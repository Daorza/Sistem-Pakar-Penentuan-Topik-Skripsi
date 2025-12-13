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
    ''' Display Level 1 results (Top 3 topics with >= 50% score)
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

            ' Reset labels first (hide them by default)
            labelTopic.Text = ""
            labelTopic2.Text = ""
            labelTopic3.Text = ""

            ' Loop through rankings and display only those >= 50%
            Dim displayIndex As Integer = 0

            For i As Integer = 0 To Math.Min(2, topicRankings.Count - 1)
                Dim ranking = topicRankings(i)

                ' LOGIC FILTER: Only show if score is >= 50%
                If ranking.Persentase >= 50 Then
                    Dim displayText As String = $"{ranking.Ranking}. {ranking.NamaTopic} - {ranking.Persentase}%"

                    Select Case displayIndex
                        Case 0
                            labelTopic.Text = displayText
                        Case 1
                            labelTopic2.Text = displayText
                        Case 2
                            labelTopic3.Text = displayText
                    End Select

                    displayIndex += 1
                End If
            Next

            ' If no topics qualified (all below 50%)
            If displayIndex = 0 Then
                labelTopic.Text = "Tidak ada topik yang cukup cocok (<50%)."
                labelTopic.ForeColor = Color.Red
            End If

            ' Get metode & rekomendasi (tetap ditampilkan seperti biasa)
            Dim result = ResultRepository.GetLatestResult(userId)

            If result IsNot Nothing Then
                labelMetode.Text = result.Metode

                If result.Rekomendasi.ToUpper() = "MEMBUAT" Then
                    labelRekomendasi.Text = "Membuat Aplikasi"
                ElseIf result.Rekomendasi.ToUpper() = "ANALISIS" Then
                    labelRekomendasi.Text = "Analisis Aplikasi"
                Else
                    labelRekomendasi.Text = result.Rekomendasi
                End If
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