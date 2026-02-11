namespace CapaPresentacion
{
    partial class frmRecepcion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.tbBusqueda = new System.Windows.Forms.TextBox();
            this.botBuscarRango = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpHasta = new System.Windows.Forms.DateTimePicker();
            this.tpDesde = new System.Windows.Forms.DateTimePicker();
            this.botonRegistrar = new System.Windows.Forms.Button();
            this.botEditarPaciente = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbHora = new System.Windows.Forms.TextBox();
            this.botEditarExamen = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tpFecha = new System.Windows.Forms.DateTimePicker();
            this.botonRango = new System.Windows.Forms.Button();
            this.botonFecha = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdbMostrarTodo = new System.Windows.Forms.RadioButton();
            this.label20 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.rbcMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.bbiEditarPaciente = new DevExpress.XtraBars.BarButtonItem();
            this.bbiModificarEstudio = new DevExpress.XtraBars.BarButtonItem();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lblOcultos = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblExpIngreso = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("botonLimpiar.Image")));
            this.botonLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonLimpiar.Location = new System.Drawing.Point(257, 52);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(92, 32);
            this.botonLimpiar.TabIndex = 267;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonBuscar
            // 
            this.botonBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBuscar.Image = ((System.Drawing.Image)(resources.GetObject("botonBuscar.Image")));
            this.botonBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonBuscar.Location = new System.Drawing.Point(155, 52);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(92, 32);
            this.botonBuscar.TabIndex = 266;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusqueda.Location = new System.Drawing.Point(25, 25);
            this.tbBusqueda.Name = "tbBusqueda";
            this.tbBusqueda.Size = new System.Drawing.Size(324, 22);
            this.tbBusqueda.TabIndex = 265;
            this.tbBusqueda.TextChanged += new System.EventHandler(this.tbBusqueda_TextChanged);
            this.tbBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBusqueda_KeyPress);
            // 
            // botBuscarRango
            // 
            this.botBuscarRango.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botBuscarRango.Enabled = false;
            this.botBuscarRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botBuscarRango.Image = ((System.Drawing.Image)(resources.GetObject("botBuscarRango.Image")));
            this.botBuscarRango.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botBuscarRango.Location = new System.Drawing.Point(290, 35);
            this.botBuscarRango.Name = "botBuscarRango";
            this.botBuscarRango.Size = new System.Drawing.Size(94, 39);
            this.botBuscarRango.TabIndex = 267;
            this.botBuscarRango.Text = "Buscar";
            this.botBuscarRango.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botBuscarRango.UseVisualStyleBackColor = true;
            this.botBuscarRango.Click += new System.EventHandler(this.botBuscarRango_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde";
            // 
            // tpHasta
            // 
            this.tpHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpHasta.CustomFormat = "";
            this.tpHasta.Enabled = false;
            this.tpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpHasta.Location = new System.Drawing.Point(178, 71);
            this.tpHasta.Name = "tpHasta";
            this.tpHasta.Size = new System.Drawing.Size(104, 22);
            this.tpHasta.TabIndex = 1;
            // 
            // tpDesde
            // 
            this.tpDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDesde.CustomFormat = "";
            this.tpDesde.Enabled = false;
            this.tpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpDesde.Location = new System.Drawing.Point(178, 25);
            this.tpDesde.Name = "tpDesde";
            this.tpDesde.Size = new System.Drawing.Size(104, 22);
            this.tpDesde.TabIndex = 0;
            this.tpDesde.Value = new System.DateTime(2015, 12, 1, 9, 49, 0, 0);
            // 
            // botonRegistrar
            // 
            this.botonRegistrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botonRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRegistrar.ForeColor = System.Drawing.Color.Green;
            this.botonRegistrar.Image = ((System.Drawing.Image)(resources.GetObject("botonRegistrar.Image")));
            this.botonRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonRegistrar.Location = new System.Drawing.Point(200, 15);
            this.botonRegistrar.Name = "botonRegistrar";
            this.botonRegistrar.Size = new System.Drawing.Size(137, 57);
            this.botonRegistrar.TabIndex = 266;
            this.botonRegistrar.Text = "Registrar Ingreso";
            this.botonRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonRegistrar.UseCompatibleTextRendering = true;
            this.botonRegistrar.UseVisualStyleBackColor = true;
            this.botonRegistrar.Click += new System.EventHandler(this.botonRegistrar_Click);
            // 
            // botEditarPaciente
            // 
            this.botEditarPaciente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botEditarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEditarPaciente.Image = ((System.Drawing.Image)(resources.GetObject("botEditarPaciente.Image")));
            this.botEditarPaciente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEditarPaciente.Location = new System.Drawing.Point(13, 10);
            this.botEditarPaciente.Name = "botEditarPaciente";
            this.botEditarPaciente.Size = new System.Drawing.Size(150, 34);
            this.botEditarPaciente.TabIndex = 269;
            this.botEditarPaciente.Text = "Editar Paciente";
            this.botEditarPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEditarPaciente.UseVisualStyleBackColor = true;
            this.botEditarPaciente.Click += new System.EventHandler(this.botEditarPaciente_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv.ColumnHeadersHeight = 25;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 285);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.RowTemplate.Height = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1238, 339);
            this.dgv.TabIndex = 276;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CurrentCellChanged += new System.EventHandler(this.dgv_CurrentCellChanged);
            this.dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvTurno_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1238, 95);
            this.panel1.TabIndex = 277;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.tbHora);
            this.panel4.Controls.Add(this.botonRegistrar);
            this.panel4.Controls.Add(this.botEditarExamen);
            this.panel4.Controls.Add(this.botEditarPaciente);
            this.panel4.Location = new System.Drawing.Point(765, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(473, 90);
            this.panel4.TabIndex = 279;
            // 
            // tbHora
            // 
            this.tbHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.tbHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHora.ForeColor = System.Drawing.Color.Black;
            this.tbHora.Location = new System.Drawing.Point(348, 21);
            this.tbHora.Name = "tbHora";
            this.tbHora.ReadOnly = true;
            this.tbHora.Size = new System.Drawing.Size(105, 44);
            this.tbHora.TabIndex = 278;
            this.tbHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // botEditarExamen
            // 
            this.botEditarExamen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botEditarExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEditarExamen.Image = ((System.Drawing.Image)(resources.GetObject("botEditarExamen.Image")));
            this.botEditarExamen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEditarExamen.Location = new System.Drawing.Point(13, 46);
            this.botEditarExamen.Name = "botEditarExamen";
            this.botEditarExamen.Size = new System.Drawing.Size(150, 34);
            this.botEditarExamen.TabIndex = 270;
            this.botEditarExamen.Text = "Modif. Estudios";
            this.botEditarExamen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEditarExamen.UseVisualStyleBackColor = true;
            this.botEditarExamen.Click += new System.EventHandler(this.botEditarExamen_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(1132, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(97, 70);
            this.btnSalir.TabIndex = 276;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Visible = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tpFecha);
            this.panel2.Controls.Add(this.botonRango);
            this.panel2.Controls.Add(this.botonFecha);
            this.panel2.Controls.Add(this.botBuscarRango);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tpDesde);
            this.panel2.Controls.Add(this.tpHasta);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 94);
            this.panel2.TabIndex = 0;
            // 
            // tpFecha
            // 
            this.tpFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFecha.CustomFormat = "";
            this.tpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpFecha.Location = new System.Drawing.Point(11, 44);
            this.tpFecha.Name = "tpFecha";
            this.tpFecha.Size = new System.Drawing.Size(104, 22);
            this.tpFecha.TabIndex = 270;
            this.tpFecha.ValueChanged += new System.EventHandler(this.tpFecha_ValueChanged);
            // 
            // botonRango
            // 
            this.botonRango.BackColor = System.Drawing.Color.Transparent;
            this.botonRango.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonRango.BackgroundImage")));
            this.botonRango.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonRango.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRango.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.botonRango.Location = new System.Drawing.Point(128, 19);
            this.botonRango.Name = "botonRango";
            this.botonRango.Size = new System.Drawing.Size(34, 33);
            this.botonRango.TabIndex = 268;
            this.botonRango.UseVisualStyleBackColor = false;
            this.botonRango.Click += new System.EventHandler(this.botonRango_Click);
            // 
            // botonFecha
            // 
            this.botonFecha.BackColor = System.Drawing.Color.Transparent;
            this.botonFecha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonFecha.BackgroundImage")));
            this.botonFecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonFecha.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.botonFecha.Location = new System.Drawing.Point(128, 53);
            this.botonFecha.Name = "botonFecha";
            this.botonFecha.Size = new System.Drawing.Size(34, 33);
            this.botonFecha.TabIndex = 269;
            this.botonFecha.UseVisualStyleBackColor = false;
            this.botonFecha.Click += new System.EventHandler(this.botonFecha_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.rdbMostrarTodo);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.botonLimpiar);
            this.panel3.Controls.Add(this.botonBuscar);
            this.panel3.Controls.Add(this.tbBusqueda);
            this.panel3.Location = new System.Drawing.Point(392, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(373, 90);
            this.panel3.TabIndex = 1;
            // 
            // rdbMostrarTodo
            // 
            this.rdbMostrarTodo.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbMostrarTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbMostrarTodo.Image = ((System.Drawing.Image)(resources.GetObject("rdbMostrarTodo.Image")));
            this.rdbMostrarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdbMostrarTodo.Location = new System.Drawing.Point(25, 52);
            this.rdbMostrarTodo.Name = "rdbMostrarTodo";
            this.rdbMostrarTodo.Size = new System.Drawing.Size(105, 32);
            this.rdbMostrarTodo.TabIndex = 270;
            this.rdbMostrarTodo.Text = "Mostrar";
            this.rdbMostrarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbMostrarTodo.UseVisualStyleBackColor = true;
            this.rdbMostrarTodo.CheckedChanged += new System.EventHandler(this.rdbMostrarTodo_CheckedChanged);
            this.rdbMostrarTodo.Click += new System.EventHandler(this.rdbMostrarTodo_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(22, 5);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(102, 16);
            this.label20.TabIndex = 268;
            this.label20.Text = "Búsqueda Libre";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // rbcMenu
            // 
            this.rbcMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
            // 
            // 
            // 
            this.rbcMenu.ExpandCollapseItem.Id = 0;
            this.rbcMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbcMenu.ExpandCollapseItem});
            this.rbcMenu.Location = new System.Drawing.Point(0, 0);
            this.rbcMenu.MaxItemId = 5;
            this.rbcMenu.Name = "rbcMenu";
            this.rbcMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.rbcMenu.Size = new System.Drawing.Size(1238, 139);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Ventanilla";
            this.ribbonPage1.Visible = false;
            // 
            // bbiEditarPaciente
            // 
            this.bbiEditarPaciente.Id = 3;
            this.bbiEditarPaciente.Name = "bbiEditarPaciente";
            // 
            // bbiModificarEstudio
            // 
            this.bbiModificarEstudio.Id = 4;
            this.bbiModificarEstudio.Name = "bbiModificarEstudio";
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SeaGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 139);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1238, 25);
            this.lbTitulo.TabIndex = 280;
            this.lbTitulo.Text = "   Ventanilla";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOcultos
            // 
            this.lblOcultos.BackColor = System.Drawing.Color.SeaGreen;
            this.lblOcultos.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblOcultos.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblOcultos.ForeColor = System.Drawing.Color.White;
            this.lblOcultos.Location = new System.Drawing.Point(1072, 0);
            this.lblOcultos.Name = "lblOcultos";
            this.lblOcultos.Size = new System.Drawing.Size(166, 26);
            this.lblOcultos.TabIndex = 283;
            this.lblOcultos.Text = "Ocultos";
            this.lblOcultos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblExpIngreso);
            this.panel5.Controls.Add(this.lblResultado);
            this.panel5.Controls.Add(this.lblOcultos);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 259);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1238, 26);
            this.panel5.TabIndex = 284;
            // 
            // lblExpIngreso
            // 
            this.lblExpIngreso.BackColor = System.Drawing.Color.SeaGreen;
            this.lblExpIngreso.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblExpIngreso.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblExpIngreso.ForeColor = System.Drawing.Color.White;
            this.lblExpIngreso.Location = new System.Drawing.Point(0, 0);
            this.lblExpIngreso.Name = "lblExpIngreso";
            this.lblExpIngreso.Size = new System.Drawing.Size(250, 26);
            this.lblExpIngreso.TabIndex = 285;
            this.lblExpIngreso.Text = "Exp. Ingreso : 0";
            this.lblExpIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResultado
            // 
            this.lblResultado.BackColor = System.Drawing.Color.SeaGreen;
            this.lblResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResultado.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblResultado.ForeColor = System.Drawing.Color.White;
            this.lblResultado.Location = new System.Drawing.Point(0, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(1072, 26);
            this.lblResultado.TabIndex = 280;
            this.lblResultado.Text = "Total Pacientes";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRecepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 624);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.rbcMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmRecepcion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventanilla";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRecepcion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.TextBox tbBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker tpHasta;
        private System.Windows.Forms.DateTimePicker tpDesde;
        private System.Windows.Forms.Button botonRegistrar;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button botEditarPaciente;
        private System.Windows.Forms.Button botBuscarRango;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox tbHora;
        private System.Windows.Forms.Button botEditarExamen;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnSalir;
        private DevExpress.XtraBars.Ribbon.RibbonControl rbcMenu;
        private DevExpress.XtraBars.BarButtonItem bbiEditarPaciente;
        private DevExpress.XtraBars.BarButtonItem bbiModificarEstudio;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdbMostrarTodo;
        private System.Windows.Forms.Label lblOcultos;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblExpIngreso;
        private System.Windows.Forms.DateTimePicker tpFecha;
        private System.Windows.Forms.Button botonRango;
        private System.Windows.Forms.Button botonFecha;
    }
}