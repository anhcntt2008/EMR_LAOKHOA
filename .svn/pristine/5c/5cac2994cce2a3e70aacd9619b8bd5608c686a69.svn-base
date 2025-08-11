using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.CompanyConstant.UI
{
	/// <summary>
	/// Summary description for DMCS101
	/// </summary>
	public partial class DMCS101 : BOSERPScreen
	{

		public DMCS101()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void fld_btnButton_Click(object sender, EventArgs e)
        {
            ((Modules.CompanyConstant.CompanyConstantModule)this.Module).SaveCustomerConfig();

            ((Modules.CompanyConstant.CompanyConstantModule)this.Module).SaveHospitalRank();
        }
	}
}
