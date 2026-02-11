using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class Empresa : CapaNegocioBase.EntidadBase
    {
        public string razonSocial = "";
        public string nombreFantasia = "";
        public string cuit = "";
        public Guid ivaID = new Guid(Utilidades.ID_VACIO);
        public Guid localidadID = new Guid(Utilidades.ID_VACIO);
        public string direccion = "";
        public string telefonos = "";
        public string celular = "";
        public string codigoPostal = "";
        public string eMail = "";
        public string contacto = "";
        public bool pagaAbono = false;
        public double importe = 0;
        public DateTime fechaActualizacion = new DateTime(1900, 01, 01);
        public Guid listaPreciosID = new Guid(Utilidades.ID_VACIO);
        public string observaciones = "";

        public Empresa()
        { }

        public Empresa(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.Empresa datEmpresa = new CapaDatos.Empresa(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datEmpresa;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datEmpresa = (CapaDatos.Empresa)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datEmpresa;
        }
    }
}