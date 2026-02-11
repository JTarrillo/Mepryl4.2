using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class Especialidad : EntidadBase
    {
        public string descripcion = "";
        
        public Especialidad(string entidadNom)
            : base(entidadNom)
        { }

        public Especialidad(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}
