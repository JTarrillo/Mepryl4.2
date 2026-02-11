using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Comunes;
using CapaNegocioMepryl;
using Entidades;

namespace CapaPresentacion
{
    public partial class frmImportacionLaboratorio : Form
    {
        frmBusquedaExamen form;
        DataTable valoresInvalidos;
        DataTable validaciones;
        CapaNegocioMepryl.ExamenPreventiva preventiva;

        int puntero;
        public frmImportacionLaboratorio(frmBusquedaExamen frm)
        {
            InitializeComponent();
            form = frm;
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();      
            validaciones = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Validaciones");
        }


        private void botImpExcel_Click(object sender, EventArgs e)
        {
            tbArchivo.Clear();
            openFileDialog.Filter = "Excel (.xlsx)|*.xlsx";
            DialogResult result = openFileDialog.ShowDialog();
            tbArchivo.Text = openFileDialog.FileName;
        }

        private void botComenzarExcel_Click(object sender, EventArgs e)
        {
            if (tbArchivo.Text != "")
            {
                DialogResult resul = MessageBox.Show("¿Desea comenzar la importación de laboratorios?", "Importar Laboratorios",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == resul)
                {
                    importar();
                }
   
            }
        }

        private void importar()
        {
            try
            {
                valoresInvalidos = new DataTable();
                valoresInvalidos.Columns.Add("Fila");
                valoresInvalidos.Columns.Add("Columna");
                string myexceldataquery = "select * from [Hoja1$]";
                string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + tbArchivo.Text + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;Allow Formula=false;\"";
                OleDbConnection oledbconn = new OleDbConnection(excelConnectionString);
                OleDbDataAdapter da = new OleDbDataAdapter(myexceldataquery, oledbconn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                progressBar.Minimum = 0;
                progressBar.Maximum = ds.Tables[0].Rows.Count;
                progressBar.Visible = true;
                
                procesarExcel(ds);


                progressBar.Visible = false;
                if (valoresInvalidos.Rows.Count == 0)
                {
                    MessageBox.Show("¡Importación exitosa! Registros importados correctamente: " + (puntero - 1).ToString(), "Importar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string detalles = "";
                    foreach (DataRow r in valoresInvalidos.Rows)
                    {
                        detalles = detalles + "\n Registro Nº: " + r.ItemArray[0].ToString() + ", Columna Nº: " +
                            r.ItemArray[1].ToString();

                    }

                    MessageBox.Show("¡Importación con valores no validados!\n\nDetalles:" + detalles, "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                progressBar.Visible = false;
                MessageBox.Show(ex.ToString(), "Error al Importar",MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }

        }

        private void procesarExcel(DataSet ds)
        {
            puntero = 1;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.ItemArray[0].ToString() != "")
                {
                    procesarFila(row);
                    progressBar.PerformStep();
                }
            }
        }

        private void procesarFila(DataRow row)
        {

            string fecha = procesarFecha(row.ItemArray[0].ToString());
            int examen = Convert.ToInt32(row.ItemArray[1].ToString());
            DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"Select tep.id from dbo.TipoExamenDePaciente 
            tep inner join dbo.Consulta c on tep.idConsulta = c.id
            where Convert(date,c.fecha) = '" + fecha + "' and c.identificador = '" + examen.ToString() + "'");
            if (tipoExamen.Rows.Count > 0)
            {
                procesarLaboratorio(tipoExamen.Rows[0].ItemArray[0].ToString(), row);
                puntero++;
            }

        }

        private string procesarFecha(string fechaSinProcesar)
        {

            string año = "20" + fechaSinProcesar.Substring(4, 2);
            string mes = fechaSinProcesar.Substring(2, 2);
            string dia = fechaSinProcesar.Substring(0, 2);
            return dia + '-' + mes + '-' + año;
        }

        private void procesarLaboratorio(string idTipoExamen, DataRow fila)
        {
            List<string> valores = new List<string>();
            Int32 multiplicacion;
            if (fila.ItemArray[2].ToString() != "" && fila.ItemArray[2].ToString() != "*")
            {
                float fltValorGlu = Convert.ToSingle(fila.ItemArray[2].ToString());
                //if ((fila.ItemArray[2].ToString()).Replace(",", ".").Replace(".", "").Length < 3)
                if ((fltValorGlu.ToString()).Replace(",", ".").Replace(".", "").Length < 3)
                {
                    multiplicacion = 100000;
                }
                else
                {
                    multiplicacion = 10000;
                }
                Int32 laboratorio;
                object strGRojo = fltValorGlu.ToString().Replace(",", ".").Replace(".", "");
                laboratorio = Convert.ToInt32(strGRojo);
                
                if (laboratorio > 999)
                    laboratorio *= 1000;
                else if (laboratorio > 99)
                    laboratorio *= 10000;                
                else if (laboratorio > 9)
                    laboratorio *= 100000;                  
                else if (laboratorio < 10)
                    laboratorio *= 1000000;

                //laboratorio = Convert.ToInt32((fila.ItemArray[2].ToString()).Replace(",", ".").Replace(".", "")) * multiplicacion;
                valores.Add(puntosAGlobulosBlancos("###,###", laboratorio.ToString()));
            }
            else
            {
                valores.Add("");
            }
            if ((fila.ItemArray[3].ToString() != "" && fila.ItemArray[3].ToString() != "*"))
            {
                valores.Add((puntosAGlobulosBlancos("###,###", fila.ItemArray[3].ToString())).Replace(",", "."));
            }
            else
            {
                valores.Add("");
            }
            if (fila.ItemArray[4].ToString() != "" && fila.ItemArray[4].ToString() != "*")
            {
                valores.Add(fila.ItemArray[4].ToString().Replace(".", ","));
            }
            else
            {
                valores.Add("");
            }
            if (fila.ItemArray[5].ToString() != "" && fila.ItemArray[5].ToString() != "*")
            {
                valores.Add(fila.ItemArray[5].ToString().Replace(".", ","));
            }
            else
            {
                valores.Add("");
            }
            if (fila.ItemArray[6].ToString() != "" && fila.ItemArray[6].ToString() != "*")
            {
                valores.Add(fila.ItemArray[6].ToString());
            }
            else
            {
                valores.Add("");
            }
            if (fila.ItemArray[7].ToString() != "" && fila.ItemArray[7].ToString() != "*")
            {
                valores.Add(fila.ItemArray[7].ToString());
            }
            else
            {
                valores.Add("");
            }
            if (fila.ItemArray[8].ToString() != "" && fila.ItemArray[8].ToString() != "*")
            {
                valores.Add(fila.ItemArray[8].ToString());
            }
            else
            {
                valores.Add("");
            }
            if (fila.ItemArray[9].ToString() != "" && fila.ItemArray[9].ToString() != "*")
            {
                valores.Add(fila.ItemArray[9].ToString());
            }
            else
            {
                valores.Add("");
            } 
            if (fila.ItemArray[10].ToString() != "" && fila.ItemArray[10].ToString() != "*")
            {
                valores.Add(fila.ItemArray[10].ToString());
            }
            else
            {
                valores.Add("");
            }
            if (fila.ItemArray[11].ToString() != "" && fila.ItemArray[11].ToString() != "*")
            {
                valores.Add(fila.ItemArray[11].ToString());
            }
            else
            {
                valores.Add("");
            }
            if (fila.ItemArray[12].ToString() != "" && fila.ItemArray[12].ToString() != "*")
            {
                valores.Add(fila.ItemArray[12].ToString());
            }
            else
            {
                valores.Add("");
            }
            if (fila.ItemArray[14].ToString() != "" && fila.ItemArray[14].ToString() != "*")
            {
                valores.Add(fila.ItemArray[14].ToString());
            }
            else
            {
                valores.Add("");
            }
            if (fila.ItemArray[15].ToString() != "" && fila.ItemArray[15].ToString() != "*")
            {
                valores.Add(fila.ItemArray[15].ToString());
            }
            else
            {
                valores.Add("");
            }


            valores.Add(obtenerIdValorChagas(fila.ItemArray[16].ToString(), validaciones));
            valores.Add(filtrarTabla(validaciones,"44", "1"));
            valores.Add(filtrarTabla(validaciones,"45", "1"));
            valores.Add(filtrarTabla(validaciones,"46", "1"));
            valores.Add(obtenerIdColor(fila.ItemArray[17].ToString(), validaciones));
            valores.Add(obtenerIdAspecto(fila.ItemArray[18].ToString(), validaciones));

            if (fila.ItemArray[19].ToString() != "" && fila.ItemArray[19].ToString() != "*")
            {
                valores.Add("1,0" + fila.ItemArray[19].ToString());
            }
            else
            {
                valores.Add("");
            }

          
            if (fila.ItemArray[20].ToString() != "" && fila.ItemArray[20].ToString() != "*")
            {
                valores.Add((fila.ItemArray[20].ToString()).Substring(0, 1));
            }
            else
            {
                valores.Add("");
            }
            valores.Add(obtenerId(fila.ItemArray[21].ToString(), "51", validaciones,22));
            valores.Add(obtenerId(fila.ItemArray[22].ToString(), "52", validaciones,23));
            valores.Add(obtenerId(fila.ItemArray[23].ToString(), "53", validaciones,24));
            valores.Add(obtenerId(fila.ItemArray[25].ToString(), "54", validaciones,26));
            valores.Add(obtenerId(fila.ItemArray[26].ToString(), "55", validaciones,27));
            valores.Add(obtenerId(fila.ItemArray[27].ToString(), "56", validaciones,28));
            valores.Add(obtenerId(fila.ItemArray[28].ToString(), "57", validaciones,29));
            valores.Add(obtenerId(fila.ItemArray[29].ToString(), "58", validaciones,30));
            valores.Add(obtenerId(fila.ItemArray[30].ToString(), "59", validaciones,31));
            valores.Add(filtrarTabla(validaciones,"60", "01"));
            valores.Add("");
            valores.Add("");
            valores.Add("");
            valores.Add("");
            valores.Add(fila.ItemArray[31].ToString());
  
            actualizarValores(idTipoExamen, valores);

        }


        private string obtenerId(string valor, string codigo, DataTable validaciones, int columna)
        {
            string idValidacion = "";
            if (valor == "N")
            {
                idValidacion = filtrarTabla(validaciones, codigo, "1");
            }
            else if (valor == "E" || valor == "+")
            {
                idValidacion = filtrarTabla(validaciones, codigo, "2");
            }
            else if (valor == "R" || valor == "++")
            {
                idValidacion = filtrarTabla(validaciones, codigo, "3");
            }
            else if (valor == "A" || valor == "+++")
            {
                idValidacion = filtrarTabla(validaciones, codigo, "4");
            }
            else if (valor == "*")
            {
                idValidacion = filtrarTabla(validaciones, codigo, "5");
            }
            else
            {
                idValidacion = filtrarTabla(validaciones, codigo, "6");
                marcarComoInvalido(puntero, columna);
            }
            return idValidacion;


        }


        private void actualizarValores(string idTipoExamen, List<string> valores)
        {
            preventiva.guardarExLaboratorio(cargarEntidad(idTipoExamen, valores));
        }


        private string obtenerIdColor(string valor, DataTable validaciones)
        {
            string idValidacion = "";
            if (valor == "A")
            {
                idValidacion = filtrarTabla(validaciones, "47", "1");
            }
            else if (valor == "AC")
            {
                idValidacion = filtrarTabla(validaciones, "47", "7");
            }
            else if (valor == "AO")
            {
                idValidacion = filtrarTabla(validaciones, "47", "5");
            }
            else if (valor == "*")
            {
                idValidacion = filtrarTabla(validaciones, "47", "2");
            }
            else
            {
                idValidacion = filtrarTabla(validaciones, "47", "8");
                marcarComoInvalido(puntero, 18);
            }
            return idValidacion;
            

        }


        private string obtenerIdAspecto(string valor, DataTable validaciones)
        {
            string idValidacion = "";
            if (valor == "L")
            {
                idValidacion = filtrarTabla(validaciones, "48", "1");
            }
            else if (valor == "LT")
            {
                idValidacion = filtrarTabla(validaciones, "48", "2");
            }
            else if (valor == "T")
            {
                idValidacion = filtrarTabla(validaciones, "48", "3");
            }
            else if (valor == "*")
            {
                idValidacion = filtrarTabla(validaciones, "48", "4");
            }
            else
            {
                idValidacion = filtrarTabla(validaciones, "48", "5");
                marcarComoInvalido(puntero, 19);
            }
            return idValidacion;


        }



        private string obtenerIdValorChagas(string valor, DataTable validaciones)
        {
            string idValidacion = "";
            if (valor == "POS")
            {
                idValidacion = filtrarTabla(validaciones, "43", "2");
            }
            else if (valor == "NEG")
            {
                idValidacion = filtrarTabla(validaciones, "43", "1");
            }
            else if (valor == "*")
            {
                idValidacion = filtrarTabla(validaciones, "43", "3");
            }
            else
            {
                idValidacion = filtrarTabla(validaciones, "43", "4");
                marcarComoInvalido(puntero, 17);
            }
            return idValidacion;

        }

        private string filtrarTabla(DataTable valid, string codigo, string codigoInterno)
        {
            DataRow[] r = valid.Select("codigo = '" + codigo + "' and codigoInterno = '" + codigoInterno + "'");
            return r[0][0].ToString();
        }

        private string puntosAGlobulosBlancos(string forma, string cadena)
        {
            if (!string.IsNullOrEmpty(cadena))
            {
                int Position = 0;
                Decimal result = 0;
                if (Decimal.TryParse(cadena, out result))
                {
                    cadena = result.ToString(forma);
                    Position = Position + 1;

                }
            }
            return cadena;
        }

        private void marcarComoInvalido(int fila, int columna)
        {
            valoresInvalidos.Rows.Add(fila, columna);
        }

        private Entidades.ExamenPreventiva cargarEntidad(string idTe, List<string> valores)
        {
            Entidades.ExamenPreventiva retorno = new Entidades.ExamenPreventiva();
            retorno.IdTipoExamen = new Guid(idTe);
            retorno.GRojos = valores[0];
            retorno.GBlancos = valores[1];
            retorno.Hemoglob = valores[2];
            retorno.Hemato = valores[3];
            retorno.Eritro = valores[4];
            retorno.Cayado = convertirInt(valores[5]);
            retorno.Segmentado = convertirInt(valores[6]);
            retorno.Eosinof = convertirInt(valores[7]);
            retorno.Basof = convertirInt(valores[8]);
            retorno.Linfoc = convertirInt(valores[9]);
            retorno.Monoc = convertirInt(valores[10]);
            retorno.Glucemia = convertirInt(valores[11]);
            retorno.Uremia = convertirInt(valores[12]);
            retorno.Chagas = convertirInt(valores[13]);
            retorno.Vdrl = convertirInt(valores[14]);
            retorno.Grupo = convertirInt(valores[15]);
            retorno.Factor = convertirInt(valores[16]);
            retorno.Color = convertirInt(valores[17]);
            retorno.Aspecto = convertirInt(valores[18]);
            retorno.Densidad = valores[19];
            retorno.Ph = convertirInt(valores[20]);
            retorno.Glucosa = convertirInt(valores[21]);
            retorno.Proteinas = convertirInt(valores[22]);
            retorno.HemoglobOrina = convertirInt(valores[23]);
            retorno.Bilirrubina = convertirInt(valores[24]);
            retorno.Celulas = convertirInt(valores[25]);
            retorno.Leucocitos = convertirInt(valores[26]);
            retorno.Hematies = convertirInt(valores[27]);
            retorno.Piocitos = convertirInt(valores[28]);
            retorno.Mucus = convertirInt(valores[29]);
            retorno.DictLab = convertirInt(valores[30]);
            retorno.ObsSerieRoja = valores[31];
            retorno.ObsSerieBlanca = valores[32];
            retorno.OtrosOrina1 = valores[33];
            retorno.OtrosOrina2 = valores[34];
            retorno.ObsLaborat = valores[35];         
            return retorno;
        }

        private int convertirInt(string valor)
        {
            int number;
            bool result = Int32.TryParse(valor, out number);
            if (result) { return number; }
            return -1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImpExcel_Click(object sender, EventArgs e)
        {
            tbArchivo.Clear();
            openFileDialog.Filter = "Excel (.xlsx)|*.xlsx";
            DialogResult result = openFileDialog.ShowDialog();
            tbArchivo.Text = openFileDialog.FileName;
        }        

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            if (tbArchivo.Text != "")
            {
                DialogResult resul = MessageBox.Show("¿Desea comenzar la importación de laboratorios?", "Importar Laboratorios",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == resul)
                {
                    importar();
                }

            }
        }
    }
}
