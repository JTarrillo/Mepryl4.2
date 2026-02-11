using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmABMNacionalidades : Form
    {
        private CapaNegocioMepryl.Nacionalidades nacionalidades;

        public frmABMNacionalidades()
        {
            InitializeComponent();
            inicializar();
        }

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

    }
}
