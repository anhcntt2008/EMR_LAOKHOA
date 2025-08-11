using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.CompanyConstant.UI
{
	/// <summary>
	/// Summary description for DMCS102
	/// </summary>
	public partial class DMCS102 : BOSERPScreen
	{

		public DMCS102()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void fld_btnProductTypeSave_Click(object sender, EventArgs e)
        {
            ((Modules.CompanyConstant.CompanyConstantModule)this.Module).SaveProductConfig();
        }
	}
}
