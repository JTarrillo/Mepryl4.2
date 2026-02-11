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
    public class ChequeFactory : EntidadFactoryBase
    {
        public Cheque entidad;

        public ChequeFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                Cheque cheque = (Cheque)entidad;

                SqlParameter[] param = new SqlParameter[17];

                param[0] = new SqlParameter("@id", cheque.id);
                param[1] = new SqlParameter("@codigo", cheque.codigo);
                param[2] = new SqlParameter("@vencimiento", cheque.vencimiento);
                param[3] = new SqlParameter("@clienteID", cheque.clienteID);
                param[4] = new SqlParameter("@bancoID", cheque.bancoID);
                param[5] = new SqlParameter("@sucursalID", cheque.sucursalID);
                param[6] = new SqlParameter("@nroCheque", cheque.nroCheque);
                param[7] = new SqlParameter("@cuentaID", cheque.cuentaID);
                param[8] = new SqlParameter("@importe", cheque.importe);
                param[9] = new SqlParameter("@firmanteID", cheque.firmanteID);
                param[10] = new SqlParameter("@baja", cheque.baja);
                param[11] = new SqlParameter("@proveedorID", cheque.proveedorID);
                param[12] = new SqlParameter("@fechaBaja", cheque.fechaBaja);
                param[13] = new SqlParameter("@rechazado", cheque.rechazado);
                param[14] = new SqlParameter("@fechaRechazo", cheque.fechaRechazo);
                param[15] = new SqlParameter("@comentariosRechazo", cheque.comentariosRechazo);
                param[16] = new SqlParameter("@registroBLOB", cheque.getRegistroBLOB()+"  "+cheque.importe.ToString());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Cheque_Update", param);

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
            entidad = new Cheque(base.entidad);
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
                    Cheque datCheque = (Cheque)resultado.objeto;
                    resultado = modificar(datCheque);
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
            Cheque cheque = new Cheque(base.leerRegistro(dr));
            try
            {
                cheque.cuentaID = new Guid(dr["cuentaID"].ToString());
                cheque.clienteID = new Guid(dr["clienteID"].ToString());
                cheque.bancoID = new Guid(dr["bancoID"].ToString());
                cheque.sucursalID = new Guid(dr["sucursalID"].ToString());
                cheque.nroCheque = dr["nroCheque"].ToString();
                cheque.vencimiento = DateTime.Parse(dr["vencimiento"].ToString());
                cheque.importe = Double.Parse(dr["importe"].ToString());
                cheque.firmanteID = new Guid(dr["firmanteID"].ToString());
                cheque.baja = bool.Parse(dr["baja"].ToString());
                cheque.proveedorID = new Guid(dr["proveedorID"].ToString());
                cheque.fechaBaja = DateTime.Parse(dr["fechaBaja"].ToString());
                cheque.rechazado = bool.Parse(dr["rechazado"].ToString());
                cheque.fechaRechazo = DateTime.Parse(dr["fechaRechazo"].ToString());
                cheque.comentariosRechazo = dr["comentariosRechazo"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return cheque;
        }
    }
}
