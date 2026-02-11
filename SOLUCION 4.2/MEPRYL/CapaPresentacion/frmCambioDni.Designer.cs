namespace CapaPresentacion
{
    partial class frmCambioDni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioDni));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbId1 = new System.Windows.Forms.TextBox();
            this.botEliminar1 = new System.Windows.Forms.Button();
            this.tbFechaNacimiento1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.tbNombre1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbApellido1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDni1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbId2 = new System.Windows.Forms.TextBox();
            this.botEliminar2 = new System.Windows.Forms.Button();
            this.tbFechaNacimiento2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.tbNombre2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbApellido2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbDni2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.botIzquierda = new System.Windows.Forms.Button();
            this.botDerecha = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1024, 35);
            this.lbTitulo.TabIndex = 127;
            this.lbTitulo.Text = "Cambio de DNI - Unificación de Historias Clínicas";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbId1);
            this.panel1.Controls.Add(this.botEliminar1);
            this.panel1.Controls.Add(this.tbFechaNacimiento1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dgv1);
            this.panel1.Controls.Add(this.tbNombre1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbApellido1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbDni1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(11, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 450);
            this.panel1.TabIndex = 128;
            // 
            // tbId1
            // 
            this.tbId1.BackColor = System.Drawing.Color.White;
            this.tbId1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbId1.Location = new System.Drawing.Point(287, 26);
            this.tbId1.Name = "tbId1";
            this.tbId1.Size = new System.Drawing.Size(64, 22);
            this.tbId1.TabIndex = 11;
            this.tbId1.Visible = false;
            // 
            // botEliminar1
            // 
            this.botEliminar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEliminar1.Image = ((System.Drawing.Image)(resources.GetObject("botEliminar1.Image")));
            this.botEliminar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEliminar1.Location = new System.Drawing.Point(261, 395);
            this.botEliminar1.Name = "botEliminar1";
            this.botEliminar1.Size = new System.Drawing.Size(180, 47);
            this.botEliminar1.TabIndex = 10;
            this.botEliminar1.Text = "Eliminar Paciente";
            this.botEliminar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEliminar1.UseVisualStyleBackColor = true;
            this.botEliminar1.Click += new System.EventHandler(this.botEliminar1_Click);
            // 
            // tbFechaNacimiento1
            // 
            this.tbFechaNacimiento1.BackColor = System.Drawing.Color.White;
            this.tbFechaNacimiento1.Enabled = false;
            this.tbFechaNacimiento1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFechaNacimiento1.Location = new System.Drawing.Point(167, 26);
            this.tbFechaNacimiento1.Name = "tbFechaNacimiento1";
            this.tbFechaNacimiento1.Size = new System.Drawing.Size(114, 22);
            this.tbFechaNacimiento1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(164, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha Nacimiento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Consultas y Turnos";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.Location = new System.Drawing.Point(9, 182);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(432, 207);
            this.dgv1.TabIndex = 6;
            // 
            // tbNombre1
            // 
            this.tbNombre1.BackColor = System.Drawing.Color.White;
            this.tbNombre1.Enabled = false;
            this.tbNombre1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre1.Location = new System.Drawing.Point(9, 126);
            this.tbNombre1.Name = "tbNombre1";
            this.tbNombre1.Size = new System.Drawing.Size(432, 22);
            this.tbNombre1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombres";
            // 
            // tbApellido1
            // 
            this.tbApellido1.BackColor = System.Drawing.Color.White;
            this.tbApellido1.Enabled = false;
            this.tbApellido1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApellido1.Location = new System.Drawing.Point(9, 76);
            this.tbApellido1.Name = "tbApellido1";
            this.tbApellido1.Size = new System.Drawing.Size(432, 22);
            this.tbApellido1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido";
            // 
            // tbDni1
            // 
            this.tbDni1.BackColor = System.Drawing.Color.White;
            this.tbDni1.Enabled = false;
            this.tbDni1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDni1.Location = new System.Drawing.Point(9, 26);
            this.tbDni1.Name = "tbDni1";
            this.tbDni1.Size = new System.Drawing.Size(152, 22);
            this.tbDni1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNI";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbId2);
            this.panel2.Controls.Add(this.botEliminar2);
            this.panel2.Controls.Add(this.tbFechaNacimiento2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dgv2);
            this.panel2.Controls.Add(this.tbNombre2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tbApellido2);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.tbDni2);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(555, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 450);
            this.panel2.TabIndex = 129;
            // 
            // tbId2
            // 
            this.tbId2.BackColor = System.Drawing.Color.White;
            this.tbId2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbId2.Location = new System.Drawing.Point(287, 26);
            this.tbId2.Name = "tbId2";
            this.tbId2.Size = new System.Drawing.Size(64, 22);
            this.tbId2.TabIndex = 12;
            this.tbId2.Visible = false;
            // 
            // botEliminar2
            // 
            this.botEliminar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEliminar2.Image = ((System.Drawing.Image)(resources.GetObject("botEliminar2.Image")));
            this.botEliminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEliminar2.Location = new System.Drawing.Point(265, 395);
            this.botEliminar2.Name = "botEliminar2";
            this.botEliminar2.Size = new System.Drawing.Size(180, 47);
            this.botEliminar2.TabIndex = 10;
            this.botEliminar2.Text = "Eliminar Paciente";
            this.botEliminar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEliminar2.UseVisualStyleBackColor = true;
            this.botEliminar2.Click += new System.EventHandler(this.botEliminar2_Click);
            // 
            // tbFechaNacimiento2
            // 
            this.tbFechaNacimiento2.BackColor = System.Drawing.Color.White;
            this.tbFechaNacimiento2.Enabled = false;
            this.tbFechaNacimiento2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFechaNacimiento2.Location = new System.Drawing.Point(167, 26);
            this.tbFechaNacimiento2.Name = "tbFechaNacimiento2";
            this.tbFechaNacimiento2.Size = new System.Drawing.Size(114, 22);
            this.tbFechaNacimiento2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(164, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Fecha Nacimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Consultas y Turnos";
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.AllowUserToOrderColumns = true;
            this.dgv2.AllowUserToResizeColumns = false;
            this.dgv2.AllowUserToResizeRows = false;
            this.dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv2.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv2.Location = new System.Drawing.Point(9, 182);
            this.dgv2.Name = "dgv2";
            this.dgv2.ReadOnly = true;
            this.dgv2.RowHeadersVisible = false;
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv2.Size = new System.Drawing.Size(436, 207);
            this.dgv2.TabIndex = 6;
            // 
            // tbNombre2
            // 
            this.tbNombre2.BackColor = System.Drawing.Color.White;
            this.tbNombre2.Enabled = false;
            this.tbNombre2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre2.Location = new System.Drawing.Point(9, 126);
            this.tbNombre2.Name = "tbNombre2";
            this.tbNombre2.Size = new System.Drawing.Size(436, 22);
            this.tbNombre2.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Nombres";
            // 
            // tbApellido2
            // 
            this.tbApellido2.BackColor = System.Drawing.Color.White;
            this.tbApellido2.Enabled = false;
            this.tbApellido2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApellido2.Location = new System.Drawing.Point(9, 76);
            this.tbApellido2.Name = "tbApellido2";
            this.tbApellido2.Size = new System.Drawing.Size(436, 22);
            this.tbApellido2.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Apellido";
            // 
            // tbDni2
            // 
            this.tbDni2.BackColor = System.Drawing.Color.White;
            this.tbDni2.Enabled = false;
            this.tbDni2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDni2.Location = new System.Drawing.Point(9, 26);
            this.tbDni2.Name = "tbDni2";
            this.tbDni2.Size = new System.Drawing.Size(152, 22);
            this.tbDni2.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "DNI";
            // 
            // botIzquierda
            // 
            this.botIzquierda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botIzquierda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botIzquierda.Image = ((System.Drawing.Image)(resources.GetObject("botIzquierda.Image")));
            this.botIzquierda.Location = new System.Drawing.Point(485, 205);
            this.botIzquierda.Name = "botIzquierda";
            this.botIzquierda.Size = new System.Drawing.Size(52, 52);
            this.botIzquierda.TabIndex = 130;
            this.botIzquierda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botIzquierda.UseVisualStyleBackColor = false;
            this.botIzquierda.Click += new System.EventHandler(this.botIzquierda_Click);
            // 
            // botDerecha
            // 
            this.botDerecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.botDerecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botDerecha.Image = ((System.Drawing.Image)(resources.GetObject("botDerecha.Image")));
            this.botDerecha.Location = new System.Drawing.Point(485, 298);
            this.botDerecha.Name = "botDerecha";
            this.botDerecha.Size = new System.Drawing.Size(52, 52);
            this.botDerecha.TabIndex = 131;
            this.botDerecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botDerecha.UseVisualStyleBackColor = false;
            this.botDerecha.Click += new System.EventHandler(this.botDerecha_Click);
            // 
            // frmCambioDni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 512);
            this.Controls.Add(this.botDerecha);
            this.Controls.Add(this.botIzquierda);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambioDni";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbNombre1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbApellido1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDni1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button botEliminar1;
        private System.Windows.Forms.TextBox tbFechaNacimiento1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button botEliminar2;
        private System.Windows.Forms.TextBox tbFechaNacimiento2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.TextBox tbNombre2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbApellido2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbDni2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button botIzquierda;
        private System.Windows.Forms.Button botDerecha;
        private System.Windows.Forms.TextBox tbId1;
        private System.Windows.Forms.TextBox tbId2;
    }
}