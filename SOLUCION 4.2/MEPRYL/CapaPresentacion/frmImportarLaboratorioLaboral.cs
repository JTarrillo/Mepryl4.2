using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data.OleDb;
using Comunes;
using CapaNegocioMepryl;
using Entidades;

namespace CapaPresentacion
{
    public partial class frmImportarLaboratorioLaboral : Form
    {
        string str;
        frmBusquedaExamen form;
        DataTable valoresInvalidos;
        DataTable validaciones;
        CapaNegocioMepryl.Examen examen;
        CapaNegocioMepryl.UtilidadesMepryl UtilMepryl;
        CapaNegocioMepryl.ExamenPreventiva preventiva;
        DataTable dtDatoRequerido;
        DataTable dtRequeridoMensaje;
        int intNroCol = 0;

        public delegate void DelegateFormulario();
        public DelegateFormulario objDelegateFormulario = null;

        int puntero;
        public frmImportarLaboratorioLaboral()
        {
            InitializeComponent();
            //form = frm;
            examen = new CapaNegocioMepryl.Examen();
            UtilMepryl = new CapaNegocioMepryl.UtilidadesMepryl();
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
            // Consulta explícita con columnas reales de la tabla Validaciones
            validaciones = SQLConnector.obtenerTablaSegunConsultaString("SELECT id, codigo, codigoInterno, descripcion, rangoDesde, rangoHasta, idClasif FROM dbo.Validaciones");
        }


        private void botImpExcel_Click(object sender, EventArgs e)
        {
            tbArchivo.Clear();
            openFileDialog.Filter = "Archivos de Excel |*.xlsx; *.xls";
            DialogResult result = openFileDialog.ShowDialog();
            tbArchivo.Text = openFileDialog.FileName;
        }

        private void botComenzarExcel_Click(object sender, EventArgs e)
        {
            if (tbArchivo.Text != "")
            {
                DialogResult resul = MessageBox.Show("¿Desea comenzar la importación de laboratorios?", "Importar Laboratorios",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == resul)
                {
                    importar();
                }
            }
        }

        private void importar()
        {
            DataTable dtDatos;

            try
            {
                intNroCol = 0;
                valoresInvalidos = new DataTable();
                dtRequeridoMensaje = new DataTable();
                dtDatoRequerido = new DataTable();

                valoresInvalidos.Columns.Add("Fila");
                valoresInvalidos.Columns.Add("Columna");
                dtRequeridoMensaje.Columns.Add("Fila");
                dtRequeridoMensaje.Columns.Add("Columna");
                dtDatos = UtilMepryl.DatosArchivoExcel(tbArchivo.Text);
                progressBar.Minimum = 0;
                progressBar.Maximum = dtDatos.Rows.Count;
                progressBar.Visible = true;

                int ndc = dtDatos.Columns.Count;

                foreach (DataRow r in dtDatos.Rows)
                {
                    for (int i = 0; i < ndc; i++)
                    {
                        str = r.ItemArray[i].ToString();
                        str = r.ItemArray[i].ToString();
                    }
                }

                intNroCol = dtDatos.Columns.Count;
                procesarExcel(dtDatos);

                ValidarValores();
                progressBar.Visible = false;
                if (valoresInvalidos.Rows.Count == 0)
                {
                    if (!faltanResultados())
                    {
                        MessageBox.Show("¡Importación exitosa! Registros importados correctamente: " + (puntero - 1).ToString(), "Importar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Debug.WriteLine("[IMPORTAR] Llamando a delegate para recargar grilla");
                        if (objDelegateFormulario != null)
                        {
                            objDelegateFormulario();
                            System.Diagnostics.Debug.WriteLine("[IMPORTAR] Delegate ejecutado, cerrando formulario");
                            this.Close();
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("[IMPORTAR] Delegate es null, no se ejecutará recarga");
                        }
                    }
                }
                else
                {
                    string detalles = "";
                    foreach (DataRow r in valoresInvalidos.Rows)
                    {
                        detalles = detalles + "\n Fila " + (Convert.ToInt32(GetSafeValue(r, 0)) + 1).ToString() + " del archivo de EXCEL. --> Error en la Columna: " +
                            GetSafeValue(r, 1);

                    }

                    MessageBox.Show("¡El archivo de Excel presenta los siguientes errores!\n\nDetalles:" + detalles, "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                str = ex.ToString();
                str = ex.ToString();
                progressBar.Visible = false;
                MessageBox.Show("Existe un error con los registros del archivo, verifique que el nro. de orden y que los registros existan.\nError al importar la fila nro.: " + (Convert.ToInt32(puntero.ToString()) + 1).ToString() + " del archivo de EXCEL\n\n-------\n" + ex.ToString(), "Error al Importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool faltanResultados()
        {
            string detalles = "";
            bool blnResultado = false;

            if (dtRequeridoMensaje.Rows.Count > 0)
            {
                detalles = "";

                foreach (DataRow t in dtRequeridoMensaje.Rows)
                {
                    detalles = detalles + "\nPara el Nº Orden: L-" + GetSafeValue(t, 0) + ". --> " + //Es requerido resultados de " +
                        GetSafeValue(t, 1);
                }

                MessageBox.Show("¡Importación incompleta, los siguientes resultados de examen son o no requeridos y no se han encontrado en el archivo de Excel.\n" + detalles, "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                blnResultado = true;
            }

            return blnResultado;
        }

        //private void procesarExcel(DataSet ds)
        private void procesarExcel(DataTable ds)
        {
            puntero = 1;
            foreach (DataRow row in ds.Rows)
            {
                if (GetSafeValue(row, 0) != "")
                {
                    procesarFila(row);
                    progressBar.PerformStep();
                }
            }
        }

        private void procesarFila(DataRow row)
        {
            try
            {
                String test;
                string fecha;
                object rawFecha = row.ItemArray[0];
                DateTime dtFecha;
                if (rawFecha != null)
                {
                    if (rawFecha is DateTime)
                    {
                        fecha = ((DateTime)rawFecha).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        string rawStr = rawFecha.ToString().Trim();

                        // ✅ PRIORIDAD 1: Si el dato tiene 6 u 8 dígitos, es formato DDMMYY / DDMMYYYY
                        if (Regex.IsMatch(rawStr, @"^\d{6}$") || Regex.IsMatch(rawStr, @"^\d{8}$"))
                        {
                            fecha = procesarFecha(rawStr);
                        }
                        // PRIORIDAD 2: Intentar parsear como fecha string normal
                        else if (DateTime.TryParse(rawStr, out dtFecha))
                        {
                            fecha = dtFecha.ToString("yyyy-MM-dd");
                        }
                        // PRIORIDAD 3: Intentar como OADate de Excel (solo si es número grande)
                        else
                        {
                            double oa;
                            if (double.TryParse(rawStr, out oa))
                            {
                                try
                                {
                                    // Las fechas actuales en OADate están en el rango 40000-60000
                                    // Si es un número fuera de este rango, probablemente sea DDMMYY
                                    if (oa > 30000 && oa < 70000)
                                    {
                                        DateTime fromOADate = DateTime.FromOADate(oa);
                                        fecha = fromOADate.ToString("yyyy-MM-dd");
                                    }
                                    else
                                    {
                                        fecha = procesarFecha(rawStr);
                                    }
                                }
                                catch
                                {
                                    fecha = procesarFecha(rawStr);
                                }
                            }
                            else
                            {
                                fecha = procesarFecha(rawStr);
                            }
                        }
                    }
                }
                else
                {
                    fecha = string.Empty;
                }

                string examen01 = CorregirIdentificador(GetSafeValue(row, 1));
                
                Debug.WriteLine("[ImportLaboralLaboral] Fecha leída del Excel columna 0: " + fecha);
                Debug.WriteLine("[ImportLaboralLaboral] Identificador del Excel columna 1: " + examen01);
                
                // Construir SQL filtrando por fecha si está disponible en el Excel
                string strSQL = "Select tep.id, Convert(date,c.fecha) as FechaReal from dbo.TipoExamenDePaciente " +
                    "tep inner join dbo.Consulta c on tep.idConsulta = c.id " +
                    "where c.identificador = '" + examen01.ToString() + "' AND c.valido = '1' AND c.nroOrden != '0' AND c.tipo != 'V' ";
                
                // Si el Excel tiene una fecha válida, agregar filtro de fecha
                if (!string.IsNullOrEmpty(fecha))
                {
                    // Convertir DDMMYY a YYYY-MM-DD para el filtro
                    string fechaFiltro = fecha.Replace("-", "");
                    if (fechaFiltro.Length == 6)
                    {
                        // DDMMYY -> YYYY-MM-DD
                        string dia = fechaFiltro.Substring(0, 2);
                        string mes = fechaFiltro.Substring(2, 2);
                        string anio = fechaFiltro.Substring(4, 2);
                        // Asumir años 2000s para 00-26, 1900s para 27-99
                        int anioNum = int.Parse(anio);
                        anioNum = anioNum >= 27 ? 1900 + anioNum : 2000 + anioNum;
                        string fechaCompleta = anioNum + "-" + mes + "-" + dia;
                        strSQL += "AND CONVERT(VARCHAR(8), c.fecha, 112) = '" + anioNum + mes + dia + "' ";
                        Debug.WriteLine("[ImportLaboralLaboral] Fecha DDMMYY convertida: " + fechaFiltro + " -> " + fechaCompleta);
                        Debug.WriteLine("[ImportLaboralLaboral] Filtrando por fecha YYYYMMDD: " + anioNum + mes + dia);
                    }
                    else if (fechaFiltro.Length == 8)
                    {
                        // Formato YYYYMMDD - usar CONVERT directamente
                        strSQL += "AND CONVERT(VARCHAR(8), c.fecha, 112) = '" + fechaFiltro + "' ";
                        Debug.WriteLine("[ImportLaboralLaboral] Filtrando por fecha YYYYMMDD: " + fechaFiltro);
                    }
                    else
                    {
                        Debug.WriteLine("[ImportLaboralLaboral] Formato de fecha no reconocido: " + fechaFiltro);
                    }
                }
                else
                {
                    Debug.WriteLine("[ImportLaboralLaboral] No hay fecha en Excel, usando registro más reciente");
                }
                
                strSQL += "ORDER BY c.fecha DESC";

                Debug.WriteLine("[ImportLaboralLaboral] Buscando: Identificador=" + examen01);
                Debug.WriteLine("[ImportLaboralLaboral] SQL: " + strSQL);

                DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
                Debug.WriteLine("[ImportLaboralLaboral] Resultados encontrados: " + tipoExamen.Rows.Count);

                // Si se encontró el registro, usar la fecha real de la base de datos
                if (tipoExamen.Rows.Count > 0)
                {
                    fecha = tipoExamen.Rows[0]["FechaReal"].ToString();
                    Debug.WriteLine("[ImportLaboralLaboral] Fecha real del registro: " + fecha);
                }

                if (tipoExamen.Rows.Count > 0)
                {
                    dtDatoRequerido.Clear();
                    string idTipoExamen = tipoExamen.Rows[0][0].ToString();
                    test = idTipoExamen;
                    dtDatoRequerido = examen.ComprobarEstudioPorExamen(idTipoExamen);

                    procesarLaboratorio(examen01, fecha, row, idTipoExamen);
                    //CampoRequerido(puntero, row);                
                    CampoRequerido(ObtieneNroOrden(GetSafeValue(row, 1)), row);
                    puntero++;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ImportLaboralLaboral] EXCEPTION while processing row: " + ex.ToString());
                try
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < row.ItemArray.Length; i++) sb.Append($"[{i}]='{row.ItemArray[i]}' ");
                    Debug.WriteLine("[ImportLaboralLaboral] Row content: " + sb.ToString());
                }
                catch { }
                try { valoresInvalidos.Rows.Add(puntero, "EXCEPTION"); } catch { }
            }
        }

        private string CorregirIdentificador(string Ident)
        {
            string strCorregido = "";
            int intNumero = 0;

            if (Ident.Contains("L"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("L"), 2);
                intNumero = Convert.ToInt32(strCorregido);
                strCorregido = "L" + intNumero;
            }
            else if (Ident.Contains("EC"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("E"), 3);
                intNumero = Convert.ToInt32(strCorregido);
                strCorregido = "EC" + intNumero;
            }
            else if (Ident.Contains("C"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("C"), 2);
                intNumero = Convert.ToInt32(strCorregido);
                strCorregido = "C" + intNumero;
            }
            else if (Ident.Contains("R"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("R"), 2);
                intNumero = Convert.ToInt32(strCorregido);
                strCorregido = "R" + intNumero;
            }

            return strCorregido;
        }

        private string procesarFecha(string fechaSinProcesar)
        {
            if (string.IsNullOrWhiteSpace(fechaSinProcesar))
                return fechaSinProcesar;

            DateTime dt;
            // Intentar parsear formatos comunes (ej: 12/05/2026)
            if (DateTime.TryParse(fechaSinProcesar, out dt))
            {
                // Devolver en formato ISO compatible con SQL: yyyy-MM-dd
                return dt.ToString("yyyy-MM-dd");
            }

            // Eliminar caracteres no numéricos y manejar ddMMyy, yyyyMMdd, ddMMyyyy
            string digits = Regex.Replace(fechaSinProcesar, "\\D", "");
            if (digits.Length == 6)
            {
                // Interpretar como DDMMYY (día-mes-año) para este sistema
                // Formato: 180826 → 18-08-2026
                string strDia = digits.Substring(0, 2);
                string strMes = digits.Substring(2, 2);
                string año2 = digits.Substring(4, 2);
                
                // Asumir años 2000s para 00-26, 1900s para 27-99
                int añoNum = int.Parse(año2);
                añoNum = añoNum >= 27 ? 1900 + añoNum : 2000 + añoNum;
                
                return añoNum + "-" + strMes + "-" + strDia;
            }
            else if (digits.Length == 8)
            {
                // Verificar si es DDMMYYYY o YYYYMMDD
                // Si los primeros 2 dígitos > 31, es YYYYMMDD, de lo contrario es DDMMYYYY
                int primerosDos = int.Parse(digits.Substring(0, 2));
                if (primerosDos > 31)
                {
                    // YYYYMMDD (año-mes-día)
                    // Formato: 20230826 → 2023-08-26
                    string año = digits.Substring(0, 4);
                    string strMes = digits.Substring(4, 2);
                    string strDia = digits.Substring(6, 2);
                    return año + "-" + strMes + "-" + strDia;
                }
                else
                {
                    // DDMMYYYY (día-mes-año)
                    // Formato: 26082023 → 26-08-2023
                    string strDia = digits.Substring(0, 2);
                    string strMes = digits.Substring(2, 2);
                    string año = digits.Substring(4, 4);
                    return año + "-" + strMes + "-" + strDia;
                }
            }

            // Fallback: devolver la cadena original si no se pudo parsear
            return fechaSinProcesar;
        }

        private void procesarLaboratorio(string Identificador, string Fecha, DataRow fila, string idTipoExamen)
        {
            System.Diagnostics.Debug.WriteLine("[IMPORTAR] procesarLaboratorio llamado - Identificador: " + Identificador + ", Fecha: " + Fecha);
            System.Diagnostics.Debug.WriteLine("[IMPORTAR] CONTENIDO DEL EXCEL (Índices 31-39):");
            for (int i = 31; i < Math.Min(40, fila.ItemArray.Length); i++)
            {
                System.Diagnostics.Debug.WriteLine("[IMPORTAR] fila.ItemArray[" + i + "] = '" + fila.ItemArray[i].ToString() + "'");
            }
            
            List<string> valores = new List<string>();
            Int32 multiplicacion;
            
            // ORDEN ESPERADO POR cargarEntidad:
            // [0]: GRojos, [1]: GBlancos, [2]: Hemoglob, [3]: Hemato, [4]: Eritro
            // [5]: Cayado, [6]: Segmentado, [7]: Eosinof, [8]: Basof, [9]: Linfoc
            // [10]: Monoc, [11]: Glucemia, [12]: Uremia, [13]: Chagas, [14]: Vdrl
            // [15]: Grupo, [16]: Factor, [17]: Color, [18]: Aspecto, [19]: Densidad
            // [20]: Ph, [21]: Glucosa, [22]: Proteinas, [23]: HemoglobOrina, [24]: Bilirrubina
            // [25]: Celulas, [26]: Leucocitos, [27]: Hematies, [28]: Piocitos, [29]: Mucus
            // [30]: DictLab, [31]: ObsSerieRoja, [32]: ObsSerieBlanca, [33]: OtrosOrina1
            // [34]: OtrosOrina2, [35]: ObsLaborat
            
            // [0] GRojos - Excel [2] GR
            string valorGRojos = GetSafeValue(fila, 2);
            if (valorGRojos != "")
            {
                if (valorGRojos.Replace(",", ".").Replace(".", "").Length < 3)
                {
                    multiplicacion = 100000;
                }
                else
                {
                    multiplicacion = 10000;
                }
                Int32 laboratorio;

                object strGRojo = valorGRojos.Replace(",", ".").Replace(".", "");
                laboratorio = Convert.ToInt32(strGRojo);

                if (laboratorio > 999)
                    laboratorio *= 1000;
                else if (laboratorio > 99)
                    laboratorio *= 10000;
                else if (laboratorio > 9)
                    laboratorio *= 100000;
                else if (laboratorio < 10)
                    laboratorio *= 1000000;

                valores.Add(puntosAGlobulosBlancos("###,###", laboratorio.ToString()));
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(GetSafeValue(fila, 1)), 2);
            }

            // [1] GBlancos - Excel [3] GB
            string valorGBlancos = GetSafeValue(fila, 3);
            if (valorGBlancos != "")
            {
                valores.Add((puntosAGlobulosBlancos("###,###", valorGBlancos)).Replace(",", "."));
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(GetSafeValue(fila, 1)), 3);
            }
            
            // [2] Hemoglob - Excel [4] HGB
            string valorHemoglob = GetSafeValue(fila, 4);
            if (valorHemoglob != "")
            {
                valores.Add(valorHemoglob.Replace(".", ","));
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(GetSafeValue(fila, 1)), 4);
            }
            
            // [3] Hemato - Excel [5] HTC
            string valorHemato = GetSafeValue(fila, 5);
            if (valorHemato != "")
            {
                valores.Add(valorHemato.Replace(".", ","));
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(GetSafeValue(fila, 1)), 5);
            }
            
            // [4] Eritro - Excel [6] ERI
            string valorEritro = GetSafeValue(fila, 6);
            if (valorEritro != "")
            {
                valores.Add(valorEritro);
            }
            else
            {
                valores.Add("");
            }
            
            // [5] Cayado - Excel [7] NC
            string valorCayado = GetSafeValue(fila, 7);
            if (valorCayado != "")
            {
                valores.Add(valorCayado);
            }
            else
            {
                valores.Add("");
            }
            
            // [6] Segmentado - Excel [8] NS
            string valorSegmentado = GetSafeValue(fila, 8);
            if (valorSegmentado != "")
            {
                valores.Add(valorSegmentado);
            }
            else
            {
                valores.Add("");
            }
            
            // [7] Eosinof - Excel [9] EOS
            string valorEosinof = GetSafeValue(fila, 9);
            if (valorEosinof != "")
            {
                valores.Add(valorEosinof);
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(GetSafeValue(fila, 1)), 9);
            }
            
            // [8] Basof - Excel [10] BAS
            string valorBasof = GetSafeValue(fila, 10);
            if (valorBasof != "")
            {
                valores.Add(valorBasof);
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(GetSafeValue(fila, 1)), 10);
            }
            
            // [9] Linfoc - Excel [11] LIN
            string valorLinfoc = GetSafeValue(fila, 11);
            if (valorLinfoc != "")
            {
                valores.Add(valorLinfoc);
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(GetSafeValue(fila, 1)), 11);
            }
            
            // [10] Monoc - Excel [12] MON
            string valorMonoc = GetSafeValue(fila, 12);
            if (valorMonoc != "")
            {
                valores.Add(valorMonoc);
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(GetSafeValue(fila, 1)), 12);
            }

            // [11] Glucemia - Excel [14] GLU
            string valorGlucemia = GetSafeValue(fila, 14);
            if (valorGlucemia != "")
            {
                valores.Add(valorGlucemia);
            }
            else
            {
                valores.Add("");
            }
            
            // [12] Uremia - Excel [15] URE
            string valorUremia = GetSafeValue(fila, 15);
            if (valorUremia != "")
            {
                valores.Add(valorUremia);
            }
            else
            {
                valores.Add("");
            }

            // [13] Chagas - YA NO EXISTE en el nuevo Excel
            valores.Add(""); // Chagas ya no existe
            
            // [14] color - YA NO EXISTE en el nuevo Excel
            valores.Add(""); // Color ya no existe
            
            // [15] aspecto - YA NO EXISTE en el nuevo Excel
            valores.Add(""); // Aspecto ya no existe
            
            // [16] densidad - Excel [19] DEN
            string valorDensidad = GetSafeValue(fila, 19);
            if (valorDensidad != "")
            {
                valores.Add(valorDensidad);
            }
            else
            {
                valores.Add("");
            }
            
            // [17] ph - Excel [20] PH
            string valorPh = GetSafeValue(fila, 20);
            if (valorPh != "")
            {
                valores.Add(valorPh);
            }
            else
            {
                valores.Add("");
            }
            
            // [18] gluc - Excel [21] GLU
            string valorGlucOrina = GetSafeValue(fila, 21);
            if (valorGlucOrina != "")
            {
                valores.Add(valorGlucOrina);
            }
            else
            {
                valores.Add("");
            }
            
            // [19] prot - Excel [22] PRO
            string valorProt = GetSafeValue(fila, 22);
            if (valorProt != "")
            {
                valores.Add(valorProt);
            }
            else
            {
                valores.Add("");
            }
            
            // [20] hemogOrina - Excel [23] HGB
            string valorHemogOrina = GetSafeValue(fila, 23);
            if (valorHemogOrina != "")
            {
                valores.Add(valorHemogOrina);
            }
            else
            {
                valores.Add("");
            }
            
            // [21] cetonas - Excel [24] CC
            string valorCetonas = GetSafeValue(fila, 24);
            if (valorCetonas != "")
            {
                valores.Add(valorCetonas);
            }
            else
            {
                valores.Add("");
            }
            
            // [22] bilirrubina - Excel [25] BIL
            string valorBilirrubina = GetSafeValue(fila, 25);
            if (valorBilirrubina != "")
            {
                valores.Add(valorBilirrubina);
            }
            else
            {
                valores.Add("");
            }
            
            // [23] celulas - Excel [26] CEL
            string valorCelulas = GetSafeValue(fila, 26);
            if (valorCelulas != "")
            {
                valores.Add(valorCelulas);
            }
            else
            {
                valores.Add("");
            }
            
            // [24] leuco - Excel [27] LEU
            string valorLeuco = GetSafeValue(fila, 27);
            if (valorLeuco != "")
            {
                valores.Add(valorLeuco);
            }
            else
            {
                valores.Add("");
            }
            
            // [25] hematies - Excel [28] HEM
            string valorHematies = GetSafeValue(fila, 28);
            if (valorHematies != "")
            {
                valores.Add(valorHematies);
            }
            else
            {
                valores.Add("");
            }
            
            // [26] NO USADO - Se salta en el SQL
            valores.Add(""); // Índice no usado en SQL
            
            // [27] NO USADO - Se salta en el SQL
            valores.Add(""); // Índice no usado en SQL
            
            // [28] HDL - Excel [31] HDL
            string valorHDL = GetSafeValue(fila, 31);
            if (valorHDL != "")
            {
                valores.Add(valorHDL);
            }
            else
            {
                valores.Add("");
            }
            
            // [29] colTotal - Excel [32] COL.1 (Colesterol total)
            string valorColTotal = GetSafeValue(fila, 32);
            if (valorColTotal != "")
            {
                valores.Add(valorColTotal);
            }
            else
            {
                valores.Add("");
            }
            
            // [30] trig - Excel [33] TGL (Triglicéridos)
            string valorTrig = GetSafeValue(fila, 33);
            if (valorTrig != "")
            {
                valores.Add(valorTrig);
            }
            else
            {
                valores.Add("");
            }
            
            // [31] ldl - Excel [34] LDL
            string valorLDL = GetSafeValue(fila, 34);
            if (valorLDL != "")
            {
                valores.Add(valorLDL);
            }
            else
            {
                valores.Add("");
            }
            
            // [32] grupo - Excel [35] GS (Grupo Sanguíneo)
            string valorGrupo = GetSafeValue(fila, 35);
            if (valorGrupo != "")
            {
                valores.Add(valorGrupo);
            }
            else
            {
                valores.Add("");
            }
            
            // [33] factor - Excel [36] RH (Factor RH)
            string valorFactor = GetSafeValue(fila, 36);
            if (valorFactor != "")
            {
                valores.Add(valorFactor);
            }
            else
            {
                valores.Add("");
            }
            
            // [34] vdrl - Excel [37] VDRCU (VDRL)
            string valorVDRL = GetSafeValue(fila, 37);
            if (valorVDRL != "")
            {
                valores.Add(obtenerIdValorVDRL(valorVDRL, validaciones));
            }
            else
            {
                valores.Add("");
            }
            
            // [35] te - Excel [38] T. EMB. (Test embarazo)
            string valorTE = GetSafeValue(fila, 38);
            if (valorTE != "")
            {
                valores.Add(valorTE);
            }
            else
            {
                valores.Add("");
            }
            
            // [36] observacionesLab - Excel [39] OBS. (Observaciones)
            string valorObsLab = GetSafeValue(fila, 39);
            if (valorObsLab != "")
            {
                valores.Add(valorObsLab);
            }
            else
            {
                valores.Add("");
            }

            // Arbitros - ELIMINADOS (el nuevo Excel solo tiene 39 columnas)
            // if (intNroCol > 39) { ... }

            //if (dtRequeridoMensaje.Rows.Count < 1 && valoresInvalidos.Rows.Count < 1)
            System.Diagnostics.Debug.WriteLine("[IMPORTAR] valoresInvalidos.Rows.Count: " + valoresInvalidos.Rows.Count);
            System.Diagnostics.Debug.WriteLine("[IMPORTAR] VALORES A ENVIAR (Total: " + valores.Count + "):");
            for (int i = 0; i < valores.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("[IMPORTAR] valores[" + i + "] = '" + valores[i] + "'");
            }
            
            if (valoresInvalidos.Rows.Count < 1)
            {
                System.Diagnostics.Debug.WriteLine("[IMPORTAR] Llamando a ActualizaEstudioLaboratorio para orden: " + Identificador);
                ActualizaEstudioLaboratorio(idTipoExamen, valores);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[IMPORTAR] NO se llamó a ActualizaEstudioLaboratorio por valores inválidos");
            }
        }


        private string obtenerId(string valor, string codigo, DataTable validaciones, int columna)
        {
            string idValidacion = "";
            if (valor == "N")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "1");
            }
            else if (valor == "E" || valor == "+")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "2");
            }
            else if (valor == "R" || valor == "++")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "3");
            }
            else if (valor == "A" || valor == "+++")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "4");
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "5");
                idValidacion = "";
            }
            else if (valor == "")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "5");
                idValidacion = "";
            }
            else
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "6");
                marcarComoInvalido(puntero, columna);
            }
            return idValidacion;
        }

        private string obtenerIdValorFactor(string valor)
        {
            string idValidacion = "";

            if (valor == "POS" || valor == "(+)" || valor == "+")
            {
                idValidacion = "+";
            }
            else if (valor == "NEG" || valor == "(-)" || valor == "-")
            {
                idValidacion = "-";
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "43", "3");
                idValidacion = "";
            }
            else if (valor == "")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "43", "3");
                idValidacion = "";
            }
            else
            {
                idValidacion = "";
                marcarComoInvalido(puntero, 36);
            }
            return idValidacion;
        }

        private void actualizarValores(string idTipoExamen, List<string> valores)
        {
            preventiva.guardarExLaboratorio(cargarEntidad(idTipoExamen, valores));
        }

        /// <summary>
        /// Método auxiliar para obtener valores de forma segura desde DataRow con validación de DBNull y nulos
        /// </summary>
        private string GetSafeValue(DataRow row, int index)
        {
            try
            {
                if (index >= row.ItemArray.Length || index < 0)
                    return "";

                object value = row.ItemArray[index];
                
                if (value == DBNull.Value || value == null)
                    return "";

                string stringValue = value.ToString();
                
                // Validar valores comunes de Excel que indican celda vacía
                if (string.IsNullOrWhiteSpace(stringValue) || 
                    stringValue.ToLower() == "nan" || 
                    stringValue == "*")
                    return "";

                return stringValue.Trim();
            }
            catch
            {
                return "";
            }
        }

        private string obtenerIdColor(string valor, DataTable validaciones)
        {
            string idValidacion = "";
            if (valor == "A")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "47", "1");
            }
            else if (valor == "AC")
            {
                // idValidacion = filtrarTablaDescripcion(validaciones, "47", "7");
                idValidacion = "CLARO";
            }
            else if (valor == "AO")
            {
                // idValidacion = filtrarTablaDescripcion(validaciones, "47", "5");
                idValidacion = "OSCURO";
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "47", "2");
                idValidacion = "";
            }
            else if (valor == "")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "47", "2");
                idValidacion = "";
            }
            else
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "47", "8");
                marcarComoInvalido(puntero, 17);
            }
            return idValidacion;
        }

        private string obtenerIdAspecto(string valor, DataTable validaciones)
        {
            string idValidacion = "";
            if (valor == "L")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "48", "1");
            }
            else if (valor == "LT")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "48", "2");
                idValidacion = "LIG. TURBIO";
            }
            else if (valor == "T")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "48", "3");
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "48", "4");
                idValidacion = "";
            }
            else if (valor == "")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "48", "4");
                idValidacion = "";
            }
            else
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "48", "5");
                marcarComoInvalido(puntero, 18);
            }
            return idValidacion;


        }

        private string obtenerIdValorChagas(string valor, DataTable validaciones)
        {
            string idValidacion = "";
            if (valor == "POS")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "43", "2");
            }
            else if (valor == "NEG")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "43", "1");
            }
            else if (valor == "*")
            {
                idValidacion = "";
            }
            else if (valor == "")
            {
                idValidacion = "";
            }
            else
            {
                idValidacion = "";
                marcarComoInvalido(puntero, 16);
            }
            return idValidacion;
        }

        private string obtenerIdValorVDRL(string valor, DataTable validaciones)
        {
            string idValidacion = "";
            if (valor == "R")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "44", "2");
            }
            else if (valor == "NR")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "44", "1");
            }
            else if (valor == "*")
            {
                idValidacion = "";
            }
            else if (valor == "")
            {
                idValidacion = "";
            }
            else
            {
                idValidacion = "";
                marcarComoInvalido(puntero, 37);
            }
            return idValidacion;
        }

        private string filtrarTabla(DataTable valid, string codigo, string codigoInterno)
        {
            DataRow[] r = valid.Select("codigo = '" + codigo + "' and codigoInterno = '" + codigoInterno + "'");
            if (r.Length > 0)
            {
                // Acceso seguro por nombre de columna (retorna el id)
                object idValue = r[0]["id"];
                return (idValue != DBNull.Value && idValue != null) ? idValue.ToString() : "";
            }
            return "";
        }

        private string filtrarTablaDescripcion(DataTable valid, string codigo, string codigoInterno)
        {
            DataRow[] r = valid.Select("codigo = '" + codigo + "' and codigoInterno = '" + codigoInterno + "'");
            if (r.Length > 0)
            {
                // Acceso seguro por nombre de columna
                object descripcionValue = r[0]["descripcion"];
                return (descripcionValue != DBNull.Value && descripcionValue != null) ? descripcionValue.ToString() : "";
            }
            return "";
        }

        private string puntosAGlobulosBlancos(string forma, string cadena)
        {
            if (!string.IsNullOrEmpty(cadena))
            {
                int Position = 0;
                Decimal result = 0;
                if (Decimal.TryParse(cadena, out result))
                {
                    cadena = result.ToString(forma);
                    Position = Position + 1;

                }
            }
            return cadena;
        }

        private void marcarComoInvalido(int fila, int columna)
        {
            valoresInvalidos.Rows.Add(fila, columna);
        }

        private string obtenerIdCelulas(string valor, string codigo, DataTable validaciones, int columna)
        {
            string idValidacion = "";
            if (valor == "N")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "2");
                idValidacion = "NO SE OBSERVAN";
            }
            else if (valor == "E" || valor == "+")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "2");
            }
            else if (valor == "R" || valor == "++")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "3");
            }
            else if (valor == "A" || valor == "+++")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "4");
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "6");
                idValidacion = "";
            }
            else if (valor == "")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "6");
                idValidacion = "";
            }
            else
            {
                idValidacion = "";
                marcarComoInvalido(puntero, 26);
            }
            return idValidacion;
        }

        private string obtenerIdLeucocitos(string valor, string codigo, DataTable validaciones, int columna)
        {
            string idValidacion = "";
            if (valor == "N")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "2");
                idValidacion = "NO SE OBSERVAN";
            }
            else if (valor == "E" || valor == "+")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "2");
            }
            else if (valor == "R" || valor == "++")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "3");
            }
            else if (valor == "A" || valor == "+++")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "4");
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "6");
                idValidacion = "";
            }
            else if (valor == "")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "6");
                idValidacion = "";
            }
            else
            {
                idValidacion = "";
                marcarComoInvalido(puntero, 27);
            }
            return idValidacion;
        }

        private Entidades.ExamenPreventiva cargarEntidad(string idTe, List<string> valores)
        {
            Entidades.ExamenPreventiva retorno = new Entidades.ExamenPreventiva();
            retorno.IdTipoExamen = new Guid(idTe);
            retorno.GRojos = valores[0];
            retorno.GBlancos = valores[1];
            retorno.Hemoglob = valores[2];
            retorno.Hemato = valores[3];
            retorno.Eritro = valores[4];
            retorno.Cayado = convertirInt(valores[5]);
            retorno.Segmentado = convertirInt(valores[6]);
            retorno.Eosinof = convertirInt(valores[7]);
            retorno.Basof = convertirInt(valores[8]);
            retorno.Linfoc = convertirInt(valores[9]);
            retorno.Monoc = convertirInt(valores[10]);
            retorno.Glucemia = convertirInt(valores[11]);
            retorno.Uremia = convertirInt(valores[12]);
            retorno.Chagas = convertirInt(valores[13]);
            retorno.Vdrl = convertirInt(valores[14]);
            retorno.Grupo = convertirInt(valores[15]);
            retorno.Factor = convertirInt(valores[16]);
            retorno.Color = convertirInt(valores[17]);
            retorno.Aspecto = convertirInt(valores[18]);
            retorno.Densidad = valores[19];
            retorno.Ph = convertirInt(valores[20]);
            retorno.Glucosa = convertirInt(valores[21]);
            retorno.Proteinas = convertirInt(valores[22]);
            retorno.HemoglobOrina = convertirInt(valores[23]);
            retorno.Bilirrubina = convertirInt(valores[24]);
            retorno.Celulas = convertirInt(valores[25]);
            retorno.Leucocitos = convertirInt(valores[26]);
            retorno.Hematies = convertirInt(valores[27]);
            retorno.Piocitos = convertirInt(valores[28]);
            retorno.Mucus = convertirInt(valores[29]);
            retorno.DictLab = convertirInt(valores[30]);
            retorno.ObsSerieRoja = valores[31];
            retorno.ObsSerieBlanca = valores[32];
            retorno.OtrosOrina1 = valores[33];
            retorno.OtrosOrina2 = valores[34];
            retorno.ObsLaborat = valores[35];
            return retorno;
        }

        private int convertirInt(string valor)
        {
            int number;
            bool result = Int32.TryParse(valor, out number);
            if (result) { return number; }
            return -1;
        }

        private bool ActualizaEstudioLaboratorio(string idTipoExamen, List<string> valores)
        {
            System.Diagnostics.Debug.WriteLine("[IMPORTAR] ActualizaEstudioLaboratorio llamado - idTipoExamen: " + idTipoExamen);
            System.Diagnostics.Debug.WriteLine("[IMPORTAR] Cantidad de valores: " + valores.Count);
            
            // Según la estructura: ExamenLaboral.id se relaciona directamente con TipoExamenDePaciente.id
            // Por lo tanto, usamos el idTipoExamen directamente como idExamenLaboral
            string idExamenLaboral = idTipoExamen;
            
            System.Diagnostics.Debug.WriteLine("[IMPORTAR] Usando idTipoExamen como idExamenLaboral: " + idExamenLaboral);
            
            // Verificar si el registro existe en ExamenLaboral
            string idExistente = verificarExamenLaboralExistente(idExamenLaboral);
            
            if (string.IsNullOrEmpty(idExistente))
            {
                System.Diagnostics.Debug.WriteLine("[IMPORTAR] NO se encontró ExamenLaboral, creando nuevo registro");
                
                // Crear el registro en ExamenLaboral usando el idTipoExamen como ID
                bool creado = examen.CrearExamenLaboral(idTipoExamen);
                
                if (!creado)
                {
                    System.Diagnostics.Debug.WriteLine("[IMPORTAR] ERROR al crear ExamenLaboral");
                    return false;
                }
                
                System.Diagnostics.Debug.WriteLine("[IMPORTAR] ExamenLaboral creado exitosamente");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[IMPORTAR] ExamenLaboral ya existe, actualizando");
            }
            
            bool resultado = examen.ActualizarExamenLaboralPorId(idExamenLaboral, valores);
            
            System.Diagnostics.Debug.WriteLine("[IMPORTAR] Resultado de ActualizarExamenLaboral: " + resultado);
            return resultado;
        }

        private string verificarExamenLaboralExistente(string idExamenLaboral)
        {
            string strSQL = "SELECT id FROM dbo.ExamenLaboral WHERE id = CONVERT(uniqueidentifier, '" + idExamenLaboral + "')";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            
            if (dtConsulta.Rows.Count > 0 && dtConsulta.Rows[0]["id"] != DBNull.Value)
            {
                return dtConsulta.Rows[0]["id"].ToString();
            }
            return "";
        }

        private string obtenerIdExamenLaboralPorTipoExamen(string idTipoExamen)
        {
            string strSQL = "SELECT idExamenLaboral FROM dbo.ConsultaLaboral WHERE idTipoExamen = '" + idTipoExamen + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            
            if (dtConsulta.Rows.Count > 0 && dtConsulta.Rows[0]["idExamenLaboral"] != DBNull.Value)
            {
                return dtConsulta.Rows[0]["idExamenLaboral"].ToString();
            }
            return "";
        }

        private void ValidarValores()
        {
            string strResultado = "";

            if (valoresInvalidos.Rows.Count > 0)
            {
                for (int i = 0; i < valoresInvalidos.Rows.Count; i++)
                {
                    strResultado = valoresInvalidos.Rows[i][1].ToString();

                    switch (strResultado)
                    {
                        case "0":
                            valoresInvalidos.Rows[i][1] = "Fecha";
                            break;
                        case "1":
                            valoresInvalidos.Rows[i][1] = "Orden";
                            break;
                        case "2":
                            valoresInvalidos.Rows[i][1] = "GR (Globulos Rojos)";
                            break;
                        case "3":
                            valoresInvalidos.Rows[i][1] = "GB (Globulos Blancos)";
                            break;
                        case "4":
                            valoresInvalidos.Rows[i][1] = "HGB (Hemoglobina)";
                            break;
                        case "5":
                            valoresInvalidos.Rows[i][1] = "HTC (Hematocrito)";
                            break;
                        case "6":
                            valoresInvalidos.Rows[i][1] = "ERI (Eritrosedimentación)";
                            break;
                        case "7":
                            valoresInvalidos.Rows[i][1] = "NC ()";
                            break;
                        case "8":
                            valoresInvalidos.Rows[i][1] = "NS ()";
                            break;
                        case "9":
                            valoresInvalidos.Rows[i][1] = "EOS (Eosinófilos)";
                            break;
                        case "10":
                            valoresInvalidos.Rows[i][1] = "BAS (Basófilos)";
                            break;
                        case "11":
                            valoresInvalidos.Rows[i][1] = "LIN (Linfocitos)";
                            break;
                        case "12":
                            valoresInvalidos.Rows[i][1] = "MON (Monocitos)";
                            break;
                        case "14":
                            valoresInvalidos.Rows[i][1] = "GLU (Glucemia)";
                            break;
                        case "15":
                            valoresInvalidos.Rows[i][1] = "URE (Uremia)";
                            break;
                        case "16":
                            valoresInvalidos.Rows[i][1] = "CHA (Chagas)";
                            break;
                        case "17":
                            valoresInvalidos.Rows[i][1] = "COL (Color)";
                            break;
                        case "18":
                            valoresInvalidos.Rows[i][1] = "ASP (Aspecto)";
                            break;
                        case "19":
                            valoresInvalidos.Rows[i][1] = "DEN Densidad";
                            break;
                        case "20":
                            valoresInvalidos.Rows[i][1] = "PH";
                            break;
                        case "21":
                            valoresInvalidos.Rows[i][1] = "GLU (Glucosa)";
                            break;
                        case "22":
                            valoresInvalidos.Rows[i][1] = "PRO (Proteinas)";
                            break;
                        case "23":
                            valoresInvalidos.Rows[i][1] = "HGB (Hemoglobina)";
                            break;
                        case "24":
                            valoresInvalidos.Rows[i][1] = "CC ()";
                            break;
                        case "25":
                            valoresInvalidos.Rows[i][1] = "BIL (Billirubina)";
                            break;
                        case "26":
                            valoresInvalidos.Rows[i][1] = "CEL (Celulas)";
                            break;
                        case "27":
                            valoresInvalidos.Rows[i][1] = "LEU (Leucocitos)";
                            break;
                        case "28":
                            valoresInvalidos.Rows[i][1] = "HEM (Hematies)";
                            break;
                        case "29":
                            valoresInvalidos.Rows[i][1] = "PIO (Piociotos)";
                            break;
                        case "30":
                            valoresInvalidos.Rows[i][1] = "MUC ()";
                            break;
                        case "31":
                            valoresInvalidos.Rows[i][1] = "HDL";
                            break;
                        case "32":
                            valoresInvalidos.Rows[i][1] = "COL";
                            break;
                        case "33":
                            valoresInvalidos.Rows[i][1] = "TGL";
                            break;
                        case "34":
                            valoresInvalidos.Rows[i][1] = "LDL";
                            break;
                        case "35":
                            valoresInvalidos.Rows[i][1] = "GS";
                            break;
                        case "36":
                            valoresInvalidos.Rows[i][1] = "RH";
                            break;
                        case "37":
                            valoresInvalidos.Rows[i][1] = "VDRCU";
                            break;
                        case "38":
                            valoresInvalidos.Rows[i][1] = "OBD (Observaciones)";
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void CampoRequerido(int puntero, DataRow fila)
        {
            foreach (DataRow row in dtDatoRequerido.Rows)
            {
                // [4] HGB (Hemoglobina) - MANTENIDO
                if ((fila.ItemArray[4].ToString() == "" || fila.ItemArray[4].ToString() == "*") && Convert.ToBoolean(row.ItemArray[0].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Hemoglobina");
                }
                else if ((fila.ItemArray[4].ToString() != "" || fila.ItemArray[4].ToString() != "*") && Convert.ToBoolean(row.ItemArray[0].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Hemoglobina ");
                }

                // [6] ERI (Eritrosedimentación) - MANTENIDO
                if ((fila.ItemArray[6].ToString() == "" || fila.ItemArray[6].ToString() == "*") && Convert.ToBoolean(row.ItemArray[1].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Eritrosedimentación");
                }
                else if ((fila.ItemArray[6].ToString() != "" || fila.ItemArray[6].ToString() != "*") && Convert.ToBoolean(row.ItemArray[1].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Eritrosedimentación");
                }

                // [35] GS (Grupo y Factor combinados) - ANTES ERA [33] Grupo y [34] Factor
                if ((fila.ItemArray[35].ToString() == "" || fila.ItemArray[35].ToString() == "*") && Convert.ToBoolean(row.ItemArray[2].ToString()))
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Grupo y Factor");
                }
                else if ((fila.ItemArray[35].ToString() != "" && fila.ItemArray[35].ToString() != "*") && !Convert.ToBoolean(row.ItemArray[2].ToString()))
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Grupo y Factor");
                }

                // [14] GLU (Glucemia) - MANTENIDO
                if ((fila.ItemArray[14].ToString() == "" || fila.ItemArray[14].ToString() == "*") && Convert.ToBoolean(row.ItemArray[3].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Glucemia");
                }
                else if ((fila.ItemArray[14].ToString() != "" && fila.ItemArray[14].ToString() != "*") && Convert.ToBoolean(row.ItemArray[3].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Glucemia");
                }

                // [15] URE (Uremia) - MANTENIDO
                if ((fila.ItemArray[15].ToString() == "" || fila.ItemArray[15].ToString() == "*") && Convert.ToBoolean(row.ItemArray[4].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Uremia");
                }
                else if ((fila.ItemArray[15].ToString() != "" && fila.ItemArray[15].ToString() != "*") && Convert.ToBoolean(row.ItemArray[4].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Uremia");
                }

                // [16] Chagas - YA NO EXISTE en el nuevo Excel
                // Comentado ya que Chagas ya no está en el nuevo formato
                // if ((fila.ItemArray[16].ToString() == "" || fila.ItemArray[16].ToString() == "*") && Convert.ToBoolean(row.ItemArray[5].ToString()) == true)
                // {
                //     dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Chagas");
                // }
                // else if ((fila.ItemArray[16].ToString() != "" && fila.ItemArray[16].ToString() != "*") && Convert.ToBoolean(row.ItemArray[5].ToString()) == false)
                // {
                //     dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Chagas");
                // }

                // [37] VDRCU (VDRL) - ANTES ERA [35] VDRL
                if ((fila.ItemArray[37].ToString() == "" || fila.ItemArray[37].ToString() == "*") && Convert.ToBoolean(row.ItemArray[6].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de VDRL");
                }
                else if ((fila.ItemArray[37].ToString() != "" && fila.ItemArray[37].ToString() != "*") && Convert.ToBoolean(row.ItemArray[6].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) VDRL");
                }

                // Comentado para permitir importación sin estudios de lípidos requeridos
                // [17] COL (Colesterol) - ANTES ERA [32] Col. Total
                // if ((fila.ItemArray[17].ToString() == "" || fila.ItemArray[17].ToString() == "*") && Convert.ToBoolean(row.ItemArray[8].ToString()) == true)
                // {
                //     dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Col. Total");
                // }
                // else if ((fila.ItemArray[17].ToString() != "" && fila.ItemArray[17].ToString() != "*") && Convert.ToBoolean(row.ItemArray[8].ToString()) == false)
                // {
                //     dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Col. Total");
                // }

                // Comentado para permitir importación sin estudios de lípidos requeridos
                // [34] LDL - MANTENIDO
                // if ((fila.ItemArray[34].ToString() == "" || fila.ItemArray[34].ToString() == "*" || Convert.ToInt32(fila.ItemArray[34]) == 0) && Convert.ToBoolean(row.ItemArray[9].ToString()) == true)
                // {
                //     dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de LDL");
                // }
                // else if ((fila.ItemArray[34].ToString() != "" && fila.ItemArray[34].ToString() != "*" && Convert.ToInt32(fila.ItemArray[34]) != 0) && Convert.ToBoolean(row.ItemArray[9].ToString()) == false)
                // {
                //     dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) LDL");
                // }

                // Comentado para permitir importación sin estudios de lípidos requeridos
                // [31] HDL - MANTENIDO
                // if ((fila.ItemArray[31].ToString() == "" || fila.ItemArray[31].ToString() == "*") && Convert.ToBoolean(row.ItemArray[10].ToString()) == true)
                // {
                //     dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de HDL");
                // }
                // else if ((fila.ItemArray[31].ToString() != "" && fila.ItemArray[31].ToString() != "*") && Convert.ToBoolean(row.ItemArray[10].ToString()) == false)
                // {
                //     dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) HDL");
                // }

                // Comentado para permitir importación sin estudios de lípidos requeridos
                // [33] TGL (Triglicéridos) - MANTENIDO
                // if ((fila.ItemArray[33].ToString() == "" || fila.ItemArray[33].ToString() == "*") && Convert.ToBoolean(row.ItemArray[11].ToString()) == true)
                // {
                //     dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Triglic.");
                // }
                // else if ((fila.ItemArray[33].ToString() != "" && fila.ItemArray[33].ToString() != "*") && Convert.ToBoolean(row.ItemArray[11].ToString()) == false)
                // {
                //     dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Triglic.");
                // }

                // Orina: [19] DEN, [20] PH, [21] GLU, [22] PRO, [25] BIL - Simplificado
                if (((fila.ItemArray[19].ToString() == "" || fila.ItemArray[19].ToString() == "*") ||
                    (fila.ItemArray[20].ToString() == "" || fila.ItemArray[20].ToString() == "*") ||
                    (fila.ItemArray[21].ToString() == "" || fila.ItemArray[21].ToString() == "*")) &&
                    Convert.ToBoolean(row.ItemArray[12].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Incompleto Análisis de Orina");
                }
                else if (((fila.ItemArray[19].ToString() != "" && fila.ItemArray[19].ToString() != "*") ||
                    (fila.ItemArray[20].ToString() != "" && fila.ItemArray[20].ToString() != "*") ||
                    (fila.ItemArray[21].ToString() != "" && fila.ItemArray[21].ToString() != "*")) &&
                    Convert.ToBoolean(row.ItemArray[12].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Análisis de Orina");
                }
            }
        }

        private int ObtieneNroOrden(string Ident)
        {
            string strCorregido = "";
            int intNumero = 0;

            if (Ident.Contains("L"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("L"), 2);
                intNumero = Convert.ToInt32(strCorregido);

            }
            else if (Ident.Contains("EC"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("E"), 3);
                intNumero = Convert.ToInt32(strCorregido);
            }
            else if (Ident.Contains("C"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("C"), 2);
                intNumero = Convert.ToInt32(strCorregido);
            }
            else if (Ident.Contains("R"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("R"), 2);
                intNumero = Convert.ToInt32(strCorregido);
            }

            return intNumero;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImpExcel_Click(object sender, EventArgs e)
        {
            tbArchivo.Clear();
            openFileDialog.Filter = "Archivos de Excel |*.xlsx; *.xls";
            DialogResult result = openFileDialog.ShowDialog();
            tbArchivo.Text = openFileDialog.FileName;
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            if (tbArchivo.Text != "")
            {
                DialogResult resul = MessageBox.Show("¿Desea comenzar la importación de laboratorios?", "Importar Laboratorios",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == resul)
                {
                    importar();
                }
            }
        }

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
