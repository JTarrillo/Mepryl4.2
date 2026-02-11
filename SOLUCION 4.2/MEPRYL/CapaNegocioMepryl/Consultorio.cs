using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatosMepryl;
using System.Data;

namespace CapaNegocioMepryl
{ 
    public class Consultorio
    {
        private CapaDatosMepryl.Laboral datLaboral;

        public Consultorio()
        {
            datLaboral = new Laboral();
        }

        public DataTable cargarMedicos()
        {
            return datLaboral.consulta(@"select id, (apellido + ' ' + nombres)
            as profesional from dbo.Profesional order by CONVERT(int,codigo)");
        }

        public DataTable cargarEstadoAtencion()
        {
            return datLaboral.consulta(@"select * from dbo.EstadoAtencion order by codigo");
        }

        public DataTable cargarPatologia()
        {
            return datLaboral.consulta(@"select * from dbo.Patologia order by descripcion");
        }

        public DataTable cargarMotivoConsulta()
        {
            return datLaboral.consulta(@"select * from dbo.MotivoDeConsultaLaboral order by descripcion");
        }

        public DataTable cargarCondicionLaboral()
        {
            return datLaboral.consulta(@"select * from dbo.CondicionLaboral where lugarAtencion = 'CONSULTORIO' order by codigo");
        }

        public Entidades.Consultorio cargarConsultorio(string idConsultaLaboral)
        {
            return datLaboral.cargarConsultorio(idConsultaLaboral);
        }

        public void guardarConsulta(Entidades.Consultorio c)
        {
            datLaboral.updateConsultorio(c);
        }

        public Entidades.Consultorio cargarConsultorioAnterior(string fecha, string idPaciente, string idEmpresa)
        {
            return datLaboral.cargarConsultorio(fecha,idPaciente,"<", idEmpresa);
        }

        public Entidades.Consultorio cargarConsultorioSiguiente(string fecha, string idPaciente, string idEmpresa)
        {
            return datLaboral.cargarConsultorio(fecha, idPaciente, ">", idEmpresa);
        }

        public DataTable cargarDataSourceConsultorio()
        {
            return datLaboral.cargarDataSourceConsultorio();
        }

        public DataTable cargarParametrosConsultorio(string idConsultorio)
        {
            return datLaboral.cargarParametrosConsultorio(idConsultorio);
        }

        public Entidades.Resultado verificarEstadoAtencionSeleccionado(string idEstadoAtencion, string idPaciente, string fecha)
        {
            return datLaboral.verificarEstadoAtencion(idEstadoAtencion,idPaciente,fecha);
        }

        public List<string> cargarMailsEmpresa(string idConsultorio)
        {
            return datLaboral.cargarMailsEmpresaConsultorio(idConsultorio);
        }

        public string ObtenerIdConsultaLaboralSegunConsultorio(string idcons)
        {
            Laboral lab = new Laboral();
            return lab.ObtenerIdConsultaLaboralSegunConsultorio(idcons);
        }

    }
}
