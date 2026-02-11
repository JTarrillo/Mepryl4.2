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

namespace CapaPresentacion
{
    public partial class frmListaPrecioTomaBase : Form
    {
        private CapaNegocioMepryl.ListaPrecios listaPrecios;
        public string strCodigo = "";
        public string strVariacion = "";
        public string strNombreLista = "";

        public frmListaPrecioTomaBase()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            listaPrecios = new CapaNegocioMepryl.ListaPrecios();
            CargarDGV();
            txtBuscar.Select();
        }

        private void CargarDGV()
        {
            dgv.DataSource = null;
            txtBuscar.Text = "";
            dgv.DataSource = listaPrecios.ListarNombreListaPrecios();
            dgv.Columns[0].Visible = false;
            
            dgv.Columns[1].HeaderText = "Lista de precios";
            dgv.Columns[1].Width = 350;            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgv.DataSource = listaPrecios.ListarNombreListaPrecios(txtBuscar.Text);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            strCodigo = dgv.CurrentRow.Cells[0].Value.ToString();
            strNombreLista = dgv.CurrentRow.Cells[1].Value.ToString();
            strVariacion = txtVariacion.Text;
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtVariacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                    e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
            e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
