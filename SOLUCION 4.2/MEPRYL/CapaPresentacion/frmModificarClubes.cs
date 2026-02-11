using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmModificarClubes : Form
    {
        private string strID = "";
        private string strCodigo = "";
        private string strIdLiga = "";
        private string strCodigoLiga = "";
        private string strNombreClub = "";
        private string strNombreLiga = "";
        private bool blnActivo = false;
        private string strPathImagen = "";
        private string strDireccion1 = "";
        private string strDireccion2 = "";
        private string strContacto = "";
        private string strTelefono = "";
        private string strMail = "";
        private string strUrlMapa = "";
        private bool blnActualizar = false;


        private CapaNegocioMepryl.ClubMantenimiento Club;
        private CapaNegocioMepryl.LigaMantenimiento Liga;

        public frmModificarClubes(string ID, string Codigo, string IdLiga, string CodigoLiga, string NombreLiga, string NombreClub, bool Activo, string PathImagen, string Direccion1, string Direccion2, string Contacto, string Telefono, string Mail, string URL, bool Actualizar)
        {
            InitializeComponent();
            Club = new CapaNegocioMepryl.ClubMantenimiento();
            Liga = new CapaNegocioMepryl.LigaMantenimiento();

            cmbLigas.DataSource = Liga.LigasActivas();
            cmbLigas.DisplayMember = "Descripcion";
            cmbLigas.ValueMember = "Id";

            strID = ID;
            strCodigo = Codigo;
            strIdLiga = IdLiga;
            strCodigoLiga = CodigoLiga;
            strNombreClub = NombreClub;
            strNombreLiga = NombreLiga;
            blnActivo = Activo;
            strPathImagen = PathImagen;
            strDireccion1 = Direccion1;
            strDireccion2 = Direccion2;
            strContacto = Contacto;
            strTelefono = Telefono;
            strMail = Mail;
            strUrlMapa = URL;
            blnActualizar = Actualizar;

            LlenarFormulario();
        }

        private void ptbImagen_DoubleClick(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        private void LlenarFormulario()
        {
            if (blnActualizar == true)
            {
                txtNombre.Text = strNombreClub;
                cmbLigas.Text = strNombreLiga;
                chkActivo.Checked = blnActivo;
                txtDireccion1.Text = strDireccion1;
                txtDireccion2.Text = strDireccion2;
                txtContacto.Text = strContacto;
                txtTelefono.Text = strTelefono;
                txtMail.Text = strMail;
                txtGoogleMaps.Text = strUrlMapa;

                if (!(string.IsNullOrEmpty(strPathImagen)))
                    ptbImagen.Image = Image.FromFile(strPathImagen);

                this.Text = "Modificar registro";
            }
            else
            {
                this.Text = "Nuevo registro";

            }

            //txtNombre.CharacterCasing = CharacterCasing.Upper;            
        }

        private void AbrirArchivo()
        {
            OpenFileDialog ofdAbrirArchivo = new OpenFileDialog();

            ofdAbrirArchivo.InitialDirectory = @"S:\PUBLICO\MARIAN\PAGINA ZETAHOSTING\imagenes\deportiva\instituciones\todos";
            ofdAbrirArchivo.Filter = "JPEG|*.jpg;*.jpeg;*.jpe|PNG|*.png";

            if (ofdAbrirArchivo.ShowDialog() == DialogResult.OK)
            {
                strPathImagen = ofdAbrirArchivo.FileName;
                ptbImagen.Image = Image.FromFile(strPathImagen);                
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtNombre.Text)))
            {
                guardar();
                this.Close();
            }
            else
                MessageBox.Show("Antes de guardar debe asignar un nombre al Club.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void guardar()
        {            
            CargarDatos();
            Club.ActualizarClub(ObtenerDatosDGV());           
        }

        private void CargarDatos()
        {            
            strNombreClub = txtNombre.Text;
            strNombreLiga = cmbLigas.Text;
            strIdLiga = cmbLigas.SelectedValue.ToString(); ;
            strCodigoLiga = Liga.RecuperaCodigoLiga(strIdLiga);
            blnActivo = chkActivo.Checked;
            strDireccion1 = txtDireccion1.Text;
            strDireccion2 = txtDireccion2.Text;
            strContacto = txtContacto.Text;
            strTelefono = txtTelefono.Text;
            strMail = txtMail.Text;
            strUrlMapa = txtGoogleMaps.Text;
        }
                
        private DataTable ObtenerDatosDGV()
        {
            DataTable dt = new DataTable();
            
            dt.Columns.Add("Id", typeof(System.String));
            dt.Columns.Add("Codigo", typeof(System.String));
            dt.Columns.Add("IdLiga", typeof(System.String));
            dt.Columns.Add("CodigoLiga", typeof(System.String));
            dt.Columns.Add("NombreClub", typeof(System.String));                        
            dt.Columns.Add("Activo", typeof(System.Boolean));            
            dt.Columns.Add("PathImagen", typeof(System.String));
            dt.Columns.Add("Direccion1", typeof(System.String));
            dt.Columns.Add("Direccion2", typeof(System.String));
            dt.Columns.Add("Contacto", typeof(System.String));
            dt.Columns.Add("Telefono", typeof(System.String));
            dt.Columns.Add("Mail", typeof(System.String));
            dt.Columns.Add("URL", typeof(System.String));
        
            DataRow row = dt.NewRow();

            row["Id"] = strID;
            row["Codigo"] = strCodigo;
            row["IdLiga"] = strIdLiga;
            row["CodigoLiga"] = strCodigoLiga;
            row["NombreClub"] = strNombreClub;                
            row["Activo"] = blnActivo;                
            row["PathImagen"] = strPathImagen;
            row["Direccion1"] = strDireccion1;
            row["Direccion2"] = strDireccion2;
            row["Contacto"] = strContacto;
            row["Telefono"] = strTelefono;
            row["Mail"] = strMail;
            row["URL"] = strUrlMapa;

            dt.Rows.Add(row);
            
            return dt;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        private void btnVerMapa_Click(object sender, EventArgs e)
        {   
            if (!(string.IsNullOrEmpty(txtGoogleMaps.Text)))
                System.Diagnostics.Process.Start(txtGoogleMaps.Text);
            else
                System.Diagnostics.Process.Start("https://www.google.com.ar/maps/place/Centro+M%C3%A9dico+Mepryl+-+MEPRYL+S.A./@-34.6246652,-58.380405,16.5z/data=!4m5!3m4!1s0x0:0x53314810fdad8caf!8m2!3d-34.624068!4d-58.378416");
            //frmNavegadorWeb frmWeb = new frmNavegadorWeb(txtGoogleMaps.Text);
            //frmWeb.ShowDialog();
        }
    }
}
