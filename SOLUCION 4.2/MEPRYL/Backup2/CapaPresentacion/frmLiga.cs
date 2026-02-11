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
    public partial class frmLiga : CapaPresentacionBase.frmBaseEntidadABM
    {
        public Liga rglEntidad;

        public frmLiga()
        {
            InitializeComponent();
        }

        public frmLiga(Configuracion config)
            : base(config)
        {
            EntidadNombre = "Liga";
        }

        //Implementacion
        protected override void inicializarEntidad()
        {
            rglEntidad = new Liga();
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
            this.permisoAlta = seguridad.verificarPermiso("Administracion.Ligas", "ALTA");
            this.permisoModificacion = seguridad.verificarPermiso("Administracion.Ligas", "MODIFICAR");
            this.permisoBaja = seguridad.verificarPermiso("Administracion.Ligas", "BORRAR");
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
                rglEntidad = (Liga)base.rglEntidad;
                tbDescripcion.Text = rglEntidad.descripcion.ToString();
                pictureBox.Image = Image.FromStream(rglEntidad.imagen);
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
                pictureBox.Image.Save(rglEntidad.imagen, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

        public override string validarNegocio()
        {
            LigaFactory negEntidadFac = (LigaFactory)crearNegEntidadFac();
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
            return new LigaFactory(this.configuracion, this.EntidadNombre);
        }

        public override Resultado alta()
        {
            Resultado resultado = new Resultado();

            try
            {
                LigaFactory negEntidadFac = (LigaFactory)crearNegEntidadFac();
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
                LigaFactory negEntidadFac = (LigaFactory)crearNegEntidadFac();
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
                LigaFactory negLigaFac = new LigaFactory(this.configuracion, this.EntidadNombre);
                resultado = negLigaFac.borrar(id);

                negLigaFac = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado = ex.Message;
            }
            return resultado;
        }

        private void botonCargar_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName.ToString());
                }
                catch
                {
                    MessageBox.Show("No se soporta el formato del archivo seleccionado");
                }
            }
        }

        private void btnLlamaLiga_Click(object sender, EventArgs e)
        {
            frmLigaMantenimiento frmLiga = new frmLigaMantenimiento();
            frmLiga.Show();
        }



    }
}