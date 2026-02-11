using System;
using System.Xml;
using System.IO;
using System.Web;

using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace Comunes
{
	public struct Conexion 
	{
		public string SERVER, DATABASE, UID, PWD, seguridadIntegrada;

		public Conexion(string server, string database, string uid, string pwd) 
		{
			SERVER = server;
			DATABASE = database;
			UID = uid;
			PWD = pwd;
            seguridadIntegrada = "NO";
		}
	}

	public class Configuracion
	{
		/// <summary>
		/// Almacena un array con los valores del sistema.
		/// </summary>
		public DataRowCollection parametros;
		public Conexion conexion;
		public Usuario usuario = null;
		public Sucursal sucursal = null;
		public Maquina maquina = null;
		public string email_errores;
		public Guid _JornadaVentaID;
		public bool obtenerJornadaVenta = true;

		public Configuracion()
		{
			iniciar("");
		}

		public Configuracion(string pathConfigXML)
		{
			iniciar(pathConfigXML);
		}

		public void iniciar(string pathConfigXML)
		{
			try
			{
				string pathXml = "";
				if (pathConfigXML=="")
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
				conexion = new Conexion("","","","");
				conexion.SERVER = docXml.SelectSingleNode("./Configuracion/Conexion/SERVER").InnerText;
				conexion.DATABASE = docXml.SelectSingleNode("./Configuracion/Conexion/DATABASE").InnerText;
				conexion.UID = docXml.SelectSingleNode("./Configuracion/Conexion/UID").InnerText;
				conexion.PWD = docXml.SelectSingleNode("./Configuracion/Conexion/PWD").InnerText;
				conexion.PWD = Utilidades.desencriptar(conexion.PWD);
                conexion.seguridadIntegrada = docXml.SelectSingleNode("./Configuracion/Conexion/SeguridadIntegrada").InnerText;

                //cadenaConexion += conexion.ToString() + "   SERVER=" + conexion.SERVER + ". DATABASE=" + conexion.DATABASE + ". UID=" + conexion.UID + ". PWD=" + conexion.PWD;

                
				//Sabe si debe o no obtener la jornada de Venta
				if (docXml.SelectSingleNode("./Configuracion/ObtenerJornadaVenta") != null)
					obtenerJornadaVenta = bool.Parse(docXml.SelectSingleNode("./Configuracion/ObtenerJornadaVenta").InnerText);

				//Toma el email de errores
				this.email_errores = docXml.SelectSingleNode("./Configuracion/Errores/Email").InnerText;

				reader.Close();

				//Carga los parametros del sistema
				DataSet ds = SqlHelper.ExecuteDataset(this.getConectionString(), CommandType.StoredProcedure, "sp_getAllParametros");

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
				cargarSucursal();

				//Luego la maquina
				cargarMaquina();

				//Carga la jornada de venta
				if (obtenerJornadaVenta)
					cargarJornadaVenta();
			}
			catch (Exception ex)
			{
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
			
				drSucursal.Read();
				suc.id = new System.Guid(drSucursal["id"].ToString());
				suc.nombre = drSucursal["nombre"].ToString();
				suc.numero = int.Parse(drSucursal["numero"].ToString());

				this.sucursal = suc;

				drSucursal.Close();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
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
					maq.sucursalID = this.sucursal.id;

					this.maquina = maq;
				}
				else
					throw( new Exception("Debe registrar el nombre de la maquina en el modulo 'Ligier - Seguridad'."));

				drMaquina.Close();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
			}
		}

		//Carga la Jornada de Venta
		public void cargarJornadaVenta()
		{
			try
			{
				SqlDataReader drJornada = SqlHelper.ExecuteReader(this.getConectionString(), "sp_getJornadaVentaAbierta");

				//Si no hay registros, no se inicio la caja
				if (!drJornada.HasRows)
				{
					System.Windows.Forms.MessageBox.Show("Primero se debe Iniciar Caja.", "Configuración", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
				}
				else
				{
					//Carga el encabezado
					drJornada.Read();
					this._JornadaVentaID = new Guid(drJornada["id"].ToString());
				}
				drJornada.Close();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
			}
		}

		public string getConectionString()
		{
            string cadena = "SERVER=" + this.conexion.SERVER + ";DATABASE=" + this.conexion.DATABASE;
            if (this.conexion.seguridadIntegrada == "SI")
                cadena += ";Integrated Security=SSPI;";
            else
                cadena += ";UID=" + this.conexion.UID + ";PWD=" + this.conexion.PWD + ";";

            return cadena;
        }

		//Devuelve un parametro, segun el nombre
		public object obtenerParametro(string nombreParametro)
		{
			try
			{

				object resultado = null;
				for (int i=0; i<parametros.Count; i++)
				{
					if (parametros[i]["nombreParametro"].ToString()==nombreParametro)
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
						}
						break;
					}
				}
				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
				return null;
			}
		}

        //Obtiene la version del componente Comunes
        public string obtenerFechaCompilacion()
        {
            return System.IO.File.GetLastWriteTime(System.Windows.Forms.Application.StartupPath + "\\Comunes.dll").ToShortDateString();
        }

        public Guid JornadaVentaID
        {
            get
            {
                this.cargarJornadaVenta();
                return _JornadaVentaID;
            }
            /*set
            {
                someProperty = value;
            }*/
        }
	}
}
