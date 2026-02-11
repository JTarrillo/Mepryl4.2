namespace CapaPresentacion
{
    partial class frmNotificacionesSMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotificacionesSMS));
            this.label2 = new System.Windows.Forms.Label();
            this.cbClubB = new System.Windows.Forms.ComboBox();
            this.cbLigaB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbFiltro = new System.Windows.Forms.Label();
            this.lbCantRegistros = new System.Windows.Forms.Label();
            this.lbListaEnviar = new System.Windows.Forms.Label();
            this.butAgregarALista = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbCategoriaB = new System.Windows.Forms.TextBox();
            this.tbMensaje = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butSeleccionarTodo = new System.Windows.Forms.Button();
            this.dgListaEnviar = new System.Windows.Forms.DataGridView();
            this.seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ligaTexto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clubTexto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butSeleccionarTodoEnviar = new System.Windows.Forms.Button();
            this.butEnviarLista = new System.Windows.Forms.Button();
            this.butBorrarSeleccionados = new System.Windows.Forms.Button();
            this.butInsertarNombre = new System.Windows.Forms.Button();
            this.butInsertarApellido = new System.Windows.Forms.Button();
            this.butInsertarDni = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgListaEnviar)).BeginInit();
            this.SuspendLayout();
            // 
            // panCentro
            // 
            this.panCentro.Size = new System.Drawing.Size(927, 329);
            // 
            // panAbajo
            // 
            this.panAbajo.Controls.Add(this.butBorrarSeleccionados);
            this.panAbajo.Controls.Add(this.butSeleccionarTodoEnviar);
            this.panAbajo.Controls.Add(this.dgListaEnviar);
            this.panAbajo.Controls.Add(this.panel2);
            this.panAbajo.Controls.Add(this.lbListaEnviar);
            this.panAbajo.Location = new System.Drawing.Point(0, 369);
            this.panAbajo.Size = new System.Drawing.Size(937, 264);
            this.panAbajo.Controls.SetChildIndex(this.lbListaEnviar, 0);
            this.panAbajo.Controls.SetChildIndex(this.tbEntidadNombre, 0);
            this.panAbajo.Controls.SetChildIndex(this.panel2, 0);
            this.panAbajo.Controls.SetChildIndex(this.dgListaEnviar, 0);
            this.panAbajo.Controls.SetChildIndex(this.butSeleccionarTodoEnviar, 0);
            this.panAbajo.Controls.SetChildIndex(this.butBorrarSeleccionados, 0);
            // 
            // tbEntidadNombre
            // 
            this.tbEntidadNombre.Location = new System.Drawing.Point(616, 0);
            // 
            // panDerecha
            // 
            this.panDerecha.Controls.Add(this.butAgregarALista);
            this.panDerecha.Controls.Add(this.butEnviarLista);
            this.panDerecha.Location = new System.Drawing.Point(937, 40);
            this.panDerecha.Size = new System.Drawing.Size(117, 593);
            this.panDerecha.Controls.SetChildIndex(this.butEnviarLista, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAgregarALista, 0);
            this.panDerecha.Controls.SetChildIndex(this.butImprimir, 0);
            this.panDerecha.Controls.SetChildIndex(this.butCancelar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAceptar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butModificar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butEliminar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butAgregar, 0);
            this.panDerecha.Controls.SetChildIndex(this.butSalir, 0);
            // 
            // butCancelar
            // 
            this.butCancelar.Location = new System.Drawing.Point(6, 44);
            // 
            // butAceptar
            // 
            this.butAceptar.Location = new System.Drawing.Point(6, 15);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1010, 0);
            this.pictureBox2.Size = new System.Drawing.Size(44, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // butSalir
            // 
            this.butSalir.Location = new System.Drawing.Point(0, 569);
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Size = new System.Drawing.Size(927, 129);
            // 
            // tbBusqueda
            // 
            this.tbBusqueda.Location = new System.Drawing.Point(307, 62);
            this.tbBusqueda.Size = new System.Drawing.Size(139, 20);
            this.tbBusqueda.TabIndex = 3;
            // 
            // labe2
            // 
            this.labe2.Location = new System.Drawing.Point(304, 44);
            // 
            // tabPage1
            // 
            this.tabPage1.ImageIndex = -1;
            this.tabPage1.Size = new System.Drawing.Size(919, 102);
            this.tabPage1.Text = "";
            // 
            // panBusqueda
            // 
            this.panBusqueda.Size = new System.Drawing.Size(919, 102);
            // 
            // gbControles
            // 
            this.gbControles.Size = new System.Drawing.Size(775, 102);
            this.gbControles.Visible = false;
            // 
            // tbId
            // 
            this.tbId.Text = "00000000-0000-0000-0000-000000000000";
            // 
            // butBuscar
            // 
            this.butBuscar.Location = new System.Drawing.Point(452, 29);
            this.butBuscar.Size = new System.Drawing.Size(83, 39);
            this.butBuscar.TabIndex = 4;
            this.butBuscar.Click += new System.EventHandler(this.butBuscar_Click);
            // 
            // panBotones
            // 
            this.panBotones.Location = new System.Drawing.Point(775, 0);
            this.panBotones.Size = new System.Drawing.Size(144, 102);
            this.panBotones.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.butInsertarDni);
            this.tabPage2.Controls.Add(this.butInsertarApellido);
            this.tabPage2.Controls.Add(this.butInsertarNombre);
            this.tabPage2.Controls.Add(this.tbMensaje);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tbCategoriaB);
            this.tabPage2.Controls.Add(this.lbCantRegistros);
            this.tabPage2.Controls.Add(this.cbClubB);
            this.tabPage2.Controls.Add(this.cbLigaB);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Size = new System.Drawing.Size(666, 102);
            this.tabPage2.Controls.SetChildIndex(this.labe2, 0);
            this.tabPage2.Controls.SetChildIndex(this.tbBusqueda, 0);
            this.tabPage2.Controls.SetChildIndex(this.butBuscar, 0);
            this.tabPage2.Controls.SetChildIndex(this.label2, 0);
            this.tabPage2.Controls.SetChildIndex(this.label4, 0);
            this.tabPage2.Controls.SetChildIndex(this.label5, 0);
            this.tabPage2.Controls.SetChildIndex(this.cbLigaB, 0);
            this.tabPage2.Controls.SetChildIndex(this.cbClubB, 0);
            this.tabPage2.Controls.SetChildIndex(this.lbCantRegistros, 0);
            this.tabPage2.Controls.SetChildIndex(this.tbCategoriaB, 0);
            this.tabPage2.Controls.SetChildIndex(this.label6, 0);
            this.tabPage2.Controls.SetChildIndex(this.tbMensaje, 0);
            this.tabPage2.Controls.SetChildIndex(this.butInsertarNombre, 0);
            this.tabPage2.Controls.SetChildIndex(this.butInsertarApellido, 0);
            this.tabPage2.Controls.SetChildIndex(this.butInsertarDni, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butSeleccionarTodo);
            this.panel1.Controls.Add(this.lbFiltro);
            this.panel1.Size = new System.Drawing.Size(927, 159);
            this.panel1.Controls.SetChildIndex(this.tabPrincipal, 0);
            this.panel1.Controls.SetChildIndex(this.lbFiltro, 0);
            this.panel1.Controls.SetChildIndex(this.butSeleccionarTodo, 0);
            // 
            // butImprimir
            // 
            this.butImprimir.Location = new System.Drawing.Point(6, 74);
            this.butImprimir.Visible = false;
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbTitulo.ForeColor = System.Drawing.Color.IndianRed;
            this.lbTitulo.Size = new System.Drawing.Size(1010, 40);
            this.lbTitulo.Text = "Enviar Notificaciones por SMS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Categoría";
            // 
            // cbClubB
            // 
            this.cbClubB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClubB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbClubB.FormattingEnabled = true;
            this.cbClubB.Location = new System.Drawing.Point(15, 62);
            this.cbClubB.Name = "cbClubB";
            this.cbClubB.Size = new System.Drawing.Size(286, 21);
            this.cbClubB.TabIndex = 1;
            // 
            // cbLigaB
            // 
            this.cbLigaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLigaB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbLigaB.FormattingEnabled = true;
            this.cbLigaB.Location = new System.Drawing.Point(15, 21);
            this.cbLigaB.Name = "cbLigaB";
            this.cbLigaB.Size = new System.Drawing.Size(286, 21);
            this.cbLigaB.TabIndex = 0;
            this.cbLigaB.SelectedIndexChanged += new System.EventHandler(this.cbLigaB_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 73;
            this.label5.Text = "Club";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "Liga";
            // 
            // lbFiltro
            // 
            this.lbFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbFiltro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFiltro.ForeColor = System.Drawing.Color.IndianRed;
            this.lbFiltro.Location = new System.Drawing.Point(0, 129);
            this.lbFiltro.Name = "lbFiltro";
            this.lbFiltro.Size = new System.Drawing.Size(927, 30);
            this.lbFiltro.TabIndex = 6;
            this.lbFiltro.Text = "Todos";
            this.lbFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCantRegistros
            // 
            this.lbCantRegistros.AutoSize = true;
            this.lbCantRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantRegistros.Location = new System.Drawing.Point(455, 75);
            this.lbCantRegistros.Name = "lbCantRegistros";
            this.lbCantRegistros.Size = new System.Drawing.Size(0, 25);
            this.lbCantRegistros.TabIndex = 75;
            // 
            // lbListaEnviar
            // 
            this.lbListaEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbListaEnviar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbListaEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbListaEnviar.ForeColor = System.Drawing.Color.IndianRed;
            this.lbListaEnviar.Location = new System.Drawing.Point(0, 0);
            this.lbListaEnviar.Name = "lbListaEnviar";
            this.lbListaEnviar.Size = new System.Drawing.Size(937, 30);
            this.lbListaEnviar.TabIndex = 7;
            this.lbListaEnviar.Text = "Lista para Enviar";
            this.lbListaEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butAgregarALista
            // 
            this.butAgregarALista.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butAgregarALista.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAgregarALista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAgregarALista.Location = new System.Drawing.Point(6, 129);
            this.butAgregarALista.Name = "butAgregarALista";
            this.butAgregarALista.Size = new System.Drawing.Size(106, 27);
            this.butAgregarALista.TabIndex = 72;
            this.butAgregarALista.Text = "Agregar a la lista";
            this.butAgregarALista.UseVisualStyleBackColor = false;
            this.butAgregarALista.Click += new System.EventHandler(this.butAgregarALista_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 240);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(937, 24);
            this.panel2.TabIndex = 73;
            // 
            // tbCategoriaB
            // 
            this.tbCategoriaB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCategoriaB.Location = new System.Drawing.Point(307, 21);
            this.tbCategoriaB.Name = "tbCategoriaB";
            this.tbCategoriaB.Size = new System.Drawing.Size(82, 20);
            this.tbCategoriaB.TabIndex = 2;
            this.tbCategoriaB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCategoriaB.Validating += new System.ComponentModel.CancelEventHandler(this.tbCategoriaB_Validating);
            // 
            // tbMensaje
            // 
            this.tbMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMensaje.Location = new System.Drawing.Point(572, 21);
            this.tbMensaje.MaxLength = 140;
            this.tbMensaje.Multiline = true;
            this.tbMensaje.Name = "tbMensaje";
            this.tbMensaje.Size = new System.Drawing.Size(344, 54);
            this.tbMensaje.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(569, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 77;
            this.label6.Text = "Mensaje ";
            // 
            // butSeleccionarTodo
            // 
            this.butSeleccionarTodo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butSeleccionarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSeleccionarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSeleccionarTodo.Location = new System.Drawing.Point(2, 131);
            this.butSeleccionarTodo.Name = "butSeleccionarTodo";
            this.butSeleccionarTodo.Size = new System.Drawing.Size(116, 25);
            this.butSeleccionarTodo.TabIndex = 73;
            this.butSeleccionarTodo.Tag = "";
            this.butSeleccionarTodo.Text = "Seleccionar Todo";
            this.butSeleccionarTodo.UseVisualStyleBackColor = false;
            this.butSeleccionarTodo.Click += new System.EventHandler(this.butSeleccionarTodo_Click);
            // 
            // dgListaEnviar
            // 
            this.dgListaEnviar.AllowUserToAddRows = false;
            this.dgListaEnviar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListaEnviar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seleccionar,
            this.dni,
            this.apellido,
            this.nombres,
            this.ligaTexto,
            this.clubTexto,
            this.fechaNacimiento,
            this.celular});
            this.dgListaEnviar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgListaEnviar.Location = new System.Drawing.Point(0, 30);
            this.dgListaEnviar.Name = "dgListaEnviar";
            this.dgListaEnviar.Size = new System.Drawing.Size(937, 210);
            this.dgListaEnviar.TabIndex = 74;
            this.dgListaEnviar.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgListaEnviar_CellEndEdit);
            // 
            // seleccionar
            // 
            this.seleccionar.HeaderText = "";
            this.seleccionar.Name = "seleccionar";
            // 
            // dni
            // 
            this.dni.HeaderText = "DNI";
            this.dni.Name = "dni";
            // 
            // apellido
            // 
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            // 
            // nombres
            // 
            this.nombres.HeaderText = "Nombres";
            this.nombres.Name = "nombres";
            // 
            // ligaTexto
            // 
            this.ligaTexto.HeaderText = "Liga";
            this.ligaTexto.Name = "ligaTexto";
            // 
            // clubTexto
            // 
            this.clubTexto.HeaderText = "Club";
            this.clubTexto.Name = "clubTexto";
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.HeaderText = "Fecha Nac.";
            this.fechaNacimiento.Name = "fechaNacimiento";
            // 
            // celular
            // 
            this.celular.HeaderText = "Celular";
            this.celular.Name = "celular";
            // 
            // butSeleccionarTodoEnviar
            // 
            this.butSeleccionarTodoEnviar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butSeleccionarTodoEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butSeleccionarTodoEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSeleccionarTodoEnviar.Location = new System.Drawing.Point(13, 3);
            this.butSeleccionarTodoEnviar.Name = "butSeleccionarTodoEnviar";
            this.butSeleccionarTodoEnviar.Size = new System.Drawing.Size(115, 25);
            this.butSeleccionarTodoEnviar.TabIndex = 75;
            this.butSeleccionarTodoEnviar.Tag = "";
            this.butSeleccionarTodoEnviar.Text = "Seleccionar Todo";
            this.butSeleccionarTodoEnviar.UseVisualStyleBackColor = false;
            this.butSeleccionarTodoEnviar.Click += new System.EventHandler(this.butSeleccionarTodoEnviar_Click);
            // 
            // butEnviarLista
            // 
            this.butEnviarLista.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butEnviarLista.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butEnviarLista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEnviarLista.Location = new System.Drawing.Point(6, 512);
            this.butEnviarLista.Name = "butEnviarLista";
            this.butEnviarLista.Size = new System.Drawing.Size(106, 27);
            this.butEnviarLista.TabIndex = 77;
            this.butEnviarLista.Tag = "";
            this.butEnviarLista.Text = "Enviar Lista";
            this.butEnviarLista.UseVisualStyleBackColor = false;
            this.butEnviarLista.Click += new System.EventHandler(this.butEnviarLista_Click);
            // 
            // butBorrarSeleccionados
            // 
            this.butBorrarSeleccionados.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butBorrarSeleccionados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butBorrarSeleccionados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBorrarSeleccionados.Location = new System.Drawing.Point(136, 3);
            this.butBorrarSeleccionados.Name = "butBorrarSeleccionados";
            this.butBorrarSeleccionados.Size = new System.Drawing.Size(122, 25);
            this.butBorrarSeleccionados.TabIndex = 76;
            this.butBorrarSeleccionados.Tag = "";
            this.butBorrarSeleccionados.Text = "Borrar Seleccionados";
            this.butBorrarSeleccionados.UseVisualStyleBackColor = false;
            this.butBorrarSeleccionados.Click += new System.EventHandler(this.butBorrarSeleccionados_Click);
            // 
            // butInsertarNombre
            // 
            this.butInsertarNombre.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butInsertarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butInsertarNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInsertarNombre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInsertarNombre.Location = new System.Drawing.Point(691, 1);
            this.butInsertarNombre.Name = "butInsertarNombre";
            this.butInsertarNombre.Size = new System.Drawing.Size(73, 19);
            this.butInsertarNombre.TabIndex = 78;
            this.butInsertarNombre.Tag = "";
            this.butInsertarNombre.Text = "*NOMBRE*";
            this.butInsertarNombre.UseVisualStyleBackColor = false;
            this.butInsertarNombre.Click += new System.EventHandler(this.butInsertarNombre_Click);
            // 
            // butInsertarApellido
            // 
            this.butInsertarApellido.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butInsertarApellido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butInsertarApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInsertarApellido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInsertarApellido.Location = new System.Drawing.Point(768, 1);
            this.butInsertarApellido.Name = "butInsertarApellido";
            this.butInsertarApellido.Size = new System.Drawing.Size(82, 19);
            this.butInsertarApellido.TabIndex = 79;
            this.butInsertarApellido.Tag = "";
            this.butInsertarApellido.Text = "*APELLIDO*";
            this.butInsertarApellido.UseVisualStyleBackColor = false;
            this.butInsertarApellido.Click += new System.EventHandler(this.butInsertarApellido_Click);
            // 
            // butInsertarDni
            // 
            this.butInsertarDni.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butInsertarDni.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butInsertarDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInsertarDni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInsertarDni.Location = new System.Drawing.Point(854, 1);
            this.butInsertarDni.Name = "butInsertarDni";
            this.butInsertarDni.Size = new System.Drawing.Size(62, 19);
            this.butInsertarDni.TabIndex = 80;
            this.butInsertarDni.Tag = "";
            this.butInsertarDni.Text = "*DNI*";
            this.butInsertarDni.UseVisualStyleBackColor = false;
            this.butInsertarDni.Click += new System.EventHandler(this.butInsertarDni_Click);
            // 
            // frmNotificacionesSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1054, 633);
            this.Name = "frmNotificacionesSMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar Notificaciones por SMS";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgListaEnviar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbClubB;
        public System.Windows.Forms.ComboBox cbLigaB;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbFiltro;
        private System.Windows.Forms.Label lbCantRegistros;
        private System.Windows.Forms.Label lbListaEnviar;
        protected System.Windows.Forms.Button butAgregarALista;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbCategoriaB;
        private System.Windows.Forms.TextBox tbMensaje;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Button butSeleccionarTodo;
        private System.Windows.Forms.DataGridView dgListaEnviar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn ligaTexto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clubTexto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn celular;
        protected System.Windows.Forms.Button butSeleccionarTodoEnviar;
        protected System.Windows.Forms.Button butEnviarLista;
        protected System.Windows.Forms.Button butBorrarSeleccionados;
        protected System.Windows.Forms.Button butInsertarDni;
        protected System.Windows.Forms.Button butInsertarApellido;
        protected System.Windows.Forms.Button butInsertarNombre;
    }
}
