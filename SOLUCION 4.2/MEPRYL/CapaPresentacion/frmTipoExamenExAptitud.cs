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
    public partial class frmTipoExamenExAptitud : Form
    {

        public delegate void DelegateDevolverTipoExamen(Entidades.TipoExamen te);
        public DelegateDevolverTipoExamen objDelegateDevolverTipoExamen = null;
        public delegate void DelegateModificado();
        public DelegateModificado objDelegateModificado = null;

        private Entidades.TipoExamen tipoExamen;
        private CapaNegocioMepryl.TipoExamen tep;

        public frmTipoExamenExAptitud(Entidades.TipoExamen te)
        {
            InitializeComponent();
            tipoExamen = te;
            tep = new CapaNegocioMepryl.TipoExamen();
            inicializarFormulario();
        }

        public frmTipoExamenExAptitud()
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
            tbImporte.Text = tipoExamen.PrecioBase.ToString();
            tbId.Text = tipoExamen.Id.ToString();
            if (tipoExamen.Modificado)
            {
                tbTipoExamen.Text = tbTipoExamen.Text + " MODIF.";
            }
            llenarDataGrids();
        }


        private void llenarDataGrids()
        {
            dgvClinico.DataSource = tipoExamen.Clinico;
            dgvHematologia.DataSource = tipoExamen.Hematologia;
            dgvQuimicaHematica.DataSource = tipoExamen.QuimicaHematica;
            dgvSerologia.DataSource = tipoExamen.Serologia;
            dgvPerfilLipidico.DataSource = tipoExamen.PerfilLipidico;
            dgvBacteriologia.DataSource = tipoExamen.Bacteriologia;
            dgvOrina.DataSource = tipoExamen.Orina;
            dgvLaboralesBasicas.DataSource = tipoExamen.LaboralesBasicas;
            dgvCraneoYMSuperior.DataSource = tipoExamen.CraneoYMSuperior;
            dgvTroncoYPelvis.DataSource = tipoExamen.TroncoYPelvis;
            dgvMiembroInferior.DataSource = tipoExamen.MiembroInferior;
            dgvEstComplementarios.DataSource = tipoExamen.EstComplementarios;
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
            if (tbImporte.Text != string.Empty && Double.TryParse(tbImporte.Text, out result))
            {
                tipoExamen.PrecioBase = result;
            }
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
    }
}
