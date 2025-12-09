''' <summary>
''' Global User Session - stores current user data
''' </summary>
Public Class GlobalUser
    Public Shared Property UserId As Integer = 0
    Public Shared Property Nama As String = ""
    Public Shared Property NIM As String = ""
    Public Shared Property Prodi As String = ""
    Public Shared Property CurrentUser As User = Nothing

    ''' <summary>
    ''' Reset session data
    ''' </summary>
    Public Shared Sub Reset()
        UserId = 0
        Nama = ""
        NIM = ""
        Prodi = ""
    End Sub

    ''' <summary>
    ''' Check if user is logged in
    ''' </summary>
    Public Shared Function IsLoggedIn() As Boolean
        Return UserId > 0
    End Function
End Class
