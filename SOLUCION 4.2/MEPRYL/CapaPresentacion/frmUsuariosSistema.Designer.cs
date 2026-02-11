namespace CapaPresentacion
{
    partial class frmUsuariosSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuariosSistema));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.chkMedico = new System.Windows.Forms.CheckBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tblBuscar = new System.Windows.Forms.TableLayoutPanel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dgwDatos = new System.Windows.Forms.DataGridView();
            this.gpbPermisos = new System.Windows.Forms.GroupBox();
            this.chkEliminar = new System.Windows.Forms.CheckBox();
            this.chkModificar = new System.Windows.Forms.CheckBox();
            this.chkVer = new System.Windows.Forms.CheckBox();
            this.gpbAccesoPantallas = new System.Windows.Forms.GroupBox();
            this.chkVerAudiometria = new System.Windows.Forms.CheckBox();
            this.chkResumen = new System.Windows.Forms.CheckBox();
            this.chkTurnos = new System.Windows.Forms.CheckBox();
            this.chkVentanilla = new System.Windows.Forms.CheckBox();
            this.chkMesaEntrada = new System.Windows.Forms.CheckBox();
            this.chkConfiguracion = new System.Windows.Forms.CheckBox();
            this.chkExamenes = new System.Windows.Forms.CheckBox();
            this.chkPacientes = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTipoUsuario = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.lblFaltanCargar = new System.Windows.Forms.Panel();
            this.botModificar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnTipoUsuario = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.botCancelar = new System.Windows.Forms.Button();
            this.botAceptar = new System.Windows.Forms.Button();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tblBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDatos)).BeginInit();
            this.gpbPermisos.SuspendLayout();
            this.gpbAccesoPantallas.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.lblFaltanCargar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SeaGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1092, 25);
            this.lbTitulo.TabIndex = 127;
            this.lbTitulo.Text = "   Usuarios del Sistema";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 534);
            this.panel1.TabIndex = 128;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDNI);
            this.panel2.Controls.Add(this.chkMedico);
            this.panel2.Controls.Add(this.chkActivo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tblBuscar);
            this.panel2.Controls.Add(this.dgwDatos);
            this.panel2.Controls.Add(this.gpbPermisos);
            this.panel2.Controls.Add(this.gpbAccesoPantallas);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1092, 534);
            this.panel2.TabIndex = 2;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(965, 276);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 22);
            this.txtDNI.TabIndex = 173;
            this.txtDNI.Visible = false;
            // 
            // chkMedico
            // 
            this.chkMedico.AutoSize = true;
            this.chkMedico.Location = new System.Drawing.Point(307, 270);
            this.chkMedico.Name = "chkMedico";
            this.chkMedico.Size = new System.Drawing.Size(140, 20);
            this.chkMedico.TabIndex = 171;
            this.chkMedico.Text = "Medico Asosciado";
            this.chkMedico.UseVisualStyleBackColor = true;
            this.chkMedico.Visible = false;
            this.chkMedico.CheckedChanged += new System.EventHandler(this.chkMedico_CheckedChanged);
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Location = new System.Drawing.Point(161, 270);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(114, 20);
            this.chkActivo.TabIndex = 166;
            this.chkActivo.Text = "Usuario Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            this.chkActivo.CheckedChanged += new System.EventHandler(this.chkActivo_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(382, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 172;
            // 
            // tblBuscar
            // 
            this.tblBuscar.ColumnCount = 1;
            this.tblBuscar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tblBuscar.Controls.Add(this.txtBuscar, 0, 0);
            this.tblBuscar.Controls.Add(this.dgv, 0, 1);
            this.tblBuscar.Location = new System.Drawing.Point(462, 32);
            this.tblBuscar.Name = "tblBuscar";
            this.tblBuscar.RowCount = 2;
            this.tblBuscar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tblBuscar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 328F));
            this.tblBuscar.Size = new System.Drawing.Size(383, 258);
            this.tblBuscar.TabIndex = 170;
            this.tblBuscar.Visible = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(3, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(374, 22);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(3, 35);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(380, 225);
            this.dgv.TabIndex = 1;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_KeyPress);
            // 
            // dgwDatos
            // 
            this.dgwDatos.AllowUserToAddRows = false;
            this.dgwDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgwDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwDatos.Location = new System.Drawing.Point(658, 341);
            this.dgwDatos.Name = "dgwDatos";
            this.dgwDatos.Size = new System.Drawing.Size(136, 91);
            this.dgwDatos.TabIndex = 11;
            this.dgwDatos.Visible = false;
            this.dgwDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwDatos_CellClick);
            this.dgwDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwDatos_CellContentClick);
            this.dgwDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwDatos_CellDoubleClick);
            this.dgwDatos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwDatos_CellMouseClick);
            this.dgwDatos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwDatos_CellValueChanged);
            this.dgwDatos.SelectionChanged += new System.EventHandler(this.dgwDatos_SelectionChanged);
            // 
            // gpbPermisos
            // 
            this.gpbPermisos.Controls.Add(this.chkEliminar);
            this.gpbPermisos.Controls.Add(this.chkModificar);
            this.gpbPermisos.Controls.Add(this.chkVer);
            this.gpbPermisos.Location = new System.Drawing.Point(28, 392);
            this.gpbPermisos.Name = "gpbPermisos";
            this.gpbPermisos.Size = new System.Drawing.Size(212, 102);
            this.gpbPermisos.TabIndex = 49;
            this.gpbPermisos.TabStop = false;
            this.gpbPermisos.Text = "Permisos";
            // 
            // chkEliminar
            // 
            this.chkEliminar.AutoSize = true;
            this.chkEliminar.Location = new System.Drawing.Point(118, 30);
            this.chkEliminar.Name = "chkEliminar";
            this.chkEliminar.Size = new System.Drawing.Size(75, 20);
            this.chkEliminar.TabIndex = 2;
            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.UseVisualStyleBackColor = true;
            // 
            // chkModificar
            // 
            this.chkModificar.AutoSize = true;
            this.chkModificar.Location = new System.Drawing.Point(118, 67);
            this.chkModificar.Name = "chkModificar";
            this.chkModificar.Size = new System.Drawing.Size(82, 20);
            this.chkModificar.TabIndex = 1;
            this.chkModificar.Text = "Modificar";
            this.chkModificar.UseVisualStyleBackColor = true;
            // 
            // chkVer
            // 
            this.chkVer.AutoSize = true;
            this.chkVer.Location = new System.Drawing.Point(29, 30);
            this.chkVer.Name = "chkVer";
            this.chkVer.Size = new System.Drawing.Size(48, 20);
            this.chkVer.TabIndex = 0;
            this.chkVer.Text = "Ver";
            this.chkVer.UseVisualStyleBackColor = true;
            // 
            // gpbAccesoPantallas
            // 
            this.gpbAccesoPantallas.Controls.Add(this.chkVerAudiometria);
            this.gpbAccesoPantallas.Controls.Add(this.chkResumen);
            this.gpbAccesoPantallas.Controls.Add(this.chkTurnos);
            this.gpbAccesoPantallas.Controls.Add(this.chkVentanilla);
            this.gpbAccesoPantallas.Controls.Add(this.chkMesaEntrada);
            this.gpbAccesoPantallas.Controls.Add(this.chkConfiguracion);
            this.gpbAccesoPantallas.Controls.Add(this.chkExamenes);
            this.gpbAccesoPantallas.Controls.Add(this.chkPacientes);
            this.gpbAccesoPantallas.Location = new System.Drawing.Point(28, 269);
            this.gpbAccesoPantallas.Name = "gpbAccesoPantallas";
            this.gpbAccesoPantallas.Size = new System.Drawing.Size(902, 115);
            this.gpbAccesoPantallas.TabIndex = 47;
            this.gpbAccesoPantallas.TabStop = false;
            this.gpbAccesoPantallas.Text = "Acceso a Pantallas";
            // 
            // chkVerAudiometria
            // 
            this.chkVerAudiometria.AutoSize = true;
            this.chkVerAudiometria.Location = new System.Drawing.Point(487, 67);
            this.chkVerAudiometria.Name = "chkVerAudiometria";
            this.chkVerAudiometria.Size = new System.Drawing.Size(123, 20);
            this.chkVerAudiometria.TabIndex = 13;
            this.chkVerAudiometria.Text = "Ver Audiometria";
            this.chkVerAudiometria.UseVisualStyleBackColor = true;
            // 
            // chkResumen
            // 
            this.chkResumen.AutoSize = true;
            this.chkResumen.Location = new System.Drawing.Point(487, 30);
            this.chkResumen.Name = "chkResumen";
            this.chkResumen.Size = new System.Drawing.Size(115, 20);
            this.chkResumen.TabIndex = 12;
            this.chkResumen.Text = "Planilla del día";
            this.chkResumen.UseVisualStyleBackColor = true;
            // 
            // chkTurnos
            // 
            this.chkTurnos.AutoSize = true;
            this.chkTurnos.Location = new System.Drawing.Point(357, 67);
            this.chkTurnos.Name = "chkTurnos";
            this.chkTurnos.Size = new System.Drawing.Size(69, 20);
            this.chkTurnos.TabIndex = 11;
            this.chkTurnos.Text = "Turnos";
            this.chkTurnos.UseVisualStyleBackColor = true;
            // 
            // chkVentanilla
            // 
            this.chkVentanilla.AutoSize = true;
            this.chkVentanilla.Location = new System.Drawing.Point(38, 30);
            this.chkVentanilla.Name = "chkVentanilla";
            this.chkVentanilla.Size = new System.Drawing.Size(86, 20);
            this.chkVentanilla.TabIndex = 6;
            this.chkVentanilla.Text = "Ventanilla";
            this.chkVentanilla.UseVisualStyleBackColor = true;
            // 
            // chkMesaEntrada
            // 
            this.chkMesaEntrada.AutoSize = true;
            this.chkMesaEntrada.Location = new System.Drawing.Point(38, 67);
            this.chkMesaEntrada.Name = "chkMesaEntrada";
            this.chkMesaEntrada.Size = new System.Drawing.Size(129, 20);
            this.chkMesaEntrada.TabIndex = 7;
            this.chkMesaEntrada.Text = "Mesa de entrada";
            this.chkMesaEntrada.UseVisualStyleBackColor = true;
            // 
            // chkConfiguracion
            // 
            this.chkConfiguracion.AutoSize = true;
            this.chkConfiguracion.Location = new System.Drawing.Point(207, 67);
            this.chkConfiguracion.Name = "chkConfiguracion";
            this.chkConfiguracion.Size = new System.Drawing.Size(109, 20);
            this.chkConfiguracion.TabIndex = 9;
            this.chkConfiguracion.Text = "Configuración";
            this.chkConfiguracion.UseVisualStyleBackColor = true;
            // 
            // chkExamenes
            // 
            this.chkExamenes.AutoSize = true;
            this.chkExamenes.Location = new System.Drawing.Point(207, 30);
            this.chkExamenes.Name = "chkExamenes";
            this.chkExamenes.Size = new System.Drawing.Size(91, 20);
            this.chkExamenes.TabIndex = 8;
            this.chkExamenes.Text = "Examenes";
            this.chkExamenes.UseVisualStyleBackColor = true;
            // 
            // chkPacientes
            // 
            this.chkPacientes.AutoSize = true;
            this.chkPacientes.Location = new System.Drawing.Point(357, 30);
            this.chkPacientes.Name = "chkPacientes";
            this.chkPacientes.Size = new System.Drawing.Size(87, 20);
            this.chkPacientes.TabIndex = 10;
            this.chkPacientes.Text = "Pacientes";
            this.chkPacientes.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(765, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(91, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            this.groupBox1.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 820F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 251F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pbFoto, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1071, 219);
            this.tableLayoutPanel2.TabIndex = 169;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 412F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 286F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label18, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtApellido, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtContrasena, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtNombreUsuario, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtCorreo, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbTipoUsuario, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(790, 205);
            this.tableLayoutPanel1.TabIndex = 168;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.BackgroundImage")));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(3, 20);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(25, 22);
            this.pictureBox6.TabIndex = 164;
            this.pictureBox6.TabStop = false;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(42, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 22);
            this.label18.TabIndex = 165;
            this.label18.Text = "[F1]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido: ";
            // 
            // txtApellido
            // 
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Location = new System.Drawing.Point(95, 20);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(406, 22);
            this.txtApellido.TabIndex = 0;
            this.txtApellido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtApellido_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre: ";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(95, 69);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(406, 22);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "Correo-E: ";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(95, 167);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(170, 22);
            this.txtContrasena.TabIndex = 3;
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(95, 118);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(164, 22);
            this.txtNombreUsuario.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "Contraseña: ";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(507, 69);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(266, 22);
            this.txtCorreo.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(95, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 16);
            this.label7.TabIndex = 48;
            this.label7.Text = "Nombre de Usuario: ";
            // 
            // cmbTipoUsuario
            // 
            this.cmbTipoUsuario.FormattingEnabled = true;
            this.cmbTipoUsuario.Items.AddRange(new object[] {
            "ADMINISTRADOR",
            "OPERADOR",
            "TECNICO/MEDICO"});
            this.cmbTipoUsuario.Location = new System.Drawing.Point(507, 118);
            this.cmbTipoUsuario.Name = "cmbTipoUsuario";
            this.cmbTipoUsuario.Size = new System.Drawing.Size(266, 24);
            this.cmbTipoUsuario.TabIndex = 5;
            this.cmbTipoUsuario.Text = "OPERADOR";
            this.cmbTipoUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbTipoUsuario_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 46;
            this.label6.Text = "Tipo de Usuario: ";
            // 
            // pbFoto
            // 
            this.pbFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFoto.Image = ((System.Drawing.Image)(resources.GetObject("pbFoto.Image")));
            this.pbFoto.Location = new System.Drawing.Point(840, 3);
            this.pbFoto.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(212, 213);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 50;
            this.pbFoto.TabStop = false;
            this.pbFoto.Click += new System.EventHandler(this.pbFoto_Click);
            this.pbFoto.DoubleClick += new System.EventHandler(this.pbFoto_DoubleClick);
            // 
            // lblFaltanCargar
            // 
            this.lblFaltanCargar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblFaltanCargar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFaltanCargar.Controls.Add(this.botModificar);
            this.lblFaltanCargar.Controls.Add(this.btnSalir);
            this.lblFaltanCargar.Controls.Add(this.btnTipoUsuario);
            this.lblFaltanCargar.Controls.Add(this.btnNuevo);
            this.lblFaltanCargar.Controls.Add(this.btnEliminar);
            this.lblFaltanCargar.Controls.Add(this.botCancelar);
            this.lblFaltanCargar.Controls.Add(this.botAceptar);
            this.lblFaltanCargar.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFaltanCargar.Location = new System.Drawing.Point(1092, 0);
            this.lblFaltanCargar.Name = "lblFaltanCargar";
            this.lblFaltanCargar.Size = new System.Drawing.Size(136, 559);
            this.lblFaltanCargar.TabIndex = 129;
            // 
            // botModificar
            // 
            this.botModificar.Enabled = false;
            this.botModificar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botModificar.Image = ((System.Drawing.Image)(resources.GetObject("botModificar.Image")));
            this.botModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botModificar.Location = new System.Drawing.Point(8, 111);
            this.botModificar.Name = "botModificar";
            this.botModificar.Size = new System.Drawing.Size(120, 45);
            this.botModificar.TabIndex = 276;
            this.botModificar.Text = "Modificar";
            this.botModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botModificar.UseVisualStyleBackColor = true;
            this.botModificar.Click += new System.EventHandler(this.botModificar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(5, 487);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(123, 45);
            this.btnSalir.TabIndex = 275;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnTipoUsuario
            // 
            this.btnTipoUsuario.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTipoUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnTipoUsuario.Image")));
            this.btnTipoUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTipoUsuario.Location = new System.Drawing.Point(5, 398);
            this.btnTipoUsuario.Name = "btnTipoUsuario";
            this.btnTipoUsuario.Size = new System.Drawing.Size(123, 45);
            this.btnTipoUsuario.TabIndex = 274;
            this.btnTipoUsuario.Text = "Tipo\r\nUsuario";
            this.btnTipoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTipoUsuario.UseVisualStyleBackColor = true;
            this.btnTipoUsuario.Click += new System.EventHandler(this.btnTipoUsuario_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(8, 289);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(123, 45);
            this.btnNuevo.TabIndex = 273;
            this.btnNuevo.Text = "Agregar";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Visible = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(5, 340);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(123, 45);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // botCancelar
            // 
            this.botCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botCancelar.Image")));
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(8, 170);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(123, 45);
            this.botCancelar.TabIndex = 13;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = true;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // botAceptar
            // 
            this.botAceptar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAceptar.Image = ((System.Drawing.Image)(resources.GetObject("botAceptar.Image")));
            this.botAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAceptar.Location = new System.Drawing.Point(5, 53);
            this.botAceptar.Name = "botAceptar";
            this.botAceptar.Size = new System.Drawing.Size(123, 45);
            this.botAceptar.TabIndex = 12;
            this.botAceptar.Text = "Guardar";
            this.botAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAceptar.UseVisualStyleBackColor = true;
            this.botAceptar.Click += new System.EventHandler(this.botAceptar_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // frmUsuariosSistema
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 559);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lblFaltanCargar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUsuariosSistema";
            this.ShowIcon = false;
            this.Text = "Usuarios Sistema";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmUsuariosSistema_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tblBuscar.ResumeLayout(false);
            this.tblBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDatos)).EndInit();
            this.gpbPermisos.ResumeLayout(false);
            this.gpbPermisos.PerformLayout();
            this.gpbAccesoPantallas.ResumeLayout(false);
            this.gpbAccesoPantallas.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.lblFaltanCargar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Panel lblFaltanCargar;
        protected System.Windows.Forms.Button botCancelar;
        protected System.Windows.Forms.Button botAceptar;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgwDatos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkExamenes;
        private System.Windows.Forms.CheckBox chkPacientes;
        private System.Windows.Forms.CheckBox chkConfiguracion;
        private System.Windows.Forms.CheckBox chkMesaEntrada;
        private System.Windows.Forms.CheckBox chkVentanilla;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipoUsuario;
        private System.Windows.Forms.GroupBox gpbAccesoPantallas;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Button btnEliminar;
        protected System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox gpbPermisos;
        private System.Windows.Forms.CheckBox chkEliminar;
        private System.Windows.Forms.CheckBox chkModificar;
        private System.Windows.Forms.CheckBox chkVer;
        private System.Windows.Forms.CheckBox chkTurnos;
        private System.Windows.Forms.CheckBox chkResumen;
        protected System.Windows.Forms.Button btnTipoUsuario;
        private System.Windows.Forms.PictureBox pbFoto;
        protected System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox chkVerAudiometria;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button botModificar;
        private System.Windows.Forms.CheckBox chkMedico;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label label3;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.TextBox txtDNI;
    }
}