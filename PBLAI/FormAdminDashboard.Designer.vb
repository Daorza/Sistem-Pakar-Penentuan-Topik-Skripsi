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
        panelMenu.Location = New Point(267, 247)
        panelMenu.Name = "panelMenu"
        panelMenu.Size = New Size(250, 125)
        panelMenu.TabIndex = 4
        ' 
        ' btnManageTopics
        ' 
        btnManageTopics.CustomizableEdges = CustomizableEdges1
        btnManageTopics.DisabledState.BorderColor = Color.DarkGray
        btnManageTopics.DisabledState.CustomBorderColor = Color.DarkGray
        btnManageTopics.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnManageTopics.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnManageTopics.Font = New Font("Segoe UI", 9.0F)
        btnManageTopics.ForeColor = Color.White
        btnManageTopics.Location = New Point(35, 163)
        btnManageTopics.Name = "btnManageTopics"
        btnManageTopics.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnManageTopics.Size = New Size(225, 56)
        btnManageTopics.TabIndex = 14
        btnManageTopics.Text = "Manage Topics"
        ' 
        ' btnManageQuestions
        ' 
        btnManageQuestions.CustomizableEdges = CustomizableEdges3
        btnManageQuestions.DisabledState.BorderColor = Color.DarkGray
        btnManageQuestions.DisabledState.CustomBorderColor = Color.DarkGray
        btnManageQuestions.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnManageQuestions.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnManageQuestions.Font = New Font("Segoe UI", 9.0F)
        btnManageQuestions.ForeColor = Color.White
        btnManageQuestions.Location = New Point(35, 225)
        btnManageQuestions.Name = "btnManageQuestions"
        btnManageQuestions.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnManageQuestions.Size = New Size(225, 56)
        btnManageQuestions.TabIndex = 13
        btnManageQuestions.Text = "Manage Questions"
        ' 
        ' lblWelcome
        ' 
        lblWelcome.BackColor = Color.Transparent
        lblWelcome.Location = New Point(101, 47)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(32, 22)
        lblWelcome.TabIndex = 12
        lblWelcome.Text = "Title"
        ' 
        ' btnLogout
        ' 
        btnLogout.CustomizableEdges = CustomizableEdges5
        btnLogout.DisabledState.BorderColor = Color.DarkGray
        btnLogout.DisabledState.CustomBorderColor = Color.DarkGray
        btnLogout.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnLogout.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnLogout.Font = New Font("Segoe UI", 9.0F)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(35, 101)
        btnLogout.Name = "btnLogout"
        btnLogout.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnLogout.Size = New Size(225, 56)
        btnLogout.TabIndex = 15
        btnLogout.Text = "Logout"
        ' 
        ' btnManageSubtopics
        ' 
        btnManageSubtopics.CustomizableEdges = CustomizableEdges7
        btnManageSubtopics.DisabledState.BorderColor = Color.DarkGray
        btnManageSubtopics.DisabledState.CustomBorderColor = Color.DarkGray
        btnManageSubtopics.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnManageSubtopics.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnManageSubtopics.Font = New Font("Segoe UI", 9.0F)
        btnManageSubtopics.ForeColor = Color.White
        btnManageSubtopics.Location = New Point(35, 287)
        btnManageSubtopics.Name = "btnManageSubtopics"
        btnManageSubtopics.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        btnManageSubtopics.Size = New Size(225, 56)
        btnManageSubtopics.TabIndex = 16
        btnManageSubtopics.Text = "Manage SubTopics"
        ' 
        ' FormAdminDashboard
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
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
