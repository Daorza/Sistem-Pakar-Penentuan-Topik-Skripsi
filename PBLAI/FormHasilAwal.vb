Public Class FormHasilAwal

    Private totalSeconds As Integer = 0

    Private Sub FormHasilAwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        questionTimer.Start()
    End Sub

    Private Sub questionTimer_Tick(sender As Object, e As EventArgs) Handles questionTimer.Tick
        totalSeconds += 1

        Dim minutes As Integer = totalSeconds \ 60
        Dim seconds As Integer = totalSeconds Mod 60

        labelTimer.Text = $"{minutes:D2}:{seconds:D2}"
    End Sub
End Class