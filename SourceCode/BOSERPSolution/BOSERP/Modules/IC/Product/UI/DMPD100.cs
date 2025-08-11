using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.Product.UI
{
	/// <summary>
	/// Summary description for DMPD100
	/// </summary>
	public partial class DMPD100 : BOSERPScreen
	{
		public DMPD100()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}        

        private void fld_lnkEditPrice_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            ((ProductModule)Module).ShowPriceLevelForm();
        }

        private void fld_lnkEditUnitOfMeasure_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            ((ProductModule)Module).ShowMeasureOfUnits();
        }

        private void fld_bedICProductAttribute_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ((ProductModule)Module).ShowEditAttributeForm();
        }

        private void fld_btnMoveUp_Click(object sender, EventArgs e)
        {
            ((ProductModule)Module).SortProductComponentList("MoveUp");
        }

        private void fld_btnMoveDown_Click(object sender, EventArgs e)
        {
            ((ProductModule)Module).SortProductComponentList("MoveDown");
        }

        private void fld_lnkOpenSupplier_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            ((ProductModule)Module).ShowSuppliersForm();
        }

        private void fld_lnkOpenBranchPrice_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            ((ProductModule)Module).ShowProductBranchPrice();
        }

        private void fld_lnkSetDefaultDesc_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            ((ProductModule)Module).SetDefaultProductDesc();
        }

        private void fld_lnkEditPurchasePrice_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            ((ProductModule)Module).EditPurchasePriceByCurrency();
        }

        private void fld_bedFK_ICProductGroupID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ((ProductModule)Module).ShowCategoryTree();
        }
        private void fld_lnkShowHistoryBranchPrice_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            ((ProductModule)Module).ShowProductBranchPriceHistory();
        }

        private void fld_txtICProductNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void fld_txtICProductNo_KeyUp_1(object sender, KeyEventArgs e)
        {
            BOSTextBox text = (BOSTextBox)sender;
            if (text.Text.Length > 4)
            {
                ((ProductModule)Module).FindSameProduct(text.Text);
            }
        }
	}
}
