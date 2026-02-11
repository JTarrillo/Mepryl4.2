using System;
using Comunes;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using UserControls;

namespace CapaPresentacionBase
{
    /// <summary>
    /// Summary description for NavegadorFormulario.
    /// </summary>
    public class NavegadorFormulario
    {
        public HybridDictionary controles = new HybridDictionary();
        public HybridDictionary controlesTeclaRapida = new HybridDictionary();
        public int indiceActual;
        public CapsulaControl controlActual = new CapsulaControl();
        private Configuracion configuracion;

        public NavegadorFormulario(Configuracion conf)
        {
            this.configuracion = conf;
        }

        public void agregarControl(CapsulaControl cc)
        {
            cc.indice = controles.Count;
            controles.Add(cc.control.Name, cc);
            //cc.control.KeyDown += new KeyEventHandler(this.KeyDown);
            if (cc.control.Tag == null)
            {
                cc.control.PreviewKeyDown += new PreviewKeyDownEventHandler(this.KeyDown);
                cc.control.Tag = "EVENTOS_CONTROLADOS";
            }
            cc.control.Enter += new EventHandler(this.Enter);
            cc.control.Leave += new EventHandler(this.Leave);
        }

        public void agregarControlTeclaRapida(CapsulaControl cc)
        {
            cc.indice = controlesTeclaRapida.Count;
            controlesTeclaRapida.Add(cc.control.Name, cc);
        }

        //Procesa la tecla PreviewKeyDownEventArgs
        //private void KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        private void KeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            bool eventoManejado = false;
            CapsulaControl cc;
            Control con = (Control)sender;

            //Maneja las teclas rapidas
            foreach (DictionaryEntry de in this.controlesTeclaRapida)
            {
                cc = (CapsulaControl)de.Value;
                if ((char)e.KeyCode == cc.keyCode)
                {
                    if (cc.control.GetType() == typeof(Button))
                    {
                        if (cc.control.Visible)
                        {
                            cc.control.Select();
                            ((Button)cc.control).PerformClick();
                        }
                        eventoManejado = true;
                        //e.Handled = true;
                    }
                }
            }


            //Maneja la navegacion por enter o flechas
            if (this.controles.Contains(con.Name) && !eventoManejado)
            {
                int indiceProximo = ((CapsulaControl)this.controles[con.Name]).indice;

                if (e.KeyCode == Keys.Enter ||
                    (e.KeyCode == Keys.Down && con.GetType() == typeof(TextBox)) ||
                    (e.KeyCode == Keys.Down && con.GetType() == typeof(MaskedTextBox)) ||
                    (e.KeyCode == Keys.Right && con.GetType() == typeof(ComboBox)) ||
                    (e.KeyCode == Keys.Down && con.GetType() == typeof(Button)) ||
                    (e.KeyCode == Keys.Right && con.GetType() == typeof(Button)))
                {
                    indiceProximo = indiceProximo + 1;
                }
                if (e.KeyCode == Keys.Escape ||
                    (e.KeyCode == Keys.Up && con.GetType() == typeof(TextBox)) ||
                    (e.KeyCode == Keys.Up && con.GetType() == typeof(MaskedTextBox)) ||
                    (e.KeyCode == Keys.Left && con.GetType() == typeof(ComboBox)) ||
                    (e.KeyCode == Keys.Up && con.GetType() == typeof(Button)) ||
                    (e.KeyCode == Keys.Left && con.GetType() == typeof(Button)))
                {
                    indiceProximo = indiceProximo - 1;
                }

                cc = buscarControlByIndice(indiceProximo);
                if (cc != null)
                    cc.control.Focus();
            }
           

        }

        //Busca un control por el indice
        private CapsulaControl buscarControlByIndice(int indice)
        {
            CapsulaControl cc = null;
            foreach (DictionaryEntry de in this.controles)
            {
                cc = (CapsulaControl)de.Value;
                if (cc.indice == indice)
                {
                    break;
                }
                else
                    cc = null;
            }
            return cc;
        }

        //Agrega el handler a todos los controles para que escuchen las teclas rapidas
        public void agregarHandlersContenedor(Control contenedor)
        {
            //Agrega el handler al contenedor
            if (!this.controles.Contains(contenedor.Name))
            {
                if (contenedor.Tag == null)
                {
                    contenedor.Tag = "EVENTOS_CONTROLADOS";
                    //contenedor.KeyDown += new KeyEventHandler(this.KeyDown);
                    contenedor.PreviewKeyDown += new PreviewKeyDownEventHandler(this.KeyDown);
                }
            }

            //Agrega el handler a los controles hijos
            for (int i = 0; i < contenedor.Controls.Count; i++)
            {
                Control control = contenedor.Controls[i];
                if (!this.controles.Contains(control.Name))
                {
                    if (control.Tag == null)
                    {
                        //control.KeyDown += new KeyEventHandler(this.KeyDown);
                        control.PreviewKeyDown += new PreviewKeyDownEventHandler(this.KeyDown);
                        control.Tag = "EVENTOS_CONTROLADOS";
                    }
                }   
                if (control.Controls.Count > 0)
                    agregarHandlersContenedor(control);
            }
        }

        //Representa el evento Enter
        public void Enter(object sender, System.EventArgs e)
        {
            controlarColorFondo(ref sender, "Enter");
        }

        //Representa el evento Leave
        public void Leave(object sender, System.EventArgs e)
        {
            controlarColorFondo(ref sender, "Leave");
        }

        //Cambia el color de fondo segun tenga o pierda el foco
        private void controlarColorFondo(ref object sender, string foco)
        {
            try
            {
                Control control = (Control)sender;
                ucComboBoxActualizable cboa = null;
                if (control is ucComboBoxActualizable)
                    cboa = (ucComboBoxActualizable)control;

                if (foco == "Enter")
                {
                    control.BackColor = Color.AntiqueWhite;
                    control.ForeColor = Color.Black;
                    if (control.GetType() == typeof(TextBox) || control.GetType() == typeof(MaskedTextBox))
                    {
                        ((TextBoxBase)control).SelectAll();
                    }
                }
                else
                {
                    if ((control is Button) || (control is CheckBox) || (control is RadioButton))
                        control.BackColor = SystemColors.Control;
                    else
                        control.BackColor = SystemColors.Window;

                    control.ForeColor = Color.Black;
                }
                if (cboa != null)
                {
                    cboa.cboCombo.BackColor = control.BackColor;
                    cboa.cboCombo.ForeColor = control.ForeColor;
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

    }
}
