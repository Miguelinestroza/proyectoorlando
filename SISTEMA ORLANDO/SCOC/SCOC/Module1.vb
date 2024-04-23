Imports System.Data.SqlClient
Module Module1
    Public conexion As New SqlConnection
    Public comando As New SqlCommand

    Sub conect()
        Try
            conexion.ConnectionString = "Data Source=CESAR\SQLCREDI;Initial Catalog=SistemaOrlando;Persist Security Info=True;User ID=sa;Password=1625"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
