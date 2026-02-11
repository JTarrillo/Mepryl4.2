namespace CapaPresentacion
{
    partial class frmProfesionales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfesionales));
            this.botonLaboratorio = new System.Windows.Forms.Panel();
            this.botModificar = new System.Windows.Forms.Button();
            this.botVolver = new System.Windows.Forms.Button();
            this.botCancelar = new System.Windows.Forms.Button();
            this.botGuardar = new System.Windows.Forms.Button();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label66 = new System.Windows.Forms.Label();
            this.cboTipoContribuyente = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.tbNroDocumento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboLugarMatricula = new System.Windows.Forms.ComboBox();
            this.tbNroMatricula = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboEspecialidad = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tbLocalidad = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.tbCodigoPostal = new System.Windows.Forms.TextBox();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.tbCelular = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.cbRealizaVisitasCapital = new System.Windows.Forms.CheckBox();
            this.cbRealizaVisitasProvincia = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboEstadoCivil = new System.Windows.Forms.ComboBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.botonLaboratorio.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonLaboratorio
            // 
            this.botonLaboratorio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botonLaboratorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.botonLaboratorio.Controls.Add(this.botModificar);
            this.botonLaboratorio.Controls.Add(this.botVolver);
            this.botonLaboratorio.Controls.Add(this.botCancelar);
            this.botonLaboratorio.Controls.Add(this.botGuardar);
            this.botonLaboratorio.Dock = System.Windows.Forms.DockStyle.Right;
            this.botonLaboratorio.Location = new System.Drawing.Point(929, 40);
            this.botonLaboratorio.Name = "botonLaboratorio";
            this.botonLaboratorio.Size = new System.Drawing.Size(155, 541);
            this.botonLaboratorio.TabIndex = 12;
            // 
            // botModificar
            // 
            this.botModificar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botModificar.Image = ((System.Drawing.Image)(resources.GetObject("botModificar.Image")));
            this.botModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botModificar.Location = new System.Drawing.Point(10, 198);
            this.botModificar.Name = "botModificar";
            this.botModificar.Size = new System.Drawing.Size(135, 46);
            this.botModificar.TabIndex = 1;
            this.botModificar.Text = "Modificar";
            this.botModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botModificar.UseVisualStyleBackColor = true;
            this.botModificar.Click += new System.EventHandler(this.botModificar_Click);
            // 
            // botVolver
            // 
            this.botVolver.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botVolver.Image = ((System.Drawing.Image)(resources.GetObject("botVolver.Image")));
            this.botVolver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botVolver.Location = new System.Drawing.Point(10, 250);
            this.botVolver.Name = "botVolver";
            this.botVolver.Size = new System.Drawing.Size(135, 46);
            this.botVolver.TabIndex = 2;
            this.botVolver.Text = "Volver";
            this.botVolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botVolver.UseVisualStyleBackColor = true;
            this.botVolver.Click += new System.EventHandler(this.botVolver_Click);
            // 
            // botCancelar
            // 
            this.botCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botCancelar.Image")));
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(10, 198);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(135, 46);
            this.botCancelar.TabIndex = 1;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = true;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // botGuardar
            // 
            this.botGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botGuardar.Image = ((System.Drawing.Image)(resources.GetObject("botGuardar.Image")));
            this.botGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botGuardar.Location = new System.Drawing.Point(10, 146);
            this.botGuardar.Name = "botGuardar";
            this.botGuardar.Size = new System.Drawing.Size(135, 46);
            this.botGuardar.TabIndex = 0;
            this.botGuardar.Text = "Guardar";
            this.botGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botGuardar.UseVisualStyleBackColor = true;
            this.botGuardar.Click += new System.EventHandler(this.botGuardar_Click);
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.ForestGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1084, 40);
            this.lbTitulo.TabIndex = 131;
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label66);
            this.panel1.Controls.Add(this.cboTipoContribuyente);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboTipoDocumento);
            this.panel1.Controls.Add(this.tbNroDocumento);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(81, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 77);
            this.panel1.TabIndex = 7;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(3, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(132, 16);
            this.label66.TabIndex = 32;
            this.label66.Text = "Datos Impositivos";
            // 
            // cboTipoContribuyente
            // 
            this.cboTipoContribuyente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboTipoContribuyente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoContribuyente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoContribuyente.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTipoContribuyente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoContribuyente.FormattingEnabled = true;
            this.cboTipoContribuyente.Items.AddRange(new object[] {
            "RESPONSABLE INSCRIPTO",
            "MONOTRIBUTISTA",
            "CONSUMIDOR FINAL",
            "EXENTO",
            "NO ALCANZADO"});
            this.cboTipoContribuyente.Location = new System.Drawing.Point(243, 41);
            this.cboTipoContribuyente.Name = "cboTipoContribuyente";
            this.cboTipoContribuyente.Size = new System.Drawing.Size(280, 28);
            this.cboTipoContribuyente.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Tipo de Doc.";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboTipoDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Items.AddRange(new object[] {
            "CUIT",
            "CUIL",
            "DNI"});
            this.cboTipoDocumento.Location = new System.Drawing.Point(9, 41);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(97, 28);
            this.cboTipoDocumento.TabIndex = 0;
            // 
            // tbNroDocumento
            // 
            this.tbNroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNroDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroDocumento.Location = new System.Drawing.Point(112, 42);
            this.tbNroDocumento.MaxLength = 11;
            this.tbNroDocumento.Name = "tbNroDocumento";
            this.tbNroDocumento.Size = new System.Drawing.Size(125, 26);
            this.tbNroDocumento.TabIndex = 1;
            this.tbNroDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(109, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "Nro. Documento";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(240, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 16);
            this.label15.TabIndex = 28;
            this.label15.Text = "Tipo de Contribuyente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 135;
            this.label1.Text = "Dr./Dra.";
            // 
            // cboDoctor
            // 
            this.cboDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoctor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Items.AddRange(new object[] {
            "DR.",
            "DRA."});
            this.cboDoctor.Location = new System.Drawing.Point(81, 83);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(97, 28);
            this.cboDoctor.TabIndex = 0;
            // 
            // tbApellido
            // 
            this.tbApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApellido.Location = new System.Drawing.Point(184, 84);
            this.tbApellido.MaxLength = 256;
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(327, 26);
            this.tbApellido.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(181, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 137;
            this.label2.Text = "Apellido";
            // 
            // tbNombre
            // 
            this.tbNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(517, 84);
            this.tbNombre.MaxLength = 256;
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(327, 26);
            this.tbNombre.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(514, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 139;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 141;
            this.label4.Text = "Tipo Matrícula";
            // 
            // cboLugarMatricula
            // 
            this.cboLugarMatricula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLugarMatricula.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboLugarMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLugarMatricula.FormattingEnabled = true;
            this.cboLugarMatricula.Items.AddRange(new object[] {
            "M.N.:",
            "M.P.:"});
            this.cboLugarMatricula.Location = new System.Drawing.Point(81, 135);
            this.cboLugarMatricula.Name = "cboLugarMatricula";
            this.cboLugarMatricula.Size = new System.Drawing.Size(97, 28);
            this.cboLugarMatricula.TabIndex = 3;
            // 
            // tbNroMatricula
            // 
            this.tbNroMatricula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNroMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroMatricula.Location = new System.Drawing.Point(184, 136);
            this.tbNroMatricula.MaxLength = 10;
            this.tbNroMatricula.Name = "tbNroMatricula";
            this.tbNroMatricula.Size = new System.Drawing.Size(125, 26);
            this.tbNroMatricula.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(181, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 143;
            this.label5.Text = "Nro. Matrícula";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(78, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 145;
            this.label8.Text = "Especialidad";
            // 
            // cboEspecialidad
            // 
            this.cboEspecialidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboEspecialidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboEspecialidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEspecialidad.FormattingEnabled = true;
            this.cboEspecialidad.Items.AddRange(new object[] {
            "CLINICA MEDICA",
            "CARDIOLOGIA",
            "CIRUGIA GENERAL",
            "DERMATOLOGIA",
            "GINECOLOGIA",
            "GASTROENTEROLOGIA",
            "NEUROLOGIA",
            "OFTALMOLOGIA",
            "OTORRINOLARINGOLOGIA",
            "ODONTOLOGIA",
            "PSICOLOGIA",
            "RADIOLOGIA",
            "TRAUMATOLOGIA",
            "FONOAUDIOLOGIA",
            "KINESIOLOGIA",
            "ANESTESIOLOGIA",
            "PSIQUIATRIA",
            "RECONOCIMIENTO A DOMICILIO",
            "CHEQUEOS EN PLANTA",
            "MEDICINA DEL TRABAJO",
            "OTRAS"});
            this.cboEspecialidad.Location = new System.Drawing.Point(81, 188);
            this.cboEspecialidad.Name = "cboEspecialidad";
            this.cboEspecialidad.Size = new System.Drawing.Size(337, 28);
            this.cboEspecialidad.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cboProvincia);
            this.panel5.Controls.Add(this.label29);
            this.panel5.Controls.Add(this.label28);
            this.panel5.Controls.Add(this.tbLocalidad);
            this.panel5.Controls.Add(this.label63);
            this.panel5.Controls.Add(this.tbCodigoPostal);
            this.panel5.Controls.Add(this.tbDireccion);
            this.panel5.Controls.Add(this.label26);
            this.panel5.Controls.Add(this.label27);
            this.panel5.Location = new System.Drawing.Point(81, 303);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(763, 123);
            this.panel5.TabIndex = 8;
            // 
            // cboProvincia
            // 
            this.cboProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Items.AddRange(new object[] {
            "BUENOS AIRES",
            "CABA",
            "CATAMARCA",
            "CHACO",
            "CHUBUT",
            "CORDOBA",
            "CORRIENTES",
            "ENTRE RIOS",
            "FORMOSA",
            "JUJUY",
            "LA PAMPA",
            "LA RIOJA",
            "MENDOZA",
            "MISIONES",
            "NEUQUEN",
            "RIO NEGRO",
            "SALTA",
            "SAN JUAN",
            "SAN LUIS",
            "SANTA CRUZ",
            "SANTA FE",
            "SANTIAGO DEL ESTERO",
            "TIERRA DEL FUEGO",
            "TUCUMAN"});
            this.cboProvincia.Location = new System.Drawing.Point(395, 89);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(354, 28);
            this.cboProvincia.TabIndex = 3;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(392, 69);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(64, 16);
            this.label29.TabIndex = 44;
            this.label29.Text = "Provincia";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(6, 69);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(68, 16);
            this.label28.TabIndex = 42;
            this.label28.Text = "Localidad";
            // 
            // tbLocalidad
            // 
            this.tbLocalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLocalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLocalidad.Location = new System.Drawing.Point(9, 90);
            this.tbLocalidad.MaxLength = 100;
            this.tbLocalidad.Name = "tbLocalidad";
            this.tbLocalidad.Size = new System.Drawing.Size(380, 26);
            this.tbLocalidad.TabIndex = 2;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.Location = new System.Drawing.Point(3, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(144, 16);
            this.label63.TabIndex = 32;
            this.label63.Text = "Datos Domiciliarios";
            // 
            // tbCodigoPostal
            // 
            this.tbCodigoPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodigoPostal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCodigoPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigoPostal.Location = new System.Drawing.Point(606, 39);
            this.tbCodigoPostal.MaxLength = 10;
            this.tbCodigoPostal.Name = "tbCodigoPostal";
            this.tbCodigoPostal.Size = new System.Drawing.Size(143, 26);
            this.tbCodigoPostal.TabIndex = 1;
            // 
            // tbDireccion
            // 
            this.tbDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDireccion.Location = new System.Drawing.Point(9, 39);
            this.tbDireccion.MaxLength = 150;
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(591, 26);
            this.tbDireccion.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(6, 19);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 16);
            this.label26.TabIndex = 34;
            this.label26.Text = "Dirección";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(603, 19);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(93, 16);
            this.label27.TabIndex = 36;
            this.label27.Text = "Código Postal";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label39);
            this.panel2.Controls.Add(this.tbMail);
            this.panel2.Controls.Add(this.tbCelular);
            this.panel2.Controls.Add(this.label37);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.tbTelefono);
            this.panel2.Location = new System.Drawing.Point(81, 430);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 76);
            this.panel2.TabIndex = 9;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(392, 22);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(33, 16);
            this.label39.TabIndex = 40;
            this.label39.Text = "Mail";
            // 
            // tbMail
            // 
            this.tbMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMail.Location = new System.Drawing.Point(395, 42);
            this.tbMail.MaxLength = 100;
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(354, 26);
            this.tbMail.TabIndex = 2;
            // 
            // tbCelular
            // 
            this.tbCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCelular.Location = new System.Drawing.Point(202, 42);
            this.tbCelular.MaxLength = 10;
            this.tbCelular.Name = "tbCelular";
            this.tbCelular.Size = new System.Drawing.Size(187, 26);
            this.tbCelular.TabIndex = 1;
            this.tbCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(199, 22);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(50, 16);
            this.label37.TabIndex = 38;
            this.label37.Text = "Celular";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(3, 3);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(136, 16);
            this.label32.TabIndex = 32;
            this.label32.Text = "Datos de Contacto";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(6, 22);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(62, 16);
            this.label36.TabIndex = 36;
            this.label36.Text = "Teléfono";
            // 
            // tbTelefono
            // 
            this.tbTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTelefono.Location = new System.Drawing.Point(9, 42);
            this.tbTelefono.MaxLength = 10;
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(187, 26);
            this.tbTelefono.TabIndex = 0;
            this.tbTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbRealizaVisitasCapital
            // 
            this.cbRealizaVisitasCapital.AutoSize = true;
            this.cbRealizaVisitasCapital.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRealizaVisitasCapital.Location = new System.Drawing.Point(81, 510);
            this.cbRealizaVisitasCapital.Name = "cbRealizaVisitasCapital";
            this.cbRealizaVisitasCapital.Size = new System.Drawing.Size(207, 24);
            this.cbRealizaVisitasCapital.TabIndex = 10;
            this.cbRealizaVisitasCapital.Text = "Realiza Visitas en Capital";
            this.cbRealizaVisitasCapital.UseVisualStyleBackColor = true;
            // 
            // cbRealizaVisitasProvincia
            // 
            this.cbRealizaVisitasProvincia.AutoSize = true;
            this.cbRealizaVisitasProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRealizaVisitasProvincia.Location = new System.Drawing.Point(81, 536);
            this.cbRealizaVisitasProvincia.Name = "cbRealizaVisitasProvincia";
            this.cbRealizaVisitasProvincia.Size = new System.Drawing.Size(221, 24);
            this.cbRealizaVisitasProvincia.TabIndex = 11;
            this.cbRealizaVisitasProvincia.Text = "Realiza Visitas en Provincia";
            this.cbRealizaVisitasProvincia.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(421, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 16);
            this.label9.TabIndex = 151;
            this.label9.Text = "Estado Civil";
            // 
            // cboEstadoCivil
            // 
            this.cboEstadoCivil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboEstadoCivil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoCivil.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboEstadoCivil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstadoCivil.FormattingEnabled = true;
            this.cboEstadoCivil.Items.AddRange(new object[] {
            "SOLTERO/A",
            "CASADO/A",
            "DIVORCIADO/A",
            "VIUDO/A",
            "CONCUBINATO"});
            this.cboEstadoCivil.Location = new System.Drawing.Point(424, 188);
            this.cboEstadoCivil.Name = "cboEstadoCivil";
            this.cboEstadoCivil.Size = new System.Drawing.Size(181, 28);
            this.cboEstadoCivil.TabIndex = 6;
            // 
            // tbId
            // 
            this.tbId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbId.Location = new System.Drawing.Point(817, 135);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(27, 26);
            this.tbId.TabIndex = 152;
            this.tbId.Visible = false;
            // 
            // frmProfesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 581);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboEstadoCivil);
            this.Controls.Add(this.cbRealizaVisitasProvincia);
            this.Controls.Add(this.cbRealizaVisitasCapital);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboEspecialidad);
            this.Controls.Add(this.tbNroMatricula);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboLugarMatricula);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDoctor);
            this.Controls.Add(this.tbApellido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botonLaboratorio);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProfesionales";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profesionales";
            this.botonLaboratorio.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel botonLaboratorio;
        private System.Windows.Forms.Button botVolver;
        private System.Windows.Forms.Button botCancelar;
        private System.Windows.Forms.Button botGuardar;
        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.ComboBox cboTipoContribuyente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.TextBox tbNroDocumento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboLugarMatricula;
        private System.Windows.Forms.TextBox tbNroMatricula;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboEspecialidad;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbLocalidad;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TextBox tbCodigoPostal;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.TextBox tbCelular;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.CheckBox cbRealizaVisitasCapital;
        private System.Windows.Forms.CheckBox cbRealizaVisitasProvincia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboEstadoCivil;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Button botModificar;
    }
}