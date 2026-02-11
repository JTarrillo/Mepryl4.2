namespace CapaPresentacion
{
    partial class frmTransferenciaLegajos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferenciaLegajos));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.lblPacienteNoEncontrado = new System.Windows.Forms.Label();
            this.dgvBusqueda = new System.Windows.Forms.DataGridView();
            this.botAltaPaciente = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbBusqueda = new System.Windows.Forms.TextBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.tbEmpresaDesde = new System.Windows.Forms.TextBox();
            this.tbPaciente = new System.Windows.Forms.TextBox();
            this.tbEmpresaA = new System.Windows.Forms.TextBox();
            this.tbIdEmpresaDesde = new System.Windows.Forms.TextBox();
            this.tbIdPaciente = new System.Windows.Forms.TextBox();
            this.panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(694, 30);
            this.lbTitulo.TabIndex = 149;
            this.lbTitulo.Text = "Transferencia de Legajos";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Controls.Add(this.lblPacienteNoEncontrado);
            this.panelBusqueda.Controls.Add(this.dgvBusqueda);
            this.panelBusqueda.Controls.Add(this.botAltaPaciente);
            this.panelBusqueda.Controls.Add(this.pictureBox1);
            this.panelBusqueda.Controls.Add(this.tbBusqueda);
            this.panelBusqueda.Location = new System.Drawing.Point(72, 33);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(465, 135);
            this.panelBusqueda.TabIndex = 150;
            // 
            // lblPacienteNoEncontrado
            // 
            this.lblPacienteNoEncontrado.AutoSize = true;
            this.lblPacienteNoEncontrado.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblPacienteNoEncontrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacienteNoEncontrado.ForeColor = System.Drawing.Color.White;
            this.lblPacienteNoEncontrado.Location = new System.Drawing.Point(104, 72);
            this.lblPacienteNoEncontrado.Name = "lblPacienteNoEncontrado";
            this.lblPacienteNoEncontrado.Size = new System.Drawing.Size(245, 16);
            this.lblPacienteNoEncontrado.TabIndex = 133;
            this.lblPacienteNoEncontrado.Text = "¡Registre el Alta para el Paciente !";
            this.lblPacienteNoEncontrado.Visible = false;
            // 
            // dgvBusqueda
            // 
            this.dgvBusqueda.AllowUserToAddRows = false;
            this.dgvBusqueda.AllowUserToDeleteRows = false;
            this.dgvBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBusqueda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusqueda.ColumnHeadersVisible = false;
            this.dgvBusqueda.Location = new System.Drawing.Point(4, 33);
            this.dgvBusqueda.MultiSelect = false;
            this.dgvBusqueda.Name = "dgvBusqueda";
            this.dgvBusqueda.ReadOnly = true;
            this.dgvBusqueda.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBusqueda.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBusqueda.Size = new System.Drawing.Size(458, 99);
            this.dgvBusqueda.TabIndex = 1;
            this.dgvBusqueda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusqueda_CellDoubleClick);
            // 
            // botAltaPaciente
            // 
            this.botAltaPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAltaPaciente.Image = ((System.Drawing.Image)(resources.GetObject("botAltaPaciente.Image")));
            this.botAltaPaciente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAltaPaciente.Location = new System.Drawing.Point(370, 4);
            this.botAltaPaciente.Name = "botAltaPaciente";
            this.botAltaPaciente.Size = new System.Drawing.Size(92, 26);
            this.botAltaPaciente.TabIndex = 132;
            this.botAltaPaciente.Text = "Alta [F2]";
            this.botAltaPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAltaPaciente.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 27);
            this.pictureBox1.TabIndex = 131;
            this.pictureBox1.TabStop = false;
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusqueda.Location = new System.Drawing.Point(38, 6);
            this.tbBusqueda.Name = "tbBusqueda";
            this.tbBusqueda.Size = new System.Drawing.Size(326, 22);
            this.tbBusqueda.TabIndex = 0;
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDe.Location = new System.Drawing.Point(68, 188);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(60, 20);
            this.lblDe.TabIndex = 151;
            this.lblDe.Text = "Desde:";
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPaciente.Location = new System.Drawing.Point(267, 246);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(75, 20);
            this.lblPaciente.TabIndex = 152;
            this.lblPaciente.Text = "Paciente:";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblA.Location = new System.Drawing.Point(486, 188);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(24, 20);
            this.lblA.TabIndex = 153;
            this.lblA.Text = "A:";
            // 
            // tbEmpresaDesde
            // 
            this.tbEmpresaDesde.Location = new System.Drawing.Point(72, 211);
            this.tbEmpresaDesde.Name = "tbEmpresaDesde";
            this.tbEmpresaDesde.Size = new System.Drawing.Size(100, 20);
            this.tbEmpresaDesde.TabIndex = 154;
            this.tbEmpresaDesde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEmpresaDesde_KeyDown);
            this.tbEmpresaDesde.Leave += new System.EventHandler(this.tbEmpresaDesde_Leave);
            // 
            // tbPaciente
            // 
            this.tbPaciente.Location = new System.Drawing.Point(271, 269);
            this.tbPaciente.Name = "tbPaciente";
            this.tbPaciente.Size = new System.Drawing.Size(100, 20);
            this.tbPaciente.TabIndex = 155;
            this.tbPaciente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPaciente_KeyDown);
            this.tbPaciente.Leave += new System.EventHandler(this.tbPaciente_Leave);
            // 
            // tbEmpresaA
            // 
            this.tbEmpresaA.Location = new System.Drawing.Point(490, 211);
            this.tbEmpresaA.Name = "tbEmpresaA";
            this.tbEmpresaA.Size = new System.Drawing.Size(100, 20);
            this.tbEmpresaA.TabIndex = 156;
            this.tbEmpresaA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEmpresaA_KeyDown);
            this.tbEmpresaA.Leave += new System.EventHandler(this.tbEmpresaA_Leave);
            // 
            // tbIdEmpresaDesde
            // 
            this.tbIdEmpresaDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIdEmpresaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdEmpresaDesde.Location = new System.Drawing.Point(72, 237);
            this.tbIdEmpresaDesde.Name = "tbIdEmpresaDesde";
            this.tbIdEmpresaDesde.ReadOnly = true;
            this.tbIdEmpresaDesde.Size = new System.Drawing.Size(37, 22);
            this.tbIdEmpresaDesde.TabIndex = 157;
            this.tbIdEmpresaDesde.Visible = false;
            // 
            // tbIdPaciente
            // 
            this.tbIdPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIdPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdPaciente.Location = new System.Drawing.Point(271, 295);
            this.tbIdPaciente.Name = "tbIdPaciente";
            this.tbIdPaciente.ReadOnly = true;
            this.tbIdPaciente.Size = new System.Drawing.Size(37, 22);
            this.tbIdPaciente.TabIndex = 134;
            this.tbIdPaciente.Visible = false;
            // 
            // frmTransferenciaLegajos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 344);
            this.Controls.Add(this.tbIdPaciente);
            this.Controls.Add(this.tbIdEmpresaDesde);
            this.Controls.Add(this.tbEmpresaA);
            this.Controls.Add(this.tbPaciente);
            this.Controls.Add(this.tbEmpresaDesde);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.lblDe);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.lbTitulo);
            this.Name = "frmTransferenciaLegajos";
            this.Text = "frmTransferenciaLegajos";
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Label lblPacienteNoEncontrado;
        private System.Windows.Forms.DataGridView dgvBusqueda;
        private System.Windows.Forms.Button botAltaPaciente;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbBusqueda;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.TextBox tbEmpresaDesde;
        private System.Windows.Forms.TextBox tbPaciente;
        private System.Windows.Forms.TextBox tbEmpresaA;
        private System.Windows.Forms.TextBox tbIdEmpresaDesde;
        private System.Windows.Forms.TextBox tbIdPaciente;
    }
}