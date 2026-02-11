using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace CapaPresentacion
{
    public partial class frmMensajeAlerta : Form
    {
        private string strMensaje = "";
        private string strTitulo = "";
        private DataTable dtDatos;

        #region " Storage "
        private SystemSound _Sound;
        #endregion

        #region " Properties "
        internal SystemSound Sound
        {
            get { return _Sound; }
            set { _Sound = value; }
        }
        #endregion

        #region " Constructors "

        public frmMensajeAlerta(string Mensaje, string Titulo, DataTable Datos)
        {
            InitializeComponent();

            dtDatos = new DataTable();
            strMensaje = Mensaje;
            strTitulo = Titulo;
            dtDatos = Datos;
        }

        #endregion
        
        #region " Event handlers "

        private void frmMensajeAlerta_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        public void SizeForm()
        {
            //int NewHeight = 0;
            //int NewWidth = 0;

            ////Icon stays where it is.
            ////TextLabel.Left and QuestionLabel.Left are already correct

            //NewWidth = Math.Max(TextLabel.Width, QuestionTextLabel.Width) + TextLabel.Left + 4;
            //if (NewWidth < 275)
            //    NewWidth = 275;

            //Button1.Left = NewWidth - Button1.Width - 4;
            //Button2.Left = Button1.Left - Button2.Width - 4;
            //Button3.Left = Button2.Left - Button3.Width - 4;

            //if (string.IsNullOrEmpty(QuestionTextLabel.Text))
            //{
            //    PrintLabel.Top = TextLabel.Top + TextLabel.Height + 8;
            //}
            //else
            //{
            //    QuestionTextLabel.Top = TextLabel.Top + TextLabel.Height + 8;
            //    PrintLabel.Top = QuestionTextLabel.Top + QuestionTextLabel.Height + 8;
            //}

            //Button1.Top = PrintLabel.Top + PrintLabel.Height + 8;
            //Button2.Top = Button1.Top;
            //Button3.Top = Button1.Top;

            //NewHeight = Math.Max(Button1.Top + Button1.Height, MessagePictureBox.Top + MessagePictureBox.Height) + 4;

            //this.SetClientSizeCore(NewWidth, NewHeight);
        }

        #endregion

        private void frmMensajeAlerta_Load(object sender, EventArgs e)
        {            
            this.Text = strTitulo;
            lblPrincipal.Text = strMensaje;
            //faltanResultados();
            CargarLista();

        }

        public bool faltanResultados()
        {
            string detalles = "";
            bool blnResultado = false;

            if (dtDatos.Rows.Count > 0)
            {
                detalles = "";

                foreach (DataRow t in dtDatos.Rows)
                {
                    detalles = detalles + "\nPara el Nº Orden: L-" + t.ItemArray[0].ToString() + ". --> " +
                        t.ItemArray[1].ToString();

                    if (detalles.Contains("(No Requerido)"))
                    {
                        txtMensaje.SelectedText = t.ItemArray[1].ToString();
                        txtMensaje.SelectionColor = Color.Red;
                    }
                    else
                    {

                    }
                }

                txtMensaje.Text = detalles;
                //MessageBox.Show("¡Importación incompleta, los siguientes resultados de examen son requeridos y no se han encontrado en el archivo de Excel.\n" + detalles, "Atención",
                //MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                blnResultado = true;
            }

            return blnResultado;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarLista()
        {
            lstvLista.View = View.Details;
            lstvLista.Columns.Add("Fecha");
            lstvLista.Columns.Add("Nro. Orden");
            lstvLista.Columns.Add("DNI");
            lstvLista.Columns.Add("Falta Examen.");
            lstvLista.Columns[0].Width = 80;
            lstvLista.Columns[1].Width = 80;
            lstvLista.Columns[2].Width = 60;
            lstvLista.Columns[3].Width = 160;

            lstvLista.Items.Clear();

            foreach (DataRow row in dtDatos.Rows)
            {
                ListViewItem item = new ListViewItem(row["Fecha"].ToString());
                item.SubItems.Add(row["Orden"].ToString());
                item.SubItems.Add(row["DNI"].ToString());
                item.SubItems.Add(row["Mensaje"].ToString());
                lstvLista.Items.Add(item);
            }
        }
        // http://stackoverflow.com/questions/899350/how-do-i-copy-the-contents-of-a-string-to-the-clipboard-in-c
        private void btnCopiar_Click(object sender, EventArgs e)
        {
            copy_to_clipboard();
        }

        protected void copy_to_clipboard()
        {
            Thread clipboardThread = new Thread(SeleccionarTexto);
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.IsBackground = false;
            clipboardThread.Start();
        }

        private void SeleccionarTexto()
        {
            string strClip = "";

            strClip = "Fecha\tNroOrden\tDNI\tMensaje\n";

            foreach (DataRow row in dtDatos.Rows)
            {
                strClip = strClip + row["Fecha"].ToString() + "\t";
                strClip = strClip + row["Orden"].ToString() + "\t";
                strClip = strClip + row["DNI"].ToString() + "\t";
                strClip = strClip + row["Mensaje"].ToString() + "\n";
            }

            Clipboard.SetText(strClip);
        }
    }
}
