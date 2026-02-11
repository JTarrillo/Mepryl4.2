namespace CapaPresentacion
{
    partial class frmExportacionCompleta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportacionCompleta));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.tpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTodas = new System.Windows.Forms.CheckBox();
            this.tpCategoriaHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tpCategoriaDesde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboClub = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboLiga = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.botComenzar = new System.Windows.Forms.Button();
            this.botAbrirUbicacion = new System.Windows.Forms.Button();
            this.tbUbicacion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblTarea = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbAcotada = new System.Windows.Forms.RadioButton();
            this.rbCompleta = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cboDictamen = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.DarkOrange;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(449, 40);
            this.lbTitulo.TabIndex = 126;
            this.lbTitulo.Text = "Exportaciones a Medida";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpFechaDesde
            // 
            this.tpFechaDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFechaDesde.CalendarTitleBackColor = System.Drawing.Color.MediumBlue;
            this.tpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpFechaDesde.Location = new System.Drawing.Point(52, 15);
            this.tpFechaDesde.Name = "tpFechaDesde";
            this.tpFechaDesde.Size = new System.Drawing.Size(123, 26);
            this.tpFechaDesde.TabIndex = 133;
            this.tpFechaDesde.Value = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 132;
            this.label3.Text = "Desde";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tpFechaHasta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tpFechaDesde);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 48);
            this.groupBox1.TabIndex = 134;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha";
            // 
            // tpFechaHasta
            // 
            this.tpFechaHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFechaHasta.CalendarTitleBackColor = System.Drawing.Color.MediumBlue;
            this.tpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpFechaHasta.Location = new System.Drawing.Point(293, 15);
            this.tpFechaHasta.Name = "tpFechaHasta";
            this.tpFechaHasta.Size = new System.Drawing.Size(123, 26);
            this.tpFechaHasta.TabIndex = 135;
            this.tpFechaHasta.Value = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 134;
            this.label1.Text = "Hasta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTodas);
            this.groupBox2.Controls.Add(this.tpCategoriaHasta);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tpCategoriaDesde);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 65);
            this.groupBox2.TabIndex = 135;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Categoria";
            // 
            // cbTodas
            // 
            this.cbTodas.AutoSize = true;
            this.cbTodas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTodas.Location = new System.Drawing.Point(178, 40);
            this.cbTodas.Name = "cbTodas";
            this.cbTodas.Size = new System.Drawing.Size(72, 24);
            this.cbTodas.TabIndex = 136;
            this.cbTodas.Text = "Todas";
            this.cbTodas.UseVisualStyleBackColor = true;
            this.cbTodas.CheckedChanged += new System.EventHandler(this.cbTodas_CheckedChanged);
            // 
            // tpCategoriaHasta
            // 
            this.tpCategoriaHasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpCategoriaHasta.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue;
            this.tpCategoriaHasta.CustomFormat = "yyyy";
            this.tpCategoriaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpCategoriaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tpCategoriaHasta.Location = new System.Drawing.Point(293, 17);
            this.tpCategoriaHasta.Name = "tpCategoriaHasta";
            this.tpCategoriaHasta.ShowUpDown = true;
            this.tpCategoriaHasta.Size = new System.Drawing.Size(123, 26);
            this.tpCategoriaHasta.TabIndex = 135;
            this.tpCategoriaHasta.Value = new System.DateTime(2006, 12, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(247, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 134;
            this.label2.Text = "Hasta";
            // 
            // tpCategoriaDesde
            // 
            this.tpCategoriaDesde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpCategoriaDesde.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue;
            this.tpCategoriaDesde.CustomFormat = "yyyy";
            this.tpCategoriaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpCategoriaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tpCategoriaDesde.Location = new System.Drawing.Point(52, 17);
            this.tpCategoriaDesde.Name = "tpCategoriaDesde";
            this.tpCategoriaDesde.ShowUpDown = true;
            this.tpCategoriaDesde.Size = new System.Drawing.Size(123, 26);
            this.tpCategoriaDesde.TabIndex = 133;
            this.tpCategoriaDesde.Value = new System.DateTime(2000, 12, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 132;
            this.label4.Text = "Desde";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboClub);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cboLiga);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 113);
            this.groupBox3.TabIndex = 136;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Liga y Club";
            // 
            // cboClub
            // 
            this.cboClub.BackColor = System.Drawing.SystemColors.Control;
            this.cboClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClub.FormattingEnabled = true;
            this.cboClub.Location = new System.Drawing.Point(52, 70);
            this.cboClub.Name = "cboClub";
            this.cboClub.Size = new System.Drawing.Size(364, 28);
            this.cboClub.TabIndex = 135;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 15);
            this.label5.TabIndex = 134;
            this.label5.Text = "Club";
            // 
            // cboLiga
            // 
            this.cboLiga.BackColor = System.Drawing.SystemColors.Control;
            this.cboLiga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLiga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLiga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLiga.FormattingEnabled = true;
            this.cboLiga.Location = new System.Drawing.Point(52, 27);
            this.cboLiga.Name = "cboLiga";
            this.cboLiga.Size = new System.Drawing.Size(364, 28);
            this.cboLiga.TabIndex = 133;
            this.cboLiga.SelectedValueChanged += new System.EventHandler(this.cboLiga_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 132;
            this.label6.Text = "Liga";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.botComenzar);
            this.groupBox4.Controls.Add(this.botAbrirUbicacion);
            this.groupBox4.Controls.Add(this.tbUbicacion);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(13, 400);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(422, 91);
            this.groupBox4.TabIndex = 137;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Exportación Excel";
            // 
            // botComenzar
            // 
            this.botComenzar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botComenzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botComenzar.Location = new System.Drawing.Point(145, 59);
            this.botComenzar.Name = "botComenzar";
            this.botComenzar.Size = new System.Drawing.Size(141, 22);
            this.botComenzar.TabIndex = 10;
            this.botComenzar.Text = "Comenzar";
            this.botComenzar.UseVisualStyleBackColor = true;
            this.botComenzar.Click += new System.EventHandler(this.botComenzar_Click);
            // 
            // botAbrirUbicacion
            // 
            this.botAbrirUbicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botAbrirUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAbrirUbicacion.Location = new System.Drawing.Point(375, 31);
            this.botAbrirUbicacion.Name = "botAbrirUbicacion";
            this.botAbrirUbicacion.Size = new System.Drawing.Size(41, 22);
            this.botAbrirUbicacion.TabIndex = 9;
            this.botAbrirUbicacion.Text = "...";
            this.botAbrirUbicacion.UseVisualStyleBackColor = true;
            this.botAbrirUbicacion.Click += new System.EventHandler(this.botAbrirUbicacion_Click);
            // 
            // tbUbicacion
            // 
            this.tbUbicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUbicacion.Location = new System.Drawing.Point(74, 31);
            this.tbUbicacion.Name = "tbUbicacion";
            this.tbUbicacion.ReadOnly = true;
            this.tbUbicacion.Size = new System.Drawing.Size(295, 22);
            this.tbUbicacion.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ubicación";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.DarkOrange;
            this.progressBar.Location = new System.Drawing.Point(13, 511);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(422, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 138;
            this.progressBar.Visible = false;
            // 
            // lblTarea
            // 
            this.lblTarea.AutoSize = true;
            this.lblTarea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarea.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTarea.Location = new System.Drawing.Point(12, 538);
            this.lblTarea.Name = "lblTarea";
            this.lblTarea.Size = new System.Drawing.Size(301, 18);
            this.lblTarea.TabIndex = 139;
            this.lblTarea.Text = "CONSULTANDO BASE DE DATOS......";
            this.lblTarea.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkOrange;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(405, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 40);
            this.pictureBox1.TabIndex = 140;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbAcotada);
            this.groupBox5.Controls.Add(this.rbCompleta);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(13, 346);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(422, 51);
            this.groupBox5.TabIndex = 141;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tipo";
            // 
            // rbAcotada
            // 
            this.rbAcotada.AutoSize = true;
            this.rbAcotada.Checked = true;
            this.rbAcotada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAcotada.Location = new System.Drawing.Point(88, 17);
            this.rbAcotada.Name = "rbAcotada";
            this.rbAcotada.Size = new System.Drawing.Size(87, 24);
            this.rbAcotada.TabIndex = 1;
            this.rbAcotada.TabStop = true;
            this.rbAcotada.Text = "Acotada";
            this.rbAcotada.UseVisualStyleBackColor = true;
            // 
            // rbCompleta
            // 
            this.rbCompleta.AutoSize = true;
            this.rbCompleta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCompleta.Location = new System.Drawing.Point(250, 17);
            this.rbCompleta.Name = "rbCompleta";
            this.rbCompleta.Size = new System.Drawing.Size(95, 24);
            this.rbCompleta.TabIndex = 0;
            this.rbCompleta.Text = "Completa";
            this.rbCompleta.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cboDictamen);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(13, 289);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(422, 51);
            this.groupBox6.TabIndex = 142;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Dictámen Final";
            // 
            // cboDictamen
            // 
            this.cboDictamen.BackColor = System.Drawing.SystemColors.Control;
            this.cboDictamen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDictamen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDictamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDictamen.FormattingEnabled = true;
            this.cboDictamen.Location = new System.Drawing.Point(52, 17);
            this.cboDictamen.Name = "cboDictamen";
            this.cboDictamen.Size = new System.Drawing.Size(364, 28);
            this.cboDictamen.TabIndex = 136;
            // 
            // frmExportacionCompleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 567);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTarea);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExportacionCompleta";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportaciones a Medida";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.DateTimePicker tpFechaDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker tpFechaHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker tpCategoriaHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker tpCategoriaDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboClub;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboLiga;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button botAbrirUbicacion;
        private System.Windows.Forms.TextBox tbUbicacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button botComenzar;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox cbTodas;
        private System.Windows.Forms.Label lblTarea;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbAcotada;
        private System.Windows.Forms.RadioButton rbCompleta;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cboDictamen;
    }
}