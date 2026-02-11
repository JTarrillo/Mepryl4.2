using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class Profesional : CapaNegocioBase.EntidadBase
    {
        public string apellido = "";
        public string nombres = "";
        public string telefonos = "";
        public string observaciones = "";

        public Profesional()
        { }

        public Profesional(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.Profesional datProfesional = new CapaDatos.Profesional(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datProfesional;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datProfesional = (CapaDatos.Profesional)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datProfesional;
        }
    }
}