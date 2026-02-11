using System;
using System.Collections.Generic;
using System.Text;
using Comunes;

namespace CapaNegocioBase
{
    public class PersonaBase : EntidadBase
    {
        public string apellido = "";
        public string nombres = "";
        public string direccion = "";
        public Guid localidadID = new Guid(Utilidades.ID_VACIO);
        public string localidadDesc = "";
        public string codigoPostal = "";
        public Guid provinciaID = new Guid(Utilidades.ID_VACIO);
        public string provinciaDesc = "";
        public string ubicacionGuia = "";
        public string dni = "";
        public DateTime fechaNacimiento = DateTime.Now;
        public string eMail = "";
        public string telefonos = "";
        public string paginaWeb = "";
        public string observaciones = "";

        //private CapaDatosBase.PersonaBase datEntidad;

        public PersonaBase()
        { }

        public PersonaBase(EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        public CapaDatosBase.EntidadBase convertirEnObjetoDatos() { return null; }
       

        //En cada subclase se debe inicializar el objeto datEntidad del tipo especifico.
        protected override void inicializar()
        {
            datEntidad = new CapaDatosBase.PersonaBase(this.EntidadNombre);
            
        }
    }
}
