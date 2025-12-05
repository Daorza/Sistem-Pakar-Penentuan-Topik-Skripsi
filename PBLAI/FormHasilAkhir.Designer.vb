<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHasilAkhir
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
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        labelTopic3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelTopic2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        nextButton = New Guna.UI2.WinForms.Guna2Button()
        endButton = New Guna.UI2.WinForms.Guna2Button()
        Guna2HtmlLabel5 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelRekomendasi = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelMetode = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelTimer = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelTopic = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        questionTimer = New Timer(components)
        labelSubTopik3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelSubTopik2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelSubTopik = New Guna.UI2.WinForms.Guna2HtmlLabel()
        SuspendLayout()
        ' 
        ' labelTopic3
        ' 
        labelTopic3.BackColor = Color.Transparent
        labelTopic3.Font = New Font("Segoe UI", 10F)
        labelTopic3.Location = New Point(52, 195)
        labelTopic3.Name = "labelTopic3"
        labelTopic3.Size = New Size(159, 25)
        labelTopic3.TabIndex = 25
        labelTopic3.Text = "Label Topik Utama 3"
        ' 
        ' labelTopic2
        ' 
        labelTopic2.BackColor = Color.Transparent
        labelTopic2.Font = New Font("Segoe UI", 12F)
        labelTopic2.Location = New Point(52, 159)
        labelTopic2.Name = "labelTopic2"
        labelTopic2.Size = New Size(182, 30)
        labelTopic2.TabIndex = 24
        labelTopic2.Text = "Label Topik Utama 2"
        ' 
        ' nextButton
        ' 
        nextButton.BorderRadius = 8
        nextButton.CustomizableEdges = CustomizableEdges5
        nextButton.DisabledState.BorderColor = Color.DarkGray
        nextButton.DisabledState.CustomBorderColor = Color.DarkGray
        nextButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        nextButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        nextButton.Font = New Font("Segoe UI", 9F)
        nextButton.ForeColor = Color.White
        nextButton.Location = New Point(370, 383)
        nextButton.Name = "nextButton"
        nextButton.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        nextButton.Size = New Size(225, 39)
        nextButton.TabIndex = 23
        nextButton.Text = "Lanjutkan!"
        ' 
        ' endButton
        ' 
        endButton.BorderRadius = 8
        endButton.CustomizableEdges = CustomizableEdges7
        endButton.DisabledState.BorderColor = Color.DarkGray
        endButton.DisabledState.CustomBorderColor = Color.DarkGray
        endButton.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        endButton.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        endButton.Font = New Font("Segoe UI", 9F)
        endButton.ForeColor = Color.White
        endButton.Location = New Point(152, 383)
        endButton.Name = "endButton"
        endButton.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        endButton.Size = New Size(212, 39)
        endButton.TabIndex = 22
        endButton.Text = "Selesaikan"
        ' 
        ' Guna2HtmlLabel5
        ' 
        Guna2HtmlLabel5.BackColor = Color.Transparent
        Guna2HtmlLabel5.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel5.Location = New Point(125, 341)
        Guna2HtmlLabel5.Name = "Guna2HtmlLabel5"
        Guna2HtmlLabel5.Size = New Size(490, 25)
        Guna2HtmlLabel5.TabIndex = 21
        Guna2HtmlLabel5.Text = "Lanjutkan tes ke level selanjutnya untuk hasil lebih maksimal!"
        ' 
        ' labelRekomendasi
        ' 
        labelRekomendasi.BackColor = Color.Transparent
        labelRekomendasi.Font = New Font("Segoe UI", 12F)
        labelRekomendasi.Location = New Point(456, 284)
        labelRekomendasi.Name = "labelRekomendasi"
        labelRekomendasi.Size = New Size(171, 30)
        labelRekomendasi.TabIndex = 20
        labelRekomendasi.Text = "Label Rekomendasi"
        ' 
        ' labelMetode
        ' 
        labelMetode.BackColor = Color.Transparent
        labelMetode.Font = New Font("Segoe UI", 12F)
        labelMetode.Location = New Point(52, 284)
        labelMetode.Name = "labelMetode"
        labelMetode.Size = New Size(213, 30)
        labelMetode.TabIndex = 19
        labelMetode.Text = "Label metode penelitian"
        ' 
        ' Guna2HtmlLabel4
        ' 
        Guna2HtmlLabel4.BackColor = Color.Transparent
        Guna2HtmlLabel4.Location = New Point(456, 256)
        Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Guna2HtmlLabel4.Size = New Size(165, 22)
        Guna2HtmlLabel4.TabIndex = 18
        Guna2HtmlLabel4.Text = "Rekomendasi penelitian:"
        ' 
        ' Guna2HtmlLabel3
        ' 
        Guna2HtmlLabel3.BackColor = Color.Transparent
        Guna2HtmlLabel3.Location = New Point(52, 256)
        Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Guna2HtmlLabel3.Size = New Size(127, 22)
        Guna2HtmlLabel3.TabIndex = 17
        Guna2HtmlLabel3.Text = "Metode Penelitian:"
        ' 
        ' labelTimer
        ' 
        labelTimer.BackColor = Color.Transparent
        labelTimer.Location = New Point(670, 28)
        labelTimer.Name = "labelTimer"
        labelTimer.Size = New Size(78, 22)
        labelTimer.TabIndex = 16
        labelTimer.Text = "TImer label"
        ' 
        ' labelTopic
        ' 
        labelTopic.BackColor = Color.Transparent
        labelTopic.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        labelTopic.Location = New Point(52, 106)
        labelTopic.Name = "labelTopic"
        labelTopic.Size = New Size(292, 47)
        labelTopic.TabIndex = 15
        labelTopic.Text = "Label Topik Utama"
        ' 
        ' Guna2HtmlLabel2
        ' 
        Guna2HtmlLabel2.BackColor = Color.Transparent
        Guna2HtmlLabel2.Font = New Font("Microsoft Sans Serif", 8.25F)
        Guna2HtmlLabel2.Location = New Point(269, 56)
        Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Guna2HtmlLabel2.Size = New Size(170, 19)
        Guna2HtmlLabel2.TabIndex = 14
        Guna2HtmlLabel2.Text = "Kamu cocok dengan topik:"
        ' 
        ' Guna2HtmlLabel1
        ' 
        Guna2HtmlLabel1.BackColor = Color.Transparent
        Guna2HtmlLabel1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel1.Location = New Point(318, 28)
        Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Guna2HtmlLabel1.Size = New Size(73, 22)
        Guna2HtmlLabel1.TabIndex = 13
        Guna2HtmlLabel1.Text = "Hasil Awal "
        ' 
        ' Guna2BorderlessForm1
        ' 
        Guna2BorderlessForm1.ContainerControl = Me
        Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Guna2BorderlessForm1.TransparentWhileDrag = True
        ' 
        ' labelSubTopik3
        ' 
        labelSubTopik3.BackColor = Color.Transparent
        labelSubTopik3.Font = New Font("Segoe UI", 10F)
        labelSubTopik3.Location = New Point(456, 195)
        labelSubTopik3.Name = "labelSubTopik3"
        labelSubTopik3.Size = New Size(132, 25)
        labelSubTopik3.TabIndex = 28
        labelSubTopik3.Text = "Label SubTopik 3"
        ' 
        ' labelSubTopik2
        ' 
        labelSubTopik2.BackColor = Color.Transparent
        labelSubTopik2.Font = New Font("Segoe UI", 12F)
        labelSubTopik2.Location = New Point(456, 159)
        labelSubTopik2.Name = "labelSubTopik2"
        labelSubTopik2.Size = New Size(153, 30)
        labelSubTopik2.TabIndex = 27
        labelSubTopik2.Text = "Label SubTopik 2"
        ' 
        ' labelSubTopik
        ' 
        labelSubTopik.BackColor = Color.Transparent
        labelSubTopik.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        labelSubTopik.Location = New Point(456, 106)
        labelSubTopik.Name = "labelSubTopik"
        labelSubTopik.Size = New Size(239, 47)
        labelSubTopik.TabIndex = 26
        labelSubTopik.Text = "Label SubTopik"
        ' 
        ' FormHasilAkhir
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(labelSubTopik3)
        Controls.Add(labelSubTopik2)
        Controls.Add(labelSubTopik)
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
        Name = "FormHasilAkhir"
        Text = "FormHasilAkhir"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents labelTopic3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelTopic2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents nextButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents endButton As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2HtmlLabel5 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelRekomendasi As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelMetode As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelTimer As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelTopic As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents labelSubTopik3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelSubTopik2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelSubTopik As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents questionTimer As Timer
End Class
