using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmBusquedaCasaMatriz : Form
    {
        string test;
        frmEmpresa frmEmp;
        CapaNegocioMepryl.Empresa emp;

        public frmBusquedaCasaMatriz(frmEmpresa frm)
        {
            InitializeComponent();
            emp = new CapaNegocioMepryl.Empresa();
            frmEmp = frm;
            llenarCampos();
            llenarDGV();
        }

        private void llenarCampos()
        {
            lblIdSucursal.Text = frmEmp.DevuelveIdEmpresa();
            lblRazonSocial.Text = frmEmp.DevuelveNombreEmpresa();
        }

        private void llenarDGV()
        {
            dgvBusquedaGeneral.DataSource = Comunes.SQLConnector.obtenerTablaSegunConsultaString("select id, razonSocial from dbo.Empresa where tipoDeEntidad = 'CASA MATRIZ' and razonSocial LIKE '%" + tbBusqueda.Text.ToString() +"%' order by razonSocial");
            dgvBusquedaGeneral.RowHeadersVisible = false;
            dgvBusquedaGeneral.Columns[0].Visible = false;
            dgvBusquedaGeneral.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (dgvBusquedaGeneral.Rows.Count>0 && e.KeyChar == (char)Keys.Enter)
            {
                CargarDatosCasaMatriz();
            }
        }

        private void CargarDatosCasaMatriz()
        {
            lblIdCasaMatriz.Text = dgvBusquedaGeneral.SelectedRows[0].Cells[0].Value.ToString();
            lblCasaMatrizInfo.Text = dgvBusquedaGeneral.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
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

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            llenarDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblCasaMatrizInfo.Text != string.Empty && lblIdCasaMatriz.Text != string.Empty)
            {
                if (rbCasaMatriz.Checked || rbSucursal.Checked)
                {
                    guardarDatos();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Señale si factura a la sucursal o a la casa matriz");
                }
            }
            else
            {
                MessageBox.Show("Escoja la casa matriz");
            }
        }

        private void guardarDatos()
        {
            int FacturaCasaMatriz = 0;
            if (rbCasaMatriz.Checked && !rbSucursal.Checked)
            {
                FacturaCasaMatriz = 1;
            }
            else if (!rbCasaMatriz.Checked && rbSucursal.Checked)
            {
                FacturaCasaMatriz = 0;
            }
            DataTable dt = Comunes.SQLConnector.obtenerTablaSegunConsultaString("select * from [dbo].[SucursalesPorCasaMatriz] where idSucursal = '" + lblIdSucursal.Text.ToString() + "'");
            if (dt.Rows.Count == 0)
            {
                Comunes.SQLConnector.EjecutarConsulta("insert into [dbo].[SucursalesPorCasaMatriz] ([idSucursal],[idCasaMatriz],[FacturaCasaMatriz]) VALUES ('" + lblIdSucursal.Text.ToString() + "', '" + lblIdCasaMatriz.Text.ToString() + "', '" + FacturaCasaMatriz + "')");
                MessageBox.Show("Se creo una nueva relacion Sucursal - Casa Matriz entre " + lblCasaMatrizInfo.Text.ToString() + " y " + lblRazonSocial.Text.ToString());
            }
            else if (dt.Rows.Count > 0)
            {
                Comunes.SQLConnector.EjecutarConsulta("update [MEPRYLv2.1].[dbo].[SucursalesPorCasaMatriz] set idCasaMatriz = '" + lblIdCasaMatriz.Text.ToString() + "', FacturaCasaMatriz = '" + FacturaCasaMatriz + "'  where idSucursal = '" + lblIdSucursal.Text.ToString() +"'");
                MessageBox.Show("Se actualizo una relacion Sucursal - Casa Matriz entre " + lblCasaMatrizInfo.Text.ToString() + " y " + lblRazonSocial.Text.ToString());
            }
        }
    }
}
