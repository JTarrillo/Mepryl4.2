using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for Sincronizacion.
	/// </summary>
	public class Sincronizacion
	{
		public Configuracion configuracion;
		public Guid id;
		public string archivoZIP = "";
		public string tipoSincronizacion = "";
		public string respuestaServidor = "";
		public DateTime fecha;
		public string sincronizacionExitosa = "";
		public Guid suscripcionID;

		public Sincronizacion()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public Sincronizacion(Configuracion config, Guid id, string archivoZIP, string tipoSincronizacion, string respuestaServidor, DateTime fecha, string sincronizacionExitosa, Guid suscripcionID)
		{
			this.configuracion = config;

			this.id = id;
			this.archivoZIP = archivoZIP;
			this.tipoSincronizacion = tipoSincronizacion;
			this.respuestaServidor = respuestaServidor;
			this.fecha = fecha;
			this.sincronizacionExitosa = sincronizacionExitosa;
			this.suscripcionID = suscripcionID;
		}

		public void guardarComoNueva()
		{
			SqlParameter[] param = new SqlParameter[7];
			param[0] = new SqlParameter("@id", this.id);
			param[1] = new SqlParameter("@archivoZIP", this.archivoZIP);
			param[2] = new SqlParameter("@tipoSincronizacion", this.tipoSincronizacion);
			param[3] = new SqlParameter("@respuestaServidor", this.respuestaServidor);
			param[4] = new SqlParameter("@fecha", this.fecha);
			param[5] = new SqlParameter("@sincronizacionExitosa", this.sincronizacionExitosa);
			param[6] = new SqlParameter("@suscripcionID", this.suscripcionID);

			SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_sync_NuevaSincronizacion", param);
		}
	}
}
