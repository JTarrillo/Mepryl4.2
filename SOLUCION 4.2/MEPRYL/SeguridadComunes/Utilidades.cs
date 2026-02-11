using System;
using System.Text.RegularExpressions;
using System.Data;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Windows.Forms;

namespace Comunes
{
	/// <summary>
	/// Summary description for Utilidades.
	/// </summary>
	/// 
	public class Utilidades
	{
		public const string ID_VACIO = "00000000-0000-0000-0000-000000000000";
       

		public Utilidades()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        //Devuelve un GUID con los primeros 9 digitos en cero.
        public static string ID_VACIO_RANDOM()
        {
            try
            {
                string resultado;

                resultado = Guid.NewGuid().ToString().Substring(0, 20) + ID_VACIO.Substring(21);

                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
                return "";
            }
        }

        //Verdader si es un ID-VACIO_RANDOM
        public static bool esID_VACIO_RANDOM(string id)
        {
            try
            {
                bool resultado = false;

                if (id.Substring(21) == ID_VACIO.Substring(21))
                    resultado = true;

                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
                return false;
            }
        }

		public static bool IsNumeric(string cadena) 
		{
			try
			{
				bool resultado;
				try 
				{
					double x = double.Parse(cadena);
					resultado = true;
				}
				catch (Exception e) 
				{
					resultado = false;
				}

				return resultado;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
				return false;
			}
		}

		/// <summary>
		/// Validates a standard email address; i.e someone@somewhere.com, .net, .org, etc.		
		/// </summary>
		/// <param name="control">The control to validate; i.e. textBox, comboBox, etc.</param>
		/// <param name="errorProvider">The error provider used to display the error message.</param>
		/// <returns>True if there is a match, false if there is not.</returns>
		public static bool IsEmailAddress(string direccion)
		{
			try
			{
				// Create a new Regex object
				Regex emailRegex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
			
				// Test if we have a match or not
				if (! emailRegex.IsMatch(direccion))
				{
				
					return false;
				}
				else
				{
				
					return true;
				}
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
				return false;
			}
		}

        //Busca un valor en una tabla
        public static int DataTableSeek(ref DataTable dt, string campo, string valor)
        {
            int resultado = -1;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][campo].ToString() == valor)
                        {
                            resultado = i;
                            break;
                        }
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
                return -1;
            }
        }


		//Encripta la cadena de texto
		public static string encriptar(string cadena)
		{
			try
			{
				char[] array = cadena.ToCharArray();

				string nuevaCadena = "";
				int caracter = 0;
				for (int i=array.GetUpperBound(0); i>=array.GetLowerBound(0); i--)
				{
					caracter = array[i]+3;
					nuevaCadena += caracter.ToString("x");
				}

				return nuevaCadena;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
				return null;
			}
		}

		//Desencripta la cadena de texto
		public static string desencriptar(string cadena)
		{
			try
			{
				string nuevaCadena = "";
				int caracter = 0;
				for (int i=cadena.Length-1; i>=0; i--)
				{
					i--;
					caracter = int.Parse(cadena.Substring(i,2), System.Globalization.NumberStyles.HexNumber)-3;
					nuevaCadena += new string((char)caracter, 1);
				}

				return nuevaCadena;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
				return null;
			}
		}

		public static string numeroALetras(string numero) 
		{
			try
			{
				//'********Declara variables de tipo cadena************
				string palabras="", entero="", dec="", flag="";
				string Letras="";

				//'********Declara variables de tipo entero***********
				int num=0, x=0, y=0;

				flag = "N";

				//'*********Dividir parte entera y decimal************
				for (y = 0; y<numero.Length; y++)
				{
					if (numero.Substring(y,1) == ",")
						flag = "S";
					else
					{
						if (flag == "N")
							entero = entero + numero.Substring(y,1);
						else
							dec = dec + numero.Substring(y,1);
					}
				}

				if (dec.Length == 1) 
					dec = dec + "0";

				if (dec.Length>2)
					dec = dec.Substring(0,2);

				//'**********proceso de conversión***********
				flag = "N";

				if (Double.Parse(numero) <= 999999999) 
				{
					for (y = entero.Length; y>0; y--)
					{
						num = entero.Length - (y);
						switch (y)
						{
							case 3:
							case 6:
							case 9:
								//'**********Asigna las palabras para las centenas***********
							switch (entero.Substring(num, 1))
							{
								case "1":
									if (entero.Substring(num + 1, 1) == "0" && entero.Substring(num + 2, 1) == "0")
										palabras = palabras + "cien ";
									else
										palabras = palabras + "ciento ";
									break;
								case "2":
									palabras = palabras + "doscientos ";
									break;
								case "3":
									palabras = palabras + "trescientos ";
									break;
								case "4":
									palabras = palabras + "cuatrocientos ";
									break;
								case "5":
									palabras = palabras + "quinientos ";
									break;
								case "6":
									palabras = palabras + "seiscientos ";
									break;
								case "7":
									palabras = palabras + "setecientos ";
									break;
								case "8":
									palabras = palabras + "ochocientos ";
									break;
								case "9":
									palabras = palabras + "novecientos ";
									break;
							}
								break;
							case 2:
							case 5:
							case 8:
								//'*********Asigna las palabras para las decenas************
							switch(entero.Substring(num, 1))
							{
								case "1":
									if (entero.Substring(num + 1, 1) == "0")
									{
										flag = "S";
										palabras = palabras + "diez ";
									}
									if (entero.Substring(num + 1, 1) == "1")
									{
										flag = "S";
										palabras = palabras + "once ";
									}
				
									if (entero.Substring(num + 1, 1) == "2")
									{
										flag = "S";
										palabras = palabras + "doce ";
									}
									if (entero.Substring(num + 1, 1) == "3")
									{
										flag = "S";
										palabras = palabras + "trece ";
									}
									if (entero.Substring(num + 1, 1) == "4")
									{
										flag = "S";
										palabras = palabras + "catorce ";
									}
									if (entero.Substring(num + 1, 1) == "5")
									{
										flag = "S";
										palabras = palabras + "quince ";
									}
									if (int.Parse(entero.Substring(num + 1, 1)) > 5)
									{
										flag = "N";
										palabras = palabras + "dieci";
									}
									break;
								case "2":
									if (entero.Substring(num + 1, 1) == "0")
									{
										palabras = palabras + "veinte ";
										flag = "S";
									}
									else
									{
										palabras = palabras + "veinti";
										flag = "N";
									}
									break;
								case "3":
									if (entero.Substring(num + 1, 1) == "0")
									{
										palabras = palabras + "treinta ";
										flag = "S";
									}
									else
									{
										palabras = palabras + "treinta y ";
										flag = "N";
									}
									break;
								case "4":
									if (entero.Substring(num + 1, 1) == "0" )
									{
										palabras = palabras + "cuarenta ";
										flag = "S";
									}
									else
									{
										palabras = palabras + "cuarenta y ";
										flag = "N";
									}
									break;
								case "5":
									if (entero.Substring(num + 1, 1) == "0")
									{
										palabras = palabras + "cincuenta ";
										flag = "S";
									}
									else
									{
										palabras = palabras + "cincuenta y ";
										flag = "N";
									}
									break;
								case "6":
									if (entero.Substring(num + 1, 1) == "0")
									{
										palabras = palabras + "sesenta ";
										flag = "S";
									}
									else
									{
										palabras = palabras + "sesenta y ";
										flag = "N";
									}
									break;
								case "7":
									if (entero.Substring(num + 1, 1) == "0")
									{
										palabras = palabras + "setenta ";
										flag = "S";
									}
									else
									{
										palabras = palabras + "setenta y ";
										flag = "N";
									}
									break;
								case "8":
									if (entero.Substring(num + 1, 1) == "0")
									{
										palabras = palabras + "ochenta ";
										flag = "S";
									}
									else
									{
										palabras = palabras + "ochenta y ";
										flag = "N";
									}
									break;
								case "9":
									if (entero.Substring(num + 1, 1) == "0")
									{
										palabras = palabras + "noventa ";
										flag = "S";
									}
									else
									{
										palabras = palabras + "noventa y ";
										flag = "N";
									}
									break;
								case "0":   //Agregado por MMM 20/01/2006
									flag = "N";
									break;
							}
								break;
							case 1:
							case 4:
							case 7:
								//'*********Asigna las palabras para las unidades*********
							switch(entero.Substring(num, 1))
							{
								case "1":
									if (flag == "N") 
									{
										if (y == 1)
											palabras = palabras + "uno ";
										else
											palabras = palabras + "un ";
									}
									break;
								case "2":
									if (flag == "N") 
										palabras = palabras + "dos ";
									break;
								case "3":
									if (flag == "N")
										palabras = palabras + "tres ";
									break;
								case "4":
									if (flag == "N")
										palabras = palabras + "cuatro ";
									break;
								case "5":
									if (flag == "N")
										palabras = palabras + "cinco ";
									break;
								case "6":
									if (flag == "N")
										palabras = palabras + "seis ";
									break;
								case "7":
									if (flag == "N")
										palabras = palabras + "siete ";
									break;
								case "8":
									if (flag == "N")
										palabras = palabras + "ocho ";
									break;
								case "9":
									if (flag == "N")
										palabras = palabras + "nueve ";
									break;
							}
								break;
						}
				

						//'***********Asigna la palabra mil***************
						if (y == 4)
						{
							//if (entero.Substring(6, 1) != "0" || entero.Substring(5, 1) != "0" || entero.Substring(4, 1) != "0" ||
							//	(entero.Substring(6, 1) == "0" && entero.Substring(5, 1) == "0" && entero.Substring(4, 1) == "0" &&
							//	entero.Length <= 6))
							//{
							palabras = palabras + "mil ";
							//}
						}
							
						//'**********Asigna la palabra millón*************
						if (y == 7)
						{
							if (entero.Length == 7 && entero.Substring(1, 1) == "1")
							{
								palabras = palabras + "millón ";
							}
							else
							{
								palabras = palabras + "millones ";
							}
						}
				
					} //(next y)

					//'**********Une la parte entera y la parte decimal*************
					if (dec != "" && dec != "00")
					{
						Letras = palabras + "con " + dec + " centavos.";
					}
					else
					{
						Letras = palabras.Trim() + ".---";
					}
				}
				else
				{
					Letras = "";
				}
				return Letras;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
				return null;
			}
		}

		//Agrega ceros a la izquierda del numero y valida si el valor es numerico
		public static bool agregarCerosIzquierda(ref string numero, int len)
		{
			try
			{
				bool result = false;
				if (IsNumeric(numero) && numero.Trim()!="")
				{
					numero = "00000000" + numero.Trim();
					int punto = numero.Length - len;
					numero = numero.Substring(punto, len);
					result = true;
				}

				return result;
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
				return false;
			}
		}

		//Dado un archivo con su path, devuelve el nombre del archivo
		public static string obtenerNombreArchivo(string nombreCompleto)
		{
			try
			{
				return nombreCompleto.Substring(nombreCompleto.LastIndexOf("\\")+1);
			}
			catch (Exception ex)
			{
				ManejadorErrores.escribirLog(ex, true);
				return null;
			}
		}

		//Abrevia una cadena hasta llegar al ancho indicado.
		/* Metodo:
		 *		0 - Se quitan todos los puntos, comas y espacios dobles de la frase.
		 *		1 - Se comienza el procedimiento de atras hacia adelante, palabra por palabra hasta llegar al anchoFinal
		 *		2 - Se parte la palabra en dos y se quitan las vocales de la segunda mitad.
		 *		3 - Si no alcanza, se comienza a quitar la ultima letra de cada palabra hasta alcanzar el ancho necesario.
		 */
		public static string abreviarPalabras(string cadenaOriginal, int anchoFinal)
		{
			//Elimina los puntos, comas y espacios dobles
			string cadena = cadenaOriginal.Replace(".","");
			cadena = cadenaOriginal.Replace(",","");
			cadena = cadenaOriginal.Replace("  "," ");

			//Crea un array de palabras
			string[] aPalabras = cadena.Split(" ".ToCharArray());

			int i = aPalabras.Length - 1;

			int paso = 1;
			int anchoAnterior = cadena.Length;
			
			//Revisa las palabras hasta que la cadena final tenga el ancho necesario.
			while (cadena.Length > anchoFinal)
			{
				//Termino de revisar las palabras, ejecuta el paso siguiente
				if (i<0)
				{
					//Si no cambio el ancho, quiere decir que se estanco. Termina.
					if (cadena.Length==anchoAnterior && paso>1)
						break;
					else
						anchoAnterior = cadena.Length;

					paso++;
					i = aPalabras.Length - 1;
				}

				if (paso==1)  //Paso 1: parte la palabra y le quita las vocales a la segunda mitad.
				{
					string palabra = aPalabras[i].ToLower();
					//Solo aplica a las palabras mayores a tres letras
					if (palabra.Length > 3)
					{
						int punto = (int)(palabra.Length/2);
						string mitad2 = palabra.Substring(punto);
						mitad2 = mitad2.Replace("a", "");
						mitad2 = mitad2.Replace("e", "");
						mitad2 = mitad2.Replace("i", "");
						mitad2 = mitad2.Replace("o", "");
						mitad2 = mitad2.Replace("u", "");
						mitad2 = mitad2.Replace("y", "");
						mitad2 = mitad2.Replace("á", "");
						mitad2 = mitad2.Replace("é", "");
						mitad2 = mitad2.Replace("í", "");
						mitad2 = mitad2.Replace("ó", "");
						mitad2 = mitad2.Replace("ú", "");

						palabra = palabra.Substring(0, punto) + mitad2;

						aPalabras[i] = palabra;
					}
				}
				else
				{
					if (aPalabras[i].Length>3)
					{
						//Solo aplica a letras, no a numeros
						string caracter = aPalabras[i].Substring(aPalabras[i].Length-1);
						if (!IsNumeric(caracter))
							aPalabras[i] = aPalabras[i].Substring(0, aPalabras[i].Length-1);
					}
				}

				cadena = arrayToString(aPalabras, " ");
				i--;
			}

			return cadena;
		}

		//Convierte un array de cadenas a una sola cadena
		public static string arrayToString(string[] aCadenas, string separador)
		{
			string cadenaFinal = "";
			string miSeparador = "";
			for (int i=0; i<aCadenas.Length; i++)
			{
				cadenaFinal += miSeparador + aCadenas[i];

				miSeparador = separador;
			}

			return cadenaFinal;
		}

		//Quita acentos y caracteres especiales
		public static string quitarAcentos(string texto)
		{
			string[,] caracteres = new string[20,2];
			caracteres[0,0] = "º"; caracteres[0,1] = "o";
			caracteres[1,0] = "¡"; caracteres[1,1] = "";
			caracteres[2,0] = "ç"; caracteres[2,1] = "c";
			caracteres[3,0] = "ñ"; caracteres[3,1] = "n";
			caracteres[4,0] = "á"; caracteres[4,1] = "a";
			caracteres[5,0] = "é"; caracteres[5,1] = "e";
			caracteres[6,0] = "í"; caracteres[6,1] = "i";
			caracteres[7,0] = "ó"; caracteres[7,1] = "o";
			caracteres[8,0] = "ú"; caracteres[8,1] = "u";
			caracteres[9,0] = "ª"; caracteres[9,1] = "a";
			caracteres[10,0] = "¿"; caracteres[10,1] = "";
			caracteres[11,0] = "Ç"; caracteres[11,1] = "C";
			caracteres[12,0] = "Á"; caracteres[12,1] = "A";
			caracteres[13,0] = "É"; caracteres[13,1] = "E";
			caracteres[14,0] = "Í"; caracteres[14,1] = "I";
			caracteres[15,0] = "Ú"; caracteres[15,1] = "U";
			caracteres[16,0] = "Ó"; caracteres[16,1] = "O";
			caracteres[17,0] = "Ñ"; caracteres[17,1] = "N";
			caracteres[18,0] = "ü"; caracteres[18,1] = "u";
			caracteres[19,0] = "Ü"; caracteres[19,1] = "U";

			for (int i=0; i<20; i++)
			{
				while (texto.IndexOf(caracteres[i,0])>-1)
				{
					texto = texto.Replace(caracteres[i,0], caracteres[i,1]);
				}
			}

			return texto;
		}

		//Interpreta el mensaje de la Impresora Fiscal
		public static void leerMensajeImpresora(string comando, string modulo, ref bool respuesta, ref AxEPSON_Impresora_Fiscal.AxPrinterFiscal PrinterOCX, ref string mensajeImpresora)
		{
			if (!respuesta)
			{
				string mensaje = "La impresora ha generado un error: \r\n\r\n" +
								"Modulo : " + modulo + "\r\n" +
								"Comando: " + comando + "\r\n" + 
								"Mensaje: " + PrinterOCX.AnswerField_3.ToString() + " "  
											+ PrinterOCX.AnswerField_4.ToString() + " " 
											+ PrinterOCX.AnswerField_5.ToString() + " " 
											+ PrinterOCX.AnswerField_6.ToString() + " " 
											+ PrinterOCX.AnswerField_7.ToString() + " " 
											+ "\r\n\r\n";	
					
											/*+ PrinterOCX.AnswerField_8.ToString() + " " 
											+ PrinterOCX.AnswerField_9.ToString() + " " 
											+ PrinterOCX.AnswerField_10.ToString() + " " 
											+ PrinterOCX.AnswerField_11.ToString() + " " 
											+ PrinterOCX.AnswerField_12.ToString() + " " 
											+ PrinterOCX.AnswerField_13.ToString() + " " 
											+ PrinterOCX.AnswerField_14.ToString() + " " 
											+ PrinterOCX.AnswerField_15.ToString() + " " 
											+ PrinterOCX.AnswerField_16.ToString() + " " 
											+ PrinterOCX.AnswerField_17.ToString() + " " 
											+ PrinterOCX.AnswerField_18.ToString() + " " 
											+ PrinterOCX.AnswerField_19.ToString() + " " +
								"\r\n\r\n";*/

				mensajeImpresora += "\r\n\r\n" + mensaje;

				/*DialogResult dlr;
								
				dlr = MessageBox.Show(mensaje, "Error al intentar imprimir", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);

				switch (dlr)
				{
					case DialogResult.Abort:
						respuesta = false;
						break;
					case DialogResult.Ignore:
						respuesta = true;
						break;
					case DialogResult.Retry:
						respuesta = false;
						break;
				}*/
				respuesta = false;
			}
		}

		//Valida un CUIT
		/*public static bool validarCUIT(string cuit)
		{
			bool resultado = true;

			cuit = cuit.Replace("-","");
			cuit = cuit.Replace("/","");
			cuit = cuit.Replace(" ","");
			cuit = cuit.Replace(".","");
			
			if (cuit.Length!=11)
				resultado = false;

			if (!Utilidades.IsNumeric(cuit))
					resultado = false;
			
			return resultado;
		}*/
        public static bool validarCUIT(string cadena)
        {
            bool resultado = false;

            if (cadena.Length == 11 && Utilidades.IsNumeric(cadena))
            {
                //Valores por los que multiplicaremos cada digio del CUIT
                int[] loValores = new int[10];
                loValores[0] = 5;
                loValores[1] = 4;
                loValores[2] = 3;
                loValores[3] = 2;
                loValores[4] = 7;
                loValores[5] = 6;
                loValores[6] = 5;
                loValores[7] = 4;
                loValores[8] = 3;
                loValores[9] = 2;

                //Variable donde iremos sumando los valores que obtengamos de multiplicar los digitos del cuit por los numeros de loValores
                int loProducto = 0;

                for (int index = 0; index <= 9; index++)
                {
                    loProducto += (loValores[index] * int.Parse(cadena.Substring(index, 1)));
                }

                //Sacamos el mod 11 de loProducto
                int intMod11 = loProducto % 11;
                //Destamos el resultado de mod a 11
                int digito = 11 - intMod11;

                //Comprobamos que el valor coincida con el digito de control introducido por el usuario
                int dc = int.Parse(cadena.Substring(10, 1));

                if (dc == digito)
                {
                    //El resultado es correcto
                    resultado = true;
                }
                else
                {
                    //El resultado es incorrecto
                    resultado = false;
                }
            }
            else
                resultado = false;


            return resultado;
        }

        //Limia de caracteres extranios un cuit
        public static string limpiarCUIT(string cuit)
		{
			cuit = cuit.Replace("-","");
			cuit = cuit.Replace("/","");
			cuit = cuit.Replace(" ","");
			cuit = cuit.Replace(".","");
			
			return cuit;
		}

		//Valida la estructura de una cadena GUID
		public static string validarGUID(string guid)
		{
			try
			{
                if (guid != "0" && guid != "")
                {
                    Guid gu = new Guid(guid);
                }
                else
                    guid = Utilidades.ID_VACIO;  //NO se si esta bien
			}
			catch (Exception e)
			{
				MessageBox.Show("Estructura GUID erronea: " + guid, "Validacion GUID");
			}
			return guid;
		}

		//Crea una cadena de espacios
		public static string espacios(int cant)
		{
			return new string(' ', cant);
		}

	}
}
