using System;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace Comunes
{
	/// <summary>
	/// Summary description for MercaderiaEnTransito.
	/// </summary>
	public class MercaderiaEnTransito
	{
		private Configuracion configuracion = null;
		public MercaderiaEnTransito(Configuracion config)
		{
			this.configuracion = config;
		}
	
		//Despacha mercaderia, crea una nueva instancia en la base de datos
		public void despachada(string remitoID, string observaciones)
		{
			ejecutarProcedimiento("sp_NuevaMercaderiaEnTransito", remitoID, "DESPACHADA", observaciones);
		}

		//Mercaderia Entregada
		public void entregada(string remitoID, string observaciones)
		{
			ejecutarProcedimiento("sp_MercaderiaEnTransitoCambioEstado", remitoID, "ENTREGADA", observaciones);
		}

		//Mercaderia Devuelta
		public void devuelta(string remitoID, string observaciones)
		{
			ejecutarProcedimiento("sp_MercaderiaEnTransitoCambioEstado", remitoID, "DEVUELTA", observaciones);
		}

		//Mercaderia Devuelta, cliente notificado
		public void clienteNotificado(string remitoID, string observaciones)
		{
			ejecutarProcedimiento("sp_MercaderiaEnTransitoCambioEstado", remitoID, "CLIENTE_NOTIFICADO", observaciones);
		}

		//Ejecuta Procedimiento
		private void ejecutarProcedimiento(string sp, string remitoID, string estado, string observaciones)
		{
			try
			{

				SqlParameter[] param = new SqlParameter[3];
				param[0] = new SqlParameter("@remitoID", new System.Guid(remitoID));
				param[1] = new SqlParameter("@estado", estado);
				param[2] = new SqlParameter("@observaciones", observaciones);
				SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), sp, param);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
	}
}
