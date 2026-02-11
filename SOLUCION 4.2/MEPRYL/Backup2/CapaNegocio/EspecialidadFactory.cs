using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class EspecialidadFactory : EntidadFactoryBase
    {
        public EspecialidadFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.EspecialidadFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.Especialidad();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.Especialidad neg = new CapaNegocio.Especialidad();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)neg;

                Utilidades.copiarAtributos(ref origen, ref destino);
                neg = (CapaNegocio.Especialidad)destino;

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

                CapaDatos.Especialidad dat = (CapaDatos.Especialidad)((CapaNegocio.Especialidad)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(dat);
                dat = (CapaDatos.Especialidad)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(dat);

                resultado.objeto = (CapaNegocio.Especialidad)negEntidad;
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

                CapaDatos.Especialidad dat = (CapaDatos.Especialidad)((CapaNegocio.Especialidad)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(dat);

                dat = (CapaDatos.Especialidad)resultado.objeto;
                entidad = convertirEnObjetoNegocio(dat);

                resultado.objeto = (CapaNegocio.Especialidad)entidad;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

        //Valida los datos del objeto de negocio
        public override string validar(CapaNegocioBase.EntidadBase negEntidad, ModoEdicion edicion)
        {
            string resultado = "";

            try
            {
                resultado = base.validar(negEntidad, edicion);

                CapaNegocio.Especialidad objeto = (CapaNegocio.Especialidad)negEntidad;


                //Verifica que no exista otro club similar.
                //if (yaExisteSimilar(objeto))
                    //resultado += "\r\nYa existe una Especialidad similar.";
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }


        //Verifica la existencia de otra Especialidad similar
        public bool yaExisteSimilar(CapaNegocio.Especialidad objeto)
        {
            bool resultado = false;

            try
            {
                crearDatEntidadFac();

                CapaDatos.Especialidad dat = (CapaDatos.Especialidad)objeto.convertirEnObjetoDatos();
                resultado = ((CapaDatos.EspecialidadFactory)datEntidadFac).yaExisteSimilar(dat);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }

    }
}