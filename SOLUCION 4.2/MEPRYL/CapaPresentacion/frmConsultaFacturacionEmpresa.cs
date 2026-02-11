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
using Comunes;

namespace CapaPresentacion
{
    public partial class frmConsultaFacturacionEmpresa : DevExpress.XtraEditors.XtraForm
    {
        string test, FechaSinHora;
        DateTime fecha;
        Double Iva;
        string DiscriminaIva;
        public frmConsultaFacturacionEmpresa()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            rbInformeResumido.Checked = true;
            CargarEmpresas();
            cbEmpresaHasta.SelectedIndex = cbEmpresaHasta.Items.Count - 1;
        }

        private void CargarEmpresas()
        {
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString("SELECT id, razonSocial from [MEPRYLv2.1].[dbo].[Empresa] ORDER BY razonSocial");
            if (dt.Rows.Count > 0)
            {
                cbEmpresaDesde.DataSource = new DataView(dt); ;
                cbEmpresaDesde.ValueMember = "id";
                cbEmpresaDesde.DisplayMember = "razonSocial";

            }

            if (dt.Rows.Count > 0 )
            {
                cbEmpresaHasta.DataSource = new DataView(dt);
                cbEmpresaHasta.ValueMember = "id";
                cbEmpresaHasta.DisplayMember = "razonSocial";
            }
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            BuscaElementosFacturados();
        }

        private void BuscaElementosFacturados()
        {
            DataTable Busqueda, Agregar, AgregarFacturacion;
            string Valueinicial = cbEmpresaDesde.SelectedValue.ToString();
            List<string> listaEmpresas = new List<string>();

            Busqueda = new DataTable();

            Busqueda.Columns.Add("idFact");
            Busqueda.Columns.Add("idConsLab");
            Busqueda.Columns.Add("idEmpresa");
            Busqueda.Columns.Add("Paciente");
            Busqueda.Columns.Add("FechaAt");
            Busqueda.Columns.Add("FechaFact");
            Busqueda.Columns.Add("Codigo");
            Busqueda.Columns.Add("TipoPrest");
            Busqueda.Columns.Add("Descripcion");
            Busqueda.Columns.Add("Precio");

            for (int i = cbEmpresaDesde.SelectedIndex; i < cbEmpresaHasta.SelectedIndex+1; i++)
            {
                cbEmpresaDesde.SelectedIndex = i;
                listaEmpresas.Add(cbEmpresaDesde.SelectedValue.ToString());
            }

            cbEmpresaDesde.SelectedValue = Valueinicial;
            Agregar = new DataTable();

            if (dtpFechaFactDesde.Visible)
            {
                foreach (string value in listaEmpresas)
                {
                    test = dtpFechaFactDesde.Value.ToShortDateString();
                    test = dtpFechaFactHasta.Value.ToShortDateString();
                    test = dtpFechaFactHasta.Value.ToShortDateString();
                    Agregar = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT fact.id, cl.id, e.id, CONCAT(pl.apellido, ', ', pl.nombres), c.fecha, fact.fecha, lpb.Codigo, lpb.TipoPrestacion, lpb.Descripcion,lpb.Factura
                    FROM [MEPRYLv2.1].dbo.ElementosListaPrecioPorConsultaLaboral fact
                    inner join [MEPRYLv2.1].dbo.ConsultaLaboral cl on fact.idConsultaLaboral = cl.id
                    inner join [MEPRYLv2.1].dbo.ListaPreciosBase lpb on fact.idElementoLista = lpb.id
                    inner join [MEPRYLv2.1].dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
                    inner join [MEPRYLv2.1].dbo.empresaPorTipoDeExamen ete on tep.id = ete.idTipoExamen
                    inner join [MEPRYLv2.1].dbo.Empresa e on ete.idEmpresa = e.id
                    inner join [MEPRYLv2.1].dbo.Consulta c on tep.idConsulta = c.id
                    inner join [MEPRYLv2.1].dbo.PacienteLaboral pl on c.pacienteID = pl.id
                    where e.id = '" + value + "' AND CONVERT(date, fact.fecha) BETWEEN '" + dtpFechaFactDesde.Value.ToShortDateString() + "' AND '" + dtpFechaFactHasta.Value.ToShortDateString() + "'");

                    /*AgregarFacturacion = new DataTable();
                    if (Agregar.Rows.Count > 0)
                    {
                        test = "AAAAAA";
                        AgregarFacturacion = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT lpb.Codigo, lpb.TipoPrestacion, lpb.Descripcion,lpb.Factura
                        FROM [MEPRYLv2.1].dbo.ListaPreciosBase lpb
                        inner join [MEPRYLv2.1].dbo.ElementosListaPrecioPorConsultaLaboral fact on lpb.id = fact.idElementoLista
                        where fact.id = '" + Agregar.Rows[0][0].ToString() + "'");
                    }*/

                    foreach (DataRow dr in Agregar.Rows)
                    {
                        Busqueda.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
                        /*foreach (DataRow r in AgregarFacturacion.Rows)
                        {
                            Busqueda.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), r[0].ToString(), r[1].ToString(), r[2].ToString(), r[3].ToString());
                        }*/
                    }
                }
            }

            else if (dtpFechaAtencionDesde.Visible)
            {
                foreach (string value in listaEmpresas)
                {
                    Agregar = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT fact.id, cl.id, e.id, CONCAT(pl.apellido, ', ', pl.nombres), c.fecha, fact.fecha, lpb.Codigo, lpb.TipoPrestacion, lpb.Descripcion,lpb.Factura
                    FROM [MEPRYLv2.1].dbo.ElementosListaPrecioPorConsultaLaboral fact
                    inner join [MEPRYLv2.1].dbo.ConsultaLaboral cl on fact.idConsultaLaboral = cl.id
                    inner join [MEPRYLv2.1].dbo.ListaPreciosBase lpb on fact.idElementoLista = lpb.id
                    inner join [MEPRYLv2.1].dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
                    inner join [MEPRYLv2.1].dbo.empresaPorTipoDeExamen ete on tep.id = ete.idTipoExamen
                    inner join [MEPRYLv2.1].dbo.Empresa e on ete.idEmpresa = e.id
                    inner join [MEPRYLv2.1].dbo.Consulta c on tep.idConsulta = c.id
                    inner join [MEPRYLv2.1].dbo.PacienteLaboral pl on c.pacienteID = pl.id
                    where e.id = '" + value + "' AND CONVERT(date, c.fecha) BETWEEN '" + dtpFechaAtencionDesde.Value.ToShortDateString() + "' AND '" + dtpFechaAtHasta.Value.ToShortDateString() + "'");



                    foreach (DataRow dr in Agregar.Rows)
                    {
                        Busqueda.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
                    }
                }
            }

            else
            {
                MessageBox.Show("Debe seleccionar el rango de fechas");
                return;
            }

            bool EsResumido;

            if (rbInformeResumido.Checked)
            {
                EsResumido = true;
            }

            else
            {
                EsResumido = false;
            }

            frmMuestraFactPorEmpresa frm = new frmMuestraFactPorEmpresa();
            if (dtpFechaFactDesde.Visible)
            {
                frm = new frmMuestraFactPorEmpresa(Busqueda, EsResumido, listaEmpresas, dtpFechaFactDesde.Value, dtpFechaFactHasta.Value, true);
            }
            else if (dtpFechaAtencionDesde.Visible)
            {
                frm = new frmMuestraFactPorEmpresa(Busqueda, EsResumido, listaEmpresas, dtpFechaAtencionDesde.Value, dtpFechaAtHasta.Value, false);
            }
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            this.Close();
        }

        private void dgvFacturaciones_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ModificaSubTotal();
            ModificaTotal();
        }

        private void dgvFacturaciones_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ModificaSubTotal();
            ModificaTotal();
        }

        private void cbEmpresas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ModificaIva();
        }

        private void ModificaIva()
        {
        }

        private void ModificaSubTotal()
        {
            
        }

        private void rbInformeDetallado_CheckedChanged(object sender, EventArgs e)
        {
            /*if (rbInformeDetallado.Checked)
            {
                cbEmpresaHasta.Enabled = false;
            }
            else
            {
                cbEmpresaHasta.Enabled = true;
            }*/
        }

        private void btnIgualaEmpresas_Click(object sender, EventArgs e)
        {
            cbEmpresaHasta.SelectedValue = cbEmpresaDesde.SelectedValue;
        }

        private void btnIgualaFechasFac_Click(object sender, EventArgs e)
        {
            dtpFechaFactHasta.Value = dtpFechaFactDesde.Value;
        }

        private void btnIgualaFechaAt_Click(object sender, EventArgs e)
        {
            dtpFechaAtHasta.Value = dtpFechaAtencionDesde.Value;
        }

        private void btnFechaFactDesde_Click(object sender, EventArgs e)
        {
            dtpFechaFactDesde.Visible = true;
            dtpFechaFactHasta.Visible = true;
            lblFechaFacHasta.Visible = true;
            btnIgualaFechasFac.Visible = true;
            lblFechaFactDesde.Visible = true;

            lblFechaAtDesde.Visible = false;
            dtpFechaAtencionDesde.Visible = false;
            dtpFechaAtHasta.Visible = false;
            lblFechaAtHasta.Visible = false;
            btnIgualaFechaAt.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtpFechaFactDesde.Visible = false;
            dtpFechaFactHasta.Visible = false;
            lblFechaFacHasta.Visible = false;
            btnIgualaFechasFac.Visible = false;
            lblFechaFactDesde.Visible = false;

            lblFechaAtDesde.Visible = true;
            dtpFechaAtencionDesde.Visible = true;
            dtpFechaAtHasta.Visible = true;
            lblFechaAtHasta.Visible = true;
            btnIgualaFechaAt.Visible = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            

        }

        private void btnSiguienteEmpresa_Click(object sender, EventArgs e)
        {
            Object a = new object();
            EventArgs ea = new EventArgs();

            CambiaEmpresa();

            botBuscar_Click(a,ea);
        }

        private void ModificaTotal()
        {
        }

        private void frmConsultaFacturacionEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void dgvFacturaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbIVA_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSubTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblCostoTotal_Click(object sender, EventArgs e)
        {

        }

        private void lblUtilidadTotal_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lbliva_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbTitulo_Click(object sender, EventArgs e)
        {

        }

        private void CambiaEmpresa()
        {
            string ValueACambiar = "";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT e.id, e.razonSocial
                FROM[MEPRYLv2.1].dbo.Empresa e
                inner join[MEPRYLv2.1].dbo.empresaPorTipoDeExamen ete on e.id = ete.idEmpresa
                inner join[MEPRYLv2.1].dbo.ConsultaLaboral cl on ete.idTipoExamen = cl.idTipoExamen
                inner join[MEPRYLv2.1].[dbo].[ElementosListaPrecioPorConsultaLaboral] fact on cl.id = fact.idConsultaLaboral
                group by e.razonSocial, e.id
                order by razonSocial");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == cbEmpresaDesde.SelectedValue.ToString())
                {
                    if (i+1 >= dt.Rows.Count)
                    {
                        ValueACambiar = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        ValueACambiar = dt.Rows[i + 1][0].ToString();
                    }
                }
            }

            cbEmpresaDesde.SelectedValue = ValueACambiar;
        }
    }
}