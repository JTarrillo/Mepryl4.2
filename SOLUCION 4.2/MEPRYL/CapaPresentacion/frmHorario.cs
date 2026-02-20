using CapaNegocio;
using CapaPresentacionBase;
using Comunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UserControls;

namespace CapaPresentacion
{
    public partial class frmHorario : CapaPresentacionBase.frmBaseGrillaABM
    {
        private string str;
        int Solucion;
        public Horario rglEntidad;
        public string seleccionarProfesionalID = Utilidades.ID_VACIO;
        public string strIdProfesional = "";
        private CapaNegocioMepryl.TipoExamen tipoExamen = new CapaNegocioMepryl.TipoExamen();
        private string strNombreEspecialidad = "";
        private static int contadorCargarEspecialidad = 0;
        private bool cargandoDatos = false;
        private bool inicializandoProfesional = false;
        private bool cambiandoProfesional = false;

        private bool ignorarEventoMotivo = false;

        public frmHorario(Configuracion config, ModoApertura modo, bool maximizar = true)
    : base(config, modo)
        {
            //InitializeComponent();
            //Aca iba lo que ahora está en inicializacionEspecifica(); 
            if (maximizar)
                this.WindowState = FormWindowState.Maximized;

            // Control de botón Agregar según tipo de usuario
            if (this.configuracion != null && Configuracion.usuario != null && Configuracion.usuario.Tipo == "ADMINISTRADOR")
            {
                this.habilitarBotonAgregar = true;
                this.habilitarBotonEliminar = true;
                this.permisoAlta = true;
                this.permisoModificacion = true; // Esto habilita el botón Modificar
                this.permisoBaja = true;
            }
            else
            {
                this.habilitarBotonAgregar = false;
                this.habilitarBotonEliminar = false;
                this.permisoAlta = false;
                this.permisoModificacion = false; // Esto deshabilita el botón Modificar
                this.permisoBaja = false;
            }
        }

        // GRV - Nuevo constructor
        public frmHorario()
        {
            //
            // Sincronización de combos en cascada
            InitializeComponent();
            cboMotivo.SelectionChangeCommitted += cboMotivo_SelectionChangeCommitted;
            cboEspecialidad.SelectionChangeCommitted += cboEspecialidad_SelectionChangeCommitted;
            cboSubtipo.SelectionChangeCommitted += cboSubtipo_SelectionChangeCommitted;
            dgItems.SelectionChanged += dgItems_SelectionChanged;

        }
        // Cargar tipos de examen al cambiar motivo
        private void cboMotivo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cargandoDatos) return;
            cargarEspecialidad();
            cboEspecialidad.SelectedIndex = -1;
            cboSubtipo.DataSource = null;
        }

        private void dgItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgItems.CurrentRow != null && dgItems.CurrentRow.Index >= 0)
            {
                // Llama al método que sincroniza los combos con la fila seleccionada

            }
        }


        // Cargar subtipos al cambiar tipo de examen
        private void cboEspecialidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("[DEBUG] >>> Entró a cboEspecialidad_SelectionChangeCommitted");
            if (cboEspecialidad.SelectedIndex != -1 && cboEspecialidad.SelectedValue != null)
            {
                string idPadre = cboEspecialidad.SelectedValue.ToString();
                System.Diagnostics.Debug.WriteLine($"[DEBUG] idPadre={idPadre}");
                cargarSubtipos(""); // No seleccionar subtipo por defecto
                // Actualiza el nombre de la especialidad seleccionada
                strNombreEspecialidad = cboEspecialidad.Text;
            }
            else
            {
                cargarSubtipos("");
                strNombreEspecialidad = "";
            }
        }

        // Filtrar grilla por subtipo
        private void cboSubtipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboSubtipo.SelectedIndex != -1 && cboSubtipo.SelectedValue != null)
            {
                string idSubtipo = cboSubtipo.SelectedValue.ToString();
                string filtro = $"especialidadID = '{idSubtipo}'";
                inicializarGrilla(new HorarioFactory(this.configuracion, this.EntidadNombre), filtro);
            }
        }

        // Cargar subtipos del tipo seleccionado
        private void cargarSubtipos(string idSeleccionar)
        {
            try
            {
                cboSubtipo.DataSource = null;

                if (cboEspecialidad.SelectedIndex == -1 || cboEspecialidad.SelectedValue == null)
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG][EXCEPTION] cboEspecialidad sin selección o valor nulo en cargarSubtipos");
                    return;
                }

                // DEBUG: Mostrar el valor de idPadre usado en la consulta
                string idPadre = cboEspecialidad.SelectedValue.ToString();
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Valor de idPadre usado en cargarSubtipos: '{idPadre}'");

                // Ejecutar la consulta directamente y mostrar los resultados
                string sql = $@"
                SELECT e.*
                FROM dbo.Especialidad e
                WHERE e.Padre = 0 
                  AND e.IdPadre = '{idPadre}'
                  AND e.estado = 1
                  AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
                ORDER BY e.descripcion";
                DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(sql);

                // DEBUG: Mostrar los subtipos cargados y sus IdPadre
                if (dt != null)
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG] Subtipos cargados en cargarSubtipos:");
                    foreach (DataRow row in dt.Rows)
                    {
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] id={row["id"]}, descripcion={row["descripcion"]}, IdPadre={row["IdPadre"]}, Padre={row["Padre"]}, estado={row["estado"]}");
                    }
                }

                bool existe = false;
                foreach (DataRow row in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(idSeleccionar) && row["id"].ToString().Equals(idSeleccionar, StringComparison.OrdinalIgnoreCase))
                        existe = true;
                }
                cboSubtipo.DataSource = dt;
                cboSubtipo.ValueMember = "id";
                cboSubtipo.DisplayMember = "descripcion";
                // DEBUG: Mostrar el contenido real del DataTable asignado al combo
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Asignando DataSource a cboSubtipo. dt.Rows.Count = {dt?.Rows.Count ?? 0}");
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] (cboSubtipo) id={row["id"]}, descripcion={row["descripcion"]}, IdPadre={row["IdPadre"]}, Padre={row["Padre"]}, estado={row["estado"]}");
                    }
                }
                System.Diagnostics.Debug.WriteLine($"[DEBUG] idSeleccionar='{idSeleccionar}', existe={existe}");
                if (!string.IsNullOrEmpty(idSeleccionar) && existe)
                    cboSubtipo.SelectedValue = idSeleccionar;
                else
                    cboSubtipo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG][EXCEPTION] cargarSubtipos: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Error en cargarSubtipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public frmHorario(ModoApertura modo)
            : base(modo)
        {
            //InitializeComponent();
            //Aca iba lo que ahora está en inicializacionEspecifica();            
        }

        public frmHorario(Configuracion config, ModoApertura modo, frmBasePrincipal parentForm)
            : base(config, modo, parentForm)
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
            inicializandoProfesional = true; // <-- Activa la bandera

            EntidadNombre = "Horario";
            seleccionarHorariosProfesional();

            if (seleccionarProfesionalID != Utilidades.ID_VACIO)
                cboProfesional.SelectedValue = seleccionarProfesionalID;

            inicializandoProfesional = false; // <-- Desactiva la bandera
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
                navegador.agregarControl(new CapsulaControl((Control)cboEspecialidad));
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
            cboProfesional.Enabled = false;
        }


        protected override void inicializarComponentes()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt = SQLConnector.obtenerTablaSegunConsultaString("select id as ID, (apellido + ' ' + nombres) as NOMBRE from dbo.Profesional WHERE TieneHorario = 1 order by NOMBRE");
            cboProfesional.DataSource = dt;
            cboProfesional.ValueMember = "ID";
            cboProfesional.DisplayMember = "NOMBRE";
            cboProfesional.SelectedIndex = -1;

            DataTable dt1 = new DataTable();
            dt1 = SQLConnector.obtenerTablaSegunConsultaString(@"
        SELECT DISTINCT e.id AS ID, e.descripcion AS NOMBRE 
        FROM dbo.Especialidad e
        WHERE e.Padre = 1 
          AND e.estado = 1
          AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
          -- ✅ FALTA AQUI: Solo padres con SUBTIPOS ACTIVOS
          AND EXISTS (
              SELECT 1 FROM dbo.Especialidad s
              WHERE s.IdPadre = e.id 
                AND s.Padre = 0 
                AND s.estado = 1
                AND s.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
          )
        ORDER BY e.descripcion");

            cboEspecialidad.DataSource = dt1;
            cboEspecialidad.ValueMember = "ID";
            cboEspecialidad.DisplayMember = "NOMBRE";
            cboEspecialidad.SelectedIndex = -1;

            cargarMotivoConsulta();
            inicializarEntidad();
        }

        private void cargarMotivoConsulta()
        {
            cboMotivo.DataSource = tipoExamen.cargarMotivosDeConsulta();
            cboMotivo.ValueMember = "id";
            cboMotivo.DisplayMember = "nombre";
            cboMotivo.SelectedIndex = -1;
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
                dgItems.Columns["especialidadTexto"].HeaderText = "Subtipo de Examen";
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

                dgItems.Columns["profesionalTexto"].Width = 250;

                dgItems.AutoResizeColumns();

                if (dgItems.Rows.Count > 0)
                {
                    strNombreEspecialidad = dgItems.Rows[0].Cells["especialidadTexto"].Value.ToString();
                    // DEBUG: Mostrar la especialidad de cada fila en la grilla
                    for (int i = 0; i < dgItems.Rows.Count; i++)
                    {
                        var esp = dgItems.Rows[i].Cells["especialidadTexto"].Value?.ToString();
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] Fila {i}: Especialidad = {esp}");
                    }
                }
                else
                {
                    strNombreEspecialidad = "";
                    System.Diagnostics.Debug.WriteLine("[DEBUG] La grilla no tiene filas.");
                }

                CargarMotivoPorEspecialidad();

                //cboEspecialidad.Text = strNombreEspecialidad;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                cboEspecialidad.Text = strNombreEspecialidad;
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
                inicializarEntidad();
                rglEntidad.id = new Guid(tbId.Text);
                rglEntidad.codigo = tbCodigo.Text;
                rglEntidad.profesionalID = new Guid(Utilidades.comboObtenerID(ref cboProfesional));
                rglEntidad.profesionalTexto = cboProfesional.Text;

                // Usar subtipo si está seleccionado, si no el tipo
                if (cboSubtipo.SelectedValue != null && cboSubtipo.SelectedIndex != -1)
                {
                    rglEntidad.especialidadID = new Guid(cboSubtipo.SelectedValue.ToString());
                    rglEntidad.especialidadTexto = cboSubtipo.Text;
                }
                else
                {
                    rglEntidad.especialidadID = new Guid(cboEspecialidad.SelectedValue.ToString());
                    rglEntidad.especialidadTexto = cboEspecialidad.Text;
                }

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

            if (ControlaHorario())
            {
                return "El registro no se puede borrar. El horario está vigente y tiene turnos asignados. ";
            }

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
                // Mostrar el subtipo si está seleccionado, si no el tipo
                string especialidadTexto;
                if (cboSubtipo.SelectedValue != null && cboSubtipo.SelectedIndex != -1)
                {
                    especialidadTexto = cboSubtipo.Text;
                }
                else
                {
                    especialidadTexto = cboEspecialidad.Text;
                }

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

                // Selecciona la primera celda visible para evitar error de celda invisible
                int firstVisibleCol = -1;
                foreach (DataGridViewColumn col in dgItems.Columns)
                {
                    if (col.Visible)
                    {
                        firstVisibleCol = col.Index;
                        break;
                    }
                }
                if (dgItems.Rows.Count > 0 && firstVisibleCol >= 0)
                {
                    dgItems.CurrentCell = dgItems.Rows[0].Cells[firstVisibleCol];
                }

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

        private string ObtenerEspecialidadPorID(string id)
        {
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(
                "select descripcion from dbo.Especialidad where id = '" + id + "'"
            );
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "";
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
            if (cambiandoProfesional) return;
            base.mostrarDatosObjeto();
            cargandoDatos = true;
            try
            {
                rglEntidad = (Horario)base.rglEntidad;

                System.Diagnostics.Debug.WriteLine($"[DEBUGF] mostrarDatosObjeto: profesionalID={rglEntidad.profesionalID}, especialidadID={rglEntidad.especialidadID}");

                // 1. Seleccionar profesional
                cboProfesional.SelectedValue = rglEntidad.profesionalID.ToString();
                System.Diagnostics.Debug.WriteLine($"[DEBUGF] cboProfesional.SelectedValue set to {cboProfesional.SelectedValue}");

                // 2. Seleccionar motivo y cargar especialidades
                string idMotivo = ObtenerIdMotivo(rglEntidad.especialidadID.ToString());

                // 2.1 Si es subtipo, obtener el motivo del tipo padre y si es distinto, cambiar y recargar antes de seguir
                DataTable dtEsp = SQLConnector.obtenerTablaSegunConsultaString($"SELECT Padre, IdPadre FROM dbo.Especialidad WHERE id = '{rglEntidad.especialidadID}'");
                if (dtEsp.Rows.Count > 0)
                {
                    object padreObj = dtEsp.Rows[0]["Padre"];
                    string idPadre = dtEsp.Rows[0]["IdPadre"].ToString();
                    bool esSubtipo = false;
                    if (padreObj is bool)
                        esSubtipo = !(bool)padreObj;
                    else if (padreObj is int)
                        esSubtipo = ((int)padreObj == 0);
                    else
                        esSubtipo = padreObj.ToString() == "0";

                    if (esSubtipo && !string.IsNullOrEmpty(idPadre))
                    {
                        DataTable dtPadre = SQLConnector.obtenerTablaSegunConsultaString($"SELECT idMotivoConsulta FROM dbo.Especialidad WHERE id = '{idPadre}'");
                        if (dtPadre.Rows.Count > 0)
                        {
                            string idMotivoPadre = dtPadre.Rows[0]["idMotivoConsulta"].ToString();
                            if (idMotivoPadre != idMotivo)
                            {
                                System.Diagnostics.Debug.WriteLine($"[DEBUGF][AUTO] Cambiando motivo de consulta a {idMotivoPadre} porque el tipo padre tiene motivo diferente.");
                                cargarMotivoConsulta();
                                SetComboSelectedValue(cboMotivo, idMotivoPadre);
                                System.Diagnostics.Debug.WriteLine($"[DEBUGF] cboMotivo.SelectedValue set to {idMotivoPadre}");
                                cargarEspecialidad();
                                // En vez de return, volver a llamar a mostrarDatosObjeto para completar la sincronización
                                mostrarDatosObjeto();
                                return;
                            }
                        }
                    }
                }

                // Primero cargar motivos y especialidades, luego asignar el valor seleccionado
                // ...dentro de mostrarDatosObjeto()...
                cargarMotivoConsulta();

                // --- Agrega aquí el debug ---
                var dtMotivo = cboMotivo.DataSource as DataTable;
                if (dtMotivo != null)
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG] Motivos disponibles en cboMotivo:");
                    foreach (DataRow row in dtMotivo.Rows)
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] id={row["id"]}, nombre={row["nombre"]}");
                }
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Intentando asignar cboMotivo.SelectedValue = {idMotivo}");

                // Luego sigue la asignación:
                ignorarEventoMotivo = true;
                cboMotivo.SelectedValue = idMotivo;
                ignorarEventoMotivo = false;
                System.Diagnostics.Debug.WriteLine($"[DEBUGF] cboMotivo.SelectedValue set to {idMotivo}");
                cargarEspecialidad();
                var dtEspCombo = cboEspecialidad.DataSource as DataTable;
                if (dtEspCombo != null)
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUGF] DataTable Especialidad IDs: {string.Join(", ", dtEspCombo.AsEnumerable().Select(r => r["ID"].ToString()))}");
                }
                System.Diagnostics.Debug.WriteLine($"[DEBUGF] cargarEspecialidad ejecutado");

                // --- FIX: Asegurar que el tipo padre esté presente en el DataSource antes de la selección (caso Medico de Planta y similares) ---
                // Solo si es subtipo y hay idPadre
                DataTable dtEspPadreCheck = SQLConnector.obtenerTablaSegunConsultaString($"SELECT Padre, IdPadre FROM dbo.Especialidad WHERE id = '{rglEntidad.especialidadID}'");
                if (dtEspPadreCheck.Rows.Count > 0)
                {
                    object padreObjCheck = dtEspPadreCheck.Rows[0]["Padre"];
                    string idPadreCheck = dtEspPadreCheck.Rows[0]["IdPadre"].ToString();
                    bool esSubtipoCheck = false;
                    if (padreObjCheck is bool)
                        esSubtipoCheck = !(bool)padreObjCheck;
                    else if (padreObjCheck is int)
                        esSubtipoCheck = ((int)padreObjCheck == 0);
                    else
                        esSubtipoCheck = padreObjCheck.ToString() == "0";

                    if (esSubtipoCheck && !string.IsNullOrEmpty(idPadreCheck))
                    {
                        var dtEspComboCheck = cboEspecialidad.DataSource as DataTable;
                        bool padreEnCombo = dtEspComboCheck != null && dtEspComboCheck.AsEnumerable().Any(r => r["ID"].ToString().Equals(idPadreCheck, StringComparison.OrdinalIgnoreCase));
                        if (!padreEnCombo && dtEspComboCheck != null)
                        {
                            System.Diagnostics.Debug.WriteLine($"[DEBUGF][FIX] No se encontró el tipo padre idPadre={idPadreCheck} en cboEspecialidad tras cargarEspecialidad. Se agregará temporalmente al DataSource.");
                            DataTable dtPadreRowFix = SQLConnector.obtenerTablaSegunConsultaString($"SELECT id as ID, descripcion as NOMBRE FROM dbo.Especialidad WHERE id = '{idPadreCheck}'");
                            if (dtPadreRowFix.Rows.Count > 0)
                            {
                                dtEspComboCheck.ImportRow(dtPadreRowFix.Rows[0]);
                                cboEspecialidad.DataSource = dtEspComboCheck;
                                cboEspecialidad.ValueMember = "ID";
                                cboEspecialidad.DisplayMember = "NOMBRE";
                                Application.DoEvents();
                                System.Diagnostics.Debug.WriteLine($"[DEBUGF][FIX] Tipo padre idPadre={idPadreCheck} agregado temporalmente tras cargarEspecialidad.");
                            }
                        }
                    }
                }

                // 4. Verificar si el ID es subtipo o tipo (Padre es bit, puede ser bool/int/string)
                DataTable dt = SQLConnector.obtenerTablaSegunConsultaString($"SELECT Padre, IdPadre FROM dbo.Especialidad WHERE id = '{rglEntidad.especialidadID}'");
                if (dt.Rows.Count > 0)
                {
                    object padreObj = dt.Rows[0]["Padre"];
                    string idPadre = dt.Rows[0]["IdPadre"].ToString();
                    bool esSubtipo = false;
                    if (padreObj is bool)
                        esSubtipo = !(bool)padreObj;
                    else if (padreObj is int)
                        esSubtipo = ((int)padreObj == 0);
                    else
                        esSubtipo = padreObj.ToString() == "0";

                    System.Diagnostics.Debug.WriteLine($"[DEBUGF] especialidadID={rglEntidad.especialidadID}, Padre={padreObj}, IdPadre={idPadre}, esSubtipo={esSubtipo}");

                    if (esSubtipo)
                    {
                        // El motivo ya está alineado, buscar el padre en el combo
                        var dtEspCombo2 = cboEspecialidad.DataSource as DataTable;
                        cboEspecialidad.SelectionChangeCommitted -= cboEspecialidad_SelectionChangeCommitted;

                        // Buscar el padre en el DataSource y agregarlo si no existe
                        // ...dentro de mostrarDatosObjeto()...
                        bool padreEncontrado = dtEspCombo2 != null && dtEspCombo2.AsEnumerable()
                            .Any(r => r["ID"].ToString().Equals(idPadre, StringComparison.OrdinalIgnoreCase)); if (!padreEncontrado)
                        {
                            System.Diagnostics.Debug.WriteLine($"[DEBUGF][WARNING] No se encontró el tipo padre idPadre={idPadre} en cboEspecialidad. Se agregará temporalmente al DataSource.");
                            if (dtEspCombo2 != null)
                            {
                                DataTable dtPadreRow = SQLConnector.obtenerTablaSegunConsultaString($"SELECT id as ID, descripcion as NOMBRE FROM dbo.Especialidad WHERE id = '{idPadre}'");
                                if (dtPadreRow.Rows.Count > 0)
                                {
                                    dtEspCombo2.ImportRow(dtPadreRow.Rows[0]);
                                    cboEspecialidad.DataSource = dtEspCombo2;
                                    cboEspecialidad.ValueMember = "ID";
                                    cboEspecialidad.DisplayMember = "NOMBRE";
                                    Application.DoEvents();
                                    cboEspecialidad.SelectedValue = idPadre;
                                    if (cboEspecialidad.SelectedValue == null || cboEspecialidad.SelectedValue.ToString() == "")
                                    {
                                        int idx = cboEspecialidad.FindStringExact(dtPadreRow.Rows[0]["NOMBRE"].ToString());
                                        if (idx >= 0)
                                            cboEspecialidad.SelectedIndex = idx;
                                    }
                                    Application.DoEvents();
                                    System.Diagnostics.Debug.WriteLine($"[DEBUGF][INFO] Tipo padre idPadre={idPadre} agregado temporalmente y seleccionado en cboEspecialidad. SelectedValue={cboEspecialidad.SelectedValue}, SelectedIndex={cboEspecialidad.SelectedIndex}");
                                }
                                else
                                {
                                    System.Diagnostics.Debug.WriteLine($"[DEBUGF][ERROR] No se pudo obtener datos del tipo padre idPadre={idPadre}.");
                                    cboEspecialidad.SelectionChangeCommitted += cboEspecialidad_SelectionChangeCommitted;
                                    return;
                                }
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine($"[DEBUGF][ERROR] cboEspecialidad.DataSource está vacío. No se puede seleccionar tipo padre ni cargar subtipos.");
                                cboEspecialidad.SelectionChangeCommitted += cboEspecialidad_SelectionChangeCommitted;
                                return;
                            }
                        }
                        else
                        {
                            cboEspecialidad.SelectedValue = idPadre;
                            if (cboEspecialidad.SelectedValue == null || cboEspecialidad.SelectedValue.ToString() == "")
                            {
                                var padreRow = dtEspCombo2.AsEnumerable().FirstOrDefault(r => r["ID"].ToString().Equals(idPadre, StringComparison.OrdinalIgnoreCase)); if (padreRow != null)
                                {
                                    int idx = cboEspecialidad.FindStringExact(padreRow["NOMBRE"].ToString());
                                    if (idx >= 0)
                                        cboEspecialidad.SelectedIndex = idx;
                                }
                            }
                            Application.DoEvents();
                        }
                        // Forzar actualización del combo antes de cargar subtipos
                        Application.DoEvents();
                        cboEspecialidad.SelectionChangeCommitted += cboEspecialidad_SelectionChangeCommitted;
                        System.Diagnostics.Debug.WriteLine($"[DEBUGF] cboEspecialidad.SelectedValue set to (tipo padre) {idPadre}, SelectedIndex={cboEspecialidad.SelectedIndex}");
                        // Siempre cargar subtipos usando el ID del padre
                        cargarSubtipos(rglEntidad.especialidadID.ToString());
                        var dtSub = cboSubtipo.DataSource as DataTable;
                        if (dtSub != null)
                        {
                            System.Diagnostics.Debug.WriteLine($"[DEBUGF] DataTable Subtipo IDs: {string.Join(", ", dtSub.AsEnumerable().Select(r => r["id"].ToString()))}");
                        }
                        System.Diagnostics.Debug.WriteLine($"[DEBUGF] cargarSubtipos ejecutado con idSeleccionar={rglEntidad.especialidadID}");
                        // Seleccionar el subtipo si existe
                        if (dtSub != null && dtSub.AsEnumerable().Any(r => r["id"].ToString().Equals(rglEntidad.especialidadID.ToString(), StringComparison.OrdinalIgnoreCase)))
                        {
                            cboSubtipo.SelectedValue = rglEntidad.especialidadID.ToString();
                            System.Diagnostics.Debug.WriteLine($"[DEBUGF] cboSubtipo.SelectedValue set to {cboSubtipo.SelectedValue}");
                        }
                        else
                        {
                            cboSubtipo.SelectedIndex = -1;
                            System.Diagnostics.Debug.WriteLine($"[DEBUGF] cboSubtipo.SelectedIndex set to -1 (no existe subtipo)");
                        }
                    }
                    else
                    {
                        // Es tipo: seleccionar tipo y limpiar subtipos
                        // Esperar a que el DataSource de cboEspecialidad esté listo y contenga el id
                        int intentos = 0;
                        while ((cboEspecialidad.DataSource as DataTable)?.AsEnumerable().All(r => !r["ID"].ToString().Equals(rglEntidad.especialidadID.ToString(), StringComparison.OrdinalIgnoreCase)) == true && intentos < 10)
                        {
                            System.Diagnostics.Debug.WriteLine($"[DEBUGF] Esperando que cboEspecialidad contenga especialidadID={rglEntidad.especialidadID} (intento {intentos + 1})");
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(50);
                            intentos++;
                        }
                        cboEspecialidad.SelectedValue = rglEntidad.especialidadID.ToString();
                        System.Diagnostics.Debug.WriteLine($"[DEBUGF] cboEspecialidad.SelectedValue set to (tipo) {rglEntidad.especialidadID}");
                        cargarSubtipos("");
                        var dtSub = cboSubtipo.DataSource as DataTable;
                        if (dtSub != null)
                        {
                            System.Diagnostics.Debug.WriteLine($"[DEBUGF] DataTable Subtipo IDs: {string.Join(", ", dtSub.AsEnumerable().Select(r => r["id"].ToString()))}");
                        }
                        System.Diagnostics.Debug.WriteLine($"[DEBUGF] cargarSubtipos ejecutado con idSeleccionar vacio");
                        cboSubtipo.SelectedIndex = -1;
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUGF] No se encontró especialidadID={rglEntidad.especialidadID} en la tabla Especialidad");
                }

                System.Diagnostics.Debug.WriteLine($"[DEBUGF] FINAL: cboEspecialidad.SelectedValue={cboEspecialidad.SelectedValue}, cboSubtipo.SelectedValue={cboSubtipo.SelectedValue}");

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
                System.Diagnostics.Debug.WriteLine($"[DEBUGF] Exception en mostrarDatosObjeto: {ex.Message}");
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            finally
            {
                cargandoDatos = false;
            }
        }

        private string ObtenerIdMotivo(string idEspecialidad)
        {
            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(
                "select mc.id, mc.nombre from dbo.MotivoDeConsulta mc " +
                "inner join dbo.Especialidad e on mc.id = e.idMotivoConsulta " +
                "where e.id = '" + idEspecialidad + "'"
            );

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }

        protected override void limpiarFormulario()
        {
            try
            {
                tbObservaciones.Text = "";
                //cboProfesional.Enabled = true;
            }
            catch (System.NullReferenceException ex)
            {
                //
            }
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
        private void SetComboSelectedValue(ComboBox combo, object value)
        {
            if (combo.DataSource is DataTable dt)
            {
                var existe = dt.AsEnumerable().Any(r => r[combo.ValueMember].ToString() == value?.ToString());
                if (existe)
                {
                    combo.SelectedValue = value;
                }
                else
                {
                    combo.SelectedIndex = -1;
                }
            }
            else
            {
                combo.SelectedIndex = -1;
            }
        }
        private void cboaEspecialidad_Load(object sender, EventArgs e)
        {

        }
        private void cboProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoDatos) return; // Protege contra ejecución durante mostrarDatosObjeto

            cambiandoProfesional = true; // Activa la bandera para evitar recursividad y pisado de motivo

            cargarMotivoConsulta();
            if (cboProfesional.SelectedValue != null)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Profesional seleccionado: ID={cboProfesional.SelectedValue}, Nombre={cboProfesional.Text}");
                // También puedes usar:
                // MessageBox.Show($"Profesional seleccionado: {cboProfesional.Text} (ID: {cboProfesional.SelectedValue})");
            }

            CargaMedico();
            seleccionarHorariosProfesional();

        }


        private void cargarEspecialidad(bool forzarTodos = false)
        {
            string idMotivo = cboMotivo.SelectedValue?.ToString() ?? "NULL";
            string idPadre = "";

            // Chequeo: Si no hay motivo seleccionado, limpiar y salir
            if (cboMotivo.SelectedIndex == -1 || cboMotivo.SelectedValue == null || cboMotivo.SelectedValue.ToString() == "")
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG][cargarEspecialidad] No hay motivo seleccionado. Limpiando combos y saliendo.");
                cboEspecialidad.DataSource = null;
                cboSubtipo.DataSource = null;
                return;
            }

            // Solo buscar el padre si hay una especialidad seleccionada, NO estamos agregando y NO se fuerza mostrar todos
            if (!forzarTodos && rglEntidad != null && rglEntidad.especialidadID != Guid.Empty && edicion != ModoEdicion.AGREGANDO)
            {
                DataTable dtPadre = SQLConnector.obtenerTablaSegunConsultaString(
                    $"SELECT IdPadre FROM dbo.Especialidad WHERE id = '{rglEntidad.especialidadID}' AND Padre = 0");
                if (dtPadre.Rows.Count > 0)
                    idPadre = dtPadre.Rows[0]["IdPadre"].ToString();
                System.Diagnostics.Debug.WriteLine($"[DEBUG][cargarEspecialidad] idPadre detectado={idPadre}");
            }

            string sql;
            if (!string.IsNullOrEmpty(idPadre))
            {
                // Solo el tipo padre relacionado
                sql = $@"
                SELECT id AS ID, descripcion AS NOMBRE
                FROM dbo.Especialidad
                WHERE id = '{idPadre}'
                  AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
                ORDER BY descripcion";
                System.Diagnostics.Debug.WriteLine($"[DEBUG][cargarEspecialidad] SQL para tipo padre: {sql}");
            }
            else
            {
                // ✅ MEJORADO: Solo tipos padre CON SUBTIPOS ACTIVOS
                sql = $@"
                SELECT DISTINCT e.id AS ID, e.descripcion AS NOMBRE
                FROM dbo.Especialidad e
                WHERE e.Padre = 1
                  AND e.idMotivoConsulta = '{idMotivo}'
                  AND e.estado = 1
                  AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
                  -- ✅ Solo padres que tienen SUBTIPOS ACTIVOS
                  AND EXISTS (
                      SELECT 1 FROM dbo.Especialidad s
                      WHERE s.IdPadre = e.id 
                        AND s.Padre = 0 
                        AND s.estado = 1
                        AND s.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
                  )
                ORDER BY e.descripcion";
                System.Diagnostics.Debug.WriteLine($"[DEBUG][cargarEspecialidad] SQL para tipos del motivo (con subtipos activos): {sql}");
            }

            DataTable dt1 = SQLConnector.obtenerTablaSegunConsultaString(sql);

            // DEBUG: Mostrar cantidad de filas obtenidas y sus valores
            System.Diagnostics.Debug.WriteLine($"[DEBUG][cargarEspecialidad] dt1.Rows.Count={(dt1 != null ? dt1.Rows.Count : 0)}");
            if (dt1 != null)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG][cargarEspecialidad] ID={row["ID"]}, NOMBRE={row["NOMBRE"]}");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG][cargarEspecialidad] dt1 es null");
            }

            cboEspecialidad.DataSource = dt1;
            cboEspecialidad.ValueMember = "ID";
            cboEspecialidad.DisplayMember = "NOMBRE";
            cboEspecialidad.SelectedIndex = -1;
            cboSubtipo.DataSource = null; // Limpia subtipos al cambiar motivo
        }













        private void seleccionarHorariosProfesional()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] >>> seleccionarHorariosProfesional: EntidadNombre={this.EntidadNombre}, ProfesionalID={Utilidades.comboObtenerID(ref cboProfesional)}");
                if (this.EntidadNombre != "Grilla")
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG] Llamando a inicializarGrilla para el profesional seleccionado");
                    inicializarGrilla(new HorarioFactory(this.configuracion, this.EntidadNombre), "profesionalID='" + Utilidades.comboObtenerID(ref cboProfesional) + "'");
                }

                System.Diagnostics.Debug.WriteLine($"[DEBUG] dgItems.Rows.Count = {dgItems.Rows.Count}");
                // Selecciona la primera fila si hay datos
                if (dgItems.Rows.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG] Hay filas en la grilla, seleccionando la primera fila");
                    dgItems.ClearSelection();
                    dgItems.Rows[0].Selected = true;
                    // Buscar la primera celda visible para asignar como CurrentCell
                    DataGridViewRow row = dgItems.Rows[0];
                    DataGridViewCell firstVisibleCell = null;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Visible)
                        {
                            firstVisibleCell = cell;
                            break;
                        }
                    }
                    if (firstVisibleCell != null)
                    {
                        dgItems.CurrentCell = firstVisibleCell;
                        System.Diagnostics.Debug.WriteLine($"[DEBUG] CurrentCell asignada a columna: {firstVisibleCell.OwningColumn.Name}");
                    }

                    // Desactiva la bandera y muestra los datos de la primera fila
                    cambiandoProfesional = false;
                    mostrarDatosObjeto();
                }
                else
                {
                    // Limpia los combos si no hay filas en la grilla
                    cambiandoProfesional = false;
                    cboMotivo.SelectedIndex = -1;
                    cboEspecialidad.DataSource = null;
                    cboSubtipo.DataSource = null;
                    System.Diagnostics.Debug.WriteLine("[DEBUG] No hay filas en la grilla, combos limpiados");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG][EXCEPTION] seleccionarHorariosProfesional: {ex.Message}");
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }
        private bool ControlaHorario()
        {
            bool blnRetorno = false;
            CapaNegocioMepryl.Turno turno = new CapaNegocioMepryl.Turno();

            DateTime dtDesde = Convert.ToDateTime(dgItems.Rows[dgItems.CurrentCell.RowIndex].Cells[2].Value.ToString());
            DateTime dtHasta = Convert.ToDateTime(dgItems.Rows[dgItems.CurrentCell.RowIndex].Cells[3].Value.ToString());
            DateTime dtActual = DateTime.Now;

            if (dtHasta > dtActual)
            {

                //blnRetorno = turno.ExisteTurnoFecha(cboProfesional.SelectedValue.ToString(), cboEspecialidad.SelectedValue.ToString());
                //cboProfesional.SelectedValue.ToString();
                //MessageBox.Show("El registro no se puede borrar. El horario está vigente y tiene turnos asignados.", "Horarios",MessageBoxButtons.OK,MessageBoxIcon.Warning);                
            }

            return blnRetorno;
        }

        private void tabPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPrincipal.SelectedIndex == 1)
                panel1.Size = new Size(813, 297);
            if (tabPrincipal.SelectedIndex == 0)
                panel1.Size = new Size(813, 126);
        }

        private void frmHorario_Load(object sender, EventArgs e)
        {
            tabPrincipal.SelectedIndex = 1;
            panel1.Size = new Size(813, 297);
            //tabPrincipal.SelectedTab = tabPage1;

            CargaMedico();

        }

        private void CargaMedico()
        {
            if (!string.IsNullOrEmpty(strIdProfesional))
            {
                cboProfesional.SelectedValue = strIdProfesional;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarEspecialidad()
        {
            string idMotivo = cboMotivo.SelectedValue?.ToString() ?? "NULL";
            string idPadre = "";

            System.Diagnostics.Debug.WriteLine($"[DEBUG][cargarEspecialidad] cboMotivo.SelectedIndex={cboMotivo.SelectedIndex}, SelectedValue={cboMotivo.SelectedValue}, idMotivo={idMotivo}");

            if (cboMotivo.SelectedIndex == -1 || cboMotivo.SelectedValue == null || cboMotivo.SelectedValue.ToString() == "")
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG][cargarEspecialidad] No hay motivo seleccionado. Limpiando combos y saliendo.");
                cboEspecialidad.DataSource = null;
                cboSubtipo.DataSource = null;
                return;
            }

            if (rglEntidad != null && rglEntidad.especialidadID != Guid.Empty && edicion != ModoEdicion.AGREGANDO)
            {
                DataTable dtPadre = SQLConnector.obtenerTablaSegunConsultaString(
                    $"SELECT IdPadre FROM dbo.Especialidad WHERE id = '{rglEntidad.especialidadID}' AND Padre = 0");
                if (dtPadre.Rows.Count > 0)
                    idPadre = dtPadre.Rows[0]["IdPadre"].ToString();
                System.Diagnostics.Debug.WriteLine($"[DEBUG][cargarEspecialidad] idPadre detectado={idPadre}");
            }

            string sql;
            if (!string.IsNullOrEmpty(idPadre))
            {
                sql = $@"
                SELECT id AS ID, descripcion AS NOMBRE
                FROM dbo.Especialidad
                WHERE id = '{idPadre}'
                  AND id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
                ORDER BY descripcion";
                System.Diagnostics.Debug.WriteLine($"[DEBUG][cargarEspecialidad] SQL para tipo padre: {sql}");
            }
            else
            {
                sql = $@"
            SELECT DISTINCT e.id AS ID, e.descripcion AS NOMBRE
            FROM dbo.Especialidad e
            WHERE e.Padre = 1
              AND e.idMotivoConsulta = '{idMotivo}'
              AND e.estado = 1
              AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
              AND EXISTS (
                  SELECT 1 FROM dbo.Especialidad s
                  WHERE s.IdPadre = e.id 
                    AND s.Padre = 0 
                    AND s.estado = 1
                    AND s.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
              )
            ORDER BY e.descripcion";
                System.Diagnostics.Debug.WriteLine($"[DEBUG][cargarEspecialidad] SQL para tipos del motivo (con subtipos activos): {sql}");
            }

            DataTable dt1 = SQLConnector.obtenerTablaSegunConsultaString(sql);

            System.Diagnostics.Debug.WriteLine($"[DEBUG][cargarEspecialidad] dt1.Rows.Count={(dt1 != null ? dt1.Rows.Count : 0)}");
            if (dt1 != null)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG][cargarEspecialidad] ID={row["ID"]}, NOMBRE={row["NOMBRE"]}");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG][cargarEspecialidad] dt1 es null");
            }

            cboEspecialidad.DataSource = dt1;
            cboEspecialidad.ValueMember = "ID";
            cboEspecialidad.DisplayMember = "NOMBRE";
            cboEspecialidad.SelectedIndex = -1;
            cboSubtipo.DataSource = null;
        }

        private void CargarMotivoPorEspecialidad()
        {
            // Si no hay especialidad seleccionada, limpiar combo
            if (string.IsNullOrEmpty(strNombreEspecialidad) || cboEspecialidad.SelectedValue == null)
            {
                cboEspecialidad.DataSource = null;
                cboEspecialidad.SelectedIndex = -1;
                return;
            }

            string idEspecialidad = cboEspecialidad.SelectedValue.ToString();

            DataTable dt1 = new DataTable();
            dt1 = SQLConnector.obtenerTablaSegunConsultaString($@"
        SELECT DISTINCT e.id AS ID, e.descripcion AS NOMBRE 
        FROM dbo.Especialidad e
        WHERE e.Padre = 1 
          AND e.estado = 1
          AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
          AND e.idMotivoConsulta = (SELECT idMotivoConsulta FROM dbo.Especialidad WHERE id = '{idEspecialidad}')
          -- ✅ Solo padres que tienen SUBTIPOS ACTIVOS
          AND EXISTS (
              SELECT 1 FROM dbo.Especialidad s
              WHERE s.IdPadre = e.id 
                AND s.Padre = 0 
                AND s.estado = 1
                AND s.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
          )
        ORDER BY e.descripcion");

            if (dt1 != null)
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] CargarMotivoPorEspecialidad - Filas de dt1:");
                foreach (DataRow row in dt1.Rows)
                {
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] ID={row["ID"]}, NOMBRE={row["NOMBRE"]}");
                }
            }

            cboEspecialidad.DataSource = dt1;
            cboEspecialidad.ValueMember = "ID";
            cboEspecialidad.DisplayMember = "NOMBRE";
            cboEspecialidad.SelectedIndex = -1;

            // Restaurar la selección anterior
            cboEspecialidad.Text = strNombreEspecialidad;

            if (cboEspecialidad.SelectedValue != null)
            {
                DataTable dt = tipoExamen.FiltrarMotivoConsulta(tipoExamen.ObtenerMotivoConsulta(cboEspecialidad.SelectedValue.ToString()));

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboMotivo.Text = dt.Rows[i][1].ToString();
                    }
                }
            }
        }

        private void butCancelar_Click_1(object sender, EventArgs e)
        {
            cboEspecialidad.Text = strNombreEspecialidad;
            cboProfesional.Enabled = true;
        }

        private void cboMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoDatos || ignorarEventoMotivo) return;

            ignorarEventoMotivo = true; // <-- Protege el evento
            try
            {
                if (cboMotivo.SelectedIndex != -1 && cboMotivo.SelectedValue.ToString() != "" && Solucion > 0)
                {
                    // Limpia selección de especialidad y subtipo
                    cboEspecialidad.SelectedIndex = -1;
                    cboSubtipo.DataSource = null;
                    cargarEspecialidad(true);
                }
                Solucion++;
            }
            finally
            {
                ignorarEventoMotivo = false; // <-- Siempre libera la bandera
            }
        }
        private void cboSubtipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public override void SaludarHolaMundo()
        {
            string profesionalID = cboProfesional.SelectedValue.ToString();
            var frm = new CapaPresentacion.frmReplicarHorario();
            frm.ShowDialog();
        }

        private void cboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
