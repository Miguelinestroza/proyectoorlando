Imports System.Data.SqlClient
Public Class frmAgregarProfeciones
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox2.Text) And String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Por favor, llene todos los campos del formulario antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            conect()
            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            Try
                Dim consulta As String = "INSERT INTO Profeciones (Codigo,Nombre) VALUES (@codigo,@nombre)"
                comando = New SqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@codigo", TextBox1.Text)
                comando.Parameters.AddWithValue("@nombre", TextBox2.Text)
                comando.ExecuteNonQuery()
                MessageBox.Show("Datos guardados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCampos()
            Catch ex As Exception
                MessageBox.Show("Error al guardar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        End If
    End Sub
    Private Sub LimpiarCampos()
        TextBox2.Clear()
        TextBox1.Clear()
        TextBox1.Focus()
    End Sub
End Class