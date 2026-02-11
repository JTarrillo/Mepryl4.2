using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using Microsoft.Reporting.WinForms;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmMesaDeEntrada : Form
    {
        int puntero = -1;
        bool primeraVez;
        // GRV - Ramírez
        private string strIdPaciente;
        private string strIdEmpresa;
        private bool blnInfantilInicial = false;
        private int intContPre = 200; // Modificar para empezar en 1 ó 200 Preventiva. Valores Posibles(1,200)
        //private string strTipoConsulta = "";
        private string strIdEmpresaNuevoConsultorio = "";
        
        CapaNegocioMepryl.ExamenPreventiva exPreventiva;
        CapaNegocioMepryl.MesaEntrada mesaEntrada;
        
        public frmMesaDeEntrada()
        {
            InitializeComponent();
            botonRegresarRecepcion.Visible = false;
            exPreventiva = new ExamenPreventiva();
            mesaEntrada = new MesaEntrada();
            inicializar();
        }

        private void inicializar()
        {
            cargarGrilla();
            setearTotales();
        }


        private void llenarComboBox(string idMotivoConsulta)
        {
            cbTipoDeExamen.DataSource = mesaEntrada.cargarTiposDeExamen(idMotivoConsulta);
            cbTipoDeExamen.ValueMember = "id";
            cbTipoDeExamen.DisplayMember = "descripcion";
            cbTipoDeExamen.SelectedIndex = -1;
        }

        public void clickBuscar()
        {
            botonBuscarDni.PerformClick();
        }

        public void cargarGrilla()
        {

            primeraVez = true;

            dgvGrilla.Columns.Clear();

            dgvGrilla.DataSource = mesaEntrada.cargarMesaEntrada();

            dgvGrilla.Columns[0].Visible = false;
            dgvGrilla.Columns[1].Visible = false;
            dgvGrilla.Columns[2].Visible = false;
            dgvGrilla.Columns[3].Visible = false;
            dgvGrilla.Columns[7].Visible = false;

            dgvGrilla.Columns[4].Width = 100;
            dgvGrilla.Columns[5].Width = 50;
            dgvGrilla.Columns[6].Width = 50;
            dgvGrilla.Columns[8].Width = 180;
            dgvGrilla.Columns[9].Width = 70;
            dgvGrilla.Columns[10].Width = 80;
            dgvGrilla.Columns[11].Width = 170;
            dgvGrilla.Columns[12].Width = 180;
            dgvGrilla.Columns[13].Width = 100;
            dgvGrilla.Columns[14].Width = 100;
            dgvGrilla.Columns[15].Width = 30;
          
            foreach (DataGridViewRow dgvR in dgvGrilla.Rows)
            {
                colorearFila(dgvR);
            }

            if (dgvGrilla.Rows.Count > 0 && puntero != -1 && (puntero <= dgvGrilla.Rows.Count - 1))
            {
                dgvGrilla.CurrentCell = dgvGrilla.Rows[puntero].Cells[4];
            }
            if (dgvGrilla.Rows.Count > 0 && puntero == -1)
            {
                dgvGrilla.CurrentCell = dgvGrilla.Rows[0].Cells[4];
            }

            lblTotal.Text = "Total Pacientes: " + dgvGrilla.Rows.Count.ToString();

            this.ActiveControl = dgvGrilla;                       
        }

        private void colorearFila(DataGridViewRow row)
        {
            Color color = Color.White;
            switch (row.Cells[7].Value.ToString())
            {
                case "P":
                    color = Color.MistyRose;
                    break;
                case "L":
                    color = Color.Moccasin;
                    break;
                case "EC":
                    color = Color.Azure;
                    break;
                case "CO":
                    color = Color.LightSteelBlue;
                    break;
                case "R":
                    color = Color.LightYellow;
                    break;
            }
            row.DefaultCellStyle.BackColor = color;
        }


  
        private List<object> obtenerNroOrden(string idPaciente)
        {
                List<object> retorno = new List<object>();
                DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString(@"select * from Consulta c where convert(Date,c.fecha) = '" + DateTime.Today.ToShortDateString() + "' and c.nroOrden != 0 and c.nroOrden != -1 and c.tipo != 'V' order by c.nroOrden asc");
                if (tabla.Rows.Count > 0)
                {
                    int anterior = 0;
                    foreach (DataRow r in tabla.Rows)
                    {
                        anterior++;
                        if (anterior != (int)r.ItemArray[4])
                        {
                            DialogResult result = MessageBox.Show("Se encontró el número de orden ---" + anterior + 
                                "--- que no está asignado. ¿Desea reasignar ese numero a este ingreso?", "Resasignar Numeración",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                retorno.Add(anterior);
                                retorno.Add(true);
                                return retorno;
                            }
                            else
                            {
                                retorno.Add((int)tabla.Rows[tabla.Rows.Count - 1].ItemArray[4] + 1);
                                retorno.Add(false);
                                return retorno;
                            }

                        }
                    }
                    retorno.Add((int)tabla.Rows[tabla.Rows.Count - 1].ItemArray[4] + 1);
                    retorno.Add(false);
                    return retorno;
     
                }
                else
                {
                    retorno.Add(1);
                    retorno.Add(false);
                    return retorno;
                }
            
        }

        private int obtenerNroIdentificador(string tipo,string idPaciente, bool reasignar)
        {
                DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString("select * from Consulta c where convert(Date,c.fecha) = '" + DateTime.Today.ToShortDateString() + "' and c.tipo = '" + tipo + "' order by convert(int,c.nroOrden) asc");
                List<object> retorno = new List<object>();
                if (tabla.Rows.Count > 0)
                {

                    if (tipo == "P")
                    {                   
                        //int anterior = 199;
                        //if (tabla.Rows.Count >= 200)
                        //{
                        //    anterior = 599;
                        //}
                    
                        //foreach (DataRow r in tabla.Rows)
                        //{
                        //    anterior++;
                        //    if (reasignar && (anterior != Convert.ToInt32(r.ItemArray[5])))
                        //    {
  
                        //           return anterior;
                        
                        //    }
                        //}
                        //return Convert.ToInt32(tabla.Rows[tabla.Rows.Count - 1].ItemArray[5]) + 1;
                        return generaNroIdentificadorPre(tipo, idPaciente);

                    }
                    else
                    {
                        // GRV - Modificado
                        //int anterior = 0;
                        //foreach (DataRow r in tabla.Rows)
                        //{
                        //    anterior++;
                        //    if (reasignar && (anterior != quitarLetras(r.ItemArray[5].ToString())))
                        //    {
                        //        return anterior;
                        //    }
                        //}
                        //return quitarLetras(tabla.Rows[tabla.Rows.Count - 1].ItemArray[5].ToString()) + 1;
                        return generaNroIdentificador(tipo, idPaciente);
                    }
                  
                }
                else
                {
                    if (tipo == "P")
                    {
                        if (intContPre > 1)
                            return intContPre;//200;
                        else
                            return intContPre--;
                    }
                    else
                    {
                        return 1;
                    }
                }            
        }

        private int quitarLetras(string identificador)
        {
            char[] MyChar = { 'L', 'C', 'O', 'P', 'R' , 'E' };
            int numero = (Int32.Parse(identificador.TrimStart(MyChar)));
            return numero;
        }

        private string insertarEnBaseDeDatosPreventiva(string tipo, int modo, string id)
        {
            string idPaciente = "";
            string strResultado = ""; // GRV - Modificado
            if (id == "")
            {
                idPaciente = dgvTurno.SelectedRows[0].Cells[9].Value.ToString();
            }
            else
            {
                idPaciente = id;
            }

            if (cbTipoDeExamen.Text == "INFANTIL INICIAL")
            {
                CapaNegocioMepryl.PacientePreventiva PacientePre = new CapaNegocioMepryl.PacientePreventiva();

                if (VerificaCategoriaPacienteInicial(PacientePre.ObtenerDNIpaciente(idPaciente)))
                {
                    if (!PacienteRepetido(idPaciente))
                    {
                        List<object> retorno = obtenerNroOrden(idPaciente);
                        int nroOrden = (int)retorno[0];
                        string nroIdentificador = obtenerNroIdentificador(tipo, idPaciente, (bool)retorno[1]).ToString();
                        string idTurno = "";
                        if (modo == 0)
                        {
                            idTurno = dgvTurno.SelectedRows[0].Cells[0].Value.ToString();
                        }
                        else
                        {
                            idTurno = "00000000-0000-0000-0000-000000000000";
                        }

                        List<string> lista = SQLConnector.generarListaParaProcedure("@tipo", "@fecha", "@nroOrden", "@identificador", "@pacienteID", "@observaciones", "@valido", "@idTurno");
                        //GRV - Modificado
                        //return (string)SQLConnector.executeProcedureWithReturnValue("sp_Consulta_Insert", lista, tipo, DateTime.Now, nroOrden, nroIdentificador, idPaciente, "", "1",idTurno);
                        strResultado = (string)SQLConnector.executeProcedureWithReturnValue("sp_Consulta_Insert", lista, tipo, DateTime.Now, nroOrden, nroIdentificador, idPaciente, "", "1", idTurno);
                    }
                    else
                    {
                        MessageBox.Show("El paceinte ya se encuentra ingresado en la mesa de entrada", "Mesa de entrada",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("El paciente no corresponde al tipo de examen 'INFANTIL INICIAL'...", "Asignar turnos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (!PacienteRepetido(idPaciente))
                {
                    List<object> retorno = obtenerNroOrden(idPaciente);
                    int nroOrden = (int)retorno[0];
                    string nroIdentificador = obtenerNroIdentificador(tipo, idPaciente, (bool)retorno[1]).ToString();
                    string idTurno = "";
                    if (modo == 0)
                    {
                        idTurno = dgvTurno.SelectedRows[0].Cells[0].Value.ToString();
                    }
                    else
                    {
                        idTurno = "00000000-0000-0000-0000-000000000000";
                    }

                    List<string> lista = SQLConnector.generarListaParaProcedure("@tipo", "@fecha", "@nroOrden", "@identificador", "@pacienteID", "@observaciones", "@valido", "@idTurno");
                    //GRV - Modificado
                    //return (string)SQLConnector.executeProcedureWithReturnValue("sp_Consulta_Insert", lista, tipo, DateTime.Now, nroOrden, nroIdentificador, idPaciente, "", "1",idTurno);
                    strResultado = (string)SQLConnector.executeProcedureWithReturnValue("sp_Consulta_Insert", lista, tipo, DateTime.Now, nroOrden, nroIdentificador, idPaciente, "", "1", idTurno);
                }
                else
                {
                    MessageBox.Show("El paceinte ya se encuentra ingresado en la mesa de entrada", "Mesa de entrada",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return strResultado;
        }

        private string insertarEnBaseDeDatosOtros(string tipo, int modo, string id)
        {
            string idPaciente = "";
            if (id == "")
            {
                idPaciente = dgvTurno.SelectedRows[0].Cells[9].Value.ToString();
            }
            else
            {
                idPaciente = id;
            }
            List<object> retorno = obtenerNroOrden(idPaciente);
            int nroOrden = (int)retorno[0];
            string nroIdentificador = obtenerNroIdentificador(tipo, idPaciente, (bool)retorno[1]).ToString();
            string idTurno = "";
            if (modo == 0)
            {
                idTurno = dgvTurno.SelectedRows[0].Cells[0].Value.ToString();
            }
            else
            {
                idTurno = "00000000-0000-0000-0000-000000000000";
            }

            //if ((strTipoConsulta == "REINGRESO LABORAL ") || (strTipoConsulta == "REINGRESO LABORAL"))
            //    nroOrden = 0;

            List<string> lista = SQLConnector.generarListaParaProcedure("@tipo", "@fecha", "@nroOrden", "@identificador", "@pacienteID", "@observaciones", "@valido","@idTurno");
            return (string)SQLConnector.executeProcedureWithReturnValue("sp_Consulta_Insert", lista, tipo, DateTime.Now, nroOrden, tipo + nroIdentificador, idPaciente, "", "1",idTurno);
        }

        private string checkearRadioButton()
        {
            if (botonPreventiva.Checked == true)
                return "P";
            if (botonLaboral.Checked == true)
                return "L";
            if (botonClinica.Checked == true)
                return "OC";
            if (botonRepeticion.Checked == true)
                return "R";
            if (botonConsultorio.Checked == true)
                return "CO";
            return "";

        }

        private void limpiarLabels()
        {
            tbDni.Clear();
            tbApellido.Clear();
            tbNacimiento.Clear();
            tbNombre.Clear();
            tbTelefono.Clear();
            tbObsTurno.Clear();
            lblNroOrdenDato.Text = "";
            lblNroExamenDato.Text = "";
            tbObsMesaEntrada.Text = "";
            dgvInformacionPaciente.DataSource = null;
        }


        private void updateObservacionPaciente()
        {
            try
            {
                string idConsulta = dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string observacion = tbObsMesaEntrada.Text;
                List<string> lista = SQLConnector.generarListaParaProcedure("@id", "@observaciones");
                SQLConnector.executeProcedure("sp_Consulta_UpdateObservacion", lista, idConsulta, observacion);
                cargarGrilla();
            }
            catch (System.NullReferenceException ex)
            {
                //
            }
        }

        public void mostrarDatos()
        {
           

            if (dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells[0].Value != null)
            {
                CapaNegocioMepryl.PacientePreventiva PacientePre = new PacientePreventiva();

                limpiarLabels();

                panelTurnos.Visible = false;
                panelDatos.Visible = true;

                lblNroExamenDato.Visible = true;
                lblNroOrdenDato.Visible = true;

                Entidades.MesaEntrada entidad =  mesaEntrada.cargarInformacionConsulta(
                    new Guid(dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells[0].Value.ToString()));

                tbDni.Text = entidad.Dni;
                tbApellido.Text = entidad.Apellido;
                tbNombre.Text = entidad.Nombre;
                tbTelefono.Text = entidad.Telefono + " " + entidad.Celular;
                tbObsMesaEntrada.Text = entidad.ObservacionesMesaEntrada;
                tbObsTurno.Text = entidad.ObservacionesTurno;
                tbNacimiento.Text = entidad.Nacimiento;
                dgvInformacionPaciente.DataSource = entidad.ClubesOEmpresa;
                lblNroOrdenDato.Text = entidad.NroOrden;
                lblNroExamenDato.Text = entidad.NroExamen;
                strIdEmpresa = dgvInformacionPaciente.Rows[0].Cells[2].Value.ToString(); // GRV - Ramírez

                tbClinico.Text = entidad.TipoExamen.TextoClinico;
                tbLaboratorio.Text = entidad.TipoExamen.TextoLaboratorio;
                tbRx.Text = entidad.TipoExamen.TextoRx;
                tbEstudiosComplementarios.Text = entidad.TipoExamen.TextoEstComplement;
                tbTipoExamen.Text = entidad.TipoExamen.Descripcion;
                if (entidad.TipoExamen.Modificado)
                {
                    tbTipoExamen.Text = tbTipoExamen.Text + " (*)";
                }

                //if (!PacientePre.DebeRealizarExamenRX(entidad.Dni))
                //{
                //    tbTipoExamen.Text = entidad.TipoExamen.Descripcion + " (*)";
                //}
                                                
                    
                if (!primeraVez)
                {
                    puntero = dgvGrilla.CurrentCell.RowIndex;
                }
                else
                {
                    primeraVez = false;
                }

                dgvInformacionPaciente.Columns[2].Visible = false;

                deschekearComboBoxs();
               
            }
        }

        private void invalidarConsulta()
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar al paciente ingresado?", "Eliminar ingreso", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select id from dbo.TipoExamenDePaciente
                where idConsulta = '" + dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'");

                    string idTe = tipoExamen.Rows[0].ItemArray[0].ToString();
                    string idC = dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    exPreventiva.eliminarExamen(idTe, idC);

                    MessageBox.Show("Consulta eliminada correctamente", "Eliminar Ingreso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede eliminar la consulta. Error:\n\n" + ex.ToString(),
                        "Eliminar Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cargarGrilla();
             
            }

        }

        private void buscar()
        {
            DataTable tabla = (DataTable)dgvTurno.DataSource;
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();
            if (cboTipoBusqueda.SelectedIndex == 0) filtrosBusqueda.Add("Apellido LIKE '%" + tbBusqueda.Text + "%'");
            if (cboTipoBusqueda.SelectedIndex == 1) filtrosBusqueda.Add("Nombre LIKE '%" + tbBusqueda.Text + "%'");
            if (cboTipoBusqueda.SelectedIndex == 2 && tbBusqueda.Text != "") filtrosBusqueda.Add("DNI = " + tbBusqueda.Text);
            if (cboTipoBusqueda.SelectedIndex == 3 && tbBusqueda.Text != "") filtrosBusqueda.Add("Código = " + tbBusqueda.Text);


            foreach (var filtro in filtrosBusqueda)
            {
                if (!posFiltro)
                    final_rol += " AND " + filtro;
                else
                {
                    final_rol += filtro;
                    posFiltro = false;
                }
            }
            if (tabla != null)
                tabla.DefaultView.RowFilter = final_rol;
            dgvTurno.DataSource = tabla;


        }


        private void botonAgregar_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmPaciente(new Configuracion(), true), new Configuracion());
        }

        private void dgvGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mostrarDatos();
            if (e.ColumnIndex == 15)
            {
                List<string> lista = SQLConnector.generarListaParaProcedure("@idConsulta", "@valor");
                if ((bool)dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells[e.ColumnIndex].Value == true)
                {
                    dgvGrilla.Rows[dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Index].Cells[e.ColumnIndex].Value = false;
                    SQLConnector.executeProcedure("sp_retiraEnMepryl_update", lista, new Guid(dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells[0].Value.ToString()), "0");
                }
                else
                {
                    SQLConnector.executeProcedure("sp_retiraEnMepryl_update", lista, new Guid(dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells[0].Value.ToString()), "1");
                    dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
            }
            deschekearComboBoxs();
        }

        private void deschekearComboBoxs()
        {
            if (botonPreventiva.Checked == true) botonPreventiva.Checked = false;
            if (botonLaboral.Checked == true) botonLaboral.Checked = false;
            if (botonClinica.Checked == true) botonClinica.Checked = false;
            if (botonConsultorio.Checked == true) botonConsultorio.Checked = false;
            if (botonRepeticion.Checked == true) botonRepeticion.Checked = false;
            
        }

        private void botonPreventiva_CheckedChanged(object sender, EventArgs e)
        {
            if (botonPreventiva.Checked == true)
            {
                lblNroOrdenDato.Visible = false;
                lblNroExamenDato.Visible = false;
                cargarDataGridTurno("1");
                llenarComboBox("1");
            }
            else
            {
                cbTipoDeExamen.DataSource = null;
            }
        }

        private void cargarDataGridTurno(string motivoConsulta)
        {
            panelTurnos.Visible = true;
            panelDatos.Visible = false;
            dgvTurno.DataSource = mesaEntrada.cargarTurnosSegunMotivoDeConsulta(motivoConsulta);
            dgvTurno.Columns[0].Visible = false;
            dgvTurno.Columns[9].Visible = false;
            dgvTurno.Columns[10].Visible = false;
            dgvTurno.Columns[11].Visible = false;
            botonRegresarRecepcion.Visible = true;
        }

        private void botonLaboral_CheckedChanged(object sender, EventArgs e)
        {
            if (botonLaboral.Checked)
            {
                lblNroOrdenDato.Visible = false;
                lblNroExamenDato.Visible = false;
                cargarDataGridTurno("2");
                llenarComboBox("2");
            }
            else
            {
                cbTipoDeExamen.DataSource = null;
            }
        }

        private void botonClinica_CheckedChanged(object sender, EventArgs e)
        {
            if (botonClinica.Checked)
            {
                lblNroOrdenDato.Visible = false;
                lblNroExamenDato.Visible = false;
                cargarDataGridTurno("3");
                llenarComboBox("3");
            }
            else
            {
                cbTipoDeExamen.DataSource = null;
            }

        }

        private void botonConsultorio_CheckedChanged(object sender, EventArgs e)
        {
            if (botonConsultorio.Checked)
            {
                lblNroOrdenDato.Visible = false;
                lblNroExamenDato.Visible = false;
                cargarDataGridTurno("4");
                llenarComboBox("4");
            }
            else
            {
                cbTipoDeExamen.DataSource = null;
            }
        }

        private void botonRepeticion_CheckedChanged(object sender, EventArgs e)
        {
            if (botonRepeticion.Checked)
            {
                lblNroOrdenDato.Visible = false;
                lblNroExamenDato.Visible = false;
                cargarDataGridTurno("5");
                llenarComboBox("5");
            }
            else
            {
                cbTipoDeExamen.DataSource = null;
            }
        }


        private void cargarTurnoSeleccionado()
        {
            if (botonPreventiva.Checked) cargarDataGridTurno("1");
            if (botonLaboral.Checked) cargarDataGridTurno("2");
            if (botonClinica.Checked) cargarDataGridTurno("3");
            if (botonConsultorio.Checked) cargarDataGridTurno("4");
            if (botonRepeticion.Checked) cargarDataGridTurno("5");
         
        }

        public void ingresarPaciente()
        {
            //if ((strTipoConsulta == "REINGRESO LABORAL ") || (strTipoConsulta == "REINGRESO LABORAL"))
            //{
            //    asignarPacienteLaboral(dgvTurno.SelectedRows[0].Cells[9].Value.ToString(), strIdEmpresaNuevoConsultorio);
            //    LimpiaDatosGenerarConsultorio();
            //}

            if (dgvTurno.Rows.Count > 0)
            {
                ///////!existeEnListado(dgvTurno.SelectedRows[0].Cells[9].Value.ToString())
                if (true)
                {
                    if (estaHabilitado(dgvTurno.SelectedRows[0].Cells[9].Value.ToString()))
                    {
                        string motivo = dgvTurno.SelectedRows[0].Cells[6].Value.ToString();
                        string idConsulta = "";
                        if (motivo == "PREVENTIVA")
                            idConsulta = insertarEnBaseDeDatosPreventiva("P", 0, "");
                        if (motivo == "LABORAL")
                            idConsulta = insertarEnBaseDeDatosOtros("L", 0, "");
                        if (motivo == "CONSULTAS")
                            idConsulta = insertarEnBaseDeDatosOtros("CO", 0, "");
                        if (motivo == "REPETICIONES")
                            idConsulta = insertarEnBaseDeDatosOtros("R", 0, "");
                        if (motivo == "ESTUDIOS COMPLEMENTARIOS")
                            idConsulta = insertarEnBaseDeDatosOtros("EC", 0, "");


                        List<string> lista = SQLConnector.generarListaParaProcedure("@id", "@valor");
                        SQLConnector.executeProcedure("sp_Turno_UpdateMesaDeEntrada", lista, dgvTurno.SelectedRows[0].Cells[0].Value.ToString(), "1");

                        List<string> list = SQLConnector.generarListaParaProcedure("@idTurno", "@idConsulta");
                        SQLConnector.executeProcedure("sp_Items_UpdateItemsPorPaciente", list, dgvTurno.SelectedRows[0].Cells[0].Value.ToString(), idConsulta);

                        if (mesaEntrada.verificarTipoPaciente(new Guid(dgvTurno.SelectedRows[0].Cells[9].Value.ToString())) == 'P')
                        {
                            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select pacienteID from dbo.Consulta
                            where id = '" + idConsulta + "'");
                            if (consulta.Rows.Count > 0)
                            {
                                string paciente = consulta.Rows[0].ItemArray[0].ToString();
                                DataTable clubesPorPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.clubesPorPaciente
                                where paciente = '" + paciente + "'");
                                if (clubesPorPaciente.Rows.Count > 0)
                                {
                                    DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.TipoExamenDePaciente
                                    where idConsulta = '" + idConsulta + "'");

                                    if (tipoExamen.Rows.Count > 0)
                                    {

                                        string idTe = tipoExamen.Rows[0].ItemArray[0].ToString();

                                        DataTable clubesPorTipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select * 
                                       from dbo.clubesPorTipoExamen where idTipoExamen = '" + idTe + "'");
                                        if (clubesPorTipoExamen.Rows.Count == 0)
                                        {
                                            List<string> add = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idClub");
                                            foreach (DataRow r in clubesPorPaciente.Rows)
                                            {
                                                SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add",
                                                    add, new Guid(idTe), new Guid(r.ItemArray[2].ToString()));

                                            }
                                        }
                                        if (motivo == "PREVENTIVA")
                                        {
                                            exPreventiva.crearExamen(idTe);
                                        }
                                    }

                                    
                                }
                            }
                        }
                        else
                        {
                            generarLaboral(idConsulta);
                        }
                        cargarGrilla();
                        cargarTurnoSeleccionado();
                        if (dgvGrilla.Rows.Count > 0)
                        {
                            dgvGrilla.CurrentCell = dgvGrilla.Rows[dgvGrilla.Rows.Count - 1].Cells[4];
                            puntero = dgvGrilla.CurrentCell.RowIndex;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede ingresar paciente ya que se encontró como inhabilitado. Por favor verifique en exámenes para volverlo a"
                            + " habilitar e ingresarlo nuevamente", "Jugador inhabilitado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString(@"select dni from dbo.Paciente
                    where id = '" + dgvTurno.SelectedRows[0].Cells[9].Value.ToString() + "'");
                        frmBusquedaExamen busq = new frmBusquedaExamen(this,1);
                        Utilidades.abrirFormulario(this.MdiParent, busq, new Configuracion());
                        busq.gbRango.Enabled = true;
                        busq.gbFecha.Enabled = false;
                        busq.tbBusqueda.Text = paciente.Rows[0].ItemArray[0].ToString();
                        busq.botonBuscar.PerformClick();
                      
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¡El paciente ya fue ingresado!\n¿Desea invalidar el turno?",
                        "DNI Ingresado",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        List<string> lista = SQLConnector.generarListaParaProcedure("@id", "@valor");
                        SQLConnector.executeProcedure("sp_Turno_UpdateMesaDeEntrada", lista, dgvTurno.SelectedRows[0].Cells[0].Value.ToString(), "1");
                        cargarTurnoSeleccionado();

                    }
                   
                }
                setearTotales();
                dgvGrilla.AllowUserToResizeColumns = true;
            }
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            tbBusqueda.Text = "";
            cargarTurnoSeleccionado();
        }

        private void botonActualiz_Click(object sender, EventArgs e)
        {
            updateObservacionPaciente();
        }

        private void botonBuscarDni_Click(object sender, EventArgs e)
        {
            if (cbTipoDeExamen.SelectedIndex != -1)
            {
                verificarMotivoConsulta();
                /*
                DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Paciente where dni = '" + tbBusquedaDni.Text + "'");

                string apellido = paciente.Rows[0].ItemArray[2].ToString();
                string nombre = paciente.Rows[0].ItemArray[3].ToString();
                DataRowView drv = (DataRowView)cbTipoDeExamen.SelectedItem;
                string motivoDeConsulta = drv.Row[2].ToString();
                string dni = paciente.Rows[0].ItemArray[7].ToString();
                DialogResult result = MessageBox.Show("El siguiente paciente va a ser ingresado: \n\n\t DNI: " + dni + "\n\t APELLIDO: " + apellido + "\n\t NOMBRE: " + nombre + "\n\t MOTIVO DE CONSULTA: " + motivoDeConsulta + "\n\n ¿Desea continuar?", "Confirmar Ingreso", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    cargarPaciente(paciente.Rows[0].ItemArray[0].ToString(), dni);
                }
                */
                 
            }
            else
            {
                MessageBox.Show("¡Seleccione un tipo de exámen válido!","Seleccionar Tipo Examen",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void verificarMotivoConsulta()
        {
            if (botonPreventiva.Checked)
            {
                abrirVentanaPacientePreventivaAsignacion();
            }
            else if (botonLaboral.Checked)
            {
                abrirVentanaPacienteLaboralAsignacion();
            }
            else
            {
                abrirVentanaTipoPaciente();
            }
        }

        /*
        private void cargarPaciente(string idPaciente, string dni)
        {
            if (!existeEnListado(idPaciente))
            {
                if (estaHabilitado(dni))
                {
                    string idTipoDeExamen = cbTipoDeExamen.SelectedValue.ToString();
                    DataTable motivoConsulta = SQLConnector.obtenerTablaSegunConsultaString("Select mc.id, mc.nombre, mc.identificadorInterno, e.id from dbo.Especialidad e inner join dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id where e.id = '" + idTipoDeExamen + "'");
                    string motivo = motivoConsulta.Rows[0].ItemArray[1].ToString();
                    string idEspecialidad = motivoConsulta.Rows[0].ItemArray[3].ToString();
                    string idConsulta = "";
                    if (motivo == "PREVENTIVA")
                        idConsulta = insertarEnBaseDeDatosPreventiva("P", 1, idPaciente);
                    if (motivo == "LABORAL")
                        idConsulta = insertarEnBaseDeDatosOtros("L", 1, idPaciente);
                    if (motivo == "CONSULTAS")
                        idConsulta = insertarEnBaseDeDatosOtros("CO", 1, idPaciente);
                    if (motivo == "REPETICIONES")
                        idConsulta = insertarEnBaseDeDatosOtros("R", 1, idPaciente);
                    if (motivo == "ESTUDIOS COMPLEMENTARIOS")
                        idConsulta = insertarEnBaseDeDatosOtros("EC", 1, idPaciente);
                    DataTable esp = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Especialidad where id = '" + idEspecialidad + "'");
                    double imp;
                    if (esp.Rows[0].ItemArray[9].ToString() != "")
                    {
                        imp = Convert.ToDouble(esp.Rows[0].ItemArray[9].ToString());
                    }
                    else
                    {
                        imp = 0;
                    }
                    List<string> lista = SQLConnector.generarListaParaProcedure("@idConsulta", "@idTurno", "@modificado", "@idEspecialidad", "@importe", "@factClub");
                    string retorno = SQLConnector.executeProcedureWithReturnValue("sp_TipoExamenDePaciente_Add", lista, new Guid(idConsulta), new Guid("00000000-0000-0000-0000-000000000000"), "", new Guid(idEspecialidad), imp, "0");
                    DataTable predefinidos = SQLConnector.obtenerTablaSegunConsultaString(@"select I.id As IdItem, IP.estado as Estado 
                    from dbo.ItemsPredefinidos IP inner join dbo.Items I
                    on IP.idItem = I.id  where IP.idEspecialidad = '" + idEspecialidad + "' order by IP.idItem asc");
                    List<string> listaProcedure = SQLConnector.generarListaParaProcedure("@idItem", "@idExamenPaciente", "@estado");
                    foreach (DataRow row in predefinidos.Rows)
                    {
                        SQLConnector.executeProcedure("sp_Items_AddPorPaciente", listaProcedure, row.ItemArray[0], new Guid(retorno), row.ItemArray[1]);
                    }
                    DataTable c = SQLConnector.obtenerTablaSegunConsultaString("select cp.club from dbo.clubesPorPaciente cp where cp.paciente = '" + idPaciente + "'");
                    if (c.Rows.Count > 0)
                    {
                        foreach (DataRow r in c.Rows)
                        {
                            if (r.ItemArray[0].ToString() != "00000000-0000-0000-0000-000000000000")
                            {
                                List<string> add = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idClub");
                                SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add", add, new Guid(retorno), new Guid(r.ItemArray[0].ToString()));
                            }
                        }
                    }

                    DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString("select p.empresaID, p.empresaTarea from dbo.Paciente p where p.id = '" + idPaciente + "'");
                    string empresaId = paciente.Rows[0].ItemArray[0].ToString();
                    string tarea = paciente.Rows[0].ItemArray[1].ToString();
                    if (empresaId != "00000000-0000-0000-0000-000000000000" && empresaId != "")
                    {
                        List<string> procedure = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idEmpresa", "@tarea");
                        SQLConnector.executeProcedure("sp_empresaPorTipoDeExamen_Add", procedure, new Guid(retorno), new Guid(empresaId), tarea);
                    }

                    if (motivo == "LABORAL" || motivo == "CONSULTAS"
                        || motivo == "REPETICIONES" || motivo == "ESTUDIOS COMPLEMENTARIOS")
                    {
                        generarLaboral(idConsulta);
                    }
                    else if (motivo == "PREVENTIVA")
                    {
                        exPreventiva.crearExamen(retorno);
                    }

                    puntero = dgvGrilla.Rows.Count;
                    cargarGrilla();
                    cbTipoDeExamen.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No se puede ingresar paciente ya que se encontró como inhabilitado. Por favor verifique en exámenes para volverlo a"
                    + " habilitar e ingresarlo nuevamente", "Jugador inhabilitado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString(@"select dni from dbo.Paciente
                    where id = '" + idPaciente + "'");
                    frmBusquedaExamen busq = new frmBusquedaExamen(this,2);
                    Utilidades.abrirFormulario(this.MdiParent, busq, new Configuracion());
                    busq.gbRango.Enabled = true;
                    busq.gbFecha.Enabled = false;
                    busq.tbBusqueda.Text = paciente.Rows[0].ItemArray[0].ToString();
                    busq.botonBuscar.PerformClick();

                }
             
            }
            else
            {
                MessageBox.Show("¡El paciente ya fue ingresado!");
            }


        }
        */

        private bool existeEnListado(string idPaciente)
        {
            foreach (DataGridViewRow row in dgvGrilla.Rows)
            {
                if (row.Cells[1].Value.ToString() == idPaciente)
                {
                    return true;
                }

            }
            return false;
        }

        private void frmMesaDeEntrada_Enter(object sender, EventArgs e)
        {
            cargarGrilla();
        }



        public void imprimirComprobante()
        {
            if (dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex] != null)
            {
               
                DialogResult result = MessageBox.Show("¿Imprimir hoja de ruta?", "Imprimir", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    imprimirHojaRuta();
                }
                DialogResult result1 = MessageBox.Show("¿Imprimir examen clinico?", "Imprimir", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    imprimirClinico();
                }

            }
            else
            {
                MessageBox.Show("Seleccione un paciente para imprimir");
            }

        }


        private void imprimirClinico()
        {
             Reportes report = new Reportes(new rptExamenClinico());
             report.imprimir(mesaEntrada.cargarParametrosReporteExClinico(dgvGrilla.Rows[dgvGrilla.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
        }



        private void imprimirHojaRuta()
        {
            Reportes report = new Reportes(new rptHojaRuta());
            report.imprimir(mesaEntrada.cargarParametrosReporteHojaRuta(dgvGrilla.Rows[dgvGrilla.SelectedCells[0].RowIndex].Cells[0].Value.ToString()));
        }

       


        private void tbBusquedaDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                botonBuscarDni.PerformClick();
            }
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (tbBusqueda.Text == "")
            {
                cargarTurnoSeleccionado();
            }
        }

        private void tbBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                botonBuscar.PerformClick();
            }
        }

        private void dgvGrilla_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvGrilla.CurrentCell != null)
            {
                mostrarDatos();
            }
        }

        private void butSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonEditar_Click(object sender, EventArgs e)
        {
            //Utilidades.abrirFormulario(this.MdiParent, new frmPaciente(this,new Configuracion(), true, lblDniDato.Text, 2), new Configuracion());
        }

        private void cargarTotalATextBox(string motivoConsulta, TextBox tb)
        {
            try
            {
                DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString(@"select t.id from dbo.Turno t inner join dbo.TipoExamenDePaciente ep 
            on ep.idTurno = t.id inner join dbo.Especialidad e on ep.idEspecialidad = e.id inner join 
            dbo.MotivoDeConsulta mc on e.idMotivoConsulta = mc.id where t.recepcion = '1' and t.mesaDeEntrada = '0' and mc.id = " + motivoConsulta);
                int cantidad = tabla.Rows.Count;
                if (cantidad > 0)
                {
                    tb.Text = cantidad.ToString();
                }
                else
                {
                    tb.Text = "-";
                }
            }
            catch (System.NullReferenceException ex)
            {
                //
            }


        }

        private void setearTotales()
        {
            cargarTotalATextBox("1", tbTotalP);
            cargarTotalATextBox("2", tbTotalL);
            cargarTotalATextBox("3", tbTotalEC);
            cargarTotalATextBox("4", tbTotalC);
            cargarTotalATextBox("5", tbTotalR);
        }

        private void botonRegresarRecepcion_Click(object sender, EventArgs e)
        {
            if (dgvTurno.SelectedRows.Count > 0)
            {
                List<string> lista = SQLConnector.generarListaParaProcedure("@id", "@valor");
                SQLConnector.executeProcedure("sp_Turno_CambiarEstadoRecepcion", lista, new Guid(dgvTurno.SelectedRows[0].Cells[0].Value.ToString()), "0");
                cargarTurnoSeleccionado();
            }
            else
            {
                MessageBox.Show("Seleccione un paciente para regresarlo a ventanilla");
            }
        }

        private void botonRegresarPaciente_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.SelectedRows.Count > 0)
            {







            }
            else
            {
                MessageBox.Show("Seleccione un paciente para regresar a la espera");
            }
        }


        public void comprobarEmpresaYClub()
        {
            string idConsulta = dgvGrilla.CurrentRow.Cells[0].Value.ToString();
            string idPaciente = dgvGrilla.CurrentRow.Cells[1].Value.ToString();
            DataTable tipoDeEx = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.TipoExamenDePaciente where idConsulta = '" + idConsulta + "'");
            DataTable clubesDePaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id as Club from clubesPorPaciente cp inner join Club c on cp.club = c.id
                                                                                      where cp.paciente = '" + idPaciente + "'");

            List<string> listDelete = SQLConnector.generarListaParaProcedure("@idTipoExamen");
            SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Delete", listDelete, new Guid(tipoDeEx.Rows[0].ItemArray[0].ToString()));

            foreach (DataRow r in clubesDePaciente.Rows)
            {
                List<string> listAdd = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idClub");
                SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add", listAdd,
                    new Guid(tipoDeEx.Rows[0].ItemArray[0].ToString()),
                    new Guid(r.ItemArray[0].ToString()));
            }

        }

        private void modifTE_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.CurrentRow.Index >= 0)
            {
                Utilidades.abrirFormulario(this.MdiParent, new frmModifTE(this), new Configuracion());
            }
        }

        public void modificarTipoExamen(string idEsp)
        {
            DataTable especialidad = SQLConnector.obtenerTablaSegunConsultaString(@"select e.descripcion,
            e.precioBase from dbo.Especialidad e where e.id = '" + idEsp + "'");
            DataTable te = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.TipoExamenDePaciente where
            idConsulta = '" + dgvGrilla.CurrentRow.Cells[0].Value.ToString() + "'");
            List<string> listaUpdateTE = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idEsp", "@importe");
            SQLConnector.executeProcedure("dbo.sp_TipoExamenDePaciente_UpdateTipo", listaUpdateTE,
                new Guid(te.Rows[0].ItemArray[0].ToString()), new Guid(idEsp), especialidad.Rows[0].ItemArray[1]);
            List<string> listDelete = SQLConnector.generarListaParaProcedure("@id");
            SQLConnector.executeProcedure("sp_ItemsPorPaciente_Delete", listDelete, new Guid(te.Rows[0].ItemArray[0].ToString()));
            DataTable itemsPredefinidos = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ItemsPredefinidos
            where idEspecialidad = '" + idEsp + "'");
            List<string> listAdd = SQLConnector.generarListaParaProcedure("@idItem", "@idExamenPaciente", "@estado");
            foreach (DataRow row in itemsPredefinidos.Rows)
            {
                SQLConnector.executeProcedure("sp_Items_AddPorPaciente", listAdd,
                    row.ItemArray[2], new Guid(te.Rows[0].ItemArray[0].ToString()),
                    row.ItemArray[3].ToString());
            }
            cargarGrilla();
            mostrarDatos();
        }

        private bool estaHabilitado(string idPaciente)
        {
            DataTable examenesRealizados = SQLConnector.obtenerTablaSegunConsultaString(@"select tep.id from dbo.Consulta
            c inner join dbo.TipoExamenDePaciente tep
            on tep.idConsulta = c.id 
            inner join dbo.Paciente p on c.pacienteID = p.id
            where p.id = '" + idPaciente + "' and c.tipo = 'P' order by c.fecha desc");
            if (examenesRealizados.Rows.Count > 0)
            {
                return !exPreventiva.estaInhabilitado(examenesRealizados.Rows[0][0].ToString());
            }
            return true;
        }

        private string consultarCodigoValidacion(DataTable ve, string codigo)
        {
            DataTable valid = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Validaciones");
            DataRow[] rows = ve.Select("codigo = '" + codigo + "'");
            if (rows.Length > 0)
            {
                string idValidacion = rows[0][3].ToString();
                DataRow[] r = valid.Select("id = " + idValidacion);
                return r[0][2].ToString();
            }
            else
            {
                return "00";
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            setearTotales();
        }

        private void generarLaboral(string idConsulta)
        {
            DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.TipoExamenDePaciente
            where idConsulta = '" + idConsulta + "'");
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.Consulta where id = '" + idConsulta + "'");
            if (consulta.Rows.Count > 0)
            {
//                DataTable especialidad = null;

//                if ((strTipoConsulta == "REINGRESO LABORAL ") || (strTipoConsulta == "REINGRESO LABORAL"))
//                {
//                    especialidad = SQLConnector.obtenerTablaSegunConsultaString(@"select tipo, descripcion from dbo.Especialidad
//                where id = '254110EB-0A50-47D8-89EF-118D163FCE8B'"); // Id de Consultorio
//                }
//                else
//                {
//                    especialidad = SQLConnector.obtenerTablaSegunConsultaString(@"select tipo, descripcion from dbo.Especialidad
//                where id = '" + tipoExamen.Rows[0].ItemArray[4].ToString() + "'");
//                }

                DataTable especialidad = SQLConnector.obtenerTablaSegunConsultaString(@"select tipo, descripcion from dbo.Especialidad
                where id = '" + tipoExamen.Rows[0].ItemArray[4].ToString() + "'");
                DataTable lugarAtencion = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.LugarAtencion");
                string idConsultaLaboral;
                DateTime fecha = (DateTime)consulta.Rows[0].ItemArray[3];
                Guid lugarAtenc = new Guid(lugarAtencion.Select("codigo = 1")[0][0].ToString());

                if (especialidad.Rows[0].ItemArray[0].ToString() == "0")
                {
                    //INGRESA EL CONSULTORIO
                    Guid estAtenc = cargarEstadoAtencion(consulta.Rows[0].ItemArray[6].ToString());
                    idConsultaLaboral = ingresarConsultaLaboral(tipoExamen.Rows[0].ItemArray[0].ToString(), 0);
                    List<string> addConsultaLaboral = SQLConnector.generarListaParaProcedure("@fechaHora", "@lugarAtencion", "@idEstadoAtencion", "@motivo");
                    String idConsultorioLaboral = SQLConnector.executeProcedureWithReturnValue("sp_ConsultorioLaboral_Insert", addConsultaLaboral, fecha, lugarAtenc, estAtenc, null);
                    List<string> updateConsultaLaboral = SQLConnector.generarListaParaProcedure("@id", "@idConsultorioLaboral");
                    SQLConnector.executeProcedure("sp_ConsultaLaboral_UpdateIdConsultorio", updateConsultaLaboral,new Guid(idConsultaLaboral), new Guid(idConsultorioLaboral));

                }
                else if ((especialidad.Rows[0].ItemArray[0].ToString() == "1"))
                {
                    //INGRESA EL EXAMEN YA SEA PARA CREARLO O PARA MODIFICARLO
                    idConsultaLaboral = ingresarConsultaLaboral(tipoExamen.Rows[0].ItemArray[0].ToString(), 1);
                    Guid idExamenLaboral = new Guid(SQLConnector.executeProcedureWithReturnValue("dbo.sp_ExamenLaboral_Insert", null, null));
                    List<string> updateConsultaLaboral = SQLConnector.generarListaParaProcedure("@id", "@idExamen");
                    SQLConnector.executeProcedure("sp_ConsultaLaboral_UpdateIdExamen", updateConsultaLaboral,
                        new Guid(idConsultaLaboral), idExamenLaboral);

                    if (especialidad.Rows[0].ItemArray[1].ToString() == "REINGRESO LABORAL")
                    {
                        //Guid estAtenc = new Guid("A4F29D18-56CC-4FA6-A271-349C27E7C636"); //CITADO //cargarEstadoAtencion(consulta.Rows[0].ItemArray[6].ToString());
                        //List<string> addConsultaLaboral = SQLConnector.generarListaParaProcedure("@fechaHora", "@lugarAtencion", "@idEstadoAtencion", "@motivo");
                        //String idConsultorioLaboral = SQLConnector.executeProcedureWithReturnValue("sp_ConsultorioLaboral_Insert", addConsultaLaboral, fecha, lugarAtenc, estAtenc, null);
                        //List<string> updateConsultaLaboral1 = SQLConnector.generarListaParaProcedure("@id", "@idConsultorioLaboral");
                        //SQLConnector.executeProcedure("sp_ConsultaLaboral_UpdateIdConsultorio", updateConsultaLaboral1, new Guid(idConsultaLaboral), new Guid(idConsultorioLaboral));
                    }

                }
                //actualizarEmpresaExamen(consulta.Rows[0].ItemArray[0].ToString(), tipoExamen.Rows[0].ItemArray[0].ToString());
            }

        }

        private Guid cargarEstadoAtencion(string idPaciente)
        {
            DataTable condicionLaboral = SQLConnector.obtenerTablaSegunConsultaString(@"select  top(1) consL.idCondicionLaboral
            from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta
            inner join dbo.ConsultaLaboral cl on cl.idTipoExamen = tep.id
            inner join dbo.ConsultorioLaboral consL on cl.idConsultorioLaboral = consL.id
            where c.pacienteID = '" + idPaciente + @"' and c.fecha < '" + DateTime.Today.ToShortDateString() + @"'
            order by c.fecha desc");
            DataTable estadoAtencion = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.EstadoAtencion");
            int codigo1;
            if (condicionLaboral.Rows.Count > 0 && condicionLaboral.Rows[0].ItemArray[0].ToString() != string.Empty)
            {
                DataRow[] rows = SQLConnector.obtenerTablaSegunConsultaString("select * from condicionLaboral").Select("id = '" + condicionLaboral.Rows[0].ItemArray[0].ToString() + "'");
                if (rows[0][5].ToString() == "SI" && rows[0][6].ToString() == "SI" && rows[0][7].ToString() == "NO")
                {
                    codigo1 = 1;                 
                }
                else if (rows[0][5].ToString() == "SI" && rows[0][6].ToString() == "SI" && rows[0][7].ToString() == "SI")
                {
                    codigo1 = 3;
                }
                else if (rows[0][5].ToString() == "NO" && rows[0][6].ToString() == "NO" && rows[0][7].ToString() == "SI")
                {
                    codigo1 = 2;
                }
                else if (rows[0][5].ToString() == "SI" && rows[0][6].ToString() == "NO" && rows[0][7].ToString() == "NO")
                {
                    codigo1 = 1;
                }
                else if (rows[0][5].ToString() == "NO" && rows[0][6].ToString() == "NO" && rows[0][7].ToString() == "NO")
                {
                    MessageBox.Show("La consulta anterior del paciente tiene como condicion laboral: A DESIGNAR. Por favor verifique");
                    codigo1 = 1;
                }
                else
                {
                    codigo1 = 1;
                }
            }
            else
            {
                MessageBox.Show("La consulta anterior del paciente tiene como condicion laboral: A DESIGNAR. Por favor verifique");
                codigo1 = 1;             
            }

            DataRow[] dr = estadoAtencion.Select("codigo = " + codigo1.ToString());
            return new Guid(dr[0][0].ToString());

        }

        private void actualizarEmpresaExamen(string idConsulta, string idTe)
        {
            List<string> list = SQLConnector.generarListaParaProcedure("@idTipoExamen",
                      "@idEmpresa", "@tarea");
            DataTable empPorTe = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.empresaPorTipoDeExamen
                        where idTipoExamen = '" + idTe + "'");
            string procedure = "";
            if (empPorTe.Rows.Count > 0)
            {
                procedure = "sp_empresaPorTipoDeExamen_Update";
            }
            else
            {
                procedure = "sp_empresaPorTipoDeExamen_Add";
            }

            DataTable pacEmpYTar = SQLConnector.obtenerTablaSegunConsultaString(@"select p.empresaID, p.empresaTarea
            from dbo.PacienteLaboral p inner join dbo.Consulta c on c.pacienteID = p.id
            where c.id = '" + idConsulta + "'");
            if (pacEmpYTar.Rows[0].ItemArray[0].ToString() != Guid.Empty.ToString() &&
                pacEmpYTar.Rows[0].ItemArray[0].ToString() != string.Empty)
            {
                SQLConnector.executeProcedure(procedure, list,
                      new Guid(idConsulta), new Guid(pacEmpYTar.Rows[0].ItemArray[0].ToString()),
                      pacEmpYTar.Rows[0].ItemArray[1].ToString());
            }
        }

        private string ingresarConsultaLaboral(string idTe, int tipo)
        {
            List<string> addConsultaLaboral = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@tipo");
            return SQLConnector.executeProcedureWithReturnValue("sp_ConsultaLaboral_Insert", addConsultaLaboral, new Guid(idTe), tipo);
        }

        private bool tieneCitacion(string idConsulta)
        {
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Consulta where id = '" + idConsulta + "'");
            string idPaciente = consulta.Rows[0].ItemArray[6].ToString();
            DataTable condicionLaboral = SQLConnector.obtenerTablaSegunConsultaString(@"select top (1) consL.idCondicionLaboral
            from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta
            inner join dbo.ConsultaLaboral cl on cl.idTipoExamen = tep.id
            inner join dbo.ConsultorioLaboral consL on cl.idConsultorioLaboral = consL.id
            where c.pacienteID = '" + idPaciente + @"'
            order by c.fecha desc");
            if (condicionLaboral.Rows.Count > 0 && condicionLaboral.Rows[0].ItemArray[0].ToString() != string.Empty)
            {
                DataRow[] rows = SQLConnector.obtenerTablaSegunConsultaString("select * from condicionLaboral").Select("id = '" + condicionLaboral.Rows[0].ItemArray[0].ToString() + "'");
                if (rows[0][7].ToString() == "SI")
                {
                    return true;
                }
            }
            return false;
        }

        private void dgvTurno_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //CargarDatosGenerarConsultorio();
            ingresarPaciente();
        }

        private void abrirVentanaPacientePreventivaAsignacion()
        {
            frmPaciente fPaciente = new frmPaciente(new Configuracion(), true);
            fPaciente.objDelegateDevolverID = new frmPaciente.DelegateDevolverID(asignarPacientePreventiva);
            fPaciente.ShowDialog();
        }

        private void abrirVentanaPacienteLaboralAsignacion()
        {
            frmPacienteLaboral fPaciente = new frmPacienteLaboral();
            fPaciente.objDelegateDevolverID = new frmPacienteLaboral.DelegateDevolverID(asignarPacienteLaboral);
            fPaciente.ShowDialog();
        }

        private void abrirVentanaPacientePreventivaEdicion()
        {
            frmPaciente fPaciente = new frmPaciente(new Configuracion(), true);
            fPaciente.mostarDatosDni(tbDni.Text);
            fPaciente.objDelegateDevolverID = new frmPaciente.DelegateDevolverID(recargarPacientePreventiva);
            fPaciente.ShowDialog();
        }

        private void abrirVentanaPacienteLaboralEdicion()
        {
            frmPacienteLaboral fPaciente = new frmPacienteLaboral();
            fPaciente.cargarPacienteEspecifico(dgvInformacionPaciente.Rows[0].Cells[2].Value.ToString(),
                dgvGrilla.Rows[dgvGrilla.SelectedCells[0].RowIndex].Cells[1].Value.ToString());
            fPaciente.objDelegateDevolverID = new frmPacienteLaboral.DelegateDevolverID(recargarPacienteLaboral);
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
                abrirVentanaPacienteLaboralAsignacion();
            }
            else
            {
                abrirVentanaPacientePreventivaAsignacion();
            }
        }

        private string cargarMotivoSeleccionado()
        {
            if (botonPreventiva.Checked) { return "PREVENTIVA"; }
            else if (botonLaboral.Checked) { return "LABORAL"; }
            else if (botonClinica.Checked) { return "ESTUDIOS COMPLEMENTARIOS"; }
            else if (botonConsultorio.Checked) { return "CONSULTAS"; }
            else { return "REPETICIONES"; }
        }

        private void asignarPacientePreventiva(string idPaciente)
        {
            if (verificaPacienteIngresado(idPaciente))
            {
                MessageBox.Show("el paciente ya ha sido ingresado en mesa de entrada", "Mesa de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbTipoDeExamen.Text == "INFANTIL INICIAL")
                blnInfantilInicial = true;
            else
                blnInfantilInicial = false;

            CapaNegocioMepryl.PacientePreventiva PacientePre = new PacientePreventiva();
            
            if (estaHabilitado(idPaciente))
            {
                string motivo = cargarMotivoSeleccionado();
                string idConsulta = "";
                if (motivo == "PREVENTIVA")
                    idConsulta = insertarEnBaseDeDatosPreventiva("P", 1, idPaciente);
                if (motivo == "CONSULTAS")
                    idConsulta = insertarEnBaseDeDatosOtros("CO", 1, idPaciente);
                if (motivo == "REPETICIONES")
                    idConsulta = insertarEnBaseDeDatosOtros("R", 1, idPaciente);
                if (motivo == "ESTUDIOS COMPLEMENTARIOS")
                    idConsulta = insertarEnBaseDeDatosOtros("EC", 1, idPaciente);
                                
                if (string.IsNullOrEmpty(idConsulta))
                    return;

                // GRV - Modificado
                //CapaNegocioMepryl.TipoExamen tipoExamen2 = new TipoExamen();
                CapaNegocioMepryl.TipoExamen tipoExamen = new TipoExamen();
                if (blnInfantilInicial == false)
                    tipoExamen.blnTieneRX(PacientePre.DebeRealizarExamenRX(mesaEntrada.ObtenerDNI(idPaciente)));

                DataTable infoTipoExamen = SQLConnector.obtenerTablaSegunConsultaString("select id, precioBase from dbo.Especialidad where id = '"
                    + cbTipoDeExamen.SelectedValue.ToString() + "'");

                // GRV - Modificado
                //Entidades.TipoExamen entidad = tipoExamen.cargarEstudiosPorTipoExamen(infoTipoExamen.Rows[0][0].ToString());

                List<string> listAddTipoExamen = SQLConnector.generarListaParaProcedure("@idConsulta", "@idTurno", "@modificado",
                "@idEspecialidad", "@importe", "@factClub");
                string idTipoExamen = SQLConnector.executeProcedureWithReturnValue("sp_TipoExamenDePaciente_Add", listAddTipoExamen, new Guid(idConsulta), Guid.Empty,
                null, new Guid(infoTipoExamen.Rows[0][0].ToString()), Convert.ToDecimal(infoTipoExamen.Rows[0][1].ToString()),
                null);
            
                List<string> listAddClubPorTipoExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idClub");

                DataTable clubesPorPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select club from dbo.clubesPorPaciente
                where paciente = '" + idPaciente + "'");
                foreach (DataRow r in clubesPorPaciente.Rows)
                {
                    SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add", listAddClubPorTipoExamen,
                        new Guid(idTipoExamen), new Guid(r.ItemArray[0].ToString()));
                }
                // GRV - Modificado - Modificar tipo de examen
                //CapaNegocioMepryl.TipoExamen tipoExamen = new TipoExamen();                
                                
                Entidades.TipoExamen entidad = tipoExamen.cargarEstudiosPorTipoExamen(infoTipoExamen.Rows[0][0].ToString());                
                entidad.IdTipoExamenPaciente = new Guid(idTipoExamen);
                //tipoExamen.VerificaExamenPreventiva(PacientePre.DebeRealizarExamenRX(mesaEntrada.ObtenerDNI(idPaciente)), entidad.IdTipoExamenPaciente.ToString()); // Actualiza estado modificado
                if (blnInfantilInicial == false)
                    if (!PacientePre.DebeRealizarExamenRX(mesaEntrada.ObtenerDNI(idPaciente)))
                        entidad.Modificado = true;
                tipoExamen.crearEstudiosPorExamen(entidad);

                if (motivo == "PREVENTIVA")
                {
                    exPreventiva.crearExamen(idTipoExamen);
                }
                              
                cargarGrilla();

                if (dgvGrilla.Rows.Count > 0)
                {
                    dgvGrilla.CurrentCell = dgvGrilla.Rows[dgvGrilla.Rows.Count - 1].Cells[4];
                    puntero = dgvGrilla.CurrentCell.RowIndex;
                }
            }
            else
            {
                MessageBox.Show("No se puede ingresar paciente ya que se encontró como inhabilitado. Por favor verifique en exámenes para volverlo a"
                    + " habilitar e ingresarlo nuevamente", "Jugador inhabilitado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString(@"select dni from dbo.Paciente
                    where id = '" + dgvTurno.SelectedRows[0].Cells[9].Value.ToString() + "'");
                frmBusquedaExamen busq = new frmBusquedaExamen(this, 1);
                Utilidades.abrirFormulario(this.MdiParent, busq, new Configuracion());
                busq.gbRango.Enabled = true;
                busq.gbFecha.Enabled = false;
                busq.tbBusqueda.Text = paciente.Rows[0].ItemArray[0].ToString();
                busq.botonBuscar.PerformClick();
            }

        }

        private void recargarPacientePreventiva(string idPaciente)
        {
            mesaEntrada.actualizarClubPorTipoExamen(dgvGrilla.Rows[dgvGrilla.SelectedCells[0].RowIndex].Cells[0].Value.ToString(),
                idPaciente);
            cargarGrilla();
            mostrarDatos();
        }

        private void recargarPacienteLaboral(string idPaciente, string idEmpresa)
        {
            mesaEntrada.actualizarEmpresaPorTipoExamen(dgvGrilla.Rows[dgvGrilla.SelectedCells[0].RowIndex].Cells[0].Value.ToString(),
                idPaciente, idEmpresa);
            cargarGrilla();
            mostrarDatos();
        }


        private void asignarPacienteLaboral(string idPaciente, string idEmpresa)
        {
            if (verificaPacienteIngresado(idPaciente))
            {
                MessageBox.Show("el paciente ya ha sido ingresado en mesa de entrada","Mesa de entrada",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string motivo = cargarMotivoSeleccionado();

            //dgvGrilla.Rows[dgvGrilla.SelectedCells[0].RowIndex].Cells[10].Value.ToString();

            //if ((strTipoConsulta == "REINGRESO LABORAL ") || (strTipoConsulta == "REINGRESO LABORAL"))
            //    motivo = "CONSULTAS";
            
            string idConsulta = "";
            if (motivo == "LABORAL")
                idConsulta = insertarEnBaseDeDatosOtros("L", 1, idPaciente);
            if (motivo == "CONSULTAS")
                idConsulta = insertarEnBaseDeDatosOtros("CO", 1, idPaciente);
            if (motivo == "REPETICIONES")
                idConsulta = insertarEnBaseDeDatosOtros("R", 1, idPaciente);
            if (motivo == "ESTUDIOS COMPLEMENTARIOS")
                idConsulta = insertarEnBaseDeDatosOtros("EC", 1, idPaciente);

            //DataTable infoTipoExamen = null;

            //if ((strTipoConsulta == "REINGRESO LABORAL ") || (strTipoConsulta == "REINGRESO LABORAL"))
            //{
            //    infoTipoExamen = SQLConnector.obtenerTablaSegunConsultaString("select id, precioBase from dbo.Especialidad where id = '4eb46c5e-703b-49fd-acfb-dddf0a925c49'");
            //}
            //else
            //{
            //    infoTipoExamen = SQLConnector.obtenerTablaSegunConsultaString("select id, precioBase from dbo.Especialidad where id = '"
            //        + cbTipoDeExamen.SelectedValue.ToString() + "'");
            //}

            DataTable infoTipoExamen = SQLConnector.obtenerTablaSegunConsultaString("select id, precioBase from dbo.Especialidad where id = '"
                    + cbTipoDeExamen.SelectedValue.ToString() + "'");

            List<string> listAddTipoExamen = SQLConnector.generarListaParaProcedure("@idConsulta", "@idTurno", "@modificado",
            "@idEspecialidad", "@importe", "@factClub");
            string idTipoExamen = SQLConnector.executeProcedureWithReturnValue("sp_TipoExamenDePaciente_Add", listAddTipoExamen, new Guid(idConsulta), Guid.Empty,
            null, new Guid(infoTipoExamen.Rows[0][0].ToString()), Convert.ToDecimal(infoTipoExamen.Rows[0][1].ToString()),
            null);

     
            DataTable empresaYTarea = SQLConnector.obtenerTablaSegunConsultaString(@"select e.id, e.razonSocial, epp.tarea from dbo.EmpresasPorPaciente
                    epp inner join dbo.Empresa e on epp.idEmpresa = e.id where epp.idEmpresa = '" + idEmpresa + @"' 
                    and epp.idPaciente = '" + idPaciente + "'");

            List<string> listAddEmpresaPorTipoExamen = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idEmpresa", "@tarea");
            SQLConnector.executeProcedure("sp_empresaPorTipoDeExamen_Add", listAddEmpresaPorTipoExamen, new Guid(idTipoExamen),
            new Guid(empresaYTarea.Rows[0][0].ToString()), empresaYTarea.Rows[0][2].ToString());

            CapaNegocioMepryl.TipoExamen tipoExamen = new TipoExamen();


            Entidades.TipoExamen entidad = tipoExamen.cargarEstudiosPorTipoExamen(infoTipoExamen.Rows[0][0].ToString());
            entidad.IdTipoExamenPaciente = new Guid(idTipoExamen);
            tipoExamen.crearEstudiosPorExamen(entidad);

            if (motivo == "LABORAL" || motivo == "CONSULTAS")
            {
                generarLaboral(idConsulta);
            }

            cargarGrilla();

            if (dgvGrilla.Rows.Count > 0)
            {
                dgvGrilla.CurrentCell = dgvGrilla.Rows[dgvGrilla.Rows.Count - 1].Cells[4];
                puntero = dgvGrilla.CurrentCell.RowIndex;
            }
        }



        private void dgvGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            imprimirComprobante();
        }

        private void botEditarExamenLaboral_Click(object sender, EventArgs e)
        {
            frmTipoExamen fTipoExamen = new frmTipoExamen();
            fTipoExamen.cargarSegunIdConsulta(new Guid(dgvGrilla.Rows[dgvGrilla.CurrentCell.RowIndex].Cells[0].Value.ToString()));
            fTipoExamen.objDelegateModificado = new frmTipoExamen.DelegateModificado(mostrarDatos);
            fTipoExamen.ShowDialog();
            // GRV - Modificado actualiza grilla
            //botonActualiz_Click_1(sender, e); // GRV
            cargarGrilla();
        }

        private void botonEditarPaciente_Click(object sender, EventArgs e)
        {
            editarPaciente();
        }

        private void editarPaciente()
        {
        
            if (mesaEntrada.verificarTipoPaciente(new Guid(dgvGrilla.Rows[dgvGrilla.SelectedCells[0].RowIndex].Cells[1].Value.ToString())) == 'P')
            {
                abrirVentanaPacientePreventivaEdicion();
            }
            else
            {
                abrirVentanaPacienteLaboralEdicion();
            }
        }

        private void botonActualiz_Click_1(object sender, EventArgs e)
        {
            updateObservacionPaciente();
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.Rows.Count > 0)
            {
                invalidarConsulta();
            }
            else
            {
                MessageBox.Show("¡No existe paciente para ser eliminado!", "Eliminar Consulta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvGrilla_Sorted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvR in dgvGrilla.Rows)
            {
                colorearFila(dgvR);
            }
        }

        private void botCambiarTipoExamen_Click(object sender, EventArgs e)
        {
            string strMotivoConsulta;
            string strIdTurno;
            string strIdConsulta;
            string strIdTipoExamen;
            string strTipoConsulta;

            strIdPaciente = dgvGrilla.Rows[dgvGrilla.SelectedCells[0].RowIndex].Cells[1].Value.ToString();            
            strIdTurno = dgvGrilla.Rows[dgvGrilla.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
            strIdTipoExamen = dgvGrilla.Rows[dgvGrilla.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            strIdConsulta = dgvGrilla.Rows[dgvGrilla.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            strMotivoConsulta = mesaEntrada.verificarTipoPaciente(ConvierteStringGuid(strIdPaciente)).ToString();
            strTipoConsulta = dgvGrilla.Rows[dgvGrilla.SelectedCells[0].RowIndex].Cells[7].Value.ToString();
                        
            frmMesaSelecTipoExamen frmTipoExamen = new frmMesaSelecTipoExamen(strMotivoConsulta, strIdPaciente, strIdEmpresa, strIdTurno, strIdTipoExamen, strIdConsulta, strTipoConsulta);                                 
            frmTipoExamen.ShowDialog();
            //CambiarTipoExamenInvalidarConsulta();
            inicializar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // GRV - Ramírez - cambiar tipo de examen
        public void CambiarTipoExamen(string NombreTipoExamen, string MotivoConsulta, string IdPaciente, string IdEmpresa, string IdTurno, string IdConsulta, string IdTipoExamen)
        {            
            char cTipoTurno;
            strIdPaciente = IdPaciente;
            strIdEmpresa = IdEmpresa;

            switch (MotivoConsulta)
            {
                case "P":                    
                    botonPreventiva.Checked = true;
                    cbTipoDeExamen.Text = NombreTipoExamen;

                    mesaEntrada.ActualizaTipoExamenIDConsulta(IdConsulta, IdTipoExamen);
                    CambiarTipoPacienteIdentificador("P", IdPaciente, IdConsulta);
                    //asignarPacientePreventiva(IdPaciente);
                    break;
                case "L":                    
                    botonLaboral.Checked = true;
                    cbTipoDeExamen.Text = NombreTipoExamen;

                    mesaEntrada.ActualizaTipoExamenIDConsulta(IdConsulta, IdTipoExamen);
                    CambiarTipoPacienteIdentificador("L", IdPaciente, IdConsulta);
                    //asignarPacienteLaboral(IdPaciente, IdEmpresa);
                    break;
                case "EC":
                    botonClinica.Checked = true;
                    cbTipoDeExamen.Text = NombreTipoExamen;
                    cTipoTurno = mesaEntrada.verificarTipoPaciente(ConvierteStringGuid(strIdPaciente));

                    mesaEntrada.ActualizaTipoExamenIDConsulta(IdConsulta, IdTipoExamen);
                    CambiarTipoPacienteIdentificador("EC", IdPaciente, IdConsulta);

                    //if (cTipoTurno == 'P')
                    //    //asignarPacientePreventiva(IdPaciente);
                    //    CambiarTipoPacienteIdentificador("EC", IdPaciente, IdConsulta);
                    //else
                    //    //asignarPacienteLaboral(IdPaciente, IdEmpresa);                    
                    break;
                case "CO":
                    botonConsultorio.Checked = true;
                    cbTipoDeExamen.Text = NombreTipoExamen;
                    cTipoTurno = mesaEntrada.verificarTipoPaciente(ConvierteStringGuid(strIdPaciente));

                    mesaEntrada.ActualizaTipoExamenIDConsulta(IdConsulta, IdTipoExamen);
                    CambiarTipoPacienteIdentificador("CO", IdPaciente, IdConsulta);
                    //if (cTipoTurno == 'P')
                    //    asignarPacientePreventiva(IdPaciente);
                    //else 
                    //    asignarPacienteLaboral(IdPaciente, IdEmpresa);                    
                    break;
                case "R":
                    botonRepeticion.Checked = true;
                    cbTipoDeExamen.Text = NombreTipoExamen;
                    cTipoTurno = mesaEntrada.verificarTipoPaciente(ConvierteStringGuid(strIdPaciente));

                    mesaEntrada.ActualizaTipoExamenIDConsulta(IdConsulta, IdTipoExamen);
                    CambiarTipoPacienteIdentificador("R", IdPaciente, IdConsulta);
                    //if (cTipoTurno == 'P')
                    //    asignarPacientePreventiva(IdPaciente);
                    //else 
                    //    asignarPacienteLaboral(IdPaciente, IdEmpresa);                    
                    break;
            }
        }

        private Guid ConvierteStringGuid(string Valor)
        {
            Guid gidIdTurno;

            try { gidIdTurno = new Guid(Valor); }
            catch { gidIdTurno = Guid.Empty; }

            return gidIdTurno;
        }

        private void CambiarTipoExamenTipoPaciente()
        {
            frmTipoPaciente fTipoPaciente = new frmTipoPaciente();
            fTipoPaciente.objDelegateDevolverID = new frmTipoPaciente.DelegateDevolverID(CambiarTipoExamenAsignarPacienteSeleccionado);
            fTipoPaciente.ShowDialog();
        }

        private void CambiarTipoExamenAsignarPacienteSeleccionado(char tipo)
        {
            if (tipo == 'L')
            {
                asignarPacienteLaboral(strIdPaciente, strIdEmpresa);
            }
            else
            {
                asignarPacientePreventiva(strIdPaciente);
            }
        }
        private void CambiarTipoPacienteIdentificador(string tipo, string idPaciente, string idConsulta)
        {
            //List<object> retorno = obtenerNroOrden(idPaciente);
            //string nroIdentificador = obtenerNroIdentificador(tipo, idPaciente, true).ToString();
            //string nroIdentificador = obtenerNroIdentificador(tipo, idPaciente, (bool)retorno[1]).ToString();
            

            if (tipo == "P")
            {
                string nroIdentificador = obtenerNroIdentificador(tipo, idPaciente, true).ToString();
                mesaEntrada.ActualizaIdentificadorConsulta(idConsulta, tipo, nroIdentificador);
                //
                ModificaTipoExamenPaciente(idConsulta);
            }
            else
            {
                string nroIdentificador = generaNroIdentificador(tipo, idPaciente).ToString();
                mesaEntrada.ActualizaIdentificadorConsulta(idConsulta, tipo, tipo + nroIdentificador);

                if (tipo == "L" || tipo == "CO")
                {
                    generarLaboral(idConsulta);
                    ModificaTipoExamenPaciente(idConsulta);
                }
                else
                {
                    mesaEntrada.EliminaIdentificadorConsulta(idConsulta);
                    ModificaTipoExamenPaciente(idConsulta);
                }
            }
        }

        private int generaNroIdentificador(string tipo, string idPaciente)
        {
            int intValor1 = 0;
            int intValor2 = 0;
            
            //DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString("select identificador from Consulta c where convert(Date,c.fecha) = '" + DateTime.Today.ToShortDateString() + "' and c.tipo = '" + tipo + "' order by convert(int,c.nroOrden) asc");
            DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString("select identificador from Consulta c where convert(Date,c.fecha) = '" + DateTime.Today.ToShortDateString() + "' and c.tipo = '" + tipo + "' order by convert(int,dbo.RemoveChars(c.identificador)) asc");
            if (tipo == "P")
                tabla = SQLConnector.obtenerTablaSegunConsultaString("select identificador from Consulta c where convert(Date,c.fecha) = '" + DateTime.Today.ToShortDateString() + "' and c.tipo = '" + tipo + "' order by convert(int,c.identificador) asc");
            DataView view = new DataView(tabla);            

               //tabla.DefaultView.Sort = "identificador ASC";
            //view.Sort = "identificador ASC";
            //tabla = view.ToTable();

            if (tabla.Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < tabla.Rows.Count; i++)
                    {
                        if ((i + 1) < tabla.Rows.Count)
                        {
                            intValor1 = quitarLetras(tabla.Rows[i + 1][0].ToString());
                            intValor2 = quitarLetras(tabla.Rows[i][0].ToString()) + 1;

                            if (1 < (quitarLetras(tabla.Rows[0][0].ToString())))
                            {
                                return 1;
                            }

                            if (intValor1 != intValor2)
                            {
                                return intValor2;
                            }                            
                        }
                        else
                        {
                            if (1 < (quitarLetras(tabla.Rows[0][0].ToString())))
                            {
                                return 1;
                            }
                            else
                            {

                                return quitarLetras(tabla.Rows[i][0].ToString()) + 1;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    
                }
            }

            return 1;
        }

        private int generaNroIdentificadorPre(string tipo, string idPaciente)
        {
            int intValor1 = 0;
            int intValor2 = 0;
                        
            DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString("select identificador from Consulta c where convert(Date,c.fecha) = '" + DateTime.Today.ToShortDateString() + "' and c.tipo = '" + tipo + "' order by convert(int,c.identificador) asc");
            DataView view = new DataView(tabla);

            //tabla.DefaultView.Sort = "identificador ASC";
            //view.Sort = "identificador ASC";
            //tabla = view.ToTable();

            if (tabla.Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < tabla.Rows.Count; i++)
                    {
                        if ((i + 1) < tabla.Rows.Count)
                        {
                            intValor1 = quitarLetras(tabla.Rows[i + 1][0].ToString());
                            intValor2 = quitarLetras(tabla.Rows[i][0].ToString()) + 1;

                            //if (201 < (quitarLetras(tabla.Rows[0][0].ToString())))
                            if ((intContPre + 1) < (quitarLetras(tabla.Rows[0][0].ToString())))
                            {
                                return (intContPre + 1);//201;
                            }

                            if (intValor1 != intValor2)
                            {
                                return intValor2;
                            }
                        }
                        else
                        {
                            //if (201 < (quitarLetras(tabla.Rows[0][0].ToString())))
                            if ((intContPre + 1) < (quitarLetras(tabla.Rows[0][0].ToString())))
                            {
                                return (intContPre + 1);//201;
                            }
                            else
                            {

                                return quitarLetras(tabla.Rows[i][0].ToString()) + 1;
                            }
                        }
                    }
                }
                catch (IndexOutOfRangeException ex)
                {

                }
            }

            return (intContPre + 1);//201;
        }

        private bool PacienteRepetido(string IdPaciente)
        {
            bool blnVerifica = false;

            DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString("select pacienteID from Consulta c where convert(Date,c.fecha) = '" + DateTime.Today.ToShortDateString() + "' and pacienteID = '" + IdPaciente + "'");
            DataView view = new DataView(tabla);

            if (tabla.Rows.Count > 0)
            {
                blnVerifica = true;
            }

            //for (int i = 0; i < tabla.Rows.Count; i++)
            //{
            //    if (tabla.Rows.Count > 0)
            //    {
            //        if (tabla.Rows[i][0].ToString() == IdPaciente)
            //            blnVerifica = true;
            //    }
            //}

            return blnVerifica;
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

        private void ModificaTipoExamenPaciente(string idConsulta) 
        {
            DataTable infoTipoExamen = SQLConnector.obtenerTablaSegunConsultaString("select id, precioBase from dbo.Especialidad where id = '"
                + cbTipoDeExamen.SelectedValue.ToString() + "'");

            DataTable TipoExamen = SQLConnector.obtenerTablaSegunConsultaString("SELECT id from dbo.TipoExamenDePaciente WHERE idConsulta = '"
                + idConsulta + "'");

            CapaNegocioMepryl.TipoExamen tipoExamen = new TipoExamen();

            Entidades.TipoExamen entidad = tipoExamen.cargarEstudiosPorTipoExamen(infoTipoExamen.Rows[0][0].ToString());
            entidad.IdTipoExamenPaciente = new Guid(TipoExamen.Rows[0][0].ToString());
            tipoExamen.actualizarEstudiosPorExamen(entidad);
        }

        //private void CargarDatosGenerarConsultorio()
        //{
        //    // Si es "REINGRESO LABORAL"
        //    CapaNegocioMepryl.PacienteLaboral PacienteLaboral = new CapaNegocioMepryl.PacienteLaboral();
        //    strTipoConsulta = dgvTurno.SelectedRows[0].Cells[3].Value.ToString();
        //    strIdEmpresaNuevoConsultorio = PacienteLaboral.obtenerIdEmpresaPaciente(dgvTurno.SelectedRows[0].Cells[9].Value.ToString());            
        //}

        //private void LimpiaDatosGenerarConsultorio()
        //{
        //    // Si es "REINGRESO LABORAL"            
        //    strTipoConsulta = "";
        //    strIdEmpresaNuevoConsultorio = "";
        //}

        private bool verificaPacienteIngresado(string idPaciente) 
        {
            bool blnEstado = false;
            CapaNegocioMepryl.PacienteLaboral pLaboral = new CapaNegocioMepryl.PacienteLaboral();
            CapaNegocioMepryl.PacientePreventiva pPreventiva = new CapaNegocioMepryl.PacientePreventiva();
            string strDNIPre = "";
            string strDNILab = "";
            
            strDNIPre = pPreventiva.ObtenerDNIpaciente(idPaciente);
            strDNILab = pLaboral.obtenerDNIPaciente(idPaciente).ToString();

            if (!string.IsNullOrEmpty(strDNIPre))
            {
                blnEstado = BuscarPaciente(strDNIPre, "10", dgvGrilla);
            }
            if (!string.IsNullOrEmpty(strDNILab))
            {
                blnEstado = BuscarPaciente(strDNILab, "10", dgvGrilla);
            }            

            return blnEstado;
        }

        private bool BuscarPaciente(string TextoABuscar, string Columna, DataGridView grid)
        {
            bool encontrado = false;
            if (TextoABuscar == string.Empty) return false;
            if (grid.RowCount == 0) return false;
            grid.ClearSelection();
            if (Columna == string.Empty)
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                        if (cell.Value == TextoABuscar)
                        {
                            row.Selected = true;
                            return true;
                        }
                }
            }
            else
            {
                foreach (DataGridViewRow row in grid.Rows)
                {

                    if (row.Cells[10].Value.ToString() == TextoABuscar)
                    {
                        row.Selected = true;
                        return true;
                    }
                }
            }
            return encontrado;
        }
    }
}
