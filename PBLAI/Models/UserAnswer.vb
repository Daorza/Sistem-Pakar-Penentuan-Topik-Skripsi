Public Class UserAnswer
    Public Property Id As Integer
    Public Property UserId As Integer
    Public Property QuestionId As Integer
    Public Property Skala As Integer ' 1-6
    Public Property CfUser As Double
    Public Property CreatedAt As DateTime

    Public Sub New()
        CreatedAt = DateTime.Now
    End Sub
End Class
