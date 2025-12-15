Imports System.Drawing.Printing
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
    ''' FILTERED: Only shows results >= 50%
    ''' </summary>
    Private Sub TampilkanHasilAkhir()
        Try
            Dim userId As Integer = GlobalUser.UserId

            ' ==========================================
            ' 1. DISPLAY TOP 3 TOPICS (>= 50%)
            ' ==========================================
            Dim topicRankings = ResultRepository.GetRankingsByUser(userId, "TOPIK")

            ' Reset labels first
            labelTopic.Text = ""
            labelTopic2.Text = ""
            labelTopic3.Text = ""
            labelTopic2.Visible = False
            labelTopic3.Visible = False

            Dim topicDisplayIndex As Integer = 0

            If topicRankings.Count > 0 Then
                For i As Integer = 0 To Math.Min(2, topicRankings.Count - 1)
                    Dim ranking = topicRankings(i)

                    ' FILTER: Only show if score >= 50
                    If ranking.Persentase >= 50 Then
                        Dim displayText As String = $"{ranking.Ranking}. {ranking.NamaTopic} - {ranking.Persentase}%"

                        Select Case topicDisplayIndex
                            Case 0
                                labelTopic.Text = displayText
                                labelTopic.Visible = True
                            Case 1
                                labelTopic2.Text = displayText
                                labelTopic2.Visible = True
                            Case 2
                                labelTopic3.Text = displayText
                                labelTopic3.Visible = True
                        End Select

                        topicDisplayIndex += 1
                    End If
                Next
            End If

            ' Fallback if no topics meet criteria
            If topicDisplayIndex = 0 Then
                labelTopic.Text = "Tidak ada topik yang cukup dominan (<50%)"
                labelTopic.Visible = True
            End If

            ' ==========================================
            ' 2. DISPLAY TOP 3 SUBTOPICS (>= 50%)
            ' ==========================================
            Dim subtopicRankings = ResultRepository.GetRankingsByUser(userId, "SUBTOPIK")

            ' Reset labels first
            labelSubTopik.Text = ""
            labelSubTopik2.Text = ""
            labelSubTopik3.Text = ""
            labelSubTopik2.Visible = False
            labelSubTopik3.Visible = False

            Dim subtopicDisplayIndex As Integer = 0

            If subtopicRankings.Count > 0 Then
                For i As Integer = 0 To Math.Min(2, subtopicRankings.Count - 1)
                    Dim ranking = subtopicRankings(i)

                    ' FILTER: Only show if score >= 50
                    If ranking.Persentase >= 50 Then
                        Dim displayText As String = $"{ranking.Ranking}. {ranking.NamaSubtopic} - {ranking.Persentase}%"

                        Select Case subtopicDisplayIndex
                            Case 0
                                labelSubTopik.Text = displayText
                                labelSubTopik.Visible = True
                            Case 1
                                labelSubTopik2.Text = displayText
                                labelSubTopik2.Visible = True
                            Case 2
                                labelSubTopik3.Text = displayText
                                labelSubTopik3.Visible = True
                        End Select

                        subtopicDisplayIndex += 1
                    End If
                Next
            End If

            ' Fallback if no subtopics meet criteria
            If subtopicDisplayIndex = 0 Then
                labelSubTopik.Text = "Subtopik belum tersedia atau skor terlalu rendah."
                labelSubTopik.Visible = True
            End If

            ' ==========================================
            ' 3. DISPLAY METODE & REKOMENDASI
            ' ==========================================
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

    ''' <summary>
    ''' Button Print - Generates a report
    ''' </summary>
    Private Sub print_Click(sender As Object, e As EventArgs) Handles print.Click
        Try
            ' 1. Create the PrintDocument object
            Dim pd As New PrintDocument()
            pd.DefaultPageSettings.PaperSize = New PaperSize("A4", 827, 1169) ' Standard A4

            ' 2. Link the PrintPage event to our drawing logic
            AddHandler pd.PrintPage, AddressOf OnPrintPage

            ' 3. Create a Preview Dialog so user can see it before printing
            Dim ppd As New PrintPreviewDialog()
            ppd.Document = pd
            ppd.Width = 800
            ppd.Height = 600
            ppd.StartPosition = FormStartPosition.CenterScreen

            ' 4. Show the preview
            ppd.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Gagal mencetak dokumen: " & ex.Message, "Print Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' The Logic to DRAW the text onto the paper
    ''' </summary>
    Private Sub OnPrintPage(sender As Object, e As PrintPageEventArgs)
        ' --- 1. SETUP FONTS & BRUSHES ---
        Dim titleFont As New Font("Arial", 16, FontStyle.Bold)
        Dim headerFont As New Font("Arial", 12, FontStyle.Bold)
        Dim bodyFont As New Font("Arial", 11, FontStyle.Regular)
        Dim smallFont As New Font("Arial", 9, FontStyle.Italic)
        Dim brush As Brush = Brushes.Black
        Dim pen As New Pen(Color.Black, 1)

        ' --- 2. SETUP MARGINS & POSITIONS ---
        Dim startX As Integer = 50
        Dim startY As Integer = 50
        Dim offset As Integer = 40 ' Space between lines
        Dim currentY As Integer = startY

        ' --- 3. DRAW TITLE ---
        Dim title As String = "LAPORAN HASIL REKOMENDASI TOPIK SKRIPSI"
        ' Center the title
        Dim titleSize As SizeF = e.Graphics.MeasureString(title, titleFont)
        Dim centerX As Integer = (e.PageBounds.Width - titleSize.Width) / 2

        e.Graphics.DrawString(title, titleFont, brush, centerX, currentY)
        currentY += offset

        ' Draw a separator line
        e.Graphics.DrawLine(pen, startX, currentY, e.PageBounds.Width - startX, currentY)
        currentY += 20

        ' --- 4. DRAW USER INFO (USING GLOBALUSER) ---
        e.Graphics.DrawString("Tanggal Cetak : " & DateTime.Now.ToString("dd MMMM yyyy HH:mm"), bodyFont, brush, startX, currentY)
        currentY += 25

        ' USE GLOBALUSER.NAMA HERE
        Dim displayName As String = If(String.IsNullOrEmpty(GlobalUser.Nama), "User", GlobalUser.Nama)
        e.Graphics.DrawString("Nama User     : " & displayName, bodyFont, brush, startX, currentY)

        ' Optional: You can add NIM too if you want
        If Not String.IsNullOrEmpty(GlobalUser.NIM) Then
            currentY += 25
            e.Graphics.DrawString("NIM           : " & GlobalUser.NIM, bodyFont, brush, startX, currentY)
        End If

        currentY += offset + 10

        ' --- 5. DRAW HASIL LEVEL 1 (TOPIK UTAMA) ---
        e.Graphics.DrawString("I. REKOMENDASI TOPIK UTAMA", headerFont, brush, startX, currentY)
        currentY += 30

        ' Check Label texts to print what is visible on screen
        ' Because TampilkanHasilAkhir clears the text for < 50%, this logic automatically prints only valid ones
        If labelTopic.Text <> "" AndAlso labelTopic.Visible Then
            e.Graphics.DrawString("   " & labelTopic.Text, bodyFont, brush, startX, currentY)
            currentY += 25
        End If
        If labelTopic2.Text <> "" AndAlso labelTopic2.Visible Then
            e.Graphics.DrawString("   " & labelTopic2.Text, bodyFont, brush, startX, currentY)
            currentY += 25
        End If
        If labelTopic3.Text <> "" AndAlso labelTopic3.Visible Then
            e.Graphics.DrawString("   " & labelTopic3.Text, bodyFont, brush, startX, currentY)
            currentY += 25
        End If
        currentY += 15

        ' --- 6. DRAW HASIL LEVEL 2 (SUBTOPIK) ---
        e.Graphics.DrawString("II. REKOMENDASI SUBTOPIK SPESIFIK", headerFont, brush, startX, currentY)
        currentY += 30

        If labelSubTopik.Text <> "" AndAlso labelSubTopik.Visible Then
            e.Graphics.DrawString("   " & labelSubTopik.Text, bodyFont, brush, startX, currentY)
            currentY += 25
        End If
        If labelSubTopik2.Text <> "" AndAlso labelSubTopik2.Visible Then
            e.Graphics.DrawString("   " & labelSubTopik2.Text, bodyFont, brush, startX, currentY)
            currentY += 25
        End If
        If labelSubTopik3.Text <> "" AndAlso labelSubTopik3.Visible Then
            e.Graphics.DrawString("   " & labelSubTopik3.Text, bodyFont, brush, startX, currentY)
            currentY += 25
        End If
        currentY += 15

        ' --- 7. DRAW METODE & REKOMENDASI ---
        e.Graphics.DrawString("III. DETAIL PENELITIAN", headerFont, brush, startX, currentY)
        currentY += 30

        e.Graphics.DrawString("   Metode Penelitian       : " & labelMetode.Text, bodyFont, brush, startX, currentY)
        currentY += 25
        e.Graphics.DrawString("   Jenis Output Skripsi    : " & labelRekomendasi.Text, bodyFont, brush, startX, currentY)
        currentY += offset + 20

        ' --- 8. FOOTER ---
        ' Draw a bottom line
        e.Graphics.DrawLine(pen, startX, currentY, e.PageBounds.Width - startX, currentY)
        currentY += 10
        e.Graphics.DrawString("Dokumen ini digenerate secara otomatis oleh Sistem Pakar.", smallFont, Brushes.Gray, startX, currentY)
    End Sub

    Private Sub Guna2HtmlLabel5_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel5.Click
        Guna2HtmlLabel5.Text = "Selamat! " + GlobalUser.Nama + " (" + GlobalUser.NIM + ") - " + GlobalUser.Prodi + " telah menyelesaikan tes. Semoga membantu!"
    End Sub

End Class