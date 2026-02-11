using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class Club : CapaNegocioBase.EntidadBase
    {
        public string descripcion = "";
        public Guid ligaID = new Guid(Utilidades.ID_VACIO);
        public string observaciones = "";

        public Club()
        { }

        public Club(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.Club datClub = new CapaDatos.Club(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datClub;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datClub = (CapaDatos.Club)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datClub;
        }
    }
}