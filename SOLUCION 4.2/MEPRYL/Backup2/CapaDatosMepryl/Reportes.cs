using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Comunes;

namespace CapaDatosMepryl
{
    public class Reportes
    {
        public Reportes()
        {
            // Constructor
        }

        public DataTable ReporteEspirometria(string strIdExamenLaboral, string strDNI)
        {
            string strSQL = "";

            strSQL = @"DECLARE @talla VARCHAR(10),
                        @peso VARCHAR(10),
                        @paciente VARCHAR(30),
                        @Nacimiento VARCHAR(10),
                        @informe VARCHAR(255)
                        SELECT @talla = talla, @peso = peso, @informe = espiro FROM dbo.ExamenLaboral WHERE id = '" + strIdExamenLaboral + @"'
                        SELECT @paciente = apellido + ' ' + nombres, @Nacimiento = Convert(date,fechaNacimiento,105) FROM dbo.PacienteLaboral WHERE dni = '" + strDNI + @"'
                        SELECT @paciente, @talla, @peso, @Nacimiento, @informe";
            
            DataTable dtConsulta = SQLConnector.obtenerTablaSegunConsultaString(strSQL);
            
            return dtConsulta;
        }


    }
}
