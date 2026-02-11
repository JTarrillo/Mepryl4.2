using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class Cheque : EntidadBase
    {
        public DateTime vencimiento = DateTime.Now;
        public Guid clienteID = new Guid(Utilidades.ID_VACIO);
        public string clienteTexto = "";
        public Guid bancoID = new Guid(Utilidades.ID_VACIO);
        public string bancoTexto = "";
        public Guid sucursalID = new Guid(Utilidades.ID_VACIO);
        public string sucursalTexto = "";
        public string nroCheque = "";
        public Guid cuentaID = new Guid(Utilidades.ID_VACIO);
        public string cuentaTexto = "";
        public double importe = 0;
        public Guid firmanteID = new Guid(Utilidades.ID_VACIO);
        public string firmanteTexto = "";
        public bool baja = false;
        public Guid proveedorID = new Guid(Utilidades.ID_VACIO);
        public string proveedorTexto = "";
        public DateTime fechaBaja = DateTime.Now;
        public bool rechazado = false;
        public DateTime fechaRechazo = DateTime.Now;
        public string comentariosRechazo = "";

        public Cheque(string entidadNom)
            : base(entidadNom)
        { }

        public Cheque(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}
