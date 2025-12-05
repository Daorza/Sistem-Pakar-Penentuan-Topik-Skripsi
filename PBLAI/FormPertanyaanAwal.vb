Imports Microsoft.Data.SqlClient

Public Class FormPertanyaanAwal

    Private totalSeconds As Integer = 0

    Private Class QuestionItem
        Public Property Id As Integer
        Public Property Text As String
    End Class

    Private questions As New List(Of QuestionItem)
    Private currentIndex As Integer = 0
    Private answers As New Dictionary(Of Integer, Integer)

    Private Sub TampilkanPertanyaan()
        Dim q = questions(currentIndex)

        labelProgress.Text = $"Pertanyaan {currentIndex + 1} dari {questions.Count}"
        labelPertanyaan.Text = q.Text

        Dim percentage As Integer = CInt(((currentIndex + 1) / questions.Count) * 100)
        progressBar.Value = percentage

        ' Reset radio button
        radio1.Checked = False
        radio2.Checked = False
        radio3.Checked = False
        radio4.Checked = False
        radio5.Checked = False
        radio6.Checked = False

        If answers.ContainsKey(q.Id) Then
            Select Case answers(q.Id)
                Case 1 : radio1.Checked = True
                Case 2 : radio2.Checked = True
                Case 3 : radio3.Checked = True
                Case 4 : radio4.Checked = True
                Case 5 : radio5.Checked = True
                Case 6 : radio6.Checked = True
            End Select
        End If

        buttonKembali.Enabled = (currentIndex > 0)
        If currentIndex = questions.Count - 1 Then
            buttonSelanjutnya.Text = "Selesai"
        Else
            buttonSelanjutnya.Text = "Selanjutnya"
        End If
    End Sub

    Private Function GetSelectedScale() As Integer
        If radio1.Checked Then Return 1
        If radio2.Checked Then Return 2
        If radio3.Checked Then Return 3
        If radio4.Checked Then Return 4
        If radio5.Checked Then Return 5
        If radio6.Checked Then Return 6
        Return 0
    End Function

    Private Sub FormPertanyaanAwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            If conn.State <> ConnectionState.Open Then
                OpenConnection()
            End If

            Dim sql As String = "SELECT id, pertanyaan FROM questions WHERE level = 1 AND is_active = 1 ORDER BY NEWID();"
            Dim cmd As New SqlCommand(sql, conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim q As New QuestionItem With {
                    .Id = Convert.ToInt32(reader("id")),
                    .Text = reader("pertanyaan").ToString()
                }
                questions.Add(q)
            End While
            reader.Close()

            If questions.Count = 0 Then
                MessageBox.Show("Tidak ada pertanyaan Level 1 di database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Exit Sub
            End If

            currentIndex = 0
            TampilkanPertanyaan()

            questionTimer.Interval = 1000
            questionTimer.Start()

        Catch ex As Exception
            MessageBox.Show("Gagal memuat pertanyaan: " & ex.Message)
        End Try
    End Sub

    Private Sub buttonSelanjutnya_Click(sender As Object, e As EventArgs) Handles buttonSelanjutnya.Click

        Dim scale = GetSelectedScale()
        Dim q = questions(currentIndex)

        If scale = 0 Then
            MessageBox.Show("Silakan pilih salah satu jawaban (skala 1–6) sebelum melanjutkan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If answers.ContainsKey(q.Id) Then
            answers(q.Id) = scale
        Else
            answers.Add(q.Id, scale)
        End If

        If currentIndex = questions.Count - 1 Then
            If MessageBox.Show("Selesai menjawab semua pertanyaan. Simpan jawaban?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                SimpanJawabanKeDatabase()
                Dim f As New FormHasilAwal
                f.Show()
                Me.Close()
            End If
        Else
            currentIndex += 1
            TampilkanPertanyaan()
        End If

    End Sub

    Private Sub buttonKembali_Click(sender As Object, e As EventArgs) Handles buttonKembali.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            TampilkanPertanyaan()
        End If
    End Sub

    Private Sub questionTimer_Tick(sender As Object, e As EventArgs) Handles questionTimer.Tick
        totalSeconds += 1

        Dim minutes As Integer = totalSeconds \ 60
        Dim seconds As Integer = totalSeconds Mod 60

        labelTimer.Text = $"{minutes:D2}:{seconds:D2}"
    End Sub

    Private Sub SimpanJawabanKeDatabase()
        Try
            If conn.State <> ConnectionState.Open Then
                OpenConnection()
            End If

            For Each kvp In answers
                Dim questionId = kvp.Key
                Dim scale = kvp.Value
                Dim cf = ConvertScaleToCF(scale)

                Dim sql As String = "INSERT INTO user_answers (user_id, question_id, skala, cf_user) " &
                                    "VALUES (@user_id, @question_id, @skala, @cf_user);"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@user_id", CurrentUserId)
                    cmd.Parameters.AddWithValue("@question_id", questionId)
                    cmd.Parameters.AddWithValue("@skala", scale)
                    cmd.Parameters.AddWithValue("@cf_user", cf)
                    cmd.ExecuteNonQuery()
                End Using
            Next

            MessageBox.Show("Jawaban berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan jawaban: " & ex.Message)
        End Try
    End Sub
End Class