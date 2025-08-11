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
    public partial class guiTemplates : BOSERPScreen
    {
        private ADUserGroupsInfo _userGroup;

        public guiTemplates(ADUserGroupsInfo userGroup)
        {
            InitializeComponent();
            _userGroup = userGroup;
            Text = Text + $" Nhóm người dùng: [{userGroup.ADUserGroupName}]";
        }

        public override void InitializeControls()
        {
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.METemplateList.InitBOSListGridControl(fld_dgcMETemplates);
            fld_dgcMETemplates.Screen = this;
            fld_dgcMETemplates.InitializeControl();
            ((UserManagementModule)Module).InvalidateTemplates(_userGroup);
        }

        private void fld_btnSave_Click(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).SaveTemplates(_userGroup);
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fld_chkChooseAll_CheckedChanged(object sender, EventArgs e)
        {
            ((UserManagementModule)Module).ChooseAllTemplates(fld_chkChooseAll.Checked);
        }
    }
}
