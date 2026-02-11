using System;//
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
using System.Net.Mail;
using System.Threading;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.IO;
using CapaNegocioMepryl;


namespace CapaPresentacion
{
    public partial class frmPaciente : CapaPresentacionBase.frmBaseEntidadABM
    {
        public Paciente rglEntidad;
        public string tipoConsulta = "";
        public string comboSeleccionado;
        public frmMesaDeEntrada form;
        public frmTurno formTurno;
        public frmRecepcion formRecepcion;
        DataTable valoresExamen; // GRV - Modificado
        DataTable valor;  // GRV - Modificado
        DataRow[] filtroTabla; // GRV - Modificado
        DataTable cacheDgv = new DataTable(); // GRV - Modificado
        private CapaNegocioMepryl.UtilidadesMepryl UtilMepryl = new CapaNegocioMepryl.UtilidadesMepryl(); // GRV - Modificado
        
        int nroFila = -1;
        int puntero = -1;
        int celda = -1;
        int modo = 0;
        Color color;
        public CapaNegocioMepryl.ExamenPreventiva preventiva;
        private CapaNegocioMepryl.UbicacionFotos DirectorioFotos;
        // GRV - Modificado
        private CapaNegocioMepryl.PacientePreventiva PacientePre;
        private bool blnPresionarQuitar = false;
        

        public frmPaciente()
        {
            InitializeComponent();
            //UtilMepryl = new CapaNegocioMepryl.UtilidadesMepryl();
            tabPrincipal.TabPages.Remove(tabPage2);
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
            txtMail.CharacterCasing = CharacterCasing.Lower;           
        }

        public frmPaciente(Configuracion config, bool mostrarBotonOk)
            : base(config, mostrarBotonOk)
        {
            EntidadNombre = "Paciente";
            //tabPrincipal.TabPages.Remove(tabPage2);  //GRV - Modificado
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
        }

        public frmPaciente(frmMesaDeEntrada frm, Configuracion config, bool mostrarBotonOk, string dni, int mod)
            : base(config, mostrarBotonOk)
        {
            EntidadNombre = "Paciente";
            this.tbCodigo.Text = dni;
            modo = mod;
            form = frm;
            //tabPrincipal.TabPages.Remove(tabPage2); //GRV - Modificado
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
        }

        public frmPaciente(frmTurno frm, Configuracion config, bool mostrarBotonOk, string dni, int mod)
            : base(config, mostrarBotonOk)
        {
            EntidadNombre = "Paciente";
            this.tbCodigo.Text = dni;
            modo = mod;
            formTurno = frm;
            //tabPrincipal.TabPages.Remove(tabPage2); // GRV - Modificado
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
        }

        public frmPaciente(frmRecepcion frm, int mod,Configuracion config, bool mostrarBotonOk)
            : base(config, mostrarBotonOk)
        {
            EntidadNombre = "Paciente";
            formRecepcion = frm;
            modo = mod;
            //tabPrincipal.TabPages.Remove(tabPage2); // GRV - Modificado
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
        }

        public frmPaciente(frmRecepcion frm, int mod, Configuracion config, bool mostrarBotonOk, string dni)
            : base(config, mostrarBotonOk)
        {
            EntidadNombre = "Paciente";
            formRecepcion = frm;
            modo = mod;
            tbCodigo.Text = dni;
            //tabPrincipal.TabPages.Remove(tabPage2); // GRV - Modificado
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
        }

        public frmPaciente(Configuracion config) : base(config)
        {
            EntidadNombre = "Paciente";
            //tabPrincipal.TabPages.Remove(tabPage2);  // GRV - Modificado
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
        }

        //Implementacion
        protected override void inicializarEntidad()
        {          
            rglEntidad = new Paciente();
            //inicializarTabla();
        }

        //
        //Para redefinir en cada formulario
        //
        protected override void modoEstatico(bool hayObjetoActivo)
        {
            base.modoEstatico(hayObjetoActivo);
            habilitarControles(ref gbDatosPersonales, false);
            dgvExamenes.Enabled = false;
            botonCambiarClub.Enabled = false;
            botMail.Enabled = false;
            botImprimir.Enabled = false;
            btnUbicar.Enabled = false;            
        }

        public void mostarDatosDni(string dni)
        {
            tbCodigo.Text = dni;
            tbCodigo.Focus();
            SendKeys.Send("{ENTER}");
        }

        public void mostrarDatosPorId(Guid idPaciente)
        {
            base.recuperarObjetoPorId(idPaciente.ToString());
        }


        protected override void modoEditable()
        {
            base.modoEditable();
            habilitarControles(ref gbDatosPersonales, true);
            dgvExamenes.Enabled = true;
            botonCambiarClub.Enabled = true;
            botMail.Enabled = true;
            botImprimir.Enabled = true;
            btnUbicar.Enabled = true;
            
            this.Focus();

            if (this.edicion == ModoEdicion.MODIFICANDO)
            {
                if (gbPreventiva.Visible)
                {
                    cboLiga.Focus();
                }
                else if (gbLaboral.Visible)
                {
                    tbBuscarEmpresa.Focus();
                }
                else
                    tbApellido.Focus();
            }
            else
                tbApellido.Focus();

            seleccionarTipoConsulta();

            //Si está dando de alta, selecciona el tipo de paciente por defecto segun el tipo de consulta
            if (this.edicion == ModoEdicion.AGREGANDO)
            {
                llenarDgvEmpresa();
                tbDNI.Text = tbCodigo.Text;
                switch (this.tipoConsulta)
	            {
                    case "P":
                        rbPreventiva.Checked = true;

                    
                        break;
                    case "L":
                        rbLaboral.Checked = true;
                        break;
                    case "CO":
                    case "R":
                    case "CL":
                        {
                            rbPreventiva.Checked = false;
                            gbPreventiva.Visible = false;
                            rbLaboral.Checked = false;
                            gbLaboral.Visible = false;
                            break;
                        }
	            }
                tbApellido.Focus();
            }
        }

        protected override void inicializarComponentes()
        {
            InitializeComponent();
            base.inicializarComponentes();
            PacientePre = new CapaNegocioMepryl.PacientePreventiva();
            this.StartPosition = FormStartPosition.CenterScreen;

            //Aquí llenar el combo del club
            // GRV - Llenar ligas activas
            //Utilidades.llenarCombo(ref cboLiga, this.configuracion.getConectionString(), "sp_Liga_SelectAll", "", -1);            
            cboLiga.DataSource = PacientePre.ListarLigaActiva();
            cboLiga.ValueMember = "id";
            cboLiga.DisplayMember = "descripcion";
            cboLiga.SelectedIndex = 0;
                
            //Aqui se llena el combo de la empresa

            inicializarEntidad();
            seleccionarTipoConsulta();
            llenarDgvEmpresa();
            llenarCboLocalidad();
            llenarCboNacionalidad();
            //tabPage1.Text = "Datos &Personales";
            //tabPage2.Text = "Exa&menes";
        }

        private void llenarDgvEmpresa()
        {
            DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString(@"select e.id, e.razonSocial as Empresa from dbo.Empresa e
            order by e.razonSocial");
            DataTable empresas = new DataTable();
            empresas.Columns.Add("Id");
            empresas.Columns.Add("Empresa");
            empresas.Rows.Add(Guid.Empty, "A DESIGNAR");
            foreach (DataRow r in tabla.Rows)
            {
                empresas.Rows.Add(r.ItemArray[0], r.ItemArray[1]);
            }
            dgvEmpresa.DataSource = empresas;
            dgvEmpresa.Columns[0].Visible = false;
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
                navegador.agregarControl(new CapsulaControl((Control)tbApellido));
                navegador.agregarControl(new CapsulaControl((Control)tbNombres));
                navegador.agregarControl(new CapsulaControl((Control)dtpFechaNacimiento));
                //navegador.agregarControl(new CapsulaControl((Control)cboLiga));
                navegador.agregarControl(new CapsulaControl((Control)tbBuscarClub));
             //   navegador.agregarControl(new CapsulaControl((Control)lbxClub));
                navegador.agregarControl(new CapsulaControl((Control)dgvEmpresa));
                navegador.agregarControl(new CapsulaControl((Control)tbEmpresaTarea));
                navegador.agregarControl(new CapsulaControl((Control)tbTelefonos));
                navegador.agregarControl(new CapsulaControl((Control)tbCelular));
                navegador.agregarControl(new CapsulaControl((Control)tbObservaciones));
                navegador.agregarControl(new CapsulaControl((Control)tbDNI));
                navegador.agregarControl(new CapsulaControl((Control)dgvClubesAsignados));
                navegador.agregarControl(new CapsulaControl((Control)dgvExamenes));
                navegador.agregarControl(new CapsulaControl((Control)tbDNIExamen));
                navegador.agregarControl(new CapsulaControl((Control)tbNombreExamen));
                navegador.agregarControl(new CapsulaControl((Control)tbApellidoExamen));
                navegador.agregarControl(new CapsulaControl((Control)tbNacimientoExamen));
                navegador.agregarControl(new CapsulaControl((Control)tbCategoriaExamen));
                navegador.agregarControl(new CapsulaControl((Control)tbDireccion));
                navegador.agregarControl(new CapsulaControl((Control)cboLocalidad));
                navegador.agregarControl(new CapsulaControl((Control)cboNacionalidad));
           
                //
              
                //Agrega los handlers para todos los controles del control contenedor
                navegador.agregarHandlersContenedor(this);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void llenarCboLocalidad()
        {
            cboLocalidad.DataSource = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.Prestaciones
            where tiPres = 'V' order by pres");
            cboLocalidad.ValueMember = "id";
            cboLocalidad.DisplayMember = "pres";
            cboLocalidad.SelectedIndex = 0;
        }

        private void llenarCboNacionalidad()
        {
            cboNacionalidad.DataSource = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.Nacionalidad
            order by codigo");
            cboNacionalidad.ValueMember = "id";
            cboNacionalidad.DisplayMember = "descripcion";
            cboNacionalidad.SelectedIndex = 0;
        }

    
        protected override void mostrarDatosObjeto()
        {
            int intAnioCatInicial = 0; // GRV - Modificado
           
            base.mostrarDatosObjeto();
            try
            {
                llenarDgvEmpresa();
                tbBuscarEmpresa.Text = "";
                dgvClubesAsignados.Rows.Clear();
                dgvClub.DataSource = null;
                cboLiga.SelectedIndex = 0;
                rglEntidad = (Paciente)base.rglEntidad;
                tbApellido.Text = rglEntidad.apellido.ToString();
                tbNombres.Text = rglEntidad.nombres.ToString();
                tbDNI.Text = rglEntidad.dni.ToString();
                dtpFechaNacimiento.Text = rglEntidad.fechaNacimiento.ToString();

                txtEdad.Text = (DateTime.Today.AddTicks(-rglEntidad.fechaNacimiento.Ticks).Year - 1).ToString();

                DateTime fechaCategoria = DateTime.Parse(rglEntidad.fechaNacimiento.ToString());
                lblCategoria.Text = fechaCategoria.Year.ToString();
                // Utilidades.listBoxSeleccionarItemById(rglEntidad.clubID, ref lbxClub);
                obtenerEmpresaSeleccionada(rglEntidad.empresa.id.ToString());
                tbEmpresaTarea.Text = rglEntidad.empresaTarea.ToString();
                tbTelefonos.Text = rglEntidad.telefonos.ToString();
                tbCelular.Text = rglEntidad.celular.ToString();
                tbObservaciones.Text = rglEntidad.observaciones.ToString();
                txtMail.Text = PacientePre.VerMail(tbDNI.Text);
                cargarClubesQueJuega();
                tbDNIExamen.Text = rglEntidad.dni.ToString();
                tbApellidoExamen.Text = rglEntidad.apellido.ToString();
                tbNombreExamen.Text = rglEntidad.nombres.ToString();
                tbNacimientoExamen.Text = fechaCategoria.ToShortDateString();
                tbCategoriaExamen.Text = fechaCategoria.Year.ToString();
                if (rglEntidad.nacionalidad != Guid.Empty)
                {
                    cboNacionalidad.SelectedValue = rglEntidad.nacionalidad;
                }
                if (rglEntidad.localidad != Guid.Empty)
                {
                    cboLocalidad.SelectedValue = rglEntidad.localidad;
                }
                tbDireccion.Text = rglEntidad.direccion;
      

                bool hacerPlaca = false;
                lbTienePlaca.Text = "";

                //Toma los parametros para el criterio de evaluacion
                ParametrosPlacasFactory ppf = new ParametrosPlacasFactory(this.configuracion, "ParametrosPlacas");
                ParametrosPlacas pp = (ParametrosPlacas)ppf.getByCodigo("1");

                //Lee los datos auxiliares del paciente
                SqlConnection con = new SqlConnection(this.configuracion.getConectionString());
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM PacienteFechaPlaca WHERE dni='" + rglEntidad.dni + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                //Criterio 1: Continúa la evaluación si hay registro, sino directamente tiene que hacer placa
                if (!dr.HasRows)
                    hacerPlaca = true;
                else
                {
                    dr.Read();
                    //Lee los datos complementarios del paciente
                    rglEntidad.fechaUltimoExamen = DateTime.Parse(dr["fechaUltimoExamen"].ToString());
                    String auxFechaUltimoExamen = dr["fechaUltimoExamen"].ToString();
                    String auxHizoPlaca = dr["hizoPlacaID"].ToString();
                    //String auxAñoUltimoExamen = auxFechaUltimoExamen.Split(" ".ToCharArray())[0].Split("/".ToCharArray())[2];


                    //int añoUltimoExamen = int.Parse(auxAñoUltimoExamen);
                    //Criterio 2: si no hizo placa en el año indicado en los parámetros
                    //Criterio 3: si se examino el ultimo año pero no hizo placa
                    //if ((añoUltimoExamen < parAño) || (añoUltimoExamen >= parAño && auxHizoPlaca != "1"))

                    //GRV - Modificado - Verifica si hace placa o no
                    if (!(rglEntidad.fechaUltimoExamen >= pp.ultimoPeriodoDesde) ||
                        ((rglEntidad.fechaUltimoExamen >= pp.ultimoPeriodoDesde) && auxHizoPlaca != "1"))
                        hacerPlaca = true;
                    else
                    {
                        int categoriaPaciente = rglEntidad.fechaNacimiento.Year;
                        bool ligaOk = true;


                        //Citerio 4: si pertenece a las categorias marcadas y a las ligas marcadas
                        if ((categoriaPaciente == int.Parse(pp.categoriaInicial) || categoriaPaciente == int.Parse(pp.novenaCategoria)) && ligaOk)
                            hacerPlaca = true;
                    }
                    
                    //----------
                    dr.Close();
                }                
                
                cmd.Dispose();
                con.Close();

                // GRV - Modificado - Verifica si hace placa o no
                //hacerPlaca = PacientePre.DebeRealizarExamenRX(tbDNI.Text);
                cargarImagen();
                hacerPlaca = DebeExamenRX();

                for (int i = 0; i < dgvClubesAsignados.Rows.Count; i++)
                {
                    if (PacientePre.ClubPerteneceAFA(dgvClubesAsignados.Rows[i].Cells[1].Value.ToString()))
                    {
                        intAnioCatInicial = PacientePre.AnioCategoriaInfantil(dgvClubesAsignados.Rows[i].Cells[1].Value.ToString());
                        break;
                    }
                    else
                    {
                        intAnioCatInicial = PacientePre.AnioCategoriaInfantil(dgvClubesAsignados.Rows[i].Cells[1].Value.ToString());
                    }
                }
                //intAnioCatInicial = PacientePre.AnioCategoriaInfantil(dgvClubesAsignados.Rows[0].Cells[1].Value.ToString());

                if (intAnioCatInicial == int.Parse(lblCategoria.Text))
                    hacerPlaca = true;

                if (DateTime.Today.Year == PacientePre.FechaExamenEsteAnio(rglEntidad.dni.ToString()).Year)
                    hacerPlaca = false;

                if (PacientePre.ObtenerCodigoTipoExamen(rglEntidad.dni.ToString()) == 266)
                    hacerPlaca = true;

                //hacerPlaca = DebeExamenRXParaNuevoClubIngresado();
                
                // GRV - Modificado                
                //if (hacerPlaca)
                //{
                //    lbTienePlaca.ForeColor = Color.LimeGreen;
                //    lbTienePlaca.Text = "DEBE REALIZAR RX.";
                //}
                //else
                //{
                //    lbTienePlaca.ForeColor = Color.Red;
                //    lbTienePlaca.Text = "NO DEBE REALIZAR RX.";
                //}
                MostrarMensaje(hacerPlaca);
                // GRV

                if (!PacientePre.LigaEstaActiva(dgvClubesAsignados.Rows[0].Cells[1].Value.ToString()))
                    lbTienePlaca.Text = "";

                // GRV - Modificado - Muestra fecha último examen
                //if (rglEntidad.fechaUltimoExamen.ToString().Substring(0, 10) != "01/01/0001")
                if (PacientePre.FechaUltimoExamen(rglEntidad.dni.ToString()).ToString().Substring(0, 10) != "01/01/0001")
                {
                    //tbFechaUltimoExamen.Text = rglEntidad.fechaUltimoExamen.ToString();
                    tbFechaUltimoExamen.Text = PacientePre.FechaUltimoExamen(rglEntidad.dni.ToString()).ToString();
                    lbFechaUltimoExamen.Visible = true;
                    tbFechaUltimoExamen.Visible = true;
                }
                else
                {
                    //tbFechaUltimoExamen.Text = "No examinado en el último año.";
                    lbFechaUltimoExamen.Visible = false;
                    tbFechaUltimoExamen.Visible = false;
                }

                if (!PacientePre.LigaEstaActiva(dgvClubesAsignados.Rows[0].Cells[1].Value.ToString()))
                    tbFechaUltimoExamen.Text = "";                

                cargarExamenes();

                //if (lbTienePlaca.Text != "NO DEBE REALIZAR RX.")
                //    MessageBox.Show(lbTienePlaca.Text, "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (preventiva.estaInhabilitadoDni(tbDNI.Text))
                {
                    MessageBox.Show("¡El número de dni se encuentra inhabilitado! Por favor verifique", "Jugador Inhabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void MostrarMensaje(bool blnMostrar)
        {
            if (blnMostrar)
            {
                lbTienePlaca.ForeColor = Color.LimeGreen;
                lbTienePlaca.Text = "DEBE REALIZAR RX.";
            }
            else
            {
                lbTienePlaca.ForeColor = Color.Red;
                lbTienePlaca.Text = "NO DEBE REALIZAR RX.";
            }

            if (!PacientePre.VerificaRX(dgvClubesAsignados.Rows[0].Cells[1].Value.ToString()))
                lbTienePlaca.Text = "";
        }

        private void obtenerEmpresaSeleccionada(string id)
        {
            foreach (DataGridViewRow r in dgvEmpresa.Rows)
            {
                if (r.Cells[0].Value.ToString() == id)
                {
                    dgvEmpresa.CurrentCell = r.Cells[1];
                }
            }
        }

        protected override bool estaInhabilitadoDni()
        {
            return preventiva.estaInhabilitadoDni(tbDNI.Text);
        }

        public void cargarExamenes()
        {
            
            //if (puntero != -1) { dictamenFinalAutomatico(puntero); }
            if (dgvExamenes.Rows.Count > 0) { dgvExamenes.Rows.Clear(); }
            dgvExamenes.Columns[7].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[9].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[11].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[13].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[18].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[20].DefaultCellStyle.NullValue = null;
            dgvExamenes.Columns[22].DefaultCellStyle.NullValue = null;

            DataTable tipoDeExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select tep.id as IdTE, c.id as IdC, 
            CONVERT(date, c.fecha) as Fecha, c.identificador as 'Nº Examen',
            tep.rm as RM, tep.imp as IMP,
            tep.ImpLab,tep.mail as Mail, tep.inf from dbo.TipoExamenDePaciente tep 
            inner join dbo.Consulta c on tep.idConsulta = c.id inner join dbo.Paciente p on c.pacienteID = p.id
            where c.tipo = 'P' and CONVERT(varchar,p.dni) LIKE '%" + tbCodigo.Text + "%' order by c.fecha asc");
            //where c.tipo = 'P' and p.id = '" + rglEntidad.id.ToString() + "' order by c.fecha asc");

            

            foreach (DataRow row in tipoDeExamen.Rows)
            {
                // GRV - Modificado
                valoresExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select dictClinico, dictLab, dictRx, dictCar, dictFinal from dbo.ExamenPreventiva where
                      idTipoExamen = '" + row.ItemArray[0].ToString() + "'");
                DataTable clasif = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Clasificaciones");
                DataTable validaciones = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Validaciones");
                string liga = "";
                string club = "";
                DataTable ligaYClubes = SQLConnector.obtenerTablaSegunConsultaString(@"
            select l.descripcion, c.descripcion from dbo.clubesPorTipoExamen cte inner join dbo.Club c on cte.idClub = c.id
            inner join dbo.Liga l on c.ligaID = l.id
            where cte.idTipoExamen = '" + row.ItemArray[0].ToString() + "'");
                valor = SQLConnector.obtenerTablaSegunConsultaString(@"select v.id as Id, v.descripcion as Descrip, c.codigo as Cod
                from dbo.Validaciones v 
                inner join dbo.Clasificaciones c on v.idClasif = c.id");

                foreach (DataRow r in ligaYClubes.Rows)
                {
                    if (liga == "") { liga = r.ItemArray[0].ToString(); club = r.ItemArray[1].ToString(); }
                    else { liga = liga + "/" + r.ItemArray[0].ToString(); club = club + "/" + r.ItemArray[1].ToString(); }
                }
                bool rm = false;
                if (row.ItemArray[4].ToString() == "1")
                {
                    rm = true;
                }
                bool retirado = false;
                if (row.ItemArray[8].ToString() == "1")
                {
                    retirado = true;
                }
                string idTe = row.ItemArray[0].ToString();
                string idC = row.ItemArray[1].ToString();
                string fecha = ((DateTime)row.ItemArray[2]).ToShortDateString();
                string nroEx = row.ItemArray[3].ToString();
                string impEx = row.ItemArray[5].ToString();
                string impLab = row.ItemArray[6].ToString();
                string mail = row.ItemArray[7].ToString();
                if (impEx == "") { impEx = "0"; }
                if (impLab == "") { impLab = "0"; }
                if (mail == "") { mail = "0"; }

                if (valoresExamen.Rows.Count > 0)
                {
                    // GRV - Modificado
                    //string fisico = filtrarValores(validaciones, "22", valoresExamen);
                    //string lab = filtrarValores(validaciones, "60", valoresExamen);
                    //string rx = filtrarValores(validaciones, "72", valoresExamen);
                    //string car = filtrarValores(validaciones, "81", valoresExamen);
                    //string final = filtrarValores(validaciones, "80", valoresExamen);
                    string fisico = filtrarValores(validaciones, 0);
                    string lab = filtrarValores(validaciones, 1);
                    string rx = filtrarValores(validaciones, 2);
                    string car = filtrarValores(validaciones, 3);
                    string final = cargarDictamenFinal(row, fisico, lab, rx, car, nroEx);
                    //string valorFinal = cargarDictamenFinal("90", fisico, lab, rx, car, valoresExamen);
                    string valorFinal = consultarIdValidacion(4);

                    Image imgFisico = setearImagenSegunValor(fisico, clasif);
                    Image imgLab = setearImagenSegunValor(lab, clasif);
                    Image imgRX = setearImagenSegunValor(rx, clasif);
                    Image imgCar = setearImagenSegunValor(car, clasif);
                    Image imgImpEx = setearImagen(clasif, impEx);
                    Image imgMail = setearImagen(clasif, mail);
                    Image imgImpLab = setearImagen(clasif, impLab);

                    agregarFilaAlDgv(idTe, idC, fecha, nroEx, liga, club, fisico, imgFisico, lab, imgLab,
                    rx, imgRX, car, imgCar, valorFinal, final, rm, impEx, imgImpEx, impLab, imgImpLab,
                    mail, imgMail, retirado);

                }
                else
                {
                agregarFilaAlDgv(idTe, idC, fecha, nroEx,
                liga, club, "0", setearImagen(clasif, "0"), "0", setearImagen(clasif, "0"),
                "0", setearImagen(clasif, "0"), "0", setearImagen(clasif, "0"), "0", "NO CARGADO",
                rm, "0", setearImagen(clasif, "0"), "0", setearImagen(clasif, "0"), "0", setearImagen(clasif, "0"), retirado);
                color = Color.WhiteSmoke;
                }
                dgvExamenes.Rows[dgvExamenes.Rows.Count - 1].Cells[15].Style.BackColor = color;
           

            }

            
            //filtroTabla = cacheDgv.Select(obtenerFiltroString());
            
            if (dgvExamenes.Rows.Count > 0 && puntero != -1) { dgvExamenes.CurrentCell = dgvExamenes.Rows[puntero].Cells[celda]; }
            if (dgvExamenes.Rows.Count > 0 && puntero == -1) { dgvExamenes.CurrentCell = dgvExamenes.Rows[0].Cells[2]; }

            dgvExamenes.ScrollBars = ScrollBars.Both;
        }

        private void inicializarTabla() {
            cacheDgv = new DataTable();
            cacheDgv.Columns.Add("idTe");
            cacheDgv.Columns.Add("idC");
            cacheDgv.Columns.Add("Fecha");
            cacheDgv.Columns.Add("nroEx");
            cacheDgv.Columns.Add("Liga");
            cacheDgv.Columns.Add("Club");
            cacheDgv.Columns.Add("fisico");
            cacheDgv.Columns.Add("imgFisico");
            cacheDgv.Columns.Add("lab");
            cacheDgv.Columns.Add("imgLab");
            cacheDgv.Columns.Add("rx");
            cacheDgv.Columns.Add("imgRX");
            cacheDgv.Columns.Add("car");
            cacheDgv.Columns.Add("imgCar");
            cacheDgv.Columns.Add("valorFinal");            
            cacheDgv.Columns.Add("final");
            cacheDgv.Columns.Add("rm");            
            cacheDgv.Columns.Add("impEx");
            cacheDgv.Columns.Add("imgImpEx");
            cacheDgv.Columns.Add("impLab");
            cacheDgv.Columns.Add("imgImpLab");
            cacheDgv.Columns.Add("mail");
            cacheDgv.Columns.Add("imgMail");
            cacheDgv.Columns.Add("retirado");
            //cacheDgv.Columns[2].DataType = System.Type.GetType("System.Date");
            //cacheDgv.Columns[7].DataType = System.Type.GetType("System.Drawing.Bitmap");
            //cacheDgv.Columns[9].DataType = System.Type.GetType("System.Drawing.Bitmap");
            //cacheDgv.Columns[11].DataType = System.Type.GetType("System.Drawing.Bitmap");
            //cacheDgv.Columns[13].DataType = System.Type.GetType("System.Drawing.Bitmap");
            //cacheDgv.Columns[18].DataType = System.Type.GetType("System.Drawing.Bitmap");
            //cacheDgv.Columns[20].DataType = System.Type.GetType("System.Drawing.Bitmap");
            //cacheDgv.Columns[22].DataType = System.Type.GetType("System.Byte[]");            
            //cacheDgv.Columns[28].DataType = typeof(System.Drawing.Color);
            //cargarExamenes(DateTime.Today, DateTime.Today);
        }

        private string obtenerFiltroString()
        {
            string cadena = "";
            //if (cboL.SelectedIndex != 0) { cadena = "Liga LIKE '%" + cboL.SelectedValue.ToString() + "%'"; }
            //if (cboC.SelectedIndex != 0) { if (cadena == "") { cadena = "Club like '%" + cboC.SelectedValue.ToString() + "%'"; } else { cadena = cadena + " and Club like '%" + cboC.SelectedValue.ToString() + "%'"; } }
            //if (cboD.SelectedIndex != 0) { if (cadena == "") { cadena = "DICF = '" + cboD.SelectedValue.ToString() + "'"; } else { cadena = cadena + " and DICF = '" + cboD.SelectedValue.ToString() + "'"; } }
            return cadena;

        }

        private string cargarDictamenFinal(DataRow tipoExamen, string fis, string lab,
            string rx, string car, string nroEx)
        {

            if (valoresExamen.Rows.Count > 0 && valoresExamen.Rows[0].ItemArray[4].ToString() != "")
            {
                string idValidacion;
                idValidacion = valoresExamen.Rows[0].ItemArray[4].ToString();

                DataRow[] r = valor.Select("Id = " + idValidacion);


                switch (Convert.ToInt16(r[0][2].ToString()))
                {
                    case 1:
                        color = Color.DarkSeaGreen;
                        break;
                    case 2:
                        color = Color.Khaki;
                        break;
                    case 3:
                        color = Color.IndianRed;
                        break;
                    case 4:
                        color = Color.LightBlue; ;
                        break;
                    case 5:
                        color = Color.PeachPuff;
                        break;
                }
                return r[0][1].ToString();
            }
            if (Convert.ToInt16(nroEx) >= 200) { color = Color.White; } else { color = Color.Gainsboro; }
            return "NO CARGADO";

        }

        private string consultarIdValidacion(int posicion)
        {
            if (valoresExamen.Rows.Count > 0 && valoresExamen.Rows[0][posicion].ToString() != "")
            {
                return valoresExamen.Rows[0].ItemArray[posicion].ToString();

            }
            return "0";
        }

        private void agregarFilaAlDgv(object idE, object idC, object fecha, object numeroEx, object liga, object club,
                object txtCLI, object CLI, object txtLAB, object LAB, object txtRX, object RX, object txtCAR, object CAR,
                object txtDIC, object DIC, object RM, object txtIMP, object IMP, object txtIMPLAB, object IMPLAB, object txtMAIL,
                object MAIL, object retirado)
        {
            dgvExamenes.Rows.Add(idE, idC, fecha, numeroEx, liga, club, txtCLI, CLI, txtLAB, LAB, txtRX, RX, txtCAR, CAR,
                txtDIC, DIC, RM, txtIMP, IMP, txtIMPLAB, IMPLAB, txtMAIL, MAIL, retirado);

            //cacheDgv.Rows.Add(idE, idC, fecha, numeroEx, liga, club, txtCLI, CLI, txtLAB, LAB, txtRX, RX, txtCAR, CAR,
            //    txtDIC, DIC, RM, txtIMP, IMP, txtIMPLAB, IMPLAB, txtMAIL, MAIL, retirado);
        }

        private string cargarDictamenFinal(string codigo, string fis, string lab, string rx, string car, DataTable valoresExamen)
        {

            if (fis != "0" || lab != "0" || car != "0" || rx != "0")
            {
                string idValidacion;

                DataRow[] rows = valoresExamen.Select("codigo = " + codigo);
                if (rows.Length > 0)
                {
                    idValidacion = rows[0].ItemArray[3].ToString();
                    DataTable valor = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.Validaciones v 
                inner join dbo.Clasificaciones c on v.idClasif = c.id where 
                v.id = " + idValidacion);

                    if (valor.Rows[0].ItemArray[8].ToString() == "1") { color = Color.DarkSeaGreen; }
                    else if (valor.Rows[0].ItemArray[8].ToString() == "2") { color = Color.Khaki; }
                    else if (valor.Rows[0].ItemArray[8].ToString() == "3") { color = Color.IndianRed; }
                    else if (valor.Rows[0].ItemArray[8].ToString() == "4") { color = Color.LightBlue; }
                    else if (valor.Rows[0].ItemArray[8].ToString() == "5") { color = Color.PeachPuff; }
                    return valor.Rows[0].ItemArray[3].ToString();
                }
            }
            color = Color.White;
            return "NO CARGADO";
        }

        private Image setearImagenSegunValor(string valor, DataTable clasificaciones)
        {
            if (valor != "0") { return setearImagen(clasificaciones, valor); } else { return setearImagen(clasificaciones, "0"); }
        }

        private Image setearImagen(DataTable clasificaciones, string codigo)
        {
            if (codigo != "0")
            {
                DataRow[] row = clasificaciones.Select("id = " + codigo);
                System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])row[0].ItemArray[3]);
                return Image.FromStream(ms);
            }
            return null;
        }

        //private string filtrarValores(DataTable validaciones,string codigo, DataTable valoresExamen)
        //{
        //    string idValid = "";
        //    DataRow[] rows = valoresExamen.Select("codigo = '" + codigo + "'");
        //    if (rows.Length > 0) { idValid = rows[0][3].ToString(); } else { idValid = "0"; }
        //    if (idValid != "0")
        //    {
        //        DataRow[] valid = validaciones.Select("id = " + idValid);
        //        return valid[0][6].ToString();
        //    }
        //    else
        //    {
        //        return "0";
        //    }
        //}
        private string filtrarValores(DataTable validaciones, int posicion)
        {
            if (valoresExamen.Rows.Count > 0 && valoresExamen.Rows[0][posicion].ToString() != "")
            {

                DataRow[] valid = validaciones.Select("id = " + valoresExamen.Rows[0][posicion].ToString());
                return valid[0][6].ToString();
            }
            return "0";
        }

        public override string validarDatosIngresados()
        {   
            string strPerCategoria = "";
            string resultado = "";

            try
            {
                if (tbApellido.Text.Trim() == "" && tbNombres.Text.Trim() == "")
                    resultado += "\r\n\t- Debe ingresar Apellido y Nombres.";

                /*if (tbDNI.Text.Trim() == "")
                    resultado += "\r\n\t- Debe ingresar el DNI.";
                */
                DateTime d;
                if (!DateTime.TryParse(dtpFechaNacimiento.Text, out d))
                    resultado += "\r\n\t- La Fecha de Nacimiento no es válida.";

                if (!rbPreventiva.Checked && !rbLaboral.Checked)
                    resultado += "\r\n\t- Debe seleccionar un tipo de paciente (Preventiva o Laboral).";

                //GRV - Modificado - Verifica que el paciente pertenesca al menos a un club

                if (dgvClubesAsignados.Rows.Count <= 0)
                    resultado += "\r\n\t- El paciente no tiene un club asociado.";
                else
                {
                    strPerCategoria = VerificaPerteneceCategoria();
                    if (!string.IsNullOrEmpty(strPerCategoria))
                        resultado += "\r\n\t- " + strPerCategoria;

                    strPerCategoria = VerificaAceptaMenores();
                    if (!string.IsNullOrEmpty(strPerCategoria))
                        resultado += "\r\n\t- " + strPerCategoria;
                }
                
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
                tbApellido.Text = "";
                tbNombres.Text = "";
                tbDNI.Text = "";
                lblCategoria.Text = "";
                tbTelefonos.Text = "";
                tbCelular.Text = "";
                tbObservaciones.Text = "";
                dtpFechaNacimiento.Text = "";
                txtEdad.Text = "";
                tbEmpresaTarea.Text = "";
                tbFechaUltimoExamen.Text = "";
                dgvClubesAsignados.Rows.Clear();
                dgvClubesAsignados.DataSource = null;
                cboLiga.SelectedIndex = 0;
                if (dgvExamenes.Rows.Count > 0) { dgvExamenes.Rows.Clear(); }
                tbDNIExamen.Text = "";
                tbNombreExamen.Text = "";
                tbApellidoExamen.Text = "";
                tbCategoriaExamen.Text = "";
                tbNacimientoExamen.Text = "";
                tbBuscarEmpresa.Text = "";
                tbDireccion.Text = "";
                cboNacionalidad.SelectedIndex = 0;
                cboLocalidad.SelectedIndex = 0;
                dgvEmpresa.DataSource = null;
                lbTienePlaca.Text = ""; // GRV - Modifcado limpiar valor al cargar nuevo dni
                txtMail.Text = ""; // GRV - Modificado
                pictureBox1.Image = null;
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
                //MessageBox.Show(cboaNroSucursal.cboCombo.Text);
              //  inicializarEntidad();
                    if (dgvClub.Rows.Count > 0)
                    {
                        dgvClub.CurrentRow.Selected = false;
                    }
                    if (dgvClubesAsignados.Rows.Count > 0)
                    {
                        dgvClubesAsignados.CurrentRow.Selected = false;
                    }
                    dgvClub.DataSource = null;
                    cboLiga.SelectedIndex = 0;
                    rglEntidad.id = new Guid(tbId.Text);
                    rglEntidad.codigo = tbDNI.Text;
                    rglEntidad.apellido = tbApellido.Text.Trim();
                    rglEntidad.nombres = tbNombres.Text.Trim();
                    rglEntidad.dni = tbDNI.Text;
                    rglEntidad.fechaNacimiento = DateTime.Parse(dtpFechaNacimiento.Text);


                    string pacienteTipo = "PREVENTIVA";
                    if (rbPreventiva.Checked)
                    {
                        pacienteTipo = "PREVENTIVA";
                        List<string> l = SQLConnector.generarListaParaProcedure("@id");
                        SQLConnector.executeProcedure("sp_Paciente_DeleteClub", l, rglEntidad.id);

                        foreach (DataGridViewRow row in dgvClubesAsignados.Rows)
                        {
                            try
                            {
                                SqlParameter[] param = new SqlParameter[2];
                                param[0] = new SqlParameter("@idPaciente", rglEntidad.id);
                                param[1] = new SqlParameter("@idClub", row.Cells[3].Value);
                                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Paciente_AddClub", param);
                            }
                            catch (Exception ex)
                            {
                                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                    else if (rbLaboral.Checked)
                    {
                        pacienteTipo = "LABORAL";
                        rglEntidad.empresa.id = new Guid(dgvEmpresa.CurrentRow.Cells[0].Value.ToString());
                        rglEntidad.empresaTarea = tbEmpresaTarea.Text;
                        DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select tep.id 
                    from dbo.Consulta c 
                    inner join dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id
                    where CONVERT(date,c.fecha) = '" + DateTime.Today.ToShortDateString() + @"' and
                    c.pacienteID = '" + rglEntidad.id + "'");
                        if (consulta.Rows.Count > 0)
                        {
                            List<string> list = SQLConnector.generarListaParaProcedure("@idTipoExamen",
                                 "@idEmpresa", "@tarea");
                            DataTable empPorTe = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.empresaPorTipoDeExamen
                        where idTipoExamen = '" + consulta.Rows[0].ItemArray[0].ToString() + "'");
                            string procedure = "";
                            if (empPorTe.Rows.Count > 0)
                            {
                                procedure = "sp_empresaPorTipoDeExamen_Update";
                            }
                            else
                            {
                                procedure = "sp_empresaPorTipoDeExamen_Add";

                            }
                            SQLConnector.executeProcedure(procedure, list,
                                  new Guid(consulta.Rows[0].ItemArray[0].ToString()), rglEntidad.empresa.id, rglEntidad.empresaTarea);
                        }
                    }
                    rglEntidad.pacienteTipo = (PacienteTipo)(new PacienteTipoFactory(this.configuracion, "PacienteTipo")).getByCodigo(pacienteTipo);
                    rglEntidad.telefonos = tbTelefonos.Text;
                    rglEntidad.celular = tbCelular.Text;
                    rglEntidad.observaciones = tbObservaciones.Text;
                    rglEntidad.localidad = new Guid(cboLocalidad.SelectedValue.ToString());
                    rglEntidad.direccion = tbDireccion.Text;
                    rglEntidad.nacionalidad = new Guid(cboNacionalidad.SelectedValue.ToString());
                    tabPrincipal.SelectedIndex = 0;
               
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
      
        }

        protected override bool verificarDni()
        {
            DataTable pac = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Paciente where dni = '" + tbDNI.Text + "'");
            if (pac.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                DataRow[] dr = pac.Select("id = '" + tbId.Text + "'");
                if (dr.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool existeEnListado(string idClub)
        {
            foreach (DataGridViewRow row in dgvClubesAsignados.Rows)
            {
                if (row.Cells[3].Value.ToString() == idClub)
                {
                    return true;
                }
            }
            return false;

        }
        private void cargarClubesQueJuega()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection cn = new SqlConnection(configuracion.getConectionString());
                SqlCommand cmd = new SqlCommand(@"select cp.id As Id, l.id as IdLiga, l.descripcion as Liga, cp.club as IdClub, c.descripcion as Club from dbo.clubesPorPaciente cp 
                inner join dbo.Club c on cp.club = c.id inner join dbo.Liga l on c.ligaID = l.id where cp.paciente = '" + rglEntidad.id.ToString() + "' order by l.descripcion", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    int index = dgvClubesAsignados.Rows.Add(1);
                    dgvClubesAsignados.Rows[index].Selected = true;
                    dgvClubesAsignados.SelectedCells[0].Value = row.ItemArray[0];
                    dgvClubesAsignados.SelectedCells[1].Value = row.ItemArray[1];
                    dgvClubesAsignados.SelectedCells[2].Value = row.ItemArray[2];
                    dgvClubesAsignados.SelectedCells[3].Value = row.ItemArray[3];
                    dgvClubesAsignados.SelectedCells[4].Value = row.ItemArray[4];
            
                }
                if (dgvClubesAsignados.Rows.Count > 0)
                {
                    dgvClubesAsignados.SelectedRows[0].Selected = false;
                }
                else if (dgvEmpresa.DataSource != null && dgvEmpresa.CurrentRow.Index != 0)
                {
                    rbLaboral.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        protected override void dniDuplicados()
        {
            string idPaciente1 = tbId.Text;
            DataTable pacientesConMismoDni = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Paciente where dni = '" + tbDNI.Text + "'");
            if (pacientesConMismoDni.Select("id <> '" + idPaciente1 + "'").Length > 0)
            {
                string idPaciente2 = pacientesConMismoDni.Select("id <> '" + idPaciente1 + "'")[0][0].ToString();
                abrirVentanaUnificacionHistoriaClinica(idPaciente1, idPaciente2);               
            }
        }

        private void abrirVentanaUnificacionHistoriaClinica(string idPaciente1, string idPaciente2)
        {
            frmCambioDni frm = new frmCambioDni(idPaciente1, idPaciente2, this);
            frm.ShowDialog();
        }

        private DataTable cargarConsultasYTurnosPaciente(string idPaciente)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Columna");
            DataTable consultas = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Consulta where pacienteID = '" + idPaciente + "'");
            foreach (DataRow cons in consultas.Rows)
            {
                retorno.Rows.Add("CONSULTA");
            }
            DataTable turnos = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Turno where pacienteID = '" + idPaciente + "'");
            foreach (DataRow turn in turnos.Rows)
            {
                retorno.Rows.Add("TURNO");
            }
            return retorno;
        }

        public override string validarNegocio()
        {
            PacienteFactory negEntidadFac = (PacienteFactory)crearNegEntidadFac();
            string resultado = negEntidadFac.validar(rglEntidad, edicion);
            negEntidadFac = null;

            return resultado;
        }


        public override CapaNegocioBase.EntidadFactoryBase crearNegEntidadFac()
        {
            return new PacienteFactory(this.configuracion, this.EntidadNombre);
        }

        public override Resultado alta()
        {
            Resultado resultado = new Resultado();

            try
            {
                PacienteFactory negEntidadFac = (PacienteFactory)crearNegEntidadFac();
                resultado = negEntidadFac.alta(rglEntidad);
                negEntidadFac = null;

                PacientePre.ActualizarMail(tbDNI.Text, txtMail.Text); // GRV - Modificado
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
                PacienteFactory negEntidadFac = (PacienteFactory)crearNegEntidadFac();
                resultado = negEntidadFac.modificar(rglEntidad);
                negEntidadFac = null;

                //Si es movil y se modifico el paciente, se lo marca como no sincronizado.
                //if (bool.Parse(this.configuracion.obtenerParametro("ES_MOVIL").ToString()))
                //    SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), CommandType.Text, "UPDATE Paciente SET sincronizado=NULL WHERE id='" + rglEntidad.id.ToString() + "'");
                PacientePre.ActualizarMail(tbDNI.Text, txtMail.Text); // GRV - Modificado
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
                PacienteFactory negPacienteFac = new PacienteFactory(this.configuracion, this.EntidadNombre);
                resultado = negPacienteFac.borrar(id);

                negPacienteFac = null;
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
                    agregar();
                    tbDNI.Text = codigo;
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

            blnPresionarQuitar = true;

            return encontro;
        }

        protected override void focoEnOK()
        {
            //butOk.Focus();
            if (this.mostrarBotonOk)
                this.ok();
        }

        private void seleccionarTipoConsulta()
        {
            if (rbPreventiva.Checked)
            {
                gbPreventiva.Visible = true;
                gbLaboral.Visible = false;
                cboLiga.Focus();
            }

            if (rbLaboral.Checked)
            {
                gbPreventiva.Visible = false;
                gbLaboral.Visible = true;
                tbBuscarEmpresa.Focus();
            }

        }

        private void rbPreventiva_CheckedChanged(object sender, EventArgs e)
        {
            seleccionarTipoConsulta();
        }

        private void rbLaboral_CheckedChanged(object sender, EventArgs e)
        {
            seleccionarTipoConsulta();
        }

        private void rbOtros_CheckedChanged(object sender, EventArgs e)
        {
            seleccionarTipoConsulta();
        }

        //private void tbBuscarClub_TextChanged(object sender, EventArgs e)
        //{
        //  //  llenarClubes(tbBuscarClub.Text);
        //    if (tbBuscarClub.Text == string.Empty)
        //    {
        //        if (cboLiga.Text != "A DESIGNAR...")
        //        {
        //            btnBusClub.Enabled = false;
        //            frmBusquedaClubxLiga frmBusCL = new frmBusquedaClubxLiga(configuracion, "Club", cboLiga.SelectedValue.ToString());
        //            frmBusCL.ShowDialog();
        //            tbBuscarClub.Text = frmBusCL.clubSeleccionado;
        //            if (frmBusCL.clubSeleccionado != string.Empty)
        //                club1 = new Guid(frmBusCL.idCLub.ToString());
        //            btnBusClub.Enabled = true;
        //        }
        //    }
        //}

        private string ComboLiga(ComboBox combo)
        {
            string resultado="";
          
            switch (combo.Name)
            {
                case "cboLiga":
                    resultado = cboLiga.SelectedValue.ToString();
                    break;

            }
            return resultado;

        }



        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               
                System.IO.StreamReader sr = new
                System.IO.StreamReader(openFileDialog1.FileName);
                this.txtRutaFoto.Text = openFileDialog1.FileName;
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }
        }

        private void cboLiga_DropDown(object sender, EventArgs e)
        {
            comboSeleccionado = ComboLiga(cboLiga);
            if (cboLiga.Text.ToString() == "A DESIGNAR...")
                tbBuscarClub.Text = string.Empty;
        }

  
        private DataTable obtenerTablaSegunConsultaString(string consulta)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection cn = new SqlConnection(configuracion.getConectionString());
                SqlCommand cmd = new SqlCommand(consulta, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void tbBuscarClub_TextChanged(object sender, EventArgs e)
        {
            if (!MuestraMensajeSiPacienteTieneLiga())
                buscarClubes();            
        }

        private void buscarClubes()
        {
            string filtro = "";
            if (tbBuscarClub.Text != "")
            {
               filtro = " and c.descripcion like '%" + tbBuscarClub.Text + "%'";
            }

            DataTable clubes;
            clubes = obtenerTablaSegunConsultaString(@"Select c.id as Id, c.descripcion as Nombre 
                from dbo.Club c where activo = 1 and ligaID = '" + cboLiga.SelectedValue.ToString() + "'" + filtro);
            dgvClub.DataSource = clubes;
            dgvClub.Columns[0].Visible = false;
   
        }

        private void dgvClub_DoubleClick(object sender, EventArgs e)
        {
            agregarClubAlPaciente();
        }



        private void agregarClubAlPaciente()
        {
            try
            {
                DataRowView datos = (DataRowView)cboLiga.SelectedItem;
                int index = dgvClubesAsignados.Rows.Add(1);
                dgvClubesAsignados.Rows[index].Selected = true;
                dgvClubesAsignados.SelectedCells[0].Value = 0;
                dgvClubesAsignados.SelectedCells[1].Value = cboLiga.SelectedValue.ToString();
                dgvClubesAsignados.SelectedCells[2].Value = datos.Row.ItemArray[2].ToString();
                dgvClubesAsignados.SelectedCells[3].Value = dgvClub.SelectedCells[0].Value;
                dgvClubesAsignados.SelectedCells[4].Value = dgvClub.SelectedCells[1].Value;
                dgvClubesAsignados.Rows[index].Selected = false;
                cboLiga.SelectedIndex = 0;
                dgvClub.DataSource = null;
                this.ActiveControl = cboLiga;

                // GRV - Modificado
                verificaClubIngresado();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                //
            }
            
        }

        private void eliminarClub()
        {
            DialogResult result = MessageBox.Show("Se va a eliminar el club asignado al paciente. ¿Desea continuar? ", "Eliminar Club Asignado ", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
               
                    dgvClubesAsignados.Rows.RemoveAt(dgvClubesAsignados.SelectedRows[0].Index);
                    cboLiga.SelectedIndex = 0;
                    this.ActiveControl = cboLiga;
                    if (dgvClubesAsignados.SelectedRows.Count > 0)
                    {
                        dgvClubesAsignados.CurrentCell.Selected = false;
                    }
            }

            // GRV - Modificado
            if (dgvClubesAsignados.Rows.Count > 0)
            {
                verificaClubIngresado();
            }
        }

        private bool juegaEnLiga()
        {
            DataRowView infoLiga = (DataRowView)cboLiga.SelectedItem;
            String nombreDeLiga = infoLiga.Row.ItemArray[2].ToString();
            foreach (DataGridViewRow row in dgvClubesAsignados.Rows)
            {
                if (row.Cells[2].Value.ToString() == nombreDeLiga){
                    return true;
                }
            }
            return false;

        }


        private void dgvClubesAsignados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            eliminarClub();
        }



        private void dtpFechaNacimiento_Leave(object sender, EventArgs e)
        {
            if (fechaDeNacimientoValida())
            {
                if (dtpFechaNacimiento.Text.Length == 10)
                {
                    lblCategoria.Text = Convert.ToDateTime(dtpFechaNacimiento.Text).Year.ToString();
                }
            }
            else
            {
                MessageBox.Show("La fecha de nacimiento ingresada no es valida. Por favor verifique para continuar");
            }

            try
            {
                DateTime dtNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Text);
                txtEdad.Text = (DateTime.Today.AddTicks(-dtNacimiento.Ticks).Year - 1).ToString();
            }
            catch (System.FormatException ex)
            {
                txtEdad.Text = "0";
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvClubesAsignados.SelectedRows.Count > 0)
            {
                eliminarClub();
            }
            else
            {
                MessageBox.Show("Error. Seleccione un club para eliminar");
            }
            dgvClub.DataSource = null;
            blnPresionarQuitar = true;
        }

        private bool fechaDeNacimientoValida()
        {
            try
            {
                DateTime fechaValida = DateTime.Parse(dtpFechaNacimiento.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

      
        private void dgvClub_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                dgvClub_DoubleClick(this, e);
                tbBuscarClub.Text = "";
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (dgvClubesAsignados.Rows.Count > 0)
                {
                    this.ActiveControl = dgvClubesAsignados;
                    dgvClubesAsignados.Rows[0].Selected = true;
                }
            }
        }

        private void cboLiga_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (cboLiga.DroppedDown == false)
                {
                    e.SuppressKeyPress = true;
                    cboLiga.DroppedDown = true;
                }
              
            }
            else if (e.KeyCode == Keys.Right)
            {
                e.SuppressKeyPress = true;
                this.ActiveControl = dgvClubesAsignados;
                dgvClubesAsignados.Rows[0].Selected = true;

            }
        }

        private void dgvClubesAsignados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnQuitar.PerformClick();
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (dgvClub.Rows.Count > 0)
                {
                    this.ActiveControl = dgvClub;
                    dgvClub.Rows[0].Selected = true;
                    dgvClubesAsignados.CurrentRow.Selected = false;
                }
            }
        }

        private void cboLiga_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvClubesAsignados.RowCount <= 4)
            {
                if (cboLiga.SelectedValue != null)
                {
                    if (!juegaEnLiga())
                    {
                        tbBuscarClub.Clear();
                        DataTable clubes;
                        // GRV - Modificado mostrar clubes activos
                        //clubes = obtenerTablaSegunConsultaString("Select c.id as Id, c.descripcion as Nombre from dbo.Club c where ligaID = '" + cboLiga.SelectedValue.ToString() + "'");                    
                        clubes = obtenerTablaSegunConsultaString("Select c.id as Id, c.descripcion as Nombre from dbo.Club c where ligaID = '" + cboLiga.SelectedValue.ToString() + "' AND activo = 1");
                        dgvClub.DataSource = clubes;
                        dgvClub.Columns[0].Visible = false;
                        this.ActiveControl = tbBuscarClub;
                    }
                }
                else
                {
                    MessageBox.Show("El paciente ya juega en esa liga. Seleccione otra o verifique la categoría");
                    dgvClub.DataSource = null;
                    this.ActiveControl = cboLiga;
                }
            }
            else
            {
                MessageBox.Show("Solo se permite asignar hasta 5 clubes por paciente");
                cboLiga.SelectedIndex = 0;
                this.ActiveControl = cboLiga;
            }
        }

        private void dtpFechaNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = cboLiga;
                dgvClub.DataSource = null;
                EliminarRegistroLigaComboBox();                
            }
        }

        private void frmPaciente_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (modo == 2)
            {
                form.cargarGrilla();
                form.mostrarDatos();
                form.comprobarEmpresaYClub();
            }
            else if (modo == 1)
            {
                formTurno.actualizarPaciente(tbId.Text);
            }
            if (modo == 3)
            {
                DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Paciente where id = '" + tbId.Text + "'");
                if (paciente.Rows.Count > 0)
                {
                    form.clickBuscar();
                }
            }
        }

        private void dgvExamenes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                abrirClinico(e.RowIndex);
            }
            else if (e.ColumnIndex == 9)
            {
                abrirLaboratorio(e.RowIndex);
            }
            else if(e.ColumnIndex == 11)
            {
                abrirRX(e.RowIndex);
            }
            else if (e.ColumnIndex == 13)
            {
                abrirCard(e.RowIndex);
            }
            else if (e.ColumnIndex == 15)
            {
                if (dgvExamenes.Rows[e.RowIndex].Cells[18].Value.ToString() != "NO RENOVADO"
                    && dgvExamenes.Rows[e.RowIndex].Cells[18].Value.ToString() != "NO EFECTUADO"
                    && dgvExamenes.Rows[e.RowIndex].Cells[18].Value.ToString() != "NO CARGADO")
                {
                    Utilidades.abrirFormulario(this.MdiParent, new frmDictamenFinal(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
                }
            }
            puntero = dgvExamenes.CurrentCell.RowIndex;
            celda = e.ColumnIndex;
        }

        // GRV - Modificado

        private void abrirClinico(int r)
        {
            if (dgvExamenes.Rows[r].Cells[15].Value.ToString() != "NO RENOVADO" &&
                dgvExamenes.Rows[r].Cells[15].Value.ToString() != "NO EFECTUADO")
            {
                frmExamenFisico frmExamen = new frmExamenFisico(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]);
                frmExamen.ShowDialog();
                frmExamen.Focus();
                //Utilidades.abrirFormulario(this.MdiParent, new frmExamenFisico(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
                //Utilidades.abrirFormulario(this.MdiParent, new frmExamenFisico(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
            }
        }

        private void abrirLaboratorio(int r)
        {
            if (dgvExamenes.Rows[r].Cells[15].Value.ToString() != "NO RENOVADO"
                && dgvExamenes.Rows[r].Cells[15].Value.ToString() != "NO EFECTUADO"
                && dgvExamenes.Rows[r].Cells[15].Value.ToString() != "NO CARGADO")
            {
                frmExamenLaboratorio frmExamenLab = new frmExamenLaboratorio(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]);
                frmExamenLab.ShowDialog();
                frmExamenLab.Focus();
                //Utilidades.abrirFormulario(this.MdiParent, new frmExamenLaboratorio(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
            }

        }

        private void abrirRX(int r)
        {
            if (dgvExamenes.Rows[r].Cells[15].Value.ToString() != "NO RENOVADO"
                && dgvExamenes.Rows[r].Cells[15].Value.ToString() != "NO EFECTUADO"
                && dgvExamenes.Rows[r].Cells[15].Value.ToString() != "NO CARGADO")
            {
                frmRX frmRX01 = new frmRX(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]);
                frmRX01.ShowDialog();
                frmRX01.Focus();
                //Utilidades.abrirFormulario(this.MdiParent, new frmRX(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
            }
        }

        private void abrirCard(int r)
        {
            if (dgvExamenes.Rows[r].Cells[15].Value.ToString() != "NO RENOVADO"
                && dgvExamenes.Rows[r].Cells[15].Value.ToString() != "NO EFECTUADO"
                && dgvExamenes.Rows[r].Cells[15].Value.ToString() != "NO CARGADO")
            {
                frmExamenCardiologia frmExamenCard = new frmExamenCardiologia(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]);
                frmExamenCard.ShowDialog();
                frmExamenCard.Focus();
                //Utilidades.abrirFormulario(this.MdiParent, new frmExamenCardiologia(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
            }
        }

//        private void abrirClinico(int r)
//        {
//            if (dgvExamenes.Rows[r].Cells[6].Value.ToString() == "0")
//            {
//                Utilidades.abrirFormulario(this.MdiParent, new frmExamenFisico(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
//            }
//            else
//            {
//                DataTable valoresDelExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ValoresPorExamen where idTipoExamen 
//                    = '" + dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex].Cells[0].Value.ToString() + @"' and Convert(int,codigo) >= 1 and Convert(int,codigo) <= 29 
//                    order by Convert(int,codigo) asc");
//                  Utilidades.abrirFormulario(this.MdiParent, new frmExamenFisico(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex], valoresDelExamen), new Configuracion());              
//            }
//        }

//        private void abrirLaboratorio(int r)
//        {
//            if (dgvExamenes.Rows[r].Cells[6].Value.ToString() != "0")
//            {
//                if (dgvExamenes.Rows[r].Cells[8].Value.ToString() == "0")
//                {
//                    Utilidades.abrirFormulario(this.MdiParent, new frmExamenLaboratorio(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
//                }
//                else
//                {
//                    DataTable valoresDelExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ValoresPorExamen where idTipoExamen 
//                    = '" + dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex].Cells[0].Value.ToString() + @"' and Convert(int,codigo) >= 30 and Convert(int,codigo) <= 69
//                    order by Convert(int,codigo) asc");
                  
//                        Utilidades.abrirFormulario(this.MdiParent, new frmExamenLaboratorio(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex], valoresDelExamen), new Configuracion());
                  
                    
//                }
//            }
//            else
//            {
//                MessageBox.Show("¡Se debe cargar el examen clínico para poder cargar los demás estudios!", "Atención",
//                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//            }

//        }

//        private void abrirRX(int r)
//        {
//            if (dgvExamenes.Rows[r].Cells[6].Value.ToString() != "0")
//            {
//                if (dgvExamenes.Rows[r].Cells[10].Value.ToString() == "0")
//                {
//                    Utilidades.abrirFormulario(this.MdiParent, new frmRX(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
//                }
//                else
//                {
//                    DataTable valoresDelExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ValoresPorExamen where idTipoExamen 
//                    = '" + dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex].Cells[0].Value.ToString() + @"' and Convert(int,codigo) >= 70 and Convert(int,codigo) <= 75
//                    order by Convert(int,codigo) asc");
            
//                        Utilidades.abrirFormulario(this.MdiParent, new frmRX(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex], valoresDelExamen), new Configuracion());
               
                    
//                }
//            }
//            else
//            {
//                MessageBox.Show("¡Se debe cargar el examen clínico para poder cargar los demás estudios!", "Atención",
//                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//            }
//        }

//        private void abrirCard(int r)
//        {
//            if (dgvExamenes.Rows[r].Cells[6].Value.ToString() != "0")
//            {
//                if (dgvExamenes.Rows[r].Cells[12].Value.ToString() == "0")
//                {
//                    Utilidades.abrirFormulario(this.MdiParent, new frmExamenCardiologia(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
//                }
//                else
//                {
//                    DataTable valoresDelExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ValoresPorExamen where idTipoExamen 
//                    = '" + dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex].Cells[0].Value.ToString() + @"' and Convert(int,codigo) >= 80 and Convert(int,codigo) <= 82
//                    order by Convert(int,codigo) asc");

                   
//                        Utilidades.abrirFormulario(this.MdiParent, new frmExamenCardiologia(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex], valoresDelExamen), new Configuracion());
                   
                  
//                }
//            }
//            else
//            {
//                MessageBox.Show("¡Se debe cargar el examen clínico para poder cargar los demás estudios!", "Atención",
//                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//            }
//        }
        // GRV - Modificado

        private void dictamenFinalAutomatico(int puntero)
        {
            DataGridViewRow dgvR = dgvExamenes.Rows[puntero];
            string idTe = dgvR.Cells[0].Value.ToString();
            DataTable tipoEx = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.TipoExamenDePaciente where id = '" +
                idTe + "' and (dictAut is NULL or dictAut = '')");
            if (tipoEx.Rows.Count > 0)
            {
                DataTable valoresPorExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ValoresPorExamen
            where idTipoExamen = '" + idTe + "'");
                string fisico = consultarCodigoValidacion(valoresPorExamen, "22");
                string lab = consultarCodigoValidacion(valoresPorExamen, "60");
                string rx = consultarCodigoValidacion(valoresPorExamen, "72");
                string car = consultarCodigoValidacion(valoresPorExamen, "81");
                string final = consultarIdValidacion(valoresPorExamen, "90");
                DataTable validacionAutomatica = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ValidacionesDictamen
                where fisico = '" + fisico + "' and laboratorio = '" + lab + "' and rx = '" + rx + "' and car = '" + car + "'");
                string codigoFinal = "13";
                if (validacionAutomatica.Rows.Count > 0)
                {
                    codigoFinal = validacionAutomatica.Rows[0].ItemArray[5].ToString();
                }
                DataTable validaciones = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.Validaciones where
                codigo = '90' and codigoInterno = '" + codigoFinal + "'");
                if (final != "0")
                {
                    List<string> listUpdate = SQLConnector.generarListaParaProcedure("@id", "@valor");
                    SQLConnector.executeProcedure("dbo.ValoresPorExamen_UpdateDictamenFinal", listUpdate, new Guid(idTe), validaciones.Rows[0].ItemArray[0].ToString());
                }
                else
                {
                    List<string> listAdd = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@codigo", "@valor");
                    SQLConnector.executeProcedure("sp_ValoresPorExamen_Add", listAdd, new Guid(idTe), "90", validaciones.Rows[0].ItemArray[0].ToString());
                }
            }
        }


        private string consultarCodigoValidacion(DataTable ve, string codigo)
        {
            DataRow[] rows = ve.Select("codigo = '" + codigo + "'");
            if (rows.Length > 0)
            {
                string idValidacion = rows[0][3].ToString();
                DataTable validaciones = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.Validaciones
                where id = " + idValidacion);
                return validaciones.Rows[0].ItemArray[2].ToString();
            }
            else
            {
                return "00";
            }

        }


        private string consultarIdValidacion(DataTable ve, string codigo)
        {
            DataRow[] rows = ve.Select("codigo = '" + codigo + "'");
            if (rows.Length > 0) { return rows[0][3].ToString(); } else { return "0"; }


        }

        private void botImprimir_Click(object sender, EventArgs e)
        {
            DialogResult resultExamen = MessageBox.Show("¿Desea imprimir la carátula de exámen?", "Imprimir Carátula",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult resultProtocolo = MessageBox.Show("¿Desea imprimir el protocolo de laboratorio?", "Imprimir Protocolo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgvExamenes.SelectedCells.Count > 0)
            {
                puntero = dgvExamenes.SelectedCells[0].RowIndex;
                celda = dgvExamenes.SelectedCells[0].ColumnIndex;
                foreach (DataGridViewCell cell in dgvExamenes.SelectedCells)
                {
                    if (celda == cell.ColumnIndex)
                    {
                        DataGridViewRow row = dgvExamenes.Rows[cell.RowIndex];
                        if (row.Cells[6].Value.ToString() != "0" && row.Cells[8].Value.ToString() != "0" &&
                            row.Cells[10].Value.ToString() != "0" && row.Cells[12].Value.ToString() != "0"
                            && row.Cells[14].Value.ToString() != "0")
                        {
                            if (resultExamen == DialogResult.Yes) { imprimirExamen(row); }
                            if (resultProtocolo == DialogResult.Yes) { imprimirProtocolo(row); }
                        }
                        else
                        {
                            MessageBox.Show("No se puede imprimir el exámen Nº: " + row.Cells[3].Value.ToString() + " de la fecha: " +
                                row.Cells[2].Value.ToString() + " . ¡Faltan cargar estudios!",
                                "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                cargarExamenes();
            }
        }

        // GRV - Modificado
        //private void imprimirExamen(DataGridViewRow r)
        //{
        //    DateTime fecha = Convert.ToDateTime(r.Cells[2].Value);
        //    int dia = fecha.Day;
        //    string diaStr = dia.ToString();
        //    if (dia <= 9) { diaStr = "0" + diaStr; }

        //    int mes = fecha.Month;
        //    string mesStr = mes.ToString();
        //    if (mes <= 9) { mesStr = "0" + mesStr; }

        //    rptExamenPreventiva doc = new rptExamenPreventiva();
        //    doc.SetDataSource(setearDS(1));
        //    setearParametrosExamen(r, doc);
        //    List<string> listImp = SQLConnector.generarListaParaProcedure("@id", "@valor");
        //    SQLConnector.executeProcedure("sp_TipoExamenDePaciente_UpdateImpresion", listImp,
        //        new Guid(r.Cells[0].Value.ToString()), "1");

        //    string nombreExamen = diaStr +
        //    mesStr + fecha.Year.ToString() + "-" + tbDNIExamen.Text + "-E";
        //    doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
        //    @"P:\ESTUDIOS TEMPORADA 2016\" + nombreExamen.Replace(" ", "") + ".pdf");
        //    doc.PrintToPrinter(1, true, 1, 1);
        //    doc.Close();

        //}
        private void imprimirExamen(DataGridViewRow r)
        {
            Reportes report = new Reportes(new rptExamenPreventiva());

            Entidades.Resultado result = report.imprimirYExportar(preventiva.cargarParametrosExamen(r.Cells[0].Value, r.Cells[1].Value),
            new dsExamenPreventiva(), preventiva.cargarDataSourceExamen(),
                // GRV - Ramírez - Modificado
                // @"P:\ESTUDIOS TEMPORADA 2016\" + cargarRutaDestino(r,"E") + ".pdf");
            DirectorioReporte(1) + cargarRutaDestino(r, "E") + ".pdf");

            if (result.Modo == 1) { preventiva.actualizarImpresionExamen(r.Cells[0].Value); }
            else { MessageBox.Show(result.Mensaje); }
        }

        // GRV - Modoficado
        //private void imprimirProtocolo(DataGridViewRow r)
        //{
        //    DateTime fecha = Convert.ToDateTime(r.Cells[2].Value);
        //    int dia = fecha.Day;
        //    string diaStr = dia.ToString();
        //    if (dia <= 9) { diaStr = "0" + diaStr; }

        //    int mes = fecha.Month;
        //    string mesStr = mes.ToString();
        //    if (mes <= 9) { mesStr = "0" + mesStr; }
        //    rptProtocoloLaboratorioPreventiva doc = new rptProtocoloLaboratorioPreventiva();
        //    doc.SetDataSource(setearDS(2));
        //    setearParametrosProtocolo(r, doc);
        //    List<string> listImp = SQLConnector.generarListaParaProcedure("@id", "@valor");
        //    SQLConnector.executeProcedure("sp_TipoExamenDePaciente_UpdateImpresionLaboratorio", listImp,
        //        new Guid(r.Cells[0].Value.ToString()), "1");
        //    string nombreExamen = diaStr +
        //    mesStr + fecha.Year.ToString() + "-" + tbDNIExamen.Text + "-L";
        //    doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
        //    @"P:\ESTUDIOS TEMPORADA 2016\" + nombreExamen.Replace(" ", "") + ".pdf");
        //    doc.PrintToPrinter(1, true, 1, 1);
        //    doc.Close();
        //}
        private void imprimirProtocolo(DataGridViewRow r)
        {
            Reportes report = new Reportes(new rptProtocoloLaboratorioPreventiva());

            Entidades.Resultado result = report.imprimirYExportar(preventiva.cargarParametrosLaboratorio(r.Cells[0].Value, r.Cells[1].Value),
            new dsExamenPreventiva(), preventiva.cargarDataSourceProtocoloLaboratorio(),
                // GRV - Ramírez - Modificado
                // @"P:\ESTUDIOS TEMPORADA 2016\" + cargarRutaDestino(r, "L") + ".pdf");
            DirectorioReporte(2) + cargarRutaDestino(r, "L") + ".pdf");

            if (result.Modo == 1) { preventiva.actualizarImpresionLaboratorio(r.Cells[0].Value); }
            else { MessageBox.Show(result.Mensaje); }
        }

        private string DirectorioReporte(byte valor)
        {
            byte bytTipo = valor;
            string strDirectorio = "";

            DataTable valores = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT reporte FROM dbo.ConfigReportes
            WHERE tipoReporte = '" + bytTipo + "'");

            if (valores.Rows.Count > 0)
            {
                strDirectorio = valores.Rows[0].ItemArray[0].ToString() + "\\";
            }
            else
            {
                strDirectorio = "P:\\ESTUDIOS TEMPORADA 2016\\";
            }

            return strDirectorio;
        }

        private string cargarRutaDestino(DataGridViewRow r, string tipo)
        {
            DateTime fecha = Convert.ToDateTime(r.Cells[2].Value);
            int dia = fecha.Day;
            string diaStr = dia.ToString();
            if (dia <= 9) { diaStr = "0" + diaStr; }

            int mes = fecha.Month;
            string mesStr = mes.ToString();
            if (mes <= 9) { mesStr = "0" + mesStr; }

            return (diaStr + mesStr + fecha.Year.ToString() + "-" + r.Cells[7].Value.ToString() + "-" + tipo).Replace(" ", "");
        }

        private dsExamenPreventiva setearDS(int tipoReporte)
        {
            dsExamenPreventiva ds = new dsExamenPreventiva();
            DataTable temp = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ConfigReportes
            where tipoReporte = '" + tipoReporte.ToString() + "'");
            DataRow dr = ds.Imagen.NewRow();
            dr["Imagen"] = temp.Rows[0].ItemArray[1];
            dr["Imagen1"] = temp.Rows[0].ItemArray[2];
            dr["Profesional"] = temp.Rows[0].ItemArray[3];
            dr["Matricula"] = temp.Rows[0].ItemArray[4];
            dr["Cargo"] = temp.Rows[0].ItemArray[5];
            dr["PiePagina"] = temp.Rows[0].ItemArray[6];
            ds.Imagen.Rows.Add(dr);
            return ds;
        }

        private void setearParametrosProtocolo(DataGridViewRow row, rptProtocoloLaboratorioPreventiva rpt)
        {
            string idExamen = row.Cells[0].Value.ToString();
            string idConsulta = row.Cells[1].Value.ToString();
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select c.fecha, 
            c.identificador, p.dni, p.fechaNacimiento,(p.apellido + ' ' + p.nombres) as nombre,
            p.telefonos, p.celular from dbo.Consulta c inner join dbo.Paciente p 
            on c.pacienteID = p.id where c.id = '" + idConsulta + "'");
            DataTable valoresPorExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select codigo, valor 
            from dbo.ValoresPorExamen where idTipoExamen = '" + idExamen + "' order by CONVERT(int, codigo) asc");
            string fecha = ((DateTime)consulta.Rows[0].ItemArray[0]).ToShortDateString();
            string identificador = consulta.Rows[0].ItemArray[1].ToString();
            string dni = consulta.Rows[0].ItemArray[2].ToString();
            string nacimiento = ((DateTime)consulta.Rows[0].ItemArray[3]).ToShortDateString();
            string nombre = consulta.Rows[0].ItemArray[4].ToString();
            setearParametroProtocolo(rpt, 0, fecha);
            setearParametroProtocolo(rpt, 1, identificador);
            setearParametroProtocolo(rpt, 2, dni);
            setearParametroProtocolo(rpt, 3, nacimiento);
            setearParametroProtocolo(rpt, 4, nombre);
            setearValorProtocolo(rpt, 5, valoresPorExamen, 29, 1, "");
            setearValorProtocolo(rpt, 6, valoresPorExamen, 30, 1, "");
            setearValorProtocolo(rpt, 7, valoresPorExamen, 31, 1, "");
            setearValorProtocolo(rpt, 8, valoresPorExamen, 32, 1, "");
            setearValorProtocolo(rpt, 9, valoresPorExamen, 33, 1, "");
            setearValorProtocolo(rpt, 10, valoresPorExamen, 34, 1, "");
            setearValorProtocolo(rpt, 11, valoresPorExamen, 35, 1, "");
            setearValorProtocolo(rpt, 12, valoresPorExamen, 36, 1, "");
            setearValorProtocolo(rpt, 13, valoresPorExamen, 37, 1, "");
            setearValorProtocolo(rpt, 14, valoresPorExamen, 38, 1, "");
            setearValorProtocolo(rpt, 15, valoresPorExamen, 39, 1, "");
            setearValorProtocolo(rpt, 16, valoresPorExamen, 40, 1, "");
            setearValorProtocolo(rpt, 17, valoresPorExamen, 41, 1, "");
            setearValorProtocolo(rpt, 18, valoresPorExamen, 42, 2, "");
            setearValorProtocolo(rpt, 19, valoresPorExamen, 43, 2, "");
            setearValorProtocolo(rpt, 20, valoresPorExamen, 46, 2, "");
            setearValorProtocolo(rpt, 21, valoresPorExamen, 47, 2, "");
            setearValorProtocolo(rpt, 22, valoresPorExamen, 48, 1, "");
            setearValorProtocolo(rpt, 23, valoresPorExamen, 49, 1, "");
            setearValorProtocolo(rpt, 24, valoresPorExamen, 50, 2, "");
            setearValorProtocolo(rpt, 25, valoresPorExamen, 51, 2, "");
            setearValorProtocolo(rpt, 26, valoresPorExamen, 52, 2, "");
            setearValorProtocolo(rpt, 27, valoresPorExamen, 53, 2, "");
            setearValorProtocolo(rpt, 28, valoresPorExamen, 54, 2, "");
            setearValorProtocolo(rpt, 29, valoresPorExamen, 55, 2, "");
            setearValorProtocolo(rpt, 30, valoresPorExamen, 56, 2, "");
            setearValorProtocolo(rpt, 31, valoresPorExamen, 57, 2, "");
            setearValorProtocolo(rpt, 32, valoresPorExamen, 58, 2, "");
            setearValorProtocolo(rpt, 33, valoresPorExamen, 64, 1, "");

        }

        private void setearParametrosExamen(DataGridViewRow row, rptExamenPreventiva rpt)
        {
            string idExamen = row.Cells[0].Value.ToString();
            string idConsulta = row.Cells[1].Value.ToString();
            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select c.fecha, 
            c.identificador, p.dni, p.fechaNacimiento,(p.apellido + ' ' + p.nombres) as nombre,
            p.telefonos, p.celular from dbo.Consulta c inner join dbo.Paciente p 
            on c.pacienteID = p.id where c.id = '" + idConsulta + "'");
            string fecha = ((DateTime)consulta.Rows[0].ItemArray[0]).ToShortDateString();
            string identificador = consulta.Rows[0].ItemArray[1].ToString();
            string dni = consulta.Rows[0].ItemArray[2].ToString();
            string nacimiento = ((DateTime)consulta.Rows[0].ItemArray[3]).ToShortDateString();
            string nombre = consulta.Rows[0].ItemArray[4].ToString();
            string telefono = ((DateTime)consulta.Rows[0].ItemArray[3]).Year.ToString();
            DataTable clubesPorExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select l.descripcion 
            as Liga, c.descripcion as Club from dbo.clubesPorTipoExamen cte inner join dbo.Club c on 
            cte.idClub = c.id inner join dbo.Liga l on c.ligaID = l.id where cte.idTipoExamen = '"
                + idExamen + "'");
            List<string> lista = new List<string>();
            lista.Add("");
            lista.Add("");
            lista.Add("");
            lista.Add("");
            int contador = 0;
            foreach (DataRow r in clubesPorExamen.Rows)
            {
                if (contador <= 3)
                {
                    lista[contador] = r.ItemArray[0].ToString();
                    contador++;
                    lista[contador] = r.ItemArray[1].ToString();
                    contador++;
                }
            }

            DataTable valoresPorExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select codigo, valor 
            from dbo.ValoresPorExamen where idTipoExamen = '" + idExamen + "' order by CONVERT(int, codigo) asc");


            setearParametro(rpt, 0, fecha);
            setearParametro(rpt, 1, identificador);
            setearParametro(rpt, 2, dni);
            setearParametro(rpt, 3, nacimiento);
            setearParametro(rpt, 4, nombre);
            setearParametro(rpt, 5, telefono);
            setearParametro(rpt, 6, lista[0].ToString());
            setearParametro(rpt, 7, lista[1].ToString());
            setearParametro(rpt, 8, lista[2].ToString());
            setearParametro(rpt, 9, lista[3].ToString());
            setearValor(rpt, 10, valoresPorExamen, 26, 1, "");
            setearValor(rpt, 11, valoresPorExamen, 27, 1, "");
            setearValor(rpt, 12, valoresPorExamen, 28, 1, "");
            setearValor(rpt, 13, valoresPorExamen, 24, 1, " m");
            setearValor(rpt, 14, valoresPorExamen, 25, 1, " kg");
            setearValor(rpt, 15, valoresPorExamen, 0, 2, "");
            setearValor(rpt, 16, valoresPorExamen, 1, 2, "");
            setearValor(rpt, 17, valoresPorExamen, 2, 2, "");
            setearValor(rpt, 18, valoresPorExamen, 3, 2, "");
            setearValor(rpt, 19, valoresPorExamen, 4, 2, "");
            setearValor(rpt, 20, valoresPorExamen, 5, 1, "");
            setearValor(rpt, 21, valoresPorExamen, 6, 1, "");
            setearValor(rpt, 22, valoresPorExamen, 7, 1, " xMin");
            setearValor(rpt, 23, valoresPorExamen, 8, 2, "");
            setearValor(rpt, 24, valoresPorExamen, 9, 2, "");
            setearValor(rpt, 25, valoresPorExamen, 10, 2, "");
            setearValor(rpt, 26, valoresPorExamen, 11, 2, "");
            setearValor(rpt, 27, valoresPorExamen, 12, 2, "");
            setearValor(rpt, 28, valoresPorExamen, 13, 2, "");
            setearValor(rpt, 29, valoresPorExamen, 14, 2, "");
            setearValor(rpt, 30, valoresPorExamen, 15, 2, "");
            setearValor(rpt, 31, valoresPorExamen, 16, 2, "");
            setearValor(rpt, 32, valoresPorExamen, 17, 2, "");
            setearValor(rpt, 33, valoresPorExamen, 18, 2, "");
            setearValor(rpt, 34, valoresPorExamen, 19, 2, "");
            setearValor(rpt, 35, valoresPorExamen, 20, 2, "");
            setearValor(rpt, 36, valoresPorExamen, 59, 2, "");
            setearValor(rpt, 37, valoresPorExamen, 70, 2, "");
            setearValor(rpt, 38, valoresPorExamen, 65, 2, "");
            setearValor(rpt, 39, valoresPorExamen, 66, 2, "");
            setearValor(rpt, 40, valoresPorExamen, 68, 1, "");
            setearValor(rpt, 41, valoresPorExamen, 73, 2, "");
            setearValor(rpt, 42, valoresPorExamen, 21, 2, "");

            string obsCli = valoresPorExamen.Rows[22].ItemArray[1].ToString();
            if (obsCli != "") { obsCli = "CLINICO: " + obsCli + " \n"; }
            string obsLab = valoresPorExamen.Rows[64].ItemArray[1].ToString();
            if (obsLab != "") { obsLab = "LABORATORIO: " + obsLab + " \n"; }
            string obsRx = valoresPorExamen.Rows[69].ItemArray[1].ToString();
            if (obsRx != "") { obsRx = "RX: " + obsRx + " \n"; }
            string obsCar = valoresPorExamen.Rows[72].ItemArray[1].ToString();
            if (obsCar != "") { obsCar = "CARDIOLOGIA: " + obsCar + " \n"; }
            string observaciones = obsCli + obsLab + obsRx + obsCar;
            setearParametro(rpt, 43, observaciones);

            DataTable rm = SQLConnector.obtenerTablaSegunConsultaString(@"select rm from dbo.TipoExamenDePaciente 
            where id = '" + idExamen + "'");
            string retiro = "";
            if (rm.Rows.Count > 0 && rm.Rows[0].ItemArray[0].ToString() == "1")
            {
                retiro = "R.M.";
            }
            setearParametro(rpt, 44, retiro);



        }

        private void setearParametro(rptExamenPreventiva rpt, int pos, string valor)
        {
            if (valor != "") { rpt.SetParameterValue(pos, valor); }
            else { rpt.SetParameterValue(pos, ""); }

        }

        private void setearParametroProtocolo(rptProtocoloLaboratorioPreventiva rpt, int pos, string valor)
        {
            if (valor != "") { rpt.SetParameterValue(pos, valor); }
            else { rpt.SetParameterValue(pos, ""); }

        }

        private void setearValor(rptExamenPreventiva rpt, int pos, DataTable tabla, int posTabla,
            int modo, string agregado)
        {
            if (modo == 1)
            {
                setearParametro(rpt, pos, tabla.Rows[posTabla].ItemArray[1].ToString() + agregado);
            }
            else
            {
                DataTable valid = SQLConnector.obtenerTablaSegunConsultaString(@"select *
                from dbo.Validaciones where id = " + tabla.Rows[posTabla].ItemArray[1].ToString());
                setearParametro(rpt, pos, valid.Rows[0].ItemArray[3].ToString() + agregado);
            }
        }

        private void setearValorProtocolo(rptProtocoloLaboratorioPreventiva rpt, int pos, DataTable tabla, int posTabla,
    int modo, string agregado)
        {
            if (modo == 1)
            {
                setearParametroProtocolo(rpt, pos, tabla.Rows[posTabla].ItemArray[1].ToString() + agregado);
            }
            else
            {
                DataTable valid = SQLConnector.obtenerTablaSegunConsultaString(@"select *
                from dbo.Validaciones where id = " + tabla.Rows[posTabla].ItemArray[1].ToString());
                setearParametroProtocolo(rpt, pos, valid.Rows[0].ItemArray[3].ToString() + agregado);
            }
        }

        private void botMail_Click(object sender, EventArgs e)
        {
            // GRV - Modificado
            //if (dgvExamenes.Rows.Count > 0)
            //{
            //    if (dgvExamenes.CurrentRow.Cells[6].Value.ToString() != "0" &&
            //        dgvExamenes.CurrentRow.Cells[8].Value.ToString() != "0" &&
            //        dgvExamenes.CurrentRow.Cells[10].Value.ToString() != "0" &&
            //        dgvExamenes.CurrentRow.Cells[12].Value.ToString() != "0" &&
            //        dgvExamenes.CurrentRow.Cells[14].Value.ToString() != "0")
            //    {
            //        panelMail.Visible = true;
            //        tbDestinatario.Text = "";
            //        tbDestinatario.Focus();
            //    }
            //    else
            //    {
            //        MessageBox.Show("El exámen no se puede enviar por mail. ¡Faltan cargar estudios!",
            //            "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}

            if (dgvExamenes.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                mail();
                Cursor.Current = Cursors.Default;
            }
        }

        private void mail()
        {
            List<string> archivos = new List<string>();
            puntero = dgvExamenes.SelectedCells[0].RowIndex;
            celda = dgvExamenes.SelectedCells[0].ColumnIndex;
            frmMail frm = frmMail.GetForm();

            foreach (DataGridViewCell cell in dgvExamenes.SelectedCells)
            {
                if (celda == cell.ColumnIndex)
                {
                    Reportes reportPreventiva = new Reportes(new rptExamenPreventiva());
                    string rutaPreventiva = reportPreventiva.exportarAPDF(preventiva.cargarParametrosExamen(dgvExamenes.Rows[cell.RowIndex].Cells[0].Value,
                        dgvExamenes.Rows[cell.RowIndex].Cells[1].Value),
                    new dsExamenPreventiva(), preventiva.cargarDataSourceExamen(),
                        // GRV - Ramírez - Modificado
                        //@"P:\ESTUDIOS POR MAIL\" + cargarRutaDestino(dgvExamenes.Rows[cell.RowIndex], "E") + ".pdf");
                    DirectorioReporte(1) + cargarRutaDestino(dgvExamenes.Rows[cell.RowIndex], "E") + ".pdf");
                    archivos.Add(rutaPreventiva);

                    Reportes reportProtocolo = new Reportes(new rptProtocoloLaboratorioPreventiva());
                    string rutaProtocolo = reportProtocolo.exportarAPDF(preventiva.cargarParametrosLaboratorio(dgvExamenes.Rows[cell.RowIndex].Cells[0].Value,
                    dgvExamenes.Rows[cell.RowIndex].Cells[1].Value),
                    new dsExamenPreventiva(), preventiva.cargarDataSourceProtocoloLaboratorio(),
                        // GRV - Ramírez - Modificado
                        //@"P:\ESTUDIOS POR MAIL\" + cargarRutaDestino(dgvExamenes.Rows[cell.RowIndex], "P") + ".pdf");
                    DirectorioReporte(2) + cargarRutaDestino(dgvExamenes.Rows[cell.RowIndex], "P") + ".pdf");
                    archivos.Add(rutaProtocolo);
                    frm.agregarIdTipoExamen(new Guid(dgvExamenes.Rows[cell.RowIndex].Cells[0].Value.ToString()));
                }
            }
            frm.archivosAdjuntos(archivos);
            frm.setearAsunto("RESULTADO EXAMEN DE APTITUD DEPORTIVA");
            frm.setearMensaje("Adjuntamos al presente mail los estudios solicitados.");
            frm.mailPreventiva();
            frm.objDelegateDevolverResultadoEnvio = new frmMail.DelegateDevolverResultadoEnvio(actualizarEnvioMail);
            frm.mostrar(this.MdiParent);
        }

        public void actualizarEnvioMail(bool resultado, List<Guid> idsTipoExamen)
        {
            if (resultado)
            {
                foreach (Guid obj in idsTipoExamen)
                {
                    preventiva.actualizarEnvioMail(obj);
                }
                cargarExamenes();
            }
        }

        private void botEnviar_Click(object sender, EventArgs e)
        {
            if (tbDestinatario.Text != "")
            {
                enviarMail(tbDestinatario.Text);
            }
            else
            {
                MessageBox.Show("¡Ingrese el destinatario!", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void enviarMail(string destinatario)
        {
            try
            {


                DateTime fecha = Convert.ToDateTime(dgvExamenes.CurrentRow.Cells[2].Value);
                int dia = fecha.Day;
                string diaStr = dia.ToString();
                if (dia <= 9) { diaStr = "0" + diaStr; }

                int mes = fecha.Month;
                string mesStr = mes.ToString();
                if (mes <= 9) { mesStr = "0" + mesStr; }


                rptExamenPreventiva doc = new rptExamenPreventiva();
                doc.SetDataSource(setearDS(1));
                setearParametrosExamen(dgvExamenes.Rows[dgvExamenes.CurrentRow.Index], doc);
                string nombreExamen = diaStr +
                mesStr + fecha.Year.ToString() + "-" + tbDNIExamen.Text + "-E";
                doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                @"P:\ESTUDIOS POR MAIL\" + nombreExamen + ".pdf");
                doc.Close();

                rptProtocoloLaboratorioPreventiva rptProt = new rptProtocoloLaboratorioPreventiva();
                rptProt.SetDataSource(setearDS(2));
                setearParametrosProtocolo(dgvExamenes.Rows[dgvExamenes.CurrentRow.Index], rptProt);
                string nombreProtoc = diaStr +
                 mesStr + fecha.Year.ToString() + "-" + tbDNIExamen.Text + "-P";
                rptProt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                @"P:\ESTUDIOS POR MAIL\" + nombreProtoc + ".pdf");
                rptProt.Close();




                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                mmsg.To.Add(destinatario);


                mmsg.Subject = "Envío de estudio solicitado";
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;



                mmsg.Body = "Adjunto al presente los estudios solicitados";
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = false;

                mmsg.Attachments.Add(new Attachment(@"P:\ESTUDIOS POR MAIL\" + nombreExamen + ".pdf"));
                mmsg.Attachments.Add(new Attachment(@"P:\ESTUDIOS POR MAIL\" + nombreProtoc + ".pdf"));

                mmsg.From = new System.Net.Mail.MailAddress("resultados@mepryl.com.ar", "Centro Médico Mepryl");


                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                cliente.Credentials =
                    new System.Net.NetworkCredential("resultados@mepryl.com.ar", "resultados2016");

                cliente.Port = 587;
                cliente.EnableSsl = false;

                cliente.Host = "mail.mepryl.com.ar";
                cliente.Send(mmsg);
                panelMail.Visible = false;
                MessageBox.Show("¡Envío realizado correctamente!", "Enviar examen", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                actualizarValorEnvioMail();
                mmsg.Dispose();

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void actualizarValorEnvioMail()
        {
            List<string> lista = SQLConnector.generarListaParaProcedure("@id", "@valor");
            SQLConnector.executeProcedure("sp_TipoExamenDePaciente_UpdateMail", lista,
                new Guid(dgvExamenes.CurrentRow.Cells[0].Value.ToString()), "1");
            cargarExamenes();
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            panelMail.Visible = false;
            tbDestinatario.Text = "";
        }

        private void dgvExamenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                if (e.ColumnIndex == 16)
                {
                    cambiarEstado(dgvExamenes.Rows[e.RowIndex].Cells[0].Value.ToString(), dgvExamenes.Rows[e.RowIndex].Cells[16].Value.ToString(),
                        "sp_TipoExamenDePaciente_UpdateRM");
                }

                if (e.ColumnIndex == 23)
                {
                    cambiarEstado(dgvExamenes.Rows[e.RowIndex].Cells[0].Value.ToString(), dgvExamenes.Rows[e.RowIndex].Cells[23].Value.ToString(),
                        "sp_TipoExamenDePaciente_UpdateRetiro");
                }
            }
        }

        private void cambiarEstado(string idTe, string valor, string procedure)
        {
            string val = "0";
            if (valor == "False") { val = "1"; }
            List<string> l = SQLConnector.generarListaParaProcedure("@id", "@valor");
            SQLConnector.executeProcedure(procedure, l, idTe, val);
            cargarExamenes();

        }

        private void dgvExamenes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (dgvExamenes.CurrentCell.ColumnIndex == 7) { abrirClinico(dgvExamenes.CurrentCell.RowIndex); }
                if (dgvExamenes.CurrentCell.ColumnIndex == 9) { abrirLaboratorio(dgvExamenes.CurrentCell.RowIndex); }
                if (dgvExamenes.CurrentCell.ColumnIndex == 11) { abrirRX(dgvExamenes.CurrentCell.RowIndex); }
                if (dgvExamenes.CurrentCell.ColumnIndex == 13) { abrirCard(dgvExamenes.CurrentCell.RowIndex); }

                if (dgvExamenes.CurrentCell.ColumnIndex == 15)
                {
                    Utilidades.abrirFormulario(this.MdiParent, new frmDictamenFinal(this, dgvExamenes.Rows[dgvExamenes.SelectedCells[0].RowIndex]), new Configuracion());
                }
                puntero = dgvExamenes.CurrentCell.RowIndex;
                celda = dgvExamenes.CurrentCell.ColumnIndex;
            }
        }

        private void botonCambiarClub_Click(object sender, EventArgs e)
        {
            if (dgvExamenes.Rows.Count > 0 && dgvExamenes.SelectedCells[0].RowIndex != -1)
            {
                mostrarCambioClub();
            }
        }

        private void mostrarCambioClub()
        {
            panelNuevoClub.Visible = false;
            tbRow.Text = dgvExamenes.SelectedCells[0].RowIndex.ToString();
            lblJugador.Text = tbDNIExamen.Text + " - " +
            tbApellidoExamen.Text + " " + tbNombreExamen.Text;
            cargarClub();
            panelCambioDeClub.Visible = true;
            botAgregar.Enabled = true;
            cargarCombo(cboLigaExamen, "select l.id, l.descripcion from dbo.Liga l where l.id != '00000000-0000-0000-0000-000000000000' order by l.descripcion asc");
        }

        private void cargarClub()
        {
            string idTe = dgvExamenes.Rows[Convert.ToInt16(tbRow.Text)].Cells[0].Value.ToString();
            DataTable ligaYClubes = SQLConnector.obtenerTablaSegunConsultaString(@"select cte.id,l.id, l.descripcion as Liga, c.id, c.descripcion as Club
            from dbo.clubesPorTipoExamen cte inner join dbo.Club c on cte.idClub = c.id
            inner join dbo.Liga l on c.ligaID = l.id where cte.idTipoExamen = '" + idTe + "'");
            dgvClubExamen.DataSource = ligaYClubes;
            dgvClubExamen.Columns[0].Visible = false;
            dgvClubExamen.Columns[1].Visible = false;
            dgvClubExamen.Columns[3].Visible = false;
        }

        private void cargarCombo(ComboBox cb, string consulta)
        {
            DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString(consulta);
            cb.DataSource = tabla;
            cb.DisplayMember = "descripcion";
            cb.ValueMember = "id";
            cb.SelectedIndex = -1;
        }

        private void botAgregar_Click(object sender, EventArgs e)
        {
            panelNuevoClub.Visible = true;
            botAgregar.Enabled = false;
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClubExamen.SelectedRows.Count > 0)
            {
                List<string> listDelete = SQLConnector.generarListaParaProcedure("@id");
                SQLConnector.executeProcedure("sp_clubesPorTipoExamen_DeleteById", listDelete, Convert.ToInt32(dgvClubExamen.SelectedRows[0].Cells[0].Value.ToString()));
                cargarClub();

            }
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            if (cboClubExamen.SelectedIndex != -1 && !juegaEnLiga())
            {
                string idTe = dgvExamenes.Rows[Convert.ToInt16(tbRow.Text)].Cells[0].Value.ToString();
                string idClub = cboClubExamen.SelectedValue.ToString();
                List<string> listAdd = SQLConnector.generarListaParaProcedure("@idTipoExamen", "@idClub");
                SQLConnector.executeProcedure("sp_clubesPorTipoExamen_Add", listAdd, new Guid(idTe), new Guid(idClub));
                panelNuevoClub.Visible = false;
                botAgregar.Enabled = true;
                cboLiga.SelectedIndex = -1;
                cboClubExamen.DataSource = null;
                cargarClub();
            }
        }

        private void botCerrar_Click(object sender, EventArgs e)
        {
            panelCambioDeClub.Visible = false;
            cargarExamenes();
        }

        private void cboLigaExamen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarCombo(cboClubExamen, "select c.id, c.descripcion from dbo.Club c where c.ligaID = '" + cboLigaExamen.SelectedValue.ToString() +
           "' order by c.descripcion asc");
        }

        private void tbBuscarEmpresa_TextChanged(object sender, EventArgs e)
        {            
            buscarEmpresa();
        }

        private void buscarEmpresa()
        {
            string filtro = "";
            if (tbBuscarEmpresa.Text != "")
            {
                filtro = "Empresa like '%" + tbBuscarEmpresa.Text + "%'";
            }
            llenarDgvEmpresa();
            DataTable empresa = (DataTable)dgvEmpresa.DataSource;
            DataRow[] r = empresa.Select(filtro);
            DataTable aux = new DataTable();
            aux.Columns.Add("Id");
            aux.Columns.Add("Empresa");
            foreach (DataRow row in r)
            {
                aux.Rows.Add(row[0], row[1]);
            }
            dgvEmpresa.DataSource = aux;
            dgvEmpresa.Columns[0].Visible = false;
        }

        private void botBuscarPorApellido_Click(object sender, EventArgs e)
        {
            frmBusquedaPaciente f = new frmBusquedaPaciente(this);
            f.ShowDialog();
        }

        public void recibirIdPaciente(string idPaciente)
        {
            base.recuperarObjetoPorId(idPaciente);
            modoEditable();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (tbDNI.Text != string.Empty)
            {
                frmFotoPaciente fFoto = new frmFotoPaciente(tbDNI.Text, 'P');
                fFoto.ShowDialog();
                cargarImagen();
            }
            else
            {
                MessageBox.Show("Debe ingresar primero el DNI del paciente", "Foto paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }      
        }

        private void cargarImagen()
        {
            try
            {
                DirectorioFotos = new UbicacionFotos();
                //GRV - Ramírez - Modificado
                //System.IO.FileStream fs = new System.IO.FileStream(@"S:/FOTOS/" + tbDNI.Text + ".jpg", FileMode.Open, FileAccess.Read);
                System.IO.FileStream fs = new System.IO.FileStream(DirectorioFotos.UbicacionFotopreventiva() + "\\" + tbDNI.Text + ".jpg", FileMode.Open, FileAccess.Read);
                pictureBox1.Image = Image.FromStream(fs);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = Image.FromStream(fs);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                fs.Dispose();
                fs.Close();
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        // GRV - Modificado
        private string VerificaPerteneceCategoria()
        {
            string strRespuesta = "";
            int intAnioCatFinal = 0;
            int intAnioCatInicial = 0;
            
            for (int i = 0; i < dgvClubesAsignados.Rows.Count; i++)
            {
                intAnioCatFinal = PacientePre.AnioCategoriaJuvenil(dgvClubesAsignados.Rows[i].Cells[1].Value.ToString()); // ID de Liga
                intAnioCatInicial = PacientePre.AnioCategoriaInfantil(dgvClubesAsignados.Rows[i].Cells[1].Value.ToString());

                if (PacientePre.VerificaClub(dgvClubesAsignados.Rows[i].Cells[1].Value.ToString()))
                {
                    if (PacientePre.PerteneceClubAFA(dgvClubesAsignados.Rows[i].Cells[3].Value.ToString())) // ID de Club
                    {
                        //if (PacientePre.PerteneceLigaInfantil(dgvClubesAsignados.Rows[i].Cells[3].Value.ToString()))
                        //{
                        //    //if (intAnioCatJuvenil >= int.Parse(lblCategoria.Text))
                        //    //    strRespuesta = "El club '" + dgvClubesAsignados.Rows[i].Cells[4].Value.ToString() + "' pertenece a la liga '" + dgvClubesAsignados.Rows[i].Cells[2].Value.ToString() + "' y admite categorías desde " + intAnioCatInfantil.ToString() + ".\nLa categoría del paciente no corresponde a esta liga. \nVerifique la configuración de Ligas.";
                        //}
                    }
                    if (!(intAnioCatInicial >= int.Parse(lblCategoria.Text) && intAnioCatFinal <= int.Parse(lblCategoria.Text)))
                    {
                        strRespuesta = dgvClubesAsignados.Rows[i].Cells[2].Value.ToString() + "\nEl jugador ha cambiado de divisional, debe actualizar Liga y Club";
                    }
                }
            }

            return strRespuesta;
        }

        private string VerificaAceptaMenores()
        {
            string strRespuesta = "";
            int intAnioCatInfantil = 0;

            for (int i = 0; i < dgvClubesAsignados.Rows.Count; i++)
            {
                intAnioCatInfantil = PacientePre.AnioCategoriaInfantil(dgvClubesAsignados.Rows[i].Cells[1].Value.ToString());

                if (!PacientePre.VerificaAdmiteMenores(dgvClubesAsignados.Rows[i].Cells[1].Value.ToString()))
                {
                    if (intAnioCatInfantil < int.Parse(lblCategoria.Text))
                        strRespuesta = "La categoría del paciente es menor a la aceptada por la liga. '" + dgvClubesAsignados.Rows[i].Cells[2].Value.ToString() + "' \nEsta liga no admite menores.";
                }
            }

            return strRespuesta;
        }

        private bool DebeExamenRX()
        {
            bool blnResultado = false;

            if (dgvClubesAsignados.Rows.Count == 0)
            {
                blnResultado = PacientePre.DebeRealizarExamenRX(tbDNI.Text);
            }
            else
            {            
                for (int i = 0; i < dgvClubesAsignados.Rows.Count; i++)
                {
                    if (PacientePre.VerificaRX(dgvClubesAsignados.Rows[i].Cells[1].Value.ToString()))
                    {
                        blnResultado = PacientePre.DebeRealizarExamenRX(tbDNI.Text);
                    }
                }                
            }

            return blnResultado;
        }

        private void EliminarRegistroLigaComboBox()
        {
            int intAnioCatFinal = 0;
            int intAnioCatInicial = 0;

            intAnioCatFinal = PacientePre.AnioCategoriaJuvenil("345FFF9B-45C2-4CD5-87EC-47E944E8236D"); // ID de Liga
            intAnioCatInicial = PacientePre.AnioCategoriaInfantil("345FFF9B-45C2-4CD5-87EC-47E944E8236D");

            //cboLiga.Items.Clear();

            if (!(string.IsNullOrEmpty(lblCategoria.Text)))
            {
                //if (!(intAnioCatInicial >= int.Parse(lblCategoria.Text) && intAnioCatFinal <= int.Parse(lblCategoria.Text)))
                //{
                //    //cboLiga.Items.Remove("345FFF9B-45C2-4CD5-87EC-47E944E8236D");
                //    cboLiga.DataSource = PacientePre.ListarLigaNoInfantil();
                //    cboLiga.ValueMember = "id";
                //    cboLiga.DisplayMember = "descripcion";
                //    cboLiga.SelectedIndex = 0;
                //}
                //else
                //{
                //    cboLiga.DataSource = PacientePre.ListarLigaNoJuvenil();
                //    cboLiga.ValueMember = "id";
                //    cboLiga.DisplayMember = "descripcion";
                //    cboLiga.SelectedIndex = 0;
                //}

                ////if ((int.Parse(lblCategoria.Text) > intAnioCatInicial) && !string.IsNullOrEmpty(VerificaAceptaMenores()))
                //if ((int.Parse(lblCategoria.Text) > intAnioCatInicial) && !PacientePre.VerificaAdmiteMenores("345FFF9B-45C2-4CD5-87EC-47E944E8236D"))
                //{
                //    cboLiga.DataSource = PacientePre.ListarLigaNoJuvenilNoInfantil();
                //    cboLiga.ValueMember = "id";
                //    cboLiga.DisplayMember = "descripcion";
                //    cboLiga.SelectedIndex = 0;
                //}
                try
                {
                    if (int.Parse(lblCategoria.Text) < 1900)
                    {
                        cboLiga.DataSource = PacientePre.ListarLigaActiva();
                        cboLiga.ValueMember = "id";
                        cboLiga.DisplayMember = "descripcion";
                        cboLiga.SelectedIndex = 0;
                        cboLiga.Text = "A DESIGNAR";
                    }
                    else
                    {
                        cboLiga.DataSource = PacientePre.ListaLigaPorCategoria(int.Parse(lblCategoria.Text));
                        cboLiga.ValueMember = "id";
                        cboLiga.DisplayMember = "descripcion";
                        cboLiga.SelectedIndex = 0;
                        cboLiga.Text = "A DESIGNAR";
                    }
                }
                catch (System.ArgumentOutOfRangeException ex)
                {
                    cboLiga.DataSource = null;
                }                
            }
        }

        private void cboLiga_Click(object sender, EventArgs e)
        {
            dgvClub.DataSource = null;
            EliminarRegistroLigaComboBox();            
        }

        private void verificaClubIngresado()
        {
            //if (blnPresionarQuitar == true)
                MostrarMensaje(DebeExamenRXParaNuevoClubIngresado());

            blnPresionarQuitar = false;
        }

        private bool DebeExamenRXParaNuevoClubIngresado()
        {            
            int intAnioCatInicial = 0;
            bool hacerPlaca = false;

            try
            {
                hacerPlaca = DebeExamenRX();

                if (!PacientePre.ExistePaciente(tbDNI.Text))
                    hacerPlaca = true;

                for (int i = 0; i < dgvClubesAsignados.Rows.Count; i++)
                {
                    if (PacientePre.ClubPerteneceAFA(dgvClubesAsignados.Rows[i].Cells[1].Value.ToString()))
                    {
                        intAnioCatInicial = PacientePre.AnioCategoriaInfantil(dgvClubesAsignados.Rows[i].Cells[1].Value.ToString());
                        break;
                    }
                    else
                    {
                        intAnioCatInicial = PacientePre.AnioCategoriaInfantil(dgvClubesAsignados.Rows[i].Cells[1].Value.ToString());
                    }
                }

                if (intAnioCatInicial == int.Parse(lblCategoria.Text))
                    hacerPlaca = true;

                if (DateTime.Today.Year == PacientePre.FechaExamenEsteAnio(rglEntidad.dni.ToString()).Year)
                    hacerPlaca = false;

                if (PacientePre.ObtenerCodigoTipoExamen(rglEntidad.dni.ToString()) == 266)
                    hacerPlaca = true;
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show("Al parecer ha ocurrido un error al establecer la fecha de nacimiento", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return hacerPlaca;
        }

        private void dgvClubesAsignados_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //verificaClubIngresado();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmClubMantenimiento frmClub = new frmClubMantenimiento();
            frmClub.Show();
        }

        private void dgvExamenes_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            try
            {
                //if (filtroTabla != null && filtroTabla.Length > 0)
                //{
                //    if (e.RowIndex != nroFila)
                //    {
                //        nroFila = e.RowIndex;
                //        //progressBar.PerformStep();
                //    }
                //    int rowI = e.RowIndex;
                //    int colI = e.ColumnIndex;
                //    if (colI == 10 || colI == 12 || colI == 14 || colI == 16 || colI == 21
                //        || colI == 23 || colI == 25 || colI == 27)
                //    {
                //        try
                //        {
                //            if (filtroTabla[rowI][colI] != System.DBNull.Value)
                //            {
                //                byte[] imageBuffer = (byte[])filtroTabla[rowI][colI];
                //                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                //                e.Value = Image.FromStream(ms);
                //            }
                //            else
                //            {
                //                e.Value = null;
                //            }
                //        }
                //        catch (System.IO.IOException ex)
                //        {
                //            //
                //        }
                //    }
                //    else
                //    {

                //        e.Value = filtroTabla[rowI][colI];
                //    }
                //    try
                //    {

                //        if (colI == 3)
                //        {
                //            if (Convert.ToInt16(e.Value) < 200) { dgvExamenes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gainsboro; }
                //        }
                //        if (colI == 18)
                //        {
                //            dgvExamenes.Rows[e.RowIndex].Cells[18].Style.BackColor =
                //                (Color)filtroTabla[e.RowIndex][28];
                //        }
                //    }
                //    catch (System.FormatException ex)
                //    {
                //        //
                //    }

                //}
                //string strHola = "";
                //strHola = "hoa";
            }
            catch (System.IO.FileNotFoundException ex)
            {

            }
        }       

        //private bool LigaAdmiteMenores(string strIdLiga)
        //{
        //    bool blnRespuesta = false;

        //    if (!PacientePre.VerificaAdmiteMenores(strIdLiga))
        //    {
        //        if (intAnioCatInfantil < int.Parse(lblCategoria.Text))
        //    }

        //    return blnRespuesta;
        //}

        private bool MuestraMensajeSiPacienteTieneLiga()
        {
            bool blnRetorno = false;
            
            for (int i = 0; i < dgvClubesAsignados.Rows.Count; i++)
            {
                if(cboLiga.Text == dgvClubesAsignados.Rows[i].Cells[2].Value.ToString())
                {
                    MessageBox.Show("El paciente ya juega en esa liga. Seleccione otra o verifique la categoría");
                    blnRetorno = true;                    
                    return blnRetorno;
                }
            }
            return blnRetorno;
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            txtMail.CharacterCasing = CharacterCasing.Lower;
        }

        private void txtMail_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbBuscarClub_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down) && dgvClub.Rows.Count > 0)
            {
                dgvClub.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {                
                tbBuscarClub.Focus();
            }
        }

        private void btnUbicar_Click(object sender, EventArgs e)
        {
            ExamenSeleccionado();
        }

        private void ExamenSeleccionado()
        {
            if (dgvExamenes.Rows.Count > 0)
            {
                celda = dgvExamenes.SelectedCells[0].ColumnIndex;
                foreach (DataGridViewCell cell in dgvExamenes.SelectedCells)
                {
                    if (celda == cell.ColumnIndex)
                    {
                        DataGridViewRow row = dgvExamenes.Rows[cell.RowIndex];
                        row.Cells[2].Value.ToString();
                        row.Cells[3].Value.ToString();
                        //if (row.Cells[9].Value.ToString() != "0" && row.Cells[1

                        AbrirCarperta(row.Cells[3].Value.ToString(), Convert.ToDateTime(row.Cells[2].Value.ToString()));
                    }
                }
            }
        }

        private void AbrirCarperta(string NroOrden, DateTime Fecha)
        {
            string strDia = "";
            string strMes = "";
            string strAnio = "";
            string strDirecConsolTemp = "";
            string strNombreMes = "";
            string strFechaCorta = "";
            string strFiltro = NroOrden + " -*";

            strDia = UtilMepryl.NroDia(Fecha).ToUpper();
            strMes = UtilMepryl.NroMes(Fecha).ToUpper();
            strNombreMes = UtilMepryl.NombreMes(Int32.Parse(strMes)).ToUpper();
            strAnio = Convert.ToString(Fecha.Year).ToUpper();
            strFechaCorta = strDia + "-" + strMes + "-" + strAnio;

            strDirecConsolTemp = DirectorioConsolidaddo() + "\\" + strAnio + "\\" + strMes + "-" + strNombreMes
                                                          + "\\" + strFechaCorta + "\\";

            try
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDirecConsolTemp);
                foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
                {
                    if (System.IO.File.Exists(fi.FullName))
                        //System.Diagnostics.Process.Start(fi.DirectoryName);
                        UbicarArchivoDisco(fi.FullName);
                    else
                        MessageBox.Show("No se encontro el archivo de consolidado en la ruta.\n" + fi.DirectoryName, "Examenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                MessageBox.Show("No se encontro el archivo de consolidado.", "Examenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string DirectorioConsolidaddo()
        {
            CapaNegocioMepryl.ConsolidarReportes Consolidar = new CapaNegocioMepryl.ConsolidarReportes();
            string strDirectorioConsolidar = "";

            DataTable dt = Consolidar.Directorios();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    strDirectorioConsolidar = r.ItemArray[5].ToString();
                }
            }

            return strDirectorioConsolidar;
        }

        private void UbicarArchivoDisco(string FullPath)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select, \"" + FullPath + "\"");
        }        
    }
}