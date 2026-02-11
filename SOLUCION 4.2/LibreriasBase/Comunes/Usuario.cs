using System;

namespace Comunes
{
	/// <summary>
	/// Summary description for Usuario.
	/// </summary>
	public class Usuario
	{
		private string _id;
		private string _nombre;
		private string _apellido;
		private string _username;
		private string _email1;
		private string _comentarios;
		private string _sucursalID;
		public SeguridadPerfil[] perfiles;

		public string id 
		{
			set
			{
				this._id = value;
			}
			get
			{
				return this._id;
			}
		}
		public string nombre 
		{
			set
			{
				this._nombre = value;
			}
			get
			{
				return this._nombre;
			}
		}
		public string apellido 
		{
			set
			{
				this._apellido = value;
			}
			get
			{
				return this._apellido;
			}
		}
		public string username 
		{
			set
			{
				this._username = value;
			}
			get
			{
				return this._username;
			}
		}
		public string email1 
		{
			set
			{
				this._email1 = value;
			}
			get
			{
				return this._email1;
			}
		}
		public string comentarios 
		{
			set
			{
				this._comentarios = value;
			}
			get
			{
				return this._comentarios;
			}
		}
		public string sucursalID
		{
			set
			{
				this._sucursalID = value;
			}
			get
			{
				return this._sucursalID;
			}
		}

        public string Tipo { get; set; }

        /*public string perfiles 
		{
			set
			{
				this._perfiles = value;
			}
			get
			{
				return this._perfiles;
			}
		}*/

        public Usuario(string id, string nombre, string apellido, string username, string email1, string comentarios, string sucursalID)
		{
			this.id = id;
			this.nombre = nombre;
			this.apellido = apellido;
			this.username = username;
			this.email1 = email1;
			this.comentarios = comentarios;
			this.sucursalID = sucursalID;
		}

        public bool contienePerfil(string nombrePerfil) {
            bool contiene = false;
            foreach (SeguridadPerfil perfil in this.perfiles) {
                if (perfil.nombre == nombrePerfil)
                {
                    contiene = true;
                    break;
                }
            }
            return contiene;
        }
	}
}
