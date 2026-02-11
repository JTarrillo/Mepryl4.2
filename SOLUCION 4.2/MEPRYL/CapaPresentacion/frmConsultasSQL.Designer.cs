namespace CapaPresentacion
{
    partial class frmConsultasSQL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultasSQL));
            this.pnlConsulta = new System.Windows.Forms.Panel();
            this.txtConsultaSQL = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlResultadoSQL = new System.Windows.Forms.Panel();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnListarTablas = new System.Windows.Forms.Button();
            this.pnlMenuLateral = new System.Windows.Forms.Panel();
            this.butExportarListado = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.btnColumnasTablas = new System.Windows.Forms.Button();
            this.pnlConsulta.SuspendLayout();
            this.pnlResultadoSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlMenuLateral.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConsulta
            // 
            this.pnlConsulta.Controls.Add(this.txtConsultaSQL);
            this.pnlConsulta.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConsulta.Location = new System.Drawing.Point(0, 25);
            this.pnlConsulta.Name = "pnlConsulta";
            this.pnlConsulta.Size = new System.Drawing.Size(780, 168);
            this.pnlConsulta.TabIndex = 0;
            // 
            // txtConsultaSQL
            // 
            this.txtConsultaSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsultaSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsultaSQL.Location = new System.Drawing.Point(0, 0);
            this.txtConsultaSQL.Name = "txtConsultaSQL";
            this.txtConsultaSQL.Size = new System.Drawing.Size(780, 168);
            this.txtConsultaSQL.TabIndex = 0;
            this.txtConsultaSQL.Text = "";
            this.txtConsultaSQL.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.txtConsultaSQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConsultaSQL_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Brown;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(919, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Consultas SQL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlResultadoSQL
            // 
            this.pnlResultadoSQL.Controls.Add(this.dgvResultado);
            this.pnlResultadoSQL.Controls.Add(this.panel1);
            this.pnlResultadoSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultadoSQL.Location = new System.Drawing.Point(0, 193);
            this.pnlResultadoSQL.Name = "pnlResultadoSQL";
            this.pnlResultadoSQL.Size = new System.Drawing.Size(780, 300);
            this.pnlResultadoSQL.TabIndex = 4;
            // 
            // dgvResultado
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResultado.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultado.Location = new System.Drawing.Point(0, 56);
            this.dgvResultado.Name = "dgvResultado";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultado.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvResultado.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvResultado.Size = new System.Drawing.Size(780, 244);
            this.dgvResultado.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnColumnasTablas);
            this.panel1.Controls.Add(this.btnListarTablas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 56);
            this.panel1.TabIndex = 1;
            // 
            // btnListarTablas
            // 
            this.btnListarTablas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarTablas.Location = new System.Drawing.Point(11, 5);
            this.btnListarTablas.Name = "btnListarTablas";
            this.btnListarTablas.Size = new System.Drawing.Size(114, 45);
            this.btnListarTablas.TabIndex = 0;
            this.btnListarTablas.Text = "Ver tablas";
            this.btnListarTablas.UseVisualStyleBackColor = true;
            this.btnListarTablas.Click += new System.EventHandler(this.btnListarTablas_Click);
            // 
            // pnlMenuLateral
            // 
            this.pnlMenuLateral.Controls.Add(this.butExportarListado);
            this.pnlMenuLateral.Controls.Add(this.button1);
            this.pnlMenuLateral.Controls.Add(this.btnGuardar);
            this.pnlMenuLateral.Controls.Add(this.btnEjecutar);
            this.pnlMenuLateral.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenuLateral.Location = new System.Drawing.Point(780, 25);
            this.pnlMenuLateral.Name = "pnlMenuLateral";
            this.pnlMenuLateral.Size = new System.Drawing.Size(139, 468);
            this.pnlMenuLateral.TabIndex = 5;
            // 
            // butExportarListado
            // 
            this.butExportarListado.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butExportarListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExportarListado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.butExportarListado.Image = ((System.Drawing.Image)(resources.GetObject("butExportarListado.Image")));
            this.butExportarListado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExportarListado.Location = new System.Drawing.Point(7, 135);
            this.butExportarListado.Name = "butExportarListado";
            this.butExportarListado.Size = new System.Drawing.Size(120, 45);
            this.butExportarListado.TabIndex = 263;
            this.butExportarListado.Text = "Exportar\r\nListado";
            this.butExportarListado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExportarListado.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(7, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Salir";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(7, 72);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 45);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("btnEjecutar.Image")));
            this.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEjecutar.Location = new System.Drawing.Point(7, 12);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(120, 45);
            this.btnEjecutar.TabIndex = 0;
            this.btnEjecutar.Text = "Ejecutar\r\n[F5]";
            this.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnColumnasTablas
            // 
            this.btnColumnasTablas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColumnasTablas.Location = new System.Drawing.Point(145, 5);
            this.btnColumnasTablas.Name = "btnColumnasTablas";
            this.btnColumnasTablas.Size = new System.Drawing.Size(161, 45);
            this.btnColumnasTablas.TabIndex = 1;
            this.btnColumnasTablas.Text = "Ver Columnas tabla";
            this.btnColumnasTablas.UseVisualStyleBackColor = true;
            this.btnColumnasTablas.Click += new System.EventHandler(this.btnColumnasTablas_Click);
            // 
            // frmConsultasSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 493);
            this.Controls.Add(this.pnlResultadoSQL);
            this.Controls.Add(this.pnlConsulta);
            this.Controls.Add(this.pnlMenuLateral);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "frmConsultasSQL";
            this.ShowIcon = false;
            this.Text = "Consultas SQL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConsultasSQL_Load);
            this.pnlConsulta.ResumeLayout(false);
            this.pnlResultadoSQL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlMenuLateral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlResultadoSQL;
        private System.Windows.Forms.Panel pnlMenuLateral;
        private System.Windows.Forms.RichTextBox txtConsultaSQL;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnListarTablas;
        private System.Windows.Forms.Button button1;
        protected System.Windows.Forms.Button butExportarListado;
        private System.Windows.Forms.Button btnColumnasTablas;
    }
}