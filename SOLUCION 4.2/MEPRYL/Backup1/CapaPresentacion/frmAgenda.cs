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
    public partial class frmAgenda : CapaPresentacionBase.frmBaseGrillaABM
    {
        public Turno rglEntidad;

        private string estadoLibreID = Utilidades.ID_VACIO;
        private string estadoAsignadoID = Utilidades.ID_VACIO;
        private DateTime fechaSeleccionada = DateTime.Now;

        public frmAgenda(Configuracion config, ModoApertura modo)
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

                //Carga los controles
                navegador.agregarControl(new CapsulaControl((Control)cbEspecialidadB));
                navegador.agregarControl(new CapsulaControl((Control)cbProfesionalB));
                navegador.agregarControl(new CapsulaControl((Control)cbEstadoB));
                
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


            /*habilitarControles(ref gbPaciente, ref dgItems, false);
            gbPaciente.Enabled = false;
            butLiberarTurno.Enabled = gbPaciente.Visible;*/
        }
        protected override void modoEditable()
        {
            base.modoEditable();

            /*habilitarControles(ref gbPaciente, ref dgItems, true);
            gbPaciente.Enabled = true;*/
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
            Utilidades.comboSeleccionarItemByIdentificador("1", ref cbEstadoB);
            this.estadoLibreID = Utilidades.comboObtenerID(ref cbEstadoB);

            Utilidades.comboSeleccionarItemByIdentificador("2", ref cbEstadoB);
            this.estadoAsignadoID = Utilidades.comboObtenerID(ref cbEstadoB);
            //Fin


            this.busquedaInstantanea = false;
            inicializarEntidad();

            cbEspecialidadB.Focus();

        }


        protected new void inicializarGrilla(CapaNegocioBase.EntidadFactoryBase ef, string filtro)
        {
            inicializarGrilla(ef, filtro, 0);
        }

        protected new void inicializarGrilla(CapaNegocioBase.EntidadFactoryBase ef, string filtro, int top)
        {
            try
            {
                base.inicializarGrilla(ef, filtro, top, "Agenda");
                //Arregla la grilla
                dgItems.Columns["registroBLOB"].Visible = false;
                dgItems.Columns["id"].Visible = false;
                dgItems.Columns["estadoID"].Visible = false;
                dgItems.Columns["pacienteID"].Visible = false;
                dgItems.Columns["horarioID"].Visible = false;
                dgItems.Columns["estadoCodigo"].Visible = false;
                dgItems.Columns["hora"].Visible = false;
                dgItems.Columns["especialidadID"].Visible = false;
                dgItems.Columns["profesionalID"].Visible = false;
                dgItems.Columns["bloqueado"].Visible = false;
                dgItems.Columns["usuarioID"].Visible = false;
                dgItems.Columns["pacienteCelular"].Visible = false;
                dgItems.Columns["especialidadTexto"].Visible = false;
                dgItems.Columns["estadoTexto"].Visible = false;
                dgItems.Columns["pacienteTelefonos"].Visible = false;
                dgItems.Columns["usuarioTexto"].Visible = false;

                //Asigna los nombres de la base de datos
                dgItems.Columns["fecha"].HeaderText = "Fecha";
                dgItems.Columns["horaReferencia"].HeaderText = "Hora";
                dgItems.Columns["nroOrden"].HeaderText = "Nro.";
                dgItems.Columns["profesionalTexto"].HeaderText = "Profesional";
                dgItems.Columns["pacienteTexto"].HeaderText = "Paciente";
                dgItems.Columns["clubTexto"].HeaderText = "Club";
                dgItems.Columns["empresaTexto"].HeaderText = "Empresa";  
                dgItems.Columns["observaciones"].HeaderText = "Observaciones";
                dgItems.Columns["codigo"].HeaderText = "Código";
                dgItems.Columns["pacienteDni"].HeaderText = "DNI";

                dgItems.Columns["fecha"].DefaultCellStyle.Format = "d";

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

        

        public override CapaNegocioBase.EntidadFactoryBase crearNegEntidadFac()
        {
            return new TurnoFactory(this.configuracion, this.EntidadNombre);
        }

        


        protected override void inicializarTabla()
        {
            base.inicializarTabla();

            inicializarGrilla(new TurnoFactory(this.configuracion, this.EntidadNombre), "1=2");
        }


        protected override void buscarPalabrasClave()
        {
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
                    //this.fechaSeleccionada = mcFecha.SelectionStart;


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
                            like += " AND fecha>= " + Utilidades.fechaCanonicaSQL(dtpFechaDesde.Value.Date, "00:00:00");
                            like += " AND fecha<= " + Utilidades.fechaCanonicaSQL(dtpFechaHasta.Value.Date, "23:59:59");
                        }
                        if (localizarFecha == 1)
                        {
                            //like += " AND fecha>= " + Utilidades.fechaCanonicaSQL(mcFecha.SelectionStart.AddDays(1), "00:00:00");
                        }
                        if (localizarFecha == -1)
                        {
                            ///like += " AND fecha<= " + Utilidades.fechaCanonicaSQL(mcFecha.SelectionStart.AddDays(-1), "23:59:59");
                        }
                        textoFiltro += dtpFechaDesde.Value.Day + "/" + dtpFechaDesde.Value.Month + " al " + dtpFechaHasta.Value.Day + "/" + dtpFechaHasta.Value.Month + " ";
                        separador = " | ";

                        
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
                        if (Utilidades.IsNumeric(tbCategoriaB.Text))
                        {
                            like += " AND Categoria=" + tbCategoriaB.Text;
                            textoFiltro += separador + "Categoría " + tbCategoriaB.Text;
                            separador = " | ";
                        }
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

                    lbCantRegistros.Text = dgItems.RowCount.ToString() + " registros.";

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

        protected override void imprimirListado()
        {
            try
            {
                rptAgenda doc = new rptAgenda();

                doc.SetDataSource(((DataTable)dgItems.DataSource));

                //doc.DataDefinition.FormulaFields["txtTituloF"].Text = "\"" + dgItems.CaptionText + "\"";

                string cadenaFiltro = lbFiltro.Text;
                //string cadenaOrden = ""; //obtenerCadenaOrden();
                if (cadenaFiltro!="")
                    doc.DataDefinition.FormulaFields["txtFiltroF"].Text = "\"(" + cadenaFiltro + ")\"";

                doc.DataDefinition.FormulaFields["txtCantRegistros"].Text = "\"" + lbCantRegistros.Text + "\"";
                //else
                //    doc.Section1.ReportObjects["txtFiltroTitulo"].ObjectFormat.EnableSuppress = true;

                /*if (cadenaOrden!="")
                    doc.DataDefinition.FormulaFields["txtOrdenF"].Text = "\"" + cadenaOrden + "\"";
                else
                    doc.Section7.ReportObjects["txtOrdenTitulo"].ObjectFormat.EnableSuppress = true;
                */

                /*System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
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

                frmVistaPrevia fvp = new frmVistaPrevia(doc);
                fvp.ShowDialog();
                fvp = null;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
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
            buscar(origen, localizarFecha);
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
            //buscarCombinado(2);
        }


        private void cbProfesionalB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //buscarCombinado(2);
        }

        private void cbEstadoB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //buscarCombinado(2);
        }


        private void frmTurno_Load(object sender, EventArgs e)
        {
            base.frmBaseGrillaABM_Load(sender, e);


            //buscarCombinado(2);
        }

        protected override void pintarRenglon(DataGridViewCellFormattingEventArgs e)
        {
            base.pintarRenglon(e);

            if (dgItems.Columns[e.ColumnIndex].HeaderText == "Paciente")
            {
                if (e.Value.ToString() != "")
                    dgItems.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LavenderBlush;
                else
                    dgItems.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
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



    }
}