using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comunes;
using System.Data;
using Entidades;
using System.IO;

namespace CapaDatosMepryl
{
    public class Laboral
    {
        int prueba;
        string test;
        private DataTable validaciones;
        int puntEncabez;
        int puntTxtEncab;
        
        public Laboral()
        {
            // GRV - Modificado
            validaciones = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Validaciones");   
        }

        public DataTable consultasConFiltro(string filtro)
        {
            DataTable tablaLaborales = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id, c.fecha, c.identificador, 
                p.id, p.dni,(p.apellido + ' ' + p.nombres), tep.id, e.descripcion, cl.id, cl.tipo, cl.idExamenLaboral, cl.idConsultorioLaboral, 
                tep.imp, tep.impLab, cons, tep.mail 
                from dbo.Consulta c inner join dbo.PacienteLaboral p on c.pacienteID = p.id
                                inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta
                                inner join dbo.Especialidad e on tep.idEspecialidad = e.id
                                inner join dbo.ConsultaLaboral cl on tep.id = cl.idTipoExamen
                where c.tipo != 'P' and p.dni = '" + filtro + @"' and c.tipo != 'R' 
                order by CONVERT(VARCHAR(10),c.fecha,101), convert(int,REPLACE(REPLACE(REPLACE(REPLACE(c.identificador, 'L', ''),'CO',''),'EC',''),'R',''))");
            return cargarConsultas(tablaLaborales);   
        }

        public DataTable consultasSinFiltro(string desde, string hasta, List<string> listaFiltro)
        {
            DataTable AAgregar = new DataTable();

            // Validar y formatear fechas
            DateTime fechaDesde, fechaHasta;
            if (!DateTime.TryParse(desde, out fechaDesde) || !DateTime.TryParse(hasta, out fechaHasta))
                throw new ArgumentException("Las fechas no tienen un formato válido.");

            string desdeSql = fechaDesde.ToString("yyyy-MM-dd");
            string hastaSql = fechaHasta.ToString("yyyy-MM-dd");

            if (listaFiltro.Count > 0)
            {
                string consulta = "";
                bool primeraVez = true;
                foreach (string s in listaFiltro)
                {
                    if (primeraVez)
                    {
                        consulta = " and c.tipo = '" + s + "'"; primeraVez = false;
                    }
                    else
                    {
                        consulta = consulta + " or c.tipo = '" + s + "'";
                    }
                }

                DataTable tablaLaborales = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id, c.fecha, c.identificador, 
            p.id, p.dni,(p.apellido + ' ' + p.nombres), tep.id, e.descripcion, cl.id, cl.tipo, cl.idExamenLaboral, cl.idConsultorioLaboral,
            tep.imp, tep.impLab, cons, tep.mail 
            from dbo.Consulta c inner join dbo.PacienteLaboral p on c.pacienteID = p.id
                            inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta
                            inner join dbo.Especialidad e on tep.idEspecialidad = e.id
                            inner join dbo.ConsultaLaboral cl on tep.id = cl.idTipoExamen
            where c.tipo != 'P' " + consulta + " and convert(date,c.fecha) >= '" + desdeSql + @"' and convert(date,c.fecha)
            <= '" + hastaSql + "' order by CONVERT(VARCHAR(10),c.fecha,101), convert(int,REPLACE(REPLACE(REPLACE(REPLACE(c.identificador, 'L', ''), 'CO',''), 'EC', ''),'R',''))");

                if (listaFiltro.Contains("L"))
                {
                    AAgregar = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id, c.fecha, c.identificador, 
            p.id, p.dni,(p.apellido + ' ' + p.nombres), tep.id, e.descripcion, tep.imp, tep.impLab, cons, tep.mail 
            from dbo.Consulta c inner join dbo.PacienteLaboral p on c.pacienteID = p.id
                            inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta
                            inner join dbo.Especialidad e on tep.idEspecialidad = e.id
            where c.tipo != 'P' AND c.tipo = 'EC' and convert(date,c.fecha) >= '" + desdeSql + @"' and convert(date,c.fecha)
            <= '" + hastaSql + "' order by CONVERT(VARCHAR(10),c.fecha,101), CONVERT(int,REPLACE(REPLACE(REPLACE(REPLACE(c.identificador, 'L', ''), 'CO',''), 'EC', ''),'R',''))");
                    bool a = false;
                    if (AAgregar.Rows.Count == 0)
                    {
                        AAgregar = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id, c.fecha, c.identificador, 
            p.id, p.dni,(p.apellido + ' ' + p.nombres), tep.id, e.descripcion, tep.imp, tep.impLab, cons, tep.mail 
            from dbo.Consulta c inner join dbo.PacienteLaboral p on c.pacienteID = p.id
                            inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta
                            inner join dbo.Especialidad e on tep.idEspecialidad = e.id
            where c.tipo != 'P' AND c.tipo = 'EC' and convert(date,c.fecha) >= '" + desdeSql + @"' and convert(date,c.fecha)
            <= '" + hastaSql + "' order by CONVERT(VARCHAR(10),c.fecha,101), CONVERT(int,REPLACE(REPLACE(REPLACE(REPLACE(c.identificador, 'L', ''), 'CO',''), 'EC', ''),'R',''))");
                    }
                    foreach (DataRow dr in AAgregar.Rows)
                    {
                        tablaLaborales.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], Guid.Empty.ToString(), 1, Guid.Empty.ToString(), Guid.Empty.ToString(), dr[8], dr[9], dr[10], dr[11]);
                    }
                    AAgregar = SQLConnector.obtenerTablaSegunConsultaString(@"select c.id, c.fecha, c.identificador, 
            p.id, p.dni,(p.apellido + ' ' + p.nombres), tep.id, e.descripcion, cl.id, cl.tipo, cl.idExamenLaboral, cl.idConsultorioLaboral,
            tep.imp, tep.impLab, cons, tep.mail 
            from dbo.Consulta c inner join dbo.PacienteLaboral p on c.pacienteID = p.id
                            inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta
                            inner join dbo.Especialidad e on tep.idEspecialidad = e.id
                            inner join dbo.ConsultaLaboral cl on tep.id = cl.idTipoExamen
            where c.tipo != 'P' AND c.tipo = 'R' and convert(date,c.fecha) >= '" + desdeSql + @"' and convert(date,c.fecha)
            <= '" + hastaSql + "' order by CONVERT(VARCHAR(10),c.fecha,101), CONVERT(int,REPLACE(REPLACE(REPLACE(REPLACE(c.identificador, 'L', ''), 'CO',''), 'EC', ''),'R',''))");
                    foreach (DataRow dr in AAgregar.Rows)
                    {
                        tablaLaborales.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10], dr[11], dr[12], dr[13], dr[14], dr[15]);
                    }
                }
                return cargarConsultas(tablaLaborales);
            }
            return new DataTable();
        }

        private DataTable cargarConsultas(DataTable tablaLaborales)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("IdConsulta");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Hora");
            retorno.Columns.Add("Ident.");
            retorno.Columns.Add("Motivo Consulta");
            retorno.Columns.Add("IdEmpresa");
            retorno.Columns.Add("Empresa");
            retorno.Columns.Add("Tarea");
            retorno.Columns.Add("Paciente");
            retorno.Columns.Add("DNI");
            retorno.Columns.Add("IdPaciente");
            retorno.Columns.Add("IdConsultaLaboral");
            retorno.Columns.Add("TipoConsultaLaboral");
            retorno.Columns.Add("EstadoAtencion");
            retorno.Columns.Add("Diagnostico");
            retorno.Columns.Add("Fecha Alta/Citacion");
            retorno.Columns.Add("Dictamen");
            retorno.Columns.Add("IdExamenLaboral");
            retorno.Columns.Add("IdConsultorioLaboral");
            retorno.Columns.Add("ClinicoCargado");
            retorno.Columns.Add("IdTipoExamen");
            retorno.Columns.Add("ImpClinico");
            retorno.Columns.Add("ImpLaboratorio");
            retorno.Columns.Add("Consolidado");
            retorno.Columns.Add("Enviado");

            foreach (DataRow r in tablaLaborales.Rows)
                {
                    DataTable empresaPorTipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select e.id, e.razonSocial, ete.tarea 
                from dbo.empresaPorTipoDeExamen ete inner join dbo.Empresa e on ete.idEmpresa = e.id
                where ete.idTipoExamen = '" + r.ItemArray[6].ToString() + "'");
                    string idEmp = "";
                    string emp = "";
                    string tarea = "";
                    if (empresaPorTipoExamen.Rows.Count > 0)
                    {
                        idEmp = empresaPorTipoExamen.Rows[0].ItemArray[0].ToString();
                        emp = empresaPorTipoExamen.Rows[0].ItemArray[1].ToString();
                        tarea = empresaPorTipoExamen.Rows[0].ItemArray[2].ToString();

                        if (r.ItemArray[11].ToString() == "")
                        {
                            r.BeginEdit();
                            r[11] = Guid.Empty.ToString();
                            r.AcceptChanges();
                            test = r.ItemArray[11].ToString();
                            test = r.ItemArray[11].ToString();
                            r.EndEdit();
                    }
                        if (Guid.Parse(r.ItemArray[11].ToString()) != Guid.Empty)
                        {
                            //CONSULTORIO
                            DataTable consultorioLaboral = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ConsultorioLaboral
                            where id = '" + r.ItemArray[11].ToString() + "'");
                            string estAtenc = "";
                            if (consultorioLaboral.Rows[0].ItemArray[4].ToString() != string.Empty)
                            {
                                DataTable estadoAtencion = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.EstadoAtencion where id = '" +
                                    consultorioLaboral.Rows[0].ItemArray[4].ToString() + "'");
                                estAtenc = estadoAtencion.Rows[0].ItemArray[2].ToString();
                            }

                            string fechaAltaCitacion = "";
                            if (consultorioLaboral.Rows[0].ItemArray[8].ToString() != string.Empty)
                            {
                                fechaAltaCitacion = ((DateTime)consultorioLaboral.Rows[0].ItemArray[8]).ToShortDateString();
                            }
                            retorno.Rows.Add(r.ItemArray[0], Convert.ToDateTime(r.ItemArray[1]).ToShortDateString(),
                            Convert.ToDateTime(r.ItemArray[1]).ToString("HH:mm"), r.ItemArray[2], r.ItemArray[7].ToString(),
                            idEmp, emp, tarea, r.ItemArray[4], r.ItemArray[5], r.ItemArray[6],
                            r.ItemArray[8], r.ItemArray[9], estAtenc, "", fechaAltaCitacion, "",
                            r.ItemArray[10], r.ItemArray[11], "", r.ItemArray[6], r.ItemArray[12], r.ItemArray[13], r.ItemArray[14]);
                        }
                        else
                        {
                            string dictamen = "";
                            string dictamenClinico = "";
                            DataTable examen = SQLConnector.obtenerTablaSegunConsultaString("select dictamen, dictamenCli from dbo.ExamenLaboral where id = '" + r.ItemArray[10].ToString() + "'");
                            if (examen.Rows.Count > 0)
                            {
                                if (examen.Rows[0].ItemArray[0].ToString() == "") { dictamen = "A DESIGNAR"; }
                                else
                                {
                                    DataTable t0 = SQLConnector.obtenerTablaSegunConsultaString(@"select descripcion from dbo.DictamenesLaboral
                                    where id = '" + examen.Rows[0].ItemArray[0].ToString() + "'");
                                    dictamen = t0.Rows[0].ItemArray[0].ToString();
                                }
                                if (examen.Rows[0].ItemArray[1].ToString() == "") { dictamenClinico = ""; }
                                else
                                {
                                    DataTable t1 = SQLConnector.obtenerTablaSegunConsultaString(@"select descripcion from dbo.DictamenesLaboral
                                    where id = '" + examen.Rows[0].ItemArray[1].ToString() + "'");
                                    if ("A DESIGNAR" != t1.Rows[0].ItemArray[0].ToString())
                                    {
                                        dictamenClinico = examen.Rows[0].ItemArray[1].ToString();
                                    }
                                }
                            }
                            string fechaAltaCitacion = "";
                            retorno.Rows.Add(r.ItemArray[0], Convert.ToDateTime(r.ItemArray[1]).ToShortDateString(),
                            Convert.ToDateTime(r.ItemArray[1]).ToString("HH:mm"), r.ItemArray[2], r.ItemArray[7].ToString(),
                            idEmp, emp, tarea, r.ItemArray[4], r.ItemArray[5], r.ItemArray[6],
                            r.ItemArray[8], r.ItemArray[9], "", "", fechaAltaCitacion, dictamen,
                            r.ItemArray[10], r.ItemArray[11], dictamenClinico, r.ItemArray[6], r.ItemArray[12], r.ItemArray[13], r.ItemArray[14], r.ItemArray[15]);
                        }
                    }


             
            }
            return retorno;
        }

        public DataTable consulta(string consulta)
        { 
            return SQLConnector.obtenerTablaSegunConsultaString(consulta);
        }

        public Entidades.Consultorio cargarConsultorio(string id)
        {
            //GRV - modificado para reservar turno de consulta
//            DataTable consultorio = SQLConnector.obtenerTablaSegunConsultaString(@"select cl.*, c.pacienteID, p.dni,
//            (p.apellido + ' ' + p.nombres) as paciente, e.razonSocial, ete.tarea, c.identificador
//            from ConsultorioLaboral cl inner join dbo.ConsultaLaboral consL on cl.id = consL.idConsultorioLaboral
//            inner join dbo.TipoExamenDePaciente tep on consL.idTipoExamen = tep.id
//            inner join dbo.Consulta c on c.id = tep.idConsulta
//            inner join dbo.empresaPorTipoDeExamen ete on ete.idTipoExamen = tep.id
//            inner join dbo.PacienteLaboral p on c.pacienteID = p.id
//            inner join dbo.Empresa e on ete.idEmpresa = e.id
//            where cl.id = '" + id + "'");

            DataTable consultorio = SQLConnector.obtenerTablaSegunConsultaString(@"select cl.*, c.pacienteID, p.dni,
            (p.apellido + ' ' + p.nombres) as paciente, e.razonSocial, ete.tarea, c.identificador, e.id
            from ConsultorioLaboral cl 
            inner join dbo.ConsultaLaboral consL on cl.id = consL.idConsultorioLaboral
            inner join dbo.TipoExamenDePaciente tep on consL.idTipoExamen = tep.id
            inner join dbo.Consulta c on c.id = tep.idConsulta
            inner join dbo.empresaPorTipoDeExamen ete on ete.idTipoExamen = tep.id
            inner join dbo.PacienteLaboral p on c.pacienteID = p.id
            inner join dbo.Empresa e on ete.idEmpresa = e.id
            where cl.id = '" + id + "'");
            return cargarEntidad(consultorio);
        }

        public DataTable cargarProfesionales()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select id, (codigo + ' - ' + apellido + ' ' + nombres) as descripcion 
            from dbo.Profesional WHERE Activo = 1 order by CONVERT(int,codigo) asc");
        }

        public DataTable cargarDictamenes()
        {
            return SQLConnector.obtenerTablaSegunConsultaString(@"select id, descripcion
            from dbo.DictamenesLaboral order by codigo asc");
        }

        public void updateConsultorio(Entidades.Consultorio entidad)
        {
            List<string> updateConsultorio = SQLConnector.generarListaParaProcedure("@id", "@fechaHora", "@motivo",
               "@estadoAtencion", "@patologia", "@diagnostico", "@condicionLaboral", "@altaCitacion", "@medico", "@factPrest");
            if (entidad.FechaAltaCitacion == string.Empty)
            {
                SQLConnector.executeProcedure("sp_ConsultorioLaboral_Update", updateConsultorio,
               entidad.IdConsultorio, entidad.FechaHora, entidad.IdMotivo, entidad.IdEstadoAtencion, entidad.IdPatologia,
               entidad.Diagnostico, entidad.IdCondicionLaboral, null, entidad.IdMedico, entidad.FacturaPrestacion);
            }
            else
            {
                SQLConnector.executeProcedure("sp_ConsultorioLaboral_Update", updateConsultorio,
               entidad.IdConsultorio, entidad.FechaHora, entidad.IdMotivo, entidad.IdEstadoAtencion, entidad.IdPatologia,
               entidad.Diagnostico, entidad.IdCondicionLaboral, Convert.ToDateTime(entidad.FechaAltaCitacion), entidad.IdMedico, entidad.FacturaPrestacion);
            }
           
           
        }

        public Entidades.Consultorio cargarConsultorio(string fecha, string idPaciente, string comparador, string idEmpresa)
        {
            // GRV - Ramírez - Corregir tipo de datos String a GUID
            string tipoOrden = "desc";
            string empresa = string.Empty;
            //if (idEmpresa != string.Empty) { empresa = " and ete.idEmpresa = '" + idEmpresa + "'"; }
            if (!(string.IsNullOrEmpty(idEmpresa))) { empresa = " and ete.idEmpresa = CONVERT(uniqueidentifier,'" + idEmpresa + "')"; }
            if (comparador == ">") { tipoOrden = "asc"; }
//            DataTable consultorio = SQLConnector.obtenerTablaSegunConsultaString(@"select top(1) cl.*, c.pacienteID, p.dni,
//            (p.apellido + ' ' + p.nombres) as paciente, e.razonSocial, ete.tarea, c.identificador
//            from ConsultorioLaboral cl inner join dbo.ConsultaLaboral consL on cl.id = consL.idConsultorioLaboral
//            inner join dbo.TipoExamenDePaciente tep on consL.idTipoExamen = tep.id
//            inner join dbo.Consulta c on c.id = tep.idConsulta
//            inner join dbo.empresaPorTipoDeExamen ete on ete.idTipoExamen = tep.id
//            inner join dbo.PacienteLaboral p on c.pacienteID = p.id
//            inner join dbo.Empresa e on ete.idEmpresa = e.id
//            where c.pacienteID = '" + idPaciente + "'" + empresa + " and convert(date,c.fecha) " + comparador + " '" + fecha + @"'
//            order by c.fecha " + tipoOrden);

            DataTable consultorio = SQLConnector.obtenerTablaSegunConsultaString(@"select top(1) cl.*, c.pacienteID, p.dni,
            (p.apellido + ' ' + p.nombres) as paciente, e.razonSocial, ete.tarea, c.identificador
            from ConsultorioLaboral cl inner join dbo.ConsultaLaboral consL on cl.id = consL.idConsultorioLaboral
            inner join dbo.TipoExamenDePaciente tep on consL.idTipoExamen = tep.id
            inner join dbo.Consulta c on c.id = tep.idConsulta
            inner join dbo.empresaPorTipoDeExamen ete on ete.idTipoExamen = tep.id
            inner join dbo.PacienteLaboral p on c.pacienteID = p.id
            inner join dbo.Empresa e on ete.idEmpresa = e.id
            where c.pacienteID = CONVERT(uniqueidentifier,'" + idPaciente + "')" + empresa + " and convert(date,c.fecha) " + comparador + " '" + fecha + @"'
            order by c.fecha " + tipoOrden);
            return cargarEntidad(consultorio);            
        }

        private Entidades.Consultorio cargarEntidad(DataTable consultorio)
        {
            Entidades.Consultorio entidad = new Entidades.Consultorio();
            if (consultorio.Rows.Count > 0)
            {
                entidad.IdConsultorio = new Guid(consultorio.Rows[0].ItemArray[0].ToString());
                entidad.FechaHora = (DateTime)(consultorio.Rows[0].ItemArray[1]);
                if (consultorio.Rows[0].ItemArray[2].ToString() != string.Empty)
                {
                    DataTable lugarAtenc = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.LugarAtencion
                where id = '" + consultorio.Rows[0].ItemArray[2].ToString() + "'");
                    entidad.LugarAtencion = lugarAtenc.Rows[0].ItemArray[2].ToString();
                }
                if (consultorio.Rows[0].ItemArray[4].ToString() != string.Empty)
                {
                    entidad.IdEstadoAtencion = new Guid(consultorio.Rows[0].ItemArray[4].ToString());
                }             
                if (consultorio.Rows[0].ItemArray[5].ToString() != string.Empty)
                {
                    entidad.IdPatologia = new Guid(consultorio.Rows[0].ItemArray[5].ToString());
                }
                entidad.Diagnostico = consultorio.Rows[0].ItemArray[6].ToString();
                if (consultorio.Rows[0].ItemArray[7].ToString() != string.Empty)
                {
                    entidad.IdCondicionLaboral = new Guid(consultorio.Rows[0].ItemArray[7].ToString());
                }
                if (consultorio.Rows[0].ItemArray[8].ToString() != string.Empty)
                {
                    entidad.FechaAltaCitacion = consultorio.Rows[0].ItemArray[8].ToString();
                }
                if (consultorio.Rows[0].ItemArray[9].ToString() != string.Empty)
                {
                    entidad.IdMedico = new Guid(consultorio.Rows[0].ItemArray[9].ToString());
                }
                if (consultorio.Rows[0].ItemArray[10].ToString() != string.Empty)
                {
                    entidad.FacturaPrestacion = (int)consultorio.Rows[0].ItemArray[10];
                }
                entidad.IdPaciente = new Guid(consultorio.Rows[0].ItemArray[11].ToString());
                entidad.Paciente = consultorio.Rows[0].ItemArray[13].ToString();
                entidad.Empresa = consultorio.Rows[0].ItemArray[14].ToString();
                entidad.Tarea = consultorio.Rows[0].ItemArray[15].ToString();
                entidad.Identificador = consultorio.Rows[0].ItemArray[16].ToString();
                entidad.Dni = consultorio.Rows[0].ItemArray[12].ToString();
                entidad.IdEmpresa = new Guid(consultorio.Rows[0].ItemArray[17].ToString()); //GRV - Ramírez 
          
            }
            return entidad;
        }

        public DataTable consultarItemsPorTipoExamen(string idConsulta)
        {
            DataTable idTipoEx = this.consulta("select idTipoExamen from dbo.ConsultaLaboral where id = '" + idConsulta + "'");
            return procesarTablaEstudiosPorExamen(SQLConnector.obtenerTablaSegunConsultaString(@"select * 
            from dbo.EstudiosPorExamen epe
            where  epe.idTipoExamen = '" + idTipoEx.Rows[0].ItemArray[0].ToString() + "'"));
        }

        public DataTable consultarItemsPorTipoExamenSegunIdConsulta(string idConsulta)
        {
            DataTable idTipoEx = this.consulta(@"select tep.id from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep on tep.idConsulta = c.id
            where c.id = '" + idConsulta + "'");
            return procesarTablaEstudiosPorExamen(SQLConnector.obtenerTablaSegunConsultaString(@"select * 
            from dbo.EstudiosPorExamen epe
            where  epe.idTipoExamen = '" + idTipoEx.Rows[0].ItemArray[0].ToString() + "'"));
        }

        private DataTable procesarTablaEstudiosPorExamen(DataTable estudiosPorExamen)
        {
            DataTable items = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Items");
            DataTable retorno = new DataTable();
            retorno.Columns.Add("id");
            retorno.Columns.Add("nombreCompleto");
            retorno.Columns.Add("ordenFormulario");
            retorno.Columns.Add("nombreCorto");

            retorno.Columns[0].DataType = System.Type.GetType("System.Int32");
            retorno.Columns[2].DataType = System.Type.GetType("System.Int32");

            int posicionColumna = 0;
            foreach(object dc in estudiosPorExamen.Rows[0].ItemArray)
            {
                if (posicionColumna >= 2 && dc.ToString() == "True")
                {
                    DataRow[] dr = items.Select("codigo = " + (posicionColumna - 1).ToString());
                    if (dr.Length > 0)
                    {
                        retorno.Rows.Add(dr[0][0].ToString(), dr[0][1].ToString(), dr[0][3].ToString()
                            , dr[0][2].ToString());
                    }
                }
                posicionColumna++;
            }
            return retorno;
        }

        public Entidades.Resultado updateExamen(ExamenLaboral examen)
        {
            Entidades.Resultado resul = new Entidades.Resultado();
            try
            {
                List<string> update = SQLConnector.generarListaParaProcedure("@id", "@antCli", "@antQui", "@antTrau", "@talla",
                "@peso", "@entradaAire", "@ruidosAgre", "@ruidosCard", "@silencios", "@taMax", "@taMin", "@pulso", "@abdomen", "@hernias",
                "@varices", "@apGenitour", "@pielYFaneras", "@apLocomotor", "@snc", "@ojoDer", "@ojoDerLent", "@ojoIzq", "@ojoIzqLent",
                "@visionCromatica", "@exOdonto", "@equil", "@observacionesCli", "@medico", "@dictamenCli", "@gRojos", "@gBlancos",
                "@hemoglobina", "@hematocrito", "@eritro", "@plaquetas", "@obsSerieRoja", "@cayado", "@segmentado", "@eosinof", "@basof",
                "@linfoc", "@monoc", "@obsSerieBlanca", "@glucemia", "@uremia", "@chagas", "@vdrl", "@grupo", "@factor", "@uricemia",
                "@te", "@otrosQuimicaHemat", "@colTotal", "@hdl", "@ldl", "@trig", "@otrosPerfilLipidico", "@color", "@aspecto", "@densidad",
                "@ph", "@celulas", "@leuco", "@hematies", "@prot", "@gluc", "@hemogOrina", "@cetonas", "@bilirrubina", "@otrosOrina",
                "@observacionesLab", "@dictamenLab", "@toraxF", "@lumbarF", "@lumbarP", "@cervicalF", "@cervicalP", "@fnp", "@mnp", "@hombrosF",
                "@rodillasF", "@caderasF", "@tobillosF", "@craneoFyP", "@hombroF", "@hombroVP", "@humeroFyP", "@codoFyP", "@antebrazoFyP",
                "@munecaFyP", "@manoFyP", "@toraxP", "@pCostalFyO", "@colDorsalFyP", "@pelvisF", "@caderaF", "@caderaP", "@femurFyP",
                "@rodillaF", "@rodillaP", "@piernaFyP", "@tobilloFyP", "@axialDeCalcaneo", "@pieFyP", "@audio", "@ergo", "@eco", "@psico",
                "@espiro", "@eeg", "@iTorg", "@ecg", "@observaciones", "@dictamen", "@na", "@k", "@protTotal", "@albumina", "@alfa1", "@alfa2", "@beta1", "@beta2", "@gammaglob", 
                "@relacAlbGlob", "@creat");

                SQLConnector.executeProcedure("sp_ExamenLaboral_Update", update, examen.Id, examen.AntCli, examen.AntQui,
                    examen.AntTrau, examen.Talla, examen.Peso, examen.EntradaAire, examen.RuidosAgre, examen.RuidosCard,
                    examen.Silencios, examen.TaMax, examen.TaMin, examen.Pulso, examen.Abdomen, examen.Hernias,
                    examen.Varices, examen.ApGenitour, examen.PielYFaneras, examen.ApLocomotor, examen.Snc, examen.OjoDer,
                    examen.OjoDerLent, examen.OjoIzq, examen.OjoIzqLent, examen.VisionCromatica, examen.ExOdonto,
                    examen.Equil, examen.ObservacionesCli, examen.Medico, examen.DictamenCli, examen.GRojos, examen.GBlancos,
                    examen.Hemoglobina, examen.Hematocrito, examen.Eritro, examen.Plaquetas, examen.ObsSerieRoja, examen.Cayado,
                    examen.Segmentado, examen.Eosinof, examen.Basof, examen.Linfoc, examen.Monoc, examen.ObsSerieBlanca,
                    examen.Glucemia, examen.Uremia, examen.Chagas, examen.Vdrl, examen.Grupo, examen.Factor, examen.Uricemia,
                    examen.Te, examen.OtrosQuimicaHemat, examen.ColTotal, examen.Hdl, examen.Ldl, examen.Triglic, examen.OtrosPerfilLipidico,
                    examen.Color, examen.Aspecto, examen.Densidad, examen.Ph, examen.Celulas, examen.Leuco, examen.Hematies,
                    examen.Prot, examen.Gluc, examen.HemogOrina, examen.Cetonas, examen.Bilirrubina, examen.OtrosOrina,
                    examen.ObservacionesLab, examen.DictamenLab, examen.ToraxF, examen.LumbarF, examen.LumbarP,
                    examen.CervicalF, examen.CervicalP, examen.Fnp, examen.Mnp, examen.HombrosF, examen.RodillasF,
                    examen.CaderasF, examen.TobillosF, examen.CraneoFyP, examen.HombroF, examen.HombroVP, examen.HumeroFyP,
                    examen.CodoFyP, examen.AntebrazoFyP, examen.MunecaFyP, examen.ManoFyP, examen.ToraxP, examen.PCostalFyO,
                    examen.ColDorsalFyP, examen.PelvisF, examen.CaderaF, examen.CaderaP, examen.FemurFyP, examen.RodillaF,
                    examen.RodillaP, examen.PiernaFyP, examen.TobilloFyP, examen.AxialDeCalcaneo, examen.PieFyP,
                    examen.Audio, examen.Ergo, examen.Eco, examen.Psico, examen.Espiro, examen.Eeg, examen.ITorg,
                    examen.Ecg, examen.Observaciones, examen.Dictamen, examen.Na, examen.K, examen.ProtTotales, examen.Albumina,
                    examen.ALFA1, examen.ALFA2, examen.BETA1, examen.BETA2, examen.Gammaglob, examen.RelacAlbGlob, examen.Creat);
                resul.Modo = 1;
                return resul;
            }
            catch (Exception ex)
            {
                resul.Modo = -1;
                resul.Mensaje = ex.ToString();
                return resul;
            }
        }

        public Entidades.ExamenLaboral cargarExamen(string id)
        {
            Entidades.ExamenLaboral retorno = new ExamenLaboral();
            DataTable examen = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.ExamenLaboral where id = '" + id + "'");
            if (examen.Rows.Count > 0)
            {
                retorno.Id = new Guid(examen.Rows[0].ItemArray[0].ToString());
                retorno.AntCli = examen.Rows[0].ItemArray[1].ToString();
                retorno.AntQui = examen.Rows[0].ItemArray[2].ToString();
                retorno.AntTrau = examen.Rows[0].ItemArray[3].ToString();
                retorno.Talla = examen.Rows[0].ItemArray[4].ToString();
                retorno.Peso = examen.Rows[0].ItemArray[5].ToString();
                retorno.EntradaAire = examen.Rows[0].ItemArray[6].ToString();
                retorno.RuidosAgre = examen.Rows[0].ItemArray[7].ToString();
                retorno.RuidosCard = examen.Rows[0].ItemArray[8].ToString();
                retorno.Silencios = examen.Rows[0].ItemArray[9].ToString();
                retorno.TaMax = examen.Rows[0].ItemArray[10].ToString();
                retorno.TaMin = examen.Rows[0].ItemArray[11].ToString();
                retorno.Pulso = examen.Rows[0].ItemArray[12].ToString();
                retorno.Abdomen = examen.Rows[0].ItemArray[13].ToString();
                retorno.Hernias = examen.Rows[0].ItemArray[14].ToString();
                retorno.Varices = examen.Rows[0].ItemArray[15].ToString();
                retorno.ApGenitour = examen.Rows[0].ItemArray[16].ToString();
                retorno.PielYFaneras = examen.Rows[0].ItemArray[17].ToString();
                retorno.ApLocomotor = examen.Rows[0].ItemArray[18].ToString();
                retorno.Snc = examen.Rows[0].ItemArray[19].ToString();
                retorno.OjoDer = examen.Rows[0].ItemArray[20].ToString();
                retorno.OjoDerLent = examen.Rows[0].ItemArray[21].ToString();
                retorno.OjoIzq = examen.Rows[0].ItemArray[22].ToString();
                retorno.OjoIzqLent = examen.Rows[0].ItemArray[23].ToString();
                retorno.VisionCromatica = examen.Rows[0].ItemArray[24].ToString();
                retorno.ExOdonto = examen.Rows[0].ItemArray[25].ToString();
                retorno.Equil = examen.Rows[0].ItemArray[26].ToString();
                retorno.ObservacionesCli = examen.Rows[0].ItemArray[27].ToString();
                retorno.Medico = examen.Rows[0].ItemArray[28].ToString();
                retorno.DictamenCli = examen.Rows[0].ItemArray[29].ToString();
                retorno.GRojos = examen.Rows[0].ItemArray[30].ToString();
                retorno.GBlancos = examen.Rows[0].ItemArray[31].ToString();
                retorno.Hemoglobina = examen.Rows[0].ItemArray[32].ToString();
                retorno.Hematocrito = examen.Rows[0].ItemArray[33].ToString();
                retorno.Eritro = examen.Rows[0].ItemArray[34].ToString();
                retorno.Plaquetas = examen.Rows[0].ItemArray[35].ToString();
                retorno.ObsSerieRoja = examen.Rows[0].ItemArray[36].ToString();
                retorno.Cayado = examen.Rows[0].ItemArray[37].ToString();
                retorno.Segmentado = examen.Rows[0].ItemArray[38].ToString();
                retorno.Eosinof = examen.Rows[0].ItemArray[39].ToString();
                retorno.Basof = examen.Rows[0].ItemArray[40].ToString();
                retorno.Linfoc = examen.Rows[0].ItemArray[41].ToString();
                retorno.Monoc = examen.Rows[0].ItemArray[42].ToString();
                retorno.ObsSerieBlanca = examen.Rows[0].ItemArray[43].ToString();
                retorno.Glucemia = examen.Rows[0].ItemArray[44].ToString();
                retorno.Uremia = examen.Rows[0].ItemArray[45].ToString();
                retorno.Chagas = examen.Rows[0].ItemArray[46].ToString();
                retorno.Vdrl = examen.Rows[0].ItemArray[47].ToString();
                retorno.Grupo = examen.Rows[0].ItemArray[48].ToString();
                retorno.Factor = examen.Rows[0].ItemArray[49].ToString();
                retorno.Uricemia = examen.Rows[0].ItemArray[50].ToString();
                retorno.Te = examen.Rows[0].ItemArray[51].ToString();
                retorno.OtrosQuimicaHemat = examen.Rows[0].ItemArray[52].ToString();
                retorno.ColTotal = examen.Rows[0].ItemArray[53].ToString();
                retorno.Hdl = examen.Rows[0].ItemArray[54].ToString();
                retorno.Ldl = examen.Rows[0].ItemArray[55].ToString();
                retorno.Triglic = examen.Rows[0].ItemArray[56].ToString();
                retorno.OtrosPerfilLipidico = examen.Rows[0].ItemArray[57].ToString();
                retorno.Color = examen.Rows[0].ItemArray[58].ToString();
                retorno.Aspecto = examen.Rows[0].ItemArray[59].ToString();
                retorno.Densidad = examen.Rows[0].ItemArray[60].ToString();
                retorno.Ph = examen.Rows[0].ItemArray[61].ToString();
                retorno.Celulas = examen.Rows[0].ItemArray[62].ToString();
                retorno.Leuco = examen.Rows[0].ItemArray[63].ToString();
                retorno.Hematies = examen.Rows[0].ItemArray[64].ToString();
                retorno.Prot = examen.Rows[0].ItemArray[65].ToString();
                retorno.Gluc = examen.Rows[0].ItemArray[66].ToString();
                retorno.HemogOrina = examen.Rows[0].ItemArray[67].ToString();
                retorno.Cetonas = examen.Rows[0].ItemArray[68].ToString();
                retorno.Bilirrubina = examen.Rows[0].ItemArray[69].ToString();
                retorno.OtrosOrina = examen.Rows[0].ItemArray[70].ToString();
                retorno.ObservacionesLab = examen.Rows[0].ItemArray[71].ToString();
                retorno.DictamenLab = examen.Rows[0].ItemArray[72].ToString();
                retorno.ToraxF = examen.Rows[0].ItemArray[73].ToString();
                retorno.LumbarF = examen.Rows[0].ItemArray[74].ToString();
                retorno.LumbarP = examen.Rows[0].ItemArray[75].ToString();
                retorno.CervicalF = examen.Rows[0].ItemArray[76].ToString();
                retorno.CervicalP = examen.Rows[0].ItemArray[77].ToString();
                retorno.Fnp = examen.Rows[0].ItemArray[78].ToString();
                retorno.Mnp = examen.Rows[0].ItemArray[79].ToString();
                retorno.HombrosF = examen.Rows[0].ItemArray[80].ToString();
                retorno.RodillasF = examen.Rows[0].ItemArray[81].ToString();
                retorno.CaderasF = examen.Rows[0].ItemArray[82].ToString();
                retorno.TobillosF = examen.Rows[0].ItemArray[83].ToString();
                retorno.CraneoFyP = examen.Rows[0].ItemArray[84].ToString();
                retorno.HombroF = examen.Rows[0].ItemArray[85].ToString();
                retorno.HombroVP = examen.Rows[0].ItemArray[86].ToString();
                retorno.HumeroFyP = examen.Rows[0].ItemArray[87].ToString();
                retorno.CodoFyP = examen.Rows[0].ItemArray[88].ToString();
                retorno.AntebrazoFyP = examen.Rows[0].ItemArray[89].ToString();
                retorno.MunecaFyP = examen.Rows[0].ItemArray[90].ToString();
                retorno.ManoFyP = examen.Rows[0].ItemArray[91].ToString();
                retorno.ToraxP = examen.Rows[0].ItemArray[92].ToString();
                retorno.PCostalFyO = examen.Rows[0].ItemArray[93].ToString();
                retorno.ColDorsalFyP = examen.Rows[0].ItemArray[94].ToString();
                retorno.PelvisF = examen.Rows[0].ItemArray[95].ToString();
                retorno.CaderaF = examen.Rows[0].ItemArray[96].ToString();
                retorno.CaderaP = examen.Rows[0].ItemArray[97].ToString();
                retorno.FemurFyP = examen.Rows[0].ItemArray[98].ToString();
                retorno.RodillaF = examen.Rows[0].ItemArray[99].ToString();
                retorno.RodillaP = examen.Rows[0].ItemArray[100].ToString();
                retorno.PiernaFyP = examen.Rows[0].ItemArray[101].ToString();
                retorno.TobilloFyP = examen.Rows[0].ItemArray[102].ToString();
                retorno.AxialDeCalcaneo = examen.Rows[0].ItemArray[103].ToString();
                retorno.PieFyP = examen.Rows[0].ItemArray[104].ToString();
                retorno.Audio = examen.Rows[0].ItemArray[105].ToString();
                retorno.Ergo = examen.Rows[0].ItemArray[106].ToString();
                retorno.Eco = examen.Rows[0].ItemArray[107].ToString();
                retorno.Psico = examen.Rows[0].ItemArray[108].ToString();
                retorno.Espiro = examen.Rows[0].ItemArray[109].ToString();
                retorno.Eeg = examen.Rows[0].ItemArray[110].ToString();
                retorno.ITorg = examen.Rows[0].ItemArray[111].ToString();
                retorno.Ecg = examen.Rows[0].ItemArray[112].ToString();
                retorno.Observaciones = examen.Rows[0].ItemArray[113].ToString();
                retorno.Dictamen = examen.Rows[0].ItemArray[114].ToString();
                retorno.Na = examen.Rows[0].ItemArray[115].ToString();
                retorno.K = examen.Rows[0].ItemArray[116].ToString();
                retorno.ProtTotales = examen.Rows[0].ItemArray[117].ToString();
                retorno.Albumina = examen.Rows[0].ItemArray[118].ToString();
                retorno.ALFA1 = examen.Rows[0].ItemArray[119].ToString();
                retorno.ALFA2 = examen.Rows[0].ItemArray[120].ToString();
                retorno.BETA1 = examen.Rows[0].ItemArray[121].ToString();
                retorno.BETA2 = examen.Rows[0].ItemArray[122].ToString();
                retorno.Gammaglob = examen.Rows[0].ItemArray[123].ToString();
                retorno.RelacAlbGlob = examen.Rows[0].ItemArray[124].ToString();
                retorno.Creat = examen.Rows[0].ItemArray[125].ToString();
            }
            return retorno;

        }

        public void llenarParametrosReporteLaboral(string idExamenLaboral)
        {
            ImpresionExamenLaboral retorno = new ImpresionExamenLaboral();
            DataTable examen = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ExamenLaboral
            where id = '" + idExamenLaboral + "'");
            if (examen.Rows.Count > 0)
            {
                retorno.AntCli = examen.Rows[0].ItemArray[1].ToString();
                retorno.AntQui = examen.Rows[0].ItemArray[2].ToString();
                retorno.AntTrau = examen.Rows[0].ItemArray[3].ToString();
            }
            



        }

        public DataTable cargarParametrosExamen(string idExamen, bool oliv)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("tipoExamen");
            retorno.Columns.Add("fecha");
            retorno.Columns.Add("nro");
            retorno.Columns.Add("empresa");
            retorno.Columns.Add("dni");
            retorno.Columns.Add("nacimiento");
            retorno.Columns.Add("apellidoNombre");
            retorno.Columns.Add("nacionalidad");
            retorno.Columns.Add("direccion");
            retorno.Columns.Add("localidad");
            retorno.Columns.Add("telefono");
            retorno.Columns.Add("tarea");
            retorno.Columns.Add("antCli");
            retorno.Columns.Add("antQui");
            retorno.Columns.Add("antTrau");
            retorno.Columns.Add("talla");
            retorno.Columns.Add("peso");
            retorno.Columns.Add("imc");
            retorno.Columns.Add("entAire");
            retorno.Columns.Add("ruiAgre");
            retorno.Columns.Add("ruiCard");
            retorno.Columns.Add("silencios");
            retorno.Columns.Add("taMax");
            retorno.Columns.Add("taMin");
            retorno.Columns.Add("pulso");
            retorno.Columns.Add("abdomen");
            retorno.Columns.Add("hernias");
            retorno.Columns.Add("varices");
            retorno.Columns.Add("apGenitour");
            retorno.Columns.Add("pielYFaneras");
            retorno.Columns.Add("apLocomotor");
            retorno.Columns.Add("snc");
            retorno.Columns.Add("ojoDer");
            retorno.Columns.Add("ojoDerLent");
            retorno.Columns.Add("ojoIzq");
            retorno.Columns.Add("ojoIzqLent");
            retorno.Columns.Add("visionCromatica");
            retorno.Columns.Add("exOdonto");
            retorno.Columns.Add("equil");
            retorno.Columns.Add("equilTxt");
            retorno.Columns.Add("medico");
            retorno.Columns.Add("obsCli");
            retorno.Columns.Add("txtEncabezado1");
            retorno.Columns.Add("encabezado1");
            retorno.Columns.Add("txtEncabezado2");
            retorno.Columns.Add("encabezado2");
            retorno.Columns.Add("txtEncabezado3");
            retorno.Columns.Add("encabezado3");
            retorno.Columns.Add("txtEncabezado4");
            retorno.Columns.Add("encabezado4");
            retorno.Columns.Add("txtEncabezado5");
            retorno.Columns.Add("encabezado5");
            retorno.Columns.Add("txtEncabezado6");
            retorno.Columns.Add("encabezado6");
            retorno.Columns.Add("txtEncabezado7");
            retorno.Columns.Add("encabezado7");
            retorno.Columns.Add("txtEncabezado8");
            retorno.Columns.Add("encabezado8");
            retorno.Columns.Add("txtEncabezado9");
            retorno.Columns.Add("encabezado9");
            retorno.Columns.Add("txtEncabezado10");
            retorno.Columns.Add("encabezado10");
            retorno.Columns.Add("txtEncabezado11");
            retorno.Columns.Add("encabezado11");
            retorno.Columns.Add("txtEncabezado12");
            retorno.Columns.Add("encabezado12");
            retorno.Columns.Add("txtEncabezado13");
            retorno.Columns.Add("encabezado13");
            retorno.Columns.Add("txtEncabezado14");
            retorno.Columns.Add("encabezado14");
            retorno.Columns.Add("txtEncabezado15");
            retorno.Columns.Add("encabezado15");
            retorno.Columns.Add("txtEncabezado16");
            retorno.Columns.Add("encabezado16");
            retorno.Columns.Add("txtEncabezado17");
            retorno.Columns.Add("encabezado17");
            retorno.Columns.Add("dictFinal");
            retorno.Columns.Add("observaciones");
            retorno.Columns.Add("encabezado");

            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"
            select e.descripcionInformes,  Convert(varchar(10),CONVERT(date,c.fecha,106),103) as fecha, 
            c.identificador, emp.razonSocial, p.dni, Convert(varchar(10),CONVERT(date,p.fechaNacimiento,106),103) as nacimiento,
            (p.apellido + ' ' + p.nombres) as apellidoNombre,
            p.nacionalidad, p. direccion, p.localidad, (ISNULL(p.telefonos, '') + ' / ' + ISNULL(p.celular, '')) AS telefonos, ete.tarea, el.*, tep.id
            as idTe from dbo.ExamenLaboral el
            inner join dbo.ConsultaLaboral cl on el.id = cl.idExamenLaboral
            inner join dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
            inner join dbo.Consulta c on tep.idConsulta = c.id
            inner join dbo.Especialidad e on tep.idEspecialidad = e.id
            inner join dbo.PacienteLaboral p on c.pacienteID = p.id
            inner join dbo.empresaPorTipoDeExamen ete on tep.id = ete.idTipoExamen
            inner join dbo.Empresa emp on ete.idEmpresa = emp.id
            where el.id = '" + idExamen + "'");

            string nacionalidad = "";
            if (consulta.Rows[0].ItemArray[7].ToString() != "")
            {
                DataTable nac = SQLConnector.obtenerTablaSegunConsultaString(@"select descripcion from dbo.Nacionalidad 
                where id = '" + consulta.Rows[0].ItemArray[7].ToString() + "'");
                if (nac.Rows.Count > 0) { nacionalidad = nac.Rows[0].ItemArray[0].ToString(); }
                if (nacionalidad == "A DESIGNAR") { nacionalidad = ""; }
            }

            string localidad = "";
            if (consulta.Rows[0].ItemArray[9].ToString() != "")
            {               
                DataTable pres = SQLConnector.obtenerTablaSegunConsultaString(@"select pres from dbo.Prestaciones
                where id = '" + consulta.Rows[0].ItemArray[9].ToString() + "'");
                if (pres.Rows.Count > 0) { localidad = pres.Rows[0].ItemArray[0].ToString(); }
                if (localidad == "A DESIGNAR") { localidad = ""; }
            }


            if(consulta.Rows.Count > 0)
            {
            string medico = "";
            if (consulta.Rows[0].ItemArray[40].ToString() != string.Empty)
            {
                DataTable medicos = SQLConnector.obtenerTablaSegunConsultaString(@"select (apellido + ' ' + nombres), tipo, nroMatricula from
            Profesional where id = '" + consulta.Rows[0].ItemArray[40].ToString() + "'");
                if (medicos.Rows.Count > 0)
                {
                    medico = medicos.Rows[0].ItemArray[1].ToString() + " " + medicos.Rows[0].ItemArray[0].ToString()
                        + " M.N: " + medicos.Rows[0].ItemArray[2].ToString();
                }
            }
            string dictCli = "";
            DataTable dictamenes = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.DictamenesLaboral");
            if (dictamenes.Select("id = '" + consulta.Rows[0].ItemArray[41].ToString() + "'").Length > 0)
            {
                dictCli = dictamenes.Select("id = '" + consulta.Rows[0].ItemArray[41].ToString() + "'")[0][2].ToString();
            }
            string dictFinal = "";
            if (dictamenes.Select("id = '" + consulta.Rows[0].ItemArray[126].ToString() + "'").Length > 0)
            {
                dictFinal = dictamenes.Select("id = '" + consulta.Rows[0].ItemArray[126].ToString() + "'")[0][2].ToString();
            }


            List<string> encabezados = new List<string>();
            for (int i = 1; i <= 17; i++) { encabezados.Add(""); }
            List<string> txtencabezados = new List<string>();
            for (int i = 1; i <= 17; i++) { txtencabezados.Add(""); }
            puntEncabez = 0;
            puntTxtEncab = 0;

            TipoExamen te = new TipoExamen();
            Entidades.TipoExamen entidad = te.cargarEstudiosPorExamen(consulta.Rows[0].ItemArray[140].ToString());


            if (entidad.Clinico.Select("Id = 1 and Estado = true").Length > 0)
            {
                encabezados[puntEncabez] = "DICTAMEN CLINICO";
                puntEncabez++;
                txtencabezados[puntTxtEncab] = dictCli;
                puntTxtEncab++;
            }


            if (entidad.Hematologia.Select("Estado = true").Length > 0 ||
                entidad.QuimicaHematica.Select("Estado = true").Length > 0 ||
                entidad.Serologia.Select("Estado = true").Length > 0 ||
                entidad.PerfilLipidico.Select("Estado = true").Length > 0 ||
                entidad.Bacteriologia.Select("Estado = true").Length > 0 ||
                entidad.Orina.Select("Estado = true").Length > 0)
            {
                encabezados[puntEncabez] = "LABORATORIO";
                puntEncabez++;
                txtencabezados[puntTxtEncab] = consulta.Rows[0].ItemArray[84].ToString();
                puntTxtEncab++;
            }

            setearValoresDinamicos(entidad.EstComplementarios, "Id = 78", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[124].ToString(), "");
            setearValoresDinamicos(entidad.LaboralesBasicas, "Id = 38", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[85].ToString(), "RX. ");
            setearValoresDinamicos(entidad.LaboralesBasicas, "Id = 39", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[86].ToString(), "RX. ");
            setearValoresDinamicos(entidad.LaboralesBasicas, "Id = 40", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[87].ToString(), "RX. ");
            setearValoresDinamicos(entidad.LaboralesBasicas, "Id = 41", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[88].ToString(), "RX. ");
            setearValoresDinamicos(entidad.LaboralesBasicas, "Id = 42", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[89].ToString(), "RX. ");
            setearValoresDinamicos(entidad.LaboralesBasicas, "Id = 43", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[90].ToString(), "RX. ");
            setearValoresDinamicos(entidad.LaboralesBasicas, "Id = 44", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[91].ToString(), "RX. ");
            setearValoresDinamicos(entidad.LaboralesBasicas, "Id = 45", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[92].ToString(), "RX. ");
            setearValoresDinamicos(entidad.LaboralesBasicas, "Id = 46", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[93].ToString(), "RX. ");
            setearValoresDinamicos(entidad.LaboralesBasicas, "Id = 80", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[94].ToString(), "RX. ");
            setearValoresDinamicos(entidad.LaboralesBasicas, "Id = 81", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[95].ToString(), "RX. ");
            setearValoresDinamicos(entidad.CraneoYMSuperior, "Id = 47", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[96].ToString(), "RX. ");
            setearValoresDinamicos(entidad.CraneoYMSuperior, "Id = 48", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[97].ToString(), "RX. ");
            setearValoresDinamicos(entidad.CraneoYMSuperior, "Id = 49", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[98].ToString(), "RX. ");
            setearValoresDinamicos(entidad.CraneoYMSuperior, "Id = 50", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[99].ToString(), "RX. ");
            setearValoresDinamicos(entidad.CraneoYMSuperior, "Id = 51", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[100].ToString(), "RX. ");
            setearValoresDinamicos(entidad.CraneoYMSuperior, "Id = 52", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[101].ToString(), "RX. ");
            setearValoresDinamicos(entidad.CraneoYMSuperior, "Id = 53", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[102].ToString(), "RX. ");
            setearValoresDinamicos(entidad.CraneoYMSuperior, "Id = 54", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[103].ToString(), "RX. ");
            setearValoresDinamicos(entidad.TroncoYPelvis, "Id = 55", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[104].ToString(), "RX. ");
            setearValoresDinamicos(entidad.TroncoYPelvis, "Id = 56", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[105].ToString(), "RX. ");
            setearValoresDinamicos(entidad.TroncoYPelvis, "Id = 57", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[106].ToString(), "RX. ");
            setearValoresDinamicos(entidad.TroncoYPelvis, "Id = 58", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[107].ToString(), "RX. ");
            setearValoresDinamicos(entidad.TroncoYPelvis, "Id = 59", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[108].ToString(), "RX. ");
            setearValoresDinamicos(entidad.TroncoYPelvis, "Id = 60", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[109].ToString(), "RX. ");
            setearValoresDinamicos(entidad.MiembroInferior, "Id = 61", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[110].ToString(), "RX. ");
            setearValoresDinamicos(entidad.MiembroInferior, "Id = 62", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[111].ToString(), "RX. ");
            setearValoresDinamicos(entidad.MiembroInferior, "Id = 63", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[112].ToString(), "RX. ");
            setearValoresDinamicos(entidad.MiembroInferior, "Id = 64", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[113].ToString(), "RX. ");
            setearValoresDinamicos(entidad.MiembroInferior, "Id = 65", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[114].ToString(), "RX. ");
            setearValoresDinamicos(entidad.MiembroInferior, "Id = 66", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[115].ToString(), "RX. ");
            setearValoresDinamicos(entidad.MiembroInferior, "Id = 67", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[116].ToString(), "RX. ");

            setearValoresDinamicos(entidad.EstComplementarios, "Id = 68", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[117].ToString(), "");
            setearValoresDinamicos(entidad.EstComplementarios, "Id = 70", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[118].ToString(), "");
            setearValoresDinamicos(entidad.EstComplementarios, "Id = 72", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[119].ToString(), "");
            setearValoresDinamicos(entidad.EstComplementarios, "Id = 73", encabezados, txtencabezados,
            consulta.Rows[0].ItemArray[120].ToString(), "");
            setearValoresDinamicos(entidad.EstComplementarios, "Id = 75", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[121].ToString(), "");
            setearValoresDinamicos(entidad.EstComplementarios, "Id = 76", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[122].ToString(), "");
            setearValoresDinamicos(entidad.EstComplementarios, "Id = 77", encabezados, txtencabezados, 
            consulta.Rows[0].ItemArray[123].ToString(), "");

            string encabezadoEquilibriometrico = "";
            string resultadoEquilibriometrico = "";
            if (entidad.Clinico.Select("Id = 69 and Estado = true").Length > 0)
            {
                encabezadoEquilibriometrico = "Equilibriometrico";
                resultadoEquilibriometrico = consulta.Rows[0].ItemArray[38].ToString();
            }

            string encabezado = "DEPARTAMENTO DE MEDICINA LABORAL";
            if (oliv) { encabezado = consulta.Rows[0].ItemArray[0].ToString(); }
            string tipoEx = consulta.Rows[0].ItemArray[0].ToString();
            if (oliv) {tipoEx = "";}

            retorno.Rows.Add(tipoEx,consulta.Rows[0].ItemArray[1].ToString(),
            consulta.Rows[0].ItemArray[2].ToString(),consulta.Rows[0].ItemArray[3].ToString(),consulta.Rows[0].ItemArray[4].ToString(),
            consulta.Rows[0].ItemArray[5].ToString(),consulta.Rows[0].ItemArray[6].ToString(),nacionalidad,consulta.Rows[0].ItemArray[8].ToString(),
            localidad,consulta.Rows[0].ItemArray[10].ToString(),consulta.Rows[0].ItemArray[11].ToString(),
            consulta.Rows[0].ItemArray[13].ToString(),consulta.Rows[0].ItemArray[14].ToString(),consulta.Rows[0].ItemArray[15].ToString(),  
            consulta.Rows[0].ItemArray[16].ToString() + " m.",consulta.Rows[0].ItemArray[17].ToString() + " kg.",
            calcularImc(consulta.Rows[0].ItemArray[16].ToString(), consulta.Rows[0].ItemArray[17].ToString()),
            consulta.Rows[0].ItemArray[18].ToString(), consulta.Rows[0].ItemArray[19].ToString(),
            consulta.Rows[0].ItemArray[20].ToString(), consulta.Rows[0].ItemArray[21].ToString(),
            consulta.Rows[0].ItemArray[22].ToString(), consulta.Rows[0].ItemArray[23].ToString(),
            consulta.Rows[0].ItemArray[24].ToString() + " x min", consulta.Rows[0].ItemArray[25].ToString(),
            consulta.Rows[0].ItemArray[26].ToString(), consulta.Rows[0].ItemArray[27].ToString(),
            consulta.Rows[0].ItemArray[28].ToString(), consulta.Rows[0].ItemArray[29].ToString(),
            consulta.Rows[0].ItemArray[30].ToString(), consulta.Rows[0].ItemArray[31].ToString(),
            consulta.Rows[0].ItemArray[32].ToString(), consulta.Rows[0].ItemArray[33].ToString(),
            consulta.Rows[0].ItemArray[34].ToString(), consulta.Rows[0].ItemArray[35].ToString(),
            consulta.Rows[0].ItemArray[36].ToString(), consulta.Rows[0].ItemArray[37].ToString(),
            encabezadoEquilibriometrico, resultadoEquilibriometrico, medico, consulta.Rows[0].ItemArray[39].ToString(),
            encabezados[0],txtencabezados[0],encabezados[1],txtencabezados[1],encabezados[2],txtencabezados[2],
            encabezados[3],txtencabezados[3],encabezados[4],txtencabezados[4],encabezados[5],txtencabezados[5],
            encabezados[6],txtencabezados[6],encabezados[7],txtencabezados[7],encabezados[8],txtencabezados[8],
            encabezados[9], txtencabezados[9],encabezados[10], txtencabezados[10],encabezados[11], txtencabezados[11],
            encabezados[12], txtencabezados[12],encabezados[13], txtencabezados[13],encabezados[14], txtencabezados[14],
            dictFinal, consulta.Rows[0].ItemArray[125].ToString(), encabezado);
            }

            return retorno;

        }

        private void setearValoresDinamicos(DataTable items, string filtro, List<string> enc, List<string> txtEnc,
             string valorTxt, string encabezAdic)
        {
            //try
            //{
                DataRow[] r = items.Select(filtro + " and Estado = true");
                if (r.Length > 0)
                {
                    enc[puntEncabez] = encabezAdic + r[0][4].ToString();
                    puntEncabez++;
                    txtEnc[puntTxtEncab] = valorTxt;
                    puntTxtEncab++;
                }
            //}
            //catch (System.ArgumentOutOfRangeException ex)
            //{
            //    //
            //}
        }

        private string calcularImc(string talla, string peso)
        {
            decimal IMC = 0;

            try
            {
                decimal m = Convert.ToDecimal(talla.Replace('.', ','));
                decimal p = Convert.ToDecimal(peso);
                IMC = decimal.Round((p / (m * m)), 0);                
            }
            catch (System.FormatException ex)
            {
                //
            }

            return IMC.ToString();
        }

        public DataTable cargarDataSourceExamen(byte[] foto, string tipo)
        {
            return setearDataSource(foto, tipo);
        }

        public DataTable cargarDataSourceConsultorio()
        {
            return setearDataSource(null, "5");
        }

        public DataTable cargarDataSourceHistoriaClinica()
        {
            return setearDataSource(null, "6");
        }

        private DataTable setearDataSource(byte[] foto, string tipo)
        {
            // GRV - Ramírez - modificar consulta
            //DataTable configReporte = SQLConnector.obtenerTablaSegunConsultaString(@"select * from dbo.ConfigReportes

            DataTable configReporte = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT id, logo, firma, profesional, matricula, cargo, piePagina, tipoReporte, libroFolio FROM dbo.ConfigReportes
            where tipoReporte = " + tipo);
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Logo");
            retorno.Columns.Add("Firma");
            retorno.Columns.Add("PiePagina");
            retorno.Columns.Add("Profesional");
            retorno.Columns.Add("Matricula");
            retorno.Columns.Add("Cargo");
            retorno.Columns.Add("Foto");
            retorno.Columns.Add("LibroFolio");
            retorno.Columns[0].DataType = System.Type.GetType("System.Byte[]");
            retorno.Columns[1].DataType = System.Type.GetType("System.Byte[]");
            retorno.Columns[6].DataType = System.Type.GetType("System.Byte[]");
            if (configReporte.Rows.Count > 0)
            {
                //string RutaLogo = Convert.ToString(configReporte.Rows[0].ItemArray[1]);                
                //retorno.Rows.Add(configReporte.Rows[0].ItemArray[1], configReporte.Rows[0].ItemArray[2],
                //    configReporte.Rows[0].ItemArray[6], configReporte.Rows[0].ItemArray[3],
                //    configReporte.Rows[0].ItemArray[4], configReporte.Rows[0].ItemArray[5],
                //    foto, configReporte.Rows[0].ItemArray[8]);
                retorno.Rows.Add(Imagen_A_Bytes(Convert.ToString(configReporte.Rows[0].ItemArray[1])), Imagen_A_Bytes(Convert.ToString(configReporte.Rows[0].ItemArray[2])),
                    configReporte.Rows[0].ItemArray[6], configReporte.Rows[0].ItemArray[3],
                    configReporte.Rows[0].ItemArray[4], configReporte.Rows[0].ItemArray[5],
                    foto, configReporte.Rows[0].ItemArray[8]);
            }
            return retorno;
        }

        // GRV - Ramírez - Convertir imagenes a bytes
        public Byte[] Imagen_A_Bytes(String ruta)
        {
            Byte[] arreglo;

            if (ruta != "")
            {
                FileStream foto = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                arreglo = new Byte[foto.Length];
                BinaryReader reader = new BinaryReader(foto);
                arreglo = reader.ReadBytes(Convert.ToInt32(foto.Length));
                foto.Dispose();
                foto.Close();
            }
            else
            {
                arreglo = new byte[ruta.Length * sizeof(char)];
                System.Buffer.BlockCopy(ruta.ToCharArray(), 0, arreglo, 0, arreglo.Length);
            }
            return arreglo;
        }

        public DataTable cargarParametrosConsultorio(string idConsultoio)
        {
            DataTable retorno = new DataTable();
            retorno.Columns.Add("Lugar");
            retorno.Columns.Add("Fecha");
            retorno.Columns.Add("Empresa");
            retorno.Columns.Add("DNI");
            retorno.Columns.Add("ApellidoNombre");
            retorno.Columns.Add("TxtDireccion");
            retorno.Columns.Add("Direccion");
            retorno.Columns.Add("TxtLocalidad");
            retorno.Columns.Add("Localidad");
            retorno.Columns.Add("Diagnostico");
            retorno.Columns.Add("CondicionLaboral");
            retorno.Columns.Add("AltaCitacion");
            retorno.Columns.Add("FechaAltaCitacion");
            retorno.Columns.Add("Motivo");
            retorno.Columns.Add("EstadoAtencion");

            DataTable consulta = SQLConnector.obtenerTablaSegunConsultaString(@"select consl.idLugarAtencion, 
            consl.fechaHora, e.razonSocial,
            p.dni, p.apellido + ' ' + p.nombres as apellidoNombre, ' ', ' ', 
            consl.diagnostico, consl.idCondicionLaboral, consl.fechaAltaCitacion,
            consl.idMotivo, consl.idEstadoAtencion 
            from dbo.ConsultorioLaboral consl
            inner join dbo.ConsultaLaboral cl on cl.idConsultorioLaboral = consl.id
            inner join dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
            inner join dbo.Consulta c on tep.idConsulta = c.id
            inner join dbo.PacienteLaboral p on c.pacienteID = p.id
            inner join dbo.empresaPorTipoDeExamen ete on tep.id = ete.idTipoExamen
            inner join dbo.Empresa e on e.id = ete.idEmpresa
            where consl.id = '" + idConsultoio + "'");

            if (consulta.Rows.Count > 0)
            {
                string lugarAtencion = "";
                DataTable lugar = SQLConnector.obtenerTablaSegunConsultaString(@"select descripcion from dbo.LugarAtencion
                where id = '" + consulta.Rows[0].ItemArray[0].ToString() + "'");
                if (lugar.Rows.Count > 0) { lugarAtencion = "ATENCIÓN EN " + lugar.Rows[0].ItemArray[0].ToString(); }

                string condLaboral = "";
                string txtFechaAltaCitacion = "";
                string fechaAltaCitacion = "";
                DataTable condLab = SQLConnector.obtenerTablaSegunConsultaString(@"select fechaAlta,fechaCitacion, descripcion from dbo.CondicionLaboral
                where id = '" + consulta.Rows[0].ItemArray[8].ToString() + "'");
                if (condLab.Rows.Count > 0) 
                {
                    condLaboral = condLab.Rows[0][2].ToString();
                    if (condLab.Rows[0][0].ToString() == "SI" || condLab.Rows[0][1].ToString() == "SI")
                    {
                        txtFechaAltaCitacion = "FECHA:";
                        fechaAltaCitacion = ((DateTime)consulta.Rows[0].ItemArray[9]).ToShortDateString();
           
                    }
                }

                string motivo = "";
                DataTable mot = SQLConnector.obtenerTablaSegunConsultaString(@"select descripcion from dbo.MotivoDeConsultaLaboral
                where id = '" + consulta.Rows[0].ItemArray[10].ToString() + "'");
                if (mot.Rows.Count > 0) { motivo = mot.Rows[0].ItemArray[0].ToString(); }

                string estado = "";
                DataTable est = SQLConnector.obtenerTablaSegunConsultaString(@"select descripcion from dbo.EstadoAtencion
                where id = '" + consulta.Rows[0].ItemArray[11].ToString() + "'");
                if (est.Rows.Count > 0) { estado = est.Rows[0].ItemArray[0].ToString(); }

                retorno.Rows.Add(lugarAtencion, ((DateTime)consulta.Rows[0].ItemArray[1]).ToShortDateString(),
                    consulta.Rows[0].ItemArray[2].ToString(), consulta.Rows[0].ItemArray[3].ToString(),
                    consulta.Rows[0].ItemArray[4].ToString(), "", "", "", "", consulta.Rows[0].ItemArray[7].ToString(),
                    condLaboral, txtFechaAltaCitacion,fechaAltaCitacion,
                    motivo, estado);

            }

            return retorno;
        }

        public string getIdTipoExamen(string idConsultaLaboral)
        {
            DataTable consLab = SQLConnector.obtenerTablaSegunConsultaString(@"select idTipoExamen from dbo.ConsultaLaboral
            where id = '" + idConsultaLaboral + "'");
            return consLab.Rows[0].ItemArray[0].ToString();
        }

        public Entidades.Resultado verificarEstadoAtencion(string idEstadoAtencion, string idPaciente, string fecha)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            DataTable condicionLaboral = SQLConnector.obtenerTablaSegunConsultaString(@"select  top(1) consL.idCondicionLaboral
            from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta
            inner join dbo.ConsultaLaboral cl on cl.idTipoExamen = tep.id
            inner join dbo.ConsultorioLaboral consL on cl.idConsultorioLaboral = consL.id
            where c.pacienteID = '" + idPaciente + @"' and c.fecha < '" + Convert.ToDateTime(fecha).ToShortDateString() + @"'
            order by c.fecha desc");
            DataTable estadoAtencion = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.EstadoAtencion");
            int codigo1 = 0;
            int codigo2 = 0;
            string mensaje;
            if (condicionLaboral.Rows.Count > 0 && condicionLaboral.Rows[0].ItemArray[0].ToString() != string.Empty)
            {
                DataRow[] rows = SQLConnector.obtenerTablaSegunConsultaString("select * from condicionLaboral").Select("id = '" + condicionLaboral.Rows[0].ItemArray[0].ToString() + "'");
                if (rows[0][5].ToString() == "SI" && rows[0][6].ToString() == "SI" && rows[0][7].ToString() == "NO")
                {
                    codigo1 = 1;
                    codigo2 = 3;
                    mensaje = "La consulta ingresada puede ser PRIMERA VEZ o REINGRESO, verifique la patología anterior";
                }
                else if (rows[0][5].ToString() == "SI" && rows[0][6].ToString() == "SI" && rows[0][7].ToString() == "SI")
                {
                    codigo1 = 3;
                    mensaje = "La consulta ingresada debe ser REINGRESO";
                }
                else if (rows[0][5].ToString() == "NO" && rows[0][6].ToString() == "NO" && rows[0][7].ToString() == "SI")
                {
                    codigo1 = 2;
                    mensaje = "La consulta ingresada debe ser CITACION";
                }
                else if (rows[0][5].ToString() == "SI" && rows[0][6].ToString() == "NO" && rows[0][7].ToString() == "NO")
                {
                    codigo1 = 1;
                    codigo2 = 3;
                    mensaje = "La consulta ingresada debe ser PRIMERA VEZ O REINGRESO";
                }
                else if (rows[0][5].ToString() == "NO" && rows[0][6].ToString() == "NO" && rows[0][7].ToString() == "NO")
                {
                    mensaje = @"La consulta anterior tiene como condicion laboral A DESIGNAR, por favor cambie
                    la condición laboral anterior para continuar";
                }
                else
                {
                    retorno.Modo = 1;
                    return retorno;
                }
            }
            else
            {
                codigo1 = 1;
                mensaje = "La consulta debe ser ingresada como PRIMERA VEZ debido a que el paciente no tiene consultas previas";
            }

            if (codigo1 != 0)
            {
                DataRow[] dr = estadoAtencion.Select("codigo = " + codigo1.ToString());
                string idEst = dr[0][0].ToString();
                if (idEst == idEstadoAtencion) { retorno.Modo = 1; return retorno; }
            }

            if (codigo2 != 0)
            {
                DataRow[] dr = estadoAtencion.Select("codigo = " + codigo2.ToString());
                string idEst = dr[0][0].ToString();
                if (idEst == idEstadoAtencion) { retorno.Modo = 1; return retorno; }
            }
            retorno.Modo = -1;
            retorno.Mensaje = mensaje;
            return retorno;
        }

        public List<string> cargarMailsEmpresaExamenLaboral(string idExamenLaboral)
        {
            List<string> retorno = new List<string>();
            DataTable idEmpresa = SQLConnector.obtenerTablaSegunConsultaString(@"select ete.idEmpresa 
            from dbo.ExamenLaboral el
            inner join dbo.ConsultaLaboral cl on el.id = cl.idExamenLaboral
            inner join dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
            inner join dbo.empresaPorTipoDeExamen ete on tep.id = ete.idTipoExamen
            where el.id = '" + idExamenLaboral + "'");
            if (idEmpresa.Rows.Count > 0)
            {
                retorno = cargarMailsEmpresa(idEmpresa.Rows[0][0].ToString());
            }
            return retorno;
        }

        private List<string> cargarMailsEmpresa(string idEmpresa)
        {
            List<string> retorno = new List<string>();
            DataTable mails = SQLConnector.obtenerTablaSegunConsultaString(@"select mail1, mail2, mail3 from dbo.Empresa
                where id = '" + idEmpresa + "'");
            if (mails.Rows.Count > 0)
            {
                if (mails.Rows[0][0].ToString() != string.Empty) { retorno.Add(mails.Rows[0][0].ToString()); }
                if (mails.Rows[0][1].ToString() != string.Empty) { retorno.Add(mails.Rows[0][1].ToString()); }
                if (mails.Rows[0][2].ToString() != string.Empty) { retorno.Add(mails.Rows[0][2].ToString()); }
            }
            return retorno;
        }

        public List<string> cargarMailsEmpresaConsultorio(string idConsultorio)
        {
            List<string> retorno = new List<string>();
            DataTable idEmpresa = SQLConnector.obtenerTablaSegunConsultaString(@"select ete.idEmpresa 
            from dbo.ConsultorioLaboral consL
            inner join dbo.ConsultaLaboral cl on consL.id = cl.idConsultorioLaboral
            inner join dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
            inner join dbo.empresaPorTipoDeExamen ete on tep.id = ete.idTipoExamen
            where consL.id = '" + idConsultorio + "'");
            if (idEmpresa.Rows.Count > 0)
            {
                retorno = cargarMailsEmpresa(idEmpresa.Rows[0][0].ToString());
            }
            return retorno;
        }

        // GRV - Modificado
        public DataTable cargarParametrosLaboratorio(string idExamenLaboratorio, sbyte tipoReporte)
        {
            string strSQL = "";
            DataTable dtConsulta;

            strSQL = "SELECT TOP 1 C.fecha, C.identificador, E.razonSocial, P.DNI, P.fechaNacimiento, (P.Apellido + ' ' + P.Nombres) as 'nombre', P.Telefonos, " +
	                        "P.Celular, EL.gRojos, EL.gBlancos, EL.hemoglobina, EL.hematocrito, EL.eritro, EL.plaquetas, EL.obsSerieRoja, " +
	                        "EL.cayado, EL.segmentado, EL.eosinof, EL.basof, EL.linfoc, EL.monoc, EL.obsSerieBlanca, EL.glucemia, EL.uremia, " +
	                        "EL.chagas, EL.vdrl, EL.grupo, EL.factor, EL.uricemia, EL.te, EL.otrosQuimicaHemat, EL.colTotal, EL.hdl, " +
	                        "EL.ldl, EL.trig, EL.otrosPerfilLipidico, EL.color, EL.aspecto, EL.celulas, EL.leuco, EL.hematies, EL.gluc, " +
                            "EL.hemogOrina, EL.prot, EL.cetonas, EL.bilirrubina, EL.otrosOrina, EL.dictamenLab, EL.densidad, EL.ph, CR.piePagina, " +
                            "CR.profesional, CR.matricula, CR.cargo, CR.logo AS Path, EL.observacionesLab, EL.na, EL.k, EL.protTotal, EL.albumina, EL.alfa1, EL.alfa2, EL.beta1, EL.beta2, EL.gammaglob, EL.relacAlbGlob, EL.creat " +
                        "FROM dbo.PacienteLaboral P " +
                        "INNER JOIN dbo.Consulta C ON P.id = C.pacienteID " +
                        "INNER JOIN dbo.TipoExamenDePaciente TEP ON TEP.idConsulta = C.id " +
                        "INNER JOIN dbo.ConsultaLaboral CL ON CL.idTipoExamen = TEP.id " +
                        "INNER JOIN dbo.ExamenLaboral EL ON CL.idExamenLaboral = EL.id " +
                        //"INNER JOIN dbo.EmpresasPorPaciente EPP ON EPP.idPaciente = C.pacienteID " +
                        "INNER JOIN dbo.empresaPorTipoDeExamen EPL ON EPL.idTipoExamen = CL.idTipoExamen " +
						"INNER JOIN dbo.EmpresasPorPaciente EPP ON EPP.idPaciente = C.pacienteID " +                        
                        "INNER JOIN dbo.Empresa E ON E.id = EPL.idEmpresa " +
                        //
                        "INNER JOIN dbo.ConfigReportes CR ON CR.tipoReporte = " + tipoReporte.ToString() + " " +
                        "WHERE EL.id = '" + idExamenLaboratorio + "' ORDER BY EPP.ingreso DESC";

            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            
            return cargarImagenDT(dtConsulta); 
        }

        private DataTable cargarImagenDT(DataTable dt)
        {
            dt.Columns.Add("logo", typeof(byte[]));
            //dt.Columns[55].DataType = System.Type.GetType("System.Byte[]");

            if (dt.Rows.Count > 0)
            {
                dt.Rows[0][67] = Imagen_A_Bytes(Convert.ToString(dt.Rows[0].ItemArray[54]));
            }

            return dt;
        }

        private string cargarValorValidacion(object idValidacion)
        {
            if (idValidacion.ToString() != "" && idValidacion != null)
            {
                DataRow[] dr = validaciones.Select("id = " + idValidacion);
                if (dr.Length > 0) { return dr[0][3].ToString(); }
            }
            return string.Empty;
        }

        public string IDExamenLaboral(string Fecha, string Identificador)
        {
            string strSQL = "";
            string strIDExamen = "";
            DataTable dtConsulta;

            strSQL = "SELECT TOP 1 EL.id " +
                     "FROM dbo.Consulta C " +
                     "INNER JOIN dbo.TipoExamenDePaciente TEP ON TEP.idConsulta = C.id AND tipo = 'L' " +
                     "INNER JOIN dbo.ConsultaLaboral CL ON CL.idTipoExamen = TEP.id " +
                     "INNER JOIN dbo.ExamenLaboral EL ON CL.idExamenLaboral = EL.id " +
                     "WHERE C.identificador = '" + Identificador + "' AND Convert(date, C.fecha) = '" + Convert.ToDateTime(Fecha).ToShortDateString() + "'";
            
            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
                strIDExamen = dtConsulta.Rows[0][0].ToString();

            return strIDExamen;
        }

        public bool ActualizarExamenLaboral(string Fecha, string Identificador, List<string> valores)
        {
            bool blnResultado = false;
            string strIdentificador = "";
            string strSQL;
            string strObservaciones = "";
            string strObsGeneral = "";
        //    DateTime dtFecha;
            DataTable dtConsulta;
            string strConsulta = "";
            string strHemoglobina = "";
            string strLDL = "";

            //if (dtExamenLaboratorio.Rows.Count > 0)
            //{
            //    foreach (DataRow r in dtExamenLaboratorio.Rows)
            //    {
            //dtFecha = Convert.ToDateTime(r.ItemArray[0].ToString());
            //strIdentificador = r.ItemArray[1].ToString();
            //strObservaciones = valores[36].ToString();
            if (!string.IsNullOrEmpty(valores[36].ToString()))
                strObsGeneral = strObsGeneral + valores[36].ToString() + ". ";
            if (!string.IsNullOrEmpty(valores[26].ToString()))
                strObservaciones = strObservaciones + "PIOCITOS: " + valores[26].ToString() + ". ";
            if (!string.IsNullOrEmpty(valores[27].ToString()))
                strObservaciones = strObservaciones + "MUCUS: " + valores[27].ToString() + ". ";

            if (valores.Count > 38)
            {
                strConsulta = ", na = '" + valores[37].ToString() + "', " +
                         "k = '" + valores[38].ToString() + "', " +
                         "protTotal = '" + valores[39].ToString() + "', " +
                         "albumina = '" + valores[40].ToString() + "', " +
                         "alfa1 = '" + valores[41].ToString() + "', " +
                         "alfa2 = '" + valores[42].ToString() + "', " +
                         "beta1 = '" + valores[43].ToString() + "', " +
                         "beta2 = '" + valores[44].ToString() + "', " +
                         "gammaglob = '" + valores[45].ToString() + "', " +
                         "relacAlbGlob = '" + valores[46].ToString() + "', " +
                         "creat = '" + valores[47].ToString() + "' ";
            }
            else
            {
                strConsulta = "";
            }

            strHemoglobina = valores[2].ToString();

            if (valores[2].Length > 4)
            {
                strHemoglobina = valores[2].Substring(0, 4).ToString();
            }

            strLDL = valores[31].ToString();
            test = valores[31].ToString();
            test = valores[31].ToString();

            if (valores[28].Length > 3)
            {
                strLDL = valores[28].Substring(0, 3).ToString();
            }

            strSQL =
            "UPDATE dbo.ExamenLaboral " +
            "SET " +
                 "gRojos = '" + valores[0].ToString() + "', " +
                 "gBlancos = '" + valores[1].ToString() + "', " +
                 "hemoglobina = '" + strHemoglobina + "', " +
                 "hematocrito = '" + valores[3].ToString() + "', " +
                 "eritro = '" + valores[4].ToString() + "', " +
                 "cayado = '" + valores[5].ToString() + "', " +
                 "segmentado = '" + valores[6].ToString() + "', " +
                 "eosinof = '" + valores[7].ToString() + "', " +
                 "basof = '" + valores[8].ToString() + "', " +
                 "linfoc = '" + valores[9].ToString() + "', " +
                 "monoc = '" + valores[10].ToString() + "', " +                         
                 "obsSerieRoja = 'NORMOCITICA NORMOCRONICA', " +
                 "obsSerieBlanca = 'NO SE OBSERVAN ATIPIAS', " +
                 "glucemia = '" + valores[11].ToString() + "', " +
                 "uremia = '" + valores[12].ToString() + "', " +
                 "chagas = '" + valores[13].ToString() + "', " +
                 "color = '" + valores[14].ToString() + "', " +
                 "aspecto = '" + valores[15].ToString() + "', " +
                 "densidad = '" + valores[16].ToString() + "', " +
                 "ph = '" + valores[17].ToString() + "', " +
                 "gluc = '" + valores[18].ToString() + "', " +
                 "prot = '" + valores[19].ToString() + "', " +                         
                 "hemogOrina = '" + valores[20].ToString() + "', " +
                 "cetonas = '" + valores[21].ToString() + "', " +
                 "bilirrubina = '" + valores[22].ToString() + "', " +
                 "celulas = '" + valores[23].ToString() + "', " +
                 "leuco = '" + valores[24].ToString() + "', " +
                 "hematies = '" + valores[25].ToString() + "', " +
                 "hdl = '" + valores[28].ToString() + "', " +
                 "colTotal = '" + valores[29].ToString() + "', " +                         
                 "trig = '" + valores[30].ToString() + "', " +
                 "ldl = '" + strLDL + "', " +
                 "grupo = '" + valores[32].ToString() + "', " +
                 "factor = '" + valores[33].ToString() + "', " +
                 "vdrl = '" + valores[34].ToString() + "', " +
                 "te = '" + valores[35].ToString() + "', " +
                 "otrosOrina = '" + strObservaciones + "', " +
                 "observacionesLab = '" + strObsGeneral + "' " +
                 strConsulta +
            "WHERE id = CONVERT(uniqueidentifier, '" + IDExamenLaboral(Fecha, Identificador) + "')";

            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            blnResultado = true;
            //    }
            //}

            return blnResultado;
        }

        public DataTable ComprobarEstudioPorExamen(string idTipoExamen)
        {            
            DataTable dtConsulta;
            string strSQL = "";

            strSQL = "SELECT Item4 AS HGB, item5 AS ERI, item6 AS 'GS-HR', item9 AS GLUCE, item10 AS URE, item22 AS CHA, item23 AS VDRL, " + 
	                 "item28 AS TE, item30 AS COL, item31 AS LDL, item32 AS HDL, item33 AS TGL, item37 AS ORINA " +
                     "FROM dbo.EstudiosPorExamen WHERE idTipoExamen = '" + idTipoExamen + "'";
            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            
            return dtConsulta;
        }

        public DataTable ExportarDictamenFinal(string desde, string hasta, string Empresa, string Motivo)
        {
            DataTable dtConsulta;
            string strSQL = "";
            string strMotivo = "";
            string strEmpresa = "";

            if ((Empresa == "") || (Empresa == "TODAS")){
                strEmpresa = "EMP.razonSocial like '%'";
            }
            else
            {
                strEmpresa = "EMP.razonSocial = '" + Empresa + "'";
            }

            if ((Motivo == "") || (Motivo == "TODAS"))
            {
                strMotivo = "e.descripcion LIKE '%'";
            }
            else
            {
                strMotivo = "e.descripcion = '" + Motivo + "'";
            }
            
            strSQL = "Select CONVERT(VARCHAR(10), c.fecha, 103) as fecha, c.identificador, EMP.razonSocial, e.descripcion AS 'MotivoConsulta', " +
                     "p.dni,(p.apellido + ' ' + p.nombres) AS 'Nombre', DL.descripcion AS 'Dictamen', EL.observaciones " +
                     "FROM dbo.Consulta c inner join dbo.PacienteLaboral p on c.pacienteID = p.id " +
                     "inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta " +
                     "inner join dbo.Especialidad e on tep.idEspecialidad = e.id " +
                     "inner join dbo.ConsultaLaboral cl on tep.id = cl.idTipoExamen " +
                     "INNER JOIN dbo.ExamenLaboral EL ON EL.id = cl.idExamenLaboral " +
                     "INNER JOIN dbo.DictamenesLaboral DL ON DL.id = EL.dictamen " +
                     "INNER JOIN dbo.empresaPorTipoDeExamen ete ON ete.idTipoExamen = tep.id " +
                     "INNER JOIN dbo.Empresa EMP ON EMP.id = ete.idEmpresa " +
                     "where c.tipo != 'P'  and c.tipo = 'L' and convert(date, c.fecha) >= '"+ desde + "' and convert(date, c.fecha) " +
                     "<= '" + hasta + "' AND " + strMotivo + " AND " + strEmpresa + " " +
                     "order by CONVERT(VARCHAR(10), c.fecha, 101), convert(int, REPLACE(REPLACE(c.identificador, 'L', ''), 'CO', '')), EMP.razonSocial";

            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dtConsulta;
        }

        public DataTable ConsultarEmpresa()
        {
            DataTable dtConsulta;
            string strSQL = "";

            strSQL = "SELECT id, razonSocial FROM dbo.Empresa ORDER BY razonSocial";

            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dtConsulta;
        }

        public DataTable ListarMotivoConsultaLaboral()
        {
            DataTable dtConsulta;
            string strSQL = "";

            strSQL = "SELECT id, descripcion FROM dbo.Especialidad WHERE descripcion NOT LIKE '%FUTB%' AND descripcion NOT LIKE '%INFANT%' ORDER BY descripcion";

            dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dtConsulta;
        }

        public string ObtenerIdConsultaLaboralSegunConsultorio(string idcons)
        {
            string str;

            str = "select * from [MEPRYLv2.1].[dbo].[ConsultaLaboral] where [idConsultorioLaboral] = '" + idcons + "'";

            DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(str);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }
    }    
}
