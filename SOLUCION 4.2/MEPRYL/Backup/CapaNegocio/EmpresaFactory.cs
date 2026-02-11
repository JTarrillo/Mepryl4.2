using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class EmpresaFactory : EntidadFactoryBase
    {
        public EmpresaFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.EmpresaFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.Empresa();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.Empresa negEmpresa = new CapaNegocio.Empresa();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negEmpresa;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negEmpresa = (CapaNegocio.Empresa)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return negEmpresa;
        }

        //Da el alta recibiendo todos los datos en un objeto
        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            Resultado resultado = new Resultado();
            try
            {
                crearDatEntidadFac();

                CapaDatos.Empresa datEmpresa = (CapaDatos.Empresa)((CapaNegocio.Empresa)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(datEmpresa);
                datEmpresa = (CapaDatos.Empresa)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(datEmpresa);

                resultado.objeto = (CapaNegocio.Empresa)negEntidad;
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

                CapaDatos.Empresa datEmpresa = (CapaDatos.Empresa)((CapaNegocio.Empresa)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(datEmpresa);

                datEmpresa = (CapaDatos.Empresa)resultado.objeto;
                entidad = convertirEnObjetoNegocio(datEmpresa);

                resultado.objeto = (CapaNegocio.Empresa)entidad;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

    }
}