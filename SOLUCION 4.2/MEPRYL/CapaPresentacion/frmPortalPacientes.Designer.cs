namespace CapaPresentacion
{
    partial class frmPortalPacientes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cboTipoPaciente = new System.Windows.Forms.ComboBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.tbBusqueda = new System.Windows.Forms.TextBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.colDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTieneAcceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.btnGenerarAcceso = new System.Windows.Forms.Button();
            this.btnVerCredenciales = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.panelInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(117)))));
            this.panelSuperior.Controls.Add(this.lblBusqueda);
            this.panelSuperior.Controls.Add(this.tbBusqueda);
            this.panelSuperior.Controls.Add(this.lblFiltro);
            this.panelSuperior.Controls.Add(this.cboTipoPaciente);
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(900, 70);
            this.panelSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(230, 25);
            this.lblTitulo.Text = "Portal Pacientes - Accesos";
            // 
            // cboTipoPaciente
            //
            this.cboTipoPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPaciente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoPaciente.Items.AddRange(new object[] { "Todos", "Laboral", "Preventiva" });
            this.cboTipoPaciente.Location = new System.Drawing.Point(340, 22);
            this.cboTipoPaciente.Name = "cboTipoPaciente";
            this.cboTipoPaciente.Size = new System.Drawing.Size(130, 25);
            this.cboTipoPaciente.SelectedIndex = 0;
            this.cboTipoPaciente.SelectedIndexChanged += new System.EventHandler(this.cboTipoPaciente_SelectedIndexChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFiltro.ForeColor = System.Drawing.Color.White;
            this.lblFiltro.Location = new System.Drawing.Point(290, 25);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Text = "Tipo:";
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbBusqueda.Location = new System.Drawing.Point(560, 22);
            this.tbBusqueda.Name = "tbBusqueda";
            this.tbBusqueda.Size = new System.Drawing.Size(320, 25);
            this.tbBusqueda.TextChanged += new System.EventHandler(this.tbBusqueda_TextChanged);
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBusqueda.ForeColor = System.Drawing.Color.White;
            this.lblBusqueda.Location = new System.Drawing.Point(495, 25);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Text = "Buscar:";
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.AllowUserToAddRows = false;
            this.dgvPacientes.AllowUserToDeleteRows = false;
            this.dgvPacientes.AllowUserToResizeRows = false;
            this.dgvPacientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPacientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPacientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colDni, this.colApellido, this.colNombre, this.colTipo,
                this.colTieneAcceso, this.colUsername, this.colPassword });
            this.dgvPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPacientes.Location = new System.Drawing.Point(0, 70);
            this.dgvPacientes.MultiSelect = false;
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.ReadOnly = true;
            this.dgvPacientes.RowHeadersVisible = false;
            this.dgvPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacientes.Size = new System.Drawing.Size(900, 380);
            this.dgvPacientes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvPacientes.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(200, 220, 240);
            this.dgvPacientes.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPacientes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(15, 76, 117);
            this.dgvPacientes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPacientes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvPacientes.EnableHeadersVisualStyles = false;
            // 
            // colDni
            // 
            this.colDni.HeaderText = "DNI";
            this.colDni.Name = "colDni";
            this.colDni.Width = 90;
            // 
            // colApellido
            // 
            this.colApellido.HeaderText = "Apellido";
            this.colApellido.Name = "colApellido";
            this.colApellido.Width = 150;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Width = 150;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.Width = 90;
            // 
            // colTieneAcceso
            // 
            this.colTieneAcceso.HeaderText = "Acceso Portal";
            this.colTieneAcceso.Name = "colTieneAcceso";
            this.colTieneAcceso.Width = 100;
            // 
            // colUsername
            // 
            this.colUsername.HeaderText = "Usuario";
            this.colUsername.Name = "colUsername";
            this.colUsername.Width = 120;
            // 
            // colPassword
            // 
            this.colPassword.HeaderText = "Contraseña";
            this.colPassword.Name = "colPassword";
            this.colPassword.Width = 120;
            // 
            // panelInferior
            // 
            this.panelInferior.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelInferior.Controls.Add(this.lblInfo);
            this.panelInferior.Controls.Add(this.btnCerrar);
            this.panelInferior.Controls.Add(this.btnVerCredenciales);
            this.panelInferior.Controls.Add(this.btnGenerarAcceso);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 450);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(900, 60);
            // 
            // btnGenerarAcceso
            // 
            this.btnGenerarAcceso.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnGenerarAcceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarAcceso.FlatAppearance.BorderSize = 0;
            this.btnGenerarAcceso.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerarAcceso.ForeColor = System.Drawing.Color.White;
            this.btnGenerarAcceso.Location = new System.Drawing.Point(12, 12);
            this.btnGenerarAcceso.Name = "btnGenerarAcceso";
            this.btnGenerarAcceso.Size = new System.Drawing.Size(180, 36);
            this.btnGenerarAcceso.Text = "Generar Acceso";
            this.btnGenerarAcceso.UseVisualStyleBackColor = false;
            this.btnGenerarAcceso.Click += new System.EventHandler(this.btnGenerarAcceso_Click);
            // 
            // btnVerCredenciales
            // 
            this.btnVerCredenciales.BackColor = System.Drawing.Color.FromArgb(15, 76, 117);
            this.btnVerCredenciales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerCredenciales.FlatAppearance.BorderSize = 0;
            this.btnVerCredenciales.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVerCredenciales.ForeColor = System.Drawing.Color.White;
            this.btnVerCredenciales.Location = new System.Drawing.Point(205, 12);
            this.btnVerCredenciales.Name = "btnVerCredenciales";
            this.btnVerCredenciales.Size = new System.Drawing.Size(180, 36);
            this.btnVerCredenciales.Text = "Ver Credenciales";
            this.btnVerCredenciales.UseVisualStyleBackColor = false;
            this.btnVerCredenciales.Click += new System.EventHandler(this.btnVerCredenciales_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(790, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 36);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblInfo.Location = new System.Drawing.Point(400, 22);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Text = "Seleccione un paciente y presione 'Generar Acceso'";
            // 
            // frmPortalPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 510);
            this.Controls.Add(this.dgvPacientes);
            this.Controls.Add(this.panelInferior);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPortalPacientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portal Pacientes - Gestión de Accesos";
            this.Load += new System.EventHandler(this.frmPortalPacientes_Load);
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.panelInferior.ResumeLayout(false);
            this.panelInferior.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cboTipoPaciente;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox tbBusqueda;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTieneAcceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassword;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Button btnGenerarAcceso;
        private System.Windows.Forms.Button btnVerCredenciales;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblInfo;
    }
}
