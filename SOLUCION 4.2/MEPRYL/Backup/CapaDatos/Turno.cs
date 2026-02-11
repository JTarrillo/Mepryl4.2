using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class Turno : EntidadBase
    {

        public DateTime fecha = DateTime.Now;
        public Guid estadoID = new Guid(Utilidades.ID_VACIO);
        public string estadoTexto = "";
        public string especialidadTexto = "";
        public string profesionalTexto = "";
        public string hora = "00:00";
        public string horaReferencia = "00:00";
        public int nroOrden = 0;
        public Guid pacienteID = new Guid(Utilidades.ID_VACIO);
        public Guid horarioID = new Guid(Utilidades.ID_VACIO);
        public string observaciones = "";
        public string pacienteTexto = "";
        public string pacienteTelefonos = "";
        public string pacienteCelular = "";
        public string pacienteDni = "";

        public bool domingo = false;
        public bool lunes = false;
        public bool martes = false;
        public bool miercoles = false;
        public bool jueves = false;
        public bool viernes = false;
        public bool sabado = false;

        public Guid usuarioID = new Guid(Utilidades.ID_VACIO);
        public string usuarioTexto = "";

        public Turno(string entidadNom)
            : base(entidadNom)
        { }

        public Turno(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }
    }
}
