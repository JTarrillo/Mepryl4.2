using System;
using System.Data;
using System.Data.OleDb;

class Program
{
    static void Main()
    {
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Mepryl4.2\\SOLUCION 4.2\\18.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES'";
        
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            connection.Open();
            
            // Obtener nombres de columnas
            DataTable schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);
            Console.WriteLine("=== COLUMNAS DEL EXCEL ===");
            foreach (DataRow row in schema.Rows)
            {
                Console.WriteLine($"Columna: {row["COLUMN_NAME"]}, Posición: {row["ORDINAL_POSITION"]}");
            }
            
            // Leer primeras filas
            string query = "SELECT * FROM [Hoja1$]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            Console.WriteLine($"\n=== TOTAL COLUMNAS: {dt.Columns.Count} ===");
            Console.WriteLine("=== PRIMERAS 3 FILAS ===");
            for (int i = 0; i < Math.Min(3, dt.Rows.Count); i++)
            {
                Console.WriteLine($"\nFila {i + 1}:");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.WriteLine($"  [{j}] {dt.Columns[j].ColumnName}: {dt.Rows[i][j]}");
                }
            }
        }
    }
}
