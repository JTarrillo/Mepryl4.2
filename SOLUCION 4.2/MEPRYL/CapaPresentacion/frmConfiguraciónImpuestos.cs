using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comunes;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmConfiguraciónImpuestos : DevExpress.XtraEditors.XtraForm
    {
        private CapaNegocioMepryl.Empresa empresa;
        private bool blnModificar = false;

        public frmConfiguraciónImpuestos()
        {
            InitializeComponent();
            empresa = new CapaNegocioMepryl.Empresa();
            CargarDGV();
        }

        public frmConfiguraciónImpuestos(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            empresa = new CapaNegocioMepryl.Empresa();
            this.WindowState = FormWindowState.Maximized;
            CargarDGV();
        }

        private void CargarDGV()
        {
            dgv.DataSource = empresa.listarImpuestos();

            if (dgv.Rows.Count > 0)
            {
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Visible = true;
                dgv.Columns[2].Visible = true;
                dgv.Columns[1].Width = 250;
                dgv.Columns[2].Width = 60;
            }
        }

        private void botAgregar_Click(object sender, EventArgs e)
        {
            dgv.Enabled = false;
            botAgregar.Visible = false;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            botEliminar.Visible = false;

            txtNombre.Enabled = true;
            txtValor.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNombre.Text))
            {
                return;
            }

            if (string.IsNullOrEmpty(txtValor.Text))
            {
                return;
            }

            if (blnModificar)
            {
                empresa.ActualizarIVA(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString(), txtNombre.Text, txtValor.Text);
            }
            else
            {
                empresa.InsertarIVA(txtNombre.Text, txtValor.Text);
            }           

            dgv.Enabled = true;
            botAgregar.Visible = true;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            botEliminar.Visible = true;
            CargarDGV();

            txtNombre.Enabled = false;
            txtValor.Enabled = false;

            txtNombre.Text = "";
            txtValor.Text = "";

            blnModificar = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgv.Enabled = true;
            botAgregar.Visible = true;
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            botEliminar.Visible = true;

            txtNombre.Enabled = false;
            txtValor.Enabled = false;
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            blnModificar = true;

            dgv.Enabled = false;
            botAgregar.Visible = false;
            botEliminar.Visible = false;
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;            

            if(dgv.Rows.Count > 0)
            {
                txtNombre.Text = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value.ToString();
                txtValor.Text = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value.ToString();
            }

            txtNombre.Enabled = true;
            txtValor.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
