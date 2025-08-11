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
    public partial class guiUsersOfGroup : BOSERPScreen
    {
        public ADUserGroupsInfo _group { get; set; }

        public guiUsersOfGroup(ADUserGroupsInfo group)
        {
            InitializeComponent();
            _group = group;
            this.Text = $"Danh sách người dùng của nhóm [{_group.ADUserGroupName }]";
        }

        public override void InitializeControls()
        {
            base.InitializeControls();
            var entity = (UserManagementEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.ADUserOfGroupList.InitBOSListGridControl(fld_dgcADUsersOfGroup);
            fld_dgcADUsersOfGroup.Screen = this;
            fld_dgcADUsersOfGroup.InitializeControl();
            ((UserManagementModule)Module).InvalidateADUsersOfGroup();


            entity.ADUserExtraOfGroupList.InitBOSListGridControl(fld_dgcADUserGroupExtras);
            fld_dgcADUserGroupExtras.Screen = this;
            fld_dgcADUserGroupExtras.InitializeControl();
            ((UserManagementModule)Module).InvalidateExtraUsersOfGroup();
        }

        private void fld_btnSave_Click(object sender, EventArgs e)
        {
            if (((UserManagementModule)Module).SaveUserExtraOfGroups())
                this.Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
