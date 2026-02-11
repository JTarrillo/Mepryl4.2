namespace CapaPresentacion
{
    partial class frmTurno
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTurno));
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.mcFecha = new System.Windows.Forms.MonthCalendar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butFechaSiguiente = new System.Windows.Forms.Button();
            this.butFechaAnterior = new System.Windows.Forms.Button();
            this.butFechaInicio = new System.Windows.Forms.Button();
            this.lsbHoraDesde = new System.Windows.Forms.ListBox();
            this.cbEstadoB = new System.Windows.Forms.ComboBox();
            this.cbProfesionalB = new System.Windows.Forms.ComboBox();
            this.cbEspecialidadB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butBuscarPorCampos = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chDomingoB = new System.Windows.Forms.CheckBox();
            this.chSabadoB = new System.Windows.Forms.CheckBox();
            this.chViernesB = new System.Windows.Forms.CheckBox();
            this.chJuevesB = new System.Windows.Forms.CheckBox();
            this.chMiercolesB = new System.Windows.Forms.CheckBox();
            this.chMartesB = new System.Windows.Forms.CheckBox();
            this.chLunesB = new System.Windows.Forms.CheckBox();
            this.chCombinarBusqueda = new System.Windows.Forms.CheckBox();
            this.lbFiltro = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.lbPacienteTexto = new System.Windows.Forms.Label();
            this.butLiberarTurno = new System.Windows.Forms.Button();
            this.gbPaciente = new System.Windows.Forms.GroupBox();
            this.cbFactClub = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPacienteNacimiento = new System.Windows.Forms.Label();
            this.botEditarPaciente = new System.Windows.Forms.Button();
            this.tbImporte = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblModificado = new System.Windows.Forms.Label();
            this.lblTipoExamen = new System.Windows.Forms.Label();
            this.dgvClubes = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPacienteTelefono = new System.Windows.Forms.Label();
            this.tbPacienteID = new System.Windows.Forms.TextBox();
            this.botonTipoDeExamen = new System.Windows.Forms.Button();
            this.lbPacienteDni = new System.Windows.Forms.Label();
            this.lbPacienteTelefonos = new System.Windows.Forms.Label();
            this.butModificarObservaciones = new System.Windows.Forms.Button();
            this.butMarcarFeriado = new System.Windows.Forms.Button();
            this.butQuitarFeriado = new System.Windows.Forms.Button();
            this.butHabilitar = new System.Windows.Forms.Button();
            this.butInhabilitar = new System.Windows.Forms.Button();
            this.butBorrarTurnos = new System.Windows.Forms.Button();
            this.botReservar = new System.Windows.Forms.Button();
            this.botLiberarReserva = new System.Windows.Forms.Button();
            this.gbReserva = new System.Windows.Forms.GroupBox();
            this.botCancReserva = new System.Windows.Forms.Button();
            this.botAceptReserv = new System.Windows.Forms.Button();
            this.tbReserva = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
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
            this.gbFiltro.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbPaciente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClubes)).BeginInit();
            this.gbReserva.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(1211, 551);
            // 
            // panAbajo
            // 
            this.panAbajo.Controls.Add(this.botLiberarReserva);
            this.panAbajo.Controls.Add(this.botReservar);
            this.panAbajo.Controls.Add(this.butHabilitar);
            this.panAbajo.Controls.Add(this.butInhabilitar);
            this.panAbajo.Controls.Add(this.butMarcarFeriado);
            this.panAbajo.Controls.Add(this.butQuitarFeriado);
            this.panAbajo.Location = new System.Drawing.Point(0, 591);
            this.panAbajo.Size = new System.Drawing.Size(1221, 24);
            this.panAbajo.Controls.SetChildIndex(this.tbEntidadNombre, 0);
            this.panAbajo.Controls.SetChildIndex(this.butQuitarFeriado, 0);
            this.panAbajo.Controls.SetChildIndex(this.butMarcarFeriado, 0);
            this.panAbajo.Controls.SetChildIndex(this.butInhabilitar, 0);
            this.panAbajo.Controls.SetChildIndex(this.butHabilitar, 0);
            this.panAbajo.Controls.SetChildIndex(this.botReservar, 0);
            this.panAbajo.Controls.SetChildIndex(this.botLiberarReserva, 0);
            // 
            // tbEntidadNombre
            // 
            this.tbEntidadNombre.Location = new System.Drawing.Point(332, 6);
            // 
            // panDerecha
            // 
            this.panDerecha.Controls.Add(this.butModificarObservaciones);
            this.panDerecha.Controls.Add(this.butBorrarTurnos);
            this.panDerecha.Controls.Add(this.butLiberarTurno);
            this.panDerecha.Location = new System.Drawing.Point(1221, 40);
            this.panDerecha.Size = new System.Drawing.Size(117, 575);
            this.panDerecha.Controls.SetChildIndex(this.butModificar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAceptar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butLiberarTurno, 0);
            this.panDerecha.Controls.SetChildIndex(this.butEliminar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butCancelar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAgregar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butSalir, 0);
            this.panDerecha.Controls.SetChildIndex(this.butImprimir, 0);
            this.panDerecha.Controls.SetChildIndex(this.butBorrarTurnos, 0);
            this.panDerecha.Controls.SetChildIndex(this.butModificarObservaciones, 0);
            // 
            // butCancelar
            // 
            this.butCancelar.Location = new System.Drawing.Point(6, 255);
            // 
            // butAceptar
            // 
            this.butAceptar.Location = new System.Drawing.Point(6, 221);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.OrangeRed;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1297, 0);
            this.pictureBox2.Size = new System.Drawing.Size(41, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(0, 551);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(1211, 253);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusqueda.Location = new System.Drawing.Point(238, 120);
            this.tbBusqueda.Size = new System.Drawing.Size(120, 20);
            this.tbBusqueda.TabIndex = 1;
            // 
            // labe2
            // 
            this.labe2.Location = new System.Drawing.Point(235, 101);
            this.labe2.Size = new System.Drawing.Size(93, 13);
            this.labe2.Text = "B�squeda Textual";
            // 
            // tabPage1
            // 
            this.tabPage1.Size = new System.Drawing.Size(1203, 226);
            // 
            // panBusqueda
            // 
            this.panBusqueda.Size = new System.Drawing.Size(1203, 226);
            // 
            // gbControles
            // 
            this.gbControles.Size = new System.Drawing.Size(1059, 226);
            // 
            // tbId
            // 
            this.tbId.Text = "00000000-0000-0000-0000-000000000000";
            // 
            // butModificar
            // 
            this.butModificar.Text = "&Asignar [F8]";
            // 
            // butBuscar
            // 
            this.butBuscar.Location = new System.Drawing.Point(363, 120);
            this.butBuscar.Size = new System.Drawing.Size(41, 21);
            this.butBuscar.TabIndex = 2;
            // 
            // panBotones
            // 
            this.panBotones.Location = new System.Drawing.Point(1059, 0);
            this.panBotones.Size = new System.Drawing.Size(144, 226);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbReserva);
            this.tabPage2.Controls.Add(this.gbFiltro);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cbEspecialidadB);
            this.tabPage2.Controls.Add(this.cbProfesionalB);
            this.tabPage2.Controls.Add(this.gbPaciente);
            this.tabPage2.Controls.Add(this.chCombinarBusqueda);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cbEstadoB);
            this.tabPage2.Controls.Add(this.butBuscarPorCampos);
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Size = new System.Drawing.Size(1203, 226);
            this.tabPage2.Text = "Asignaci�n de Turnos";
            this.tabPage2.Controls.SetChildIndex(this.butBuscarPorCampos, 0);
            this.tabPage2.Controls.SetChildIndex(this.cbEstadoB, 0);
            this.tabPage2.Controls.SetChildIndex(this.label6, 0);
            this.tabPage2.Controls.SetChildIndex(this.label5, 0);
            this.tabPage2.Controls.SetChildIndex(this.chCombinarBusqueda, 0);
            this.tabPage2.Controls.SetChildIndex(this.gbPaciente, 0);
            this.tabPage2.Controls.SetChildIndex(this.cbProfesionalB, 0);
            this.tabPage2.Controls.SetChildIndex(this.cbEspecialidadB, 0);
            this.tabPage2.Controls.SetChildIndex(this.label4, 0);
            this.tabPage2.Controls.SetChildIndex(this.butBuscar, 0);
            this.tabPage2.Controls.SetChildIndex(this.labe2, 0);
            this.tabPage2.Controls.SetChildIndex(this.tbBusqueda, 0);
            this.tabPage2.Controls.SetChildIndex(this.gbFiltro, 0);
            this.tabPage2.Controls.SetChildIndex(this.gbReserva, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lbFiltro);
            this.panel1.Size = new System.Drawing.Size(1211, 293);
            this.panel1.Controls.SetChildIndex(this.lbFiltro, 0);
            this.panel1.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel1.Controls.SetChildIndex(this.tabPrincipal, 0);
            // 
            // butImprimir
            // 
            this.butImprimir.Location = new System.Drawing.Point(6, 450);
            this.butImprimir.Visible = false;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.OrangeRed;
            this.lbTitulo.Size = new System.Drawing.Size(1297, 40);
            this.lbTitulo.Text = "Administraci�n de Turnos";
            // 
            // gbFiltro
            // 
            this.gbFiltro.Controls.Add(this.mcFecha);
            this.gbFiltro.Controls.Add(this.panel2);
            this.gbFiltro.Controls.Add(this.lsbHoraDesde);
            this.gbFiltro.Location = new System.Drawing.Point(5, 8);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(227, 174);
            this.gbFiltro.TabIndex = 0;
            this.gbFiltro.TabStop = false;
            // 
            // mcFecha
            // 
            this.mcFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mcFecha.Location = new System.Drawing.Point(4, 12);
            this.mcFecha.Name = "mcFecha";
            this.mcFecha.TabIndex = 3;
            this.mcFecha.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcFecha_DateChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butFechaSiguiente);
            this.panel2.Controls.Add(this.butFechaAnterior);
            this.panel2.Controls.Add(this.butFechaInicio);
            this.panel2.Location = new System.Drawing.Point(6, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 21);
            this.panel2.TabIndex = 71;
            // 
            // butFechaSiguiente
            // 
            this.butFechaSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butFechaSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butFechaSiguiente.Location = new System.Drawing.Point(111, 0);
            this.butFechaSiguiente.Name = "butFechaSiguiente";
            this.butFechaSiguiente.Size = new System.Drawing.Size(53, 21);
            this.butFechaSiguiente.TabIndex = 7;
            this.butFechaSiguiente.Text = "Sig.>>";
            this.butFechaSiguiente.UseVisualStyleBackColor = true;
            this.butFechaSiguiente.Click += new System.EventHandler(this.butFechaSiguiente_Click);
            // 
            // butFechaAnterior
            // 
            this.butFechaAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butFechaAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butFechaAnterior.Location = new System.Drawing.Point(55, 0);
            this.butFechaAnterior.Name = "butFechaAnterior";
            this.butFechaAnterior.Size = new System.Drawing.Size(53, 21);
            this.butFechaAnterior.TabIndex = 6;
            this.butFechaAnterior.Text = "<<Ant.";
            this.butFechaAnterior.UseVisualStyleBackColor = true;
            this.butFechaAnterior.Click += new System.EventHandler(this.butFechaAnterior_Click);
            // 
            // butFechaInicio
            // 
            this.butFechaInicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butFechaInicio.Location = new System.Drawing.Point(0, 0);
            this.butFechaInicio.Name = "butFechaInicio";
            this.butFechaInicio.Size = new System.Drawing.Size(52, 21);
            this.butFechaInicio.TabIndex = 5;
            this.butFechaInicio.Text = "|| Inicio";
            this.butFechaInicio.UseVisualStyleBackColor = true;
            this.butFechaInicio.Click += new System.EventHandler(this.butFechaInicio_Click);
            // 
            // lsbHoraDesde
            // 
            this.lsbHoraDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsbHoraDesde.FormattingEnabled = true;
            this.lsbHoraDesde.Items.AddRange(new object[] {
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00"});
            this.lsbHoraDesde.Location = new System.Drawing.Point(183, 25);
            this.lsbHoraDesde.Name = "lsbHoraDesde";
            this.lsbHoraDesde.Size = new System.Drawing.Size(39, 132);
            this.lsbHoraDesde.TabIndex = 4;
            this.lsbHoraDesde.SelectedIndexChanged += new System.EventHandler(this.lsbHoraDesde_SelectedIndexChanged);
            // 
            // cbEstadoB
            // 
            this.cbEstadoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbEstadoB.FormattingEnabled = true;
            this.cbEstadoB.Location = new System.Drawing.Point(407, 22);
            this.cbEstadoB.Name = "cbEstadoB";
            this.cbEstadoB.Size = new System.Drawing.Size(86, 21);
            this.cbEstadoB.TabIndex = 2;
            this.cbEstadoB.SelectedIndexChanged += new System.EventHandler(this.cbEstadoB_SelectedIndexChanged);
            // 
            // cbProfesionalB
            // 
            this.cbProfesionalB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfesionalB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbProfesionalB.FormattingEnabled = true;
            this.cbProfesionalB.Location = new System.Drawing.Point(238, 64);
            this.cbProfesionalB.Name = "cbProfesionalB";
            this.cbProfesionalB.Size = new System.Drawing.Size(163, 21);
            this.cbProfesionalB.TabIndex = 1;
            this.cbProfesionalB.SelectedIndexChanged += new System.EventHandler(this.cbProfesionalB_SelectedIndexChanged);
            // 
            // cbEspecialidadB
            // 
            this.cbEspecialidadB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEspecialidadB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbEspecialidadB.FormattingEnabled = true;
            this.cbEspecialidadB.Location = new System.Drawing.Point(238, 22);
            this.cbEspecialidadB.Name = "cbEspecialidadB";
            this.cbEspecialidadB.Size = new System.Drawing.Size(164, 21);
            this.cbEspecialidadB.TabIndex = 0;
            this.cbEspecialidadB.SelectedIndexChanged += new System.EventHandler(this.cbEspecialidadB_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(404, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 67;
            this.label6.Text = "Estado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Profesional";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Tipo de Examen";
            // 
            // butBuscarPorCampos
            // 
            this.butBuscarPorCampos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butBuscarPorCampos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarPorCampos.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarPorCampos.Image")));
            this.butBuscarPorCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscarPorCampos.Location = new System.Drawing.Point(407, 46);
            this.butBuscarPorCampos.Name = "butBuscarPorCampos";
            this.butBuscarPorCampos.Size = new System.Drawing.Size(86, 39);
            this.butBuscarPorCampos.TabIndex = 8;
            this.butBuscarPorCampos.Text = "Mostrar";
            this.butBuscarPorCampos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBuscarPorCampos.UseVisualStyleBackColor = false;
            this.butBuscarPorCampos.Click += new System.EventHandler(this.butBuscarPorCampos_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chDomingoB);
            this.groupBox1.Controls.Add(this.chSabadoB);
            this.groupBox1.Controls.Add(this.chViernesB);
            this.groupBox1.Controls.Add(this.chJuevesB);
            this.groupBox1.Controls.Add(this.chMiercolesB);
            this.groupBox1.Controls.Add(this.chMartesB);
            this.groupBox1.Controls.Add(this.chLunesB);
            this.groupBox1.Location = new System.Drawing.Point(273, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(95, 35);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // chDomingoB
            // 
            this.chDomingoB.AutoSize = true;
            this.chDomingoB.Checked = true;
            this.chDomingoB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chDomingoB.Location = new System.Drawing.Point(8, 14);
            this.chDomingoB.Name = "chDomingoB";
            this.chDomingoB.Size = new System.Drawing.Size(40, 17);
            this.chDomingoB.TabIndex = 0;
            this.chDomingoB.Text = "Do";
            this.chDomingoB.UseVisualStyleBackColor = true;
            // 
            // chSabadoB
            // 
            this.chSabadoB.AutoSize = true;
            this.chSabadoB.Checked = true;
            this.chSabadoB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chSabadoB.Location = new System.Drawing.Point(263, 14);
            this.chSabadoB.Name = "chSabadoB";
            this.chSabadoB.Size = new System.Drawing.Size(39, 17);
            this.chSabadoB.TabIndex = 6;
            this.chSabadoB.Text = "Sa";
            this.chSabadoB.UseVisualStyleBackColor = true;
            // 
            // chViernesB
            // 
            this.chViernesB.AutoSize = true;
            this.chViernesB.Checked = true;
            this.chViernesB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chViernesB.Location = new System.Drawing.Point(225, 14);
            this.chViernesB.Name = "chViernesB";
            this.chViernesB.Size = new System.Drawing.Size(35, 17);
            this.chViernesB.TabIndex = 5;
            this.chViernesB.Text = "Vi";
            this.chViernesB.UseVisualStyleBackColor = true;
            // 
            // chJuevesB
            // 
            this.chJuevesB.AutoSize = true;
            this.chJuevesB.Checked = true;
            this.chJuevesB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chJuevesB.Location = new System.Drawing.Point(182, 14);
            this.chJuevesB.Name = "chJuevesB";
            this.chJuevesB.Size = new System.Drawing.Size(37, 17);
            this.chJuevesB.TabIndex = 4;
            this.chJuevesB.Text = "Ju";
            this.chJuevesB.UseVisualStyleBackColor = true;
            // 
            // chMiercolesB
            // 
            this.chMiercolesB.AutoSize = true;
            this.chMiercolesB.Checked = true;
            this.chMiercolesB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chMiercolesB.Location = new System.Drawing.Point(139, 14);
            this.chMiercolesB.Name = "chMiercolesB";
            this.chMiercolesB.Size = new System.Drawing.Size(37, 17);
            this.chMiercolesB.TabIndex = 3;
            this.chMiercolesB.Text = "Mi";
            this.chMiercolesB.UseVisualStyleBackColor = true;
            // 
            // chMartesB
            // 
            this.chMartesB.AutoSize = true;
            this.chMartesB.Checked = true;
            this.chMartesB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chMartesB.Location = new System.Drawing.Point(92, 14);
            this.chMartesB.Name = "chMartesB";
            this.chMartesB.Size = new System.Drawing.Size(41, 17);
            this.chMartesB.TabIndex = 2;
            this.chMartesB.Text = "Ma";
            this.chMartesB.UseVisualStyleBackColor = true;
            // 
            // chLunesB
            // 
            this.chLunesB.AutoSize = true;
            this.chLunesB.Checked = true;
            this.chLunesB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chLunesB.Location = new System.Drawing.Point(52, 14);
            this.chLunesB.Name = "chLunesB";
            this.chLunesB.Size = new System.Drawing.Size(38, 17);
            this.chLunesB.TabIndex = 1;
            this.chLunesB.Text = "Lu";
            this.chLunesB.UseVisualStyleBackColor = true;
            // 
            // chCombinarBusqueda
            // 
            this.chCombinarBusqueda.AutoSize = true;
            this.chCombinarBusqueda.Location = new System.Drawing.Point(238, 146);
            this.chCombinarBusqueda.Name = "chCombinarBusqueda";
            this.chCombinarBusqueda.Size = new System.Drawing.Size(120, 17);
            this.chCombinarBusqueda.TabIndex = 3;
            this.chCombinarBusqueda.Text = "Combinar b�squeda";
            this.chCombinarBusqueda.UseVisualStyleBackColor = true;
            this.chCombinarBusqueda.CheckedChanged += new System.EventHandler(this.chCombinarBusqueda_CheckedChanged);
            // 
            // lbFiltro
            // 
            this.lbFiltro.BackColor = System.Drawing.Color.OrangeRed;
            this.lbFiltro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFiltro.ForeColor = System.Drawing.Color.White;
            this.lbFiltro.Location = new System.Drawing.Point(0, 256);
            this.lbFiltro.Name = "lbFiltro";
            this.lbFiltro.Size = new System.Drawing.Size(1211, 37);
            this.lbFiltro.TabIndex = 5;
            this.lbFiltro.Text = "Todos";
            this.lbFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 73;
            this.label10.Text = "Observaciones";
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.BackColor = System.Drawing.Color.White;
            this.tbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbObservaciones.Location = new System.Drawing.Point(203, 118);
            this.tbObservaciones.Multiline = true;
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObservaciones.Size = new System.Drawing.Size(298, 37);
            this.tbObservaciones.TabIndex = 1;
            // 
            // lbPacienteTexto
            // 
            this.lbPacienteTexto.AutoSize = true;
            this.lbPacienteTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPacienteTexto.ForeColor = System.Drawing.Color.Black;
            this.lbPacienteTexto.Location = new System.Drawing.Point(6, 31);
            this.lbPacienteTexto.Name = "lbPacienteTexto";
            this.lbPacienteTexto.Size = new System.Drawing.Size(15, 15);
            this.lbPacienteTexto.TabIndex = 74;
            this.lbPacienteTexto.Text = "_";
            // 
            // butLiberarTurno
            // 
            this.butLiberarTurno.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.butLiberarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLiberarTurno.Image = ((System.Drawing.Image)(resources.GetObject("butLiberarTurno.Image")));
            this.butLiberarTurno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLiberarTurno.Location = new System.Drawing.Point(6, 124);
            this.butLiberarTurno.Name = "butLiberarTurno";
            this.butLiberarTurno.Size = new System.Drawing.Size(106, 31);
            this.butLiberarTurno.TabIndex = 75;
            this.butLiberarTurno.Text = "Liberar [F3]";
            this.butLiberarTurno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLiberarTurno.UseVisualStyleBackColor = true;
            this.butLiberarTurno.Click += new System.EventHandler(this.butLiberarTurno_Click);
            // 
            // gbPaciente
            // 
            this.gbPaciente.Controls.Add(this.cbFactClub);
            this.gbPaciente.Controls.Add(this.label9);
            this.gbPaciente.Controls.Add(this.lblPacienteNacimiento);
            this.gbPaciente.Controls.Add(this.botEditarPaciente);
            this.gbPaciente.Controls.Add(this.tbImporte);
            this.gbPaciente.Controls.Add(this.label8);
            this.gbPaciente.Controls.Add(this.label7);
            this.gbPaciente.Controls.Add(this.lblModificado);
            this.gbPaciente.Controls.Add(this.lblTipoExamen);
            this.gbPaciente.Controls.Add(this.dgvClubes);
            this.gbPaciente.Controls.Add(this.label3);
            this.gbPaciente.Controls.Add(this.label2);
            this.gbPaciente.Controls.Add(this.lblPacienteTelefono);
            this.gbPaciente.Controls.Add(this.lbPacienteTexto);
            this.gbPaciente.Controls.Add(this.tbObservaciones);
            this.gbPaciente.Controls.Add(this.label10);
            this.gbPaciente.Controls.Add(this.tbPacienteID);
            this.gbPaciente.Controls.Add(this.botonTipoDeExamen);
            this.gbPaciente.Location = new System.Drawing.Point(532, 2);
            this.gbPaciente.Name = "gbPaciente";
            this.gbPaciente.Size = new System.Drawing.Size(668, 161);
            this.gbPaciente.TabIndex = 0;
            this.gbPaciente.TabStop = false;
            this.gbPaciente.Visible = false;
            // 
            // cbFactClub
            // 
            this.cbFactClub.AutoSize = true;
            this.cbFactClub.Location = new System.Drawing.Point(553, 139);
            this.cbFactClub.Name = "cbFactClub";
            this.cbFactClub.Size = new System.Drawing.Size(109, 17);
            this.cbFactClub.TabIndex = 90;
            this.cbFactClub.Text = "Se factura al club";
            this.cbFactClub.UseVisualStyleBackColor = true;
            this.cbFactClub.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbFactClub_MouseClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 15);
            this.label9.TabIndex = 89;
            this.label9.Text = "Nacimiento";
            // 
            // lblPacienteNacimiento
            // 
            this.lblPacienteNacimiento.AutoSize = true;
            this.lblPacienteNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacienteNacimiento.ForeColor = System.Drawing.Color.Black;
            this.lblPacienteNacimiento.Location = new System.Drawing.Point(6, 91);
            this.lblPacienteNacimiento.Name = "lblPacienteNacimiento";
            this.lblPacienteNacimiento.Size = new System.Drawing.Size(15, 15);
            this.lblPacienteNacimiento.TabIndex = 88;
            this.lblPacienteNacimiento.Text = "_";
            // 
            // botEditarPaciente
            // 
            this.botEditarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botEditarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEditarPaciente.Image = ((System.Drawing.Image)(resources.GetObject("botEditarPaciente.Image")));
            this.botEditarPaciente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEditarPaciente.Location = new System.Drawing.Point(6, 118);
            this.botEditarPaciente.Name = "botEditarPaciente";
            this.botEditarPaciente.Size = new System.Drawing.Size(93, 38);
            this.botEditarPaciente.TabIndex = 87;
            this.botEditarPaciente.Text = "Editar    Paciente";
            this.botEditarPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEditarPaciente.UseVisualStyleBackColor = true;
            this.botEditarPaciente.Click += new System.EventHandler(this.botEditarPaciente_Click);
            // 
            // tbImporte
            // 
            this.tbImporte.AutoSize = true;
            this.tbImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbImporte.ForeColor = System.Drawing.Color.Black;
            this.tbImporte.Location = new System.Drawing.Point(532, 101);
            this.tbImporte.Name = "tbImporte";
            this.tbImporte.Size = new System.Drawing.Size(27, 29);
            this.tbImporte.TabIndex = 86;
            this.tbImporte.Text = "_";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(534, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 85;
            this.label8.Text = "Importe";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(534, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 84;
            this.label7.Text = "Examen";
            // 
            // lblModificado
            // 
            this.lblModificado.AutoSize = true;
            this.lblModificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModificado.ForeColor = System.Drawing.Color.Red;
            this.lblModificado.Location = new System.Drawing.Point(534, 49);
            this.lblModificado.Name = "lblModificado";
            this.lblModificado.Size = new System.Drawing.Size(0, 15);
            this.lblModificado.TabIndex = 82;
            // 
            // lblTipoExamen
            // 
            this.lblTipoExamen.AutoSize = true;
            this.lblTipoExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoExamen.ForeColor = System.Drawing.Color.Black;
            this.lblTipoExamen.Location = new System.Drawing.Point(534, 34);
            this.lblTipoExamen.Name = "lblTipoExamen";
            this.lblTipoExamen.Size = new System.Drawing.Size(0, 15);
            this.lblTipoExamen.TabIndex = 81;
            // 
            // dgvClubes
            // 
            this.dgvClubes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClubes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvClubes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClubes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClubes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClubes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClubes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClubes.Enabled = false;
            this.dgvClubes.GridColor = System.Drawing.SystemColors.Control;
            this.dgvClubes.Location = new System.Drawing.Point(203, 16);
            this.dgvClubes.Name = "dgvClubes";
            this.dgvClubes.ReadOnly = true;
            this.dgvClubes.RowHeadersVisible = false;
            this.dgvClubes.RowHeadersWidth = 30;
            this.dgvClubes.RowTemplate.Height = 18;
            this.dgvClubes.Size = new System.Drawing.Size(298, 80);
            this.dgvClubes.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 79;
            this.label3.Text = "Tel�fonos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 78;
            this.label2.Text = "Paciente";
            // 
            // lblPacienteTelefono
            // 
            this.lblPacienteTelefono.AutoSize = true;
            this.lblPacienteTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacienteTelefono.ForeColor = System.Drawing.Color.Black;
            this.lblPacienteTelefono.Location = new System.Drawing.Point(6, 61);
            this.lblPacienteTelefono.Name = "lblPacienteTelefono";
            this.lblPacienteTelefono.Size = new System.Drawing.Size(15, 15);
            this.lblPacienteTelefono.TabIndex = 77;
            this.lblPacienteTelefono.Text = "_";
            // 
            // tbPacienteID
            // 
            this.tbPacienteID.Location = new System.Drawing.Point(415, 97);
            this.tbPacienteID.Name = "tbPacienteID";
            this.tbPacienteID.Size = new System.Drawing.Size(18, 20);
            this.tbPacienteID.TabIndex = 75;
            this.tbPacienteID.Visible = false;
            // 
            // botonTipoDeExamen
            // 
            this.botonTipoDeExamen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonTipoDeExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonTipoDeExamen.ForeColor = System.Drawing.Color.Red;
            this.botonTipoDeExamen.Image = ((System.Drawing.Image)(resources.GetObject("botonTipoDeExamen.Image")));
            this.botonTipoDeExamen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonTipoDeExamen.Location = new System.Drawing.Point(105, 118);
            this.botonTipoDeExamen.Name = "botonTipoDeExamen";
            this.botonTipoDeExamen.Size = new System.Drawing.Size(92, 38);
            this.botonTipoDeExamen.TabIndex = 0;
            this.botonTipoDeExamen.Text = "Tipo de   Examen";
            this.botonTipoDeExamen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botonTipoDeExamen.UseVisualStyleBackColor = true;
            this.botonTipoDeExamen.Click += new System.EventHandler(this.botonTipoDeExamen_Click);
            // 
            // lbPacienteDni
            // 
            this.lbPacienteDni.AutoSize = true;
            this.lbPacienteDni.Location = new System.Drawing.Point(256, 35);
            this.lbPacienteDni.Name = "lbPacienteDni";
            this.lbPacienteDni.Size = new System.Drawing.Size(0, 13);
            this.lbPacienteDni.TabIndex = 11;
            this.lbPacienteDni.Visible = false;
            // 
            // lbPacienteTelefonos
            // 
            this.lbPacienteTelefonos.AutoSize = true;
            this.lbPacienteTelefonos.Location = new System.Drawing.Point(289, 35);
            this.lbPacienteTelefonos.Name = "lbPacienteTelefonos";
            this.lbPacienteTelefonos.Size = new System.Drawing.Size(0, 13);
            this.lbPacienteTelefonos.TabIndex = 12;
            this.lbPacienteTelefonos.Visible = false;
            // 
            // butModificarObservaciones
            // 
            this.butModificarObservaciones.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.butModificarObservaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butModificarObservaciones.Image = ((System.Drawing.Image)(resources.GetObject("butModificarObservaciones.Image")));
            this.butModificarObservaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butModificarObservaciones.Location = new System.Drawing.Point(6, 90);
            this.butModificarObservaciones.Name = "butModificarObservaciones";
            this.butModificarObservaciones.Size = new System.Drawing.Size(106, 31);
            this.butModificarObservaciones.TabIndex = 76;
            this.butModificarObservaciones.Text = "Modificar [F4]";
            this.butModificarObservaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butModificarObservaciones.UseVisualStyleBackColor = true;
            this.butModificarObservaciones.Click += new System.EventHandler(this.butModificarObservaciones_Click);
            // 
            // butMarcarFeriado
            // 
            this.butMarcarFeriado.Dock = System.Windows.Forms.DockStyle.Right;
            this.butMarcarFeriado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butMarcarFeriado.Location = new System.Drawing.Point(978, 0);
            this.butMarcarFeriado.Name = "butMarcarFeriado";
            this.butMarcarFeriado.Size = new System.Drawing.Size(132, 24);
            this.butMarcarFeriado.TabIndex = 80;
            this.butMarcarFeriado.Text = "Marcar como Feriado";
            this.butMarcarFeriado.UseVisualStyleBackColor = true;
            this.butMarcarFeriado.Click += new System.EventHandler(this.butMarcarFeriado_Click);
            // 
            // butQuitarFeriado
            // 
            this.butQuitarFeriado.Dock = System.Windows.Forms.DockStyle.Right;
            this.butQuitarFeriado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butQuitarFeriado.Location = new System.Drawing.Point(1110, 0);
            this.butQuitarFeriado.Name = "butQuitarFeriado";
            this.butQuitarFeriado.Size = new System.Drawing.Size(111, 24);
            this.butQuitarFeriado.TabIndex = 79;
            this.butQuitarFeriado.Text = "Quitar Feriado";
            this.butQuitarFeriado.UseVisualStyleBackColor = true;
            this.butQuitarFeriado.Click += new System.EventHandler(this.butQuitarFeriado_Click);
            // 
            // butHabilitar
            // 
            this.butHabilitar.Dock = System.Windows.Forms.DockStyle.Left;
            this.butHabilitar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butHabilitar.Location = new System.Drawing.Point(111, 0);
            this.butHabilitar.Name = "butHabilitar";
            this.butHabilitar.Size = new System.Drawing.Size(132, 24);
            this.butHabilitar.TabIndex = 82;
            this.butHabilitar.Text = "Habilitar";
            this.butHabilitar.UseVisualStyleBackColor = true;
            this.butHabilitar.Click += new System.EventHandler(this.butHabilitar_Click);
            // 
            // butInhabilitar
            // 
            this.butInhabilitar.Dock = System.Windows.Forms.DockStyle.Left;
            this.butInhabilitar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butInhabilitar.Location = new System.Drawing.Point(0, 0);
            this.butInhabilitar.Name = "butInhabilitar";
            this.butInhabilitar.Size = new System.Drawing.Size(111, 24);
            this.butInhabilitar.TabIndex = 81;
            this.butInhabilitar.Text = "Inhabilitar";
            this.butInhabilitar.UseVisualStyleBackColor = true;
            this.butInhabilitar.Click += new System.EventHandler(this.butInhabilitar_Click);
            // 
            // butBorrarTurnos
            // 
            this.butBorrarTurnos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butBorrarTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarTurnos.Image = ((System.Drawing.Image)(resources.GetObject("butBorrarTurnos.Image")));
            this.butBorrarTurnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarTurnos.Location = new System.Drawing.Point(6, 314);
            this.butBorrarTurnos.Name = "butBorrarTurnos";
            this.butBorrarTurnos.Size = new System.Drawing.Size(106, 32);
            this.butBorrarTurnos.TabIndex = 9;
            this.butBorrarTurnos.Text = "   Borrar Turnos";
            this.butBorrarTurnos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBorrarTurnos.UseVisualStyleBackColor = false;
            this.butBorrarTurnos.Visible = false;
            this.butBorrarTurnos.Click += new System.EventHandler(this.butBorrarTurnos_Click);
            // 
            // botReservar
            // 
            this.botReservar.Dock = System.Windows.Forms.DockStyle.Left;
            this.botReservar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botReservar.Location = new System.Drawing.Point(243, 0);
            this.botReservar.Name = "botReservar";
            this.botReservar.Size = new System.Drawing.Size(132, 24);
            this.botReservar.TabIndex = 83;
            this.botReservar.Text = "Reservar";
            this.botReservar.UseVisualStyleBackColor = true;
            this.botReservar.Click += new System.EventHandler(this.botReservar_Click);
            // 
            // botLiberarReserva
            // 
            this.botLiberarReserva.Dock = System.Windows.Forms.DockStyle.Left;
            this.botLiberarReserva.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botLiberarReserva.Location = new System.Drawing.Point(375, 0);
            this.botLiberarReserva.Name = "botLiberarReserva";
            this.botLiberarReserva.Size = new System.Drawing.Size(132, 24);
            this.botLiberarReserva.TabIndex = 84;
            this.botLiberarReserva.Text = "Liberar Reserva";
            this.botLiberarReserva.UseVisualStyleBackColor = true;
            this.botLiberarReserva.Click += new System.EventHandler(this.botLiberarReserva_Click);
            // 
            // gbReserva
            // 
            this.gbReserva.Controls.Add(this.botCancReserva);
            this.gbReserva.Controls.Add(this.botAceptReserv);
            this.gbReserva.Controls.Add(this.tbReserva);
            this.gbReserva.Controls.Add(this.label11);
            this.gbReserva.Location = new System.Drawing.Point(877, 0);
            this.gbReserva.Name = "gbReserva";
            this.gbReserva.Size = new System.Drawing.Size(323, 164);
            this.gbReserva.TabIndex = 91;
            this.gbReserva.TabStop = false;
            this.gbReserva.Visible = false;
            // 
            // botCancReserva
            // 
            this.botCancReserva.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botCancReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botCancReserva.Image = ((System.Drawing.Image)(resources.GetObject("botCancReserva.Image")));
            this.botCancReserva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancReserva.Location = new System.Drawing.Point(168, 93);
            this.botCancReserva.Name = "botCancReserva";
            this.botCancReserva.Size = new System.Drawing.Size(100, 46);
            this.botCancReserva.TabIndex = 82;
            this.botCancReserva.Text = "Cancelar";
            this.botCancReserva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancReserva.UseVisualStyleBackColor = true;
            this.botCancReserva.Click += new System.EventHandler(this.botCancReserva_Click);
            // 
            // botAceptReserv
            // 
            this.botAceptReserv.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botAceptReserv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botAceptReserv.Image = ((System.Drawing.Image)(resources.GetObject("botAceptReserv.Image")));
            this.botAceptReserv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAceptReserv.Location = new System.Drawing.Point(56, 93);
            this.botAceptReserv.Name = "botAceptReserv";
            this.botAceptReserv.Size = new System.Drawing.Size(100, 46);
            this.botAceptReserv.TabIndex = 81;
            this.botAceptReserv.Text = "Aceptar";
            this.botAceptReserv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAceptReserv.UseVisualStyleBackColor = true;
            this.botAceptReserv.Click += new System.EventHandler(this.botAceptReserv_Click);
            // 
            // tbReserva
            // 
            this.tbReserva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbReserva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbReserva.Location = new System.Drawing.Point(19, 55);
            this.tbReserva.Name = "tbReserva";
            this.tbReserva.Size = new System.Drawing.Size(288, 26);
            this.tbReserva.TabIndex = 80;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(234, 20);
            this.label11.TabIndex = 79;
            this.label11.Text = "Indique para qui�n es la reserva";
            // 
            // frmTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1338, 615);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turnos";
            this.Load += new System.EventHandler(this.frmTurno_Load);
            this.panCentro.ResumeLayout(false);
            this.panAbajo.ResumeLayout(false);
            this.panAbajo.PerformLayout();
            this.panDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panBusqueda.ResumeLayout(false);
            this.gbControles.ResumeLayout(false);
            this.gbControles.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbFiltro.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPaciente.ResumeLayout(false);
            this.gbPaciente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClubes)).EndInit();
            this.gbReserva.ResumeLayout(false);
            this.gbReserva.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltro;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chDomingoB;
        private System.Windows.Forms.CheckBox chSabadoB;
        private System.Windows.Forms.CheckBox chViernesB;
        private System.Windows.Forms.CheckBox chJuevesB;
        private System.Windows.Forms.CheckBox chMiercolesB;
        private System.Windows.Forms.CheckBox chMartesB;
        private System.Windows.Forms.CheckBox chLunesB;
        private System.Windows.Forms.CheckBox chCombinarBusqueda;
        private System.Windows.Forms.ComboBox cbEstadoB;
        private System.Windows.Forms.ComboBox cbProfesionalB;
        protected System.Windows.Forms.Button butBuscarPorCampos;
        public System.Windows.Forms.ComboBox cbEspecialidadB;
        private System.Windows.Forms.ListBox lsbHoraDesde;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butFechaSiguiente;
        private System.Windows.Forms.Button butFechaAnterior;
        private System.Windows.Forms.Button butFechaInicio;
        private System.Windows.Forms.Label lbFiltro;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox tbObservaciones;
        private System.Windows.Forms.Button butLiberarTurno;
        private System.Windows.Forms.Label lbPacienteTexto;
        private System.Windows.Forms.GroupBox gbPaciente;
        private System.Windows.Forms.TextBox tbPacienteID;
        private System.Windows.Forms.Label lbPacienteTelefonos;
        private System.Windows.Forms.Label lbPacienteDni;
        private System.Windows.Forms.Button butModificarObservaciones;
        private System.Windows.Forms.Button butMarcarFeriado;
        private System.Windows.Forms.Button butQuitarFeriado;
        private System.Windows.Forms.Button butHabilitar;
        private System.Windows.Forms.Button butInhabilitar;
        protected System.Windows.Forms.Button butBorrarTurnos;
        private System.Windows.Forms.Button botonTipoDeExamen;
        private System.Windows.Forms.Label lblPacienteTelefono;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvClubes;
        private System.Windows.Forms.Label lblModificado;
        private System.Windows.Forms.Label lblTipoExamen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label tbImporte;
        private System.Windows.Forms.Button botEditarPaciente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPacienteNacimiento;
        private System.Windows.Forms.CheckBox cbFactClub;
        private System.Windows.Forms.Button botReservar;
        private System.Windows.Forms.Button botLiberarReserva;
        private System.Windows.Forms.GroupBox gbReserva;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button botCancReserva;
        private System.Windows.Forms.Button botAceptReserv;
        private System.Windows.Forms.TextBox tbReserva;
        public System.Windows.Forms.MonthCalendar mcFecha;
    }
}
