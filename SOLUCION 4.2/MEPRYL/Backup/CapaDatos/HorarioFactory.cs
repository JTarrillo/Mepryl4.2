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
    public class HorarioFactory : EntidadFactoryBase
    {
        public Horario entidad;

        public HorarioFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                Horario horario = (Horario)entidad;

                

                SqlParameter[] param = new SqlParameter[21];

                param[0] = new SqlParameter("@id", horario.id);
                param[1] = new SqlParameter("@codigo", horario.codigo);
                param[2] = new SqlParameter("@profesionalID", horario.profesionalID);
                param[3] = new SqlParameter("@especialidadID", horario.especialidadID);
                param[4] = new SqlParameter("@domingo", horario.domingo);
                param[5] = new SqlParameter("@lunes", horario.lunes);
                param[6] = new SqlParameter("@martes", horario.martes);
                param[7] = new SqlParameter("@miercoles", horario.miercoles);
                param[8] = new SqlParameter("@jueves", horario.jueves);
                param[9] = new SqlParameter("@viernes", horario.viernes);
                param[10] = new SqlParameter("@sabado", horario.sabado);
                param[11] = new SqlParameter("@diasSimplificado", horario.diasSimplificado);
                param[12] = new SqlParameter("@horaDesde", horario.horaDesde);
                param[13] = new SqlParameter("@horaHasta", horario.horaHasta);
                param[14] = new SqlParameter("@cantidadTurnos", horario.cantidadTurnos);
                param[15] = new SqlParameter("@citarCada", horario.citarCada);
                param[16] = new SqlParameter("@pacientesGrupo", horario.pacientesGrupo);
                param[17] = new SqlParameter("@fechaDesde", horario.fechaDesde);
                param[18] = new SqlParameter("@fechaHasta", horario.fechaHasta);
                param[19] = new SqlParameter("@observaciones", horario.observaciones);
                param[20] = new SqlParameter("@registroBLOB", horario.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Horario_Update", param);

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
            entidad = new Horario(base.entidad);
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
                    Horario datHorario = (Horario)resultado.objeto;
                    resultado = modificar(datHorario);
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
            Horario horario = new Horario(base.leerRegistro(dr));
            try
            {
                horario.profesionalID = new Guid(dr["profesionalID"].ToString());
                horario.especialidadID = new Guid(dr["especialidadID"].ToString());
                horario.domingo = bool.Parse(dr["domingo"].ToString());
                horario.lunes = bool.Parse(dr["lunes"].ToString());
                horario.martes = bool.Parse(dr["martes"].ToString());
                horario.miercoles = bool.Parse(dr["miercoles"].ToString());
                horario.jueves = bool.Parse(dr["jueves"].ToString());
                horario.viernes = bool.Parse(dr["viernes"].ToString());
                horario.sabado = bool.Parse(dr["sabado"].ToString());
                horario.diasSimplificado = dr["diasSimplificado"].ToString();
                horario.horaDesde = dr["horaDesde"].ToString();
                horario.horaHasta = dr["horaHasta"].ToString();
                horario.cantidadTurnos = int.Parse(dr["cantidadTurnos"].ToString());
                horario.citarCada = int.Parse(dr["citarCada"].ToString());
                horario.pacientesGrupo = int.Parse(dr["pacientesGrupo"].ToString());
                horario.fechaDesde = DateTime.Parse(dr["fechaDesde"].ToString());
                horario.fechaHasta = DateTime.Parse(dr["fechaHasta"].ToString());
                horario.observaciones = dr["observaciones"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return horario;
        }

        public bool yaExisteHorarioSimilar(CapaDatos.Horario horario)
        {
            bool resultado = false;

            try
            {
                SqlParameter[] param = new SqlParameter[13];
                param[0] = new SqlParameter("@profesionalID", horario.profesionalID);
                param[1] = new SqlParameter("@especialidadID", horario.especialidadID);
                param[2] = new SqlParameter("@domingo", horario.domingo);
                param[3] = new SqlParameter("@lunes", horario.lunes);
                param[4] = new SqlParameter("@martes", horario.martes);
                param[5] = new SqlParameter("@miercoles", horario.miercoles);
                param[6] = new SqlParameter("@jueves", horario.jueves);
                param[7] = new SqlParameter("@viernes", horario.viernes);
                param[8] = new SqlParameter("@sabado", horario.sabado);
                param[9] = new SqlParameter("@horaDesde", horario.horaDesde);
                param[10] = new SqlParameter("@horaHasta", horario.horaHasta);
                param[11] = new SqlParameter("@fechaDesde", horario.fechaDesde);
                param[12] = new SqlParameter("@fechaHasta", horario.fechaHasta);

                SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_Horario_ExisteSimilar", param);

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
