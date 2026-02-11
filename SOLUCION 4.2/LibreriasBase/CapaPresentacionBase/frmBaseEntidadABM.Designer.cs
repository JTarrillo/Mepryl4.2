namespace CapaPresentacionBase
{
    partial class frmBaseEntidadABM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseEntidadABM));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.panArriba = new System.Windows.Forms.Panel();
            this.lblEtiqueta = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbEstadoEdicion = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panDerecha = new System.Windows.Forms.Panel();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancelar = new System.Windows.Forms.Button();
            this.butAceptar = new System.Windows.Forms.Button();
            this.butEliminar = new System.Windows.Forms.Button();
            this.butAgregar = new System.Windows.Forms.Button();
            this.butModificar = new System.Windows.Forms.Button();
            this.panAbajo = new System.Windows.Forms.Panel();
            this.butSalir = new System.Windows.Forms.Button();
            this.tbEntidadNombre = new System.Windows.Forms.TextBox();
            this.panIzquierda = new System.Windows.Forms.Panel();
            this.panCentro = new System.Windows.Forms.Panel();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbId = new System.Windows.Forms.TextBox();
            this.butBuscar = new System.Windows.Forms.Button();
            this.tbCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imagenesTab = new System.Windows.Forms.ImageList();
            this.rbcMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiAgregarClub = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBuscarPaciente = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEnviarCorreo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCambiarClub = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUbicarConsolidado = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.panArriba.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panDerecha.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panCentro.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panArriba
            // 
            this.panArriba.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.panArriba.Controls.Add(this.lblEtiqueta);
            this.panArriba.Controls.Add(this.lbTitulo);
            this.panArriba.Controls.Add(this.lbEstadoEdicion);
            this.panArriba.Controls.Add(this.pictureBox2);
            this.panArriba.Dock = System.Windows.Forms.DockStyle.Top;
            this.panArriba.Location = new System.Drawing.Point(0, 139);
            this.panArriba.Name = "panArriba";
            this.panArriba.Size = new System.Drawing.Size(647, 25);
            this.panArriba.TabIndex = 0;
            // 
            // lblEtiqueta
            // 
            this.lblEtiqueta.AutoSize = true;
            this.lblEtiqueta.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblEtiqueta.ForeColor = System.Drawing.Color.White;
            this.lblEtiqueta.Location = new System.Drawing.Point(1, 5);
            this.lblEtiqueta.Name = "lblEtiqueta";
            this.lblEtiqueta.Size = new System.Drawing.Size(183, 19);
            this.lblEtiqueta.TabIndex = 125;
            this.lblEtiqueta.Text = "  Paciente Preventiva";
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.BackColor = System.Drawing.Color.Black;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(71, 19);
            this.lbTitulo.TabIndex = 119;
            this.lbTitulo.Text = "Entidad";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTitulo.Visible = false;
            // 
            // lbEstadoEdicion
            // 
            this.lbEstadoEdicion.AutoSize = true;
            this.lbEstadoEdicion.BackColor = System.Drawing.Color.Transparent;
            this.lbEstadoEdicion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbEstadoEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstadoEdicion.ForeColor = System.Drawing.Color.White;
            this.lbEstadoEdicion.Location = new System.Drawing.Point(647, 0);
            this.lbEstadoEdicion.Name = "lbEstadoEdicion";
            this.lbEstadoEdicion.Size = new System.Drawing.Size(0, 25);
            this.lbEstadoEdicion.TabIndex = 124;
            this.lbEstadoEdicion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(773, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 122;
            this.pictureBox2.TabStop = false;
            // 
            // panDerecha
            // 
            this.panDerecha.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panDerecha.Controls.Add(this.butOk);
            this.panDerecha.Controls.Add(this.butCancelar);
            this.panDerecha.Controls.Add(this.butAceptar);
            this.panDerecha.Controls.Add(this.butEliminar);
            this.panDerecha.Controls.Add(this.butAgregar);
            this.panDerecha.Controls.Add(this.butModificar);
            this.panDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.panDerecha.Location = new System.Drawing.Point(647, 139);
            this.panDerecha.Name = "panDerecha";
            this.panDerecha.Size = new System.Drawing.Size(142, 475);
            this.panDerecha.TabIndex = 1;
            // 
            // butOk
            // 
            this.butOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(9, 336);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(120, 45);
            this.butOk.TabIndex = 6;
            this.butOk.Text = "&OK\r\n[F10]";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Visible = false;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            this.butOk.Leave += new System.EventHandler(this.butOk_Leave);
            // 
            // butCancelar
            // 
            this.butCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancelar.Image = ((System.Drawing.Image)(resources.GetObject("butCancelar.Image")));
            this.butCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancelar.Location = new System.Drawing.Point(9, 274);
            this.butCancelar.Name = "butCancelar";
            this.butCancelar.Size = new System.Drawing.Size(120, 45);
            this.butCancelar.TabIndex = 12;
            this.butCancelar.Text = "&Cancelar\r\n[F10]";
            this.butCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancelar.UseVisualStyleBackColor = true;
            this.butCancelar.Click += new System.EventHandler(this.butCancelar_Click);
            // 
            // butAceptar
            // 
            this.butAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAceptar.Image = ((System.Drawing.Image)(resources.GetObject("butAceptar.Image")));
            this.butAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAceptar.Location = new System.Drawing.Point(9, 212);
            this.butAceptar.Name = "butAceptar";
            this.butAceptar.Size = new System.Drawing.Size(120, 45);
            this.butAceptar.TabIndex = 11;
            this.butAceptar.Text = "&Aceptar\r\n[F5]";
            this.butAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAceptar.UseVisualStyleBackColor = true;
            this.butAceptar.Click += new System.EventHandler(this.butAceptar_Click);
            // 
            // butEliminar
            // 
            this.butEliminar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butEliminar.Image = ((System.Drawing.Image)(resources.GetObject("butEliminar.Image")));
            this.butEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEliminar.Location = new System.Drawing.Point(9, 150);
            this.butEliminar.Name = "butEliminar";
            this.butEliminar.Size = new System.Drawing.Size(120, 45);
            this.butEliminar.TabIndex = 5;
            this.butEliminar.Text = "&Eliminar";
            this.butEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butEliminar.UseVisualStyleBackColor = true;
            this.butEliminar.Visible = false;
            this.butEliminar.Click += new System.EventHandler(this.butEliminar_Click);
            // 
            // butAgregar
            // 
            this.butAgregar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAgregar.Image = ((System.Drawing.Image)(resources.GetObject("butAgregar.Image")));
            this.butAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAgregar.Location = new System.Drawing.Point(9, 26);
            this.butAgregar.Name = "butAgregar";
            this.butAgregar.Size = new System.Drawing.Size(120, 45);
            this.butAgregar.TabIndex = 3;
            this.butAgregar.Text = "A&gregar";
            this.butAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAgregar.UseVisualStyleBackColor = true;
            this.butAgregar.Visible = false;
            this.butAgregar.Click += new System.EventHandler(this.butAgregar_Click);
            this.butAgregar.Enter += new System.EventHandler(this.butAgregar_Enter);
            // 
            // butModificar
            // 
            this.butModificar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butModificar.Image = ((System.Drawing.Image)(resources.GetObject("butModificar.Image")));
            this.butModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butModificar.Location = new System.Drawing.Point(9, 88);
            this.butModificar.Name = "butModificar";
            this.butModificar.Size = new System.Drawing.Size(120, 45);
            this.butModificar.TabIndex = 4;
            this.butModificar.Text = "&Modificar";
            this.butModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butModificar.UseVisualStyleBackColor = true;
            this.butModificar.Visible = false;
            this.butModificar.Click += new System.EventHandler(this.butModificar_Click);
            // 
            // panAbajo
            // 
            this.panAbajo.Controls.Add(this.butSalir);
            this.panAbajo.Controls.Add(this.tbEntidadNombre);
            this.panAbajo.Location = new System.Drawing.Point(0, 542);
            this.panAbajo.Name = "panAbajo";
            this.panAbajo.Size = new System.Drawing.Size(789, 28);
            this.panAbajo.TabIndex = 1;
            this.panAbajo.Visible = false;
            // 
            // butSalir
            // 
            this.butSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
            this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir.Location = new System.Drawing.Point(663, 0);
            this.butSalir.Name = "butSalir";
            this.butSalir.Size = new System.Drawing.Size(126, 28);
            this.butSalir.TabIndex = 7;
            this.butSalir.Text = "&Salir [Esc]";
            this.butSalir.Visible = false;
            this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // tbEntidadNombre
            // 
            this.tbEntidadNombre.Enabled = false;
            this.tbEntidadNombre.Location = new System.Drawing.Point(454, 6);
            this.tbEntidadNombre.Name = "tbEntidadNombre";
            this.tbEntidadNombre.Size = new System.Drawing.Size(96, 21);
            this.tbEntidadNombre.TabIndex = 6;
            this.tbEntidadNombre.Visible = false;
            // 
            // panIzquierda
            // 
            this.panIzquierda.Location = new System.Drawing.Point(0, 192);
            this.panIzquierda.Name = "panIzquierda";
            this.panIzquierda.Size = new System.Drawing.Size(10, 297);
            this.panIzquierda.TabIndex = 2;
            this.panIzquierda.Visible = false;
            // 
            // panCentro
            // 
            this.panCentro.AutoScroll = true;
            this.panCentro.Controls.Add(this.tabPrincipal);
            this.panCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panCentro.Location = new System.Drawing.Point(0, 164);
            this.panCentro.Name = "panCentro";
            this.panCentro.Size = new System.Drawing.Size(647, 450);
            this.panCentro.TabIndex = 3;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabPage1);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPrincipal.HotTrack = true;
            this.tabPrincipal.ImageList = this.imagenesTab;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(647, 450);
            this.tabPrincipal.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabPage1.Controls.Add(this.tbId);
            this.tabPage1.Controls.Add(this.butBuscar);
            this.tabPage1.Controls.Add(this.tbCodigo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(639, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos Principales";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(479, 0);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(54, 22);
            this.tbId.TabIndex = 7;
            this.tbId.Visible = false;
            // 
            // butBuscar
            // 
            this.butBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.butBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscar.Image = ((System.Drawing.Image)(resources.GetObject("butBuscar.Image")));
            this.butBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscar.Location = new System.Drawing.Point(182, 33);
            this.butBuscar.Name = "butBuscar";
            this.butBuscar.Size = new System.Drawing.Size(147, 21);
            this.butBuscar.TabIndex = 6;
            this.butBuscar.Text = "Buscar [F1]";
            this.butBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBuscar.UseVisualStyleBackColor = false;
            this.butBuscar.Visible = false;
            this.butBuscar.Click += new System.EventHandler(this.butBuscar_Click);
            // 
            // tbCodigo
            // 
            this.tbCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodigo.Location = new System.Drawing.Point(18, 34);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.Size = new System.Drawing.Size(158, 22);
            this.tbCodigo.TabIndex = 0;
            this.tbCodigo.TextChanged += new System.EventHandler(this.tbCodigo_TextChanged);
            this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // imagenesTab
            // 
            this.imagenesTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesTab.ImageStream")));
            this.imagenesTab.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenesTab.Images.SetKeyName(0, "");
            // 
            // rbcMenu
            // 
            this.rbcMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
            this.rbcMenu.ExpandCollapseItem.Id = 0;
            this.rbcMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbcMenu.ExpandCollapseItem,
            this.bbiAgregarClub,
            this.bbiBuscarPaciente,
            this.bbiImprimir,
            this.bbiEnviarCorreo,
            this.bbiCambiarClub,
            this.bbiUbicarConsolidado});
            this.rbcMenu.Location = new System.Drawing.Point(0, 0);
            this.rbcMenu.MaxItemId = 7;
            this.rbcMenu.Name = "rbcMenu";
            this.rbcMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.rbcMenu.Size = new System.Drawing.Size(789, 139);
            // 
            // bbiAgregarClub
            // 
            this.bbiAgregarClub.Caption = "Agregar Club";
            this.bbiAgregarClub.Id = 1;
            this.bbiAgregarClub.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAgregarClub.ImageOptions.Image")));
            this.bbiAgregarClub.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAgregarClub.ImageOptions.LargeImage")));
            this.bbiAgregarClub.Name = "bbiAgregarClub";
            toolTipTitleItem1.Text = "Agregar un club";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Permite agregar un club de futbol a una liga previamente existente.\r\nEsto abre un" +
    "a ventana en la cual podemos “Agregar, modificar o eliminar” un club.\r\n";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.bbiAgregarClub.SuperTip = superToolTip1;
            this.bbiAgregarClub.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAgregarClub_ItemClick);
            // 
            // bbiBuscarPaciente
            // 
            this.bbiBuscarPaciente.Caption = "Buscar Paciente";
            this.bbiBuscarPaciente.Id = 2;
            this.bbiBuscarPaciente.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiBuscarPaciente.ImageOptions.Image")));
            this.bbiBuscarPaciente.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiBuscarPaciente.ImageOptions.LargeImage")));
            this.bbiBuscarPaciente.Name = "bbiBuscarPaciente";
            toolTipTitleItem2.Text = "Buscar paciente de preventiva";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Permite buscar un paciente previamente ingresado por nombre o DNI.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.bbiBuscarPaciente.SuperTip = superToolTip2;
            this.bbiBuscarPaciente.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBuscarPaciente_ItemClick);
            // 
            // bbiImprimir
            // 
            this.bbiImprimir.Caption = "Imprimir Historia";
            this.bbiImprimir.Id = 3;
            this.bbiImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiImprimir.ImageOptions.Image")));
            this.bbiImprimir.Name = "bbiImprimir";
            this.bbiImprimir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiEnviarCorreo
            // 
            this.bbiEnviarCorreo.Caption = "Enviar Correo";
            this.bbiEnviarCorreo.Id = 4;
            this.bbiEnviarCorreo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEnviarCorreo.ImageOptions.Image")));
            this.bbiEnviarCorreo.Name = "bbiEnviarCorreo";
            this.bbiEnviarCorreo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiCambiarClub
            // 
            this.bbiCambiarClub.Caption = "Cambiar Club";
            this.bbiCambiarClub.Id = 5;
            this.bbiCambiarClub.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCambiarClub.ImageOptions.Image")));
            this.bbiCambiarClub.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiCambiarClub.ImageOptions.LargeImage")));
            this.bbiCambiarClub.Name = "bbiCambiarClub";
            this.bbiCambiarClub.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiUbicarConsolidado
            // 
            this.bbiUbicarConsolidado.Caption = "Ubicar Consolidado";
            this.bbiUbicarConsolidado.Id = 6;
            this.bbiUbicarConsolidado.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiUbicarConsolidado.ImageOptions.Image")));
            this.bbiUbicarConsolidado.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiUbicarConsolidado.ImageOptions.LargeImage")));
            this.bbiUbicarConsolidado.Name = "bbiUbicarConsolidado";
            this.bbiUbicarConsolidado.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Paciente Preventiva";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiAgregarClub);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiBuscarPaciente);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiImprimir);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEnviarCorreo);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiCambiarClub);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiUbicarConsolidado);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // frmBaseEntidadABM
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(789, 614);
            this.Controls.Add(this.panCentro);
            this.Controls.Add(this.panIzquierda);
            this.Controls.Add(this.panAbajo);
            this.Controls.Add(this.panArriba);
            this.Controls.Add(this.panDerecha);
            this.Controls.Add(this.rbcMenu);
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmBaseEntidadABM";
            this.ShowIcon = false;
            this.Text = "frmBaseEntidadABM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBaseEntidadABM_FormClosing);
            this.Load += new System.EventHandler(this.frmBaseEntidadABM_Load);
            this.panArriba.ResumeLayout(false);
            this.panArriba.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panDerecha.ResumeLayout(false);
            this.panAbajo.ResumeLayout(false);
            this.panAbajo.PerformLayout();
            this.panCentro.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panArriba;
        private System.Windows.Forms.Panel panIzquierda;
        private System.Windows.Forms.ImageList imagenesTab;
        protected System.Windows.Forms.Label lbTitulo;
        protected System.Windows.Forms.PictureBox pictureBox2;
        protected System.Windows.Forms.TabControl tabPrincipal;
        protected System.Windows.Forms.Button butCancelar;
        protected System.Windows.Forms.Button butAceptar;
        protected System.Windows.Forms.Button butAgregar;
        protected System.Windows.Forms.Button butEliminar;
        protected System.Windows.Forms.Button butModificar;
        protected System.Windows.Forms.TextBox tbEntidadNombre;
        protected System.Windows.Forms.TextBox tbId;
        protected System.Windows.Forms.Panel panDerecha;
        protected System.Windows.Forms.Panel panAbajo;
        protected System.Windows.Forms.Panel panCentro;
        protected System.Windows.Forms.TabPage tabPage1;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button butSalir;
        private System.Windows.Forms.Label lbEstadoEdicion;
        protected System.Windows.Forms.Button butOk;
        protected System.Windows.Forms.Button butBuscar;
        public System.Windows.Forms.TextBox tbCodigo;
        public DevExpress.XtraBars.Ribbon.RibbonControl rbcMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        public DevExpress.XtraBars.BarButtonItem bbiAgregarClub;
        public DevExpress.XtraBars.BarButtonItem bbiBuscarPaciente;
        public DevExpress.XtraBars.BarButtonItem bbiImprimir;
        public DevExpress.XtraBars.BarButtonItem bbiEnviarCorreo;
        public DevExpress.XtraBars.BarButtonItem bbiCambiarClub;
        public DevExpress.XtraBars.BarButtonItem bbiUbicarConsolidado;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.Label lblEtiqueta;
    }
}