Imports System.Data.SqlClient
Public Class frmListaCiudades
    Public Property CodigoCiudadesSeleccionada As String
        Get
            Return _codigoCiudadesSeleccionada
        End Get
        Set(value As String)
            _codigoCiudadesSeleccionada = value
        End Set
    End Property
    Private _codigoCiudadesSeleccionada As String
    Private Sub frmListaCiudades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatos("Ciudades", DataGridView1)
    End Sub
    Private Sub CargarDatos(tabla As String, dataGridView As DataGridView)
        dataGridView.DataSource = Nothing
        Dim consulta As String = $"select * from {tabla}"
        Try
            conect()
            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If
            Using comando As New SqlCommand(consulta, conexion)
                Using adaptador As New SqlDataAdapter(comando)
                    Dim dataSet As New DataSet()
                    adaptador.Fill(dataSet, tabla)
                    dataGridView.DataSource = dataSet.Tables(tabla)
                    dataGridView.RowHeadersVisible = False
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    dataGridView.AllowUserToResizeRows = True
                    dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub
    Public Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim cellValue As Object = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If cellValue IsNot Nothing AndAlso Not DBNull.Value.Equals(cellValue) Then
                CodigoCiudadesSeleccionada = cellValue.ToString()
                DialogResult = DialogResult.OK
                Close()
            End If
        End If
    End Sub
End Class