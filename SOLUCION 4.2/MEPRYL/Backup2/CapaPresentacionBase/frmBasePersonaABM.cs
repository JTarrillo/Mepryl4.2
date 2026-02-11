using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaNegocioBase;
using UserControls;

namespace CapaPresentacionBase
{
    public partial class frmBasePersonaABM : CapaPresentacionBase.frmBaseEntidadABM
    {
        public PersonaBase rglEntidad;

        public frmBasePersonaABM()
        {
            InitializeComponent();
        }

        public frmBasePersonaABM(Configuracion config) : base(config)
        {
        }

        //Métodos abstractos
        public override CapaNegocioBase.EntidadFactoryBase crearNegEntidadFac() { return null; }
        protected override void cargarObjetoReglas() {}
        public override string validarNegocio() { return null; }
        public override Resultado alta() { return null; }
        public override Resultado modificar() { return null; }
        protected override void inicializarEntidad() {}
        //

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
            base.inicializarComponentes();

            cboaLocalidad.inicializar(this.configuracion, "Localidad");
            cboaProvincia.inicializar(this.configuracion, "Provincia");

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
                navegador.agregarControl(new CapsulaControl((Control)tbDireccion));
                navegador.agregarControl(new CapsulaControl((Control)cboaLocalidad));
                navegador.agregarControl(new CapsulaControl((Control)tbCodigoPostal));
                navegador.agregarControl(new CapsulaControl((Control)cboaProvincia));
                navegador.agregarControl(new CapsulaControl((Control)tbUbicacionGuia));
                navegador.agregarControl(new CapsulaControl((Control)tbDNI));
                navegador.agregarControl(new CapsulaControl((Control)dtpFechaNacimiento));
                navegador.agregarControl(new CapsulaControl((Control)tbEmail));
                navegador.agregarControl(new CapsulaControl((Control)tbTelefonos));
                navegador.agregarControl(new CapsulaControl((Control)tbPaginaWeb));
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
                rglEntidad = (PersonaBase)base.rglEntidad;
                tbApellido.Text = rglEntidad.apellido.ToString();
                tbNombres.Text = rglEntidad.nombres.ToString();
                tbDireccion.Text = rglEntidad.direccion.ToString();
                cboaLocalidad.cboCombo.SelectedValue = new Guid(rglEntidad.localidadID.ToString());
                tbCodigoPostal.Text = rglEntidad.codigoPostal.ToString();
                cboaProvincia.cboCombo.SelectedValue = new Guid(rglEntidad.provinciaID.ToString());
                tbUbicacionGuia.Text = rglEntidad.ubicacionGuia.ToString();
                tbDNI.Text = rglEntidad.dni.ToString();
                dtpFechaNacimiento.Value = DateTime.Parse(rglEntidad.fechaNacimiento.ToString());
                tbEmail.Text = rglEntidad.eMail.ToString();
                tbTelefonos.Text = rglEntidad.telefonos.ToString();
                tbPaginaWeb.Text = rglEntidad.paginaWeb.ToString();
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
                if (tbApellido.Text.Trim() == "")
                    resultado += "\r\n\t- El campo Apellido está vacío.";

                if (tbNombres.Text.Trim() == "")
                    resultado += "\r\n\t- El campo Nombres está vacío.";

                if (tbDireccion.Text.Trim() == "")
                    resultado += "\r\n\t- El campo Dirección está vacío.";

                if (cboaLocalidad.cboCombo.SelectedValue == null)
                    resultado += "\r\n\t- Debe seleccionar una Localidad.";

                if (cboaProvincia.cboCombo.SelectedValue == null)
                    resultado += "\r\n\t- Debe seleccionar una Provincia.";

                if (tbEmail.Text.Trim() != "")
                    if (!Utilidades.IsEmailAddress(tbEmail.Text.Trim()))
                        resultado += "\r\n\t- El formato del e-mail no es correcto.";

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
                tbDireccion.Text = "";
                tbCodigoPostal.Text = "";
                tbUbicacionGuia.Text = "";
                tbDNI.Text = "";
                tbEmail.Text = "";
                tbTelefonos.Text = "";
                tbPaginaWeb.Text = "";
                tbObservaciones.Text = "";
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }
    }
}

