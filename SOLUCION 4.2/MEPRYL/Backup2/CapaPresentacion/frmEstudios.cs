using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;
using CapaPresentacion;

namespace CapaPresentacion
{
    public partial class frmEstudios : Form
    {
        public int modoDeApertura;
        public string idEspecialidad;
        public DataTable tipoDeExamen = new DataTable();
        public double imp;
        public frmTurno vistaTurno;
        public bool hacerPlaca;
        private frmExamenLaboral laboral;

        public frmEstudios(string texto)
        {
            InitializeComponent();
            this.Text = texto;
        }

        public frmEstudios(string idEsp, int modAp)
        {
            InitializeComponent();
            modoDeApertura = modAp;
            idEspecialidad = idEsp;
        }

        public frmEstudios(frmTurno frm, string idEsp, int modAp, bool placa)
        {
            InitializeComponent();
            modoDeApertura = modAp;
            idEspecialidad = idEsp;
            vistaTurno = frm;
            hacerPlaca = placa;
        }

        public frmEstudios(DataTable tabla, int modAp, string idEsp, double importe)
        {
            InitializeComponent();
            tipoDeExamen.Columns.Add("Id");
            tipoDeExamen.Columns.Add("Estado");
            tipoDeExamen.Columns.Add("Nombre");
            tipoDeExamen.Columns.Add("OrdenEnFormulario");
            tipoDeExamen.Columns.Add("IdItem");
            modoDeApertura = modAp;
            tipoDeExamen = tabla;
            idEspecialidad = idEsp;
            imp = importe;
        }

        public frmEstudios(frmTurno frm,DataTable tabla, int modAp, string idEsp, double importe)
        {
            InitializeComponent();
            tipoDeExamen.Columns.Add("Id");
            tipoDeExamen.Columns.Add("Estado");
            tipoDeExamen.Columns.Add("Nombre");
            tipoDeExamen.Columns.Add("OrdenEnFormulario");
            tipoDeExamen.Columns.Add("IdItem");
            modoDeApertura = modAp;
            tipoDeExamen = tabla;
            idEspecialidad = idEsp;
            imp = importe;
            vistaTurno = frm;
        }

        public frmEstudios(DataTable tabla, int modAp, string idEsp)
        {
            InitializeComponent();
            tipoDeExamen.Columns.Add("Id");
            tipoDeExamen.Columns.Add("Estado");
            tipoDeExamen.Columns.Add("Nombre");
            tipoDeExamen.Columns.Add("OrdenEnFormulario");
            tipoDeExamen.Columns.Add("IdItem");
            modoDeApertura = modAp;
            tipoDeExamen = tabla;
            idEspecialidad = idEsp;
        }

        public frmEstudios(string idTipoExamen, frmExamenLaboral frm)
        {
            InitializeComponent();
            modoDeApertura = 5;
            tipoDeExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select ip.id as Id, ip.estado as Estado, i.nombreInformes as Nombre,
            i.ordenFormulario as OrdenFormulario, i.id as IdItem
            from dbo.ItemsPorPaciente ip inner join dbo.Items i on ip.idItem = i.id
            where ip.idTipoExamenPaciente = '" + idTipoExamen + "' order by i.id");
            DataTable especialidad = SQLConnector.obtenerTablaSegunConsultaString("select idEspecialidad from dbo.TipoExamenDePaciente where id = '" + idTipoExamen + "'");
            idEspecialidad = especialidad.Rows[0].ItemArray[0].ToString();
            laboral = frm;

        }

        public frmEstudios()
        {
            
            InitializeComponent();
        }

        private void frmEstudios_Load(object sender, EventArgs e)
        {
            if ((modoDeApertura == 1 || modoDeApertura == 2 || modoDeApertura == 3 || modoDeApertura == 4
                || modoDeApertura == 5)) //Cuando se abre para editar los examenes predeterminados
            {
                cargarTablasYDataGrids("1", dgvClinico);
                cargarTablasYDataGrids("2", dgvHematologia);
                cargarTablasYDataGrids("3", dgvQuimicaHematica);
                cargarTablasYDataGrids("4", dgvSerologia);
                cargarTablasYDataGrids("5", dgvPerfilLipidico);
                cargarTablasYDataGrids("6", dgvBacteriologia);
                cargarTablasYDataGrids("7", dgvOrina);
                cargarTablasYDataGrids("8", dgvLaboralesBasicas);
                cargarTablasYDataGrids("9", dgvCraneoYMSuperior);
                cargarTablasYDataGrids("10", dgvTroncoYPelvis);
                cargarTablasYDataGrids("11", dgvMiembroInferior);
                cargarTablasYDataGrids("12", dgvEstComplementarios);
               
            }

            if (modoDeApertura == 1 || modoDeApertura == 2)
            {
                gbImporte.Enabled = true;
                cargarImportePredeterminado();
            
            }
            else if (modoDeApertura == 3 || modoDeApertura == 4 || modoDeApertura == 5)
            {
                gbImporte.Enabled = true;
                tbImporte.Text = imp.ToString();
             
            }
          
        }




        private void cargarImportePredeterminado()
        {
            DataTable importe = SQLConnector.obtenerTablaSegunConsultaString("select precioBase from dbo.Especialidad where id = '" + idEspecialidad + "'");
            tbImporte.Text = importe.Rows[0].ItemArray[0].ToString();
        }
        private void cargarTablasYDataGrids(string ordenFormulario, DataGridView dataGrid)
        {
           
            if (modoDeApertura == 1 || modoDeApertura == 2)
            {
               DataTable tabla = new DataTable();
               tabla  = SQLConnector.obtenerTablaSegunConsultaString(@"select IP.id as Id, I.nombreInformes as Nombre, IP.estado as Estado, I.ordenFormulario, I.id As IdItem 
            from dbo.ItemsPredefinidos IP inner join dbo.Items I
            on IP.idItem = I.id  where I.ordenFormulario = " + ordenFormulario + "and IP.idEspecialidad = '" + idEspecialidad + "'");
               if (modoDeApertura == 2 && ordenFormulario == "8" && !hacerPlaca)
               {
                   tabla.Rows[0][2] = 0;
                 
               }
               agregarAlDataGrid(tabla, dataGrid);
            }
            else if (modoDeApertura == 4 || modoDeApertura == 5)
            {
                foreach (DataRow row in tipoDeExamen.Rows)
                {
                    if (row.ItemArray[3].ToString() == ordenFormulario)
                    {
                        if (row.ItemArray[1].ToString() == "1")
                        {
                            dataGrid.Rows.Add(row.ItemArray[0], true, row.ItemArray[2], row.ItemArray[3], row.ItemArray[4]);
                        }
                        else
                        {
                            dataGrid.Rows.Add(row.ItemArray[0], false, row.ItemArray[2], row.ItemArray[3], row.ItemArray[4]);
                        }
                    }
                }


            }
            else
            {
                foreach (DataRow row in tipoDeExamen.Rows)
                {
                    if (row.ItemArray[3].ToString() == ordenFormulario)
                    {
                        if (row.ItemArray[1].ToString() == "True")
                        {
                            dataGrid.Rows.Add(row.ItemArray[0], true, row.ItemArray[2], row.ItemArray[3], row.ItemArray[4]);
                        }
                        else
                        {
                            dataGrid.Rows.Add(row.ItemArray[0], false, row.ItemArray[2], row.ItemArray[3], row.ItemArray[4]);
                        }
                    }
                }

            }
           
        }

        private void agregarAlDataGrid(DataTable tabla, DataGridView dataGrid)
        {
            foreach (DataRow row in tabla.Rows)
            {
                if (row.ItemArray[2].ToString() == "1")
                {
                    dataGrid.Rows.Add(row.ItemArray[0], true, row.ItemArray[1],row.ItemArray[3],row.ItemArray[4]);
                }
                else
                {
                    dataGrid.Rows.Add(row.ItemArray[0], false, row.ItemArray[1],row.ItemArray[3],row.ItemArray[4]);
                }
            }
            
        }
        private void actualizarImportePredefinido()
        {
            List<string> lista = SQLConnector.generarListaParaProcedure("@idEsp", "@importe");
            SQLConnector.executeProcedure("dbo.sp_Predefinido_ActualizarImporte", lista, new Guid(idEspecialidad),Convert.ToDouble(tbImporte.Text));
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            if (modoDeApertura == 1)
            {

                if (tbImporte.Text != "")
                {
                    actualizarImportePredefinido();
                    actualizarPredefinido();               
                }
                else
                {
                    MessageBox.Show("Verifique importe para continuar");
                }
            }
            else if (modoDeApertura == 2 || modoDeApertura == 3)
            {
                DataTable tabla = new DataTable();
                tabla.Columns.Add("Id");
                tabla.Columns.Add("Estado");
                tabla.Columns.Add("Nombre");
                tabla.Columns.Add("OrdenEnFormulario");
                tabla.Columns.Add("IdItem");
                unirATabla(dgvClinico, tabla);
                unirATabla(dgvHematologia, tabla);
                unirATabla(dgvQuimicaHematica, tabla);
                unirATabla(dgvSerologia, tabla);
                unirATabla(dgvPerfilLipidico, tabla);
                unirATabla(dgvBacteriologia, tabla);
                unirATabla(dgvOrina, tabla);
                unirATabla(dgvLaboralesBasicas, tabla);
                unirATabla(dgvCraneoYMSuperior, tabla);
                unirATabla(dgvTroncoYPelvis, tabla);
                unirATabla(dgvMiembroInferior, tabla);
                unirATabla(dgvEstComplementarios, tabla);
                bool modif = verificarSiEstaModificado(tabla);
                if (modif)
                {
                    DialogResult result = MessageBox.Show("El exámen fue modificado. ¿El importe ingresado es correcto?", "Confirmar Importe", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        vistaTurno.recibirTablasDeTipoDeExamen(tabla, modif, Convert.ToDouble(tbImporte.Text));
                        this.Close();
                    }

                }
                else
                {
                    vistaTurno.recibirTablasDeTipoDeExamen(tabla, modif, Convert.ToDouble(tbImporte.Text));
                    this.Close();
                }
                
            }
            else if (modoDeApertura == 4 || modoDeApertura == 5)
            {
                DataTable tabla = new DataTable();
                tabla.Columns.Add("Id");
                tabla.Columns.Add("Estado");
                tabla.Columns.Add("Nombre");
                tabla.Columns.Add("OrdenEnFormulario");
                tabla.Columns.Add("IdItem");
                unirATabla(dgvClinico, tabla);
                unirATabla(dgvHematologia, tabla);
                unirATabla(dgvQuimicaHematica, tabla);
                unirATabla(dgvSerologia, tabla);
                unirATabla(dgvPerfilLipidico, tabla);
                unirATabla(dgvBacteriologia, tabla);
                unirATabla(dgvOrina, tabla);
                unirATabla(dgvLaboralesBasicas, tabla);
                unirATabla(dgvCraneoYMSuperior, tabla);
                unirATabla(dgvTroncoYPelvis, tabla);
                unirATabla(dgvMiembroInferior, tabla);
                unirATabla(dgvEstComplementarios, tabla);

                List<string> lista = SQLConnector.generarListaParaProcedure("@id", "@estado");
                foreach (DataRow row in tabla.Rows)
                {
                    int valor;
                    if (row.ItemArray[1].ToString() == "True")
                    {
                        valor = 1;
                    }
                    else
                    {
                        valor = 0;
                    }

                    SQLConnector.executeProcedure("dbo.sp_Items_UpdateDesdeMesaDeEntrada", lista, row.ItemArray[0],valor);
                }
              
                DataTable tipoDeExamen = SQLConnector.obtenerTablaSegunConsultaString(@"select tep.id from dbo.ItemsPorPaciente ip inner join dbo.TipoExamenDePaciente tep on ip.idTipoExamenPaciente = tep.id
                                         where ip.id = '" + tabla.Rows[0].ItemArray[0].ToString() + "'");
                string idExamenPaciente = tipoDeExamen.Rows[0].ItemArray[0].ToString();
                List<string> listaParaProc = SQLConnector.generarListaParaProcedure("@id", "@valor", "@importe");
                if (verificarSiEstaModificado(tabla))
                {
                    DialogResult result = MessageBox.Show("El exámen fue modificado. ¿El importe ingresado es correcto?", "Confirmar Importe", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        SQLConnector.executeProcedure("sp_TipoExamenDePaciente_UpdateDesdeMesaDeEntrada", listaParaProc, new Guid(idExamenPaciente), "(*)", Convert.ToDouble(tbImporte.Text));
                        this.Close();
                        if (modoDeApertura == 5) { laboral.refreshExamen(); }
                    }
                   
                    
                }
                else
                {
                    SQLConnector.executeProcedure("sp_TipoExamenDePaciente_UpdateDesdeMesaDeEntrada", listaParaProc, new Guid(idExamenPaciente), "", Convert.ToDouble(tbImporte.Text));
                    this.Close();
                    if (modoDeApertura == 5) { laboral.refreshExamen(); }
                }
                
            }
        }

        private bool verificarSiEstaModificado(DataTable t)
        {
            t.DefaultView.Sort = "IdItem";
            DataTable predefinido = SQLConnector.obtenerTablaSegunConsultaString(@"select idItem, estado from dbo.ItemsPredefinidos 
            where idEspecialidad = '" + idEspecialidad + "' order by idItem asc");
            foreach (DataRow row in t.Rows)
            {
                string var;
                DataRow[] filaFiltro;
                filaFiltro = predefinido.Select("idItem = " + row.ItemArray[4].ToString());
                
                if (filaFiltro[0][1].ToString() == "1")
                {
                    var = "True";
                }
                else
                {
                    var = "False";
                }
                if (row.ItemArray[1].ToString() != var)
                {
                    return true;
                }
                 
               

            }
            return false;



        }

        private void unirATabla(DataGridView dataGrid, DataTable tabla)
        {
            
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                tabla.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value);
            }
        }

        private void actualizarPredefinido()
        {
            actualizador(dgvClinico,1);
            actualizador(dgvHematologia,1);
            actualizador(dgvQuimicaHematica,1);
            actualizador(dgvSerologia,1);
            actualizador(dgvPerfilLipidico,1);
            actualizador(dgvBacteriologia,1);
            actualizador(dgvOrina,1);
            actualizador(dgvLaboralesBasicas,1);
            actualizador(dgvCraneoYMSuperior,1);
            actualizador(dgvTroncoYPelvis,1);
            actualizador(dgvMiembroInferior,1);
            actualizador(dgvEstComplementarios,1);
            MessageBox.Show("Exámen predefinido actualizado correctamente");
            this.Close();
        }

        private void actualizador(DataGridView datagrid, int modo)
        {
            foreach (DataGridViewRow row in datagrid.Rows)
            {
                int id = (int)row.Cells[0].Value;
                string valor = consultarValor((bool)row.Cells[1].Value);
                List<string> lista = SQLConnector.generarListaParaProcedure("@idEx", "@valor");
                SQLConnector.executeProcedure("sp_Items_ExamenPredefinidoUpdate", lista, id, valor);
            }
        }

        private string consultarValor(bool unValor)
        {
            if (unValor == true)
            {
                return "1";
            }
            return "0";
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
