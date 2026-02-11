using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocioMepryl;
using CapaPresentacionBase;
using Comunes;
using System.Text.RegularExpressions;

namespace CapaPresentacion
{
    public partial class frmConsultasSQL : Form
    {
        CapaNegocioMepryl.UtilidadesMepryl UtilMepryl;
        private string strSQL = "";
        private int intPunteroCursor = 0;

        public frmConsultasSQL()
        {
            InitializeComponent();
            UtilMepryl = new CapaNegocioMepryl.UtilidadesMepryl();
        }

        public frmConsultasSQL(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;
            UtilMepryl = new CapaNegocioMepryl.UtilidadesMepryl();
        }

        private void btnListarTablas_Click(object sender, EventArgs e)
        {            
            txtConsultaSQL.Text = "SELECT CAST(table_name as varchar) as 'Tablas' FROM INFORMATION_SCHEMA.TABLES";
            txtConsultaSQL.Select();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = UtilMepryl.EjecutarSQL(strSQL);

           
                if (dt.Rows.Count > 0)                
                    dgvResultado.DataSource = dt;                

            }catch(System.NullReferenceException ex)
            {
                dgvResultado.DataSource = null;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            strSQL = txtConsultaSQL.Text;
            intPunteroCursor = txtConsultaSQL.SelectionStart;
            RemarcarSintaxis();
            txtConsultaSQL.SelectionStart = intPunteroCursor;
        }
               
        private void txtConsultaSQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnEjecutar_Click(sender, e);
            }            
        }

        private void ParametrosRichTextBox()
        {
            // https://social.msdn.microsoft.com/Forums/es-ES/c7b036e4-19d9-4665-bb00-93f5ea8cf0a5/cambiar-de-color-una-palabra-en-un-rich-textbox-c?forum=vcses
            // http://www.c-sharpcorner.com/article/syntax-highlighting-in-rich-textbox-control-part-1/
            txtConsultaSQL.Multiline = true;
            txtConsultaSQL.WordWrap = false;
            txtConsultaSQL.AcceptsTab = true;
            txtConsultaSQL.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            txtConsultaSQL.SelectionFont = new Font("Courier New", 13, FontStyle.Regular);
            txtConsultaSQL.SelectionColor = Color.Black;            
        }

        private void RemarcarSintaxis() {
            Regex r = new Regex("\\n");
            String[] lines = r.Split(txtConsultaSQL.Text);            
            
            txtConsultaSQL.Text = "";

            foreach (string l in lines)
                {
                    ParseLine(l);
                }
            }

        private void ParseLine(string line)
        {
            Regex r = new Regex("([ \\t{}();])");
            String[] tokens = r.Split(line);

            foreach (string token in tokens)
            {
                // Set the token's default color and font.
                txtConsultaSQL.SelectionColor = Color.Black;
                txtConsultaSQL.SelectionFont = new Font("Courier New", 13, FontStyle.Regular);

                // Check for a comment.
                if (token == "//" || token.StartsWith("//"))
                {
                    // Find the start of the comment and then extract the whole comment.
                    int index = line.IndexOf("//");
                    string comment = line.Substring(index, line.Length - index);
                    txtConsultaSQL.SelectionColor = Color.LightGreen;
                    txtConsultaSQL.SelectionFont = new Font("Courier New", 13, FontStyle.Regular);
                    txtConsultaSQL.SelectedText = comment;
                    break;
                }

                // Check whether the token is a keyword. 
                String[] keywords = { "select", "from", "where", "update", "and", "or", "in", "not", "is", "between", "SELECT", "FROM", "WHERE", "AND", "OR", "NOT", "BETWEEN", "IS" };
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (keywords[i] == token)
                    {
                        // Apply alternative color and font to highlight keyword.
                        txtConsultaSQL.SelectionColor = Color.Blue;
                        txtConsultaSQL.SelectionFont = new Font("Courier New", 13, FontStyle.Bold);
                        break;
                    }
                }

                txtConsultaSQL.SelectedText = token;
            }            
        }

        private void frmConsultasSQL_Load(object sender, EventArgs e)
        {
            ParametrosRichTextBox();
            MostrarArchivoTextBox();
        }

        private void btnColumnasTablas_Click(object sender, EventArgs e)
        {
            txtConsultaSQL.Text = "SELECT column_name FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = 'Nombre_Tabla'";
            txtConsultaSQL.Select(72,84);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"P:\Temporal\PLANTILLA REPORTE INFORMES\ConsultaSQL.txt", txtConsultaSQL.Text);
            MessageBox.Show("Consulta sql guardada", "Consulta SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarArchivoTextBox()
        {
            txtConsultaSQL.Text = System.IO.File.ReadAllText(@"P:\Temporal\PLANTILLA REPORTE INFORMES\ConsultaSQL.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
