namespace CapaPresentacion
{
    partial class frmReporteTurnosAsignados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteTurnosAsignados));
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbClubB = new System.Windows.Forms.ComboBox();
            this.cbLigaB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCategoriaHastaB = new System.Windows.Forms.TextBox();
            this.tbCategoriaDesdeB = new System.Windows.Forms.TextBox();
            this.butBuscarPorCampos = new System.Windows.Forms.Button();
            this.lbFiltro = new System.Windows.Forms.Label();
            this.lbCantRegistros = new System.Windows.Forms.Label();
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
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.MediumOrchid;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(752, 0);
            this.pictureBox2.Size = new System.Drawing.Size(49, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.MediumOrchid;
            this.lbTitulo.Text = "Reporte de Turnos Asignados";
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Location = new System.Drawing.Point(521, 10);
            this.tbBusqueda.Size = new System.Drawing.Size(74, 20);
            this.tbBusqueda.Visible = false;
            // 
            // labe2
            // 
            this.labe2.Location = new System.Drawing.Point(518, -6);
            this.labe2.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.ImageIndex = -1;
            this.tabPage1.Text = "";
            // 
            // tbCodigo
            // 
            this.tbCodigo.Visible = false;
            // 
            // label1
            // 
            this.label1.Visible = false;
            // 
            // tbId
            // 
            this.tbId.Text = "00000000-0000-0000-0000-000000000000";
            // 
            // butBuscar
            // 
            this.butBuscar.Location = new System.Drawing.Point(601, 8);
            this.butBuscar.Size = new System.Drawing.Size(55, 21);
            this.butBuscar.TabIndex = 60;
            this.butBuscar.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbCantRegistros);
            this.tabPage2.Controls.Add(this.butBuscarPorCampos);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tbCategoriaHastaB);
            this.tabPage2.Controls.Add(this.tbCategoriaDesdeB);
            this.tabPage2.Controls.Add(this.cbClubB);
            this.tabPage2.Controls.Add(this.cbLigaB);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.dtpFechaHasta);
            this.tabPage2.Controls.Add(this.dtpFechaDesde);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.SetChildIndex(this.labe2, 0);
            this.tabPage2.Controls.SetChildIndex(this.tbBusqueda, 0);
            this.tabPage2.Controls.SetChildIndex(this.butBuscar, 0);
            this.tabPage2.Controls.SetChildIndex(this.label2, 0);
            this.tabPage2.Controls.SetChildIndex(this.dtpFechaDesde, 0);
            this.tabPage2.Controls.SetChildIndex(this.dtpFechaHasta, 0);
            this.tabPage2.Controls.SetChildIndex(this.label4, 0);
            this.tabPage2.Controls.SetChildIndex(this.label5, 0);
            this.tabPage2.Controls.SetChildIndex(this.cbLigaB, 0);
            this.tabPage2.Controls.SetChildIndex(this.cbClubB, 0);
            this.tabPage2.Controls.SetChildIndex(this.tbCategoriaDesdeB, 0);
            this.tabPage2.Controls.SetChildIndex(this.tbCategoriaHastaB, 0);
            this.tabPage2.Controls.SetChildIndex(this.label3, 0);
            this.tabPage2.Controls.SetChildIndex(this.butBuscarPorCampos, 0);
            this.tabPage2.Controls.SetChildIndex(this.lbCantRegistros, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbFiltro);
            this.panel1.Size = new System.Drawing.Size(674, 145);
            this.panel1.Controls.SetChildIndex(this.tabPrincipal, 0);
            this.panel1.Controls.SetChildIndex(this.lbFiltro, 0);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(14, 52);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaHasta.TabIndex = 54;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(14, 26);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaDesde.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Período";
            // 
            // cbClubB
            // 
            this.cbClubB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClubB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbClubB.FormattingEnabled = true;
            this.cbClubB.Location = new System.Drawing.Point(312, 25);
            this.cbClubB.Name = "cbClubB";
            this.cbClubB.Size = new System.Drawing.Size(179, 21);
            this.cbClubB.TabIndex = 56;
            // 
            // cbLigaB
            // 
            this.cbLigaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLigaB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbLigaB.FormattingEnabled = true;
            this.cbLigaB.Location = new System.Drawing.Point(127, 25);
            this.cbLigaB.Name = "cbLigaB";
            this.cbLigaB.Size = new System.Drawing.Size(179, 21);
            this.cbLigaB.TabIndex = 55;
            this.cbLigaB.SelectedIndexChanged += new System.EventHandler(this.cbLigaB_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 69;
            this.label5.Text = "Club";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Liga";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Categorías";
            // 
            // tbCategoriaHastaB
            // 
            this.tbCategoriaHastaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCategoriaHastaB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCategoriaHastaB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCategoriaHastaB.Location = new System.Drawing.Point(437, 52);
            this.tbCategoriaHastaB.Name = "tbCategoriaHastaB";
            this.tbCategoriaHastaB.Size = new System.Drawing.Size(54, 20);
            this.tbCategoriaHastaB.TabIndex = 58;
            // 
            // tbCategoriaDesdeB
            // 
            this.tbCategoriaDesdeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCategoriaDesdeB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbCategoriaDesdeB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCategoriaDesdeB.Location = new System.Drawing.Point(365, 52);
            this.tbCategoriaDesdeB.Name = "tbCategoriaDesdeB";
            this.tbCategoriaDesdeB.Size = new System.Drawing.Size(56, 20);
            this.tbCategoriaDesdeB.TabIndex = 57;
            // 
            // butBuscarPorCampos
            // 
            this.butBuscarPorCampos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butBuscarPorCampos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBuscarPorCampos.Image = ((System.Drawing.Image)(resources.GetObject("butBuscarPorCampos.Image")));
            this.butBuscarPorCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBuscarPorCampos.Location = new System.Drawing.Point(509, 19);
            this.butBuscarPorCampos.Name = "butBuscarPorCampos";
            this.butBuscarPorCampos.Size = new System.Drawing.Size(86, 39);
            this.butBuscarPorCampos.TabIndex = 72;
            this.butBuscarPorCampos.Text = "Mostrar";
            this.butBuscarPorCampos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBuscarPorCampos.UseVisualStyleBackColor = false;
            this.butBuscarPorCampos.Click += new System.EventHandler(this.butBuscarPorCampos_Click);
            // 
            // lbFiltro
            // 
            this.lbFiltro.BackColor = System.Drawing.Color.MediumOrchid;
            this.lbFiltro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFiltro.ForeColor = System.Drawing.Color.White;
            this.lbFiltro.Location = new System.Drawing.Point(0, 115);
            this.lbFiltro.Name = "lbFiltro";
            this.lbFiltro.Size = new System.Drawing.Size(674, 30);
            this.lbFiltro.TabIndex = 7;
            this.lbFiltro.Text = "Todos";
            this.lbFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCantRegistros
            // 
            this.lbCantRegistros.AutoSize = true;
            this.lbCantRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantRegistros.Location = new System.Drawing.Point(517, 61);
            this.lbCantRegistros.Name = "lbCantRegistros";
            this.lbCantRegistros.Size = new System.Drawing.Size(0, 20);
            this.lbCantRegistros.TabIndex = 76;
            // 
            // frmReporteTurnosAsignados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(801, 489);
            this.Name = "frmReporteTurnosAsignados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Turnos Asignados";
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
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DateTimePicker dtpFechaHasta;
        protected System.Windows.Forms.DateTimePicker dtpFechaDesde;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbClubB;
        public System.Windows.Forms.ComboBox cbLigaB;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox tbCategoriaHastaB;
        protected System.Windows.Forms.TextBox tbCategoriaDesdeB;
        protected System.Windows.Forms.Button butBuscarPorCampos;
        private System.Windows.Forms.Label lbFiltro;
        private System.Windows.Forms.Label lbCantRegistros;
    }
}
