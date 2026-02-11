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
    public class EmpresaFactory : EntidadFactoryBase
    {
        public Empresa entidad;

        public EmpresaFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                Empresa empresa = (Empresa)entidad;

                SqlParameter[] param = new SqlParameter[19];

                param[0] = new SqlParameter("@id", empresa.id);
                param[1] = new SqlParameter("@codigo", empresa.codigo);
                param[2] = new SqlParameter("@razonSocial", empresa.razonSocial);
                param[3] = new SqlParameter("@nombreFantasia", empresa.nombreFantasia);
                param[4] = new SqlParameter("@cuit", empresa.cuit);
                param[5] = new SqlParameter("@ivaID", empresa.ivaID);
                param[6] = new SqlParameter("@localidadID", empresa.localidadID);
                param[7] = new SqlParameter("@direccion", empresa.direccion);
                param[8] = new SqlParameter("@telefonos", empresa.telefonos);
                param[9] = new SqlParameter("@celular", empresa.celular);
                param[10] = new SqlParameter("@codigoPostal", empresa.codigoPostal);
                param[11] = new SqlParameter("@eMail", empresa.eMail);
                param[12] = new SqlParameter("@contacto", empresa.contacto);
                param[13] = new SqlParameter("@pagaAbono", empresa.pagaAbono);
                param[14] = new SqlParameter("@importe", empresa.importe);
                param[15] = new SqlParameter("@fechaActualizacion", empresa.fechaActualizacion);
                param[16] = new SqlParameter("@listaPreciosID", empresa.listaPreciosID);
                param[17] = new SqlParameter("@observaciones", empresa.observaciones);
                param[18] = new SqlParameter("@registroBLOB", empresa.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Empresa_Update", param);

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
            entidad = new Empresa(base.entidad);
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
                    Empresa datEmpresa = (Empresa)resultado.objeto;
                    resultado = modificar(datEmpresa);
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
            Empresa empresa = new Empresa(base.leerRegistro(dr)); 
            try
            {
                empresa.razonSocial = dr["razonSocial"].ToString();
                empresa.nombreFantasia = dr["nombreFantasia"].ToString();
                empresa.cuit = dr["cuit"].ToString();
                empresa.ivaID = new Guid(dr["ivaID"].ToString());
                empresa.localidadID = new Guid(dr["localidadID"].ToString());
                empresa.direccion = dr["direccion"].ToString();
                empresa.telefonos = dr["telefonos"].ToString();
                empresa.celular = dr["celular"].ToString();
                empresa.codigoPostal = dr["codigoPostal"].ToString();
                empresa.eMail = dr["eMail"].ToString();
                empresa.contacto = dr["contacto"].ToString();
                empresa.pagaAbono = bool.Parse(dr["pagaAbono"].ToString());
                empresa.importe = double.Parse("0" + dr["importe"].ToString());
                empresa.fechaActualizacion = DateTime.Parse(dr["fechaActualizacion"].ToString());
                empresa.listaPreciosID = new Guid(dr["listaPreciosID"].ToString());
                empresa.observaciones = dr["observaciones"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return empresa;
        }
    }
}
