
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class ItemsPorSecciones : UserControl
    {
        private CapaNegocioMepryl.TipoExamen tipoExamenNegocio;

        public DataGridView DgvClinico => dgvClinico;
        public DataGridView DgvHematologia => dgvHematologia;
        public DataGridView DgvQuimicaHematica => dgvQuimicaHematica;
        public DataGridView DgvSerologia => dgvSerologia;
        public DataGridView DgvPerfilLipidico => dgvPerfilLipidico;
        public DataGridView DgvBacteriologia => dgvBacteriologia;
        public DataGridView DgvOrina => dgvOrina;
        public DataGridView DgvLaboralesBasicas => dgvLaboralesBasicas;
        public DataGridView DgvCraneoYMSuperior => dgvCraneoYMSuperior;
        public DataGridView DgvTroncoYPelvis => dgvTroncoYPelvis;
        public DataGridView DgvMiembroInferior => dgvMiembroInferior;
        public DataGridView DgvEstComplementarios => dgvEstComplementarios;

        public ItemsPorSecciones()
        {
            InitializeComponent();
            InicializarRayosXLayout();
            InicializarLaboratorioLayout();
            InicializarClinicoLayout();
            InicializarEstComplementariosLayout();
            /// <summary>
            /// Ajusta el layout de la sección Ex. Clínico para que el DataGridView ocupe todo el espacio horizontal sin AutoScroll
            /// </summary>

        }
        /// <summary>
        /// Ajusta el layout de la sección Estudios Complementarios para que el DataGridView ocupe todo el espacio horizontal sin AutoScroll
        /// </summary>
        private void InicializarEstComplementariosLayout()
        {
            // Busca el TabPage correspondiente a Estudios Complementarios (ajusta el nombre si es diferente)
            var tabEstCompl = this.Controls.OfType<TabControl>()
                .SelectMany(tc => tc.TabPages.Cast<TabPage>())
                .FirstOrDefault(tp => tp.Text.Contains("Estudios Complementarios") || tp.Name.Contains("EstComplementarios"));

            if (tabEstCompl == null)
                return;

            // Crear TableLayoutPanel con 1 columna y 2 filas (etiqueta arriba, grid abajo)
            var tableEstCompl = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = false,
                AutoScroll = false // Desactivado para evitar scroll molesto
            };
            tableEstCompl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableEstCompl.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F)); // Etiqueta
            tableEstCompl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Grid

            // Agregar el Label arriba (debe existir en el Designer)
            tableEstCompl.Controls.Add(label43, 0, 0); // Estudios Complementarios

            // Configurar el DataGridView para que ocupe todo el espacio
            dgvEstComplementarios.Dock = DockStyle.Fill;

            // Agregar el DataGridView abajo
            tableEstCompl.Controls.Add(dgvEstComplementarios, 0, 1);

            // Limpiar el TabPage y agregar el TableLayoutPanel
            tabEstCompl.Controls.Clear();
            tabEstCompl.Controls.Add(tableEstCompl);
        }

        private void InicializarClinicoLayout()
        {
            // Busca el TabPage correspondiente a Ex. Clínico (ajusta el nombre si es diferente)
            var tabClinico = this.Controls.OfType<TabControl>()
                .SelectMany(tc => tc.TabPages.Cast<TabPage>())
                .FirstOrDefault(tp => tp.Text.Contains("Clínico") || tp.Name.Contains("Clinico"));

            if (tabClinico == null)
                return;

            // Crear TableLayoutPanel con 1 columna y 2 filas (etiqueta arriba, grid abajo)
            var tableClinico = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = false,
                AutoScroll = false // Desactivado para evitar scroll molesto
            };
            tableClinico.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableClinico.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F)); // Etiqueta
            tableClinico.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Grid

            // Agregar el Label arriba (debe existir en el Designer)
            tableClinico.Controls.Add(label32, 0, 0); // Clínico

            // Configurar el DataGridView para que ocupe todo el espacio
            dgvClinico.Dock = DockStyle.Fill;

            // Agregar el DataGridView abajo
            tableClinico.Controls.Add(dgvClinico, 0, 1);

            // Limpiar el TabPage y agregar el TableLayoutPanel
            tabClinico.Controls.Clear();
            tabClinico.Controls.Add(tableClinico);
        }

        /// <summary>
        /// Ajusta el layout de la sección Laboratorio para que los DataGridView estén juntos y ocupen todo el espacio horizontal
        /// </summary>
        private void InicializarLaboratorioLayout()
        {
            // Busca el TabPage correspondiente a Laboratorio (ajusta el nombre si es diferente)
            var tabLaboratorio = this.Controls.OfType<TabControl>()
                .SelectMany(tc => tc.TabPages.Cast<TabPage>())
                .FirstOrDefault(tp => tp.Text.Contains("Laboratorio") || tp.Name.Contains("Laboratorio"));

            if (tabLaboratorio == null)
                return;

            // Crear TableLayoutPanel con 6 columnas y 2 filas (etiqueta arriba, grid abajo)
            var tableLaboratorio = new TableLayoutPanel
            {
                ColumnCount = 6,
                RowCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = false,
                AutoScroll = false // Desactivado para evitar scroll molesto
            };
            for (int i = 0; i < 6; i++)
                tableLaboratorio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / 6F));
            tableLaboratorio.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F)); // Etiquetas
            tableLaboratorio.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Grids

            // Agregar los Label arriba (deben existir en el Designer)
            tableLaboratorio.Controls.Add(label33, 0, 0); // Hematología
            tableLaboratorio.Controls.Add(label34, 1, 0); // Química Hemática
            tableLaboratorio.Controls.Add(label35, 2, 0); // Serología
            tableLaboratorio.Controls.Add(label36, 3, 0); // Perfil Lipídico
            tableLaboratorio.Controls.Add(label37, 4, 0); // Bacteriología
            tableLaboratorio.Controls.Add(label38, 5, 0); // Orina

            // Configurar los DataGridView para que ocupen todo el espacio
            dgvHematologia.Dock = DockStyle.Fill;
            dgvQuimicaHematica.Dock = DockStyle.Fill;
            dgvSerologia.Dock = DockStyle.Fill;
            dgvPerfilLipidico.Dock = DockStyle.Fill;
            dgvBacteriologia.Dock = DockStyle.Fill;
            dgvOrina.Dock = DockStyle.Fill;

            // Agregar los DataGridView abajo
            tableLaboratorio.Controls.Add(dgvHematologia, 0, 1);
            tableLaboratorio.Controls.Add(dgvQuimicaHematica, 1, 1);
            tableLaboratorio.Controls.Add(dgvSerologia, 2, 1);
            tableLaboratorio.Controls.Add(dgvPerfilLipidico, 3, 1);
            tableLaboratorio.Controls.Add(dgvBacteriologia, 4, 1);
            tableLaboratorio.Controls.Add(dgvOrina, 5, 1);

            // Limpiar el TabPage y agregar el TableLayoutPanel
            tabLaboratorio.Controls.Clear();
            tabLaboratorio.Controls.Add(tableLaboratorio);
        }


        private void ItemsPorSecciones_Load(object sender, EventArgs e)
        {
            // Cargar datos aquí
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Manejar cambio de pestaña
        }

        /// <summary>
        /// Event handler que se dispara cuando hace click en el contenido de una celda (checkbox)
        /// Sincroniza el resumen cuando se marca/desmarca un checkbox
        /// </summary>
        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                DataGridView dgv = sender as DataGridView;
                if (dgv == null || e.ColumnIndex >= dgv.Columns.Count)
                    return;

                // ✅ Detectar si es la columna de Estado (columna 2) - Checkbox
                if (e.ColumnIndex == 2)
                {
                    // ✅ IMPORTANTE: Verificar que sea realmente una columna checkbox
                    if (dgv.Columns[2] is DataGridViewCheckBoxColumn)
                    {
                        System.Diagnostics.Debug.WriteLine($"► Checkbox clickeado en fila {e.RowIndex} en {dgv.Name}");

                        // ✅ CRÍTICO: Llamar a EndEdit() INMEDIATAMENTE para sincronizar con DataTable
                        // Esto fuerza que el checkbox se escriba en el DataTable al instante
                        dgv.EndEdit();
                        System.Diagnostics.Debug.WriteLine($"  ✓ EndEdit() ejecutado para sincronizar");

                        // ✅ Leer el valor actual del checkbox DESPUÉS de EndEdit
                        if (dgv.DataSource is DataTable dt && e.RowIndex < dt.Rows.Count)
                        {
                            bool nuevoEstado = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells[2].Value ?? false);
                            System.Diagnostics.Debug.WriteLine($"  ✓ Nuevo estado leído: {nuevoEstado}");
                            System.Diagnostics.Debug.WriteLine($"  ✓ DataTable fila {e.RowIndex} = {dt.Rows[e.RowIndex][2]}");
                        }

                        // ✅ Usar BeginInvoke para actualizar el resumen DESPUÉS de que todo se sincronice
                        this.BeginInvoke(new Action(() =>
                        {
                            System.Diagnostics.Debug.WriteLine($"  ✓ Actualizando resumen");
                            ActualizarResumen();
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en Dgv_CellContentClick: {ex.Message}");
            }
        }

        /// <summary>
        /// Navega a una tab específica del TabControl
        /// </summary>
        public void NavigarATab(int indiceTab)
        {
            try
            {
                if (indiceTab >= 0 && indiceTab < tabControl.TabCount)
                {
                    tabControl.SelectedIndex = indiceTab;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al navegar a tab: {ex.Message}");
            }
        }

        // Conversión robusta de cualquier valor a bool
        private bool ConvertirABool(object valor)
        {
            if (valor == null || valor == DBNull.Value) return false;
            if (valor is bool b) return b;
            if (valor is int i) return i != 0;
            if (valor is string s)
                return s == "1" || s.Equals("true", StringComparison.OrdinalIgnoreCase);
            try { return Convert.ToBoolean(valor); } catch { return false; }
        }

        /// <summary>
        /// Carga la entidad TipoExamen y llena los DataGridView con los items por sección
        /// </summary>
        public void CargarItemsPorSeccion(string idTipoExamen)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] CargarItemsPorSeccion: idTipoExamen recibido = {idTipoExamen}");
                tipoExamenNegocio = new CapaNegocioMepryl.TipoExamen();
                Entidades.TipoExamen entidad = tipoExamenNegocio.cargarEntidad(idTipoExamen);
                if (entidad != null)
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Entidad cargada: Id={entidad.Id}, Descripcion={entidad.Descripcion}");
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Clinico: {entidad.Clinico?.Rows.Count ?? 0} items");
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Hematologia: {entidad.Hematologia?.Rows.Count ?? 0} items");
                    // ... puedes agregar más debug si lo necesitas ...
                    LlenarDataGrids(entidad);
                    LlenarResumen(entidad);
                    NavigarATab(1);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG] No se pudo cargar la entidad TipoExamen");
                    MessageBox.Show("No se pudo cargar la entidad TipoExamen", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Error en CargarItemsPorSeccion: {ex.Message}");
                MessageBox.Show("Error al cargar items por sección: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Llena todos los DataGridView con los datos de la entidad TipoExamen
        /// Replicando el patrón de frmLocalidadNacionalidad.cs
        /// </summary>
        private void LlenarDataGrids(Entidades.TipoExamen entidad)
        {
            try
            {
                // TAB: EX. CLÍNICO
                dgvClinico.DataSource = entidad.Clinico;
                dgvClinico.BackgroundColor = SystemColors.Control;

                // TAB: LABORATORIO (6 DataGridView)
                dgvHematologia.DataSource = entidad.Hematologia;
                dgvHematologia.BackgroundColor = SystemColors.Control;
                dgvQuimicaHematica.DataSource = entidad.QuimicaHematica;
                dgvQuimicaHematica.BackgroundColor = SystemColors.Control;
                dgvSerologia.DataSource = entidad.Serologia;
                dgvSerologia.BackgroundColor = SystemColors.Control;
                dgvPerfilLipidico.DataSource = entidad.PerfilLipidico;
                dgvPerfilLipidico.BackgroundColor = SystemColors.Control;
                dgvBacteriologia.DataSource = entidad.Bacteriologia;
                dgvBacteriologia.BackgroundColor = SystemColors.Control;
                dgvOrina.DataSource = entidad.Orina;
                dgvOrina.BackgroundColor = SystemColors.Control;

                // TAB: RAYOS X (4 DataGridView)
                dgvLaboralesBasicas.DataSource = entidad.LaboralesBasicas;
                dgvLaboralesBasicas.BackgroundColor = SystemColors.Control;
                dgvCraneoYMSuperior.DataSource = entidad.CraneoYMSuperior;
                dgvCraneoYMSuperior.BackgroundColor = SystemColors.Control;
                dgvTroncoYPelvis.DataSource = entidad.TroncoYPelvis;
                dgvTroncoYPelvis.BackgroundColor = SystemColors.Control;
                dgvMiembroInferior.DataSource = entidad.MiembroInferior;
                dgvMiembroInferior.BackgroundColor = SystemColors.Control;

                // TAB: ESTUDIOS COMPLEMENTARIOS
                dgvEstComplementarios.DataSource = entidad.EstComplementarios;
                dgvEstComplementarios.BackgroundColor = SystemColors.Control;

                // Ocultar columnas de ID en todos los grids
                OcultarColumnasID();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar DataGridView: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Llena los TextBox de resumen con la información de la entidad
        /// SOLO MUESTRA ITEMS MARCADOS (Estado = true)
        /// </summary>
        private void LlenarResumen(Entidades.TipoExamen entidad)
        {
            try
            {
                // Generar resumen de cada sección (solo items marcados)
                tbResumenClinico.Text = GenerarResumenSeccion(entidad.Clinico);
                tbResumenLaboratorio.Text = GenerarResumenSeccion(entidad.Hematologia);
                tbResumenRx.Text = GenerarResumenSeccion(entidad.CraneoYMSuperior);
                tbResumenEstCompl.Text = GenerarResumenSeccion(entidad.EstComplementarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar resumen: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Genera un resumen textual a partir de una DataTable de items
        /// SOLO INCLUYE ITEMS CON Estado = true (marcados)
        /// Estructura esperada: [0]=Id, [1]=Codigo, [2]=Estado, [3]=Item, [4]=OrdenFormulario
        /// </summary>
        private string GenerarResumenSeccion(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return "";

            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    // Conversión robusta a bool
                    if (ConvertirABool(row.ItemArray[2]))
                    {
                        string item = row.ItemArray[3]?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(item))
                        {
                            if (sb.Length > 0)
                                sb.Append(" - ");
                            sb.Append(item);
                        }
                    }
                }
                catch { }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Oculta las columnas de ID (0) y Código (1), pero las mantiene en la consulta
        /// Mostrando solo: Checkbox, Estado, Nombre/Item
        /// </summary>
        private void OcultarColumnasID()
        {
            try
            {
                // Lista de todos los DataGridView
                DataGridView[] grids = new DataGridView[]
                {
                    dgvClinico, dgvHematologia, dgvQuimicaHematica, dgvSerologia,
                    dgvPerfilLipidico, dgvBacteriologia, dgvOrina, dgvLaboralesBasicas,
                    dgvCraneoYMSuperior, dgvTroncoYPelvis, dgvMiembroInferior, dgvEstComplementarios
                };

                foreach (DataGridView grid in grids)
                {
                    // Ocultar columna 0 (ID numérico)
                    if (grid.Columns.Count > 0)
                        grid.Columns[0].Visible = false;

                    // Ocultar columna 1 (Código)
                    if (grid.Columns.Count > 1)
                        grid.Columns[1].Visible = false;

                    // ✅ IMPORTANTE: Convertir columna 2 (Estado) a DataGridViewCheckBoxColumn
                    // Si no se convierte, el DataGridView modrá comportarse de manera extraña
                    if (grid.Columns.Count > 2)
                    {
                        // Guardar el índice y propiedades de la columna actual
                        int columnIndex = 2;

                        // Remover la columna auto-generada
                        grid.Columns.RemoveAt(columnIndex);

                        // Crear una nueva columna checkbox
                        DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
                        chkColumn.HeaderText = "Estado";
                        chkColumn.Name = "Estado";
                        chkColumn.DataPropertyName = "Estado";
                        chkColumn.Width = 50;
                        chkColumn.FalseValue = false;
                        chkColumn.TrueValue = true;
                        chkColumn.CellTemplate = new DataGridViewCheckBoxCell();

                        // Insertar en la posición correcta
                        grid.Columns.Insert(columnIndex, chkColumn);

                        System.Diagnostics.Debug.WriteLine($"✓ Columna 'Estado' convertida a CheckBox en {grid.Name}");
                    }


                    // ✅ MEJORAR UX: Seleccionar solo celdas individuales
                    grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    grid.MultiSelect = false;  // Solo una celda a la vez

                    // ✅ Quitar color azul de selección
                    grid.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
                    grid.DefaultCellStyle.SelectionForeColor = Color.Black;

                    // ✅ VINCULAR EVENT HANDLER PARA SINCRONIZAR RESUMEN
                    // Usar CellContentClick para checkboxes (evita movimiento de cursor)
                    // IMPORTANTE: Desuscribir ANTES de suscribir para evitar duplicados
                    grid.CellContentClick -= Dgv_CellContentClick;
                    grid.CellContentClick += Dgv_CellContentClick;

                    System.Diagnostics.Debug.WriteLine($"✓ Evento CellContentClick registrado para {grid.Name}");
                }
            }
            catch { }
        }

        /// <summary>
        /// Actualiza todos los TextBox de resumen según los items marcados
        /// Siguiendo el patrón de frmLocalidadNacionalidad.cs
        /// </summary>
        private void ActualizarResumen()
        {
            try
            {
                if (tbResumenClinico == null || tbResumenLaboratorio == null ||
                    tbResumenRx == null || tbResumenEstCompl == null)
                    return;

                System.Diagnostics.Debug.WriteLine("► Actualizando resumen...");

                // ✅ RESUMEN CLÍNICO (solo dgvClinico)
                List<DataTable> listaClinico = new List<DataTable>();
                if (dgvClinico.DataSource is DataTable dtClinico && dtClinico.Rows.Count > 0)
                {
                    listaClinico.Add(dtClinico);
                    System.Diagnostics.Debug.WriteLine($"  - Clínico: {dtClinico.Rows.Count} items");
                }
                ActualizarTextBox(tbResumenClinico, ref listaClinico);

                // ✅ RESUMEN LABORATORIO (todas las 6 secciones)
                List<DataTable> listaLaboratorio = new List<DataTable>();
                if (dgvHematologia.DataSource is DataTable dt1) listaLaboratorio.Add(dt1);
                if (dgvQuimicaHematica.DataSource is DataTable dt2) listaLaboratorio.Add(dt2);
                if (dgvSerologia.DataSource is DataTable dt3) listaLaboratorio.Add(dt3);
                if (dgvPerfilLipidico.DataSource is DataTable dt4) listaLaboratorio.Add(dt4);
                if (dgvBacteriologia.DataSource is DataTable dt5) listaLaboratorio.Add(dt5);
                if (dgvOrina.DataSource is DataTable dt6) listaLaboratorio.Add(dt6);
                if (listaLaboratorio.Count > 0)
                    System.Diagnostics.Debug.WriteLine($"  - Laboratorio: {listaLaboratorio.Count} secciones");
                ActualizarTextBox(tbResumenLaboratorio, ref listaLaboratorio);

                // ✅ RESUMEN RAYOS X (todas las 4 secciones)
                List<DataTable> listaRayosX = new List<DataTable>();
                if (dgvLaboralesBasicas.DataSource is DataTable dt7) listaRayosX.Add(dt7);
                if (dgvCraneoYMSuperior.DataSource is DataTable dt8) listaRayosX.Add(dt8);
                if (dgvTroncoYPelvis.DataSource is DataTable dt9) listaRayosX.Add(dt9);
                if (dgvMiembroInferior.DataSource is DataTable dt10) listaRayosX.Add(dt10);
                if (listaRayosX.Count > 0)
                    System.Diagnostics.Debug.WriteLine($"  - Rayos X: {listaRayosX.Count} secciones");
                ActualizarTextBox(tbResumenRx, ref listaRayosX);

                // ✅ RESUMEN ESTUDIOS COMPLEMENTARIOS
                List<DataTable> listaEstCompl = new List<DataTable>();
                if (dgvEstComplementarios.DataSource is DataTable dt11) listaEstCompl.Add(dt11);
                ActualizarTextBox(tbResumenEstCompl, ref listaEstCompl);

                System.Diagnostics.Debug.WriteLine("✓ Resumen actualizado correctamente");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en ActualizarResumen: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza un TextBox de resumen con los items marcados de múltiples DataTables
        /// Estructura esperada: [0]=Id, [1]=Codigo, [2]=Estado, [3]=Item, [4]=OrdenFormulario
        /// Siguiendo exactamente el patrón de frmLocalidadNacionalidad.cs
        /// </summary>
        // ...existing code...

        /// <summary>
        /// Ajusta el layout de la sección Rayos X para que los DataGridView estén juntos y ocupen todo el espacio horizontal
        /// </summary>
        private void InicializarRayosXLayout()
        {
            // Busca el TabPage correspondiente a Rayos X (ajusta el nombre si es diferente)
            var tabRayosX = this.Controls.OfType<TabControl>()
                .SelectMany(tc => tc.TabPages.Cast<TabPage>())
                .FirstOrDefault(tp => tp.Text.Contains("Rayos X") || tp.Name.Contains("RayosX"));

            if (tabRayosX == null)
                return;

            // Crear TableLayoutPanel con 4 columnas y 2 filas (etiqueta arriba, grid abajo)
            var tableRayosX = new TableLayoutPanel
            {
                ColumnCount = 4,
                RowCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = false,
                AutoScroll = false // Desactivado para evitar scroll molesto
            };
            for (int i = 0; i < 4; i++)
                tableRayosX.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableRayosX.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F)); // Etiquetas
            tableRayosX.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Grids

            // Agregar los Label arriba (deben existir en el Designer)
            tableRayosX.Controls.Add(label40, 0, 0); // Laborales Básicas
            tableRayosX.Controls.Add(label41, 1, 0); // Cráneo y Miembro Superior
            tableRayosX.Controls.Add(label42, 2, 0); // Tronco y Pelvis
            tableRayosX.Controls.Add(label39, 3, 0); // Miembro Inferior

            // Configurar los DataGridView para que ocupen todo el espacio
            dgvLaboralesBasicas.Dock = DockStyle.Fill;
            dgvCraneoYMSuperior.Dock = DockStyle.Fill;
            dgvTroncoYPelvis.Dock = DockStyle.Fill;
            dgvMiembroInferior.Dock = DockStyle.Fill;

            // Agregar los DataGridView abajo
            tableRayosX.Controls.Add(dgvLaboralesBasicas, 0, 1);
            tableRayosX.Controls.Add(dgvCraneoYMSuperior, 1, 1);
            tableRayosX.Controls.Add(dgvTroncoYPelvis, 2, 1);
            tableRayosX.Controls.Add(dgvMiembroInferior, 3, 1);

            // Limpiar el TabPage y agregar el TableLayoutPanel
            tabRayosX.Controls.Clear();
            tabRayosX.Controls.Add(tableRayosX);
        }

        // Propiedades públicas para exponer los TextBox de resumen
        public TextBox TxtResumenClinico => tbResumenClinico;
        public TextBox TxtResumenLaboratorio => tbResumenLaboratorio;
        public TextBox TxtResumenRx => tbResumenRx;
        public TextBox TxtResumenEstCompl => tbResumenEstCompl;

        // ...existing code...
        private void ActualizarTextBox(TextBox tb, ref List<DataTable> lista)
        {
            try
            {
                tb.Clear();
                int itemsMarcados = 0;

                foreach (DataTable dt in lista)
                {
                    if (dt == null) continue;

                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            // ItemArray[2] = Estado (checkbox)
                            // ItemArray[3] = Item (descripción)
                            bool estado = ConvertirABool(dr.ItemArray[2]);
                            string item = dr.ItemArray[3]?.ToString() ?? "";

                            if (estado && !string.IsNullOrEmpty(item))
                            {
                                if (tb.Text.Length == 0)
                                {
                                    tb.Text = item;
                                }
                                else
                                {
                                    tb.Text = tb.Text + " - " + item;
                                }
                                itemsMarcados++;
                                System.Diagnostics.Debug.WriteLine($"    ✓ Agregado al resumen: {item}");
                            }
                        }
                        catch (Exception exRow)
                        {
                            System.Diagnostics.Debug.WriteLine($"    ⚠️ Error leyendo fila: {exRow.Message}");
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine($"  → Total items en resumen: {itemsMarcados}");
                lista.Clear();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en ActualizarTextBox: {ex.Message}");
            }
        }

        /// <summary>
        /// NUEVO: Guarda los items seleccionados (Estado = true) en la BD
        /// Se llama desde BtnGrabar en frmLocalidadNacionalidad
        /// </summary>
        public void GuardarItems(string idSubtipo)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"\n╔════════════════════════════════════════════════════╗");
                System.Diagnostics.Debug.WriteLine($"║     INICIANDO GUARDADO DE ITEMS                     ║");
                System.Diagnostics.Debug.WriteLine($"╚════════════════════════════════════════════════════╝");
                System.Diagnostics.Debug.WriteLine($"► ID Subtipo recibido: {idSubtipo ?? "NULL"}");

                if (tipoExamenNegocio == null)
                    tipoExamenNegocio = new CapaNegocioMepryl.TipoExamen();

                // ✅ VALIDACIÓN: Verificar que el ID no sea nulo o vacío
                if (string.IsNullOrEmpty(idSubtipo))
                {
                    System.Diagnostics.Debug.WriteLine("⚠️ ERROR: idSubtipo es NULL o vacío");
                    throw new Exception("El ID del subtipo no puede estar vacío. Seleccione un subtipo correctamente.");
                }

                // ✅ VALIDAR: Verificar si hay al menos UN item marcado
                if (!HayItemsMarcados())
                {
                    System.Diagnostics.Debug.WriteLine("⚠️ No hay items marcados - Guardado cancelado");
                    throw new Exception("Debe seleccionar al menos un item para guardar");
                }

                // ✅ Recolectar items de todas las grillas y guardarlos
                GuardarEstadoItemsParaSubtipo(idSubtipo);

                System.Diagnostics.Debug.WriteLine($"✅ Items guardados correctamente para subtipo: {idSubtipo}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ ERROR en GuardarItems: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Verifica si hay al menos un item marcado en cualquier grilla
        /// </summary>
        private bool HayItemsMarcados()
        {
            try
            {
                DataGridView[] grids = new DataGridView[]
                {
                    dgvClinico, dgvHematologia, dgvQuimicaHematica, dgvSerologia,
                    dgvPerfilLipidico, dgvBacteriologia, dgvOrina, dgvLaboralesBasicas,
                    dgvCraneoYMSuperior, dgvTroncoYPelvis, dgvMiembroInferior, dgvEstComplementarios
                };

                int totalItemsRevisados = 0;
                int itemsMarcados = 0;

                foreach (DataGridView dgv in grids)
                {
                    if (dgv == null || dgv.Rows.Count == 0)
                        continue;

                    System.Diagnostics.Debug.WriteLine($"  → Revisando {dgv.Name} ({dgv.Rows.Count} filas)");

                    // ✅ Leer DESDE EL DATAGRIDVIEW, no del DataTable
                    // porque el DataTable podría no estar sincronizado si el usuario marcó pero no presionó tabular
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        try
                        {
                            // Leer el valor del checkbox en la UI (columna 2)
                            bool estado = Convert.ToBoolean(row.Cells[2].Value ?? false);
                            totalItemsRevisados++;

                            if (estado)
                            {
                                string item = row.Cells[3].Value?.ToString() ?? "Sin descripción";
                                System.Diagnostics.Debug.WriteLine($"    ✓ Item MARCADO: {item}");
                                itemsMarcados++;
                            }
                        }
                        catch (Exception exRow)
                        {
                            System.Diagnostics.Debug.WriteLine($"    ⚠️ Error leyendo fila: {exRow.Message}");
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine($"📊 RESUMEN: {itemsMarcados} items marcados de {totalItemsRevisados} revisados");

                return itemsMarcados > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en HayItemsMarcados: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Guarda el estado de los items (qué está marcado) en la BD
        /// </summary>
        private void GuardarEstadoItemsParaSubtipo(string idSubtipo)
        {
            try
            {
                if (string.IsNullOrEmpty(idSubtipo))
                {
                    System.Diagnostics.Debug.WriteLine("ERROR: idSubtipo es nulo o vacío");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"► Guardando items para subtipo: {idSubtipo}");

                // ✅ IMPORTANTE: Llamar a EndEdit() en TODOS los DataGridView
                // Esto asegura que los cambios de checkboxes se graben en el DataTable
                CommitDataGridChanges();

                // ✅ CARGAR LA ENTIDAD COMPLETA DESDE BD
                Entidades.TipoExamen entidadParaGuardar = tipoExamenNegocio.cargarEntidad(idSubtipo);

                if (entidadParaGuardar == null)
                {
                    System.Diagnostics.Debug.WriteLine($"ERROR: No se pudo cargar la entidad para subtipo: {idSubtipo}");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"► Entidad cargada. Clinico: {entidadParaGuardar.Clinico.Rows.Count} items");

                // ✅ NUEVO PATRÓN: NO limpiar y re-llenar, sino SINCRONIZAR los valores desde la UI
                // Mapeo: DataGridView en UI -> DataTable en Entidad
                Dictionary<DataGridView, DataTable> mapeoGrillaADataTable = new Dictionary<DataGridView, DataTable>
                {
                    { dgvClinico, entidadParaGuardar.Clinico },
                    { dgvHematologia, entidadParaGuardar.Hematologia },
                    { dgvQuimicaHematica, entidadParaGuardar.QuimicaHematica },
                    { dgvSerologia, entidadParaGuardar.Serologia },
                    { dgvPerfilLipidico, entidadParaGuardar.PerfilLipidico },
                    { dgvBacteriologia, entidadParaGuardar.Bacteriologia },
                    { dgvOrina, entidadParaGuardar.Orina },
                    { dgvLaboralesBasicas, entidadParaGuardar.LaboralesBasicas },
                    { dgvCraneoYMSuperior, entidadParaGuardar.CraneoYMSuperior },
                    { dgvTroncoYPelvis, entidadParaGuardar.TroncoYPelvis },
                    { dgvMiembroInferior, entidadParaGuardar.MiembroInferior },
                    { dgvEstComplementarios, entidadParaGuardar.EstComplementarios }
                };

                // ✅ Sincronizar el estado (checked/unchecked) desde las grillas hacia los DataTables
                int itemsActualizados = 0;
                foreach (var kvp in mapeoGrillaADataTable)
                {
                    DataGridView dgv = kvp.Key;
                    DataTable dt = kvp.Value;

                    if (dgv == null || dt == null || dgv.Rows.Count != dt.Rows.Count)
                    {
                        System.Diagnostics.Debug.WriteLine($"⚠️ Mismatch en {dgv.Name}: Grid={dgv?.Rows.Count}, DT={dt?.Rows.Count}");
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine($"  → Sincronizando {dgv.Name}");

                    // Recorrer ambos en sincronía: UI y DataTable
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        try
                        {
                            // Leer estado desde la UI (columna 2)
                            bool estadoUI = Convert.ToBoolean(dgv.Rows[i].Cells[2].Value ?? false);

                            // Actualizar en el DataTable (columna 2)
                            dt.Rows[i][2] = estadoUI;

                            itemsActualizados++;

                            if (estadoUI)
                            {
                                string item = dt.Rows[i][3]?.ToString() ?? "";
                                System.Diagnostics.Debug.WriteLine($"    ✓ Item [{i}] = {estadoUI}: {item}");
                            }
                        }
                        catch (Exception exSync)
                        {
                            System.Diagnostics.Debug.WriteLine($"    ⚠️ Error sincronizando fila {i}: {exSync.Message}");
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine($"► {itemsActualizados} items sincronizados desde UI al DataTable");

                // ✅ GUARDAR LA ENTIDAD ACTUALIZADA EN BD
                System.Diagnostics.Debug.WriteLine($"► Guardando items en BD usando LimpiarYGuardarItemsDelSubtipo...");

                // LLAMAR AL NUEVO MÉTODO QUE LIMPIA Y GUARDA LOS ITEMS
                LimpiarYGuardarItemsDelSubtipo(idSubtipo, entidadParaGuardar);

                System.Diagnostics.Debug.WriteLine($"✅ GuardarEstadoItemsParaSubtipo completado - Guardado en BD");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en GuardarEstadoItemsParaSubtipo: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Llama a EndEdit() en TODOS los DataGridView para forzar que los cambios se guarden
        /// en el DataTable subyacente. Esto es CRÍTICO para que los checkboxes se sincronicen.
        /// </summary>
        private void CommitDataGridChanges()
        {
            try
            {
                DataGridView[] grids = new DataGridView[]
                {
                    dgvClinico, dgvHematologia, dgvQuimicaHematica, dgvSerologia,
                    dgvPerfilLipidico, dgvBacteriologia, dgvOrina, dgvLaboralesBasicas,
                    dgvCraneoYMSuperior, dgvTroncoYPelvis, dgvMiembroInferior, dgvEstComplementarios
                };

                foreach (DataGridView dgv in grids)
                {
                    if (dgv != null && dgv.DataSource != null)
                    {
                        // ✅ IMPORTANTE: EndEdit() fuerza que todos los cambios pendientes se escriban en el DataSource
                        dgv.EndEdit();
                        System.Diagnostics.Debug.WriteLine($"  ✓ EndEdit() ejecutado en {dgv.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en CommitDataGridChanges: {ex.Message}");
            }
        }

        /// <summary>
        /// Limpia todos los items del subtipo en BD y guarda los nuevos items marcados como TRUE
        /// </summary>
        private void LimpiarYGuardarItemsDelSubtipo(string idSubtipo, Entidades.TipoExamen entidad)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"► LimpiarYGuardarItemsDelSubtipo para {idSubtipo}");

                // ✅ PASO 1: LIMPIAR TODOS LOS ITEMS DEL SUBTIPO EN BD
                System.Diagnostics.Debug.WriteLine($"  1️⃣ Limpiando items previos...");
                tipoExamenNegocio.limpiarEstudiosPorSubtipo(idSubtipo);
                System.Diagnostics.Debug.WriteLine($"  ✓ Items previos eliminados");

                // ✅ PASO 2: GUARDAR LOS ITEMS NUEVOS (SOLO LOS MARCADOS COMO TRUE)
                System.Diagnostics.Debug.WriteLine($"  2️⃣ Insertando items nuevos...");

                Dictionary<DataTable, int> mapeoDataTableAOrden = new Dictionary<DataTable, int>
                {
                    { entidad.Clinico, 1 },
                    { entidad.Hematologia, 2 },
                    { entidad.QuimicaHematica, 3 },
                    { entidad.Serologia, 4 },
                    { entidad.PerfilLipidico, 5 },
                    { entidad.Bacteriologia, 6 },
                    { entidad.Orina, 7 },
                    { entidad.LaboralesBasicas, 8 },
                    { entidad.CraneoYMSuperior, 9 },
                    { entidad.TroncoYPelvis, 10 },
                    { entidad.MiembroInferior, 11 },
                    { entidad.EstComplementarios, 12 }
                };

                int itemsInsertados = 0;

                foreach (var kvp in mapeoDataTableAOrden)
                {
                    DataTable dt = kvp.Key;
                    int orden = kvp.Value;

                    if (dt == null || dt.Rows.Count == 0)
                        continue;

                    System.Diagnostics.Debug.WriteLine($"    → Procesando orden {orden} ({dt.Rows.Count} items)");

                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            bool estado = ConvertirABool(row[2]); // columna 2 = estado

                            // SOLO GUARDAR LOS QUE ESTÁN MARCADOS COMO TRUE
                            if (estado)
                            {
                                int codigo = Convert.ToInt32(row[1]);
                                string item = row[3]?.ToString() ?? "";

                                // ✅ INSERTAR EN BD
                                tipoExamenNegocio.insertarEstudioPorSubtipo(idSubtipo, codigo, item, orden);
                                itemsInsertados++;

                                System.Diagnostics.Debug.WriteLine($"      ✓ [{codigo}] {item}");
                            }
                        }
                        catch (Exception exRow)
                        {
                            System.Diagnostics.Debug.WriteLine($"      ⚠️ Error procesando row: {exRow.Message}");
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine($"✅ {itemsInsertados} items insertados en BD para subtipo {idSubtipo}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en LimpiarYGuardarItemsDelSubtipo: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                throw;
            }
        }
    }
}
