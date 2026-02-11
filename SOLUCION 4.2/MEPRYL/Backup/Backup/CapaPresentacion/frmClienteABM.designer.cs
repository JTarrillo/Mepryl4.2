namespace CapaPresentacion
{
    partial class frmPacienteABM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPacienteABM));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.panDerecha.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panCentro.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbNombres
            // 
            this.tbNombres.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // tbApellido
            // 
            this.tbApellido.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // tbCodigoPostal
            // 
            this.tbCodigoPostal.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // tbDireccion
            // 
            this.tbDireccion.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // tbDNI
            // 
            this.tbDNI.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // tbPaginaWeb
            // 
            this.tbPaginaWeb.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // tbEmail
            // 
            this.tbEmail.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // tbTelefonos
            // 
            this.tbTelefonos.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // tbUbicacionGuia
            // 
            this.tbUbicacionGuia.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.Maroon;
            this.lbTitulo.Size = new System.Drawing.Size(849, 40);
            this.lbTitulo.Text = "Cliente";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Maroon;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(801, 0);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(722, 308);
            this.tabPrincipal.Enter += new System.EventHandler(this.tabPrincipal_Enter);
            
            // 
            // butAgregar
            // 
            this.butAgregar.Image = ((System.Drawing.Image)(resources.GetObject("butAgregar.Image")));
            // 
            // butEliminar
            // 
            this.butEliminar.Image = ((System.Drawing.Image)(resources.GetObject("butEliminar.Image")));
            // 
            // butModificar
            // 
            this.butModificar.Image = ((System.Drawing.Image)(resources.GetObject("butModificar.Image")));
            // 
            // panDerecha
            // 
            this.panDerecha.Location = new System.Drawing.Point(732, 40);
            this.panDerecha.Size = new System.Drawing.Size(117, 308);
            // 
            // panAbajo
            // 
            this.panAbajo.Location = new System.Drawing.Point(0, 348);
            this.panAbajo.Size = new System.Drawing.Size(849, 53);
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(722, 308);
            // 
            // tabPage1
            // 
            this.tabPage1.Size = new System.Drawing.Size(714, 281);
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(732, 0);
            // 
            // frmClienteABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(849, 401);
            this.Name = "frmClienteABM";
            this.Text = "Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.panDerecha.ResumeLayout(false);
            this.panAbajo.ResumeLayout(false);
            this.panAbajo.PerformLayout();
            this.panCentro.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
