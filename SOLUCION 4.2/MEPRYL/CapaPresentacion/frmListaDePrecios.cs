using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacionBase;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmListaDePrecios : DevExpress.XtraEditors.XtraForm
    {
        private CapaNegocioMepryl.TipoExamen tipoExamen;
        private CapaNegocioMepryl.LocalidadesYPrestaciones localidPrest;
        private CapaNegocioMepryl.ListaPrecios listaPrecios;
        public bool VieneDeFact;

        DataGridView dgvClinico = new DataGridView();
        DataGridView dgvHematologia = new DataGridView();
        DataGridView dgvQuimicaHematica = new DataGridView();
        DataGridView dgvSerologia = new DataGridView();
        DataGridView dgvPerfilLipidico = new DataGridView();
        DataGridView dgvBacteriologia = new DataGridView();
        DataGridView dgvOrina = new DataGridView();
        DataGridView dgvLaboralesBasicas = new DataGridView();
        DataGridView dgvCraneoYMSuperior = new DataGridView();
        DataGridView dgvTroncoYPelvis = new DataGridView();
        DataGridView dgvMiembroInferior = new DataGridView();
        DataGridView dgvEstComplementarios = new DataGridView();

        public frmListaDePrecios()
        {
            InitializeComponent();
            Inicializar();
        }

        public frmListaDePrecios(string valueASeleccionarLista)
        {
            InitializeComponent();
            Inicializar();
            SeleccionarListaDePrecio(valueASeleccionarLista);
            VieneDeFact = true;
        }

        public frmListaDePrecios(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;           
            Inicializar();
        }

        private void Inicializar()
        {
            tipoExamen = new CapaNegocioMepryl.TipoExamen();
            localidPrest = new CapaNegocioMepryl.LocalidadesYPrestaciones();
            listaPrecios = new CapaNegocioMepryl.ListaPrecios();
            llenardgvExAptitud();
            llenardgvPrestaciones();
            llenardgvVisitas();
            pnlBaseLista.Visible = false;
            CargarComboBox();
            dgvListaPrecios.Columns[6].DefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void llenardgvVisitas()
        {
            dgvVisitas.DataSource = null;
            //txtBuscarVisitas.Clear();
            //dgvVisitas.DataSource = localidPrest.cargarLocalidadesYPrestaciones("v");
            dgvVisitas.DataSource = localidPrest.cargarLocalidadesYPrestacionesFiltro("v", txtBuscarVisitas.Text);
            dgvVisitas.Columns[0].Visible = false;
            dgvVisitas.Columns[2].Visible = false;
            dgvVisitas.Columns[4].Visible = false;
            dgvVisitas.Columns[5].Visible = false;

            dgvVisitas.Columns[3].HeaderText = "Prestaciones";
            dgvVisitas.Columns[3].Width = 80;
            dgvVisitas.Columns[3].Width = 230;
        }

        private void frmListaDePrecios_Load(object sender, EventArgs e)
        {
            //dgvExAptitud.Rows.Insert(0, false, "00-00-01", "CONSULTA CLINICA");
            //dgvExAptitud.Rows.Insert(0, false, "00-00-02", "PRE-OCUPACIONAL LEY");
            //dgvExAptitud.Rows.Insert(0, false, "00-00-03", "PRE-OCUPACIONAL 01");
            //dgvExAptitud.Rows.Insert(0, false, "00-00-04", "PRE-OCUPACIONAL 02");
            //dgvExAptitud.Rows.Insert(0, false, "00-00-05", "PRE-OCUPACIONAL BONIFACIO");
            //dgvExAptitud.Rows.Insert(0, false, "00-00-06", "ERGOMETRIA 01");

            //dgvLaboratorio.Rows.Insert(0, false, "00-00-01", "C.A.B.A.");
            //dgvLaboratorio.Rows.Insert(0, false, "00-00-02", "ALDO BONZI");
            //dgvLaboratorio.Rows.Insert(0, false, "00-00-03", "AVELLANEDA");
            //dgvLaboratorio.Rows.Insert(0, false, "00-00-04", "CIUDADELA");
            //dgvLaboratorio.Rows.Insert(0, false, "00-00-05", "DOCK SUD");
            //dgvLaboratorio.Rows.Insert(0, false, "00-00-06", "FLORIDA");
            //dgvLaboratorio.Rows.Insert(0, false, "00-00-07", "GERLI");
            //dgvLaboratorio.Rows.Insert(0, false, "00-00-08", "ISLA MACIEL");

            //dgvLaboratorio.Sort(dgvLaboratorio.Columns[1], ListSortDirection.Ascending);
            //dgvExAptitud.Sort(dgvExAptitud.Columns[1], ListSortDirection.Ascending);
        }

        public void SeleccionarListaDePrecio(string value)
        {
            object a = new object();
            EventArgs ea = new EventArgs();
            cboListaPrecios.SelectedValue = value;
            cboListaPrecios_SelectionChangeCommitted(a,ea);
            btnEditar_Click(a, ea);
        }

        private void CargarComboBox()
        {
            cboListaPrecios.DataSource = listaPrecios.ListarNombreListaPrecios();
            cboListaPrecios.ValueMember = "id";
            cboListaPrecios.DisplayMember = "NombreLista";
            cboListaPrecios.SelectedIndex = -1;

            cboCargarLista.DataSource = listaPrecios.ListarNombreListaPrecios();
            cboCargarLista.ValueMember = "id";
            cboCargarLista.DisplayMember = "NombreLista";
            cboCargarLista.SelectedIndex = -1;

            cboListaPrecios.Width = 329;
            txtNombreLista.Width = 329;
            cboListaPrecios.Text = txtNombreLista.Text;
        }

        private void llenardgvExAptitud()
        {
            dgvExAptitud.DataSource = null;
            //txtBuscarAptitud.Clear();
            //dgv6.DataSource = localidPrest.cargarLocalidadesYPrestaciones(obtenerItemSeleccionado4(cboTipoPrestacion6));
            dgvExAptitud.DataSource = tipoExamen.cargarTiposDeExamenFinales("2", txtBuscarAptitud.Text, true);
            dgvExAptitud.Columns[0].Visible = false;
            dgvExAptitud.Columns[3].Visible = false;
            dgvExAptitud.Columns[4].Visible = false;
            dgvExAptitud.Columns[5].Visible = false;
            dgvExAptitud.Columns[6].Visible = false;
            dgvExAptitud.Columns[7].Visible = false;
            dgvExAptitud.Columns[8].Visible = false;
            dgvExAptitud.Columns[9].Visible = false;
            dgvExAptitud.Columns[10].Visible = false;
            dgvExAptitud.Columns[11].Visible = false;
            dgvExAptitud.Columns[12].Visible = false;
            dgvExAptitud.Columns[13].Visible = false;
            dgvExAptitud.Columns[14].Visible = false;

            dgvExAptitud.Columns[1].Width = 80;
            dgvExAptitud.Columns[2].Width = 360;
        }
        
        private void dgvExAptitud_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int nroFila = dgvExAptitud.CurrentCell.RowIndex;            

            Entidades.TipoExamen entidad = tipoExamen.cargarEntidad(dgvExAptitud.Rows[nroFila].Cells[0].Value.ToString());
            llenarDataGrids(entidad);
            actualizarResumen();            
        }

        private void actualizarResumen()
        {
            List<DataTable> lista = new List<DataTable>();
            lista.Add((DataTable)dgvClinico.DataSource);
            actualizarTextBox(txtClinico, ref lista);
            lista.Add((DataTable)dgvHematologia.DataSource);
            lista.Add((DataTable)dgvQuimicaHematica.DataSource);
            lista.Add((DataTable)dgvSerologia.DataSource);
            lista.Add((DataTable)dgvPerfilLipidico.DataSource);
            lista.Add((DataTable)dgvBacteriologia.DataSource);
            lista.Add((DataTable)dgvOrina.DataSource);
            actualizarTextBox(txtLaboratorio, ref lista);
            lista.Add((DataTable)dgvLaboralesBasicas.DataSource);
            lista.Add((DataTable)dgvCraneoYMSuperior.DataSource);
            lista.Add((DataTable)dgvTroncoYPelvis.DataSource);
            lista.Add((DataTable)dgvMiembroInferior.DataSource);
            actualizarTextBox(txtRX, ref lista);
            lista.Add((DataTable)dgvEstComplementarios.DataSource);
            actualizarTextBox(txtEstComple, ref lista);
        }

        private void llenarDataGrids(Entidades.TipoExamen entidad)
        {
            dgvClinico.DataSource = entidad.Clinico;
            dgvHematologia.DataSource = entidad.Hematologia;
            dgvQuimicaHematica.DataSource = entidad.QuimicaHematica;
            dgvSerologia.DataSource = entidad.Serologia;
            dgvPerfilLipidico.DataSource = entidad.PerfilLipidico;
            dgvBacteriologia.DataSource = entidad.Bacteriologia;
            dgvOrina.DataSource = entidad.Orina;
            dgvLaboralesBasicas.DataSource = entidad.LaboralesBasicas;
            dgvCraneoYMSuperior.DataSource = entidad.CraneoYMSuperior;
            dgvTroncoYPelvis.DataSource = entidad.TroncoYPelvis;
            dgvMiembroInferior.DataSource = entidad.MiembroInferior;
            dgvEstComplementarios.DataSource = entidad.EstComplementarios;            
        }

        private void actualizarTextBox(TextBox tb, ref List<DataTable> lista)
        {
            tb.Clear();
            foreach (DataTable dt in lista)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if ((bool)dr.ItemArray[2])
                    {
                        if (tb.Text.Length == 0)
                        {
                            tb.Text = dr.ItemArray[3].ToString();
                        }
                        else
                        {
                            tb.Text = tb.Text + " - " + dr.ItemArray[3].ToString();
                        }
                    }
                }
            }
            lista.Clear();
        }

        private void llenardgvPrestaciones()
        {
            dgvPrestaciones.DataSource = null;
            //txtBuscarPrestacion.Clear();
            //dgvPrestaciones.DataSource = localidPrest.cargarLocalidadesYPrestaciones("P");
            dgvPrestaciones.DataSource = localidPrest.cargarLocalidadesYPrestacionesFiltro("P", txtBuscarPrestacion.Text);
            dgvPrestaciones.Columns[0].Visible = false;
            dgvPrestaciones.Columns[2].Visible = false;
            dgvPrestaciones.Columns[4].Visible = false;
            dgvPrestaciones.Columns[5].Visible = false;

            dgvPrestaciones.Columns[3].HeaderText = "Prestaciones";
            dgvPrestaciones.Columns[3].Width = 80;
            dgvPrestaciones.Columns[3].Width = 230;
        }

        private void dgvPrestaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int nroFila = dgvExAptitud.CurrentCell.RowIndex;

            txtDescripcion.Text = dgvPrestaciones.CurrentRow.Cells[3].Value.ToString();
        }

        private void dgvPrestaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strCodigo = dgvPrestaciones.CurrentRow.Cells[1].Value.ToString();
            string strDescripcion = dgvPrestaciones.CurrentRow.Cells[3].Value.ToString();

            if (VerificaIngresado(strDescripcion))
            {
                MessageBox.Show("Esta prestación ya está ingresada. Por favor seleccione otra opción.",
                     "lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvListaPrecios.Rows.Insert(0, "Prestaciones", strCodigo, strDescripcion, "0.00", "0.00");
            }            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarNuevaLista();
        }

        private void AgregarNuevaLista()
        {
            pnlBaseLista.Visible = false;
            lblListaPrecios.Text = "Nombre Lista de Precios";

            txtNombreLista.Visible = true;
            cboListaPrecios.Visible = false;
            txtNombreLista.Select();
            dgvListaPrecios.Rows.Clear();
            tbControl.Enabled = true;

            btnAgregar.Enabled = false;
            btnEditar.Visible = false;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            btnEliminarFila.Visible = true;
            btnEliminar.Visible = false;
                       

            tbControl.Visible = true;
            //btnCargarLista.Visible = true;
            pnlPanelVariacion.Visible = true;
        }

        private void CancelarNuevaLista()
        {
            pnlBaseLista.Visible = false;
            lblListaPrecios.Text = "Lista de Precios";

            txtNombreLista.Visible = false;
            txtNombreLista.Enabled = true;
            cboListaPrecios.Visible = true;            
            //dgvListaPrecios.Rows.Clear();

            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;

            btnAgregar.Visible = true;
            btnEditar.Visible = true;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnEliminarFila.Visible = false;
            btnEliminar.Visible = true;

            tbControl.Visible = false;
            //btnCargarLista.Visible = true;
            pnlPanelVariacion.Visible = false;
            pnlPanelVariacion.Enabled = false;
        }

        private void LimpiaCampos()
        {
            txtClinico.Clear();
            txtLaboratorio.Clear();
            txtRX.Clear();
            txtEstComple.Clear();
            txtDescripcion.Clear();
            txtDescripcionVisitas.Clear();
            txtZona.Clear();
            txtNombreLista.Clear();
            tbControl.Enabled = false;
            dgvListaPrecios.Rows.Clear();
            cboListaPrecios.Text = "";
            lblListaElegida.Text = "";
            txtVariacionP.Clear();
            txtBuscarAptitud.Clear();
            txtBuscarPrestacion.Clear();
            txtBuscarVisitas.Clear();            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Los datos no guardados se perderán",
                     "Editar lista de precios", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                CancelarNuevaLista();
                LimpiaCampos();
            }               
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreLista.Text))
            {
                if (ValidaCostoFactura())
                {
                    DialogResult result = MessageBox.Show("El valor del costo es mayor al facturado\n\nDesea continuar.",
                                                            "Guardar lista de precios", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (btnAgregar.Visible)
                        {
                            if (!listaPrecios.VerificaNombreListaPrecios(txtNombreLista.Text))
                            {
                                guardarDatosListaPreciosBase();
                                MessageBox.Show("Datos guardados correctamente",
                                            "Guardar lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("El nombre de la lista ya existe, debe usar otro nombre",
                                            "Guardar lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        if (btnEditar.Visible)
                        {
                            EditarDatosListaPreciosBase();
                            MessageBox.Show("Datos editados correctamente",
                                        "Editar lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        CancelarNuevaLista();
                        //LimpiaCampos();
                        CargarComboBox();
                    }
                }
                else
                {
                    if (btnAgregar.Visible)
                    {
                        guardarDatosListaPreciosBase();
                        MessageBox.Show("Datos guardados correctamente",
                                    "Guardar lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (btnEditar.Visible)
                    {
                        EditarDatosListaPreciosBase();
                        MessageBox.Show("Datos editados correctamente",
                                    "Editar lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (VieneDeFact == true)
                        {
                            this.Close();
                        }
                    }

                    CancelarNuevaLista();
                    //LimpiaCampos();
                    CargarComboBox();
                } 
            }
            else
            {
                MessageBox.Show("Falta un nombre para la lista",
                                "Guardar lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreLista.Select();
            }
        }

        private void guardarDatosNombreLista()
        {
            
        }

        private void guardarDatosListaPreciosBase()
        {
            int intCodigoNombreLista = 0;
            DataTable dt = null;
            
            //DataTable dt = new DataTable();

            //dt.Columns.Add("TipoPrestacion", typeof(System.String));
            //dt.Columns.Add("Codigo", typeof(System.String));
            //dt.Columns.Add("Descripcion", typeof(System.String));
            //dt.Columns.Add("Costo", typeof(System.String));
            //dt.Columns.Add("Facturacion", typeof(System.String));

            //foreach (DataGridViewRow rowGrid in dgvListaPrecios.Rows)
            //{
            //    DataRow row = dt.NewRow();
            //    row["TipoPrestacion"] = rowGrid.Cells[0].Value.ToString();
            //    row["Codigo"] = rowGrid.Cells[1].Value.ToString();
            //    row["Descripcion"] = rowGrid.Cells[2].Value.ToString();
            //    row["Costo"] = rowGrid.Cells[3].Value.ToString();
            //    row["Facturacion"] = rowGrid.Cells[4].Value.ToString();

            //    dt.Rows.Add(row);
            //}

            dt = cargarListaPrecio();
           

            if (dgvListaPrecios.Rows.Count > 0)
            {
                intCodigoNombreLista = listaPrecios.InsertarNombreListaPrecios(txtNombreLista.Text);
            }
            
            if(intCodigoNombreLista != 0 && dt.Rows.Count > 0)
            {
                listaPrecios.InsertarListaPreciosBase(intCodigoNombreLista, dt);
            }
        }

        private DataTable cargarListaPrecio()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("TipoPrestacion", typeof(System.String));
            dt.Columns.Add("Codigo", typeof(System.String));
            dt.Columns.Add("Descripcion", typeof(System.String));
            dt.Columns.Add("Costo", typeof(System.String));
            dt.Columns.Add("Facturacion", typeof(System.String));

            foreach (DataGridViewRow rowGrid in dgvListaPrecios.Rows)
            {
                DataRow row = dt.NewRow();
                row["TipoPrestacion"] = rowGrid.Cells[0].Value.ToString();
                row["Codigo"] = rowGrid.Cells[1].Value.ToString();
                row["Descripcion"] = rowGrid.Cells[2].Value.ToString();
                row["Costo"] = rowGrid.Cells[3].Value.ToString();
                row["Facturacion"] = rowGrid.Cells[4].Value.ToString();

                dt.Rows.Add(row);
            }

            return dt;
        }

        private bool ValidaCostoFactura()
        {
            bool blnestado = false;
            float fltCosto = 0f;
            float fltFactura = 0f;

            foreach (DataGridViewRow rowGrid in dgvListaPrecios.Rows)
            {
                fltCosto = float.Parse(rowGrid.Cells[3].Value.ToString().Replace('.', ','));
                fltFactura = float.Parse(rowGrid.Cells[4].Value.ToString().Replace('.', ','));

                if (fltCosto <= fltFactura)
                {

                }else
                {
                    blnestado = true;
                }
            }

            return blnestado;
        }

        private void cboListaPrecios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarListaPrecioBase(int.Parse(cboListaPrecios.SelectedValue.ToString()));
        }

        private void CargarListaPrecioBase(int intIdNombreLista)
        {
            DataTable dt = null;
            string strCosto = "";
            string strFactu = "";

            DataTable data = SQLConnector.obtenerTablaSegunConsultaString("SELECT valor, DiscriminaIva FROM [MEPRYLv2.1].[dbo].[Iva] WHERE descripcion = 'PREDETERMINADO'");

            if (intIdNombreLista > 0)
            {
                dgvListaPrecios.Rows.Clear();
                dt = listaPrecios.ListarListaPreciosBase(intIdNombreLista);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strCosto = String.Format("{0:#.##}", dt.Rows[i][6].ToString().Replace('.', ','));
                        strFactu = String.Format("{0:#.##}", dt.Rows[i][7].ToString().Replace('.', ','));

                        dgvListaPrecios.Rows.Insert(0, dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), Convert.ToDouble(strCosto).ToString("F"), Convert.ToDouble(strFactu).ToString("F"), Convert.ToDouble(Convert.ToDouble(strFactu) - Convert.ToDouble(strCosto)).ToString("F"), Convert.ToDouble(Convert.ToDouble(strFactu) + ((Convert.ToDouble(strFactu) * Convert.ToDouble(data.Rows[0][0].ToString())) / 100)).ToString("F"));
                    }
                }
            }
        }
        
        private void btnCargarLista_Click(object sender, EventArgs e)
        {
            int intCodigoNombreLista = 0;
            string PorcentajeVariacion = "";
            
            frmListaPrecioTomaBase frm = new frmListaPrecioTomaBase();
            frm.ShowDialog();
            if (!string.IsNullOrEmpty(frm.strCodigo))
            {
                intCodigoNombreLista = int.Parse(frm.strCodigo);
                PorcentajeVariacion = frm.strVariacion;
                lblListaElegida.Text = frm.strNombreLista;

                CargarListaPrecioBase(intCodigoNombreLista);
                txtVariacionP.Text = PorcentajeVariacion;
            }         
        }

        private void tbPrecioBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((char.IsDigit(e.KeyChar)) || (e.KeyChar == '.') || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            //tbPrecioBase.Text = tbPrecioBase.Text.Replace('.', ',');
            //tbPrecioBase.SelectionStart = tbPrecioBase.Text.Length;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombreLista.Text = cboListaPrecios.Text;

            if (string.IsNullOrEmpty(txtNombreLista.Text))
            {
                MessageBox.Show("Debe seleccionar una lista de precios",
                     "Editar lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            { 
                tbControl.Enabled = true;
                btnAgregar.Visible = false;
                btnGuardar.Visible = true;
                btnCancelar.Visible = true;
                btnEliminarFila.Visible = true;
                btnEliminar.Visible = false;                

                btnEditar.Enabled = false;
                txtNombreLista.Visible = true;
                txtNombreLista.Enabled = false;
                cboListaPrecios.Visible = false;

                tbControl.Visible = true;
                pnlPanelVariacion.Visible = false;
            }
            
        }

        private void dgvVisitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int nroFila = dgvVisitas.CurrentCell.RowIndex;

            txtDescripcionVisitas.Text = dgvVisitas.CurrentRow.Cells[3].Value.ToString();
            txtZona.Text = dgvVisitas.CurrentRow.Cells[5].Value.ToString();
        }

        private void dgvListaPrecios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((char.IsDigit(e.KeyChar)) || (e.KeyChar == '.') || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            dgvListaPrecios.CurrentRow.Cells[3].Value = dgvListaPrecios.CurrentRow.Cells[3].Value.ToString().Replace('.', ',');
            dgvListaPrecios.CurrentRow.Cells[4].Value = dgvListaPrecios.CurrentRow.Cells[4].Value.ToString().Replace('.', ',');
            
        }

        private void dgvExAptitud_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strCodigo = dgvExAptitud.CurrentRow.Cells[1].Value.ToString();
            string strDescripcion = dgvExAptitud.CurrentRow.Cells[2].Value.ToString();

            if (VerificaIngresado(strDescripcion))
            {
                MessageBox.Show("Este examen ya está ingresado. Por favor seleccione otra opción.",
                     "lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvListaPrecios.Rows.Insert(0, "Examen Aptitud", strCodigo, strDescripcion, "0.00", "0.00");
            }
        }

        private void dgvVisitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strCodigo = dgvVisitas.CurrentRow.Cells[1].Value.ToString();
            string strDescripcion = dgvVisitas.CurrentRow.Cells[3].Value.ToString();

            if (VerificaIngresado(strDescripcion))
            {
                MessageBox.Show("Esta visita ya está ingresada. Por favor seleccione otra opción.",
                     "lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvListaPrecios.Rows.Insert(0, "Visitas", strCodigo, strDescripcion, "0.00", "0.00");
            }
        }

        private void txtNombreLista_TextChanged(object sender, EventArgs e)
        {
            if(txtNombreLista.Text.Length > 0)
            {
                pnlPanelVariacion.Enabled = true;
            }
            else
            {
                pnlPanelVariacion.Enabled = false;
            }
        }

        private void CalcularPorcentaje()
        {
            if (dgvListaPrecios.Rows.Count > 0 && txtVariacionP.Text != "-")
            {
                float fltPorcentaje = float.Parse(txtVariacionP.Text);
                float fltCosto = 0f;
                float fltFactura = 0f;
                
                foreach (DataGridViewRow rowGrid in dgvListaPrecios.Rows)
                {
                    fltCosto = float.Parse(rowGrid.Cells[5].Value.ToString());
                    fltFactura = float.Parse(rowGrid.Cells[6].Value.ToString());

                    rowGrid.Cells[3].Value = Math.Round((((fltCosto * fltPorcentaje) / 100) + fltCosto), 2).ToString();
                    rowGrid.Cells[4].Value = Math.Round((((fltFactura * fltPorcentaje) / 100) + fltFactura), 2).ToString();                                        
                }
            }
        }

        private bool VerificaIngresado(string strNombreExamen)
        {
            bool blnResultado = false;

            foreach (DataGridViewRow r in dgvListaPrecios.Rows)
            {
                if(r.Cells[2].Value.ToString() == strNombreExamen)
                {
                    blnResultado = true;
                }
            }

            return blnResultado;
        }

        private void EditarDatosListaPreciosBase()
        {
            int intCodigoNombreLista = 0;
            DataTable dt = null;

            dt = cargarListaPrecio();

            intCodigoNombreLista = int.Parse(cboListaPrecios.SelectedValue.ToString());

            if (intCodigoNombreLista != 0 && dt.Rows.Count > 0)
            {
                listaPrecios.DeleteListaPreciosBase(intCodigoNombreLista);
                listaPrecios.InsertarListaPreciosBase(intCodigoNombreLista, dt);
                
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int intCodigoNombreLista = 0;

            if (string.IsNullOrEmpty(cboListaPrecios.Text))
            {
                MessageBox.Show("Debe seleccionar una lista de precios",
                     "Editar lista de precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                intCodigoNombreLista = int.Parse(cboListaPrecios.SelectedValue.ToString());

                DialogResult result = MessageBox.Show("¿Realmente desea eliminar la lista de precios seleccionada?",
                        "Eliminar Lista de Precios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    listaPrecios.DeleteNombreListaPrecios(intCodigoNombreLista);
                    listaPrecios.DeleteListaPreciosBase(intCodigoNombreLista);

                    CargarComboBox();
                    CancelarNuevaLista();
                    LimpiaCampos();
                }
            }
        }

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            if (dgvListaPrecios.Rows.Count > 0)
            {
                dgvListaPrecios.Rows.Remove(dgvListaPrecios.CurrentRow);
            }
        }

        private void txtVariacionP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            //-------------------------------------------
            
        }

        private void txtVariacionP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVariacionP.Text))
            {
                txtVariacionP.Text = "0";
            }

            
            CalcularPorcentaje();
        }

        private void txtBuscarAptitud_TextChanged(object sender, EventArgs e)
        {
            llenardgvExAptitud();
        }

        private void txtBuscarPrestacion_TextChanged(object sender, EventArgs e)
        {
            llenardgvPrestaciones();
        }

        private void txtBuscarVisitas_TextChanged(object sender, EventArgs e)
        {
            llenardgvVisitas();
        }

        private void dgvListaPrecios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            double costo, facturacion;
            if (dgvListaPrecios.Rows.Count != 0)
            {
                if (dgvListaPrecios.Rows[index].Cells[4].Value.ToString().Contains("."))
                {
                    dgvListaPrecios.Rows[index].Cells[4].Value = dgvListaPrecios.Rows[index].Cells[4].Value.ToString().Replace('.', ',');
                }
                if (dgvListaPrecios.Rows[index].Cells[3].Value.ToString().Contains("."))
                {
                    dgvListaPrecios.Rows[index].Cells[3].Value = dgvListaPrecios.Rows[index].Cells[3].Value.ToString().Replace('.', ',');
                }
                Double.TryParse(dgvListaPrecios.Rows[index].Cells[4].Value.ToString(), out facturacion);
                Double.TryParse(dgvListaPrecios.Rows[index].Cells[3].Value.ToString(), out costo);
                dgvListaPrecios.Rows[index].Cells[5].Value = Convert.ToString(facturacion-costo);
            }
        }

        private void dgvListaPrecios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataTable data = SQLConnector.obtenerTablaSegunConsultaString("SELECT valor, DiscriminaIva FROM [MEPRYLv2.1].[dbo].[Iva] WHERE descripcion = 'PREDETERMINADO'");
            int i = e.RowIndex;
            string strFactu = dgvListaPrecios.Rows[i].Cells[4].Value.ToString();
            dgvListaPrecios.Rows[i].Cells[6].Value = Convert.ToString(Math.Round(Convert.ToDouble(strFactu) + ((Convert.ToDouble(strFactu) * Convert.ToDouble(data.Rows[0][0].ToString())) / 100), 2));
        }

        private void dgvVisitas_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvVisitas.RowCount == 0)
            {

            }
        }

        private void txtBuscarVisitas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmABMPrestaciones frmPrestaciones = new frmABMPrestaciones();
                frmPrestaciones.ShowDialog();
            }
        }

        private void txtBuscarPrestacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmABMPrestaciones frmPrestaciones = new frmABMPrestaciones();
                frmPrestaciones.cambiaAPrestaciones();
                frmPrestaciones.ShowDialog();
            }
        }
    }
}
