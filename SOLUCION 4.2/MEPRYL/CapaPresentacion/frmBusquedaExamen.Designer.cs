using System.Windows.Forms;

namespace CapaPresentacion
{
    partial class frmBusquedaExamen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaExamen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panCentro = new System.Windows.Forms.Panel();
            this.panelCambioDeClub = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tbRow = new System.Windows.Forms.TextBox();
            this.lblJugador = new System.Windows.Forms.Label();
            this.botCerrar = new System.Windows.Forms.Button();
            this.panelNuevoClub = new System.Windows.Forms.Panel();
            this.botGuardar = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.cboClub = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboLiga = new System.Windows.Forms.ComboBox();
            this.botEliminar = new System.Windows.Forms.Button();
            this.botAgregar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvClub = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvExamenes = new System.Windows.Forms.DataGridView();
            this.idTe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Liga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Club = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCLI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLI = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtLAB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAB = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtRX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RX = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtCAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAR = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtDICT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DICF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RM = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtIMP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMP = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtIMPLAB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPLAB = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtINF = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.INF = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtConsolidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONS = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtEnviado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enviado = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblCantReg = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pgrBarraProgreso = new System.Windows.Forms.ProgressBar();
            this.gbFecha = new System.Windows.Forms.GroupBox();
            this.tpFecha = new System.Windows.Forms.DateTimePicker();
            this.gbRango = new System.Windows.Forms.GroupBox();
            this.botBuscar = new System.Windows.Forms.Button();
            this.tpHasta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tpDesde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.botonRango = new System.Windows.Forms.Button();
            this.botonFecha = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboD = new System.Windows.Forms.ComboBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cboTipoBusqueda = new System.Windows.Forms.ComboBox();
            this.cboL = new System.Windows.Forms.ComboBox();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.tbBusqueda = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboC = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCantFis = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbImpLab = new System.Windows.Forms.TextBox();
            this.txtCantLab = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCantRX = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCantCar = new System.Windows.Forms.TextBox();
            this.tbImpEx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNoCarg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.botRevalidarCondicionales = new System.Windows.Forms.Button();
            this.botonHabilitarInabiitar = new System.Windows.Forms.Button();
            this.botEliminarExamen = new System.Windows.Forms.Button();
            this.botImportarMovil = new System.Windows.Forms.Button();
            this.botonCambiarClub = new System.Windows.Forms.Button();
            this.botECGAuto = new System.Windows.Forms.Button();
            this.botonRx = new System.Windows.Forms.Button();
            this.botImportar = new System.Windows.Forms.Button();
            this.botonRevalidar = new System.Windows.Forms.Button();
            this.botMail = new System.Windows.Forms.Button();
            this.botImprimir = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerActualizaEstados = new System.Windows.Forms.Timer(this.components);
            this.rbcMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiImportarJugador = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImportarLaboratorio = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHabilitar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCambioClub = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRevalidacion = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRXAutomatico = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEcgAutomatico = new DevExpress.XtraBars.BarButtonItem();
            this.bbiConsolidarEstudios = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportarPDF = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEnviarEmail = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExpMedida = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExpWeb = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDataSMS = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportarMesaEnt = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAudiometria = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditarPaciente = new DevExpress.XtraBars.BarButtonItem();
            this.rbpExamenPre = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.panCentro.SuspendLayout();
            this.panelCambioDeClub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelNuevoClub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamenes)).BeginInit();
            this.panel2.SuspendLayout();
            this.gbFecha.SuspendLayout();
            this.gbRango.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).BeginInit();
            this.SuspendLayout();

            this.ribbonPageGroup1.ItemLinks.Add(this.bbiImportarJugador);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiImportarLaboratorio);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiHabilitar);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiCambioClub);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRevalidacion);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRXAutomatico);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEcgAutomatico);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiConsolidarEstudios);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiExportarPDF);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiAudiometria);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEnviarEmail);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEditarPaciente);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEliminar);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiImprimir);
            // 
            // panCentro
            // 
            this.panCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panCentro.Controls.Add(this.panelCambioDeClub);
            this.panCentro.Controls.Add(this.dgvExamenes);
            this.panCentro.Controls.Add(this.lblCantReg);
            this.panCentro.Controls.Add(this.panel2);
            this.panCentro.Controls.Add(this.panel1);
            this.panCentro.Controls.Add(this.lbTitulo);
            this.panCentro.Controls.Add(this.gbFiltros);
            this.panCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panCentro.Location = new System.Drawing.Point(0, 139);
            this.panCentro.Name = "panCentro";
            this.panCentro.Size = new System.Drawing.Size(1323, 583);
            this.panCentro.TabIndex = 6;
            // 
            // panelCambioDeClub
            // 
            this.panelCambioDeClub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelCambioDeClub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCambioDeClub.Controls.Add(this.pictureBox3);
            this.panelCambioDeClub.Controls.Add(this.tbRow);
            this.panelCambioDeClub.Controls.Add(this.lblJugador);
            this.panelCambioDeClub.Controls.Add(this.botCerrar);
            this.panelCambioDeClub.Controls.Add(this.panelNuevoClub);
            this.panelCambioDeClub.Controls.Add(this.botEliminar);
            this.panelCambioDeClub.Controls.Add(this.botAgregar);
            this.panelCambioDeClub.Controls.Add(this.label12);
            this.panelCambioDeClub.Controls.Add(this.dgvClub);
            this.panelCambioDeClub.Controls.Add(this.label13);
            this.panelCambioDeClub.Location = new System.Drawing.Point(383, 138);
            this.panelCambioDeClub.Name = "panelCambioDeClub";
            this.panelCambioDeClub.Size = new System.Drawing.Size(515, 381);
            this.panelCambioDeClub.TabIndex = 284;
            this.panelCambioDeClub.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(18, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(42, 39);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // tbRow
            // 
            this.tbRow.Location = new System.Drawing.Point(337, 179);
            this.tbRow.Name = "tbRow";
            this.tbRow.Size = new System.Drawing.Size(33, 21);
            this.tbRow.TabIndex = 10;
            this.tbRow.Visible = false;
            // 
            // lblJugador
            // 
            this.lblJugador.AutoSize = true;
            this.lblJugador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJugador.Location = new System.Drawing.Point(67, 32);
            this.lblJugador.Name = "lblJugador";
            this.lblJugador.Size = new System.Drawing.Size(0, 20);
            this.lblJugador.TabIndex = 9;
            // 
            // botCerrar
            // 
            this.botCerrar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.botCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCerrar.Location = new System.Drawing.Point(189, 337);
            this.botCerrar.Name = "botCerrar";
            this.botCerrar.Size = new System.Drawing.Size(135, 35);
            this.botCerrar.TabIndex = 8;
            this.botCerrar.Text = "Volver";
            this.botCerrar.UseVisualStyleBackColor = true;
            this.botCerrar.Click += new System.EventHandler(this.botCerrar_Click);
            // 
            // panelNuevoClub
            // 
            this.panelNuevoClub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNuevoClub.Controls.Add(this.botGuardar);
            this.panelNuevoClub.Controls.Add(this.label15);
            this.panelNuevoClub.Controls.Add(this.cboClub);
            this.panelNuevoClub.Controls.Add(this.label14);
            this.panelNuevoClub.Controls.Add(this.cboLiga);
            this.panelNuevoClub.Location = new System.Drawing.Point(18, 212);
            this.panelNuevoClub.Name = "panelNuevoClub";
            this.panelNuevoClub.Size = new System.Drawing.Size(479, 119);
            this.panelNuevoClub.TabIndex = 6;
            this.panelNuevoClub.Visible = false;
            // 
            // botGuardar
            // 
            this.botGuardar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.botGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botGuardar.Location = new System.Drawing.Point(378, 26);
            this.botGuardar.Name = "botGuardar";
            this.botGuardar.Size = new System.Drawing.Size(86, 74);
            this.botGuardar.TabIndex = 7;
            this.botGuardar.Text = "Guardar";
            this.botGuardar.UseVisualStyleBackColor = true;
            this.botGuardar.Click += new System.EventHandler(this.botGuardar_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 16);
            this.label15.TabIndex = 6;
            this.label15.Text = "Club";
            // 
            // cboClub
            // 
            this.cboClub.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboClub.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClub.FormattingEnabled = true;
            this.cboClub.Location = new System.Drawing.Point(6, 76);
            this.cboClub.Name = "cboClub";
            this.cboClub.Size = new System.Drawing.Size(355, 24);
            this.cboClub.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 16);
            this.label14.TabIndex = 4;
            this.label14.Text = "Liga";
            // 
            // cboLiga
            // 
            this.cboLiga.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboLiga.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLiga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboLiga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLiga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLiga.FormattingEnabled = true;
            this.cboLiga.Location = new System.Drawing.Point(6, 26);
            this.cboLiga.Name = "cboLiga";
            this.cboLiga.Size = new System.Drawing.Size(355, 24);
            this.cboLiga.TabIndex = 0;
            this.cboLiga.SelectionChangeCommitted += new System.EventHandler(this.cboLiga_SelectionChangeCommitted);
            // 
            // botEliminar
            // 
            this.botEliminar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.botEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEliminar.Location = new System.Drawing.Point(159, 172);
            this.botEliminar.Name = "botEliminar";
            this.botEliminar.Size = new System.Drawing.Size(135, 33);
            this.botEliminar.TabIndex = 5;
            this.botEliminar.Text = "Eliminar";
            this.botEliminar.UseVisualStyleBackColor = true;
            this.botEliminar.Click += new System.EventHandler(this.botEliminar_Click);
            // 
            // botAgregar
            // 
            this.botAgregar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.botAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAgregar.Location = new System.Drawing.Point(18, 172);
            this.botAgregar.Name = "botAgregar";
            this.botAgregar.Size = new System.Drawing.Size(135, 33);
            this.botAgregar.TabIndex = 4;
            this.botAgregar.Text = "Agregar";
            this.botAgregar.UseVisualStyleBackColor = true;
            this.botAgregar.Click += new System.EventHandler(this.botAgregar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "Actual";
            // 
            // dgvClub
            // 
            this.dgvClub.AllowUserToAddRows = false;
            this.dgvClub.AllowUserToDeleteRows = false;
            this.dgvClub.AllowUserToResizeColumns = false;
            this.dgvClub.AllowUserToResizeRows = false;
            this.dgvClub.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClub.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvClub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClub.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClub.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvClub.Location = new System.Drawing.Point(18, 83);
            this.dgvClub.Name = "dgvClub";
            this.dgvClub.ReadOnly = true;
            this.dgvClub.RowHeadersVisible = false;
            this.dgvClub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClub.Size = new System.Drawing.Size(479, 83);
            this.dgvClub.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(66, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(201, 29);
            this.label13.TabIndex = 1;
            this.label13.Text = "Cambio de Club";
            // 
            // dgvExamenes
            // 
            this.dgvExamenes.AllowUserToAddRows = false;
            this.dgvExamenes.AllowUserToDeleteRows = false;
            this.dgvExamenes.BackgroundColor = System.Drawing.Color.White;
            this.dgvExamenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTe,
            this.idC,
            this.Fecha,
            this.NEx,
            this.Liga,
            this.Club,
            this.Categoria,
            this.DNI,
            this.Paciente,
            this.txtCLI,
            this.CLI,
            this.txtLAB,
            this.LAB,
            this.txtRX,
            this.RX,
            this.txtCAR,
            this.CAR,
            this.txtDICT,
            this.DICF,
            this.RM,
            this.txtIMP,
            this.IMP,
            this.txtIMPLAB,
            this.IMPLAB,
            this.txtINF,
            this.INF,
            this.txtConsolidado,
            this.CONS,
            this.txtEnviado,
            this.Enviado});
            this.dgvExamenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExamenes.Location = new System.Drawing.Point(0, 172);
            this.dgvExamenes.Name = "dgvExamenes";
            this.dgvExamenes.RowHeadersWidth = 30;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvExamenes.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvExamenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvExamenes.Size = new System.Drawing.Size(1323, 375);
            this.dgvExamenes.TabIndex = 128;
            this.dgvExamenes.VirtualMode = true;
            this.dgvExamenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamenes_CellClick);
            this.dgvExamenes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamenes_CellDoubleClick);
            this.dgvExamenes.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvExamenes_CellValueNeeded);
            this.dgvExamenes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvExamenes_KeyDown);
            // 
            // idTe
            // 
            this.idTe.HeaderText = "idTe";
            this.idTe.Name = "idTe";
            this.idTe.Visible = false;
            this.idTe.Width = 53;
            // 
            // idC
            // 
            this.idC.HeaderText = "idC";
            this.idC.Name = "idC";
            this.idC.Visible = false;
            this.idC.Width = 47;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 62;
            // 
            // NEx
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NEx.DefaultCellStyle = dataGridViewCellStyle2;
            this.NEx.HeaderText = "N° Ex.";
            this.NEx.Name = "NEx";
            this.NEx.ReadOnly = true;
            this.NEx.Width = 62;
            // 
            // Liga
            // 
            this.Liga.HeaderText = "Liga";
            this.Liga.Name = "Liga";
            this.Liga.Width = 52;
            // 
            // Club
            // 
            this.Club.HeaderText = "Club";
            this.Club.Name = "Club";
            this.Club.Width = 53;
            // 
            // Categoria
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Categoria.DefaultCellStyle = dataGridViewCellStyle3;
            this.Categoria.HeaderText = "Categ.";
            this.Categoria.Name = "Categoria";
            this.Categoria.Width = 63;
            // 
            // DNI
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DNI.DefaultCellStyle = dataGridViewCellStyle4;
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            this.DNI.Width = 51;
            // 
            // Paciente
            // 
            this.Paciente.HeaderText = "Paciente";
            this.Paciente.Name = "Paciente";
            this.Paciente.ReadOnly = true;
            this.Paciente.Width = 74;
            // 
            // txtCLI
            // 
            this.txtCLI.HeaderText = "txtCLI";
            this.txtCLI.Name = "txtCLI";
            this.txtCLI.Visible = false;
            this.txtCLI.Width = 59;
            // 
            // CLI
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CLI.DefaultCellStyle = dataGridViewCellStyle5;
            this.CLI.HeaderText = "CLI";
            this.CLI.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.CLI.Name = "CLI";
            this.CLI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CLI.Width = 29;
            // 
            // txtLAB
            // 
            this.txtLAB.HeaderText = "txtLAB";
            this.txtLAB.Name = "txtLAB";
            this.txtLAB.Visible = false;
            this.txtLAB.Width = 63;
            // 
            // LAB
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LAB.DefaultCellStyle = dataGridViewCellStyle6;
            this.LAB.HeaderText = "LAB";
            this.LAB.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.LAB.Name = "LAB";
            this.LAB.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LAB.Width = 33;
            // 
            // txtRX
            // 
            this.txtRX.HeaderText = "txtRX";
            this.txtRX.Name = "txtRX";
            this.txtRX.Visible = false;
            this.txtRX.Width = 58;
            // 
            // RX
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RX.DefaultCellStyle = dataGridViewCellStyle7;
            this.RX.HeaderText = "RX";
            this.RX.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.RX.Name = "RX";
            this.RX.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RX.Width = 28;
            // 
            // txtCAR
            // 
            this.txtCAR.HeaderText = "txtCAR";
            this.txtCAR.Name = "txtCAR";
            this.txtCAR.Visible = false;
            this.txtCAR.Width = 65;
            // 
            // CAR
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CAR.DefaultCellStyle = dataGridViewCellStyle8;
            this.CAR.HeaderText = "ECG";
            this.CAR.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.CAR.Name = "CAR";
            this.CAR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CAR.Width = 35;
            // 
            // txtDICT
            // 
            this.txtDICT.HeaderText = "txtDIC";
            this.txtDICT.Name = "txtDICT";
            this.txtDICT.Visible = false;
            this.txtDICT.Width = 61;
            // 
            // DICF
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DICF.DefaultCellStyle = dataGridViewCellStyle9;
            this.DICF.HeaderText = "Dictámen Final";
            this.DICF.Name = "DICF";
            this.DICF.ReadOnly = true;
            this.DICF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DICF.Width = 102;
            // 
            // RM
            // 
            this.RM.HeaderText = "RM";
            this.RM.Name = "RM";
            this.RM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RM.Width = 49;
            // 
            // txtIMP
            // 
            this.txtIMP.HeaderText = "txtIMP";
            this.txtIMP.Name = "txtIMP";
            this.txtIMP.Visible = false;
            this.txtIMP.Width = 62;
            // 
            // IMP
            // 
            this.IMP.HeaderText = "EXP-C";
            this.IMP.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.IMP.Name = "IMP";
            this.IMP.ReadOnly = true;
            this.IMP.Width = 42;
            // 
            // txtIMPLAB
            // 
            this.txtIMPLAB.HeaderText = "txtIMPLAB";
            this.txtIMPLAB.Name = "txtIMPLAB";
            this.txtIMPLAB.Visible = false;
            this.txtIMPLAB.Width = 82;
            // 
            // IMPLAB
            // 
            this.IMPLAB.HeaderText = "EXP-L";
            this.IMPLAB.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.IMPLAB.Name = "IMPLAB";
            this.IMPLAB.Width = 41;
            // 
            // txtINF
            // 
            this.txtINF.HeaderText = "RET";
            this.txtINF.Name = "txtINF";
            this.txtINF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtINF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.txtINF.Visible = false;
            this.txtINF.Width = 54;
            // 
            // INF
            // 
            this.INF.HeaderText = "INF";
            this.INF.Name = "INF";
            this.INF.ReadOnly = true;
            this.INF.Visible = false;
            this.INF.Width = 30;
            // 
            // txtConsolidado
            // 
            this.txtConsolidado.HeaderText = "txtConsolidado";
            this.txtConsolidado.Name = "txtConsolidado";
            this.txtConsolidado.Visible = false;
            // 
            // CONS
            // 
            this.CONS.HeaderText = "CONS";
            this.CONS.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.CONS.Name = "CONS";
            this.CONS.Width = 41;
            // 
            // txtEnviado
            // 
            this.txtEnviado.HeaderText = "txtEnviado";
            this.txtEnviado.Name = "txtEnviado";
            this.txtEnviado.Visible = false;
            this.txtEnviado.Width = 82;
            // 
            // Enviado
            // 
            this.Enviado.HeaderText = "ENV";
            this.Enviado.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Enviado.Name = "Enviado";
            this.Enviado.Width = 35;
            // 
            // lblCantReg
            // 
            this.lblCantReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.lblCantReg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCantReg.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantReg.ForeColor = System.Drawing.Color.White;
            this.lblCantReg.Location = new System.Drawing.Point(0, 148);
            this.lblCantReg.Name = "lblCantReg";
            this.lblCantReg.Size = new System.Drawing.Size(1323, 24);
            this.lblCantReg.TabIndex = 127;
            this.lblCantReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.pgrBarraProgreso);
            this.panel2.Controls.Add(this.gbFecha);
            this.panel2.Controls.Add(this.gbRango);
            this.panel2.Controls.Add(this.botonRango);
            this.panel2.Controls.Add(this.botonFecha);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1323, 123);
            this.panel2.TabIndex = 291;
            // 
            // pgrBarraProgreso
            // 
            this.pgrBarraProgreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pgrBarraProgreso.Location = new System.Drawing.Point(15, 95);
            this.pgrBarraProgreso.Name = "pgrBarraProgreso";
            this.pgrBarraProgreso.Size = new System.Drawing.Size(498, 16);
            this.pgrBarraProgreso.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgrBarraProgreso.TabIndex = 291;
            this.pgrBarraProgreso.Visible = false;
            // 
            // gbFecha
            // 
            this.gbFecha.Controls.Add(this.tpFecha);
            this.gbFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbFecha.Location = new System.Drawing.Point(12, 4);
            this.gbFecha.Name = "gbFecha";
            this.gbFecha.Size = new System.Drawing.Size(125, 85);
            this.gbFecha.TabIndex = 26;
            this.gbFecha.TabStop = false;
            // 
            // tpFecha
            // 
            this.tpFecha.CalendarMonthBackground = System.Drawing.Color.White;
            this.tpFecha.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.tpFecha.CalendarTitleForeColor = System.Drawing.Color.White;
            this.tpFecha.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.tpFecha.CustomFormat = "yyyy";
            this.tpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpFecha.Location = new System.Drawing.Point(9, 40);
            this.tpFecha.Name = "tpFecha";
            this.tpFecha.Size = new System.Drawing.Size(106, 22);
            this.tpFecha.TabIndex = 1;
            this.tpFecha.ValueChanged += new System.EventHandler(this.tpFecha_ValueChanged);
            // 
            // gbRango
            // 
            this.gbRango.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbRango.Controls.Add(this.botBuscar);
            this.gbRango.Controls.Add(this.tpHasta);
            this.gbRango.Controls.Add(this.label5);
            this.gbRango.Controls.Add(this.tpDesde);
            this.gbRango.Controls.Add(this.label4);
            this.gbRango.Enabled = false;
            this.gbRango.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbRango.Location = new System.Drawing.Point(178, 4);
            this.gbRango.Name = "gbRango";
            this.gbRango.Size = new System.Drawing.Size(343, 81);
            this.gbRango.TabIndex = 25;
            this.gbRango.TabStop = false;
            // 
            // botBuscar
            // 
            this.botBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botBuscar.Image = ((System.Drawing.Image)(resources.GetObject("botBuscar.Image")));
            this.botBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botBuscar.Location = new System.Drawing.Point(249, 32);
            this.botBuscar.Name = "botBuscar";
            this.botBuscar.Size = new System.Drawing.Size(86, 33);
            this.botBuscar.TabIndex = 271;
            this.botBuscar.Text = "Buscar";
            this.botBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botBuscar.Click += new System.EventHandler(this.botBuscar_Click);
            // 
            // tpHasta
            // 
            this.tpHasta.CalendarMonthBackground = System.Drawing.Color.White;
            this.tpHasta.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.tpHasta.CalendarTitleForeColor = System.Drawing.Color.White;
            this.tpHasta.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.tpHasta.CustomFormat = "yyyy";
            this.tpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpHasta.Location = new System.Drawing.Point(129, 40);
            this.tpHasta.Name = "tpHasta";
            this.tpHasta.Size = new System.Drawing.Size(110, 22);
            this.tpHasta.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(130, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Hasta";
            // 
            // tpDesde
            // 
            this.tpDesde.CalendarMonthBackground = System.Drawing.Color.White;
            this.tpDesde.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.tpDesde.CalendarTitleForeColor = System.Drawing.Color.White;
            this.tpDesde.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.tpDesde.CustomFormat = "yyyy";
            this.tpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpDesde.Location = new System.Drawing.Point(5, 40);
            this.tpDesde.Name = "tpDesde";
            this.tpDesde.Size = new System.Drawing.Size(110, 22);
            this.tpDesde.TabIndex = 1;
            this.tpDesde.Value = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Desde";
            // 
            // botonRango
            // 
            this.botonRango.BackColor = System.Drawing.Color.Transparent;
            this.botonRango.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonRango.BackgroundImage")));
            this.botonRango.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonRango.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRango.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.botonRango.Location = new System.Drawing.Point(141, 21);
            this.botonRango.Name = "botonRango";
            this.botonRango.Size = new System.Drawing.Size(34, 33);
            this.botonRango.TabIndex = 27;
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
            this.botonFecha.Location = new System.Drawing.Point(141, 55);
            this.botonFecha.Name = "botonFecha";
            this.botonFecha.Size = new System.Drawing.Size(34, 33);
            this.botonFecha.TabIndex = 28;
            this.botonFecha.UseVisualStyleBackColor = false;
            this.botonFecha.Click += new System.EventHandler(this.botonFecha_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox1.Controls.Add(this.cboD);
            this.groupBox1.Controls.Add(this.botonBuscar);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cboTipoBusqueda);
            this.groupBox1.Controls.Add(this.cboL);
            this.groupBox1.Controls.Add(this.botonLimpiar);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.tbBusqueda);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.cboC);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(527, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 107);
            this.groupBox1.TabIndex = 286;
            this.groupBox1.TabStop = false;
            // 
            // cboD
            // 
            this.cboD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboD.FormattingEnabled = true;
            this.cboD.Items.AddRange(new object[] {
            "Paciente",
            "DNI"});
            this.cboD.Location = new System.Drawing.Point(451, 33);
            this.cboD.Name = "cboD";
            this.cboD.Size = new System.Drawing.Size(200, 24);
            this.cboD.TabIndex = 286;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonBuscar.Image = ((System.Drawing.Image)(resources.GetObject("botonBuscar.Image")));
            this.botonBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonBuscar.Location = new System.Drawing.Point(452, 64);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(90, 33);
            this.botonBuscar.TabIndex = 288;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(447, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 16);
            this.label22.TabIndex = 287;
            this.label22.Text = "Dictámen";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(205, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 16);
            this.label21.TabIndex = 285;
            this.label21.Text = "Liga";
            // 
            // cboTipoBusqueda
            // 
            this.cboTipoBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoBusqueda.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoBusqueda.FormattingEnabled = true;
            this.cboTipoBusqueda.Items.AddRange(new object[] {
            "Paciente",
            "DNI"});
            this.cboTipoBusqueda.Location = new System.Drawing.Point(11, 33);
            this.cboTipoBusqueda.Name = "cboTipoBusqueda";
            this.cboTipoBusqueda.Size = new System.Drawing.Size(181, 24);
            this.cboTipoBusqueda.TabIndex = 268;
            // 
            // cboL
            // 
            this.cboL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboL.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboL.FormattingEnabled = true;
            this.cboL.Items.AddRange(new object[] {
            "Paciente",
            "DNI"});
            this.cboL.Location = new System.Drawing.Point(247, 33);
            this.cboL.Name = "cboL";
            this.cboL.Size = new System.Drawing.Size(191, 24);
            this.cboL.TabIndex = 282;
            this.cboL.SelectedIndexChanged += new System.EventHandler(this.cboL_SelectedIndexChanged);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("botonLimpiar.Image")));
            this.botonLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonLimpiar.Location = new System.Drawing.Point(560, 64);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(90, 33);
            this.botonLimpiar.TabIndex = 271;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(204, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 16);
            this.label20.TabIndex = 284;
            this.label20.Text = "Club";
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBusqueda.BackColor = System.Drawing.Color.White;
            this.tbBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusqueda.Location = new System.Drawing.Point(11, 62);
            this.tbBusqueda.Name = "tbBusqueda";
            this.tbBusqueda.Size = new System.Drawing.Size(181, 22);
            this.tbBusqueda.TabIndex = 269;
            this.tbBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBusqueda_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 16);
            this.label19.TabIndex = 283;
            this.label19.Text = "Jugador";
            // 
            // cboC
            // 
            this.cboC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboC.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboC.FormattingEnabled = true;
            this.cboC.Items.AddRange(new object[] {
            "Paciente",
            "DNI"});
            this.cboC.Location = new System.Drawing.Point(247, 61);
            this.cboC.Name = "cboC";
            this.cboC.Size = new System.Drawing.Size(191, 24);
            this.cboC.TabIndex = 281;
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar.Location = new System.Drawing.Point(15, 95);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(498, 16);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 276;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtCantFis);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.tbImpLab);
            this.panel1.Controls.Add(this.txtCantLab);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtCantRX);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txtCantCar);
            this.panel1.Controls.Add(this.tbImpEx);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbNoCarg);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 547);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1323, 36);
            this.panel1.TabIndex = 290;
            this.panel1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(586, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 282;
            this.label9.Text = "DICT";
            // 
            // txtCantFis
            // 
            this.txtCantFis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantFis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantFis.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtCantFis.Location = new System.Drawing.Point(170, 7);
            this.txtCantFis.Name = "txtCantFis";
            this.txtCantFis.ReadOnly = true;
            this.txtCantFis.Size = new System.Drawing.Size(47, 22);
            this.txtCantFis.TabIndex = 271;
            this.txtCantFis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.SteelBlue;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(1177, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 16);
            this.label18.TabIndex = 289;
            this.label18.Text = "LAB";
            // 
            // tbImpLab
            // 
            this.tbImpLab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbImpLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbImpLab.ForeColor = System.Drawing.Color.MediumBlue;
            this.tbImpLab.Location = new System.Drawing.Point(1221, 8);
            this.tbImpLab.Name = "tbImpLab";
            this.tbImpLab.ReadOnly = true;
            this.tbImpLab.Size = new System.Drawing.Size(47, 22);
            this.tbImpLab.TabIndex = 288;
            this.tbImpLab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCantLab
            // 
            this.txtCantLab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantLab.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtCantLab.Location = new System.Drawing.Point(282, 7);
            this.txtCantLab.Name = "txtCantLab";
            this.txtCantLab.ReadOnly = true;
            this.txtCantLab.Size = new System.Drawing.Size(47, 22);
            this.txtCantLab.TabIndex = 272;
            this.txtCantLab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.SteelBlue;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(1076, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 16);
            this.label16.TabIndex = 287;
            this.label16.Text = "EX";
            // 
            // txtCantRX
            // 
            this.txtCantRX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantRX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantRX.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtCantRX.Location = new System.Drawing.Point(395, 7);
            this.txtCantRX.Name = "txtCantRX";
            this.txtCantRX.ReadOnly = true;
            this.txtCantRX.Size = new System.Drawing.Size(47, 22);
            this.txtCantRX.TabIndex = 273;
            this.txtCantRX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.SteelBlue;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(965, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 16);
            this.label17.TabIndex = 286;
            this.label17.Text = "A Imprimir:";
            // 
            // txtCantCar
            // 
            this.txtCantCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantCar.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtCantCar.Location = new System.Drawing.Point(513, 7);
            this.txtCantCar.Name = "txtCantCar";
            this.txtCantCar.ReadOnly = true;
            this.txtCantCar.Size = new System.Drawing.Size(47, 22);
            this.txtCantCar.TabIndex = 274;
            this.txtCantCar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbImpEx
            // 
            this.tbImpEx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbImpEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbImpEx.ForeColor = System.Drawing.Color.MediumBlue;
            this.tbImpEx.Location = new System.Drawing.Point(1110, 8);
            this.tbImpEx.Name = "tbImpEx";
            this.tbImpEx.ReadOnly = true;
            this.tbImpEx.Size = new System.Drawing.Size(47, 22);
            this.tbImpEx.TabIndex = 285;
            this.tbImpEx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 275;
            this.label3.Text = "A cargar: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(136, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 277;
            this.label2.Text = "CLI";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(242, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 16);
            this.label6.TabIndex = 278;
            this.label6.Text = "LAB";
            // 
            // tbNoCarg
            // 
            this.tbNoCarg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNoCarg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNoCarg.ForeColor = System.Drawing.Color.MediumBlue;
            this.tbNoCarg.Location = new System.Drawing.Point(636, 7);
            this.tbNoCarg.Name = "tbNoCarg";
            this.tbNoCarg.ReadOnly = true;
            this.tbNoCarg.Size = new System.Drawing.Size(47, 22);
            this.tbNoCarg.TabIndex = 281;
            this.tbNoCarg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(363, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 16);
            this.label7.TabIndex = 279;
            this.label7.Text = "RX";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(468, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 20);
            this.label8.TabIndex = 280;
            this.label8.Text = "ECG";
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1323, 25);
            this.lbTitulo.TabIndex = 125;
            this.lbTitulo.Text = "   Exámenes Preventiva ";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbFiltros
            // 
            this.gbFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbFiltros.Controls.Add(this.btnExportarPDF);
            this.gbFiltros.Controls.Add(this.botRevalidarCondicionales);
            this.gbFiltros.Controls.Add(this.botonHabilitarInabiitar);
            this.gbFiltros.Controls.Add(this.botEliminarExamen);
            this.gbFiltros.Controls.Add(this.botImportarMovil);
            this.gbFiltros.Controls.Add(this.botonCambiarClub);
            this.gbFiltros.Controls.Add(this.botECGAuto);
            this.gbFiltros.Controls.Add(this.botonRx);
            this.gbFiltros.Controls.Add(this.botImportar);
            this.gbFiltros.Controls.Add(this.botonRevalidar);
            this.gbFiltros.Controls.Add(this.botMail);
            this.gbFiltros.Controls.Add(this.botImprimir);
            this.gbFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbFiltros.Location = new System.Drawing.Point(1180, 16);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(125, 82);
            this.gbFiltros.TabIndex = 126;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Visible = false;
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnExportarPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExportarPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExportarPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarPDF.Image")));
            this.btnExportarPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarPDF.Location = new System.Drawing.Point(1295, 34);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(118, 39);
            this.btnExportarPDF.TabIndex = 290;
            this.btnExportarPDF.Text = "Exportar \r\nPDF";
            this.btnExportarPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarPDF.UseVisualStyleBackColor = false;
            this.btnExportarPDF.Visible = false;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // botRevalidarCondicionales
            // 
            this.botRevalidarCondicionales.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botRevalidarCondicionales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botRevalidarCondicionales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botRevalidarCondicionales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botRevalidarCondicionales.Image = ((System.Drawing.Image)(resources.GetObject("botRevalidarCondicionales.Image")));
            this.botRevalidarCondicionales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botRevalidarCondicionales.Location = new System.Drawing.Point(1303, 34);
            this.botRevalidarCondicionales.Name = "botRevalidarCondicionales";
            this.botRevalidarCondicionales.Size = new System.Drawing.Size(118, 39);
            this.botRevalidarCondicionales.TabIndex = 289;
            this.botRevalidarCondicionales.Text = "Consolidar\r\nEstudios";
            this.botRevalidarCondicionales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botRevalidarCondicionales.UseVisualStyleBackColor = false;
            this.botRevalidarCondicionales.Visible = false;
            this.botRevalidarCondicionales.Click += new System.EventHandler(this.botRevalidarCondicionales_Click);
            // 
            // botonHabilitarInabiitar
            // 
            this.botonHabilitarInabiitar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botonHabilitarInabiitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botonHabilitarInabiitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonHabilitarInabiitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonHabilitarInabiitar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botonHabilitarInabiitar.Image = ((System.Drawing.Image)(resources.GetObject("botonHabilitarInabiitar.Image")));
            this.botonHabilitarInabiitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonHabilitarInabiitar.Location = new System.Drawing.Point(1303, 34);
            this.botonHabilitarInabiitar.Name = "botonHabilitarInabiitar";
            this.botonHabilitarInabiitar.Size = new System.Drawing.Size(118, 39);
            this.botonHabilitarInabiitar.TabIndex = 288;
            this.botonHabilitarInabiitar.Text = "Habilitar\r\nInhabilitar";
            this.botonHabilitarInabiitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonHabilitarInabiitar.UseVisualStyleBackColor = false;
            this.botonHabilitarInabiitar.Visible = false;
            this.botonHabilitarInabiitar.Click += new System.EventHandler(this.botonHabilitarInabiitar_Click);
            // 
            // botEliminarExamen
            // 
            this.botEliminarExamen.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botEliminarExamen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botEliminarExamen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botEliminarExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.botEliminarExamen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botEliminarExamen.Image = ((System.Drawing.Image)(resources.GetObject("botEliminarExamen.Image")));
            this.botEliminarExamen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEliminarExamen.Location = new System.Drawing.Point(1295, 37);
            this.botEliminarExamen.Name = "botEliminarExamen";
            this.botEliminarExamen.Size = new System.Drawing.Size(118, 39);
            this.botEliminarExamen.TabIndex = 287;
            this.botEliminarExamen.Text = "Eliminar";
            this.botEliminarExamen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEliminarExamen.UseVisualStyleBackColor = false;
            this.botEliminarExamen.Visible = false;
            this.botEliminarExamen.Click += new System.EventHandler(this.botEliminarExamen_Click);
            // 
            // botImportarMovil
            // 
            this.botImportarMovil.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botImportarMovil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botImportarMovil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botImportarMovil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.botImportarMovil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botImportarMovil.Image = ((System.Drawing.Image)(resources.GetObject("botImportarMovil.Image")));
            this.botImportarMovil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botImportarMovil.Location = new System.Drawing.Point(1295, 37);
            this.botImportarMovil.Name = "botImportarMovil";
            this.botImportarMovil.Size = new System.Drawing.Size(118, 39);
            this.botImportarMovil.TabIndex = 279;
            this.botImportarMovil.Text = "Importar \r\nJug.";
            this.botImportarMovil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botImportarMovil.UseVisualStyleBackColor = false;
            this.botImportarMovil.Visible = false;
            this.botImportarMovil.Click += new System.EventHandler(this.botImportarMovil_Click);
            // 
            // botonCambiarClub
            // 
            this.botonCambiarClub.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botonCambiarClub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botonCambiarClub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonCambiarClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.botonCambiarClub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botonCambiarClub.Image = ((System.Drawing.Image)(resources.GetObject("botonCambiarClub.Image")));
            this.botonCambiarClub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonCambiarClub.Location = new System.Drawing.Point(1322, 34);
            this.botonCambiarClub.Name = "botonCambiarClub";
            this.botonCambiarClub.Size = new System.Drawing.Size(118, 39);
            this.botonCambiarClub.TabIndex = 278;
            this.botonCambiarClub.Text = "Cambiar \r\nClub";
            this.botonCambiarClub.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonCambiarClub.UseVisualStyleBackColor = false;
            this.botonCambiarClub.Visible = false;
            this.botonCambiarClub.Click += new System.EventHandler(this.botonCambiarClub_Click);
            // 
            // botECGAuto
            // 
            this.botECGAuto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botECGAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botECGAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.botECGAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botECGAuto.Image = ((System.Drawing.Image)(resources.GetObject("botECGAuto.Image")));
            this.botECGAuto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botECGAuto.Location = new System.Drawing.Point(1322, 33);
            this.botECGAuto.Name = "botECGAuto";
            this.botECGAuto.Size = new System.Drawing.Size(118, 39);
            this.botECGAuto.TabIndex = 277;
            this.botECGAuto.Text = "ECG \r\nAutomático";
            this.botECGAuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botECGAuto.UseVisualStyleBackColor = false;
            this.botECGAuto.Visible = false;
            this.botECGAuto.Click += new System.EventHandler(this.botECGAuto_Click);
            // 
            // botonRx
            // 
            this.botonRx.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botonRx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonRx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.botonRx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botonRx.Image = ((System.Drawing.Image)(resources.GetObject("botonRx.Image")));
            this.botonRx.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonRx.Location = new System.Drawing.Point(1303, 33);
            this.botonRx.Name = "botonRx";
            this.botonRx.Size = new System.Drawing.Size(118, 39);
            this.botonRx.TabIndex = 276;
            this.botonRx.Text = "RX \r\nAutomático";
            this.botonRx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonRx.UseVisualStyleBackColor = false;
            this.botonRx.Visible = false;
            this.botonRx.Click += new System.EventHandler(this.botonRx_Click);
            // 
            // botImportar
            // 
            this.botImportar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.botImportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botImportar.Image = ((System.Drawing.Image)(resources.GetObject("botImportar.Image")));
            this.botImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botImportar.Location = new System.Drawing.Point(1295, 34);
            this.botImportar.Name = "botImportar";
            this.botImportar.Size = new System.Drawing.Size(118, 39);
            this.botImportar.TabIndex = 275;
            this.botImportar.Text = "Importar \r\nLabo.";
            this.botImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botImportar.UseVisualStyleBackColor = false;
            this.botImportar.Visible = false;
            this.botImportar.Click += new System.EventHandler(this.botImportar_Click);
            // 
            // botonRevalidar
            // 
            this.botonRevalidar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botonRevalidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonRevalidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRevalidar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botonRevalidar.Image = ((System.Drawing.Image)(resources.GetObject("botonRevalidar.Image")));
            this.botonRevalidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonRevalidar.Location = new System.Drawing.Point(1322, 34);
            this.botonRevalidar.Name = "botonRevalidar";
            this.botonRevalidar.Size = new System.Drawing.Size(118, 39);
            this.botonRevalidar.TabIndex = 274;
            this.botonRevalidar.Text = "Revalidación\r\nDict/Cond";
            this.botonRevalidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonRevalidar.UseVisualStyleBackColor = false;
            this.botonRevalidar.Visible = false;
            this.botonRevalidar.Click += new System.EventHandler(this.botonRevalidar_Click);
            // 
            // botMail
            // 
            this.botMail.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.botMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botMail.Image = ((System.Drawing.Image)(resources.GetObject("botMail.Image")));
            this.botMail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botMail.Location = new System.Drawing.Point(1281, 34);
            this.botMail.Name = "botMail";
            this.botMail.Size = new System.Drawing.Size(118, 39);
            this.botMail.TabIndex = 273;
            this.botMail.Text = "Mail";
            this.botMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botMail.UseVisualStyleBackColor = false;
            this.botMail.Visible = false;
            this.botMail.Click += new System.EventHandler(this.botMail_Click);
            // 
            // botImprimir
            // 
            this.botImprimir.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.botImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.botImprimir.Image = ((System.Drawing.Image)(resources.GetObject("botImprimir.Image")));
            this.botImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botImprimir.Location = new System.Drawing.Point(1303, 34);
            this.botImprimir.Name = "botImprimir";
            this.botImprimir.Size = new System.Drawing.Size(118, 39);
            this.botImprimir.TabIndex = 270;
            this.botImprimir.Text = "Imprimir";
            this.botImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botImprimir.UseVisualStyleBackColor = false;
            this.botImprimir.Visible = false;
            this.botImprimir.Click += new System.EventHandler(this.botImprimir_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "idTe";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 53;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "idC";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 47;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 62;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn4.HeaderText = "N° Ex.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 62;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Liga";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 52;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Club";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 53;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn7.HeaderText = "Categ.";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 63;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn8.HeaderText = "DNI";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 51;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Paciente";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 74;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "txtCLI";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 59;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "txtLAB";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 63;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "txtRX";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            this.dataGridViewTextBoxColumn12.Width = 58;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "txtCAR";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            this.dataGridViewTextBoxColumn13.Width = 65;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "txtDIC";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            this.dataGridViewTextBoxColumn14.Width = 61;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn15.HeaderText = "Dictámen Final";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn15.Width = 102;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "txtIMP";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Visible = false;
            this.dataGridViewTextBoxColumn16.Width = 62;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "txtIMPLAB";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Visible = false;
            this.dataGridViewTextBoxColumn17.Width = 82;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "txtEnviado";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Visible = false;
            this.dataGridViewTextBoxColumn18.Width = 82;
            // 
            // timerActualizaEstados
            // 
            this.timerActualizaEstados.Interval = 1000;
            this.timerActualizaEstados.Tick += new System.EventHandler(this.timerActualizaEstados_Tick);
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
            this.bbiImportarJugador,
            this.bbiImportarLaboratorio,
            this.bbiHabilitar,
            this.bbiCambioClub,
            this.bbiRevalidacion,
            this.bbiRXAutomatico,
            this.bbiEcgAutomatico,
            this.bbiConsolidarEstudios,
            this.bbiExportarPDF,
            this.bbiEliminar,
            this.bbiImprimir,
            this.bbiEnviarEmail,
            this.bbiExpMedida,
            this.bbiExpWeb,
            this.bbiDataSMS,
            this.bbiExportarMesaEnt,
            this.bbiAudiometria,
            this.bbiEditarPaciente});
            this.rbcMenu.Location = new System.Drawing.Point(0, 0);
            this.rbcMenu.MaxItemId = 7;
            this.rbcMenu.Name = "rbcMenu";
            this.rbcMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpExamenPre});
            this.rbcMenu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.rbcMenu.Size = new System.Drawing.Size(1323, 139);
            // 
            // bbiImportarJugador
            // 
            this.bbiImportarJugador.Caption = "Importar Jugadores";
            this.bbiImportarJugador.Id = 1;
            this.bbiImportarJugador.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiImportarJugador.ImageOptions.LargeImage")));
            this.bbiImportarJugador.Name = "bbiImportarJugador";
            this.bbiImportarJugador.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiImportarJugador_ItemClick);
            // 
            // bbiImportarLaboratorio
            // 
            this.bbiImportarLaboratorio.Caption = "Importar Laboratorio";
            this.bbiImportarLaboratorio.Id = 2;
            this.bbiImportarLaboratorio.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiImportarLaboratorio.ImageOptions.LargeImage")));
            this.bbiImportarLaboratorio.Name = "bbiImportarLaboratorio";
            this.bbiImportarLaboratorio.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiImportarLaboratorio_ItemClick);
            // 
            // bbiHabilitar
            // 
            this.bbiHabilitar.Caption = "Habilitar Inhabilitar";
            this.bbiHabilitar.Id = 3;
            this.bbiHabilitar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiHabilitar.ImageOptions.LargeImage")));
            this.bbiHabilitar.Name = "bbiHabilitar";
            this.bbiHabilitar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHabilitar_ItemClick);
            // 
            // bbiCambioClub
            // 
            this.bbiCambioClub.Caption = "Cambiar Club";
            this.bbiCambioClub.Id = 4;
            this.bbiCambioClub.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiCambioClub.ImageOptions.LargeImage")));
            this.bbiCambioClub.Name = "bbiCambioClub";
            this.bbiCambioClub.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCambioClub_ItemClick);
            // 
            // bbiRevalidacion
            // 
            this.bbiRevalidacion.Caption = "Revalidación Dict/Cond";
            this.bbiRevalidacion.Id = 5;
            this.bbiRevalidacion.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiRevalidacion.ImageOptions.LargeImage")));
            this.bbiRevalidacion.Name = "bbiRevalidacion";
            this.bbiRevalidacion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRevalidacion_ItemClick);
            // 
            // bbiRXAutomatico
            // 
            this.bbiRXAutomatico.Caption = "RX \r\nAutomático";
            this.bbiRXAutomatico.Id = 6;
            this.bbiRXAutomatico.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiRXAutomatico.ImageOptions.LargeImage")));
            this.bbiRXAutomatico.Name = "bbiRXAutomatico";
            this.bbiRXAutomatico.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRXAutomatico_ItemClick);
            // 
            // bbiEcgAutomatico
            // 
            this.bbiEcgAutomatico.Caption = "ECG\r\nAutomático";
            this.bbiEcgAutomatico.Id = 7;
            this.bbiEcgAutomatico.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiEcgAutomatico.ImageOptions.LargeImage")));
            this.bbiEcgAutomatico.Name = "bbiEcgAutomatico";
            this.bbiEcgAutomatico.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEcgAutomatico_ItemClick);
            // 
            // bbiConsolidarEstudios
            // 
            this.bbiConsolidarEstudios.Caption = "Consolidar Estudios";
            this.bbiConsolidarEstudios.Id = 8;
            this.bbiConsolidarEstudios.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiConsolidarEstudios.ImageOptions.LargeImage")));
            this.bbiConsolidarEstudios.Name = "bbiConsolidarEstudios";
            this.bbiConsolidarEstudios.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiConsolidarEstudios_ItemClick);
            // 
            // bbiExportarPDF
            // 
            this.bbiExportarPDF.Caption = "Exportar PDF";
            this.bbiExportarPDF.Id = 9;
            this.bbiExportarPDF.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportarPDF.ImageOptions.LargeImage")));
            this.bbiExportarPDF.Name = "bbiExportarPDF";
            this.bbiExportarPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportarPDF_ItemClick);
            // 
            // bbiEliminar
            // 
            this.bbiEliminar.Caption = "Eliminar";
            this.bbiEliminar.Id = 10;
            this.bbiEliminar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEliminar.ImageOptions.Image")));
            this.bbiEliminar.Name = "bbiEliminar";
            this.bbiEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEliminar_ItemClick);
            // 
            // bbiImprimir
            // 
            this.bbiImprimir.Caption = "Imprimir";
            this.bbiImprimir.Id = 11;
            this.bbiImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiImprimir.ImageOptions.Image")));
            this.bbiImprimir.Name = "bbiImprimir";
            this.bbiImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiImprimir_ItemClick);
            // 
            // bbiEnviarEmail
            // 
            this.bbiEnviarEmail.Caption = "Enviar Mail";
            this.bbiEnviarEmail.Id = 12;
            this.bbiEnviarEmail.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiEnviarEmail.ImageOptions.LargeImage")));
            this.bbiEnviarEmail.Name = "bbiEnviarEmail";
            this.bbiEnviarEmail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEnviarEmail_ItemClick);
            // 
            // bbiExpMedida
            // 
            this.bbiExpMedida.Caption = "Exportación a Medida";
            this.bbiExpMedida.Id = 1;
            this.bbiExpMedida.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExpMedida.ImageOptions.Image")));
            this.bbiExpMedida.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExpMedida.ImageOptions.LargeImage")));
            this.bbiExpMedida.Name = "bbiExpMedida";
            // 
            // bbiExpWeb
            // 
            this.bbiExpWeb.Caption = "Exportacion Página Web";
            this.bbiExpWeb.Id = 2;
            this.bbiExpWeb.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExpWeb.ImageOptions.Image")));
            this.bbiExpWeb.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExpWeb.ImageOptions.LargeImage")));
            this.bbiExpWeb.Name = "bbiExpWeb";
            // 
            // bbiDataSMS
            // 
            this.bbiDataSMS.Caption = "Exportar Data SMS";
            this.bbiDataSMS.Id = 3;
            this.bbiDataSMS.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDataSMS.ImageOptions.Image")));
            this.bbiDataSMS.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDataSMS.ImageOptions.LargeImage")));
            this.bbiDataSMS.Name = "bbiDataSMS";
            // 
            // bbiExportarMesaEnt
            // 
            this.bbiExportarMesaEnt.Caption = "Exportar Mesa Entrada";
            this.bbiExportarMesaEnt.Id = 4;
            this.bbiExportarMesaEnt.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportarMesaEnt.ImageOptions.Image")));
            this.bbiExportarMesaEnt.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportarMesaEnt.ImageOptions.LargeImage")));
            this.bbiExportarMesaEnt.Name = "bbiExportarMesaEnt";
            // 
            // bbiAudiometria
            // 
            this.bbiAudiometria.Caption = "Reporte Audiometria";
            this.bbiAudiometria.Id = 5;
            this.bbiAudiometria.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAudiometria.ImageOptions.Image")));
            this.bbiAudiometria.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAudiometria.ImageOptions.LargeImage")));
            this.bbiAudiometria.Name = "bbiAudiometria";
            this.bbiAudiometria.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAudiometria_ItemClick);
            // 
            // bbiEditarPaciente
            // 
            this.bbiEditarPaciente.Caption = "Editar Paciente";
            this.bbiEditarPaciente.Id = 6;
            this.bbiEditarPaciente.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEditarPaciente.ImageOptions.Image")));
            this.bbiEditarPaciente.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiEditarPaciente.ImageOptions.LargeImage")));
            this.bbiEditarPaciente.Name = "bbiEditarPaciente";
            this.bbiEditarPaciente.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditarPaciente_ItemClick);
            // 
            // rbpExamenPre
            // 
            this.rbpExamenPre.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.rbpExamenPre.Name = "rbpExamenPre";
            this.rbpExamenPre.Text = "Exámenes Preventiva";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // frmBusquedaExamen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 722);
            this.Controls.Add(this.panCentro);
            this.Controls.Add(this.rbcMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmBusquedaExamen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preventiva";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.frmBusquedaExamen_Load);
            this.panCentro.ResumeLayout(false);
            this.panelCambioDeClub.ResumeLayout(false);
            this.panelCambioDeClub.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelNuevoClub.ResumeLayout(false);
            this.panelNuevoClub.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamenes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.gbFecha.ResumeLayout(false);
            this.gbRango.ResumeLayout(false);
            this.gbRango.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel panCentro;
        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.DataGridView dgvExamenes;
        protected System.Windows.Forms.Label lblCantReg;
        private System.Windows.Forms.DateTimePicker tpDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker tpHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantCar;
        private System.Windows.Forms.TextBox txtCantRX;
        private System.Windows.Forms.TextBox txtCantLab;
        private System.Windows.Forms.TextBox txtCantFis;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button botonRango;
        private System.Windows.Forms.DateTimePicker tpFecha;
        private System.Windows.Forms.Button botonFecha;
        protected System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.ComboBox cboTipoBusqueda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNoCarg;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbImpLab;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbImpEx;
        private System.Windows.Forms.Panel panelCambioDeClub;
        private System.Windows.Forms.TextBox tbRow;
        private System.Windows.Forms.Label lblJugador;
        private System.Windows.Forms.Button botCerrar;
        private System.Windows.Forms.Panel panelNuevoClub;
        private System.Windows.Forms.Button botGuardar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboClub;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboLiga;
        private System.Windows.Forms.Button botEliminar;
        private System.Windows.Forms.Button botAgregar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvClub;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboL;
        private System.Windows.Forms.ComboBox cboC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cboD;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.TextBox tbBusqueda;
        public System.Windows.Forms.GroupBox gbRango;
        public System.Windows.Forms.Button botBuscar;
        public System.Windows.Forms.GroupBox gbFecha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.ProgressBar pgrBarraProgreso;
        private System.Windows.Forms.Timer timerActualizaEstados;
        public System.Windows.Forms.Button botonBuscar;
        private DevExpress.XtraBars.Ribbon.RibbonControl rbcMenu;
        private DevExpress.XtraBars.BarButtonItem bbiImportarJugador;
        private DevExpress.XtraBars.BarButtonItem bbiImportarLaboratorio;
        private DevExpress.XtraBars.BarButtonItem bbiHabilitar;
        private DevExpress.XtraBars.BarButtonItem bbiCambioClub;
        private DevExpress.XtraBars.BarButtonItem bbiRevalidacion;
        private DevExpress.XtraBars.BarButtonItem bbiRXAutomatico;
        private DevExpress.XtraBars.BarButtonItem bbiEcgAutomatico;
        private DevExpress.XtraBars.BarButtonItem bbiConsolidarEstudios;
        private DevExpress.XtraBars.BarButtonItem bbiExportarPDF;
        private DevExpress.XtraBars.BarButtonItem bbiEliminar;
        private DevExpress.XtraBars.BarButtonItem bbiImprimir;
        private DevExpress.XtraBars.BarButtonItem bbiEnviarEmail;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpExamenPre;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTe;
        private System.Windows.Forms.DataGridViewTextBoxColumn idC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn NEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Liga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Club;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCLI;
        private System.Windows.Forms.DataGridViewImageColumn CLI;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLAB;
        private System.Windows.Forms.DataGridViewImageColumn LAB;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRX;
        private System.Windows.Forms.DataGridViewImageColumn RX;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCAR;
        private System.Windows.Forms.DataGridViewImageColumn CAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDICT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DICF;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RM;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIMP;
        private System.Windows.Forms.DataGridViewImageColumn IMP;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIMPLAB;
        private System.Windows.Forms.DataGridViewImageColumn IMPLAB;
        private System.Windows.Forms.DataGridViewCheckBoxColumn txtINF;
        private System.Windows.Forms.DataGridViewImageColumn INF;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtConsolidado;
        private System.Windows.Forms.DataGridViewImageColumn CONS;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEnviado;
        private System.Windows.Forms.DataGridViewImageColumn Enviado;
        private DevExpress.XtraBars.BarButtonItem bbiExpMedida;
        private DevExpress.XtraBars.BarButtonItem bbiExpWeb;
        private DevExpress.XtraBars.BarButtonItem bbiDataSMS;
        private DevExpress.XtraBars.BarButtonItem bbiExportarMesaEnt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbFiltros;
        protected System.Windows.Forms.Button btnExportarPDF;
        protected System.Windows.Forms.Button botRevalidarCondicionales;
        protected System.Windows.Forms.Button botonHabilitarInabiitar;
        protected System.Windows.Forms.Button botEliminarExamen;
        protected System.Windows.Forms.Button botImportarMovil;
        protected System.Windows.Forms.Button botonCambiarClub;
        protected System.Windows.Forms.Button botECGAuto;
        protected System.Windows.Forms.Button botonRx;
        protected System.Windows.Forms.Button botImportar;
        protected System.Windows.Forms.Button botonRevalidar;
        protected System.Windows.Forms.Button botMail;
        protected System.Windows.Forms.Button botImprimir;
        private DevExpress.XtraBars.BarButtonItem bbiAudiometria;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem bbiEditarPaciente;
    }
}