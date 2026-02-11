using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace CapaPresentacion
{
    public partial class frmExportacionCompleta : Form
    {
        private DataTable validaciones;
        private DataTable profesionales;
        private DataTable retorno;

        public frmExportacionCompleta()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            llenarCombo("select id, descripcion from dbo.Liga where descripcion != 'A DESIGNAR...' order by descripcion asc", cboLiga, "id", "descripcion", "TODAS",1);
            llenarCombo("select id, descripcion from dbo.Club where descripcion != 'A DESIGNAR...' order by descripcion asc", cboClub, "id", "descripcion", "TODOS",1);
            llenarCombo("select v.id, v.descripcion from dbo.Validaciones v where v.codigo = '90' order by CONVERT(int,codigoInterno) asc", cboDictamen , "id", "descripcion", "TODOS",2);
            tpFechaHasta.Value = DateTime.Today;
            cbTodas.Checked = true;
        }

        private void botAbrirUbicacion_Click(object sender, EventArgs e)
        {
            abrirSaveFileDialog();
        }

        private void llenarCombo(string consulta, ComboBox cbo, string value, string display, string valorDefecto, int modo)
        {
            DataTable combo = new DataTable();
            combo.Columns.Add(value);
            combo.Columns.Add(display);
            if (valorDefecto != "")
            {
                combo.Rows.Add("0", valorDefecto);
            }
            DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString(consulta);
            foreach (DataRow r in tabla.Rows)
            {
                combo.Rows.Add(r.ItemArray[0].ToString(), r.ItemArray[1].ToString());
            }
            if (modo == 2) { combo.Rows.Add("0", "NO CARGADO"); }
            cbo.DataSource = combo;
            cbo.ValueMember = value;
            if (modo == 2) { cbo.ValueMember = "descripcion"; }
            cbo.DisplayMember = display;
            cbo.SelectedIndex = 0;
        }

        private void abrirSaveFileDialog()
        {
            int dia = tpFechaHasta.Value.Day;
            string day = dia.ToString();
            if (dia <= 9) { day = "0" + dia.ToString(); }
            int mes = tpFechaHasta.Value.Month;
            string month = mes.ToString();
            if (mes <= 9) { month = "0" + mes.ToString(); }
            string anio = tpFechaHasta.Value.Year.ToString();
            saveFileDialog.Filter = "Excel (*.xls)|*.xls";
            if (rbCompleta.Checked)
            {
                saveFileDialog.FileName = "EXPORTACION COMPLETA AL " + day + "-" + month + "-" + anio;
            }
            else
            {
                saveFileDialog.FileName = "EXPORTACION ACOTADA AL " + day + "-" + month + "-" + anio;
            }
            if(saveFileDialog.ShowDialog() == DialogResult.OK) 
            {
                tbUbicacion.Text = saveFileDialog.FileName;
            }
        }

        private void botComenzar_Click(object sender, EventArgs e)
        {
            if (tbUbicacion.Text != "")
            {
                if (tpFechaDesde.Value <= tpFechaHasta.Value
                    && tpCategoriaDesde.Value <= tpCategoriaHasta.Value) 
                {
                    if (rbCompleta.Checked) 
                    {
                        Thread hilo = new Thread(new ThreadStart(guardarExportacionExcel));
                        hilo.Start();
                    } 
                    else 
                    {
                        Thread hilo = new Thread(new ThreadStart(guardarExportacionAcotada));
                        hilo.Start();
                    }
                } 
                else 
                { 
                    mostrarMensajeAtencion("¡El rango seleccionado no es válido!"); 
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
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;

            excel.Visible = false;
            excel.DisplayAlerts = false;
            excel.SheetsInNewWorkbook = 1;
            excelworkBook = (Microsoft.Office.Interop.Excel.Workbook)(excel.Workbooks.Add(Type.Missing));
            excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = "Hoja 1";

            lblTarea.Visible = true;
            excelSheet.Cells[1, 1] = "FECHA";
            excelSheet.Cells[1, 2] = "NRO. EX.";
            excelSheet.Cells[1, 3] = "LIGA";
            excelSheet.Cells[1, 4] = "CLUB";
            excelSheet.Cells[1, 5] = "DNI";
            excelSheet.Cells[1, 6] = "JUGADOR";
            excelSheet.Cells[1, 7] = "CATEGORIA";
            excelSheet.Cells[1, 8] = "DICT. FINAL";
            excelSheet.Cells[1, 9] = "ANT. CLI.";
            excelSheet.Cells[1, 10] = "ANT. QUI.";
            excelSheet.Cells[1, 11] = "ANT. TRAU.";
            excelSheet.Cells[1, 12] = "TALLA";
            excelSheet.Cells[1, 13] = "PESO";
            excelSheet.Cells[1, 14] = "BIOTIPO";
            excelSheet.Cells[1, 15] = "ENTRADA AIRE";
            excelSheet.Cells[1, 16] = "RUID. AGREGADOS";
            excelSheet.Cells[1, 17] = "RUID. CARDIACOS";
            excelSheet.Cells[1, 18] = "SILENCIOS";
            excelSheet.Cells[1, 19] = "T.A. MAX.";
            excelSheet.Cells[1, 20] = "T.A. MIN";
            excelSheet.Cells[1, 21] = "PULSO";
            excelSheet.Cells[1, 22] = "ABDOMEN";
            excelSheet.Cells[1, 23] = "HERNIAS";
            excelSheet.Cells[1, 24] = "VARICES";
            excelSheet.Cells[1, 25] = "AP. GENITOUR.";
            excelSheet.Cells[1, 26] = "PIEL Y FANERAS";
            excelSheet.Cells[1, 27] = "AP. LOCOMOTOR";
            excelSheet.Cells[1, 28] = "S.N.C.";
            excelSheet.Cells[1, 29] = "OJO DER.";
            excelSheet.Cells[1, 30] = "OJO DER. C/ LENT.";
            excelSheet.Cells[1, 31] = "OJO IZQ.";
            excelSheet.Cells[1, 32] = "OJO IZQ. C/ LENT.";
            excelSheet.Cells[1, 33] = "VISION CROMAT.";
            excelSheet.Cells[1, 34] = "EX. ODONTOLOGICO";
            excelSheet.Cells[1, 35] = "OBS. CLINICAS";
            excelSheet.Cells[1, 36] = "MEDICO";
            excelSheet.Cells[1, 37] = "DICT. CLINICO";
            excelSheet.Cells[1, 38] = "G. ROJOS";
            excelSheet.Cells[1, 39] = "G. BLANCOS";
            excelSheet.Cells[1, 40] = "HEMOGLOBINA";
            excelSheet.Cells[1, 41] = "HEMATOCRITO";
            excelSheet.Cells[1, 42] = "ERITROSEDIM.";
            excelSheet.Cells[1, 43] = "OBS. SERIE ROJA";
            excelSheet.Cells[1, 44] = "N. CAYADO";
            excelSheet.Cells[1, 45] = "N. SEGMENTADOS";
            excelSheet.Cells[1, 46] = "EOSINOFILOS";
            excelSheet.Cells[1, 47] = "BASOFILOS";
            excelSheet.Cells[1, 48] = "LINFOCITOS";
            excelSheet.Cells[1, 49] = "MONOCITOS";
            excelSheet.Cells[1, 50] = "OBS. SERIE BLANCA";
            excelSheet.Cells[1, 51] = "GLUCEMIA";
            excelSheet.Cells[1, 52] = "UREMIA";
            excelSheet.Cells[1, 53] = "CHAGAS";
            excelSheet.Cells[1, 54] = "V.D.R.L.";
            excelSheet.Cells[1, 55] = "GRUPO";
            excelSheet.Cells[1, 56] = "FACTOR";
            excelSheet.Cells[1, 57] = "COLOR";
            excelSheet.Cells[1, 58] = "ASPECTO";
            excelSheet.Cells[1, 59] = "DENSIDAD";
            excelSheet.Cells[1, 60] = "PH";
            excelSheet.Cells[1, 61] = "GLUCOSA";
            excelSheet.Cells[1, 62] = "PROTEINAS";
            excelSheet.Cells[1, 63] = "HEMOGLOBINA";
            excelSheet.Cells[1, 64] = "BILLIRUBINA";
            excelSheet.Cells[1, 65] = "CELULAS";
            excelSheet.Cells[1, 66] = "LEUCOCITOS";
            excelSheet.Cells[1, 67] = "HEMATIES";
            excelSheet.Cells[1, 68] = "PIOCITOS";
            excelSheet.Cells[1, 69] = "MUCUS";
            excelSheet.Cells[1, 70] = "OTROS ORINA 1";
            excelSheet.Cells[1, 71] = "OTROS ORINA 2";
            excelSheet.Cells[1, 72] = "OBS. LABORATORIO";
            excelSheet.Cells[1, 73] = "DICT. LABORATORIO";
            excelSheet.Cells[1, 74] = "RX. TORAX";
            excelSheet.Cells[1, 75] = "RX. COLUMNA";
            excelSheet.Cells[1, 76] = "OTRAS RX.";
            excelSheet.Cells[1, 77] = "OBS. RX.";
            excelSheet.Cells[1, 78] = "DICT. RX.";
            excelSheet.Cells[1, 79] = "E.C.G.";
            excelSheet.Cells[1, 80] = "OBS. E.C.G.";
            excelSheet.Cells[1, 81] = "DICT. E.C.G.";
            excelSheet.Cells[1, 82] = "RM.";
            excelSheet.Cells[1, 83] = "IMP. EX.";
            excelSheet.Cells[1, 84] = "IMP. LAB.";
            excelSheet.Cells[1, 85] = "RETIRADO";
            excelSheet.Cells[1, 86] = "ENVIADO";



            setearColorYBorde(excel.get_Range("A1", "CH1"),System.Drawing.Color.PowderBlue);
            setearColorYBorde(excel.get_Range("H1", "H1"), System.Drawing.Color.CadetBlue);
            setearColorYBorde(excel.get_Range("AK1", "AK1"), System.Drawing.Color.CadetBlue);
            setearColorYBorde(excel.get_Range("BU1", "BU1"), System.Drawing.Color.CadetBlue);
            setearColorYBorde(excel.get_Range("BZ1", "BZ1"), System.Drawing.Color.CadetBlue);
            setearColorYBorde(excel.get_Range("CC1", "CC1"), System.Drawing.Color.CadetBlue);
            setearColorYBorde(excel.get_Range("AL1", "BD1"), System.Drawing.Color.LightSteelBlue);
            setearColorYBorde(excel.get_Range("BE1", "BT1"), System.Drawing.Color.LightSkyBlue);

  



            DataTable dt = cargarTablasExcel();

           // DataView dv = dt.DefaultView;
           // dv.Sort = "0 asc, convert(int,1) asc";
           // DataTable sortedDT = dv.ToTable();
            progressBar.Minimum = 1;
            progressBar.Maximum = dt.Rows.Count;
            progressBar.Value = 1;
            progressBar.Visible = true;
            lblTarea.Text = "CREANDO EXCEL......";
       
            int i = 1;
            int j = 0;
            foreach (DataRow dr in dt.Rows)
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
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[6].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[7].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[8].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[9].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[10].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[11].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[12].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[13].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[14].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[15].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[16].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[17].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[18].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[19].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[20].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[21].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[22].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[23].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[24].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[25].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[26].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[27].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[28].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[29].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[30].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[31].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[32].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[33].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[34].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[35].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[36].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[37].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[38].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[39].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[40].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[41].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[42].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[43].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[44].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[45].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[46].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[47].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[48].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[49].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[50].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[51].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[52].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[53].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[54].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[55].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[56].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[57].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[58].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[59].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[60].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[61].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[62].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[63].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[64].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[65].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[66].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[67].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[68].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[69].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[70].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[71].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[72].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[73].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[74].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[75].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[76].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[77].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[78].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[79].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[80].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[81].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[82].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[83].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[84].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[85].ToString();
 

                i++;
                j = 0;
                progressBar.PerformStep();
            }
            lblTarea.Visible = false;
            progressBar.Visible = false;
            excel.get_Range("A1", "CH1").EntireColumn.AutoFit();
            excel.get_Range("A1", "CH1").EntireColumn.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            excelworkBook.SaveAs(tbUbicacion.Text, Excel.XlFileFormat.xlAddIn,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excel.Quit();
            progressBar.Visible = false;
            MessageBox.Show("Exportación guardada correctamente en: \n" + tbUbicacion.Text, "Exportar", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();
        }

        private void setearColorYBorde(Excel.Range rng, System.Drawing.Color color)
        {
            rng.Font.Bold = true;
            rng.Interior.Color = System.Drawing.ColorTranslator.ToOle(color);
            rng.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium,
            Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        }

        private DataTable cargarTablasExcel()
        {
            lblTarea.Visible = true;
            progressBar.Visible = true;
            validaciones = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Validaciones");
            profesionales = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Profesional");
            retorno = new DataTable();
            retorno = agregarColumnas(retorno);
            DataTable tipoEx = SQLConnector.obtenerTablaSegunConsultaString(@"Select 
            tep.id as Id,
            c.fecha as Fecha,
            e.descripcion as TipoExamen,
            c.identificador as NroEx,
            p.dni as DNI,
            (p.apellido + ' ' + p.nombres) as Paciente,
            p.fechaNacimiento as Nacimiento,
            tep.imp,
            tep.impLab,
            tep.mail,
            tep.inf,
            tep.rm,
            ep.*
            from dbo.TipoExamenDePaciente tep inner join dbo.Consulta c on tep.idConsulta
            = c.id inner join dbo.Paciente p on c.pacienteID = p.id
            inner join dbo.Especialidad e on tep.idEspecialidad = e.id
            inner join dbo.ExamenPreventiva ep on tep.id = ep.idTipoExamen
            where convert(date,c.fecha) >= '" + tpFechaDesde.Value.ToShortDateString() +
            "' and convert(date,c.fecha) <= '" + tpFechaHasta.Value.ToShortDateString() + "' and c.tipo = 'P'" + filtroCategoria() + @" order by
            fecha asc, convert(int,c.identificador) asc");
   
            progressBar.Minimum = 1;
            progressBar.Maximum = tipoEx.Rows.Count;
            progressBar.Step = 1;
     
            foreach (DataRow r in tipoEx.Rows)
            {
                DataTable clubesPorTipoEx = SQLConnector.obtenerTablaSegunConsultaString(@"select
                l.descripcion as Liga,
                c.descripcion as Club 
                from dbo.clubesPorTipoExamen cte inner join dbo.Club c on cte.idClub = c.id
                inner join dbo.Liga l on c.ligaID = l.id where cte.idTipoExamen = '" + r.ItemArray[0].ToString() + "'" 
                + filtroLiga() + filtroClub());
                string liga = "";
                string club = "";
                foreach (DataRow row in clubesPorTipoEx.Rows)
                {
                    if (liga == string.Empty) { liga = row[0].ToString(); } else { liga = liga + " - " + row[0].ToString(); }
                    if (club == string.Empty) { club = row[1].ToString(); } else { club = club + " - " + row[1].ToString(); }
                }
                string dictamenFinal = filtrarValidaciones(r.ItemArray[87]);
                if (dictamenFinal == string.Empty) { dictamenFinal = "NO CARGADO"; }

                if (cboDictamen.SelectedIndex != 0)
                {
                    if (dictamenFinal == cboDictamen.SelectedValue.ToString())
                    {
                        agregarRegistro(r, liga, club, dictamenFinal);
                    }

                }
                else
                {
                    agregarRegistro(r, liga, club, dictamenFinal);
                }
                progressBar.PerformStep();
                

            }
            progressBar.Visible = false;
            return retorno;
        }

        private string filtrarValidaciones(object valor)
        {
            if (valor != null && valor.ToString() != string.Empty)
            {
                DataRow[] dr = validaciones.Select("id = " + valor);
                if (dr.Length > 0) { return dr[0][3].ToString(); }
            }
            return string.Empty;
        }

        private void agregarRegistro(DataRow r, string liga, string club, string dictamenFinal)
        {
            string impEx = "NO";
            string impLab = "NO";
            string enviado = "NO";
            string rm = "NO";
            string retirado = "NO";
            if(r.ItemArray[7].ToString() == "1"){impEx = "SI";}
            if(r.ItemArray[8].ToString() == "1"){impLab = "SI";}
            if(r.ItemArray[9].ToString() == "1"){enviado = "SI";}
            if(r.ItemArray[11].ToString() == "1") { rm = "SI"; }
            if(r.ItemArray[10].ToString() == "1") { retirado = "SI"; }


            retorno.Rows.Add(Convert.ToDateTime(r.ItemArray[1].ToString()).ToShortDateString(),
                r.ItemArray[3].ToString(), liga, club, r.ItemArray[4].ToString(),
                r.ItemArray[5].ToString(), Convert.ToDateTime(r.ItemArray[6].ToString()).Year.ToString(),
                dictamenFinal, r.ItemArray[40].ToString(), r.ItemArray[41].ToString(), r.ItemArray[42].ToString(),
                r.ItemArray[38].ToString(), r.ItemArray[39].ToString(), filtrarValidaciones(r.ItemArray[14]),
                filtrarValidaciones(r.ItemArray[15]),filtrarValidaciones(r.ItemArray[16]),filtrarValidaciones(r.ItemArray[17]),
                filtrarValidaciones(r.ItemArray[18]),r.ItemArray[19].ToString(),r.ItemArray[20].ToString(),r.ItemArray[21].ToString(),
                filtrarValidaciones(r.ItemArray[22]),filtrarValidaciones(r.ItemArray[23]),filtrarValidaciones(r.ItemArray[24]),
                filtrarValidaciones(r.ItemArray[25]),filtrarValidaciones(r.ItemArray[26]),filtrarValidaciones(r.ItemArray[27]),
                filtrarValidaciones(r.ItemArray[28]),filtrarValidaciones(r.ItemArray[29]).Replace("/","|"),
                filtrarValidaciones(r.ItemArray[30]).Replace("/","|"),filtrarValidaciones(r.ItemArray[31]).Replace("/","|"),
                filtrarValidaciones(r.ItemArray[32]).Replace("/","|"),filtrarValidaciones(r.ItemArray[33]),
                filtrarValidaciones(r.ItemArray[34]),r.ItemArray[36].ToString(), cargarMedico(r.ItemArray[37]),
                filtrarValidaciones(r.ItemArray[35]),r.ItemArray[43].ToString(),r.ItemArray[44].ToString(),
                r.ItemArray[45].ToString(),r.ItemArray[46].ToString(),r.ItemArray[47].ToString(),r.ItemArray[74].ToString(),
                r.ItemArray[48].ToString(),r.ItemArray[49].ToString(),r.ItemArray[50].ToString(),
                r.ItemArray[51].ToString(),r.ItemArray[52].ToString(),r.ItemArray[53].ToString(),
                r.ItemArray[75].ToString(),r.ItemArray[54].ToString(),r.ItemArray[55].ToString(),
                filtrarValidaciones(r.ItemArray[56]),filtrarValidaciones(r.ItemArray[57]),filtrarValidaciones(r.ItemArray[58]),
                filtrarValidaciones(r.ItemArray[59]),filtrarValidaciones(r.ItemArray[60]),filtrarValidaciones(r.ItemArray[61]),
                r.ItemArray[62].ToString(),r.ItemArray[63].ToString(), filtrarValidaciones(r.ItemArray[64]),
                filtrarValidaciones(r.ItemArray[65]),filtrarValidaciones(r.ItemArray[66]),filtrarValidaciones(r.ItemArray[67]),
                filtrarValidaciones(r.ItemArray[68]),filtrarValidaciones(r.ItemArray[69]),filtrarValidaciones(r.ItemArray[70]),
                filtrarValidaciones(r.ItemArray[71]),filtrarValidaciones(r.ItemArray[72]),
                r.ItemArray[76].ToString(),r.ItemArray[77].ToString(),r.ItemArray[78].ToString(),
                filtrarValidaciones(r.ItemArray[73]),filtrarValidaciones(r.ItemArray[79]),filtrarValidaciones(r.ItemArray[80]),
                r.ItemArray[82].ToString(),r.ItemArray[83].ToString(),filtrarValidaciones(r.ItemArray[81]),
                filtrarValidaciones(r.ItemArray[84]),r.ItemArray[86].ToString(), filtrarValidaciones(r.ItemArray[85]),
                rm, impEx, impLab, retirado, enviado);



            /*
         
                dictamenFinal, obtenerValor(valoresPorEx, 27, 2),
                obtenerValor(valoresPorEx, 28, 2), obtenerValor(valoresPorEx, 29, 2), obtenerValor(valoresPorEx, 25, 2),
                obtenerValor(valoresPorEx, 26, 2), obtenerValor(valoresPorEx, 1, 1), obtenerValor(valoresPorEx, 2, 1),
                obtenerValor(valoresPorEx, 3, 1), obtenerValor(valoresPorEx, 4, 1), obtenerValor(valoresPorEx, 5, 1),
                obtenerValor(valoresPorEx, 6, 2), obtenerValor(valoresPorEx, 7, 2), obtenerValor(valoresPorEx, 8, 2),
                obtenerValor(valoresPorEx, 9, 1), obtenerValor(valoresPorEx, 10, 1), obtenerValor(valoresPorEx, 11, 1),
                obtenerValor(valoresPorEx, 12, 1), obtenerValor(valoresPorEx, 13, 1), obtenerValor(valoresPorEx, 14, 1),
                obtenerValor(valoresPorEx, 15, 1), obtenerValor(valoresPorEx, 16, 1).Replace("/", "|"), obtenerValor(valoresPorEx, 17, 1).Replace("/", "|"),
                obtenerValor(valoresPorEx, 18, 1).Replace("/", "|"), obtenerValor(valoresPorEx, 19, 1).Replace("/", "|"), obtenerValor(valoresPorEx, 20, 1),
                obtenerValor(valoresPorEx, 21, 1), obtenerValor(valoresPorEx, 23, 2), obtenerValor(valoresPorEx, 24, 3),
                obtenerValor(valoresPorEx, 22, 1), obtenerValor(valoresPorEx, 30, 2), obtenerValor(valoresPorEx, 31, 2),
                obtenerValor(valoresPorEx, 32, 2), obtenerValor(valoresPorEx, 33, 2), obtenerValor(valoresPorEx, 34, 2),
                obtenerValor(valoresPorEx, 61, 2), obtenerValor(valoresPorEx, 35, 2), obtenerValor(valoresPorEx, 36, 2),
                obtenerValor(valoresPorEx, 37, 2), obtenerValor(valoresPorEx, 38, 2), obtenerValor(valoresPorEx, 39, 2),
                obtenerValor(valoresPorEx, 40, 2), obtenerValor(valoresPorEx, 62, 2), obtenerValor(valoresPorEx, 41, 2),
                obtenerValor(valoresPorEx, 42, 2), obtenerValor(valoresPorEx, 43, 1), obtenerValor(valoresPorEx, 44, 1),
                obtenerValor(valoresPorEx, 45, 1), obtenerValor(valoresPorEx, 46, 1), obtenerValor(valoresPorEx, 47, 1),
                obtenerValor(valoresPorEx, 48, 1), obtenerValor(valoresPorEx, 49, 2), obtenerValor(valoresPorEx, 50, 2),
                obtenerValor(valoresPorEx, 51, 1), obtenerValor(valoresPorEx, 52, 1), obtenerValor(valoresPorEx, 53, 1),
                obtenerValor(valoresPorEx, 54, 1), obtenerValor(valoresPorEx, 55, 1), obtenerValor(valoresPorEx, 56, 1),
                obtenerValor(valoresPorEx, 57, 1), obtenerValor(valoresPorEx, 58, 1), obtenerValor(valoresPorEx, 59, 1),
                obtenerValor(valoresPorEx, 63, 2), obtenerValor(valoresPorEx, 64, 2), obtenerValor(valoresPorEx, 65, 2),
                obtenerValor(valoresPorEx, 60, 1), obtenerValor(valoresPorEx, 70, 1), obtenerValor(valoresPorEx, 71, 1),
                obtenerValor(valoresPorEx, 73, 2), obtenerValor(valoresPorEx, 74, 2), obtenerValor(valoresPorEx, 72, 1),
                obtenerValor(valoresPorEx, 80, 1), obtenerValor(valoresPorEx, 82, 2), obtenerValor(valoresPorEx, 81, 1),
                rm, impEx, impLab, retirado, enviado);
              */
        }



        private string filtroCategoria()
        {
            if (!cbTodas.Checked)
            {
                string desde = tpCategoriaDesde.Value.Year.ToString();
                string hasta = tpCategoriaHasta.Value.Year.ToString();
                return " and YEAR(p.fechaNacimiento) >= " + desde + " and YEAR(p.fechaNacimiento) <= " + hasta;
            }
            return "";
        }

        private string filtroLiga()
        {
            if (cboLiga.SelectedIndex != 0)
            {
                return " and l.id = '" + cboLiga.SelectedValue.ToString() + "'";
            }
            return "";
        }

        private string filtroClub()
        {
            if (cboClub.SelectedIndex != 0)
            {
                return " and c.id = '" + cboClub.SelectedValue.ToString() + "'";
            }
            return "";
        }

        private DataTable agregarColumnas(DataTable tabla)
        {
            int max;
            if(rbCompleta.Checked){max = 85;} else {max = 16;}
            for (int i = 0; i <= max; i++)
            {
                tabla.Columns.Add(i.ToString());
            }
            return tabla;
        }


        private void cbTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodas.Checked)
            {
                tpCategoriaDesde.Enabled = false;
                tpCategoriaHasta.Enabled = false;
            }
            else
            {
                tpCategoriaDesde.Enabled = true;
                tpCategoriaHasta.Enabled = true;
            }
        }


        private void cboLiga_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLiga.SelectedIndex == 0)
            {
                llenarCombo("select id, descripcion from dbo.Club where descripcion != 'A DESIGNAR...' order by descripcion asc", cboClub, "id", "descripcion", "TODOS",1);
            }
            else
            {
                string id = ((DataRowView)cboLiga.SelectedItem).Row[0].ToString();
                llenarCombo(@"select id, descripcion from dbo.Club where descripcion != 'A DESIGNAR...' and
                ligaID = '" + id + "' order by descripcion asc", cboClub, "id", "descripcion", "TODOS",1);

            }
        }

        private void guardarExportacionAcotada()
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;

            excel.Visible = false;
            excel.DisplayAlerts = false;
            excel.SheetsInNewWorkbook = 1;
            excelworkBook = (Microsoft.Office.Interop.Excel.Workbook)(excel.Workbooks.Add(Type.Missing));
            excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = "Hoja 1";

            lblTarea.Visible = true;
            excelSheet.Cells[1, 1] = "FECHA";
            excelSheet.Cells[1, 2] = "NRO. EX.";
            excelSheet.Cells[1, 3] = "LIGA";
            excelSheet.Cells[1, 4] = "CLUB";
            excelSheet.Cells[1, 5] = "DNI";
            excelSheet.Cells[1, 6] = "JUGADOR";
            excelSheet.Cells[1, 7] = "CATEGORIA";
            excelSheet.Cells[1, 8] = "DICT. CLI";
            excelSheet.Cells[1, 9] = "DICT. LAB";
            excelSheet.Cells[1, 10] = "DICT. RX";
            excelSheet.Cells[1, 11] = "DICT. CAR";
            excelSheet.Cells[1, 12] = "DICT. FINAL";
            excelSheet.Cells[1, 13] = "RM.";
            excelSheet.Cells[1, 14] = "IMP. EX.";
            excelSheet.Cells[1, 15] = "IMP. LAB.";
            excelSheet.Cells[1, 16] = "RETIRADO";
            excelSheet.Cells[1, 17] = "ENVIADO";



            setearColorYBorde(excel.get_Range("A1", "G1"), System.Drawing.Color.PowderBlue);
            setearColorYBorde(excel.get_Range("H1", "K1"), System.Drawing.Color.CadetBlue);
            setearColorYBorde(excel.get_Range("L1", "L1"), System.Drawing.Color.CadetBlue);
            setearColorYBorde(excel.get_Range("M1", "Q1"), System.Drawing.Color.PowderBlue);
  



            DataTable dt = cargarTablasAcotada();

            // DataView dv = dt.DefaultView;
            // dv.Sort = "0 asc, convert(int,1) asc";
            // DataTable sortedDT = dv.ToTable();
            progressBar.Minimum = 1;
            progressBar.Maximum = dt.Rows.Count;
            progressBar.Value = 1;
            progressBar.Visible = true;
            lblTarea.Text = "CREANDO EXCEL......";

            int i = 1;
            int j = 0;
            foreach (DataRow dr in dt.Rows)
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
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[6].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[7].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[8].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[9].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[10].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[11].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[12].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[13].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[14].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[15].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[16].ToString();
                i++;
                j = 0;
                progressBar.PerformStep();
            }
            lblTarea.Visible = false;
            progressBar.Visible = false;
            excel.get_Range("A1", "Q1").EntireColumn.AutoFit();
            excel.get_Range("A1", "Q1").EntireColumn.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            excelworkBook.SaveAs(tbUbicacion.Text, Excel.XlFileFormat.xlAddIn,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excel.Quit();
            progressBar.Visible = false;
            MessageBox.Show("Exportación guardada correctamente en: \n" + tbUbicacion.Text, "Exportar", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();


        }

        private DataTable cargarTablasAcotada()
        {
            lblTarea.Visible = true;
            progressBar.Visible = true;
            validaciones = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Validaciones");
            profesionales = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Profesional");
            DataTable retorno = new DataTable();
            retorno = agregarColumnas(retorno);
            DataTable tipoEx = SQLConnector.obtenerTablaSegunConsultaString(@"Select 
            tep.id as Id,
            c.fecha as Fecha,
            e.descripcion as TipoExamen,
            c.identificador as NroEx,
            p.dni as DNI,
            (p.apellido + ' ' + p.nombres) as Paciente,
            p.fechaNacimiento as Nacimiento,
            tep.imp,
            tep.impLab,
            tep.mail,
            tep.inf,
            tep.rm,
            ep.dictClinico,
            ep.dictLab,
            ep.dictRx,
            ep.dictCar,
            ep.dictFinal
            from dbo.TipoExamenDePaciente tep inner join dbo.Consulta c on tep.idConsulta
            = c.id inner join dbo.Paciente p on c.pacienteID = p.id
            inner join dbo.Especialidad e on tep.idEspecialidad = e.id 
            inner join dbo.ExamenPreventiva ep on tep.id = ep.idTipoExamen where convert(date,c.fecha) >= '" + tpFechaDesde.Value.ToShortDateString() +
            "' and convert(date,c.fecha) <= '" + tpFechaHasta.Value.ToShortDateString() + "' and c.tipo = 'P'" + filtroCategoria() + @" order by
            fecha asc, convert(int,c.identificador) asc");

            progressBar.Minimum = 1;
            progressBar.Maximum = tipoEx.Rows.Count;
            progressBar.Step = 1;

            foreach (DataRow r in tipoEx.Rows)
            {
                DataTable clubesPorTipoEx = SQLConnector.obtenerTablaSegunConsultaString(@"select
                l.descripcion as Liga,
                c.descripcion as Club 
                from dbo.clubesPorTipoExamen cte inner join dbo.Club c on cte.idClub = c.id
                inner join dbo.Liga l on c.ligaID = l.id where cte.idTipoExamen = '" + r.ItemArray[0].ToString() + "'"
                + filtroLiga() + filtroClub());
                string impEx = "NO";
                string impLab = "NO";
                string enviado = "NO";
                string rm = "NO";
                string inf = "NO";
                if (r.ItemArray[7].ToString() == "1") { impEx = "SI"; }
                if (r.ItemArray[8].ToString() == "1") { impLab = "SI"; }
                if (r.ItemArray[9].ToString() == "1") { enviado = "SI"; }
                if (r.ItemArray[10].ToString() == "1") { inf = "SI"; }
                if (r.ItemArray[11].ToString() == "1") { rm = "SI"; }
                foreach (DataRow row in clubesPorTipoEx.Rows)
                {
                    string dictamenFinal = filtrarValidaciones(r.ItemArray[16]);
                    if (dictamenFinal == "") { dictamenFinal = "NO CARGADO"; }
                    if (cboDictamen.SelectedIndex != 0)
                    {
                        if (dictamenFinal == cboDictamen.SelectedValue.ToString())
                        {
                                retorno.Rows.Add(Convert.ToDateTime(r.ItemArray[1].ToString()).ToShortDateString(),
                                r.ItemArray[3].ToString(), row.ItemArray[0].ToString(),
                                row.ItemArray[1].ToString(), r.ItemArray[4].ToString(),
                                r.ItemArray[5].ToString(), Convert.ToDateTime(r.ItemArray[6].ToString()).Year.ToString(),
                                filtrarValidaciones(r.ItemArray[12]), filtrarValidaciones(r.ItemArray[13]),
                                filtrarValidaciones(r.ItemArray[14]), filtrarValidaciones(r.ItemArray[15]),
                                dictamenFinal, rm, impEx, impLab, inf, enviado);
                        }
                    }
                    else
                    {
                        retorno.Rows.Add(Convert.ToDateTime(r.ItemArray[1].ToString()).ToShortDateString(),
                              r.ItemArray[3].ToString(), row.ItemArray[0].ToString(),
                              row.ItemArray[1].ToString(), r.ItemArray[4].ToString(),
                              r.ItemArray[5].ToString(), Convert.ToDateTime(r.ItemArray[6].ToString()).Year.ToString(),
                              filtrarValidaciones(r.ItemArray[12]), filtrarValidaciones(r.ItemArray[13]),
                              filtrarValidaciones(r.ItemArray[14]), filtrarValidaciones(r.ItemArray[15]),
                              dictamenFinal, rm, impEx, impLab, inf, enviado);
                    }

                }
                progressBar.PerformStep();

            }
            progressBar.Visible = false;
            return retorno;
        }

        private string cargarMedico(object valor)
        {
            if (valor != null && valor.ToString() != string.Empty)
            {
                DataRow[] dr = profesionales.Select("id = '" + valor.ToString() + "'");
                if (dr.Length > 0) { return dr[0][2].ToString() + " " + dr[0][3].ToString(); }
            }
            return string.Empty;
        }


    }
}
