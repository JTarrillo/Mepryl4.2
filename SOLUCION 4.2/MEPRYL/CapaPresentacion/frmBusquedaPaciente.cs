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
    public partial class frmBusquedaPaciente : Form
    {
        private frmPaciente f;
        public frmBusquedaPaciente(frmPaciente frm)
        {
            InitializeComponent();
            f = frm;
        }

        private void cargarPacientes(string filtro)
        {
            DataTable table = SQLConnector.obtenerTablaSegunConsultaString(@"select TOP 200 p.id as Id, (p.apellido + ' ' + p.nombres)
            as Paciente, p.dni as DNI, CONVERT(date,fechaNacimiento) as Nacimiento, p.telefonos as Telefono, p.celular as Celular
            from dbo.Paciente p where (p.apellido + ' ' + p.nombres) != ''" + filtro);
            dgvBusqueda.DataSource = table;
            dgvBusqueda.Columns[0].Visible = false;
        }


        private void dgvBusqueda_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Close();
            f.recibirIdPaciente(dgvBusqueda.Rows[e.RowIndex].Cells[0].Value.ToString());

        }

        private void tbBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                filtrarPacientes();
            }
        }

        private void filtrarPacientes()
        {
            string filtro = "";
            if (tbBusqueda.Text != "")
            {
                filtro = " and (p.apellido + ' ' + p.nombres) like '%" + tbBusqueda.Text + "%'";
            }
            cargarPacientes(filtro);
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            filtrarPacientes();
        }

        private void frmBusquedaPaciente_Load(object sender, EventArgs e)
        {
            tbBusqueda.Select();
        }
    }
}
