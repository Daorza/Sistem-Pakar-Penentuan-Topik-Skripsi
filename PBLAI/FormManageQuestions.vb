Imports System.Windows.Forms
Imports System.Drawing

Public Class FormManageQuestions
    Inherits System.Windows.Forms.Form

    Public Sub New()
        ' Required by Windows Form Designer
        InitializeComponent()
    End Sub

    Private Sub FormManageQuestions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            ' Get all questions
            Dim questions = QuestionRepository.GetAll()

            ' Setup Grid manually or bind list
            dgvQuestions.DataSource = Nothing
            dgvQuestions.DataSource = questions

            ' Rename headers safely
            If dgvQuestions.Columns.Count > 0 Then
                If dgvQuestions.Columns.Contains("IsActive") Then dgvQuestions.Columns("IsActive").Visible = False
                If dgvQuestions.Columns.Contains("CreatedAt") Then dgvQuestions.Columns("CreatedAt").Visible = False
                If dgvQuestions.Columns.Contains("UpdatedAt") Then dgvQuestions.Columns("UpdatedAt").Visible = False
                If dgvQuestions.Columns.Contains("Id") Then dgvQuestions.Columns("Id").Width = 50
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Open Add Form
        Dim frm As New FormAddEditQuestion()
        If frm.ShowDialog() = DialogResult.OK Then
            LoadData()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvQuestions.SelectedRows.Count > 0 Then
            Dim selectedQ As Question = CType(dgvQuestions.SelectedRows(0).DataBoundItem, Question)

            Dim frm As New FormAddEditQuestion(selectedQ.Id)
            If frm.ShowDialog() = DialogResult.OK Then
                LoadData()
            End If
        Else
            MessageBox.Show("Pilih pertanyaan yang ingin diedit!")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvQuestions.SelectedRows.Count > 0 Then
            If MessageBox.Show("Yakin ingin menghapus pertanyaan ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    Dim selectedQ As Question = CType(dgvQuestions.SelectedRows(0).DataBoundItem, Question)
                    QuestionRepository.Delete(selectedQ.Id)
                    LoadData()
                    MessageBox.Show("Berhasil dihapus!")
                Catch ex As Exception
                    MessageBox.Show("Gagal menghapus: " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Pilih pertanyaan yang ingin dihapus!")
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        ' Leave empty. You can delete the button in the Designer view now.
    End Sub

    Friend WithEvents lblTitle As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dgvQuestions As Guna.UI2.WinForms.Guna2DataGridView

    Private Sub InitializeComponent()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        lblTitle = New Guna.UI2.WinForms.Guna2HtmlLabel()
        btnAdd = New Guna.UI2.WinForms.Guna2Button()
        btnEdit = New Guna.UI2.WinForms.Guna2Button()
        btnDelete = New Guna.UI2.WinForms.Guna2Button()
        btnClose = New Guna.UI2.WinForms.Guna2Button()
        dgvQuestions = New Guna.UI2.WinForms.Guna2DataGridView()
        CType(dgvQuestions, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(31, 160)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(308, 30)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Daftar Pertanyaan & Aturan Pakar"
        ' 
        ' btnAdd
        ' 
        btnAdd.BorderRadius = 8
        btnAdd.CustomizableEdges = CustomizableEdges1
        btnAdd.DisabledState.BorderColor = Color.DarkGray
        btnAdd.DisabledState.CustomBorderColor = Color.DarkGray
        btnAdd.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnAdd.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnAdd.FillColor = Color.Teal
        btnAdd.Font = New Font("Segoe UI", 9F)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(262, 37)
        btnAdd.Name = "btnAdd"
        btnAdd.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnAdd.Size = New Size(225, 56)
        btnAdd.TabIndex = 1
        btnAdd.Text = "Tambah Baru"
        ' 
        ' btnEdit
        ' 
        btnEdit.BorderRadius = 8
        btnEdit.CustomizableEdges = CustomizableEdges3
        btnEdit.DisabledState.BorderColor = Color.DarkGray
        btnEdit.DisabledState.CustomBorderColor = Color.DarkGray
        btnEdit.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnEdit.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnEdit.FillColor = Color.Goldenrod
        btnEdit.Font = New Font("Segoe UI", 9F)
        btnEdit.ForeColor = Color.White
        btnEdit.Location = New Point(855, 37)
        btnEdit.Name = "btnEdit"
        btnEdit.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnEdit.Size = New Size(225, 56)
        btnEdit.TabIndex = 2
        btnEdit.Text = "Edit Selected"
        ' 
        ' btnDelete
        ' 
        btnDelete.BorderRadius = 8
        btnDelete.CustomizableEdges = CustomizableEdges5
        btnDelete.DisabledState.BorderColor = Color.DarkGray
        btnDelete.DisabledState.CustomBorderColor = Color.DarkGray
        btnDelete.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnDelete.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnDelete.FillColor = Color.OrangeRed
        btnDelete.Font = New Font("Segoe UI", 9F)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(624, 37)
        btnDelete.Name = "btnDelete"
        btnDelete.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnDelete.Size = New Size(225, 56)
        btnDelete.TabIndex = 3
        btnDelete.Text = "Hapus Selected"
        ' 
        ' btnClose
        ' 
        btnClose.BorderRadius = 8
        btnClose.CustomizableEdges = CustomizableEdges7
        btnClose.DisabledState.BorderColor = Color.DarkGray
        btnClose.DisabledState.CustomBorderColor = Color.DarkGray
        btnClose.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnClose.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnClose.FillColor = Color.Coral
        btnClose.Font = New Font("Segoe UI", 9F)
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(31, 37)
        btnClose.Name = "btnClose"
        btnClose.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        btnClose.Size = New Size(225, 56)
        btnClose.TabIndex = 4
        btnClose.Text = "Tutup"
        ' 
        ' dgvQuestions
        ' 
        DataGridViewCellStyle1.BackColor = Color.White
        dgvQuestions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvQuestions.BackgroundColor = Color.Azure
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvQuestions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvQuestions.ColumnHeadersHeight = 4
        dgvQuestions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvQuestions.DefaultCellStyle = DataGridViewCellStyle3
        dgvQuestions.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvQuestions.Location = New Point(31, 196)
        dgvQuestions.Name = "dgvQuestions"
        dgvQuestions.RowHeadersVisible = False
        dgvQuestions.RowHeadersWidth = 51
        dgvQuestions.Size = New Size(1049, 237)
        dgvQuestions.TabIndex = 5
        dgvQuestions.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgvQuestions.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgvQuestions.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgvQuestions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgvQuestions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgvQuestions.ThemeStyle.BackColor = Color.Azure
        dgvQuestions.ThemeStyle.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvQuestions.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        dgvQuestions.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgvQuestions.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9F)
        dgvQuestions.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgvQuestions.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvQuestions.ThemeStyle.HeaderStyle.Height = 4
        dgvQuestions.ThemeStyle.ReadOnly = False
        dgvQuestions.ThemeStyle.RowsStyle.BackColor = Color.White
        dgvQuestions.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvQuestions.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9F)
        dgvQuestions.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        dgvQuestions.ThemeStyle.RowsStyle.Height = 29
        dgvQuestions.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvQuestions.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' FormManageQuestions
        ' 
        ClientSize = New Size(1107, 460)
        Controls.Add(dgvQuestions)
        Controls.Add(btnClose)
        Controls.Add(btnDelete)
        Controls.Add(btnEdit)
        Controls.Add(btnAdd)
        Controls.Add(lblTitle)
        Name = "FormManageQuestions"
        CType(dgvQuestions, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
End Class