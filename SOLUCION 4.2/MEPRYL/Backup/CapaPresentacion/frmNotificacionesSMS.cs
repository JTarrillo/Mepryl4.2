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
using Microsoft.ApplicationBlocks.Data;

namespace CapaPresentacion
{
    public partial class frmNotificacionesSMS : CapaPresentacionBase.frmBaseGrillaABM
    {
        public Paciente rglEntidad;

        public frmNotificacionesSMS(Configuracion config, ModoApertura modo)
            : base(config, modo)
        {
            //InitializeComponent();
            EntidadNombre = "Paciente";
            this.habilitarBotonAgregar = false;
            this.habilitarBotonEliminar = false;
        }

        //Implementacion
        protected override void inicializarEntidad()
        {
            rglEntidad = new Paciente();
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
                //navegador.agregarControl(new CapsulaControl((Control)dtpFechaNacimientoDesde));
                //navegador.agregarControl(new CapsulaControl((Control)dtpFechaNacimientoHasta));
                navegador.agregarControl(new CapsulaControl((Control)cbLigaB));
                navegador.agregarControl(new CapsulaControl((Control)cbClubB));
                
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
            Utilidades.llenarCombo(ref cbClubB, this.configuracion.getConectionString(), "sp_Club_SelectAll", "Todos", 0);

            butSeleccionarTodo.Tag = true;
            butSeleccionarTodoEnviar.Tag = true;
            
            /*dtpFechaNacimientoDesde.Value = new DateTime(1900, 01, 01);
            dtpFechaNacimientoDesde.Tag = dtpFechaNacimientoDesde.Value;
            dtpFechaNacimientoHasta.Value = DateTime.Now;
            dtpFechaNacimientoHasta.Tag = dtpFechaNacimientoHasta.Value;*/
           
            this.busquedaInstantanea = false;
            inicializarEntidad();

            cbLigaB.Focus();

        }


        protected new void inicializarGrilla(CapaNegocioBase.EntidadFactoryBase ef, string filtro)
        {
            inicializarGrilla(ef, filtro, 0);
        }

        protected new void inicializarGrilla(CapaNegocioBase.EntidadFactoryBase ef, string filtro, int top)
        {
            try
            {
                base.inicializarGrilla(ef, filtro, top, "Paciente");
                //Arregla la grilla
                dgItems.Columns["id"].Visible = false;
                dgItems.Columns["codigo"].Visible = false;
                dgItems.Columns["ligaID"].Visible = false;
                dgItems.Columns["clubID"].Visible = false;
                dgItems.Columns["observaciones"].Visible = false;
                dgItems.Columns["tipoPacienteID"].Visible = false;
                dgItems.Columns["fechaUltimoExamen"].Visible = false;
                dgItems.Columns["descripcion"].Visible = false;
                dgItems.Columns["pacienteTipoCodigo"].Visible = false;
                dgItems.Columns["registroBLOB"].Visible = false;

                //Asigna los nombres de la base de datos
                dgItems.Columns["seleccionar"].HeaderText = "";
                dgItems.Columns["apellido"].HeaderText = "Apellido";
                dgItems.Columns["nombres"].HeaderText = "Nombres";
                dgItems.Columns["dni"].HeaderText = "DNI";
                dgItems.Columns["ligaTexto"].HeaderText = "Liga";
                dgItems.Columns["clubTexto"].HeaderText = "Club";
                dgItems.Columns["fechaNacimiento"].HeaderText = "Fecha Nac.";
                dgItems.Columns["celular"].HeaderText = "Celular";

                dgItems.Columns["fechaNacimiento"].DefaultCellStyle.Format = "d";
                
                dgItems.ReadOnly = false;

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

            inicializarGrilla(new PacienteFactory(this.configuracion, this.EntidadNombre), "1=2");
        }


        //Realiza la busqueda de las palabras clave de la caja de texto, combinado con los campos filtro

        protected void buscar()
        {
            try
            {
                if (this.EntidadNombre != "Grilla")
                {
                    this.Cursor = Cursors.WaitCursor;
                    base.buscandoPalabrasClave = true;
                    
                    string textoFiltro = "";
                    string separador = "";
                    string like = "1=1"; // "pacienteTipoCodigo='PREVENTIVA'"; 
                    //string like = "pacienteTipoCodigo='PREVENTIVA'"; 
                    
                
                    /*if (dtpFechaNacimientoDesde.Value > (DateTime)dtpFechaNacimientoDesde.Tag)
                    {
                        like += " AND fechaNacimiento>= " + Utilidades.fechaCanonicaSQL(dtpFechaNacimientoDesde.Value.Date, "00:00:00");
                        textoFiltro += dtpFechaNacimientoDesde.Value.Day + "/" + dtpFechaNacimientoDesde.Value.Month;
                        separador = " | ";
                    }
                    if (dtpFechaNacimientoHasta.Value < (DateTime)dtpFechaNacimientoHasta.Tag)
                    {
                        like += " AND fechaNacimiento<= " + Utilidades.fechaCanonicaSQL(dtpFechaNacimientoHasta.Value.Date, "23:59:59");
                        textoFiltro += " al " + dtpFechaNacimientoHasta.Value.Day + "/" + dtpFechaNacimientoHasta.Value.Month + " ";
                        separador = " | ";
                    }*/
                    if (tbCategoriaB.Text.Trim() != "" && Utilidades.IsNumeric(tbCategoriaB.Text)) {
                        DateTime fechaCategoriaDesde = new DateTime(int.Parse(tbCategoriaB.Text), 1, 1, 0, 0, 0);
                        DateTime fechaCategoriaHasta = new DateTime(int.Parse(tbCategoriaB.Text), 12, 31, 23, 59, 59);
                        
                        like += " AND fechaNacimiento>= " + Utilidades.fechaCanonicaSQL(fechaCategoriaDesde, "00:00:00");
                        like += " AND fechaNacimiento<= " + Utilidades.fechaCanonicaSQL(fechaCategoriaHasta, "23:59:59");
                        textoFiltro += "Categoría: " + tbCategoriaB.Text;
                        separador = " | ";
                    }
                    
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

                    inicializarGrilla(new PacienteFactory(this.configuracion, this.EntidadNombre), like);

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
            cbLigaB.Focus();
        }

        
        private void cbLigaB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLigaB.SelectedIndex == 0)
                Utilidades.llenarCombo(ref cbClubB, this.configuracion.getConectionString(), "sp_Club_SelectAll", "Todos", 0);
            else
            {
                Utilidades.llenarCombo(ref cbClubB, this.configuracion.getConectionString(), "sp_Club_SelectFiltro", "Todos", 0,
                                        "ligaID='" + Utilidades.comboObtenerID(ref cbLigaB) + "'");
            }
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

        private void tbCategoriaB_Validating(object sender, CancelEventArgs e)
        {
            tbCategoriaB.Text = tbCategoriaB.Text.Replace(" ", "");
            string mensaje = "";
            if (tbCategoriaB.Text.Trim() != "" && Utilidades.IsNumeric(tbCategoriaB.Text))
            {
                int categoria = int.Parse(tbCategoriaB.Text);
                if (categoria < 1900)
                    if (categoria >= 0 && categoria < 20)
                        categoria += 2000;
                    else if (categoria >= 20 && categoria < 100)
                        categoria += 1900;
                    else
                        mensaje = "Categoría errónea.";


                tbCategoriaB.Text = categoria.ToString();
            }
            else if (tbCategoriaB.Text.Trim() != "")
                mensaje = "Categoría errónea.";

            if (mensaje != "")
            {
                MessageBox.Show("Categoría errónea.", "Categoría", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void butBuscar_Click(object sender, EventArgs e)
        {
            butSeleccionarTodo.Tag = true;
            butSeleccionarTodoEnviar.Tag = true;
            buscar();
        }

        private void butSeleccionarTodo_Click(object sender, EventArgs e)
        {
            /*this.Cursor = Cursors.WaitCursor;
            butSeleccionarTodo.Tag = !bool.Parse(butSeleccionarTodo.Tag.ToString());

            foreach (DataGridViewRow row in dgItems.Rows){
                row.Cells["seleccionar"].Value = bool.Parse(butSeleccionarTodo.Tag.ToString());
            }
            this.Cursor = Cursors.Default;*/

            butSeleccionarTodo.Tag = !bool.Parse(butSeleccionarTodo.Tag.ToString());
            seleccionarTodo(ref dgItems, bool.Parse(butSeleccionarTodo.Tag.ToString()));
        }

        private void butAgregarALista_Click(object sender, EventArgs e)
        {
            agregarALaLista();
        }

        private void agregarALaLista() {
            //Primero deselecciona la lista de envios
            //seleccionarTodo(ref dgListaEnviar, false);

            this.Cursor = Cursors.WaitCursor;
            if (dgItems.RowCount > 0)
            {
                bool haySeleccionados = false;
                int seleccionados = 0;
                foreach (DataGridViewRow row in dgItems.Rows)
                {
                    bool seleccionado = bool.Parse(row.Cells["seleccionar"].Value.ToString());
                    if (seleccionado)
                    {
                        int nuevo = dgListaEnviar.Rows.Add();
                        dgListaEnviar.Rows[nuevo].Cells["seleccionar"].Value = row.Cells["seleccionar"].Value;
                        dgListaEnviar.Rows[nuevo].Cells["dni"].Value = row.Cells["dni"].Value;
                        dgListaEnviar.Rows[nuevo].Cells["apellido"].Value = row.Cells["apellido"].Value;
                        dgListaEnviar.Rows[nuevo].Cells["nombres"].Value = row.Cells["nombres"].Value;
                        dgListaEnviar.Rows[nuevo].Cells["ligaTexto"].Value = row.Cells["ligaTexto"].Value;
                        dgListaEnviar.Rows[nuevo].Cells["clubTexto"].Value = row.Cells["clubTexto"].Value;
                        dgListaEnviar.Rows[nuevo].Cells["fechaNacimiento"].Value = row.Cells["fechaNacimiento"].Value;
                        dgListaEnviar.Rows[nuevo].Cells["celular"].Value = row.Cells["celular"].Value;
                        haySeleccionados = true;
                    }
                }
                dgListaEnviar.Columns["fechaNacimiento"].DefaultCellStyle.Format = "d";
                actualizarEtiquetaSeleccionados();
                if (haySeleccionados)
                    dgListaEnviar.FirstDisplayedScrollingRowIndex = dgListaEnviar.RowCount - 1;
                else
                    MessageBox.Show( "Debe seleccionar algún registro.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Cursor = Cursors.Default;
        }

        private void butSeleccionarTodoEnviar_Click(object sender, EventArgs e)
        {
            /*this.Cursor = Cursors.WaitCursor;
            butSeleccionarTodoEnviar.Tag = !bool.Parse(butSeleccionarTodoEnviar.Tag.ToString());

            foreach (DataGridViewRow row in dgListaEnviar.Rows)
            {
                row.Cells["seleccionar"].Value = bool.Parse(butSeleccionarTodoEnviar.Tag.ToString());
            }
            this.Cursor = Cursors.Default;*/

            butSeleccionarTodoEnviar.Tag = !bool.Parse(butSeleccionarTodoEnviar.Tag.ToString());
            seleccionarTodo(ref dgListaEnviar, bool.Parse(butSeleccionarTodoEnviar.Tag.ToString()));
            actualizarEtiquetaSeleccionados();
        }


        //Método para seleccionar o deseleccionar una lista
        private void seleccionarTodo(ref DataGridView dg, bool valor)
        {
            this.Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow row in dg.Rows)
            {
                row.Cells["seleccionar"].Value = valor;
            }

            this.Cursor = Cursors.Default;
        }
        
        //Cuenta los registros seleccionados de una grilla
        private int contarSeleccionados(ref DataGridView dg)
        {
            this.Cursor = Cursors.WaitCursor;
            int seleccionados = 0;
            foreach (DataGridViewRow row in dg.Rows)
            {
                if (bool.Parse(row.Cells["seleccionar"].Value.ToString()))
                    seleccionados++;
            }
            this.Cursor = Cursors.Default;
            return seleccionados;
        }

        private void butBorrarSeleccionados_Click(object sender, EventArgs e)
        {
            if (dgListaEnviar.RowCount>0)
                if (MessageBox.Show("¿Desea borrar los registros seleccionados?", "Borrar Seleccionados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int i = 0;
                    while (dgListaEnviar.RowCount>0 && i<dgListaEnviar.RowCount)
                    {
                        if (dgListaEnviar.Rows[i].Cells["seleccionar"].Value.ToString() == "True")
                        {
                            dgListaEnviar.Rows.RemoveAt(i);
                        }
                        else
                        {
                            i++;
                        }
                    }
                    actualizarEtiquetaSeleccionados();
                    this.Cursor = Cursors.Default;
                }
        }

        private void actualizarEtiquetaSeleccionados() {
            lbListaEnviar.Text = "Lista para Enviar (" + contarSeleccionados(ref dgListaEnviar) + ")";
        }

        private void butEnviarLista_Click(object sender, EventArgs e)
        {
            string mensajeValidacion = "";

            if (tbMensaje.Text.Trim() == "")
                mensajeValidacion += "\n\r    - Debe escribir algún mensaje antes de enviar las notificaciones.";
            if (dgListaEnviar.RowCount==0)
                mensajeValidacion += "\n\r    - No hay registros en la Lista para Enviar.";

            if (mensajeValidacion == "") {
                string mensaje = tbMensaje.Text.Trim();
                mensaje = mensaje.Replace("*APELLIDO*", dgListaEnviar["apellido", 0].Value.ToString());
                mensaje = mensaje.Replace("*NOMBRE*", dgListaEnviar["nombres", 0].Value.ToString());
                mensaje = mensaje.Replace("*DNI*", dgListaEnviar["dni", 0].Value.ToString());
                                    
                if (MessageBox.Show("Está a punto de enviar " + contarSeleccionados(ref dgListaEnviar) + " notificaciones con el siguiente mensaje (primer registro como ejemplo):\r\n\r\n\"" + mensaje + "\"\r\n\r\n¿Confirma el envío?", "Enviar Lista", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    enviarLista();
            }
            else
                MessageBox.Show("Todavía no se pueden enviar las notificaciones por lo siguiente:" + mensajeValidacion, "Enviar Lista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //Envia la lista a la bandeja de salida de DataSMS
        private void enviarLista() {
            try
            {
                int seleccionados = contarSeleccionados(ref dgListaEnviar);
                if (dgListaEnviar.Rows.Count > 1 || (dgListaEnviar.Rows.Count == 1 && dgListaEnviar["celular", 0].Value != null && dgItems["apellido", 0].Value != null))
                {
                    /*DialogResult op = MessageBox.Show("Está a punto de enviar esta lista de mensajes a DataSMS. " +
                                                        "Una vez enviada, DataSMS comenzará a procesarla.\r\n" +
                                                        "¿Desea continuar?", "Enviar a DataSMS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (op == DialogResult.Yes)
                    {*/
                        Cursor.Current = Cursors.WaitCursor;
                        string telefono = "";
                        string mensaje = "";
                        int variacion = 0;
                        int enviados = 0, noEnviados = -1;
                        foreach (DataGridViewRow row in dgListaEnviar.Rows)
                        {
                            if (bool.Parse(row.Cells["seleccionar"].Value.ToString()))
                            {
                                bool enviadoOK = false;
                                telefono = "";
                                mensaje = "";
                                if (row.Cells["celular"].Value != null)
                                    if (row.Cells["seleccionar"].Value.ToString() == "True"
                                        && row.Cells["celular"].Value.ToString().Trim() != "")
                                    {
                                        telefono = row.Cells["celular"].Value.ToString();
                                        mensaje = tbMensaje.Text.Trim();
                                        //Reemplaza el nombre, apellido y DNI
                                        mensaje = mensaje.Replace("*APELLIDO*", row.Cells["apellido"].Value.ToString());
                                        mensaje = mensaje.Replace("*NOMBRE*", row.Cells["nombres"].Value.ToString());
                                        mensaje = mensaje.Replace("*DNI*", row.Cells["dni"].Value.ToString());
                                        telefono = Utilidades.quitarAcentos(telefono);
                                        mensaje = Utilidades.quitarAcentos(mensaje);
                                        telefono = telefono.Replace("'", "''");
                                        mensaje = mensaje.Replace("'", "''");

                                        //Variacion del mensaje
                                        variacion = 0;
                                        //int.TryParse(row.Cells["variacion"].Value.ToString(), out variacion);

                                        SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString2(), CommandType.Text,
                                                                    "INSERT INTO BandejaSalida (telefono, mensaje, estadoID, variacionMensaje) VALUES ('" + telefono + "','" + mensaje + "', 1, " + variacion.ToString() + ")");
                                        enviadoOK = true;
                                    }

                                if (enviadoOK)
                                    enviados++;
                                else
                                    noEnviados++;
                            }
                            Application.DoEvents();
                        }
                        Cursor.Current = Cursors.Default;

                        MessageBox.Show("Proceso realizado con éxito.\r\n\r\n" +
                                        "Mensajes enviados a DataSMS: " + enviados.ToString() + "\r\n" +
                                        "Mensajes ignorados:          " + noEnviados.ToString(),
                                        "Enviar a DataSMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
                else
                    MessageBox.Show("La lista se encuentra vacía. Debe ingresar o importar al menos un destinatario y un mensaje válidos.", "Enviar a DataSMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void dgListaEnviar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            actualizarEtiquetaSeleccionados();
        }

        private void butInsertarNombre_Click(object sender, EventArgs e)
        {
            insertarPalabra(ref tbMensaje, "*NOMBRE*");
        }

        private void butInsertarApellido_Click(object sender, EventArgs e)
        {
            insertarPalabra(ref tbMensaje, "*APELLIDO*");
        }

        private void butInsertarDni_Click(object sender, EventArgs e)
        {
            insertarPalabra(ref tbMensaje, "*DNI*");
        }

        //inserta una palabra dentro del texto del mensaje
        private void insertarPalabra(ref TextBox tb, string palabra) {
            tb.AppendText(palabra);
            tbMensaje.Select();
        }

        
    }
}