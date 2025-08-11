using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSLib;
using Localization;

namespace BOSERP
{
    public partial class guiChangePassword : Form
    {
        public guiChangePassword()
        {
            InitializeComponent();
        }
        
        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fld_btnLogin_Click(object sender, EventArgs e)
        {
            if (BOSApp.IsAuthenticated(fld_txtUserName.Text, fld_txtCurrentPassword.Text) == false)
            {
                MessageBox.Show(BaseLocalizedResources.InvalidCurrentPassword, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (fld_txtNewPassword.Text != fld_txtConfirmNewPassword.Text)
            {
                MessageBox.Show(BaseLocalizedResources.InvalidConfirmNewPassword, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BOSApp.ChangePassword(fld_txtUserName.Text, fld_txtNewPassword.Text);
            this.Dispose();
        }

        private void guiChangePassword_Load(object sender, EventArgs e)
        {
            fld_txtUserName.Text = BOSApp.CurrentUsersInfo.ADUserName;
        }
    }
}