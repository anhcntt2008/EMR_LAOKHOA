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
    public partial class guiObjectStatePermission : BOSERPScreen
    {
        public ADUserGroupsInfo _group { get; set; }

        public guiObjectStatePermission(ADUserGroupsInfo group)
        {
            InitializeComponent();
            _group = group;
            this.Text = $"Phân quyền truy xuất dữ liệu nhóm [{_group.ADUserGroupName }]";
        }

        public override void InitializeControls()
        {
            base.InitializeControls();
            var entity = (UserManagementEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.ObjectStatePermissionList.InitBOSListGridControl(fld_dgcSTObjectStatePermissions);
            fld_dgcSTObjectStatePermissions.Screen = this;
            fld_dgcSTObjectStatePermissions.InitializeControl();
            ((UserManagementModule)Module).InvalidateObjectStatePermissionsList();
        }

        private void fld_btnSave_Click(object sender, EventArgs e)
        {
            if (((UserManagementModule)Module).SaveObjectStatePermissions())
                this.Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
