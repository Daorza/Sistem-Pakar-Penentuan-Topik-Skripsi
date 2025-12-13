<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormManageSubtopics
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
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
        dgvSubtopics = New Guna.UI2.WinForms.Guna2DataGridView()
        btnClose = New Guna.UI2.WinForms.Guna2Button()
        btnDelete = New Guna.UI2.WinForms.Guna2Button()
        btnEdit = New Guna.UI2.WinForms.Guna2Button()
        btnAdd = New Guna.UI2.WinForms.Guna2Button()
        lblTitle = New Guna.UI2.WinForms.Guna2HtmlLabel()
        CType(dgvSubtopics, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvSubtopics
        ' 
        DataGridViewCellStyle1.BackColor = Color.White
        dgvSubtopics.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvSubtopics.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvSubtopics.ColumnHeadersHeight = 4
        dgvSubtopics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvSubtopics.DefaultCellStyle = DataGridViewCellStyle3
        dgvSubtopics.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvSubtopics.Location = New Point(142, 203)
        dgvSubtopics.Name = "dgvSubtopics"
        dgvSubtopics.RowHeadersVisible = False
        dgvSubtopics.RowHeadersWidth = 51
        dgvSubtopics.Size = New Size(1049, 236)
        dgvSubtopics.TabIndex = 17
        dgvSubtopics.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgvSubtopics.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgvSubtopics.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgvSubtopics.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgvSubtopics.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgvSubtopics.ThemeStyle.BackColor = Color.White
        dgvSubtopics.ThemeStyle.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvSubtopics.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        dgvSubtopics.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgvSubtopics.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9F)
        dgvSubtopics.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgvSubtopics.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvSubtopics.ThemeStyle.HeaderStyle.Height = 4
        dgvSubtopics.ThemeStyle.ReadOnly = False
        dgvSubtopics.ThemeStyle.RowsStyle.BackColor = Color.White
        dgvSubtopics.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvSubtopics.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9F)
        dgvSubtopics.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        dgvSubtopics.ThemeStyle.RowsStyle.Height = 29
        dgvSubtopics.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgvSubtopics.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' btnClose
        ' 
        btnClose.CustomizableEdges = CustomizableEdges1
        btnClose.DisabledState.BorderColor = Color.DarkGray
        btnClose.DisabledState.CustomBorderColor = Color.DarkGray
        btnClose.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnClose.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnClose.Font = New Font("Segoe UI", 9F)
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(575, 39)
        btnClose.Name = "btnClose"
        btnClose.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnClose.Size = New Size(225, 56)
        btnClose.TabIndex = 16
        btnClose.Text = "Tutup"
        ' 
        ' btnDelete
        ' 
        btnDelete.CustomizableEdges = CustomizableEdges3
        btnDelete.DisabledState.BorderColor = Color.DarkGray
        btnDelete.DisabledState.CustomBorderColor = Color.DarkGray
        btnDelete.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnDelete.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnDelete.Font = New Font("Segoe UI", 9F)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(432, 125)
        btnDelete.Name = "btnDelete"
        btnDelete.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnDelete.Size = New Size(225, 56)
        btnDelete.TabIndex = 15
        btnDelete.Text = "Hapus Selected"
        ' 
        ' btnEdit
        ' 
        btnEdit.CustomizableEdges = CustomizableEdges5
        btnEdit.DisabledState.BorderColor = Color.DarkGray
        btnEdit.DisabledState.CustomBorderColor = Color.DarkGray
        btnEdit.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnEdit.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnEdit.Font = New Font("Segoe UI", 9F)
        btnEdit.ForeColor = Color.White
        btnEdit.Location = New Point(966, 148)
        btnEdit.Name = "btnEdit"
        btnEdit.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnEdit.Size = New Size(225, 56)
        btnEdit.TabIndex = 14
        btnEdit.Text = "Edit Selected"
        ' 
        ' btnAdd
        ' 
        btnAdd.CustomizableEdges = CustomizableEdges7
        btnAdd.DisabledState.BorderColor = Color.DarkGray
        btnAdd.DisabledState.CustomBorderColor = Color.DarkGray
        btnAdd.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnAdd.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnAdd.Font = New Font("Segoe UI", 9F)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(326, 11)
        btnAdd.Name = "btnAdd"
        btnAdd.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        btnAdd.Size = New Size(225, 56)
        btnAdd.TabIndex = 13
        btnAdd.Text = "Tambah Baru"
        ' 
        ' lblTitle
        ' 
        lblTitle.BackColor = Color.Transparent
        lblTitle.Location = New Point(705, 127)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(111, 22)
        lblTitle.TabIndex = 12
        lblTitle.Text = "Daftar SubTopik"
        ' 
        ' FormManageSubtopics
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1332, 450)
        Controls.Add(dgvSubtopics)
        Controls.Add(btnClose)
        Controls.Add(btnDelete)
        Controls.Add(btnEdit)
        Controls.Add(btnAdd)
        Controls.Add(lblTitle)
        Name = "FormManageSubtopics"
        Text = "FormManageSubtopics"
        CType(dgvSubtopics, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvSubtopics As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents btnClose As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnEdit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblTitle As Guna.UI2.WinForms.Guna2HtmlLabel
End Class
