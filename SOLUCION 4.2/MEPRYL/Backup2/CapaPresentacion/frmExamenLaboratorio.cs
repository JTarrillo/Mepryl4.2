using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comunes;

namespace CapaPresentacion
{
    public partial class frmExamenLaboratorio : Form
    {
        private CapaNegocioMepryl.ExamenPreventiva preventiva;
        private DataGridViewRow tipoExamen;
        private frmBusquedaExamen formBusqueda;
        private frmPaciente formPaciente;
        private DataTable valoresPorExamen;

        int ind = -1;
        bool puntosHabilitados = true;

        public frmExamenLaboratorio(frmBusquedaExamen frm, DataGridViewRow r)     
        {
            InitializeComponent();
            this.Text = "N° Examen: " + r.Cells[3].Value.ToString() + " - Liga: " +
                       r.Cells[4].Value.ToString() + " - Club: " + r.Cells[5].Value.ToString()
                       + " - Examinado: " + r.Cells[7].Value.ToString() + "  " + r.Cells[8].Value.ToString();
            formBusqueda = frm;
            inicializarExamen(r);
        }

        public frmExamenLaboratorio(frmPaciente frm, DataGridViewRow r)
        {
            InitializeComponent();
            formPaciente = frm;
            inicializarExamen(r);
        }


        public frmExamenLaboratorio(frmPaciente frm, DataGridViewRow r, DataTable ve)
        {
            InitializeComponent();
            formPaciente = frm;
            inicializarExamen(r);
        }

        private void inicializarExamen(DataGridViewRow r)
        {
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
            tipoExamen = r;
            cargarComboBoxs();
            puntosHabilitados = false;
            cargarEntidad();
            puntosHabilitados = true;
            this.ActiveControl = tb30;
            tb30.Focus();
        }


        private void cargarEntidad()
        {
            Entidades.ExamenPreventiva entidad = preventiva.cargarExamen(tipoExamen.Cells[0].Value.ToString());
            tbId.Text = entidad.IdTipoExamen.ToString();
            tb30.Text = entidad.GRojos;
            tb31.Text = entidad.GBlancos;
            tb32.Text = entidad.Hemoglob;
            tb33.Text = entidad.Hemato;
            tb34.Text = entidad.Eritro;
            tb61.Text = entidad.ObsSerieRoja;
            if (entidad.Cayado != -1) { tb35.Text = entidad.Cayado.ToString(); }
            if (entidad.Segmentado != -1) { tb36.Text = entidad.Segmentado.ToString(); }
            if (entidad.Eosinof != -1) { tb37.Text = entidad.Eosinof.ToString(); }
            if (entidad.Basof != -1) { tb38.Text = entidad.Basof.ToString(); }
            if (entidad.Linfoc != -1) { tb39.Text = entidad.Linfoc.ToString(); }
            if (entidad.Monoc != -1) { tb40.Text = entidad.Monoc.ToString(); }
            tb62.Text = entidad.ObsSerieBlanca;
            if (entidad.Glucemia != -1) { tb41.Text = entidad.Glucemia.ToString(); }
            if (entidad.Uremia != -1) { tb42.Text = entidad.Uremia.ToString(); }
            cbo43.SelectedValue = entidad.Chagas;
            cbo44.SelectedValue = entidad.Vdrl;
            cbo45.SelectedValue = entidad.Grupo;
            cbo46.SelectedValue = entidad.Factor;
            cbo47.SelectedValue = entidad.Color;
            cbo48.SelectedValue = entidad.Aspecto;
            tb49.Text = entidad.Densidad;
            if (entidad.Ph != -1) { tb50.Text = entidad.Ph.ToString(); }
            cbo51.SelectedValue = entidad.Glucosa;
            cbo52.SelectedValue = entidad.Proteinas;
            cbo53.SelectedValue = entidad.HemoglobOrina;
            cbo54.SelectedValue = entidad.Bilirrubina;
            cbo55.SelectedValue = entidad.Celulas;
            cbo56.SelectedValue = entidad.Leucocitos;
            cbo57.SelectedValue = entidad.Hematies;
            cbo58.SelectedValue = entidad.Piocitos;
            cbo59.SelectedValue = entidad.Mucus;
            tb63.Text = entidad.OtrosOrina1;
            tb64.Text = entidad.OtrosOrina2;
            tb65.Text = entidad.ObsLaborat;
            cbo60.SelectedValue = entidad.DictLab;
            comprobarValidacionRango(tb30, "30", pb30);
            comprobarValidacionRango(tb31, "31", pb31);
            comprobarValidacionRango(tb32, "32", pb32);
            comprobarValidacionRango(tb33, "33", pb33);
            comprobarValidacionRango(tb34, "34", pb34);
            comprobarValidacionRango(tb35, "35", pb35);
            comprobarValidacionRango(tb36, "36", pb36);
            comprobarValidacionRango(tb37, "37", pb37);
            comprobarValidacionRango(tb38, "38", pb38);
            comprobarValidacionRango(tb39, "39", pb39);
            comprobarValidacionRango(tb40, "40", pb40);
            comprobarValidacionRango(tb41, "41", pb41);
            comprobarValidacionRango(tb42, "42", pb42);
            comprobarValidacionRango(tb49, "49", pb49);
            comprobarValidacionRango(tb50, "50", pb50);
        }

        private void cargarComboBoxs()
        {
            llenarCombo(cbo43, "43");
            llenarCombo(cbo44, "44");
            llenarCombo(cbo45, "45");
            llenarCombo(cbo46, "46");
            llenarCombo(cbo47, "47");
            llenarCombo(cbo48, "48");
            llenarCombo(cbo51, "51");
            llenarCombo(cbo52, "52");
            llenarCombo(cbo53, "53");
            llenarCombo(cbo54, "54");
            llenarCombo(cbo55, "55");
            llenarCombo(cbo56, "56");
            llenarCombo(cbo57, "57");
            llenarCombo(cbo58, "58");
            llenarCombo(cbo59, "59");
            llenarCombo(cbo60, "60");
        }


        public void llenarCombo(ComboBox cbo, string codigo)
        {
            DataTable combo = SQLConnector.obtenerTablaSegunConsultaString(@"select v.id, (convert(varchar(4),v.codigoInterno) + ' - ' + v.descripcion) as detalle, c.imagen from dbo.Validaciones v
            inner join dbo.Clasificaciones c on v.idClasif = c.id
            where v.codigo = " + codigo + " order by convert(int,v.codigoInterno) asc");
            cbo.DataSource = combo;
            cbo.ValueMember = "id";
            cbo.DisplayMember = "detalle";
            cbo.SelectedIndex = -1;
        }

        private void cargarIcono(string index, DataRowView row, PictureBox pb)
        {
            if (index != "-1")
            {
                byte[] imageBuffer = (byte[])row.Row[2];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Image = Image.FromStream(ms);
            }
            else
            {
                pb.Image = null;
            }


        }

        //EVENTOS COMBOS INDEXCHANGED ----------------------------------------------------------------------

        private void cbo43_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo43.SelectedIndex.ToString(), (DataRowView)cbo43.SelectedItem, pb43);
        }

        private void cbo44_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo44.SelectedIndex.ToString(), (DataRowView)cbo44.SelectedItem, pb44);
        }

        private void cbo45_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo45.SelectedIndex.ToString(), (DataRowView)cbo45.SelectedItem, pb45);
        }

        private void cbo46_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo46.SelectedIndex.ToString(), (DataRowView)cbo46.SelectedItem, pb46);
        }

        private void cbo47_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo47.SelectedIndex.ToString(), (DataRowView)cbo47.SelectedItem, pb47);
        }

        private void cbo48_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo48.SelectedIndex.ToString(), (DataRowView)cbo48.SelectedItem, pb48);
        }

        private void cbo51_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo51.SelectedIndex.ToString(), (DataRowView)cbo51.SelectedItem, pb51);
        }

        private void cbo52_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo52.SelectedIndex.ToString(), (DataRowView)cbo52.SelectedItem, pb52);
        }

        private void cbo53_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo53.SelectedIndex.ToString(), (DataRowView)cbo53.SelectedItem, pb53);
        }

        private void cbo54_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo54.SelectedIndex.ToString(), (DataRowView)cbo54.SelectedItem, pb54);
        }

        private void cbo55_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo55.SelectedIndex.ToString(), (DataRowView)cbo55.SelectedItem, pb55);
        }

        private void cbo56_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo56.SelectedIndex.ToString(), (DataRowView)cbo56.SelectedItem, pb56);
        }

        private void cbo57_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo57.SelectedIndex.ToString(), (DataRowView)cbo57.SelectedItem, pb57);
        }

        private void cbo58_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo58.SelectedIndex.ToString(), (DataRowView)cbo58.SelectedItem, pb58);
        }

        private void cbo59_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo59.SelectedIndex.ToString(), (DataRowView)cbo59.SelectedItem, pb59);
        }

        private void cbo60_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo60.SelectedIndex.ToString(), (DataRowView)cbo60.SelectedItem, pb60);
            ind = cbo60.SelectedIndex;
        }




        private void comprobarValidacionRango(TextBox tb, string codigo, PictureBox pb)
        {
            if (tb.Text != "")
            {
                DataTable validacRango = SQLConnector.obtenerTablaSegunConsultaString(@"select v.id, v.rangoDesde, v.rangoHasta,
                c.imagen from dbo.Validaciones v inner join dbo.Clasificaciones c on v.idClasif = c.id 
                where v.codigo = " + codigo);
                bool encontro = false;
                foreach (DataRow row in validacRango.Rows)
                {
          
                    if (tb.Text.Contains("."))
                    {

                        if (Convert.ToInt32(tb.Text.Replace(".", "")) >= Convert.ToInt32(row.ItemArray[1].ToString())
              && Convert.ToInt32(tb.Text.Replace(".", "")) <= Convert.ToInt32(row.ItemArray[2].ToString()))
                        {
                            byte[] imageBuffer = (byte[])row.ItemArray[3];
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                            pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            pb.Image = Image.FromStream(ms);
                            encontro = true;
                        }
                    }
                    else
                    {
                        try
                        {
                           
                            if (Convert.ToDouble(tb.Text) >= Convert.ToDouble(row.ItemArray[1].ToString()) && 
                                Convert.ToDouble(tb.Text) <= Convert.ToDouble(row.ItemArray[2].ToString()))
                            {
                                byte[] imageBuffer = (byte[])row.ItemArray[3];
                                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                                pb.Image = Image.FromStream(ms);
                                encontro = true;
                            }
                        }
                        catch
                        {
                            tb.Text = "";
                            pb.Image = null;
                        }

                    }
                }
                if (!encontro)
                {
                    pb.Image = null;
                    SendKeys.Send("+{TAB}");
                    
                }
               
            }
            else
            {
                pb.Image = null;
            }
         
        }

        private void tb30_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb30, "30", pb30);
        }

        private void tb31_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb31, "31", pb31);
        }

        private void tb32_Leave(object sender, EventArgs e)
        {
            reemplazarCaracter(tb32, '.', ',');
            comprobarValidacionRango(tb32, "32", pb32);
        }

        private void tb33_Leave(object sender, EventArgs e)
        {
            reemplazarCaracter(tb33, '.', ',');
            comprobarValidacionRango(tb33, "33", pb33);
        }

        private void tb34_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb34, "34", pb34);
        }

        private void tb35_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb35, "35", pb35);
        }

        private void tb36_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb36, "36", pb36);
        }

        private void tb37_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb37, "37", pb37);
        }

        private void tb38_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb38, "38", pb38);

        }

        private void tb39_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb39, "39", pb39);
        }

        private void tb40_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb40, "40", pb40);
            if (!verificarFormulaLeucocitaria())
            {
                MessageBox.Show("La suma de los totales de la fórmula leucocitaria debe ser 100",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tb41_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb41, "41", pb41);
        }

        private void tb42_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb42, "42", pb42);
        }

        private void tb49_Leave(object sender, EventArgs e)
        {
            reemplazarCaracter(tb49, '.', ',');
            comprobarValidacionRango(tb49, "49", pb49);
        }

        private void tb50_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb50, "50", pb50);
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            guardarExamen();
        }

        private void guardarExamen()
        {
          
                if (verificarFormulaLeucocitaria())
                {
                    guardar(); 
                    this.Close();
                    if (formBusqueda != null)
                    {
                        formBusqueda.actualizarExamenes();
                    }
                    else if (formPaciente != null)
                    {
                        formPaciente.cargarExamenes();
                    }
                }
                else
                {
                    MessageBox.Show("La suma de los totales de la fórmula leucocitaria debe ser 100",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
          
        }

        private void guardar()
        {
            Entidades.Resultado result = preventiva.guardarExLaboratorio(llenarEntidad());
            if (result.Modo == -1)
            {
                MessageBox.Show("No se puede guardar el exámen de laboratorio.\nError: " + result.Mensaje, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Entidades.ExamenPreventiva llenarEntidad()
        {
            Entidades.ExamenPreventiva retorno = new Entidades.ExamenPreventiva();
            retorno.IdTipoExamen = new Guid(tbId.Text);
            retorno.GRojos = tb30.Text;
            retorno.GBlancos = tb31.Text;
            retorno.Hemoglob = tb32.Text;
            retorno.Hemato = tb33.Text;
            retorno.Eritro = tb34.Text;
            retorno.ObsSerieRoja = tb61.Text;
            if (tb35.Text != string.Empty) { retorno.Cayado = Convert.ToInt16(tb35.Text); }
            if (tb36.Text != string.Empty) { retorno.Segmentado = Convert.ToInt16(tb36.Text); }
            if (tb37.Text != string.Empty) { retorno.Eosinof = Convert.ToInt16(tb37.Text); }
            if (tb38.Text != string.Empty) { retorno.Basof = Convert.ToInt16(tb38.Text); }
            if (tb39.Text != string.Empty) { retorno.Linfoc = Convert.ToInt16(tb39.Text); }
            if (tb40.Text != string.Empty) { retorno.Monoc = Convert.ToInt16(tb40.Text); }
            retorno.ObsSerieBlanca = tb62.Text;
            if (tb41.Text != string.Empty) { retorno.Glucemia = Convert.ToInt16(tb41.Text); }
            if (tb42.Text != string.Empty) { retorno.Uremia = Convert.ToInt16(tb42.Text); }
            if (cbo43.SelectedIndex != -1) { retorno.Chagas = Convert.ToInt16(cbo43.SelectedValue); }
            if (cbo44.SelectedIndex != -1) { retorno.Vdrl = Convert.ToInt16(cbo44.SelectedValue); }
            if (cbo45.SelectedIndex != -1) { retorno.Grupo = Convert.ToInt16(cbo45.SelectedValue); }
            if (cbo46.SelectedIndex != -1) { retorno.Factor = Convert.ToInt16(cbo46.SelectedValue); }
            if (cbo47.SelectedIndex != -1) { retorno.Color = Convert.ToInt16(cbo47.SelectedValue); }
            if (cbo48.SelectedIndex != -1) { retorno.Aspecto = Convert.ToInt16(cbo48.SelectedValue); }
            retorno.Densidad = tb49.Text;
            if (tb50.Text != string.Empty) { retorno.Ph = Convert.ToInt16(tb50.Text); }
            if (cbo51.SelectedIndex != -1) { retorno.Glucosa = Convert.ToInt16(cbo51.SelectedValue); }
            if (cbo52.SelectedIndex != -1) { retorno.Proteinas = Convert.ToInt16(cbo52.SelectedValue); }
            if (cbo53.SelectedIndex != -1) { retorno.HemoglobOrina = Convert.ToInt16(cbo53.SelectedValue); }
            if (cbo54.SelectedIndex != -1) { retorno.Bilirrubina = Convert.ToInt16(cbo54.SelectedValue); }
            if (cbo55.SelectedIndex != -1) { retorno.Celulas = Convert.ToInt16(cbo55.SelectedValue); }
            if (cbo56.SelectedIndex != -1) { retorno.Leucocitos = Convert.ToInt16(cbo56.SelectedValue); }
            if (cbo57.SelectedIndex != -1) { retorno.Hematies = Convert.ToInt16(cbo57.SelectedValue); }
            if (cbo58.SelectedIndex != -1) { retorno.Piocitos = Convert.ToInt16(cbo58.SelectedValue); }
            if (cbo59.SelectedIndex != -1) { retorno.Mucus = Convert.ToInt16(cbo59.SelectedValue); }
            if (cbo60.SelectedIndex != -1) { retorno.DictLab = Convert.ToInt16(cbo60.SelectedValue); }
            retorno.OtrosOrina1 = tb63.Text;
            retorno.OtrosOrina2 = tb64.Text;
            retorno.ObsLaborat = tb65.Text;          
            return retorno;
        }



        private void reemplazarCaracter(TextBox tb, char viejo, char nuevo)
        {
            string text = tb.Text;
            tb.Text = text.Replace(viejo, nuevo);
           
        }

        private bool validarIngreso()
        {
            if (indexActualValido(cbo43) && indexActualValido(cbo44)
                 && indexActualValido(cbo45) && indexActualValido(cbo46) && indexActualValido(cbo47)
                 && indexActualValido(cbo48) && textBoxValido(tb49) && textBoxValido(tb50)
                 && indexActualValido(cbo51) && indexActualValido(cbo52) && indexActualValido(cbo53)
                 && indexActualValido(cbo54) && indexActualValido(cbo55) && indexActualValido(cbo56)
                 && indexActualValido(cbo57) && indexActualValido(cbo58) && indexActualValido(cbo59)
                 && indexActualValido(cbo60)
            ) { return true; }
            return false;
        }

        private bool indexActualValido(ComboBox cb)
        {
            if (cb.SelectedIndex != -1) { return true; }
            return false;
        }

        private bool textBoxValido(TextBox tb)
        {
            if (tb.Text != "") { return true; }
            return false;

        }


        private void tb30_TextChanged(object sender, EventArgs e)
        {
            puntosAlTextBox(tb30, "###,###");
        }

        private void puntosAlTextBox(TextBox tb, string forma)
        {
            if (!string.IsNullOrEmpty(tb.Text) && puntosHabilitados)
            {
                int Position = tb.SelectionStart;
                Decimal result = 0;
                if (Decimal.TryParse(tb.Text, out result))
                {
                    tb.Text = result.ToString(forma);
                    tb.SelectionStart = Position + 1;

                }
            }

        }

        public static void soloNumeros(KeyPressEventArgs e)
        {
            if (!((char.IsDigit(e.KeyChar)) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        public static void numerosYPuntos(KeyPressEventArgs e)
        {
            if (!((char.IsDigit(e.KeyChar)) || (e.KeyChar == (char)Keys.Back) || e.KeyChar == (char) Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void tb30_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb31_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb32_KeyPress(object sender, KeyPressEventArgs e)
        {
            numerosYPuntos(e);
        }

        private void tb33_KeyPress(object sender, KeyPressEventArgs e)
        {
            numerosYPuntos(e);
        }

        private void tb34_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb35_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb36_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb37_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb38_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb39_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb40_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb41_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb42_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb49_KeyPress(object sender, KeyPressEventArgs e)
        {
            numerosYPuntos(e);
        }

        private void tb50_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb31_TextChanged(object sender, EventArgs e)
        {
           puntosAlTextBox(tb31,"###,###");
        }


        private bool verificarFormulaLeucocitaria()
        {
            if (tb35.Text != "" && tb36.Text != "" && tb37.Text != "" &&
                tb38.Text != "" && tb39.Text != "" && tb40.Text != "")
            {
                Int32 suma = Convert.ToInt32(tb35.Text) + Convert.ToInt32(tb36.Text)
                    + Convert.ToInt32(tb37.Text) + Convert.ToInt32(tb38.Text) +
                    Convert.ToInt32(tb39.Text) + Convert.ToInt32(tb40.Text);
                if (suma == 100) { return true; }
                return false;

            }
            else if (tb35.Text == "" && tb36.Text == "" && tb37.Text == "" &&
                tb38.Text == "" && tb39.Text == "" && tb40.Text == "")
            {
                return true;
            }
            return false;
        }


        private void seleccionarTexto(TextBox tb)
        {
            if (tb.Text.Length > 0)
            {
                tb.SelectionStart = 0;
                tb.SelectionLength = tb.Text.Length;
            }
        }

        private void tb30_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb30);
        }

        private void tb31_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb31);
        }

        private void tb32_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb32);
        }

        private void tb33_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb33);
        }

        private void tb34_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb34);
        }

        private void tb61_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb61);
        }

        private void tb35_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb35);
        }

        private void tb36_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb36);
        }

        private void tb37_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb37);
        }

        private void tb38_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb38);
        }

        private void tb39_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb39);
        }

        private void tb40_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb40);
        }

        private void tb62_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb62);
        }

        private void tb41_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb41);
        }

        private void tb42_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb42);
        }

        private void tb49_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb49);
        }

        private void tb50_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb50);
        }

        private void tb63_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb63);
        }

        private void tb64_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb64);
        }

        private void tb65_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb65);
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExamenLaboratorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && butAceptar.Visible)
            {
                butAceptar.PerformClick();
            }
            else if (e.KeyCode == Keys.F10 && butCancelar.Visible)
            {
                butCancelar.PerformClick();
            }   
        }







    }
}
