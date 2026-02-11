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
    public class ConsultaFactory : EntidadFactoryBase
    {
        public Consulta entidad;

        public ConsultaFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                Consulta consulta = (Consulta)entidad;

                SqlParameter[] param = new SqlParameter[9];

                param[0] = new SqlParameter("@id", consulta.id);
                param[1] = new SqlParameter("@codigo", consulta.codigo);
                param[2] = new SqlParameter("@tipo", consulta.tipo);
                param[3] = new SqlParameter("@fecha", consulta.fecha);
                param[4] = new SqlParameter("@nroOrden", consulta.nroOrden);
                param[5] = new SqlParameter("@identificador", consulta.identificador);
                param[6] = new SqlParameter("@pacienteID", consulta.paciente.id);
                param[7] = new SqlParameter("@observaciones", consulta.observaciones);
                param[8] = new SqlParameter("@registroBLOB", consulta.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Consulta_Update", param);

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
            entidad = new Consulta(base.entidad);
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
                    Consulta datConsulta = (Consulta)resultado.objeto;
                    resultado = modificar(datConsulta);
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
            Consulta consulta = new Consulta(base.leerRegistro(dr));
            try
            {
                consulta.tipo = dr["tipo"].ToString();
                consulta.fecha = DateTime.Parse(dr["fecha"].ToString());
                consulta.nroOrden = int.Parse(dr["nroOrden"].ToString());
                consulta.identificador = dr["identificador"].ToString();
                consulta.paciente = (Paciente)(new PacienteFactory(this.configuracion, "Paciente")).getById(new Guid(dr["pacienteID"].ToString()));
                consulta.observaciones = dr["observaciones"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return consulta;
        }

        public bool existeSimilar(string filtro)
        {
            bool resultado = false;

            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@filtro", filtro);

                SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_Consulta_SelectFiltro", param);

                resultado = dr.HasRows;

                dr.Close();
                dr = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }

            return resultado;
        }
    }
}
