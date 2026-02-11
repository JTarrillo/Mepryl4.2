using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;

namespace CapaDatos
{
    public class Horario : EntidadBase
    {
        public Guid profesionalID = new Guid(Utilidades.ID_VACIO);
        public string profesionalTexto = "";
        public Guid especialidadID = new Guid(Utilidades.ID_VACIO);
        public string especialidadTexto = "";
        public bool domingo = false;
        public bool lunes = false;
        public bool martes = false;
        public bool miercoles = false;
        public bool jueves = false;
        public bool viernes = false;
        public bool sabado = false;
        public string diasSimplificado = "";
        public string horaDesde = "09:00";
        public string horaHasta = "17:00";
        public int cantidadTurnos = 0;
        public int citarCada = 0;
        public int pacientesGrupo = 0;
        public DateTime fechaDesde = DateTime.Now;
        public DateTime fechaHasta = DateTime.Now;
        public string observaciones = "";

        public Horario(string entidadNom)
            : base(entidadNom)
        { }

        public Horario(EntidadBase entidad)
            : base(entidad.EntidadNombre)
        {
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.campos = entidad.campos;
        }

        

    }
}
