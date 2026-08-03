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
        private DataGridView dgvEmpresas;
        private bool yaInicializado = false;
        private decimal[] _coefsPromo = new decimal[12];
        private decimal[] _coefsPublico = new decimal[12];
        private decimal[] _factoresPublico = new decimal[12];
        
        // Variable para almacenar la columna seleccionada en el menú contextual
        private string _columnaSeleccionada = string.Empty;
        // Lista para almacenar columnas seleccionadas para ocultar múltiples
        private List<string> _columnasSeleccionadas = new List<string>();
        // Variables para selección arrastrando cursor
        private bool _arrastrandoSeleccion = false;
        private int _columnaInicioArrastre = -1;
        private DataGridView _dgvActual = null;
        private static readonly Guid EspecialidadSinSenaFutbolMetro = new Guid("60E94892-6F59-4202-A966-884FD71A5D8B");
        private static readonly Guid EspecialidadSinSenaFutbolMetroSinLab = new Guid("C260173E-3C3C-4AB0-8FAB-822DD540A3AA");
        private static readonly Guid EspecialidadSenaManualGna3Ecografias = new Guid("185F4837-E9CF-48D9-9FDC-3D031B939B19");
        private static readonly Guid EspecialidadSenaManualGnaEcografiaAbdominal = new Guid("A022589B-1299-4E3F-BE33-492D4EFEEC5F");
        private static readonly Guid EspecialidadSenaManualPsaEcografiaAbdominal = new Guid("6E86E3F4-9B5A-4FBE-9E39-BD47055D8F56");

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
            InicializarGrillaEmpresas();

            for (int i = 0; i < 12; i++)
            {
                _coefsPromo[i] = 1;
                _coefsPublico[i] = 1;
                _factoresPublico[i] = 0;
            }

            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            this.cboMesVariacion.SelectedIndexChanged += new System.EventHandler(this.cboMesVariacion_SelectedIndexChanged);
            this.dgvObsPre.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObsPre_CellContentClick);
            
            // Asignar menú contextual y eventos de arrastre a las grillas
            dgvPrecios.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvPrecios_ColumnHeaderMouseClick);
            dgvPrecios.MouseDown += new MouseEventHandler(this.dgvPrecios_MouseDown);
            dgvPrecios.MouseMove += new MouseEventHandler(this.dgvPrecios_MouseMove);
            dgvPrecios.MouseUp += new MouseEventHandler(this.dgvPrecios_MouseUp);
            dgvPrecioPublico.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvPrecios_ColumnHeaderMouseClick);
            dgvPrecioPublico.MouseDown += new MouseEventHandler(this.dgvPrecios_MouseDown);
            dgvPrecioPublico.MouseMove += new MouseEventHandler(this.dgvPrecios_MouseMove);
            dgvPrecioPublico.MouseUp += new MouseEventHandler(this.dgvPrecios_MouseUp);
            
            ConfigurarFocoGrilla(dgvPrecios);
            ConfigurarFocoGrilla(dgvPrecioPublico);
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
            foreach (DataGridViewColumn col in dgvEmpresas.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (DataGridViewColumn col in dgvPrecioPublico.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            ConfigurarOrdenColumnas(dgvPrecios);
            ConfigurarOrdenColumnas(dgvEmpresas);
            ConfigurarOrdenColumnas(dgvPrecioPublico);

            ConfigurarGrillaConfig();
            nudAnio.Value = DateTime.Now.Year;
            cboMesVariacion.SelectedIndex = DateTime.Now.Month; // 0 = Todos, 1-12 = mes
            
            if (tabControl.SelectedTab == tabEmpresas)
                lblTitulo.Text = "  Precios Empresas";
            else if (EsPrecioPublico())
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

        private bool EsPrecioEmpresa()
        {
            return tabControl.SelectedTab == tabEmpresas;
        }

        private DataGridView ObtenerDGVActual()
        {
            if (EsPrecioPublico())
                return dgvPrecioPublico;

            if (EsPrecioEmpresa())
                return dgvEmpresas;

            return dgvPrecios;
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
            if (tabControl.SelectedTab == tabPrecioPublico || tabControl.SelectedTab == tabPrecios || tabControl.SelectedTab == tabEmpresas)
            {
                int anio = (int)nudAnio.Value;
                CargarGrillasPromoYEmpresas(anio);
                CargarGrillaPublico(anio);

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

        private void InicializarGrillaEmpresas()
        {
            dgvEmpresas = new DataGridView();
            dgvEmpresas.Name = "dgvEmpresas";
            dgvEmpresas.Dock = DockStyle.Fill;
            dgvEmpresas.AllowUserToAddRows = dgvPrecios.AllowUserToAddRows;
            dgvEmpresas.AllowUserToDeleteRows = dgvPrecios.AllowUserToDeleteRows;
            dgvEmpresas.AutoSizeColumnsMode = dgvPrecios.AutoSizeColumnsMode;
            dgvEmpresas.BackgroundColor = dgvPrecios.BackgroundColor;
            dgvEmpresas.BorderStyle = dgvPrecios.BorderStyle;
            dgvEmpresas.ColumnHeadersHeightSizeMode = dgvPrecios.ColumnHeadersHeightSizeMode;
            dgvEmpresas.EditMode = dgvPrecios.EditMode;
            dgvEmpresas.EnableHeadersVisualStyles = dgvPrecios.EnableHeadersVisualStyles;
            dgvEmpresas.RowHeadersVisible = dgvPrecios.RowHeadersVisible;
            dgvEmpresas.RowTemplate.Height = dgvPrecios.RowTemplate.Height;
            dgvEmpresas.SelectionMode = dgvPrecios.SelectionMode;
            dgvEmpresas.MultiSelect = dgvPrecios.MultiSelect;
            dgvEmpresas.ColumnHeadersDefaultCellStyle = (DataGridViewCellStyle)dgvPrecios.ColumnHeadersDefaultCellStyle.Clone();
            dgvEmpresas.DefaultCellStyle = (DataGridViewCellStyle)dgvPrecios.DefaultCellStyle.Clone();
            dgvEmpresas.AlternatingRowsDefaultCellStyle = (DataGridViewCellStyle)dgvPrecios.AlternatingRowsDefaultCellStyle.Clone();

            foreach (DataGridViewColumn col in dgvPrecios.Columns)
            {
                DataGridViewColumn colClonada = (DataGridViewColumn)col.Clone();
                colClonada.DefaultCellStyle = (DataGridViewCellStyle)col.DefaultCellStyle.Clone();
                dgvEmpresas.Columns.Add(colClonada);
            }

            dgvEmpresas.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.dgvPrecios_CellBeginEdit);
            dgvEmpresas.CellEndEdit += new DataGridViewCellEventHandler(this.dgvPrecios_CellEndEdit);
            dgvEmpresas.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvPrecios_CellFormatting);
            dgvEmpresas.CellPainting += new DataGridViewCellPaintingEventHandler(this.dgvPrecios_CellPainting);
            dgvEmpresas.ColumnHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgvPrecios_ColumnHeaderMouseDoubleClick);
            dgvEmpresas.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvPrecios_ColumnHeaderMouseClick);
            dgvEmpresas.MouseDown += new MouseEventHandler(this.dgvPrecios_MouseDown);
            dgvEmpresas.MouseMove += new MouseEventHandler(this.dgvPrecios_MouseMove);
            dgvEmpresas.MouseUp += new MouseEventHandler(this.dgvPrecios_MouseUp);
            dgvEmpresas.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvPrecios_EditingControlShowing);
            ConfigurarFocoGrilla(dgvEmpresas);

            tabEmpresas.Controls.Add(dgvEmpresas);
            dgvEmpresas.BringToFront();
        }

        private void CargarGrillasPromoYEmpresas(int anio)
        {
            _coefsPromo = ConstruirArrayCoeficientes(precioPromo.ListarCoeficientesAnio(anio));
            DataTable dtPromo = precioPromo.ListarPreciosPublicoAnio(anio);

            // BUZO y LIBRETA deben aparecer en ambas grillas
            CargarFilasEnGrilla(dgvPrecios, dtPromo, row => !EsSubtipoEmpresa(row["Tipo"]?.ToString(), row["Descripcion"]?.ToString()) || EsBuoOLibreta(row["Tipo"]?.ToString(), row["Descripcion"]?.ToString()));
            CargarFilasEnGrilla(dgvEmpresas, dtPromo, row => EsSubtipoEmpresa(row["Tipo"]?.ToString(), row["Descripcion"]?.ToString()) || EsBuoOLibreta(row["Tipo"]?.ToString(), row["Descripcion"]?.ToString()));

            ActualizarEncabezadosCoeficientes(dgvPrecios, _coefsPromo);
            ActualizarEncabezadosCoeficientes(dgvEmpresas, _coefsPromo);
        }

        private void CargarGrillaPublico(int anio)
        {
            _coefsPublico = ConstruirArrayCoeficientes(precioPublico.ListarCoeficientesAnio(anio));
            _factoresPublico = ObtenerFactoresAnio(anio);

            if (cboMesVariacion.SelectedIndex > 0)
                txtVariacion.Text = _factoresPublico[cboMesVariacion.SelectedIndex - 1].ToString("0.####", System.Globalization.CultureInfo.InvariantCulture);
            else
                txtVariacion.Text = "0";

            // BUZO y LIBRETA deben aparecer también en Precio Público
            CargarFilasEnGrilla(dgvPrecioPublico, precioPublico.ListarPreciosPublicoAnio(anio), row => !EsSubtipoEmpresa(row["Tipo"]?.ToString(), row["Descripcion"]?.ToString()) || EsBuoOLibreta(row["Tipo"]?.ToString(), row["Descripcion"]?.ToString()));
            ActualizarEncabezadosCoeficientes(dgvPrecioPublico, _coefsPublico);
        }

        private void CargarFilasEnGrilla(DataGridView dgv, DataTable dt, Func<DataRow, bool> filtro)
        {
            dgv.Rows.Clear();
            if (dt == null) return;

            int colBaseMeses = dgv.Columns.Contains("colPromo01")
                ? dgv.Columns["colPromo01"].Index
                : dgv.Columns["colPublicoPromo01"].Index;

            foreach (DataRow row in dt.Rows)
            {
                if (filtro != null && !filtro(row))
                    continue;

                int idx = dgv.Rows.Add();
                dgv.Rows[idx].Cells[ObtenerNombreColumnaIdEspecialidad(dgv)].Value = row["idEspecialidad"].ToString();
                dgv.Rows[idx].Cells[ObtenerNombreColumnaMotivo(dgv)].Value = row["Motivo"].ToString();
                dgv.Rows[idx].Cells[ObtenerNombreColumnaTipo(dgv)].Value = row["Tipo"].ToString();
                dgv.Rows[idx].Cells[ObtenerNombreColumnaDescripcion(dgv)].Value = row["Descripcion"].ToString();
                dgv.Rows[idx].Cells[ObtenerNombreColumnaIPCBase(dgv)].Value = row["IPCBase"] == DBNull.Value ? 0m : Convert.ToDecimal(row["IPCBase"]);

                for (int mes = 1; mes <= 12; mes++)
                {
                    string colPromo = "Promo" + mes.ToString("00");
                    string colCoef = "Coef" + mes.ToString("00");
                    dgv.Rows[idx].Cells[colBaseMeses + (mes - 1) * 2].Value = row[colPromo] == DBNull.Value ? 0m : Convert.ToDecimal(row[colPromo]);
                    dgv.Rows[idx].Cells[colBaseMeses + 1 + (mes - 1) * 2].Value = row[colCoef] == DBNull.Value ? 0m : Convert.ToDecimal(row[colCoef]);
                }
            }
        }

        private decimal[] ConstruirArrayCoeficientes(DataTable dtCoef)
        {
            decimal[] coeficientes = new decimal[12];
            for (int i = 0; i < 12; i++) coeficientes[i] = 1;

            if (dtCoef == null) return coeficientes;

            foreach (DataRow row in dtCoef.Rows)
            {
                int mes = Convert.ToInt32(row["Mes"]);
                if (mes >= 1 && mes <= 12)
                    coeficientes[mes - 1] = Convert.ToDecimal(row["Coeficiente"]);
            }

            return coeficientes;
        }

        private void ActualizarEncabezadosCoeficientes(DataGridView dgv, decimal[] coeficientes)
        {
            int colBaseMeses = dgv.Columns.Contains("colPromo01")
                ? dgv.Columns["colPromo01"].Index
                : dgv.Columns["colPublicoPromo01"].Index;

            for (int mes = 1; mes <= 12; mes++)
            {
                dgv.Columns[colBaseMeses + 1 + (mes - 1) * 2].HeaderText =
                    coeficientes[mes - 1].ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);
            }

            dgv.Columns[ObtenerNombreColumnaIPCBase(dgv)].HeaderText =
                coeficientes[0].ToString("0.##", System.Globalization.CultureInfo.CurrentCulture);
        }

        private bool EsSubtipoEmpresa(string tipo, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                string descripcionSinTipo = string.IsNullOrWhiteSpace(descripcion)
                    ? string.Empty
                    : descripcion.Trim().ToUpperInvariant();

                return descripcionSinTipo.Contains("PREOCUPACIONAL")
                    || descripcionSinTipo.Contains("PERIODICO");
            }

            string tipoNormalizado = tipo.Trim().ToUpperInvariant();
            string descripcionNormalizada = string.IsNullOrWhiteSpace(descripcion)
                ? string.Empty
                : descripcion.Trim().ToUpperInvariant();

            if (tipoNormalizado.Contains("LICENCIAS PNA"))
            {
                return descripcionNormalizada.StartsWith("BUZO")
                    || descripcionNormalizada.StartsWith("LIBRETA");
            }

            return tipoNormalizado.Contains("PRE-OCUPACIONAL")
                || tipoNormalizado.Contains("PREOCUPACIONAL")
                || tipoNormalizado.Contains("PERIODICO")
                || descripcionNormalizada.Contains("PERIODICO")
                || descripcionNormalizada.Contains("PREOCUPACIONAL")
                || tipoNormalizado.Contains("EGRESO");
        }

        private bool EsBuoOLibreta(string tipo, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                string descripcionSinTipo = string.IsNullOrWhiteSpace(descripcion)
                    ? string.Empty
                    : descripcion.Trim().ToUpperInvariant();

                return descripcionSinTipo.StartsWith("BUZO") || descripcionSinTipo.StartsWith("LIBRETA");
            }

            string descripcionNormalizada = string.IsNullOrWhiteSpace(descripcion)
                ? string.Empty
                : descripcion.Trim().ToUpperInvariant();

            return descripcionNormalizada.StartsWith("BUZO") || descripcionNormalizada.StartsWith("LIBRETA");
        }

        private DataGridViewRow BuscarFilaPromoPorId(string idEspecialidad)
        {
            if (string.IsNullOrWhiteSpace(idEspecialidad))
                return null;

            foreach (DataGridView dgv in new[] { dgvPrecios, dgvEmpresas })
            {
                if (dgv == null) continue;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells[ObtenerNombreColumnaIdEspecialidad(dgv)].Value?.ToString() == idEspecialidad)
                        return row;
                }
            }

            return null;
        }

        private void CargarGrillaObsPre()
        {
            try
            {
                dgvObsPre.Rows.Clear();
                DataTable dt = SQLConnector.obtenerTablaSegunConsultaString("SELECT id, texto, ISNULL(AcumulaPrecioAuto, 0) AS AcumulaPrecioAuto, activo FROM ObservacionPredefinida ORDER BY texto");

                Image imgEliminar = IconChar.TrashAlt.ToBitmap(Color.IndianRed, 16);

                foreach (DataRow dr in dt.Rows)
                {
                    dgvObsPre.Rows.Add(dr["id"], dr["texto"], Convert.ToBoolean(dr["AcumulaPrecioAuto"]), dr["activo"], imgEliminar);
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

                int anio = (int)nudAnio.Value;
                GuardarCoeficientesActual(anio, _coefs);

                if (EsPrecioPublico())
                    ActualizarEncabezadosCoeficientes(dgvPrecioPublico, _coefsPublico);
                else
                {
                    ActualizarEncabezadosCoeficientes(dgvPrecios, _coefsPromo);
                    ActualizarEncabezadosCoeficientes(dgvEmpresas, _coefsPromo);
                }

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

                        // ✅ NUEVA LÓGICA: Detectar si hay un precio forzado activo y propagarlo
                        decimal precioForzadoActivo = 0m;

                        for (int mes = mesInicio; mes <= 12; mes++)
                        {
                            // AQUI ESTABA EL PROBLEMA: Si originalValues[mes - 1] == 0, se cortaba la cascada
                            // if (mes > mesInicio && originalValues[mes - 1] == 0m) continue;

                            decimal valorMesAnterior = ParseDecimal(row.Cells[5 + (mes - 2) * 2].Value);
                            decimal aumentoFijoFila = ParseDecimal(row.Cells[6 + (mes - 2) * 2].Value); // El valor "del medio" en pesos
                            decimal coefGlobal = _coefsPromo[mes - 2]; // El rojo de arriba del mes anterior
                            
                            // ✅ LÓGICA DE PRECIO FORZADO: Si hay un precio forzado activo, se propaga a todos los meses siguientes
                            decimal nuevoValor;
                            if (precioForzadoActivo > 0)
                            {
                                // Mantener el precio forzado para todos los meses siguientes
                                nuevoValor = precioForzadoActivo;
                            }
                            else if (aumentoFijoFila > 0)
                            {
                                // Nuevo precio forzado detectado, activarlo y propagarlo
                                nuevoValor = aumentoFijoFila;
                                precioForzadoActivo = aumentoFijoFila;
                            }
                            else
                            {
                                // Sin precio forzado, aplicar cálculo estándar
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
            DataGridView dgvPublico = dgvPrecioPublico;

            foreach (DataGridViewRow rowPublico in dgvPublico.Rows)
            {
                // Solo ignoramos las filas nuevas de edición
                if (rowPublico.IsNewRow) continue;

                string idEsp = rowPublico.Cells[ObtenerNombreColumnaIdEspecialidad(dgvPublico)].Value?.ToString();
                
                // Buscar la fila correspondiente en la grilla Promo por ID
                DataGridViewRow rowPromo = BuscarFilaPromoPorId(idEsp);
                
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
                        // Si no hay fuerza de precio previa, seguimos la relación normal
                        // AQUI ESTA LA CLAVE: En lugar de usar SIEMPRE valorPromo * CoeficienteRojoPublico,
                        // debemos propagar el valor publico anterior si ya se aplico un factor
                        decimal valorAnteriorPublico = 0;
                        if (mes > 1)
                        {
                            valorAnteriorPublico = ParseDecimal(rowPublico.Cells[5 + (mes - 2) * 2].Value);
                        }

                        decimal factorDelMes = _factoresPublico[mes - 1];
                        
                        // Calculamos el valor propagado desde el mes anterior en Público
                        decimal valorPropagado = 0;
                        if (valorAnteriorPublico > 0)
                        {
                            decimal factorRelacion = 1;
                            if (mes > 1) factorRelacion = _coefsPublico[mes - 2]; 
                            
                            // El valor anterior ya tiene el factor aplicado, así que SOLO aplicamos el coeficiente rojo
                            valorPropagado = valorAnteriorPublico * factorRelacion;
                        }

                        // Calculamos el valor basado en Promo
                        decimal valorPromo = ParseDecimal(rowPromo.Cells[5 + (mes - 1) * 2].Value);
                        decimal valorDesdePromo = 0;
                        if (valorPromo > 0)
                        {
                            decimal factorRelacion = 1;
                            if (mes > 1) factorRelacion = _coefsPublico[mes - 2]; 
                            
                            valorDesdePromo = valorPromo * factorRelacion;
                            // Al valor de Promo SÍ le aplicamos el factor de conversión
                            if (factorDelMes > 0) valorDesdePromo *= factorDelMes;
                        }

                        // Tomamos el mayor valor (para que el factor se propague, pero nunca sea menor que Promo)
                        decimal precioPublicoCalculado = Math.Max(valorPropagado, valorDesdePromo);

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
                    filaPromo = BuscarFilaPromoPorId(idEsp);

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
                                // AQUI ESTA LA CLAVE PARA LA FILA:
                                // Debemos propagar el valor publico anterior si ya existe,
                                // en lugar de volver a traer el valor de Promo
                                decimal valorAnteriorPublico = 0;
                                if (mes > 1)
                                {
                                    valorAnteriorPublico = ParseDecimal(filaPublico.Cells[5 + (mes - 2) * 2].Value);
                                }

                                decimal factorDelMes = _factoresPublico[mes - 1];
                                
                                decimal valorPropagado = 0;
                                if (valorAnteriorPublico > 0)
                                {
                                    decimal factorRelacion = 1;
                                    if (mes > 1) factorRelacion = _coefsPublico[mes - 2];

                                    // El valor anterior ya tiene el factor aplicado, así que SOLO aplicamos el coeficiente rojo
                                    valorPropagado = valorAnteriorPublico * factorRelacion;
                                }

                                decimal valorPromo = ParseDecimal(filaPromo.Cells[5 + (mes - 1) * 2].Value);
                                decimal valorDesdePromo = 0;
                                if (valorPromo > 0)
                                {
                                    decimal factorRelacion = 1;
                                    if (mes > 1) factorRelacion = _coefsPublico[mes - 2];
                                    
                                    valorDesdePromo = valorPromo * factorRelacion;
                                    // Al valor de Promo SÍ le aplicamos el factor de conversión
                                    if (factorDelMes > 0) valorDesdePromo *= factorDelMes;
                                }

                                decimal precioPublicoCalculado = Math.Max(valorPropagado, valorDesdePromo);

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

                    // ✅ NUEVA LÓGICA: Detectar si hay un precio forzado activo y propagarlo
                    decimal precioForzadoActivo = 0m;
                    
                    for (int mes = mesInicio; mes <= 12; mes++)
                    {
                        if (!filaActual.Visible) continue;

                        if (cascadeSoloConValores)
                        {
                            if (originalValues[mes] == 0m) continue;
                        }
                        else
                        {
                            // AQUI ESTABA EL PROBLEMA: Si originalValues[mes - 1] == 0, se cortaba la cascada,
                            // por lo que si ponías un valor nuevo en un mes y el siguiente estaba en 0, no se copiaba.
                            // Eliminamos esta restricción para que los valores se propaguen hacia adelante.
                            // if (mes > mesInicio && originalValues[mes - 1] == 0m) continue;
                        }

                        decimal valorBase = ParseDecimal(filaActual.Cells[5 + (mes - 2) * 2].Value);
                        decimal aumentoFijoFila = ParseDecimal(filaActual.Cells[6 + (mes - 2) * 2].Value);
                        decimal coefGlobal = _coefsPromo[mes - 2];
                        
                        // ✅ LÓGICA DE PRECIO FORZADO: Si hay un precio forzado activo, se propaga a todos los meses siguientes
                        decimal nuevoValor;
                        if (precioForzadoActivo > 0)
                        {
                            // Mantener el precio forzado para todos los meses siguientes
                            nuevoValor = precioForzadoActivo;
                        }
                        else if (aumentoFijoFila > 0)
                        {
                            // Nuevo precio forzado detectado, activarlo y propagarlo
                            nuevoValor = aumentoFijoFila;
                            precioForzadoActivo = aumentoFijoFila;
                        }
                        else
                        {
                            // Sin precio forzado, aplicar cálculo estándar
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
            if (tabControl.SelectedTab == tabPrecioPublico || tabControl.SelectedTab == tabPrecios || tabControl.SelectedTab == tabEmpresas)
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
                    bool acumulaVal = row.Cells["colObsAcumula"].Value != null && Convert.ToBoolean(row.Cells["colObsAcumula"].Value);
                    bool activoVal = row.Cells["colObsActivo"].Value != null && Convert.ToBoolean(row.Cells["colObsActivo"].Value);
                    string acumula = acumulaVal ? "1" : "0";
                    string activo = activoVal ? "1" : "0";

                    if (string.IsNullOrWhiteSpace(texto)) continue;

                    if (string.IsNullOrEmpty(id))
                    {
                        sb.AppendLine($"INSERT INTO ObservacionPredefinida (texto, AcumulaPrecioAuto, activo) VALUES ('{texto}', {acumula}, {activo});");
                    }
                    else
                    {
                        sb.AppendLine($"UPDATE ObservacionPredefinida SET texto = '{texto}', AcumulaPrecioAuto = {acumula}, activo = {activo} WHERE id = {id};");
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
                $"¿Está seguro que desea aplicar un factor de {factor} a {alcanceMes} en Precio Público?\nEsto actualizará TODAS las prestaciones de ese mes.",
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
                
                // Forzar recálculo visualmente en la grilla para TODAS las filas
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

        private void ConfigurarFocoGrilla(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.MultiSelect = false;
            dgv.CurrentCellChanged += dgvPrecios_CurrentCellChanged;
            dgv.CellClick += dgvPrecios_CellClick;
        }

        private void dgvPrecios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                ((DataGridView)sender).Invalidate();
        }

        private void dgvPrecios_CurrentCellChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).Invalidate();
        }

        private void dgvPrecios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                string colName = dgv.Columns[e.ColumnIndex].Name;
                Color backColor = (colName.Contains("Coef") || colName.Contains("IPCBase")) ? Color.FromArgb(180, 0, 0) : Color.SeaGreen;
                
                // Si la columna está seleccionada, cambiar el color de fondo
                if (_columnasSeleccionadas.Contains(colName))
                {
                    backColor = Color.FromArgb(100, 100, 200); // Azul claro para columnas seleccionadas
                }

                using (var brush = new SolidBrush(backColor))
                    e.Graphics.FillRectangle(brush, e.CellBounds);

                string text = dgv.Columns[e.ColumnIndex].HeaderText;
                var font = e.CellStyle.Font ?? dgv.ColumnHeadersDefaultCellStyle.Font;
                TextRenderer.DrawText(e.Graphics, text, font, e.CellBounds, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordEllipsis);

                using (var pen = new Pen(Color.FromArgb(100, 100, 100)))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                e.Handled = true;
                return;
            }

            if (e.RowIndex >= 0
                && e.ColumnIndex >= 0
                && dgv.CurrentCell != null
                && dgv.CurrentCell.RowIndex == e.RowIndex
                && dgv.CurrentCell.ColumnIndex == e.ColumnIndex)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                using (var pen = new Pen(Color.FromArgb(0, 120, 215), 2))
                {
                    e.Graphics.DrawRectangle(pen, e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 3, e.CellBounds.Height - 3);
                }

                e.Handled = true;
            }
        }

        private void dgvPrecios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridView dgv = (DataGridView)sender;
            string col = dgv.Columns[e.ColumnIndex].Name;
            bool filaActiva = dgv.CurrentCell != null && dgv.CurrentCell.RowIndex == e.RowIndex;

            if (col.Contains("Motivo") || (col.StartsWith("col") && col.Contains("Motivo")))
            {
                e.CellStyle.BackColor = filaActiva ? Color.FromArgb(180, 200, 220) : Color.FromArgb(230, 245, 235);
                e.CellStyle.ForeColor = Color.FromArgb(20, 70, 40);
            }
            else if (col.Contains("Tipo") || (col.StartsWith("col") && col.Contains("Tipo")))
            {
                e.CellStyle.BackColor = filaActiva ? Color.FromArgb(180, 200, 220) : Color.White;
                e.CellStyle.ForeColor = Color.FromArgb(30, 30, 90);
            }
            else if (col.Contains("Descripcion") || (col.StartsWith("col") && col.Contains("Descripcion")))
            {
                e.CellStyle.BackColor = filaActiva ? Color.FromArgb(180, 200, 220) : Color.White;
                e.CellStyle.ForeColor = Color.FromArgb(20, 20, 20);
            }
            else if (col.Contains("Promo") || (col.StartsWith("col") && col.Contains("Promo")))
            {
                e.CellStyle.BackColor = filaActiva ? Color.FromArgb(180, 200, 220) : Color.White;
                e.CellStyle.ForeColor = Color.FromArgb(20, 20, 20);
            }
            else if (col == "colIPCBase" || col == "colPublicoIPCBase")
            {
                e.CellStyle.BackColor = filaActiva ? Color.FromArgb(210, 228, 244) : Color.FromArgb(240, 240, 240);
                e.CellStyle.ForeColor = Color.FromArgb(0, 100, 200);
            }
            else if (col.Contains("Coef"))
            {
                e.CellStyle.BackColor = filaActiva ? Color.FromArgb(255, 225, 225) : Color.FromArgb(255, 210, 210);
                e.CellStyle.ForeColor = Color.FromArgb(140, 0, 0);
            }

            // Color de selección más oscuro para mejor visibilidad pero manteniendo aspecto limpio
            Color backColor = e.CellStyle.BackColor;
            Color selectionBackColor = Color.FromArgb(
                Math.Max(0, backColor.R - 40),
                Math.Max(0, backColor.G - 40),
                Math.Max(0, backColor.B - 40)
            );
            e.CellStyle.SelectionBackColor = selectionBackColor;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
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
            if (dgv.Columns.Contains("colIdEspecialidad")) return "colIdEspecialidad";
            if (dgv.Columns.Contains("colPublicoIdEspecialidad")) return "colPublicoIdEspecialidad";
            return "colIdEspecialidad";
        }

        private string ObtenerNombreColumnaIPCBase(DataGridView dgv)
        {
            if (dgv.Columns.Contains("colIPCBase")) return "colIPCBase";
            if (dgv.Columns.Contains("colPublicoIPCBase")) return "colPublicoIPCBase";
            return "colIPCBase";
        }

        private string ObtenerNombreColumnaMotivo(DataGridView dgv)
        {
            if (dgv.Columns.Contains("colMotivo")) return "colMotivo";
            if (dgv.Columns.Contains("colPublicoMotivo")) return "colPublicoMotivo";
            return "colMotivo";
        }

        private string ObtenerNombreColumnaTipo(DataGridView dgv)
        {
            if (dgv.Columns.Contains("colTipo")) return "colTipo";
            if (dgv.Columns.Contains("colPublicoTipo")) return "colPublicoTipo";
            return "colTipo";
        }

        private string ObtenerNombreColumnaDescripcion(DataGridView dgv)
        {
            if (dgv.Columns.Contains("colDescripcion")) return "colDescripcion";
            if (dgv.Columns.Contains("colPublicoDescripcion")) return "colPublicoDescripcion";
            return "colDescripcion";
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
            dgvConfig.Columns[4].HeaderText = "Seña";
            dgvConfig.Columns[4].ReadOnly = false;
            dgvConfig.Columns[4].DefaultCellStyle.BackColor = Color.White;
            dgvConfig.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void CargarGrillaConfig()
        {
            dgvConfig.Rows.Clear();
            DataTable dt = precioPromo.ListarConfigEspecialidades();
            if (dt == null) return;
            Dictionary<string, decimal> preciosPromoMesActual = ObtenerPreciosPromoMesActualParaConfig((int)nudAnio.Value);
            foreach (DataRow row in dt.Rows)
            {
                int idx = dgvConfig.Rows.Add();
                string idEspecialidad = row["idEspecialidad"].ToString();
                Guid guidEspecialidad;
                Guid.TryParse(idEspecialidad, out guidEspecialidad);
                decimal precioPromoMesActual = 0m;
                preciosPromoMesActual.TryGetValue(idEspecialidad, out precioPromoMesActual);
                decimal senaCalculada = CalcularSenaAutomaticaConfig(guidEspecialidad, precioPromoMesActual);
                decimal senaConfigurada = row["Seña"] == DBNull.Value ? 0m : Convert.ToDecimal(row["Seña"]);
                bool esManual = EsEspecialidadSenaManualConfig(guidEspecialidad);

                dgvConfig.Rows[idx].Cells[0].Value = row["idEspecialidad"].ToString();
                dgvConfig.Rows[idx].Cells[1].Value = row["Motivo"].ToString();
                dgvConfig.Rows[idx].Cells[2].Value = row["Tipo"].ToString();
                dgvConfig.Rows[idx].Cells[3].Value = row["Descripcion"].ToString();
                dgvConfig.Rows[idx].Cells[4].Value = esManual ? senaConfigurada : senaCalculada;
                dgvConfig.Rows[idx].Cells[4].Tag = senaConfigurada;
                dgvConfig.Rows[idx].Cells[4].ReadOnly = !esManual;
                dgvConfig.Rows[idx].Cells[4].Style.BackColor = esManual ? Color.White : Color.WhiteSmoke;
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
                string idEspecialidad = row.Cells[0].Value?.ToString() ?? "";
                dr["idEspecialidad"] = idEspecialidad;
                Guid guidEspecialidad;
                Guid.TryParse(idEspecialidad, out guidEspecialidad);
                decimal seña = EsEspecialidadSenaManualConfig(guidEspecialidad)
                    ? ParseDecimal(row.Cells[4].Value)
                    : (row.Cells[4].Tag == null ? 0m : ParseDecimal(row.Cells[4].Tag));
                dr["Seña"] = seña;
                dr["LlevaPlanilla"] = (row.Cells[5].Value as bool?) ?? false;
                string observaciones = row.Cells[6].Value?.ToString() ?? "";
                dr["Observaciones"] = observaciones;

                System.Diagnostics.Debug.WriteLine($"[FRM_PRECIO_PROMO] GuardarConfig - Id={idEspecialidad}, Observaciones='{observaciones}', LlevaPlanilla={dr["LlevaPlanilla"]}, Seña={seña}");

                dtConfig.Rows.Add(dr);
            }
            precioPromo.GuardarConfigEspecialidades(dtConfig);
        }

        private Dictionary<string, decimal> ObtenerPreciosPromoMesActualParaConfig(int anio)
        {
            var resultado = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
            DataTable dtPrecios = precioPromo.ListarPreciosPublicoAnio(anio);
            if (dtPrecios == null || dtPrecios.Rows.Count == 0)
                return resultado;

            string nombreColumna = "Promo" + DateTime.Now.Month.ToString("00");
            if (!dtPrecios.Columns.Contains("idEspecialidad") || !dtPrecios.Columns.Contains(nombreColumna))
                return resultado;

            foreach (DataRow row in dtPrecios.Rows)
            {
                string idEspecialidad = row["idEspecialidad"].ToString();
                decimal precioPromo = row[nombreColumna] == DBNull.Value ? 0m : Convert.ToDecimal(row[nombreColumna]);
                resultado[idEspecialidad] = precioPromo;
            }

            return resultado;
        }

        private decimal CalcularSenaAutomaticaConfig(Guid idEspecialidad, decimal precioPromo)
        {
            if (precioPromo <= 0)
                return 0m;

            if (EsEspecialidadSinSenaConfig(idEspecialidad))
                return 0m;

            if (EsEspecialidadSenaManualConfig(idEspecialidad))
                return 0m;

            decimal residuo = precioPromo % 10000m;
            if (residuo == 5000m)
                return 5000m;

            if (residuo < 5000m)
                return residuo + 5000m;

            return residuo;
        }

        private bool EsEspecialidadSinSenaConfig(Guid idEspecialidad)
        {
            return idEspecialidad == EspecialidadSinSenaFutbolMetro
                || idEspecialidad == EspecialidadSinSenaFutbolMetroSinLab;
        }

        private bool EsEspecialidadSenaManualConfig(Guid idEspecialidad)
        {
            return idEspecialidad == EspecialidadSenaManualGna3Ecografias
                || idEspecialidad == EspecialidadSenaManualGnaEcografiaAbdominal
                || idEspecialidad == EspecialidadSenaManualPsaEcografiaAbdominal;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yaInicializado)
            {
                if (tabControl.SelectedTab == tabEmpresas)
                {
                    lblTitulo.Text = "  Precios Empresas";
                    btnCopiarAnio.Visible = false;
                    lblMesVariacion.Visible = false;
                    cboMesVariacion.Visible = false;
                    lblVariacion.Visible = false;
                    txtVariacion.Visible = false;
                    btnAplicar.Visible = false;
                }
                else if (tabControl.SelectedTab == tabPrecios)
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
                    lblTitulo.Text = "  Configuración de Seña Automática y Planilla";
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

        #region Menú Contextual de Columnas

        private void dgvPrecios_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            _dgvActual = dgv;
            
            // Obtener información de la celda bajo el cursor
            DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
            
            if (hitInfo.Type == DataGridViewHitTestType.ColumnHeader && hitInfo.ColumnIndex >= 0)
            {
                // Solo iniciar arrastre si es clic izquierdo
                if (e.Button == MouseButtons.Left)
                {
                    _arrastrandoSeleccion = true;
                    _columnaInicioArrastre = hitInfo.ColumnIndex;
                    _columnasSeleccionadas.Clear();
                    _columnasSeleccionadas.Add(dgv.Columns[hitInfo.ColumnIndex].Name);
                    dgv.Invalidate();
                }
                // Si es clic derecho, mantener la selección actual
            }
        }

        private void dgvPrecios_MouseMove(object sender, MouseEventArgs e)
        {
            if (_arrastrandoSeleccion && _dgvActual != null)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridView.HitTestInfo hitInfo = dgv.HitTest(e.X, e.Y);
                
                if (hitInfo.Type == DataGridViewHitTestType.ColumnHeader && hitInfo.ColumnIndex >= 0)
                {
                    // Calcular rango desde inicio hasta posición actual
                    int inicio = Math.Min(_columnaInicioArrastre, hitInfo.ColumnIndex);
                    int fin = Math.Max(_columnaInicioArrastre, hitInfo.ColumnIndex);
                    
                    _columnasSeleccionadas.Clear();
                    for (int i = inicio; i <= fin; i++)
                    {
                        string nombreColumna = dgv.Columns[i].Name;
                        if (!_columnasSeleccionadas.Contains(nombreColumna))
                            _columnasSeleccionadas.Add(nombreColumna);
                    }
                    
                    // Redibujar para mostrar selección visual
                    dgv.Invalidate();
                }
            }
        }

        private void dgvPrecios_MouseUp(object sender, MouseEventArgs e)
        {
            // Solo limpiar si no es clic derecho (para mantener la selección para el menú contextual)
            if (_arrastrandoSeleccion && e.Button != MouseButtons.Right)
            {
                _arrastrandoSeleccion = false;
                _columnaInicioArrastre = -1;
            }
        }

        private void dgvPrecios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                _columnaSeleccionada = dgv.Columns[e.ColumnIndex].Name;
                
                // Si no hay columnas seleccionadas, seleccionar la actual
                if (_columnasSeleccionadas.Count == 0)
                {
                    _columnasSeleccionadas.Add(_columnaSeleccionada);
                }
                
                // Habilitar/deshabilitar opción de ocultar seleccionadas según cantidad
                mnuOcultarSeleccionadas.Enabled = _columnasSeleccionadas.Count > 0;
                if (_columnasSeleccionadas.Count > 1)
                    mnuOcultarSeleccionadas.Text = "Ocultar " + _columnasSeleccionadas.Count + " columnas seleccionadas";
                else
                    mnuOcultarSeleccionadas.Text = "Ocultar columnas seleccionadas";
                
                // Mostrar menú contextual
                mnuColumnas.Show(Cursor.Position);
            }
        }

        private void mnuOcultarColumna_Click(object sender, EventArgs e)
        {
            DataGridView dgvActual = ObtenerDGVActual();
            if (dgvActual == null || string.IsNullOrEmpty(_columnaSeleccionada)) return;
            
            if (dgvActual.Columns.Contains(_columnaSeleccionada))
            {
                dgvActual.Columns[_columnaSeleccionada].Visible = false;
            }
            
            // Sincronizar con otras grillas
            SincronizarVisibilidadColumna(_columnaSeleccionada, false);
        }

        private void mnuOcultarSeleccionadas_Click(object sender, EventArgs e)
        {
            DataGridView dgvActual = ObtenerDGVActual();
            if (dgvActual == null || _columnasSeleccionadas.Count == 0) return;
            
            // Ocultar todas las columnas seleccionadas
            foreach (string columna in _columnasSeleccionadas)
            {
                if (dgvActual.Columns.Contains(columna))
                {
                    dgvActual.Columns[columna].Visible = false;
                }
                
                // Sincronizar con otras grillas
                SincronizarVisibilidadColumna(columna, false);
            }
            
            // Limpiar selección después de ocultar
            _columnasSeleccionadas.Clear();
        }

        private void mnuMostrarTodas_Click(object sender, EventArgs e)
        {
            DataGridView dgvActual = ObtenerDGVActual();
            if (dgvActual == null) return;
            
            // Mostrar todas las columnas de meses
            foreach (DataGridViewColumn col in dgvActual.Columns)
            {
                if (col.Name.Contains("Promo") || col.Name.Contains("Coef") || 
                    col.Name.Contains("PublicoPromo") || col.Name.Contains("PublicoCoef"))
                {
                    col.Visible = true;
                }
            }
            
            // Sincronizar con otras grillas
            SincronizarVisibilidadTodasColumnas(true);
        }

        private void mnuMostrarSoloEste_Click(object sender, EventArgs e)
        {
            DataGridView dgvActual = ObtenerDGVActual();
            if (dgvActual == null || string.IsNullOrEmpty(_columnaSeleccionada)) return;
            
            // Primero ocultar todas las columnas de meses
            foreach (DataGridViewColumn col in dgvActual.Columns)
            {
                if (col.Name.Contains("Promo") || col.Name.Contains("Coef") || 
                    col.Name.Contains("PublicoPromo") || col.Name.Contains("PublicoCoef"))
                {
                    col.Visible = false;
                }
            }
            
            // Mostrar solo el mes seleccionado
            string mes = ObtenerMesDeColumna(_columnaSeleccionada);
            string colPromo = "colPromo" + mes;
            string colCoef = "colCoef" + mes;
            string colPublicoPromo = "colPublicoPromo" + mes;
            string colPublicoCoef = "colPublicoCoef" + mes;
            
            if (dgvActual.Columns.Contains(colPromo))
                dgvActual.Columns[colPromo].Visible = true;
            if (dgvActual.Columns.Contains(colCoef))
                dgvActual.Columns[colCoef].Visible = true;
            if (dgvActual.Columns.Contains(colPublicoPromo))
                dgvActual.Columns[colPublicoPromo].Visible = true;
            if (dgvActual.Columns.Contains(colPublicoCoef))
                dgvActual.Columns[colPublicoCoef].Visible = true;
            
            // Sincronizar con otras grillas
            SincronizarVisibilidadSoloMes(mes);
        }

        private string ObtenerMesDeColumna(string nombreColumna)
        {
            for (int i = 1; i <= 12; i++)
            {
                string mes = i.ToString("00");
                if (nombreColumna.Contains(mes))
                    return mes;
            }
            return "";
        }

        private void SincronizarVisibilidadColumna(string nombreColumna, bool visible)
        {
            // Sincronizar con grilla de empresas
            if (dgvEmpresas != null && dgvEmpresas.Columns.Contains(nombreColumna))
                dgvEmpresas.Columns[nombreColumna].Visible = visible;
            
            // Sincronizar con grilla público
            string nombreColumnaPublico = nombreColumna.Replace("colPromo", "colPublicoPromo").Replace("colCoef", "colPublicoCoef");
            if (dgvPrecioPublico != null && dgvPrecioPublico.Columns.Contains(nombreColumnaPublico))
                dgvPrecioPublico.Columns[nombreColumnaPublico].Visible = visible;
        }

        private void SincronizarVisibilidadTodasColumnas(bool visible)
        {
            // Sincronizar con grilla de empresas
            if (dgvEmpresas != null)
            {
                foreach (DataGridViewColumn col in dgvEmpresas.Columns)
                {
                    if (col.Name.Contains("Promo") || col.Name.Contains("Coef"))
                        col.Visible = visible;
                }
            }
            
            // Sincronizar con grilla público
            if (dgvPrecioPublico != null)
            {
                foreach (DataGridViewColumn col in dgvPrecioPublico.Columns)
                {
                    if (col.Name.Contains("PublicoPromo") || col.Name.Contains("PublicoCoef"))
                        col.Visible = visible;
                }
            }
        }

        private void SincronizarVisibilidadSoloMes(string mes)
        {
            // Primero ocultar todas las columnas de meses en las otras grillas
            if (dgvEmpresas != null)
            {
                foreach (DataGridViewColumn col in dgvEmpresas.Columns)
                {
                    if (col.Name.Contains("Promo") || col.Name.Contains("Coef"))
                        col.Visible = false;
                }
                // Mostrar solo el mes seleccionado
                string colPromo = "colPromo" + mes;
                string colCoef = "colCoef" + mes;
                if (dgvEmpresas.Columns.Contains(colPromo))
                    dgvEmpresas.Columns[colPromo].Visible = true;
                if (dgvEmpresas.Columns.Contains(colCoef))
                    dgvEmpresas.Columns[colCoef].Visible = true;
            }
            
            if (dgvPrecioPublico != null)
            {
                foreach (DataGridViewColumn col in dgvPrecioPublico.Columns)
                {
                    if (col.Name.Contains("PublicoPromo") || col.Name.Contains("PublicoCoef"))
                        col.Visible = false;
                }
                // Mostrar solo el mes seleccionado
                string colPublicoPromo = "colPublicoPromo" + mes;
                string colPublicoCoef = "colPublicoCoef" + mes;
                if (dgvPrecioPublico.Columns.Contains(colPublicoPromo))
                    dgvPrecioPublico.Columns[colPublicoPromo].Visible = true;
                if (dgvPrecioPublico.Columns.Contains(colPublicoCoef))
                    dgvPrecioPublico.Columns[colPublicoCoef].Visible = true;
            }
        }

        #endregion
    }
}
