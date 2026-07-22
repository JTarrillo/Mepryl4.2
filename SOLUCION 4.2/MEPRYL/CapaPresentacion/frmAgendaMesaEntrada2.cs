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
    public partial class frmAgendaMesaEntrada2 : DevExpress.XtraEditors.XtraForm
    {
        CapaNegocioMepryl.MesaEntrada mesaEntrada;
        CapaNegocioMepryl.PacientePreventiva PacientePre;
        string _pathFotoLab = null;
        string _pathFotoPre = null;

        bool primeraVez;
        int puntero = -1;
        int intFilaSelecc = 0;
        int intColSelecc = 4;
        int intPosScroll = 0;

        public frmAgendaMesaEntrada2()
        {
            InitializeComponent();
            mesaEntrada = new MesaEntrada();
            inicializar();                                
        }

        public frmAgendaMesaEntrada2(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;            
            mesaEntrada = new MesaEntrada();
            inicializar();
            //ActualizaTimer();
        }

        private void inicializar()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            System.Diagnostics.Debug.WriteLine("[AGENDA] --- inicializar() start ---");

            CargarDatos();
            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"[AGENDA] CargarDatos(): {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            PintarFilaGrilla();
            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"[AGENDA] PintarFilaGrilla(): {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            mostrarDatos();
            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"[AGENDA] mostrarDatos(): {sw.ElapsedMilliseconds} ms");

            System.Diagnostics.Debug.WriteLine("[AGENDA] --- inicializar() end ---");
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

        private DataTable CargarEmpresaClub01(string strNroExamen, string strLiga, string strClub)
        {
            int n;
            bool isNumeric = int.TryParse(strNroExamen, out n);

            DataTable retorno = new DataTable();
            if (isNumeric)
            {
                
                retorno.Columns.Add("Liga");
                retorno.Columns.Add("Club");
            }else
            {                
                retorno.Columns.Add("Empresa");
                retorno.Columns.Add("Tarea");
            }

            retorno.Rows.Add(strLiga, strClub);

            return retorno;
        }

        private void CargarDatos()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            DataTable dt = mesaEntrada.cargarMesaEntradaPlanillaCompleta();
            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"[AGENDA]   SQL cargarMesaEntradaPlanillaCompleta: {sw.ElapsedMilliseconds} ms ({dt.Rows.Count} filas)");

            if (dt.Rows.Count > 0)
            {
                sw.Restart();
                dgvGrilla.DataSource = dt;
                sw.Stop();
                System.Diagnostics.Debug.WriteLine($"[AGENDA]   dgvGrilla.DataSource asignado: {sw.ElapsedMilliseconds} ms");

                if (dgvGrilla.Rows.Count > 0)
                {
                    sw.Restart();
                    cargarGrilla();
                    sw.Stop();
                    System.Diagnostics.Debug.WriteLine($"[AGENDA]   cargarGrilla (DatosBasicosGrilla): {sw.ElapsedMilliseconds} ms");
                }
                else
                {
                    dgvGrilla.DataSource = null;
                }
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
                        //PacientePre = new PacientePreventiva();

                        lblNroExamenDato.Visible = true;
                        lblNroOrdenDato.Visible = true;

                        //Entidades.MesaEntrada entidad = mesaEntrada.cargarInformacionConsulta(
                        //    new Guid(dgvGrilla.Rows[intFilaSelecc].Cells[0].Value.ToString()));

                        txtDni.Text = dgvGrilla.Rows[intFilaSelecc].Cells[10].Value.ToString();
                        txtApellido.Text = dgvGrilla.Rows[intFilaSelecc].Cells[11].Value.ToString();
                        txtNombre.Text = dgvGrilla.Rows[intFilaSelecc].Cells[12].Value.ToString();
                        txtFechaNacimiento.Text = dgvGrilla.Rows[intFilaSelecc].Cells[16].Value.ToString();
                        txtEdad.Text = CalcularEdad(txtFechaNacimiento.Text) + " Años";
                                               
                        //CargarGrillaEmpresaClub();
                        lblNroOrdenDato.Text = dgvGrilla.Rows[intFilaSelecc].Cells[6].Value.ToString();
                        lblNroExamenDato.Text = dgvGrilla.Rows[intFilaSelecc].Cells[9].Value.ToString();
                        dgvInformacionPaciente.DataSource = CargarEmpresaClub01(lblNroExamenDato.Text, dgvGrilla.Rows[intFilaSelecc].Cells[22].Value.ToString(), dgvGrilla.Rows[intFilaSelecc].Cells[23].Value.ToString());
                        
                        tbClinico.Text = dgvGrilla.Rows[intFilaSelecc].Cells[18].Value.ToString();
                        tbLaboratorio.Text = dgvGrilla.Rows[intFilaSelecc].Cells[19].Value.ToString();
                        tbRx.Text = dgvGrilla.Rows[intFilaSelecc].Cells[20].Value.ToString();
                        tbEstudiosComplementarios.Text = dgvGrilla.Rows[intFilaSelecc].Cells[21].Value.ToString();
                        tbTipoExamen.Text = dgvGrilla.Rows[intFilaSelecc].Cells[8].Value.ToString();

                        chkRevisado.Checked = Convert.ToBoolean(dgvGrilla.Rows[intFilaSelecc].Cells[17].Value.ToString());

                        try
                        {
                            if (chkRevisado.Checked == true)
                            {
                                chkRevisado.Image = Image.FromFile("P:\\img-system\\mCheck01_45x45.png");
                            }
                            else
                            {
                                chkRevisado.Image = Image.FromFile("P:\\img-system\\mCheck02_45x45.png");
                            }
                        }catch(System.IO.FileNotFoundException ex)
                        {
                            chkRevisado.Image = null;
                        }

                        //if (Convert.ToBoolean(dgvGrilla.Rows[intFilaSelecc].Cells[24].Value.ToString()))
                        //{
                        //    tbTipoExamen.Text = tbTipoExamen.Text + " (*)";
                        //}

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
            timerActualiza.Interval = 50000;
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
                dgvGrilla.Columns[18].Visible = false;
                dgvGrilla.Columns[19].Visible = false;
                dgvGrilla.Columns[20].Visible = false;
                dgvGrilla.Columns[21].Visible = false;
                dgvGrilla.Columns[22].Visible = false;
                dgvGrilla.Columns[23].Visible = false;
                dgvGrilla.Columns[24].Visible = false;
                dgvGrilla.Columns[25].Visible = true;
                dgvGrilla.Columns[26].Visible = true;
                dgvGrilla.Columns[27].Visible = true;
                dgvGrilla.Columns[28].Visible = true;

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
                dgvGrilla.Columns[25].Width = 50;
                dgvGrilla.Columns[25].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[26].Width = 50;
                dgvGrilla.Columns[26].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[27].Width = 50;
                dgvGrilla.Columns[27].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrilla.Columns[28].Width = 50;
                dgvGrilla.Columns[28].SortMode = DataGridViewColumnSortMode.NotSortable;

                dgvGrilla.Columns[6].HeaderText = "Orden";
                dgvGrilla.Columns[8].HeaderText = "Subtipo de Examen";
                dgvGrilla.Columns[9].HeaderText = "Nº Examen";
                dgvGrilla.Columns[10].HeaderText = "DNI";
                dgvGrilla.Columns[13].HeaderText = "Obs. Turnos";
                dgvGrilla.Columns[14].HeaderText = "Obs. Mesa Entrada";
                dgvGrilla.Columns[16].HeaderText = "Fecha Nacimiento";
                dgvGrilla.Columns[25].HeaderText = "Labo";
                dgvGrilla.Columns[26].HeaderText = "Rayos";
                dgvGrilla.Columns[27].HeaderText = "Electro";
                dgvGrilla.Columns[28].HeaderText = "Salida";

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
            if (dgvGrilla.Rows.Count > 0)
            {
                for (int i = 0; i < dgvGrilla.Rows.Count; i++)
                {
                    try
                    {
                        // Cells[17] = Revisado, ya viene en la consulta principal — sin llamada extra a la BD
                        var val = dgvGrilla.Rows[i].Cells[17].Value;
                        if (val != null && val != DBNull.Value && Convert.ToBoolean(val))
                        {
                            dgvGrilla.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                    }
                    catch (System.NullReferenceException)
                    {
                        // fila sin datos, ignorar
                    }
                }
            }
        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            intFilaSelecc = dgvGrilla.CurrentCell.RowIndex;
            intColSelecc = dgvGrilla.CurrentCell.ColumnIndex;

            System.Diagnostics.Debug.WriteLine($"[CHECKBOX] CellContentClick - ColumnIndex: {e.ColumnIndex}, RowIndex: {e.RowIndex}");

            // Manejar los nuevos checkboxes (columnas 25-28)
            if (e.ColumnIndex >= 25 && e.ColumnIndex <= 28 && e.RowIndex >= 0)
            {
                System.Diagnostics.Debug.WriteLine($"[CHECKBOX] Detectado checkbox en columna {e.ColumnIndex}");

                var valor = dgvGrilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                System.Diagnostics.Debug.WriteLine($"[CHECKBOX] Valor antes de cambio: {valor} (Tipo: {valor?.GetType().Name})");

                bool estadoActual = valor != DBNull.Value && valor != null ? Convert.ToBoolean(valor) : false;
                bool nuevoEstado = !estadoActual; // Invertir el valor

                dgvGrilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = nuevoEstado;
                dgvGrilla.CommitEdit(DataGridViewDataErrorContexts.Commit);

                string idConsulta = dgvGrilla.Rows[e.RowIndex].Cells[0].Value.ToString();
                string idTipoExamen = dgvGrilla.Rows[e.RowIndex].Cells[2].Value.ToString();

                System.Diagnostics.Debug.WriteLine($"[CHECKBOX] Estado cambiado de {estadoActual} a {nuevoEstado} - IdConsulta: {idConsulta}, IdTipoExamen: {idTipoExamen}");

                // Guardar el estado en base de datos
                mesaEntrada.guardarEstadoCheckbox(idTipoExamen, e.ColumnIndex, nuevoEstado);
            }

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
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                CargarDatos();
            }
            catch(System.InvalidOperationException ex)
            {
                CargarDatos();
            }

        }

        private void CargarDirectoriosFotos()
        {
            if (_pathFotoLab != null) return; // ya cargado
            try
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                CapaNegocioMepryl.UbicacionFotos UbiFoto = new UbicacionFotos();
                DataTable dt = UbiFoto.RecuperarDirectorioFotos();
                sw.Stop();
                System.Diagnostics.Debug.WriteLine($"[AGENDA]   RecuperarDirectorioFotos (SQL): {sw.ElapsedMilliseconds} ms");
                _pathFotoPre = dt.Rows[0][0].ToString();
                _pathFotoLab = dt.Rows[0][1].ToString();
            }
            catch { _pathFotoPre = ""; _pathFotoLab = ""; }
        }

        private void MostrarFoto(string strDNI)
        {
            CargarDirectoriosFotos();
            string strPathFotoPre = _pathFotoPre;
            string strPathFotoLab = _pathFotoLab;
                         
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
