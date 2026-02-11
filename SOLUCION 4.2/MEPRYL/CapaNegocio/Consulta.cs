using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using CapaDatosBase;
using Comunes;

namespace CapaNegocio
{
    public class Consulta : CapaNegocioBase.EntidadBase
    {
        public string tipo = "";
        public DateTime fecha = DateTime.Now;
        public int nroOrden = 0;
        public string identificador = "";
        public Paciente paciente;
        public string observaciones = "";


        public Consulta()
        { }

        public Consulta(CapaNegocioBase.EntidadBase entidad)
        {
            this.EntidadNombre = entidad.EntidadNombre;
            this.id = entidad.id;
            this.codigo = entidad.codigo;
        }


        //Devuelve un objeto de la capa de datos
        public override CapaDatosBase.EntidadBase convertirEnObjetoDatos()
        {
            CapaDatos.Consulta datConsulta = new CapaDatos.Consulta(this.EntidadNombre);
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)this;
                object destino = (object)datConsulta;

                Utilidades.copiarAtributos(ref origen, ref destino);
                datConsulta = (CapaDatos.Consulta)destino;

                origen = null;
                destino = null;
                /*************************/

                //Copia el objeto Paciente
                datConsulta.paciente = (CapaDatos.Paciente)(new CapaDatos.PacienteFactory(new Configuracion(), "Paciente")).getById(this.paciente.id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return datConsulta;
        }
    }
}