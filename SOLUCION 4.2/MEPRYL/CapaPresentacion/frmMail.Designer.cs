namespace CapaPresentacion
{
    partial class frmMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDestinatarios = new System.Windows.Forms.DataGridView();
            this.Destinatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.botAddDestinatario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDestinatario = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvArchivosAdjuntos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.botAddArchivoAdjunto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.botEnviar = new System.Windows.Forms.Button();
            this.botCancelar = new System.Windows.Forms.Button();
            this.tbMensaje = new System.Windows.Forms.TextBox();
            this.tbAsunto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestinatarios)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivosAdjuntos)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.ForestGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(651, 40);
            this.lbTitulo.TabIndex = 128;
            this.lbTitulo.Text = "Mail";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvDestinatarios);
            this.panel1.Controls.Add(this.botAddDestinatario);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbDestinatario);
            this.panel1.Location = new System.Drawing.Point(5, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 228);
            this.panel1.TabIndex = 129;
            // 
            // dgvDestinatarios
            // 
            this.dgvDestinatarios.AllowUserToAddRows = false;
            this.dgvDestinatarios.AllowUserToDeleteRows = false;
            this.dgvDestinatarios.AllowUserToOrderColumns = true;
            this.dgvDestinatarios.AllowUserToResizeColumns = false;
            this.dgvDestinatarios.AllowUserToResizeRows = false;
            this.dgvDestinatarios.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDestinatarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDestinatarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Destinatario,
            this.Eliminar});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDestinatarios.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDestinatarios.Location = new System.Drawing.Point(6, 48);
            this.dgvDestinatarios.MultiSelect = false;
            this.dgvDestinatarios.Name = "dgvDestinatarios";
            this.dgvDestinatarios.ReadOnly = true;
            this.dgvDestinatarios.RowHeadersVisible = false;
            this.dgvDestinatarios.Size = new System.Drawing.Size(302, 171);
            this.dgvDestinatarios.TabIndex = 3;
            this.dgvDestinatarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDestinatarios_CellClick);
            // 
            // Destinatario
            // 
            this.Destinatario.HeaderText = "Destinatario";
            this.Destinatario.Name = "Destinatario";
            this.Destinatario.ReadOnly = true;
            this.Destinatario.Width = 249;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Eliminar.Image")));
            this.Eliminar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Width = 50;
            // 
            // botAddDestinatario
            // 
            this.botAddDestinatario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botAddDestinatario.BackgroundImage")));
            this.botAddDestinatario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botAddDestinatario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botAddDestinatario.Location = new System.Drawing.Point(284, 23);
            this.botAddDestinatario.Name = "botAddDestinatario";
            this.botAddDestinatario.Size = new System.Drawing.Size(24, 22);
            this.botAddDestinatario.TabIndex = 2;
            this.botAddDestinatario.UseVisualStyleBackColor = true;
            this.botAddDestinatario.Click += new System.EventHandler(this.botAddDestinatario_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Destinatario";
            // 
            // tbDestinatario
            // 
            this.tbDestinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDestinatario.Location = new System.Drawing.Point(6, 23);
            this.tbDestinatario.Name = "tbDestinatario";
            this.tbDestinatario.Size = new System.Drawing.Size(275, 22);
            this.tbDestinatario.TabIndex = 0;
            this.tbDestinatario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDestinatario_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvArchivosAdjuntos);
            this.panel2.Controls.Add(this.botAddArchivoAdjunto);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(327, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 228);
            this.panel2.TabIndex = 130;
            // 
            // dgvArchivosAdjuntos
            // 
            this.dgvArchivosAdjuntos.AllowUserToAddRows = false;
            this.dgvArchivosAdjuntos.AllowUserToDeleteRows = false;
            this.dgvArchivosAdjuntos.AllowUserToOrderColumns = true;
            this.dgvArchivosAdjuntos.AllowUserToResizeColumns = false;
            this.dgvArchivosAdjuntos.AllowUserToResizeRows = false;
            this.dgvArchivosAdjuntos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvArchivosAdjuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchivosAdjuntos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewImageColumn1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArchivosAdjuntos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArchivosAdjuntos.Location = new System.Drawing.Point(6, 48);
            this.dgvArchivosAdjuntos.MultiSelect = false;
            this.dgvArchivosAdjuntos.Name = "dgvArchivosAdjuntos";
            this.dgvArchivosAdjuntos.ReadOnly = true;
            this.dgvArchivosAdjuntos.RowHeadersVisible = false;
            this.dgvArchivosAdjuntos.Size = new System.Drawing.Size(302, 171);
            this.dgvArchivosAdjuntos.TabIndex = 3;
            this.dgvArchivosAdjuntos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArchivosAdjuntos_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Archivo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 249;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Eliminar";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // botAddArchivoAdjunto
            // 
            this.botAddArchivoAdjunto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botAddArchivoAdjunto.BackgroundImage")));
            this.botAddArchivoAdjunto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botAddArchivoAdjunto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botAddArchivoAdjunto.Location = new System.Drawing.Point(284, 23);
            this.botAddArchivoAdjunto.Name = "botAddArchivoAdjunto";
            this.botAddArchivoAdjunto.Size = new System.Drawing.Size(24, 22);
            this.botAddArchivoAdjunto.TabIndex = 2;
            this.botAddArchivoAdjunto.UseVisualStyleBackColor = true;
            this.botAddArchivoAdjunto.Click += new System.EventHandler(this.botAddArchivoAdjunto_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Archivos Adjuntos";
            // 
            // botEnviar
            // 
            this.botEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEnviar.Image = ((System.Drawing.Image)(resources.GetObject("botEnviar.Image")));
            this.botEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEnviar.Location = new System.Drawing.Point(531, 449);
            this.botEnviar.Name = "botEnviar";
            this.botEnviar.Size = new System.Drawing.Size(112, 54);
            this.botEnviar.TabIndex = 131;
            this.botEnviar.Text = "Enviar";
            this.botEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEnviar.UseVisualStyleBackColor = true;
            this.botEnviar.Click += new System.EventHandler(this.botEnviar_Click);
            // 
            // botCancelar
            // 
            this.botCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botCancelar.Image")));
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(5, 449);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(112, 54);
            this.botCancelar.TabIndex = 132;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = true;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // tbMensaje
            // 
            this.tbMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMensaje.Location = new System.Drawing.Point(5, 346);
            this.tbMensaje.Multiline = true;
            this.tbMensaje.Name = "tbMensaje";
            this.tbMensaje.Size = new System.Drawing.Size(638, 97);
            this.tbMensaje.TabIndex = 133;
            // 
            // tbAsunto
            // 
            this.tbAsunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAsunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAsunto.Location = new System.Drawing.Point(5, 296);
            this.tbAsunto.Name = "tbAsunto";
            this.tbAsunto.Size = new System.Drawing.Size(638, 22);
            this.tbAsunto.TabIndex = 134;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 135;
            this.label3.Text = "Asunto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 136;
            this.label4.Text = "Mensaje";
            // 
            // frmMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 508);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbAsunto);
            this.Controls.Add(this.tbMensaje);
            this.Controls.Add(this.botCancelar);
            this.Controls.Add(this.botEnviar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Mail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestinatarios)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivosAdjuntos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button botAddDestinatario;
        private System.Windows.Forms.TextBox tbDestinatario;
        private System.Windows.Forms.DataGridView dgvDestinatarios;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvArchivosAdjuntos;
        private System.Windows.Forms.Button botAddArchivoAdjunto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botEnviar;
        private System.Windows.Forms.Button botCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destinatario;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.TextBox tbMensaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAsunto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}