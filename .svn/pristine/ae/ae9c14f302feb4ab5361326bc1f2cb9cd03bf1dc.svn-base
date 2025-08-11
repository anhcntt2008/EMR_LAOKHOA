using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.SellStaff.UI
{
	/// <summary>
	/// Summary description for DMSS105
	/// </summary>
	public partial class DMSS105 : BOSERPScreen
	{

		public DMSS105()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void bosButton3_Click(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).AddItemToContractList();
        }

        private void bosButton2_Click(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).RemoveSelectedItemFromContractList();
        }

        private void bosButton1_Click(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).ChangeSelectedItemFromContractList();
        }
	}
}
