Imports System.Data.SqlClient
Public Class frmPostearPago
    Private Sub frmPostearPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conect()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim terminoBusqueda As String = TextBox1.Text.Trim()
        Dim consulta As String = "SELECT * FROM referencias WHERE IDCliente = @IDCliente"
        Using comando As New SqlCommand(consulta, conexion)
            comando.Parameters.AddWithValue("@IDCliente", terminoBusqueda)
            Dim adaptador2 As New SqlDataAdapter(comando)
            Dim conjuntoDatos2 As New DataSet()
            adaptador2.Fill(conjuntoDatos2, "IDCliente")
            If conjuntoDatos2.Tables("IDCliente").Rows.Count > 0 Then
                Dim fila2 As DataRow = conjuntoDatos2.Tables("IDCliente").Rows(0)
                TextBox32.Text = fila2("R1Nombre").ToString()
                TextBox30.Text = fila2("R1Parentesco").ToString()
                TextBox29.Text = fila2("R1Direccion").ToString()
                TextBox28.Text = fila2("R1Numero").ToString()
                TextBox33.Text = fila2("R2Nombre").ToString()
                TextBox31.Text = fila2("R2Parentesco").ToString()
                TextBox27.Text = fila2("R2Direccion").ToString()
                TextBox24.Text = fila2("R2Numero").ToString()
            End If
        End Using
    End Sub
End Class