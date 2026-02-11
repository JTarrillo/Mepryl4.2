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

namespace CapaPresentacion
{
    public partial class frmZonasNacionalidad : DevExpress.XtraEditors.XtraForm
    {
        private CapaNegocioMepryl.Nacionalidades nacionalidades;

        public frmZonasNacionalidad()
        {
            InitializeComponent();
            inicializar();
            inicializar2();
        }

        public frmZonasNacionalidad(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            // Nacionalidades
            inicializar();
            // Localidades
            /*inicializar2();*/
            // Zonas Geográficas
            inicializar3();
            // Prestaciones
            /*inicializar4();*/
            // Examen Aptitud
            /*inicializar6();*/
            // Examen Aptitud
            /*inicializar7();*/

            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;

            tab.TabPages.Remove(tabPage5);
            tab.TabPages.Remove(tabPage4);
            tab.TabPages.Remove(tabPage2);
            tab.TabPages.Remove(tabPage6);
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

            //btnGuardar5.Visible = false;
            //btnCancelar5.Visible = false;
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
            //cboTipoPrestacion2.Text = "LOCALIDAD";
            //cboTipoPrestacion4.Text = "PRESTACION";
            //cboTipoPrestacion6.Text = "EXAMEN APTITUD";
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
                //case 1:
                //    botAgregar4_Click(sender, e);
                //    txtDescripcion4.Select();
                //    break;
                //case 2:
                //    botAgregar2_Click(sender, e);
                //    txtDescripcion2.Select();
                //    break;
                case 0:
                    botAgregar_Click(sender, e);
                    break;
                case 1:
                    botAgregar3_Click(sender, e);
                    break;
                    //case 0:
                    //    //frmConfigTipoExamenExApt frm = new frmConfigTipoExamenExApt();                    
                    //    //frm.OcultarEditar();
                    //    //frm.ShowDialog();
                    //    botAgregar7_Click(sender, e);
                    //    tbDescripcion7.Select();
                    //    //txtDescripcion6.Select();
                    //    //llenarDgv6();
                    //    break;
            }

        }

        private void btnEditar5_Click(object sender, EventArgs e)
        {
            switch (tab.SelectedIndex)
            {
                //case 1:
                //    botEditar4_Click(sender, e);
                //    txtDescripcion4.Select();
                //    break;
                //case 2:
                //    botEditar2_Click(sender, e);
                //    txtDescripcion2.Select();                   
                //    break;
                case 0:
                    botEditar_Click(sender, e);
                    break;
                case 1:
                    botEditar3_Click(sender, e);
                    break;
                    //case 0:
                    //    //btnEditar6_Click(sender, e);
                    //    //txtDescripcion6.Select();
                    //    //EditarExamenActitud06();
                    //    //llenarDgv6();
                    //    botEditar7_Click(sender, e);
                    //    break;
            }
        }

        private void btnGuardar5_Click(object sender, EventArgs e)
        {
            switch (tab.SelectedIndex)
            {
                //case 1:
                //    botGuardar4_Click(sender, e);
                //    break;
                //case 2:
                //    botGuardar2_Click(sender, e);                    
                //    break;
                case 0:
                    botGuardar_Click(sender, e);
                    break;
                case 1:
                    botGuardar3_Click(sender, e);
                    break;
                    //case 0:
                    //    //btnGuardar6_Click(sender, e);
                    //    botGuardar7_Click(sender, e);
                    //    break;
            }
        }

        private void btnCancelar5_Click(object sender, EventArgs e)
        {
            switch (tab.SelectedIndex)
            {
                //case 1:
                //    botCancelar4_Click(sender, e);
                //    break;
                //case 2:
                //    botCancelar2_Click(sender, e);                    
                //    break;
                case 0:
                    botCancelar_Click(sender, e);
                    break;
                case 1:
                    botCancelar3_Click(sender, e);
                    break;
                    //case 0:
                    //    //btnCancelar6_Click(sender, e);
                    //    botCancelar7_Click(sender, e);
                    //    break;
            }
        }

        private void btnEliminar5_Click(object sender, EventArgs e)
        {
            switch (tab.SelectedIndex)
            {
                //case 1:
                //    botEliminar4_Click(sender, e);
                //    break;
                //case 2:
                //    botEliminar2_Click(sender, e);                    
                //    break;
                case 0:
                    botEliminar_Click(sender, e);
                    break;
                case 1:
                    botEliminar3_Click(sender, e);
                    break;
                    //case 0:
                    //    botEliminar7_Click(sender, e);
                    //    //llenarDgv6();
                    //    break;
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
            if(tab.SelectedIndex != 0)
            {
                btnGuardar5.Visible = true;
                btnCancelar5.Visible = true;
            }
            else
            {
                btnGuardar5.Visible = false;
                btnCancelar5.Visible = false;
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

        private void inicializar7()
        {
            tipoExamen = new CapaNegocioMepryl.TipoExamen();
            cargarComboMotivoConsulta();
            modoMenu();

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

        private void llenarFormulario()
        {
            limpiarPanelPrincipal();
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
                //tbId.Text = entidad.Id.ToString();
                tbCodigo7.Text = entidad.Codigo.ToString();
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
            btnEditar5.Enabled = false;
            btnEliminar5.Enabled = false;
            limpiarPanelPrincipal();
            if (cboTipoExamen.SelectedIndex != -1)
            {
                tabControl.Enabled = true;
                btnEditar5.Enabled = true;
                btnEliminar5.Enabled = true;
                llenarFormulario();
            }

            strIdEspecialidadViejo = cboTipoExamen.SelectedValue.ToString();
        }

        private void limpiarPanelPrincipal()
        {
            tbId7.Clear();
            tbCodigo7.Clear();
            tbDescripcion7.Clear();
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
            if (cboTipoExamen.SelectedIndex != -1)
            {
                modoEdicion7();
            }else
            {
                MessageBox.Show("¡Falta seleccionar el tipo de examen que se quiere editar!", "Ingresar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
            llenarFormulario();

            //
            btnAgregar5.Visible = true;
            btnEditar5.Visible = true;
            btnEliminar5.Visible = true;
        }

        private void cambiarHabilitacionControles(bool estado)
        {
            tbDescripcion7.Enabled = estado;
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
            guardar7();
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
            Entidades.TipoExamen entidad = llenarDatosEntidad();
            Entidades.Resultado resultado;
            if (tbId7.Text != string.Empty)
            {
                //
                if (strDescripcionViejo != tbDescripcion7.Text)
                {
                    if (tipoExamen.VerificaNombreRepetido(tbDescripcion7.Text))
                    {
                        MessageBox.Show("Ya existe un examen con esa descripción", "Crear Tipo Examen",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnEstadoGuardo = false;
                        return;
                    }
                }

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
                    if (strIdEspecialidad != tbId7.Text)
                    {
                        if (!string.IsNullOrEmpty(strIdEspecialidad))
                        {
                            MessageBox.Show("El examen " + tipoExamen.DescripcionEspecialidad(strIdEspecialidad) + " contiene los mismos ítems\n\n", "Crear Tipo Examen",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            blnEstadoGuardo = false;
                            return;
                        }
                    }

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

                if (tipoExamen.VerificaNombreRepetido(tbDescripcion7.Text))
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
            retorno.Codigo = Convert.ToInt16(tbCodigo7.Text);

            //Modificado
            retorno.Padre = false;
            retorno.IdPadre = cboSubTipo.SelectedValue.ToString();
            return retorno;

        }

        public void botAgregar7_Click(object sender, EventArgs e)
        {
            nuevoTipoExamenParcial();
            if (cboMotivoConsulta.SelectedIndex != -1 && cboSubTipo.SelectedIndex != -1)
            {
                modoEdicion7();
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
            Entidades.TipoExamen entidad = tipoExamen.cargarItems();
            tbCodigo7.Text = entidad.Codigo.ToString();
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

        private void botEliminar7_Click(object sender, EventArgs e)
        {
            eliminarTipoExamen();
        }

        private void eliminarTipoExamen()
        {
            if (cboTipoExamen.SelectedIndex != -1 && tbId7.Text != "")
            {
                DialogResult result = MessageBox.Show("Se va a eliminar el Tipo de Examen seleccionado, \n\n¿Realmente desea continuar?",
                    "Eliminar Tipo de Examen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Entidades.Resultado resultado = tipoExamen.eliminarTipoExamen(tbId7.Text);
                    if (resultado.Modo == 1)
                    {
                        limpiarPanelPrincipal();
                        cargarComboTipoExamen();
                        MessageBox.Show("¡Tipo de Examen eliminado correctamente!", "Eliminar Tipo de Examen",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarComboSubTipo();
                    }
                    else
                    {
                        MessageBox.Show("¡El Tipo de Examen no puede ser eliminado!\n" + resultado.Mensaje,
                            "Eliminar Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
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
            btnEditar5.Enabled = false;
            btnEliminar5.Enabled = false;
            limpiarPanelPrincipal();
            if (cboSubTipo.SelectedIndex != -1)
            {
                tabControl.Enabled = true;
                btnEditar5.Enabled = true;
                btnEliminar5.Enabled = true;
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
            Entidades.TipoExamen entidad = llenarDatosEntidad();
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
                if (tipoExamen.VerificaNombreRepetido(tbDescripcion7.Text))
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
