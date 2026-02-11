namespace CapaPresentacion
{
    partial class frmExportacionesPreventiva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportacionesPreventiva));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiExpWeb = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDataSMS = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExpMedida = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportarMesaEnt = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportarConsolidadoPreventiva = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCrearTablaJumpy = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
            // 
            // 

            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // Agregar los botones al grupo del ribbon
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiExpWeb);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDataSMS);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiExpMedida);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiExportarMesaEnt);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiExportarConsolidadoPreventiva);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiCrearTablaJumpy);
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbiExpWeb,
            this.bbiDataSMS,
            this.bbiExpMedida,
            this.bbiExportarMesaEnt,
            this.bbiExportarConsolidadoPreventiva,
            this.bbiCrearTablaJumpy});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(819, 139);
            // 
            // bbiExpWeb
            // 
            this.bbiExpWeb.Caption = "Exportación Página Web";
            this.bbiExpWeb.Id = 1;
            this.bbiExpWeb.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExpWeb.ImageOptions.Image")));
            this.bbiExpWeb.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExpWeb.ImageOptions.LargeImage")));
            this.bbiExpWeb.Name = "bbiExpWeb";
            this.bbiExpWeb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExpWeb_ItemClick);
            // 
            // bbiDataSMS
            // 
            this.bbiDataSMS.Caption = "Exportar Data SMS";
            this.bbiDataSMS.Id = 2;
            this.bbiDataSMS.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDataSMS.ImageOptions.Image")));
            this.bbiDataSMS.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDataSMS.ImageOptions.LargeImage")));
            this.bbiDataSMS.Name = "bbiDataSMS";
            this.bbiDataSMS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDataSMS_ItemClick);
            // 
            // bbiExpMedida
            // 
            this.bbiExpMedida.Caption = "Exportación a Medida";
            this.bbiExpMedida.Id = 3;
            this.bbiExpMedida.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExpMedida.ImageOptions.Image")));
            this.bbiExpMedida.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExpMedida.ImageOptions.LargeImage")));
            this.bbiExpMedida.Name = "bbiExpMedida";
            this.bbiExpMedida.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExpMedida_ItemClick);
            // 
            // bbiExportarMesaEnt
            // 
            this.bbiExportarMesaEnt.Caption = "Exportar Mesa Entrada";
            this.bbiExportarMesaEnt.Id = 4;
            this.bbiExportarMesaEnt.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportarMesaEnt.ImageOptions.Image")));
            this.bbiExportarMesaEnt.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportarMesaEnt.ImageOptions.LargeImage")));
            this.bbiExportarMesaEnt.Name = "bbiExportarMesaEnt";
            this.bbiExportarMesaEnt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportarMesaEnt_ItemClick);
            // 
            // bbiExportarConsolidadoPreventiva
            // 
            this.bbiExportarConsolidadoPreventiva.Caption = "Consolidación Masiva";
            this.bbiExportarConsolidadoPreventiva.Id = 5;
            this.bbiExportarConsolidadoPreventiva.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportarConsolidadoPreventiva.ImageOptions.Image")));
            this.bbiExportarConsolidadoPreventiva.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportarConsolidadoPreventiva.ImageOptions.LargeImage")));
            this.bbiExportarConsolidadoPreventiva.Name = "bbiExportarConsolidadoPreventiva";
            this.bbiExportarConsolidadoPreventiva.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportarConsolidadoPreventiva_ItemClick);
            // 
            // bbiCrearTablaJumpy
            // 
            this.bbiCrearTablaJumpy.Caption = "Crear Tabla para Jumpy";
            this.bbiCrearTablaJumpy.Id = 6;
            this.bbiCrearTablaJumpy.ImageOptions.LargeImage = global::CapaPresentacion.Properties.Resources.jumpy;
            this.bbiCrearTablaJumpy.Name = "bbiCrearTablaJumpy";
            this.bbiCrearTablaJumpy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCrearTablaJumpy_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Exportaciones Preventiva";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Exportaciones";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 258);
            this.panel1.TabIndex = 1;
            // 
            // frmExportacionesPreventiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 397);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.MinimizeBox = false;
            this.Name = "frmExportacionesPreventiva";
            this.ShowIcon = false;
            this.Text = "Exportaciones Preventiva";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiExpWeb;
        private DevExpress.XtraBars.BarButtonItem bbiDataSMS;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbiExpMedida;
        private DevExpress.XtraBars.BarButtonItem bbiExportarMesaEnt;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.BarButtonItem bbiExportarConsolidadoPreventiva;
        private DevExpress.XtraBars.BarButtonItem bbiCrearTablaJumpy;
    }
}