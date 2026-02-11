namespace CapaPresentacion
{
    partial class frmBusquedaEmpresa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaEmpresa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.botonLaboratorio = new System.Windows.Forms.Panel();
            this.botFiltrar = new System.Windows.Forms.Button();
            this.tbFiltro = new System.Windows.Forms.ComboBox();
            this.botLimpiar = new System.Windows.Forms.Button();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.botImprimirListado = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.botVerDatos = new System.Windows.Forms.Button();
            this.botModificar = new System.Windows.Forms.Button();
            this.botEliminar = new System.Windows.Forms.Button();
            this.botAgregar = new System.Windows.Forms.Button();
            this.rbcMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiAgregarEmpresa = new DevExpress.XtraBars.BarButtonItem();
            this.bbiModificarEmpresa = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEliminarEmpresa = new DevExpress.XtraBars.BarButtonItem();
            this.bbiVerDatos = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFactAbonos = new System.Windows.Forms.Button();
            this.dgv01 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.botonLaboratorio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv01)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SeaGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 139);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1171, 25);
            this.lbTitulo.TabIndex = 128;
            this.lbTitulo.Text = "   Empresas Asociadas";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Location = new System.Drawing.Point(31, 299);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(81, 85);
            this.dgv.TabIndex = 129;
            this.dgv.Visible = false;
            // 
            // botonLaboratorio
            // 
            this.botonLaboratorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.botonLaboratorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.botonLaboratorio.Controls.Add(this.botFiltrar);
            this.botonLaboratorio.Controls.Add(this.tbFiltro);
            this.botonLaboratorio.Controls.Add(this.botLimpiar);
            this.botonLaboratorio.Controls.Add(this.cboFiltro);
            this.botonLaboratorio.Controls.Add(this.label15);
            this.botonLaboratorio.Controls.Add(this.botImprimirListado);
            this.botonLaboratorio.Dock = System.Windows.Forms.DockStyle.Top;
            this.botonLaboratorio.Location = new System.Drawing.Point(0, 164);
            this.botonLaboratorio.Name = "botonLaboratorio";
            this.botonLaboratorio.Size = new System.Drawing.Size(1025, 66);
            this.botonLaboratorio.TabIndex = 131;
            // 
            // botFiltrar
            // 
            this.botFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.botFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("botFiltrar.Image")));
            this.botFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botFiltrar.Location = new System.Drawing.Point(555, 14);
            this.botFiltrar.Name = "botFiltrar";
            this.botFiltrar.Size = new System.Drawing.Size(87, 33);
            this.botFiltrar.TabIndex = 434;
            this.botFiltrar.Text = "Buscar";
            this.botFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botFiltrar.UseVisualStyleBackColor = false;
            this.botFiltrar.Click += new System.EventHandler(this.botFiltrar_Click);
            // 
            // tbFiltro
            // 
            this.tbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFiltro.FormattingEnabled = true;
            this.tbFiltro.Location = new System.Drawing.Point(264, 19);
            this.tbFiltro.Name = "tbFiltro";
            this.tbFiltro.Size = new System.Drawing.Size(275, 24);
            this.tbFiltro.TabIndex = 433;
            this.tbFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFiltro_KeyDown);
            // 
            // botLimpiar
            // 
            this.botLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("botLimpiar.Image")));
            this.botLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botLimpiar.Location = new System.Drawing.Point(657, 14);
            this.botLimpiar.Name = "botLimpiar";
            this.botLimpiar.Size = new System.Drawing.Size(87, 33);
            this.botLimpiar.TabIndex = 431;
            this.botLimpiar.Text = "Limpiar";
            this.botLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botLimpiar.UseVisualStyleBackColor = true;
            this.botLimpiar.Click += new System.EventHandler(this.botLimpiar_Click);
            // 
            // cboFiltro
            // 
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Items.AddRange(new object[] {
            "Razon Social",
            "Tipo Documento",
            "Nro. Documento",
            "Tipo Contribuyente",
            "Categoria"});
            this.cboFiltro.Location = new System.Drawing.Point(83, 19);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(164, 24);
            this.cboFiltro.TabIndex = 428;
            this.cboFiltro.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(27, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 16);
            this.label15.TabIndex = 427;
            this.label15.Text = "Buscar";
            // 
            // botImprimirListado
            // 
            this.botImprimirListado.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botImprimirListado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botImprimirListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImprimirListado.Image = ((System.Drawing.Image)(resources.GetObject("botImprimirListado.Image")));
            this.botImprimirListado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botImprimirListado.Location = new System.Drawing.Point(-1, 465);
            this.botImprimirListado.Name = "botImprimirListado";
            this.botImprimirListado.Size = new System.Drawing.Size(182, 55);
            this.botImprimirListado.TabIndex = 137;
            this.botImprimirListado.Text = "Imprimir Listado";
            this.botImprimirListado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botImprimirListado.UseVisualStyleBackColor = true;
            this.botImprimirListado.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(11, 298);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(121, 45);
            this.btnSalir.TabIndex = 432;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Visible = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // botVerDatos
            // 
            this.botVerDatos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botVerDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botVerDatos.Image = ((System.Drawing.Image)(resources.GetObject("botVerDatos.Image")));
            this.botVerDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botVerDatos.Location = new System.Drawing.Point(11, 198);
            this.botVerDatos.Name = "botVerDatos";
            this.botVerDatos.Size = new System.Drawing.Size(121, 45);
            this.botVerDatos.TabIndex = 136;
            this.botVerDatos.Text = "Ver Datos";
            this.botVerDatos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botVerDatos.UseVisualStyleBackColor = true;
            this.botVerDatos.Click += new System.EventHandler(this.botVerDatos_Click);
            // 
            // botModificar
            // 
            this.botModificar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botModificar.Image = ((System.Drawing.Image)(resources.GetObject("botModificar.Image")));
            this.botModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botModificar.Location = new System.Drawing.Point(11, 86);
            this.botModificar.Name = "botModificar";
            this.botModificar.Size = new System.Drawing.Size(121, 45);
            this.botModificar.TabIndex = 135;
            this.botModificar.Text = "Modificar";
            this.botModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botModificar.UseVisualStyleBackColor = true;
            this.botModificar.Click += new System.EventHandler(this.botModificar_Click);
            // 
            // botEliminar
            // 
            this.botEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEliminar.Image = ((System.Drawing.Image)(resources.GetObject("botEliminar.Image")));
            this.botEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEliminar.Location = new System.Drawing.Point(11, 142);
            this.botEliminar.Name = "botEliminar";
            this.botEliminar.Size = new System.Drawing.Size(121, 45);
            this.botEliminar.TabIndex = 134;
            this.botEliminar.Text = "Eliminar";
            this.botEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEliminar.UseVisualStyleBackColor = true;
            this.botEliminar.Click += new System.EventHandler(this.botEliminar_Click);
            // 
            // botAgregar
            // 
            this.botAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAgregar.Image = ((System.Drawing.Image)(resources.GetObject("botAgregar.Image")));
            this.botAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAgregar.Location = new System.Drawing.Point(11, 31);
            this.botAgregar.Name = "botAgregar";
            this.botAgregar.Size = new System.Drawing.Size(121, 45);
            this.botAgregar.TabIndex = 133;
            this.botAgregar.Text = "Agregar";
            this.botAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAgregar.UseVisualStyleBackColor = true;
            this.botAgregar.Click += new System.EventHandler(this.botAgregar_Click);
            // 
            // rbcMenu
            // 
            this.rbcMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
            this.rbcMenu.ExpandCollapseItem.Id = 0;
            this.rbcMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbcMenu.ExpandCollapseItem,
            this.bbiAgregarEmpresa,
            this.bbiModificarEmpresa,
            this.bbiEliminarEmpresa,
            this.bbiVerDatos,
            this.bbiImprimir});
            this.rbcMenu.Location = new System.Drawing.Point(0, 0);
            this.rbcMenu.MaxItemId = 6;
            this.rbcMenu.Name = "rbcMenu";
            this.rbcMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.rbcMenu.Size = new System.Drawing.Size(1171, 139);
            this.rbcMenu.Visible = false;
            // 
            // bbiAgregarEmpresa
            // 
            this.bbiAgregarEmpresa.Caption = "Agregar Empresa";
            this.bbiAgregarEmpresa.Id = 1;
            this.bbiAgregarEmpresa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAgregarEmpresa.ImageOptions.LargeImage")));
            this.bbiAgregarEmpresa.Name = "bbiAgregarEmpresa";
            this.bbiAgregarEmpresa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAgregarEmpresa_ItemClick);
            // 
            // bbiModificarEmpresa
            // 
            this.bbiModificarEmpresa.Caption = "Modificar Empresa";
            this.bbiModificarEmpresa.Id = 2;
            this.bbiModificarEmpresa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiModificarEmpresa.ImageOptions.LargeImage")));
            this.bbiModificarEmpresa.Name = "bbiModificarEmpresa";
            this.bbiModificarEmpresa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiModificarEmpresa_ItemClick);
            // 
            // bbiEliminarEmpresa
            // 
            this.bbiEliminarEmpresa.Caption = "Eliminar Empresa";
            this.bbiEliminarEmpresa.Id = 3;
            this.bbiEliminarEmpresa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiEliminarEmpresa.ImageOptions.LargeImage")));
            this.bbiEliminarEmpresa.Name = "bbiEliminarEmpresa";
            this.bbiEliminarEmpresa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEliminarEmpresa_ItemClick);
            // 
            // bbiVerDatos
            // 
            this.bbiVerDatos.Caption = "Ver Empresa";
            this.bbiVerDatos.Id = 4;
            this.bbiVerDatos.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiVerDatos.ImageOptions.LargeImage")));
            this.bbiVerDatos.Name = "bbiVerDatos";
            this.bbiVerDatos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiVerDatos_ItemClick);
            // 
            // bbiImprimir
            // 
            this.bbiImprimir.Caption = "Imprimir Listado";
            this.bbiImprimir.Id = 5;
            this.bbiImprimir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiImprimir.ImageOptions.LargeImage")));
            this.bbiImprimir.Name = "bbiImprimir";
            this.bbiImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiImprimir_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Configuración";
            this.ribbonPage1.Visible = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiAgregarEmpresa);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiModificarEmpresa);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEliminarEmpresa);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiVerDatos);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiImprimir);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnFactAbonos);
            this.panel1.Controls.Add(this.botModificar);
            this.panel1.Controls.Add(this.botAgregar);
            this.panel1.Controls.Add(this.botEliminar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.botVerDatos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1025, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 422);
            this.panel1.TabIndex = 435;
            // 
            // btnFactAbonos
            // 
            this.btnFactAbonos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFactAbonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFactAbonos.Image = ((System.Drawing.Image)(resources.GetObject("btnFactAbonos.Image")));
            this.btnFactAbonos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFactAbonos.Location = new System.Drawing.Point(11, 249);
            this.btnFactAbonos.Name = "btnFactAbonos";
            this.btnFactAbonos.Size = new System.Drawing.Size(121, 45);
            this.btnFactAbonos.TabIndex = 433;
            this.btnFactAbonos.Text = "Facturacion\r\nAbonos";
            this.btnFactAbonos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFactAbonos.UseVisualStyleBackColor = true;
            // 
            // dgv01
            // 
            this.dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv01.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv01.Location = new System.Drawing.Point(0, 230);
            this.dgv01.Name = "dgv01";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv01.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv01.Size = new System.Drawing.Size(1025, 356);
            this.dgv01.TabIndex = 437;
            this.dgv01.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv01_CellContentDoubleClick);
            // 
            // frmBusquedaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 586);
            this.Controls.Add(this.dgv01);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.botonLaboratorio);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.rbcMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBusquedaEmpresa";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresas Asociadas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBusquedaEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.botonLaboratorio.ResumeLayout(false);
            this.botonLaboratorio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv01)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.DataGridView dgv;
        protected System.Windows.Forms.Panel botonLaboratorio;
        private System.Windows.Forms.Button botAgregar;
        private System.Windows.Forms.Button botVerDatos;
        private System.Windows.Forms.Button botModificar;
        private System.Windows.Forms.Button botEliminar;
        private System.Windows.Forms.Button botImprimirListado;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button botLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox tbFiltro;
        private DevExpress.XtraBars.Ribbon.RibbonControl rbcMenu;
        private DevExpress.XtraBars.BarButtonItem bbiAgregarEmpresa;
        private DevExpress.XtraBars.BarButtonItem bbiModificarEmpresa;
        private DevExpress.XtraBars.BarButtonItem bbiEliminarEmpresa;
        private DevExpress.XtraBars.BarButtonItem bbiVerDatos;
        private DevExpress.XtraBars.BarButtonItem bbiImprimir;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        public System.Windows.Forms.Button botFiltrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv01;
        private System.Windows.Forms.Button btnFactAbonos;
    }
}