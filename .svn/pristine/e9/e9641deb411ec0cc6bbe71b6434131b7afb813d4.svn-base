using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.ImportData.UI
{
	/// <summary>
	/// Summary description for DMID100
	/// </summary>
	public partial class DMID100 : BOSERPScreen
	{

		public DMID100()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void fld_btnImportProduct_Click(object sender, EventArgs e)
        {
            ((ImportDataModule)Module).ImportProductFromExcel();
        }

        private void fld_btnImportSupplier_Click(object sender, EventArgs e)
        {
            ((ImportDataModule)Module).ImportSupplierFromExcel();
        }

        private void fld_btnImportStock_Click(object sender, EventArgs e)
        {
            ((ImportDataModule)Module).ImportStockFromExcel();
        }

        private void fld_btnImportBranch_Click(object sender, EventArgs e)
        {
            ((ImportDataModule)Module).ImportBranchFromExcel();
        }

        private void fld_btnImportEmployee_Click(object sender, EventArgs e)
        {
            ((ImportDataModule)Module).ImportEmployeeFromExcel();
        }

        private void fld_btnImportCustomer_Click(object sender, EventArgs e)
        {
            ((ImportDataModule)Module).ImportCustomerFromExcel();
        }

        private void fld_btnExportProduct_Click(object sender, EventArgs e)
        {
            ((ImportDataModule)Module).ExportProduct();
        }

        private void fld_btnUpdateInventoryCost_Click(object sender, EventArgs e)
        {
            ((ImportDataModule)Module).UpdateInventoryCost();
        }

        private void fld_btnUpdateProductPrice_Click(object sender, EventArgs e)
        {
            ((ImportDataModule)Module).UpdateProductPrice();
        }        

        private void fld_btnSyncInventory_Click(object sender, EventArgs e)
        {
            ((ImportDataModule)Module).SyncInventory();
        }

        private void fld_btnCreateProgressNote_Click(object sender, EventArgs e)
        {
            ((ImportDataModule)Module).CreateProgessNote();
        }
    }
}
