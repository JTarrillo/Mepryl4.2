namespace CapaPresentacion
{
    partial class frmReporteAudiometria
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteAudiometria));
            this.btnGuardarDatosExcel = new System.Windows.Forms.Button();
            this.spreadsheetControl1 = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.showBar1 = new DevExpress.XtraSpreadsheet.UI.ShowBar();
            this.spreadsheetCommandBarCheckItem1 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarCheckItem();
            this.spreadsheetCommandBarCheckItem2 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarCheckItem();
            this.zoomBar1 = new DevExpress.XtraSpreadsheet.UI.ZoomBar();
            this.spreadsheetCommandBarButtonItem1 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem2 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem3 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem4 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.windowBar1 = new DevExpress.XtraSpreadsheet.UI.WindowBar();
            this.spreadsheetCommandBarSubItem1 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarSubItem();
            this.spreadsheetCommandBarButtonItem5 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem6 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem7 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem8 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbActualizando = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pbActualizando = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkRevisar = new System.Windows.Forms.CheckBox();
            this.bntSalir = new System.Windows.Forms.Button();
            this.btnCrearReporte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstListaPaciente = new System.Windows.Forms.ListBox();
            this.dtpCalendario = new System.Windows.Forms.MonthCalendar();
            this.spreadsheetBarController1 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetBarController();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbActualizando.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spreadsheetBarController1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardarDatosExcel
            // 
            this.btnGuardarDatosExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarDatosExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarDatosExcel.Image")));
            this.btnGuardarDatosExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarDatosExcel.Location = new System.Drawing.Point(6, 24);
            this.btnGuardarDatosExcel.Name = "btnGuardarDatosExcel";
            this.btnGuardarDatosExcel.Size = new System.Drawing.Size(110, 45);
            this.btnGuardarDatosExcel.TabIndex = 0;
            this.btnGuardarDatosExcel.Text = "Guardar";
            this.btnGuardarDatosExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarDatosExcel.UseVisualStyleBackColor = true;
            this.btnGuardarDatosExcel.Visible = false;
            this.btnGuardarDatosExcel.Click += new System.EventHandler(this.btnGuardarDatosExcel_Click);
            // 
            // spreadsheetControl1
            // 
            this.spreadsheetControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadsheetControl1.Location = new System.Drawing.Point(0, 0);
            this.spreadsheetControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spreadsheetControl1.MenuManager = this.barManager1;
            this.spreadsheetControl1.Name = "spreadsheetControl1";
            this.spreadsheetControl1.Options.Import.Csv.Encoding = ((System.Text.Encoding)(resources.GetObject("spreadsheetControl1.Options.Import.Csv.Encoding")));
            this.spreadsheetControl1.Options.Import.Txt.Encoding = ((System.Text.Encoding)(resources.GetObject("spreadsheetControl1.Options.Import.Txt.Encoding")));
            this.spreadsheetControl1.Options.View.Charts.Antialiasing = DevExpress.XtraSpreadsheet.DocumentCapability.Disabled;
            this.spreadsheetControl1.Options.View.Charts.TextAntialiasing = DevExpress.XtraSpreadsheet.DocumentCapability.Disabled;
            this.spreadsheetControl1.Options.View.Pictures.HighQualityScaling = DevExpress.XtraSpreadsheet.DocumentCapability.Enabled;
            this.spreadsheetControl1.Size = new System.Drawing.Size(774, 499);
            this.spreadsheetControl1.TabIndex = 1;
            this.spreadsheetControl1.Text = "spreadsheetControl1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.showBar1,
            this.zoomBar1,
            this.windowBar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.spreadsheetCommandBarCheckItem1,
            this.spreadsheetCommandBarCheckItem2,
            this.spreadsheetCommandBarButtonItem1,
            this.spreadsheetCommandBarButtonItem2,
            this.spreadsheetCommandBarButtonItem3,
            this.spreadsheetCommandBarButtonItem4,
            this.spreadsheetCommandBarSubItem1,
            this.spreadsheetCommandBarButtonItem5,
            this.spreadsheetCommandBarButtonItem6,
            this.spreadsheetCommandBarButtonItem7,
            this.spreadsheetCommandBarButtonItem8});
            this.barManager1.MaxItemId = 35;
            // 
            // showBar1
            // 
            this.showBar1.Control = this.spreadsheetControl1;
            this.showBar1.DockCol = 0;
            this.showBar1.DockRow = 0;
            this.showBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.showBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.spreadsheetCommandBarCheckItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.spreadsheetCommandBarCheckItem2)});
            // 
            // spreadsheetCommandBarCheckItem1
            // 
            this.spreadsheetCommandBarCheckItem1.BindableChecked = true;
            this.spreadsheetCommandBarCheckItem1.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.spreadsheetCommandBarCheckItem1.Checked = true;
            this.spreadsheetCommandBarCheckItem1.CommandName = "ViewShowGridlines";
            this.spreadsheetCommandBarCheckItem1.Id = 24;
            this.spreadsheetCommandBarCheckItem1.Name = "spreadsheetCommandBarCheckItem1";
            // 
            // spreadsheetCommandBarCheckItem2
            // 
            this.spreadsheetCommandBarCheckItem2.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.spreadsheetCommandBarCheckItem2.CommandName = "ViewShowHeadings";
            this.spreadsheetCommandBarCheckItem2.Id = 25;
            this.spreadsheetCommandBarCheckItem2.Name = "spreadsheetCommandBarCheckItem2";
            // 
            // zoomBar1
            // 
            this.zoomBar1.Control = this.spreadsheetControl1;
            this.zoomBar1.DockCol = 1;
            this.zoomBar1.DockRow = 0;
            this.zoomBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.zoomBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.spreadsheetCommandBarButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.spreadsheetCommandBarButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.spreadsheetCommandBarButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.spreadsheetCommandBarButtonItem4)});
            this.zoomBar1.Offset = 207;
            // 
            // spreadsheetCommandBarButtonItem1
            // 
            this.spreadsheetCommandBarButtonItem1.CommandName = "ViewZoom";
            this.spreadsheetCommandBarButtonItem1.Id = 26;
            this.spreadsheetCommandBarButtonItem1.Name = "spreadsheetCommandBarButtonItem1";
            // 
            // spreadsheetCommandBarButtonItem2
            // 
            this.spreadsheetCommandBarButtonItem2.CommandName = "ViewZoomOut";
            this.spreadsheetCommandBarButtonItem2.Id = 27;
            this.spreadsheetCommandBarButtonItem2.Name = "spreadsheetCommandBarButtonItem2";
            // 
            // spreadsheetCommandBarButtonItem3
            // 
            this.spreadsheetCommandBarButtonItem3.CommandName = "ViewZoomIn";
            this.spreadsheetCommandBarButtonItem3.Id = 28;
            this.spreadsheetCommandBarButtonItem3.Name = "spreadsheetCommandBarButtonItem3";
            // 
            // spreadsheetCommandBarButtonItem4
            // 
            this.spreadsheetCommandBarButtonItem4.CommandName = "ViewZoom100Percent";
            this.spreadsheetCommandBarButtonItem4.Id = 29;
            this.spreadsheetCommandBarButtonItem4.Name = "spreadsheetCommandBarButtonItem4";
            // 
            // windowBar1
            // 
            this.windowBar1.Control = this.spreadsheetControl1;
            this.windowBar1.DockCol = 2;
            this.windowBar1.DockRow = 0;
            this.windowBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.windowBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.spreadsheetCommandBarSubItem1)});
            this.windowBar1.Offset = 211;
            // 
            // spreadsheetCommandBarSubItem1
            // 
            this.spreadsheetCommandBarSubItem1.CommandName = "ViewFreezePanesCommandGroup";
            this.spreadsheetCommandBarSubItem1.Id = 30;
            this.spreadsheetCommandBarSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.spreadsheetCommandBarButtonItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.spreadsheetCommandBarButtonItem6),
            new DevExpress.XtraBars.LinkPersistInfo(this.spreadsheetCommandBarButtonItem7),
            new DevExpress.XtraBars.LinkPersistInfo(this.spreadsheetCommandBarButtonItem8)});
            this.spreadsheetCommandBarSubItem1.Name = "spreadsheetCommandBarSubItem1";
            // 
            // spreadsheetCommandBarButtonItem5
            // 
            this.spreadsheetCommandBarButtonItem5.CommandName = "ViewFreezePanes";
            this.spreadsheetCommandBarButtonItem5.Id = 31;
            this.spreadsheetCommandBarButtonItem5.Name = "spreadsheetCommandBarButtonItem5";
            // 
            // spreadsheetCommandBarButtonItem6
            // 
            this.spreadsheetCommandBarButtonItem6.CommandName = "ViewUnfreezePanes";
            this.spreadsheetCommandBarButtonItem6.Id = 32;
            this.spreadsheetCommandBarButtonItem6.Name = "spreadsheetCommandBarButtonItem6";
            // 
            // spreadsheetCommandBarButtonItem7
            // 
            this.spreadsheetCommandBarButtonItem7.CommandName = "ViewFreezeTopRow";
            this.spreadsheetCommandBarButtonItem7.Id = 33;
            this.spreadsheetCommandBarButtonItem7.Name = "spreadsheetCommandBarButtonItem7";
            // 
            // spreadsheetCommandBarButtonItem8
            // 
            this.spreadsheetCommandBarButtonItem8.CommandName = "ViewFreezeFirstColumn";
            this.spreadsheetCommandBarButtonItem8.Id = 34;
            this.spreadsheetCommandBarButtonItem8.Name = "spreadsheetCommandBarButtonItem8";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1132, 44);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 573);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1132, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 44);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 529);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1132, 44);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 529);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbActualizando);
            this.panel1.Controls.Add(this.spreadsheetControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(235, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 499);
            this.panel1.TabIndex = 2;
            // 
            // gbActualizando
            // 
            this.gbActualizando.BackColor = System.Drawing.Color.Transparent;
            this.gbActualizando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gbActualizando.Controls.Add(this.label12);
            this.gbActualizando.Controls.Add(this.pbActualizando);
            this.gbActualizando.Location = new System.Drawing.Point(203, 166);
            this.gbActualizando.Name = "gbActualizando";
            this.gbActualizando.Size = new System.Drawing.Size(365, 80);
            this.gbActualizando.TabIndex = 10;
            this.gbActualizando.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Brown;
            this.label12.Location = new System.Drawing.Point(17, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 16);
            this.label12.TabIndex = 8;
            this.label12.Text = "Cargando exámenes...";
            // 
            // pbActualizando
            // 
            this.pbActualizando.ForeColor = System.Drawing.Color.Lime;
            this.pbActualizando.Location = new System.Drawing.Point(19, 19);
            this.pbActualizando.Name = "pbActualizando";
            this.pbActualizando.Size = new System.Drawing.Size(332, 23);
            this.pbActualizando.Step = 1;
            this.pbActualizando.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbActualizando.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkRevisar);
            this.panel2.Controls.Add(this.bntSalir);
            this.panel2.Controls.Add(this.btnCrearReporte);
            this.panel2.Controls.Add(this.btnGuardarDatosExcel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1009, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 499);
            this.panel2.TabIndex = 3;
            // 
            // chkRevisar
            // 
            this.chkRevisar.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRevisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkRevisar.Image = ((System.Drawing.Image)(resources.GetObject("chkRevisar.Image")));
            this.chkRevisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkRevisar.Location = new System.Drawing.Point(6, 86);
            this.chkRevisar.Name = "chkRevisar";
            this.chkRevisar.Size = new System.Drawing.Size(110, 45);
            this.chkRevisar.TabIndex = 3;
            this.chkRevisar.Text = "Revisar";
            this.chkRevisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRevisar.UseVisualStyleBackColor = true;
            this.chkRevisar.Visible = false;
            this.chkRevisar.CheckedChanged += new System.EventHandler(this.chkRevisar_CheckedChanged);
            this.chkRevisar.Click += new System.EventHandler(this.chkRevisar_Click);
            // 
            // bntSalir
            // 
            this.bntSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntSalir.Image = ((System.Drawing.Image)(resources.GetObject("bntSalir.Image")));
            this.bntSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntSalir.Location = new System.Drawing.Point(8, 391);
            this.bntSalir.Name = "bntSalir";
            this.bntSalir.Size = new System.Drawing.Size(106, 45);
            this.bntSalir.TabIndex = 2;
            this.bntSalir.Text = "Salir";
            this.bntSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntSalir.UseVisualStyleBackColor = true;
            this.bntSalir.Click += new System.EventHandler(this.bntSalir_Click);
            // 
            // btnCrearReporte
            // 
            this.btnCrearReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnCrearReporte.Image")));
            this.btnCrearReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearReporte.Location = new System.Drawing.Point(6, 151);
            this.btnCrearReporte.Name = "btnCrearReporte";
            this.btnCrearReporte.Size = new System.Drawing.Size(110, 45);
            this.btnCrearReporte.TabIndex = 1;
            this.btnCrearReporte.Text = "Reporte";
            this.btnCrearReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrearReporte.UseVisualStyleBackColor = true;
            this.btnCrearReporte.Visible = false;
            this.btnCrearReporte.Click += new System.EventHandler(this.btnCrearReporte_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SeaGreen;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1132, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Audiometría";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lstListaPaciente);
            this.panel3.Controls.Add(this.dtpCalendario);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 74);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(235, 499);
            this.panel3.TabIndex = 5;
            // 
            // lstListaPaciente
            // 
            this.lstListaPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstListaPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstListaPaciente.FormattingEnabled = true;
            this.lstListaPaciente.HorizontalScrollbar = true;
            this.lstListaPaciente.ItemHeight = 16;
            this.lstListaPaciente.Items.AddRange(new object[] {
            "L1",
            "L2",
            "L3",
            "L4",
            "L5",
            "L6",
            "L7",
            "L8"});
            this.lstListaPaciente.Location = new System.Drawing.Point(4, 183);
            this.lstListaPaciente.Name = "lstListaPaciente";
            this.lstListaPaciente.Size = new System.Drawing.Size(225, 244);
            this.lstListaPaciente.TabIndex = 1;
            this.lstListaPaciente.SelectedIndexChanged += new System.EventHandler(this.lstListaPaciente_SelectedIndexChanged);
            // 
            // dtpCalendario
            // 
            this.dtpCalendario.Location = new System.Drawing.Point(4, 9);
            this.dtpCalendario.Name = "dtpCalendario";
            this.dtpCalendario.TabIndex = 6;
            this.dtpCalendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.dtpCalendario_DateChanged);
            // 
            // spreadsheetBarController1
            // 
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarCheckItem1);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarCheckItem2);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem1);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem2);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem3);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem4);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarSubItem1);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem5);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem6);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem7);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem8);
            this.spreadsheetBarController1.Control = this.spreadsheetControl1;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // frmReporteAudiometria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 573);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmReporteAudiometria";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audiometría";
            this.Load += new System.EventHandler(this.frmReporteAudiometria_Load);
            this.Shown += new System.EventHandler(this.frmReporteAudiometria_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbActualizando.ResumeLayout(false);
            this.gbActualizando.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spreadsheetBarController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardarDatosExcel;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lstListaPaciente;
        private System.Windows.Forms.MonthCalendar dtpCalendario;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraSpreadsheet.UI.ShowBar showBar1;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarCheckItem spreadsheetCommandBarCheckItem1;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarCheckItem spreadsheetCommandBarCheckItem2;
        private DevExpress.XtraSpreadsheet.UI.ZoomBar zoomBar1;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem1;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem2;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem3;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem4;
        private DevExpress.XtraSpreadsheet.UI.WindowBar windowBar1;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarSubItem spreadsheetCommandBarSubItem1;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem5;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem6;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem7;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem8;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetBarController spreadsheetBarController1;
        private System.Windows.Forms.Button bntSalir;
        private System.Windows.Forms.Button btnCrearReporte;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.CheckBox chkRevisar;
        private System.Windows.Forms.Panel gbActualizando;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ProgressBar pbActualizando;
    }
}

