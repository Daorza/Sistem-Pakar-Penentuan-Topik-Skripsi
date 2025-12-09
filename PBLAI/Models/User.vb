Public Class User
    Public Property Id As Integer
    Public Property Nama As String
    Public Property Nim As String
    Public Property Prodi As String
    Public Property Password As String
    Public Property Role As String
    Public Property IsActive As Boolean
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    Public Sub New()
        IsActive = True
        Role = "user"
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
    End Sub
End Class
