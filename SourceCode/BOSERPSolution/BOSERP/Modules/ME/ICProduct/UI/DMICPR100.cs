using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.ICProduct.UI
{
	/// <summary>
	/// Summary description for DMICPR100
	/// </summary>
	public partial class DMICPR100 : BOSERPScreen
	{

		public DMICPR100()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void fld_lnkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((ICProductModule)Module).ShowMeasureOfUnits();
        }

        private void fld_lkeFK_ICProductBasicUnitID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            int basicUnitID = Convert.ToInt32(e.Value);
            int oldBasicUnitID = Convert.ToInt32(((BOSLookupEdit)sender).OldEditValue);
            if (basicUnitID != oldBasicUnitID)
            {
                ((ICProductModule)Module).ChangeBasicUnit(basicUnitID);
            }
        }
        
        private void fld_rdgMedicineDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((ICProductModule)Module).InvalidateScreen();
        }

        private void fld_txtICProductPrice01_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void fld_txtICProductSupplierPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void fld_txtICProductStockMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void fld_txtICProductStockMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void fld_lnkSetDefaultDesc_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            ((ICProductModule)Module).SetDefaultProductDesc();
        }
	}
}
