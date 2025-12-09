Imports Guna.UI2.WinForms
Public Class Form1
    ''' <summary>
    ''' Form Load - Initialize controls
    ''' </summary>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup TextBox placeholders
        txtNama.PlaceholderText = "Nama Lengkap Mahasiswa"
        txtNama.Text = ""

        txtNIM.PlaceholderText = "NIM Mahasiswa"
        txtNIM.Text = ""

        ' Setup ComboBox
        InitializeProdiComboBox()
        ' Setup Admin Link
        Dim linkAdmin As New LinkLabel()
        linkAdmin.Text = "Admin Login"
        linkAdmin.AutoSize = True
        linkAdmin.Location = New Point(10, Me.ClientSize.Height - 30)
        linkAdmin.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Me.Controls.Add(linkAdmin)
        AddHandler linkAdmin.LinkClicked, AddressOf LinkAdmin_Clicked

        ' Test database connection
        If Not DatabaseHelper.TestConnection() Then
            MessageBox.Show("Koneksi database gagal! Periksa connection string.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub LinkAdmin_Clicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim frmLogin As New FormLogin()
        frmLogin.ShowDialog()
    End Sub

    ''' <summary>
    ''' Initialize Program Studi ComboBox
    ''' </summary>
    Private Sub InitializeProdiComboBox()
        comboProdi.Items.Clear()
        comboProdi.Items.AddRange(New Object() {
            "--- Pilih Program Studi ---",
            "D4 Teknik Informatika",
            "D3 Teknik Multimedia Digital",
            "D4 Teknik Multimedia Jaringan"
        })

        comboProdi.SelectedIndex = 0
        comboProdi.DrawMode = DrawMode.OwnerDrawFixed
        comboProdi.DropDownStyle = ComboBoxStyle.DropDownList
        comboProdi.ItemHeight = 30
    End Sub

    ''' <summary>
    ''' ComboBox selection changed - update color
    ''' </summary>
    Private Sub comboProdi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboProdi.SelectedIndexChanged
        If comboProdi.SelectedIndex = 0 Then
            comboProdi.ForeColor = Color.Gray
        Else
            comboProdi.ForeColor = Color.Black
        End If
    End Sub

    ''' <summary>
    ''' Button Keluar - Exit application
    ''' </summary>
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If MessageBox.Show("Yakin ingin keluar dari aplikasi?", "Konfirmasi",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    ''' <summary>
    ''' Button Mulai Tes - Validate & Insert User
    ''' </summary>
    Private Sub buttonMulai_Click(sender As Object, e As EventArgs) Handles buttonMulai.Click
        ' Validation
        If Not ValidateInput() Then
            Return
        End If

        Try
            ' Insert user using repository
            Dim userId As Integer = UserRepository.Insert(
                txtNama.Text.Trim(),
                txtNIM.Text.Trim(),
                comboProdi.Text
            )

            ' Set global variables
            GlobalUser.UserId = userId
            GlobalUser.Nama = txtNama.Text.Trim()
            GlobalUser.NIM = txtNIM.Text.Trim()
            GlobalUser.Prodi = comboProdi.Text

            ' Navigate to Level 1 questions
            Dim frmQuiz As New FormPertanyaanAwal()
            frmQuiz.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Validate user input
    ''' </summary>
    Private Function ValidateInput() As Boolean
        ' Check empty fields
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama tidak boleh kosong!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtNIM.Text) Then
            MessageBox.Show("NIM tidak boleh kosong!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNIM.Focus()
            Return False
        End If

        If comboProdi.SelectedIndex = 0 Then
            MessageBox.Show("Silakan pilih Program Studi!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            comboProdi.Focus()
            Return False
        End If

        ' Validate NIM format (contoh: harus angka)
        If Not IsNumeric(txtNIM.Text.Trim()) Then
            MessageBox.Show("NIM harus berisi angka saja!", "Validasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNIM.Focus()
            Return False
        End If

        Return True
    End Function
End Class