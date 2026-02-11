namespace CapaPresentacion
{
    partial class frmExportacionesLaboral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportacionesLaboral));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiExportarDictamen = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbiExportarDictamen,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            ((DevExpress.XtraBars.Ribbon.RibbonPage)(this.ribbonPage1))});
            this.ribbonControl1.Size = new System.Drawing.Size(812, 139);
            // 
            // bbiExportarDictamen
            // 
            this.bbiExportarDictamen.Caption = "Exportación Dictamen Final";
            this.bbiExportarDictamen.Id = 1;
            this.bbiExportarDictamen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportarDictamen.ImageOptions.Image")));
            this.bbiExportarDictamen.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportarDictamen.ImageOptions.LargeImage")));
            this.bbiExportarDictamen.Name = "bbiExportarDictamen";
            this.bbiExportarDictamen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportarDictamen_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Consulta Facturacion";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            ((DevExpress.XtraBars.Ribbon.RibbonPageGroup)(this.ribbonPageGroup1))});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Exportaciones Laboral";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(812, 235);
            this.panel1.TabIndex = 1;
            // 
            // frmExportacionesLaboral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 374);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.MinimizeBox = false;
            this.Name = "frmExportacionesLaboral";
            this.ShowIcon = false;
            this.Text = "Exportaciones Laboral";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.BarButtonItem bbiExportarDictamen;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}