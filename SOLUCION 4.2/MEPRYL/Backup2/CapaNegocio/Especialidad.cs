using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class Especialidad : CapaNegocioBase.EntidadBase
    {
        public string descripcion = "";
        
        public Especialidad()
        { }

        public Especialidad(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
            this.motivoConsulta = entidad.motivoConsulta;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.Especialidad dat = new CapaDatos.Especialidad(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)dat;

                Utilidades.copiarAtributos(ref origen, ref destino);
                dat = (CapaDatos.Especialidad)destino;

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