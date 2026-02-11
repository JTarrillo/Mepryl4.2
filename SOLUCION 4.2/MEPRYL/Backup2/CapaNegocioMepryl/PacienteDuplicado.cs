using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using CapaDatosMepryl;
using System.Data;

namespace CapaNegocioMepryl
{
    public class PacienteDuplicado
    {
        private CapaDatosMepryl.PacienteDuplicado pacDuplicado;

        public PacienteDuplicado()
        {
            pacDuplicado = new CapaDatosMepryl.PacienteDuplicado();
        }

        public Entidades.PacienteDuplicado cargarDatosEntidad(string id)
        {
            return pacDuplicado.cargarDatosEntidad(id);
        }

        public void moverDatos(DataTable tabla, string idPaciente)
        {
            pacDuplicado.moverDatos(tabla, idPaciente);
        }

        public void eliminarPaciente(string idPaciente)
        {
            pacDuplicado.eliminarPaciente(idPaciente);
        }

    }
}
