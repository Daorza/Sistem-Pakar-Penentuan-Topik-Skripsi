Public Class ResultRanking
    Public Property Id As Integer
    Public Property UserId As Integer
    Public Property Tipe As String ' TOPIK or SUBTOPIK
    Public Property RefId As Integer
    Public Property CfValue As Double
    Public Property Persentase As Integer
    Public Property Ranking As Integer
    Public Property CreatedAt As DateTime

    ' Navigation properties
    Public Property NamaTopic As String
    Public Property NamaSubtopic As String

    Public Sub New()
        CreatedAt = DateTime.Now
    End Sub
End Class
