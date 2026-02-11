using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;

namespace Comunes
{
    public partial class frmNotaCreditoConsulta : Form
    {

        private Configuracion configuracion;
        public StatusBar statusBar1 = null;
        public ToolBar toolBar2 = null;
        private bool consultaRapida = false;
        //private bool facturaDescuento = false;
        private string tipoPresentacion = "";
        public string clienteID = "";
        public Control controlContenedorResultados;

        //Define el Delegado 
        public delegate bool DelegateDevolverID(Configuracion configuracion, string ID, ref Control controlContenedorResultados);
        public DelegateDevolverID objDelegateDevolverID = null;

        public frmNotaCreditoConsulta(Configuracion conf, bool esConsultaRapida, string tipoPresentacion)
        {
            this.configuracion = conf;
            this.consultaRapida = esConsultaRapida;
            //this.facturaDescuento = esFacturaDescuento;
            this.tipoPresentacion = tipoPresentacion;

            InitializeComponent();
        }

        private void frmNotaCreditoConsulta_Load(object sender, EventArgs e)
        {
            ucNotaCreditoConsulta1.statusBarPrincipal = statusBar1;
            ucNotaCreditoConsulta1.formContenedor = this;
            ucNotaCreditoConsulta1.configuracion = configuracion;
            ucNotaCreditoConsulta1.consultaRapida = this.consultaRapida;
            ucNotaCreditoConsulta1.tipoPresentacion = this.tipoPresentacion;
            ucNotaCreditoConsulta1.clienteID = this.clienteID;
            ucNotaCreditoConsulta1.inicializarComponentes();
            //if (this.facturaDescuento)
            //	ucFacturaConsulta1.configurarFacturaConDescuento();
        }

        private void frmNotaCreditoConsulta_Enter(object sender, EventArgs e)
        {
            if (toolBar2 != null)
            {
                soltarBotones();
                ((ToolBarButton)this.Tag).Pushed = true;
            }
        }
        //Suelta todos los botones de la barra de tareas
        public void soltarBotones()
        {
            foreach (ToolBarButton tbb in toolBar2.Buttons)
                tbb.Pushed = false;
        }

        private void frmNotaCreditoConsulta_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Elimina el boton de la barra de tareas
            if (this.toolBar2 != null)
                this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);

            //Devuelve el ID del Articulo Seleccionado
            if (objDelegateDevolverID != null)
                objDelegateDevolverID(this.configuracion, ucNotaCreditoConsulta1.getID(), ref this.controlContenedorResultados);
        }
    }
}