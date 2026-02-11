using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class CuentaFactory : EntidadFactoryBase
    {
        public CuentaFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.CuentaFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.Cuenta();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.Cuenta negCuenta = new CapaNegocio.Cuenta();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negCuenta;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negCuenta = (CapaNegocio.Cuenta)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return negCuenta;
        }

        //Da el alta recibiendo todos los datos en un objeto
        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            Resultado resultado = new Resultado();
            try
            {
                crearDatEntidadFac();

                CapaDatos.Cuenta datCuenta = (CapaDatos.Cuenta)((CapaNegocio.Cuenta)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(datCuenta);
                datCuenta = (CapaDatos.Cuenta)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(datCuenta);

                resultado.objeto = (CapaNegocio.Cuenta)negEntidad;
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

                CapaDatos.Cuenta datCuenta = (CapaDatos.Cuenta)((CapaNegocio.Cuenta)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(datCuenta);

                datCuenta = (CapaDatos.Cuenta)resultado.objeto;
                entidad = convertirEnObjetoNegocio(datCuenta);

                resultado.objeto = (CapaNegocio.Cuenta)entidad;
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