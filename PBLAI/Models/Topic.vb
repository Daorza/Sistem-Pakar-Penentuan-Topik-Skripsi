Public Class Topic
    Public Property Id As Integer
    Public Property Kode As String
    Public Property Nama As String
    Public Property IsActive As Boolean
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    Public Sub New()
        IsActive = True
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
    End Sub
End Class
