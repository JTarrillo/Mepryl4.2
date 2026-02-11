namespace DataSMSTurnos
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton8 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton9 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton10 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton11 = new System.Windows.Forms.ToolBarButton();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "Clubes");
            this.imageList1.Images.SetKeyName(1, "Horarios");
            this.imageList1.Images.SetKeyName(2, "Turnos");
            this.imageList1.Images.SetKeyName(3, "Agenda");
            this.imageList1.Images.SetKeyName(4, "Profesionales");
            this.imageList1.Images.SetKeyName(5, "Pacientes");
            this.imageList1.Images.SetKeyName(6, "AFA.png");
            this.imageList1.Images.SetKeyName(7, "PRINTER.png");
            this.imageList1.Images.SetKeyName(8, "celular3.jpg");
            this.imageList1.Images.SetKeyName(9, "Gear.png");
            this.imageList1.Images.SetKeyName(10, "stethoscope3.png");
            // 
            // toolBar2
            // 
            this.toolBar2.Location = new System.Drawing.Point(0, 433);
            this.toolBar2.Size = new System.Drawing.Size(1024, 28);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 461);
            this.statusBar1.Size = new System.Drawing.Size(1024, 22);
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton7,
            this.toolBarButton2,
            this.toolBarButton11,
            this.toolBarButton3,
            this.toolBarButton1,
            this.toolBarButton4,
            this.toolBarButton5,
            this.toolBarButton6,
            this.toolBarButton8,
            this.toolBarButton9,
            this.toolBarButton10});
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Size = new System.Drawing.Size(1024, 36);
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 5;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Text = "Pacientes";
            this.toolBarButton1.ToolTipText = "Administración de Pacientes";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.ImageIndex = 0;
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Text = "Clubes";
            this.toolBarButton2.ToolTipText = "Administración de Clubes";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.ImageIndex = 4;
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Text = "Profesionales";
            this.toolBarButton3.ToolTipText = "Administración de Profesionales";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.ImageIndex = 1;
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Text = "Horarios";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.ImageIndex = 2;
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Text = "Turnos";
            this.toolBarButton5.ToolTipText = "Administración de Turnos";
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.ImageIndex = 3;
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.Text = "Agenda";
            this.toolBarButton6.ToolTipText = "Impresión de Listados";
            // 
            // toolBarButton7
            // 
            this.toolBarButton7.ImageIndex = 6;
            this.toolBarButton7.Name = "toolBarButton7";
            this.toolBarButton7.Text = "Ligas";
            // 
            // toolBarButton8
            // 
            this.toolBarButton8.ImageIndex = 7;
            this.toolBarButton8.Name = "toolBarButton8";
            this.toolBarButton8.Text = "Reporte";
            this.toolBarButton8.ToolTipText = "Reporte de Turnos asignados";
            // 
            // toolBarButton9
            // 
            this.toolBarButton9.ImageIndex = 8;
            this.toolBarButton9.Name = "toolBarButton9";
            this.toolBarButton9.Text = "Notificaciones SMS";
            this.toolBarButton9.ToolTipText = "Enviar Notificaciones por SMS";
            // 
            // toolBarButton10
            // 
            this.toolBarButton10.ImageIndex = 9;
            this.toolBarButton10.Name = "toolBarButton10";
            this.toolBarButton10.Text = "Configuración";
            // 
            // toolBarButton11
            // 
            this.toolBarButton11.ImageIndex = 10;
            this.toolBarButton11.Name = "toolBarButton11";
            this.toolBarButton11.Text = "Especialidades";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1024, 483);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmPrincipal";
            this.Text = "Administración de Turnos - DataSMS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ToolBarButton toolBarButton4;
        private System.Windows.Forms.ToolBarButton toolBarButton5;
        private System.Windows.Forms.ToolBarButton toolBarButton6;
        private System.Windows.Forms.ToolBarButton toolBarButton7;
        private System.Windows.Forms.ToolBarButton toolBarButton8;
        private System.Windows.Forms.ToolBarButton toolBarButton9;
        private System.Windows.Forms.ToolBarButton toolBarButton10;
        private System.Windows.Forms.ToolBarButton toolBarButton11;
    }
}
