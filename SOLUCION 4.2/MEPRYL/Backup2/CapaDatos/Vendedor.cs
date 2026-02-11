using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;

namespace CapaDatos
{
    public class Vendedor : PersonaBase
    {
        public Vendedor(string entidadNom)
            : base(entidadNom)
        { }

        public Vendedor(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }
    }
}
