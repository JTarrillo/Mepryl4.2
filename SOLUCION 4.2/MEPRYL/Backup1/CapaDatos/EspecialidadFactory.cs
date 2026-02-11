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
    public class EspecialidadFactory : EntidadFactoryBase
    {
        public Especialidad entidad;

        public EspecialidadFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                Especialidad objeto = (Especialidad)entidad;

                SqlParameter[] param = new SqlParameter[4];

                param[0] = new SqlParameter("@id", objeto.id);
                param[1] = new SqlParameter("@codigo", objeto.codigo);
                param[2] = new SqlParameter("@descripcion", objeto.descripcion);
                param[3] = new SqlParameter("@registroBLOB", objeto.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Especialidad_Update", param);

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
            entidad = new Especialidad(base.entidad);
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
                    Especialidad dat = (Especialidad)resultado.objeto;
                    resultado = modificar(dat);
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
            Especialidad objeto = new Especialidad(base.leerRegistro(dr));
            try
            {
                objeto.descripcion = dr["descripcion"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return objeto;
        }

        public bool yaExisteSimilar(CapaDatos.Especialidad objeto)
        {
            bool resultado = false;

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@descripcion", objeto.descripcion);

                SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_Especialidad_ExisteSimilar", param);

                resultado = dr.HasRows;

                dr.Close();
                dr = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }
    }
}
