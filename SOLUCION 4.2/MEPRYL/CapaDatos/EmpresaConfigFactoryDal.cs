using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaDatosBase;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
namespace CapaDatos
{
   public class EmpresaConfigFactoryDal:EntidadFactoryBase
    {
       public EmpresaConfigFactoryDal(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }
       public override Resultado modificar(EntidadBase entidad)
       {
           Resultado resultado = new Resultado(entidad, "");
           try
           {
               EmpresaConfigDal parametrosConfig = (EmpresaConfigDal)entidad;

               SqlParameter[] param = new SqlParameter[5];

               param[0] = new SqlParameter("@id", parametrosConfig.id);
               param[1] = new SqlParameter("@razonSocial", parametrosConfig.razonSocial);
               param[2] = new SqlParameter("@rutaLogo", parametrosConfig.rutaLogo);
               param[3] = new SqlParameter("@rutaFirma", parametrosConfig.rutaFirma);
               param[4] = new SqlParameter("@direccion", parametrosConfig.direccion);
               param[5] = new SqlParameter("@unidadFotos", parametrosConfig.unidadFotos);


               SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_ConfigEmpresa_Update", param);

           }
           catch (Exception ex)
           {
               ManejadorErrores.escribirLog(ex, true, this.configuracion);
               resultado.mensaje = ex.Message;
           }

           return resultado;
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
                   ParametrosPlacas datParametrosPlacas = (ParametrosPlacas)resultado.objeto;
                   resultado = modificar(datParametrosPlacas);
               }
           }
           catch (Exception ex)
           {
               ManejadorErrores.escribirLog(ex, true, this.configuracion);
               resultado.mensaje = ex.Message;
           }
           return resultado;
       }

    }
}
