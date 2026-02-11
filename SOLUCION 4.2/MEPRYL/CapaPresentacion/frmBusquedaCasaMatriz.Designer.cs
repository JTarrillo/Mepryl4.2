namespace CapaPresentacion
{
    partial class frmBusquedaCasaMatriz
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
            this.lbTitulo = new System.Windows.Forms.Label();
            this.dgvBusquedaGeneral = new System.Windows.Forms.DataGridView();
            this.tbBusqueda = new System.Windows.Forms.TextBox();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblCasaMatriz = new System.Windows.Forms.Label();
            this.lblCasaMatrizInfo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblIdSucursal = new System.Windows.Forms.Label();
            this.lblIdCasaMatriz = new System.Windows.Forms.Label();
            this.rbCasaMatriz = new System.Windows.Forms.RadioButton();
            this.rbSucursal = new System.Windows.Forms.RadioButton();
            this.lblFactura = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusquedaGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.SeaGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(691, 30);
            this.lbTitulo.TabIndex = 127;
            this.lbTitulo.Text = "Definir Casa Matriz";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvBusquedaGeneral
            // 
            this.dgvBusquedaGeneral.AllowUserToAddRows = false;
            this.dgvBusquedaGeneral.AllowUserToDeleteRows = false;
            this.dgvBusquedaGeneral.AllowUserToResizeRows = false;
            this.dgvBusquedaGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusquedaGeneral.Location = new System.Drawing.Point(4, 123);
            this.dgvBusquedaGeneral.MultiSelect = false;
            this.dgvBusquedaGeneral.Name = "dgvBusquedaGeneral";
            this.dgvBusquedaGeneral.ReadOnly = true;
            this.dgvBusquedaGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBusquedaGeneral.Size = new System.Drawing.Size(440, 192);
            this.dgvBusquedaGeneral.TabIndex = 128;
            this.dgvBusquedaGeneral.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgvBusquedaGeneral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            this.dgvBusquedaGeneral.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_KeyPress);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Location = new System.Drawing.Point(4, 97);
            this.tbBusqueda.Name = "tbBusqueda";
            this.tbBusqueda.Size = new System.Drawing.Size(440, 20);
            this.tbBusqueda.TabIndex = 129;
            this.tbBusqueda.TextChanged += new System.EventHandler(this.tbBusqueda_TextChanged);
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSucursal.Location = new System.Drawing.Point(13, 34);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(58, 15);
            this.lblSucursal.TabIndex = 130;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblRazonSocial.Location = new System.Drawing.Point(13, 60);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(46, 18);
            this.lblRazonSocial.TabIndex = 131;
            this.lblRazonSocial.Text = "label1";
            // 
            // lblCasaMatriz
            // 
            this.lblCasaMatriz.AutoSize = true;
            this.lblCasaMatriz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCasaMatriz.Location = new System.Drawing.Point(267, 34);
            this.lblCasaMatriz.Name = "lblCasaMatriz";
            this.lblCasaMatriz.Size = new System.Drawing.Size(75, 15);
            this.lblCasaMatriz.TabIndex = 133;
            this.lblCasaMatriz.Text = "Casa Matriz:";
            // 
            // lblCasaMatrizInfo
            // 
            this.lblCasaMatrizInfo.AutoSize = true;
            this.lblCasaMatrizInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblCasaMatrizInfo.Location = new System.Drawing.Point(267, 60);
            this.lblCasaMatrizInfo.Name = "lblCasaMatrizInfo";
            this.lblCasaMatrizInfo.Size = new System.Drawing.Size(0, 18);
            this.lblCasaMatrizInfo.TabIndex = 134;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button1.Location = new System.Drawing.Point(476, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 37);
            this.button1.TabIndex = 135;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblIdSucursal
            // 
            this.lblIdSucursal.AutoSize = true;
            this.lblIdSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblIdSucursal.Location = new System.Drawing.Point(77, 34);
            this.lblIdSucursal.Name = "lblIdSucursal";
            this.lblIdSucursal.Size = new System.Drawing.Size(46, 18);
            this.lblIdSucursal.TabIndex = 136;
            this.lblIdSucursal.Text = "label1";
            this.lblIdSucursal.Visible = false;
            // 
            // lblIdCasaMatriz
            // 
            this.lblIdCasaMatriz.AutoSize = true;
            this.lblIdCasaMatriz.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblIdCasaMatriz.Location = new System.Drawing.Point(348, 34);
            this.lblIdCasaMatriz.Name = "lblIdCasaMatriz";
            this.lblIdCasaMatriz.Size = new System.Drawing.Size(46, 18);
            this.lblIdCasaMatriz.TabIndex = 137;
            this.lblIdCasaMatriz.Text = "label1";
            this.lblIdCasaMatriz.Visible = false;
            // 
            // rbCasaMatriz
            // 
            this.rbCasaMatriz.AutoSize = true;
            this.rbCasaMatriz.Location = new System.Drawing.Point(453, 196);
            this.rbCasaMatriz.Name = "rbCasaMatriz";
            this.rbCasaMatriz.Size = new System.Drawing.Size(80, 17);
            this.rbCasaMatriz.TabIndex = 138;
            this.rbCasaMatriz.TabStop = true;
            this.rbCasaMatriz.Text = "Casa Matriz";
            this.rbCasaMatriz.UseVisualStyleBackColor = true;
            // 
            // rbSucursal
            // 
            this.rbSucursal.AutoSize = true;
            this.rbSucursal.Location = new System.Drawing.Point(453, 220);
            this.rbSucursal.Name = "rbSucursal";
            this.rbSucursal.Size = new System.Drawing.Size(66, 17);
            this.rbSucursal.TabIndex = 139;
            this.rbSucursal.TabStop = true;
            this.rbSucursal.Text = "Sucursal";
            this.rbSucursal.UseVisualStyleBackColor = true;
            // 
            // lblFactura
            // 
            this.lblFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblFactura.Location = new System.Drawing.Point(450, 160);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(140, 33);
            this.lblFactura.TabIndex = 140;
            this.lblFactura.Text = "Factura a la Casa Matriz o en la Sucursal?";
            // 
            // frmBusquedaCasaMatriz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 327);
            this.Controls.Add(this.lblFactura);
            this.Controls.Add(this.rbSucursal);
            this.Controls.Add(this.rbCasaMatriz);
            this.Controls.Add(this.lblIdCasaMatriz);
            this.Controls.Add(this.lblIdSucursal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCasaMatrizInfo);
            this.Controls.Add(this.lblCasaMatriz);
            this.Controls.Add(this.lblRazonSocial);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.tbBusqueda);
            this.Controls.Add(this.dgvBusquedaGeneral);
            this.Controls.Add(this.lbTitulo);
            this.Name = "frmBusquedaCasaMatriz";
            this.Text = "frmBusquedaCasaMatriz";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusquedaGeneral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.DataGridView dgvBusquedaGeneral;
        private System.Windows.Forms.TextBox tbBusqueda;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Label lblCasaMatriz;
        private System.Windows.Forms.Label lblCasaMatrizInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblIdSucursal;
        private System.Windows.Forms.Label lblIdCasaMatriz;
        private System.Windows.Forms.RadioButton rbCasaMatriz;
        private System.Windows.Forms.RadioButton rbSucursal;
        private System.Windows.Forms.Label lblFactura;
    }
}