using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
namespace Comunes
{
    public class frmActualizacion : Form
    {
        private LinkLabel linkLabel;
        private Label labelMensaje;
        private string rutaInstaladores;
        private string versionNueva;
        private string connectionString;

        public frmActualizacion(string versionNueva, string rutaInstaladores, string mensajePersonalizado, string connectionString)
        {
            this.versionNueva = versionNueva;
            this.rutaInstaladores = rutaInstaladores;
            this.connectionString = connectionString;
            this.Text = "Actualización disponible - Mepryl 4.2 Prueba";
            this.Size = new System.Drawing.Size(500, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // Logo centrado arriba
            PictureBox pictureLogo = new PictureBox();
            System.Drawing.Image logoImg = null;
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(@"P:\img-system\mUsuarioLogin.png", System.IO.FileMode.Open, System.IO.FileAccess.Read);
                logoImg = System.Drawing.Image.FromStream(fs);
                pictureLogo.Image = logoImg;
                fs.Close();
            }
            catch { }
            if (logoImg != null)
            {
                try
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    logoImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    this.Icon = new System.Drawing.Icon(ms, 32, 32);
                }
                catch { }
            }
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogo.Size = new System.Drawing.Size(80, 80);
            pictureLogo.Location = new System.Drawing.Point((this.Width - pictureLogo.Width) / 2, 25);

            // Mensaje centrado y con fuente más grande
            labelMensaje = new Label();
            labelMensaje.Text = $"Existe una nueva versión de MEPRYL 4.2 Prueba disponible: {versionNueva}\n\n{mensajePersonalizado}\n\nBusque la carpeta MEPRYL{versionNueva} dentro de la siguiente ruta:";
            labelMensaje.AutoSize = false;
            labelMensaje.Size = new System.Drawing.Size(440, 120);
            labelMensaje.Location = new System.Drawing.Point(30, 115);
            labelMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelMensaje.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Regular);

            // Panel para resaltar el link
            Panel panelLink = new Panel();
            panelLink.Size = new System.Drawing.Size(440, 40);
            panelLink.Location = new System.Drawing.Point(30, 260);
            panelLink.BackColor = System.Drawing.Color.White;
            panelLink.BorderStyle = BorderStyle.FixedSingle;

            linkLabel = new LinkLabel();
            linkLabel.Text = $"{rutaInstaladores}\\MEPRYL{versionNueva}";
            linkLabel.Location = new System.Drawing.Point(10, 8);
            linkLabel.Size = new System.Drawing.Size(420, 25);
            linkLabel.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            linkLabel.LinkColor = System.Drawing.Color.DarkBlue;
            linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            linkLabel.VisitedLinkColor = System.Drawing.Color.Purple;
            linkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            linkLabel.LinkClicked += LinkLabel_LinkClicked;

            panelLink.Controls.Add(linkLabel);

            this.Controls.Add(pictureLogo);
            this.Controls.Add(labelMensaje);
            this.Controls.Add(panelLink);

            // Registrar IP y equipo en la tabla si no existe
            RegistrarEquipoActualizacion();
        }

        private void RegistrarEquipoActualizacion()
        {
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
            string nombreEquipo = Environment.MachineName;

            if (!string.IsNullOrEmpty(this.connectionString) && !string.IsNullOrEmpty(this.versionNueva))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(this.connectionString))
                    {
                        conn.Open();
                        // Verificar si ya existe registro para esta versión y equipo/IP
                        string sqlCheck = "SELECT COUNT(*) FROM ActualizacionesSistema WHERE Version = @version AND NombreEquipo = @nombreEquipo AND IP = @ip";
                        using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn))
                        {
                            cmdCheck.Parameters.AddWithValue("@version", this.versionNueva);
                            cmdCheck.Parameters.AddWithValue("@nombreEquipo", nombreEquipo);
                            cmdCheck.Parameters.AddWithValue("@ip", ipLocal ?? "");
                            int count = (int)cmdCheck.ExecuteScalar();
                            if (count == 0)
                            {
                                // Insertar nuevo registro
                                string sqlInsert = "INSERT INTO ActualizacionesSistema (Version, Mensaje, RutaInstalador, Fecha, Estado, NombreEquipo, IP) VALUES (@version, @mensaje, @ruta, GETDATE(), 1, @nombreEquipo, @ip)";
                                using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn))
                                {
                                    cmdInsert.Parameters.AddWithValue("@version", this.versionNueva);
                                    cmdInsert.Parameters.AddWithValue("@mensaje", "Actualización importante: Instale la nueva versión desde la carpeta indicada.");
                                    cmdInsert.Parameters.AddWithValue("@ruta", $"{rutaInstaladores}\\MEPRYL{versionNueva}");
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

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Abrir la carpeta específica de la versión nueva
                string rutaVersion = $"{rutaInstaladores}\\MEPRYL{versionNueva}";
                System.Diagnostics.Process.Start("explorer.exe", rutaVersion);
                // Cambiar Estado a 0 para este equipo y versión
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
                string nombreEquipo = Environment.MachineName;
                if (!string.IsNullOrEmpty(this.connectionString) && !string.IsNullOrEmpty(this.versionNueva))
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(this.connectionString))
                        {
                            conn.Open();
                            string sqlUpdate = "UPDATE ActualizacionesSistema SET Estado = 0 WHERE Version = @version AND NombreEquipo = @nombreEquipo";
                            using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn))
                            {
                                cmdUpdate.Parameters.AddWithValue("@version", this.versionNueva);
                                cmdUpdate.Parameters.AddWithValue("@nombreEquipo", nombreEquipo);
                                cmdUpdate.ExecuteNonQuery();
                            }
                        }
                    }
                    catch { }
                }
                // Cerrar la aplicación completamente
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la carpeta: " + ex.Message);
            }
        }

        // ...
    }
}
