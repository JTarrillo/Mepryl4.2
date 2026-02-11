namespace CapaPresentacion
{
    partial class frmConfigUbicacionFotosLaboral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigUbicacionFotosLaboral));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lblFaltanCargar = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLaboral = new System.Windows.Forms.TextBox();
            this.btnLaboral = new System.Windows.Forms.Button();
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
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SeaGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1016, 25);
            this.lbTitulo.TabIndex = 127;
            this.lbTitulo.Text = "   Configuración Ubicación de fotografías";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFaltanCargar
            // 
            this.lblFaltanCargar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblFaltanCargar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFaltanCargar.Controls.Add(this.btnCancelar);
            this.lblFaltanCargar.Controls.Add(this.btnAceptar);
            this.lblFaltanCargar.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFaltanCargar.Location = new System.Drawing.Point(880, 25);
            this.lblFaltanCargar.Name = "lblFaltanCargar";
            this.lblFaltanCargar.Size = new System.Drawing.Size(136, 418);
            this.lblFaltanCargar.TabIndex = 128;
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
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtLaboral);
            this.panel1.Controls.Add(this.btnLaboral);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 418);
            this.panel1.TabIndex = 275;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 276;
            this.label1.Text = "Laboral";
            // 
            // txtLaboral
            // 
            this.txtLaboral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLaboral.Location = new System.Drawing.Point(94, 63);
            this.txtLaboral.Name = "txtLaboral";
            this.txtLaboral.Size = new System.Drawing.Size(553, 22);
            this.txtLaboral.TabIndex = 273;
            this.txtLaboral.Text = "C:\\Users\\carlos\\Pictures\\LogoTipo01.jpg";
            // 
            // btnLaboral
            // 
            this.btnLaboral.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLaboral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaboral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaboral.Location = new System.Drawing.Point(672, 60);
            this.btnLaboral.Name = "btnLaboral";
            this.btnLaboral.Size = new System.Drawing.Size(38, 26);
            this.btnLaboral.TabIndex = 274;
            this.btnLaboral.Text = "...";
            this.btnLaboral.UseVisualStyleBackColor = false;
            this.btnLaboral.Click += new System.EventHandler(this.btnLaboral_Click);
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
            this.panel3.Size = new System.Drawing.Size(880, 50);
            this.panel3.TabIndex = 319;
            // 
            // btnDirectorio
            // 
            this.btnDirectorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectorio.Location = new System.Drawing.Point(574, 10);
            this.btnDirectorio.Name = "btnDirectorio";
            this.btnDirectorio.Size = new System.Drawing.Size(205, 28);
            this.btnDirectorio.TabIndex = 3;
            this.btnDirectorio.Text = "Directorio consolidado";
            this.btnDirectorio.UseVisualStyleBackColor = true;
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
            this.btnFotos.BackColor = System.Drawing.SystemColors.Control;
            this.btnFotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFotos.Location = new System.Drawing.Point(28, 10);
            this.btnFotos.Name = "btnFotos";
            this.btnFotos.Size = new System.Drawing.Size(120, 28);
            this.btnFotos.TabIndex = 0;
            this.btnFotos.Text = "Fotos";
            this.btnFotos.UseVisualStyleBackColor = false;
            this.btnFotos.Click += new System.EventHandler(this.rbtFotos_Click);
            // 
            // frmConfigUbicacionFotosLaboral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 443);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFaltanCargar);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmConfigUbicacionFotosLaboral";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración Ubicación de Fotografías";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConfigUbicacionFotos_Load);
            this.lblFaltanCargar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        protected System.Windows.Forms.Panel lblFaltanCargar;
        protected System.Windows.Forms.Button btnCancelar;
        protected System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLaboral;
        protected System.Windows.Forms.Button btnLaboral;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDirectorio;
        private System.Windows.Forms.Button btnArchivosConsolidar;
        private System.Windows.Forms.Button btnPlantillas;
        private System.Windows.Forms.Button btnFotos;
    }
}