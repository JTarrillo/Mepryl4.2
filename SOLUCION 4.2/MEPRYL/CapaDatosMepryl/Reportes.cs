using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class Reportes
    {
        public Reportes()
        {
            // Constructor
        }

        public DataTable ReporteEspirometria(string strIdExamenLaboral, string strDNI)
        {
            string strSQL = "";

            strSQL = @"DECLARE @talla VARCHAR(10),
                        @peso VARCHAR(10),
                        @paciente VARCHAR(30),
                        @Nacimiento VARCHAR(10),
                        @informe VARCHAR(255)
                        SELECT @talla = talla, @peso = peso, @informe = espiro FROM dbo.ExamenLaboral WHERE id = '" + strIdExamenLaboral + @"'
                        SELECT @paciente = apellido + ' ' + nombres, @Nacimiento = Convert(date,fechaNacimiento,105) FROM dbo.PacienteLaboral WHERE dni = '" + strDNI + @"'
                        SELECT @paciente, @talla, @peso, @Nacimiento, @informe";
            
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            
            return dtConsulta;
        }

        public DataTable AudiometriaEstablcerDatos(DateTime dtFecha, string strNroOrden)
        {
            DataTable dt = null;
            string strSQL = "";
            //strSQL = "SELECT DA.* , Apellido + ' ' + Nombre as 'NombreApellido', EL.Revisado " + 
            //         "FROM dbo.DatosAudiometria DA " +
            //         "INNER JOIN dbo.ExamenLaboral EL ON EL.id = DA.IdExamenLaboral " +
            //         "WHERE fecha = '" + dtFecha.ToShortDateString() + "'  AND NroOrden = '" + strNroOrden + "'";

            strSQL = @"SELECT DA.* , Apellido + ' ' + Nombre as 'NombreApellido', DA.Revisado 
                    FROM dbo.DatosAudiometria DA
                    INNER JOIN dbo.TipoExamenDePaciente EL ON EL.id = DA.idTipoExamen
                    WHERE fecha = '" + dtFecha.ToShortDateString() + "'  AND NroOrden = '" + strNroOrden + "'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public DataTable AudiometriaEstablcerDatos(DateTime dtFecha)
        {
            DataTable dt = null;
            string strSQL = "";

            //strSQL = @"select c.fecha, c.identificador AS 'NroOrden', p.dni, c.identificador + ' - ' + p.Apellido + ' ' + p.nombres as 'NombreApellido', EP.razonSocial as 'Empresa', EL.audio AS 'Diagnostico',
            //      EL.Revisado, EL.Id AS 'IdExamenLaboral', EL.Usuario, p.Apellido + ' ' + p.nombres as 'Paciente', c.nroOrden as 'Ingreso'
            //      from dbo.Consulta c inner join dbo.PacienteLaboral p on c.pacienteID = p.id
            //      inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta
            //      inner join dbo.Especialidad e on tep.idEspecialidad = e.id
            //      inner join dbo.ConsultaLaboral cl on tep.id = cl.idTipoExamen
            //      INNER JOIN dbo.ExamenLaboral EL on EL.id = cl.idExamenLaboral
            //      INNER JOIN dbo.empresaPorTipoDeExamen EPTE on EPTE.idtipoExamen = cl.idTipoExamen
            //      INNER JOIN dbo.Empresa EP on EP.id = EPTE.idEmpresa
            //      INNER JOIN dbo.EstudiosPorExamen epe ON tep.id = epe.idTipoExamen
            //    where c.tipo != 'P' and c.tipo = 'L' and convert(date, c.fecha) >= '" + dtFecha.ToShortDateString() + @"' and convert(date, c.fecha)
            //    <= '" + dtFecha.ToShortDateString() + @"' AND epe.item68 = '1' order by CONVERT(VARCHAR(10), c.fecha, 101), convert(int, REPLACE(REPLACE(c.identificador, 'L', ''), 'CO', ''))";

            strSQL = @"select c.nroOrden as 'Ingreso', c.identificador as 'NroOrden', VCP.Apellidos + ' ' + VCP.Nombres as Paciente, VCP.TipoPaciente, 
	                      VCP.Apellidos, VCP.Nombres, te.id as IdTipoExamen
                    from Consulta c
                    inner
                    join dbo.TipoExamenDePaciente te on te.idConsulta = c.id
                    inner
                    join dbo.Especialidad e on te.idEspecialidad = e.id
                    INNER JOIN dbo.EstudiosPorExamen EPE ON EPE.idTipoExamen = te.id
                    INNER JOIN dbo.vwConsultarPacientes VCP ON VCP.id = c.pacienteID
                    WHERE convert(Date, c.fecha) = '" + dtFecha.ToShortDateString() + @"' and c.valido = '1' and c.nroOrden != '0' and c.tipo != 'V' and EPE.item68 = '1'
                    order by c.nroOrden";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public DataTable AudiometriaApellidoNombre(string strDni)
        {
            DataTable dt = null;
            string strSQL = "";
            strSQL = "SELECT top 1 apellido, nombres FROM dbo.PacienteLaboral WHERE dni = '" + strDni + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return dt;
        }

        public DataTable AudiometriaDiagnostico(DateTime dtfecha, string strNroOrden)
        {
            DataTable dt = null;
            string strSQL = "";

            //strSQL = @"select c.fecha, c.identificador AS 'NroOrden', p.dni, p.Apellido, p.nombres as 'Nombre', EP.razonSocial as 'Empresa', EL.audio AS 'Diagnostico',
            //            OidoIzq0, OidoIzq32, OidoIzq64, DL.OidoIzq128, OidoIzq256, OidoIzq512, OidoIzq1024, OidoIzq2048, OidoIzq4096, OidoIzq8192, OidoIzq16334, OidoIzq20000,
            //            OidoDer0, OidoDer32, OidoDer64, OidoDer128, OidoDer256, OidoDer512, OidoDer1024, OidoDer2048, OidoDer4096, OidoDer8192, OidoDer16334, OidoDer20000, EL.Revisado, EL.Id AS 'IdExamenLaboral', EL.Usuario
            //            from dbo.Consulta c inner join dbo.PacienteLaboral p on c.pacienteID = p.id
            //            inner join dbo.TipoExamenDePaciente tep on c.id = tep.idConsulta
            //            inner join dbo.Especialidad e on tep.idEspecialidad = e.id
            //            inner join dbo.ConsultaLaboral cl on tep.id = cl.idTipoExamen
            //            INNER JOIN dbo.ExamenLaboral EL on EL.id = cl.idExamenLaboral
            //            INNER JOIN dbo.empresaPorTipoDeExamen EPTE on EPTE.idtipoExamen = cl.idTipoExamen
            //            INNER JOIN dbo.Empresa EP on EP.id = EPTE.idEmpresa
            //            LEFT OUTER JOIN dbo.DatosAudiometria DL on c.identificador = DL.NroOrden AND convert(date,c.fecha) = convert(date,DL.Fecha)
            //        where c.tipo != 'P' and c.tipo = 'L' and convert(date, c.fecha) >= '" + dtfecha.ToShortDateString() + @"' and convert(date, c.fecha)
            //        <= '" + dtfecha.ToShortDateString() + @"' AND c.identificador = '" + strNroOrden + @"'  order by CONVERT(VARCHAR(10), c.fecha, 101), convert(int, REPLACE(REPLACE(c.identificador, 'L', ''), 'CO', ''))";

            strSQL = @"select c.fecha, c.identificador as 'NroOrden', VCP.dni, VCP.Apellidos as 'Apellido', VCP.Nombres as 'Nombre', 
                        ECTE.NombreEmpresaClub as 'Empresa', DL.Diagnostico,  
	                    OidoIzq0, OidoIzq32, OidoIzq64, DL.OidoIzq128, OidoIzq256, OidoIzq512, OidoIzq1024, OidoIzq2048, OidoIzq4096, OidoIzq8192, OidoIzq16334, OidoIzq20000,
                        OidoDer0, OidoDer32, OidoDer64, OidoDer128, OidoDer256, OidoDer512, OidoDer1024, OidoDer2048, OidoDer4096, OidoDer8192, OidoDer16334, OidoDer20000,
	                    DL.Revisado, te.id as IdTipoExamen, DL.Usuario, VCP.TipoPaciente
                    from Consulta c
                    inner join dbo.TipoExamenDePaciente te on te.idConsulta = c.id
                    inner join dbo.Especialidad e on te.idEspecialidad = e.id
                    INNER JOIN dbo.EstudiosPorExamen EPE ON EPE.idTipoExamen = te.id
                    INNER JOIN dbo.vwConsultarPacientes VCP ON VCP.id = c.pacienteID
                    INNER JOIN dbo.vwConsultarEmpresaClubPorTipoExamen ECTE ON te.id = ECTE.idTipoExamen
                    LEFT OUTER JOIN dbo.DatosAudiometria DL on c.identificador = DL.NroOrden AND convert(date, c.fecha) = convert(date, DL.Fecha)
                    WHERE convert(Date, c.fecha) = '" + dtfecha.ToShortDateString() + @"' and c.valido = '1' and c.nroOrden != '0' and c.tipo != 'V' and EPE.item68 = '1' AND c.identificador = '" + strNroOrden + @"'
                    order by c.nroOrden";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            
            return dt;
        }

        public bool InsertarDatos(List<string> strDatos)
        {
            bool blnRetorno = false;
            string strSQL = "";
            bool blnActrualiza = false;

            if (strDatos.Count > 0)
            {
                if (AudiometriaEstablcerDatos(Convert.ToDateTime(strDatos[1]), strDatos[0]).Rows.Count > 0)
                {
                    blnActrualiza = true;
                }

                if (!blnActrualiza)
                {
                    Console.WriteLine(strDatos[30]);
                    Console.WriteLine(strDatos[31]);
                    strSQL = "INSERT INTO dbo.DatosAudiometria(NroOrden, Fecha, Apellido, Nombre, Empresa, Diagnostico, OidoIzq0, OidoIzq32, OidoIzq64, OidoIzq128, OidoIzq256, OidoIzq512, OidoIzq1024, OidoIzq2048, OidoIzq4096, OidoIzq8192, OidoIzq16334, OidoIzq20000, OidoDer0, OidoDer32, OidoDer64, OidoDer128, OidoDer256, OidoDer512, OidoDer1024, OidoDer2048, OidoDer4096, OidoDer8192, OidoDer16334, OidoDer20000, idTipoExamen, TipoPaciente) " +
                        "VALUES " +
                        "('" + strDatos[0] + "', " +
                        "'" + Convert.ToDateTime(strDatos[1]).ToString("yyyyMMdd") + "', " +
                        "'" + strDatos[2] + "', " +
                        "'" + strDatos[3] + "', " +
                        "'" + strDatos[4] + "', " +
                        "'" + strDatos[5] + "', " +
                        strDatos[6] + ", " +
                        strDatos[7] + ", " +
                        strDatos[8] + ", " +
                        strDatos[9] + ", " +
                        strDatos[10] + ", " +
                        strDatos[11] + ", " +
                        strDatos[12] + ", " +
                        strDatos[13] + ", " +
                        strDatos[14] + ", " +
                        strDatos[15] + ", " +
                        strDatos[16] + ", " +
                        strDatos[17] + ", " +
                        strDatos[18] + ", " +
                        strDatos[19] + ", " +
                        strDatos[20] + ", " +
                        strDatos[21] + ", " +
                        strDatos[22] + ", " +
                        strDatos[23] + ", " +
                        strDatos[24] + ", " +
                        strDatos[25] + ", " +
                        strDatos[26] + ", " +
                        strDatos[27] + ", " +
                        strDatos[28] + ", " +
                        strDatos[29] + ", '" +
                        strDatos[30] + "', '" +
                        strDatos[31] + "')";    
                }
                else
                {
                    strSQL = "UPDATE dbo.DatosAudiometria " +
                        "SET " +
                        "Apellido = '" + strDatos[2] + "', " +
                        "Nombre = '" + strDatos[3] + "', " +
                        "Empresa = '" + strDatos[4] + "', " +
                        "Diagnostico = '" + strDatos[5] + "', " +
                        "OidoIzq0 = " + strDatos[6] + ", " +
                        "OidoIzq32 = " + strDatos[7] + ", " +
                        "OidoIzq64 = " + strDatos[8] + ", " +
                        "OidoIzq128 = " + strDatos[9] + ", " +
                        "OidoIzq256 = " + strDatos[10] + ", " +
                        "OidoIzq512 = " + strDatos[11] + ", " +
                        "OidoIzq1024 = " + strDatos[12] + ", " +
                        "OidoIzq2048 = " + strDatos[13] + ", " +
                        "OidoIzq4096 = " + strDatos[14] + ", " +
                        "OidoIzq8192 = " + strDatos[15] + ", " +
                        "OidoIzq16334 = " + strDatos[16] + ", " +
                        "OidoIzq20000 = " + strDatos[17] + ", " +
                        "OidoDer0 = " + strDatos[18] + ", " +
                        "OidoDer32 = " + strDatos[19] + ", " +
                        "OidoDer64 = " + strDatos[20] + ", " +
                        "OidoDer128 = " + strDatos[21] + ", " +
                        "OidoDer256 = " + strDatos[22] + ", " +
                        "OidoDer512 = " + strDatos[23] + ", " +
                        "OidoDer1024 = " + strDatos[24] + ", " +
                        "OidoDer2048 = " + strDatos[25] + ", " +
                        "OidoDer4096 = " + strDatos[26] + ", " +
                        "OidoDer8192 = " + strDatos[27] + ", " +
                        "OidoDer16334 = " + strDatos[28] + ", " +
                        "OidoDer20000 = " + strDatos[29] + ", " +
                        "idTipoExamen = '" + strDatos[30] + "' "  +
                        "WHERE Fecha = '" + Convert.ToDateTime(strDatos[1]).ToString("yyyyMMdd") + "' AND NroOrden = '" + strDatos[0] + "'";
                }

                SQLConnector.obtenerTablaSegunConsultaString(strSQL);

                blnRetorno = true;                
            }

            return blnRetorno;
        }

        public bool ActualizaRevisado(string IdTipoExamen, string Usuario, bool Estado, string strDicAudio, string strTipoPaciente)
        {
            byte blnRevisado = 0;
            bool blnRetorno = false;
            string strSQL = "";
            string IdExamenLaboral = "";
            DataTable dt;

            if (Estado == true)
                blnRevisado = 1;

            // Si es laboral
            strSQL = @"SELECT CL.idExamenLaboral FROM dbo.TipoExamenDePaciente TEP 
                    INNER JOIN dbo.ConsultaLaboral CL ON CL.idTipoExamen = TEP.id
                    WHERE CL.idTipoExamen = '" + IdTipoExamen + "'";
            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    IdExamenLaboral = fila["idExamenLaboral"].ToString();
                }

                strSQL = "UPDATE dbo.ExamenLaboral " +
                         "SET " +
                         "audio = '" + strDicAudio + "' " +
                         "WHERE id = '" + IdExamenLaboral + "'";
                SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            }

                strSQL = "update dbo.DatosAudiometria " +
                     "SET diagnostico = '" + strDicAudio + "' ," +
                     "Usuario = '" + Usuario + "', " +
                     "Revisado = " + blnRevisado + " " +
                     "WHERE idTipoExamen = '" + IdTipoExamen + "'";
            SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            blnRetorno = true;

            return blnRetorno;
        }

        public bool VerificaEstudioAudioCargado(string strIdExamenLaboral)
        {
            bool blnResultado = false;
            string strSQL = "";
            DataTable dt = null;

            //strSQL = @"SELECT DA.NroOrden, DA.Fecha, EL.Revisado, EL.Usuario FROM dbo.ExamenLaboral EL
            //        INNER JOIN dbo.DatosAudiometria DA ON DA.idExamenLaboral =  EL.id
            //        WHERE EL.id = '"+ strIdExamenLaboral + "' AND DA.idExamenLaboral = '"+ strIdExamenLaboral + "'";

            strSQL = @"SELECT DA.NroOrden, DA.Fecha, DA.Revisado, DA.Usuario 
                    FROM dbo.TipoExamenDePaciente EL
                    INNER JOIN dbo.DatosAudiometria DA ON DA.idTipoExamen = EL.id
                    WHERE EL.id = '" + strIdExamenLaboral + "' AND DA.idTipoExamen = '" + strIdExamenLaboral + "'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if(dt.Rows.Count > 0)
            {
                blnResultado = true;
            }

            return blnResultado;
        }

        public bool EstudioRevisado(string strIdExamenLaboral)
        {
            bool blnResultado = false;
            string strSQL = "";
            DataTable dt = null;

            //strSQL = @"SELECT * FROM dbo.ExamenLaboral WHERE Revisado = 1 AND id = '" + strIdExamenLaboral + "'";
            strSQL = @"SELECT * FROM dbo.DatosAudiometria WHERE Revisado = 1 AND idTipoExamen = '" + strIdExamenLaboral + "'";

            dt = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dt.Rows.Count > 0)
            {
                blnResultado = true;
            }

            return blnResultado;
        }
    }
}
