using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using System.Data.OleDb;
using System.Threading;

namespace CapaPresentacion
{
    public partial class frmUtilidadesDataSMS : Form
    {
        DataTable validaciones;
        public frmUtilidadesDataSMS()
        {
            InitializeComponent();
            validaciones = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Validaciones");
        }

        private void abrirOpenFileDialog()
        {
            int dia = tpHasta.Value.Day;
            string day = dia.ToString();
            if (dia <= 9) { day = "0" + dia.ToString(); }
            int mes = tpHasta.Value.Month;
            string month = mes.ToString();
            if (mes <= 9) { month = "0" + mes.ToString(); }
            string anio = tpHasta.Value.Year.ToString();
            saveFileDialog.Filter = "DBF (*.dbf)|*.dbf"; saveFileDialog.FileName = "DATOS";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbDBF.Text = saveFileDialog.FileName; 
            }
        }

        private void botImpDBF_Click(object sender, EventArgs e)
        {
            abrirOpenFileDialog();
        }

        private void botComenzarDBF_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(comenzarExportacion));
            thread.Start();      
        }

        private void comenzarExportacion()
        {
            int pos = -1;
            char[] array = saveFileDialog.FileName.ToCharArray();
            for (int i = 0; i <= array.Length - 1; i++)
            {
                if (array[i] == '\\')
                {
                    pos = i;
                }
            }
            string texto = "";
            for (int j = pos; j <= array.Length - 1; j++)
            {
                texto = texto + array[j].ToString();
            }
            try
            {
                string fileName = (texto.Trim('\\')).Replace(".DBF", "");
                string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + (saveFileDialog.FileName).Replace("\\" + fileName, "") + ";Extended Properties=dBase IV";
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"Create Table " + fileName + @" (LIGA varchar(200),
            CLUB varchar(200), JUGADOR varchar(200), CATEGORIA varchar(200), NOMBRE varchar(200),
            DICTAMEN varchar(200), DETALLE varchar(200), FECHA varchar(200))";
                cmd.ExecuteNonQuery();


                DataTable tipoEx = SQLConnector.obtenerTablaSegunConsultaString(@"Select tep.id as Id, (p.apellido + ' ' + p.nombres) as Paciente,
            p.dni as DNI, p.fechaNacimiento as Nacimiento, c.fecha as Fecha, ep.dictFinal
            from dbo.TipoExamenDePaciente tep inner join dbo.Consulta c on tep.idConsulta
            = c.id inner join dbo.Paciente p on c.pacienteID = p.id 
                inner join dbo.ExamenPreventiva ep on tep.id = ep.idTipoExamen where convert(date,c.fecha) >= '" + tpDesde.Value.ToShortDateString() +
                "' and convert(date,c.fecha) <= '" + tpHasta.Value.ToShortDateString() + "' and c.tipo = 'P'");
                progressBar.Minimum = 1;
                progressBar.Maximum = tipoEx.Rows.Count;
                progressBar.Visible = true;
                foreach (DataRow r in tipoEx.Rows)
                {
                    string dictFinal = "NO CARGADO";
                    string codigoDict = "0";
                    if (r.ItemArray[5].ToString() != string.Empty)
                    {
                        DataRow[] valid = validaciones.Select("id = " + r.ItemArray[5].ToString());
                        if (valid.Length > 0) { dictFinal = valid[0][3].ToString(); codigoDict = valid[0][2].ToString(); }
                    }
                    DataTable clubesPorEx = SQLConnector.obtenerTablaSegunConsultaString(@"select l.descripcion as Liga, c.descripcion as Club
                from dbo.clubesPorTipoExamen cte inner join dbo.Club c
                on cte.idClub = c.id inner join dbo.Liga l on c.ligaID = l.id
                where cte.idTipoExamen = '" + r.ItemArray[0].ToString() + "'");
                    foreach (DataRow row in clubesPorEx.Rows)
                    {
                        OleDbCommand command = connection.CreateCommand();
                        command.CommandText = @"Insert into " + fileName + " values ('" + row.ItemArray[0].ToString() + "','" +
                            row.ItemArray[1].ToString() + "','" + r.ItemArray[2].ToString() + "','" + ((DateTime)r.ItemArray[3]).Year.ToString()
                            + "','" + r.ItemArray[1].ToString() + "','" + codigoDict + "','" + dictFinal + "','" + ((DateTime)r.ItemArray[4]).ToShortDateString() + "')";
                        command.ExecuteNonQuery();
                        progressBar.PerformStep();

                    }

                }
                connection.Close();
                progressBar.Visible = false;
                MessageBox.Show("Exportación guardada correctamente en: \n" + tbDBF.Text, "Exportar", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
