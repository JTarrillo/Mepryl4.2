namespace CapaPresentacion
{
    partial class frmConfigDictamenAutomatico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigDictamenAutomatico));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.cboClinico = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLaboratorio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboRX = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDictFinal = new System.Windows.Forms.ComboBox();
            this.botCancelar = new System.Windows.Forms.Button();
            this.botGuardar = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clinico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodLab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Laboratorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodRx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodCar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cardiologia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Final = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.botEditar = new System.Windows.Forms.Button();
            this.botEliminar = new System.Windows.Forms.Button();
            this.botSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.MediumBlue;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1295, 40);
            this.lbTitulo.TabIndex = 126;
            this.lbTitulo.Text = "Configuración Dictámen Automático";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboClinico
            // 
            this.cboClinico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboClinico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClinico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClinico.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboClinico.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClinico.FormattingEnabled = true;
            this.cboClinico.Location = new System.Drawing.Point(42, 78);
            this.cboClinico.Name = "cboClinico";
            this.cboClinico.Size = new System.Drawing.Size(433, 32);
            this.cboClinico.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 128;
            this.label1.Text = "Dictámen Clínico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 18);
            this.label2.TabIndex = 130;
            this.label2.Text = "Dictámen Laboratorio";
            // 
            // cboLaboratorio
            // 
            this.cboLaboratorio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboLaboratorio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLaboratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLaboratorio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboLaboratorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLaboratorio.FormattingEnabled = true;
            this.cboLaboratorio.Location = new System.Drawing.Point(42, 134);
            this.cboLaboratorio.Name = "cboLaboratorio";
            this.cboLaboratorio.Size = new System.Drawing.Size(433, 32);
            this.cboLaboratorio.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 132;
            this.label3.Text = "Dictámen RX";
            // 
            // cboRX
            // 
            this.cboRX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboRX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboRX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRX.FormattingEnabled = true;
            this.cboRX.Location = new System.Drawing.Point(42, 190);
            this.cboRX.Name = "cboRX";
            this.cboRX.Size = new System.Drawing.Size(433, 32);
            this.cboRX.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 18);
            this.label4.TabIndex = 134;
            this.label4.Text = "Dictámen Cardiología";
            // 
            // cboCar
            // 
            this.cboCar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboCar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCar.FormattingEnabled = true;
            this.cboCar.Location = new System.Drawing.Point(42, 245);
            this.cboCar.Name = "cboCar";
            this.cboCar.Size = new System.Drawing.Size(433, 32);
            this.cboCar.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 18);
            this.label5.TabIndex = 136;
            this.label5.Text = "Dictámen Final";
            // 
            // cboDictFinal
            // 
            this.cboDictFinal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboDictFinal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDictFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDictFinal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboDictFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDictFinal.FormattingEnabled = true;
            this.cboDictFinal.Location = new System.Drawing.Point(19, 27);
            this.cboDictFinal.Name = "cboDictFinal";
            this.cboDictFinal.Size = new System.Drawing.Size(393, 32);
            this.cboDictFinal.TabIndex = 0;
            // 
            // botCancelar
            // 
            this.botCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botCancelar.Image")));
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(353, 394);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(122, 46);
            this.botCancelar.TabIndex = 6;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = true;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // botGuardar
            // 
            this.botGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botGuardar.Image = ((System.Drawing.Image)(resources.GetObject("botGuardar.Image")));
            this.botGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botGuardar.Location = new System.Drawing.Point(42, 394);
            this.botGuardar.Name = "botGuardar";
            this.botGuardar.Size = new System.Drawing.Size(122, 46);
            this.botGuardar.TabIndex = 5;
            this.botGuardar.Text = "Guardar";
            this.botGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botGuardar.UseVisualStyleBackColor = true;
            this.botGuardar.Click += new System.EventHandler(this.botGuardar_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.CodCli,
            this.Clinico,
            this.CodLab,
            this.Laboratorio,
            this.CodRx,
            this.RX,
            this.CodCar,
            this.Cardiologia,
            this.CodFinal,
            this.Final});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Location = new System.Drawing.Point(501, 78);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(782, 298);
            this.dgv.TabIndex = 139;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // CodCli
            // 
            this.CodCli.HeaderText = "CodCli";
            this.CodCli.Name = "CodCli";
            this.CodCli.ReadOnly = true;
            this.CodCli.Visible = false;
            // 
            // Clinico
            // 
            this.Clinico.HeaderText = "Clinico";
            this.Clinico.Name = "Clinico";
            this.Clinico.ReadOnly = true;
            // 
            // CodLab
            // 
            this.CodLab.HeaderText = "CodLab";
            this.CodLab.Name = "CodLab";
            this.CodLab.ReadOnly = true;
            this.CodLab.Visible = false;
            // 
            // Laboratorio
            // 
            this.Laboratorio.HeaderText = "Laboratorio";
            this.Laboratorio.Name = "Laboratorio";
            this.Laboratorio.ReadOnly = true;
            // 
            // CodRx
            // 
            this.CodRx.HeaderText = "CodRx";
            this.CodRx.Name = "CodRx";
            this.CodRx.ReadOnly = true;
            this.CodRx.Visible = false;
            // 
            // RX
            // 
            this.RX.HeaderText = "RX";
            this.RX.Name = "RX";
            this.RX.ReadOnly = true;
            // 
            // CodCar
            // 
            this.CodCar.HeaderText = "CodCar";
            this.CodCar.Name = "CodCar";
            this.CodCar.ReadOnly = true;
            this.CodCar.Visible = false;
            // 
            // Cardiologia
            // 
            this.Cardiologia.HeaderText = "Cardiologia";
            this.Cardiologia.Name = "Cardiologia";
            this.Cardiologia.ReadOnly = true;
            // 
            // CodFinal
            // 
            this.CodFinal.HeaderText = "CodFinal";
            this.CodFinal.Name = "CodFinal";
            this.CodFinal.ReadOnly = true;
            this.CodFinal.Visible = false;
            // 
            // Final
            // 
            this.Final.HeaderText = "Final";
            this.Final.Name = "Final";
            this.Final.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(498, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 18);
            this.label6.TabIndex = 140;
            this.label6.Text = "Combinaciones Ingresadas";
            // 
            // botEditar
            // 
            this.botEditar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEditar.Image = ((System.Drawing.Image)(resources.GetObject("botEditar.Image")));
            this.botEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEditar.Location = new System.Drawing.Point(500, 394);
            this.botEditar.Name = "botEditar";
            this.botEditar.Size = new System.Drawing.Size(122, 46);
            this.botEditar.TabIndex = 7;
            this.botEditar.Text = "Editar";
            this.botEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEditar.UseVisualStyleBackColor = true;
            this.botEditar.Click += new System.EventHandler(this.botEditar_Click);
            // 
            // botEliminar
            // 
            this.botEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEliminar.Image = ((System.Drawing.Image)(resources.GetObject("botEliminar.Image")));
            this.botEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEliminar.Location = new System.Drawing.Point(628, 394);
            this.botEliminar.Name = "botEliminar";
            this.botEliminar.Size = new System.Drawing.Size(122, 46);
            this.botEliminar.TabIndex = 8;
            this.botEliminar.Text = "Eliminar";
            this.botEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEliminar.UseVisualStyleBackColor = true;
            this.botEliminar.Click += new System.EventHandler(this.botEliminar_Click);
            // 
            // botSalir
            // 
            this.botSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botSalir.Image = ((System.Drawing.Image)(resources.GetObject("botSalir.Image")));
            this.botSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botSalir.Location = new System.Drawing.Point(1161, 394);
            this.botSalir.Name = "botSalir";
            this.botSalir.Size = new System.Drawing.Size(122, 46);
            this.botSalir.TabIndex = 9;
            this.botSalir.Text = "Salir";
            this.botSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botSalir.UseVisualStyleBackColor = true;
            this.botSalir.Click += new System.EventHandler(this.botSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboDictFinal);
            this.panel1.Location = new System.Drawing.Point(42, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 76);
            this.panel1.TabIndex = 4;
            // 
            // frmConfigDictamenAutomatico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 452);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botSalir);
            this.Controls.Add(this.botEliminar);
            this.Controls.Add(this.botEditar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.botCancelar);
            this.Controls.Add(this.botGuardar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboRX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLaboratorio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboClinico);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmConfigDictamenAutomatico";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración Dictámen Automático";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.ComboBox cboClinico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLaboratorio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboRX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDictFinal;
        private System.Windows.Forms.Button botCancelar;
        private System.Windows.Forms.Button botGuardar;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button botEditar;
        private System.Windows.Forms.Button botEliminar;
        private System.Windows.Forms.Button botSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clinico;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodLab;
        private System.Windows.Forms.DataGridViewTextBoxColumn Laboratorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodRx;
        private System.Windows.Forms.DataGridViewTextBoxColumn RX;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cardiologia;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Final;
    }
}