using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class ParametrosPlacasFactory : EntidadFactoryBase
    {
        public ParametrosPlacasFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.ParametrosPlacasFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.Paciente();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.ParametrosPlacas negParametrosPlacas = new CapaNegocio.ParametrosPlacas();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negParametrosPlacas;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negParametrosPlacas = (CapaNegocio.ParametrosPlacas)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return negParametrosPlacas;
        }

        //Da el alta recibiendo todos los datos en un objeto
        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            Resultado resultado = new Resultado();
            try
            {
                crearDatEntidadFac();

                CapaDatos.ParametrosPlacas datParametrosPlacas = (CapaDatos.ParametrosPlacas)((CapaNegocio.ParametrosPlacas)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(datParametrosPlacas);
                datParametrosPlacas = (CapaDatos.ParametrosPlacas)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(datParametrosPlacas);

                resultado.objeto = (CapaNegocio.ParametrosPlacas)negEntidad;
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

                CapaDatos.ParametrosPlacas datParametrosPlacas = (CapaDatos.ParametrosPlacas)((CapaNegocio.ParametrosPlacas)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(datParametrosPlacas);

                datParametrosPlacas = (CapaDatos.ParametrosPlacas)resultado.objeto;
                entidad = convertirEnObjetoNegocio(datParametrosPlacas);

                resultado.objeto = (CapaNegocio.ParametrosPlacas)entidad;
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