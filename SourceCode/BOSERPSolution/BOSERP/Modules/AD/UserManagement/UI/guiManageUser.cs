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
using BOSERP;

namespace BOSERP.Modules.UserManagement
{
    public partial class guiManageUser : BOSERPScreen
    {
        private ADUserGroupsController _groupCtrl;

        public guiManageUser()
        {
            InitializeComponent();
            _groupCtrl = new ADUserGroupsController();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void guiManageUser_Load(object sender, EventArgs e)
        {
            //fld_lkeEndTime.Screen = this;
            //fld_lkeEndTime.InitializeControl();
            //fld_lkeEndTime.InvalidateDataSourceToLookupEdit();
            MEEndTimeFrameValuesController objEndTimeController = new MEEndTimeFrameValuesController();
            List<MEEndTimeFrameValuesInfo> list = objEndTimeController.GetListAllTime();
            InitializeControls(Controls);
            fld_lkeEndTime.Properties.DataSource = list;
            fld_lkeEndTime.EditValue = list[0].ADUserEndTimeDefault;
           
        }

        public override void InitializeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl);
                if (ctrl.Controls.Count > 0)
                {
                    InitializeControls(ctrl.Controls);
                }
            }
        }

        /// <summary>
        /// Check the user whether it is proper or not
        /// </summary>
        /// <returns></returns>
        private bool IsValidInput()
        {
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            ADUsersInfo objUsersInfo = (ADUsersInfo)entity.ModuleObjects[TableName.ADUsersTableName];
            if (string.IsNullOrEmpty(objUsersInfo.ADUserName))
            {
                MessageBox.Show(UserManagementLocalizedResources.UserNameRequiredMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            ADUsersController objUsersController = new ADUsersController();
            ADUsersInfo existingUser = (ADUsersInfo)objUsersController.GetObjectByName(objUsersInfo.ADUserName);
            if (existingUser != null && existingUser.ADUserID != objUsersInfo.ADUserID)
            {
                MessageBox.Show(UserManagementLocalizedResources.UserNameExistsMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (objUsersInfo.ADUserID == 0)
            {
                if (String.IsNullOrEmpty(objUsersInfo.ADPassword))
                {
                    MessageBox.Show(UserManagementLocalizedResources.PasswordRequiredMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(objUsersInfo.ADPassword) && objUsersInfo.ADPassword != fld_txtConfirmPassword.Text)
            {
                MessageBox.Show(UserManagementLocalizedResources.PasswordNotMatchMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            objUsersInfo.ADUserEndTimeDefault = Convert.ToInt16(fld_lkeEndTime.EditValue);
            entity.UpdateModuleObjectBindingSource(TableName.ADUsersTableName);
            return true;
        }
        
        private void fld_btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidInput())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void fld_lkeUserGroup_EditValueChanged(object sender, EventArgs e)
        {
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            ADUsersInfo objUsersInfo = (ADUsersInfo)entity.ModuleObjects[TableName.ADUsersTableName];
            if (string.IsNullOrEmpty(objUsersInfo.ADUserEmrView))
            {
                var group = _groupCtrl.GetObjectByID(objUsersInfo.ADUserGroupID) as ADUserGroupsInfo;
                objUsersInfo.ADUserEmrView = group.ADUserGroupEmrView;
                entity.UpdateModuleObjectBindingSource(TableName.ADUsersTableName);
            }
        }
    }
}