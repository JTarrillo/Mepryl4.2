using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;

namespace CapaDatos
{
    public class Cliente : PersonaBase
    {
        public Cliente(string entidadNom) : base(entidadNom)
        { }

        public Cliente(EntidadBase entidad) : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }
    }
}
