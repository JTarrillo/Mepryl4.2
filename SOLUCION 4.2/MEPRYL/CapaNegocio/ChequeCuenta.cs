using System;
using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class ChequeCuenta : CapaNegocioBase.EntidadBase
    {
        public string descripcion = "";
        public Guid clienteID = new Guid(Utilidades.ID_VACIO);
        public Guid bancoID = new Guid(Utilidades.ID_VACIO);
        public Guid bancoSucursalID = new Guid(Utilidades.ID_VACIO);
        
        public ChequeCuenta()
        { }

        public ChequeCuenta(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.ChequeCuenta datCuenta = new CapaDatos.ChequeCuenta(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datCuenta;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datCuenta = (CapaDatos.ChequeCuenta)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datCuenta;
        }
    }
}