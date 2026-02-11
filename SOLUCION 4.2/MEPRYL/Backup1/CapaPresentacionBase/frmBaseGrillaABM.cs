using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocioBase;
using Comunes;

namespace CapaPresentacionBase
{
    public partial class frmBaseGrillaABM : Form
    {
        public string EntidadNombre = "Grilla";
        public EntidadBase rglEntidad;
        public frmBaseBusqueda frmBusqueda;
        public NavegadorFormulario navegador;
        public Configuracion configuracion;
        public enum ModoApertura
        {
            NUEVO_REGISTRO,
            CONSULTA,
            CONSULTA_FICHA

        }
        public ModoApertura modoApertura;
        public bool buscandoPalabrasClave = false;
        public bool recuperandoObjeto = false;
        public bool busquedaInstantanea = true;

        public bool habilitarBotonAgregar = true;
        public bool habilitarBotonEliminar = true;

        public ModoEdicion edicion = ModoEdicion.VACIO;

        public bool permisoAlta = true;
        public bool permisoModificacion = true;
        public bool permisoBaja = true;

        protected Color colorTitulo;


        public frmBaseGrillaABM()
        {
            InitializeComponent();
        }

        public frmBaseGrillaABM(Configuracion config, ModoApertura modo)
        {
            InitializeComponent();

            this.configuracion = config;

            inicializarComponentes();

            this.modoApertura = modo;
            inicializacionEspecifica();

        }

        public void reiniciarFormulario(ModoApertura modo)
        {
            inicializarComponentes();
            this.modoApertura = modo;
            inicializacionEspecifica();
            formularioLoad();
        }

        //Métodos virtuales
        public virtual CapaNegocioBase.EntidadFactoryBase crearNegEntidadFac() { return null; }
        public virtual frmBaseBusqueda crearFormularioBusqueda() { return null; }
        public virtual string validarDatosIngresados() { return null; }
        public virtual string validarNegocio() { return null; }
        public virtual Resultado alta() { return null; }
        public virtual Resultado modificar() { return null; }
        public virtual string borrar(string id) { return null; }
        protected virtual void inicializarEntidad() { }
        protected virtual void cargarObjetoReglas() { }
        public virtual void agregarRegistroGrilla(ref Resultado resultado) { }
        protected virtual void buscarPalabrasClave() { }
        protected virtual void editarRegistro() { }
        protected virtual void actualizarRegistro() { }
        protected virtual void inicializarTabla() { }
        protected virtual void eliminarRegistroGrilla() { }
        protected virtual void recuperarObjetoPorCodigo() { }
        protected virtual void imprimirListado() { }
        protected virtual void inicializacionEspecifica() { } //Es nuevo y hay que agregarlo a los sistemas ya hechos al 22/10/2010
        protected virtual void actualizarFiltro(int formaBusqueda) { }
        protected virtual void pintarRenglon(DataGridViewCellFormattingEventArgs e) { }
        protected virtual void cerrandoFormulario(object sender, FormClosingEventArgs e)
        {
            if (this.edicion == ModoEdicion.AGREGANDO || this.edicion == ModoEdicion.MODIFICANDO)
            {
                if (MessageBox.Show("Si cierra ahora, no se guardarán los cambios del registro actual. \r\n\r\n¿Desea cerrar de todas formas?", "Datos sin guardar",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
            if (!e.Cancel)
                rglEntidad = null;
        }
        
        //

        protected void actualizarRegistro(ref DataGridView dg)
        {
            try
            {
                int i = dg.CurrentCell.RowIndex;
                if (i >= 0)
                {
                    
                    foreach (DataGridViewColumn columna in dg.Columns)
                    {
                        if (rglEntidad.campos.ContainsKey(columna.DataPropertyName))
                        {
                            int row = dg.CurrentCell.RowIndex;
                            dg.Rows[row].Cells[columna.Name].Value = rglEntidad.campos[columna.DataPropertyName];
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }
        protected virtual void butAgregar_Click(object sender, EventArgs e)
        {
            //if (rglEntidad != null)
            //{
                tbCodigo.Text = "";
            //}
            tabPrincipal.SelectedIndex = 1;
            edicion = ModoEdicion.AGREGANDO;
            limpiarFormulario();
            tbId.Text = Utilidades.ID_VACIO;
            modoEditable();
            cambiarEtiquetaEdicion();
            rglEntidad = null;
        }

        protected virtual void cambiarEtiquetaEdicion()
        {
            switch (edicion)
            {
                case ModoEdicion.AGREGANDO:
                    {
                        //lbEstadoEdicion.Text = "AGREGANDO...";
                        //lbEstadoEdicion.BackColor = Color.Blue;
                        lbTitulo.Text = "Agregando " + this.Text + "...";
                        lbTitulo.BackColor = Color.Red;
                        break;
                    }
                case ModoEdicion.MODIFICANDO:
                    {
                        //lbEstadoEdicion.Text = "MODIFICANDO...";
                        //lbEstadoEdicion.BackColor = Color.Green;
                        lbTitulo.Text = "Modificando " + this.Text + "...";
                        lbTitulo.BackColor = Color.Red;
                        break;
                    }
                case ModoEdicion.VACIO:
                    {
                        //lbEstadoEdicion.Text = "";
                        //lbEstadoEdicion.BackColor = Color.Transparent;
                        lbTitulo.Text = this.Text;
                        lbTitulo.BackColor = this.colorTitulo;
                        break;
                    }
            }
        }

        protected void butModificar_Click(object sender, EventArgs e)
        {
            //modificarClick();
            if (dgItems.RowCount>0 && this.permisoModificacion)
                if (dgItems.CurrentRow.Index > -1)
                    editarRegistro();
        }

        protected void modificarClick()
        {

            edicion = ModoEdicion.MODIFICANDO;
            modoEditable();
            cambiarEtiquetaEdicion();
        }

        protected void butEliminar_Click(object sender, EventArgs e)
        {
           if (confirmar("¿Está seguro que desea eliminar el registro?") == DialogResult.Yes)
            {
                string resultado = borrar(tbId.Text);
                if (resultado == "")
                {
                    limpiarFormulario();
                    tbId.Text = Utilidades.ID_VACIO;
                    modoEstatico(false);
                    edicion = ModoEdicion.VACIO;
                    eliminarRegistroGrilla();
                    cambiarEtiquetaEdicion();
                }
                else
                    mostrarError(resultado);
            }
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        protected virtual void aceptar()
        {
            try
            {
                Resultado resultado = new Resultado();

                resultado.mensaje = validarDatosIngresados(); //Valida tipos de dato pero no reglas de negocio.
                if (resultado.mensaje == "")
                {
                    cargarObjetoReglas();


                    resultado.mensaje = validarNegocio();

                    if (resultado.mensaje == "")
                    {
                        if (edicion == ModoEdicion.AGREGANDO)
                        {
                            resultado = alta();
                            if (resultado.mensaje == "" && resultado.objeto!=null)
                                agregarRegistroGrilla(ref resultado);
                        }
                        else if (edicion == ModoEdicion.MODIFICANDO)
                        {
                            resultado = modificar();
                            //Actualiza el registro de la grilla
                            actualizarRegistro();
                        }
                        else
                            resultado.mensaje = "No se puede realizar esta operación.";

                        if (resultado.mensaje == "" && resultado.objeto!=null)
                        {
                            rglEntidad = (CapaNegocioBase.EntidadBase)resultado.objeto;
                            tbId.Text = rglEntidad.id.ToString();
                            tbCodigo.Text = rglEntidad.codigo;
                            modoEstatico(true);
                            dgItems.Focus();

                            dgItems_CurrentCellChanged(dgItems, new EventArgs());
                        }
                    }
                }
                if (resultado.mensaje != "")
                    mostrarError(resultado.mensaje);
                else
                {
                    edicion = ModoEdicion.VACIO;
                    cambiarEtiquetaEdicion();
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        protected void butCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        protected virtual void cancelar()
        {
            if (tbId.Text != Utilidades.ID_VACIO) //Si era una edición
            {
                mostrarDatosObjeto();
            }
            else
            {
                limpiarFormulario();
            }
            
            tbCodigo.Focus();
            edicion = ModoEdicion.VACIO;
            cambiarEtiquetaEdicion();
            modoEstatico(rglEntidad != null);

            dgItems_CurrentCellChanged(dgItems, new EventArgs());
        }

        
        protected void recuperarObjeto(string id)
        {
            try
            {
                tbId.Text = id;

                EntidadFactoryBase negEntidadFac = crearNegEntidadFac();

                EntidadBase entidadAux = negEntidadFac.getById(tbId.Text);

                if (entidadAux != null)
                {
                    rglEntidad = entidadAux;
                    mostrarDatosObjeto();
                    butModificar.Enabled = true; 
                    if (this.permisoModificacion)
                        butModificar.Visible = true;
                    if (this.habilitarBotonEliminar && this.permisoBaja)
                    {
                        butEliminar.Enabled = true;
                        butEliminar.Visible = true;
                    }
                }

                entidadAux = null;

                negEntidadFac = null;
            }
            catch (Exception exError)
            {
                mostrarError(exError.Message);
            }
        }


        protected void recuperarObjetoPorCodigo(string codigo)
        {
            try
            {
                EntidadFactoryBase negEntidadFac = crearNegEntidadFac();

                EntidadBase entidadAux = negEntidadFac.getByCodigo(codigo);

                if (entidadAux != null)
                {
                    rglEntidad = entidadAux;
                    mostrarDatosObjeto();
                    butModificar.Enabled = true;
                    if (this.permisoModificacion)
                        butModificar.Visible = true;
                    if (this.habilitarBotonEliminar && this.permisoBaja)
                    {
                        butEliminar.Enabled = true;
                        butEliminar.Visible = true;
                    }
                }

                entidadAux = null;

                negEntidadFac = null;
            }
            catch (Exception exError)
            {
                mostrarError(exError.Message);
            }
        }

        private void cargarObjetoRecuperado()
        {
            if (tbId.Text != Utilidades.ID_VACIO)
            {
                try
                {
                    mostrarDatosObjeto();
                }
                catch (Exception exError)
                {
                    limpiarFormulario();
                    mostrarError(exError.Message);
                }
            }
            modoEstatico(rglEntidad != null);
        }

        protected void frmBaseGrillaABM_Load(object sender, EventArgs e)
        {
            modoEstatico(false);
            tbBusqueda.Select();

            //Aquí iba lo que está en formularioLoad();
            formularioLoad();
        }

        protected void formularioLoad()
        {
            if (this.modoApertura == ModoApertura.NUEVO_REGISTRO)
            {
                this.abrirComoNuevo();
            }
            if (this.modoApertura == ModoApertura.CONSULTA)
            {
                this.abrirComoConsulta();
            }
            if (this.modoApertura == ModoApertura.CONSULTA_FICHA)
            {
                this.abrirComoConsultaFicha();
            }
 
        }

        protected void frmBaseGrillaABM_FormClosing(object sender, FormClosingEventArgs e)
        {
            cerrandoFormulario(sender, e);
        }

        //
        //Para redefinir en cada formulario
        //
        protected virtual void modoEstatico(bool hayObjetoActivo)
        {
            
            tbCodigo.Enabled = true;
            tbCodigo.Focus();
            //butBuscar.Enabled = true;
            if (this.habilitarBotonAgregar && this.permisoAlta)
            {
                butAgregar.Enabled = true;
                butAgregar.Visible = true;
            }
            butModificar.Enabled = hayObjetoActivo;
            
            butAceptar.Enabled = false;
            butCancelar.Enabled = false;

            dgItems.Enabled = true;

            if (this.permisoModificacion)
                butModificar.Visible = hayObjetoActivo;

            if (this.habilitarBotonAgregar && this.permisoBaja)
            {
                butEliminar.Enabled = hayObjetoActivo;
                butEliminar.Visible = hayObjetoActivo;
            }
            butAceptar.Visible = false;
            butCancelar.Visible = false;

            //Deshabilita la busqueda
            foreach (Control con in tabPage2.Controls)
                con.Enabled = true;
        }

        protected virtual void modoEditable()
        {
            tbCodigo.Enabled = false;
            //butBuscar.Enabled = false;
            butAgregar.Enabled = false;
            butModificar.Enabled = false;
            butEliminar.Enabled = false;
            butAceptar.Enabled = true;
            butCancelar.Enabled = true;
            dgItems.Enabled = false;
            this.Focus();

            butAgregar.Visible = false;
            butModificar.Visible = false;
            butEliminar.Visible = false;
            butAceptar.Visible = true;
            butCancelar.Visible = true;

            //Deshabilita la busqueda
            foreach (Control con in tabPage2.Controls)
                con.Enabled = false;
        }

        protected void mostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected DialogResult confirmar(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        protected virtual void nuevoFormularioBusqueda()
        {
            try
            {
                frmBusqueda = crearFormularioBusqueda();
                frmBusqueda.objDelegateDevolverID = new frmBaseBusqueda.DelegateDevolverID(recuperarObjeto);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
            }
        }
        //
        protected virtual void limpiarFormulario()
        {
        }
        //
        protected virtual void mostrarDatosObjeto()
        {
            try
            {
                tbId.Text = rglEntidad.id.ToString();
                tbCodigo.Text = rglEntidad.codigo.ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }
        //

        //
        protected virtual void crearObjetoMapeo()
        {
        }
        //
        protected virtual string validar()
        {
            return "";
        }
        //
        protected virtual void inicializarComponentes()
        {
            try
            {
                tbId.Text = Utilidades.ID_VACIO;
                cargarNavegadorFormulario();

                this.colorTitulo = lbTitulo.BackColor;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }
        //
        //Carga el Navegador de Formularios
        protected virtual void cargarNavegadorFormulario()
        {
            try
            {
                navegador = new NavegadorFormulario(this.configuracion);

                //Carga las teclas rapidas primero
                //navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butBuscar, (char)Keys.F1));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butAceptar, (char)Keys.F5));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butCancelar, (char)Keys.F6));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butAgregar, (char)Keys.F7));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butModificar, (char)Keys.F8));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butEliminar, (char)Keys.F9));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butImprimir, (char)Keys.F10));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butSalir, (char)Keys.Escape));

                //Carga los controles
                navegador.agregarControl(new CapsulaControl((Control)tbCodigo));

                //Agrega los handlers para todos los controles del control contenedor
                navegador.agregarHandlersContenedor(this);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }


        protected void habilitarControles(ref GroupBox contenedor, ref DataGridView dg, bool habilitar)
        {
            try
            {
                foreach (Control cont in contenedor.Controls)
                {
                   
                    if (cont.GetType() == typeof(TextBox))
                    {
                        if (habilitar)
                            ((TextBox)cont).BackColor = Color.White;
                        else
                            ((TextBox)cont).BackColor = SystemColors.ButtonFace;
                    }
                    cont.Enabled = habilitar;
                   
                }

                if (dg.CurrentRow != null && this.edicion==ModoEdicion.MODIFICANDO)
                {
                    DataGridViewBand band = (DataGridViewBand)dg.CurrentRow;

                    DataGridViewCellStyle estilo = new DataGridViewCellStyle();
                    if (habilitar)
                        estilo.BackColor = Color.GreenYellow;
                    else
                        estilo.BackColor = Color.White;

                    band.DefaultCellStyle = estilo;
                }
                
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        protected void inicializarGrilla(EntidadFactoryBase ef, string filtro)
        {
            inicializarGrilla(ef, filtro, 0);
        }
        protected void inicializarGrilla(EntidadFactoryBase ef, string filtro, int top)
        {
            inicializarGrilla(ef, filtro, top, ef.EntidadNombre);
        }
        protected void inicializarGrilla(EntidadFactoryBase ef, string filtro, int top, string nombreSP)
        {
            try
            {
                DataTable tabla = ef.getAllInDataTable(filtro, top, nombreSP);
                if (tabla!=null)
                    dgItems.DataSource = tabla;
                tabla = null;

                dgItems.AutoResizeColumns();
                dgItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                //Si la grilla está vacía, pasa a modo estático
                if (dgItems.RowCount == 0)
                {
                    rglEntidad = null;
                    modoEstatico(false);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (this.busquedaInstantanea)
                if (!this.buscandoPalabrasClave)
                    if (tbBusqueda.Text.Trim().Length > 3)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        buscarPalabrasClave();
                        this.Cursor = Cursors.Default;
                    }
        }

        private void dgItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editarRegistro();
        }

        private void tbBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.Cursor = Cursors.WaitCursor;
                buscarPalabrasClave();

                this.Cursor = Cursors.Default;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                dgItems.Select();
        }

        private void dgItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                editarRegistro();
                e.Handled = true;
            }
        }

        private void dgItems_CurrentCellChanged(object sender, EventArgs e)
        {
            if (!this.recuperandoObjeto)
            {
                //Console.WriteLine(dgItems.CurrentCell.RowIndex.ToString() + "," + dgItems.CurrentCell.ColumnIndex.ToString() + ":" + dgItems.CurrentCell.Value);
                recuperarObjetoPorCodigo();
                modoEstatico(rglEntidad != null);
            }
        }

        //Estos metodos se ejecutan desde el invocador del formulario
        public virtual void abrirComoNuevo()
        {
            tabPrincipal.SelectedIndex = 1;
            butAgregar_Click(this, new EventArgs());
        }
        public virtual void abrirComoConsulta()
        {
            tabPrincipal.SelectedIndex = 0;
            //tbBusqueda.Focus();
        }
        public virtual void abrirComoConsultaFicha()
        {
            tabPrincipal.SelectedIndex = 1;
        }

        private void butBuscar_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            buscarPalabrasClave();
            this.Cursor = Cursors.Default;
        }

        private void butImprimir_Click(object sender, EventArgs e)
        {
            imprimirListado();
        }

        private void butSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}