using System;
using System.Data.SqlClient;

namespace Comunes
{
	/// <summary>
	/// Summary description for Suscripcion.
	/// </summary>
	public class Suscripcion
	{
		public Guid id;
		public Guid serverRemotoID;
		public Guid serverLocalID;
		public int suscripcionTipoID = 0;
		public string SuscripcionNombre = "";
		public string web_service_url = "";
		public string ServidorRemoto = "";
		public string ServidorLocal = "";
		public string tipo = "";
		public string SuscripcionTipo = "";
		public Guid ultimaSincronizacionID;
		public string UltSincTipoSincronizacion = "";
		public string UltSincRespuestaServidor = "";
		public DateTime UltSincFecha;
		public string UltSincSincronizacionExistosa = "";
		public Guid ultimaSincronizacionExitosaID;
		public string UltSinExitTipoSincronizacion = "";
		public string UltSincExitRespuestaServidor = "";
		public DateTime UltSincExitFecha;
		public string UltSincExitSincronizacionExitosa = "";

		public Suscripcion()
		{
		}
		
		public Suscripcion(SqlDataReader drSuscripcion)
		{
			this.id = new Guid(drSuscripcion["id"].ToString());	
			this.serverRemotoID = drSuscripcion["serverRemotoID"].ToString()!="" ? new Guid(drSuscripcion["serverRemotoID"].ToString()) : new Guid(Utilidades.ID_VACIO);
			this.serverLocalID = drSuscripcion["serverLocalID"].ToString()!="" ? new Guid(drSuscripcion["serverLocalID"].ToString()) : new Guid(Utilidades.ID_VACIO);
			this.suscripcionTipoID = (int)drSuscripcion["suscripcionTipoID"];
			this.SuscripcionNombre = drSuscripcion["Suscripcion"].ToString();
			this.web_service_url = drSuscripcion["web_service_url"].ToString();
			this.ServidorRemoto = drSuscripcion["Servidor Remoto"].ToString();
			this.ServidorLocal = drSuscripcion["Servidor Local"].ToString();
			this.tipo = drSuscripcion["tipo"].ToString();
			this.SuscripcionTipo = drSuscripcion["Suscripcion Tipo"].ToString();
			this.ultimaSincronizacionExitosaID = drSuscripcion["ultimaSincronizacionExitosaID"].ToString()!="" ? new Guid(drSuscripcion["ultimaSincronizacionExitosaID"].ToString()) : new Guid(Utilidades.ID_VACIO);
			this.ultimaSincronizacionID = drSuscripcion["ultimaSincronizacionID"].ToString()!="" ? new Guid(drSuscripcion["ultimaSincronizacionID"].ToString()) : new Guid(Utilidades.ID_VACIO);
			this.UltSincTipoSincronizacion = drSuscripcion["Ult.Sinc. tipoSincronizacion"].ToString();
			this.UltSincRespuestaServidor = drSuscripcion["Ult.Sinc. respuestaServidor"].ToString();
			this.UltSincFecha = drSuscripcion["Ult.Sinc. fecha"].ToString()!="" ? (DateTime)drSuscripcion["Ult.Sinc. fecha"] : DateTime.Now;
			this.UltSincSincronizacionExistosa = drSuscripcion["Ult.Sinc. sincronizacionExitosa"].ToString();
			this.UltSinExitTipoSincronizacion = drSuscripcion["Ult.Sinc.Exit. tipoSincronizacion"].ToString();
			this.UltSincExitRespuestaServidor = drSuscripcion["Ult.Sinc.Exit. respuestaServidor"].ToString();
			this.UltSincExitFecha = drSuscripcion["Ult.Sinc.Exit. fecha"].ToString()!="" ? (DateTime)drSuscripcion["Ult.Sinc.Exit. fecha"] : DateTime.Now;
			this.UltSincExitSincronizacionExitosa = drSuscripcion["Ult.Sinc.Exit. sincronizacionExitosa"].ToString();
		}
	}
}
