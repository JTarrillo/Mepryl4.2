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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblFaltanCargar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirma)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.Maroon;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1049, 30);
            this.lbTitulo.TabIndex = 126;
            this.lbTitulo.Text = "Configuración de Reportes";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFaltanCargar
            // 
            this.lblFaltanCargar.BackColor = System.Drawing.SystemColors.Control;
            this.lblFaltanCargar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFaltanCargar.Controls.Add(this.botCancelar);
            this.lblFaltanCargar.Controls.Add(this.botAceptar);
            this.lblFaltanCargar.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFaltanCargar.Location = new System.Drawing.Point(910, 30);
            this.lblFaltanCargar.Name = "lblFaltanCargar";
            this.lblFaltanCargar.Size = new System.Drawing.Size(139, 608);
            this.lblFaltanCargar.TabIndex = 127;
            // 
            // botCancelar
            // 
            this.botCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botCancelar.Image = ((System.Drawing.Image)(resources.GetObject("botCancelar.Image")));
            this.botCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botCancelar.Location = new System.Drawing.Point(8, 116);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(123, 45);
            this.botCancelar.TabIndex = 271;
            this.botCancelar.Text = "Cancelar";
            this.botCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botCancelar.UseVisualStyleBackColor = false;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // botAceptar
            // 
            this.botAceptar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAceptar.Image = ((System.Drawing.Image)(resources.GetObject("botAceptar.Image")));
            this.botAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAceptar.Location = new System.Drawing.Point(8, 39);
            this.botAceptar.Name = "botAceptar";
            this.botAceptar.Size = new System.Drawing.Size(123, 45);
            this.botAceptar.TabIndex = 270;
            this.botAceptar.Text = "Aceptar";
            this.botAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAceptar.UseVisualStyleBackColor = false;
            this.botAceptar.Click += new System.EventHandler(this.botAceptar_Click);
            // 
            // tbLogo
            // 
            this.tbLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLogo.Location = new System.Drawing.Point(6, 131);
            this.tbLogo.Name = "tbLogo";
            this.tbLogo.Size = new System.Drawing.Size(600, 22);
            this.tbLogo.TabIndex = 128;
            this.tbLogo.Text = "C:\\Users\\carlos\\Pictures\\LogoTipo01.jpg";
            this.tbLogo.TextChanged += new System.EventHandler(this.tbLogo_TextChanged);
            // 
            // botFLLogo
            // 
            this.botFLLogo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botFLLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFLLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botFLLogo.Location = new System.Drawing.Point(615, 131);
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
            this.pbLogo.Location = new System.Drawing.Point(676, 117);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(178, 53);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 273;
            this.pbLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 274;
            this.label1.Text = "Logo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 278;
            this.label2.Text = "Firma";
            // 
            // pbFirma
            // 
            this.pbFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFirma.Location = new System.Drawing.Point(676, 176);
            this.pbFirma.Name = "pbFirma";
            this.pbFirma.Size = new System.Drawing.Size(71, 71);
            this.pbFirma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFirma.TabIndex = 277;
            this.pbFirma.TabStop = false;
            // 
            // botFLFirma
            // 
            this.botFLFirma.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botFLFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFLFirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botFLFirma.Location = new System.Drawing.Point(615, 197);
            this.botFLFirma.Name = "botFLFirma";
            this.botFLFirma.Size = new System.Drawing.Size(38, 26);
            this.botFLFirma.TabIndex = 276;
            this.botFLFirma.Text = "...";
            this.botFLFirma.UseVisualStyleBackColor = false;
            this.botFLFirma.Click += new System.EventHandler(this.botFLFirma_Click);
            // 
            // tbFirma
            // 
            this.tbFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFirma.Location = new System.Drawing.Point(6, 197);
            this.tbFirma.Name = "tbFirma";
            this.tbFirma.Size = new System.Drawing.Size(600, 22);
            this.tbFirma.TabIndex = 275;
            this.tbFirma.Text = "C:\\Users\\carlos\\Pictures\\firma-transp.jpg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 280;
            this.label3.Text = "Profesional";
            // 
            // tbProfesional
            // 
            this.tbProfesional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProfesional.Location = new System.Drawing.Point(6, 258);
            this.tbProfesional.Name = "tbProfesional";
            this.tbProfesional.Size = new System.Drawing.Size(600, 22);
            this.tbProfesional.TabIndex = 279;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 282;
            this.label4.Text = "Matricula";
            // 
            // tbMatricula
            // 
            this.tbMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatricula.Location = new System.Drawing.Point(6, 305);
            this.tbMatricula.Name = "tbMatricula";
            this.tbMatricula.Size = new System.Drawing.Size(600, 22);
            this.tbMatricula.TabIndex = 281;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 284;
            this.label5.Text = "Cargo";
            // 
            // tbCargo
            // 
            this.tbCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCargo.Location = new System.Drawing.Point(6, 353);
            this.tbCargo.Name = "tbCargo";
            this.tbCargo.Size = new System.Drawing.Size(600, 22);
            this.tbCargo.TabIndex = 283;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 286;
            this.label6.Text = "Pie de Página";
            // 
            // tbPiePagina
            // 
            this.tbPiePagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPiePagina.Location = new System.Drawing.Point(6, 456);
            this.tbPiePagina.Name = "tbPiePagina";
            this.tbPiePagina.Size = new System.Drawing.Size(600, 22);
            this.tbPiePagina.TabIndex = 285;
            // 
            // rbPreventCaratula
            // 
            this.rbPreventCaratula.AutoSize = true;
            this.rbPreventCaratula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbPreventCaratula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPreventCaratula.Location = new System.Drawing.Point(45, 44);
            this.rbPreventCaratula.Name = "rbPreventCaratula";
            this.rbPreventCaratula.Size = new System.Drawing.Size(75, 20);
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
            this.rbPrevLaborat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPrevLaborat.Location = new System.Drawing.Point(45, 70);
            this.rbPrevLaborat.Name = "rbPrevLaborat";
            this.rbPrevLaborat.Size = new System.Drawing.Size(155, 20);
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
            this.panel1.Location = new System.Drawing.Point(792, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(53, 57);
            this.panel1.TabIndex = 289;
            this.panel1.Visible = false;
            // 
            // rbHistoriaClinica
            // 
            this.rbHistoriaClinica.AutoSize = true;
            this.rbHistoriaClinica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbHistoriaClinica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHistoriaClinica.Location = new System.Drawing.Point(612, 70);
            this.rbHistoriaClinica.Name = "rbHistoriaClinica";
            this.rbHistoriaClinica.Size = new System.Drawing.Size(114, 20);
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
            this.rbConsultorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbConsultorio.Location = new System.Drawing.Point(612, 44);
            this.rbConsultorio.Name = "rbConsultorio";
            this.rbConsultorio.Size = new System.Drawing.Size(99, 20);
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
            this.rbExAptitudOlivera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbExAptitudOlivera.Location = new System.Drawing.Point(345, 70);
            this.rbExAptitudOlivera.Name = "rbExAptitudOlivera";
            this.rbExAptitudOlivera.Size = new System.Drawing.Size(133, 20);
            this.rbExAptitudOlivera.TabIndex = 289;
            this.rbExAptitudOlivera.TabStop = true;
            this.rbExAptitudOlivera.Text = "Ex. Aptitud Olivera";
            this.rbExAptitudOlivera.UseVisualStyleBackColor = true;
            this.rbExAptitudOlivera.CheckedChanged += new System.EventHandler(this.rbExAptitudOlivera_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(328, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 275;
            this.label8.Text = "Laboral";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 275;
            this.label7.Text = "Preventiva";
            // 
            // rbExAptitud
            // 
            this.rbExAptitud.AutoSize = true;
            this.rbExAptitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbExAptitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbExAptitud.Location = new System.Drawing.Point(345, 44);
            this.rbExAptitud.Name = "rbExAptitud";
            this.rbExAptitud.Size = new System.Drawing.Size(87, 20);
            this.rbExAptitud.TabIndex = 287;
            this.rbExAptitud.TabStop = true;
            this.rbExAptitud.Text = "Ex. Aptitud";
            this.rbExAptitud.UseVisualStyleBackColor = true;
            this.rbExAptitud.CheckedChanged += new System.EventHandler(this.rbExAptitud_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 385);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 291;
            this.label9.Text = "Libro y Folio";
            // 
            // tbLibroYFolio
            // 
            this.tbLibroYFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLibroYFolio.Location = new System.Drawing.Point(6, 404);
            this.tbLibroYFolio.Name = "tbLibroYFolio";
            this.tbLibroYFolio.Size = new System.Drawing.Size(600, 22);
            this.tbLibroYFolio.TabIndex = 290;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 490);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 16);
            this.label10.TabIndex = 293;
            this.label10.Text = "Guardar reportes";
            // 
            // tbGuardarReporte
            // 
            this.tbGuardarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGuardarReporte.Location = new System.Drawing.Point(6, 509);
            this.tbGuardarReporte.Name = "tbGuardarReporte";
            this.tbGuardarReporte.Size = new System.Drawing.Size(600, 22);
            this.tbGuardarReporte.TabIndex = 292;
            // 
            // botFLReporte
            // 
            this.botFLReporte.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.botFLReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFLReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botFLReporte.Location = new System.Drawing.Point(615, 509);
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
            this.botFLExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFLExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botFLExportar.Location = new System.Drawing.Point(615, 563);
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
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 544);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 16);
            this.label11.TabIndex = 296;
            this.label11.Text = "Directorio para exportar";
            // 
            // tbExportarReporte
            // 
            this.tbExportarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExportarReporte.Location = new System.Drawing.Point(6, 563);
            this.tbExportarReporte.Name = "tbExportarReporte";
            this.tbExportarReporte.Size = new System.Drawing.Size(600, 22);
            this.tbExportarReporte.TabIndex = 295;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(910, 608);
            this.panel2.TabIndex = 298;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.tbCargo);
            this.panel3.Controls.Add(this.botFLExportar);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.tbLogo);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.tbMatricula);
            this.panel3.Controls.Add(this.botFLLogo);
            this.panel3.Controls.Add(this.tbPiePagina);
            this.panel3.Controls.Add(this.tbExportarReporte);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pbLogo);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.botFLReporte);
            this.panel3.Controls.Add(this.tbProfesional);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.tbLibroYFolio);
            this.panel3.Controls.Add(this.tbFirma);
            this.panel3.Controls.Add(this.pbFirma);
            this.panel3.Controls.Add(this.tbGuardarReporte);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.botFLFirma);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(910, 608);
            this.panel3.TabIndex = 299;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.rbHistoriaClinica);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.rbPreventCaratula);
            this.groupBox1.Controls.Add(this.rbConsultorio);
            this.groupBox1.Controls.Add(this.rbPrevLaborat);
            this.groupBox1.Controls.Add(this.rbExAptitudOlivera);
            this.groupBox1.Controls.Add(this.rbExAptitud);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(851, 100);
            this.groupBox1.TabIndex = 298;
            this.groupBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(595, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 16);
            this.label12.TabIndex = 299;
            this.label12.Text = "Otros";
            // 
            // frmConfigReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 638);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblFaltanCargar);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmConfigReportes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de Reportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.lblFaltanCargar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirma)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
    }
}