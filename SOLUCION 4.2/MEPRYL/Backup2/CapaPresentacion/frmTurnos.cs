using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocioMepryl;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmTurnos : Form
    {
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

        public frmTurnos()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            tipoEx = new CapaNegocioMepryl.TipoExamen();
            turno = new CapaNegocioMepryl.Turno();
            inicializarDgv();
            llenarComboTipoExamen();
            modoConsulta();
            cargarGrillaTurnosSinFiltro();
            cambiarEnabledBotonProximaFecha();
            blnConsultaExterna = false;
            LimpiarUltimoRegistroIngresado(); // GRV - Modificado            
        }

        private void inicializarDgv()
        {
            agregarColumnaDgv("Id", "Id", false);
            agregarColumnaDgv("TipoExamen", "Tipo Examen", true);
            agregarColumnaDgv("Medico", "Médico", true);
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
            panelLaboral.Enabled = false;
            panelPacientePreventiva.Enabled = false;
            dgvLigaYClub.Enabled = false;
            dgv.Enabled = true;
            panelFechaTipoExamen.Enabled = true;
            panelHorario.Enabled = true;
            panelFiltro.Enabled = true;
            panelEstado.Enabled = true;
            cambiarVisibilidadBotonesPrincipales();
            dgv.Focus();
        }

        private void cambiarEnabledBotonProximaFecha()
        {
            botProxFechaLibre.Enabled = false;
            if (cboTipoExamen.SelectedIndex > 0) { botProxFechaLibre.Enabled = true; }
        }

        private void llenarComboTipoExamen()
        {
            cboTipoExamen.DataSource = turno.cargarTiposDeExamen();
            cboTipoExamen.ValueMember = "Id";
            cboTipoExamen.DisplayMember = "Descripcion";
            cboTipoExamen.SelectedIndex = 0;
        }

        private void cboTipoExamen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            rbHoraTodas.Checked = true;
            cargarGrillaTurnosSinFiltro();
            cambiarEnabledBotonProximaFecha();
        }

        private void cargarGrillaTurnosSinFiltro()
        {
            llenarDgv(turno.cargarTurnos(obtenerTipoExamen(), obtenerFecha(), obtenerHora(), obtenerEstado()));
        }

        private void llenarDgv(DataTable tabla)
        {
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
                    colorearFila();
                }

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
                
                if (dgv.Rows.Count > 0) { 
                    //lblInformacion.Text = dgv.Rows.Count.ToString() + " Turnos"; 
                    string strEstado = "";
                    if (rbEstadoLibres.Checked)
                        strEstado = rbEstadoLibres.Text.ToLowerInvariant();
                    else if (rbEstadoAsignados.Checked)
                        strEstado = rbEstadoAsignados.Text.ToLowerInvariant();
                    else
                        strEstado = "abiertos";

                    if ((!rbEstadoTodos.Checked) && cboTipoExamen.Text != "TODOS" && cboTipoExamen.Text != "System.Data.DataRowView")
                        LblTurnos.Text = dgv.Rows.Count.ToString() + " Turnos " + strEstado + " de (" + cboTipoExamen.Text + ")";
                    else if ((rbEstadoTodos.Checked) && cboTipoExamen.Text != "TODOS")
                        LblTurnos.Text = dgv.Rows.Count.ToString() + " Turnos abiertos de (" + cboTipoExamen.Text + ")";
                    else if (cboTipoExamen.Text == "TODOS" && rbEstadoLibres.Checked)
                        LblTurnos.Text = "Un total de " + dgv.Rows.Count.ToString() + " Turnos " + strEstado;
                    else if (cboTipoExamen.Text == "TODOS" && rbEstadoAsignados.Checked)
                        //LblTurnos.Text = "Un total de " + dgv.Rows.Count.ToString() + " Turnos " + strEstado;
                        LblTurnos.Text = "";
                    else
                        LblTurnos.Text = "";

                    lblAsignados.Text = "Asignados " + turno.TotalTurnosAsignados(obtenerFecha()) + " de 140 turnos";
                    
                    if (turno.TotalTurnosAsignados(obtenerFecha()) > 140)
                    {
                        lblAsignados.ForeColor = Color.Maroon;
                        MessageBox.Show("Se ha superado el total de 140 turnos diarios para la fecha " + obtenerFecha().ToShortDateString() + "\nProcure asignar los nuevos turnos a fechas posteriores", "Turnos",MessageBoxButtons.OK,MessageBoxIcon.Warning);                        
                    }
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

        private void colorearFila()
        {
            int valor = Convert.ToInt16(dgv.Rows[dgv.Rows.Count - 1].Cells[17].Value.ToString());
            System.Drawing.Color color =  System.Drawing.Color.White;
            switch (valor)
            {
                case 2:
                    color = System.Drawing.Color.MistyRose;
                    break;
                case 3:
                    color = System.Drawing.Color.LightGray;
                    break;
                case 4:
                    color = System.Drawing.Color.LightSteelBlue;
                    break;
                case 5:
                    color = System.Drawing.Color.LightGray;
                    break;
            }
            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = color;
        }

        private Guid obtenerTipoExamen()
        {
            if (cboTipoExamen.SelectedIndex == 0)
            {
                return Guid.Empty;
            }
            return new Guid(cboTipoExamen.SelectedValue.ToString());
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
        }

        private void rbEstadoLibres_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
        }

        private void rbEstadoAsignados_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrillaTurnosSinFiltro();
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
                char tipoPaciente = turno.verificarTipoPaciente(new Guid(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[6].Value.ToString()));
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
                }
                else
                {
                    botAsignar.Visible = true;
                    botModificar.Visible = false;
                    botLiberar.Visible = false;
                }
            }
            else
            {
                botAsignar.Visible = false;
                botModificar.Visible = false;
                botLiberar.Visible = false;
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
                tbCategoriaPreventiva.Text = turnoPrev.Nacimiento.Year.ToString();
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
            Entidades.TurnoLaboral pacienteLaboral = turno.cargarTurnoPacienteLaboral(new Guid(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString()));
            llenarPanelPacienteLaboral(pacienteLaboral);
        }


        private void llenarPanelPacienteLaboral(Entidades.TurnoLaboral turnoLab)
        {
            tbIdTurnoLaboral.Text = turnoLab.Id.ToString();
            tbIdPacienteLaboral.Text = turnoLab.IdPaciente.ToString();
            tbPacienteLaboral.Text = turnoLab.ApellidoNombre;
            tbDniLaboral.Text = turnoLab.Dni;
            tbCuilLaboral.Text = turnoLab.Cuil;
            tbIdEmpresaLaboral.Text = turnoLab.IdEmpresa.ToString();
            tbEmpresaLaboral.Text = turnoLab.Empresa;
            tbTareaLaboral.Text = turnoLab.Tarea;
            tbTelefonoLaboral.Text = turnoLab.Telefono;
            cbFactEmpresaLaboral.Checked = turnoLab.FacturaEmpresa;
            tbObservacionesLaboral.Text = turnoLab.Observaciones;
            tipoExamenActual = turnoLab.TipoExamen;
            tbIdTipoExamenLaboral.Text = tipoExamenActual.IdTipoExamenPaciente.ToString();
            tbImporteLaboral.Text = tipoExamenActual.PrecioBase.ToString();
            cbExamenModificadoLaboral.Checked = tipoExamenActual.Modificado;
            tbExamenLaboral.Text = tipoExamenActual.Descripcion;
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
            }
            else if (tipoTurno == 'L')
            {
                abrirVentanaPacienteLaboral();
            }
            else
            {
                // GRV - Ramírez modifcado asignar turno consulta
                //abrirVentanaTipoPaciente();
                if (blnConsultaExterna)
                {                    
                    asignarPacienteLaboral(strIDPaciente, strIDEmpresa);
                }
                else
                {
                    abrirVentanaTipoPaciente();
                }
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
            Entidades.TurnoLaboral pacienteLaboral = turno.nuevoTurnoPacienteLaboral(idPaciente, dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString(),idEmpresa);
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

            if ((cboTipoExamen.Text == "BUZO") || (cboTipoExamen.Text == "BUZO 1º VEZ"))
                InhabilitaErgometrias();
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
            liberarTurno();
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
            if (tipoTurno == 'P')
            {
                liberarTurnoPreventiva();
            }
            else if (tipoTurno == 'L')
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
                MessageBox.Show("¡Turno liberado correctamente!","Liberar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return verificarEstado(index,"1");
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
            if (dgv.Rows[index].Cells[17].Value.ToString() == codigo)
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
            Entidades.TurnoLaboral turnoLab = turno.recargarDatoPacienteLaboral(idPaciente, idEmpresa);
            tbPacienteLaboral.Text = turnoLab.ApellidoNombre;
            tbDniLaboral.Text = turnoLab.Dni;
            tbCuilLaboral.Text = turnoLab.Cuil;
            tbIdEmpresaLaboral.Text = turnoLab.IdEmpresa.ToString();
            tbEmpresaLaboral.Text = turnoLab.Empresa;
            tbTareaLaboral.Text = turnoLab.Tarea;
            tbTelefonoLaboral.Text = turnoLab.Telefono;
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
        }

        private void tpFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            rbHoraTodas.Checked = true;
            cargarGrillaTurnosSinFiltro();
        }

        private void botReservar_Click(object sender, EventArgs e)
        {
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
            foreach (DataGridViewRow dgvR in dgv.SelectedRows)
            {
                if (turnoReservado(dgvR.Index))
                {
                    turno.liberarReservaTurno(new Guid(dgvR.Cells[0].Value.ToString()));
                }
            }
            cargarGrillaTurnosSinFiltro();
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
            // GRV - Modificado
            // asignar();
            if (!VerificaIDTurnoLibre())
                asignar();
            else
                cargarGrillaTurnosSinFiltro();            
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
                if (idPaciente == dgv.Rows[i].Cells[6].Value.ToString())
                {
                    dgv.Rows[i].Selected = true;
                    dgv.CurrentCell = this.dgv[7,i];
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

        private bool PacienteTieneTurno(string IdPaciente, string NombrePaciente, string DNI)
        {
            bool blnEstado = false;
            DataTable dtConsulta;
            DialogResult drResultado;
            string strMensaje = "\n\n";

            dtConsulta = turno.PacienteTieneTurnoAsignado(obtenerFecha(), IdPaciente);            

            if (dtConsulta.Rows.Count > 0)
            {
                strMensaje = strMensaje + "Nombre: " + NombrePaciente;
                strMensaje = strMensaje + "\nDni: " + DNI;
                strMensaje = strMensaje + "\nTipoExamen: " + dtConsulta.Rows[0][1].ToString();
                strMensaje = strMensaje + "\nHora: " + dtConsulta.Rows[0][3].ToString();
                strMensaje = strMensaje + "\nFecha: " + Convert.ToDateTime(dtConsulta.Rows[0][2].ToString()).ToShortDateString();
                strMensaje = strMensaje + "\n\n¿Desea asignar un turno de todos modos.?";

                drResultado = MessageBox.Show("El paciente ya tiene asignado un turno..." + strMensaje, "Asignar turnos",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (drResultado == System.Windows.Forms.DialogResult.Yes)
                    blnEstado = false;
                else
                    blnEstado = true;
            }            

            return blnEstado;
        }

        private bool VerificaIDTurnoLibre()
        {
            bool blnLibre = false;
            DataTable dtConsulta;
            string strMensaje = "";

            dtConsulta = turno.VerificaIDTurnoLibre(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString(), Convert.ToDateTime(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[3].Value.ToString()), dgv.Rows[dgv.CurrentCell.RowIndex].Cells[6].Value.ToString());
                        
            if (dgv.Rows[dgv.CurrentCell.RowIndex].Cells[17].Value.ToString() == "1")
            {
                if (dtConsulta.Rows.Count > 0)
                {
                    //strMensaje = "El usuario, " + turno.NombreUsuario(dtConsulta.Rows[0][2].ToString()) + " ya ha asignado este turno para el paciente " + turno.NombreApellidoPaciente(dtConsulta.Rows[0][1].ToString()) + "\nPor favor seleccione otro turno.";
                    //MessageBox.Show(strMensaje, "Asignar turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //PacienteTieneTurno(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[6].Value.ToString(), dgv.Rows[dgv.CurrentCell.RowIndex].Cells[8].Value.ToString(), dgv.Rows[dgv.CurrentCell.RowIndex].Cells[7].Value.ToString());                    
                    blnLibre = true;
                }

                if (!string.IsNullOrEmpty(strIdPaciente))
                    blnLibre = PacienteTieneTurno(strIdPaciente, strApellido, strDNI);
            }

            if (verificaTurnoReservado(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString()))
                blnLibre = true;

            LimpiaVariableDatos();

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
            }else
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
    }
}
