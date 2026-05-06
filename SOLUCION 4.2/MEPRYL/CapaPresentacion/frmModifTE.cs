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
            // Solo hijos activos (Padre=0), no eliminados
            dt = SQLConnector.obtenerTablaSegunConsultaString(@"
                SELECT e.id, e.descripcion, e.codigo,
                       p.descripcion AS descripcionPadre
                FROM dbo.Especialidad e
                LEFT JOIN dbo.Especialidad p ON e.IdPadre = p.id
                WHERE e.Padre = 0
                  AND e.estado = 1
                  AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
                ORDER BY p.descripcion, CASE WHEN ISNUMERIC(e.codigo) = 1 THEN CONVERT(int, e.codigo) ELSE 999999 END");
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
