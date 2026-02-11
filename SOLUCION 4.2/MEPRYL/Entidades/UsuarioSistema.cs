using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuarioSistema
    {
        private Guid id;
        private string username;
        private string password;
        private string apellido;
        private string nombre;
        private Guid sucursalId;
        private string email;
        private string comentarios;
        private DateTime actualiza_local;
        private string operacion_local;
        private DateTime sincronizado;
        private Guid serverId;
        private string tipo;
        private bool ventConfiguracion;
        private bool ventExamenes;
        private bool ventMesa;
        private bool ventPacientes;
        private bool ventVentanilla;
        private bool ventResumen;
        private bool ventTurnos;
        private bool ventAudiometria;
        private bool permisoVer;
        private bool permisoModificar;
        private bool permisoEliminar;
        private bool activo;
        private Guid profesionalAsignado;
        private string dni;

        public UsuarioSistema()
        {
            this.id = Guid.Empty;
            this.username = string.Empty;
            this.password = string.Empty;
            this.apellido = string.Empty;
            this.nombre = string.Empty;
            this.sucursalId = Guid.Empty;
            this.email = string.Empty;
            this.comentarios = string.Empty;
            this.actualiza_local = new DateTime(1800, 1, 1);
            this.operacion_local = string.Empty;
            this.sincronizado = new DateTime(1800, 1, 1);
            this.serverId = Guid.Empty;
            this.tipo = string.Empty;
            this.ventConfiguracion = false;
            this.ventExamenes = false;
            this.ventMesa = false;
            this.ventPacientes = false;
            this.ventVentanilla = false;
            this.ventResumen = false;
            this.ventTurnos = false;
            this.ventAudiometria = false;
            this.permisoVer = false;
            this.permisoModificar = false;
            this.permisoEliminar = false;
            this.activo = false;
            this.profesionalAsignado = Guid.Empty;
            this.dni = string.Empty;
        }

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Guid SucursalId
        {
            get { return sucursalId; }
            set { sucursalId = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Comentarios
        {
            get { return comentarios; }
            set { comentarios = value; }
        }

        public DateTime Actualiza_Local
        {
            get { return actualiza_local; }
            set { actualiza_local = value; }
        }

        public string Operacion_Local
        {
            get { return operacion_local; }
            set { operacion_local = value; }
        }

        public DateTime Sincronizado
        {
            get { return sincronizado; }
            set { sincronizado = value; }
        }

        public Guid ServerId
        {
            get { return serverId; }
            set { serverId = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public bool VentConfiguracion 
        {
            get { return ventConfiguracion; }
            set { ventConfiguracion = value; }
        }

        public bool VentExamenes
        {
            get { return ventExamenes; }
            set { ventExamenes = value; }
        }

        public bool VentMesa
        {
            get { return ventMesa; }
            set { ventMesa = value; }
        }

        public bool VentPacientes
        {
            get { return ventPacientes; }
            set { ventPacientes = value; }
        }

        public bool VentVentanilla
        {
            get { return ventVentanilla; }
            set { ventVentanilla = value; }
        }

        public bool VentResumen
        {
            get { return ventResumen; }
            set { ventResumen = value; }
        }

        public bool VentTurnos
        {
            get { return ventTurnos; }
            set { ventTurnos = value; }
        }
        
        public bool VentAudiometria
        {
            get { return ventAudiometria; }
            set { ventAudiometria = value; }
        }

        public bool PermisoVer
        {
            get { return permisoVer; }
            set { permisoVer = value; }
        }

        public bool PermisoModificar
        {
            get { return permisoModificar; }
            set { permisoModificar = value; }
        }

        public bool PermisoEliminar
        {
            get { return permisoEliminar; }
            set { permisoEliminar = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public Guid ProfesionalAsignado
        {
            get { return profesionalAsignado; }
            set { profesionalAsignado = value; }
        }

        public string DNI
        {
            get { return dni; }
            set { dni = value; }
        }
    }
}
