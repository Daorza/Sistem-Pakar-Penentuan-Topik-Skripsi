<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddEditSubtopic
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
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges13 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges14 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges15 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges16 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges17 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges18 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges19 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges20 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        title = New Guna.UI2.WinForms.Guna2HtmlLabel()
        cboTopic = New Guna.UI2.WinForms.Guna2ComboBox()
        subtopik = New Guna.UI2.WinForms.Guna2HtmlLabel()
        txtKode = New Guna.UI2.WinForms.Guna2TextBox()
        txtNama = New Guna.UI2.WinForms.Guna2TextBox()
        namasubtopik = New Guna.UI2.WinForms.Guna2HtmlLabel()
        btnSave = New Guna.UI2.WinForms.Guna2Button()
        btnCancel = New Guna.UI2.WinForms.Guna2Button()
        SuspendLayout()
        ' 
        ' title
        ' 
        title.BackColor = Color.Transparent
        title.Location = New Point(111, 68)
        title.Name = "title"
        title.Size = New Size(83, 22)
        title.TabIndex = 0
        title.Text = "Topik Induk:"
        ' 
        ' cboTopic
        ' 
        cboTopic.BackColor = Color.Transparent
        cboTopic.CustomizableEdges = CustomizableEdges11
        cboTopic.DrawMode = DrawMode.OwnerDrawFixed
        cboTopic.DropDownStyle = ComboBoxStyle.DropDownList
        cboTopic.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        cboTopic.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        cboTopic.Font = New Font("Segoe UI", 10F)
        cboTopic.ForeColor = Color.FromArgb(CByte(68), CByte(88), CByte(112))
        cboTopic.ItemHeight = 30
        cboTopic.Location = New Point(111, 119)
        cboTopic.Name = "cboTopic"
        cboTopic.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        cboTopic.Size = New Size(175, 36)
        cboTopic.TabIndex = 1
        ' 
        ' subtopik
        ' 
        subtopik.BackColor = Color.Transparent
        subtopik.Location = New Point(111, 194)
        subtopik.Name = "subtopik"
        subtopik.Size = New Size(104, 22)
        subtopik.TabIndex = 2
        subtopik.Text = "Kode Subtopik:"
        ' 
        ' txtKode
        ' 
        txtKode.CustomizableEdges = CustomizableEdges13
        txtKode.DefaultText = ""
        txtKode.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txtKode.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txtKode.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtKode.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtKode.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtKode.Font = New Font("Segoe UI", 9F)
        txtKode.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtKode.Location = New Point(111, 236)
        txtKode.Margin = New Padding(3, 4, 3, 4)
        txtKode.Name = "txtKode"
        txtKode.PlaceholderText = ""
        txtKode.SelectedText = ""
        txtKode.ShadowDecoration.CustomizableEdges = CustomizableEdges14
        txtKode.Size = New Size(286, 60)
        txtKode.TabIndex = 3
        ' 
        ' txtNama
        ' 
        txtNama.CustomizableEdges = CustomizableEdges15
        txtNama.DefaultText = ""
        txtNama.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txtNama.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txtNama.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtNama.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtNama.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtNama.Font = New Font("Segoe UI", 9F)
        txtNama.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtNama.Location = New Point(111, 357)
        txtNama.Margin = New Padding(3, 4, 3, 4)
        txtNama.Name = "txtNama"
        txtNama.PlaceholderText = ""
        txtNama.SelectedText = ""
        txtNama.ShadowDecoration.CustomizableEdges = CustomizableEdges16
        txtNama.Size = New Size(286, 60)
        txtNama.TabIndex = 5
        ' 
        ' namasubtopik
        ' 
        namasubtopik.BackColor = Color.Transparent
        namasubtopik.Location = New Point(111, 315)
        namasubtopik.Name = "namasubtopik"
        namasubtopik.Size = New Size(109, 22)
        namasubtopik.TabIndex = 4
        namasubtopik.Text = "Nama Subtopik:"
        ' 
        ' btnSave
        ' 
        btnSave.CustomizableEdges = CustomizableEdges17
        btnSave.DisabledState.BorderColor = Color.DarkGray
        btnSave.DisabledState.CustomBorderColor = Color.DarkGray
        btnSave.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnSave.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnSave.Font = New Font("Segoe UI", 9F)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(528, 128)
        btnSave.Name = "btnSave"
        btnSave.ShadowDecoration.CustomizableEdges = CustomizableEdges18
        btnSave.Size = New Size(225, 56)
        btnSave.TabIndex = 6
        btnSave.Text = "Simpan"
        ' 
        ' btnCancel
        ' 
        btnCancel.CustomizableEdges = CustomizableEdges19
        btnCancel.DisabledState.BorderColor = Color.DarkGray
        btnCancel.DisabledState.CustomBorderColor = Color.DarkGray
        btnCancel.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnCancel.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnCancel.Font = New Font("Segoe UI", 9F)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(528, 212)
        btnCancel.Name = "btnCancel"
        btnCancel.ShadowDecoration.CustomizableEdges = CustomizableEdges20
        btnCancel.Size = New Size(225, 56)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Cancel"
        ' 
        ' FormAddEditSubtopic
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(txtNama)
        Controls.Add(namasubtopik)
        Controls.Add(txtKode)
        Controls.Add(subtopik)
        Controls.Add(cboTopic)
        Controls.Add(title)
        Name = "FormAddEditSubtopic"
        Text = "FormAddEditSubtopic"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents title As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents cboTopic As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents subtopik As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtKode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtNama As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents namasubtopik As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnCancel As Guna.UI2.WinForms.Guna2Button
End Class
