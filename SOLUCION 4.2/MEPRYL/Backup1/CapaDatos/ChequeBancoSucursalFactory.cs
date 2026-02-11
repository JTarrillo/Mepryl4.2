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
    public class ChequeBancoSucursalFactory : EntidadFactoryBase
    {
        public ChequeBancoSucursal entidad;

        public ChequeBancoSucursalFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                ChequeBancoSucursal sucursal = (ChequeBancoSucursal)entidad;

                SqlParameter[] param = new SqlParameter[4];

                param[0] = new SqlParameter("@id", sucursal.id);
                param[1] = new SqlParameter("@descripcion", sucursal.descripcion);
                param[2] = new SqlParameter("@bancoID", sucursal.bancoID);
                param[3] = new SqlParameter("@registroBLOB", sucursal.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_ChequeBancoSucursal_Update", param);

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
            entidad = new ChequeBancoSucursal(base.entidad);
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
                    ChequeBancoSucursal dat = (ChequeBancoSucursal)resultado.objeto;
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
            ChequeBancoSucursal sucursal = new ChequeBancoSucursal(base.leerRegistro(dr));
            try
            {
                sucursal.descripcion = dr["descripcion"].ToString();
                sucursal.bancoID = new Guid(dr["bancoID"].ToString());
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return sucursal;
        }
    }
}
