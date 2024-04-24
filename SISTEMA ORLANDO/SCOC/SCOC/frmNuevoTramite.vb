﻿Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Linq
Public Class frmNuevoTramite
    Public plaso As Char
    Public sexo As Char
    Private Sub frmNuevoTramite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToResizeRows = True
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        MaskedTextBox4.Text = DateTime.Now.ToString("dd/MM/yyyy")
        MaskedTextBox2.Text = DateTime.Now.ToString("dd/MM/yyyy")
        MaskedTextBox3.Text = DateTime.Now.ToString("dd/MM/yyyy")


        If RadioButton3.Checked = True Then
            plaso = "7"
        ElseIf RadioButton4.Checked = True Then
            plaso = "15"
        ElseIf RadioButton5.Checked = True Then
            plaso = "30"
        End If

        If RadioButton1.Checked = True Then
            sexo = "M"
        ElseIf RadioButton2.Checked = True Then
            sexo = "F"
        End If
        If TextBox1.Text = "" Then
            TextBox2.Enabled = False
            MaskedTextBox1.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox7.Enabled = False
            TextBox8.Enabled = False
            TextBox9.Enabled = False
            TextBox10.Enabled = False
            TextBox11.Enabled = False
            TextBox12.Enabled = False
            TextBox13.Enabled = False
            TextBox14.Enabled = False
            TextBox15.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            MaskedTextBox4.Enabled = False
        End If
    End Sub
    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text.Length = 2 Then
            conect()

            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            Try
                Dim terminoBusqueda As String = TextBox9.Text.Trim()
                Dim consulta As String = "SELECT * FROM Departamentos WHERE Codigo = @Codigo"
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@Codigo", terminoBusqueda)
                    Dim adaptador As New SqlDataAdapter(comando)
                    Dim conjuntoDatos As New DataSet()
                    adaptador.Fill(conjuntoDatos, "Codigo")
                    If conjuntoDatos.Tables("Codigo").Rows.Count > 0 Then
                        Dim fila As DataRow = conjuntoDatos.Tables("Codigo").Rows(0)
                        TextBox8.Text = fila("Nombre").ToString()
                    Else
                        MessageBox.Show("No se encontró el Departamento especificado.", "No Existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al buscar el Departamento: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        Else
        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        If TextBox11.Text.Length = 2 Then
            conect()

            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            Try
                Dim terminoBusqueda As String = TextBox9.Text.Trim() & TextBox11.Text.Trim()
                Dim consulta As String = "SELECT * FROM Ciudades WHERE Codigo = @Codigo"
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@Codigo", terminoBusqueda)
                    Dim adaptador As New SqlDataAdapter(comando)
                    Dim conjuntoDatos As New DataSet()
                    adaptador.Fill(conjuntoDatos, "Codigo")
                    If conjuntoDatos.Tables("Codigo").Rows.Count > 0 Then
                        Dim fila As DataRow = conjuntoDatos.Tables("Codigo").Rows(0)
                        TextBox10.Text = fila("Nombre").ToString()
                    Else
                        MessageBox.Show("No se encontró el Municipio especificado.", "No Existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al buscar el Municipio: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        Else
        End If
    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged
        TextBox18.Text = Val(TextBox16.Text) - Val(TextBox17.Text)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = " "
        MaskedTextBox1.Text = 0 - 0 - 0
        TextBox4.Text = " "
        TextBox5.Text = " "
        TextBox6.Text = " "
        TextBox7.Text = " "
        TextBox8.Text = " "
        TextBox9.Text = " "
        TextBox10.Text = " "
        TextBox11.Text = " "
        TextBox12.Text = " "
        TextBox13.Text = " "
        TextBox14.Text = " "
        TextBox15.Text = " "
        MostrarCantidadFilas()
        conect()
        If conexion.State = ConnectionState.Closed Then
            conexion.Open()
        End If
        Try
            Dim consulta As String = "INSERT INTO clientes (IDCliente,	Nombre,	Direccion,	Departamento,	Ciudad,	Telefono,	Sexo,	Fecha,	fechatramite,	Id,	profecion,	ocupacion,	barrio,	observacion,	codigo_departamento,	codigo_municipio,	codigo_profecion,	codigo_ocupacion) VALUES (@IDCliente,	@Nombre,	@Direccion,	@Departamento,	@Ciudad,	@Telefono,	@Sexo,	@Fecha,	GETDATE(),	@Id,	@profecion,	@ocupacion,	@barrio,	@observacion,	@codigo_departamento,	@codigo_municipio,	@codigo_profecion,	@codigo_ocupacion)"
            Dim comando As New SqlCommand(consulta, conexion)
            comando.Parameters.AddWithValue("@IDCliente", TextBox1.Text)
            comando.Parameters.AddWithValue("@Nombre", TextBox2.Text)
            comando.Parameters.AddWithValue("@Direccion", TextBox13.Text)
            comando.Parameters.AddWithValue("@Departamento", TextBox8.Text)
            comando.Parameters.AddWithValue("@Ciudad", TextBox10.Text)
            comando.Parameters.AddWithValue("@Telefono", TextBox14.Text)
            comando.Parameters.AddWithValue("@Sexo", sexo)
            comando.Parameters.AddWithValue("@Fecha", MaskedTextBox4.Text)
            comando.Parameters.AddWithValue("@Id", TextBox6.Text)
            comando.Parameters.AddWithValue("@profecion", TextBox5.Text)
            comando.Parameters.AddWithValue("@ocupacion", TextBox6.Text)
            comando.Parameters.AddWithValue("@barrio", TextBox12.Text)
            comando.Parameters.AddWithValue("@observacion", TextBox15.Text)
            comando.Parameters.AddWithValue("@codigo_departamento", TextBox9.Text)
            comando.Parameters.AddWithValue("@codigo_municipio", TextBox11.Text)
            comando.Parameters.AddWithValue("@codigo_profecion", TextBox4.Text)
            comando.Parameters.AddWithValue("@codigo_ocupacion", TextBox7.Text)
            comando.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            conexion.Close()
        End Try
    End Sub
    Private Sub MostrarCantidadFilas()
        conect()
        Dim query As String = "SELECT COUNT(*) FROM clientes;"

        Using connection As SqlConnection = conexion
            connection.Open()
            Using command As New SqlCommand(query, connection)
                Dim result As Integer = CInt(command.ExecuteScalar())
                TextBox1.Text = result.ToString()
            End Using
        End Using
        Dim conteo As Integer = CInt(TextBox1.Text) + 1
        TextBox1.Text = conteo.ToString().PadLeft(4, "0"c)
    End Sub
    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        Dim cargarsexo As String
        If TextBox1.Text.Length = 4 Then
            conect()
            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            Try
                Dim terminoBusqueda As String = TextBox1.Text.Trim()
                Dim consulta As String = "SELECT * FROM Clientes WHERE IDCliente = @IDCliente"
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@IDCliente", terminoBusqueda)
                    Dim adaptador As New SqlDataAdapter(comando)
                    Dim conjuntoDatos As New DataSet()
                    adaptador.Fill(conjuntoDatos, "IDCliente")
                    If conjuntoDatos.Tables("IDCliente").Rows.Count > 0 Then
                        Dim fila As DataRow = conjuntoDatos.Tables("IDCliente").Rows(0)
                        TextBox2.Text = fila("Nombre").ToString()
                        TextBox13.Text = fila("Direccion").ToString()
                        TextBox9.Text = fila("codigo_departamento").ToString()
                        TextBox11.Text = fila("codigo_municipio").ToString()
                        TextBox14.Text = fila("telefono").ToString()
                        cargarsexo = fila("sexo").ToString()
                        Select Case cargarsexo
                            Case "M"
                                RadioButton1.Checked = True
                                RadioButton2.Checked = False
                            Case "F"
                                RadioButton2.Checked = True
                                RadioButton1.Checked = False
                        End Select
                        MaskedTextBox4.Text = fila("fecha").ToString()
                        MaskedTextBox1.Text = fila("Id").ToString()
                        TextBox4.Text = fila("codigo_profecion").ToString()
                        TextBox7.Text = fila("codigo_ocupacion").ToString()
                        TextBox12.Text = fila("barrio").ToString()
                        TextBox15.Text = fila("observacion").ToString()
                        Button2.Enabled = False
                    Else
                        Dim respuesta As DialogResult = MessageBox.Show("No se encontró el Cliente especificado. ¿Desea crear uno nuevo?", "No Existe", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If respuesta = DialogResult.Yes Then
                            Button2.Enabled = True
                        Else
                        End If
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al buscar el Cliente" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        Else
        End If
        If TextBox1.Text <> "" Then
            TextBox2.Enabled = True
            MaskedTextBox1.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox7.Enabled = True
            TextBox8.Enabled = False
            TextBox9.Enabled = True
            TextBox10.Enabled = False
            TextBox11.Enabled = True
            TextBox12.Enabled = True
            TextBox13.Enabled = True
            TextBox14.Enabled = True
            TextBox15.Enabled = True
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
            MaskedTextBox4.Enabled = True
            Button7.Enabled = True
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim terminoBusqueda As String = TextBox1.Text.Trim()
        If Not String.IsNullOrEmpty(terminoBusqueda) Then
            Dim consulta As String = "UPDATE Clientes SET IDCliente = @IDCliente, Nombre = @Nombre, Direccion = @Direccion, Departamento = @Departamento, Ciudad = @Ciudad, Telefono = @Telefono, Sexo = @Sexo, Fecha = @Fecha, Id = @Id, profecion = @profecion, ocupacion = @ocupacion, barrio = @barrio, observacion = @observacion, codigo_departamento = @codigo_departamento, codigo_municipio = @codigo_municipio, codigo_profecion = @codigo_profecion, codigo_ocupacion = @codigo_ocupacion WHERE IDCliente = @IDCliente"
            Try
                If conexion.State = ConnectionState.Closed Then
                    conexion.Open()
                End If
                Dim comando As New SqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@Nombre", TextBox2.Text)
                comando.Parameters.AddWithValue("@Direccion", TextBox13.Text)
                comando.Parameters.AddWithValue("@Departamento", TextBox8.Text)
                comando.Parameters.AddWithValue("@Ciudad", TextBox10.Text)
                comando.Parameters.AddWithValue("@Telefono", TextBox14.Text)
                comando.Parameters.AddWithValue("@Sexo", sexo)
                comando.Parameters.AddWithValue("@Fecha", MaskedTextBox4.Text)
                comando.Parameters.AddWithValue("@Id", MaskedTextBox1.Text)
                comando.Parameters.AddWithValue("@profecion", TextBox5.Text)
                comando.Parameters.AddWithValue("@ocupacion", TextBox6.Text)
                comando.Parameters.AddWithValue("@barrio", TextBox12.Text)
                comando.Parameters.AddWithValue("@observacion", TextBox15.Text)
                comando.Parameters.AddWithValue("@codigo_departamento", TextBox9.Text)
                comando.Parameters.AddWithValue("@codigo_municipio", TextBox11.Text)
                comando.Parameters.AddWithValue("@codigo_profecion", TextBox4.Text)
                comando.Parameters.AddWithValue("@codigo_ocupacion", TextBox7.Text)
                comando.Parameters.AddWithValue("@IDCliente", terminoBusqueda)
                Dim filasAfectadas As Integer = comando.ExecuteNonQuery()
                If filasAfectadas > 0 Then
                Else
                    MessageBox.Show("No se encontró el Cliente especificado.", "No Existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("Error al intentar actualizar el registro: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        Else
            MessageBox.Show("Por favor, ingrese Numero de Expediene.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Text.Length = 3 Then
            conect()

            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            Try
                Dim terminoBusqueda As String = TextBox4.Text.Trim()
                Dim consulta As String = "SELECT * FROM Profeciones WHERE Codigo = @Codigo"
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@Codigo", terminoBusqueda)
                    Dim adaptador As New SqlDataAdapter(comando)
                    Dim conjuntoDatos As New DataSet()
                    adaptador.Fill(conjuntoDatos, "Codigo")
                    If conjuntoDatos.Tables("Codigo").Rows.Count > 0 Then
                        Dim fila As DataRow = conjuntoDatos.Tables("Codigo").Rows(0)
                        TextBox5.Text = fila("Nombre").ToString()
                    Else
                        MessageBox.Show("No se encontró el Departamento especificado.", "No Existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al buscar el Departamento: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        Else
        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If TextBox7.Text.Length = 3 Then
            conect()

            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            Try
                Dim terminoBusqueda As String = TextBox7.Text.Trim()
                Dim consulta As String = "SELECT * FROM Ocupaciones WHERE Codigo = @Codigo"
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@Codigo", terminoBusqueda)
                    Dim adaptador As New SqlDataAdapter(comando)
                    Dim conjuntoDatos As New DataSet()
                    adaptador.Fill(conjuntoDatos, "Codigo")
                    If conjuntoDatos.Tables("Codigo").Rows.Count > 0 Then
                        Dim fila As DataRow = conjuntoDatos.Tables("Codigo").Rows(0)
                        TextBox6.Text = fila("Nombre").ToString()
                    Else
                        MessageBox.Show("No se encontró el Departamento especificado.", "No Existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al buscar el Departamento: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        Else
        End If
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        ' Obtener los datos del préstamo
        Dim monto As Decimal = Decimal.Parse(TextBox18.Text)
        Dim tasaInteres As Decimal
        Dim plazo As Integer
        Dim cuotaMensual As Decimal
        Dim dias As Integer
        If RadioButton5.Checked = True Then
            tasaInteres = (Val(TextBox19.Text) / 12) / 100
            dias = 30
            plazo = Val(TextBox20.Text) * 1
        ElseIf RadioButton4.Checked = True Then
            tasaInteres = (Val(TextBox19.Text) / 24) / 100
            dias = 15
            plazo = Val(TextBox20.Text) * 2
        ElseIf RadioButton3.Checked = True Then
            tasaInteres = ((Val(TextBox19.Text) / 12) / 4.25) / 100
            dias = 7
            plazo = Val(TextBox20.Text) * 4.25
        End If


        cuotaMensual = CalcCuotaMensual(monto, tasaInteres, plazo)


        Dim saldo As Decimal = monto
        Dim fechaPago As DateTime = MaskedTextBox3.Text

        DataGridView1.Rows.Clear()
        For i As Integer = 1 To plazo
            Dim interes As Decimal = saldo * tasaInteres
            Dim capital As Decimal = cuotaMensual - interes
            saldo -= capital
            DataGridView1.Rows.Add(i, fechaPago.ToShortDateString(), capital.ToString("0.00"), interes.ToString("0.00"), cuotaMensual.ToString("0.00"), saldo.ToString("0.00"), dias)
            If RadioButton5.Checked = True Then
                fechaPago = fechaPago.AddMonths(1)
            ElseIf RadioButton4.Checked = True Then
                fechaPago = fechaPago.AddDays(15)
            ElseIf RadioButton3.Checked = True Then
                fechaPago = fechaPago.AddDays(7)
            End If
        Next
    End Sub
    Private Function CalcCuotaMensual(monto As Decimal, tasaInteres As Decimal, plazo As Integer) As Decimal
        Dim cuotaMensual As Decimal
        cuotaMensual = monto * (tasaInteres / (1 - (1 + tasaInteres) ^ -plazo))
        Return cuotaMensual
    End Function
    Private Sub MaskedTextBox3_DoubleClick(sender As Object, e As EventArgs) Handles MaskedTextBox3.DoubleClick
        Dim fechaPago As DateTime
        If DateTime.TryParse(MaskedTextBox2.Text, fechaPago) Then
            Select Case True
                Case RadioButton5.Checked
                    MaskedTextBox3.Text = fechaPago.AddMonths(1).ToString("dd/MM/yyyy")
                Case RadioButton4.Checked
                    MaskedTextBox3.Text = fechaPago.AddDays(15).ToString("dd/MM/yyyy")
                Case RadioButton3.Checked
                    MaskedTextBox3.Text = fechaPago.AddDays(7).ToString("dd/MM/yyyy")
            End Select
        Else
            MessageBox.Show("La fecha ingresada en MaskedTextBox2 no es válida.")
        End If
    End Sub
End Class