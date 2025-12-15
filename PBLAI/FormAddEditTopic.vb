Imports System.Windows.Forms
Imports System.Drawing

Public Class FormAddEditTopic
    Inherits System.Windows.Forms.Form
    Private _topicId As Integer

    Public Sub New(Optional topicId As Integer = 0)
        ' Required by Windows Form Designer
        InitializeComponent()

        _topicId = topicId

        If _topicId > 0 Then
            LoadTopicData()
            Me.Text = "Edit Topik"
        Else
            Me.Text = "Tambah Topik Baru"
        End If
    End Sub

    Private Sub LoadTopicData()
        Try
            Dim topic = TopicRepository.GetById(_topicId)
            If topic IsNot Nothing Then
                txtKode.Text = topic.Kode
                txtNama.Text = topic.Nama
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading topic data: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validation
        If String.IsNullOrWhiteSpace(txtKode.Text) Then
            MessageBox.Show("Kode Topik harus diisi!")
            txtKode.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama Topik harus diisi!")
            txtNama.Focus()
            Return
        End If

        Try
            If _topicId > 0 Then
                ' Update
                TopicRepository.Update(_topicId, txtKode.Text.Trim(), txtNama.Text.Trim())
            Else
                ' Insert
                TopicRepository.Insert(txtKode.Text.Trim(), txtNama.Text.Trim())
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan: " & ex.Message)
        End Try
    End Sub

    Private Sub InitializeComponent()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        txtKode = New Guna.UI2.WinForms.Guna2TextBox()
        txtNama = New Guna.UI2.WinForms.Guna2TextBox()
        btnSave = New Guna.UI2.WinForms.Guna2Button()
        btnCancel = New Guna.UI2.WinForms.Guna2Button()
        kodeTopik = New Guna.UI2.WinForms.Guna2HtmlLabel()
        namaTopik = New Guna.UI2.WinForms.Guna2HtmlLabel()
        SuspendLayout()
        ' 
        ' txtKode
        ' 
        txtKode.BorderRadius = 8
        txtKode.CustomizableEdges = CustomizableEdges1
        txtKode.DefaultText = ""
        txtKode.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txtKode.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txtKode.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtKode.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtKode.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtKode.Font = New Font("Segoe UI", 9F)
        txtKode.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtKode.Location = New Point(115, 53)
        txtKode.Margin = New Padding(3, 4, 3, 4)
        txtKode.Name = "txtKode"
        txtKode.PlaceholderText = ""
        txtKode.SelectedText = ""
        txtKode.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        txtKode.Size = New Size(482, 60)
        txtKode.TabIndex = 0
        ' 
        ' txtNama
        ' 
        txtNama.BorderRadius = 8
        txtNama.CustomizableEdges = CustomizableEdges3
        txtNama.DefaultText = ""
        txtNama.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txtNama.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txtNama.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtNama.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtNama.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtNama.Font = New Font("Segoe UI", 9F)
        txtNama.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtNama.Location = New Point(115, 165)
        txtNama.Margin = New Padding(3, 4, 3, 4)
        txtNama.Name = "txtNama"
        txtNama.PlaceholderText = ""
        txtNama.SelectedText = ""
        txtNama.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        txtNama.Size = New Size(482, 60)
        txtNama.TabIndex = 1
        ' 
        ' btnSave
        ' 
        btnSave.BorderRadius = 8
        btnSave.CustomizableEdges = CustomizableEdges5
        btnSave.DisabledState.BorderColor = Color.DarkGray
        btnSave.DisabledState.CustomBorderColor = Color.DarkGray
        btnSave.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnSave.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnSave.FillColor = Color.Teal
        btnSave.Font = New Font("Segoe UI", 9F)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(372, 297)
        btnSave.Name = "btnSave"
        btnSave.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnSave.Size = New Size(225, 56)
        btnSave.TabIndex = 2
        btnSave.Text = "Simpan"
        ' 
        ' btnCancel
        ' 
        btnCancel.BorderRadius = 8
        btnCancel.CustomizableEdges = CustomizableEdges7
        btnCancel.DisabledState.BorderColor = Color.DarkGray
        btnCancel.DisabledState.CustomBorderColor = Color.DarkGray
        btnCancel.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnCancel.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnCancel.FillColor = Color.Coral
        btnCancel.Font = New Font("Segoe UI", 9F)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(115, 297)
        btnCancel.Name = "btnCancel"
        btnCancel.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        btnCancel.Size = New Size(225, 56)
        btnCancel.TabIndex = 3
        btnCancel.Text = "Batal"
        ' 
        ' kodeTopik
        ' 
        kodeTopik.BackColor = Color.Transparent
        kodeTopik.Location = New Point(115, 24)
        kodeTopik.Name = "kodeTopik"
        kodeTopik.Size = New Size(79, 22)
        kodeTopik.TabIndex = 4
        kodeTopik.Text = "Kode Topik"
        ' 
        ' namaTopik
        ' 
        namaTopik.BackColor = Color.Transparent
        namaTopik.Location = New Point(115, 136)
        namaTopik.Name = "namaTopik"
        namaTopik.Size = New Size(84, 22)
        namaTopik.TabIndex = 5
        namaTopik.Text = "Nama Topik"
        ' 
        ' FormAddEditTopic
        ' 
        ClientSize = New Size(702, 412)
        Controls.Add(namaTopik)
        Controls.Add(kodeTopik)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(txtNama)
        Controls.Add(txtKode)
        Name = "FormAddEditTopic"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Friend WithEvents txtKode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtNama As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents kodeTopik As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents namaTopik As Guna.UI2.WinForms.Guna2HtmlLabel
End Class