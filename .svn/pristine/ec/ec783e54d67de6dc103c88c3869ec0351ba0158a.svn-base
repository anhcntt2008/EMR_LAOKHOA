using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.SellStaff.UI
{
	/// <summary>
	/// Summary description for DMSS107
	/// </summary>
	public partial class DMSS107 : BOSERPScreen
	{

		public DMSS107()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void bosButton3_Click(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).AddItemToTransferList();
        }

        private void bosButton2_Click(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).RemoveSelectedItemFromTransferList();
        }

        private void bosButton1_Click(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).ChangeSelectedItemFromTransferList();
        }
	}
}
