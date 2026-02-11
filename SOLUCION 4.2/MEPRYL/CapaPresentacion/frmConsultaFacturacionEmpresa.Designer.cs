namespace CapaPresentacion
{
    partial class frmConsultaFacturacionEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaFacturacionEmpresa));
            this.dtpFechaFactDesde = new System.Windows.Forms.DateTimePicker();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.dtpFechaFactHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFacHasta = new System.Windows.Forms.Label();
            this.btnIgualaFechasFac = new System.Windows.Forms.Button();
            this.btnIgualaFechaAt = new System.Windows.Forms.Button();
            this.dtpFechaAtHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaAtHasta = new System.Windows.Forms.Label();
            this.dtpFechaAtencionDesde = new System.Windows.Forms.DateTimePicker();
            this.rbInformeDetallado = new System.Windows.Forms.RadioButton();
            this.rbInformeResumido = new System.Windows.Forms.RadioButton();
            this.btnIgualaEmpresas = new System.Windows.Forms.Button();
            this.cbEmpresaHasta = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEmpresaDesde = new System.Windows.Forms.ComboBox();
            this.btnFechaFactDesde = new System.Windows.Forms.Button();
            this.btnFechaAtDesde = new System.Windows.Forms.Button();
            this.lblFechaFactDesde = new System.Windows.Forms.Label();
            this.lblFechaAtDesde = new System.Windows.Forms.Label();
            this.botBuscar = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // dtpFechaFactDesde
            // 
            this.dtpFechaFactDesde.CustomFormat = "yyyy";
            this.dtpFechaFactDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpFechaFactDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFactDesde.Location = new System.Drawing.Point(68, 197);
            this.dtpFechaFactDesde.Name = "dtpFechaFactDesde";
            this.dtpFechaFactDesde.Size = new System.Drawing.Size(114, 24);
            this.dtpFechaFactDesde.TabIndex = 197;
            this.dtpFechaFactDesde.Visible = false;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.Red;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(421, 30);
            this.lbTitulo.TabIndex = 194;
            this.lbTitulo.Text = "Consulta de Facturacion por Empresa";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTitulo.Click += new System.EventHandler(this.lbTitulo_Click);
            // 
            // dtpFechaFactHasta
            // 
            this.dtpFechaFactHasta.CustomFormat = "yyyy";
            this.dtpFechaFactHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpFechaFactHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFactHasta.Location = new System.Drawing.Point(68, 276);
            this.dtpFechaFactHasta.Name = "dtpFechaFactHasta";
            this.dtpFechaFactHasta.Size = new System.Drawing.Size(114, 24);
            this.dtpFechaFactHasta.TabIndex = 292;
            this.dtpFechaFactHasta.Visible = false;
            // 
            // lblFechaFacHasta
            // 
            this.lblFechaFacHasta.AutoSize = true;
            this.lblFechaFacHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.lblFechaFacHasta.Location = new System.Drawing.Point(19, 279);
            this.lblFechaFacHasta.Name = "lblFechaFacHasta";
            this.lblFechaFacHasta.Size = new System.Drawing.Size(45, 17);
            this.lblFechaFacHasta.TabIndex = 291;
            this.lblFechaFacHasta.Text = "Hasta";
            this.lblFechaFacHasta.Visible = false;
            // 
            // btnIgualaFechasFac
            // 
            this.btnIgualaFechasFac.BackColor = System.Drawing.SystemColors.Control;
            this.btnIgualaFechasFac.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnIgualaFechasFac.Location = new System.Drawing.Point(22, 227);
            this.btnIgualaFechasFac.Name = "btnIgualaFechasFac";
            this.btnIgualaFechasFac.Size = new System.Drawing.Size(160, 30);
            this.btnIgualaFechasFac.TabIndex = 293;
            this.btnIgualaFechasFac.Text = "Igualar Fecha";
            this.btnIgualaFechasFac.UseVisualStyleBackColor = false;
            this.btnIgualaFechasFac.Visible = false;
            this.btnIgualaFechasFac.Click += new System.EventHandler(this.btnIgualaFechasFac_Click);
            // 
            // btnIgualaFechaAt
            // 
            this.btnIgualaFechaAt.BackColor = System.Drawing.SystemColors.Control;
            this.btnIgualaFechaAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnIgualaFechaAt.Location = new System.Drawing.Point(235, 227);
            this.btnIgualaFechaAt.Name = "btnIgualaFechaAt";
            this.btnIgualaFechaAt.Size = new System.Drawing.Size(168, 30);
            this.btnIgualaFechaAt.TabIndex = 298;
            this.btnIgualaFechaAt.Text = "Igualar Fecha";
            this.btnIgualaFechaAt.UseVisualStyleBackColor = false;
            this.btnIgualaFechaAt.Visible = false;
            this.btnIgualaFechaAt.Click += new System.EventHandler(this.btnIgualaFechaAt_Click);
            // 
            // dtpFechaAtHasta
            // 
            this.dtpFechaAtHasta.CustomFormat = "yyyy";
            this.dtpFechaAtHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpFechaAtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAtHasta.Location = new System.Drawing.Point(289, 276);
            this.dtpFechaAtHasta.Name = "dtpFechaAtHasta";
            this.dtpFechaAtHasta.Size = new System.Drawing.Size(114, 24);
            this.dtpFechaAtHasta.TabIndex = 297;
            this.dtpFechaAtHasta.Visible = false;
            // 
            // lblFechaAtHasta
            // 
            this.lblFechaAtHasta.AutoSize = true;
            this.lblFechaAtHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.lblFechaAtHasta.Location = new System.Drawing.Point(238, 279);
            this.lblFechaAtHasta.Name = "lblFechaAtHasta";
            this.lblFechaAtHasta.Size = new System.Drawing.Size(45, 17);
            this.lblFechaAtHasta.TabIndex = 296;
            this.lblFechaAtHasta.Text = "Hasta";
            this.lblFechaAtHasta.Visible = false;
            // 
            // dtpFechaAtencionDesde
            // 
            this.dtpFechaAtencionDesde.CustomFormat = "yyyy";
            this.dtpFechaAtencionDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpFechaAtencionDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAtencionDesde.Location = new System.Drawing.Point(289, 197);
            this.dtpFechaAtencionDesde.Name = "dtpFechaAtencionDesde";
            this.dtpFechaAtencionDesde.Size = new System.Drawing.Size(114, 24);
            this.dtpFechaAtencionDesde.TabIndex = 295;
            this.dtpFechaAtencionDesde.Visible = false;
            // 
            // rbInformeDetallado
            // 
            this.rbInformeDetallado.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbInformeDetallado.AutoSize = true;
            this.rbInformeDetallado.Location = new System.Drawing.Point(18, 321);
            this.rbInformeDetallado.Name = "rbInformeDetallado";
            this.rbInformeDetallado.Size = new System.Drawing.Size(103, 23);
            this.rbInformeDetallado.TabIndex = 299;
            this.rbInformeDetallado.TabStop = true;
            this.rbInformeDetallado.Text = "Informe Detallado";
            this.rbInformeDetallado.UseVisualStyleBackColor = true;
            this.rbInformeDetallado.CheckedChanged += new System.EventHandler(this.rbInformeDetallado_CheckedChanged);
            // 
            // rbInformeResumido
            // 
            this.rbInformeResumido.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbInformeResumido.AutoSize = true;
            this.rbInformeResumido.Location = new System.Drawing.Point(18, 348);
            this.rbInformeResumido.Name = "rbInformeResumido";
            this.rbInformeResumido.Size = new System.Drawing.Size(104, 23);
            this.rbInformeResumido.TabIndex = 300;
            this.rbInformeResumido.TabStop = true;
            this.rbInformeResumido.Text = "Informe Resumido";
            this.rbInformeResumido.UseVisualStyleBackColor = true;
            // 
            // btnIgualaEmpresas
            // 
            this.btnIgualaEmpresas.BackColor = System.Drawing.SystemColors.Control;
            this.btnIgualaEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnIgualaEmpresas.Location = new System.Drawing.Point(107, 90);
            this.btnIgualaEmpresas.Name = "btnIgualaEmpresas";
            this.btnIgualaEmpresas.Size = new System.Drawing.Size(150, 30);
            this.btnIgualaEmpresas.TabIndex = 290;
            this.btnIgualaEmpresas.Text = "Igualar Empresas";
            this.btnIgualaEmpresas.UseVisualStyleBackColor = false;
            this.btnIgualaEmpresas.Click += new System.EventHandler(this.btnIgualaEmpresas_Click);
            // 
            // cbEmpresaHasta
            // 
            this.cbEmpresaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbEmpresaHasta.FormattingEnabled = true;
            this.cbEmpresaHasta.Location = new System.Drawing.Point(107, 143);
            this.cbEmpresaHasta.Name = "cbEmpresaHasta";
            this.cbEmpresaHasta.Size = new System.Drawing.Size(215, 24);
            this.cbEmpresaHasta.TabIndex = 289;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.label5.Location = new System.Drawing.Point(104, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 288;
            this.label5.Text = "Empresa hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.label1.Location = new System.Drawing.Point(104, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 199;
            this.label1.Text = "Empresa desde:";
            // 
            // cbEmpresaDesde
            // 
            this.cbEmpresaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbEmpresaDesde.FormattingEnabled = true;
            this.cbEmpresaDesde.Location = new System.Drawing.Point(107, 60);
            this.cbEmpresaDesde.Name = "cbEmpresaDesde";
            this.cbEmpresaDesde.Size = new System.Drawing.Size(215, 24);
            this.cbEmpresaDesde.TabIndex = 200;
            this.cbEmpresaDesde.SelectionChangeCommitted += new System.EventHandler(this.cbEmpresas_SelectionChangeCommitted);
            // 
            // btnFechaFactDesde
            // 
            this.btnFechaFactDesde.Location = new System.Drawing.Point(18, 173);
            this.btnFechaFactDesde.Name = "btnFechaFactDesde";
            this.btnFechaFactDesde.Size = new System.Drawing.Size(164, 21);
            this.btnFechaFactDesde.TabIndex = 294;
            this.btnFechaFactDesde.Text = "Por Fecha De Facturacion";
            this.btnFechaFactDesde.UseVisualStyleBackColor = true;
            this.btnFechaFactDesde.Click += new System.EventHandler(this.btnFechaFactDesde_Click);
            // 
            // btnFechaAtDesde
            // 
            this.btnFechaAtDesde.Location = new System.Drawing.Point(235, 173);
            this.btnFechaAtDesde.Name = "btnFechaAtDesde";
            this.btnFechaAtDesde.Size = new System.Drawing.Size(168, 21);
            this.btnFechaAtDesde.TabIndex = 295;
            this.btnFechaAtDesde.Text = "Por Fecha De Atencion";
            this.btnFechaAtDesde.UseVisualStyleBackColor = true;
            this.btnFechaAtDesde.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFechaFactDesde
            // 
            this.lblFechaFactDesde.AutoSize = true;
            this.lblFechaFactDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.lblFechaFactDesde.Location = new System.Drawing.Point(15, 200);
            this.lblFechaFactDesde.Name = "lblFechaFactDesde";
            this.lblFechaFactDesde.Size = new System.Drawing.Size(49, 17);
            this.lblFechaFactDesde.TabIndex = 295;
            this.lblFechaFactDesde.Text = "Desde";
            this.lblFechaFactDesde.Visible = false;
            // 
            // lblFechaAtDesde
            // 
            this.lblFechaAtDesde.AutoSize = true;
            this.lblFechaAtDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.lblFechaAtDesde.Location = new System.Drawing.Point(236, 199);
            this.lblFechaAtDesde.Name = "lblFechaAtDesde";
            this.lblFechaAtDesde.Size = new System.Drawing.Size(49, 17);
            this.lblFechaAtDesde.TabIndex = 301;
            this.lblFechaAtDesde.Text = "Desde";
            this.lblFechaAtDesde.Visible = false;
            // 
            // botBuscar
            // 
            this.botBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.botBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.botBuscar.Image = ((System.Drawing.Image)(resources.GetObject("botBuscar.Image")));
            this.botBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botBuscar.Location = new System.Drawing.Point(308, 338);
            this.botBuscar.Name = "botBuscar";
            this.botBuscar.Size = new System.Drawing.Size(95, 33);
            this.botBuscar.TabIndex = 277;
            this.botBuscar.Text = "Buscar";
            this.botBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botBuscar.UseVisualStyleBackColor = false;
            this.botBuscar.Click += new System.EventHandler(this.botBuscar_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(18, 377);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(385, 23);
            this.progressBar.TabIndex = 325;
            this.progressBar.Visible = false;
            // 
            // frmConsultaFacturacionEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 415);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblFechaAtDesde);
            this.Controls.Add(this.lblFechaFactDesde);
            this.Controls.Add(this.btnFechaAtDesde);
            this.Controls.Add(this.btnFechaFactDesde);
            this.Controls.Add(this.dtpFechaFactDesde);
            this.Controls.Add(this.cbEmpresaDesde);
            this.Controls.Add(this.lblFechaFacHasta);
            this.Controls.Add(this.dtpFechaAtencionDesde);
            this.Controls.Add(this.dtpFechaFactHasta);
            this.Controls.Add(this.lblFechaAtHasta);
            this.Controls.Add(this.btnIgualaFechasFac);
            this.Controls.Add(this.dtpFechaAtHasta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIgualaFechaAt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbEmpresaHasta);
            this.Controls.Add(this.btnIgualaEmpresas);
            this.Controls.Add(this.rbInformeResumido);
            this.Controls.Add(this.rbInformeDetallado);
            this.Controls.Add(this.botBuscar);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmConsultaFacturacionEmpresa";
            this.Text = "Desde";
            this.Load += new System.EventHandler(this.frmConsultaFacturacionEmpresa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFechaFactDesde;
        protected System.Windows.Forms.Label lbTitulo;
        public System.Windows.Forms.Button botBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaFactHasta;
        private System.Windows.Forms.Label lblFechaFacHasta;
        public System.Windows.Forms.Button btnIgualaFechasFac;
        public System.Windows.Forms.Button btnIgualaFechaAt;
        private System.Windows.Forms.DateTimePicker dtpFechaAtHasta;
        private System.Windows.Forms.Label lblFechaAtHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaAtencionDesde;
        private System.Windows.Forms.RadioButton rbInformeDetallado;
        private System.Windows.Forms.RadioButton rbInformeResumido;
        public System.Windows.Forms.Button btnIgualaEmpresas;
        private System.Windows.Forms.ComboBox cbEmpresaHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEmpresaDesde;
        private System.Windows.Forms.Button btnFechaAtDesde;
        private System.Windows.Forms.Button btnFechaFactDesde;
        private System.Windows.Forms.Label lblFechaFactDesde;
        private System.Windows.Forms.Label lblFechaAtDesde;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}