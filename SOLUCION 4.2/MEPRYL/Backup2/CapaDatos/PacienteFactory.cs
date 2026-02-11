using System;
using System.Collections.Generic;
using System.Text;
using CapaDatosBase;
using Comunes;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class PacienteFactory : EntidadFactoryBase
    {
        public Paciente entidad;

        public PacienteFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        
        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                Paciente paciente = (Paciente)entidad;
                //15
                    SqlParameter[] param = new SqlParameter[16];

                    param[0] = new SqlParameter("@id", paciente.id);
                    param[1] = new SqlParameter("@codigo", paciente.dni);
                    param[2] = new SqlParameter("@apellido", paciente.apellido);
                    param[3] = new SqlParameter("@nombres", paciente.nombres); //
                    param[4] = new SqlParameter("@tipoPacienteID", paciente.pacienteTipo.id);
                    param[5] = new SqlParameter("@empresaID", paciente.empresa.id);
                    param[6] = new SqlParameter("@empresaTarea", paciente.empresaTarea);
                    param[7] = new SqlParameter("@dni", paciente.dni);
                    param[8] = new SqlParameter("@fechaNacimiento", paciente.fechaNacimiento);
                    param[9] = new SqlParameter("@telefonos", paciente.telefonos);
                    param[10] = new SqlParameter("@celular", paciente.celular);
                    param[11] = new SqlParameter("@observaciones", paciente.observaciones);
                    param[12] = new SqlParameter("@registroBLOB", paciente.getRegistroBLOB() + " " + paciente.empresa.getRegistroBLOB());
                    param[13] = new SqlParameter("@direccion", paciente.direccion);
                    param[14] = new SqlParameter("@localidad", paciente.localidad);
                    param[15] = new SqlParameter("@nacionalidad", paciente.nacionalidad);
                    //param[16] = new SqlParameter("@email", paciente.Email); // GRV - Modificado


                    SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Paciente_Update", param);

                    SqlParameter[] parametro = new SqlParameter[1];
                    parametro[0] = new SqlParameter("@id", paciente.id);
                    SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Paciente_AsignarClubesANuevoId", parametro);
                
                 
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }

            return resultado;
        }

        //Implementacion
        public override void inicializarEntidad()
        {
            base.inicializarEntidad();
            entidad = new Paciente(base.entidad);
        }

        public override Resultado alta(EntidadBase ent)
        {
            Resultado resultado = new Resultado();
            try
            {
                //Da el alta del registro vacío para obtener el ID
                resultado = altaID(ent);

                //Modifica el registro nuevo con los datos completos del alta
                if (resultado.mensaje == "")
                {
                    Paciente datPaciente = (Paciente)resultado.objeto;
                    resultado = modificar(datPaciente);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }

        //Lee el registro obtenido de la base de datos, cada implementación agrega los campos espefícicos.
        protected override EntidadBase leerRegistro(SqlDataReader dr)
        {
            Paciente paciente = new Paciente(base.leerRegistro(dr));
            try
            {
                string ligaID = dr["ligaID"].ToString();
                string clubID = dr["clubID"].ToString();
     

                string empresaID = dr["empresaID"].ToString();
                string tipoPacienteID = dr["tipoPacienteID"].ToString();

                empresaID = empresaID == "" ? Utilidades.ID_VACIO : empresaID;
                tipoPacienteID = tipoPacienteID == "" ? Utilidades.ID_VACIO : tipoPacienteID; 

                
                paciente.apellido = dr["apellido"].ToString();
                paciente.nombres = dr["nombres"].ToString();
                paciente.pacienteTipo = (PacienteTipo)(new PacienteTipoFactory(this.configuracion, "PacienteTipo")).getById(new Guid(tipoPacienteID));
                paciente.empresa = (Empresa)(new EmpresaFactory(this.configuracion, "Empresa")).getById(new Guid(empresaID));
                paciente.empresaTarea = dr["empresaTarea"].ToString();
                paciente.dni = dr["dni"].ToString();
                paciente.fechaNacimiento = DateTime.Parse(dr["fechaNacimiento"].ToString());
                if (dr["fechaUltimoExamen"].ToString()!="")
                    paciente.fechaUltimoExamen = DateTime.Parse(dr["fechaUltimoExamen"].ToString());
                paciente.telefonos = dr["telefonos"].ToString();
                paciente.celular = dr["celular"].ToString();
                paciente.observaciones = dr["observaciones"].ToString();
                //paciente.Email = dr["Email"].ToString(); // GRV - Modificar
                //paciente.hizoPlacaID = int.Parse(dr["hizoPlacaID"].ToString());
                int.TryParse(dr["hizoPlacaID"].ToString(), out paciente.hizoPlacaID);
                if (dr["nacionalidad"].ToString() != "")
                {
                    paciente.nacionalidad = new Guid(dr["nacionalidad"].ToString());
                }
                if (dr["localidad"].ToString() != "")
                {
                    paciente.localidad = new Guid(dr["localidad"].ToString());
                }
                paciente.direccion = dr["direccion"].ToString();
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
            }
            return paciente;
        }
    }
}