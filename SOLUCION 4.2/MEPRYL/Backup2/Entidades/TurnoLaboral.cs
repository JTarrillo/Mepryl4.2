using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class TurnoLaboral
    {
        private Guid id;
        private string dni; 
        private string cuil;
        private string apellidoNombre;
        private string empresa; 
        private string tarea;
        private Guid idTipoExamen;
        private string examen;
        private bool facturaEmpresa;
        private bool examenModificado;
        private Guid idPaciente;
        private string observaciones;
        private double importe;
        private Guid idEmpresa;
        private string telefono;
        private TipoExamen tipoExamen;
        private string consulta; // GRV - Ramírez - Guardar consulta "LABORAL"




        public TurnoLaboral()
        {
            this.id = Guid.Empty;
            this.dni = string.Empty;
            this.cuil = string.Empty;
            this.apellidoNombre = string.Empty;
            this.empresa = string.Empty;
            this.tarea = string.Empty;
            this.idTipoExamen = Guid.Empty;
            this.examen = string.Empty;
            this.facturaEmpresa = false;
            this.examenModificado = false;
            this.idPaciente = Guid.Empty;
            this.observaciones = string.Empty;
            this.importe = 0;
            this.idEmpresa = Guid.Empty;
            this.telefono = string.Empty;
            this.tipoExamen = new TipoExamen();
            this.consulta = string.Empty;  // GRV - Ramírez - Guardar consulta "LABORAL"
        }


        #region Getters&Setters

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Cuil
        {
            get { return cuil; }
            set { cuil = value; }
        }

        public string ApellidoNombre
        {
            get { return apellidoNombre; }
            set { apellidoNombre = value; }
        }

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        public string Tarea
        {
            get { return tarea; }
            set { tarea = value; }
        }

        public Guid IdTipoExamen
        {
            get { return idTipoExamen; }
            set { idTipoExamen = value; }
        }

        public string Examen
        {
            get { return examen; }
            set { examen = value; }
        }

        public bool FacturaEmpresa
        {
            get { return facturaEmpresa; }
            set { facturaEmpresa = value; }
        }

        public bool ExamenModificado
        {
            get { return examenModificado; }
            set { examenModificado = value; }
        }

        public Guid IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public double Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public Guid IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public TipoExamen TipoExamen
        {
            get { return tipoExamen; }
            set { tipoExamen = value; }
        }

        // GRV - Ramírez
        public string Consulta
        {
            get { return consulta; }
            set { consulta = value; }
        }


        #endregion
    }
}
