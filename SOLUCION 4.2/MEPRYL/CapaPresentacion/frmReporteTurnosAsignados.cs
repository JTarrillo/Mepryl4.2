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
    public partial class frmReporteTurnosAsignados : CapaPresentacionBase.frmBaseGrillaABM
    {
        public Turno rglEntidad;

        private string estadoLibreID = Utilidades.ID_VACIO;
        private string estadoAsignadoID = Utilidades.ID_VACIO;
        private DateTime fechaSeleccionada = DateTime.Now;

        public frmReporteTurnosAsignados(Configuracion config, ModoApertura modo)
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
                navegador.agregarControl(new CapsulaControl((Control)dtpFechaDesde));
                navegador.agregarControl(new CapsulaControl((Control)dtpFechaHasta));
                navegador.agregarControl(new CapsulaControl((Control)cbLigaB));
                navegador.agregarControl(new CapsulaControl((Control)cbClubB));
                navegador.agregarControl(new CapsulaControl((Control)tbCategoriaDesdeB));
                navegador.agregarControl(new CapsulaControl((Control)tbCategoriaHastaB));
                navegador.agregarControl(new CapsulaControl((Control)butBuscarPorCampos));

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

            Utilidades.llenarCombo(ref cbLigaB, this.configuracion.getConectionString(), "sp_Liga_SelectAll", "Todas", 0);
            llenarClubes();
            //Fin


            this.busquedaInstantanea = false;
            inicializarEntidad();

            dtpFechaDesde.Focus();

        }

        private void llenarClubes()
        {
            try
            {
                string ligaID = Utilidades.comboObtenerID(ref cbLigaB);
                Utilidades.llenarCombo(ref cbClubB, this.configuracion.getConectionString(), "sp_Club_SelectFiltro", "Todos", 0, "ligaID='" + ligaID + "'");

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        protected new void inicializarGrilla(CapaNegocioBase.EntidadFactoryBase ef, string filtro)
        {
            inicializarGrilla(ef, filtro, 0);
        }

        protected new void inicializarGrilla(CapaNegocioBase.EntidadFactoryBase ef, string filtro, int top)
        {
            try
            {
                base.inicializarGrilla(ef, filtro, top, "ReporteTurnos");
                //Arregla la grilla
                dgItems.Columns["ligaID"].Visible = false;
                dgItems.Columns["clubID"].Visible = false;
                dgItems.Columns["bloqueado"].Visible = false;
                dgItems.Columns["dni"].Visible = false;
                
                //Asigna los nombres de la base de datos
                dgItems.Columns["Liga"].HeaderText = "Liga";
                dgItems.Columns["Club"].HeaderText = "Club";
                dgItems.Columns["Categoria"].HeaderText = "Categor�a";
                dgItems.Columns["Fecha"].HeaderText = "Fecha";
                dgItems.Columns["Paciente"].HeaderText = "Paciente";
                dgItems.Columns["Telefonos"].HeaderText = "Tel�fono";

                dgItems.Columns["Fecha"].DefaultCellStyle.Format = "d";

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
                    string like = "1=1 "; // "bloqueado=0";  //No muestra los registros bloqueados.
                    //this.fechaSeleccionada = mcFecha.SelectionStart;


                    /*Dictionary<string, string> diasSemana = new Dictionary<string, string>();
                    diasSemana["Sunday"] = "Domingo";
                    diasSemana["Monday"] = "Lunes";
                    diasSemana["Tuesday"] = "Martes";
                    diasSemana["Wednesday"] = "Mi�rcoles";
                    diasSemana["Thursday"] = "Jueves";
                    diasSemana["Friday"] = "Viernes";
                    diasSemana["Saturday"] = "S�bado";*/

                    string textoFiltro = "";
                    string separador = "";

                    if (formaBusqueda == 2 || formaBusqueda == 0)
                    {
                        if (localizarFecha == 0)
                        {
                            like += " AND Fecha>= " + Utilidades.fechaCanonicaSQL(dtpFechaDesde.Value.Date, "00:00:00");
                            like += " AND Fecha<= " + Utilidades.fechaCanonicaSQL(dtpFechaHasta.Value.Date, "23:59:59");
                        }
                        if (localizarFecha == 1)
                        {
                            //like += " AND fecha>= " + Utilidades.fechaCanonicaSQL(mcFecha.SelectionStart.AddDays(1), "00:00:00");
                        }
                        if (localizarFecha == -1)
                        {
                            ///like += " AND fecha<= " + Utilidades.fechaCanonicaSQL(mcFecha.SelectionStart.AddDays(-1), "23:59:59");
                        }
                        textoFiltro += dtpFechaDesde.Value.Day + "/" + dtpFechaDesde.Value.Month + "/" + dtpFechaDesde.Value.Year + " al " + dtpFechaHasta.Value.Day + "/" + dtpFechaHasta.Value.Month + "/" + dtpFechaHasta.Value.Year + " ";
                        separador = " | ";


                        if (cbLigaB.SelectedIndex > 0)
                        {
                            like += " AND ligaID='" + cbLigaB.SelectedValue.ToString() + "'";
                            textoFiltro += separador + cbLigaB.Text;
                            separador = " | ";
                        }
                        if (cbClubB.SelectedIndex > 0)
                        {
                            like += " AND clubID='" + cbClubB.SelectedValue.ToString() + "'";
                            textoFiltro += separador + cbClubB.Text;
                            separador = " | ";
                        }
                        if (Utilidades.IsNumeric(tbCategoriaDesdeB.Text))
                        {
                            like += " AND Categoria>=" + tbCategoriaDesdeB.Text;
                            textoFiltro += separador + " desde la Categor�a " + tbCategoriaDesdeB.Text;
                            separador = " | ";
                        }
                        if (Utilidades.IsNumeric(tbCategoriaHastaB.Text))
                        {
                            like += " AND Categoria<=" + tbCategoriaHastaB.Text;
                            textoFiltro += separador + " hasta la Categor�a " + tbCategoriaHastaB.Text;
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
                rptReporteTurnos doc = new rptReporteTurnos();

                doc.SetDataSource(((DataTable)dgItems.DataSource));

                //doc.DataDefinition.FormulaFields["txtTituloF"].Text = "\"" + dgItems.CaptionText + "\"";

                string cadenaFiltro = lbFiltro.Text;
                //string cadenaOrden = ""; //obtenerCadenaOrden();
                if (cadenaFiltro != "")
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
            dtpFechaDesde.Focus();
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

        private void cbLigaB_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarClubes();
        }

    }
}