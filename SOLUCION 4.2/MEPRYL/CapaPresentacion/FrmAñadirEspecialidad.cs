// Conversión robusta de cualquier valor a bool

/// <summary>
/// Debug: Muestra la cantidad de ítems totales y marcados por subtipo en cada sección
/// </summary>

// Método para filtrar y mostrar los tipos de examen padre por nombre

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
using Entidades;

namespace CapaPresentacion
{
    public partial class FrmAñadirEspecialidad : Form
    {
        // Permite ocultar y mostrar el tab "Items" dinámicamente
        private TabPage tabItemsBackup = null;
        private TabPage tabPruenaBackup = null; // 
        private TabPage tabGestionarBackup = null; // ← NUEVA
        private TabPage tabAgregarBackup = null;           // ← NUEVA
        private TabPage tabItemsSeccionesBackup = null;   // ← NUEVA
        private TabPage tabResumenBackup = null;
        public bool TodosSubtiposDesactivados { get; private set; }

        private List<KeyValuePair<string, bool>> subtiposPendientesCambio = new List<KeyValuePair<string, bool>>();

        // Bandera para controlar el mensaje de estado

        private bool mostrarMensajeEstado = true;
        private bool actualizandoEstadoMotivo = false; // ✅ Evita recursión al actualizar checkboxes de EstadoMotivo
        private string idSubtipoDesactivadoParaPintar = null; // ✅ Guarda el id del subtipo desactivado para pintarlo en azul
        private CapaNegocioMepryl.TipoExamen negocioTipoExamen;
        private List<Entidades.TipoExamen> listaTiposExamenes; // Lista temporal en memoria
        private int idMotivoConsultaSeleccionado;
        private string idTipoExamenSeleccionado; // Almacena el ID del TipoExamen seleccionado
        private string idSubtipoActualmenteCargado; // Almacena el ID del subtipo actual para auto-save al cambiar

        private DataTable dtTiposExamenesOriginal; // DataTable original para filtrar correctamente

        private bool permitirEventoSubtipo = true;
        private bool permitirSincronizacion = true;  // ✅ Bandera para evitar sincronización recursiva
        // Bandera para evitar selección automática de tipo de examen tras guardar en Motivo de Consulta
        private bool evitarSeleccionTipoExamenAutomatico = false;
        // Bandera para ignorar eventos del grid durante la reasignación del DataSource
        private bool ignorandoEventosGrid = false;
        // Bandera para evitar filtrado automático al recargar por DropDown
        private bool ignorarEventoTipoExamen = false;
        private bool recargandoPorDropDown = false;



        private void DebugResumenSubtipo()
        {
            if (itemsPorSecciones == null) return;
            var sb = new StringBuilder();
            sb.AppendLine($"[DEBUG] Resumen de ítems para subtipo actual:");

            void Seccion(string nombre, DataGridView dgv)
            {
                if (dgv == null) return;
                int total = dgv.Rows.Count;
                int marcados = 0;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    try
                    {
                        bool estado = Convert.ToBoolean(row.Cells[2].Value ?? false);
                        if (estado) marcados++;
                    }
                    catch { }
                }
                sb.AppendLine($"  - {nombre}: {marcados} marcados / {total} total");
            }

            Seccion("Clínico", itemsPorSecciones.DgvClinico);
            Seccion("Hematología", itemsPorSecciones.DgvHematologia);
            Seccion("Química Hemática", itemsPorSecciones.DgvQuimicaHematica);
            Seccion("Serología", itemsPorSecciones.DgvSerologia);
            Seccion("Perfil Lipídico", itemsPorSecciones.DgvPerfilLipidico);
            Seccion("Bacteriología", itemsPorSecciones.DgvBacteriologia);
            Seccion("Orina", itemsPorSecciones.DgvOrina);
            Seccion("Laborales Básicas", itemsPorSecciones.DgvLaboralesBasicas);
            Seccion("Cráneo y M. Superior", itemsPorSecciones.DgvCraneoYMSuperior);
            Seccion("Tronco y Pelvis", itemsPorSecciones.DgvTroncoYPelvis);
            Seccion("Miembro Inferior", itemsPorSecciones.DgvMiembroInferior);
            Seccion("Estudios Complementarios", itemsPorSecciones.DgvEstComplementarios);

            System.Diagnostics.Debug.WriteLine(sb.ToString());
        }

        public void SincronizarCombosDesde(int idMotivo, string idTipo, string idSubtipo)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"[SYNC] Iniciando SincronizarCombosDesde: idMotivo={idMotivo}, idTipo={idTipo}, idSubtipo={idSubtipo}");
                permitirEventoSubtipo = false;
                permitirSincronizacion = false;

                try
                {
                    // 1. Cargar motivos y seleccionar
                    CargarMotivosConsulta();

                    System.Diagnostics.Debug.WriteLine($"[SYNC] Motivos cargados. SelectedValue={cmbMotivoConsulta.SelectedValue}");

                    if (idMotivo > 0)
                    {
                        if (cmbMotivoConsulta.SelectedValue == null || Convert.ToInt32(cmbMotivoConsulta.SelectedValue) != idMotivo)
                        {
                            cmbMotivoConsulta.SelectedValue = idMotivo;
                            idMotivoConsultaSeleccionado = idMotivo;
                            System.Diagnostics.Debug.WriteLine($"[SYNC] Motivo seleccionado: {idMotivo}");
                        }
                    }


                    // 2. Cargar tipos y seleccionar
                    if (idMotivo > 0)
                    {
                        CargarTiposExamen();
                        Application.DoEvents();
                        System.Diagnostics.Debug.WriteLine($"[SYNC] Tipos de examen cargados. SelectedValue={cmbTipoExamen.SelectedValue}");
                        if (idMotivo > 0)
                            MostrarGestionMotivoTipoSubtipo(idMotivo);

                        if (!evitarSeleccionTipoExamenAutomatico)
                        {
                            if (!string.IsNullOrEmpty(idTipo))
                            {
                                if (cmbTipoExamen.SelectedValue == null || cmbTipoExamen.SelectedValue.ToString() != idTipo)
                                {
                                    cmbTipoExamen.SelectedValue = idTipo;
                                    idTipoExamenSeleccionado = idTipo;
                                    System.Diagnostics.Debug.WriteLine($"[SYNC] Tipo de examen seleccionado: {idTipo}");
                                }
                            }
                            else
                            {
                                // Si no hay tipo, limpiar selección
                                cmbTipoExamen.SelectedIndex = -1;
                                idTipoExamenSeleccionado = "";
                            }
                        }
                    }

                    // 3. Cargar subtipos y seleccionar
                    if (!string.IsNullOrEmpty(idTipo))
                    {
                        CargarSubtipos();
                        Application.DoEvents();
                        System.Diagnostics.Debug.WriteLine($"[SYNC] Subtipos cargados. SelectedValue={cmbSubtipo.SelectedValue}");
                        if (!string.IsNullOrEmpty(idSubtipo))
                        {
                            if (cmbSubtipo.SelectedValue == null || cmbSubtipo.SelectedValue.ToString() != idSubtipo)
                            {
                                cmbSubtipo.SelectedValue = idSubtipo;
                                idSubtipoActualmenteCargado = idSubtipo;
                                System.Diagnostics.Debug.WriteLine($"[SYNC] Subtipo seleccionado: {idSubtipo}");
                            }
                        }
                        else
                        {
                            // Si no hay subtipo, limpiar selección
                            cmbSubtipo.SelectedIndex = -1;
                            idSubtipoActualmenteCargado = "";
                        }
                    }

                    ActualizarEstadoControles();
                    System.Diagnostics.Debug.WriteLine($"[SYNC] Estado de controles actualizado");
                }
                finally
                {
                    permitirEventoSubtipo = true;
                    permitirSincronizacion = true;
                    evitarSeleccionTipoExamenAutomatico = false; // Siempre resetear tras sincronizar

                    Application.DoEvents();
                    System.Diagnostics.Debug.WriteLine($"[SYNC] Finalizando sincronización. idSubtipo={idSubtipo}, cmbSubtipo.SelectedIndex={cmbSubtipo.SelectedIndex}, idTipo={idTipo}, cmbTipoExamen.SelectedIndex={cmbTipoExamen.SelectedIndex}");
                    if (!string.IsNullOrEmpty(idSubtipo) && cmbSubtipo.SelectedIndex != -1)
                    {
                        System.Diagnostics.Debug.WriteLine($"[SYNC] Lanzando CmbSubtipo_SelectedIndexChanged por sincronización");
                        CmbSubtipo_SelectedIndexChanged(cmbSubtipo, EventArgs.Empty);
                    }
                    else if (!string.IsNullOrEmpty(idTipo) && cmbTipoExamen.SelectedIndex != -1)
                    {
                        System.Diagnostics.Debug.WriteLine($"[SYNC] Lanzando CmbTipoExamen_SelectedIndexChanged por sincronización");
                        CmbTipoExamen_SelectedIndexChanged(cmbTipoExamen, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                permitirEventoSubtipo = true;
                permitirSincronizacion = true;
                System.Diagnostics.Debug.WriteLine($"[SYNC][ERROR] Excepción en SincronizarCombosDesde: {ex.Message}\n{ex.StackTrace}");
            }
        }

        // Método público para activar la bandera desde fuera
        public void EvitarSeleccionTipoExamenAutomaticoEnProximaSincronizacion()
        {
            evitarSeleccionTipoExamenAutomatico = true;
        }

        // ✅ EVENT0: Notificar cuando se crea un subtipo
        public event EventHandler SubtipoCreado;

        // ✅ EVENT: Notificar cuando cambian los combos de sincronización (bidireccional)
        public event EventHandler<CombosChangedEventArgs> CombosChanged;

        public class CombosChangedEventArgs : EventArgs
        {
            public int IdMotivo { get; set; }
            public string IdTipo { get; set; }
            public string IdSubtipo { get; set; }
        }

        // ✅ PROPIEDADES PÚBLICAS PARA SINCRONIZACIÓN BIDIRECCIONAL
        public int ObtenerIdMotivoConsultaSeleccionado
        {
            get { return idMotivoConsultaSeleccionado; }
        }

        public string ObtenerIdTipoExamenSeleccionado
        {
            get { return idTipoExamenSeleccionado ?? ""; }
        }

        public string ObtenerIdSubtipoActualmenteCargado
        {
            get { return idSubtipoActualmenteCargado ?? ""; }
        }

        // ✅ PROPIEDAD PÚBLICA para acceder a la lista de tipos de exámenes
        public List<Entidades.TipoExamen> ObtenerListaTiposExamenes
        {
            get { return listaTiposExamenes; }
        }


        // ✅ MÉTODO PÚBLICO: Controlar visibilidad de tabs
        public void ConfigurarTabs(bool mostrarItems)
        {
            try
            {
                // Buscar el TabControl en el formulario
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TabControl tabCtrl)
                    {
                        // Recorrer todos los tabs y ocultar/mostrar solo el tab "Items" (tabItems)
                        foreach (TabPage tab in tabCtrl.TabPages)
                        {
                            // Buscar por el nombre de la variable (Name property) o por el texto (Text property)
                            if (tab.Name == "tabItems" || tab.Text.Equals("Items", StringComparison.OrdinalIgnoreCase))
                            {
                                tab.Visible = mostrarItems;
                            }
                        }

                        break; // Solo procesar el primer TabControl encontrado
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo silencioso de error
            }
        }

        // Handler para crear motivo de consulta
        private void button1_Click(object sender, EventArgs e)
        {
            // Mostrar diálogo para ingresar nombre e identificador interno
            using (var dlg = new FrmNuevoMotivoConsulta())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string nombre = dlg.NombreMotivo;
                    string identificador = dlg.IdentificadorInterno;
                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        MessageBox.Show("Ingrese un nombre para el motivo de consulta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int estado = dlg.Estado ? 1 : 0; // ✅ Obtener estado del formulario
                    var resultado = negocioTipoExamen.CrearMotivoDeConsulta(nombre, identificador, estado);
                    if (resultado != null && resultado.Modo > 0)
                    {
                        // ✅ Cargar motivos actualizados
                        CargarMotivosConsulta();

                        // ✅ Seleccionar automáticamente el nuevo motivo creado por nombre
                        if (cmbMotivoConsulta.DataSource is DataTable dt)
                        {
                            var filaMotivo = dt.AsEnumerable().FirstOrDefault(r => r.Field<string>("nombre").Equals(nombre, StringComparison.OrdinalIgnoreCase));
                            if (filaMotivo != null)
                            {
                                int nuevoMotivoId = int.Parse(filaMotivo.Field<object>("id").ToString());
                                cmbMotivoConsulta.SelectedValue = nuevoMotivoId;
                            }
                        }

                        MessageBox.Show(resultado.Mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(resultado?.Mensaje ?? "No se pudo crear el motivo de consulta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ═══════════════════════════════════════════════════════════════════════
        // MÉTODOS PARA TAB AGREGAR
        // ═══════════════════════════════════════════════════════════════════════

        public void OcultarTabAgregar()
        {
            if (tabControl.TabPages.Contains(tabAgregar))
            {
                tabAgregarBackup = tabAgregar;
                tabControl.TabPages.Remove(tabAgregar);
            }
        }

        public void MostrarTabAgregar(int index = -1)
        {
            if (!tabControl.TabPages.Contains(tabAgregar) && tabAgregarBackup != null)
            {
                if (index >= 0 && index <= tabControl.TabPages.Count)
                    tabControl.TabPages.Insert(index, tabAgregarBackup);
                else
                    tabControl.TabPages.Add(tabAgregarBackup);
            }
        }


        // ═══════════════════════════════════════════════════════════════════════
        // MÉTODOS PARA TAB ITEMS POR SECCIONES
        // ═══════════════════════════════════════════════════════════════════════

        // ✅ NUEVO: Navegar a un tab específico por nombre
        public void NavigarATab(string tabName)
        {
            try
            {
                foreach (TabPage tab in tabControl.TabPages)
                {
                    if (tab.Name == tabName)
                    {
                        tabControl.SelectedTab = tab;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo silencioso de error
            }
        }

        public void OcultarTabItemsSecciones()
        {
            if (tabControl.TabPages.Contains(tabItemsSecciones))
            {
                tabItemsSeccionesBackup = tabItemsSecciones;
                tabControl.TabPages.Remove(tabItemsSecciones);
            }
        }

        public void MostrarTabItemsSecciones(int index = -1)
        {
            if (!tabControl.TabPages.Contains(tabItemsSecciones) && tabItemsSeccionesBackup != null)
            {
                if (index >= 0 && index <= tabControl.TabPages.Count)
                    tabControl.TabPages.Insert(index, tabItemsSeccionesBackup);
                else
                    tabControl.TabPages.Add(tabItemsSeccionesBackup);
            }
        }





        public void OcultarTabGestionar()
        {
            if (tabControl.TabPages.Contains(tabGestionar))
            {
                tabGestionarBackup = tabGestionar;
                tabControl.TabPages.Remove(tabGestionar);
            }
        }

        public void MostrarTabGestionar(int index = -1)
        {
            if (!tabControl.TabPages.Contains(tabGestionar) && tabGestionarBackup != null)
            {
                if (index >= 0 && index <= tabControl.TabPages.Count)
                    tabControl.TabPages.Insert(index, tabGestionarBackup);
                else
                    tabControl.TabPages.Add(tabGestionarBackup);
            }
            // Limpiar la grilla al mostrar el tab
            dgvTiposExamenes.DataSource = null;
            dgvTiposExamenes.Rows.Clear();
            // Limpiar combos de filtro
            cmbMotivoConsulta.SelectedIndex = -1;
            cmbMotivoConsulta.SelectedItem = null;
            cmbMotivoConsulta.SelectedValue = null;
            cmbTipoExamen.DataSource = null;
            cmbTipoExamen.Items.Clear();
            cmbTipoExamen.SelectedIndex = -1;
            cmbSubtipo.DataSource = null;
            cmbSubtipo.Items.Clear();
            cmbSubtipo.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Validar selección
            if (cmbMotivoConsulta.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un motivo de consulta para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idMotivo;
            if (!int.TryParse(cmbMotivoConsulta.SelectedValue.ToString(), out idMotivo))
            {
                MessageBox.Show("No se pudo obtener el motivo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nombreMotivo = cmbMotivoConsulta.Text;
            var confirm = MessageBox.Show($"¿Está seguro que desea eliminar el motivo '{nombreMotivo}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var resultado = negocioTipoExamen.EliminarMotivoDeConsulta(idMotivo);
                if (resultado != null && resultado.Modo > 0)
                {
                    MessageBox.Show(resultado.Mensaje, "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMotivosConsulta();
                }
                else
                {
                    MessageBox.Show(resultado?.Mensaje ?? "No se pudo eliminar el motivo de consulta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AjustarAnchoColumnasTiposExamenes()
        {
            if (dgvTiposExamenes.Columns.Count == 0) return;
            dgvTiposExamenes.Columns["MotivoConsulta"].Width = 140;
            dgvTiposExamenes.Columns["EstadoMotivo"].Width = 60;
            dgvTiposExamenes.Columns["TipoExamen"].Width = 120;
            dgvTiposExamenes.Columns["SubtipoExamen"].Width = 120;
            dgvTiposExamenes.Columns["EstadoEspecialidad"].Width = 60;
            dgvTiposExamenes.Columns["Lun"].Width = 40;
            dgvTiposExamenes.Columns["Mar"].Width = 40;
            dgvTiposExamenes.Columns["Mie"].Width = 40;
            dgvTiposExamenes.Columns["Jue"].Width = 40;
            dgvTiposExamenes.Columns["Vie"].Width = 40;
            dgvTiposExamenes.Columns["TurnoGeneral"].Width = 80;
            // ...ajusta los valores a tu gusto...

            // EJEMPLO: Actualizar el estado del padre en el DataTable si todos los subtipos están desactivados
            // (esto debe llamarse ANTES de recargar la grilla)
            if (dtTiposExamenesOriginal != null)
            {
                foreach (DataRow padreRow in dtTiposExamenesOriginal.Rows)
                {
                    // Solo padres
                    if (padreRow.Table.Columns.Contains("Padre") && padreRow["Padre"].ToString() == "1")
                    {
                        string idPadre = padreRow["id"].ToString();
                        // Buscar subtipos de este padre
                        var subtipos = dtTiposExamenesOriginal.Select($"Padre = 0 AND IdPadre = '{idPadre}'");
                        // Si todos los subtipos están desactivados, desactivar el padre
                        if (subtipos.Length > 0 && subtipos.All(r => r.Table.Columns.Contains("EstadoEspecialidad") && !Convert.ToBoolean(r["EstadoEspecialidad"])))
                        {
                        }
                    }
                }
            }
        }

        public FrmAñadirEspecialidad()
        {
            InitializeComponent();

            // Inicialización defensiva para uso incrustado

            negocioTipoExamen = new CapaNegocioMepryl.TipoExamen();
            listaTiposExamenes = new List<Entidades.TipoExamen>();
            idMotivoConsultaSeleccionado = -1;
            idTipoExamenSeleccionado = "";

            // Activar autocompletar en el ComboBox de Subtipo
            cmbSubtipo.DropDownStyle = ComboBoxStyle.DropDown;
            cmbSubtipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSubtipo.AutoCompleteSource = AutoCompleteSource.ListItems;




            // ✅ Ocultar botón Guardar original (será llamado desde frmLocalidadNacionalidad)
            this.btnGuardar.Visible = false;

            // ✅ Ocultar texto de la pestaña Items por Secciones
            this.tabItemsSecciones.Text = "";

            // ✅ Configurar evento para cambiar color del tab activo
            this.tabControl.DrawItem += TabControl_DrawItem;

            // Eventos
            this.Load += FrmAñadirEspecialidad_Load;
            this.Shown += FrmAñadirEspecialidad_Shown; // Agregar evento Shown como fallback
            this.btnAgregarTipoExamen.Click += BtnAgregar_Click;
            this.btnEliminarTipoExamen.Click += BtnEliminarTipoExamen_Click;
            this.btnEliminarSubtipo.Click += BtnEliminarSubtipo_Click;
            this.btnAgregarSubtipo.Click += BtnAgregarSubtipo_Click;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.cmbMotivoConsulta.SelectedIndexChanged += CmbMotivoConsulta_SelectedIndexChanged;
            this.cmbTipoExamen.SelectedIndexChanged += CmbTipoExamen_SelectedIndexChanged;
            this.cmbSubtipo.SelectedIndexChanged += CmbSubtipo_SelectedIndexChanged;
            this.dgvTiposExamenes.SelectionChanged += DgvTiposExamenes_SelectionChanged;
            this.btnMotivodeConsulta.Click += button1_Click;
            this.button2.Click += button2_Click;
            this.dgvTiposExamenes.DataBindingComplete += DgvTiposExamenes_DataBindingComplete;
            // Eventos CellValueChanged y CurrentCellDirtyStateChanged ya están suscritos en Designer.cs

            this.dgvTiposExamenes.CellClick += DgvTiposExamenes_CellClickAccion;

            // Suscribir evento DropDown para recargar tipos de examen al desplegar el combo
            this.cmbTipoExamen.DropDown += cmbTipoExamen_DropDown;

            System.Diagnostics.Debug.WriteLine("✓ FrmAñadirEspecialidad Constructor completado");
        }

        private void cmbTipoExamen_DropDown(object sender, EventArgs e)
        {
            recargandoPorDropDown = true;
            // Recargar la lista de tipos de examen solo al desplegar
            CargarTiposExamen();
            recargandoPorDropDown = false;
        }

        private void DgvTiposExamenes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Obtén la lista de tipos temporales
            var tiposTemporales = listaTiposExamenes.Where(t => t.IdMotivoConsulta == idMotivoConsultaSeleccionado).ToList();
            foreach (DataGridViewRow row in dgvTiposExamenes.Rows)
            {
                string idReal = null;
                if (row.DataBoundItem is DataRowView drv && drv.DataView.Table.Columns.Contains("Id"))
                {
                    idReal = drv["Id"].ToString();
                }
                bool esNuevo = !string.IsNullOrEmpty(idReal) && tiposTemporales.Any(t => t.Id.ToString() == idReal);
                if (esNuevo)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
                }
            }

            // ✅ RESALTAR FILA DESACTIVADA - Ahora se hace en MostrarGestionMotivoTipoSubtipo
        }
        private void FrmAñadirEspecialidad_Load(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("► FrmAñadirEspecialidad_Load disparado");
                // ✅ OCULTAR BOTÓN GUARDAR PERMANENTEMENTE
                this.btnGuardar.Visible = false;
                this.btnGuardar.Enabled = false;
                InitializeForm();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("✗ Error en Load: " + ex.Message);
                MessageBox.Show("Error al cargar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Shown para contextos incrustados (más confiable)
        private void FrmAñadirEspecialidad_Shown(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("► FrmAñadirEspecialidad_Shown disparado");
                // ✅ OCULTAR BOTÓN GUARDAR PERMANENTEMENTE
                this.btnGuardar.Visible = false;
                this.btnGuardar.Enabled = false;
                InitializeForm();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("✗ Error en Shown: " + ex.Message);
                MessageBox.Show("Error al mostrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método centralizado de inicialización (ejecutado una sola vez)
        private bool formInitialized = false;
        private void InitializeForm()
        {
            if (formInitialized)
                return;

            System.Diagnostics.Debug.WriteLine("► InitializeForm: Cargando datos...");
            try
            {
                System.Diagnostics.Debug.WriteLine("✓ Motivos de consulta cargados");

                ConfigurarDataGridViews();
                System.Diagnostics.Debug.WriteLine("✓ DataGridViews configurados");

                // Dejar la grilla vacía hasta que el usuario seleccione un motivo
                dgvTiposExamenes.DataSource = null;
                dgvTiposExamenes.Rows.Clear();

                ActualizarEstadoControles();
                System.Diagnostics.Debug.WriteLine("✓ Estado de controles actualizado");

                formInitialized = true;
                System.Diagnostics.Debug.WriteLine("✓ Formulario inicializado correctamente");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("✗ Error en InitializeForm: " + ex.StackTrace);
                throw;
            }
        }

        // ✅ MÉTODO PÚBLICO: Para recargar datos cuando el formulario se muestra nuevamente (incrustado)
        public void RecargarDatos()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("► RecargarDatos: Recargando datos del formulario incrustado");
                CargarMotivosConsulta();
                ConfigurarDataGridViews();
                ;
                ActualizarEstadoControles();
                System.Diagnostics.Debug.WriteLine("✓ Datos recargados correctamente");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"✗ Error en RecargarDatos: {ex.Message}");
                MessageBox.Show($"Error al recargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// MÉTODO HELPER: Oculta la columna "id" en cualquier DataGridView
        /// DEBE LLAMARSE DESPUÉS de asignar DataSource
        /// </summary>
        private void OcultarColumnaID(DataGridView dgv)
        {
            try
            {
                if (dgv != null && dgv.Columns.Count > 0)
                {
                    if (dgv.Columns.Contains("id"))
                    {
                        dgv.Columns["id"].Visible = false;
                        System.Diagnostics.Debug.WriteLine($"✓ Columna 'id' oculta en {dgv.Name}");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"⚠️ Columna 'id' no encontrada en {dgv.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR ocultando ID: {ex.Message}");
            }
        }


        // ...existing code...
        private void CargarMotivosConsulta()
        {
            try
            {
                DataTable dt = negocioTipoExamen.cargarMotivosDeConsulta();
                if (dt != null && dt.Rows.Count > 0)
                {
                    // FILTRAR SOLO ACTIVOS si existe la columna "estado"
                    DataTable dtActivos = dt;
                    if (dt.Columns.Contains("estado"))
                    {
                        DataRow[] activos = dt.Select("estado = 1");
                        dtActivos = dt.Clone();
                        foreach (var row in activos)
                            dtActivos.ImportRow(row);
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        // Agregar opción "Todos" SOLO si estamos en el tab Gestionar
                        if (tabControl.SelectedTab == tabGestionar && !dt.AsEnumerable().Any(r => r.Field<string>("nombre") == "Todos"))
                        {
                            DataRow rowTodos = dt.NewRow();
                            rowTodos[dt.Columns[0].ColumnName] = 0; // ID = 0 para "Todos"
                            rowTodos[dt.Columns[1].ColumnName] = "TODOS";
                            dt.Rows.InsertAt(rowTodos, 0);
                        }
                        cmbMotivoConsulta.DataSource = dt;
                        cmbMotivoConsulta.DisplayMember = dt.Columns.Count > 1 ? dt.Columns[1].ColumnName : dt.Columns[0].ColumnName;
                        cmbMotivoConsulta.ValueMember = dt.Columns[0].ColumnName;
                        cmbMotivoConsulta.SelectedIndex = -1; // <-- Esto hace que aparezca vacío al inicio
                    }

                    if (cmbMotivoConsulta.SelectedIndex == -1 || cmbMotivoConsulta.Items.Count == 0)
                    {
                        dgvTiposExamenes.DataSource = null;
                        dgvTiposExamenes.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar motivos: " + ex.Message);
            }
        }

        // ...existing code...
        private void ConfigurarDataGridViews()
        {
            dgvTiposExamenes.Columns.Clear();
            dgvTiposExamenes.AutoGenerateColumns = false;
            // Permitir edición de checkboxes con un solo click
            dgvTiposExamenes.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvTiposExamenes.Columns.Add(new DataGridViewTextBoxColumn { Name = "id", HeaderText = "ID", DataPropertyName = "id" });
            // Columna oculta para el valor de Padre
            dgvTiposExamenes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Padre", HeaderText = "Padre", DataPropertyName = "Padre", Visible = true });
            dgvTiposExamenes.Columns.Add(new DataGridViewTextBoxColumn { Name = "MotivoConsulta", HeaderText = "Motivo de Consulta", DataPropertyName = "MotivoConsulta", ReadOnly = true, Width = 200 });
            // ✅ COLUMNA ESTADO MOTIVO - Al lado de Motivo de Consulta
            dgvTiposExamenes.Columns.Add(new DataGridViewCheckBoxColumn { Name = "EstadoMotivo", HeaderText = "Activo", DataPropertyName = "EstadoMotivo", TrueValue = true, FalseValue = false, Width = 90, ReadOnly = false });
            dgvTiposExamenes.Columns.Add(new DataGridViewTextBoxColumn { Name = "TipoExamen", HeaderText = "Tipo de Examen", DataPropertyName = "TipoExamen", ReadOnly = true, Width = 150 });
            // ✅ COLUMNA ACTIVO PADRE - Solo para tipos padre (al lado de Tipo de Examen)
            dgvTiposExamenes.Columns.Add(new DataGridViewTextBoxColumn { Name = "SubtipoExamen", HeaderText = "Subtipo", DataPropertyName = "SubtipoExamen", ReadOnly = true, Width = 100 });
            dgvTiposExamenes.Columns.Add(new DataGridViewTextBoxColumn { Name = "PrecioSubtipo", HeaderText = "Precio", DataPropertyName = "PrecioSubtipo", ReadOnly = true, Width = 100, DefaultCellStyle = { FormatProvider = new System.Globalization.CultureInfo("es-AR"), Format = "C2", NullValue = "$ 0,00" } });
            dgvTiposExamenes.Columns.Add(new DataGridViewCheckBoxColumn { Name = "EstadoEspecialidad", HeaderText = "Activo", DataPropertyName = "EstadoTipo", TrueValue = true, FalseValue = false, Width = 60, ReadOnly = false });

            // AGREGAR COLUMNAS VISUALES PARA LOS DÍAS DE LA SEMANA Y "TURNO GENERAL" AL FINAL
            dgvTiposExamenes.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Lun", HeaderText = "Lun", Width = 40, ReadOnly = false });
            dgvTiposExamenes.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Mar", HeaderText = "Mar", Width = 40, ReadOnly = false });
            dgvTiposExamenes.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Mie", HeaderText = "Mié", Width = 40, ReadOnly = false });
            dgvTiposExamenes.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Jue", HeaderText = "Jue", Width = 40, ReadOnly = false });
            dgvTiposExamenes.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Vie", HeaderText = "Vie", Width = 40, ReadOnly = false });
            var colTurnoGeneral = new DataGridViewCheckBoxColumn
            {
                Name = "TurnoGeneral",
                HeaderText = "TURNO GENERAL",
                Width = 80,
                ReadOnly = false
            };
            dgvTiposExamenes.Columns.Add(colTurnoGeneral);


            // ✅ NUEVA COLUMNA: ACCIONES
            DataGridViewButtonColumn colAcciones = new DataGridViewButtonColumn
            {
                Name = "Acciones",
                HeaderText = "Acciones",
                Text = "✎ Editar",
                UseColumnTextForButtonValue = true,
                Width = 90,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(0, 120, 215),  // Azul Windows 10
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            // ✅ AGREGADO: Eliminar borde del botón
            colAcciones.FlatStyle = FlatStyle.Flat;

            dgvTiposExamenes.Columns.Add(colAcciones);


            // Estilo visual para el encabezado de "TURNO GENERAL"
            dgvTiposExamenes.EnableHeadersVisualStyles = false;
            dgvTiposExamenes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvTiposExamenes.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvTiposExamenes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvTiposExamenes.Columns["TurnoGeneral"].HeaderCell.Style.ForeColor = Color.Red;
            dgvTiposExamenes.Columns["TurnoGeneral"].HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Bold);

            // ✅ NUEVO: Ocultar la columna ID aquí y siempre
            dgvTiposExamenes.Columns["id"].Visible = false;
            // Ocultar la columna de precios si existe
            if (dgvTiposExamenes.Columns.Contains("PrecioSubtipo"))
            {
                dgvTiposExamenes.Columns["PrecioSubtipo"].Visible = false;
            }
            // Ocultar columna Padre si existe
            if (dgvTiposExamenes.Columns.Contains("Padre"))
            {
                dgvTiposExamenes.Columns["Padre"].Visible = false;
            }


            // Ajustar FillWeight para que las columnas se vean proporcionadas
            if (dgvTiposExamenes.Columns.Contains("MotivoConsulta")) dgvTiposExamenes.Columns["MotivoConsulta"].FillWeight = 120;
            if (dgvTiposExamenes.Columns.Contains("EstadoMotivo")) dgvTiposExamenes.Columns["EstadoMotivo"].FillWeight = 40;
            if (dgvTiposExamenes.Columns.Contains("TipoExamen")) dgvTiposExamenes.Columns["TipoExamen"].FillWeight = 100;
            if (dgvTiposExamenes.Columns.Contains("SubtipoExamen")) dgvTiposExamenes.Columns["SubtipoExamen"].FillWeight = 100;
            if (dgvTiposExamenes.Columns.Contains("EstadoEspecialidad")) dgvTiposExamenes.Columns["EstadoEspecialidad"].FillWeight = 40;
            if (dgvTiposExamenes.Columns.Contains("Lun")) dgvTiposExamenes.Columns["Lun"].FillWeight = 20;
            if (dgvTiposExamenes.Columns.Contains("Mar")) dgvTiposExamenes.Columns["Mar"].FillWeight = 20;
            if (dgvTiposExamenes.Columns.Contains("Mie")) dgvTiposExamenes.Columns["Mie"].FillWeight = 20;
            if (dgvTiposExamenes.Columns.Contains("Jue")) dgvTiposExamenes.Columns["Jue"].FillWeight = 20;
            if (dgvTiposExamenes.Columns.Contains("Vie")) dgvTiposExamenes.Columns["Vie"].FillWeight = 20;
            if (dgvTiposExamenes.Columns.Contains("TurnoGeneral")) dgvTiposExamenes.Columns["TurnoGeneral"].FillWeight = 40;
            if (dgvTiposExamenes.Columns.Contains("Acciones")) dgvTiposExamenes.Columns["Acciones"].FillWeight = 50;



            // Columna Estado (CheckBox)
            System.Windows.Forms.DataGridViewCheckBoxColumn colEstado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colEstado.Name = "Estado";
            colEstado.HeaderText = "Estado";
            colEstado.Width = 60;
            colEstado.ReadOnly = false;
            colEstado.TrueValue = true;
            colEstado.FalseValue = false;



            // Limpiar grillas de secciones
            if (dgvClinico != null)
            {
                dgvClinico.Rows.Clear();
                dgvClinico.DataSource = null;
            }
            if (dgvLaboratorio != null)
            {
                dgvLaboratorio.Rows.Clear();
                dgvLaboratorio.DataSource = null;
            }
            if (dgvRadiologia != null)
            {
                dgvRadiologia.Rows.Clear();
                dgvRadiologia.DataSource = null;
            }
            if (dgvCardiologia != null)
            {
                dgvCardiologia.Rows.Clear();
                dgvCardiologia.DataSource = null;
            }
        }

        private void DgvTiposExamenes_CellClickAccion(object sender, DataGridViewCellEventArgs e)
        {
            // ✅ NUEVO: Detectar clic en columna "Acciones" para editar subtipos
            if (
                e.RowIndex >= 0 &&
                e.ColumnIndex >= 0 &&
                dgvTiposExamenes.Columns.Contains("Acciones") &&
                dgvTiposExamenes.Columns[e.ColumnIndex].Name == "Acciones"
            )
            {
                var row = dgvTiposExamenes.Rows[e.RowIndex];
                string idSubtipo = row.Cells["id"]?.Value?.ToString();
                string nombreSubtipo = row.Cells["SubtipoExamen"]?.Value?.ToString();

                if (string.IsNullOrEmpty(idSubtipo))
                {
                    MessageBox.Show("No se pudo obtener el ID del subtipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!Guid.TryParse(idSubtipo, out Guid guidSubtipo))
                {
                    MessageBox.Show("El ID del subtipo no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"[DEBUG] Abriendo ventana de edición para subtipo: {nombreSubtipo} (ID: {idSubtipo})");

                // ✅ NUEVO: Abrir formulario modal para editar el subtipo
                FrmEditarSubtipo frmEditar = new FrmEditarSubtipo(idSubtipo, nombreSubtipo);
                DialogResult resultado = frmEditar.ShowDialog(this);

                if (resultado == DialogResult.OK)
                {
                    // ✅ Recargar la grilla COMPLETA desde BD
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Cambios guardados en subtipo: {nombreSubtipo}. Refrescando grilla...");

                    // ✅ Si el filtro es "TODOS" (id==0), recargar TODO sin filtro
                    if (idMotivoConsultaSeleccionado == 0)
                    {
                        MostrarGestionMotivoTipoSubtipo(0); // Recargar todo
                    }
                    else
                    {
                        // Si hay un motivo específico seleccionado, recargar solo ese
                        MostrarGestionMotivoTipoSubtipo(idMotivoConsultaSeleccionado);
                    }
                }
            }
        }

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
        /// Llena las 4 grillas de secciones (Clínico, Laboratorio, Radiología, Cardiología)
        /// distribuyendo los items según su OrdenFormulario:
        /// - Clínico: 1, 12 (Examen Físico y Estudios Complementarios)
        /// - Laboratorio: 2, 3, 4, 5, 6, 7 (Laboratorio y análisis)
        /// - Radiología: 8, 9, 10, 11 (Radiografías y estudios por imagen)
        /// - Cardiología: 12 (Estudios del corazón)
        /// </summary>
        private void InitializarDataTablesSubtipo(Entidades.TipoExamen subtipo)
        {
            try
            {
                // Inicializar todos los DataTables con la estructura correcta
                // Estructura: [0]=Id, [1]=Codigo, [2]=Estado, [3]=Item, [4]=OrdenFormulario

                subtipo.Clinico = CrearDataTableVacio();
                subtipo.Hematologia = CrearDataTableVacio();
                subtipo.QuimicaHematica = CrearDataTableVacio();
                subtipo.Serologia = CrearDataTableVacio();
                subtipo.PerfilLipidico = CrearDataTableVacio();
                subtipo.Bacteriologia = CrearDataTableVacio();
                subtipo.Orina = CrearDataTableVacio();
                subtipo.LaboralesBasicas = CrearDataTableVacio();
                subtipo.CraneoYMSuperior = CrearDataTableVacio();
                subtipo.TroncoYPelvis = CrearDataTableVacio();
                subtipo.MiembroInferior = CrearDataTableVacio();
                subtipo.EstComplementarios = CrearDataTableVacio();

                System.Diagnostics.Debug.WriteLine("✅ DataTables del subtipo inicializados");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en InitializarDataTablesSubtipo: {ex.Message}");
            }
        }

        /// <summary>
        /// Crea un DataTable vacío con la estructura esperada: [0]=Id, [1]=Codigo, [2]=Estado, [3]=Item, [4]=OrdenFormulario
        /// </summary>
        private DataTable CrearDataTableVacio()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(Guid));
            dt.Columns.Add("Codigo", typeof(int));
            dt.Columns.Add("Estado", typeof(bool));
            dt.Columns.Add("Item", typeof(string));
            dt.Columns.Add("OrdenFormulario", typeof(int));
            return dt;
        }



        private void btnGuardarEstado_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTiposExamenes.Rows)
            {
                if (row.Cells["IdEspecialidad"].Value != null)
                {
                    string idEspecialidad = row.Cells["IdEspecialidad"].Value.ToString();
                    bool estado = Convert.ToBoolean(row.Cells["EstadoEspecialidad"].Value ?? true);
                    negocioTipoExamen.ActualizarEstadoEspecialidad(idEspecialidad, estado ? 1 : 0);
                }
            }
            MessageBox.Show("Estados actualizados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        private void ActualizarEstadoControles()
        {
            // TipoExamen siempre está habilitado si hay motivo seleccionado
            cmbTipoExamen.Enabled = idMotivoConsultaSeleccionado > 0;
            // Subtipo solo está habilitado si hay un TipoExamen seleccionado
            cmbSubtipo.Enabled = !string.IsNullOrEmpty(idTipoExamenSeleccionado);
        }

        private void CmbMotivoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (recargandoPorDropDown) return;

            // ✅ EVITAR EVENTOS DURANTE SINCRONIZACIÓN
            if (!permitirSincronizacion) return;

            try
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] >>>>> INICIO SELECCIÓN MOTIVO DE CONSULTA <<<<<");
                if (cmbMotivoConsulta.SelectedValue != null && int.TryParse(cmbMotivoConsulta.SelectedValue.ToString(), out int id))
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Motivo seleccionado: id={id}, texto={cmbMotivoConsulta.Text}");
                    idMotivoConsultaSeleccionado = id;
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Cargando grilla de tipos de examen para motivo id={id}");
                    CargarTiposExamen();
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Grilla cargada. Limpiando subtipo y actualizando controles.");
                    LimpiarSubtipo();
                    ActualizarEstadoControles();
                    // Mostrar todos los tipos y subtipos SOLO si se seleccionó 'Todos' (id==0)
                    if (idMotivoConsultaSeleccionado == 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] Motivo seleccionado es 'Todos', mostrando todos los tipos y subtipos");
                        MostrarGestionMotivoTipoSubtipo(0);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] Mostrando gestión para motivo id={idMotivoConsultaSeleccionado}");
                        MostrarGestionMotivoTipoSubtipo(idMotivoConsultaSeleccionado);
                    }
                    // Puedes comentar o eliminar la siguiente línea si ya no quieres la vista anterior:
                    // MostrarTiposYSubtiposPorMotivo();

                    // ✅ SINCRONIZACIÓN BIDIRECCIONAL: Disparar evento si estamos permitiendo sincronización
                    if (permitirSincronizacion)
                    {
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] Disparando evento CombosChanged: Motivo={id}, Tipo={ObtenerIdTipoExamenSeleccionado}, Subtipo={ObtenerIdSubtipoActualmenteCargado}");
                        CombosChanged?.Invoke(this, new CombosChangedEventArgs
                        {
                            IdMotivo = id,
                            IdTipo = ObtenerIdTipoExamenSeleccionado,
                            IdSubtipo = ObtenerIdSubtipoActualmenteCargado
                        });
                    }
                }
                System.Diagnostics.Debug.WriteLine($"[DEBUG] <<<<< FIN SELECCIÓN MOTIVO DE CONSULTA <<<<<");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Error en selección motivo de consulta: {ex.Message}");
            }
        }
        /// <summary>
        /// Muestra los Tipos de Examen y sus Subtipos relacionados al Motivo de Consulta seleccionado en el grid de gestión
        /// </summary>
        private void MostrarTiposYSubtiposPorMotivo()
        {
            try
            {
                dgvTiposExamenes.Rows.Clear();
                List<Entidades.TipoExamen> tipos;
                if (idMotivoConsultaSeleccionado == 0)
                {
                    // Mostrar todos los tipos padre
                    tipos = listaTiposExamenes.Where(t => t.Padre).ToList();
                }
                else
                {
                    // Filtrar tipos por motivo seleccionado
                    tipos = listaTiposExamenes.Where(t => t.Padre && t.IdMotivoConsulta == idMotivoConsultaSeleccionado).ToList();
                }
                foreach (var tipo in tipos)
                {
                    // Mostrar TipoExamen (Padre) con GUID completo
                    dgvTiposExamenes.Rows.Add(
                        tipo.Id.ToString(),            // id GUID completo
                        tipo.Descripcion,
                        "Tipo Examen",
                        tipo.PrecioBase
                    );
                    // Mostrar Subtipos (Hijos) relacionados con GUID completo
                    var subtipos = listaTiposExamenes.Where(s => !s.Padre && s.IdPadre == tipo.Id.ToString()).ToList();
                    foreach (var subtipo in subtipos)
                    {
                        dgvTiposExamenes.Rows.Add(
                            subtipo.Id.ToString(),     // id GUID completo
                            "   ↳ " + subtipo.Descripcion,
                            "Subtipo",
                            subtipo.PrecioBase
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar tipos y subtipos: " + ex.Message);
            }
        }

        private void CargarTiposExamenAgregar()
        {
            try
            {
                var selectedTipoId = cmbTipoExamen.SelectedValue?.ToString();

                if (idMotivoConsultaSeleccionado <= 0)
                {
                    cmbTipoExamen.DataSource = null;
                    cmbTipoExamen.Items.Clear();
                    cmbTipoExamen.SelectedIndex = -1;
                    return;
                }

                // Nuevo método de negocio: cargar solo tipos padre activos (sin filtrar por subtipos)
                DataTable dtBD = negocioTipoExamen.cargarTiposExamenPadreActivos(idMotivoConsultaSeleccionado.ToString());
                DataTable dtFinal = new DataTable();
                dtFinal.Columns.Add("id", typeof(string));
                dtFinal.Columns.Add("descripcion", typeof(string));

                if (dtBD != null && dtBD.Rows.Count > 0)
                {
                    foreach (DataRow tipoRow in dtBD.Rows)
                    {
                        int estado = 1;
                        if (tipoRow.Table.Columns.Contains("estado") && tipoRow["estado"] != DBNull.Value)
                        {
                            int.TryParse(tipoRow["estado"].ToString(), out estado);
                        }
                        if (estado == 1)
                        {
                            dtFinal.Rows.Add(tipoRow["id"].ToString(), tipoRow["descripcion"].ToString());
                        }
                    }
                }

                cmbTipoExamen.DataSource = dtFinal;
                cmbTipoExamen.DisplayMember = "descripcion";
                cmbTipoExamen.ValueMember = "id";

                if (!string.IsNullOrEmpty(selectedTipoId) && dtFinal.AsEnumerable().Any(r => r.Field<string>("id") == selectedTipoId))
                {
                    cmbTipoExamen.SelectedValue = selectedTipoId;
                }
                else
                {
                    cmbTipoExamen.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de examen (agregar): " + ex.Message);
                cmbTipoExamen.DataSource = null;
                cmbTipoExamen.Items.Clear();
                cmbTipoExamen.SelectedIndex = -1;
            }
        }
        private void CargarTiposExamen()
        {
            try
            {
                var selectedTipoId = cmbTipoExamen.SelectedValue?.ToString();

                if (idMotivoConsultaSeleccionado <= 0)
                {
                    cmbTipoExamen.DataSource = null;
                    cmbTipoExamen.Items.Clear();
                    cmbTipoExamen.SelectedIndex = -1;
                    return;
                }

                DataTable dtBD = negocioTipoExamen.cargarTiposDeExamenPadreConSubtiposActivos(idMotivoConsultaSeleccionado.ToString());
                DataTable dtFinal = new DataTable();
                dtFinal.Columns.Add("id", typeof(string));
                dtFinal.Columns.Add("descripcion", typeof(string));

                if (dtBD != null && dtBD.Rows.Count > 0)
                {
                    foreach (DataRow tipoRow in dtBD.Rows)
                    {
                        int estado = 1;
                        if (tipoRow.Table.Columns.Contains("estado") && tipoRow["estado"] != DBNull.Value)
                        {
                            int.TryParse(tipoRow["estado"].ToString(), out estado);
                        }
                        if (estado == 1)
                        {
                            dtFinal.Rows.Add(tipoRow["id"].ToString(), tipoRow["descripcion"].ToString());
                        }
                    }
                }

                cmbTipoExamen.DataSource = dtFinal;
                cmbTipoExamen.DisplayMember = "descripcion";
                cmbTipoExamen.ValueMember = "id";

                // Si el tipo padre sigue activo pero el subtipo seleccionado ya no existe, selecciona el padre
                if (!string.IsNullOrEmpty(selectedTipoId) && dtFinal.AsEnumerable().Any(r => r.Field<string>("id") == selectedTipoId))
                {
                    cmbTipoExamen.SelectedValue = selectedTipoId;
                }
                else
                {
                    // Buscar el padre del subtipo seleccionado en la grilla
                    string idPadreBD = null;
                    if (dgvTiposExamenes.CurrentRow != null && dgvTiposExamenes.CurrentRow.Cells["id"].Value != null)
                    {
                        string idSubtipoActual = dgvTiposExamenes.CurrentRow.Cells["id"].Value.ToString();
                        // Consultar a la base de datos el padre de este subtipo SOLO si tiene subtipos activos
                        idPadreBD = negocioTipoExamen.ObtenerIdPadreDeSubtipo(idSubtipoActual);

                        // Verifica si el padre sigue activo y tiene subtipos activos
                        if (!string.IsNullOrEmpty(idPadreBD) && dtFinal.AsEnumerable().Any(r => r.Field<string>("id") == idPadreBD))
                        {
                            cmbTipoExamen.SelectedValue = idPadreBD;
                        }
                        else
                        {
                            cmbTipoExamen.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        cmbTipoExamen.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de examen: " + ex.Message);
                cmbTipoExamen.DataSource = null;
                cmbTipoExamen.Items.Clear();
                cmbTipoExamen.SelectedIndex = -1;
            }
        }
        private void CargarSubtipos()
        {
            try
            {
                permitirEventoSubtipo = false;
                if (string.IsNullOrEmpty(idTipoExamenSeleccionado))
                {
                    cmbSubtipo.DataSource = null;
                    cmbSubtipo.Items.Clear();
                    cmbSubtipo.SelectedIndex = -1; // <-- Vacío al inicio
                    return;
                }

                var subtiposTemporales = listaTiposExamenes.Where(t => !t.Padre && t.IdPadre == idTipoExamenSeleccionado).ToList();

                if (subtiposTemporales.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("id", typeof(string));
                    dt.Columns.Add("descripcion", typeof(string));

                    foreach (var subtipo in subtiposTemporales)
                    {
                        dt.Rows.Add(subtipo.Id.ToString(), subtipo.Descripcion);
                    }

                    cmbSubtipo.DataSource = dt;
                    cmbSubtipo.DisplayMember = "descripcion";
                    cmbSubtipo.ValueMember = "id";
                    cmbSubtipo.SelectedIndex = -1; // <-- Vacío al inicio
                }
                else
                {
                    DataTable dt = negocioTipoExamen.cargarNivel2EspecialidadActivos(idTipoExamenSeleccionado);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        cmbSubtipo.DataSource = dt;
                        cmbSubtipo.DisplayMember = "descripcion";
                        cmbSubtipo.ValueMember = "id";
                        cmbSubtipo.SelectedIndex = -1; // <-- Vacío al inicio
                    }
                    else
                    {
                        cmbSubtipo.DataSource = null;
                        cmbSubtipo.Items.Clear();
                        cmbSubtipo.SelectedIndex = -1; // <-- Vacío al inicio
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar subtipos: " + ex.Message);
                cmbSubtipo.DataSource = null;
                cmbSubtipo.Items.Clear();
                cmbSubtipo.SelectedIndex = -1; // <-- Vacío al inicio
            }
            finally
            {
                permitirEventoSubtipo = true;
            }
        }

        // Detecta si hay cualquier cambio pendiente (activar o desactivar)
        public bool HayCambiosPendientes()
        {
            return subtiposPendientesCambio.Count > 0;
        }

        // Llamar este método después de guardar exitosamente para limpiar la lista de cambios
        private void LimpiarCambiosPendientes()
        {
            subtiposPendientesCambio.Clear();
        }

        private void CmbTipoExamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ignorarEventoTipoExamen)
                return;
            // Evitar ejecución si no hay selección válida
            if (cmbTipoExamen.SelectedIndex == -1 || cmbTipoExamen.SelectedValue == null)
                return;
            // Evitar filtrado si solo se desplegó el combo
            if (recargandoPorDropDown)
                return;
            try
            {
                if (dtTiposExamenesOriginal != null)
                {
                    idTipoExamenSeleccionado = cmbTipoExamen.SelectedValue.ToString();

                    if (!string.IsNullOrEmpty(idTipoExamenSeleccionado))
                    {
                        DataView dv = new DataView(dtTiposExamenesOriginal);
                        dv.RowFilter = $"TipoExamen = '{cmbTipoExamen.Text.Replace("'", "''")}'";
                        if (dv.Count > 0)
                        {
                            dgvTiposExamenes.DataSource = dv.ToTable();
                        }
                        else
                        {
                            dgvTiposExamenes.DataSource = dtTiposExamenesOriginal.Clone();
                        }
                        OcultarColumnaID(dgvTiposExamenes);
                        CargarSubtipos();
                    }



                    else
                    {
                        idTipoExamenSeleccionado = "";
                        LimpiarSubtipo();

                        // Mostrar todos los registros cuando no hay selección
                        if (dtTiposExamenesOriginal != null)
                            dgvTiposExamenes.DataSource = dtTiposExamenesOriginal.Copy();
                        OcultarColumnaID(dgvTiposExamenes);
                    }

                    // ✅ SINCRONIZACIÓN BIDIRECCIONAL: Disparar evento si estamos permitiendo sincronización
                    if (permitirSincronizacion)
                    {
                        System.Diagnostics.Debug.WriteLine($"[SYNC] Disparando evento CombosChanged: Motivo={idMotivoConsultaSeleccionado}, Tipo={idTipoExamenSeleccionado}, Subtipo={ObtenerIdSubtipoActualmenteCargado}");
                        CombosChanged?.Invoke(this, new CombosChangedEventArgs
                        {
                            IdMotivo = idMotivoConsultaSeleccionado,
                            IdTipo = idTipoExamenSeleccionado,
                            IdSubtipo = ObtenerIdSubtipoActualmenteCargado
                        });
                    }
                }
                ActualizarEstadoControles();
            }
            catch { }
        }
        private void DebugColumnasDgvTiposExamenes()
        {
            if (dgvTiposExamenes == null || dgvTiposExamenes.Columns == null) return;
            var columnas = dgvTiposExamenes.Columns.Cast<DataGridViewColumn>().Select(c => c.Name).ToArray();
            System.Diagnostics.Debug.WriteLine($"[dgvTiposExamenes] Columnas: {string.Join(", ", columnas)}");
        }

        private void CmbSubtipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (recargandoPorDropDown) return;

            if (!permitirEventoSubtipo) return;
            try
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] CmbSubtipo_SelectedIndexChanged: disparado, SelectedIndex={cmbSubtipo.SelectedIndex}, SelectedValue={cmbSubtipo.SelectedValue ?? "NULL"}, Text={cmbSubtipo.Text}");

                // Guardar estado actual antes de cambiar
                if (!string.IsNullOrEmpty(idSubtipoActualmenteCargado))
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Guardando estado del subtipo anterior: {idSubtipoActualmenteCargado}");
                    GuardarEstadoItemsParaSubtipo(idSubtipoActualmenteCargado);
                }

                string idSubtipo = "";

                if (cmbSubtipo.SelectedIndex >= 0)
                {
                    if (cmbSubtipo.SelectedItem is DataRowView drv)
                    {
                        idSubtipo = drv["id"].ToString();
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] ID obtenido desde DataRowView: {idSubtipo}");
                    }
                    else if (cmbSubtipo.SelectedValue != null)
                    {
                        idSubtipo = cmbSubtipo.SelectedValue.ToString();
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] ID obtenido desde SelectedValue: {idSubtipo}");
                    }
                    else if (cmbSubtipo.DataSource is DataTable dt && cmbSubtipo.SelectedIndex >= 0 && cmbSubtipo.SelectedIndex < dt.Rows.Count)
                    {
                        idSubtipo = dt.Rows[cmbSubtipo.SelectedIndex]["id"].ToString();
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] ID obtenido desde DataSource directo: {idSubtipo}");
                    }
                }

                if (string.IsNullOrEmpty(idSubtipo))
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] ID SUBTIPO VACÍO");
                    idSubtipoActualmenteCargado = "";
                    btnEliminarSubtipo.Visible = false;
                    return;
                }

                if (!Guid.TryParse(idSubtipo, out Guid guidValidation))
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] ID NO ES GUID VÁLIDO: {idSubtipo}");
                    idSubtipoActualmenteCargado = "";
                    btnEliminarSubtipo.Visible = false;
                    return;
                }

                idSubtipoActualmenteCargado = idSubtipo;
                System.Diagnostics.Debug.WriteLine($"[DEBUG] idSubtipoActualmenteCargado = {idSubtipoActualmenteCargado}");

                if (dtTiposExamenesOriginal != null)
                {
                    DataView dv = new DataView(dtTiposExamenesOriginal);
                    dv.RowFilter = $"SubtipoExamen = '{cmbSubtipo.Text.Replace("'", "''")}'";
                    dgvTiposExamenes.DataSource = dv;
                    OcultarColumnaID(dgvTiposExamenes);
                }

                btnEliminarSubtipo.Visible = true;

                if (itemsPorSecciones != null)
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Cargando ItemsPorSeccion con ID: {idSubtipo}");
                    itemsPorSecciones.CargarItemsPorSeccion(idSubtipo);
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] ItemsPorSeccion cargado");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] itemsPorSecciones es NULL");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] ERROR: {ex.Message}\n{ex.StackTrace}");
                idSubtipoActualmenteCargado = "";
            }

            // Debug de visibilidad del botón btngravarespecialidades
            var btnGrabar = this.Controls.Find("btngravarespecialidades", true).FirstOrDefault() as Button;
            if (btnGrabar != null)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] CmbSubtipo_SelectedIndexChanged: btngravarespecialidades Visible={btnGrabar.Visible}");
            }

            if (permitirSincronizacion && cmbSubtipo.SelectedIndex >= 0)
            {
                System.Diagnostics.Debug.WriteLine($"[SYNC] Subtipo cambiado a {idSubtipoActualmenteCargado}, disparando evento CombosChanged: Motivo={idMotivoConsultaSeleccionado}, Tipo={idTipoExamenSeleccionado}, Subtipo={idSubtipoActualmenteCargado}");
                CombosChanged?.Invoke(this, new CombosChangedEventArgs
                {
                    IdMotivo = idMotivoConsultaSeleccionado,
                    IdTipo = idTipoExamenSeleccionado,
                    IdSubtipo = idSubtipoActualmenteCargado
                });
            }
        }


        // ...existing code...

        /// <summary>
        /// Actualiza todos los resúmenes del tabResumen mostrando los ítems marcados de cada sección.
        /// Llama a ActualizarResumenSeccion para cada DataGridView y su TextBox resumen.
        /// </summary>
        private void ActualizarTodosLosResumenes()
        {
            if (itemsPorSecciones != null)
            {
                // Clínico (solo una grilla)
                ActualizarResumenSeccion(itemsPorSecciones.DgvClinico, itemsPorSecciones.TxtResumenClinico);

                // Laboratorio (acumular de todas las grillas)
                var sbLab = new StringBuilder();
                AcumularResumen(itemsPorSecciones.DgvHematologia, sbLab);
                AcumularResumen(itemsPorSecciones.DgvQuimicaHematica, sbLab);
                AcumularResumen(itemsPorSecciones.DgvSerologia, sbLab);
                AcumularResumen(itemsPorSecciones.DgvPerfilLipidico, sbLab);
                AcumularResumen(itemsPorSecciones.DgvBacteriologia, sbLab);
                AcumularResumen(itemsPorSecciones.DgvOrina, sbLab);
                itemsPorSecciones.TxtResumenLaboratorio.Text = sbLab.ToString();

                // Rayos X (acumular de todas las grillas)
                var sbRx = new StringBuilder();
                AcumularResumen(itemsPorSecciones.DgvLaboralesBasicas, sbRx);
                AcumularResumen(itemsPorSecciones.DgvCraneoYMSuperior, sbRx);
                AcumularResumen(itemsPorSecciones.DgvTroncoYPelvis, sbRx);
                AcumularResumen(itemsPorSecciones.DgvMiembroInferior, sbRx);
                itemsPorSecciones.TxtResumenRx.Text = sbRx.ToString();

                // Estudios Complementarios (solo una grilla)
                ActualizarResumenSeccion(itemsPorSecciones.DgvEstComplementarios, itemsPorSecciones.TxtResumenEstCompl);

                DebugResumenSubtipo();
            }
        }

        // Nuevo método auxiliar:
        private void AcumularResumen(DataGridView dgv, StringBuilder sb)
        {
            if (dgv == null) return;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                bool estado = ConvertirABool(row.Cells[2].Value);
                string item = row.Cells[3].Value?.ToString() ?? "";
                if (estado && !string.IsNullOrEmpty(item))
                {
                    if (sb.Length > 0)
                        sb.Append(" - ");
                    sb.Append(item);
                }
            }
        }

        // ...existing code...
        // ✅ EVENTO: Cambio de pestaña en TabControl principal
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl.SelectedTab != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Tab seleccionado: {tabControl.SelectedTab.Name} - {tabControl.SelectedTab.Text}");

                    // Si el tab seleccionado es el de resumen (tabResumen o tabItemsSecciones), actualizar todos los resúmenes
                    if (tabControl.SelectedTab.Name == "tabResumen" || tabControl.SelectedTab.Name == "tabItemsSecciones" || tabControl.SelectedTab.Text.Contains("Resumen"))
                    {
                        ActualizarTodosLosResumenes();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en TabControl_SelectedIndexChanged: {ex.Message}");
            }
        }


        private bool ConvertirABooleano(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return false;

            if (bool.TryParse(valor.ToString(), out bool resultado))
                return resultado;

            if (int.TryParse(valor.ToString(), out int numResult))
                return numResult != 0;

            return false;
        }


        /// <summary>
        /// Actualiza un TextBox de resumen con los items marcados de una grilla
        /// </summary>
        private void ActualizarResumenSeccion(DataGridView dgv, TextBox tbResumen)
        {
            try
            {
                if (dgv == null || tbResumen == null)
                    return;

                StringBuilder sb = new StringBuilder();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    // Columna[2] = Estado (checkbox)
                    // Columna[3] = Item (descripción)
                    bool estado = ConvertirABool(row.Cells[2].Value);
                    string item = row.Cells[3].Value?.ToString() ?? "";

                    if (estado && !string.IsNullOrEmpty(item))
                    {
                        if (sb.Length > 0)
                            sb.Append(" - ");
                        sb.Append(item);
                    }
                }

                tbResumen.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar sección de resumen: " + ex.Message);
            }
        }



        private void LimpiarSubtipo()
        {
            cmbSubtipo.DataSource = null;
        }

        private void DgvTiposExamenes_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar diálogo para ingresar Descripción y Precio
                FrmAgregarTipoExamen dlg = new FrmAgregarTipoExamen();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string descripcion = dlg.Descripcion;
                    double precio = dlg.Precio;
                    bool estado = dlg.Estado;  // ✅ NUEVO: Capturar estado del checkbox

                    if (string.IsNullOrWhiteSpace(descripcion))
                    {
                        MessageBox.Show("Ingrese una descripción para el TipoExamen", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (idMotivoConsultaSeleccionado <= 0)
                    {
                        MessageBox.Show("Seleccione un motivo de consulta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Crear nueva entidad TIPOEXAMEN (Padre)
                    Entidades.TipoExamen nuevo = new Entidades.TipoExamen();
                    nuevo.Id = Guid.NewGuid();
                    nuevo.Descripcion = descripcion;
                    nuevo.IdMotivoConsulta = idMotivoConsultaSeleccionado;
                    nuevo.PrecioBase = precio;
                    nuevo.Padre = true;
                    nuevo.IdPadre = null;
                    nuevo.Codigo = GenerarCodigoTipo();
                    nuevo.Estado = estado ? 1 : 0;  // ✅ NUEVO: Asignar estado (1=Activo, 0=Inactivo)

                    // Inicializar DataTables
                    InitializarDataTablesSubtipo(nuevo);

                    // ✅ GUARDAR DIRECTAMENTE EN BASE DE DATOS
                    Entidades.Resultado res = negocioTipoExamen.crearTipoExamenPadre(nuevo);
                    if (res != null && res.Modo > 0)
                    {
                        listaTiposExamenes.Add(nuevo);
                        ActualizarGridTiposExamenes();
                        CargarTiposExamenAgregar();

                        // ✅ Seleccionar automáticamente el nuevo tipo creado
                        cmbTipoExamen.SelectedValue = nuevo.Id.ToString();

                        MessageBox.Show("TipoExamen agregado correctamente en Base de Datos", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // FORZAR CREACIÓN DE SUBTIPO
                        bool subtipoCreado = false;
                        while (!subtipoCreado)
                        {
                            // Reutilizar lógica de BtnAgregarSubtipo_Click
                            FrmAgregarTipoExamen dlgSubtipo = new FrmAgregarTipoExamen("Nuevo Subtipo");
                            var resultSubtipo = dlgSubtipo.ShowDialog();
                            if (resultSubtipo == DialogResult.OK)
                            {
                                string descripcionSubtipo = dlgSubtipo.Descripcion;
                                double precioSubtipo = dlgSubtipo.Precio;
                                bool estadoSubtipo = dlgSubtipo.Estado;

                                if (string.IsNullOrWhiteSpace(descripcionSubtipo))
                                {
                                    MessageBox.Show("Ingrese una descripción para el Subtipo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    continue;
                                }

                                Entidades.TipoExamen nuevoSubtipo = new Entidades.TipoExamen();
                                nuevoSubtipo.Id = Guid.NewGuid();
                                nuevoSubtipo.Descripcion = descripcionSubtipo;
                                nuevoSubtipo.IdMotivoConsulta = idMotivoConsultaSeleccionado;
                                nuevoSubtipo.PrecioBase = precioSubtipo;
                                nuevoSubtipo.Padre = false;
                                nuevoSubtipo.IdPadre = nuevo.Id.ToString();
                                nuevoSubtipo.Codigo = GenerarCodigoSubtipo();
                                nuevoSubtipo.Estado = estadoSubtipo ? 1 : 0;
                                // Si el motivo de consulta es 2 (laboral), setear tipo=1
                                if (idMotivoConsultaSeleccionado == 2)
                                    nuevoSubtipo.Tipo = 1;

                                Entidades.Resultado resSubtipo = negocioTipoExamen.crearTipoExamenHijo(nuevoSubtipo);
                                if (resSubtipo != null && resSubtipo.Modo > 0)
                                {
                                    MessageBox.Show("Subtipo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    SubtipoCreado?.Invoke(this, EventArgs.Empty);
                                    CargarSubtipos();
                                    cmbSubtipo.SelectedValue = nuevoSubtipo.Id.ToString();
                                    idSubtipoActualmenteCargado = nuevoSubtipo.Id.ToString();
                                    if (itemsPorSecciones != null)
                                        itemsPorSecciones.CargarItemsPorSeccion(nuevoSubtipo.Id.ToString());
                                    subtipoCreado = true;
                                }
                                else
                                {
                                    MessageBox.Show(resSubtipo?.Mensaje ?? "No se pudo guardar el Subtipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe crear al menos un Subtipo para continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(res?.Mensaje ?? "No se pudo guardar el TipoExamen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GenerarCodigoTipo()
        {
            // Generar un código único basado en timestamp
            long timestamp = DateTime.Now.Ticks;
            return (int)(timestamp % 100000);
        }

        private void ActualizarComboTiposExamen()
        {
            try
            {
                // Recargar el combo con los TipoExamenes actualizados
                CargarTiposExamen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar combo: " + ex.Message);
            }
        }

        private void BtnAgregarSubtipo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(idTipoExamenSeleccionado))
                {
                    MessageBox.Show("Seleccione un TipoExamen Padre", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FrmAgregarTipoExamen dlg = new FrmAgregarTipoExamen("Nuevo Subtipo");
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string descripcion = dlg.Descripcion.ToUpper();
                    double precio = dlg.Precio;
                    bool estado = dlg.Estado;

                    if (string.IsNullOrWhiteSpace(descripcion))
                    {
                        MessageBox.Show("Ingrese una descripción para el Subtipo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Entidades.TipoExamen nuevo = new Entidades.TipoExamen();
                    nuevo.Id = Guid.NewGuid();
                    nuevo.Descripcion = descripcion;
                    nuevo.IdMotivoConsulta = idMotivoConsultaSeleccionado;
                    nuevo.PrecioBase = precio;
                    nuevo.Padre = false;
                    nuevo.IdPadre = idTipoExamenSeleccionado;
                    nuevo.Codigo = GenerarCodigoSubtipo();
                    nuevo.Estado = estado ? 1 : 0;
                    // Si el motivo de consulta es 2 (laboral), setear tipo=1
                    if (idMotivoConsultaSeleccionado == 2)
                        nuevo.Tipo = 1;

                    System.Diagnostics.Debug.WriteLine($"► Creando subtipo: {nuevo.Descripcion} (ID: {nuevo.Id})");

                    // ✅ GUARDAR EN BASE DE DATOS
                    Entidades.Resultado res = negocioTipoExamen.crearTipoExamenHijo(nuevo);

                    if (res != null && res.Modo > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"✓ Subtipo creado exitosamente");
                        MessageBox.Show("Subtipo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // ✅ DISPARAR EVENTO SubtipoCreado PARA QUE APAREZCA EL BOTÓN GUARDAR
                        SubtipoCreado?.Invoke(this, EventArgs.Empty);

                        // ✅ CARGAR ITEMS DESDE BD INMEDIATAMENTE
                        System.Diagnostics.Debug.WriteLine($"► Cargando items desde BD para ID: {nuevo.Id}");
                        Entidades.TipoExamen entidadCargada = negocioTipoExamen.cargarEntidad(nuevo.Id.ToString());

                        if (entidadCargada != null)
                        {
                            System.Diagnostics.Debug.WriteLine($"✓ Entidad cargada con items");

                            // ✅ NO AGREGAR A listaTiposExamenes - YA FUE GUARDADO EN BD
                            // listaTiposExamenes.Add(entidadCargada);

                            // ✅ ACTUALIZAR COMBO DE SUBTIPOS
                            System.Diagnostics.Debug.WriteLine($"► Recargando combo de subtipos");
                            CargarSubtipos();

                            // ✅ SELECCIONAR EL SUBTIPO RECIÉN CREADO
                            System.Diagnostics.Debug.WriteLine($"► Seleccionando subtipo: {nuevo.Id}");
                            permitirEventoSubtipo = false;
                            cmbSubtipo.SelectedValue = nuevo.Id.ToString();
                            permitirEventoSubtipo = true;

                            // ✅ ASIGNAR DIRECTAMENTE idSubtipoActualmenteCargado (el evento no se disparó)
                            idSubtipoActualmenteCargado = nuevo.Id.ToString();
                            System.Diagnostics.Debug.WriteLine($"✓ idSubtipoActualmenteCargado = {idSubtipoActualmenteCargado}");

                            // ✅ CARGAR ITEMS EN GRILLAS
                            System.Diagnostics.Debug.WriteLine($"► Cargando items en grillas");

                            // ✅ CARGAR EN itemsPorSecciones (UserControl) - PERO NO NAVEGAR
                            System.Diagnostics.Debug.WriteLine($"► Cargando en ItemsPorSecciones");
                            if (itemsPorSecciones != null)
                            {
                                itemsPorSecciones.CargarItemsPorSeccion(nuevo.Id.ToString());
                                System.Diagnostics.Debug.WriteLine($"✓ ItemsPorSecciones actualizado");
                            }
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine($"❌ cargarEntidad devolvió null - intentando cargar items disponibles");
                            MessageBox.Show("Subtipo creado pero no se pudieron cargar los items.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"❌ Error creando subtipo: {res?.Mensaje}");
                        MessageBox.Show(res?.Mensaje ?? "No se pudo guardar el Subtipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Excepción: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Carga items disponibles desde BD y los asigna a los DataTables del subtipo temporal
        /// Se usa cuando se crea un nuevo subtipo para que tenga items disponibles
        /// </summary>
        private void CargarYAsignarItemsAlSubtipo(string idSubtipo, Entidades.TipoExamen subtipo)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"\n► Cargando items para subtipo temporal: {idSubtipo}");

                if (subtipo == null || !Guid.TryParse(idSubtipo, out Guid guidSubtipo))
                {
                    System.Diagnostics.Debug.WriteLine($"❌ Subtipo o ID inválido");
                    return;
                }

                // ✅ Cargar TODOS los items disponibles (no filtrados por subtipo)
                // Usar Guid.Empty para obtener todos los items
                DataTable dtTodos = negocioTipoExamen.CargarItemsDesdeEstudiosPorExamen(Guid.Empty);

                if (dtTodos == null || dtTodos.Rows.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine($"⚠️  No hay items en BD (tabla vacía)");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"✓ {dtTodos.Rows.Count} items cargados desde BD");

                // Mapeo de OrdenFormulario → DataTable del subtipo
                Dictionary<int, DataTable> mapeoOrden = new Dictionary<int, DataTable>
                {
                    { 1, subtipo.Clinico ?? CrearDataTableVacio() },
                    { 2, subtipo.Hematologia ?? CrearDataTableVacio() },
                    { 3, subtipo.QuimicaHematica ?? CrearDataTableVacio() },
                    { 4, subtipo.Serologia ?? CrearDataTableVacio() },
                    { 5, subtipo.PerfilLipidico ?? CrearDataTableVacio() },
                    { 6, subtipo.Bacteriologia ?? CrearDataTableVacio() },
                    { 7, subtipo.Orina ?? CrearDataTableVacio() },
                    { 8, subtipo.LaboralesBasicas ?? CrearDataTableVacio() },
                    { 9, subtipo.CraneoYMSuperior ?? CrearDataTableVacio() },
                    { 10, subtipo.TroncoYPelvis ?? CrearDataTableVacio() },
                    { 11, subtipo.MiembroInferior ?? CrearDataTableVacio() },
                    { 12, subtipo.EstComplementarios ?? CrearDataTableVacio() }
                };

                // Distribuir items a sus DataTables correspondientes
                int itemsDistribuidos = 0;
                foreach (DataRow r in dtTodos.Rows)
                {
                    try
                    {
                        int orden = 1;
                        if (r.Table.Columns.Contains("OrdenFormulario") && r["OrdenFormulario"] != DBNull.Value)
                        {
                            if (!int.TryParse(r["OrdenFormulario"].ToString(), out orden))
                                orden = 1;
                        }

                        if (!mapeoOrden.ContainsKey(orden))
                            orden = 1;

                        DataTable dtDestino = mapeoOrden[orden];

                        string codigo = r.Table.Columns.Contains("Codigo") ? r["Codigo"]?.ToString() ?? "" : "";
                        bool estado = ConvertirABooleano(r.Table.Columns.Contains("Estado") ? r["Estado"] : false);
                        string item = r.Table.Columns.Contains("Item") ? r["Item"]?.ToString() ?? "" : "";

                        if (!string.IsNullOrEmpty(item))
                        {
                            dtDestino.Rows.Add(Guid.NewGuid(), codigo, estado, item, orden);
                            itemsDistribuidos++;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"  ✗ Error en fila: {ex.Message}");
                    }
                }

                System.Diagnostics.Debug.WriteLine($"✓ {itemsDistribuidos} items distribuidos en DataTables");

                // Reasignar los DataTables al subtipo
                subtipo.Clinico = mapeoOrden[1];
                subtipo.Hematologia = mapeoOrden[2];
                subtipo.QuimicaHematica = mapeoOrden[3];
                subtipo.Serologia = mapeoOrden[4];
                subtipo.PerfilLipidico = mapeoOrden[5];
                subtipo.Bacteriologia = mapeoOrden[6];
                subtipo.Orina = mapeoOrden[7];
                subtipo.LaboralesBasicas = mapeoOrden[8];
                subtipo.CraneoYMSuperior = mapeoOrden[9];
                subtipo.TroncoYPelvis = mapeoOrden[10];
                subtipo.MiembroInferior = mapeoOrden[11];
                subtipo.EstComplementarios = mapeoOrden[12];

                System.Diagnostics.Debug.WriteLine($"✅ Items cargados correctamente en subtipo temporal");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ ERROR en CargarYAsignarItemsAlSubtipo: {ex.Message}");
            }
        }

        private int GenerarCodigoSubtipo()
        {
            // Generar un código único basado en timestamp + número aleatorio
            long timestamp = DateTime.Now.Ticks;
            Random rnd = new Random();
            int random = rnd.Next(1000, 9999);
            return (int)((timestamp % 100000) + random);
        }

        private void ActualizarGridTiposExamenes()
        {
            try
            {
                dgvTiposExamenes.DataSource = null;
                dgvTiposExamenes.Rows.Clear();

                string nombreMotivo = "";
                if (cmbMotivoConsulta.SelectedItem is DataRowView drv && drv.DataView.Table.Columns.Contains(cmbMotivoConsulta.DisplayMember))
                {
                    nombreMotivo = drv[cmbMotivoConsulta.DisplayMember].ToString();
                }
                else
                {
                    nombreMotivo = cmbMotivoConsulta.Text;
                }

                // Crear DataTable compatible con las columnas del DataGridView
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("MotivoConsulta", typeof(string));
                dt.Columns.Add("TipoExamen", typeof(string));
                dt.Columns.Add("SubtipoExamen", typeof(string));
                dt.Columns.Add("PrecioSubtipo", typeof(double));
                dt.Columns.Add("EstadoTipo", typeof(bool));

                foreach (var item in listaTiposExamenes)
                {
                    string guidStr = item.Id != null ? item.Id.ToString() : Guid.NewGuid().ToString();
                    dt.Rows.Add(
                        guidStr,
                        nombreMotivo,
                        item.Padre ? item.Descripcion : "",
                        item.Padre ? "" : item.Descripcion,
                        item.PrecioBase,
                        true
                    );
                }

                dgvTiposExamenes.DataSource = dt;
                OcultarColumnaID(dgvTiposExamenes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar grid: " + ex.Message);
            }
        }
        private void BtnEliminarTipoExamen_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoExamen.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un TipoExamen para eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string idTipoExamen = cmbTipoExamen.SelectedValue.ToString();

                // Validar que sea un GUID válido
                if (!Guid.TryParse(idTipoExamen, out Guid guidTipoExamen))
                {
                    MessageBox.Show("El ID del TipoExamen no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este TipoExamen de la base de datos? Se eliminarán también todos sus subtipos.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                    return;

                // Llamar al método de negocio para eliminar
                Entidades.Resultado res = negocioTipoExamen.eliminarTipoExamenPadre(guidTipoExamen.ToString());

                if (res != null && res.Modo > 0)
                {
                    MessageBox.Show("TipoExamen eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar el combo
                    CargarTiposExamen();
                    LimpiarSubtipo();
                    ActualizarEstadoControles();
                }
                else
                {
                    // Mostrar el mensaje específico de error desde la capa de datos
                    string mensajeError = (res != null && !string.IsNullOrEmpty(res.Mensaje))
                        ? res.Mensaje
                        : "No se pudo eliminar el TipoExamen";
                    MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarSubtipo_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSubtipo.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un Subtipo para eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string idSubtipo = cmbSubtipo.SelectedValue.ToString();

                // Validar que sea un GUID válido
                if (!Guid.TryParse(idSubtipo, out Guid guidSubtipo))
                {
                    MessageBox.Show("El ID del Subtipo no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este Subtipo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                    return;

                // Primero intentar eliminar de la lista temporal (si fue creado en esta sesión)
                var subtipoEnLista = listaTiposExamenes.FirstOrDefault(x => x.Id == guidSubtipo && !x.Padre);
                if (subtipoEnLista != null)
                {
                    listaTiposExamenes.Remove(subtipoEnLista);
                    ActualizarGridTiposExamenes();
                    MessageBox.Show("Subtipo eliminado de la lista temporal", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar combo y actualizar grid
                    CargarSubtipos();
                    LimpiarSubtipo();
                    ActualizarEstadoControles();
                    return;
                }

                // Si no está en la lista temporal, eliminarlo de base de datos
                Entidades.Resultado res = negocioTipoExamen.eliminarSubtipo(guidSubtipo.ToString());

                if (res != null && res.Modo > 0)
                {
                    MessageBox.Show("Subtipo eliminado de la base de datos correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar los subtipos
                    CargarSubtipos();
                    LimpiarSubtipo();
                    ActualizarEstadoControles();
                }
                else
                {
                    // Mostrar el mensaje específico de error desde la capa de datos
                    string mensajeError = (res != null && !string.IsNullOrEmpty(res.Mensaje))
                        ? res.Mensaje
                        : "No se pudo eliminar el Subtipo";
                    MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTiposExamenes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un elemento para eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este elemento?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                    return;

                int indice = dgvTiposExamenes.SelectedRows[0].Index;
                if (indice >= 0 && indice < listaTiposExamenes.Count)
                {
                    listaTiposExamenes.RemoveAt(indice);
                    ActualizarGridTiposExamenes();
                    MessageBox.Show("Elemento eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTiposExamenes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un elemento para editar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int indice = dgvTiposExamenes.SelectedRows[0].Index;
                if (indice >= 0 && indice < listaTiposExamenes.Count)
                {
                    var item = listaTiposExamenes[indice];

                    // Mostrar diálogo para editar
                    FrmAgregarTipoExamen dlg = new FrmAgregarTipoExamen();
                    dlg.Descripcion = item.Descripcion;
                    dlg.Precio = item.PrecioBase;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        item.Descripcion = dlg.Descripcion;
                        item.PrecioBase = dlg.Precio;
                        ActualizarGridTiposExamenes();
                        MessageBox.Show("Elemento actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarTodo_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaTiposExamenes.Count == 0)
                {
                    MessageBox.Show("No hay elementos para eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar TODOS los tipos y subtipos agregados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                    return;

                listaTiposExamenes.Clear();
                ActualizarGridTiposExamenes();
                CargarTiposExamen();
                LimpiarSubtipo();
                cmbSubtipo.SelectedIndex = -1;

                MessageBox.Show("Todos los elementos han sido eliminados", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método público para ejecutar el guardado desde un formulario externo (frmLocalidadNacionalidad)
        /// </summary>
        public void EjecutarGuardar()
        {
            BtnGuardar_Click(null, EventArgs.Empty);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemsPorSecciones == null || string.IsNullOrEmpty(idSubtipoActualmenteCargado))
                {
                    MessageBox.Show("Seleccione un subtipo para guardar.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                itemsPorSecciones.GuardarItems(idSubtipoActualmenteCargado);

                MessageBox.Show("Guardado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MostrarGestionMotivoTipoSubtipo(int idMotivo)
        {
            try
            {
                // ✅ RESETEAR COMBOS A ESTADO SIN FILTRO
                cmbTipoExamen.SelectedIndex = -1;
                cmbSubtipo.SelectedIndex = -1;

                // Guardar el id de la fila seleccionada antes de recargar
                string idSeleccionado = null;
                if (dgvTiposExamenes.CurrentRow != null && dgvTiposExamenes.CurrentRow.Cells["id"].Value != null)
                    idSeleccionado = dgvTiposExamenes.CurrentRow.Cells["id"].Value.ToString();

                // 1. Cargar desde la base de datos (ordenando el desactivado primero si existe)
                DataTable dt = negocioTipoExamen.ObtenerMotivoTipoSubtipoExamenPorMotivo(idMotivo, idSubtipoDesactivadoParaPintar);

                // 2. Crear una copia para agregar los temporales
                DataTable dtFinal = dt.Clone();
                if (!dtFinal.Columns.Contains("id"))
                    dtFinal.Columns.Add("id", typeof(string));
                if (!dtFinal.Columns.Contains("idMotivoConsulta"))
                    dtFinal.Columns.Add("idMotivoConsulta", typeof(int));
                // ✅ AGREGAR COLUMNA PARA ESTADO DEL MOTIVO
                if (!dtFinal.Columns.Contains("EstadoMotivo"))
                    dtFinal.Columns.Add("EstadoMotivo", typeof(bool));
                // ✅ AGREGAR COLUMNAS PARA DÍAS
                if (!dtFinal.Columns.Contains("lunes"))
                    dtFinal.Columns.Add("lunes", typeof(bool));
                if (!dtFinal.Columns.Contains("martes"))
                    dtFinal.Columns.Add("martes", typeof(bool));
                if (!dtFinal.Columns.Contains("miercoles"))
                    dtFinal.Columns.Add("miercoles", typeof(bool));
                if (!dtFinal.Columns.Contains("jueves"))
                    dtFinal.Columns.Add("jueves", typeof(bool));
                if (!dtFinal.Columns.Contains("viernes"))
                    dtFinal.Columns.Add("viernes", typeof(bool));
                // ✅ AGREGAR COLUMNA PARA PADRE
                if (!dtFinal.Columns.Contains("Padre"))
                    dtFinal.Columns.Add("Padre", typeof(int));

                foreach (DataRow row in dt.Rows)
                {
                    string id = null;
                    if (row.Table.Columns.Contains("IdSubtipo") && !string.IsNullOrEmpty(row["IdSubtipo"].ToString()))
                        id = row["IdSubtipo"].ToString();
                    else if (row.Table.Columns.Contains("IdTipo") && !string.IsNullOrEmpty(row["IdTipo"].ToString()))
                        id = row["IdTipo"].ToString();
                    else
                        id = Guid.NewGuid().ToString();

                    DataRow dr = dtFinal.NewRow();
                    foreach (DataColumn col in dt.Columns)
                    {
                        dr[col.ColumnName] = row[col.ColumnName];
                    }
                    dr["id"] = id;
                    // Asignar correctamente el valor de Padre
                    if (row.Table.Columns.Contains("PadreTipo") && !string.IsNullOrEmpty(row["TipoExamen"]?.ToString()))
                        dr["Padre"] = row["PadreTipo"];
                    else if (row.Table.Columns.Contains("PadreSubtipo") && !string.IsNullOrEmpty(row["SubtipoExamen"]?.ToString()))
                        dr["Padre"] = row["PadreSubtipo"];
                    else if (row.Table.Columns.Contains("Padre"))
                        dr["Padre"] = row["Padre"];
                    else
                    {
                        // Si es tipo padre, asigna 1; si es subtipo, asigna 0
                        bool esPadreRow = row.Table.Columns.Contains("TipoExamen") && !string.IsNullOrEmpty(row["TipoExamen"]?.ToString());
                        dr["Padre"] = esPadreRow ? 1 : 0;
                    }
                    // Copiar el valor de idMotivoConsulta si existe
                    if (row.Table.Columns.Contains("idMotivoConsulta"))
                        dr["idMotivoConsulta"] = row["idMotivoConsulta"];

                    // ✅ ASIGNAR ESTADO DEL MOTIVO DE CONSULTA
                    if (row.Table.Columns.Contains("EstadoMotivo") && row["EstadoMotivo"] != DBNull.Value)
                    {
                        object valEstadoMotivo = row["EstadoMotivo"];
                        if (valEstadoMotivo is int intValMotivo)
                            dr["EstadoMotivo"] = intValMotivo == 1;
                        else if (valEstadoMotivo is bool boolValMotivo)
                            dr["EstadoMotivo"] = boolValMotivo;
                        else
                            dr["EstadoMotivo"] = Convert.ToInt32(valEstadoMotivo) == 1;
                    }
                    else
                    {
                        dr["EstadoMotivo"] = true; // Por defecto activo
                    }

                    // ✅ ASIGNAR DÍAS (por defecto todos TRUE si vienen NULL)
                    dr["lunes"] = row.Table.Columns.Contains("lunes") && row["lunes"] != DBNull.Value ? Convert.ToBoolean(row["lunes"]) : true;
                    dr["martes"] = row.Table.Columns.Contains("martes") && row["martes"] != DBNull.Value ? Convert.ToBoolean(row["martes"]) : true;
                    dr["miercoles"] = row.Table.Columns.Contains("miercoles") && row["miercoles"] != DBNull.Value ? Convert.ToBoolean(row["miercoles"]) : true;
                    dr["jueves"] = row.Table.Columns.Contains("jueves") && row["jueves"] != DBNull.Value ? Convert.ToBoolean(row["jueves"]) : true;
                    dr["viernes"] = row.Table.Columns.Contains("viernes") && row["viernes"] != DBNull.Value ? Convert.ToBoolean(row["viernes"]) : true;

                    // ✅ ASIGNAR ACTIVO PADRE (solo si TipoExamen no está vacío, es decir, es un padre)
                    bool esPadre = row.Table.Columns.Contains("TipoExamen") && !string.IsNullOrEmpty(row["TipoExamen"]?.ToString());
                    if (esPadre)
                    {
                        if (row.Table.Columns.Contains("EstadoTipo") && row["EstadoTipo"] != DBNull.Value)
                        {
                            // ✅ Manejar todos los tipos posibles: int, string, bool
                            object valEstadoTipo = row["EstadoTipo"];
                            bool estadoPadreActivo = true; // Por defecto activo

                            if (valEstadoTipo is int intVal)
                                estadoPadreActivo = intVal == 1;
                            else if (valEstadoTipo is string strVal)
                                estadoPadreActivo = strVal == "1" || strVal.ToLower() == "true";
                            else if (valEstadoTipo is bool boolVal)
                                estadoPadreActivo = boolVal;
                        }
                    }

                    dtFinal.Rows.Add(dr);
                }

                // 3. Agregar solo los tipos y subtipos temporales (no guardados aún)
                var tiposTemporales = listaTiposExamenes
                    .Where(t => t.IdMotivoConsulta == idMotivo)
                    .Where(t => dtFinal.Select($"id = '{t.Id}'").Length == 0) // Solo si no está en BD
                    .ToList();

                foreach (var tipo in tiposTemporales)
                {
                    DataRow dr = dtFinal.NewRow();
                    dr["MotivoConsulta"] = cmbMotivoConsulta.Text;
                    dr["TipoExamen"] = tipo.Padre ? tipo.Descripcion : "";
                    dr["SubtipoExamen"] = tipo.Padre ? "" : tipo.Descripcion;
                    dr["PrecioSubtipo"] = tipo.PrecioBase;
                    dr["id"] = tipo.Id != null ? tipo.Id.ToString() : Guid.NewGuid().ToString();
                    // ✅ INICIALIZAR DÍAS PARA TEMPORALES
                    dr["lunes"] = true;
                    dr["martes"] = true;
                    dr["miercoles"] = true;
                    dr["jueves"] = true;
                    dr["viernes"] = true;
                    // ✅ INICIALIZAR ACTIVO PADRE PARA TEMPORALES (true si es padre)
                    // ✅ INICIALIZAR ESTADO MOTIVO PARA TEMPORALES (true por defecto)
                    dr["EstadoMotivo"] = true;
                    dr["idMotivoConsulta"] = idMotivoConsultaSeleccionado;
                    dtFinal.Rows.Add(dr);
                }

                // Conversión correcta del estado
                if (!dtFinal.Columns.Contains("EstadoTipo"))
                    dtFinal.Columns.Add("EstadoTipo", typeof(bool));
                foreach (DataRow row in dtFinal.Rows)
                {
                    object val = null;
                    // Si es subtipo, usa EstadoSubtipo; si es tipo, usa EstadoTipo
                    if (row.Table.Columns.Contains("EstadoSubtipo") && row["SubtipoExamen"] != DBNull.Value && !string.IsNullOrEmpty(row["SubtipoExamen"].ToString()))
                        val = row["EstadoSubtipo"];
                    else if (row.Table.Columns.Contains("EstadoTipo"))
                        val = row["EstadoTipo"];

                    string id = row.Table.Columns.Contains("id") ? row["id"].ToString() : "";

                    bool estado = false;
                    if (val != null && val != DBNull.Value)
                    {
                        if (val is int)
                            estado = ((int)val) == 1;
                        else if (val is string)
                            estado = val.ToString() == "1";
                        else if (val is bool)
                            estado = (bool)val;
                    }
                    row["EstadoTipo"] = estado;
                }


                // Refuerzo: asegurar que todas las filas tengan un GUID válido en 'id'
                foreach (DataRow row in dtFinal.Rows)
                {
                    if (string.IsNullOrEmpty(row["id"].ToString()))
                        row["id"] = Guid.NewGuid().ToString();
                }

                // Refuerzo: asegurar que dtFinal tenga todas las columnas esperadas
                string[] columnasEsperadas = new string[] { "id", "IdPadre", "TipoExamen", "SubtipoExamen", "EstadoTipo", "EstadoSubtipo", "EstadoMotivo", "idMotivoConsulta", "lunes", "martes", "miercoles", "jueves", "viernes" };
                foreach (var col in columnasEsperadas)
                {
                    if (!dtFinal.Columns.Contains(col))
                    {
                        // Tipo por defecto: string para ids/nombres, bool para estados/días
                        Type tipo = typeof(string);
                        if (col.StartsWith("Estado") || col == "lunes" || col == "martes" || col == "miercoles" || col == "jueves" || col == "viernes")
                            tipo = typeof(bool);
                        if (col == "idMotivoConsulta")
                            tipo = typeof(int);
                        dtFinal.Columns.Add(col, tipo);
                    }
                }

                // Usar bandera para ignorar eventos del grid durante la reasignación
                ignorandoEventosGrid = true;
                // === DEBUG: Mostrar columnas y valores de dtFinal antes de asignar al DataGridView ===
                System.Diagnostics.Debug.WriteLine("\n[DEBUG] Columnas de dtFinal antes de asignar a DataGridView:");
                foreach (DataColumn col in dtFinal.Columns)
                {
                    System.Diagnostics.Debug.Write($"{col.ColumnName} | ");
                }
                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Total filas: {dtFinal.Rows.Count}");
                for (int i = 0; i < dtFinal.Rows.Count; i++)
                {
                    var row = dtFinal.Rows[i];
                    string valores = string.Join(" | ", dtFinal.Columns.Cast<DataColumn>().Select(c => $"{c.ColumnName}: {row[c] ?? "<null>"}"));
                    System.Diagnostics.Debug.WriteLine($"Fila {i}: {valores}");
                }
                dtTiposExamenesOriginal = dtFinal.Copy();
                dgvTiposExamenes.DataSource = dtFinal;
                dgvTiposExamenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ignorandoEventosGrid = false;
                // OcultarColumnaID(dgvTiposExamenes);

                // Resaltar los elementos temporales nuevos
                foreach (DataGridViewRow row in dgvTiposExamenes.Rows)
                {
                    string idReal = null;
                    if (dtFinal.Columns.Contains("id"))
                    {
                        int idx = row.Index;
                        if (idx >= 0 && idx < dtFinal.Rows.Count)
                        {
                            idReal = dtFinal.Rows[idx]["id"].ToString();
                        }
                    }
                    bool esNuevo = false;
                    if (!string.IsNullOrEmpty(idReal))
                        esNuevo = tiposTemporales.Any(t => t.Id.ToString() == idReal);
                    if (esNuevo)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
                    }
                }
                // === AGREGAR COLUMNA CALCULADA 'Clasificacion' ===
                if (!dtFinal.Columns.Contains("Clasificacion"))
                    dtFinal.Columns.Add("Clasificacion", typeof(string));
                foreach (DataRow row in dtFinal.Rows)
                {
                    int padre = 0;
                    if (row.Table.Columns.Contains("Padre") && int.TryParse(row["Padre"].ToString(), out int p))
                        padre = p;
                    row["Clasificacion"] = padre == 1 ? "Tipo Examen" : "Subtipo";
                }

                // === PINTAR FILA DESACTIVADA AL FINAL ===
                bool filaDesactivadaPintada = false;
                if (!string.IsNullOrEmpty(idSubtipoDesactivadoParaPintar))
                {
                    foreach (DataGridViewRow row in dgvTiposExamenes.Rows)
                    {
                        string idFila = row.Cells["id"]?.Value?.ToString();
                        if (idFila == idSubtipoDesactivadoParaPintar)
                        {
                            // Azul Windows 10 (RGB: 0, 120, 215)
                            row.DefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
                            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 90, 160);
                            row.DefaultCellStyle.ForeColor = Color.White;
                            row.DefaultCellStyle.SelectionForeColor = Color.White;
                            // NO mover el scroll ni la selección
                            row.Selected = false;
                            dgvTiposExamenes.ClearSelection();
                            dgvTiposExamenes.CurrentCell = null;
                            filaDesactivadaPintada = true;
                            break;
                        }
                    }
                    idSubtipoDesactivadoParaPintar = null;
                }

                // Restaurar la selección de fila si existe (SOLO si no se pintó una fila desactivada)
                if (!filaDesactivadaPintada && !string.IsNullOrEmpty(idSeleccionado))
                {
                    bool seleccionada = false;
                    foreach (DataGridViewRow row in dgvTiposExamenes.Rows)
                    {
                        if (row.Cells["id"].Value != null && row.Cells["id"].Value.ToString() == idSeleccionado)
                        {
                            row.Selected = true;
                            foreach (DataGridViewColumn col in dgvTiposExamenes.Columns)
                            {
                                if (col.Visible && col.Index < row.Cells.Count)
                                {
                                    dgvTiposExamenes.CurrentCell = row.Cells[col.Index];
                                    break;
                                }
                            }
                            dgvTiposExamenes.FirstDisplayedScrollingRowIndex = row.Index;
                            seleccionada = true;
                            break;
                        }
                    }
                    if (!seleccionada && dgvTiposExamenes.Rows.Count > 0)
                    {
                        // Buscar y seleccionar el padre si existe
                        string idPadre = null;
                        // Buscar en dtFinal el IdPadre del subtipo desactivado
                        DataRow rowSubtipo = null;
                        foreach (DataRow dr in dtFinal.Rows)
                        {
                            if (dr.Table.Columns.Contains("id") && dr["id"].ToString() == idSeleccionado)
                            {
                                rowSubtipo = dr;
                                break;
                            }
                        }
                        if (rowSubtipo != null && rowSubtipo.Table.Columns.Contains("IdPadre") && rowSubtipo["IdPadre"] != DBNull.Value)
                        {
                            idPadre = rowSubtipo["IdPadre"].ToString();
                        }
                        if (!string.IsNullOrEmpty(idPadre))
                        {
                            foreach (DataGridViewRow row in dgvTiposExamenes.Rows)
                            {
                                if (row.Cells["id"].Value != null && row.Cells["id"].Value.ToString() == idPadre)
                                {
                                    row.Selected = true;
                                    foreach (DataGridViewColumn col in dgvTiposExamenes.Columns)
                                    {
                                        if (col.Visible && col.Index < row.Cells.Count)
                                        {
                                            dgvTiposExamenes.CurrentCell = row.Cells[col.Index];
                                            break;
                                        }
                                    }
                                    dgvTiposExamenes.FirstDisplayedScrollingRowIndex = row.Index;
                                    seleccionada = true;
                                    break;
                                }
                            }
                        }
                        if (!seleccionada)
                        {
                            dgvTiposExamenes.Rows[0].Selected = true;
                            foreach (DataGridViewColumn col in dgvTiposExamenes.Columns)
                            {
                                if (col.Visible && col.Index < dgvTiposExamenes.Rows[0].Cells.Count)
                                {
                                    dgvTiposExamenes.CurrentCell = dgvTiposExamenes.Rows[0].Cells[col.Index];
                                    break;
                                }
                            }
                            dgvTiposExamenes.FirstDisplayedScrollingRowIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar gestión: " + ex.Message);
            }
        }

        /// <summary>
        /// Guarda los items desde las grillas hacia un subtipo específico de la lista temporal.
        /// Se usa para auto-guardar items cuando se cambia de subtipo seleccionado.
        /// </summary>
        private void GuardarEstadoItemsParaSubtipo(string idSubtipo)
        {
            if (string.IsNullOrEmpty(idSubtipo) || !Guid.TryParse(idSubtipo, out Guid guidSubtipo))
                return;

            try
            {
                System.Diagnostics.Debug.WriteLine($"\n► GuardarEstadoItemsParaSubtipo: {idSubtipo}");

                // Buscar el subtipo en la lista temporal
                var subtipo = listaTiposExamenes.FirstOrDefault(t => t.Id.ToString() == idSubtipo);
                if (subtipo == null || subtipo.Clinico == null)
                {
                    System.Diagnostics.Debug.WriteLine($"⚠️ Subtipo no encontrado en listaTiposExamenes");
                    return;
                }

                // Mapeo: OrdenFormulario -> Propiedad DataTable
                Dictionary<int, DataTable> mapeoOrdenAPropiedad = new Dictionary<int, DataTable>
                {
                    { 1, subtipo.Clinico },
                    { 2, subtipo.Hematologia },
                    { 3, subtipo.QuimicaHematica },
                    { 4, subtipo.Serologia },
                    { 5, subtipo.PerfilLipidico },
                    { 6, subtipo.Bacteriologia },
                    { 7, subtipo.Orina },
                    { 8, subtipo.LaboralesBasicas },
                    { 9, subtipo.CraneoYMSuperior },
                    { 10, subtipo.TroncoYPelvis },
                    { 11, subtipo.MiembroInferior },
                    { 12, subtipo.EstComplementarios }
                };

                // Limpiar todos los DataTables (mantener estructura de columnas)
                int filasCleaneadas = 0;
                foreach (var dt in mapeoOrdenAPropiedad.Values)
                {
                    if (dt != null)
                    {
                        filasCleaneadas += dt.Rows.Count;
                        dt.Rows.Clear();
                    }
                }
                System.Diagnostics.Debug.WriteLine($"  Limpiadas {filasCleaneadas} filas previas");

                // Recolectar items de las 4 grillas principales
                List<DataGridView> grillas = new List<DataGridView> { dgvClinico, dgvLaboratorio, dgvRadiologia, dgvCardiologia };
                int itemsGuardados = 0;

                foreach (DataGridView dgv in grillas)
                {
                    if (dgv == null || dgv.Rows.Count == 0)
                        continue;

                    System.Diagnostics.Debug.WriteLine($"  Procesando grilla: {dgv.Name} ({dgv.Rows.Count} filas)");

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        try
                        {
                            int codigo = int.TryParse(row.Cells[0].Value?.ToString(), out int c) ? c : 0;
                            bool estado = Convert.ToBoolean(row.Cells[1].Value ?? false);
                            string item = row.Cells[2].Value?.ToString() ?? "";
                            int orden = int.TryParse(row.Cells[3].Value?.ToString(), out int o) ? o : 0;

                            // Obtener la propiedad DataTable correspondiente al orden
                            if (mapeoOrdenAPropiedad.TryGetValue(orden, out DataTable dtDestino))
                            {
                                if (dtDestino != null && estado)  // ✅ SOLO GUARDAR SI ESTADO = TRUE
                                {
                                    dtDestino.Rows.Add(Guid.NewGuid(), codigo, estado, item, orden);
                                    itemsGuardados++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"❌ Error procesando fila: {ex.Message}");
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine($"✅ Guardados {itemsGuardados} items TRUE en subtipo {idSubtipo}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ ERROR en GuardarEstadoItemsParaSubtipo: {ex.Message}");
            }
        }

        /// <summary>
        /// Guarda el estado (checked/unchecked) de todos los items desde las grillas de secciones
        /// en las propiedades DataTable del subtipo según su orden de formulario
        /// ESTRUCTURA ESPERADA: [0]=Id, [1]=Codigo, [2]=Estado, [3]=Item, [4]=OrdenFormulario
        /// </summary>
        private void GuardarEstadoItems()
        {
            try
            {
                // Obtener el último subtipo de la lista (es el que tiene los items cargados)
                var ultimoSubtipo = listaTiposExamenes.LastOrDefault(t => !t.Padre);
                if (ultimoSubtipo == null)
                    return;

                // ✅ RECOLECTAR ITEMS DESDE LAS GRILLAS DE SECCIONES Y DISTRIBUIRLAS
                // Mapeo: OrdenFormulario -> Propiedad DataTable
                Dictionary<int, DataTable> mapeoOrdenAPropiedad = new Dictionary<int, DataTable>
                {
                    { 1, ultimoSubtipo.Clinico },
                    { 2, ultimoSubtipo.Hematologia },
                    { 3, ultimoSubtipo.QuimicaHematica },
                    { 4, ultimoSubtipo.Serologia },
                    { 5, ultimoSubtipo.PerfilLipidico },
                    { 6, ultimoSubtipo.Bacteriologia },
                    { 7, ultimoSubtipo.Orina },
                    { 8, ultimoSubtipo.LaboralesBasicas },
                    { 9, ultimoSubtipo.CraneoYMSuperior },
                    { 10, ultimoSubtipo.TroncoYPelvis },
                    { 11, ultimoSubtipo.MiembroInferior },
                    { 12, ultimoSubtipo.EstComplementarios }
                };

                // Limpiar todos los DataTables primero (excepto estructura de columnas)
                foreach (var dt in mapeoOrdenAPropiedad.Values)
                {
                    dt.Rows.Clear();
                }

                // Recolectar items de las grillas
                List<DataGridView> grillas = new List<DataGridView> { dgvClinico, dgvLaboratorio, dgvRadiologia, dgvCardiologia };
                foreach (DataGridView dgv in grillas)
                {
                    if (dgv != null && dgv.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            try
                            {
                                int codigo = int.TryParse(row.Cells[0].Value?.ToString(), out int c) ? c : 0;
                                bool estado = Convert.ToBoolean(row.Cells[1].Value ?? false);
                                string item = row.Cells[2].Value?.ToString() ?? "";
                                int orden = int.TryParse(row.Cells[3].Value?.ToString(), out int o) ? o : 0;

                                // Obtener la propiedad DataTable correspondiente al orden
                                if (mapeoOrdenAPropiedad.TryGetValue(orden, out DataTable dtDestino))
                                {
                                    // Estructura: [0]=Id, [1]=Codigo, [2]=Estado, [3]=Item, [4]=OrdenFormulario
                                    dtDestino.Rows.Add(Guid.NewGuid(), codigo, estado, item, orden);
                                }
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine($"Error procesando fila: {ex.Message}");
                            }
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine("✅ GuardarEstadoItems completado exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar estado de items: " + ex.Message);
                System.Diagnostics.Debug.WriteLine($"ERROR en GuardarEstadoItems: {ex.Message}");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de cerrar sin guardar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        // Handler vacío para grpClinico.Enter
        private void grpClinico_Enter(object sender, EventArgs e)
        {
            // Puede dejarse vacío o agregar lógica si es necesario
        }

        // Handler para btnNuevoMotivo
        private void btnNuevoMotivo_Click(object sender, EventArgs e)
        {
            // TODO: Agregar lógica para nuevo motivo si es necesario
        }

        // Permite que el cambio de checkbox se registre inmediatamente al hacer click
        private void DgvTiposExamenes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTiposExamenes.IsCurrentCellDirty)
            {
                dgvTiposExamenes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Actualiza el estado en la lógica de negocio al cambiar el checkbox
        private void DgvTiposExamenes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Mostrar columnas actuales para depuración
            DebugColumnasDgvTiposExamenes();
            // Ignorar eventos si se está reasignando el DataSource
            if (ignorandoEventosGrid) return;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = dgvTiposExamenes.Rows[e.RowIndex];
                var idCell = row.Cells["id"];

                if (idCell == null || string.IsNullOrEmpty(idCell.Value?.ToString()))
                    return;

                string idSubtipo = idCell.Value.ToString();
                string columnName = dgvTiposExamenes.Columns[e.ColumnIndex].Name;

                // Debug para saber si se marca/desmarca el checkbox
                if (columnName == "EstadoEspecialidad")
                {
                    bool estadoSubtipo = Convert.ToBoolean(row.Cells["EstadoEspecialidad"]?.Value ?? false);
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Checkbox EstadoEspecialidad {(estadoSubtipo ? "MARCADO" : "DESMARCADO")} para id={idSubtipo} en fila {e.RowIndex}");
                    // Mostrar el contenido actual de subtiposPendientesCambio
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] subtiposPendientesCambio (antes de modificar):");
                    foreach (var item in subtiposPendientesCambio)
                    {
                        System.Diagnostics.Debug.WriteLine($"[DEBUG]   id={item.Key}, estado={item.Value}");
                    }
                }

                // ✅ SI CAMBIÓ ESTADO DEL MOTIVO DE CONSULTA
                if (columnName == "EstadoMotivo")
                {
                    // ✅ EVITAR RECURSIÓN Y MENSAJES DUPLICADOS
                    if (actualizandoEstadoMotivo) return;

                    bool estadoMotivo = Convert.ToBoolean(row.Cells["EstadoMotivo"]?.Value ?? false);

                    // Obtener el idMotivoConsulta de la fila
                    int idMotivoFila = 0;
                    if (row.DataBoundItem is DataRowView drv && drv.Row.Table.Columns.Contains("idMotivoConsulta"))
                    {
                        int.TryParse(drv["idMotivoConsulta"]?.ToString(), out idMotivoFila);
                    }

                    if (idMotivoFila > 0)
                    {
                        // ✅ Guardar nombre ANTES de cualquier operación que pueda cambiar el grid
                        string nombreMotivo = row.Cells["MotivoConsulta"]?.Value?.ToString() ?? "";

                        var resultado = negocioTipoExamen.ActualizarEstadoMotivoConsulta(idMotivoFila, estadoMotivo ? 1 : 0);

                        if (resultado.Modo > 0)
                        {
                            // ✅ ACTIVAR BANDERA antes de modificar otras celdas
                            actualizandoEstadoMotivo = true;
                            try
                            {
                                // ✅ Actualizar todas las filas con el mismo motivo en la grilla
                                foreach (DataGridViewRow filaMotivo in dgvTiposExamenes.Rows)
                                {
                                    if (filaMotivo.DataBoundItem is DataRowView drvFila &&
                                        drvFila.Row.Table.Columns.Contains("idMotivoConsulta"))
                                    {
                                        int idMotivoOtraFila = 0;
                                        int.TryParse(drvFila["idMotivoConsulta"]?.ToString(), out idMotivoOtraFila);
                                        if (idMotivoOtraFila == idMotivoFila && filaMotivo.Index != e.RowIndex)
                                        {
                                            filaMotivo.Cells["EstadoMotivo"].Value = estadoMotivo;
                                        }
                                    }
                                }

                                // ✅ RECARGAR COMBO para reflejar cambios en tiempo real
                                CargarMotivosConsulta();

                                // ✅ Mensaje claro según el estado (SOLO 1 VEZ)
                                if (estadoMotivo)
                                {
                                    // ✅ Seleccionar automáticamente el motivo activado en el combo
                                    cmbMotivoConsulta.SelectedValue = idMotivoFila;

                                    MessageBox.Show($"El motivo '{nombreMotivo}' fue ACTIVADO.", "Motivo Activado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    // ✅ Limpiar selección del combo cuando se desactiva
                                    cmbMotivoConsulta.SelectedIndex = -1;

                                    MessageBox.Show($"El motivo '{nombreMotivo}' fue DESACTIVADO.", "Motivo Desactivado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            finally
                            {
                                // ✅ DESACTIVAR BANDERA siempre, incluso si hay error
                                actualizandoEstadoMotivo = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    return;
                }


                // ✅ SI CAMBIÓ ESTADO DE SUBTIPO (Activo/Inactivo)
                if (columnName == "EstadoEspecialidad")
                {
                    bool estadoSubtipo = Convert.ToBoolean(row.Cells["EstadoEspecialidad"]?.Value ?? false);

                    // Guardar el id para pintarlo después si se desactiva
                    if (!estadoSubtipo)
                        idSubtipoDesactivadoParaPintar = idSubtipo;
                    else
                        idSubtipoDesactivadoParaPintar = null;

                    // Registrar el cambio en la lista temporal (si ya existe, actualizar)
                    var existente = subtiposPendientesCambio.FindIndex(x => x.Key == idSubtipo);
                    if (existente >= 0)
                        subtiposPendientesCambio[existente] = new KeyValuePair<string, bool>(idSubtipo, estadoSubtipo);
                    else
                        subtiposPendientesCambio.Add(new KeyValuePair<string, bool>(idSubtipo, estadoSubtipo));

                    // Debug extra para ver el conteo actualizado
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] subtiposPendientesCambio.Count ahora: {subtiposPendientesCambio.Count}");
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] subtiposPendientesCambio (después de modificar):");
                    foreach (var item in subtiposPendientesCambio)
                    {
                        System.Diagnostics.Debug.WriteLine($"[DEBUG]   id={item.Key}, estado={item.Value}");
                    }

                    // Si se activa el subtipo, activar el padre en BD y marcar visualmente el padre como activo en la grilla y ComboBox
                    if (estadoSubtipo)
                    {
                        // Activar el padre en la base de datos
                        var resultadoPadre = negocioTipoExamen.ActivarPadrePorSubtipo(idSubtipo);
                        string idPadre = null;
                        if (dgvTiposExamenes.Columns.Contains("IdPadre"))
                        {
                            int idxIdPadre = dgvTiposExamenes.Columns["IdPadre"].Index;
                            idPadre = row.Cells[idxIdPadre]?.Value?.ToString();
                        }
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] Al activar subtipo {idSubtipo}, idPadre obtenido: '{idPadre}'");
                        // Si no existe la columna, no hacer nada
                        if (!string.IsNullOrEmpty(idPadre))
                        {
                            foreach (DataGridViewRow padreRow in dgvTiposExamenes.Rows)
                            {
                                if (padreRow.Cells["id"]?.Value?.ToString() == idPadre)
                                {
                                    padreRow.Cells["EstadoEspecialidad"].Value = true;
                                    // Si el ComboBox de tipo examen está presente y el padre está en la lista, seleccionarlo
                                    if (cmbTipoExamen.DataSource is DataTable dtTipos)
                                    {
                                        var padreEnCombo = dtTipos.AsEnumerable().FirstOrDefault(r => r["id"].ToString() == idPadre);
                                        if (padreEnCombo != null)
                                            cmbTipoExamen.SelectedValue = idPadre;
                                    }
                                    // --- NUEVO: Agregar o actualizar el padre en la lista de pendientes ---
                                    var idxPadre = subtiposPendientesCambio.FindIndex(x => x.Key == idPadre);
                                    if (idxPadre >= 0)
                                        subtiposPendientesCambio[idxPadre] = new KeyValuePair<string, bool>(idPadre, true);
                                    else
                                        subtiposPendientesCambio.Add(new KeyValuePair<string, bool>(idPadre, true));
                                    // Debug extra para ver el conteo actualizado tras agregar padre
                                    System.Diagnostics.Debug.WriteLine($"[DEBUG] subtiposPendientesCambio.Count ahora: {subtiposPendientesCambio.Count}");
                                    break;
                                }
                            }
                        }
                    }
                    // Notificar a listeners externos para sincronizar la visibilidad del botón
                    CombosChanged?.Invoke(this, new CombosChangedEventArgs());
                    // Notificar a listeners externos para sincronizar la visibilidad del botón
                    CombosChanged?.Invoke(this, new CombosChangedEventArgs());
                }
                // ✅ SI CAMBIÓ ESTADO DE PADRE (ActivoPadre)
            }
        }

        private void btnEliminarSubtipo_Click_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Carga los datos del subtipo seleccionado en la pestaña pruena
        /// </summary>


        /// <summary>
        /// Agrega una sección con encabezado a una grilla
        /// Estructura esperada del DataTable: [0]=Id, [1]=Codigo, [2]=Estado, [3]=Item, [4]=OrdenFormulario
        /// </summary>
        private void AgregarSeccionConEncabezado(DataGridView grilla, string nombreSeccion, DataTable tabla)
        {
            try
            {
                if (grilla == null)
                {
                    System.Diagnostics.Debug.WriteLine($"❌ Grilla NULL");
                    return;
                }

                if (tabla == null || tabla.Rows.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine($"  ⚠️ {nombreSeccion}: VACÍO");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"  ✓ Agregando {nombreSeccion}: {tabla.Rows.Count} items");

                // Agregar encabezado de sección CONTRAÍDO (▶) con símbolo desplegable
                int filaEncabezadoIdx = grilla.Rows.Add("▶", nombreSeccion);
                DataGridViewRow filaEncabezado = grilla.Rows[filaEncabezadoIdx];
                filaEncabezado.ReadOnly = true;
                filaEncabezado.Height = 28;
                filaEncabezado.Tag = new Dictionary<string, object>
                {
                    { "esEncabezado", true },
                    { "nombreSeccion", nombreSeccion },
                    { "estaExpandido", false }, // Inicialmente contraído
                    { "indicesItems", new List<int>() }
                };

                // Estilo del encabezado: Azul oscuro con texto blanco
                Color colorEncabezado = Color.FromArgb(70, 130, 180); // Azul acero
                filaEncabezado.DefaultCellStyle.BackColor = colorEncabezado;
                filaEncabezado.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                filaEncabezado.DefaultCellStyle.ForeColor = Color.White;
                filaEncabezado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // ✅ CELDA [0]: SÍMBOLO DESPLEGABLE (▶ / ◀)
                filaEncabezado.Cells[0].ReadOnly = true;
                filaEncabezado.Cells[0].Style.BackColor = colorEncabezado;
                filaEncabezado.Cells[0].Style.ForeColor = Color.White;
                filaEncabezado.Cells[0].Style.Font = new Font("Arial", 12, FontStyle.Bold);
                filaEncabezado.Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                filaEncabezado.Cells[0].Style.SelectionBackColor = colorEncabezado;
                filaEncabezado.Cells[0].Style.SelectionForeColor = Color.White;

                // ✅ CELDA [1]: NOMBRE DE LA SECCIÓN
                filaEncabezado.Cells[1].ReadOnly = true;
                filaEncabezado.Cells[1].Style.BackColor = colorEncabezado;
                filaEncabezado.Cells[1].Style.ForeColor = Color.White;

                // Lista para guardar índices de items
                List<int> indicesItems = new List<int>();

                // Agregar items de la sección (OCULTOS inicialmente)
                foreach (DataRow fila in tabla.Rows)
                {
                    try
                    {
                        // Estructura: [0]=Id, [1]=Codigo, [2]=Estado, [3]=Item, [4]=OrdenFormulario
                        bool estado = fila.ItemArray.Length > 2 ? Convert.ToBoolean(fila.ItemArray[2]) : false;
                        string item = fila.ItemArray.Length > 3 ? fila.ItemArray[3].ToString() : "";

                        if (!string.IsNullOrEmpty(item))
                        {
                            int filaItemIdx = grilla.Rows.Add(estado, "  • " + item);
                            DataGridViewRow filaItem = grilla.Rows[filaItemIdx];
                            filaItem.DefaultCellStyle.BackColor = Color.White;
                            filaItem.DefaultCellStyle.ForeColor = Color.Black;
                            filaItem.DefaultCellStyle.Font = new Font("Arial", 9);
                            filaItem.Height = 22;
                            filaItem.Visible = false; // Inicialmente oculto

                            indicesItems.Add(filaItemIdx);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"    ✗ Error procesando item: {ex.Message}");
                    }
                }

                // Guardar índices de items en el encabezado
                var tagDict = filaEncabezado.Tag as Dictionary<string, object>;
                if (tagDict != null)
                {
                    tagDict["indicesItems"] = indicesItems;
                    filaEncabezado.Tag = tagDict;
                }

                // Agregar espaciador visual entre secciones
                int filaEspaciadorIdx = grilla.Rows.Add();
                DataGridViewRow filaEspaciador = grilla.Rows[filaEspaciadorIdx];
                filaEspaciador.ReadOnly = true;
                filaEspaciador.Height = 3;
                filaEspaciador.DefaultCellStyle.BackColor = Color.LightGray;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ ERROR en AgregarSeccionConEncabezado: {ex.Message}");
            }
        }

        /// <summary>
        /// Expande o contrae una sección de items según su estado actual
        /// </summary>
        private void AlternarSeccion(DataGridView grilla, int filaEncabezado)
        {
            try
            {
                if (filaEncabezado < 0 || filaEncabezado >= grilla.Rows.Count)
                    return;

                DataGridViewRow fila = grilla.Rows[filaEncabezado];
                var tagDict = fila.Tag as Dictionary<string, object>;

                if (tagDict == null || !(bool)tagDict["esEncabezado"])
                    return;

                bool estaExpandido = (bool)tagDict["estaExpandido"];
                List<int> indicesItems = tagDict["indicesItems"] as List<int> ?? new List<int>();
                string nombreSeccion = tagDict["nombreSeccion"].ToString();

                // Alternar visibilidad de items
                foreach (int indiceItem in indicesItems)
                {
                    if (indiceItem < grilla.Rows.Count)
                    {
                        grilla.Rows[indiceItem].Visible = !estaExpandido;
                    }
                }

                // ✅ ACTUALIZAR SÍMBOLO en la celda [0]: ▶ (contraído) ◀ (expandido)
                string nuevoSimbolo = estaExpandido ? "▶" : "◀";
                fila.Cells[0].Value = nuevoSimbolo;

                // Actualizar estado
                tagDict["estaExpandido"] = !estaExpandido;
                fila.Tag = tagDict;

                System.Diagnostics.Debug.WriteLine($"✓ Sección '{nombreSeccion}' {(!estaExpandido ? "expandida" : "contraída")}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en AlternarSeccion: {ex.Message}");
            }
        }

        /// <summary>
        /// Llena una grilla con los items de un DataTable (sin encabezados)
        /// Estructura esperada del DataTable: [0]=Id, [1]=Codigo, [2]=Estado, [3]=Item, [4]=OrdenFormulario
        /// </summary>
        private void LlenarGrillaPruena(DataGridView grilla, DataTable tabla)
        {
            try
            {
                if (grilla == null)
                {
                    System.Diagnostics.Debug.WriteLine($"❌ Grilla NULL");
                    return;
                }

                grilla.Rows.Clear();

                if (tabla == null || tabla.Rows.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine($"  ⚠️ Tabla vacía o NULL");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"  ✓ Llenando grilla con {tabla.Rows.Count} items");

                foreach (DataRow fila in tabla.Rows)
                {
                    try
                    {
                        // Estructura: [0]=Id, [1]=Codigo, [2]=Estado, [3]=Item, [4]=OrdenFormulario
                        bool estado = fila.ItemArray.Length > 2 ? Convert.ToBoolean(fila.ItemArray[2]) : false;
                        string item = fila.ItemArray.Length > 3 ? fila.ItemArray[3].ToString() : "";

                        if (!string.IsNullOrEmpty(item))
                        {
                            grilla.Rows.Add(estado, item);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"    ✗ Error procesando fila: {ex.Message}");
                    }
                }

                System.Diagnostics.Debug.WriteLine($"  ✓ Grilla poblada con {grilla.Rows.Count} filas");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ ERROR en LlenarGrillaPruena: {ex.Message}");
            }
        }

        /// <summary>
        /// Event handler para clicks en celdas de grillas desplegables
        /// Detecta clics en encabezados y alterna su estado
        /// </summary>
        private void DgvPruena_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= ((DataGridView)sender).Rows.Count)
                    return;

                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow fila = dgv.Rows[e.RowIndex];
                var tagDict = fila.Tag as Dictionary<string, object>;

                // Si es un encabezado desplegable, alternar
                if (tagDict != null && tagDict.ContainsKey("esEncabezado") && (bool)tagDict["esEncabezado"])
                {
                    AlternarSeccion(dgv, e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en DgvPruena_CellClick: {ex.Message}");
            }
        }

        /// <summary>
        /// Limpia todas las grillas de la pestaña pruena
        /// </summary>
        private void LimpiarGrillasPruena()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"► LimpiarGrillasPruena: Limpiando grillas de secciones");

                // Limpiar grillas de secciones
                List<DataGridView> grillas = new List<DataGridView> { dgvClinico, dgvLaboratorio, dgvRadiologia, dgvCardiologia };
                foreach (DataGridView dgv in grillas)
                {
                    if (dgv != null)
                    {
                        dgv.Rows.Clear();
                        dgv.DataSource = null;
                    }
                }

                System.Diagnostics.Debug.WriteLine($"✓ Grillas de secciones limpiadas");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR en LimpiarGrillasPruena: {ex.Message}");
            }
        }

        // ✅ NUEVO MÉTODO PÚBLICO: Cargar un subtipo específico desde frmLocalidadNacionalidad
        public void CargarSubtipoEnTab(int idMotivo, string idTipo, string idSubtipo)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"► CargarSubtipoEnTab: Motivo={idMotivo}, Tipo={idTipo}, Subtipo={idSubtipo}");

                // 1. Establecer el ID del motivo seleccionado
                idMotivoConsultaSeleccionado = idMotivo;

                // 2. Cargar los motivos primero
                CargarMotivosConsulta();

                // 3. Seleccionar el motivo en cmbMotivoConsulta
                if (cmbMotivoConsulta.Items.Count > 0)
                {
                    bool motivoEncontrado = false;
                    for (int i = 0; i < cmbMotivoConsulta.Items.Count; i++)
                    {
                        DataRowView drv = cmbMotivoConsulta.Items[i] as DataRowView;
                        if (drv != null && drv["id"].ToString() == idMotivo.ToString())
                        {
                            cmbMotivoConsulta.SelectedIndex = i;
                            motivoEncontrado = true;
                            System.Diagnostics.Debug.WriteLine($"✓ Motivo seleccionado: {drv["descripcion"].ToString()}");
                            break;
                        }
                    }
                    if (!motivoEncontrado)
                    {
                        System.Diagnostics.Debug.WriteLine($"⚠ Motivo {idMotivo} no encontrado");
                    }
                }

                // 4. Cargar tipos después de seleccionar motivo
                if (idMotivoConsultaSeleccionado > 0)
                {
                    CargarTiposExamen();

                    // 5. Seleccionar el tipo en cmbTipoExamen
                    if (!string.IsNullOrEmpty(idTipo) && cmbTipoExamen.Items.Count > 0)
                    {
                        bool tipoEncontrado = false;
                        for (int i = 0; i < cmbTipoExamen.Items.Count; i++)
                        {
                            DataRowView drv = cmbTipoExamen.Items[i] as DataRowView;
                            if (drv != null && drv["id"].ToString() == idTipo)
                            {
                                cmbTipoExamen.SelectedIndex = i;
                                idTipoExamenSeleccionado = idTipo;
                                tipoEncontrado = true;
                                System.Diagnostics.Debug.WriteLine($"✓ Tipo seleccionado: {drv["descripcion"].ToString()}");
                                break;
                            }
                        }
                        if (!tipoEncontrado)
                        {
                            System.Diagnostics.Debug.WriteLine($"⚠ Tipo {idTipo} no encontrado");
                        }
                    }

                    // 6. Cargar subtipos después de seleccionar tipo
                    if (!string.IsNullOrEmpty(idTipoExamenSeleccionado))
                    {
                        CargarSubtipos();

                        // 7. Seleccionar el subtipo en cmbSubtipo
                        if (!string.IsNullOrEmpty(idSubtipo) && cmbSubtipo.Items.Count > 0)
                        {
                            bool subtipoEncontrado = false;
                            for (int i = 0; i < cmbSubtipo.Items.Count; i++)
                            {
                                DataRowView drv = cmbSubtipo.Items[i] as DataRowView;
                                if (drv != null && drv["id"].ToString() == idSubtipo)
                                {
                                    cmbSubtipo.SelectedIndex = i;
                                    idSubtipoActualmenteCargado = idSubtipo;
                                    subtipoEncontrado = true;
                                    System.Diagnostics.Debug.WriteLine($"✓ Subtipo seleccionado: {drv["descripcion"].ToString()}");
                                    break;
                                }
                            }
                            if (!subtipoEncontrado)
                            {
                                System.Diagnostics.Debug.WriteLine($"⚠ Subtipo {idSubtipo} no encontrado");
                            }
                        }
                    }
                }

                // 8. Navegar al tab "Tipo de Examen Médico"
                TabControl tabCtrl = null;
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TabControl)
                    {
                        tabCtrl = ctrl as TabControl;
                        break;
                    }
                }

                if (tabCtrl != null)
                {
                    foreach (TabPage tab in tabCtrl.TabPages)
                    {
                        if (tab.Name == "tabAgregar" || tab.Text == "Tipo de Examen Médico")
                        {
                            tabCtrl.SelectedTab = tab;
                            System.Diagnostics.Debug.WriteLine("✅ Tab 'Tipo de Examen Médico' activado");
                            break;
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine("✅ CargarSubtipoEnTab completado");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Error en CargarSubtipoEnTab: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Error al cargar el subtipo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Método para dibujar el tab con colores personalizados
        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tab = tabControl.TabPages[e.Index];

            // Mismo color para todos los tabs (sin mostrar diferencia visual)
            Color tabColor = Color.FromArgb(240, 240, 240); // Gris uniforme

            e.Graphics.FillRectangle(new SolidBrush(tabColor), e.Bounds);

            // Dibujar el texto del tab
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(tab.Text, e.Font, Brushes.Black, e.Bounds, stringFormat);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbSubtipo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cmbMotivoConsulta_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Btndesactivar_Click(object sender, EventArgs e)
        {

        }


        private void Btndesactivar_Click_1(object sender, EventArgs e)
        {

            var confirm = MessageBox.Show("¿Desea desactivar todos los subtipos?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            System.Diagnostics.Debug.WriteLine($"[DEBUG] Desactivar: idMotivoConsultaSeleccionado={idMotivoConsultaSeleccionado}, idTipoExamenSeleccionado={idTipoExamenSeleccionado}");
            actualizandoEstadoMotivo = true;
            try
            {
                Entidades.Resultado resultado = null;
                string mensajeExito = "Todos los subtipos han sido desactivados correctamente.";
                string mensajeError = "No se pudieron desactivar los subtipos.";

                if (idMotivoConsultaSeleccionado == 0)
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG] Desactivando TODOS los subtipos globalmente");
                    resultado = negocioTipoExamen.DesactivarTodosLosSubtipos();
                    mensajeExito = "Todos los subtipos de todos los motivos han sido desactivados correctamente.";
                    mensajeError = "No se pudieron desactivar los subtipos de todos los motivos.";
                }
                else if (idMotivoConsultaSeleccionado > 0 && string.IsNullOrEmpty(idTipoExamenSeleccionado))
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Desactivando todos los subtipos para motivo: {idMotivoConsultaSeleccionado}");
                    resultado = negocioTipoExamen.DesactivarTodosLosSubtiposPorMotivo(idMotivoConsultaSeleccionado.ToString());
                    mensajeExito = $"Todos los subtipos del motivo seleccionado han sido desactivados correctamente.";
                    mensajeError = $"No se pudieron desactivar los subtipos del motivo seleccionado.";
                }
                else if (!string.IsNullOrEmpty(idTipoExamenSeleccionado))
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Desactivando todos los subtipos para motivo: {idMotivoConsultaSeleccionado} (por selección de tipo)");
                    resultado = negocioTipoExamen.DesactivarTodosLosSubtiposPorMotivo(idMotivoConsultaSeleccionado.ToString());
                    mensajeExito = $"Todos los subtipos del motivo y tipo seleccionado han sido desactivados correctamente.";
                    mensajeError = $"No se pudieron desactivar los subtipos del motivo y tipo seleccionado.";
                }

                System.Diagnostics.Debug.WriteLine($"[DEBUG] Resultado desactivar subtipos: {(resultado != null ? resultado.Modo.ToString() : "NULL")}");

                if (resultado != null && resultado.Modo > 0)
                {
                    MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            System.Diagnostics.Debug.WriteLine($"[DEBUG] Recargando combos y grilla tras desactivación para motivo: {idMotivoConsultaSeleccionado}");
                            CargarTiposExamenAgregar();
                            CargarSubtipos();
                            MostrarGestionMotivoTipoSubtipo(idMotivoConsultaSeleccionado);

                            if (cmbTipoExamen != null)
                            {
                                cmbTipoExamen.SelectedIndex = -1;
                                cmbTipoExamen.DataSource = null;
                                System.Diagnostics.Debug.WriteLine($"[DEBUG] ComboBox TipoExamen limpiado. SelectedIndex: {cmbTipoExamen.SelectedIndex}, SelectedValue: {cmbTipoExamen.SelectedValue}");
                                System.Diagnostics.Debug.WriteLine($"[DEBUG] ComboBox TipoExamen DataSource ahora es NULL.");
                            }
                        }
                        finally
                        {
                            actualizandoEstadoMotivo = false;
                        }
                    }));
                }
                else
                {
                    actualizandoEstadoMotivo = false;
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Error desactivando: {resultado?.Mensaje ?? mensajeError}");
                    MessageBox.Show(resultado?.Mensaje ?? mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                actualizandoEstadoMotivo = false;
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Excepción en desactivar: {ex.Message}");
                MessageBox.Show($"Error al desactivar subtipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Activar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Desea activar todos los tipos y subtipos de este motivo?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            System.Diagnostics.Debug.WriteLine($"[DEBUG] Activar: idMotivoConsultaSeleccionado={idMotivoConsultaSeleccionado}");
            actualizandoEstadoMotivo = true;
            try
            {
                Entidades.Resultado resultadoSubtipos = null;
                Entidades.Resultado resultadoTipos = null;
                string mensajeExito = "Todos los tipos y subtipos han sido activados correctamente.";
                string mensajeError = "No se pudieron activar los tipos y subtipos.";

                if (idMotivoConsultaSeleccionado == 0)
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG] Activando TODOS los subtipos globalmente");
                    resultadoSubtipos = negocioTipoExamen.ActivarTodosLosSubtiposGlobal();
                    mensajeExito = "Todos los tipos y subtipos de todos los motivos han sido activados correctamente.";
                    mensajeError = "No se pudieron activar los tipos y subtipos de todos los motivos.";
                    // Si tienes método para activar todos los tipos padre globalmente, agrégalo aquí
                    // resultadoTipos = negocioTipoExamen.ActivarTodosLosTiposGlobal();
                }
                else if (idMotivoConsultaSeleccionado > 0 && string.IsNullOrEmpty(idTipoExamenSeleccionado))
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Activando todos los tipos y subtipos para motivo: {idMotivoConsultaSeleccionado}");
                    resultadoSubtipos = negocioTipoExamen.ActivarTodosLosSubtiposPorMotivo(idMotivoConsultaSeleccionado.ToString());
                    mensajeExito = $"Todos los tipos y subtipos del motivo seleccionado han sido activados correctamente.";
                    mensajeError = $"No se pudieron activar los tipos y subtipos del motivo seleccionado.";
                }
                else if (!string.IsNullOrEmpty(idTipoExamenSeleccionado))
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Activando todos los tipos y subtipos para motivo: {idMotivoConsultaSeleccionado} (por selección de tipo)");
                    resultadoSubtipos = negocioTipoExamen.ActivarTodosLosSubtiposPorMotivo(idMotivoConsultaSeleccionado.ToString());
                    mensajeExito = $"Todos los tipos y subtipos del motivo y tipo seleccionado han sido activados correctamente.";
                    mensajeError = $"No se pudieron activar los tipos y subtipos del motivo y tipo seleccionado.";
                }

                bool exitoSubtipos = resultadoSubtipos != null && resultadoSubtipos.Modo > 0;
                bool exitoTipos = resultadoTipos == null || resultadoTipos.Modo > 0;

                System.Diagnostics.Debug.WriteLine($"[DEBUG] Resultado subtipos: {(resultadoSubtipos != null ? resultadoSubtipos.Modo.ToString() : "NULL")}");
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Resultado tipos: {(resultadoTipos != null ? resultadoTipos.Modo.ToString() : "NULL")}");

                if (exitoSubtipos && exitoTipos)
                {
                    MessageBox.Show(mensajeExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            System.Diagnostics.Debug.WriteLine($"[DEBUG] Recargando combos y grilla tras activación para motivo: {idMotivoConsultaSeleccionado}");
                            CargarTiposExamenAgregar();
                            CargarSubtipos();
                            MostrarGestionMotivoTipoSubtipo(idMotivoConsultaSeleccionado);
                        }
                        finally
                        {
                            actualizandoEstadoMotivo = false;
                        }
                    }));
                }
                else
                {
                    actualizandoEstadoMotivo = false;
                    if (resultadoSubtipos != null && resultadoSubtipos.Modo <= 0)
                        mensajeError = resultadoSubtipos.Mensaje;
                    else if (resultadoTipos != null && resultadoTipos.Modo <= 0)
                        mensajeError = resultadoTipos.Mensaje;
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Error activando: {mensajeError}");
                    MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                actualizandoEstadoMotivo = false;
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Excepción en activar: {ex.Message}");
                MessageBox.Show($"Error al activar tipos y subtipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ...existing code...

        // Método público para exportar el DataTable actual de la grilla
        public DataTable ExportarTiposExamenesDataTable()
        {
            return dtTiposExamenesOriginal?.Copy();
        }

        // Método público para importar el DataTable y refrescar la grilla
        public void ImportarTiposExamenesDataTable(DataTable dt)
        {
            if (dt != null)
            {
                dtTiposExamenesOriginal = dt.Copy();
                dgvTiposExamenes.DataSource = dtTiposExamenesOriginal;
                OcultarColumnaID(dgvTiposExamenes);
            }
        }

        // ...existing code...

        public void GuardarCambiosSubtipos()
        {
            System.Diagnostics.Debug.WriteLine($"[DEBUG] >>>>> INICIO GUARDAR CAMBIOS SUBTIPOS <<<<<");
            System.Diagnostics.Debug.WriteLine($"[DEBUG] subtiposPendientesCambio.Count={subtiposPendientesCambio.Count}");
            System.Diagnostics.Debug.WriteLine($"[DEBUG] subtiposPendientesCambio: contenido actual:");
            foreach (var item in subtiposPendientesCambio)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG]   id={item.Key}, estado={item.Value}");
            }
            try
            {
                int cambios = 0;
                var pendientesCopia = subtiposPendientesCambio.ToList();
                foreach (var kv in pendientesCopia)
                {
                    string idSubtipo = kv.Key;
                    bool nuevoEstado = kv.Value;
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Guardando subtipo: id={idSubtipo}, nuevoEstado={nuevoEstado}");
                    var resultado = negocioTipoExamen.ActualizarEstadoEspecialidad(idSubtipo, nuevoEstado ? 1 : 0);
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Resultado guardar subtipo id={idSubtipo}: modo={resultado.Modo}, mensaje={resultado.Mensaje}");
                    if (resultado.Modo > 0)
                    {
                        cambios++;
                        // Actualiza solo el checkbox en la grilla
                        foreach (DataGridViewRow row in dgvTiposExamenes.Rows)
                        {
                            if (row.Cells["id"].Value?.ToString() == idSubtipo)
                            {
                                row.Cells["EstadoEspecialidad"].Value = nuevoEstado;
                                break;
                            }
                        }
                        // Actualiza también el DataTable original para que el filtro funcione bien
                        if (dtTiposExamenesOriginal != null && dtTiposExamenesOriginal.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtTiposExamenesOriginal.Rows)
                            {
                                if (dr["id"].ToString() == idSubtipo)
                                {
                                    // Puede ser "EstadoTipo" o "EstadoEspecialidad" según tu estructura
                                    if (dr.Table.Columns.Contains("EstadoEspecialidad"))
                                        dr["EstadoEspecialidad"] = nuevoEstado;
                                    if (dr.Table.Columns.Contains("EstadoTipo"))
                                        dr["EstadoTipo"] = nuevoEstado;
                                    System.Diagnostics.Debug.WriteLine($"[DEBUG] DataTable actualizado para id={idSubtipo}: EstadoEspecialidad={nuevoEstado}");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] ERROR al guardar subtipo id={idSubtipo}: {resultado.Mensaje}");
                        MessageBox.Show($"Error al guardar el subtipo {idSubtipo}: {resultado.Mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Verifica si quedan subtipos activos
                bool haySubtiposActivos = dgvTiposExamenes.Rows
                    .Cast<DataGridViewRow>()
                    .Any(r => Convert.ToBoolean(r.Cells["EstadoEspecialidad"].Value ?? false));

                var btnGrabar = this.Controls.Find("btngravarespecialidades", true).FirstOrDefault() as Button;
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Cambios realizados: {cambios}");
                if (cambios > 0)
                {
                    MessageBox.Show($"Se guardaron {cambios} cambios de estado de subtipos.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (btnGrabar != null)
                    {
                        btnGrabar.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("No hay cambios de subtipos para guardar.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (btnGrabar != null)
                    {
                        btnGrabar.Visible = false;
                    }
                }
                subtiposPendientesCambio.Clear();
                System.Diagnostics.Debug.WriteLine($"[DEBUG] subtiposPendientesCambio limpiado tras guardar.");
                CombosChanged?.Invoke(this, new CombosChangedEventArgs());

                // Refrescar el ComboBox de subtipos para reflejar los cambios
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Refrescando ComboBox de subtipos tras guardar.");
                CargarSubtipos();

                // Solo si TODOS los subtipos están desactivados, recarga combos y grilla
                if (!haySubtiposActivos)
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Todos los subtipos desactivados. Recargando combos y grilla.");
                    CargarTiposExamen();
                    if (idMotivoConsultaSeleccionado > 0)
                        MostrarGestionMotivoTipoSubtipo(idMotivoConsultaSeleccionado);
                }
                System.Diagnostics.Debug.WriteLine($"[DEBUG] <<<<< FIN GUARDAR CAMBIOS SUBTIPOS <<<<<");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Error en GuardarCambiosSubtipos: {ex.Message}");
                MessageBox.Show($"Error al guardar cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ...existing code...

        // ...existing code...
        private void btngravarespecialidades_Click(object sender, EventArgs e)
        {
            // Forzar commit de celda activa antes de guardar
            if (dgvTiposExamenes != null && dgvTiposExamenes.IsCurrentCellDirty)
            {
                dgvTiposExamenes.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dgvTiposExamenes.EndEdit(); // <-- Esto asegura que el cambio se registre siempre
            }
            if (!HayCambiosPendientes())
            {
                MessageBox.Show("No hay cambios de subtipos para guardar.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var btnGrabar = this.Controls.Find("btngravarespecialidades", true).FirstOrDefault() as Button;
                if (btnGrabar != null)
                {
                    btnGrabar.Visible = false;
                }
                return;
            }
            GuardarCambiosSubtipos();
            LimpiarCambiosPendientes();
        }

        private void itemsPorSecciones_Load(object sender, EventArgs e)
        {

        }
    }
}
