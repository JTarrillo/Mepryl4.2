﻿using CapaNegocioMepryl;
using CapaPresentacionBase;
using Comunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
namespace CapaPresentacion
{
    public partial class frmTurnos : DevExpress.XtraEditors.XtraForm
    {
        string test;
        int prueba;
        private CapaNegocioMepryl.Turno turno;
        private CapaNegocioMepryl.TipoExamen tipoEx;
        private Entidades.TipoExamen tipoExamenActual;
        private int nroFila = 0;
        private int nroColumna = 1;
        //GRV - Ramírez Proceso consulta
        private bool blnConsultaExterna = false;
        private string strIDEmpresa = "", strIDPaciente = "";
        private string[] strUltRegistro = new string[18];
        private bool blnRecargaGrilla = false; //GRV
        private int intFilaSeleccionada = 0;
        //GRV - Modificado Variables globales
        private string strIdPaciente = "";
        private string strDNI = "";
        private string strApellido = "";
        private string strTextoPlantilla = "";

        //GRV - Modificado Mover Turnos
        private string strIdTurnoAntiguoMover = "";
        private string strIdTurnoNuevoMover = "";
        private string strTipoExamenMover = "";
        private bool blnActivoMoverTurno = false;

        public frmTurnos()
        {
            InitializeComponent();
            inicializar();
            this.Size = new System.Drawing.Size(1300, 700);
        }

        public frmTurnos(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            this.WindowState = FormWindowState.Maximized;
            inicializar();
            //            
        }

        private void inicializar()
        {
            tipoEx = new CapaNegocioMepryl.TipoExamen();
            turno = new CapaNegocioMepryl.Turno();
            inicializarDgv();
            cargarMotivoConsulta(); // Dispara cascada (solo carga combos, NO grilla)
            modoConsulta();
            cargarGrillaTurnosSinFiltro(); // Carga INICIAL de turnos (TODOS los tipos)
            cambiarEnabledBotonProximaFecha();
            blnConsultaExterna = false;
            LimpiarUltimoRegistroIngresado(); // GRV - Modificado
            BotonesRibbon('*');
        }

        private void inicializarDgv()
        {
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            agregarColumnaDgv("Id", "Id", false);
            agregarColumnaDgv("TipoPadre", "Tipo de Examen", true);        // ✅ NUEVO
            agregarColumnaDgv("SubTipoExamen", "Subtipo de Examen", true);
            agregarColumnaDgv("Medico", "Médico", false);
            agregarColumnaDgv("Fecha", "Fecha", true);
            agregarColumnaDgv("Hora", "Hora", true);
            agregarColumnaDgv("Nro", "Nro.", true);
            agregarColumnaDgv("IdPaciente", "IdPaciente", false);
            agregarColumnaDgv("Dni", "DNI", true);
            agregarColumnaDgv("Paciente", "Paciente", true);
            agregarColumnaDgv("Categoria", "Cat.", true);
            agregarColumnaDgv("Codigo", "Cód.", true);
            agregarColumnaDgv("Reserva", "Reserva", true);
            agregarColumnaDgv("Usuario", "Usuario", true);
            agregarColumnaDgv("Bloqueado", "Bloqueado", false);
            agregarColumnaDgv("Asistio", "Asistio", false);
            agregarColumnaDgv("Reservado", "Reservado", false);
            agregarColumnaDgv("IdTipoExamen", "IdTipoExamen", false);
            agregarColumnaDgv("Estado", "Estado", false);
            agregarColumnaDgv("IdPadre", "IdPadre", false);              // ✅ NUEVO
            agregarColumnaDgv("IdSubtipo", "IdSubtipo", false);

            // Permitir redimensionamiento en cada columna
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Resizable = DataGridViewTriState.True;
            }

            // Establecer anchos personalizados para columnas específicas
            dgv.Columns["TipoPadre"].Width = 180;
            dgv.Columns["SubTipoExamen"].Width = 230;  // Subtipo de Examen más ancho
            dgv.Columns["Paciente"].Width = 220;    // Paciente más ancho
            dgv.Columns["Fecha"].Width = 100;
            dgv.Columns["Hora"].Width = 70;
            dgv.Columns["DNI"].Width = 90;
        }

        private void agregarColumnaDgv(string nombreOculto, string nombreAMostrar, bool visible)
        {
            dgv.Columns.Add(nombreOculto, nombreAMostrar);
            dgv.Columns[nombreOculto].Visible = visible;
        }

        private void modoConsulta()
        {
            botAceptar.Visible = false;
            botCancelar.Visible = false;
            //panelLaboral.Enabled = false;  //GRV - Modificado para panel editable
            //panelPacientePreventiva.Enabled = false;   //GRV - Modificado para panel editable         
            pintarControlesPanelDeshabilitar();
            dgvLigaYClub.Enabled = false;
            dgv.Enabled = true;
            panelFechaTipoExamen.Enabled = true;
            panelHorario.Enabled = true;
            panelFiltro.Enabled = true;
            panelEstado.Enabled = true;
            cambiarVisibilidadBotonesPrincipales();

            botEditarExamenLaboral.Visible = false;
            botEditarExamenPreventiva.Visible = false;
            botEditarPacienteLaboral.Visible = false;
            botEditarPacientePreventiva.Visible = false;

            btnTogglePrecioPreventiva.Visible = false;
            btnTogglePrecioLaboral.Visible = false;

            btnMoverTurno.Visible = true;

            dgv.Focus();
        }

        private void cambiarEnabledBotonProximaFecha()
        {
            botProxFechaLibre.Enabled = false;
            if (cboTipoExamen.SelectedIndex > 0) { botProxFechaLibre.Enabled = true; }
        }

        /// <summary>
        /// CASCADA NIVEL 1: Cuando cambia el MotivoConsulta, carga los tipos de examen padre (Padre=1)
        /// </summary>
        private void cboMotivoConsulta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                // Si no hay selección, limpiar todo
                if (cboMotivoConsulta.SelectedIndex < 0 || cboMotivoConsulta.SelectedValue == null)
                {
                    cboTipoExamen.DataSource = null;
                    cboSubTipoExamen.DataSource = null;
                    cargarGrillaTurnosSinFiltro();
                    return;
                }

                string idMotivoConsulta = cboMotivoConsulta.SelectedValue.ToString();

                if (!string.IsNullOrEmpty(idMotivoConsulta))
                {
                    // Cargar SOLO especialidades PADRE (Padre=1) para este motivo
                    DataTable dtPadres = tipoEx.cargarNivel1Especialidad(idMotivoConsulta);

                    if (dtPadres != null && dtPadres.Rows.Count > 0)
                    {
                        // Filtrar solo Padre = 1
                        DataView dv = new DataView(dtPadres);
                        dv.RowFilter = "Padre = 1";
                        DataTable dtFiltrados = dv.ToTable();

                        if (dtFiltrados.Rows.Count > 0)
                        {
                            // Agregar opción "TODOS" al principio
                            DataRow rowTodos = dtFiltrados.NewRow();
                            rowTodos["id"] = Guid.Empty;
                            rowTodos["descripcion"] = "TODOS";
                            dtFiltrados.Rows.InsertAt(rowTodos, 0);

                            cboTipoExamen.DataSource = dtFiltrados;
                            cboTipoExamen.ValueMember = "id";
                            cboTipoExamen.DisplayMember = "descripcion";
                            cboTipoExamen.SelectedIndex = 0;

                            cboSubTipoExamen.DataSource = null;
                            cargarGrillaTurnosSinFiltro();
                        }
                        else
                        {
                            cboTipoExamen.DataSource = null;
                            cboSubTipoExamen.DataSource = null;
                            cargarGrillaTurnosSinFiltro();
                        }
                    }
                    else
                    {
                        cboTipoExamen.DataSource = null;
                        cboSubTipoExamen.DataSource = null;
                        cargarGrillaTurnosSinFiltro();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en cboMotivoConsulta_SelectionChangeCommitted: {ex.Message}");
            }
        }
        private void cboTipoExamen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                // Si no hay selección, limpiar
                if (cboTipoExamen.SelectedIndex < 0 || cboTipoExamen.SelectedValue == null)
                {
                    cboSubTipoExamen.DataSource = null;
                    cargarGrillaTurnosSinFiltro();
                    cambiarEnabledBotonProximaFecha();
                    return;
                }

                string idTipoExamen = cboTipoExamen.SelectedValue.ToString();

                if (!string.IsNullOrEmpty(idTipoExamen) && idTipoExamen != Guid.Empty.ToString())
                {
                    // Cargar Nivel 2 (especialidades hijas dentro de este tipo/padre)
                    DataTable dtNivel2 = tipoEx.cargarNivel2Especialidad(idTipoExamen);

                    if (dtNivel2 != null && dtNivel2.Rows.Count > 0)
                    {
                        // Agregar opción "TODOS"
                        DataRow rowTodos = dtNivel2.NewRow();
                        rowTodos["id"] = Guid.Empty;
                        rowTodos["descripcion"] = "TODOS";
                        dtNivel2.Rows.InsertAt(rowTodos, 0);

                        // Debug: imprimir el orden de los subtipos antes de asignar al combo
                        foreach (DataRow dr in dtNivel2.Rows)
                        {
                            System.Diagnostics.Debug.WriteLine($"Subtipo: {dr["descripcion"]}");
                        }

                        cboSubTipoExamen.DataSource = dtNivel2;
                        cboSubTipoExamen.ValueMember = "id";
                        cboSubTipoExamen.DisplayMember = "descripcion";
                        cboSubTipoExamen.SelectedIndex = 0;

                        // Cargar grilla
                        cargarGrillaTurnosSinFiltro();
                    }
                    else
                    {
                        // Si no hay Nivel 2, limpiar y cargar grilla
                        cboSubTipoExamen.DataSource = null;
                        rbHoraTodas.Checked = true;
                        cargarGrillaTurnosSinFiltro();
                    }
                }
                else
                {
                    // Si selecciona "TODOS" en cboTipoExamen, limpiar cboSubTipoExamen
                    cboSubTipoExamen.DataSource = null;
                    rbHoraTodas.Checked = true;
                    cargarGrillaTurnosSinFiltro();
                }

                cambiarEnabledBotonProximaFecha();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en cboTipoExamen_SelectionChangeCommitted: {ex.Message}");
            }
        }


        private void cargarGrillaTurnosSinFiltro()
        {
            llenarDgv(turno.cargarTurnos(obtenerTipoExamen(), obtenerFecha(), obtenerHora(), obtenerEstado()));
        }
        private void colorearTodasLasFilas()
        {
            try
            {
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    object cellValue = fila.Cells[18].Value;  // ✅ Cambiar de 17 a 18

                    if (cellValue == null || string.IsNullOrEmpty(cellValue.ToString()))
                        continue;

                    if (!int.TryParse(cellValue.ToString(), out int valor))
                    {
                        System.Diagnostics.Debug.WriteLine($"No se puede convertir '{cellValue}' a número");
                        continue;
                    }

                    System.Diagnostics.Debug.WriteLine($"Estado: {valor}");

                    switch (valor)
                    {
                        case 2:
                            fila.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;      // Asignado
                            System.Diagnostics.Debug.WriteLine($"✅ Coloreada fila con estado 2");
                            break;
                        case 3:
                            fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;      // Bloqueado / Inhabilitado
                            System.Diagnostics.Debug.WriteLine($"[COLOR] Fila pintada LightGray (Inhabilitado, estado 3)");
                            break;
                        case 4:
                            fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightSteelBlue; // Reservado
                            break;
                        case 5:
                            fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;      // Otro estado bloqueado
                            break;
                        default:
                            fila.DefaultCellStyle.BackColor = System.Drawing.Color.White;          // Libre
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en colorearTodasLasFilas: {ex.Message}");
            }
        }
        private void llenarDgv(DataTable tabla)
        {
            int intTotalTurnosAsignados = 150;
            intTotalTurnosAsignados = 150;

            DataTable dt2 = tabla.Clone();
            dt2.Columns["Nro"].DataType = Type.GetType("System.Int32");

            foreach (DataRow dr in tabla.Rows)
            {
                dt2.ImportRow(dr);
            }
            dt2.AcceptChanges();

            tabla = dt2;

            try
            {
                try
                {
                    if (dgv.Rows.Count > 0)
                    { dgv.Rows.Clear(); }
                }
                catch (InvalidOperationException ex)
                { }

                foreach (DataRow r in tabla.Rows)
                {
                    dgv.Rows.Add(r.ItemArray);

                }
                colorearTodasLasFilas();
                try
                {
                    if (dgv.Rows.Count > 0 && dgv.Rows[nroFila] != null &&
                      dgv.Rows[nroFila].Cells[nroColumna] != null)
                    { dgv.CurrentCell = dgv.Rows[nroFila].Cells[nroColumna]; }
                }
                catch (InvalidOperationException ex)
                { }

                lblInformacion.Text = "";
                LblTurnos.Text = "";

                if (dgv.Rows.Count > 0)
                {
                    //lblInformacion.Text = dgv.Rows.Count.ToString() + " Turnos"; 
                    string strEstado = "";
                    if (rbEstadoLibres.Checked)
                        strEstado = rbEstadoLibres.Text.ToLowerInvariant();
                    else if (rbEstadoAsignados.Checked)
                        strEstado = rbEstadoAsignados.Text.ToLowerInvariant();
                    else
                        strEstado = "abiertos";

                    if ((!rbEstadoTodos.Checked) && cboTipoExamen.Text != "TODOS" && cboTipoExamen.Text != "System.Data.DataRowView")
                        LblTurnos.Text = dgv.Rows.Count.ToString() + " Turnos " + strEstado + " de (" + cboSubTipoExamen.Text + ")";
                    else if ((rbEstadoTodos.Checked) && cboTipoExamen.Text != "TODOS")
                        LblTurnos.Text = dgv.Rows.Count.ToString() + " Turnos abiertos de (" + cboTipoExamen.Text + ")";
                    else if (cboTipoExamen.Text == "TODOS" && rbEstadoLibres.Checked)
                        LblTurnos.Text = "Un total de " + dgv.Rows.Count.ToString() + " Turnos " + strEstado;
                    else if (cboTipoExamen.Text == "TODOS" && rbEstadoAsignados.Checked)
                        //LblTurnos.Text = "Un total de " + dgv.Rows.Count.ToString() + " Turnos " + strEstado;
                        LblTurnos.Text = "";
                    else
                        LblTurnos.Text = "";

                    //lblAsignados.Text = "Asignados " + turno.TotalTurnosAsignados(obtenerFecha()) + " de " + intTotalTurnosAsignados.ToString() + " turnos";

                    //if (turno.TotalTurnosAsignados(obtenerFecha()) > intTotalTurnosAsignados)
                    //{
                    //    lblAsignados.ForeColor = Color.Maroon;
                    //    MessageBox.Show("Se ha superado el total de " + intTotalTurnosAsignados.ToString() + " turnos diarios para la fecha " + obtenerFecha().ToShortDateString() + "\nProcure asignar los nuevos turnos a fechas posteriores", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                    //else
                    //{
                    //    lblAsignados.ForeColor = Color.White;
                    //}
                }
                cambiarHabilitacionBotonesHora();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //
            }
            catch (NullReferenceException ex)
            {
                //
            }
        }

        public virtual void mostrarMessageBox(string str)
        {
            MessageBox.Show(str);
        }

        private void colorearFila()
        {
            try
            {
                // Obtener el valor del estado (columna 17)
                object cellValue = dgv.Rows[dgv.Rows.Count - 1].Cells[17].Value;

                if (cellValue == null || string.IsNullOrEmpty(cellValue.ToString()))
                    return;

                // Intentar convertir a int
                if (!int.TryParse(cellValue.ToString(), out int valor))
                {
                    System.Diagnostics.Debug.WriteLine($"No se puede convertir '{cellValue}' a número en colorearFila");
                    return;
                }

                prueba = valor;
                System.Drawing.Color color = System.Drawing.Color.White;

                switch (valor)
                {
                    case 1:
                        color = System.Drawing.Color.White;  // Libre
                        break;
                    case 2:
                        color = System.Drawing.Color.MistyRose;  // Asignado
                        break;
                    case 3:
                        color = System.Drawing.Color.LightGray;  // Bloqueado
                        break;
                    case 4:
                        color = System.Drawing.Color.LightSteelBlue;  // Reservado
                        break;
                    case 5:
                        color = System.Drawing.Color.LightGray;  // Otro estado
                        break;
                }

                dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = color;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en colorearFila: {ex.Message}");
            }
        }
        private Guid obtenerTipoExamen()
        {
            // PRIORIDAD: Si está seleccionado cboSubTipoExamen (y no es TODOS), usarlo
            if (cboSubTipoExamen.SelectedIndex > 0 && cboSubTipoExamen.SelectedValue != null)
            {
                string selectedValue = cboSubTipoExamen.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(selectedValue) && selectedValue != Guid.Empty.ToString())
                {
                    return new Guid(selectedValue);
                }
            }

            // Si no hay SubTipo seleccionado, usar cboTipoExamen (Padre)
            if (cboTipoExamen.SelectedIndex > 0 && cboTipoExamen.SelectedValue != null)
            {
                string selectedValue = cboTipoExamen.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(selectedValue) && selectedValue != Guid.Empty.ToString())
                {
                    return new Guid(selectedValue);
                }
            }

            // Si nada está seleccionado, retornar vacío (mostrar TODOS)
            return Guid.Empty;
        }

        private DateTime obtenerFecha()
        {
            return tpFecha.SelectionRange.Start;
        }

        private string obtenerHora()
        {
            if (rbHora8.Checked) { return "8:00"; }
            if (rbHora9.Checked) { return "9:00"; }
            if (rbHora10.Checked) { return "10:00"; }
            if (rbHora11.Checked) { return "11:00"; }
            if (rbHora12.Checked) { return "12:00"; }
            if (rbHora13.Checked) { return "13:00"; }
            if (rbHora14.Checked) { return "14:00"; }
            if (rbHora15.Checked) { return "15:00"; }
            if (rbHora16.Checked) { return "16:00"; }
            return string.Empty;
        }

        private string obtenerEstado()
        {
            if (rbEstadoAsignados.Checked) { return "Asignado"; }
            if (rbEstadoLibres.Checked) { return "Libre"; }
            return string.Empty;
        }

        private void rbEstadoTodos_CheckedChanged(object sender, EventArgs e)
        {
            // GRV - Modificado
            //LimpiarUltimoRegistroIngresado();
            //
            cargarGrillaTurnosSinFiltro();
            CambiarColorEstados();
        }

        private void rbEstadoLibres_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
            CambiarColorEstados();
        }

        private void rbEstadoAsignados_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
            CambiarColorEstados();
        }

        private void rbHoraTodas_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
        }

        private void rbHora8_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
        }

        private void rbHora9_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
        }

        private void rbHora10_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
        }

        private void rbHora11_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
        }

        private void rbHora12_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
        }

        private void rbHora13_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
        }

        private void rbHora14_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
        }

        private void rbHora15_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
        }

        private void rbHora16_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
        }

        private void cargarTurnoSeleccionado()
        {
            if (dgv.CurrentCell != null && turnoAsignado(dgv.CurrentCell.RowIndex))
            {
                // ✅ CAMBIAR de [6] a [7]
                char tipoPaciente = turno.verificarTipoPaciente(new Guid(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[7].Value.ToString()));
                if (tipoPaciente == 'P')
                {
                    cargarPanelPreventiva();
                }
                else
                {
                    cargarPanelLaboral();
                }
            }
            else
            {
                panelPacientePreventiva.Visible = false;
                panelLaboral.Visible = false;
            }
            cambiarVisibilidadBotonesPrincipales();
        }
        private void cambiarVisibilidadBotonesPrincipales()
        {
            if (dgv.CurrentCell != null)
            {
                if (turnoAsignado(dgv.CurrentCell.RowIndex))
                {
                    botAsignar.Visible = false;
                    botModificar.Visible = true;
                    botLiberar.Visible = true;
                    btnCopiarInfo.Visible = true; //GRV - Visible para todos los tipos de turno
                    btnWhatsApp.Visible = true; // WhatsApp visible para todos los tipos de turno
                    btnVerEstudio.Visible = true;
                    btnMoverTurno.Visible = true; // GRV - Modificado
                    if (blnActivoMoverTurno)
                    {
                        botLiberar.Visible = false;
                        btnCopiarInfo.Visible = false; //GRV - Modificado
                        btnWhatsApp.Visible = false; // WhatsApp oculto en modo mover turno
                        btnVerEstudio.Visible = false;
                        btnMoverTurno.Visible = false; // GRV - Modificado
                        botModificar.Visible = false;
                    }
                }
                else
                {
                    if (!botAceptar.Visible && !botCancelar.Visible)
                    {
                        botAsignar.Visible = true;
                    }
                    btnMoverTurno.Visible = false; // GRV - Modificado
                    btnWhatsApp.Visible = false; // WhatsApp oculto si no hay turno asignado
                    if (blnActivoMoverTurno)
                    {
                        botAsignar.Visible = false;
                        btnMoverTurno.Visible = true; // GRV - Modificado
                    }
                    botModificar.Visible = false;
                    botLiberar.Visible = false;
                    btnCopiarInfo.Visible = false; //GRV - Modificado
                    btnVerEstudio.Visible = false;
                }
            }
            else
            {
                botAsignar.Visible = false;
                botModificar.Visible = false;
                botLiberar.Visible = false;
                btnCopiarInfo.Visible = false; //GRV - Modificado
                btnWhatsApp.Visible = false; // WhatsApp oculto si no hay selección
                btnVerEstudio.Visible = false;
            }
        }

        private void cargarPanelPreventiva()
        {
            panelPacientePreventiva.Visible = true;
            panelLaboral.Visible = false;
            Entidades.TurnoPreventiva pacientePreventiva = turno.cargarTurnoPacientePreventiva(new Guid(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString()));

            // Si PrecioLista es 0, buscarlo en PrecioPublico usando el IdSubtipo de la grilla
            if (pacientePreventiva.TipoExamen.PrecioLista == 0)
            {
                string idSubtipoPrev = dgv.Rows[dgv.CurrentCell.RowIndex].Cells["IdSubtipo"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(idSubtipoPrev) && idSubtipoPrev != Guid.Empty.ToString())
                {
                    DataTable puPrev = SQLConnector.obtenerTablaSegunConsultaString("SELECT PrecioLista FROM dbo.PrecioPublico WHERE idEspecialidad = '" + idSubtipoPrev + "' AND Mes = " + obtenerFecha().Month + " AND Anio = " + obtenerFecha().Year + " AND Eliminado = 0");
                    if (puPrev.Rows.Count > 0 && Convert.ToDouble(puPrev.Rows[0]["PrecioLista"].ToString()) > 0)
                        pacientePreventiva.TipoExamen.PrecioLista = Convert.ToDouble(puPrev.Rows[0]["PrecioLista"].ToString());
                }
            }

            // Cargar campos de seña y planilla desde PrecioPromo (solo si no hay valor personalizado)
            {
                string idSubtipoPrev2 = dgv.Rows[dgv.CurrentCell.RowIndex].Cells["IdSubtipo"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(idSubtipoPrev2) && idSubtipoPrev2 != Guid.Empty.ToString())
                {
                    DataTable ppPrev2 = turno.ObtenerPrecioPromo(new Guid(idSubtipoPrev2), obtenerFecha());
                    if (ppPrev2.Rows.Count > 0)
                    {
                        // Solo cargar Seña desde PrecioPromo si no hay un valor personalizado (> 0)
                        if (pacientePreventiva.TipoExamen.Seña <= 0)
                        {
                            pacientePreventiva.TipoExamen.Seña = Convert.ToDouble(ppPrev2.Rows[0]["Seña"]);
                        }
                        pacientePreventiva.TipoExamen.LlevaPlanilla = Convert.ToBoolean(ppPrev2.Rows[0]["LlevaPlanilla"]);
                        pacientePreventiva.TipoExamen.ObservacionesExtra = ppPrev2.Rows[0]["ObservacionesExtra"].ToString();
                    }
                }
            }

            llenarPanelPacientePreventiva(pacientePreventiva);
        }

        private void llenarPanelPacientePreventiva(Entidades.TurnoPreventiva turnoPrev)
        {
            CapaNegocioMepryl.PacientePreventiva PacientePre = new PacientePreventiva();

            tbIdTurnoPreventiva.Text = turnoPrev.Id.ToString();
            tbIdPacientePreventiva.Text = turnoPrev.IdPaciente.ToString();
            tbPacientePreventiva.Text = turnoPrev.ApellidoNombre;
            if (turnoPrev.Nacimiento != new DateTime(1800, 1, 1))
            {
                //tbCategoriaPreventiva.Text = turnoPrev.Nacimiento.Year.ToString();
                tbCategoriaPreventiva.Text = turnoPrev.Nacimiento.ToString("dd/MM/yyyy");
            }
            tbDniPreventiva.Text = turnoPrev.Dni;
            tbTelefonoPreventiva.Text = turnoPrev.Telefono;
            dgvLigaYClub.DataSource = turnoPrev.LigaClub;
            if (dgvLigaYClub.Rows.Count > 0)
            {
                dgvLigaYClub.Columns[0].Visible = false;
                dgvLigaYClub.Columns[2].Visible = false;
                ((DataGridViewImageColumn)dgvLigaYClub.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                ((DataGridViewImageColumn)dgvLigaYClub.Columns[1]).DefaultCellStyle.BackColor = System.Drawing.Color.Transparent;
            }
            tbObservPreventiva.Text = turnoPrev.Observaciones;
            tipoExamenActual = turnoPrev.TipoExamen;
            // Auto-generar observaciones si tiene seña/planilla y la observación está vacía
            if (string.IsNullOrWhiteSpace(tbObservPreventiva.Text) &&
                (tipoExamenActual.LlevaPlanilla || tipoExamenActual.Seña > 0))
                tbObservPreventiva.Text = generarObservaciones(tipoExamenActual);
            txtEmail.Text = turnoPrev.Mail;
            txtEdad.Text = (DateTime.Today.AddTicks(-turnoPrev.Nacimiento.Ticks).Year - 1).ToString();
            tbIdTipoExamenPreventiva.Text = tipoExamenActual.IdTipoExamenPaciente.ToString();
            tbImportePreventiva.Text = (tipoExamenActual.PrecioBase - tipoExamenActual.Seña).ToString("N0");
            tbImporteListaPreventiva.Text = (tipoExamenActual.PrecioLista - tipoExamenActual.Seña).ToString("N0");
            tbSeñaPreventiva.Text = tipoExamenActual.Seña.ToString("N0");
            tbExamenPreventiva.Text = tipoExamenActual.Descripcion;
            if (tipoExamenActual.Modificado)
            {
                tbExamenPreventiva.Text = tbExamenPreventiva.Text + " MODIF.";

                // GRV- Modificado saber si realizo exemen
                //if (!PacientePre.DebeRealizarExamenRX(turnoPrev.Dni))
                //{
                //    tbExamenPreventiva.Text = tipoExamenActual.Descripcion + " MODIF.";
                //}
            }

            // GRV
            strUltRegistro[6] = turnoPrev.IdPaciente.ToString();
            strUltRegistro[7] = turnoPrev.Dni;
            strUltRegistro[8] = turnoPrev.ApellidoNombre;
            strUltRegistro[9] = tbCategoriaPreventiva.Text;
        }

        private void cargarPanelLaboral()
        {
            panelPacientePreventiva.Visible = false;
            panelLaboral.Visible = true;
            test = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
            test = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
            Entidades.TurnoLaboral pacienteLaboral = turno.cargarTurnoPacienteLaboral(new Guid(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString()));

            // Si PrecioLista es 0, buscarlo en PrecioPublico usando el IdSubtipo de la grilla
            if (pacienteLaboral.TipoExamen.PrecioLista == 0)
            {
                string idSubtipoLab = dgv.Rows[dgv.CurrentCell.RowIndex].Cells["IdSubtipo"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(idSubtipoLab) && idSubtipoLab != Guid.Empty.ToString())
                {
                    DataTable puLab = SQLConnector.obtenerTablaSegunConsultaString("SELECT PrecioLista FROM dbo.PrecioPublico WHERE idEspecialidad = '" + idSubtipoLab + "' AND Mes = " + obtenerFecha().Month + " AND Anio = " + obtenerFecha().Year + " AND Eliminado = 0");
                    if (puLab.Rows.Count > 0 && Convert.ToDouble(puLab.Rows[0]["PrecioLista"].ToString()) > 0)
                        pacienteLaboral.TipoExamen.PrecioLista = Convert.ToDouble(puLab.Rows[0]["PrecioLista"].ToString());
                }
            }

            // Cargar campos de seña y planilla desde PrecioPromo (solo si no hay valor personalizado)
            {
                string idSubtipoLab2 = dgv.Rows[dgv.CurrentCell.RowIndex].Cells["IdSubtipo"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(idSubtipoLab2) && idSubtipoLab2 != Guid.Empty.ToString())
                {
                    DataTable ppLab2 = turno.ObtenerPrecioPromo(new Guid(idSubtipoLab2), obtenerFecha());
                    if (ppLab2.Rows.Count > 0)
                    {
                        // Solo cargar Seña desde PrecioPromo si no hay un valor personalizado (> 0)
                        if (pacienteLaboral.TipoExamen.Seña <= 0)
                        {
                            pacienteLaboral.TipoExamen.Seña = Convert.ToDouble(ppLab2.Rows[0]["Seña"]);
                        }
                        pacienteLaboral.TipoExamen.LlevaPlanilla = Convert.ToBoolean(ppLab2.Rows[0]["LlevaPlanilla"]);
                        pacienteLaboral.TipoExamen.ObservacionesExtra = ppLab2.Rows[0]["ObservacionesExtra"].ToString();
                    }
                }
            }

            llenarPanelPacienteLaboral(pacienteLaboral);
        }

        private void llenarPanelPacienteLaboral(Entidades.TurnoLaboral turnoLab)
        {
            string strFecha = "";
            tbIdTurnoLaboral.Text = turnoLab.Id.ToString();
            tbIdPacienteLaboral.Text = turnoLab.IdPaciente.ToString();
            tbPacienteLaboral.Text = turnoLab.ApellidoNombre;
            tbDniLaboral.Text = turnoLab.Dni;
            tbCuilLaboral.Text = turnoLab.Cuil;
            tbIdEmpresaLaboral.Text = turnoLab.IdEmpresa.ToString();
            tbEmpresaLaboral.Text = turnoLab.Empresa;
            strFecha = turnoLab.FechaNacimiento.ToString("dd/MM/yyyy");
            if (strFecha != "01/01/0001")
            {
                txtFNacLab.Text = turnoLab.FechaNacimiento.ToString("dd/MM/yyyy");
                txtEdadLab.Text = (DateTime.Today.AddTicks(-turnoLab.FechaNacimiento.Ticks).Year - 1).ToString();
            }
            else
            {
                txtFNacLab.Text = "";
                txtEdadLab.Text = "0";
            }

            tbTareaLaboral.Text = turnoLab.Tarea;
            txtEmailLab.Text = turnoLab.Email;
            tbTelefonoLaboral.Text = turnoLab.Telefono;
            tbObservacionesLaboral.Text = turnoLab.Observaciones;
            tipoExamenActual = turnoLab.TipoExamen;
            // Auto-generar observaciones si tiene seña/planilla y la observación está vacía
            if (string.IsNullOrWhiteSpace(tbObservacionesLaboral.Text) &&
                (tipoExamenActual.LlevaPlanilla || tipoExamenActual.Seña > 0))
                tbObservacionesLaboral.Text = generarObservaciones(tipoExamenActual);
            tbIdTipoExamenLaboral.Text = tipoExamenActual.IdTipoExamenPaciente.ToString();
            tbImporteLaboral.Text = (tipoExamenActual.PrecioBase - tipoExamenActual.Seña).ToString("N0");
            tbImporteListaLaboral.Text = (tipoExamenActual.PrecioLista - tipoExamenActual.Seña).ToString("N0");
            tbSeñaLaboral.Text = tipoExamenActual.Seña.ToString("N0");
            tbExamenLaboral.Text = dgv.Rows[dgv.CurrentCell.RowIndex].Cells["SubTipoExamen"].Value?.ToString();
            if (tipoExamenActual.Modificado)
            {
                tbExamenLaboral.Text = tbExamenLaboral.Text + " MODIF.";
            }
            // GRV
            strUltRegistro[6] = tbIdPacienteLaboral.Text = turnoLab.IdPaciente.ToString();
            strUltRegistro[7] = turnoLab.Dni;
            strUltRegistro[8] = turnoLab.ApellidoNombre;
            strUltRegistro[9] = "";
        }

        private void turnoNoAsignado()
        {
            char tipoTurno = turno.verificarTipoTurno(new Guid(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString()));
            if (tipoTurno == 'P')
            {
                abrirVentanaPacientePreventiva();
                //BotonesRibbon(tipoTurno);
            }
            else if (tipoTurno == 'L')
            {
                abrirVentanaPacienteLaboral();
                //BotonesRibbon(tipoTurno);
            }
            else
            {
                // GRV - Ramírez modifcado asignar turno consulta
                //abrirVentanaTipoPaciente();
                if (blnConsultaExterna)
                {
                    asignarPacienteLaboral(strIDPaciente, strIDEmpresa);
                    //BotonesRibbon('L');
                }
                else
                {
                    abrirVentanaTipoPaciente();
                    //BotonesRibbon('P');
                }
            }
        }

        private void BotonesRibbon(char strTipo)
        {
            //bbiEditarPreventiva.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //bbiExamenPreventiva.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //bbiEditarLaboral.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //bbiExamenLaboral.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            botEditarExamenPreventiva.Visible = false;
            botEditarPacientePreventiva.Visible = false;
            botEditarPacienteLaboral.Visible = false;
            botEditarExamenLaboral.Visible = false;

            if (strTipo == 'P')
            {
                //bbiEditarPreventiva.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //bbiExamenPreventiva.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                botEditarExamenPreventiva.Visible = true;
                botEditarPacientePreventiva.Visible = true;
            }
            else if (strTipo == 'L')
            {
                //bbiEditarLaboral.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //bbiExamenLaboral.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                botEditarPacienteLaboral.Visible = true;
                botEditarExamenLaboral.Visible = true;
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!VerificaIDTurnoLibre())
                asignar();
            else
                cargarGrillaTurnosSinFiltro();
        }

        public void asignar()
        {
            // GRV - Modificado
            LimpiarUltimoRegistroIngresado();
            //

            if (dgv.CurrentCell != null && turnoLibre(dgv.CurrentCell.RowIndex))
            {
                turnoNoAsignado();
            }
            else if (dgv.CurrentCell != null && turnoReservado(dgv.CurrentCell.RowIndex))
            {
                DialogResult result = MessageBox.Show("¿Desea asignar el turno reservado?", "Asignar Reserva",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    turno.liberarReservaTurno(new Guid(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString()));
                    turnoNoAsignado();
                }
            }
        }

        private void asignarPacientePreventiva(string idPaciente)
        {
            //GRV - Modificado "INFANTIL INICIAL"
            turno.EsInfantilInicial(cboTipoExamen.Text);

            panelPacientePreventiva.Visible = true;
            panelLaboral.Visible = false;
            Entidades.TurnoPreventiva pacientePreventiva = turno.nuevoTurnoPacientePreventiva(idPaciente, dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString());

            // Buscar y actualizar precio desde PrecioPromo por periodo
            DateTime fechaTurno = obtenerFecha();
            string idSubtipoAsigPrev = dgv.Rows[dgv.CurrentCell.RowIndex].Cells["IdSubtipo"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(idSubtipoAsigPrev))
            {
                DataTable ppAsigPrev = turno.ObtenerPrecioPromo(new Guid(idSubtipoAsigPrev), fechaTurno);
                if (ppAsigPrev.Rows.Count > 0)
                {
                    pacientePreventiva.TipoExamen.PrecioBase = Convert.ToDouble(ppAsigPrev.Rows[0]["PrecioPromo"].ToString());
                    pacientePreventiva.TipoExamen.PrecioLista = Convert.ToDouble(ppAsigPrev.Rows[0]["PrecioLista"].ToString());
                    pacientePreventiva.TipoExamen.Seña = Convert.ToDouble(ppAsigPrev.Rows[0]["Seña"]);
                    pacientePreventiva.TipoExamen.LlevaPlanilla = Convert.ToBoolean(ppAsigPrev.Rows[0]["LlevaPlanilla"]);
                    pacientePreventiva.TipoExamen.ObservacionesExtra = ppAsigPrev.Rows[0]["ObservacionesExtra"].ToString();
                    // Guardar precioLista y Seña actualizado en BD
                    if (pacientePreventiva.TipoExamen.IdTipoExamenPaciente != Guid.Empty)
                    {
                        turno.ActualizarPrecioListaTipoExamenPaciente(
                            pacientePreventiva.TipoExamen.IdTipoExamenPaciente,
                            pacientePreventiva.TipoExamen.PrecioLista);
                    }
                }
            }

            // GRV - Modificado verifica si el turno esta asignado
            //llenarPanelPacientePreventiva(pacientePreventiva);
            //modoEdicion();
            strIdPaciente = pacientePreventiva.IdPaciente.ToString();
            strDNI = pacientePreventiva.Dni.ToString();
            strApellido = pacientePreventiva.ApellidoNombre.ToString();

            if (cboTipoExamen.Text == "INFANTIL INICIAL")
            {
                if (VerificaCategoriaPacienteInicial(pacientePreventiva.Dni.ToString()))
                {
                    if (!PacienteTieneTurno(pacientePreventiva.IdPaciente.ToString(), pacientePreventiva.ApellidoNombre.ToString(), pacientePreventiva.Dni.ToString()))
                    {
                        llenarPanelPacientePreventiva(pacientePreventiva);
                        modoEdicion();
                    }
                }
                else
                {
                    MessageBox.Show("El paciente no corresponde al tipo de examen 'INFANTIL INICIAL'...", "Asignar turnos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (!PacienteTieneTurno(pacientePreventiva.IdPaciente.ToString(), pacientePreventiva.ApellidoNombre.ToString(), pacientePreventiva.Dni.ToString()))
                {
                    llenarPanelPacientePreventiva(pacientePreventiva);
                    modoEdicion();
                }
            }
        }

        private void asignarPacienteLaboral(string idPaciente, string idEmpresa)
        {
            panelPacientePreventiva.Visible = false;
            panelLaboral.Visible = true;
            test = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
            test = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
            Entidades.TurnoLaboral pacienteLaboral = turno.nuevoTurnoPacienteLaboral(idPaciente, dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString(), idEmpresa);

            // Buscar y actualizar precio desde PrecioPromo por periodo
            DateTime fechaTurno = obtenerFecha();
            string idSubtipoAsigLab = dgv.Rows[dgv.CurrentCell.RowIndex].Cells["IdSubtipo"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(idSubtipoAsigLab))
            {
                DataTable ppAsigLab = turno.ObtenerPrecioPromo(new Guid(idSubtipoAsigLab), fechaTurno);
                if (ppAsigLab.Rows.Count > 0)
                {
                    pacienteLaboral.TipoExamen.PrecioBase = Convert.ToDouble(ppAsigLab.Rows[0]["PrecioPromo"].ToString());
                    pacienteLaboral.TipoExamen.PrecioLista = Convert.ToDouble(ppAsigLab.Rows[0]["PrecioLista"].ToString());
                    pacienteLaboral.TipoExamen.Seña = Convert.ToDouble(ppAsigLab.Rows[0]["Seña"]);
                    pacienteLaboral.TipoExamen.LlevaPlanilla = Convert.ToBoolean(ppAsigLab.Rows[0]["LlevaPlanilla"]);
                    pacienteLaboral.TipoExamen.ObservacionesExtra = ppAsigLab.Rows[0]["ObservacionesExtra"].ToString();
                    // Guardar precioLista actualizado en BD
                    if (pacienteLaboral.TipoExamen.IdTipoExamenPaciente != Guid.Empty)
                    {
                        turno.ActualizarPrecioListaTipoExamenPaciente(
                            pacienteLaboral.TipoExamen.IdTipoExamenPaciente,
                            pacienteLaboral.TipoExamen.PrecioLista);
                    }
                }
            }

            //GRV - Modificado Verifica si el turno esta asignado
            //llenarPanelPacienteLaboral(pacienteLaboral);
            //modoEdicion();
            strIdPaciente = pacienteLaboral.IdPaciente.ToString();
            strDNI = pacienteLaboral.ApellidoNombre.ToString();
            strApellido = pacienteLaboral.Dni.ToString();

            if (!PacienteTieneTurno(pacienteLaboral.IdPaciente.ToString(), pacienteLaboral.ApellidoNombre.ToString(), pacienteLaboral.Dni.ToString()))
            {
                llenarPanelPacienteLaboral(pacienteLaboral);
                modoEdicion();
            }
        }

        private void abrirVentanaPacientePreventiva()
        {
            frmPaciente fPaciente = new frmPaciente(new Configuracion(), true);
            fPaciente.objDelegateDevolverID = new frmPaciente.DelegateDevolverID(asignarPacientePreventiva);
            fPaciente.ShowDialog();
        }

        private void abrirVentanaPacienteLaboral()
        {
            frmPacienteLaboral fPaciente = new frmPacienteLaboral();
            fPaciente.objDelegateDevolverID = new frmPacienteLaboral.DelegateDevolverID(asignarPacienteLaboral);
            fPaciente.ShowDialog();
        }

        private void abrirVentanaTipoPaciente()
        {
            frmTipoPaciente fTipoPaciente = new frmTipoPaciente();
            fTipoPaciente.objDelegateDevolverID = new frmTipoPaciente.DelegateDevolverID(asignarTipoPacienteSeleccionado);
            fTipoPaciente.ShowDialog();
        }

        private void asignarTipoPacienteSeleccionado(char tipo)
        {
            if (tipo == 'L')
            {
                abrirVentanaPacienteLaboral();
            }
            else
            {
                abrirVentanaPacientePreventiva();
            }
        }

        private void botEditarExamenLaboral_Click(object sender, EventArgs e)
        {
            editarExamenLaboral();
        }

        private void editarExamenLaboral()
        {
            frmTipoExamen fTipoExamen = new frmTipoExamen(tipoExamenActual);
            fTipoExamen.objDelegateDevolverTipoExamen = new frmTipoExamen.DelegateDevolverTipoExamen(cargarTipoExamenLaboral);
            fTipoExamen.ShowDialog();
        }

        private void cargarTipoExamenLaboral(Entidades.TipoExamen tipoEx)
        {
            tipoExamenActual = tipoEx;
            tbIdTipoExamenLaboral.Text = tipoEx.IdTipoExamenPaciente.ToString();
            tbImporteLaboral.Text = (tipoEx.PrecioBase - tipoEx.Seña).ToString("N0");
            tbImporteListaLaboral.Text = (tipoEx.PrecioLista - tipoEx.Seña).ToString("N0");
            tbExamenLaboral.Text = tipoEx.Descripcion;
            if (tipoEx.Modificado)
            {
                tbExamenLaboral.Text = tbExamenLaboral.Text + " MODIF.";
            }
            resaltarPrecioActivoLaboral(tipoEx.UsarPrecioLista);
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            modoEdicion();
        }

        private void modoEdicion()
        {
            dgv.Focus();
            if (panelPacientePreventiva.Visible)
            {
                panelPacientePreventiva.Enabled = true;
                dgvLigaYClub.Enabled = true;
            }
            if (panelLaboral.Visible) { panelLaboral.Enabled = true; }
            botAsignar.Visible = false;
            botModificar.Visible = false;
            botLiberar.Visible = false;
            botAceptar.Visible = true;
            botCancelar.Visible = true;
            dgv.Enabled = false;
            panelFechaTipoExamen.Enabled = false;
            panelFiltro.Enabled = false;
            panelHorario.Enabled = false;
            panelEstado.Enabled = false;
            btnCopiarInfo.Visible = false; //GRV - Modificado
            btnVerEstudio.Visible = false;

            btnMoverTurno.Visible = false;

            MuestraBotonesEditar();

            // Mostrar toggle de precio en el panel activo
            btnTogglePrecioPreventiva.Visible = panelPacientePreventiva.Visible;
            btnTogglePrecioLaboral.Visible = panelLaboral.Visible;

            pintarControlesPanelHabilitar(); //GRV - pinta los controles
        }

        private void MuestraBotonesEditar()
        {
            if (panelPacientePreventiva.Visible)
            {
                botEditarPacientePreventiva.Visible = true;
                botEditarExamenPreventiva.Visible = true;

                botEditarPacienteLaboral.Visible = false;
                botEditarExamenLaboral.Visible = false;
            }

            if (panelLaboral.Visible)
            {
                botEditarPacienteLaboral.Visible = true;
                botEditarExamenLaboral.Visible = true;

                botEditarPacientePreventiva.Visible = false;
                botEditarExamenPreventiva.Visible = false;
            }
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            cargarTurnoSeleccionado();
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            // GRV
            CargarDatosMatrizTemp();
            // GRV

            sincronizarImportesDesdePantalla();

            // GRV - Modificado verifica si el turno no esta ocupado
            //guardar();

            if (!VerificaIDTurnoLibre()) // GRV - Modificado
                guardar();
            //else
            //cargarGrillaTurnosSinFiltro();
            // GRV
            MostrarUltimoRegistro();
        }

        private void sincronizarImportesDesdePantalla()
        {
            if (tipoExamenActual == null)
                return;

            if (panelPacientePreventiva.Visible)
            {
                double seña = obtenerDoubleDesdeTextBox(tbSeñaPreventiva.Text, tipoExamenActual.Seña);
                tipoExamenActual.PrecioBase = obtenerDoubleDesdeTextBox(tbImportePreventiva.Text, 0) + seña;
                tipoExamenActual.PrecioLista = obtenerDoubleDesdeTextBox(tbImporteListaPreventiva.Text, 0) + seña;
                tipoExamenActual.Seña = seña;
                return;
            }

            if (panelLaboral.Visible)
            {
                double seña = obtenerDoubleDesdeTextBox(tbSeñaLaboral.Text, tipoExamenActual.Seña);
                tipoExamenActual.PrecioBase = obtenerDoubleDesdeTextBox(tbImporteLaboral.Text, 0) + seña;
                tipoExamenActual.PrecioLista = obtenerDoubleDesdeTextBox(tbImporteListaLaboral.Text, 0) + seña;
                tipoExamenActual.Seña = seña;
            }
        }

        private void guardar()
        {
            if (panelPacientePreventiva.Visible)
            {
                guardarPreventiva();
            }
            else
            {
                guardarLaboral();
            }
        }

        private void guardarPreventiva()
        {
            Entidades.TurnoPreventiva entidad = llenarEntidadPreventiva();
            if (turnoAsignado(dgv.CurrentCell.RowIndex))
            {
                Entidades.Resultado resultado = turno.modificarTurnoPreventiva(entidad);
                analizarGuardadoTurno(resultado);
            }
            else
            {
                Entidades.Resultado resultado = turno.nuevoTurnoPreventiva(entidad);
                analizarGuardadoTurno(resultado);
            }
        }

        private void guardarLaboral()
        {
            Entidades.TurnoLaboral entidad = llenarEntidadLaboral();
            if (turnoAsignado(dgv.CurrentCell.RowIndex))
            {
                Entidades.Resultado resultado = turno.modificarTurnoLaboral(entidad);
                analizarGuardadoTurno(resultado);
            }
            else
            {
                Entidades.Resultado resultado = turno.nuevoTurnoLaboral(entidad);
                analizarGuardadoTurno(resultado);
            }

            //if ((cboTipoExamen.Text == "BUZO") || (cboTipoExamen.Text == "BUZO 1º VEZ"))
            //    InhabilitaErgometrias();
        }

        private void analizarGuardadoTurno(Entidades.Resultado resultado)
        {
            if (resultado.Modo == 1)
            {
                nroFila = dgv.CurrentCell.RowIndex;
                nroColumna = dgv.CurrentCell.ColumnIndex;
                modoConsulta();
                cargarGrillaTurnosSinFiltro();
                cargarTurnoSeleccionado();
            }
            else
            {
                MessageBox.Show("¡Error al guardar turno!\nError: " + resultado.Mensaje, "Guardar Turno",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows[dgv.CurrentCell.RowIndex].Cells[8].Value.ToString() == "")
            {
                SQLConnector.EjecutarConsulta(
                    "UPDATE [dbo].[Turno] " +
                    "SET estadoID = '1737e61f-b256-40f5-8b57-63369638536d' " +
                    "WHERE id = '" + dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'"
                ); cargarGrillaTurnosSinFiltro();
            }
            cancelar();
        }

        private void cancelar()
        {
            modoConsulta();
            cargarGrillaTurnosSinFiltro();
            cargarTurnoSeleccionado();
        }

        private Entidades.TurnoPreventiva llenarEntidadPreventiva()
        {
            Entidades.TurnoPreventiva retorno = new Entidades.TurnoPreventiva();
            if (tbIdTurnoPreventiva.Text != string.Empty) { retorno.Id = new Guid(tbIdTurnoPreventiva.Text); }
            retorno.LigaClub = (DataTable)dgvLigaYClub.DataSource;
            retorno.Observaciones = tbObservPreventiva.Text;
            retorno.IdPaciente = new Guid(tbIdPacientePreventiva.Text);
            if (tipoExamenActual != null)
            {
                double precioListaUI = obtenerDoubleDesdeTextBox(tbImporteListaPreventiva.Text, tipoExamenActual.PrecioLista);
                tipoExamenActual.PrecioLista = precioListaUI;
            }
            retorno.TipoExamen = tipoExamenActual;
            retorno.Consulta = "PREVENTIVA";
            return retorno;
        }

        private Entidades.TurnoLaboral llenarEntidadLaboral()
        {
            Entidades.TurnoLaboral retorno = new Entidades.TurnoLaboral();
            if (tbIdTurnoLaboral.Text != string.Empty) { retorno.Id = new Guid(tbIdTurnoLaboral.Text); }
            retorno.IdEmpresa = new Guid(tbIdEmpresaLaboral.Text);
            retorno.Tarea = tbTareaLaboral.Text;
            retorno.Observaciones = tbObservacionesLaboral.Text;
            retorno.IdPaciente = new Guid(tbIdPacienteLaboral.Text);
            if (tipoExamenActual != null)
            {
                double precioListaUI = obtenerDoubleDesdeTextBox(tbImporteListaLaboral.Text, tipoExamenActual.PrecioLista);
                tipoExamenActual.PrecioLista = precioListaUI;
            }
            retorno.TipoExamen = tipoExamenActual;
            retorno.Consulta = "LABORAL";
            return retorno;
        }

        private void resaltarPrecioActivoPreventiva(bool usarLista)
        {
            if (usarLista)
            {
                tbImporteListaPreventiva.BackColor = Color.PaleGreen;
                tbImporteListaPreventiva.Font = new Font(tbImporteListaPreventiva.Font, FontStyle.Bold);
                tbImportePreventiva.BackColor = SystemColors.Window;
                tbImportePreventiva.Font = new Font(tbImportePreventiva.Font, FontStyle.Regular);
            }
            else
            {
                tbImportePreventiva.BackColor = Color.PaleGreen;
                tbImportePreventiva.Font = new Font(tbImportePreventiva.Font, FontStyle.Bold);
                tbImporteListaPreventiva.BackColor = SystemColors.Window;
                tbImporteListaPreventiva.Font = new Font(tbImporteListaPreventiva.Font, FontStyle.Regular);
            }
            btnTogglePrecioPreventiva.BackColor = Color.PaleGreen;
        }

        private void resaltarPrecioActivoLaboral(bool usarLista)
        {
            if (usarLista)
            {
                tbImporteListaLaboral.BackColor = Color.PaleGreen;
                tbImporteListaLaboral.Font = new Font(tbImporteListaLaboral.Font, FontStyle.Bold);
                tbImporteLaboral.BackColor = SystemColors.Window;
                tbImporteLaboral.Font = new Font(tbImporteLaboral.Font, FontStyle.Regular);
            }
            else
            {
                tbImporteLaboral.BackColor = Color.PaleGreen;
                tbImporteLaboral.Font = new Font(tbImporteLaboral.Font, FontStyle.Bold);
                tbImporteListaLaboral.BackColor = SystemColors.Window;
                tbImporteListaLaboral.Font = new Font(tbImporteListaLaboral.Font, FontStyle.Regular);
            }
            btnTogglePrecioLaboral.BackColor = Color.PaleGreen;
        }

        private void btnTogglePrecioPreventiva_Click(object sender, EventArgs e)
        {
            if (tipoExamenActual == null) return;
            tipoExamenActual.UsarPrecioLista = !tipoExamenActual.UsarPrecioLista;
            resaltarPrecioActivoPreventiva(tipoExamenActual.UsarPrecioLista);
            if (tipoExamenActual.SeñaPromo > 0 || tipoExamenActual.SeñaLista > 0 || tipoExamenActual.LlevaPlanilla || tipoExamenActual.Seña > 0)
                tbObservPreventiva.Text = generarObservaciones(tipoExamenActual);
        }

        private void btnTogglePrecioLaboral_Click(object sender, EventArgs e)
        {
            if (tipoExamenActual == null) return;
            tipoExamenActual.UsarPrecioLista = !tipoExamenActual.UsarPrecioLista;
            resaltarPrecioActivoLaboral(tipoExamenActual.UsarPrecioLista);
            if (tipoExamenActual.SeñaPromo > 0 || tipoExamenActual.SeñaLista > 0 || tipoExamenActual.LlevaPlanilla || tipoExamenActual.Seña > 0)
                tbObservacionesLaboral.Text = generarObservaciones(tipoExamenActual);
        }

        private void tbSeñaPreventiva_TextChanged(object sender, EventArgs e)
        {
            if (tipoExamenActual == null) return;
            tipoExamenActual.Seña = obtenerDoubleDesdeTextBox(tbSeñaPreventiva.Text, tipoExamenActual.Seña);
            tbObservPreventiva.Text = generarObservaciones(tipoExamenActual);
            
            // Actualizar visualmente los importes restando la seña
            tbImportePreventiva.Text = (tipoExamenActual.PrecioBase - tipoExamenActual.Seña).ToString("N0");
            tbImporteListaPreventiva.Text = (tipoExamenActual.PrecioLista - tipoExamenActual.Seña).ToString("N0");
        }

        private void tbSeñaLaboral_TextChanged(object sender, EventArgs e)
        {
            if (tipoExamenActual == null) return;
            tipoExamenActual.Seña = obtenerDoubleDesdeTextBox(tbSeñaLaboral.Text, tipoExamenActual.Seña);
            tbObservacionesLaboral.Text = generarObservaciones(tipoExamenActual);

            // Actualizar visualmente los importes restando la seña
            tbImporteLaboral.Text = (tipoExamenActual.PrecioBase - tipoExamenActual.Seña).ToString("N0");
            tbImporteListaLaboral.Text = (tipoExamenActual.PrecioLista - tipoExamenActual.Seña).ToString("N0");
        }

        private string generarObservaciones(Entidades.TipoExamen te)
        {
            // Formato: [ObsExtra | ] [PLANILLA | ] $ {Promo} - $ {Seña} (SEÑA) | LISTA: $ {Lista} - SEÑA = $ {Lista - Seña}
            var sb = new System.Text.StringBuilder();

            // Prefijo extra (ej: "EXPRESS")
            if (!string.IsNullOrWhiteSpace(te.ObservacionesExtra))
                sb.Append(te.ObservacionesExtra.Trim() + " | ");

            // Indicador de planilla
            if (te.LlevaPlanilla)
                sb.Append("PLANILLA | ");

            decimal promo = (decimal)te.PrecioBase;
            decimal lista = (decimal)te.PrecioLista;
            decimal seña = (decimal)te.Seña;

            // Precio promo con seña
            if (seña > 0)
                sb.Append("$ " + promo.ToString("N0") + " - $ " + seña.ToString("N0") + " (SEÑA)");
            else
                sb.Append("$ " + promo.ToString("N0"));

            // Precio lista con seña
            if (lista > 0)
            {
                sb.Append(" | LISTA: $ " + lista.ToString("N0"));
                if (seña > 0)
                    sb.Append(" - SEÑA = $ " + (lista - seña).ToString("N0"));
            }

            return sb.ToString();
        }

        private double obtenerDoubleDesdeTextBox(string texto, double valorDefault)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return valorDefault;

            double valor;
            // Intento directo: maneja "103300" y "103.300" (miles en es-AR) y "103,300" (miles en en-US)
            if (double.TryParse(texto, System.Globalization.NumberStyles.Any,
                                 System.Globalization.CultureInfo.CurrentCulture, out valor))
                return valor;

            // Fallback: quitar separadores de miles (. y ,) y parsear como entero
            string sinMiles = texto.Replace(".", "").Replace(",", "").Trim();
            if (double.TryParse(sinMiles, out valor))
                return valor;

            return valorDefault;
        }

        private void botEditarExamenPreventiva_Click(object sender, EventArgs e)
        {
            editarExamenPreventiva();
        }

        private void editarExamenPreventiva()
        {
            frmTipoExamen fTipoExamen = new frmTipoExamen(tipoExamenActual);
            fTipoExamen.objDelegateDevolverTipoExamen = new frmTipoExamen.DelegateDevolverTipoExamen(cargarTipoExamenPreventiva);
            fTipoExamen.Size = new Size(1400, 800);
            fTipoExamen.ShowDialog();
        }

        private void cargarTipoExamenPreventiva(Entidades.TipoExamen tipoEx)
        {
            tipoExamenActual = tipoEx;
            tbIdTipoExamenPreventiva.Text = tipoEx.IdTipoExamenPaciente.ToString();
            tbImportePreventiva.Text = (tipoEx.PrecioBase - tipoEx.Seña).ToString("N0");
            tbImporteListaPreventiva.Text = (tipoEx.PrecioLista - tipoEx.Seña).ToString("N0");
            tbSeñaPreventiva.Text = tipoEx.Seña.ToString("N0");
            tbExamenPreventiva.Text = tipoEx.Descripcion;
            if (tipoEx.Modificado)
            {
                tbExamenPreventiva.Text = tbExamenPreventiva.Text + " MODIF.";
            }
            resaltarPrecioActivoPreventiva(tipoEx.UsarPrecioLista);
        }

        private void botLiberar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows[dgv.CurrentCell.RowIndex].Cells[8].Value.ToString() == "")
            {
                SQLConnector.EjecutarConsulta(
                    "UPDATE [dbo].[Turno] " +
                    "SET estadoID = '1737e61f-b256-40f5-8b57-63369638536d' " +
                    "WHERE id = '" + dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'"
                );
                cargarGrillaTurnosSinFiltro();
            }
            else
            {
                // Verifica si el turno tiene exámenes asociados
                string idTurno = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
                bool blnTieneExamenes = turno.TurnoTieneAsociadoExamen(idTurno);
                if (blnTieneExamenes)
                {
                    // Busca todos los exámenes de paciente asociados a este turno
                    DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(
                        "SELECT id FROM dbo.TipoExamenDePaciente WHERE idTurno = '" + idTurno + "'"
                    );
                    foreach (DataRow row in dt.Rows)
                    {
                        Guid idTipoExamenDePaciente = new Guid(row["id"].ToString());
                        // Elimina los ítems asociados
                        SQLConnector.EjecutarConsulta("DELETE FROM EstudiosPorExamenItem WHERE idTipoExamen = '" + idTipoExamenDePaciente + "'");
                        // Elimina el examen de paciente
                        SQLConnector.EjecutarConsulta("DELETE FROM TipoExamenDePaciente WHERE id = '" + idTipoExamenDePaciente + "'");
                    }
                }
                liberarTurno();
            }
        }
        private void liberarTurno()
        {
            if (dgv.CurrentCell != null && turnoAsignado(dgv.CurrentCell.RowIndex))
            {
                DialogResult result = MessageBox.Show("El turno seleccionado va a ser liberado, ¿Quiere continuar con la acción?", "Liberar Turno",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    procesarLiberacionTurno();
                }
            }
        }

        private void procesarLiberacionTurno()
        {
            char tipoTurno = turno.verificarTipoTurno(new Guid(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString()));
            bool blnTieneExamenes = turno.TurnoTieneAsociadoExamen(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString());

            if (tipoTurno == 'P' && !blnTieneExamenes)
            {
                liberarTurnoPreventiva();
            }
            else if (tipoTurno == 'L' && !blnTieneExamenes)
            {
                liberarTurnoLaboral();
            }
        }

        private void liberarTurnoPreventiva()
        {
            Entidades.Resultado result = turno.liberarTurnoPreventiva(llenarEntidadPreventiva());
            analizarLiberacionTurno(result);
        }

        private void liberarTurnoLaboral()
        {
            Entidades.Resultado result = turno.liberarTurnoLaboral(llenarEntidadLaboral());
            analizarLiberacionTurno(result);
        }

        private void analizarLiberacionTurno(Entidades.Resultado resultado)
        {
            if (resultado.Modo == 1)
            {
                nroFila = dgv.CurrentCell.RowIndex;
                nroColumna = dgv.CurrentCell.ColumnIndex;
                MessageBox.Show("¡Turno liberado correctamente!", "Liberar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                modoConsulta();
                cargarGrillaTurnosSinFiltro();
                cargarTurnoSeleccionado();
            }
            else
            {
                MessageBox.Show("¡No se puede liberar el turno seleccionado!\nError: " + resultado.Mensaje, "Liberar Turno",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool turnoLibre(int index)
        {
            return verificarEstado(index, "1");
        }

        private bool turnoAsignado(int index)
        {
            return verificarEstado(index, "2");
        }

        private bool turnoBloqueado(int index)
        {
            return verificarEstado(index, "3");
        }

        private bool turnoReservado(int index)
        {
            return verificarEstado(index, "4");
        }

        private bool verificarEstado(int index, string codigo)
        {
            test = dgv.Rows[index].Cells[18].Value.ToString();  // ✅ Cambiar de 17 a 18
            test = dgv.Rows[index].Cells[18].Value.ToString();
            if (dgv.Rows[index].Cells[18].Value.ToString() == codigo)  // ✅ Cambiar de 17 a 18
            {
                return true;
            }
            return false;
        }

        private void botHabilitar_Click(object sender, EventArgs e)
        {
            int intFila = dgv.CurrentCell.RowIndex;
            habilitarTurnos();
            dgv.Rows[intFila].Selected = true;
            dgv.CurrentCell = dgv.Rows[intFila].Cells[1];
        }

        private void habilitarTurnos()
        {
            MessageBox.Show("Aviso: Los turnos seleccionados van hacer habilitados",
                "Habilitar Turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach (DataGridViewRow dgvR in dgv.SelectedRows)
            {
                if (turnoBloqueado(dgvR.Index))
                {
                    turno.habilitarTurno(new Guid(dgvR.Cells[0].Value.ToString()));
                }
            }
            cargarGrillaTurnosSinFiltro();
        }

        private void botInhabilitar_Click(object sender, EventArgs e)
        {
            int intFila = dgv.CurrentCell.RowIndex;

            List<int> filasLibres = new List<int>();
            foreach (DataGridViewRow dgvR in dgv.SelectedRows)
            {
                if (turnoLibre(dgvR.Index))
                    filasLibres.Add(dgvR.Index);
            }

            nroFila = intFila;
            nroColumna = 1;
            inhabilitarTurnos();

            foreach (int fila in filasLibres)
            {
                if (fila < dgv.Rows.Count)
                    dgv.Rows[fila].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            }

            dgv.Rows[intFila].Selected = true;
            dgv.CurrentCell = dgv.Rows[intFila].Cells[1];
        }

        private void inhabilitarTurnos()
        {
            MessageBox.Show("Aviso: Se van a inhabilitar los turnos seleccionados que estén libres",
                "Inhabilitar Turnos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            System.Diagnostics.Debug.WriteLine($"[INHABILITAR] inhabilitarTurnos() | Total filas seleccionadas: {dgv.SelectedRows.Count}");
            foreach (DataGridViewRow dgvR in dgv.SelectedRows)
            {
                string estadoFila = dgvR.Cells[18].Value?.ToString() ?? "null";
                bool esLibre = turnoLibre(dgvR.Index);
                System.Diagnostics.Debug.WriteLine($"[INHABILITAR] Fila {dgvR.Index} | ID: {dgvR.Cells[0].Value} | Estado col18: {estadoFila} | turnoLibre: {esLibre}");
                if (esLibre)
                {
                    turno.inhabilitarTurno(new Guid(dgvR.Cells[0].Value.ToString()));
                    System.Diagnostics.Debug.WriteLine($"[INHABILITAR] ✅ inhabilitarTurno() llamado para fila {dgvR.Index}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[INHABILITAR] ❌ Fila {dgvR.Index} NO es libre, no se inhabilita");
                }
            }
            cargarGrillaTurnosSinFiltro();
        }

        private void botEditarPacienteLaboral_Click(object sender, EventArgs e)
        {
            editarPacienteLaboral();
        }

        private void editarPacienteLaboral()
        {
            frmPacienteLaboral fPaciente = new frmPacienteLaboral();
            fPaciente.cargarPacienteEspecifico(tbIdEmpresaLaboral.Text, tbIdPacienteLaboral.Text);
            fPaciente.objDelegateDevolverID = new frmPacienteLaboral.DelegateDevolverID(recargarDatosPacienteLaboral);
            fPaciente.ShowDialog();
        }

        private void recargarDatosPacienteLaboral(string idPaciente, string idEmpresa)
        {
            string strFecha = "";
            Entidades.TurnoLaboral turnoLab = turno.recargarDatoPacienteLaboral(idPaciente, idEmpresa);
            tbPacienteLaboral.Text = turnoLab.ApellidoNombre;
            tbDniLaboral.Text = turnoLab.Dni;
            tbCuilLaboral.Text = turnoLab.Cuil;
            tbIdEmpresaLaboral.Text = turnoLab.IdEmpresa.ToString();
            tbEmpresaLaboral.Text = turnoLab.Empresa;
            tbTareaLaboral.Text = turnoLab.Tarea;
            tbTelefonoLaboral.Text = turnoLab.Telefono;
            strFecha = turnoLab.FechaNacimiento.ToString("dd/MM/yyyy");
            if (strFecha != "01/01/0001")
            {
                txtFNacLab.Text = turnoLab.FechaNacimiento.ToString("dd/MM/yyyy");
                txtEdadLab.Text = (DateTime.Today.AddTicks(-turnoLab.FechaNacimiento.Ticks).Year - 1).ToString();
            }
            else
            {
                txtFNacLab.Text = "";
                txtEdadLab.Text = "0";
            }

        }

        private void botEditarPacientePreventiva_Click(object sender, EventArgs e)
        {
            editarPacientePreventiva();
        }

        private void editarPacientePreventiva()
        {
            frmPaciente fPaciente = new frmPaciente(new Configuracion(), true);
            fPaciente.mostarDatosDni(tbDniPreventiva.Text);
            fPaciente.objDelegateDevolverID = new frmPaciente.DelegateDevolverID(recargarDatosPacientePreventiva);
            fPaciente.ShowDialog();
        }

        private void recargarDatosPacientePreventiva(string idPaciente)
        {
            Entidades.TurnoPreventiva entidad = turno.recargarDatoPacientePreventiva(idPaciente);
            dgvLigaYClub.DataSource = entidad.LigaClub;
            ((DataGridViewImageColumn)dgvLigaYClub.Columns[1]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            ((DataGridViewImageColumn)dgvLigaYClub.Columns[1]).DefaultCellStyle.BackColor = System.Drawing.Color.Transparent;
            tbDniPreventiva.Text = entidad.Dni;
            tbPacientePreventiva.Text = entidad.ApellidoNombre;
            tbCategoriaPreventiva.Text = entidad.Nacimiento.Year.ToString();
            tbTelefonoPreventiva.Text = entidad.Telefono;
            txtEmail.Text = entidad.Mail;
            txtEdad.Text = (DateTime.Today.AddTicks(-entidad.Nacimiento.Ticks).Year - 1).ToString();
        }

        private void tpFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            rbHoraTodas.Checked = true;
            cargarGrillaTurnosSinFiltro();
        }

        private void botReservar_Click(object sender, EventArgs e)
        {
            LimpiaVariableDatos(); // Limpia variables publicas

            if (!VerificaIDTurnoLibre())
                reservarTurno();
            else
            {
                MessageBox.Show("Este turno se encuentra reservado. Por favor seleccione otro turno", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cargarGrillaTurnosSinFiltro();
            }

        }

        private void botLiberarReserva_Click(object sender, EventArgs e)
        {
            liberarReserva();
        }

        private void reservarTurno()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                frmReservaTurno fReserva = new frmReservaTurno();
                fReserva.objDelegateDevolverReserva = new frmReservaTurno.DelegateDevolverReserva(asignarReserva);
                fReserva.ShowDialog();
            }
        }

        private void liberarReserva()
        {
            DialogResult drResultado;

            drResultado = MessageBox.Show("¿Está seguro que desea liberar la reserva?", "Liberar reserva turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (drResultado == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow dgvR in dgv.SelectedRows)
                {

                    if (turnoReservado(dgvR.Index))
                    {
                        turno.liberarReservaTurno(new Guid(dgvR.Cells[0].Value.ToString()));
                    }
                }

                cargarGrillaTurnosSinFiltro();
            }
        }

        private void asignarReserva(string destinatario)
        {
            if (!VerificaIDTurnoLibre())
            {
                foreach (DataGridViewRow dgvR in dgv.SelectedRows)
                {
                    if (turnoLibre(dgvR.Index))
                    {
                        //turno.reservarTurno(new Guid(dgvR.Cells[0].Value.ToString()), dgvR.Cells[16].Value.ToString(), destinatario);
                        turno.reservarTurno(new Guid(dgvR.Cells[0].Value.ToString()), destinatario);
                    }
                }
            }
            else
            {
                MessageBox.Show("Este turno se encuentra reservado. Por favor seleccione otro turno", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cargarGrillaTurnosSinFiltro();
        }

        private void cambiarHabilitacionBotonesHora()
        {
            deshabilitarTodosLosBotonesHora();
            List<string> horasDisponibles = new List<string>();
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (!horasDisponibles.Contains(r.Cells[4].Value.ToString()))
                {
                    horasDisponibles.Add(r.Cells[4].Value.ToString());
                }
            }
            if (horasDisponibles.Count > 0) { rbHoraTodas.Enabled = true; }
            cambiarHabilitacionBotonHora(horasDisponibles, rbHora8, "08:00");
            cambiarHabilitacionBotonHora(horasDisponibles, rbHora9, "09:00");
            cambiarHabilitacionBotonHora(horasDisponibles, rbHora10, "10:00");
            cambiarHabilitacionBotonHora(horasDisponibles, rbHora11, "11:00");
            cambiarHabilitacionBotonHora(horasDisponibles, rbHora12, "12:00");
            cambiarHabilitacionBotonHora(horasDisponibles, rbHora13, "13:00");
            cambiarHabilitacionBotonHora(horasDisponibles, rbHora14, "14:00");
            cambiarHabilitacionBotonHora(horasDisponibles, rbHora15, "15:00");
            cambiarHabilitacionBotonHora(horasDisponibles, rbHora16, "16:00");
        }

        private void deshabilitarTodosLosBotonesHora()
        {
            rbHoraTodas.Enabled = false;
            rbHora8.Enabled = false;
            rbHora9.Enabled = false;
            rbHora10.Enabled = false;
            rbHora11.Enabled = false;
            rbHora12.Enabled = false;
            rbHora13.Enabled = false;
            rbHora14.Enabled = false;
            rbHora15.Enabled = false;
            rbHora16.Enabled = false;
        }

        private void cambiarHabilitacionBotonHora(List<string> horasDisponibles,
            RadioButton bot, string hora)
        {
            bot.Enabled = false;
            foreach (string horaString in horasDisponibles)
            {
                int horaLista = Convert.ToDateTime(horaString).Hour;
                int horaBoton = Convert.ToDateTime(hora).Hour;
                if (horaLista == horaBoton)
                {
                    bot.Enabled = true;
                }
            }
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            if (tbFiltro.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor ingrese un DNI o nombre", "Búsqueda Vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                cargarGrillaTurnoConFiltro();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cargarGrillaTurnoConFiltro()
        {
            string filtro = tbFiltro.Text.Trim();

            if (EsDNI(filtro))
            {
                // Buscar por DNI
                llenarDgv(turno.buscarTurnosPorDNI(filtro));
            }
            else
            {
                // Buscar por Nombre
                llenarDgv(turno.buscarTurnosPorNombre(filtro));
            }
        }
        /// <summary>
        /// Método mejorado para buscar turnos por DNI o Nombre
        /// Identifica automáticamente el tipo de búsqueda según el criterio
        /// </summary>
        private void buscarTurnosPorDNIONombre()
        {
            if (tbFiltro.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor ingrese un DNI o nombre para buscar", "Búsqueda Vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string filtro = tbFiltro.Text.Trim();
                DataTable resultado = null;

                // Validar si es DNI (solo números) o Nombre
                if (EsDNI(filtro))
                {
                    // Buscar por DNI
                    resultado = turno.buscarTurnosPorDNI(filtro);
                    if (resultado == null || resultado.Rows.Count == 0)
                    {
                        MessageBox.Show($"No se encontraron turnos para el DNI: {filtro}", "Sin Resultados",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Buscar por Nombre
                    resultado = turno.buscarTurnosPorNombre(filtro);
                    if (resultado == null || resultado.Rows.Count == 0)
                    {
                        MessageBox.Show($"No se encontraron turnos para el nombre: {filtro}", "Sin Resultados",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (resultado != null && resultado.Rows.Count > 0)
                {
                    llenarDgv(resultado);
                }
                else
                {
                    llenarDgv(new DataTable()); // Mostrar grilla vacía
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la búsqueda: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Valida si el string es un DNI válido (solo dígitos)
        /// </summary>

        private bool EsDNI(string valor)
        {
            valor = valor.Replace(" ", "");
            if (valor.Length >= 7 && valor.Length <= 8)
            {
                return valor.All(char.IsDigit);
            }
            return false;
        }

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            tbFiltro.Clear();
            cargarGrillaTurnosSinFiltro();
        }

        private void botAsignar_Click(object sender, EventArgs e)
        {
            DataGridView dgvUso = dgv;
            // GRV - Modificado
            // asignar();
            LimpiaVariableDatos();

            // No permitir asignar si el turno no está libre (estado 1)
            if (!turnoLibre(dgv.CurrentCell.RowIndex))
            {
                MessageBox.Show("El turno seleccionado no está disponible para asignar.",
                    "Turno no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!VerificaIDTurnoLibre())
            {
                int index = dgv.CurrentCell.RowIndex;
                SQLConnector.EjecutarConsulta(
                    "UPDATE [dbo].[Turno] " +
                    "SET estadoID = '8f85032b-b03d-406d-a050-a9436aed0703' " +
                    "WHERE id = '" + dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'"
                );
                dgv.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                asignar();

            }
            else
            {
                MessageBox.Show("Alguien mas esta dando este turno, Comuniquese con su compañero");
                cargarGrillaTurnosSinFiltro();
            }
        }

        private void botProxFechaLibre_Click(object sender, EventArgs e)
        {
            obtenerProximaFechaLibre();
        }

        private void obtenerProximaFechaLibre()
        {
            DateTime diaSiguiente = tpFecha.SelectionStart.AddDays(1);
            rbEstadoLibres.Checked = true;
            rbHoraTodas.Checked = true;
        inicio:
            llenarDgv(turno.cargarTurnos(obtenerTipoExamen(), diaSiguiente, obtenerHora(), obtenerEstado()));
            if (dgv.Rows.Count == 0)
            {
                diaSiguiente = diaSiguiente.AddDays(1);
                if (diaSiguiente <= DateTime.Today.AddDays(60))
                {
                    goto inicio;
                }
                else
                {
                    MessageBox.Show("¡No se encontraron turnos libres dentro de los 60 días posteriores a la fecha actual!",
                        "Próxima Fecha Libre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (diaSiguiente <= DateTime.Today.AddDays(60))
                {
                    tpFecha.SelectionStart = diaSiguiente;
                }
                else
                {
                    MessageBox.Show("¡No se encontraron turnos libres dentro de los 60 días posteriores a la fecha actual!",
                       "Próxima Fecha Libre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (botAsignar.Visible) { botAsignar.PerformClick(); }
                if (botModificar.Visible) { botModificar.PerformClick(); }
            }
        }

        private void tbFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buscarTurnosPorDNIONombre();
            }
        }

        // GRV - Ramírez Llamar a propiedaes del formulario turnos
        public void ProcesoConsultorio(string idPaciente, string idEmpresa, DateTime fechaTurno)
        {
            strIDPaciente = idPaciente;
            strIDEmpresa = idEmpresa;
            blnConsultaExterna = true;
            tpFecha.SetDate(fechaTurno);
            cboTipoExamen.SelectedIndex = 7;   // Propiedad .Text = CONSULTORIO
            obtenerTipoExamen();
            rbEstadoLibres.Checked = true;
            dgv.CurrentCell = this.dgv[8, 0];

            asignar();
            guardar();

            // limpiar variables
            blnConsultaExterna = false;
            strIDEmpresa = "";
            strIDPaciente = "";
        }

        public void ProcesoConsultorioMuestraTurno(string idPaciente, string idEmpresa, DateTime fechaTurno)
        {
            strIDPaciente = idPaciente;
            strIDEmpresa = idEmpresa;
            blnConsultaExterna = true;
            tpFecha.SetDate(fechaTurno);
            cboTipoExamen.SelectedIndex = 7;   // Propiedad .Text = CONSULTORIO
            obtenerTipoExamen();
            rbEstadoAsignados.Checked = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SeleccionarFila(idPaciente);

            // limpiar variables
            blnConsultaExterna = false;
            strIDEmpresa = "";
            strIDPaciente = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeleccionarFila(string idPaciente)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                // ✅ CAMBIAR de [6] a [7]
                if (idPaciente == dgv.Rows[i].Cells[7].Value.ToString())
                {
                    dgv.Rows[i].Selected = true;
                    dgv.CurrentCell = this.dgv[8, i];
                }
            }
        }

        // GRV - Ramírez permite que el último registro de muestre en pantalla
        private void CargarDatosMatrizTemp()
        {
            //for (int i = 1; i < 13; i++)
            //{
            //    strUltRegistro[i] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[i].Value.ToString();
            //}

            strUltRegistro[0] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
            strUltRegistro[1] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value.ToString();
            strUltRegistro[2] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value.ToString();
            strUltRegistro[3] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[3].Value.ToString();
            strUltRegistro[4] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[4].Value.ToString();
            strUltRegistro[5] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[5].Value.ToString();
            strUltRegistro[10] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[10].Value.ToString();
            strUltRegistro[11] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[11].Value.ToString();
            strUltRegistro[12] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[12].Value.ToString();
            strUltRegistro[13] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[13].Value.ToString();
            strUltRegistro[14] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[14].Value.ToString();
            strUltRegistro[15] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[15].Value.ToString();
            strUltRegistro[16] = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[16].Value.ToString();
            strUltRegistro[17] = "2";
            intFilaSeleccionada = dgv.CurrentCell.RowIndex;
        }

        private void MostrarUltimoRegistro()
        {
            //if (rbEstadoLibres.Checked == true)
            //{
            lblTipoExamen.Text = strUltRegistro[1];
            lblFecha.Text = strUltRegistro[3];
            lblHora.Text = strUltRegistro[4];
            lblDNI.Text = strUltRegistro[7];
            lblNombre.Text = strUltRegistro[8];
            lblCodigo.Text = strUltRegistro[10];

            //dgv.Rows.Insert(intFilaSeleccionada,
            //    strUltRegistro[0],
            //    strUltRegistro[1],
            //    strUltRegistro[2],
            //    strUltRegistro[3],
            //    strUltRegistro[4],
            //    strUltRegistro[5],
            //    strUltRegistro[6],
            //    strUltRegistro[7],
            //    strUltRegistro[8],
            //    strUltRegistro[9],
            //    strUltRegistro[10],
            //    strUltRegistro[11],
            //    strUltRegistro[12],
            //    strUltRegistro[13],
            //    strUltRegistro[14],
            //    strUltRegistro[15],
            //    strUltRegistro[16],
            //    strUltRegistro[17]);

            ////for (int i = 1; i < 13; i++)
            ////{
            ////    dgv.Rows[dgv.CurrentCell.RowIndex].Cells[i].Value = strUltRegistro[i];
            ////}

            //dgv.Rows[intFilaSeleccionada].DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
            ////dgv.CurrentCell = dgv[8, intFilaSeleccionada];
            //dgv.CurrentCell = dgv[8, dgv.CurrentCell.RowIndex];
            //dgv.Rows[dgv.CurrentCell.RowIndex].Selected = false;
            //dgv.Rows[intFilaSeleccionada].Selected = false;
            //dgv.MultiSelect = false;
            //blnRecargaGrilla = true;                
            //}
            //else
            //{
            blnRecargaGrilla = false;
            //}
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //LimpiarUltimoRegistroIngresado();
            //if (blnRecargaGrilla == true && rbEstadoLibres.Checked == true)
            //{
            //    //rbEstadoAsignados.Checked = true;
            //    //rbEstadoLibres.Checked = true;
            //    LimpiarUltimoRegistroIngresado();
            //    cargarGrillaTurnosSinFiltro();
            //    //blnRecargaGrilla = false;
            //}
        }

        private void LimpiarUltimoRegistroIngresado()
        {
            //blnRecargaGrilla = false;
            //dgv.Rows[intFilaSeleccionada].Cells[7].Value = "";
            //dgv.Rows[intFilaSeleccionada].Cells[8].Value = "";
            //dgv.Rows[intFilaSeleccionada].Cells[9].Value = "";            
            //dgv.Rows[intFilaSeleccionada].Selected = false;

            //dgv.Rows[intFilaSeleccionada].DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
            lblTipoExamen.Text = "";
            lblFecha.Text = "";
            lblHora.Text = "";
            lblDNI.Text = "";
            lblNombre.Text = "";
            lblCodigo.Text = "";

            try
            {
                //dgv.Rows.RemoveAt(intFilaSeleccionada);
            }
            catch (InvalidOperationException ex)
            { }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (blnRecargaGrilla == true && rbEstadoLibres.Checked == true)
            {
                //rbEstadoAsignados.Checked = true;
                //rbEstadoLibres.Checked = true;
                LimpiarUltimoRegistroIngresado();
                cargarGrillaTurnosSinFiltro();
                dgv.MultiSelect = true;
                //blnRecargaGrilla = false;
            }
        }

        private bool PacienteTieneTurno(string IdPaciente, string NombrePaciente, string DNI, string IdEmpresa = null)
        {
            bool blnEstado = false;
            DataTable dtConsulta;
            DialogResult drResultado;
            string strMensaje = "\n\n";

            dtConsulta = turno.PacienteTieneTurnoAsignado(obtenerFecha(), IdPaciente, IdEmpresa);

            if (dtConsulta.Rows.Count > 0)
            {
                strMensaje += "Nombre: " + NombrePaciente;
                strMensaje += "\nDni: " + DNI;
                strMensaje += "\nTipoExamen: " + dtConsulta.Rows[0][1].ToString();
                strMensaje += "\nHora: " + dtConsulta.Rows[0][3].ToString();
                strMensaje += "\nFecha: " + Convert.ToDateTime(dtConsulta.Rows[0][2].ToString()).ToShortDateString();
                strMensaje += "\n\n¿Desea asignar un turno de todos modos.?";

                drResultado = MessageBox.Show("El paciente ya tiene asignado un turno..." + strMensaje, "Asignar turnos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResultado == DialogResult.Yes)
                    blnEstado = false;
                else
                {
                    blnEstado = true;
                    cargarGrillaTurnosSinFiltro();
                }
            }

            return blnEstado;
        }

        private bool VerificaIDTurnoLibre()
        {
            bool blnLibre = false;
            DataTable dtConsulta;
            string strMensaje = "";

            try
            {
                DateTime fechaTurno;
                if (!DateTime.TryParse(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[3].Value.ToString(), out fechaTurno))
                {
                    fechaTurno = DateTime.Now;
                }

                dtConsulta = turno.VerificaIDTurnoLibre(
                    dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString(),
                    fechaTurno,
                    dgv.Rows[dgv.CurrentCell.RowIndex].Cells[7].Value.ToString());  // ✅ CORRECTO [7]

                if (dgv.Rows[dgv.CurrentCell.RowIndex].Cells[18].Value.ToString() == "1")
                {
                    if (dtConsulta.Rows.Count > 0 && dtConsulta.Rows[0][3].ToString() == "8f85032b-b03d-406d-a050-a9436aed0703")
                    {
                        blnLibre = true;
                    }

                    if (!string.IsNullOrEmpty(strIdPaciente))
                        blnLibre = PacienteTieneTurno(strIdPaciente, strApellido, strDNI);
                }

                if (verificaTurnoReservado(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString()))
                    blnLibre = true;

                LimpiaVariableDatos();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en VerificaIDTurnoLibre: {ex.Message}");
                blnLibre = false;
            }

            return blnLibre;
        }
        private bool VerificaCategoriaPacienteInicial(string strDNIpaciente)
        {
            bool blnCorresponde = false;
            CapaNegocioMepryl.PacientePreventiva PacientePre = new CapaNegocioMepryl.PacientePreventiva();
            int intAnioCatInicial = 0;
            int intAnioCatFinal = 0;
            int intCatPaciente = 0;

            intAnioCatInicial = PacientePre.AnioCategoriaInfantil("345FFF9B-45C2-4CD5-87EC-47E944E8236D");
            intAnioCatFinal = PacientePre.AnioCategoriaJuvenil("345FFF9B-45C2-4CD5-87EC-47E944E8236D");
            intCatPaciente = PacientePre.CategoriaPaciente(strDNIpaciente);

            if ((intAnioCatInicial >= intCatPaciente) && (intCatPaciente >= intAnioCatFinal))
                blnCorresponde = true;

            return blnCorresponde;
        }

        private void LimpiaVariableDatos()
        {
            strIdPaciente = string.Empty;
            strDNI = string.Empty;
            strApellido = string.Empty;
        }

        private void frmTurnos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && botAceptar.Visible)
            {
                botAceptar.PerformClick();
            }
            else if (e.KeyCode == Keys.F10 && botCancelar.Visible)
            {
                botCancelar.PerformClick();
            }
        }

        private void InhabilitaErgometrias()
        {
            int intTotalErgometrias = turno.TotalErgometrias(obtenerFecha());
            int intTotalBuzos = turno.TotalBuzos(obtenerFecha());

            if (intTotalErgometrias > 0)
            {
                // Permite Inhabilitar Turnos 
                // intTotalErgometrias--;
                //turno.inhabilitarTurno(new Guid(turno.ObtenerAlAzarIdErgometria(obtenerFecha())));
                MessageBox.Show("Hay " + intTotalErgometrias + " turnos disponibles de Ergometría para la fecha " + obtenerFecha().ToShortDateString(), "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Se ha excedido en " + intTotalBuzos + " los turnos de Ergometría para la fecha " + obtenerFecha().ToShortDateString(), "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool verificaTurnoReservado(string idTurno)
        {
            string strNombrePacienteReserva = "";
            bool blnReservado = false;

            strNombrePacienteReserva = turno.TurnoReservado(idTurno);

            if (!string.IsNullOrEmpty(strNombrePacienteReserva))
            {
                MessageBox.Show("Este turno se encuentra reservado para " + strNombrePacienteReserva + "\nPor favor seleccione otro turno", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                blnReservado = true;
            }

            return blnReservado;
        }

        private void bbiExamenLaboral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botEditarExamenLaboral_Click(sender, e);
        }

        private void bbiEditarPreventiva_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botEditarPacientePreventiva_Click(sender, e);
        }

        private void bbiExamenPreventiva_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botEditarExamenPreventiva_Click(sender, e);
        }

        private void bbiReservar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botReservar_Click(sender, e);
        }

        private void bbiLiberar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botLiberarReserva_Click(sender, e);
        }

        private void bbiHabilitar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botHabilitar_Click(sender, e);
        }

        private void bbiInhabilitar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botInhabilitar_Click(sender, e);
        }

        private void frmTurnos_Load(object sender, EventArgs e)
        {
            rbcMenu.Minimized = true;
            rbcMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
        }

        private void bbiEditarLaboral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            botEditarPacienteLaboral_Click(sender, e);
        }

        private void btnReservar01_Click(object sender, EventArgs e)
        {
            botReservar_Click(sender, e);
        }

        private void btnLiberar01_Click(object sender, EventArgs e)
        {
            botLiberarReserva_Click(sender, e);
        }

        private void btnHabilitar01_Click(object sender, EventArgs e)
        {
            botHabilitar_Click(sender, e);
        }

        private void btnInhabilitar01_Click(object sender, EventArgs e)
        {
            botInhabilitar_Click(sender, e);
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void CambiarColorEstados()
        {
            rbEstadoAsignados.BackColor = Color.FromArgb(235, 236, 239);
            rbEstadoLibres.BackColor = Color.FromArgb(235, 236, 239);
            rbEstadoTodos.BackColor = Color.FromArgb(235, 236, 239);

            if (rbEstadoAsignados.Checked == true)
                rbEstadoAsignados.BackColor = Color.LightYellow;
            if (rbEstadoLibres.Checked == true)
                rbEstadoLibres.BackColor = Color.LightYellow;
            if (rbEstadoTodos.Checked == true)
                rbEstadoTodos.BackColor = Color.LightYellow;
        }
        private void btnConfigurarTipoExamen_Click(object sender, EventArgs e)
        {
            using (var frm = new frmConfiguracionExamenRX2())
            {
                frm.ShowDialog(this);
            }
            // Al cerrar, recarga los combos y la grilla para reflejar los cambios
            cargarMotivoConsulta();
            cargarGrillaTurnosSinFiltro();
        }
        private void btnCopiarInfo_Click(object sender, EventArgs e)
        {
            CopiarTexto();
        }

        private void reemplazarTexto()
        {
            string strPaciente = "";
            string strHorario = "";
            string strFechaTurno = "";
            string strCodSeg = "";
            string strPrecio = "";
            string strIdSubtipo = "";
            DateTime dtDiaSemana;

            strPrecio = panelPacientePreventiva.Visible ? tbImportePreventiva.Text : tbImporteLaboral.Text;
            strHorario = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[5].Value.ToString();    // HORA [5]
            strFechaTurno = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[4].Value.ToString(); // FECHA [4]
            strCodSeg = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[11].Value.ToString();    // CODIGO [11]
            // Obtener nombre y apellido por separado si están disponibles
            string nombre = "";
            string apellido = "";
            if (dgv.Rows[dgv.CurrentCell.RowIndex].Cells[9].Value != null)
            {
                var pacienteCompleto = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[9].Value.ToString();
                // Si el formato es "APELLIDO, NOMBRE" lo separamos
                if (pacienteCompleto.Contains(","))
                {
                    var partes = pacienteCompleto.Split(',');
                    if (partes.Length >= 2)
                    {
                        apellido = partes[0].Trim();
                        nombre = partes[1].Trim();
                        strPaciente = nombre + " " + apellido;
                    }
                    else
                    {
                        strPaciente = pacienteCompleto.Trim();
                    }
                }
                else
                {
                    strPaciente = pacienteCompleto.Trim();
                }
            }
            strIdSubtipo = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[20].Value?.ToString() ?? ""; // IDSUBTIPO [20]

            dtDiaSemana = Convert.ToDateTime(strFechaTurno);
            strFechaTurno = dtDiaSemana.ToString("dddd", System.Globalization.CultureInfo.CreateSpecificCulture("es-ES")).ToUpper() + " " + strFechaTurno;

            RecuperarTextoPorSubtipo(strIdSubtipo);

            strTextoPlantilla = strTextoPlantilla.Replace("<<paciente>>", strPaciente)
                .Replace("<<nombre>>", nombre)
                .Replace("<<apellido>>", apellido)
                .Replace("<<FechaTurno>>", strFechaTurno)
                .Replace("<<horario>>", strHorario)
                .Replace("<<codseg>>", strCodSeg)
                .Replace("<<Precio>>", strPrecio);

            // DEBUG: Mostrar el mensaje final tras el reemplazo
            System.Diagnostics.Debug.WriteLine("[WhatsApp] Mensaje tras reemplazo:\n" + strTextoPlantilla);
        }

        private void CopiarTexto()
        {
            reemplazarTexto();
            Clipboard.SetDataObject(strTextoPlantilla);
            strTextoPlantilla = "";
        }

        private void RecuperarTextoPorSubtipo(string idSubtipo)
        {
            CapaNegocioMepryl.ConfigPlantillaReporte Reporte = new CapaNegocioMepryl.ConfigPlantillaReporte();

            // Buscar plantilla según tipo: Laboral o Preventiva
            string strPathArchivo;
            if (panelLaboral.Visible)
                strPathArchivo = Reporte.GetPathMensajePorSubtipoLaboral(idSubtipo);
            else
                strPathArchivo = Reporte.GetPathMensajePorSubtipo(idSubtipo);

            if (string.IsNullOrEmpty(strPathArchivo) || !System.IO.File.Exists(strPathArchivo))
            {
                strTextoPlantilla = "";
                MessageBox.Show("No hay plantilla de mensaje configurada para este subtipo de examen.\n\nConfigurala en: Configuración Mensaje → Mensaje Turnos.",
                    "Sin plantilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lee el archivo como UTF-8 y elimina el BOM si está presente
            strTextoPlantilla = System.IO.File.ReadAllText(strPathArchivo, Encoding.UTF8);
            if (!string.IsNullOrEmpty(strTextoPlantilla) && strTextoPlantilla[0] == '\uFEFF')
                strTextoPlantilla = strTextoPlantilla.Substring(1);
        }

        private void btnVerEstudio_Click(object sender, EventArgs e)
        {
            string strIdTurno = "";

            strIdTurno = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();

            frmAvisoExamenModificado fExamen = new frmAvisoExamenModificado(false);
            fExamen.cargarEstudiosSegunIdTurno(new Guid(strIdTurno));
            fExamen.ShowDialog();
        }

        private void pintarControlesPanelDeshabilitar()
        {
            tbDniPreventiva.BackColor = Color.WhiteSmoke;
            tbCategoriaPreventiva.BackColor = Color.WhiteSmoke;
            txtEdad.BackColor = Color.WhiteSmoke;
            tbPacientePreventiva.BackColor = Color.WhiteSmoke;
            tbTelefonoPreventiva.BackColor = Color.WhiteSmoke;
            txtEmail.BackColor = Color.WhiteSmoke;
            dgvLigaYClub.BackColor = Color.WhiteSmoke;
            tbExamenPreventiva.BackColor = Color.WhiteSmoke;
            tbImportePreventiva.BackColor = Color.WhiteSmoke;
            tbImporteListaPreventiva.BackColor = Color.WhiteSmoke;
            tbImporteListaPreventiva.ReadOnly = true;
            tbSeñaPreventiva.BackColor = Color.WhiteSmoke;
            tbSeñaPreventiva.ReadOnly = true;
            tbObservPreventiva.BackColor = Color.WhiteSmoke;
            tbObservPreventiva.ReadOnly = true;

            tbDniLaboral.BackColor = Color.WhiteSmoke;
            txtFNacLab.BackColor = Color.WhiteSmoke;
            txtEdadLab.BackColor = Color.WhiteSmoke;
            tbExamenLaboral.BackColor = Color.WhiteSmoke;
            tbEmpresaLaboral.BackColor = Color.WhiteSmoke;
            tbPacienteLaboral.BackColor = Color.WhiteSmoke;
            tbTareaLaboral.BackColor = Color.WhiteSmoke;
            tbTelefonoLaboral.BackColor = Color.WhiteSmoke;
            txtEmailLab.BackColor = Color.WhiteSmoke;
            tbImporteLaboral.BackColor = Color.WhiteSmoke;
            tbImporteListaLaboral.BackColor = Color.WhiteSmoke;
            tbImporteListaLaboral.ReadOnly = true;
            tbSeñaLaboral.BackColor = Color.WhiteSmoke;
            tbSeñaLaboral.ReadOnly = true;
            tbObservacionesLaboral.BackColor = Color.WhiteSmoke;
            tbObservacionesLaboral.ReadOnly = true;
        }

        private void pintarControlesPanelHabilitar()
        {
            tbDniPreventiva.BackColor = Color.White;
            tbCategoriaPreventiva.BackColor = Color.White;
            txtEdad.BackColor = Color.White;
            tbPacientePreventiva.BackColor = Color.White;
            tbTelefonoPreventiva.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            dgvLigaYClub.BackColor = Color.White;
            tbExamenPreventiva.BackColor = Color.White;
            tbImportePreventiva.BackColor = Color.White;
            tbImporteListaPreventiva.BackColor = Color.White;
            tbImporteListaPreventiva.ReadOnly = false;
            tbSeñaPreventiva.BackColor = Color.White;
            tbSeñaPreventiva.ReadOnly = false;
            tbObservPreventiva.BackColor = Color.White;
            tbObservPreventiva.ReadOnly = false;

            tbDniLaboral.BackColor = Color.White;
            txtFNacLab.BackColor = Color.White;
            txtEdadLab.BackColor = Color.White;
            tbExamenLaboral.BackColor = Color.White;
            tbEmpresaLaboral.BackColor = Color.White;
            tbPacienteLaboral.BackColor = Color.White;
            tbTareaLaboral.BackColor = Color.White;
            tbTelefonoLaboral.BackColor = Color.White;
            txtEmailLab.BackColor = Color.White;
            tbImporteLaboral.BackColor = Color.White;
            tbImporteListaLaboral.BackColor = Color.White;
            tbImporteListaLaboral.ReadOnly = false;
            tbSeñaLaboral.BackColor = Color.White;
            tbSeñaLaboral.ReadOnly = false;
            tbObservacionesLaboral.BackColor = Color.White;
            tbObservacionesLaboral.ReadOnly = false;
        }

        private void btnCancelarMover_Click(object sender, EventArgs e)
        {
            strIdTurnoAntiguoMover = "";
            strIdTurnoNuevoMover = "";
            strTipoExamenMover = "";
            btnMoverTurno.Text = "Mover\r\nTurno";
            btnMoverTurno.Image = Image.FromFile(@"P:\img-system\mCortar36x36.png");
            mostrarBotonesMoverTurno(false);
            blnActivoMoverTurno = false;
        }

        private void btnMoverTurno_Click(object sender, EventArgs e)
        {
            int FilaIndex = 1;
            string strTipoConsulta = "";
            bool blnPuedeAsignarTurno = false;

            if (btnMoverTurno.Text == "Mover\r\nTurno")
            {
                strIdTurnoAntiguoMover = dgv.CurrentRow.Cells[0].Value.ToString();
                strTipoExamenMover = dgv.CurrentRow.Cells[2].Value.ToString(); // SubTipo (correcto ✅)

                btnMoverTurno.Text = "Pegar\r\nTurno";
                btnMoverTurno.Image = Image.FromFile(@"P:\img-system\mPegar36x36.png");
                mostrarBotonesMoverTurno(true);
                blnActivoMoverTurno = true;
            }
            else
            {
                strTipoConsulta = turno.TipoConsulta(strIdTurnoAntiguoMover);

                if (strTipoExamenMover == dgv.CurrentRow.Cells[2].Value.ToString())
                {
                    blnPuedeAsignarTurno = true;
                }

                if (strTipoConsulta == "LABORAL" && blnPuedeAsignarTurno == false)
                {
                    switch (dgv.CurrentRow.Cells[1].Value.ToString()) // TipoPadre
                    {
                        case "PRE-OCUPACIONAL":
                        case "PERIODICOS":
                        case "EGRESO":
                            blnPuedeAsignarTurno = true;
                            break;
                        default:
                            blnPuedeAsignarTurno = false;
                            break;
                    }
                }
                else if (strTipoConsulta == "PREVENTIVA" && blnPuedeAsignarTurno == false)
                {
                    switch (dgv.CurrentRow.Cells[1].Value.ToString()) // TipoPadre
                    {
                        case "FUTBOL AFA":
                        case "FUTBOL LAFIJ":
                        case "FUTBOL METRO":
                            blnPuedeAsignarTurno = true;
                            break;
                        default:
                            blnPuedeAsignarTurno = false;
                            break;
                    }
                }

                if (blnPuedeAsignarTurno)
                {
                    // ✅ CORRECCIÓN: Cambiar [7] a [8] para verificar DNI
                    if (string.IsNullOrEmpty(dgv.CurrentRow.Cells[8].Value.ToString()))
                    {
                        strIdTurnoNuevoMover = dgv.CurrentRow.Cells[0].Value.ToString();

                        if (!string.IsNullOrEmpty(strIdTurnoNuevoMover))
                        {
                            DialogResult result01 = MessageBox.Show(
                                "El turno de " + strTipoExamenMover +
                                " va hacer movido a la fecha " + dgv.CurrentRow.Cells[4].Value.ToString() +
                                " con el tipo de examen " + dgv.CurrentRow.Cells[1].Value.ToString() +
                                ".\n\n¿Desea continuar?",
                                "Mover turno", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (result01 == DialogResult.Yes)
                            {
                                turno.MoverTurno(strIdTurnoAntiguoMover, strIdTurnoNuevoMover,
                                    dgv.CurrentRow.Cells[1].Value.ToString());

                                MessageBox.Show("¡Turno movido correctamente a la fecha " +
                                    dgv.CurrentRow.Cells[4].Value.ToString() + "!",
                                    "Mover turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                strIdTurnoAntiguoMover = "";
                                strIdTurnoNuevoMover = "";
                                strTipoExamenMover = "";
                                btnMoverTurno.Text = "Mover\r\nTurno";
                                btnMoverTurno.Image = Image.FromFile(@"P:\img-system\mCortar36x36.png");
                                mostrarBotonesMoverTurno(false);
                                blnActivoMoverTurno = false;
                                FilaIndex = dgv.CurrentCell.RowIndex;
                                cargarGrillaTurnosSinFiltro();
                                dgv.Rows[FilaIndex].Selected = true;
                                dgv.CurrentCell = dgv.Rows[FilaIndex].Cells[1];
                            }
                        }
                        else
                        {
                            MessageBox.Show("¡Debe seleccionar un turno en una fecha diferente!",
                                "Mover turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("¡Debe seleccionar un turno libre!",
                            "Mover turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string mensaje = strTipoConsulta == "LABORAL"
                        ? "¡Se puede mover el turno al mismo tipo de examen ó a los siguientes tipos de examen!\n\nTipo de examen:\n\n  * PRE-OCUPACIONAL\n  * PERIODICOS\n  * EGRESO "
                        : "¡Se puede mover el turno al mismo tipo de examen ó a los siguientes tipos de examen!\n\nTipo de examen:\n\n* FUTBOL AFA\n* FUTBOL LAFIJ\n* FUTBOL METRO ";

                    MessageBox.Show(mensaje, "Mover turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void mostrarBotonesMoverTurno(bool blnMostrarBoton)
        {
            if (blnMostrarBoton)
            {
                //botAsignar.Visible = false;
                botModificar.Visible = false;
                botLiberar.Visible = false;
                btnCopiarInfo.Visible = false;
                btnVerEstudio.Visible = false;
                btnMoverTurno.Visible = true;
                btnCancelarMover.Visible = true;
            }
            else
            {
                //botAsignar.Visible = true;
                botModificar.Visible = true;
                botLiberar.Visible = true;
                btnCopiarInfo.Visible = true;
                btnVerEstudio.Visible = true;
                btnMoverTurno.Visible = true;
                btnCancelarMover.Visible = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmHorario(((frmBasePrincipal)this.MdiParent).configuracion, CapaPresentacionBase.frmBaseGrillaABM.ModoApertura.CONSULTA_FICHA, false);
                frm.Size = new Size(1400, 700);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
                cargarGrillaTurnosSinFiltro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir frmHorario:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cargarMotivoConsulta()
        {
            DataTable dtMotivos = tipoEx.cargarMotivosDeConsultaTipoExamen();

            // Agregar opción "TODOS" al principio
            DataRow rowTodos = dtMotivos.NewRow();
            rowTodos["id"] = 0; // O usa Guid.Empty si el campo es GUID
            rowTodos["nombre"] = "TODOS";
            dtMotivos.Rows.InsertAt(rowTodos, 0);

            cboMotivoConsulta.DataSource = dtMotivos;
            cboMotivoConsulta.ValueMember = "id";
            cboMotivoConsulta.DisplayMember = "nombre";
            cboMotivoConsulta.SelectedIndex = 0; // Selecciona "TODOS" por defecto

            // Conectar el evento SelectionChangeCommitted si no está ya conectado
            cboMotivoConsulta.SelectionChangeCommitted -= cboMotivoConsulta_SelectionChangeCommitted;
            cboMotivoConsulta.SelectionChangeCommitted += cboMotivoConsulta_SelectionChangeCommitted;

            // Conectar eventos de los otros combos
            cboTipoExamen.SelectionChangeCommitted -= cboTipoExamen_SelectionChangeCommitted;
            cboTipoExamen.SelectionChangeCommitted += cboTipoExamen_SelectionChangeCommitted;

            cboSubTipoExamen.SelectionChangeCommitted -= cboSubTipoExamen_SelectionChangeCommitted;
            cboSubTipoExamen.SelectionChangeCommitted += cboSubTipoExamen_SelectionChangeCommitted;

            // Limpiar los otros combos
            cboTipoExamen.DataSource = null;
            cboSubTipoExamen.DataSource = null;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboMotivoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTipoExamen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboSubTipoExamen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LblTurnos_Click(object sender, EventArgs e)
        {

        }

        private void lblAsignados_Click(object sender, EventArgs e)
        {

        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {

        }
        private string LimpiarMensaje(string mensaje)
        {
            // Normaliza UTF-8
            byte[] bytes = Encoding.UTF8.GetBytes(mensaje);
            mensaje = Encoding.UTF8.GetString(bytes);

            // Elimina caracteres corruptos
            mensaje = mensaje.Replace("�", "");

            // Elimina caracteres invisibles problemáticos, pero CONSERVA saltos de línea (\n y \r)
            // Solo elimina los caracteres de control excepto \n (10) y \r (13)
            mensaje = System.Text.RegularExpressions.Regex.Replace(mensaje, "[\u0000-\u0009\u000B\u000C\u000E-\u001F\u007F]", "");

            return mensaje.Trim();


        }

        public async Task<bool> EnviarMensajeWhatsApp(string telefono, object mensajeObj)
        {
            using (var client = new HttpClient())
            {
                var url = "http://localhost:3000/enviar-mensaje";
                var payload = new { telefono = telefono, mensaje = mensajeObj };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // DEBUG: Mostrar el JSON enviado
                System.Diagnostics.Debug.WriteLine($"[WhatsApp] JSON enviado: {json}");

                var response = await client.PostAsync(url, content);
                var responseText = await response.Content.ReadAsStringAsync();

                // DEBUG: Mostrar la respuesta completa de la API
                System.Diagnostics.Debug.WriteLine($"[WhatsApp] StatusCode: {response.StatusCode}");
                System.Diagnostics.Debug.WriteLine($"[WhatsApp] Respuesta: {responseText}");

                return response.IsSuccessStatusCode;
            }

        }
        private async void btnWhatsApp_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Index < 0)
            {
                MessageBox.Show("Debe seleccionar un turno en la grilla para enviar el mensaje por WhatsApp.", "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string telefono = "";

            if (panelLaboral.Visible)
                telefono = tbTelefonoLaboral.Text;
            else if (panelPacientePreventiva.Visible)
                telefono = tbTelefonoPreventiva.Text;

            // Limpieza teléfono
            telefono = telefono.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            if (telefono.StartsWith("15"))
                telefono = telefono.Substring(2);

            if (telefono.StartsWith("0"))
                telefono = telefono.Substring(1);

            if (!telefono.StartsWith("549"))
                telefono = "549" + telefono;

            // DEBUG: Mostrar el número final en la salida de depuración
            System.Diagnostics.Debug.WriteLine($"[WhatsApp] Número a enviar: {telefono}");

            // Validación básica: el número debe tener al menos 11 dígitos (549 + cod área + número)
            if (telefono.Length < 13)
            {
                MessageBox.Show("El número de teléfono es demasiado corto. Debe incluir código de área.\nEjemplo: 2324518204 → 5492324518204", "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Genera mensaje
            reemplazarTexto();
            // DEBUG: Mostrar plantilla antes de limpiar
            System.Diagnostics.Debug.WriteLine("[WhatsApp] Plantilla antes de limpiar:\n" + strTextoPlantilla.Replace("\n", "[NL]\n"));
            strTextoPlantilla = LimpiarMensaje(strTextoPlantilla);
            // DEBUG: Mostrar plantilla después de limpiar
            System.Diagnostics.Debug.WriteLine("[WhatsApp] Plantilla después de limpiar:\n" + strTextoPlantilla.Replace("\n", "[NL]\n"));

            // Obtiene el idSubtipo de la grilla usando el nombre de columna
            string strIdSubtipo = "";
            if (dgv.CurrentRow != null && dgv.CurrentRow.Cells["IdSubtipo"] != null)
                strIdSubtipo = dgv.CurrentRow.Cells["IdSubtipo"].Value?.ToString() ?? "";

            // Obtiene la ruta del archivo de plantilla usando el idSubtipo
            var reporte = new CapaNegocioMepryl.ConfigPlantillaReporte();
            string rutaPlantilla = reporte.GetPathMensajePorSubtipo(strIdSubtipo);

            // Validar que la ruta no esté vacía y que el archivo exista
            if (string.IsNullOrEmpty(rutaPlantilla) || !System.IO.File.Exists(rutaPlantilla))
            {
                MessageBox.Show("No se encontró el archivo de mensaje para el subtipo seleccionado.", "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Forzar saltos de línea a \n (Unix-style para WhatsApp)
            System.Diagnostics.Debug.WriteLine("[WhatsApp] MENSAJE ANTES DE ENVIAR (saltos de línea visibles como [NL]):\n" + strTextoPlantilla.Replace("\n", "[NL]\n"));
            strTextoPlantilla = strTextoPlantilla.Replace("\r\n", "\n").Replace("\r", "\n");

            // SIEMPRE CONVERTIR A OBJETO ESTRUCTURADO PARA EL BUILDER DEL BACKEND
            object mensajeObj = ParsearPlantillaTxtAObjeto(strTextoPlantilla);

            // Si por algún motivo el "temporal" es string, forzar conversión a objeto
            if (mensajeObj is string textoPlano)
            {
                mensajeObj = ParsearPlantillaTxtAObjeto(textoPlano);
            }

            // DEBUG: Mostrar el objeto estructurado antes de enviarlo
            string debugMensajeObj = Newtonsoft.Json.JsonConvert.SerializeObject(mensajeObj, Newtonsoft.Json.Formatting.Indented);
            System.Diagnostics.Debug.WriteLine($"[WhatsApp] OBJETO ESTRUCTURADO A ENVIAR:\n{debugMensajeObj}");

            // Llama a la API REST enviando el objeto estructurado
            bool exito = await EnviarMensajeWhatsApp(telefono, mensajeObj);

            if (exito)
                MessageBox.Show("Mensaje enviado por WhatsApp correctamente.", "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error al enviar el mensaje por WhatsApp.", "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private object ParsearPlantillaTxtAObjeto(string plantillaTxt)
        {
            var lineas = plantillaTxt.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            string titulo = null;
            string cuerpo = null;
            var secciones = new List<object>();
            string pie = null;
            var items = new List<string>();
            string seccionActual = null;
            var textoSeccion = new List<string>();

            // Diccionario para acumular secciones únicas (normalizando encabezados)
            var seccionesUnicas = new Dictionary<string, (List<string> items, List<string> textos)>();
            // Función para normalizar encabezados de sección especial
            string QuitarTildes(string texto)
            {
                var conTildes = "áéíóúÁÉÍÓÚñÑ";
                var sinTildes = "aeiouAEIOUnN";
                var sb = new System.Text.StringBuilder(texto.Length);
                foreach (var c in texto)
                {
                    int idx = conTildes.IndexOf(c);
                    sb.Append(idx >= 0 ? sinTildes[idx] : c);
                }
                return sb.ToString();
            }

            string NormalizarSeccion(string encabezado)
            {
                var s = QuitarTildes(encabezado).ToUpper();
                s = s.Replace("_", "").Replace("*", "").Replace(":", "").Replace(" ", "").Replace("-", "");
                if (s.Contains("IMPORTANTE") && s.Contains("PADRES")) return "*IMPORTANTE Sres. Padres:*";
                if (s.Contains("IMPORTANTE")) return "*IMPORTANTE*";
                return encabezado.Trim();
            }

            foreach (var linea in lineas)
            {
                if (linea.StartsWith("📅"))
                {
                    titulo = linea.Trim();
                }
                // Forzar doble salto de línea antes y después de la duración del examen
                else if (linea.ToUpper().Contains("DURACION DEL EXAMEN"))
                {
                    if (cuerpo == null) cuerpo = "";
                    // Eliminar saltos de línea al final del texto anterior
                    cuerpo = cuerpo.TrimEnd('\n', '\r');
                    // Agregar dos saltos antes y dos después
                    cuerpo += "\n\n" + linea.Trim() + "\n\n";
                }
                else if (linea.StartsWith("💰") || linea.StartsWith("⛔") || linea.StartsWith("⏱"))
                {
                    if (cuerpo == null) cuerpo = "";
                    cuerpo += (cuerpo.Length > 0 ? "\n" : "") + linea.Trim();
                }
                // Forzar INDICACIONES en negrita
                else if (linea.ToUpper().Contains("INDICACIONES"))
                {
                    if (seccionActual != null && items.Count > 0)
                    {
                        var itemsLimpios = items.Select(i => i.Trim('*', ' ')).ToList();
                        secciones.Add(new { titulo = seccionActual, items = itemsLimpios.ToArray() });
                        items.Clear();
                    }
                    seccionActual = "*INDICACIONES:*";
                }
                else if (linea.StartsWith("▶️") || linea.StartsWith("✅"))
                {
                    if (seccionActual == "*INDICACIONES:*")
                    {
                        var textoSinEmoji = linea.Trim().Replace("▶️", "").Replace("✅", "").Trim();
                        textoSinEmoji = textoSinEmoji.Trim('*', ' ');
                        if (!string.IsNullOrEmpty(textoSinEmoji))
                            items.Add(textoSinEmoji);
                    }
                    else
                    {
                        var textoLimpio = linea.Trim().Trim('*', ' ');
                        items.Add(textoLimpio);
                    }
                }
                // Detectar cualquier variante de IMPORTANTE o IMPORTANTE Sres. Padres (con o sin emoji, con o sin formato)
                else if (
                    linea.ToUpper().Contains("IMPORTANTE SRES. PADRES") ||
                    linea.ToUpper().Contains("IMPORTANTE SRES PADRES") ||
                    linea.ToUpper().Contains("IMPORTANTE")
                )
                {
                    // Antes de cambiar de sección, acumula lo anterior si corresponde
                    if (seccionActual != null && (items.Count > 0 || textoSeccion.Count > 0))
                    {
                        var itemsLimpios = items.Select(i => i.Trim('*', ' ')).ToList();
                        var textoLimpio = string.Join("\n", textoSeccion.Select(t => t.Trim('*', ' ')));
                        var claveNormalizada = NormalizarSeccion(seccionActual);
                        if (claveNormalizada == "*IMPORTANTE*" || claveNormalizada == "*IMPORTANTE Sres. Padres:*")
                        {
                            if (!seccionesUnicas.ContainsKey(claveNormalizada))
                                seccionesUnicas[claveNormalizada] = (new List<string>(), new List<string>());
                            seccionesUnicas[claveNormalizada].items.AddRange(itemsLimpios);
                            if (!string.IsNullOrEmpty(textoLimpio))
                                seccionesUnicas[claveNormalizada].textos.Add(textoLimpio);
                        }
                        else
                        {
                            secciones.Add(new { titulo = seccionActual, items = itemsLimpios.ToArray(), texto = textoLimpio });
                        }
                        items.Clear(); textoSeccion.Clear();
                    }
                    // Normalizar el encabezado
                    var claveNueva = NormalizarSeccion(linea);
                    seccionActual = claveNueva;
                    var textoSinEmoji = linea.Trim().Replace("❗", "").Replace("🗣️", "").Replace("⚠️", "").Trim('*', ' ').Trim();
                    if (!string.IsNullOrEmpty(textoSinEmoji))
                        textoSeccion.Add(textoSinEmoji);
                }
                else if (linea.StartsWith("_*CLASIFICACION DE LOS RESULTADOS:*_"))
                {
                    if (seccionActual != null && (items.Count > 0 || textoSeccion.Count > 0))
                    {
                        var itemsLimpios = items.Select(i => i.Trim('*', ' ')).ToList();
                        var textoLimpio = string.Join(" ", textoSeccion.Select(t => t.Trim('*', ' ')));
                        if (seccionActual == "*IMPORTANTE*" || seccionActual == "*IMPORTANTE Sres. Padres:*")
                        {
                            if (!seccionesUnicas.ContainsKey(seccionActual))
                                seccionesUnicas[seccionActual] = (new List<string>(), new List<string>());
                            seccionesUnicas[seccionActual].items.AddRange(itemsLimpios);
                            if (!string.IsNullOrEmpty(textoLimpio))
                                seccionesUnicas[seccionActual].textos.Add(textoLimpio);
                        }
                        else
                        {
                            secciones.Add(new { titulo = seccionActual, items = itemsLimpios.ToArray(), texto = textoLimpio });
                        }
                        items.Clear(); textoSeccion.Clear();
                    }
                    seccionActual = "CLASIFICACION DE LOS RESULTADOS";
                }
                else if (linea.StartsWith("⛔") || linea.StartsWith("⚠️") || linea.StartsWith("✅") || linea.StartsWith("(*)"))
                {
                    var textoLimpio = linea.Trim().Trim('*', ' ');
                    items.Add(textoLimpio);
                }
                else if (linea.StartsWith("📍"))
                {
                    // Resaltar la dirección con salto de línea antes y después
                    var direccionResaltada = "\n" + linea.Trim() + "\n";
                    pie = (pie == null ? "" : pie + "\n") + direccionResaltada;
                }
                else if (linea.StartsWith("📱"))
                {
                    pie = (pie == null ? "" : pie + "\n") + linea.Trim();
                }
                else if (!string.IsNullOrWhiteSpace(linea))
                {
                    if (seccionActual != null)
                        textoSeccion.Add(linea.Trim().Trim('*', ' '));
                }
            }
            // Agrega última sección si corresponde
            if (seccionActual != null && (items.Count > 0 || textoSeccion.Count > 0))
            {
                var itemsLimpios = items.Select(i => i.Trim('*', ' ')).ToList();
                var textoLimpio = string.Join("\n", textoSeccion.Select(t => t.Trim('*', ' ')));
                var claveNormalizada = NormalizarSeccion(seccionActual);
                if (claveNormalizada == "*IMPORTANTE*" || claveNormalizada == "*IMPORTANTE Sres. Padres:*")
                {
                    if (!seccionesUnicas.ContainsKey(claveNormalizada))
                        seccionesUnicas[claveNormalizada] = (new List<string>(), new List<string>());
                    seccionesUnicas[claveNormalizada].items.AddRange(itemsLimpios);
                    if (!string.IsNullOrEmpty(textoLimpio))
                        seccionesUnicas[claveNormalizada].textos.Add(textoLimpio);
                }
                else
                {
                    secciones.Add(new { titulo = seccionActual, items = itemsLimpios.ToArray(), texto = textoLimpio });
                }
            }

            // Al final, agrega las secciones únicas (IMPORTANTE y IMPORTANTE Sres. Padres) solo una vez cada una
            foreach (var kvp in seccionesUnicas)
            {
                var itemsArr = kvp.Value.items.ToArray();
                var textoArr = kvp.Value.textos;
                var textoFinal = string.Join("\n", textoArr.Where(t => !string.IsNullOrWhiteSpace(t)));
                // Si es la sección IMPORTANTE, quitar la palabra 'IMPORTANTE' del texto
                if (kvp.Key == "*IMPORTANTE*")
                {
                    textoFinal = textoFinal.Replace("IMPORTANTE\n", "").Replace("IMPORTANTE", "");
                }
                secciones.Add(new { titulo = kvp.Key, items = itemsArr, texto = textoFinal });
            }

            return new
            {
                titulo = titulo,
                cuerpo = cuerpo,
                secciones = secciones.ToArray(),
                pie = pie
            };
        }

        private void tbPacienteLaboral_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento CASCADA NIVEL 3: Cuando cambia cboSubTipoExamen, recarga la grilla con el filtro aplicado
        /// </summary>
        private void cboSubTipoExamen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                rbHoraTodas.Checked = true;
                cargarGrillaTurnosSinFiltro();
                cambiarEnabledBotonProximaFecha();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en cboSubTipoExamen_SelectionChangeCommitted: {ex.Message}");
            }
        }

    }
}