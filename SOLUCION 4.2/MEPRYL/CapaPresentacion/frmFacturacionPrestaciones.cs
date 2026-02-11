using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CapaPresentacionBase;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmFacturacionPrestaciones : DevExpress.XtraEditors.XtraForm
    {
        private frmConsultorio frmConsultorio;
        private frmExamenLaboral ExamenLaboral;
        public string idEmpresa;
        public string idConsultaLaboral;
        string test;
        int prueba;
        private CapaNegocioMepryl.ListaPrecios listaPrecios;
        frmEmpresa frmEmp;

        public frmFacturacionPrestaciones()
        {
            InitializeComponent();
            inicializar();
        }

        public frmFacturacionPrestaciones(frmExamenLaboral frm, string _idEmpresa, string idConsLab)
        {
            idConsultaLaboral = idConsLab;
            idEmpresa = ObtenerIdEmpresa(idConsLab);
            InitializeComponent();
            inicializar();
            tbIdConsultaLaboral.Text = idConsultaLaboral;
        }

        public frmFacturacionPrestaciones(frmConsultorio frm, string _idEmpresa, string idConsLab)
        {
            idConsultaLaboral = idConsLab;
            idEmpresa = ObtenerIdEmpresa(idConsLab);
            InitializeComponent();
            inicializar();
            tbIdConsultaLaboral.Text = idConsultaLaboral;
        }

        public frmFacturacionPrestaciones(frmEmpresa frmEmp, frmConsultorio frm, string _idEmpresa)
        {
            frmConsultorio = frm;
            idEmpresa = _idEmpresa;
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            listaPrecios = new CapaNegocioMepryl.ListaPrecios();
            CargarComboBox();
            CargarFecha();
            //CargarListaPrecioBase(int.Parse(tbIdListaPrecios.Text.ToString()));
            CambiarVisibilidadEditar(EditaEnFact(idEmpresa));
            CargarElementosdgvListaPrecios();
            tbBusqueda.Text = "Escriba para buscar";
            tbBusqueda.ForeColor = Color.Gray;
            this.Activate();
        }

        private void CambiarVisibilidadEditar(bool estado)
        {
            cbEditar.Visible = estado;
        }

        private void CargarFecha()
        {
            DateTime FechaFact = DateTime.Now;
            DataTable dt = ObtenerFechaConsulta();
            DateTime fecha = Convert.ToDateTime(dt.Rows[0][0].ToString());
            int mes = Convert.ToInt32(fecha.Month.ToString());
            int ano = Convert.ToInt32(fecha.Year.ToString());
            if (mes != 12)
            {
                mes++;
                FechaFact = new DateTime(fecha.Year, mes, 01);
            }
            else
            {
                ano++;
                FechaFact = new DateTime(ano, 01, 01);
            }
            dtpFechaFact.Value = FechaFact;
        }

        private bool EditaEnFact(string idEmpresa)
        {
            cbEditar.Checked = false;
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString("select modifPrecioConFact from [MEPRYLv2.1].[dbo].[Empresa] where id = '" + idEmpresa + "'");
            if (dt.Rows[0][0].ToString() == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private DataTable ObtenerFechaConsulta()
        {
            DataTable retorno = SQLConnector.obtenerTablaSegunConsultaString("SELECT c.fecha from [MEPRYLv2.1].[dbo].[Consulta] c inner join [dbo].[TipoExamenDePaciente] tep on c.id = tep.idConsulta inner join [dbo].[ConsultaLaboral] cl on tep.id = cl.idTipoExamen where cl.id = '" + idConsultaLaboral + "'");
            return retorno;
        }

        private void CargarComboBox()
        {
            DataTable dt = listaPrecios.ObtenerListaPreciosDeEmpresa(idEmpresa);
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                tbIdListaPrecios.Text = dt.Rows[0][0].ToString();
                tbListaDePrecios.Text = dt.Rows[0][1].ToString();
            }
        }

        private string ObtenerIdEmpresa(string idConsultaLaboral)
        {
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString("SELECT ept.idEmpresa from [MEPRYLv2.1].[dbo].[empresaPorTipoDeExamen] ept inner join [MEPRYLv2.1].[dbo].[ConsultaLaboral] cl on ept.idTipoExamen = cl.idTipoExamen where cl.id = '" + idConsultaLaboral + "'");

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }

        private void CargarElementosdgvListaPrecios()
        {
            int Costo;
            int Fact;
            DataTable dt = null;
            DataTable dtElemento = null;
            string strCosto = "";
            string strFactu = "";

            string strSQL;
            strSQL = "SELECT lpb.id from[MEPRYLv2.1].[dbo].[ListaPreciosBase] lpb inner join[MEPRYLv2.1].[dbo].[ElementosListaPrecioPorConsultaLaboral] epc on lpb.id = epc.idElementoLista WHERE epc.idConsultaLaboral = '" + idConsultaLaboral + "'";
            dt = Comunes.SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dtElemento = listaPrecios.ObtenerElementoParaAgregar(int.Parse(dr[0].ToString()));
                    if (dtElemento.Rows.Count > 0)
                    {
                        foreach (DataRow dre in dtElemento.Rows)
                        {
                            dgvListaPrecios.Rows.Insert(0, dre[0].ToString(), dre[3].ToString(), dre[4].ToString(), dre[5].ToString(), dre[6].ToString(), dre[7].ToString(), Convert.ToString(double.Parse(dre[7].ToString()) - double.Parse(dre[6].ToString())));
                            foreach (DataGridViewRow dgvr in dgvListaPrecios.Rows)
                            {
                                dgvr.DefaultCellStyle.BackColor = Color.Gray;
                            }
                            ModificaTotalizadores();
                        }
                    }
                }
            }
        }

        private void CargarListaPrecioBase(int intIdNombreLista)
        {
            Double Costo, Fact;
            DataTable dt = null;
            string strCosto = "";
            string strFactu = "";

            if (intIdNombreLista > 0)
            {
                dgvListaPrecios.Rows.Clear();
                dgvExamenAptitud.Rows.Clear();
                dgvPrestaciones.Rows.Clear();
                dgvVisitas.Rows.Clear();

                dt = listaPrecios.ListarListaPreciosBase(intIdNombreLista);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strCosto = dt.Rows[i][6].ToString();
                        strFactu = dt.Rows[i][7].ToString();
                        double.TryParse(strFactu, out Fact);
                        double.TryParse(strCosto, out Costo);

                        if (dt.Rows[i][3].ToString() == "Examen Aptitud")
                        {
                            dgvExamenAptitud.Rows.Insert(0, dt.Rows[i][0].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), strCosto, strFactu, Convert.ToString(Fact - Costo));
                        }
                        else if (dt.Rows[i][3].ToString() == "Visitas")
                        {
                            dgvVisitas.Rows.Insert(0, dt.Rows[i][0].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), strCosto, strFactu, Convert.ToString(Fact - Costo));
                        }
                        else if (dt.Rows[i][3].ToString() == "Prestaciones")
                        {
                            dgvPrestaciones.Rows.Insert(0, dt.Rows[i][0].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), strCosto, strFactu, Convert.ToString(Fact - Costo));
                        }


                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tbIdListaPrecios.Text != "")
            {
                frmListaDePrecios frm = new frmListaDePrecios(tbIdListaPrecios.Text);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Asigne a la empresa una lista de precios antes de poder editarla");
            }
            actualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiaCampos()
        {
            dgvListaPrecios.Rows.Clear();
            tbListaDePrecios.Text = "";
        }

        private void frmFacturaPrestaciones_Activated(object sender, EventArgs e)
        {

        }

        private void actualizar()
        {
            dgvListaPrecios.Rows.Clear();
            tbListaDePrecios.Clear();
            tbTotalFacturacion.Text = "0";
            dgvListaPrecios.DataSource = null;
            CargarComboBox();
            CambiarVisibilidadEditar(EditaEnFact(idEmpresa));
            CargarElementosdgvListaPrecios();
            //CargarListaPrecioBase(int.Parse(tbIdListaPrecios.Text.ToString()));
        }

        private void btnEditarEmpresa_Click(object sender, EventArgs e)
        {
            frmEmp = new frmEmpresa(this, frmConsultorio, idEmpresa);
            frmEmp.StartPosition = FormStartPosition.CenterScreen;
            frmEmp.modoEdicion(idEmpresa);
            frmEmp.ShowDialog();
            actualizar();
        }

        private void tbListaDePrecios_TextChanged(object sender, EventArgs e)
        {
            CargarListaPrecioBase(int.Parse(tbIdListaPrecios.Text.ToString()));
        }

        private void dgvPrestaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cbEditar.Checked != true)
            {
                DataTable dt = listaPrecios.ObtenerElementoParaAgregar(int.Parse(dgvPrestaciones.SelectedRows[0].Cells[0].Value.ToString()));
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgvListaPrecios.Rows.Insert(0, dr[0].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), Convert.ToString(double.Parse(dr[7].ToString()) - double.Parse(dr[6].ToString())));
                        ModificaTotalizadores();
                    }
                    dgvListaPrecios.ClearSelection();
                    dgvListaPrecios.Rows[0].Selected = true;
                }
            }
            else
            {
                return;
            }
        }

        private void dgvExamenAptitud_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (cbEditar.Checked != true)
            {
                DataTable dt = listaPrecios.ObtenerElementoParaAgregar(int.Parse(dgvExamenAptitud.SelectedRows[0].Cells[0].Value.ToString()));
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgvListaPrecios.Rows.Insert(0, dr[0].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), Convert.ToString(double.Parse(dr[7].ToString()) - double.Parse(dr[6].ToString())));
                        ModificaTotalizadores();
                    }
                    dgvListaPrecios.ClearSelection();
                    dgvListaPrecios.Rows[0].Selected = true;
                }
            }
            else
            {
                return;
            }
        }

        private void dgvVisitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvListaPrecios.SelectedRows)
            {
                if (dgvr.DefaultCellStyle.BackColor == Color.Gray)
                {
                    DialogResult result = MessageBox.Show("LA PRESTACION \"" + dgvr.Cells[3].Value.ToString() + "\" YA HA SIDO FACTURADA. SEGURO DESEA ELIMINARLA?", "Eliminar Prestacion", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        dgvListaPrecios.Rows.RemoveAt(dgvr.Index);
                        ModificaTotalizadores();
                        dgvListaPrecios.ClearSelection();
                    }
                }
                if (dgvListaPrecios.Rows.Count > 0)
                {
                    dgvListaPrecios.Rows[0].Selected = true;
                }
            }
        }

        private void ModificaTotalizadores()
        {
            double CostoTotal = 0;
            double UtilidadTotal = 0;
            double FacturacionTotal = 0;

            for (int i = 0; i < dgvListaPrecios.Rows.Count; i++)
            {
                CostoTotal = CostoTotal + double.Parse(dgvListaPrecios.Rows[i].Cells[4].Value.ToString());
                FacturacionTotal = FacturacionTotal + double.Parse(dgvListaPrecios.Rows[i].Cells[5].Value.ToString());
                UtilidadTotal = UtilidadTotal + double.Parse(dgvListaPrecios.Rows[i].Cells[6].Value.ToString());
            }
            tbUtilidadTotal.Text = UtilidadTotal.ToString();
            tbTotalCosto.Text = CostoTotal.ToString();
            tbTotalFacturacion.Text = FacturacionTotal.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarElementosLista();
            GuardarFacturacion();
            MessageBox.Show("Los elementos fueron facturados exitosamente");
            this.Close();
        }

        private void GuardarFacturacion()
        {
            string strSQL = "Delete from [MEPRYLv2.1].[dbo].[ElementosListaPrecioPorConsultaLaboral] where idConsultaLaboral = '" + idConsultaLaboral + "'";
            Comunes.SQLConnector.EjecutarConsulta(strSQL);
            string idElementoLista;
            for (int i = 0; i < dgvListaPrecios.Rows.Count; i++)
            {
                idElementoLista = dgvListaPrecios.Rows[i].Cells[0].Value.ToString();
                strSQL = "INSERT INTO [MEPRYLv2.1].[dbo].[ElementosListaPrecioPorConsultaLaboral] (idConsultaLaboral, idElementoLista, fecha) VALUES ('" + idConsultaLaboral + "', '" + idElementoLista + "', '" + dtpFechaFact.Value + "')";
                Comunes.SQLConnector.EjecutarConsulta(strSQL);
            }
        }

        private void GuardarElementosLista()
        {
            foreach (DataGridViewRow dgvr in dgvExamenAptitud.Rows)
            {
                SQLConnector.obtenerTablaSegunConsultaString("UPDATE [MEPRYLv2.1].[dbo].[ListaPreciosBase] SET Costo = '" + dgvr.Cells[3].Value.ToString() + "', Factura = '" + dgvr.Cells[4].Value.ToString() + "' WHERE id = '" + dgvr.Cells[0].Value.ToString() + "'");
            }
            foreach (DataGridViewRow dgvr in dgvVisitas.Rows)
            {
                SQLConnector.obtenerTablaSegunConsultaString("UPDATE [MEPRYLv2.1].[dbo].[ListaPreciosBase] SET Costo = '" + dgvr.Cells[3].Value.ToString() + "', Factura = '" + dgvr.Cells[4].Value.ToString() + "' WHERE id = '" + dgvr.Cells[0].Value.ToString() + "'");
            }
            foreach (DataGridViewRow dgvr in dgvPrestaciones.Rows)
            {
                SQLConnector.obtenerTablaSegunConsultaString("UPDATE [MEPRYLv2.1].[dbo].[ListaPreciosBase] SET Costo = '" + dgvr.Cells[3].Value.ToString() + "', Factura = '" + dgvr.Cells[4].Value.ToString() + "' WHERE id = '" + dgvr.Cells[0].Value.ToString() + "'");
            }
        }

        private void chkOcultar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOcultar.Checked == true)
            {
                foreach (DataGridViewRow dgvr in dgvExamenAptitud.Rows)
                {
                    if (dgvr.Cells[5].Value.ToString() == "0")
                    {
                        dgvr.Visible = false;
                    }
                }
                foreach (DataGridViewRow dgvr in dgvPrestaciones.Rows)
                {
                    if (dgvr.Cells[5].Value.ToString() == "0")
                    {
                        dgvr.Visible = false;
                    }
                }
                foreach (DataGridViewRow dgvr in dgvVisitas.Rows)
                {
                    if (dgvr.Cells[5].Value.ToString() == "0")
                    {
                        dgvr.Visible = false;
                    }
                }
            }
            if (chkOcultar.Checked == false)
            {
                foreach (DataGridViewRow dgvr in dgvExamenAptitud.Rows)
                {
                    dgvr.Visible = true;
                }
                foreach (DataGridViewRow dgvr in dgvPrestaciones.Rows)
                {
                    dgvr.Visible = true;
                }
                foreach (DataGridViewRow dgvr in dgvVisitas.Rows)
                {
                    dgvr.Visible = true;
                }
            }
        }

        private void lbTitulo_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbEditar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEditar.Checked == true)
            {
                dgvExamenAptitud.ReadOnly = false;
                dgvPrestaciones.ReadOnly = false;
                dgvVisitas.ReadOnly = false;
            }
            else
            {
                GuardarElementosLista();
                dgvExamenAptitud.ReadOnly = true;
                dgvPrestaciones.ReadOnly = true;
                dgvVisitas.ReadOnly = true;
            }
        }

        private void dgvExamenAptitud_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            double costo, facturacion;
            if (dgvExamenAptitud.Rows.Count != 0)
            {
                Double.TryParse(dgvExamenAptitud.Rows[index].Cells[4].Value.ToString(), out facturacion);
                Double.TryParse(dgvExamenAptitud.Rows[index].Cells[3].Value.ToString(), out costo);
                dgvExamenAptitud.Rows[index].Cells[5].Value = Convert.ToString(facturacion - costo);
            }
        }

        private void dgvPrestaciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            Double costo, facturacion;
            if (dgvPrestaciones.Rows.Count != 0)
            {
                Double.TryParse(dgvPrestaciones.Rows[index].Cells[4].Value.ToString(), out facturacion);
                Double.TryParse(dgvPrestaciones.Rows[index].Cells[3].Value.ToString(), out costo);
                dgvPrestaciones.Rows[index].Cells[5].Value = Convert.ToString(facturacion - costo);
            }
        }

        private void dgvVisitas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            Double costo, facturacion;
            if (dgvVisitas.Rows.Count != 0)
            {
                Double.TryParse(dgvVisitas.Rows[index].Cells[4].Value.ToString(), out facturacion);
                Double.TryParse(dgvVisitas.Rows[index].Cells[3].Value.ToString(), out costo);
                dgvVisitas.Rows[index].Cells[5].Value = Convert.ToString(facturacion - costo);
            }
        }

        private void tbBusqueda_Enter(object sender, EventArgs e)
        {
            tbBusqueda.Text = "";
        }

        private void tbBusqueda_Leave(object sender, EventArgs e)
        {
            tbBusqueda.Text = "Escriba para buscar";
            tbBusqueda.ForeColor = Color.Gray;
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            BuscaElementosConFiltro(tbBusqueda.Text);
        }

        private void BuscaElementosConFiltro(string filtro)
        {
            string strCosto, strFactu;
            int Fact, Costo;
            if (tcElementosLista.SelectedTab == tpExAptitud)
            {
                if (tbBusqueda.Text != "Escriba para buscar")
                {
                    dgvExamenAptitud.Rows.Clear();
                    DataTable dt = SQLConnector.obtenerTablaSegunConsultaString("SELECT id, idNombreLista, NombrePrestacion, TipoPrestacion, Codigo, Descripcion, Costo, Factura from [MEPRYLv2.1].dbo.ListaPreciosBase WHERE idNombreLista = '" + tbIdListaPrecios.Text.ToString() + "' AND Descripcion LIKE '%" + filtro + "%' AND TipoPrestacion = 'Examen Aptitud'");
                    foreach (DataRow dr in dt.Rows)
                    {
                        strCosto = dr[6].ToString();
                        strFactu = dr[7].ToString();
                        int.TryParse(strFactu, out Fact);
                        int.TryParse(strCosto, out Costo);
                        dgvExamenAptitud.Rows.Insert(0, dr[0].ToString(), dr[4].ToString(), dr[5].ToString(), strCosto, strFactu, Convert.ToString(Fact - Costo));
                    }
                }
            }
            if (tcElementosLista.SelectedTab == tpVisitas)
            {
                if (tbBusqueda.Text != "Escriba para buscar")
                {
                    dgvVisitas.Rows.Clear();
                    DataTable dt = SQLConnector.obtenerTablaSegunConsultaString("SELECT id, idNombreLista, NombrePrestacion, TipoPrestacion, Codigo, Descripcion, Costo, Factura from [MEPRYLv2.1].dbo.ListaPreciosBase WHERE idNombreLista = '" + tbIdListaPrecios.Text + "' AND Descripcion LIKE '%" + filtro + "%' AND TipoPrestacion = 'Visitas'");
                    foreach (DataRow dr in dt.Rows)
                    {
                        strCosto = dr[6].ToString();
                        strFactu = dr[7].ToString();
                        int.TryParse(strFactu, out Fact);
                        int.TryParse(strCosto, out Costo);
                        dgvVisitas.Rows.Insert(0, dr[0].ToString(), dr[4].ToString(), dr[5].ToString(), strCosto, strFactu, Convert.ToString(Fact - Costo));
                    }
                }
            }
            if (tcElementosLista.SelectedTab == tpPrestaciones)
            {
                if (tbBusqueda.Text != "Escriba para buscar")
                {
                    dgvPrestaciones.Rows.Clear();
                    DataTable dt = SQLConnector.obtenerTablaSegunConsultaString("SELECT id, idNombreLista, NombrePrestacion, TipoPrestacion, Codigo, Descripcion, Costo, Factura from [MEPRYLv2.1].dbo.ListaPreciosBase WHERE idNombreLista = '" + tbIdListaPrecios.Text + "' AND Descripcion LIKE '%" + filtro + "%' AND TipoPrestacion = 'Prestaciones'");
                    foreach (DataRow dr in dt.Rows)
                    {
                        strCosto = dr[6].ToString();
                        strFactu = dr[7].ToString();
                        int.TryParse(strFactu, out Fact);
                        int.TryParse(strCosto, out Costo);
                        dgvPrestaciones.Rows.Insert(0, dr[0].ToString(), dr[4].ToString(), dr[5].ToString(), strCosto, strFactu, Convert.ToString(Fact - Costo));
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}