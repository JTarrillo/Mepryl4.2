using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmBusquedaPacienteLaboral : Form
    {
        private CapaNegocioMepryl.PacienteLaboral paciente = new CapaNegocioMepryl.PacienteLaboral();
        private frmPacienteLaboral f;
        public frmBusquedaPacienteLaboral(frmPacienteLaboral frm)
        {
            InitializeComponent();
            f = frm;
            cargarPacientes();
        }

        private void cargarPacientes()
        {            
            dgvBusqueda.DataSource = paciente.BuscarPacienteLaboral(tbBusqueda.Text);
            if (dgvBusqueda.Rows.Count > 0)
            {
                dgvBusqueda.Columns[0].Visible = false;
                dgvBusqueda.Columns[1].Visible = false;
            }
        }

        private void dgvBusqueda_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string strIdEmpresa = dgvBusqueda.Rows[e.RowIndex].Cells[1].Value.ToString();
            string strIdPaciente = dgvBusqueda.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.Close();
            
            f.cargarPacienteEspecifico(strIdEmpresa, strIdPaciente);            
        }

        private void tbBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cargarPacientes();
                dgvBusqueda.Focus();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                tbBusqueda.Text = "";
                tbBusqueda.Focus();
            }
        }

        private void filtrarPacientes()
        {
            
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            //filtrarPacientes();
            cargarPacientes();
            dgvBusqueda.Focus();
        }

        private void dgvBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvBusqueda.Rows.Count > 0 && e.KeyChar == (char)Keys.Enter)
            {
                string strIdEmpresa = "";
                string strIdPaciente = "";

                if (dgvBusqueda.Rows.Count > 1)
                {
                    strIdEmpresa = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex - 1].Cells[1].Value.ToString();
                    strIdPaciente = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex - 1].Cells[0].Value.ToString();
                }
                else
                {
                    strIdEmpresa = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    strIdPaciente = dgvBusqueda.Rows[dgvBusqueda.CurrentCell.RowIndex].Cells[0].Value.ToString();
                }

                this.Close();

                f.cargarPacienteEspecifico(strIdEmpresa, strIdPaciente);
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                tbBusqueda.Text = "";
                tbBusqueda.Focus();
            }
        }

        private void frmBusquedaPacienteLaboral_Load(object sender, EventArgs e)
        {
            tbBusqueda.Select();
        }
    }
}
