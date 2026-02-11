using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Comunes
{
	/// <summary>
	/// Summary description for CustomGrid.
	/// </summary>
	public class ucCustomGrid : System.Windows.Forms.DataGrid
	{
		private const int WM_KEYDOWN = 0x100;
		private const int WM_KEYUP = 0x101;
		private const int WM_CHAR = 0x102;  //Supuestamente KeyPress

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucCustomGrid()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call

		}

	
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

	
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		//Define el Delegado 
		public delegate void DelegateKeyDown(System.Windows.Forms.Keys keyData);
		public DelegateKeyDown objDelegateKeyDown = null;

		protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData )  
		{ 
			//MessageBox.Show(msg.Msg.ToString());
			switch (msg.Msg) 
			{ 
				case WM_KEYDOWN: 
				//case WM_CHAR:
				//case WM_KEYUP:
					//Si el objeto delegate no es nulo, lo ejecuta
					if (objDelegateKeyDown!=null)
						objDelegateKeyDown(keyData);
					break;
			} 
			return false; //base.ProcessCmdKey(ref msg, keyData); 
		}
	}
}
