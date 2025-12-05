Imports Guna.UI2.WinForms.Suite

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Application.Exit()
    End Sub

    Private Sub buttonMulai_Click(sender As Object, e As EventArgs) Handles buttonMulai.Click
        If txtNama.Text.Trim = "" Then
            MessageBox.Show("Nama harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtNIM.Text.Trim = "" Then
            MessageBox.Show("NIM harus diisi.", "Peringaran", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If comboProdi.SelectedIndex = 0 Then
            MessageBox.Show("Silakan pilih program studi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        GlobalUser.Nama = txtNIM.Text
        GlobalUser.NIM = txtNIM.Text
        GlobalUser.Prodi = comboProdi.Text

        Dim f As New FormPertanyaanAwal
        f.Show()
        Me.Hide()
    End Sub
End Class
