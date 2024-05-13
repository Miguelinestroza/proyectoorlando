Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class frmImprimirDatosCliente
    Private filaActual As Integer = 0
    Private totalFilas As Integer
    Private tabla As DataTable
    Private Sub frmImprimirDatosCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = frmNuevoTramite.TextBox1.Text
        Label6.Text = frmNuevoTramite.MaskedTextBox4.Text
        Label5.Text = frmNuevoTramite.TextBox2.Text
        Label10.Text = frmNuevoTramite.MaskedTextBox1.Text
        If frmNuevoTramite.RadioButton1.Checked = True Then
            CheckBox2.Checked = True
            CheckBox1.Checked = False
        ElseIf frmNuevoTramite.RadioButton2.Checked = True Then
            CheckBox1.Checked = True
            CheckBox2.Checked = False
        End If
        Label20.Text = frmNuevoTramite.TextBox13.Text
        Label17.Text = frmNuevoTramite.TextBox12.Text
        Label23.Text = frmNuevoTramite.TextBox10.Text
        Label26.Text = frmNuevoTramite.TextBox8.Text
        Label30.Text = frmNuevoTramite.TextBox5.Text
        Label18.Text = frmNuevoTramite.TextBox6.Text
        Label13.Text = frmNuevoTramite.TextBox14.Text
        Dim VALOR As Double = Double.Parse(frmNuevoTramite.TextBox16.Text)
        Label79.Text = VALOR.ToString("C", New Globalization.CultureInfo("es-HN"))
        Dim PRIMA As Double = Double.Parse(frmNuevoTramite.TextBox17.Text)
        Label73.Text = PRIMA.ToString("C", New Globalization.CultureInfo("es-HN"))
        Dim PAPELERIA As Double = Double.Parse(frmNuevoTramite.TextBox21.Text)
        Label67.Text = PAPELERIA.ToString("C", New Globalization.CultureInfo("es-HN"))
        Dim VALORF As Double = Double.Parse(frmNuevoTramite.TextBox18.Text)
        Label61.Text = VALORF.ToString("C", New Globalization.CultureInfo("es-HN"))
        Dim CUOTA As Double = Double.Parse(frmNuevoTramite.TextBox22.Text)
        Label71.Text = CUOTA.ToString("C", New Globalization.CultureInfo("es-HN"))
        Label58.Text = frmNuevoTramite.TextBox20.Text
        If frmNuevoTramite.RadioButton3.Checked = True Then
            Label59.Text = Val(Label58.Text) * 4.33
            Label64.Text = "Semanal"
        ElseIf frmNuevoTramite.RadioButton4.Checked = True Then
            Label59.Text = Val(Label58.Text) * 2
            Label64.Text = "Quincenal"
        ElseIf frmNuevoTramite.RadioButton5.Checked = True Then
            Label59.Text = Val(Label58.Text) * 1
            Label64.Text = "Mensual"
        End If
        Label34.Text = frmNuevoTramite.TextBox32.Text
        Label37.Text = frmNuevoTramite.TextBox30.Text

        Label43.Text = frmNuevoTramite.TextBox29.Text
        Label40.Text = frmNuevoTramite.TextBox28.Text
        Label55.Text = frmNuevoTramite.TextBox33.Text
        Label52.Text = frmNuevoTramite.TextBox31.Text
        Label49.Text = frmNuevoTramite.TextBox27.Text
        Label46.Text = frmNuevoTramite.TextBox24.Text
    End Sub
    Private Sub OcultarBotones(sender As Object, e As PrintEventArgs)
        Button1.Visible = False
    End Sub
    Private Sub MostrarBotones(sender As Object, e As PrintEventArgs)
        Button1.Visible = True
    End Sub
    Private Sub Imprimirtramites(sender As Object, e As PrintPageEventArgs)
        Dim printArea As New Rectangle(0, 0, Panel1.Width, Panel1.Height)
        Dim bitmap As New Bitmap(Panel1.Width, Panel1.Height)
        Panel1.DrawToBitmap(bitmap, printArea)
        e.Graphics.DrawImage(bitmap, printArea)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim printDocument As New PrintDocument()
        AddHandler printDocument.BeginPrint, AddressOf OcultarBotones
        AddHandler printDocument.PrintPage, AddressOf Imprimirtramites
        AddHandler printDocument.EndPrint, AddressOf MostrarBotones
        Dim printDialog As New PrintDialog()
        printDialog.Document = printDocument
        If printDialog.ShowDialog() = DialogResult.OK Then
            Dim printPreviewDialog As New PrintPreviewDialog()
            printPreviewDialog.Document = printDocument
            printPreviewDialog.ShowDialog()
        End If
    End Sub
End Class