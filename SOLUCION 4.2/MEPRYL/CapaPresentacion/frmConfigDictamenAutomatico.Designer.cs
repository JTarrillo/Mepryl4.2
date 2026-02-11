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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRX = new System.Windows.Forms.Button();
            this.btnDictamen = new System.Windows.Forms.Button();
            this.btnValidaciones = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cboDictFinal = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1110, 25);
            this.lbTitulo.TabIndex = 126;
            this.lbTitulo.Text = "   Configuración Dictámen Automático";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboClinico
            // 
            this.cboClinico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboClinico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClinico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClinico.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboClinico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClinico.FormattingEnabled = true;
            this.cboClinico.Location = new System.Drawing.Point(16, 127);
            this.cboClinico.Name = "cboClinico";
            this.cboClinico.Size = new System.Drawing.Size(299, 24);
            this.cboClinico.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 128;
            this.label1.Text = "Dictámen Clínico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 130;
            this.label2.Text = "Dictámen Laboratorio";
            // 
            // cboLaboratorio
            // 
            this.cboLaboratorio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboLaboratorio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLaboratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLaboratorio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboLaboratorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLaboratorio.FormattingEnabled = true;
            this.cboLaboratorio.Location = new System.Drawing.Point(16, 183);
            this.cboLaboratorio.Name = "cboLaboratorio";
            this.cboLaboratorio.Size = new System.Drawing.Size(299, 24);
            this.cboLaboratorio.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 132;
            this.label3.Text = "Dictámen RX";
            // 
            // cboRX
            // 
            this.cboRX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboRX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboRX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRX.FormattingEnabled = true;
            this.cboRX.Location = new System.Drawing.Point(16, 239);
            this.cboRX.Name = "cboRX";
            this.cboRX.Size = new System.Drawing.Size(299, 24);
            this.cboRX.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 16);
            this.label4.TabIndex = 134;
            this.label4.Text = "Dictámen Cardiología";
            // 
            // cboCar
            // 
            this.cboCar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboCar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCar.FormattingEnabled = true;
            this.cboCar.Location = new System.Drawing.Point(16, 294);
            this.cboCar.Name = "cboCar";
            this.cboCar.Size = new System.Drawing.Size(299, 24);
            this.cboCar.TabIndex = 3;
            // 
            // botCancelar
            // 
            this.botCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.botCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botCancelar.Image")));
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(11, 137);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(120, 45);
            this.botCancelar.TabIndex = 6;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = true;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // botGuardar
            // 
            this.botGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.botGuardar.Image = ((System.Drawing.Image)(resources.GetObject("botGuardar.Image")));
            this.botGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botGuardar.Location = new System.Drawing.Point(11, 35);
            this.botGuardar.Name = "botGuardar";
            this.botGuardar.Size = new System.Drawing.Size(120, 45);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Location = new System.Drawing.Point(6, 24);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(774, 350);
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
            this.Clinico.Width = 153;
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
            this.Laboratorio.Width = 154;
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
            this.RX.Width = 154;
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
            this.Cardiologia.Width = 155;
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
            this.Final.Width = 155;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 16);
            this.label6.TabIndex = 140;
            this.label6.Text = "Combinaciones Ingresadas";
            // 
            // botEditar
            // 
            this.botEditar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.botEditar.Image = ((System.Drawing.Image)(resources.GetObject("botEditar.Image")));
            this.botEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEditar.Location = new System.Drawing.Point(11, 86);
            this.botEditar.Name = "botEditar";
            this.botEditar.Size = new System.Drawing.Size(120, 45);
            this.botEditar.TabIndex = 7;
            this.botEditar.Text = "Editar";
            this.botEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEditar.UseVisualStyleBackColor = true;
            this.botEditar.Click += new System.EventHandler(this.botEditar_Click);
            // 
            // botEliminar
            // 
            this.botEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.botEliminar.Image = ((System.Drawing.Image)(resources.GetObject("botEliminar.Image")));
            this.botEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEliminar.Location = new System.Drawing.Point(11, 190);
            this.botEliminar.Name = "botEliminar";
            this.botEliminar.Size = new System.Drawing.Size(120, 45);
            this.botEliminar.TabIndex = 8;
            this.botEliminar.Text = "Eliminar";
            this.botEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEliminar.UseVisualStyleBackColor = true;
            this.botEliminar.Click += new System.EventHandler(this.botEliminar_Click);
            // 
            // botSalir
            // 
            this.botSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.botSalir.Image = ((System.Drawing.Image)(resources.GetObject("botSalir.Image")));
            this.botSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botSalir.Location = new System.Drawing.Point(11, 329);
            this.botSalir.Name = "botSalir";
            this.botSalir.Size = new System.Drawing.Size(120, 45);
            this.botSalir.TabIndex = 9;
            this.botSalir.Text = "Salir";
            this.botSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botSalir.UseVisualStyleBackColor = true;
            this.botSalir.Visible = false;
            this.botSalir.Click += new System.EventHandler(this.botSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(356, 330);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(43, 50);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnRX);
            this.panel3.Controls.Add(this.btnDictamen);
            this.panel3.Controls.Add(this.btnValidaciones);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1110, 50);
            this.panel3.TabIndex = 321;
            // 
            // btnRX
            // 
            this.btnRX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRX.Location = new System.Drawing.Point(362, 10);
            this.btnRX.Name = "btnRX";
            this.btnRX.Size = new System.Drawing.Size(69, 28);
            this.btnRX.TabIndex = 2;
            this.btnRX.Text = "RX";
            this.btnRX.UseVisualStyleBackColor = true;
            this.btnRX.Click += new System.EventHandler(this.btnRX_Click);
            // 
            // btnDictamen
            // 
            this.btnDictamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDictamen.Location = new System.Drawing.Point(154, 10);
            this.btnDictamen.Name = "btnDictamen";
            this.btnDictamen.Size = new System.Drawing.Size(202, 28);
            this.btnDictamen.TabIndex = 1;
            this.btnDictamen.Text = "Dictamenes Automaticos";
            this.btnDictamen.UseVisualStyleBackColor = true;
            this.btnDictamen.Click += new System.EventHandler(this.btnDictamen_Click);
            // 
            // btnValidaciones
            // 
            this.btnValidaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidaciones.Location = new System.Drawing.Point(28, 10);
            this.btnValidaciones.Name = "btnValidaciones";
            this.btnValidaciones.Size = new System.Drawing.Size(120, 28);
            this.btnValidaciones.TabIndex = 0;
            this.btnValidaciones.Text = "Validaciones";
            this.btnValidaciones.UseVisualStyleBackColor = true;
            this.btnValidaciones.Click += new System.EventHandler(this.btnValidaciones_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.botGuardar);
            this.panel2.Controls.Add(this.botEditar);
            this.panel2.Controls.Add(this.botCancelar);
            this.panel2.Controls.Add(this.botEliminar);
            this.panel2.Controls.Add(this.botSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1110, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 509);
            this.panel2.TabIndex = 322;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.dgv);
            this.panel4.Location = new System.Drawing.Point(325, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(783, 377);
            this.panel4.TabIndex = 323;
            // 
            // cboDictFinal
            // 
            this.cboDictFinal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboDictFinal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDictFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDictFinal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboDictFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDictFinal.FormattingEnabled = true;
            this.cboDictFinal.Location = new System.Drawing.Point(16, 347);
            this.cboDictFinal.Name = "cboDictFinal";
            this.cboDictFinal.Size = new System.Drawing.Size(299, 24);
            this.cboDictFinal.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(29, 432);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 45);
            this.groupBox1.TabIndex = 141;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dictámen Final";
            this.groupBox1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 324;
            this.label5.Text = "Dictámen Final";
            // 
            // frmConfigDictamenAutomatico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 509);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboDictFinal);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboRX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLaboratorio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboClinico);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmConfigDictamenAutomatico";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dictámen Automático";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.Button botCancelar;
        private System.Windows.Forms.Button botGuardar;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button botEditar;
        private System.Windows.Forms.Button botEliminar;
        private System.Windows.Forms.Button botSalir;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRX;
        private System.Windows.Forms.Button btnDictamen;
        private System.Windows.Forms.Button btnValidaciones;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboDictFinal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
    }
}