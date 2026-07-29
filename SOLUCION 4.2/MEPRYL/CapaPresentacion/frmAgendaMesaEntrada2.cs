using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            
            // Habilitar DoubleBuffered para evitar parpadeo visual
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null,
                dgvGrilla,
                new object[] { true });
            
            inicializar();                                
        }

        public frmAgendaMesaEntrada2(frmBasePrincipal parentForm)
        {
            InitializeComponent();
            this.MdiParent = parentForm;            
            mesaEntrada = new MesaEntrada();
            
            // Habilitar DoubleBuffered para evitar parpadeo visual
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null,
                dgvGrilla,
                new object[] { true });
            
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
            mostrarDatos();
            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"[AGENDA] mostrarDatos(): {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            dgvGrilla.Refresh(); // Asegurar que el DataGridView esté completamente cargado
            PintarFilaGrilla();
            dgvGrilla.Refresh(); // Forzar repintado visual después de colorear
            sw.Stop();
            System.Diagnostics.Debug.WriteLine($"[AGENDA] PintarFilaGrilla(): {sw.ElapsedMilliseconds} ms");

            // Ajustar orden de columnas visualmente
            if (dgvGrilla.Columns.Count > 31)
            {
                // FechaNaci antes de ObservacTurno
                dgvGrilla.Columns[16].DisplayIndex = 13; // FechaNaci antes de ObservacTurno
                
                // ObservacTurno y ObservacMesaEntrada en orden correcto
                dgvGrilla.Columns[13].DisplayIndex = 14; // ObservacTurno
                dgvGrilla.Columns[14].DisplayIndex = 15; // ObservacMesaEntrada después de ObservacTurno
                
                // Nat y Continua después de ObservacMesaEntrada
                dgvGrilla.Columns[29].DisplayIndex = 16; // Nat después de ObservacMesaEntrada
                dgvGrilla.Columns[29].Width = 40; // Ancho de columna Nat
                dgvGrilla.Columns[29].HeaderText = "NAT"; // Nombre de columna Nat
                dgvGrilla.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar Nat
                dgvGrilla.Columns[30].DisplayIndex = 17; // Continua después de Nat
                dgvGrilla.Columns[30].Width = 50; // Ancho de columna Continua
                dgvGrilla.Columns[30].HeaderText = "CONT."; // Nombre de columna Continua
                
                // RM después de Continua
                dgvGrilla.Columns[15].DisplayIndex = 18; // RM después de Continua
                
                // HoraSalida al final
                dgvGrilla.Columns[31].DisplayIndex = 31; // HoraSalida al final
                dgvGrilla.Columns[31].Width = 70; // Ancho de columna HoraSalida
                dgvGrilla.Columns[31].HeaderText = "Hora"; // Nombre de columna HoraSalida
                dgvGrilla.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar encabezado
                dgvGrilla.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar contenido
                dgvGrilla.Columns[31].ReadOnly = true; // HoraSalida read-only para evitar acciones al hacer click
                
                // Color de selección RGB(0, 120, 212) - #0078D4 (azul Windows)
                dgvGrilla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 212);
                dgvGrilla.DefaultCellStyle.SelectionForeColor = Color.White;
            }

            System.Diagnostics.Debug.WriteLine("[AGENDA] --- inicializar() end ---");
        }

        private void dgvGrilla_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvGrilla.CurrentCell != null)
            {
                // No llamar mostrarDatos() cuando la celda actual es HoraSalida (columna 31) para evitar despintado
                if (dgvGrilla.CurrentCell.ColumnIndex != 31)
                {
                    mostrarDatos();
                    MostrarFoto(txtDni.Text);
                }
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
            // No recargar datos, solo actualizar colores
            // CargarDatos(); // Comentado para evitar reseteo de la grilla

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
            System.Diagnostics.Debug.WriteLine($"[PINTAR] PintarFilaGrilla llamado - Filas: {dgvGrilla.Rows.Count}");
            
            if (dgvGrilla.Rows.Count > 0)
            {
                for (int i = 0; i < dgvGrilla.Rows.Count; i++)
                {
                    try
                    {
                        // Prioridad 0: Regla Naranja - Si Nat y Continua están ambos ON
                        var natVal = dgvGrilla.Rows[i].Cells[29].Value;
                        var continuaVal = dgvGrilla.Rows[i].Cells[30].Value;
                        bool natOn = natVal != null && natVal != DBNull.Value && Convert.ToBoolean(natVal);
                        bool continuaOn = continuaVal != null && continuaVal != DBNull.Value && Convert.ToBoolean(continuaVal);

                        if (natOn && continuaOn)
                        {
                            // Naranja (combinación de amarillo y rojo según teoría del color)
                            dgvGrilla.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
                            System.Diagnostics.Debug.WriteLine($"[PINTAR] Fila {i} - Pintando NARANJA (Nat ON y Continua ON)");
                        }
                        else if (continuaOn)
                        {
                            // Prioridad 1: Regla Amarilla - Si Continua está ON (tiene prioridad sobre Nat)
                            // Amarillo más oscuro pero limpio
                            dgvGrilla.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 50);
                            System.Diagnostics.Debug.WriteLine($"[PINTAR] Fila {i} - Pintando AMARILLO (Continua ON)");
                        }
                        else if (natOn)
                        {
                            // Prioridad 2: Regla Roja - Si Nat está ON y Continua está OFF
                            // Rojo más oscuro pero limpio
                            dgvGrilla.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(220, 50, 50);
                            System.Diagnostics.Debug.WriteLine($"[PINTAR] Fila {i} - Pintando ROJO (Nat ON)");
                        }
                            else
                            {
                                // Prioridad 3: Regla Verde Oscuro - Si Salida está ON
                                var salidaVal = dgvGrilla.Rows[i].Cells[28].Value;
                                bool salidaOn = salidaVal != null && salidaVal != DBNull.Value && Convert.ToBoolean(salidaVal);

                                if (salidaOn)
                                {
                                    // Verde esmeralda para indicar salida
                                    dgvGrilla.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(46, 204, 113);
                                    System.Diagnostics.Debug.WriteLine($"[PINTAR] Fila {i} - Pintando VERDE OSCURO (Salida ON)");
                                }
                                else
                                {
                                    // Estado por defecto - Alternancia blanco y verde claro
                                    var val = dgvGrilla.Rows[i].Cells[17].Value;
                                    System.Diagnostics.Debug.WriteLine($"[PINTAR] Fila {i} - Columna 17: {val} (Tipo: {val?.GetType().Name})");
                                    
                                    bool esVerde = false;
                                    if (val != null && val != DBNull.Value)
                                    {
                                        if (val is bool boolVal)
                                        {
                                            esVerde = boolVal;
                                        }
                                        else if (val is string strVal)
                                        {
                                            esVerde = strVal.Equals("True", StringComparison.OrdinalIgnoreCase);
                                        }
                                    }
                                    
                                    if (esVerde)
                                    {
                                        dgvGrilla.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                                        System.Diagnostics.Debug.WriteLine($"[PINTAR] Fila {i} - Pintando VERDE");
                                    }
                                    else
                                    {
                                        // Color por defecto (blanco)
                                        dgvGrilla.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                        System.Diagnostics.Debug.WriteLine($"[PINTAR] Fila {i} - Pintando BLANCO");
                                    }
                                }
                            }
                        
                    }
                    catch (NullReferenceException)
                    {
                        // fila sin datos, ignorar
                    }
                }
            }
        }

        private void PintarFilaEspecifica(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvGrilla.Rows.Count) return;
            
            try
            {
                dgvGrilla.SuspendLayout();
                
                // Prioridad 0: Regla Naranja - Si Nat y Continua están ambos ON
                var natVal = dgvGrilla.Rows[rowIndex].Cells[29].Value;
                var continuaVal = dgvGrilla.Rows[rowIndex].Cells[30].Value;
                bool natOn = natVal != null && natVal != DBNull.Value && Convert.ToBoolean(natVal);
                bool continuaOn = continuaVal != null && continuaVal != DBNull.Value && Convert.ToBoolean(continuaVal);

                if (natOn && continuaOn)
                {
                    // Naranja (combinación de amarillo y rojo según teoría del color)
                    dgvGrilla.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
                }
                else if (continuaOn)
                {
                    // Prioridad 1: Regla Amarilla - Si Continua está ON (tiene prioridad sobre Nat)
                    dgvGrilla.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 50);
                }
                else if (natOn)
                {
                    // Prioridad 2: Regla Roja - Si Nat está ON y Continua está OFF
                    dgvGrilla.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(220, 50, 50);
                }
                else
                {
                    var salidaVal = dgvGrilla.Rows[rowIndex].Cells[28].Value;
                    bool salidaOn = salidaVal != null && salidaVal != DBNull.Value && Convert.ToBoolean(salidaVal);

                    if (salidaOn)
                    {
                        dgvGrilla.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(46, 204, 113);
                    }
                    else
                    {
                        var val = dgvGrilla.Rows[rowIndex].Cells[17].Value;
                        bool esVerde = false;
                        if (val != null && val != DBNull.Value)
                        {
                            if (val is bool boolVal)
                            {
                                esVerde = boolVal;
                            }
                            else if (val is string strVal)
                            {
                                esVerde = strVal.Equals("True", StringComparison.OrdinalIgnoreCase);
                            }
                        }
                        if (esVerde)
                        {
                            dgvGrilla.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            dgvGrilla.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
                dgvGrilla.InvalidateRow(rowIndex);
                dgvGrilla.ResumeLayout(true);
            }
            catch (NullReferenceException)
            {
                // fila sin datos, ignorar
            }
        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"[CHECKBOX] CellContentClick - ColumnIndex: {e.ColumnIndex}, RowIndex: {e.RowIndex}");

            // No hacer nada cuando se hace click en HoraSalida (columna 31) para evitar despintado
            if (e.ColumnIndex == 31)
            {
                return;
            }

            intFilaSelecc = dgvGrilla.CurrentCell.RowIndex;
            intColSelecc = dgvGrilla.CurrentCell.ColumnIndex;

            // Manejar los nuevos checkboxes (columnas 25-30)
            if (e.ColumnIndex >= 25 && e.ColumnIndex <= 30 && e.RowIndex >= 0)
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
                
                // Si es Salida (columna 28), actualizar HoraSalida en tiempo real
                if (e.ColumnIndex == 28)
                {
                    if (nuevoEstado)
                    {
                        // Marcar Salida - mostrar hora actual (solo hora)
                        dgvGrilla.Rows[e.RowIndex].Cells[31].Value = DateTime.Now.ToString("HH:mm:ss");
                    }
                    else
                    {
                        // Desmarcar Salida - limpiar hora
                        dgvGrilla.Rows[e.RowIndex].Cells[31].Value = string.Empty;
                    }
                }
                
                // Actualizar coloreo en tiempo real cuando cambia Nat o Continua
                // Solo repintar la fila específica para evitar reseteo visual de toda la grilla
                PintarFilaEspecifica(e.RowIndex);
            }
            // Actualizar coloreo cuando cambia la columna 17 (controla coloreo verde)
            else if (e.ColumnIndex == 17 && e.RowIndex >= 0)
            {
                PintarFilaGrilla();
            }

            //intPosScroll = dgvGrilla.FirstDisplayedScrollingRowIndex;
        }

        private void frmAgendaMesaEntrada_Load(object sender, EventArgs e)
        {
            dgvGrilla.Refresh(); // Asegurar que el DataGridView esté completamente cargado
            PintarFilaGrilla();
            dgvGrilla.Refresh(); // Forzar repintado visual después de colorear

            // Log para verificar HoraSalida en la grilla
            System.Diagnostics.Debug.WriteLine($"[HORA_SALIDA_GRILLA] Total columnas en grilla: {dgvGrilla.Columns.Count}");
            if (dgvGrilla.Columns.Count > 31)
            {
                System.Diagnostics.Debug.WriteLine($"[HORA_SALIDA_GRILLA] Columna 31 (HoraSalida) existe: {dgvGrilla.Columns[31].Name}");
                
                for (int i = 0; i < Math.Min(5, dgvGrilla.Rows.Count); i++)
                {
                    var horaSalidaValue = dgvGrilla.Rows[i].Cells[31].Value;
                    System.Diagnostics.Debug.WriteLine($"[HORA_SALIDA_GRILLA] Fila {i} - HoraSalida: {horaSalidaValue} (Tipo: {horaSalidaValue?.GetType().Name})");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"[HORA_SALIDA_GRILLA] ERROR: La grilla solo tiene {dgvGrilla.Columns.Count} columnas, se necesitan al menos 32");
            }

            // Ajustar orden de columnas visualmente
            if (dgvGrilla.Columns.Count > 31)
            {
                // FechaNaci antes de ObservacTurno
                dgvGrilla.Columns[16].DisplayIndex = 13; // FechaNaci antes de ObservacTurno
                
                // ObservacTurno y ObservacMesaEntrada en orden correcto
                dgvGrilla.Columns[13].DisplayIndex = 14; // ObservacTurno
                dgvGrilla.Columns[14].DisplayIndex = 15; // ObservacMesaEntrada después de ObservacTurno
                
                // Nat y Continua después de ObservacMesaEntrada
                dgvGrilla.Columns[29].DisplayIndex = 16; // Nat después de ObservacMesaEntrada
                dgvGrilla.Columns[29].Width = 40; // Ancho de columna Nat
                dgvGrilla.Columns[29].HeaderText = "NAT"; // Nombre de columna Nat
                dgvGrilla.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar Nat
                dgvGrilla.Columns[30].DisplayIndex = 17; // Continua después de Nat
                dgvGrilla.Columns[30].Width = 50; // Ancho de columna Continua
                dgvGrilla.Columns[30].HeaderText = "CONT."; // Nombre de columna Continua
                
                // RM después de Continua
                dgvGrilla.Columns[15].DisplayIndex = 18; // RM después de Continua
                
                // HoraSalida al final
                dgvGrilla.Columns[31].DisplayIndex = 31; // HoraSalida al final
                dgvGrilla.Columns[31].Width = 70; // Ancho de columna HoraSalida
                dgvGrilla.Columns[31].HeaderText = "Hora"; // Nombre de columna HoraSalida
                dgvGrilla.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar encabezado
                dgvGrilla.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar contenido
                dgvGrilla.Columns[31].ReadOnly = true; // HoraSalida read-only para evitar acciones al hacer click
                
                // Color de selección RGB(0, 120, 212) - #0078D4 (azul Windows)
                dgvGrilla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 212);
                dgvGrilla.DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        private void dgvGrilla_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Nat y Continua ahora son checkboxes normales, no se personaliza como Toggle Switch
        }

        private GraphicsPath CreateRoundedRect(float x, float y, float width, float height, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(x + radius, y, x + width - radius, y);
            path.AddArc(x + width - radius, y, radius, radius, 270, 90);
            path.AddLine(x + width, y + radius, x + width, y + height - radius);
            path.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);
            path.AddLine(x + width - radius, y + height, x + radius, y + height);
            path.AddArc(x, y + height - radius, radius, radius, 90, 90);
            path.AddLine(x, y + height - radius, x, y + radius);
            path.AddArc(x, y, radius, radius, 180, 90);
            path.CloseFigure();
            return path;
        }

        private void dgvGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            intFilaSelecc = dgvGrilla.CurrentCell.RowIndex;
            intColSelecc = dgvGrilla.CurrentCell.ColumnIndex;

            //intPosScroll = dgvGrilla.FirstDisplayedScrollingRowIndex;
            //SeleccinarFilaTurno();
            
            // No llamar mostrarDatos() cuando se hace click en HoraSalida (columna 31) para evitar despintado
            if (e.ColumnIndex != 31)
            {
                mostrarDatos();
            }
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
                dgvGrilla.Rows[intFilaSelecc].Cells[17].Value = chkRevisado.Checked;
                dgvGrilla.Rows[intFilaSelecc].DefaultCellStyle.BackColor = Color.LightGreen;
                chkRevisado.Image = Image.FromFile("P:\\img-system\\mCheck01_45x45.png");
            }
            else
            {
                mesaEntrada.RevisarPaciente(dgvGrilla.Rows[intFilaSelecc].Cells[0].Value.ToString(), chkRevisado.Checked);
                dgvGrilla.Rows[intFilaSelecc].Cells[17].Value = chkRevisado.Checked;
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
