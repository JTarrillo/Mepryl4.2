using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class ConsultaFactory : EntidadFactoryBase
    {
        public ConsultaFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.ConsultaFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.Consulta();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.Consulta negConsulta = new CapaNegocio.Consulta();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negConsulta;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negConsulta = (CapaNegocio.Consulta)destino;

                origen = null;
                destino = null;
                /*************************/

                //Obtiene el objeto Paciente y lo asigna a la propiedad
                CapaDatos.Consulta datConsulta = (CapaDatos.Consulta)datEntidad;
                negConsulta.paciente = (Paciente)(new PacienteFactory(this.configuracion, "Paciente")).getById(datConsulta.paciente.id.ToString());
                datConsulta = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return negConsulta;
        }

        //Da el alta recibiendo todos los datos en un objeto
        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            Resultado resultado = new Resultado();
            try
            {
                crearDatEntidadFac();

                CapaDatos.Consulta datConsulta = (CapaDatos.Consulta)((CapaNegocio.Consulta)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(datConsulta);
                datConsulta = (CapaDatos.Consulta)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(datConsulta);

                resultado.objeto = (CapaNegocio.Consulta)negEntidad;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");

            try
            {
                crearDatEntidadFac();

                CapaDatos.Consulta datConsulta = (CapaDatos.Consulta)((CapaNegocio.Consulta)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(datConsulta);

                datConsulta = (CapaDatos.Consulta)resultado.objeto;
                entidad = convertirEnObjetoNegocio(datConsulta);

                resultado.objeto = (CapaNegocio.Consulta)entidad;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

        //Valida los datos del objeto de negocio
        public override string validar(CapaNegocioBase.EntidadBase negEntidad, ModoEdicion edicion)
        {
            string resultado = "";

            try
            {
                resultado = base.validar(negEntidad, edicion);

             
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }

        public bool existeSimilar(string filtro)
        {
            bool resultado = false;

            try
            {
                crearDatEntidadFac();

                resultado = ((CapaDatos.ConsultaFactory)datEntidadFac).existeSimilar(filtro);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }
    }
}