namespace CapaPresentacion
{
    partial class frmPaciente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaciente));
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.rbOtros = new System.Windows.Forms.RadioButton();
            this.rbLaboral = new System.Windows.Forms.RadioButton();
            this.rbPreventiva = new System.Windows.Forms.RadioButton();
            this.gbLaboral = new System.Windows.Forms.GroupBox();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEmpresaTarea = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gbPreventiva = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbxClub = new System.Windows.Forms.ListBox();
            this.tbBuscarClub = new System.Windows.Forms.TextBox();
            this.cboLiga = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCelular = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.tbNombres = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTelefonos = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbFechaUltimoExamen = new System.Windows.Forms.MaskedTextBox();
            this.lbFechaUltimoExamen = new System.Windows.Forms.Label();
            this.lbTienePlaca = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.panDerecha.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panCentro.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbDatosPersonales.SuspendLayout();
            this.gbLaboral.SuspendLayout();
            this.gbPreventiva.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lbTitulo.Size = new System.Drawing.Size(875, 40);
            this.lbTitulo.Text = "Paciente";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(834, 0);
            this.pictureBox2.Size = new System.Drawing.Size(41, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(737, 490);
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(646, 3);
            // 
            // panDerecha
            // 
            this.panDerecha.Location = new System.Drawing.Point(747, 40);
            this.panDerecha.Size = new System.Drawing.Size(128, 490);
            // 
            // panAbajo
            // 
            this.panAbajo.Location = new System.Drawing.Point(0, 530);
            this.panAbajo.Size = new System.Drawing.Size(875, 24);
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(737, 490);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbTienePlaca);
            this.tabPage1.Controls.Add(this.tbFechaUltimoExamen);
            this.tabPage1.Controls.Add(this.lbFechaUltimoExamen);
            this.tabPage1.Controls.Add(this.gbDatosPersonales);
            this.tabPage1.Size = new System.Drawing.Size(729, 463);
            this.tabPage1.Controls.SetChildIndex(this.tbId, 0);
            this.tabPage1.Controls.SetChildIndex(this.gbDatosPersonales, 0);
            this.tabPage1.Controls.SetChildIndex(this.label1, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbCodigo, 0);
            this.tabPage1.Controls.SetChildIndex(this.butBuscar, 0);
            this.tabPage1.Controls.SetChildIndex(this.lbFechaUltimoExamen, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbFechaUltimoExamen, 0);
            this.tabPage1.Controls.SetChildIndex(this.lbTienePlaca, 0);
            // 
            // label1
            // 
            this.label1.Text = "Buscar";
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(747, 0);
            this.butSalir.Size = new System.Drawing.Size(128, 24);
            // 
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.rbOtros);
            this.gbDatosPersonales.Controls.Add(this.rbLaboral);
            this.gbDatosPersonales.Controls.Add(this.rbPreventiva);
            this.gbDatosPersonales.Controls.Add(this.gbLaboral);
            this.gbDatosPersonales.Controls.Add(this.gbPreventiva);
            this.gbDatosPersonales.Controls.Add(this.tbCelular);
            this.gbDatosPersonales.Controls.Add(this.label4);
            this.gbDatosPersonales.Controls.Add(this.dtpFechaNacimiento);
            this.gbDatosPersonales.Controls.Add(this.label2);
            this.gbDatosPersonales.Controls.Add(this.tbApellido);
            this.gbDatosPersonales.Controls.Add(this.tbNombres);
            this.gbDatosPersonales.Controls.Add(this.label3);
            this.gbDatosPersonales.Controls.Add(this.label13);
            this.gbDatosPersonales.Controls.Add(this.tbObservaciones);
            this.gbDatosPersonales.Controls.Add(this.tbDNI);
            this.gbDatosPersonales.Controls.Add(this.label8);
            this.gbDatosPersonales.Controls.Add(this.label9);
            this.gbDatosPersonales.Controls.Add(this.tbTelefonos);
            this.gbDatosPersonales.Controls.Add(this.label10);
            this.gbDatosPersonales.Location = new System.Drawing.Point(2, 69);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(709, 391);
            this.gbDatosPersonales.TabIndex = 39;
            this.gbDatosPersonales.TabStop = false;
            // 
            // rbOtros
            // 
            this.rbOtros.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOtros.AutoSize = true;
            this.rbOtros.Location = new System.Drawing.Point(37, 273);
            this.rbOtros.Name = "rbOtros";
            this.rbOtros.Size = new System.Drawing.Size(42, 23);
            this.rbOtros.TabIndex = 36;
            this.rbOtros.Text = "Otros";
            this.rbOtros.UseVisualStyleBackColor = true;
            this.rbOtros.CheckedChanged += new System.EventHandler(this.rbOtros_CheckedChanged);
            // 
            // rbLaboral
            // 
            this.rbLaboral.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbLaboral.AutoSize = true;
            this.rbLaboral.Location = new System.Drawing.Point(27, 209);
            this.rbLaboral.Name = "rbLaboral";
            this.rbLaboral.Size = new System.Drawing.Size(52, 23);
            this.rbLaboral.TabIndex = 35;
            this.rbLaboral.Text = "Laboral";
            this.rbLaboral.UseVisualStyleBackColor = true;
            this.rbLaboral.CheckedChanged += new System.EventHandler(this.rbLaboral_CheckedChanged);
            // 
            // rbPreventiva
            // 
            this.rbPreventiva.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbPreventiva.AutoSize = true;
            this.rbPreventiva.Checked = true;
            this.rbPreventiva.Location = new System.Drawing.Point(11, 78);
            this.rbPreventiva.Name = "rbPreventiva";
            this.rbPreventiva.Size = new System.Drawing.Size(68, 23);
            this.rbPreventiva.TabIndex = 34;
            this.rbPreventiva.TabStop = true;
            this.rbPreventiva.Text = "Preventiva";
            this.rbPreventiva.UseVisualStyleBackColor = true;
            this.rbPreventiva.CheckedChanged += new System.EventHandler(this.rbPreventiva_CheckedChanged);
            // 
            // gbLaboral
            // 
            this.gbLaboral.Controls.Add(this.cboEmpresa);
            this.gbLaboral.Controls.Add(this.label5);
            this.gbLaboral.Controls.Add(this.tbEmpresaTarea);
            this.gbLaboral.Controls.Add(this.label11);
            this.gbLaboral.Location = new System.Drawing.Point(85, 201);
            this.gbLaboral.Name = "gbLaboral";
            this.gbLaboral.Size = new System.Drawing.Size(616, 67);
            this.gbLaboral.TabIndex = 33;
            this.gbLaboral.TabStop = false;
            this.gbLaboral.Visible = false;
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(8, 30);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(276, 21);
            this.cboEmpresa.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Empresa";
            // 
            // tbEmpresaTarea
            // 
            this.tbEmpresaTarea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEmpresaTarea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbEmpresaTarea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmpresaTarea.Location = new System.Drawing.Point(290, 30);
            this.tbEmpresaTarea.Name = "tbEmpresaTarea";
            this.tbEmpresaTarea.Size = new System.Drawing.Size(310, 20);
            this.tbEmpresaTarea.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(289, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Tarea";
            // 
            // gbPreventiva
            // 
            this.gbPreventiva.Controls.Add(this.label12);
            this.gbPreventiva.Controls.Add(this.lbxClub);
            this.gbPreventiva.Controls.Add(this.tbBuscarClub);
            this.gbPreventiva.Controls.Add(this.cboLiga);
            this.gbPreventiva.Controls.Add(this.label6);
            this.gbPreventiva.Controls.Add(this.label7);
            this.gbPreventiva.Location = new System.Drawing.Point(85, 70);
            this.gbPreventiva.Name = "gbPreventiva";
            this.gbPreventiva.Size = new System.Drawing.Size(613, 131);
            this.gbPreventiva.TabIndex = 32;
            this.gbPreventiva.TabStop = false;
            this.gbPreventiva.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(565, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Buscar";
            // 
            // lbxClub
            // 
            this.lbxClub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxClub.FormattingEnabled = true;
            this.lbxClub.Location = new System.Drawing.Point(293, 51);
            this.lbxClub.Name = "lbxClub";
            this.lbxClub.Size = new System.Drawing.Size(310, 67);
            this.lbxClub.TabIndex = 31;
            // 
            // tbBuscarClub
            // 
            this.tbBuscarClub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBuscarClub.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBuscarClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBuscarClub.Location = new System.Drawing.Point(293, 29);
            this.tbBuscarClub.Name = "tbBuscarClub";
            this.tbBuscarClub.Size = new System.Drawing.Size(266, 20);
            this.tbBuscarClub.TabIndex = 30;
            this.tbBuscarClub.TextChanged += new System.EventHandler(this.tbBuscarClub_TextChanged);
            // 
            // cboLiga
            // 
            this.cboLiga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLiga.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboLiga.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLiga.FormattingEnabled = true;
            this.cboLiga.Location = new System.Drawing.Point(12, 29);
            this.cboLiga.Name = "cboLiga";
            this.cboLiga.Size = new System.Drawing.Size(276, 21);
            this.cboLiga.TabIndex = 4;
            this.cboLiga.SelectedIndexChanged += new System.EventHandler(this.cboLiga_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Liga";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Club";
            // 
            // tbCelular
            // 
            this.tbCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCelular.Location = new System.Drawing.Point(11, 365);
            this.tbCelular.Name = "tbCelular";
            this.tbCelular.Size = new System.Drawing.Size(328, 20);
            this.tbCelular.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Celular (administrado por DataSMS)";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(522, 35);
            this.dtpFechaNacimiento.Mask = "00/00/0000";
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(86, 20);
            this.dtpFechaNacimiento.TabIndex = 2;
            this.dtpFechaNacimiento.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Apellido";
            // 
            // tbApellido
            // 
            this.tbApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApellido.Location = new System.Drawing.Point(11, 35);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(162, 20);
            this.tbApellido.TabIndex = 0;
            // 
            // tbNombres
            // 
            this.tbNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombres.Location = new System.Drawing.Point(177, 35);
            this.tbNombres.Name = "tbNombres";
            this.tbNombres.Size = new System.Drawing.Size(162, 20);
            this.tbNombres.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombres";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(351, 299);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Observaciones";
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbObservaciones.Location = new System.Drawing.Point(354, 316);
            this.tbObservaciones.Multiline = true;
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObservaciones.Size = new System.Drawing.Size(344, 69);
            this.tbObservaciones.TabIndex = 8;
            // 
            // tbDNI
            // 
            this.tbDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDNI.Location = new System.Drawing.Point(354, 35);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(119, 29);
            this.tbDNI.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(351, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "DNI";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(519, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Fecha  de Nacimiento";
            // 
            // tbTelefonos
            // 
            this.tbTelefonos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTelefonos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbTelefonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTelefonos.Location = new System.Drawing.Point(11, 316);
            this.tbTelefonos.Name = "tbTelefonos";
            this.tbTelefonos.Size = new System.Drawing.Size(328, 20);
            this.tbTelefonos.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 299);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Teléfonos";
            // 
            // tbFechaUltimoExamen
            // 
            this.tbFechaUltimoExamen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFechaUltimoExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFechaUltimoExamen.Location = new System.Drawing.Point(356, 34);
            this.tbFechaUltimoExamen.Mask = "00/00/0000";
            this.tbFechaUltimoExamen.Name = "tbFechaUltimoExamen";
            this.tbFechaUltimoExamen.ReadOnly = true;
            this.tbFechaUltimoExamen.Size = new System.Drawing.Size(119, 29);
            this.tbFechaUltimoExamen.TabIndex = 40;
            this.tbFechaUltimoExamen.ValidatingType = typeof(System.DateTime);
            // 
            // lbFechaUltimoExamen
            // 
            this.lbFechaUltimoExamen.AutoSize = true;
            this.lbFechaUltimoExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaUltimoExamen.Location = new System.Drawing.Point(353, 12);
            this.lbFechaUltimoExamen.Name = "lbFechaUltimoExamen";
            this.lbFechaUltimoExamen.Size = new System.Drawing.Size(158, 16);
            this.lbFechaUltimoExamen.TabIndex = 41;
            this.lbFechaUltimoExamen.Text = "Fecha Último Examen";
            // 
            // lbTienePlaca
            // 
            this.lbTienePlaca.AutoSize = true;
            this.lbTienePlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTienePlaca.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbTienePlaca.Location = new System.Drawing.Point(481, 34);
            this.lbTienePlaca.Name = "lbTienePlaca";
            this.lbTienePlaca.Size = new System.Drawing.Size(0, 24);
            this.lbTienePlaca.TabIndex = 42;
            // 
            // frmPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(875, 554);
            this.Name = "frmPaciente";
            this.Text = "Paciente";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.panDerecha.ResumeLayout(false);
            this.panAbajo.ResumeLayout(false);
            this.panAbajo.PerformLayout();
            this.panCentro.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbDatosPersonales.ResumeLayout(false);
            this.gbDatosPersonales.PerformLayout();
            this.gbLaboral.ResumeLayout(false);
            this.gbLaboral.PerformLayout();
            this.gbPreventiva.ResumeLayout(false);
            this.gbPreventiva.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosPersonales;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox tbApellido;
        protected System.Windows.Forms.TextBox tbNombres;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.TextBox tbObservaciones;
        protected System.Windows.Forms.TextBox tbDNI;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.TextBox tbTelefonos;
        protected System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboLiga;
        private System.Windows.Forms.MaskedTextBox dtpFechaNacimiento;
        protected System.Windows.Forms.TextBox tbCelular;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox tbEmpresaTarea;
        protected System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.GroupBox gbPreventiva;
        private System.Windows.Forms.GroupBox gbLaboral;
        private System.Windows.Forms.RadioButton rbOtros;
        private System.Windows.Forms.RadioButton rbLaboral;
        private System.Windows.Forms.RadioButton rbPreventiva;
        private System.Windows.Forms.MaskedTextBox tbFechaUltimoExamen;
        protected System.Windows.Forms.Label lbFechaUltimoExamen;
        protected System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lbxClub;
        protected System.Windows.Forms.TextBox tbBuscarClub;
        protected System.Windows.Forms.Label lbTienePlaca;
    }
}
