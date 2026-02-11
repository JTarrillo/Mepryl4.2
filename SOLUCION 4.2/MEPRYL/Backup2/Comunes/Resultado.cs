using System;
using System.Collections.Generic;
using System.Text;

namespace Comunes
{
    public class Resultado
    {
        public object objeto;
        public string mensaje;

        public Resultado()
        {
            this.objeto = null;
            this.mensaje = "";
        }

        public Resultado(object obj, string mens)
        {
            this.objeto = obj;
            this.mensaje = mens;
        }
    }
}
