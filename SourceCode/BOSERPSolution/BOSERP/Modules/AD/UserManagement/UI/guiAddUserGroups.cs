using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using BOSLib;
using Localization;

namespace BOSERP.Modules.UserManagement
{
    public enum AddUserGroupMode { Add, Edit }

    public partial class guiAddUserGroups : BOSERPScreen
    {
        private TreeList TreeList = null;
        private AddUserGroupMode Mode;
        private ADUserGroupsController _objUserGroupsController;
        private ADUserGroupSectionsController _objUserGroupSectionsController;
        private STModuleToUserGroupSectionsController _objModuleToUserGroupSectionsController;
        private STFieldPermissionsController _objFieldPermissionsController;
        public guiAddUserGroups(TreeList treeList, AddUserGroupMode mode)
        {
            InitializeComponent();
            TreeList = treeList;
            Mode = mode;
            _objUserGroupsController = new ADUserGroupsController();
            _objUserGroupSectionsController = new ADUserGroupSectionsController();
            _objModuleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();
            _objFieldPermissionsController = new STFieldPermissionsController();
            fld_lkeCopyUserGroup.Properties.DisplayMember = "ADUserGroupName";
            fld_lkeCopyUserGroup.Properties.ValueMember = "ADUserGroupID";
        }

        private void fld_btnCloseUserGroup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void fld_btnAddUserGroup_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fld_txtUserGroup.Text))
            {
                MessageBox.Show(UserManagementLocalizedResources.UserGroupNameRequiredMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Mode == AddUserGroupMode.Add)
            {
                ADUserGroupsInfo objADUserGroupsInfo = new ADUserGroupsInfo();
                objADUserGroupsInfo.ADUserGroupName = fld_txtUserGroup.Text;
                objADUserGroupsInfo.ADLanguageIDCombo = 1;
                objADUserGroupsInfo.ADUserGroupDesc = fld_txtUserGroup.Text;
                objADUserGroupsInfo.ADUserGroupRole = fld_lkeUserGroupRole.EditValue?.ToString();
                objADUserGroupsInfo.ADUserGroupEmrView = fld_lkeUserGroupEmrView.EditValue?.ToString();
                _objUserGroupsController.CreateObject(objADUserGroupsInfo);
                if (!string.IsNullOrEmpty(fld_lkeCopyUserGroup.EditValue?.ToString()) && int.Parse(fld_lkeCopyUserGroup.EditValue?.ToString()) > 0)
                {
                    CopyUserGroup(_objUserGroupsController.GetMaxID());
                }
            }
            else if (Mode == AddUserGroupMode.Edit)
            {
                ADUserGroupsInfo objADUserGroupsInfo = (ADUserGroupsInfo)_objUserGroupsController.GetObjectByID(Convert.ToInt32(TreeList.FocusedNode.Tag));
                objADUserGroupsInfo.ADUserGroupName = fld_txtUserGroup.Text;
                objADUserGroupsInfo.ADUserGroupDesc = fld_txtUserGroup.Text;
                objADUserGroupsInfo.ADUserGroupRole = fld_lkeUserGroupRole.EditValue?.ToString();
                objADUserGroupsInfo.ADUserGroupEmrView = fld_lkeUserGroupEmrView.EditValue?.ToString();
                _objUserGroupsController.UpdateObject(objADUserGroupsInfo);
                if (!string.IsNullOrEmpty(fld_lkeCopyUserGroup.EditValue?.ToString()) && int.Parse(fld_lkeCopyUserGroup.EditValue?.ToString()) > 0)
                {
                    var dsUserGroupSection = _objUserGroupSectionsController.GetUserGroupSectionByUserGroupID(objADUserGroupsInfo.ADUserGroupID);
                    if (dsUserGroupSection.Tables.Count > 0 && dsUserGroupSection.Tables[0].Rows.Count > 0)
                    {
                        if (MessageBox.Show("Nhóm người dùng đã có nhóm module, có muốn thay thế?", "Xác nhận thay thế", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _objUserGroupSectionsController.DeleteByForeignColumn("ADUserGroupID", objADUserGroupsInfo.ADUserGroupID);
                            _objFieldPermissionsController.DeleteByForeignColumn("FK_ADUserGroupID", objADUserGroupsInfo.ADUserGroupID);
                            CopyUserGroup(objADUserGroupsInfo.ADUserGroupID);
                        }
                    }
                    else
                    {
                        CopyUserGroup(objADUserGroupsInfo.ADUserGroupID);
                    }
                }
            }
            ((UserManagementModule)this.Module).InitializeTreeList(TreeList);
            this.Close();
        }

        private void guiAddUserGroups_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fld_txtUserGroup.Text))
            {
                var group = _objUserGroupsController.GetObjectByName(fld_txtUserGroup.Text) as ADUserGroupsInfo;
                if (group != null)
                {
                    fld_lkeUserGroupRole.EditValue = group.ADUserGroupRole;
                    fld_lkeUserGroupEmrView.EditValue = group.ADUserGroupEmrView;
                }
            }
        }

        private void CopyUserGroup(int adUserGroupID)
        {
            int adUserGroupIDCopy = int.Parse(fld_lkeCopyUserGroup.EditValue?.ToString());
            var ds = _objUserGroupSectionsController.GetUserGroupSectionByUserGroupID(adUserGroupIDCopy);
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ADUserGroupSectionsController objUserGroupSectionsController = new ADUserGroupSectionsController();
                    ADUserGroupSectionsInfo adUserGroupSectionsInfo = new ADUserGroupSectionsInfo();
                    adUserGroupSectionsInfo = (ADUserGroupSectionsInfo)objUserGroupSectionsController.GetObjectFromDataRow(ds.Tables[0].Rows[i]);
                    adUserGroupSectionsInfo.ADUserGroupSectionID = 0;
                    adUserGroupSectionsInfo.ADUserGroupID = adUserGroupID;
                    objUserGroupSectionsController.CreateObject(adUserGroupSectionsInfo);

                    int newADUserGroupSectionID = objUserGroupSectionsController.GetMaxID();
                    var dsSTModuleToUserGroupSections = _objModuleToUserGroupSectionsController.GetAllModuleToUserGroupSectionByUserGroupSectionID(Convert.ToInt32(ds.Tables[0].Rows[i]["ADUserGroupSectionID"]));
                    if (dsSTModuleToUserGroupSections.Tables.Count > 0)
                    {
                        for (int j = 0; j < dsSTModuleToUserGroupSections.Tables[0].Rows.Count; j++)
                        {
                            STModuleToUserGroupSectionsController objModuleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();
                            STModuleToUserGroupSectionsInfo stModuleToUserGroupSectionsInfo = new STModuleToUserGroupSectionsInfo();
                            stModuleToUserGroupSectionsInfo = (STModuleToUserGroupSectionsInfo)objModuleToUserGroupSectionsController.GetObjectFromDataRow(dsSTModuleToUserGroupSections.Tables[0].Rows[j]);
                            stModuleToUserGroupSectionsInfo.STModuleToUserGroupSectionID = 0;
                            stModuleToUserGroupSectionsInfo.STUserGroupSectionID = newADUserGroupSectionID;
                            objModuleToUserGroupSectionsController.CreateObject(stModuleToUserGroupSectionsInfo);
                        }
                    }
                }
            }

            var dsfieldPermissionList = _objFieldPermissionsController.GetAllDataByForeignColumn("FK_ADUserGroupID", adUserGroupIDCopy);
            if (dsfieldPermissionList.Tables.Count > 0)
            {
                for (int i = 0; i < dsfieldPermissionList.Tables[0].Rows.Count; i++)
                {
                    STFieldPermissionsController objFieldPermissionsController = new STFieldPermissionsController();
                    STFieldPermissionsInfo stFieldPermissionsInfo = new STFieldPermissionsInfo();
                    stFieldPermissionsInfo = (STFieldPermissionsInfo)objFieldPermissionsController.GetObjectFromDataRow(dsfieldPermissionList.Tables[0].Rows[i]);
                    stFieldPermissionsInfo.STFieldPermissionID = 0;
                    stFieldPermissionsInfo.FK_ADUserGroupID = adUserGroupID;
                    objFieldPermissionsController.CreateObject(stFieldPermissionsInfo);

                }
            }
        }


    }
}