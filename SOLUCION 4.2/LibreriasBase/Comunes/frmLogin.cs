using Comunes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comunes
{
    public partial class frmLogin : Form
    {

        private Configuracion configuracion;
        private Usuario usuario = null;
        private Timer fotoTimer = new Timer();
        //Define el Delegado 
        public delegate void DelegateDevolverID(Usuario usuario);
        public DelegateDevolverID objDelegateDevolverID = null;

        // Variable para guardar la IP detectada
        private string ipDetectada = "";


        public frmLogin(Configuracion conf)
        {
            inicializar(conf, "");
            // ...existing code...
            fotoTimer.Interval = 400; // 400 ms de espera
            fotoTimer.Tick += FotoTimer_Tick;
            this.Load += frmLogin_Load;
        }

        public frmLogin(Configuracion conf, string mensaje)
        {
            inicializar(conf, mensaje);
            this.Load += frmLogin_Load;
        }
        // Evento Load para detectar IP y guardar en base de datos
        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Registro de equipo/IP se realiza solo al validar usuario para evitar duplicados
        }

        // Método para actualizar el campo IpEquipo en la versión más reciente de ActualizacionesSistema
        private void GuardarIPEnBaseDeDatos(string ip, string nombreEquipo)
        {
            try
            {
                using (var conn = new System.Data.SqlClient.SqlConnection(configuracion.getConectionString()))
                {
                    conn.Open();
                    // Leer la versión máxima disponible en la carpeta de instaladores
                    string path = @"S:\PUBLICO\INSTALADORES MEPRYL";
                    string versionMaxima = "0.0";
                    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"MEPRYL(\d+\.\d+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    if (System.IO.Directory.Exists(path))
                    {
                        foreach (var dir in System.IO.Directory.GetDirectories(path))
                        {
                            var match = regex.Match(System.IO.Path.GetFileName(dir));
                            if (match.Success)
                            {
                                string version = match.Groups[1].Value;
                                if (string.Compare(version, versionMaxima) > 0)
                                    versionMaxima = version;
                            }
                        }
                    }

                    // Verificar si ya existe registro para esta versión y equipo
                    string sqlCheck = "SELECT COUNT(*) FROM ActualizacionesSistema WHERE Version = @version AND NombreEquipo = @nombreEquipo";
                    using (var cmdCheck = new System.Data.SqlClient.SqlCommand(sqlCheck, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@version", versionMaxima);
                        cmdCheck.Parameters.AddWithValue("@nombreEquipo", nombreEquipo);
                        int count = (int)cmdCheck.ExecuteScalar();
                        if (count == 0)
                        {
                            // Insertar nuevo registro
                            string sqlInsert = "INSERT INTO ActualizacionesSistema (Version, Mensaje, RutaInstalador, Fecha, Estado, NombreEquipo) VALUES (@version, @mensaje, @ruta, GETDATE(), 1, @nombreEquipo)";
                            using (var cmdInsert = new System.Data.SqlClient.SqlCommand(sqlInsert, conn))
                            {
                                cmdInsert.Parameters.AddWithValue("@version", versionMaxima);
                                cmdInsert.Parameters.AddWithValue("@mensaje", "Actualización importante: Instale la nueva versión desde la carpeta indicada.");
                                cmdInsert.Parameters.AddWithValue("@ruta", $"{path}\\MEPRYL{versionMaxima}");
                                cmdInsert.Parameters.AddWithValue("@nombreEquipo", nombreEquipo);
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void inicializar(Configuracion conf, string mensaje)
        {
            //
            // Required for Windows Form Designer support
            //

            this.configuracion = conf;

            InitializeComponent();

            if (mensaje != "")
            {
                lbMensaje.Text = mensaje;
                this.Text = mensaje;
            }

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void butAceptar_Click(object sender, System.EventArgs e)
        {
            validarUsuario();
        }

        //Valida el usuario contra la base de datos
        private void validarUsuario()
        {
            UsuarioFactory uf = new UsuarioFactory();

            uf.strConexion = configuracion.getConectionString();

            if (uf.UsuarioActivo(tbNombre.Text.Trim()))
            {
                if (uf.validarUsuario(tbNombre.Text.Trim(), tbClave.Text.Trim()))
                {
                    RegistrarVersionInstalada();
                    RegistrarEquipoActualizacion();
                    VerificarVersionNueva();
                    this.DialogResult = DialogResult.OK;
                    this.usuario = new UsuarioDatos().ObtenerUsuarioPorUsername(tbNombre.Text.Trim());
                    UsuarioDatos.UsuarioSistema = this.usuario.username;
                    this.Close();
                }
                else
                {
                    this.usuario = null;
                    MessageBox.Show("El nombre de usuario o la contraseña no son correctos. Por favor inténtelo nuevamente.", "No se pudo iniciar la sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (!string.IsNullOrEmpty(tbNombre.Text))
                    {
                        tbNombre.Focus();
                        tbNombre.SelectionStart = 0;
                        tbNombre.SelectionLength = tbNombre.Text.Length;
                    }
                }
            }
            else
            {
                this.usuario = null;
                MessageBox.Show("El usuario no esta activo\nContacte con el Administrador.", "No se pudo iniciar la sesiòn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (!string.IsNullOrEmpty(tbNombre.Text))
                {
                    tbNombre.Focus();
                    tbNombre.SelectionStart = 0;
                    tbNombre.SelectionLength = tbNombre.Text.Length;
                }
            }
        }

        // Registrar equipo/IP y versión en ActualizacionesSistema si no existe
        // Registra la versión instalada con estado 0 y nuevas versiones con estado 1
        private void RegistrarVersionInstalada()
        {
            string nombreEquipo = Environment.MachineName;
            string ipLocal = "";
            try
            {
                ipLocal = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                    .Where(ni => ni.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                    .SelectMany(ni => ni.GetIPProperties().UnicastAddresses)
                    .Where(ip => ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !ip.Address.ToString().StartsWith("169.254"))
                    .Select(ip => ip.Address.ToString())
                    .FirstOrDefault();
            }
            catch { }
            if (string.IsNullOrEmpty(ipLocal))
                ipLocal = "SIN_IP";

            try
            {
                using (var conn = new System.Data.SqlClient.SqlConnection(configuracion.getConectionString()))
                {
                    conn.Open();
                    // Verificar si ya existe registro para esta versión y equipo/IP
                    string sqlCheck = "SELECT Estado FROM ActualizacionesSistema WHERE Version = @version AND NombreEquipo = @nombreEquipo AND IP = @ip";
                    using (var cmdCheck = new System.Data.SqlClient.SqlCommand(sqlCheck, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@version", VersionApp.VERSION);
                        cmdCheck.Parameters.AddWithValue("@nombreEquipo", nombreEquipo);
                        cmdCheck.Parameters.AddWithValue("@ip", ipLocal ?? "");
                        var result = cmdCheck.ExecuteScalar();
                        if (result == null)
                        {
                            // Insertar nuevo registro con estado 0
                            string sqlInsert = "INSERT INTO ActualizacionesSistema (Version, Mensaje, RutaInstalador, Fecha, Estado, NombreEquipo, IP) VALUES (@version, @mensaje, @ruta, GETDATE(), 0, @nombreEquipo, @ip)";
                            using (var cmdInsert = new System.Data.SqlClient.SqlCommand(sqlInsert, conn))
                            {
                                cmdInsert.Parameters.AddWithValue("@version", VersionApp.VERSION);
                                cmdInsert.Parameters.AddWithValue("@mensaje", "Versión instalada correctamente.");
                                cmdInsert.Parameters.AddWithValue("@ruta", "");
                                cmdInsert.Parameters.AddWithValue("@nombreEquipo", nombreEquipo);
                                cmdInsert.Parameters.AddWithValue("@ip", ipLocal ?? "");
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                        else if (Convert.ToInt32(result) != 0)
                        {
                            // Si existe y está en estado 1, actualizar a 0
                            string sqlUpdate = "UPDATE ActualizacionesSistema SET Estado = 0 WHERE Version = @version AND NombreEquipo = @nombreEquipo AND IP = @ip";
                            using (var cmdUpdate = new System.Data.SqlClient.SqlCommand(sqlUpdate, conn))
                            {
                                cmdUpdate.Parameters.AddWithValue("@version", VersionApp.VERSION);
                                cmdUpdate.Parameters.AddWithValue("@nombreEquipo", nombreEquipo);
                                cmdUpdate.Parameters.AddWithValue("@ip", ipLocal ?? "");
                                cmdUpdate.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch { }
        }

        // Registra la versión máxima disponible con estado 1 si es mayor que la instalada
        private void RegistrarEquipoActualizacion()
        {
            string path = @"S:\PUBLICO\INSTALADORES MEPRYL";
            string versionMaxima = "0.0";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"MEPRYL(\d+\.\d+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (System.IO.Directory.Exists(path))
            {
                foreach (var dir in System.IO.Directory.GetDirectories(path))
                {
                    var match = regex.Match(System.IO.Path.GetFileName(dir));
                    if (match.Success)
                    {
                        string version = match.Groups[1].Value;
                        if (string.Compare(version, versionMaxima) > 0)
                            versionMaxima = version;
                    }
                }
            }

            // Solo registrar si la versión máxima es mayor que la instalada
            if (string.Compare(VersionApp.VERSION, versionMaxima) < 0)
            {
                string nombreEquipo = Environment.MachineName;
                string ipLocal = "";
                try
                {
                    ipLocal = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                        .Where(ni => ni.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                        .SelectMany(ni => ni.GetIPProperties().UnicastAddresses)
                        .Where(ip => ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !ip.Address.ToString().StartsWith("169.254"))
                        .Select(ip => ip.Address.ToString())
                        .FirstOrDefault();
                }
                catch { }
                if (string.IsNullOrEmpty(ipLocal))
                    ipLocal = "SIN_IP";

                try
                {
                    using (var conn = new System.Data.SqlClient.SqlConnection(configuracion.getConectionString()))
                    {
                        conn.Open();
                        // Verificar si ya existe registro para esta versión y equipo/IP
                        string sqlCheck = "SELECT COUNT(*) FROM ActualizacionesSistema WHERE Version = @version AND NombreEquipo = @nombreEquipo AND IP = @ip";
                        using (var cmdCheck = new System.Data.SqlClient.SqlCommand(sqlCheck, conn))
                        {
                            cmdCheck.Parameters.AddWithValue("@version", versionMaxima);
                            cmdCheck.Parameters.AddWithValue("@nombreEquipo", nombreEquipo);
                            cmdCheck.Parameters.AddWithValue("@ip", ipLocal ?? "");
                            int count = (int)cmdCheck.ExecuteScalar();
                            if (count == 0)
                            {
                                // Insertar nuevo registro con estado 1
                                string sqlInsert = "INSERT INTO ActualizacionesSistema (Version, Mensaje, RutaInstalador, Fecha, Estado, NombreEquipo, IP) VALUES (@version, @mensaje, @ruta, GETDATE(), 1, @nombreEquipo, @ip)";
                                using (var cmdInsert = new System.Data.SqlClient.SqlCommand(sqlInsert, conn))
                                {
                                    cmdInsert.Parameters.AddWithValue("@version", versionMaxima);
                                    cmdInsert.Parameters.AddWithValue("@mensaje", "Actualización importante: Instale la nueva versión desde la carpeta indicada.");
                                    cmdInsert.Parameters.AddWithValue("@ruta", $"{path}\\MEPRYL{versionMaxima}");
                                    cmdInsert.Parameters.AddWithValue("@nombreEquipo", nombreEquipo);
                                    cmdInsert.Parameters.AddWithValue("@ip", ipLocal ?? "");
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void butSalir_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbNombre_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Enter
            {
                CargarFotoUsuario();
                tbClave.Focus();
            }
        }

        private void tbClave_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                butAceptar_Click(null, null);
                e.Handled = true;
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                this.DialogResult = DialogResult.Cancel;

            //Devuelve objeto Usuario
            if (objDelegateDevolverID != null)
                objDelegateDevolverID(this.usuario);
        }

        private void tbClave_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbClave.Text))
            {
                tbClave.SelectionStart = 0;
                tbClave.SelectionLength = tbClave.Text.Length;
            }
        }

        private void lblCambiarContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNombre.Text))
            {
                frmCambioContrasena frm = new frmCambioContrasena(tbNombre.Text);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe ingresar el nombre de usuario, para poder continuar", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            fotoTimer.Stop();
            fotoTimer.Start();
        }

        private void FotoTimer_Tick(object sender, EventArgs e)
        {
            fotoTimer.Stop();
            if (!string.IsNullOrWhiteSpace(tbNombre.Text))
            {
                UsuarioFactory uf = new UsuarioFactory();
                uf.strConexion = configuracion.getConectionString();
                if (uf.UsuarioActivo(tbNombre.Text.Trim()))
                {
                    CargarFotoUsuario();
                }
            }
        }
        private void tbNombre_Leave(object sender, EventArgs e)
        {
            CargarFotoUsuario();
        }

        private void CargarFotoUsuario()
        {
            UsuarioFactory uf = new UsuarioFactory();
            string strPathFoto = uf.DevuelveFoto(tbNombre.Text);
            if (System.IO.File.Exists(strPathFoto))
            {
                cargarImagen(strPathFoto);
            }
            else
            {
                cargarImagen("P:\\img-system\\mUsuarioLogin.png");
            }
        }
        // Eliminado: ahora la versión se maneja por constante VERSION_APP
        private void cargarImagen(string strPath)
        {
            try
            {
                //GRV - Ram�rez - Modificado
                //FileStream fs = new System.IO.FileStream(@"S:/FOTOS/" + tbDNI.Text + ".jpg", FileMode.Open, FileAccess.Read);
                System.IO.FileStream fs = new System.IO.FileStream(strPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                pictureBox1.Image = Image.FromStream(fs);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                fs.Close();
                
                // Agregar indicador de PRUEBA si aplica
                AgregarIndicadorPrueba();
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        // Método para agregar un indicador visual de "PRUEBA" en la esquina superior derecha de la imagen
        private void AgregarIndicadorPrueba()
        {
            if (pictureBox1.Image != null && VersionApp.VERSION.Contains("Prueba"))
            {
                try
                {
                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        // Crear un rectángulo rojo en la esquina superior derecha
                        int rectSize = 50;
                        Rectangle rectPrueba = new Rectangle(bmp.Width - rectSize - 5, 5, rectSize, rectSize);
                        
                        // Dibujar fondo rojo
                        g.FillRectangle(new SolidBrush(Color.Red), rectPrueba);
                        
                        // Dibujar borde negro
                        g.DrawRectangle(new Pen(Color.Black, 2), rectPrueba);
                        
                        // Dibujar texto "PRUEBA"
                        string textoPrueba = "PRUEBA";
                        Font fontPrueba = new Font("Arial", 8, FontStyle.Bold);
                        SizeF textSize = g.MeasureString(textoPrueba, fontPrueba);
                        
                        float x = rectPrueba.X + (rectPrueba.Width - textSize.Width) / 2;
                        float y = rectPrueba.Y + (rectPrueba.Height - textSize.Height) / 2;
                        
                        g.DrawString(textoPrueba, fontPrueba, Brushes.White, x, y);
                    }
                    pictureBox1.Image = bmp;
                }
                catch { }
            }
        }

        private void tbNombre_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbNombre.Text))
            {
                tbNombre.SelectionStart = 0;
                tbNombre.SelectionLength = tbNombre.Text.Length;
            }
        }

        // Método para verificar si existe una versión nueva y mostrar ventana solo si Estado=1 para la IP/equipo actual
        private void VerificarVersionNueva()
        {
            try
            {
                // Leer la versión máxima disponible en la carpeta de instaladores
                string path = @"S:\PUBLICO\INSTALADORES MEPRYL";
                string versionMaxima = "0.0";
                string mensaje = "Actualización importante: Instale la nueva versión desde la carpeta indicada.";
                string rutaInstalador = path;
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"MEPRYL(\d+\.\d+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                if (System.IO.Directory.Exists(path))
                {
                    foreach (var dir in System.IO.Directory.GetDirectories(path))
                    {
                        var match = regex.Match(System.IO.Path.GetFileName(dir));
                        if (match.Success)
                        {
                            string version = match.Groups[1].Value;
                            if (string.Compare(version, versionMaxima) > 0)
                                versionMaxima = version;
                        }
                    }
                }

                // Obtener nombre de equipo local
                string nombreEquipo = Environment.MachineName;

                // Solo mostrar la ventana si la versión instalada es menor que la máxima y Estado = 1
                if (string.Compare(VersionApp.VERSION, versionMaxima) < 0)
                {
                    int estado = 0;
                    try
                    {
                        using (var conn = new System.Data.SqlClient.SqlConnection(configuracion.getConectionString()))
                        {
                            conn.Open();
                            string sql = @"SELECT TOP 1 Estado FROM ActualizacionesSistema WHERE NombreEquipo = @nombreEquipo AND Version = @version ORDER BY Fecha DESC";
                            using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@nombreEquipo", nombreEquipo);
                                cmd.Parameters.AddWithValue("@version", versionMaxima);
                                var result = cmd.ExecuteScalar();
                                if (result != null && int.TryParse(result.ToString(), out int est))
                                    estado = est;
                            }
                        }
                    }
                    catch { }

                    if (estado == 1)
                    {
                        frmActualizacion frm = new frmActualizacion(versionMaxima, rutaInstalador, mensaje, configuracion.getConectionString());
                        frm.ShowDialog();
                    }
                }
            }
            catch { }
        }


        // ...
    }
}