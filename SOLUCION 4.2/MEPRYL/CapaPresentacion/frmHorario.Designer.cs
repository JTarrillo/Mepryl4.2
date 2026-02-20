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
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboProfesional = new System.Windows.Forms.ComboBox();
            this.cboEspecialidad = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gbActualizando = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cboMotivo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboSubtipo = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
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
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbActualizando.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(1142, 482);
            // 
            // panAbajo
            // 
            this.panAbajo.Location = new System.Drawing.Point(0, 512);
            this.panAbajo.Size = new System.Drawing.Size(1152, 5);
            // 
            // panDerecha
            // 
            this.panDerecha.Controls.Add(this.btnSalir);
            this.panDerecha.Location = new System.Drawing.Point(1152, 30);
            this.panDerecha.Size = new System.Drawing.Size(145, 487);
            this.panDerecha.Controls.SetChildIndex(this.butModificar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAceptar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butEliminar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butCancelar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAgregar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butSalir, 0);
            this.panDerecha.Controls.SetChildIndex(this.butImprimir, 0);
            this.panDerecha.Controls.SetChildIndex(this.btnSalir, 0);
            // 
            // butCancelar
            // 
            this.butCancelar.Location = new System.Drawing.Point(13, 266);
            this.butCancelar.Click += new System.EventHandler(this.butCancelar_Click_1);
            // 
            // butAceptar
            // 
            this.butAceptar.Location = new System.Drawing.Point(13, 204);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.LimeGreen;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(925, 0);
            this.pictureBox2.Size = new System.Drawing.Size(43, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.Visible = false;
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(0, 442);
            this.butSalir.Size = new System.Drawing.Size(145, 45);
            this.butSalir.UseVisualStyleBackColor = true;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(1142, 295);
            this.tabPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabPrincipal_SelectedIndexChanged);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Enabled = false;
            this.tbBusqueda.Location = new System.Drawing.Point(16, 45);
            this.tbBusqueda.Size = new System.Drawing.Size(486, 22);
            // 
            // labe2
            // 
            this.labe2.Location = new System.Drawing.Point(14, 24);
            // 
            // tabPage1
            // 
            this.tabPage1.Size = new System.Drawing.Size(1134, 266);
            // 
            // panBusqueda
            // 
            this.panBusqueda.BackColor = System.Drawing.SystemColors.Control;
            this.panBusqueda.Controls.Add(this.label15);
            this.panBusqueda.Controls.Add(this.cboSubtipo);
            this.panBusqueda.Controls.Add(this.cboProfesional);
            this.panBusqueda.Controls.Add(this.label3);
            this.panBusqueda.Size = new System.Drawing.Size(1134, 266);
            this.panBusqueda.Controls.SetChildIndex(this.label3, 0);
            this.panBusqueda.Controls.SetChildIndex(this.cboProfesional, 0);
            this.panBusqueda.Controls.SetChildIndex(this.gbControles, 0);
            this.panBusqueda.Controls.SetChildIndex(this.panBotones, 0);
            this.panBusqueda.Controls.SetChildIndex(this.cboSubtipo, 0);
            this.panBusqueda.Controls.SetChildIndex(this.label15, 0);
            // 
            // gbControles
            // 
            this.gbControles.Controls.Add(this.label14);
            this.gbControles.Controls.Add(this.gbActualizando);
            this.gbControles.Controls.Add(this.label13);
            this.gbControles.Controls.Add(this.tbObservaciones);
            this.gbControles.Controls.Add(this.cboEspecialidad);
            this.gbControles.Controls.Add(this.butAceptar1);
            this.gbControles.Controls.Add(this.groupBox3);
            this.gbControles.Controls.Add(this.groupBox2);
            this.gbControles.Controls.Add(this.groupBox1);
            this.gbControles.Controls.Add(this.label4);
            this.gbControles.Controls.Add(this.cboMotivo);
            this.gbControles.Dock = System.Windows.Forms.DockStyle.None;
            this.gbControles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbControles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbControles.Location = new System.Drawing.Point(8, 55);
            this.gbControles.Size = new System.Drawing.Size(1115, 205);
            this.gbControles.Controls.SetChildIndex(this.cboMotivo, 0);
            this.gbControles.Controls.SetChildIndex(this.label1, 0);
            this.gbControles.Controls.SetChildIndex(this.tbCodigo, 0);
            this.gbControles.Controls.SetChildIndex(this.tbId, 0);
            this.gbControles.Controls.SetChildIndex(this.label4, 0);
            this.gbControles.Controls.SetChildIndex(this.groupBox1, 0);
            this.gbControles.Controls.SetChildIndex(this.groupBox2, 0);
            this.gbControles.Controls.SetChildIndex(this.groupBox3, 0);
            this.gbControles.Controls.SetChildIndex(this.butAceptar1, 0);
            this.gbControles.Controls.SetChildIndex(this.cboEspecialidad, 0);
            this.gbControles.Controls.SetChildIndex(this.tbObservaciones, 0);
            this.gbControles.Controls.SetChildIndex(this.label13, 0);
            this.gbControles.Controls.SetChildIndex(this.gbActualizando, 0);
            this.gbControles.Controls.SetChildIndex(this.label14, 0);
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
            // panBotones
            // 
            this.panBotones.Location = new System.Drawing.Point(1129, 0);
            this.panBotones.Size = new System.Drawing.Size(5, 266);
            // 
            // tabPage2
            // 
            this.tabPage2.Size = new System.Drawing.Size(1134, 266);
            this.tabPage2.Text = "Búsqueda";
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1142, 299);
            // 
            // butImprimir
            // 
            this.butImprimir.Location = new System.Drawing.Point(13, 343);
            this.butImprimir.Visible = false;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SeaGreen;
            this.lbTitulo.Size = new System.Drawing.Size(1297, 30);
            this.lbTitulo.Text = "Horarios";
            // 
            // butBuscar
            // 
            this.butBuscar.Enabled = false;
            this.butBuscar.Location = new System.Drawing.Point(508, 39);
            this.butBuscar.UseVisualStyleBackColor = true;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(28, 47);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(98, 22);
            this.dtpFechaDesde.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
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
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 61;
            this.label4.Text = "Motivo de Consulta";
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
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 45);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Días";
            // 
            // chDomingo
            // 
            this.chDomingo.AutoSize = true;
            this.chDomingo.Location = new System.Drawing.Point(29, 20);
            this.chDomingo.Name = "chDomingo";
            this.chDomingo.Size = new System.Drawing.Size(44, 20);
            this.chDomingo.TabIndex = 0;
            this.chDomingo.Text = "Do";
            this.chDomingo.UseVisualStyleBackColor = true;
            // 
            // chSabado
            // 
            this.chSabado.AutoSize = true;
            this.chSabado.Location = new System.Drawing.Point(297, 20);
            this.chSabado.Name = "chSabado";
            this.chSabado.Size = new System.Drawing.Size(43, 20);
            this.chSabado.TabIndex = 6;
            this.chSabado.Text = "Sa";
            this.chSabado.UseVisualStyleBackColor = true;
            // 
            // chViernes
            // 
            this.chViernes.AutoSize = true;
            this.chViernes.Location = new System.Drawing.Point(255, 20);
            this.chViernes.Name = "chViernes";
            this.chViernes.Size = new System.Drawing.Size(38, 20);
            this.chViernes.TabIndex = 5;
            this.chViernes.Text = "Vi";
            this.chViernes.UseVisualStyleBackColor = true;
            // 
            // chJueves
            // 
            this.chJueves.AutoSize = true;
            this.chJueves.Location = new System.Drawing.Point(211, 20);
            this.chJueves.Name = "chJueves";
            this.chJueves.Size = new System.Drawing.Size(40, 20);
            this.chJueves.TabIndex = 4;
            this.chJueves.Text = "Ju";
            this.chJueves.UseVisualStyleBackColor = true;
            // 
            // chMiercoles
            // 
            this.chMiercoles.AutoSize = true;
            this.chMiercoles.Location = new System.Drawing.Point(167, 20);
            this.chMiercoles.Name = "chMiercoles";
            this.chMiercoles.Size = new System.Drawing.Size(40, 20);
            this.chMiercoles.TabIndex = 3;
            this.chMiercoles.Text = "Mi";
            this.chMiercoles.UseVisualStyleBackColor = true;
            // 
            // chMartes
            // 
            this.chMartes.AutoSize = true;
            this.chMartes.Location = new System.Drawing.Point(119, 20);
            this.chMartes.Name = "chMartes";
            this.chMartes.Size = new System.Drawing.Size(45, 20);
            this.chMartes.TabIndex = 2;
            this.chMartes.Text = "Ma";
            this.chMartes.UseVisualStyleBackColor = true;
            // 
            // chLunes
            // 
            this.chLunes.AutoSize = true;
            this.chLunes.Location = new System.Drawing.Point(76, 20);
            this.chLunes.Name = "chLunes";
            this.chLunes.Size = new System.Drawing.Size(40, 20);
            this.chLunes.TabIndex = 1;
            this.chLunes.Text = "Lu";
            this.chLunes.UseVisualStyleBackColor = true;
            // 
            // pbActualizando
            // 
            this.pbActualizando.ForeColor = System.Drawing.Color.Lime;
            this.pbActualizando.Location = new System.Drawing.Point(19, 19);
            this.pbActualizando.Name = "pbActualizando";
            this.pbActualizando.Size = new System.Drawing.Size(332, 23);
            this.pbActualizando.Step = 1;
            this.pbActualizando.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
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
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(388, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 88);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Horario";
            // 
            // tbPacientes
            // 
            this.tbPacientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPacientes.Location = new System.Drawing.Point(313, 42);
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
            this.label11.Location = new System.Drawing.Point(310, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 16);
            this.label11.TabIndex = 69;
            this.label11.Text = "Pacientes x Cita";
            // 
            // tbCitarCada
            // 
            this.tbCitarCada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCitarCada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCitarCada.Location = new System.Drawing.Point(199, 42);
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
            this.label9.Location = new System.Drawing.Point(252, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 16);
            this.label9.TabIndex = 67;
            this.label9.Text = "min.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 66;
            this.label6.Text = "Citar cada";
            // 
            // tbCantidadTurnos
            // 
            this.tbCantidadTurnos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCantidadTurnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCantidadTurnos.Location = new System.Drawing.Point(261, 66);
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
            this.label10.Location = new System.Drawing.Point(258, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 16);
            this.label10.TabIndex = 64;
            this.label10.Text = "Cantidad de turnos";
            this.label10.Visible = false;
            // 
            // tbHoraHasta
            // 
            this.tbHoraHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbHoraHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHoraHasta.Location = new System.Drawing.Point(85, 42);
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
            this.tbHoraDesde.Location = new System.Drawing.Point(25, 42);
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
            this.label8.Location = new System.Drawing.Point(82, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 16);
            this.label8.TabIndex = 61;
            this.label8.Text = "Hasta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 60;
            this.label7.Text = "Desde";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpFechaHasta);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dtpFechaDesde);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(837, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 86);
            this.groupBox3.TabIndex = 64;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Período";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(163, 47);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(98, 22);
            this.dtpFechaHasta.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 51;
            this.label5.Text = "Hasta";
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbObservaciones.Location = new System.Drawing.Point(397, 134);
            this.tbObservaciones.Multiline = true;
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObservaciones.Size = new System.Drawing.Size(421, 54);
            this.tbObservaciones.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Profesional";
            // 
            // cboProfesional
            // 
            this.cboProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfesional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProfesional.FormattingEnabled = true;
            this.cboProfesional.Location = new System.Drawing.Point(15, 25);
            this.cboProfesional.Name = "cboProfesional";
            this.cboProfesional.Size = new System.Drawing.Size(388, 24);
            this.cboProfesional.TabIndex = 0;
            this.cboProfesional.SelectedIndexChanged += new System.EventHandler(this.cboProfesional_SelectedIndexChanged);
            // 
            // cboEspecialidad
            // 
            this.cboEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEspecialidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEspecialidad.FormattingEnabled = true;
            this.cboEspecialidad.Location = new System.Drawing.Point(6, 82);
            this.cboEspecialidad.Name = "cboEspecialidad";
            this.cboEspecialidad.Size = new System.Drawing.Size(352, 24);
            this.cboEspecialidad.TabIndex = 66;
            this.cboEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cboEspecialidad_SelectedIndexChanged);
            this.cboEspecialidad.SelectionChangeCommitted += new System.EventHandler(this.cboEspecialidad_SelectionChangeCommitted);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Brown;
            this.label12.Location = new System.Drawing.Point(17, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 16);
            this.label12.TabIndex = 8;
            this.label12.Text = "Actualizando Turnos...";
            // 
            // gbActualizando
            // 
            this.gbActualizando.BackColor = System.Drawing.Color.Transparent;
            this.gbActualizando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gbActualizando.Controls.Add(this.label12);
            this.gbActualizando.Controls.Add(this.pbActualizando);
            this.gbActualizando.Location = new System.Drawing.Point(363, 67);
            this.gbActualizando.Name = "gbActualizando";
            this.gbActualizando.Size = new System.Drawing.Size(365, 80);
            this.gbActualizando.TabIndex = 8;
            this.gbActualizando.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(396, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 16);
            this.label13.TabIndex = 67;
            this.label13.Text = "Observaciones";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(13, 394);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(123, 45);
            this.btnSalir.TabIndex = 276;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cboMotivo
            // 
            this.cboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMotivo.FormattingEnabled = true;
            this.cboMotivo.Location = new System.Drawing.Point(7, 32);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Size = new System.Drawing.Size(352, 24);
            this.cboMotivo.TabIndex = 69;
            this.cboMotivo.SelectedIndexChanged += new System.EventHandler(this.cboMotivo_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 16);
            this.label14.TabIndex = 68;
            this.label14.Text = "Tipo de Examen";
            // 
            // cboSubtipo
            // 
            this.cboSubtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubtipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSubtipo.FormattingEnabled = true;
            this.cboSubtipo.Location = new System.Drawing.Point(430, 25);
            this.cboSubtipo.Name = "cboSubtipo";
            this.cboSubtipo.Size = new System.Drawing.Size(687, 24);
            this.cboSubtipo.TabIndex = 71;
            this.cboSubtipo.SelectedIndexChanged += new System.EventHandler(this.cboSubtipo_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(427, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 16);
            this.label15.TabIndex = 72;
            this.label15.Text = "Subtipo";
            // 
            // frmHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1297, 517);
            this.Name = "frmHorario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Horarios";
            this.Load += new System.EventHandler(this.frmHorario_Load);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbActualizando.ResumeLayout(false);
            this.gbActualizando.PerformLayout();
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
        protected System.Windows.Forms.TextBox tbObservaciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboProfesional;
        private System.Windows.Forms.ProgressBar pbActualizando;
        private System.Windows.Forms.MaskedTextBox tbCitarCada;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox tbPacientes;
        protected System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboEspecialidad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel gbActualizando;
        private System.Windows.Forms.Label label13;
        protected System.Windows.Forms.Button btnSalir;
        protected System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboMotivo;
        private System.Windows.Forms.ComboBox cboSubtipo;
        private System.Windows.Forms.Label label15;
    }
}
