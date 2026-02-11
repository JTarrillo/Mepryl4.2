using System;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace Comunes
{
	/// <summary>
	/// Summary description for CaluladorRankingClientes.
	/// </summary>
	public class CalculadorRankingClientes
	{
		private Configuracion configuracion;
		public CalculadorRankingClientes(Configuracion conf)
		{
			this.configuracion = conf;
		}

		//Ejecuta el calculo
		public void ejecutarCalculo()
		{
			//Obtiene la lista completa de clientes
			SqlDataReader drClientes = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_getAllClientes");

			if (drClientes.HasRows)
			{
				//Recorre los clientes
				while (drClientes.Read())
				{
					double puntaje = 0;
					double montoHistorial = 0,
							montoUltimoAnio = 0,
							promedioCompra = 0,
							cantidadFacturas = 0;
					double frecuenciaCompra = 0;

					double umbral_montoHistorial = (double)configuracion.obtenerParametro("UMBRAL_MONTO_HISTORIAL");
					double umbral_montoUltimoAnio = (double)configuracion.obtenerParametro("UMBRAL_MONTO_ULTIMO_ANIO");
					double umbral_promedioCompra = (double)configuracion.obtenerParametro("UMBRAL_PROMEDIO_COMPRA");
					double umbral_frecuenciaCompra = (double)configuracion.obtenerParametro("UMBRAL_FRECUENCIA_COMPRA");

					double puntaje_montoHistorial = (double)configuracion.obtenerParametro("PUNTAJE_MONTO_HISTORIAL");
					double puntaje_montoUltimoAnio = (double)configuracion.obtenerParametro("PUNTAJE_MONTO_ULTIMO_ANIO");
					double puntaje_promedioCompra = (double)configuracion.obtenerParametro("PUNTAJE_PROMEDIO_COMPRA");
					double puntaje_frecuenciaCompra = (double)configuracion.obtenerParametro("PUNTAJE_FRECUENCIA_COMPRA");

					//Obtiene los totales
					SqlParameter[] param = new SqlParameter[1];
					param[0] = new SqlParameter("@clienteID", new System.Guid(drClientes["id"].ToString()));
					SqlDataReader drTotales = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_getClienteRankingTotales", param);
					if (drTotales.HasRows)
					{
						drTotales.Read();
						montoHistorial = double.Parse(drTotales["montoHistorial"].ToString());
						montoUltimoAnio = double.Parse(drTotales["montoUltimoAnio"].ToString());
						cantidadFacturas = double.Parse(drTotales["cantidadFacturas"].ToString());
						promedioCompra = double.Parse(drTotales["promedioCompra"].ToString());
					}

					//Obtiene la frecuencia
					SqlDataReader drFechas = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_getClienteRankingFechasCompras", param);
					DateTime fechaAnterior = DateTime.Now, fechaActual = DateTime.Now;
					bool primerRegistro = true;
					double totalFrecuencias = 0;
					if (drFechas.HasRows)
					{
						while (drFechas.Read())
						{
							if (!primerRegistro)
							{
								fechaActual = (DateTime)drFechas["fecha_creacion"];

								double diferencia = ((TimeSpan)(fechaActual - fechaAnterior)).Days;
								totalFrecuencias += diferencia;
							}

							fechaAnterior = (DateTime)drFechas["fecha_creacion"];
							primerRegistro = false;
						}
					}

					//Saca los calculos finales
					if (cantidadFacturas > 0)
					{
						//Calcula el promedio de frecuencia de compra
						frecuenciaCompra = totalFrecuencias / cantidadFacturas;

						//Asigna los puntos
						if (montoHistorial >= umbral_montoHistorial)
							puntaje += puntaje_montoHistorial;

						if (montoUltimoAnio >= umbral_montoUltimoAnio)
							puntaje += puntaje_montoUltimoAnio;

						if (frecuenciaCompra <= umbral_frecuenciaCompra)
							puntaje += puntaje_frecuenciaCompra;

						if (promedioCompra >= umbral_promedioCompra)
							puntaje += puntaje_promedioCompra;
					}
				}
			}
		}
	}
}
