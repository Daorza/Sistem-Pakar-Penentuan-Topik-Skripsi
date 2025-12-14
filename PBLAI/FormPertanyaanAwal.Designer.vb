<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPertanyaanAwal
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
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        labelProgress = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelTitle = New Guna.UI2.WinForms.Guna2HtmlLabel()
        labelTimer = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        labelPertanyaan = New Guna.UI2.WinForms.Guna2HtmlLabel()
        radio1 = New Guna.UI2.WinForms.Guna2CustomRadioButton()
        radio2 = New Guna.UI2.WinForms.Guna2CustomRadioButton()
        radio3 = New Guna.UI2.WinForms.Guna2CustomRadioButton()
        radio4 = New Guna.UI2.WinForms.Guna2CustomRadioButton()
        radio5 = New Guna.UI2.WinForms.Guna2CustomRadioButton()
        radio6 = New Guna.UI2.WinForms.Guna2CustomRadioButton()
        buttonKembali = New Guna.UI2.WinForms.Guna2Button()
        buttonSelanjutnya = New Guna.UI2.WinForms.Guna2Button()
        questionTimer = New Timer(components)
        progressBar = New Guna.UI2.WinForms.Guna2ProgressBar()
        Label1 = New Label()
        Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel5 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        SuspendLayout()
        ' 
        ' Guna2BorderlessForm1
        ' 
        Guna2BorderlessForm1.ContainerControl = Me
        Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Guna2BorderlessForm1.TransparentWhileDrag = True
        ' 
        ' labelProgress
        ' 
        labelProgress.BackColor = Color.Transparent
        labelProgress.Location = New Point(25, 66)
        labelProgress.Name = "labelProgress"
        labelProgress.Size = New Size(248, 22)
        labelProgress.TabIndex = 0
        labelProgress.Text = "Pertanyaan ke-(x) dari (n) pertanyaan"
        ' 
        ' labelTitle
        ' 
        labelTitle.BackColor = Color.Transparent
        labelTitle.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        labelTitle.Location = New Point(269, 27)
        labelTitle.Name = "labelTitle"
        labelTitle.Size = New Size(254, 33)
        labelTitle.TabIndex = 1
        labelTitle.Text = "Tes Minat Topik Skripsi"
        ' 
        ' labelTimer
        ' 
        labelTimer.BackColor = Color.Transparent
        labelTimer.Location = New Point(674, 66)
        labelTimer.Name = "labelTimer"
        labelTimer.Size = New Size(114, 22)
        labelTimer.TabIndex = 2
        labelTimer.Text = "Timer Label here"
        ' 
        ' Guna2Separator1
        ' 
        Guna2Separator1.Location = New Point(25, 118)
        Guna2Separator1.Name = "Guna2Separator1"
        Guna2Separator1.Size = New Size(763, 12)
        Guna2Separator1.TabIndex = 3
        ' 
        ' labelPertanyaan
        ' 
        labelPertanyaan.AutoSize = False
        labelPertanyaan.BackColor = Color.Transparent
        labelPertanyaan.Location = New Point(38, 136)
        labelPertanyaan.Name = "labelPertanyaan"
        labelPertanyaan.Size = New Size(737, 64)
        labelPertanyaan.TabIndex = 4
        labelPertanyaan.Text = "Isi pertanyaan di sini"
        ' 
        ' radio1
        ' 
        radio1.CheckedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        radio1.CheckedState.BorderThickness = 0
        radio1.CheckedState.FillColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        radio1.CheckedState.InnerColor = Color.White
        radio1.Location = New Point(90, 235)
        radio1.Name = "radio1"
        radio1.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        radio1.Size = New Size(25, 25)
        radio1.TabIndex = 5
        radio1.Text = "Guna2CustomRadioButton1"
        radio1.UncheckedState.BorderColor = Color.FromArgb(CByte(125), CByte(137), CByte(149))
        radio1.UncheckedState.BorderThickness = 2
        radio1.UncheckedState.FillColor = Color.Transparent
        radio1.UncheckedState.InnerColor = Color.Transparent
        ' 
        ' radio2
        ' 
        radio2.CheckedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        radio2.CheckedState.BorderThickness = 0
        radio2.CheckedState.FillColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        radio2.CheckedState.InnerColor = Color.White
        radio2.Location = New Point(238, 235)
        radio2.Name = "radio2"
        radio2.ShadowDecoration.CustomizableEdges = CustomizableEdges11
        radio2.Size = New Size(25, 25)
        radio2.TabIndex = 6
        radio2.Text = "Guna2CustomRadioButton1"
        radio2.UncheckedState.BorderColor = Color.FromArgb(CByte(125), CByte(137), CByte(149))
        radio2.UncheckedState.BorderThickness = 2
        radio2.UncheckedState.FillColor = Color.Transparent
        radio2.UncheckedState.InnerColor = Color.Transparent
        ' 
        ' radio3
        ' 
        radio3.CheckedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        radio3.CheckedState.BorderThickness = 0
        radio3.CheckedState.FillColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        radio3.CheckedState.InnerColor = Color.White
        radio3.Location = New Point(364, 235)
        radio3.Name = "radio3"
        radio3.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        radio3.Size = New Size(25, 25)
        radio3.TabIndex = 7
        radio3.Text = "Guna2CustomRadioButton1"
        radio3.UncheckedState.BorderColor = Color.FromArgb(CByte(125), CByte(137), CByte(149))
        radio3.UncheckedState.BorderThickness = 2
        radio3.UncheckedState.FillColor = Color.Transparent
        radio3.UncheckedState.InnerColor = Color.Transparent
        ' 
        ' radio4
        ' 
        radio4.CheckedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        radio4.CheckedState.BorderThickness = 0
        radio4.CheckedState.FillColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        radio4.CheckedState.InnerColor = Color.White
        radio4.Location = New Point(487, 235)
        radio4.Name = "radio4"
        radio4.ShadowDecoration.CustomizableEdges = CustomizableEdges9
        radio4.Size = New Size(25, 25)
        radio4.TabIndex = 8
        radio4.Text = "Guna2CustomRadioButton1"
        radio4.UncheckedState.BorderColor = Color.FromArgb(CByte(125), CByte(137), CByte(149))
        radio4.UncheckedState.BorderThickness = 2
        radio4.UncheckedState.FillColor = Color.Transparent
        radio4.UncheckedState.InnerColor = Color.Transparent
        ' 
        ' radio5
        ' 
        radio5.CheckedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        radio5.CheckedState.BorderThickness = 0
        radio5.CheckedState.FillColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        radio5.CheckedState.InnerColor = Color.White
        radio5.Location = New Point(603, 235)
        radio5.Name = "radio5"
        radio5.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        radio5.Size = New Size(25, 25)
        radio5.TabIndex = 9
        radio5.Text = "Guna2CustomRadioButton1"
        radio5.UncheckedState.BorderColor = Color.FromArgb(CByte(125), CByte(137), CByte(149))
        radio5.UncheckedState.BorderThickness = 2
        radio5.UncheckedState.FillColor = Color.Transparent
        radio5.UncheckedState.InnerColor = Color.Transparent
        ' 
        ' radio6
        ' 
        radio6.CheckedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        radio6.CheckedState.BorderThickness = 0
        radio6.CheckedState.FillColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        radio6.CheckedState.InnerColor = Color.White
        radio6.Location = New Point(709, 235)
        radio6.Name = "radio6"
        radio6.ShadowDecoration.CustomizableEdges = CustomizableEdges7
        radio6.Size = New Size(25, 25)
        radio6.TabIndex = 10
        radio6.Text = "Guna2CustomRadioButton1"
        radio6.UncheckedState.BorderColor = Color.FromArgb(CByte(125), CByte(137), CByte(149))
        radio6.UncheckedState.BorderThickness = 2
        radio6.UncheckedState.FillColor = Color.Transparent
        radio6.UncheckedState.InnerColor = Color.Transparent
        ' 
        ' buttonKembali
        ' 
        buttonKembali.BorderRadius = 10
        buttonKembali.CustomizableEdges = CustomizableEdges5
        buttonKembali.DisabledState.BorderColor = Color.DarkGray
        buttonKembali.DisabledState.CustomBorderColor = Color.DarkGray
        buttonKembali.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        buttonKembali.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        buttonKembali.FillColor = Color.Coral
        buttonKembali.Font = New Font("Segoe UI", 9F)
        buttonKembali.ForeColor = Color.White
        buttonKembali.Location = New Point(38, 369)
        buttonKembali.Name = "buttonKembali"
        buttonKembali.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        buttonKembali.Size = New Size(225, 56)
        buttonKembali.TabIndex = 11
        buttonKembali.Text = "Kembali"
        ' 
        ' buttonSelanjutnya
        ' 
        buttonSelanjutnya.BorderRadius = 10
        buttonSelanjutnya.CustomizableEdges = CustomizableEdges3
        buttonSelanjutnya.DisabledState.BorderColor = Color.DarkGray
        buttonSelanjutnya.DisabledState.CustomBorderColor = Color.DarkGray
        buttonSelanjutnya.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        buttonSelanjutnya.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        buttonSelanjutnya.FillColor = Color.Teal
        buttonSelanjutnya.Font = New Font("Segoe UI", 9F)
        buttonSelanjutnya.ForeColor = Color.White
        buttonSelanjutnya.Location = New Point(550, 360)
        buttonSelanjutnya.Name = "buttonSelanjutnya"
        buttonSelanjutnya.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        buttonSelanjutnya.Size = New Size(225, 56)
        buttonSelanjutnya.TabIndex = 12
        buttonSelanjutnya.Text = "Selanjutnya"
        ' 
        ' questionTimer
        ' 
        questionTimer.Interval = 1000
        ' 
        ' progressBar
        ' 
        progressBar.CustomizableEdges = CustomizableEdges1
        progressBar.FillColor = Color.LightBlue
        progressBar.Location = New Point(25, 94)
        progressBar.Name = "progressBar"
        progressBar.ProgressColor = Color.Teal
        progressBar.ProgressColor2 = Color.FromArgb(CByte(0), CByte(192), CByte(192))
        progressBar.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        progressBar.Size = New Size(763, 18)
        progressBar.TabIndex = 13
        progressBar.Text = "Guna2ProgressBar1"
        progressBar.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(38, 292)
        Label1.Name = "Label1"
        Label1.Size = New Size(140, 20)
        Label1.TabIndex = 14
        Label1.Text = "Sangat Tidak Setuju"
        ' 
        ' Guna2HtmlLabel1
        ' 
        Guna2HtmlLabel1.BackColor = Color.Transparent
        Guna2HtmlLabel1.Location = New Point(210, 290)
        Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Guna2HtmlLabel1.Size = New Size(84, 22)
        Guna2HtmlLabel1.TabIndex = 15
        Guna2HtmlLabel1.Text = "Tidak Setuju"
        ' 
        ' Guna2HtmlLabel2
        ' 
        Guna2HtmlLabel2.BackColor = Color.Transparent
        Guna2HtmlLabel2.Location = New Point(333, 290)
        Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Guna2HtmlLabel2.Size = New Size(95, 22)
        Guna2HtmlLabel2.TabIndex = 16
        Guna2HtmlLabel2.Text = "Kurang Setuju"
        ' 
        ' Guna2HtmlLabel3
        ' 
        Guna2HtmlLabel3.BackColor = Color.Transparent
        Guna2HtmlLabel3.Location = New Point(478, 290)
        Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Guna2HtmlLabel3.Size = New Size(44, 22)
        Guna2HtmlLabel3.TabIndex = 17
        Guna2HtmlLabel3.Text = "Setuju"
        ' 
        ' Guna2HtmlLabel4
        ' 
        Guna2HtmlLabel4.BackColor = Color.Transparent
        Guna2HtmlLabel4.Location = New Point(573, 292)
        Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Guna2HtmlLabel4.Size = New Size(89, 22)
        Guna2HtmlLabel4.TabIndex = 18
        Guna2HtmlLabel4.Text = "Cukup Setuju"
        ' 
        ' Guna2HtmlLabel5
        ' 
        Guna2HtmlLabel5.BackColor = Color.Transparent
        Guna2HtmlLabel5.Location = New Point(681, 290)
        Guna2HtmlLabel5.Name = "Guna2HtmlLabel5"
        Guna2HtmlLabel5.Size = New Size(94, 22)
        Guna2HtmlLabel5.TabIndex = 19
        Guna2HtmlLabel5.Text = "Sangat Setuju"
        ' 
        ' FormPertanyaanAwal
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Guna2HtmlLabel5)
        Controls.Add(Guna2HtmlLabel4)
        Controls.Add(Guna2HtmlLabel3)
        Controls.Add(Guna2HtmlLabel2)
        Controls.Add(Guna2HtmlLabel1)
        Controls.Add(Label1)
        Controls.Add(progressBar)
        Controls.Add(buttonSelanjutnya)
        Controls.Add(buttonKembali)
        Controls.Add(radio6)
        Controls.Add(radio5)
        Controls.Add(radio4)
        Controls.Add(radio3)
        Controls.Add(radio2)
        Controls.Add(radio1)
        Controls.Add(labelPertanyaan)
        Controls.Add(Guna2Separator1)
        Controls.Add(labelTimer)
        Controls.Add(labelTitle)
        Controls.Add(labelProgress)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormPertanyaanAwal"
        Text = "FormPertanyaanAwal"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents labelTimer As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelTitle As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents labelProgress As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents radio6 As Guna.UI2.WinForms.Guna2CustomRadioButton
    Friend WithEvents radio5 As Guna.UI2.WinForms.Guna2CustomRadioButton
    Friend WithEvents radio4 As Guna.UI2.WinForms.Guna2CustomRadioButton
    Friend WithEvents radio3 As Guna.UI2.WinForms.Guna2CustomRadioButton
    Friend WithEvents radio2 As Guna.UI2.WinForms.Guna2CustomRadioButton
    Friend WithEvents radio1 As Guna.UI2.WinForms.Guna2CustomRadioButton
    Friend WithEvents labelPertanyaan As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents buttonSelanjutnya As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents buttonKembali As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents progressBar As Guna.UI2.WinForms.Guna2ProgressBar
    Friend WithEvents questionTimer As Timer
    Friend WithEvents Guna2HtmlLabel5 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Label1 As Label
End Class
