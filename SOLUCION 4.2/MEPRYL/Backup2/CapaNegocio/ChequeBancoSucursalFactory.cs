using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class ChequeBancoSucursalFactory : EntidadFactoryBase
    {
        public ChequeBancoSucursalFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.ChequeBancoSucursalFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.ChequeBancoSucursal();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.ChequeBancoSucursal neg = new CapaNegocio.ChequeBancoSucursal();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)neg;

                Utilidades.copiarAtributos(ref origen, ref destino);
                neg = (CapaNegocio.ChequeBancoSucursal)destino;

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

                CapaDatos.ChequeBancoSucursal dat = (CapaDatos.ChequeBancoSucursal)((CapaNegocio.ChequeBancoSucursal)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(dat);
                dat = (CapaDatos.ChequeBancoSucursal)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(dat);

                resultado.objeto = (CapaNegocio.ChequeBancoSucursal)negEntidad;
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

                CapaDatos.ChequeBancoSucursal dat = (CapaDatos.ChequeBancoSucursal)((CapaNegocio.ChequeBancoSucursal)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(dat);

                dat = (CapaDatos.ChequeBancoSucursal)resultado.objeto;
                entidad = convertirEnObjetoNegocio(dat);

                resultado.objeto = (CapaNegocio.ChequeBancoSucursal)entidad;
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