Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Public Class DatabaseHelper
    ' Connection string untuk LocalDB (adjust kalau beda instance)
    Private Shared ReadOnly ConnectionString As String =
        "Server=(LocalDB)\MSSQLLocalDB;Database=SistemPakarSkripsi;Integrated Security=True;TrustServerCertificate=True"
    ''' <summary>
    ''' Get SQL Connection object
    ''' </summary>
    Public Shared Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function
    ''' <summary>
    ''' Execute SELECT query and return DataTable
    ''' </summary>
    Public Shared Function ExecuteQuery(query As String, Optional params As Dictionary(Of String, Object) = Nothing) As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)
                    If params IsNot Nothing Then
                        For Each param In params
                            cmd.Parameters.AddWithValue(param.Key, If(param.Value, DBNull.Value))
                        Next
                    End If
                    conn.Open()
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Database query error: " & ex.Message, ex)
        End Try
        Return dt
    End Function
    ''' <summary>
    ''' Execute INSERT, UPDATE, DELETE and return rows affected
    ''' </summary>
    Public Shared Function ExecuteNonQuery(query As String, Optional params As Dictionary(Of String, Object) = Nothing) As Integer
        Dim rowsAffected As Integer = 0
        Try
            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)
                    If params IsNot Nothing Then
                        For Each param In params
                            cmd.Parameters.AddWithValue(param.Key, If(param.Value, DBNull.Value))
                        Next
                    End If
                    conn.Open()
                    rowsAffected = cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Database execution error: " & ex.Message, ex)
        End Try
        Return rowsAffected
    End Function
    ''' <summary>
    ''' Execute query and return single scalar value (for INSERT with SCOPE_IDENTITY)
    ''' </summary>
    Public Shared Function ExecuteScalar(query As String, Optional params As Dictionary(Of String, Object) = Nothing) As Object
        Dim result As Object = Nothing
        Try
            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)
                    If params IsNot Nothing Then
                        For Each param In params
                            cmd.Parameters.AddWithValue(param.Key, If(param.Value, DBNull.Value))
                        Next
                    End If
                    conn.Open()
                    result = cmd.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Database scalar error: " & ex.Message, ex)
        End Try
        Return result
    End Function
    ''' <summary>
    ''' Test database connection
    ''' </summary>
    Public Shared Function TestConnection() As Boolean
        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class