using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using Entidades;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmConfigTipoExamen : Form
    {
        private CapaNegocioMepryl.TipoExamen tipoExamen;

        public frmConfigTipoExamen()
        {
            InitializeComponent();
            inicializar();
        }
    
        
        private void inicializar()
        {
            tipoExamen = new CapaNegocioMepryl.TipoExamen();
            cargarComboMotivoConsulta();
            modoMenu();

        }

        private void cargarComboMotivoConsulta()
        {
            cboMotivoConsulta.DataSource = tipoExamen.cargarMotivosDeConsulta();
            cboMotivoConsulta.ValueMember = "id";
            cboMotivoConsulta.DisplayMember = "nombre";
            cboMotivoConsulta.SelectedIndex = -1;
        }

        private void cargarComboTipoExamen()
        {
            if (cboMotivoConsulta.SelectedIndex != -1)
            {
                cboTipoExamen.DataSource = tipoExamen.cargarTiposDeExamen(cboMotivoConsulta.SelectedValue.ToString());
                cboTipoExamen.ValueMember = "id";
                cboTipoExamen.DisplayMember = "descripcion";
                cboTipoExamen.SelectedIndex = -1;
            }
        }


        private void llenarFormulario()
        {
            limpiarPanelPrincipal();
            if (cboTipoExamen.SelectedIndex != -1)
            {
                Entidades.TipoExamen entidad = tipoExamen.cargarEntidad(cboTipoExamen.SelectedValue.ToString());
                tbId.Text = entidad.Id.ToString();
                tbCodigo.Text = entidad.Codigo.ToString();
                tbDescripcion.Text = entidad.Descripcion;
                tbDescripcionInformes.Text = entidad.DescripcionInformes;
                if (entidad.PrecioBase != 0) { tbPrecioBase.Text = entidad.PrecioBase.ToString(); }
                llenarDataGrids(entidad);
                tabControl.TabIndex = 0;
                actualizarResumen();
            }
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
            ocultarColumnasDgv();
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
        }

        private void cboTipoExamen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            botEditar.Enabled = false;
            botEliminar.Enabled = false;
            limpiarPanelPrincipal();
            if (cboTipoExamen.SelectedIndex != -1)
            {
                botEditar.Enabled = true;
                botEliminar.Enabled = true;
                llenarFormulario();
            }
        }

        private void limpiarPanelPrincipal()
        {
            tbId.Clear();
            tbCodigo.Clear();
            tbDescripcion.Clear();
            tbDescripcionInformes.Clear();
            tbPrecioBase.Clear();
            dgvClinico.DataSource = null;
            dgvHematologia.DataSource = null;
            dgvQuimicaHematica.DataSource = null;
            dgvSerologia.DataSource = null;
            dgvPerfilLipidico.DataSource = null;
            dgvBacteriologia.DataSource = null;
            dgvOrina.DataSource = null;
            dgvLaboralesBasicas.DataSource = null;
            dgvCraneoYMSuperior.DataSource = null;
            dgvTroncoYPelvis.DataSource = null;
            dgvMiembroInferior.DataSource = null;
            dgvEstComplementarios.DataSource = null;
            tbResumenClinico.Clear();
            tbResumenLaboratorio.Clear();
            tbResumenRx.Clear();
            tbResumenEstCompl.Clear();
        }

        private void botEditar_Click(object sender, EventArgs e)
        {
            modoEdicion();
        }

        private void modoEdicion()
        {
            panelMenu.Enabled = false;
            botGuardar.Visible = true;
            botCancelar.Visible = true;
            tabControl.TabIndex = 0;
            cambiarHabilitacionControles(true);
        }

        private void modoMenu()
        {
            panelMenu.Enabled = true;
            botGuardar.Visible = false;
            botCancelar.Visible = false;
            cambiarHabilitacionControles(false);
            llenarFormulario();
        }

        private void cambiarHabilitacionControles(bool estado)
        {
            tbDescripcion.Enabled = estado;
            tbDescripcionInformes.Enabled = estado;
            tbPrecioBase.Enabled = estado;
            dgvBacteriologia.Enabled = estado;
            dgvClinico.Enabled = estado;
            dgvCraneoYMSuperior.Enabled = estado;
            dgvEstComplementarios.Enabled = estado;
            dgvHematologia.Enabled = estado;
            dgvLaboralesBasicas.Enabled = estado;
            dgvMiembroInferior.Enabled = estado;
            dgvOrina.Enabled = estado;
            dgvPerfilLipidico.Enabled = estado;
            dgvQuimicaHematica.Enabled = estado;
            dgvSerologia.Enabled = estado;
            dgvTroncoYPelvis.Enabled = estado;
        }

        private void cambiarHabilitacionTabControl()
        {
            tabControl.Enabled = true;
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            modoMenu();
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            guardar();      
        }

        private void guardar()
        {
            if (verificarDatosIngresados())
            {
                guardarDatos();
            }
            else
            {
                MessageBox.Show("¡Faltan ingresar datos requeridos!", "Ingresar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool verificarDatosIngresados()
        {
            if (tbDescripcion.Text != string.Empty && cboMotivoConsulta.SelectedIndex != -1)
            {
                return true;
            }
            return false;
        }

        private void guardarDatos()
        {
            Entidades.TipoExamen entidad = llenarDatosEntidad();
            Entidades.Resultado resultado;
            if (tbId.Text != string.Empty)
            {
                resultado = tipoExamen.editarTipoExamen(entidad);
                if (resultado.Modo == 1)
                {
                    modoMenu();
                    llenarFormulario();
                }
                else
                {
                    MessageBox.Show("¡Error al editar Tipo de Examen!\nError:" + resultado.Mensaje, "Editar Tipo Examen",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                resultado = tipoExamen.crearTipoExamen(entidad);
                if (resultado.Modo == 1)
                {
                    modoMenu();
                    limpiarPanelPrincipal();
                    cargarComboTipoExamen();
                }
                else
                {
                    MessageBox.Show("¡Error al crear Tipo de Examen!\nError:" + resultado.Mensaje, "Crear Tipo Examen",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private Entidades.TipoExamen llenarDatosEntidad()
        {
            Entidades.TipoExamen retorno = new Entidades.TipoExamen();
            if (tbId.Text != string.Empty) { retorno.Id = new Guid(tbId.Text); }
            retorno.Descripcion = tbDescripcion.Text;
            retorno.DescripcionInformes = tbDescripcionInformes.Text;
            retorno.IdMotivoConsulta = Convert.ToInt16(cboMotivoConsulta.SelectedValue.ToString());
            Double result;
            if (tbPrecioBase.Text != string.Empty && Double.TryParse(tbPrecioBase.Text, out result))
            {
                retorno.PrecioBase = result;
            }
            retorno.Clinico = (DataTable)dgvClinico.DataSource;
            retorno.Hematologia = (DataTable)dgvHematologia.DataSource;
            retorno.QuimicaHematica = (DataTable)dgvQuimicaHematica.DataSource;
            retorno.Serologia = (DataTable)dgvSerologia.DataSource;
            retorno.PerfilLipidico = (DataTable)dgvPerfilLipidico.DataSource;
            retorno.Bacteriologia = (DataTable)dgvBacteriologia.DataSource;
            retorno.Orina = (DataTable)dgvOrina.DataSource;
            retorno.LaboralesBasicas = (DataTable)dgvLaboralesBasicas.DataSource;
            retorno.CraneoYMSuperior = (DataTable)dgvCraneoYMSuperior.DataSource;
            retorno.TroncoYPelvis = (DataTable)dgvTroncoYPelvis.DataSource;
            retorno.MiembroInferior = (DataTable)dgvMiembroInferior.DataSource;
            retorno.EstComplementarios = (DataTable)dgvEstComplementarios.DataSource;
            retorno.Codigo = Convert.ToInt16(tbCodigo.Text);
            return retorno;

        }

        private void botAgregar_Click(object sender, EventArgs e)
        {
            nuevoTipoExamen();
        }

        private void nuevoTipoExamen()
        {
            limpiarPanelPrincipal();
            cboTipoExamen.SelectedIndex = -1;
            modoEdicion();
            Entidades.TipoExamen entidad = tipoExamen.cargarItems();
            tbCodigo.Text = entidad.Codigo.ToString();
            llenarDataGrids(entidad);
        }

        private void tbPrecioBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((char.IsDigit(e.KeyChar)) || (e.KeyChar == '.') || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            tbPrecioBase.Text = tbPrecioBase.Text.Replace('.', ',');
            tbPrecioBase.SelectionStart = tbPrecioBase.Text.Length;
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            eliminarTipoExamen();
        }

        private void eliminarTipoExamen()
        {
            DialogResult result = MessageBox.Show("Se va a eliminar el Tipo de Examen seleccionado, ¿Realmente desea continuar?",
                "Eliminar Tipo de Examen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Entidades.Resultado resultado = tipoExamen.eliminarTipoExamen(tbId.Text);
                if (resultado.Modo == 1)
                {
                    limpiarPanelPrincipal();
                    cargarComboTipoExamen();
                    MessageBox.Show("¡Tipo de Examen eliminado correctamente!", "Eliminar Tipo de Examen",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("¡El Tipo de Examen no puede ser eliminado!\n" + resultado.Mensaje,
                        "Eliminar Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cboMotivoConsulta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            limpiarPanelPrincipal();
            cargarComboTipoExamen();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarResumen();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //DialogResult rpta = MessageBox.Show("La ventana se cerrara y perderá las modificaciones que no hayan guardado", "Configuración tipo examen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (rpta == DialogResult.Yes)
            //{
                this.Close();
            //}
        }

        private void frmConfigTipoExamen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult rpta = MessageBox.Show("La ventana se cerrara y perderá las modificaciones que no hayan guardado", "Configuración tipo examen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rpta == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }




 



    }
}
