Public Class FormPertanyaanAwal

    Private totalSeconds As Integer = 0

    Private questions As New List(Of String) From {
        "Saya menyukai untuk memecahkan masalah dengan memikirkan solusi yang bisa memberi dampak.",
        "Saya tertarik mengembangkan perangkat lunak atau aplikasi.",
        "Saya suka bekerja dengan data dan membuat analisis terstruktur.",
        "Saya tertarik membuat model machine learning.",
        "Saya suka merancang tampilan UI/UX sebuah aplikasi."
    }

    Private currentIndex As Integer = 0
    Private answers(10) As Integer  ' Tampung jawaban user

    Private Sub LoadQuestion()
        labelProgress.Text = $"Pertanyaan {currentIndex + 1} dari {questions.Count}"
        labelPertanyaan.Text = questions(currentIndex)

        ' menjalan timer
        Dim percentage As Integer = CInt(((currentIndex + 1) / questions.Count) * 100)
        progressBar.Value = percentage

        ' reset radio setiap load
        radio1.Checked = False
        radio2.Checked = False
        radio3.Checked = False
        radio4.Checked = False
        radio5.Checked = False
        radio6.Checked = False

        ' kalau user sudah jawab, tampilkan lagi
        If answers(currentIndex) <> 0 Then
            Select Case answers(currentIndex)
                Case 1 : radio1.Checked = True
                Case 2 : radio2.Checked = True
                Case 3 : radio3.Checked = True
                Case 4 : radio4.Checked = True
                Case 5 : radio5.Checked = True
                Case 6 : radio6.Checked = True
            End Select
        End If

        ' disable prev jika di awal
        buttonKembali.Enabled = currentIndex > 0

        ' ubah text Next pada pertanyaan terakhir
        If currentIndex = questions.Count - 1 Then
            buttonSelanjutnya.Text = "Selesai"
        Else
            buttonSelanjutnya.Text = "Selanjutnya"
        End If
    End Sub

    Private Sub FormPertanyaanAwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        questionTimer.Start()
        LoadQuestion()
    End Sub

    Private Sub buttonSelanjutnya_Click(sender As Object, e As EventArgs) Handles buttonSelanjutnya.Click

        ' pastikan user memilih jawaban
        Dim selected As Integer = 0
        If radio1.Checked Then selected = 1
        If radio2.Checked Then selected = 2
        If radio3.Checked Then selected = 3
        If radio4.Checked Then selected = 4
        If radio5.Checked Then selected = 5
        If radio6.Checked Then selected = 6

        If selected = 0 Then
            MessageBox.Show("Harap pilih jawaban terlebih dahulu.", "Peringatan")
            Exit Sub
        End If

        ' simpan jawaban
        answers(currentIndex) = selected

        ' pertanyaan terakhir → selesai
        If currentIndex = questions.Count - 1 Then
            MessageBox.Show("Tes selesai! Data jawaban tersimpan sementara.", "Selesai")
            Exit Sub
        End If

        currentIndex += 1
        LoadQuestion()

    End Sub

    Private Sub buttonKembali_Click(sender As Object, e As EventArgs) Handles buttonKembali.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            LoadQuestion()
        End If
    End Sub

    Private Sub questionTimer_Tick(sender As Object, e As EventArgs) Handles questionTimer.Tick
        totalSeconds += 1

        Dim minutes As Integer = totalSeconds \ 60
        Dim seconds As Integer = totalSeconds Mod 60

        labelTimer.Text = $"{minutes:D2}:{seconds:D2}"
    End Sub
End Class