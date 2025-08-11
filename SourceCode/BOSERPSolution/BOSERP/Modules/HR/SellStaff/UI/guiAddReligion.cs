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
    public partial class guiAddReligion : BOSERPScreen
    {
        public guiAddReligion()
        {
            InitializeComponent();
        }

        public guiAddReligion(String txtname, String txtcode)
        {
            InitializeComponent();
            fld_lblName.Text = txtname;
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fld_txtAttributeName.Text))
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
            fld_txtAttributeName.Focus();
        }
    }
}