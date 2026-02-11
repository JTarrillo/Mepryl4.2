using System;
using System.Collections.Generic;
using System.Text;
using Comunes;

namespace CapaNegocioBase 
{
    public abstract class PersonaFactoryBase : EntidadFactoryBase
    {
        public PersonaFactoryBase(Configuracion conf, string entNombre) : base(conf, entNombre)
        {
        }

        protected override abstract CapaNegocioBase.EntidadBase crearEntidadNegocio();
    }
}
