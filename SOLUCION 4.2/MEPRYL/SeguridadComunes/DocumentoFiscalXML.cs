using System;
using System.ComponentModel;
using System.Xml;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using Comunes;


namespace Comunes
{
	/// <summary>
	/// Summary description for FacturaXML.
	/// </summary>
	public class DocumentoFiscalXML
	{
		public Guid ID = Guid.NewGuid();
		public bool esperarRespuestaServidor = true;

		public string mensajeServidor;

		public string documentoNombre = "FA";
        public string documentoComando = "";
		public string comprobanteTipo = "";
		public int comprobanteNumero = 0;
		public int comprobanteCopias = 0;
        public string comprobanteOrigenNro = "";

		public string plazoPago = "";
		public DateTime fechaCreacion = DateTime.Now;
        public string nombreCliente = "";
        public string direccionCliente = "";
        public string ivaCliente = "";
        public string ivaIdentificador = "";
        public string cuitCliente = "";
        public string direccionEntrega = "";
        public string vendedor = "";
        public string condicionEntrega = "";
		public DataTable items;
		public double bonifPorcentaje = 0;
        public string autorizadorBonificacion = "";
		public double bonifImporte = 0;
		public DataTable formasPago;

		public Guid notaPedidoID = new Guid(Utilidades.ID_VACIO);

		public Configuracion configuracion;
		public string pathImpresora;

		public DocumentoFiscalXML(Configuracion config)
		{
			this.configuracion = config;
		}

		//Arma y envia el paquete al servidor de impresion
		public string enviarPaquete()
		{
			string mensajeRespuesta = "";
			try 
			{
				XmlDocument docXml = new XmlDocument();

				XmlElement eAux;

				XmlElement eDocumento = docXml.CreateElement("Documento");
			
				//Asigna los atributos de Documento
				XmlAttribute nAtributo = docXml.CreateAttribute("ID");
				nAtributo.Value = this.ID.ToString();
				eDocumento.Attributes.Append(nAtributo);

				nAtributo = docXml.CreateAttribute("Tipo");
				nAtributo.Value = this.comprobanteTipo;
				eDocumento.Attributes.Append(nAtributo);

				nAtributo = docXml.CreateAttribute("Nombre");
				nAtributo.Value = this.documentoNombre;
				eDocumento.Attributes.Append(nAtributo);


                nAtributo = docXml.CreateAttribute("Comando");
                nAtributo.Value = this.documentoComando;
                eDocumento.Attributes.Append(nAtributo);


				//Agrega el cliente
				XmlElement eCliente = docXml.CreateElement("Cliente");

				eAux = docXml.CreateElement("Nombre");
				eAux.InnerText = this.nombreCliente;
				eCliente.AppendChild(eAux);

				eAux = docXml.CreateElement("Direccion");
				eAux.InnerText = this.direccionCliente;
				eCliente.AppendChild(eAux);

				eAux = docXml.CreateElement("Iva");
				eAux.InnerText = this.ivaCliente;
				eCliente.AppendChild(eAux);

				eAux = docXml.CreateElement("Cuit");
				eAux.InnerText = this.cuitCliente;
				eCliente.AppendChild(eAux);

				eAux = docXml.CreateElement("DireccionEntrega");
				eAux.InnerText = this.direccionEntrega;
				eCliente.AppendChild(eAux);

				eAux = docXml.CreateElement("CondicionEntrega");
				eAux.InnerText = this.condicionEntrega;
				eCliente.AppendChild(eAux);

				eDocumento.AppendChild(eCliente);

				//Agrega el vendedor
				eAux = docXml.CreateElement("Vendedor");
				eAux.InnerText = this.vendedor;
				eDocumento.AppendChild(eAux);

				//Agrega el comprobante
				XmlElement eComprobante = docXml.CreateElement("Comprobante");

				eAux = docXml.CreateElement("Tipo");
				eAux.InnerText = this.comprobanteTipo;
				eComprobante.AppendChild(eAux);

				eAux = docXml.CreateElement("Copias");
				eAux.InnerText = this.comprobanteCopias.ToString();
				eComprobante.AppendChild(eAux);

				eAux = docXml.CreateElement("Identificador");
				eAux.InnerText = this.ivaIdentificador;
				eComprobante.AppendChild(eAux);

                eAux = docXml.CreateElement("ComprobanteOrigenNro");
                eAux.InnerText = this.comprobanteOrigenNro;
                eComprobante.AppendChild(eAux);

				eDocumento.AppendChild(eComprobante);

				//Agrega los items
				XmlElement eItems = docXml.CreateElement("Items");
			
				if (this.items!=null)
				{
					for (int i= 0; i < this.items.Rows.Count; i++)
					{
						eAux = docXml.CreateElement("Item");
				
						nAtributo = docXml.CreateAttribute("Descripcion");
						nAtributo.InnerText = this.items.Rows[i]["Descripción"].ToString();
						eAux.Attributes.Append(nAtributo);

						nAtributo = docXml.CreateAttribute("Cantidad");
						nAtributo.InnerText = this.items.Rows[i]["Cantidad"].ToString();
						eAux.Attributes.Append(nAtributo);

						nAtributo = docXml.CreateAttribute("Precio");
						nAtributo.InnerText = this.items.Rows[i]["Precio"].ToString();
						eAux.Attributes.Append(nAtributo);

						nAtributo = docXml.CreateAttribute("IVA1");
						nAtributo.InnerText = this.configuracion.obtenerParametro("IVA1").ToString();
						eAux.Attributes.Append(nAtributo);

						eItems.AppendChild(eAux);
					}
				}
				eDocumento.AppendChild(eItems);

				//Agrega la Bonificacion
				XmlElement eBonificacion = docXml.CreateElement("Bonificacion");

				eAux = docXml.CreateElement("Porcentaje");
				eAux.InnerText = this.bonifPorcentaje.ToString();
				eBonificacion.AppendChild(eAux);

				eAux = docXml.CreateElement("Importe");
				eAux.InnerText = this.bonifImporte.ToString();
				eBonificacion.AppendChild(eAux);

				eAux = docXml.CreateElement("Autorizador");
				eAux.InnerText = this.autorizadorBonificacion.ToString();
				eBonificacion.AppendChild(eAux);

				eDocumento.AppendChild(eBonificacion);

				//Agrega las Formas de Pago
				XmlElement eFormasDePago = docXml.CreateElement("FormasDePago");
			
				if (this.formasPago!=null)
				{
					for (int i= 0; i < this.formasPago.Rows.Count; i++)
					{
						eAux = docXml.CreateElement("FormaDePago");
				
						nAtributo = docXml.CreateAttribute("Tipo");
						nAtributo.InnerText = this.formasPago.Rows[i]["Tipo Pago"].ToString();
						eAux.Attributes.Append(nAtributo);
						eItems.AppendChild(eAux);

						nAtributo = docXml.CreateAttribute("Detalle");
						nAtributo.InnerText = this.formasPago.Rows[i]["Detalle"].ToString();
						eAux.Attributes.Append(nAtributo);

						nAtributo = docXml.CreateAttribute("Pesos");
						nAtributo.InnerText = this.formasPago.Rows[i]["Pesos"].ToString();
						eAux.Attributes.Append(nAtributo);

                        nAtributo = docXml.CreateAttribute("nroCheque");
                        nAtributo.InnerText = this.formasPago.Rows[i]["Nro. Cheque"].ToString();
                        eAux.Attributes.Append(nAtributo);


						eFormasDePago.AppendChild(eAux);
					}
				}
				eDocumento.AppendChild(eFormasDePago);

				//Agrega los nodos vacios, para la respuesta del servidor
				eAux = docXml.CreateElement("ComprobanteNumero");
				eAux.InnerText = "";
				eDocumento.AppendChild(eAux);

				eAux = docXml.CreateElement("MensajeServidor");
				eAux.InnerText = "";
				eDocumento.AppendChild(eAux);

				//Agrega el Elemento principal al documento
				docXml.AppendChild(eDocumento);

				//Escribe el documento en la red
				//Decide a cual impresora enviar la factura
				if (this.plazoPago=="CONTADO")
					this.pathImpresora = this.configuracion.obtenerParametro("C1").ToString();
				else
					this.pathImpresora = this.configuracion.obtenerParametro("C2").ToString();

				bool continuar = true;
				while (true)
				{
					try
					{
						//Guarda el archivo temporal
						string archivoTemp = pathImpresora + this.documentoNombre + "_" + this.ID.ToString();
						docXml.Save(archivoTemp);

						//Renombra el archivo
						File.Move(archivoTemp, archivoTemp + ".xml");
					
						//Se va del loop
						break;
					}
					catch (Exception e)
					{
						switch (MessageBox.Show("La impresora no está disponible.","Imprimiendo",MessageBoxButtons.RetryCancel,MessageBoxIcon.Exclamation))
						{
							case DialogResult.Retry:
                                mensajeRespuesta = "";
								continuar = true;
								break;
							case DialogResult.Cancel:
								mensajeRespuesta = "La Impresora no está disponible.\r\n\r\n" + e.Message;
								continuar = false;
								break;
						}
					}
					if (!continuar)
						break;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				mensajeRespuesta = ex.Message;
			}
			return mensajeRespuesta;
		}

		//Espera y recibe la respuesta del servidor de impresion
		public void recibirRespuesta()
		{
			this.esperarRespuestaServidor = true;
			frmMensajeSplashPantalla fm = new frmMensajeSplashPantalla("Imprimiendo...");
			//Le asigna una referencia al mismo objeto para que pueda cambiar el flag esperarRespuestaServidor desde el formulario.
			fm.documentoFiscalXML = this;
			try 
			{
				fm.Show();
				XmlDocument docXml = new XmlDocument();
				string archivo = this.pathImpresora + "OK\\" + this.documentoNombre + "_" + this.ID.ToString() + ".xml";
				int i = 0;
				while (this.esperarRespuestaServidor)
				{
					if (File.Exists(archivo))
					{
						//Carga el archivo
						docXml.Load(archivo);

						//Toma los datos
						this.mensajeServidor = docXml.SelectSingleNode("./Documento/MensajeServidor").InnerText;
						string comprobanteNumero = docXml.SelectSingleNode("./Documento/ComprobanteNumero").InnerText;

						if (this.mensajeServidor=="" && comprobanteNumero!="")
						{
							this.comprobanteNumero = int.Parse(comprobanteNumero);
						}

						docXml = null;

						//Elimina el archivo
						File.Delete(archivo);

						break;
					}
					else
					{
						i++;
						fm.lblMensaje.Text = "Imprimiendo...\r\n\r\nEsperando respuesta " + i.ToString() + "...";
						Application.DoEvents();
						Thread.Sleep(500);
					}
				}
				//Si fue cancelado por el usuario, agrega un mensaje
				if (!this.esperarRespuestaServidor)
				{
					//Borra el archivo enviado
					File.Delete(this.pathImpresora + this.documentoNombre + "_" + this.ID.ToString() + ".xml");
					this.mensajeServidor += "\r\nNo se imprimio. La operacion fue cancelada por el usuario.";
				}

				fm.documentoFiscalXML = null;
				fm.Close();
			}
			catch (Exception ex)
			{
				fm.documentoFiscalXML = null;
				fm.Close();
				ManejadorErrores.escribirLog(ex, true, this.configuracion);
				this.mensajeServidor = "Error en estacion local: " + ex.Message;
			}
		}
	}
}