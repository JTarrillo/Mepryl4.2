namespace CapaPresentacion
{
    partial class frmConfigReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigReportes));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lblFaltanCargar = new System.Windows.Forms.Panel();
            this.botCancelar = new System.Windows.Forms.Button();
            this.botAceptar = new System.Windows.Forms.Button();
            this.tbLogo = new System.Windows.Forms.TextBox();
            this.botFLLogo = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbFirma = new System.Windows.Forms.PictureBox();
            this.botFLFirma = new System.Windows.Forms.Button();
            this.tbFirma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbProfesional = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMatricula = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCargo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPiePagina = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.rbPreventCaratula = new System.Windows.Forms.RadioButton();
            this.rbPrevLaborat = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbHistoriaClinica = new System.Windows.Forms.RadioButton();
            this.rbConsultorio = new System.Windows.Forms.RadioButton();
            this.rbExAptitudOlivera = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rbExAptitud = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLibroYFolio = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbGuardarReporte = new System.Windows.Forms.TextBox();
            this.botFLReporte = new System.Windows.Forms.Button();
            this.botFLExportar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tbExportarReporte = new System.Windows.Forms.TextBox();
            this.lblFaltanCargar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirma)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(819, 40);
            this.lbTitulo.TabIndex = 126;
            this.lbTitulo.Text = "Configuración de Reportes";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFaltanCargar
            // 
            this.lblFaltanCargar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblFaltanCargar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFaltanCargar.Controls.Add(this.botCancelar);
            this.lblFaltanCargar.Controls.Add(this.botAceptar);
            this.lblFaltanCargar.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFaltanCargar.Location = new System.Drawing.Point(680, 40);
            this.lblFaltanCargar.Name = "lblFaltanCargar";
            this.lblFaltanCargar.Size = new System.Drawing.Size(139, 598);
            this.lblFaltanCargar.TabIndex = 127;
            // 
            // botCancelar
            // 
            this.botCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botCancelar.Image")));
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(8, 162);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(123, 36);
            this.botCancelar.TabIndex = 271;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = false;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // botAceptar
            // 
            this.botAceptar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAceptar.Image = ((System.Drawing.Image)(resources.GetObject("botAceptar.Image")));
            this.botAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAceptar.Location = new System.Drawing.Point(8, 120);
            this.botAceptar.Name = "botAceptar";
            this.botAceptar.Size = new System.Drawing.Size(123, 36);
            this.botAceptar.TabIndex = 270;
            this.botAceptar.Text = "Aceptar";
            this.botAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAceptar.UseVisualStyleBackColor = false;
            this.botAceptar.Click += new System.EventHandler(this.botAceptar_Click);
            // 
            // tbLogo
            // 
            this.tbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLogo.Location = new System.Drawing.Point(12, 167);
            this.tbLogo.Name = "tbLogo";
            this.tbLogo.Size = new System.Drawing.Size(387, 26);
            this.tbLogo.TabIndex = 128;
            this.tbLogo.Text = "C:\\Users\\carlos\\Pictures\\LogoTipo01.jpg";
            this.tbLogo.TextChanged += new System.EventHandler(this.tbLogo_TextChanged);
            // 
            // botFLLogo
            // 
            this.botFLLogo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botFLLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botFLLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFLLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botFLLogo.Location = new System.Drawing.Point(405, 167);
            this.botFLLogo.Name = "botFLLogo";
            this.botFLLogo.Size = new System.Drawing.Size(38, 26);
            this.botFLLogo.TabIndex = 272;
            this.botFLLogo.Text = "...";
            this.botFLLogo.UseVisualStyleBackColor = false;
            this.botFLLogo.Click += new System.EventHandler(this.botFLLogo_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogo.ImageLocation = "C:\\Users\\carlos\\Pictures\\LogoTipo01.jpg";
            this.pbLogo.Location = new System.Drawing.Point(461, 153);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(178, 53);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 273;
            this.pbLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 274;
            this.label1.Text = "Logo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 278;
            this.label2.Text = "Firma";
            // 
            // pbFirma
            // 
            this.pbFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFirma.Location = new System.Drawing.Point(461, 212);
            this.pbFirma.Name = "pbFirma";
            this.pbFirma.Size = new System.Drawing.Size(71, 71);
            this.pbFirma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFirma.TabIndex = 277;
            this.pbFirma.TabStop = false;
            // 
            // botFLFirma
            // 
            this.botFLFirma.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botFLFirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botFLFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFLFirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botFLFirma.Location = new System.Drawing.Point(405, 233);
            this.botFLFirma.Name = "botFLFirma";
            this.botFLFirma.Size = new System.Drawing.Size(38, 26);
            this.botFLFirma.TabIndex = 276;
            this.botFLFirma.Text = "...";
            this.botFLFirma.UseVisualStyleBackColor = false;
            this.botFLFirma.Click += new System.EventHandler(this.botFLFirma_Click);
            // 
            // tbFirma
            // 
            this.tbFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFirma.Location = new System.Drawing.Point(12, 233);
            this.tbFirma.Name = "tbFirma";
            this.tbFirma.Size = new System.Drawing.Size(387, 26);
            this.tbFirma.TabIndex = 275;
            this.tbFirma.Text = "C:\\Users\\carlos\\Pictures\\firma-transp.jpg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 280;
            this.label3.Text = "Profesional";
            // 
            // tbProfesional
            // 
            this.tbProfesional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbProfesional.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProfesional.Location = new System.Drawing.Point(12, 294);
            this.tbProfesional.Name = "tbProfesional";
            this.tbProfesional.Size = new System.Drawing.Size(387, 26);
            this.tbProfesional.TabIndex = 279;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 282;
            this.label4.Text = "Matricula";
            // 
            // tbMatricula
            // 
            this.tbMatricula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatricula.Location = new System.Drawing.Point(12, 341);
            this.tbMatricula.Name = "tbMatricula";
            this.tbMatricula.Size = new System.Drawing.Size(387, 26);
            this.tbMatricula.TabIndex = 281;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 284;
            this.label5.Text = "Cargo";
            // 
            // tbCargo
            // 
            this.tbCargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCargo.Location = new System.Drawing.Point(12, 389);
            this.tbCargo.Name = "tbCargo";
            this.tbCargo.Size = new System.Drawing.Size(387, 26);
            this.tbCargo.TabIndex = 283;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 473);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 286;
            this.label6.Text = "Pie de Página";
            // 
            // tbPiePagina
            // 
            this.tbPiePagina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPiePagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPiePagina.Location = new System.Drawing.Point(12, 492);
            this.tbPiePagina.Name = "tbPiePagina";
            this.tbPiePagina.Size = new System.Drawing.Size(627, 26);
            this.tbPiePagina.TabIndex = 285;
            // 
            // rbPreventCaratula
            // 
            this.rbPreventCaratula.AutoSize = true;
            this.rbPreventCaratula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbPreventCaratula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPreventCaratula.Location = new System.Drawing.Point(16, 27);
            this.rbPreventCaratula.Name = "rbPreventCaratula";
            this.rbPreventCaratula.Size = new System.Drawing.Size(83, 20);
            this.rbPreventCaratula.TabIndex = 287;
            this.rbPreventCaratula.TabStop = true;
            this.rbPreventCaratula.Text = "Carátula";
            this.rbPreventCaratula.UseVisualStyleBackColor = true;
            this.rbPreventCaratula.CheckedChanged += new System.EventHandler(this.rbPreventCaratula_CheckedChanged);
            // 
            // rbPrevLaborat
            // 
            this.rbPrevLaborat.AutoSize = true;
            this.rbPrevLaborat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbPrevLaborat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPrevLaborat.Location = new System.Drawing.Point(16, 53);
            this.rbPrevLaborat.Name = "rbPrevLaborat";
            this.rbPrevLaborat.Size = new System.Drawing.Size(176, 20);
            this.rbPrevLaborat.TabIndex = 288;
            this.rbPrevLaborat.TabStop = true;
            this.rbPrevLaborat.Text = "Protocolo Laboratorio";
            this.rbPrevLaborat.UseVisualStyleBackColor = true;
            this.rbPrevLaborat.CheckedChanged += new System.EventHandler(this.rbPrevLaborat_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbHistoriaClinica);
            this.panel1.Controls.Add(this.rbConsultorio);
            this.panel1.Controls.Add(this.rbExAptitudOlivera);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.rbExAptitud);
            this.panel1.Controls.Add(this.rbPrevLaborat);
            this.panel1.Controls.Add(this.rbPreventCaratula);
            this.panel1.Location = new System.Drawing.Point(12, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 83);
            this.panel1.TabIndex = 289;
            // 
            // rbHistoriaClinica
            // 
            this.rbHistoriaClinica.AutoSize = true;
            this.rbHistoriaClinica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbHistoriaClinica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHistoriaClinica.Location = new System.Drawing.Point(488, 52);
            this.rbHistoriaClinica.Name = "rbHistoriaClinica";
            this.rbHistoriaClinica.Size = new System.Drawing.Size(130, 20);
            this.rbHistoriaClinica.TabIndex = 291;
            this.rbHistoriaClinica.TabStop = true;
            this.rbHistoriaClinica.Text = "Historia Clinica";
            this.rbHistoriaClinica.UseVisualStyleBackColor = true;
            this.rbHistoriaClinica.CheckedChanged += new System.EventHandler(this.rbHistoriaClinica_CheckedChanged);
            // 
            // rbConsultorio
            // 
            this.rbConsultorio.AutoSize = true;
            this.rbConsultorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbConsultorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbConsultorio.Location = new System.Drawing.Point(488, 26);
            this.rbConsultorio.Name = "rbConsultorio";
            this.rbConsultorio.Size = new System.Drawing.Size(111, 20);
            this.rbConsultorio.TabIndex = 290;
            this.rbConsultorio.TabStop = true;
            this.rbConsultorio.Text = "Consultorios";
            this.rbConsultorio.UseVisualStyleBackColor = true;
            this.rbConsultorio.CheckedChanged += new System.EventHandler(this.rbConsultorio_CheckedChanged);
            // 
            // rbExAptitudOlivera
            // 
            this.rbExAptitudOlivera.AutoSize = true;
            this.rbExAptitudOlivera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbExAptitudOlivera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbExAptitudOlivera.Location = new System.Drawing.Point(316, 53);
            this.rbExAptitudOlivera.Name = "rbExAptitudOlivera";
            this.rbExAptitudOlivera.Size = new System.Drawing.Size(152, 20);
            this.rbExAptitudOlivera.TabIndex = 289;
            this.rbExAptitudOlivera.TabStop = true;
            this.rbExAptitudOlivera.Text = "Ex. Aptitud Olivera";
            this.rbExAptitudOlivera.UseVisualStyleBackColor = true;
            this.rbExAptitudOlivera.CheckedChanged += new System.EventHandler(this.rbExAptitudOlivera_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(299, -1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 275;
            this.label8.Text = "Laboral";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 275;
            this.label7.Text = "Preventiva";
            // 
            // rbExAptitud
            // 
            this.rbExAptitud.AutoSize = true;
            this.rbExAptitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbExAptitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbExAptitud.Location = new System.Drawing.Point(316, 26);
            this.rbExAptitud.Name = "rbExAptitud";
            this.rbExAptitud.Size = new System.Drawing.Size(98, 20);
            this.rbExAptitud.TabIndex = 287;
            this.rbExAptitud.TabStop = true;
            this.rbExAptitud.Text = "Ex. Aptitud";
            this.rbExAptitud.UseVisualStyleBackColor = true;
            this.rbExAptitud.CheckedChanged += new System.EventHandler(this.rbExAptitud_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 421);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 15);
            this.label9.TabIndex = 291;
            this.label9.Text = "Libro y Folio";
            // 
            // tbLibroYFolio
            // 
            this.tbLibroYFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLibroYFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLibroYFolio.Location = new System.Drawing.Point(12, 440);
            this.tbLibroYFolio.Name = "tbLibroYFolio";
            this.tbLibroYFolio.Size = new System.Drawing.Size(387, 26);
            this.tbLibroYFolio.TabIndex = 290;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 526);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 15);
            this.label10.TabIndex = 293;
            this.label10.Text = "Guardar reportes";
            // 
            // tbGuardarReporte
            // 
            this.tbGuardarReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGuardarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGuardarReporte.Location = new System.Drawing.Point(12, 545);
            this.tbGuardarReporte.Name = "tbGuardarReporte";
            this.tbGuardarReporte.Size = new System.Drawing.Size(583, 26);
            this.tbGuardarReporte.TabIndex = 292;
            // 
            // botFLReporte
            // 
            this.botFLReporte.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botFLReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botFLReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFLReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botFLReporte.Location = new System.Drawing.Point(601, 545);
            this.botFLReporte.Name = "botFLReporte";
            this.botFLReporte.Size = new System.Drawing.Size(38, 26);
            this.botFLReporte.TabIndex = 294;
            this.botFLReporte.Text = "...";
            this.botFLReporte.UseVisualStyleBackColor = false;
            this.botFLReporte.Click += new System.EventHandler(this.botFLReporte_Click);
            // 
            // botFLExportar
            // 
            this.botFLExportar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botFLExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botFLExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFLExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botFLExportar.Location = new System.Drawing.Point(601, 599);
            this.botFLExportar.Name = "botFLExportar";
            this.botFLExportar.Size = new System.Drawing.Size(38, 26);
            this.botFLExportar.TabIndex = 297;
            this.botFLExportar.Text = "...";
            this.botFLExportar.UseVisualStyleBackColor = false;
            this.botFLExportar.Click += new System.EventHandler(this.botFLExportar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 580);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 15);
            this.label11.TabIndex = 296;
            this.label11.Text = "Directorio para exportar";
            // 
            // tbExportarReporte
            // 
            this.tbExportarReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbExportarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExportarReporte.Location = new System.Drawing.Point(12, 599);
            this.tbExportarReporte.Name = "tbExportarReporte";
            this.tbExportarReporte.Size = new System.Drawing.Size(583, 26);
            this.tbExportarReporte.TabIndex = 295;
            // 
            // frmConfigReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 638);
            this.Controls.Add(this.botFLExportar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbExportarReporte);
            this.Controls.Add(this.botFLReporte);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbGuardarReporte);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbLibroYFolio);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPiePagina);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbCargo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMatricula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbProfesional);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbFirma);
            this.Controls.Add(this.botFLFirma);
            this.Controls.Add(this.tbFirma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.botFLLogo);
            this.Controls.Add(this.tbLogo);
            this.Controls.Add(this.lblFaltanCargar);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigReportes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de Reportes";
            this.lblFaltanCargar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirma)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        protected System.Windows.Forms.Panel lblFaltanCargar;
        protected System.Windows.Forms.Button botAceptar;
        protected System.Windows.Forms.Button botCancelar;
        private System.Windows.Forms.TextBox tbLogo;
        protected System.Windows.Forms.Button botFLLogo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbFirma;
        protected System.Windows.Forms.Button botFLFirma;
        private System.Windows.Forms.TextBox tbFirma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbProfesional;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMatricula;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCargo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPiePagina;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.RadioButton rbPreventCaratula;
        private System.Windows.Forms.RadioButton rbPrevLaborat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbExAptitud;
        private System.Windows.Forms.RadioButton rbExAptitudOlivera;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbLibroYFolio;
        private System.Windows.Forms.RadioButton rbConsultorio;
        private System.Windows.Forms.RadioButton rbHistoriaClinica;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbGuardarReporte;
        protected System.Windows.Forms.Button botFLReporte;
        protected System.Windows.Forms.Button botFLExportar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbExportarReporte;
    }
}