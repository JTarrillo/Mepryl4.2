using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class ConsolidarReportes
    {
        public ConsolidarReportes()
        {

        }

        public DataTable Directorios()
        {
            string strSQL = "";

            strSQL = "SELECT TOP 1 InfRadiologico, InfClinico, InfLaboratorio, InfRX, InfECG, InfConsolidado, plantilla, infAudiometria, infPsicotecnico, infErgometria FROM dbo.ConfigConsolidacion WHERE id = 1";
            DataTable dtResultado = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            
            return dtResultado;
        }

        public DataTable DirectoriosLaboral()
        {
            string strSQL = "";

            strSQL = "SELECT TOP 1 InfClinico, InfLaboratorio, InfRX, InfECG, infEspirometria, infEEG, infEcodoppler, infAudiometria, infPsicotecnico, infErgometria, InfConsolidado FROM dbo.ConfigConsolidacion WHERE id = 2";
            DataTable dtResultado = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dtResultado;
        }

        public DataTable DatosBase(DateTime FechaInicio, DateTime FechaFin, bool Movil, bool Clinica)
        {
            DataTable dtResultado = null;

            if (Movil == true && Clinica == true)
            {
                string strSQL = "";

                strSQL = "SELECT CONVERT(date, c.fecha) as Fecha, c.identificador as 'Nº Examen', p.dni as DNI, " +
                         "(p.apellido + ' ' + p.nombres) as Paciente, EP.dictFinal AS 'Infantil Inicial', " +
                         "item1 AS Clinico, item37 AS Orina, item38 AS RX, item77 AS ECG, item75 AS EEG, Item72 AS Psico, " +
                         "item68 as Audio, item70 AS Ergo, item71 AS Eco " +
                         "FROM dbo.Consulta c inner join dbo.TipoExamenDePaciente tep " +
                         "on c.id = tep.idConsulta inner join dbo.Paciente p on c.pacienteID = p.id " +
                         "INNER JOIN dbo.ExamenPreventiva EP ON EP.idTipoExamen = tep.id " +
                         "INNER JOIN dbo.EstudiosPorExamen EE ON EE.idTipoExamen = tep.id " +
                         "WHERE c.tipo = 'P' and Convert(date,c.fecha) >= convert(date,'" + FechaInicio.ToShortDateString() + "',105) and Convert(date,c.fecha) " +
                         "<= convert(date,'" + FechaFin.ToShortDateString() + "',105) " +
                         "ORDER BY c.fecha asc, convert(int,c.identificador) asc";

                dtResultado = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }

            if (Movil == true && Clinica == false)
            {
                string strSQL = "";

                strSQL = "SELECT CONVERT(date, c.fecha) as Fecha, c.identificador as 'Nº Examen', p.dni as DNI, " +
                         "(p.apellido + ' ' + p.nombres) as Paciente, EP.dictFinal AS 'Infantil Inicial', " +
                         "item1 AS Clinico, item37 AS Orina, item38 AS RX, item77 AS ECG, item75 AS EEG, Item72 AS Psico, " +
                         "item68 as Audio, item70 AS Ergo, item71 AS Eco " +
                         "FROM dbo.Consulta c inner join dbo.TipoExamenDePaciente tep " +
                         "on c.id = tep.idConsulta inner join dbo.Paciente p on c.pacienteID = p.id " +
                         "INNER JOIN dbo.ExamenPreventiva EP ON EP.idTipoExamen = tep.id " +
                         "INNER JOIN dbo.EstudiosPorExamen EE ON EE.idTipoExamen = tep.id " +
                         "WHERE c.tipo = 'P' and Convert(date,c.fecha) >= convert(date,'" + FechaInicio.ToShortDateString() + "',105) and Convert(date,c.fecha) " +
                         "<= convert(date,'" + FechaFin.ToShortDateString() + "',105) AND (c.identificador < 200 OR c.identificador > 399) " +
                         "ORDER BY c.fecha asc, convert(int,c.identificador) asc";

                dtResultado = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }

            if (Movil == false && Clinica == true)
            {
                string strSQL = "";

                strSQL = "SELECT CONVERT(date, c.fecha) as Fecha, c.identificador as 'Nº Examen', p.dni as DNI, " +
                         "(p.apellido + ' ' + p.nombres) as Paciente, EP.dictFinal AS 'Infantil Inicial', " +
                         "item1 AS Clinico, item37 AS Orina, item38 AS RX, item77 AS ECG, item75 AS EEG, Item72 AS Psico, " +
                         "item68 as Audio, item70 AS Ergo, item71 AS Eco " +
                         "FROM dbo.Consulta c inner join dbo.TipoExamenDePaciente tep " +
                         "on c.id = tep.idConsulta inner join dbo.Paciente p on c.pacienteID = p.id " +
                         "INNER JOIN dbo.ExamenPreventiva EP ON EP.idTipoExamen = tep.id " +
                         "INNER JOIN dbo.EstudiosPorExamen EE ON EE.idTipoExamen = tep.id " +
                         "WHERE c.tipo = 'P' and Convert(date,c.fecha) >= convert(date,'" + FechaInicio.ToShortDateString() + "',105) and Convert(date,c.fecha) " +
                         "<= convert(date,'" + FechaFin.ToShortDateString() + "',105) AND c.identificador > 199 AND c.identificador < 400 " +
                         "ORDER BY c.fecha asc, convert(int,c.identificador) asc";

                dtResultado = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }

            return dtResultado;
        }

        public DataRow DatosBase(DateTime FechaInicio, DateTime FechaFin, bool Movil, bool Clinica, int NroOrden, string idTipoExamen)
        {
            DataTable dtResultado = null;
            DataRow dtRow = null;

            if (Movil == true && Clinica == true)
            {
                string strSQL = "";

                strSQL = "SELECT CONVERT(date, c.fecha) as Fecha, c.identificador as 'Nº Examen', p.dni as DNI, " +
                         "(p.apellido + ' ' + p.nombres) as Paciente, EP.dictFinal AS 'Infantil Inicial', " +
                         "item1 AS Clinico, item37 AS Orina, item38 AS RX, item77 AS ECG, item75 AS EEG, Item72 AS Psico, " +
                         "item68 as Audio, item70 AS Ergo, item71 AS Eco, '" + idTipoExamen + "' AS IdTep " +
                         "FROM dbo.Consulta c inner join dbo.TipoExamenDePaciente tep " +
                         "on c.id = tep.idConsulta inner join dbo.Paciente p on c.pacienteID = p.id " +
                         "INNER JOIN dbo.ExamenPreventiva EP ON EP.idTipoExamen = tep.id " +
                         "INNER JOIN dbo.EstudiosPorExamen EE ON EE.idTipoExamen = tep.id " +
                         "WHERE c.tipo = 'P' and Convert(date,c.fecha) >= convert(date,'" + FechaInicio.ToShortDateString() + "',105) and Convert(date,c.fecha) " +
                         "<= convert(date,'" + FechaFin.ToShortDateString() + "',105) AND c.identificador = " + NroOrden + " AND tep.imp = 1 AND tep.impLab = 1 " +
                         "ORDER BY c.fecha asc, convert(int,c.identificador) asc";

                dtResultado = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }

            if (dtResultado.Rows.Count > 0)
            {
                foreach (DataRow r in dtResultado.Rows)                
                {
                    dtRow = r;
                }
            }

            return dtRow;
        }

        public DataRow DatosBaseLaboral(DateTime FechaInicio, DateTime FechaFin, bool Movil, bool Clinica, string NroOrden, string idTipoExamen, string DNI)
        {
            DataTable dtResultado = null;
            DataRow dtRow = null;

            if (Movil == true && Clinica == true)
            {
                string strSQL = "";

                strSQL = @"select CONVERT(date, c.fecha) as Fecha, c.identificador AS 'Nº Examen', 
                            p.dni,(p.apellido + ' ' + p.nombres) as 'Paciente', '368' as 'Infantil Inicial', 
                            item1 AS Clinico, item37 AS Orina, item38 AS RX, item77 AS ECG, item75 AS EEG, Item72 AS Psico,
                            item68 as Audio, item70 AS Ergo, item71 AS Eco, item2 AS Oto, item74 as Espiro, '" + idTipoExamen + @"' AS IdTep 
                            from dbo.Consulta c inner join dbo.PacienteLaboral p on c.pacienteID = p.id
                                inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta
                                inner join dbo.Especialidad e on tep.idEspecialidad = e.id
                                inner join dbo.ConsultaLaboral cl on tep.id = cl.idTipoExamen
                                INNER JOIN dbo.EstudiosPorExamen EE ON EE.idTipoExamen = tep.id
                            where c.tipo != 'P' and convert(date, c.fecha) >= convert(date, '" + FechaInicio.ToShortDateString() + @"', 105) and convert(date, c.fecha)
                            <= convert(date, '" + FechaFin.ToShortDateString() + @"', 105) AND c.identificador = '" + NroOrden + @"' AND p.dni = '" + DNI + @"' order by CONVERT(VARCHAR(10), c.fecha, 101), convert(int, REPLACE(REPLACE(c.identificador, 'L', ''), 'CO', ''))";

                dtResultado = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }

            if (dtResultado.Rows.Count > 0)
            {
                foreach (DataRow r in dtResultado.Rows)
                {
                    dtRow = r;
                }
            }

            return dtRow;            
        }
    }
}
