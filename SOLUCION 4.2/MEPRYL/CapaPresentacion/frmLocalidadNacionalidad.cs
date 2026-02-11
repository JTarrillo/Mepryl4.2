


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using CapaPresentacionBase;
using CapaPresentacion;

namespace CapaPresentacion
{
    public partial class frmLocalidadNacionalidad : DevExpress.XtraEditors.XtraForm
    {

        private CapaNegocioMepryl.Nacionalidades nacionalidades;

        public frmLocalidadNacionalidad()
        {
            InitializeComponent();
            inicializar();
            inicializar2();
        }

        public frmLocalidadNacionalidad(frmBasePrincipal parentForm)
        {
            InitializeComponent();

            this.BtnGrabar.Visible = false;

            inicializar2();
            inicializar4();
            inicializar7();

            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;

            tab.TabPages.Remove(tabPage4);
            tab.TabPages.Remove(tabPage2);
            tab.TabPages.Remove(tabPage5);
            tab.TabPages.Remove(tabPage3);
            tab.TabPages.Remove(tabPage1);

            botAgregar.Visible = false;
        }

        // *** Inicio Nacionalidad ***
        private void inicializar()
        {
            nacionalidades = new CapaNegocioMepryl.Nacionalidades();
            llenarDgv();
            modoConsulta();
        }

        private void modoConsulta()
        {
            panelPrincipal.Visible = true;
            panelPrincipal.Enabled = true;
            panelEdicion.Visible = false;
        }

        private void llenarDgv()
        {
            dgv.DataSource = nacionalidades.cargarNacionalidades();
            dgv.Columns[0].Visible = false;
        }

        private void botEditar_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void editar()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                modoEdicion();
            }
        }

        private void modoEdicion()
        {
            panelPrincipal.Enabled = false;
            panelEdicion.Visible = true;
            tbId.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();
            tbCodigo.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();
            tbDescripcion.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            modoConsulta();
            limpiarFormulario();
        }

        private void botAgregar_Click(object sender, EventArgs e)
        {
            modoNuevo();
        }

        private void limpiarFormulario()
        {
            tbId.Text = string.Empty;
            tbCodigo.Text = string.Empty;
            tbDescripcion.Text = string.Empty;
        }

        private void modoNuevo()
        {
            limpiarFormulario();
            panelEdicion.Visible = true;
            panelPrincipal.Enabled = false;
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                eliminar();
            }
        }


        private void AjustarScrollDgvClinico()
        {
            if (dgvClinico.Rows.Count > 15)
            {
                dgvClinico.ScrollBars = ScrollBars.Vertical;
                dgvClinico.Height = 15 * dgvClinico.RowTemplate.Height + dgvClinico.ColumnHeadersHeight + 5;
            }
            else
            {
                dgvClinico.ScrollBars = ScrollBars.None;
                dgvClinico.Height = dgvClinico.Rows.Count * dgvClinico.RowTemplate.Height + dgvClinico.ColumnHeadersHeight + 5;
            }
        }

        private void eliminar()
        {
            if (nacionalidades.verificarNacionalidadAsignada(dgv.SelectedRows[0].Cells[0].Value.ToString()))
            {
                Entidades.Resultado result = nacionalidades.eliminar(dgv.SelectedRows[0].Cells[0].Value.ToString());
                if (result.Modo == -1)
                {
                    MessageBox.Show("¡La nacionalidad seleccionada no puede ser eliminada!", "Eliminar Nacionalidad",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                llenarDgv();
            }
            else
            {
                MessageBox.Show("¡La nacionalidad asignada no puede ser eliminada porque ya se encuentra asignada a un paciente!", "Eliminar Nacionalidad",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void evaluarResultado(Entidades.Resultado result, string mensaje1, string mensaje2)
        {
            if (result.Modo == 1)
            {
                modoConsulta();
                limpiarFormulario();
                llenarDgv();
            }
            else
            {
                MessageBox.Show("¡Error al " + mensaje1 + " Nacionalidad!", mensaje1 + " Nacionalidad",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            if (tbDescripcion.Text.Length > 0)
            {
                Entidades.Resultado resultado;
                string mensaje1;
                string mensaje2;
                if (tbId.Text == string.Empty)
                {
                    resultado = nacionalidades.guardar(tbDescripcion.Text);
                    mensaje1 = "Guardar";
                    mensaje2 = "Guardada";
                }
                else
                {
                    resultado = nacionalidades.editar(tbId.Text, tbDescripcion.Text);
                    mensaje1 = "Editar";
                    mensaje2 = "Editada";
                }
                evaluarResultado(resultado, mensaje1, mensaje2);
            }
            else
            {
                MessageBox.Show("El ingreso de la descripción es obligatorio",
                    "Ingresar descripción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // *** Fin Nacionalidad ***
        // **********************************************************************************************************************
        // ***Inicio Localidades ***

        private CapaNegocioMepryl.LocalidadesYPrestaciones localidPrest;

        private void inicializar2()
        {
            localidPrest = new CapaNegocioMepryl.LocalidadesYPrestaciones();
            panelEdicion2.Visible = false;
            cboTipoPrestacion2.SelectedIndex = -1;
            cboTipoPrestacion2.SelectedIndex = 1;
            llenarComboZonas2();
        }

        private void cboTipoPrestacion2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPrestacion2.SelectedIndex != -1)
            {
                llenarDgv2();
            }
        }

        private void llenarComboZonas2()
        {
            cboZona2.DataSource = localidPrest.cargarZonas();
            cboZona2.ValueMember = "Id";
            cboZona2.DisplayMember = "Descripcion";
            cboZona2.SelectedIndex = -1;
        }

        private void llenarDgv2()
        {
            dgv2.DataSource = null;
            tbBusquedaPrestacion2.Clear();
            dgv2.DataSource = localidPrest.cargarLocalidadesYPrestaciones(obtenerItemSeleccionado2(cboTipoPrestacion2));
            dgv2.Columns[0].Visible = false;
            dgv2.Columns[2].Visible = false;
            dgv2.Columns[4].Visible = false;
            dgv2.Columns[5].Visible = false;
            if (cboTipoPrestacion2.SelectedIndex == 1)
            {
                dgv2.Columns[5].Visible = true;
            }

            dgv2.Columns[3].HeaderText = "Prestaciones";
        }

        private string obtenerItemSeleccionado2(ComboBox cbo)
        {
            int switchCase = cbo.SelectedIndex;
            switch (switchCase)
            {
                case 0:
                    return "P";
                case 1:
                    return "V";
                case 2:
                    return "M";
                case 3:
                    return "L";
            }
            return string.Empty;
        }
        /// <summary>
        /// Refresca la pantalla como si fuera la primera vez (puedes personalizar la lógica interna).
        /// </summary>
        public void RefrescarPantalla()
        {
            // Debug: inicio de reinicio total
            System.Diagnostics.Debug.WriteLine("[DEBUG][RefrescarPantalla] Reinicio total solicitado");

            // Limpiar instancias embebidas y variables temporales
            limpiarFrmAgregarEspecialidades();
            // Si tienes más variables de estado globales, agrégalas aquí

            // Selecciona la solapa "Tipo de Examen Médico" si existe
            foreach (TabPage page in tab.TabPages)
            {
                if (page.Text == "Tipo de Examen Médico")
                {
                    tab.SelectedTab = page;
                    break;
                }
            }

            // Refresca los datos del formulario y los DataGrids
            llenarFormulario();

            // Lógica de refresco original
            this.OnLoad(EventArgs.Empty);

            // Debug: fin de reinicio total
            System.Diagnostics.Debug.WriteLine("[DEBUG][RefrescarPantalla] Reinicio total finalizado");
        }
        /// <summary>
        /// Lleva a la solapa de Tipo de Examen Médico en el formulario de especialidades, si corresponde.
        /// </summary>
        public void SeleccionarTabTipoExamenMedico()
        {
            // Si tienes una referencia al formulario FrmAñadirEspecialidad, llama a su método público
            // Por ejemplo:
            // if (this.frmAñadirEspecialidad != null)
            //     this.frmAñadirEspecialidad.SeleccionarTabTipoExamenMedico();
            // Si el control está embebido, accede al TabControl y selecciona la solapa correspondiente
        }
        private void tbBusquedaPrestacion2_TextChanged(object sender, EventArgs e)
        {
            filtrarLocalidadesYPrestaciones2();
        }

        private void filtrarLocalidadesYPrestaciones2()
        {
            if (cboTipoPrestacion2.SelectedIndex != -1)
            {
                dgv2.DataSource = localidPrest.cargarLocalidadesYPrestacionesFiltro(obtenerItemSeleccionado2(cboTipoPrestacion2), tbBusquedaPrestacion2.Text);
                dgv2.Columns[0].Visible = false;
                dgv2.Columns[2].Visible = false;
                dgv2.Columns[4].Visible = false;
                dgv2.Columns[5].Visible = false;
                if (cboTipoPrestacion2.SelectedIndex == 1)
                {
                    dgv2.Columns[5].Visible = true;
                }
            }
        }

        private void botEditar2_Click(object sender, EventArgs e)
        {
            modoEdicion2();
        }

        public void RefrescarTabTipoExamenMedicoCompleto()
        {
            // Limpiar panel y combos
            limpiarPanelPrincipal();
            cboMotivoConsulta.DataSource = null;
            cboSubTipo.DataSource = null;
            cboTipoExamen.DataSource = null;
            // Recargar motivos
            cargarComboMotivoConsulta();
        }

        private void modoEdicion2()
        {
            if (dgv2.SelectedRows.Count > 0)
            {
                txtId2.Text = dgv2.SelectedRows[0].Cells[0].Value.ToString();
                txtCodigo2.Text = dgv2.SelectedRows[0].Cells[1].Value.ToString();
                cboTipoPrestacionEditar2.SelectedIndex = cboTipoPrestacion2.SelectedIndex;
                txtDescripcion2.Text = dgv2.SelectedRows[0].Cells[3].Value.ToString();
                if (aplicaZona2())
                {
                    cboZona2.SelectedValue = dgv2.SelectedRows[0].Cells[4].Value.ToString();
                    if (dgv2.SelectedRows[0].Cells[4].Value.ToString() == string.Empty)
                    {
                        cboZona2.SelectedIndex = 0;
                    }
                }
                panelEdicion2.Visible = true;
                panelPrincipal2.Enabled = false;
            }
        }

        private bool aplicaZona2()
        {
            cboZona2.Visible = false;
            lblZona2.Visible = false;
            if (obtenerItemSeleccionado2(cboTipoPrestacion2) == "V")
            {
                cboZona2.Visible = true;
                lblZona2.Visible = true;
                return true;
            }
            return false;
        }

        private void limpiarFormulario2()
        {
            txtId2.Clear();
            txtCodigo2.Clear();
            txtDescripcion2.Clear();
            cboZona2.SelectedIndex = -1;
            cboTipoPrestacionEditar2.SelectedIndex = 0;
        }

        private void botCancelar2_Click(object sender, EventArgs e)
        {
            modoConsulta2();
        }

        private void modoConsulta2()
        {
            limpiarFormulario2();
            panelEdicion2.Visible = false;
            panelPrincipal2.Enabled = true;
        }

        private void botGuardar2_Click(object sender, EventArgs e)
        {
            guardar2();
        }

        private void guardar2()
        {
            if (txtDescripcion2.Text.Length > 0)
            {
                Entidades.Resultado resultado;
                string mensaje1;
                string mensaje2;
                if (txtId2.Text == string.Empty)
                {
                    resultado = localidPrest.guardarNueva(cargarDatosEntidad2());
                    mensaje1 = "Guardar";
                    mensaje2 = "Guardada";
                }
                else
                {
                    resultado = localidPrest.editar(cargarDatosEntidad2());
                    mensaje1 = "Editar";
                    mensaje2 = "Editada";
                }
                evaluarResultado2(resultado, mensaje1, mensaje2);
            }
            else
            {
                MessageBox.Show("El ingreso de la descripción es obligatorio",
                    "Ingresar descripción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void evaluarResultado2(Entidades.Resultado result, string mensaje1, string mensaje2)
        {
            if (result.Modo == 1)
            {
                modoConsulta2();
                llenarDgv2();
            }
            else
            {
                MessageBox.Show("¡Error al " + mensaje1 + " Localidad/Prestación!", mensaje1 + " Localidad/Prestación",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void botEliminar2_Click(object sender, EventArgs e)
        {
            eliminar2();
        }

        private void eliminar2()
        {
            if (dgv2.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Realmente desea eliminar la prestación/localidad seleccionada?",
                    "Eliminar Prestación/Localidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    eliminarLocalidadPrestacion2(dgv2.SelectedRows[0].Cells[0].Value.ToString(),
                        dgv2.SelectedRows[0].Cells[2].Value.ToString());
                }
            }
        }

        private void eliminarLocalidadPrestacion2(string id, string tipo)
        {
            if (verificarEliminar2(id, tipo))
            {
                Entidades.Resultado result = localidPrest.eliminar(id);
                if (result.Modo == 1)
                {
                    MessageBox.Show("¡Localidad/Prestación eliminada correctamente!",
                        "Eliminar Localidad/Prestación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenarDgv2();
                }
                else
                {
                    MessageBox.Show("¡Error al eliminar Localidad/Prestación!",
                      "Eliminar Localidad/Prestación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar la Localidad/Prestación. ¡Se encuentra asignada a una consulta o paciente!", "Eliminar Localidad/Prestación",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private Entidades.LocalidadPrestacion cargarDatosEntidad2()
        {
            Entidades.LocalidadPrestacion retorno = new LocalidadPrestacion();
            if (txtId2.Text != string.Empty) { retorno.Id = new Guid(txtId2.Text); }
            retorno.Tipo = obtenerItemSeleccionado2(cboTipoPrestacionEditar2);
            retorno.Descripcion = txtDescripcion2.Text;
            if (cboZona2.SelectedIndex > 0) { retorno.Zona = Convert.ToInt16(cboZona2.SelectedValue.ToString()); }
            return retorno;
        }

        private void botAgregar2_Click(object sender, EventArgs e)
        {
            modoNuevo2();
        }

        private void modoNuevo2()
        {
            if (cboTipoPrestacion2.SelectedIndex != -1)
            {
                limpiarFormulario2();
                panelEdicion2.Visible = true;
                panelPrincipal2.Enabled = false;
                cboTipoPrestacionEditar2.SelectedIndex = cboTipoPrestacion2.SelectedIndex;
                aplicaZona2();
            }
            else
            {
                MessageBox.Show("Agregar Localidad/Prestación", "¡Seleccione el tipo de Prestación que desea agregar!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool verificarEliminar2(string id, string tipo)
        {
            return localidPrest.verificarEliminar(id, tipo);
        }

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ***Fin Localidades ***
        // **********************************************************************************************************************
        // ***Inicio Prestaciones ***

        private CapaNegocioMepryl.LocalidadesYPrestaciones localidPrest4;

        private void inicializar4()
        {
            localidPrest = new CapaNegocioMepryl.LocalidadesYPrestaciones();
            panelEdicion4.Visible = false;
            cboTipoPrestacion4.SelectedIndex = -1;
            cboTipoPrestacion4.SelectedIndex = 1;
            llenarComboZonas4();
        }
        private void inicializar6()
        {
            localidPrest = new CapaNegocioMepryl.LocalidadesYPrestaciones();
            panelEdicion6.Visible = false;
            cboTipoPrestacion6.SelectedIndex = -1;
            cboTipoPrestacion6.SelectedIndex = 1;
            llenarComboZonas6();

            btnGuardar5.Visible = false;
            btnCancelar5.Visible = false;
        }

        private void cboTipoPrestacion4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPrestacion4.SelectedIndex != -1)
            {
                llenarDgv4();
            }
        }

        private void llenarComboZonas4()
        {
            cboZona4.DataSource = localidPrest.cargarZonas();
            cboZona4.ValueMember = "Id";
            cboZona4.DisplayMember = "Descripcion";
            cboZona4.SelectedIndex = -1;
        }

        private void llenarComboZonas6()
        {
            cboZona6.DataSource = localidPrest.cargarZonas();
            cboZona6.ValueMember = "Id";
            cboZona6.DisplayMember = "Descripcion";
            cboZona6.SelectedIndex = -1;
        }

        private void llenarDgv4()
        {
            dgv4.DataSource = null;
            txtBusquedaPrestacion4.Clear();
            dgv4.DataSource = localidPrest.cargarLocalidadesYPrestaciones(obtenerItemSeleccionado4(cboTipoPrestacion4));
            dgv4.Columns[0].Visible = false;
            dgv4.Columns[2].Visible = false;
            dgv4.Columns[4].Visible = false;
            dgv4.Columns[5].Visible = false;
            if (cboTipoPrestacion4.SelectedIndex == 1)
            {
                dgv4.Columns[5].Visible = true;
            }

            dgv4.Columns[3].HeaderText = "Localidades";
        }

        private void llenarDgv6()
        {
            dgv6.DataSource = null;
            txtBusquedaPrestacion6.Clear();
            //dgv6.DataSource = localidPrest.cargarLocalidadesYPrestaciones(obtenerItemSeleccionado4(cboTipoPrestacion6));
            dgv6.DataSource = localidPrest.cargarEspecialidad(txtBusquedaPrestacion6.Text);
            dgv6.Columns[0].Visible = false;
            dgv6.Columns[2].Visible = false;
            dgv6.Columns[4].Visible = false;
            dgv6.Columns[5].Visible = false;
            if (cboTipoPrestacion6.SelectedIndex == 1)
            {
                //dgv6.Columns[5].Visible = true;
            }
        }

        private string obtenerItemSeleccionado4(ComboBox cbo)
        {
            int switchCase = cbo.SelectedIndex;
            switch (switchCase)
            {
                case 0:
                    return "P";
                case 1:
                    return "V";
                case 2:
                    return "M";
                case 3:
                    return "L";
                case 4:
                    return "E";
            }
            return string.Empty;
        }

        private void tbBusquedaPrestacion4_TextChanged(object sender, EventArgs e)
        {
            filtrarLocalidadesYPrestaciones4();
        }

        private void filtrarLocalidadesYPrestaciones4()
        {
            if (cboTipoPrestacion4.SelectedIndex != -1)
            {
                dgv4.DataSource = localidPrest.cargarLocalidadesYPrestacionesFiltro(obtenerItemSeleccionado4(cboTipoPrestacion4), txtBusquedaPrestacion4.Text);
                dgv4.Columns[0].Visible = false;
                dgv4.Columns[2].Visible = false;
                dgv4.Columns[4].Visible = false;
                dgv4.Columns[5].Visible = false;
                if (cboTipoPrestacion4.SelectedIndex == 1)
                {
                    dgv4.Columns[5].Visible = true;
                }
            }
        }

        private void botEditar4_Click(object sender, EventArgs e)
        {
            modoEdicion4();
        }

        private void modoEdicion4()
        {
            if (dgv4.SelectedRows.Count > 0)
            {
                txtId4.Text = dgv4.SelectedRows[0].Cells[0].Value.ToString();
                txtCodigo4.Text = dgv4.SelectedRows[0].Cells[1].Value.ToString();
                cboTipoPrestacionEditar4.SelectedIndex = cboTipoPrestacion4.SelectedIndex;
                txtDescripcion4.Text = dgv4.SelectedRows[0].Cells[3].Value.ToString();
                if (aplicaZona4())
                {
                    cboZona4.SelectedValue = dgv4.SelectedRows[0].Cells[4].Value.ToString();
                    if (dgv4.SelectedRows[0].Cells[4].Value.ToString() == string.Empty)
                    {
                        cboZona4.SelectedIndex = 0;
                    }
                }
                panelEdicion4.Visible = true;
                panelPrincipal4.Enabled = false;
            }
        }

        private bool aplicaZona4()
        {
            cboZona4.Visible = false;
            lblZona4.Visible = false;
            if (obtenerItemSeleccionado4(cboTipoPrestacion4) == "V")
            {
                cboZona4.Visible = true;
                lblZona4.Visible = true;
                return true;
            }
            return false;
        }

        private void limpiarFormulario4()
        {
            txtId4.Clear();
            txtCodigo4.Clear();
            txtDescripcion4.Clear();
            cboZona4.SelectedIndex = -1;
            cboTipoPrestacionEditar4.SelectedIndex = 0;
        }

        private void botCancelar4_Click(object sender, EventArgs e)
        {
            modoConsulta4();
        }

        private void modoConsulta4()
        {
            limpiarFormulario4();
            panelEdicion4.Visible = false;
            panelPrincipal4.Enabled = true;
        }

        private void botGuardar4_Click(object sender, EventArgs e)
        {
            guardar4();
        }

        private void guardar4()
        {
            if (txtDescripcion4.Text.Length > 0)
            {
                Entidades.Resultado resultado;
                string mensaje1;
                string mensaje2;
                if (txtId4.Text == string.Empty)
                {
                    resultado = localidPrest.guardarNueva(cargarDatosEntidad4());
                    mensaje1 = "Guardar";
                    mensaje2 = "Guardada";
                }
                else
                {
                    resultado = localidPrest.editar(cargarDatosEntidad4());
                    mensaje1 = "Editar";
                    mensaje2 = "Editada";
                }
                evaluarResultado4(resultado, mensaje1, mensaje2);
            }
            else
            {
                MessageBox.Show("El ingreso de la descripción es obligatorio",
                    "Ingresar descripción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void evaluarResultado4(Entidades.Resultado result, string mensaje1, string mensaje2)
        {
            if (result.Modo == 1)
            {
                modoConsulta4();
                llenarDgv4();
            }
            else
            {
                MessageBox.Show("¡Error al " + mensaje1 + " Localidad/Prestación!", mensaje1 + " Localidad/Prestación",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void botEliminar4_Click(object sender, EventArgs e)
        {
            eliminar4();
        }

        private void eliminar4()
        {
            if (dgv4.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Realmente desea eliminar la prestación/localidad seleccionada?",
                    "Eliminar Prestación/Localidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    eliminarLocalidadPrestacion4(dgv4.SelectedRows[0].Cells[0].Value.ToString(),
                        dgv4.SelectedRows[0].Cells[2].Value.ToString());
                }
            }
        }

        private void eliminarLocalidadPrestacion4(string id, string tipo)
        {
            if (verificarEliminar4(id, tipo))
            {
                Entidades.Resultado result = localidPrest.eliminar(id);
                if (result.Modo == 1)
                {
                    MessageBox.Show("¡Localidad/Prestación eliminada correctamente!",
                        "Eliminar Localidad/Prestación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenarDgv4();
                }
                else
                {
                    MessageBox.Show("¡Error al eliminar Localidad/Prestación!",
                      "Eliminar Localidad/Prestación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar la Localidad/Prestación. ¡Se encuentra asignada a una consulta o paciente!", "Eliminar Localidad/Prestación",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private Entidades.LocalidadPrestacion cargarDatosEntidad4()
        {
            Entidades.LocalidadPrestacion retorno = new LocalidadPrestacion();
            if (txtId4.Text != string.Empty) { retorno.Id = new Guid(txtId4.Text); }
            retorno.Tipo = obtenerItemSeleccionado4(cboTipoPrestacionEditar4);
            retorno.Descripcion = txtDescripcion4.Text;
            if (cboZona4.SelectedIndex > 0) { retorno.Zona = Convert.ToInt16(cboZona4.SelectedValue.ToString()); }
            return retorno;
        }

        private void botAgregar4_Click(object sender, EventArgs e)
        {
            modoNuevo4();
        }

        private void modoNuevo4()
        {
            if (cboTipoPrestacion4.SelectedIndex != -1)
            {
                limpiarFormulario();
                panelEdicion4.Visible = true;
                panelPrincipal4.Enabled = false;
                cboTipoPrestacionEditar4.SelectedIndex = cboTipoPrestacion4.SelectedIndex;
                aplicaZona4();
            }
            else
            {
                MessageBox.Show("Agregar Localidad/Prestación", "¡Seleccione el tipo de Prestación que desea agregar!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool verificarEliminar4(string id, string tipo)
        {
            return localidPrest.verificarEliminar(id, tipo);
        }

        private void btnSalir4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalidadNacionalidad_Load(object sender, EventArgs e)
        {
            // cboTipoPrestacion2.Text = "LOCALIDAD";  // OCULTO: Localidades
            // cboTipoPrestacion4.Text = "PRESTACION";  // OCULTO: Prestaciones
            cboTipoPrestacion6.Text = "EXAMEN APTITUD";
        }

        // *** Fin Prestaciones ***
        // **********************************************************************************************************************
        // *** Inicio Zonas Geo ***

        private CapaNegocioMepryl.LocalidadesYPrestaciones localidades3;

        private void inicializar3()
        {
            localidades3 = new CapaNegocioMepryl.LocalidadesYPrestaciones();
            llenarDgv3();
            modoConsulta3();
        }

        private void llenarDgv3()
        {
            dgv3.DataSource = localidades3.cargarZonasSinNoAplica();
            dgv3.Columns[0].Visible = false;
        }

        private void modoConsulta3()
        {
            panelPrincipal3.Visible = true;
            panelPrincipal3.Enabled = true;
            panelEdicion3.Visible = false;
        }

        private void botEditar3_Click(object sender, EventArgs e)
        {
            editar3();
        }

        private void editar3()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                modoEdicion3();
            }
        }

        private void modoEdicion3()
        {
            panelPrincipal3.Enabled = false;
            panelEdicion3.Visible = true;
            txtId3.Text = dgv3.SelectedRows[0].Cells[0].Value.ToString();
            txtCodigo3.Text = dgv3.SelectedRows[0].Cells[1].Value.ToString();
            txtDescripcion3.Text = dgv3.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void botCancelar3_Click(object sender, EventArgs e)
        {
            modoConsulta3();
        }

        private void botAgregar3_Click(object sender, EventArgs e)
        {
            modoNuevo3();
        }

        private void limpiarFormulario3()
        {
            txtId3.Text = string.Empty;
            txtCodigo3.Text = string.Empty;
            txtDescripcion3.Text = string.Empty;
        }

        private void modoNuevo3()
        {
            limpiarFormulario3();
            panelEdicion3.Visible = true;
            panelPrincipal3.Enabled = false;
        }

        private void botEliminar3_Click(object sender, EventArgs e)
        {
            if (dgv3.SelectedRows.Count > 0)
            {
                eliminar3();
            }
        }

        private void eliminar3()
        {
            if (localidades3.verificarZonaAsignada(dgv3.SelectedRows[0].Cells[0].Value.ToString()))
            {
                Entidades.Resultado result = localidades3.eliminarZona(dgv3.SelectedRows[0].Cells[0].Value.ToString());
                if (result.Modo == -1)
                {
                    MessageBox.Show("¡La zona seleccionada no puede ser eliminada!", "Eliminar Zona",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                llenarDgv3();
            }
            else
            {
                MessageBox.Show("¡La zona asignada no puede ser eliminada porque ya se encuentra asignada!", "Eliminar Zona",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void botGuardar3_Click(object sender, EventArgs e)
        {
            if (txtDescripcion3.Text.Length > 0)
            {
                Entidades.Resultado resultado;
                string mensaje1;
                string mensaje2;
                if (tbId.Text == string.Empty)
                {
                    resultado = localidades3.guardarZona(txtDescripcion3.Text);
                    mensaje1 = "Guardar";
                    mensaje2 = "Guardada";
                }
                else
                {
                    resultado = localidades3.editarZona(txtId3.Text, txtDescripcion3.Text);
                    mensaje1 = "Editar";
                    mensaje2 = "Editada";
                }
                evaluarResultado3(resultado, mensaje1, mensaje2);
            }
            else
            {
                MessageBox.Show("El ingreso de la descripción es obligatorio",
                    "Ingresar descripción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void evaluarResultado3(Entidades.Resultado result, string mensaje1, string mensaje2)
        {
            if (result.Modo == 1)
            {
                modoConsulta3();
                limpiarFormulario3();
                llenarDgv3();
            }
            else
            {
                MessageBox.Show("¡Error al " + mensaje1 + " Zona!", mensaje1 + " Zona",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar5_Click(object sender, EventArgs e)
        {
            switch (tab.SelectedIndex)
            {
                case 1:
                    botAgregar4_Click(sender, e);
                    txtDescripcion4.Select();
                    break;
                case 2:
                    botAgregar2_Click(sender, e);
                    txtDescripcion2.Select();
                    break;
                //case 3:
                //    botAgregar_Click(sender, e);
                //    break;
                //case 4:
                //    botAgregar3_Click(sender, e);                    
                //    break;
                case 0:
                    //frmConfigTipoExamenExApt frm = new frmConfigTipoExamenExApt();                    
                    //frm.OcultarEditar();
                    //frm.ShowDialog();
                    botAgregar7_Click(sender, e);
                    tbDescripcion7.Select();
                    //txtDescripcion6.Select();
                    //llenarDgv6();
                    break;
            }

        }

        private void btnEditar5_Click(object sender, EventArgs e)
        {
            switch (tab.SelectedIndex)
            {
                case 1:
                    botEditar4_Click(sender, e);
                    txtDescripcion4.Select();
                    break;
                case 2:
                    botEditar2_Click(sender, e);
                    txtDescripcion2.Select();
                    break;
                //case 3:
                //    botEditar_Click(sender, e);
                //    break;
                //case 4:
                //    botEditar3_Click(sender, e);                    
                //    break;
                case 0:
                    //btnEditar6_Click(sender, e);
                    //txtDescripcion6.Select();
                    //EditarExamenActitud06();
                    //llenarDgv6();
                    if (cboTipoExamen.SelectedIndex == -1)
                    {
                        MsgBoxUtil.HackMessageBox("Editar", "Cancelar");
                        DialogResult resultExamen = MessageBox.Show("Va a editar el tipo de examen, desea continuar?", "Editar Tipo Examen",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (resultExamen == DialogResult.OK)
                        {
                            botEditar7_Click(sender, e);
                        }
                        else if (resultExamen == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else
                    {
                        botEditar7_Click(sender, e);
                    }
                    break;
            }
        }

        private void btnGuardar5_Click(object sender, EventArgs e)
        {
            switch (tab.SelectedIndex)
            {
                case 1:
                    botGuardar4_Click(sender, e);
                    break;
                case 2:
                    botGuardar2_Click(sender, e);
                    break;
                //case 3:
                //    botGuardar_Click(sender, e);
                //    break;
                //case 4:
                //    botGuardar3_Click(sender, e);                    
                //    break;
                case 0:
                    //btnGuardar6_Click(sender, e);
                    botGuardar7_Click(sender, e);
                    break;
            }
        }

        private void btnCancelar5_Click(object sender, EventArgs e)
        {
            switch (tab.SelectedIndex)
            {
                case 1:
                    botCancelar4_Click(sender, e);
                    break;
                case 2:
                    botCancelar2_Click(sender, e);
                    break;
                //case 3:
                //    botCancelar_Click(sender, e);
                //    break;
                //case 4:
                //    botCancelar3_Click(sender, e);                    
                //    break;
                case 0:
                    //btnCancelar6_Click(sender, e);
                    botCancelar7_Click(sender, e);
                    break;
            }
        }

        private void btnEliminar5_Click(object sender, EventArgs e)
        {
            switch (tab.SelectedIndex)
            {
                case 1:
                    botEliminar4_Click(sender, e);
                    break;
                case 2:
                    botEliminar2_Click(sender, e);
                    break;
                //case 3:
                //    botEliminar_Click(sender, e);
                //    break;
                //case 4:
                //    botEliminar3_Click(sender, e);                    
                //    break;
                case 0:
                    botEliminar7_Click(sender, e);
                    //llenarDgv6();
                    break;
            }
        }

        private void btnEditar6_Click(object sender, EventArgs e)
        {
            modoEdicion6();
        }

        private void btnGuardar6_Click(object sender, EventArgs e)
        {
            guardar6();
        }

        private void btnCancelar6_Click(object sender, EventArgs e)
        {
            modoConsulta6();
        }

        private void btnEliminar6_Click(object sender, EventArgs e)
        {
            eliminar6();
        }

        private void btnAgregar6_Click(object sender, EventArgs e)
        {
            modoNuevo6();
        }

        private void modoNuevo6()
        {
            if (cboTipoPrestacion6.SelectedIndex != -1)
            {
                limpiarFormulario6();
                panelEdicion6.Visible = true;
                //panelEdicion6.Enabled = true; //
                panelPrincipal6.Enabled = true;
                cboTipoPrestacionEditar6.SelectedIndex = cboTipoPrestacion6.SelectedIndex;
                aplicaZona6();
            }
            else
            {
                MessageBox.Show("Agregar Localidad/Prestación", "¡Seleccione el tipo de Prestación que desea agregar!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void guardar6()
        {
            if (txtDescripcion6.Text.Length > 0)
            {
                Entidades.Resultado resultado;
                string mensaje1;
                string mensaje2;
                if (txtId6.Text == string.Empty)
                {
                    resultado = localidPrest.guardarNueva(cargarDatosEntidad6());
                    mensaje1 = "Guardar";
                    mensaje2 = "Guardada";
                }
                else
                {
                    resultado = localidPrest.editar(cargarDatosEntidad6());
                    mensaje1 = "Editar";
                    mensaje2 = "Editada";
                }
                evaluarResultado6(resultado, mensaje1, mensaje2);
            }
            else
            {
                MessageBox.Show("El ingreso de la descripción es obligatorio",
                    "Ingresar descripción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Entidades.LocalidadPrestacion cargarDatosEntidad6()
        {
            Entidades.LocalidadPrestacion retorno = new LocalidadPrestacion();
            if (txtId6.Text != string.Empty) { retorno.Id = new Guid(txtId6.Text); }
            retorno.Tipo = obtenerItemSeleccionado4(cboTipoPrestacionEditar6);
            retorno.Descripcion = txtDescripcion6.Text;
            if (cboZona6.SelectedIndex > 0) { retorno.Zona = Convert.ToInt16(cboZona6.SelectedValue.ToString()); }
            return retorno;
        }

        private void modoConsulta6()
        {
            limpiarFormulario6();
            panelEdicion6.Visible = false;
            panelPrincipal6.Enabled = true;
        }

        private void limpiarFormulario6()
        {
            txtId6.Clear();
            txtCodigo6.Clear();
            txtDescripcion6.Clear();
            cboZona6.SelectedIndex = -1;
            cboTipoPrestacionEditar6.SelectedIndex = 4;
            //txtDescripcion6.Enabled = true;
        }

        private void evaluarResultado6(Entidades.Resultado result, string mensaje1, string mensaje2)
        {
            if (result.Modo == 1)
            {
                modoConsulta6();
                //llenarDgv6();
            }
            else
            {
                MessageBox.Show("¡Error al " + mensaje1 + " Localidad/Prestación!", mensaje1 + " Localidad/Prestación",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool aplicaZona6()
        {
            cboZona6.Visible = false;
            lblZona6.Visible = false;
            if (obtenerItemSeleccionado4(cboTipoPrestacion6) == "V")
            {
                cboZona6.Visible = true;
                lblZona6.Visible = true;
                return true;
            }
            return false;
        }

        private void modoEdicion6()
        {
            if (dgv4.SelectedRows.Count > 0)
            {
                txtId6.Text = dgv6.SelectedRows[0].Cells[0].Value.ToString();
                txtCodigo6.Text = dgv6.SelectedRows[0].Cells[1].Value.ToString();
                cboTipoPrestacionEditar6.SelectedIndex = cboTipoPrestacion6.SelectedIndex;
                txtDescripcion6.Text = dgv6.SelectedRows[0].Cells[3].Value.ToString();
                if (aplicaZona6())
                {
                    cboZona6.SelectedValue = dgv6.SelectedRows[0].Cells[4].Value.ToString();
                    if (dgv6.SelectedRows[0].Cells[4].Value.ToString() == string.Empty)
                    {
                        cboZona6.SelectedIndex = 0;
                    }
                }
                panelEdicion6.Visible = true;
                panelPrincipal6.Enabled = false;
            }
        }

        private void txtBusquedaPrestacion6_TextChanged(object sender, EventArgs e)
        {
            filtrarLocalidadesYPrestaciones6();
        }

        private void filtrarLocalidadesYPrestaciones6()
        {
            if (cboTipoPrestacion6.SelectedIndex != -1)
            {
                //dgv6.DataSource = localidPrest.cargarLocalidadesYPrestacionesFiltro(obtenerItemSeleccionado4(cboTipoPrestacion6), txtBusquedaPrestacion6.Text);
                dgv6.DataSource = localidPrest.cargarEspecialidad(txtBusquedaPrestacion6.Text);
                dgv6.Columns[0].Visible = false;
                dgv6.Columns[2].Visible = false;
                dgv6.Columns[4].Visible = false;
                dgv6.Columns[5].Visible = false;
                if (cboTipoPrestacion6.SelectedIndex == 1)
                {
                    dgv6.Columns[5].Visible = true;
                }
            }
        }

        private void cboTipoPrestacion6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPrestacion6.SelectedIndex != -1)
            {
                //llenarDgv6();
            }
        }

        private void eliminar6()
        {
            CapaNegocioMepryl.TipoExamen TipoExamen = new CapaNegocioMepryl.TipoExamen();


            if (dgv6.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Realmente desea eliminar el Exámen de Aptitud?",
                    "Eliminar Prestación/Localidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //eliminarLocalidadPrestacion6(dgv6.SelectedRows[0].Cells[0].Value.ToString(), dgv6.SelectedRows[0].Cells[2].Value.ToString());                   

                    string strIdEspecialidad = "";

                    try
                    {
                        int nroFila = dgv6.CurrentCell.RowIndex;
                        strIdEspecialidad = dgv6.Rows[nroFila].Cells[0].Value.ToString();
                        TipoExamen.EliminarEspecialidad(strIdEspecialidad);
                    }
                    catch (System.NullReferenceException ex)
                    {
                        strIdEspecialidad = dgv6.Rows[0].Cells[0].Value.ToString();
                        TipoExamen.EliminarEspecialidad(strIdEspecialidad);
                    }
                }
            }
        }

        private void eliminarLocalidadPrestacion6(string id, string tipo)
        {
            if (verificarEliminar6(id, tipo))
            {
                Entidades.Resultado result = localidPrest.eliminar(id);
                if (result.Modo == 1)
                {
                    MessageBox.Show("¡Localidad/Prestación eliminada correctamente!",
                        "Eliminar Localidad/Prestación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenarDgv6();
                }
                else
                {
                    MessageBox.Show("¡Error al eliminar Localidad/Prestación!",
                      "Eliminar Localidad/Prestación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar la Localidad/Prestación. ¡Se encuentra asignada a una consulta o paciente!", "Eliminar Localidad/Prestación",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool verificarEliminar6(string id, string tipo)
        {
            return localidPrest.verificarEliminar(id, tipo);
        }

        private void EditarExamenActitud06()
        {
            string strIdPadre = "";
            string strIdEspecialidad = "";

            try
            {
                int nroFila = dgv6.CurrentCell.RowIndex;

                strIdPadre = dgv6.Rows[nroFila].Cells[5].Value.ToString();
                strIdEspecialidad = dgv6.Rows[nroFila].Cells[0].Value.ToString();
            }
            catch (System.NullReferenceException ex)
            {
                strIdPadre = dgv6.Rows[0].Cells[5].Value.ToString();
                strIdEspecialidad = dgv6.Rows[0].Cells[0].Value.ToString();
            }

            frmConfigTipoExamenExApt frm = new frmConfigTipoExamenExApt();
            frm.CargarDatosEditar(strIdPadre, strIdEspecialidad, "EDITAR");
            frm.OcultarAgregar();
            frm.ShowDialog();
        }

        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ✅ VERIFICAR CUÁL PESTAÑA ESTÁ SELECCIONADA
            string tabSeleccionado = tab.SelectedTab?.Text ?? "";

            // Mostrar/ocultar botones según la pestaña
            if (tabSeleccionado == "Agregar Tipos y Subtipos")
            {
                btnGuardar5.Visible = false;
                btnCancelar5.Visible = false;
                btnAgregar5.Visible = false;
                btnEditar5.Visible = false;

                abrirFrmAgregarEspecialidades();

                // Solo sincronizar si hay selección válida de motivo
                if (frmAgregarEspecialidadInstance != null && !frmAgregarEspecialidadInstance.IsDisposed)
                {
                    int idMotivo = 0;
                    string idTipo = "";
                    string idSubtipo = "";

                    if (frmGestionarEspecialidadInstance != null && !frmGestionarEspecialidadInstance.IsDisposed)
                    {
                        idMotivo = frmGestionarEspecialidadInstance.ObtenerIdMotivoConsultaSeleccionado;
                        idTipo = frmGestionarEspecialidadInstance.ObtenerIdTipoExamenSeleccionado;
                        idSubtipo = frmGestionarEspecialidadInstance.ObtenerIdSubtipoActualmenteCargado;
                    }

                    if (idMotivo == 0)
                    {
                        idMotivo = cboMotivoConsulta.SelectedIndex > -1 ? Convert.ToInt32(cboMotivoConsulta.SelectedValue ?? 0) : 0;
                        idTipo = cboSubTipo.SelectedValue?.ToString() ?? "";
                        idSubtipo = cboTipoExamen.SelectedValue?.ToString() ?? "";
                    }

                    // Solo sincronizar si el usuario ya seleccionó un motivo
                    if (idMotivo > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"[SYNC][NAV] Sincronizando a Agregar: Motivo={idMotivo}, Tipo={idTipo}, Subtipo={idSubtipo}");
                        frmAgregarEspecialidadInstance.SincronizarCombosDesde(idMotivo, idTipo, idSubtipo);
                    }
                }

                if (frmGestionarEspecialidadInstance != null)
                {
                    frmGestionarEspecialidadInstance.OcultarTabItemsSecciones();
                }
            }
            else if (tabSeleccionado == "Gestionar")
            {
                btnGuardar5.Visible = false;
                btnCancelar5.Visible = false;
                btnAgregar5.Visible = false;
                btnEditar5.Visible = false;
                BtnGrabar.Visible = false;

                abrirFrmGestionarEspecialidades();

                // Sincronizar si hay motivo seleccionado (aunque tipo y subtipo estén vacíos)
                if (frmGestionarEspecialidadInstance != null && !frmGestionarEspecialidadInstance.IsDisposed)
                {
                    int idMotivo = 0;
                    string idTipo = "";
                    string idSubtipo = "";

                    if (frmAgregarEspecialidadInstance != null && !frmAgregarEspecialidadInstance.IsDisposed)
                    {
                        idMotivo = frmAgregarEspecialidadInstance.ObtenerIdMotivoConsultaSeleccionado;
                        idTipo = frmAgregarEspecialidadInstance.ObtenerIdTipoExamenSeleccionado;
                        idSubtipo = frmAgregarEspecialidadInstance.ObtenerIdSubtipoActualmenteCargado;
                    }

                    if (idMotivo == 0)
                    {
                        idMotivo = cboMotivoConsulta.SelectedIndex > -1 ? Convert.ToInt32(cboMotivoConsulta.SelectedValue ?? 0) : 0;
                        idTipo = cboSubTipo.SelectedValue?.ToString() ?? "";
                        idSubtipo = cboTipoExamen.SelectedValue?.ToString() ?? "";
                    }

                    // Sincronizar si el usuario ya seleccionó motivo (aunque tipo y subtipo estén vacíos)
                    if (idMotivo > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"[SYNC][NAV] Sincronizando a Gestionar: Motivo={idMotivo}, Tipo={idTipo}, Subtipo={idSubtipo}");
                        frmGestionarEspecialidadInstance.SincronizarCombosDesde(idMotivo, idTipo, idSubtipo);
                    }
                }
            }
            else if (tabSeleccionado == "Tipo de Examen Médico")
            {
                btnGuardar5.Visible = false;
                btnCancelar5.Visible = false;
                btnAgregar5.Visible = false;
                btnEditar5.Visible = true;
                BtnGrabar.Visible = false;

                // OBTENER DATOS ANTES DE LIMPIAR
                int idMotivo = 0;
                string idTipo = "";
                string idSubtipo = "";

                if (frmGestionarEspecialidadInstance != null && !frmGestionarEspecialidadInstance.IsDisposed)
                {
                    idMotivo = frmGestionarEspecialidadInstance.ObtenerIdMotivoConsultaSeleccionado;
                    idTipo = frmGestionarEspecialidadInstance.ObtenerIdTipoExamenSeleccionado;
                    idSubtipo = frmGestionarEspecialidadInstance.ObtenerIdSubtipoActualmenteCargado;
                }

                if (idMotivo == 0 && frmAgregarEspecialidadInstance != null && !frmAgregarEspecialidadInstance.IsDisposed)
                {
                    idMotivo = frmAgregarEspecialidadInstance.ObtenerIdMotivoConsultaSeleccionado;
                    idTipo = frmAgregarEspecialidadInstance.ObtenerIdTipoExamenSeleccionado;
                    idSubtipo = frmAgregarEspecialidadInstance.ObtenerIdSubtipoActualmenteCargado;
                }

                // DESPUÉS obtener datos, limpiar
                limpiarFrmAgregarEspecialidades();

                // Si el motivo es 'TODOS', forzar limpieza total
                if (idMotivo == 0)
                {
                    RefrescarTabTipoExamenMedico(0, "", "");
                }
                else
                {
                    RefrescarTabTipoExamenMedico(idMotivo, idTipo, idSubtipo);
                }

                if (frmGestionarEspecialidadInstance != null)
                {
                    frmGestionarEspecialidadInstance.MostrarTabItemsSecciones();
                }
            }
            else
            {
                btnGuardar5.Visible = false;
                btnCancelar5.Visible = false;
                btnAgregar5.Visible = false;
                btnEditar5.Visible = false;
                BtnGrabar.Visible = false;
            }
        }

        // ✅ VARIABLE GLOBAL: Instancia de FrmAñadirEspecialidad
        private FrmAñadirEspecialidad frmAgregarEspecialidadInstance = null;
        private FrmAñadirEspecialidad frmGestionarEspecialidadInstance = null;
        // Suscribirse al evento CombosChanged y ocultar el botón al inicio
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Ocultar el botón al inicio (asumiendo que está en el diseñador)
            if (btnguardarsubtipos != null)
                btnguardarsubtipos.Visible = false;

            // Suscribirse al evento CombosChanged de ambas instancias si existen
            if (frmAgregarEspecialidadInstance != null)
                frmAgregarEspecialidadInstance.CombosChanged += FrmEspecialidad_CombosChanged;
            if (frmGestionarEspecialidadInstance != null)
                frmGestionarEspecialidadInstance.CombosChanged += FrmEspecialidad_CombosChanged;
        }

        // Handler para actualizar la visibilidad del botón según los subtipos pendientes
        private void FrmEspecialidad_CombosChanged(object sender, EventArgs e)
        {
            var frm = sender as FrmAñadirEspecialidad;
            if (frm == null || btnguardarsubtipos == null)
                return;
            // Se asume que subtiposPendientesCambio es público o hay un método para obtener la cantidad
            var prop = frm.GetType().GetField("subtiposPendientesCambio", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (prop != null)
            {
                var lista = prop.GetValue(frm) as System.Collections.ICollection;
                bool hayPendientes = lista != null && lista.Count > 0;
                btnguardarsubtipos.Visible = hayPendientes;
            }
        }

        // ✅ BANDERA: Evitar sincronización recursiva/infinita
        private bool sincronizandoDesdeAgregar = false;

        // ✅ NUEVO MÉTODO: Incrusta FrmAñadirEspecialidad dentro del tab para AGREGAR
        private void abrirFrmAgregarEspecialidades()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] Entrando a abrirFrmAgregarEspecialidades");
                // Si ya existe una instancia, no crear otra
                if (frmAgregarEspecialidadInstance != null && !frmAgregarEspecialidadInstance.IsDisposed)
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG] Ya existe instancia de FrmAñadirEspecialidad. Recargando datos y retornando.");
                    frmAgregarEspecialidadInstance.RecargarDatos();
                    return;
                }

                // ✅ CREAR INSTANCIA COMO FORMULARIO HIJO (NO MODAL)
                System.Diagnostics.Debug.WriteLine("[DEBUG] Creando nueva instancia de FrmAñadirEspecialidad");
                frmAgregarEspecialidadInstance = new FrmAñadirEspecialidad();
                // Suscribirse al evento CombosChanged para mostrar/ocultar el botón guardar subtipos
                frmAgregarEspecialidadInstance.CombosChanged += FrmEspecialidad_CombosChanged;

                // ✅ OCULTAR TABS INNECESARIOS (mantener \"Items por Secciones\" VISIBLE)
                System.Diagnostics.Debug.WriteLine("[DEBUG] Ocultando tab Gestionar en FrmAñadirEspecialidad");
                frmAgregarEspecialidadInstance.OcultarTabGestionar();      // Ocultar "Gestionar"
                // ✅ VISIBLE: "Agregar Tipos y Subtipos" + "Items por Secciones"

                // ✅ CONFIGURAR PARA INCRUSTAR EN TAB
                System.Diagnostics.Debug.WriteLine("[DEBUG] Configurando propiedades visuales de FrmAñadirEspecialidad para incrustar en tab");
                frmAgregarEspecialidadInstance.TopLevel = false;          // No es ventana independiente
                frmAgregarEspecialidadInstance.FormBorderStyle = FormBorderStyle.None;  // Sin bordes
                frmAgregarEspecialidadInstance.Dock = DockStyle.Fill;     // Llenar el contenedor
                frmAgregarEspecialidadInstance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; // Adaptar a tamaño
                frmAgregarEspecialidadInstance.AutoScroll = true;         // Scroll si es necesario

                // ✅ AGREGAR AL TAB ACTUAL - SOLO AGREGAR LA INSTANCIA, NO LIMPIAR TODO
                if (tab.SelectedTab != null)
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG] Agregando FrmAñadirEspecialidad al tab seleccionado");
                    tab.SelectedTab.Controls.Add(frmAgregarEspecialidadInstance);
                }

                // ✅ MOSTRAR EL FORMULARIO INCRUSTADO
                System.Diagnostics.Debug.WriteLine("[DEBUG] Mostrando FrmAñadirEspecialidad incrustado");
                frmAgregarEspecialidadInstance.Show();

                // Sincronizar selección desde "Gestionar" si existe
                if (frmGestionarEspecialidadInstance != null && !frmGestionarEspecialidadInstance.IsDisposed)
                {
                    int idMotivo = frmGestionarEspecialidadInstance.ObtenerIdMotivoConsultaSeleccionado;
                    string idTipo = frmGestionarEspecialidadInstance.ObtenerIdTipoExamenSeleccionado;
                    string idSubtipo = frmGestionarEspecialidadInstance.ObtenerIdSubtipoActualmenteCargado;
                    System.Diagnostics.Debug.WriteLine($"[SYNC][NAV] Sincronizando a Agregar (al crear): Motivo={idMotivo}, Tipo={idTipo}, Subtipo={idSubtipo}");
                    frmAgregarEspecialidadInstance.SincronizarCombosDesde(idMotivo, idTipo, idSubtipo);
                }

                // ✅ SUSCRIBIRSE AL EVENTO: Cuando se crea un subtipo, mostrar botón Grabar y navegar a tabItemsSecciones en FrmAñadirEspecialidad
                frmAgregarEspecialidadInstance.SubtipoCreado += (s, e) =>
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG] Evento SubtipoCreado disparado en FrmAñadirEspecialidad");
                    BtnGrabar.Visible = true;
                    BtnGrabar.BackColor = SystemColors.Control;

                    // Buscar y navegar a tabItemsSecciones en FrmAñadirEspecialidad
                    var tabControls = frmAgregarEspecialidadInstance.Controls.OfType<System.Windows.Forms.TabControl>();
                    foreach (var tabCtrl in tabControls)
                    {
                        foreach (System.Windows.Forms.TabPage tab in tabCtrl.TabPages)
                        {
                            if (tab.Name == "tabItemsSecciones")
                            {
                                System.Diagnostics.Debug.WriteLine("[DEBUG] Navegando a tabItemsSecciones en FrmAñadirEspecialidad");
                                tabCtrl.SelectedTab = tab;
                                return;
                            }
                        }
                    }
                };

                // ✅ NUEVO: Recargar datos después de mostrar
                System.Diagnostics.Debug.WriteLine("[DEBUG] Recargando datos en FrmAñadirEspecialidad");
                frmAgregarEspecialidadInstance.RecargarDatos();
                System.Diagnostics.Debug.WriteLine("[DEBUG] Fin de abrirFrmAgregarEspecialidades");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ERROR] Error al cargar en abrirFrmAgregarEspecialidades: {ex.Message}");
                MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ NUEVO MÉTODO: Incrusta FrmAñadirEspecialidad dentro del tab para GESTIONAR
        private void abrirFrmGestionarEspecialidades()
        {
            try
            {
                // Si ya existe una instancia, no crear otra
                if (frmGestionarEspecialidadInstance != null && !frmGestionarEspecialidadInstance.IsDisposed)
                {
                    frmGestionarEspecialidadInstance.RecargarDatos();
                    return;
                }

                // ✅ CREAR INSTANCIA COMO FORMULARIO HIJO (NO MODAL)
                frmGestionarEspecialidadInstance = new FrmAñadirEspecialidad();
                // Suscribirse al evento CombosChanged para mostrar/ocultar el botón guardar subtipos
                frmGestionarEspecialidadInstance.CombosChanged += FrmEspecialidad_CombosChanged;

                // ✅ OCULTAR TODOS LOS TABS EXCEPTO GESTIONAR
                frmGestionarEspecialidadInstance.OcultarTabAgregar();         // Ocultar "Agregar Tipos y Subtipos"
                frmGestionarEspecialidadInstance.OcultarTabItemsSecciones(); // Ocultar "Items por Secciones"
                // ✅ TabGestionar permanece VISIBLE - SOLO ESTE

                // ✅ CONFIGURAR PARA INCRUSTAR EN TAB
                frmGestionarEspecialidadInstance.TopLevel = false;          // No es ventana independiente
                frmGestionarEspecialidadInstance.FormBorderStyle = FormBorderStyle.None;  // Sin bordes
                frmGestionarEspecialidadInstance.Dock = DockStyle.Fill;     // Llenar el contenedor
                frmGestionarEspecialidadInstance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; // Adaptar a tamaño
                frmGestionarEspecialidadInstance.AutoScroll = true;         // Scroll si es necesario

                // ✅ AGREGAR AL TAB ACTUAL - SOLO AGREGAR LA INSTANCIA, NO LIMPIAR TODO
                if (tab.SelectedTab != null)
                {
                    tab.SelectedTab.Controls.Clear();  // Limpiar controles previos
                    tab.SelectedTab.Controls.Add(frmGestionarEspecialidadInstance);
                }

                // ✅ MOSTRAR EL FORMULARIO INCRUSTADO
                frmGestionarEspecialidadInstance.Show();
                frmGestionarEspecialidadInstance.BringToFront();

                // Sincronizar selección desde "Agregar" si existe
                if (frmAgregarEspecialidadInstance != null && !frmAgregarEspecialidadInstance.IsDisposed)
                {
                    int idMotivo = frmAgregarEspecialidadInstance.ObtenerIdMotivoConsultaSeleccionado;
                    string idTipo = frmAgregarEspecialidadInstance.ObtenerIdTipoExamenSeleccionado;
                    string idSubtipo = frmAgregarEspecialidadInstance.ObtenerIdSubtipoActualmenteCargado;
                    System.Diagnostics.Debug.WriteLine($"[SYNC][NAV] Sincronizando a Gestionar (al crear): Motivo={idMotivo}, Tipo={idTipo}, Subtipo={idSubtipo}");
                    frmGestionarEspecialidadInstance.SincronizarCombosDesde(idMotivo, idTipo, idSubtipo);
                }

                // ✅ SUSCRIBIRSE AL EVENTO: Cuando se crea un subtipo, mostrar botón Grabar
                frmGestionarEspecialidadInstance.SubtipoCreado += (s, e) =>
                {
                    BtnGrabar.Visible = true;
                    BtnGrabar.BackColor = System.Drawing.Color.Green;
                };

                // ✅ NUEVO: Recargar datos después de mostrar
                frmGestionarEspecialidadInstance.RecargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ NUEVO MÉTODO: Limpiar instancia cuando se sale del tab
        public void RefrescarTabTipoExamenMedico(int idMotivoSincronizar = 0, string idTipoSincronizar = "", string idSubtipoSincronizar = "")
        {
            try
            {
                // 1️⃣ PASO 1: RECARGAR COMBO MOTIVO
                DataTable dtMotivos = tipoExamen.cargarMotivosDeConsultaTipoExamen();

                if (dtMotivos == null || dtMotivos.Rows.Count == 0)
                {
                    limpiarPanelPrincipal();
                    return;
                }

                cboMotivoConsulta.DataSource = dtMotivos;
                cboMotivoConsulta.ValueMember = "id";
                cboMotivoConsulta.DisplayMember = "nombre";
                cboMotivoConsulta.SelectedIndex = -1;

                // Si hay motivo a sincronizar, usarlo; si no, dejar sin selección
                if (idMotivoSincronizar > 0)
                {
                    cboMotivoConsulta.SelectedValue = idMotivoSincronizar;
                }
                else
                {
                    cboMotivoConsulta.SelectedIndex = -1;
                    cboSubTipo.DataSource = null;
                    cboTipoExamen.DataSource = null;
                    limpiarPanelPrincipal();
                    return;
                }

                // 2️⃣ PASO 2: CARGAR NIVEL 1 (TIPOS) - INCLUIR TEMPORALES
                string idMotivo = cboMotivoConsulta.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(idMotivo))
                {
                    limpiarPanelPrincipal();
                    return;
                }

                DataTable dtNivel1 = tipoExamen.cargarTiposDeExamenPadreConSubtiposActivos(idMotivo);

                // ✅ AGREGAR TIPOS TEMPORALES (PADRES) DE LA LISTA
                if (frmAgregarEspecialidadInstance != null && !frmAgregarEspecialidadInstance.IsDisposed)
                {
                    var listaTemp = frmAgregarEspecialidadInstance.ObtenerListaTiposExamenes;
                    if (listaTemp != null)
                    {
                        var tiposTemporales = listaTemp.Where(t => t.Padre && t.IdMotivoConsulta.ToString() == idMotivo).ToList();
                        foreach (var tipo in tiposTemporales)
                        {
                            DataRow newRow = dtNivel1.NewRow();
                            newRow["id"] = tipo.Id.ToString();
                            newRow["descripcion"] = tipo.Descripcion + " (NUEVO)";
                            newRow["idPadre"] = tipo.IdPadre ?? "";
                            dtNivel1.Rows.Add(newRow);
                        }
                    }
                }

                if (dtNivel1 == null || dtNivel1.Rows.Count == 0)
                {
                    cboSubTipo.DataSource = null;
                    cboTipoExamen.DataSource = null;
                    limpiarPanelPrincipal();
                    return;
                }

                cboSubTipo.DataSource = dtNivel1;
                cboSubTipo.ValueMember = "id";
                cboSubTipo.DisplayMember = "descripcion";

                // Si hay tipo a sincronizar, usarlo; si no, dejar sin selección
                if (!string.IsNullOrEmpty(idTipoSincronizar))
                {
                    cboSubTipo.SelectedValue = idTipoSincronizar;
                }
                else
                {
                    cboSubTipo.SelectedIndex = -1;
                    cboTipoExamen.DataSource = null;
                    // No limpiar panel principal aquí, permitir selección parcial
                    return;
                }

                // 3️⃣ PASO 3: CARGAR NIVEL 2 (SUBTIPOS) - INCLUIR TEMPORALES
                string idTipo = cboSubTipo.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(idTipo))
                {
                    cboTipoExamen.DataSource = null;
                    // No limpiar panel principal aquí, permitir selección parcial
                    return;
                }

                DataTable dtNivel2 = tipoExamen.cargarNivel2EspecialidadActivos(idTipo);


                // ✅ AGREGAR SUBTIPOS TEMPORALES (NO PADRES) DE LA LISTA
                if (frmAgregarEspecialidadInstance != null && !frmAgregarEspecialidadInstance.IsDisposed)
                {
                    var listaTemp = frmAgregarEspecialidadInstance.ObtenerListaTiposExamenes;
                    if (listaTemp != null)
                    {
                        var subtiposTemporales = listaTemp.Where(t => !t.Padre && t.IdPadre == idTipo).ToList();
                        foreach (var subtipo in subtiposTemporales)
                        {
                            DataRow newRow = dtNivel2.NewRow();
                            newRow["id"] = subtipo.Id.ToString();
                            newRow["descripcion"] = subtipo.Descripcion + " (NUEVO)";
                            newRow["idPadre"] = subtipo.IdPadre ?? "";
                            dtNivel2.Rows.Add(newRow);
                        }
                    }
                }

                if (dtNivel2 == null || dtNivel2.Rows.Count == 0)
                {
                    cboTipoExamen.DataSource = null;
                    // No limpiar panel principal aquí, permitir selección parcial
                    return;
                }

                cboTipoExamen.DataSource = dtNivel2;
                cboTipoExamen.ValueMember = "id";
                cboTipoExamen.DisplayMember = "descripcion";

                // Si hay subtipo a sincronizar, usarlo; si no, dejar sin selección
                if (!string.IsNullOrEmpty(idSubtipoSincronizar))
                {
                    cboTipoExamen.SelectedValue = idSubtipoSincronizar;
                }
                else
                {
                    cboTipoExamen.SelectedIndex = -1;
                    // No limpiar panel principal aquí, permitir selección parcial
                    return;
                }

                // 4️⃣ PASO 4: CARGAR DATOS EN LOS CONTROLES
                string idSubtipo = cboTipoExamen.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(idSubtipo))
                {
                    // No limpiar panel principal aquí, permitir selección parcial
                    return;
                }

                try
                {
                    Entidades.TipoExamen entidad = tipoExamen.cargarEntidad(idSubtipo);

                    if (entidad == null)
                    {
                        limpiarPanelPrincipal();
                        return;
                    }

                    // ✅ LLENAR TEXTBOXES
                    tbId7.Text = entidad.Id.ToString();
                    tbCodigo7.Text = entidad.Codigo.ToString();
                    tbDescripcion7.Text = entidad.Descripcion ?? "";
                    tbDescripcionInformes.Text = entidad.DescripcionInformes ?? "";

                    if (entidad.PrecioBase != 0)
                        tbPrecioBase.Text = entidad.PrecioBase.ToString();
                    else
                        tbPrecioBase.Text = "";

                    // ✅ LLENAR DATAGRIDS SIEMPRE
                    llenarDataGrids(entidad);

                    // ✅ ACTUALIZAR RESUMEN
                    actualizarResumen();

                    // ✅ HABILITAR BOTONES
                    btnEditar5.Enabled = true;
                    btnEliminar5.Enabled = true;
                    tabControl.Enabled = true;
                }
                catch (Exception ex)
                {
                    limpiarPanelPrincipal();
                }
            }
            catch (Exception ex)
            {
                limpiarPanelPrincipal();
            }
        }

        private void limpiarFrmAgregarEspecialidades()
        {
            try
            {
                if (frmAgregarEspecialidadInstance != null && !frmAgregarEspecialidadInstance.IsDisposed)
                {
                    // SOLO ELIMINAR LA INSTANCIA, NO LIMPIAR TODOS LOS CONTROLES DEL TAB
                    frmAgregarEspecialidadInstance.Dispose();
                    frmAgregarEspecialidadInstance = null;
                }

                // TAMBIÉN LIMPIAR INSTANCIA DE GESTIÓN
                if (frmGestionarEspecialidadInstance != null && !frmGestionarEspecialidadInstance.IsDisposed)
                {
                    frmGestionarEspecialidadInstance.Dispose();
                    frmGestionarEspecialidadInstance = null;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgv6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditarExamenActitud06();
                llenarDgv6();
            }
        }

        //
        // ******************************************************
        //

        private CapaNegocioMepryl.TipoExamen tipoExamen;
        private string strEstadoEdicion = "";
        private bool blnEstadoTipoExamen = false;
        private bool blnEstadoGuardo = false;
        private string strIdEspecialidadViejo = "";
        private string strDescripcionViejo = "";
        private bool blnItemsModificados = false;  // Flag para trackear cambios en items

        private void inicializar7()
        {
            tipoExamen = new CapaNegocioMepryl.TipoExamen();

            // ✅ CARGAR COMBO AL INICIAR (ANTES DE modoMenu)
            try
            {
                cargarComboMotivoConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar Motivos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            modoMenu();
        }

        /// <summary>
        /// ✅ MÉTODO PÚBLICO: Carga un subtipo específico en el tab "Tipo de Examen Médico"
        /// Se llama desde FrmAñadirEspecialidad cuando se crea un subtipo nuevo
        /// </summary>
        public void CargarSubtipoEnTab(int idMotivo, string idTipo, string idSubtipo)
        {
            try
            {
                // Navegar al tab "Tipo de Examen Médico"
                if (tab.SelectedTab == null || tab.SelectedTab.Text != "Tipo de Examen Médico")
                {
                    foreach (System.Windows.Forms.TabPage tabPage in tab.TabPages)
                    {
                        if (tabPage.Text == "Tipo de Examen Médico")
                        {
                            tab.SelectedTab = tabPage;
                            break;
                        }
                    }
                }

                // Usar BeginInvoke para permitir que se cargue el UI thread
                this.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        // Cargar combo: Motivo de Consulta
                        cargarComboMotivoConsulta();
                        if (cboMotivoConsulta.Items.Count > 0)
                        {
                            for (int i = 0; i < cboMotivoConsulta.Items.Count; i++)
                            {
                                if (cboMotivoConsulta.GetItemText(cboMotivoConsulta.Items[i]).Contains(idMotivo.ToString()) ||
                                    (cboMotivoConsulta.Items[i] is DataRowView drv && drv["IdMotivoConsulta"]?.ToString() == idMotivo.ToString()))
                                {
                                    cboMotivoConsulta.SelectedIndex = i;
                                    break;
                                }
                            }
                        }

                        // Cargar nivel 2 (Tipos)
                        Application.DoEvents();
                        cargarComboNivel2();
                        if (cboSubTipo.Items.Count > 0)
                        {
                            for (int i = 0; i < cboSubTipo.Items.Count; i++)
                            {
                                if (cboSubTipo.GetItemText(cboSubTipo.Items[i]).Contains(idTipo) ||
                                    (cboSubTipo.Items[i] is DataRowView drv && drv["Id"]?.ToString() == idTipo))
                                {
                                    cboSubTipo.SelectedIndex = i;
                                    break;
                                }
                            }
                        }

                        // Cargar nivel 3 (Subtipos)
                        Application.DoEvents();
                        cargarComboNivel3();
                        if (cboTipoExamen.Items.Count > 0)
                        {
                            for (int i = 0; i < cboTipoExamen.Items.Count; i++)
                            {
                                if (cboTipoExamen.GetItemText(cboTipoExamen.Items[i]).Contains(idSubtipo) ||
                                    (cboTipoExamen.Items[i] is DataRowView drv && drv["Id"]?.ToString() == idSubtipo))
                                {
                                    cboTipoExamen.SelectedIndex = i;
                                    break;
                                }
                            }
                        }

                        // Cargar datos del formulario
                        Application.DoEvents();
                        if (cboTipoExamen.SelectedIndex != -1)
                        {
                            cboTipoExamen_SelectionChangeCommitted(cboTipoExamen, EventArgs.Empty);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar el subtipo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el subtipo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// MÉTODOS NORMALIZADOS - Jerarquía de 3 Niveles
        /// Nivel 1: Categorías (Padre=1, IdPadre=NULL)
        /// Nivel 2: Subcategorías (Padre=1, IdPadre=<Nivel1>)
        /// Nivel 3: Exámenes Finales (Padre=0, IdPadre=<Nivel2>)
        /// </summary>

        private void cargarComboNivel1()
        {
            if (cboMotivoConsulta.SelectedIndex != -1)
            {
                // Usa el método que filtra por subtipos activos
                DataTable dt = tipoExamen.cargarTiposDeExamenPadreConSubtiposActivos(cboMotivoConsulta.SelectedValue.ToString());
                cboSubTipo.DataSource = dt;
                cboSubTipo.ValueMember = "id";
                cboSubTipo.DisplayMember = "descripcion";
                cboSubTipo.SelectedIndex = -1;
            }
        }
        private void cargarComboNivel2()
        {
            if (cboSubTipo.SelectedIndex != -1)  // Nivel 1 seleccionado
            {
                // Nota: Reutilizamos cboTipoExamen como Nivel 2 (intermedio)
                DataTable dt = tipoExamen.cargarNivel2EspecialidadActivos(cboSubTipo.SelectedValue.ToString());
                cboTipoExamen.DataSource = dt;
                cboTipoExamen.ValueMember = "id";
                cboTipoExamen.DisplayMember = "descripcion";
                cboTipoExamen.SelectedIndex = -1;
            }
        }

        private void cargarComboNivel3()
        {
            // Nivel 3 se carga directamente en cboTipoExamen (reutilizado)
            // Este método mantiene el nombre original cargarComboTipoExamen() para compatibilidad
            if (cboMotivoConsulta.SelectedIndex != -1 && cboTipoExamen.SelectedIndex != -1)
            {
                // En modo CREATE: usar Nivel 2
                // En modo EDITAR: usar solo Motivo
                DataTable dt = null;

                if (strEstadoEdicion != "EDITAR")
                {
                    // Búsqueda por Nivel 2 (idPadre)
                    dt = tipoExamen.cargarNivel3Especialidad(cboTipoExamen.SelectedValue.ToString());
                }
                else
                {
                    // En edición, cargar todos los hijos del motivo
                    dt = tipoExamen.cargarTiposDeExamenHijo(cboMotivoConsulta.SelectedValue.ToString());
                }

                // Aquí NO cambiamos el DataSource de cboTipoExamen, 
                // porque YA CONTIENE los Nivel 2
                // En su lugar, cargamos el formulario directamente
            }
        }

        private void cargarComboTipoExamen()
        {
            // MÉTODO ANTIGUO - MANTENIDO PARA COMPATIBILIDAD
            // Ahora solo carga Nivel 2 (subcategorías)
            if (cboMotivoConsulta.SelectedIndex != -1)
            {
                if (strEstadoEdicion != "EDITAR")
                {
                    // En CREATE: Nivel 2 filtrado por Nivel 1
                    if (cboSubTipo.SelectedIndex != -1)
                    {
                        cargarComboNivel2();
                    }
                }
                else
                {
                    // En EDITAR: Carga todos los Nivel 2 del Motivo
                    DataTable dt = tipoExamen.cargarTiposDeExamenPadre(cboMotivoConsulta.SelectedValue.ToString());
                    cboTipoExamen.DataSource = dt;
                    cboTipoExamen.ValueMember = "id";
                    cboTipoExamen.DisplayMember = "descripcion";
                    cboTipoExamen.SelectedIndex = -1;
                }
            }
        }

        private void llenarFormulario()
        {
            limpiarPanelPrincipal();
            // Cargar formulario con Nivel 2 (cboTipoExamen)
            if (cboTipoExamen.SelectedIndex != -1)
            {
                Entidades.TipoExamen entidad = tipoExamen.cargarEntidad(cboTipoExamen.SelectedValue.ToString());
                tbId7.Text = entidad.Id.ToString();
                tbCodigo7.Text = entidad.Codigo.ToString();
                tbDescripcion7.Text = entidad.Descripcion;
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
                tbId7.Text = entidad.Id.ToString();
                tbCodigo7.Text = entidad.Codigo.ToString();
                tbDescripcion7.Text = entidad.Descripcion;
                tbDescripcionInformes.Text = entidad.DescripcionInformes;
                if (entidad.PrecioBase != 0)
                {
                    tbPrecioBase.Text = entidad.PrecioBase.ToString();
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
            // Limpiar los DataGridView antes de asignar el nuevo DataSource
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
            AjustarScrollDgvClinico();
        }

        private void llenarDataGridsInicio(Entidades.TipoExamen entidad)
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
            btnEditar5.Enabled = false;
            btnEliminar5.Enabled = false;
            limpiarPanelPrincipal();

            if (cboTipoExamen.SelectedIndex != -1)  // Nivel 2 (Subtipo) seleccionado
            {
                try
                {
                    string idSubtipo = cboTipoExamen.SelectedValue.ToString();

                    // Cargar la entidad (especialidad) del Subtipo seleccionado
                    Entidades.TipoExamen entidad = tipoExamen.cargarEntidad(idSubtipo);

                    // Validar que la entidad tiene datos
                    if (entidad == null || string.IsNullOrEmpty(entidad.Descripcion))
                    {
                        MessageBox.Show("No se pudieron cargar los datos del subtipo seleccionado",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    tabControl.Enabled = true;
                    btnEditar5.Enabled = true;
                    btnEliminar5.Enabled = true;

                    tbId7.Text = entidad.Id.ToString();
                    tbCodigo7.Text = entidad.Codigo.ToString();
                    tbDescripcion7.Text = entidad.Descripcion;
                    tbDescripcionInformes.Text = entidad.DescripcionInformes;
                    if (entidad.PrecioBase != 0) { tbPrecioBase.Text = entidad.PrecioBase.ToString(); }

                    llenarDataGrids(entidad);
                    actualizarResumen();

                    strIdEspecialidadViejo = cboTipoExamen.SelectedValue.ToString();

                    // Habilitar controles y scroll automáticamente al seleccionar los 3 combos
                    cambiarHabilitacionControles(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiarPanelPrincipal();
                }
            }
        }

        private void limpiarPanelPrincipal()
        {
            tbId7.Clear();
            tbCodigo7.Clear();
            tbDescripcion7.Clear();
            tbDescripcionInformes.Clear();
            tbPrecioBase.Clear();
            tbResumenClinico.Clear();
            tbResumenLaboratorio.Clear();
            tbResumenRx.Clear();
            tbResumenEstCompl.Clear();

            // ❌ ELIMINADAS: Limpiar DataGridViews es muy costoso
            // Se limpiarán solo si es necesario en llenarDataGrids()
        }

        private void limpiarPanelParcial()
        {
            tbId7.Clear();
            tbCodigo7.Clear();
            tbDescripcion7.Clear();
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

        private void botEditar7_Click(object sender, EventArgs e)
        {
            // Debug: Recorrer los elementos del combo cboSubTipo
            for (int i = 0; i < cboTipoExamen.Items.Count; i++)
            {
                var item = cboTipoExamen.Items[i];
                System.Diagnostics.Debug.WriteLine($"[DEBUG][botEditar7_Click] Index: {i}, Value: {cboTipoExamen.GetItemText(item)}");
            }

            if (cboTipoExamen.SelectedIndex != -1)
            {
                modoEdicion7();
            }
            else
            {
                MessageBox.Show("¡Falta seleccionar el tipo de examen que se quiere editar!", "Ingresar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void botEditarPadre_Click(object sender, EventArgs e)
        {
            if (cboSubTipo.SelectedIndex != -1)
            {
                modoEdicion7();
            }
            else
            {
                MessageBox.Show("¡Falta seleccionar el tipo de examen que se quiere editar!", "Ingresar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void modoEdicionPadre()
        {
            panelMenu.Enabled = false;
            btnGuardar5.Visible = true;
            btnCancelar5.Visible = true;
            tabControl.TabIndex = 0;
            cambiarHabilitacionControles(true);
            tbDescripcion7.Text = cboSubTipo.Text.ToString();

            //
            btnAgregar5.Visible = false;
            btnEditar5.Visible = false;
            btnEliminar5.Visible = false;
        }

        private void modoEdicion7()
        {
            panelMenu.Enabled = false;
            btnGuardar5.Visible = true;
            btnCancelar5.Visible = true;
            tabControl.TabIndex = 0;
            cambiarHabilitacionControles(true);

            //
            btnAgregar5.Visible = false;
            btnEditar5.Visible = false;
            btnEliminar5.Visible = false;
        }

        private void modoMenu()
        {
            panelMenu.Enabled = true;
            btnGuardar5.Visible = false;
            btnCancelar5.Visible = false;
            cambiarHabilitacionControles(false);
            if (cboTipoExamen.SelectedIndex != -1)
            {
                llenarFormulario();
            }
            else
            {
                llenarFormularioPadre();
            }

            //
            btnAgregar5.Visible = false;
            btnEditar5.Visible = true;
            btnEliminar5.Visible = false;
        }

        private void cambiarHabilitacionControles(bool estado)
        {
            tbDescripcion7.Enabled = estado;
            tbDescripcionInformes.Enabled = estado;
            tbPrecioBase.Enabled = estado;
            dgvBacteriologia.Enabled = estado;
            dgvBacteriologia.ReadOnly = !estado;  // Permitir edición en grids
            dgvClinico.Enabled = estado;
            dgvClinico.ReadOnly = !estado;
            dgvCraneoYMSuperior.Enabled = estado;
            dgvCraneoYMSuperior.ReadOnly = !estado;
            dgvEstComplementarios.Enabled = estado;
            dgvEstComplementarios.ReadOnly = !estado;
            dgvHematologia.Enabled = estado;
            dgvHematologia.ReadOnly = !estado;
            dgvLaboralesBasicas.Enabled = estado;
            dgvLaboralesBasicas.ReadOnly = !estado;
            dgvMiembroInferior.Enabled = estado;
            dgvMiembroInferior.ReadOnly = !estado;
            dgvOrina.Enabled = estado;
            dgvOrina.ReadOnly = !estado;
            dgvPerfilLipidico.Enabled = estado;
            dgvPerfilLipidico.ReadOnly = !estado;
            dgvQuimicaHematica.Enabled = estado;
            dgvQuimicaHematica.ReadOnly = !estado;
            dgvSerologia.Enabled = estado;
            dgvSerologia.ReadOnly = !estado;
            dgvTroncoYPelvis.Enabled = estado;
            dgvTroncoYPelvis.ReadOnly = !estado;

            tabControl.Enabled = estado;
            tabControl.SelectedIndex = 0;
        }

        private void cambiarHabilitacionTabControl()
        {
            tabControl.Enabled = true;
        }

        private void botCancelar7_Click(object sender, EventArgs e)
        {
            modoMenu();

            if (cboTipoExamen.Text == "" && tbDescripcion7.Text == "")
            {
                //this.Close();
            }
        }

        private void botGuardar7_Click(object sender, EventArgs e)
        {
            blnEstadoGuardo = true;
            if (cboTipoExamen.SelectedIndex == -1)
            {
                guardarPadre();
            }
            else
            {
                guardar7();
            }
            //
            //botAgregar.Visible = true;
            //botEditar.Visible = true;
            //botEliminar.Visible = true;

            if (blnEstadoGuardo)
            {
                //this.Close();
            }
        }

        private void guardar7()
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

        private void guardarPadre()
        {
            if (verificarDatosIngresados())
            {
                guardarDatosPadre();
            }
            else
            {
                MessageBox.Show("¡Faltan ingresar datos requeridos!", "Ingresar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool verificarDatosIngresados()
        {
            if (tbDescripcion7.Text != string.Empty && cboMotivoConsulta.SelectedIndex != -1)
            {
                return true;
            }
            return false;
        }

        private void guardarDatos()
        {
            // Asegurar que los cambios en DataGrids se graben antes de continuar
            CommitDataGridChanges();

            Entidades.TipoExamen entidad = llenarDatosEntidad();
            Entidades.Resultado resultado;

            // Siempre editar, nunca crear
            // Validación de nombre repetido eliminada porque siempre se edita

            string strIdEspecialidad = ValidarExisteExamen();

            // ✅ GUARDAR DIRECTAMENTE SIN DIÁLOGOS (siempre editando)
            resultado = tipoExamen.editarTipoExamen(entidad);
            if (resultado.Modo == 1)
            {
                MessageBox.Show("Exámen de aptitud editado correctamente", "Editar Tipo Examen",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                modoMenu();
                llenarFormulario();
                blnItemsModificados = false;  // Reset flag después de guardar
            }
            else
            {
                MessageBox.Show("¡Error al editar Tipo de Examen!\nError:" + resultado.Mensaje, "Editar Tipo Examen",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                blnEstadoGuardo = false;
            }
        }


        private void guardarDatosPadre()
        {
            // Asegurar que los cambios en DataGrids se graben antes de continuar
            CommitDataGridChanges();

            Entidades.TipoExamen entidad = llenarDatosEntidadPadre();
            Entidades.Resultado resultado;
            if (tbId7.Text != string.Empty)
            {
                //

                string strIdEspecialidad = ValidarExisteExamen();

                //if (strIdEspecialidad != strIdEspecialidadViejo)
                //{
                //    if (!string.IsNullOrEmpty(strIdEspecialidad))
                //    {
                //        MessageBox.Show("El examen " + tipoExamen.DescripcionEspecialidad(strIdEspecialidad) + " contiene los mismos ítems\n\n", "Crear Tipo Examen",
                //                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        blnEstadoGuardo = false;
                //        return;
                //    }
                //}
                //else
                //{
                MsgBoxUtil.HackMessageBox("Actualizar", "Crear Nuevo", "Cancelar");
                DialogResult resultExamen = MessageBox.Show("¿Desea crear un nuevo examen o actualizar el mismo? ", "Crear Tipo Examen",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (resultExamen == DialogResult.Yes)
                {
                    // continua con el proceso normal
                }
                else if (resultExamen == DialogResult.No)
                {
                    //blnEstadoGuardo = false;
                    tbDescripcion7.Text = "";
                    tbDescripcionInformes.Text = "";
                    tbPrecioBase.Text = "";
                    tbId7.Text = "";
                    blnEstadoGuardo = false;
                    return;
                }
                else if (resultExamen == DialogResult.Cancel)
                {
                    blnEstadoGuardo = false;
                    return;
                }
                //}
                //

                resultado = tipoExamen.editarTipoExamen(entidad);
                if (resultado.Modo == 1)
                {
                    MessageBox.Show("Exámen de aptitud editado correctamente", "Crear Tipo Examen",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    modoMenu();
                    llenarFormularioPadre();
                    blnItemsModificados = false;  // Reset flag después de guardar
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
                //
                resultado = tipoExamen.crearTipoExamenPadre(entidad);
                if (resultado.Modo == 1)
                {
                    MessageBox.Show("Exámen de aptitud guardado correctamente", "Crear Tipo Examen",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    modoMenu();
                    limpiarPanelPrincipal();
                    cargarComboNivel1();
                    cboSubTipo.SelectedIndex = cboSubTipo.Items.Count - 1;
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
            if (tbId7.Text != string.Empty)
            {
                retorno.Id = new Guid(tbId7.Text);
            }
            retorno.Descripcion = tbDescripcion7.Text;
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

            // ✅ Validación mejorada: Aceptar int completo sin restricción int16
            if (int.TryParse(tbCodigo7.Text, out int codigo))
            {
                retorno.Codigo = codigo;  // ✅ Asignar directamente (int completo)
            }
            else
            {
                MessageBox.Show("El código debe ser un número válido", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            //Modificado
            retorno.Padre = false;
            retorno.IdPadre = cboSubTipo.SelectedValue.ToString();
            retorno.Modificado = blnItemsModificados;  // Marcar si hay cambios en items
            return retorno;

        }

        private Entidades.TipoExamen llenarDatosEntidadPadre()
        {
            Entidades.TipoExamen retorno = new Entidades.TipoExamen();
            if (tbId7.Text != string.Empty)
            {
                retorno.Id = new Guid(tbId7.Text);
            }
            retorno.Descripcion = tbDescripcion7.Text;
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

            // ✅ Validación mejorada: Aceptar int completo sin restricción int16
            if (int.TryParse(tbCodigo7.Text, out int codigoPadre))
            {
                retorno.Codigo = codigoPadre;  // ✅ Asignar directamente (int completo)
            }
            else
            {
                MessageBox.Show("El código debe ser un número válido", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            //Modificado
            retorno.Padre = true;
            retorno.IdPadre = null;
            retorno.Modificado = blnItemsModificados;  // Marcar si hay cambios en items
            return retorno;

        }


        public void botAgregar7_Click(object sender, EventArgs e)
        {
            // ✅ PREGUNTAR SI CREAR NUEVO O USAR EXISTENTE
            DialogResult resultado = MessageBox.Show(
                "¿Desea crear un NUEVO Tipo de Examen?\n\n" +
                "Sí = Crear nuevo (Motivo → Tipo → Subtipo)\n" +
                "No = Usar tipo existente",
                "Agregar Tipo de Examen",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // ✅ CREAR NUEVO: Ir a tab "Agregar Tipos y Subtipos"
                tab.SelectedIndex = 1;  // Índice de la tab "Agregar Tipos y Subtipos"

                MessageBox.Show(
                    "Se abrió la pestaña 'Agregar Tipos y Subtipos'.\n\n" +
                    "1. Selecciona o crea un Motivo de Consulta\n" +
                    "2. Crea un Tipo de Examen PADRE\n" +
                    "3. Crea un Subtipo de Examen HIJO\n" +
                    "4. Asigna los Items",
                    "Crear Nuevo Tipo de Examen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Refrescar pantalla tras agregar o asignar ítem
                RefrescarPantalla();
            }
            else if (resultado == DialogResult.No)
            {
                // ✅ USAR EXISTENTE: Validar que haya seleccionado los datos
                if (cboMotivoConsulta.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un MOTIVO DE CONSULTA",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMotivoConsulta.Focus();
                    return;
                }

                if (cboTipoExamen.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un TIPO DE EXAMEN",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboTipoExamen.Focus();
                    return;
                }

                if (cboSubTipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un SUBTIPO",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSubTipo.Focus();
                    return;
                }

                // ✅ TODO VALIDADO: Proceder con el formulario de edición
                nuevoTipoExamenParcial();
                modoEdicion7();
                tbDescripcion7.Focus();

                // Refrescar pantalla tras editar ítem
                RefrescarPantalla();
            }
        }
        private void nuevoTipoExamen()
        {
            limpiarPanelPrincipal();
            cboTipoExamen.SelectedIndex = -1;
            modoEdicion7();
            Entidades.TipoExamen entidad = tipoExamen.cargarItems();
            tbCodigo7.Text = entidad.Codigo.ToString();
            llenarDataGrids(entidad);
        }

        private void nuevoTipoExamenParcial()
        {
            limpiarPanelParcial();
            cboTipoExamen.SelectedIndex = -1;
            modoEdicion7();
            Entidades.TipoExamen entidad = new TipoExamen();
            if (cboSubTipo.SelectedIndex != -1)
            {
                Entidades.TipoExamen entidad2 = tipoExamen.cargarItems();
                entidad = tipoExamen.cargarEntidad(cboSubTipo.SelectedValue.ToString());
                tbCodigo7.Text = entidad2.Codigo.ToString();
            }
            else
            {
                entidad = tipoExamen.cargarItems();
                tbCodigo7.Text = entidad.Codigo.ToString();
            }
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

        private void botEliminar7_Click(object sender, EventArgs e)
        {
            if (cboTipoExamen.SelectedIndex != -1)
            {
                eliminarTipoExamen();
                cargarComboTipoExamen();
                limpiarPanelPrincipal();
            }
            else if (cboSubTipo.SelectedIndex != -1 && cboTipoExamen.SelectedIndex == -1)
            {
                EliminarTipoExamenPadre();
                cargarComboNivel1();
                limpiarPanelPrincipal();
            }
        }

        private void EliminarTipoExamenPadre()
        {
            Comunes.SQLConnector.obtenerTablaSegunConsultaString(@"INSERT INTO [MEPRYLv2.1].[dbo].[EspecialidadesEliminadas] 
            Select * 
            from [MEPRYLv2.1].[dbo].[Especialidad] 
            WHERE id = '" + cboSubTipo.SelectedValue.ToString() + "'");
        }

        private void eliminarTipoExamen()
        {
            if (cboTipoExamen.SelectedIndex != -1 && tbId7.Text != "")
            {
                DialogResult result = MessageBox.Show("Se va a eliminar el Tipo de Examen seleccionado, \n\n¿Realmente desea continuar?",
                    "Eliminar Tipo de Examen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Comunes.SQLConnector.obtenerTablaSegunConsultaString(@"INSERT INTO [MEPRYLv2.1].[dbo].[EspecialidadesEliminadas] 
                    Select * 
                    from [MEPRYLv2.1].[dbo].[Especialidad] 
                    WHERE id = '" + cboTipoExamen.SelectedValue.ToString() + "'");
                    //Entidades.Resultado resultado = tipoExamen.eliminarTipoExamen(tbId7.Text);
                    /*if (resultado.Modo == 1)
                    {
                        limpiarPanelPrincipal();
                        cargarComboTipoExamen();
                        MessageBox.Show("¡Tipo de Examen eliminado correctamente!", "Eliminar Tipo de Examen",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarComboNivel1();
                    }
                    else
                    {
                        MessageBox.Show("¡El Tipo de Examen no puede ser eliminado!\n" + resultado.Mensaje,
                            "Eliminar Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }*/
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de examen", "Eliminar Tipo de Examen",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            tabControl.Enabled = false;
            tabControl.SelectedIndex = 0;
        }

        private void cboMotivoConsulta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            limpiarPanelPrincipal();
            cboSubTipo.DataSource = null;
            cboTipoExamen.DataSource = null;
            // Solo cargar si hay motivo seleccionado
            if (cboMotivoConsulta.SelectedIndex != -1 && cboMotivoConsulta.SelectedValue != null)
            {
                cargarComboNivel1();
            }
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
            // Este método carga los Tipos/Nivel 1 en cboTipoExamen
            // cuando se selecciona un Motivo en cboSubTipo
            limpiarPanelPrincipal();
            cboTipoExamen.DataSource = null;

            if (cboSubTipo.SelectedIndex != -1) // Nivel 1 (Tipo) seleccionado
            {
                try
                {
                    // Cascade: Nivel 1 → Nivel 2 (carga Subtipos en cboTipoExamen)
                    DataTable dt = tipoExamen.cargarNivel2EspecialidadActivos(cboSubTipo.SelectedValue.ToString());
                    cboTipoExamen.DataSource = dt;
                    cboTipoExamen.ValueMember = "id";
                    cboTipoExamen.DisplayMember = "descripcion";
                    cboTipoExamen.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void botSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ValidarExisteExamen()
        {
            string resultado = "";

            // ✅ SI ESTAMOS EDITANDO (hay ID), NO HACER VALIDACIÓN
            // Solo validar cuando estamos CREANDO (sin ID)
            if (!string.IsNullOrEmpty(tbId7.Text))
            {
                return resultado; // ✅ No validar al editar
            }

            // ✅ SOLO SI ESTAMOS CREANDO (sin ID)
            Entidades.TipoExamen entidad = llenarDatosEntidad();

            if (entidad == null)
            {
                return resultado;
            }

            // ✅ COMPARAR CON TODOS LOS EXÁMENES (solo si es NUEVO)
            DataTable dtTodosExamenes = tipoExamen.ListaEstudioPorTipoExamen();

            if (dtTodosExamenes == null || dtTodosExamenes.Rows.Count == 0)
            {
                return resultado;
            }

            foreach (DataRow row in dtTodosExamenes.Rows)
            {
                bool iguales = true;
                iguales &= CompararItemsConEstudiosPorExamen(entidad.Clinico, row);
                iguales &= CompararItemsConEstudiosPorExamen(entidad.Hematologia, row);
                iguales &= CompararItemsConEstudiosPorExamen(entidad.QuimicaHematica, row);
                iguales &= CompararItemsConEstudiosPorExamen(entidad.Serologia, row);
                iguales &= CompararItemsConEstudiosPorExamen(entidad.PerfilLipidico, row);
                iguales &= CompararItemsConEstudiosPorExamen(entidad.Bacteriologia, row);
                iguales &= CompararItemsConEstudiosPorExamen(entidad.Orina, row);
                iguales &= CompararItemsConEstudiosPorExamen(entidad.LaboralesBasicas, row);
                iguales &= CompararItemsConEstudiosPorExamen(entidad.CraneoYMSuperior, row);
                iguales &= CompararItemsConEstudiosPorExamen(entidad.TroncoYPelvis, row);
                iguales &= CompararItemsConEstudiosPorExamen(entidad.MiembroInferior, row);
                iguales &= CompararItemsConEstudiosPorExamen(entidad.EstComplementarios, row);

                if (iguales)
                {
                    // ✅ ENCONTRÓ UN DUPLICADO (solo para nuevos)
                    return row.Table.Columns.Contains("Codigo") ? row["Codigo"].ToString() : "";
                }
            }

            return resultado;
        }

        private bool CompararItemsConEstudiosPorExamen(DataTable items, DataRow examenRow)
        {
            foreach (DataRow item in items.Rows)
            {
                string codigo = item["Codigo"].ToString();
                bool estadoItem = Convert.ToBoolean(item["Estado"]);
                bool estadoExamen = false;
                if (examenRow.Table.Columns.Contains(codigo))
                {
                    var valor = examenRow[codigo];
                    estadoExamen = valor != DBNull.Value && valor.ToString() == "1";
                }
                if (estadoItem != estadoExamen)
                    return false;
            }
            return true;
        }

        private string ValidarExisteExamenPadre()
        {
            string resultado = "";
            DataTable dtTipoExamenes = tipoExamen.ListaEstudioPorTipoExamen(new Guid(tbId7.Text)); Entidades.TipoExamen entidad = llenarDatosEntidadPadre();
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

                        if (blnRtdoClinico == false &&
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

            // Cascada: Motivo → TipoExamen (Nivel 1) → SubTipo (Nivel 2) → IdEspecialidad (Nivel 3)
            cboMotivoConsulta.SelectedValue = int.Parse(tipoExamen.ObtenerMotivoConsulta(IdEspecialidad));

            // IdEspecialidadPadre es el Nivel 1 (categoría padre)
            blnEstadoTipoExamen = true;
            cboSubTipo.SelectedValue = IdEspecialidadPadre;

            // IdEspecialidad es el Nivel 3 (item final seleccionado)
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
                if (cboMotivoConsulta.SelectedIndex != -1 && cboMotivoConsulta.SelectedValue != null)
                {
                    cargarComboNivel1();
                }
                else
                {
                    cboSubTipo.DataSource = null;
                    cboTipoExamen.DataSource = null;
                }
            }
        }

        private void cboSubTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ✅ EVITAR SINCRONIZACIÓN RECURSIVA MIENTRAS SE ESTÁ SINCRONIZANDO
            if (sincronizandoDesdeAgregar) return;

            if (cboSubTipo.Text != "")
            {
                tbIdTipoExamen.Text = cboSubTipo.SelectedValue.ToString();
            }

            if (strEstadoEdicion == "EDITAR")
            {
                cargarComboTipoExamen();
            }

            // ✅ SINCRONIZACIÓN BIDIRECCIONAL: Si estamos en "Tipo de Examen Médico", sincronizar a "Agregar"
            if (tab.SelectedTab?.Text == "Tipo de Examen Médico" && frmAgregarEspecialidadInstance != null && !frmAgregarEspecialidadInstance.IsDisposed)
            {
                int idMotivo = cboMotivoConsulta.SelectedIndex > -1 ?
                    Convert.ToInt32(cboMotivoConsulta.SelectedValue ?? 0) : 0;
                string idTipo = cboSubTipo.SelectedValue?.ToString() ?? "";
                System.Diagnostics.Debug.WriteLine($"[SYNC][cboSubTipo_SelectedIndexChanged] Sincronizando a Agregar: Motivo={idMotivo}, Tipo={idTipo}");
                frmAgregarEspecialidadInstance.SincronizarCombosDesde(idMotivo, idTipo, "");
            }
        }

        private void cboTipoExamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evitar ejecución si no hay selección válida
            if (cboTipoExamen.SelectedIndex == -1 || cboTipoExamen.SelectedValue == null)
                return;

            // ✅ EVITAR SINCRONIZACIÓN RECURSIVA MIENTRAS SE ESTÁ SINCRONIZANDO
            if (sincronizandoDesdeAgregar) return;

            if (strEstadoEdicion == "EDITAR" && blnEstadoTipoExamen == true)
            {
                cboTipoExamen_SelectionChangeCommitted(sender, e);
            }
            // ✅ SINCRONIZACIÓN BIDIRECCIONAL: Si estamos en "Tipo de Examen Médico", sincronizar a "Agregar"
            if (tab.SelectedTab?.Text == "Tipo de Examen Médico" && frmAgregarEspecialidadInstance != null && !frmAgregarEspecialidadInstance.IsDisposed)
            {
                int idMotivo = cboMotivoConsulta.SelectedIndex > -1 ?
                    Convert.ToInt32(cboMotivoConsulta.SelectedValue ?? 0) : 0;
                string idTipo = cboSubTipo.SelectedValue?.ToString() ?? "";
                string idSubtipo = cboTipoExamen.SelectedValue?.ToString() ?? "";
                System.Diagnostics.Debug.WriteLine($"[SYNC][cboTipoExamen_SelectedIndexChanged] Sincronizando a Agregar: Motivo={idMotivo}, Tipo={idTipo}, Subtipo={idSubtipo}");
                frmAgregarEspecialidadInstance.SincronizarCombosDesde(idMotivo, idTipo, idSubtipo);
            }

            // ✅ SINCRONIZACIÓN TRIDIMENSIONAL: Si estamos en "Tipo de Examen Médico", sincronizar también a "Gestionar" si está cargado
            if (tab.SelectedTab?.Text == "Tipo de Examen Médico" && frmGestionarEspecialidadInstance != null && !frmGestionarEspecialidadInstance.IsDisposed)
            {
                int idMotivo = cboMotivoConsulta.SelectedIndex > -1 ?
                    Convert.ToInt32(cboMotivoConsulta.SelectedValue ?? 0) : 0;
                string idTipo = cboSubTipo.SelectedValue?.ToString() ?? "";
                string idSubtipo = cboTipoExamen.SelectedValue?.ToString() ?? "";

                if (idMotivo > 0 && !string.IsNullOrEmpty(idTipo) && !string.IsNullOrEmpty(idSubtipo))
                {
                    System.Diagnostics.Debug.WriteLine($"[SYNC][cboTipoExamen_SelectedIndexChanged] Sincronizando a Gestionar: Motivo={idMotivo}, Tipo={idTipo}, Subtipo={idSubtipo}");
                    frmGestionarEspecialidadInstance.SincronizarCombosDesde(idMotivo, idTipo, idSubtipo);
                }
            }
        }

        public void OcultarEditar()
        {
            btnEditar5.Visible = false;
        }

        public void OcultarAgregar()
        {
            btnAgregar5.Visible = false;
        }

        public void verificaTipoExamen()
        {
            //
            //MsgBoxUtil.HackMessageBox("Todos", "Seleccionados", "Cancelar");
            //DialogResult resultExamen = MessageBox.Show("¿Desea enviar un correo a los pacientes con su estudio consolidado?\n\n", "Enviar correo",
            //    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (strDescripcionViejo != tbDescripcion7.Text)
            {
                // ✅ MEJORADO: Pasar el Guid actual para excluirlo de la búsqueda
                Guid idActualPadre = new Guid(tbId7.Text);
                if (tipoExamen.VerificaNombreRepetidos(tbDescripcion7.Text, idActualPadre))
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Commits los cambios de todos los DataGrids antes de guardar
        /// Esto asegura que los cambios en las celdas se guarden en el DataSource
        /// </summary>
        private void CommitDataGridChanges()
        {
            try
            {
                // EndEdit() para cada grid para asegurar que los cambios se guarden
                if (dgvClinico.DataSource != null)
                    dgvClinico.EndEdit();
                if (dgvHematologia.DataSource != null)
                    dgvHematologia.EndEdit();
                if (dgvQuimicaHematica.DataSource != null)
                    dgvQuimicaHematica.EndEdit();
                if (dgvSerologia.DataSource != null)
                    dgvSerologia.EndEdit();
                if (dgvPerfilLipidico.DataSource != null)
                    dgvPerfilLipidico.EndEdit();
                if (dgvBacteriologia.DataSource != null)
                    dgvBacteriologia.EndEdit();
                if (dgvOrina.DataSource != null)
                    dgvOrina.EndEdit();
                if (dgvLaboralesBasicas.DataSource != null)
                    dgvLaboralesBasicas.EndEdit();
                if (dgvCraneoYMSuperior.DataSource != null)
                    dgvCraneoYMSuperior.EndEdit();
                if (dgvTroncoYPelvis.DataSource != null)
                    dgvTroncoYPelvis.EndEdit();
                if (dgvMiembroInferior.DataSource != null)
                    dgvMiembroInferior.EndEdit();
                if (dgvEstComplementarios.DataSource != null)
                    dgvEstComplementarios.EndEdit();

                blnItemsModificados = true;  // Marcar como modificado
            }
            catch (Exception ex)
            {
            }
        }

        private void tbResumenRx_TextChanged(object sender, EventArgs e)
        {

        }

        // ✅ NUEVO MÉTODO: Sincronizar los combos de "Tipo de Examen Médico" con "Gestionar"
        private void SincronizarCombosAGestionar()
        {
            try
            {
                if (frmGestionarEspecialidadInstance == null || frmGestionarEspecialidadInstance.IsDisposed)
                    return;

                // Obtener los valores seleccionados de la solapa "Tipo de Examen Médico"
                if (cboMotivoConsulta.SelectedValue != null &&
                    cboSubTipo.SelectedValue != null &&
                    cboTipoExamen.SelectedValue != null)
                {
                    string idMotivo = cboMotivoConsulta.SelectedValue.ToString();
                    string idTipo = cboSubTipo.SelectedValue.ToString();
                    string idSubtipo = cboTipoExamen.SelectedValue.ToString();

                    // Cargar el subtipo seleccionado en Gestionar con los mismos combos llenos
                    frmGestionarEspecialidadInstance.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            frmGestionarEspecialidadInstance.CargarSubtipoEnTab(Convert.ToInt32(idMotivo), idTipo, idSubtipo);
                        }
                        catch (Exception ex)
                        {
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
            }
        }

        // ✅ NUEVO MÉTODO: Sincronizar los combos de "Gestionar" hacia "Tipo de Examen Médico" (inversa)
        private void SincronizarCombosDesdeGestionar()
        {
            try
            {
                if (frmGestionarEspecialidadInstance == null || frmGestionarEspecialidadInstance.IsDisposed)
                    return;

                // Obtener los valores seleccionados usando las propiedades públicas de FrmAñadirEspecialidad
                int idMotivo = frmGestionarEspecialidadInstance.ObtenerIdMotivoConsultaSeleccionado;
                string idTipo = frmGestionarEspecialidadInstance.ObtenerIdTipoExamenSeleccionado;
                string idSubtipo = frmGestionarEspecialidadInstance.ObtenerIdSubtipoActualmenteCargado;

                if (idMotivo > 0 && !string.IsNullOrEmpty(idTipo) && !string.IsNullOrEmpty(idSubtipo))
                {
                    // Llenar los combos de "Tipo de Examen Médico" con los valores de "Gestionar"
                    // Combo Motivo
                    for (int i = 0; i < cboMotivoConsulta.Items.Count; i++)
                    {
                        DataRowView drv = (DataRowView)cboMotivoConsulta.Items[i];
                        if (drv["id"].ToString() == idMotivo.ToString())
                        {
                            cboMotivoConsulta.SelectedIndex = i;
                            break;
                        }
                    }

                    // Esperar a que se cargue combo Tipo
                    this.BeginInvoke(new Action(() =>
                    {
                        cargarComboNivel1();
                        for (int i = 0; i < cboSubTipo.Items.Count; i++)
                        {
                            DataRowView drv = (DataRowView)cboSubTipo.Items[i];
                            if (drv["id"].ToString() == idTipo)
                            {
                                cboSubTipo.SelectedIndex = i;
                                break;
                            }
                        }

                        // Esperar a que se cargue combo Subtipo
                        this.BeginInvoke(new Action(() =>
                        {
                            cargarComboNivel2();
                            for (int i = 0; i < cboTipoExamen.Items.Count; i++)
                            {
                                DataRowView drv = (DataRowView)cboTipoExamen.Items[i];
                                if (drv["id"].ToString() == idSubtipo)
                                {
                                    cboTipoExamen.SelectedIndex = i;
                                    break;
                                }
                            }

                            // Cargar el resumen
                            llenarFormulario();
                        }));
                    }));
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAñadirEspecialidad frmEspecialidad = null;

                // Intentar obtener la instancia desde diferentes fuentes
                if (frmAgregarEspecialidadInstance != null && !frmAgregarEspecialidadInstance.IsDisposed)
                {
                    frmEspecialidad = frmAgregarEspecialidadInstance;
                }
                else if (frmGestionarEspecialidadInstance != null && !frmGestionarEspecialidadInstance.IsDisposed)
                {
                    frmEspecialidad = frmGestionarEspecialidadInstance;
                }
                else if (tab.SelectedTab != null)
                {
                    // Buscar en los controles del TabPage actual
                    foreach (Control ctrl in tab.SelectedTab.Controls)
                    {
                        if (ctrl is FrmAñadirEspecialidad frm)
                        {
                            frmEspecialidad = frm;
                            break;
                        }
                    }
                }

                if (frmEspecialidad != null && !frmEspecialidad.IsDisposed)
                {
                    // Guardar cambios
                    frmEspecialidad.EjecutarGuardar();

                    // Obtener los datos que se acaban de guardar
                    int idMotivo = frmEspecialidad.ObtenerIdMotivoConsultaSeleccionado;
                    string idTipo = frmEspecialidad.ObtenerIdTipoExamenSeleccionado;
                    string idSubtipo = frmEspecialidad.ObtenerIdSubtipoActualmenteCargado;

                    // Navegar a la solapa "Tipo de Examen Médico"
                    foreach (System.Windows.Forms.TabPage tabPage in tab.TabPages)
                    {
                        if (tabPage.Text == "Tipo de Examen Médico")
                        {
                            tab.SelectedTab = tabPage;

                            // Sincronizar si hay datos
                            if (idMotivo > 0 && !string.IsNullOrEmpty(idTipo) && !string.IsNullOrEmpty(idSubtipo))
                            {
                                // Cargar combo motivo
                                cargarComboMotivoConsulta();
                                Application.DoEvents();
                                cboMotivoConsulta.SelectedValue = idMotivo;

                                // Cargar combo tipo
                                cargarComboNivel1();
                                Application.DoEvents();
                                cboSubTipo.SelectedValue = idTipo;

                                // Cargar combo subtipo
                                cargarComboNivel2();
                                Application.DoEvents();
                                cboTipoExamen.SelectedValue = idSubtipo;

                                // Cargar datos del formulario
                                Application.DoEvents();
                                if (cboTipoExamen.SelectedIndex != -1)
                                {
                                    cboTipoExamen_SelectionChangeCommitted(cboTipoExamen, EventArgs.Empty);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnguardarsubtipos_Click(object sender, EventArgs e)
        {
            // Llama al método público de la instancia de FrmAñadirEspecialidad
            FrmAñadirEspecialidad frm = null;
            if (frmGestionarEspecialidadInstance != null && !frmGestionarEspecialidadInstance.IsDisposed)
            {
                frm = frmGestionarEspecialidadInstance;
            }
          
            if (frm != null)
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] btnguardarsubtipos_Click: Guardando cambios de subtipos.");
                frm.GuardarCambiosSubtipos();
                // Ocultar el botón tras guardar
                if (btnguardarsubtipos != null)
                    btnguardarsubtipos.Visible = false;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] btnguardarsubtipos_Click: No hay instancia activa de FrmAñadirEspecialidad.");
                MessageBox.Show("No hay instancia activa de FrmAñadirEspecialidad para guardar los subtipos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Método para sincronizar la visibilidad del botón btngravarespecialidades según los subtipos pendientes
        private void SincronizarBotonGrabarEspecialidades()
        {
            FrmAñadirEspecialidad frm = null;
            if (frmAgregarEspecialidadInstance != null && !frmAgregarEspecialidadInstance.IsDisposed)
            {
                frm = frmAgregarEspecialidadInstance;
            }
            else if (frmGestionarEspecialidadInstance != null && !frmGestionarEspecialidadInstance.IsDisposed)
            {
                frm = frmGestionarEspecialidadInstance;
            }
            if (frm != null)
            {
                // Se asume que la lista subtiposPendientesCambio es pública o hay un método para obtener la cantidad
                var prop = frm.GetType().GetField("subtiposPendientesCambio", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (prop != null)
                {
                    var lista = prop.GetValue(frm) as System.Collections.ICollection;
                    var btn = frm.Controls.Find("btngravarespecialidades", true).FirstOrDefault() as Button;
                    if (btn != null)
                    {
                        bool hayPendientes = lista != null && lista.Count > 0;
                        btn.Visible = hayPendientes;
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] SincronizarBotonGrabarEspecialidades: subtiposPendientesCambio.Count={(lista != null ? lista.Count : 0)}, Botón Visible={btn.Visible}");
                    }
                }
            }
        }

      
    }
}
