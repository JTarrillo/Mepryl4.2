namespace CapaPresentacion
{
    partial class frmBusquedaEmpresa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusquedaEmpresa));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.botonLaboratorio = new System.Windows.Forms.Panel();
            this.tbFiltro = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.botLimpiar = new System.Windows.Forms.Button();
            this.botFiltrar = new System.Windows.Forms.Button();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.botImprimirListado = new System.Windows.Forms.Button();
            this.botVerDatos = new System.Windows.Forms.Button();
            this.botModificar = new System.Windows.Forms.Button();
            this.botEliminar = new System.Windows.Forms.Button();
            this.botAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.botonLaboratorio.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.ForestGreen;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(1171, 40);
            this.lbTitulo.TabIndex = 128;
            this.lbTitulo.Text = "Empresas Asociadas";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv.ColumnHeadersHeight = 25;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.DarkGray;
            this.dgv.Location = new System.Drawing.Point(0, 40);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(989, 546);
            this.dgv.TabIndex = 129;
            this.dgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentDoubleClick);
            // 
            // botonLaboratorio
            // 
            this.botonLaboratorio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.botonLaboratorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.botonLaboratorio.Controls.Add(this.tbFiltro);
            this.botonLaboratorio.Controls.Add(this.btnSalir);
            this.botonLaboratorio.Controls.Add(this.botLimpiar);
            this.botonLaboratorio.Controls.Add(this.botFiltrar);
            this.botonLaboratorio.Controls.Add(this.cboFiltro);
            this.botonLaboratorio.Controls.Add(this.label15);
            this.botonLaboratorio.Controls.Add(this.botImprimirListado);
            this.botonLaboratorio.Controls.Add(this.botVerDatos);
            this.botonLaboratorio.Controls.Add(this.botModificar);
            this.botonLaboratorio.Controls.Add(this.botEliminar);
            this.botonLaboratorio.Controls.Add(this.botAgregar);
            this.botonLaboratorio.Dock = System.Windows.Forms.DockStyle.Right;
            this.botonLaboratorio.Location = new System.Drawing.Point(989, 40);
            this.botonLaboratorio.Name = "botonLaboratorio";
            this.botonLaboratorio.Size = new System.Drawing.Size(182, 546);
            this.botonLaboratorio.TabIndex = 131;
            // 
            // tbFiltro
            // 
            this.tbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.tbFiltro.FormattingEnabled = true;
            this.tbFiltro.Location = new System.Drawing.Point(7, 50);
            this.tbFiltro.Name = "tbFiltro";
            this.tbFiltro.Size = new System.Drawing.Size(164, 24);
            this.tbFiltro.TabIndex = 433;
            this.tbFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFiltro_KeyDown);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(-1, 373);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(182, 55);
            this.btnSalir.TabIndex = 432;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // botLimpiar
            // 
            this.botLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("botLimpiar.Image")));
            this.botLimpiar.Location = new System.Drawing.Point(7, 106);
            this.botLimpiar.Name = "botLimpiar";
            this.botLimpiar.Size = new System.Drawing.Size(164, 25);
            this.botLimpiar.TabIndex = 431;
            this.botLimpiar.UseVisualStyleBackColor = true;
            this.botLimpiar.Click += new System.EventHandler(this.botLimpiar_Click);
            // 
            // botFiltrar
            // 
            this.botFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("botFiltrar.Image")));
            this.botFiltrar.Location = new System.Drawing.Point(7, 79);
            this.botFiltrar.Name = "botFiltrar";
            this.botFiltrar.Size = new System.Drawing.Size(164, 25);
            this.botFiltrar.TabIndex = 430;
            this.botFiltrar.UseVisualStyleBackColor = true;
            this.botFiltrar.Click += new System.EventHandler(this.botFiltrar_Click);
            // 
            // cboFiltro
            // 
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Items.AddRange(new object[] {
            "Razon Social",
            "Tipo Documento",
            "Nro. Documento",
            "Tipo Contribuyente",
            "Categoria"});
            this.cboFiltro.Location = new System.Drawing.Point(7, 21);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(164, 24);
            this.cboFiltro.TabIndex = 428;
            this.cboFiltro.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 15);
            this.label15.TabIndex = 427;
            this.label15.Text = "Filtros";
            // 
            // botImprimirListado
            // 
            this.botImprimirListado.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botImprimirListado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botImprimirListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botImprimirListado.Image = ((System.Drawing.Image)(resources.GetObject("botImprimirListado.Image")));
            this.botImprimirListado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botImprimirListado.Location = new System.Drawing.Point(-1, 465);
            this.botImprimirListado.Name = "botImprimirListado";
            this.botImprimirListado.Size = new System.Drawing.Size(182, 55);
            this.botImprimirListado.TabIndex = 137;
            this.botImprimirListado.Text = "Imprimir Listado";
            this.botImprimirListado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botImprimirListado.UseVisualStyleBackColor = true;
            this.botImprimirListado.Visible = false;
            // 
            // botVerDatos
            // 
            this.botVerDatos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botVerDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botVerDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botVerDatos.Image = ((System.Drawing.Image)(resources.GetObject("botVerDatos.Image")));
            this.botVerDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botVerDatos.Location = new System.Drawing.Point(-1, 319);
            this.botVerDatos.Name = "botVerDatos";
            this.botVerDatos.Size = new System.Drawing.Size(182, 55);
            this.botVerDatos.TabIndex = 136;
            this.botVerDatos.Text = "Ver Datos";
            this.botVerDatos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botVerDatos.UseVisualStyleBackColor = true;
            this.botVerDatos.Click += new System.EventHandler(this.botVerDatos_Click);
            // 
            // botModificar
            // 
            this.botModificar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botModificar.Image = ((System.Drawing.Image)(resources.GetObject("botModificar.Image")));
            this.botModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botModificar.Location = new System.Drawing.Point(-1, 213);
            this.botModificar.Name = "botModificar";
            this.botModificar.Size = new System.Drawing.Size(182, 55);
            this.botModificar.TabIndex = 135;
            this.botModificar.Text = "Modificar";
            this.botModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botModificar.UseVisualStyleBackColor = true;
            this.botModificar.Click += new System.EventHandler(this.botModificar_Click);
            // 
            // botEliminar
            // 
            this.botEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botEliminar.Image = ((System.Drawing.Image)(resources.GetObject("botEliminar.Image")));
            this.botEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botEliminar.Location = new System.Drawing.Point(-1, 265);
            this.botEliminar.Name = "botEliminar";
            this.botEliminar.Size = new System.Drawing.Size(182, 55);
            this.botEliminar.TabIndex = 134;
            this.botEliminar.Text = "Eliminar";
            this.botEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botEliminar.UseVisualStyleBackColor = true;
            this.botEliminar.Click += new System.EventHandler(this.botEliminar_Click);
            // 
            // botAgregar
            // 
            this.botAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botAgregar.Image = ((System.Drawing.Image)(resources.GetObject("botAgregar.Image")));
            this.botAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botAgregar.Location = new System.Drawing.Point(-1, 161);
            this.botAgregar.Name = "botAgregar";
            this.botAgregar.Size = new System.Drawing.Size(182, 55);
            this.botAgregar.TabIndex = 133;
            this.botAgregar.Text = "Agregar";
            this.botAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botAgregar.UseVisualStyleBackColor = true;
            this.botAgregar.Click += new System.EventHandler(this.botAgregar_Click);
            // 
            // frmBusquedaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 586);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.botonLaboratorio);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusquedaEmpresa";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresas Asociadas";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.botonLaboratorio.ResumeLayout(false);
            this.botonLaboratorio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.DataGridView dgv;
        protected System.Windows.Forms.Panel botonLaboratorio;
        private System.Windows.Forms.Button botAgregar;
        private System.Windows.Forms.Button botVerDatos;
        private System.Windows.Forms.Button botModificar;
        private System.Windows.Forms.Button botEliminar;
        private System.Windows.Forms.Button botImprimirListado;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button botFiltrar;
        private System.Windows.Forms.Button botLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox tbFiltro;
    }
}