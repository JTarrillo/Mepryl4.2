using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class Empresa : EntidadBase
    {
        public string razonSocial = "";
        public string nombreFantasia = "";
        public string cuit = "";
        public Guid ivaID = new Guid(Utilidades.ID_VACIO);
        public Guid localidadID = new Guid(Utilidades.ID_VACIO);
        public string direccion = "";
        public string telefonos = "";
        public string celular = "";
        public string codigoPostal = "";
        public string eMail = "";
        public string contacto = "";
        public bool pagaAbono = false;
        public double importe = 0;
        public DateTime fechaActualizacion = new DateTime(1900,01,01);
        public Guid listaPreciosID = new Guid(Utilidades.ID_VACIO);
        public string observaciones = "";

        public Empresa(string entidadNom)
            : base(entidadNom)
        { }

        public Empresa(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}
