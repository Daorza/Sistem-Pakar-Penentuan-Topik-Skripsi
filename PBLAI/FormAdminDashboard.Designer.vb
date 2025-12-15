<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAdminDashboard
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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        panelMenu = New FlowLayoutPanel()
        btnManageTopics = New Guna.UI2.WinForms.Guna2Button()
        btnManageQuestions = New Guna.UI2.WinForms.Guna2Button()
        lblWelcome = New Guna.UI2.WinForms.Guna2HtmlLabel()
        btnLogout = New Guna.UI2.WinForms.Guna2Button()
        btnManageSubtopics = New Guna.UI2.WinForms.Guna2Button()
        SuspendLayout()
        ' 
        ' panelMenu
        ' 
        panelMenu.Location = New Point(283, 225)
        panelMenu.Name = "panelMenu"
        panelMenu.Size = New Size(490, 118)
        panelMenu.TabIndex = 4
        ' 
        ' btnManageTopics
        ' 
        btnManageTopics.BorderRadius = 8
        btnManageTopics.CustomizableEdges = CustomizableEdges1
        btnManageTopics.DisabledState.BorderColor = Color.DarkGray
        btnManageTopics.DisabledState.CustomBorderColor = Color.DarkGray
        btnManageTopics.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnManageTopics.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnManageTopics.FillColor = Color.Teal
        btnManageTopics.Font = New Font("Segoe UI", 9F)
        btnManageTopics.ForeColor = Color.White
        btnManageTopics.Location = New Point(35, 97)
        btnManageTopics.Name = "btnManageTopics"
        btnManageTopics.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnManageTopics.Size = New Size(225, 56)
        btnManageTopics.TabIndex = 14
        btnManageTopics.Text = "Kelola Topik"
        ' 
        ' btnManageQuestions
        ' 
        btnManageQuestions.BorderRadius = 8
        btnManageQuestions.CustomizableEdges = CustomizableEdges3
        btnManageQuestions.DisabledState.BorderColor = Color.DarkGray
        btnManageQuestions.DisabledState.CustomBorderColor = Color.DarkGray
        btnManageQuestions.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnManageQuestions.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnManageQuestions.FillColor = Color.Teal
        btnManageQuestions.Font = New Font("Segoe UI", 9F)
        btnManageQuestions.ForeColor = Color.White
        btnManageQuestions.Location = New Point(35, 159)
        btnManageQuestions.Name = "btnManageQuestions"
        btnManageQuestions.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnManageQuestions.Size = New Size(225, 56)
        btnManageQuestions.TabIndex = 13
        btnManageQuestions.Text = "Kelola Pertanyaan"
        ' 
        ' lblWelcome
        ' 
        lblWelcome.BackColor = Color.Transparent
        lblWelcome.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblWelcome.Location = New Point(123, 40)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(42, 30)
        lblWelcome.TabIndex = 12
        lblWelcome.Text = "Title"
        ' 
        ' btnLogout
        ' 
        btnLogout.BorderRadius = 8
        btnLogout.CustomizableEdges = CustomizableEdges5
        btnLogout.DisabledState.BorderColor = Color.DarkGray
        btnLogout.DisabledState.CustomBorderColor = Color.DarkGray
        btnLogout.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnLogout.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnLogout.FillColor = Color.Coral
        btnLogout.Font = New Font("Segoe UI", 9F)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(35, 370)
        btnLogout.Name = "btnLogout"
        btnLogout.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnLogout.Size = New Size(225, 56)
        btnLogout.TabIndex = 15
        btnLogout.Text = "Logout"
        ' 
        ' btnManageSubtopics
        ' 
        btnManageSubtopics.BorderRadius = 8
        btnManageSubtopics.CustomizableEdges = CustomizableEdges7
        btnManageSubtopics.DisabledState.BorderColor = Color.DarkGray
        btnManageSubtopics.DisabledState.CustomBorderColor = Color.DarkGray
        btnManageSubtopics.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnManageSubtopics.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnManageSubtopics.FillColor = Color.Teal
        btnManageSubtopics.Font = New Font("Segoe UI", 9F)
        btnManageSubtopics.ForeColor = Color.White
        btnManageSubtopics.Location = New Point(35, 221)
        btnManageSubtopics.Name = "btnManageSubtopics"
        btnManageSubtopics.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        btnManageSubtopics.Size = New Size(225, 56)
        btnManageSubtopics.TabIndex = 16
        btnManageSubtopics.Text = "Kelola Subtopik"
        ' 
        ' FormAdminDashboard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnManageSubtopics)
        Controls.Add(btnLogout)
        Controls.Add(btnManageTopics)
        Controls.Add(btnManageQuestions)
        Controls.Add(panelMenu)
        Controls.Add(lblWelcome)
        Name = "FormAdminDashboard"
        Text = "FormAdminDashboard"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents panelMenu As FlowLayoutPanel
    Friend WithEvents btnManageTopics As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnManageQuestions As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblWelcome As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnLogout As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnManageSubtopics As Guna.UI2.WinForms.Guna2Button
End Class
