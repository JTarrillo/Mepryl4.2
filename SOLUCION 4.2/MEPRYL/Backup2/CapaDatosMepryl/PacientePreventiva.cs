using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class PacientePreventiva
    {
        public int CodigoRX = 0;

        public PacientePreventiva()
        {
            // Constructor
        }

        public DataTable ListarLigaActiva()
        {
            string strSQL = "";

            strSQL = "SELECT id, codigo, descripcion FROM dbo.Liga WHERE activo = 1 ORDER BY descripcion ASC";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable ListarLigaNoInfantil()
        { 
            string strSQL = "";

            strSQL = "SELECT id, codigo, descripcion FROM dbo.Liga WHERE activo = 1 AND id <> '345FFF9B-45C2-4CD5-87EC-47E944E8236D' ORDER BY descripcion ASC";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable ListaLigaPorCategoria(int intCategoria)
        {
            string strSQL = "";

            strSQL = "SELECT L.id, L.Codigo, L.descripcion FROM " +
                     "dbo.ParametrosPlacas P INNER JOIN dbo.Liga L ON P.ligasIDs = CONVERT(VARCHAR(36), L.id) AND L.activo = 1 " +
                     "WHERE ((P.categoriaInicial >= " + intCategoria + ") AND (" + intCategoria + " >= P.novenaCategoria)) OR (AdmiteMenores = 1 AND (" + intCategoria + " >= P.categoriaInicial)) OR L.codigo = 0 ORDER BY L.descripcion ASC";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public DataTable ListarLigaNoJuvenil()
        {
            string strSQL = "";

            strSQL = "SELECT id, codigo, descripcion FROM dbo.Liga WHERE activo = 1 AND id <> '7B954373-2CC6-4FC0-90C0-B8690862CB7B' ORDER BY descripcion ASC";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);            
        }

        public DataTable ListarLigaNoJuvenilNoInfantil()
        {
            string strSQL = "";
            strSQL = "SELECT id, codigo, descripcion FROM dbo.Liga WHERE activo = 1 AND id <> '7B954373-2CC6-4FC0-90C0-B8690862CB7B' AND id <> '345FFF9B-45C2-4CD5-87EC-47E944E8236D' ORDER BY descripcion ASC";
            return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
        }

        public bool PerteneceLigaInfantil(string IdClub)
        {
            bool blnResultado = false;
            string strSQL = "";

            strSQL = "SELECT descripcion FROM dbo.Club WHERE LigaID = '6D0C0314-57A2-4867-AA48-2888A553FE0F' AND id = '" + IdClub + "'";
            if (SQLConnector.obtenerTablaSegunConsultaString(strSQL).Rows.Count > 0)
                blnResultado = true;

            return blnResultado;
        }

        public bool PerteneceClubAFA(string IdClub)
        {
            bool blnResultado = false;
            string strSQL = "";

            strSQL = "SELECT L.id AS IdLiga, L.descripcion AS Liga FROM dbo.Club C INNER JOIN dbo.Liga L ON L.descripcion LIKE '%A_F_A%' AND L.id = C.LigaID WHERE  C.id = '" + IdClub + "'";
            if (SQLConnector.obtenerTablaSegunConsultaString(strSQL).Rows.Count > 0)
                blnResultado = true;

            return blnResultado;
        }

        public int AnioCategoriaJuvenil(string IdLiga)
        {
            int intAnioCat = 0;
            string strSQL = "";

            strSQL = "SELECT novenaCategoria FROM dbo.ParametrosPlacas WHERE ligasIDs = '" + IdLiga + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                intAnioCat = Convert.ToInt32(dtConsulta.Rows[0].ItemArray[0].ToString());
            }
            return intAnioCat;
        }

        public int AnioCategoriaInfantil(string IdLiga)
        {
            int intAnioCat = 0;
            string strSQL = "";

            strSQL = "SELECT categoriaInicial FROM dbo.ParametrosPlacas WHERE ligasIDs = '" + IdLiga + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                intAnioCat = Convert.ToInt32(dtConsulta.Rows[0].ItemArray[0].ToString());
            }
            return intAnioCat;
        }

        public DateTime FechaUltimoExamen(string strDNI)
        {
            DateTime dtFechaUltimo = new DateTime();
            string strSQL = "";
            DateTime dtPrimerDiaAnio = Convert.ToDateTime("01/01/2015");
            DateTime dtFechaTemp = new DateTime();

            strSQL = "select tep.id as IdTipoExamen, CONVERT(date, c.fecha) as Fecha, p.dni as DNI " +
                      "from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep " +
                      "on c.id = tep.idConsulta inner join dbo.Paciente p on c.pacienteID = p.id " +
                      "WHERE p.dni = '" + strDNI + "' " +
                      "ORDER BY fecha ASC";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            
            if (dtConsulta.Rows.Count > 0)
            {
                for (int i = 0; i < dtConsulta.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dtConsulta.Rows[i].ItemArray[1].ToString()))
                    {
                        dtFechaTemp = Convert.ToDateTime(dtConsulta.Rows[i].ItemArray[1].ToString());

                        if (DateTime.Today.AddDays(-1) >= dtFechaTemp && dtFechaTemp >= dtPrimerDiaAnio)
                        {
                            dtFechaUltimo = dtFechaTemp;
                        }
                    }
                }
            }

            return dtFechaUltimo;
        }

        public DateTime FechaExamenEsteAnio(string strDNI)
        {
            DateTime dtFechaUltimo = new DateTime();
            string strSQL = "";
            DateTime dtPrimerDiaAnio = Convert.ToDateTime("01/01/" + DateTime.Today.Year.ToString());
            DateTime dtFechaTemp = new DateTime();

            strSQL = "select tep.id as IdTipoExamen, CONVERT(date, c.fecha) as Fecha, p.dni as DNI " +
                      "from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep " +
                      "on c.id = tep.idConsulta inner join dbo.Paciente p on c.pacienteID = p.id " +
                      "WHERE p.dni = '" + strDNI + "' " +
                      "ORDER BY fecha ASC";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                for (int i = 0; i < dtConsulta.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dtConsulta.Rows[i].ItemArray[1].ToString()))
                    {
                        dtFechaTemp = Convert.ToDateTime(dtConsulta.Rows[i].ItemArray[1].ToString());

                        if (DateTime.Today.AddDays(-1) >= dtFechaTemp && dtFechaTemp >= dtPrimerDiaAnio)
                        {
                        dtFechaUltimo = dtFechaTemp;
                        }
                    }
                }
            }

            return dtFechaUltimo;
        }
        
        public bool TieneRX(string strIDTipoExamen)
        {
            bool blnResultado = false;
            string strSQL = "";
            int Valor = 0;

            strSQL = "select rxTorax, dictRx from dbo.ExamenPreventiva " +
                     "where idTipoExamen = '" + strIDTipoExamen + "'";

            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {                
                //if (!string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[0].ToString()))
                //    if (int.Parse(dtConsulta.Rows[0].ItemArray[0].ToString()) != 264) // Correponde al codigo interno 3 RXTorax
                //        blnResultado = true;

                ////GRV - Modifcado Dictámen RX (No Efectuado)
                //if (!string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[0].ToString()))
                //    if (int.Parse(dtConsulta.Rows[0].ItemArray[0].ToString()) != 266) // Correponde al codigo interno 5 RXTorax
                //        blnResultado = true;
                //    else
                //        blnResultado = false;
                if (!string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[0].ToString()))
                {
                    Valor = int.Parse(dtConsulta.Rows[0].ItemArray[0].ToString());
                    CodigoRX = Valor;
                    if ((Valor == 264) || (Valor == 266))
                        blnResultado = false;
                    else
                        blnResultado = true;
                }  
            }

            return blnResultado;
        }

        public bool DebeRealizarExamenRX(string strDNI)
        {   
            bool blnResultado = false;
            DateTime dtAnioRX = new DateTime();
            DateTime dtAnioActual = DateTime.Today;
            int intAnioRX = 0;
            int intAnioActual = 0;
            
                        
            string strSQL = "";

            strSQL = "select tep.id as IdTipoExamen, CONVERT(date, c.fecha) as Fecha, p.dni as DNI " +
                      "from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep " +
                      "on c.id = tep.idConsulta inner join dbo.Paciente p on c.pacienteID = p.id AND CONVERT(date, c.fecha) < CONVERT(date,GETDATE())" +
                      "WHERE p.dni = '" + strDNI + "' AND c.tipo = 'P' " +
                      "ORDER BY fecha ASC";
            DataTable dtTabla = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dtTabla.Rows[i].ItemArray[1].ToString()))
                    {
                        dtAnioRX = Convert.ToDateTime(dtTabla.Rows[i].ItemArray[1].ToString());
                        intAnioRX = int.Parse(dtAnioRX.Year.ToString());
                        intAnioActual = int.Parse(dtAnioActual.Year.ToString());

                        if ((intAnioRX + 1) < intAnioActual)
                            blnResultado = true;
                        else
                        {                            
                            if (TieneRX(dtTabla.Rows[i].ItemArray[0].ToString()))
                            {
                                blnResultado = false;
                                
                                //return blnResultado;
                            }
                            else
                                blnResultado = true;

                            if (CategoriaLigaIgualCategoriaPaciente(dtTabla.Rows[i].ItemArray[0].ToString(), strDNI))
                                blnResultado = true;
                            //if (DateTime.Today.Year == Convert.ToDateTime(dtTabla.Rows[i].ItemArray[1].ToString()).Year)
                            if (DateTime.Today.Year == FechaExamenEsteAnio(strDNI).Year)
                                blnResultado = false;
                            if (CodigoTipoExamen(dtTabla.Rows[i].ItemArray[0].ToString()) == 266)
                                blnResultado = true;
                            if (!VerificaRX(ObtenerIDligaPaciente(ObtenerIDclubPaciente(ObtenerIDpaciente(strDNI)))))
                                blnResultado = true;
                        }
                    }
                }
            }
            else
            {
                blnResultado = true;
            }

            return blnResultado;
        }

        public bool CategoriaLigaIgualCategoriaPaciente(string strIdTipoExamenDePaciente, string strDNI)
        {
            bool blnResultado = false;
            int intCatInicialLiga = 0;
            int intCatPaciente = 0;

            //intCatInicialLiga = AnioCategoriaInfantil(ObtenerIdLiga(strIdTipoExamenDePaciente));
            intCatInicialLiga = AnioCategoriaInfantil(ObtenerIDligaPaciente(ObtenerIDclubPaciente(ObtenerIDpaciente(strDNI))));
            intCatPaciente = CategoriaPaciente(strDNI);

            if (intCatInicialLiga == intCatPaciente)
                blnResultado = true;

            return blnResultado;
        }

        public bool VerificaAdmiteMenores(string IdLiga)
        {
            string strSQL = "";
            bool blnEstado = false;

            strSQL = "SELECT VerificaRX, VerificaClub, AdmiteMenores " +
                      "FROM dbo.ParametrosPlacas " +                      
                      "WHERE LigasIDs = '" + IdLiga + "' ";
            DataTable dtTabla = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dtTabla.Rows[i].ItemArray[2].ToString()))
                    {
                        blnEstado = Convert.ToBoolean(dtTabla.Rows[i].ItemArray[2]);
                    }
                }
            }
            return blnEstado;
        }

        public bool VerificaClub(string IdLiga)
        {
            string strSQL = "";
            bool blnEstado = false;

            strSQL = "SELECT VerificaRX, VerificaClub, AdmiteMenores " +
                      "FROM dbo.ParametrosPlacas " +
                      "WHERE LigasIDs = '" + IdLiga + "' ";
            DataTable dtTabla = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dtTabla.Rows[i].ItemArray[1].ToString()))
                    {
                        blnEstado = Convert.ToBoolean(dtTabla.Rows[i].ItemArray[1]);
                    }
                }
            }
            return blnEstado;
        }

        public bool VerificaRX(string IdLiga)
        {
            string strSQL = "";
            bool blnEstado = false;

            strSQL = "SELECT VerificaRX, VerificaClub, AdmiteMenores " +
                      "FROM dbo.ParametrosPlacas " +
                      "WHERE LigasIDs = '" + IdLiga + "' ";
            DataTable dtTabla = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtTabla.Rows.Count > 0)
            {
                for (int i = 0; i < dtTabla.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dtTabla.Rows[i].ItemArray[0].ToString()))
                    {
                        blnEstado = Convert.ToBoolean(dtTabla.Rows[i].ItemArray[0]);
                    }
                }
            }
            return blnEstado;
        }

        public bool LigaEstaActiva(string strIdLiga)
        {
            bool blnEstado = false;
            string strSQL = "";

            strSQL = "SELECT id, codigo, descripcion FROM dbo.Liga WHERE activo = 1 AND id = '" + strIdLiga + "' ORDER BY descripcion ASC";

            DataTable dtTabla = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtTabla.Rows.Count > 0)
            {
                blnEstado = true;
            }

            return blnEstado;
        }

        public DateTime FechaUltimoExamenAFA(string strDNI)
        {
            DateTime dtFechaUltimo = new DateTime();
            dtFechaUltimo = Convert.ToDateTime("01/01/2000");
            string strNombreLiga = "";
            string strSQL = "";

            strSQL = "select tep.id as IdTipoExamen, CONVERT(date, c.fecha) as Fecha, p.dni as DNI " +
                      "from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep " +
                      "on c.id = tep.idConsulta inner join dbo.Paciente p on c.pacienteID = p.id " +
                      "WHERE p.dni = '" + strDNI + "' " +
                      "ORDER BY fecha ASC";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                for (int i = 0; i < dtConsulta.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dtConsulta.Rows[i].ItemArray[1].ToString()))
                    {
                        strNombreLiga = NombreLigaDelClub(dtConsulta.Rows[i].ItemArray[0].ToString());

                        if (strNombreLiga.IndexOf("A.F.A") >= 0)
                        {
                            dtFechaUltimo = Convert.ToDateTime(dtConsulta.Rows[i].ItemArray[1].ToString());
                        }
                    }
                }
            }

            return dtFechaUltimo;
        }

        public DateTime FechaUltimoExamenLIGA(string strDNI)
        {
            DateTime dtFechaUltimo = new DateTime();
            dtFechaUltimo = Convert.ToDateTime("01/01/2000");
            string strNombreLiga = "";
            string strSQL = "";

            strSQL = "select tep.id as IdTipoExamen, CONVERT(date, c.fecha) as Fecha, p.dni as DNI " +
                      "from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep " +
                      "on c.id = tep.idConsulta inner join dbo.Paciente p on c.pacienteID = p.id " +
                      "WHERE p.dni = '" + strDNI + "' " +
                      "ORDER BY fecha ASC";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                for (int i = 0; i < dtConsulta.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dtConsulta.Rows[i].ItemArray[1].ToString()))
                    {
                        strNombreLiga = NombreLigaDelClub(dtConsulta.Rows[i].ItemArray[0].ToString());

                        if (!(strNombreLiga.IndexOf("A.F.A") >= 0))
                        {
                            dtFechaUltimo = Convert.ToDateTime(dtConsulta.Rows[i].ItemArray[1].ToString());
                        }
                    }
                }
            }

            return dtFechaUltimo;
        }

        private string NombreLigaDelClub(string strIdTipoExamenDePaciente)
        {            
            string strSQL = "";
            string strNombreLiga = "";

            strSQL = "select idClub from dbo.clubesPorTipoExamen where idTipoExamen = '" + strIdTipoExamenDePaciente + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strSQL = "SELECT ligaID FROM dbo.club WHERE id = '" + dtConsulta.Rows[0][0].ToString() + "'";
                dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

                if (dtConsulta.Rows.Count > 0)
                {
                    strSQL = "SELECT descripcion from dbo.Liga WHERE id = '" + dtConsulta.Rows[0][0].ToString() + "'";
                    dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

                    strNombreLiga = dtConsulta.Rows[0][0].ToString();
                }
            }

            return strNombreLiga;
        }

        public int ObtenerCodigoTipoExamen(string strDNI)
        {
            int intCodigo = 0;
            string strIDTipoExamen = "";
            string strSQL = "";
            string strTemp = "";

            strSQL = "select tep.id as IdTipoExamen, CONVERT(date, c.fecha) as Fecha, p.dni as DNI " +
                      "from dbo.Consulta c inner join dbo.TipoExamenDePaciente tep " +
                      "on c.id = tep.idConsulta inner join dbo.Paciente p on c.pacienteID = p.id " +
                      "WHERE p.dni = '" + strDNI + "' " +
                      "ORDER BY fecha ASC";
            
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                for (int i = 0; i < dtConsulta.Rows.Count; i++)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(dtConsulta.Rows[i].ItemArray[0].ToString()))
                        {
                            strIDTipoExamen = dtConsulta.Rows[i].ItemArray[0].ToString();

                            strSQL = "select rxTorax from dbo.ExamenPreventiva " +
                            "where idTipoExamen = '" + strIDTipoExamen + "'";

                            DataTable dtConsulta2 = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

                            strTemp = dtConsulta2.Rows[0].ItemArray[0].ToString();

                            if (!string.IsNullOrEmpty(dtConsulta2.Rows[0].ItemArray[0].ToString()))
                            {
                                intCodigo = int.Parse(dtConsulta2.Rows[0].ItemArray[0].ToString());

                                if ((intCodigo == 266))
                                {
                                    return intCodigo;
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        return intCodigo;
                    }                    
                }
            }

            return intCodigo;
        }

        public int CodigoTipoExamen(string strIDTipoExamen)
        {
            int intCodigo = 0;            
            string strSQL = "";

            strSQL = "select rxTorax from dbo.ExamenPreventiva " +
            "where idTipoExamen = '" + strIDTipoExamen + "'";

            DataTable dtConsulta2 = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta2.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtConsulta2.Rows[0].ItemArray[0].ToString()))
                {
                    intCodigo = int.Parse(dtConsulta2.Rows[0].ItemArray[0].ToString());

                    if ((intCodigo == 266))
                    {
                        return intCodigo;
                    }
                }
            }
            
            return intCodigo;
        }

        public string ObtenerIdLiga(string strIdTipoExamenDePaciente)
        {            
            string strSQL = "";
            string strIdLiga = "";

            strSQL = "select idClub from dbo.clubesPorTipoExamen where idTipoExamen = '" + strIdTipoExamenDePaciente + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strSQL = "SELECT ligaID FROM dbo.club WHERE id = '" + dtConsulta.Rows[0][0].ToString() + "'";
                dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

                strIdLiga = dtConsulta.Rows[0][0].ToString();
            }

            return strIdLiga;
        }

        public int CategoriaPaciente(string strDNI)
        {
            string strSQL = "";
            DateTime dtFechaUltimo;
            int intValor = 0;

            strSQL = "SELECT TOP 1 fechaNacimiento FROM dbo.Paciente WHERE dni = '" + strDNI + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                dtFechaUltimo = Convert.ToDateTime(dtConsulta.Rows[0][0].ToString());
                intValor = int.Parse(dtFechaUltimo.Year.ToString());
            }

            return intValor;
        }

        public string ObtenerIDpaciente(string strDNI)
        {
            string strID = "";  
            string strSQL = "";

            strSQL = "SELECT TOP 1 id FROM dbo.Paciente WHERE dni = '" + strDNI + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strID = dtConsulta.Rows[0][0].ToString();
            }

            return strID;
        }

        public string ObtenerIDclubPaciente(string strIDPaciente)
        {
            string strIDClub = "";
            string strSQL = "";

            strSQL = "SELECT TOP 5 club FROM dbo.clubesPorPaciente WHERE paciente = '" + strIDPaciente + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            
            for (int i = 0; i < dtConsulta.Rows.Count; i++)
            {
                if (dtConsulta.Rows.Count > 0)
                {
                    if (ClubPerteneceAFA(ObtenerIDligaPaciente(dtConsulta.Rows[i][0].ToString())))
                    {
                        strIDClub = dtConsulta.Rows[i][0].ToString();
                        break;
                    }
                    else
                    {
                        strIDClub = dtConsulta.Rows[i][0].ToString();
                    }                    
                }
            }

            return strIDClub;
        }

        public bool ClubPerteneceAFA(string strIdLiga)
        {
            bool blnAFA = false;
            string strSQL = "";

            strSQL = "SELECT TOP 1 descripcion FROM dbo.Liga WHERE id = '" + strIdLiga + "' AND descripcion LIKE '%A.F.A.%'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                blnAFA = true;
            }

            return blnAFA;
        }

        public string ObtenerIDligaPaciente(string strIDClub)
        {
            string strIDLiga = "";
            string strSQL = "";

            strSQL = "SELECT TOP 1 LigaID FROM dbo.club WHERE id = '" + strIDClub + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strIDLiga = dtConsulta.Rows[0][0].ToString();
            }

            return strIDLiga;
        }

        public string ObtenerDNIpaciente(string strIdPaciente)
        {
            string strID = "";
            string strSQL = "";

            strSQL = "SELECT TOP 1 codigo FROM dbo.Paciente WHERE id = '" + strIdPaciente + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strID = dtConsulta.Rows[0][0].ToString();
            }

            return strID;
        }

        public bool ExistePaciente(string strDNI)
        {
            bool blnRetorno = false;
            string strSQL = "";

            strSQL = "SELECT TOP 1 id FROM dbo.Paciente WHERE codigo = '" + strDNI + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                blnRetorno = true;
            }

            return blnRetorno;
        }

        public string VerMail(string strDNI)
        {
            string strEmail = "";
            string strSQL = "";
            
            strSQL = "SELECT Email FROM dbo.Paciente WHERE codigo = '" + strDNI + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            if (dtConsulta.Rows.Count > 0)
            {
                strEmail = dtConsulta.Rows[0][0].ToString();
            }

            return strEmail;
        }

        public bool ActualizarMail(string strDNI, string strMail)
        {
            string strSQL = "";
            bool blnRetorno = false;

            strSQL = "UPDATE dbo.Paciente " +
                     "SET Email = '" + strMail + "' " +
                     "WHERE codigo = '" + strDNI + "'";
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            return blnRetorno;
        }

        public bool ActualizaPacienteDeImportacion(DataTable dtDatos)
        {
            // GRV - Modificado
            return true;
        }

        
    }
}
