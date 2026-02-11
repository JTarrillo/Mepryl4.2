using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class Turno : CapaNegocioBase.EntidadBase
    {
        public DateTime fecha = DateTime.Now;
        public Guid estadoID = new Guid(Utilidades.ID_VACIO);
        public string estadoTexto = "";
        public string especialidadTexto = "";
        public string profesionalTexto = "";
        public string hora = "00:00";
        public string horaReferencia = "00:00";
        public int nroOrden = 0;
        public Guid pacienteID = new Guid(Utilidades.ID_VACIO);
        public Guid horarioID = new Guid(Utilidades.ID_VACIO);
        public string observaciones = "";
        public string pacienteTexto = "";
        public string pacienteTelefonos = "";
        public string pacienteCelular = "";
        public string pacienteDni = "";

        public bool domingo = false;
        public bool lunes = false;
        public bool martes = false;
        public bool miercoles = false;
        public bool jueves = false;
        public bool viernes = false;
        public bool sabado = false;


        public Guid usuarioID = new Guid(Utilidades.ID_VACIO);
        public string usuarioTexto = "";

        public Turno()
        { }

        public Turno(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.Turno datTurno = new CapaDatos.Turno(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datTurno;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datTurno = (CapaDatos.Turno)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datTurno;
        }
    }
}