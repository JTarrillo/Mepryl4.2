using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Comunes
{
    public partial class frmPlanillaRepartoAlta : Form
    {
        private Configuracion configuracion;
        public StatusBar statusBar1 = null;
        public ToolBar toolBar2 = null;
        public frmPlanillaRepartoAlta(Configuracion conf)
        {
            this.configuracion = conf;
            InitializeComponent();
        }

        private void ucPlanillaRepartoAlta1_Load(object sender, EventArgs e)
        {
            ucPlanillaRepartoAlta1.statusBarPrincipal = statusBar1;
            ucPlanillaRepartoAlta1.formContenedor = this;
            ucPlanillaRepartoAlta1.configuracion = configuracion;
            ucPlanillaRepartoAlta1.inicializarComponentes();
        }

        private void frmPlanillaRepartoAlta_Enter(object sender, EventArgs e)
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

        private void frmPlanillaRepartoAlta_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Elimina el boton de la barra de tareas
            if (this.toolBar2 != null)
                this.toolBar2.Buttons.Remove((ToolBarButton)this.Tag);
        }
    }
}