using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocioMepryl;
using Comunes;
using System.IO;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmTransferenciaDeLegajos : Form
    {
        private string test = string.Empty;
        private string busqueda = string.Empty;
        private string TipoEmpresa = string.Empty;
        private CapaNegocioMepryl.PacienteLaboral pacienteLaboral;

        public frmTransferenciaDeLegajos()
        {
            InitializeComponent();
            pacienteLaboral = new PacienteLaboral();
            ModoInicio();
        }
        public void ModoInicio()
        {
            btnTransferir.Enabled = false;
            dgvBusquedaGeneral.Visible = false;
            tbBusqueda.Visible = false;
            lblIdEmpresaDesde.Visible = false;
            lblIdPaciente.Visible = false;
            lblIdEmpresaA.Visible = false;
            tbEmpresaDesde.Text = "Presione F1 para buscar";
            tbEmpresaDesde.ForeColor = Color.Gray;
            tbPaciente.Text = "Presione F1 para buscar";
            tbPaciente.ForeColor = Color.Gray;
            tbEmpresaA.Text = "Presione F1 para buscar";
            tbEmpresaA.ForeColor = Color.Gray;
        }

        private void modoBusqueda()
        {
            dgvBusquedaGeneral.Visible = true;
            tbBusqueda.Visible = true;
            tbEmpresaDesde.Enabled = false;
            tbEmpresaA.Enabled = false;
            tbPaciente.Enabled = false;
            dgvBusquedaGeneral.Focus();
        }

        private void tbEmpresaDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                tbPaciente.Clear();
                TipoEmpresa = "D";
                modoBusqueda();
                BuscarEmpresas();
                dgvBusquedaGeneral.Rows[0].Selected = true;
            }
        }

        private void BuscarEmpresas()
        {
            busqueda = "E";
            llenarDGV();
        }

        private void BuscarPacientes()
        {
            busqueda = "P";
            llenarDGV();
        }

        private void llenarDGV()
        {
            dgvBusquedaGeneral.DataSource = pacienteLaboral.cargarDataGridBusqueda(busqueda, tbBusqueda.Text, lblIdEmpresaDesde.Text);
            dgvBusquedaGeneral.RowHeadersVisible = false;
            dgvBusquedaGeneral.Columns[0].Visible = false;
            dgvBusquedaGeneral.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBusquedaGeneral.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBusquedaGeneral.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            llenarDGV();
        }

        private void dgvBusquedaGeneral_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void cargarDatosEmpresaDesde()
        {
            lblIdEmpresaDesde.Text = dgvBusquedaGeneral.SelectedRows[0].Cells[0].Value.ToString();
            tbEmpresaDesde.Text = dgvBusquedaGeneral.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void cargarDatosEmpresaA()
        {
            lblIdEmpresaA.Text = dgvBusquedaGeneral.CurrentRow.Cells[0].Value.ToString();
            tbEmpresaA.Text = dgvBusquedaGeneral.CurrentRow.Cells[2].Value.ToString();
        }

        private void cargarDatosPaciente()
        {
            lblIdPaciente.Text = dgvBusquedaGeneral.CurrentRow.Cells[0].Value.ToString();
            tbPaciente.Text = dgvBusquedaGeneral.CurrentRow.Cells[2].Value.ToString();
        }

        private void dgvBusquedaGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (dgvBusquedaGeneral.Rows.Count > 0 && e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (busqueda == "E")
                {
                    if (TipoEmpresa == "D")
                    {
                        cargarDatosEmpresaDesde();
                    }
                    else
                    {
                        cargarDatosEmpresaA();
                    }
                }
                else
                {
                    cargarDatosPaciente();
                }
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                ModoInicio();
                if (busqueda == "P")
                {
                    tbPaciente.Focus();
                    tbPaciente.Select();
                }
                else
                {
                    tbEmpresaDesde.Focus();
                    tbEmpresaDesde.Select();
                }
            }
            if (tbEmpresaA.Text == "" || tbEmpresaDesde.Text == "" || tbPaciente.Text == "")
            {
                btnTransferir.Enabled = false;
            }
            else
            {
                btnTransferir.Enabled = true;
            }
            tbEmpresaA.Enabled = true;
            tbEmpresaDesde.Enabled = true;
            tbPaciente.Enabled = true;
            dgvBusquedaGeneral.Visible = false;
            tbBusqueda.Visible = false;
            tbBusqueda.Clear();
        }

        private void dgvBusquedaGeneral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                selectUpRow();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                selectDownRow();
            }
            e.Handled = true;
        }

        private void selectUpRow()
        {
            DataGridView dgv = dgvBusquedaGeneral;
            int totalRows = dgv.Rows.Count;
            int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
            if (rowIndex == 0)
                return;
            DataGridViewRow selectedRow = dgv.Rows[rowIndex];
            dgv.ClearSelection();
            dgv.Rows[rowIndex - 1].Selected = true;
            dgvBusquedaGeneral.FirstDisplayedScrollingRowIndex = dgvBusquedaGeneral.SelectedCells[0].OwningRow.Index;
        }

        private void selectDownRow()
        {
            DataGridView dgv = dgvBusquedaGeneral;
            int totalRows = dgv.Rows.Count;
            int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
            if (rowIndex == totalRows - 1)
                return;
            DataGridViewRow selectedRow = dgv.Rows[rowIndex];
            dgv.ClearSelection();
            dgv.Rows[rowIndex + 1].Selected = true;
            dgvBusquedaGeneral.FirstDisplayedScrollingRowIndex = dgvBusquedaGeneral.SelectedCells[0].OwningRow.Index;
        }

        private void tbPaciente_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbEmpresaDesde.Text != "" && tbEmpresaDesde.Text != "Presione F1 para buscar")
            {
                if (e.KeyCode == Keys.F1)
                {
                    modoBusqueda();
                    BuscarPacientes();
                }
            }
            else
            {

                return;
            }
        }

        private void tbEmpresaA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                TipoEmpresa = "A";
                modoBusqueda();
                BuscarEmpresas();
            }
        }

        private void tbEmpresaDesde_Enter(object sender, EventArgs e)
        {
            if (tbEmpresaDesde.Text == "Presione F1 para buscar")
            {
                tbEmpresaDesde.Clear();
            }
        }

        private void tbPaciente_Enter(object sender, EventArgs e)
        {
            if (tbPaciente.Text == "Presione F1 para buscar")
            {
                tbPaciente.Clear();
            }
        }

        private void tbEmpresaA_Enter(object sender, EventArgs e)
        {

        }

        private void tbEmpresaDesde_Leave(object sender, EventArgs e)
        {
            if (tbEmpresaDesde.Text == "")
            {
                tbEmpresaDesde.Text = "Presione F1 para buscar";
            }
        }

        private void tbPaciente_Leave(object sender, EventArgs e)
        {
            if (tbPaciente.Text == "")
            {
                tbPaciente.Text = "Presione F1 para buscar";
            }
        }

        private void tbEmpresaA_Leave(object sender, EventArgs e)
        {
            if (tbEmpresaA.Text == "")
            {
                tbEmpresaA.Text = "Presione F1 para buscar";
            }
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            if (tbEmpresaA.Text != "" && tbEmpresaDesde.Text != "" && tbPaciente.Text != "")
            {
                Transferir();
                tbEmpresaDesde.Clear();
                tbEmpresaA.Clear();
                tbPaciente.Clear();
                MessageBox.Show("El paciente fue transferido exitosamente", "Transferencia de Legajos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Transferir()
        {
            SQLConnector.EjecutarConsulta(@"update dbo.EmpresasPorPaciente set idEmpresa = '" + lblIdEmpresaA.Text.ToString() + "' where idPaciente = '" + lblIdPaciente.Text.ToString() + "' and idEmpresa = '" + lblIdEmpresaDesde.Text.ToString() + "'");
        }

        private void tbBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dgvBusquedaGeneral_KeyPress(sender, e);
            }
        }
    }
}
