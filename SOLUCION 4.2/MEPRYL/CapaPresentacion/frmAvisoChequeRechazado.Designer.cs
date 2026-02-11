namespace CapaPresentacion
{
    partial class frmAvisoChequeRechazado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAvisoChequeRechazado));
            this.label2 = new System.Windows.Forms.Label();
            this.tbComentariosRechazo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpFechaRechazo = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.panCentro.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panBusqueda.SuspendLayout();
            this.gbControles.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(665, 253);
            // 
            // panAbajo
            // 
            this.panAbajo.Controls.Add(this.tbComentariosRechazo);
            this.panAbajo.Controls.Add(this.label13);
            this.panAbajo.Controls.Add(this.dtpFechaRechazo);
            this.panAbajo.Controls.Add(this.label12);
            this.panAbajo.Location = new System.Drawing.Point(0, 283);
            this.panAbajo.Size = new System.Drawing.Size(675, 80);
            this.panAbajo.Controls.SetChildIndex(this.tbEntidadNombre, 0);
            this.panAbajo.Controls.SetChildIndex(this.label12, 0);
            this.panAbajo.Controls.SetChildIndex(this.dtpFechaRechazo, 0);
            this.panAbajo.Controls.SetChildIndex(this.label13, 0);
            this.panAbajo.Controls.SetChildIndex(this.tbComentariosRechazo, 0);
            // 
            // tbEntidadNombre
            // 
            this.tbEntidadNombre.Location = new System.Drawing.Point(573, 15);
            // 
            // panDerecha
            // 
            this.panDerecha.Location = new System.Drawing.Point(675, 30);
            this.panDerecha.Size = new System.Drawing.Size(117, 333);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(752, 0);
            this.pictureBox2.Size = new System.Drawing.Size(40, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(0, 288);
            this.butSalir.Size = new System.Drawing.Size(117, 45);
            this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.None;
            this.tabPrincipal.Size = new System.Drawing.Size(10, 10);
            this.tabPrincipal.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Size = new System.Drawing.Size(2, 0);
            // 
            // panBusqueda
            // 
            this.panBusqueda.Size = new System.Drawing.Size(2, 0);
            // 
            // gbControles
            // 
            this.gbControles.Size = new System.Drawing.Size(0, 0);
            // 
            // tbId
            // 
            this.tbId.Text = "00000000-0000-0000-0000-000000000000";
            // 
            // panBotones
            // 
            this.panBotones.Location = new System.Drawing.Point(-142, 0);
            this.panBotones.Size = new System.Drawing.Size(144, 0);
            // 
            // tabPage2
            // 
            this.tabPage2.Size = new System.Drawing.Size(2, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Size = new System.Drawing.Size(665, 60);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.tabPrincipal, 0);
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.Red;
            this.lbTitulo.Size = new System.Drawing.Size(752, 30);
            this.lbTitulo.Text = "Alerta de Cheques Rechazados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "La cuenta tiene cheques rechazados anteriormente.";
            // 
            // tbComentariosRechazo
            // 
            this.tbComentariosRechazo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbComentariosRechazo.Location = new System.Drawing.Point(157, 20);
            this.tbComentariosRechazo.Multiline = true;
            this.tbComentariosRechazo.Name = "tbComentariosRechazo";
            this.tbComentariosRechazo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbComentariosRechazo.Size = new System.Drawing.Size(338, 50);
            this.tbComentariosRechazo.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(154, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Comentarios";
            // 
            // dtpFechaRechazo
            // 
            this.dtpFechaRechazo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRechazo.Location = new System.Drawing.Point(10, 20);
            this.dtpFechaRechazo.Name = "dtpFechaRechazo";
            this.dtpFechaRechazo.Size = new System.Drawing.Size(90, 21);
            this.dtpFechaRechazo.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Fecha";
            // 
            // frmAvisoChequeRechazado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 363);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Default;
            this.Name = "frmAvisoChequeRechazado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alerta de Cheques Rechazados";
            this.panCentro.ResumeLayout(false);
            this.panAbajo.ResumeLayout(false);
            this.panAbajo.PerformLayout();
            this.panDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panBusqueda.ResumeLayout(false);
            this.gbControles.ResumeLayout(false);
            this.gbControles.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbComentariosRechazo;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.DateTimePicker dtpFechaRechazo;
        protected System.Windows.Forms.Label label12;
    }
}
