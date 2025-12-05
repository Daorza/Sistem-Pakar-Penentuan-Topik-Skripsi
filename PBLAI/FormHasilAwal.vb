Imports Microsoft.Data.SqlClient

Public Class FormHasilAwal

    Private totalSeconds As Integer = 0

    Private Sub FormHasilAwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InferensiLevel1()
        TampilkanHasilLevel1()
        questionTimer.Start()
    End Sub

    Private Sub questionTimer_Tick(sender As Object, e As EventArgs) Handles questionTimer.Tick
        totalSeconds += 1

        Dim minutes As Integer = totalSeconds \ 60
        Dim seconds As Integer = totalSeconds Mod 60

        labelTimer.Text = $"{minutes:D2}:{seconds:D2}"
    End Sub
    Public Function CombineCF(cf1 As Double, cf2 As Double) As Double
        Return cf1 + cf2 * (1 - cf1)
    End Function

    Public Sub InferensiLevel1()

        Dim sumTopik As New Dictionary(Of Integer, Double)
        Dim cfMetode As New Dictionary(Of String, Double)
        Dim cfRekomendasi As New Dictionary(Of String, Double)

        Try
            If conn.State <> ConnectionState.Open Then OpenConnection()

            Dim clear1 As New SqlCommand("DELETE FROM result_rankings WHERE user_id=@uid", conn)
            clear1.Parameters.AddWithValue("@uid", CurrentUserId)
            clear1.ExecuteNonQuery()

            Dim clear2 As New SqlCommand("DELETE FROM results WHERE user_id=@uid", conn)
            clear2.Parameters.AddWithValue("@uid", CurrentUserId)
            clear2.ExecuteNonQuery()

            Dim sql As String =
            "SELECT ua.cf_user, qr.topic_id, qr.metode, qr.rekomendasi " &
            "FROM user_answers ua " &
            "JOIN question_rules qr ON ua.question_id = qr.question_id " &
            "WHERE ua.user_id = @user_id;"

            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@user_id", CurrentUserId)

                Using rd = cmd.ExecuteReader()
                    While rd.Read()

                        Dim cfUser = CDbl(rd("cf_user"))

                        ' TOPIK
                        If Not IsDBNull(rd("topic_id")) Then
                            Dim topicId As Integer = CInt(rd("topic_id"))

                            If sumTopik.ContainsKey(topicId) Then
                                sumTopik(topicId) += cfUser
                            Else
                                sumTopik.Add(topicId, cfUser)
                            End If
                        End If

                        ' METODE
                        If Not IsDBNull(rd("metode")) Then
                            Dim metode As String = rd("metode").ToString()

                            If cfMetode.ContainsKey(metode) Then
                                If cfUser > cfMetode(metode) Then
                                    cfMetode(metode) = cfUser
                                End If
                            Else
                                cfMetode.Add(metode, cfUser)
                            End If
                        End If

                        ' REKOMENDASI
                        If Not IsDBNull(rd("rekomendasi")) Then
                            Dim rek As String = rd("rekomendasi").ToString()

                            If cfRekomendasi.ContainsKey(rek) Then
                                If cfUser > cfRekomendasi(rek) Then
                                    cfRekomendasi(rek) = cfUser
                                End If
                            Else
                                cfRekomendasi.Add(rek, cfUser)
                            End If
                        End If

                    End While
                End Using
            End Using


            ' PROSES TOPIK (TOP 3 + THRESHOLD)

            Dim jumlahSoalTopik As Integer = 6

            Dim hasilTopik = sumTopik.
            Select(Function(x) New With {
                .Id = x.Key,
                .CF = x.Value / jumlahSoalTopik
            }).
            OrderByDescending(Function(x) x.CF).
            ToList()

            Dim filtered = hasilTopik.Where(Function(x) x.CF >= 0.7).Take(3).ToList()

            If filtered.Count = 0 Then
                filtered = hasilTopik.Where(Function(x) x.CF >= 0.5).Take(3).ToList()
            End If

            If filtered.Count = 0 Then
                MessageBox.Show("Sistem tidak dapat menentukan topik. Silakan ulangi kembali menjawab pertanyaan.",
                                "Gagal",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' SIMPAN TOP 3 TOPIK

            For i = 0 To filtered.Count - 1
                Dim persen As Integer = CInt(filtered(i).CF * 100)

                Dim insertTopik As String =
                "INSERT INTO result_rankings (user_id, tipe, ref_id, cf_value, persentase, ranking) " &
                "VALUES (@uid, 'TOPIK', @ref, @cf, @persen, @rank);"

                Using cmd As New SqlCommand(insertTopik, conn)
                    cmd.Parameters.AddWithValue("@uid", CurrentUserId)
                    cmd.Parameters.AddWithValue("@ref", filtered(i).Id)
                    cmd.Parameters.AddWithValue("@cf", filtered(i).CF)
                    cmd.Parameters.AddWithValue("@persen", persen)
                    cmd.Parameters.AddWithValue("@rank", i + 1)
                    cmd.ExecuteNonQuery()
                End Using
            Next



            ' METODE TERBAIK

            Dim metodeFinal = cfMetode.OrderByDescending(Function(x) x.Value).First().Key

            ' REKOMENDASI TERBAIK
            Dim rekomendasiFinal = cfRekomendasi.OrderByDescending(Function(x) x.Value).First().Key



            ' SIMPAN KE TABEL RESULTS

            Dim insertResult As String =
            "INSERT INTO results (user_id, metode, rekomendasi) VALUES (@uid, @metode, @rek);"

            Using cmd As New SqlCommand(insertResult, conn)
                cmd.Parameters.AddWithValue("@uid", CurrentUserId)
                cmd.Parameters.AddWithValue("@metode", metodeFinal)
                cmd.Parameters.AddWithValue("@rek", rekomendasiFinal)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Inferensi Level 1 berhasil dilakukan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Inferensi gagal: " & ex.Message)
        End Try

    End Sub

    Private Sub TampilkanHasilLevel1()
        Try
            If conn.State <> ConnectionState.Open Then
                OpenConnection()
            End If

            ' AMBIL TOP 3 TOPIK
            Dim sqlTopik As String =
                "SELECT rr.ref_id, t.nama, rr.persentase, rr.ranking " &
                "FROM result_rankings rr " &
                "JOIN topics t ON rr.ref_id = t.id " &
                "WHERE rr.user_id = @uid AND rr.tipe = 'TOPIK' " &
                "ORDER BY rr.ranking;"

            Using cmd As New SqlCommand(sqlTopik, conn)
                cmd.Parameters.AddWithValue("@uid", CurrentUserId)

                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        Dim rank = CInt(rd("ranking"))
                        Dim nama = rd("nama").ToString()
                        Dim persen = rd("persentase").ToString()

                        Select Case rank
                            Case 1
                                labelTopic.Text = $"1. {nama} - {persen}%"
                            Case 2
                                labelTopic2.Text = $"2. {nama} - {persen}%"
                            Case 3
                                labelTopic3.Text = $"3. {nama} - {persen}%"
                        End Select
                    End While
                End Using
            End Using


            ' AMBIL METODE & REKOMENDASI

            Dim sqlMR As String =
                "SELECT metode, rekomendasi FROM results WHERE user_id = @uid;"

            Using cmd As New SqlCommand(sqlMR, conn)
                cmd.Parameters.AddWithValue("@uid", CurrentUserId)

                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        labelMetode.Text = rd("metode").ToString()
                        Dim rekRaw As String = rd("rekomendasi").ToString().ToUpper()

                        If rekRaw = "MEMBUAT" Then
                            labelRekomendasi.Text = "Membuat Aplikasi"
                        ElseIf rekRaw = "ANALISIS" Then
                            labelRekomendasi.Text = "Analisis Aplikasi"
                        Else
                            labelRekomendasi.Text = rekRaw
                        End If
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan hasil: " & ex.Message)
        End Try
    End Sub


    ' TOMBOL LANJUT KE LEVEL 2
    Private Sub nextButton_Click(sender As Object, e As EventArgs) Handles nextButton.Click
        Dim f As New FormPertanyaanAkhir
        f.Show()
        Me.Hide()
    End Sub

    ' TOMBOL SELESAIKAN
    Private Sub endButton_Click(sender As Object, e As EventArgs) Handles endButton.Click
        MessageBox.Show(
            "Tes telah selesai." & vbCrLf &
            "Terima kasih telah menggunakan Sistem Pakar Penentuan Topik Skripsi.",
            "Selesai",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

        Application.Exit()
    End Sub
End Class