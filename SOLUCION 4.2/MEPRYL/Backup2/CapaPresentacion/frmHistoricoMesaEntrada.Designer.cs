namespace CapaPresentacion
{
    partial class frmHistoricoMesaEntrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistoricoMesaEntrada));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.botonLaboratorio = new System.Windows.Forms.Panel();
            this.botMostrarEstudios = new System.Windows.Forms.Button();
            this.butImprimirListado = new System.Windows.Forms.Button();
            this.butSalir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.botonT = new System.Windows.Forms.RadioButton();
            this.botonC = new System.Windows.Forms.RadioButton();
            this.botonEC = new System.Windows.Forms.RadioButton();
            this.botonP = new System.Windows.Forms.RadioButton();
            this.botonL = new System.Windows.Forms.RadioButton();
            this.botonR = new System.Windows.Forms.RadioButton();
            this.gbRango = new System.Windows.Forms.GroupBox();
            this.botBuscarFecha = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpHasta = new System.Windows.Forms.DateTimePicker();
            this.tpDesde = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.tbBusqueda = new System.Windows.Forms.TextBox();
            this.cboTipoBusqueda = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.idConsulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoExamen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoExamen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Examen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Liga = new System.Windows.Forms.DataGridViewImageColumn();
            this.Club = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LigaDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estudios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.botonRango = new System.Windows.Forms.Button();
            this.gbFecha = new System.Windows.Forms.GroupBox();
            this.tpFecha = new System.Windows.Forms.DateTimePicker();
            this.botonFecha = new System.Windows.Forms.Button();
            this.botonLaboratorio.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbRango.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.ForestGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1282, 40);
            this.lbTitulo.TabIndex = 129;
            this.lbTitulo.Text = "Histórico Mesa de Entrada";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // botonLaboratorio
            // 
            this.botonLaboratorio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botonLaboratorio.Controls.Add(this.botMostrarEstudios);
            this.botonLaboratorio.Controls.Add(this.butImprimirListado);
            this.botonLaboratorio.Controls.Add(this.butSalir);
            this.botonLaboratorio.Dock = System.Windows.Forms.DockStyle.Right;
            this.botonLaboratorio.Location = new System.Drawing.Point(1156, 40);
            this.botonLaboratorio.Name = "botonLaboratorio";
            this.botonLaboratorio.Size = new System.Drawing.Size(126, 586);
            this.botonLaboratorio.TabIndex = 130;
            // 
            // botMostrarEstudios
            // 
            this.botMostrarEstudios.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botMostrarEstudios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botMostrarEstudios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botMostrarEstudios.Image = ((System.Drawing.Image)(resources.GetObject("botMostrarEstudios.Image")));
            this.botMostrarEstudios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botMostrarEstudios.Location = new System.Drawing.Point(9, 11);
            this.botMostrarEstudios.Name = "botMostrarEstudios";
            this.botMostrarEstudios.Size = new System.Drawing.Size(111, 54);
            this.botMostrarEstudios.TabIndex = 263;
            this.botMostrarEstudios.Text = "Mostrar Estudios";
            this.botMostrarEstudios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botMostrarEstudios.UseVisualStyleBackColor = false;
            this.botMostrarEstudios.Click += new System.EventHandler(this.botMostrarEstudios_Click);
            // 
            // butImprimirListado
            // 
            this.butImprimirListado.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butImprimirListado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butImprimirListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butImprimirListado.Image = ((System.Drawing.Image)(resources.GetObject("butImprimirListado.Image")));
            this.butImprimirListado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimirListado.Location = new System.Drawing.Point(9, 266);
            this.butImprimirListado.Name = "butImprimirListado";
            this.butImprimirListado.Size = new System.Drawing.Size(111, 54);
            this.butImprimirListado.TabIndex = 262;
            this.butImprimirListado.Text = "Imprimir Listado";
            this.butImprimirListado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImprimirListado.UseVisualStyleBackColor = false;
            this.butImprimirListado.Click += new System.EventHandler(this.butImprimirListado_Click);
            // 
            // butSalir
            // 
            this.butSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
            this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSalir.Location = new System.Drawing.Point(0, 558);
            this.butSalir.Name = "butSalir";
            this.butSalir.Size = new System.Drawing.Size(126, 28);
            this.butSalir.TabIndex = 8;
            this.butSalir.Text = "&Salir [Esc]";
            this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.botonT);
            this.groupBox2.Controls.Add(this.botonC);
            this.groupBox2.Controls.Add(this.botonEC);
            this.groupBox2.Controls.Add(this.botonP);
            this.groupBox2.Controls.Add(this.botonL);
            this.groupBox2.Controls.Add(this.botonR);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(488, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 98);
            this.groupBox2.TabIndex = 131;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Motivo de Consulta";
            // 
            // botonT
            // 
            this.botonT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonT.Appearance = System.Windows.Forms.Appearance.Button;
            this.botonT.BackColor = System.Drawing.SystemColors.Control;
            this.botonT.Checked = true;
            this.botonT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonT.Location = new System.Drawing.Point(7, 69);
            this.botonT.Name = "botonT";
            this.botonT.Size = new System.Drawing.Size(225, 23);
            this.botonT.TabIndex = 30;
            this.botonT.TabStop = true;
            this.botonT.Text = "Todos";
            this.botonT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonT.UseVisualStyleBackColor = false;
            // 
            // botonC
            // 
            this.botonC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonC.Appearance = System.Windows.Forms.Appearance.Button;
            this.botonC.BackColor = System.Drawing.Color.LightSteelBlue;
            this.botonC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonC.Location = new System.Drawing.Point(150, 32);
            this.botonC.Name = "botonC";
            this.botonC.Size = new System.Drawing.Size(38, 35);
            this.botonC.TabIndex = 29;
            this.botonC.Text = "C";
            this.botonC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonC.UseVisualStyleBackColor = false;
            this.botonC.CheckedChanged += new System.EventHandler(this.botonC_CheckedChanged);
            // 
            // botonEC
            // 
            this.botonEC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonEC.Appearance = System.Windows.Forms.Appearance.Button;
            this.botonEC.BackColor = System.Drawing.Color.Azure;
            this.botonEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonEC.Location = new System.Drawing.Point(91, 32);
            this.botonEC.Name = "botonEC";
            this.botonEC.Size = new System.Drawing.Size(53, 35);
            this.botonEC.TabIndex = 27;
            this.botonEC.Text = "EC";
            this.botonEC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonEC.UseVisualStyleBackColor = false;
            this.botonEC.CheckedChanged += new System.EventHandler(this.botonEC_CheckedChanged);
            // 
            // botonP
            // 
            this.botonP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonP.Appearance = System.Windows.Forms.Appearance.Button;
            this.botonP.BackColor = System.Drawing.Color.MistyRose;
            this.botonP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonP.Location = new System.Drawing.Point(7, 32);
            this.botonP.Name = "botonP";
            this.botonP.Size = new System.Drawing.Size(37, 35);
            this.botonP.TabIndex = 25;
            this.botonP.Text = "P";
            this.botonP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonP.UseVisualStyleBackColor = false;
            this.botonP.CheckedChanged += new System.EventHandler(this.botonP_CheckedChanged);
            // 
            // botonL
            // 
            this.botonL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonL.Appearance = System.Windows.Forms.Appearance.Button;
            this.botonL.BackColor = System.Drawing.Color.Moccasin;
            this.botonL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonL.Location = new System.Drawing.Point(50, 32);
            this.botonL.Name = "botonL";
            this.botonL.Size = new System.Drawing.Size(35, 35);
            this.botonL.TabIndex = 26;
            this.botonL.Text = "L";
            this.botonL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonL.UseVisualStyleBackColor = false;
            this.botonL.CheckedChanged += new System.EventHandler(this.botonL_CheckedChanged);
            // 
            // botonR
            // 
            this.botonR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonR.Appearance = System.Windows.Forms.Appearance.Button;
            this.botonR.BackColor = System.Drawing.Color.LightYellow;
            this.botonR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonR.Location = new System.Drawing.Point(194, 32);
            this.botonR.Name = "botonR";
            this.botonR.Size = new System.Drawing.Size(38, 35);
            this.botonR.TabIndex = 28;
            this.botonR.Text = "R";
            this.botonR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.botonR.UseVisualStyleBackColor = false;
            this.botonR.CheckedChanged += new System.EventHandler(this.botonR_CheckedChanged);
            // 
            // gbRango
            // 
            this.gbRango.Controls.Add(this.botBuscarFecha);
            this.gbRango.Controls.Add(this.label2);
            this.gbRango.Controls.Add(this.label1);
            this.gbRango.Controls.Add(this.tpHasta);
            this.gbRango.Controls.Add(this.tpDesde);
            this.gbRango.Enabled = false;
            this.gbRango.Location = new System.Drawing.Point(192, 43);
            this.gbRango.Name = "gbRango";
            this.gbRango.Size = new System.Drawing.Size(290, 98);
            this.gbRango.TabIndex = 268;
            this.gbRango.TabStop = false;
            this.gbRango.Text = "Rango de Fechas";
            // 
            // botBuscarFecha
            // 
            this.botBuscarFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botBuscarFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botBuscarFecha.Image = ((System.Drawing.Image)(resources.GetObject("botBuscarFecha.Image")));
            this.botBuscarFecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botBuscarFecha.Location = new System.Drawing.Point(203, 32);
            this.botBuscarFecha.Name = "botBuscarFecha";
            this.botBuscarFecha.Size = new System.Drawing.Size(73, 58);
            this.botBuscarFecha.TabIndex = 267;
            this.botBuscarFecha.Text = "Buscar";
            this.botBuscarFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botBuscarFecha.Click += new System.EventHandler(this.botBuscarFecha_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde";
            // 
            // tpHasta
            // 
            this.tpHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpHasta.CustomFormat = "";
            this.tpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpHasta.Location = new System.Drawing.Point(66, 64);
            this.tpHasta.Name = "tpHasta";
            this.tpHasta.Size = new System.Drawing.Size(131, 26);
            this.tpHasta.TabIndex = 1;
            // 
            // tpDesde
            // 
            this.tpDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDesde.CustomFormat = "";
            this.tpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpDesde.Location = new System.Drawing.Point(66, 32);
            this.tpDesde.Name = "tpDesde";
            this.tpDesde.Size = new System.Drawing.Size(131, 26);
            this.tpDesde.TabIndex = 0;
            this.tpDesde.Value = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.botonLimpiar);
            this.groupBox3.Controls.Add(this.botonBuscar);
            this.groupBox3.Controls.Add(this.tbBusqueda);
            this.groupBox3.Controls.Add(this.cboTipoBusqueda);
            this.groupBox3.Location = new System.Drawing.Point(733, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(417, 98);
            this.groupBox3.TabIndex = 269;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Búsqueda";
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("botonLimpiar.Image")));
            this.botonLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonLimpiar.Location = new System.Drawing.Point(331, 32);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(77, 58);
            this.botonLimpiar.TabIndex = 267;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonBuscar
            // 
            this.botonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBuscar.Image = ((System.Drawing.Image)(resources.GetObject("botonBuscar.Image")));
            this.botonBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonBuscar.Location = new System.Drawing.Point(250, 32);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(75, 58);
            this.botonBuscar.TabIndex = 266;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusqueda.Location = new System.Drawing.Point(11, 64);
            this.tbBusqueda.Name = "tbBusqueda";
            this.tbBusqueda.Size = new System.Drawing.Size(233, 26);
            this.tbBusqueda.TabIndex = 265;
            this.tbBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBusqueda_KeyPress);
            // 
            // cboTipoBusqueda
            // 
            this.cboTipoBusqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoBusqueda.FormattingEnabled = true;
            this.cboTipoBusqueda.Items.AddRange(new object[] {
            "Tipo de Exámen",
            "Apellido",
            "DNI",
            "Categoria"});
            this.cboTipoBusqueda.Location = new System.Drawing.Point(11, 32);
            this.cboTipoBusqueda.Name = "cboTipoBusqueda";
            this.cboTipoBusqueda.Size = new System.Drawing.Size(233, 28);
            this.cboTipoBusqueda.TabIndex = 264;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.Silver;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idConsulta,
            this.idPaciente,
            this.idTipoExamen,
            this.Fecha,
            this.TipoExamen,
            this.Orden,
            this.Examen,
            this.Apellido,
            this.Nombre,
            this.DNI,
            this.Categoria,
            this.Liga,
            this.Club,
            this.Empresa,
            this.LigaDesc,
            this.Tipo,
            this.Estudios});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv.Location = new System.Drawing.Point(0, 172);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1156, 454);
            this.dgv.TabIndex = 270;
            // 
            // idConsulta
            // 
            this.idConsulta.HeaderText = "idConsulta";
            this.idConsulta.Name = "idConsulta";
            this.idConsulta.ReadOnly = true;
            this.idConsulta.Visible = false;
            this.idConsulta.Width = 62;
            // 
            // idPaciente
            // 
            this.idPaciente.HeaderText = "idPaciente";
            this.idPaciente.Name = "idPaciente";
            this.idPaciente.ReadOnly = true;
            this.idPaciente.Visible = false;
            this.idPaciente.Width = 63;
            // 
            // idTipoExamen
            // 
            this.idTipoExamen.HeaderText = "idTipoExamen";
            this.idTipoExamen.Name = "idTipoExamen";
            this.idTipoExamen.ReadOnly = true;
            this.idTipoExamen.Visible = false;
            this.idTipoExamen.Width = 80;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 62;
            // 
            // TipoExamen
            // 
            this.TipoExamen.HeaderText = "Examen";
            this.TipoExamen.Name = "TipoExamen";
            this.TipoExamen.ReadOnly = true;
            this.TipoExamen.Width = 70;
            // 
            // Orden
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Orden.DefaultCellStyle = dataGridViewCellStyle1;
            this.Orden.HeaderText = "Nº Orden";
            this.Orden.Name = "Orden";
            this.Orden.ReadOnly = true;
            this.Orden.Width = 76;
            // 
            // Examen
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Examen.DefaultCellStyle = dataGridViewCellStyle2;
            this.Examen.HeaderText = "Nº Examen";
            this.Examen.Name = "Examen";
            this.Examen.ReadOnly = true;
            this.Examen.Width = 85;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 69;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 69;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            this.DNI.Width = 51;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 77;
            // 
            // Liga
            // 
            this.Liga.HeaderText = "Liga";
            this.Liga.Image = ((System.Drawing.Image)(resources.GetObject("Liga.Image")));
            this.Liga.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Liga.Name = "Liga";
            this.Liga.ReadOnly = true;
            this.Liga.Width = 33;
            // 
            // Club
            // 
            this.Club.HeaderText = "Club";
            this.Club.Name = "Club";
            this.Club.ReadOnly = true;
            this.Club.Width = 53;
            // 
            // Empresa
            // 
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            this.Empresa.Width = 73;
            // 
            // LigaDesc
            // 
            this.LigaDesc.HeaderText = "LigaDesc";
            this.LigaDesc.Name = "LigaDesc";
            this.LigaDesc.ReadOnly = true;
            this.LigaDesc.Visible = false;
            this.LigaDesc.Width = 77;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Visible = false;
            this.Tipo.Width = 53;
            // 
            // Estudios
            // 
            this.Estudios.HeaderText = "Estudios";
            this.Estudios.Name = "Estudios";
            this.Estudios.ReadOnly = true;
            this.Estudios.Visible = false;
            this.Estudios.Width = 72;
            // 
            // tbTotal
            // 
            this.tbTotal.BackColor = System.Drawing.Color.ForestGreen;
            this.tbTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.ForeColor = System.Drawing.Color.White;
            this.tbTotal.Location = new System.Drawing.Point(0, 144);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(1156, 28);
            this.tbTotal.TabIndex = 271;
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.ForestGreen;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1234, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 40);
            this.pictureBox1.TabIndex = 272;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.ForestGreen;
            this.progressBar.Location = new System.Drawing.Point(325, 394);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(496, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 273;
            this.progressBar.Visible = false;
            // 
            // botonRango
            // 
            this.botonRango.BackColor = System.Drawing.Color.Transparent;
            this.botonRango.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonRango.BackgroundImage")));
            this.botonRango.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonRango.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRango.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.botonRango.Location = new System.Drawing.Point(152, 66);
            this.botonRango.Name = "botonRango";
            this.botonRango.Size = new System.Drawing.Size(34, 33);
            this.botonRango.TabIndex = 275;
            this.botonRango.UseVisualStyleBackColor = false;
            this.botonRango.Click += new System.EventHandler(this.botonRango_Click);
            // 
            // gbFecha
            // 
            this.gbFecha.Controls.Add(this.tpFecha);
            this.gbFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbFecha.Location = new System.Drawing.Point(5, 43);
            this.gbFecha.Name = "gbFecha";
            this.gbFecha.Size = new System.Drawing.Size(141, 98);
            this.gbFecha.TabIndex = 274;
            this.gbFecha.TabStop = false;
            this.gbFecha.Text = "Fecha";
            // 
            // tpFecha
            // 
            this.tpFecha.CustomFormat = "yyyy";
            this.tpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpFecha.Location = new System.Drawing.Point(16, 42);
            this.tpFecha.Name = "tpFecha";
            this.tpFecha.Size = new System.Drawing.Size(110, 26);
            this.tpFecha.TabIndex = 1;
            this.tpFecha.ValueChanged += new System.EventHandler(this.tpFecha_ValueChanged);
            // 
            // botonFecha
            // 
            this.botonFecha.BackColor = System.Drawing.Color.Transparent;
            this.botonFecha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonFecha.BackgroundImage")));
            this.botonFecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonFecha.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.botonFecha.Location = new System.Drawing.Point(152, 100);
            this.botonFecha.Name = "botonFecha";
            this.botonFecha.Size = new System.Drawing.Size(34, 33);
            this.botonFecha.TabIndex = 276;
            this.botonFecha.UseVisualStyleBackColor = false;
            this.botonFecha.Click += new System.EventHandler(this.botonFecha_Click);
            // 
            // frmHistoricoMesaEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 626);
            this.Controls.Add(this.botonRango);
            this.Controls.Add(this.gbFecha);
            this.Controls.Add(this.botonFecha);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbRango);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.botonLaboratorio);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHistoricoMesaEntrada";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histórico Mesa de Entrada";
            this.botonLaboratorio.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbRango.ResumeLayout(false);
            this.gbRango.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbFecha.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        protected System.Windows.Forms.Panel botonLaboratorio;
        protected System.Windows.Forms.Button butImprimirListado;
        protected System.Windows.Forms.Button butSalir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbRango;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker tpHasta;
        private System.Windows.Forms.DateTimePicker tpDesde;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbBusqueda;
        private System.Windows.Forms.ComboBox cboTipoBusqueda;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.RadioButton botonC;
        private System.Windows.Forms.RadioButton botonEC;
        private System.Windows.Forms.RadioButton botonP;
        private System.Windows.Forms.RadioButton botonL;
        private System.Windows.Forms.RadioButton botonR;
        private System.Windows.Forms.RadioButton botonT;
        protected System.Windows.Forms.Button botonBuscar;
        protected System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.Button botMostrarEstudios;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoExamen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoExamen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Examen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewImageColumn Liga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Club;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn LigaDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estudios;
        private System.Windows.Forms.ProgressBar progressBar;
        protected System.Windows.Forms.Button botBuscarFecha;
        private System.Windows.Forms.Button botonRango;
        private System.Windows.Forms.GroupBox gbFecha;
        private System.Windows.Forms.DateTimePicker tpFecha;
        private System.Windows.Forms.Button botonFecha;
    }
}