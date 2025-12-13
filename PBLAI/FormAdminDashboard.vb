Public Class FormAdminDashboard
    Private CurrentUser As User

    Public Sub New(user As User)
        InitializeComponent()
        Me.CurrentUser = user
    End Sub

    Private Sub btnManageQuestions_Click(sender As Object, e As EventArgs) Handles btnManageQuestions.Click
        Dim frm As New FormManageQuestions()
        frm.ShowDialog()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Close()
            ' Show Main Form (Form1) if accessible, or restart app
            ' Application.Restart() ' Simple way to reset
            Dim frmLogin As New FormLogin
            frmLogin.Show()
        End If
    End Sub

    Private Sub btnManageTopics_Click(sender As Object, e As EventArgs) Handles btnManageTopics.Click
        Dim frm As New FormManageTopics
        frm.ShowDialog()
    End Sub

    Private Sub btnManageSubtopics_Click(sender As Object, e As EventArgs) Handles btnManageSubtopics.Click
        Dim frm As New FormManageSubtopics()
        frm.ShowDialog()
    End Sub

End Class