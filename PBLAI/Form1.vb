Imports Guna.UI2.WinForms.Suite
Imports Microsoft.Data.SqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenConnection()
        txtNama.PlaceholderText = "Nama Lengkap Mahasiswa"
        txtNama.DefaultText = ""

        txtNIM.PlaceholderText = "NIM Mahasiswa"
        txtNIM.DefaultText = ""

        comboProdi.Items.Clear()

        comboProdi.Items.AddRange(New Object() {
            "--- Pilih Program Studi ---",
            "Teknik Informatika",
            "Teknik Multimedia Digital",
            "Teknik Multimedia Jaringan",
            "Teknik Komputer Jaringan"
        })

        comboProdi.SelectedIndex = 0
    End Sub

    Private Sub comboProdi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboProdi.SelectedIndexChanged
        Dim selected = comboProdi.SelectedItem?.ToString()
        comboProdi.DrawMode = DrawMode.OwnerDrawFixed
        comboProdi.DropDownStyle = ComboBoxStyle.DropDownList
        comboProdi.ItemHeight = 30

        If comboProdi.SelectedIndex = 0 Then
            comboProdi.ForeColor = Color.Gray
        Else
            comboProdi.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If MessageBox.Show("Yakin ingin keluar dari aplikasi?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub buttonMulai_Click(sender As Object, e As EventArgs) Handles buttonMulai.Click
        If txtNama.Text.Trim = "" Or txtNIM.Text.Trim = "" Or comboProdi.SelectedIndex = 0 Then
            MessageBox.Show("Harap lengkapi Nama, NIM, dan Prodi terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            If conn.State <> ConnectionState.Open Then
                OpenConnection()
            End If

            Dim sql As String = "INSERT INTO users (nama, nim, prodi) VALUES (@nama, @nim, @prodi); SELECT SCOPE_IDENTITY();"
            Dim cmd As New SqlCommand(sql, conn)

            cmd.Parameters.AddWithValue("@nama", txtNama.Text)
            cmd.Parameters.AddWithValue("@nim", txtNIM.Text)
            cmd.Parameters.AddWithValue("@prodi", comboProdi.Text)

            Dim userId As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            CurrentUserId = userId
            GlobalUser.Nama = txtNama.Text
            GlobalUser.NIM = txtNIM.Text
            GlobalUser.Prodi = comboProdi.Text

            Dim f As New FormPertanyaanAwal
            f.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data: " & ex.Message)
        End Try
    End Sub

    Private Sub panelCard_Paint(sender As Object, e As PaintEventArgs) Handles panelCard.Paint

    End Sub

End Class
