namespace CapaPresentacion
{
    partial class frmCheque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheque));
            this.cboaBanco = new UserControls.ucComboBoxActualizable();
            this.label4 = new System.Windows.Forms.Label();
            this.cboaCliente = new UserControls.ucComboBoxActualizable();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNroCheque = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboaNroSucursal = new UserControls.ucComboBoxActualizable();
            this.cboaFirmante = new UserControls.ucComboBoxActualizable();
            this.cboaNroCuenta = new UserControls.ucComboBoxActualizable();
            this.butAceptar1 = new System.Windows.Forms.Button();
            this.tbImporte = new KMCurrencyTextBox.KMCurrencyTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbDarDeBaja = new System.Windows.Forms.GroupBox();
            this.dtpFechaBaja = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cboaProveedor = new UserControls.ucComboBoxActualizable();
            this.label10 = new System.Windows.Forms.Label();
            this.chDarDeBaja = new System.Windows.Forms.CheckBox();
            this.gbChequeRechazado = new System.Windows.Forms.GroupBox();
            this.tbComentariosRechazo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpFechaRechazo = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.chChequeRechazado = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chRechazados = new System.Windows.Forms.CheckBox();
            this.chDeBaja = new System.Windows.Forms.CheckBox();
            this.panCentro.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panBusqueda.SuspendLayout();
            this.gbControles.SuspendLayout();
            this.panBotones.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbDarDeBaja.SuspendLayout();
            this.gbChequeRechazado.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(808, 368);
            // 
            // panAbajo
            // 
            this.panAbajo.Controls.Add(this.gbChequeRechazado);
            this.panAbajo.Location = new System.Drawing.Point(0, 408);
            this.panAbajo.Size = new System.Drawing.Size(818, 70);
            this.panAbajo.Controls.SetChildIndex(this.tbEntidadNombre, 0);
            this.panAbajo.Controls.SetChildIndex(this.gbChequeRechazado, 0);
            // 
            // tbEntidadNombre
            // 
            this.tbEntidadNombre.Location = new System.Drawing.Point(568, 6);
            // 
            // panDerecha
            // 
            this.panDerecha.Location = new System.Drawing.Point(818, 40);
            this.panDerecha.Size = new System.Drawing.Size(117, 438);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(884, 0);
            this.pictureBox2.Size = new System.Drawing.Size(51, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.DarkRed;
            this.lbTitulo.Size = new System.Drawing.Size(935, 40);
            this.lbTitulo.Text = "Cheques";
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(0, 410);
            this.butSalir.Size = new System.Drawing.Size(117, 28);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(808, 111);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Location = new System.Drawing.Point(12, 25);
            // 
            // labe2
            // 
            this.labe2.Location = new System.Drawing.Point(9, 9);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Size = new System.Drawing.Size(800, 84);
            this.tabPage1.Text = "Alta y Modificación de Cheques";
            this.tabPage1.Controls.SetChildIndex(this.groupBox1, 0);
            this.tabPage1.Controls.SetChildIndex(this.panBusqueda, 0);
            // 
            // panBusqueda
            // 
            this.panBusqueda.Size = new System.Drawing.Size(800, 84);
            // 
            // gbControles
            // 
            this.gbControles.Controls.Add(this.tbImporte);
            this.gbControles.Controls.Add(this.dtpVencimiento);
            this.gbControles.Controls.Add(this.label2);
            this.gbControles.Controls.Add(this.cboaNroCuenta);
            this.gbControles.Controls.Add(this.cboaFirmante);
            this.gbControles.Controls.Add(this.label9);
            this.gbControles.Controls.Add(this.cboaNroSucursal);
            this.gbControles.Controls.Add(this.label7);
            this.gbControles.Controls.Add(this.label8);
            this.gbControles.Controls.Add(this.label6);
            this.gbControles.Controls.Add(this.tbNroCheque);
            this.gbControles.Controls.Add(this.label5);
            this.gbControles.Controls.Add(this.cboaCliente);
            this.gbControles.Controls.Add(this.label4);
            this.gbControles.Controls.Add(this.cboaBanco);
            this.gbControles.Controls.Add(this.label3);
            this.gbControles.Controls.Add(this.butAceptar1);
            this.gbControles.Size = new System.Drawing.Size(670, 84);
            this.gbControles.TabIndex = 1;
            this.gbControles.Text = "Datos del Cheque";
            this.gbControles.Controls.SetChildIndex(this.butAceptar1, 0);
            this.gbControles.Controls.SetChildIndex(this.label3, 0);
            this.gbControles.Controls.SetChildIndex(this.label1, 0);
            this.gbControles.Controls.SetChildIndex(this.cboaBanco, 0);
            this.gbControles.Controls.SetChildIndex(this.label4, 0);
            this.gbControles.Controls.SetChildIndex(this.cboaCliente, 0);
            this.gbControles.Controls.SetChildIndex(this.label5, 0);
            this.gbControles.Controls.SetChildIndex(this.tbNroCheque, 0);
            this.gbControles.Controls.SetChildIndex(this.label6, 0);
            this.gbControles.Controls.SetChildIndex(this.label8, 0);
            this.gbControles.Controls.SetChildIndex(this.label7, 0);
            this.gbControles.Controls.SetChildIndex(this.cboaNroSucursal, 0);
            this.gbControles.Controls.SetChildIndex(this.label9, 0);
            this.gbControles.Controls.SetChildIndex(this.tbCodigo, 0);
            this.gbControles.Controls.SetChildIndex(this.cboaFirmante, 0);
            this.gbControles.Controls.SetChildIndex(this.cboaNroCuenta, 0);
            this.gbControles.Controls.SetChildIndex(this.label2, 0);
            this.gbControles.Controls.SetChildIndex(this.dtpVencimiento, 0);
            this.gbControles.Controls.SetChildIndex(this.tbImporte, 0);
            this.gbControles.Controls.SetChildIndex(this.tbId, 0);
            // 
            // tbCodigo
            // 
            this.tbCodigo.TabIndex = 0;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(479, 42);
            this.tbId.Text = "00000000-0000-0000-0000-000000000000";
            // 
            // butAgregar
            // 
            this.butAgregar.Visible = false;
            // 
            // butEliminar
            // 
            this.butEliminar.Visible = true;
            // 
            // butModificar
            // 
            this.butModificar.Visible = true;
            // 
            // butBuscar
            // 
            this.butBuscar.Location = new System.Drawing.Point(523, 24);
            // 
            // panBotones
            // 
            this.panBotones.Controls.Add(this.gbDarDeBaja);
            this.panBotones.Location = new System.Drawing.Point(670, 0);
            this.panBotones.Size = new System.Drawing.Size(130, 84);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.chRechazados);
            this.tabPage2.Controls.Add(this.chDeBaja);
            this.tabPage2.Size = new System.Drawing.Size(666, 84);
            this.tabPage2.Controls.SetChildIndex(this.chDeBaja, 0);
            this.tabPage2.Controls.SetChildIndex(this.chRechazados, 0);
            this.tabPage2.Controls.SetChildIndex(this.label14, 0);
            this.tabPage2.Controls.SetChildIndex(this.labe2, 0);
            this.tabPage2.Controls.SetChildIndex(this.tbBusqueda, 0);
            this.tabPage2.Controls.SetChildIndex(this.butBuscar, 0);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(808, 115);
            // 
            // cboaBanco
            // 
            this.cboaBanco.Location = new System.Drawing.Point(298, 26);
            this.cboaBanco.Name = "cboaBanco";
            this.cboaBanco.Size = new System.Drawing.Size(104, 23);
            this.cboaBanco.TabIndex = 3;
            this.cboaBanco.Validated += new System.EventHandler(this.cboaBanco_Validated);
            this.cboaBanco.SelectedIndexChanged += new System.EventHandler(this.cboaBanco_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Banco";
            // 
            // cboaCliente
            // 
            this.cboaCliente.Location = new System.Drawing.Point(166, 26);
            this.cboaCliente.Name = "cboaCliente";
            this.cboaCliente.Size = new System.Drawing.Size(126, 23);
            this.cboaCliente.TabIndex = 2;
            this.cboaCliente.Validated += new System.EventHandler(this.cboaCliente_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Vencimiento";
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(176, 63);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(90, 20);
            this.dtpVencimiento.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "N° Cheque";
            // 
            // tbNroCheque
            // 
            this.tbNroCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNroCheque.Location = new System.Drawing.Point(6, 63);
            this.tbNroCheque.MaxLength = 8;
            this.tbNroCheque.Name = "tbNroCheque";
            this.tbNroCheque.Size = new System.Drawing.Size(164, 20);
            this.tbNroCheque.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Importe";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(405, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Sucursal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(104, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "N° Cuenta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(346, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Firmante";
            // 
            // cboaNroSucursal
            // 
            this.cboaNroSucursal.Location = new System.Drawing.Point(408, 26);
            this.cboaNroSucursal.Name = "cboaNroSucursal";
            this.cboaNroSucursal.Size = new System.Drawing.Size(110, 23);
            this.cboaNroSucursal.TabIndex = 4;
            // 
            // cboaFirmante
            // 
            this.cboaFirmante.Location = new System.Drawing.Point(349, 63);
            this.cboaFirmante.Name = "cboaFirmante";
            this.cboaFirmante.Size = new System.Drawing.Size(170, 23);
            this.cboaFirmante.TabIndex = 8;
            // 
            // cboaNroCuenta
            // 
            this.cboaNroCuenta.Location = new System.Drawing.Point(60, 26);
            this.cboaNroCuenta.Name = "cboaNroCuenta";
            this.cboaNroCuenta.Size = new System.Drawing.Size(100, 23);
            this.cboaNroCuenta.TabIndex = 1;
            this.cboaNroCuenta.Validated += new System.EventHandler(this.cboaNroCuenta_Validated);
            // 
            // butAceptar1
            // 
            this.butAceptar1.Location = new System.Drawing.Point(529, 65);
            this.butAceptar1.Name = "butAceptar1";
            this.butAceptar1.Size = new System.Drawing.Size(10, 10);
            this.butAceptar1.TabIndex = 40;
            this.butAceptar1.UseVisualStyleBackColor = true;
            this.butAceptar1.Visible = false;
            this.butAceptar1.Enter += new System.EventHandler(this.butAceptar1_Enter);
            // 
            // tbImporte
            // 
            this.tbImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbImporte.CurrencyDecimalSeparator = ",";
            this.tbImporte.CurrencyGroupSeparator = ".";
            this.tbImporte.CurrencySymbol = "$";
            this.tbImporte.DecimalsDigits = 2;
            this.tbImporte.Location = new System.Drawing.Point(272, 63);
            this.tbImporte.Name = "tbImporte";
            this.tbImporte.Size = new System.Drawing.Size(70, 20);
            this.tbImporte.TabIndex = 7;
            this.tbImporte.Text = "$ 0,00";
            this.tbImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // gbDarDeBaja
            // 
            this.gbDarDeBaja.Controls.Add(this.dtpFechaBaja);
            this.gbDarDeBaja.Controls.Add(this.label11);
            this.gbDarDeBaja.Controls.Add(this.cboaProveedor);
            this.gbDarDeBaja.Controls.Add(this.label10);
            this.gbDarDeBaja.Controls.Add(this.chDarDeBaja);
            this.gbDarDeBaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDarDeBaja.Location = new System.Drawing.Point(0, 0);
            this.gbDarDeBaja.Name = "gbDarDeBaja";
            this.gbDarDeBaja.Size = new System.Drawing.Size(130, 84);
            this.gbDarDeBaja.TabIndex = 0;
            this.gbDarDeBaja.TabStop = false;
            this.gbDarDeBaja.Text = "                        ";
            // 
            // dtpFechaBaja
            // 
            this.dtpFechaBaja.Enabled = false;
            this.dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaBaja.Location = new System.Drawing.Point(6, 64);
            this.dtpFechaBaja.Name = "dtpFechaBaja";
            this.dtpFechaBaja.Size = new System.Drawing.Size(90, 20);
            this.dtpFechaBaja.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Fecha Baja";
            // 
            // cboaProveedor
            // 
            this.cboaProveedor.Enabled = false;
            this.cboaProveedor.Location = new System.Drawing.Point(6, 26);
            this.cboaProveedor.Name = "cboaProveedor";
            this.cboaProveedor.Size = new System.Drawing.Size(120, 23);
            this.cboaProveedor.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Proveedor";
            // 
            // chDarDeBaja
            // 
            this.chDarDeBaja.AutoSize = true;
            this.chDarDeBaja.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chDarDeBaja.Location = new System.Drawing.Point(6, 0);
            this.chDarDeBaja.Name = "chDarDeBaja";
            this.chDarDeBaja.Size = new System.Drawing.Size(82, 17);
            this.chDarDeBaja.TabIndex = 2;
            this.chDarDeBaja.Text = "Dar de Baja";
            this.chDarDeBaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chDarDeBaja.UseVisualStyleBackColor = true;
            this.chDarDeBaja.CheckedChanged += new System.EventHandler(this.chDarDeBaja_CheckedChanged);
            // 
            // gbChequeRechazado
            // 
            this.gbChequeRechazado.Controls.Add(this.tbComentariosRechazo);
            this.gbChequeRechazado.Controls.Add(this.label13);
            this.gbChequeRechazado.Controls.Add(this.dtpFechaRechazo);
            this.gbChequeRechazado.Controls.Add(this.label12);
            this.gbChequeRechazado.Controls.Add(this.chChequeRechazado);
            this.gbChequeRechazado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChequeRechazado.Location = new System.Drawing.Point(0, 0);
            this.gbChequeRechazado.Name = "gbChequeRechazado";
            this.gbChequeRechazado.Size = new System.Drawing.Size(818, 70);
            this.gbChequeRechazado.TabIndex = 7;
            this.gbChequeRechazado.TabStop = false;
            this.gbChequeRechazado.Text = "                        ";
            // 
            // tbComentariosRechazo
            // 
            this.tbComentariosRechazo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbComentariosRechazo.Enabled = false;
            this.tbComentariosRechazo.Location = new System.Drawing.Point(201, 9);
            this.tbComentariosRechazo.Multiline = true;
            this.tbComentariosRechazo.Name = "tbComentariosRechazo";
            this.tbComentariosRechazo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbComentariosRechazo.Size = new System.Drawing.Size(338, 56);
            this.tbComentariosRechazo.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(133, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Comentarios";
            // 
            // dtpFechaRechazo
            // 
            this.dtpFechaRechazo.Enabled = false;
            this.dtpFechaRechazo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRechazo.Location = new System.Drawing.Point(10, 46);
            this.dtpFechaRechazo.Name = "dtpFechaRechazo";
            this.dtpFechaRechazo.Size = new System.Drawing.Size(90, 20);
            this.dtpFechaRechazo.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Fecha";
            // 
            // chChequeRechazado
            // 
            this.chChequeRechazado.AutoSize = true;
            this.chChequeRechazado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chChequeRechazado.Location = new System.Drawing.Point(6, 0);
            this.chChequeRechazado.Name = "chChequeRechazado";
            this.chChequeRechazado.Size = new System.Drawing.Size(121, 17);
            this.chChequeRechazado.TabIndex = 2;
            this.chChequeRechazado.Text = "Cheque Rechazado";
            this.chChequeRechazado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chChequeRechazado.UseVisualStyleBackColor = true;
            this.chChequeRechazado.CheckedChanged += new System.EventHandler(this.chChequeRechazado_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "No Incluir:";
            // 
            // chRechazados
            // 
            this.chRechazados.AutoSize = true;
            this.chRechazados.Location = new System.Drawing.Point(170, 53);
            this.chRechazados.Name = "chRechazados";
            this.chRechazados.Size = new System.Drawing.Size(86, 17);
            this.chRechazados.TabIndex = 15;
            this.chRechazados.Text = "Rechazados";
            this.chRechazados.UseVisualStyleBackColor = true;
            this.chRechazados.CheckedChanged += new System.EventHandler(this.chDeBaja_CheckedChanged);
            // 
            // chDeBaja
            // 
            this.chDeBaja.AutoSize = true;
            this.chDeBaja.Location = new System.Drawing.Point(70, 53);
            this.chDeBaja.Name = "chDeBaja";
            this.chDeBaja.Size = new System.Drawing.Size(96, 17);
            this.chDeBaja.TabIndex = 14;
            this.chDeBaja.Text = "Dados de Baja";
            this.chDeBaja.UseVisualStyleBackColor = true;
            this.chDeBaja.CheckedChanged += new System.EventHandler(this.chDeBaja_CheckedChanged);
            // 
            // frmCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(935, 478);
            this.Name = "frmCheque";
            this.Text = "Cheques";
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
            this.panBotones.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbDarDeBaja.ResumeLayout(false);
            this.gbDarDeBaja.PerformLayout();
            this.gbChequeRechazado.ResumeLayout(false);
            this.gbChequeRechazado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbNroCheque;
        protected System.Windows.Forms.Label label5;
        protected UserControls.ucComboBoxActualizable cboaBanco;
        protected System.Windows.Forms.Label label4;
        protected UserControls.ucComboBoxActualizable cboaCliente;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.DateTimePicker dtpVencimiento;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Label label7;
        protected UserControls.ucComboBoxActualizable cboaNroSucursal;
        protected UserControls.ucComboBoxActualizable cboaFirmante;
        protected UserControls.ucComboBoxActualizable cboaNroCuenta;
        private System.Windows.Forms.Button butAceptar1;
        private KMCurrencyTextBox.KMCurrencyTextBox tbImporte;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbDarDeBaja;
        private System.Windows.Forms.CheckBox chDarDeBaja;
        protected System.Windows.Forms.DateTimePicker dtpFechaBaja;
        protected System.Windows.Forms.Label label11;
        protected UserControls.ucComboBoxActualizable cboaProveedor;
        protected System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbChequeRechazado;
        private System.Windows.Forms.TextBox tbComentariosRechazo;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.DateTimePicker dtpFechaRechazo;
        protected System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chChequeRechazado;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chDeBaja;
        private System.Windows.Forms.CheckBox chRechazados;
    }
}
