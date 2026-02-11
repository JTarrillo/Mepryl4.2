using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class Cheque : CapaNegocioBase.EntidadBase
    {
        public DateTime vencimiento = DateTime.Now;
        public Guid clienteID = new Guid(Utilidades.ID_VACIO);
        public string clienteTexto = "";
        public Guid bancoID = new Guid(Utilidades.ID_VACIO);
        public string bancoTexto = "";
        public Guid sucursalID = new Guid(Utilidades.ID_VACIO);
        public string sucursalTexto = "";
        public string nroCheque = "";
        public Guid cuentaID = new Guid(Utilidades.ID_VACIO);
        public string cuentaTexto = "";
        public double importe = 0;
        public Guid firmanteID = new Guid(Utilidades.ID_VACIO);
        public string firmanteTexto = "";
        public bool baja = false;
        public Guid proveedorID = new Guid(Utilidades.ID_VACIO);
        public string proveedorTexto = "";
        public DateTime fechaBaja = DateTime.Now;
        public bool rechazado = false;
        public DateTime fechaRechazo = DateTime.Now;
        public string comentariosRechazo = "";

        public Cheque()
        { }

        public Cheque(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.Cheque datCheque = new CapaDatos.Cheque(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datCheque;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datCheque = (CapaDatos.Cheque)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datCheque;
        }
    }
}