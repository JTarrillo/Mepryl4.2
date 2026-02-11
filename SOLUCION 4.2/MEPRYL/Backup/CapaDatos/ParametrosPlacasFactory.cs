using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class ParametrosPlacasFactory : EntidadFactoryBase
    {
        public ParametrosPlacas entidad;

        public ParametrosPlacasFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                ParametrosPlacas parametrosPlacas = (ParametrosPlacas)entidad;

                SqlParameter[] param = new SqlParameter[7];

                param[0] = new SqlParameter("@id", parametrosPlacas.id);
                param[1] = new SqlParameter("@codigo", parametrosPlacas.codigo);
                param[2] = new SqlParameter("@categoriaInicial", parametrosPlacas.categoriaInicial);
                param[3] = new SqlParameter("@novenaCategoria", parametrosPlacas.novenaCategoria);
                param[4] = new SqlParameter("@ligasIDs", parametrosPlacas.ligasIDs);
                param[5] = new SqlParameter("@ultimoPeriodoDesde", parametrosPlacas.ultimoPeriodoDesde);
                param[6] = new SqlParameter("@ultimoPeriodoHasta", parametrosPlacas.ultimoPeriodoHasta);

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_ParametrosPlacas_Update", param);

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }

            return resultado;
        }

        //Implementacion
        public override void inicializarEntidad()
        {
            base.inicializarEntidad();
            entidad = new ParametrosPlacas(base.entidad);
        }

        public override Resultado alta(EntidadBase ent)
        {
            Resultado resultado = new Resultado();
            try
            {
                //Da el alta del registro vacío para obtener el ID
                resultado = altaID(ent);

                //Modifica el registro nuevo con los datos completos del alta
                if (resultado.mensaje == "")
                {
                    ParametrosPlacas datParametrosPlacas = (ParametrosPlacas)resultado.objeto;
                    resultado = modificar(datParametrosPlacas);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

        //Lee el registro obtenido de la base de datos, cada implementación agrega los campos espefícicos.
        protected override EntidadBase leerRegistro(SqlDataReader dr)
        {
            ParametrosPlacas parametrosPlacas = new ParametrosPlacas(base.leerRegistro(dr));
            try
            {
                parametrosPlacas.codigo = dr["codigo"].ToString();
                parametrosPlacas.categoriaInicial = dr["categoriaInicial"].ToString();
                parametrosPlacas.novenaCategoria = dr["novenaCategoria"].ToString();
                parametrosPlacas.ligasIDs = dr["ligasIDs"].ToString();
                parametrosPlacas.ultimoPeriodoDesde = DateTime.Parse(dr["ultimoPeriodoDesde"].ToString());
                parametrosPlacas.ultimoPeriodoHasta = DateTime.Parse(dr["ultimoPeriodoHasta"].ToString());
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return parametrosPlacas;
        }
    }
}
