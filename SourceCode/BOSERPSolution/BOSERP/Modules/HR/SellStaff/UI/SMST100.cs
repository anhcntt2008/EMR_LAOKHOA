using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.SellStaff.UI
{
	/// <summary>
	/// Summary description for SMST100
	/// </summary>
	public partial class SMST100 : BOSERPScreen
	{

		public SMST100()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void fld_btnButton3_Click(object sender, EventArgs e)
        {
            ((BaseModuleERP)this.Module).ResetSearchObject();
        }
	}
}
