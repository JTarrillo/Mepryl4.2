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
            this.botonCargar = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnLlamaLiga = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.panDerecha.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panCentro.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbDatosPersonales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SkyBlue;
            this.lbTitulo.Size = new System.Drawing.Size(681, 40);
            this.lbTitulo.Text = "Liga";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SkyBlue;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(634, 0);
            this.pictureBox2.Size = new System.Drawing.Size(47, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(545, 343);
            // 
            // panDerecha
            // 
            this.panDerecha.Controls.Add(this.btnLlamaLiga);
            this.panDerecha.Location = new System.Drawing.Point(555, 40);
            this.panDerecha.Size = new System.Drawing.Size(126, 343);
            this.panDerecha.Controls.SetChildIndex(this.btnLlamaLiga, 0);
            this.panDerecha.Controls.SetChildIndex(this.butModificar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAgregar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butEliminar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAceptar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butCancelar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butOk, 0);
            // 
            // panAbajo
            // 
            this.panAbajo.Location = new System.Drawing.Point(0, 383);
            this.panAbajo.Size = new System.Drawing.Size(681, 28);
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(545, 343);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbDatosPersonales);
            this.tabPage1.Size = new System.Drawing.Size(537, 316);
            this.tabPage1.Controls.SetChildIndex(this.label1, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbCodigo, 0);
            this.tabPage1.Controls.SetChildIndex(this.butBuscar, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbId, 0);
            this.tabPage1.Controls.SetChildIndex(this.gbDatosPersonales, 0);
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(555, 0);
            // 
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.botonCargar);
            this.gbDatosPersonales.Controls.Add(this.pictureBox);
            this.gbDatosPersonales.Controls.Add(this.label2);
            this.gbDatosPersonales.Controls.Add(this.tbDescripcion);
            this.gbDatosPersonales.Location = new System.Drawing.Point(18, 76);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(374, 187);
            this.gbDatosPersonales.TabIndex = 41;
            this.gbDatosPersonales.TabStop = false;
            // 
            // botonCargar
            // 
            this.botonCargar.Location = new System.Drawing.Point(165, 159);
            this.botonCargar.Name = "botonCargar";
            this.botonCargar.Size = new System.Drawing.Size(34, 23);
            this.botonCargar.TabIndex = 2;
            this.botonCargar.Text = "...";
            this.botonCargar.UseVisualStyleBackColor = true;
            this.botonCargar.Click += new System.EventHandler(this.botonCargar_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(11, 62);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(147, 119);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
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
            this.tbDescripcion.Size = new System.Drawing.Size(188, 20);
            this.tbDescripcion.TabIndex = 0;
            // 
            // btnLlamaLiga
            // 
            this.btnLlamaLiga.Location = new System.Drawing.Point(25, 302);
            this.btnLlamaLiga.Name = "btnLlamaLiga";
            this.btnLlamaLiga.Size = new System.Drawing.Size(75, 23);
            this.btnLlamaLiga.TabIndex = 7;
            this.btnLlamaLiga.Text = "button1";
            this.btnLlamaLiga.UseVisualStyleBackColor = true;
            this.btnLlamaLiga.Click += new System.EventHandler(this.btnLlamaLiga_Click);
            // 
            // frmLiga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(681, 411);
            this.Name = "frmLiga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosPersonales;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button botonCargar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnLlamaLiga;
    }
}
