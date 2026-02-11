using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocio;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class frmRecepcion : Form
    {
        private CapaNegocioMepryl.Ventanilla ventanilla;
        private CapaNegocioMepryl.Turno turno;

        public frmRecepcion()
        {
            InitializeComponent();
            ventanilla = new CapaNegocioMepryl.Ventanilla();
            turno = new CapaNegocioMepryl.Turno();
            cargarDgv();
            this.ActiveControl = dgv;
        }

        private void cargarDgv()
        {
            dgv.DataSource = ventanilla.cargar(tpDesde.Value, tpHasta.Value);
            ocultarColumnasDgv();
            tbResultado.Text = "Total Pacientes: " + dgv.Rows.Count.ToString();
            cambiarVisibilidadBotonEditarPaciente();
        }

        private void actualizarListadoManteniendoPosicion()
        {
            int nroFila = dgv.SelectedRows[0].Index;
            cargarDgv();
            dgv.CurrentCell = dgv.Rows[nroFila].Cells[0];
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            dgv.DataSource = ventanilla.cargarConFiltro(tpDesde.Value, tpHasta.Value, tbBusqueda.Text);
            ocultarColumnasDgv();
            tbResultado.Text = "Total Pacientes: " + dgv.Rows.Count.ToString();
            cambiarVisibilidadBotonEditarPaciente();
        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            registrar();
        }

        private void ocultarColumnasDgv()
        {
            dgv.Columns[2].Visible = false;
            dgv.Columns[13].Visible = false;
            dgv.Columns[14].Visible = false;
            dgv.Columns[15].Visible = false;
            dgv.Columns[10].HeaderText = "Club/Empresa";
        }

        public void registrarIngreso()
        {
            string apellido, nombre, dni;
            dni = dgv.SelectedRows[0].Cells[7].Value.ToString();
            apellido = dgv.SelectedRows[0].Cells[8].Value.ToString();
            nombre = dgv.SelectedRows[0].Cells[9].Value.ToString();
            if ((bool)dgv.SelectedRows[0].Cells[0].Value)
            {
                DialogResult result = MessageBox.Show("El siguiente paciente va a ser ingresado: \n\n\t DNI: " + dni + "\n\t APELLIDO Y NOMBRE: " + apellido + "\n\n ¿Desea continuar?", "Confirmar Ingreso", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ventanilla.registrarIngreso(new Guid(dgv.SelectedRows[0].Cells[2].Value.ToString()));
                    cargarDgv();
                }
            }
            else
            {
                MessageBox.Show("¡Se debe registrar la asistencia del paciente antes de ingresarlo!", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void tbBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buscar();
            }
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            tbBusqueda.Clear();
            cargarDgv();
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (tbBusqueda.Text == "")
            {
                botonLimpiar.PerformClick();
            }
        }


        private void actualizarListado()
        {
            cargarDgv();               
        }


        private void abrirVentanaPaciente()
        {
            char tipoTurno = ventanilla.verificarTipoTurno(new Guid(dgv.SelectedRows[0].Cells[2].Value.ToString()));
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
                abrirVentanaTipoPaciente();
            }
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

        private void dgvTurno_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                botonRegistrar.PerformClick();
            }
        }

        private void botEditarPaciente_Click(object sender, EventArgs e)
        {
            editarPaciente();
        }

        private void editarPaciente()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (ventanilla.verificarTipoPaciente(new Guid(dgv.SelectedRows[0].Cells[13].Value.ToString())) == 'P')
                {
                    editarPacientePreventiva();
                }
                else
                {
                    editarPacienteLaboral();
                }              
            }
            else
            {
                MessageBox.Show("Se debe seleccionar un paciente para editar", "Editar Paciente",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void editarPacientePreventiva()
        {
            frmPaciente fPaciente = new frmPaciente(new Configuracion(), true);
            fPaciente.mostarDatosDni(dgv.SelectedRows[0].Cells[7].Value.ToString());
            fPaciente.objDelegateDevolverID = new frmPaciente.DelegateDevolverID(recargarDatosPacientePreventiva);
            fPaciente.ShowDialog();
        }

        private void editarPacienteLaboral()
        {
            frmPacienteLaboral fPaciente = new frmPacienteLaboral();
            fPaciente.cargarPacienteEspecifico(dgv.SelectedRows[0].Cells[15].Value.ToString(), dgv.SelectedRows[0].Cells[13].Value.ToString());
            fPaciente.objDelegateDevolverID = new frmPacienteLaboral.DelegateDevolverID(recargarDatosPacienteLaboral);
            fPaciente.ShowDialog();
        }


        private void abrirVentanaPacientePreventiva()
        {
            frmPaciente fPaciente = new frmPaciente(new Configuracion(), true);
            fPaciente.mostarDatosDni(dgv.SelectedRows[0].Cells[7].Value.ToString());
            fPaciente.objDelegateDevolverID = new frmPaciente.DelegateDevolverID(asignarTurnoPacientePreventiva);
            fPaciente.ShowDialog();
        }

        private void abrirVentanaPacienteLaboral()
        {
            frmPacienteLaboral fPaciente = new frmPacienteLaboral();
            fPaciente.objDelegateDevolverID = new frmPacienteLaboral.DelegateDevolverID(asignarTurnoPacienteLaboral);
            fPaciente.ShowDialog();
        }

        private void asignarTurnoPacienteLaboral(string idPaciente, string idEmpresa)
        {
            Entidades.Resultado result = ventanilla.nuevoTurnoPacienteLaboral(idPaciente, dgv.SelectedRows[0].Cells[2].Value.ToString(), idEmpresa);
            analizarResultadoAsignacionTurno(result);
        }

        private void asignarTurnoPacientePreventiva(string idPaciente)
        {
            Entidades.Resultado result = ventanilla.nuevoTurnoPacientePreventiva(idPaciente, dgv.SelectedRows[0].Cells[2].Value.ToString());
            analizarResultadoAsignacionTurno(result);
        }

        private void analizarResultadoAsignacionTurno(Entidades.Resultado result)
        {
            if (result.Modo == 1)
            {
                actualizarListadoManteniendoPosicion();
            }
            else
            {
                MessageBox.Show("Error al asignar al paciente a la reserva seleccionada.\nError: " + result.Mensaje,
                    "Error Asignar Reserva", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void recargarDatosPacienteLaboral(string idPaciente, string idEmpresa)
        {
            actualizarListadoManteniendoPosicion();
        }

        private void recargarDatosPacientePreventiva(string idPaciente)
        {
            ventanilla.actualizarClubesPorTipoExamenSegunTurno(new Guid(dgv.SelectedRows[0].Cells[2].Value.ToString()), new Guid(idPaciente));
            actualizarListadoManteniendoPosicion();
        }

        private void botBuscarRango_Click(object sender, EventArgs e)
        {
            cargarDgv();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            actualizarHora();
        }

        private void actualizarHora()
        {
            tbHora.Text = DateTime.Now.ToString("HH:mm");
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            cambiarVisibilidadBotonEditarPaciente();
        }

        private void cambiarVisibilidadBotonEditarPaciente()
        {
            botEditarPaciente.Enabled = false;
            botEditarExamen.Enabled = false;
            if (dgv.CurrentCell != null && dgv.SelectedRows.Count > 0
                && !Convert.ToBoolean(dgv.SelectedRows[0].Cells[14].Value.ToString()))
            {
                botEditarPaciente.Enabled = true;
                botEditarExamen.Enabled = true;
            }
        }

        private void botEditarExamen_Click(object sender, EventArgs e)
        {
            editarTipoExamen();
        }

        private void editarTipoExamen()
        {
            frmTipoExamen fTipoExamen = new frmTipoExamen();
            fTipoExamen.cargarSegunIdTurno(new Guid(dgv.SelectedRows[0].Cells[2].Value.ToString()));
            fTipoExamen.objDelegateModificado = new frmTipoExamen.DelegateModificado(actualizarListadoManteniendoPosicion);
            fTipoExamen.ShowDialog();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            actualizarEstadoTurno(e);
        }

        private void actualizarEstadoTurno(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                ventanilla.actualizarPresente(new Guid(dgv.SelectedRows[0].Cells[2].Value.ToString()), obtenerValorBooleano(e.RowIndex, 0));
            }
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                ventanilla.actualizarAbono(new Guid(dgv.SelectedRows[0].Cells[2].Value.ToString()), obtenerValorBooleano(e.RowIndex, 1));
            }
        }

        private bool obtenerValorBooleano(int nroFila, int nroColumna)
        {
            if ((bool)dgv.Rows[nroFila].Cells[nroColumna].Value)
            {
                return false;
            }
            return true;
        }

        private void registrar()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (!Convert.ToBoolean(dgv.SelectedRows[0].Cells[14].Value.ToString()))
                {
                    frmAvisoExamenModificado fExamen = new frmAvisoExamenModificado(false);
                    fExamen.cargarEstudiosSegunIdTurno(new Guid(dgv.SelectedRows[0].Cells[2].Value.ToString()));
                    fExamen.objDelegateVentanilla = new frmAvisoExamenModificado.DelegateVentanilla(registrarIngreso);
                    fExamen.ShowDialog();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Los datos del paciente no fueron cargados. ¿Desea cargarlos ahora?", "Ingreso Paciente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        abrirVentanaPaciente();
                    }
                    else
                    {
                        if ((bool)dgv.SelectedRows[0].Cells[0].Value)
                        {
                            DialogResult result2 = MessageBox.Show("La siguiente reserva va a ser ingresada. ¿Desea continuar?", "Registrar Ingreso",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result2 == DialogResult.Yes)
                            {
                                ventanilla.registrarIngreso(new Guid(dgv.SelectedRows[0].Cells[2].Value.ToString()));
                                cargarDgv();
                            }
                        }
                        else
                        {
                            MessageBox.Show("¡Se debe registrar la asistencia del paciente antes de ingresarlo!", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Seleccione un paciente para ingresar");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
