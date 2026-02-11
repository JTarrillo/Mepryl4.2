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
    public class ClienteFactory : PersonaFactoryBase
    {
        public Cliente entidad;

        public ClienteFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                Cliente cliente = (Cliente)entidad;
                
                SqlParameter[] param = new SqlParameter[16];

                param[0] = new SqlParameter("@id", cliente.id);
                param[1] = new SqlParameter("@codigo", cliente.codigo);
                param[2] = new SqlParameter("@apellido", cliente.apellido);
                param[3] = new SqlParameter("@nombres", cliente.nombres);
                param[4] = new SqlParameter("@direccion", cliente.direccion);
                param[5] = new SqlParameter("@localidadID", cliente.localidadID);
                param[6] = new SqlParameter("@codigoPostal", cliente.codigoPostal);
                param[7] = new SqlParameter("@provinciaID", cliente.provinciaID);
                param[8] = new SqlParameter("@ubicacionGuia", cliente.ubicacionGuia);
                param[9] = new SqlParameter("@dni", cliente.dni);
                param[10] = new SqlParameter("@fechaNacimiento", cliente.fechaNacimiento);
                param[11] = new SqlParameter("@eMail", cliente.eMail);
                param[12] = new SqlParameter("@telefonos", cliente.telefonos);
                param[13] = new SqlParameter("@paginaWeb", cliente.paginaWeb);
                param[14] = new SqlParameter("@observaciones", cliente.observaciones);
                param[15] = new SqlParameter("@registroBLOB", cliente.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Cliente_Update", param);
              
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
            entidad = new Cliente(base.entidad);
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
                    Cliente datCliente = (Cliente)resultado.objeto;
                    resultado = modificar(datCliente);
                }
            }
            catch (Exception ex)
            {
                ManejadorErrores.escribirLog(ex, true, this.configuracion);
                resultado.mensaje = ex.Message;
            }
            return resultado;
        }
    }
}
