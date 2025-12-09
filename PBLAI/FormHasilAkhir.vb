Imports Guna.UI2.WinForms
Public Class FormHasilAkhir
    Private totalSeconds As Integer = 0

    ''' <summary>
    ''' Form Load - Display complete final results
    ''' </summary>
    Private Sub FormHasilAkhir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Display all final results
            TampilkanHasilAkhir()

            ' Start timer
            questionTimer.Interval = 1000
            questionTimer.Start()

        Catch ex As Exception
            MessageBox.Show("Gagal memuat hasil akhir: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Timer Tick - Update display
    ''' </summary>
    Private Sub questionTimer_Tick(sender As Object, e As EventArgs) Handles questionTimer.Tick
        totalSeconds += 1

        Dim minutes As Integer = totalSeconds \ 60
        Dim seconds As Integer = totalSeconds Mod 60

        labelTimer.Text = $"{minutes:D2}:{seconds:D2}"
    End Sub

    ''' <summary>
    ''' Display complete final results (Topics + Subtopics + Metode + Rekomendasi)
    ''' </summary>
    Private Sub TampilkanHasilAkhir()
        Try
            Dim userId As Integer = GlobalUser.UserId

            ' ===== DISPLAY TOP 3 TOPICS =====
            Dim topicRankings = ResultRepository.GetRankingsByUser(userId, "TOPIK")

            If topicRankings.Count > 0 Then
                For i As Integer = 0 To Math.Min(2, topicRankings.Count - 1)
                    Dim ranking = topicRankings(i)
                    Dim displayText As String = $"{ranking.Ranking}. {ranking.NamaTopic} - {ranking.Persentase}%"

                    Select Case i
                        Case 0
                            labelTopic.Text = displayText
                        Case 1
                            labelTopic2.Text = displayText
                        Case 2
                            labelTopic3.Text = displayText
                    End Select
                Next
            Else
                labelTopic.Text = "Tidak ada hasil topik"
            End If

            ' ===== DISPLAY TOP 3 SUBTOPICS =====
            Dim subtopicRankings = ResultRepository.GetRankingsByUser(userId, "SUBTOPIK")

            If subtopicRankings.Count > 0 Then
                For i As Integer = 0 To Math.Min(2, subtopicRankings.Count - 1)
                    Dim ranking = subtopicRankings(i)
                    Dim displayText As String = $"{ranking.Ranking}. {ranking.NamaSubtopic} - {ranking.Persentase}%"

                    Select Case i
                        Case 0
                            labelSubTopik.Text = displayText
                        Case 1
                            labelSubTopik2.Text = displayText
                        Case 2
                            labelSubTopik3.Text = displayText
                    End Select
                Next
            Else
                ' If no Level 2 results, hide subtopic labels
                labelSubTopik.Text = "Subtopik belum tersedia"
                labelSubTopik2.Visible = False
                labelSubTopik3.Visible = False
            End If

            ' ===== DISPLAY METODE & REKOMENDASI =====
            Dim result = ResultRepository.GetLatestResult(userId)

            If result IsNot Nothing Then
                ' Display metode
                labelMetode.Text = result.Metode

                ' Display rekomendasi with formatting
                If result.Rekomendasi.ToUpper() = "MEMBUAT" Then
                    labelRekomendasi.Text = "Membuat Aplikasi"
                ElseIf result.Rekomendasi.ToUpper() = "ANALISIS" Then
                    labelRekomendasi.Text = "Analisis Aplikasi"
                Else
                    labelRekomendasi.Text = result.Rekomendasi
                End If
            Else
                labelMetode.Text = "Data tidak tersedia"
                labelRekomendasi.Text = "Data tidak tersedia"
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan hasil akhir: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Button Lanjutkan - Start new test
    ''' </summary>
    Private Sub nextButton_Click(sender As Object, e As EventArgs) Handles nextButton.Click
        questionTimer.Stop()

        Dim result As DialogResult = MessageBox.Show(
            "Apakah Anda ingin memulai tes baru?" & vbCrLf & vbCrLf &
            "Data tes sebelumnya akan tetap tersimpan di database.",
            "Tes Baru",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            ' Reset global user
            GlobalUser.Reset()

            ' Navigate back to Form1 (main input)
            Dim frmMain As New Form1()
            frmMain.Show()
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' Button Selesaikan - Exit application
    ''' </summary>
    Private Sub endButton_Click(sender As Object, e As EventArgs) Handles endButton.Click
        questionTimer.Stop()

        Dim result As DialogResult = MessageBox.Show(
            "Terima kasih telah menggunakan Sistem Pakar Penentuan Topik Skripsi!" & vbCrLf & vbCrLf &
            "Hasil tes Anda:" & vbCrLf &
            $"- Topik Utama: {labelTopic.Text}" & vbCrLf &
            $"- Subtopik: {labelSubTopik.Text}" & vbCrLf &
            $"- Metode: {labelMetode.Text}" & vbCrLf &
            $"- Rekomendasi: {labelRekomendasi.Text}" & vbCrLf & vbCrLf &
            "Apakah Anda ingin keluar dari aplikasi?",
            "Selesai",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information
        )

        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class
