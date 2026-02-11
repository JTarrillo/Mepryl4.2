using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class PacienteTipo : EntidadBase
    {
        public string descripcion = "";

        public PacienteTipo(string entidadNom)
            : base(entidadNom)
        { }

        public PacienteTipo(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}
