using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for Cliente.
	/// </summary>
	public class Cliente
	{
		public Configuracion configuracion;

		public Cliente(Configuracion config)
		{
			this.configuracion = config;
		}

		public SqlDataReader getByApellidoyNombres(string apellido, string nombres)
		{
			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@apellido", apellido);
			param[1] = new SqlParameter("@nombres", nombres);

			SqlDataReader dr = SqlHelper.ExecuteReader(configuracion.getConectionString(), "sp_getClienteByApellidoyNombres", param);

			return dr;
		}
	}
}
