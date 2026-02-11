using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;
namespace CapaNegocio
{//Viviana
   public class EmpresaConfigFactoryNeg:EntidadFactoryBase
    {
       public EmpresaConfigFactoryNeg(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }
       public override void crearDatEntidadFac()
       {
           this.datEntidadFac = new CapaDatos.EmpresaConfigFactoryDal(this.configuracion, this.EntidadNombre);
       }
       protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
       {//Viviana
           return new CapaNegocio.EmpresaConfigNeg();
       }

       public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
       {
           Resultado resultado = new Resultado();
           try
           {
               crearDatEntidadFac();

               CapaDatos.EmpresaConfigDal datConfigEmp = (CapaDatos.EmpresaConfigDal)((CapaNegocio.EmpresaConfigNeg)negEntidad).convertirEnObjetoDatos();

               resultado = datEntidadFac.alta(datConfigEmp);
               datConfigEmp = (CapaDatos.EmpresaConfigDal)resultado.objeto;
               negEntidad = convertirEnObjetoNegocio(datConfigEmp);

               resultado.objeto = (CapaNegocio.EmpresaConfigNeg)negEntidad;
           }
           catch (Exception ex)
           {
               ManejadorErrores.escribirLog(ex, true, this.configuracion);
               resultado.mensaje = ex.Message;
           }
           return resultado;
       }
       public override Resultado modificar(EntidadBase entidad)
       {
           Resultado resultado = new Resultado(entidad, "");

           try
           {
               crearDatEntidadFac();

               CapaDatos.EmpresaConfigDal datConfigEmp = (CapaDatos.EmpresaConfigDal)((CapaNegocio.EmpresaConfigNeg)entidad).convertirEnObjetoDatos();
               resultado = datEntidadFac.modificar(datConfigEmp);

               datConfigEmp = (CapaDatos.EmpresaConfigDal)resultado.objeto;
               entidad = convertirEnObjetoNegocio(datConfigEmp);

               resultado.objeto = (CapaNegocio.EmpresaConfigNeg)entidad;
           }
           catch (Exception ex)
           {
               ManejadorErrores.escribirLog(ex, true, this.configuracion);
               resultado.mensaje = ex.Message;
           }
           return resultado;
       }

       protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
       {
           CapaNegocio.EmpresaConfigNeg negConfigEmpr = new CapaNegocio.EmpresaConfigNeg();
           try
           {
               /*************************/
               /* Copia las propiedades */
               object origen = (object)datEntidad;
               object destino = (object)negConfigEmpr;

               Utilidades.copiarAtributos(ref origen, ref destino);
               negConfigEmpr = (CapaNegocio.EmpresaConfigNeg)destino;

               origen = null;
               destino = null;
               /*************************/
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message, ex);
           }
           return negConfigEmpr;
       }


    }
}
