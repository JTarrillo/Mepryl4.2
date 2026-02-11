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
using CapaPresentacionBase;

namespace CapaPresentacion
{
    public partial class frmRecepcion : DevExpress.XtraEditors.XtraForm
    {
        private CapaNegocioMepryl.Ventanilla ventanilla;
        private CapaNegocioMepryl.Turno turno;
        private bool blnEstadoOculta = false;
        private bool blnPrimerIngreso = true;


        public frmRecepcion()
        {
            InitializeComponent();
            ventanilla = new CapaNegocioMepryl.Ventanilla();
            turno = new CapaNegocioMepryl.Turno();
            cargarDgv();
            this.ActiveControl = dgv;
        }

        public frmRecepcion(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            ventanilla = new CapaNegocioMepryl.Ventanilla();
            turno = new CapaNegocioMepryl.Turno();
            cargarDgv();
            this.ActiveControl = dgv;
        }

        private void cargarDgv()
        {
            DataView dv = null;
            //int CantidadTurnos = 0;
            //int CantidadTurnosOcultos = 0;
            if (tpHasta.Enabled)
            {
                dv = new DataView(ventanilla.cargar(tpDesde.Value, tpHasta.Value, blnPrimerIngreso));
                dgv.DataSource = dv;

                //dgv.DataSource = ventanilla.cargar(tpDesde.Value, tpHasta.Value, blnPrimerIngreso);
                //dgv.Sort(dgv.Columns[4], ListSortDirection.Ascending);
            }

            if (tpFecha.Enabled)
            {
                dv = new DataView(ventanilla.cargar(tpFecha.Value, tpFecha.Value, blnPrimerIngreso));
                dgv.DataSource = dv;
                //dgv.DataSource = ventanilla.cargar(tpFecha.Value, tpFecha.Value, blnPrimerIngreso);                
            }

            dv.Sort = "HORA, Nro, Paciente";
            //dgv.Sort(dgv.Columns[4], ListSortDirection.Ascending);

            ocultarColumnasDgv();
            //if (blnPrimerIngreso)
            //    //lblResultado.Text = "Total Pacientes: " + ventanilla.TotalTurnosVentanilla(tpDesde.Value, tpHasta.Value).ToString();
            //    CantidadTurnos = ventanilla.TotalTurnosVentanilla(tpDesde.Value, tpHasta.Value);
            //else
            //    //lblResultado.Text = "Total Pacientes: " + dgv.Rows.Count.ToString();
            //    CantidadTurnos = dgv.Rows.Count;

            //lblResultado.Text = "Total Pacientes: " + CantidadTurnos.ToString();
            //lblOcultos.Text = "Ocultos: " + (CantidadTurnos - ventanilla.TurnosNoOcultos()).ToString(); ;
            MostrarTotales();

            cambiarVisibilidadBotonEditarPaciente();
            //ocultarFilasDgv();
            blnPrimerIngreso = false;
            
            MostrarExpIngreso(); // <-- Actualiza la suma de Importe
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
            DataView dv = null;            

            if (tpHasta.Enabled)
            {
                dv = new DataView(ventanilla.cargarConFiltro(tpDesde.Value, tpHasta.Value, tbBusqueda.Text));
                dgv.DataSource = dv;
                //dgv.DataSource = ventanilla.cargarConFiltro(tpDesde.Value, tpHasta.Value, tbBusqueda.Text);
                
            }

            if (tpFecha.Enabled)
            {
                dv = new DataView(ventanilla.cargarConFiltro(tpFecha.Value, tpFecha.Value, tbBusqueda.Text));
                dgv.DataSource = dv;
                //dgv.DataSource = ventanilla.cargarConFiltro(tpFecha.Value, tpFecha.Value, tbBusqueda.Text);

            }

            dv.Sort = "HORA, Nro, Paciente";
            //dgv.DataSource = ventanilla.cargarConFiltro(tpDesde.Value, tpHasta.Value, tbBusqueda.Text);
            //dgv.Sort(dgv.Columns[4], ListSortDirection.Ascending);

            ocultarColumnasDgv();
            //lblResultado.Text = "Total Pacientes: " + dgv.Rows.Count.ToString();
            MostrarTotales();
            cambiarVisibilidadBotonEditarPaciente();

            //rdbMostrarTodo.Checked = true;
            //blnEstadoOculta = false;
            //MostrarTodo();
            ocultarFilasDgv();
            
            MostrarExpIngreso(); // <-- Actualiza la suma de Importe
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

            //dgv.Refresh();
        }

        public void registrarIngreso()
        {
            string apellido, nombre, dni;
            dni = dgv.SelectedRows[0].Cells[7].Value.ToString();
            apellido = dgv.SelectedRows[0].Cells[8].Value.ToString();
            nombre = dgv.SelectedRows[0].Cells[9].Value.ToString();
            if ((bool)dgv.SelectedRows[0].Cells[0].Value)
            {
                DialogResult result = MessageBox.Show("El siguiente paciente: \n\n\t " + apellido + "\n\t (DNI): " + dni + "\n\nVa a ser ingresado\n ¿Desea continuar?", "Confirmar Ingreso", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ventanilla.registrarIngreso(new Guid(dgv.SelectedRows[0].Cells[2].Value.ToString()));
                    cargarDgv();
                    ocultarFilasDgv();
                }
            }
            else
            {
                MessageBox.Show("¡Registre la asistencia del paciente para poder continuar!", "Atención",
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

            rdbMostrarTodo.Checked = false;
            blnEstadoOculta = true;
            MostrarTodo();
            ocultarFilasDgv();
            //rdbMostrarTodo.Checked = false;
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
            //fPaciente.mostarDatosDni(dgv.SelectedRows[0].Cells[7].Value.ToString());
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
            ocultarFilasDgv();
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
            try
            {
                botEditarPaciente.Enabled = false;
                botEditarExamen.Enabled = false;
                if (dgv.CurrentCell != null && dgv.SelectedRows.Count > 0
                    && !Convert.ToBoolean(dgv.SelectedRows[0].Cells[14].Value.ToString()))
                {
                    botEditarPaciente.Enabled = true;
                    botEditarExamen.Enabled = true;
                }
            }catch(System.ArgumentOutOfRangeException ex)
            {

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
            if (e.ColumnIndex == 16 && e.RowIndex >= 0)
            {
                ventanilla.actualizarOcultar(dgv.SelectedRows[0].Cells[2].Value.ToString(), obtenerValorBooleano(e.RowIndex, 16));
                dgv.CurrentCell = null;
                //ocultarFilasDgv();
                if (obtenerValorBooleano(e.RowIndex, 16))
                {
                    if (rdbMostrarTodo.Checked)
                    { 
                        dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                        dgv.Rows[e.RowIndex].Cells[16].Value = true;
                    }
                    else
                    {
                        dgv.Rows[e.RowIndex].Visible = false;                        
                    }                    
                }
                else
                {
                    dgv.Rows[e.RowIndex].Visible = true;
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dgv.Rows[e.RowIndex].Cells[16].Value = false;                    
                }

                MostrarTotales();
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


        private void MostrarExpIngreso()
        {
            decimal totalImporte = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Visible && row.Cells["Importe"].Value != null)
                {
                    decimal importe;
                    if (decimal.TryParse(row.Cells["Importe"].Value.ToString(), out importe))
                        totalImporte += importe;
                }
            }
            lblExpIngreso.Text = $"Exp. Ingreso : {totalImporte:N0}";
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
                                MostrarExpIngreso();
                                //ocultarFilasDgv();
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

        private void frmRecepcion_Load(object sender, EventArgs e)
        {
            rbcMenu.Minimized = true;
            rbcMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green;
            ocultarFilasDgv();
        }

        private void ocultarFilasDgv()
        {
            bool blnOcultar = false;

            try
            {
                if (!rdbMostrarTodo.Checked)
                {
                    for (int fila = 0; fila < dgv.Rows.Count - 1; fila++)
                    //for (int fila = 0; fila < intFilas - 1; fila++)
                    {
                        blnOcultar = Convert.ToBoolean(dgv.Rows[fila].Cells[16].Value.ToString());
                        //dgv.CurrentCell = null;
                        if (blnOcultar)
                        {
                            CurrencyManager cm = (CurrencyManager)BindingContext[dgv.DataSource];
                            cm.SuspendBinding();
                            dgv.Rows[fila].Visible = false;
                        }
                        else
                        {
                            dgv.Rows[fila].Visible = true;
                        }
                    }
                }
                else
                {
                    for (int fila = 0; fila < dgv.Rows.Count - 1; fila++)
                    //for (int fila = 0; fila < intFilas - 1; fila++)
                    {
                        blnOcultar = Convert.ToBoolean(dgv.Rows[fila].Cells[16].Value.ToString());

                        if (blnOcultar)
                        {
                            dgv.Rows[fila].Visible = true;
                            dgv.Rows[fila].DefaultCellStyle.BackColor = Color.MistyRose;
                        }
                        else
                        {
                            dgv.Rows[fila].DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
            }
            catch (System.InvalidOperationException ex)
            {
                //
            }
        }

        private void rdbMostrarTodo_CheckedChanged(object sender, EventArgs e)
        {
            cargarDgv();
            ocultarFilasDgv();            
        }

        private void rdbMostrarTodo_Click(object sender, EventArgs e)
        {
            //if (blnEstadoOculta == true)
            //{
            //    rdbMostrarTodo.Checked = false;
            //    blnEstadoOculta = false;
            //    rdbMostrarTodo.Text = "Mostrar";
            //    rdbMostrarTodo.Image = Image.FromFile(@"P:\img-system\mMostrar2_36x36.png");
            //}
            //else
            //{
            //    blnEstadoOculta = true;
            //    rdbMostrarTodo.Text = "Ocultar";
            //    rdbMostrarTodo.Image = Image.FromFile(@"P:\img-system\mNoMostrar2_36x36.png");
            //}

            MostrarTodo();
        }

        private void MostrarTodo()
        {
            if (blnEstadoOculta == true)
            {
                rdbMostrarTodo.Checked = false;
                blnEstadoOculta = false;
                rdbMostrarTodo.Text = "Mostrar";
                rdbMostrarTodo.Image = Image.FromFile(@"P:\img-system\mMostrar2_36x36.png");
            }
            else
            {
                blnEstadoOculta = true;
                rdbMostrarTodo.Text = "Ocultar";
                rdbMostrarTodo.Image = Image.FromFile(@"P:\img-system\mNoMostrar2_36x36.png");
            }
        }

        private void MostrarTodo2()
        {
            if (rdbMostrarTodo.Checked == false)
            {
                //rdbMostrarTodo.Checked = false;
                blnEstadoOculta = false;
                rdbMostrarTodo.Text = "Mostrar";
                rdbMostrarTodo.Image = Image.FromFile(@"P:\img-system\mMostrar2_36x36.png");
            }
            else
            {
                blnEstadoOculta = true;
                rdbMostrarTodo.Text = "Ocultar";
                rdbMostrarTodo.Image = Image.FromFile(@"P:\img-system\mNoMostrar2_36x36.png");
            }
        }

        private void MostrarTotales()
        {
            if (tpHasta.Enabled)
            {
                lblResultado.Text = "Total Pacientes: " + ventanilla.TurnosNoOcultos(tpDesde.Value, tpHasta.Value).ToString();
                lblOcultos.Text = "Ocultos: " + ventanilla.TurnosOcultos(tpDesde.Value, tpHasta.Value).ToString();
            }

            if (tpFecha.Enabled)
            {
                lblResultado.Text = "Total Pacientes: " + ventanilla.TurnosNoOcultos(tpFecha.Value, tpFecha.Value).ToString();
                lblOcultos.Text = "Ocultos: " + ventanilla.TurnosOcultos(tpFecha.Value, tpFecha.Value).ToString();
            }            
        }

        private void botonRango_Click(object sender, EventArgs e)
        {
            tpDesde.Enabled = true;
            tpHasta.Enabled = true;
            botBuscarRango.Enabled = true;
            tpFecha.Enabled = false;
        }

        private void botonFecha_Click(object sender, EventArgs e)
        {
            tpDesde.Enabled = false;
            tpHasta.Enabled = false;
            botBuscarRango.Enabled = false;
            tpFecha.Enabled = true;
            cargarDgv();
            ocultarFilasDgv();
        }

        private void tpFecha_ValueChanged(object sender, EventArgs e)
        {
            //botBuscarRango.PerformClick();
            cargarDgv();
            ocultarFilasDgv();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
