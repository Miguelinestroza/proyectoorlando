Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Linq
Public Class frmNuevoTramite
    Public sexo As Char
    ''Carga Y Cierre del formulario Info General
    Private Sub frmNuevoTramite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New SqlConnection("Data Source=CESAR\SQLCREDI;Initial Catalog=SistemaOrlando;Persist Security Info=True;User ID=sa;Password=1625")
        comando = New SqlCommand()
        comando.Connection = conexion
        Try
            conexion.Open()
        Catch ex As Exception
            MessageBox.Show("Error al conectar a la base de datos: " & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToResizeRows = True
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        MaskedTextBox4.Text = DateTime.Now.ToString("dd/MM/yyyy")
        MaskedTextBox2.Text = DateTime.Now.ToString("dd/MM/yyyy")
        fechaPrimerPago()

        If RadioButton1.Checked = True Then
            sexo = "M"
        ElseIf RadioButton2.Checked = True Then
            sexo = "F"
        End If
        DeshabilitarCampos()
        actualizarDataGrid()
    End Sub
    Private Sub frmNuevoTramite_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If conexion IsNot Nothing AndAlso conexion.State = ConnectionState.Open Then
            conexion.Close()
        End If
    End Sub
    ''Funciones para los controles
    Private Sub HabilitarCampos()
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
        TextBox28.Enabled = True
        TextBox29.Enabled = True
        TextBox30.Enabled = True
        TextBox32.Enabled = True
        TextBox24.Enabled = True
        TextBox27.Enabled = True
        TextBox31.Enabled = True
        TextBox33.Enabled = True
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        MaskedTextBox4.Enabled = True
        Button7.Enabled = True
        TextBox16.Enabled = True
        TextBox17.Enabled = True
        TextBox18.Enabled = True
        TextBox19.Enabled = True
        TextBox20.Enabled = True
        TextBox21.Enabled = True
        TextBox23.Enabled = True
        TextBox25.Enabled = True
        TextBox26.Enabled = True
        MaskedTextBox4.Enabled = True
        MaskedTextBox2.Enabled = True
    End Sub
    Private Sub DeshabilitarCampos()
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
        TextBox28.Enabled = False
        TextBox29.Enabled = False
        TextBox30.Enabled = False
        TextBox32.Enabled = False
        TextBox24.Enabled = False
        TextBox27.Enabled = False
        TextBox31.Enabled = False
        TextBox33.Enabled = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        MaskedTextBox4.Enabled = False
        Button7.Enabled = False
        TextBox16.Enabled = False
        TextBox17.Enabled = False
        TextBox18.Enabled = False
        TextBox19.Enabled = False
        TextBox20.Enabled = False
        TextBox21.Enabled = False
        TextBox23.Enabled = False
        TextBox25.Enabled = False
        TextBox26.Enabled = False
        MaskedTextBox4.Enabled = False
        MaskedTextBox2.Enabled = False
    End Sub
    Private Sub Limpiarcampos()
        TextBox2.Clear()
        MaskedTextBox4.Clear()
        MaskedTextBox1.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox28.Clear()
        TextBox29.Clear()
        TextBox30.Clear()
        TextBox32.Clear()
        TextBox24.Clear()
        TextBox27.Clear()
        TextBox31.Clear()
        TextBox33.Clear()
        TextBox16.Text = "0.00"
        TextBox17.Text = "0.00"
        TextBox18.Text = "0.00"
        TextBox19.Text = "42.00"
        TextBox20.Text = 12
        TextBox21.Text = "0.00"
        TextBox23.Text = "0.00"
        TextBox25.Text = "0.00"
        TextBox26.Text = "0.00"
        MaskedTextBox4.Text = DateTime.Now.ToString("dd/MM/yyyy")
        MaskedTextBox2.Text = DateTime.Now.ToString("dd/MM/yyyy")
    End Sub
    Private Sub MostrarCantidadFilas()
        If Not conexion.State = ConnectionState.Open Then
            conect()
        End If
        Dim query As String = "SELECT COUNT(*) FROM clientes;"
        Try
            Using connection As SqlConnection = conexion
                If Not connection.State = ConnectionState.Open Then
                    connection.Open()
                End If
                Using command As New SqlCommand(query, connection)
                    Dim result As Integer = CInt(command.ExecuteScalar())
                    TextBox1.Text = result.ToString()
                End Using
            End Using
            Dim conteo As Integer = CInt(TextBox1.Text) + 1
            TextBox1.Text = conteo.ToString().PadLeft(4, "0"c)
        Catch ex As Exception
        End Try
    End Sub
    ''Busacar
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Button2.Enabled = False
        Dim cargarsexo As String
        If TextBox1.Text.Length = 4 Then
            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            Try
                ''datos del cliente
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

                        ''referencias
                        Dim consulta2 As String = "SELECT * FROM referencias WHERE IDCliente = @IDCliente"
                        Using comando2 As New SqlCommand(consulta2, conexion)
                            comando2.Parameters.AddWithValue("@IDCliente", terminoBusqueda)
                            Dim adaptador2 As New SqlDataAdapter(comando2)
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

                        ''plan de pago
                        Dim consulta3 As String = "SELECT * FROM PlanesDePago WHERE IDCliente = @IDCliente"
                        Using comando3 As New SqlCommand(consulta3, conexion)
                            comando3.Parameters.AddWithValue("@IDCliente", terminoBusqueda)
                            Dim adaptador3 As New SqlDataAdapter(comando3)
                            Dim conjuntoDatos3 As New DataSet()
                            adaptador3.Fill(conjuntoDatos3, "IDCliente")
                            If conjuntoDatos3.Tables("IDCliente").Rows.Count > 0 Then
                                Dim fila3 As DataRow = conjuntoDatos3.Tables("IDCliente").Rows(0)
                                TextBox3.Text = fila3("IDPlanPago").ToString()
                                TextBox21.Text = fila3("papeleria").ToString()
                                TextBox22.Text = fila3("Cuota").ToString()
                                MaskedTextBox2.Text = fila3("FechaDeDesembolso").ToString()
                                TextBox18.Text = fila3("Monto").ToString()
                                TextBox16.Text = fila3("MontoSolicitado").ToString()
                                TextBox17.Text = fila3("Prima").ToString()
                                TextBox19.Text = fila3("InteresAnual").ToString()
                                MaskedTextBox3.Text = fila3("PrimerPago").ToString()
                            End If
                        End Using

                        Button2.Enabled = False
                        Button9.Enabled = True
                        Button8.Enabled = True
                        Button11.Enabled = True
                    Else
                        MessageBox.Show("No se encontró el Cliente especificado.", "No Existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Limpiarcampos()
                        Button2.Enabled = True
                        Button11.Enabled = False
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al buscar el Cliente" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        End If
        actualizarDataGrid()

        If TextBox1.Text = "" Then
            Limpiarcampos()
            Button2.Enabled = True
            Button11.Enabled = False
            Button9.Enabled = False
            Button8.Enabled = False
        End If
    End Sub
    ''Profecion
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Text.Length = 3 Then
            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            Try
                Dim terminoBusqueda As String = TextBox4.Text.Trim()
                Dim consulta As String = "SELECT * FROM Profeciones WHERE Codigo = @Codigo"
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@Codigo", terminoBusqueda)
                    Using adaptador As New SqlDataAdapter(comando)
                        Dim conjuntoDatos As New DataSet()
                        adaptador.Fill(conjuntoDatos, "Codigo")
                        If conjuntoDatos.Tables("Codigo").Rows.Count > 0 Then
                            Dim fila As DataRow = conjuntoDatos.Tables("Codigo").Rows(0)
                            TextBox5.Text = fila("Nombre").ToString()
                        Else
                            MessageBox.Show("No se encontró la Profesión especificada.", "No Existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al buscar la Profesión: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.F1 Then
            e.Handled = True
            e.SuppressKeyPress = True
            MostrarListaProfeciones()
        End If
    End Sub
    Private Sub MostrarListaProfeciones()
        Using listaProfecionesForm As New frmListaProfeciones()
            If listaProfecionesForm.ShowDialog() = DialogResult.OK Then
                TextBox4.Text = listaProfecionesForm.CodigoProfecionSeleccionada
            End If
        End Using
    End Sub
    ''Ocupaciones
    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If TextBox7.Text.Length = 3 Then
            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            Try
                Dim terminoBusqueda As String = TextBox7.Text.Trim()
                Dim consulta As String = "SELECT * FROM Ocupaciones WHERE Codigo = @Codigo"
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@Codigo", terminoBusqueda)
                    Using adaptador As New SqlDataAdapter(comando)
                        Dim conjuntoDatos As New DataSet()
                        adaptador.Fill(conjuntoDatos, "Codigo")
                        If conjuntoDatos.Tables("Codigo").Rows.Count > 0 Then
                            Dim fila As DataRow = conjuntoDatos.Tables("Codigo").Rows(0)
                            TextBox6.Text = fila("Nombre").ToString()
                        Else
                            MessageBox.Show("No se encontró la Ocupación especificada.", "No Existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al buscar la Ocupación: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyDown
        If e.KeyCode = Keys.F1 Then
            e.Handled = True
            e.SuppressKeyPress = True
            MostrarListaOcupaciones()
        End If
    End Sub
    Private Sub MostrarListaOcupaciones()
        Using listaOcupacionesForm As New frmListaOcupaciones()
            If listaOcupacionesForm.ShowDialog() = DialogResult.OK Then
                TextBox7.Text = listaOcupacionesForm.CodigoOcupacionSeleccionada
            End If
        End Using
    End Sub
    ''Departamentos
    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text.Length = 2 Then
            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            Try
                Dim terminoBusqueda As String = TextBox9.Text.Trim()
                Dim consulta As String = "SELECT * FROM Departamentos WHERE Codigo = @Codigo"
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@Codigo", terminoBusqueda)
                    Using adaptador As New SqlDataAdapter(comando)
                        Dim conjuntoDatos As New DataSet()
                        adaptador.Fill(conjuntoDatos, "Codigo")
                        If conjuntoDatos.Tables("Codigo").Rows.Count > 0 Then
                            Dim fila As DataRow = conjuntoDatos.Tables("Codigo").Rows(0)
                            TextBox8.Text = fila("Nombre").ToString()
                        Else
                            MessageBox.Show("No se encontró el Departamento especificado.", "No Existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al buscar el Departamento: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub TextBox9_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox9.KeyDown
        If e.KeyCode = Keys.F1 Then
            e.Handled = True
            e.SuppressKeyPress = True
            MostrarListaDepartamentos()
        End If
    End Sub
    Private Sub MostrarListaDepartamentos()
        Using listaDepartamentoForm As New frmListaDepartamento()
            If listaDepartamentoForm.ShowDialog() = DialogResult.OK Then
                TextBox9.Text = listaDepartamentoForm.CodigoDepartamentoSeleccionada
            End If
        End Using
    End Sub
    ''Municipios
    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        If TextBox11.Text.Length = 2 Then
            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            Try
                Dim terminoBusqueda As String = TextBox11.Text.Trim()
                Dim consulta As String = "SELECT * FROM Ciudades WHERE Codigo = @Codigo"
                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@Codigo", terminoBusqueda)
                    Using adaptador As New SqlDataAdapter(comando)
                        Dim conjuntoDatos As New DataSet()
                        adaptador.Fill(conjuntoDatos, "Codigo")
                        If conjuntoDatos.Tables("Codigo").Rows.Count > 0 Then
                            Dim fila As DataRow = conjuntoDatos.Tables("Codigo").Rows(0)
                            TextBox10.Text = fila("Nombre").ToString()
                        Else
                            MessageBox.Show("No se encontró el Municipio especificado.", "No Existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al buscar el Municipio: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub TextBox11_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox11.KeyDown
        If e.KeyCode = Keys.F1 Then
            e.Handled = True
            e.SuppressKeyPress = True
            MostrarListaCiudades()
        End If
    End Sub
    Private Sub MostrarListaCiudades()
        Using listaCiudadesForm As New frmListaCiudades()
            If listaCiudadesForm.ShowDialog() = DialogResult.OK Then
                TextBox11.Text = listaCiudadesForm.CodigoCiudadesSeleccionada
            End If
        End Using
    End Sub
    ''Guardar 
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ''datos del cliente
        MostrarCantidadFilas()
        TextBox3.Text = TextBox1.Text
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
            Button7.Enabled = True

            ''referencias
            Dim consulta2 As String = "INSERT INTO referencias (IDCliente,	R1Nombre,	R1Parentesco,	R1Direccion,	R1Numero,	R2Nombre,	R2Parentesco,	R2Direccion,	R2Numero) VALUES (@IDCliente,	@R1Nombre,	@R1Parentesco,	@R1Direccion,	@R1Numero,	@R2Nombre,	@R2Parentesco,	@R2Direccion,	@R2Numero)"
            Dim comando2 As New SqlCommand(consulta2, conexion)
            comando2.Parameters.AddWithValue("@IDCliente", TextBox1.Text)
            comando2.Parameters.AddWithValue("@R1Nombre", TextBox32.Text)
            comando2.Parameters.AddWithValue("@R1Parentesco", TextBox30.Text)
            comando2.Parameters.AddWithValue("@R1Direccion", TextBox29.Text)
            comando2.Parameters.AddWithValue("@R1Numero", TextBox28.Text)
            comando2.Parameters.AddWithValue("@R2Nombre", TextBox33.Text)
            comando2.Parameters.AddWithValue("@R2Parentesco", TextBox31.Text)
            comando2.Parameters.AddWithValue("@R2Direccion", TextBox27.Text)
            comando2.Parameters.AddWithValue("@R2Numero", TextBox24.Text)
            comando2.ExecuteNonQuery()

            ''plan de pago
            Dim consulta3 As String = "INSERT INTO PlanesDePago (IDPlanPago,	IDCliente,	Cuota,	FechaDeDesembolso,	Monto,	MontoSolicitado,	Prima,	InteresAnual,	PrimerPago,	papeleria) VALUES (@IDPlanPago,	@IDCliente,	@Cuota,	@FechaDeDesembolso,	@Monto,	@MontoSolicitado,	@Prima,	@InteresAnual,	@PrimerPago,	@papeleria)"
            Dim comando3 As New SqlCommand(consulta3, conexion)
            comando3.Parameters.AddWithValue("@IDPlanPago", TextBox3.Text)
            comando3.Parameters.AddWithValue("@IDCliente", TextBox1.Text)
            comando3.Parameters.AddWithValue("@Cuota", TextBox22.Text)
            comando3.Parameters.AddWithValue("@FechaDeDesembolso", MaskedTextBox2.Text)
            comando3.Parameters.AddWithValue("@Monto", TextBox18.Text)
            comando3.Parameters.AddWithValue("@MontoSolicitado", TextBox16.Text)
            comando3.Parameters.AddWithValue("@Prima", TextBox17.Text)
            comando3.Parameters.AddWithValue("@InteresAnual", TextBox19.Text)
            comando3.Parameters.AddWithValue("@PrimerPago", MaskedTextBox3.Text)
            comando3.Parameters.AddWithValue("@papeleria", TextBox21.Text)
            comando3.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            conexion.Close()
        End Try
        DeshabilitarCampos()
        Button9.Enabled = True
        Button8.Enabled = True
    End Sub
    ''Editar
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ''datos del cliente
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
                End If
            Catch ex As Exception
            Finally
                conexion.Close()
            End Try
        Else
        End If

        ''referencias
        If Not String.IsNullOrEmpty(terminoBusqueda) Then
            Dim consulta2 As String = "UPDATE referencias SET IDCliente = @IDCliente, R1Nombre = @R1Nombre, R1Parentesco = @R1Parentesco, R1Direccion = @R1Direccion, R1Numero = @R1Numero, R2Nombre = @R2Nombre, R2Parentesco = @R2Parentesco, R2Direccion = @R2Direccion, R2Numero = @R2Numero WHERE IDCliente = @IDCliente"
            Try
                If conexion.State = ConnectionState.Closed Then
                    conexion.Open()
                End If
                Dim comando2 As New SqlCommand(consulta2, conexion)
                comando2.Parameters.AddWithValue("@R1Nombre", TextBox32.Text)
                comando2.Parameters.AddWithValue("@R1Parentesco", TextBox30.Text)
                comando2.Parameters.AddWithValue("@R1Direccion", TextBox29.Text)
                comando2.Parameters.AddWithValue("@R1Numero", TextBox28.Text)
                comando2.Parameters.AddWithValue("@R2Nombre", TextBox33.Text)
                comando2.Parameters.AddWithValue("@R2Parentesco", TextBox31.Text)
                comando2.Parameters.AddWithValue("@R2Direccion", TextBox27.Text)
                comando2.Parameters.AddWithValue("@R2Numero", TextBox24.Text)
                comando2.Parameters.AddWithValue("@IDCliente", terminoBusqueda)
                Dim filasAfectadas As Integer = comando2.ExecuteNonQuery()
            Catch ex As Exception
            Finally
                conexion.Close()
            End Try
        Else
        End If

        ''plan de pago
        If Not String.IsNullOrEmpty(terminoBusqueda) Then
            Dim consulta3 As String = "UPDATE PlanesDePago SET IDPlanPago = @IDPlanPago, Cuota = @Cuota, FechaDeDesembolso = @FechaDeDesembolso, Monto = @Monto, MontoSolicitado = @MontoSolicitado, Prima = @Prima, InteresAnual = @InteresAnual, PrimerPago = @PrimerPago, papeleria = @papeleria WHERE IDCliente = @IDCliente"
            Try
                If conexion.State = ConnectionState.Closed Then
                    conexion.Open()
                End If
                Dim comando3 As New SqlCommand(consulta3, conexion)
                comando3.Parameters.AddWithValue("@IDPlanPago", TextBox3.Text)
                comando3.Parameters.AddWithValue("@Cuota", TextBox22.Text)
                comando3.Parameters.AddWithValue("@FechaDeDesembolso", MaskedTextBox2.Text)
                comando3.Parameters.AddWithValue("@Monto", TextBox18.Text)
                comando3.Parameters.AddWithValue("@MontoSolicitado", TextBox16.Text)
                comando3.Parameters.AddWithValue("@Prima", TextBox17.Text)
                comando3.Parameters.AddWithValue("@InteresAnual", TextBox19.Text)
                comando3.Parameters.AddWithValue("@PrimerPago", MaskedTextBox3.Text)
                comando3.Parameters.AddWithValue("@papeleria", TextBox21.Text)
                comando3.Parameters.AddWithValue("@IDCliente", terminoBusqueda)
                Dim filasAfectadas As Integer = comando3.ExecuteNonQuery()
                If filasAfectadas > 0 Then
                Else
                End If
            Catch ex As Exception
            Finally
                conexion.Close()
            End Try
        Else
        End If
        DeshabilitarCampos()
        Button9.Enabled = True
        Button8.Enabled = True
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        HabilitarCampos()
        Button9.Enabled = False
        Button8.Enabled = False
    End Sub
    ''Borrar
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim terminoBusqueda As String = TextBox1.Text.Trim()
        If Not String.IsNullOrEmpty(terminoBusqueda) Then
            Dim respuesta As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar el registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = DialogResult.Yes Then
                Try
                    conect()
                    If conexion.State = ConnectionState.Closed Then
                        conexion.Open()
                    End If
                    ''plan de pago
                    Dim consulta3 As String = "DELETE FROM PlanesDePago WHERE IDCliente = @IDCliente"
                    Dim comando3 As New SqlCommand(consulta3, conexion)
                    comando3.Parameters.AddWithValue("@IDCliente", terminoBusqueda)
                    comando3.ExecuteNonQuery()
                    ''datos del cliente
                    Dim consulta As String = "DELETE FROM Clientes WHERE IDCliente = @IDCliente"
                    Dim comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@IDCliente", terminoBusqueda)
                    comando.ExecuteNonQuery()
                    ''referencias
                    Dim consulta2 As String = "DELETE FROM referencias WHERE IDCliente = @IDCliente"
                    Dim comando2 As New SqlCommand(consulta2, conexion)
                    comando2.Parameters.AddWithValue("@IDCliente", terminoBusqueda)
                    comando2.ExecuteNonQuery()
                    ''estados de cuenta
                    Dim consulta4 As String = "DELETE FROM EstadosDeCuenta WHERE IDCliente = @IDCliente"
                    Dim comando4 As New SqlCommand(consulta4, conexion)
                    comando4.Parameters.AddWithValue("@IDCliente", terminoBusqueda)
                    comando4.ExecuteNonQuery()
                    MessageBox.Show("Registro eliminado exitosamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiarcampos()
                    Button9.Enabled = False
                    Button8.Enabled = False
                    TextBox1.Clear()
                    TextBox1.Focus()
                    Button11.Enabled = False
                Catch ex As Exception
                    MessageBox.Show("Error al intentar eliminar el Registro: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    conexion.Close()
                End Try
            End If
        Else
            MessageBox.Show("Por favor, ingrese un Codigo Valido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        frmImprimirDatosCliente.Show()
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
    End Sub




    ''Plan de pago
    Private Function CalcCuotaMensual(monto As Decimal, tasaInteres As Decimal, plazo As Integer) As Decimal
        Dim cuotaMensual As Decimal
        cuotaMensual = monto * (tasaInteres / (1 - (1 + tasaInteres) ^ -plazo))
        Return cuotaMensual
    End Function
    Private Sub MaskedTextBox3_DoubleClick(sender As Object, e As EventArgs) Handles MaskedTextBox3.DoubleClick
        fechaPrimerPago()
    End Sub
    Private Sub actualizarDataGrid()
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
            tasaInteres = ((Val(TextBox19.Text) / 12) / 4.33) / 100
            dias = 7
            plazo = Val(TextBox20.Text) * 4.33
        End If
        cuotaMensual = CalcCuotaMensual(monto, tasaInteres, plazo)
        Dim saldo As Decimal = monto
        Dim fechaPago As DateTime = MaskedTextBox3.Text
        Dim sumaCapital As Decimal = 0
        Dim sumaInteres As Decimal = 0
        Dim sumaCuotas As Decimal = 0
        DataGridView1.Rows.Clear()
        For i As Integer = 1 To plazo
            Dim interes As Decimal = saldo * tasaInteres
            Dim capital As Decimal = cuotaMensual - interes
            saldo -= capital
            sumaCapital += capital
            sumaInteres += interes
            sumaCuotas += cuotaMensual
            DataGridView1.Rows.Add(i, fechaPago.ToShortDateString(), capital.ToString("0.00"), interes.ToString("0.00"), cuotaMensual.ToString("0.00"), saldo.ToString("0.00"), dias)
            If RadioButton5.Checked = True Then
                fechaPago = fechaPago.AddMonths(1)
            ElseIf RadioButton4.Checked = True Then
                fechaPago = fechaPago.AddDays(15)
            ElseIf RadioButton3.Checked = True Then
                fechaPago = fechaPago.AddDays(7)
            End If
        Next
        TextBox23.Text = sumaCapital.ToString("0.00")
        TextBox25.Text = sumaInteres.ToString("0.00")
        TextBox26.Text = sumaCuotas.ToString("0.00")
        TextBox22.Text = cuotaMensual.ToString("0.00")
    End Sub
    Private Sub fechaPrimerPago()
        Dim PrimerPago As DateTime
        If DateTime.TryParse(MaskedTextBox2.Text, PrimerPago) Then
            Select Case True
                Case RadioButton5.Checked
                    MaskedTextBox3.Text = PrimerPago.AddMonths(1).ToString("dd/MM/yyyy")
                Case RadioButton4.Checked
                    MaskedTextBox3.Text = PrimerPago.AddDays(15).ToString("dd/MM/yyyy")
                Case RadioButton3.Checked
                    MaskedTextBox3.Text = PrimerPago.AddDays(7).ToString("dd/MM/yyyy")
            End Select
        Else
            MessageBox.Show("La fecha ingresada en MaskedTextBox2 no es válida.")
        End If
    End Sub
    ''calculo del saldo que se financiara
    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged
        calcularSaldoAFinanciar()
    End Sub
    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged
        calcularSaldoAFinanciar()
    End Sub
    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged
        calcularSaldoAFinanciar()
    End Sub
    Private Sub calcularSaldoAFinanciar()
        TextBox18.Text = Val(TextBox16.Text) - Val(TextBox17.Text) + Val(TextBox21.Text)
    End Sub
    ''llenado del datagrid cada vez que se medifique un textbox
    Private Sub TextBox16_LostFocus(sender As Object, e As EventArgs) Handles TextBox16.LostFocus
        actualizarDataGrid()
    End Sub

    Private Sub TextBox17_LostFocus(sender As Object, e As EventArgs) Handles TextBox17.LostFocus
        actualizarDataGrid()
    End Sub

    Private Sub TextBox19_LostFocus(sender As Object, e As EventArgs) Handles TextBox19.LostFocus
        actualizarDataGrid()
    End Sub

    Private Sub TextBox20_LostFocus(sender As Object, e As EventArgs) Handles TextBox20.LostFocus
        actualizarDataGrid()
    End Sub

    Private Sub MaskedTextBox2_LostFocus(sender As Object, e As EventArgs) Handles MaskedTextBox2.LostFocus
        actualizarDataGrid()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        actualizarDataGrid()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        actualizarDataGrid()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim terminoBusqueda As String = TextBox1.Text.Trim()
        If Not String.IsNullOrEmpty(terminoBusqueda) Then
            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim numeroCuota As Integer = Convert.ToInt32(row.Cells("Column1").Value)
                Dim fechaPago As Date = Convert.ToDateTime(row.Cells("Column2").Value)
                Dim capitalAbonado As Decimal = Convert.ToDecimal(row.Cells("Column3").Value)
                Dim interesPagado As Decimal = Convert.ToDecimal(row.Cells("Column5").Value)
                Dim cuota As Decimal = Convert.ToDecimal(row.Cells("Column6").Value)
                Dim saldo As Decimal = Convert.ToDecimal(row.Cells("Column7").Value)
                Dim Dias As Decimal = Convert.ToDecimal(row.Cells("Column8").Value)
                Dim pagado As Boolean = False
                Dim query As String = "INSERT INTO EstadosDeCuenta (IDCliente, Numero_Cuota, Fecha_Pago, Capital_Abonado, Interes_Pagado, Cuota, Saldo, Dias, Pagado) VALUES (@IDCliente, @Numero_Cuota, @Fecha_Pago, @Capital_Abonado, @Interes_Pagado, @Cuota, @Saldo, @Dias, @Pagado)"
                Dim command As New SqlCommand(query, conexion)
                command.Parameters.AddWithValue("@Fecha_Pago", fechaPago)
                command.Parameters.AddWithValue("@Capital_Abonado", capitalAbonado)
                command.Parameters.AddWithValue("@Interes_Pagado", interesPagado)
                command.Parameters.AddWithValue("@Cuota", cuota)
                command.Parameters.AddWithValue("@Saldo", saldo)
                command.Parameters.AddWithValue("@Dias", Dias)
                command.Parameters.AddWithValue("@Pagado", pagado)
                command.Parameters.AddWithValue("@IDCliente", terminoBusqueda)
                command.Parameters.AddWithValue("@Numero_Cuota", numeroCuota)
                command.ExecuteNonQuery()
            Next
            conexion.Close()
        Else
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class