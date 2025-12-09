Imports System.Security.Cryptography
Imports System.Text

Public Class PasswordHelper
    ''' <summary>
    ''' Hash password menggunakan SHA256
    ''' </summary>
    Public Shared Function HashPassword(password As String) As String
        If String.IsNullOrEmpty(password) Then
            Throw New ArgumentException("Password cannot be null or empty")
        End If

        Using sha256 As SHA256 = SHA256.Create()
            ' Convert password string to bytes
            Dim passwordBytes As Byte() = Encoding.UTF8.GetBytes(password)
            
            ' Compute hash
            Dim hashBytes As Byte() = sha256.ComputeHash(passwordBytes)
            
            ' Convert hash bytes to hex string (uppercase)
            Dim hashString As New StringBuilder()
            For Each b As Byte In hashBytes
                hashString.Append(b.ToString("X2"))
            Next
            
            Return hashString.ToString()
        End Using
    End Function

    ''' <summary>
    ''' Verify password dengan membandingkan hash
    ''' </summary>
    Public Shared Function VerifyPassword(inputPassword As String, storedHash As String) As Boolean
        If String.IsNullOrEmpty(inputPassword) OrElse String.IsNullOrEmpty(storedHash) Then
            Return False
        End If

        ' Hash input password
        Dim inputHash As String = HashPassword(inputPassword)
        
        ' Compare (case-insensitive karena hex string)
        Return String.Equals(inputHash, storedHash, StringComparison.OrdinalIgnoreCase)
    End Function
End Class
