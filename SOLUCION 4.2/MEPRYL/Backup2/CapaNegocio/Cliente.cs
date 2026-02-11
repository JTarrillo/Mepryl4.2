using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class Cliente : CapaNegocioBase.PersonaBase
    {
        public Cliente()
        { }

        public Cliente(CapaNegocioBase.PersonaBase persona)
        {
            this.EntidadNombre = persona.EntidadNombre;
            this.apellido = persona.apellido;
            this.codigo = persona.codigo;
            this.codigoPostal = persona.codigoPostal;
            this.direccion = persona.direccion;
            this.dni = persona.dni;
            this.eMail = persona.eMail;
            this.fechaNacimiento = persona.fechaNacimiento;
            this.id = persona.id;
            this.localidadDesc = persona.localidadDesc;
            this.localidadID = persona.localidadID;
            this.nombres = persona.nombres;
            this.observaciones = persona.observaciones;
            this.paginaWeb = persona.paginaWeb;
            this.provinciaDesc = persona.provinciaDesc;
            this.provinciaID = persona.provinciaID;
            this.telefonos = persona.telefonos;
            this.ubicacionGuia = persona.ubicacionGuia;
        }


        //Devuelve un objeto de la capa de datos
        public CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.Cliente datCliente = new CapaDatos.Cliente(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datCliente;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datCliente = (CapaDatos.Cliente)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datCliente;
        }

    }

}
