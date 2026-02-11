using System;
using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class ChequeBancoSucursal : CapaNegocioBase.EntidadBase
    {
        public string descripcion = "";
        public Guid bancoID = new Guid(Utilidades.ID_VACIO);
        
        public ChequeBancoSucursal()
        { }

        public ChequeBancoSucursal(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.ChequeBancoSucursal dat = new CapaDatos.ChequeBancoSucursal(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)dat;

                Utilidades.copiarAtributos(ref origen, ref destino);
                dat = (CapaDatos.ChequeBancoSucursal)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return dat;
        }
    }
}