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
    class Seguridad
    {
        public Configuracion configuracion;

        public Seguridad(Configuracion conf)
        {
            this.configuracion = conf;
        }

        //Verifica el nivel de acceso a cierto punto del sistema
        public bool verificarPermiso(string objetoSitema, string operacion)
        {
            bool accesoConcedido = false;
            try
            {
                //Busca si existe l permiso requerido
                bool permiso = recorrerPermisos(objetoSitema, operacion);

                //Si no existe, muestra el inicio de sesion
                if (!permiso)
                {
                    //Crea el formulario de login
                    frmLogin form = new frmLogin(this.configuracion);

                    //Crea y asigna el Delegate
                    form.objDelegateDevolverID = new Comunes.frmLogin.DelegateDevolverID(verificarPermiso_usuarioValidado);

                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.OK)
                    {
                        if (this.configuracion.usuario!=null)
                            if (recorrerPermisos(objetoSitema, operacion))
                                accesoConcedido = true;
                    }
                }
                else
                    accesoConcedido = true;


                if (!accesoConcedido)
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
                bool terminar = false;
                foreach (SeguridadPerfil perfil in this.configuracion.usuario.perfiles)
                {
                    foreach (SeguridadPerfilItem item in perfil.items)
                    {
                        if (item.objeto.identificador == objetoSistema && item.operacion.identificador == operacion)
                        {
                            permiso = true;
                            terminar = true;
                            Application.DoEvents();
                            break;
                        }
                        if (terminar)
                            break;
                    }
                }
                return permiso;
            }
            catch (Exception e)
            {
                ManejadorErrores.escribirLog(e, true);
                return permiso;
            }
        }
        //Define si el usuario fue validado o no
        private void verificarPermiso_usuarioValidado(Usuario usuario)
        {
            try
            {

                this.configuracion.usuario = usuario;

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
