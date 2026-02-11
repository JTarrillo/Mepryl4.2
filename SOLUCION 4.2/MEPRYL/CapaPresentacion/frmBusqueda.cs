using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaPresentacionBase;
using CapaNegocio;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmBusqueda : frmBaseBusqueda
    {
        public frmBusqueda()
        {
            InitializeComponent();
            
        }

        public frmBusqueda(Configuracion conf, string entidadNom)
            : base(conf, entidadNom)
        {
            this.tbPalabrasClave.CharacterCasing = CharacterCasing.Upper;
        }

        public override void crearEntidadFac()
        {
            this.entidadFac = new EntidadGeneralFactory(this.configuracion, this.EntidadNombre);
        }

     
       
    }
}