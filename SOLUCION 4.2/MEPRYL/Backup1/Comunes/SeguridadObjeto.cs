using System;

namespace Comunes
{
	/// <summary>
	/// Summary description for SeguridadObjeto.
	/// </summary>
	public class SeguridadObjeto
	{
		private string _id;
		private string _nombre;
		private string _descripcion;
		private string _identificador;

		public string id 
		{
			set
			{
				_id = value;
			}
			get
			{
				return _id;
			}
		}
		public string nombre 
		{
			set
			{
				_nombre = value;
			}
			get
			{
				return _nombre;
			}
		}
		public string descripcion 
		{
			set
			{
				_descripcion = value;
			}
			get
			{
				return _descripcion;
			}
		}

		public SeguridadObjeto(string id, string nombre, string descripcion, string identificador)
		{
			this.id = id;
			this.nombre = nombre;
			this.descripcion = descripcion;
			this.identificador = identificador;

		}

		/// <summary>
		/// Identificador unico en forma de string.
		/// </summary>
		public string identificador
		{
			get
			{
				return _identificador;
			}
			set
			{
				_identificador = value;
			}
		}
	}
}

