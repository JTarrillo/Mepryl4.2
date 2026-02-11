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
    public class ChequeCuentaFactory : EntidadFactoryBase
    {
        public ChequeCuenta entidad;

        public ChequeCuentaFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                ChequeCuenta cuenta = (ChequeCuenta)entidad;

                SqlParameter[] param = new SqlParameter[6];

                param[0] = new SqlParameter("@id", cuenta.id);
                param[1] = new SqlParameter("@descripcion", cuenta.descripcion);
                param[2] = new SqlParameter("@clienteID", cuenta.clienteID);
                param[3] = new SqlParameter("@bancoID", cuenta.bancoID);
                param[4] = new SqlParameter("@bancoSucursalID", cuenta.bancoSucursalID);
                param[5] = new SqlParameter("@registroBLOB", cuenta.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_ChequeCuenta_Update", param);

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
            entidad = new ChequeCuenta(base.entidad);
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
                    ChequeCuenta datCuenta = (ChequeCuenta)resultado.objeto;
                    resultado = modificar(datCuenta);
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
            ChequeCuenta cuenta = new ChequeCuenta(base.leerRegistro(dr));
            try
            {
                cuenta.bancoID = new Guid(dr["bancoID"].ToString());
                cuenta.bancoSucursalID = new Guid(dr["bancoSucursalID"].ToString());
                cuenta.clienteID = new Guid(dr["clienteID"].ToString());
                cuenta.descripcion = dr["descripcion"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return cuenta;
        }
    }
}
