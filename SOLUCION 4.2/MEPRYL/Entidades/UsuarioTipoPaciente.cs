using System;

namespace Entidades
{
    public class UsuarioTipoPaciente
    {
        private Guid id;
        private string username;
        private string password;
        private string dni;
        private string apellido;
        private string nombre;
        private string tipo;
        private bool activo;
        private DateTime fechaCreacion;

        public UsuarioTipoPaciente()
        {
            id = Guid.Empty;
            username = string.Empty;
            password = string.Empty;
            dni = string.Empty;
            apellido = string.Empty;
            nombre = string.Empty;
            tipo = string.Empty;
            activo = true;
            fechaCreacion = DateTime.Now;
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

        public string DNI
        {
            get { return dni; }
            set { dni = value; }
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

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
    }
}
