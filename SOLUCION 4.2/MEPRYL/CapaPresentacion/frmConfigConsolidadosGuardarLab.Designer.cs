namespace CapaPresentacion
{
    partial class frmConfigConsolidadosGuardarLab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigConsolidadosGuardarLab));
            this.lblFaltanCargar = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.tpExportacionDesde = new System.Windows.Forms.DateTimePicker();
            this.lblNombreFirma = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNombreFirma = new System.Windows.Forms.TextBox();
            this.txtGuardaConsolidado = new System.Windows.Forms.TextBox();
            this.lblNombreLogo = new System.Windows.Forms.Label();
            this.btnPreventiva = new System.Windows.Forms.Button();
            this.tbNombreLogo = new System.Windows.Forms.TextBox();
            this.tbDireccionArchivosPDF = new System.Windows.Forms.TextBox();
            this.lblDirectorioPDF = new System.Windows.Forms.Label();
            this.btnArchivosPDF = new System.Windows.Forms.Button();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDirectorio = new System.Windows.Forms.Button();
            this.btnArchivosConsolidar = new System.Windows.Forms.Button();
            this.btnPlantillas = new System.Windows.Forms.Button();
            this.btnFotos = new System.Windows.Forms.Button();
            this.lblFaltanCargar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFaltanCargar
            // 
            this.lblFaltanCargar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblFaltanCargar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFaltanCargar.Controls.Add(this.btnCancelar);
            this.lblFaltanCargar.Controls.Add(this.btnAceptar);
            this.lblFaltanCargar.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFaltanCargar.Location = new System.Drawing.Point(827, 25);
            this.lblFaltanCargar.Name = "lblFaltanCargar";
            this.lblFaltanCargar.Size = new System.Drawing.Size(139, 348);
            this.lblFaltanCargar.TabIndex = 278;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(8, 114);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 45);
            this.btnCancelar.TabIndex = 271;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(8, 51);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 45);
            this.btnAceptar.TabIndex = 270;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.tpExportacionDesde);
            this.panel1.Controls.Add(this.lblNombreFirma);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbNombreFirma);
            this.panel1.Controls.Add(this.txtGuardaConsolidado);
            this.panel1.Controls.Add(this.lblNombreLogo);
            this.panel1.Controls.Add(this.btnPreventiva);
            this.panel1.Controls.Add(this.tbNombreLogo);
            this.panel1.Controls.Add(this.tbDireccionArchivosPDF);
            this.panel1.Controls.Add(this.lblDirectorioPDF);
            this.panel1.Controls.Add(this.btnArchivosPDF);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 298);
            this.panel1.TabIndex = 279;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(12, 168);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(191, 16);
            this.lblFecha.TabIndex = 329;
            this.lblFecha.Text = "Fecha Inicial de Exportaciones";
            // 
            // tpExportacionDesde
            // 
            this.tpExportacionDesde.CalendarMonthBackground = System.Drawing.Color.White;
            this.tpExportacionDesde.CalendarTitleBackColor = System.Drawing.Color.SeaGreen;
            this.tpExportacionDesde.CalendarTitleForeColor = System.Drawing.Color.White;
            this.tpExportacionDesde.CalendarTrailingForeColor = System.Drawing.Color.White;
            this.tpExportacionDesde.CustomFormat = "yyyy";
            this.tpExportacionDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpExportacionDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tpExportacionDesde.Location = new System.Drawing.Point(15, 188);
            this.tpExportacionDesde.Name = "tpExportacionDesde";
            this.tpExportacionDesde.Size = new System.Drawing.Size(110, 22);
            this.tpExportacionDesde.TabIndex = 328;
            this.tpExportacionDesde.Value = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            // 
            // lblNombreFirma
            // 
            this.lblNombreFirma.AutoSize = true;
            this.lblNombreFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreFirma.Location = new System.Drawing.Point(353, 123);
            this.lblNombreFirma.Name = "lblNombreFirma";
            this.lblNombreFirma.Size = new System.Drawing.Size(191, 16);
            this.lblNombreFirma.TabIndex = 327;
            this.lblNombreFirma.Text = "Nombre del archivo de la firma";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 16);
            this.label7.TabIndex = 276;
            this.label7.Text = "Directorio generar consolidados";
            // 
            // tbNombreFirma
            // 
            this.tbNombreFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombreFirma.Location = new System.Drawing.Point(356, 143);
            this.tbNombreFirma.Name = "tbNombreFirma";
            this.tbNombreFirma.Size = new System.Drawing.Size(296, 22);
            this.tbNombreFirma.TabIndex = 326;
            // 
            // txtGuardaConsolidado
            // 
            this.txtGuardaConsolidado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGuardaConsolidado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuardaConsolidado.Location = new System.Drawing.Point(16, 45);
            this.txtGuardaConsolidado.Name = "txtGuardaConsolidado";
            this.txtGuardaConsolidado.Size = new System.Drawing.Size(636, 22);
            this.txtGuardaConsolidado.TabIndex = 273;
            this.txtGuardaConsolidado.Text = "C:\\USERS\\CARLOS\\PICTURES\\LOGOTIPO01.JPG";
            // 
            // lblNombreLogo
            // 
            this.lblNombreLogo.AutoSize = true;
            this.lblNombreLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreLogo.Location = new System.Drawing.Point(12, 123);
            this.lblNombreLogo.Name = "lblNombreLogo";
            this.lblNombreLogo.Size = new System.Drawing.Size(178, 16);
            this.lblNombreLogo.TabIndex = 325;
            this.lblNombreLogo.Text = "Nombre del archivo del logo";
            // 
            // btnPreventiva
            // 
            this.btnPreventiva.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPreventiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreventiva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreventiva.Location = new System.Drawing.Point(668, 43);
            this.btnPreventiva.Name = "btnPreventiva";
            this.btnPreventiva.Size = new System.Drawing.Size(38, 26);
            this.btnPreventiva.TabIndex = 274;
            this.btnPreventiva.Text = "...";
            this.btnPreventiva.UseVisualStyleBackColor = false;
            this.btnPreventiva.Click += new System.EventHandler(this.btnPreventiva_Click);
            // 
            // tbNombreLogo
            // 
            this.tbNombreLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombreLogo.Location = new System.Drawing.Point(15, 143);
            this.tbNombreLogo.Name = "tbNombreLogo";
            this.tbNombreLogo.Size = new System.Drawing.Size(296, 22);
            this.tbNombreLogo.TabIndex = 324;
            // 
            // tbDireccionArchivosPDF
            // 
            this.tbDireccionArchivosPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDireccionArchivosPDF.Location = new System.Drawing.Point(16, 98);
            this.tbDireccionArchivosPDF.Name = "tbDireccionArchivosPDF";
            this.tbDireccionArchivosPDF.Size = new System.Drawing.Size(636, 22);
            this.tbDireccionArchivosPDF.TabIndex = 321;
            // 
            // lblDirectorioPDF
            // 
            this.lblDirectorioPDF.AutoSize = true;
            this.lblDirectorioPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirectorioPDF.Location = new System.Drawing.Point(13, 78);
            this.lblDirectorioPDF.Name = "lblDirectorioPDF";
            this.lblDirectorioPDF.Size = new System.Drawing.Size(287, 16);
            this.lblDirectorioPDF.TabIndex = 323;
            this.lblDirectorioPDF.Text = "Directorio de archivos para la exportacion PDF";
            // 
            // btnArchivosPDF
            // 
            this.btnArchivosPDF.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnArchivosPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchivosPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArchivosPDF.Location = new System.Drawing.Point(668, 96);
            this.btnArchivosPDF.Name = "btnArchivosPDF";
            this.btnArchivosPDF.Size = new System.Drawing.Size(38, 26);
            this.btnArchivosPDF.TabIndex = 322;
            this.btnArchivosPDF.Text = "...";
            this.btnArchivosPDF.UseVisualStyleBackColor = false;
            this.btnArchivosPDF.Click += new System.EventHandler(this.btnArchivosPDF_Click);
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SeaGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(966, 25);
            this.lbTitulo.TabIndex = 277;
            this.lbTitulo.Text = "   Ubicación de archivo consolidado";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnDirectorio);
            this.panel3.Controls.Add(this.btnArchivosConsolidar);
            this.panel3.Controls.Add(this.btnPlantillas);
            this.panel3.Controls.Add(this.btnFotos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(827, 50);
            this.panel3.TabIndex = 320;
            // 
            // btnDirectorio
            // 
            this.btnDirectorio.BackColor = System.Drawing.SystemColors.Control;
            this.btnDirectorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectorio.Location = new System.Drawing.Point(574, 10);
            this.btnDirectorio.Name = "btnDirectorio";
            this.btnDirectorio.Size = new System.Drawing.Size(205, 28);
            this.btnDirectorio.TabIndex = 3;
            this.btnDirectorio.Text = "Directorio consolidado";
            this.btnDirectorio.UseVisualStyleBackColor = false;
            this.btnDirectorio.Click += new System.EventHandler(this.rbtDirectorioConsolidados_Click);
            // 
            // btnArchivosConsolidar
            // 
            this.btnArchivosConsolidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchivosConsolidar.Location = new System.Drawing.Point(362, 10);
            this.btnArchivosConsolidar.Name = "btnArchivosConsolidar";
            this.btnArchivosConsolidar.Size = new System.Drawing.Size(205, 28);
            this.btnArchivosConsolidar.TabIndex = 2;
            this.btnArchivosConsolidar.Text = "Archivos para consolidar";
            this.btnArchivosConsolidar.UseVisualStyleBackColor = true;
            this.btnArchivosConsolidar.Click += new System.EventHandler(this.rbtArchivosConsolidados_Click);
            // 
            // btnPlantillas
            // 
            this.btnPlantillas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlantillas.Location = new System.Drawing.Point(154, 10);
            this.btnPlantillas.Name = "btnPlantillas";
            this.btnPlantillas.Size = new System.Drawing.Size(202, 28);
            this.btnPlantillas.TabIndex = 1;
            this.btnPlantillas.Text = "Plantillas para reportes";
            this.btnPlantillas.UseVisualStyleBackColor = true;
            this.btnPlantillas.Click += new System.EventHandler(this.rbtPlantillasReportes_Click);
            // 
            // btnFotos
            // 
            this.btnFotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFotos.Location = new System.Drawing.Point(28, 10);
            this.btnFotos.Name = "btnFotos";
            this.btnFotos.Size = new System.Drawing.Size(120, 28);
            this.btnFotos.TabIndex = 0;
            this.btnFotos.Text = "Fotos";
            this.btnFotos.UseVisualStyleBackColor = true;
            this.btnFotos.Click += new System.EventHandler(this.rbtFotos_Click);
            // 
            // frmConfigConsolidadosGuardarLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 373);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblFaltanCargar);
            this.Controls.Add(this.lbTitulo);
            this.Name = "frmConfigConsolidadosGuardarLab";
            this.ShowIcon = false;
            this.Text = "Ubicación de archivo consolidado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.lblFaltanCargar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel lblFaltanCargar;
        protected System.Windows.Forms.Button btnCancelar;
        protected System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGuardaConsolidado;
        protected System.Windows.Forms.Button btnPreventiva;
        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDirectorio;
        private System.Windows.Forms.Button btnArchivosConsolidar;
        private System.Windows.Forms.Button btnPlantillas;
        private System.Windows.Forms.Button btnFotos;
        private System.Windows.Forms.Label lblNombreFirma;
        private System.Windows.Forms.TextBox tbNombreFirma;
        private System.Windows.Forms.Label lblNombreLogo;
        private System.Windows.Forms.TextBox tbNombreLogo;
        private System.Windows.Forms.TextBox tbDireccionArchivosPDF;
        private System.Windows.Forms.Label lblDirectorioPDF;
        protected System.Windows.Forms.Button btnArchivosPDF;
        private System.Windows.Forms.DateTimePicker tpExportacionDesde;
        private System.Windows.Forms.Label lblFecha;
    }
}