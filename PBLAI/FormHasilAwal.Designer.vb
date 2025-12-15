<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHasilAwal
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
        components = New ComponentModel.Container()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelTopic = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelTimer = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelMetode = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelRekomendasi = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel5 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        endButton = New Guna.UI2.WinForms.Guna2Button()
        nextButton = New Guna.UI2.WinForms.Guna2Button()
        questionTimer = New Timer(components)
        labelTopic2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelTopic3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2ShadowPanel1 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Guna2ShadowPanel2 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Guna2ShadowPanel3 = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Guna2ShadowPanel1.SuspendLayout()
        Guna2ShadowPanel2.SuspendLayout()
        Guna2ShadowPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Guna2BorderlessForm1
        ' 
        Guna2BorderlessForm1.ContainerControl = Me
        Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Guna2BorderlessForm1.TransparentWhileDrag = True
        ' 
        ' Guna2HtmlLabel1
        ' 
        Guna2HtmlLabel1.BackColor = Color.Transparent
        Guna2HtmlLabel1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel1.Location = New Point(397, 30)
        Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Guna2HtmlLabel1.Size = New Size(73, 22)
        Guna2HtmlLabel1.TabIndex = 0
        Guna2HtmlLabel1.Text = "Hasil Awal "
        ' 
        ' Guna2HtmlLabel2
        ' 
        Guna2HtmlLabel2.BackColor = Color.Transparent
        Guna2HtmlLabel2.Font = New Font("Microsoft Sans Serif", 8.25F)
        Guna2HtmlLabel2.Location = New Point(348, 58)
        Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Guna2HtmlLabel2.Size = New Size(170, 19)
        Guna2HtmlLabel2.TabIndex = 1
        Guna2HtmlLabel2.Text = "Kamu cocok dengan topik:"
        ' 
        ' labelTopic
        ' 
        labelTopic.BackColor = Color.Transparent
        labelTopic.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        labelTopic.Location = New Point(25, 23)
        labelTopic.Name = "labelTopic"
        labelTopic.Size = New Size(292, 47)
        labelTopic.TabIndex = 2
        labelTopic.Text = "Label Topik Utama"
        ' 
        ' labelTimer
        ' 
        labelTimer.BackColor = Color.Transparent
        labelTimer.Location = New Point(746, 30)
        labelTimer.Name = "labelTimer"
        labelTimer.Size = New Size(78, 22)
        labelTimer.TabIndex = 3
        labelTimer.Text = "TImer label"
        ' 
        ' Guna2HtmlLabel3
        ' 
        Guna2HtmlLabel3.BackColor = Color.Transparent
        Guna2HtmlLabel3.Location = New Point(25, 17)
        Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Guna2HtmlLabel3.Size = New Size(127, 22)
        Guna2HtmlLabel3.TabIndex = 4
        Guna2HtmlLabel3.Text = "Metode Penelitian:"
        ' 
        ' Guna2HtmlLabel4
        ' 
        Guna2HtmlLabel4.BackColor = Color.Transparent
        Guna2HtmlLabel4.Location = New Point(16, 17)
        Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Guna2HtmlLabel4.Size = New Size(165, 22)
        Guna2HtmlLabel4.TabIndex = 5
        Guna2HtmlLabel4.Text = "Rekomendasi penelitian:"
        ' 
        ' labelMetode
        ' 
        labelMetode.BackColor = Color.Transparent
        labelMetode.Font = New Font("Segoe UI", 12F)
        labelMetode.Location = New Point(25, 45)
        labelMetode.Name = "labelMetode"
        labelMetode.Size = New Size(213, 30)
        labelMetode.TabIndex = 6
        labelMetode.Text = "Label metode penelitian"
        ' 
        ' labelRekomendasi
        ' 
        labelRekomendasi.BackColor = Color.Transparent
        labelRekomendasi.Font = New Font("Segoe UI", 12F)
        labelRekomendasi.Location = New Point(16, 45)
        labelRekomendasi.Name = "labelRekomendasi"
        labelRekomendasi.Size = New Size(171, 30)
        labelRekomendasi.TabIndex = 7
        labelRekomendasi.Text = "Label Rekomendasi"
        ' 
        ' Guna2HtmlLabel5
        ' 
        Guna2HtmlLabel5.BackColor = Color.Transparent
        Guna2HtmlLabel5.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel5.Location = New Point(198, 428)
        Guna2HtmlLabel5.Name = "Guna2HtmlLabel5"
        Guna2HtmlLabel5.Size = New Size(490, 25)
        Guna2HtmlLabel5.TabIndex = 8
        Guna2HtmlLabel5.Text = "Lanjutkan tes ke level selanjutnya untuk hasil lebih maksimal!"
        ' 
        ' endButton
        ' 
        endButton.BorderRadius = 8
        endButton.CustomizableEdges = CustomizableEdges3
        endButton.DisabledState.BorderColor = Color.DarkGray
        endButton.DisabledState.CustomBorderColor = Color.DarkGray
        endButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        endButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        endButton.FillColor = Color.Coral
        endButton.Font = New Font("Segoe UI", 9F)
        endButton.ForeColor = Color.White
        endButton.Location = New Point(225, 470)
        endButton.Name = "endButton"
        endButton.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        endButton.Size = New Size(212, 39)
        endButton.TabIndex = 9
        endButton.Text = "Selesaikan"
        ' 
        ' nextButton
        ' 
        nextButton.BorderRadius = 8
        nextButton.CustomizableEdges = CustomizableEdges1
        nextButton.DisabledState.BorderColor = Color.DarkGray
        nextButton.DisabledState.CustomBorderColor = Color.DarkGray
        nextButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        nextButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        nextButton.FillColor = Color.Teal
        nextButton.Font = New Font("Segoe UI", 9F)
        nextButton.ForeColor = Color.White
        nextButton.Location = New Point(443, 470)
        nextButton.Name = "nextButton"
        nextButton.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        nextButton.Size = New Size(225, 39)
        nextButton.TabIndex = 10
        nextButton.Text = "Lanjutkan!"
        ' 
        ' questionTimer
        ' 
        questionTimer.Interval = 1000
        ' 
        ' labelTopic2
        ' 
        labelTopic2.BackColor = Color.Transparent
        labelTopic2.Font = New Font("Segoe UI", 12F)
        labelTopic2.Location = New Point(25, 76)
        labelTopic2.Name = "labelTopic2"
        labelTopic2.Size = New Size(182, 30)
        labelTopic2.TabIndex = 11
        labelTopic2.Text = "Label Topik Utama 2"
        ' 
        ' labelTopic3
        ' 
        labelTopic3.BackColor = Color.Transparent
        labelTopic3.Font = New Font("Segoe UI", 10F)
        labelTopic3.Location = New Point(25, 121)
        labelTopic3.Name = "labelTopic3"
        labelTopic3.Size = New Size(159, 25)
        labelTopic3.TabIndex = 12
        labelTopic3.Text = "Label Topik Utama 3"
        ' 
        ' Guna2ShadowPanel1
        ' 
        Guna2ShadowPanel1.BackColor = Color.Transparent
        Guna2ShadowPanel1.Controls.Add(labelTopic)
        Guna2ShadowPanel1.Controls.Add(labelTopic2)
        Guna2ShadowPanel1.Controls.Add(labelTopic3)
        Guna2ShadowPanel1.FillColor = Color.Azure
        Guna2ShadowPanel1.Location = New Point(65, 114)
        Guna2ShadowPanel1.Name = "Guna2ShadowPanel1"
        Guna2ShadowPanel1.Radius = 8
        Guna2ShadowPanel1.ShadowColor = Color.Black
        Guna2ShadowPanel1.Size = New Size(759, 171)
        Guna2ShadowPanel1.TabIndex = 13
        ' 
        ' Guna2ShadowPanel2
        ' 
        Guna2ShadowPanel2.BackColor = Color.Transparent
        Guna2ShadowPanel2.Controls.Add(Guna2HtmlLabel3)
        Guna2ShadowPanel2.Controls.Add(labelMetode)
        Guna2ShadowPanel2.FillColor = Color.Azure
        Guna2ShadowPanel2.Location = New Point(65, 291)
        Guna2ShadowPanel2.Name = "Guna2ShadowPanel2"
        Guna2ShadowPanel2.Radius = 8
        Guna2ShadowPanel2.ShadowColor = Color.Black
        Guna2ShadowPanel2.Size = New Size(372, 92)
        Guna2ShadowPanel2.TabIndex = 14
        ' 
        ' Guna2ShadowPanel3
        ' 
        Guna2ShadowPanel3.BackColor = Color.Transparent
        Guna2ShadowPanel3.Controls.Add(Guna2HtmlLabel4)
        Guna2ShadowPanel3.Controls.Add(labelRekomendasi)
        Guna2ShadowPanel3.FillColor = Color.Azure
        Guna2ShadowPanel3.Location = New Point(443, 291)
        Guna2ShadowPanel3.Name = "Guna2ShadowPanel3"
        Guna2ShadowPanel3.Radius = 8
        Guna2ShadowPanel3.ShadowColor = Color.Black
        Guna2ShadowPanel3.Size = New Size(381, 92)
        Guna2ShadowPanel3.TabIndex = 15
        ' 
        ' FormHasilAwal
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(880, 560)
        Controls.Add(Guna2ShadowPanel3)
        Controls.Add(Guna2ShadowPanel2)
        Controls.Add(Guna2ShadowPanel1)
        Controls.Add(nextButton)
        Controls.Add(endButton)
        Controls.Add(Guna2HtmlLabel5)
        Controls.Add(labelTimer)
        Controls.Add(Guna2HtmlLabel2)
        Controls.Add(Guna2HtmlLabel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormHasilAwal"
        Text = "FormHasilAwal"
        Guna2ShadowPanel1.ResumeLayout(False)
        Guna2ShadowPanel1.PerformLayout()
        Guna2ShadowPanel2.ResumeLayout(False)
        Guna2ShadowPanel2.PerformLayout()
        Guna2ShadowPanel3.ResumeLayout(False)
        Guna2ShadowPanel3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelRekomendasi As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelMetode As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelTimer As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelTopic As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents nextButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents endButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2HtmlLabel5 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents questionTimer As Timer
    Friend WithEvents labelTopic3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelTopic2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2ShadowPanel3 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Guna2ShadowPanel2 As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Guna2ShadowPanel1 As Guna.UI2.WinForms.Guna2ShadowPanel
End Class
