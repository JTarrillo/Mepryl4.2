using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entidades
{
    public class TurnoPreventiva
    {
        private Guid id;
        private string dni;
        private string apellidoNombre;
        private DateTime nacimiento;
        private string telefono; 
        private DataTable ligaClub;
        private Guid idTipoExamen;
        private string examen;
        private bool facturaClub;
        private bool examenModificado;
        private Guid idPaciente; 
        private string observaciones;
        private double importe;
        private TipoExamen tipoExamen;
        private string consulta; // GRV - Ramírez - Guardar consulta "PREVENTIVA"
        private string mail;

        public TurnoPreventiva()
        {
            this.id = Guid.Empty;
            this.dni = string.Empty;
            this.apellidoNombre = string.Empty;
            this.nacimiento = new DateTime(1800, 1, 1);
            this.telefono = string.Empty;
            this.ligaClub = new DataTable();
            this.idTipoExamen = Guid.Empty;
            this.examen = string.Empty;
            this.facturaClub = false;
            this.examenModificado = false;
            this.idPaciente = Guid.Empty;
            this.observaciones = string.Empty;
            this.importe = 0;
            this.tipoExamen = new TipoExamen();
            this.consulta = string.Empty;  // GRV - Ramírez - Guardar consulta "PREVENTIVA"
            this.mail = string.Empty;
            
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

        public string ApellidoNombre
        {
            get { return apellidoNombre; }
            set { apellidoNombre = value; }
        }

        public DateTime Nacimiento
        {
            get { return nacimiento; }
            set { nacimiento = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public DataTable LigaClub
        {
            get { return ligaClub; }
            set { ligaClub = value; }
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

        public bool FacturaClub
        {
            get { return facturaClub; }
            set { facturaClub = value; }
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

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        #endregion
    }
}
