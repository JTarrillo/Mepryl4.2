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
    public partial class frmHorario : CapaPresentacionBase.frmBaseGrillaABM
    {
        public Horario rglEntidad;
        public string seleccionarProfesionalID = Utilidades.ID_VACIO;

        public frmHorario(Configuracion config, ModoApertura modo)
            : base(config, modo)
        {
            //InitializeComponent();
            //Aca iba lo que ahora está en inicializacionEspecifica();
        }

        //Implementacion
        protected override void inicializarEntidad()
        {
            rglEntidad = new Horario();

        }

        protected override void inicializacionEspecifica()
        {
            EntidadNombre = "Horario";
            seleccionarHorariosProfesional();

            if (seleccionarProfesionalID != Utilidades.ID_VACIO)
                cboProfesional.SelectedValue = seleccionarProfesionalID;
        }

        //Carga el Navegador de Formularios
        protected override void cargarNavegadorFormulario()
        {
            try
            {
                //InitializeComponent();
                base.cargarNavegadorFormulario();
                //Carga las teclas rapidas primero
                //navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butBuscar, (char)Keys.F1));

                //Carga los controles
                navegador.agregarControl(new CapsulaControl((Control)cboProfesional));
                navegador.agregarControl(new CapsulaControl((Control)cboaEspecialidad));
                navegador.agregarControl(new CapsulaControl((Control)chDomingo));
                navegador.agregarControl(new CapsulaControl((Control)chLunes));
                navegador.agregarControl(new CapsulaControl((Control)chMartes));
                navegador.agregarControl(new CapsulaControl((Control)chMiercoles));
                navegador.agregarControl(new CapsulaControl((Control)chJueves));
                navegador.agregarControl(new CapsulaControl((Control)chViernes));
                navegador.agregarControl(new CapsulaControl((Control)chSabado));
                navegador.agregarControl(new CapsulaControl((Control)tbHoraDesde));
                navegador.agregarControl(new CapsulaControl((Control)tbHoraHasta));
                navegador.agregarControl(new CapsulaControl((Control)tbCitarCada));
                navegador.agregarControl(new CapsulaControl((Control)tbPacientes));
                navegador.agregarControl(new CapsulaControl((Control)dtpFechaDesde));
                navegador.agregarControl(new CapsulaControl((Control)dtpFechaHasta));
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


            habilitarControles(ref gbControles, ref dgItems, false);
        }
        protected override void modoEditable()
        {
            base.modoEditable();
            habilitarControles(ref gbControles, ref dgItems, true);
            this.Focus();
            /*if (this.edicion == ModoEdicion.AGREGANDO)
            {
                cboaNroCuenta.inicializar(this.configuracion, "ChequeCuenta");
                cboaNroCuenta.cboCombo.Text = "";
            }*/
            cboaEspecialidad.Focus();
        }

        
        protected override void inicializarComponentes()
        {
            InitializeComponent();

            //Verifica los permisos
            Seguridad seguridad = new Seguridad(this.configuracion);
            this.permisoAlta = seguridad.verificarPermiso("Administracion.Horarios", "ALTA");
            this.permisoModificacion = seguridad.verificarPermiso("Administracion.Horarios", "MODIFICAR");
            this.permisoBaja = seguridad.verificarPermiso("Administracion.Horarios", "BORRAR");
            seguridad = null;


            base.inicializarComponentes();

            Utilidades.llenarCombo(ref cboProfesional, this.configuracion.getConectionString(), "sp_Profesional_SelectAll", "", -1);
            cboaEspecialidad.inicializar(this.configuracion, "Especialidad");
            cboaEspecialidad.mayusculas = true;
            inicializarEntidad();

        }

        protected new void inicializarGrilla(CapaNegocioBase.EntidadFactoryBase ef, string filtro)
        {
            try
            {
                base.inicializarGrilla(ef, filtro);

                //Arregla la grilla
                dgItems.Columns["registroBLOB"].Visible = false;
                dgItems.Columns["id"].Visible = false;
                dgItems.Columns["codigo"].Visible = false;
                dgItems.Columns["profesionalID"].Visible = false;
                dgItems.Columns["especialidadID"].Visible = false;
                dgItems.Columns["domingo"].Visible = false;
                dgItems.Columns["lunes"].Visible = false;
                dgItems.Columns["martes"].Visible = false;
                dgItems.Columns["miercoles"].Visible = false;
                dgItems.Columns["jueves"].Visible = false;
                dgItems.Columns["viernes"].Visible = false;
                dgItems.Columns["sabado"].Visible = false;

                //dgItems.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgItems.Columns["importe"].DefaultCellStyle.Format = "c";

                //Asigna los nombres de la base de datos
                dgItems.Columns["profesionalTexto"].HeaderText = "Profesional";
                dgItems.Columns["especialidadTexto"].HeaderText = "Especialidad";
                dgItems.Columns["diasSimplificado"].HeaderText = "Días";
                dgItems.Columns["horaDesde"].HeaderText = "De";
                dgItems.Columns["horaHasta"].HeaderText = "A";
                dgItems.Columns["fechaDesde"].HeaderText = "Desde";
                dgItems.Columns["fechaHasta"].HeaderText = "Hasta";
                dgItems.Columns["citarCada"].HeaderText = "Citar cada";
                dgItems.Columns["pacientesGrupo"].HeaderText = "Pacientes";
                dgItems.Columns["cantidadTurnos"].HeaderText = "Turnos";
                dgItems.Columns["observaciones"].HeaderText = "Observaciones";

                dgItems.Columns["fechaDesde"].DefaultCellStyle.Format = "d";
                dgItems.Columns["fechaHasta"].DefaultCellStyle.Format = "d";

                dgItems.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        private void butAceptar1_Enter(object sender, EventArgs e)
        {
            butAceptar.Select();
        }

 
        public override string validarDatosIngresados()
        {
            return "";
        }

        protected override void cargarObjetoReglas()
        {
            try
            {
                //MessageBox.Show(cboaNroSucursal.cboCombo.Text);
                inicializarEntidad();
                rglEntidad.id = new Guid(tbId.Text);
                rglEntidad.codigo = tbCodigo.Text;
                rglEntidad.profesionalID = new Guid(Utilidades.comboObtenerID(ref cboProfesional));
                rglEntidad.profesionalTexto = cboProfesional.Text;
                rglEntidad.especialidadID = cboaEspecialidad.obtenerID();
                rglEntidad.especialidadTexto = cboaEspecialidad.cboCombo.Text;

                rglEntidad.domingo = chDomingo.Checked;
                rglEntidad.lunes = chLunes.Checked;
                rglEntidad.martes = chMartes.Checked;
                rglEntidad.miercoles = chMiercoles.Checked;
                rglEntidad.jueves = chJueves.Checked;
                rglEntidad.viernes = chViernes.Checked;
                rglEntidad.sabado = chSabado.Checked;

                rglEntidad.horaDesde = tbHoraDesde.Text;
                rglEntidad.horaHasta = tbHoraHasta.Text;
                rglEntidad.cantidadTurnos = 1; // int.Parse("0" + tbCantidadTurnos.Text.Trim());
                rglEntidad.citarCada = int.Parse("0" + tbCitarCada.Text.Trim());
                rglEntidad.pacientesGrupo = int.Parse("0" + tbPacientes.Text.Trim());
                rglEntidad.fechaDesde = dtpFechaDesde.Value;
                rglEntidad.fechaHasta = dtpFechaHasta.Value;
                rglEntidad.observaciones = tbObservaciones.Text;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override string validarNegocio()
        {
            HorarioFactory negEntidadFac = (HorarioFactory)crearNegEntidadFac();
            string resultado = negEntidadFac.validar(rglEntidad, edicion);
            negEntidadFac = null;

            return resultado;
        }

        public override CapaNegocioBase.EntidadFactoryBase crearNegEntidadFac()
        {
            return new HorarioFactory(this.configuracion, this.EntidadNombre);
        }

        public override Resultado alta()
        {
            Resultado resultado = new Resultado();

            try
            {
                gbActualizando.Visible = true;
                pbActualizando.Value = 0;
                Application.DoEvents();

                HorarioFactory negEntidadFac = (HorarioFactory)crearNegEntidadFac();
                if (!negEntidadFac.progresoHandlerAsignado)
                {
                    negEntidadFac.progreso += new ProgresoEventHandler(negEntidadFac_progreso);
                    negEntidadFac.progresoHandlerAsignado = true;
                }
                resultado = negEntidadFac.alta(rglEntidad);
                negEntidadFac = null;

                gbActualizando.Visible = false;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }

        void negEntidadFac_progreso(double valorActual, double valorFinal)
        {
            pbActualizando.Value = (int)valorActual;
            pbActualizando.Maximum = (int)valorFinal;
            Application.DoEvents();
        }

     
        //
        public override Resultado modificar()
        {
            Resultado resultado = new Resultado();
            try
            {
                gbActualizando.Visible = true;
                pbActualizando.Value = 0;
                Application.DoEvents();

                HorarioFactory negEntidadFac = (HorarioFactory)crearNegEntidadFac();
                if (!negEntidadFac.progresoHandlerAsignado)
                {
                    negEntidadFac.progreso += new ProgresoEventHandler(negEntidadFac_progreso);
                    negEntidadFac.progresoHandlerAsignado = true;
                }
                resultado = negEntidadFac.modificar(rglEntidad);
                negEntidadFac = null;

                gbActualizando.Visible = false;

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
                HorarioFactory negHorarioFac = new HorarioFactory(this.configuracion, this.EntidadNombre);
                resultado = negHorarioFac.borrar(id);

                negHorarioFac = null;
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

            inicializarGrilla(new HorarioFactory(this.configuracion, this.EntidadNombre), "1=2");
        }


        //Agrega un registro en la grilla
        public override void agregarRegistroGrilla(ref Resultado resultado)
        {
            try
            {
                if (dgItems.DataSource == null)
                    inicializarTabla();

                Horario horario = (Horario)resultado.objeto;

                //Toma los datos en memoria
                string codigo = horario.codigo;
                string profesionalTexto = cboProfesional.Text;
                string especialidadTexto = cboaEspecialidad.cboCombo.Text;

                bool domingo = chDomingo.Checked;
                bool lunes = chLunes.Checked;
                bool martes = chMartes.Checked;
                bool miercoles = chMiercoles.Checked;
                bool jueves = chJueves.Checked;
                bool viernes = chViernes.Checked;
                bool sabado = chSabado.Checked;

                string horaDesde = tbHoraDesde.Text;
                string horaHasta = tbHoraHasta.Text;

                int cantidadTurnos = 1; // int.Parse(tbCantidadTurnos.Text);
                int citarCada = int.Parse("0" + tbCitarCada.Text.Trim());
                int pacientesGrupo = int.Parse("0" + tbPacientes.Text.Trim());

                DateTime fechaDesde = dtpFechaDesde.Value;
                DateTime fechaHasta = dtpFechaHasta.Value;

                string observaciones = tbObservaciones.Text;

                DataTable tabla = (DataTable)dgItems.DataSource;
                DataRow row = tabla.NewRow();
                row["id"] = horario.id;
                row["codigo"] = tbCodigo.Text.Trim() == "" ? 0 : int.Parse(tbCodigo.Text);

                tabla.Rows.InsertAt(row, 0);
                tabla.AcceptChanges();

                dgItems.CurrentCell = dgItems[0, 0];

                dgItems.Rows[0].Cells["codigo"].Value = codigo;
                dgItems.Rows[0].Cells["profesionalTexto"].Value = profesionalTexto;
                dgItems.Rows[0].Cells["especialidadTexto"].Value = especialidadTexto;
                dgItems.Rows[0].Cells["diasSimplificado"].Value = horario.diasSimplificado;
                dgItems.Rows[0].Cells["horaDesde"].Value = horaDesde;
                dgItems.Rows[0].Cells["horaHasta"].Value = horaHasta;
                dgItems.Rows[0].Cells["fechaDesde"].Value = fechaDesde;
                dgItems.Rows[0].Cells["fechaHasta"].Value = fechaHasta;
                dgItems.Rows[0].Cells["cantidadTurnos"].Value = cantidadTurnos;
                dgItems.Rows[0].Cells["citarCada"].Value = citarCada;
                dgItems.Rows[0].Cells["pacientesGrupo"].Value = pacientesGrupo;
                dgItems.Rows[0].Cells["observaciones"].Value = observaciones;

                recuperarObjetoPorCodigo();

                row = null;
                tabla = null;
                horario = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
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
                inicializarGrilla(new HorarioFactory(this.configuracion, this.EntidadNombre), like);

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
                rglEntidad = (Horario)base.rglEntidad;
                cboProfesional.SelectedValue = rglEntidad.profesionalID.ToString();
                cboaEspecialidad.cboCombo.SelectedValue = rglEntidad.especialidadID.ToString();

                chDomingo.Checked = rglEntidad.domingo;
                chLunes.Checked = rglEntidad.lunes;
                chMartes.Checked = rglEntidad.martes;
                chMiercoles.Checked = rglEntidad.miercoles;
                chJueves.Checked = rglEntidad.jueves;
                chViernes.Checked = rglEntidad.viernes;
                chSabado.Checked = rglEntidad.sabado;

                tbHoraDesde.Text = rglEntidad.horaDesde;
                tbHoraHasta.Text = rglEntidad.horaHasta;
                tbCantidadTurnos.Text = rglEntidad.cantidadTurnos.ToString();
                tbCitarCada.Text = rglEntidad.citarCada.ToString();
                tbPacientes.Text = rglEntidad.pacientesGrupo.ToString();

                dtpFechaDesde.Value = rglEntidad.fechaDesde;
                dtpFechaHasta.Value = rglEntidad.fechaHasta;

                tbObservaciones.Text = rglEntidad.observaciones;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        protected override void limpiarFormulario()
        {
            tbObservaciones.Text = "";
        }

     
        protected override void imprimirListado()
        {
            try
            {
                /*rptListadoCheques doc = new rptListadoCheques();

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
                }*/
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void cboaEspecialidad_Load(object sender, EventArgs e)
        {
            cboaEspecialidad.Focus();
        }

        private void cboProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionarHorariosProfesional();
        }


        private void seleccionarHorariosProfesional()
        {
            try
            {
                if (this.EntidadNombre!="Grilla") //Solo si ya fue inicializado el nombre de entidad.
                    inicializarGrilla(new HorarioFactory(this.configuracion, this.EntidadNombre), "profesionalID='" + Utilidades.comboObtenerID(ref cboProfesional) + "'");
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


    }
}