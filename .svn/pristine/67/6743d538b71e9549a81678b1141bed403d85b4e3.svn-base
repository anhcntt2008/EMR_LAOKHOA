using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace BOSERP.Modules.SellStaff.UI
{
	/// <summary>
	/// Summary description for DMSS103
	/// </summary>
	public partial class DMSS103 : BOSERPScreen
	{

		public DMSS103()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
            // Load leave days config


            fld_dteFrom.EditValue = DateTime.Now;
            fld_dteTo.EditValue = DateTime.Now;
        }

        private void fld_btnShow_Click(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).ShowHistoryDetails();
            ((SellStaffModule)Module).ShowEmployeeRewardHistory();
            ((SellStaffModule)Module).ShowEmployeeDisciplineHistory();
            ((SellStaffModule)Module).ShowEmployeeAllowanceHistory();
            ((SellStaffModule)Module).ShowAdvanceRequestHistory();
            //((SellStaffModule)Module).ShowDeliverysHistory();
            ((SellStaffModule)Module).ShowLeaveDayHistory();
        }

   }
}
