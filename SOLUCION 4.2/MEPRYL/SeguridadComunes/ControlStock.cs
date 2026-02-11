using System;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace Comunes
{
	/// <summary>
	/// Summary description for ControlStock.
	/// </summary>
	public class ControlStock
	{
		private Configuracion configuracion = null;
		public ControlStock(Configuracion config)
		{
			this.configuracion = config;
		}

		//Agrega a stock
		public void aumentarExistencia(DataTable tabla, string campoID, string campoCantidad)
		{
			actualizarStock(tabla, campoID, campoCantidad, "sp_StockAumentarExistencia");
		}

		//Descuenta de stock
		public void disminuirExistencia(DataTable tabla, string campoID, string campoCantidad)
		{
			actualizarStock(tabla, campoID, campoCantidad, "sp_StockDisminuirExistencia");
		}

		private void actualizarStock(DataTable tabla, string campoID, string campoCantidad, string sp)
		{
			try
			{
				if (tabla.Rows.Count > 0)
				{
					SqlParameter[] param = new SqlParameter[2];
					for (int i=0; i<tabla.Rows.Count; i++)
					{
						string id = tabla.Rows[i][campoID].ToString();
						string cantidad = tabla.Rows[i][campoCantidad].ToString();

						if (id!="" && cantidad!="")
						{
							param[0] = new SqlParameter("articuloID", new System.Guid(id));
							param[1] = new SqlParameter("cantidad", cantidad);
						}
						SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), sp, param);
					}
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}
		}
	}
}
