using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacionBase;
using CapaNegocioMepryl;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmTransferenciaLegajos : Form
    {
        string test;
        private string busqueda = string.Empty;
        private CapaNegocioMepryl.PacienteLaboral pacienteLaboral;

        public frmTransferenciaLegajos()
        {
            InitializeComponent();
            pacienteLaboral = new PacienteLaboral();
            panelBusqueda.Visible = false;
            tbEmpresaDesde.Text = "Presione F1 para buscar";
            tbEmpresaDesde.ForeColor = Color.Gray;
            tbEmpresaA.Text = "Presione F1 para buscar";
            tbEmpresaA.ForeColor = Color.Gray;
            tbPaciente.Text = "Presione F1 para buscar";
            tbPaciente.ForeColor = Color.Gray;
        }

        private void tbEmpresaDesde_Leave(object sender, EventArgs e)
        {
            if (tbEmpresaDesde.Text == "")
            {
                tbEmpresaDesde.Text = "Presione F1 para buscar";
                tbEmpresaDesde.ForeColor = Color.Gray;
            }
        }

        private void tbPaciente_Leave(object sender, EventArgs e)
        {
            if (tbPaciente.Text == "")
            {
                tbPaciente.Text = "Presione F1 para buscar";
                tbPaciente.ForeColor = Color.Gray;
            }
        }

        private void tbEmpresaA_Leave(object sender, EventArgs e)
        {
            if (tbEmpresaA.Text == "")
            {
                tbEmpresaA.Text = "Presione F1 para buscar";
                tbEmpresaA.ForeColor = Color.Gray;
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
            busqueda = "E";
            llenarDgv();
        }

        private void llenarDgv()
        {
            test = busqueda;
            test = tbBusqueda.Text;
            test = tbIdEmpresaDesde.Text;
            test = tbIdEmpresaDesde.Text;
            dgvBusqueda.DataSource = pacienteLaboral.cargarDataGridBusqueda(busqueda, tbBusqueda.Text, tbIdEmpresaDesde.Text);
            dgvBusqueda.Columns[0].Visible = false;
            lblPacienteNoEncontrado.Visible = false;
            botAltaPaciente.Visible = false;
            if (busqueda == "P")
            {
                botAltaPaciente.Visible = true;
                if (dgvBusqueda.Rows.Count == 0)
                {
                    lblPacienteNoEncontrado.Visible = true;
                }
            }
        }

        private void tbEmpresaDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                modoBusqueda();
                busquedaEmpresa();

            }
            else if (e.KeyCode == Keys.Enter && tbIdEmpresaDesde.Text != string.Empty)
            {
                tbPaciente.Focus();
                SendKeys.Send("{F1}");
            }
        }

        private void tbPaciente_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tbEmpresaA_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // GRV - Ramírez - El sistema se cuelga al llamar a este metodo
            SendKeys.Send("{ENTER}");
            //KeyEventArgs ee = new KeyEventArgs(Keys.Enter);            
            //dgvBusqueda_KeyDown(sender, ee);
        }

        private void dgvBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void cargarDatosEmpresa()
        {
            tbIdEmpresa.Text = dgvBusqueda.SelectedRows[0].Cells[0].Value.ToString();
            tbEmpresa.Text = dgvBusqueda.SelectedRows[0].Cells[1].Value.ToString() + "  |  " +
            dgvBusqueda.SelectedRows[0].Cells[2].Value.ToString();
            modoInicio();
            tbIdPaciente.Clear();
            tbPaciente.Clear();
            tbPaciente.Focus();
            limpiarFicha();
        }

        private void setearDatosPaciente()
        {
            tbIdPaciente.Text = dgvBusqueda.SelectedRows[0].Cells[0].Value.ToString();
            tbPaciente.Text = dgvBusqueda.SelectedRows[0].Cells[1].Value.ToString() +
                " | " + dgvBusqueda.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void dgvBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (dgvBusqueda.Rows.Count > 0 && e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (busqueda == "E")
                {
                    cargarDatosEmpresa();
                }
                else
                {
                    setearDatosPaciente();
                    cargarDatosPaciente();
                }
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                modoInicio();
                if (busqueda == "P")
                {
                    tbPaciente.Focus();
                    tbPaciente.Select();
                }
                else
                {
                    tbEmpresa.Focus();
                    tbEmpresa.Select();
                }
            }
        }
    }
}
