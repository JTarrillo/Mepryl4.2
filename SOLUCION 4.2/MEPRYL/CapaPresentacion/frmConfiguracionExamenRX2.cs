using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocioMepryl;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmConfiguracionExamenRX2 : DevExpress.XtraEditors.XtraForm
    {
        //private CapaNegocioMepryl.ClubMantenimiento Club;
        private CapaNegocioMepryl.ConfiguracionExamenRX Config;
        private bool blnModificar = false;
        private bool blnFilaNueva = false;
        private int intFilaSelecc = 0;
        //private bool blnPrimerIngresoSistema = false;

        public frmConfiguracionExamenRX2()
        {
            //Club = new CapaNegocioMepryl.ClubMantenimiento();
            Config = new CapaNegocioMepryl.ConfiguracionExamenRX();
            InitializeComponent();
            InicializarDataGridView();
            CargarDatosDGV();
            //NumerarFilas();            
        }
        public frmConfiguracionExamenRX2(frmBasePrincipal parentForm)
        {
            //Club = new CapaNegocioMepryl.ClubMantenimiento();
            Config = new CapaNegocioMepryl.ConfiguracionExamenRX();
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            InicializarDataGridView();
            CargarDatosDGV();
            //NumerarFilas();            
        }

        private void InicializarDataGridView()
        {
            AgregarColumnaDGV("Id", "Id", false, "Text");
            AgregarColumnaDGV("Codigo", "Codigo", false, "Text");
            AgregarColumnaDGV("Liga", "Liga", true, "Text");
            AgregarColumnaDGV("Imagen", "Escudo", true, "Image");
            AgregarColumnaDGV("PathImagen", "Path Imagen", false, "Text");
            AgregarColumnaDGV("CategoriaInicial", "Cat. Inicial", true, "ComboBox");
            AgregarColumnaDGV("CategoriaFinal", "Cat. Final", true, "ComboBox");
            AgregarColumnaDGV("Desde", "Desde", true, "Calendar");
            AgregarColumnaDGV("Hasta", "Hasta", true, "Calendar");
            AgregarColumnaDGV("VerificaRX", "Verifica RX", true, "CheckBox");
            AgregarColumnaDGV("VerificaClub", "Verifica Club", true, "CheckBox");
            AgregarColumnaDGV("AdmiteMenores", "Admite Menores", true, "CheckBox");
            AgregarColumnaDGV("IdLiga", "IdLiga", false, "Text");

            dgvLiga.Columns[0].Width = 50;
            dgvLiga.Columns[1].Width = 50;
            dgvLiga.Columns[2].Width = 200;
            dgvLiga.Columns[3].Width = 60;
            dgvLiga.Columns[4].Width = 60;
            dgvLiga.Columns[5].Width = 80;
            dgvLiga.Columns[6].Width = 80;
            dgvLiga.Columns[7].Width = 110;
            dgvLiga.Columns[8].Width = 110;
            dgvLiga.Columns[9].Width = 80;
            dgvLiga.Columns[10].Width = 80;
            dgvLiga.Columns[11].Width = 100;
            dgvLiga.Columns[12].Width = 80;

            dgvLiga.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtBuscar.CharacterCasing = CharacterCasing.Upper;
            dgvLiga.Columns["Liga"].ReadOnly = true;
        }

        private void AgregarColumnaDGV(string nombreOculto, string nombreAMostrar, bool visible, string TipoColumna)
        {
            switch (TipoColumna)
            {
                case "CheckBox":
                    DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
                    dgvLiga.Columns.Add(col1);
                    dgvLiga.Columns[intFilaSelecc].Name = nombreOculto;
                    dgvLiga.Columns[intFilaSelecc].HeaderText = nombreAMostrar;
                    dgvLiga.Columns[intFilaSelecc].Visible = visible;
                    break;
                case "Image":
                    DataGridViewImageColumn col2 = new DataGridViewImageColumn();
                    col2.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dgvLiga.Columns.Add(col2);
                    dgvLiga.Columns[3].Name = nombreOculto;
                    dgvLiga.Columns[3].HeaderText = nombreAMostrar;
                    dgvLiga.Columns[3].Visible = visible;
                    break;
                case "ComboBox":
                    DataGridViewComboBoxColumn col3 = new DataGridViewComboBoxColumn();
                    for (int i = 1930; i <= DateTime.Now.Year + 5; i++)
                    {
                        col3.Items.Add(i.ToString());
                    }
                    dgvLiga.Columns.Add(col3);
                    dgvLiga.Columns[intFilaSelecc].Name = nombreOculto;
                    dgvLiga.Columns[intFilaSelecc].HeaderText = nombreAMostrar;
                    dgvLiga.Columns[intFilaSelecc].Visible = visible;
                    break;
                case "Calendar":
                    CalendarColumn col4 = new CalendarColumn();
                    dgvLiga.Columns.Add(col4);
                    dgvLiga.Columns[intFilaSelecc].Name = nombreOculto;
                    dgvLiga.Columns[intFilaSelecc].HeaderText = nombreAMostrar;
                    dgvLiga.Columns[intFilaSelecc].Visible = visible;
                    break;
                default:
                    dgvLiga.Columns.Add(nombreOculto, nombreAMostrar);
                    dgvLiga.Columns[nombreOculto].Visible = visible;
                    break;
            }

            intFilaSelecc++;
        }

        private void CargarDatosDGV()
        {
            if (dgvLiga.Rows.Count > 0)
                dgvLiga.Rows.Clear();

            foreach (DataRow r in Config.MostrarLigasActivas(txtBuscar.Text).Rows)
            {
                dgvLiga.Rows.Add(r.ItemArray);
            }

            ColorearFilas();
            RecargarImagen();
            NumerarFilas();
            //MostrarIconoMapa();
            ModoEdicion(false);
            dgvLiga.AllowUserToAddRows = false; // Elimina la última fila en blanco
        }

        private void RecargarImagen()
        {
            for (int i = 0; i < dgvLiga.Rows.Count - 1; i++)
            {
                if (!(string.IsNullOrEmpty(dgvLiga.Rows[i].Cells[4].Value.ToString())))
                {
                    try
                    {
                        dgvLiga.Rows[i].Cells[3].Value = Image.FromFile(dgvLiga.Rows[i].Cells[4].Value.ToString());
                    }
                    catch (System.IO.FileNotFoundException ex)
                    {
                        dgvLiga.Rows[i].Cells[3].Value = null;
                    }
                }
                else
                {
                    dgvLiga.Rows[i].Cells[3].Value = null;
                }
            }
        }

        private void MostrarIconoMapa()
        {
            for (int i = 0; i < dgvLiga.Rows.Count - 1; i++)
            {
                if (!(string.IsNullOrEmpty(dgvLiga.Rows[i].Cells[14].Value.ToString())))
                {
                    try
                    {
                        dgvLiga.Rows[i].Cells[15].Value = Image.FromFile("P:\\img-system\\globe_2.png");
                    }
                    catch (System.IO.FileNotFoundException ex)
                    {
                        dgvLiga.Rows[i].Cells[15].Value = Image.FromFile("P:\\img-system\\globe_no.png");
                    }
                }
                else
                {
                    dgvLiga.Rows[i].Cells[15].Value = Image.FromFile("P:\\img-system\\globe_no.png");
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
                strValor = dgvLiga.Rows[i].Cells[9].Value.ToString();
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
            ch1 = (DataGridViewCheckBoxCell)dgvLiga.Rows[dgvLiga.CurrentRow.Index].Cells[9];

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
            if (e.ColumnIndex == 9)
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
            Config.ActualizarExamenRX(ObtenerDatosDGV(dgvLiga));
            dgvLiga.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnModificar.Enabled = true;
            ColorearFilas();
            //CargarDatosDGV();
        }

        private DataTable ObtenerDatosDGV(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(System.String));
            dt.Columns.Add("CatInicial", typeof(System.String));
            dt.Columns.Add("CatFinal", typeof(System.String));
            dt.Columns.Add("PeriodoDesde", typeof(System.DateTime));
            dt.Columns.Add("PeridoHasta", typeof(System.DateTime));
            dt.Columns.Add("VerificaRX", typeof(System.Boolean));
            dt.Columns.Add("VerificaClub", typeof(System.Boolean));
            dt.Columns.Add("AdminteMenores", typeof(System.Boolean));
            dt.Columns.Add("IdLiga", typeof(System.String));

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataRow row = dt.NewRow();

                row["Id"] = dgv.Rows[i].Cells[0].Value;
                row["CatInicial"] = Convert.ToString(dgv.Rows[i].Cells[5].Value);
                row["CatFinal"] = Convert.ToString(dgv.Rows[i].Cells[6].Value);
                row["PeriodoDesde"] = Convert.ToDateTime(dgv.Rows[i].Cells[7].Value);
                row["PeridoHasta"] = Convert.ToDateTime(dgv.Rows[i].Cells[8].Value);
                row["VerificaRX"] = Convert.ToBoolean(dgv.Rows[i].Cells[9].Value);
                row["VerificaClub"] = Convert.ToBoolean(dgv.Rows[i].Cells[10].Value);
                row["AdminteMenores"] = Convert.ToBoolean(dgv.Rows[i].Cells[11].Value);
                row["IdLiga"] = Convert.ToString(dgv.Rows[i].Cells[12].Value);

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

            DialogResult drResultado = MessageBox.Show("Esta liga será eliminada...  \n¿Seguro que desea proceder?", "Mantenimiento de Ligas", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (drResultado == DialogResult.Yes)
            {
                strID = dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[0].Value.ToString();

                if (!(string.IsNullOrEmpty(strID)))
                {
                    //Club.EliminarClub(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[0].Value.ToString());
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

        private void frmConfiguracionExamenRX2_FormClosing(object sender, FormClosingEventArgs e)
        {
            botGuardar_Click(sender, e);
        }

        private void ValidarAnioCategorias(int intAñoInicial, int intAñoFinal, string strNombre)
        {
            if (intAñoInicial < intAñoFinal)
            {
                MessageBox.Show(strNombre + "\nEl año de nacimiento para categoria infantil no corresponde", "Configuración de RX", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvLiga_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            int intInicial = 0;
            int intFinal = 0;
            string strNombre = "";

            if (!(string.IsNullOrEmpty(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[5].Value.ToString())))
                intInicial = Convert.ToInt32(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[5].Value.ToString());
            else
                intInicial = 0;

            if (!(string.IsNullOrEmpty(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[6].Value.ToString())))
                intFinal = Convert.ToInt32(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[6].Value.ToString());
            else
                intFinal = 0;

            strNombre = Convert.ToString(dgvLiga.Rows[dgvLiga.CurrentCell.RowIndex].Cells[2].Value);
            ValidarAnioCategorias(intInicial, intFinal, strNombre);
            //blnPrimerIngresoSistema = true;
        }

        private void btnValidaciones_Click(object sender, EventArgs e)
        {
            frmValidacionesExamen frm = new frmValidacionesExamen();
            frm.ShowDialog();
        }

        private void btnDictamen_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfigDictamenAutomatico(), new Configuracion());
        }

        private void btnRX_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmConfiguracionExamenRX2(), new Configuracion());
        }

        private void botFiltrar_Click(object sender, EventArgs e)
        {
            CargarDatosDGV();
        }
    }
}
