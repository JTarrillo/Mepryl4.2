using System;
using System.Data;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Comunes
{
	/// <summary>
	/// Summary description for Recibo.
	/// </summary>
	public class Recibo
	{
		private Configuracion configuracion;

		public string ReciboSuc = "";
		public string ReciboNro = "";

		public Recibo(Configuracion config)
		{
			this.configuracion = config;
		}

		//Graba un nuevo estado para el recibo
		public void cambiarEstadoRecibo(string reciboID, string estadoRecibo)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[2];
			
				param[0] = new SqlParameter("@reciboID", new Guid(reciboID));
				param[1] = new SqlParameter("@estadoRecibo", estadoRecibo);

				//Ejecuta el cambio de estado
				SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_CambiarEstadoRecibo", param);
		
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}		
		}

		//Obtener nuevo Nro Recibo
		public string[] obtenerNuevoNroRecibo(string reciboID, string sucursalID)
		{
			string[] resultado = new string[2];
			try
			{
				SqlParameter[] param = new SqlParameter[2];
			
				param[0] = new SqlParameter("@reciboID", new Guid(reciboID));
                param[1] = new SqlParameter("@sucuralID", new Guid(sucursalID));
				
				//Ejecuta el cambio de estado
				SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_getNewReciboNro", param);

				dr.Read();

				resultado[0] = dr["Sucursal"].ToString();
				resultado[1] = dr["Numero"].ToString();

				dr.Close();

				this.ReciboSuc = resultado[0];
				this.ReciboNro = resultado[1];
		
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}		
			return resultado;
		}

		
		//Imprime el Recibo
		public bool imprimirRecibo(string reciboID)
		{
			bool resultado = false;
			try
			{
				//Carga el dataset
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@reciboID", new Guid(reciboID));
				DataSet ds = SqlHelper.ExecuteDataset(this.configuracion.getConectionString(), "sp_getReciboImpresion", param);

				ds.Tables[0].TableName = "v_Recibo";
				ds.Tables[1].TableName = "v_ReciboLinea";
				ds.Tables[2].TableName = "v_FormaPago";
				ds.Tables[3].TableName = "v_FormaPagoLinea";
				ds.Tables[4].TableName = "v_FormaPagoLineaTexto";
				ds.DataSetName = "dsReciboImpresion";
				
				//Carga el reporte
				crReciboImpresion doc = new crReciboImpresion();
				doc.SetDataSource(ds);
				
				System.Windows.Forms.PrintDialog printDialog1 = new System.Windows.Forms.PrintDialog();
				System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
				printDialog1.Document = pd;
			
				if (printDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
				{
					int desde = 0, hasta = 0;
					if (printDialog1.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.AllPages)
					{
						desde = 1;
						hasta = 10000;
					}
					else
					{
						desde = printDialog1.PrinterSettings.FromPage;
						hasta = printDialog1.PrinterSettings.ToPage;
					}
					int copias = printDialog1.PrinterSettings.Copies;
					doc.PrintToPrinter(copias, printDialog1.PrinterSettings.Collate, desde, hasta);

					//Guarda el Nro de Recibo
					this.obtenerNuevoNroRecibo(reciboID,this.configuracion.sucursal.id.ToString());

                    

					resultado = true;
				}
				else
					resultado = false;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				resultado = false;
			}	

			return resultado;
		}
	}
}
