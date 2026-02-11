using System;
using System.Xml.Serialization;
using System.IO;

namespace Comunes
{
	/// <summary>
	/// Summary description for PaqueteSincronizacion.
	/// </summary>
	[Serializable]
	public class PaqueteSincronizacion
	{
		public Guid ID = new Guid();
		public byte[] archivoZIP = null;
		public string pathOrigen = null;
		public DateTime fechaEnvio;
		public Guid servidorOrigenID = new Guid();
		public Guid sucursalOrigenID = new Guid();
		public bool solicitarRespuesta = false;

		public PaqueteSincronizacion()
		{}
		public PaqueteSincronizacion(Guid id, string pathOrigen, DateTime fechaEnvio, Guid servidorOrigenID, Guid sucursalOrigenID, bool solicitarRespuesta)
		{
			this.ID = id;
			this.fechaEnvio = fechaEnvio;
			this.servidorOrigenID = servidorOrigenID;
			this.sucursalOrigenID = sucursalOrigenID;
			this.solicitarRespuesta = solicitarRespuesta;

			cargarArchivoZIP(pathOrigen);
		}

		//Carga en memoria un archivo desde un path
		public bool cargarArchivoZIP(string pathOrigen)
		{
			try 
			{
				FileStream fs = new FileStream(pathOrigen, FileMode.Open, FileAccess.Read);
				this.archivoZIP = new byte[fs.Length];
				BinaryReader bReader = new BinaryReader(fs);
				bReader.Read(this.archivoZIP, 0, this.archivoZIP.Length);

				bReader.Close();
				fs.Close();
				return true;
			}
			catch (Exception e)
			{
				throw new Exception("Error en PaqueteSincronizacion.cargarArchivoZIP().", e);
			}
		}

		//Escribe el archivo de memoria en un path especificado.
		public string guardarArchivoZIP(string pathDestino)
		{
			string nombreDestino = "";
			try 
			{
				nombreDestino = "\\" + this.ID.ToString() + ".zip";
				FileStream fs = new FileStream(pathDestino + nombreDestino, FileMode.CreateNew);
				BinaryWriter bWriter = new BinaryWriter(fs);
				bWriter.Write(this.archivoZIP);
				bWriter.Flush();

				bWriter.Close();
				fs.Close();

				return "OK";
			}
			catch (Exception e)
			{
				//throw new Exception("Error en PaqueteSincronizacion.guardarArchivoZIP().", e);
				return "ERROR en PaqueteSincronizacion.guardarArchivoZIP(). Archivo: " + pathDestino + nombreDestino + ", Mensaje: " + e.Message;
			}
		}
	}
}
