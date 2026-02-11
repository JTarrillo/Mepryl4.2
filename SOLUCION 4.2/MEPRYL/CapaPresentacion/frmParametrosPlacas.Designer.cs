namespace CapaPresentacion
{
    partial class frmParametrosPlacas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametrosPlacas));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.rbcMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiAgregarClub = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBuscarPaciente = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEnviarCorreo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCambiarClub = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUbicarConsolidado = new DevExpress.XtraBars.BarButtonItem();
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSeleccionarTodas = new System.Windows.Forms.CheckBox();
            this.chklbLigas = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCategoriaInicial = new System.Windows.Forms.TextBox();
            this.tb9Categoria = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbRegistrosProcesados = new System.Windows.Forms.Label();
            this.lblProcesando = new System.Windows.Forms.Label();
            this.butImportar = new System.Windows.Forms.Button();
            this.butAbrirArchivo = new System.Windows.Forms.Button();
            this.tbArchivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.panDerecha.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panCentro.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).BeginInit();
            this.gbDatosPersonales.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.Navy;
            this.lbTitulo.Size = new System.Drawing.Size(121, 19);
            this.lbTitulo.Text = "Configuración";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Navy;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(841, 0);
            this.pictureBox2.Size = new System.Drawing.Size(41, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabPage2);
            this.tabPrincipal.Size = new System.Drawing.Size(757, 352);
            this.tabPrincipal.Controls.SetChildIndex(this.tabPage2, 0);
            this.tabPrincipal.Controls.SetChildIndex(this.tabPage1, 0);
            // 
            // panDerecha
            // 
            this.panDerecha.Controls.Add(this.button1);
            this.panDerecha.Location = new System.Drawing.Point(757, 139);
            this.panDerecha.Size = new System.Drawing.Size(128, 377);
            this.panDerecha.Controls.SetChildIndex(this.button1, 0);
            this.panDerecha.Controls.SetChildIndex(this.butModificar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAgregar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butEliminar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAceptar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butCancelar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butOk, 0);
            // 
            // panAbajo
            // 
            this.panAbajo.Location = new System.Drawing.Point(0, 483);
            this.panAbajo.Size = new System.Drawing.Size(882, 30);
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(757, 352);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbDatosPersonales);
            this.tabPage1.Size = new System.Drawing.Size(749, 323);
            this.tabPage1.Text = "Datos Principales RX";
            this.tabPage1.Controls.SetChildIndex(this.gbDatosPersonales, 0);
            this.tabPage1.Controls.SetChildIndex(this.label1, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbCodigo, 0);
            this.tabPage1.Controls.SetChildIndex(this.butBuscar, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbId, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.Text = "Buscar";
            this.label1.Visible = false;
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(754, 0);
            this.butSalir.Size = new System.Drawing.Size(128, 30);
            // 
            // tbCodigo
            // 
            this.tbCodigo.Visible = false;
            // 
            // rbcMenu
            // 
            this.rbcMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
            // 
            // 
            // 
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
            this.rbcMenu.Size = new System.Drawing.Size(885, 139);
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
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.dtpHasta);
            this.gbDatosPersonales.Controls.Add(this.dtpDesde);
            this.gbDatosPersonales.Controls.Add(this.label5);
            this.gbDatosPersonales.Controls.Add(this.chkSeleccionarTodas);
            this.gbDatosPersonales.Controls.Add(this.chklbLigas);
            this.gbDatosPersonales.Controls.Add(this.label2);
            this.gbDatosPersonales.Controls.Add(this.tbCategoriaInicial);
            this.gbDatosPersonales.Controls.Add(this.tb9Categoria);
            this.gbDatosPersonales.Controls.Add(this.label3);
            this.gbDatosPersonales.Controls.Add(this.label6);
            this.gbDatosPersonales.Location = new System.Drawing.Point(2, 69);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(709, 344);
            this.gbDatosPersonales.TabIndex = 39;
            this.gbDatosPersonales.TabStop = false;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(488, 35);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(111, 22);
            this.dtpHasta.TabIndex = 12;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(371, 35);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(111, 22);
            this.dtpDesde.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Último período";
            // 
            // chkSeleccionarTodas
            // 
            this.chkSeleccionarTodas.AutoSize = true;
            this.chkSeleccionarTodas.Location = new System.Drawing.Point(52, 74);
            this.chkSeleccionarTodas.Name = "chkSeleccionarTodas";
            this.chkSeleccionarTodas.Size = new System.Drawing.Size(66, 20);
            this.chkSeleccionarTodas.TabIndex = 8;
            this.chkSeleccionarTodas.Text = "Todas";
            this.chkSeleccionarTodas.UseVisualStyleBackColor = true;
            this.chkSeleccionarTodas.CheckedChanged += new System.EventHandler(this.chkSeleccionarTodas_CheckedChanged);
            // 
            // chklbLigas
            // 
            this.chklbLigas.CheckOnClick = true;
            this.chklbLigas.FormattingEnabled = true;
            this.chklbLigas.Location = new System.Drawing.Point(11, 97);
            this.chklbLigas.Name = "chklbLigas";
            this.chklbLigas.Size = new System.Drawing.Size(679, 242);
            this.chklbLigas.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Categoría Inicial";
            // 
            // tbCategoriaInicial
            // 
            this.tbCategoriaInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCategoriaInicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCategoriaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCategoriaInicial.Location = new System.Drawing.Point(11, 35);
            this.tbCategoriaInicial.Name = "tbCategoriaInicial";
            this.tbCategoriaInicial.Size = new System.Drawing.Size(162, 20);
            this.tbCategoriaInicial.TabIndex = 0;
            // 
            // tb9Categoria
            // 
            this.tb9Categoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb9Categoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb9Categoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb9Categoria.Location = new System.Drawing.Point(177, 35);
            this.tb9Categoria.Name = "tb9Categoria";
            this.tb9Categoria.Size = new System.Drawing.Size(162, 20);
            this.tb9Categoria.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "9° Categoría";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Liga(s)";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.lbRegistrosProcesados);
            this.tabPage2.Controls.Add(this.lblProcesando);
            this.tabPage2.Controls.Add(this.butImportar);
            this.tabPage2.Controls.Add(this.butAbrirArchivo);
            this.tabPage2.Controls.Add(this.tbArchivo);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(749, 414);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Importar Archivo RX";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(532, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(226, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Nombre de la hoja de Excel: DATOS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(324, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(482, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Columnas del archivo: JUGADOR - CATEGORIA - NOMBRE - FECHA - CODIGO";
            // 
            // lbRegistrosProcesados
            // 
            this.lbRegistrosProcesados.AutoSize = true;
            this.lbRegistrosProcesados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegistrosProcesados.Location = new System.Drawing.Point(14, 177);
            this.lbRegistrosProcesados.Name = "lbRegistrosProcesados";
            this.lbRegistrosProcesados.Size = new System.Drawing.Size(0, 18);
            this.lbRegistrosProcesados.TabIndex = 5;
            // 
            // lblProcesando
            // 
            this.lblProcesando.AutoSize = true;
            this.lblProcesando.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesando.Location = new System.Drawing.Point(14, 142);
            this.lblProcesando.Name = "lblProcesando";
            this.lblProcesando.Size = new System.Drawing.Size(0, 24);
            this.lblProcesando.TabIndex = 4;
            // 
            // butImportar
            // 
            this.butImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butImportar.Location = new System.Drawing.Point(293, 225);
            this.butImportar.Name = "butImportar";
            this.butImportar.Size = new System.Drawing.Size(145, 48);
            this.butImportar.TabIndex = 3;
            this.butImportar.Text = "Importar";
            this.butImportar.UseVisualStyleBackColor = true;
            this.butImportar.Click += new System.EventHandler(this.butImportar_Click);
            // 
            // butAbrirArchivo
            // 
            this.butAbrirArchivo.Location = new System.Drawing.Point(647, 83);
            this.butAbrirArchivo.Name = "butAbrirArchivo";
            this.butAbrirArchivo.Size = new System.Drawing.Size(65, 23);
            this.butAbrirArchivo.TabIndex = 2;
            this.butAbrirArchivo.Text = "Examinar";
            this.butAbrirArchivo.UseVisualStyleBackColor = true;
            this.butAbrirArchivo.Click += new System.EventHandler(this.butAbrirArchivo_Click);
            // 
            // tbArchivo
            // 
            this.tbArchivo.Location = new System.Drawing.Point(17, 83);
            this.tbArchivo.Name = "tbArchivo";
            this.tbArchivo.Size = new System.Drawing.Size(624, 22);
            this.tbArchivo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Archivo";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmParametrosPlacas
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(885, 516);
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmParametrosPlacas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Activated += new System.EventHandler(this.frmParametrosPlacas_Activated);
            this.Load += new System.EventHandler(this.frmParametrosPlacas_Load);
            this.Controls.SetChildIndex(this.rbcMenu, 0);
            this.Controls.SetChildIndex(this.panDerecha, 0);
            this.Controls.SetChildIndex(this.panAbajo, 0);
            this.Controls.SetChildIndex(this.panCentro, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.panDerecha.ResumeLayout(false);
            this.panAbajo.ResumeLayout(false);
            this.panAbajo.PerformLayout();
            this.panCentro.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).EndInit();
            this.gbDatosPersonales.ResumeLayout(false);
            this.gbDatosPersonales.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosPersonales;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox tbCategoriaInicial;
        protected System.Windows.Forms.TextBox tb9Categoria;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkSeleccionarTodas;
        private System.Windows.Forms.CheckedListBox chklbLigas;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button butAbrirArchivo;
        private System.Windows.Forms.TextBox tbArchivo;
        private System.Windows.Forms.Button butImportar;
        private System.Windows.Forms.Label lblProcesando;
        private System.Windows.Forms.Label lbRegistrosProcesados;
        protected System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraBars.Ribbon.RibbonControl rbcMenu;
        private DevExpress.XtraBars.BarButtonItem bbiAgregarClub;
        private DevExpress.XtraBars.BarButtonItem bbiBuscarPaciente;
        private DevExpress.XtraBars.BarButtonItem bbiImprimir;
        private DevExpress.XtraBars.BarButtonItem bbiEnviarCorreo;
        private DevExpress.XtraBars.BarButtonItem bbiCambiarClub;
        private DevExpress.XtraBars.BarButtonItem bbiUbicarConsolidado;
    }
}
