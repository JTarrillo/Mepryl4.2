using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class Profesional : EntidadBase
    {
        public string apellido = "";
        public string nombres = "";
        public string telefonos = "";
        public string observaciones = "";

        public Profesional(string entidadNom)
            : base(entidadNom)
        { }

        public Profesional(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}
