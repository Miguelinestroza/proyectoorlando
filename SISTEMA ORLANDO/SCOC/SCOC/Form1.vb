Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmSesion.Show()
        frmSesion.MdiParent = Me
    End Sub

    Private Sub NuevoTramiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoTramiteToolStripMenuItem.Click
        frmNuevoTramite.Show()
        frmNuevoTramite.MdiParent = Me
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub
    Private Sub DeshacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeshacerToolStripMenuItem.Click
        frmAgregarProfeciones.MdiParent = Me
        frmAgregarProfeciones.Show()
    End Sub

    Private Sub SeleccionartodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionartodoToolStripMenuItem.Click
        frmAgregarOcupaciones.MdiParent = Me
        frmAgregarOcupaciones.Show()
    End Sub

    Private Sub PostearPagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PostearPagoToolStripMenuItem.Click
        frmPostearPago.MdiParent = Me
        frmPostearPago.Show()
    End Sub

    Private Sub VerEstadoDeLosTramitesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerEstadoDeLosTramitesToolStripMenuItem.Click
        frmEstadoDeCuenta.MdiParent = Me
        frmEstadoDeCuenta.Show()
    End Sub

    Private Sub VerMoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerMoraToolStripMenuItem.Click
        frmMora.MdiParent = Me
        frmMora.Show()
    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        lbTipo.Text = ""
        lbUsuario.Text = ""
        Dim loginForm As New frmSesion()
        loginForm.Show()
        MenuStrip1.Visible = False
        ArchivoToolStripMenuItem.Enabled = False
        EditarToolStripMenuItem.Enabled = False
        HerramientasToolStripMenuItem.Enabled = False
        StatusStrip1.Visible = False
    End Sub
End Class
