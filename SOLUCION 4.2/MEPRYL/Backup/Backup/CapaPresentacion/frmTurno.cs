using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocio;
using UserControls;

namespace CapaPresentacion
{
    public partial class frmTurno : CapaPresentacionBase.frmBaseGrillaABM
    {
        public Turno rglEntidad;

        private string estadoLibreID = Utilidades.ID_VACIO;
        private string estadoAsignadoID = Utilidades.ID_VACIO;
        private DateTime fechaSeleccionada = DateTime.Now;

        public frmTurno(Configuracion config, ModoApertura modo)
            : base(config, modo)
        {
            //InitializeComponent();
            EntidadNombre = "Turno";
            this.habilitarBotonAgregar = false;
            this.habilitarBotonEliminar = false;
        }

        //Implementacion
        protected override void inicializarEntidad()
        {
            rglEntidad = new Turno();
        }

        //Carga el Navegador de Formularios
        protected override void cargarNavegadorFormulario()
        {
            try
            {
                //InitializeComponent();
                base.cargarNavegadorFormulario();
                //Carga las teclas rapidas primero
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butLiberarTurno, (char)Keys.F3));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butModificarObservaciones, (char)Keys.F4));

                //Carga los controles
                navegador.agregarControl(new CapsulaControl((Control)cbEspecialidadB));
                navegador.agregarControl(new CapsulaControl((Control)cbProfesionalB));
                navegador.agregarControl(new CapsulaControl((Control)cbEstadoB));
                /*navegador.agregarControl(new CapsulaControl((Control)chDomingoB));
                navegador.agregarControl(new CapsulaControl((Control)chLunesB));
                navegador.agregarControl(new CapsulaControl((Control)chMartesB));
                navegador.agregarControl(new CapsulaControl((Control)chMiercolesB));
                navegador.agregarControl(new CapsulaControl((Control)chJuevesB));
                navegador.agregarControl(new CapsulaControl((Control)chViernesB));
                navegador.agregarControl(new CapsulaControl((Control)chSabadoB));*/

                navegador.agregarControl(new CapsulaControl((Control)tbObservaciones));
                navegador.agregarControl(new CapsulaControl((Control)butLiberarTurno));

                //Agrega los handlers para todos los controles del control contenedor
                navegador.agregarHandlersContenedor(this);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        protected override void modoEstatico(bool hayObjetoActivo)
        {
            base.modoEstatico(hayObjetoActivo);


            habilitarControles(ref gbPaciente, ref dgItems, false);
            gbPaciente.Enabled = false;
            butLiberarTurno.Enabled = gbPaciente.Visible;
            butModificarObservaciones.Enabled = gbPaciente.Visible;
        }
        protected override void modoEditable()
        {            
            base.modoEditable();
            habilitarControles(ref gbPaciente, ref dgItems, true);
            gbPaciente.Enabled = true;
            this.Focus();
            if (this.edicion == ModoEdicion.AGREGANDO)
            {
                //cboaNroCuenta.inicializar(this.configuracion, "ChequeCuenta");
                //cboaNroCuenta.cboCombo.Text = "";
            }
            //cboaNroCuenta.Focus();
        }

        
        protected override void inicializarComponentes()
        {
            InitializeComponent();
            base.inicializarComponentes();

            Utilidades.llenarCombo(ref cbEspecialidadB, this.configuracion.getConectionString(), "sp_Especialidad_SelectAll", "Todas", 0);
            Utilidades.llenarCombo(ref cbProfesionalB, this.configuracion.getConectionString(), "sp_Profesional_SelectAll", "Todos", 0);
            Utilidades.llenarCombo(ref cbEstadoB, this.configuracion.getConectionString(), "sp_TurnoEstado_SelectAll", "Todos", 0);

            //Obtiene los IDs de los estados
            Utilidades.comboSeleccionarItemByIdentificador("2", ref cbEstadoB);
            this.estadoAsignadoID = Utilidades.comboObtenerID(ref cbEstadoB);

            Utilidades.comboSeleccionarItemByIdentificador("1", ref cbEstadoB);
            this.estadoLibreID = Utilidades.comboObtenerID(ref cbEstadoB);
            //Fin

            this.busquedaInstantanea = false;
            inicializarEntidad();

            lsbHoraDesde.SelectedIndex = 0;

            cbEspecialidadB.Focus();

            //Veifica permisos
            if (this.configuracion.usuario.contienePerfil("Administrador"))
                butBorrarTurnos.Visible = true;

        }


        protected new void inicializarGrilla(CapaNegocioBase.EntidadFactoryBase ef, string filtro)
        {
            inicializarGrilla(ef, filtro, 0);
        }

        protected new void inicializarGrilla(CapaNegocioBase.EntidadFactoryBase ef, string filtro, int top)
        {
            try
            {
                base.inicializarGrilla(ef, filtro, top);

                //Arregla la grilla
                dgItems.Columns["registroBLOB"].Visible = false;
                dgItems.Columns["id"].Visible = false;
                dgItems.Columns["estadoID"].Visible = false;
                dgItems.Columns["pacienteID"].Visible = false;
                dgItems.Columns["horarioID"].Visible = false;
                dgItems.Columns["estadoCodigo"].Visible = false;
                dgItems.Columns["hora"].Visible = false;
                /*dgItems.Columns["domingo"].Visible = false;
                dgItems.Columns["lunes"].Visible = false;
                dgItems.Columns["martes"].Visible = false;
                dgItems.Columns["miercoles"].Visible = false;
                dgItems.Columns["jueves"].Visible = false;
                dgItems.Columns["viernes"].Visible = false;
                dgItems.Columns["sabado"].Visible = false;*/
                dgItems.Columns["especialidadID"].Visible = false;
                dgItems.Columns["profesionalID"].Visible = false;
                dgItems.Columns["bloqueado"].Visible = false;
                dgItems.Columns["usuarioID"].Visible = false;
                dgItems.Columns["pacienteCelular"].Visible = false;
                dgItems.Columns["habilitado"].Visible = false;

                
                //Asigna los nombres de la base de datos
                dgItems.Columns["especialidadTexto"].HeaderText = "Epecialidad";
                dgItems.Columns["profesionalTexto"].HeaderText = "Profesional";
                dgItems.Columns["fecha"].HeaderText = "Fecha"; 
                dgItems.Columns["horaReferencia"].HeaderText = "Hora";
                dgItems.Columns["nroOrden"].HeaderText = "Nro.";
                dgItems.Columns["pacienteTexto"].HeaderText = "Paciente";
                dgItems.Columns["pacienteTelefonos"].HeaderText = "Teléfono";
                dgItems.Columns["pacienteDni"].HeaderText = "DNI";
                dgItems.Columns["estadoTexto"].HeaderText = "Estado";
                dgItems.Columns["codigo"].HeaderText = "Código";
                dgItems.Columns["observaciones"].HeaderText = "Observaciones";
                dgItems.Columns["usuarioTexto"].HeaderText = "Usuario";


                dgItems.Columns["fecha"].DefaultCellStyle.Format = "d";

                if (dgItems.Rows.Count == 0)
                {
                    gbPaciente.Visible = false;
                    butLiberarTurno.Visible = false;
                    butModificarObservaciones.Enabled = gbPaciente.Visible;
                }

                colorearRenglones();
                
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override string validarDatosIngresados()
        {
            return "";
        }

        protected override void cargarObjetoReglas()
        {
            try
            {
                if (rglEntidad==null) //Solo para el caso de los turnos que no se modifican todos los campos.
                    inicializarEntidad();
                //Cargar los datos de los controles de edicion.
                rglEntidad.id = new Guid(tbId.Text);
                rglEntidad.codigo = tbCodigo.Text;
                rglEntidad.pacienteID = new Guid(tbPacienteID.Text);
                if (tbPacienteID.Text == Utilidades.ID_VACIO)
                    rglEntidad.estadoID = new Guid(this.estadoLibreID);
                else
                    rglEntidad.estadoID = new Guid(this.estadoAsignadoID);

                rglEntidad.pacienteTexto = lbPacienteTexto.Text;
                rglEntidad.pacienteDni = lbPacienteDni.Text;
                rglEntidad.pacienteTelefonos = lbPacienteTelefonos.Text;

                rglEntidad.observaciones = tbObservaciones.Text;
                rglEntidad.usuarioID = new Guid(this.configuracion.usuario.id);
                rglEntidad.usuarioTexto = this.configuracion.usuario.apellido + ", " + this.configuracion.usuario.nombre;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override string validarNegocio()
        {
            TurnoFactory negEntidadFac = (TurnoFactory)crearNegEntidadFac();
            string resultado = negEntidadFac.validar(rglEntidad, edicion);
            negEntidadFac = null;

            return resultado;
        }

        public override CapaNegocioBase.EntidadFactoryBase crearNegEntidadFac()
        {
            return new TurnoFactory(this.configuracion, this.EntidadNombre);
        }

        public override Resultado alta()
        {
            Resultado resultado = new Resultado();

            try
            {
                TurnoFactory negEntidadFac = (TurnoFactory)crearNegEntidadFac();
                resultado = negEntidadFac.alta(rglEntidad);
                negEntidadFac = null;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }

       
        public override Resultado modificar()
        {
            Resultado resultado = new Resultado();
            try
            {
                TurnoFactory negEntidadFac = (TurnoFactory)crearNegEntidadFac();
                resultado = negEntidadFac.modificar(rglEntidad);
                negEntidadFac = null;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }

        public override string borrar(string id)
        {
            string resultado = "";

            try
            {
                TurnoFactory negTurnoFac = new TurnoFactory(this.configuracion, this.EntidadNombre);
                resultado = negTurnoFac.borrar(id);

                negTurnoFac = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

        protected override void inicializarTabla()
        {
            base.inicializarTabla();

            inicializarGrilla(new TurnoFactory(this.configuracion, this.EntidadNombre), "1=2");
        }


        protected override void buscarPalabrasClave()
        {
            if (chCombinarBusqueda.Checked)
                buscar(0);
            else
                buscar(1);
        }

        //Realiza la busqueda de las palabras clave de la caja de texto, combinado con los campos filtro
        protected void buscar(int formaBusqueda)
        {
            buscar(formaBusqueda, 0);
        }
        protected void buscar(int formaBusqueda, int localizarFecha)
        {
            try
            {
                if (this.EntidadNombre != "Grilla")
                {
                    this.Cursor = Cursors.WaitCursor;
                    base.buscandoPalabrasClave = true;
                    string like = "bloqueado=0";  //No muestra los registros bloqueados.
                    this.fechaSeleccionada = mcFecha.SelectionStart;


                    Dictionary<string, string> diasSemana = new Dictionary<string, string>();
                    diasSemana["Sunday"] = "Domingo";
                    diasSemana["Monday"] = "Lunes";
                    diasSemana["Tuesday"] = "Martes";
                    diasSemana["Wednesday"] = "Miércoles";
                    diasSemana["Thursday"] = "Jueves";
                    diasSemana["Friday"] = "Viernes";
                    diasSemana["Saturday"] = "Sábado";
                    string textoFiltro = "";
                    string separador = "";

                    if (formaBusqueda == 2 || formaBusqueda == 0)
                    {
                        if (localizarFecha == 0)
                        {
                            like += " AND fecha>= " + Utilidades.fechaCanonicaSQL(mcFecha.SelectionStart, "00:00:00");
                            like += " AND fecha<= " + Utilidades.fechaCanonicaSQL(mcFecha.SelectionStart, "23:59:59");
                        }
                        if (localizarFecha == 1)
                        {
                            like += " AND fecha>= " + Utilidades.fechaCanonicaSQL(mcFecha.SelectionStart.AddDays(1), "00:00:00");
                        }
                        if (localizarFecha == -1)
                        {
                            like += " AND fecha<= " + Utilidades.fechaCanonicaSQL(mcFecha.SelectionStart.AddDays(-1), "23:59:59");
                        }
                        textoFiltro += diasSemana[mcFecha.SelectionStart.DayOfWeek.ToString()] + " " +
                                    mcFecha.SelectionStart.Day + "/" + mcFecha.SelectionStart.Month + " ";
                        separador = " | ";

                        if (lsbHoraDesde.SelectedIndex > -1)
                        {
                            like += " AND horaReferencia>='" + lsbHoraDesde.Text + "'";

                            textoFiltro += separador + lsbHoraDesde.Text + "hs";
                            separador = " | ";
                        }
                        if (cbEspecialidadB.SelectedIndex > 0)
                        {
                            like += " AND especialidadID='" + cbEspecialidadB.SelectedValue.ToString() + "'";
                            textoFiltro += separador + cbEspecialidadB.Text;
                            separador = " | ";
                        }
                        if (cbProfesionalB.SelectedIndex > 0)
                        {
                            like += " AND profesionalID='" + cbProfesionalB.SelectedValue.ToString() + "'";
                            textoFiltro += separador + cbProfesionalB.Text;
                            separador = " | ";
                        }
                        if (cbEstadoB.SelectedIndex > 0)
                        {
                            like += " AND estadoID='" + cbEstadoB.SelectedValue.ToString() + "'";
                            textoFiltro += separador + cbEstadoB.Text + "s";
                            separador = " | ";
                        }
                        if (!chDomingoB.Checked)
                            like += " AND domingo=0";
                        if (!chLunesB.Checked)
                            like += " AND lunes=0";
                        if (!chMartesB.Checked)
                            like += " AND martes=0";
                        if (!chMiercolesB.Checked)
                            like += " AND miercoles=0";
                        if (!chJuevesB.Checked)
                            like += " AND jueves=0";
                        if (!chViernesB.Checked)
                            like += " AND viernes=0";
                        if (!chSabadoB.Checked)
                            like += " AND sabado=0";
                    }

                    if (formaBusqueda == 1 || formaBusqueda == 0)
                    {
                        if (tbBusqueda.Text.Trim() != "")
                        {
                            string[] palabras = tbBusqueda.Text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                            foreach (string palabra in palabras)
                            {
                                like += " AND registroBLOB LIKE '%" + palabra + "%' ";
                            }
                            textoFiltro += separador + " Palabras: \"" + tbBusqueda.Text + "\"";
                            separador = " | ";
                        }
                    }

                    lbFiltro.Text = textoFiltro;
                   

                    inicializarGrilla(new TurnoFactory(this.configuracion, this.EntidadNombre), like, localizarFecha);
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            finally
            {
                base.buscandoPalabrasClave = false;
            }
        }


        //Edita los datos de un registro de la grilla
        protected override void editarRegistro()
        {
            editarRegistro(true);    
        }

        protected void editarRegistro(bool abrirVentana)
        {
            try
            {
                int i = dgItems.CurrentCell.RowIndex;
                if (i >= 0)
                {
                    if (dgItems.Rows[i].Cells["habilitado"].Value.ToString() == "1")
                    {
                        if (((DateTime)dgItems.Rows[i].Cells["Fecha"].Value).Date >= DateTime.Now.Date)
                        {
                            tbCodigo.Text = dgItems.Rows[i].Cells["codigo"].Value.ToString();
                            recuperarObjetoPorCodigo(tbCodigo.Text);

                            //Primero verifica si el registro no está bloqueado o asignado
                            TurnoFactory negEntidadFac = (TurnoFactory)crearNegEntidadFac();

                            if (negEntidadFac.consultarBloqueo(rglEntidad.id, abrirVentana))
                            {
                                MessageBox.Show("Este turno ahora ya está asignado o bloqueado por otro operador.\r\nPor favor refresque los resultados o libere el turno antes de volver a asignarlo.", "Registro Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                //Bloquea el registro
                                negEntidadFac.cambiarBloqueo(rglEntidad.id, true);

                                //Presiona el boton Modificar
                                base.modificarClick();

                                //Abre la ventana para asignar paciente.
                                if (abrirVentana)
                                {
                                    gbPaciente.Visible = true;
                                    tbObservaciones.Focus();
                                    abrirVentanaPaciente();
                                }

                                //Desbloquea el registro
                                negEntidadFac.cambiarBloqueo(rglEntidad.id, false);

                                //Colorea el registro
                                colorearRenglon(i);
                            }
                            negEntidadFac = null;
                        }
                        else
                            MessageBox.Show("No se pueden modificar los turnos de fechas anteriores al día de hoy.", "Fecha pasada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        MessageBox.Show("Este turno está deshabilitado por feriado o ausencia del profesional.", "Turno deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        protected override void recuperarObjetoPorCodigo()
        {
            base.recuperandoObjeto = true;
            if (dgItems.CurrentCell != null)
                base.recuperarObjetoPorCodigo(dgItems["codigo", dgItems.CurrentCell.RowIndex].Value.ToString());
            base.recuperandoObjeto = false;
        }

        //Actualiza el registro de la grilla
        protected override void actualizarRegistro()
        {
            recuperarObjetoPorCodigo(tbCodigo.Text); //Aquí tiene que venir el objeto actualizado desde la base de datos, con los campos[] completados.
            //CapaNegocioBase.EntidadBase entidad = (CapaNegocioBase.EntidadBase)rglEntidad;
            base.actualizarRegistro(ref dgItems);
        }

        protected override void mostrarDatosObjeto()
        {
            base.mostrarDatosObjeto();
            try
            {
                rglEntidad = (Turno)base.rglEntidad;
                /*lbEspecialidadTexto.Text = rglEntidad.especialidadTexto;
                lbProfesionalTexto.Text = rglEntidad.profesionalTexto;
                lbFecha.Text = rglEntidad.fecha.ToString("dd/MM/yyyy");
                lbHora.Text = rglEntidad.horaReferencia;
                lbTurno.Text = rglEntidad.nroOrden.ToString();*/
                tbObservaciones.Text = rglEntidad.observaciones;

                //Datos del paciente
                if (rglEntidad.pacienteID.ToString() == Utilidades.ID_VACIO)
                    gbPaciente.Visible = false;
                else
                    gbPaciente.Visible = true;
                butLiberarTurno.Visible = gbPaciente.Visible;
                butModificarObservaciones.Visible = gbPaciente.Visible;
                tbPacienteID.Text = rglEntidad.pacienteID.ToString();
                lbPacienteTexto.Text = rglEntidad.pacienteTexto;
                lbPacienteDni.Text = rglEntidad.pacienteDni;
                lbPacienteTelefonos.Text = rglEntidad.pacienteTelefonos;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        protected override void limpiarFormulario()
        {
            /*cboaNroCuenta.cboCombo.SelectedIndex = -1;
            cboaCliente.cboCombo.SelectedIndex = -1;
            cboaBanco.cboCombo.SelectedIndex = -1;
            cboaNroSucursal.cboCombo.SelectedIndex = -1;
            cboaNroSucursal.cboCombo.Text = "";
            tbNroCheque.Text = "";
            tbImporte.Text = "$ 0,00";
            cboaFirmante.cboCombo.SelectedIndex = -1;
            dtpVencimiento.Value = DateTime.Now;
            //Datos de la baja
            chDarDeBaja.Checked = false;
            cboaProveedor.cboCombo.SelectedIndex = -1;
            dtpFechaBaja.Value = DateTime.Now;
            //Datos del rechazo
            chChequeRechazado.Checked = false;
            dtpFechaRechazo.Value = DateTime.Now;
            tbComentariosRechazo.Text = "";*/
        }
        protected override void imprimirListado()
        {/*
            try
            {
                rptListadoCheques doc = new rptListadoCheques();

                doc.SetDataSource(((DataTable)dgItems.DataSource));

                /*doc.DataDefinition.FormulaFields["txtTituloF"].Text = "\"" + dgItems.CaptionText + "\"";

                string cadenaFiltro = ""; //obtenerCadenaFiltro();
                string cadenaOrden = ""; //obtenerCadenaOrden();
                if (cadenaFiltro!="")
                    doc.DataDefinition.FormulaFields["txtFiltroF"].Text = "\"" + cadenaFiltro + "\"";
                else
                    doc.Section1.ReportObjects["txtFiltroTitulo"].ObjectFormat.EnableSuppress = true;

                if (cadenaOrden!="")
                    doc.DataDefinition.FormulaFields["txtOrdenF"].Text = "\"" + cadenaOrden + "\"";
                else
                    doc.Section7.ReportObjects["txtOrdenTitulo"].ObjectFormat.EnableSuppress = true;
                * /

                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                printDialog1.Document = pd;

                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    int desde = 0, hasta = 0;
                    if (printDialog1.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.AllPages)
                    {
                        desde = 1;
                        hasta = 10000;
                    }
                    else
                    {
                        desde = printDialog1.PrinterSettings.FromPage;
                        hasta = printDialog1.PrinterSettings.ToPage;
                    }
                    int copias = printDialog1.PrinterSettings.Copies;
                    doc.PrintToPrinter(copias, printDialog1.PrinterSettings.Collate, desde, hasta);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }*/
        }


        public override void abrirComoConsulta()
        {
            cbEspecialidadB.Focus();
        }




        private void butBuscarPorCampos_Click(object sender, EventArgs e)
        {
            buscarCombinado(2);
        }

        private void buscarCombinado(int origen)
        {
            buscarCombinado(origen, 0);
        }

        private void buscarCombinado(int origen, int localizarFecha)
        {
            if (chCombinarBusqueda.Checked)
                buscar(0, localizarFecha);
            else
                buscar(origen, localizarFecha);
        }

        private void abrirVentanaPaciente()
        {

            if (rglEntidad != null)
            {
                if (rglEntidad.id.ToString() != Utilidades.ID_VACIO)
                {
                    frmPaciente fPaciente = new frmPaciente(this.configuracion, true);
                    fPaciente.mostrarBotonOk = true;
                    fPaciente.objDelegateDevolverID = new frmPaciente.DelegateDevolverID(asignarPaciente);
                    fPaciente.ShowDialog(this);
                    fPaciente = null;
                }
            }
        }

        private void asignarPaciente(string pacienteID)
        {
            try 
            {

                PacienteFactory pacienteFactory = new PacienteFactory(this.configuracion, "Paciente");

                Paciente paciente = (Paciente)pacienteFactory.getById(pacienteID);

                if (paciente != null)
                {
                    //Verifica si el paciente tiene turnos reservados
                    //Crea el TurnoFactory 
                    TurnoFactory turnoFac = new TurnoFactory(this.configuracion, "Turno");

                    //Verifica que no tenga turnos para esa fecha
                    DataTable dt = turnoFac.getAllInDataTable("pacienteID='" + pacienteID + "' AND fecha>=" + Utilidades.fechaCanonicaSQL(DateTime.Now.Date, "00:00:00"));
                    string turnoYaReservado = "";
                    if (dt.Rows.Count > 0) //Si tiene un turno ya reservado, lo devuelve.
                    {
                        //Mostrar los datos del turno y preguntar al operador si desea cotinuar asignando..
                        turnoYaReservado = "Código: " + dt.Rows[0]["codigo"].ToString() + "\r\n";
                        DateTime fecha = DateTime.Parse(dt.Rows[0]["fecha"].ToString());
                        turnoYaReservado += "Fecha: " + Utilidades.diaSemana(fecha.DayOfWeek) + " ";
                        turnoYaReservado += fecha.Day.ToString() + "/" + fecha.Month.ToString() + "\r\n";
                        turnoYaReservado += "Hora: " + dt.Rows[0]["horaReferencia"].ToString() + "\r\n";
                        turnoYaReservado += "DNI: " + dt.Rows[0]["pacienteDni"].ToString() + "\r\n";
                        turnoYaReservado += "Paciente: " + dt.Rows[0]["pacienteTexto"].ToString() + "\r\n";
                        turnoYaReservado += "Usuario asignación: " + dt.Rows[0]["usuarioTexto"].ToString();

                        turnoYaReservado = "Ya existe un turno para este Paciente: \r\n\r\n" + 
                                            turnoYaReservado + "\r\n\r\n" +
                                            "¿Desea asignar un nuevo turno de todas formas?";
                    }

                    bool asignar = true;
                    if (turnoYaReservado != "")
                        if (DialogResult.No == MessageBox.Show(turnoYaReservado, "Turno pendiente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                            asignar = false;

                    if (asignar)
                    {
                        tbPacienteID.Text = pacienteID;
                        lbPacienteDni.Text = paciente.dni;
                        lbPacienteTelefonos.Text = paciente.telefonos;
                        lbPacienteTexto.Text = paciente.apellido + ", " + paciente.nombres;
                    }
                }

                paciente = null;

                pacienteFactory = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butLiberarTurno_Click(object sender, EventArgs e)
        {
            liberarTurno();
        }

        private void liberarTurno()
        {
            try
            {
                if (MessageBox.Show("¿Desea liberar este Turno?", "Liberar Turno",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    editarRegistro(false);
                    tbPacienteID.Text = Utilidades.ID_VACIO;
                    lbPacienteTexto.Text = "";
                    lbPacienteDni.Text = "";
                    lbPacienteTelefonos.Text = "";
                    tbObservaciones.Text = "";
                    aceptar();
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void cbEspecialidadB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEspecialidadB.SelectedIndex == 0)
                Utilidades.llenarCombo(ref cbProfesionalB, this.configuracion.getConectionString(), "sp_Profesional_SelectAll", "Todos", 0);
            else
            {
                Utilidades.llenarCombo(ref cbProfesionalB, this.configuracion.getConectionString(), "sp_Profesional_SelectFiltro", "Todos", 0,
                                        "especialidadID='" + Utilidades.comboObtenerID(ref cbEspecialidadB) + "'");
            }
            buscarCombinado(2);
        }


        private void cbProfesionalB_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscarCombinado(2);
        }

        private void cbEstadoB_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscarCombinado(2);
        }



        private void lsbHoraDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscarCombinado(2);
        }

        private void mcFecha_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (this.fechaSeleccionada!=e.Start)
                buscarCombinado(2);
        }

        private void frmTurno_Load(object sender, EventArgs e)
        {
            base.frmBaseGrillaABM_Load(sender, e);


            buscarCombinado(2);
        }

        protected override void pintarRenglon(DataGridViewCellFormattingEventArgs e)
        {
            base.pintarRenglon(e);

          
            /*if (dgItems.Columns[e.ColumnIndex].HeaderText == "Paciente")
            {
                if (e.Value.ToString()!="")
                    dgItems.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LavenderBlush;
                else
                    dgItems.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }*/
        }


        private void colorearRenglones()
        {
            for (int i = 0; i < dgItems.Rows.Count; i++)
            {
                colorearRenglon(i);
                //Application.DoEvents();
            }
        }

        private void colorearRenglon(int i)
        {
            //DataGridViewRow row = dgItems.Rows[i];
            if (dgItems.Rows[i].Cells["habilitado"].Value.ToString() == "1") //Habilitado
            {
                if (dgItems.Rows[i].Cells["pacienteTexto"].Value.ToString() != "")
                    dgItems.Rows[i].DefaultCellStyle.BackColor = Color.LavenderBlush;
                else
                    dgItems.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
            else //Regitro deshabilitado
            {
                dgItems.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                dgItems.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
            }
        }

        private void butFechaInicio_Click(object sender, EventArgs e)
        {
            mcFecha.SelectionStart = DateTime.Now;
            mcFecha.SelectionEnd = DateTime.Now;
        }

        private void butFechaSiguiente_Click(object sender, EventArgs e)
        {
            //mcFecha.SelectionStart = mcFecha.SelectionStart.AddDays(1);
            buscarCombinado(2, 1);
            
            if (dgItems.Rows.Count > 0)
                mcFecha.SelectionStart = (DateTime)dgItems["Fecha", 0].Value;
            
            mcFecha.SelectionEnd = mcFecha.SelectionStart;
        }

        private void butFechaAnterior_Click(object sender, EventArgs e)
        {
            //mcFecha.SelectionStart = mcFecha.SelectionStart.AddDays(-1);
            buscarCombinado(2, -1);

            if (dgItems.Rows.Count > 0)
                mcFecha.SelectionStart = (DateTime)dgItems["Fecha", 0].Value;

            mcFecha.SelectionEnd = mcFecha.SelectionStart;
        }

        private void chCombinarBusqueda_CheckedChanged(object sender, EventArgs e)
        {
            buscarPalabrasClave();
        }

        private void butModificarObservaciones_Click(object sender, EventArgs e)
        {
            base.modificarClick();
            tbObservaciones.Select();
        }

        private void butMarcarFeriado_Click(object sender, EventArgs e)
        {
            cambiarEstadoHabilitar(0);
        }

        private void cambiarEstadoHabilitar(int estado)
        {
            cambiarEstadoHabilitar(estado, false);
        }
        private void cambiarEstadoHabilitar(int estado, bool registrosSeleccionados)
        {
            try 
            {
                string texto = "Fecha: " + this.fechaSeleccionada.ToShortDateString() + "\r\n";
                if (!registrosSeleccionados)
                    texto += "Especialidad: " + cbEspecialidadB.Text + "\r\n" +
                             "Profesional: " + cbProfesionalB.Text;
                string pregunta = "", titulo = "";
                if (estado == 1) //Habilitar
                {
                    pregunta = "¿Desea volver a habilitar los Turnos seleccionados?\r\n\r\n";
                    titulo = "Habilitar/Quitar feriado";
                }
                else
                {
                    pregunta = "¿Desea Marcar como Feriado/Inhabilitar los Turnos seleccionados?\r\n\r\n";
                    titulo = "Inhabilitar/Marcar como Feriado";
                }
                if (MessageBox.Show(pregunta + texto, titulo,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    TurnoFactory negEntidadFac = (TurnoFactory)crearNegEntidadFac();
                    string like = "";
                    bool refrescar = false;
                    if (!registrosSeleccionados)
                    {
                        like = "fecha>= " + Utilidades.fechaCanonicaSQL(mcFecha.SelectionStart, "00:00:00");
                        like += " AND fecha<= " + Utilidades.fechaCanonicaSQL(mcFecha.SelectionStart, "23:59:59");
                        if (cbEspecialidadB.SelectedIndex > 0)
                        {
                            like += " AND especialidadID='" + cbEspecialidadB.SelectedValue.ToString() + "'";
                        }
                        if (cbProfesionalB.SelectedIndex > 0)
                        {
                            like += " AND profesionalID='" + cbProfesionalB.SelectedValue.ToString() + "'";
                        }
                    }
                    else //Si hay que deshabilitar registros seleccionados individualmente
                    {
                        string ids = ""; string coma = ""; int contador = 0;
                        foreach (DataGridViewRow row in this.dgItems.Rows) {
                            if (row.Selected) {
                                ids += coma + "'" + row.Cells["ID"].Value + "'";
                                coma = ",";
                                contador++;

                                if (contador == 10) //Envia de a 10 para no sobrepasar los 2080 caracteres en el parámetro varchar
                                {
                                    like = " turno.id IN (" + ids + ")";
                                    negEntidadFac.cambiarEstadoHabilitar(like, estado);
                                    ids = ""; coma = "";
                                    contador = 0;
                                    refrescar = true;
                                }
                            }
                        }
                        if (contador > 0) //Envia de a 10 para no sobrepasar los 2080 caracteres en el parámetro varchar
                        {
                            like = " turno.id IN (" + ids + ")";
                            negEntidadFac.cambiarEstadoHabilitar(like, estado);
                            ids = ""; coma = "";
                            contador = 0;
                            refrescar = true;
                        }
                        if (!refrescar)
                            MessageBox.Show("Debe seleccionar algún los registros haciendo Control+Click en el borde izquierdo de la grilla.", "Inhabilitar/Habilitar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                            
                    }

                    if (!registrosSeleccionados)
                    {
                        negEntidadFac.cambiarEstadoHabilitar(like, estado);
                        refrescar = true;
                    }

                    negEntidadFac = null;
                    if (refrescar){
                        butBuscarPorCampos_Click(butBuscarPorCampos, new EventArgs());
                    }
                }
                
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void butQuitarFeriado_Click(object sender, EventArgs e)
        {
            cambiarEstadoHabilitar(1);
        }

        private void butInhabilitar_Click(object sender, EventArgs e)
        {
            cambiarEstadoHabilitar(0, true);
        }

        private void butHabilitar_Click(object sender, EventArgs e)
        {
            cambiarEstadoHabilitar(1, true);
        }

        private void butBorrarTurnos_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.ParentForm, new frmBorrarTurnos(this.configuracion), this.configuracion);
        }


    }
}