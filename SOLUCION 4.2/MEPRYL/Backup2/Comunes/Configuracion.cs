using System;
using System.Xml;
using System.IO;
using System.Web;
using System.Windows.Forms;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace Comunes
{
    public class Conexion
    {
        public string SERVER, DATABASE, UID, PWD, seguridadIntegrada;

        public Conexion(string server, string database, string uid, string pwd, string seguridadIntegrada)
        {
            this.SERVER = server;
            this.DATABASE = database;
            this.UID = uid;
            this.PWD = pwd;
            this.seguridadIntegrada = seguridadIntegrada;
        }
        public Conexion(string server, string database, string uid, string pwd)
        {
            new Conexion(server, database, uid, pwd, "NO");
        }

        public string ToString()
        {
            string cadena = "SERVER=" + this.SERVER + ";DATABASE=" + this.DATABASE;
            if (this.seguridadIntegrada == "SI")
                cadena += ";Integrated Security=SSPI;";
            else
                cadena += ";UID=" + this.UID + ";PWD=" + this.PWD + ";";

            return cadena;

        }
    }

    public class Configuracion
    {
        /// <summary>
        /// Almacena un array con los valores del sistema.
        /// </summary>
        public DataRowCollection parametros;
        public Conexion conexion;
        public Conexion conexion2;
        public static Usuario usuario = null;
        public Sucursal sucursal = null;
        public Maquina maquina = null;
        public string email_errores;

        public Configuracion()
            : this("")
        {
        }
        public Configuracion(bool conectarBaseDatos)
        {
            iniciar("", conectarBaseDatos);
        }

        public Configuracion(string pathConfigXML)
        {
            iniciar(pathConfigXML, true);
        }

        public void iniciar(string pathConfigXML, bool conectarBaseDatos)
        {
            String cadenaConexion = "Cadena conexion: ";
            String cadenaConexion2 = "Cadena conexion2: ";
            try
            {
                string pathXml = "";
                if (pathConfigXML == "")
                    pathXml = System.AppDomain.CurrentDomain.BaseDirectory + "Config.xml";

                else
                    pathXml = pathConfigXML;

                //Carga el archivo XML
                XmlDocument docXml = new XmlDocument();
                XmlTextReader reader = new XmlTextReader(pathXml);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                reader.Read();
                docXml.Load(reader);

                //Toma los valores
                if (conectarBaseDatos)
                {
                    //Conexion blanca
                    conexion = new Conexion("", "", "", "");
                    conexion.SERVER = docXml.SelectSingleNode("./Configuracion/Conexion/SERVER").InnerText;
                    conexion.DATABASE = docXml.SelectSingleNode("./Configuracion/Conexion/DATABASE").InnerText;
                    conexion.UID = docXml.SelectSingleNode("./Configuracion/Conexion/UID").InnerText;
                    conexion.PWD = docXml.SelectSingleNode("./Configuracion/Conexion/PWD").InnerText;
                    //conexion.PWD = Utilidades.desencriptar(conexion.PWD);
                    conexion.seguridadIntegrada = docXml.SelectSingleNode("./Configuracion/Conexion/SeguridadIntegrada").InnerText;

                    cadenaConexion += conexion.ToString() + "   SERVER=" + conexion.SERVER + ". DATABASE=" + conexion.DATABASE + ". UID=" + conexion.UID + ". PWD=" + conexion.PWD;


                    //ManejadorErrores.escribirLog(new Exception(cadenaConexion + "\n" + cadenaConexion2), false);
                    //Conexion negra
                    /*conexion2 = new Conexion("", "", "", "");
                    conexion2.SERVER = conexion.SERVER;
                    conexion2.DATABASE = conexion.DATABASE + "_backup";
                    conexion2.UID = conexion.UID;
                    conexion2.PWD = conexion.PWD;
                    conexion2.seguridadIntegrada = conexion.seguridadIntegrada;*/

                    //Segunda conexion
                    conexion2 = new Conexion("", "", "", "");
                    if (docXml.SelectSingleNode("./Configuracion/Conexion2") != null)
                    {
                        conexion2.SERVER = docXml.SelectSingleNode("./Configuracion/Conexion2/SERVER").InnerText;
                        conexion2.DATABASE = docXml.SelectSingleNode("./Configuracion/Conexion2/DATABASE").InnerText;
                        conexion2.UID = docXml.SelectSingleNode("./Configuracion/Conexion2/UID").InnerText;
                        conexion2.PWD = docXml.SelectSingleNode("./Configuracion/Conexion2/PWD").InnerText;
                        conexion2.PWD = Utilidades.desencriptar(conexion2.PWD);
                        conexion2.seguridadIntegrada = docXml.SelectSingleNode("./Configuracion/Conexion2/SeguridadIntegrada").InnerText;
                    }

                    cadenaConexion2 += conexion2.ToString() + "   SERVER=" + conexion2.SERVER + ". DATABASE=" + conexion2.DATABASE + ". UID=" + conexion2.UID + ". PWD=" + conexion2.PWD;




                    //Carga los parametros del sistema
                    DataSet ds = SqlHelper.ExecuteDataset(this.getConectionString(), CommandType.StoredProcedure, "sp_getAllParametros");
                    //DataSet ds = SqlHelper.ExecuteDataset("SERVER=D7\\SQLEXPRESS;DATABASE=DataSMS;Integrated Security=SSPI;", CommandType.StoredProcedure, "sp_getAllParametros");
                    SQLConnector.conectarABaseDeDatos();
                    //Carga los parametros locales de la maquina
                    DataRow dataRow;
                    foreach (XmlNode nodo in docXml.SelectNodes("./Configuracion/Parametros/Parametro"))
                    {
                        dataRow = ds.Tables[0].NewRow();
                        dataRow["nombreParametro"] = nodo.Attributes["nombreParametro"].InnerText;
                        dataRow["valorTexto"] = nodo.Attributes["valorTexto"].InnerText;
                        dataRow["tipoDato"] = nodo.Attributes["tipoDato"].InnerText;
                        dataRow["etiqueta"] = nodo.Attributes["etiqueta"].InnerText;
                        dataRow["visible"] = nodo.Attributes["visible"].InnerText;
                        dataRow["valorEntero"] = int.Parse(nodo.Attributes["valorEntero"].InnerText);
                        dataRow["valorMoneda"] = double.Parse(nodo.Attributes["valorMoneda"].InnerText);
                        dataRow["valorBoolean"] = bool.Parse(nodo.Attributes["valorBoolean"].InnerText);
                        dataRow["valorUniqueidentifier"] = new System.Guid(nodo.Attributes["valorUniqueidentifier"].InnerText);

                        ds.Tables[0].Rows.Add(dataRow);
                    }

                    parametros = ds.Tables[0].Rows;
                    ds.Dispose();


                    //Primero la sucursal
                    // cargarSucursal();

                    //Luego la maquina
                    //    cargarMaquina();
                }

                //Toma el email de errores
                this.email_errores = docXml.SelectSingleNode("./Configuracion/Errores/Email").InnerText;

                reader.Close();
            }
            catch (Exception ex)
            {

                ManejadorErrores.escribirLog(new Exception(cadenaConexion + "\n" + cadenaConexion2), true);
                ManejadorErrores.escribirLog(ex, true);
            }
        }

        //Carga la sucursal
        private void cargarSucursal()
        {
            try
            {

                SqlDataReader drSucursal = SqlHelper.ExecuteReader(this.getConectionString(), "sp_getSucursalLocal");
                Sucursal suc = new Sucursal();

                if (drSucursal.HasRows)
                {
                    drSucursal.Read();
                    suc.id = new System.Guid(drSucursal["id"].ToString());
                    suc.codigo = drSucursal["codigo"].ToString();
                    suc.nombre = drSucursal["nombre"].ToString();
                    suc.numero = int.Parse(drSucursal["numero"].ToString());

                    this.sucursal = suc;
                }
                drSucursal.Close();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
                ManejadorErrores.escribirLog(new Exception(this.getConectionString()), true);
            }
        }

        //Carga la Maquina
        private void cargarMaquina()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@sucursalID", this.sucursal.id);
                param[0] = new SqlParameter("@nombreMaquina", System.Environment.MachineName);

                SqlDataReader drMaquina = SqlHelper.ExecuteReader(this.getConectionString(), "sp_getMaquinaByNombre", param);

                if (drMaquina.HasRows)
                {
                    Maquina maq = new Maquina();

                    drMaquina.Read();
                    maq.id = new System.Guid(drMaquina["id"].ToString());
                    maq.nombre = System.Environment.MachineName;
                    if (this.sucursal != null)
                        maq.sucursalID = this.sucursal.id;

                    this.maquina = maq;
                }
                else
                    throw (new Exception("Debe registrar el nombre de la maquina en el modulo 'Seguridad'."));

                drMaquina.Close();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
            }
        }


        public string getConectionString()
        {
            string cadena = "Data Source=" + conexion.SERVER + ";Initial Catalog=" + conexion.DATABASE;
            if (conexion.seguridadIntegrada == "SI")
                cadena += ";Integrated Security=SSPI;";
            else
                cadena += ";User ID=" + conexion.UID + ";Password=" + conexion.PWD + ";";

            // GRV - Modificado para multitarea
            cadena += " MultipleActiveResultSets=True;"; 
            //GRV - Fin

            return cadena; // +"Connect Timeout=120;";
        }

        public string getConectionString2()
        {
            string cadena = "SERVER=" + conexion2.SERVER + ";DATABASE=" + conexion2.DATABASE;
            if (conexion2.seguridadIntegrada == "SI")
                cadena += ";Integrated Security=SSPI;";
            else
                cadena += ";UID=" + conexion2.UID + ";PWD=" + conexion2.PWD + ";";
            return cadena;// +"Connect Timeout=120;";
        }

        //Devuelve un parametro, segun el nombre
        public object obtenerParametro(string nombreParametro)
        {
            try
            {
                object resultado = null;
                for (int i = 0; i < parametros.Count; i++)
                {
                    if (parametros[i]["nombreParametro"].ToString() == nombreParametro)
                    {
                        string tipoDato = parametros[i]["tipoDato"].ToString();
                        switch (tipoDato)
                        {
                            case "E":  //Entero
                                resultado = int.Parse(parametros[i]["valorEntero"].ToString());
                                break;
                            case "M":  //Moneda
                                resultado = double.Parse(parametros[i]["valorMoneda"].ToString());
                                break;
                            case "T":  //Texto
                                resultado = parametros[i]["valorTexto"].ToString();
                                break;
                            case "B":  //Boolean
                                resultado = bool.Parse(parametros[i]["valorBoolean"].ToString());
                                break;
                            case "U":  //UniqueIdentifier
                                resultado = new Guid(parametros[i]["valorUniqueidentifier"].ToString());
                                break;
                            case "F":  //Fecha
                                resultado = DateTime.Parse(parametros[i]["valorFecha"].ToString());
                                break;
                        }
                        break;
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //Guarda el valor de un parámetro en la base de datos
        public void guardarParametro(string nombreParametro, object valor)
        {
            try
            {
                for (int i = 0; i < parametros.Count; i++)
                {
                    if (parametros[i]["nombreParametro"].ToString() == nombreParametro)
                    {
                        string update = "";
                        string tipoDato = parametros[i]["tipoDato"].ToString();
                        switch (tipoDato)
                        {
                            case "E":  //Entero
                                {
                                    parametros[i]["valorEntero"] = (int)valor;
                                    update = "valorEntero=" + valor.ToString();
                                    break;
                                }
                            case "M":  //Moneda
                                {
                                    parametros[i]["valorMoneda"] = (double)valor;
                                    update = "valorMoneda=" + valor.ToString();
                                    break;
                                }
                            case "T":  //Texto
                                {
                                    parametros[i]["valorTexto"] = (string)valor;
                                    update = "valorTexto='" + valor.ToString() + "'";
                                    break;
                                }
                            case "B":  //Boolean
                                {
                                    parametros[i]["valorBoolean"] = (bool)valor;
                                    update = "valorBoolean=" + int.Parse(valor.ToString());
                                    break;
                                }
                            case "U":  //UniqueIdentifier
                                {
                                    parametros[i]["valorUniqueidentifier"] = (Guid)valor;
                                    update = "valorUniqueidentifier='" + valor.ToString() + "'";
                                    break;
                                }
                            case "F":  //Fecha
                                {
                                    parametros[i]["valorFecha"] = (DateTime)valor;
                                    update = "valorFecha=" + Utilidades.fechaCanonicaSQL((DateTime)valor);
                                    break;
                                }
                        }

                        SqlHelper.ExecuteNonQuery(this.getConectionString(), CommandType.Text, "UPDATE ts_ParametrosLocales SET " + update + " WHERE nombreParametro='" + nombreParametro + "'");

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
            }
        }


        //Obtiene la version del componente Comunes
        public string obtenerFechaCompilacion()
        {
            return System.IO.File.GetLastWriteTime(System.Windows.Forms.Application.StartupPath + "\\Comunes.dll").ToShortDateString();
        }

        //Es un comnutador que selecciona la conexion: si fue iniciado desde el pendrive, devuelve conexion2, sino devuelve conexion.
        public string seleccionarConexion()
        {
            string con = "";
            if (obtenerParametro("PENDRIVE") != null)
            {
                con = conexion2.ToString();
            }
            else
            {
                con = conexion.ToString();
            }
            return con;
        }
    }
}