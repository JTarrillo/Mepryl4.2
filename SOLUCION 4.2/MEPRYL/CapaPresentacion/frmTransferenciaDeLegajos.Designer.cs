namespace CapaPresentacion
{
    partial class frmTransferenciaDeLegajos
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
            this.lblIdEmpresaDesde = new System.Windows.Forms.Label();
            this.btnTransferir = new System.Windows.Forms.Button();
            this.tbBusqueda = new System.Windows.Forms.TextBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lblIdPaciente = new System.Windows.Forms.Label();
            this.lblIdEmpresaA = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.tbEmpresaA = new System.Windows.Forms.TextBox();
            this.tbPaciente = new System.Windows.Forms.TextBox();
            this.tbEmpresaDesde = new System.Windows.Forms.TextBox();
            this.dgvBusquedaGeneral = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusquedaGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIdEmpresaDesde
            // 
            this.lblIdEmpresaDesde.AutoSize = true;
            this.lblIdEmpresaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblIdEmpresaDesde.Location = new System.Drawing.Point(14, 80);
            this.lblIdEmpresaDesde.Name = "lblIdEmpresaDesde";
            this.lblIdEmpresaDesde.Size = new System.Drawing.Size(0, 20);
            this.lblIdEmpresaDesde.TabIndex = 7;
            // 
            // btnTransferir
            // 
            this.btnTransferir.Location = new System.Drawing.Point(508, 289);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(112, 33);
            this.btnTransferir.TabIndex = 144;
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.UseVisualStyleBackColor = true;
            this.btnTransferir.Click += new System.EventHandler(this.btnTransferir_Click);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Location = new System.Drawing.Point(131, 140);
            this.tbBusqueda.Name = "tbBusqueda";
            this.tbBusqueda.Size = new System.Drawing.Size(355, 20);
            this.tbBusqueda.TabIndex = 143;
            this.tbBusqueda.TextChanged += new System.EventHandler(this.tbBusqueda_TextChanged);
            this.tbBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBusqueda_KeyPress);
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SeaGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(630, 25);
            this.lbTitulo.TabIndex = 142;
            this.lbTitulo.Text = " Transferencia de Legajos";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIdPaciente
            // 
            this.lblIdPaciente.AutoSize = true;
            this.lblIdPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblIdPaciente.Location = new System.Drawing.Point(218, 121);
            this.lblIdPaciente.Name = "lblIdPaciente";
            this.lblIdPaciente.Size = new System.Drawing.Size(0, 20);
            this.lblIdPaciente.TabIndex = 141;
            // 
            // lblIdEmpresaA
            // 
            this.lblIdEmpresaA.AutoSize = true;
            this.lblIdEmpresaA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblIdEmpresaA.Location = new System.Drawing.Point(440, 86);
            this.lblIdEmpresaA.Name = "lblIdEmpresaA";
            this.lblIdEmpresaA.Size = new System.Drawing.Size(0, 20);
            this.lblIdEmpresaA.TabIndex = 140;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(14, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 139;
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblA.Location = new System.Drawing.Point(416, 40);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(147, 18);
            this.lblA.TabIndex = 138;
            this.lblA.Text = "Empresa de Destino:";
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblPaciente.Location = new System.Drawing.Point(219, 75);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(69, 18);
            this.lblPaciente.TabIndex = 137;
            this.lblPaciente.Text = "Paciente:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblDesde.Location = new System.Drawing.Point(14, 40);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(140, 18);
            this.lblDesde.TabIndex = 136;
            this.lblDesde.Text = "Empresa de Origen:";
            // 
            // tbEmpresaA
            // 
            this.tbEmpresaA.Location = new System.Drawing.Point(420, 63);
            this.tbEmpresaA.Name = "tbEmpresaA";
            this.tbEmpresaA.Size = new System.Drawing.Size(200, 20);
            this.tbEmpresaA.TabIndex = 135;
            this.tbEmpresaA.Enter += new System.EventHandler(this.tbEmpresaA_Enter);
            this.tbEmpresaA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEmpresaA_KeyDown);
            this.tbEmpresaA.Leave += new System.EventHandler(this.tbEmpresaA_Leave);
            // 
            // tbPaciente
            // 
            this.tbPaciente.Location = new System.Drawing.Point(222, 98);
            this.tbPaciente.Name = "tbPaciente";
            this.tbPaciente.Size = new System.Drawing.Size(200, 20);
            this.tbPaciente.TabIndex = 134;
            this.tbPaciente.Enter += new System.EventHandler(this.tbPaciente_Enter);
            this.tbPaciente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPaciente_KeyDown);
            this.tbPaciente.Leave += new System.EventHandler(this.tbPaciente_Leave);
            // 
            // tbEmpresaDesde
            // 
            this.tbEmpresaDesde.Location = new System.Drawing.Point(18, 63);
            this.tbEmpresaDesde.Name = "tbEmpresaDesde";
            this.tbEmpresaDesde.Size = new System.Drawing.Size(195, 20);
            this.tbEmpresaDesde.TabIndex = 133;
            this.tbEmpresaDesde.Enter += new System.EventHandler(this.tbEmpresaDesde_Enter);
            this.tbEmpresaDesde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEmpresaDesde_KeyDown);
            this.tbEmpresaDesde.Leave += new System.EventHandler(this.tbEmpresaDesde_Leave);
            // 
            // dgvBusquedaGeneral
            // 
            this.dgvBusquedaGeneral.AllowUserToAddRows = false;
            this.dgvBusquedaGeneral.AllowUserToDeleteRows = false;
            this.dgvBusquedaGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusquedaGeneral.Location = new System.Drawing.Point(131, 166);
            this.dgvBusquedaGeneral.MultiSelect = false;
            this.dgvBusquedaGeneral.Name = "dgvBusquedaGeneral";
            this.dgvBusquedaGeneral.ReadOnly = true;
            this.dgvBusquedaGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBusquedaGeneral.Size = new System.Drawing.Size(355, 156);
            this.dgvBusquedaGeneral.TabIndex = 1;
            this.dgvBusquedaGeneral.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusquedaGeneral_CellDoubleClick);
            this.dgvBusquedaGeneral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBusquedaGeneral_KeyDown);
            this.dgvBusquedaGeneral.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvBusquedaGeneral_KeyPress);
            // 
            // frmTransferenciaDeLegajos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 328);
            this.Controls.Add(this.btnTransferir);
            this.Controls.Add(this.tbBusqueda);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lblIdPaciente);
            this.Controls.Add(this.lblIdEmpresaA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.tbEmpresaA);
            this.Controls.Add(this.tbPaciente);
            this.Controls.Add(this.tbEmpresaDesde);
            this.Controls.Add(this.dgvBusquedaGeneral);
            this.Controls.Add(this.lblIdEmpresaDesde);
            this.Name = "frmTransferenciaDeLegajos";
            this.Text = "frmTransferenciaDeLegajos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusquedaGeneral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblIdEmpresaDesde;
        private System.Windows.Forms.Button btnTransferir;
        private System.Windows.Forms.TextBox tbBusqueda;
        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lblIdPaciente;
        private System.Windows.Forms.Label lblIdEmpresaA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.TextBox tbEmpresaA;
        private System.Windows.Forms.TextBox tbPaciente;
        private System.Windows.Forms.TextBox tbEmpresaDesde;
        private System.Windows.Forms.DataGridView dgvBusquedaGeneral;
    }
}