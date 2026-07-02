using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocioMepryl;
using CapaPresentacionBase;
using Comunes;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class frmPrecioPromo : DevExpress.XtraEditors.XtraForm
    {
        private PrecioPromo precioPromo;
        private PrecioPublico precioPublico;
        private bool yaInicializado = false;
        private decimal[] _coefsPromo = new decimal[12];
        private decimal[] _coefsPublico = new decimal[12];
        private decimal[] _factoresPublico = new decimal[12];

        private decimal[] _coefs 
        { 
            get { return EsPrecioPublico() ? _coefsPublico : _coefsPromo; }
            set { if (EsPrecioPublico()) _coefsPublico = value; else _coefsPromo = value; }
        }

        private static readonly string[] NombresMeses =
        {
            "Enero","Febrero","Marzo","Abril","Mayo","Junio",
            "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"
        };

        public frmPrecioPromo(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            precioPromo = new PrecioPromo();
            precioPublico = new PrecioPublico();

            for (int i = 0; i < 12; i++)
            {
                _coefsPromo[i] = 1;
                _coefsPublico[i] = 1;
                _factoresPublico[i] = 0;
            }

            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            this.cboMesVariacion.SelectedIndexChanged += new System.EventHandler(this.cboMesVariacion_SelectedIndexChanged);
            this.dgvObsPre.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObsPre_CellContentClick);
        }

        private void frmPrecioPromo_Load(object sender, EventArgs e)
        {
            // Asegurar que la tabla CoeficientePrecio tenga la columna Tipo
            try
            {
                string checkSql = "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('CoeficientePrecio') AND name = 'Tipo') " +
                                  "BEGIN " +
                                  "  ALTER TABLE CoeficientePrecio ADD Tipo VARCHAR(20) NOT NULL DEFAULT 'PROMO'; " +
                                  "  ALTER TABLE CoeficientePrecio DROP CONSTRAINT UQ_CoeficientePrecio_MesAnio; " +
                                  "  ALTER TABLE CoeficientePrecio ADD CONSTRAINT UQ_CoeficientePrecio_MesAnioTipo UNIQUE (Mes, Anio, Tipo); " +
                                  "END";
                SQLConnector.obtenerTablaSegunConsultaString(checkSql);
            }
            catch { /* Silencioso si falla, probablemente por permisos o ya existe */ }

            foreach (DataGridViewColumn col in dgvPrecios.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (DataGridViewColumn col in dgvPrecioPublico.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            ConfigurarOrdenColumnas(dgvPrecios);
            ConfigurarOrdenColumnas(dgvPrecioPublico);

            ConfigurarGrillaConfig();
            nudAnio.Value = DateTime.Now.Year;
            cboMesVariacion.SelectedIndex = DateTime.Now.Month; // 0 = Todos, 1-12 = mes
            
            if (EsPrecioPublico())
                lblTitulo.Text = "  Precios Públicos";
            else
                lblTitulo.Text = "  Precios Promos";

            CargarGrilla();
            yaInicializado = true;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (yaInicializado)
                CargarGrilla();
        }

        private bool EsPrecioPublico()
        {
            return tabControl.SelectedTab == tabPrecioPublico;
        }

        private DataGridView ObtenerDGVActual()
        {
            return EsPrecioPublico() ? dgvPrecioPublico : dgvPrecios;
        }

        private DataTable ObtenerDatosActual(int anio)
        {
            return EsPrecioPublico() ? precioPublico.ListarPreciosPublicoAnio(anio) : precioPromo.ListarPreciosPublicoAnio(anio);
        }

        private void GuardarDatosActual(int anio, DataTable dtDatos)
        {
            if (EsPrecioPublico())
                precioPublico.GuardarPreciosPublicoAnio(anio, dtDatos);
            else
                precioPromo.GuardarPreciosPublicoAnio(anio, dtDatos);
        }

        private bool ExistenPreciosActual(int anio)
        {
            return EsPrecioPublico() ? precioPublico.ExistenPreciosAnio(anio) : precioPromo.ExistenPreciosAnio(anio);
        }

        private DataTable ObtenerCoeficientesActual(int anio)
        {
            return EsPrecioPublico() ? precioPublico.ListarCoeficientesAnio(anio) : precioPromo.ListarCoeficientesAnio(anio);
        }

        private void GuardarCoeficientesActual(int anio, decimal[] coef)
        {
            if (EsPrecioPublico())
                precioPublico.GuardarCoeficientesAnio(anio, coef);
            else
                precioPromo.GuardarCoeficientesAnio(anio, coef);
        }

        private void CopiarPreciosActual(int mesOrigen, int anioOrigen, int mesDestino, int anioDestino)
        {
            if (EsPrecioPublico())
                precioPublico.CopiarPrecios(mesOrigen, anioOrigen, mesDestino, anioDestino);
            else
                precioPromo.CopiarPrecios(mesOrigen, anioOrigen, mesDestino, anioDestino);
        }

        private void AplicarVariacionActual(int mes, int anio, decimal porcentaje)
        {
            if (EsPrecioPublico())
                precioPublico.AplicarVariacion(mes, anio, porcentaje);
            else
                precioPromo.AplicarVariacion(mes, anio, porcentaje);
        }

        private void CargarGrilla()
        {
            if (tabControl.SelectedTab == tabPrecioPublico || tabControl.SelectedTab == tabPrecios)
            {
                int anio = (int)nudAnio.Value;
                DataGridView dgv = ObtenerDGVActual();

                dgv.Rows.Clear();

                // Cargar coeficientes
                _coefs = new decimal[12];
                for (int i = 0; i < 12; i++) _coefs[i] = 1;
                DataTable dtCoef = ObtenerCoeficientesActual(anio);
                foreach (DataRow row in dtCoef.Rows)
                {
                    int mes = Convert.ToInt32(row["Mes"]);
                    if (mes >= 1 && mes <= 12)
                        _coefs[mes - 1] = Convert.ToDecimal(row["Coeficiente"]);
                }

                // Cargar factores públicos y actualizar la UI
                _factoresPublico = ObtenerFactoresAnio(anio);
                if (cboMesVariacion.SelectedIndex > 0)
                {
                    txtVariacion.Text = _factoresPublico[cboMesVariacion.SelectedIndex - 1].ToString("0.####", System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    txtVariacion.Text = "0";
                }

                // Cargar datos
                DataTable dt = ObtenerDatosActual(anio);
                foreach (DataRow row in dt.Rows)
                {
                    int idx = dgv.Rows.Add();
                    dgv.Rows[idx].Cells[ObtenerNombreColumnaIdEspecialidad(dgv)].Value = row["idEspecialidad"].ToString();
                    dgv.Rows[idx].Cells[ObtenerNombreColumnaMotivo(dgv)].Value = row["Motivo"].ToString();
                    dgv.Rows[idx].Cells[ObtenerNombreColumnaTipo(dgv)].Value = row["Tipo"].ToString();
                    dgv.Rows[idx].Cells[ObtenerNombreColumnaDescripcion(dgv)].Value = row["Descripcion"].ToString();

                    // Cargar IPC
                    decimal ipcBase = (row["IPCBase"] == DBNull.Value) ? 0m : Convert.ToDecimal(row["IPCBase"]);
                    dgv.Rows[idx].Cells[ObtenerNombreColumnaIPCBase(dgv)].Value = ipcBase;

                    // Cargar precios y coeficientes
                    for (int mes = 1; mes <= 12; mes++)
                    {
                        string colPromo = "Promo" + mes.ToString("00");
                        string colCoef = "Coef" + mes.ToString("00");
                        decimal valorPromo = (row[colPromo] == DBNull.Value) ? 0 : Convert.ToDecimal(row[colPromo]);
                        decimal coefInd = (row[colCoef] == DBNull.Value) ? 0m : Convert.ToDecimal(row[colCoef]);
                        dgv.Rows[idx].Cells[5 + (mes - 1) * 2].Value = valorPromo;
                        dgv.Rows[idx].Cells[6 + (mes - 1) * 2].Value = coefInd;
                    }
                }

                // Actualizar encabezados de coeficientes
                for (int mes = 1; mes <= 12; mes++)
                {
                    dgv.Columns[6 + (mes - 1) * 2].HeaderText = _coefs[mes - 1].ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);
                }
                dgv.Columns[ObtenerNombreColumnaIPCBase(dgv)].HeaderText = _coefs[0].ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);

                txtBuscar_TextChanged(this, EventArgs.Empty);
            }
            else if (tabControl.SelectedTab == tabConfig)
            {
                CargarGrillaConfig();
            }
            else if (tabControl.SelectedTab == tabObsPre)
            {
                CargarGrillaObsPre();
            }
        }

        private void CargarGrillaObsPre()
        {
            try
            {
                dgvObsPre.Rows.Clear();
                DataTable dt = SQLConnector.obtenerTablaSegunConsultaString("SELECT id, texto, activo FROM ObservacionPredefinida ORDER BY texto");
                
                Image imgEliminar = IconChar.TrashAlt.ToBitmap(Color.IndianRed, 16);

                foreach (DataRow dr in dt.Rows)
                {
                    dgvObsPre.Rows.Add(dr["id"], dr["texto"], dr["activo"], imgEliminar);
                }
                lblTotal.Text = $"Observaciones: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar observaciones: " + ex.Message);
            }
        }

        private void dgvPrecios_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            DataGridView dgv = ObtenerDGVActual();
            string colName = dgv.Columns[e.ColumnIndex].Name;
            
            // Detectar si es una columna de coeficiente (colCoefXX o colPublicoCoefXX)
            if (colName.Contains("Coef") && !colName.Contains("IPC"))
            {
                // Extraer el número de mes del final del nombre (siempre son los últimos 2 caracteres: 01, 02...)
                string strMes = colName.Substring(colName.Length - 2);
                if (!int.TryParse(strMes, out int mes)) return;

                string actual = _coefs[mes - 1].ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    "Coeficiente para " + NombresMeses[mes - 1] + ":", "Editar coeficiente", actual);
                
                if (string.IsNullOrWhiteSpace(input)) return;
                
                decimal v;
                if (!decimal.TryParse(input.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out v)) return;
                
                _coefs[mes - 1] = v;
                dgv.Columns[e.ColumnIndex].HeaderText = v.ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);

                int anio = (int)nudAnio.Value;
                GuardarCoeficientesActual(anio, _coefs);
                AplicarCalculoCoeficientesSucesivos(mes);

                // Si estamos en la pestaña Promo, actualizar también la grilla de Público automáticamente
                if (!EsPrecioPublico())
                {
                    RecalcularPrecioPublicoRelativoAPromo(mes);
                }
            }
        }

        private void AplicarCalculoCoeficientesSucesivos(int mesModificado)
        {
            try
            {
                DataGridView dgv = ObtenerDGVActual();
                dgv.CellEndEdit -= dgvPrecios_CellEndEdit;

                // Si estamos en Precio Público, el cálculo es RELATIVO a la grilla de Promos
                if (EsPrecioPublico())
                {
                    RecalcularPrecioPublicoRelativoAPromo(mesModificado);
                }
                else
                {
                    // Lógica original para Precio Promo (Sucesiva)
                    int mesInicio = mesModificado + 1;
                    if (mesInicio > 12) return;

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        // Procesamos todas las filas, incluso las ocultas por el filtro, 
                        // para mantener la consistencia total de la grilla.
                        if (row.IsNewRow) continue;

                        decimal[] originalValues = new decimal[13]; // índice 1..12
                        for (int m = mesInicio; m <= 12; m++)
                            originalValues[m] = ParseDecimal(row.Cells[5 + (m - 1) * 2].Value);

                        for (int mes = mesInicio; mes <= 12; mes++)
                    {
                        if (mes > mesInicio && originalValues[mes - 1] == 0m) continue;

                        decimal valorMesAnterior = ParseDecimal(row.Cells[5 + (mes - 2) * 2].Value);
                        decimal aumentoFijoFila = ParseDecimal(row.Cells[6 + (mes - 2) * 2].Value); // El valor "del medio" en pesos
                        decimal coefGlobal = _coefsPromo[mes - 2]; // El rojo de arriba del mes anterior
                        
                        // ✅ LÓGICA DE PRECIO FORZADO: Si el usuario pone un valor en el medio (ej. 1000), 
                        // el precio del mes siguiente ES ese valor (fuerza de precio).
                        // Si pone 0, se aplica el coeficiente global al precio anterior.
                        decimal nuevoValor;
                        if (aumentoFijoFila > 0)
                        {
                            nuevoValor = aumentoFijoFila;
                        }
                        else
                        {
                            nuevoValor = valorMesAnterior * coefGlobal;
                        }
                        
                        row.Cells[5 + (mes - 1) * 2].Value = nuevoValor;
                    }
                    }
                }

                string mensaje = EsPrecioPublico() 
                    ? $"Se han recalculado los precios públicos desde {NombresMeses[mesModificado - 1]} basándose en los precios Promo y el factor de relación."
                    : $"Se han recalculado los precios desde {NombresMeses[mesModificado]} hasta Diciembre aplicando los coeficientes y precios forzados.";
                
                MessageBox.Show(mensaje, "Cálculo aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar cálculo de coeficientes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ObtenerDGVActual().CellEndEdit += dgvPrecios_CellEndEdit;
            }
        }

        private void RecalcularPrecioPublicoRelativoAPromo(int mesModificado)
        {
            // ✅ LÓGICA SENIOR: Sincronizamos la grilla de Público usando los valores de la grilla Promo.
            // Esto asegura que tanto el Coeficiente Global como los Precios Forzados se trasladen correctamente.
            DataGridView dgvPromo = dgvPrecios;
            DataGridView dgvPublico = dgvPrecioPublico;

            foreach (DataGridViewRow rowPublico in dgvPublico.Rows)
            {
                if (rowPublico.IsNewRow) continue;

                string idEsp = rowPublico.Cells[ObtenerNombreColumnaIdEspecialidad(dgvPublico)].Value?.ToString();
                
                // Buscar la fila correspondiente en la grilla Promo por ID
                DataGridViewRow rowPromo = null;
                foreach (DataGridViewRow rP in dgvPromo.Rows)
                {
                    if (rP.Cells[ObtenerNombreColumnaIdEspecialidad(dgvPromo)].Value?.ToString() == idEsp)
                    {
                        rowPromo = rP;
                        break;
                    }
                }
                
                if (rowPromo == null) continue;

                // El bucle empieza en el mes modificado para afectar también al mes en curso con el factor nuevo
                int mesInicio = mesModificado;
                if (mesInicio == 0) mesInicio = 1;
                if (mesInicio > 12) return;

                // ✅ LÓGICA SENIOR: Detectar si ya existe un precio forzado previo en esta fila 
                // para decidir si seguimos la cadena o la relación con Promo.
                bool usoCadenaForzada = false;
                for (int m = 1; m < mesInicio; m++)
                {
                    if (ParseDecimal(rowPublico.Cells[6 + (m - 1) * 2].Value) > 0)
                    {
                        usoCadenaForzada = true;
                        break;
                    }
                }

                for (int mes = mesInicio; mes <= 12; mes++)
                {
                    // ✅ LÓGICA DE PRECIO FORZADO EN PÚBLICO:
                    // Si el usuario pone un valor en la columna del medio de la grilla Pública, ese valor manda.
                    decimal aumentoFijoFilaPublico = ParseDecimal(rowPublico.Cells[6 + (mes - 2) * 2].Value);
                    
                    if (aumentoFijoFilaPublico > 0)
                    {
                        rowPublico.Cells[5 + (mes - 1) * 2].Value = aumentoFijoFilaPublico;
                        usoCadenaForzada = true;
                    }
                    else if (usoCadenaForzada)
                    {
                        // Si estamos en una cadena forzada y el importe actual es 0,
                        // multiplicamos el PRECIO PÚBLICO ANTERIOR por el COEFICIENTE GLOBAL PÚBLICO.
                        decimal valorAnteriorPublico = 0;
                        decimal factorRelacion = 1;
                        if (mes > 1) 
                        {
                            valorAnteriorPublico = ParseDecimal(rowPublico.Cells[5 + (mes - 2) * 2].Value);
                            factorRelacion = _coefsPublico[mes - 2]; 
                        }
                        
                        decimal precioCalculado = valorAnteriorPublico * factorRelacion;
                        
                        // Y AQUÍ SE APLICA TU NUEVO FACTOR TAMBIÉN EN LA CASCADA FORZADA:
                        decimal factorDelMes = _factoresPublico[mes - 1];
                        if (factorDelMes > 0)
                        {
                            precioCalculado = precioCalculado * factorDelMes;
                        }

                        rowPublico.Cells[5 + (mes - 1) * 2].Value = Math.Ceiling(precioCalculado / 1000m) * 1000m;
                    }
                    else
                    {
                        // Si no hay fuerza de precio previa, seguimos la relación normal: Público(Mes) = Promo(Mes) * CoeficienteRojo(Mes-1)
                        decimal valorPromo = ParseDecimal(rowPromo.Cells[5 + (mes - 1) * 2].Value);
                        if (valorPromo == 0) continue;

                        // Se respeta la lógica base intocable (Coeficiente Rojo Público)
                        decimal factorRelacion = 1;
                        if (mes > 1)
                        {
                            factorRelacion = _coefsPublico[mes - 2]; 
                        }
                        
                        decimal precioPublicoCalculado = valorPromo * factorRelacion;
                        
                        // Y AQUÍ SE APLICA TU NUEVO FACTOR: Se multiplica el resultado por el Factor del mes actual
                        decimal factorDelMes = _factoresPublico[mes - 1];
                        if (factorDelMes > 0)
                        {
                            precioPublicoCalculado = precioPublicoCalculado * factorDelMes;
                        }

                        rowPublico.Cells[5 + (mes - 1) * 2].Value = Math.Ceiling(precioPublicoCalculado / 1000m) * 1000m;
                    }
                }
            }
        }

        private void AplicarCalculoCoeficientesSucesivosFila(int mesModificado, int rowIndex, bool cascadeSoloConValores = false)
        {
            try
            {
                DataGridView dgv = ObtenerDGVActual();
                dgv.CellEndEdit -= dgvPrecios_CellEndEdit;

                if (EsPrecioPublico())
                {
                    // ✅ LÓGICA SENIOR: Sincronizamos esta fila de Público usando los valores de la fila Promo correspondiente.
                    DataGridViewRow filaPublico = dgv.Rows[rowIndex];
                    string idEsp = filaPublico.Cells[ObtenerNombreColumnaIdEspecialidad(dgv)].Value?.ToString();
                    
                    // Buscar la fila Promo en la otra grilla
                    DataGridViewRow filaPromo = null;
                    foreach (DataGridViewRow rP in dgvPrecios.Rows)
                    {
                        if (rP.Cells[ObtenerNombreColumnaIdEspecialidad(dgvPrecios)].Value?.ToString() == idEsp)
                        {
                            filaPromo = rP;
                            break;
                        }
                    }

                    if (filaPromo != null)
                    {
                        // ✅ LÓGICA DE CADENA FORZADA: Detectar si hay fuerza de precio previa en esta fila
                        bool usoCadenaForzada = false;
                        for (int m = 1; m <= mesModificado; m++)
                        {
                            if (ParseDecimal(filaPublico.Cells[6 + (m - 1) * 2].Value) > 0)
                            {
                                usoCadenaForzada = true;
                                break;
                            }
                        }

                        // Empezamos desde el mes modificado
                        for (int mes = mesModificado; mes <= 12; mes++)
                        {
                            decimal aumentoFijoFilaPublico = ParseDecimal(filaPublico.Cells[6 + (mes - 2) * 2].Value);
                            
                            if (aumentoFijoFilaPublico > 0)
                            {
                                filaPublico.Cells[5 + (mes - 1) * 2].Value = aumentoFijoFilaPublico;
                                usoCadenaForzada = true;
                            }
                            else if (usoCadenaForzada)
                            {
                                decimal valorAnteriorPublico = ParseDecimal(filaPublico.Cells[5 + (mes - 2) * 2].Value);
                                decimal factorRelacion = _coefsPublico[mes - 2]; 
                                decimal precioCalculado = valorAnteriorPublico * factorRelacion;
                                
                                // Aquí aplicamos el factor multiplicador nuevo a la cascada forzada
                                decimal factorDelMes = _factoresPublico[mes - 1];
                                if (factorDelMes > 0)
                                {
                                    precioCalculado = precioCalculado * factorDelMes;
                                }

                                filaPublico.Cells[5 + (mes - 1) * 2].Value = Math.Ceiling(precioCalculado / 1000m) * 1000m;
                            }
                            else
                            {
                                decimal valorPromo = ParseDecimal(filaPromo.Cells[5 + (mes - 1) * 2].Value);
                                if (valorPromo == 0) continue;

                                // Lógica base intocable
                                decimal factorRelacion = _coefsPublico[mes - 2];
                                decimal precioPublicoCalculado = valorPromo * factorRelacion;

                                // Aquí aplicamos el factor multiplicador nuevo
                                decimal factorDelMes = _factoresPublico[mes - 1];
                                if (factorDelMes > 0)
                                {
                                    precioPublicoCalculado = precioPublicoCalculado * factorDelMes;
                                }

                                filaPublico.Cells[5 + (mes - 1) * 2].Value = Math.Ceiling(precioPublicoCalculado / 1000m) * 1000m;
                            }
                        }
                    }
                }
                else
                {
                    // Lógica original de cascada para Promo
                    int mesInicio = mesModificado + 1;
                    DataGridViewRow filaActual = dgv.Rows[rowIndex];

                    decimal[] originalValues = new decimal[13]; // índice 1..12
                    for (int m = mesInicio; m <= 12; m++)
                        originalValues[m] = ParseDecimal(filaActual.Cells[5 + (m - 1) * 2].Value);

                    for (int mes = mesInicio; mes <= 12; mes++)
                    {
                        if (!filaActual.Visible) continue;

                        if (cascadeSoloConValores)
                        {
                            if (originalValues[mes] == 0m) continue;
                        }
                        else
                        {
                            if (mes > mesInicio && originalValues[mes - 1] == 0m) continue;
                        }

                        decimal valorBase = ParseDecimal(filaActual.Cells[5 + (mes - 2) * 2].Value);
                        decimal aumentoFijoFila = ParseDecimal(filaActual.Cells[6 + (mes - 2) * 2].Value);
                        decimal coefGlobal = _coefsPromo[mes - 2];
                        
                        // ✅ LÓGICA DE PRECIO FORZADO: Consistente con el cálculo masivo
                        decimal nuevoValor;
                        if (aumentoFijoFila > 0)
                        {
                            nuevoValor = aumentoFijoFila;
                        }
                        else
                        {
                            nuevoValor = valorBase * coefGlobal;
                        }
                        
                        filaActual.Cells[5 + (mes - 1) * 2].Value = nuevoValor;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar cálculo de coeficientes en la fila: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ObtenerDGVActual().CellEndEdit += dgvPrecios_CellEndEdit;
            }
        }

        private decimal[] ObtenerCoeficientesAnio(int anio)
        {
            decimal[] result = new decimal[12];
            for (int i = 0; i < 12; i++) result[i] = 1;
            DataTable dt = ObtenerCoeficientesActual(anio);
            foreach (DataRow row in dt.Rows)
            {
                int mes = Convert.ToInt32(row["Mes"]);
                if (mes >= 1 && mes <= 12)
                    result[mes - 1] = Convert.ToDecimal(row["Coeficiente"]);
            }
            return result;
        }

        private decimal AplicarFormulaIncremento(decimal valorN4, decimal incrementoPromosFebrero)
        {
            return valorN4 * incrementoPromosFebrero;
        }

        private void nudAnio_ValueChanged(object sender, EventArgs e)
        {
            if (yaInicializado) CargarGrilla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPrecioPublico || tabControl.SelectedTab == tabPrecios)
            {
                GuardarPrecios();
            }
            else if (tabControl.SelectedTab == tabConfig)
            {
                GuardarConfig();
                MessageBox.Show("Configuración guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tabControl.SelectedTab == tabObsPre)
            {
                GuardarObsPre();
            }
        }

        private void GuardarPrecios()
        {
            try
            {
                int anio = (int)nudAnio.Value;
                DataGridView dgv = ObtenerDGVActual();

                DataTable dtGuardar = new DataTable();
                dtGuardar.Columns.Add("idEspecialidad", typeof(string));
                dtGuardar.Columns.Add("Descripcion", typeof(string));
                dtGuardar.Columns.Add("IPCBase", typeof(decimal));
                for (int mes = 1; mes <= 12; mes++)
                {
                    dtGuardar.Columns.Add("Promo" + mes.ToString("00"), typeof(decimal));
                    dtGuardar.Columns.Add("Coef" + mes.ToString("00"), typeof(decimal));
                }

                GuardarCoeficientesActual(anio, _coefs);

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow || !row.Visible) continue;
                    
                    // Asegurarnos de que tenga el ID antes de guardar
                    string idEsp = row.Cells[ObtenerNombreColumnaIdEspecialidad(dgv)].Value?.ToString();
                    if (string.IsNullOrEmpty(idEsp)) continue;

                    DataRow dr = dtGuardar.NewRow();
                    dr["idEspecialidad"] = idEsp;
                    dr["Descripcion"] = row.Cells[ObtenerNombreColumnaDescripcion(dgv)].Value?.ToString() ?? "";
                    dr["IPCBase"] = ParseDecimal(row.Cells[ObtenerNombreColumnaIPCBase(dgv)].Value);
                    
                    // Buscar en qué índice empiezan los meses (dependiendo si tiene Tipo/Motivo, el offset cambia)
                    int colBaseMeses = 5; // Por defecto
                    if (dgv.Columns.Contains("colPromo01")) colBaseMeses = dgv.Columns["colPromo01"].Index;
                    else if (dgv.Columns.Contains("colPublicoPromo01")) colBaseMeses = dgv.Columns["colPublicoPromo01"].Index;

                    for (int mes = 1; mes <= 12; mes++)
                    {
                        dr["Promo" + mes.ToString("00")] = ParseDecimal(row.Cells[colBaseMeses + (mes - 1) * 2].Value);
                        dr["Coef" + mes.ToString("00")] = ParseDecimal(row.Cells[colBaseMeses + 1 + (mes - 1) * 2].Value);
                    }
                    dtGuardar.Rows.Add(dr);
                }

                GuardarDatosActual(anio, dtGuardar);

                // ✅ NUEVA LÓGICA SENIOR: Si guardamos Promos, sincronizamos y guardamos Públicos automáticamente
                if (!EsPrecioPublico())
                {
                    // 1. Forzar el recálculo de la grilla pública basándose en los nuevos valores de Promo
                    RecalcularPrecioPublicoRelativoAPromo(1);

                    // 2. Generar el DataTable para guardar los Precios Públicos actualizados
                    DataTable dtPublicoGuardar = dtGuardar.Clone();
                    foreach (DataGridViewRow rowPub in dgvPrecioPublico.Rows)
                    {
                        if (rowPub.IsNewRow || !rowPub.Visible) continue;
                        
                        string idEspPub = rowPub.Cells[ObtenerNombreColumnaIdEspecialidad(dgvPrecioPublico)].Value?.ToString();
                        if (string.IsNullOrEmpty(idEspPub)) continue;

                        DataRow drPub = dtPublicoGuardar.NewRow();
                        drPub["idEspecialidad"] = idEspPub;
                        drPub["Descripcion"] = rowPub.Cells[ObtenerNombreColumnaDescripcion(dgvPrecioPublico)].Value?.ToString() ?? "";
                        drPub["IPCBase"] = ParseDecimal(rowPub.Cells[ObtenerNombreColumnaIPCBase(dgvPrecioPublico)].Value);
                        
                        int colBaseMesesPub = dgvPrecioPublico.Columns.Contains("colPublicoPromo01") 
                            ? dgvPrecioPublico.Columns["colPublicoPromo01"].Index 
                            : 5;

                        for (int mes = 1; mes <= 12; mes++)
                        {
                            drPub["Promo" + mes.ToString("00")] = ParseDecimal(rowPub.Cells[colBaseMesesPub + (mes - 1) * 2].Value);
                            drPub["Coef" + mes.ToString("00")] = ParseDecimal(rowPub.Cells[colBaseMesesPub + 1 + (mes - 1) * 2].Value);
                        }
                        dtPublicoGuardar.Rows.Add(drPub);
                    }

                    // 3. Guardar en la tabla de Precios Públicos
                    precioPublico.GuardarPreciosPublicoAnio(anio, dtPublicoGuardar);
                    precioPublico.GuardarCoeficientesAnio(anio, _coefsPublico);
                }

                MessageBox.Show("Precios guardados y sincronizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar precios: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarObsPre()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow row in dgvObsPre.Rows)
                {
                    if (row.IsNewRow) continue;

                    string id = row.Cells["colObsId"].Value?.ToString();
                    string texto = row.Cells["colObsTexto"].Value?.ToString()?.Replace("'", "''") ?? "";
                    bool activoVal = row.Cells["colObsActivo"].Value != null && Convert.ToBoolean(row.Cells["colObsActivo"].Value);
                    string activo = activoVal ? "1" : "0";

                    if (string.IsNullOrWhiteSpace(texto)) continue;

                    if (string.IsNullOrEmpty(id))
                    {
                        sb.AppendLine($"INSERT INTO ObservacionPredefinida (texto, activo) VALUES ('{texto}', {activo});");
                    }
                    else
                    {
                        sb.AppendLine($"UPDATE ObservacionPredefinida SET texto = '{texto}', activo = {activo} WHERE id = {id};");
                    }
                }

                if (sb.Length > 0)
                {
                    SQLConnector.obtenerTablaSegunConsultaString(sb.ToString());
                    MessageBox.Show("Observaciones guardadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrillaObsPre();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar observaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvObsPre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvObsPre.Columns["colObsAcciones"].Index && e.RowIndex >= 0)
            {
                if (dgvObsPre.Rows[e.RowIndex].IsNewRow) return;

                string id = dgvObsPre.Rows[e.RowIndex].Cells["colObsId"].Value?.ToString();
                string texto = dgvObsPre.Rows[e.RowIndex].Cells["colObsTexto"].Value?.ToString();

                DialogResult dr = MessageBox.Show($"¿Está seguro que desea eliminar la observación: \"{texto}\"?", 
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        try
                        {
                            SQLConnector.obtenerTablaSegunConsultaString($"DELETE FROM ObservacionPredefinida WHERE id = {id}");
                            MessageBox.Show("Observación eliminada correctamente.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar de la base de datos: " + ex.Message);
                        }
                    }
                    CargarGrillaObsPre();
                }
            }
        }

        private void btnCopiarAnio_Click(object sender, EventArgs e)
        {
            int anioActual = (int)nudAnio.Value;
            int anioAnterior = anioActual - 1;

            if (!ExistenPreciosActual(anioAnterior))
            {
                MessageBox.Show("No existen precios en " + anioAnterior + " para copiar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Se copiarán los precios de " + anioAnterior + " a " + anioActual +
                " (solo prestaciones faltantes por mes).\n¿Continuar?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                for (int mes = 1; mes <= 12; mes++)
                    CopiarPreciosActual(mes, anioAnterior, mes, anioActual);

                MessageBox.Show("Precios copiados desde " + anioAnterior + ".", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al copiar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            mnuAplicar.Show(btnAplicar, 0, btnAplicar.Height);
        }

        private void mnuVariacion_Click(object sender, EventArgs e)
        {
            AplicarVariacionGrilla();
        }

        private decimal[] ObtenerFactoresAnio(int anio)
        {
            decimal[] result = new decimal[12];
            for (int i = 0; i < 12; i++) result[i] = 0;
            
            // Asumiendo que guardamos los factores en la misma tabla con Tipo='FACTOR'
            string sql = $"SELECT Mes, Coeficiente FROM CoeficientePrecio WHERE Anio = {anio} AND Tipo = 'FACTOR'";
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(sql);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int mes = Convert.ToInt32(row["Mes"]);
                    if (mes >= 1 && mes <= 12)
                        result[mes - 1] = Convert.ToDecimal(row["Coeficiente"]);
                }
            }
            return result;
        }

        private void GuardarFactoresAnio(int anio)
        {
            for (int mes = 1; mes <= 12; mes++)
            {
                // Solo inserta o actualiza; y lo formatea correctamente para SQL
                string valorSQL = _factoresPublico[mes - 1].ToString("0.####", System.Globalization.CultureInfo.InvariantCulture);
                string sql = $"IF EXISTS (SELECT * FROM CoeficientePrecio WHERE Mes={mes} AND Anio={anio} AND Tipo='FACTOR') " +
                             $"UPDATE CoeficientePrecio SET Coeficiente={valorSQL} WHERE Mes={mes} AND Anio={anio} AND Tipo='FACTOR' " +
                             $"ELSE " +
                             $"INSERT INTO CoeficientePrecio (Mes, Anio, Tipo, Coeficiente) VALUES ({mes}, {anio}, 'FACTOR', {valorSQL})";
                SQLConnector.obtenerTablaSegunConsultaString(sql);
            }
        }

        private void AplicarVariacionGrilla()
        {
            decimal factor = ObtenerFactor();
            if (factor < 0)
            {
                MessageBox.Show("Ingrese un valor válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int mesIdx = cboMesVariacion.SelectedIndex; // 0 = Todos, 1-12 = mes
            string alcanceMes = mesIdx == 0 ? "todos los meses" : NombresMeses[mesIdx - 1];

            DialogResult dr = MessageBox.Show(
                $"¿Está seguro que desea aplicar un factor de {factor} a {alcanceMes} en Precio Público?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (mesIdx == 0) // Todos
                {
                    for (int i = 0; i < 12; i++) _factoresPublico[i] = factor;
                }
                else
                {
                    _factoresPublico[mesIdx - 1] = factor;
                }
                
                // Forzar recálculo visualmente en la grilla
                RecalcularPrecioPublicoRelativoAPromo(mesIdx == 0 ? 1 : mesIdx);
                
                // Guardar Inmediatamente en BD
                GuardarFactoresAnio((int)nudAnio.Value);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            int visibles = 0;
            DataGridView dgv = ObtenerDGVActual();
            string colDesc = ObtenerNombreColumnaDescripcion(dgv);
            string colMotivo = ObtenerNombreColumnaMotivo(dgv);
            string colTipo = ObtenerNombreColumnaTipo(dgv);

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (string.IsNullOrEmpty(filtro))
                {
                    row.Visible = true;
                    visibles++;
                }
                else
                {
                    string desc = row.Cells[colDesc].Value?.ToString().ToLower() ?? "";
                    string motivo = row.Cells[colMotivo].Value?.ToString().ToLower() ?? "";
                    string tipo = row.Cells[colTipo].Value?.ToString().ToLower() ?? "";
                    row.Visible = desc.Contains(filtro) || motivo.Contains(filtro) || tipo.Contains(filtro);
                    if (row.Visible) visibles++;
                }
            }

            lblTotal.Text = "Prestaciones: " + visibles;

            // Filtrar también la pestaña de configuración
            foreach (DataGridViewRow row in dgvConfig.Rows)
            {
                if (string.IsNullOrEmpty(filtro))
                    row.Visible = true;
                else
                {
                    string desc = row.Cells[3].Value?.ToString().ToLower() ?? "";
                    string motivo = row.Cells[1].Value?.ToString().ToLower() ?? "";
                    string tipo = row.Cells[2].Value?.ToString().ToLower() ?? "";
                    row.Visible = desc.Contains(filtro) || motivo.Contains(filtro) || tipo.Contains(filtro);
                }
            }
        }

        private decimal ParseDecimal(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            decimal result;
            return decimal.TryParse(value.ToString(), out result) ? result : 0;
        }

        private decimal ObtenerFactor()
        {
            decimal valor;
            string texto = txtVariacion.Text.Replace(".", ",");
            if (!decimal.TryParse(texto, out valor)) return -1;
            return valor;
        }

        private void chkFactor_CheckedChanged(object sender, EventArgs e)
        {
            // Sin lógica, dejamos solo Factor
        }

        private void cboMesVariacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMesVariacion.SelectedIndex == 0)
            {
                txtVariacion.Text = "0";
            }
            else
            {
                // Si el factor es diferente de 0, lo mostramos, si no mostramos "0" para mantener la UI limpia.
                decimal factorActual = _factoresPublico[cboMesVariacion.SelectedIndex - 1];
                txtVariacion.Text = factorActual.ToString("0.####", System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        private void dgvPrecios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1 || e.ColumnIndex < 0) return;

            DataGridView dgv = (DataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            Color backColor = (colName.Contains("Coef") || colName.Contains("IPCBase")) ? Color.FromArgb(180, 0, 0) : Color.SeaGreen;

            using (var brush = new System.Drawing.SolidBrush(backColor))
                e.Graphics.FillRectangle(brush, e.CellBounds);

            string text = dgv.Columns[e.ColumnIndex].HeaderText;
            var font = e.CellStyle.Font ?? dgv.ColumnHeadersDefaultCellStyle.Font;
            TextRenderer.DrawText(e.Graphics, text, font, e.CellBounds, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordEllipsis);

            using (var pen = new System.Drawing.Pen(Color.FromArgb(100, 100, 100)))
            {
                e.Graphics.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
            }

            e.Handled = true;
        }

        private void dgvPrecios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridView dgv = (DataGridView)sender;
            string col = dgv.Columns[e.ColumnIndex].Name;

            if (col.Contains("Motivo") || (col.StartsWith("col") && col.Contains("Motivo")))
            {
                e.CellStyle.BackColor = Color.FromArgb(230, 245, 235);
                e.CellStyle.ForeColor = Color.FromArgb(20, 70, 40);
                e.CellStyle.SelectionBackColor = Color.FromArgb(230, 245, 235);
                e.CellStyle.SelectionForeColor = Color.Black;
            }
            else if (col.Contains("Tipo") || (col.StartsWith("col") && col.Contains("Tipo")))
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.FromArgb(30, 30, 90);
                e.CellStyle.SelectionBackColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.FromArgb(30, 30, 90);
            }
            else if (col.Contains("Descripcion") || (col.StartsWith("col") && col.Contains("Descripcion")))
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.FromArgb(20, 20, 20);
                e.CellStyle.SelectionBackColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.FromArgb(20, 20, 20);
            }
            else if (col.Contains("Promo") || (col.StartsWith("col") && col.Contains("Promo")))
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.FromArgb(20, 20, 20);
                e.CellStyle.SelectionBackColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.FromArgb(20, 20, 20);
            }
            else if (col == "colIPCBase" || col == "colPublicoIPCBase")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 240, 240);
                e.CellStyle.ForeColor = Color.FromArgb(0, 100, 200);
                e.CellStyle.SelectionBackColor = Color.FromArgb(220, 230, 240);
                e.CellStyle.SelectionForeColor = Color.FromArgb(0, 100, 200);
            }
            else if (col.Contains("Coef"))
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 210, 210);
                e.CellStyle.ForeColor = Color.FromArgb(140, 0, 0);
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 210);
                e.CellStyle.SelectionForeColor = Color.FromArgb(140, 0, 0);
            }
        }

        private void ConfigurarOrdenColumnas(DataGridView dgv)
        {
            string colIpc = ObtenerNombreColumnaIPCBase(dgv);
            string colDesc = ObtenerNombreColumnaDescripcion(dgv);

            if (dgv.Columns.Contains(colIpc))
                dgv.Columns[colIpc].DisplayIndex = 0;
            if (dgv.Columns.Contains(colDesc))
                dgv.Columns[colDesc].DisplayIndex = 1;

            string prefPromo = dgv.Columns.Contains("colPromo01") ? "colPromo" : "colPublicoPromo";
            string prefCoef = dgv.Columns.Contains("colCoef01") ? "colCoef" : "colPublicoCoef";

            int displayIndex = 2;
            for (int mes = 1; mes <= 12; mes++)
            {
                string promo = prefPromo + mes.ToString("00");
                string coef = prefCoef + mes.ToString("00");

                if (dgv.Columns.Contains(promo))
                    dgv.Columns[promo].DisplayIndex = displayIndex++;
                if (dgv.Columns.Contains(coef))
                    dgv.Columns[coef].DisplayIndex = displayIndex++;
            }
        }

        private string ObtenerNombreColumnaIdEspecialidad(DataGridView dgv)
        {
            return dgv.Columns.Contains("colIdEspecialidad") ? "colIdEspecialidad" : "colPublicoIdEspecialidad";
        }

        private string ObtenerNombreColumnaIPCBase(DataGridView dgv)
        {
            return dgv.Columns.Contains("colIPCBase") ? "colIPCBase" : "colPublicoIPCBase";
        }

        private string ObtenerNombreColumnaMotivo(DataGridView dgv)
        {
            return dgv.Columns.Contains("colMotivo") ? "colMotivo" : "colPublicoMotivo";
        }

        private string ObtenerNombreColumnaTipo(DataGridView dgv)
        {
            return dgv.Columns.Contains("colTipo") ? "colTipo" : "colPublicoTipo";
        }

        private string ObtenerNombreColumnaDescripcion(DataGridView dgv)
        {
            return dgv.Columns.Contains("colDescripcion") ? "colDescripcion" : "colPublicoDescripcion";
        }

        private void dgvPrecios_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;

            // Permitir editar las columnas de precios (colPromo), coeficientes (colCoef) e IPCBase
            if (!colName.Contains("Promo") && !colName.Contains("Coef") && !colName.Contains("IPCBase"))
            {
                e.Cancel = true;
                return;
            }
        }

        private void dgvPrecios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;

            if (colName.Contains("IPCBase"))
            {
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                decimal value = ParseDecimal(cell.Value);
                if (value < 0) value = 0m;
                cell.Value = value;
                if (value > 0)
                    AplicarCalculoCoeficientesSucesivosFila(1, e.RowIndex);
            }
            else if (colName.Contains("Promo"))
            {
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                decimal value = ParseDecimal(cell.Value);
                if (value < 0) value = 0;
                cell.Value = value;
                if (value > 0)
                {
                    int mes = int.Parse(colName.Substring(colName.IndexOf("Promo") + 5));
                    AplicarCalculoCoeficientesSucesivosFila(mes, e.RowIndex, cascadeSoloConValores: true);
                }
            }
            else if (colName.Contains("Coef"))
            {
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                decimal value = ParseDecimal(cell.Value);
                if (value < 0) value = 0;
                cell.Value = value;
                int mes = int.Parse(colName.Substring(colName.IndexOf("Coef") + 4));
                AplicarCalculoCoeficientesSucesivosFila(mes, e.RowIndex);
            }
        }

        private void dgvPrecios_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string colName = dgv.CurrentCell?.OwningColumn.Name ?? "";

            if ((colName.Contains("Promo") || colName.Contains("Coef") || colName.Contains("IPCBase")) && e.Control is TextBox textBox)
            {
                textBox.KeyPress -= NumericTextBox_KeyPress;
                textBox.KeyPress += NumericTextBox_KeyPress;
            }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ConfigurarGrillaConfig()
        {
            foreach (DataGridViewColumn col in dgvConfig.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvConfig.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 70, 140);
            dgvConfig.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvConfig.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConfig.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void CargarGrillaConfig()
        {
            dgvConfig.Rows.Clear();
            DataTable dt = precioPromo.ListarConfigEspecialidades();
            if (dt == null) return;
            foreach (DataRow row in dt.Rows)
            {
                int idx = dgvConfig.Rows.Add();
                dgvConfig.Rows[idx].Cells[0].Value = row["idEspecialidad"].ToString();
                dgvConfig.Rows[idx].Cells[1].Value = row["Motivo"].ToString();
                dgvConfig.Rows[idx].Cells[2].Value = row["Tipo"].ToString();
                dgvConfig.Rows[idx].Cells[3].Value = row["Descripcion"].ToString();
                dgvConfig.Rows[idx].Cells[4].Value = Convert.ToDecimal(row["Seña"]);
                dgvConfig.Rows[idx].Cells[5].Value = Convert.ToBoolean(row["LlevaPlanilla"]);
                dgvConfig.Rows[idx].Cells[6].Value = row["Observaciones"].ToString();
            }
        }

        private void GuardarConfig()
        {
            DataTable dtConfig = new DataTable();
            dtConfig.Columns.Add("idEspecialidad", typeof(string));
            dtConfig.Columns.Add("Seña", typeof(decimal));
            dtConfig.Columns.Add("LlevaPlanilla", typeof(bool));
            dtConfig.Columns.Add("Observaciones", typeof(string));

            foreach (DataGridViewRow row in dgvConfig.Rows)
            {
                DataRow dr = dtConfig.NewRow();
                dr["idEspecialidad"] = row.Cells[0].Value?.ToString() ?? "";
                decimal seña = ParseDecimal(row.Cells[4].Value);
                dr["Seña"] = seña;
                dr["LlevaPlanilla"] = (row.Cells[5].Value as bool?) ?? false;
                dr["Observaciones"] = row.Cells[6].Value?.ToString() ?? "";
                dtConfig.Rows.Add(dr);
            }
            precioPromo.GuardarConfigEspecialidades(dtConfig);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yaInicializado)
            {
                if (tabControl.SelectedTab == tabPrecios)
                {
                    lblTitulo.Text = "  Precios Promos";
                    btnCopiarAnio.Visible = true;
                    // Ocultar Factor
                    lblMesVariacion.Visible = false;
                    cboMesVariacion.Visible = false;
                    lblVariacion.Visible = false;
                    txtVariacion.Visible = false;
                    btnAplicar.Visible = false;
                }
                else if (tabControl.SelectedTab == tabPrecioPublico)
                {
                    lblTitulo.Text = "  Precios Públicos";
                    btnCopiarAnio.Visible = false;
                    // Mostrar Factor
                    lblMesVariacion.Visible = true;
                    cboMesVariacion.Visible = true;
                    lblVariacion.Visible = true;
                    txtVariacion.Visible = true;
                    btnAplicar.Visible = true;
                }
                else if (tabControl.SelectedTab == tabConfig)
                {
                    lblTitulo.Text = "  Configuración de Señas y Planilla";
                    // Ocultar controles
                    btnCopiarAnio.Visible = false;
                    lblMesVariacion.Visible = false;
                    cboMesVariacion.Visible = false;
                    lblVariacion.Visible = false;
                    txtVariacion.Visible = false;
                    btnAplicar.Visible = false;
                }
                else if (tabControl.SelectedTab == tabObsPre)
                {
                    lblTitulo.Text = "  Gestión de Observaciones Rápidas";
                    // Ocultar controles
                    btnCopiarAnio.Visible = false;
                    lblMesVariacion.Visible = false;
                    cboMesVariacion.Visible = false;
                    lblVariacion.Visible = false;
                    txtVariacion.Visible = false;
                    btnAplicar.Visible = false;
                }

                CargarGrilla();
            }
        }
    }
}
