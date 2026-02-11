using System;
using System.Text.RegularExpressions;
using System.Data;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace Comunes
{
	/// <summary>
	/// Summary description for Utilidades.
	/// </summary>
	/// 
    public enum ModoEdicion
    {
        VACIO,
        AGREGANDO,
        MODIFICANDO
    }
    public enum EEspecialidad
    {
        Preventiva = 1,
        Eco = 2,
        Buzo = 3,
        Trauma = 4,
        Ergo = 5,
        Preocu = 6
    }
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

        //Revisa los atributos de un objeto y copia los valores en el otro objeto
        public static void copiarAtributos(ref object origen, ref object destino)
        {
            try
            {
                FieldInfo[] origenAtributos = origen.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                FieldInfo[] destinoAtributos = destino.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                
                //Recorre el origen
                foreach (FieldInfo fo in origenAtributos)
                {
                    //Recorre el destino
                    foreach (FieldInfo fd in destinoAtributos)
                    {
                        //Si los atributos tienen el mismo nombre y mismo tipo.
                        //if (fo.Name == fd.Name && fo.FieldType.Name == fd.FieldType.Name)
                        if (fo.Name == fd.Name && fo.FieldType.FullName == fd.FieldType.FullName)
                        {
                            fd.SetValue(destino, fo.GetValue(origen));
                            break;
                        }
                        
                    }    
                }
                
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
            }
        }

        //Selecciona el item segun el texto del parametro
        public static void comboSeleccionarItemByText(string texto, ref ComboBox cb)
        {
            try
            {
                int index = 0;
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    cb.SelectedIndex = i;
                    if (cb.Text == texto)
                    {
                        index = i;
                        break;
                    }
                }
                cb.SelectedIndex = index;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
            }
        }

        //Selecciona el item segun el identificador
        public static void comboSeleccionarItemByIdentificador(string identificador, ref ComboBox cb)
        {
            try
            {
                DataTable dt = (DataTable)cb.DataSource;
                int index = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["identificador"].ToString() == identificador)
                    {
                        index = i;
                        break;
                    }
                }
                cb.SelectedIndex = index;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
            }
        }

        //Selecciona el item segun el ID
        public static void comboSeleccionarItemById(Guid id, ref ComboBox cb)
        {
            try
            {
                DataTable dt = (DataTable)cb.DataSource;
                int index = -1;
                
                if (dt!=null)
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["id"].ToString() == id.ToString())
                        {
                            index = i;
                            break;
                        }
                    }
                cb.SelectedIndex = index;

                dt = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
            }
        }

        //Selecciona el item segun el ID
        public static void listBoxSeleccionarItemById(Guid id, ref ListBox cb)
        {
            try
            {
                DataTable dt = (DataTable)cb.DataSource;
                int index = -1;

                if (dt != null)
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["id"].ToString() == id.ToString())
                        {
                            index = i;
                            break;
                        }
                    }
                cb.SelectedIndex = index;

                dt = null;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
            }
        }

        //Obtiene el ID del item seleccionado
        public static string comboObtenerID(ref ComboBox cb)
        {
            string resultado = Utilidades.ID_VACIO;
            DataTable dt = (DataTable)cb.DataSource;
            if (dt != null)
                if (dt.Rows.Count > 0 && cb.SelectedIndex>-1)
                    resultado = dt.Rows[cb.SelectedIndex]["ID"].ToString();

            dt = null;
            return resultado;
        }

        //Obtiene el ID del item seleccionado
        public static string listBoxObtenerID(ref ListBox cb)
        {
            string resultado = Utilidades.ID_VACIO;
            DataTable dt = (DataTable)cb.DataSource;
            if (dt != null)
                if (dt.Rows.Count > 0 && cb.SelectedIndex > -1)
                    resultado = dt.Rows[cb.SelectedIndex]["ID"].ToString();

            dt = null;
            return resultado;
        }

        public static void llenarCombo(ref ComboBox combo, string conexion, string sp, string etiquetaDefault, int valorDefault, string filtro)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@filtro", filtro);
            llenarCombo(ref combo, conexion, sp, etiquetaDefault, valorDefault.ToString(), param);
        }

        public static void llenarCombo(ref ComboBox combo, string conexion, string sp, string etiquetaDefault, int valorDefault, SqlParameter[] param)
        {
            llenarCombo(ref combo, conexion, sp, etiquetaDefault, valorDefault.ToString(), param);
        }

        public static void llenarCombo(ref ComboBox combo, string conexion, string sp, string etiquetaDefault, int valorDefault)
        {
            llenarCombo(ref combo, conexion, sp, etiquetaDefault, valorDefault.ToString(), null);
        }

        public static void llenarCombo(ref ComboBox combo, string conexion, string sp, string etiquetaDefault, string valorDefault)
        {
            llenarCombo(ref combo, conexion, sp, etiquetaDefault, valorDefault, null);
        }

        public static void llenarCombo(ref ComboBox combo, string conexion, string sp, string etiquetaDefault, string valorDefault, SqlParameter[] param)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(conexion, sp, param);

                if (valorDefault != "-1" && etiquetaDefault != "")
                {
                    if (valorDefault.Length < "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx".Length)
                        valorDefault = Utilidades.ID_VACIO;

                    DataRow dr = ds.Tables[0].NewRow();
                    dr["id"] = valorDefault;
                    dr["descripcion"] = etiquetaDefault;
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                }

                combo.DisplayMember = "descripcion";
                combo.ValueMember = "id";
                combo.DataSource = ds.Tables[0];

                if (valorDefault == "-1" || valorDefault == "0")
                {
                    if (combo.Items.Count > 0)
                        combo.SelectedIndex = 0; //Selecciona el primer elemento.
                }//combo.SelectedIndex = -1;
                else
                    if (etiquetaDefault == "")
                        combo.SelectedValue = valorDefault;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
            }
        }

        public static void llenarListBox(ref ListBox combo, string conexion, string sp, string etiquetaDefault, int valorDefault, string filtro)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@filtro", filtro);
            llenarListBox(ref combo, conexion, sp, etiquetaDefault, valorDefault.ToString(), param);
        }

        public static void llenarListBox(ref ListBox combo, string conexion, string sp, string etiquetaDefault, int valorDefault)
        {
            llenarListBox(ref combo, conexion, sp, etiquetaDefault, valorDefault.ToString());
        }
        public static void llenarListBox(ref ListBox combo, string conexion, string sp, string etiquetaDefault, string valorDefault)
        {
            llenarListBox(ref combo, conexion, sp, etiquetaDefault, valorDefault, null);
        }

        public static void llenarListBox(ref ListBox combo, string conexion, string sp, string etiquetaDefault, int valorDefault, SqlParameter[] param)
        {
            llenarListBox(ref combo, conexion, sp, etiquetaDefault, valorDefault.ToString(), param);
        }

        public static void llenarListBox(ref ListBox combo, string conexion, string sp, string etiquetaDefault, string valorDefault, SqlParameter[] param)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(conexion, sp, param);

                if (valorDefault != "-1" && etiquetaDefault != "")
                {
                    if (valorDefault.Length < "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx".Length)
                        valorDefault = Utilidades.ID_VACIO;

                    DataRow dr = ds.Tables[0].NewRow();
                    dr["id"] = valorDefault;
                    dr["descripcion"] = etiquetaDefault;
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                }

                combo.DisplayMember = "descripcion";
                combo.ValueMember = "id";
                combo.DataSource = ds.Tables[0];

                if (valorDefault == "-1")
                    combo.SelectedIndex = -1;
                else
                    if (etiquetaDefault == "")
                        combo.SelectedValue = valorDefault;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
            }
        }


        public static void llenarCheckedListBox(ref CheckedListBox combo, string conexion, string sp, string etiquetaDefault, int valorDefault)
        {
            llenarCheckedListBox(ref combo, conexion, sp, etiquetaDefault, valorDefault.ToString());
        }
        public static void llenarCheckedListBox(ref CheckedListBox combo, string conexion, string sp, string etiquetaDefault, string valorDefault)
        {
            llenarCheckedListBox(ref combo, conexion, sp, etiquetaDefault, valorDefault, null);
        }

        public static void llenarCheckedListBox(ref CheckedListBox combo, string conexion, string sp, string etiquetaDefault, string valorDefault, SqlParameter[] param)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(conexion, sp, param);

                if (valorDefault != "-1" && etiquetaDefault != "")
                {
                    if (valorDefault.Length < "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx".Length)
                        valorDefault = Utilidades.ID_VACIO;

                    DataRow dr = ds.Tables[0].NewRow();
                    dr["id"] = valorDefault;
                    dr["descripcion"] = etiquetaDefault;
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                }
                //Crea la primary key
                DataColumn[] pk = new DataColumn[1];
                pk[0] = ds.Tables[0].Columns["id"];
                ds.Tables[0].PrimaryKey = pk;

                combo.DataSource = ds.Tables[0];
                combo.DisplayMember = "descripcion";
                combo.ValueMember = "id";

                if (valorDefault == "-1")
                    combo.SelectedIndex = -1;
                else
                    if (etiquetaDefault == "")
                        combo.SelectedValue = valorDefault;
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
            }
        }


        //Asegura que haya solo una instancia de cada formulario
        public static Form abrirFormulario(Form frmMDI, Form frmAbrir, Configuracion configuracion)
        {
            try
            {
                //Contorla que se haya iniciado la caja
                frmMDI.Cursor = Cursors.WaitCursor;

                foreach (Form frm in frmMDI.MdiChildren)
                {
                    if (frm.Name == frmAbrir.Name)
                    {
                        frmAbrir = frm;
                        break;
                    }
                }

                frmAbrir.MdiParent = frmMDI;
                frmAbrir.Show();
                frmAbrir.Focus();

                //UtilUI.cambiarColorFondo(this, configuracion);

                frmMDI.Cursor = Cursors.Arrow;

                return frmAbrir;

            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, configuracion);
                return null;
            }
        }

        public static string fechaCanonicaSQL(DateTime fecha) {
            string hora = fecha.Hour.ToString("00");
            string minuto = fecha.Minute.ToString("00");
            string segundo = fecha.Second.ToString("00");

            return fechaCanonicaSQL(fecha, hora + ":" + minuto + ":" + segundo);
        }

        public static string fechaCanonicaSQL(DateTime fecha, string hora)
        {
            string dia = fecha.Day.ToString("00");
            string mes = fecha.Month.ToString("00");
            string anio = fecha.Year.ToString("0000");
            return "{ts '" + anio + "-" + mes + "-" + dia + " " + hora + "'}";
        }

        public static string fechaAAAAMMDD(DateTime fecha)
        {
            string dia = fecha.Day.ToString("00");
            string mes = fecha.Month.ToString("00");
            string anio = fecha.Year.ToString("0000");
            return anio + "-" + mes + "-" + dia + " ";
        }

        public static string diaSemana(DayOfWeek dia)
        {
            string resultado = "";
            switch (dia)
            {
                case DayOfWeek.Monday:
                    resultado = "Lunes";
                    break;
                case DayOfWeek.Tuesday:
                    resultado = "Martes";
                    break;
                case DayOfWeek.Wednesday:
                    resultado = "Miercoles";
                    break;
                case DayOfWeek.Thursday:
                    resultado = "Jueves";
                    break;
                case DayOfWeek.Friday:
                    resultado = "Viernes";
                    break;
                case DayOfWeek.Saturday:
                    resultado = "Sabado";
                    break;
                case DayOfWeek.Sunday:
                    resultado = "Domingo";
                    break;
            }

            return resultado;
        }

        //Ejecuta un comando shell
        public static void shell(string file, string mensaje)
        {
            shell(file, mensaje, AppDomain.CurrentDomain.BaseDirectory);
        }
        public static void shell(string file, string mensaje, string path)
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = path + file;
                proc.Start();
                proc.WaitForExit();
                MessageBox.Show(mensaje, "Comandos externos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true);
            }
        }

	}
}