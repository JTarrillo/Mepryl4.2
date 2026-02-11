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
    public partial class frmBusquedaEmpresa : Form
    {
        private CapaNegocioMepryl.Empresa empresa;

        public frmBusquedaEmpresa()
        {
            InitializeComponent();
            empresa = new CapaNegocioMepryl.Empresa();
            cboFiltro.SelectedIndex = 0;
            cargarListado();
        }

        private void botVerDatos_Click(object sender, EventArgs e)
        {
            modoConsulta();
        }

        private void cargarListado()
        {
            dgv.DataSource = empresa.cargarEmpresas();
            dgv.Columns[0].Visible = false;
        }

        private frmEmpresa crearFormulario()
        {
            frmEmpresa frm = new frmEmpresa(this);
            Utilidades.abrirFormulario(this.MdiParent, frm, new Configuracion());
            return frm;
        }

        private void modoConsulta()
        {
            if (dgv.Rows.Count > 0 && dgv.SelectedCells != null)
            {
                frmEmpresa frm = crearFormulario();
                frm.modoConsulta(dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[0].Value);
            }
    
        }

        public void actualizarListado()
        {
            cargarListado();
        }

        private void botAgregar_Click(object sender, EventArgs e)
        {
            nuevaEmpresa();
        }

        private void nuevaEmpresa()
        {
            frmEmpresa frm = crearFormulario();
            frm.modoNuevo();
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            editarEmpresa();
        }

        private void editarEmpresa()
        {
            if (dgv.Rows.Count > 0 && dgv.SelectedCells != null)
            {
                frmEmpresa frm = crearFormulario();
                frm.modoEdicion(dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[0].Value);
            }
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que quiere eliminar a una empresa? Esta acción podría causar pérdida de información en los turnos y/o exámenes",
            "Eliminar Empresa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                eliminarEmpresa();
            }
        }


        private void eliminarEmpresa()
        {
            if (dgv.Rows.Count > 0 && dgv.SelectedCells != null)
            {
                if(!empresa.tieneExamenesRealizados(dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[0].Value))
                {
                     Entidades.Resultado result = empresa.eliminarEmpresa(dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[0].Value);
                     if (result.Modo == 1)
                     {
                         MessageBox.Show("¡Empresa eliminada correctamente!", "Eliminar Empresa",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     else
                     {
                         MessageBox.Show("No se eliminó a la empresa correctamente.\nError: " + result.Mensaje, "Eliminar Empresa",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                     actualizarListado();
                }
                else
                {
                    MessageBox.Show("¡No se puede eliminar la empresa, tiene examenes realizados a partir del 01-12-2015!",
                        "Eliminar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                modoConsulta();
            }
        }

        private void botFiltrar_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        private void filtrar()
        {
            if (tbFiltro.Text.Length > 0 && cboFiltro.SelectedIndex != -1)
            {
                dgv.DataSource = empresa.cargarEmpresasConFiltro(obtenerFiltroSeleccionado(),tbFiltro.Text);
                dgv.Columns[0].Visible = false;
            }
        }

        private string obtenerFiltroSeleccionado()
        {
            if (cboFiltro.SelectedIndex == 0) { return "razonSocial"; }
            if (cboFiltro.SelectedIndex == 1) { return "tipoDeDocumento"; }
            if (cboFiltro.SelectedIndex == 2) { return "cuit"; }
            if (cboFiltro.SelectedIndex == 3) { return "tipoDeContribuyente"; }
            if (cboFiltro.SelectedIndex == 4) { return "categoria"; }
            return "";
        }

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFiltro();
        }

        private void limpiarFiltro()
        {
            cboFiltro.SelectedIndex = 0;
            // tbFiltro.Clear(); 
            tbFiltro.Items.Clear();  // GRV - Ramírez - se remplazo el textbox por un combobox
            cargarListado();
        }

        private void tbFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                filtrar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //DialogResult rpta = MessageBox.Show("Desea cerrar la ventana Empresas Asociadas", "Empresas Asociadas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (rpta == DialogResult.Yes)
            //{
                this.Close();
            //}
        }

        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOpcionesFiltro(cboFiltro.Text);            
        }

        private void CargarOpcionesFiltro(string strOpcion)
        {
            switch (strOpcion)
            {
                case "Categoria":
                    tbFiltro.Items.Clear();                    
                    //
                    tbFiltro.Items.Add("LABORAL");
                    tbFiltro.Items.Add("PREVENTIVA");
                    tbFiltro.SelectedIndex = 0;
                    tbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;                    
                    tbFiltro.Focus();
                    break;
                case "Tipo Contribuyente":
                    tbFiltro.Items.Clear();                    
                    //
                    tbFiltro.Items.Add("RESPONSABLE INSCRIPTO");
                    tbFiltro.Items.Add("EXENTO");
                    tbFiltro.Items.Add("CONSUMIDOR FINAL");
                    tbFiltro.Items.Add("MONOTRIBUTISTA");
                    tbFiltro.Items.Add("NO ALCANZADO");
                    tbFiltro.SelectedIndex = 0;
                    tbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
                    tbFiltro.Focus();
                    break;
                case "Tipo Documento":
                    tbFiltro.Items.Clear();                    
                    //
                    tbFiltro.Items.Add("CUIT");
                    tbFiltro.Items.Add("CUIL");
                    tbFiltro.Items.Add("DNI");
                    tbFiltro.SelectedIndex = 0;
                    tbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
                    tbFiltro.Focus();
                    break;
                default:
                    tbFiltro.Items.Clear();
                    tbFiltro.DropDownStyle = ComboBoxStyle.DropDown;
                    tbFiltro.Focus();
                    break;
            }
        }

        private void tbFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                botFiltrar.PerformClick();
            }
        }
    }
}
