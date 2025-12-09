Imports Guna.UI2.WinForms
Public Class FormPertanyaanAwal
    ' Timer tracking
    Private totalSeconds As Integer = 0

    ' Question data
    Private questions As New List(Of Question)
    Private currentIndex As Integer = 0
    Private answers As New Dictionary(Of Integer, Integer) ' questionId, skala

    ''' <summary>
    ''' Form Load - Load Level 1 questions
    ''' </summary>
    Private Sub FormPertanyaanAwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Load all Level 1 questions (TOPIK, METODE, REKOMENDASI)
            questions = QuestionRepository.GetLevel1Questions()

            If questions.Count = 0 Then
                MessageBox.Show("Tidak ada pertanyaan Level 1 di database.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Return
            End If

            ' Shuffle questions for randomization
            questions = questions.OrderBy(Function(x) Guid.NewGuid()).ToList()

            ' Display first question
            currentIndex = 0
            TampilkanPertanyaan()

            ' Start timer
            questionTimer.Interval = 1000
            questionTimer.Start()

        Catch ex As Exception
            MessageBox.Show("Gagal memuat pertanyaan: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Display current question
    ''' </summary>
    Private Sub TampilkanPertanyaan()
        Dim q As Question = questions(currentIndex)

        ' Update progress
        labelProgress.Text = $"Pertanyaan {currentIndex + 1} dari {questions.Count}"

        ' Update question text
        labelPertanyaan.Text = q.Pertanyaan

        ' Update progress bar
        Dim percentage As Integer = CInt(((currentIndex + 1) / questions.Count) * 100)
        progressBar.Value = percentage

        ' Reset radio buttons
        ResetRadioButtons()

        ' If already answered, restore previous answer
        If answers.ContainsKey(q.Id) Then
            SetSelectedScale(answers(q.Id))
        End If

        ' Enable/disable navigation buttons
        buttonKembali.Enabled = (currentIndex > 0)

        ' Change button text on last question
        If currentIndex = questions.Count - 1 Then
            buttonSelanjutnya.Text = "Selesai"
        Else
            buttonSelanjutnya.Text = "Selanjutnya"
        End If
    End Sub

    ''' <summary>
    ''' Reset all radio buttons
    ''' </summary>
    Private Sub ResetRadioButtons()
        radio1.Checked = False
        radio2.Checked = False
        radio3.Checked = False
        radio4.Checked = False
        radio5.Checked = False
        radio6.Checked = False
    End Sub

    ''' <summary>
    ''' Get selected scale (1-6)
    ''' </summary>
    Private Function GetSelectedScale() As Integer
        If radio1.Checked Then Return 1
        If radio2.Checked Then Return 2
        If radio3.Checked Then Return 3
        If radio4.Checked Then Return 4
        If radio5.Checked Then Return 5
        If radio6.Checked Then Return 6
        Return 0 ' Not selected
    End Function

    ''' <summary>
    ''' Set radio button based on scale
    ''' </summary>
    Private Sub SetSelectedScale(scale As Integer)
        Select Case scale
            Case 1 : radio1.Checked = True
            Case 2 : radio2.Checked = True
            Case 3 : radio3.Checked = True
            Case 4 : radio4.Checked = True
            Case 5 : radio5.Checked = True
            Case 6 : radio6.Checked = True
        End Select
    End Sub

    ''' <summary>
    ''' Button Selanjutnya - Save answer and navigate
    ''' </summary>
    Private Sub buttonSelanjutnya_Click(sender As Object, e As EventArgs) Handles buttonSelanjutnya.Click
        Dim scale As Integer = GetSelectedScale()
        Dim q As Question = questions(currentIndex)

        ' Validation
        If scale = 0 Then
            MessageBox.Show("Silakan pilih salah satu jawaban (skala 1–6) sebelum melanjutkan.",
                          "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Save answer to dictionary
        If answers.ContainsKey(q.Id) Then
            answers(q.Id) = scale
        Else
            answers.Add(q.Id, scale)
        End If

        ' Check if last question
        If currentIndex = questions.Count - 1 Then
            ' Confirm before finishing
            If MessageBox.Show("Selesai menjawab semua pertanyaan Level 1. Lanjutkan?",
                             "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                SimpanJawabanKeDatabase()
                ProcessLevel1Results()
            End If
        Else
            ' Move to next question
            currentIndex += 1
            TampilkanPertanyaan()
        End If
    End Sub

    ''' <summary>
    ''' Button Kembali - Navigate to previous question
    ''' </summary>
    Private Sub buttonKembali_Click(sender As Object, e As EventArgs) Handles buttonKembali.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            TampilkanPertanyaan()
        End If
    End Sub

    ''' <summary>
    ''' Timer Tick - Update timer display
    ''' </summary>
    Private Sub questionTimer_Tick(sender As Object, e As EventArgs) Handles questionTimer.Tick
        totalSeconds += 1

        Dim minutes As Integer = totalSeconds \ 60
        Dim seconds As Integer = totalSeconds Mod 60

        labelTimer.Text = $"{minutes:D2}:{seconds:D2}"
    End Sub

    ''' <summary>
    ''' Save all answers to database
    ''' </summary>
    Private Sub SimpanJawabanKeDatabase()
        Try
            Dim userId As Integer = GlobalUser.UserId

            For Each kvp In answers
                Dim questionId As Integer = kvp.Key
                Dim skala As Integer = kvp.Value

                ' Convert skala to CF
                Dim cfUser As Double = CertaintyFactorHelper.ConvertSkalaToCF(skala)

                ' Insert using repository
                AnswerRepository.Insert(userId, questionId, skala, cfUser)
            Next

        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan jawaban: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Process Level 1 results - Calculate CF and rankings
    ''' </summary>
    Private Sub ProcessLevel1Results()
        questionTimer.Stop()

        Try
            Dim userId As Integer = GlobalUser.UserId
            Dim engine As New InferenceEngine()

            ' Calculate CF for topics, metode, rekomendasi
            Dim topicCF As Dictionary(Of Integer, Double) = engine.CalculateTopicCF(userId)
            Dim metodeCF As Dictionary(Of String, Double) = engine.CalculateMetodeCF(userId)
            Dim rekomendasiCF As Dictionary(Of String, Double) = engine.CalculateRekomendasiCF(userId)

            ' Save topic rankings
            Dim topicRankings = topicCF.OrderByDescending(Function(x) x.Value).ToList()
            For i As Integer = 0 To topicRankings.Count - 1
                Dim topicId As Integer = topicRankings(i).Key
                Dim cfValue As Double = topicRankings(i).Value
                Dim persentase As Integer = CertaintyFactorHelper.CFToPercentage(cfValue)
                Dim ranking As Integer = i + 1

                ResultRepository.InsertRanking(userId, "TOPIK", topicId, cfValue, persentase, ranking)
            Next

            ' Save metode & rekomendasi
            Dim topMetode As String = metodeCF.OrderByDescending(Function(x) x.Value).First().Key
            Dim topRekomendasi As String = rekomendasiCF.OrderByDescending(Function(x) x.Value).First().Key

            ResultRepository.InsertResult(userId, topMetode, topRekomendasi)

            ' Navigate to Hasil Awal
            Dim frmHasil As New FormHasilAwal()
            frmHasil.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Gagal memproses hasil: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class