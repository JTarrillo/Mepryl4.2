using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class ChequeFirmanteFactory : EntidadFactoryBase
    {
        public ChequeFirmanteFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.ChequeFirmanteFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.ChequeFirmante();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.ChequeFirmante neg = new CapaNegocio.ChequeFirmante();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)neg;

                Utilidades.copiarAtributos(ref origen, ref destino);
                neg = (CapaNegocio.ChequeFirmante)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return neg;
        }

        //Da el alta recibiendo todos los datos en un objeto
        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            Resultado resultado = new Resultado();
            try
            {
                crearDatEntidadFac();

                CapaDatos.ChequeFirmante dat = (CapaDatos.ChequeFirmante)((CapaNegocio.ChequeFirmante)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(dat);
                dat = (CapaDatos.ChequeFirmante)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(dat);

                resultado.objeto = (CapaNegocio.ChequeFirmante)negEntidad;
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

                CapaDatos.ChequeFirmante dat = (CapaDatos.ChequeFirmante)((CapaNegocio.ChequeFirmante)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(dat);

                dat = (CapaDatos.ChequeFirmante)resultado.objeto;
                entidad = convertirEnObjetoNegocio(dat);

                resultado.objeto = (CapaNegocio.ChequeFirmante)entidad;
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