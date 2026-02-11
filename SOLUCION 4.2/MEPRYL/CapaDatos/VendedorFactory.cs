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
    public class VendedorFactory : PersonaFactoryBase
    {
        public Vendedor entidad;

        public VendedorFactory(Configuracion conf, string entNombre)
            : base(conf, entNombre)
        { }

        public override Resultado modificar(EntidadBase entidad)
        {
            Resultado resultado = new Resultado(entidad, "");
            try
            {
                Vendedor vendedor = (Vendedor)entidad;

                SqlParameter[] param = new SqlParameter[16];

                param[0] = new SqlParameter("@id", vendedor.id);
                param[1] = new SqlParameter("@codigo", vendedor.codigo);
                param[2] = new SqlParameter("@apellido", vendedor.apellido);
                param[3] = new SqlParameter("@nombres", vendedor.nombres);
                param[4] = new SqlParameter("@direccion", vendedor.direccion);
                param[5] = new SqlParameter("@localidadID", vendedor.localidadID);
                param[6] = new SqlParameter("@codigoPostal", vendedor.codigoPostal);
                param[7] = new SqlParameter("@provinciaID", vendedor.provinciaID);
                param[8] = new SqlParameter("@ubicacionGuia", vendedor.ubicacionGuia);
                param[9] = new SqlParameter("@dni", vendedor.dni);
                param[10] = new SqlParameter("@fechaNacimiento", vendedor.fechaNacimiento);
                param[11] = new SqlParameter("@eMail", vendedor.eMail);
                param[12] = new SqlParameter("@telefonos", vendedor.telefonos);
                param[13] = new SqlParameter("@paginaWeb", vendedor.paginaWeb);
                param[14] = new SqlParameter("@observaciones", vendedor.observaciones);
                param[15] = new SqlParameter("@registroBLOB", vendedor.getRegistroBLOB());

                SqlHelper.ExecuteNonQuery(this.configuracion.getConectionString(), "sp_Vendedor_Update", param);

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
            entidad = new Vendedor(base.entidad);
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
                    Vendedor datVendedor = (Vendedor)resultado.objeto;
                    resultado = modificar(datVendedor);
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
