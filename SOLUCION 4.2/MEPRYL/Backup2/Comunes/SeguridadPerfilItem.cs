using System;

namespace Comunes
{
	/// <summary>
	/// Summary description for SeguridadPerfilItem.
	/// </summary>
	public class SeguridadPerfilItem
	{
		private SeguridadOperacion _operacion;
		private SeguridadObjeto _objeto;
		private string _id;
		private string _seguridadPerfilId;

		public SeguridadOperacion operacion 
		{
			set
			{
				this._operacion = value;
			}
			get
			{
				return this._operacion;
			}
		}
			
		public SeguridadObjeto objeto 
		{
			set
			{
				this._objeto = value;
			}
			get
			{
				return this._objeto;
			}
		}
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
		public string seguridadPerfilId 
		{
			set
			{
				this._seguridadPerfilId = value;
			}
			get
			{
				return this._seguridadPerfilId;
			}
		}

		public SeguridadPerfilItem(string id, string seguridadPerfilId, SeguridadObjeto seguridadObjeto, SeguridadOperacion seguridadOperacion)
		{
			this.id = id;
			this.seguridadPerfilId = seguridadPerfilId;
			this.operacion = seguridadOperacion;
			this.objeto = seguridadObjeto;
		}
	}
}
