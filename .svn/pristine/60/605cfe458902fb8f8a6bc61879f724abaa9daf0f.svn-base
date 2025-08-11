using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSLib;
using DevExpress.XtraEditors;
using Localization;

namespace BOSERP.Modules.UserManagement
{
    public partial class guiInventoryPermission : BOSERPScreen
    {
        public guiInventoryPermission()
        {
            InitializeComponent();
        }

        public override void InitializeControls()
        {
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.InventoryPermissionsList.InitBOSListGridControl(fld_dgcICInventoryPermissions);
            fld_dgcICInventoryPermissions.Screen = this;
            fld_dgcICInventoryPermissions.InitializeControl();
            ((UserManagementModule)Module).InvalidateInventoryPermissionList();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fld_btnSave_Click(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).SaveInventoryPermission();
        }

        private void fld_chkChooseAll_CheckedChanged(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).ChooseAllStocks(fld_chkChooseAll.Checked);
        }
    }
}
