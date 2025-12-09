Public Class AnswerRepository
    ''' <summary>
    ''' Insert user answer
    ''' </summary>
    Public Shared Function Insert(userId As Integer, questionId As Integer, skala As Integer, cfUser As Double) As Integer
        Try
            Dim query As String = "INSERT INTO user_answers (user_id, question_id, skala, cf_user) " &
                                "OUTPUT INSERTED.id VALUES (@userId, @questionId, @skala, @cfUser)"

            Dim params As New Dictionary(Of String, Object) From {
                {"@userId", userId},
                {"@questionId", questionId},
                {"@skala", skala},
                {"@cfUser", cfUser}
            }

            Return CInt(DatabaseHelper.ExecuteScalar(query, params))

        Catch ex As Exception
            Throw New Exception("Error inserting answer: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Get all answers for a user
    ''' </summary>
    Public Shared Function GetByUserId(userId As Integer) As List(Of UserAnswer)
        Try
            Dim query As String = "SELECT * FROM user_answers WHERE user_id = @userId ORDER BY created_at"
            Dim params As New Dictionary(Of String, Object) From {{"@userId", userId}}

            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)

            Dim answers As New List(Of UserAnswer)
            For Each row As DataRow In dt.Rows
                answers.Add(MapToUserAnswer(row))
            Next

            Return answers

        Catch ex As Exception
            Throw New Exception("Error getting answers: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Check if user has answered a specific question
    ''' </summary>
    Public Shared Function HasAnswered(userId As Integer, questionId As Integer) As Boolean
        Try
            Dim query As String = "SELECT COUNT(*) FROM user_answers WHERE user_id = @userId AND question_id = @questionId"
            Dim params As New Dictionary(Of String, Object) From {
                {"@userId", userId},
                {"@questionId", questionId}
            }

            Dim count As Integer = CInt(DatabaseHelper.ExecuteScalar(query, params))
            Return count > 0

        Catch ex As Exception
            Throw New Exception("Error checking answer: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Delete all answers for a user (for retake test)
    ''' </summary>
    Public Shared Function DeleteByUserId(userId As Integer) As Integer
        Try
            Dim query As String = "DELETE FROM user_answers WHERE user_id = @userId"
            Dim params As New Dictionary(Of String, Object) From {{"@userId", userId}}

            Return DatabaseHelper.ExecuteNonQuery(query, params)

        Catch ex As Exception
            Throw New Exception("Error deleting answers: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Map DataRow to UserAnswer object
    ''' </summary>
    Private Shared Function MapToUserAnswer(row As DataRow) As UserAnswer
        Return New UserAnswer With {
            .Id = CInt(row("id")),
            .UserId = CInt(row("user_id")),
            .QuestionId = CInt(row("question_id")),
            .Skala = CInt(row("skala")),
            .CfUser = CDbl(row("cf_user")),
            .CreatedAt = CDate(row("created_at"))
        }
    End Function
End Class
