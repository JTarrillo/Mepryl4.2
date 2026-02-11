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
    public partial class frmPacienteABM : frmBasePersonaABM
    {
        private Cliente rglEntidad;

        
        public frmPacienteABM(Configuracion config) : base(config)
        {
            InitializeComponent();
            EntidadNombre = "Cliente";
        }

        //Implementacion
        protected override void inicializarEntidad()
        {
            rglEntidad = new Cliente();
        }

        public override frmBaseBusqueda crearFormularioBusqueda()
        {
            return new frmBusqueda(this.configuracion, this.EntidadNombre);
        }

        public override EntidadFactoryBase crearNegEntidadFac()
        {
            return new ClienteFactory(this.configuracion, this.EntidadNombre);
        }

        protected override void cargarObjetoReglas()
        {
            try
            {
                inicializarEntidad();
                rglEntidad.id = new Guid(tbId.Text);
                rglEntidad.codigo = tbCodigo.Text;
                rglEntidad.apellido = tbApellido.Text;
                rglEntidad.nombres = tbNombres.Text;
                rglEntidad.direccion = tbDireccion.Text;
                rglEntidad.localidadID = (Guid)cboaLocalidad.cboCombo.SelectedValue;
                rglEntidad.localidadDesc = cboaLocalidad.cboCombo.Text;
                rglEntidad.codigoPostal = tbCodigoPostal.Text;
                rglEntidad.provinciaID = (Guid)cboaProvincia.cboCombo.SelectedValue;
                rglEntidad.provinciaDesc = cboaProvincia.cboCombo.Text;
                rglEntidad.ubicacionGuia = tbUbicacionGuia.Text;
                rglEntidad.dni = tbDNI.Text;
                rglEntidad.fechaNacimiento = dtpFechaNacimiento.Value;
                rglEntidad.eMail = tbEmail.Text;
                rglEntidad.telefonos = tbTelefonos.Text;
                rglEntidad.paginaWeb = tbPaginaWeb.Text;
                rglEntidad.observaciones = tbObservaciones.Text;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override string validarNegocio()
        {
            ClienteFactory negEntidadFac = (ClienteFactory)crearNegEntidadFac();
            string resultado = negEntidadFac.validar(rglEntidad, edicion);
            negEntidadFac = null;

            return resultado;
        }
        //
        public override Resultado alta()
        {
            Resultado resultado = new Resultado();

            try
            {
                ClienteFactory negEntidadFac = (ClienteFactory)crearNegEntidadFac();
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
                ClienteFactory negEntidadFac = (ClienteFactory)crearNegEntidadFac();
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
                ClienteFactory negClienteFac = new ClienteFactory(this.configuracion, this.EntidadNombre);
                resultado = negClienteFac.borrar(id);

                negClienteFac = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

        private void tabPrincipal_Enter(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("El tab."); 
        }
    }
}

