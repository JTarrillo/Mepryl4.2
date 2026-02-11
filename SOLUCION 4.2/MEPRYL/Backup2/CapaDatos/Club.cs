using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class Club : EntidadBase
    {
        public string descripcion = "";
        public Guid ligaID = new Guid(Utilidades.ID_VACIO);
        public string observaciones = "";

        public Club(string entidadNom)
            : base(entidadNom)
        { }

        public Club(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}
