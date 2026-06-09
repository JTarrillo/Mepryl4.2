using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmTipoExamen : Form
    {

        public delegate void DelegateDevolverTipoExamen(Entidades.TipoExamen te);
        public DelegateDevolverTipoExamen objDelegateDevolverTipoExamen = null;
        public delegate void DelegateModificado();
        public DelegateModificado objDelegateModificado = null;

        private Entidades.TipoExamen tipoExamen;
        private CapaNegocioMepryl.TipoExamen tep;
        private bool _usarPrecioLista = false;

        public frmTipoExamen(Entidades.TipoExamen te)
        {
            InitializeComponent();
            tipoExamen = te;
            tep = new CapaNegocioMepryl.TipoExamen();
            inicializarFormulario();
        }

        public frmTipoExamen()
        {
            InitializeComponent();
            tep = new CapaNegocioMepryl.TipoExamen();
        }

        public void cargarSegunIdConsulta(Guid idConsulta)
        {
            tipoExamen = tep.cargarTipoExamenSegunIdConsulta(idConsulta);
            inicializarFormulario();
        }

        public void cargarSegunIdTipoExamen(Guid idTipoExamen)
        {
            tipoExamen = tep.cargarTipoExamenSegunId(idTipoExamen);
            inicializarFormulario();
        }

        public void cargarSegunIdTurno(Guid idTurno)
        {
            tipoExamen = tep.cargarTipoExamenSegunIdTurno(idTurno);
            inicializarFormulario();
        }

        private void inicializarFormulario()
        {
            tbTipoExamen.Text = tipoExamen.Descripcion;
            
            // Mostrar importes netos (restando seña)
            tbImporte.Text = (tipoExamen.PrecioBase - tipoExamen.Seña).ToString("N0");
            tbImporteLista.Text = (tipoExamen.PrecioLista - tipoExamen.Seña).ToString("N0");
            
            tbId.Text = tipoExamen.Id.ToString();
            if (tipoExamen.Modificado)
            {
                tbTipoExamen.Text = tbTipoExamen.Text + " MODIF.";
            }
            actualizarVisualesPrecio();
            llenarDataGrids();
        }


        private void llenarDataGrids()
        {
            dgvClinico.DataSource = OrdenarDataTable(tipoExamen.Clinico);
            dgvHematologia.DataSource = OrdenarDataTable(tipoExamen.Hematologia);
            dgvQuimicaHematica.DataSource = OrdenarDataTable(tipoExamen.QuimicaHematica);
            dgvSerologia.DataSource = OrdenarDataTable(tipoExamen.Serologia);
            dgvPerfilLipidico.DataSource = OrdenarDataTable(tipoExamen.PerfilLipidico);
            dgvBacteriologia.DataSource = OrdenarDataTable(tipoExamen.Bacteriologia);
            dgvOrina.DataSource = OrdenarDataTable(tipoExamen.Orina);
            dgvLaboralesBasicas.DataSource = OrdenarDataTable(tipoExamen.LaboralesBasicas);
            dgvCraneoYMSuperior.DataSource = OrdenarDataTable(tipoExamen.CraneoYMSuperior);
            dgvTroncoYPelvis.DataSource = OrdenarDataTable(tipoExamen.TroncoYPelvis);
            dgvMiembroInferior.DataSource = OrdenarDataTable(tipoExamen.MiembroInferior);
            dgvEstComplementarios.DataSource = OrdenarDataTable(tipoExamen.EstComplementarios);
            ocultarColumnasDgv();
            actualizarResumen();
        }

        private void actualizarResumen()
        {
            List<DataTable> lista = new List<DataTable>();
            lista.Add((DataTable)dgvClinico.DataSource);
            actualizarTextBox(tbResumenClinico, ref lista);
            lista.Add((DataTable)dgvHematologia.DataSource);
            lista.Add((DataTable)dgvQuimicaHematica.DataSource);
            lista.Add((DataTable)dgvSerologia.DataSource);
            lista.Add((DataTable)dgvPerfilLipidico.DataSource);
            lista.Add((DataTable)dgvBacteriologia.DataSource);
            lista.Add((DataTable)dgvOrina.DataSource);
            actualizarTextBox(tbResumenLaboratorio, ref lista);
            lista.Add((DataTable)dgvLaboralesBasicas.DataSource);
            lista.Add((DataTable)dgvCraneoYMSuperior.DataSource);
            lista.Add((DataTable)dgvTroncoYPelvis.DataSource);
            lista.Add((DataTable)dgvMiembroInferior.DataSource);
            actualizarTextBox(tbResumenRx, ref lista);
            lista.Add((DataTable)dgvEstComplementarios.DataSource);
            actualizarTextBox(tbResumenEstCompl, ref lista);
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

        private void ocultarColumnasDgv()
        {
            ocultarColumna(dgvClinico);
            ocultarColumna(dgvHematologia);
            ocultarColumna(dgvQuimicaHematica);
            ocultarColumna(dgvSerologia);
            ocultarColumna(dgvPerfilLipidico);
            ocultarColumna(dgvBacteriologia);
            ocultarColumna(dgvOrina);
            ocultarColumna(dgvLaboralesBasicas);
            ocultarColumna(dgvCraneoYMSuperior);
            ocultarColumna(dgvTroncoYPelvis);
            ocultarColumna(dgvMiembroInferior);
            ocultarColumna(dgvEstComplementarios);
        }

        private void ocultarColumna(DataGridView dgv)
        {
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[4].Visible = false;
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        private void cancelar()
        {
            this.Close();
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void aceptar()
        {
            if (objDelegateDevolverTipoExamen != null)
            {
                objDelegateDevolverTipoExamen(llenarDatosEntidad());
                this.Close();
            }
            if (objDelegateModificado != null)
            {
                actualizarDatosEntidad();
                tep.actualizarEstudiosPorExamen(tipoExamen);
                objDelegateModificado();
                this.Close();
            }
        }

        private Entidades.TipoExamen llenarDatosEntidad()
        {
            actualizarDatosEntidad();
            return tipoExamen;
        }

        private void actualizarDatosEntidad()
        {
            Double result;
            if (tbImporte.Text != string.Empty && TryParseImporte(tbImporte.Text, out result))
            {
                // Guardar total bruto (neto + seña)
                tipoExamen.PrecioBase = result + tipoExamen.Seña;
            }
            Double resultLista;
            if (tbImporteLista.Text != string.Empty && TryParseImporte(tbImporteLista.Text, out resultLista))
            {
                // Guardar total bruto (neto + seña)
                tipoExamen.PrecioLista = resultLista + tipoExamen.Seña;
            }
            // Guardar cuál precio eligió el usuario
            tipoExamen.UsarPrecioLista = _usarPrecioLista;
            tipoExamen.Clinico = (DataTable)dgvClinico.DataSource;
            tipoExamen.Hematologia = (DataTable)dgvHematologia.DataSource;
            tipoExamen.QuimicaHematica = (DataTable)dgvQuimicaHematica.DataSource;
            tipoExamen.Serologia = (DataTable)dgvSerologia.DataSource;
            tipoExamen.PerfilLipidico = (DataTable)dgvPerfilLipidico.DataSource;
            tipoExamen.Bacteriologia = (DataTable)dgvBacteriologia.DataSource;
            tipoExamen.Orina = (DataTable)dgvOrina.DataSource;
            tipoExamen.LaboralesBasicas = (DataTable)dgvLaboralesBasicas.DataSource;
            tipoExamen.CraneoYMSuperior = (DataTable)dgvCraneoYMSuperior.DataSource;
            tipoExamen.TroncoYPelvis = (DataTable)dgvTroncoYPelvis.DataSource;
            tipoExamen.MiembroInferior = (DataTable)dgvMiembroInferior.DataSource;
            tipoExamen.EstComplementarios = (DataTable)dgvEstComplementarios.DataSource;
            tipoExamen.Modificado = tep.verificarSiEstaModificado(tipoExamen);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarResumen();
        }

        private void btnUsarPrecio_Click(object sender, EventArgs e)
        {
            _usarPrecioLista = !_usarPrecioLista;
            actualizarVisualesPrecio();
        }

        private void actualizarVisualesPrecio()
        {
            if (_usarPrecioLista)
            {
                tbImporteLista.BackColor = Color.PaleGreen;
                tbImporteLista.Font = new Font(tbImporteLista.Font, FontStyle.Bold);
                tbImporte.BackColor = SystemColors.Window;
                tbImporte.Font = new Font(tbImporte.Font, FontStyle.Regular);
                btnUsarPrecio.BackColor = Color.PaleGreen;
            }
            else
            {
                tbImporte.BackColor = Color.PaleGreen;
                tbImporte.Font = new Font(tbImporte.Font, FontStyle.Bold);
                tbImporteLista.BackColor = SystemColors.Window;
                tbImporteLista.Font = new Font(tbImporteLista.Font, FontStyle.Regular);
                btnUsarPrecio.BackColor = SystemColors.Control;
            }
        }

        private bool TryParseImporte(string texto, out double valor)
        {
            if (double.TryParse(texto, System.Globalization.NumberStyles.Any,
                                System.Globalization.CultureInfo.CurrentCulture, out valor))
                return true;
            // Fallback: quitar separadores de miles y parsear como entero
            string sinMiles = texto.Replace(".", "").Replace(",", "").Trim();
            return double.TryParse(sinMiles, out valor);
        }

        // Método auxiliar para ordenar DataTable alfabéticamente por la columna de descripción
        private DataTable OrdenarDataTable(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return dt;

            // Mostrar los nombres de las columnas para identificar el nombre correcto
            foreach (DataColumn col in dt.Columns)
            {
                //MessageBox.Show(col.ColumnName);
                System.Diagnostics.Debug.WriteLine(col.ColumnName);
            }

            // Cambia "Descripcion" por el nombre real de la columna de texto si es diferente
            DataView dv = dt.DefaultView;
            dv.Sort = "Item ASC";
            return dv.ToTable();
        }
    }
}
