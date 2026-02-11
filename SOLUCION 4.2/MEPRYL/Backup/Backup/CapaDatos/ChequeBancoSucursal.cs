using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class ChequeBancoSucursal : EntidadBase
    {
        public string descripcion = "";
        public Guid bancoID = new Guid(Utilidades.ID_VACIO);
        
        public ChequeBancoSucursal(string entidadNom)
            : base(entidadNom)
        { }

        public ChequeBancoSucursal(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}