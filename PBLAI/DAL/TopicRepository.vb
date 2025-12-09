Public Class TopicRepository
    ''' <summary>
    ''' Get all topics
    ''' </summary>
    Public Shared Function GetAll() As List(Of Topic)
        Try
            Dim query As String = "SELECT * FROM topics WHERE is_active = 1 ORDER BY id"
            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query)

            Dim topics As New List(Of Topic)
            For Each row As DataRow In dt.Rows
                topics.Add(MapToTopic(row))
            Next

            Return topics

        Catch ex As Exception
            Throw New Exception("Error getting topics: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Get topic by ID
    ''' </summary>
    Public Shared Function GetById(id As Integer) As Topic
        Try
            Dim query As String = "SELECT * FROM topics WHERE id = @id"
            Dim params As New Dictionary(Of String, Object) From {{"@id", id}}

            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)

            If dt.Rows.Count > 0 Then
                Return MapToTopic(dt.Rows(0))
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("Error getting topic: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Insert new topic
    ''' </summary>
    Public Shared Function Insert(kode As String, nama As String) As Integer
        Try
            Dim query As String = "INSERT INTO topics (kode, nama) OUTPUT INSERTED.id VALUES (@kode, @nama)"
            Dim params As New Dictionary(Of String, Object) From {
                {"@kode", kode},
                {"@nama", nama}
            }

            Return CInt(DatabaseHelper.ExecuteScalar(query, params))

        Catch ex As Exception
            Throw New Exception("Error inserting topic: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Update topic
    ''' </summary>
    Public Shared Function Update(id As Integer, kode As String, nama As String) As Integer
        Try
            Dim query As String = "UPDATE topics SET kode = @kode, nama = @nama, updated_at = GETDATE() WHERE id = @id"
            Dim params As New Dictionary(Of String, Object) From {
                {"@id", id},
                {"@kode", kode},
                {"@nama", nama}
            }

            Return DatabaseHelper.ExecuteNonQuery(query, params)

        Catch ex As Exception
            Throw New Exception("Error updating topic: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Delete topic (soft delete)
    ''' </summary>
    Public Shared Function Delete(id As Integer) As Integer
        Try
            Dim query As String = "UPDATE topics SET is_active = 0 WHERE id = @id"
            Dim params As New Dictionary(Of String, Object) From {{"@id", id}}

            Return DatabaseHelper.ExecuteNonQuery(query, params)

        Catch ex As Exception
            Throw New Exception("Error deleting topic: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Map DataRow to Topic object
    ''' </summary>
    Private Shared Function MapToTopic(row As DataRow) As Topic
        Return New Topic With {
            .Id = CInt(row("id")),
            .Kode = row("kode").ToString(),
            .Nama = row("nama").ToString(),
            .IsActive = CBool(row("is_active")),
            .CreatedAt = CDate(row("created_at")),
            .UpdatedAt = CDate(row("updated_at"))
        }
    End Function
End Class
