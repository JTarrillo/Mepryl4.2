using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocioMepryl;
using Comunes;
using CapaPresentacionBase;

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

                    if (valor == 2)
                    {
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                        System.Diagnostics.Debug.WriteLine($"✅ Coloreada fila con estado 2");
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
                    btnCopiarInfo.Visible = true; //GRV - Modificado
                    btnVerEstudio.Visible = true;
                    btnMoverTurno.Visible = true; // GRV - Modificado
                    if (blnActivoMoverTurno)
                    {
                        botLiberar.Visible = false;
                        btnCopiarInfo.Visible = false; //GRV - Modificado
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
                btnVerEstudio.Visible = false;
            }
        }

        private void cargarPanelPreventiva()
        {
            panelPacientePreventiva.Visible = true;
            panelLaboral.Visible = false;
            Entidades.TurnoPreventiva pacientePreventiva = turno.cargarTurnoPacientePreventiva(new Guid(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString()));
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
            cbFactClubPreventiva.Checked = turnoPrev.FacturaClub;
            tbObservPreventiva.Text = turnoPrev.Observaciones;
            tipoExamenActual = turnoPrev.TipoExamen;
            txtEmail.Text = turnoPrev.Mail;
            txtEdad.Text = (DateTime.Today.AddTicks(-turnoPrev.Nacimiento.Ticks).Year - 1).ToString();
            tbIdTipoExamenPreventiva.Text = tipoExamenActual.IdTipoExamenPaciente.ToString();
            tbImportePreventiva.Text = tipoExamenActual.PrecioBase.ToString();
            cbExamenModifPreventiva.Checked = tipoExamenActual.Modificado;
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
            cbFactEmpresaLaboral.Checked = turnoLab.FacturaEmpresa;
            tbObservacionesLaboral.Text = turnoLab.Observaciones;
            tipoExamenActual = turnoLab.TipoExamen;
            tbIdTipoExamenLaboral.Text = tipoExamenActual.IdTipoExamenPaciente.ToString();
            tbImporteLaboral.Text = tipoExamenActual.PrecioBase.ToString();
            cbExamenModificadoLaboral.Checked = tipoExamenActual.Modificado;
            tbExamenLaboral.Text = dgv.Rows[dgv.CurrentCell.RowIndex].Cells["SubTipoExamen"].Value?.ToString();
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
            tbImporteLaboral.Text = tipoEx.PrecioBase.ToString();
            cbExamenModificadoLaboral.Checked = tipoEx.Modificado;
            tbExamenLaboral.Text = tipoEx.Descripcion;
            if (tipoEx.Modificado)
            {
                tbExamenLaboral.Text = tbExamenLaboral.Text + " MODIF.";
            }
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

            // GRV - Modificado verifica si el turno no esta ocupado
            //guardar();

            if (!VerificaIDTurnoLibre()) // GRV - Modificado
                guardar();
            //else
            //cargarGrillaTurnosSinFiltro();
            // GRV
            MostrarUltimoRegistro();
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
            retorno.FacturaClub = cbFactClubPreventiva.Checked;
            retorno.Observaciones = tbObservPreventiva.Text;
            retorno.IdPaciente = new Guid(tbIdPacientePreventiva.Text);
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
            retorno.FacturaEmpresa = cbFactEmpresaLaboral.Checked;
            retorno.IdPaciente = new Guid(tbIdPacienteLaboral.Text);
            retorno.TipoExamen = tipoExamenActual;
            retorno.Consulta = "LABORAL";
            return retorno;
        }

        private void botEditarExamenPreventiva_Click(object sender, EventArgs e)
        {
            editarExamenPreventiva();
        }

        private void editarExamenPreventiva()
        {
            frmTipoExamen fTipoExamen = new frmTipoExamen(tipoExamenActual);
            fTipoExamen.objDelegateDevolverTipoExamen = new frmTipoExamen.DelegateDevolverTipoExamen(cargarTipoExamenPreventiva);
            fTipoExamen.ShowDialog();
        }

        private void cargarTipoExamenPreventiva(Entidades.TipoExamen tipoEx)
        {
            tipoExamenActual = tipoEx;
            tbIdTipoExamenPreventiva.Text = tipoEx.IdTipoExamenPaciente.ToString();
            tbImportePreventiva.Text = tipoEx.PrecioBase.ToString();
            cbExamenModifPreventiva.Checked = tipoEx.Modificado;
            tbExamenPreventiva.Text = tipoEx.Descripcion;
            if (tipoEx.Modificado)
            {
                tbExamenPreventiva.Text = tbExamenPreventiva.Text + " MODIF.";
            }
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
            inhabilitarTurnos();
            dgv.Rows[intFila].Selected = true;
            dgv.CurrentCell = dgv.Rows[intFila].Cells[1];
        }

        private void inhabilitarTurnos()
        {
            MessageBox.Show("Aviso: Se van a inhabilitar los turnos seleccionados que estén libres",
                "Inhabilitar Turnos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            foreach (DataGridViewRow dgvR in dgv.SelectedRows)
            {
                if (turnoLibre(dgvR.Index))
                {
                    turno.inhabilitarTurno(new Guid(dgvR.Cells[0].Value.ToString()));
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
            Cursor.Current = Cursors.WaitCursor;
            cargarGrillaTurnoConFiltro();
            Cursor.Current = Cursors.Default;
        }

        private void cargarGrillaTurnoConFiltro()
        {
            if (tbFiltro.Text != string.Empty)
            {
                llenarDgv(turno.cargarTurnosConFiltro(tbFiltro.Text));
            }
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
                botBuscar.PerformClick();
            }
        }

        private void cbFactClubPreventiva_CheckStateChanged(object sender, EventArgs e)
        {
            if (tipoExamenActual != null)
            {
                if (cbFactClubPreventiva.Checked)
                {
                    tbObservPreventiva.Text = "SE FACT. AL CLUB";
                    tipoExamenActual.PrecioBase = 0;
                    tbImportePreventiva.Text = tipoExamenActual.PrecioBase.ToString();
                }
                else
                {
                    tbObservPreventiva.Text = string.Empty;
                    tipoExamenActual.PrecioBase = tipoEx.cargarEstudiosPorTipoExamen(tipoExamenActual.Id.ToString()).PrecioBase;
                    tbImportePreventiva.Text = tipoExamenActual.PrecioBase.ToString();
                }
            }
        }

        private void cbFactEmpresaLaboral_CheckStateChanged(object sender, EventArgs e)
        {
            if (tipoExamenActual != null)
            {
                if (cbFactEmpresaLaboral.Checked)
                {
                    tbObservacionesLaboral.Text = "SE FACT. A LA EMPRESA";
                    tipoExamenActual.PrecioBase = 0;
                    tbImporteLaboral.Text = tipoExamenActual.PrecioBase.ToString();
                }
                else
                {
                    tbObservacionesLaboral.Text = string.Empty;
                    tipoExamenActual.PrecioBase = tipoEx.cargarEstudiosPorTipoExamen(tipoExamenActual.Id.ToString()).PrecioBase;
                    tbImporteLaboral.Text = tipoExamenActual.PrecioBase.ToString();
                }
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
            char strTipoPaciente;

            strTipoPaciente = turno.verificarTipoTurno(new Guid(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString()));

            if (strTipoPaciente == 'P')
                CopiarTexto();
            else
            {
                strTextoPlantilla = "";
                Clipboard.Clear();
            }
        }

        private void reemplazarTexto()
        {
            string strPaciente = "";
            string strHorario = "";
            string strFechaTurno = "";
            string strCodSeg = "";
            string strPrecio = "";
            string strTipoExamen = "";
            DateTime dtDiaSemana;

            strPrecio = tbImportePreventiva.Text;
            strHorario = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[4].Value.ToString();
            strFechaTurno = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[3].Value.ToString();
            strCodSeg = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[10].Value.ToString();
            strPaciente = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[8].Value.ToString();
            strTipoExamen = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value.ToString();

            dtDiaSemana = Convert.ToDateTime(strFechaTurno);

            strFechaTurno = dtDiaSemana.ToString("dddd", System.Globalization.CultureInfo.CreateSpecificCulture("es-ES")).ToUpper() + " " + strFechaTurno;

            if (strTipoExamen == "FUTBOL LAFIJ")
                RecuperarTexto();
            else if (strTipoExamen == "ERGOMETRIA")
                RecuperarTexto3();
            else
                RecuperarTexto2();

            strTextoPlantilla = strTextoPlantilla.Replace("<<paciente>>", strPaciente).Replace("<<FechaTurno>>",
                strFechaTurno).Replace("<<horario>>", strHorario).Replace("<<codseg>>",
                strCodSeg).Replace("<<Precio>>", strPrecio);
        }

        private void CopiarTexto()
        {
            reemplazarTexto();
            Clipboard.SetDataObject(strTextoPlantilla);
            strTextoPlantilla = "";
        }

        private void RecuperarTexto()
        {
            CapaNegocioMepryl.ConfigPlantillaReporte Reporte = new CapaNegocioMepryl.ConfigPlantillaReporte();
            DataTable dt = Reporte.ListarPlantillas("P");
            string strPathArchivo = "";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strPathArchivo = dt.Rows[i][8].ToString();
                }
            }

            strTextoPlantilla = System.IO.File.ReadAllText(strPathArchivo);
        }

        private void btnVerEstudio_Click(object sender, EventArgs e)
        {
            string strIdTurno = "";

            strIdTurno = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();

            frmAvisoExamenModificado fExamen = new frmAvisoExamenModificado(false);
            fExamen.cargarEstudiosSegunIdTurno(new Guid(strIdTurno));
            fExamen.ShowDialog();
        }

        private void RecuperarTexto2()
        {
            CapaNegocioMepryl.ConfigPlantillaReporte Reporte = new CapaNegocioMepryl.ConfigPlantillaReporte();
            DataTable dt = Reporte.ListarPlantillas("P");
            string strPathArchivo = "";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strPathArchivo = dt.Rows[i][9].ToString();
                }
            }

            strTextoPlantilla = System.IO.File.ReadAllText(strPathArchivo);
        }

        private void RecuperarTexto3()
        {
            CapaNegocioMepryl.ConfigPlantillaReporte Reporte = new CapaNegocioMepryl.ConfigPlantillaReporte();
            DataTable dt = Reporte.ListarPlantillas("P");
            string strPathArchivo = "";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strPathArchivo = dt.Rows[i][10].ToString();
                }
            }

            strTextoPlantilla = System.IO.File.ReadAllText(strPathArchivo);
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
            tbObservPreventiva.BackColor = Color.WhiteSmoke;
            tbObservPreventiva.ReadOnly = true;
            cbFactClubPreventiva.Enabled = false;

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
            tbObservacionesLaboral.BackColor = Color.WhiteSmoke;
            tbObservacionesLaboral.ReadOnly = true;
            cbFactEmpresaLaboral.Enabled = false;
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
            tbObservPreventiva.BackColor = Color.White;
            tbObservPreventiva.ReadOnly = false;
            cbFactClubPreventiva.Enabled = true;

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
            tbObservacionesLaboral.BackColor = Color.White;
            tbObservacionesLaboral.ReadOnly = false;
            cbFactEmpresaLaboral.Enabled = true;
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
                strTipoExamenMover = dgv.CurrentRow.Cells[2].Value.ToString(); // ✅ Cambiar índice de 1 a 2 (SubTipo)

                btnMoverTurno.Text = "Pegar\r\nTurno";
                btnMoverTurno.Image = Image.FromFile(@"P:\img-system\mPegar36x36.png");
                mostrarBotonesMoverTurno(true);
                blnActivoMoverTurno = true;
            }
            else
            {
                strTipoConsulta = turno.TipoConsulta(strIdTurnoAntiguoMover);

                if (strTipoExamenMover == dgv.CurrentRow.Cells[2].Value.ToString()) // ✅ Cambiar índice
                {
                    blnPuedeAsignarTurno = true;
                }

                if (strTipoConsulta == "LABORAL" && blnPuedeAsignarTurno == false)
                {
                    switch (dgv.CurrentRow.Cells[1].Value.ToString())
                    {
                        case "PRE-OCUPACIONAL":
                            blnPuedeAsignarTurno = true;
                            break;
                        case "PERIODICOS":
                            blnPuedeAsignarTurno = true;
                            break;
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
                    switch (dgv.CurrentRow.Cells[1].Value.ToString())
                    {
                        case "FUTBOL AFA":
                            blnPuedeAsignarTurno = true;
                            break;
                        case "FUTBOL LAFIJ":
                            blnPuedeAsignarTurno = true;
                            break;
                        case "FUTBOL METRO":
                            blnPuedeAsignarTurno = true;
                            break;
                        default:
                            blnPuedeAsignarTurno = false;
                            break;
                    }
                }

                //if (strTipoExamenMover == dgv.CurrentRow.Cells[1].Value.ToString()) // Comprueba que sea el mismo tipo de examen
                if (blnPuedeAsignarTurno) // Comprueba que sea el mismo tipo de examen
                {

                    if (string.IsNullOrEmpty(dgv.CurrentRow.Cells[7].Value.ToString())) // Verifica si paciente con DNI esta asignado
                    {
                        strIdTurnoNuevoMover = dgv.CurrentRow.Cells[0].Value.ToString(); // IdTurno Nuevo

                        if (!string.IsNullOrEmpty(strIdTurnoNuevoMover))
                        {
                            DialogResult result01 = MessageBox.Show("El turno de " + strTipoExamenMover + " va hacer movido a la fecha " + dgv.CurrentRow.Cells[3].Value.ToString() + " con el tipo de examen " + dgv.CurrentRow.Cells[1].Value.ToString() + ".\n\n¿Desea continuar?", "Mover turno", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result01 == DialogResult.Yes)
                            {
                                turno.MoverTurno(strIdTurnoAntiguoMover, strIdTurnoNuevoMover, dgv.CurrentRow.Cells[1].Value.ToString());

                                MessageBox.Show("¡Turno movido correctamente a la fecha " + dgv.CurrentRow.Cells[3].Value.ToString() + "!", "Mover turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                                FilaIndex = 1;
                            }
                        }
                        else
                        {
                            MessageBox.Show("¡Debe seleccionar un turno en una fecha diferente!", "Mover turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("¡Debe seleccionar un turno libre!", "Mover turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (strTipoConsulta == "LABORAL")
                    {
                        MessageBox.Show("¡Se puede mover el turno al mismo tipo de examen ó a los siguientes tipos de examen!\n\nTipo de examen:\n\n  * PRE-OCUPACIONAL\n  * PERIODICOS\n  * EGRESO ", "Mover turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("¡Se puede mover el turno al mismo tipo de examen ó a los siguientes tipos de examen!\n\nTipo de examen:\n\n* FUTBOL AFA\n* FUTBOL LAFIJ\n* FUTBOL METRO ", "Mover turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
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