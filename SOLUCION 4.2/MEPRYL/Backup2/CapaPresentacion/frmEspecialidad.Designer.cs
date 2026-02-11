namespace CapaPresentacion
{
    partial class frmEspecialidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEspecialidad));
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.botonEditar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMotivoConsulta = new System.Windows.Forms.ComboBox();
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
            this.lbTitulo.BackColor = System.Drawing.Color.SpringGreen;
            this.lbTitulo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbTitulo.Size = new System.Drawing.Size(560, 40);
            this.lbTitulo.Text = "Tipo de Examen";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SpringGreen;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(521, 0);
            this.pictureBox2.Size = new System.Drawing.Size(39, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(424, 310);
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(359, 3);
            // 
            // panDerecha
            // 
            this.panDerecha.Location = new System.Drawing.Point(434, 40);
            this.panDerecha.Size = new System.Drawing.Size(126, 310);
            // 
            // panAbajo
            // 
            this.panAbajo.Location = new System.Drawing.Point(0, 350);
            this.panAbajo.Size = new System.Drawing.Size(560, 28);
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(424, 310);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbDatosPersonales);
            this.tabPage1.Size = new System.Drawing.Size(416, 283);
            this.tabPage1.Controls.SetChildIndex(this.label1, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbCodigo, 0);
            this.tabPage1.Controls.SetChildIndex(this.butBuscar, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbId, 0);
            this.tabPage1.Controls.SetChildIndex(this.gbDatosPersonales, 0);
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(434, 0);
            // 
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.cboMotivoConsulta);
            this.gbDatosPersonales.Controls.Add(this.label3);
            this.gbDatosPersonales.Controls.Add(this.botonEditar);
            this.gbDatosPersonales.Controls.Add(this.label2);
            this.gbDatosPersonales.Controls.Add(this.tbDescripcion);
            this.gbDatosPersonales.Location = new System.Drawing.Point(18, 76);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(374, 187);
            this.gbDatosPersonales.TabIndex = 41;
            this.gbDatosPersonales.TabStop = false;
            // 
            // botonEditar
            // 
            this.botonEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botonEditar.Location = new System.Drawing.Point(62, 123);
            this.botonEditar.Name = "botonEditar";
            this.botonEditar.Size = new System.Drawing.Size(248, 28);
            this.botonEditar.TabIndex = 76;
            this.botonEditar.Text = "Modificar Estudios Asociados";
            this.botonEditar.UseVisualStyleBackColor = true;
            this.botonEditar.Click += new System.EventHandler(this.botonEditar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion.Location = new System.Drawing.Point(62, 47);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(248, 20);
            this.tbDescripcion.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "Motivo de Consulta";
            // 
            // cboMotivoConsulta
            // 
            this.cboMotivoConsulta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboMotivoConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMotivoConsulta.FormattingEnabled = true;
            this.cboMotivoConsulta.Location = new System.Drawing.Point(62, 87);
            this.cboMotivoConsulta.Name = "cboMotivoConsulta";
            this.cboMotivoConsulta.Size = new System.Drawing.Size(248, 21);
            this.cboMotivoConsulta.TabIndex = 78;
            // 
            // frmEspecialidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(560, 378);
            this.Name = "frmEspecialidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Examen";
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
        protected System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Button botonEditar;
        protected System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMotivoConsulta;
    }
}
