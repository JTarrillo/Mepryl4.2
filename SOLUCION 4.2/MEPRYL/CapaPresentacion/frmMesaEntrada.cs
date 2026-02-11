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
using CapaNegocioBase;

namespace CapaPresentacion
{
    public partial class frmMesaEntrada : CapaPresentacionBase.frmBaseGrillaABM
    {
        public Consulta rglEntidad;
        private EntidadGeneralFactory vistaPacienteFac;
        private bool aceptandoCambios = false;
        private bool esMovil = false;
        private int inicioContadorP = 199;

        public frmMesaEntrada(Configuracion config, ModoApertura modo)
            : base(config, modo)
        {
            //InitializeComponent();
            //Aca iba lo que ahora está en inicializacionEspecifica();
        }

        //Implementacion
        protected override void inicializarEntidad()
        {
            rglEntidad = new Consulta();
            
        }

        protected override void inicializacionEspecifica()
        {
            //Si es móvil
            //this.esMovil = (bool)configuracion.obtenerParametro("ES_MOVIL");
            if (this.esMovil)
            {
                rbL.Visible = false;
                rbCL.Visible = false;
                rbR.Visible = false;
                rbCO.Visible = false;
                this.inicioContadorP = 0;
            }
            else
                this.inicioContadorP = 199;

            EntidadNombre = "Consulta";
            buscar();
        }

        //Carga el Navegador de Formularios
        protected override void cargarNavegadorFormulario()
        {
            try
            {
                //InitializeComponent();
                base.cargarNavegadorFormulario();
                //Carga las teclas rapidas primero
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butPaciente, (char)Keys.F1));

                //Carga los controles
                navegador.agregarControl(new CapsulaControl((Control)butPaciente));
                navegador.agregarControl(new CapsulaControl((Control)tbObservaciones));

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

            butImprimir.Visible = true;
            butImprimirComprobante.Visible = true;
            habilitarControles(ref gbControles, ref dgItems, false);
        }
        protected override void modoEditable()
        {
            base.modoEditable();
            habilitarControles(ref gbControles, ref dgItems, true);
            butImprimir.Visible = false;
            butImprimirComprobante.Visible = false;
            if (edicion == ModoEdicion.AGREGANDO)
                nuevoNroOrden(rbP, new EventArgs());
            this.Focus();
        }

        protected void habilitarControles(ref GroupBox contenedor, ref DataGridView dg, bool habilitar) { 
            base.habilitarControles(ref contenedor, ref dg, habilitar);

            //Habilita siempre la grilla
            dg.Enabled = true;
            int registros = dg.RowCount;
            if (registros > 0)
            {
                Object celda = dg[0, registros - 1];
            }
            //if (registros > 0 && dg.CurrentRow.Index != registros-1)
                //dg.CurrentCell = (DataGridViewCell)celda;
        }
        
        protected override void inicializarComponentes()
        {
            InitializeComponent();

            //Verifica los permisos
            /*Seguridad seguridad = new Seguridad(this.configuracion);
            this.permisoAlta = seguridad.verificarPermiso("Administracion.Horarios", "ALTA");
            this.permisoModificacion = seguridad.verificarPermiso("Administracion.Horarios", "MODIFICAR");
            this.permisoBaja = seguridad.verificarPermiso("Administracion.Horarios", "BORRAR");
            seguridad = null;*/


            base.inicializarComponentes();

            inicializarEntidad();
            vistaPacienteFac = new EntidadGeneralFactory(this.configuracion, "vPaciente");


        }

        protected new void inicializarGrilla(CapaNegocioBase.EntidadFactoryBase ef, string filtro)
        {
            try
            {
                base.inicializarGrilla(ef, filtro);

                //Arregla la grilla
                //dgItems.Columns["registroBLOB"].Visible = false;
                dgItems.Columns["id"].Visible = false;
                dgItems.Columns["codigo"].Visible = false;
                dgItems.Columns["pacienteID"].Visible = false;
                dgItems.Columns["tipo"].Visible = false;
                
                //dgItems.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgItems.Columns["importe"].DefaultCellStyle.Format = "c";

                //Asigna los nombres de la base de datos
                dgItems.Columns["fecha"].HeaderText = "Fecha";
                dgItems.Columns["nroOrden"].HeaderText = "Nº Ingreso";
                dgItems.Columns["identificador"].HeaderText = "Nº Orden";
                dgItems.Columns["Liga"].HeaderText = "Liga";
                dgItems.Columns["Club"].HeaderText = "Club";
                dgItems.Columns["Empresa"].HeaderText = "Empresa";
                dgItems.Columns["Apellido"].HeaderText = "Apellido";
                dgItems.Columns["Nombres"].HeaderText = "Nombres";
                dgItems.Columns["DNI"].HeaderText = "DNI";
                dgItems.Columns["Fec.Nac."].HeaderText = "Fec.Nac.";
                dgItems.Columns["observaciones"].HeaderText = "Observaciones";

                dgItems.Columns["fecha"].DefaultCellStyle.Format = "d";
                dgItems.Columns["Fec.Nac."].DefaultCellStyle.Format = "d";

                dgItems.AutoResizeColumns();
                dgItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override void abrirComoNuevo()
        {
            base.abrirComoNuevo();
            nuevoNroOrden((object)rbP, new EventArgs());
        }


        private void butAceptar1_Enter(object sender, EventArgs e)
        {
            butAceptar.Select();
        }

 
        public override string validarDatosIngresados()
        {
            string mensaje = "";
            if (tbPacienteID.Text == "" || tbPacienteID.Text == Utilidades.ID_VACIO)
                mensaje = "    - Debe seleccionar un Paciente o Cancelar.";
            return mensaje;
        }

        protected override void cargarObjetoReglas()
        {
            try
            {
                //MessageBox.Show(cboaNroSucursal.cboCombo.Text);
                inicializarEntidad();
                rglEntidad.id = new Guid(tbId.Text);
                rglEntidad.codigo = tbCodigo.Text;
                rglEntidad.fecha = dtpFecha.Value;
                rglEntidad.identificador = tbIdentificador.Text;
                rglEntidad.nroOrden = int.Parse(tbNroOrden.Text);
                rglEntidad.paciente = (Paciente)(new PacienteFactory(this.configuracion, "Paciente")).getById(tbPacienteID.Text);
                rglEntidad.observaciones = tbObservaciones.Text;

                if (rbCL.Checked)
                    rglEntidad.tipo = "CL";
                if (rbCO.Checked)
                    rglEntidad.tipo = "CO";
                if (rbL.Checked)
                    rglEntidad.tipo = "L";
                if (rbP.Checked)
                    rglEntidad.tipo = "P";
                if (rbR.Checked)
                    rglEntidad.tipo = "R";
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override string validarNegocio()
        {
            ConsultaFactory negEntidadFac = (ConsultaFactory)crearNegEntidadFac();
            string resultado = negEntidadFac.validar(rglEntidad, edicion);
            negEntidadFac = null;

            return resultado;
        }

        public override CapaNegocioBase.EntidadFactoryBase crearNegEntidadFac()
        {
            return new ConsultaFactory(this.configuracion, this.EntidadNombre);
        }

        public override Resultado alta()
        {
            Resultado resultado = new Resultado();

            try
            {
                ConsultaFactory negEntidadFac = (ConsultaFactory)crearNegEntidadFac();
                rglEntidad.fecha = DateTime.Now;

                //Verifica que no haya un registro para el mismo paciente la misma fecha
                string filtro = ("pacienteID='" + rglEntidad.paciente.id.ToString() + "' " +
                                " AND fecha>=" + Utilidades.fechaCanonicaSQL(rglEntidad.fecha, "00:00:00") +
                                " AND fecha<=" + Utilidades.fechaCanonicaSQL(rglEntidad.fecha, "23:59:59"));
                bool continuar = true;

                if (negEntidadFac.existeSimilar(filtro))
                {
                    if (MessageBox.Show("Ya existe un registro para el mismo paciente y la misma fecha.\r\n\r\n¿Desea agregarlo nuevamente?", "Registro duplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        continuar = true;
                    else
                        continuar = false;
                }

                if (continuar)
                {
                    resultado = negEntidadFac.alta(rglEntidad);
                    negEntidadFac = null;

                    //Aumenta los contadores
                    this.configuracion.guardarParametro("MESA_ENTRADA_" + rglEntidad.tipo, int.Parse(tbIdentificador.Text.Trim("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray())));
                    this.configuracion.guardarParametro("MESA_ENTRADA_ORDEN", int.Parse(tbNroOrden.Text));

                    //Imprime el comprobante
                    imprimirComprobante();
                }
                

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }

     
        //
        public override Resultado modificar()
        {
            Resultado resultado = new Resultado();
            try
            {
                ConsultaFactory negEntidadFac = (ConsultaFactory)crearNegEntidadFac();
                
                resultado = negEntidadFac.modificar(rglEntidad);
                negEntidadFac = null;

                //Modifica el Identificador
                int identificadorActual = (int)this.configuracion.obtenerParametro("MESA_ENTRADA_" + rglEntidad.tipo);
                int identificadorNuevo = int.Parse(tbIdentificador.Text.Trim("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()));

                if (identificadorNuevo>identificadorActual)
                    this.configuracion.guardarParametro("MESA_ENTRADA_" + rglEntidad.tipo, identificadorNuevo);
                    

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
                //***************
                //*Primero verifica si es el útimo registro para recuperar el número
                recuperarNroOrden();
                //**************** 

                ConsultaFactory negConsultaFac = new ConsultaFactory(this.configuracion, this.EntidadNombre);
                resultado = negConsultaFac.borrar(id);

                negConsultaFac = null;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

        private void recuperarNroOrden()
        {
            try
            {
                int nroOrden = (int)configuracion.obtenerParametro("MESA_ENTRADA_ORDEN");
                int idP = (int)configuracion.obtenerParametro("MESA_ENTRADA_P");
                int idL = (int)configuracion.obtenerParametro("MESA_ENTRADA_L");
                int idR = (int)configuracion.obtenerParametro("MESA_ENTRADA_R");
                int idCL = (int)configuracion.obtenerParametro("MESA_ENTRADA_CL");
                int idCO = (int)configuracion.obtenerParametro("MESA_ENTRADA_CO");

                if (rglEntidad.nroOrden==nroOrden)
                {
                    if (rglEntidad.tipo.Trim() == "P")
                        configuracion.guardarParametro("MESA_ENTRADA_P", idP - 1);
                    if (rglEntidad.tipo.Trim() == "L")
                        configuracion.guardarParametro("MESA_ENTRADA_L", idL - 1);
                    if (rglEntidad.tipo.Trim() == "R")
                        configuracion.guardarParametro("MESA_ENTRADA_R", idR - 1);
                    if (rglEntidad.tipo.Trim() == "CL")
                        configuracion.guardarParametro("MESA_ENTRADA_CL", idCL - 1);
                    if (rglEntidad.tipo.Trim() == "CO")
                        configuracion.guardarParametro("MESA_ENTRADA_CO", idCO - 1);

                    configuracion.guardarParametro("MESA_ENTRADA_ORDEN", nroOrden - 1);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        protected override void inicializarTabla()
        {
            base.inicializarTabla();

            inicializarGrilla(new ConsultaFactory(this.configuracion, this.EntidadNombre), "1=2");
        }


        //Agrega un registro en la grilla
        public override void agregarRegistroGrilla(ref Resultado resultado)
        {
            try
            {
                if (dgItems.DataSource == null)
                    inicializarTabla();

                Consulta consulta = (Consulta)resultado.objeto;

                //Toma los datos en memoria
                
                DataTable tabla = (DataTable)dgItems.DataSource;
                DataRow row = tabla.NewRow();
                row["id"] = consulta.id;
                row["codigo"] = consulta.codigo; // tbCodigo.Text.Trim() == "" ? 0 : int.Parse(tbCodigo.Text);
                
                tabla.Rows.InsertAt(row, tabla.Rows.Count);
                tabla.AcceptChanges();

                int renglon = dgItems.RowCount-1;
                if (renglon < 0)
                    renglon = 0;

                dgItems.CurrentCell = dgItems[0, renglon];

                dgItems.Rows[renglon].Cells["codigo"].Value = consulta.codigo;
                dgItems.Rows[renglon].Cells["fecha"].Value = dtpFecha.Value;
                dgItems.Rows[renglon].Cells["identificador"].Value = tbIdentificador.Text;
                dgItems.Rows[renglon].Cells["nroOrden"].Value = int.Parse("0" + tbNroOrden.Text);
                dgItems.Rows[renglon].Cells["observaciones"].Value = tbObservaciones.Text;
                dgItems.Rows[renglon].Cells["pacienteID"].Value = tbPacienteID.Text;
                dgItems.Rows[renglon].Cells["Liga"].Value = lbLiga.Text;
                dgItems.Rows[renglon].Cells["Club"].Value = lbClub.Text;
                dgItems.Rows[renglon].Cells["Empresa"].Value = lbEmpresa.Text;
                dgItems.Rows[renglon].Cells["Apellido"].Value = lbApellido.Text;
                dgItems.Rows[renglon].Cells["Nombres"].Value = lbNombres.Text;
                dgItems.Rows[renglon].Cells["DNI"].Value = lbDNI.Text;
                dgItems.Rows[renglon].Cells["Fec.Nac."].Value = DateTime.Parse(lbFechaNacimiento.Text);
                dgItems.Rows[renglon].Cells["observaciones"].Value = tbObservaciones.Text;

                string tipo = obtenerTipoConsulta();

                dgItems.Rows[renglon].Cells["tipo"].Value = tipo;

                recuperarObjetoPorCodigo();

                row = null;
                tabla = null;
                consulta = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
        }

        protected override void aceptar()
        {
            this.aceptandoCambios = true;
            base.aceptar();
            this.aceptandoCambios = false;
            
            //Abre un nuevo ingreso
            butAgregar_Click(butAgregar, new EventArgs());
        }

        protected override void cancelar()
        {
            base.cancelar();
            
            
        }

        private string obtenerTipoConsulta()
        {
            string tipo = "";
            if (rbCL.Checked)
                tipo = "CL";
            if (rbCO.Checked)
                tipo = "CO";
            if (rbL.Checked)
                tipo = "L";
            if (rbP.Checked)
                tipo = "P";
            if (rbR.Checked)
                tipo = "R";

            return tipo;
        }

        //Elimina un registro de la grilla
        protected override void eliminarRegistroGrilla()
        {
            try
            {
                if (dgItems.CurrentCell != null)
                {
                    dgItems.Rows.RemoveAt(dgItems.CurrentCell.RowIndex);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        //Realiza la busqueda de las palabras clave de la caja de texto
        protected override void buscarPalabrasClave()
        {
            try
            {
                base.buscandoPalabrasClave = true;
                string like = "1=1";

                /*if (chDeBaja.Checked)
                    like += " AND baja=0 ";
                if (chRechazados.Checked)
                    like += " AND rechazado=0 ";
                */
                if (tbBusqueda.Text.Trim() != "")
                {
                    string[] palabras = tbBusqueda.Text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    foreach (string palabra in palabras)
                    {
                        like += " AND registroBLOB LIKE '%" + palabra + "%' ";
                    }
                }
                inicializarGrilla(new ConsultaFactory(this.configuracion, this.EntidadNombre), like);

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
            try
            {
                int i = dgItems.CurrentCell.RowIndex;
                if (i >= 0)
                {
                    tabPrincipal.SelectedIndex = 1;
                    tbCodigo.Text = dgItems.Rows[i].Cells["codigo"].Value.ToString();
                    recuperarObjetoPorCodigo(tbCodigo.Text);



                    //Presiona el boton Modificar
                    base.modificarClick();
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
            recuperarObjetoPorCodigo(tbCodigo.Text);
            //CapaNegocioBase.EntidadBase entidad = (CapaNegocioBase.EntidadBase)rglEntidad;
            base.actualizarRegistro(ref dgItems);
        }

        protected override void mostrarDatosObjeto()
        {
            base.mostrarDatosObjeto();
            try
            {
                rglEntidad = (Consulta)base.rglEntidad;

                if (rglEntidad.tipo.Trim() == "P")
                    rbP.Checked = true;
                if (rglEntidad.tipo.Trim() == "L")
                    rbL.Checked = true; 
                if (rglEntidad.tipo == "CL")
                    rbCL.Checked = true;
                if (rglEntidad.tipo.Trim() == "R")
                    rbR.Checked = true;
                if (rglEntidad.tipo == "CO")
                    rbCO.Checked = true;

                dtpFecha.Value = rglEntidad.fecha;
                tbNroOrden.Text = rglEntidad.nroOrden.ToString();
                tbIdentificador.Text = rglEntidad.identificador;

                tbPacienteID.Text = rglEntidad.paciente.id.ToString();

                EntidadBase vPaciente = vistaPacienteFac.getById(rglEntidad.paciente.id.ToString());
                lbLiga.Text = vPaciente.campos["Liga"].ToString();
                lbClub.Text = vPaciente.campos["Club"].ToString();
                lbEmpresa.Text = vPaciente.campos["Empresa"].ToString();
                vPaciente = null;

                lbTarea.Text = rglEntidad.paciente.empresaTarea;
                lbApellido.Text = rglEntidad.paciente.apellido;
                lbNombres.Text = rglEntidad.paciente.nombres;
                lbDNI.Text = rglEntidad.paciente.dni;
                lbFechaNacimiento.Text = rglEntidad.paciente.fechaNacimiento.ToString("dd/MM/yyyy");
                tbObservaciones.Text = rglEntidad.observaciones;
                
                
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        protected override void limpiarFormulario()
        {
            rbCL.Checked = false;
            rbCO.Checked = false;
            rbL.Checked = false;
            rbP.Checked = false;
            rbR.Checked = false;

            tbIdentificador.Text = "";
            tbNroOrden.Text = "";
            lbLiga.Text = "";
            lbClub.Text = "";
            lbEmpresa.Text = "";
            lbTarea.Text = "";
            tbPacienteID.Text = Utilidades.ID_VACIO;
            lbApellido.Text = "";
            lbNombres.Text = "";
            lbDNI.Text = "";
            lbFechaNacimiento.Text = "";
            tbObservaciones.Text = "";
        }

     
        protected override void imprimirListado()
        {
           
 
  
        }


        private void butPaciente_Click(object sender, EventArgs e)
        {
            tbObservaciones.Focus();
            if (!rbP.Checked && !rbL.Checked && !rbCL.Checked && !rbR.Checked && !rbCO.Checked)
                MessageBox.Show("Primero debe seleccionar el tipo de consulta (P, L, CL, R, CO).", "No se puede seleccionar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                abrirVentanaPaciente(obtenerTipoConsulta());
        }



        private void abrirVentanaPaciente(string tipoConsulta)
        {

            //if (rglEntidad != null)
            //{
                //if (rglEntidad.id.ToString() != Utilidades.ID_VACIO)
                //{
                    frmPaciente fPaciente = new frmPaciente(this.configuracion, true);
                    fPaciente.mostrarBotonOk = true;
                    fPaciente.objDelegateDevolverID = new frmPaciente.DelegateDevolverID(asignarPaciente);
                    fPaciente.tipoConsulta = tipoConsulta;
                    fPaciente.ShowDialog(this);
                    fPaciente = null;
                //}
            //}
        }

        private void asignarPaciente(string pacienteID)
        {
            try
            {

                PacienteFactory pacienteFactory = new PacienteFactory(this.configuracion, "Paciente");

                Paciente paciente = (Paciente)pacienteFactory.getById(pacienteID);

                if (paciente != null)
                {
                    
                    bool asignar = true;
                    
                    if (asignar)
                    {
                        tbPacienteID.Text = paciente.id.ToString();

                        EntidadBase vPaciente = vistaPacienteFac.getById(paciente.id.ToString());
                        lbLiga.Text = vPaciente.campos["Liga"].ToString();
                        lbClub.Text = vPaciente.campos["Club"].ToString();
                        lbEmpresa.Text = vPaciente.campos["Empresa"].ToString();
                        lbTarea.Text = vPaciente.campos["empresaTarea"].ToString();
                        vPaciente = null;

                        lbApellido.Text = paciente.apellido;
                        lbNombres.Text = paciente.nombres;
                        lbDNI.Text = paciente.dni;
                        lbFechaNacimiento.Text = paciente.fechaNacimiento.ToString("dd/MM/yyyy");
                        tbObservaciones.Text = paciente.observaciones;
                        tbObservaciones.Focus();

                        //Establece la visibilidad de las etiquetas
                        if (paciente.pacienteTipo.codigo == "PREVENTIVA")
                        {
                            lbTitLiga.Visible = true;
                            lbLiga.Visible = true;
                            lbTitClub.Visible = true;
                            lbClub.Visible = true;

                            lbTitEmpresa.Visible = false;
                            lbEmpresa.Visible = false;
                            lbTitTarea.Visible = false;
                            lbTarea.Visible = false;
                        }
                        if (paciente.pacienteTipo.codigo == "LABORAL")
                        {
                            lbTitLiga.Visible = false;
                            lbLiga.Visible = false;
                            lbTitClub.Visible = false;
                            lbClub.Visible = false;

                            lbTitEmpresa.Visible = true;
                            lbEmpresa.Visible = true;
                            lbTitTarea.Visible = true;
                            lbTarea.Visible = true;
                        }
                        if (paciente.pacienteTipo.codigo == "OTROS")
                        {
                            lbTitLiga.Visible = false;
                            lbLiga.Visible = false;
                            lbTitClub.Visible = false;
                            lbClub.Visible = false;

                            lbTitEmpresa.Visible = false;
                            lbEmpresa.Visible = false;
                            lbTitTarea.Visible = false;
                            lbTarea.Visible = false;
                        }
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

        //Si la fecha es nueva, inicializa los números de orden. Sino, genera uno nuevo.
        private void nuevoNroOrden(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Checked)
            {
                rb.BackColor = Color.Red;
                string tipo = rb.Name.Substring(2);

                string sfecha = (string)this.configuracion.obtenerParametro("MESA_ENTRADA_FECHA");
                DateTime fecha;
                DateTime.TryParse(sfecha, out fecha);
                if (fecha.Day != DateTime.Now.Day) //Si es diferente el día, alcanza para reiniciar los contadores
                    reiniciarContadores();

                int valorIdentificador = (int)this.configuracion.obtenerParametro("MESA_ENTRADA_" + tipo);
                valorIdentificador++;

                int valorOrden = 0;

                //Si está agregando, obtiene el último nro de orden
                if (this.edicion == ModoEdicion.AGREGANDO)
                {
                    valorOrden = (int)this.configuracion.obtenerParametro("MESA_ENTRADA_ORDEN");
                    valorOrden++;
                } //Si está modificando, mantiene el mismo numero de orden.
                else if (this.edicion == ModoEdicion.MODIFICANDO)
                    valorOrden = int.Parse(tbNroOrden.Text);


                if (tipo == "P")
                    tbIdentificador.Text = valorIdentificador.ToString();
                else
                    tbIdentificador.Text = tipo + valorIdentificador.ToString();

                tbNroOrden.Text = valorOrden.ToString();

                establecerCamposPorTipo(tipo);
                
                //Abre directamente el formulario de Pacientes
                if (this.edicion == ModoEdicion.AGREGANDO && !this.aceptandoCambios)
                {
                    tbObservaciones.Focus();
                    abrirVentanaPaciente(tipo);
                }
            }
            else
                rb.BackColor = SystemColors.Control;
        }
        
        private void establecerCamposPorTipo(string tipo)
        {
            if (tipo == "P")
            {
                lbTitLiga.Visible = true;
                lbLiga.Visible = true;
                lbTitClub.Visible = true;
                lbClub.Visible = true;
                
                lbTitEmpresa.Visible = false;
                lbEmpresa.Visible = false;
                lbTitTarea.Visible = false;
                lbTarea.Visible = false;
            }
            if (tipo == "L" || tipo=="CO")
            {
                lbTitLiga.Visible = false;
                lbLiga.Visible = false;
                lbTitClub.Visible = false;
                lbClub.Visible = false;

                lbTitEmpresa.Visible = true;
                lbEmpresa.Visible = true;
                lbTitTarea.Visible = true;
                lbTarea.Visible = true;
            }
            if (tipo == "CL" || tipo == "R")
            {
                lbTitLiga.Visible = true;
                lbLiga.Visible = true;
                lbTitClub.Visible = true;
                lbClub.Visible = true;

                lbTitEmpresa.Visible = true;
                lbEmpresa.Visible = true;
                lbTitTarea.Visible = true;
                lbTarea.Visible = true;
            }
        }
        


        private void reiniciarContadores()
        {
            this.configuracion.guardarParametro("MESA_ENTRADA_FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
            this.configuracion.guardarParametro("MESA_ENTRADA_ORDEN", 0);
            this.configuracion.guardarParametro("MESA_ENTRADA_P", this.inicioContadorP);
            this.configuracion.guardarParametro("MESA_ENTRADA_L", 0);
            this.configuracion.guardarParametro("MESA_ENTRADA_CL", 0);
            this.configuracion.guardarParametro("MESA_ENTRADA_CO", 0);
            this.configuracion.guardarParametro("MESA_ENTRADA_R", 0);
        }


        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date)
            {
                dtpFechaHasta.Value = dtpFechaDesde.Value.Date;
            }
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaHasta.Value.Date < dtpFechaDesde.Value.Date)
            {
                dtpFechaDesde.Value = dtpFechaHasta.Value.Date;
            }
        }

        private void butBuscarPorCampos_Click(object sender, EventArgs e)
        {
            buscar();
        }

        //Realiza la busqueda de las palabras clave de la caja de texto, combinado con los campos filtro
        protected void buscar()
        {
            try
            {
                if (this.EntidadNombre != "Grilla")
                {
                    this.Cursor = Cursors.WaitCursor;
                    dgItems.Cursor = Cursors.WaitCursor;
                    base.buscandoPalabrasClave = true;
                    string like = "1=1 ";  
                    string textoFiltro = "";
                    string separador = "";

                    like += " AND fecha>= " + Utilidades.fechaCanonicaSQL(dtpFechaDesde.Value.Date, "00:00:00");
                    like += " AND fecha<= " + Utilidades.fechaCanonicaSQL(dtpFechaHasta.Value.Date, "23:59:59");
                    
                    textoFiltro += dtpFechaDesde.Value.Day + "/" + dtpFechaDesde.Value.Month + " al " + dtpFechaHasta.Value.Day + "/" + dtpFechaHasta.Value.Month + " ";
                    separador = " | ";

                    textoFiltro += separador + "Consultas:";
                    string likeTipos = "";
                    string or = "";
                    if (chP.Checked)
                    {
                        likeTipos += or + " tipo='P'";
                        textoFiltro += "  P";
                        or = " OR ";
                    }
                    if (chL.Checked)
                    {
                        likeTipos += or +" tipo='L'";
                        textoFiltro += "  L";
                        or = " OR ";
                    }
                    if (chCL.Checked)
                    {
                        likeTipos += or + " tipo='CL'";
                        textoFiltro += "  CL";
                        or = " OR ";
                    }
                    if (chR.Checked)
                    {
                        likeTipos += or + " tipo='R'";
                        textoFiltro += "  R";
                        or = " OR ";
                    }
                    if (chCO.Checked)
                    {
                        likeTipos += or + " tipo='CO'";
                        textoFiltro += "  CO";
                        or = " OR ";
                    }

                    if (likeTipos != "")
                    {
                        like += " AND (" + likeTipos + ")";
                    }

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

                    lbFiltro.Text = textoFiltro;


                    inicializarGrilla(new ConsultaFactory(this.configuracion, this.EntidadNombre), like);

                    lbCantRegistros.Text = dgItems.RowCount.ToString() + " registros.";

                    this.Cursor = Cursors.Default;
                    dgItems.Cursor = Cursors.Default;
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

        private void butImprimirComprobante_Click(object sender, EventArgs e)
        {
            imprimirComprobante();
        }

        private void imprimirComprobante()
        {
            try
            {
                rptComprobante doc = new rptComprobante();

                doc.DataDefinition.FormulaFields["txtNroOrden"].Text = "\"" + tbNroOrden.Text + "\"";
                doc.DataDefinition.FormulaFields["txtIdentificador"].Text = "\"" + tbIdentificador.Text + "\"";
                doc.DataDefinition.FormulaFields["txtIdentificadorPie"].Text = "\"" + tbIdentificador.Text + "\"";
                doc.DataDefinition.FormulaFields["txtFecha"].Text = "\"" + rglEntidad.fecha.ToString("dd/MM/yyyy") + "\"";
                doc.DataDefinition.FormulaFields["txtFechaPie"].Text = "\"" + rglEntidad.fecha.ToString("dd/MM/yyyy") + "\"";
                if (rglEntidad.paciente.pacienteTipo.codigo == "PREVENTIVA")
                {
                    doc.DataDefinition.FormulaFields["txtLiga"].Text = "\"" + lbLiga.Text + "\"";
                    doc.DataDefinition.FormulaFields["txtClubEmpresa"].Text = "\"" + lbClub.Text + "\"";
                }
                if (rglEntidad.paciente.pacienteTipo.codigo == "LABORAL")
                {
                    doc.DataDefinition.FormulaFields["txtClubEmpresa"].Text = "\"" + lbEmpresa.Text + "\"";
                    doc.DataDefinition.FormulaFields["txtTarea"].Text = "\"" + lbTarea.Text + "\"";
                }
                doc.DataDefinition.FormulaFields["txtApellidoNombre"].Text = "\"" + lbApellido.Text.Trim() + ", " + lbNombres.Text + "\"";
                doc.DataDefinition.FormulaFields["txtApellidoNombrePie"].Text = "\"" + lbApellido.Text.Trim() + ", " + lbNombres.Text + "\"";
                doc.DataDefinition.FormulaFields["txtDni"].Text = "\"" + lbDNI.Text + "\"";
                doc.DataDefinition.FormulaFields["txtFechaNacimiento"].Text = "\"" + rglEntidad.paciente.fechaNacimiento.ToString("dd/MM/yyyy") + "\"";

                string telefono = "";
                if (rglEntidad.paciente.celular.Trim() != "")
                    telefono = rglEntidad.paciente.celular.Trim();
                else
                    telefono = rglEntidad.paciente.telefonos.Trim();
                doc.DataDefinition.FormulaFields["txtTelefono"].Text = "\"" + telefono + "\"";
                

                if (!this.esMovil)
                {
                    if (MessageBox.Show("¿Imprimir Comprobante 1?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        doc.DataDefinition.FormulaFields["txtNroCopia"].Text = "\"1\"";
                        doc.PrintToPrinter(1, true, 1, 1);
                    }
                }
                if (MessageBox.Show("¿Imprimir Comprobante 2? \r\n(Hoja de Ruta con copia para el Laboratorio)", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    doc.DataDefinition.FormulaFields["txtNroCopia"].Text = "\"2\"";
                    doc.PrintToPrinter(1, true, 1, 1);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tabPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPrincipal.SelectedIndex == 0)
                lbCantRegistros.Text = dgItems.RowCount.ToString() + " registros.";
        }

        protected override void cambiarEtiquetaEdicion()
        {
            switch (edicion)
            {
                case ModoEdicion.AGREGANDO:
                    {
                        lbTitulo.Text = "Agregando Nuevo Registro...";
                        lbTitulo.BackColor = Color.Red;
                        break;
                    }
                case ModoEdicion.MODIFICANDO:
                    {
                        lbTitulo.Text = "Modificando Registro...";
                        lbTitulo.BackColor = Color.Red;
                        break;
                    }
                case ModoEdicion.VACIO:
                    {
                        lbTitulo.Text = this.Text;
                        lbTitulo.BackColor = this.colorTitulo;
                        break;
                    }
            }
        }



    }
}