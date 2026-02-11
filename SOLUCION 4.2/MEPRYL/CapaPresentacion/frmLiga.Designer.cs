namespace CapaPresentacion
{
    partial class frmLiga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLiga));
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
            this.botonCargar = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnLlamaLiga = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.panDerecha.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panCentro.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).BeginInit();
            this.gbDatosPersonales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SkyBlue;
            this.lbTitulo.Size = new System.Drawing.Size(43, 19);
            this.lbTitulo.Text = "Liga";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SkyBlue;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(634, 0);
            this.pictureBox2.Size = new System.Drawing.Size(47, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(558, 328);
            // 
            // panDerecha
            // 
            this.panDerecha.Controls.Add(this.btnLlamaLiga);
            this.panDerecha.Location = new System.Drawing.Point(558, 139);
            this.panDerecha.Size = new System.Drawing.Size(126, 353);
            this.panDerecha.Controls.SetChildIndex(this.btnLlamaLiga, 0);
            this.panDerecha.Controls.SetChildIndex(this.butModificar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAgregar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butEliminar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAceptar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butCancelar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butOk, 0);
            // 
            // panAbajo
            // 
            this.panAbajo.Location = new System.Drawing.Point(0, 383);
            this.panAbajo.Size = new System.Drawing.Size(681, 28);
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(558, 328);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbDatosPersonales);
            this.tabPage1.Size = new System.Drawing.Size(550, 299);
            this.tabPage1.Controls.SetChildIndex(this.label1, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbCodigo, 0);
            this.tabPage1.Controls.SetChildIndex(this.butBuscar, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbId, 0);
            this.tabPage1.Controls.SetChildIndex(this.gbDatosPersonales, 0);
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(555, 0);
            // 
            // rbcMenu
            // 
            this.rbcMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
            // 
            // 
            // 
            this.rbcMenu.ExpandCollapseItem.Id = 0;
            this.rbcMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            ((DevExpress.XtraBars.BarItem)(this.rbcMenu.ExpandCollapseItem)),
            ((DevExpress.XtraBars.BarItem)(this.bbiAgregarClub)),
            ((DevExpress.XtraBars.BarItem)(this.bbiBuscarPaciente)),
            ((DevExpress.XtraBars.BarItem)(this.bbiImprimir)),
            ((DevExpress.XtraBars.BarItem)(this.bbiEnviarCorreo)),
            ((DevExpress.XtraBars.BarItem)(this.bbiCambiarClub)),
            ((DevExpress.XtraBars.BarItem)(this.bbiUbicarConsolidado))});
            this.rbcMenu.Location = new System.Drawing.Point(0, 0);
            this.rbcMenu.MaxItemId = 7;
            this.rbcMenu.Name = "rbcMenu";
            this.rbcMenu.Size = new System.Drawing.Size(684, 139);
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
            this.gbDatosPersonales.Controls.Add(this.botonCargar);
            this.gbDatosPersonales.Controls.Add(this.pictureBox);
            this.gbDatosPersonales.Controls.Add(this.label2);
            this.gbDatosPersonales.Controls.Add(this.tbDescripcion);
            this.gbDatosPersonales.Location = new System.Drawing.Point(18, 76);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(374, 187);
            this.gbDatosPersonales.TabIndex = 41;
            this.gbDatosPersonales.TabStop = false;
            // 
            // botonCargar
            // 
            this.botonCargar.Location = new System.Drawing.Point(165, 159);
            this.botonCargar.Name = "botonCargar";
            this.botonCargar.Size = new System.Drawing.Size(34, 23);
            this.botonCargar.TabIndex = 2;
            this.botonCargar.Text = "...";
            this.botonCargar.UseVisualStyleBackColor = true;
            this.botonCargar.Click += new System.EventHandler(this.botonCargar_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(11, 62);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(147, 119);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion.Location = new System.Drawing.Point(11, 35);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(188, 20);
            this.tbDescripcion.TabIndex = 0;
            // 
            // btnLlamaLiga
            // 
            this.btnLlamaLiga.Location = new System.Drawing.Point(25, 302);
            this.btnLlamaLiga.Name = "btnLlamaLiga";
            this.btnLlamaLiga.Size = new System.Drawing.Size(75, 23);
            this.btnLlamaLiga.TabIndex = 7;
            this.btnLlamaLiga.Text = "button1";
            this.btnLlamaLiga.UseVisualStyleBackColor = true;
            this.btnLlamaLiga.Click += new System.EventHandler(this.btnLlamaLiga_Click);
            // 
            // frmLiga
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(684, 492);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Default;
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmLiga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liga";
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosPersonales;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button botonCargar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnLlamaLiga;
        private DevExpress.XtraBars.Ribbon.RibbonControl rbcMenu;
        private DevExpress.XtraBars.BarButtonItem bbiAgregarClub;
        private DevExpress.XtraBars.BarButtonItem bbiBuscarPaciente;
        private DevExpress.XtraBars.BarButtonItem bbiImprimir;
        private DevExpress.XtraBars.BarButtonItem bbiEnviarCorreo;
        private DevExpress.XtraBars.BarButtonItem bbiCambiarClub;
        private DevExpress.XtraBars.BarButtonItem bbiUbicarConsolidado;
    }
}
