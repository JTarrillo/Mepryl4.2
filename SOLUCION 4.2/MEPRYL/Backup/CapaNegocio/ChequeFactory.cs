using System;
using System.Collections.Generic;
using System.Text;
using CapaNegocioBase;
using Comunes;

namespace CapaNegocio
{
    public class ChequeFactory : EntidadFactoryBase
    {
        public ChequeFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override void crearDatEntidadFac()
        {
            this.datEntidadFac = new CapaDatos.ChequeFactory(this.configuracion, this.EntidadNombre);
        }

        protected override CapaNegocioBase.EntidadBase crearEntidadNegocio()
        {
            return new CapaNegocio.Cheque();
        }


        protected override EntidadBase convertirEnObjetoNegocio(CapaDatosBase.EntidadBase datEntidad)
        {
            CapaNegocio.Cheque negCheque = new CapaNegocio.Cheque();
            try
            {
                /*************************/
                /* Copia las propiedades */
                object origen = (object)datEntidad;
                object destino = (object)negCheque;

                Utilidades.copiarAtributos(ref origen, ref destino);
                negCheque = (CapaNegocio.Cheque)destino;

                origen = null;
                destino = null;
                /*************************/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return negCheque;
        }

        //Da el alta recibiendo todos los datos en un objeto
        public override Resultado alta(CapaNegocioBase.EntidadBase negEntidad)
        {
            Resultado resultado = new Resultado();
            try
            {
                crearDatEntidadFac();

                CapaDatos.Cheque datCheque = (CapaDatos.Cheque)((CapaNegocio.Cheque)negEntidad).convertirEnObjetoDatos();

                resultado = datEntidadFac.alta(datCheque);
                datCheque = (CapaDatos.Cheque)resultado.objeto;
                negEntidad = convertirEnObjetoNegocio(datCheque);

                resultado.objeto = (CapaNegocio.Cheque)negEntidad;
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

                CapaDatos.Cheque datCheque = (CapaDatos.Cheque)((CapaNegocio.Cheque)entidad).convertirEnObjetoDatos();
                resultado = datEntidadFac.modificar(datCheque);

                datCheque = (CapaDatos.Cheque)resultado.objeto;
                entidad = convertirEnObjetoNegocio(datCheque);

                resultado.objeto = (CapaNegocio.Cheque)entidad;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

        public bool hayChequesRechazados(Guid cuentaID)
        {
            bool resultado = false;
            try
            {
                CapaDatos.ChequeFactory dchf = new CapaDatos.ChequeFactory(this.configuracion, this.EntidadNombre);
                int cantidad = dchf.getAllInDataTable("(cuentaID='" + cuentaID.ToString() + "') AND rechazado=1").Rows.Count;
                if (cantidad > 0)
                    resultado = true;
                dchf = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return resultado;
        }
    }
}