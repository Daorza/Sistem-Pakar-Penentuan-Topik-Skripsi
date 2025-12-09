Public Class Result
    Public Property Id As Integer
    Public Property UserId As Integer
    Public Property Metode As String ' KUALITATIF or KUANTITATIF
    Public Property Rekomendasi As String ' MEMBUAT or ANALISIS
    Public Property CreatedAt As DateTime

    Public Sub New()
        CreatedAt = DateTime.Now
    End Sub
End Class
