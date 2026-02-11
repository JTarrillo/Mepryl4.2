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
    public class Seguridad
    {
        public Configuracion configuracion;

        public Seguridad(Configuracion conf)
        {
            this.configuracion = conf;
        }

        //Verifica el nivel de acceso a cierto punto del sistema
        public bool verificarPermiso(string objetSistema, string operacion)
        {
            return verificarPermiso(objetSistema, operacion, "");
        }
        public bool verificarPermiso(string objetSistema, string operacion, string mensaje)
        {
            return verificarPermiso(objetSistema, operacion, mensaje, false);
        }
        public bool verificarPermiso(string objetSistema, string operacion, string mensaje, bool mostrarLogin)
        {
            return verificarPermiso(objetSistema, operacion, mensaje, false, false);
        }
        public bool verificarPermiso(string objetoSitema, string operacion, string mensaje, bool mostrarLogin, bool mostrarMensaje)
        {
            bool accesoConcedido = false;
            try
            {
                //Busca si existe l permiso requerido
                bool permiso = recorrerPermisos(objetoSitema, operacion);

                //Si no existe, muestra el inicio de sesion
                if (!permiso)
                {
                    if (mostrarLogin)
                    {
                        //Crea el formulario de login
                        frmLogin form = new frmLogin(this.configuracion, mensaje);

                        //Crea y asigna el Delegate
                        form.objDelegateDevolverID = new Comunes.frmLogin.DelegateDevolverID(verificarPermiso_usuarioValidado);

                        form.ShowDialog();

                        if (form.DialogResult == DialogResult.OK)
                        {
                            if (Configuracion.usuario != null)
                                if (recorrerPermisos(objetoSitema, operacion))
                                    accesoConcedido = true;
                        }
                    }
                }
                else
                    accesoConcedido = true;


                if (!accesoConcedido)
                    if (mostrarMensaje)
                        MessageBox.Show("Usted no tiene los permisos necesarios para realizar esta operación.\r\nPor favor, solicite ayuda al supervisor.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return accesoConcedido;
            }
            catch (Exception e)
            {
                ManejadorErrores.escribirLog(e, true);
                return accesoConcedido;
            }
        }

        //Recorre los permisos
        private bool recorrerPermisos(string objetoSistema, string operacion)
        {
            bool permiso = false;
            try
            {
                Console.WriteLine("Entro al try");
                bool terminar = false;
                if (Configuracion.usuario.perfiles != null)
                {
                    Console.WriteLine("Entro al primero");
                    foreach (SeguridadPerfil perfil in Configuracion.usuario.perfiles)
                    {
                        Console.WriteLine("Entro al segundo");
                        if (perfil.items != null)
                        {
                            Console.WriteLine("Entro al tercero");
                            foreach (SeguridadPerfilItem item in perfil.items)
                            {
                                Console.WriteLine("Entro al cuarto");
                                Console.WriteLine("item.objeto.identificador=" + item.objeto.identificador + ", item.operacion.identificador=" + item.operacion.identificador);
                                if (item.objeto.identificador == objetoSistema && item.operacion.identificador == operacion)
                                {
                                    Console.WriteLine("Entro al quinto y ultimo");
                                    permiso = true;
                                    terminar = true;
                                    Application.DoEvents();
                                    break;
                                }
                                if (terminar)
                                    break;
                            }
                        }
                    }
                }
                return permiso;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ManejadorErrores.escribirLog(e, true);
                return permiso;
            }
        }
        //Define si el usuario fue validado o no
        private void verificarPermiso_usuarioValidado(Usuario usuario)
        {
            try
            {

                Configuracion.usuario = usuario;

                if (usuario == null)
                {
                    //this.Close();
                }

                //Toma el nombre del usuario
                //this.Text = this.Text + " - " + usuario.apellido + ", " + usuario.nombre + " [v" + this.configuracion.obtenerFechaCompilacion() + "]";
            }
            catch (Exception e)
            {
                ManejadorErrores.escribirLog(e, true);
            }
        }

    }
}
