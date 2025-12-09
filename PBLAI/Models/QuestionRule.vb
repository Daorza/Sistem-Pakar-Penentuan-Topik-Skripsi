Public Class QuestionRule
    Public Property Id As Integer
    Public Property QuestionId As Integer
    Public Property TopicId As Integer?
    Public Property SubtopicId As Integer?
    Public Property Metode As String
    Public Property Rekomendasi As String
    Public Property CfPakar As Double
    Public Property IsActive As Boolean
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    Public Sub New()
        CfPakar = 1.0
        IsActive = True
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
    End Sub
End Class
