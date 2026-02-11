using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using Excel = Microsoft.Office.Interop.Excel;
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
            if (modo == 1) { saveFileDialog.Filter = "Excel (*.xls)|*.xls"; saveFileDialog.FileName = "EXAMINADOS AL " + day + "-" + month + "-" + anio; }
            if (modo == 2) { saveFileDialog.Filter = "Excel (*.xls)|*.xls"; saveFileDialog.FileName = "LAFIJ AL " + day + "-" + month + "-" + anio; }
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

        private void setearColorYBorde(Excel.Range rng)
        {
            //rng.Font.Bold = true;
            //rng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.PowderBlue);
            //rng.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium,
            //Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;            
        }

        private void guardarExportacionExcel()
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;

            lblTarea.Visible = true;
            excel.Visible = false;
            excel.DisplayAlerts = false;
            excel.SheetsInNewWorkbook = 1;
            excelworkBook = (Microsoft.Office.Interop.Excel.Workbook)(excel.Workbooks.Add(Type.Missing));
            excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = "Hoja 1";
                        

            excelSheet.Cells[1, 1] = "LIGA";
            excelSheet.Cells[1, 2] = "CLUB";
            excelSheet.Cells[1, 3] = "JUGADOR";
            excelSheet.Cells[1, 4] = "CATEGORIA";
            excelSheet.Cells[1, 5] = "NOMBRE";
            excelSheet.Cells[1, 6] = "DICTAMEN";
            excelSheet.Cells[1, 7] = "FECHA";


            setearColorYBorde(excel.get_Range("A1", "A1"));
            setearColorYBorde(excel.get_Range("B1", "B1"));
            setearColorYBorde(excel.get_Range("C1", "C1"));
            setearColorYBorde(excel.get_Range("D1", "D1"));
            setearColorYBorde(excel.get_Range("E1", "E1"));
            setearColorYBorde(excel.get_Range("F1", "F1"));
            setearColorYBorde(excel.get_Range("G1", "G1"));



            DataTable dt = cargarTablasExcel();

            DataView dv = dt.DefaultView;
            dv.Sort = "LIGA asc, CLUB asc, CATEGORIA asc, JUGADOR asc";
            DataTable sortedDT = dv.ToTable();

            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Maximum = dt.Rows.Count;
            progressBar.Step = 1;

            int i = 1;
            int j = 0;
            string strFecha = "";
            foreach (DataRow dr in sortedDT.Rows)
            {                
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
                strFecha = "'" + dr.ItemArray[6].ToString();
                excelSheet.Cells[i + 1, j + 1] = strFecha;

                if (dr.ItemArray[5].ToString() == "APTITUD PENDIENTE" ||
                dr.ItemArray[5].ToString() == "APTO CONDICIONAL VENCIDO"
                    || dr.ItemArray[5].ToString() == "NO EFECTUADO"
                    || dr.ItemArray[5].ToString() == "NO RENOVADO")
                {
                    setearColorRojoFuente(excel.get_Range("A" + (i + 1).ToString(), "G" + (i + 1).ToString()));
                }

                i++;
                progressBar.PerformStep();
                j = 0;
            }
            excel.get_Range("A1", "G1").EntireColumn.AutoFit();
            excelworkBook.SaveAs(tbExcel.Text, Excel.XlFileFormat.xlAddIn,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excel.Quit();
            progressBar.Visible = false;
            lblTarea.Visible = false;

            MessageBox.Show("La exportación se a guardado correctamente: \n" + tbExcel.Text, "Exportar", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();
        }

        private void setearColorRojoFuente(Excel.Range rng)
        {
            rng.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
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
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;

            lblTarea.Visible = true;
            
            excel.Visible = false;
            excel.DisplayAlerts = false;
            excel.SheetsInNewWorkbook = 1;
            excelworkBook = (Microsoft.Office.Interop.Excel.Workbook)(excel.Workbooks.Add(Type.Missing));
            excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = "Hoja 1";


            excelSheet.Cells[1, 1] = "LIGA";
            excelSheet.Cells[1, 2] = "CLUB";
            excelSheet.Cells[1, 3] = "CATEGORIA";
            excelSheet.Cells[1, 4] = "APELLIDO";
            excelSheet.Cells[1, 5] = "NOMBRE";
            excelSheet.Cells[1, 6] = "FECHA DE VENC.";
            excelSheet.Cells[1, 7] = "DNI";
            
            setearColorYBorde(excel.get_Range("A1", "G1"));
            

            DataTable dt = cargarTablaLafij();

            DataView dv = dt.DefaultView;
            dv.Sort = "LIGA asc, CLUB asc";
            DataTable sortedDT = dv.ToTable();

            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Maximum = dt.Rows.Count;
            progressBar.Step = 1;

            int i = 1;
            int j = 0;
            string strFecha = "";
            foreach (DataRow dr in sortedDT.Rows)
            {
                if (dr.ItemArray[7].ToString() == "APTITUD PENDIENTE" 
                    || dr.ItemArray[7].ToString() == "APTO CONDICIONAL VENCIDO"
                    || dr.ItemArray[7].ToString() == "NO EFECTUADO"
                    || dr.ItemArray[7].ToString() == "APTO CLINICO"
                    || dr.ItemArray[7].ToString() == "NO RENOVADO")
                { }
                else
                {
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
                    strFecha = "'" + dr.ItemArray[5].ToString();
                    excelSheet.Cells[i + 1, j + 1] = strFecha;
                    j++;
                    excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[6].ToString();

                    i++;
                    progressBar.PerformStep();
                    j = 0;
                }
            }
            excel.get_Range("A1", "G1").EntireColumn.AutoFit();
            excelworkBook.SaveAs(tbLafij.Text, Excel.XlFileFormat.xlAddIn,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excel.Quit();
            progressBar.Visible = false;
            lblTarea.Visible = false;

            MessageBox.Show("La exportación se a generado correctamente en: \n" + tbLafij.Text, "Exportar", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();
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
