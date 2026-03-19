using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace Migrador
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 🔥 Habilitar soporte para codificaciones (UTF-8, etc.)
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());
        }
    }
}