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
    public class ClubFactory : EntidadFactoryBase
    {
        public Club entidad;

        public ClubFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                Club club = (Club)entidad;

                SqlParameter[] param = new SqlParameter[6];

                param[0] = new SqlParameter("@id", club.id);
                param[1] = new SqlParameter("@codigo", club.codigo);
                param[2] = new SqlParameter("@descripcion", club.descripcion);
                param[3] = new SqlParameter("@ligaID", club.ligaID);
                param[4] = new SqlParameter("@observaciones", club.observaciones);
                param[5] = new SqlParameter("@registroBLOB", club.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Club_Update", param);

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
            entidad = new Club(base.entidad);
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
                    Club datClub = (Club)resultado.objeto;
                    resultado = modificar(datClub);
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
            Club club = new Club(base.leerRegistro(dr));
            try
            {
                club.descripcion = dr["descripcion"].ToString();
                club.ligaID = new Guid(dr["ligaID"].ToString());
                club.observaciones = dr["observaciones"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return club;
        }

        public bool yaExisteClubSimilar(CapaDatos.Club club)
        {
            bool resultado = false;

            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@descripcion", club.descripcion);
                param[1] = new SqlParameter("@ligaID", club.ligaID);

                SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_Club_ExisteSimilar", param);

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
