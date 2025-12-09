Public Class SubtopicRepository
    ''' <summary>
    ''' Get subtopics by topic ID
    ''' </summary>
    Public Shared Function GetByTopicId(topicId As Integer) As List(Of Subtopic)
        Try
            Dim query As String = "SELECT s.*, t.nama as topic_nama " &
                                "FROM subtopics s " &
                                "INNER JOIN topics t ON s.topic_id = t.id " &
                                "WHERE s.topic_id = @topicId AND s.is_active = 1 " &
                                "ORDER BY s.id"

            Dim params As New Dictionary(Of String, Object) From {{"@topicId", topicId}}
            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)

            Dim subtopics As New List(Of Subtopic)
            For Each row As DataRow In dt.Rows
                subtopics.Add(MapToSubtopic(row))
            Next

            Return subtopics

        Catch ex As Exception
            Throw New Exception("Error getting subtopics: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Get all subtopics
    ''' </summary>
    Public Shared Function GetAll() As List(Of Subtopic)
        Try
            Dim query As String = "SELECT s.*, t.nama as topic_nama " &
                                "FROM subtopics s " &
                                "INNER JOIN topics t ON s.topic_id = t.id " &
                                "WHERE s.is_active = 1 " &
                                "ORDER BY s.topic_id, s.id"

            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query)

            Dim subtopics As New List(Of Subtopic)
            For Each row As DataRow In dt.Rows
                subtopics.Add(MapToSubtopic(row))
            Next

            Return subtopics

        Catch ex As Exception
            Throw New Exception("Error getting all subtopics: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Get subtopic by ID
    ''' </summary>
    Public Shared Function GetById(id As Integer) As Subtopic
        Try
            Dim query As String = "SELECT s.*, t.nama as topic_nama " &
                                "FROM subtopics s " &
                                "INNER JOIN topics t ON s.topic_id = t.id " &
                                "WHERE s.id = @id"

            Dim params As New Dictionary(Of String, Object) From {{"@id", id}}
            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)

            If dt.Rows.Count > 0 Then
                Return MapToSubtopic(dt.Rows(0))
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("Error getting subtopic: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Insert new subtopic
    ''' </summary>
    Public Shared Function Insert(topicId As Integer, kode As String, nama As String) As Integer
        Try
            Dim query As String = "INSERT INTO subtopics (topic_id, kode, nama) " &
                                "OUTPUT INSERTED.id VALUES (@topicId, @kode, @nama)"

            Dim params As New Dictionary(Of String, Object) From {
                {"@topicId", topicId},
                {"@kode", kode},
                {"@nama", nama}
            }

            Return CInt(DatabaseHelper.ExecuteScalar(query, params))

        Catch ex As Exception
            Throw New Exception("Error inserting subtopic: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Map DataRow to Subtopic object
    ''' </summary>
    Private Shared Function MapToSubtopic(row As DataRow) As Subtopic
        Return New Subtopic With {
            .Id = CInt(row("id")),
            .TopicId = CInt(row("topic_id")),
            .Kode = row("kode").ToString(),
            .Nama = row("nama").ToString(),
            .TopicNama = row("topic_nama").ToString(),
            .IsActive = CBool(row("is_active")),
            .CreatedAt = CDate(row("created_at")),
            .UpdatedAt = CDate(row("updated_at"))
        }
    End Function
End Class
