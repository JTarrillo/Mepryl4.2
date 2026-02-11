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
    public class LigaFactory : EntidadFactoryBase
    {
        public Liga entidad;

        public LigaFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                Liga liga = (Liga)entidad;

                SqlParameter[] param = new SqlParameter[4];

                param[0] = new SqlParameter("@id", liga.id);
                param[1] = new SqlParameter("@codigo", liga.codigo);
                param[2] = new SqlParameter("@descripcion", liga.descripcion);
                param[3] = new SqlParameter("@registroBLOB", liga.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Liga_Update", param);

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
            entidad = new Liga(base.entidad);
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
                    Liga datLiga = (Liga)resultado.objeto;
                    resultado = modificar(datLiga);
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
            Liga liga = new Liga(base.leerRegistro(dr));
            try
            {
                liga.descripcion = dr["descripcion"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return liga;
        }

        public bool yaExisteLigaSimilar(CapaDatos.Liga liga)
        {
            bool resultado = false;

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@descripcion", liga.descripcion);

                SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_Liga_ExisteSimilar", param);

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
