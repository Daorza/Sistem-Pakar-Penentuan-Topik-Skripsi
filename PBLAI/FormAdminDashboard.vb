Imports System.Windows.Forms
Imports System.Drawing
Public Class FormAdminDashboard
    Inherits System.Windows.Forms.Form
    Private CurrentUser As User
    Private lblWelcome As Label
    Private btnManageQuestions As Button
    Private btnManageTopics As Button
    Private btnLogout As Button
    Private panelMenu As FlowLayoutPanel
    Public Sub New(user As User)
        Me.CurrentUser = user
        SetupUI()
    End Sub
    Private Sub SetupUI()
        Me.Text = "Admin Dashboard - Sistem Pakar"
        Me.Size = New Size(800, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.IsMdiContainer = False
        ' Header Label
        lblWelcome = New Label()
        lblWelcome.Text = "Selamat Datang, Admin " & CurrentUser.Nama
        lblWelcome.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblWelcome.AutoSize = True
        lblWelcome.Location = New Point(20, 20)
        ' Menu Panel
        panelMenu = New FlowLayoutPanel()
        panelMenu.FlowDirection = FlowDirection.LeftToRight
        panelMenu.Location = New Point(20, 80)
        panelMenu.Size = New Size(740, 100)
        panelMenu.AutoSize = True
        ' Button Manage Questions
        btnManageQuestions = CreateMenuButton("Kelola Pertanyaan", Color.Teal)
        AddHandler btnManageQuestions.Click, AddressOf btnManageQuestions_Click
        ' Button Manage Topics
        btnManageTopics = CreateMenuButton("Kelola Topik & Subtopik", Color.DarkOrange)
        AddHandler btnManageTopics.Click, AddressOf btnManageTopics_Click
        ' Button Logout
        btnLogout = CreateMenuButton("Logout", Color.Crimson)
        AddHandler btnLogout.Click, AddressOf btnLogout_Click
        ' Add to Panel
        panelMenu.Controls.Add(btnManageQuestions)
        panelMenu.Controls.Add(btnManageTopics)
        panelMenu.Controls.Add(btnLogout)
        ' Add to Form
        Me.Controls.Add(lblWelcome)
        Me.Controls.Add(panelMenu)
    End Sub
    Private Function CreateMenuButton(text As String, bgColor As Color) As Button
        Dim btn As New Button()
        btn.Text = text
        btn.Size = New Size(180, 80)
        btn.BackColor = bgColor
        btn.ForeColor = Color.White
        btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btn.FlatStyle = FlatStyle.Flat
        btn.Margin = New Padding(10)
        Return btn
    End Function
    Private Sub btnManageQuestions_Click(sender As Object, e As EventArgs)
        ' Open Manage Questions Form
        Dim frm As New FormManageQuestions()
        frm.ShowDialog()
    End Sub
    Private Sub btnManageTopics_Click(sender As Object, e As EventArgs)
        ' Open Manage Topics Form
        Dim frm As New FormManageTopics()
        frm.ShowDialog()
    End Sub
    Private Sub btnLogout_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
            ' Show Main Form (Form1) if accessible, or restart app
            ' Application.Restart() ' Simple way to reset
            Dim frmLogin As New FormLogin()
            frmLogin.Show()
        End If
    End Sub
    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        MyBase.OnFormClosed(e)
        ' Ensure we don't leave zombie processes if this was the main window
        ' But Form1 is hidden.
        ' Ideally we show Form1 again or FormLogin.
        ' Application.Exit() ' If we want to close everything
    End Sub
End Class