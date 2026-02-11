using System;
using System.Collections.Generic;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace CapaPresentacion
{
    public class Reportes
    {
        ReportClass rpt;
        public Reportes(ReportClass reporte)
        {
            rpt = reporte;
        }

        public void setearParametrosReporte(DataTable t)
        {
            for (int i = 0; i <= t.Columns.Count - 1; i++)
            {
                rpt.SetParameterValue(i, t.Rows[0].ItemArray[i].ToString());

            }
        }

        public void setearDataSource(DataSet ds, DataTable t)
        {
            setearDataSource(ds, t, 0);
        }

        public void setearDataSource(DataSet ds, DataTable t1, DataTable t2)
        {
            setearDataSource(ds, t1, 0);
            setearDataSource(ds, t2, 1);
        }

        public void setearDataSource(DataSet ds, DataTable t, int nroTabla)
        {
            foreach (DataRow dataR in t.Rows)
            {
                DataRow dr = ds.Tables[nroTabla].NewRow();
                for (int i = 0; i <= t.Columns.Count - 1; i++)
                {
                    if (t.Rows.Count > 0)
                    {
                        dr[i] = dataR.ItemArray[i];
                    }
                    else
                    {
                        dr[i] = null;
                    }
                }
                ds.Tables[nroTabla].Rows.Add(dr);
            }
            rpt.SetDataSource(ds);
        }

        public void imprimir(DataTable parametros, DataSet ds, DataTable contenidoDs)
        {
            this.setearDataSource(ds, contenidoDs);
            this.setearParametrosReporte(parametros);
            rpt.PrintToPrinter(1, true, 1, 1);
            rpt.Close();
        }

        public void imprimirLaboratorio(DataTable parametros, DataSet ds)
        {
            rpt.SetDataSource(parametros);
            rpt.PrintToPrinter(1, true, 1, 2);
            rpt.Close();
        }

        public void ExportarLaboratorio(DataTable parametros, string Ubicacion)
        {
            rpt.SetDataSource(parametros);            
            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
            Ubicacion);            
            rpt.Close();
        }

        public void imprimir(DataTable parametros)
        {
            this.setearParametrosReporte(parametros);
            rpt.PrintToPrinter(1, true, 1, 1);
            rpt.Close();
        }

        public void imprimir()
        {
            rpt.PrintToPrinter(1, true, 1, 0);
            rpt.Close();
        }

        public string exportarAPDF(DataTable parametros, DataSet ds, DataTable contenidoDs,
            string ubicacion)
        {
            this.setearDataSource(ds, contenidoDs);
            this.setearParametrosReporte(parametros);
            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
            ubicacion);
            rpt.Close();
            return ubicacion;
        }

        public string exportarAPDF(string ubicacion)
        {
            rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
            ubicacion);
            rpt.Close();
            return ubicacion;
        }

        public Entidades.Resultado imprimirYExportar(DataTable parametros, DataSet ds, DataTable contenidoDs,
            string ubicacion)
        {
            Entidades.Resultado retorno = new Entidades.Resultado();
            try
            {
                this.setearDataSource(ds, contenidoDs);
                this.setearParametrosReporte(parametros);
                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                ubicacion);
                rpt.PrintToPrinter(1, true, 1, 1);
                rpt.Close();
                retorno.Modo = 1;
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Modo = -1;
                retorno.Mensaje = ex.ToString();
                return retorno;
            }
        }
    }
}
