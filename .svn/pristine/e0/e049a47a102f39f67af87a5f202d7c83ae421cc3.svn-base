using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.Branch.UI
{
	/// <summary>
	/// Summary description for DMBR100
	/// </summary>
	public partial class DMBR100 : BOSERPScreen
	{

		public DMBR100()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void fld_bedGELocationName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ((BranchModule)Module).ChooseLocation();
        }

        private void fld_btnAutoCHBase_Click(object sender, EventArgs e)
        {
            ((BranchModule) Module).ConfigAutoUploadCHBase();}

        private void fld_btnResetTo1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Bạn chắc chắn đặt lại số thứ tự hóa đơn bảo hiểm y tế về giá trị '1'?", @"Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            fld_txtInvoiceNo.EditValue = 1;
        }
    }
}
