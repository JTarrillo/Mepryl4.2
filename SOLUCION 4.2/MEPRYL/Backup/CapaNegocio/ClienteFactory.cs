using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class ClienteFactory : PersonaFactoryBase
    {
        public ClienteFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.ClienteFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.Cliente();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.Cliente negCliente = new CapaNegocio.Cliente();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negCliente;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negCliente = (CapaNegocio.Cliente)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return negCliente;
        }

        //Da el alta recibiendo todos los datos en un objeto
        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            Resultado resultado = new Resultado();
            try
            {
                crearDatEntidadFac();

                CapaDatos.Cliente datCliente = (CapaDatos.Cliente)((CapaNegocio.Cliente)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(datCliente);
                datCliente = (CapaDatos.Cliente)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(datCliente);

                resultado.objeto = (CapaNegocio.Cliente)negEntidad;
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

                CapaDatos.Cliente datCliente = (CapaDatos.Cliente)((CapaNegocio.Cliente)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(datCliente);

                datCliente = (CapaDatos.Cliente)resultado.objeto;
                entidad = convertirEnObjetoNegocio(datCliente);

                resultado.objeto = (CapaNegocio.Cliente)entidad;
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
