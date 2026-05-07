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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblAnio = new System.Windows.Forms.Label();
            this.nudAnio = new System.Windows.Forms.NumericUpDown();
            this.btnCargar = new System.Windows.Forms.Button();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCopiarAnio = new System.Windows.Forms.Button();
            this.lblMesVariacion = new System.Windows.Forms.Label();
            this.cboMesVariacion = new System.Windows.Forms.ComboBox();
            this.lblVariacion = new System.Windows.Forms.Label();
            this.txtVariacion = new System.Windows.Forms.TextBox();
            this.chkFactor = new System.Windows.Forms.CheckBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.mnuAplicar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuVariacion = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCentro = new System.Windows.Forms.Panel();
            this.dgvPrecios = new System.Windows.Forms.DataGridView();
            this.colIdEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromo01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoef01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromo02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoef02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromo03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoef03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromo04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoef04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromo05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoef05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromo06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoef06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromo07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoef07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromo08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoef08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromo09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoef09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromo10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoef10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromo11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoef11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPromo12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoef12 = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlCentro.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.BackColor = System.Drawing.Color.SeaGreen;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1364, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "  Precios al Público — Vista Anual";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlSuperior
            this.pnlSuperior.Controls.Add(this.lblAnio);
            this.pnlSuperior.Controls.Add(this.nudAnio);
            this.pnlSuperior.Controls.Add(this.btnCargar);
            this.pnlSuperior.Controls.Add(this.lblBuscar);
            this.pnlSuperior.Controls.Add(this.txtBuscar);
            this.pnlSuperior.Controls.Add(this.lblTotal);
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 40);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1364, 50);
            this.pnlSuperior.TabIndex = 1;

            // lblAnio
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAnio.Location = new System.Drawing.Point(12, 14);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Text = "Año:";

            // nudAnio
            this.nudAnio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudAnio.Location = new System.Drawing.Point(50, 11);
            this.nudAnio.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            this.nudAnio.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(70, 25);
            this.nudAnio.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            this.nudAnio.ValueChanged += new System.EventHandler(this.nudAnio_ValueChanged);

            // btnCargar
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Location = new System.Drawing.Point(135, 9);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(80, 30);
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);

            // lblBuscar
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBuscar.Location = new System.Drawing.Point(235, 14);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "Buscar:";

            // txtBuscar
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(290, 11);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(250, 25);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotal.Location = new System.Drawing.Point(555, 14);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "Prestaciones: 0";

            // pnlMenu
            this.pnlMenu.Controls.Add(this.btnGuardar);
            this.pnlMenu.Controls.Add(this.btnCopiarAnio);
            this.pnlMenu.Controls.Add(this.lblMesVariacion);
            this.pnlMenu.Controls.Add(this.cboMesVariacion);
            this.pnlMenu.Controls.Add(this.lblVariacion);
            this.pnlMenu.Controls.Add(this.txtVariacion);
            this.pnlMenu.Controls.Add(this.chkFactor);
            this.pnlMenu.Controls.Add(this.btnAplicar);
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(248, 248, 248);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenu.Location = new System.Drawing.Point(1214, 90);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(150, 467);
            this.pnlMenu.TabIndex = 2;

            // btnGuardar
            this.btnGuardar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(10, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 40);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCopiarAnio
            this.btnCopiarAnio.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCopiarAnio.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCopiarAnio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiarAnio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCopiarAnio.ForeColor = System.Drawing.Color.White;
            this.btnCopiarAnio.Location = new System.Drawing.Point(10, 60);
            this.btnCopiarAnio.Name = "btnCopiarAnio";
            this.btnCopiarAnio.Size = new System.Drawing.Size(130, 40);
            this.btnCopiarAnio.Text = "Copiar desde\r\naño anterior";
            this.btnCopiarAnio.UseVisualStyleBackColor = false;
            this.btnCopiarAnio.Click += new System.EventHandler(this.btnCopiarAnio_Click);

            // lblMesVariacion
            this.lblMesVariacion.AutoSize = true;
            this.lblMesVariacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMesVariacion.Location = new System.Drawing.Point(10, 115);
            this.lblMesVariacion.Name = "lblMesVariacion";
            this.lblMesVariacion.Text = "Mes a aplicar:";

            // cboMesVariacion
            this.cboMesVariacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesVariacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboMesVariacion.Items.AddRange(new object[] {
                "(Todos)", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" });
            this.cboMesVariacion.Location = new System.Drawing.Point(10, 132);
            this.cboMesVariacion.Name = "cboMesVariacion";
            this.cboMesVariacion.Size = new System.Drawing.Size(130, 23);

            // lblVariacion
            this.lblVariacion.AutoSize = true;
            this.lblVariacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVariacion.Location = new System.Drawing.Point(10, 168);
            this.lblVariacion.Name = "lblVariacion";
            this.lblVariacion.Text = "Incremento %:";

            // txtVariacion
            this.txtVariacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVariacion.Location = new System.Drawing.Point(10, 186);
            this.txtVariacion.Name = "txtVariacion";
            this.txtVariacion.Size = new System.Drawing.Size(130, 25);
            this.txtVariacion.Text = "0";

            // chkFactor
            this.chkFactor.AutoSize = true;
            this.chkFactor.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkFactor.Location = new System.Drawing.Point(12, 216);
            this.chkFactor.Name = "chkFactor";
            this.chkFactor.Text = "Usar factor (ej: 1.15)";
            this.chkFactor.CheckedChanged += new System.EventHandler(this.chkFactor_CheckedChanged);

            // mnuAplicar
            this.mnuAplicar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuVariacion });
            this.mnuAplicar.Name = "mnuAplicar";

            // mnuVariacion
            this.mnuVariacion.Name = "mnuVariacion";
            this.mnuVariacion.Text = "Aplicar variación al mes seleccionado";
            this.mnuVariacion.Click += new System.EventHandler(this.mnuVariacion_Click);

            // btnAplicar
            this.btnAplicar.BackColor = System.Drawing.Color.FromArgb(210, 105, 30);
            this.btnAplicar.FlatAppearance.BorderColor = System.Drawing.Color.Chocolate;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.Location = new System.Drawing.Point(10, 240);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(130, 40);
            this.btnAplicar.Text = "Aplicar \u25bc";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);

            // pnlCentro
            this.pnlCentro.Controls.Add(this.dgvPrecios);
            this.pnlCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentro.Location = new System.Drawing.Point(0, 90);
            this.pnlCentro.Name = "pnlCentro";
            this.pnlCentro.TabIndex = 3;

            // dgvPrecios
            this.dgvPrecios.AllowUserToAddRows = false;
            this.dgvPrecios.AllowUserToDeleteRows = false;
            this.dgvPrecios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrecios.BackgroundColor = System.Drawing.Color.White;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = System.Drawing.Color.SeaGreen;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrecios.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvPrecios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colIdEspecialidad,
                this.colMotivo,
                this.colTipo,
                this.colDescripcion,
                this.colPromo01, this.colCoef01,
                this.colPromo02, this.colCoef02,
                this.colPromo03, this.colCoef03,
                this.colPromo04, this.colCoef04,
                this.colPromo05, this.colCoef05,
                this.colPromo06, this.colCoef06,
                this.colPromo07, this.colCoef07,
                this.colPromo08, this.colCoef08,
                this.colPromo09, this.colCoef09,
                this.colPromo10, this.colCoef10,
                this.colPromo11, this.colCoef11,
                this.colPromo12, this.colCoef12 });

            cellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = System.Drawing.SystemColors.Window;
            cellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            cellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            cellStyle.SelectionBackColor = System.Drawing.Color.White;
            cellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPrecios.DefaultCellStyle = cellStyle;

            altStyle.BackColor = System.Drawing.Color.FromArgb(235, 247, 240);
            altStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 247, 240);
            altStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPrecios.AlternatingRowsDefaultCellStyle = altStyle;

            this.dgvPrecios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrecios.EnableHeadersVisualStyles = false;
            this.dgvPrecios.Location = new System.Drawing.Point(0, 0);
            this.dgvPrecios.Name = "dgvPrecios";
            this.dgvPrecios.RowHeadersVisible = false;
            this.dgvPrecios.RowTemplate.Height = 28;
            this.dgvPrecios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrecios.TabIndex = 0;

            // colIdEspecialidad
            this.colIdEspecialidad.HeaderText = "Id";
            this.colIdEspecialidad.Name = "colIdEspecialidad";
            this.colIdEspecialidad.Visible = false;

            // colMotivo
            this.colMotivo.FillWeight = 70F;
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.ReadOnly = true;
            this.colMotivo.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(230, 245, 235);
            this.colMotivo.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 80, 50);
            this.colMotivo.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(180, 220, 195);
            this.colMotivo.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.colMotivo.HeaderCell.Style.BackColor = System.Drawing.Color.SeaGreen;
            this.colMotivo.HeaderCell.Style.ForeColor = System.Drawing.Color.White;
            this.colMotivo.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.colMotivo.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // colTipo
            this.colTipo.FillWeight = 90F;
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;

            // colDescripcion
            this.colDescripcion.FillWeight = 160F;
            this.colDescripcion.HeaderText = "Subtipo";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;

            // colPromo01 - colPromo12 / colCoef01 - colCoef12
            this.colPromo01.FillWeight = 60F; this.colPromo01.HeaderText = "Ene"; this.colPromo01.Name = "colPromo01"; this.colPromo01.ValueType = typeof(decimal); this.colPromo01.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colPromo01.DefaultCellStyle.Format = "N0";
            this.colPromo02.FillWeight = 60F; this.colPromo02.HeaderText = "Feb"; this.colPromo02.Name = "colPromo02"; this.colPromo02.ValueType = typeof(decimal); this.colPromo02.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colPromo02.DefaultCellStyle.Format = "N0";
            this.colPromo03.FillWeight = 60F; this.colPromo03.HeaderText = "Mar"; this.colPromo03.Name = "colPromo03"; this.colPromo03.ValueType = typeof(decimal); this.colPromo03.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colPromo03.DefaultCellStyle.Format = "N0";
            this.colPromo04.FillWeight = 60F; this.colPromo04.HeaderText = "Abr"; this.colPromo04.Name = "colPromo04"; this.colPromo04.ValueType = typeof(decimal); this.colPromo04.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colPromo04.DefaultCellStyle.Format = "N0";
            this.colPromo05.FillWeight = 60F; this.colPromo05.HeaderText = "May"; this.colPromo05.Name = "colPromo05"; this.colPromo05.ValueType = typeof(decimal); this.colPromo05.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colPromo05.DefaultCellStyle.Format = "N0";
            this.colPromo06.FillWeight = 60F; this.colPromo06.HeaderText = "Jun"; this.colPromo06.Name = "colPromo06"; this.colPromo06.ValueType = typeof(decimal); this.colPromo06.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colPromo06.DefaultCellStyle.Format = "N0";
            this.colPromo07.FillWeight = 60F; this.colPromo07.HeaderText = "Jul"; this.colPromo07.Name = "colPromo07"; this.colPromo07.ValueType = typeof(decimal); this.colPromo07.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colPromo07.DefaultCellStyle.Format = "N0";
            this.colPromo08.FillWeight = 60F; this.colPromo08.HeaderText = "Ago"; this.colPromo08.Name = "colPromo08"; this.colPromo08.ValueType = typeof(decimal); this.colPromo08.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colPromo08.DefaultCellStyle.Format = "N0";
            this.colPromo09.FillWeight = 60F; this.colPromo09.HeaderText = "Sep"; this.colPromo09.Name = "colPromo09"; this.colPromo09.ValueType = typeof(decimal); this.colPromo09.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colPromo09.DefaultCellStyle.Format = "N0";
            this.colPromo10.FillWeight = 60F; this.colPromo10.HeaderText = "Oct"; this.colPromo10.Name = "colPromo10"; this.colPromo10.ValueType = typeof(decimal); this.colPromo10.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colPromo10.DefaultCellStyle.Format = "N0";
            this.colPromo11.FillWeight = 60F; this.colPromo11.HeaderText = "Nov"; this.colPromo11.Name = "colPromo11"; this.colPromo11.ValueType = typeof(decimal); this.colPromo11.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colPromo11.DefaultCellStyle.Format = "N0";
            this.colPromo12.FillWeight = 60F; this.colPromo12.HeaderText = "Dic"; this.colPromo12.Name = "colPromo12"; this.colPromo12.ValueType = typeof(decimal); this.colPromo12.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colPromo12.DefaultCellStyle.Format = "N0";

            this.colCoef01.FillWeight = 32F; this.colCoef01.HeaderText = ""; this.colCoef01.Name = "colCoef01"; this.colCoef01.ValueType = typeof(decimal); this.colCoef01.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; this.colCoef01.DefaultCellStyle.Format = "0.####"; this.colCoef01.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef01.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef01.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef01.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef01.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef01.HeaderCell.Style.BackColor = System.Drawing.Color.FromArgb(180, 0, 0); this.colCoef01.HeaderCell.Style.ForeColor = System.Drawing.Color.White; this.colCoef01.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef01.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCoef02.FillWeight = 32F; this.colCoef02.HeaderText = ""; this.colCoef02.Name = "colCoef02"; this.colCoef02.ValueType = typeof(decimal); this.colCoef02.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; this.colCoef02.DefaultCellStyle.Format = "0.####"; this.colCoef02.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef02.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef02.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef02.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef02.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef02.HeaderCell.Style.BackColor = System.Drawing.Color.FromArgb(180, 0, 0); this.colCoef02.HeaderCell.Style.ForeColor = System.Drawing.Color.White; this.colCoef02.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef02.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCoef03.FillWeight = 32F; this.colCoef03.HeaderText = ""; this.colCoef03.Name = "colCoef03"; this.colCoef03.ValueType = typeof(decimal); this.colCoef03.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; this.colCoef03.DefaultCellStyle.Format = "0.####"; this.colCoef03.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef03.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef03.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef03.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef03.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef03.HeaderCell.Style.BackColor = System.Drawing.Color.FromArgb(180, 0, 0); this.colCoef03.HeaderCell.Style.ForeColor = System.Drawing.Color.White; this.colCoef03.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef03.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCoef04.FillWeight = 32F; this.colCoef04.HeaderText = ""; this.colCoef04.Name = "colCoef04"; this.colCoef04.ValueType = typeof(decimal); this.colCoef04.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; this.colCoef04.DefaultCellStyle.Format = "0.####"; this.colCoef04.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef04.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef04.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef04.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef04.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef04.HeaderCell.Style.BackColor = System.Drawing.Color.FromArgb(180, 0, 0); this.colCoef04.HeaderCell.Style.ForeColor = System.Drawing.Color.White; this.colCoef04.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef04.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCoef05.FillWeight = 32F; this.colCoef05.HeaderText = ""; this.colCoef05.Name = "colCoef05"; this.colCoef05.ValueType = typeof(decimal); this.colCoef05.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; this.colCoef05.DefaultCellStyle.Format = "0.####"; this.colCoef05.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef05.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef05.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef05.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef05.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef05.HeaderCell.Style.BackColor = System.Drawing.Color.FromArgb(180, 0, 0); this.colCoef05.HeaderCell.Style.ForeColor = System.Drawing.Color.White; this.colCoef05.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef05.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCoef06.FillWeight = 32F; this.colCoef06.HeaderText = ""; this.colCoef06.Name = "colCoef06"; this.colCoef06.ValueType = typeof(decimal); this.colCoef06.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; this.colCoef06.DefaultCellStyle.Format = "0.####"; this.colCoef06.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef06.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef06.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef06.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef06.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef06.HeaderCell.Style.BackColor = System.Drawing.Color.FromArgb(180, 0, 0); this.colCoef06.HeaderCell.Style.ForeColor = System.Drawing.Color.White; this.colCoef06.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef06.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCoef07.FillWeight = 32F; this.colCoef07.HeaderText = ""; this.colCoef07.Name = "colCoef07"; this.colCoef07.ValueType = typeof(decimal); this.colCoef07.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; this.colCoef07.DefaultCellStyle.Format = "0.####"; this.colCoef07.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef07.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef07.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef07.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef07.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef07.HeaderCell.Style.BackColor = System.Drawing.Color.FromArgb(180, 0, 0); this.colCoef07.HeaderCell.Style.ForeColor = System.Drawing.Color.White; this.colCoef07.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef07.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCoef08.FillWeight = 32F; this.colCoef08.HeaderText = ""; this.colCoef08.Name = "colCoef08"; this.colCoef08.ValueType = typeof(decimal); this.colCoef08.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; this.colCoef08.DefaultCellStyle.Format = "0.####"; this.colCoef08.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef08.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef08.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef08.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef08.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef08.HeaderCell.Style.BackColor = System.Drawing.Color.FromArgb(180, 0, 0); this.colCoef08.HeaderCell.Style.ForeColor = System.Drawing.Color.White; this.colCoef08.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef08.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCoef09.FillWeight = 32F; this.colCoef09.HeaderText = ""; this.colCoef09.Name = "colCoef09"; this.colCoef09.ValueType = typeof(decimal); this.colCoef09.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; this.colCoef09.DefaultCellStyle.Format = "0.####"; this.colCoef09.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef09.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef09.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef09.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef09.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef09.HeaderCell.Style.BackColor = System.Drawing.Color.FromArgb(180, 0, 0); this.colCoef09.HeaderCell.Style.ForeColor = System.Drawing.Color.White; this.colCoef09.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef09.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCoef10.FillWeight = 32F; this.colCoef10.HeaderText = ""; this.colCoef10.Name = "colCoef10"; this.colCoef10.ValueType = typeof(decimal); this.colCoef10.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; this.colCoef10.DefaultCellStyle.Format = "0.####"; this.colCoef10.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef10.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef10.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef10.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef10.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef10.HeaderCell.Style.BackColor = System.Drawing.Color.FromArgb(180, 0, 0); this.colCoef10.HeaderCell.Style.ForeColor = System.Drawing.Color.White; this.colCoef10.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef10.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCoef11.FillWeight = 32F; this.colCoef11.HeaderText = ""; this.colCoef11.Name = "colCoef11"; this.colCoef11.ValueType = typeof(decimal); this.colCoef11.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; this.colCoef11.DefaultCellStyle.Format = "0.####"; this.colCoef11.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef11.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef11.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef11.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef11.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef11.HeaderCell.Style.BackColor = System.Drawing.Color.FromArgb(180, 0, 0); this.colCoef11.HeaderCell.Style.ForeColor = System.Drawing.Color.White; this.colCoef11.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef11.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCoef12.FillWeight = 32F; this.colCoef12.HeaderText = ""; this.colCoef12.Name = "colCoef12"; this.colCoef12.ValueType = typeof(decimal); this.colCoef12.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; this.colCoef12.DefaultCellStyle.Format = "0.####"; this.colCoef12.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef12.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef12.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 210); this.colCoef12.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(140, 0, 0); this.colCoef12.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef12.HeaderCell.Style.BackColor = System.Drawing.Color.FromArgb(180, 0, 0); this.colCoef12.HeaderCell.Style.ForeColor = System.Drawing.Color.White; this.colCoef12.HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.colCoef12.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // frmPreciosPublico
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 557);
            this.Controls.Add(this.pnlCentro);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmPreciosPublico";
            this.Text = "Precios al Público";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPreciosPublico_Load);            this.dgvPrecios.CellPainting                 += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPrecios_CellPainting);            this.dgvPrecios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPrecios_CellFormatting);
            this.dgvPrecios.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPrecios_ColumnHeaderMouseDoubleClick);

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
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCopiarAnio;
        private System.Windows.Forms.Label lblMesVariacion;
        private System.Windows.Forms.ComboBox cboMesVariacion;
        private System.Windows.Forms.Label lblVariacion;
        private System.Windows.Forms.TextBox txtVariacion;
        private System.Windows.Forms.CheckBox chkFactor;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.ContextMenuStrip mnuAplicar;
        private System.Windows.Forms.ToolStripMenuItem mnuVariacion;
        private System.Windows.Forms.Panel pnlCentro;
        private System.Windows.Forms.DataGridView dgvPrecios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromo01;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoef01;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromo02;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoef02;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromo03;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoef03;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromo04;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoef04;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromo05;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoef05;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromo06;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoef06;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromo07;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoef07;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromo08;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoef08;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromo09;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoef09;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromo10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoef10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromo11;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoef11;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPromo12;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoef12;
    }
}