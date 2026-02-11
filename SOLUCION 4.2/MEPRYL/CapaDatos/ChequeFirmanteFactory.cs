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
    public class ChequeFirmanteFactory : EntidadFactoryBase
    {
        public ChequeFirmante entidad;

        public ChequeFirmanteFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                ChequeFirmante firmante = (ChequeFirmante)entidad;

                SqlParameter[] param = new SqlParameter[4];

                param[0] = new SqlParameter("@id", firmante.id);
                param[1] = new SqlParameter("@descripcion", firmante.descripcion);
                param[2] = new SqlParameter("@cuentaID", firmante.cuentaID);
                param[3] = new SqlParameter("@registroBLOB", firmante.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_ChequeFirmante_Update", param);

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
            entidad = new ChequeFirmante(base.entidad);
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
                    ChequeFirmante dat = (ChequeFirmante)resultado.objeto;
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
            ChequeFirmante firmante = new ChequeFirmante(base.leerRegistro(dr));
            try
            {
                firmante.descripcion = dr["descripcion"].ToString();
                firmante.cuentaID = new Guid(dr["cuentaID"].ToString());
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return firmante;
        }
    }
}