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
    public partial class frmImportarLaboratorioLaboral : Form
    {
        frmBusquedaExamen form;
        DataTable valoresInvalidos;
        DataTable validaciones;
        CapaNegocioMepryl.Examen examen;
        CapaNegocioMepryl.UtilidadesMepryl UtilMepryl;
        CapaNegocioMepryl.ExamenPreventiva preventiva;
        DataTable dtDatoRequerido;
        DataTable dtRequeridoMensaje;
        int intNroCol = 0;

        int puntero;
        public frmImportarLaboratorioLaboral()
        {
            InitializeComponent();
            //form = frm;
            examen = new CapaNegocioMepryl.Examen();
            UtilMepryl = new CapaNegocioMepryl.UtilidadesMepryl();
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();      
            validaciones = SQLConnector.obtenerTablaSegunConsultaString("Select * from dbo.Validaciones");
        }


        private void botImpExcel_Click(object sender, EventArgs e)
        {
            tbArchivo.Clear();
            openFileDialog.Filter = "Archivos de Excel |*.xlsx; *.xls";
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
            DataTable dtDatos;

            try
            {
                intNroCol = 0;
                valoresInvalidos = new DataTable();
                dtRequeridoMensaje = new DataTable();
                dtDatoRequerido = new DataTable();

                valoresInvalidos.Columns.Add("Fila");
                valoresInvalidos.Columns.Add("Columna");
                dtRequeridoMensaje.Columns.Add("Fila");
                dtRequeridoMensaje.Columns.Add("Columna");                
                dtDatos = UtilMepryl.DatosArchivoExcel(tbArchivo.Text);
                progressBar.Minimum = 0;                
                progressBar.Maximum = dtDatos.Rows.Count;
                progressBar.Visible = true;

                intNroCol = dtDatos.Columns.Count;
                procesarExcel(dtDatos);

                ValidarValores();
                progressBar.Visible = false;
                if (valoresInvalidos.Rows.Count == 0)
                {
                    if(!faltanResultados())                    
                        MessageBox.Show("¡Importación exitosa! Registros importados correctamente: " + (puntero - 1).ToString(), "Importar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string detalles = "";
                    foreach (DataRow r in valoresInvalidos.Rows)
                    {
                        detalles = detalles + "\n Nº Orden: L-" + r.ItemArray[0].ToString() + ". --> Error en la Columna: " +
                            r.ItemArray[1].ToString();

                    }

                    MessageBox.Show("¡El archivo de Excel presenta los siguientes errores!\n\nDetalles:" + detalles, "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                MessageBox.Show("Existe un error con los registros del archivo, verifique que el nro. de orden y que los registros existan.\nError al importar la fila nro.: " + puntero.ToString() + " \n\n-------\n" + ex.ToString(), "Error al Importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool faltanResultados()
        {
            string detalles = "";
            bool blnResultado = false;

            if (dtRequeridoMensaje.Rows.Count > 0)
            {
                detalles = "";

                foreach (DataRow t in dtRequeridoMensaje.Rows)
                {
                    detalles = detalles + "\nPara el Nº Orden: L-" + t.ItemArray[0].ToString() + ". --> " + //Es requerido resultados de " +
                        t.ItemArray[1].ToString();
                }

                MessageBox.Show("¡Importación incompleta, los siguientes resultados de examen son o no requeridos y no se han encontrado en el archivo de Excel.\n" + detalles, "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                blnResultado = true;
            }

            return blnResultado;
        }

        //private void procesarExcel(DataSet ds)
        private void procesarExcel(DataTable ds)
        {
            puntero = 1;
            foreach (DataRow row in ds.Rows)
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
            string examen01 = CorregirIdentificador(row.ItemArray[1].ToString());
            DataTable tipoExamen = SQLConnector.obtenerTablaSegunConsultaString(@"Select tep.id from dbo.TipoExamenDePaciente 
            tep inner join dbo.Consulta c on tep.idConsulta = c.id AND C.tipo = 'L' 
            where Convert(date,c.fecha) = '" + fecha + "' and c.identificador = '" + examen01.ToString() + "'");

            dtDatoRequerido.Clear();
            dtDatoRequerido = examen.ComprobarEstudioPorExamen(tipoExamen.Rows[0][0].ToString());

            if (tipoExamen.Rows.Count > 0)
            {
                procesarLaboratorio(examen01, fecha, row);
                //CampoRequerido(puntero, row);                
                CampoRequerido(ObtieneNroOrden(row.ItemArray[1].ToString()), row);
                puntero++;
            }

        }

        private string CorregirIdentificador(string Ident)
        {
            string strCorregido = "";
            int intNumero = 0;

            if (Ident.Contains("L"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("L"), 2);
                intNumero = Convert.ToInt32(strCorregido);
                strCorregido = "L" + intNumero;
            }
            else if (Ident.Contains("EC"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("E"), 3);
                intNumero = Convert.ToInt32(strCorregido);
                strCorregido = "EC" + intNumero;
            }
            else if (Ident.Contains("C"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("C"), 2);
                intNumero = Convert.ToInt32(strCorregido);
                strCorregido = "C" + intNumero;
            }
            else if (Ident.Contains("R"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("R"), 2);
                intNumero = Convert.ToInt32(strCorregido);
                strCorregido = "R" + intNumero;
            }

            return strCorregido;
        }

        private string procesarFecha(string fechaSinProcesar)
        {

            string año = "20" + fechaSinProcesar.Substring(4, 2);
            string mes = fechaSinProcesar.Substring(2, 2);
            string dia = fechaSinProcesar.Substring(0, 2);
            return dia + '-' + mes + '-' + año;
        }

        private void procesarLaboratorio(string Identificador, string Fecha, DataRow fila)
        {
            List<string> valores = new List<string>();
            Int32 multiplicacion;
            if (fila.ItemArray[2].ToString() != "" && fila.ItemArray[2].ToString() != "*")
            {
                if ((fila.ItemArray[2].ToString()).Replace(",", ".").Replace(".", "").Length < 3)
                {
                    multiplicacion = 100000;
                }
                else
                {
                    multiplicacion = 10000;
                }
                Int32 laboratorio;

                object strGRojo = fila.ItemArray[2].ToString().Replace(",", ".").Replace(".", "");
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
                marcarComoInvalido(ObtieneNroOrden(fila.ItemArray[1].ToString()), 2);
            }

            if ((fila.ItemArray[3].ToString() != "" && fila.ItemArray[3].ToString() != "*"))
            {
                valores.Add((puntosAGlobulosBlancos("###,###", fila.ItemArray[3].ToString())).Replace(",", "."));
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(fila.ItemArray[1].ToString()), 3);
            }
            if (fila.ItemArray[4].ToString() != "" && fila.ItemArray[4].ToString() != "*")
            {
                valores.Add(fila.ItemArray[4].ToString().Replace(".", ","));
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(fila.ItemArray[1].ToString()), 4);
                
            }
            if (fila.ItemArray[5].ToString() != "" && fila.ItemArray[5].ToString() != "*")
            {
                valores.Add(fila.ItemArray[5].ToString().Replace(".", ","));
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(fila.ItemArray[1].ToString()), 5);
            }
            if (fila.ItemArray[6].ToString() != "" && fila.ItemArray[6].ToString() != "*")
            {
                valores.Add(fila.ItemArray[6].ToString());
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(fila.ItemArray[1].ToString()), 6);
                
            }
            if (fila.ItemArray[7].ToString() != "" && fila.ItemArray[7].ToString() != "*")
            {
                valores.Add(fila.ItemArray[7].ToString());
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(fila.ItemArray[1].ToString()), 7);
            }
            if (fila.ItemArray[8].ToString() != "" && fila.ItemArray[8].ToString() != "*")
            {
                valores.Add(fila.ItemArray[8].ToString());
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(fila.ItemArray[1].ToString()), 8);
            }
            if (fila.ItemArray[9].ToString() != "" && fila.ItemArray[9].ToString() != "*")
            {
                valores.Add(fila.ItemArray[9].ToString());
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(fila.ItemArray[1].ToString()), 9);
            }
            if (fila.ItemArray[10].ToString() != "" && fila.ItemArray[10].ToString() != "*")
            {
                valores.Add(fila.ItemArray[10].ToString());
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(fila.ItemArray[1].ToString()), 10);
            }
            if (fila.ItemArray[11].ToString() != "" && fila.ItemArray[11].ToString() != "*")
            {
                valores.Add(fila.ItemArray[11].ToString());
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(fila.ItemArray[1].ToString()), 11);
            }
            if (fila.ItemArray[12].ToString() != "" && fila.ItemArray[12].ToString() != "*")
            {
                valores.Add(fila.ItemArray[12].ToString());
            }
            else
            {
                valores.Add("");
                marcarComoInvalido(ObtieneNroOrden(fila.ItemArray[1].ToString()), 12);
            }

            if (fila.ItemArray[14].ToString() != "" && fila.ItemArray[14].ToString() != "*")
            {
                valores.Add(fila.ItemArray[14].ToString());
            }
            else
            {
                valores.Add("");
                //marcarComoInvalido(puntero, 14);                
            }
            if (fila.ItemArray[15].ToString() != "" && fila.ItemArray[15].ToString() != "*")
            {
                valores.Add(fila.ItemArray[15].ToString());
            }
            else
            {
                valores.Add("");
                //marcarComoInvalido(puntero, 15);                
            }

            valores.Add(obtenerIdValorChagas(fila.ItemArray[16].ToString(), validaciones));            
            valores.Add(obtenerIdColor(fila.ItemArray[17].ToString(), validaciones));
            valores.Add(obtenerIdAspecto(fila.ItemArray[18].ToString(), validaciones));

            if (fila.ItemArray[19].ToString() != "" && fila.ItemArray[19].ToString() != "*")
            {
                valores.Add("1,0" + fila.ItemArray[19].ToString());
            }
            else
            {
                valores.Add("");
                //marcarComoInvalido(puntero, 19);
            }

            if (fila.ItemArray[20].ToString() != "" && fila.ItemArray[20].ToString() != "*")
            {
                valores.Add((fila.ItemArray[20].ToString()).Substring(0, 1));
            }
            else
            {
                valores.Add("");
                //marcarComoInvalido(puntero, 20);
            }
            valores.Add(obtenerId(fila.ItemArray[21].ToString(), "51", validaciones, 21));            
            valores.Add(obtenerId(fila.ItemArray[22].ToString(), "52", validaciones, 22));                
            valores.Add(obtenerId(fila.ItemArray[23].ToString(), "53", validaciones, 23));            
            valores.Add(obtenerId(fila.ItemArray[24].ToString(), "53", validaciones, 24));
            valores.Add(obtenerId(fila.ItemArray[25].ToString(), "54", validaciones, 25));
            valores.Add(obtenerIdCelulas(fila.ItemArray[26].ToString(), "55", validaciones, 26)); // Celulas
            valores.Add(obtenerIdLeucocitos(fila.ItemArray[27].ToString(), "56", validaciones, 27)); // Leucocitos
            valores.Add(obtenerId(fila.ItemArray[28].ToString(), "57", validaciones, 28));
            valores.Add(obtenerId(fila.ItemArray[29].ToString(), "58", validaciones, 29));
            valores.Add(obtenerId(fila.ItemArray[30].ToString(), "59", validaciones, 30));
            //valores.Add(filtrarTabla(validaciones, "60", "01"));
            if (fila.ItemArray[31].ToString() != "" && fila.ItemArray[31].ToString() != "*")
            {
                valores.Add(Convert.ToString(Convert.ToInt32(fila.ItemArray[31])));
            }
            else
            {
                valores.Add("");                
            }
            if (fila.ItemArray[32].ToString() != "" && fila.ItemArray[32].ToString() != "*")
            {
                valores.Add(Convert.ToString(Convert.ToInt32(fila.ItemArray[32])));
            }
            else
            {
                valores.Add("");                
            }
            if (fila.ItemArray[33].ToString() != "" && fila.ItemArray[33].ToString() != "*")
            {
                valores.Add(Convert.ToString(Convert.ToInt32(fila.ItemArray[33])));
            }
            else
            {
                valores.Add("");
            }
            if (fila.ItemArray[34].ToString() != "" && fila.ItemArray[34].ToString() != "*")
            {
                valores.Add(Convert.ToString(Convert.ToInt32((fila.ItemArray[34]))));
            }
            else
            {
                valores.Add("");
            }            
            if (fila.ItemArray[35].ToString() != "" && fila.ItemArray[35].ToString() != "*")
            {
                valores.Add(fila.ItemArray[35].ToString());
            }
            else
            {
                valores.Add("");
            }
            
            valores.Add(obtenerIdValorFactor(fila.ItemArray[36].ToString()));
            valores.Add(obtenerIdValorVDRL(fila.ItemArray[37].ToString(), validaciones));
            valores.Add(obtenerIdValorEmbarazo(fila.ItemArray[38].ToString(), validaciones));
            
            if (fila.ItemArray[39].ToString() != "" && fila.ItemArray[39].ToString() != "*")
            {
                valores.Add(fila.ItemArray[39].ToString());
            }
            else
            {
                valores.Add("");
            }

            // Arbitros Inicio
            if (intNroCol > 40)
            {
                if (fila.ItemArray[40].ToString() != "" && fila.ItemArray[40].ToString() != "*")
                {
                    valores.Add(fila.ItemArray[40].ToString());
                }
                else
                {
                    valores.Add("");
                }
                if (fila.ItemArray[41].ToString() != "" && fila.ItemArray[41].ToString() != "*")
                {
                    valores.Add(fila.ItemArray[41].ToString());
                }
                else
                {
                    valores.Add("");
                }
                if (fila.ItemArray[42].ToString() != "" && fila.ItemArray[42].ToString() != "*")
                {
                    valores.Add(fila.ItemArray[42].ToString());
                }
                else
                {
                    valores.Add("");
                }
                if (fila.ItemArray[43].ToString() != "" && fila.ItemArray[43].ToString() != "*")
                {
                    valores.Add(fila.ItemArray[43].ToString());
                }
                else
                {
                    valores.Add("");
                }
                if (fila.ItemArray[44].ToString() != "" && fila.ItemArray[44].ToString() != "*")
                {
                    valores.Add(fila.ItemArray[44].ToString());
                }
                else
                {
                    valores.Add("");
                }
                if (fila.ItemArray[45].ToString() != "" && fila.ItemArray[45].ToString() != "*")
                {
                    valores.Add(fila.ItemArray[45].ToString());
                }
                else
                {
                    valores.Add("");
                }
                if (fila.ItemArray[46].ToString() != "" && fila.ItemArray[46].ToString() != "*")
                {
                    valores.Add(fila.ItemArray[46].ToString());
                }
                else
                {
                    valores.Add("");
                }
                if (fila.ItemArray[47].ToString() != "" && fila.ItemArray[47].ToString() != "*")
                {
                    valores.Add(fila.ItemArray[47].ToString());
                }
                else
                {
                    valores.Add("");
                }
                if (fila.ItemArray[48].ToString() != "" && fila.ItemArray[48].ToString() != "*")
                {
                    valores.Add(fila.ItemArray[48].ToString());
                }
                else
                {
                    valores.Add("");
                }
                if (fila.ItemArray[49].ToString() != "" && fila.ItemArray[49].ToString() != "*")
                {
                    valores.Add(fila.ItemArray[49].ToString());
                }
                else
                {
                    valores.Add("");
                }
                if (fila.ItemArray[50].ToString() != "" && fila.ItemArray[50].ToString() != "*")
                {
                    valores.Add(fila.ItemArray[50].ToString());
                }
                else
                {
                    valores.Add("");
                }
            }
            // Arbitros Fin

            if (dtRequeridoMensaje.Rows.Count < 1 && valoresInvalidos.Rows.Count < 1)
                ActualizaEstudioLaboratorio(Fecha, Identificador, valores);
        }


        private string obtenerId(string valor, string codigo, DataTable validaciones, int columna)
        {
            string idValidacion = "";
            if (valor == "N")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "1");
            }
            else if (valor == "E" || valor == "+")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "2");
            }
            else if (valor == "R" || valor == "++")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "3");
            }
            else if (valor == "A" || valor == "+++")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "4");
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "5");
                idValidacion = "";
            }
            else if (valor == "")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "5");
                idValidacion = "";
            }
            else
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "6");
                marcarComoInvalido(puntero, columna);
            }
            return idValidacion;
        }

        private string obtenerIdValorFactor(string valor)
        {
            string idValidacion = "";

            if (valor == "POS" || valor == "(+)" || valor == "+")
            {
                idValidacion = "+";
            }
            else if (valor == "NEG" || valor == "(-)" || valor == "-")
            {
                idValidacion = "-";
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "43", "3");
                idValidacion = "";
            }
            else if (valor == "")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "43", "3");
                idValidacion = "";
            }
            else
            {
                idValidacion = "";
                marcarComoInvalido(puntero, 36);
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
                idValidacion = filtrarTablaDescripcion(validaciones, "47", "1");
            }
            else if (valor == "AC")
            {
                // idValidacion = filtrarTablaDescripcion(validaciones, "47", "7");
                idValidacion = "CLARO";
            }
            else if (valor == "AO")
            {
                // idValidacion = filtrarTablaDescripcion(validaciones, "47", "5");
                idValidacion = "OSCURO";
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "47", "2");
                idValidacion = "";
            }
            else if (valor == "")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "47", "2");
                idValidacion = "";
            }
            else
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "47", "8");
                marcarComoInvalido(puntero, 17);
            }
            return idValidacion;
        }

        private string obtenerIdAspecto(string valor, DataTable validaciones)
        {
            string idValidacion = "";
            if (valor == "L")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "48", "1");
            }
            else if (valor == "LT")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "48", "2");
                idValidacion = "LIG. TURBIO";
            }
            else if (valor == "T")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "48", "3");
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "48", "4");
                idValidacion = "";
            }
            else if (valor == "")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "48", "4");
                idValidacion = "";
            }
            else
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "48", "5");
                marcarComoInvalido(puntero, 18);
            }
            return idValidacion;


        }
        
        private string obtenerIdValorChagas(string valor, DataTable validaciones)
        {
            string idValidacion = "";
            if (valor == "POS")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "43", "2");
            }
            else if (valor == "NEG")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "43", "1");
            }
            else if (valor == "*")
            {
                idValidacion = "";
            }
            else if (valor == "")
            {
                idValidacion = "";
            }
            else
            {
                idValidacion = "";
                marcarComoInvalido(puntero, 16);
            }
            return idValidacion;
        }

        private string obtenerIdValorVDRL(string valor, DataTable validaciones)
        {
            string idValidacion = "";
            if (valor == "R")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "44", "2");
            }
            else if (valor == "NR")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "44", "1");
            }
            else if (valor == "*")
            {
                idValidacion = "";
            }
            else if (valor == "")
            {
                idValidacion = "";
            }
            else
            {
                idValidacion = "";
                marcarComoInvalido(puntero, 37);
            }
            return idValidacion;
        }

        private string obtenerIdValorEmbarazo(string valor, DataTable validaciones)
        {
            string idValidacion = "";
            if (valor == "POS" || valor == "(+)" || valor == "+")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "43", "2");
            }
            else if (valor == "NEG" || valor == "(-)" || valor == "-")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, "43", "1");
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "43", "3");
                idValidacion = "";                
            }
            else if (valor == "")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, "43", "3");
                idValidacion = "";
            }
            else
            {
                idValidacion = "";
                marcarComoInvalido(puntero, 38);                
            }
            return idValidacion;
        }

        private string filtrarTabla(DataTable valid, string codigo, string codigoInterno)
        {
            DataRow[] r = valid.Select("codigo = '" + codigo + "' and codigoInterno = '" + codigoInterno + "'");
            return r[0][0].ToString();
        }

        private string filtrarTablaDescripcion(DataTable valid, string codigo, string codigoInterno)
        {
            DataRow[] r = valid.Select("codigo = '" + codigo + "' and codigoInterno = '" + codigoInterno + "'");
            return r[0][3].ToString();
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

        private string obtenerIdCelulas(string valor, string codigo, DataTable validaciones, int columna)
        {
            string idValidacion = "";
            if (valor == "N")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "2");
                idValidacion = "NO SE OBSERVAN";
            }
            else if (valor == "E" || valor == "+")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "2");
            }
            else if (valor == "R" || valor == "++")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "3");
            }
            else if (valor == "A" || valor == "+++")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "4");
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "6");
                idValidacion = "";
            }
            else if (valor == "")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "6");
                idValidacion = "";
            }
            else
            {
                idValidacion = "";
                marcarComoInvalido(puntero, 26);
            }
            return idValidacion;
        }

        private string obtenerIdLeucocitos(string valor, string codigo, DataTable validaciones, int columna)
        {
            string idValidacion = "";
            if (valor == "N")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "2");
                idValidacion = "NO SE OBSERVAN";
            }
            else if (valor == "E" || valor == "+")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "2");
            }
            else if (valor == "R" || valor == "++")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "3");
            }
            else if (valor == "A" || valor == "+++")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "4");
            }
            else if (valor == "*")
            {
                //idValidacion = filtrarTablaDescripcion(validaciones, codigo, "6");
                idValidacion = "";
            }
            else if (valor == "")
            {
                idValidacion = filtrarTablaDescripcion(validaciones, codigo, "6");
                idValidacion = "";
            }
            else
            {
                idValidacion = "";
                marcarComoInvalido(puntero, 27);
            }
            return idValidacion;
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

        private bool ActualizaEstudioLaboratorio(string Fecha, string Identificador, List<string> valores)
        {
            return examen.ActualizarExamenLaboral(Fecha, Identificador, valores);
        }

        private void ValidarValores()
        {
            string strResultado = "";

            if (valoresInvalidos.Rows.Count > 0)
            {
                for (int i = 0; i < valoresInvalidos.Rows.Count; i++)
                {
                    strResultado = valoresInvalidos.Rows[i][1].ToString();

                    switch (strResultado)
                    {
                        case "0":
                            valoresInvalidos.Rows[i][1] = "Fecha";
                            break;
                        case "1":
                            valoresInvalidos.Rows[i][1] = "Orden";
                            break;
                        case "2":
                            valoresInvalidos.Rows[i][1] = "GR (Globulos Rojos)";
                            break;
                        case "3":
                            valoresInvalidos.Rows[i][1] = "GB (Globulos Blancos)";
                            break;
                        case "4":
                            valoresInvalidos.Rows[i][1] = "HGB (Hemoglobina)";
                            break;
                        case "5":
                            valoresInvalidos.Rows[i][1] = "HTC (Hematocrito)";
                            break;
                        case "6":
                            valoresInvalidos.Rows[i][1] = "ERI (Eritrosedimentación)";
                            break;
                        case "7":
                            valoresInvalidos.Rows[i][1] = "NC ()";
                            break;
                        case "8":
                            valoresInvalidos.Rows[i][1] = "NS ()";
                            break;
                        case "9":
                            valoresInvalidos.Rows[i][1] = "EOS (Eosinófilos)";
                            break;
                        case "10":
                            valoresInvalidos.Rows[i][1] = "BAS (Basófilos)";
                            break;
                        case "11":
                            valoresInvalidos.Rows[i][1] = "LIN (Linfocitos)";
                            break;
                        case "12":
                            valoresInvalidos.Rows[i][1] = "MON (Monocitos)";
                            break;
                        case "14":
                            valoresInvalidos.Rows[i][1] = "GLU (Glucemia)";
                            break;
                        case "15":
                            valoresInvalidos.Rows[i][1] = "URE (Uremia)";
                            break;
                        case "16":
                            valoresInvalidos.Rows[i][1] = "CHA (Chagas)";
                            break;
                        case "17":
                            valoresInvalidos.Rows[i][1] = "COL (Color)";
                            break;
                        case "18":
                            valoresInvalidos.Rows[i][1] = "ASP (Aspecto)";
                            break;
                        case "19":
                            valoresInvalidos.Rows[i][1] = "DEN Densidad";
                            break;
                        case "20":
                            valoresInvalidos.Rows[i][1] = "PH";
                            break;
                        case "21":
                            valoresInvalidos.Rows[i][1] = "GLU (Glucosa)";
                            break;
                        case "22":
                            valoresInvalidos.Rows[i][1] = "PRO (Proteinas)";
                            break;
                        case "23":
                            valoresInvalidos.Rows[i][1] = "HGB (Hemoglobina)";
                            break;
                        case "24":
                            valoresInvalidos.Rows[i][1] = "CC ()";
                            break;
                        case "25":
                            valoresInvalidos.Rows[i][1] = "BIL (Billirubina)";
                            break;
                        case "26":
                            valoresInvalidos.Rows[i][1] = "CEL (Celulas)";
                            break;
                        case "27":
                            valoresInvalidos.Rows[i][1] = "LEU (Leucocitos)";
                            break;
                        case "28":
                            valoresInvalidos.Rows[i][1] = "HEM (Hematies)";
                            break;
                        case "29":
                            valoresInvalidos.Rows[i][1] = "PIO (Piociotos)";
                            break;
                        case "30":
                            valoresInvalidos.Rows[i][1] = "MUC ()";
                            break;
                        case "31":
                            valoresInvalidos.Rows[i][1] = "HDL";
                            break;
                        case "32":
                            valoresInvalidos.Rows[i][1] = "COL";
                            break;
                        case "33":
                            valoresInvalidos.Rows[i][1] = "TGL";
                            break;
                        case "34":
                            valoresInvalidos.Rows[i][1] = "LDL";
                            break;
                        case "35":
                            valoresInvalidos.Rows[i][1] = "GS";
                            break;
                        case "36":
                            valoresInvalidos.Rows[i][1] = "RH";
                            break;
                        case "37":
                            valoresInvalidos.Rows[i][1] = "VDRCU";
                            break;
                        case "38":
                            valoresInvalidos.Rows[i][1] = "T. EMB. (Test Embarazo)";
                            break;
                        case "39":
                            valoresInvalidos.Rows[i][1] = "OBD (Observaciones)";
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void CampoRequerido(int puntero, DataRow fila)
        {
            foreach (DataRow row in dtDatoRequerido.Rows)
            {
                if ((fila.ItemArray[4].ToString() == "" || fila.ItemArray[4].ToString() == "*") && Convert.ToBoolean(row.ItemArray[0].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Hemoglobina");
                }
                else if ((fila.ItemArray[4].ToString() != "" || fila.ItemArray[4].ToString() != "*") && Convert.ToBoolean(row.ItemArray[0].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Hemoglobina ");
                }

                if ((fila.ItemArray[6].ToString() == "" || fila.ItemArray[6].ToString() == "*") && Convert.ToBoolean(row.ItemArray[1].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Eritrosedimentación");
                }
                else if ((fila.ItemArray[6].ToString() != "" || fila.ItemArray[6].ToString() != "*") && Convert.ToBoolean(row.ItemArray[1].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Eritrosedimentación");
                }

                if (((fila.ItemArray[35].ToString() == "" || fila.ItemArray[35].ToString() == "*") || (fila.ItemArray[36].ToString() == "" || fila.ItemArray[36].ToString() == "*"))
                    && Convert.ToBoolean(row.ItemArray[2].ToString()))
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Grupo y Factor");
                }
                else if (((fila.ItemArray[35].ToString() != "" && fila.ItemArray[35].ToString() != "*") || (fila.ItemArray[36].ToString() != "" && fila.ItemArray[36].ToString() != "*"))
                    && !Convert.ToBoolean(row.ItemArray[2].ToString()))
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Grupo y Factor");
                }

                if ((fila.ItemArray[14].ToString() == "" || fila.ItemArray[14].ToString() == "*") && Convert.ToBoolean(row.ItemArray[3].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Glucemia");
                }
                else if ((fila.ItemArray[14].ToString() != "" && fila.ItemArray[14].ToString() != "*") && Convert.ToBoolean(row.ItemArray[3].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Glucemia");
                }

                if ((fila.ItemArray[15].ToString() == "" || fila.ItemArray[15].ToString() == "*") && Convert.ToBoolean(row.ItemArray[4].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Uremia");
                }
                else if ((fila.ItemArray[15].ToString() != "" && fila.ItemArray[15].ToString() != "*") && Convert.ToBoolean(row.ItemArray[4].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Uremia");
                }

                if ((fila.ItemArray[16].ToString() == "" || fila.ItemArray[16].ToString() == "*") && Convert.ToBoolean(row.ItemArray[5].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Chagas");
                }
                else if ((fila.ItemArray[16].ToString() != "" && fila.ItemArray[16].ToString() != "*") && Convert.ToBoolean(row.ItemArray[5].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Chagas");
                }

                if ((fila.ItemArray[37].ToString() == "" || fila.ItemArray[37].ToString() == "*") && Convert.ToBoolean(row.ItemArray[6].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de VDRL");
                }
                else if ((fila.ItemArray[37].ToString() != "" && fila.ItemArray[37].ToString() != "*") && Convert.ToBoolean(row.ItemArray[6].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) VDRL");
                }

                if ((fila.ItemArray[38].ToString() == "" || fila.ItemArray[38].ToString() == "*") && Convert.ToBoolean(row.ItemArray[7].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Test Embarazo");
                }
                else if ((fila.ItemArray[38].ToString() != "" && fila.ItemArray[38].ToString() != "*") && Convert.ToBoolean(row.ItemArray[7].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Test Embarazo");
                }

                if ((fila.ItemArray[32].ToString() == "" || fila.ItemArray[32].ToString() == "*") && Convert.ToBoolean(row.ItemArray[8].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Col. Total");
                }
                else if ((fila.ItemArray[32].ToString() != "" && fila.ItemArray[32].ToString() != "*") && Convert.ToBoolean(row.ItemArray[8].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Col. Total");
                }

                if ((fila.ItemArray[34].ToString() == "" || fila.ItemArray[34].ToString() == "*" || Convert.ToInt32(fila.ItemArray[34]) == 0) && Convert.ToBoolean(row.ItemArray[9].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de LDL");
                }
                else if ((fila.ItemArray[34].ToString() != "" && fila.ItemArray[34].ToString() != "*" && Convert.ToInt32(fila.ItemArray[34]) != 0) && Convert.ToBoolean(row.ItemArray[9].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) LDL");
                }

                if ((fila.ItemArray[31].ToString() == "" || fila.ItemArray[31].ToString() == "*") && Convert.ToBoolean(row.ItemArray[10].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de HDL");
                }
                else if ((fila.ItemArray[31].ToString() != "" && fila.ItemArray[31].ToString() != "*") && Convert.ToBoolean(row.ItemArray[10].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) HDL");
                }

                if ((fila.ItemArray[33].ToString() == "" || fila.ItemArray[33].ToString() == "*") && Convert.ToBoolean(row.ItemArray[11].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Es requerido resultados de Triglic.");
                }
                else if ((fila.ItemArray[33].ToString() != "" && fila.ItemArray[33].ToString() != "*") && Convert.ToBoolean(row.ItemArray[11].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Triglic.");
                }

                if (((fila.ItemArray[17].ToString() == "" || fila.ItemArray[17].ToString() == "*") ||
                    (fila.ItemArray[18].ToString() == "" || fila.ItemArray[18].ToString() == "*") ||
                    (fila.ItemArray[19].ToString() == "" || fila.ItemArray[19].ToString() == "*") ||
                    (fila.ItemArray[20].ToString() == "" || fila.ItemArray[20].ToString() == "*") ||
                    (fila.ItemArray[21].ToString() == "" || fila.ItemArray[21].ToString() == "*") ||
                    (fila.ItemArray[22].ToString() == "" || fila.ItemArray[22].ToString() == "*") ||
                    (fila.ItemArray[23].ToString() == "" || fila.ItemArray[23].ToString() == "*") ||
                    (fila.ItemArray[24].ToString() == "" || fila.ItemArray[24].ToString() == "*") ||
                    (fila.ItemArray[25].ToString() == "" || fila.ItemArray[25].ToString() == "*")) &&
                    Convert.ToBoolean(row.ItemArray[12].ToString()) == true)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "Incompleto Análisis de Orina");
                }
                else if (((fila.ItemArray[17].ToString() != "" && fila.ItemArray[17].ToString() != "*") ||
                    (fila.ItemArray[18].ToString() != "" && fila.ItemArray[18].ToString() != "*") ||
                    (fila.ItemArray[19].ToString() != "" && fila.ItemArray[19].ToString() != "*") ||
                    (fila.ItemArray[20].ToString() != "" && fila.ItemArray[20].ToString() != "*") ||
                    (fila.ItemArray[21].ToString() != "" && fila.ItemArray[21].ToString() != "*") ||
                    (fila.ItemArray[22].ToString() != "" && fila.ItemArray[22].ToString() != "*") ||
                    (fila.ItemArray[23].ToString() != "" && fila.ItemArray[23].ToString() != "*") ||
                    (fila.ItemArray[24].ToString() != "" && fila.ItemArray[24].ToString() != "*") ||
                    (fila.ItemArray[25].ToString() != "" && fila.ItemArray[25].ToString() != "*")) &&
                    Convert.ToBoolean(row.ItemArray[12].ToString()) == false)
                {
                    dtRequeridoMensaje.Rows.Add(puntero, "(No Requerido) Análisis de Orina");
                }
            }
        }

        private int ObtieneNroOrden(string Ident)
        {
            string strCorregido = "";
            int intNumero = 0;

            if (Ident.Contains("L"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("L"), 2);
                intNumero = Convert.ToInt32(strCorregido);
                
            }
            else if (Ident.Contains("EC"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("E"), 3);
                intNumero = Convert.ToInt32(strCorregido);                
            }
            else if (Ident.Contains("C"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("C"), 2);
                intNumero = Convert.ToInt32(strCorregido);                
            }
            else if (Ident.Contains("R"))
            {
                strCorregido = Ident.Remove(Ident.IndexOf("R"), 2);
                intNumero = Convert.ToInt32(strCorregido);                
            }

            return intNumero;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImpExcel_Click(object sender, EventArgs e)
        {
            tbArchivo.Clear();
            openFileDialog.Filter = "Archivos de Excel |*.xlsx; *.xls";
            DialogResult result = openFileDialog.ShowDialog();
            tbArchivo.Text = openFileDialog.FileName;
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

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
