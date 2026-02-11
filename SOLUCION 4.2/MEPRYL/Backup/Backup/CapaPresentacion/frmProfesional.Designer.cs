namespace CapaPresentacion
{
    partial class frmProfesional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfesional));
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.tbNombres = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.tbTelefonos = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.butHorarios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.panDerecha.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panCentro.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbDatosPersonales.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SaddleBrown;
            this.lbTitulo.Size = new System.Drawing.Size(544, 40);
            this.lbTitulo.Text = "Profesional";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SaddleBrown;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(503, 0);
            this.pictureBox2.Size = new System.Drawing.Size(41, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(408, 355);
            // 
            // panDerecha
            // 
            this.panDerecha.Location = new System.Drawing.Point(418, 40);
            this.panDerecha.Size = new System.Drawing.Size(126, 355);
            // 
            // panAbajo
            // 
            this.panAbajo.Location = new System.Drawing.Point(0, 395);
            this.panAbajo.Size = new System.Drawing.Size(544, 28);
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(408, 355);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.butHorarios);
            this.tabPage1.Controls.Add(this.gbDatosPersonales);
            this.tabPage1.Size = new System.Drawing.Size(400, 328);
            this.tabPage1.Controls.SetChildIndex(this.label1, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbCodigo, 0);
            this.tabPage1.Controls.SetChildIndex(this.butBuscar, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbId, 0);
            this.tabPage1.Controls.SetChildIndex(this.gbDatosPersonales, 0);
            this.tabPage1.Controls.SetChildIndex(this.butHorarios, 0);
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(418, 0);
            // 
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.label2);
            this.gbDatosPersonales.Controls.Add(this.tbApellido);
            this.gbDatosPersonales.Controls.Add(this.tbNombres);
            this.gbDatosPersonales.Controls.Add(this.label3);
            this.gbDatosPersonales.Controls.Add(this.label13);
            this.gbDatosPersonales.Controls.Add(this.tbObservaciones);
            this.gbDatosPersonales.Controls.Add(this.tbTelefonos);
            this.gbDatosPersonales.Controls.Add(this.label10);
            this.gbDatosPersonales.Location = new System.Drawing.Point(18, 75);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(369, 213);
            this.gbDatosPersonales.TabIndex = 40;
            this.gbDatosPersonales.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Apellido";
            // 
            // tbApellido
            // 
            this.tbApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApellido.Location = new System.Drawing.Point(11, 35);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(162, 20);
            this.tbApellido.TabIndex = 0;
            // 
            // tbNombres
            // 
            this.tbNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombres.Location = new System.Drawing.Point(177, 35);
            this.tbNombres.Name = "tbNombres";
            this.tbNombres.Size = new System.Drawing.Size(162, 20);
            this.tbNombres.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombres";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Observaciones";
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbObservaciones.Location = new System.Drawing.Point(11, 138);
            this.tbObservaciones.Multiline = true;
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObservaciones.Size = new System.Drawing.Size(345, 69);
            this.tbObservaciones.TabIndex = 7;
            // 
            // tbTelefonos
            // 
            this.tbTelefonos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTelefonos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbTelefonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTelefonos.Location = new System.Drawing.Point(11, 88);
            this.tbTelefonos.Name = "tbTelefonos";
            this.tbTelefonos.Size = new System.Drawing.Size(328, 20);
            this.tbTelefonos.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Teléfonos";
            // 
            // butHorarios
            // 
            this.butHorarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butHorarios.Location = new System.Drawing.Point(261, 294);
            this.butHorarios.Name = "butHorarios";
            this.butHorarios.Size = new System.Drawing.Size(113, 23);
            this.butHorarios.TabIndex = 41;
            this.butHorarios.Text = "Horarios";
            this.butHorarios.UseVisualStyleBackColor = true;
            this.butHorarios.Click += new System.EventHandler(this.butHorarios_Click);
            // 
            // frmProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(544, 423);
            this.Name = "frmProfesional";
            this.Text = "Profesional";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.panDerecha.ResumeLayout(false);
            this.panAbajo.ResumeLayout(false);
            this.panAbajo.PerformLayout();
            this.panCentro.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbDatosPersonales.ResumeLayout(false);
            this.gbDatosPersonales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosPersonales;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox tbApellido;
        protected System.Windows.Forms.TextBox tbNombres;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.TextBox tbObservaciones;
        protected System.Windows.Forms.TextBox tbTelefonos;
        protected System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button butHorarios;
    }
}
