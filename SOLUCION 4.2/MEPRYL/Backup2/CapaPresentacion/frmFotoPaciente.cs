using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmFotoPaciente : Form
    {           
        private bool ExisteDispositivo = false;
        private FilterInfoCollection DispositivoDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;
        private string strRuta = "S:\\FOTOS\\";
        private string strDNIPersona = "";
        private bool blnEstadoGuardar = false;
        private char strPaciente;
        UbicacionFotos DirectorioFotos = new UbicacionFotos();

        public frmFotoPaciente(string strDNI, char strTipoPaciente)
        {
            InitializeComponent();
            BuscarDispositivos();
            strDNIPersona = strDNI;
            strPaciente = strTipoPaciente;
            this.Location = new Point(50, 75);
        }
        
        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            for (int i = 0; i < Dispositivos.Count; i++) ;

            cbxDispositivos.Items.Add(Dispositivos[0].Name.ToString());
            cbxDispositivos.Text = cbxDispositivos.Items[0].ToString();
        }

        public void BuscarDispositivos()
        {
            DispositivoDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (DispositivoDeVideo.Count == 0)
            {
                ExisteDispositivo = false;
            }

            else
            {
                ExisteDispositivo = true;
                CargarDispositivos(DispositivoDeVideo);
            }
        }

        public void TerminarFuenteDeVideo()
        {
            if (!(FuenteDeVideo == null))
                if (FuenteDeVideo.IsRunning)
                {
                    FuenteDeVideo.SignalToStop();
                    FuenteDeVideo = null;
                }
        }

        public void Video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            ptbEspacioCamara.Image = Imagen;
        }

        private void GuardarImagen(string strArchivo)
        {            
            if (System.IO.File.Exists(strArchivo))
            {
                System.IO.File.Delete(strArchivo);
                ptbEspacioCamara.Image.Save(strArchivo, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                ptbEspacioCamara.Image.Save(strArchivo, System.Drawing.Imaging.ImageFormat.Jpeg);
            }            
        }

        private void IniciarVideo()
        {            
            if (ExisteDispositivo)
            {
                FuenteDeVideo = new VideoCaptureDevice(DispositivoDeVideo[cbxDispositivos.SelectedIndex].MonikerString);
                FuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);
                FuenteDeVideo.Start();
                Estado.Text = "Ejecutando Dispositivo…";                
                cbxDispositivos.Enabled = false;                
            }
            else
            {
                Estado.Text = "Error: No se encuenta el Dispositivo";
            }        
        }

        private void TerminarVideo()
        {
            if (FuenteDeVideo.IsRunning)
            {
                TerminarFuenteDeVideo();
                Estado.Text = "Dispositivo Detenido…";                
                cbxDispositivos.Enabled = true;
            }
        }
                
        private void btnCapturar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FuenteDeVideo.IsRunning)
                {
                    PictureBox ptbImagen = new PictureBox();

                    ptbImagen.Image = ptbEspacioCamara.Image;
                    TerminarVideo();
                    ptbEspacioCamara.Image = ptbImagen.Image;

                    btnCapturar.Image = Properties.Resources.Update;
                    btnGuardar.Image = Properties.Resources.GuardarSalir01;
                    blnEstadoGuardar = true;
                }
                else
                {
                    IniciarVideo();
                    btnCapturar.Image = Properties.Resources.Camera_Front01;
                    btnGuardar.Image = Properties.Resources.CancelarSalir;
                    blnEstadoGuardar = false;
                }
            }
            catch (NullReferenceException ex)
            {
                IniciarVideo();
                btnCapturar.Image = Properties.Resources.Camera_Front01;
                btnGuardar.Image = Properties.Resources.CancelarSalir;
                blnEstadoGuardar = false;
                //Estado.Text = "Error: No se encuenta el Dispositivo";
            }
        }

        private void frmFotoPaciente_Load(object sender, EventArgs e)
        {
            IniciarVideo();
            btnGuardar.Image = Properties.Resources.CancelarSalir;

            switch (strPaciente)
            {
                case 'L':
                    strRuta = DirectorioFotos.UbicacionFotoLaboral() + "\\";
                    break;
                case 'P':
                    strRuta = DirectorioFotos.UbicacionFotopreventiva() + "\\";
                    break;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TerminarFuenteDeVideo();

            if (blnEstadoGuardar)
            {
                GuardarImagen(strRuta + strDNIPersona + ".jpg");
            }

            this.Close();
        }

        private void frmFotoPaciente_FormClosing(Object sender, FormClosingEventArgs e)
        {
            TerminarFuenteDeVideo();
        }               
    }    
}
