using System;
using System.Collections.Generic;
using System.Text;
using Comunes;

namespace CapaDatosBase
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

        public PersonaBase(string entNombre) : base(entNombre)
        { }

        public PersonaBase(EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        /*public override string getRegistroBLOB()
        {
            string resultado = base.getRegistroBLOB();
            try
            {
                resultado += " " + this.apellido;
                resultado += " " + this.nombres;
                resultado += " " + this.direccion;
                resultado += " " + this.localidadDesc;
                resultado += " " + this.codigoPostal;
                resultado += " " + this.provinciaDesc;
                resultado += " " + this.ubicacionGuia;
                resultado += " " + this.dni;
                resultado += " " + this.fechaNacimiento.ToShortDateString();
                resultado += " " + this.eMail;
                resultado += " " + this.observaciones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return resultado;
        }*/
    }
}
