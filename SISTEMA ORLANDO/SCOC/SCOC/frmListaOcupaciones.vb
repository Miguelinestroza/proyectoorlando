Imports System.Data.SqlClient
Public Class frmListaOcupaciones
    Public Property CodigoOcupacionSeleccionada As String
        Get
            Return _codigoOcupacionSeleccionada
        End Get
        Set(value As String)
            _codigoOcupacionSeleccionada = value
        End Set
    End Property
    Private _codigoOcupacionSeleccionada As String
    Private Sub frmListaOcupaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatos("Ocupaciones", DataGridView1)
    End Sub
    Private Sub CargarDatos(tabla As String, dataGridView As DataGridView)
        dataGridView.DataSource = Nothing
        Dim consulta As String = $"select * from {tabla}"
        Try
            conect()
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
        If e.RowIndex >= 0 Then
            CodigoOcupacionSeleccionada = DataGridView1.Rows(e.RowIndex).Cells("Codigo").Value.ToString()
            DialogResult = DialogResult.OK
            Close()
        End If
    End Sub
End Class