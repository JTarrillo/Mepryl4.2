using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Threading;

namespace Comunes
{
	/// <summary>
	/// Summary description for ucRubroAlta.
	/// </summary>
	public class ucRubroAlta : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox gbModificacionProveedores;
		private System.Windows.Forms.Button butSalir;
		private System.Windows.Forms.Button butGuardar;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbRubro;
		private System.Windows.Forms.DataGrid dgSubRubros;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckedListBox clbCampos;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn tbDescripcion;

		public StatusBar statusBarPrincipal;
		public Form formContenedor;
		public string conexion = ""; //"SERVER=(local);DATABASE=Ligier;UID=sa;PWD=;";
		public Configuracion m_configuracion;
		public DataSet dataset = (DataSet) new dsRubros();
		private DataRow[] ultimosCampos;
		private bool recordarCambios = true;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox tbDescripcionArticulo;
		private System.Windows.Forms.ComboBox cbCampo1;
		private System.Windows.Forms.ComboBox cbCampo2;
		private System.Windows.Forms.ComboBox cbCampo3;
		private System.Windows.Forms.ComboBox cbCampo4;
		private System.Windows.Forms.ComboBox cbCampo5;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private bool habilitarHandlerCombos = true;
		private bool habilitarHandlerRowChanged = true;
		private System.Windows.Forms.Button butBorrarSubRubros;
		private System.Windows.Forms.Label lblTituloCampos;
		private System.Windows.Forms.GroupBox gbDescripcion;
		public static bool combosEstanOcupadas = false;

		public ucRubroAlta()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		public Configuracion configuracion
		{
			get
			{
				return m_configuracion;
			}
			set
			{
				m_configuracion = value;
				if (m_configuracion!=null)
					conexion = m_configuracion.getConectionString();
			}
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucRubroAlta));
			this.gbModificacionProveedores = new System.Windows.Forms.GroupBox();
			this.butBorrarSubRubros = new System.Windows.Forms.Button();
			this.gbDescripcion = new System.Windows.Forms.GroupBox();
			this.cbCampo5 = new System.Windows.Forms.ComboBox();
			this.cbCampo4 = new System.Windows.Forms.ComboBox();
			this.cbCampo3 = new System.Windows.Forms.ComboBox();
			this.cbCampo2 = new System.Windows.Forms.ComboBox();
			this.cbCampo1 = new System.Windows.Forms.ComboBox();
			this.tbDescripcionArticulo = new System.Windows.Forms.TextBox();
			this.lblTituloCampos = new System.Windows.Forms.Label();
			this.clbCampos = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgSubRubros = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.tbDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tbRubro = new System.Windows.Forms.TextBox();
			this.butSalir = new System.Windows.Forms.Button();
			this.butGuardar = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.gbModificacionProveedores.SuspendLayout();
			this.gbDescripcion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSubRubros)).BeginInit();
			this.SuspendLayout();
			// 
			// gbModificacionProveedores
			// 
			this.gbModificacionProveedores.Controls.Add(this.butBorrarSubRubros);
			this.gbModificacionProveedores.Controls.Add(this.gbDescripcion);
			this.gbModificacionProveedores.Controls.Add(this.lblTituloCampos);
			this.gbModificacionProveedores.Controls.Add(this.clbCampos);
			this.gbModificacionProveedores.Controls.Add(this.label1);
			this.gbModificacionProveedores.Controls.Add(this.dgSubRubros);
			this.gbModificacionProveedores.Controls.Add(this.tbRubro);
			this.gbModificacionProveedores.Controls.Add(this.butSalir);
			this.gbModificacionProveedores.Controls.Add(this.butGuardar);
			this.gbModificacionProveedores.Controls.Add(this.label22);
			this.gbModificacionProveedores.Location = new System.Drawing.Point(8, 40);
			this.gbModificacionProveedores.Name = "gbModificacionProveedores";
			this.gbModificacionProveedores.Size = new System.Drawing.Size(648, 416);
			this.gbModificacionProveedores.TabIndex = 114;
			this.gbModificacionProveedores.TabStop = false;
			// 
			// butBorrarSubRubros
			// 
			this.butBorrarSubRubros.BackColor = System.Drawing.Color.Maroon;
			this.butBorrarSubRubros.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butBorrarSubRubros.ForeColor = System.Drawing.Color.White;
			this.butBorrarSubRubros.Image = ((System.Drawing.Image)(resources.GetObject("butBorrarSubRubros.Image")));
			this.butBorrarSubRubros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBorrarSubRubros.Location = new System.Drawing.Point(248, 56);
			this.butBorrarSubRubros.Name = "butBorrarSubRubros";
			this.butBorrarSubRubros.Size = new System.Drawing.Size(64, 23);
			this.butBorrarSubRubros.TabIndex = 101;
			this.butBorrarSubRubros.Text = "&Borrar";
			this.butBorrarSubRubros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBorrarSubRubros.Click += new System.EventHandler(this.butBorrarSubRubros_Click);
			// 
			// gbDescripcion
			// 
			this.gbDescripcion.Controls.Add(this.cbCampo5);
			this.gbDescripcion.Controls.Add(this.cbCampo4);
			this.gbDescripcion.Controls.Add(this.cbCampo3);
			this.gbDescripcion.Controls.Add(this.cbCampo2);
			this.gbDescripcion.Controls.Add(this.cbCampo1);
			this.gbDescripcion.Controls.Add(this.tbDescripcionArticulo);
			this.gbDescripcion.Location = new System.Drawing.Point(8, 328);
			this.gbDescripcion.Name = "gbDescripcion";
			this.gbDescripcion.Size = new System.Drawing.Size(528, 80);
			this.gbDescripcion.TabIndex = 100;
			this.gbDescripcion.TabStop = false;
			this.gbDescripcion.Text = "Campos que componen la Descripción del Artículo";
			// 
			// cbCampo5
			// 
			this.cbCampo5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCampo5.Items.AddRange(new object[] {
														  "---"});
			this.cbCampo5.Location = new System.Drawing.Point(424, 16);
			this.cbCampo5.Name = "cbCampo5";
			this.cbCampo5.Size = new System.Drawing.Size(96, 21);
			this.cbCampo5.TabIndex = 98;
			this.cbCampo5.SelectedIndexChanged += new System.EventHandler(this.cbCampo5_SelectedIndexChanged);
			// 
			// cbCampo4
			// 
			this.cbCampo4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCampo4.Items.AddRange(new object[] {
														  "---"});
			this.cbCampo4.Location = new System.Drawing.Point(320, 16);
			this.cbCampo4.Name = "cbCampo4";
			this.cbCampo4.Size = new System.Drawing.Size(96, 21);
			this.cbCampo4.TabIndex = 97;
			this.cbCampo4.SelectedIndexChanged += new System.EventHandler(this.cbCampo4_SelectedIndexChanged);
			// 
			// cbCampo3
			// 
			this.cbCampo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCampo3.Items.AddRange(new object[] {
														  "---"});
			this.cbCampo3.Location = new System.Drawing.Point(216, 16);
			this.cbCampo3.Name = "cbCampo3";
			this.cbCampo3.Size = new System.Drawing.Size(96, 21);
			this.cbCampo3.TabIndex = 96;
			this.cbCampo3.SelectedIndexChanged += new System.EventHandler(this.cbCampo3_SelectedIndexChanged);
			// 
			// cbCampo2
			// 
			this.cbCampo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCampo2.Items.AddRange(new object[] {
														  "---"});
			this.cbCampo2.Location = new System.Drawing.Point(112, 16);
			this.cbCampo2.Name = "cbCampo2";
			this.cbCampo2.Size = new System.Drawing.Size(96, 21);
			this.cbCampo2.TabIndex = 95;
			this.cbCampo2.SelectedIndexChanged += new System.EventHandler(this.cbCampo2_SelectedIndexChanged);
			// 
			// cbCampo1
			// 
			this.cbCampo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCampo1.Items.AddRange(new object[] {
														  "---"});
			this.cbCampo1.Location = new System.Drawing.Point(8, 16);
			this.cbCampo1.Name = "cbCampo1";
			this.cbCampo1.Size = new System.Drawing.Size(96, 21);
			this.cbCampo1.TabIndex = 94;
			this.cbCampo1.SelectedIndexChanged += new System.EventHandler(this.cbCampo1_SelectedIndexChanged);
			// 
			// tbDescripcionArticulo
			// 
			this.tbDescripcionArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDescripcionArticulo.Location = new System.Drawing.Point(8, 48);
			this.tbDescripcionArticulo.Multiline = true;
			this.tbDescripcionArticulo.Name = "tbDescripcionArticulo";
			this.tbDescripcionArticulo.ReadOnly = true;
			this.tbDescripcionArticulo.Size = new System.Drawing.Size(512, 24);
			this.tbDescripcionArticulo.TabIndex = 93;
			this.tbDescripcionArticulo.Text = "";
			this.tbDescripcionArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblTituloCampos
			// 
			this.lblTituloCampos.Location = new System.Drawing.Point(328, 16);
			this.lblTituloCampos.Name = "lblTituloCampos";
			this.lblTituloCampos.Size = new System.Drawing.Size(296, 14);
			this.lblTituloCampos.TabIndex = 97;
			this.lblTituloCampos.Text = "Campos para el Sub Rubro";
			// 
			// clbCampos
			// 
			this.clbCampos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.clbCampos.CheckOnClick = true;
			this.clbCampos.Location = new System.Drawing.Point(328, 32);
			this.clbCampos.Name = "clbCampos";
			this.clbCampos.Size = new System.Drawing.Size(312, 287);
			this.clbCampos.TabIndex = 96;
			this.clbCampos.Enter += new System.EventHandler(this.clbCampos_Enter);
			this.clbCampos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCampos_ItemCheck);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 14);
			this.label1.TabIndex = 94;
			this.label1.Text = "Sub Rubros";
			// 
			// dgSubRubros
			// 
			this.dgSubRubros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dgSubRubros.CaptionVisible = false;
			this.dgSubRubros.DataMember = "";
			this.dgSubRubros.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgSubRubros.Location = new System.Drawing.Point(8, 80);
			this.dgSubRubros.Name = "dgSubRubros";
			this.dgSubRubros.Size = new System.Drawing.Size(304, 240);
			this.dgSubRubros.TabIndex = 93;
			this.dgSubRubros.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			this.dgSubRubros.CurrentCellChanged += new System.EventHandler(this.dbSubRubros_CurrentCellChanged);
			this.dgSubRubros.Leave += new System.EventHandler(this.dgSubRubros_Leave);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.AllowSorting = false;
			this.dataGridTableStyle1.DataGrid = this.dgSubRubros;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.tbDescripcion,
																												  this.dataGridTextBoxColumn1});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "SubRubro";
			this.dataGridTableStyle1.RowHeadersVisible = false;
			// 
			// tbDescripcion
			// 
			this.tbDescripcion.Format = "";
			this.tbDescripcion.FormatInfo = null;
			this.tbDescripcion.HeaderText = "Nombre";
			this.tbDescripcion.MappingName = "descripcion";
			this.tbDescripcion.Width = 250;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.MappingName = "id";
			this.dataGridTextBoxColumn1.Width = 0;
			// 
			// tbRubro
			// 
			this.tbRubro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbRubro.Location = new System.Drawing.Point(8, 32);
			this.tbRubro.Name = "tbRubro";
			this.tbRubro.Size = new System.Drawing.Size(304, 20);
			this.tbRubro.TabIndex = 92;
			this.tbRubro.Text = "";
			// 
			// butSalir
			// 
			this.butSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butSalir.Image = ((System.Drawing.Image)(resources.GetObject("butSalir.Image")));
			this.butSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSalir.Location = new System.Drawing.Point(544, 372);
			this.butSalir.Name = "butSalir";
			this.butSalir.Size = new System.Drawing.Size(96, 24);
			this.butSalir.TabIndex = 99;
			this.butSalir.Text = "&Salir";
			this.butSalir.Click += new System.EventHandler(this.butSalir_Click);
			// 
			// butGuardar
			// 
			this.butGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butGuardar.Image = ((System.Drawing.Image)(resources.GetObject("butGuardar.Image")));
			this.butGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butGuardar.Location = new System.Drawing.Point(544, 340);
			this.butGuardar.Name = "butGuardar";
			this.butGuardar.Size = new System.Drawing.Size(96, 24);
			this.butGuardar.TabIndex = 98;
			this.butGuardar.Text = "&Guardar";
			this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(8, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(136, 14);
			this.label22.TabIndex = 91;
			this.label22.Text = "Rubro";
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.Green;
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(0, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(664, 32);
			this.label18.TabIndex = 113;
			this.label18.Text = "     Alta de Rubros";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Green;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 31);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 115;
			this.pictureBox1.TabStop = false;
			// 
			// ucRubroAlta
			// 
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.gbModificacionProveedores);
			this.Controls.Add(this.label18);
			this.Name = "ucRubroAlta";
			this.Size = new System.Drawing.Size(664, 456);
			this.gbModificacionProveedores.ResumeLayout(false);
			this.gbDescripcion.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgSubRubros)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		//Llena los comboBox y demas inicializaciones
		public void inicializarComponentes()
		{
			try
			{
				DataTable dataTableSubRubro = (DataTable)dataset.Tables["SubRubro"];
				dataTableSubRubro.RowChanged += new DataRowChangeEventHandler(dataTableSubRubro_RowChanged);
				dgSubRubros.DataSource = (DataTable)dataset.Tables["SubRubro"];


				//SqlParameter[] param = new SqlParameter[1];
				//param[0] = new SqlParameter("@tablaID", "1");
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_getAllts_Campos"); //, param);
			
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						clbCampos.Items.Add(dr["campoEtiqueta"].ToString());
					}
				}
				dr.Close();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Maneja el evento de modificacion de registros
		protected void dataTableSubRubro_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
		{
			if (habilitarHandlerRowChanged)
			{
				armarEstructuraDescripcion(e);
			}
		}


		private void colocarSubRubroIDs()
		{
			try
			{
				DataTable tabla = (DataTable)dgSubRubros.DataSource;
				
				if (tabla.Rows.Count>0)
				{
					for (int rowIndex = 0; rowIndex<tabla.Rows.Count; rowIndex++)
					{
						if (tabla.Rows[rowIndex].RowState!=DataRowState.Deleted)
						{
							string subRubroID = Utilidades.validarGUID((tabla.Rows[rowIndex]["id"].ToString()));
							if (subRubroID=="0")
							{
								tabla.Rows[rowIndex]["id"] = System.Guid.NewGuid().ToString();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void colocarSubRubroID()
		{
			try
			{
				//Pone el codigo unico en el subrubro
				string subRubroID = Utilidades.validarGUID(dgSubRubros[dgSubRubros.CurrentRowIndex, 1].ToString());
				string descripcion = dgSubRubros[dgSubRubros.CurrentRowIndex, 0].ToString();
				if (subRubroID=="0" && descripcion!="")
				{
					dgSubRubros[dgSubRubros.CurrentRowIndex, 1] = System.Guid.NewGuid().ToString();
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void dbSubRubros_CurrentCellChanged(object sender, System.EventArgs e)
		{
			mostrarSubRubro();
			colocarSubRubroIDs();
			componerSubRubroCampos();
			//En observacion
			cargarCamposCombosDescripcion();
			
			
			acomodarCombosEstructura();
		}

		//Muestra el Sub Rubro seleccionado
		private void mostrarSubRubro()
		{
			int row = dgSubRubros.CurrentCell.RowNumber;
			DataTable dt = (DataTable)dgSubRubros.DataSource;
			string subRubro = "";
			if (dt.Rows.Count>row)
				subRubro = dt.Rows[row]["descripcion"].ToString();

			lblTituloCampos.Text = "Campos para: " + subRubro;
			gbDescripcion.Text = "Descripción para: " + subRubro;

			dt = null;
		}

		private void clbCampos_Enter(object sender, System.EventArgs e)
		{
			if (dgSubRubros.CurrentRowIndex>-1)
			{
				colocarSubRubroID();

				//Toma de la tabla los campos que tiene
				componerSubRubroCampos();
			}
		}

		private void componerSubRubroCampos()
		{
			try
			{
				if (dgSubRubros.CurrentRowIndex==-1)
				{
					MessageBox.Show("Debe seleccionar un Sub Rubro.", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					//Marca que no hay que recordar los cambios en la lista
					recordarCambios = false;
					colocarSubRubroID();
					string subRubroID = Utilidades.validarGUID(dgSubRubros[dgSubRubros.CurrentRowIndex, 1].ToString());

					//Obtiene la lista de campos para este Sub Rubro
					DataRow[] rows = dataset.Tables["SubRubroCampo"].Select("subRubroID='" + subRubroID + "'");

					bool encontrado;
					//Si no tiene campos, toma los campos del ultimo sub rubro
					if (rows.Length==0)
					{
						//Deselecciona primero
						for (int i=0; i<clbCampos.Items.Count; i++)
							clbCampos.SetItemChecked(i, false);

						//Selecciona los campos del recuerdo
						for (int i=0; i<clbCampos.Items.Count; i++)
						{
							if (ultimosCampos!=null ? ultimosCampos.Length==0 : true)
								clbCampos.SetItemChecked(i, false);
							else
							{
								encontrado = false;
								for (int j=0; j<ultimosCampos.Length; j++)
								{
									if (ultimosCampos[j]["campoEtiqueta"].ToString()==clbCampos.Items[i].ToString())
									{
										encontrado = true;
										clbCampos.SetItemChecked(i, true);
										break;
									}
								}
								if (!encontrado)
									clbCampos.SetItemChecked(i, false);
							}
						}
					}
					else
					{
						//Selecciona los campos que corresponden al resultado
						for (int i=0; i<clbCampos.Items.Count; i++)
						{
							if (rows.Length==0)
								clbCampos.SetItemChecked(i, false);
							else
							{
								encontrado = false;
								for (int j=0; j<rows.Length; j++)
								{
									if (rows[j]["campoEtiqueta"].ToString()==clbCampos.Items[i].ToString())
									{
										encontrado = true;
										clbCampos.SetItemChecked(i, true);
										break;
									}
								}
								if (!encontrado)
									clbCampos.SetItemChecked(i, false);
							}
						}

						//Guarda en el recuerdo los campos seleccionados para este sub rubro
						ultimosCampos = (DataRow[])rows.Clone();
					}
					recordarCambios = true;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void clbCampos_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			try
			{
				if (dgSubRubros.CurrentRowIndex==-1)
				{
					MessageBox.Show("Debe seleccionar un Sub Rubro.", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					DataTable tabla = dataset.Tables["SubRubroCampo"];
					//Graba o borra el campo seleccionado de la tabla de campos
					if (e.NewValue==CheckState.Checked)
					{
						DataRow row = tabla.NewRow();
						//Cambios MMM
						string subRubroID = Utilidades.validarGUID(dgSubRubros[dgSubRubros.CurrentRowIndex, 1].ToString());
						if (tabla.Select("subRubroID='" + subRubroID + "' AND campoNombre='" + clbCampos.Items[e.Index].ToString() + "'").Length < 1)
						{
							row["id"] = System.Guid.NewGuid().ToString();
							row["campoNombre"] = clbCampos.Items[e.Index].ToString();
							row["campoEtiqueta"] = clbCampos.Items[e.Index].ToString();
							row["subRubroID"] = Utilidades.validarGUID(dgSubRubros[dgSubRubros.CurrentRowIndex, 1].ToString());
							tabla.Rows.Add(row);
						}		
						tabla.AcceptChanges();
						if (recordarCambios)
							ultimosCampos = (DataRow[])tabla.Select("subRubroID='" + row["subRubroID"].ToString() + "'").Clone();
					}
					else //Si es deschequeado
					{
						//Solo si hay subRubroID
						string subRubroID = Utilidades.validarGUID(dgSubRubros[dgSubRubros.CurrentRowIndex,1].ToString());
						if (subRubroID!="0")
						{
							//Busca el registro dentro de la tabla
							DataRow[] rows = tabla.Select("subRubroID='" + subRubroID + "'");
							if (rows.Length>0)
							{
								for (int i=0; i<rows.Length; i++)
								{
									//Si encuentra el campo
									if (rows[i]["campoEtiqueta"].ToString()==clbCampos.Items[e.Index].ToString())
									{
										//Borra el registro <------- Problema, nunca llega aca porque el subRubroID es del registro actual y se pretende borrar los cmpos del subrubro donde estaba parado anteriormente.
										tabla.Rows.Remove(rows[i]);
									}
								}
								tabla.AcceptChanges();
								if (recordarCambios)
									ultimosCampos = (DataRow[])tabla.Select("subRubroID='" + subRubroID + "'").Clone();
							}
						}
					}
					//Carga los items en los combos
					if (recordarCambios)
					{
						cargarCamposCombosDescripcion();
						armarEstructuraDescripcion(null);
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void cargarCamposCombosDescripcion()
		{
			try
			{
				//Si estan siendo ocupadas por otro proceso, espera
				while (combosEstanOcupadas)
					Thread.Sleep(200);


				//Marca el semaforo para ocupar las combos
				combosEstanOcupadas = true;

				//Obtiene el id del subRubro actual
				string subRubroID = Utilidades.validarGUID(dgSubRubros[dgSubRubros.CurrentRowIndex,1].ToString());

				//Obtiene una copia de la tabla
				DataRow[] rows = dataset.Tables["SubRubroCampo"].Copy().Select("subRubroID='" + subRubroID + "'", "campoNombre");
				DataTable tabla = dataset.Tables["SubRubroCampo"].Clone();

				//Agrega el primer registro
				DataRow dr = tabla.NewRow();
				dr["id"] = "0";
				dr["campoNombre"] = "---";
				dr["campoEtiqueta"] = "---";
				tabla.Rows.Add(dr);

				//Agrega los registros con campos
				for (int i=0; i<rows.Length; i++)
				{
					if (rows[i]["campoEtiqueta"].ToString()!="Descripción")
					{
						dr = tabla.NewRow();
						dr["id"] = rows[i]["id"];
						dr["campoNombre"] = rows[i]["campoNombre"];
						dr["campoEtiqueta"] = rows[i]["campoEtiqueta"];
						tabla.Rows.Add(dr);
					}
				}
			
				habilitarHandlerCombos = false;

				//Asigna la tabla como origen de datos.
				string itemSeleccionado = cbCampo1.Text;
				cbCampo1.DataSource = null;
				cbCampo1.DataSource = tabla;
				cbCampo1.DisplayMember = "campoNombre";
				cbCampo1.ValueMember = "id";
				UtilUI.comboSeleccionarItemByText(itemSeleccionado, ref cbCampo1);

				itemSeleccionado = cbCampo2.Text;
				cbCampo2.DataSource = null;
				cbCampo2.DataSource = tabla.Copy();
				cbCampo2.DisplayMember = "campoNombre";
				cbCampo2.ValueMember = "id";
				UtilUI.comboSeleccionarItemByText(itemSeleccionado, ref cbCampo2);

				itemSeleccionado = cbCampo3.Text;
				cbCampo3.DataSource = null;
				cbCampo3.DataSource = tabla.Copy();
				cbCampo3.DisplayMember = "campoNombre";
				cbCampo3.ValueMember = "id";
				UtilUI.comboSeleccionarItemByText(itemSeleccionado, ref cbCampo3);

				itemSeleccionado = cbCampo4.Text;
				cbCampo4.DataSource = null;
				cbCampo4.DataSource = tabla.Copy();
				cbCampo4.DisplayMember = "campoNombre";
				cbCampo4.ValueMember = "id";
				UtilUI.comboSeleccionarItemByText(itemSeleccionado, ref cbCampo4);

				itemSeleccionado = cbCampo5.Text;
				cbCampo5.DataSource = null;
				cbCampo5.DataSource = tabla.Copy();
				cbCampo5.DisplayMember = "campoNombre";
				cbCampo5.ValueMember = "id";
				UtilUI.comboSeleccionarItemByText(itemSeleccionado, ref cbCampo5);

				habilitarHandlerCombos = true;
			
				//Desocupa las combos
				combosEstanOcupadas = false;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void armarEstructuraDescripcion(System.Data.DataRowChangeEventArgs e)
		{
			try
			{
				//Espera hasta que se desocupen las combos
				while (combosEstanOcupadas)
					Thread.Sleep(200);

				combosEstanOcupadas = true;

				string texto = "";
				string coma = "";

				if (cbCampo1.Text!="---")
				{
					texto += coma + cbCampo1.Text;
					coma = ", ";
				}
				if (cbCampo2.Text!="---")
				{
					texto += coma + cbCampo2.Text;
					coma = ", ";
				}
				if (cbCampo3.Text!="---")
				{
					texto += coma + cbCampo3.Text;
					coma = ", ";
				}
				if (cbCampo4.Text!="---")
				{
					texto += coma + cbCampo4.Text;
					coma = ", ";
				}
				if (cbCampo5.Text!="---")
				{
					texto += coma + cbCampo5.Text;
				}
				tbDescripcionArticulo.Text = texto;

				combosEstanOcupadas = false;

			
				//Guarda el texto en el registro del subrubro
				DataTable subRubros = (DataTable)dgSubRubros.DataSource;
				habilitarHandlerRowChanged = false;

				if (e!=null)
					e.Row["cadenaDescripcion"] = texto;
				else
				{
					subRubros.Rows[dgSubRubros.CurrentRowIndex]["cadenaDescripcion"] = texto;
					subRubros.AcceptChanges();
				}
				habilitarHandlerRowChanged = true;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void acomodarCombosEstructura()
		{
			try
			{
				DataTable subRubros = (DataTable)dgSubRubros.DataSource;
				if (dgSubRubros.CurrentRowIndex<subRubros.Rows.Count)
				{
					string texto;
					if (subRubros.Rows[dgSubRubros.CurrentRowIndex].RowState!=DataRowState.Deleted)
						texto = subRubros.Rows[dgSubRubros.CurrentRowIndex]["cadenaDescripcion"].ToString();
					else
						texto = "";

					//Si hay una estructura guardada, la toma
					if (texto!="")
					{
						habilitarHandlerCombos = false;

						tbDescripcionArticulo.Text = texto;

						texto = texto.Replace(", ",":");
						string[] aTexto = texto.Split(":".ToCharArray());
					
						if (aTexto.Length>0)
							UtilUI.comboSeleccionarItemByText(aTexto[0], ref cbCampo1);
						else
							cbCampo1.SelectedIndex = 0;

						if (aTexto.Length>1)
							UtilUI.comboSeleccionarItemByText(aTexto[1], ref cbCampo2);
						else
							cbCampo2.SelectedIndex = 0;
					
						if (aTexto.Length>2)
							UtilUI.comboSeleccionarItemByText(aTexto[2], ref cbCampo3);
						else
							cbCampo3.SelectedIndex = 0;

						if (aTexto.Length>3)
							UtilUI.comboSeleccionarItemByText(aTexto[3], ref cbCampo4);
						else
							cbCampo4.SelectedIndex = 0;

						if (aTexto.Length>4)
							UtilUI.comboSeleccionarItemByText(aTexto[4], ref cbCampo5);
						else
							cbCampo5.SelectedIndex = 0;

						habilitarHandlerCombos = true;
					}
					else //Si no hay estructura guardada, guarda definida por la posicion de los combos
					{
						//armarEstructuraDescripcion();
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void butGuardar_Click(object sender, System.EventArgs e)
		{
			UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Guardando Registro...", true);
			if (validarFormulario())
			{
				DialogResult dr = MessageBox.Show("¿Desea guargar el Rubro y comenzar con uno nuevo?", "Alta de Rubros", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (dr== DialogResult.Yes)
					darAlta();
			}
			else
				UtilUI.trabajando(formContenedor, ref statusBarPrincipal, "Valores incorrectos.", false);
		}

		private bool validarFormulario()
		{
			try
			{
				string mensaje = "";
				bool resultado = true;
			
				if (tbRubro.Text.Trim()=="")
				{
					mensaje += "   - Debe ingresar el nombre del Rubro.\r\n";
					resultado = false;
				}       
                if (clbCampos.CheckedItems.Count==0)
                {
                    mensaje += "   - Debe seleccionar algún campo para habilitar la carga de artículos.\r\n";
                    resultado = false;
                }       

				if (mensaje!="")
				{
					mensaje = "Hay algunos valores incorrectos:\r\n\r\n" + mensaje;
					MessageBox.Show(mensaje, "Alta de Rubros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

			
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				return false;
			}
		}

		//Inserta un nuevo registro en la base de datos
		private void darAlta()
		{
			try
			{
				//Inserta el Rubro
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@descripcion", tbRubro.Text.Trim());
				SqlDataReader dr = SqlHelper.ExecuteReader(this.conexion, "sp_InsertRubro", param);

				//Inserta los subrubros
				if (dr.HasRows)
				{
					dr.Read();
					string rubroID = dr["ID"].ToString();
					string subRubroID = "";
					string descripcion = "";
					string cadenaDescripcion = "";

					DataTable dtSubRubros = (DataTable)dgSubRubros.DataSource;
					for (int i=0; i<dtSubRubros.Rows.Count; i++)
					{
						if (dtSubRubros.Rows[i].RowState!=DataRowState.Deleted)
						{
							if (dtSubRubros.Rows[i].RowState!=DataRowState.Deleted)
								descripcion = dtSubRubros.Rows[i]["descripcion"].ToString();
							else
								descripcion = "";

							cadenaDescripcion = dtSubRubros.Rows[i]["cadenaDescripcion"].ToString();
							if (descripcion.Trim()!="")
							{
								subRubroID = Utilidades.validarGUID(dtSubRubros.Rows[i]["id"].ToString());
								param = new SqlParameter[4];
								param[0] = new SqlParameter("@id", subRubroID);
								param[1] = new SqlParameter("@descripcion", descripcion);
								param[2] = new SqlParameter("@rubroID", new System.Guid(rubroID));
								param[3] = new SqlParameter("@cadenaDescripcion", cadenaDescripcion);
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertSubRubro", param);

								//Inserta los campos
								//Primero borra los campos existentes
								param = new SqlParameter[1];
								param[0] = new SqlParameter("@subRubroID", subRubroID);
								SqlHelper.ExecuteNonQuery(this.conexion, "sp_DeleteSubRubroCampos", param);

								//Toma los registros de la tabla de memoria
								DataRow[] campos = dataset.Tables["SubRubroCampo"].Select("subRubroID='" + subRubroID + "'");

								//Luego inserta uno a uno los campos
								for (int j=0; j<campos.Length; j++)
								{
									param = new SqlParameter[4];
									param[0] = new SqlParameter("@id", campos[j]["id"].ToString());
									param[1] = new SqlParameter("@subRubroID", Utilidades.validarGUID(campos[j]["subRubroID"].ToString()));
									param[2] = new SqlParameter("@campoNombre", campos[j]["campoNombre"].ToString());
									param[3] = new SqlParameter("@campoEtiqueta", campos[j]["campoEtiqueta"].ToString());
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_InsertSubRubroCampo", param);
								}
							}
						}
					}
				}
				dr.Close();
				MessageBox.Show("Rubro ingresado con éxito.", "Alta de Rubros", MessageBoxButtons.OK, MessageBoxIcon.Information);
				limpiarCamposUnicos();
				UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Rubro ingresado con éxito.", false);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		//Limpia los campos del formulario
		private void limpiarCamposUnicos()
		{
			tbRubro.Text = "";
		}

		private void butSalir_Click(object sender, System.EventArgs e)
		{
			((Form)this.Parent).Close();
		}

		private void cbCampo1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (habilitarHandlerCombos)
				armarEstructuraDescripcion(null);
		}

		private void cbCampo2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (habilitarHandlerCombos)
				armarEstructuraDescripcion(null);
		}

		private void cbCampo3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (habilitarHandlerCombos)
				armarEstructuraDescripcion(null);
		}

		private void cbCampo4_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (habilitarHandlerCombos)
				armarEstructuraDescripcion(null);
		}

		private void cbCampo5_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (habilitarHandlerCombos)
				armarEstructuraDescripcion(null);
		}

		private void butBorrarSubRubros_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (dgSubRubros.DataSource!=null)
				{
					DataTable dt = (DataTable)dgSubRubros.DataSource;
				
					if (dt.Rows.Count>0)
					{
						//Selecciona el registro actual
						if (dgSubRubros.CurrentCell.RowNumber>-1)
						{
							dgSubRubros.Select(dgSubRubros.CurrentCell.RowNumber);
						}
						//Primero recorre los renglones seleccionados
						string sRows = "";
						string coma = "";
						for (int i=0; i<dt.Rows.Count; i++)
						{
							if (dgSubRubros.IsSelected(i))
							{
								sRows += coma + dt.Rows[i]["id"].ToString() + ":" + i.ToString();
								coma = ",";
							}
						}

						if (sRows!="")
						{
							DialogResult dr = MessageBox.Show("¿Desea eliminar permanentemente los Sub Rubros seleccionados?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
							if (dr== DialogResult.Yes)
							{
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Borrando Sub Rubros...", true);
								SqlParameter[] param = new SqlParameter[1];
								string[] rows = sRows.Split(",".ToCharArray());
								for (int j=0; j<rows.Length; j++)
								{
									string id = rows[j].Split(":".ToCharArray())[0];
									int renglon = int.Parse(rows[j].Split(":".ToCharArray())[1]);

									//param[0] = new SqlParameter("@id", new System.Guid(id));
									param[0] = new SqlParameter("@id", id);
								
									SqlHelper.ExecuteNonQuery(this.conexion, "sp_BorrarSubRubro", param);

									//dt.Rows[renglon].Delete();
									dt.Rows[renglon]["id"] = "-1";
								}
								//Recorre los renglones marcados para borrar
								DataRow[] rowsBorrar = dt.Select("id='-1'");
								for (int k=0; k<rowsBorrar.Length; k++)
								{
									rowsBorrar[k].Delete();
								}
								dt.AcceptChanges();
								
								UtilUI.trabajando(this.formContenedor, ref this.statusBarPrincipal, "Listo.", false);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}

		private void dgSubRubros_Leave(object sender, System.EventArgs e)
		{
			mostrarSubRubro();
		}

	}
}
