using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Microsoft.Reporting.WinForms;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmReporteMesaDeEntrada : Form
    {
        DataTable clubes = new DataTable();
        DataTable examenPersonalizado = new DataTable();
        DataGridViewRow row;
        string empresa = "";
        string tarea = "";
        int pos;
        public frmReporteMesaDeEntrada(DataTable tabla, DataGridViewRow fila, string emp, string tar)
        {
            InitializeComponent();
            clubes = tabla;
            row = fila;
            empresa = emp;
            tarea = tar;
        }

        private void frmReporteMesaDeEntrada_Load(object sender, EventArgs e)
        {
            setearParametrosDelReporte();
            this.reportViewer.RefreshReport();
        }

        private void setearParametrosDelReporte()
        {
            ReportParameter[] parameters = new ReportParameter[37];
            parameters[0] = new ReportParameter("nroOrden", row.Cells[4].Value.ToString());
            parameters[1] = new ReportParameter("nroExamen", row.Cells[7].Value.ToString());
            parameters[2] = new ReportParameter("tipoDeExamen", row.Cells[6].Value.ToString());
            parameters[3] = new ReportParameter("fecha", row.Cells[2].Value.ToString());
            parameters[4] = new ReportParameter("nombre", row.Cells[8].Value.ToString() + " " + row.Cells[9].Value.ToString());
            parameters[5] = new ReportParameter("dni", row.Cells[10].Value.ToString());
            DateTime nacimiento = (DateTime)row.Cells[13].Value;
            parameters[6] = new ReportParameter("nacimiento", nacimiento.ToShortDateString());
            if (row.Cells[15].Value.ToString() != "")
            {
                parameters[7] = new ReportParameter("telefono", row.Cells[15].Value.ToString());
            }
            else
            {
                parameters[7] = new ReportParameter("telefono", row.Cells[14].Value.ToString());
            }
            consultarItemsPrincipales();
            parameters[8] = new ReportParameter("clinico", comprobarEstado("1"));
            parameters[9] = new ReportParameter("electrocardiograma", comprobarEstado("78"));
            parameters[10] = new ReportParameter("rx", comprobarEstado("38"));
            parameters[11] = new ReportParameter("liga1", "");
            parameters[12] = new ReportParameter("club1", "");
            parameters[13] = new ReportParameter("liga2", "");
            parameters[14] = new ReportParameter("club2", "");
            parameters[15] = new ReportParameter("liga2", "");
            parameters[16] = new ReportParameter("club3", "");
            parameters[17] = new ReportParameter("item1", "");
            parameters[18] = new ReportParameter("valor1", "");
            parameters[19] = new ReportParameter("item2", "");
            parameters[20] = new ReportParameter("valor2", "");
            parameters[21] = new ReportParameter("item3", "");
            parameters[22] = new ReportParameter("valor3", "");
            parameters[23] = new ReportParameter("item4", "");
            parameters[24] = new ReportParameter("valor4", "");
            parameters[25] = new ReportParameter("item5", "");
            parameters[26] = new ReportParameter("valor5", "");
            parameters[27] = new ReportParameter("item6", "");
            parameters[28] = new ReportParameter("valor6", "");
            parameters[29] = new ReportParameter("item7", "");
            parameters[30] = new ReportParameter("valor7", "");
            parameters[31] = new ReportParameter("item8", "");
            parameters[32] = new ReportParameter("valor8", "");
            parameters[33] = new ReportParameter("item9", "");
            parameters[34] = new ReportParameter("valor9", "");
            parameters[35] = new ReportParameter("laboratorio", "");
            parameters[36] = new ReportParameter("tarea", "");
            int cont = 1;
            int parm = 11;
            if (row.Cells[5].Value.ToString() == "P")
            {
                foreach (DataRow r in clubes.Rows)
                {
                    if (cont <= 3)
                    {
                        parameters[parm] = new ReportParameter("liga" + cont.ToString(), r.ItemArray[0].ToString());
                        parm++;
                        parameters[parm] = new ReportParameter("club" + cont.ToString(), r.ItemArray[1].ToString());
                        parm++;

                    }
                    cont++;
                }
            }
            else
            {
                parameters[parm] = new ReportParameter("liga" + cont.ToString(), empresa);
                parm++;
                parameters[36] = new ReportParameter("tarea", tarea);

            }
            parm = 17;
            cont = 1;
            DataRow[] resultClinico = examenPersonalizado.Select("Orden = 1 and Estado = 1");
            foreach (DataRow r in resultClinico)
            {
                if (cont <= 21)
                {
                    parameters[parm] = new ReportParameter("item" + cont.ToString(), r.ItemArray[1].ToString());
                    cont++;
                }
            }
            DataRow[] resultRX = examenPersonalizado.Select("(Orden = 8 or Orden = 9 or Orden = 10 or Orden = 11) and Estado = 1 and not(Id = 38)");
            foreach (DataRow r in resultRX)
            {
                parameters[parm] = new ReportParameter("item" + cont.ToString(), r.ItemArray[1].ToString());
                parm++;
                parameters[parm] = new ReportParameter("valor" + cont.ToString(), "X");
                parm++;
                cont++;
            }
            DataRow[] resultComp = examenPersonalizado.Select("Orden = 12 and Estado = 1 and not(Id = 78)");
            foreach (DataRow r in resultComp)
            {
                parameters[parm] = new ReportParameter("item" + cont.ToString(), r.ItemArray[1].ToString());
                parm++;
                parameters[parm] = new ReportParameter("valor" + cont.ToString(), "X");
                parm++;
                cont++;
            }
            DataRow[] resultLab = examenPersonalizado.Select("(Orden = 2 or Orden = 3 or Orden = 4 or Orden = 5 or Orden = 6 or Orden = 7) and Estado = 1 and not(Id = 38)");
            string itemsLaboratorio = "";
            cont = 1;
            foreach (DataRow r in resultLab)
            {
                if (cont == 1)
                {
                    itemsLaboratorio = r.ItemArray[1].ToString();
                    cont++;
                }
                else
                {
                    itemsLaboratorio = itemsLaboratorio + " - " + r.ItemArray[1].ToString();
                }
            }
            parameters[35] = new ReportParameter("laboratorio", itemsLaboratorio);
            this.reportViewer.LocalReport.SetParameters(parameters);
        }

   

        private void consultarItemsPrincipales()
        {
            string idConsulta = row.Cells[0].Value.ToString();
            DataTable nroExamen = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.TipoExamenDePaciente where idConsulta = '" + idConsulta + "'");
            string idTipoExamen = nroExamen.Rows[0].ItemArray[0].ToString();
            examenPersonalizado = SQLConnector.obtenerTablaSegunConsultaString(@"select i.id as Id, i.nombreCompleto as Nombre, i.ordenFormulario as Orden, ip.estado as Estado 
            from dbo.ItemsPorPaciente ip inner join dbo.Items i on ip.idItem = i.id where ip.idTipoExamenPaciente = '" + idTipoExamen + "'");

        }


        private string comprobarEstado(string id)
        {
            foreach (DataRow fila in examenPersonalizado.Rows)
            {
                if (fila.ItemArray[0].ToString() == id)
                {
                    if (consultarEstado(fila.ItemArray[3].ToString()))
                    {
                        return "X";
                    }
                    return "";
                }
            }
            return "";

        }

        private bool consultarEstado(string valor)
        {
            if (valor == "1")
            {
                return true;
            }
            return false;
        }

        private void reportViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
