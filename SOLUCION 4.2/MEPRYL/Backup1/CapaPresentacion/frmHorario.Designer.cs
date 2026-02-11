namespace CapaPresentacion
{
    partial class frmHorario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHorario));
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.butAceptar1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chDomingo = new System.Windows.Forms.CheckBox();
            this.chSabado = new System.Windows.Forms.CheckBox();
            this.chViernes = new System.Windows.Forms.CheckBox();
            this.chJueves = new System.Windows.Forms.CheckBox();
            this.chMiercoles = new System.Windows.Forms.CheckBox();
            this.chMartes = new System.Windows.Forms.CheckBox();
            this.chLunes = new System.Windows.Forms.CheckBox();
            this.gbActualizando = new System.Windows.Forms.GroupBox();
            this.pbActualizando = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPacientes = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbCitarCada = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCantidadTurnos = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbHoraHasta = new System.Windows.Forms.MaskedTextBox();
            this.tbHoraDesde = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboProfesional = new System.Windows.Forms.ComboBox();
            this.cboaEspecialidad = new UserControls.ucComboBoxActualizable();
            this.panCentro.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panBusqueda.SuspendLayout();
            this.gbControles.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbActualizando.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(738, 444);
            // 
            // panAbajo
            // 
            this.panAbajo.Location = new System.Drawing.Point(0, 484);
            this.panAbajo.Size = new System.Drawing.Size(748, 5);
            // 
            // panDerecha
            // 
            this.panDerecha.Location = new System.Drawing.Point(748, 40);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.LimeGreen;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(822, 0);
            this.pictureBox2.Size = new System.Drawing.Size(43, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.LimeGreen;
            this.lbTitulo.Size = new System.Drawing.Size(865, 40);
            this.lbTitulo.Text = "Horarios";
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(738, 245);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Enabled = false;
            this.tbBusqueda.Size = new System.Drawing.Size(400, 20);
            // 
            // tabPage1
            // 
            this.tabPage1.Size = new System.Drawing.Size(730, 218);
            // 
            // panBusqueda
            // 
            this.panBusqueda.Controls.Add(this.cboProfesional);
            this.panBusqueda.Controls.Add(this.label3);
            this.panBusqueda.Size = new System.Drawing.Size(730, 218);
            this.panBusqueda.Controls.SetChildIndex(this.label3, 0);
            this.panBusqueda.Controls.SetChildIndex(this.cboProfesional, 0);
            this.panBusqueda.Controls.SetChildIndex(this.gbControles, 0);
            this.panBusqueda.Controls.SetChildIndex(this.panBotones, 0);
            // 
            // gbControles
            // 
            this.gbControles.Controls.Add(this.gbActualizando);
            this.gbControles.Controls.Add(this.cboaEspecialidad);
            this.gbControles.Controls.Add(this.butAceptar1);
            this.gbControles.Controls.Add(this.groupBox4);
            this.gbControles.Controls.Add(this.groupBox3);
            this.gbControles.Controls.Add(this.groupBox2);
            this.gbControles.Controls.Add(this.groupBox1);
            this.gbControles.Controls.Add(this.label4);
            this.gbControles.Dock = System.Windows.Forms.DockStyle.None;
            this.gbControles.Location = new System.Drawing.Point(0, 35);
            this.gbControles.Size = new System.Drawing.Size(719, 180);
            this.gbControles.Controls.SetChildIndex(this.label1, 0);
            this.gbControles.Controls.SetChildIndex(this.tbCodigo, 0);
            this.gbControles.Controls.SetChildIndex(this.tbId, 0);
            this.gbControles.Controls.SetChildIndex(this.label4, 0);
            this.gbControles.Controls.SetChildIndex(this.groupBox1, 0);
            this.gbControles.Controls.SetChildIndex(this.groupBox2, 0);
            this.gbControles.Controls.SetChildIndex(this.groupBox3, 0);
            this.gbControles.Controls.SetChildIndex(this.groupBox4, 0);
            this.gbControles.Controls.SetChildIndex(this.butAceptar1, 0);
            this.gbControles.Controls.SetChildIndex(this.cboaEspecialidad, 0);
            this.gbControles.Controls.SetChildIndex(this.gbActualizando, 0);
            // 
            // tbCodigo
            // 
            this.tbCodigo.Location = new System.Drawing.Point(375, 79);
            this.tbCodigo.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(329, 79);
            this.label1.Visible = false;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(312, 87);
            this.tbId.Text = "00000000-0000-0000-0000-000000000000";
            // 
            // butBuscar
            // 
            this.butBuscar.Enabled = false;
            this.butBuscar.Location = new System.Drawing.Point(468, 31);
            // 
            // panBotones
            // 
            this.panBotones.Location = new System.Drawing.Point(725, 0);
            this.panBotones.Size = new System.Drawing.Size(5, 218);
            // 
            // tabPage2
            // 
            this.tabPage2.Size = new System.Drawing.Size(666, 218);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(738, 248);
            // 
            // butImprimir
            // 
            this.butImprimir.Visible = false;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(8, 36);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaDesde.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Desde";
            // 
            // butAceptar1
            // 
            this.butAceptar1.Location = new System.Drawing.Point(604, 168);
            this.butAceptar1.Name = "butAceptar1";
            this.butAceptar1.Size = new System.Drawing.Size(10, 10);
            this.butAceptar1.TabIndex = 57;
            this.butAceptar1.UseVisualStyleBackColor = true;
            this.butAceptar1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "Especialidad";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chDomingo);
            this.groupBox1.Controls.Add(this.chSabado);
            this.groupBox1.Controls.Add(this.chViernes);
            this.groupBox1.Controls.Add(this.chJueves);
            this.groupBox1.Controls.Add(this.chMiercoles);
            this.groupBox1.Controls.Add(this.chMartes);
            this.groupBox1.Controls.Add(this.chLunes);
            this.groupBox1.Location = new System.Drawing.Point(6, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 35);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Días";
            // 
            // chDomingo
            // 
            this.chDomingo.AutoSize = true;
            this.chDomingo.Location = new System.Drawing.Point(8, 14);
            this.chDomingo.Name = "chDomingo";
            this.chDomingo.Size = new System.Drawing.Size(40, 17);
            this.chDomingo.TabIndex = 0;
            this.chDomingo.Text = "Do";
            this.chDomingo.UseVisualStyleBackColor = true;
            // 
            // chSabado
            // 
            this.chSabado.AutoSize = true;
            this.chSabado.Location = new System.Drawing.Point(263, 14);
            this.chSabado.Name = "chSabado";
            this.chSabado.Size = new System.Drawing.Size(39, 17);
            this.chSabado.TabIndex = 6;
            this.chSabado.Text = "Sa";
            this.chSabado.UseVisualStyleBackColor = true;
            // 
            // chViernes
            // 
            this.chViernes.AutoSize = true;
            this.chViernes.Location = new System.Drawing.Point(225, 14);
            this.chViernes.Name = "chViernes";
            this.chViernes.Size = new System.Drawing.Size(35, 17);
            this.chViernes.TabIndex = 5;
            this.chViernes.Text = "Vi";
            this.chViernes.UseVisualStyleBackColor = true;
            // 
            // chJueves
            // 
            this.chJueves.AutoSize = true;
            this.chJueves.Location = new System.Drawing.Point(182, 14);
            this.chJueves.Name = "chJueves";
            this.chJueves.Size = new System.Drawing.Size(37, 17);
            this.chJueves.TabIndex = 4;
            this.chJueves.Text = "Ju";
            this.chJueves.UseVisualStyleBackColor = true;
            // 
            // chMiercoles
            // 
            this.chMiercoles.AutoSize = true;
            this.chMiercoles.Location = new System.Drawing.Point(139, 14);
            this.chMiercoles.Name = "chMiercoles";
            this.chMiercoles.Size = new System.Drawing.Size(37, 17);
            this.chMiercoles.TabIndex = 3;
            this.chMiercoles.Text = "Mi";
            this.chMiercoles.UseVisualStyleBackColor = true;
            // 
            // chMartes
            // 
            this.chMartes.AutoSize = true;
            this.chMartes.Location = new System.Drawing.Point(92, 14);
            this.chMartes.Name = "chMartes";
            this.chMartes.Size = new System.Drawing.Size(41, 17);
            this.chMartes.TabIndex = 2;
            this.chMartes.Text = "Ma";
            this.chMartes.UseVisualStyleBackColor = true;
            // 
            // chLunes
            // 
            this.chLunes.AutoSize = true;
            this.chLunes.Location = new System.Drawing.Point(52, 14);
            this.chLunes.Name = "chLunes";
            this.chLunes.Size = new System.Drawing.Size(38, 17);
            this.chLunes.TabIndex = 1;
            this.chLunes.Text = "Lu";
            this.chLunes.UseVisualStyleBackColor = true;
            // 
            // gbActualizando
            // 
            this.gbActualizando.BackColor = System.Drawing.Color.Cornsilk;
            this.gbActualizando.Controls.Add(this.pbActualizando);
            this.gbActualizando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbActualizando.Location = new System.Drawing.Point(183, 55);
            this.gbActualizando.Name = "gbActualizando";
            this.gbActualizando.Size = new System.Drawing.Size(377, 77);
            this.gbActualizando.TabIndex = 7;
            this.gbActualizando.TabStop = false;
            this.gbActualizando.Text = "Actualizando Turnos...";
            this.gbActualizando.Visible = false;
            // 
            // pbActualizando
            // 
            this.pbActualizando.Location = new System.Drawing.Point(23, 30);
            this.pbActualizando.Name = "pbActualizando";
            this.pbActualizando.Size = new System.Drawing.Size(332, 23);
            this.pbActualizando.Step = 1;
            this.pbActualizando.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbActualizando.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPacientes);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbCitarCada);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbCantidadTurnos);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbHoraHasta);
            this.groupBox2.Controls.Add(this.tbHoraDesde);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(323, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 70);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Horario";
            // 
            // tbPacientes
            // 
            this.tbPacientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPacientes.Location = new System.Drawing.Point(267, 33);
            this.tbPacientes.Mask = "99999";
            this.tbPacientes.Name = "tbPacientes";
            this.tbPacientes.Size = new System.Drawing.Size(52, 20);
            this.tbPacientes.TabIndex = 3;
            this.tbPacientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPacientes.ValidatingType = typeof(int);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(264, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 69;
            this.label11.Text = "Pacientes x Cita";
            // 
            // tbCitarCada
            // 
            this.tbCitarCada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCitarCada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCitarCada.Location = new System.Drawing.Point(183, 33);
            this.tbCitarCada.Mask = "99999";
            this.tbCitarCada.Name = "tbCitarCada";
            this.tbCitarCada.Size = new System.Drawing.Size(52, 20);
            this.tbCitarCada.TabIndex = 2;
            this.tbCitarCada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCitarCada.ValidatingType = typeof(int);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(236, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 67;
            this.label9.Text = "min.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Citar cada";
            // 
            // tbCantidadTurnos
            // 
            this.tbCantidadTurnos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCantidadTurnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCantidadTurnos.Location = new System.Drawing.Point(259, 57);
            this.tbCantidadTurnos.Mask = "99999";
            this.tbCantidadTurnos.Name = "tbCantidadTurnos";
            this.tbCantidadTurnos.Size = new System.Drawing.Size(96, 20);
            this.tbCantidadTurnos.TabIndex = 2;
            this.tbCantidadTurnos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCantidadTurnos.ValidatingType = typeof(int);
            this.tbCantidadTurnos.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(256, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 64;
            this.label10.Text = "Cantidad de turnos";
            this.label10.Visible = false;
            // 
            // tbHoraHasta
            // 
            this.tbHoraHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbHoraHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHoraHasta.Location = new System.Drawing.Point(83, 33);
            this.tbHoraHasta.Mask = "00:00";
            this.tbHoraHasta.Name = "tbHoraHasta";
            this.tbHoraHasta.Size = new System.Drawing.Size(50, 20);
            this.tbHoraHasta.TabIndex = 1;
            this.tbHoraHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbHoraHasta.ValidatingType = typeof(System.DateTime);
            // 
            // tbHoraDesde
            // 
            this.tbHoraDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbHoraDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHoraDesde.Location = new System.Drawing.Point(23, 33);
            this.tbHoraDesde.Mask = "00:00";
            this.tbHoraDesde.Name = "tbHoraDesde";
            this.tbHoraDesde.Size = new System.Drawing.Size(50, 20);
            this.tbHoraDesde.TabIndex = 0;
            this.tbHoraDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbHoraDesde.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Hasta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Desde";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpFechaHasta);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dtpFechaDesde);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(6, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 75);
            this.groupBox3.TabIndex = 64;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Período";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(139, 36);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaHasta.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Hasta";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbObservaciones);
            this.groupBox4.Location = new System.Drawing.Point(323, 95);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(352, 75);
            this.groupBox4.TabIndex = 65;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Observaciones";
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbObservaciones.Location = new System.Drawing.Point(6, 19);
            this.tbObservaciones.Multiline = true;
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObservaciones.Size = new System.Drawing.Size(340, 50);
            this.tbObservaciones.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Profesional";
            // 
            // cboProfesional
            // 
            this.cboProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfesional.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProfesional.FormattingEnabled = true;
            this.cboProfesional.Location = new System.Drawing.Point(64, 9);
            this.cboProfesional.Name = "cboProfesional";
            this.cboProfesional.Size = new System.Drawing.Size(655, 26);
            this.cboProfesional.TabIndex = 0;
            this.cboProfesional.SelectedIndexChanged += new System.EventHandler(this.cboProfesional_SelectedIndexChanged);
            // 
            // cboaEspecialidad
            // 
            this.cboaEspecialidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboaEspecialidad.Location = new System.Drawing.Point(6, 29);
            this.cboaEspecialidad.Name = "cboaEspecialidad";
            this.cboaEspecialidad.Size = new System.Drawing.Size(305, 22);
            this.cboaEspecialidad.TabIndex = 0;
            this.cboaEspecialidad.Load += new System.EventHandler(this.cboaEspecialidad_Load);
            // 
            // frmHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(865, 489);
            this.Name = "frmHorario";
            this.Text = "Horarios";
            this.panCentro.ResumeLayout(false);
            this.panAbajo.ResumeLayout(false);
            this.panAbajo.PerformLayout();
            this.panDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panBusqueda.ResumeLayout(false);
            this.panBusqueda.PerformLayout();
            this.gbControles.ResumeLayout(false);
            this.gbControles.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbActualizando.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DateTimePicker dtpFechaDesde;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butAceptar1;
        protected System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chLunes;
        private System.Windows.Forms.CheckBox chDomingo;
        private System.Windows.Forms.CheckBox chSabado;
        private System.Windows.Forms.CheckBox chViernes;
        private System.Windows.Forms.CheckBox chJueves;
        private System.Windows.Forms.CheckBox chMiercoles;
        private System.Windows.Forms.CheckBox chMartes;
        private System.Windows.Forms.MaskedTextBox tbHoraHasta;
        private System.Windows.Forms.MaskedTextBox tbHoraDesde;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox tbCantidadTurnos;
        private System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.DateTimePicker dtpFechaHasta;
        protected System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        protected System.Windows.Forms.TextBox tbObservaciones;
        private System.Windows.Forms.Label label3;
        private UserControls.ucComboBoxActualizable cboaEspecialidad;
        private System.Windows.Forms.ComboBox cboProfesional;
        private System.Windows.Forms.ProgressBar pbActualizando;
        private System.Windows.Forms.GroupBox gbActualizando;
        private System.Windows.Forms.MaskedTextBox tbCitarCada;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox tbPacientes;
        protected System.Windows.Forms.Label label11;
    }
}
