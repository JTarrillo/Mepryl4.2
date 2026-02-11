using System;
using Comunes;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
namespace Comunes
{
	/// <summary>
	/// Summary description for ManejadorErrores.
	/// </summary>
	public class ManejadorErrores
	{
		public ManejadorErrores()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public static void escribirLog(Exception e, bool mostrarVentana)
		{
			escribirLog(e, mostrarVentana, null);
		}
		public static void escribirLog(Exception e, bool mostrarVentana, Configuracion config)
		{

            string logFolder = Path.Combine(
           Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
           "MEPRYL4.0"
           );
            Directory.CreateDirectory(logFolder);
            string archivo = Path.Combine(logFolder, "Errores.log");
            StreamWriter sw;


            try
            {
                //Si no existe, lo crea
                if (!File.Exists(archivo))
                    sw = File.CreateText(archivo);
                else
                    sw = File.AppendText(archivo);


                //Prepara el texto a escribir
                string texto = DateTime.Now.ToString() + ", " + e.TargetSite.DeclaringType.FullName + "." + e.TargetSite.Name + "(), " + e.Message + "\r\n" +
                                e.StackTrace + "\r\n\r\n";

                //Escribe el archivo
                sw.Write(texto);

                sw.Close();
            }
            catch (Exception e1) {

                MessageBox.Show(e1.Message);
                MessageBox.Show(e.Message);
            }

			//Muestra la ventana de error al usuario
			if (mostrarVentana)
			{
                try
                {
                    frmManejadorErrores f = new frmManejadorErrores();
                    f.Modulo.Text = e.TargetSite.DeclaringType.FullName + "." + e.TargetSite.Name + "()";
                    f.Mensaje.Text = e.Message;
                    f.PilaLlamadas.Text = e.StackTrace;

                    if (config != null)
                    {
                        f.configuracion = config;
                        f.butEnviarMail.Enabled = true;
                    }
                    //f.ShowDialog();
                }
                catch (Exception e2) {
                    MessageBox.Show("Error" + e.Message);
                }
			}

		}
	}
}
