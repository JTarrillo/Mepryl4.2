using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocioMepryl;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmClubMantenimiento : DevExpress.XtraEditors.XtraForm
    {
        private CapaNegocioMepryl.ClubMantenimiento Club;
        private bool blnModificar = false;
        private bool blnFilaNueva = false;
        private int intFilaSelecc = 0;
        string strValorComboFiltro = "";
        
        public frmClubMantenimiento()
        {
            Club = new CapaNegocioMepryl.ClubMantenimiento();
            InitializeComponent();
            InicializarDataGridView();            
            CargarDatosDGV();
            NumerarFilas();
            CargarLigasActivas();
        }

        public frmClubMantenimiento(frmBasePrincipal parentForm)
        {
            Club = new CapaNegocioMepryl.ClubMantenimiento();
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            InicializarDataGridView();
            CargarDatosDGV();
            NumerarFilas();
            CargarLigasActivas();
        }

        private void InicializarDataGridView()
        {            
            AgregarColumnaDGV("Id", "Id", false, "Text");
            AgregarColumnaDGV("Codigo", "Codigo", false, "Text");
            AgregarColumnaDGV("LigaId", "LigaId", false, "Text");
            AgregarColumnaDGV("CodigoLiga", "CodigoLiga", false, "Text");
            AgregarColumnaDGV("Club", "Club", true, "Text");
            AgregarColumnaDGV("Escudo", "Escudo", true, "Image");
            AgregarColumnaDGV("Liga", "Nombre Liga", true, "Text");            
            AgregarColumnaDGV("Activo", "Activo", true, "CheckBox");            
            AgregarColumnaDGV("PathImagen", "Path Imagen", false, "Text");
            AgregarColumnaDGV("Direccion1", "Dirección", false, "Text");
            AgregarColumnaDGV("Direccion2", "Direccion Movil", false, "Text");
            AgregarColumnaDGV("Contacto", "Delegado", false, "Text");
            AgregarColumnaDGV("Telefono", "Teléfono", false, "Text");
            AgregarColumnaDGV("Mail", "E-Mail", false, "Text");
            AgregarColumnaDGV("Url", "Url", false, "Text");
            AgregarColumnaDGV("Mapa", "Ver Mapa", true, "Button");
                        
            dgvLiga.Columns[0].Width = 50;
            dgvLiga.Columns[1].Width = 50;
            dgvLiga.Columns[2].Width = 50;
            dgvLiga.Columns[3].Width = 50;
            dgvLiga.Columns[4].Width = 250;
            dgvLiga.Columns[5].Width = 90;
            dgvLiga.Columns[6].Width = 160;
            dgvLiga.Columns[7].Width = 80;
            dgvLiga.Columns[8].Width = 110;
            dgvLiga.Columns[15].Width = 60;

            dgvLiga.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
        }

        private void AgregarColumnaDGV(string nombreOculto, string nombreAMostrar, bool visible, string TipoColumna)
        {
            switch (TipoColumna)
            {
                case "CheckBox":
                    DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
                    dgvLiga.Columns.Add(col1);
                    dgvLiga.Columns[7].Name = nombreOculto;
                    dgvLiga.Columns[7].HeaderText = nombreAMostrar;
                    dgvLiga.Columns[7].Visible = visible;
                    break;
                case "Image":
                    DataGridViewImageColumn col2 = new DataGridViewImageColumn();
                    col2.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dgvLiga.Columns.Add(col2);
                    dgvLiga.Columns[5].Name = nombreOculto;
                    dgvLiga.Columns[5].HeaderText = nombreAMostrar;
                    dgvLiga.Columns[5].Visible = visible;                    
                    break;
                case "Button":
                    //DataGridViewButtonColumn col3 = new DataGridViewButtonColumn();                    
                    DataGridViewImageColumn col3 = new DataGridViewImageColumn();
                    col3.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dgvLiga.Columns.Add(col3);
                    dgvLiga.Columns[15].Name = nombreOculto;
                    dgvLiga.Columns[15].HeaderText = nombreAMostrar;
                    dgvLiga.Columns[15].Visible = visible;
                    break;
                default:
                    dgvLiga.Columns.Add(nombreOculto, nombreAMostrar);
                    dgvLiga.Columns[nombreOculto].Visible = visible;
                    break;
            }
        }

        private void CargarDatosDGV()
        {
            if (dgvLiga.Rows.Count > 0)
                dgvLiga.Rows.Clear();

            if (strValorComboFiltro == "Todos" || strValorComboFiltro == "")
            {
                foreach (DataRow r in Club.MostrarClubConFiltro(txtBuscar.Text).Rows)
                {
                    dgvLiga.Rows.Add(r.ItemArray);
                }
            }
            else
            {
                foreach (DataRow r in Club.MostrarClubConFiltro(txtBuscar.Text, strValorComboFiltro).Rows)
                {
                    dgvLiga.Rows.Add(r.ItemArray);
                }
            }

            ColorearFilas();
            RecargarImagen();
            NumerarFilas();
            MostrarIconoMapa();
            ModoEdicion(true);
            dgvLiga.AllowUserToAddRows = false; // Elimina la última fila en blanco
        }

        private void RecargarImagen()
        {
            for (int i = 0; i < dgvLiga.Rows.Count - 1; i++)
            {
                try
                {
                    if (!(string.IsNullOrEmpty(dgvLiga.Rows[i].Cells[8].Value.ToString())))
                        dgvLiga.Rows[i].Cells[5].Value = Image.FromFile(dgvLiga.Rows[i].Cells[8].Value.ToString());
                    else
                        dgvLiga.Rows[i].Cells[5].Value = Image.FromFile("P:\\img-system\\mMapaNo36x36.png");
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    Bitmap bmpFlag = new Bitmap(36, 36);
                    dgvLiga.Rows[i].Cells[5].Value = bmpFlag;
                }
            }
        }

        private void MostrarIconoMapa()
        {
            for (int i = 0; i < dgvLiga.Rows.Count - 1; i++)
            {
                try
                {
                    if (!(string.IsNullOrEmpty(dgvLiga.Rows[i].Cells[14].Value.ToString())))
                        dgvLiga.Rows[i].Cells[15].Value = Image.FromFile("P:\\img-system\\globe_2.png");
                    else
                        dgvLiga.Rows[i].Cells[15].Value = Image.FromFile("P:\\img-system\\mMapaNo36x36.png");
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    Bitmap bmpFlag = new Bitmap(36, 36);
                    dgvLiga.Rows[i].Cells[15].Value = bmpFlag;
                }
            }

            dgvLiga.Columns[15].HeaderText = "Ver Mapa";
        }

        private void ModoEdicion(bool blnEditar)
        {
            // true Activa modo ReadOnly
            // false Desactiva permitiendo la edición
            foreach (DataGridViewRow fila in dgvLiga.Rows)
            {
                fila.ReadOnly = blnEditar;
            }
        }

        private void ColorearFilas()
        { 
            string strValor = "";

            for (int i = 0; i < dgvLiga.Rows.Count - 1; i++) 
            {
                strValor = dgvLiga.Rows[i].Cells[7].Value.ToString();
                if (Boolean.Parse(strValor))
                    dgvLiga.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarDatosDGV();
        }

        private void ResaltaLigaActiva()
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgvLiga.Rows[dgvLiga.CurrentRow.Index].Cells[7];

            if (ch1.Value == null)
                ch1.Value = false;
            
            switch (ch1.Value.ToString())
            {
                case "True":
                    {                        
                        ch1.Value = false;
                        dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
                        break;
                    }
                case "False":
                    {
                        ch1.Value = true;
                        dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                        break;
                    }
            }
        }

        private void dgvLiga_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvLiga_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvLiga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                ResaltaLigaActiva();
                botGuardar_Click(sender, e);
            }
        }

        private void dgvLiga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLiga.CurrentRow.Index == (dgvLiga.Rows.Count - 1))
            {
                dgvLiga.CurrentRow.ReadOnly = false;
                blnFilaNueva = true;
                intFilaSelecc = dgvLiga.CurrentCell.RowIndex;
            }

            if (e.ColumnIndex == 15 && e.RowIndex != -1)
            {
                AbrirMapa(Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[14].Value));
            }
        }        

        private void dgvLiga_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 4 && e.RowIndex != -1)
            //{
            //    dgvLiga.Rows[e.RowIndex].Height = 90;
            //    dgvLiga.Cursor = Cursors.Hand;
            //    dgvLiga.Rows[e.RowIndex].Cells[4].ToolTipText = "Doble click para modificar la imagen";                
            //}
            //else
            //{
            //    dgvLiga.Cursor = Cursors.Default;
            //}
            if (e.ColumnIndex == 15 && e.RowIndex != -1)
            {
                dgvLiga.Cursor = Cursors.Hand;
            }
            else
            {
                dgvLiga.Cursor = Cursors.Default;
            }
        }

        private void dgvLiga_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 4 && e.RowIndex != -1)
            //    dgvLiga.Rows[e.RowIndex].Height = 22;            
        }
        
        private void dgvLiga_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.ColumnIndex == 4 && e.RowIndex == intFilaSelecc && (blnModificar == true || blnFilaNueva == true))
            //    AbrirArchivo(e.RowIndex);
        }

        private void AbrirArchivo(int intIndiceFila)
        {
            OpenFileDialog ofdAbrirArchivo = new OpenFileDialog();

            ofdAbrirArchivo.Filter = "JPEG|*.jpg;*.jpeg;*.jpe|PNG|*.png";

            if (ofdAbrirArchivo.ShowDialog() == DialogResult.OK)
            {
                string strImagen = ofdAbrirArchivo.FileName;
                dgvLiga.Rows[intIndiceFila].Cells[5].Value = Image.FromFile(strImagen);
                dgvLiga.Rows[intIndiceFila].Cells[8].Value = strImagen;
            }
        }

        private void NumerarFilas()
        {          
	        if (dgvLiga != null) 
            {
                foreach (DataGridViewRow r in dgvLiga.Rows) 
                {
			        r.HeaderCell.Value = (r.Index + 1).ToString();
		        }

                dgvLiga.RowHeadersWidth = 50;                
	        }
        }

        private void EtiquetaEmergente()
        {
            ToolTip ttMensaje = new ToolTip();
            ttMensaje.AutoPopDelay = 5000;
            ttMensaje.InitialDelay = 1000;
            ttMensaje.ReshowDelay = 500;
            ttMensaje.ShowAlways = true;
            ttMensaje.SetToolTip(this.btnSalir, "");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            blnModificar = true;
            intFilaSelecc = dgvLiga.CurrentCell.RowIndex;
            //modificarFila();
            //btnModificar.Enabled = false;
            
            frmModificarClubes frmVentana = new frmModificarClubes(
                dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[0].Value.ToString(),
                Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[1].Value),
                Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[2].Value),
                Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[3].Value),
                Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[6].Value),
                Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[4].Value),
                Convert.ToBoolean(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[7].Value),
                Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[8].Value),
                Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[9].Value),
                Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[10].Value),
                Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[11].Value),
                Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[12].Value),
                Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[13].Value),
                Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[14].Value),
                true);                
            frmVentana.ShowDialog();            
            CargarDatosDGV();
            dgvLiga.Rows[intFilaSelecc].Selected = true;
            dgvLiga.CurrentCell = dgvLiga.Rows[intFilaSelecc].Cells[4];
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void modificarFila()
        {            
            dgvLiga.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[2].Selected = true;            
            dgvLiga.CurrentRow.ReadOnly = false;
            dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            dgvLiga.Focus();            
            
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                
            }
        }

        private void guardar() 
        {            
            blnModificar = false;
            blnFilaNueva = false;
            Club.ActualizarClub(ObtenerDatosDGV(dgvLiga));
            dgvLiga.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                        
            btnModificar.Enabled = true;
            ColorearFilas();
            //CargarDatosDGV();
        }

        private DataTable ObtenerDatosDGV(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            dt.Columns.Add("Id", typeof(System.String));
            dt.Columns.Add("Codigo", typeof(System.String));
            dt.Columns.Add("IdLiga", typeof(System.String));
            dt.Columns.Add("CodigoLiga", typeof(System.String));
            dt.Columns.Add("NombreClub", typeof(System.String));
            dt.Columns.Add("Activo", typeof(System.Boolean));
            dt.Columns.Add("PathImagen", typeof(System.String));
            dt.Columns.Add("Direccion1", typeof(System.String));
            dt.Columns.Add("Direccion2", typeof(System.String));
            dt.Columns.Add("Contacto", typeof(System.String));
            dt.Columns.Add("Telefono", typeof(System.String));
            dt.Columns.Add("Mail", typeof(System.String));
            dt.Columns.Add("URL", typeof(System.String));
            
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataRow row = dt.NewRow();
                
                row["Id"] = dgv.Rows[i].Cells[0].Value;
                row["Codigo"] = Convert.ToString(dgv.Rows[i].Cells[1].Value);
                row["IdLiga"] = Convert.ToString(dgv.Rows[i].Cells[2].Value);
                row["CodigoLiga"] = Convert.ToString(dgv.Rows[i].Cells[3].Value);
                row["NombreClub"] = Convert.ToString(dgv.Rows[i].Cells[4].Value);
                row["Activo"] = Convert.ToBoolean(dgv.Rows[i].Cells[7].Value);
                row["PathImagen"] = Convert.ToString(dgv.Rows[i].Cells[8].Value);
                row["Direccion1"] = Convert.ToString(dgv.Rows[i].Cells[9].Value);
                row["Direccion2"] = Convert.ToString(dgv.Rows[i].Cells[10].Value);
                row["Contacto"] = Convert.ToString(dgv.Rows[i].Cells[11].Value);
                row["Telefono"] = Convert.ToString(dgv.Rows[i].Cells[12].Value);
                row["Mail"] = Convert.ToString(dgv.Rows[i].Cells[13].Value);
                row["URL"] = Convert.ToString(dgv.Rows[i].Cells[14].Value);

                dt.Rows.Add(row);            
            }

            return dt;
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }

        private Guid ConvertirGuid(string gidDato)
        {
            Guid gidValor;

            try
            {
                gidValor = new Guid(gidDato);
            }
            catch
            {
                gidValor = Guid.Empty;
            }

            return gidValor;
        }        

        private void botCancelar_Click(object sender, EventArgs e)
        {
            string strID = "";

            DialogResult drResultado = MessageBox.Show("Este club será eliminada...  \n¿Seguro que desea proceder?", "Mantenimiento de Ligas", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (drResultado == DialogResult.Yes)
            {
                strID = dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[0].Value.ToString();

                if (!(string.IsNullOrEmpty(strID)))
                {
                    Club.EliminarClub(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    CargarDatosDGV();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmModificarClubes frmVentana = new frmModificarClubes("", "", "", "", "", "", false, "", "", "", "", "", "", "", false);
            frmVentana.ShowDialog();
            CargarDatosDGV();
        }

        private void AbrirMapa(string strUrlMapa)
        {
            if (!(string.IsNullOrEmpty(strUrlMapa)))
                System.Diagnostics.Process.Start(strUrlMapa);
            //else
            //    System.Diagnostics.Process.Start("https://www.google.com.ar/maps/place/Centro+M%C3%A9dico+Mepryl+-+MEPRYL+S.A./@-34.6246652,-58.380405,16.5z/data=!4m5!3m4!1s0x0:0x53314810fdad8caf!8m2!3d-34.624068!4d-58.378416");            
        }

        private void CargarLigasActivas()
        {
            LigaMantenimiento Liga = new LigaMantenimiento();            
            DataTable dtLigaActiva = Liga.LigasActivas();                      
            DataRow row;

            if (dtLigaActiva.Rows.Count > 0)
            {                
                cmbLigasActivas.Items.Add("Todos");

                for (int i = 1; i < dtLigaActiva.Rows.Count + 1; i++)
                {
                    row = dtLigaActiva.Rows[i - 1];             
                    cmbLigasActivas.Items.Add(row["descripcion"].ToString());
                }
                cmbLigasActivas.Text = "Todos";
            }
        }

        private void cmbLigasActivas_SelectedValueChanged(object sender, EventArgs e)
        {
            strValorComboFiltro = cmbLigasActivas.Text;
            //if (strValorComboFiltro != "Todos")
                CargarDatosDGV();            
        }

        private void botFiltrar_Click(object sender, EventArgs e)
        {
            CargarDatosDGV();
        }
    }
}
