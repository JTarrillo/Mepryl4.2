using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmValidacionesExamen : DevExpress.XtraEditors.XtraForm
    {
        private string modo = "";
        private bool tipoDeCarga;
        private bool tipoDeNumeracion;
        public frmValidacionesExamen()
        {
            InitializeComponent();
        }

        private void botonClasificaciones_Click(object sender, EventArgs e)
        {
            cambiarVisibilidad(true, false, false, false);
            cargarClasificaciones();
        }

        private void cambiarVisibilidad(bool gbClasif, bool editClasif, bool gbCamp, bool editCamp)
        {
            gbClasificaciones.Visible = gbClasif;
            gbValidacion.Visible = gbCamp;
            gbAgregarEditarValidacion.Visible = editClasif;
            gbAgregarEditarClasif.Visible = editCamp;
        }

        private void cargarClasificaciones()
        {
            pictureBox.Image = null;
            DataTable clasif = SQLConnector.obtenerTablaSegunConsultaString(@"Select c.codigo as Código, c.
            descripcion as Descripcion from dbo.Clasificaciones c order by c.codigo");
            dgvClasif.DataSource = clasif;     
        }

        private void frmValidacionesExamen_Load(object sender, EventArgs e)
        {
            limpiarPantalla();
        }

        private void limpiarPantalla()
        {
            gbAgregarEditarValidacion.Visible = false;
            gbAgregarEditarClasif.Visible = false;
            gbValidacion.Visible = false;
            gbClasificaciones.Visible = false;
        }

        private void botAgregarClasif_Click(object sender, EventArgs e)
        {
            tbCodigoClasif.Clear();
            tbDescripcionClasif.Clear();
            tbIdClasif.Clear();
            pictureBoxAgregarEditar.Image = null;
            gbClasificaciones.Enabled = false;
            gbAgregarEditarClasif.Visible = true;
            cargarNumeroClasificaciones(dgvClasif, tbCodigoClasif);
            tbDescripcionClasif.Focus();
            modo = "AGREGA";
        }
        private void botModifClasif_Click(object sender, EventArgs e)
        {
            gbClasificaciones.Enabled = false;
            gbAgregarEditarClasif.Visible = true;
            modo = "EDITA";
        }
        private void botCancelarClasif_Click(object sender, EventArgs e)
        {
            gbClasificaciones.Enabled = true;
            gbAgregarEditarClasif.Visible = false;
        }

        private void cargarNumeroClasificaciones(DataGridView dgv, TextBox tb)
        {
            if (dgv.Rows.Count > 0)
            {
                int numero = Convert.ToInt16(dgv.Rows[dgv.Rows.Count - 1].Cells[0].Value.ToString());
                tb.Text = (numero + 1).ToString();
            }
            else
            {
                tb.Text = "1";
            }
        }
        private void cargarNumeroValidaciones(DataGridView dgv, TextBox tb)
        {
            if (dgv.Rows.Count > 0)
            {
                if (!tipoDeNumeracion)
                {
                    int numero = Convert.ToInt16(dgv.Rows[dgv.Rows.Count - 1].Cells[1].Value.ToString());
                    tb.Text = (numero + 1).ToString();
                }
                else
                {
                    int numero = Convert.ToInt16(dgv.Rows[dgv.Rows.Count - 1].Cells[1].Value.ToString());
                    int suma = numero + 1;
                    if (suma < 10) { tb.Text = "0" + suma.ToString(); } else { tb.Text = suma.ToString(); }
              
                }
            }
            else
            {
                if (!tipoDeNumeracion)
                {
                    tb.Text = "1";
                }
                else
                {
                    tb.Text = "01";
                }
            }
        }
        private void botonAbrirFileDialog_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    pictureBoxAgregarEditar.Image = Image.FromFile(openFileDialog.FileName.ToString());
                }
                catch
                {
                    MessageBox.Show("No se soporta el formato del archivo seleccionado");
                }
            }
        }

        private void botAceptarClasif_Click(object sender, EventArgs e)
        {
            if (validarClasificaciones())
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBoxAgregarEditar.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                if (modo == "AGREGA")
                {
                        List<string> listaProcAgrega = SQLConnector.generarListaParaProcedure("@codigo", "@descripcion", "@imagen");
                        SQLConnector.executeProcedure("sp_Clasificaciones_Add", listaProcAgrega, Convert.ToInt16(tbCodigoClasif.Text), tbDescripcionClasif.Text, ms.GetBuffer());
                        cargarClasificaciones();
                        botCancelarClasif.PerformClick();
         
                }
                else if (modo == "EDITA")
                {
                    List<string> listaProcEdita = SQLConnector.generarListaParaProcedure("@id","@descripcion", "@imagen");
                    SQLConnector.executeProcedure("sp_Clasificaciones_Update", listaProcEdita, Convert.ToInt16(tbIdClasif.Text),
                        tbDescripcionClasif.Text, ms.GetBuffer());
                    cargarClasificaciones();
                    botCancelarClasif.PerformClick();

                }

            }
            else
            {
                MessageBox.Show("Alguno de los campos requeridos no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            gbClasificaciones.Enabled = true;
            gbAgregarEditarClasif.Visible = false;
        }

        private bool validarClasificaciones()
        {
            if (tbCodigoClasif.Text != "" && tbDescripcionClasif.Text != "" && pictureBoxAgregarEditar.Image != null)
            {
                DataTable codigo = SQLConnector.obtenerTablaSegunConsultaString("select c.codigo from dbo.Clasificaciones c where c.codigo = " + tbCodigoClasif.Text);
                if (codigo.Rows.Count > 0 && modo == "AGREGA")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        private void dgvClasif_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClasif.SelectedRows.Count > 0 && dgvClasif.Rows.Count > 0)
            {
                DataTable clasificacion = SQLConnector.obtenerTablaSegunConsultaString("select * from dbo.Clasificaciones where codigo = " + dgvClasif.CurrentRow.Cells[0].Value.ToString());
                tbIdClasif.Text = clasificacion.Rows[0].ItemArray[0].ToString();
                tbCodigoClasif.Text = clasificacion.Rows[0].ItemArray[1].ToString();
                tbDescripcionClasif.Text = clasificacion.Rows[0].ItemArray[2].ToString();
                byte[] imageBuffer = (byte[])clasificacion.Rows[0].ItemArray[3];
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ms = new System.IO.MemoryStream(imageBuffer);
                pictureBox.Image = Image.FromStream(ms);
                pictureBoxAgregarEditar.Image = Image.FromStream(ms);
        
            }
 
        }

        private void botEliminarClasif_Click(object sender, EventArgs e)
        {            
            if (dgvClasif.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro que quiere eliminar la clasificación?", "Eliminar",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    List<string> listaProcElimina = SQLConnector.generarListaParaProcedure("@id");
                    SQLConnector.executeProcedure("sp_Clasificaciones_Delete", listaProcElimina, Convert.ToInt16(tbIdClasif.Text));
                    cargarClasificaciones();

                }
            }
        }

        private void cargarCampos(string texto, string codigo, bool carga, bool tipoNumerac)
        {
            cambiarVisibilidad(false, false, true, false);
            gbValidacion.Enabled = true;
            gbValidacion.Text = texto;
            tbCodigo.Text = codigo;
            tipoDeCarga = carga;
            tipoDeNumeracion = tipoNumerac;
            if (tipoDeCarga)
            {
                cargarPorRangos();
            }
            else
            {
                cargarPorDescripcion();
            }
        }

        private void cargarPorRangos()
        {
            dgvValidaciones.DataSource = null;
            dgvValidaciones.Refresh();
            if (dgvValidaciones.Columns.Count > 0)
            {
                dgvValidaciones.Columns.Clear();
            }
            DataTable rangos = SQLConnector.obtenerTablaSegunConsultaString(@"Select v.id, v.codigoInterno as Cód, v.rangoDesde as 'Rango Desde',
            v.rangoHasta as 'Rango Hasta', c.imagen as ' ', v.idClasif from dbo.Validaciones v inner join dbo.Clasificaciones c on v.idClasif = c.id where v.codigo = " + tbCodigo.Text);
            dgvValidaciones.DataSource = rangos;
            dgvValidaciones.Columns[0].Visible = false;
            dgvValidaciones.Columns[5].Visible = false;
            ((DataGridViewImageColumn)dgvValidaciones.Columns[4]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgvValidaciones.Columns[1].Width = 30;
            dgvValidaciones.Columns[2].Width = 95;
            dgvValidaciones.Columns[3].Width = 95;
            dgvValidaciones.Columns[4].Width = 40;

        }

        private void cargarPorDescripcion()
        {
            dgvValidaciones.DataSource = null;
            dgvValidaciones.Refresh();
            if (dgvValidaciones.Columns.Count > 0)
            {
                dgvValidaciones.Columns.Clear();
            }
            DataTable descripcion = SQLConnector.obtenerTablaSegunConsultaString(@"Select v.id, v.codigoInterno as Cód, v.descripcion as Descripción,
            c.imagen as ' ', v.idClasif from dbo.Validaciones v inner join dbo.Clasificaciones c on v.idClasif = c.id where v.codigo = " + tbCodigo.Text);
            dgvValidaciones.DataSource = descripcion;
            dgvValidaciones.Columns[0].Visible = false;
            dgvValidaciones.Columns[4].Visible = false;
            ((DataGridViewImageColumn)dgvValidaciones.Columns[3]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgvValidaciones.Columns[1].Width = 30;
            dgvValidaciones.Columns[2].Width = 180;
            dgvValidaciones.Columns[3].Width = 40;
          
        }


        private void botAgregarValidacion_Click(object sender, EventArgs e)
        {
            agregarValidacion();
      
        }

        private void agregarValidacion()
        {
            tbCodigoValidacion.Clear();
            tbDescripcionValidacion.Clear();
            tbRangoDesde.Clear();
            tbRangoHasta.Clear();
            cbClasificación.DataSource = null;
            llenarCombo();
            if (cbClasificación.Items.Count > 0)
            {
                cbClasificación.SelectedIndex = -1;
            }
            gbAgregarEditarValidacion.Visible = true;
            gbAgregarEditarValidacion.Text = gbValidacion.Text + " - AGREGANDO VALIDACIÓN";
            gbValidacion.Enabled = false;
            cambiarVisibilidadSegunTipoDeCarga();
            if (tipoDeCarga) { tbRangoDesde.Focus(); }{ tbDescripcionValidacion.Focus(); }
            modo = "AGREGA";
            cargarNumeroValidaciones(dgvValidaciones, tbCodigoValidacion);
        }

        private void llenarCombo()
        {
            DataTable combo = SQLConnector.obtenerTablaSegunConsultaString("select id, (convert(varchar(4),codigo) + ' - ' + descripcion) as detalle from dbo.Clasificaciones");
            cbClasificación.DataSource = combo;
            cbClasificación.DisplayMember = "detalle";
            cbClasificación.ValueMember = "id";
        }

        private void cambiarVisibilidadSegunTipoDeCarga()
        {
            if (tipoDeCarga)
            {
                visibilidadLabelsYTextsBoxs(true, true, false, true, true, false);
            }
            else
            {
                visibilidadLabelsYTextsBoxs(false, false, true, false, false, true);
            }
        }

        private void visibilidadLabelsYTextsBoxs(bool lblD, bool lblH, bool lblDesc, bool tbD, bool tbH, bool tbDesc)
        {
            lblDesde.Visible = lblD;
            lblHasta.Visible = lblH;
            lblDescripcion.Visible = lblDesc;
            tbRangoDesde.Visible = tbD;
            tbRangoHasta.Visible = tbH;
            tbDescripcionValidacion.Visible = tbDesc;

        }

        private void botonModifValidacion_Click(object sender, EventArgs e)
        {
            modificarValidacion();
        }

        private void modificarValidacion()
        {
            if (dgvValidaciones.SelectedRows.Count > 0)
            {
                gbAgregarEditarValidacion.Text = gbValidacion.Text + " - MODIFICANDO VALIDACIÓN";
                gbValidacion.Enabled = false;
                gbAgregarEditarValidacion.Visible = true;
                cambiarVisibilidadSegunTipoDeCarga();
                if (tipoDeCarga){tbRangoDesde.Focus();}{ tbDescripcionValidacion.Focus(); }
                modo = "EDITA";
            }
        }

        private void botAceptarValidacion_Click(object sender, EventArgs e)
        {
            if (validarIngresoValidacion())
            {
                if (modo == "AGREGA")
                {
                    if (tipoDeCarga)
                    {

                        List<string> listaProcAddRango = SQLConnector.generarListaParaProcedure("@codigo", "@codigoInterno", "@rangoDesde"
                            , "@rangoHasta","idClasif");
                        SQLConnector.executeProcedure("sp_Validaciones_AddPorRango", listaProcAddRango,tbCodigo.Text, tbCodigoValidacion.Text,
                            tbRangoDesde.Text,tbRangoHasta.Text,Convert.ToInt16(cbClasificación.SelectedValue.ToString()));
                        cargarValidaciones();
                        agregarValidacion();
                    }
                    else
                    {
                        List<string> listaProcAddDescripcion = SQLConnector.generarListaParaProcedure("@codigo","@codigoInterno", "@descripcion", "@idClasif");
                        SQLConnector.executeProcedure("sp_Validaciones_AddPorDescripcion", listaProcAddDescripcion, tbCodigo.Text, tbCodigoValidacion.Text,
                            tbDescripcionValidacion.Text, Convert.ToInt16(cbClasificación.SelectedValue.ToString()));
                        cargarValidaciones();
                        agregarValidacion();
                    }

                }
                else if (modo == "EDITA")
                {
                    if (tipoDeCarga)
                    {
                        List<string> listaProcEditRango = SQLConnector.generarListaParaProcedure("@id","@rangoDesde"
                            , "@rangoHasta", "idClasif");
                        SQLConnector.executeProcedure("sp_Validaciones_UpdatePorRango", listaProcEditRango, Convert.ToInt16(tbIdValidacion.Text),
                            tbRangoDesde.Text, tbRangoHasta.Text, Convert.ToInt16(cbClasificación.SelectedValue.ToString()));
                        cargarValidaciones();
                        botCancelarValidacion.PerformClick();
                    }
                    else
                    {
                        List<string> listaProcEditDescripcion = SQLConnector.generarListaParaProcedure("@id", "@descripcion", "@idClasif");
                        SQLConnector.executeProcedure("sp_Validaciones_UpdatePorDescripcion", listaProcEditDescripcion, Convert.ToInt16(tbIdValidacion.Text),
                            tbDescripcionValidacion.Text, Convert.ToInt16(cbClasificación.SelectedValue.ToString()));
                        cargarValidaciones();
                        botCancelarValidacion.PerformClick();
                    }
                }
            }
            else
            {
                MessageBox.Show("Alguno de los campos requeridos no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            gbValidacion.Enabled = true;
            cambiarVisibilidad(false, false, true, false);
        }

        private bool validarIngresoValidacion()
        {
            if (tipoDeCarga)
            {
                if ( tbRangoDesde.Text != "" && tbRangoHasta.Text != "" && cbClasificación.SelectedIndex != -1) { return true; }{ return false; }

            }
            else
            {
                if (tbDescripcionValidacion.Text != "" && cbClasificación.SelectedIndex != -1) { return true; }{ return false; }
            }

        }

        private void botCancelarValidacion_Click(object sender, EventArgs e)
        {
            gbValidacion.Enabled = true;
            cambiarVisibilidad(false,false,true,false);
        }

        private void botonEliminarValidacion_Click(object sender, EventArgs e)
        {
            if (dgvValidaciones.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro que quiere eliminar la validación?", "Eliminar",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt16(dgvValidaciones.SelectedRows[0].Cells[0].Value.ToString());
                    List<string> listaProcDelete = SQLConnector.generarListaParaProcedure("@id");
                    SQLConnector.executeProcedure("sp_Validaciones_Delete", listaProcDelete, id);
                    cargarValidaciones();
                }
            }
        }

        private void cargarValidaciones()
        {
            if (tipoDeCarga)
            {
                cargarPorRangos();
            }
            else
            {
                cargarPorDescripcion();
            }



        }


        private void botCerrarValidacion_Click(object sender, EventArgs e)
        {
            cambiarVisibilidad(false, false, false, false);
        }

        private void botCerrarClasif_Click(object sender, EventArgs e)
        {
            cambiarVisibilidad(false, false, false, false);
        }

        private void dgvValidaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (tipoDeCarga)
            {
                if (dgvValidaciones.CurrentRow != null && dgvValidaciones.Columns.Count == 6)
                {
                    tbIdValidacion.Text = dgvValidaciones.CurrentRow.Cells[0].Value.ToString();
                    tbCodigoValidacion.Text = dgvValidaciones.CurrentRow.Cells[1].Value.ToString();
                    tbRangoDesde.Text = dgvValidaciones.CurrentRow.Cells[2].Value.ToString();
                    tbRangoHasta.Text = dgvValidaciones.CurrentRow.Cells[3].Value.ToString();
                    llenarCombo();
                    cbClasificación.SelectedValue = dgvValidaciones.CurrentRow.Cells[5].Value.ToString();
                }
            }
            else
            {
                if (dgvValidaciones.CurrentRow != null && dgvValidaciones.Columns.Count == 5)
                {
                    tbIdValidacion.Text = dgvValidaciones.CurrentRow.Cells[0].Value.ToString();
                    tbCodigoValidacion.Text = dgvValidaciones.CurrentRow.Cells[1].Value.ToString();
                    tbDescripcionValidacion.Text = dgvValidaciones.CurrentRow.Cells[2].Value.ToString();
                    llenarCombo();
                    cbClasificación.SelectedValue = dgvValidaciones.CurrentRow.Cells[4].Value.ToString();
                }

            }
        }

        private void botonIMC_Click(object sender, EventArgs e)
        {
            cargarCampos("(1) BIOTIPO", "1", false,false);
        }

        private void botonEntradaDeAire_Click(object sender, EventArgs e)
        {
            cargarCampos("(2) ENTRADA DE AIRE", "2", false, false);
        }

        private void botRuidosAgregados_Click(object sender, EventArgs e)
        {
            cargarCampos("(3) RUIDOS AGREGADOS", "3", false, false);
        }

        private void botRuidosCardiacos_Click(object sender, EventArgs e)
        {
            cargarCampos("(4) RUIDOS CARDÍACOS", "4", false, false);
        }

        private void botSilencios_Click(object sender, EventArgs e)
        {
            cargarCampos("(5) SILENCIOS", "5", false, false);
        }

        private void botTAMaxima_Click(object sender, EventArgs e)
        {
            cargarCampos("(6) T.A. MÁXIMA", "6", true, false);
        }

        private void botTAMinima_Click(object sender, EventArgs e)
        {
            cargarCampos("(7) T.A. MÍNIMA", "7", true, false);
        }

        private void botPulso_Click(object sender, EventArgs e)
        {
            cargarCampos("(8) PULSO", "8", true, false);
        }

        private void botAbdomen_Click(object sender, EventArgs e)
        {
            cargarCampos("(9) ABDOMEN", "9", false, false);
        }

        private void botHernias_Click(object sender, EventArgs e)
        {
            cargarCampos("(10) HERNIAS", "10", false, false);
        }

        private void botVarices_Click(object sender, EventArgs e)
        {
            cargarCampos("(11) VARICES", "11", false, false);
        }

        private void botApGenitour_Click(object sender, EventArgs e)
        {
            cargarCampos("(12) AP. GENITOUR.", "12", false, false);
        }

        private void botPielYFaneras_Click(object sender, EventArgs e)
        {
            cargarCampos("(13) PIEL Y FANERAS", "13", false, false);
        }

        private void botApLocomotor_Click(object sender, EventArgs e)
        {
            cargarCampos("(14) AP. LOCOMOTOR", "14", false, false);
        }

        private void botSNC_Click(object sender, EventArgs e)
        {
            cargarCampos("(15) S.N.C.", "15", false, false);
        }

        private void botOjoDer_Click(object sender, EventArgs e)
        {
            cargarCampos("(16) OJO DER.", "16", false, false);
        }

        private void botLentesDer_Click(object sender, EventArgs e)
        {
            cargarCampos("(17) OJO DER. C/ LENTES", "17", false, false);
        }

        private void botOjoIzq_Click(object sender, EventArgs e)
        {
            cargarCampos("(18) OJO IZQ.", "18", false, false);
        }

        private void botLentesIzq_Click(object sender, EventArgs e)
        {
            cargarCampos("(19) OJO IZQ. C/ LENTES", "19", false, false);
        }

        private void botVisionCromatica_Click(object sender, EventArgs e)
        {
            cargarCampos("(20) VISIÓN CROMÁTICA", "20", false, false);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            cargarCampos("(21) EXAMEN ODONTOLÓGICO", "21", false, false);
        }

        private void botonDictamenClinico_Click(object sender, EventArgs e)
        {
            cargarCampos("(22) DICTÁMEN FISICO", "22", false, true);
        }

        private void botGRojos_Click(object sender, EventArgs e)
        {
            cargarCampos("(30) G.ROJOS", "30", true, false);
        }

        private void botGBlancos_Click(object sender, EventArgs e)
        {
            cargarCampos("(31) G.BLANCOS", "31", true, false);
        }

        private void botHemoglob_Click(object sender, EventArgs e)
        {
            cargarCampos("(32) HEMOGLOBINA", "32", true, false);
        }

        private void botHematocrito_Click(object sender, EventArgs e)
        {
            cargarCampos("(33) HEMATOCRITO", "33", true, false);
        }

        private void botEritro_Click(object sender, EventArgs e)
        {
            cargarCampos("(34) ERITROSEDIMENTACIÓN", "34", true, false);
        }

        private void botCayado_Click(object sender, EventArgs e)
        {
            cargarCampos("(35) N. EN CAYADO", "35", true, false);
        }

        private void botSegmentados_Click(object sender, EventArgs e)
        {
            cargarCampos("(36) N. SEGMENTADOS", "36", true, false);
        }

        private void botEosinofilos_Click(object sender, EventArgs e)
        {
            cargarCampos("(37) EOSINÓFILOS", "37", true, false);
        }

        private void botBasofilos_Click(object sender, EventArgs e)
        {
            cargarCampos("(38) BASÓFILOS", "38", true, false);
        }

        private void botLinfocitos_Click(object sender, EventArgs e)
        {
            cargarCampos("(39) LINFOCITOS", "39", true, false);
        }

        private void botMonocitos_Click(object sender, EventArgs e)
        {
            cargarCampos("(40) MONOCITOS", "40", true, false);
        }


        private void botGlucemia_Click(object sender, EventArgs e)
        {
            cargarCampos("(41) GLUCEMIA", "41", true, false);

        }

        private void botUremia_Click(object sender, EventArgs e)
        {
            cargarCampos("(42) UREMIA", "42", true, false);
        }

        private void botChagas_Click(object sender, EventArgs e)
        {
            cargarCampos("(43) CHAGAS", "43", false, false);
        }

        private void botVDRL_Click(object sender, EventArgs e)
        {
            cargarCampos("(44) VDRL", "44", false, false);
        }

        private void botGrupo_Click(object sender, EventArgs e)
        {
            cargarCampos("(45) GRUPO", "45", false, false);
        }

        private void botonFactor_Click(object sender, EventArgs e)
        {
            cargarCampos("(46) FACTOR", "46", false, false);
        }

        private void botColor_Click(object sender, EventArgs e)
        {
            cargarCampos("(47) COLOR", "47", false, false);
        }

        private void botAspecto_Click(object sender, EventArgs e)
        {
            cargarCampos("(48) ASPECTO", "48", false, false);
        }

        private void botDensidad_Click(object sender, EventArgs e)
        {
            cargarCampos("(49) DENSIDAD", "49", true, false);
        }

        private void botPH_Click(object sender, EventArgs e)
        {
            cargarCampos("(50) PH", "50", true, false);
        }

        private void botGlucosa_Click(object sender, EventArgs e)
        {
            cargarCampos("(51) GLUCOSA", "51", false, false);
        }

        private void botProteinas_Click(object sender, EventArgs e)
        {
            cargarCampos("(52) PROTEÍNAS", "52", false, false);
        }

        private void botHemoglobina_Click(object sender, EventArgs e)
        {
            cargarCampos("(53) HEMOGLOBINA", "53", false, false);
        }

        private void botBillirubina_Click(object sender, EventArgs e)
        {
            cargarCampos("(54) BILIRRUBINA", "54", false, false);
        }

        private void botCelulas_Click(object sender, EventArgs e)
        {
            cargarCampos("(55) CÉLULAS", "55", false, false);
        }

        private void botLeucocitos_Click(object sender, EventArgs e)
        {
            cargarCampos("(56) LEUCOCITOS", "56", false, false);
        }

        private void botHematies_Click(object sender, EventArgs e)
        {
            cargarCampos("(57) HEMATIES", "57", false, false);
        }

        private void botPiocitos_Click(object sender, EventArgs e)
        {
            cargarCampos("(58) PIOCITOS", "58", false, false);
        }

        private void botMucus_Click(object sender, EventArgs e)
        {
            cargarCampos("(59) MUCUS", "59", false, false);
        }

        private void botDictamenLaboratorio_Click(object sender, EventArgs e)
        {
            cargarCampos("(60) DICTÁMEN LABORATORIO", "60", false, true);
        }

        private void botRxTorax_Click(object sender, EventArgs e)
        {
            cargarCampos("(70) RX. TORAX", "70", false, false);
        }

        private void botRxColumna_Click(object sender, EventArgs e)
        {
            cargarCampos("(71) RX. COLUMNA", "71", false, false);
        }

        private void botDictamenRX_Click(object sender, EventArgs e)
        {
            cargarCampos("(72) DICTÁMEN RX.", "72", false, true);
        }

        private void botElectrocardio_Click(object sender, EventArgs e)
        {
            cargarCampos("(80) ELECTROCARDIOGRAMA", "80", false, false);
        }

        private void botDictamenCardiologia_Click(object sender, EventArgs e)
        {
            cargarCampos("(81) DICTÁMEN CARDIOLÓGICO", "81", false, true);
        }

        private void botonDictamenFinal_Click(object sender, EventArgs e)
        {
            cargarCampos("(90) DICTÁMEN FINAL", "90", false, true);
        }

 

        private void cbClasificación_Enter(object sender, EventArgs e)
        {
            cbClasificación.DroppedDown = true;
        }

        private void botImag_Click(object sender, EventArgs e)
        {
            Utilidades.abrirFormulario(this.MdiParent, new frmImagenesExamen(), new Configuracion());
        }










    }
}
