using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaNegocioMepryl;
using Entidades;
using Comunes;
using System.IO;

namespace CapaPresentacion
{
    public partial class frmExamenLaboral : DevExpress.XtraEditors.XtraForm
    {
        public delegate void DelegateRefreshHistoriaClinica();
        public DelegateRefreshHistoriaClinica objDelegateRefreshHistoria = null;

        private string idConsulta;
        private string idEmpresa;
        private string idTipoExamen;
        private CapaNegocioMepryl.Examen examenLaboral;
        private string idExamenLaboral;
        private bool puntosHabilitados;
        private bool EsComplementario = false;
        private Dictionary<string, bool> EstudioComplementario = new Dictionary<string, bool>();

        private List<Panel> panelesPlacas;
        private List<Label> labelsPlacas;
        private List<TextBox> textBoxsPlacas;
        private List<TextBox> textBoxsPlacasId;

        private List<Panel> panelesEC;
        private List<Label> labelsEC;
        private List<TextBox> textBoxsEC;
        private List<TextBox> textBoxsECId;
        private List<Button> btnBotonEC; // GRV Modificado 18/03/2018

        private List<Label> labelsUsados = new List<Label>();
        private List<TextBox> textBoxsUsados = new List<TextBox>();
        private List<TextBox> textBoxsIdUsados = new List<TextBox>();

        private frmBusquedaLaboral frmBusquedaLaboral;
        private string strIDPaciente = "", strIDEmpresa = "";

        private string strDiagnosticoAudiometria = "";
        private string strNombrePaciente = "";
        private string strApellidoPaciente = "";
        decimal medida;
        decimal peso;
        decimal IMC;



        public frmExamenLaboral(frmBusquedaLaboral frm)
        {
            InitializeComponent();
            examenLaboral = new Examen();
            frmBusquedaLaboral = frm;
        }

        public frmExamenLaboral(frmBusquedaLaboral frm, bool PuedeModificar)
        {
            InitializeComponent();
            examenLaboral = new Examen();
            frmBusquedaLaboral = frm;

            ModoPermisos(PuedeModificar);
        }

        public frmExamenLaboral()
        {
            InitializeComponent();
            examenLaboral = new Examen();
            tabPageLab.AutoScroll = true;
        }

        public void setearLabelTitulo(string texto)
        {
            lbTitulo.Text = texto;
        }

        public void setearValores(string idConsultaLaboral, string empresa, string tarea, string paciente, string fecha, string examen,
            string identificador, string dni, string idExamen)
        {
            idConsulta = idConsultaLaboral;
            tbEmpresa.Text = empresa;
            tbTarea.Text = tarea;
            tbPaciente.Text = paciente;
            tbFecha.Text = fecha;
            tbExamen.Text = examen;
            lblIdentificador.Text = identificador;
            tbDni.Text = dni;
            cargarImagen(@"S:\\FOTOS\\" + dni + ".jpg");
            idExamenLaboral = idExamen;
            inicializarFormulario();
            cargarExamen();
            tbAntCli.Focus();
        }

        public void setearValores(string idConsultaLaboral, string empresa, string tarea, string paciente, string fecha, string examen,
    string identificador, string dni, string idExamen, string idEmp)
        {
            idConsulta = idConsultaLaboral;
            idEmpresa = idEmp;
            tbEmpresa.Text = empresa;
            tbTarea.Text = tarea;
            tbPaciente.Text = paciente;
            tbFecha.Text = fecha;
            tbExamen.Text = examen;
            lblIdentificador.Text = identificador;
            tbDni.Text = dni;
            cargarImagen(@"S:\\FOTOS\\" + dni + ".jpg");
            idExamenLaboral = idExamen;
            inicializarFormulario();
            cargarExamen();
            tbAntCli.Focus();
        }

        public void setearValoresEstudioComplementario(string _idTipoExamen, string idEmp)
        {
            EsComplementario = true;
            idTipoExamen = _idTipoExamen;
            crearRelacionYExamen();
            idConsulta = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT id FROM dbo.ConsultaLaboral where idTipoExamen = '" + idTipoExamen + "'").Rows[0][0].ToString();
            idEmpresa = idEmp;
            tbEmpresa.Text = SQLConnector.obtenerTablaSegunConsultaString("SELECT e.razonSocial FROM dbo.empresaPorTipoDeExamen ete inner join dbo.Empresa e on ete.idEmpresa = e.id where ete.idTipoExamen = '" + idTipoExamen + "'").Rows[0][0].ToString();
            tbTarea.Text = SQLConnector.obtenerTablaSegunConsultaString("SELECT ete.tarea FROM dbo.empresaPorTipoDeExamen ete where ete.idTipoExamen = '" + idTipoExamen + "'").Rows[0][0].ToString(); ;
            tbPaciente.Text = SQLConnector.obtenerTablaSegunConsultaString("select CONCAT(pl.apellido,',',pl.nombres) FROM dbo.TipoExamenDePaciente tep inner join dbo.Consulta c on tep.idConsulta = c.id inner join dbo.PacienteLaboral pl on c.pacienteID = pl.id where tep.id = '" + idTipoExamen + "'").Rows[0][0].ToString();
            tbFecha.Text = Convert.ToDateTime(SQLConnector.obtenerTablaSegunConsultaString("select c.fecha FROM dbo.TipoExamenDePaciente tep inner join dbo.Consulta c on tep.idConsulta = c.id where tep.id = '" + idTipoExamen + "'").Rows[0][0].ToString()).ToShortDateString();
            tbExamen.Text = "ESTUDIOS COMPLEMENTARIOS";
            lblIdentificador.Text = SQLConnector.obtenerTablaSegunConsultaString("select c.identificador FROM dbo.TipoExamenDePaciente tep inner join dbo.Consulta c on tep.idConsulta = c.id where tep.id = '" + idTipoExamen + "'").Rows[0][0].ToString();
            tbDni.Text = SQLConnector.obtenerTablaSegunConsultaString("select pl.dni FROM dbo.TipoExamenDePaciente tep inner join dbo.Consulta c on tep.idConsulta = c.id inner join dbo.PacienteLaboral pl on c.pacienteID = pl.id where tep.id = '" + idTipoExamen + "'").Rows[0][0].ToString();
            cargarImagen(@"S:\\FOTOS\\" + tbDni.Text + ".jpg");
            idExamenLaboral = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT idExamenLaboral from dbo.ConsultaLaboral where idTipoExamen = '" + idTipoExamen + "'").Rows[0][0].ToString();
            crearExamenLaboral();
            inicializarFormularioEC();
            ModoEC();
            cargarExamen();
            //tbAntCli.Focus();
        }


        private void crearExamenLaboral()
        {
            if (SQLConnector.obtenerTablaSegunConsultaString("Select * FROM dbo.ExamenLaboral where id = '" + idExamenLaboral + "'").Rows.Count == 0)
            {
                DataTable dt = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT idExamenLaboral FROM dbo.ConsultaLaboral where idTipoExamen = '" + idTipoExamen + "'");
                if (dt.Rows.Count > 0)
                {
                    string a = dt.Rows[0][0].ToString();
                    SQLConnector.obtenerTablaSegunConsultaString(@"Insert into dbo.ExamenLaboral (id) Values ('" + a + "')");
                }
            }
        }

        private void crearRelacionYExamen()
        {
            if (SQLConnector.obtenerTablaSegunConsultaString("Select * FROM dbo.ConsultaLaboral where idTipoExamen = '" + idTipoExamen + "'").Rows.Count == 0)
            {
                SQLConnector.obtenerTablaSegunConsultaString(@"Insert into dbo.ConsultaLaboral (id,idTipoExamen,tipo,idExamenLaboral)
                Values (NEWID(),'" + idTipoExamen + "',1,NEWID())");
            }
        }

        private void ModoEC()
        {
            DataTable Cli = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT [item1]
            FROM dbo.EstudiosPorExamen
            where idTipoExamen = '" + idTipoExamen + "'");
            if (Cli.Rows[0][0].ToString() == "True")
            {
                EstudioComplementario.Add("Clinico", true);
            }
            else
            {
                EstudioComplementario.Add("Clinico", false);
            }

            bool hayLab = false;
            DataTable Lab = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16, item17, item18, item19, item20, item21, item22, item23, item24, item25, item26, item27, item28, item29, item30, item31, item32, item33, item34, item35, item36, item37
            FROM dbo.EstudiosPorExamen
            where idTipoExamen = '" + idTipoExamen + "'");
            foreach (DataColumn dr in Lab.Columns)
            {
                if (Lab.Rows[0][dr].ToString() == "True")
                {
                    hayLab = true;
                }
            }
            if (hayLab)
            {
                EstudioComplementario.Add("Lab", true);
            }
            else
            {
                EstudioComplementario.Add("Lab", false);
            }

            bool hayRX = false;
            DataTable RX = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT [item38]
            ,[item39]
            ,[item40]
            ,[item41]
            ,[item42]
            ,[item43]
            ,[item44]
            ,[item45]
            ,[item46]
            ,[item47]
            ,[item48]
            ,[item49]
            ,[item50]
            ,[item51]
            ,[item52]
            ,[item53]
            ,[item54]
            ,[item55]
            ,[item56]
            ,[item57]
            ,[item58]
            ,[item59]
            ,[item60]
            ,[item61]
            ,[item62]
            ,[item63]
            ,[item64]
            ,[item65]
            ,[item66]
            ,[item67]
            ,item79
            FROM dbo.EstudiosPorExamen
            where idTipoExamen = '" + idTipoExamen + "'");
            foreach (DataColumn dr in RX.Columns)
            {
                if (RX.Rows[0][dr].ToString() == "True")
                {
                    hayRX = true;
                }
            }
            if (hayRX)
            {
                EstudioComplementario.Add("RX", true);
            }
            else
            {
                EstudioComplementario.Add("RX", false);
            }

            bool hayEC = false;
            DataTable EC = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT item68 ,item70 ,item71 ,item72 ,item73 ,item74 ,item75 ,item76 ,item77 ,item78
            FROM dbo.EstudiosPorExamen
            where idTipoExamen = '" + idTipoExamen + "'");
            foreach (DataColumn dr in EC.Columns)
            {
                if (EC.Rows[0][dr].ToString() == "True")
                {
                    hayEC = true;
                }
            }
            if (hayEC)
            {
                EstudioComplementario.Add("EC", true);
            }
            else
            {
                EstudioComplementario.Add("EC", false);
            }

            foreach (string item in EstudioComplementario.Keys)
            {
                if (item == "EC" && EstudioComplementario[item])
                {
                    tabControl1.SelectedIndex = 3;
                }
                if (item == "RX" && EstudioComplementario[item])
                {
                    tabControl1.SelectedIndex = 2;
                }
                if (item == "Lab" && EstudioComplementario[item])
                {
                    tabControl1.SelectedIndex = 1;
                }
                if (EstudioComplementario["Clinico"])
                {
                    tabControl1.SelectedIndex = 0;
                }
            }
        }

        private void inicializarFormularioEC()
        {

            labelsUsados.Clear();
            textBoxsUsados.Clear();
            textBoxsIdUsados.Clear();

            cboMedico.DataSource = examenLaboral.cargarProfesionales();
            cboMedico.ValueMember = "id";
            cboMedico.DisplayMember = "descripcion";
            cboMedico.SelectedIndex = -1;

            cboDictamenFinal.DataSource = examenLaboral.cargarDictamenes();
            cboDictamenFinal.ValueMember = "id";
            cboDictamenFinal.DisplayMember = "descripcion";
            cboDictamenFinal.SelectedIndex = 0;


            cboDictClinico.DataSource = examenLaboral.cargarDictamenes();
            cboDictClinico.ValueMember = "id";
            cboDictClinico.DisplayMember = "descripcion";
            cboDictClinico.SelectedIndex = 0;

            panelesPlacas = new List<Panel>();
            labelsPlacas = new List<Label>();
            textBoxsPlacas = new List<TextBox>();
            textBoxsPlacasId = new List<TextBox>();

            panelesEC = new List<Panel>();
            labelsEC = new List<Label>();
            textBoxsEC = new List<TextBox>();
            textBoxsECId = new List<TextBox>();
            btnBotonEC = new List<Button>();

            List<ToolStripButton> lClinico = new List<ToolStripButton>();
            lClinico.Add(botCli);

            List<ToolStripButton> lLab = new List<ToolStripButton>();
            lLab.Add(botLab);

            List<ToolStripButton> lRx = new List<ToolStripButton>();
            lRx.Add(botRx);

            List<ToolStripButton> lEC = new List<ToolStripButton>();
            lEC.Add(botECG);
            lEC.Add(botAudio);
            lEC.Add(botEco);
            lEC.Add(botElectro);
            lEC.Add(botErgo);
            lEC.Add(botEspiro);
            lEC.Add(botFondo);
            lEC.Add(botITorg);
            lEC.Add(botPsico);


            DataTable itemsPorExamen = examenLaboral.consultarItemsPorExamen(idConsulta);
            cambiarVisibilidadBoton(itemsPorExamen, botCli, "id = 1");
            cambiarVisibilidadBoton(itemsPorExamen, botLab, @"ordenFormulario = 2 or ordenFormulario = 3" +
            " or ordenFormulario = 4 or ordenFormulario = 5 or ordenFormulario = 6 or ordenFormulario = 7");
            cambiarVisibilidadBoton(itemsPorExamen, botRx, @"ordenFormulario = 8 or ordenFormulario = 9" +
            " or ordenFormulario = 10 or ordenFormulario = 11");
            cambiarVisibilidadBoton(itemsPorExamen, botECG, "id = 78");
            cambiarVisibilidadBoton(itemsPorExamen, botAudio, "id = 68");
            cambiarVisibilidadBoton(itemsPorExamen, botEco, "id = 72");
            cambiarVisibilidadBoton(itemsPorExamen, botElectro, "id = 76");
            cambiarVisibilidadBoton(itemsPorExamen, botErgo, "id = 70");
            cambiarVisibilidadBoton(itemsPorExamen, botEspiro, "id = 75");
            cambiarVisibilidadBoton(itemsPorExamen, botFondo, "id = 3");
            cambiarVisibilidadBoton(itemsPorExamen, botITorg, "id = 77");
            cambiarVisibilidadBoton(itemsPorExamen, botPsico, "id = 73");

            cambiarVisibilidadTextBox(itemsPorExamen, tbEritro, "id = 5");
            cambiarVisibilidadTextBox(itemsPorExamen, tbPlaquetas, "id = 8");

            cambiarVisibilidadTextBox(itemsPorExamen, tbGlucemia, "id = 9");
            cambiarVisibilidadTextBox(itemsPorExamen, tbUremia, "id = 10");
            cambiarVisibilidadTextBox(itemsPorExamen, tbChagas, "id = 22");
            cambiarVisibilidadTextBox(itemsPorExamen, tbVdrl, "id = 23");
            cambiarVisibilidadComboBox(itemsPorExamen, cboGrupo, "id = 6");
            cambiarVisibilidadComboBox(itemsPorExamen, cboFactor, "id = 6");
            cambiarVisibilidadTextBox(itemsPorExamen, tbUricemia, "id = 21");
            cambiarVisibilidadTextBox(itemsPorExamen, tbTe, "id = 28");

            cambiarVisibilidadTextBox(itemsPorExamen, tbColTotal, "id = 30");
            cambiarVisibilidadTextBox(itemsPorExamen, tbHdl, "id = 32");
            cambiarVisibilidadTextBox(itemsPorExamen, tbLdl, "id = 31");
            cambiarVisibilidadTextBox(itemsPorExamen, tbTriglic, "id = 33");

            cambiarVisibilidadTextBox(itemsPorExamen, tbColor, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbAspecto, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbDensidad, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbPh, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbCelulas, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbLeuco, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbHematies, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbProteinas, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbGlucosa, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbHemglobOrina, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbCetonas, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbBilirrubina, "id = 37");

            cambiarVisibilidadTextBox(itemsPorExamen, tbEquil, "id = 69");

            cambiarVisibilidadPlacas(itemsPorExamen);
            cambiarVisibilidadEstudiosComplementarios(itemsPorExamen);

            /*cambiarVisibilidadTabPage(lClinico, tabPageCli);
            cambiarVisibilidadTabPage(lLab, tabPageLab);
            cambiarVisibilidadTabPage(lRx, tabPageRx);
            cambiarVisibilidadTabPage(lEC, tabPageEC);*/

            actualizarTabPageFinal();



        }

        private void inicializarFormulario()
        {

            labelsUsados.Clear();
            textBoxsUsados.Clear();
            textBoxsIdUsados.Clear();

            cboMedico.DataSource = examenLaboral.cargarProfesionales();
            cboMedico.ValueMember = "id";
            cboMedico.DisplayMember = "descripcion";
            cboMedico.SelectedIndex = -1;

            cboDictamenFinal.DataSource = examenLaboral.cargarDictamenes();
            cboDictamenFinal.ValueMember = "id";
            cboDictamenFinal.DisplayMember = "descripcion";
            cboDictamenFinal.SelectedIndex = 0;


            cboDictClinico.DataSource = examenLaboral.cargarDictamenes();
            cboDictClinico.ValueMember = "id";
            cboDictClinico.DisplayMember = "descripcion";
            cboDictClinico.SelectedIndex = 0;

            panelesPlacas = new List<Panel>();
            labelsPlacas = new List<Label>();
            textBoxsPlacas = new List<TextBox>();
            textBoxsPlacasId = new List<TextBox>();

            panelesEC = new List<Panel>();
            labelsEC = new List<Label>();
            textBoxsEC = new List<TextBox>();
            textBoxsECId = new List<TextBox>();
            btnBotonEC = new List<Button>();

            List<ToolStripButton> lClinico = new List<ToolStripButton>();
            lClinico.Add(botCli);

            List<ToolStripButton> lLab = new List<ToolStripButton>();
            lLab.Add(botLab);

            List<ToolStripButton> lRx = new List<ToolStripButton>();
            lRx.Add(botRx);

            List<ToolStripButton> lEC = new List<ToolStripButton>();
            lEC.Add(botECG);
            lEC.Add(botAudio);
            lEC.Add(botEco);
            lEC.Add(botElectro);
            lEC.Add(botErgo);
            lEC.Add(botEspiro);
            lEC.Add(botFondo);
            lEC.Add(botITorg);
            lEC.Add(botPsico);


            DataTable itemsPorExamen = examenLaboral.consultarItemsPorExamen(idConsulta);
            cambiarVisibilidadBoton(itemsPorExamen, botCli, "id = 1");
            cambiarVisibilidadBoton(itemsPorExamen, botLab, @"ordenFormulario = 2 or ordenFormulario = 3" +
            " or ordenFormulario = 4 or ordenFormulario = 5 or ordenFormulario = 6 or ordenFormulario = 7");
            cambiarVisibilidadBoton(itemsPorExamen, botRx, @"ordenFormulario = 8 or ordenFormulario = 9" +
            " or ordenFormulario = 10 or ordenFormulario = 11");
            cambiarVisibilidadBoton(itemsPorExamen, botECG, "id = 78");
            cambiarVisibilidadBoton(itemsPorExamen, botAudio, "id = 68");
            cambiarVisibilidadBoton(itemsPorExamen, botEco, "id = 72");
            cambiarVisibilidadBoton(itemsPorExamen, botElectro, "id = 76");
            cambiarVisibilidadBoton(itemsPorExamen, botErgo, "id = 70");
            cambiarVisibilidadBoton(itemsPorExamen, botEspiro, "id = 75");
            cambiarVisibilidadBoton(itemsPorExamen, botFondo, "id = 3");
            cambiarVisibilidadBoton(itemsPorExamen, botITorg, "id = 77");
            cambiarVisibilidadBoton(itemsPorExamen, botPsico, "id = 73");

            cambiarVisibilidadTextBox(itemsPorExamen, tbEritro, "id = 5");
            cambiarVisibilidadTextBox(itemsPorExamen, tbPlaquetas, "id = 8");

            cambiarVisibilidadTextBox(itemsPorExamen, tbGlucemia, "id = 9");
            cambiarVisibilidadTextBox(itemsPorExamen, tbUremia, "id = 10");
            cambiarVisibilidadTextBox(itemsPorExamen, tbChagas, "id = 22");
            cambiarVisibilidadTextBox(itemsPorExamen, tbVdrl, "id = 23");
            cambiarVisibilidadComboBox(itemsPorExamen, cboGrupo, "id = 6");
            cambiarVisibilidadComboBox(itemsPorExamen, cboFactor, "id = 6");
            cambiarVisibilidadTextBox(itemsPorExamen, tbUricemia, "id = 21");
            cambiarVisibilidadTextBox(itemsPorExamen, tbTe, "id = 28");

            cambiarVisibilidadTextBox(itemsPorExamen, tbColTotal, "id = 30");
            cambiarVisibilidadTextBox(itemsPorExamen, tbHdl, "id = 32");
            cambiarVisibilidadTextBox(itemsPorExamen, tbLdl, "id = 31");
            cambiarVisibilidadTextBox(itemsPorExamen, tbTriglic, "id = 33");

            cambiarVisibilidadTextBox(itemsPorExamen, tbColor, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbAspecto, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbDensidad, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbPh, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbCelulas, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbLeuco, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbHematies, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbProteinas, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbGlucosa, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbHemglobOrina, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbCetonas, "id = 37");
            cambiarVisibilidadTextBox(itemsPorExamen, tbBilirrubina, "id = 37");

            cambiarVisibilidadTextBox(itemsPorExamen, tbEquil, "id = 69");

            cambiarVisibilidadPlacas(itemsPorExamen);
            cambiarVisibilidadEstudiosComplementarios(itemsPorExamen);

            cambiarVisibilidadTabPage(lClinico, tabPageCli);
            cambiarVisibilidadTabPage(lLab, tabPageLab);
            cambiarVisibilidadTabPage(lRx, tabPageRx);
            cambiarVisibilidadTabPage(lEC, tabPageEC);

            actualizarTabPageFinal();



        }

        private void cambiarVisibilidadBoton(DataTable items, ToolStripButton button, string filtro)
        {
            button.Visible = false;
            DataRow[] r = items.Select(filtro);
            if (r.Length > 0)
            {
                button.Visible = true;
            }
            return;
        }

        private void actualizarTabPageFinal()
        {

            List<Panel> panelesDictFinal = new List<Panel>();
            panelesDictFinal.Add(panelDictFinal1);
            panelesDictFinal.Add(panelDictFinal2);
            panelesDictFinal.Add(panelDictFinal3);
            panelesDictFinal.Add(panelDictFinal4);
            panelesDictFinal.Add(panelDictFinal5);
            panelesDictFinal.Add(panelDictFinal6);
            panelesDictFinal.Add(panelDictFinal7);
            panelesDictFinal.Add(panelDictFinal8);
            panelesDictFinal.Add(panelDictFinal9);
            panelesDictFinal.Add(panelDictFinal10);
            panelesDictFinal.Add(panelDictFinal11);
            panelesDictFinal.Add(panelDictFinal12);
            panelesDictFinal.Add(panelDictFinal13);
            panelesDictFinal.Add(panelDictFinal14);
            panelesDictFinal.Add(panelDictFinal15);

            List<Label> labelsDictFinal = new List<Label>();
            labelsDictFinal.Add(lblPanelDictFinal1);
            labelsDictFinal.Add(lblPanelDictFinal2);
            labelsDictFinal.Add(lblPanelDictFinal3);
            labelsDictFinal.Add(lblPanelDictFinal4);
            labelsDictFinal.Add(lblPanelDictFinal5);
            labelsDictFinal.Add(lblPanelDictFinal6);
            labelsDictFinal.Add(lblPanelDictFinal7);
            labelsDictFinal.Add(lblPanelDictFinal8);
            labelsDictFinal.Add(lblPanelDictFinal9);
            labelsDictFinal.Add(lblPanelDictFinal10);
            labelsDictFinal.Add(lblPanelDictFinal11);
            labelsDictFinal.Add(lblPanelDictFinal12);
            labelsDictFinal.Add(lblPanelDictFinal13);
            labelsDictFinal.Add(lblPanelDictFinal14);
            labelsDictFinal.Add(lblPanelDictFinal15);

            List<TextBox> textBoxsDictFinal = new List<TextBox>();
            textBoxsDictFinal.Add(tbPanelDictFinal1);
            textBoxsDictFinal.Add(tbPanelDictFinal2);
            textBoxsDictFinal.Add(tbPanelDictFinal3);
            textBoxsDictFinal.Add(tbPanelDictFinal4);
            textBoxsDictFinal.Add(tbPanelDictFinal5);
            textBoxsDictFinal.Add(tbPanelDictFinal6);
            textBoxsDictFinal.Add(tbPanelDictFinal7);
            textBoxsDictFinal.Add(tbPanelDictFinal8);
            textBoxsDictFinal.Add(tbPanelDictFinal9);
            textBoxsDictFinal.Add(tbPanelDictFinal10);
            textBoxsDictFinal.Add(tbPanelDictFinal11);
            textBoxsDictFinal.Add(tbPanelDictFinal12);
            textBoxsDictFinal.Add(tbPanelDictFinal13);
            textBoxsDictFinal.Add(tbPanelDictFinal14);
            textBoxsDictFinal.Add(tbPanelDictFinal15);


            foreach (Panel panel in panelesDictFinal)
            {
                panel.Visible = false;
            }

            if (botCli.Visible)
            {
                panelesDictFinal[0].Visible = true;
                labelsDictFinal[0].Text = botCli.Text;
                if (cboDictClinico.SelectedItem != null)
                {
                    textBoxsDictFinal[0].Text = ((DataRowView)cboDictClinico.SelectedItem)[1].ToString();
                }
                else
                {
                    textBoxsDictFinal[0].Text = "";
                }
                textBoxsDictFinal.RemoveAt(0);
                panelesDictFinal.RemoveAt(0);
                labelsDictFinal.RemoveAt(0);
            }
            if (botLab.Visible)
            {
                panelesDictFinal[0].Visible = true;
                labelsDictFinal[0].Text = botLab.Text;
                textBoxsDictFinal[0].Text = tbDictLab.Text;
                textBoxsDictFinal.RemoveAt(0);
                panelesDictFinal.RemoveAt(0);
                labelsDictFinal.RemoveAt(0);
            }
            foreach (Label label in labelsUsados)
            {
                if (labelsDictFinal.Count > 0)
                {
                    labelsDictFinal[0].Text = label.Text;
                    labelsDictFinal.RemoveAt(0);
                    panelesDictFinal[0].Visible = true;
                    panelesDictFinal.RemoveAt(0);
                }
            }
            foreach (TextBox tb in textBoxsUsados)
            {
                if (textBoxsDictFinal.Count > 0)
                {
                    textBoxsDictFinal[0].Text = tb.Text;
                    textBoxsDictFinal.RemoveAt(0);
                }
            }





        }
        private void cambiarVisibilidadPlacas(DataTable items)
        {
            panelesPlacas.Add(rxPanel1);
            panelesPlacas.Add(rxPanel2);
            panelesPlacas.Add(rxPanel3);
            panelesPlacas.Add(rxPanel4);
            panelesPlacas.Add(rxPanel5);
            panelesPlacas.Add(rxPanel6);
            panelesPlacas.Add(rxPanel7);
            panelesPlacas.Add(rxPanel8);
            panelesPlacas.Add(rxPanel9);

            labelsPlacas.Add(lblPanelRx1);
            labelsPlacas.Add(lblPanelRx2);
            labelsPlacas.Add(lblPanelRx3);
            labelsPlacas.Add(lblPanelRx4);
            labelsPlacas.Add(lblPanelRx5);
            labelsPlacas.Add(lblPanelRx6);
            labelsPlacas.Add(lblPanelRx7);
            labelsPlacas.Add(lblPanelRx8);
            labelsPlacas.Add(lblPanelRx9);

            textBoxsPlacas.Add(tbPanelRx1);
            textBoxsPlacas.Add(tbPanelRx2);
            textBoxsPlacas.Add(tbPanelRx3);
            textBoxsPlacas.Add(tbPanelRx4);
            textBoxsPlacas.Add(tbPanelRx5);
            textBoxsPlacas.Add(tbPanelRx6);
            textBoxsPlacas.Add(tbPanelRx7);
            textBoxsPlacas.Add(tbPanelRx8);
            textBoxsPlacas.Add(tbPanelRx9);

            textBoxsPlacasId.Add(tbIdPlaca1);
            textBoxsPlacasId.Add(tbIdPlaca2);
            textBoxsPlacasId.Add(tbIdPlaca3);
            textBoxsPlacasId.Add(tbIdPlaca4);
            textBoxsPlacasId.Add(tbIdPlaca5);
            textBoxsPlacasId.Add(tbIdPlaca6);
            textBoxsPlacasId.Add(tbIdPlaca7);
            textBoxsPlacasId.Add(tbIdPlaca8);
            textBoxsPlacasId.Add(tbIdPlaca9);

            foreach (Panel p in panelesPlacas) { p.Visible = false; }
            foreach (TextBox t in textBoxsPlacas) { t.Text = ""; }
            foreach (TextBox t in textBoxsPlacasId) { t.Text = ""; }


            DataRow[] dr = items.Select("ordenFormulario = 8 or ordenFormulario = 9" +
            " or ordenFormulario = 10 or ordenFormulario = 11");
            foreach (DataRow r in dr)
            {
                if (panelesPlacas.Count > 0)
                {
                    panelesPlacas[0].Visible = true;
                    labelsPlacas[0].Text = "RX. " + r[1].ToString();
                    textBoxsPlacasId[0].Text = r.ItemArray[0].ToString();

                    labelsUsados.Add(labelsPlacas[0]);
                    textBoxsUsados.Add(textBoxsPlacas[0]);
                    textBoxsIdUsados.Add(textBoxsPlacasId[0]);

                    panelesPlacas.RemoveAt(0);
                    labelsPlacas.RemoveAt(0);
                    textBoxsPlacas.RemoveAt(0);
                    textBoxsPlacasId.RemoveAt(0);
                }
            }



        }

        private void cambiarVisibilidadEstudiosComplementarios(DataTable items)
        {
            panelesEC.Add(ecPanel1);
            panelesEC.Add(ecPanel2);
            panelesEC.Add(ecPanel3);
            panelesEC.Add(ecPanel4);
            panelesEC.Add(ecPanel5);
            panelesEC.Add(ecPanel6);
            panelesEC.Add(ecPanel7);
            panelesEC.Add(ecPanel8);
            panelesEC.Add(ecPanel9);

            labelsEC.Add(lblPanelEC1);
            labelsEC.Add(lblPanelEC2);
            labelsEC.Add(lblPanelEC3);
            labelsEC.Add(lblPanelEC4);
            labelsEC.Add(lblPanelEC5);
            labelsEC.Add(lblPanelEC6);
            labelsEC.Add(lblPanelEC7);
            labelsEC.Add(lblPanelEC8);
            labelsEC.Add(lblPanelEC9);

            textBoxsEC.Add(tbPanelEc1);
            textBoxsEC.Add(tbPanelEc2);
            textBoxsEC.Add(tbPanelEc3);
            textBoxsEC.Add(tbPanelEc4);
            textBoxsEC.Add(tbPanelEc5);
            textBoxsEC.Add(tbPanelEc6);
            textBoxsEC.Add(tbPanelEc7);
            textBoxsEC.Add(tbPanelEc8);
            textBoxsEC.Add(tbPanelEc9);

            textBoxsECId.Add(tbIdEC1);
            textBoxsECId.Add(tbIdEC2);
            textBoxsECId.Add(tbIdEC3);
            textBoxsECId.Add(tbIdEC4);
            textBoxsECId.Add(tbIdEC5);
            textBoxsECId.Add(tbIdEC6);
            textBoxsECId.Add(tbIdEC7);
            textBoxsECId.Add(tbIdEC8);
            textBoxsECId.Add(tbIdEC9);

            //GRV Modificado - Agrego botones 13/MAR/2018
            btnBotonEC.Add(btnBotonEc1);
            btnBotonEC.Add(btnBotonEc2);
            btnBotonEC.Add(btnBotonEc3);
            btnBotonEC.Add(btnBotonEc4);
            btnBotonEC.Add(btnBotonEc5);
            btnBotonEC.Add(btnBotonEc6);
            btnBotonEC.Add(btnBotonEc7);
            btnBotonEC.Add(btnBotonEc8);
            btnBotonEC.Add(btnBotonEc9);

            foreach (Panel p in panelesEC) { p.Visible = false; }
            foreach (TextBox t in textBoxsEC) { t.Text = ""; }
            foreach (TextBox t in textBoxsECId) { t.Text = ""; }
            foreach (Button B in btnBotonEC) { B.Visible = false; } // GRV - Modificado 13/MAR/2018

            DataRow[] dtr = items.Select("id = 78");
            if (dtr.Length > 0)
            {
                panelesEC[0].Visible = true;
                labelsEC[0].Text = dtr[0][1].ToString();
                textBoxsECId[0].Text = dtr[0][0].ToString();

                labelsUsados.Add(labelsEC[0]);
                textBoxsUsados.Add(textBoxsEC[0]);
                textBoxsIdUsados.Add(textBoxsECId[0]);

                textBoxsEC.RemoveAt(0);
                panelesEC.RemoveAt(0);
                labelsEC.RemoveAt(0);
                textBoxsECId.RemoveAt(0);
                btnBotonEC.RemoveAt(0);
            }

            DataRow[] dr = items.Select("ordenFormulario = 12 and (id <> 74) and (id <> 78)");
            foreach (DataRow r in dr)
            {
                if (panelesEC.Count > 0)
                {
                    panelesEC[0].Visible = true;
                    labelsEC[0].Text = r[1].ToString();
                    textBoxsECId[0].Text = r.ItemArray[0].ToString();

                    if (labelsEC[0].Text == "AUDIOMETRÍA")
                    {
                        btnBotonEC[0].Visible = true;
                        //rDiagnosticoAudiometria = textBoxsEC[0].Text;
                    }

                    labelsUsados.Add(labelsEC[0]);
                    textBoxsUsados.Add(textBoxsEC[0]);
                    textBoxsIdUsados.Add(textBoxsECId[0]);

                    textBoxsEC.RemoveAt(0);
                    panelesEC.RemoveAt(0);
                    labelsEC.RemoveAt(0);
                    textBoxsECId.RemoveAt(0);
                    btnBotonEC.RemoveAt(0);
                }
            }
        }

        private void cambiarVisibilidadComboBox(DataTable items, ComboBox cbo, string filtro)
        {
            cbo.Enabled = false;
            DataRow[] r = items.Select(filtro);
            if (r.Length > 0)
            {
                cbo.Enabled = true;
            }
            return;
        }

        private void cambiarVisibilidadTextBox(DataTable items, TextBox tb, string filtro)
        {
            tb.Enabled = false;
            DataRow[] r = items.Select(filtro);
            if (r.Length > 0)
            {
                tb.Enabled = true;
            }
            return;
        }

        private void cambiarVisibilidadTabPage(List<ToolStripButton> l, TabPage tp)
        {
            /*bool algunoVisible = false;
            foreach (ToolStripButton bt in l)
            {
                if (bt.Visible == true){algunoVisible = true;}
            }
            if (!algunoVisible)
            {
                tabControl1.TabPages.Remove(tp);
            }
            return;*/
        }

        private void botCli_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageCli;
        }

        private void botLab_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageLab;
        }

        private void botRx_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageRx;
        }

        private void botECG_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageEC;
        }

        private void botAudio_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageEC;
        }

        private void botEco_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageEC;
        }

        private void botElectro_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageEC;
        }

        private void botErgo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageEC;
        }

        private void botEspiro_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageEC;
        }

        private void botFondo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageEC;
        }

        private void botITorg_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageEC;
        }

        private void botPsico_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageEC;
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageDictFinal;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabPageDictFinal)
            {
                actualizarTabPageFinal();
                tbObservaciones.Focus();
            }
            else if (tabControl1.SelectedTab == tabPageCli)
            {
                tbAntCli.Focus();
            }
            else if (tabControl1.SelectedTab == tabPageLab)
            {
                tbGRojos.Focus();
            }
            else if (tabControl1.SelectedTab == tabPageRx)
            {
                tbPanelRx1.Focus();
                tbPanelRx1.SelectionStart = 0;
                tbPanelRx1.SelectionLength = tbPanelRx1.Text.Length;
            }
            else if (tabControl1.SelectedTab == tabPageEC)
            {
                tbPanelEc1.Focus();
                tbPanelEc1.SelectionStart = 0;
                tbPanelEc1.SelectionLength = tbPanelEc1.Text.Length;
            }
        }

        private void botFoto_Click(object sender, EventArgs e)
        {

            openFileDialog.FileName = @"Z:\FOTOS";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagen = openFileDialog.FileName;
                cargarImagen(imagen);
            }

        }


        private void cargarImagen(string ruta)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(ruta);
                System.Diagnostics.Debug.WriteLine($"Imagen cargada correctamente: {ruta}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar imagen: {ruta}\n{ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"¡No se encontró la imagen!\n\n{ex.Message}", "Cargar Imágen",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            guardar();
            if (objDelegateRefreshHistoria != null)
            {
                //MessageBox.Show("ENTRO");
                objDelegateRefreshHistoria();
            }
            else if (!EsComplementario)
            {
                frmBusquedaLaboral.actualizar();
            }
            this.Close();
        }

        private void guardar()
        {
            Entidades.ExamenLaboral examen = new Entidades.ExamenLaboral();
            examen.Id = new Guid(idExamenLaboral);
            examen.AntCli = tbAntCli.Text;
            examen.AntTrau = tbAntTrau.Text;
            examen.AntQui = tbAntQui.Text;
            examen.Talla = tbTalla.Text;
            examen.Peso = tbPeso.Text;
            examen.EntradaAire = tbEntAire.Text;
            examen.RuidosAgre = tbRuiAgre.Text;
            examen.RuidosCard = tbRuiCard.Text;
            examen.Silencios = tbSilencios.Text;
            examen.TaMax = tbTAMax.Text;
            examen.TaMin = tbTAMin.Text;
            examen.Pulso = tbPulso.Text;
            examen.Abdomen = tbAbdomen.Text;
            examen.Hernias = tbHernias.Text;
            examen.Varices = tbVarices.Text;
            examen.ApGenitour = tbApGenitour.Text;
            examen.PielYFaneras = tbPielYFaneras.Text;
            examen.ApLocomotor = tbApLocomotor.Text;
            examen.Snc = tbSnc.Text;
            examen.OjoDer = tbOjoDer.Text;
            examen.OjoDerLent = tbOjoDerLent.Text;
            examen.OjoIzq = tbOjoIzq.Text;
            examen.OjoIzqLent = tbOjoIzqLent.Text;
            examen.VisionCromatica = tbVisionCromatica.Text;
            examen.ExOdonto = tbExOdonto.Text;
            examen.Equil = tbEquil.Text;
            examen.ObservacionesCli = tbObservacionesCli.Text;
            if (cboMedico.SelectedIndex != -1)
            {
                examen.Medico = cboMedico.SelectedValue.ToString();
            }
            if (cboDictClinico.SelectedIndex != -1)
            {
                examen.DictamenCli = cboDictClinico.SelectedValue.ToString();
            }
            examen.GRojos = tbGRojos.Text;
            examen.GBlancos = tbGBlancos.Text;
            examen.Hemoglobina = tbHemoglob.Text;
            examen.Hematocrito = tbHemato.Text;
            examen.Eritro = tbEritro.Text;
            examen.Plaquetas = tbPlaquetas.Text;
            examen.ObsSerieRoja = tbObsSerieRoja.Text;
            examen.Cayado = tbCayado.Text;
            examen.Segmentado = tbSegm.Text;
            examen.Eosinof = tbEosinof.Text;
            examen.Basof = tbBasof.Text;
            examen.Linfoc = tbLinfo.Text;
            examen.Monoc = tbMono.Text;
            examen.ObsSerieBlanca = tbObsSerieBlanca.Text;
            examen.Glucemia = tbGlucemia.Text;
            examen.Uremia = tbUremia.Text;
            examen.Chagas = tbChagas.Text;
            examen.Vdrl = tbVdrl.Text;
            if (cboGrupo.SelectedIndex != -1) { examen.Grupo = cboGrupo.Items[cboGrupo.SelectedIndex].ToString(); }
            if (cboFactor.SelectedIndex != -1) { examen.Factor = cboFactor.Items[cboFactor.SelectedIndex].ToString(); }
            examen.Uricemia = tbUricemia.Text;
            examen.Te = tbTe.Text;
            examen.OtrosQuimicaHemat = tbOtrosQuimicaHematica.Text;
            examen.ColTotal = tbColTotal.Text;
            examen.Hdl = tbHdl.Text;
            examen.Ldl = tbLdl.Text;
            examen.Triglic = tbTriglic.Text;
            examen.OtrosPerfilLipidico = tbOtrosPerfilLipidico.Text;
            examen.Color = tbColor.Text;
            examen.Aspecto = tbAspecto.Text;
            examen.Densidad = tbDensidad.Text;
            examen.Ph = tbPh.Text;
            examen.Celulas = tbCelulas.Text;
            examen.Leuco = tbLeuco.Text;
            examen.Hematies = tbHematies.Text;
            examen.Prot = tbProteinas.Text;
            examen.Gluc = tbGlucosa.Text;
            examen.HemogOrina = tbHemglobOrina.Text;
            examen.Cetonas = tbCetonas.Text;
            examen.Bilirrubina = tbBilirrubina.Text;
            examen.OtrosOrina = tbOtrosOrina.Text;
            examen.DictamenLab = tbDictLab.Text;
            examen.ToraxF = obtenerValorTb("38");
            examen.LumbarF = obtenerValorTb("39");
            examen.LumbarP = obtenerValorTb("40");
            examen.CervicalF = obtenerValorTb("41");
            examen.CervicalP = obtenerValorTb("42");
            examen.Fnp = obtenerValorTb("43");
            examen.Mnp = obtenerValorTb("44");
            examen.HombrosF = obtenerValorTb("45");
            examen.RodillasF = obtenerValorTb("46");
            examen.CaderasF = obtenerValorTb("80");
            examen.TobillosF = obtenerValorTb("81");
            examen.CraneoFyP = obtenerValorTb("47");
            examen.HombroF = obtenerValorTb("48");
            examen.HombroVP = obtenerValorTb("49");
            examen.HumeroFyP = obtenerValorTb("50");
            examen.CodoFyP = obtenerValorTb("51");
            examen.AntebrazoFyP = obtenerValorTb("52");
            examen.MunecaFyP = obtenerValorTb("53");
            examen.ManoFyP = obtenerValorTb("54");
            examen.ToraxP = obtenerValorTb("55");
            examen.PCostalFyO = obtenerValorTb("56");
            examen.ColDorsalFyP = obtenerValorTb("57");
            examen.PelvisF = obtenerValorTb("58");
            examen.CaderaF = obtenerValorTb("59");
            examen.CaderaP = obtenerValorTb("60");
            examen.FemurFyP = obtenerValorTb("61");
            examen.RodillaF = obtenerValorTb("62");
            examen.RodillaP = obtenerValorTb("63");
            examen.PiernaFyP = obtenerValorTb("64");
            examen.TobilloFyP = obtenerValorTb("65");
            examen.AxialDeCalcaneo = obtenerValorTb("66");
            examen.PieFyP = obtenerValorTb("67");
            examen.Audio = obtenerValorTb("68");
            examen.Ergo = obtenerValorTb("70");
            examen.Eco = obtenerValorTb("72");
            examen.Psico = obtenerValorTb("73");
            examen.Espiro = obtenerValorTb("75");
            examen.Eeg = obtenerValorTb("76");
            examen.ITorg = obtenerValorTb("77");
            examen.Ecg = obtenerValorTb("78");
            examen.Observaciones = tbObservaciones.Text;
            examen.ObservacionesLab = txtObservacionesLaboratorio.Text;

            examen.Na = tbNa.Text;
            examen.K = tbK.Text;
            examen.ProtTotales = tbProtTotal.Text;
            examen.Albumina = tbAlbumina.Text;
            examen.ALFA1 = tbAlfa1.Text;
            examen.ALFA2 = tbAlfa2.Text;
            examen.BETA1 = tbBeta1.Text;
            examen.BETA2 = tbBeta2.Text;
            examen.Gammaglob = tbGammaglob.Text;
            examen.RelacAlbGlob = tbRelAlbGlob.Text;
            examen.Creat = tbCreatininemia.Text;

            if (cboDictamenFinal.SelectedIndex != -1)
            {
                examen.Dictamen = cboDictamenFinal.SelectedValue.ToString();
            }

            Entidades.Resultado resultado = examenLaboral.guardarExamen(examen);
            if (resultado.Modo == -1)
            {
                MessageBox.Show("Error al guardar el exámen:\n" + resultado.Mensaje, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private string obtenerValorTb(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return "";

            string idTrim = id.Trim();

            // 1) Intento con las listas dinámicas (modo actual)
            if (textBoxsIdUsados != null && textBoxsUsados != null)
            {
                int index = textBoxsIdUsados.FindIndex(x => x != null && !string.IsNullOrEmpty(x.Text) &&
                                                           x.Text.Trim().Equals(idTrim, StringComparison.OrdinalIgnoreCase));
                if (index != -1 && index < textBoxsUsados.Count && textBoxsUsados[index] != null)
                {
                    return textBoxsUsados[index].Text ?? "";
                }
            }

            // 2) Fallback sobre los controles fijos de Rayos X (si existen en el diseñador)
            try
            {
                TextBox[] idControls = new TextBox[] {
            tbIdPlaca1, tbIdPlaca2, tbIdPlaca3, tbIdPlaca4, tbIdPlaca5, tbIdPlaca6, tbIdPlaca7, tbIdPlaca8, tbIdPlaca9
        };

                TextBox[] valueControls = new TextBox[] {
            tbPanelRx1, tbPanelRx2, tbPanelRx3, tbPanelRx4, tbPanelRx5, tbPanelRx6, tbPanelRx7, tbPanelRx8, tbPanelRx9
        };

                for (int i = 0; i < idControls.Length; i++)
                {
                    var idCtrl = idControls[i];
                    if (idCtrl == null) continue;
                    if (!string.IsNullOrEmpty(idCtrl.Text) && idCtrl.Text.Trim().Equals(idTrim, StringComparison.OrdinalIgnoreCase))
                    {
                        var valCtrl = (i < valueControls.Length) ? valueControls[i] : null;
                        if (valCtrl != null) return valCtrl.Text ?? "";
                    }
                }
            }
            catch
            {
                // no hacer nada: si los controles no existen, seguimos y devolvemos ""
            }

            // 3) nada encontrado
            return "";
        }

        private void setearTbSegunId(string id, string valor, string textoBase)
        {
            int index = textBoxsIdUsados.FindIndex(x => x.Text.Equals(id));
            if (index != -1)
            {
                textBoxsUsados[index].Text = valor;
                if (valor == "")
                {
                    textBoxsUsados[index].Text = textoBase;
                }
            }
        }

        private void RecuperarTextoDiagnostico(string id)
        {
            int index = textBoxsIdUsados.FindIndex(x => x.Text.Equals(id));
            if (index != -1)
            {
                strDiagnosticoAudiometria = textBoxsUsados[index].Text;

                if (textBoxsUsados[index].Text == "")
                {
                    //strDiagnosticoAudiometria = "SIN VALOR PATOLOGICO";
                    strDiagnosticoAudiometria = "";
                }
            }
        }

        private void cargarExamen()
        {
            Entidades.ExamenLaboral ex = examenLaboral.cargarExamen(idExamenLaboral);
            if (ex.Id != Guid.Empty) { cargar(ex); }
        }

        private void cargar(Entidades.ExamenLaboral examen)
        {
            puntosHabilitados = false;
            tbAntCli.Text = examen.AntCli;
            if (tbAntCli.Text == "")
            {
                if (lbTitulo.Text != "CASINO")
                {
                    tbAntCli.Text = "NO REFIERE";
                }
                else
                {
                    tbAntCli.Text = "NO EXAMINADO";
                }
            }
            tbAntTrau.Text = examen.AntTrau;
            if (tbAntTrau.Text == "")
            {
                if (lbTitulo.Text != "CASINO")
                {
                    tbAntTrau.Text = "NO REFIERE";
                }
                else
                {
                    tbAntTrau.Text = "NO EXAMINADO";
                }
            }
            tbAntQui.Text = examen.AntQui;
            if (tbAntQui.Text == "")
            {
                if (lbTitulo.Text != "CASINO")
                {
                    tbAntQui.Text = "NO REFIERE";
                }
                else
                {
                    tbAntQui.Text = "NO EXAMINADO";
                }

            }
            tbTalla.Text = examen.Talla;
            tbPeso.Text = examen.Peso;
            tbEntAire.Text = examen.EntradaAire;
            if (tbEntAire.Text == "") { tbEntAire.Text = "SIN PARTICULARIDADES"; }
            tbRuiAgre.Text = examen.RuidosAgre;
            if (tbRuiAgre.Text == "") { tbRuiAgre.Text = "NO SE AUSCULTAN"; }
            tbRuiCard.Text = examen.RuidosCard;
            if (tbRuiCard.Text == "") { tbRuiCard.Text = "2 RUIDOS EN 4 FOCOS"; }
            tbSilencios.Text = examen.Silencios;
            if (tbSilencios.Text == "") { tbSilencios.Text = "NO SE AUSCULTAN SOPLOS"; }
            tbTAMax.Text = examen.TaMax;
            tbTAMin.Text = examen.TaMin;
            tbPulso.Text = examen.Pulso;
            tbAbdomen.Text = examen.Abdomen;
            if (tbAbdomen.Text == "")
            {
                if (lbTitulo.Text != "CASINO")
                {
                    tbAbdomen.Text = "SIN PARTICULARIDADES";
                }
                else
                {
                    tbAbdomen.Text = "NO EXAMINADO";
                }
            }
            tbHernias.Text = examen.Hernias;
            if (tbHernias.Text == "")
            {
                if (lbTitulo.Text != "CASINO")
                {
                    tbHernias.Text = "NO SE PALPAN";
                }
                else
                {
                    tbHernias.Text = "NO EXAMINADO";
                }
            }
            tbVarices.Text = examen.Varices;
            if (tbVarices.Text == "")
            {
                if (lbTitulo.Text != "CASINO")
                {
                    tbVarices.Text = "NO SE OBSERVAN";
                }
                else
                {
                    tbVarices.Text = "NO EXAMINADO";
                }
            }
            tbApGenitour.Text = examen.ApGenitour;
            if (tbApGenitour.Text == "")
            {
                if (lbTitulo.Text != "CASINO")
                {
                    tbApGenitour.Text = "SIN PARTICULARIDADES";
                }
                else
                {
                    tbApGenitour.Text = "NO EXAMINADO";
                }
            }
            tbPielYFaneras.Text = examen.PielYFaneras;
            if (tbPielYFaneras.Text == "")
            {
                if (lbTitulo.Text != "CASINO")
                {
                    tbPielYFaneras.Text = "SIN PARTICULARIDADES";
                }
                else
                {
                    tbPielYFaneras.Text = "NO EXAMINADO";
                }
            }
            tbApLocomotor.Text = examen.ApLocomotor;
            if (tbApLocomotor.Text == "")
            {
                if (lbTitulo.Text != "CASINO")
                {
                    tbApLocomotor.Text = "SIN PARTICULARIDADES";
                }
                else
                {
                    tbApLocomotor.Text = "NO EXAMINADO";
                }
            }
            tbSnc.Text = examen.Snc;
            if (tbSnc.Text == "")
            {
                if (lbTitulo.Text != "CASINO")
                {
                    tbSnc.Text = "SIN PARTICULARIDADES";
                }
                else
                {
                    tbSnc.Text = "NO EXAMINADO";
                }
            }
            tbOjoDer.Text = examen.OjoDer;
            if (tbOjoDer.Text == "") { tbOjoDer.Text = "10/10"; }
            tbOjoDerLent.Text = examen.OjoDerLent;
            tbOjoIzq.Text = examen.OjoIzq;
            if (tbOjoIzq.Text == "") { tbOjoIzq.Text = "10/10"; }
            tbOjoIzqLent.Text = examen.OjoIzqLent;
            tbVisionCromatica.Text = examen.VisionCromatica;
            if (tbVisionCromatica.Text == "") { tbVisionCromatica.Text = "SIN PARTICULARIDADES"; }
            tbExOdonto.Text = examen.ExOdonto;
            if (tbExOdonto.Text == "") { tbExOdonto.Text = "SIN PARTICULARIDADES"; }
            tbEquil.Text = examen.Equil;
            if (tbEquil.Text == "" && tbEquil.Enabled) { tbEquil.Text = "NORMAL"; }
            tbObservacionesCli.Text = examen.ObservacionesCli;
            if (tbObservacionesCli.Text == "" && lbTitulo.Text == "CASINO")
            {
                tbObservacionesCli.Text = "LOS ITEMS NO EXAMINADOS OBEDECEN A EXPRESAS DIRECTIVAS DE LA EMPRESA SOLICITANTE";
            }
            //cboMedico.SelectedValue = examen.Medico;
            cargarMedicos(examen.Medico);
            cboMedico.SelectedValue = examen.Medico;
            if (examen.DictamenCli != "") { cboDictClinico.SelectedValue = examen.DictamenCli; }
            tbGRojos.Text = examen.GRojos;
            tbGBlancos.Text = examen.GBlancos;
            tbHemoglob.Text = examen.Hemoglobina;
            tbHemato.Text = examen.Hematocrito;
            tbEritro.Text = examen.Eritro;
            tbPlaquetas.Text = examen.Plaquetas;
            tbObsSerieRoja.Text = examen.ObsSerieRoja;
            if (tbObsSerieRoja.Text == "") { tbObsSerieRoja.Text = "NORMOCITICA NORMOCRONICA"; }
            tbCayado.Text = examen.Cayado;
            tbSegm.Text = examen.Segmentado;
            tbEosinof.Text = examen.Eosinof;
            tbBasof.Text = examen.Basof;
            tbLinfo.Text = examen.Linfoc;
            tbMono.Text = examen.Monoc;
            tbObsSerieBlanca.Text = examen.ObsSerieBlanca;
            if (tbObsSerieBlanca.Text == "") { tbObsSerieBlanca.Text = "NO SE OBSERVAN ATIPIAS"; }
            tbGlucemia.Text = examen.Glucemia;
            tbUremia.Text = examen.Uremia;
            tbChagas.Text = examen.Chagas;
            tbVdrl.Text = examen.Vdrl;
            if (examen.Grupo != "") { cboGrupo.SelectedItem = examen.Grupo; }
            if (examen.Factor != "") { cboFactor.SelectedItem = examen.Factor; }
            tbUricemia.Text = examen.Uricemia;
            tbTe.Text = examen.Te;
            tbOtrosQuimicaHematica.Text = examen.OtrosQuimicaHemat;
            tbColTotal.Text = examen.ColTotal;
            tbHdl.Text = examen.Hdl;
            tbLdl.Text = examen.Ldl;
            tbTriglic.Text = examen.Triglic;
            tbOtrosPerfilLipidico.Text = examen.OtrosPerfilLipidico;
            tbColor.Text = examen.Color;
            if (tbColor.Text == "") { tbColor.Text = "AMBAR"; }
            tbAspecto.Text = examen.Aspecto;
            if (tbAspecto.Text == "") { tbAspecto.Text = "LIMPIDO"; }
            tbDensidad.Text = examen.Densidad;
            tbPh.Text = examen.Ph;
            tbCelulas.Text = examen.Celulas;
            if (tbCelulas.Text == "") { tbCelulas.Text = "ESCASAS"; }
            tbLeuco.Text = examen.Leuco;
            if (tbLeuco.Text == "") { tbLeuco.Text = "ESCASOS"; }
            tbHematies.Text = examen.Hematies;
            if (tbHematies.Text == "") { tbHematies.Text = "NO SE OBSERVAN"; }
            tbProteinas.Text = examen.Prot;
            if (tbProteinas.Text == "") { tbProteinas.Text = "NO CONTIENE"; }
            tbGlucosa.Text = examen.Gluc;
            if (tbGlucosa.Text == "") { tbGlucosa.Text = "NO CONTIENE"; }
            tbHemglobOrina.Text = examen.HemogOrina;
            if (tbHemglobOrina.Text == "") { tbHemglobOrina.Text = "NO CONTIENE"; }
            tbCetonas.Text = examen.Cetonas;
            if (tbCetonas.Text == "") { tbCetonas.Text = "NO CONTIENE"; }
            tbBilirrubina.Text = examen.Bilirrubina;
            if (tbBilirrubina.Text == "") { tbBilirrubina.Text = "NO CONTIENE"; }
            tbOtrosOrina.Text = examen.OtrosOrina;
            // Arbitros
            tbNa.Text = examen.Na;
            tbK.Text = examen.K;
            tbProtTotal.Text = examen.ProtTotales;
            tbAlbumina.Text = examen.Albumina;
            tbAlfa1.Text = examen.ALFA1;
            tbAlfa2.Text = examen.ALFA2;
            tbBeta1.Text = examen.BETA1;
            tbBeta2.Text = examen.BETA2;
            tbGammaglob.Text = examen.Gammaglob;
            tbRelAlbGlob.Text = examen.RelacAlbGlob;
            tbCreatininemia.Text = examen.Creat;
            // Arbitros
            tbDictLab.Text = examen.DictamenLab;
            txtObservacionesLaboratorio.Text = examen.ObservacionesLab;
            if (tbDictLab.Text == "") { tbDictLab.Text = "SIN PARTICULARIDADES"; }
            setearTbSegunId("38", examen.ToraxF, "SIN LESIONES PLEURO-PULMONARES ACTIVAS");
            setearTbSegunId("39", examen.LumbarF, "SIN PARTICULARIDADES");
            setearTbSegunId("40", examen.LumbarP, "SIN PARTICULARIDADES");
            setearTbSegunId("41", examen.CervicalF, "");
            setearTbSegunId("42", examen.CervicalP, "");
            setearTbSegunId("43", examen.Fnp, "SIN PARTICULARIDADES");
            setearTbSegunId("44", examen.Mnp, "SIN PARTICULARIDADES");
            setearTbSegunId("45", examen.HombrosF, "SIN PARTICULARIDADES");
            setearTbSegunId("46", examen.RodillasF, "SIN PARTICULARIDADES");
            setearTbSegunId("80", examen.CaderasF, "SIN PARTICULARIDADES");
            setearTbSegunId("81", examen.TobillosF, "SIN PARTICULARIDADES");
            setearTbSegunId("47", examen.CraneoFyP, "");
            setearTbSegunId("48", examen.HombroF, "");
            setearTbSegunId("49", examen.HombroVP, "");
            setearTbSegunId("50", examen.HumeroFyP, "");
            setearTbSegunId("51", examen.CodoFyP, "");
            setearTbSegunId("52", examen.AntebrazoFyP, "");
            setearTbSegunId("53", examen.MunecaFyP, "");
            setearTbSegunId("54", examen.ManoFyP, "");
            setearTbSegunId("55", examen.ToraxP, "");
            setearTbSegunId("56", examen.PCostalFyO, "");
            setearTbSegunId("57", examen.ColDorsalFyP, "");
            setearTbSegunId("58", examen.PelvisF, "");
            setearTbSegunId("59", examen.CaderaF, "");
            setearTbSegunId("60", examen.CaderaP, "");
            setearTbSegunId("61", examen.FemurFyP, "");
            setearTbSegunId("62", examen.RodillaF, "");
            setearTbSegunId("63", examen.RodillaP, "");
            setearTbSegunId("64", examen.PiernaFyP, "");
            setearTbSegunId("65", examen.TobilloFyP, "");
            setearTbSegunId("66", examen.AxialDeCalcaneo, "");
            setearTbSegunId("67", examen.PieFyP, "");
            setearTbSegunId("68", examen.Audio, "");
            setearTbSegunId("70", examen.Ergo, "PRUEBA SUFICIENTE NEGATIVA");
            setearTbSegunId("72", examen.Eco, "DENTRO DE LOS PARAMETROS NORMALES");
            setearTbSegunId("73", examen.Psico, "RESPONDE AL PERFIL REQUERIDO");
            setearTbSegunId("75", examen.Espiro, "NORMAL");
            setearTbSegunId("76", examen.Eeg, "DENTRO DE LOS PARAMETROS NORMALES");
            setearTbSegunId("77", examen.ITorg, "");
            setearTbSegunId("78", examen.Ecg, "SIN VALOR PATOLOGICO");
            tbObservaciones.Text = examen.Observaciones;
            txtObservacionesLaboratorio.Text = examen.ObservacionesLab;
            if (examen.Dictamen != "") { cboDictamenFinal.SelectedValue = examen.Dictamen; }
            calcularIMC();
            puntosHabilitados = true;

            RecuperarTextoDiagnostico("68");// GRV - recupera el diagnostico de audiometria
        }

        private void calcularIMC()
        {
            if (tbPeso.Text != "" && tbTalla.Text != "" && tbPeso.Text != "0" && tbTalla.Text != "0")
            {
                reemplazarCaracter(tbTalla, '.', ',');
                medida = Convert.ToDecimal(tbTalla.Text);
                peso = Convert.ToDecimal(tbPeso.Text);
                IMC = decimal.Round((peso / (medida * medida)), 0);
                tb1.Text = IMC.ToString();
            }
        }

        private void reemplazarCaracter(TextBox tb, char viejo, char nuevo)
        {
            string text = tb.Text;
            tb.Text = text.Replace(viejo, nuevo);
        }

        private void tbPeso_Leave(object sender, EventArgs e)
        {
            calcularIMC();
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

        private void tbGRojos_TextChanged(object sender, EventArgs e)
        {
            puntosAlTextBox(tbGRojos, "###,###");
        }

        private void tbGBlancos_TextChanged(object sender, EventArgs e)
        {
            puntosAlTextBox(tbGBlancos, "###,###");
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

        private void tbTAMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbTAMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbPulso_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            numerosYPuntos(e);
        }

        private void tbPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbGRojos_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbGBlancos_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbHemoglob_KeyPress(object sender, KeyPressEventArgs e)
        {
            numerosYPuntos(e);
        }

        private void tbHemato_KeyPress(object sender, KeyPressEventArgs e)
        {
            numerosYPuntos(e);
        }

        private void tbEritro_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbPlaquetas_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbGlucemia_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbUremia_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbColTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbHdl_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbLdl_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbTriglic_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbPh_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbDensidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            numerosYPuntos(e);
        }

        private void tbPlaquetas_TextChanged(object sender, EventArgs e)
        {
            puntosAlTextBox(tbPlaquetas, "###,###");
        }

        private void tbHemoglob_Leave(object sender, EventArgs e)
        {
            reemplazarCaracter(tbHemoglob, '.', ',');
        }

        private void tbHemato_Leave(object sender, EventArgs e)
        {
            reemplazarCaracter(tbHemato, '.', ',');
        }

        private void tbDensidad_Leave(object sender, EventArgs e)
        {
            reemplazarCaracter(tbDensidad, '.', ',');
        }

        private void tbCayado_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbSegm_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbEosinof_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbBasof_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbLinfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbMono_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }

        private void tbUricemia_KeyPress(object sender, KeyPressEventArgs e)
        {
            numerosYPuntos(e);
        }

        private void tbUricemia_Leave(object sender, EventArgs e)
        {
            reemplazarCaracter(tbUricemia, '.', ',');
        }

        private bool verificarFormulaLeucocitaria()
        {
            if (tbCayado.Text != "" && tbSegm.Text != "" && tbEosinof.Text != "" &&
                tbBasof.Text != "" && tbLinfo.Text != "" && tbMono.Text != "")
            {
                Int32 suma = Convert.ToInt32(tbCayado.Text) + Convert.ToInt32(tbSegm.Text)
                    + Convert.ToInt32(tbEosinof.Text) + Convert.ToInt32(tbBasof.Text) +
                    Convert.ToInt32(tbLinfo.Text) + Convert.ToInt32(tbMono.Text);
                if (suma == 100) { return true; }
                MessageBox.Show("La suma de los valores de la fórmula leucocitaria debe ser 100");
                return false;

            }
            else if (tbCayado.Text == "" && tbSegm.Text == "" && tbEosinof.Text == "" &&
                tbBasof.Text == "" && tbLinfo.Text == "" && tbMono.Text == "")
            {
                return true;
            }
            MessageBox.Show("La suma de los valores de la fórmula leucocitaria debe ser 100");
            return false;
        }

        private void tbMono_Leave(object sender, EventArgs e)
        {
            verificarFormulaLeucocitaria();
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imprimir(bool oliv, string tipo)
        {
            Reportes report = new Reportes(new rptExamenLaboral());
            report.imprimir(examenLaboral.cargarParametrosExamen(idExamenLaboral, oliv),
                new dsMedicinaLaboral(), examenLaboral.cargarDataSourceExamen(imageToArray(), tipo));
        }

        private byte[] imageToArray()
        {
            MemoryStream ms = new MemoryStream();
            if (pictureBox1.Image != null) { pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); }
            return ms.ToArray();
        }

        private void botMail_Click(object sender, EventArgs e)
        {
            guardar();
            mail();
        }

        // GRV - Ramírez - Guarda en el directorio configurado
        private string DirectorioReporte()
        {
            byte bytTipo = 3;
            string strDirectorio = "";

            DataTable valores = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT reporte FROM dbo.ConfigReportes
            WHERE tipoReporte = '" + bytTipo + "'");

            if (valores.Rows.Count > 0)
            {
                strDirectorio = valores.Rows[0].ItemArray[0].ToString() + "\\";
            }
            else
            {
                strDirectorio = "P:\\EX. APTITUD\\";
            }

            return strDirectorio;
        }

        private void mail()
        {
            List<string> archivos = new List<string>();
            Reportes report = new Reportes(new rptExamenLaboral());
            string ruta = report.exportarAPDF(examenLaboral.cargarParametrosExamen(idExamenLaboral, false),
                 new dsMedicinaLaboral(), examenLaboral.cargarDataSourceExamen(imageToArray(), "3"),
                 // GRV - Ramírez - Modificado
                 // @"P:\EX. APTITUD\" + lblIdentificador.Text + "-" + tbFecha.Text.Replace('/', '-') + ".pdf");
                 DirectorioReporte() + lblIdentificador.Text + "-" + tbFecha.Text.Replace('/', '-') + ".pdf");
            archivos.Add(ruta);
            frmMail frm = frmMail.GetForm();
            frm.archivosAdjuntos(archivos);
            frm.direccionesMail(examenLaboral.cargarMailsEmpresaExamenLaboral(idExamenLaboral));
            frm.setearAsunto("RESULTADO DE EXAMEN SOLICITADO");
            frm.setearMensaje("Adjuntamos al presente mail el exámen solicitado.");
            frm.mailLaboral();
            frm.mostrar(this.MdiParent);
        }

        private void botImprimirEx_Click(object sender, EventArgs e)
        {
            guardar();
            //imprimir(false,"3");
            //
            DialogResult resultExamen = MessageBox.Show("¿Desea imprimir la carátula de exámen?", "Imprimir Carátula",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult resultProtocolo = MessageBox.Show("¿Desea imprimir el protocolo de laboratorio?", "Imprimir Protocolo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultExamen == DialogResult.Yes)
            {
                imprimir(false, "3");
            }
            if (resultProtocolo == DialogResult.Yes)
            {
                imprimirLaboratorio();
            }
        }

        private void botImprimirExOlivera_Click(object sender, EventArgs e)
        {
            guardar();
            imprimir(true, "4");

            //DialogResult resultExamen = MessageBox.Show("¿Desea imprimir exámen olivera?", "Imprimir Olivera",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //DialogResult resultProtocolo = MessageBox.Show("¿Desea imprimir el protocolo de laboratorio?", "Imprimir Protocolo",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (resultExamen == DialogResult.Yes)
            //{
            //    imprimir(true, "4");
            //}
            //if (resultProtocolo == DialogResult.Yes)
            //{
            //    imprimirLaboratorio();
            //}
        }

        private void botModificarTipoExamen_Click(object sender, EventArgs e)
        {
            frmTipoExamen fTipoExamen = new frmTipoExamen();
            fTipoExamen.cargarSegunIdTipoExamen(new Guid(examenLaboral.cargarIdTipoExamen(idConsulta)));
            fTipoExamen.objDelegateModificado = new frmTipoExamen.DelegateModificado(refreshExamen);
            fTipoExamen.ShowDialog();
        }

        public void refreshExamen()
        {
            inicializarFormulario();
            cargarExamen();
            tbAntCli.Focus();
        }

        private void botEditarPaciente_Click(object sender, EventArgs e)
        {
            editarPaciente();
        }

        private void editarPaciente()
        {
            abrirVentanaPacienteLaboralEdicion();
        }

        private void recargarPacienteLaboral(string idPaciente, string idEmpresa)
        {
            //
        }

        private void abrirVentanaPacienteLaboralEdicion()
        {
            RecuperaDatosPaciente(tbDni.Text);
            frmPacienteLaboral fPaciente = new frmPacienteLaboral();
            fPaciente.cargarPacienteEspecifico(strIDEmpresa, strIDPaciente);
            fPaciente.objDelegateDevolverID = new frmPacienteLaboral.DelegateDevolverID(recargarPacienteLaboral);
            fPaciente.ShowDialog();
            CargarDatosBasicos();
        }

        // GRV - Ramírez - Guarda en el directorio configurado
        private void RecuperaDatosPaciente(string strDNI)
        {
            CapaNegocioMepryl.PacienteLaboral objRecuperarPaciente = new CapaNegocioMepryl.PacienteLaboral();
            strIDPaciente = objRecuperarPaciente.obtenerIdPaciente(strDNI);
            strIDEmpresa = objRecuperarPaciente.obtenerIdEmpresaPaciente(strIDPaciente);

            //DataTable valores = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT id FROM PacienteLaboral where dni = '" + strDNI + "'");
            //if (valores.Rows.Count > 0)
            //{
            //    strIDPaciente = valores.Rows[0].ItemArray[0].ToString();
            //}
            //else
            //{
            //    strIDPaciente = "";
            //}

            //valores = SQLConnector.obtenerTablaSegunConsultaString(@"SELECT top 1 idEmpresa from EmpresasPorPaciente WHERE idPaciente = '" + strIDPaciente + "'");
            //if (valores.Rows.Count > 0)
            //{
            //    strIDEmpresa = valores.Rows[0].ItemArray[0].ToString();
            //}
            //else
            //{
            //    strIDEmpresa = "";
            //}            
        }

        private void CargarDatosBasicos()
        {
            Entidades.PacienteLaboral objDatosCargar = new Entidades.PacienteLaboral();
            CapaNegocioMepryl.PacienteLaboral objRecuperarDatosPaciente = new CapaNegocioMepryl.PacienteLaboral();

            objDatosCargar = objRecuperarDatosPaciente.leerDatosEntidad(strIDPaciente, strIDEmpresa);

            tbEmpresa.Text = objDatosCargar.Empresa;
            tbPaciente.Text = objDatosCargar.Dni + " - " + objDatosCargar.Apellido + " " + objDatosCargar.Nombre;
            tbTarea.Text = objDatosCargar.Tarea;
            tbDni.Text = objDatosCargar.Dni;

            strNombrePaciente = objDatosCargar.Nombre;
            strApellidoPaciente = objDatosCargar.Apellido;
        }

        private void imprimirLaboratorio()
        {
            //Reportes report = new Reportes(new rptProtocoloLaboratorioLaboral());
            //DataTable dtConsulta = examenLaboral.cargarParametrosLaboratorio(idExamenLaboral, 2);

            //if (dtConsulta.Rows.Count > 0)
            //{
            //    if ((string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[31].ToString()) && string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[32].ToString())) || (dtConsulta.Rows[0].ItemArray[31].ToString() == "0" && dtConsulta.Rows[0].ItemArray[31].ToString() == "0"))
            //    {
            //        report = null;
            //        report = new Reportes(new rptProtocoloLaboratorioLaboral01());
            //    }

            //    if ((!string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[66].ToString())) || (dtConsulta.Rows[0].ItemArray[66].ToString() != "0"))
            //    {
            //        report = null;
            //        report = new Reportes(new rptProtocoloLaboratorioLaboral02());
            //    }
            //}

            ////Reportes report = new Reportes(new rptProtocoloLaboratorioLaboral());
            ////report.imprimirLaboratorio(examenLaboral.cargarParametrosLaboratorio(idExamenLaboral),
            //report.imprimirLaboratorio(dtConsulta,
            //    new dsLaboralLaboratorio());

            ExportarProtocoloPDF(2, true);
        }

        public void ExportarProtocoloPDF(sbyte tipoReporte, bool blnImprimir)
        {
            CapaNegocioMepryl.Reportes rpt = new CapaNegocioMepryl.Reportes();
            string strIdExamenLaboral = idExamenLaboral;
            string strNombreArchivo = "";
            DataTable dtConsulta = examenLaboral.cargarParametrosLaboratorio(strIdExamenLaboral, tipoReporte);
            Reportes report = new Reportes(new rptProtocoloLaboratorioLaboral());
            string strTipoLaboratorio = "NORMAL";

            strNombreArchivo = "";

            if (dtConsulta.Rows.Count > 0)
            {
                bool blnPerfilLipidico01 = string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[31].ToString());
                bool blnPerfilLipidico02 = string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[32].ToString());
                bool blnCreatininaArbitro = string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[66].ToString());
                bool blnTieneOrina = string.IsNullOrEmpty(dtConsulta.Rows[0].ItemArray[48].ToString());

                if (dtConsulta.Rows[0].ItemArray[31].ToString() != "0" && dtConsulta.Rows[0].ItemArray[31].ToString() != "0")
                {
                    if (blnPerfilLipidico01 && blnPerfilLipidico02)
                    {
                        strTipoLaboratorio = "CASINO";
                    }
                }

                if (!blnCreatininaArbitro)
                {
                    if (dtConsulta.Rows[0].ItemArray[66].ToString() != "0")
                    {
                        strTipoLaboratorio = "ARBITRO";
                    }
                }

                if (blnTieneOrina)
                {

                    strTipoLaboratorio = "LIBRETA";
                }
            }

            rpt.LaboratorioLaboral(dtConsulta, strNombreArchivo, Convert.ToDateTime(tbFecha.Text), strTipoLaboratorio, blnImprimir);
        }

        private void frmExamenLaboral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && botAceptar.Visible)
            {
                botAceptar.PerformClick();
            }
            else if (e.KeyCode == Keys.F10 && botCancelar.Visible)
            {
                botCancelar.PerformClick();
            }
        }

        private void AbrirReporteAudiometria()
        {
            frmReporteAudiometria frm = new frmReporteAudiometria(false);
            frm.CargarParametrosEntrada(lblIdentificador.Text,
                                        Convert.ToDateTime(tbFecha.Text),
                                        tbDni.Text,
                                        tbEmpresa.Text,
                                        strDiagnosticoAudiometria,
                                        idExamenLaboral);
            frm.ShowDialog();
        }

        private void btnBotonEc1_Click(object sender, EventArgs e)
        {
            AbrirReporteAudiometria();
        }

        private void btnBotonEc2_Click(object sender, EventArgs e)
        {
            AbrirReporteAudiometria();
        }

        private void btnBotonEc3_Click(object sender, EventArgs e)
        {
            AbrirReporteAudiometria();
        }

        private void btnBotonEc4_Click(object sender, EventArgs e)
        {
            AbrirReporteAudiometria();
        }

        private void btnBotonEc5_Click(object sender, EventArgs e)
        {
            AbrirReporteAudiometria();
        }

        private void btnBotonEc6_Click(object sender, EventArgs e)
        {
            AbrirReporteAudiometria();
        }

        private void btnBotonEc7_Click(object sender, EventArgs e)
        {
            AbrirReporteAudiometria();
        }

        private void btnBotonEc8_Click(object sender, EventArgs e)
        {
            AbrirReporteAudiometria();

        }

        private void btnBotonEc9_Click(object sender, EventArgs e)
        {
            AbrirReporteAudiometria();
        }

        private void ModoPermisos(bool blnModifica)
        {
            if (!blnModifica)
            {
                botAceptar.Enabled = false;
                botModificarTipoExamen.Enabled = false;
                botEditarPaciente.Enabled = false;
                botImprimirEx.Enabled = false;
                botImprimirExOlivera.Enabled = false;
            }
        }

        private void tbTalla_Leave(object sender, EventArgs e)
        {
            string alturaconpunto = tbTalla.Text.ToString().Insert(1, ".");
            if (!tbTalla.Text.ToString().Contains("."))
            {
                tbTalla.Text = alturaconpunto;
            }
        }

        private void tbSi_Click(object sender, EventArgs e)
        {
            frmFacturacionPrestaciones frm = new frmFacturacionPrestaciones(this, idEmpresa, idConsulta);
            Utilidades.AbrePopUps(frm);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (EsComplementario)
            {
                if (e.TabPage == tabPageCli && EstudioComplementario["Clinico"])
                {
                    e.Cancel = false;
                }
                if (e.TabPage == tabPageCli && !EstudioComplementario["Clinico"])
                {
                    e.Cancel = true;
                }
                if (e.TabPage == tabPageLab && !EstudioComplementario["Lab"])
                {
                    e.Cancel = true;
                }
                if (e.TabPage == tabPageRx && !EstudioComplementario["RX"])
                {
                    e.Cancel = true;
                }
                if (e.TabPage == tabPageEC && !EstudioComplementario["EC"])
                {
                    e.Cancel = true;
                }
            }
        }

        private void tbPanelRx1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPanelRx2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPanelRx3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cargarMedicos(string strIdProfesional)
        {
            DataTable retorno = new DataTable();
            DataView vista;
            DataTable profesional = null;
            string strSQL = "";

            retorno.Columns.Add("id");
            retorno.Columns.Add("profesional");
            retorno.Columns.Add("codigo", typeof(int));

            if (string.IsNullOrEmpty(strIdProfesional))
            {
                strIdProfesional = "00000000-0000-0000-0000-000000000000";
            }

            strSQL = "select p.id, (convert(varchar(4), p.codigo) " +
                     "+ ' - ' + p.apellido + ' ' + p.nombres) as profesional, p.codigo from dbo.Profesional p WHERE id = '" + strIdProfesional + "' order by convert(int, p.codigo) asc";

            profesional = SQLConnector.obtenerTablaSegunConsultaString(strSQL);

            foreach (DataRow r in profesional.Rows)
            {
                retorno.Rows.Add(r.ItemArray[0].ToString(), r.ItemArray[1].ToString(), r.ItemArray[2].ToString());
            }

            profesional = SQLConnector.obtenerTablaSegunConsultaString(@"select p.id, (convert(varchar(4),p.codigo) 
	+ ' - ' + p.apellido + ' ' + p.nombres) as profesional, p.codigo from dbo.Profesional p WHERE Activo = 1 AND id <> '" + strIdProfesional + "' order by convert(int,p.codigo) asc");

            foreach (DataRow r in profesional.Rows)
            {
                retorno.Rows.Add(r.ItemArray[0].ToString(), r.ItemArray[1].ToString(), r.ItemArray[2].ToString());
            }

            vista = new DataView(retorno);
            vista.Sort = "codigo";

            cboMedico.DataSource = vista;
            cboMedico.ValueMember = "id";
            cboMedico.DisplayMember = "profesional";
            cboMedico.SelectedIndex = -1;
        }
    }
}
