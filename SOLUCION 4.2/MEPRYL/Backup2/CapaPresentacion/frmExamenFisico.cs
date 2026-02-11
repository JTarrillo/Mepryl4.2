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
    public partial class frmExamenFisico : Form
    {
        CapaNegocioMepryl.ExamenPreventiva preventiva;
        public int modo;
        DataTable valoresExamen;
        DataGridViewRow examen;
        frmBusquedaExamen frmExamen;
        frmPaciente frmPac;
        int ind = -1;
        int pyf = -1;
        int apLoc = -1;
        int ojoD = -1;
        int lentOjoD = -1;
        int ojoI = -1;
        int lentOjoI = -1;

        public frmExamenFisico(frmBusquedaExamen frm,DataGridViewRow row)
        {
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
            InitializeComponent();
            frmExamen = frm;
            inicializarFormulario(row, 1);                          
        }

        public frmExamenFisico(frmPaciente frm, DataGridViewRow row)
        {
            preventiva = new CapaNegocioMepryl.ExamenPreventiva();
            InitializeComponent();
            frmPac = frm;
            inicializarFormulario(row, 1);
            valoresExamen = new DataTable();
            //antCli.Text = "NO REFIERE";
            //antQui.Text = "NO REFIERE";
            //antTrau.Text = "NO REFIERE";

        }

        public frmExamenFisico(frmPaciente frm, DataGridViewRow row, DataTable examen)
        {
            InitializeComponent();
            frmPac = frm;
            inicializarFormulario(row, 2);
            valoresExamen = examen;
            setearValores();

        }

        private void inicializarFormulario(DataGridViewRow row, int modoTextoDisplay)
        {
            if (modoTextoDisplay == 1)
            {
                this.Text = "N° Examen: " + row.Cells[3].Value.ToString() + " - Liga: " +
                       row.Cells[4].Value.ToString() + " - Club: " + row.Cells[5].Value.ToString()
                       + " - Examinado: " + row.Cells[7].Value.ToString() + "  " + row.Cells[8].Value.ToString();
            }
            else if (modoTextoDisplay == 2)
            {
                this.Text = "Fecha: " + row.Cells[2].Value.ToString() + " - Nro Ex: " + row.Cells[3].Value.ToString(); 
            }
            this.modo = modoTextoDisplay;
            llenarComboBoxs();   
            examen = row;
            cargarDatos();
            this.ActiveControl = antCli;
            this.antCli.Focus();
           

        }

        private void cargarDatos()
        {
            //Entidades.ExamenPreventiva entidad = new Entidades.ExamenPreventiva();
            Entidades.ExamenPreventiva entidad = preventiva.cargarExamen(examen.Cells[0].Value.ToString());
            //entidad = preventiva.cargarExamen(examen.Cells[0].Value.ToString());
            tbId.Text = entidad.IdTipoExamen.ToString();
            antCli.Text = "NO REFIERE";
            if (entidad.AntCli != "") { antCli.Text = entidad.AntCli; }
            antQui.Text = "NO REFIERE";
            if (entidad.AntQui != "") { antQui.Text = entidad.AntQui; }
            antTrau.Text = "NO REFIERE";
            if (entidad.AntTrau != "") { antTrau.Text = entidad.AntTrau; }
            tbTalla.Text = entidad.Talla;
            tbPeso.Text = entidad.Peso;
            calcularPeso();
            cbo1.SelectedValue = entidad.Biotipo;
            cbo2.SelectedValue = entidad.EntAire;
            cbo3.SelectedValue = entidad.RuiAgre;
            cbo4.SelectedValue = entidad.RuiCard;
            cbo5.SelectedValue = entidad.Silencios;
            if (entidad.TaMax != -1) { tb6.Text = entidad.TaMax.ToString(); }
            if (entidad.TaMin != -1) { tb7.Text = entidad.TaMin.ToString(); }
            if (entidad.Pulso != -1) { tb8.Text = entidad.Pulso.ToString(); }
            cbo9.SelectedValue = entidad.Abdomen;
            cbo10.SelectedValue = entidad.Hernias;
            cbo11.SelectedValue = entidad.Varices;
            cbo12.SelectedValue = entidad.ApGenitour;
            cbo13.SelectedValue = entidad.PielYFaneras;
            cbo14.SelectedValue = entidad.ApLocomotor;
            cbo15.SelectedValue = entidad.Snc;
            cbo16.SelectedValue = entidad.OjoDer;
            cbo17.SelectedValue = entidad.OjoDerLent;
            cbo18.SelectedValue = entidad.OjoIzq;
            cbo19.SelectedValue = entidad.OjoIzqLent;
            cbo20.SelectedValue = entidad.VisionCromatica;
            cbo21.SelectedValue = entidad.Odonto;
            tbObservaciones.Text = entidad.ObsFisico;
            cbo23.SelectedValue = entidad.Medico;
            cbo22.SelectedValue = entidad.DictFisico;        
        }






        private void setearValores()
        {
            tbTalla.Text = obtenerValor(25, 3, 1).ToString();
            tbPeso.Text = obtenerValor(26, 3, 1).ToString();
            calcularPeso();
            cbo1.SelectedValue = obtenerValor(1, 3, 2);
            cbo2.SelectedValue = obtenerValor(2, 3, 2);
            cbo3.SelectedValue = obtenerValor(3, 3, 2);
            cbo4.SelectedValue = obtenerValor(4, 3, 2);
            cbo5.SelectedValue = obtenerValor(5, 3, 2);
            tb6.Text = obtenerValor(6, 3, 1).ToString();
            comprobarValidacionRango(tb6, "6", pb6);
            tb7.Text = obtenerValor(7, 3, 1).ToString();
            comprobarValidacionRango(tb7, "7", pb7);
            tb8.Text = obtenerValor(8, 3, 1).ToString();
            comprobarValidacionRango(tb8, "8", pb8);
            cbo9.SelectedValue = obtenerValor(9,3,2);
            cbo10.SelectedValue = obtenerValor(10, 3,2);
            cbo11.SelectedValue = obtenerValor(11, 3, 2);
            cbo12.SelectedValue = obtenerValor(12, 3, 2);
            cbo13.SelectedValue = obtenerValor(13, 3, 2);
            cbo14.SelectedValue = obtenerValor(14, 3, 2);
            cbo15.SelectedValue = obtenerValor(15, 3, 2);
            cbo16.SelectedValue = obtenerValor(16, 3, 2);
            cbo17.SelectedValue = obtenerValor(17, 3, 2);
            cbo18.SelectedValue = obtenerValor(18, 3, 2);
            cbo19.SelectedValue = obtenerValor(19, 3, 2);
            cbo20.SelectedValue = obtenerValor(20, 3, 2);
            cbo21.SelectedValue = obtenerValor(21, 3, 2);
            cbo22.SelectedValue = obtenerValor(22, 3, 2);
            cbo23.SelectedValue = obtenerValor(24, 3, 2);
            tbObservaciones.Text = obtenerValor(23, 3, 1).ToString();
            antCli.Text = obtenerValor(27, 3, 1).ToString();
            antQui.Text = obtenerValor(28, 3, 1).ToString();
            antTrau.Text = obtenerValor(29,3, 1).ToString();

        }

        private object obtenerValor(int posicion, int column, int modo)
        {
            DataRow[] r = valoresExamen.Select("codigo = '" + posicion + "'");
            if (r.Length > 0)
            {
                return r[0][column];
            }
            if (modo == 1)
            {
                return "";
            }
            return -1;
        }

        public void llenarComboBoxs()
        {
            llenarCombo(cbo1, "1");
            llenarCombo(cbo2, "2");
            llenarCombo(cbo3, "3");
            llenarCombo(cbo4, "4");
            llenarCombo(cbo5, "5");
            llenarCombo(cbo9, "9");
            llenarCombo(cbo10, "10");
            llenarCombo(cbo11, "11");
            llenarCombo(cbo12, "12");
            llenarCombo(cbo13, "13");
            llenarCombo(cbo14, "14");
            llenarCombo(cbo15, "15");
            llenarCombo(cbo16, "16");
            llenarCombo(cbo17, "17");
            llenarCombo(cbo18, "18");
            llenarCombo(cbo19, "19");
            llenarCombo(cbo20, "20");
            llenarCombo(cbo21, "21");
            llenarCombo(cbo22, "22");
            cargarMedicos();

        }

        private void cargarMedicos()
        {
            DataTable profesional = SQLConnector.obtenerTablaSegunConsultaString(@"select p.id, (convert(varchar(4),p.codigo) 
            + ' - ' + p.apellido + ' ' + p.nombres) as profesional from dbo.Profesional p order by convert(int,p.codigo) asc");
            cbo23.DataSource = profesional;
            cbo23.ValueMember = "id";
            cbo23.DisplayMember = "profesional";
            cbo23.SelectedIndex = -1;
           
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
        private void cbo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo1.SelectedIndex.ToString(), (DataRowView)cbo1.SelectedItem, pb1);
        }

        private void cbo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo2.SelectedIndex.ToString(), (DataRowView)cbo2.SelectedItem, pb2);
        }

        private void cbo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo3.SelectedIndex.ToString(),(DataRowView)cbo3.SelectedItem, pb3);
        }

        private void cbo4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo4.SelectedIndex.ToString(), (DataRowView)cbo4.SelectedItem, pb4);
        }

        private void cbo5_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo5.SelectedIndex.ToString(), (DataRowView)cbo5.SelectedItem, pb5);
        }

        private void cbo9_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo9.SelectedIndex.ToString(), (DataRowView)cbo9.SelectedItem, pb9);
        }

        private void cbo10_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo10.SelectedIndex.ToString(), (DataRowView)cbo10.SelectedItem, pb10);
        }

        private void cbo11_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo11.SelectedIndex.ToString(), (DataRowView)cbo11.SelectedItem, pb11);
        }

        private void cbo12_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo12.SelectedIndex.ToString(), (DataRowView)cbo12.SelectedItem, pb12);
        }

        private void cbo13_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo13.SelectedIndex.ToString(), (DataRowView)cbo13.SelectedItem, pb13);
            pyf = cbo13.SelectedIndex;
        }

        private void cbo14_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo14.SelectedIndex.ToString(), (DataRowView)cbo14.SelectedItem, pb14);
            apLoc = cbo14.SelectedIndex;
        }

        private void cbo15_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo15.SelectedIndex.ToString(), (DataRowView)cbo15.SelectedItem, pb15);
        }

        private void cbo16_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo16.SelectedIndex.ToString(), (DataRowView)cbo16.SelectedItem, pb16);
            ojoD = cbo16.SelectedIndex;
        }

        private void cbo17_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo17.SelectedIndex.ToString(), (DataRowView)cbo17.SelectedItem, pb17);
            lentOjoD = cbo17.SelectedIndex;
        }

        private void cbo18_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo18.SelectedIndex.ToString(), (DataRowView)cbo18.SelectedItem, pb18);
            ojoI = cbo18.SelectedIndex;
        }

        private void cbo19_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo19.SelectedIndex.ToString(), (DataRowView)cbo19.SelectedItem, pb19);
            lentOjoI = cbo19.SelectedIndex;
        }

        private void cbo20_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo20.SelectedIndex.ToString(), (DataRowView)cbo20.SelectedItem, pb20);
        }

        private void cbo21_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo21.SelectedIndex.ToString(), (DataRowView)cbo21.SelectedItem, pb21);
        }

        private void cbo22_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarIcono(cbo22.SelectedIndex.ToString(), (DataRowView)cbo22.SelectedItem, pb22);
            ind = cbo22.SelectedIndex;
        }
     

        private void tbPeso_Leave(object sender, EventArgs e)
        {
            calcularPeso();
        }

        private void calcularPeso()
        {
            if (tbPeso.Text != "" && tbTalla.Text != "" && tbPeso.Text != "0" && tbTalla.Text != "0")
            {
                reemplazarCaracter(tbPeso, '.', ',');
                decimal medida = Convert.ToDecimal(tbTalla.Text);
                decimal peso = Convert.ToDecimal(tbPeso.Text);
                decimal IMC = decimal.Round((peso / (medida * medida)), 2);
                tb1.Text = IMC.ToString();
            }
            else
            {
                tb1.Clear();
                tbPeso.Clear();
                tbTalla.Clear();
            }
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
                    if (Convert.ToDouble(tb.Text) >= Convert.ToDouble(row.ItemArray[1].ToString())
                        && Convert.ToDouble(tb.Text) <= Convert.ToDouble(row.ItemArray[2].ToString()))
                    {
                        byte[] imageBuffer = (byte[])row.ItemArray[3];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.Image = Image.FromStream(ms);
                        encontro = true;
                    }
                }
                if (!encontro) { pb.Image = null; MessageBox.Show("Valor no encontrado dentro del rango definido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else
            {
                pb.Image = null;
            }
          
        }

        private void tb6_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb6, "6", pb6);
        }

        private void tb7_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb7, "7", pb7);
        }

        private void tb8_Leave(object sender, EventArgs e)
        {
            comprobarValidacionRango(tb8, "8", pb8);
        }

        private void butAceptar_Click(object sender, EventArgs e)
        {
            guardarExamen();
        }

        private void guardarExamen()
        {
            if (validarIngreso())
            {
                guardar();
                this.Close();
                if (frmExamen != null)
                {
                    frmExamen.actualizarExamenes();
                }
                else if (frmPac != null)
                {
                    frmPac.cargarExamenes();
                }
            }
            else
            {
                MessageBox.Show("¡Faltan ingresar campos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

 

        private bool validarIngreso()
        {
            if ((textBoxValido(tbPeso) && textBoxValido(tbTalla) && indexActualValido(cbo1)
                && indexActualValido(cbo2) && indexActualValido(cbo3) && indexActualValido(cbo4)
                && indexActualValido(cbo5) && textBoxValido(tb6) && textBoxValido(tb7)
                && textBoxValido(tb8) && indexActualValido(cbo9) && indexActualValido(cbo10)
                && indexActualValido(cbo11) && indexActualValido(cbo12) && indexActualValido(cbo13)
                && indexActualValido(cbo14) && indexActualValido(cbo15) && indexActualValido(cbo16)
                && indexActualValido(cbo17) && indexActualValido(cbo18) && indexActualValido(cbo19)
                && indexActualValido(cbo20) && indexActualValido(cbo21) && indexActualValido(cbo22)
                && indexActualValido(cbo23)) || cbo22.SelectedIndex == 4) { return true; }
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

        private void butCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void tb6_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb7_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tb8_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            numerosYPuntos(e);
        }

        private void tbPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            numerosYPuntos(e);
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
            if (!((char.IsDigit(e.KeyChar)) || (e.KeyChar == (char)Keys.Back) || e.KeyChar == (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void tbTalla_Leave(object sender, EventArgs e)
        {
            reemplazarCaracter(tbTalla, '.', ',');
        }

        private void reemplazarCaracter(TextBox tb, char viejo, char nuevo)
        {
            string text = tb.Text;
            tb.Text = text.Replace(viejo, nuevo);

        }

        private void tbTalla_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tbTalla);
        }

        private void tbPeso_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tbPeso);
        }

        private void tb6_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb6);
        }

        private void tb7_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb7);
        }

        private void tb8_Enter(object sender, EventArgs e)
        {
            seleccionarTexto(tb8);
        }

        private void seleccionarTexto(TextBox tb)
        {
            if (tb.Text.Length > 0)
            {
                tb.SelectionStart = 0;
                tb.SelectionLength = tb.Text.Length;
            }
        }

        private void guardar()
        {
            Entidades.Resultado result = preventiva.guardarExClinico(cargarEntidad());
            if (result.Modo == -1)
            {
                MessageBox.Show("No se puede guardar el exámen clinico.\nError: " + result.Mensaje, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmExamenFisico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.ToString() == "27")
            {

                this.Close();
            }

            if (e.KeyCode == Keys.F5 && butAceptar.Visible)
            {
                butAceptar.PerformClick();
            }
            else if (e.KeyCode == Keys.F10 && butCancelar.Visible)
            {
                butCancelar.PerformClick();
            }        
        }

        private Entidades.ExamenPreventiva cargarEntidad()
        {
            Entidades.ExamenPreventiva examen = new Entidades.ExamenPreventiva();
            examen.IdTipoExamen = new Guid(tbId.Text);
            examen.AntCli = antCli.Text;
            examen.AntQui = antQui.Text;
            examen.AntTrau = antTrau.Text;
            examen.Talla = tbTalla.Text;
            examen.Peso = tbPeso.Text;
            if (cbo1.SelectedIndex != -1) { examen.Biotipo = Convert.ToInt16(cbo1.SelectedValue); }
            if (cbo2.SelectedIndex != -1) { examen.EntAire = Convert.ToInt16(cbo2.SelectedValue); }
            if (cbo3.SelectedIndex != -1) { examen.RuiAgre = Convert.ToInt16(cbo3.SelectedValue); }
            if (cbo4.SelectedIndex != -1) { examen.RuiCard = Convert.ToInt16(cbo4.SelectedValue); }
            if (cbo5.SelectedIndex != -1) { examen.Silencios = Convert.ToInt16(cbo5.SelectedValue); }
            if (tb6.Text != string.Empty) { examen.TaMax = Convert.ToInt16(tb6.Text); }
            if (tb7.Text != string.Empty) { examen.TaMin = Convert.ToInt16(tb7.Text); }
            if (tb8.Text != string.Empty) { examen.Pulso = Convert.ToInt16(tb8.Text); }
            if (cbo9.SelectedIndex != -1) { examen.Abdomen = Convert.ToInt16(cbo9.SelectedValue); }
            if (cbo10.SelectedIndex != -1) { examen.Hernias = Convert.ToInt16(cbo10.SelectedValue); }
            if (cbo11.SelectedIndex != -1) { examen.Varices = Convert.ToInt16(cbo11.SelectedValue); }
            if (cbo12.SelectedIndex != -1) { examen.ApGenitour = Convert.ToInt16(cbo12.SelectedValue); }
            if (cbo13.SelectedIndex != -1) { examen.PielYFaneras = Convert.ToInt16(cbo13.SelectedValue); }
            if (cbo14.SelectedIndex != -1) { examen.ApLocomotor = Convert.ToInt16(cbo14.SelectedValue); }
            if (cbo15.SelectedIndex != -1) { examen.Snc = Convert.ToInt16(cbo15.SelectedValue); }
            if (cbo16.SelectedIndex != -1) { examen.OjoDer = Convert.ToInt16(cbo16.SelectedValue); }
            if (cbo17.SelectedIndex != -1) { examen.OjoDerLent = Convert.ToInt16(cbo17.SelectedValue); }
            if (cbo18.SelectedIndex != -1) { examen.OjoIzq = Convert.ToInt16(cbo18.SelectedValue); }
            if (cbo19.SelectedIndex != -1) { examen.OjoIzqLent = Convert.ToInt16(cbo19.SelectedValue); }
            if (cbo20.SelectedIndex != -1) { examen.VisionCromatica = Convert.ToInt16(cbo20.SelectedValue); }
            if (cbo21.SelectedIndex != -1) { examen.Odonto = Convert.ToInt16(cbo21.SelectedValue); }
            examen.ObsFisico = tbObservaciones.Text;
            if (cbo22.SelectedIndex != -1) { examen.DictFisico = Convert.ToInt16(cbo22.SelectedValue); }
            if (cbo23.SelectedIndex != -1) { examen.Medico = new Guid(cbo23.SelectedValue.ToString()); }
            return examen;
        }

 

     

 



    }
}
