using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmNavegadorWeb : Form
    {
        private string strURL = "";
        private string strURLDefault = "";

        public frmNavegadorWeb(string URL)
        {
            InitializeComponent();

            strURL = URL;
            strURLDefault = "https://www.google.com.ar/maps/place/Centro+M%C3%A9dico+Mepryl+-+MEPRYL+S.A./@-34.6230205,-58.3822668,16.25z/data=!4m5!3m4!1s0x0:0x53314810fdad8caf!8m2!3d-34.624068!4d-58.378416";
            CargarMapa();
        }

        private void CargarMapa()
        {
            if (!(string.IsNullOrEmpty(strURL)))
            {
                webBrowser1.Navigate(new Uri(strURL));
            }
            else
            {
                webBrowser1.Navigate(new Uri(strURLDefault));
            }
            
        }   
    }
}
