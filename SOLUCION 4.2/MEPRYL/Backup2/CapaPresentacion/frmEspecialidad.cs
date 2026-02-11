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
using Comunes;


namespace CapaPresentacion
{
    public partial class frmEspecialidad : CapaPresentacionBase.frmBaseEntidadABM
    {
        public Especialidad rglEntidad;

        public frmEspecialidad()
        {
            InitializeComponent();
        }

        public frmEspecialidad(Configuracion config)
            : base(config)
        {
            EntidadNombre = "Especialidad";
        }

        //Implementacion
        protected override void inicializarEntidad()
        {
            rglEntidad = new Especialidad();
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
            tbDescripcion.Focus();
        }

        protected override void inicializarComponentes()
        {
            InitializeComponent();

            //Verifica los permisos
            Seguridad seguridad = new Seguridad(this.configuracion);
            this.permisoAlta = seguridad.verificarPermiso("Administracion.Especialidades", "ALTA");
            this.permisoModificacion = seguridad.verificarPermiso("Administracion.Especialidades", "MODIFICAR");
            this.permisoBaja = seguridad.verificarPermiso("Administracion.Especialidades", "BORRAR");
            seguridad = null;


            base.inicializarComponentes();

            inicializarEntidad();

            llenarCombo();
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
                navegador.agregarControl(new CapsulaControl((Control)tbDescripcion));

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
                rglEntidad = (Especialidad)base.rglEntidad;
                tbId.Text = rglEntidad.id.ToString();
                tbDescripcion.Text = rglEntidad.descripcion.ToString();
                cboMotivoConsulta.SelectedValue = rglEntidad.motivoConsulta;
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
                if (tbDescripcion.Text.Trim() == "")
                    resultado += "\r\n\t- Debe ingresar un Nombre.";


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
                tbDescripcion.Text = "";
                cboMotivoConsulta.SelectedIndex = -1;
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
                rglEntidad.descripcion = tbDescripcion.Text;
                rglEntidad.motivoConsulta = cboMotivoConsulta.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override string validarNegocio()
        {
            EspecialidadFactory negEntidadFac = (EspecialidadFactory)crearNegEntidadFac();
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
            return new EspecialidadFactory(this.configuracion, this.EntidadNombre);
        }

        public override Resultado alta()
        {
            Resultado resultado = new Resultado();

            try
            {
                EspecialidadFactory negEntidadFac = (EspecialidadFactory)crearNegEntidadFac();
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
                EspecialidadFactory negEntidadFac = (EspecialidadFactory)crearNegEntidadFac();
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
            DialogResult result = MessageBox.Show(@"¿Esta seguro que desea eliminar este tipo de examen? ACLARACION: REALIZAR ESTA ACCION
            PODRIA CAUSAR FALLOS EN LA INTEGRIDAD DEL SISTEMA", "Eliminar Tipo Examen", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (result == DialogResult.Yes)
            {
                string resultado = "";
                try
                {
                    EspecialidadFactory negEspecialidadFac = new EspecialidadFactory(this.configuracion, this.EntidadNombre);
                    resultado = negEspecialidadFac.borrar(id);

                    negEspecialidadFac = null;
                }
                catch (Exception ex)
                {
                    ManejadorErrores.escribirLog(ex, true, this.configuracion);
                    resultado = ex.Message;
                }
                return resultado;
            }
            return "";
        }

        private void botonEditar_Click(object sender, EventArgs e)
        {
            if (new Guid(tbId.Text) != Guid.Empty)
            {
                Utilidades.abrirFormulario(this.MdiParent, new frmEstudios(tbId.Text, 1), new Configuracion());
            }
            else
            {
                MessageBox.Show("¡Primero se debe crear el tipo de examen!", "Crear Tipo Examen",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void llenarCombo()
        {
            cboMotivoConsulta.DataSource = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.MotivoDeConsulta");
            cboMotivoConsulta.ValueMember = "id";
            cboMotivoConsulta.DisplayMember = "nombre";
            cboMotivoConsulta.SelectedIndex = -1;
        }




    }
}