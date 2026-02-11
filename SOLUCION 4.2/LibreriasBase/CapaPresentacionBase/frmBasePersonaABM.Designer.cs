namespace CapaPresentacionBase
{
    partial class frmBasePersonaABM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBasePersonaABM));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.rbcMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiAgregarClub = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBuscarPaciente = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEnviarCorreo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCambiarClub = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUbicarConsolidado = new DevExpress.XtraBars.BarButtonItem();
            this.label2 = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNombres = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCodigoPostal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTelefonos = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbPaginaWeb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbObservaciones = new System.Windows.Forms.TextBox();
            this.cboaLocalidad = new UserControls.ucComboBoxActualizable();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboaProvincia = new UserControls.ucComboBoxActualizable();
            this.label14 = new System.Windows.Forms.Label();
            this.tbUbicacionGuia = new System.Windows.Forms.TextBox();
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPrincipal.SuspendLayout();
            this.panDerecha.SuspendLayout();
            this.panAbajo.SuspendLayout();
            this.panCentro.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).BeginInit();
            this.gbDatosPersonales.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.Size = new System.Drawing.Size(75, 19);
            this.lbTitulo.Text = "Persona";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(802, 0);
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(736, 328);
            // 
            // panDerecha
            // 
            this.panDerecha.Location = new System.Drawing.Point(736, 164);
            this.panDerecha.Size = new System.Drawing.Size(117, 328);
            // 
            // panAbajo
            // 
            this.panAbajo.Location = new System.Drawing.Point(0, 347);
            this.panAbajo.Size = new System.Drawing.Size(850, 53);
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(736, 328);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbDatosPersonales);
            this.tabPage1.Size = new System.Drawing.Size(728, 299);
            this.tabPage1.Controls.SetChildIndex(this.label1, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbCodigo, 0);
            this.tabPage1.Controls.SetChildIndex(this.butBuscar, 0);
            this.tabPage1.Controls.SetChildIndex(this.tbId, 0);
            this.tabPage1.Controls.SetChildIndex(this.gbDatosPersonales, 0);
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(733, 0);
            this.butSalir.Size = new System.Drawing.Size(117, 53);
            // 
            // rbcMenu
            // 
            this.rbcMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
            // 
            // 
            // 
            this.rbcMenu.ExpandCollapseItem.Id = 0;
            this.rbcMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            ((DevExpress.XtraBars.BarItem)(this.rbcMenu.ExpandCollapseItem)),
            ((DevExpress.XtraBars.BarItem)(this.bbiAgregarClub)),
            ((DevExpress.XtraBars.BarItem)(this.bbiBuscarPaciente)),
            ((DevExpress.XtraBars.BarItem)(this.bbiImprimir)),
            ((DevExpress.XtraBars.BarItem)(this.bbiEnviarCorreo)),
            ((DevExpress.XtraBars.BarItem)(this.bbiCambiarClub)),
            ((DevExpress.XtraBars.BarItem)(this.bbiUbicarConsolidado))});
            this.rbcMenu.Location = new System.Drawing.Point(0, 25);
            this.rbcMenu.MaxItemId = 7;
            this.rbcMenu.Name = "rbcMenu";
            this.rbcMenu.Size = new System.Drawing.Size(853, 139);
            // 
            // bbiAgregarClub
            // 
            this.bbiAgregarClub.Caption = "Agregar Club";
            this.bbiAgregarClub.Id = 1;
            this.bbiAgregarClub.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAgregarClub.ImageOptions.Image")));
            this.bbiAgregarClub.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAgregarClub.ImageOptions.LargeImage")));
            this.bbiAgregarClub.Name = "bbiAgregarClub";
            toolTipTitleItem1.Text = "Agregar un club";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Permite agregar un club de futbol a una liga previamente existente.\r\nEsto abre un" +
    "a ventana en la cual podemos “Agregar, modificar o eliminar” un club.\r\n";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.bbiAgregarClub.SuperTip = superToolTip1;
            // 
            // bbiBuscarPaciente
            // 
            this.bbiBuscarPaciente.Caption = "Buscar Paciente";
            this.bbiBuscarPaciente.Id = 2;
            this.bbiBuscarPaciente.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiBuscarPaciente.ImageOptions.Image")));
            this.bbiBuscarPaciente.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiBuscarPaciente.ImageOptions.LargeImage")));
            this.bbiBuscarPaciente.Name = "bbiBuscarPaciente";
            toolTipTitleItem2.Text = "Buscar paciente de preventiva";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Permite buscar un paciente previamente ingresado por nombre o DNI.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.bbiBuscarPaciente.SuperTip = superToolTip2;
            // 
            // bbiImprimir
            // 
            this.bbiImprimir.Caption = "Imprimir Historia";
            this.bbiImprimir.Id = 3;
            this.bbiImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiImprimir.ImageOptions.Image")));
            this.bbiImprimir.Name = "bbiImprimir";
            this.bbiImprimir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiEnviarCorreo
            // 
            this.bbiEnviarCorreo.Caption = "Enviar Correo";
            this.bbiEnviarCorreo.Id = 4;
            this.bbiEnviarCorreo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEnviarCorreo.ImageOptions.Image")));
            this.bbiEnviarCorreo.Name = "bbiEnviarCorreo";
            this.bbiEnviarCorreo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiCambiarClub
            // 
            this.bbiCambiarClub.Caption = "Cambiar Club";
            this.bbiCambiarClub.Id = 5;
            this.bbiCambiarClub.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCambiarClub.ImageOptions.Image")));
            this.bbiCambiarClub.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiCambiarClub.ImageOptions.LargeImage")));
            this.bbiCambiarClub.Name = "bbiCambiarClub";
            this.bbiCambiarClub.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiUbicarConsolidado
            // 
            this.bbiUbicarConsolidado.Caption = "Ubicar Consolidado";
            this.bbiUbicarConsolidado.Id = 6;
            this.bbiUbicarConsolidado.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiUbicarConsolidado.ImageOptions.Image")));
            this.bbiUbicarConsolidado.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiUbicarConsolidado.ImageOptions.LargeImage")));
            this.bbiUbicarConsolidado.Name = "bbiUbicarConsolidado";
            this.bbiUbicarConsolidado.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Apellido";
            // 
            // tbApellido
            // 
            this.tbApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbApellido.Location = new System.Drawing.Point(11, 35);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(162, 22);
            this.tbApellido.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombres";
            // 
            // tbNombres
            // 
            this.tbNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombres.Location = new System.Drawing.Point(177, 35);
            this.tbNombres.Name = "tbNombres";
            this.tbNombres.Size = new System.Drawing.Size(162, 22);
            this.tbNombres.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dirección";
            // 
            // tbDireccion
            // 
            this.tbDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDireccion.Location = new System.Drawing.Point(354, 35);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(328, 22);
            this.tbDireccion.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Código Postal";
            // 
            // tbCodigoPostal
            // 
            this.tbCodigoPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCodigoPostal.Location = new System.Drawing.Point(258, 83);
            this.tbCodigoPostal.Name = "tbCodigoPostal";
            this.tbCodigoPostal.Size = new System.Drawing.Size(81, 22);
            this.tbCodigoPostal.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "DNI/CI/LC/LE";
            // 
            // tbDNI
            // 
            this.tbDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDNI.Location = new System.Drawing.Point(11, 134);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(119, 22);
            this.tbDNI.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(176, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Fecha de Nacimiento";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(177, 134);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(117, 22);
            this.dtpFechaNacimiento.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Teléfonos";
            // 
            // tbTelefonos
            // 
            this.tbTelefonos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTelefonos.Location = new System.Drawing.Point(11, 183);
            this.tbTelefonos.Name = "tbTelefonos";
            this.tbTelefonos.Size = new System.Drawing.Size(328, 22);
            this.tbTelefonos.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(351, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "E-mail";
            // 
            // tbEmail
            // 
            this.tbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEmail.Location = new System.Drawing.Point(354, 134);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(162, 22);
            this.tbEmail.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(351, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 16);
            this.label12.TabIndex = 22;
            this.label12.Text = "Página Web";
            // 
            // tbPaginaWeb
            // 
            this.tbPaginaWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPaginaWeb.Location = new System.Drawing.Point(354, 183);
            this.tbPaginaWeb.Name = "tbPaginaWeb";
            this.tbPaginaWeb.Size = new System.Drawing.Size(162, 22);
            this.tbPaginaWeb.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(519, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 16);
            this.label13.TabIndex = 24;
            this.label13.Text = "Observaciones";
            // 
            // tbObservaciones
            // 
            this.tbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbObservaciones.Location = new System.Drawing.Point(522, 134);
            this.tbObservaciones.Multiline = true;
            this.tbObservaciones.Name = "tbObservaciones";
            this.tbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObservaciones.Size = new System.Drawing.Size(176, 69);
            this.tbObservaciones.TabIndex = 25;
            // 
            // cboaLocalidad
            // 
            this.cboaLocalidad.Location = new System.Drawing.Point(11, 83);
            this.cboaLocalidad.Name = "cboaLocalidad";
            this.cboaLocalidad.Size = new System.Drawing.Size(241, 23);
            this.cboaLocalidad.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Localidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(351, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Provincia";
            // 
            // cboaProvincia
            // 
            this.cboaProvincia.Location = new System.Drawing.Point(354, 83);
            this.cboaProvincia.Name = "cboaProvincia";
            this.cboaProvincia.Size = new System.Drawing.Size(241, 23);
            this.cboaProvincia.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(598, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 16);
            this.label14.TabIndex = 12;
            this.label14.Text = "Guía (ubicación)";
            // 
            // tbUbicacionGuia
            // 
            this.tbUbicacionGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUbicacionGuia.Location = new System.Drawing.Point(601, 83);
            this.tbUbicacionGuia.Name = "tbUbicacionGuia";
            this.tbUbicacionGuia.Size = new System.Drawing.Size(81, 22);
            this.tbUbicacionGuia.TabIndex = 13;
            // 
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.label2);
            this.gbDatosPersonales.Controls.Add(this.label14);
            this.gbDatosPersonales.Controls.Add(this.tbApellido);
            this.gbDatosPersonales.Controls.Add(this.tbUbicacionGuia);
            this.gbDatosPersonales.Controls.Add(this.tbNombres);
            this.gbDatosPersonales.Controls.Add(this.label7);
            this.gbDatosPersonales.Controls.Add(this.label3);
            this.gbDatosPersonales.Controls.Add(this.cboaProvincia);
            this.gbDatosPersonales.Controls.Add(this.tbDireccion);
            this.gbDatosPersonales.Controls.Add(this.label6);
            this.gbDatosPersonales.Controls.Add(this.label4);
            this.gbDatosPersonales.Controls.Add(this.cboaLocalidad);
            this.gbDatosPersonales.Controls.Add(this.tbCodigoPostal);
            this.gbDatosPersonales.Controls.Add(this.label13);
            this.gbDatosPersonales.Controls.Add(this.label5);
            this.gbDatosPersonales.Controls.Add(this.tbObservaciones);
            this.gbDatosPersonales.Controls.Add(this.tbDNI);
            this.gbDatosPersonales.Controls.Add(this.label12);
            this.gbDatosPersonales.Controls.Add(this.label8);
            this.gbDatosPersonales.Controls.Add(this.tbPaginaWeb);
            this.gbDatosPersonales.Controls.Add(this.label9);
            this.gbDatosPersonales.Controls.Add(this.label11);
            this.gbDatosPersonales.Controls.Add(this.dtpFechaNacimiento);
            this.gbDatosPersonales.Controls.Add(this.tbEmail);
            this.gbDatosPersonales.Controls.Add(this.tbTelefonos);
            this.gbDatosPersonales.Controls.Add(this.label10);
            this.gbDatosPersonales.Location = new System.Drawing.Point(3, 63);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(709, 213);
            this.gbDatosPersonales.TabIndex = 38;
            this.gbDatosPersonales.TabStop = false;
            this.gbDatosPersonales.Text = "Personales";
            // 
            // frmBasePersonaABM
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(853, 492);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Default;
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmBasePersonaABM";
            this.Text = "Persona";
            this.Controls.SetChildIndex(this.rbcMenu, 0);
            this.Controls.SetChildIndex(this.panDerecha, 0);
            this.Controls.SetChildIndex(this.panAbajo, 0);
            this.Controls.SetChildIndex(this.panCentro, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPrincipal.ResumeLayout(false);
            this.panDerecha.ResumeLayout(false);
            this.panAbajo.ResumeLayout(false);
            this.panAbajo.PerformLayout();
            this.panCentro.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbcMenu)).EndInit();
            this.gbDatosPersonales.ResumeLayout(false);
            this.gbDatosPersonales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox tbNombres;
        protected System.Windows.Forms.TextBox tbApellido;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox tbCodigoPostal;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox tbDireccion;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.TextBox tbDNI;
        protected System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.TextBox tbPaginaWeb;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox tbEmail;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox tbTelefonos;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.TextBox tbObservaciones;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label label6;
        protected UserControls.ucComboBoxActualizable cboaLocalidad;
        protected UserControls.ucComboBoxActualizable cboaProvincia;
        protected System.Windows.Forms.Label label14;
        protected System.Windows.Forms.TextBox tbUbicacionGuia;
        private System.Windows.Forms.GroupBox gbDatosPersonales;
        private DevExpress.XtraBars.Ribbon.RibbonControl rbcMenu;
        private DevExpress.XtraBars.BarButtonItem bbiAgregarClub;
        private DevExpress.XtraBars.BarButtonItem bbiBuscarPaciente;
        private DevExpress.XtraBars.BarButtonItem bbiImprimir;
        private DevExpress.XtraBars.BarButtonItem bbiEnviarCorreo;
        private DevExpress.XtraBars.BarButtonItem bbiCambiarClub;
        private DevExpress.XtraBars.BarButtonItem bbiUbicarConsolidado;
    }
}
