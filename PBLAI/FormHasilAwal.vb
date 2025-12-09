Imports Guna.UI2.WinForms
Public Class FormHasilAwal
    Private totalSeconds As Integer = 0

    ''' <summary>
    ''' Form Load - Display Level 1 results
    ''' </summary>
    Private Sub FormHasilAwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Display results (already calculated in FormPertanyaanAwal)
            TampilkanHasilLevel1()

            ' Start timer
            questionTimer.Interval = 1000
            questionTimer.Start()

        Catch ex As Exception
            MessageBox.Show("Gagal memuat hasil: " & ex.Message, "Error",
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
    ''' Display Level 1 results (Top 3 topics + metode + rekomendasi)
    ''' </summary>
    Private Sub TampilkanHasilLevel1()
        Try
            Dim userId As Integer = GlobalUser.UserId

            ' Get top 3 topic rankings
            Dim topicRankings = ResultRepository.GetRankingsByUser(userId, "TOPIK")

            If topicRankings.Count = 0 Then
                MessageBox.Show("Tidak ada hasil topik ditemukan. Silakan ulangi tes.",
                              "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Display top 3 topics
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

            ' Get metode & rekomendasi
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
                MessageBox.Show("Hasil metode dan rekomendasi tidak ditemukan.",
                              "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan hasil: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Button Lanjutkan - Navigate to Level 2 questions
    ''' </summary>
    Private Sub nextButton_Click(sender As Object, e As EventArgs) Handles nextButton.Click
        Try
            questionTimer.Stop()

            ' Navigate to Level 2 (FormPertanyaanAkhir)
            Dim frmLevel2 As New FormPertanyaanAkhir()
            frmLevel2.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Gagal membuka form Level 2: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Button Selesaikan - Exit without Level 2
    ''' </summary>
    Private Sub endButton_Click(sender As Object, e As EventArgs) Handles endButton.Click
        questionTimer.Stop()

        Dim result As DialogResult = MessageBox.Show(
            "Apakah Anda yakin ingin menyelesaikan tes tanpa melanjutkan ke Level 2?" & vbCrLf & vbCrLf &
            "Level 2 akan memberikan rekomendasi subtopik yang lebih spesifik.",
            "Konfirmasi",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            MessageBox.Show(
                "Tes telah selesai." & vbCrLf &
                "Terima kasih telah menggunakan Sistem Pakar Penentuan Topik Skripsi.",
                "Selesai",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            ' Reset global user and return to main form
            GlobalUser.Reset()

            Dim frmMain As New Form1()
            frmMain.Show()
            Me.Close()
        End If
    End Sub
End Class