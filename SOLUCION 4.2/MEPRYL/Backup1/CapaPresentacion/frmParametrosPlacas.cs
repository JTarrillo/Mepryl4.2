using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocio;
using CapaPresentacionBase;
using CapaNegocioBase;
using UserControls;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace CapaPresentacion
{
    public partial class frmParametrosPlacas: CapaPresentacionBase.frmBaseEntidadABM
    {
        public ParametrosPlacas rglEntidad;
        public bool inicializando = true;

        public frmParametrosPlacas()
        {
            InitializeComponent();
        }

        public frmParametrosPlacas(Configuracion config, bool mostrarBotonOk)
            : base(config, mostrarBotonOk)
        {
            EntidadNombre = "ParametrosPlacas";
        }

        public frmParametrosPlacas(Configuracion config)
            : base(config)
        {
            EntidadNombre = "ParametrosPlacas";
            
            
        }

        //Implementacion
        protected override void inicializarEntidad()
        {
            rglEntidad = new ParametrosPlacas();
        }
        

        //
        //Para redefinir en cada formulario
        //
        protected override void modoEstatico(bool hayObjetoActivo)
        {
            if (!inicializando){
                base.modoEstatico(hayObjetoActivo);
                habilitarControles(ref gbDatosPersonales, false);
            } 
            
        }


        protected override void modoEditable()
        {
            if (this.edicion != ModoEdicion.AGREGANDO)
            {
                base.modoEditable();
                habilitarControles(ref gbDatosPersonales, true);
                this.Focus();

                if (this.edicion == ModoEdicion.MODIFICANDO)
                    tbCategoriaInicial.Focus();
                else
                    tbCategoriaInicial.Focus();
            }
        }

        protected override void inicializarComponentes()
        {
            this.EntidadNombre = "ParametrosPlacas";
            InitializeComponent();
            base.inicializarComponentes();
            
            inicializarEntidad();
            Utilidades.llenarCheckedListBox(ref chklbLigas, this.configuracion.getConectionString(), "sp_Liga_SelectAll", "", -1);
            

            butBuscar.Visible = false;

            //Llama al metodo base recuperarObjetoPorCodigo para habilitar la edición.
            this.recuperarObjetoPorCodigo("1");

            this.agregarHabilitado = false;
            this.eliminarHabilitado = false;
        }


        //Carga el Navegador de Formularios
        protected override void cargarNavegadorFormulario()
        {
            try
            {
                base.cargarNavegadorFormulario();

                //Carga las teclas rapidas primero
                //navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butBuscar, (char)Keys.F1));

                //Carga los controles
                navegador.agregarControl(new CapsulaControl((Control)tbCategoriaInicial));
                navegador.agregarControl(new CapsulaControl((Control)tb9Categoria));
                navegador.agregarControl(new CapsulaControl((Control)dtpDesde));
                navegador.agregarControl(new CapsulaControl((Control)dtpHasta));
                navegador.agregarControl(new CapsulaControl((Control)chklbLigas));

                //Agrega los handlers para todos los controles del control contenedor
                navegador.agregarHandlersContenedor(this);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        protected override void mostrarDatosObjeto()
        {
            base.mostrarDatosObjeto();
            try
            {
                rglEntidad = (ParametrosPlacas)base.rglEntidad;
                tbId.Text = rglEntidad.id.ToString();
                tbCodigo.Text = rglEntidad.codigo;
                tbCategoriaInicial.Text = rglEntidad.categoriaInicial.ToString();
                tb9Categoria.Text = rglEntidad.novenaCategoria.ToString();
                //tbUltimoAnio.Text = rglEntidad.ultimoAnio.ToString();
                dtpDesde.Value = DateTime.Parse(rglEntidad.ultimoPeriodoDesde.ToString());
                dtpHasta.Value = DateTime.Parse(rglEntidad.ultimoPeriodoHasta.ToString());
                String[] ligasIDs = rglEntidad.ligasIDs.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                
                //Recorre la lista y marca los registros en base a los IDs.
                DataTable dtLigas = (DataTable)chklbLigas.DataSource;

                DataRow row;
                foreach (String ligaID in ligasIDs) {
                    row = dtLigas.Rows.Find(new Guid(ligaID));
                    int indice = dtLigas.Rows.IndexOf(row);
                    chklbLigas.SetItemChecked(indice, true);
                }
                
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override string validarDatosIngresados()
        {
            string resultado = "";

            try
            {
                if (tbCategoriaInicial.Text.Trim() == "" && tb9Categoria.Text.Trim() == "")
                    resultado += "\r\n\t- Debe ingresar Categoría inicial y la 9 Categoría.";
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }

        protected override void limpiarFormulario()
        {
            try
            {
                tbId.Text = Utilidades.ID_VACIO;
                tbCategoriaInicial.Text = "";
                tb9Categoria.Text = "";
                //tbUltimoAnio.Text = "";
                seleccionarTodoCheck(false);
                
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        protected override void cargarObjetoReglas()
        {
            try
            {
                inicializarEntidad();
                rglEntidad.id = new Guid(tbId.Text);
                rglEntidad.codigo = tbCodigo.Text;
                rglEntidad.categoriaInicial = tbCategoriaInicial.Text;
                rglEntidad.novenaCategoria = tb9Categoria.Text;
                rglEntidad.ultimoPeriodoDesde = dtpDesde.Value.Subtract(dtpDesde.Value.TimeOfDay);
                rglEntidad.ultimoPeriodoHasta = dtpHasta.Value.Subtract(dtpHasta.Value.TimeOfDay);
                //CARGAR LIGAS
                String separador = "";
                DataTable dt = (DataTable)chklbLigas.DataSource;
                for (int i = 0; i < chklbLigas.Items.Count; i++) { 
                    
                    if (chklbLigas.GetItemChecked(dt.Rows.IndexOf(dt.Rows[i])))
                        rglEntidad.ligasIDs += separador + dt.Rows[i]["id"].ToString();
 
                    separador = ":";
                }
               
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override string validarNegocio()
        {
            ParametrosPlacasFactory negEntidadFac = (ParametrosPlacasFactory)crearNegEntidadFac();
            string resultado = negEntidadFac.validar(rglEntidad, edicion);
            negEntidadFac = null;

            return resultado;
        }

        public override frmBaseBusqueda crearFormularioBusqueda()
        {
            frmBusqueda fb = new frmBusqueda(this.configuracion, this.EntidadNombre);
            fb.habilitarBusquedaAutomatica = false;
            return fb;
        }

        public override CapaNegocioBase.EntidadFactoryBase crearNegEntidadFac()
        {
            return new ParametrosPlacasFactory(this.configuracion, this.EntidadNombre);
        }

        public override Resultado alta()
        {
            Resultado resultado = new Resultado();

            try
            {
                ParametrosPlacasFactory negEntidadFac = (ParametrosPlacasFactory)crearNegEntidadFac();
                resultado = negEntidadFac.alta(rglEntidad);
                negEntidadFac = null;

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
                ParametrosPlacasFactory negEntidadFac = (ParametrosPlacasFactory)crearNegEntidadFac();
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
                ParametrosPlacasFactory negParametrosPlacasFac = new ParametrosPlacasFactory(this.configuracion, this.EntidadNombre);
                resultado = negParametrosPlacasFac.borrar(id);

                negParametrosPlacasFac = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

        
        protected override bool recuperarObjetoPorCodigo(string codigo)
        {
            bool encontro = false;
            try
            {
                encontro = base.recuperarObjetoPorCodigo(codigo);
                if (!encontro)
                {
                    MessageBox.Show("Debe generar un registro en la tabla ParametrosPlacas con el código 1.", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //agregar();
                }
                else
                {
                    butModificar_Click(butModificar, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return encontro;
        }

        protected override void focoEnOK()
        {
            butOk.Focus();
        }

        private void frmParametrosPlacas_Activated(object sender, EventArgs e)
        {
            this.inicializando = false;
        }

        private void chkSeleccionarTodas_CheckedChanged(object sender, EventArgs e)
        {
            seleccionarTodoCheck(chkSeleccionarTodas.Checked);
        }

        private void seleccionarTodoCheck(bool seleccionado) {

            for (int i = 0; i < chklbLigas.Items.Count; i++)
            {
                chklbLigas.SetItemChecked(i, seleccionado);
                Application.DoEvents();
            }

        }

        private void butAbrirArchivo_Click(object sender, EventArgs e)
        {
            DialogResult dl = openFileDialog1.ShowDialog();
            tbArchivo.Text = openFileDialog1.FileName;
        }

        private void butImportar_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("¿Desea comenzar la importación de registros del archivo " + openFileDialog1.FileName + "?", "Importación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)){
                lblProcesando.Text = "Aguarde un momento, procesando el archivo...";
                this.Cursor = Cursors.WaitCursor;
                butImportar.Enabled = false;

                importarArchivo(openFileDialog1.FileName);

                butImportar.Enabled = true;
                this.Cursor = Cursors.Default;
                lblProcesando.Text = "Archivo procesado.";
            }
        }

        public void importarArchivo(string excelfilepath)
        {
            //declare variables - edit these based on your particular situation
            string ssqltable = "tdatamigrationtable";
            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have different
            string myexceldataquery = "select JUGADOR, FECHA, CODIGO from [DATOS$]";

            String sql = "";
            String dni, fecha, hizoPlacaID;
            try
            {
                //create our connection strings
                string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + excelfilepath + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                SqlConnection sqlconn = new SqlConnection(this.configuracion.getConectionString());
                sqlconn.Open();

                SqlCommand sqlcmd;
                //sqlconn.Close();
                //series of commands to bulk copy data from the excel file into our sql table               
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                int registrosProcesados = 0;
                while (dr.Read())
                {
                    //Toma los datos del excel
                    dni = dr["JUGADOR"].ToString().Trim();
                    fecha = dr["FECHA"].ToString().Trim();
                    hizoPlacaID = dr["CODIGO"].ToString().Trim();
                    if (hizoPlacaID == "") hizoPlacaID = "2";

                    String[] aFecha = fecha.Split(" ".ToCharArray())[0].Split("/".ToCharArray());
                    String fechaCanonica = "{ts '" + aFecha[2] + "-" + aFecha[1] + "-" + aFecha[0] + " 00:00:00'}";

                    //Averigua si existe el registro
                    sqlcmd = new SqlCommand("SELECT Count(*) FROM PacienteFechaPlaca WHERE dni='" + dni + "'", sqlconn);
                    int existe = (int)sqlcmd.ExecuteScalar();

                    //Si no existe lo crea
                    if (existe == 0)
                    {
                        sql = "INSERT INTO PacienteFechaPlaca (dni, fechaUltimoExamen, hizoPlacaID) VALUES ('" + dni + "'," + fechaCanonica + ", " + hizoPlacaID + ")";
                    }
                    else //Si existe lo actualiza
                    {
                        sql = "UPDATE PacienteFechaPlaca SET fechaUltimoExamen=" + fechaCanonica + ", hizoPlacaID=" + hizoPlacaID + " WHERE dni='" + dni + "'";
                    }
                    sqlcmd = new SqlCommand(sql, sqlconn);
                    sqlcmd.ExecuteNonQuery();
                    //Console.WriteLine(sql);
                    registrosProcesados++;
                    lbRegistrosProcesados.Text = "Registros procesados: " + registrosProcesados;
                    Application.DoEvents();
                }
             
                oledbconn.Close();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(sql);
                MessageBox.Show(ex.Message + "\n\n" + sql);
            }
        }

    }
}