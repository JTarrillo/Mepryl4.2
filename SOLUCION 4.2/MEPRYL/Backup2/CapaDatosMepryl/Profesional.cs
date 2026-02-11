using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comunes;
using System.Data;

namespace CapaDatosMepryl
{
    public class Profesional
    {
        public Profesional()
        {

        }

        public DataTable cargarProfesionales()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select id, apellido + ' ' + nombres as Médico, especialidad
            as Especialidad, telefono as Teléfono, celular as Celular, mail as Mail from dbo.Profesional order by
            apellido,nombres");
        }


        public Entidades.Profesional cargarProfesional(Guid id)
        {
            Entidades.Profesional retorno = new Entidades.Profesional();
            DataTable profesional = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Profesional where id = '" + id.ToString() + "'");
            if (profesional.Rows.Count > 0)
            {
                retorno.Id = new Guid(profesional.Rows[0].ItemArray[0].ToString());
                retorno.Apellido = profesional.Rows[0].ItemArray[2].ToString();
                retorno.Nombre = profesional.Rows[0].ItemArray[3].ToString();
                retorno.Codigo = profesional.Rows[0].ItemArray[1].ToString();
                retorno.Tipo = profesional.Rows[0].ItemArray[4].ToString();
                retorno.LugarMatricula = profesional.Rows[0].ItemArray[5].ToString();
                retorno.NroMatricula = profesional.Rows[0].ItemArray[6].ToString();
                retorno.Especialidad = profesional.Rows[0].ItemArray[7].ToString();
                retorno.EstadoCivil = profesional.Rows[0].ItemArray[8].ToString();
                retorno.TipoDocumento = profesional.Rows[0].ItemArray[9].ToString();
                retorno.NroDocumento = profesional.Rows[0].ItemArray[10].ToString();
                retorno.TipoContribuyente = profesional.Rows[0].ItemArray[11].ToString();
                retorno.Direccion = profesional.Rows[0].ItemArray[12].ToString();
                retorno.CodigoPostal = profesional.Rows[0].ItemArray[13].ToString();
                retorno.Localidad = profesional.Rows[0].ItemArray[14].ToString();
                retorno.Provincia = profesional.Rows[0].ItemArray[15].ToString();
                retorno.Telefono = profesional.Rows[0].ItemArray[16].ToString();
                retorno.Celular = profesional.Rows[0].ItemArray[17].ToString();
                retorno.Mail = profesional.Rows[0].ItemArray[18].ToString();
                retorno.VisitasCapital = cargarDatoBool(profesional.Rows[0].ItemArray[19]);
                retorno.VisitasProvincia = cargarDatoBool(profesional.Rows[0].ItemArray[20]);
            }
            return retorno;
        }

        private bool cargarDatoBool(object objeto)
        {
            if (objeto.ToString().Length > 0)
            {
                return (bool)objeto;
            }
            return false;
        }

        public Entidades.Resultado nuevoProfesional(Entidades.Profesional profesional)
        {
            Entidades.Resultado resultado = new Entidades.Resultado();
            try
            {
                List<string> listAdd = SQLConnector.generarListaParaProcedure("@tipo","@apellido","@nombre",
                    "@lugarMatricula","@nroMatricula","@especialidad","@estadoCivil","@tipoDocumento",
                    "@nroDocumento","@tipoContribuyente","@direccion","@codigoPostal","@localidad",
                    "@provincia","@telefono","@celular","@mail","@visitasCapital","@visitasProvincia");
                SQLConnector.executeProcedure("sp_Profesional_Insert", listAdd, profesional.Tipo, profesional.Apellido,
                    profesional.Nombre, profesional.LugarMatricula, profesional.NroMatricula, profesional.Especialidad,
                    profesional.EstadoCivil, profesional.TipoDocumento, profesional.NroDocumento, profesional.TipoContribuyente,
                    profesional.Direccion, profesional.CodigoPostal, profesional.Localidad, profesional.Provincia,
                    profesional.Telefono, profesional.Celular, profesional.Mail, convertirInt(profesional.VisitasCapital),
                    convertirInt(profesional.VisitasProvincia));
                resultado.Modo = 1;
                return resultado;
            }
            catch(Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = ex.ToString();
                return resultado;
            }
        }

        public Entidades.Resultado editarProfesional(Entidades.Profesional profesional)
        {
            Entidades.Resultado resultado = new Entidades.Resultado();
            try
            {
                List<string> listUpdate = SQLConnector.generarListaParaProcedure("@id","@tipo", "@apellido", "@nombre",
                    "@lugarMatricula", "@nroMatricula", "@especialidad", "@estadoCivil", "@tipoDocumento",
                    "@nroDocumento", "@tipoContribuyente", "@direccion", "@codigoPostal", "@localidad",
                    "@provincia", "@telefono", "@celular", "@mail", "@visitasCapital", "@visitasProvincia");
                SQLConnector.executeProcedure("sp_Profesional_Update", listUpdate, profesional.Id, profesional.Tipo, profesional.Apellido,
                    profesional.Nombre, profesional.LugarMatricula, profesional.NroMatricula, profesional.Especialidad,
                    profesional.EstadoCivil, profesional.TipoDocumento, profesional.NroDocumento, profesional.TipoContribuyente,
                    profesional.Direccion, profesional.CodigoPostal, profesional.Localidad, profesional.Provincia,
                    profesional.Telefono, profesional.Celular, profesional.Mail, convertirInt(profesional.VisitasCapital),
                    convertirInt(profesional.VisitasProvincia));
                resultado.Modo = 1;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = ex.ToString();
                return resultado;
            }
        }

        private int convertirInt(bool valor)
        {
            if (valor) { return 1; }
            return 0;
        }

        public Entidades.Resultado eliminarProfesional(object id)
        {
            Entidades.Resultado resultado = new Entidades.Resultado();
            try
            {
                List<string> listDelete = SQLConnector.generarListaParaProcedure("@id");
                SQLConnector.executeProcedure("sp_Profesional_Delete", listDelete, new Guid(id.ToString()));
                resultado.Modo = 1;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Modo = -1;
                resultado.Mensaje = ex.ToString();
                return resultado;
            }
        }
    }
}
