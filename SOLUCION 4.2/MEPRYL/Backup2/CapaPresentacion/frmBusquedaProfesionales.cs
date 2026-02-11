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
    public partial class frmBusquedaProfesionales : Form
    {
        private CapaNegocioMepryl.Profesionales profesionales;
        private DataTable listado;

        public frmBusquedaProfesionales()
        {
            InitializeComponent();
            profesionales = new CapaNegocioMepryl.Profesionales();
            cargarListado();
        }

        private void cargarListado()
        {
            tbFiltro.Text = "";
            listado = profesionales.cargarProfesionales();
            dgv.DataSource = listado;
            dgv.Columns[0].Visible = false;
        }

        private void botVerDatos_Click(object sender, EventArgs e)
        {
            consultaProfesional();
        }

        private void consultaProfesional()
        {
            if (dgv.Rows.Count > 0 && dgv.SelectedCells != null)
            {
                frmProfesionales frm = crearFormulario();
                frm.modoConsulta(dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[0].Value);
            }
        }

        private frmProfesionales crearFormulario()
        {
            frmProfesionales frm = new frmProfesionales(this);
            Utilidades.abrirFormulario(this.MdiParent, frm, new Configuracion());
            return frm;
        }

        public void actualizarListado()
        {
            cargarListado();
        }

        private void botAgregar_Click(object sender, EventArgs e)
        {
            nuevoProfesional();
        }

        private void nuevoProfesional()
        {
            frmProfesionales frm = crearFormulario();
            frm.modoNuevo();
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            editarProfesional();
        }

        private void editarProfesional()
        {
            if (dgv.Rows.Count > 0 && dgv.SelectedCells != null)
            {
                frmProfesionales frm = crearFormulario();
                frm.modoEdicion(dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[0].Value);
            }
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que quiere eliminar a un médico? Esta acción podría causar pérdida de información en los turnos y/o exámenes",
                "Eliminar Profesional", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                eliminarProfesional();
            }
        }

        private void eliminarProfesional()
        {
            if (dgv.Rows.Count > 0 && dgv.SelectedCells != null)
            {
                Entidades.Resultado result = profesionales.eliminarProfesional(dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[0].Value);
                if (result.Modo == 1)
                {
                    MessageBox.Show("¡Médico eliminado correctamente!", "Eliminar Médico",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se eliminó al médico correctamente.\nError: " + result.Mensaje, "Eliminar Médico",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                actualizarListado();
            }
        }

        private void botFiltrar_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        private void filtrar()
        {
            if (tbFiltro.Text.Length > 0)
            {
                DataTable tablaAuxiliar = new DataTable();
                foreach (DataGridViewColumn c in dgv.Columns)
                {
                    tablaAuxiliar.Columns.Add(c.HeaderText);
                }
                dgv.DataSource = null;
                DataRow[] drColection = listado.Select("Médico like '%" + tbFiltro.Text + "%'");
                foreach (DataRow r in drColection)
                {
                    tablaAuxiliar.Rows.Add(r.ItemArray[0],r.ItemArray[1],r.ItemArray[2],
                        r.ItemArray[3],r.ItemArray[4],r.ItemArray[5]);
                }
                dgv.DataSource = tablaAuxiliar;
                dgv.Columns[0].Visible = false;
                if (dgv.Rows.Count > 0) { dgv.Rows[0].Cells[1].Selected = true; }
            }
            else
            {
                cargarListado();
            }
        }

        private void tbFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                filtrar();
            }
        }

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFiltro();
        }

        private void limpiarFiltro()
        {
            cargarListado();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                consultaProfesional();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
