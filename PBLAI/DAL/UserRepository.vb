Public Class UserRepository
    ''' <summary>
    ''' Insert new user and return user ID
    ''' </summary>
    Public Shared Function Insert(nama As String, nim As String, prodi As String) As Integer
        Try
            Dim query As String = "INSERT INTO users (nama, nim, prodi) " &
                                "OUTPUT INSERTED.id " &
                                "VALUES (@nama, @nim, @prodi)"

            Dim params As New Dictionary(Of String, Object) From {
                {"@nama", nama},
                {"@nim", nim},
                {"@prodi", prodi}
            }

            Dim userId As Object = DatabaseHelper.ExecuteScalar(query, params)
            Return CInt(userId)

        Catch ex As Exception
            Throw New Exception("Error inserting user: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Get user by ID
    ''' </summary>
    Public Shared Function GetById(id As Integer) As User
        Try
            Dim query As String = "SELECT * FROM users WHERE id = @id"
            Dim params As New Dictionary(Of String, Object) From {{"@id", id}}

            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)

            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Return MapToUser(row)
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("Error getting user: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Get user by NIM and password (for admin login)
    ''' Password is hashed using SHA256 before comparison
    ''' </summary>
    Public Shared Function GetByNimAndPassword(nim As String, password As String) As User
        Try
            ' First, get user by NIM only
            Dim query As String = "SELECT * FROM users WHERE nim = @nim AND is_active = 1"
            Dim params As New Dictionary(Of String, Object) From {
                {"@nim", nim}
            }

            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)

            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Dim storedPasswordHash As String = row("password").ToString()
                
                ' Verify password using PasswordHelper
                If PasswordHelper.VerifyPassword(password, storedPasswordHash) Then
                    Return MapToUser(row)
                Else
                    Return Nothing ' Password mismatch
                End If
            Else
                Return Nothing ' User not found
            End If

        Catch ex As Exception
            Throw New Exception("Error validating user: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Get all users
    ''' </summary>
    Public Shared Function GetAll() As List(Of User)
        Try
            Dim query As String = "SELECT * FROM users ORDER BY created_at DESC"
            Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query)

            Dim users As New List(Of User)
            For Each row As DataRow In dt.Rows
                users.Add(MapToUser(row))
            Next

            Return users

        Catch ex As Exception
            Throw New Exception("Error getting users: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Map DataRow to User object
    ''' </summary>
    Private Shared Function MapToUser(row As DataRow) As User
        Return New User With {
            .Id = CInt(row("id")),
            .Nama = row("nama").ToString(),
            .Nim = row("nim").ToString(),
            .Prodi = row("prodi").ToString(),
            .Password = If(IsDBNull(row("password")), "", row("password").ToString()),
            .Role = If(IsDBNull(row("role")), "user", row("role").ToString()),
            .IsActive = CBool(row("is_active")),
            .CreatedAt = CDate(row("created_at")),
            .UpdatedAt = CDate(row("updated_at"))
        }
    End Function
End Class
