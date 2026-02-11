using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class Cuenta : EntidadBase
    {
        public string descripcion = "";
        public Guid clienteID = new Guid(Utilidades.ID_VACIO);
        public Guid bancoID = new Guid(Utilidades.ID_VACIO);
        public Guid bancoSucursalID = new Guid(Utilidades.ID_VACIO);

        public Cuenta(string entidadNom)
            : base(entidadNom)
        { }

        public Cuenta(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}