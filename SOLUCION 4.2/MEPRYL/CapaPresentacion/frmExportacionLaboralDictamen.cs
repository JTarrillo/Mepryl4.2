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
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmExportacionLaboralDictamen : DevExpress.XtraEditors.XtraForm
    {
        private DataTable validaciones;
        private DataTable profesionales;
        private DataTable retorno;
        private Examen laboral = new Examen();

        public frmExportacionLaboralDictamen()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            llenarCombo();
            //llenarCombo("select v.id, v.descripcion from dbo.Validaciones v where v.codigo = '90' order by CONVERT(int,codigoInterno) asc", cboDictamen , "id", "descripcion", "TODOS",2);
            DateTime fecha;
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString("select Fecha from [MEPRYLv2.1].[dbo].[ConfigFecha] where TipoFecha = 'L'");
            if (dt.Rows.Count != 0)
            {
                fecha = Convert.ToDateTime(dt.Rows[0][0].ToString());
                tpFechaDesde.Value = fecha;
            }
            tpFechaHasta.Value = DateTime.Today;
            //cbTodas.Checked = true;
        }

        private void botAbrirUbicacion_Click(object sender, EventArgs e)
        {
            abrirSaveFileDialog();
        }

        private void llenarCombo()
        {           
            DataTable dt = laboral.ConsultarEmpresa();            
            DataTable dtCombo = new DataTable();
            DataTable dtMotivo = new DataTable();
            bool blnPrimero = true;

            dtCombo.Columns.Add("id");
            dtCombo.Columns.Add("razonSocial");

            dtMotivo.Columns.Add("id");
            dtMotivo.Columns.Add("descripcion");

            foreach (DataRow r in dt.Rows)
            {
                if (blnPrimero)
                {
                    dtCombo.Rows.Add("", "TODAS");
                    blnPrimero = false;
                }

                dtCombo.Rows.Add(r.ItemArray[0].ToString(), r.ItemArray[1].ToString());
            }

            cboEmpresa.DataSource = dtCombo;
            cboEmpresa.DisplayMember = "razonSocial";
            cboEmpresa.ValueMember = "id";
                        
            blnPrimero = true;

            DataTable dtConsulta = laboral.ListarMotivoConsultaLaboral();
            foreach (DataRow r in dtConsulta.Rows)
            {
                if (blnPrimero)
                {
                    dtMotivo.Rows.Add("", "TODAS");
                    blnPrimero = false;
                }

                dtMotivo.Rows.Add(r.ItemArray[0].ToString(), r.ItemArray[1].ToString());
            }

            cboMotivo.DataSource = dtMotivo;
            cboMotivo.DisplayMember = "descripcion";
            cboMotivo.ValueMember = "id";
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
            
            saveFileDialog.FileName = "EXPORTACION DICTAMENES AL " + day + "-" + month + "-" + anio;

            if(saveFileDialog.ShowDialog() == DialogResult.OK) 
            {
                tbUbicacion.Text = saveFileDialog.FileName;
            }
        }

        private void botComenzar_Click(object sender, EventArgs e)
        {
            if (tbUbicacion.Text != "")
            {
                if (tpFechaDesde.Value <= tpFechaHasta.Value)
                {
                     guardarExportacionExcel();
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
                       
            excelSheet.Cells[1, 1] = "FECHA";
            excelSheet.Cells[1, 2] = "NRO. EX.";
            excelSheet.Cells[1, 3] = "EMPRESA";
            excelSheet.Cells[1, 4] = "MOTIVO CONSULTA";
            excelSheet.Cells[1, 5] = "DNI";
            excelSheet.Cells[1, 6] = "NOMBRE";
            excelSheet.Cells[1, 7] = "DICT. FINAL";
            excelSheet.Cells[1, 8] = "OBSERVACIONES";            

            DataTable dt = laboral.ExportarDictamenFinal(tpFechaDesde.Value.ToShortDateString(), tpFechaHasta.Value.ToShortDateString(), cboEmpresa.Text, cboMotivo.Text);

            if (dt.Rows.Count > 0)
            {

                // DataView dv = dt.DefaultView;
                // dv.Sort = "0 asc, convert(int,1) asc";
                // DataTable sortedDT = dv.ToTable();

                progressBar.Minimum = 1;
                progressBar.Maximum = dt.Rows.Count;
                progressBar.Value = 1;
                progressBar.Visible = true;

                lblTarea.Visible = true;
                lblTarea.Text = "CONSULTANDO BASE DE DATOS...";
       
                int i = 1;
                int j = 0;
                string strFecha = "";
                DateTime dtFecha;
                foreach (DataRow dr in dt.Rows)
                {
                    strFecha = "";
                    strFecha = Convert.ToDateTime(dr.ItemArray[0].ToString()).ToString("dd/MM/yyyy");
                    dtFecha = Convert.ToDateTime(dr.ItemArray[0].ToString());

                    //excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[0].ToString();
                    excelSheet.Cells[i + 1, j + 1] = dtFecha;
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

                    i++;
                    j = 0;
                    progressBar.PerformStep();
                }
                lblTarea.Visible = false;
                progressBar.Visible = false;
                excel.get_Range("A1", "H1").EntireColumn.AutoFit();
                excel.get_Range("A1", "H1").EntireColumn.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                excelworkBook.SaveAs(tbUbicacion.Text, Excel.XlFileFormat.xlAddIn,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excel.Quit();
                progressBar.Visible = false;
                MessageBox.Show("Exportación guardada correctamente en: \n" + tbUbicacion.Text, "Exportar", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se encontraron resultados para la busqueda", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
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
            //DataTable tipoEx = SQLConnector.obtenerTablaSegunConsultaString(@"Select 
            //tep.id as Id,
            //CONVERT(VARCHAR(10), c.fecha, 105) as Fecha,
            //e.descripcion as TipoExamen,
            //c.identificador as NroEx,
            //p.dni as DNI,
            //(p.apellido + ' ' + p.nombres) as Paciente,
            //p.fechaNacimiento as Nacimiento,
            //tep.imp,
            //tep.impLab,
            //tep.mail,
            //tep.inf,
            //tep.rm,
            //ep.*
            //from dbo.TipoExamenDePaciente tep inner join dbo.Consulta c on tep.idConsulta
            //= c.id inner join dbo.Paciente p on c.pacienteID = p.id
            //inner join dbo.Especialidad e on tep.idEspecialidad = e.id
            //inner join dbo.ExamenPreventiva ep on tep.id = ep.idTipoExamen
            //where convert(date,c.fecha) >= '" + tpFechaDesde.Value.ToShortDateString() +
            //"' and convert(date,c.fecha) <= '" + tpFechaHasta.Value.ToShortDateString() + "' and c.tipo = 'P'" + filtroCategoria() + @" order by
            //fecha, convert(int,c.identificador) asc");
            DataTable tipoEx = SQLConnector.obtenerTablaSegunConsultaString(@"Select 
            tep.id as Id,
            convert(date,c.fecha) as Fecha,
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
            convert(date,c.fecha), convert(int,c.identificador) asc");

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

                //if (cboDictamen.SelectedIndex != 0)
                //{
                //    if (dictamenFinal == cboDictamen.SelectedValue.ToString())
                //    {
                //        agregarRegistro(r, liga, club, dictamenFinal);
                //    }

                //}
                //else
                //{
                //    agregarRegistro(r, liga, club, dictamenFinal);
                //}
                //progressBar.PerformStep();
                

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
        }

        private string filtroCategoria()
        {
            //if (!cbTodas.Checked)
            //{
            //    string desde = tpCategoriaDesde.Value.Year.ToString();
            //    string hasta = tpCategoriaHasta.Value.Year.ToString();
            //    return " and YEAR(p.fechaNacimiento) >= " + desde + " and YEAR(p.fechaNacimiento) <= " + hasta;
            //}
            return "";
        }

        private string filtroLiga()
        {
            if (cboEmpresa.SelectedIndex != 0)
            {
                return " and l.id = '" + cboEmpresa.SelectedValue.ToString() + "'";
            }
            return "";
        }

        private string filtroClub()
        {
            if (cboMotivo.SelectedIndex != 0)
            {
                return " and c.id = '" + cboMotivo.SelectedValue.ToString() + "'";
            }
            return "";
        }

        private DataTable agregarColumnas(DataTable tabla)
        {
            //int max;
            ////if(rbCompleta.Checked){max = 85;} else {max = 16;}
            //for (int i = 0; i <= max; i++)
            //{
            //    tabla.Columns.Add(i.ToString());
            //}
            return tabla;
        }


        private void cbTodas_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbTodas.Checked)
            //{
            //    tpCategoriaDesde.Enabled = false;
            //    tpCategoriaHasta.Enabled = false;
            //}
            //else
            //{
            //    tpCategoriaDesde.Enabled = true;
            //    tpCategoriaHasta.Enabled = true;
            //}
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

            setearColorYBorde(excel.get_Range("A1", "G1"), System.Drawing.Color.White);
            setearColorYBorde(excel.get_Range("H1", "K1"), System.Drawing.Color.White);
            setearColorYBorde(excel.get_Range("L1", "L1"), System.Drawing.Color.White);
            setearColorYBorde(excel.get_Range("M1", "Q1"), System.Drawing.Color.White);
            
            DataTable dt = cargarTablasAcotada();

            //excelSheet.Range["A1", "A" + dt.Rows.Count].NumberFormat = "mm/dd/yyyy";
            // DataView dv = dt.DefaultView;
            // dv.Sort = "0 asc, convert(int,1) asc";
            // DataTable sortedDT = dv.ToTable();
            progressBar.Minimum = 1;
            progressBar.Maximum = dt.Rows.Count;
            progressBar.Value = 1;
            progressBar.Visible = true;
            lblTarea.Text = "CONSULTANDO BASE DE DATOS...";                        
            
            int i = 1;
            int j = 0;
            string strFecha = "";
            DateTime dtFecha;

            foreach (DataRow dr in dt.Rows)
            {
                strFecha = "";
                strFecha = Convert.ToDateTime(dr.ItemArray[0].ToString()).ToString("dd/MM/yyyy");
                dtFecha = Convert.ToDateTime(dr.ItemArray[0].ToString());

                excelSheet.Cells[i + 1, j + 1] = dtFecha;               
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
            convert(date,c.fecha) as Fecha,
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
            convert(date,c.fecha) ASC, convert(int,c.identificador) asc");

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
                    //if (cboDictamen.SelectedIndex != 0)
                    //{
                    //    if (dictamenFinal == cboDictamen.SelectedValue.ToString())
                    //    {
                    //            retorno.Rows.Add(Convert.ToDateTime(r.ItemArray[1].ToString()).ToShortDateString(),
                    //            r.ItemArray[3].ToString(), row.ItemArray[0].ToString(),
                    //            row.ItemArray[1].ToString(), r.ItemArray[4].ToString(),
                    //            r.ItemArray[5].ToString(), Convert.ToDateTime(r.ItemArray[6].ToString()).Year.ToString(),
                    //            filtrarValidaciones(r.ItemArray[12]), filtrarValidaciones(r.ItemArray[13]),
                    //            filtrarValidaciones(r.ItemArray[14]), filtrarValidaciones(r.ItemArray[15]),
                    //            dictamenFinal, rm, impEx, impLab, inf, enviado);
                    //    }
                    //}
                    //else
                    //{
                    //    retorno.Rows.Add(Convert.ToDateTime(r.ItemArray[1].ToString()).ToShortDateString(),
                    //          r.ItemArray[3].ToString(), row.ItemArray[0].ToString(),
                    //          row.ItemArray[1].ToString(), r.ItemArray[4].ToString(),
                    //          r.ItemArray[5].ToString(), Convert.ToDateTime(r.ItemArray[6].ToString()).Year.ToString(),
                    //          filtrarValidaciones(r.ItemArray[12]), filtrarValidaciones(r.ItemArray[13]),
                    //          filtrarValidaciones(r.ItemArray[14]), filtrarValidaciones(r.ItemArray[15]),
                    //          dictamenFinal, rm, impEx, impLab, inf, enviado);
                    //}

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
                
        private void btnIgualarFecha_Click(object sender, EventArgs e)
        {
            tpFechaHasta.Value = tpFechaDesde.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tpCategoriaHasta.Value = tpCategoriaDesde.Value;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
