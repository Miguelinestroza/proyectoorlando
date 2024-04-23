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
End Class
