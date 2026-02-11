using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocioMepryl;
using Entidades;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmCondicionesLaborales : DevExpress.XtraEditors.XtraForm
    {
        private CapaNegocioMepryl.CondicionLaboral condLab;

        public frmCondicionesLaborales()
        {
            InitializeComponent();
            condLab = new CapaNegocioMepryl.CondicionLaboral();
            modoEstatico();
        }

        public frmCondicionesLaborales(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            condLab = new CapaNegocioMepryl.CondicionLaboral();
            modoEstatico();
        }

        private void botAgregar_Click(object sender, EventArgs e)
        {
            cboCondicionesLaborales.SelectedIndex = -1;
            limpiarFormulario();
            modoEdicion();
        }

        private void limpiarFormulario()
        {
            cboLugarAtencionEditar.SelectedIndex = -1;
            tbCodigo.Text = "";
            tbDescripcion.Text = "";
            cboJustificacion.SelectedIndex = -1;
            cboAlta.SelectedIndex = -1;
            cboFechaAlta.SelectedIndex = -1;
            cboFechaCitacion.SelectedIndex = -1;
            tbId.Text = "";
        }

        private void modoEdicion()
        {
            panelEdicion.Enabled = true;
            panelPrincipal.Enabled = false;
            botGuardar.Visible = true;
            botCancelar.Visible = true;
            cboLugarAtencionEditar.Focus();

            botAgregar.Visible = false;
            botEliminar.Visible = false;
        }

        private void modoEstatico()
        {
            panelPrincipal.Enabled = true;
            panelEdicion.Enabled = false;
            botGuardar.Visible = false;
            botCancelar.Visible = false;

            botAgregar.Visible = true;
            botEliminar.Visible = true;
        }

        private void cboLugarAtencion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            llenarComboCondicionesLaborales();
        }

        private void botEditar_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void editar()
        {
            if (validar("editar"))
            {
                modoEdicion();
                cargarDatosCondicionSeleccionada();             
            }
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la condición laboral? Esta acción puede provocar fallos en la integridad del sistema",
                "Eliminar Condición Laboral", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) { eliminar(); }
        }

        private void llenarComboCondicionesLaborales()
        {
            limpiarFormulario();
            cboCondicionesLaborales.DataSource = condLab.cargarCondiciones(cboLugarAtencion.SelectedItem.ToString());
            cboCondicionesLaborales.ValueMember = "id";
            cboCondicionesLaborales.DisplayMember = "descripcion";
            cboCondicionesLaborales.SelectedIndex = -1;
        }

        private void eliminar()
        {
            if (validar("eliminar"))
            {
                Resultado eliminar = condLab.eliminar(cboCondicionesLaborales.SelectedValue.ToString());
                if (eliminar.Modo == -1)
                {
                    MessageBox.Show(eliminar.Mensaje, "Eliminar Condición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(eliminar.Mensaje, "Eliminar Condición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenarComboCondicionesLaborales();
                }
            }
        }

        private bool validar(string modo)
        {
            if (cboCondicionesLaborales.SelectedIndex != -1)
            {
                return true;
            }
            MessageBox.Show("¡Seleccione una condición laboral para " + modo + "!", modo.Replace(modo[0], modo.ToUpper()[0]) + " Condición Laboral",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;         
        }

        private void llenarFormulario(Entidades.CondicionLaboral entidad)
        {
            tbId.Text = entidad.Id.ToString();
            cboLugarAtencionEditar.SelectedItem = entidad.LugarAtencion;
            tbCodigo.Text = entidad.Codigo.ToString();
            tbDescripcion.Text = entidad.Descripcion;
            cboJustificacion.SelectedItem = entidad.Justificacion;
            cboAlta.SelectedItem = entidad.Alta;
            cboFechaAlta.SelectedItem = entidad.FechaAlta;
            cboFechaCitacion.SelectedItem = entidad.FechaCitacion;
        }

        private void cboCondicionesLaborales_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarDatosCondicionSeleccionada();
        }

        private void cargarDatosCondicionSeleccionada()
        {
            limpiarFormulario();
            Entidades.CondicionLaboral entidad = condLab.cargarCondicionSeleccionada(cboCondicionesLaborales.SelectedValue.ToString());
            llenarFormulario(entidad); 
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            modoEstatico();
            limpiarFormulario();
        }

        private void cboLugarAtencionEditar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tbId.Text == "")
            {
                tbCodigo.Text = condLab.proximoCodigo(cboLugarAtencionEditar.SelectedItem.ToString()).ToString();
            }
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            if (validarDatosIngresados())
            {
                guardar();
            }
            else
            {
                MessageBox.Show("¡El ingreso de los campos 'Lugar de Atención' y 'Descripción' es obligatorio!",
                    "Ingresar/Editar Condicion Laboral",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validarDatosIngresados()
        {
            if (cboLugarAtencionEditar.SelectedIndex != -1 && tbDescripcion.Text != "")
            {
                return true;
            }
            return false;
        }

        private void guardar()
        {
            Entidades.Resultado resultado;
            string textoAMostrar = "";
            if (tbId.Text == "")
            {
                textoAMostrar = "Insertar";
                resultado = condLab.nuevaCondicion(cargarEntidad());
                modoEstatico();
                llenarComboCondicionesLaborales();
            }
            else
            {
                textoAMostrar = "Editar";
                resultado = condLab.editarCondicion(cargarEntidad());
                limpiarFormulario();
                modoEstatico();
                cargarDatosCondicionSeleccionada();
            }

            if (resultado.Modo == -1)
            {
                MessageBox.Show(resultado.Mensaje, textoAMostrar + " Condicion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(resultado.Mensaje, textoAMostrar + " Condicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }

        private Entidades.CondicionLaboral cargarEntidad()
        {
            Entidades.CondicionLaboral retorno = new Entidades.CondicionLaboral();
            if (tbId.Text != "") { retorno.Id = new Guid(tbId.Text); }
            retorno.LugarAtencion = cboLugarAtencionEditar.SelectedItem.ToString();
            retorno.Codigo = Convert.ToInt16(tbCodigo.Text);
            retorno.Descripcion = tbDescripcion.Text;
            if (cboJustificacion.SelectedIndex != -1) { retorno.Justificacion = cboJustificacion.SelectedItem.ToString(); }
            if (cboAlta.SelectedIndex != -1) { retorno.Alta = cboAlta.SelectedItem.ToString(); }
            if (cboFechaAlta.SelectedIndex != -1) { retorno.FechaAlta = cboFechaAlta.SelectedItem.ToString(); }
            if (cboFechaCitacion.SelectedIndex != -1) { retorno.FechaCitacion = cboFechaCitacion.SelectedItem.ToString(); }
            return retorno;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rpta = MessageBox.Show("La ventana se cerrará y perderá las modificaciones que no hayan guardado", "Configuración de Condiciones Laborales", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            
            if (rpta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmCondicionesLaborales_Load(object sender, EventArgs e)
        {
            cboLugarAtencion.Text = "CONSULTORIO";
            llenarComboCondicionesLaborales();
        }
    }
}
