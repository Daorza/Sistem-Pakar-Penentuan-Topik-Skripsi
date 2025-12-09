Imports System.Windows.Forms
Imports System.Drawing
Public Class FormLogin
    Inherits System.Windows.Forms.Form
    Private lblTitle As Label
    Private lblUsername As Label
    Private lblPassword As Label
    Private txtUsername As TextBox
    Private txtPassword As TextBox
    Private btnLogin As Button
    Private btnCancel As Button
    Public Sub New()
        SetupUI()
    End Sub
    Private Sub SetupUI()
        Me.lblTitle = New Label()
        Me.lblUsername = New Label()
        Me.lblPassword = New Label()
        Me.txtUsername = New TextBox()
        Me.txtPassword = New TextBox()
        Me.btnLogin = New Button()
        Me.btnCancel = New Button()
        Me.SuspendLayout()
        ' Form settings
        Me.Text = "Admin Login - Sistem Pakar"
        Me.Size = New Size(400, 300)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        ' Title
        Me.lblTitle.Text = "Login Administrator"
        Me.lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New Point(100, 30)
        ' Username Label
        Me.lblUsername.Text = "Username / NIM:"
        Me.lblUsername.Location = New Point(50, 80)
        Me.lblUsername.AutoSize = True
        ' Username TextBox
        Me.txtUsername.Location = New Point(50, 100)
        Me.txtUsername.Size = New Size(280, 25)
        ' Password Label
        Me.lblPassword.Text = "Password:"
        Me.lblPassword.Location = New Point(50, 140)
        Me.lblPassword.AutoSize = True
        ' Password TextBox
        Me.txtPassword.Location = New Point(50, 160)
        Me.txtPassword.Size = New Size(280, 25)
        Me.txtPassword.PasswordChar = "*"c
        ' Login Button
        Me.btnLogin.Text = "Login"
        Me.btnLogin.Location = New Point(50, 200)
        Me.btnLogin.Size = New Size(130, 35)
        Me.btnLogin.BackColor = Color.DodgerBlue
        Me.btnLogin.ForeColor = Color.White
        Me.btnLogin.FlatStyle = FlatStyle.Flat
        AddHandler Me.btnLogin.Click, AddressOf Me.btnLogin_Click
        ' Cancel Button
        Me.btnCancel.Text = "Batal"
        Me.btnCancel.Location = New Point(200, 200)
        Me.btnCancel.Size = New Size(130, 35)
        AddHandler Me.btnCancel.Click, AddressOf Me.btnCancel_Click
        ' Add Controls
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.btnCancel)
        Me.ResumeLayout(False)
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs)
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
    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    ' Handle closing
    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)
        ' If this was shown from another form, we might want to ensure app doesn't exit if main form is hidden
    End Sub
End Class
