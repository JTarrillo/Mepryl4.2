namespace CapaPresentacion
{
    partial class frmFacturacionElectronica
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // ─── DECLARACIONES ────────────────────────────────────────────────────
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEmision;
        private System.Windows.Forms.TabPage tabHistorial;
        private System.Windows.Forms.TabPage tabConfiguracion;

        // Tab 1 – Emisión
        private System.Windows.Forms.GroupBox grpCuitPrueba;
        private System.Windows.Forms.Button btnCuitTest1;
        private System.Windows.Forms.Button btnCuitTest2;
        private System.Windows.Forms.Button btnCuitTest3;
        private System.Windows.Forms.Button btnCuitTest4;
        private System.Windows.Forms.Label lblInfoCuitTest;
        private System.Windows.Forms.GroupBox grpComprobante;
        private System.Windows.Forms.Label lblTipoLabel;
        private System.Windows.Forms.Label lblTipoValor;
        private System.Windows.Forms.ComboBox cboTipoComprobante;
        private System.Windows.Forms.Label lblNroAsociadoLabel;
        private System.Windows.Forms.TextBox txtNroAsociado;

        private System.Windows.Forms.GroupBox grpReceptor;
        private System.Windows.Forms.RadioButton rbConsumidorFinal;
        private System.Windows.Forms.RadioButton rbConCuit;
        private System.Windows.Forms.Label lblNombreReceptorLabel;
        private System.Windows.Forms.TextBox txtNombreReceptor;
        private System.Windows.Forms.Label lblCuitReceptorLabel;
        private System.Windows.Forms.TextBox txtCuitReceptor;
        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.Label lblCondicionIvaReceptorLabel;
        private System.Windows.Forms.ComboBox cboCondicionIvaReceptor;

        private System.Windows.Forms.GroupBox grpImporte;
        private System.Windows.Forms.Label lblImporteLabel;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblIVANota;
        private System.Windows.Forms.Label lblMedioPagoLabel;
        private System.Windows.Forms.ComboBox cboMedioPago;

        private System.Windows.Forms.GroupBox grpResumen;
        private System.Windows.Forms.Label lblSubtotalLabel;
        private System.Windows.Forms.Label lblSubtotalValor;
        private System.Windows.Forms.Label lblIVALabel;
        private System.Windows.Forms.Label lblIVAValor;
        private System.Windows.Forms.Panel panelLinea;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalValor;

        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnVerPdf;

        private System.Windows.Forms.Panel panelResultado;
        private System.Windows.Forms.Label lblResultadoTitulo;
        private System.Windows.Forms.Label lblCaeLabel;
        private System.Windows.Forms.Label lblCaeValor;
        private System.Windows.Forms.Label lblNroComprobanteLabel;
        private System.Windows.Forms.Label lblNroComprobanteValor;
        private System.Windows.Forms.Label lblVencimientoLabel;
        private System.Windows.Forms.Label lblVencimientoValor;

        // Tab 2 – Historial
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblDesdeLabel;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHastaLabel;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.DataGridView dgvHistorial;

        // Tab 3 – Configuración
        private System.Windows.Forms.GroupBox grpEmisor;
        private System.Windows.Forms.Label lblCuitLabel;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label lblRazonSocialLabel;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label lblCondicionIvaEmisorLabel;
        private System.Windows.Forms.ComboBox cboCondicionIvaEmisor;

        private System.Windows.Forms.GroupBox grpTokens;

        private System.Windows.Forms.Button btnGuardarConfig;
        private System.Windows.Forms.Button btnProbarConexion;

        // ─── INITIALIZE COMPONENT ─────────────────────────────────────────────
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEmision = new System.Windows.Forms.TabPage();
            this.grpCuitPrueba = new System.Windows.Forms.GroupBox();
            this.btnCuitTest1 = new System.Windows.Forms.Button();
            this.btnCuitTest2 = new System.Windows.Forms.Button();
            this.btnCuitTest3 = new System.Windows.Forms.Button();
            this.btnCuitTest4 = new System.Windows.Forms.Button();
            this.lblInfoCuitTest = new System.Windows.Forms.Label();
            this.grpComprobante = new System.Windows.Forms.GroupBox();
            this.lblTipoLabel = new System.Windows.Forms.Label();
            this.cboTipoComprobante = new System.Windows.Forms.ComboBox();
            this.lblNroAsociadoLabel = new System.Windows.Forms.Label();
            this.txtNroAsociado = new System.Windows.Forms.TextBox();
            this.lblTipoValor = new System.Windows.Forms.Label();
            this.grpReceptor = new System.Windows.Forms.GroupBox();
            this.rbConsumidorFinal = new System.Windows.Forms.RadioButton();
            this.rbConCuit = new System.Windows.Forms.RadioButton();
            this.lblNombreReceptorLabel = new System.Windows.Forms.Label();
            this.txtNombreReceptor = new System.Windows.Forms.TextBox();
            this.lblCuitReceptorLabel = new System.Windows.Forms.Label();
            this.txtCuitReceptor = new System.Windows.Forms.TextBox();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.lblCondicionIvaReceptorLabel = new System.Windows.Forms.Label();
            this.cboCondicionIvaReceptor = new System.Windows.Forms.ComboBox();
            this.grpImporte = new System.Windows.Forms.GroupBox();
            this.lblImporteLabel = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblIVANota = new System.Windows.Forms.Label();
            this.lblMedioPagoLabel = new System.Windows.Forms.Label();
            this.cboMedioPago = new System.Windows.Forms.ComboBox();
            this.grpResumen = new System.Windows.Forms.GroupBox();
            this.lblSubtotalLabel = new System.Windows.Forms.Label();
            this.lblSubtotalValor = new System.Windows.Forms.Label();
            this.lblIVALabel = new System.Windows.Forms.Label();
            this.lblIVAValor = new System.Windows.Forms.Label();
            this.panelLinea = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnVerPdf = new System.Windows.Forms.Button();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.panelResultado = new System.Windows.Forms.Panel();
            this.lblResultadoTitulo = new System.Windows.Forms.Label();
            this.lblCaeLabel = new System.Windows.Forms.Label();
            this.lblCaeValor = new System.Windows.Forms.Label();
            this.lblNroComprobanteLabel = new System.Windows.Forms.Label();
            this.lblNroComprobanteValor = new System.Windows.Forms.Label();
            this.lblVencimientoLabel = new System.Windows.Forms.Label();
            this.lblVencimientoValor = new System.Windows.Forms.Label();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblDesdeLabel = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHastaLabel = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.tabConfiguracion = new System.Windows.Forms.TabPage();
            this.grpEmisor = new System.Windows.Forms.GroupBox();
            this.lblCuitLabel = new System.Windows.Forms.Label();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.lblRazonSocialLabel = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblCondicionIvaEmisorLabel = new System.Windows.Forms.Label();
            this.cboCondicionIvaEmisor = new System.Windows.Forms.ComboBox();
            this.grpTokens = new System.Windows.Forms.GroupBox();
            this.btnGuardarConfig = new System.Windows.Forms.Button();
            this.btnProbarConexion = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabEmision.SuspendLayout();
            this.grpCuitPrueba.SuspendLayout();
            this.grpComprobante.SuspendLayout();
            this.grpReceptor.SuspendLayout();
            this.grpImporte.SuspendLayout();
            this.grpResumen.SuspendLayout();
            this.panelResultado.SuspendLayout();
            this.tabHistorial.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.tabConfiguracion.SuspendLayout();
            this.grpEmisor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabEmision);
            this.tabControl1.Controls.Add(this.tabHistorial);
            this.tabControl1.Controls.Add(this.tabConfiguracion);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1376, 773);
            this.tabControl1.TabIndex = 0;
            // 
            // tabEmision
            // 
            this.tabEmision.AutoScroll = true;
            this.tabEmision.Controls.Add(this.grpCuitPrueba);
            this.tabEmision.Controls.Add(this.grpComprobante);
            this.tabEmision.Controls.Add(this.lblTipoValor);
            this.tabEmision.Controls.Add(this.grpReceptor);
            this.tabEmision.Controls.Add(this.grpImporte);
            this.tabEmision.Controls.Add(this.grpResumen);
            this.tabEmision.Controls.Add(this.btnLimpiar);
            this.tabEmision.Controls.Add(this.btnVerPdf);
            this.tabEmision.Controls.Add(this.btnEmitir);
            this.tabEmision.Controls.Add(this.panelResultado);
            this.tabEmision.Location = new System.Drawing.Point(4, 26);
            this.tabEmision.Name = "tabEmision";
            this.tabEmision.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmision.Size = new System.Drawing.Size(1368, 743);
            this.tabEmision.TabIndex = 0;
            this.tabEmision.Text = "  Emisión Manual  ";
            this.tabEmision.UseVisualStyleBackColor = true;
            // 
            // grpCuitPrueba
            // 
            this.grpCuitPrueba.Controls.Add(this.btnCuitTest1);
            this.grpCuitPrueba.Controls.Add(this.btnCuitTest2);
            this.grpCuitPrueba.Controls.Add(this.btnCuitTest3);
            this.grpCuitPrueba.Controls.Add(this.btnCuitTest4);
            this.grpCuitPrueba.Controls.Add(this.lblInfoCuitTest);
            this.grpCuitPrueba.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpCuitPrueba.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.grpCuitPrueba.Location = new System.Drawing.Point(15, 15);
            this.grpCuitPrueba.Name = "grpCuitPrueba";
            this.grpCuitPrueba.Size = new System.Drawing.Size(800, 150);
            this.grpCuitPrueba.TabIndex = 10;
            this.grpCuitPrueba.TabStop = false;
            this.grpCuitPrueba.Text = "CUITs de Testeo AFIP (Homologación)";
            // 
            // btnCuitTest1
            // 
            this.btnCuitTest1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCuitTest1.Location = new System.Drawing.Point(10, 20);
            this.btnCuitTest1.Name = "btnCuitTest1";
            this.btnCuitTest1.Size = new System.Drawing.Size(180, 60);
            this.btnCuitTest1.TabIndex = 0;
            this.btnCuitTest1.Text = "20111111112\r\nRI\r\nFactura A, B, C";
            this.btnCuitTest1.UseVisualStyleBackColor = true;
            this.btnCuitTest1.Click += new System.EventHandler(this.BtnCuitPrueba_Click);
            // 
            // btnCuitTest2
            // 
            this.btnCuitTest2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCuitTest2.Location = new System.Drawing.Point(200, 20);
            this.btnCuitTest2.Name = "btnCuitTest2";
            this.btnCuitTest2.Size = new System.Drawing.Size(180, 60);
            this.btnCuitTest2.TabIndex = 1;
            this.btnCuitTest2.Text = "20222222222\r\nMonotributista\r\nSolo Factura C";
            this.btnCuitTest2.UseVisualStyleBackColor = true;
            this.btnCuitTest2.Click += new System.EventHandler(this.BtnCuitPrueba_Click);
            // 
            // btnCuitTest3
            // 
            this.btnCuitTest3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCuitTest3.Location = new System.Drawing.Point(390, 20);
            this.btnCuitTest3.Name = "btnCuitTest3";
            this.btnCuitTest3.Size = new System.Drawing.Size(180, 60);
            this.btnCuitTest3.TabIndex = 2;
            this.btnCuitTest3.Text = "20333333333\r\nExento\r\nFactura C, E";
            this.btnCuitTest3.UseVisualStyleBackColor = true;
            this.btnCuitTest3.Click += new System.EventHandler(this.BtnCuitPrueba_Click);
            // 
            // btnCuitTest4
            // 
            this.btnCuitTest4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCuitTest4.Location = new System.Drawing.Point(580, 20);
            this.btnCuitTest4.Name = "btnCuitTest4";
            this.btnCuitTest4.Size = new System.Drawing.Size(180, 60);
            this.btnCuitTest4.TabIndex = 3;
            this.btnCuitTest4.Text = "20333333334\r\nConsumidor Final\r\nFactura C, E";
            this.btnCuitTest4.UseVisualStyleBackColor = true;
            this.btnCuitTest4.Click += new System.EventHandler(this.BtnCuitPrueba_Click);
            // 
            // lblInfoCuitTest
            // 
            this.lblInfoCuitTest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblInfoCuitTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblInfoCuitTest.Location = new System.Drawing.Point(10, 90);
            this.lblInfoCuitTest.Name = "lblInfoCuitTest";
            this.lblInfoCuitTest.Size = new System.Drawing.Size(730, 20);
            this.lblInfoCuitTest.TabIndex = 4;
            this.lblInfoCuitTest.Text = "Estos CUITs son válidos solo en modo HOMOLOGACIÓN de AFIP para testing.";
            // 
            // grpComprobante
            // 
            this.grpComprobante.Controls.Add(this.lblTipoLabel);
            this.grpComprobante.Controls.Add(this.cboTipoComprobante);
            this.grpComprobante.Controls.Add(this.lblNroAsociadoLabel);
            this.grpComprobante.Controls.Add(this.txtNroAsociado);
            this.grpComprobante.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpComprobante.Location = new System.Drawing.Point(15, 171);
            this.grpComprobante.Name = "grpComprobante";
            this.grpComprobante.Size = new System.Drawing.Size(800, 79);
            this.grpComprobante.TabIndex = 0;
            this.grpComprobante.TabStop = false;
            this.grpComprobante.Text = "Tipo de Comprobante a Emitir";
            // 
            // lblTipoLabel
            // 
            this.lblTipoLabel.AutoSize = true;
            this.lblTipoLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTipoLabel.Location = new System.Drawing.Point(12, 30);
            this.lblTipoLabel.Name = "lblTipoLabel";
            this.lblTipoLabel.Size = new System.Drawing.Size(43, 19);
            this.lblTipoLabel.TabIndex = 0;
            this.lblTipoLabel.Text = "Tipo:";
            // 
            // cboTipoComprobante
            // 
            this.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.cboTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(160)))));
            this.cboTipoComprobante.Items.AddRange(new object[] {
            "FACTURA B",
            "FACTURA A",
            "FACTURA C",
            "NOTA DE CREDITO B",
            "NOTA DE CREDITO A",
            "NOTA DE CREDITO C",
            "NOTA DE DEBITO B",
            "NOTA DE DEBITO A",
            "NOTA DE DEBITO C"});
            this.cboTipoComprobante.Location = new System.Drawing.Point(60, 27);
            this.cboTipoComprobante.Name = "cboTipoComprobante";
            this.cboTipoComprobante.Size = new System.Drawing.Size(300, 28);
            this.cboTipoComprobante.TabIndex = 0;
            this.cboTipoComprobante.SelectedIndexChanged += new System.EventHandler(this.cboTipoComprobante_SelectedIndexChanged);
            // 
            // lblNroAsociadoLabel
            // 
            this.lblNroAsociadoLabel.AutoSize = true;
            this.lblNroAsociadoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNroAsociadoLabel.Location = new System.Drawing.Point(448, 30);
            this.lblNroAsociadoLabel.Name = "lblNroAsociadoLabel";
            this.lblNroAsociadoLabel.Size = new System.Drawing.Size(102, 15);
            this.lblNroAsociadoLabel.TabIndex = 2;
            this.lblNroAsociadoLabel.Text = "Nro. Factura orig.:";
            this.lblNroAsociadoLabel.Visible = false;
            // 
            // txtNroAsociado
            // 
            this.txtNroAsociado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNroAsociado.Location = new System.Drawing.Point(566, 25);
            this.txtNroAsociado.Name = "txtNroAsociado";
            this.txtNroAsociado.Size = new System.Drawing.Size(60, 25);
            this.txtNroAsociado.TabIndex = 1;
            this.txtNroAsociado.Visible = false;
            // 
            // lblTipoValor
            // 
            this.lblTipoValor.AutoSize = true;
            this.lblTipoValor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTipoValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.lblTipoValor.Location = new System.Drawing.Point(15, 260);
            this.lblTipoValor.Name = "lblTipoValor";
            this.lblTipoValor.Size = new System.Drawing.Size(342, 20);
            this.lblTipoValor.TabIndex = 1;
            this.lblTipoValor.Text = "Factura C  —  Monotributo (sin discriminar IVA)";
            // 
            // grpReceptor
            // 
            this.grpReceptor.Controls.Add(this.rbConsumidorFinal);
            this.grpReceptor.Controls.Add(this.rbConCuit);
            this.grpReceptor.Controls.Add(this.lblNombreReceptorLabel);
            this.grpReceptor.Controls.Add(this.txtNombreReceptor);
            this.grpReceptor.Controls.Add(this.lblCuitReceptorLabel);
            this.grpReceptor.Controls.Add(this.txtCuitReceptor);
            this.grpReceptor.Controls.Add(this.btnBuscarPaciente);
            this.grpReceptor.Controls.Add(this.lblCondicionIvaReceptorLabel);
            this.grpReceptor.Controls.Add(this.cboCondicionIvaReceptor);
            this.grpReceptor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grpReceptor.Location = new System.Drawing.Point(15, 304);
            this.grpReceptor.Name = "grpReceptor";
            this.grpReceptor.Size = new System.Drawing.Size(800, 220);
            this.grpReceptor.TabIndex = 1;
            this.grpReceptor.TabStop = false;
            this.grpReceptor.Text = "Datos del Receptor";
            // 
            // rbConsumidorFinal
            // 
            this.rbConsumidorFinal.AutoSize = true;
            this.rbConsumidorFinal.Checked = true;
            this.rbConsumidorFinal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbConsumidorFinal.Location = new System.Drawing.Point(20, 30);
            this.rbConsumidorFinal.Name = "rbConsumidorFinal";
            this.rbConsumidorFinal.Size = new System.Drawing.Size(127, 21);
            this.rbConsumidorFinal.TabIndex = 0;
            this.rbConsumidorFinal.TabStop = true;
            this.rbConsumidorFinal.Text = "Consumidor Final";
            this.rbConsumidorFinal.CheckedChanged += new System.EventHandler(this.rbConsumidorFinal_CheckedChanged);
            // 
            // rbConCuit
            // 
            this.rbConCuit.AutoSize = true;
            this.rbConCuit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbConCuit.Location = new System.Drawing.Point(250, 30);
            this.rbConCuit.Name = "rbConCuit";
            this.rbConCuit.Size = new System.Drawing.Size(135, 21);
            this.rbConCuit.TabIndex = 1;
            this.rbConCuit.Text = "Receptor con CUIT";
            // 
            // lblNombreReceptorLabel
            // 
            this.lblNombreReceptorLabel.AutoSize = true;
            this.lblNombreReceptorLabel.Location = new System.Drawing.Point(20, 65);
            this.lblNombreReceptorLabel.Name = "lblNombreReceptorLabel";
            this.lblNombreReceptorLabel.Size = new System.Drawing.Size(147, 17);
            this.lblNombreReceptorLabel.TabIndex = 2;
            this.lblNombreReceptorLabel.Text = "Nombre / Razón Social:";
            // 
            // txtNombreReceptor
            // 
            this.txtNombreReceptor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreReceptor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombreReceptor.Location = new System.Drawing.Point(20, 88);
            this.txtNombreReceptor.Name = "txtNombreReceptor";
            this.txtNombreReceptor.Size = new System.Drawing.Size(800, 25);
            this.txtNombreReceptor.TabIndex = 2;
            this.txtNombreReceptor.Text = "Consumidor Final";
            // 
            // lblCuitReceptorLabel
            // 
            this.lblCuitReceptorLabel.AutoSize = true;
            this.lblCuitReceptorLabel.Location = new System.Drawing.Point(20, 120);
            this.lblCuitReceptorLabel.Name = "lblCuitReceptorLabel";
            this.lblCuitReceptorLabel.Size = new System.Drawing.Size(152, 17);
            this.lblCuitReceptorLabel.TabIndex = 3;
            this.lblCuitReceptorLabel.Text = "DNI / CUIT del Receptor:";
            // 
            // txtCuitReceptor
            // 
            this.txtCuitReceptor.Enabled = false;
            this.txtCuitReceptor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCuitReceptor.Location = new System.Drawing.Point(180, 117);
            this.txtCuitReceptor.Name = "txtCuitReceptor";
            this.txtCuitReceptor.Size = new System.Drawing.Size(150, 25);
            this.txtCuitReceptor.TabIndex = 3;
            this.txtCuitReceptor.Text = "0";
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBuscarPaciente.Location = new System.Drawing.Point(340, 115);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(135, 28);
            this.btnBuscarPaciente.TabIndex = 10;
            this.btnBuscarPaciente.Text = "🔍  Buscar...";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // lblCondicionIvaReceptorLabel
            // 
            this.lblCondicionIvaReceptorLabel.AutoSize = true;
            this.lblCondicionIvaReceptorLabel.Location = new System.Drawing.Point(20, 145);
            this.lblCondicionIvaReceptorLabel.Name = "lblCondicionIvaReceptorLabel";
            this.lblCondicionIvaReceptorLabel.Size = new System.Drawing.Size(91, 17);
            this.lblCondicionIvaReceptorLabel.TabIndex = 11;
            this.lblCondicionIvaReceptorLabel.Text = "Condición IVA:";
            // 
            // cboCondicionIvaReceptor
            // 
            this.cboCondicionIvaReceptor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicionIvaReceptor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCondicionIvaReceptor.Items.AddRange(new object[] {
            "Consumidor Final",
            "Responsable Inscripto",
            "Monotributista",
            "Exento"});
            this.cboCondicionIvaReceptor.Location = new System.Drawing.Point(20, 165);
            this.cboCondicionIvaReceptor.Name = "cboCondicionIvaReceptor";
            this.cboCondicionIvaReceptor.Size = new System.Drawing.Size(200, 25);
            this.cboCondicionIvaReceptor.TabIndex = 12;
            // 
            // grpImporte
            // 
            this.grpImporte.Controls.Add(this.lblImporteLabel);
            this.grpImporte.Controls.Add(this.txtImporte);
            this.grpImporte.Controls.Add(this.lblIVANota);
            this.grpImporte.Controls.Add(this.lblMedioPagoLabel);
            this.grpImporte.Controls.Add(this.cboMedioPago);
            this.grpImporte.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grpImporte.Location = new System.Drawing.Point(25, 550);
            this.grpImporte.Name = "grpImporte";
            this.grpImporte.Size = new System.Drawing.Size(800, 220);
            this.grpImporte.TabIndex = 2;
            this.grpImporte.TabStop = false;
            this.grpImporte.Text = "Importe y Medio de Pago";
            // 
            // lblImporteLabel
            // 
            this.lblImporteLabel.AutoSize = true;
            this.lblImporteLabel.Location = new System.Drawing.Point(20, 100);
            this.lblImporteLabel.Name = "lblImporteLabel";
            this.lblImporteLabel.Size = new System.Drawing.Size(108, 17);
            this.lblImporteLabel.TabIndex = 0;
            this.lblImporteLabel.Text = "Importe Total ($):";
            // 
            // txtImporte
            // 
            this.txtImporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImporte.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtImporte.Location = new System.Drawing.Point(20, 123);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(300, 36);
            this.txtImporte.TabIndex = 4;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.TextChanged += new System.EventHandler(this.txtImporte_TextChanged);
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // lblIVANota
            // 
            this.lblIVANota.AutoSize = true;
            this.lblIVANota.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblIVANota.ForeColor = System.Drawing.Color.Gray;
            this.lblIVANota.Location = new System.Drawing.Point(330, 133);
            this.lblIVANota.Name = "lblIVANota";
            this.lblIVANota.Size = new System.Drawing.Size(106, 30);
            this.lblIVANota.TabIndex = 5;
            this.lblIVANota.Text = "Sin discriminar IVA\r\n(Monotributo)";
            // 
            // lblMedioPagoLabel
            // 
            this.lblMedioPagoLabel.AutoSize = true;
            this.lblMedioPagoLabel.Location = new System.Drawing.Point(20, 170);
            this.lblMedioPagoLabel.Name = "lblMedioPagoLabel";
            this.lblMedioPagoLabel.Size = new System.Drawing.Size(102, 17);
            this.lblMedioPagoLabel.TabIndex = 6;
            this.lblMedioPagoLabel.Text = "Medio de Pago:";
            // 
            // cboMedioPago
            // 
            this.cboMedioPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedioPago.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboMedioPago.Items.AddRange(new object[] {
            "EFECTIVO",
            "TARJETA_CREDITO",
            "TARJETA_DEBITO",
            "MERCADO_PAGO",
            "TRANSFERENCIA"});
            this.cboMedioPago.Location = new System.Drawing.Point(130, 167);
            this.cboMedioPago.Name = "cboMedioPago";
            this.cboMedioPago.Size = new System.Drawing.Size(250, 25);
            this.cboMedioPago.TabIndex = 9;
            // 
            // grpResumen
            // 
            this.grpResumen.Controls.Add(this.lblSubtotalLabel);
            this.grpResumen.Controls.Add(this.lblSubtotalValor);
            this.grpResumen.Controls.Add(this.lblIVALabel);
            this.grpResumen.Controls.Add(this.lblIVAValor);
            this.grpResumen.Controls.Add(this.panelLinea);
            this.grpResumen.Controls.Add(this.lblTotalLabel);
            this.grpResumen.Controls.Add(this.lblTotalValor);
            this.grpResumen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grpResumen.Location = new System.Drawing.Point(847, 35);
            this.grpResumen.Name = "grpResumen";
            this.grpResumen.Size = new System.Drawing.Size(490, 130);
            this.grpResumen.TabIndex = 3;
            this.grpResumen.TabStop = false;
            this.grpResumen.Text = "Resumen de Importes";
            // 
            // lblSubtotalLabel
            // 
            this.lblSubtotalLabel.AutoSize = true;
            this.lblSubtotalLabel.Location = new System.Drawing.Point(12, 30);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";
            this.lblSubtotalLabel.Size = new System.Drawing.Size(59, 17);
            this.lblSubtotalLabel.TabIndex = 0;
            this.lblSubtotalLabel.Text = "Subtotal:";
            // 
            // lblSubtotalValor
            // 
            this.lblSubtotalValor.Location = new System.Drawing.Point(200, 30);
            this.lblSubtotalValor.Name = "lblSubtotalValor";
            this.lblSubtotalValor.Size = new System.Drawing.Size(210, 20);
            this.lblSubtotalValor.TabIndex = 1;
            this.lblSubtotalValor.Text = "$0.00";
            this.lblSubtotalValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIVALabel
            // 
            this.lblIVALabel.AutoSize = true;
            this.lblIVALabel.Location = new System.Drawing.Point(12, 58);
            this.lblIVALabel.Name = "lblIVALabel";
            this.lblIVALabel.Size = new System.Drawing.Size(29, 17);
            this.lblIVALabel.TabIndex = 2;
            this.lblIVALabel.Text = "IVA:";
            // 
            // lblIVAValor
            // 
            this.lblIVAValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblIVAValor.ForeColor = System.Drawing.Color.Gray;
            this.lblIVAValor.Location = new System.Drawing.Point(200, 58);
            this.lblIVAValor.Name = "lblIVAValor";
            this.lblIVAValor.Size = new System.Drawing.Size(210, 20);
            this.lblIVAValor.TabIndex = 3;
            this.lblIVAValor.Text = "No aplica (Monotributo)";
            this.lblIVAValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelLinea
            // 
            this.panelLinea.BackColor = System.Drawing.Color.DarkGray;
            this.panelLinea.Location = new System.Drawing.Point(10, 85);
            this.panelLinea.Name = "panelLinea";
            this.panelLinea.Size = new System.Drawing.Size(405, 1);
            this.panelLinea.TabIndex = 99;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(10, 94);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(180, 30);
            this.lblTotalLabel.TabIndex = 100;
            this.lblTotalLabel.Text = "TOTAL A FACTURAR:";
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(55)))));
            this.lblTotalValor.Location = new System.Drawing.Point(200, 90);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(216, 36);
            this.lblTotalValor.TabIndex = 101;
            this.lblTotalValor.Text = "$0.00";
            this.lblTotalValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLimpiar.Location = new System.Drawing.Point(250, 880);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(160, 50);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "↺  Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnVerPdf
            // 
            this.btnVerPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnVerPdf.FlatAppearance.BorderSize = 0;
            this.btnVerPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPdf.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVerPdf.ForeColor = System.Drawing.Color.White;
            this.btnVerPdf.Location = new System.Drawing.Point(430, 880);
            this.btnVerPdf.Name = "btnVerPdf";
            this.btnVerPdf.Size = new System.Drawing.Size(160, 50);
            this.btnVerPdf.TabIndex = 8;
            this.btnVerPdf.Text = "📄  Ver PDF";
            this.btnVerPdf.UseVisualStyleBackColor = false;
            this.btnVerPdf.Visible = false;
            this.btnVerPdf.Click += new System.EventHandler(this.btnVerPdf_Click);
            // 
            // btnEmitir
            // 
            this.btnEmitir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(60)))));
            this.btnEmitir.FlatAppearance.BorderSize = 0;
            this.btnEmitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmitir.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnEmitir.ForeColor = System.Drawing.Color.White;
            this.btnEmitir.Location = new System.Drawing.Point(15, 880);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(220, 50);
            this.btnEmitir.TabIndex = 6;
            this.btnEmitir.Text = "⚡  Emitir";
            this.btnEmitir.UseVisualStyleBackColor = false;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // panelResultado
            // 
            this.panelResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResultado.Controls.Add(this.lblResultadoTitulo);
            this.panelResultado.Controls.Add(this.lblCaeLabel);
            this.panelResultado.Controls.Add(this.lblCaeValor);
            this.panelResultado.Controls.Add(this.lblNroComprobanteLabel);
            this.panelResultado.Controls.Add(this.lblNroComprobanteValor);
            this.panelResultado.Controls.Add(this.lblVencimientoLabel);
            this.panelResultado.Controls.Add(this.lblVencimientoValor);
            this.panelResultado.Location = new System.Drawing.Point(15, 950);
            this.panelResultado.Name = "panelResultado";
            this.panelResultado.Size = new System.Drawing.Size(800, 120);
            this.panelResultado.TabIndex = 7;
            this.panelResultado.Visible = false;
            // 
            // lblResultadoTitulo
            // 
            this.lblResultadoTitulo.AutoSize = true;
            this.lblResultadoTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblResultadoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblResultadoTitulo.Location = new System.Drawing.Point(10, 8);
            this.lblResultadoTitulo.Name = "lblResultadoTitulo";
            this.lblResultadoTitulo.Size = new System.Drawing.Size(243, 21);
            this.lblResultadoTitulo.TabIndex = 0;
            this.lblResultadoTitulo.Text = "✓  Factura Autorizada por AFIP";
            // 
            // lblCaeLabel
            // 
            this.lblCaeLabel.AutoSize = true;
            this.lblCaeLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCaeLabel.Location = new System.Drawing.Point(10, 42);
            this.lblCaeLabel.Name = "lblCaeLabel";
            this.lblCaeLabel.Size = new System.Drawing.Size(34, 17);
            this.lblCaeLabel.TabIndex = 1;
            this.lblCaeLabel.Text = "CAE:";
            // 
            // lblCaeValor
            // 
            this.lblCaeValor.AutoSize = true;
            this.lblCaeValor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaeValor.Location = new System.Drawing.Point(55, 42);
            this.lblCaeValor.Name = "lblCaeValor";
            this.lblCaeValor.Size = new System.Drawing.Size(27, 19);
            this.lblCaeValor.TabIndex = 2;
            this.lblCaeValor.Text = "---";
            // 
            // lblNroComprobanteLabel
            // 
            this.lblNroComprobanteLabel.AutoSize = true;
            this.lblNroComprobanteLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNroComprobanteLabel.Location = new System.Drawing.Point(340, 42);
            this.lblNroComprobanteLabel.Name = "lblNroComprobanteLabel";
            this.lblNroComprobanteLabel.Size = new System.Drawing.Size(122, 17);
            this.lblNroComprobanteLabel.TabIndex = 3;
            this.lblNroComprobanteLabel.Text = "Nro. Comprobante:";
            // 
            // lblNroComprobanteValor
            // 
            this.lblNroComprobanteValor.AutoSize = true;
            this.lblNroComprobanteValor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNroComprobanteValor.Location = new System.Drawing.Point(460, 42);
            this.lblNroComprobanteValor.Name = "lblNroComprobanteValor";
            this.lblNroComprobanteValor.Size = new System.Drawing.Size(27, 19);
            this.lblNroComprobanteValor.TabIndex = 4;
            this.lblNroComprobanteValor.Text = "---";
            // 
            // lblVencimientoLabel
            // 
            this.lblVencimientoLabel.AutoSize = true;
            this.lblVencimientoLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblVencimientoLabel.Location = new System.Drawing.Point(10, 70);
            this.lblVencimientoLabel.Name = "lblVencimientoLabel";
            this.lblVencimientoLabel.Size = new System.Drawing.Size(108, 17);
            this.lblVencimientoLabel.TabIndex = 5;
            this.lblVencimientoLabel.Text = "Vencimiento CAE:";
            // 
            // lblVencimientoValor
            // 
            this.lblVencimientoValor.AutoSize = true;
            this.lblVencimientoValor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVencimientoValor.Location = new System.Drawing.Point(130, 70);
            this.lblVencimientoValor.Name = "lblVencimientoValor";
            this.lblVencimientoValor.Size = new System.Drawing.Size(27, 19);
            this.lblVencimientoValor.TabIndex = 6;
            this.lblVencimientoValor.Text = "---";
            // 
            // tabHistorial
            // 
            this.tabHistorial.Controls.Add(this.panelFiltros);
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Location = new System.Drawing.Point(4, 26);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistorial.Size = new System.Drawing.Size(1368, 743);
            this.tabHistorial.TabIndex = 1;
            this.tabHistorial.Text = "  Historial  ";
            this.tabHistorial.UseVisualStyleBackColor = true;
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.lblDesdeLabel);
            this.panelFiltros.Controls.Add(this.dtpDesde);
            this.panelFiltros.Controls.Add(this.lblHastaLabel);
            this.panelFiltros.Controls.Add(this.dtpHasta);
            this.panelFiltros.Controls.Add(this.btnActualizar);
            this.panelFiltros.Controls.Add(this.btnAnular);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.panelFiltros.Location = new System.Drawing.Point(3, 3);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1362, 48);
            this.panelFiltros.TabIndex = 0;
            // 
            // lblDesdeLabel
            // 
            this.lblDesdeLabel.AutoSize = true;
            this.lblDesdeLabel.Location = new System.Drawing.Point(8, 14);
            this.lblDesdeLabel.Name = "lblDesdeLabel";
            this.lblDesdeLabel.Size = new System.Drawing.Size(48, 17);
            this.lblDesdeLabel.TabIndex = 0;
            this.lblDesdeLabel.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(60, 10);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(120, 24);
            this.dtpDesde.TabIndex = 0;
            // 
            // lblHastaLabel
            // 
            this.lblHastaLabel.AutoSize = true;
            this.lblHastaLabel.Location = new System.Drawing.Point(200, 14);
            this.lblHastaLabel.Name = "lblHastaLabel";
            this.lblHastaLabel.Size = new System.Drawing.Size(44, 17);
            this.lblHastaLabel.TabIndex = 1;
            this.lblHastaLabel.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(250, 10);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(120, 24);
            this.dtpHasta.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnActualizar.Location = new System.Drawing.Point(388, 8);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(120, 30);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "🔄  Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAnular.ForeColor = System.Drawing.Color.White;
            this.btnAnular.Location = new System.Drawing.Point(526, 8);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(293, 30);
            this.btnAnular.TabIndex = 3;
            this.btnAnular.Text = "❌  Anular Seleccionado";
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvHistorial.Location = new System.Drawing.Point(3, 3);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(1362, 737);
            this.dgvHistorial.TabIndex = 1;
            this.dgvHistorial.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorial_CellDoubleClick);
            // 
            // tabConfiguracion
            // 
            this.tabConfiguracion.Controls.Add(this.grpEmisor);
            this.tabConfiguracion.Controls.Add(this.grpTokens);
            this.tabConfiguracion.Controls.Add(this.btnGuardarConfig);
            this.tabConfiguracion.Controls.Add(this.btnProbarConexion);
            this.tabConfiguracion.Location = new System.Drawing.Point(4, 26);
            this.tabConfiguracion.Name = "tabConfiguracion";
            this.tabConfiguracion.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfiguracion.Size = new System.Drawing.Size(1368, 743);
            this.tabConfiguracion.TabIndex = 2;
            this.tabConfiguracion.Text = "  Configuración  ";
            this.tabConfiguracion.UseVisualStyleBackColor = true;
            // 
            // grpEmisor
            // 
            this.grpEmisor.Controls.Add(this.lblCuitLabel);
            this.grpEmisor.Controls.Add(this.txtCuit);
            this.grpEmisor.Controls.Add(this.lblRazonSocialLabel);
            this.grpEmisor.Controls.Add(this.txtRazonSocial);
            this.grpEmisor.Controls.Add(this.lblCondicionIvaEmisorLabel);
            this.grpEmisor.Controls.Add(this.cboCondicionIvaEmisor);
            this.grpEmisor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grpEmisor.Location = new System.Drawing.Point(10, 10);
            this.grpEmisor.Name = "grpEmisor";
            this.grpEmisor.Size = new System.Drawing.Size(550, 135);
            this.grpEmisor.TabIndex = 0;
            this.grpEmisor.TabStop = false;
            this.grpEmisor.Text = "Datos del Emisor (Monotributista)";
            // 
            // lblCuitLabel
            // 
            this.lblCuitLabel.AutoSize = true;
            this.lblCuitLabel.Location = new System.Drawing.Point(12, 28);
            this.lblCuitLabel.Name = "lblCuitLabel";
            this.lblCuitLabel.Size = new System.Drawing.Size(38, 17);
            this.lblCuitLabel.TabIndex = 0;
            this.lblCuitLabel.Text = "CUIT:";
            // 
            // txtCuit
            // 
            this.txtCuit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCuit.Location = new System.Drawing.Point(100, 24);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(200, 25);
            this.txtCuit.TabIndex = 0;
            // 
            // lblRazonSocialLabel
            // 
            this.lblRazonSocialLabel.AutoSize = true;
            this.lblRazonSocialLabel.Location = new System.Drawing.Point(12, 62);
            this.lblRazonSocialLabel.Name = "lblRazonSocialLabel";
            this.lblRazonSocialLabel.Size = new System.Drawing.Size(85, 17);
            this.lblRazonSocialLabel.TabIndex = 1;
            this.lblRazonSocialLabel.Text = "Razón Social:";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRazonSocial.Location = new System.Drawing.Point(100, 58);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(435, 25);
            this.txtRazonSocial.TabIndex = 1;
            // 
            // lblCondicionIvaEmisorLabel
            // 
            this.lblCondicionIvaEmisorLabel.AutoSize = true;
            this.lblCondicionIvaEmisorLabel.Location = new System.Drawing.Point(12, 95);
            this.lblCondicionIvaEmisorLabel.Name = "lblCondicionIvaEmisorLabel";
            this.lblCondicionIvaEmisorLabel.Size = new System.Drawing.Size(91, 17);
            this.lblCondicionIvaEmisorLabel.TabIndex = 2;
            this.lblCondicionIvaEmisorLabel.Text = "Condición IVA:";
            // 
            // cboCondicionIvaEmisor
            // 
            this.cboCondicionIvaEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicionIvaEmisor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCondicionIvaEmisor.Items.AddRange(new object[] {
            "Monotributista",
            "Responsable Inscripto",
            "Exento"});
            this.cboCondicionIvaEmisor.Location = new System.Drawing.Point(100, 92);
            this.cboCondicionIvaEmisor.Name = "cboCondicionIvaEmisor";
            this.cboCondicionIvaEmisor.Size = new System.Drawing.Size(200, 25);
            this.cboCondicionIvaEmisor.TabIndex = 3;
            // 
            // grpTokens
            // 
            this.grpTokens.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grpTokens.Location = new System.Drawing.Point(10, 155);
            this.grpTokens.Name = "grpTokens";
            this.grpTokens.Size = new System.Drawing.Size(870, 200);
            this.grpTokens.TabIndex = 1;
            this.grpTokens.TabStop = false;
            this.grpTokens.Text = "Configuración API Local (servidor localhost:3000)";
            // 
            // btnGuardarConfig
            // 
            this.btnGuardarConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(178)))));
            this.btnGuardarConfig.FlatAppearance.BorderSize = 0;
            this.btnGuardarConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarConfig.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuardarConfig.ForeColor = System.Drawing.Color.White;
            this.btnGuardarConfig.Location = new System.Drawing.Point(10, 365);
            this.btnGuardarConfig.Name = "btnGuardarConfig";
            this.btnGuardarConfig.Size = new System.Drawing.Size(240, 42);
            this.btnGuardarConfig.TabIndex = 6;
            this.btnGuardarConfig.Text = "💾  Guardar Configuración";
            this.btnGuardarConfig.UseVisualStyleBackColor = false;
            this.btnGuardarConfig.Click += new System.EventHandler(this.btnGuardarConfig_Click);
            // 
            // btnProbarConexion
            // 
            this.btnProbarConexion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProbarConexion.Location = new System.Drawing.Point(265, 365);
            this.btnProbarConexion.Name = "btnProbarConexion";
            this.btnProbarConexion.Size = new System.Drawing.Size(200, 42);
            this.btnProbarConexion.TabIndex = 7;
            this.btnProbarConexion.Text = "🔌  Probar Conexión";
            this.btnProbarConexion.UseVisualStyleBackColor = true;
            this.btnProbarConexion.Click += new System.EventHandler(this.btnProbarConexion_Click);
            // 
            // frmFacturacionElectronica
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 773);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(916, 599);
            this.Name = "frmFacturacionElectronica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación Electrónica  —  TusFacturas.app / AFIP";
            this.Load += new System.EventHandler(this.frmFacturacionElectronica_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabEmision.ResumeLayout(false);
            this.tabEmision.PerformLayout();
            this.grpCuitPrueba.ResumeLayout(false);
            this.grpComprobante.ResumeLayout(false);
            this.grpComprobante.PerformLayout();
            this.grpReceptor.ResumeLayout(false);
            this.grpReceptor.PerformLayout();
            this.grpImporte.ResumeLayout(false);
            this.grpImporte.PerformLayout();
            this.grpResumen.ResumeLayout(false);
            this.grpResumen.PerformLayout();
            this.panelResultado.ResumeLayout(false);
            this.panelResultado.PerformLayout();
            this.tabHistorial.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.tabConfiguracion.ResumeLayout(false);
            this.grpEmisor.ResumeLayout(false);
            this.grpEmisor.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
