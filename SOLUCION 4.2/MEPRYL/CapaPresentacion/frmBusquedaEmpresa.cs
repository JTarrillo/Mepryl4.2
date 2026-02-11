using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmBusquedaEmpresa : DevExpress.XtraEditors.XtraForm
    {
        private CapaNegocioMepryl.Empresa empresa;

        public frmBusquedaEmpresa()
        {
            InitializeComponent();
            empresa = new CapaNegocioMepryl.Empresa();
            cboFiltro.SelectedIndex = 0;
            cargarListado();
            dgv01.Select();
        }

        public frmBusquedaEmpresa(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            empresa = new CapaNegocioMepryl.Empresa();
            cboFiltro.SelectedIndex = 0;
            cargarListado();
            dgv01.Select();
        }

        private void botVerDatos_Click(object sender, EventArgs e)
        {
            //modoConsulta();
            if (dgv01.Rows.Count > 0 && dgv01.SelectedCells != null)
            {
                frmEmpresa frm = new frmEmpresa(this);
                frm.modoConsulta(dgv01.Rows[dgv01.SelectedCells[0].RowIndex].Cells[0].Value);
                frm.ShowDialog();
            }
        }

        private void cargarListado()
        {
            DataTable tabla = empresa.cargarEmpresas();
            tabla.Columns.Add("Factura a", typeof(string));
            tabla.Columns.Add("Abonado", typeof(Boolean));
            foreach (DataRow dr in tabla.Rows)
            {
                if (EsAbonada(dr[0].ToString()))
                {
                    dr[tabla.Columns.Count - 1] = true;
                }
                if (dr[9].ToString() == "CASA MATRIZ")
                {
                    dr[10] = dr[1];
                }
                if (dr[9].ToString() == "SUCURSAL")
                {
                    int exp = ExisteEnLaTablaSucursales(dr[0].ToString());
                    if (exp == 1)
                    {
                        DataTable tablaFacturacion = obtenerCasaMatriz(dr[0].ToString());
                        if (tablaFacturacion.Rows.Count > 0)
                        {
                            dr[10] = tablaFacturacion.Rows[0][0];
                        }
                    }
                    else if (exp == 2)
                    {
                        dr[10] = dr[1];
                    }
                    else
                    {
                        dr[10] = "No definido";
                    }
                }
            }
            dgv01.DataSource = tabla;
            dgv01.Columns["Abonado"].ReadOnly = true;
            dgv01.Columns["Abonado"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgv01.Columns[0].Visible = false;
            dgv01.Columns[9].Visible = false;
            dgv01.Columns[1].Width = 300;
        }

        private bool EsAbonada(string idEmpresa)
        {
            bool a = false;
            if (SQLConnector.obtenerTablaSegunConsultaString("Select tipoContrato FROM [MEPRYLv2.1].[dbo].[Empresa] where id = '" + idEmpresa +"'").Rows[0][0].ToString().ToLower() == "abonada")
            {
                a = true;
            }
            return a;
        }

        private DataTable obtenerCasaMatriz(string idSucursal)
        {
            DataTable retorno;
            DataTable idCasaMatriz = SQLConnector.obtenerTablaSegunConsultaString("select idCasaMatriz from dbo.SucursalesPorCasaMatriz where idSucursal = '" + idSucursal + "'");
            if (idCasaMatriz.Rows.Count > 0)
            {
                retorno = SQLConnector.obtenerTablaSegunConsultaString("select razonSocial from dbo.Empresa where id = '" + idCasaMatriz.Rows[0][0].ToString() + "'");
            }
            else
            {
                retorno = null;
            }
            return retorno;
        }

        private int ExisteEnLaTablaSucursales(string id)
        {
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.SucursalesPorCasaMatriz where FacturaCasaMatriz = '1' and idSucursal = '" + id +"'");
            DataTable dt1 = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.SucursalesPorCasaMatriz where FacturaCasaMatriz = '0' and idSucursal = '" + id + "'");
            if (dt.Rows.Count > 0 && dt1.Rows.Count == 0)
            {
                return 1; //Factura a la casa matriz
            }
            else if (dt1.Rows.Count > 0 && dt.Rows.Count == 0)
            {
                return 2; //Factura a la sucursal
            }
            else
            {
                return 3; //No existe
            }
        }

        private frmEmpresa crearFormulario()
        {
            frmEmpresa frm = new frmEmpresa(this);
            Utilidades.abrirFormulario(this.MdiParent, frm, new Configuracion());
            return frm;
        }

        private void modoConsulta()
        {
            if (dgv01.Rows.Count > 0 && dgv01.SelectedCells != null)
            {
                frmEmpresa frm = crearFormulario();
                frm.modoConsulta(dgv01.Rows[dgv01.SelectedCells[0].RowIndex].Cells[0].Value);
            }    
        }

        public void actualizarListado()
        {
            cargarListado();
        }

        private void botAgregar_Click(object sender, EventArgs e)
        {
            //nuevaEmpresa();
            frmEmpresa frm = new frmEmpresa(this);
            frm.modoNuevo();
            frm.ShowDialog();
        }

        private void nuevaEmpresa()
        {
            frmEmpresa frm = crearFormulario();
            frm.modoNuevo();
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            //editarEmpresa();
            int index = dgv01.SelectedCells[0].RowIndex;
            if (dgv01.Rows.Count > 0 && dgv01.SelectedCells != null)
            {
                frmEmpresa frm = new frmEmpresa(this);
                frm.modoEdicion(dgv01.Rows[dgv01.SelectedCells[0].RowIndex].Cells[0].Value);
                frm.ShowDialog();
                dgv01.Rows[index].Selected = true;
                dgv01.FirstDisplayedScrollingRowIndex = index;
            }
        }

        private void editarEmpresa()
        {
            if (dgv01.Rows.Count > 0 && dgv01.SelectedCells != null)
            {
                frmEmpresa frm = crearFormulario();
                frm.modoEdicion(dgv01.Rows[dgv01.SelectedCells[0].RowIndex].Cells[0].Value);
            }
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            int index = dgv01.SelectedCells[0].RowIndex;
            DialogResult result = MessageBox.Show("¿Está seguro que quiere eliminar a una empresa? Esta acción podría causar pérdida de información en los turnos y/o exámenes",
            "Eliminar Empresa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                eliminarEmpresa();
                dgv01.ClearSelection();
                dgv01.Rows[index].Selected = true;
                dgv01.FirstDisplayedScrollingRowIndex = index;
            }
        }


        private void eliminarEmpresa()
        {
            if (dgv01.Rows.Count > 0 && dgv01.SelectedCells != null)
            {
                if(!empresa.tieneExamenesRealizados(dgv01.Rows[dgv01.SelectedCells[0].RowIndex].Cells[0].Value))
                {
                     Entidades.Resultado result = empresa.eliminarEmpresa(dgv01.Rows[dgv01.SelectedCells[0].RowIndex].Cells[0].Value);
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

        private void dgv01_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                dgv01.DataSource = empresa.cargarEmpresasConFiltro(obtenerFiltroSeleccionado(),tbFiltro.Text);
                dgv01.Columns[0].Visible = false;
                dgv01.Columns[1].Width = 300;
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

        private void bbiAgregarEmpresa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botAgregar_Click(sender, e);
        }

        private void bbiModificarEmpresa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botModificar_Click(sender, e);
        }

        private void bbiEliminarEmpresa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botEliminar_Click(sender, e);
        }

        private void bbiVerDatos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botVerDatos_Click(sender, e);
        }

        private void bbiImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void frmBusquedaEmpresa_Load(object sender, EventArgs e)
        {
            rbcMenu.Minimized = true;
        }
    }
}
