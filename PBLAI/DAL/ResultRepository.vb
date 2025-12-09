Public Class ResultRepository
    ''' <summary>
    ''' Insert result ranking
    ''' </summary>
    Public Shared Function InsertRanking(userId As Integer, tipe As String, refId As Integer,
                                        cfValue As Double, persentase As Integer, ranking As Integer) As Integer
        Try
            Dim query As String = "INSERT INTO result_rankings (user_id, tipe, ref_id, cf_value, persentase, ranking) " &
                                "OUTPUT INSERTED.id VALUES (@userId, @tipe, @refId, @cfValue, @persentase, @ranking)"

            Dim params As New Dictionary(Of String, Object) From {
                {"@userId", userId},
                {"@tipe", tipe},
                {"@refId", refId},
                {"@cfValue", cfValue},
                {"@persentase", persentase},
                {"@ranking", ranking}
            }

            Return CInt(DatabaseHelper.ExecuteScalar(query, params))

        Catch ex As Exception
            Throw New Exception("Error inserting ranking: " & ex.Message, ex)
        End Try
    End Function

    '''<summary>
    ''' Insert result (metode & rekomendasi)
    ''' </summary>
    Public Shared Function InsertResult(userId As Integer, metode As String, rekomendasi As String) As Integer
        Try
            Dim query As String = "INSERT INTO results (user_id, metode, rekomendasi) " &
                                "OUTPUT INSERTED.id VALUES (@userId, @metode, @rekomendasi)"

            Dim params As New Dictionary(Of String, Object) From {
                {"@userId", userId},
                {"@metode", metode},
                {"@rekomendasi", rekomendasi}
            }

            Return CInt(DatabaseHelper.ExecuteScalar(query, params))

        Catch ex As Exception
            Throw New Exception("Error inserting result: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Get result rankings for a user (topics or subtopics)
    ''' </summary>
    Public Shared Function GetRankingsByUser(userId As Integer, tipe As String) As List(Of ResultRanking)
        Try
            Dim query As String
            If tipe = "TOPIK" Then
                query = "SELECT rr.*, t.nama as topic_nama " &
                       "FROM result_rankings rr " &
                       "INNER JOIN topics t ON rr.ref_id = t.id " &
                       "WHERE rr.user_id = @userId AND rr.tipe = @tipe " &
                       "ORDER BY rr.ranking"
            Else ' SUBTOPIK
                query = "SELECT rr.*, s.nama as subtopic_nama " &
                       "FROM result_rankings rr " &
                       "INNER JOIN subtopics s ON rr.ref_id = s.id " &
                       "WHERE rr.user_id = @userId AND rr.tipe = @tipe " &
                       "ORDER BY rr.ranking"
            End If

            Dim params As New Dictionary(Of String, Object) From {
                {"@userId", userId},
                {"@tipe", tipe}
            }

            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)

            Dim rankings As New List(Of ResultRanking)
            For Each row As DataRow In dt.Rows
                Dim ranking As New ResultRanking With {
                    .Id = CInt(row("id")),
                    .UserId = CInt(row("user_id")),
                    .Tipe = row("tipe").ToString(),
                    .RefId = CInt(row("ref_id")),
                    .CfValue = CDbl(row("cf_value")),
                    .Persentase = CInt(row("persentase")),
                    .Ranking = CInt(row("ranking")),
                    .CreatedAt = CDate(row("created_at"))
                }

                If tipe = "TOPIK" Then
                    ranking.NamaTopic = row("topic_nama").ToString()
                Else
                    ranking.NamaSubtopic = row("subtopic_nama").ToString()
                End If

                rankings.Add(ranking)
            Next

            Return rankings

        Catch ex As Exception
            Throw New Exception("Error getting rankings: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Get latest result for a user
    ''' </summary>
    Public Shared Function GetLatestResult(userId As Integer) As Result
        Try
            Dim query As String = "SELECT TOP 1 * FROM results WHERE user_id = @userId ORDER BY created_at DESC"
            Dim params As New Dictionary(Of String, Object) From {{"@userId", userId}}

            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)

            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Return New Result With {
                    .Id = CInt(row("id")),
                    .UserId = CInt(row("user_id")),
                    .Metode = row("metode").ToString(),
                    .Rekomendasi = row("rekomendasi").ToString(),
                    .CreatedAt = CDate(row("created_at"))
                }
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("Error getting result: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Delete all results for a user (for retake test)
    ''' </summary>
    Public Shared Sub DeleteByUserId(userId As Integer)
        Try
            ' Delete rankings first (FK constraint)
            Dim query1 As String = "DELETE FROM result_rankings WHERE user_id = @userId"
            Dim query2 As String = "DELETE FROM results WHERE user_id = @userId"

            Dim params As New Dictionary(Of String, Object) From {{"@userId", userId}}

            DatabaseHelper.ExecuteNonQuery(query1, params)
            DatabaseHelper.ExecuteNonQuery(query2, params)

        Catch ex As Exception
            Throw New Exception("Error deleting results: " & ex.Message, ex)
        End Try
    End Sub
End Class
