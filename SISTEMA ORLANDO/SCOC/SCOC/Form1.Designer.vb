<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoTramiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerEImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerEstadoDeLosTramitesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerListaDeExpedientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeshacerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SeleccionartodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HerramientasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonalizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListaDeUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSesionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbTipo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.VerEImprimirToolStripMenuItem, Me.EditarToolStripMenuItem, Me.HerramientasToolStripMenuItem, Me.CerrarSesionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(724, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoTramiteToolStripMenuItem, Me.ToolStripSeparator2, Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'NuevoTramiteToolStripMenuItem
        '
        Me.NuevoTramiteToolStripMenuItem.Image = CType(resources.GetObject("NuevoTramiteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NuevoTramiteToolStripMenuItem.Name = "NuevoTramiteToolStripMenuItem"
        Me.NuevoTramiteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NuevoTramiteToolStripMenuItem.Text = "&Nuevo Tramite"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(162, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = CType(resources.GetObject("SalirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'VerEImprimirToolStripMenuItem
        '
        Me.VerEImprimirToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerEstadoDeLosTramitesToolStripMenuItem, Me.VerListaDeExpedientesToolStripMenuItem})
        Me.VerEImprimirToolStripMenuItem.Name = "VerEImprimirToolStripMenuItem"
        Me.VerEImprimirToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.VerEImprimirToolStripMenuItem.Text = "&Ver/Imprimir"
        '
        'VerEstadoDeLosTramitesToolStripMenuItem
        '
        Me.VerEstadoDeLosTramitesToolStripMenuItem.Image = CType(resources.GetObject("VerEstadoDeLosTramitesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.VerEstadoDeLosTramitesToolStripMenuItem.Name = "VerEstadoDeLosTramitesToolStripMenuItem"
        Me.VerEstadoDeLosTramitesToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.VerEstadoDeLosTramitesToolStripMenuItem.Text = "&Ver estado de los tramites"
        '
        'VerListaDeExpedientesToolStripMenuItem
        '
        Me.VerListaDeExpedientesToolStripMenuItem.Image = CType(resources.GetObject("VerListaDeExpedientesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.VerListaDeExpedientesToolStripMenuItem.Name = "VerListaDeExpedientesToolStripMenuItem"
        Me.VerListaDeExpedientesToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.VerListaDeExpedientesToolStripMenuItem.Text = "&Ver Lista De Clientes"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeshacerToolStripMenuItem, Me.ToolStripSeparator1, Me.SeleccionartodoToolStripMenuItem})
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.EditarToolStripMenuItem.Text = "&Editar"
        '
        'DeshacerToolStripMenuItem
        '
        Me.DeshacerToolStripMenuItem.Name = "DeshacerToolStripMenuItem"
        Me.DeshacerToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.DeshacerToolStripMenuItem.Text = "&Agregar Profeciones"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(237, 6)
        '
        'SeleccionartodoToolStripMenuItem
        '
        Me.SeleccionartodoToolStripMenuItem.Name = "SeleccionartodoToolStripMenuItem"
        Me.SeleccionartodoToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.SeleccionartodoToolStripMenuItem.Text = "&Agregar Ocupaciones"
        '
        'HerramientasToolStripMenuItem
        '
        Me.HerramientasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PersonalizarToolStripMenuItem})
        Me.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem"
        Me.HerramientasToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.HerramientasToolStripMenuItem.Text = "&Herramientas"
        '
        'PersonalizarToolStripMenuItem
        '
        Me.PersonalizarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarUsuariosToolStripMenuItem, Me.EditarUsuariosToolStripMenuItem, Me.EliminarUsuariosToolStripMenuItem, Me.ListaDeUsuariosToolStripMenuItem})
        Me.PersonalizarToolStripMenuItem.Name = "PersonalizarToolStripMenuItem"
        Me.PersonalizarToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PersonalizarToolStripMenuItem.Text = "&Personalizar"
        '
        'AgregarUsuariosToolStripMenuItem
        '
        Me.AgregarUsuariosToolStripMenuItem.Name = "AgregarUsuariosToolStripMenuItem"
        Me.AgregarUsuariosToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.AgregarUsuariosToolStripMenuItem.Text = "&Agregar Usuarios"
        '
        'EditarUsuariosToolStripMenuItem
        '
        Me.EditarUsuariosToolStripMenuItem.Name = "EditarUsuariosToolStripMenuItem"
        Me.EditarUsuariosToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.EditarUsuariosToolStripMenuItem.Text = "&Editar Usuarios"
        '
        'EliminarUsuariosToolStripMenuItem
        '
        Me.EliminarUsuariosToolStripMenuItem.Name = "EliminarUsuariosToolStripMenuItem"
        Me.EliminarUsuariosToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.EliminarUsuariosToolStripMenuItem.Text = "&Eliminar Usuarios"
        '
        'ListaDeUsuariosToolStripMenuItem
        '
        Me.ListaDeUsuariosToolStripMenuItem.Name = "ListaDeUsuariosToolStripMenuItem"
        Me.ListaDeUsuariosToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ListaDeUsuariosToolStripMenuItem.Text = "&Lista de Usuarios"
        '
        'CerrarSesionToolStripMenuItem
        '
        Me.CerrarSesionToolStripMenuItem.Name = "CerrarSesionToolStripMenuItem"
        Me.CerrarSesionToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.CerrarSesionToolStripMenuItem.Text = "&Cerrar Sesion"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lbUsuario, Me.ToolStripStatusLabel2, Me.lbTipo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 239)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.Size = New System.Drawing.Size(394, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        Me.StatusStrip1.Visible = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(53, 17)
        Me.ToolStripStatusLabel1.Text = "Usuario: "
        '
        'lbUsuario
        '
        Me.lbUsuario.Name = "lbUsuario"
        Me.lbUsuario.Size = New System.Drawing.Size(13, 17)
        Me.lbUsuario.Text = "0"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(92, 17)
        Me.ToolStripStatusLabel2.Text = "Tipo de Usuario:"
        '
        'lbTipo
        '
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(13, 17)
        Me.lbTipo.Text = "0"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(724, 583)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevoTramiteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerEImprimirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerEstadoDeLosTramitesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerListaDeExpedientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeshacerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SeleccionartodoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HerramientasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PersonalizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgregarUsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarUsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarUsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListaDeUsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CerrarSesionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lbUsuario As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents lbTipo As ToolStripStatusLabel
End Class
