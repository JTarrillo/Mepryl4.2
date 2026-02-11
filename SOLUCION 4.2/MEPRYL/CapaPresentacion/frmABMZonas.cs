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
    public partial class frmABMZonas : Form
    {
        private CapaNegocioMepryl.LocalidadesYPrestaciones localidades;
        public frmABMZonas()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            localidades = new CapaNegocioMepryl.LocalidadesYPrestaciones();
            llenarDgv();
            modoConsulta();
        }

        private void llenarDgv()
        {
            dgv.DataSource = localidades.cargarZonasSinNoAplica();
            dgv.Columns[0].Visible = false;
        }

        private void modoConsulta()
        {
            panelPrincipal.Visible = true;
            panelPrincipal.Enabled = true;
            panelEdicion.Visible = false;
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
            if (localidades.verificarZonaAsignada(dgv.SelectedRows[0].Cells[0].Value.ToString()))
            {
                Entidades.Resultado result = localidades.eliminarZona(dgv.SelectedRows[0].Cells[0].Value.ToString());
                if (result.Modo == -1)
                {
                    MessageBox.Show("¡La zona seleccionada no puede ser eliminada!", "Eliminar Zona",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                llenarDgv();
            }
            else
            {
                MessageBox.Show("¡La zona asignada no puede ser eliminada porque ya se encuentra asignada!", "Eliminar Zona",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            if (tbDescripcion.Text.Length > 0)
            {
                Entidades.Resultado resultado;
                string mensaje1;
                string mensaje2;
                if (tbId.Text == string.Empty)
                {
                    resultado = localidades.guardarZona(tbDescripcion.Text);
                    mensaje1 = "Guardar";
                    mensaje2 = "Guardada";
                }
                else
                {
                    resultado = localidades.editarZona(tbId.Text,tbDescripcion.Text);
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
                limpiarFormulario();
                llenarDgv();
            }
            else
            {
                MessageBox.Show("¡Error al " + mensaje1 + " Zona!", mensaje1 + " Zona",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
