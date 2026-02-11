using System;
using Comunes;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Comunes
{
    /// <summary>
    /// Summary description for CapsulaControl.
    /// </summary>
    public class CapsulaControl
    {
        public Control control;
        public string nombre;
        public int indice;
        public char keyCode;

        public CapsulaControl()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public CapsulaControl(Control ctrl)
        {
            this.control = ctrl;
            this.nombre = ctrl.Name;
            this.indice = 0;
            this.keyCode = (char)Keys.VolumeDown;
        }
        public CapsulaControl(Control ctrl, int ind)
        {
            this.control = ctrl;
            this.nombre = ctrl.Name;
            this.indice = ind;
            this.keyCode = (char)Keys.VolumeDown;
        }
        public CapsulaControl(Control ctrl, int ind, char key)
        {
            this.control = ctrl;
            this.nombre = ctrl.Name;
            this.indice = ind;
            this.keyCode = key;
        }

        public CapsulaControl(Control ctrl, char key)
        {
            this.control = ctrl;
            this.nombre = ctrl.Name;
            this.indice = 0;
            this.keyCode = key;
        }
    }
}
