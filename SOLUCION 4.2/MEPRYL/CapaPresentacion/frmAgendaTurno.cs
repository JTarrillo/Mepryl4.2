using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Comunes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmAgendaTurno : DevExpress.XtraEditors.XtraForm
    {
        public frmAgendaTurno()
        {
            InitializeComponent();
            tpDesde.Value = DateTime.Today;
            tpHasta.Value = DateTime.Today;
            cargarCombos();
        }

        public frmAgendaTurno(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            tpDesde.Value = DateTime.Today;
            tpHasta.Value = DateTime.Today;
            cargarCombos();
        }

        private void cargarCombos()
        {
            llenarCombo("select id, descripcion from dbo.Especialidad order by convert(int,codigo) asc", cboExamen, "id", "descripcion", "TODOS");
            llenarCombo("select id, descripcion from dbo.Liga where descripcion != 'A DESIGNAR...' order by descripcion asc", cboLiga, "id", "descripcion", "TODAS");
            llenarCombo("select id, descripcion from dbo.Club where descripcion != 'A DESIGNAR...' order by descripcion asc", cboClub, "id", "descripcion", "TODOS");
            comboEstado.SelectedIndex = 0;
        }

        private void llenarCombo(string consulta, ComboBox cbo, string value, string display, string valorDefecto)
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
            cbo.DataSource = combo;
            cbo.ValueMember = display;
            cbo.DisplayMember = display;
            cbo.SelectedIndex = 0;
        }

        private void cargarAgenda()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("IdTurno");
            tabla.Columns.Add("Fecha");
            tabla.Columns.Add("Hora");
            tabla.Columns.Add("TipoExamen");
            tabla.Columns.Add("IdPaciente");
            tabla.Columns.Add("Dni");
            tabla.Columns.Add("Paciente");
            tabla.Columns.Add("Categoria");
            tabla.Columns.Add("Liga/Empresa");
            tabla.Columns.Add("Club");
            tabla.Columns.Add("ExClinico");
            tabla.Columns.Add("Laboratorio");
            tabla.Columns.Add("RX");
            tabla.Columns.Add("EstComplementario");
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select t.id,t.fecha,t.horaReferencia,e.descripcion, 
            t.pacienteID, t.reservado, t.reserva from dbo.Turno t inner join dbo.Horario h on t.horarioID = h.id inner join 
            dbo.Especialidad e on h.especialidadID = e.id
            where convert(date,t.fecha) >= '" + tpDesde.Value.ToShortDateString() + @"' and
            convert (date,t.fecha) <= '" + tpHasta.Value.ToShortDateString() + @"' and t.habilitado = 1 order by t.fecha asc, t.hora asc");
            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Maximum = consulta.Rows.Count;
            foreach (DataRow r in consulta.Rows)
            {
                try // GRV - Ramírez - controlar filas vacias en la posición 0
                {
                    string liga = "";
                    string club = "";

                    if (r.ItemArray[4].ToString() != "00000000-0000-0000-0000-000000000000"
                        && comboEstado.SelectedIndex == 0)
                    {
                        DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString(@"select p.id, p.dni, p.apellido, p.nombres, p.fechaNacimiento, p.empresaID from 
                        dbo.Paciente p where p.id = '" + r.ItemArray[4].ToString() + "'");

                        if (paciente.Rows.Count <= 0)
                        {
                            paciente = SQLConnector.obtenerTablaSegunConsultaString(@"select top 1 p.id, p.dni, p.apellido, p.nombres, p.fechaNacimiento, EPP.idEmpresa 
                                            FROM dbo.PacienteLaboral p 
                                            INNER JOIN dbo.EmpresasPorPaciente EPP ON p.id = EPP.idPaciente
                                            where p.id = '" + r.ItemArray[4].ToString() + "'");
                        }

                        DataTable ligaYClub = SQLConnector.obtenerTablaSegunConsultaString(@"select l.descripcion, c.descripcion from dbo.clubesPorPaciente 
                    cpp inner join dbo.Club c on cpp.club = c.id inner join dbo.Liga l on c.ligaID = l.id where cpp.paciente = '" +
                               r.ItemArray[4].ToString() + "'");
                        if (ligaYClub.Rows.Count > 0)
                        {
                            liga = ligaYClub.Rows[0].ItemArray[0].ToString();
                            club = ligaYClub.Rows[0].ItemArray[1].ToString();
                        }
                        else
                        {
                            DataTable empresa = SQLConnector.obtenerTablaSegunConsultaString(@"select e.razonSocial from dbo.Empresa e
                                where id = '" + paciente.Rows[0].ItemArray[5].ToString() + "'");
                            if (empresa.Rows.Count > 0)
                            {
                                liga = empresa.Rows[0].ItemArray[0].ToString();
                            }
                        }

                        if (string.IsNullOrEmpty(paciente.Rows[0].ItemArray[4].ToString()))
                            paciente.Rows[0][4] = Convert.ToDateTime("01/01/1900");

                        string exClinico = "", laboratorio = "", rx = "", estComplementario = "";
                        cargarEstudiosPorTurno(r.ItemArray[0].ToString(), out exClinico, out laboratorio, out rx, out estComplementario);

                        tabla.Rows.Add(r.ItemArray[0].ToString(), ((DateTime)r.ItemArray[1]).ToShortDateString(), r.ItemArray[2].ToString(),
                            r.ItemArray[3].ToString(), paciente.Rows[0].ItemArray[0].ToString(), paciente.Rows[0].ItemArray[1].ToString(), paciente.Rows[0].ItemArray[2].ToString() + " " + paciente.Rows[0].ItemArray[3].ToString(),
                           ((DateTime)paciente.Rows[0].ItemArray[4]).Year.ToString(), liga, club, exClinico, laboratorio, rx, estComplementario);
                    }
                    else
                    {
                        if (r.ItemArray[5].ToString() == "1" && comboEstado.SelectedIndex == 0)
                        {
                            club = r.ItemArray[6].ToString();
                            tabla.Rows.Add(r.ItemArray[0].ToString(), ((DateTime)r.ItemArray[1]).ToShortDateString(), r.ItemArray[2].ToString(),
                            r.ItemArray[3].ToString(), "", "", "RESERVA", "", liga, club, "", "", "", "");
                        }
                        if (comboEstado.SelectedIndex == 1 && r.ItemArray[4].ToString() == "00000000-0000-0000-0000-000000000000"
                            && r.ItemArray[5].ToString() != "1")
                        {
                            tabla.Rows.Add(r.ItemArray[0].ToString(), ((DateTime)r.ItemArray[1]).ToShortDateString(), r.ItemArray[2].ToString(),
                            r.ItemArray[3].ToString(), "", "", "", "", "", "", "", "", "", "");
                        }
                    }

                    progressBar.PerformStep();
                }
                catch (IndexOutOfRangeException ex)
                {

                }
            }

            filtrarTablaYCargarDataGrid(tabla);

            //string strSQL = "";
            //DateTime dtFecha;
            //dtFecha = tpDesde.Value;

            //strSQL = @"select TOP 200 c.id as IdConsulta, c.pacienteID as IdPaciente, 
            //            te.id as IdTipoExamen, te.idTurno as IdTurno, CONVERT(date, c.fecha) as Fecha, c.identificador as 'Nº Orden',
            //            e.descripcion as 'Tipo de Exámen', PA.Apellidos + ' ' + PA.Nombres as Nombre, te.modificado, c.observaciones as Observaciones
            //            from Consulta c
            //            inner
            //            join dbo.TipoExamenDePaciente te on te.idConsulta = c.id
            //            inner
            //            join dbo.Especialidad e on te.idEspecialidad = e.id
            //            INNER JOIN dbo.vwConsultarPacientes PA ON PA.id = c.pacienteID
            //            where convert(Date, c.fecha) = '" + dtFecha.ToString() + @"' and c.valido = '1' and c.nroOrden != '0' and c.tipo != 'V' order by c.nroOrden";

            //DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            //dgv.DataSource = paciente;
            //dgv.Columns[0].Visible = false;
            //dgv.Columns[1].Visible = false;
            //dgv.Columns[2].Visible = false;
            //dgv.Columns[3].Visible = false;

        }

        private void filtrarTablaYCargarDataGrid(DataTable tabla)
        {
            DataTable tablaFiltrada = new DataTable();
            tablaFiltrada.Columns.Add("IdTurno");
            tablaFiltrada.Columns.Add("Fecha");
            tablaFiltrada.Columns.Add("Hora");
            tablaFiltrada.Columns.Add("TipoExamen");
            tablaFiltrada.Columns.Add("IdPaciente");
            tablaFiltrada.Columns.Add("Dni");
            tablaFiltrada.Columns.Add("Paciente");
            tablaFiltrada.Columns.Add("Categoria");
            tablaFiltrada.Columns.Add("Liga/Empresa");
            tablaFiltrada.Columns.Add("Club");
            tablaFiltrada.Columns.Add("ExClinico");
            tablaFiltrada.Columns.Add("Laboratorio");
            tablaFiltrada.Columns.Add("RX");
            tablaFiltrada.Columns.Add("EstComplementario");

            string cadenaFiltro = "";
            cadenaFiltro = setearCadena(cadenaFiltro, cboExamen, "TipoExamen");
            cadenaFiltro = setearCadena(cadenaFiltro, cboLiga, "[Liga/Empresa]");
            cadenaFiltro = setearCadena(cadenaFiltro, cboClub, "Club");
            cadenaFiltro = filtrarCategoria(cadenaFiltro, tbCategoria.Text, tbCategoriaHasta.Text);
            DataRow[] rows = tabla.Select(cadenaFiltro);
            foreach (DataRow r in rows)
            {
                tablaFiltrada.Rows.Add(r.ItemArray[0], r.ItemArray[1],
                    r.ItemArray[2], r.ItemArray[3], r.ItemArray[4], r.ItemArray[5],
                    r.ItemArray[6], r.ItemArray[7], r.ItemArray[8], r.ItemArray[9], r.ItemArray[10], r.ItemArray[11], r.ItemArray[12], r.ItemArray[13]);
            }
            dgv.DataSource = null;
            dgv.DataSource = tablaFiltrada;
            dgv.Columns[0].Visible = false;
            dgv.Columns[4].Visible = false;
            tbTotal.Text = "Total Registros: " + dgv.Rows.Count.ToString();
            progressBar.Visible = false;
        }

        private string setearCadena(string cadena, ComboBox cb, string nombreColumna)
        {
            if (cb.SelectedIndex != 0)
            {
                if (cadena == "")
                {
                    cadena = nombreColumna + " = '" + cb.SelectedValue + "'";
                }
                else
                {
                    cadena = cadena + " and " + nombreColumna + " = '" + cb.SelectedValue + "'";
                }
                return cadena;
            }
            return cadena;

        }

        private string filtrarCategoria(string cadena, string año, string hasta)
        {
            if (año != "")
            {
                if (cadena == "")
                {
                    cadena = "Categoria >= '" + año + "' and Categoria <= '" + hasta + "'";
                }
                else
                {
                    cadena = cadena + " and Categoria >= '" + año + "' and Categoria <= '" + hasta + "'";
                }
                return cadena;

            }
            return cadena;
        }

        // ✅ Método para cargar estudios por turno categorizados en 4 columnas
        private void cargarEstudiosPorTurno(string idTurno, out string exClinico, out string laboratorio, out string rx, out string estComplementario)
        {
            exClinico = "";
            laboratorio = "";
            rx = "";
            estComplementario = "";

            try
            {
                // Obtener TipoExamenDePaciente asociado al Turno
                DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"
                    SELECT TOP 1 id FROM dbo.TipoExamenDePaciente 
                    WHERE idTurno = '" + idTurno + "'");

                if (tipoExamen.Rows.Count <= 0)
                    return;

                string idTipoExamen = tipoExamen.Rows[0].ItemArray[0].ToString();

                // Obtener EstudiosPorExamen para ese TipoExamenDePaciente
                DataTable estudiosExamen = SQLConnector.obtenerTablaSegunConsultaString(@"
                    SELECT * FROM dbo.EstudiosPorExamen 
                    WHERE idTipoExamen = '" + idTipoExamen + "'");

                if (estudiosExamen.Rows.Count <= 0)
                    return;

                DataRow estudios = estudiosExamen.Rows[0];

                // Recorrer columnas item1 a item207 (booleanos representados como bit)
                for (int i = 1; i <= 207; i++)
                {
                    string columnName = "item" + i;
                    if (estudios.Table.Columns.Contains(columnName))
                    {
                        object valor = estudios[columnName];
                        // Verificar si el bit está activado (true / 1)
                        int estaActivo = 0;
                        if (valor != DBNull.Value)
                        {
                            estaActivo = Convert.ToInt32(valor);
                        }

                        if (estaActivo == 1)
                        {
                            // Obtener la descripción del item y su categoría desde tabla Items
                            DataTable item = SQLConnector.obtenerTablaSegunConsultaString(@"
                                SELECT nombreInformes, ordenFormulario FROM dbo.Items WHERE id = " + i);

                            if (item.Rows.Count > 0)
                            {
                                string descripcion = item.Rows[0].ItemArray[0].ToString();
                                int ordenFormulario = Convert.ToInt32(item.Rows[0].ItemArray[1]);

                                // Categorizar según ordenFormulario
                                if (ordenFormulario == 1)
                                {
                                    if (exClinico == "")
                                        exClinico = descripcion;
                                    else
                                        exClinico += " - " + descripcion;
                                }
                                else if (ordenFormulario >= 2 && ordenFormulario <= 7)
                                {
                                    if (laboratorio == "")
                                        laboratorio = descripcion;
                                    else
                                        laboratorio += " - " + descripcion;
                                }
                                else if (ordenFormulario == 8)
                                {
                                    if (rx == "")
                                        rx = descripcion;
                                    else
                                        rx += " - " + descripcion;
                                }
                                else if (ordenFormulario >= 9)
                                {
                                    if (estComplementario == "")
                                        estComplementario = descripcion;
                                    else
                                        estComplementario += " - " + descripcion;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                exClinico = "Error: " + ex.Message;
            }
        }

        private void botBuscarFecha_Click(object sender, EventArgs e)
        {
            //if (tpHasta.Value > DateTime.Now)
            //    MessageBox.Show("¡Fecha de búsqueda "+ tpHasta.Value.ToString("dd/MM/yyyy") + " no puede ser mayor a la fecha actual!", "Atención",
            //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //else
            cargarAgenda();
        }

        private void cboLiga_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLiga.SelectedIndex == 0)
            {
                llenarCombo("select id, descripcion from dbo.Club where descripcion != 'A DESIGNAR...' order by descripcion asc", cboClub, "id", "descripcion", "TODOS");
            }
            else
            {
                string id = ((DataRowView)cboLiga.SelectedItem).Row[0].ToString();
                llenarCombo(@"select id, descripcion from dbo.Club where descripcion != 'A DESIGNAR...' and
                ligaID = '" + id + "' order by descripcion asc", cboClub, "id", "descripcion", "TODOS");

            }
        }

        private void butExportarListado_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "ExportacionAgendaTurnos";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                comenzarExportacion();
            }
        }

        private void comenzarExportacion()
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
            excelSheet.Cells[1, 2] = "HORA";
            excelSheet.Cells[1, 3] = "TIPO DE EXAMEN";
            excelSheet.Cells[1, 4] = "DNI";
            excelSheet.Cells[1, 5] = "PACIENTE";
            excelSheet.Cells[1, 6] = "CATEGORIA";
            excelSheet.Cells[1, 7] = "LIGA/EMPRESA";
            excelSheet.Cells[1, 8] = "CLUB";
            excelSheet.Cells[1, 9] = "EX. CLINICO";
            excelSheet.Cells[1, 10] = "LABORATORIO";
            excelSheet.Cells[1, 11] = "RX";
            excelSheet.Cells[1, 12] = "EST. COMPLEMENTARIO";


            setearColorYBorde(excel.get_Range("A1", "A1"));
            setearColorYBorde(excel.get_Range("B1", "B1"));
            setearColorYBorde(excel.get_Range("C1", "C1"));
            setearColorYBorde(excel.get_Range("D1", "D1"));
            setearColorYBorde(excel.get_Range("E1", "E1"));
            setearColorYBorde(excel.get_Range("F1", "F1"));
            setearColorYBorde(excel.get_Range("G1", "G1"));
            setearColorYBorde(excel.get_Range("H1", "H1"));
            setearColorYBorde(excel.get_Range("I1", "I1"));
            setearColorYBorde(excel.get_Range("J1", "J1"));
            setearColorYBorde(excel.get_Range("K1", "K1"));
            setearColorYBorde(excel.get_Range("L1", "L1"));

            DataTable grilla = (DataTable)dgv.DataSource;

            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Maximum = grilla.Rows.Count;
            progressBar.Step = 1;

            int i = 1;
            int j = 0;

            foreach (DataRow dr in grilla.Rows)
            {
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[1].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[2].ToString();
                j++;
                excelSheet.Cells[i + 1, j + 1] = dr.ItemArray[3].ToString();
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
                i++;
                progressBar.PerformStep();
                j = 0;
            }

            excel.get_Range("A1", "L1").EntireColumn.AutoFit();
            excelworkBook.SaveAs(saveFileDialog.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excel.Quit();
            progressBar.Visible = false;
            MessageBox.Show("Exportación exitosa. Se guardó correctamente en: \n\n" + saveFileDialog.FileName, "Exportar Agenda", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }

        private void setearColorYBorde(Excel.Range rng)
        {
            rng.Font.Bold = true;
            rng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.PowderBlue);
            rng.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium,
            Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        }


    }
}
