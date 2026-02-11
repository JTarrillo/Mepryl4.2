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
	public class Remito
	{
		private Configuracion configuracion;

		public string RemitoSuc = "";
		public string RemitoNro = "";

		public Remito(Configuracion config)
		{
			this.configuracion = config;
		}

		//Graba un nuevo estado para el remito
		public void cambiarEstadoRemito(string remitoID, string estadoRemito)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[2];
			
				param[0] = new SqlParameter("@remitoID", new Guid(remitoID));
				param[1] = new SqlParameter("@estadoRemito", estadoRemito);

				//Ejecuta el cambio de estado
				SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_CambiarEstadoRemito", param);
		
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}		
		}


		//Graba un nuevo estado para la mercaderia en transito
		public void cambiarEstadoMercaderia(string remitoID, string estadoMercaderia)
		{
			try
			{
				SqlParameter[] param = new SqlParameter[2];
			
				param[0] = new SqlParameter("@remitoID", new Guid(remitoID));
				param[1] = new SqlParameter("@estadoMercaderia", estadoMercaderia);

				//Ejecuta el cambio de estado
				SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_CambiarEstadoRemito", param);
		
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}		
		}

		//Obtener nuevo Nro Remito
		public string[] obtenerNuevoNroRemito(string remitoID, string sucursalID)
		{
			string[] resultado = new string[2];
			try
			{
				SqlParameter[] param = new SqlParameter[2];
			
				param[0] = new SqlParameter("@remitoID", new Guid(remitoID));
                param[1] = new SqlParameter("@sucursalID", new Guid(sucursalID));
				
				//Genera un nuevo numero de remito.
				SqlDataReader dr = SqlHelper.ExecuteReader(this.configuracion.getConectionString(), "sp_getNewRemitoNro", param);

				dr.Read();

				resultado[0] = dr["Sucursal"].ToString();
				resultado[1] = dr["Numero"].ToString();

				dr.Close();

				this.RemitoSuc = resultado[0];
				this.RemitoNro = resultado[1];
		
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}		
			return resultado;
		}

		
		//Imprime el Remito
		/*public bool imprimirRemito(string remitoID)
		{
			bool resultado = false;
			try
			{
				//Carga el dataset
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@remitoID", new Guid(remitoID));
				DataSet ds = SqlHelper.ExecuteDataset(this.configuracion.getConectionString(), "sp_getRemitoImpresion", param);

				ds.Tables[0].TableName = "v_Remito";
				ds.Tables[1].TableName = "v_RemitoLinea";
				ds.DataSetName = "dsRemitoImpresion";
				
				//Carga el reporte
				crRemitoImpresion doc = new crRemitoImpresion();
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
					this.obtenerNuevoNroRemito(remitoID);

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
		}*/

		//Imprime el Remito en impresora matriz de puntos
		public bool imprimirRemito(string remitoID)
		{
			bool resultado = false;
			try
			{
				//Carga el dataset
				SqlParameter[] param = new SqlParameter[1];
				param[0] = new SqlParameter("@remitoID", new Guid(remitoID));
				DataSet ds = SqlHelper.ExecuteDataset(this.configuracion.getConectionString(), "sp_getRemitoImpresion", param);

				ds.Tables[0].TableName = "v_Remito";
				ds.Tables[1].TableName = "v_RemitoLinea";
				ds.DataSetName = "dsRemitoImpresion";
				
				//Solo si hay un registro en remitos
				if (ds.Tables["v_Remito"].Rows.Count > 0)
				{
					//Si el estado del Remito es Suspendido, pide un nuevo numero de remito, sino lo imprime con el numero ya asignado
                    if (ds.Tables["v_Remito"].Rows[0]["estadoRemitoIdentificador"].ToString() == "SUSPENDIDO")
                        this.obtenerNuevoNroRemito(remitoID, ds.Tables["v_Remito"].Rows[0]["sucursalCreacionID"].ToString());
                    else
                    {
                        this.RemitoSuc = ds.Tables["v_Remito"].Rows[0]["remitoSuc"].ToString();
                        this.RemitoNro = ds.Tables["v_Remito"].Rows[0]["remitoNro"].ToString();
                    }
                    string numeroNotaPedido = ds.Tables["v_Remito"].Rows[0]["Nota Pedido"].ToString();
                    string numeroRemito = this.RemitoSuc + "-" + this.RemitoNro;
					DateTime fecha = (DateTime)ds.Tables["v_Remito"].Rows[0]["Fecha"];
					string destinatario = ds.Tables["v_Remito"].Rows[0]["Destinatario"].ToString();
					string direccionDestinatario = ds.Tables["v_Remito"].Rows[0]["Dirección Destinatario"].ToString();
                    string fleteNombre = ""; // ds.Tables["v_Remito"].Rows[0]["Flete"].ToString();
                    string fleteDomicilio = ""; /* ds.Tables["v_Remito"].Rows[0]["Flete_Calle"].ToString() + " " +
                                             ds.Tables["v_Remito"].Rows[0]["Flete_Nro"].ToString() + " " +
                                             ds.Tables["v_Remito"].Rows[0]["Flete_Piso"].ToString() + " " +
                                             ds.Tables["v_Remito"].Rows[0]["Flete_Oficina"].ToString() + " " +
                                             "(" + ds.Tables["v_Remito"].Rows[0]["Flete_CodPost"].ToString() + ") " +
                                             ds.Tables["v_Remito"].Rows[0]["Flete_Localidad"].ToString();*/
                    string fleteIVA = ""; // ds.Tables["v_Remito"].Rows[0]["Flete_IVA"].ToString();
                    string fleteCuit = ""; // ds.Tables["v_Remito"].Rows[0]["Flete_Cuit"].ToString();
                    string sucursal = ds.Tables["v_Remito"].Rows[0]["sucursal"].ToString();
                    sucursal = sucursal.Substring(0, 2);
                    string destinatarioLocalidad = ds.Tables["v_Remito"].Rows[0]["destinatarioLocalidad"].ToString();
                    string destinatarioProvincia = ds.Tables["v_Remito"].Rows[0]["destinatarioProvincia"].ToString();
                    string facturaNumero = ds.Tables["v_Remito"].Rows[0]["facturaNumero"].ToString();
				
					//Ejemplo con el formato del Remito
					string s = "";
                    string letraCondensada = "\u001B\u0021\u0005";
                    string letraItalica = "\u001B\u0021\u0049";
                    string letraGrande = "\u001B\u0021\u0023";
                    string letraNormal = "\u001B\u0021\u0001";


                    s += "\r\n";
					s += "\r\n" + letraCondensada;  //Comprime la letra
                    s += Utilidades.espacios(74) + letraNormal + numeroRemito.ToString() + "\r\n" + letraCondensada;
					s += Utilidades.espacios(78) + fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString() + "\r\n";
                    s += "\r\n";
                    s += "\r\n";
					s += "\r\n";
					s += Utilidades.espacios(10) + (destinatario + Utilidades.espacios(50)).Substring(0,50) + Utilidades.espacios(30) + numeroNotaPedido + "\r\n";
					s += Utilidades.espacios(10) + (direccionDestinatario + Utilidades.espacios(63)).Substring(0,63) + "\r\n";
                    s += Utilidades.espacios(10) + (destinatarioLocalidad + Utilidades.espacios(63)).Substring(0, 63) + Utilidades.espacios(13) + sucursal + "\r\n";
                    s += Utilidades.espacios(10) + (destinatarioProvincia + Utilidades.espacios(63)).Substring(0, 63) + Utilidades.espacios(13) + "(Fact.Nro. " + facturaNumero + ")\r\n";
                    s += "\r\n";
                    s += "\r\n";
                    s += "\r\n";
                    /*
                    //Condicion IVA y CUIT
					s += Utilidades.espacios(7) + ("" + Utilidades.espacios(34)).Substring(0,34) + Utilidades.espacios(10) + "" + "\r\n";
					//Condiciones de venta
					s += Utilidades.espacios(17) + ("" + Utilidades.espacios(24)).Substring(0,24) + "\r\n";
					s += "\r\n";
					s += Utilidades.espacios(10) + (fleteNombre + Utilidades.espacios(60)).Substring(0,60)  + "\r\n";
					s += "\r\n";
					s += Utilidades.espacios(7) + (fleteDomicilio + Utilidades.espacios(63)).Substring(0,63)  + "\r\n";
					s += Utilidades.espacios(7) + (fleteIVA + Utilidades.espacios(34)).Substring(0,34) + Utilidades.espacios(10) + fleteCuit + "\r\n";
                    */

					//Escribe los items
					int row = -1, i;
					if (ds.Tables["v_RemitoLinea"].Rows.Count > 0)
					{
						for (i=0; i<ds.Tables["v_RemitoLinea"].Rows.Count; i++)
						{
							row++;
							string codigoInterno = ds.Tables["v_RemitoLinea"].Rows[row]["codigoInterno"].ToString();
							string cantidad = ds.Tables["v_RemitoLinea"].Rows[row]["cantidad"].ToString();
							string descripcion = ds.Tables["v_RemitoLinea"].Rows[row]["descripcion"].ToString();

                            //Quita los retornos de carro
                            descripcion = descripcion.Replace("\r\n", " ");

							s += (codigoInterno + Utilidades.espacios(10)).Substring(0,10) + "     " + (cantidad + Utilidades.espacios(4)) + "    " + (descripcion + Utilidades.espacios(54)).Substring(0,54) + "\r\n";
						}
					}
					//Completa los renglones vacios
					for (i=row; i<19; i++)
					{
						s += "\r\n";	
					}
					string bultos = ds.Tables["v_Remito"].Rows[0]["bultos"].ToString();
					string obsequiante = ds.Tables["v_Remito"].Rows[0]["obsequiante"].ToString();
					//Escribe el pie de pagina
					//s += "Items: " + ((int)(row+1)).ToString() + "    Bultos: " + bultos + "\r\n";
                    s += "\r\n";
					s += letraNormal + "            " + (obsequiante + Utilidades.espacios(40)).Substring(0,40) + "\r\n" + letraCondensada;
                    s += "\r\n";
                    s += "\r\n";
                    s += "\r\n";
                    s += "\r\n";
					s += "\r\n";
					s += "\r\n";
					s += "\r\n";
                    s += "\r\n";
                    s += "\r\n";
                    s += "\r\n";
                    s += "\r\n";
                    s += "\r\n";

					// Send a printer-specific to the printer.
                    string impresoraRemito = (string)configuracion.obtenerParametro("IMPRESORA_REMITO");
					resultado = RawPrinterHelper.SendStringToPrinter(impresoraRemito, s);
				}
				else
				{
					resultado = false;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				resultado = false;
			}	

			return resultado;
		}

        //Si no se pasa la DataTable, se obtiene una a traves del remitoID
        public void actualizarStock(string remitoID)
        {
            try
            {
                //Obtiene la tabla de RemitoLinea
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@remitoID", new Guid(remitoID));
                DataSet ds = SqlHelper.ExecuteDataset(this.configuracion.getConectionString(), "sp_getRemitoImpresion", param);
                DataTable dtRemito = ds.Tables[1];

                //Actualiza el stock
                ControlStock cs = new ControlStock(this.configuracion);
                cs.disminuirExistencia(dtRemito, "articuloID", "Cantidad");
                cs = null;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
        }

		//Descuenta el stock de la mercderia que figura en el remito y crea una instancia de Mercaderia en Transito
		public void actualizarStock(DataTable dtRemito, string remitoID)
		{
			try 
			{
				//Actualiza el stock
				ControlStock cs = new ControlStock(this.configuracion);
				cs.disminuirExistencia(dtRemito, "articuloID", "Cantidad");
				cs = null;

			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}	
		}

		//Cambia el estado de la mercaderia en transito
		public void cambiarEstadoMercaderia(string remitoID, string nuevoEstadoMercaderia, string observaciones)
		{
			try 
			{
				//Mercaderia en transito
				MercaderiaEnTransito mt = new MercaderiaEnTransito(this.configuracion);
				
				switch (nuevoEstadoMercaderia)
				{
					case "DESPACHADA":
						mt.despachada(remitoID, observaciones);
						break;
					case "CLIENTE_NOTIFICADO":
						mt.clienteNotificado(remitoID, observaciones);
						break;
					case "DEVUELTA":
						mt.devuelta(remitoID, observaciones);
						break;
					case "ENTREGADA":
						mt.entregada(remitoID, observaciones);
						break;
				}
				mt = null;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
			}	
		}

        //Asigna el Flete y la zona 
        public bool asignarZonayFlete(string remitoID, string zonaID, string fleteID)
        {
            bool resultado;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@remitoID", new Guid(remitoID));
                param[1] = new SqlParameter("@zonaID", new Guid(zonaID));
                param[2] = new SqlParameter("@fleteID", new Guid(fleteID));
                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_RemitoAsignarZonayFlete", param);
                resultado = true;
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
