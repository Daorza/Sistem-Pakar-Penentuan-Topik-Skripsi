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
        Guna2HtmlLabel1.Location = New Point(338, 30)
        Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Guna2HtmlLabel1.Size = New Size(73, 22)
        Guna2HtmlLabel1.TabIndex = 0
        Guna2HtmlLabel1.Text = "Hasil Awal "
        ' 
        ' Guna2HtmlLabel2
        ' 
        Guna2HtmlLabel2.BackColor = Color.Transparent
        Guna2HtmlLabel2.Font = New Font("Microsoft Sans Serif", 8.25F)
        Guna2HtmlLabel2.Location = New Point(289, 58)
        Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Guna2HtmlLabel2.Size = New Size(170, 19)
        Guna2HtmlLabel2.TabIndex = 1
        Guna2HtmlLabel2.Text = "Kamu cocok dengan topik:"
        ' 
        ' labelTopic
        ' 
        labelTopic.BackColor = Color.Transparent
        labelTopic.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        labelTopic.Location = New Point(72, 108)
        labelTopic.Name = "labelTopic"
        labelTopic.Size = New Size(292, 47)
        labelTopic.TabIndex = 2
        labelTopic.Text = "Label Topik Utama"
        ' 
        ' labelTimer
        ' 
        labelTimer.BackColor = Color.Transparent
        labelTimer.Location = New Point(690, 30)
        labelTimer.Name = "labelTimer"
        labelTimer.Size = New Size(78, 22)
        labelTimer.TabIndex = 3
        labelTimer.Text = "TImer label"
        ' 
        ' Guna2HtmlLabel3
        ' 
        Guna2HtmlLabel3.BackColor = Color.Transparent
        Guna2HtmlLabel3.Location = New Point(72, 258)
        Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Guna2HtmlLabel3.Size = New Size(127, 22)
        Guna2HtmlLabel3.TabIndex = 4
        Guna2HtmlLabel3.Text = "Metode Penelitian:"
        ' 
        ' Guna2HtmlLabel4
        ' 
        Guna2HtmlLabel4.BackColor = Color.Transparent
        Guna2HtmlLabel4.Location = New Point(500, 258)
        Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Guna2HtmlLabel4.Size = New Size(165, 22)
        Guna2HtmlLabel4.TabIndex = 5
        Guna2HtmlLabel4.Text = "Rekomendasi penelitian:"
        ' 
        ' labelMetode
        ' 
        labelMetode.BackColor = Color.Transparent
        labelMetode.Font = New Font("Segoe UI", 12F)
        labelMetode.Location = New Point(72, 286)
        labelMetode.Name = "labelMetode"
        labelMetode.Size = New Size(213, 30)
        labelMetode.TabIndex = 6
        labelMetode.Text = "Label metode penelitian"
        ' 
        ' labelRekomendasi
        ' 
        labelRekomendasi.BackColor = Color.Transparent
        labelRekomendasi.Font = New Font("Segoe UI", 12F)
        labelRekomendasi.Location = New Point(500, 286)
        labelRekomendasi.Name = "labelRekomendasi"
        labelRekomendasi.Size = New Size(171, 30)
        labelRekomendasi.TabIndex = 7
        labelRekomendasi.Text = "Label Rekomendasi"
        ' 
        ' Guna2HtmlLabel5
        ' 
        Guna2HtmlLabel5.BackColor = Color.Transparent
        Guna2HtmlLabel5.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel5.Location = New Point(145, 343)
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
        endButton.Font = New Font("Segoe UI", 9F)
        endButton.ForeColor = Color.White
        endButton.Location = New Point(172, 385)
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
        nextButton.Font = New Font("Segoe UI", 9F)
        nextButton.ForeColor = Color.White
        nextButton.Location = New Point(390, 385)
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
        labelTopic2.Location = New Point(72, 161)
        labelTopic2.Name = "labelTopic2"
        labelTopic2.Size = New Size(182, 30)
        labelTopic2.TabIndex = 11
        labelTopic2.Text = "Label Topik Utama 2"
        ' 
        ' labelTopic3
        ' 
        labelTopic3.BackColor = Color.Transparent
        labelTopic3.Font = New Font("Segoe UI", 10F)
        labelTopic3.Location = New Point(72, 197)
        labelTopic3.Name = "labelTopic3"
        labelTopic3.Size = New Size(159, 25)
        labelTopic3.TabIndex = 12
        labelTopic3.Text = "Label Topik Utama 3"
        ' 
        ' FormHasilAwal
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(labelTopic3)
        Controls.Add(labelTopic2)
        Controls.Add(nextButton)
        Controls.Add(endButton)
        Controls.Add(Guna2HtmlLabel5)
        Controls.Add(labelRekomendasi)
        Controls.Add(labelMetode)
        Controls.Add(Guna2HtmlLabel4)
        Controls.Add(Guna2HtmlLabel3)
        Controls.Add(labelTimer)
        Controls.Add(labelTopic)
        Controls.Add(Guna2HtmlLabel2)
        Controls.Add(Guna2HtmlLabel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormHasilAwal"
        Text = "FormHasilAwal"
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
End Class
