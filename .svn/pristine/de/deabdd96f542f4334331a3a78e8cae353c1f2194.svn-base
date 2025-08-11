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
    public partial class guiLogin : Form
    {
        public guiLogin()
        {
            InitializeComponent();
        }
        
        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void fld_btnLogin_Click(object sender, EventArgs e)
        {
            if (BOSApp.IsAuthenticated(fld_txtUserName.Text, fld_txtPassword.Text))
            {
                BOSApp.SetCurrentUserLogin(fld_txtUserName.Text);

                //Set language                
                int languageID = Convert.ToInt32(fld_lkeLanguage.EditValue);                
                if (languageID > 0)
                {
                    BOSApp.SetAppLanguage(languageID);  
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show(BaseLocalizedResources.InvalidAuthenticationMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void guiLogin_Load(object sender, EventArgs e)
        {
            GELanguagesController objLanguagesController = new GELanguagesController();
            DataSet ds = objLanguagesController.GetAllObjects();
            if (ds.Tables.Count > 0)
            {
                fld_lkeLanguage.Properties.DataSource = ds.Tables[0];
                fld_lkeLanguage.EditValue = Language.Default;
            }
        }
    }
}