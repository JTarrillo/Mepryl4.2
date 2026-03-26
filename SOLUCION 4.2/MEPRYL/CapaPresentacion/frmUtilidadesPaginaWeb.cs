using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data.OleDb;
using System.Threading;

namespace CapaPresentacion
{
    public partial class frmUtilidadesPaginaWeb : DevExpress.XtraEditors.XtraForm
    {
        DataTable validaciones;

        public frmUtilidadesPaginaWeb()
        {
            InitializeComponent();
            tpHasta.Value = DateTime.Today;
            validaciones = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Validaciones");
        }


        private void abrirOpenFileDialog(int modo)
        {
            int dia = tpHasta.Value.Day;
            string day = dia.ToString();
            if (dia <= 9) { day = "0" + dia.ToString(); }
            int mes = tpHasta.Value.Month;
            string month = mes.ToString();
            if (mes <= 9) { month = "0" + mes.ToString(); }
            string anio = tpHasta.Value.Year.ToString();
            if (modo == 1) { saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx"; saveFileDialog.FileName = "EXAMINADOS AL " + day + "-" + month + "-" + anio; }
            if (modo == 2) { saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx"; saveFileDialog.FileName = "LAFIJ AL " + day + "-" + month + "-" + anio; }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (modo == 1) { tbExcel.Text = saveFileDialog.FileName; }
                if (modo == 2) { tbLafij.Text = saveFileDialog.FileName; }
            }
        }

        private void botImpExcel_Click(object sender, EventArgs e)
        {
            abrirOpenFileDialog(1);
        }

        private void botImpLafij_Click(object sender, EventArgs e)
        {
            abrirOpenFileDialog(2);
        }

        private void botComenzarExcel_Click(object sender, EventArgs e)
        {
            if (tbExcel.Text != "")
            {
                if (tpDesde.Value <= tpHasta.Value)
                {
                    //Thread thread = new Thread(new ThreadStart(guardarExportacionExcel));
                    //thread.Start();     
                    guardarExportacionExcel();
                } 
                else 
                { 
                    mostrarMensajeAtencion("¡El rango de fecha seleccionado no es válido!"); 
                }
            }
            else
            {
                mostrarMensajeAtencion("¡Seleccione un nombre y una ubicación para el archivo de exportación!");
            }
        }


        private void mostrarMensajeAtencion(string mensaje)
        {
            MessageBox.Show(mensaje, "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void guardarExportacionExcel()
        {
            try
            {
                lblTarea.Visible = true;
                string[] headers = { "LIGA", "CLUB", "JUGADOR", "CATEGORIA", "NOMBRE", "DICTAMEN", "FECHA" };
                DataTable dt = cargarTablasExcel();
                DataView dv = dt.DefaultView;
                dv.Sort = "LIGA asc, CLUB asc, CATEGORIA asc, JUGADOR asc";
                DataTable sortedDT = dv.ToTable();
                progressBar.Visible = true;
                progressBar.Minimum = 1;
                progressBar.Maximum = sortedDT.Rows.Count;
                progressBar.Step = 1;
                using (var package = new ExcelPackage())
                {
                    var sheet = package.Workbook.Worksheets.Add("Hoja 1");
                    for (int col = 0; col < headers.Length; col++)
                        sheet.Cells[1, col + 1].Value = headers[col];
                    int row = 2;
                    foreach (DataRow dr in sortedDT.Rows)
                    {
                        sheet.Cells[row, 1].Value = dr.ItemArray[0];
                        sheet.Cells[row, 2].Value = dr.ItemArray[1];
                        sheet.Cells[row, 3].Value = long.TryParse(dr.ItemArray[2].ToString(), out long dniVal) ? (object)dniVal : dr.ItemArray[2];
                        sheet.Cells[row, 4].Value = int.TryParse(dr.ItemArray[3].ToString(), out int catVal) ? (object)catVal : dr.ItemArray[3];
                        sheet.Cells[row, 5].Value = dr.ItemArray[4];
                        sheet.Cells[row, 6].Value = dr.ItemArray[5];
                        if (DateTime.TryParse(dr.ItemArray[6].ToString(), out DateTime fechaVal))
                        {
                            sheet.Cells[row, 7].Value = fechaVal;
                            sheet.Cells[row, 7].Style.Numberformat.Format = "dd/mm/yyyy";
                        }
                        else { sheet.Cells[row, 7].Value = dr.ItemArray[6]; }
                        string dictamen = dr.ItemArray[5].ToString();
                        if (dictamen == "APTITUD PENDIENTE" || dictamen == "APTO CONDICIONAL VENCIDO"
                            || dictamen == "NO EFECTUADO" || dictamen == "NO RENOVADO")
                        {
                            sheet.Cells[row, 1, row, 7].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                        }
                        row++;
                        progressBar.PerformStep();
                    }
                    if (sheet.Dimension != null)
                        sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
                    package.SaveAs(new System.IO.FileInfo(tbExcel.Text));
                }
                progressBar.Visible = false;
                lblTarea.Visible = false;
                MessageBox.Show("La exportación se a guardado correctamente: \n" + tbExcel.Text, "Exportar", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                lblTarea.Visible = false;
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable cargarTablasExcel()
        {

            DataTable retorno = new DataTable();
            retorno.Columns.Add("LIGA");
            retorno.Columns.Add("CLUB");
            retorno.Columns.Add("JUGADOR");
            retorno.Columns.Add("CATEGORIA");
            retorno.Columns.Add("NOMBRE");
            retorno.Columns.Add("DICTAMEN");
            retorno.Columns.Add("FECHA");

            DataTable tipoEx = SQLConnector.obtenerTablaSegunConsultaString(@"Select tep.id as Id, (p.apellido + ' ' + p.nombres) as Paciente,
            p.dni as DNI, p.fechaNacimiento as Nacimiento, convert(date,c.fecha) as Fecha, ep.dictFinal
            from dbo.TipoExamenDePaciente tep inner join dbo.Consulta c on tep.idConsulta
            = c.id inner join dbo.Paciente p on c.pacienteID = p.id 
            inner join dbo.ExamenPreventiva ep on tep.id = ep.idTipoExamen where convert(date,c.fecha) >= '" + tpDesde.Value.ToShortDateString() +
            "' and convert(date,c.fecha) <= '" + tpHasta.Value.ToShortDateString() + "' and c.tipo = 'P'");
            foreach (DataRow r in tipoEx.Rows)
            {
                string dictFinal = "NO CARGADO";
                if (r.ItemArray[5].ToString() != string.Empty)
                {
                    DataRow[] valid = validaciones.Select("id = " + r.ItemArray[5].ToString());
                    if (valid.Length > 0) { dictFinal = valid[0][3].ToString(); }
                }
                DataTable clubesPorEx = SQLConnector.obtenerTablaSegunConsultaString(@"select l.descripcion as Liga, REPLACE(c.descripcion, 'Ñ', 'N') as Club
                from dbo.clubesPorTipoExamen cte inner join dbo.Club c
                on cte.idClub = c.id inner join dbo.Liga l on c.ligaID = l.id
                where cte.idTipoExamen = '" + r.ItemArray[0].ToString() + "'");

                foreach (DataRow row in clubesPorEx.Rows)
                {
                    retorno.Rows.Add(row.ItemArray[0].ToString(), row.ItemArray[1].ToString(),
                        r.ItemArray[2].ToString(), ((DateTime)r.ItemArray[3]).Year.ToString(),
                        r.ItemArray[1].ToString(), dictFinal, ((DateTime)r.ItemArray[4]).ToShortDateString());
                }

            }
            return retorno;
        }

        private void botComenzarLafij_Click(object sender, EventArgs e)
        {
            if (tbLafij.Text != "")
            {
                if (tpDesde.Value <= tpHasta.Value) 
                {
                    //Thread thread = new Thread(new ThreadStart(guardarExportacionLafij));
                    //thread.Start();
                    guardarExportacionLafij();
                } 
                else 
                { 
                    mostrarMensajeAtencion("¡El rango de fecha no es válido!");
                }
            }
            else
            {
                mostrarMensajeAtencion("¡Primero seleccione un nombre y una ubicación para el archivo de exportación!");
            }
        }

        private void guardarExportacionLafij()
        {
            try
            {
                lblTarea.Visible = true;
                string[] headers = { "LIGA", "CLUB", "CATEGORIA", "APELLIDO", "NOMBRE", "FECHA DE VENC.", "DNI" };
                DataTable dt = cargarTablaLafij();
                DataView dv = dt.DefaultView;
                dv.Sort = "LIGA asc, CLUB asc";
                DataTable sortedDT = dv.ToTable();
                progressBar.Visible = true;
                progressBar.Minimum = 1;
                progressBar.Maximum = dt.Rows.Count;
                progressBar.Step = 1;
                using (var package = new ExcelPackage())
                {
                    var sheet = package.Workbook.Worksheets.Add("Hoja 1");
                    for (int col = 0; col < headers.Length; col++)
                        sheet.Cells[1, col + 1].Value = headers[col];
                    int row = 2;
                    foreach (DataRow dr in sortedDT.Rows)
                    {
                        string dictamen = dr.ItemArray[7].ToString();
                        if (dictamen == "APTITUD PENDIENTE" || dictamen == "APTO CONDICIONAL VENCIDO"
                            || dictamen == "NO EFECTUADO" || dictamen == "APTO CLINICO"
                            || dictamen == "NO RENOVADO")
                        {
                            progressBar.PerformStep();
                            continue;
                        }
                        sheet.Cells[row, 1].Value = dr.ItemArray[0];
                        sheet.Cells[row, 2].Value = dr.ItemArray[1];
                        sheet.Cells[row, 3].Value = int.TryParse(dr.ItemArray[2].ToString(), out int catLafij) ? (object)catLafij : dr.ItemArray[2];
                        sheet.Cells[row, 4].Value = dr.ItemArray[3];
                        sheet.Cells[row, 5].Value = dr.ItemArray[4];
                        if (DateTime.TryParse(dr.ItemArray[5].ToString(), out DateTime vtoVal))
                        {
                            sheet.Cells[row, 6].Value = vtoVal;
                            sheet.Cells[row, 6].Style.Numberformat.Format = "dd/mm/yyyy";
                        }
                        else { sheet.Cells[row, 6].Value = dr.ItemArray[5]; }
                        sheet.Cells[row, 7].Value = long.TryParse(dr.ItemArray[6].ToString(), out long dniLafij) ? (object)dniLafij : dr.ItemArray[6];
                        row++;
                        progressBar.PerformStep();
                    }
                    if (sheet.Dimension != null)
                        sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
                    package.SaveAs(new System.IO.FileInfo(tbLafij.Text));
                }
                progressBar.Visible = false;
                lblTarea.Visible = false;
                MessageBox.Show("La exportación se a generado correctamente en: \n" + tbLafij.Text, "Exportar", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                lblTarea.Visible = false;
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable cargarTablaLafij()
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("LIGA");
            retorno.Columns.Add("CLUB");
            retorno.Columns.Add("CATEGORIA");
            retorno.Columns.Add("APELLIDO");
            retorno.Columns.Add("NOMBRE");
            retorno.Columns.Add("F.VTO.");
            retorno.Columns.Add("DNI");
            retorno.Columns.Add("DICT.FINAL");

            DataTable tipoEx = SQLConnector.obtenerTablaSegunConsultaString(@"Select tep.id as Id, p.apellido as Apellido, p.nombres as Nombre,
            p.dni as DNI, p.fechaNacimiento as Nacimiento, convert(date,c.fecha) as Fecha, ep.dictFinal 
            from dbo.TipoExamenDePaciente tep inner join dbo.Consulta c on tep.idConsulta
            = c.id inner join dbo.Paciente p on c.pacienteID = p.id 
            inner join dbo.ExamenPreventiva ep on tep.id = ep.idTipoExamen
            where convert(date,c.fecha) >= '" + tpDesde.Value.ToShortDateString() +
            "' and convert(date,c.fecha) <= '" + tpHasta.Value.ToShortDateString() + "' and c.tipo = 'P'");
            foreach (DataRow r in tipoEx.Rows)
            {
                string dictFinal = "NO CARGADO";
                if (!string.IsNullOrEmpty(r.ItemArray[6].ToString()))
                {
                    DataRow[] valid = validaciones.Select("id = " + r.ItemArray[6].ToString());
                    if (valid.Length > 0) { dictFinal = valid[0][3].ToString(); }
                }
                DataTable clubesPorEx = SQLConnector.obtenerTablaSegunConsultaString(@"select l.descripcion as Liga, REPLACE(c.descripcion, 'Ñ', 'N') as Club
                from dbo.clubesPorTipoExamen cte inner join dbo.Club c
                on cte.idClub = c.id inner join dbo.Liga l on c.ligaID = l.id
                where cte.idTipoExamen = '" + r.ItemArray[0].ToString() + "' and l.descripcion = 'L.A.F.I.J.'");
                foreach (DataRow row in clubesPorEx.Rows)
                {
                    retorno.Rows.Add(row.ItemArray[0].ToString(), row.ItemArray[1].ToString(),
                        Convert.ToDateTime(r.ItemArray[4].ToString()).Year.ToString(),
                        r.ItemArray[1].ToString(), r.ItemArray[2].ToString(),
                        Convert.ToDateTime(r.ItemArray[5].ToString()).AddYears(1).ToShortDateString(),
                        r.ItemArray[3].ToString(), dictFinal);
                }

            }
            return retorno;
        }

        private void frmUtilidadesPaginaWeb_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Recuerde: Antes de realizar las exportaciones se deben revalidar los aptos condicionales", "Revalidar Aptos Condicionales",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnIgualarFecha_Click(object sender, EventArgs e)
        {
            tpHasta.Value = tpDesde.Value;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
