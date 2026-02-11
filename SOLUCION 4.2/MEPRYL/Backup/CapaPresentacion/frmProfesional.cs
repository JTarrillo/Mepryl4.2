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


namespace CapaPresentacion
{
    public partial class frmProfesional : CapaPresentacionBase.frmBaseEntidadABM
    {
        public Profesional rglEntidad;

        public frmProfesional()
        {
            InitializeComponent();
        }

        public frmProfesional(Configuracion config)
            : base(config)
        {
            EntidadNombre = "Profesional";
        }

        //Implementacion
        protected override void inicializarEntidad()
        {
            rglEntidad = new Profesional();
        }


        //
        //Para redefinir en cada formulario
        //
        protected override void modoEstatico(bool hayObjetoActivo)
        {
            base.modoEstatico(hayObjetoActivo);


            habilitarControles(ref gbDatosPersonales, false);
        }


        protected override void modoEditable()
        {
            base.modoEditable();
            habilitarControles(ref gbDatosPersonales, true);
            this.Focus();
            tbApellido.Focus();
        }

        protected override void inicializarComponentes()
        {
            InitializeComponent();

            //Verifica los permisos
            Seguridad seguridad = new Seguridad(this.configuracion);
            this.permisoAlta = seguridad.verificarPermiso("Administracion.Profesionales", "ALTA");
            this.permisoModificacion = seguridad.verificarPermiso("Administracion.Pofesionales", "MODIFICAR");
            this.permisoBaja = seguridad.verificarPermiso("Administracion.Profesionales", "BORRAR");
            seguridad = null;


            base.inicializarComponentes();

            inicializarEntidad();
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
                navegador.agregarControl(new CapsulaControl((Control)tbTelefonos));
                navegador.agregarControl(new CapsulaControl((Control)tbObservaciones));

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
                rglEntidad = (Profesional)base.rglEntidad;
                tbApellido.Text = rglEntidad.apellido.ToString();
                tbNombres.Text = rglEntidad.nombres.ToString();
                tbTelefonos.Text = rglEntidad.telefonos.ToString();
                tbObservaciones.Text = rglEntidad.observaciones.ToString();
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
                if (tbApellido.Text.Trim() == "" && tbNombres.Text.Trim() == "")
                    resultado += "\r\n\t- Debe ingresar Apellido y Nombres.";

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
                tbTelefonos.Text = "";
                tbObservaciones.Text = "";
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
                inicializarEntidad();
                rglEntidad.id = new Guid(tbId.Text);
                rglEntidad.codigo = tbCodigo.Text;
                rglEntidad.apellido = tbApellido.Text;
                rglEntidad.nombres = tbNombres.Text;
                rglEntidad.telefonos = tbTelefonos.Text;
                rglEntidad.observaciones = tbObservaciones.Text;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override string validarNegocio()
        {
            ProfesionalFactory negEntidadFac = (ProfesionalFactory)crearNegEntidadFac();
            string resultado = negEntidadFac.validar(rglEntidad, edicion);
            negEntidadFac = null;

            return resultado;
        }

        public override frmBaseBusqueda crearFormularioBusqueda()
        {
            return new frmBusqueda(this.configuracion, this.EntidadNombre);
        }

        public override CapaNegocioBase.EntidadFactoryBase crearNegEntidadFac()
        {
            return new ProfesionalFactory(this.configuracion, this.EntidadNombre);
        }

        public override Resultado alta()
        {
            Resultado resultado = new Resultado();

            try
            {
                ProfesionalFactory negEntidadFac = (ProfesionalFactory)crearNegEntidadFac();
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
                ProfesionalFactory negEntidadFac = (ProfesionalFactory)crearNegEntidadFac();
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
                ProfesionalFactory negProfesionalFac = new ProfesionalFactory(this.configuracion, this.EntidadNombre);
                resultado = negProfesionalFac.borrar(id);

                negProfesionalFac = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

        private void butHorarios_Click(object sender, EventArgs e)
        {
            if (rglEntidad != null)
            {
                if (rglEntidad.id.ToString() != Utilidades.ID_VACIO)
                {
                    frmHorario fHorario = (frmHorario)Utilidades.abrirFormulario(this.ParentForm,
                                                new frmHorario(this.configuracion, frmBaseGrillaABM.ModoApertura.NUEVO_REGISTRO),
                                                this.configuracion);

                    fHorario.seleccionarProfesionalID = rglEntidad.id.ToString();
                    fHorario.reiniciarFormulario(frmBaseGrillaABM.ModoApertura.NUEVO_REGISTRO);
                    
                }
            }
        }
    }
}