using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class ChequeCuentaFactory : EntidadFactoryBase
    {
        public ChequeCuentaFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.ChequeCuentaFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.ChequeCuenta();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.ChequeCuenta negCuenta = new CapaNegocio.ChequeCuenta();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negCuenta;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negCuenta = (CapaNegocio.ChequeCuenta)destino;

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

                CapaDatos.ChequeCuenta datCuenta = (CapaDatos.ChequeCuenta)((CapaNegocio.ChequeCuenta)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(datCuenta);
                datCuenta = (CapaDatos.ChequeCuenta)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(datCuenta);

                resultado.objeto = (CapaNegocio.ChequeCuenta)negEntidad;
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

                CapaDatos.ChequeCuenta datCuenta = (CapaDatos.ChequeCuenta)((CapaNegocio.ChequeCuenta)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(datCuenta);

                datCuenta = (CapaDatos.ChequeCuenta)resultado.objeto;
                entidad = convertirEnObjetoNegocio(datCuenta);

                resultado.objeto = (CapaNegocio.ChequeCuenta)entidad;
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