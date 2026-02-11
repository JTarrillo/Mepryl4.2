using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class ParametrosPlacas : CapaNegocioBase.EntidadBase
    {
        public string categoriaInicial = "";
        public string novenaCategoria = "";
        public string ligasIDs = "";
        public DateTime ultimoPeriodoDesde;
        public DateTime ultimoPeriodoHasta;
        
        public ParametrosPlacas()
        { }

        public ParametrosPlacas(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.ParametrosPlacas datParametrosPlacas = new CapaDatos.ParametrosPlacas(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datParametrosPlacas;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datParametrosPlacas = (CapaDatos.ParametrosPlacas)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datParametrosPlacas;
        }
    }
}