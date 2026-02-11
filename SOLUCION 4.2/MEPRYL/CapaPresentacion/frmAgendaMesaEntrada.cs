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
using Comunes;
using CapaPresentacionBase;
using System.IO;


namespace CapaPresentacion
{
    public partial class frmAgendaMesaEntrada : DevExpress.XtraEditors.XtraForm
    {
        CapaNegocioMepryl.MesaEntrada mesaEntrada;
        CapaNegocioMepryl.PacientePreventiva PacientePre;
        
        bool primeraVez;
        int puntero = -1;
        int intFilaSelecc = 0;
        int intColSelecc = 4;
        int intPosScroll = 0;

        public frmAgendaMesaEntrada()
        {
            InitializeComponent();
            mesaEntrada = new MesaEntrada();
            inicializar();                                
        }

        public frmAgendaMesaEntrada(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;            
            mesaEntrada = new MesaEntrada();
            inicializar();
            //ActualizaTimer();
        }

        private void inicializar()
        {
            CargarDatos();
            PintarFilaGrilla();
            mostrarDatos();            

            //timerActualiza.Interval = 10000;
            //timerActualiza.Tick += new EventHandler(timerActualiza_Tick);
            //timerActualiza.Enabled = true;
        }

        private void dgvGrilla_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvGrilla.CurrentCell != null)
            {                
                mostrarDatos();                
                MostrarFoto(txtDni.Text);
            }
        }
        
        public void cargarGrilla()
        {
            primeraVez = true;

            DatosBasicosGrilla();
            //try
            //{
            //    if (dgvGrilla.Rows.Count > 0 && puntero != -1 && (puntero <= dgvGrilla.Rows.Count - 1))
            //    {
            //        dgvGrilla.CurrentCell = dgvGrilla.Rows[puntero].Cells[4];
            //    }
            //    if (dgvGrilla.Rows.Count > 0 && puntero == -1)
            //    {
            //        dgvGrilla.CurrentCell = dgvGrilla.Rows[0].Cells[4];
            //    }
            //}catch(System.InvalidOperationException ex)
            //{
            //    //
            //}
            
            this.ActiveControl = dgvGrilla;
            
        }

        public void CargarGrillaEmpresaClub()
        {
            dgvInformacionPaciente.Columns[2].Visible = false;
        }

        private void CargarDatos()
        {
            dgvGrilla.DataSource = mesaEntrada.cargarMesaEntradaPlanilla();

            if (dgvGrilla.Rows.Count > 0)
            {
                //dgvGrilla.CurrentCell = dgvGrilla.Rows[intFilaSelecc].Cells[intColSelecc];

                //if (dgvGrilla.InvokeRequired)
                //{
                //    MethodInvoker mi = new MethodInvoker(() => dgvGrilla.FirstDisplayedScrollingRowIndex = intPosScroll);
                //    dgvGrilla.Invoke(mi);
                //}

                //dgvGrilla.FirstDisplayedScrollingRowIndex = intPosScroll;
                cargarGrilla();
                //PintarFilaGrilla();
            }
            else
            {
                dgvGrilla.DataSource = null;
            }
        }

        public void mostrarDatos()
        {
            try
            {
                if (dgvGrilla.Rows.Count > 0)
                {
                    if (dgvGrilla.Rows[intFilaSelecc].Cells[0].Value != null)
                    {
                        PacientePre = new PacientePreventiva();

                        lblNroExamenDato.Visible = true;
                        lblNroOrdenDato.Visible = true;

                        Entidades.MesaEntrada entidad = mesaEntrada.cargarInformacionConsulta(
                            new Guid(dgvGrilla.Rows[intFilaSelecc].Cells[0].Value.ToString()));

                        txtDni.Text = entidad.Dni;
                        txtApellido.Text = entidad.Apellido;
                        txtNombre.Text = entidad.Nombre;
                        txtFechaNacimiento.Text = entidad.Nacimiento;
                        txtEdad.Text = CalcularEdad(txtFechaNacimiento.Text) + " Años";
                        dgvInformacionPaciente.DataSource = entidad.ClubesOEmpresa;
                        CargarGrillaEmpresaClub();
                        lblNroOrdenDato.Text = entidad.NroOrden;
                        lblNroExamenDato.Text = entidad.NroExamen;

                        tbClinico.Text = entidad.TipoExamen.TextoClinico;
                        tbLaboratorio.Text = entidad.TipoExamen.TextoLaboratorio;
                        tbRx.Text = entidad.TipoExamen.TextoRx;
                        tbEstudiosComplementarios.Text = entidad.TipoExamen.TextoEstComplement;
                        tbTipoExamen.Text = entidad.TipoExamen.Descripcion;

                        chkRevisado.Checked = mesaEntrada.Revisado(dgvGrilla.Rows[intFilaSelecc].Cells[0].Value.ToString());
                        if (chkRevisado.Checked == true)
                        {
                            chkRevisado.Image = Image.FromFile("P:\\img-system\\mCheck01_45x45.png");
                        }
                        else
                        {
                            chkRevisado.Image = Image.FromFile("P:\\img-system\\mCheck02_45x45.png");
                        }

                        if (entidad.TipoExamen.Modificado)
                        {
                            tbTipoExamen.Text = tbTipoExamen.Text + " (*)";
                        }

                        MostrarFoto(txtDni.Text);

                        if (!primeraVez)
                        {
                            puntero = intFilaSelecc;
                            //SeleccinarFilaTurno();                            
                        }
                        else
                        {
                            primeraVez = false;
                        }
                    }
                }
            }catch (System.NullReferenceException ex)
            {
                //
            }
        
        }
        
        private void colorearFila(DataGridViewRow row)
        {
            Color color = Color.White;
            switch (row.Cells[17].Value.ToString())
            {
                case "P":
                    color = Color.MistyRose;
                    break;
                case "L":
                    color = Color.Moccasin;
                    break;
                case "EC":
                    color = Color.Azure;
                    break;
                case "CO":
                    color = Color.LightSteelBlue;
                    break;
                case "True":
                    color = Color.LightGreen;
                    break;
            }
            row.DefaultCellStyle.BackColor = color;
            //dgvGrilla.Rows[intFilaSelecc].DefaultCellStyle.BackColor = color;
        }

        private string CalcularEdad(string strFecha)
        {
            string strResultado = "";

            try
            {
                DateTime dtNacimiento = Convert.ToDateTime(strFecha);
                DateTime dtHoy = DateTime.Today;

                if ((DateTime.Compare(dtNacimiento, dtHoy)) < 0)
                    strResultado = (DateTime.Today.AddTicks(-dtNacimiento.Ticks).Year - 1).ToString();
                else
                {
                    MessageBox.Show("Fecha de nacimiento no puede ser mayor a la fecha de hoy", "Laboral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                }

            }
            catch (System.FormatException ex)
            {
                strResultado = "0";
            }

            return strResultado;
        }

        private void timerActualiza_Tick(object sender, EventArgs e)
        {
            CargarDatos();

            //if (dgvGrilla.Rows.Count > 0)
            //{
            //    dgvGrilla.Rows[intFilaSelecc].Selected = true;
            //    dgvGrilla.CurrentCell = dgvGrilla.Rows[intFilaSelecc].Cells[4];                
            //}
            PintarFilaGrilla();
            SeleccinarFilaTurno();
            timerActualiza.Interval = 45000;
            if(dgvGrilla.Rows.Count > 0)
                dgvGrilla.FirstDisplayedScrollingRowIndex = intPosScroll;
        }

        //void ActualizaTimer()
        //{
        //    Task.Run(async () =>
        //    {
        //        while (true)
        //        {
        //            CargarDatos();
        //            SeleccinarFilaTurno();                    
        //            await Task.Delay(15000);
        //        }
        //    });
        //}

        void ActualizaTimer()
        {
            
            while (true)
            {
                CargarDatos();
                SeleccinarFilaTurno();
                System.Threading.Thread.Sleep(5000);
            }
            
        }

        

        private void RefrescaRegistro()
        {
            DatosBasicosGrilla();
        }

        private void DatosBasicosGrilla()
        {
            if (dgvGrilla.Rows.Count > 0)
            {

                dgvGrilla.Columns[0].Visible = false;                
                dgvGrilla.Columns[1].Visible = false;
                dgvGrilla.Columns[2].Visible = false;
                dgvGrilla.Columns[3].Visible = false;
                dgvGrilla.Columns[7].Visible = false;
                dgvGrilla.Columns[15].Visible = false;
                dgvGrilla.Columns[5].Visible = false;
                dgvGrilla.Columns[16].Visible = true;
                dgvGrilla.Columns[17].Visible = false;

                dgvGrilla.Columns[16].DisplayIndex = 13;

                dgvGrilla.Columns[4].Width = 80;
                dgvGrilla.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[5].Width = 50;
                dgvGrilla.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[6].Width = 60;
                dgvGrilla.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[8].Width = 170;
                dgvGrilla.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[9].Width = 90;
                dgvGrilla.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[10].Width = 80;
                dgvGrilla.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[11].Width = 160;
                dgvGrilla.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[12].Width = 160;
                dgvGrilla.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[13].Width = 130;
                dgvGrilla.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[14].Width = 130;
                dgvGrilla.Columns[14].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[15].Width = 30;
                dgvGrilla.Columns[15].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[16].Width = 88;
                dgvGrilla.Columns[16].SortMode = DataGridViewColumnSortMode.NotSortable;

                dgvGrilla.Columns[6].HeaderText = "Orden";
                dgvGrilla.Columns[8].HeaderText = "Tipo de Examen";
                dgvGrilla.Columns[9].HeaderText = "Nº Examen";
                dgvGrilla.Columns[10].HeaderText = "DNI";
                dgvGrilla.Columns[13].HeaderText = "Obs. Turnos";
                dgvGrilla.Columns[14].HeaderText = "Obs. Mesa Entrada";
                dgvGrilla.Columns[16].HeaderText = "Fecha Nacimiento";

                if (dgvGrilla.Rows.Count > 0)
                {
                    lblTotal.Text = "Total Pacientes: " + dgvGrilla.Rows.Count.ToString();
                }

                //foreach (DataGridViewRow dgvR in dgvGrilla.Rows)
                //{
                //    colorearFila(dgvR);
                //}
                
            }
        }

        private void PintarFilaGrilla()
        {

            //if (dgvGrilla.InvokeRequired)
            //{
                if (dgvGrilla.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvGrilla.Rows.Count; i++)
                    {
                        try
                        {
                            if (mesaEntrada.Revisado(dgvGrilla.Rows[i].Cells[0].Value.ToString()) == true)
                            {
                                //MethodInvoker mi = new MethodInvoker(() => dgvGrilla.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen);
                                //dgvGrilla.Invoke(mi);
                                dgvGrilla.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                            }
                        }catch(System.NullReferenceException ex)
                        {
                            dgvGrilla.DataSource = null;
                        }
                    }
                }
            //}
        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            intFilaSelecc = dgvGrilla.CurrentCell.RowIndex;
            intColSelecc = dgvGrilla.CurrentCell.ColumnIndex;

            //intPosScroll = dgvGrilla.FirstDisplayedScrollingRowIndex;
        }

        private void frmAgendaMesaEntrada_Load(object sender, EventArgs e)
        {
            PintarFilaGrilla();
        }

        private void dgvGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            intFilaSelecc = dgvGrilla.CurrentCell.RowIndex;
            intColSelecc = dgvGrilla.CurrentCell.ColumnIndex;

            //intPosScroll = dgvGrilla.FirstDisplayedScrollingRowIndex;
            //SeleccinarFilaTurno();
            mostrarDatos();
        }

        private void SeleccinarFilaTurno()
        {
            try
            {
                if (dgvGrilla.Rows.Count > 0)
                {
                    if (intFilaSelecc >= 0)
                    {
                        //dgvGrilla.Rows[intFilaSelecc].Selected = true;
                        
                        dgvGrilla.CurrentCell = dgvGrilla.Rows[intFilaSelecc].Cells[intColSelecc];

                        dgvGrilla.FirstDisplayedScrollingRowIndex = intPosScroll;

                    }
                }
            }catch(System.ArgumentOutOfRangeException ex)
            {
                CargarDatos();
            }
        }

        private void MostrarFoto(string strDNI)
        {
            CapaNegocioMepryl.UbicacionFotos UbiFoto = new UbicacionFotos();

            string strPathFotoPre = UbiFoto.RecuperarDirectorioFotos().Rows[0][0].ToString();
            string strPathFotoLab = UbiFoto.RecuperarDirectorioFotos().Rows[0][1].ToString();

            if (!string.IsNullOrEmpty(strPathFotoLab))
            {
                strPathFotoLab = strPathFotoLab + "\\" + strDNI + ".jpg";

                if (File.Exists(strPathFotoLab))
                {
                    cargarImagen(strPathFotoLab);
                    return;
                }
                else
                {
                    cargarImagen("P:\\img-system\\mUsuario300x300.jpg");
                    return;
                }                
            }
            else
            {
                //ptbFoto.Image = null;
                cargarImagen("P:\\img-system\\mUsuario300x300.jpg");
            }

            if (!string.IsNullOrEmpty(strPathFotoPre))
            {
                strPathFotoPre = strPathFotoPre + "\\" + strDNI + ".jpg";

                if (File.Exists(strPathFotoPre))
                {
                    cargarImagen(strPathFotoPre);
                    return;
                }
                else
                {
                    cargarImagen("P:\\img-system\\mUsuario300x300.jpg");
                    return;
                }
            }
            else
            {
                cargarImagen("P:\\img-system\\mUsuario300x300.jpg");
            }
        }

        private void cargarImagen(string strPath)
        {
            try
            {
                //GRV - Ramírez - Modificado
                //FileStream fs = new System.IO.FileStream(@"S:/FOTOS/" + tbDNI.Text + ".jpg", FileMode.Open, FileAccess.Read);
                System.IO.FileStream fs = new System.IO.FileStream(strPath, FileMode.Open, FileAccess.Read);
                ptbFoto.Image = Image.FromStream(fs);
                ptbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                ptbFoto.Image = Image.FromStream(fs);
                ptbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                fs.Close();
            }
            catch
            {
                ptbFoto.Image = null;
            }
        }        
        
        private void dgvGrilla_KeyDown(object sender, KeyEventArgs e)
        {
            intColSelecc = dgvGrilla.CurrentCell.ColumnIndex;
            intPosScroll = dgvGrilla.FirstDisplayedScrollingRowIndex;

            if (e.KeyData == Keys.Down)
            {
                if ((intFilaSelecc + 1) >= dgvGrilla.Rows.Count)
                {
                    intFilaSelecc = dgvGrilla.Rows.Count - 1;                    
                    //SeleccinarFilaTurno();
                }
                else
                {
                    intFilaSelecc = dgvGrilla.CurrentCell.RowIndex + 1;                    
                    //SeleccinarFilaTurno();
                }
            }else if (e.KeyData == Keys.Up)
            {
                if (dgvGrilla.CurrentCell.RowIndex <= 0)
                {
                    intFilaSelecc = 0;                    
                    //SeleccinarFilaTurno();
                }
                else
                {
                    intFilaSelecc = dgvGrilla.CurrentCell.RowIndex - 1;                    
                    //SeleccinarFilaTurno();
                }
            }           

            mostrarDatos();
        }

        //private void chkRevisado_CheckedChanged(object sender, EventArgs e)
        //{            
        //    mesaEntrada.RevisarPaciente(dgvGrilla.Rows[intFilaSelecc].Cells[0].Value.ToString(), chkRevisado.Checked);
            
        //    dgvGrilla.Rows[intFilaSelecc].DefaultCellStyle.BackColor = Color.LightGreen;
            
        //}

        private void chkRevisado_Click(object sender, EventArgs e)
        {
            if (chkRevisado.Checked == true)
            {
                mesaEntrada.RevisarPaciente(dgvGrilla.Rows[intFilaSelecc].Cells[0].Value.ToString(), chkRevisado.Checked);
                dgvGrilla.Rows[intFilaSelecc].DefaultCellStyle.BackColor = Color.LightGreen;
                chkRevisado.Image = Image.FromFile("P:\\img-system\\mCheck01_45x45.png");
            }
            else
            {
                mesaEntrada.RevisarPaciente(dgvGrilla.Rows[intFilaSelecc].Cells[0].Value.ToString(), chkRevisado.Checked);
                chkRevisado.Image = Image.FromFile("P:\\img-system\\mCheck02_45x45.png");
                dgvGrilla.Rows[intFilaSelecc].DefaultCellStyle.BackColor = Color.White;
            }            
        }

        private void chkRevisado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvGrilla_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    ContextMenu m = new ContextMenu();                
            //    m.MenuItems.Add(new MenuItem("Copiar"));
            //    m.MenuItems.Add(new MenuItem("Pegar"));

            //    int currentMouseOverRow = dgvGrilla.HitTest(e.X, e.Y).RowIndex;
                
            //    m.Show(dgvGrilla, new Point(e.X, e.Y));

            //}
        }

        private void dgvGrilla_Scroll(object sender, ScrollEventArgs e)
        {
            //if (dgvGrilla.InvokeRequired)
            //{
            //    MethodInvoker mi = new MethodInvoker(() => intPosScroll = dgvGrilla.FirstDisplayedScrollingRowIndex);
            //    dgvGrilla.Invoke(mi);
            //    return;
            //}

            intPosScroll = dgvGrilla.FirstDisplayedScrollingRowIndex;
        }
    }
}
