using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CapaNegocioMepryl;

namespace CapaPresentacion
{
    public partial class frmEstudioComplementario : DevExpress.XtraEditors.XtraForm
    {
        TipoExamen tipoexamen = new TipoExamen();
        public frmEstudioComplementario()
        {
            InitializeComponent();
            inicializar();
        }
        #region Funciones
        private void inicializar()
        {
            inicializaDgv();
        }

        private void inicializaDgv()
        {
            Entidades.TipoExamen entidad = entidad = tipoexamen.cargarItems();
            dgvEstComplementarios.DataSource = entidad.EstComplementarios;
        }

        public void CargaDatos(string idConsultaLaboral)
        {
            DataTable dt = Comunes.SQLConnector.obtenerTablaSegunConsultaString(@"Select e.razonSocial, CONCAT(pl.apellido, ' ,' ,pl.nombres), ete.tarea, pl.dni, c.fecha
            FROM [MEPRYLv2.1].[dbo].[ConsultaLaboral] cl
            inner join [MEPRYLv2.1].dbo.empresaPorTipoDeExamen ete on cl.idTipoExamen = ete.idTipoExamen
            inner join [MEPRYLv2.1].dbo.Empresa e on ete.idEmpresa = e.id
            inner join [MEPRYLv2.1].dbo.TipoExamenDePaciente tep on cl.idTipoExamen = tep.id
            inner join [MEPRYLv2.1].dbo.Consulta c on tep.idConsulta = c.id
            inner join [MEPRYLv2.1].dbo.PacienteLaboral pl on c.pacienteID = pl.id");
        }
        #endregion
    }
}