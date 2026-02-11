using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmAvisoExamenModificado : Form
    {
        public delegate void DelegateVentanilla();
        public DelegateVentanilla objDelegateVentanilla = null;
        private CapaNegocioMepryl.TipoExamen tipoExamen;

        public frmAvisoExamenModificado(bool botImprimirVisible)
        {
            InitializeComponent();
            tipoExamen = new CapaNegocioMepryl.TipoExamen();
            botonImprimir.Visible = botImprimirVisible;          
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        public void cargarEstudiosSegunIdTurno(Guid idTurno)
        {
            llenarFormulario(tipoExamen.cargarTipoExamenSegunIdTurno(idTurno));
        }

        private void aceptar()
        {
            this.Close();
            if (objDelegateVentanilla != null)
            {
                objDelegateVentanilla();
            }  
        }

        private void llenarFormulario(Entidades.TipoExamen entidad)
        {
            lblNombre.Text = entidad.Descripcion;
            if (entidad.Modificado) { lblNombre.Text = lblNombre.Text + " MODIFICADO"; }
            tbImporte.Text = entidad.PrecioBase.ToString();
            cargarTextBoxs(entidad);
        }

        private void cargarTextBoxs(Entidades.TipoExamen entidad)
        {
            agregarATextBox(entidad.Clinico, tbClinico);
            agregarATextBox(entidad.Hematologia, tbLaboratorio);
            agregarATextBox(entidad.QuimicaHematica, tbLaboratorio);
            agregarATextBox(entidad.Serologia, tbLaboratorio);
            agregarATextBox(entidad.PerfilLipidico, tbLaboratorio);
            agregarATextBox(entidad.Bacteriologia, tbLaboratorio);
            agregarATextBox(entidad.Orina, tbLaboratorio);
            agregarATextBox(entidad.LaboralesBasicas, tbRx);
            agregarATextBox(entidad.CraneoYMSuperior, tbRx);
            agregarATextBox(entidad.TroncoYPelvis, tbRx);
            agregarATextBox(entidad.MiembroInferior, tbRx);
            agregarATextBox(entidad.EstComplementarios, tbEstudiosComplementarios);
        }

        private void agregarATextBox(DataTable estudios, TextBox tb)
        {
            bool primeraVez = true;
            string cadena = "";
            if (tb.Text.Length != 0) 
            { 
                primeraVez = false;
                cadena = tb.Text;
            }
 
            foreach(DataRow dr in estudios.Rows)
            {
                if ((bool)dr.ItemArray[2])
                {
                    if (primeraVez)
                    {
                        cadena = dr.ItemArray[3].ToString();
                        primeraVez = false;
                    }
                    else
                    {
                        cadena = cadena + " - " + dr.ItemArray[3].ToString();
                    }
                }
            }
            tb.Text = cadena;
        }

        private void frmAvisoExamenModificado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                botonAceptar.PerformClick();
            }
        }

        private void botonImprimir_Click(object sender, EventArgs e)
        {
            imprimir();         
        }

        private void imprimir()
        {
            //this.Close();
            //formMesaEntrada.imprimirComprobante(); 
        }


    }
}
