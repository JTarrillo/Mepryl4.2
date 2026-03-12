using CapaPresentacionBase;
using Comunes;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CapaPresentacion
{
    public partial class frmAgendaTurno : DevExpress.XtraEditors.XtraForm
    {
        private DataTable tablaOriginal; // Almacena la tabla sin filtros para búsqueda

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
            tabla.Columns.Add("IdPaciente");
            tabla.Columns.Add("IdTipoExamen");
            tabla.Columns.Add("Fecha");
            tabla.Columns.Add("Hora");
            tabla.Columns.Add("TipoExamen");
            tabla.Columns.Add("Dni");
            tabla.Columns.Add("Paciente");
            tabla.Columns.Add("Categoria");
            tabla.Columns.Add("Liga/Empresa");
            tabla.Columns.Add("Club");
            tabla.Columns.Add("Telefono");
            tabla.Columns.Add("ExClinico");
            tabla.Columns.Add("Laboratorio");
            tabla.Columns.Add("RX");
            tabla.Columns.Add("EstComplementario");

            // Consulta desde dbo.Turno (todos los turnos) + subquery para obtener tep.id si existe
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select t.id, t.pacienteID,
            (SELECT TOP 1 tep.id FROM dbo.TipoExamenDePaciente tep WHERE tep.idTurno = t.id) as tepId,
            CONVERT(date, t.fecha), t.horaReferencia, e.descripcion, t.reservado, t.reserva
            from dbo.Turno t inner join dbo.Horario h on t.horarioID = h.id
            inner join dbo.Especialidad e on h.especialidadID = e.id
            where convert(date, t.fecha) >= '" + tpDesde.Value.ToShortDateString() + @"'
            and convert(date, t.fecha) <= '" + tpHasta.Value.ToShortDateString() + @"'
            and t.habilitado = 1
            order by t.fecha asc, t.horaReferencia asc");

            if (consulta == null || consulta.Rows.Count == 0)
            {
                filtrarTablaYCargarDataGrid(tabla);
                MessageBox.Show("⚠️ No hay turnos para las fechas seleccionadas.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Maximum = consulta.Rows.Count;

            CapaNegocioMepryl.TipoExamen tipoEx = new CapaNegocioMepryl.TipoExamen();

            foreach (DataRow r in consulta.Rows)
            {
                try
                {
                    string pacienteId = r.ItemArray[1].ToString();
                    bool tieneAsignado = pacienteId != "00000000-0000-0000-0000-000000000000" && pacienteId != "";
                    bool esReserva = r.ItemArray[6].ToString() == "1";

                    if (tieneAsignado && comboEstado.SelectedIndex == 0)
                    {
                        object drPaciente = cargarDatoPaciente(pacienteId);
                        if (drPaciente != null)
                        {
                            // Cargar estudios si existe TipoExamenDePaciente para este turno
                            string exClinico = "", laboratorio = "", rx = "", estComplementario = "";
                            string idTipoExamen = r.ItemArray[2].ToString();
                            if (!string.IsNullOrEmpty(idTipoExamen))
                            {
                                Entidades.TipoExamen entidad = tipoEx.cargarEstudiosPorExamen(idTipoExamen);
                                if (entidad != null)
                                {
                                    agregarCadenaString(ref exClinico, entidad.TextoClinico);
                                    agregarCadenaString(ref laboratorio, entidad.TextoLaboratorio);
                                    agregarCadenaString(ref rx, entidad.TextoRx);
                                    agregarCadenaString(ref estComplementario, entidad.TextoEstComplement);
                                }
                            }

                            string liga = "", club = "";
                            DataTable ligaYClub = SQLConnector.obtenerTablaSegunConsultaString(@"select l.descripcion, c.descripcion from dbo.clubesPorPaciente 
                                cpp inner join dbo.Club c on cpp.club = c.id inner join dbo.Liga l on c.ligaID = l.id where cpp.paciente = '" + pacienteId + "'");
                            if (ligaYClub.Rows.Count > 0)
                            {
                                liga = ligaYClub.Rows[0].ItemArray[0].ToString();
                                club = ligaYClub.Rows[0].ItemArray[1].ToString();
                            }

                            string nacimiento = "";
                            try { nacimiento = Convert.ToDateTime(((DataRow)drPaciente).ItemArray[3].ToString()).Year.ToString(); } catch { }

                            tabla.Rows.Add(r.ItemArray[0].ToString(), pacienteId, idTipoExamen,
                                r.ItemArray[3].ToString(), r.ItemArray[4].ToString(), r.ItemArray[5].ToString(),
                                ((DataRow)drPaciente).ItemArray[0], ((DataRow)drPaciente).ItemArray[2] + " " + ((DataRow)drPaciente).ItemArray[1],
                                nacimiento, liga, club, ((DataRow)drPaciente).ItemArray[4].ToString(), exClinico, laboratorio, rx, estComplementario);
                        }
                    }
                    else if (esReserva && comboEstado.SelectedIndex == 0)
                    {
                        tabla.Rows.Add(r.ItemArray[0].ToString(), "", "",
                            r.ItemArray[3].ToString(), r.ItemArray[4].ToString(), r.ItemArray[5].ToString(),
                            "", "RESERVA", "", "", r.ItemArray[7].ToString(), "", "", "", "", "");
                    }
                    else if (comboEstado.SelectedIndex == 1 && !tieneAsignado && !esReserva)
                    {
                        tabla.Rows.Add(r.ItemArray[0].ToString(), "", "",
                            r.ItemArray[3].ToString(), r.ItemArray[4].ToString(), r.ItemArray[5].ToString(),
                            "", "", "", "", "", "", "", "", "", "");
                    }

                    progressBar.PerformStep();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"❌ Error en cargarAgenda: {ex.Message}");
                    progressBar.PerformStep();
                }
            }

            tablaOriginal = tabla.Copy();
            filtrarTablaYCargarDataGrid(tabla);
            tbBusquedaPaciente.Clear();
        }

        private object cargarDatoPaciente(string idPaciente)
        {
            DataTable pacientePreventiva = SQLConnector.obtenerTablaSegunConsultaString(@"
                    select p.dni, p.apellido, p.nombres, p.fechaNacimiento, p.celular
                    from dbo.Paciente p
                    where p.id = '" + idPaciente + "'");
            if (pacientePreventiva.Rows.Count > 0)
            {
                return pacientePreventiva.Rows[0];
            }
            else
            {
                DataTable pacienteLaboral = SQLConnector.obtenerTablaSegunConsultaString(@"
                        select p.dni, p.apellido, p.nombres, p.fechaNacimiento, p.celular
                        from dbo.PacienteLaboral p
                        where p.id = '" + idPaciente + "'");
                if (pacienteLaboral.Rows.Count > 0)
                {
                    return pacienteLaboral.Rows[0];
                }
            }
            return null;
        }

        private void filtrarTablaYCargarDataGrid(DataTable tabla)
        {
            DataTable tablaFiltrada = new DataTable();
            tablaFiltrada.Columns.Add("IdTurno");
            tablaFiltrada.Columns.Add("IdPaciente");
            tablaFiltrada.Columns.Add("IdTipoExamen");
            tablaFiltrada.Columns.Add("Fecha");
            tablaFiltrada.Columns.Add("Hora");
            tablaFiltrada.Columns.Add("TipoExamen");
            tablaFiltrada.Columns.Add("Dni");
            tablaFiltrada.Columns.Add("Paciente");
            tablaFiltrada.Columns.Add("Categoria");
            tablaFiltrada.Columns.Add("Liga/Empresa");
            tablaFiltrada.Columns.Add("Club");
            tablaFiltrada.Columns.Add("Telefono");
            tablaFiltrada.Columns.Add("ExClinico");
            tablaFiltrada.Columns.Add("Laboratorio");
            tablaFiltrada.Columns.Add("RX");
            tablaFiltrada.Columns.Add("EstComplementario");

            string cadenaFiltro = "";
            cadenaFiltro = setearCadena(cadenaFiltro, cboExamen, "TipoExamen");
            cadenaFiltro = setearCadena(cadenaFiltro, cboLiga, "[Liga/Empresa]");
            cadenaFiltro = setearCadena(cadenaFiltro, cboClub, "Club");
            cadenaFiltro = filtrarCategoria(cadenaFiltro, tbCategoria.Text, tbCategoriaHasta.Text);
            cadenaFiltro = filtrarPorPaciente(cadenaFiltro, tbBusquedaPaciente.Text);

            DataRow[] rows = tabla.Select(cadenaFiltro);
            foreach (DataRow r in rows)
            {
                tablaFiltrada.Rows.Add(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2], r.ItemArray[3],
                    r.ItemArray[4], r.ItemArray[5], r.ItemArray[6], r.ItemArray[7], r.ItemArray[8], r.ItemArray[9],
                    r.ItemArray[10], r.ItemArray[11], r.ItemArray[12], r.ItemArray[13], r.ItemArray[14], r.ItemArray[15]);
            }
            dgv.DataSource = null;
            dgv.DataSource = tablaFiltrada;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].Visible = false;
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

        // ✅ Método para filtrar por nombre o DNI del paciente
        private string filtrarPorPaciente(string cadena, string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda))
                return cadena;

            // Buscar parcial en nombre (Paciente) o DNI
            string filtro = "(Paciente LIKE '%" + textoBusqueda + "%' OR Dni LIKE '%" + textoBusqueda + "%')";

            if (cadena == "")
            {
                return filtro;
            }
            else
            {
                return cadena + " AND " + filtro;
            }
        }

        // ✅ Evento del botón Buscar Paciente
        private void butBuscarPaciente_Click(object sender, EventArgs e)
        {
            if (tablaOriginal == null || tablaOriginal.Rows.Count == 0)
            {
                MessageBox.Show("⚠️ Por favor, realice una búsqueda de agenda primero.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            filtrarTablaYCargarDataGrid(tablaOriginal);
        }

        // ✅ MÉTODO AUXILIAR: Agregar cadena como en frmHistoricoMesaEntrada
        private void agregarCadenaString(ref string retorno, string texto)
        {
            if (!string.IsNullOrEmpty(texto))
            {
                if (!string.IsNullOrEmpty(retorno))
                {
                    retorno = retorno + " - " + texto;
                }
                else
                {
                    retorno = texto;
                }
            }
        }

        private void botBuscarFecha_Click(object sender, EventArgs e)
        {
            try
            {
                //if (tpHasta.Value > DateTime.Now)
                //    MessageBox.Show("¡Fecha de búsqueda "+ tpHasta.Value.ToString("dd/MM/yyyy") + " no puede ser mayor a la fecha actual!", "Atención",
                //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //else
                cargarAgenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al cargar agenda: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"❌ Exception: {ex}");
            }
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
                // También exportar a Google Sheets
                ExportarAGoogleSheets();
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
            excelSheet.Cells[1, 9] = "TELEFONO";
            excelSheet.Cells[1, 10] = "EX. CLINICO";
            excelSheet.Cells[1, 11] = "LABORATORIO";
            excelSheet.Cells[1, 12] = "RX";
            excelSheet.Cells[1, 13] = "EST. COMPLEMENTARIO";

            setearColorYBorde(excel.get_Range("A1", "M1"));

            DataTable grilla = (DataTable)dgv.DataSource;

            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Maximum = grilla.Rows.Count;
            progressBar.Step = 1;

            int i = 1;

            foreach (DataRow dr in grilla.Rows)
            {
                excelSheet.Cells[i + 1, 1] = dr.ItemArray[3].ToString();   // Fecha
                excelSheet.Cells[i + 1, 2] = dr.ItemArray[4].ToString();   // Hora
                excelSheet.Cells[i + 1, 3] = dr.ItemArray[5].ToString();   // TipoExamen
                excelSheet.Cells[i + 1, 4] = dr.ItemArray[6].ToString();   // Dni
                excelSheet.Cells[i + 1, 5] = dr.ItemArray[7].ToString();   // Paciente
                excelSheet.Cells[i + 1, 6] = dr.ItemArray[8].ToString();   // Categoria
                excelSheet.Cells[i + 1, 7] = dr.ItemArray[9].ToString();   // Liga/Empresa
                excelSheet.Cells[i + 1, 8] = dr.ItemArray[10].ToString();  // Club
                excelSheet.Cells[i + 1, 9] = dr.ItemArray[11].ToString();  // Telefono
                excelSheet.Cells[i + 1, 10] = dr.ItemArray[12].ToString(); // ExClinico
                excelSheet.Cells[i + 1, 11] = dr.ItemArray[13].ToString(); // Laboratorio
                excelSheet.Cells[i + 1, 12] = dr.ItemArray[14].ToString(); // RX
                excelSheet.Cells[i + 1, 13] = dr.ItemArray[15].ToString(); // EstComplementario

                i++;
                progressBar.PerformStep();
            }

            excel.get_Range("A1", "M1").EntireColumn.AutoFit();
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

        private void butExportarGoogleSheet_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ExportarAGoogleSheets();
        }

        private async void ExportarAGoogleSheets()
        {
            try
            {
                string spreadsheetId = "1_uyFFJD9oxf0cArt7Vo4dT18-v1c-o3nDXjalJDlCUk"; // Tu ID de Google Sheet
                string credentialsPath = AppDomain.CurrentDomain.BaseDirectory + "credentials.json";

                if (!System.IO.File.Exists(credentialsPath))
                {
                    MessageBox.Show("❌ Archivo credentials.json no encontrado en: " + credentialsPath,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                GoogleCredential credential;
                using (var stream = new System.IO.FileStream(credentialsPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(stream)
                        .CreateScoped(SheetsService.Scope.Spreadsheets);
                }

                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "MEPRYL"
                });

                var values = new List<IList<object>>();
                values.Add(new List<object>
                {
                    "FECHA", "HORA", "TIPO DE EXAMEN", "DNI", "PACIENTE",
                    "CATEGORIA", "LIGA/EMPRESA", "CLUB", "TELEFONO", "EX. CLINICO",
                    "LABORATORIO", "RX", "EST. COMPLEMENTARIO"
                });

                DataTable grilla = (DataTable)dgv.DataSource;
                foreach (DataRow dr in grilla.Rows)
                {
                    values.Add(new List<object>
                    {
                        dr.ItemArray[3], dr.ItemArray[4], dr.ItemArray[5], dr.ItemArray[6],
                        dr.ItemArray[7], dr.ItemArray[8], dr.ItemArray[9], dr.ItemArray[10],
                        dr.ItemArray[11], dr.ItemArray[12], dr.ItemArray[13], dr.ItemArray[14], dr.ItemArray[15]
                    });
                }

                var body = new ValueRange { Values = values };
                var request = service.Spreadsheets.Values.Update(body, spreadsheetId, "Hoja 1!A1");
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                await request.ExecuteAsync();

                MessageBox.Show("✅ Datos exportados a Google Sheets correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
