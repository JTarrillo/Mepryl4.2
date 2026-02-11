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
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmConfigTipoExamenExApt : DevExpress.XtraEditors.XtraForm
    {
        private CapaNegocioMepryl.TipoExamen tipoExamen;
        private string strEstadoEdicion = "";
        private bool blnEstadoTipoExamen = false;        
        private bool blnEstadoGuardo = false;
        private string strIdEspecialidadViejo = "";
        private string strDescripcionViejo = "";


        public frmConfigTipoExamenExApt()
        {
            InitializeComponent();
            inicializar();
        }

        public frmConfigTipoExamenExApt(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            inicializar();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
        }


        private void inicializar()
        {
            tipoExamen = new CapaNegocioMepryl.TipoExamen();
            cargarComboMotivoConsulta();
            modoMenu();

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

                strDescripcionViejo = entidad.Descripcion;
            }
        }

        private void llenarFormularioPadre()
        {
            limpiarPanelPrincipal();
            if (cboSubTipo.SelectedIndex != -1)
            {
                Entidades.TipoExamen entidad = tipoExamen.cargarEntidad(cboSubTipo.SelectedValue.ToString());
                //tbId.Text = entidad.Id.ToString();
                tbCodigo.Text = entidad.Codigo.ToString();
                //tbDescripcion.Text = entidad.Descripcion;
                //tbDescripcionInformes.Text = entidad.DescripcionInformes;
                if (entidad.PrecioBase != 0)
                {
                    //tbPrecioBase.Text = entidad.PrecioBase.ToString();
                }
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
                tabControl.Enabled = true;
                botEditar.Enabled = true;
                botEliminar.Enabled = true;
                llenarFormulario();
            }

            strIdEspecialidadViejo = cboTipoExamen.SelectedValue.ToString();
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

        private void limpiarPanelParcial()
        {
            tbId.Clear();
            tbCodigo.Clear();
            tbDescripcion.Clear();
            tbDescripcionInformes.Clear();
            tbPrecioBase.Clear();
            //dgvClinico.DataSource = null;
            //dgvHematologia.DataSource = null;
            //dgvQuimicaHematica.DataSource = null;
            //dgvSerologia.DataSource = null;
            //dgvPerfilLipidico.DataSource = null;
            //dgvBacteriologia.DataSource = null;
            //dgvOrina.DataSource = null;
            //dgvLaboralesBasicas.DataSource = null;
            //dgvCraneoYMSuperior.DataSource = null;
            //dgvTroncoYPelvis.DataSource = null;
            //dgvMiembroInferior.DataSource = null;
            //dgvEstComplementarios.DataSource = null;
            //tbResumenClinico.Clear();
            //tbResumenLaboratorio.Clear();
            //tbResumenRx.Clear();
            //tbResumenEstCompl.Clear();
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

            //
            botAgregar.Visible = false;
            botEditar.Visible = false;
            botEliminar.Visible = false;
        }

        private void modoMenu()
        {
            panelMenu.Enabled = true;
            botGuardar.Visible = false;
            botCancelar.Visible = false;
            cambiarHabilitacionControles(false);
            llenarFormulario();

            //
            botAgregar.Visible = true;
            botEditar.Visible = true;
            botEliminar.Visible = false;
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

            if(cboTipoExamen.Text == "" && tbDescripcion.Text == "")
            {
                this.Close();
            }
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            blnEstadoGuardo = true;
            guardar();
            //
            //botAgregar.Visible = true;
            //botEditar.Visible = true;
            //botEliminar.Visible = true;

            if (blnEstadoGuardo)
            {
                //this.Close();
            }
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
            if (true)
            {
                //
                if (strDescripcionViejo != tbDescripcion.Text)
                {
                    if (tipoExamen.VerificaNombreRepetido(tbDescripcion.Text))
                    {
                        MessageBox.Show("Ya existe un examen con esa descripción", "Crear Tipo Examen",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnEstadoGuardo = false;
                        return;
                    }
                }

                string strIdEspecialidad = ValidarExisteExamen();

                if (strIdEspecialidad != strIdEspecialidadViejo)
                {
                    if (!string.IsNullOrEmpty(strIdEspecialidad))
                    {
                        MessageBox.Show("El examen " + tipoExamen.DescripcionEspecialidad(strIdEspecialidad) + " contiene los mismos ítems\n\n", "Crear Tipo Examen",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnEstadoGuardo = false;
                        return;
                    }
                }
                else
                {
                    MsgBoxUtil.HackMessageBox("Actualizar", "Crear Nuevo", "Cancelar");
                    DialogResult resultExamen = MessageBox.Show("¿Desea crear un nuevo examen o actualizar el mismo? ", "Crear Tipo Examen",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (resultExamen == DialogResult.Yes)
                    {
                        // continua con el proceso normal
                    }
                    else if(resultExamen == DialogResult.No)
                    {
                        //blnEstadoGuardo = false;
                        tbDescripcion.Text = "";
                        tbDescripcionInformes.Text = "";
                        tbPrecioBase.Text = "";
                        tbId.Text = "";
                        blnEstadoGuardo = false;
                        return;
                    }
                    else if(resultExamen == DialogResult.Cancel)
                    {
                        blnEstadoGuardo = false;
                        return;
                    }
                }
                //

                resultado = tipoExamen.editarTipoExamen(entidad);
                if (resultado.Modo == 1)
                {
                    MessageBox.Show("Exámen de aptitud editado correctamente", "Crear Tipo Examen",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    modoMenu();
                    llenarFormulario();
                }
                else
                {
                    MessageBox.Show("¡Error al editar Tipo de Examen!\nError:" + resultado.Mensaje, "Editar Tipo Examen",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    blnEstadoGuardo = false;
                }
            }
            else
            {
                //
                
                if (tipoExamen.VerificaNombreRepetido(tbDescripcion.Text))
                {
                    MessageBox.Show("Ya existe un examen con esa descripción", "Crear Tipo Examen",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnEstadoGuardo = false;
                    return;
                }

                string strIdEspecialidad = ValidarExisteExamen();
                if (!string.IsNullOrEmpty(strIdEspecialidad))
                {
                    MessageBox.Show("El examen " + tipoExamen.DescripcionEspecialidad(strIdEspecialidad) + " contiene los mismos ítems", "Crear Tipo Examen",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnEstadoGuardo = false;
                    return;
                }
                //
                resultado = tipoExamen.crearTipoExamenHijo(entidad);
                if (resultado.Modo == 1)
                {
                    MessageBox.Show("Exámen de aptitud guardado correctamente", "Crear Tipo Examen",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (tbId.Text != string.Empty)
            {
                retorno.Id = new Guid(tbId.Text);
            }
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

            //Modificado
            retorno.Padre = false;
            retorno.IdPadre = cboSubTipo.SelectedValue.ToString();
            return retorno;

        }

        public void botAgregar_Click(object sender, EventArgs e)
        {
            nuevoTipoExamenParcial();
            if(cboMotivoConsulta.SelectedIndex != -1 && cboSubTipo.SelectedIndex != -1)
            {
                modoEdicion();
            }
            else
            {
                DialogResult result = MessageBox.Show("Debe seleccionar el tipo de exámen para continuar",
                "Crear tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

             // agregado
            //botAgregar.Visible = false;
            //botEditar.Visible = false;
            //botEliminar.Visible = false;
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

        private void nuevoTipoExamenParcial()
        {
            limpiarPanelParcial();
            cboTipoExamen.SelectedIndex = -1;
            modoEdicion();
            Entidades.TipoExamen entidad = tipoExamen.cargarItems();
            tbCodigo.Text = entidad.Codigo.ToString();
            //llenarDataGrids(entidad);
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
            //cargarComboTipoExamen();
            cargarComboSubTipo();            
            cboTipoExamen.DataSource = null;
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

        private void cboSubTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //cargarComboTipoExamen();
            botEditar.Enabled = false;
            botEliminar.Enabled = false;
            limpiarPanelPrincipal();
            if (cboSubTipo.SelectedIndex != -1)
            {
                tabControl.Enabled = true;
                botEditar.Enabled = true;
                botEliminar.Enabled = true;
                cargarComboTipoExamen();
                //llenarFormulario();
                llenarFormularioPadre();
            }

            strIdEspecialidadViejo = cboSubTipo.SelectedValue.ToString();
        }

        private void botSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ValidarExisteExamen()
        {
            string resultado = "";
            DataTable dtTipoExamenes = tipoExamen.ListaEstudioPorTipoExamen();
            Entidades.TipoExamen entidad =  llenarDatosEntidad();
            bool blnRtdoClinico = false;
            bool blnRtdoHematologia = false;
            bool blnQuimicaHematica = false;
            bool blnSerologia = false;
            bool blnPerfilLipidico = false;
            bool blnBactereologia = false;
            bool blnOrina = false;
            bool blnLaboralesBasicas = false;
            bool blnCraneoYMSuperior = false;
            bool blnTroncoYPelvis = false;
            bool blnMiembroInferiro = false;
            bool blnEstComplementario = false;
            
            if (dtTipoExamenes.Rows.Count > 0)
            {
                if (entidad.Clinico.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTipoExamenes.Rows.Count; i++)
                    {
                        // Clinico
                        byte n = 2;

                        for (int j = 0; j < entidad.Clinico.Rows.Count; j++)
                        {
                            if (n != 5)
                            {
                                string strValorVI = entidad.Clinico.Rows[j][2].ToString();
                                string strValorDB = dtTipoExamenes.Rows[i][n].ToString();
                                blnRtdoClinico = (strValorVI != strValorDB) ? true : false;
                                if (blnRtdoClinico)
                                {
                                    break;
                                }
                            }

                            n += 1;
                        }

                        //Hematologia
                        n = 5;

                        for (int j = 0; j < entidad.Hematologia.Rows.Count; j++)
                        {
                            string strValorVI = entidad.Hematologia.Rows[j][2].ToString();
                            string strValorDB = dtTipoExamenes.Rows[i][n].ToString();
                            blnRtdoHematologia = (entidad.Hematologia.Rows[j][2].ToString() != dtTipoExamenes.Rows[i][n].ToString()) ? true : false;
                            if (blnRtdoHematologia)
                            {
                                break;
                            }


                            n += 1;
                        }

                        //Quimica Hematica
                        n = 10;

                        for (int j = 0; j < entidad.QuimicaHematica.Rows.Count; j++)
                        {
                            string strValorVI = entidad.QuimicaHematica.Rows[j][2].ToString();
                            string strValorDB = dtTipoExamenes.Rows[i][n].ToString();

                            blnQuimicaHematica = (entidad.QuimicaHematica.Rows[j][2].ToString() != dtTipoExamenes.Rows[i][n].ToString()) ? true : false;
                            if (blnQuimicaHematica)
                            {
                                break;
                            }

                            n += 1;
                        }

                        //Serologia
                        n = 23;

                        for (int j = 0; j < entidad.Serologia.Rows.Count; j++)
                        {
                            string strValorVI = entidad.Serologia.Rows[j][2].ToString();
                            string strValorDB = dtTipoExamenes.Rows[i][n].ToString();

                            blnSerologia = (entidad.Serologia.Rows[j][2].ToString() != dtTipoExamenes.Rows[i][n].ToString()) ? true : false;
                            if (blnSerologia)
                            {
                                break;
                            }

                            n += 1;
                        }

                        //Perfil Lipidico
                        n = 31;

                        for (int j = 0; j < entidad.PerfilLipidico.Rows.Count; j++)
                        {
                            string strValorVI = entidad.PerfilLipidico.Rows[j][2].ToString();
                            string strValorDB = dtTipoExamenes.Rows[i][n].ToString();

                            blnPerfilLipidico = (entidad.PerfilLipidico.Rows[j][2].ToString() != dtTipoExamenes.Rows[i][n].ToString()) ? true : false;
                            if (blnPerfilLipidico)
                            {
                                break;
                            }

                            n += 1;
                        }

                        //Bactereologia
                        n = 35;

                        for (int j = 0; j < entidad.Bacteriologia.Rows.Count; j++)
                        {
                            string strValorVI = entidad.Bacteriologia.Rows[j][2].ToString();
                            string strValorDB = dtTipoExamenes.Rows[i][n].ToString();

                            blnBactereologia = (entidad.Bacteriologia.Rows[j][2].ToString() != dtTipoExamenes.Rows[i][n].ToString()) ? true : false;
                            if (blnBactereologia)
                            {
                                break;
                            }

                            n += 1;
                        }

                        //Orina
                        n = 38;

                        for (int j = 0; j < entidad.Orina.Rows.Count; j++)
                        {
                            string strValorVI = entidad.Orina.Rows[j][2].ToString();
                            string strValorDB = dtTipoExamenes.Rows[i][n].ToString();

                            blnOrina = (entidad.Orina.Rows[j][2].ToString() != dtTipoExamenes.Rows[i][n].ToString()) ? true : false;
                            if (blnOrina)
                            {
                                break;
                            }

                            n += 1;
                        }

                        //LaboralesBasicas
                        n = 39;

                        for (int j = 0; j < entidad.LaboralesBasicas.Rows.Count; j++)
                        {
                            string strValorVI = entidad.LaboralesBasicas.Rows[j][2].ToString();
                            string strValorDB = dtTipoExamenes.Rows[i][n].ToString();

                            blnLaboralesBasicas = (entidad.LaboralesBasicas.Rows[j][2].ToString() != dtTipoExamenes.Rows[i][n].ToString()) ? true : false;
                            if (blnLaboralesBasicas)
                            {
                                break;
                            }

                            n += 1;
                        }

                        //CraneoYM Superior
                        n = 48;

                        for (int j = 0; j < entidad.CraneoYMSuperior.Rows.Count; j++)
                        {
                            string strValorVI = entidad.CraneoYMSuperior.Rows[j][2].ToString();
                            string strValorDB = dtTipoExamenes.Rows[i][n].ToString();

                            blnCraneoYMSuperior = (entidad.CraneoYMSuperior.Rows[j][2].ToString() != dtTipoExamenes.Rows[i][n].ToString()) ? true : false;
                            if (blnCraneoYMSuperior)
                            {
                                break;
                            }

                            n += 1;
                        }

                        //Tronco Y Pelvis
                        n = 56;

                        for (int j = 0; j < entidad.TroncoYPelvis.Rows.Count; j++)
                        {
                            string strValorVI = entidad.TroncoYPelvis.Rows[j][2].ToString();
                            string strValorDB = dtTipoExamenes.Rows[i][n].ToString();

                            blnTroncoYPelvis = (entidad.TroncoYPelvis.Rows[j][2].ToString() != dtTipoExamenes.Rows[i][n].ToString()) ? true : false;
                            if (blnTroncoYPelvis)
                            {
                                break;
                            }

                            n += 1;
                        }

                        //Miembro Inferior
                        n = 62;

                        for (int j = 0; j < entidad.MiembroInferior.Rows.Count; j++)
                        {
                            string strValorVI = entidad.MiembroInferior.Rows[j][2].ToString();
                            string strValorDB = dtTipoExamenes.Rows[i][n].ToString();

                            if (n != 70)
                            {
                                blnMiembroInferiro = (entidad.MiembroInferior.Rows[j][2].ToString() != dtTipoExamenes.Rows[i][n].ToString()) ? true : false;
                                if (blnMiembroInferiro)
                                {
                                    break;
                                }
                            }

                            n += 1;
                        }

                        //Estudio Complementario
                        n = 69; //71;

                        for (int j = 0; j < entidad.EstComplementarios.Rows.Count; j++)
                        {
                            string strValorVI = entidad.EstComplementarios.Rows[j][2].ToString();
                            string strValorDB = dtTipoExamenes.Rows[i][n].ToString();

                            if (n != 70)
                            {
                                blnEstComplementario = (entidad.EstComplementarios.Rows[j][2].ToString() != dtTipoExamenes.Rows[i][n].ToString()) ? true : false;
                                if (blnEstComplementario)
                                {
                                    break;
                                }                                
                            }

                            if (n == 70)
                            {
                                j--;
                            }

                            n += 1;
                        }

                        if(blnRtdoClinico == false &&
                           blnRtdoHematologia == false &&
                           blnQuimicaHematica == false &&
                           blnSerologia == false &&
                           blnPerfilLipidico == false &&
                           blnBactereologia == false &&
                           blnOrina == false &&
                           blnLaboralesBasicas == false &&
                           blnCraneoYMSuperior == false &&
                           blnTroncoYPelvis == false &&
                           blnMiembroInferiro == false && 
                           blnEstComplementario == false)
                        {
                            return dtTipoExamenes.Rows[i][1].ToString();
                        } 
                    } 
                } 
            }
            
            return resultado;
        }

        public void CargarDatosEditar(string IdEspecialidadPadre, string IdEspecialidad, string strEstado)
        {
            strIdEspecialidadViejo = IdEspecialidad;
            strEstadoEdicion = strEstado;
            cboMotivoConsulta.SelectedValue = int.Parse(tipoExamen.ObtenerMotivoConsulta(IdEspecialidad));
            cboSubTipo.SelectedValue = IdEspecialidadPadre;
            blnEstadoTipoExamen = true;
            cboTipoExamen.SelectedValue = IdEspecialidad;
            strEstadoEdicion = "";
            blnEstadoTipoExamen = false;
            cboTipoExamen.Enabled = false;
            cboSubTipo.Enabled = false;
            cboMotivoConsulta.Enabled = false;
            
        }

        private void cboMotivoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (strEstadoEdicion == "EDITAR")
            {
                cargarComboSubTipo();
            }
        }

        private void cboSubTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (strEstadoEdicion == "EDITAR")
            {
                cargarComboTipoExamen();
            }
        }

        private void cboTipoExamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (strEstadoEdicion == "EDITAR" && blnEstadoTipoExamen == true)
            {
                cboTipoExamen_SelectionChangeCommitted(sender, e);
            }
        }

        private void cargarComboMotivoConsulta()
        {
            //cboMotivoConsulta.DataSource = tipoExamen.cargarMotivosDeConsulta();
            cboMotivoConsulta.DataSource = tipoExamen.cargarMotivosDeConsultaTipoExamen();
            cboMotivoConsulta.ValueMember = "id";
            cboMotivoConsulta.DisplayMember = "nombre";
            cboMotivoConsulta.SelectedIndex = -1;
        }

        private void cargarComboTipoExamen()
        {
            if (cboMotivoConsulta.SelectedIndex != -1)
            {
                if (strEstadoEdicion != "EDITAR")
                {
                    cboTipoExamen.DataSource = tipoExamen.cargarTiposDeExamenHijo(cboMotivoConsulta.SelectedValue.ToString(), cboSubTipo.SelectedValue.ToString());
                }
                else
                {
                    cboTipoExamen.DataSource = tipoExamen.cargarTiposDeExamenHijo(cboMotivoConsulta.SelectedValue.ToString());
                }
                cboTipoExamen.ValueMember = "id";
                cboTipoExamen.DisplayMember = "descripcion";
                cboTipoExamen.SelectedIndex = -1;
            }
        }

        private void cargarComboSubTipo()
        {
            if (cboMotivoConsulta.SelectedIndex != -1)
            {
                cboSubTipo.DataSource = tipoExamen.cargarTiposDeExamenPadre(cboMotivoConsulta.SelectedValue.ToString());
                cboSubTipo.ValueMember = "id";
                cboSubTipo.DisplayMember = "descripcion";
                cboSubTipo.SelectedIndex = -1;
            }
        }

        public void OcultarEditar()
        {
            botEditar.Visible = false;            
        }

        public void OcultarAgregar()
        {
            botAgregar.Visible = false;
        }

        public void verificaTipoExamen()
        {
            //
            //MsgBoxUtil.HackMessageBox("Todos", "Seleccionados", "Cancelar");
            //DialogResult resultExamen = MessageBox.Show("¿Desea enviar un correo a los pacientes con su estudio consolidado?\n\n", "Enviar correo",
            //    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (strDescripcionViejo != tbDescripcion.Text)
            {
                if (tipoExamen.VerificaNombreRepetido(tbDescripcion.Text))
                {
                    MessageBox.Show("Ya existe un examen con el mismo nombre", "Crear Tipo Examen",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnEstadoGuardo = false;
                    return;
                }
            }

            string strIdEspecialidad = ValidarExisteExamen();

            if (strIdEspecialidad != strIdEspecialidadViejo)
            {
                if (!string.IsNullOrEmpty(strIdEspecialidad))
                {
                    MsgBoxUtil.HackMessageBox("Actualizar", "Crear Nuevo", "Cancelar");
                    DialogResult resultExamen = MessageBox.Show("El examen " + tipoExamen.DescripcionEspecialidad(strIdEspecialidad) + " contiene los mismos ítems\n\n", "Crear Tipo Examen",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    blnEstadoGuardo = false;
                    return;
                }
            }
            //
        }
    }
}
