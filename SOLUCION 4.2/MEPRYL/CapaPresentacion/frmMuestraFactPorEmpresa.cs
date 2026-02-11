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
using Excel = Microsoft.Office.Interop.Excel;
using Comunes;
using iText;
using iText.Layout;
using iText.Kernel;
using iText.Kernel.Geom;
using RawPrint;
using iText.Kernel.Font;
using iText.IO.Font.Constants;

namespace CapaPresentacion
{
    public partial class frmMuestraFactPorEmpresa : DevExpress.XtraEditors.XtraForm
    {
        string test;
        int FILA;
        bool EsFact, Resumido, EsPDF = false;
        double ValorIva;
        double a1, b2, c3;
        DataTable Busqueda;
        List<string> EmpresasBuscadas = new List<string>();
        DateTime desde, hasta;

        public frmMuestraFactPorEmpresa()
        {
            InitializeComponent();
        }

        public frmMuestraFactPorEmpresa(DataTable _Busqueda, bool EsResumido, List<string> values, DateTime FechaDesde, DateTime FechaHasta, bool esFact)
        {
            InitializeComponent();
            Resumido = EsResumido;
            EmpresasBuscadas = values;
            desde = FechaDesde;
            hasta = FechaHasta;
            EsFact = esFact;
            Busqueda = _Busqueda;
            inicializar();
        }

        private void cbEmpresasSeleccionadas_SelectedValueChanged(object sender, EventArgs e)
        {
            cbOperaciones.SelectedIndex = cbEmpresasSeleccionadas.SelectedIndex;
            if (!Resumido)
            {
                LlenarDgv(cbEmpresasSeleccionadas.SelectedValue.ToString());
                if (cbEmpresasSeleccionadas.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    //lblTitulo.Text = "Informe Detallado de " + ObtenerNombreEmpresa(cbEmpresasSeleccionadas.SelectedValue.ToString());
                    if (EsFact)
                    {
                        lblTitulo.Text = "Informe Detallado de " + ObtenerNombreEmpresa(cbEmpresasSeleccionadas.SelectedValue.ToString()) + Environment.NewLine + "Empresa desde: " + ObtenerNombreEmpresa(EmpresasBuscadas[0]) + ". Empresa hasta: " + ObtenerNombreEmpresa(EmpresasBuscadas[EmpresasBuscadas.Count - 1]) + ". Fecha Facturacion desde: " + desde.ToShortDateString() + ". Fecha Facturacion hasta:" + hasta.ToShortDateString();
                    }
                    else
                    {
                        lblTitulo.Text = "Informe Detallado de " + ObtenerNombreEmpresa(cbEmpresasSeleccionadas.SelectedValue.ToString()) + Environment.NewLine + "Empresa desde: " + ObtenerNombreEmpresa(EmpresasBuscadas[0]) + ". Empresa hasta: " + ObtenerNombreEmpresa(EmpresasBuscadas[EmpresasBuscadas.Count - 1]) + ". Fecha Atencion desde: " + desde.ToShortDateString() + ". Fecha Atencion hasta:" + hasta.ToShortDateString();
                    }
                    ModificaPorcentajeIva();
                }
            }
        }

        private void dgvFacturaciones_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ModificaSubTotal();
            ModificaPorcentajeIva();
            ModificaIva();
            ModificaTotal();
        }

        private void dgvFacturaciones_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ModificaSubTotal();
            ModificaPorcentajeIva();
            ModificaIva();
            ModificaTotal();
        }

        private void btnSiguienteEmpresa_Click(object sender, EventArgs e)
        {
            CambiaASiguienteEmpresa();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmExamenLaboral a = new frmExamenLaboral();
            frmFacturacionPrestaciones frm = new frmFacturacionPrestaciones(a, null, dgvFacturaciones.SelectedRows[0].Cells[1].Value.ToString());
            frm.ShowDialog();
        }

        #region Funciones

        private void inicializar()
        {
            LlenarComboOperaciones(EmpresasBuscadas);
            LlenarComboEmpresasBuscadas(EmpresasBuscadas);
            LlenarDgv(cbEmpresasSeleccionadas.SelectedValue.ToString());
            if (Resumido)
            {
                btnEditar.Visible = false;
                cbEmpresasSeleccionadas.Visible = false;
                if (EsFact)
                {
                    lblTitulo.Text = "Informe Resumido" + Environment.NewLine + "Empresa desde: " + ObtenerNombreEmpresa(EmpresasBuscadas[0]) + ". hasta: " + ObtenerNombreEmpresa(EmpresasBuscadas[EmpresasBuscadas.Count - 1]) + Environment.NewLine + "Fecha Facturacion desde: " + desde.ToShortDateString()+". hasta:"+hasta.ToShortDateString();
                }
                else
                {
                    lblTitulo.Text = "Informe Resumido" + Environment.NewLine + "Empresa desde: " + ObtenerNombreEmpresa(EmpresasBuscadas[0]) + ". hasta: " + ObtenerNombreEmpresa(EmpresasBuscadas[EmpresasBuscadas.Count - 1]) + Environment.NewLine + "Fecha Atencion desde: " + desde.ToShortDateString() + ". hasta:" + hasta.ToShortDateString();
                    btnSiguienteEmpresa_Click(null,null);
                }
            }
            else
            {
                if (EsFact)
                {
                    lblTitulo.Text = "Informe Resumido" + Environment.NewLine + "Empresa desde: " + ObtenerNombreEmpresa(EmpresasBuscadas[0]) + ". hasta: " + ObtenerNombreEmpresa(EmpresasBuscadas[EmpresasBuscadas.Count - 1])+"Fecha Facturacion desde: " + desde.ToShortDateString() + ". hasta:" + hasta.ToShortDateString();
                }
                else
                {
                    lblTitulo.Text = "Informe Resumido" + Environment.NewLine + "Empresa desde: " + ObtenerNombreEmpresa(EmpresasBuscadas[0]) + ". hasta: " + ObtenerNombreEmpresa(EmpresasBuscadas[EmpresasBuscadas.Count - 1]) + "Fecha Atencion desde: " + desde.ToShortDateString() + ". hasta:" + hasta.ToShortDateString();
                    btnSiguienteEmpresa_Click(null, null);
                }
                btnEditar.Visible = true;
                btnSiguienteEmpresa.Visible = true;
                btnEmpresaAnterior.Visible = true;
            }
            if (dgvFacturaciones.Rows.Count == 0 && !Resumido)
            {
                CambiaASiguienteEmpresa();
            }
        }

        private void LlenarComboEmpresasBuscadas(List<string> lista)
        {
            DataTable Empresas = new DataTable();
            Empresas.Columns.Add("id");
            Empresas.Columns.Add("razonSocial");

            foreach (string value in lista)
            {
                DataTable Agregar = Comunes.SQLConnector.obtenerTablaSegunConsultaString("SELECT id, razonSocial from [MEPRYLv2.1].[dbo].[Empresa] WHERE id = '" + value + "' ORDER BY razonSocial");
                foreach (DataRow dr in Agregar.Rows)
                {
                    Empresas.Rows.Add(dr.ItemArray);
                }
            }

            cbEmpresasSeleccionadas.DataSource = new DataView(Empresas); ;
            cbEmpresasSeleccionadas.ValueMember = "id";
            cbEmpresasSeleccionadas.DisplayMember = "razonSocial";

            cbEmpresasSeleccionadas.SelectedIndex = 0;
        }

        private void LlenarComboOperaciones(List<string> lista)
        {
            cbOperaciones.DataSource = null;
            DataTable Empresas = new DataTable();
            Empresas.Columns.Add("id");
            Empresas.Columns.Add("razonSocial");

            foreach (string value in lista)
            {
                DataTable Agregar = Comunes.SQLConnector.obtenerTablaSegunConsultaString("SELECT id, razonSocial from [MEPRYLv2.1].[dbo].[Empresa] WHERE id = '" + value + "' ORDER BY razonSocial");
                foreach (DataRow dr in Agregar.Rows)
                {
                    Empresas.Rows.Add(dr.ItemArray);
                }
            }

            cbOperaciones.DataSource = new DataView(Empresas); ;
            cbOperaciones.ValueMember = "id";
            cbOperaciones.DisplayMember = "razonSocial";

            cbOperaciones.SelectedIndex = 0;
        }

        private void LlenarDgv(string value)
        {
            string ultimaEmpresa;
            double suma = 0;
            List<DataRow> FilasAAgregar = new List<DataRow>();
            DataTable retorno = new DataTable();

            dgvFacturaciones.Rows.Clear();
            #region Resumido
            if (Resumido)
            {
                retorno.Columns.Add("idEmpresa");
                retorno.Columns.Add("Empresa");
                retorno.Columns.Add("Facturacion");

                cbEmpresasSeleccionadas.Enabled = false;

                for (int i = 0; i < cbEmpresasSeleccionadas.Items.Count; i++)
                {
                    cbEmpresasSeleccionadas.SelectedIndex = i;
                    foreach (DataRow dr in Busqueda.Rows)
                    {
                        if (dr[2].ToString() == cbEmpresasSeleccionadas.SelectedValue.ToString())
                        {
                            FilasAAgregar.Add(dr);
                        }
                    }
                    foreach (DataRow row in FilasAAgregar)
                    {
                        suma = suma + Convert.ToDouble(row[9].ToString());
                        suma = Math.Round(suma, 2);

                        //retorno.Rows.Add(cbEmpresasSeleccionadas.SelectedValue.ToString(), ObtenerNombreEmpresa(cbEmpresasSeleccionadas.SelectedValue.ToString()), suma.ToString());
                    }
                    if (suma != 0)
                    {
                        retorno.Rows.Add(cbEmpresasSeleccionadas.SelectedValue.ToString(), ObtenerNombreEmpresa(cbEmpresasSeleccionadas.SelectedValue.ToString()), suma.ToString("F"));
                    }
                    FilasAAgregar.Clear();
                    suma = 0;
                }
                /*ultimaEmpresa = EmpresasBuscadas[0];
                foreach (DataRow dr in Busqueda.Rows)
                {
                    while (dr[2].ToString() == ultimaEmpresa)
                    {
                        FilasAAgregar.Add(dr);
                    }
                }*/

                foreach (DataRow dr in retorno.Rows)
                {
                    dgvFacturaciones.Columns[3].HeaderText = "Empresa";
                    dgvFacturaciones.Rows.Add("", "", dr[0].ToString(), dr[1].ToString(), "", "", "", "", "", dr[2].ToString());
                    //dgvFacturaciones.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
                }
            }
            #endregion
            #region Detallado
            else
            {
                foreach (DataRow dr in Busqueda.Rows)
                {
                    if (dr[2].ToString() == value)
                    {
                        FilasAAgregar.Add(dr);
                    }
                }
                foreach (DataRow dr in FilasAAgregar)
                {
                    suma = Convert.ToDouble(dr[9].ToString());
                    suma = Math.Round(suma, 2);
                    if (ObtenerIvaYDiscrimina(cbEmpresasSeleccionadas.SelectedValue.ToString()).Item2)
                    {
                        //Si la empresa discrimina el iva, cambia el valor de suma asi es mostrado como precio al publico(Precio + IVA)
                        suma = suma + (suma * ObtenerIvaYDiscrimina(cbEmpresasSeleccionadas.SelectedValue.ToString()).Item1 / 100);
                    }
                    dgvFacturaciones.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToDateTime(dr[4].ToString()).ToShortDateString(), Convert.ToDateTime(dr[5].ToString()).ToShortDateString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), suma.ToString("F"));
                }
            }
            #endregion
        }

        private string ObtenerNombreEmpresa(string idEmpresa)
        {
            DataTable dt = Comunes.SQLConnector.obtenerTablaSegunConsultaString("SELECT razonSocial from [MEPRYLv2.1].[dbo].[Empresa] WHERE id = '" + idEmpresa + "'");
            return dt.Rows[0][0].ToString();
        }

        private void ModificaSubTotal()
        {
            tbSubTotal.Text = "0";
            double suma = 0, num;
            foreach (DataGridViewRow dgvr in dgvFacturaciones.Rows)
            {
                num = Convert.ToDouble(dgvr.Cells[9].Value.ToString());
                if (!ObtenerIvaYDiscrimina(dgvr.Cells[2].Value.ToString()).Item2)
                {
                    test = Convert.ToString(num * ObtenerIvaYDiscrimina(dgvr.Cells[2].Value.ToString()).Item1 / 100);
                    test = Convert.ToString(num * ObtenerIvaYDiscrimina(dgvr.Cells[2].Value.ToString()).Item1 / 100);
                    num = num + (num * ObtenerIvaYDiscrimina(dgvr.Cells[2].Value.ToString()).Item1 / 100);
                }
                suma = suma + num;
            }
            suma = Math.Round(suma, 2);
            tbSubTotal.Text = suma.ToString("F");
        }

        private void ModificaIva()
        {
            double SubTotal, Iva;
            SubTotal = Convert.ToDouble(tbSubTotal.Text.ToString());
            tbIVA.Text = "0";
            if (Resumido)
            {
                Iva = Convert.ToDouble(lbliva.Text.ToString());
                //ValorIva = SubTotal * Iva / 100;
                ValorIva = 0;
                foreach (DataGridViewRow dr in dgvFacturaciones.Rows)
                {
                    test = dr.Cells[9].Value.ToString();
                    if (ObtenerIvaYDiscrimina(dr.Cells[2].Value.ToString()).Item2)
                    {
                        ValorIva = ValorIva + Convert.ToDouble(dr.Cells[9].Value.ToString()) * ObtenerIvaYDiscrimina(dr.Cells[2].Value.ToString()).Item1 / 100;
                    }
                }
                ValorIva = Math.Round(ValorIva, 2);
                tbIVA.Text = ValorIva.ToString("F");
            }
            else
            {
                SubTotal = Convert.ToDouble(tbSubTotal.Text.ToString());
                Iva = Convert.ToDouble(lbliva.Text.ToString());
                ValorIva = SubTotal * Iva / 100;
                ValorIva = Math.Round(ValorIva, 2);
                DataTable dt = Comunes.SQLConnector.obtenerTablaSegunConsultaString(@"SELECT DiscriminaIva
                FROM [MEPRYLv2.1].[dbo].[Iva] i
                inner join dbo.Empresa e on i.descripcion = e.tipoDeContribuyente
                WHERE e.id = '" + cbEmpresasSeleccionadas.SelectedValue.ToString() + "'");
                if (dt.Rows[0][0].ToString() == "True")
                {
                    tbIVA.Text = ValorIva.ToString("F");
                }
            }
        }

        private void ModificaPorcentajeIva()
        {
            lbliva.Text = "0";
            if (Resumido)
            {
                DataTable dt = Comunes.SQLConnector.obtenerTablaSegunConsultaString(@"SELECT valor
                FROM [MEPRYLv2.1].[dbo].[Iva] i
                WHERE descripcion = 'PREDETERMINADO'");
                lbliva.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                test = cbEmpresasSeleccionadas.SelectedValue.ToString();
                test = cbEmpresasSeleccionadas.SelectedValue.ToString();

                DataTable dt = Comunes.SQLConnector.obtenerTablaSegunConsultaString(@"SELECT valor, DiscriminaIva
                FROM [MEPRYLv2.1].[dbo].[Iva] i
                inner join dbo.Empresa e on i.descripcion = e.tipoDeContribuyente
                WHERE e.id = '" + cbEmpresasSeleccionadas.SelectedValue.ToString() + "'");
                lbliva.Text = dt.Rows[0][0].ToString();
            }
        }

        private void ModificaTotal()
        {
            double Total;

            tbTotal.Text = "0";
            if (dgvFacturaciones.Rows.Count > 0)
            {
                Total = Convert.ToDouble(tbSubTotal.Text) + ValorIva;
                Total = Math.Round(Total, 2);
                tbTotal.Text = Convert.ToString(Total);
                if (!ObtenerIvaYDiscrimina(cbEmpresasSeleccionadas.SelectedValue.ToString()).Item2)
                {
                    //tbSubTotal.Text = Total.ToString("F");
                    tbTotal.Text = tbSubTotal.Text;
                }
            }
        }

        private void CambiaAAnteriorEmpresa()
        {
            int Index = -1;

            for (int i = cbOperaciones.SelectedIndex - 1; i > -1; i--)
            {
                cbOperaciones.SelectedIndex = i;

                foreach (DataRow dr in Busqueda.Rows)
                {
                    if (dr[2].ToString() == cbOperaciones.SelectedValue.ToString() && Index == -1)
                    {
                        Index = cbOperaciones.SelectedIndex;
                    }
                }
            }
            if (Index != -1)
            {
                cbEmpresasSeleccionadas.SelectedIndex = Index;
                cbOperaciones.SelectedIndex = Index;
            }
            else
            {
                cbEmpresasSeleccionadas.SelectedIndex = 0;
                if (dgvFacturaciones.Rows.Count == 0)
                {
                    //CambiaASiguienteEmpresa();
                }
            }
        }

        private void CambiaASiguienteEmpresa()
        {
            int Index = -1;

            for (int i = cbOperaciones.SelectedIndex+1; i < cbOperaciones.Items.Count; i++)
            {
                cbOperaciones.SelectedIndex = i;

                foreach (DataRow dr in Busqueda.Rows)
                {
                    if (dr[2].ToString() == cbOperaciones.SelectedValue.ToString() && Index == -1)
                    {
                        Index = cbOperaciones.SelectedIndex;
                    }
                }
            }
            if (Index != -1)
            {
                cbEmpresasSeleccionadas.SelectedIndex = Index;
                cbOperaciones.SelectedIndex = Index;
            }
            else
            {
                cbEmpresasSeleccionadas.SelectedIndex = 0;
                if (dgvFacturaciones.Rows.Count == 0)
                {
                    //CambiaASiguienteEmpresa();
                }
            }
        }

        private void guardarExportacionPDF()
        {
            double acumSubtotal = 0, acumIva = 0, acumtotal = 0;

            iText.Kernel.Pdf.PdfWriter writer = new iText.Kernel.Pdf.PdfWriter(tbPDF.Text);
            iText.Kernel.Pdf.PdfDocument doc = new iText.Kernel.Pdf.PdfDocument(writer);
            iText.Layout.Document document;
            //float[] pointColumnWidths = { 150F, 150F, 150F };
            iText.Layout.Element.Table tabla;

            if (Resumido)
            {
                document = new iText.Layout.Document(doc);
                tabla = new iText.Layout.Element.Table(5);
                tabla.UseAllAvailableWidth();

                if (EsFact)
                {
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Empresa desde: " + ObtenerNombreEmpresa(EmpresasBuscadas[0].ToString()))));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Empresa desde: " + ObtenerNombreEmpresa(EmpresasBuscadas[EmpresasBuscadas.Count - 1].ToString()))));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Fecha fact. desde: " + desde.ToShortDateString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Fecha fact hasta: " + hasta.ToShortDateString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(DateTime.Today.ToShortDateString())));
                }
                else
                {
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Empresa desde: " + ObtenerNombreEmpresa(EmpresasBuscadas[0].ToString()))));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Hasta: " + ObtenerNombreEmpresa(EmpresasBuscadas[EmpresasBuscadas.Count - 1].ToString()))));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Fecha atencion desde: " + desde.ToShortDateString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Hasta: " + hasta.ToShortDateString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(DateTime.Today.ToShortDateString())));
                }

                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Empresa")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Fecha Fact.")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("SubTotal")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Iva")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Total")));
            }
            else
            {
                document = new iText.Layout.Document(doc, PageSize.A4.Rotate());

                tabla = new iText.Layout.Element.Table(8);
                tabla.UseAllAvailableWidth();

                if (EsFact)
                {
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Empresa desde: " + ObtenerNombreEmpresa(EmpresasBuscadas[0].ToString()))));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Empresa desde: " + ObtenerNombreEmpresa(EmpresasBuscadas[EmpresasBuscadas.Count - 1].ToString()))));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Fecha fact. desde: " + desde.ToShortDateString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Fecha fact hasta: " + hasta.ToShortDateString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(DateTime.Today.ToShortDateString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                }
                else
                {
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Empresa desde: " + ObtenerNombreEmpresa(EmpresasBuscadas[0].ToString()))));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Hasta: " + ObtenerNombreEmpresa(EmpresasBuscadas[EmpresasBuscadas.Count - 1].ToString()))));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Fecha atencion desde: " + desde.ToShortDateString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Hasta: " + hasta.ToShortDateString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(DateTime.Today.ToShortDateString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                }

                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Empresa")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Paciente")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Fecha Atencion")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Fecha Fact.")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Descripcion")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("SubTotal")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Iva")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Total")));
            }

            DataTable dt = cargarTablasExcel();
            dt = OrdenaPorEmpresaYFecha(dt);

            foreach (DataRow dr in dt.Rows)
            {
                /*string a,b,c,d,e;
                a = dr[0].ToString();
                b = dr[1].ToString();
                c = dr[2].ToString();
                d = dr[3].ToString();
                e = dr[4].ToString();*/
                if (Resumido)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        iText.Kernel.Font.PdfFont font;
                        iText.Layout.Element.Cell a = new iText.Layout.Element.Cell();
                        iText.Layout.Element.Paragraph p = new iText.Layout.Element.Paragraph(dr[dc.ColumnName.ToString()].ToString());
                        p.SetFontSize(11);
                        a.Add(p);
                        tabla.AddCell(a);
                    }
                    /*tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[0].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[1].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[2].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[3].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[4].ToString())));*/
                    //document.Add(new iText.Layout.Element.Paragraph(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString() + " " + dr[4].ToString()));
                    acumSubtotal = acumSubtotal + Convert.ToDouble(dr[2].ToString());
                    acumIva = acumIva + Convert.ToDouble(dr[3].ToString());
                    acumtotal = acumtotal + Convert.ToDouble(dr[4].ToString());
                }
                else
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        iText.Kernel.Font.PdfFont font;
                        iText.Layout.Element.Cell a = new iText.Layout.Element.Cell();
                        iText.Layout.Element.Paragraph p = new iText.Layout.Element.Paragraph(dr[dc.ColumnName.ToString()].ToString());
                        p.SetFontSize(11);
                        a.Add(p);
                        tabla.AddCell(a);
                    }
                    /*tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[0].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[1].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[2].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[3].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[4].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[5].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[6].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[7].ToString())));*/
                    //document.Add(new iText.Layout.Element.Paragraph(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString() + " " + dr[4].ToString() + " " + dr[5].ToString() + " " + dr[6].ToString() + " " + dr[7].ToString()));
                    acumSubtotal = acumSubtotal + Convert.ToDouble(dr[5].ToString());
                    acumIva = acumIva + Convert.ToDouble(dr[6].ToString());
                    acumtotal = acumtotal + Convert.ToDouble(dr[7].ToString());
                }
            }
            if (Resumido)
            {
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Totalizador")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(acumSubtotal.ToString())));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(acumIva.ToString())));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(acumtotal.ToString())));
            }
            else
            {
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Totalizador")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(acumSubtotal.ToString())));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(acumIva.ToString())));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(acumtotal.ToString())));
            }
            document.Add(tabla);
            document.Close();
            MessageBox.Show("La exportación se ha guardado correctamente: \n" + tbPDF.Text, "Exportar", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            this.Close();
        }

        private void guardarExportacionExcel()
        {
            #region Resumido
            if (Resumido)
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelworkBook;
                Microsoft.Office.Interop.Excel.Worksheet excelSheet;

                //lblTarea.Visible = true;
                excel.Visible = false;
                excel.DisplayAlerts = false;
                excel.SheetsInNewWorkbook = 1;
                excelworkBook = (Microsoft.Office.Interop.Excel.Workbook)(excel.Workbooks.Add(Type.Missing));
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = "Hoja1";

                excelSheet.Cells[1, 1] = "Informe Resumido";
                excelSheet.Cells[1, 2] = "Desde:" + desde.ToShortDateString();
                excelSheet.Cells[1, 3] = "Hasta:" + hasta.ToShortDateString();
                excelSheet.Cells[1, 4] = "Desde:" + ObtenerNombreEmpresa(EmpresasBuscadas[0].ToString());
                excelSheet.Cells[1, 5] = "Hasta:" + ObtenerNombreEmpresa(EmpresasBuscadas[EmpresasBuscadas.Count - 1].ToString());
                excelSheet.Cells[1, 6] = DateTime.Today.ToShortDateString();
                excelSheet.Cells[2, 1] = "Empresa";
                excelSheet.Cells[2, 2] = "Fecha de Facturacion";
                excelSheet.Cells[2, 3] = "SubTotal";
                excelSheet.Cells[2, 4] = "Iva";
                excelSheet.Cells[2, 5] = "Total";
                /*excelSheet.Cells[1, 4] = "dni";
                excelSheet.Cells[1, 5] = "variable";
                excelSheet.Cells[1, 6] = "variable1";*/

                setearColorYBorde(excel.get_Range("A1", "A1"));
                setearColorYBorde(excel.get_Range("B1", "B1"));
                setearColorYBorde(excel.get_Range("C1", "C1"));
                /*setearColorYBorde(excel.get_Range("D1", "D1"));
                setearColorYBorde(excel.get_Range("E1", "E1"));
                setearColorYBorde(excel.get_Range("F1", "F1"));*/

                DataTable dt = cargarTablasExcel();
                dt = OrdenaPorEmpresaYFecha(dt);

                double subtotal, iva, total;

                foreach (DataRow r in dt.Rows)
                {
                    r.BeginEdit();
                    r[2] = r[2].ToString().Replace(',', '&').Replace('.', ',').Replace('&', '.');
                    r[3] = r[3].ToString().Replace(',', '&').Replace('.', ',').Replace('&', '.');
                    r[4] = r[4].ToString().Replace(',', '&').Replace('.', ',').Replace('&', '.');
                    /*subtotal = Convert.ToDouble(r[2].ToString());
                    iva = Convert.ToDouble(r[3].ToString());
                    total = Convert.ToDouble(r[4].ToString());

                    r[2] = subtotal.ToString();
                    r[3] = iva.ToString();
                    r[4] = total.ToString();*/
                    r.EndEdit();
                }

                double a = 0, b = 0, c = 0;
                foreach (DataRow r in dt.Rows)
                {
                    a = a + Convert.ToDouble(r[2].ToString().Replace('.', ','));
                    b = b + Convert.ToDouble(r[3].ToString().Replace('.', ','));
                    c = c + Convert.ToDouble(r[4].ToString().Replace('.', ','));
                    /*if (dr["variable"].ToString() != "")
                    {
                        //fecha = Convert.ToDateTime(dr["variable"].ToString());
                        //dr["variable"] = fecha.ToString("dd/MM/yyyy");
                        //dt2.ImportRow(dr);
                    }*/
                }
                dt.Rows.Add("TOTAL", "", a.ToString().Replace(',', '&').Replace('.', ',').Replace('&', '.'), b.ToString().Replace(',', '&').Replace('.', ',').Replace('&', '.'), c.ToString().Replace(',', '&').Replace('.', ',').Replace('&', '.'));
                //dt2.AcceptChanges();

                DataView dv = dt.DefaultView;
                //dv.Sort = "FILA asc";
                DataTable sortedDT = dv.ToTable();

                progressBar.Visible = true;
                progressBar.Minimum = 1;
                progressBar.Maximum = dt.Rows.Count;
                progressBar.Step = 1;

                int i = 2;
                int j = 0;
                foreach (DataRow dr in sortedDT.Rows)
                {
                    /*excelSheet.Cells[i + 1, j + 1] = Convert.ToInt64(dr.ItemArray[0].ToString());
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[1].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[2].ToString();
                    j++;*/
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[0].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[1].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[2].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[3].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[4].ToString();
                    j++;

                    i++;
                    progressBar.PerformStep();
                    j = 0;
                }
                excel.get_Range("A1", "F1").EntireColumn.AutoFit();
                excel.get_Range("A2", "E2").EntireColumn.AutoFit();
                excel.get_Range("A2", "E2").EntireRow.Font.Bold = true;
                for (int row = 3; row < i+1; row++)
                {
                    excel.get_Range("B"+row.ToString(), "E"+ row.ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight; ;
                }
                for (int row = 3; row < i + 1; row++)
                {
                    excel.get_Range("C" + row.ToString(), "E" + row.ToString()).Style = "Currency";
                }
                int index = i;
                excel.get_Range("A"+index.ToString(), "E"+ index.ToString()).EntireRow.Font.Bold = true;
                progressBar.Value = progressBar.Maximum;
                excelworkBook.SaveAs(tbExcel.Text, Excel.XlFileFormat.xlOpenXMLWorkbook,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
                Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excel.Quit();
                progressBar.Visible = false;
                //lblTarea.Visible = false;

                MessageBox.Show("La exportación se ha guardado correctamente: \n" + tbExcel.Text, "Exportar", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            #endregion
            #region Detallado
            else
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelworkBook;
                Microsoft.Office.Interop.Excel.Worksheet excelSheet;

                //lblTarea.Visible = true;
                excel.Visible = false;
                excel.DisplayAlerts = false;
                excel.SheetsInNewWorkbook = 1;
                excelworkBook = (Microsoft.Office.Interop.Excel.Workbook)(excel.Workbooks.Add(Type.Missing));
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = "Hoja1";

                excelSheet.Cells[1, 1] = "Informe Resumido";
                excelSheet.Cells[1, 2] = "Desde:" + desde.ToShortDateString();
                excelSheet.Cells[1, 3] = "Hasta:" + hasta.ToShortDateString();
                excelSheet.Cells[1, 4] = "Desde:" + ObtenerNombreEmpresa(EmpresasBuscadas[0].ToString());
                excelSheet.Cells[1, 5] = "Hasta:" + ObtenerNombreEmpresa(EmpresasBuscadas[EmpresasBuscadas.Count - 1].ToString());
                excelSheet.Cells[1, 6] = DateTime.Today.ToShortDateString();
                excelSheet.Cells[2, 1] = "Empresa";
                excelSheet.Cells[2, 2] = "Paciente";
                excelSheet.Cells[2, 3] = "Fecha de Atencion";
                excelSheet.Cells[2, 4] = "Fecha de Facturacion";
                excelSheet.Cells[2, 5] = "Descripcion";
                excelSheet.Cells[2, 6] = "SubTotal";
                excelSheet.Cells[2, 7] = "Iva";
                excelSheet.Cells[2, 8] = "Total";
                /*excelSheet.Cells[1, 4] = "dni";
                excelSheet.Cells[1, 5] = "variable";
                excelSheet.Cells[1, 6] = "variable1";*/

                setearColorYBorde(excel.get_Range("A1", "A1"));
                setearColorYBorde(excel.get_Range("B1", "B1"));
                setearColorYBorde(excel.get_Range("C1", "C1"));
                /*setearColorYBorde(excel.get_Range("D1", "D1"));
                setearColorYBorde(excel.get_Range("E1", "E1"));
                setearColorYBorde(excel.get_Range("F1", "F1"));*/

                DataTable dt = cargarTablasExcel();
                dt = OrdenaPorEmpresaYFecha(dt);

                double a = 0, b = 0, c = 0;
                decimal subtotal, iva, total;
                foreach (DataRow r in dt.Rows)
                {
                    r.BeginEdit();
                    r[5] = r[5].ToString().Replace(',','&').Replace('.',',').Replace('&', '.');
                    r[6] = r[6].ToString().Replace(',', '&').Replace('.', ',').Replace('&', '.');
                    r[7] = r[7].ToString().Replace(',', '&').Replace('.', ',').Replace('&', '.');
                    /*subtotal = Convert.ToDecimal(r[5].ToString());
                    iva = Convert.ToDecimal(r[6].ToString());
                    total = Convert.ToDecimal(r[7].ToString());

                    r[5] = subtotal.ToString();
                    r[6] = iva.ToString();
                    r[7] = total.ToString();*/
                    r.EndEdit();
                }
                foreach (DataRow r in dt.Rows)
                {
                    a1 = Convert.ToDouble(r[5].ToString().Replace('.',','));
                    b2 = Convert.ToDouble(r[6].ToString().Replace('.', ','));
                    c3 = Convert.ToDouble(r[7].ToString().Replace('.', ','));
                    a = a + Convert.ToDouble(r[5].ToString().Replace('.', ','));
                    b = b + Convert.ToDouble(r[6].ToString().Replace('.', ','));
                    c = c + Convert.ToDouble(r[7].ToString().Replace('.', ','));
                    /*if (dr["variable"].ToString() != "")
                    {
                        //fecha = Convert.ToDateTime(dr["variable"].ToString());
                        //dr["variable"] = fecha.ToString("dd/MM/yyyy");
                        //dt2.ImportRow(dr);
                    }*/
                }
                dt.Rows.Add("TOTAL", "", "", "", "", a.ToString().Replace(',', '&').Replace('.', ',').Replace('&', '.'), b.ToString().Replace(',', '&').Replace('.', ',').Replace('&', '.'), c.ToString().Replace(',', '&').Replace('.', ',').Replace('&', '.'));
                //dt2.AcceptChanges();

                DataView dv = dt.DefaultView;
                //dv.Sort = "FILA asc";
                DataTable sortedDT = dv.ToTable();

                progressBar.Visible = true;
                progressBar.Minimum = 1;
                progressBar.Maximum = dt.Rows.Count;
                progressBar.Step = 1;

                int i = 2;
                int j = 0;
                foreach (DataRow dr in sortedDT.Rows)
                {
                    /*excelSheet.Cells[i + 1, j + 1] = Convert.ToInt64(dr.ItemArray[0].ToString());
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[1].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[2].ToString();
                    j++;*/
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[0].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[1].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[2].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[3].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[4].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[5].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[6].ToString();
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[7].ToString();
                    j++;

                    i++;
                    progressBar.PerformStep();
                    j = 0;
                }
                excel.get_Range("A1", "F1").EntireColumn.AutoFit();
                excel.get_Range("A2", "E2").EntireColumn.AutoFit();
                excel.get_Range("A2", "E2").EntireRow.Font.Bold = true;
                for (int row = 3; row < i + 1; row++)
                {
                    excel.get_Range("F" + row.ToString(), "H" + row.ToString()).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight; ;
                }
                /*for (int row = 3; row < i + 1; row++)
                {
                    excel.get_Range("F" + row.ToString(), "H" + row.ToString()).Cells.NumberFormat = "#,##0.00"; ;
                }*/
                for (int row = 3; row < i + 1; row++)
                {
                    excel.get_Range("F" + row.ToString(), "H" + row.ToString()).Style = "Currency";
                }
                int index = i;
                excel.get_Range("A" + index.ToString(), "E" + index.ToString()).EntireRow.Font.Bold = true;
                progressBar.Value = progressBar.Maximum;
                excelworkBook.SaveAs(tbExcel.Text, Excel.XlFileFormat.xlOpenXMLWorkbook,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
                Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excel.Quit();
                progressBar.Visible = false;
                //lblTarea.Visible = false;

                MessageBox.Show("La exportación se a guardado correctamente: \n" + tbExcel.Text, "Exportar", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            #endregion
        }

        private Tuple<int,bool> ObtenerIvaYDiscrimina(string idEmpresa)
        {
            bool retorno;
            DataTable dt = Comunes.SQLConnector.obtenerTablaSegunConsultaString(@"SELECT valor, DiscriminaIva
                FROM [MEPRYLv2.1].[dbo].[Iva] i
                inner join dbo.Empresa e on i.descripcion = e.tipoDeContribuyente
                WHERE e.id = '" + idEmpresa + "'");
            if (dt.Rows[0][1].ToString() == "True")
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }
            return Tuple.Create(Convert.ToInt32(dt.Rows[0][0].ToString()), retorno);
        }

        private DataTable cargarTablasExcel()
        {
            List<DataRow> FilasAEliminar = new List<DataRow>();
            DataTable retorno = new DataTable();
            bool existe = false;

            #region Resumido
            if (Resumido)
            {
                retorno.Columns.Add("Empresa");
                retorno.Columns.Add("FechaFact");
                retorno.Columns.Add("Facturacion");
                retorno.Columns.Add("idEmpresa");

                DataTable tipoEx = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT e.razonSocial, fact.fecha, lpb.Factura, fact.id, e.id
                FROM [MEPRYLv2.1].[dbo].[ElementosListaPrecioPorConsultaLaboral] fact
                inner join [MEPRYLv2.1].dbo.ConsultaLaboral cl on fact.idConsultaLaboral = cl.id
                inner join [MEPRYLv2.1].dbo.ListaPreciosBase lpb on fact.idElementoLista = lpb.id
                inner join [MEPRYLv2.1].dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
                inner join [MEPRYLv2.1].dbo.empresaPorTipoDeExamen ete on tep.id = ete.idTipoExamen
                inner join [MEPRYLv2.1].dbo.Empresa e on ete.idEmpresa = e.id
                inner join [MEPRYLv2.1].dbo.Consulta c on tep.idConsulta = c.id
                inner join [MEPRYLv2.1].dbo.PacienteLaboral pl on c.pacienteID = pl.id");

                //Elimina los que no estan en el rango de fechas o empresas
                foreach (DataRow r in tipoEx.Rows)
                {
                    bool existe1 = false;
                    foreach (DataRow dr in Busqueda.Rows)
                    {
                        if (r[3].ToString() == dr[0].ToString())
                        {
                            existe1 = true;
                        }
                    }
                    if (!existe1)
                    {
                        r.Delete();
                    }
                }
                tipoEx.AcceptChanges();

                foreach (DataRow r in tipoEx.Rows)
                {
                    foreach (String str in EmpresasBuscadas)
                    {
                        FILA = tipoEx.Rows.Count;
                        FILA = Busqueda.Rows.Count;
                        FILA = Busqueda.Rows.Count;
                        if (r[4].ToString() == str)
                        {
                            existe = true;
                        }
                    }
                    if (!existe)
                    {
                        FilasAEliminar.Add(r);
                    }
                    existe = false;
                }

                foreach (DataRow dr in FilasAEliminar)
                {
                    tipoEx.Rows.Remove(dr);
                }

                foreach (DataRow dr in tipoEx.Rows)
                {
                    string value = dr[4].ToString();
                    if (FacturaCasaMatriz(value))
                    {
                        dr.BeginEdit();
                        dr[0] = ObtenerNombreEmpresa(ObtieneCasaMatriz(value));
                        dr[4] = ObtieneCasaMatriz(value);
                        dr.EndEdit();
                    }
                }

                foreach (DataRow dr in tipoEx.Rows)
                {
                    retorno.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[4].ToString());
                }
            }
            #endregion
            #region Detallado
            else
            {
                retorno.Columns.Add("Empresa");
                retorno.Columns.Add("Paciente");
                retorno.Columns.Add("FechaAtencion");
                retorno.Columns.Add("FechaFact");
                retorno.Columns.Add("DescripcionPrestacion");
                retorno.Columns.Add("Facturacion");
                retorno.Columns.Add("idEmpresa");

                DataTable tipoEx = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT e.razonSocial, CONCAT(pl.apellido, ', ', pl.nombres), c.fecha, fact.fecha, lpb.Descripcion, lpb.Factura, e.id, fact.id
                FROM [MEPRYLv2.1].[dbo].[ElementosListaPrecioPorConsultaLaboral] fact
                inner join [MEPRYLv2.1].dbo.ConsultaLaboral cl on fact.idConsultaLaboral = cl.id
                inner join [MEPRYLv2.1].dbo.ListaPreciosBase lpb on fact.idElementoLista = lpb.id
                inner join [MEPRYLv2.1].dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
                inner join [MEPRYLv2.1].dbo.empresaPorTipoDeExamen ete on tep.id = ete.idTipoExamen
                inner join [MEPRYLv2.1].dbo.Empresa e on ete.idEmpresa = e.id
                inner join [MEPRYLv2.1].dbo.Consulta c on tep.idConsulta = c.id
                inner join [MEPRYLv2.1].dbo.PacienteLaboral pl on c.pacienteID = pl.id
                ORDER BY e.razonSocial");

                foreach (DataRow r in tipoEx.Rows)
                {
                    bool existe1 = false;
                    foreach (DataRow dr in Busqueda.Rows)
                    {
                        if (r[7].ToString() == dr[0].ToString())
                        {
                            existe1 = true;
                        }
                    }
                    if (!existe1)
                    {
                        r.Delete();
                    }
                }
                tipoEx.AcceptChanges();

                foreach (DataRow r in tipoEx.Rows)
                {
                    foreach (String str in EmpresasBuscadas)
                    {
                        if (r[6].ToString() == str)
                        {
                            existe = true;
                        }
                    }
                    if (!existe)
                    {
                        FilasAEliminar.Add(r);
                    }
                    existe = false;
                }
                foreach (DataRow dr in FilasAEliminar)
                {
                    tipoEx.Rows.Remove(dr);
                }

                foreach (DataRow dr in tipoEx.Rows)
                {
                    string value = dr[6].ToString();
                    if (FacturaCasaMatriz(value))
                    {
                        dr.BeginEdit();
                        dr[0] = ObtenerNombreEmpresa(ObtieneCasaMatriz(value)) + "("+ObtenerNombreEmpresa(value)+")";
                        dr[6] = ObtieneCasaMatriz(value);
                        dr.EndEdit();
                    }
                }

                foreach (DataRow dr in tipoEx.Rows)
                {
                    retorno.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }
            }
            #endregion

            return retorno;
        }

        private DataTable OrdenaPorEmpresaYFecha(DataTable dtAUtilizar)
        {
            DataTable retorno = new DataTable();

            #region Resumido
            if (Resumido)
            {
                string idEmpresa = "", EmpresaActual, FechaActual, EmpresaAnterior = "", FechaAnterior = "";
                double suma = 0, ValorIva, Total;
                List<DataRow> FilasAAgregar = new List<DataRow>();

                retorno.Columns.Add("Empresa");
                retorno.Columns.Add("FechaFact");
                retorno.Columns.Add("Facturacion");
                retorno.Columns.Add("ValorIva");
                retorno.Columns.Add("Total");

                DataView dv = dtAUtilizar.DefaultView;
                dv.Sort = "Empresa ASC";
                dtAUtilizar = dv.ToTable();

                foreach (DataRow dr in dtAUtilizar.Rows)
                {
                    EmpresaActual = dr[0].ToString();
                    FechaActual = dr[1].ToString();
                    if (FechaActual != FechaAnterior || EmpresaActual != EmpresaAnterior)
                    {
                        foreach (DataRow r in dtAUtilizar.Rows)
                        {
                            if (r[0].ToString() == EmpresaActual && r[1].ToString() == FechaActual)
                            {
                                FilasAAgregar.Add(r);
                            }
                        }

                        foreach (DataRow fila in FilasAAgregar)
                        {
                            suma = suma + Convert.ToDouble(fila[2].ToString());
                            idEmpresa = fila[3].ToString();
                        }
                        Tuple<int, bool> Ivas = ObtenerIvaYDiscrimina(idEmpresa);
                        ValorIva = suma * Ivas.Item1 / 100;
                        Total = suma + (suma * Ivas.Item1 / 100);
                        suma = Math.Round(suma, 2);
                        ValorIva = Math.Round(ValorIva, 2);
                        Total = Math.Round(Total, 2);
                        if (Ivas.Item2)
                        {
                            retorno.Rows.Add(EmpresaActual, Convert.ToDateTime(FechaActual).ToString("MM/dd/yyyy"), suma.ToString("F"), ValorIva.ToString("F"), Total.ToString("F"));
                        }
                        else
                        {
                            retorno.Rows.Add(EmpresaActual, Convert.ToDateTime(FechaActual).ToString("MM/dd/yyyy"), Total.ToString("F"), 0.ToString("F"), Total.ToString("F"));
                        }
                    }

                    FilasAAgregar.Clear();
                    suma = 0;
                    EmpresaAnterior = EmpresaActual;
                    FechaAnterior = FechaActual;
                }
            }
            #endregion
            #region Detallado
            else
            {
                string idEmpresa = "", EmpresaActual, FechaActual, EmpresaAnterior = "", FechaAnterior = "";
                double suma = 0, ValorIva, Total;
                List<DataRow> FilasAAgregar = new List<DataRow>();

                retorno.Columns.Add("Empresa");
                retorno.Columns.Add("Paciente");
                retorno.Columns.Add("FechaAtencion");
                retorno.Columns.Add("FechaFact");
                retorno.Columns.Add("DescripcionPrestacion");
                retorno.Columns.Add("Facturacion");
                retorno.Columns.Add("ValorIva");
                retorno.Columns.Add("Total");

                DataView dv = dtAUtilizar.DefaultView;
                dv.Sort = "Empresa ASC";
                dtAUtilizar = dv.ToTable();

                /*DataView dv = dtAUtilizar.DefaultView;
                dv.Sort = "Empresa ASC";
                dtAUtilizar = dv.ToTable();*/

                foreach (DataRow dr in dtAUtilizar.Rows)
                {
                    suma = suma + Convert.ToDouble(dr[5].ToString());
                    idEmpresa = dr[6].ToString();

                    Tuple<int, bool> Ivas = ObtenerIvaYDiscrimina(idEmpresa);
                    ValorIva = suma * Ivas.Item1 / 100;
                    Total = suma + (suma * Ivas.Item1 / 100);
                    suma = Math.Round(suma, 2);
                    ValorIva = Math.Round(ValorIva, 2);
                    Total = Math.Round(Total, 2);
                    EmpresaActual = ObtenerNombreEmpresa(idEmpresa);
                    if (Ivas.Item2)
                    {
                        retorno.Rows.Add(dr[0].ToString(), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()).ToString("MM/dd/yyyy"), Convert.ToDateTime(dr[3].ToString()).ToString("MM/dd/yyyy"), dr[4].ToString(), suma.ToString("F"), ValorIva.ToString("F"), Total.ToString("F"));
                    }
                    else
                    {
                        retorno.Rows.Add(dr[0].ToString(), dr[1].ToString(), Convert.ToDateTime(dr[2].ToString()).ToString("MM/dd/yyyy"), Convert.ToDateTime(dr[3].ToString()).ToString("MM/dd/yyyy"), dr[4].ToString(), Total.ToString("F"), 0.ToString(), Total.ToString("F"));
                    }
                    suma = 0;
                }
            }
            #endregion

            return retorno;
        }

        private void setearColorYBorde(Excel.Range rng)
        {
            //rng.Font.Bold = true;
            //rng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.PowderBlue);
            //rng.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium,
            //Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;            
        }

        private void AbrirFileDialogExcel()
        {
            SaveFileDialog fd = new SaveFileDialog();

            fd.Filter = "Excel (*.xlsx)|*.xlsx";

            if (Resumido)
            {
                fd.FileName = "EXPORTACION FACTURACION RESUMIDA AL " + hasta.Day + "-" + hasta.Month + "-" + hasta.Year;
            }
            else
            {
                fd.FileName = "EXPORTACION FACTURACION DETALLADA AL " + hasta.Day + "-" + hasta.Month + "-" + hasta.Year;
            }
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tbExcel.Text = fd.FileName;
            }
        }

        private void AbrirFileDialogPdf()
        {
            SaveFileDialog fd = new SaveFileDialog();

            fd.Filter = "Pdf Files|*.pdf";

            if (Resumido)
            {
                fd.FileName = "EXPORTACION FACTURACION RESUMIDA AL " + hasta.Day + "-" + hasta.Month + "-" + hasta.Year;
            }
            else
            {
                fd.FileName = "EXPORTACION FACTURACION DETALLADA AL " + hasta.Day + "-" + hasta.Month + "-" + hasta.Year;
            }
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tbPDF.Text = fd.FileName;
            }
        }

        private bool FacturaCasaMatriz(string empresa)
        {
            DataTable dt = Comunes.SQLConnector.obtenerTablaSegunConsultaString("SELECT FacturaCasaMatriz FROM [MEPRYLv2.1].[dbo].[SucursalesPorCasaMatriz] where idSucursal = '" + empresa + "'");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private string ObtieneCasaMatriz(string empresa)
        {
            DataTable dt = Comunes.SQLConnector.obtenerTablaSegunConsultaString("SELECT idCasaMatriz FROM [MEPRYLv2.1].[dbo].[SucursalesPorCasaMatriz] where idSucursal = '" + empresa + "'");
            return dt.Rows[0][0].ToString();
        }

        private void ImprimeReporte()
        {
            string printerAUsar = "";
            System.Drawing.Printing.PrinterSettings settings = new System.Drawing.Printing.PrinterSettings();
            foreach (string a in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = a;
                if (settings.IsDefaultPrinter)
                {
                    printerAUsar = settings.PrinterName;
                }
            }
            ExportacionPDFParaImprimir();
            IPrinter printer = new Printer();
            printer.PrintRawFile(printerAUsar, "C:\\Users\\Public\\Documents\\a.pdf", "a.pdf");
            System.IO.File.Delete("C:\\Users\\Public\\Documents\\a.pdf");
        }

        private void ExportacionPDFParaImprimir()
        {
            double acumSubtotal = 0, acumIva = 0, acumtotal = 0;

            iText.Kernel.Pdf.PdfWriter writer = new iText.Kernel.Pdf.PdfWriter("C:\\Users\\Public\\Documents\\a.pdf");
            iText.Kernel.Pdf.PdfDocument doc = new iText.Kernel.Pdf.PdfDocument(writer);
            iText.Layout.Document document;
            //float[] pointColumnWidths = { 150F, 150F, 150F };
            iText.Layout.Element.Table tabla;

            if (Resumido)
            {
                document = new iText.Layout.Document(doc);
                tabla = new iText.Layout.Element.Table(5);
                tabla.UseAllAvailableWidth();

                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Empresa")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Fecha Fact.")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("SubTotal")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Iva")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Total")));
            }
            else
            {
                document = new iText.Layout.Document(doc, PageSize.A4.Rotate());

                tabla = new iText.Layout.Element.Table(8);
                tabla.UseAllAvailableWidth();

                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Empresa")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Paciente")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Fecha Atencion")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Fecha Fact.")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Descripcion")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("SubTotal")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Iva")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Total")));
            }

            DataTable dt = cargarTablasExcel();
            dt = OrdenaPorEmpresaYFecha(dt);

            foreach (DataRow dr in dt.Rows)
            {
                if (Resumido)
                {
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[0].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[1].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[2].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[3].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[4].ToString())));
                    //document.Add(new iText.Layout.Element.Paragraph(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString() + " " + dr[4].ToString()));
                    acumSubtotal = acumSubtotal + Convert.ToDouble(dr[2].ToString());
                    acumIva = acumIva + Convert.ToDouble(dr[3].ToString());
                    acumtotal = acumtotal + Convert.ToDouble(dr[4].ToString());
                }
                else
                {
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[0].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[1].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[2].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[3].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[4].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[5].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[6].ToString())));
                    tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(dr[7].ToString())));
                    //document.Add(new iText.Layout.Element.Paragraph(dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString() + " " + dr[4].ToString() + " " + dr[5].ToString() + " " + dr[6].ToString() + " " + dr[7].ToString()));
                    acumSubtotal = acumSubtotal + Convert.ToDouble(dr[5].ToString());
                    acumIva = acumIva + Convert.ToDouble(dr[6].ToString());
                    acumtotal = acumtotal + Convert.ToDouble(dr[7].ToString());
                }
            }
            if (Resumido)
            {
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Totalizador")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(acumSubtotal.ToString())));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(acumIva.ToString())));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(acumtotal.ToString())));
            }
            else
            {
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Totalizador")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("")));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(acumSubtotal.ToString())));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(acumIva.ToString())));
                tabla.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(acumtotal.ToString())));
            }
            document.Add(tabla);
            document.Close();
            this.Close();
        }

        #endregion

        private void btnEmpresaAnterior_Click(object sender, EventArgs e)
        {
            CambiaAAnteriorEmpresa();
        }

        private void botImpExcel_Click(object sender, EventArgs e)
        {
            AbrirFileDialogExcel();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ImprimeReporte();
        }

        private void btnUbicacionPdf_Click(object sender, EventArgs e)
        {
            AbrirFileDialogPdf();
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            EsPDF = true;
            if (tbPDF.Text == "")
            {
                MessageBox.Show("Ingrese una direccion para el archivo");
                btnUbicacionPdf_Click(null, null);
                if (tbPDF.Text != "")
                {
                    guardarExportacionPDF();
                }
                else
                {
                    MessageBox.Show("No se selecciono una direccion para el archivo");
                }
            }
            else
            {
                guardarExportacionPDF();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EsPDF = false;
            if (tbExcel.Text == "")
            {
                MessageBox.Show("Ingrese una direccion para el archivo");
                botImpExcel_Click(null, null);
                if (tbExcel.Text != "")
                {
                    guardarExportacionExcel();
                }
                else
                {
                    MessageBox.Show("No se selecciono una direccion para el archivo");
                }
            }
            else
            {
                guardarExportacionExcel();
            }
        }
    }
}