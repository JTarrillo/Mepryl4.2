using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class ChequeFirmante : EntidadBase
    {
        public string descripcion = "";
        public Guid cuentaID = new Guid(Utilidades.ID_VACIO);

        public ChequeFirmante(string entidadNom)
            : base(entidadNom)
        { }

        public ChequeFirmante(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}