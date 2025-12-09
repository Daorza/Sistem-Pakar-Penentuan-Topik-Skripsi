Imports Microsoft.Data.SqlClient
Imports System.Data
Public Class QuestionRepository
    ''' <summary>
    ''' Get questions by level and kategori
    ''' </summary>
    Public Shared Function GetByLevelAndKategori(level As Integer, kategori As String) As List(Of Question)
        Try
            Dim query As String = "SELECT * FROM questions " &
                                "WHERE level = @level AND kategori = @kategori AND is_active = 1 " &
                                "ORDER BY id"
            Dim params As New Dictionary(Of String, Object) From {
                {"@level", level},
                {"@kategori", kategori}
            }
            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)
            Dim questions As New List(Of Question)
            For Each row As DataRow In dt.Rows
                questions.Add(MapToQuestion(row))
            Next
            Return questions
        Catch ex As Exception
            Throw New Exception("Error getting questions: " & ex.Message, ex)
        End Try
    End Function
    ''' <summary>
    ''' Get all Level 1 questions (all categories)
    ''' </summary>
    Public Shared Function GetLevel1Questions() As List(Of Question)
        Try
            Dim query As String = "SELECT * FROM questions WHERE level = 1 AND is_active = 1 ORDER BY kategori, id"
            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query)
            Dim questions As New List(Of Question)
            For Each row As DataRow In dt.Rows
                questions.Add(MapToQuestion(row))
            Next
            Return questions
        Catch ex As Exception
            Throw New Exception("Error getting level 1 questions: " & ex.Message, ex)
        End Try
    End Function
    ''' <summary>
    ''' Get Level 2 questions by topic (using question_rules join)
    ''' </summary>
    Public Shared Function GetLevel2QuestionsByTopic(topicId As Integer) As List(Of Question)
        Try
            Dim query As String = "SELECT DISTINCT q.* " &
                                "FROM questions q " &
                                "INNER JOIN question_rules qr ON q.id = qr.question_id " &
                                "INNER JOIN subtopics s ON qr.subtopic_id = s.id " &
                                "WHERE q.level = 2 AND q.kategori = 'SUBTOPIK' " &
                                "AND s.topic_id = @topicId AND q.is_active = 1 " &
                                "ORDER BY q.id"
            Dim params As New Dictionary(Of String, Object) From {{"@topicId", topicId}}
            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)
            Dim questions As New List(Of Question)
            For Each row As DataRow In dt.Rows
                questions.Add(MapToQuestion(row))
            Next
            Return questions
        Catch ex As Exception
            Throw New Exception("Error getting level 2 questions: " & ex.Message, ex)
        End Try
    End Function
    ''' <summary>
    ''' Get all questions (for admin CRUD)
    ''' </summary>
    Public Shared Function GetAll() As List(Of Question)
        Try
            Dim query As String = "SELECT * FROM questions ORDER BY level, kategori, id"
            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query)
            Dim questions As New List(Of Question)
            For Each row As DataRow In dt.Rows
                questions.Add(MapToQuestion(row))
            Next
            Return questions
        Catch ex As Exception
            Throw New Exception("Error getting all questions: " & ex.Message, ex)
        End Try
    End Function
    ''' <summary>
    ''' Get question by ID
    ''' </summary>
    Public Shared Function GetById(id As Integer) As Question
        Try
            Dim query As String = "SELECT * FROM questions WHERE is_active = 1 ORDER BY id"
            Dim params As New Dictionary(Of String, Object) From {{"@id", id}}
            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)
            If dt.Rows.Count > 0 Then
                Return MapToQuestion(dt.Rows(0))
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception("Error getting question: " & ex.Message, ex)
        End Try
    End Function
    ''' <summary>
    ''' Insert new question
    ''' </summary>
    Public Shared Function Insert(pertanyaan As String, kategori As String, level As Integer) As Integer
        Try
            Dim query As String = "INSERT INTO questions (pertanyaan, kategori, level) " &
                                "OUTPUT INSERTED.id VALUES (@pertanyaan, @kategori, @level)"
            Dim params As New Dictionary(Of String, Object) From {
                {"@pertanyaan", pertanyaan},
                {"@kategori", kategori},
                {"@level", level}
            }
            Return CInt(DatabaseHelper.ExecuteScalar(query, params))
        Catch ex As Exception
            Throw New Exception("Error inserting question: " & ex.Message, ex)
        End Try
    End Function
    ''' <summary>
    ''' Update question
    ''' </summary>
    Public Shared Function Update(id As Integer, pertanyaan As String, kategori As String, level As Integer) As Integer
        Try
            Dim query As String = "UPDATE questions SET pertanyaan = @pertanyaan, kategori = @kategori, " &
                                "level = @level, updated_at = GETDATE() WHERE id = @id"
            Dim params As New Dictionary(Of String, Object) From {
                {"@id", id},
                {"@pertanyaan", pertanyaan},
                {"@kategori", kategori},
                {"@level", level}
            }
            Return DatabaseHelper.ExecuteNonQuery(query, params)
        Catch ex As Exception
            Throw New Exception("Error updating question: " & ex.Message, ex)
        End Try
    End Function
    ''' <summary>
    ''' Delete question (soft delete)
    ''' </summary>
    Public Shared Function Delete(id As Integer) As Integer
        Try
            Dim query As String = "UPDATE questions SET is_active = 0 WHERE id = @id"
            Dim params As New Dictionary(Of String, Object) From {{"@id", id}}
            Return DatabaseHelper.ExecuteNonQuery(query, params)
        Catch ex As Exception
            Throw New Exception("Error deleting question: " & ex.Message, ex)
        End Try
    End Function
    ''' <summary>
    ''' Insert new question along with its rule (Transactional)
    ''' </summary>
    Public Shared Function InsertWithRule(question As Question, rule As QuestionRule) As Integer
        Dim questionId As Integer = 0

        Using conn As SqlConnection = DatabaseHelper.GetConnection()
            conn.Open()
            Dim transaction As SqlTransaction = conn.BeginTransaction()
            Try
                ' 1. Insert Question
                Dim queryQ As String = "INSERT INTO questions (pertanyaan, kategori, level) " &
                                     "OUTPUT INSERTED.id VALUES (@pertanyaan, @kategori, @level)"

                Using cmdQ As New SqlCommand(queryQ, conn, transaction)
                    cmdQ.Parameters.AddWithValue("@pertanyaan", question.Pertanyaan)
                    cmdQ.Parameters.AddWithValue("@kategori", question.Kategori)
                    cmdQ.Parameters.AddWithValue("@level", question.Level)
                    questionId = CInt(cmdQ.ExecuteScalar())
                End Using
                ' 2. Insert Rule
                Dim queryR As String = "INSERT INTO question_rules (question_id, topic_id, subtopic_id, metode, rekomendasi, cf_pakar) " &
                                     "VALUES (@questionId, @topicId, @subtopicId, @metode, @rekomendasi, @cfPakar)"

                Using cmdR As New SqlCommand(queryR, conn, transaction)
                    cmdR.Parameters.AddWithValue("@questionId", questionId)
                    cmdR.Parameters.AddWithValue("@topicId", If(rule.TopicId.HasValue, rule.TopicId.Value, DBNull.Value))
                    cmdR.Parameters.AddWithValue("@subtopicId", If(rule.SubtopicId.HasValue, rule.SubtopicId.Value, DBNull.Value))
                    cmdR.Parameters.AddWithValue("@metode", If(String.IsNullOrEmpty(rule.Metode), DBNull.Value, rule.Metode))
                    cmdR.Parameters.AddWithValue("@rekomendasi", If(String.IsNullOrEmpty(rule.Rekomendasi), DBNull.Value, rule.Rekomendasi))
                    cmdR.Parameters.AddWithValue("@cfPakar", rule.CfPakar)
                    cmdR.ExecuteNonQuery()
                End Using
                transaction.Commit()
                Return questionId
            Catch ex As Exception
                transaction.Rollback()
                Throw New Exception("Error inserting question with rule: " & ex.Message, ex)
            End Try
        End Using
    End Function
    ''' <summary>
    ''' Update question and its rule (Transactional)
    ''' </summary>
    Public Shared Function UpdateWithRule(question As Question, rule As QuestionRule) As Boolean
        Using conn As SqlConnection = DatabaseHelper.GetConnection()
            conn.Open()
            Dim transaction As SqlTransaction = conn.BeginTransaction()
            Try
                ' 1. Update Question
                Dim queryQ As String = "UPDATE questions SET pertanyaan = @pertanyaan, kategori = @kategori, " &
                                     "level = @level, updated_at = GETDATE() WHERE id = @id"

                Using cmdQ As New SqlCommand(queryQ, conn, transaction)
                    cmdQ.Parameters.AddWithValue("@id", question.Id)
                    cmdQ.Parameters.AddWithValue("@pertanyaan", question.Pertanyaan)
                    cmdQ.Parameters.AddWithValue("@kategori", question.Kategori)
                    cmdQ.Parameters.AddWithValue("@level", question.Level)
                    cmdQ.ExecuteNonQuery()
                End Using
                ' 2. Check if rule exists, if not insert, else update
                ' For simplicity, we'll try update first, if 0 rows, then insert
                Dim queryRUpdate As String = "UPDATE question_rules SET topic_id = @topicId, subtopic_id = @subtopicId, " &
                                           "metode = @metode, rekomendasi = @rekomendasi, cf_pakar = @cfPakar, updated_at = GETDATE() " &
                                           "WHERE question_id = @questionId"

                Dim rowsAffected As Integer = 0
                Using cmdR As New SqlCommand(queryRUpdate, conn, transaction)
                    cmdR.Parameters.AddWithValue("@questionId", question.Id)
                    cmdR.Parameters.AddWithValue("@topicId", If(rule.TopicId.HasValue, rule.TopicId.Value, DBNull.Value))
                    cmdR.Parameters.AddWithValue("@subtopicId", If(rule.SubtopicId.HasValue, rule.SubtopicId.Value, DBNull.Value))
                    cmdR.Parameters.AddWithValue("@metode", If(String.IsNullOrEmpty(rule.Metode), DBNull.Value, rule.Metode))
                    cmdR.Parameters.AddWithValue("@rekomendasi", If(String.IsNullOrEmpty(rule.Rekomendasi), DBNull.Value, rule.Rekomendasi))
                    cmdR.Parameters.AddWithValue("@cfPakar", rule.CfPakar)
                    rowsAffected = cmdR.ExecuteNonQuery()
                End Using
                If rowsAffected = 0 Then
                    ' Insert if not exists
                    Dim queryRInsert As String = "INSERT INTO question_rules (question_id, topic_id, subtopic_id, metode, rekomendasi, cf_pakar) " &
                                               "VALUES (@questionId, @topicId, @subtopicId, @metode, @rekomendasi, @cfPakar)"
                    Using cmdR As New SqlCommand(queryRInsert, conn, transaction)
                        cmdR.Parameters.AddWithValue("@questionId", question.Id)
                        cmdR.Parameters.AddWithValue("@topicId", If(rule.TopicId.HasValue, rule.TopicId.Value, DBNull.Value))
                        cmdR.Parameters.AddWithValue("@subtopicId", If(rule.SubtopicId.HasValue, rule.SubtopicId.Value, DBNull.Value))
                        cmdR.Parameters.AddWithValue("@metode", If(String.IsNullOrEmpty(rule.Metode), DBNull.Value, rule.Metode))
                        cmdR.Parameters.AddWithValue("@rekomendasi", If(String.IsNullOrEmpty(rule.Rekomendasi), DBNull.Value, rule.Rekomendasi))
                        cmdR.Parameters.AddWithValue("@cfPakar", rule.CfPakar)
                        cmdR.ExecuteNonQuery()
                    End Using
                End If
                transaction.Commit()
                Return True
            Catch ex As Exception
                transaction.Rollback()
                Throw New Exception("Error updating question with rule: " & ex.Message, ex)
            End Try
        End Using
    End Function
    ''' <summary>
    ''' Get Rule by Question ID
    ''' </summary>
    Public Shared Function GetRuleByQuestionId(questionId As Integer) As QuestionRule
        Try
            Dim query As String = "SELECT * FROM question_rules WHERE question_id = @questionId"
            Dim params As New Dictionary(Of String, Object) From {{"@questionId", questionId}}
            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)
            If dt.Rows.Count > 0 Then
                Dim row = dt.Rows(0)
                Return New QuestionRule With {
                    .Id = CInt(row("id")),
                    .QuestionId = CInt(row("question_id")),
                    .TopicId = If(IsDBNull(row("topic_id")), Nothing, CType(row("topic_id"), Integer?)),
                    .SubtopicId = If(IsDBNull(row("subtopic_id")), Nothing, CType(row("subtopic_id"), Integer?)),
                    .Metode = If(IsDBNull(row("metode")), Nothing, row("metode").ToString()),
                    .Rekomendasi = If(IsDBNull(row("rekomendasi")), Nothing, row("rekomendasi").ToString()),
                    .CfPakar = CDbl(row("cf_pakar")),
                    .IsActive = CBool(row("is_active")),
                    .CreatedAt = CDate(row("created_at")),
                    .UpdatedAt = CDate(row("updated_at"))
                }
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception("Error getting rule: " & ex.Message, ex)
        End Try
    End Function
    ''' <summary>
    ''' Map DataRow to Question object
    ''' </summary>
    Private Shared Function MapToQuestion(row As DataRow) As Question
        Return New Question With {
            .Id = CInt(row("id")),
            .Pertanyaan = row("pertanyaan").ToString(),
            .Kategori = row("kategori").ToString(),
            .Level = CInt(row("level")),
            .IsActive = CBool(row("is_active")),
            .CreatedAt = CDate(row("created_at")),
            .UpdatedAt = CDate(row("updated_at"))
        }
    End Function
End Class