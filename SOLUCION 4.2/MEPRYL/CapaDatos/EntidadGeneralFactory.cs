using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class EntidadGeneralFactory : EntidadFactoryBase
    {
        public EntidadGeneralFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }


        public override Resultado modificar(EntidadBase entidad)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        //Implementacion
        public override void inicializarEntidad()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override Resultado alta(EntidadBase entidad)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
