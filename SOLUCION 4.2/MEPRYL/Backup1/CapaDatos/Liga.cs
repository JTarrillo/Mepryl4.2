using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class Liga : EntidadBase
    {
        public string descripcion = "";
        
        public Liga(string entidadNom)
            : base(entidadNom)
        { }

        public Liga(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}
