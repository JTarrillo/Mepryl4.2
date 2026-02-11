using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class Liga : CapaNegocioBase.EntidadBase
    {
        public string descripcion = "";
        
        public Liga()
        { }

        public Liga(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.Liga datLiga = new CapaDatos.Liga(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datLiga;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datLiga = (CapaDatos.Liga)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datLiga;
        }
    }
}