using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class ChequeCuenta : EntidadBase
    {
        public string descripcion = "";
        public Guid clienteID = new Guid(Utilidades.ID_VACIO);
        public Guid bancoID = new Guid(Utilidades.ID_VACIO);
        public Guid bancoSucursalID = new Guid(Utilidades.ID_VACIO);

        public ChequeCuenta(string entidadNom)
            : base(entidadNom)
        { }

        public ChequeCuenta(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}