using System;
using System.Data.SqlClient;

namespace ActualizarEstado
{
    class Program
    {
        static void Log(string mensaje)
        {
            try
            {
                System.IO.File.AppendAllText("ActualizarEstado.log", DateTime.Now + " - " + mensaje + System.Environment.NewLine);
            }
            catch { }
        }

        static void Main(string[] args)
        {
            Log("Inicio de ejecución.");
            // Parámetro: versión
            if (args.Length == 0)
            {
                Console.WriteLine("No se recibió la versión.");
                Log("No se recibió la versión.");
                return;
            }
            string version = args[0];

            // Obtener IP y nombre de equipo (IPv4)
            string ipLocal = "";
            try
            {
                var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                Log("Direcciones IP detectadas:");
                foreach (var ip in host.AddressList)
                {
                    Log($"  {ip} ({ip.AddressFamily})");
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ipLocal = ip.ToString();
                        break;
                    }
                }
            }
            catch { }
            string nombreEquipo = Environment.MachineName;
            string ipEquipo = $"{ipLocal}|{nombreEquipo}";
            Console.WriteLine($"IP local detectada: {ipLocal}");
            Console.WriteLine($"Nombre de equipo detectado: {nombreEquipo}");
            Console.WriteLine($"Valor combinado para IpEquipo: {ipEquipo}");
            Log($"IP local detectada: {ipLocal}");
            Log($"Nombre de equipo detectado: {nombreEquipo}");
            Log($"Valor combinado para IpEquipo: {ipEquipo}");

            // Cadena de conexión proporcionada por el usuario
            string connectionString = "Server=192.168.1.254;Database=MEPRYLv2.1;User Id=user;Password=Mepryl22;";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Log("Conexión a base de datos OK.");
                    // Actualiza Estado=0 para la versión y equipo/IP actual
                    string sql = "UPDATE ActualizacionesSistema SET Estado = 0 WHERE Version = @version AND IpEquipo = @ipEquipo";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@version", version);
                        cmd.Parameters.AddWithValue("@ipEquipo", ipEquipo);
                        int rows = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Filas afectadas: {rows}");
                        Log($"Filas afectadas: {rows}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Log("Error: " + ex.Message);
            }
        }
    }
}
