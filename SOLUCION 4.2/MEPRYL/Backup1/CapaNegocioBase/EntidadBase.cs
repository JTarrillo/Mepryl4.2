using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;


namespace CapaNegocioBase
{
    public class EntidadBase
    {
        public Guid id = new Guid(Utilidades.ID_VACIO);
        public string codigo = "";
        public string EntidadNombre = "";
        public Dictionary<string, object> campos = new Dictionary<string, object>();
        public CapaDatosBase.EntidadBase datEntidad;


        public virtual CapaDatosBase.EntidadBase convertirEnObjetoDatos(){ return null; }
       

        //En cada subclase se debe inicializar el objeto datEntidad del tipo especifico.
        protected virtual void inicializar()
        {
            datEntidad = new CapaDatosBase.EntidadBase(this.EntidadNombre);
        }       
    }
}
