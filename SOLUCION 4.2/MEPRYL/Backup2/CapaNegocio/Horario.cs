using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class Horario : CapaNegocioBase.EntidadBase
    {
        public Guid profesionalID = new Guid(Utilidades.ID_VACIO);
        public string profesionalTexto = "";
        public Guid especialidadID = new Guid(Utilidades.ID_VACIO);
        public string especialidadTexto = "";
        public bool domingo = false;
        public bool lunes = false;
        public bool martes = false;
        public bool miercoles = false;
        public bool jueves = false;
        public bool viernes = false;
        public bool sabado = false;
        public string diasSimplificado = "";
        public string horaDesde = "09:00";
        public string horaHasta = "17:00";
        public int cantidadTurnos = 0;
        public int citarCada = 0;
        public int pacientesGrupo = 0;
        public DateTime fechaDesde = DateTime.Now;
        public DateTime fechaHasta = DateTime.Now;
        public string observaciones = "";

        public Horario()
        { }

        public Horario(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.Horario datHorario = new CapaDatos.Horario(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datHorario;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datHorario = (CapaDatos.Horario)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datHorario;
        }
    }
}