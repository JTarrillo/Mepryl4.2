using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class LigaFactory : EntidadFactoryBase
    {
        public LigaFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.LigaFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.Liga();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.Liga negLiga = new CapaNegocio.Liga();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negLiga;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negLiga = (CapaNegocio.Liga)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return negLiga;
        }

        //Da el alta recibiendo todos los datos en un objeto
        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            Resultado resultado = new Resultado();
            try
            {
                crearDatEntidadFac();

                CapaDatos.Liga datLiga = (CapaDatos.Liga)((CapaNegocio.Liga)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(datLiga);
                datLiga = (CapaDatos.Liga)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(datLiga);

                resultado.objeto = (CapaNegocio.Liga)negEntidad;
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

                CapaDatos.Liga datLiga = (CapaDatos.Liga)((CapaNegocio.Liga)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(datLiga);

                datLiga = (CapaDatos.Liga)resultado.objeto;
                entidad = convertirEnObjetoNegocio(datLiga);

                resultado.objeto = (CapaNegocio.Liga)entidad;
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
               // resultado = base.validar(negEntidad, edicion);

                CapaNegocio.Liga liga = (CapaNegocio.Liga)negEntidad;


                //Verifica que no exista otro club similar.
               // if (yaExisteLigaSimilar(liga))
                //    resultado += "\r\nYa existe una Liga similar.";
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }


        //Verifica la existencia de otra Liga similar
        public bool yaExisteLigaSimilar(CapaNegocio.Liga liga)
        {
            bool resultado = false;

            try
            {
                crearDatEntidadFac();

                CapaDatos.Liga datLiga = (CapaDatos.Liga)liga.convertirEnObjetoDatos();
               // resultado = ((CapaDatos.LigaFactory)datEntidadFac).yaExisteLigaSimilar(datLiga);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }

    }
}