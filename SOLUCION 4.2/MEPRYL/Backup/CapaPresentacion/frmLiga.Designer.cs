namespace CapaPresentacion
{
    partial class frmLiga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLiga));
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
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
            this.lbTitulo.BackColor = System.Drawing.Color.SkyBlue;
            this.lbTitulo.Size = new System.Drawing.Size(560, 40);
            this.lbTitulo.Text = "Liga";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SkyBlue;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(521, 0);
            this.pictureBox2.Size = new System.Drawing.Size(39, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(424, 310);
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
            this.gbDatosPersonales.Controls.Add(this.label2);
            this.gbDatosPersonales.Controls.Add(this.tbDescripcion);
            this.gbDatosPersonales.Location = new System.Drawing.Point(18, 76);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(374, 187);
            this.gbDatosPersonales.TabIndex = 41;
            this.gbDatosPersonales.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 18);
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
            this.tbDescripcion.Location = new System.Drawing.Point(11, 35);
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(328, 20);
            this.tbDescripcion.TabIndex = 0;
            // 
            // frmLiga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(560, 378);
            this.Name = "frmLiga";
            this.Text = "Liga";
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
    }
}
