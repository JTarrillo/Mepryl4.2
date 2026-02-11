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
    public partial class frmClub : CapaPresentacionBase.frmBaseEntidadABM
    {
        public Club rglEntidad;

        public frmClub()
        {
            InitializeComponent();
        }

        public frmClub(Configuracion config)
            : base(config)
        {
            EntidadNombre = "Club";
        }

        //Implementacion
        protected override void inicializarEntidad()
        {
            rglEntidad = new Club();
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
            this.permisoAlta = seguridad.verificarPermiso("Administracion.Clubes", "ALTA"); 
            this.permisoModificacion = seguridad.verificarPermiso("Administracion.Clubes", "MODIFICAR");
            this.permisoBaja = seguridad.verificarPermiso("Administracion.Clubes", "BORRAR");
            seguridad = null;


            base.inicializarComponentes();

            cboaLiga.inicializar(this.configuracion, "Liga");
            cboaLiga.mayusculas = true;

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
                navegador.agregarControl(new CapsulaControl((Control)tbDescripcion));
                navegador.agregarControl(new CapsulaControl((Control)cboaLiga));
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
                rglEntidad = (Club)base.rglEntidad;
                tbDescripcion.Text = rglEntidad.descripcion.ToString();
                cboaLiga.cboCombo.SelectedValue = rglEntidad.ligaID;
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
                rglEntidad.descripcion = tbDescripcion.Text;
                rglEntidad.ligaID = cboaLiga.obtenerID();
                rglEntidad.observaciones = tbObservaciones.Text;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override string validarNegocio()
        {
            ClubFactory negEntidadFac = (ClubFactory)crearNegEntidadFac();
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
            return new ClubFactory(this.configuracion, this.EntidadNombre);
        }

        public override Resultado alta()
        {
            Resultado resultado = new Resultado();

            try
            {
                ClubFactory negEntidadFac = (ClubFactory)crearNegEntidadFac();
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
                ClubFactory negEntidadFac = (ClubFactory)crearNegEntidadFac();
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
                ClubFactory negClubFac = new ClubFactory(this.configuracion, this.EntidadNombre);
                resultado = negClubFac.borrar(id);

                negClubFac = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmClubMantenimiento frmClub = new frmClubMantenimiento();
            frmClub.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmConfiguracionExamenRX2 frmConfig = new frmConfiguracionExamenRX2();
            frmConfig.Show();
        }


    }
}