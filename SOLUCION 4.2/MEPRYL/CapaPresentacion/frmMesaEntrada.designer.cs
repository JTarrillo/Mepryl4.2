namespace CapaPresentacion
{
    partial class frmMesaEntrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMesaEntrada));
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.butAceptar1 = new System.Windows.Forms.Button();
            this.lbTitLiga = new System.Windows.Forms.Label();
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.rbP = new System.Windows.Forms.RadioButton();
            this.rbR = new System.Windows.Forms.RadioButton();
            this.rbCL = new System.Windows.Forms.RadioButton();
            this.rbL = new System.Windows.Forms.RadioButton();
            this.rbCO = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNroOrden = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbIdentificador = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbNombres = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbPacienteID = new System.Windows.Forms.TextBox();
            this.lbFechaNacimiento = new System.Windows.Forms.Label();
            this.lbDNI = new System.Windows.Forms.Label();
            this.lbApellido = new System.Windows.Forms.Label();
            this.lbTarea = new System.Windows.Forms.Label();
            this.lbEmpresa = new System.Windows.Forms.Label();
            this.lbClub = new System.Windows.Forms.Label();
            this.lbLiga = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbTitTarea = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTitEmpresa = new System.Windows.Forms.Label();
            this.lbTitClub = new System.Windows.Forms.Label();
            this.butPaciente = new System.Windows.Forms.Button();
            this.lbFiltro = new System.Windows.Forms.Label();
            this.butBuscarPorCampos = new System.Windows.Forms.Button();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.lbCantRegistros = new System.Windows.Forms.Label();
            this.butImprimirComprobante = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.chP = new System.Windows.Forms.CheckBox();
            this.chL = new System.Windows.Forms.CheckBox();
            this.chCL = new System.Windows.Forms.CheckBox();
            this.chR = new System.Windows.Forms.CheckBox();
            this.chCO = new System.Windows.Forms.CheckBox();
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
            this.SuspendLayout();
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(1145, 462);
            // 
            // panAbajo
            // 
            this.panAbajo.Location = new System.Drawing.Point(0, 502);
            this.panAbajo.Size = new System.Drawing.Size(1155, 5);
            // 
            // panDerecha
            // 
            this.panDerecha.Controls.Add(this.butImprimirComprobante);
            this.panDerecha.Location = new System.Drawing.Point(1155, 40);
            this.panDerecha.Size = new System.Drawing.Size(196, 467);
            this.panDerecha.Controls.SetChildIndex(this.butModificar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAceptar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butEliminar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butCancelar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAgregar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butSalir, 0);
            this.panDerecha.Controls.SetChildIndex(this.butImprimir, 0);
            this.panDerecha.Controls.SetChildIndex(this.butImprimirComprobante, 0);
            // 
            // butCancelar
            // 
            this.butCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancelar.Location = new System.Drawing.Point(6, 246);
            this.butCancelar.Size = new System.Drawing.Size(178, 44);
            this.butCancelar.Text = "&Pantalla Principal [F6]";
            // 
            // butAceptar
            // 
            this.butAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAceptar.Location = new System.Drawing.Point(6, 196);
            this.butAceptar.Size = new System.Drawing.Size(178, 44);
            this.butAceptar.Text = "&Confirmar [F5]";
            this.butAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.LimeGreen;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1308, 0);
            this.pictureBox2.Size = new System.Drawing.Size(43, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(0, 443);
            this.butSalir.Size = new System.Drawing.Size(196, 24);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(1145, 248);
            this.tabPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabPrincipal_SelectedIndexChanged);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Enabled = false;
            this.tbBusqueda.Location = new System.Drawing.Point(13, 124);
            this.tbBusqueda.Size = new System.Drawing.Size(306, 20);
            // 
            // labe2
            // 
            this.labe2.Location = new System.Drawing.Point(10, 108);
            // 
            // tabPage1
            // 
            this.tabPage1.Size = new System.Drawing.Size(1137, 221);
            // 
            // panBusqueda
            // 
            this.panBusqueda.Size = new System.Drawing.Size(1137, 221);
            // 
            // gbControles
            // 
            this.gbControles.Controls.Add(this.butPaciente);
            this.gbControles.Controls.Add(this.groupBox1);
            this.gbControles.Controls.Add(this.tbIdentificador);
            this.gbControles.Controls.Add(this.label5);
            this.gbControles.Controls.Add(this.tbNroOrden);
            this.gbControles.Controls.Add(this.label3);
            this.gbControles.Controls.Add(this.rbCO);
            this.gbControles.Controls.Add(this.rbL);
            this.gbControles.Controls.Add(this.rbCL);
            this.gbControles.Controls.Add(this.rbR);
            this.gbControles.Controls.Add(this.rbP);
            this.gbControles.Controls.Add(this.butAceptar1);
            this.gbControles.Controls.Add(this.label2);
            this.gbControles.Controls.Add(this.dtpFecha);
            this.gbControles.Dock = System.Windows.Forms.DockStyle.None;
            this.gbControles.Location = new System.Drawing.Point(0, 3);
            this.gbControles.Size = new System.Drawing.Size(1134, 216);
            this.gbControles.Controls.SetChildIndex(this.label1, 0);
            this.gbControles.Controls.SetChildIndex(this.tbCodigo, 0);
            this.gbControles.Controls.SetChildIndex(this.tbId, 0);
            this.gbControles.Controls.SetChildIndex(this.dtpFecha, 0);
            this.gbControles.Controls.SetChildIndex(this.label2, 0);
            this.gbControles.Controls.SetChildIndex(this.butAceptar1, 0);
            this.gbControles.Controls.SetChildIndex(this.rbP, 0);
            this.gbControles.Controls.SetChildIndex(this.rbR, 0);
            this.gbControles.Controls.SetChildIndex(this.rbCL, 0);
            this.gbControles.Controls.SetChildIndex(this.rbL, 0);
            this.gbControles.Controls.SetChildIndex(this.rbCO, 0);
            this.gbControles.Controls.SetChildIndex(this.label3, 0);
            this.gbControles.Controls.SetChildIndex(this.tbNroOrden, 0);
            this.gbControles.Controls.SetChildIndex(this.label5, 0);
            this.gbControles.Controls.SetChildIndex(this.tbIdentificador, 0);
            this.gbControles.Controls.SetChildIndex(this.groupBox1, 0);
            this.gbControles.Controls.SetChildIndex(this.butPaciente, 0);
            // 
            // tbCodigo
            // 
            this.tbCodigo.Location = new System.Drawing.Point(103, 166);
            this.tbCodigo.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(65, 166);
            this.label1.Visible = false;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(39, 167);
            this.tbId.Text = "00000000-0000-0000-0000-000000000000";
            // 
            // butAgregar
            // 
            this.butAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAgregar.Size = new System.Drawing.Size(178, 44);
            this.butAgregar.Text = "Nuevo Registro [F7]";
            // 
            // butEliminar
            // 
            this.butEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butEliminar.Location = new System.Drawing.Point(6, 120);
            this.butEliminar.Size = new System.Drawing.Size(178, 44);
            this.butEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butModificar
            // 
            this.butModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butModificar.Location = new System.Drawing.Point(6, 70);
            this.butModificar.Size = new System.Drawing.Size(178, 44);
            this.butModificar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butBuscar
            // 
            this.butBuscar.Enabled = false;
            this.butBuscar.Location = new System.Drawing.Point(681, 28);
            this.butBuscar.Size = new System.Drawing.Size(46, 21);
            this.butBuscar.Visible = false;
            // 
            // panBotones
            // 
            this.panBotones.Location = new System.Drawing.Point(1132, 0);
            this.panBotones.Size = new System.Drawing.Size(5, 221);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chCO);
            this.tabPage2.Controls.Add(this.chR);
            this.tabPage2.Controls.Add(this.chCL);
            this.tabPage2.Controls.Add(this.chL);
            this.tabPage2.Controls.Add(this.chP);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.lbCantRegistros);
            this.tabPage2.Controls.Add(this.butBuscarPorCampos);
            this.tabPage2.Controls.Add(this.dtpFechaHasta);
            this.tabPage2.Controls.Add(this.dtpFechaDesde);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.lbFiltro);
            this.tabPage2.Size = new System.Drawing.Size(1137, 221);
            this.tabPage2.Controls.SetChildIndex(this.labe2, 0);
            this.tabPage2.Controls.SetChildIndex(this.tbBusqueda, 0);
            this.tabPage2.Controls.SetChildIndex(this.butBuscar, 0);
            this.tabPage2.Controls.SetChildIndex(this.lbFiltro, 0);
            this.tabPage2.Controls.SetChildIndex(this.label17, 0);
            this.tabPage2.Controls.SetChildIndex(this.dtpFechaDesde, 0);
            this.tabPage2.Controls.SetChildIndex(this.dtpFechaHasta, 0);
            this.tabPage2.Controls.SetChildIndex(this.butBuscarPorCampos, 0);
            this.tabPage2.Controls.SetChildIndex(this.lbCantRegistros, 0);
            this.tabPage2.Controls.SetChildIndex(this.label4, 0);
            this.tabPage2.Controls.SetChildIndex(this.chP, 0);
            this.tabPage2.Controls.SetChildIndex(this.chL, 0);
            this.tabPage2.Controls.SetChildIndex(this.chCL, 0);
            this.tabPage2.Controls.SetChildIndex(this.chR, 0);
            this.tabPage2.Controls.SetChildIndex(this.chCO, 0);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1145, 248);
            // 
            // butImprimir
            // 
            this.butImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butImprimir.Size = new System.Drawing.Size(178, 44);
            this.butImprimir.Text = "Listado [F10]";
            this.butImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.LimeGreen;
            this.lbTitulo.Size = new System.Drawing.Size(1308, 40);
            this.lbTitulo.Text = "Mesa de Entradas";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(75, 79);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(145, 29);
            this.dtpFecha.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 18);
            this.label2.TabIndex = 49;
            this.label2.Text = "Fecha";
            // 
            // butAceptar1
            // 
            this.butAceptar1.Location = new System.Drawing.Point(132, 196);
            this.butAceptar1.Name = "butAceptar1";
            this.butAceptar1.Size = new System.Drawing.Size(10, 10);
            this.butAceptar1.TabIndex = 57;
            this.butAceptar1.UseVisualStyleBackColor = true;
            this.butAceptar1.Visible = false;
            // 
            // lbTitLiga
            // 
            this.lbTitLiga.AutoSize = true;
            this.lbTitLiga.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitLiga.Location = new System.Drawing.Point(6, 16);
            this.lbTitLiga.Name = "lbTitLiga";
            this.lbTitLiga.Size = new System.Drawing.Size(35, 18);
            this.lbTitLiga.TabIndex = 61;
            this.lbTitLiga.Text = "Liga";
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbObservaciones.Location = new System.Drawing.Point(358, 153);
            this.tbObservaciones.Multiline = true;
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObservaciones.Size = new System.Drawing.Size(276, 47);
            this.tbObservaciones.TabIndex = 0;
            // 
            // rbP
            // 
            this.rbP.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbP.AutoSize = true;
            this.rbP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbP.Location = new System.Drawing.Point(6, 12);
            this.rbP.Name = "rbP";
            this.rbP.Size = new System.Drawing.Size(37, 35);
            this.rbP.TabIndex = 0;
            this.rbP.Text = "P";
            this.rbP.UseVisualStyleBackColor = true;
            this.rbP.CheckedChanged += new System.EventHandler(this.nuevoNroOrden);
            // 
            // rbR
            // 
            this.rbR.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbR.AutoSize = true;
            this.rbR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbR.Location = new System.Drawing.Point(139, 12);
            this.rbR.Name = "rbR";
            this.rbR.Size = new System.Drawing.Size(38, 35);
            this.rbR.TabIndex = 3;
            this.rbR.Text = "R";
            this.rbR.UseVisualStyleBackColor = true;
            this.rbR.CheckedChanged += new System.EventHandler(this.nuevoNroOrden);
            // 
            // rbCL
            // 
            this.rbCL.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCL.AutoSize = true;
            this.rbCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCL.Location = new System.Drawing.Point(85, 12);
            this.rbCL.Name = "rbCL";
            this.rbCL.Size = new System.Drawing.Size(51, 35);
            this.rbCL.TabIndex = 2;
            this.rbCL.Text = "CL";
            this.rbCL.UseVisualStyleBackColor = true;
            this.rbCL.CheckedChanged += new System.EventHandler(this.nuevoNroOrden);
            // 
            // rbL
            // 
            this.rbL.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbL.AutoSize = true;
            this.rbL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbL.Location = new System.Drawing.Point(46, 12);
            this.rbL.Name = "rbL";
            this.rbL.Size = new System.Drawing.Size(35, 35);
            this.rbL.TabIndex = 1;
            this.rbL.Text = "L";
            this.rbL.UseVisualStyleBackColor = true;
            this.rbL.CheckedChanged += new System.EventHandler(this.nuevoNroOrden);
            // 
            // rbCO
            // 
            this.rbCO.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCO.AutoSize = true;
            this.rbCO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCO.Location = new System.Drawing.Point(180, 12);
            this.rbCO.Name = "rbCO";
            this.rbCO.Size = new System.Drawing.Size(55, 35);
            this.rbCO.TabIndex = 4;
            this.rbCO.Text = "CO";
            this.rbCO.UseVisualStyleBackColor = true;
            this.rbCO.CheckedChanged += new System.EventHandler(this.nuevoNroOrden);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 71;
            this.label3.Text = "Nº de Orden";
            // 
            // tbNroOrden
            // 
            this.tbNroOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNroOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroOrden.Location = new System.Drawing.Point(98, 131);
            this.tbNroOrden.Name = "tbNroOrden";
            this.tbNroOrden.ReadOnly = true;
            this.tbNroOrden.Size = new System.Drawing.Size(76, 29);
            this.tbNroOrden.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(195, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 18);
            this.label5.TabIndex = 73;
            this.label5.Text = "ID";
            // 
            // tbIdentificador
            // 
            this.tbIdentificador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIdentificador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbIdentificador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdentificador.Location = new System.Drawing.Point(222, 131);
            this.tbIdentificador.Name = "tbIdentificador";
            this.tbIdentificador.ReadOnly = true;
            this.tbIdentificador.Size = new System.Drawing.Size(76, 29);
            this.tbIdentificador.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbNombres);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbPacienteID);
            this.groupBox1.Controls.Add(this.lbFechaNacimiento);
            this.groupBox1.Controls.Add(this.lbDNI);
            this.groupBox1.Controls.Add(this.lbApellido);
            this.groupBox1.Controls.Add(this.lbTarea);
            this.groupBox1.Controls.Add(this.lbEmpresa);
            this.groupBox1.Controls.Add(this.lbClub);
            this.groupBox1.Controls.Add(this.lbLiga);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbTitTarea);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbTitEmpresa);
            this.groupBox1.Controls.Add(this.lbTitClub);
            this.groupBox1.Controls.Add(this.tbObservaciones);
            this.groupBox1.Controls.Add(this.lbTitLiga);
            this.groupBox1.Location = new System.Drawing.Point(377, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 206);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            // 
            // lbNombres
            // 
            this.lbNombres.AutoSize = true;
            this.lbNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombres.Location = new System.Drawing.Point(229, 92);
            this.lbNombres.Name = "lbNombres";
            this.lbNombres.Size = new System.Drawing.Size(17, 18);
            this.lbNombres.TabIndex = 78;
            this.lbNombres.Text = "_";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(229, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 18);
            this.label14.TabIndex = 77;
            this.label14.Text = "Nombres";
            // 
            // tbPacienteID
            // 
            this.tbPacienteID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPacienteID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbPacienteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPacienteID.Location = new System.Drawing.Point(711, 121);
            this.tbPacienteID.Name = "tbPacienteID";
            this.tbPacienteID.ReadOnly = true;
            this.tbPacienteID.Size = new System.Drawing.Size(32, 26);
            this.tbPacienteID.TabIndex = 76;
            this.tbPacienteID.Visible = false;
            // 
            // lbFechaNacimiento
            // 
            this.lbFechaNacimiento.AutoSize = true;
            this.lbFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaNacimiento.Location = new System.Drawing.Point(6, 146);
            this.lbFechaNacimiento.Name = "lbFechaNacimiento";
            this.lbFechaNacimiento.Size = new System.Drawing.Size(17, 18);
            this.lbFechaNacimiento.TabIndex = 75;
            this.lbFechaNacimiento.Text = "_";
            // 
            // lbDNI
            // 
            this.lbDNI.AutoSize = true;
            this.lbDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDNI.Location = new System.Drawing.Point(231, 146);
            this.lbDNI.Name = "lbDNI";
            this.lbDNI.Size = new System.Drawing.Size(17, 18);
            this.lbDNI.TabIndex = 74;
            this.lbDNI.Text = "_";
            // 
            // lbApellido
            // 
            this.lbApellido.AutoSize = true;
            this.lbApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApellido.Location = new System.Drawing.Point(6, 94);
            this.lbApellido.Name = "lbApellido";
            this.lbApellido.Size = new System.Drawing.Size(17, 18);
            this.lbApellido.TabIndex = 73;
            this.lbApellido.Text = "_";
            // 
            // lbTarea
            // 
            this.lbTarea.AutoSize = true;
            this.lbTarea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTarea.Location = new System.Drawing.Point(470, 92);
            this.lbTarea.Name = "lbTarea";
            this.lbTarea.Size = new System.Drawing.Size(17, 18);
            this.lbTarea.TabIndex = 72;
            this.lbTarea.Text = "_";
            // 
            // lbEmpresa
            // 
            this.lbEmpresa.AutoSize = true;
            this.lbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmpresa.Location = new System.Drawing.Point(470, 32);
            this.lbEmpresa.Name = "lbEmpresa";
            this.lbEmpresa.Size = new System.Drawing.Size(17, 18);
            this.lbEmpresa.TabIndex = 71;
            this.lbEmpresa.Text = "_";
            // 
            // lbClub
            // 
            this.lbClub.AutoSize = true;
            this.lbClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClub.Location = new System.Drawing.Point(229, 32);
            this.lbClub.Name = "lbClub";
            this.lbClub.Size = new System.Drawing.Size(17, 18);
            this.lbClub.TabIndex = 70;
            this.lbClub.Text = "_";
            // 
            // lbLiga
            // 
            this.lbLiga.AutoSize = true;
            this.lbLiga.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLiga.Location = new System.Drawing.Point(6, 32);
            this.lbLiga.Name = "lbLiga";
            this.lbLiga.Size = new System.Drawing.Size(17, 18);
            this.lbLiga.TabIndex = 69;
            this.lbLiga.Text = "_";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(355, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 18);
            this.label12.TabIndex = 68;
            this.label12.Text = "Observaciones";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(231, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 18);
            this.label11.TabIndex = 67;
            this.label11.Text = "DNI";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 18);
            this.label10.TabIndex = 66;
            this.label10.Text = "Fecha Nacimiento";
            // 
            // lbTitTarea
            // 
            this.lbTitTarea.AutoSize = true;
            this.lbTitTarea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitTarea.Location = new System.Drawing.Point(470, 76);
            this.lbTitTarea.Name = "lbTitTarea";
            this.lbTitTarea.Size = new System.Drawing.Size(46, 18);
            this.lbTitTarea.TabIndex = 65;
            this.lbTitTarea.Text = "Tarea";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 18);
            this.label8.TabIndex = 64;
            this.label8.Text = "Apellido";
            // 
            // lbTitEmpresa
            // 
            this.lbTitEmpresa.AutoSize = true;
            this.lbTitEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitEmpresa.Location = new System.Drawing.Point(470, 16);
            this.lbTitEmpresa.Name = "lbTitEmpresa";
            this.lbTitEmpresa.Size = new System.Drawing.Size(68, 18);
            this.lbTitEmpresa.TabIndex = 63;
            this.lbTitEmpresa.Text = "Empresa";
            // 
            // lbTitClub
            // 
            this.lbTitClub.AutoSize = true;
            this.lbTitClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitClub.Location = new System.Drawing.Point(229, 16);
            this.lbTitClub.Name = "lbTitClub";
            this.lbTitClub.Size = new System.Drawing.Size(38, 18);
            this.lbTitClub.TabIndex = 62;
            this.lbTitClub.Text = "Club";
            // 
            // butPaciente
            // 
            this.butPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPaciente.Location = new System.Drawing.Point(241, 13);
            this.butPaciente.Name = "butPaciente";
            this.butPaciente.Size = new System.Drawing.Size(130, 37);
            this.butPaciente.TabIndex = 8;
            this.butPaciente.Text = "Paciente [F1]";
            this.butPaciente.UseVisualStyleBackColor = true;
            this.butPaciente.Click += new System.EventHandler(this.butPaciente_Click);
            // 
            // lbFiltro
            // 
            this.lbFiltro.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lbFiltro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFiltro.ForeColor = System.Drawing.Color.White;
            this.lbFiltro.Location = new System.Drawing.Point(0, 191);
            this.lbFiltro.Name = "lbFiltro";
            this.lbFiltro.Size = new System.Drawing.Size(1137, 30);
            this.lbFiltro.TabIndex = 12;
            this.lbFiltro.Text = "Todos";
            this.lbFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butBuscarPorCampos
            // 
            this.butBuscarPorCampos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butBuscarPorCampos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarPorCampos.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarPorCampos.Image")));
            this.butBuscarPorCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscarPorCampos.Location = new System.Drawing.Point(330, 105);
            this.butBuscarPorCampos.Name = "butBuscarPorCampos";
            this.butBuscarPorCampos.Size = new System.Drawing.Size(86, 39);
            this.butBuscarPorCampos.TabIndex = 82;
            this.butBuscarPorCampos.Text = "Mostrar";
            this.butBuscarPorCampos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBuscarPorCampos.UseVisualStyleBackColor = false;
            this.butBuscarPorCampos.Click += new System.EventHandler(this.butBuscarPorCampos_Click);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(13, 61);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaHasta.TabIndex = 77;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(13, 35);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaDesde.TabIndex = 76;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 13);
            this.label17.TabIndex = 78;
            this.label17.Text = "Período";
            // 
            // lbCantRegistros
            // 
            this.lbCantRegistros.AutoSize = true;
            this.lbCantRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantRegistros.Location = new System.Drawing.Point(16, 154);
            this.lbCantRegistros.Name = "lbCantRegistros";
            this.lbCantRegistros.Size = new System.Drawing.Size(0, 25);
            this.lbCantRegistros.TabIndex = 83;
            // 
            // butImprimirComprobante
            // 
            this.butImprimirComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butImprimirComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butImprimirComprobante.Image = ((System.Drawing.Image)(resources.GetObject("butImprimirComprobante.Image")));
            this.butImprimirComprobante.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butImprimirComprobante.Location = new System.Drawing.Point(6, 322);
            this.butImprimirComprobante.Name = "butImprimirComprobante";
            this.butImprimirComprobante.Size = new System.Drawing.Size(178, 44);
            this.butImprimirComprobante.TabIndex = 7;
            this.butImprimirComprobante.Text = "Imprimir Formularios [F9]";
            this.butImprimirComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butImprimirComprobante.Click += new System.EventHandler(this.butImprimirComprobante_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 84;
            this.label4.Text = "Tipos de Consulta";
            // 
            // chP
            // 
            this.chP.AutoSize = true;
            this.chP.Checked = true;
            this.chP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chP.Location = new System.Drawing.Point(149, 40);
            this.chP.Name = "chP";
            this.chP.Size = new System.Drawing.Size(33, 17);
            this.chP.TabIndex = 85;
            this.chP.Text = "P";
            this.chP.UseVisualStyleBackColor = true;
            // 
            // chL
            // 
            this.chL.AutoSize = true;
            this.chL.Checked = true;
            this.chL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chL.Location = new System.Drawing.Point(188, 40);
            this.chL.Name = "chL";
            this.chL.Size = new System.Drawing.Size(32, 17);
            this.chL.TabIndex = 86;
            this.chL.Text = "L";
            this.chL.UseVisualStyleBackColor = true;
            // 
            // chCL
            // 
            this.chCL.AutoSize = true;
            this.chCL.Checked = true;
            this.chCL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chCL.Location = new System.Drawing.Point(226, 40);
            this.chCL.Name = "chCL";
            this.chCL.Size = new System.Drawing.Size(39, 17);
            this.chCL.TabIndex = 87;
            this.chCL.Text = "CL";
            this.chCL.UseVisualStyleBackColor = true;
            // 
            // chR
            // 
            this.chR.AutoSize = true;
            this.chR.Checked = true;
            this.chR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chR.Location = new System.Drawing.Point(271, 40);
            this.chR.Name = "chR";
            this.chR.Size = new System.Drawing.Size(34, 17);
            this.chR.TabIndex = 88;
            this.chR.Text = "R";
            this.chR.UseVisualStyleBackColor = true;
            // 
            // chCO
            // 
            this.chCO.AutoSize = true;
            this.chCO.Checked = true;
            this.chCO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chCO.Location = new System.Drawing.Point(311, 40);
            this.chCO.Name = "chCO";
            this.chCO.Size = new System.Drawing.Size(41, 17);
            this.chCO.TabIndex = 89;
            this.chCO.Text = "CO";
            this.chCO.UseVisualStyleBackColor = true;
            // 
            // frmMesaEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1351, 507);
            this.Name = "frmMesaEntrada";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mesa de Entradas";
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DateTimePicker dtpFecha;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butAceptar1;
        protected System.Windows.Forms.Label lbTitLiga;
        protected System.Windows.Forms.TextBox tbObservaciones;
        private System.Windows.Forms.RadioButton rbL;
        private System.Windows.Forms.RadioButton rbCL;
        private System.Windows.Forms.RadioButton rbR;
        private System.Windows.Forms.RadioButton rbP;
        private System.Windows.Forms.RadioButton rbCO;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox tbIdentificador;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox tbNroOrden;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butPaciente;
        protected System.Windows.Forms.Label lbTitEmpresa;
        protected System.Windows.Forms.Label lbTitClub;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.Label lbTitTarea;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Label lbFechaNacimiento;
        protected System.Windows.Forms.Label lbDNI;
        protected System.Windows.Forms.Label lbApellido;
        protected System.Windows.Forms.Label lbTarea;
        protected System.Windows.Forms.Label lbEmpresa;
        protected System.Windows.Forms.Label lbClub;
        protected System.Windows.Forms.Label lbLiga;
        protected System.Windows.Forms.TextBox tbPacienteID;
        protected System.Windows.Forms.Label lbNombres;
        protected System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbFiltro;
        protected System.Windows.Forms.Button butBuscarPorCampos;
        protected System.Windows.Forms.DateTimePicker dtpFechaHasta;
        protected System.Windows.Forms.DateTimePicker dtpFechaDesde;
        protected System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbCantRegistros;
        protected System.Windows.Forms.Button butImprimirComprobante;
        private System.Windows.Forms.CheckBox chCO;
        private System.Windows.Forms.CheckBox chR;
        private System.Windows.Forms.CheckBox chCL;
        private System.Windows.Forms.CheckBox chL;
        private System.Windows.Forms.CheckBox chP;
        protected System.Windows.Forms.Label label4;
    }
}
