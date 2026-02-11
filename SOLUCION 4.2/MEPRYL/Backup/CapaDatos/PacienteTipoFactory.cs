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
    public class PacienteTipoFactory : EntidadFactoryBase
    {
        public PacienteTipo entidad;

        public PacienteTipoFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                PacienteTipo pacienteTipo = (PacienteTipo)entidad;

                SqlParameter[] param = new SqlParameter[4];

                param[0] = new SqlParameter("@id", pacienteTipo.id);
                param[1] = new SqlParameter("@codigo", pacienteTipo.codigo);
                param[2] = new SqlParameter("@descripcion", pacienteTipo.descripcion);
                param[3] = new SqlParameter("@registroBLOB", pacienteTipo.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_PacienteTipo_Update", param);

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
            entidad = new PacienteTipo(base.entidad);
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
                    PacienteTipo datPacienteTipo = (PacienteTipo)resultado.objeto;
                    resultado = modificar(datPacienteTipo);
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
            PacienteTipo pacienteTipo = new PacienteTipo(base.leerRegistro(dr));
            try
            {
                pacienteTipo.descripcion = dr["descripcion"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return pacienteTipo;
        }
    }
}
