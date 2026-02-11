using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    class MsgBoxUtil
    {
        #region Interoperabilidad
        /// <summary>Delegado para pasar funciones coom parametro a llmados de la api</summary>
        private delegate bool EnumWindowDelegate(IntPtr handler, IntPtr longPointer);

        /// <summary>Establece el texto de una ventana</summary>
        [DllImport("user32.dll")]
        private static extern bool SetWindowText(IntPtr handler, string texto);

        /// <summary>Obtiene el nombre de la clase de una ventana</summary>
        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr handler, StringBuilder nombre, int tamañoMaximo);

        /// <summary>Realiza un listado de las ventanas hijas y por cada una ejecuta un callback asociado</summary>
        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows(IntPtr handler, EnumWindowDelegate callback, IntPtr longPointer);

        /// <summary>Realiza un listado de las ventanas del hilo actual por cada una ejecuta un callback asociado</summary>
        [DllImport("user32.dll")]
        private static extern bool EnumThreadWindows(int threadID, EnumWindowDelegate callback, IntPtr longPointer);

        /// <summary>Obtiene el ID del hilo actual</summary>
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();

        /// <summary>Realiza un listado de las ventanas y por cada una ejecuta un callback asociado</summary>
        [DllImport("user32.dll")]
        static extern bool EnumWindows(EnumWindowDelegate lpEnumFunc, IntPtr lParam);
        #endregion Interoperabilidad

        #region Objetos locales
        /// <summary>Array que almacena los textosque se colocaran a cada uno de los botones del msgbox</summary>
        private static string[] textoBotones;
        /// <summary>Indica cual de los botones se esta actualizando</summary>
        private static int indiceTexto;
        /// <summary>Delegado para buscar e iniciar el proceso de cambio de textos en aplicaciones forms</summary>
        private delegate void BuscarMsgBoxDelegate();
        #endregion Objetos locales

        #region Constantes
        /// <summary>Nombre de la clase de la ventana de un messagebox</summary>
        private const string MBOX_CLASSNAME = "#32770";
        /// <summary>Nombre de la clase de la ventana de un boton</summary>
        private const string BUTTON_CLASSNAME = "Button";
        /// <summary>Capacidad máxima para StringBuilders</summary>
        private const int STRING_BUILDER_CAPACITY = 256;
        #endregion Constantes

        #region Métodos Públicos
        /// <summary>
        /// Modifica el texto de los botones de un messagebox
        /// </summary>
        /// <param name="textoBotones">lista de labels para los botones</param>
        /// <remarks>Internamente se llama a EsperarYCambiarMsgBoxWC
        /// que es un WaitCallBack que llama a EsperarYCambiarMsgBox</remarks>
        public static void HackMessageBox(params string[] textoBotones)
        {
            //guardar referencia global a la lista
            MsgBoxUtil.textoBotones = textoBotones;
            //Si hay al menos una forma... se debe trabajar como aplicación forms
            if (Application.OpenForms.Count > 0)
                //Se llama el delegado desde el hilo actual de forms
                Application.OpenForms[0].BeginInvoke(new BuscarMsgBoxDelegate(BuscaMessageBox));
        }

        #endregion #region Métodos Públicos

        #region Métodos Privados
        /// <summary>Wrapper para simplificar el llamado a EnumThreadWindows desde HackMessageBox</summary>
        private static void BuscaMessageBox()
        {
            EnumThreadWindows(GetCurrentThreadId(), ProcesaMessageBoxEnForms, IntPtr.Zero);
        }

        /// <summary>
        /// Determina si el handler pasado es un messagebox, 
        /// si es así inicia el proceso de modificacion de texto de los botones
        /// </summary>
        /// <param name="handler">manejador de la ventana</param>
        /// <param name="longPointer">no se usa, pero se requiere como signature de delegado</param>
        /// <returns>Si el handle pasado no es un MessageBox devuelve true, false de lo contrario</returns>
        private static bool ProcesaMessageBoxEnForms(IntPtr handler, IntPtr longPointer)
        {
            //almacenar nombre de la clase
            StringBuilder nombreClase = new StringBuilder(STRING_BUILDER_CAPACITY);
            GetClassName(handler, nombreClase, nombreClase.Capacity);

            //Si no es un MessageBox...
            if (nombreClase.ToString() != MBOX_CLASSNAME)
                return true;
            else
            {
                //Inicializar indice del arreglo
                indiceTexto = 0;
                //Buscar y cambiar Botones del MessageBox
                EnumChildWindows(handler, CambiaTextoBotonMessageBox, IntPtr.Zero);
                return false;
            }
        }

        /// <summary>
        /// Cambia el texto del boton recibido como parámetro de acuerdo al listado
        /// de valores iniciales al llamr a HackMessageBox
        /// </summary>
        /// <param name="handler">Manejador del boton</param>
        /// <param name="longPointer">no se usa, pero se requiere como signature de los delegados</param>
        /// <returns>siempre true</returns>
        private static bool CambiaTextoBotonMessageBox(IntPtr handler, IntPtr longPointer)
        {
            //almacenar nombre de la clase
            StringBuilder nombreClase = new StringBuilder(STRING_BUILDER_CAPACITY);
            GetClassName(handler, nombreClase, nombreClase.Capacity);

            //Si el handler es de un boton se modifica el texto
            if (nombreClase.ToString() == BUTTON_CLASSNAME && indiceTexto < textoBotones.Length)
            {
                SetWindowText(handler, textoBotones[indiceTexto]);
                indiceTexto++;
            }
            return true;
        }
        #endregion Métodos Privados
    }
}
