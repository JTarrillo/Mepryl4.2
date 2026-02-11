using System;
using System.Collections.Generic;
using System.Text;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace CapaDatosBase
{
    public abstract class PersonaFactoryBase : EntidadFactoryBase
    {
        public PersonaBase entidad;
        public PersonaFactoryBase(Configuracion conf, string entNombre) : base(conf, entNombre)
        { }

        public abstract override Resultado modificar(EntidadBase entidad);

        //Implementacion
        public override void inicializarEntidad()
        {
            base.inicializarEntidad();
            entidad = new PersonaBase(base.entidad);
        }

        
        //Lee el registro obtenido de la base de datos, cada implementación agrega los campos espefícicos.
        protected override EntidadBase leerRegistro(SqlDataReader dr)
        {
            PersonaBase persona = new PersonaBase(base.leerRegistro(dr));
            try
            {
                persona.apellido = dr["apellido"].ToString();
                persona.nombres = dr["nombres"].ToString();
                persona.direccion = dr["direccion"].ToString();
                persona.localidadID = new Guid(dr["localidadID"].ToString());
                persona.codigoPostal = dr["codigoPostal"].ToString();
                persona.provinciaID = new Guid(dr["provinciaID"].ToString());
                persona.ubicacionGuia = dr["ubicacionGuia"].ToString();
                persona.dni = dr["dni"].ToString();
                persona.fechaNacimiento = DateTime.Parse(dr["fechaNacimiento"].ToString());
                persona.eMail = dr["email"].ToString();
                persona.telefonos = dr["telefonos"].ToString();
                persona.paginaWeb = dr["paginaWeb"].ToString();
                persona.observaciones = dr["observaciones"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return persona;
        }
        
    }
}
