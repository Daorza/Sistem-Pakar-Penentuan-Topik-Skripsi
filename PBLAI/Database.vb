Imports Microsoft.Data.SqlClient

Module Database
    Public conn As SqlConnection

    Public Sub OpenConnection()
        Try
            Dim connectionString As String =
                "Server=(localdb)\MSSQLLocalDB;Database=SistemPakarSkripsi;Trusted_Connection=True;"

            conn = New SqlConnection(connectionString)
            conn.Open()

        Catch ex As Exception
            MessageBox.Show("Koneksi Gagal: " & ex.Message)
        End Try
    End Sub
End Module
