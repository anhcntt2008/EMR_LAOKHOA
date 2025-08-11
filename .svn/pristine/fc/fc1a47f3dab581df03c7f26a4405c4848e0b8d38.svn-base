using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSLib;
using BOSComponent;

namespace BOSERP.Modules.UserManagement
{
    public partial class guiConfigureToolbar : BOSERPScreen
    {
        public guiConfigureToolbar()
        {
            InitializeComponent();
        }

        private void guiConfigureToolbar_Load(object sender, EventArgs e)
        {
            InitializeControls();
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)this.Module).CurrentModuleEntity;
            entity.STToolbarsTreeList.InitBOSTreeListControl(fld_trlstSTToolbars);
        }

        public override void InitializeControls()
        {
            base.InitializeControls();
            fld_trlstSTToolbars.Screen = this;
            fld_trlstSTToolbars.InitializeControl();
        }

        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Save the permissions of the toolbars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fld_btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
