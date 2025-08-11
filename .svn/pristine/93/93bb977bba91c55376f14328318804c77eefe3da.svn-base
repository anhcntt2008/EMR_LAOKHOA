using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Localization;

namespace BOSERP.Modules.SellStaff
{
    public partial class guiAddCountry : BOSERPScreen
    {
        public guiAddCountry()
        {
            InitializeComponent();
        }

        public guiAddCountry( String lblname, String lblcode,String txtname, String txtcode)
        {
            InitializeComponent();
            fld_txtAttributeName.Text = lblcode;
            fld_txtAttributeCode.Text = lblname;           
            fld_lblCode.Text = txtcode;
            fld_lblName.Text = txtname;
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fld_txtAttributeCode.Text))
            {
                MessageBox.Show(SellStaffLocalizedResource.CountryNameRequiredMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void guiAttributeInput_Load(object sender, EventArgs e)
        {
            fld_txtAttributeCode.Focus();
        }
    }
}