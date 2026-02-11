using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocioMepryl;
using Entidades;

namespace CapaPresentacion
{
    public partial class frmCambioEmpresa : Form
    {
        private CapaNegocioMepryl.CambioEmpresa cambioEmpresa;
        private frmBusquedaLaboral frm;

        public frmCambioEmpresa(string idTipoExamen, frmBusquedaLaboral form)
        {
            InitializeComponent();
            inicializar(idTipoExamen);
            frm = form;
        }

        private void inicializar(string idTipoExamen)
        {
            cambioEmpresa = new CambioEmpresa();
            panelBusqueda.Visible = false;
            tbIdTipoExamen.Text = idTipoExamen;
            tbEmpresaActual.Text = cambioEmpresa.obtenerEmpresaActual(idTipoExamen);
            tbTareaActual.Text = cambioEmpresa.obtenerTareaActual(idTipoExamen);        
        }

        private void tbEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                modoBusqueda();
                tbBusqueda.Clear();
                busquedaEmpresa();
            }
            else if (e.KeyCode == Keys.F5)
            {
                guardar();
            }
            else if (e.KeyCode == Keys.F6)
            {
                cancelar();
            }
        }

        private void modoBusqueda()
        {
            panelBusqueda.Visible = true;
            tbBusqueda.Clear();
            tbBusqueda.Focus();
        }

        private void busquedaEmpresa()
        {
            dgvBusqueda.DataSource = cambioEmpresa.cargarEmpresas(tbBusqueda.Text);
            dgvBusqueda.Columns[0].Visible = false;
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            busquedaEmpresa();
        }

        private void tbBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgvBusqueda.Rows.Count == 1)
            {
                 cargarDatosEmpresa();
            }
            else if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down) && dgvBusqueda.Rows.Count > 1)
            {
                dgvBusqueda.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                tbEmpresa.Focus();
                panelBusqueda.Visible = false;
            }            
        }

        private void cargarDatosEmpresa()
        {
            tbIdEmpresa.Text = dgvBusqueda.SelectedRows[0].Cells[0].Value.ToString();
            tbEmpresa.Text = dgvBusqueda.SelectedRows[0].Cells[1].Value.ToString() + "  |  " +
                dgvBusqueda.SelectedRows[0].Cells[2].Value.ToString();
            panelBusqueda.Visible = false;
            tbEmpresa.Focus();
        }

        private void dgvBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void dgvBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvBusqueda.Rows.Count > 0 && e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                cargarDatosEmpresa();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                panelBusqueda.Visible = false;
                tbEmpresa.Focus();
            }
        }

        private void dgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SendKeys.Send("{ENTER}");
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
            guardar();
        }

        private void guardar()
        {
            if (tbIdEmpresa.Text != string.Empty)
            {
                Entidades.Resultado resultado = cambioEmpresa.guardarCambio(tbIdTipoExamen.Text, tbIdEmpresa.Text, tbTareaDesignada.Text);
                if (resultado.Modo == 1)
                {
                    this.Close();
                    frm.actualizar();
                }
                else
                {
                    MessageBox.Show("¡Error al guardar cambio de empresa!\nError: " + resultado.Mensaje, "Guardar Cambio Empresa",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("¡Seleccione una empresa para poder continuar!", "Seleccionar Empresa",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tbTareaDesignada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                guardar();
            }
            else if (e.KeyCode == Keys.F6)
            {
                cancelar();
            }
        }
    }
}
