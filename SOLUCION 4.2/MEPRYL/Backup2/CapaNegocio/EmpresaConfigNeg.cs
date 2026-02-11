using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;
namespace CapaNegocio
{
   public class EmpresaConfigNeg:CapaNegocioBase.EntidadBase
    {
        public string razonSocial = "";
        public string rutaLogo = "";
        public string rutaFirma = "";
        public string direccion = "";
        public string unidadFotos = "";
        public EmpresaConfigNeg()
        { }
        public EmpresaConfigNeg(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.EmpresaConfigDal datParametrosPlacas = new CapaDatos.EmpresaConfigDal(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datParametrosPlacas;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datParametrosPlacas = (CapaDatos.EmpresaConfigDal)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datParametrosPlacas;
        }

    }
}
