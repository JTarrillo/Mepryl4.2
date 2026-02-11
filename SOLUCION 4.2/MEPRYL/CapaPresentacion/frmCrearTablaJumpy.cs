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
    public partial class frmCrearTablaJumpy : DevExpress.XtraEditors.XtraForm
    {
        DataTable validaciones;
        string test;
        DateTime fecha;
        string telefonosin11;
        string telefonocon11;
        string telefono;
        string strArchivo;
        string strFecha;
        string strFechaSinHora;
        string strdia, strmes,stranio;

        public frmCrearTablaJumpy()
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
            if (modo == 1) { saveFileDialog.Filter = "Excel (*.csv)|*.csv"; saveFileDialog.FileName = "EXPORTACION JUMPY AL " + day + "-" + month + "-" + anio; }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (modo == 1) { tbExcel.Text = saveFileDialog.FileName; }
            }
        }

        private void botImpExcel_Click(object sender, EventArgs e)
        {
            abrirOpenFileDialog(1);
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
            excelSheet.Name = "Hoja1";


            excelSheet.Cells[1, 1] = "fila";
            excelSheet.Cells[1, 2] = "numero";
            excelSheet.Cells[1, 3] = "nombre";
            excelSheet.Cells[1, 4] = "dni"; 
            excelSheet.Cells[1, 5] = "variable";
            excelSheet.Cells[1, 6] = "variable1";

            setearColorYBorde(excel.get_Range("A1", "A1"));
            setearColorYBorde(excel.get_Range("B1", "B1"));
            setearColorYBorde(excel.get_Range("C1", "C1"));
            setearColorYBorde(excel.get_Range("D1", "D1"));
            setearColorYBorde(excel.get_Range("E1", "E1"));
            setearColorYBorde(excel.get_Range("F1", "F1"));

            DataTable dt = cargarTablasExcel();

            DataTable dt2 = dt.Clone();
            dt2.Columns["fila"].DataType = Type.GetType("System.Int32");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["variable"].ToString()!="")
                {
                    fecha = Convert.ToDateTime(dr["variable"].ToString());
                    dr["variable"] = fecha.ToString("dd/MM/yyyy");
                    dt2.ImportRow(dr);
                }
            }
            dt2.AcceptChanges();

            DataView dv = dt2.DefaultView;
            dv.Sort = "FILA asc";
            DataTable sortedDT = dv.ToTable();

            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Maximum = dt.Rows.Count;
            progressBar.Step = 1;

            int i = 1;
            int j = 0;
            foreach (DataRow dr in sortedDT.Rows)
            {
                excelSheet.Cells[i + 1, j + 1] = Convert.ToInt64(dr.ItemArray[0].ToString());
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

                i++;
                progressBar.PerformStep();
                j = 0;
            }
            excel.get_Range("A1", "E1").EntireColumn.AutoFit();
            excelworkBook.SaveAs(tbExcel.Text, Excel.XlFileFormat.xlCSV,
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
            int FILA = 1;
            retorno.Columns.Add("fila");
            retorno.Columns.Add("numero");
            retorno.Columns.Add("nombre");
            retorno.Columns.Add("dni");
            retorno.Columns.Add("variable");
            retorno.Columns.Add("variable1");

            DataTable tipoEx = SQLConnector.obtenerTablaSegunConsultaString(@"Select tep.id as Id, (p.apellido + ' ' + p.nombres) as Paciente,p.celular as Celular,
            p.dni as DNI, p.fechaNacimiento as Nacimiento, convert(date,c.fecha) as Fecha, c.identificador as NroDeExamen
            from dbo.TipoExamenDePaciente tep 
            inner join dbo.Consulta c on tep.idConsulta= c.id
            inner join dbo.Paciente p on c.pacienteID = p.id 
            inner join dbo.ExamenPreventiva ep on tep.id = ep.idTipoExamen 
            where convert(date,c.fecha) >= '" + tpDesde.Value.ToShortDateString() +
            "' and convert(date,c.fecha) <= '" + tpHasta.Value.ToShortDateString() + "' and c.tipo = 'P'");
            foreach (DataRow r in tipoEx.Rows)
            {
                DataTable clubesPorEx = SQLConnector.obtenerTablaSegunConsultaString(@"select l.descripcion as Liga, REPLACE(c.descripcion, 'Ñ', 'N') as Club
                from dbo.clubesPorTipoExamen cte inner join dbo.Club c
                on cte.idClub = c.id inner join dbo.Liga l on c.ligaID = l.id
                where cte.idTipoExamen = '" + r.ItemArray[0].ToString() + "'");

                foreach (DataRow row in clubesPorEx.Rows)
                {
                    strArchivo = r.ItemArray[6].ToString() + " - " + r.ItemArray[3].ToString() + " - " + ConvertirFechaString(r.ItemArray[5].ToString()) + " - " + r.ItemArray[1].ToString() + ".pdf";
                    telefono = r.ItemArray[2].ToString();
                    telefono = telefono.Replace(" ","");
                    telefono = telefono.Replace("-", "");
                    test = "+";
                    if (telefono != "" )
                    {
                        if (CuantasVecesTiene(telefono, '/') != 0)
                        {
                            test = "";
                            string[] telefonossinbarra = telefono.Split('/');
                            foreach (string str in telefonossinbarra)
                            {
                                if (str!="")
                                {
                                    telefonosin11 = str.Remove(0, 2);
                                    telefonocon11 = "11" + telefonosin11;
                                    test = "";
                                    if (telefonocon11.Length==10 && !YaExisteElNumero(retorno,telefonocon11, r.ItemArray[5].ToString()))
                                    {
                                        retorno.Rows.Add(FILA, telefonocon11, r.ItemArray[1].ToString(), r.ItemArray[3].ToString(), r.ItemArray[5].ToString(), strArchivo);
                                        FILA++;
                                    }
                                }
                            }
                        }
                        else if (CuantasVecesTiene(telefono, '/') == 0)
                        {
                            telefonosin11 = telefono.Remove(0, 2);
                            telefonocon11 = "11" + telefonosin11;
                            test = "";
                            if (telefonocon11.Length == 10 && !YaExisteElNumero(retorno, telefonocon11, r.ItemArray[5].ToString()))
                            {
                                retorno.Rows.Add(FILA, telefonocon11, r.ItemArray[1].ToString(), r.ItemArray[3].ToString(), r.ItemArray[5].ToString(), strArchivo);
                                FILA++;
                            }
                        }

                    }
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

        private void btnRed_Click(object sender, EventArgs e)
        {
            int dia = tpHasta.Value.Day;
            string day = dia.ToString();
            if (dia <= 9) { day = "0" + dia.ToString(); }
            int mes = tpHasta.Value.Month;
            string month = mes.ToString();
            if (mes <= 9) { month = "0" + mes.ToString(); }
            string anio = tpHasta.Value.Year.ToString();
            tbExcel.Text = "\\\\PREV4\\Disco PC JUMPY\\Mule\\path_lectura\\EXPORTACION JUMPY AL " + day + "-" + month + "-" + anio;
        }
        public bool Tiene(string s)
        {
            bool retorno=false;
            for (int i = 0; i < s.Length; i++)
            {
                char x = Convert.ToChar("+");
                if (s[i] == x)
                {
                    return true;
                }
                else { retorno = false; }
            }
            return retorno;
        }
        public int CuantasVecesTiene(string strAAnalizar, char x)
        {
            int retorno=0;
            foreach (char c in strAAnalizar)
            {
                if (c==x)
                {
                    retorno++;
                }
            }
            return retorno;
        }
        public bool YaExisteElNumero(DataTable dtAAnalizar,string Num,string fecha)
        {
            bool retorno = false;
            foreach (DataRow dr in dtAAnalizar.Rows)
            {
                if (dr["NUMERO"].ToString()==Num && dr["VARIABLE"].ToString() == fecha)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        private string ConvertirFechaString(string Fecha)
        {
            string strFecha = "";
            DateTime dtfecha = Convert.ToDateTime(Fecha);
            string strDia = dtfecha.Day.ToString();
            string strMes = dtfecha.Month.ToString();

            if (dtfecha.Day <= 9)
                strDia = "0" + strDia;
            if (dtfecha.Month <= 9)
                strMes = "0" + strMes;

            strFecha = strDia + strMes + dtfecha.Year.ToString();

            return strFecha;
        }
    }
}
