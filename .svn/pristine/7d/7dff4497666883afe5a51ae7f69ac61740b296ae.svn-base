using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEService.UI
{
	/// <summary>
	/// Summary description for DMSE101
	/// </summary>
	public partial class DMSE101 : BOSERPScreen
	{

		public DMSE101()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}
        
        private void fld_btnView_Click(object sender, EventArgs e)
        {
            ((MEServiceModule)Module).ViewCommission();
        }

        private void fld_btnExportToExcel_Click(object sender, EventArgs e)
        {
            ((MEServiceModule)Module).ExportCommissionToExcel();
        }

        private void fld_btnImportFromExcel_Click(object sender, EventArgs e)
        {
            ((MEServiceModule)Module).ImportCommissionFromExcel();
        }

        private void fld_txtFile_Click(object sender, EventArgs e)
        {
            ((MEServiceModule)Module).ChooseFile();
        }

        private void fld_lkeICProductGroupID_EditValueChanged(object sender, EventArgs e)
        {
            ((MEServiceModule)Module).InvalidateProductByProductGroup();
        }

        private void fld_btnSave_Click(object sender, EventArgs e)
        {
            ((MEServiceModule)Module).SaveProductEmployeeList();
        }
	}
}
