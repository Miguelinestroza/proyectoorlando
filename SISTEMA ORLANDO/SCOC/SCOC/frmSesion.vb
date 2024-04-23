Imports System.Data.SqlClient
Public Class frmSesion
    Dim User As String
    Dim Password As String
    Dim categoria As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim query As String = "SELECT * FROM Usuarios WHERE USUARIO=@USUARIO AND CLAVE=@CLAVE"
        Dim cmd As New SqlCommand(query, conexion)
        cmd.Parameters.AddWithValue("@USUARIO", TextBox1.Text)
        cmd.Parameters.AddWithValue("@CLAVE", TextBox2.Text)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Form1.lbUsuario.Text = TextBox1.Text
            Form1.MenuStrip1.Visible = True
            Me.Hide()
        Else
            MsgBox("Usuario o contraseña incorrectos")
        End If
        If ds.Tables(0).Rows.Count > 0 Then
            Dim tipoUsuario As String = ds.Tables(0).Rows(0)("TIPO").ToString()
            Select Case tipoUsuario
                Case "Admin"
                    Form1.ArchivoToolStripMenuItem.Enabled = True
                    Form1.EditarToolStripMenuItem.Enabled = True
                    Form1.HerramientasToolStripMenuItem.Enabled = True
                    Form1.VerEImprimirToolStripMenuItem.Enabled = True
                Case "Usuario"
                    Form1.ArchivoToolStripMenuItem.Enabled = True
                    Form1.EditarToolStripMenuItem.Enabled = False
                    Form1.HerramientasToolStripMenuItem.Enabled = False
                    Form1.VerEImprimirToolStripMenuItem.Enabled = True
                Case "Auditor"
                    Form1.ArchivoToolStripMenuItem.Enabled = True
                    Form1.EditarToolStripMenuItem.Enabled = True
                    Form1.HerramientasToolStripMenuItem.Enabled = False
                    Form1.NuevoTramiteToolStripMenuItem.Enabled = False
                Case Else
                    Form1.ArchivoToolStripMenuItem.Enabled = False
                    Form1.EditarToolStripMenuItem.Enabled = False
                    Form1.HerramientasToolStripMenuItem.Enabled = False
                    Form1.VerEImprimirToolStripMenuItem.Enabled = False
            End Select
            Form1.lbTipo.Text = tipoUsuario
        End If
    End Sub
    Private Sub frmSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conect()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        PictureBox3.Visible = False
        PictureBox3.Enabled = False
        TextBox2.PasswordChar = ""
        PictureBox4.Visible = True
        PictureBox4.Enabled = True
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        PictureBox4.Visible = False
        PictureBox4.Enabled = False
        TextBox2.PasswordChar = "*"
        PictureBox3.Visible = True
        PictureBox3.Enabled = True
    End Sub
    Private Sub frmSesion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        End
    End Sub
End Class