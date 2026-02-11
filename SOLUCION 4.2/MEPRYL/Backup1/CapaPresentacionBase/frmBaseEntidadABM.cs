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
    public partial class frmBaseEntidadABM : Form
    {
        public string EntidadNombre = "Entidad";
        public EntidadBase rglEntidad;
        public frmBaseBusqueda frmBusqueda;
        public NavegadorFormulario navegador;
        public Configuracion configuracion;

        public bool mostrarBotonOk = false;

        public bool permisoAlta = true;
        public bool permisoModificacion = true;
        public bool permisoBaja = true;

        public bool agregarHabilitado = true;
        public bool eliminarHabilitado = true;

        public ModoEdicion edicion = ModoEdicion.VACIO;
        private Color colorTitulo;

        //Define el Delegado 
        public delegate void DelegateDevolverID(string ID);
        public DelegateDevolverID objDelegateDevolverID = null;
        public object delegado;

        public frmBaseEntidadABM()
        {
            InitializeComponent();
        }

        public frmBaseEntidadABM(Configuracion config):  this(config, false)
        {
           
        }

        public frmBaseEntidadABM(Configuracion config, bool mostrarBotonOk)
        {
            InitializeComponent();

            this.configuracion = config;
            this.mostrarBotonOk = mostrarBotonOk;

            inicializarComponentes();
        }

        //Métodos abstractos
        public virtual CapaNegocioBase.EntidadFactoryBase crearNegEntidadFac() { return null; }
        public virtual frmBaseBusqueda crearFormularioBusqueda() { return null; }
        public virtual string validarDatosIngresados() { return null; }
        public virtual string validarNegocio() { return null; }
        public virtual Resultado alta() { return null; }
        public virtual Resultado modificar() { return null; }
        public virtual string borrar(string id) { return null; }
        protected virtual void inicializarEntidad() { }
        protected virtual void cargarObjetoReglas() { }
        protected virtual void focoEnOK() { }
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

        /*protected void cambiarEtiquetaEdicion()
        {
            switch (edicion)
            {
                case ModoEdicion.AGREGANDO:
                    {
                        lbEstadoEdicion.Text = "AGREGANDO...";
                        lbEstadoEdicion.BackColor = Color.Blue;
                        break;
                    }
                case ModoEdicion.MODIFICANDO:
                    {
                        lbEstadoEdicion.Text = "MODIFICANDO...";
                        lbEstadoEdicion.BackColor = Color.Green;
                        break;
                    }
                case ModoEdicion.VACIO:
                    {
                        lbEstadoEdicion.Text = "";
                        lbEstadoEdicion.BackColor = Color.Transparent;
                        break;
                    }
            }
        }*/


        protected void cambiarEtiquetaEdicion()
        {
            switch (edicion)
            {
                case ModoEdicion.AGREGANDO:
                    {
                        lbTitulo.Text = "Agregando " + this.Text + "...";
                        lbTitulo.BackColor = Color.Red;
                        break;
                    }
                case ModoEdicion.MODIFICANDO:
                    {
                        lbTitulo.Text = "Modificando " + this.Text + "...";
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

        protected virtual void butAgregar_Click(object sender, EventArgs e)
        {
            if (agregarHabilitado)
                agregar();
            else
            {
                MessageBox.Show("Esta función está deshabilitada.", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        protected void agregar()
        {

            if (rglEntidad != null)
            {
                tbCodigo.Text = "";
            }
            edicion = ModoEdicion.AGREGANDO;
            limpiarFormulario();
            tbId.Text = Utilidades.ID_VACIO;
            modoEditable();
            cambiarEtiquetaEdicion();
            rglEntidad = null;
        }

        protected void butModificar_Click(object sender, EventArgs e)
        {
            edicion = ModoEdicion.MODIFICANDO;
            modoEditable();
            cambiarEtiquetaEdicion();
        }

        protected void butEliminar_Click(object sender, EventArgs e)
        {
            if (agregarHabilitado)
                if (confirmar("¿Está seguro que desea eliminar el registro?") == DialogResult.Yes)
                {
                    string resultado = borrar(tbId.Text);
                    if (resultado == "")
                    {
                        limpiarFormulario();
                        tbId.Text = Utilidades.ID_VACIO;
                        modoEstatico(false);
                        edicion = ModoEdicion.VACIO;
                        cambiarEtiquetaEdicion();
                    }
                    else
                        mostrarError(resultado);
                }
            else
            {
                MessageBox.Show("Esta función está deshabilitada.", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        protected void aceptar()
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
                        }
                        else if (edicion == ModoEdicion.MODIFICANDO)
                        {
                            resultado = modificar();
                        }
                        else
                            resultado.mensaje = "No se puede realizar esta operación.";

                        if (resultado.mensaje == "")
                        {
                            rglEntidad = (CapaNegocioBase.EntidadBase)resultado.objeto;
                            tbId.Text = rglEntidad.id.ToString();
                            tbCodigo.Text = rglEntidad.codigo;
                            modoEstatico(true);
                            if (!this.mostrarBotonOk)
                                tbCodigo.Focus();
                            edicion = ModoEdicion.VACIO;
                            cambiarEtiquetaEdicion();
                        }
                    }
                }
                if (resultado.mensaje != "")
                    mostrarError(resultado.mensaje);
                else
                {
                    focoEnOK();
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        protected void butCancelar_Click(object sender, EventArgs e)
        {
            if (tbId.Text != Utilidades.ID_VACIO) //Si era una edición
            {
                mostrarDatosObjeto();
            }
            else
            {
                limpiarFormulario();
            }
            modoEstatico(rglEntidad != null);
            tbCodigo.Focus();
            edicion = ModoEdicion.VACIO;
            cambiarEtiquetaEdicion();
        }

        private void butBuscar_Click(object sender, EventArgs e)
        {
            
            nuevoFormularioBusqueda();
            //Crea y asigna el Delegate
            frmBusqueda.ShowDialog(this);

            tbCodigo.Focus();
        }

        private void tbCodigo_TextChanged(object sender, EventArgs e)
        {
            if (butModificar.Enabled)
            {
                limpiarFormulario();
                modoEstatico(false);
            }
        }

        private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && tbCodigo.Text != "")
            {
                recuperarObjetoPorCodigo(tbCodigo.Text);
                e.Handled = true;
            }
        }

        protected void recuperarObjeto(string id)
        {
            try
            {
                tbId.Text = id;

                //EntidadFactoryBase negEntidadFac = new EntidadFactoryBase(this.configuracion, this.EntidadNombre);
                EntidadFactoryBase negEntidadFac = crearNegEntidadFac();
                
                EntidadBase entidadAux = negEntidadFac.getById(tbId.Text);
                
                if (entidadAux != null)
                {
                    rglEntidad = entidadAux;
                    mostrarDatosObjeto();
                    butModificar.Enabled = true;
                    butEliminar.Enabled = true;
                    if (this.permisoModificacion)
                        butModificar.Visible = true;
                    if (this.permisoBaja)
                        butEliminar.Visible = true;
                    if (this.mostrarBotonOk)
                    {
                        butOk.Visible = true;
                        butOk.Focus();
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


        protected virtual bool recuperarObjetoPorCodigo(string codigo)
        {
            bool encontro = false;
            try
            {
                
                EntidadFactoryBase negEntidadFac = crearNegEntidadFac();

                EntidadBase entidadAux = negEntidadFac.getByCodigo(codigo);

                if (entidadAux != null)
                {
                    rglEntidad = entidadAux;
                    mostrarDatosObjeto();
                    butModificar.Enabled = true;
                    butEliminar.Enabled = true;
                    if (this.permisoModificacion)
                        butModificar.Visible = true;
                    if (this.permisoBaja)
                        butEliminar.Visible = true;
                    if (this.mostrarBotonOk)
                    {
                        butOk.Visible = true;
                        butOk.Focus();
                    }
                    encontro = true;
                }

                entidadAux = null;

                negEntidadFac = null;
            }
            catch (Exception exError)
            {
                mostrarError(exError.Message);
            }
            return encontro;
        }

        private void cargarObjetoRecuperado()
        {
            if (tbId.Text != Utilidades.ID_VACIO)
            {
                try
                {
                    //rglEntidad.recuperar(new Guid(tbId.Text));
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

        protected void frmBaseEntidadABM_Load(object sender, EventArgs e)
        {
            modoEstatico(false);
            tbCodigo.Focus();

        }

        protected void frmBaseEntidadABM_FormClosing(object sender, FormClosingEventArgs e)
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
            butBuscar.Enabled = true;
            butAgregar.Enabled = true;
            butModificar.Enabled = hayObjetoActivo;
            butEliminar.Enabled = hayObjetoActivo;
            butAceptar.Enabled = false;
            butCancelar.Enabled = false;

            butBuscar.Visible = true;

            if (this.permisoAlta)
                butAgregar.Visible = true;
            if (this.permisoModificacion)
                butModificar.Visible = hayObjetoActivo;
            if (this.permisoBaja)
                butEliminar.Visible = hayObjetoActivo;
            butAceptar.Visible = false;
            butCancelar.Visible = false; 
            if (this.mostrarBotonOk)
            {
                butOk.Visible = hayObjetoActivo;
            }
        }

        protected virtual void modoEditable()
        {
            tbCodigo.Enabled = false;
            butBuscar.Enabled = false;
            butAgregar.Enabled = false;
            butModificar.Enabled = false;
            butEliminar.Enabled = false;
            butAceptar.Enabled = true;
            butCancelar.Enabled = true;

            butBuscar.Visible = false;
            butAgregar.Visible = false;
            butModificar.Visible = false;
            butEliminar.Visible = false;
            butAceptar.Visible = true;
            butCancelar.Visible = true;
            butOk.Visible = false;

            this.Focus();
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
                //frmBusqueda = new frmBaseBusqueda(this.configuracion, this.EntidadNombre);
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
                modoEstatico(false);
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
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butBuscar, (char)Keys.F1));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butAceptar, (char)Keys.F5));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butCancelar, (char)Keys.F6));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butAgregar, (char)Keys.F7));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butModificar, (char)Keys.F8));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butEliminar, (char)Keys.F9));
                navegador.agregarControlTeclaRapida(new CapsulaControl((Control)butOk, (char)Keys.F10));
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

        private void butAgregar_Enter(object sender, EventArgs e)
        {
            tbCodigo.Focus();
        }

        private void butSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void habilitarControles(ref GroupBox contenedor, bool habilitar)
        {
            foreach (Control cont in contenedor.Controls)
            {
                /*if (cont.GetType() == typeof(TextBox))
                {
                    ((TextBox)cont).ReadOnly = !habilitar;
                }
                else 
                {*/
                if (cont.GetType() == typeof(TextBox))
                {
                    ((TextBox)cont).BackColor = SystemColors.ButtonFace;
                }
                cont.Enabled = habilitar;
                
                //}
            
            }
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            ok();
        }

        //Cierra devolviendo el valor seleccionado
        protected void ok()
        {
            string id = Utilidades.ID_VACIO;
            if (rglEntidad != null)
            {
                if (rglEntidad.id.ToString()!=Utilidades.ID_VACIO)
                {
                    id = rglEntidad.id.ToString();
                }
            }
            this.Close();

            //Devuelve el ID del Articulo Seleccionado
            if (objDelegateDevolverID != null)
                objDelegateDevolverID(id);
        }

        private void butOk_Leave(object sender, EventArgs e)
        {
            //MessageBox.Show("Perdio el foco");
        }

    }
}