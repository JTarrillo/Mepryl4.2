namespace CapaPresentacion
{
    partial class frmPreciosPublico
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (System.ObjectDisposedException) { }
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblMes = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.nudAnio = new System.Windows.Forms.NumericUpDown();
            this.btnCargar = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCopiarMes = new System.Windows.Forms.Button();
            this.btnVariacion = new System.Windows.Forms.Button();
            this.btnCalcularLista = new System.Windows.Forms.Button();
            this.mnuAplicar = new System.Windows.Forms.ContextMenuStrip();
            this.mnuAplicarVariacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVariacionPromo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVariacionLista = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCalcularLista = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.chkFactor = new System.Windows.Forms.CheckBox();
            this.lblVariacion = new System.Windows.Forms.Label();
            this.txtVariacion = new System.Windows.Forms.TextBox();
            this.pnlCentro = new System.Windows.Forms.Panel();
            this.dgvPrecios = new System.Windows.Forms.DataGridView();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioLista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioPromo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlCentro.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.SeaGreen;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1364, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "  Precios al Público";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.lblMes);
            this.pnlSuperior.Controls.Add(this.cboMes);
            this.pnlSuperior.Controls.Add(this.lblAnio);
            this.pnlSuperior.Controls.Add(this.nudAnio);
            this.pnlSuperior.Controls.Add(this.btnCargar);
            this.pnlSuperior.Controls.Add(this.lblBuscar);
            this.pnlSuperior.Controls.Add(this.txtBuscar);
            this.pnlSuperior.Controls.Add(this.lblTotal);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 40);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1364, 50);
            this.pnlSuperior.TabIndex = 1;

            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMes.Location = new System.Drawing.Point(12, 14);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(35, 19);
            this.lblMes.Text = "Mes:";

            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMes.Items.AddRange(new object[] {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"});
            this.cboMes.Location = new System.Drawing.Point(50, 11);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(130, 25);

            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAnio.Location = new System.Drawing.Point(195, 14);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(35, 19);
            this.lblAnio.Text = "Año:";

            // 
            // nudAnio
            // 
            this.nudAnio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudAnio.Location = new System.Drawing.Point(233, 11);
            this.nudAnio.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            this.nudAnio.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(70, 25);
            this.nudAnio.Value = new decimal(new int[] { 2026, 0, 0, 0 });

            // 
            // btnCargar
            // 
            this.btnCargar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCargar.Location = new System.Drawing.Point(315, 9);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(80, 30);
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);

            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBuscar.Location = new System.Drawing.Point(420, 14);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(50, 19);
            this.lblBuscar.Text = "Buscar:";

            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(475, 11);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(250, 25);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotal.Location = new System.Drawing.Point(740, 14);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 19);
            this.lblTotal.Text = "Prestaciones: 0";

            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnGuardar);
            this.pnlMenu.Controls.Add(this.btnCopiarMes);
            this.pnlMenu.Controls.Add(this.lblVariacion);
            this.pnlMenu.Controls.Add(this.txtVariacion);
            this.pnlMenu.Controls.Add(this.chkFactor);
            this.pnlMenu.Controls.Add(this.btnAplicar);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenu.Location = new System.Drawing.Point(1214, 90);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(150, 467);
            this.pnlMenu.TabIndex = 2;

            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(10, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 40);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // 
            // btnCopiarMes
            // 
            this.btnCopiarMes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCopiarMes.Location = new System.Drawing.Point(10, 60);
            this.btnCopiarMes.Name = "btnCopiarMes";
            this.btnCopiarMes.Size = new System.Drawing.Size(130, 40);
            this.btnCopiarMes.Text = "Copiar desde\r\nmes anterior";
            this.btnCopiarMes.UseVisualStyleBackColor = true;
            this.btnCopiarMes.Click += new System.EventHandler(this.btnCopiarMes_Click);

            // 
            // lblVariacion
            // 
            this.lblVariacion.AutoSize = true;
            this.lblVariacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVariacion.Location = new System.Drawing.Point(10, 120);
            this.lblVariacion.Name = "lblVariacion";
            this.lblVariacion.Size = new System.Drawing.Size(80, 15);
            this.lblVariacion.Text = "Incremento %:";

            // 
            // chkFactor
            // 
            this.chkFactor.AutoSize = true;
            this.chkFactor.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkFactor.Location = new System.Drawing.Point(12, 168);
            this.chkFactor.Name = "chkFactor";
            this.chkFactor.Size = new System.Drawing.Size(100, 17);
            this.chkFactor.Text = "Usar factor (ej: 1.15)";
            this.chkFactor.CheckedChanged += new System.EventHandler(this.chkFactor_CheckedChanged);

            // 
            // txtVariacion
            // 
            this.txtVariacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVariacion.Location = new System.Drawing.Point(10, 140);
            this.txtVariacion.Name = "txtVariacion";
            this.txtVariacion.Size = new System.Drawing.Size(130, 25);
            this.txtVariacion.Text = "0";

            // 
            // mnuAplicar
            // 
            this.mnuAplicar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuAplicarVariacion,
                this.mnuVariacionPromo,
                this.mnuVariacionLista,
                new System.Windows.Forms.ToolStripSeparator(),
                this.mnuCalcularLista});
            this.mnuAplicar.Name = "mnuAplicar";
            this.mnuAplicar.Size = new System.Drawing.Size(200, 48);

            // 
            // mnuAplicarVariacion
            // 
            this.mnuAplicarVariacion.Name = "mnuAplicarVariacion";
            this.mnuAplicarVariacion.Size = new System.Drawing.Size(199, 22);
            this.mnuAplicarVariacion.Text = "Variación a ambos";
            this.mnuAplicarVariacion.Click += new System.EventHandler(this.btnVariacion_Click);

            // 
            // mnuVariacionPromo
            // 
            this.mnuVariacionPromo.Name = "mnuVariacionPromo";
            this.mnuVariacionPromo.Size = new System.Drawing.Size(199, 22);
            this.mnuVariacionPromo.Text = "Variación solo a Promo";
            this.mnuVariacionPromo.Click += new System.EventHandler(this.btnVariacionPromo_Click);

            // 
            // mnuVariacionLista
            // 
            this.mnuVariacionLista.Name = "mnuVariacionLista";
            this.mnuVariacionLista.Size = new System.Drawing.Size(199, 22);
            this.mnuVariacionLista.Text = "Variación solo a Lista";
            this.mnuVariacionLista.Click += new System.EventHandler(this.btnVariacionLista_Click);

            // 
            // mnuCalcularLista
            // 
            this.mnuCalcularLista.Name = "mnuCalcularLista";
            this.mnuCalcularLista.Size = new System.Drawing.Size(199, 22);
            this.mnuCalcularLista.Text = "Calcular Lista desde Promo";
            this.mnuCalcularLista.Click += new System.EventHandler(this.btnCalcularLista_Click);

            // 
            // btnAplicar
            // 
            this.btnAplicar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAplicar.Location = new System.Drawing.Point(10, 190);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(130, 40);
            this.btnAplicar.Text = "Aplicar ▼";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);

            // 
            // btnVariacion
            // 
            this.btnVariacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVariacion.Location = new System.Drawing.Point(10, 190);
            this.btnVariacion.Name = "btnVariacion";
            this.btnVariacion.Size = new System.Drawing.Size(130, 35);
            this.btnVariacion.Text = "Aplicar variación";
            this.btnVariacion.UseVisualStyleBackColor = true;
            this.btnVariacion.Visible = false;
            this.btnVariacion.Click += new System.EventHandler(this.btnVariacion_Click);

            // 
            // btnCalcularLista
            // 
            this.btnCalcularLista.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCalcularLista.Location = new System.Drawing.Point(10, 235);
            this.btnCalcularLista.Name = "btnCalcularLista";
            this.btnCalcularLista.Size = new System.Drawing.Size(130, 40);
            this.btnCalcularLista.Text = "Calcular Lista\r\ndesde Promo";
            this.btnCalcularLista.UseVisualStyleBackColor = true;
            this.btnCalcularLista.Visible = false;
            this.btnCalcularLista.Click += new System.EventHandler(this.btnCalcularLista_Click);

            // 
            // tabControl
            // 
            this.pnlCentro.Controls.Add(this.dgvPrecios);
            this.pnlCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentro.Location = new System.Drawing.Point(0, 90);
            this.pnlCentro.Name = "pnlCentro";
            this.pnlCentro.Size = new System.Drawing.Size(1214, 467);
            this.pnlCentro.TabIndex = 3;

            // 
            // dgvPrecios
            // 
            this.dgvPrecios.AllowUserToAddRows = false;
            this.dgvPrecios.AllowUserToDeleteRows = false;
            this.dgvPrecios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrecios.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrecios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrecios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colIdEspecialidad,
                this.colMotivo,
                this.colTipo,
                this.colDescripcion,
                this.colPrecioPromo,
                this.colPrecioLista});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrecios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPrecios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrecios.EnableHeadersVisualStyles = false;
            this.dgvPrecios.Location = new System.Drawing.Point(0, 0);
            this.dgvPrecios.Name = "dgvPrecios";
            this.dgvPrecios.RowHeadersVisible = false;
            this.dgvPrecios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrecios.Size = new System.Drawing.Size(1214, 467);
            this.dgvPrecios.TabIndex = 0;
            this.dgvPrecios.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvPrecios_CellParsing);

            // 
            // colIdEspecialidad
            // 
            this.colIdEspecialidad.HeaderText = "Id";
            this.colIdEspecialidad.Name = "colIdEspecialidad";
            this.colIdEspecialidad.Visible = false;

            // 
            // colMotivo
            // 
            this.colMotivo.FillWeight = 80F;
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.ReadOnly = true;

            // 
            // colTipo
            // 
            this.colTipo.FillWeight = 100F;
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;

            // 
            // colDescripcion
            // 
            this.colDescripcion.FillWeight = 200F;
            this.colDescripcion.HeaderText = "Subtipo";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;

            // 
            // colPrecioLista
            // 
            this.colPrecioLista.FillWeight = 100F;
            this.colPrecioLista.HeaderText = "Precio Lista (Transferencia)";
            this.colPrecioLista.Name = "colPrecioLista";
            this.colPrecioLista.ValueType = typeof(decimal);
            this.colPrecioLista.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPrecioLista.DefaultCellStyle.Format = "N2";

            // 
            // colPrecioPromo
            // 
            this.colPrecioPromo.FillWeight = 100F;
            this.colPrecioPromo.HeaderText = "Precio Promo (Efectivo)";
            this.colPrecioPromo.Name = "colPrecioPromo";
            this.colPrecioPromo.ValueType = typeof(decimal);
            this.colPrecioPromo.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPrecioPromo.DefaultCellStyle.Format = "N2";

            // 
            // frmPreciosPublico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 557);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmPreciosPublico";
            this.Text = "Precios al Público";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPreciosPublico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlCentro.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCopiarMes;
        private System.Windows.Forms.Button btnVariacion;
        private System.Windows.Forms.Button btnCalcularLista;
        private System.Windows.Forms.ContextMenuStrip mnuAplicar;
        private System.Windows.Forms.ToolStripMenuItem mnuAplicarVariacion;
        private System.Windows.Forms.ToolStripMenuItem mnuVariacionPromo;
        private System.Windows.Forms.ToolStripMenuItem mnuVariacionLista;
        private System.Windows.Forms.ToolStripMenuItem mnuCalcularLista;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.CheckBox chkFactor;
        private System.Windows.Forms.Label lblVariacion;
        private System.Windows.Forms.TextBox txtVariacion;
        private System.Windows.Forms.Panel pnlCentro;
        private System.Windows.Forms.DataGridView dgvPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioPromo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblTotal;
    }
}
