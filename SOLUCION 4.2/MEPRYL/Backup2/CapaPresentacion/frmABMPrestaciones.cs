using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace CapaPresentacion
{
    public partial class frmABMPrestaciones : Form
    {
        private CapaNegocioMepryl.LocalidadesYPrestaciones localidPrest;

        public frmABMPrestaciones()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            localidPrest = new CapaNegocioMepryl.LocalidadesYPrestaciones();
            panelEdicion.Visible = false;
            cboTipoPrestacion.SelectedIndex = -1;
            cboTipoPrestacion.SelectedIndex = 1;
            llenarComboZonas();
        }

        private void cboTipoPrestacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPrestacion.SelectedIndex != -1)
            {
                llenarDgv();
            }
        }

        private void llenarComboZonas()
        {
            cboZona.DataSource = localidPrest.cargarZonas();
            cboZona.ValueMember = "Id";
            cboZona.DisplayMember = "Descripcion";
            cboZona.SelectedIndex = -1;
        }

        private void llenarDgv()
        {
            dgv.DataSource = null;
            tbBusquedaPrestacion.Clear();
            dgv.DataSource = localidPrest.cargarLocalidadesYPrestaciones(obtenerItemSeleccionado(cboTipoPrestacion));
            dgv.Columns[0].Visible = false;
            dgv.Columns[2].Visible = false;
            dgv.Columns[4].Visible = false;
            dgv.Columns[5].Visible = false;
            if (cboTipoPrestacion.SelectedIndex == 1)
            {
                dgv.Columns[5].Visible = true;
            }
        }

        private string obtenerItemSeleccionado(ComboBox cbo)
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

        private void tbBusquedaPrestacion_TextChanged(object sender, EventArgs e)
        {
            filtrarLocalidadesYPrestaciones();
        }

        private void filtrarLocalidadesYPrestaciones()
        {
            if (cboTipoPrestacion.SelectedIndex != -1)
            {
                dgv.DataSource = localidPrest.cargarLocalidadesYPrestacionesFiltro(obtenerItemSeleccionado(cboTipoPrestacion), tbBusquedaPrestacion.Text);
                dgv.Columns[0].Visible = false;
                dgv.Columns[2].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[5].Visible = false;
                if (cboTipoPrestacion.SelectedIndex == 1)
                {
                    dgv.Columns[5].Visible = true;
                }
            }
        }

        private void botEditar_Click(object sender, EventArgs e)
        {
            modoEdicion();
        }

        private void modoEdicion()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                tbId.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();
                tbCodigo.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();
                cboTipoPrestacionEditar.SelectedIndex = cboTipoPrestacion.SelectedIndex;
                tbDescripcion.Text = dgv.SelectedRows[0].Cells[3].Value.ToString();
                if (aplicaZona())
                {
                    cboZona.SelectedValue = dgv.SelectedRows[0].Cells[4].Value.ToString();
                    if (dgv.SelectedRows[0].Cells[4].Value.ToString() == string.Empty)
                    {
                        cboZona.SelectedIndex = 0;
                    }
                }
                panelEdicion.Visible = true;
                panelPrincipal.Enabled = false;
            }
        }

        private bool aplicaZona()
        {
            cboZona.Visible = false;
            lblZona.Visible = false;
            if (obtenerItemSeleccionado(cboTipoPrestacion) == "V")
            {
                cboZona.Visible = true;
                lblZona.Visible = true;
                return true;
            }
            return false;
        }

        private void limpiarFormulario()
        {
            tbId.Clear();
            tbCodigo.Clear();
            tbDescripcion.Clear();
            cboZona.SelectedIndex = -1;
            cboTipoPrestacionEditar.SelectedIndex = 0;
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            modoConsulta();
        }

        private void modoConsulta()
        {
            limpiarFormulario();
            panelEdicion.Visible = false;
            panelPrincipal.Enabled = true;
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
                    resultado = localidPrest.guardarNueva(cargarDatosEntidad());
                    mensaje1 = "Guardar";
                    mensaje2 = "Guardada";
                }
                else
                {
                    resultado = localidPrest.editar(cargarDatosEntidad());
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

        private void evaluarResultado(Entidades.Resultado result, string mensaje1, string mensaje2)
        {
            if (result.Modo == 1)
            {
                modoConsulta();
                llenarDgv();
            }
            else
            {
                MessageBox.Show("¡Error al " + mensaje1 + " Localidad/Prestación!", mensaje1 + " Localidad/Prestación",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void eliminar()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Realmente desea eliminar la prestación/localidad seleccionada?",
                    "Eliminar Prestación/Localidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    eliminarLocalidadPrestacion(dgv.SelectedRows[0].Cells[0].Value.ToString(),
                        dgv.SelectedRows[0].Cells[2].Value.ToString());
                }
            }
        }

        private void eliminarLocalidadPrestacion(string id,string tipo)
        {
            if (verificarEliminar(id,tipo))
            {
                Entidades.Resultado result = localidPrest.eliminar(id);
                if (result.Modo == 1)
                {
                    MessageBox.Show("¡Localidad/Prestación eliminada correctamente!",
                        "Eliminar Localidad/Prestación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenarDgv();
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

        private Entidades.LocalidadPrestacion cargarDatosEntidad()
        {
            Entidades.LocalidadPrestacion retorno = new LocalidadPrestacion();
            if (tbId.Text != string.Empty) { retorno.Id = new Guid(tbId.Text); }
            retorno.Tipo = obtenerItemSeleccionado(cboTipoPrestacionEditar);
            retorno.Descripcion = tbDescripcion.Text;
            if (cboZona.SelectedIndex > 0) { retorno.Zona = Convert.ToInt16(cboZona.SelectedValue.ToString()); }
            return retorno;
        }

        private void botAgregar_Click(object sender, EventArgs e)
        {
            modoNuevo();
        }

        private void modoNuevo()
        {
            if (cboTipoPrestacion.SelectedIndex != -1)
            {
                limpiarFormulario();
                panelEdicion.Visible = true;
                panelPrincipal.Enabled = false;
                cboTipoPrestacionEditar.SelectedIndex = cboTipoPrestacion.SelectedIndex;
                aplicaZona();
            }
            else
            {
                MessageBox.Show("Agregar Localidad/Prestación", "¡Seleccione el tipo de Prestación que desea agregar!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool verificarEliminar(string id, string tipo)
        {
            return localidPrest.verificarEliminar(id, tipo);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
    }
}
