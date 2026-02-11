using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using Comunes;

namespace CapaDatosMepryl
{
    public class PacienteLaboral
    {
        public DataTable cargarDataGridBusqueda(string tipoBusqueda, string filtro, string idEmpresa)
        {
            if (tipoBusqueda == "E")
            {
                return cargarEmpresas(filtro);
            }
            return cargarEmpleados(filtro, idEmpresa);
        }

        public DataTable cargarEmpresas(string filtro)
        {
            if (filtro.Length == 0)
            {
                return SQLConnector.obtenerTablaSegunConsultaString(@"select id, cuit, razonSocial from dbo.Empresa
                order by razonSocial");
            }
            return SQLConnector.obtenerTablaSegunConsultaString(@"select id, cuit, razonSocial from dbo.Empresa where "
            + nombreFiltroEmpresa(filtro) + " like '%" + filtro + "%' order by razonSocial");
        }

        private string nombreFiltroEmpresa(string filtro)
        {
            if (filtro.Where(x => Char.IsDigit(x)).Any())
            {
                return "cuit";
            }
            return "razonSocial";
        }

        private DataTable cargarEmpleados(string filtro, string idEmpresa)
        {
            if (filtro.Length == 0)
            {
                return SQLConnector.obtenerTablaSegunConsultaString(@"select pl.id, pl.dni, (pl.apellido + ' ' + pl.nombres) as Paciente 
                from dbo.EmpresasPorPaciente ep inner join dbo.PacienteLaboral pl
                on ep.idPaciente = pl.id where ep.idEmpresa = '" + idEmpresa + "' order by pl.apellido, pl.nombres");
            }
            return SQLConnector.obtenerTablaSegunConsultaString(@"select pl.id, pl.dni, (pl.apellido + ' ' + pl.nombres) as Paciente 
                from dbo.EmpresasPorPaciente ep inner join dbo.PacienteLaboral pl
                on ep.idPaciente = pl.id where "
               + nombreFiltroEmpleado(filtro) + " like '%" + filtro + "%' and ep.idEmpresa = '" + idEmpresa + "' order by pl.apellido, pl.nombres");
        }

        private string nombreFiltroEmpleado(string filtro)
        {
            if (filtro.Where(x => Char.IsDigit(x)).Any())
            {
                return "pl.dni";
            }
            return "(pl.apellido + ' ' + pl.nombres)";
        }

        public DataTable cargarDataGridLocalidad(string filtro)
        {
            if (filtro.Length == 0)
            {
                return SQLConnector.obtenerTablaSegunConsultaString(@"select id as Id, pres as Localidad from dbo.Prestaciones
                where tiPres = 'V' and codPres <> 0
                order by codPres");
            }
            return SQLConnector.obtenerTablaSegunConsultaString(@"select id as Id, pres as Localidad from dbo.Prestaciones
                where tiPres = 'V' and codPres <> 0 and pres like '%" + filtro + @"%'
                order by codPres");
        }

        public Entidades.PacienteLaboral leerDatosEntidad(string idPaciente, string idEmpresa)
        {
            Entidades.PacienteLaboral paciente = new Entidades.PacienteLaboral();
            DataTable tabla = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.PacienteLaboral where id = '" + idPaciente + "'");
            DataTable tablaTarea = SQLConnector.obtenerTablaSegunConsultaString(@"select epp.tarea, e.razonSocial, epp.ingreso from dbo.EmpresasPorPaciente epp
            inner join dbo.Empresa e on epp.idEmpresa = e.id where epp.idPaciente = '" + idPaciente +
                "' and epp.idEmpresa = '" + idEmpresa + "'");
            if (tablaTarea.Rows.Count > 0)
            {
                paciente.Tarea = tablaTarea.Rows[0].ItemArray[0].ToString();
                paciente.Empresa = tablaTarea.Rows[0].ItemArray[1].ToString();
                if (tablaTarea.Rows[0].ItemArray[2].ToString() != string.Empty) { paciente.Ingreso = Convert.ToDateTime(tablaTarea.Rows[0].ItemArray[2].ToString()); }
            }

            if (tabla.Rows.Count > 0)
            {
                paciente.Id = new Guid(tabla.Rows[0].ItemArray[0].ToString());
                paciente.Apellido = tabla.Rows[0].ItemArray[1].ToString();
                paciente.Nombre = tabla.Rows[0].ItemArray[2].ToString();
                paciente.Dni = tabla.Rows[0].ItemArray[3].ToString();
                if (tabla.Rows[0].ItemArray[4].ToString() != string.Empty) { paciente.Nacimiento = Convert.ToDateTime(tabla.Rows[0].ItemArray[4].ToString()); }
                paciente.TelefonoParticular = tabla.Rows[0].ItemArray[5].ToString();
                paciente.TelefonoCelular = tabla.Rows[0].ItemArray[6].ToString();
                paciente.Direccion = tabla.Rows[0].ItemArray[7].ToString();
                if (tabla.Rows[0].ItemArray[8].ToString() != string.Empty) { paciente.IdLocalidad = new Guid(tabla.Rows[0].ItemArray[8].ToString()); }
                if (tabla.Rows[0].ItemArray[9].ToString() != string.Empty) { paciente.Nacionalidad = new Guid(tabla.Rows[0].ItemArray[9].ToString()); }
                paciente.Sexo = tabla.Rows[0].ItemArray[10].ToString();
                paciente.EntreCalle1 = tabla.Rows[0].ItemArray[11].ToString();
                paciente.EntreCalle2 = tabla.Rows[0].ItemArray[12].ToString();
                paciente.Mail = tabla.Rows[0].ItemArray[14].ToString();
                paciente.HistoriaClinica = cargarHistoriaClinica(idPaciente, idEmpresa);

                if (paciente.IdLocalidad != Guid.Empty)
                {
                    DataTable localidad = SQLConnector.obtenerTablaSegunConsultaString(@"select pres from dbo.Prestaciones
                    where id = '" + paciente.IdLocalidad.ToString() + "'");
                    paciente.LocalidadTexto = localidad.Rows[0].ItemArray[0].ToString();
                }

            }
            return paciente;
        }

        private DataTable cargarHistoriaClinica(string idPaciente,string idEmpresa)
        {
            HistoriaClinica historiaClinica = new HistoriaClinica();
            return historiaClinica.cargarHistoriaClinicaLaboral(idPaciente, idEmpresa);
        }

        public DataTable cargarHistoriaClinicaReporte(string idPaciente, string idEmpresa,
            string fechaDesde, string fechaHasta)
        {
            HistoriaClinica historiaClinica = new HistoriaClinica();
            return historiaClinica.cargarHistoriaClinicaReporte(idPaciente, idEmpresa,
                fechaDesde, fechaHasta);
        }

        public DataTable cargarNacionalidades()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.Nacionalidad
            order by descripcion");
        }

        public Entidades.Resultado guardarDatosEntidadEdicion(Entidades.PacienteLaboral paciente)
        {
            Entidades.Resultado result = new Entidades.Resultado();
            try
            {
                // GRV - Ramírez - Para poder modificar el DNI
                // DataTable idPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select id from dbo.PacienteLaboral
                // where dni = '" + paciente.Dni + "'");
                DataTable idPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select id from dbo.PacienteLaboral
                where dni = '" + paciente.DniAnterior + "'");

                if (idPaciente.Rows[0][0].ToString() != paciente.Id.ToString())
                {
                    result.Modo = 3;
                    result.Mensaje = idPaciente.Rows[0][0].ToString();
                    return result;
                }

                List<string> listUpdatePaciente = SQLConnector.generarListaParaProcedure(
                "@id","@apellido","@nombre","@dni","@fechaNacimiento","@telefono","@celular","@direccion",
                "@localidad","@nacionalidad","@sexo","@entreCalle1","@entreCalle2","@cuil","@mail");
                SQLConnector.executeProcedure("sp_PacienteLaboral_Update", listUpdatePaciente,
                Utilidades.guardarGuid(paciente.Id), Utilidades.guardarString(paciente.Apellido),
                Utilidades.guardarString(paciente.Nombre), Utilidades.guardarString(paciente.Dni),
                Utilidades.guardarFecha(paciente.Nacimiento), Utilidades.guardarString(paciente.TelefonoParticular),
                Utilidades.guardarString(paciente.TelefonoCelular), Utilidades.guardarString(paciente.Direccion),
                Utilidades.guardarGuid(paciente.IdLocalidad), Utilidades.guardarGuid(paciente.Nacionalidad),
                Utilidades.guardarString(paciente.Sexo), Utilidades.guardarString(paciente.EntreCalle1),
                Utilidades.guardarString(paciente.EntreCalle2), Utilidades.guardarString(paciente.Cuil),
                Utilidades.guardarString(paciente.Mail));

                DataTable empresaPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.EmpresasPorPaciente
                where idPaciente = '" + paciente.Id.ToString() + "' and idEmpresa = '" + paciente.IdEmpresa + "'");
                if (empresaPaciente.Rows.Count == 0)
                {
                    List<string> listAddEmpresaPaciente = SQLConnector.generarListaParaProcedure("@idPaciente", "@idEmpresa");
                    SQLConnector.executeProcedure("sp_EmpresasPorPaciente_Add", listAddEmpresaPaciente,
                        paciente.Id, paciente.IdEmpresa);
                }

                List<string> listUpdateTarea = SQLConnector.generarListaParaProcedure("@idPaciente", "@idEmpresa", "@tarea");
                SQLConnector.executeProcedure("sp_EmpresasPorPaciente_UpdateTarea", listUpdateTarea,
                    paciente.Id, paciente.IdEmpresa, Utilidades.guardarString(paciente.Tarea));
                List<string> listUpdateFechaIngreso = SQLConnector.generarListaParaProcedure("@idPaciente", "@idEmpresa", "@ingreso");
                SQLConnector.executeProcedure("sp_EmpresasPorPaciente_UpdateIngreso", listUpdateFechaIngreso,
                    paciente.Id, paciente.IdEmpresa, Utilidades.guardarFecha(paciente.Ingreso));
                result.Modo = 1;
                return result;
            }
            catch (Exception ex)
            {
                result.Modo = 2;
                result.Mensaje = ex.ToString();
                return result;
            }
        }

        public Entidades.Resultado verificarDNIIngresadoEnEmpresa(string dni, string idEmpresa)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            DataTable paciente = SQLConnector.obtenerTablaSegunConsultaString("select id from dbo.PacienteLaboral where dni = '" + dni + "'");
            if (paciente.Rows.Count > 0)
            {
                string strPaciente = paciente.Rows[0][0].ToString();
                DataTable empresa = SQLConnector.obtenerTablaSegunConsultaString(@"select ep.*, e.razonSocial from dbo.EmpresasPorPaciente ep
                inner join dbo.Empresa e on ep.idEmpresa = e.id
                where ep.idPaciente = '" + strPaciente + "'");

                string mensajeRetorno = "";

                try
                {
                    if (empresa.Rows.Count > 0)
                    {
                        DataRow[] dr = empresa.Select("idEmpresa = '" + idEmpresa + "'");
                        if (dr.Length > 0)
                        {
                            retorno.Modo = 2;
                            return retorno;
                        }
                        
                        foreach (DataRow r in empresa.Rows)
                        {
                            mensajeRetorno = mensajeRetorno + "" + r.ItemArray[5].ToString();
                            mensajeRetorno = mensajeRetorno + " con fecha de ingreso " + Convert.ToDateTime(r.ItemArray[4].ToString()).ToShortDateString();
                        }
                        retorno.Modo = 3;
                        retorno.Mensaje = mensajeRetorno;
                        return retorno;
                    }
                }
                catch (System.FormatException ex)
                {
                    retorno.Modo = 3;
                    retorno.Mensaje = mensajeRetorno + ". No se registro fecha ingreso.";
                    return retorno;
                }
            }
            retorno.Modo = 1;
            return retorno;
        }

        public string obtenerIdPaciente(string dni)
        {
            return SQLConnector.obtenerTablaSegunConsultaString("select id from dbo.PacienteLaboral where dni = '" + dni + "'").Rows[0][0].ToString();
        }

        // GRV - Ramírez - Obtener el ID de empresa a la que pertenece un paciente
        public string obtenerIdEmpresaPaciente(string strIDpaciente)
        {
            string strIDEmpresa = "";
            DataTable dtValores;

            dtValores = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT top 1 idEmpresa from EmpresasPorPaciente WHERE idPaciente = '" + strIDpaciente + "' ORDER BY ingreso DESC");
            if (dtValores.Rows.Count > 0)
            {
                strIDEmpresa = dtValores.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                strIDEmpresa = "";
            }

            return strIDEmpresa;
        }

        public string cargarIdConsultorioLaboral(string idTipoExamen)
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select idConsultorioLaboral from dbo.ConsultaLaboral
            where idTipoExamen = '" + idTipoExamen + "'").Rows[0][0].ToString();
        }

        public string cargarIdConsultaLaboral(string idTipoExamen)
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select id from dbo.ConsultaLaboral
            where idTipoExamen = '" + idTipoExamen + "'").Rows[0][0].ToString();
        }

        public string cargarIdExamenLaboral(string idTipoExamen)
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select idExamenLaboral from dbo.ConsultaLaboral
            where idTipoExamen = '" + idTipoExamen + "'").Rows[0][0].ToString();
        }

        public Entidades.Resultado guardarDatosEntidadNueva(Entidades.PacienteLaboral paciente)
        {
            Entidades.Resultado result = new Entidades.Resultado();
            try
            {
                DataTable idPaciente = SQLConnector.obtenerTablaSegunConsultaString(@"select id from dbo.PacienteLaboral
                where dni = '" + paciente.Dni + "'");
                if (idPaciente.Rows.Count > 0)
                {
                    result.Modo = 3;
                    return result;
                }

                List<string> listInsertPaciente = SQLConnector.generarListaParaProcedure(
                "@apellido", "@nombre", "@dni", "@fechaNacimiento", "@telefono", "@celular", "@direccion",
                "@localidad", "@nacionalidad", "@sexo", "@entreCalle1", "@entreCalle2", "@cuil", "@mail");
                string idRetorno = SQLConnector.executeProcedureWithReturnValue("sp_PacienteLaboral_Insert", listInsertPaciente,
                Utilidades.guardarString(paciente.Apellido),
                Utilidades.guardarString(paciente.Nombre), Utilidades.guardarString(paciente.Dni),
                Utilidades.guardarFecha(paciente.Nacimiento), Utilidades.guardarString(paciente.TelefonoParticular),
                Utilidades.guardarString(paciente.TelefonoCelular), Utilidades.guardarString(paciente.Direccion),
                Utilidades.guardarGuid(paciente.IdLocalidad), Utilidades.guardarGuid(paciente.Nacionalidad),
                Utilidades.guardarString(paciente.Sexo), Utilidades.guardarString(paciente.EntreCalle1),
                Utilidades.guardarString(paciente.EntreCalle2), Utilidades.guardarString(paciente.Cuil),
                Utilidades.guardarString(paciente.Mail));

                List<string> listAddEmpresaPaciente = SQLConnector.generarListaParaProcedure("@idPaciente", "@idEmpresa", "@tarea");
                SQLConnector.executeProcedure("sp_EmpresasPorPaciente_AddConTarea", listAddEmpresaPaciente,
                    new Guid(idRetorno), paciente.IdEmpresa, Utilidades.guardarString(paciente.Tarea));
                List<string> listUpdateFechaIngreso = SQLConnector.generarListaParaProcedure("@idPaciente", "@idEmpresa", "@ingreso");
                SQLConnector.executeProcedure("sp_EmpresasPorPaciente_UpdateIngreso", listUpdateFechaIngreso,
                    //paciente.Id, paciente.IdEmpresa, Utilidades.guardarFecha(paciente.Ingreso));
                    new Guid(idRetorno), paciente.IdEmpresa, Utilidades.guardarFecha(paciente.Ingreso));
                result.Modo = 1;
                result.Mensaje = idRetorno;
                return result;
            }
            catch (Exception ex)
            {
                result.Modo = 2;
                result.Mensaje = ex.ToString();
                return result;
            }

        }

        public string cargarCuilRazonSocialEmpresa(string idEmpresa)
        {
            DataTable empresa = SQLConnector.obtenerTablaSegunConsultaString(@"select cuit, razonSocial from dbo.Empresa
                where id = '" + idEmpresa + "'");
            if (empresa.Rows.Count > 0)
            {
                return empresa.Rows[0][0].ToString() + " | " + empresa.Rows[0][1].ToString();
            }
            return string.Empty;
        }

        public string obtenerDNIPaciente(string idPaciente)
        {            
            string strID = "";
            string strSQL = "";

            strSQL = "SELECT TOP 1 dni FROM dbo.PacienteLaboral P WHERE P.id = '" + idPaciente + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strID = dtConsulta.Rows[0][0].ToString();
            }

            return strID;
        }

        public DataTable BuscarPacienteLaboral(string Clave)
        {
            string strSQL = "";

            strSQL = "select TOP 200 p.id, emp.id, (p.apellido + ' ' + p.nombres) as Paciente, p.dni as DNI, emp.razonSocial as Empresa, Convert(varchar(10),CONVERT(date,p.fechaNacimiento,106),103) as Nacimiento, " +
                     "epp.tarea as Tarea " +
					 "from dbo.PacienteLaboral p " +
                     "inner join dbo.EmpresasPorPaciente epp on p.id = epp.idPaciente " +
                     "inner join dbo.Empresa emp on epp.idEmpresa = emp.id " +
                     "where p.dni LIKE '%" + Clave + "%' ";
            
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {

                return dtConsulta;
            }

            strSQL = "select TOP 200 p.id, emp.id, (p.apellido + ' ' + p.nombres) as Paciente, p.dni as DNI, emp.razonSocial as Empresa, Convert(varchar(10),CONVERT(date,p.fechaNacimiento,106),103) as Nacimiento, " +
                     "epp.tarea as Tarea " +
                     "from dbo.PacienteLaboral p " +
                     "inner join dbo.EmpresasPorPaciente epp on p.id = epp.idPaciente " +
                     "inner join dbo.Empresa emp on epp.idEmpresa = emp.id " +
                     "where (p.apellido + ' ' + p.nombres) LIKE '%" + Clave + "%' " +
                     "ORDER BY p.apellido";

            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {

                return dtConsulta;
            }

            strSQL = "select TOP 200 p.id, emp.id, (p.apellido + ' ' + p.nombres) as Paciente, p.dni as DNI, emp.razonSocial as Empresa, Convert(varchar(10),CONVERT(date,p.fechaNacimiento,106),103) as Nacimiento, " +
                     "epp.tarea as Tarea " +
                     "from dbo.PacienteLaboral p " +
                     "inner join dbo.EmpresasPorPaciente epp on p.id = epp.idPaciente " +
                     "inner join dbo.Empresa emp on epp.idEmpresa = emp.id " +
                     "where emp.razonSocial LIKE '%" + Clave + "%' " +
                     "ORDER BY p.apellido";

            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                
                return dtConsulta;
            }

            return null;
        }
    }

     
}
