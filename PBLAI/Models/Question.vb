Public Class Question
    Public Property Id As Integer
    Public Property Pertanyaan As String
    Public Property Kategori As String ' TOPIK, SUBTOPIK, METODE, REKOMENDASI
    Public Property Level As Integer ' 1 or 2
    Public Property IsActive As Boolean
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    Public Sub New()
        IsActive = True
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
    End Sub
End Class
