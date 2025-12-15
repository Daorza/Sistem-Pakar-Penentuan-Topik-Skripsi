Imports System.Windows.Forms
Imports System.Drawing

Public Class FormManageTopics
    Inherits System.Windows.Forms.Form

    Public Sub New()
        ' Required by Windows Form Designer
        InitializeComponent()
    End Sub

    Private Sub FormManageTopics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim topics = TopicRepository.GetAll()

            dgvTopics.DataSource = Nothing
            dgvTopics.DataSource = topics

            ' Hide unnecessary columns
            If dgvTopics.Columns.Count > 0 Then
                If dgvTopics.Columns.Contains("IsActive") Then dgvTopics.Columns("IsActive").Visible = False
                If dgvTopics.Columns.Contains("CreatedAt") Then dgvTopics.Columns("CreatedAt").Visible = False
                If dgvTopics.Columns.Contains("UpdatedAt") Then dgvTopics.Columns("UpdatedAt").Visible = False
                If dgvTopics.Columns.Contains("Id") Then dgvTopics.Columns("Id").Width = 50
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New FormAddEditTopic()
        If frm.ShowDialog() = DialogResult.OK Then
            LoadData()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvTopics.SelectedRows.Count > 0 Then
            Dim selectedTopic As Topic = CType(dgvTopics.SelectedRows(0).DataBoundItem, Topic)

            Dim frm As New FormAddEditTopic(selectedTopic.Id)
            If frm.ShowDialog() = DialogResult.OK Then
                LoadData()
            End If
        Else
            MessageBox.Show("Pilih topik yang ingin diedit!")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvTopics.SelectedRows.Count > 0 Then
            If MessageBox.Show("Yakin ingin menghapus topik ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    Dim selectedTopic As Topic = CType(dgvTopics.SelectedRows(0).DataBoundItem, Topic)
                    TopicRepository.Delete(selectedTopic.Id)
                    LoadData()
                    MessageBox.Show("Berhasil dihapus!")
                Catch ex As Exception
                    MessageBox.Show("Gagal menghapus: " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Pilih topik yang ingin dihapus!")
        End If
    End Sub

    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        dgvTopics = New Guna.UI2.WinForms.Guna2DataGridView()
        btnClose = New Guna.UI2.WinForms.Guna2Button()
        btnDelete = New Guna.UI2.WinForms.Guna2Button()
        btnEdit = New Guna.UI2.WinForms.Guna2Button()
        btnAdd = New Guna.UI2.WinForms.Guna2Button()
        lblTitle = New Guna.UI2.WinForms.Guna2HtmlLabel()
        CType(dgvTopics, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvTopics
        ' 
        DataGridViewCellStyle1.BackColor = Color.White
        dgvTopics.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvTopics.BackgroundColor = Color.Azure
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvTopics.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvTopics.ColumnHeadersHeight = 4
        dgvTopics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvTopics.DefaultCellStyle = DataGridViewCellStyle3
        dgvTopics.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvTopics.Location = New Point(39, 200)
        dgvTopics.Name = "dgvTopics"
        dgvTopics.RowHeadersVisible = False
        dgvTopics.RowHeadersWidth = 51
        dgvTopics.Size = New Size(1049, 248)
        dgvTopics.TabIndex = 11
        dgvTopics.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgvTopics.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgvTopics.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgvTopics.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgvTopics.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgvTopics.ThemeStyle.BackColor = Color.Azure
        dgvTopics.ThemeStyle.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvTopics.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        dgvTopics.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgvTopics.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9.0F)
        dgvTopics.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgvTopics.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvTopics.ThemeStyle.HeaderStyle.Height = 4
        dgvTopics.ThemeStyle.ReadOnly = False
        dgvTopics.ThemeStyle.RowsStyle.BackColor = Color.White
        dgvTopics.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvTopics.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9.0F)
        dgvTopics.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        dgvTopics.ThemeStyle.RowsStyle.Height = 29
        dgvTopics.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvTopics.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' btnClose
        ' 
        btnClose.BorderRadius = 8
        btnClose.CustomizableEdges = CustomizableEdges1
        btnClose.DisabledState.BorderColor = Color.DarkGray
        btnClose.DisabledState.CustomBorderColor = Color.DarkGray
        btnClose.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnClose.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnClose.FillColor = Color.Coral
        btnClose.Font = New Font("Segoe UI", 9.0F)
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(39, 32)
        btnClose.Name = "btnClose"
        btnClose.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnClose.Size = New Size(225, 56)
        btnClose.TabIndex = 10
        btnClose.Text = "Tutup"
        ' 
        ' btnDelete
        ' 
        btnDelete.BorderRadius = 8
        btnDelete.CustomizableEdges = CustomizableEdges3
        btnDelete.DisabledState.BorderColor = Color.DarkGray
        btnDelete.DisabledState.CustomBorderColor = Color.DarkGray
        btnDelete.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnDelete.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnDelete.FillColor = Color.OrangeRed
        btnDelete.Font = New Font("Segoe UI", 9.0F)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(632, 32)
        btnDelete.Name = "btnDelete"
        btnDelete.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnDelete.Size = New Size(225, 56)
        btnDelete.TabIndex = 9
        btnDelete.Text = "Hapus Selected"
        ' 
        ' btnEdit
        ' 
        btnEdit.BorderRadius = 8
        btnEdit.CustomizableEdges = CustomizableEdges5
        btnEdit.DisabledState.BorderColor = Color.DarkGray
        btnEdit.DisabledState.CustomBorderColor = Color.DarkGray
        btnEdit.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnEdit.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnEdit.FillColor = Color.Goldenrod
        btnEdit.Font = New Font("Segoe UI", 9.0F)
        btnEdit.ForeColor = Color.White
        btnEdit.Location = New Point(863, 32)
        btnEdit.Name = "btnEdit"
        btnEdit.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnEdit.Size = New Size(225, 56)
        btnEdit.TabIndex = 8
        btnEdit.Text = "Edit Selected"
        ' 
        ' btnAdd
        ' 
        btnAdd.BorderRadius = 8
        btnAdd.CustomizableEdges = CustomizableEdges7
        btnAdd.DisabledState.BorderColor = Color.DarkGray
        btnAdd.DisabledState.CustomBorderColor = Color.DarkGray
        btnAdd.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnAdd.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnAdd.FillColor = Color.Teal
        btnAdd.Font = New Font("Segoe UI", 9.0F)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(270, 32)
        btnAdd.Name = "btnAdd"
        btnAdd.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        btnAdd.Size = New Size(225, 56)
        btnAdd.TabIndex = 7
        btnAdd.Text = "Tambah Baru"
        ' 
        ' lblTitle
        ' 
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(39, 164)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(115, 30)
        lblTitle.TabIndex = 6
        lblTitle.Text = "Daftar Topik"
        ' 
        ' FormManageTopics
        ' 
        ClientSize = New Size(1107, 460)
        Controls.Add(dgvTopics)
        Controls.Add(btnClose)
        Controls.Add(btnDelete)
        Controls.Add(btnEdit)
        Controls.Add(btnAdd)
        Controls.Add(lblTitle)
        Name = "FormManageTopics"
        CType(dgvTopics, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Friend WithEvents dgvTopics As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button

    Friend WithEvents lblTitle As Guna.UI2.WinForms.Guna2HtmlLabel

End Class