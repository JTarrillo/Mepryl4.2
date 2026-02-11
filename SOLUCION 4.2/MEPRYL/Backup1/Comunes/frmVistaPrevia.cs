using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Comunes
{
    public partial class frmVistaPrevia : Form
    {
        public frmVistaPrevia()
        {
            InitializeComponent();

        }

        public frmVistaPrevia(ReportClass doc):this()
        {
            crystalReportViewer1.ReportSource = doc;

            crystalReportViewer1.DisplayGroupTree = false;
        }
    }
}