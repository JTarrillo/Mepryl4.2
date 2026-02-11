using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class ProfesionalFactory : EntidadFactoryBase
    {
        public Profesional entidad;

        public ProfesionalFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                Profesional profesional = (Profesional)entidad;

                SqlParameter[] param = new SqlParameter[7];

                param[0] = new SqlParameter("@id", profesional.id);
                param[1] = new SqlParameter("@codigo", profesional.codigo);
                param[2] = new SqlParameter("@apellido", profesional.apellido);
                param[3] = new SqlParameter("@nombres", profesional.nombres);
                param[4] = new SqlParameter("@telefonos", profesional.telefonos);
                param[5] = new SqlParameter("@observaciones", profesional.observaciones);
                param[6] = new SqlParameter("@registroBLOB", profesional.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Profesional_Update", param);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }

            return resultado;
        }

        //Implementacion
        public override void inicializarEntidad()
        {
            base.inicializarEntidad();
            entidad = new Profesional(base.entidad);
        }

        public override Resultado alta(EntidadBase ent)
        {
            Resultado resultado = new Resultado();
            try
            {
                //Da el alta del registro vacío para obtener el ID
                resultado = altaID(ent);

                //Modifica el registro nuevo con los datos completos del alta
                if (resultado.mensaje == "")
                {
                    Profesional datProfesional = (Profesional)resultado.objeto;
                    resultado = modificar(datProfesional);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

        //Lee el registro obtenido de la base de datos, cada implementación agrega los campos espefícicos.
        protected override EntidadBase leerRegistro(SqlDataReader dr)
        {
            Profesional profesional = new Profesional(base.leerRegistro(dr));
            try
            {
                profesional.apellido = dr["apellido"].ToString();
                profesional.nombres = dr["nombres"].ToString();
                profesional.telefonos = dr["telefonos"].ToString();
                profesional.observaciones = dr["observaciones"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return profesional;
        }
    }
}
