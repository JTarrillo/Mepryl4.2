using System;

namespace Comunes
{
	/// <summary>
	/// Summary description for SeguridadPerfil.
	/// </summary>
	public class SeguridadPerfil
	{

		private string _id;
		private string _nombre;
		private string _descripcion;
		private SeguridadPerfilItem[] _items;

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
		public string descripcion 
		{
			set
			{
				this._descripcion = value;
			}
			get
			{
				return this._descripcion;
			}
		}
		
		public SeguridadPerfilItem[] items 
		{
			set
			{
				this._items = value;
			}
			get
			{
				return this._items;
			}
		}

		public SeguridadPerfil(string id, string nombre, string descripcion, SeguridadPerfilItem[] items)
		{
			this.id = id;
			this.nombre = nombre;
			this.descripcion = descripcion;
			this.items = items;
		}
	}
}
