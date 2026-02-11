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
    public partial class frmModifTE : Form
    {
        frmMesaDeEntrada mesaEntrada;
        public frmModifTE(frmMesaDeEntrada frm)
        {
            InitializeComponent();
            mesaEntrada = frm;
        }

        private void frmModifTE_Load(object sender, EventArgs e)
        {
            llenarComboBox();
        }

        private void llenarComboBox()
        {
            DataTable dt = new DataTable();
            dt = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Especialidad order by convert(int,codigo) asc");
            cbTipoDeExamen.DataSource = dt;
            cbTipoDeExamen.ValueMember = "id";
            cbTipoDeExamen.DisplayMember = "descripcion";
            cbTipoDeExamen.SelectedIndex = -1;
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            if (cbTipoDeExamen.SelectedIndex != -1)
            {
                mesaEntrada.modificarTipoExamen(cbTipoDeExamen.SelectedValue.ToString());
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un tipo de exámen", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


    }
}
