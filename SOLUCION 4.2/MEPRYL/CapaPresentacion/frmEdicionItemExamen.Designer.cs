namespace CapaPresentacion
{
    partial class frmEdicionItemExamen
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.TextBox txtNombreInforme;
        private System.Windows.Forms.ComboBox cboSeccion;
        private System.Windows.Forms.ComboBox cboSubseccion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.Label lblNombreInforme;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Label lblSubseccion;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picGuardar;
        private System.Windows.Forms.PictureBox picCancelar;
        private System.Windows.Forms.Panel panelBotones;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.txtNombreInforme = new System.Windows.Forms.TextBox();
            this.cboSeccion = new System.Windows.Forms.ComboBox();
            this.cboSubseccion = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.lblNombreInforme = new System.Windows.Forms.Label();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.lblSubseccion = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picGuardar = new System.Windows.Forms.PictureBox();
            this.picCancelar = new System.Windows.Forms.PictureBox();
            this.panelBotones = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCancelar)).BeginInit();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
          
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(20, 40);
            this.lblCodigo.Size = new System.Drawing.Size(80, 20);
            this.lblCodigo.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(20, 60);
            this.txtCodigo.Size = new System.Drawing.Size(80, 22);
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.Location = new System.Drawing.Point(110, 40);
            this.lblNombreCompleto.Size = new System.Drawing.Size(120, 20);
            this.lblNombreCompleto.Text = "NombreCompleto";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Location = new System.Drawing.Point(110, 60);
            this.txtNombreCompleto.Size = new System.Drawing.Size(140, 22);
            // 
            // lblNombreInforme
            // 
            this.lblNombreInforme.Location = new System.Drawing.Point(260, 40);
            this.lblNombreInforme.Size = new System.Drawing.Size(120, 20);
            this.lblNombreInforme.Text = "Nombre Informes";
            // 
            // txtNombreInforme
            // 
            this.txtNombreInforme.Location = new System.Drawing.Point(260, 60);
            this.txtNombreInforme.Size = new System.Drawing.Size(140, 22);
            // 
            // lblSeccion
            // 
            this.lblSeccion.Location = new System.Drawing.Point(410, 40);
            this.lblSeccion.Size = new System.Drawing.Size(80, 20);
            this.lblSeccion.Text = "Seccion";
            // 
            // cboSeccion
            // 
            this.cboSeccion.Location = new System.Drawing.Point(410, 60);
            this.cboSeccion.Size = new System.Drawing.Size(120, 22);
            this.cboSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblSubseccion
            // 
            this.lblSubseccion.Location = new System.Drawing.Point(540, 40);
            this.lblSubseccion.Size = new System.Drawing.Size(80, 20);
            this.lblSubseccion.Text = "SubSeccion";
            // 
            // cboSubseccion
            // 
            this.cboSubseccion.Location = new System.Drawing.Point(540, 60);
            this.cboSubseccion.Size = new System.Drawing.Size(120, 22);
            this.cboSubseccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // panelBotones
            // 
            this.panelBotones.Location = new System.Drawing.Point(800, 40); // Más a la derecha
            this.panelBotones.Size = new System.Drawing.Size(370, 42);      // Mucho más ancho
            this.panelBotones.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panelBotones.Controls.Add(this.picGuardar);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Controls.Add(this.picCancelar);
            this.panelBotones.Controls.Add(this.btnCancelar);
            // 
            // picGuardar
            // 
            this.picGuardar.Location = new System.Drawing.Point(0, 6);
            this.picGuardar.Size = new System.Drawing.Size(32, 32);
            this.picGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // this.picGuardar.Image = Properties.Resources.icon_guardar;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(80, 6);
            this.btnGuardar.Size = new System.Drawing.Size(120, 32);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            // 
            // picCancelar
            // 
            this.picCancelar.Location = new System.Drawing.Point(170, 6);
            this.picCancelar.Size = new System.Drawing.Size(32, 32);
            this.picCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // this.picCancelar.Image = Properties.Resources.icon_cancelar;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(220, 6);
            this.btnCancelar.Size = new System.Drawing.Size(120, 32);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            // 
            // frmEdicionItemExamen
            // 
            this.ClientSize = new System.Drawing.Size(1200, 100);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblNombreCompleto);
            this.Controls.Add(this.txtNombreCompleto);
            this.Controls.Add(this.lblNombreInforme);
            this.Controls.Add(this.txtNombreInforme);
            this.Controls.Add(this.lblSeccion);
            this.Controls.Add(this.cboSeccion);
            this.Controls.Add(this.lblSubseccion);
            this.Controls.Add(this.cboSubseccion);
            this.Controls.Add(this.panelBotones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmEdicionItemExamen";
            this.Text = "ManejoItems";
            ((System.ComponentModel.ISupportInitialize)(this.picGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCancelar)).EndInit();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
