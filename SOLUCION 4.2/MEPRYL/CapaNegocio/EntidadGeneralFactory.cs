using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;
using CapaDatosBase;

namespace CapaNegocio
{
    public class EntidadGeneralFactory : CapaNegocioBase.EntidadFactoryBase
    {
        public EntidadGeneralFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }
        //Viviana
        public EntidadGeneralFactory(Configuracion conf, string entNombre, string idLiga)
            : base(conf, entNombre,idLiga)
        { }

        public override void crearDatEntidadFac()
        {
            datEntidadFac = new CapaDatos.EntidadGeneralFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocioBase.EntidadBase();
        }

        protected override CapaNegocioBase.EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocioBase.EntidadBase negEntidad = new CapaNegocioBase.EntidadBase();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negEntidad;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negEntidad = (CapaNegocioBase.EntidadBase)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return negEntidad;
        }

        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override Resultado modificar(CapaNegocioBase.EntidadBase entidad)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
