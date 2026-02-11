using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Comunes;
using System.Threading;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmExportarMesaEntrada : Form
    {
        string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        CapaNegocioMepryl.MesaEntrada mesaEntrada;

        public frmExportarMesaEntrada()
        {
            InitializeComponent();
            mesaEntrada = new MesaEntrada();
            tpFechaDesde.Value = DateTime.Now;
            tpFechaHasta.Value = DateTime.Now;
            tbUbicacion.Text = mdoc + "\\" + FechaActual() + ".xls";
        }

        private void botAbrirUbicacion_Click(object sender, EventArgs e)
        {
            abrirSaveFileDialog();
        }

        private void abrirSaveFileDialog()
        {
            SaveFileDialog sfdArchivo = new SaveFileDialog();

            //int dia = tpFechaHasta.Value.Day;
            //string day = dia.ToString();
            //if (dia <= 9) { day = "0" + dia.ToString(); }
            //int mes = tpFechaHasta.Value.Month;
            //string month = mes.ToString();
            //if (mes <= 9) { month = "0" + mes.ToString(); }
            //string anio = tpFechaHasta.Value.Year.ToString();
            sfdArchivo.Filter = "Excel (*.xls)|*.xls";
            
            //sfdArchivo.FileName = day + "-" + month + "-" + anio;
            sfdArchivo.FileName = FechaActual();
            
            if (sfdArchivo.ShowDialog() == DialogResult.OK)
            {
                tbUbicacion.Text = sfdArchivo.FileName;
            }
        }

        private string FechaActual()
        {
            int dia = tpFechaHasta.Value.Day;
            string day = dia.ToString();
            if (dia <= 9) { day = "0" + dia.ToString(); }
            int mes = tpFechaHasta.Value.Month;
            string month = mes.ToString();
            if (mes <= 9) { month = "0" + mes.ToString(); }
            string anio = tpFechaHasta.Value.Year.ToString();

            return day + "-" + month + "-" + anio;
        }

        private void guardarExportacion()
        {
            string strDNI = "", strLiga = "", strClub = "";

            DataTable dt = mesaEntrada.exportarMesaEntrada(tpFechaDesde.Value, tpFechaHasta.Value);
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;

            excel.Visible = false;
            excel.DisplayAlerts = false;
            excel.SheetsInNewWorkbook = 1;
            excelworkBook = (Microsoft.Office.Interop.Excel.Workbook)(excel.Workbooks.Add(Type.Missing));
            excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = "DATOS";

            lblTarea.Visible = true;
            excelSheet.Cells[1, 1] = "FECHA";
            excelSheet.Cells[1, 2] = "NRO. EX.";
            excelSheet.Cells[1, 3] = "Tipo Ex.";
            excelSheet.Cells[1, 4] = "DNI";
            excelSheet.Cells[1, 5] = "APELLIDO";
            excelSheet.Cells[1, 6] = "NOMBRE";
            excelSheet.Cells[1, 7] = "NACIMIENTO";
            excelSheet.Cells[1, 8] = "CLUB";
            excelSheet.Cells[1, 9] = "RX";
            excelSheet.Cells[1, 10] = "Telefono";
            excelSheet.Cells[1, 11] = "Celular";
            excelSheet.Cells[1, 12] = "E-Mail";
                        
            progressBar.Minimum = 1;
            progressBar.Maximum = dt.Rows.Count;
            progressBar.Value = 1;
            progressBar.Visible = true;
            lblTarea.Text = "CREANDO EXCEL......";

            int i = 2;
            int j = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (strDNI == dr.ItemArray[3].ToString()) // validación necesaria para que no se repita el jugador
                {
                    --i;
                }

                excelSheet.Cells[i, 1] = Convert.ToDateTime(dr.ItemArray[0].ToString()).ToShortDateString();                
                excelSheet.Cells[i, 2] = dr.ItemArray[1].ToString();                
                excelSheet.Cells[i, 3] = dr.ItemArray[2].ToString();                
                excelSheet.Cells[i, 4] = dr.ItemArray[3].ToString();                
                excelSheet.Cells[i, 5] = dr.ItemArray[4].ToString();                
                excelSheet.Cells[i, 6] = dr.ItemArray[5].ToString();                
                excelSheet.Cells[i, 7] = Convert.ToDateTime(dr.ItemArray[6].ToString()).ToShortDateString();                
                excelSheet.Cells[i, 8] = dr.ItemArray[7].ToString();                
                excelSheet.Cells[i, 9] = dr.ItemArray[8].ToString();                
                excelSheet.Cells[i, 10] = dr.ItemArray[9].ToString();
                excelSheet.Cells[i, 11] = dr.ItemArray[10].ToString();
                excelSheet.Cells[i++, 12] = dr.ItemArray[11].ToString();

                if (strDNI == dr.ItemArray[3].ToString())
                {
                    // excelSheet.Cells[i-1, 3] = strLiga + "/" + dr.ItemArray[2].ToString(); // Toma la Liga
                    // excelSheet.Cells[i-1, 8] = strClub; // Toma solo un Club
                    excelSheet.Cells[i - 1, 8] = strClub + "/" + dr.ItemArray[7].ToString(); // Toma dos Clubs
                }

                progressBar.PerformStep();

                strDNI = dr.ItemArray[3].ToString();
                strLiga = dr.ItemArray[2].ToString();
                strClub = dr.ItemArray[7].ToString();
            }

            lblTarea.Visible = false;
            progressBar.Visible = false;
            excel.get_Range("A1", "L1").Cells.Font.Bold = true;
            excel.get_Range("A2", "L2").Columns.AutoFit();
            try
            {
                excelworkBook.SaveAs(tbUbicacion.Text, Excel.XlFileFormat.xlAddIn,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excel.Quit();
                progressBar.Visible = false;
                MessageBox.Show("Exportación guardada correctamente en: \n" + tbUbicacion.Text, "Exportar", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("Otra aplicación está usando el archivo \n" + tbUbicacion.Text + "\n\nCierre el archivo y vuelva a intentarlo", "Exportar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void botComenzar_Click(object sender, EventArgs e)
        {
            //Thread hilo = new Thread(new ThreadStart(guardarExportacion));
            //hilo.Start();
            guardarExportacion();
        }
    }
}
