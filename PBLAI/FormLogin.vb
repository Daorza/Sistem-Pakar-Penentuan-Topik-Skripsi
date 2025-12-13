Imports System.Windows.Forms
Imports System.Drawing
Public Class FormLogin
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Username dan Password harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            ' Validate user using UserRepository
            Dim user = UserRepository.GetByNimAndPassword(username, password)
            If user IsNot Nothing Then
                If user.Role.ToLower() = "admin" Then
                    MessageBox.Show("Login Berhasil! Selamat datang Admin.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Create GlobalUser context if needed, or just pass user
                    GlobalUser.CurrentUser = user

                    ' Open Admin Dashboard
                    Dim frmDashboard As New FormAdminDashboard(user)
                    frmDashboard.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Akses Ditolak! Akun anda bukan Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Username atau Password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    ' Handle closing
    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)
        ' If this was shown from another form, we might want to ensure app doesn't exit if main form is hidden
    End Sub

End Class
