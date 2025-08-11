using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSERP.Modules.Common;
using Localization;

namespace BOSERP
{
    public partial class guiOpenCashDrawer : BOSERPScreen
    {
        public guiOpenCashDrawer()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CommonModule module = (CommonModule)this.Module;
            if (string.IsNullOrEmpty(fld_txtPassword.Text))
            {
                MessageBox.Show(CommonLocalizedResources.PasswordIsRequiredMessage,
                                CommonLocalizedResources.MessageBoxDefaultCaption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                fld_txtPassword.Focus();
            }
            else if (module.CheckPassword(fld_txtPassword.Text))
            {
                module.UpdateHistory(fld_txtDesc.Text);
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu không đúng.",
                                CommonLocalizedResources.MessageBoxDefaultCaption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
