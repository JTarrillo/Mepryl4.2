namespace CapaPresentacion
{
    partial class frmMuestraFactPorEmpresa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMuestraFactPorEmpresa));
            this.lbliva = new System.Windows.Forms.Label();
            this.tbIVA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUtilidadTotal = new System.Windows.Forms.Label();
            this.tbSubTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCostoTotal = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvFacturaciones = new System.Windows.Forms.DataGridView();
            this.idFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idConsultaLaboral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoLista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPrestacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionLista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Facturacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.btnSiguienteEmpresa = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.cbEmpresasSeleccionadas = new System.Windows.Forms.ComboBox();
            this.cbOperaciones = new System.Windows.Forms.ComboBox();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.tbExcel = new System.Windows.Forms.TextBox();
            this.botImpExcel = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnExportarPdf = new System.Windows.Forms.Button();
            this.tbPDF = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnUbicacionPdf = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbExpExcel = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEmpresaAnterior = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaciones)).BeginInit();
            this.gbExpExcel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbliva
            // 
            this.lbliva.AutoSize = true;
            this.lbliva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbliva.Location = new System.Drawing.Point(711, 352);
            this.lbliva.Name = "lbliva";
            this.lbliva.Size = new System.Drawing.Size(46, 18);
            this.lbliva.TabIndex = 315;
            this.lbliva.Text = "IVA%";
            // 
            // tbIVA
            // 
            this.tbIVA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbIVA.Enabled = false;
            this.tbIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.tbIVA.Location = new System.Drawing.Point(756, 345);
            this.tbIVA.Name = "tbIVA";
            this.tbIVA.ReadOnly = true;
            this.tbIVA.Size = new System.Drawing.Size(124, 29);
            this.tbIVA.TabIndex = 312;
            this.tbIVA.Text = "0";
            this.tbIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(691, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 18);
            this.label4.TabIndex = 314;
            this.label4.Text = "%";
            // 
            // lblUtilidadTotal
            // 
            this.lblUtilidadTotal.AutoSize = true;
            this.lblUtilidadTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUtilidadTotal.Location = new System.Drawing.Point(611, 352);
            this.lblUtilidadTotal.Name = "lblUtilidadTotal";
            this.lblUtilidadTotal.Size = new System.Drawing.Size(80, 18);
            this.lblUtilidadTotal.TabIndex = 313;
            this.lblUtilidadTotal.Text = "Total IVA:";
            // 
            // tbSubTotal
            // 
            this.tbSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbSubTotal.Enabled = false;
            this.tbSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.tbSubTotal.Location = new System.Drawing.Point(756, 310);
            this.tbSubTotal.Name = "tbSubTotal";
            this.tbSubTotal.ReadOnly = true;
            this.tbSubTotal.Size = new System.Drawing.Size(124, 29);
            this.tbSubTotal.TabIndex = 309;
            this.tbSubTotal.Text = "0";
            this.tbSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(738, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 24);
            this.label2.TabIndex = 311;
            this.label2.Text = "$";
            // 
            // lblCostoTotal
            // 
            this.lblCostoTotal.AutoSize = true;
            this.lblCostoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoTotal.Location = new System.Drawing.Point(652, 317);
            this.lblCostoTotal.Name = "lblCostoTotal";
            this.lblCostoTotal.Size = new System.Drawing.Size(80, 18);
            this.lblCostoTotal.TabIndex = 310;
            this.lblCostoTotal.Text = "SubTotal:";
            // 
            // tbTotal
            // 
            this.tbTotal.BackColor = System.Drawing.SystemColors.Control;
            this.tbTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbTotal.Enabled = false;
            this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.tbTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbTotal.Location = new System.Drawing.Point(756, 380);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(124, 29);
            this.tbTotal.TabIndex = 306;
            this.tbTotal.Text = "0";
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(738, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 24);
            this.label3.TabIndex = 308;
            this.label3.Text = "$";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotal.Location = new System.Drawing.Point(678, 385);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(54, 20);
            this.lblTotal.TabIndex = 307;
            this.lblTotal.Text = "Total:";
            // 
            // dgvFacturaciones
            // 
            this.dgvFacturaciones.AllowUserToAddRows = false;
            this.dgvFacturaciones.AllowUserToResizeRows = false;
            this.dgvFacturaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFacturaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvFacturaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFact,
            this.idConsultaLaboral,
            this.idEmpresa,
            this.Paciente,
            this.FechaAt,
            this.FechaFact,
            this.CodigoLista,
            this.TipoPrestacion,
            this.DescripcionLista,
            this.Facturacion});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFacturaciones.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFacturaciones.Location = new System.Drawing.Point(4, 103);
            this.dgvFacturaciones.MultiSelect = false;
            this.dgvFacturaciones.Name = "dgvFacturaciones";
            this.dgvFacturaciones.ReadOnly = true;
            this.dgvFacturaciones.RowHeadersVisible = false;
            this.dgvFacturaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFacturaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturaciones.Size = new System.Drawing.Size(876, 195);
            this.dgvFacturaciones.TabIndex = 305;
            this.dgvFacturaciones.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvFacturaciones_RowsAdded);
            this.dgvFacturaciones.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvFacturaciones_RowsRemoved);
            // 
            // idFact
            // 
            this.idFact.HeaderText = "id";
            this.idFact.Name = "idFact";
            this.idFact.ReadOnly = true;
            this.idFact.Visible = false;
            // 
            // idConsultaLaboral
            // 
            this.idConsultaLaboral.HeaderText = "ConsultaLaboral";
            this.idConsultaLaboral.Name = "idConsultaLaboral";
            this.idConsultaLaboral.ReadOnly = true;
            this.idConsultaLaboral.Visible = false;
            // 
            // idEmpresa
            // 
            this.idEmpresa.HeaderText = "idEmpresa";
            this.idEmpresa.Name = "idEmpresa";
            this.idEmpresa.ReadOnly = true;
            this.idEmpresa.Visible = false;
            // 
            // Paciente
            // 
            this.Paciente.HeaderText = "Paciente";
            this.Paciente.Name = "Paciente";
            this.Paciente.ReadOnly = true;
            // 
            // FechaAt
            // 
            this.FechaAt.HeaderText = "Fecha At.";
            this.FechaAt.Name = "FechaAt";
            this.FechaAt.ReadOnly = true;
            // 
            // FechaFact
            // 
            this.FechaFact.HeaderText = "FechaFact";
            this.FechaFact.Name = "FechaFact";
            this.FechaFact.ReadOnly = true;
            // 
            // CodigoLista
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.CodigoLista.DefaultCellStyle = dataGridViewCellStyle1;
            this.CodigoLista.HeaderText = "Código";
            this.CodigoLista.Name = "CodigoLista";
            this.CodigoLista.ReadOnly = true;
            this.CodigoLista.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TipoPrestacion
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.TipoPrestacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.TipoPrestacion.HeaderText = "Tipo de Prestación";
            this.TipoPrestacion.Name = "TipoPrestacion";
            this.TipoPrestacion.ReadOnly = true;
            this.TipoPrestacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DescripcionLista
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.DescripcionLista.DefaultCellStyle = dataGridViewCellStyle3;
            this.DescripcionLista.HeaderText = "Descripción";
            this.DescripcionLista.Name = "DescripcionLista";
            this.DescripcionLista.ReadOnly = true;
            this.DescripcionLista.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Facturacion
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.Facturacion.DefaultCellStyle = dataGridViewCellStyle4;
            this.Facturacion.HeaderText = "Facturación";
            this.Facturacion.Name = "Facturacion";
            this.Facturacion.ReadOnly = true;
            this.Facturacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.Red;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1041, 30);
            this.lbTitulo.TabIndex = 304;
            this.lbTitulo.Text = "Consulta de Facturacion por Empresa";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSiguienteEmpresa
            // 
            this.btnSiguienteEmpresa.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSiguienteEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguienteEmpresa.ForeColor = System.Drawing.Color.Black;
            this.btnSiguienteEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguienteEmpresa.Image")));
            this.btnSiguienteEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSiguienteEmpresa.Location = new System.Drawing.Point(887, 154);
            this.btnSiguienteEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.btnSiguienteEmpresa.Name = "btnSiguienteEmpresa";
            this.btnSiguienteEmpresa.Size = new System.Drawing.Size(135, 45);
            this.btnSiguienteEmpresa.TabIndex = 317;
            this.btnSiguienteEmpresa.Text = "Siguiente\r\nEmpresa";
            this.btnSiguienteEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSiguienteEmpresa.UseVisualStyleBackColor = true;
            this.btnSiguienteEmpresa.Visible = false;
            this.btnSiguienteEmpresa.Click += new System.EventHandler(this.btnSiguienteEmpresa_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(887, 207);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(135, 45);
            this.btnEditar.TabIndex = 316;
            this.btnEditar.Text = "Editar\r\nFacturacion\r\n";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // cbEmpresasSeleccionadas
            // 
            this.cbEmpresasSeleccionadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cbEmpresasSeleccionadas.FormattingEnabled = true;
            this.cbEmpresasSeleccionadas.Location = new System.Drawing.Point(4, 71);
            this.cbEmpresasSeleccionadas.Name = "cbEmpresasSeleccionadas";
            this.cbEmpresasSeleccionadas.Size = new System.Drawing.Size(215, 26);
            this.cbEmpresasSeleccionadas.TabIndex = 318;
            this.cbEmpresasSeleccionadas.SelectedValueChanged += new System.EventHandler(this.cbEmpresasSeleccionadas_SelectedValueChanged);
            // 
            // cbOperaciones
            // 
            this.cbOperaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cbOperaciones.FormattingEnabled = true;
            this.cbOperaciones.Location = new System.Drawing.Point(225, 71);
            this.cbOperaciones.Name = "cbOperaciones";
            this.cbOperaciones.Size = new System.Drawing.Size(215, 26);
            this.cbOperaciones.TabIndex = 320;
            this.cbOperaciones.Visible = false;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarExcel.Location = new System.Drawing.Point(222, 13);
            this.btnExportarExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(135, 45);
            this.btnExportarExcel.TabIndex = 321;
            this.btnExportarExcel.Text = "Exportar\r\nA Excel\r\n";
            this.btnExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbExcel
            // 
            this.tbExcel.BackColor = System.Drawing.Color.White;
            this.tbExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExcel.Location = new System.Drawing.Point(6, 65);
            this.tbExcel.Name = "tbExcel";
            this.tbExcel.ReadOnly = true;
            this.tbExcel.Size = new System.Drawing.Size(306, 22);
            this.tbExcel.TabIndex = 322;
            // 
            // botImpExcel
            // 
            this.botImpExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImpExcel.Location = new System.Drawing.Point(318, 65);
            this.botImpExcel.Name = "botImpExcel";
            this.botImpExcel.Size = new System.Drawing.Size(41, 22);
            this.botImpExcel.TabIndex = 323;
            this.botImpExcel.Text = "...";
            this.botImpExcel.UseVisualStyleBackColor = true;
            this.botImpExcel.Click += new System.EventHandler(this.botImpExcel_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(4, 114);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(353, 23);
            this.progressBar.TabIndex = 324;
            this.progressBar.Visible = false;
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExportarPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPdf.ForeColor = System.Drawing.Color.Black;
            this.btnExportarPdf.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarPdf.Image")));
            this.btnExportarPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarPdf.Location = new System.Drawing.Point(222, 17);
            this.btnExportarPdf.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(135, 45);
            this.btnExportarPdf.TabIndex = 325;
            this.btnExportarPdf.Text = "Exportar\r\nA Pdf\r\n\r\n";
            this.btnExportarPdf.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnExportarPdf.UseVisualStyleBackColor = true;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // tbPDF
            // 
            this.tbPDF.BackColor = System.Drawing.Color.White;
            this.tbPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPDF.Location = new System.Drawing.Point(6, 69);
            this.tbPDF.Name = "tbPDF";
            this.tbPDF.ReadOnly = true;
            this.tbPDF.Size = new System.Drawing.Size(306, 22);
            this.tbPDF.TabIndex = 322;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(4, 112);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(353, 23);
            this.progressBar1.TabIndex = 324;
            this.progressBar1.Visible = false;
            // 
            // btnUbicacionPdf
            // 
            this.btnUbicacionPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUbicacionPdf.Location = new System.Drawing.Point(318, 69);
            this.btnUbicacionPdf.Name = "btnUbicacionPdf";
            this.btnUbicacionPdf.Size = new System.Drawing.Size(41, 22);
            this.btnUbicacionPdf.TabIndex = 323;
            this.btnUbicacionPdf.Text = "...";
            this.btnUbicacionPdf.UseVisualStyleBackColor = true;
            this.btnUbicacionPdf.Click += new System.EventHandler(this.btnUbicacionPdf_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblTitulo.Location = new System.Drawing.Point(3, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(62, 18);
            this.lblTitulo.TabIndex = 319;
            this.lblTitulo.Text = "TITULO";
            // 
            // gbExpExcel
            // 
            this.gbExpExcel.Controls.Add(this.tbExcel);
            this.gbExpExcel.Controls.Add(this.btnExportarExcel);
            this.gbExpExcel.Controls.Add(this.botImpExcel);
            this.gbExpExcel.Controls.Add(this.progressBar);
            this.gbExpExcel.Location = new System.Drawing.Point(9, 304);
            this.gbExpExcel.Name = "gbExpExcel";
            this.gbExpExcel.Size = new System.Drawing.Size(364, 141);
            this.gbExpExcel.TabIndex = 328;
            this.gbExpExcel.TabStop = false;
            this.gbExpExcel.Text = "Exportacion Excel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPDF);
            this.groupBox1.Controls.Add(this.btnExportarPdf);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnUbicacionPdf);
            this.groupBox1.Location = new System.Drawing.Point(9, 451);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 141);
            this.groupBox1.TabIndex = 329;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exportacion PDF";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(887, 260);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 45);
            this.button1.TabIndex = 330;
            this.button1.Text = "Imprimir\r\nReporte\r\n";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnEmpresaAnterior
            // 
            this.btnEmpresaAnterior.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEmpresaAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpresaAnterior.ForeColor = System.Drawing.Color.Black;
            this.btnEmpresaAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpresaAnterior.Image")));
            this.btnEmpresaAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpresaAnterior.Location = new System.Drawing.Point(887, 103);
            this.btnEmpresaAnterior.Margin = new System.Windows.Forms.Padding(4);
            this.btnEmpresaAnterior.Name = "btnEmpresaAnterior";
            this.btnEmpresaAnterior.Size = new System.Drawing.Size(135, 45);
            this.btnEmpresaAnterior.TabIndex = 331;
            this.btnEmpresaAnterior.Text = "Anterior\r\nEmpresa";
            this.btnEmpresaAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmpresaAnterior.UseVisualStyleBackColor = true;
            this.btnEmpresaAnterior.Visible = false;
            this.btnEmpresaAnterior.Click += new System.EventHandler(this.btnEmpresaAnterior_Click);
            // 
            // frmMuestraFactPorEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 673);
            this.Controls.Add(this.btnEmpresaAnterior);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbExpExcel);
            this.Controls.Add(this.cbOperaciones);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.cbEmpresasSeleccionadas);
            this.Controls.Add(this.btnSiguienteEmpresa);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lbliva);
            this.Controls.Add(this.tbIVA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblUtilidadTotal);
            this.Controls.Add(this.tbSubTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCostoTotal);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvFacturaciones);
            this.Controls.Add(this.lbTitulo);
            this.Name = "frmMuestraFactPorEmpresa";
            this.Text = "Consulta Facturacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturaciones)).EndInit();
            this.gbExpExcel.ResumeLayout(false);
            this.gbExpExcel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSiguienteEmpresa;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lbliva;
        private System.Windows.Forms.TextBox tbIVA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUtilidadTotal;
        private System.Windows.Forms.TextBox tbSubTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCostoTotal;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvFacturaciones;
        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConsultaLaboral;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPrestacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Facturacion;
        private System.Windows.Forms.ComboBox cbEmpresasSeleccionadas;
        private System.Windows.Forms.ComboBox cbOperaciones;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.TextBox tbExcel;
        private System.Windows.Forms.Button botImpExcel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnExportarPdf;
        private System.Windows.Forms.TextBox tbPDF;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnUbicacionPdf;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbExpExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEmpresaAnterior;
    }
}