using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class ProfesionalFactory : EntidadFactoryBase
    {
        public ProfesionalFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.ProfesionalFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.Profesional();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.Profesional negProfesional = new CapaNegocio.Profesional();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negProfesional;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negProfesional = (CapaNegocio.Profesional)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return negProfesional;
        }

        //Da el alta recibiendo todos los datos en un objeto
        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            Resultado resultado = new Resultado();
            try
            {
                crearDatEntidadFac();

                CapaDatos.Profesional datProfesional = (CapaDatos.Profesional)((CapaNegocio.Profesional)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(datProfesional);
                datProfesional = (CapaDatos.Profesional)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(datProfesional);

                resultado.objeto = (CapaNegocio.Profesional)negEntidad;
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

                CapaDatos.Profesional datProfesional = (CapaDatos.Profesional)((CapaNegocio.Profesional)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(datProfesional);

                datProfesional = (CapaDatos.Profesional)resultado.objeto;
                entidad = convertirEnObjetoNegocio(datProfesional);

                resultado.objeto = (CapaNegocio.Profesional)entidad;
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