using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class ClubFactory : EntidadFactoryBase
    {
        public ClubFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.ClubFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.Club();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.Club negClub = new CapaNegocio.Club();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negClub;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negClub = (CapaNegocio.Club)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return negClub;
        }

        //Da el alta recibiendo todos los datos en un objeto
        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            Resultado resultado = new Resultado();
            try
            {
                crearDatEntidadFac();

                CapaDatos.Club datClub = (CapaDatos.Club)((CapaNegocio.Club)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(datClub);
                datClub = (CapaDatos.Club)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(datClub);

                resultado.objeto = (CapaNegocio.Club)negEntidad;
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

                CapaDatos.Club datClub = (CapaDatos.Club)((CapaNegocio.Club)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(datClub);

                datClub = (CapaDatos.Club)resultado.objeto;
                entidad = convertirEnObjetoNegocio(datClub);

                resultado.objeto = (CapaNegocio.Club)entidad;
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

                CapaNegocio.Club club = (CapaNegocio.Club)negEntidad;

                
                //Verifica que no exista otro club similar.
                if (yaExisteClubSimilar(club))
                    resultado += "\r\nYa existe un Club similar.";
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }


        //Verifica la existencia de otro club similar
        public bool yaExisteClubSimilar(CapaNegocio.Club club)
        {
            bool resultado = false;

            try
            {
                crearDatEntidadFac();

                CapaDatos.Club datClub = (CapaDatos.Club)club.convertirEnObjetoDatos();
                resultado = ((CapaDatos.ClubFactory)datEntidadFac).yaExisteClubSimilar(datClub);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }
        
    }
}