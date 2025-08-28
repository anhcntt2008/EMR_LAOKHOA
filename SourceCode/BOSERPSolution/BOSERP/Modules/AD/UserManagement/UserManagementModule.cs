using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using BOSCommon;
using BOSLib;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Localization;
using System.Linq;
using System.Collections;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using System.Text.RegularExpressions;
using DevExpress.XtraRichEdit.Menu;

namespace BOSERP.Modules.UserManagement
{
    public class UserManagementModule : BaseModuleERP
    {
        #region Private Variable
        private bool moduleStart = false;
        public DataTable tableResult = new DataTable();
        private guiListUsers guiListUsers;
        private List<ADDataViewPermissionsInfo> originalDataViewPermissionList;

        private const string EndTimeDefaultName = "fld_lkeEndTime";
        private readonly UserManagementEntities _entity;
        #endregion

        #region Public variables
        private readonly string Add = "Add";
        private readonly string Delete = "Delete";
        #endregion Public variables

        #region Properties
        /// <summary>
        /// List of all command permission of an user group
        /// </summary>
        private List<MECommandPermissionsInfo> CommandPermissionList;
        private ADUserGroupExtrasController _userGroupExtrasCtrl;
        /// <summary>
        /// Gets or sets the current user group
        /// </summary>
        public ADUserGroupsInfo CurrentUserGroup { get; set; }
        /// <summary>
        /// Gets or sets the current module
        /// </summary>
        public STModulesInfo CurrentModule { get; set; }
        /// <summary>
        /// Gets or sets the current screen
        /// </summary>
        public BOSERPScreen CurrentScreen { get; set; }
        #endregion

        public UserManagementModule()
        {
            Name = BaseModuleERP.cstUserManagementModule;
            _entity = new UserManagementEntities();
            CurrentModuleEntity = _entity;

            CurrentModuleEntity.Module = this;
            if (BOSApp.LookupTables["ADUserGroups"] == null)
                BOSApp.InitLookupByTable("ADUserGroups");
            InitializeModule();
            _userGroupExtrasCtrl = new ADUserGroupExtrasController();
        }

        public override void InitializeScreens()
        {
            guiUserManagement _guiUserManagement = new guiUserManagement();
            _guiUserManagement.ScreenNumber = "DMUM100";
            _guiUserManagement.Module = this;
            Screens.Add(_guiUserManagement);
            InitializeTreeList(_guiUserManagement.fld_trlstUserGroup);

            _guiUserManagement.AddControlsToParentScreen();

            guiListUsers = new guiListUsers();
            guiListUsers.ScreenNumber = "DMUM101";
            guiListUsers.Module = this;
            Screens.Add(guiListUsers);
            guiListUsers.InitializeScreen();
            guiListUsers.AddControlsToParentScreen();

            InvalidateUserList();
            InvalidateEndTimeList();

        }

        #region initialze treelist
        public void InitializeTreeList(TreeList fld_trlstUserGroup)
        {
            List<ADUserGroupsInfo> lstNode = new List<ADUserGroupsInfo>();
            TreeListNode prevFocusedNode = fld_trlstUserGroup.FocusedNode;
            fld_trlstUserGroup.Nodes.Clear();
            ADUserGroupsController objADUserGroupsController = new ADUserGroupsController();
            DataSet dsADUserGroups = objADUserGroupsController.GetAllObjects();
            if (dsADUserGroups != null)
            {
                foreach (DataRow row in dsADUserGroups.Tables[0].Rows)
                {
                    ADUserGroupsInfo objADUserGroupsInfo = (ADUserGroupsInfo)objADUserGroupsController.GetObjectFromDataRow(row);
                    if (objADUserGroupsInfo != null)
                    {
                        lstNode.Add(objADUserGroupsInfo);
                    }
                }
            }
            CreateTreeView(fld_trlstUserGroup, lstNode, null);
            if (prevFocusedNode != null)
            {
                TreeListNode currentFocusedNode = fld_trlstUserGroup.FindNodeByID(prevFocusedNode.Id);
                while (currentFocusedNode != null)
                {
                    if (currentFocusedNode.Level > 0)
                    {
                        currentFocusedNode.ExpandAll();
                    }
                    else
                    {
                        currentFocusedNode.Expanded = true;
                    }
                    currentFocusedNode = currentFocusedNode.ParentNode;
                }
            }
        }

        private void CreateTreeView(TreeList fld_trlstUserGroup, List<ADUserGroupsInfo> lstNodeName, DevExpress.XtraTreeList.Nodes.TreeListNode ParentNode)
        {
            fld_trlstUserGroup.BeginUnboundLoad();
            TreeListNode treeListNode;
            var rootNode = fld_trlstUserGroup.AppendNode(new object[] { UserManagementLocalizedResources.UserGroup, 0 }, ParentNode);
            treeListNode = rootNode;
            fld_trlstUserGroup.Columns[0].Width = 300;
            for (int i = 0; i < lstNodeName.Count; i++)
            {
                treeListNode = fld_trlstUserGroup.AppendNode(new object[] { lstNodeName[i].ADUserGroupName, 1 }, 0);
                treeListNode.Tag = lstNodeName[i].ADUserGroupID;
                treeListNode.HasChildren = HasChild(lstNodeName[i].ADUserGroupID);
                if (treeListNode.HasChildren)
                {
                    ADUserGroupSectionsController objUserGroupSectionsController = new ADUserGroupSectionsController();
                    DataSet dsUserGroupChild = objUserGroupSectionsController.GetUserGroupSectionByUserGroupID(lstNodeName[i].ADUserGroupID);
                    if (dsUserGroupChild != null)
                    {
                        foreach (DataRow row in dsUserGroupChild.Tables[0].Rows)
                        {
                            ADUserGroupSectionsInfo objADUserGroupSectionsInfo = (ADUserGroupSectionsInfo)objUserGroupSectionsController.GetObjectFromDataRow(row);
                            if (objADUserGroupSectionsInfo != null)
                            {
                                TreeListNode treeListChildNode = fld_trlstUserGroup.AppendNode(new object[] { objADUserGroupSectionsInfo.ADUserGroupSectionName, treeListNode.Level + 1 }, treeListNode);
                                treeListChildNode.Tag = objADUserGroupSectionsInfo.ADUserGroupSectionID;
                                AddModuleNode(fld_trlstUserGroup, objADUserGroupSectionsInfo.ADUserGroupSectionID, treeListChildNode);
                            }
                        }
                    }

                }
            }
            fld_trlstUserGroup.EndUnboundLoad();
            rootNode.Expand();
        }
        private void AddModuleNode(TreeList fld_trlstUserGroup, int iUserGroupSectionID, TreeListNode parentNode)
        {
            STModuleToUserGroupSectionsController objSTModuleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();
            DataSet dsModuleUserGroupSections = objSTModuleToUserGroupSectionsController.GetAllModuleToUserGroupSectionByUserGroupSectionID(iUserGroupSectionID);
            if (dsModuleUserGroupSections != null)
            {
                foreach (DataRow row in dsModuleUserGroupSections.Tables[0].Rows)
                {
                    STModuleToUserGroupSectionsInfo objSTModuleToUserGroupSectionsInfo = (STModuleToUserGroupSectionsInfo)objSTModuleToUserGroupSectionsController.GetObjectFromDataRow(row);
                    if (objSTModuleToUserGroupSectionsInfo != null)
                    {
                        STModulesInfo objSTModulesInfo = (STModulesInfo)new STModulesController().GetObjectByID(objSTModuleToUserGroupSectionsInfo.STModuleID);
                        STModuleDescriptionsController objModuleDescriptionsController = new STModuleDescriptionsController();
                        STModuleDescriptionsInfo objModuleDescriptionsInfo = (STModuleDescriptionsInfo)objModuleDescriptionsController.GetModuleDescriptionByModuleNameAndLanguageName(objSTModulesInfo.STModuleName, BOSApp.CurrentLang);
                        objSTModulesInfo.STModuleDescription = objModuleDescriptionsInfo.STModuleDescriptionDescription;
                        if (objSTModulesInfo != null)
                        {
                            TreeListNode treeListModuleNode = fld_trlstUserGroup.AppendNode(new object[] { objSTModulesInfo.STModuleDescription, parentNode.Level + 1 }, parentNode);
                            treeListModuleNode.Tag = objSTModulesInfo.STModuleID;
                        }
                    }
                }
            }
        }
        public bool HasChild(int iUserGroupID)
        {
            DataSet ds = new ADUserGroupSectionsController().GetAllDataByForeignColumn("ADUserGroupID", iUserGroupID);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }
        #endregion

        #region User
        public void AddUser()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            entity.SetDefaultModuleObject(TableName.ADUsersTableName);
            guiManageUser _guiManageUser = new guiManageUser();
            _guiManageUser.Module = this;
            if (_guiManageUser.ShowDialog() == DialogResult.OK)
            {
                entity.SaveUser();
            }
            InvalidateUserList();
        }

        public void EditUser()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            if (entity.ADUserList.CurrentIndex >= 0)
            {
                guiManageUser _guiManageUser = new guiManageUser();
                _guiManageUser.Module = this;
                ADUsersInfo objUsersInfo = (ADUsersInfo)entity.ModuleObjects[TableName.ADUsersTableName];
                var dataPriv = objUsersInfo.Clone() as ADUsersInfo; // Prevent edit user system
                objUsersInfo.ADPassword = string.Empty;
                objUsersInfo.ADUserCaPasscode = objUsersInfo.ADUserCaPasscode;
                entity.UpdateModuleObjectBindingSource(TableName.ADUsersTableName);
                if (_guiManageUser.ShowDialog() == DialogResult.OK)
                {
                    #region Prevent edit user system
                    var configUsers = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_USERS_SYSTEM);
                    if (!string.IsNullOrEmpty(configUsers))
                    {
                        var userArr = configUsers.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
                        if (userArr.Contains(dataPriv.ADUserName))
                        {
                            entity.ModuleObjects[TableName.ADUsersTableName] = dataPriv;
                            MessageBox.Show("Người dùng này được cấu hình không thay đổi thông tin. Cấu hình lại hoặc liên hệ IT hỗ trợ.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    #endregion

                    entity.SaveUser();
                    InvalidateUserList();
                }
            }
        }

        public void DeleteUser()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            if (entity.ADUserList.CurrentIndex >= 0)
            {
                if (MessageBox.Show(UserManagementLocalizedResources.ConfirmDeleteUserMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    GEUsingHistoryController objUsingHistoryController = new GEUsingHistoryController();
                    ADUsersInfo objUsersInfo = entity.ADUserList[entity.ADUserList.CurrentIndex];
                    var configUsers = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_USERS_SYSTEM);
                    if (!string.IsNullOrEmpty(configUsers))
                    {
                        var userArr = configUsers.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
                        if (userArr.Contains(objUsersInfo.ADUserName))
                        {
                            MessageBox.Show("Người dùng này được cấu hình không thể xóa. Cấu hình lại hoặc liên hệ IT hỗ trợ.", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    if (objUsingHistoryController.CheckUserLogged(objUsersInfo.ADUserID))
                    {
                        MessageBox.Show("Người dùng đã sử dụng, không được phép xóa!", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        entity.DeleteUser(objUsersInfo.ADUserID);
                        InvalidateUserList();
                        MessageBox.Show("Xóa Người dùng thành công!", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// Invalidate user list
        /// </summary>
        public void InvalidateUserList()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            ADUsersController objUsersController = new ADUsersController();
            var configUsersDisplay = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_USERS_SYSTEM_DISPLAY);
            var configUsers = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_USERS_SYSTEM);
            DataSet ds = new DataSet();
            if (!string.IsNullOrEmpty(configUsersDisplay) && !Boolean.Parse(configUsersDisplay) && !string.IsNullOrEmpty(configUsers))
            {
                string userNames = "'" + configUsers.Replace(";", "','") + "'";
                ds = objUsersController.GetAllUserNotUserSystem(userNames);
            }
            else
                ds = objUsersController.GetAllObjects();
            entity.ADUserList.Invalidate(ds);
        }

        public void InvalidateEndTimeList()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            MEEndTimeFrameValuesController objEndTimeController = new MEEndTimeFrameValuesController();
            DataSet ds = objEndTimeController.GetAllObjects();
            //entity.MEEndTimeList.Invalidate(ds);
        }
        #endregion

        #region Field permission
        /// <summary>
        /// Save field permission
        /// </summary>
        /// <param name="treeListNode"></param>
        public void SaveFieldPermission(TreeListNode treeListNode)
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            if (treeListNode.Level == 3)
            {
                TreeListNode userGroupNode = treeListNode.ParentNode.ParentNode;
                ADUserGroupsController objUserGroupsController = new ADUserGroupsController();
                int userGroupID = Convert.ToInt32(userGroupNode.Tag);
                STModulesController objSTModulesController = new STModulesController();
                int moduleID = Convert.ToInt32(treeListNode.Tag);
                string moduleName = objSTModulesController.GetObjectNameByID(moduleID);

                STFieldPermissionsController objFieldPermissionsController = new STFieldPermissionsController();
                guiConfigureToolbar guiConfigToolbar = new guiConfigureToolbar();
                entity.STToolbarsTreeList.InvalidateTreeList(moduleID, true);
                List<STFieldPermissionsInfo> fieldPermissions = objFieldPermissionsController.GetFieldPermissionList(userGroupID, moduleName, null, null, null);
                foreach (STFieldPermissionsInfo objFieldPermissionsInfo in fieldPermissions)
                {
                    STToolbarsInfo objToolbarsInfo = (STToolbarsInfo)entity.STToolbarsTreeList.GetObjectByPropertyNameAndValue("STToolbarName", objFieldPermissionsInfo.STToolbarName);
                    if (objToolbarsInfo != null)
                    {
                        if (objFieldPermissionsInfo.STFieldPermissionType.Equals((int)FieldPermissionType.None))
                        {
                            objToolbarsInfo.Selected = true;
                        }
                        else
                        {
                            objToolbarsInfo.Selected = false;
                        }
                    }
                }
                guiConfigToolbar.Module = this;
                guiConfigToolbar.InitializeControls();
                if (guiConfigToolbar.ShowDialog() == DialogResult.OK)
                {
                    entity.SaveFieldPermission(userGroupID, moduleName);
                    //uthv clear to reload
                    BOSLib.DataAccess.SystemMemCache.FieldPermissions.Clear();
                    MessageBox.Show(UserManagementLocalizedResources.SaveSuccessfulMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Show columns of a table to make permission
        /// </summary>
        /// <param name="tableName">Table name</param>
        public void ShowColumnPermission(string tableName)
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            guiColumnPermission columnPermissionForm = new guiColumnPermission(tableName);
            columnPermissionForm.Module = this;
            if (columnPermissionForm.ShowDialog() == DialogResult.OK)
            {
                entity.SaveColumnPermissionList(tableName, CurrentUserGroup.ADUserGroupID, CurrentModule.STModuleName);
                MessageBox.Show(UserManagementLocalizedResources.SaveSuccessfulMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Invalidate column permission list of selected grid control
        /// </summary>
        /// <param name="tableName">Table name of selected grid control</param>
        public void InvalidateColumnPermissionList(string tableName)
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            STFieldColumnPermissionsController objFieldColumnPermissionsController = new STFieldColumnPermissionsController();
            DataSet ds = objFieldColumnPermissionsController.GetColumnPermissionByUserGroupIDAndModuleNameAndTableName(
                                                                                                        CurrentUserGroup.ADUserGroupID,
                                                                                                        CurrentModule.STModuleName,
                                                                                                        tableName);
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<STFieldColumnPermissionsInfo> columnPermissionList = new List<STFieldColumnPermissionsInfo>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    STFieldColumnPermissionsInfo objFieldColumnPermissionsInfo =
                        (STFieldColumnPermissionsInfo)objFieldColumnPermissionsController.GetObjectFromDataRow(dr);
                    if (objFieldColumnPermissionsInfo.STFieldColumnPermissionType == Convert.ToByte(FieldPermissionType.Hided))
                        objFieldColumnPermissionsInfo.IsCheck = true;
                    columnPermissionList.Add(objFieldColumnPermissionsInfo);
                }
                entity.STFieldColumnPermissionList.Invalidate(columnPermissionList);
            }
            else
            {
                AAColumnAliasController objColumnAliasController = new AAColumnAliasController();
                ds = objColumnAliasController.GetColumnPermissionByTableName(tableName);
                entity.STFieldColumnPermissionList.Invalidate(ds);
            }
        }
        #endregion

        #region Report permission
        /// <summary>
        /// Invalidate report permission list of selected grid control
        /// </summary>
        public void InvalidateReportPermissionList()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            ADReportPermissionsController objReportPermissionsController = new ADReportPermissionsController();
            DataSet ds = objReportPermissionsController.GetReportPermissionByUserGroupID(CurrentUserGroup.ADUserGroupID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<ADReportPermissionsInfo> reportPermissionList = new List<ADReportPermissionsInfo>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ADReportPermissionsInfo objReportPermissionsInfo = (ADReportPermissionsInfo)objReportPermissionsController.GetObjectFromDataRow(row);
                    if (objReportPermissionsInfo.ADReportPermissionType == Convert.ToByte(FieldPermissionType.None))
                        objReportPermissionsInfo.Selected = true;
                    reportPermissionList.Add(objReportPermissionsInfo);
                }
                entity.ReportPermissionsList.Invalidate(reportPermissionList);
            }
        }

        /// <summary>
        /// Save report permission
        /// </summary>
        public void SaveReportPermission()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            entity.SaveReportPermission(CurrentUserGroup.ADUserGroupID);
            MessageBox.Show(UserManagementLocalizedResources.SaveSuccessfulMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Called when user wants to choose all or discard all reports for permission
        /// </summary>
        /// <param name="isChecked">A value indicates whether the action is choosing all or discarding all</param>
        public void ChooseAllReports(bool isChecked)
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            entity.ReportPermissionsList.ForEach(ip => ip.Selected = isChecked);
            entity.ReportPermissionsList.GridControl.RefreshDataSource();
        }
        #endregion    

        #region Inventory permission
        /// <summary>
        /// Invalidate Inventory permission list of selected grid control
        /// </summary>
        public void InvalidateInventoryPermissionList()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            ICInventoryPermissionsController objInventoryPermissionsController = new ICInventoryPermissionsController();
            List<ICInventoryPermissionsInfo> invPermissions = objInventoryPermissionsController.GetInventoryPermissionByUserGroupID(CurrentUserGroup.ADUserGroupID);
            foreach (ICInventoryPermissionsInfo objInventoryPermissionsInfo in invPermissions)
            {
                if (objInventoryPermissionsInfo.ICInventoryPermissionType == Convert.ToByte(FieldPermissionType.None))
                {
                    objInventoryPermissionsInfo.Selected = true;
                }
            }
            entity.InventoryPermissionsList.Invalidate(invPermissions);
        }

        /// <summary>
        /// Save inventory permission
        /// </summary>
        public void SaveInventoryPermission()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            entity.SaveInventoryPermission(CurrentUserGroup.ADUserGroupID);
            MessageBox.Show(UserManagementLocalizedResources.SaveSuccessfulMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Called when user wants to choose all or discard all stocks for permission
        /// </summary>
        /// <param name="isChecked">A value indicates whether the action is choosing all or discarding all</param>
        public void ChooseAllStocks(bool isChecked)
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            entity.InventoryPermissionsList.ForEach(ip => ip.Selected = isChecked);
            entity.InventoryPermissionsList.GridControl.RefreshDataSource();
        }
        #endregion

        //NUThao [ADD] [23/11/2013] [DB centre] [Permission configuration], START
        #region Data view permission
        /// <summary>
        /// Create Banded Grid View
        /// </summary>
        /// <param name="gridView">GridView</param>
        /// <returns></returns>
        public BandedGridView InitBandedGridView(GridView gridView)
        {
            GELocationsController objLocationsController = new GELocationsController();
            BRBranchsController objBranchsController = new BRBranchsController();
            //int locationID = 0;
            List<GELocationsInfo> locations = objLocationsController.GetLocationsHaveBranch();
            //if (locationID > 0)
            //    locations = locations.Where(p => p.GELocationID == locationID).ToList();

            BandedGridView bandedView = new BandedGridView();
            bandedView.GridControl = gridView.GridControl;
            bandedView.Name = "bandedGridView1";
            bandedView.OptionsCustomization.AllowFilter = false;
            bandedView.OptionsView.ColumnAutoWidth = false;
            bandedView.OptionsView.ShowGroupPanel = false;

            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                bandedView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
                        ConvertToBandedGridColumn(gridView.Columns[i], false)});
            }

            GridBand[] gridBands = new GridBand[locations.Count + 1];

            GridBand itemGridBand = new GridBand();
            itemGridBand.Caption = "";
            itemGridBand.Name = "";

            BandedGridColumn bandedUserGroupSectionColumn = new BandedGridColumn();
            bandedUserGroupSectionColumn.Name = ADDataViewPermissionColumnNames.ADUserGroupSectionName;
            bandedUserGroupSectionColumn.Caption = UserManagementLocalizedResources.UserGroupSection;
            bandedUserGroupSectionColumn.FieldName = ADDataViewPermissionColumnNames.ADUserGroupSectionName;
            bandedUserGroupSectionColumn.Visible = true;
            bandedUserGroupSectionColumn.OptionsColumn.AllowEdit = false;
            bandedUserGroupSectionColumn.OwnerBand = itemGridBand;
            bandedUserGroupSectionColumn.Width = 100;
            bandedView.Columns.Add(bandedUserGroupSectionColumn);


            BandedGridColumn bandedModuleNameColumn = new BandedGridColumn();
            bandedModuleNameColumn.Name = ADDataViewPermissionColumnNames.STModuleName;
            bandedModuleNameColumn.Caption = UserManagementLocalizedResources.ModuleName;
            bandedModuleNameColumn.FieldName = ADDataViewPermissionColumnNames.STModuleName;
            bandedModuleNameColumn.Visible = true;
            bandedModuleNameColumn.OptionsColumn.AllowEdit = false;
            bandedModuleNameColumn.OwnerBand = itemGridBand;
            bandedModuleNameColumn.Width = 200;
            bandedView.Columns.Add(bandedModuleNameColumn);

            BandedGridColumn bandedColumn1 = new BandedGridColumn();
            bandedColumn1.Name = ADDataViewPermissionColumnNames.RowSelection;
            bandedColumn1.Caption = " ";
            bandedColumn1.FieldName = ADDataViewPermissionColumnNames.RowSelection;
            bandedColumn1.Visible = true;
            bandedColumn1.OptionsColumn.AllowEdit = true;
            RepositoryItemCheckEdit chk1 = new RepositoryItemCheckEdit();
            bandedColumn1.ColumnEdit = chk1;
            bandedColumn1.OwnerBand = itemGridBand;
            bandedView.Columns.Add(bandedColumn1);

            //itemGridBand.Children.Add(subItemGridBand);
            itemGridBand.Fixed = FixedStyle.Left;
            gridBands[0] = itemGridBand;

            for (int i = 0; i < locations.Count; i++)
            {
                GridBand itemGridBand1 = new GridBand();
                itemGridBand1.Caption = locations[i].GELocationName;
                itemGridBand1.Name = locations[i].GELocationID.ToString();
                itemGridBand1.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

                List<BRBranchsInfo> branchs = objBranchsController.GetAllBranches().Where(p => p.FK_GELocationID == locations[i].GELocationID).ToList();

                for (int j = 0; j < branchs.Count; j++)
                {

                    BandedGridColumn bandedColumn2 = new BandedGridColumn();
                    bandedColumn2.Name = branchs[j].BRBranchID.ToString() + branchs[j].BRBranchName;
                    bandedColumn2.Caption = branchs[j].BRBranchNo;
                    bandedColumn2.FieldName = branchs[j].BRBranchID.ToString() + branchs[j].BRBranchName;
                    bandedColumn2.Visible = true;
                    bandedColumn2.OptionsColumn.AllowEdit = true;
                    RepositoryItemCheckEdit chk2 = new RepositoryItemCheckEdit();
                    bandedColumn2.ColumnEdit = chk2;
                    bandedColumn2.OwnerBand = itemGridBand1;
                    bandedView.Columns.Add(bandedColumn2);

                }

                gridBands[i + 1] = itemGridBand1;
            }

            bandedView.Bands.AddRange(gridBands);

            //bandedView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            //        new DevExpress.XtraGrid.Columns.GridColumnSortInfo(bandedUserGroupSectionColumn, DevExpress.Data.ColumnSortOrder.Ascending)});
            //bandedUserGroupSectionColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;

            //bandedView.BeginSort();
            //try
            //{
            //    bandedView.ClearGrouping();

            //    bandedUserGroupSectionColumn.GroupIndex = 0;
            //}
            //finally
            //{
            //    bandedView.ExpandAllGroups();
            //    bandedView.EndSort();
            //}

            return bandedView;
        }

        /// <summary>
        /// Convert a column to a banded column one
        /// </summary>
        /// <param name="gridColumn">Column of GridView</param>
        /// <param name="isAllowEdit">A variable indicates whether the column is editable</param>
        /// <returns>Banded grid column</returns>
        public BandedGridColumn ConvertToBandedGridColumn(GridColumn gridColumn, bool isAllowEdit)
        {
            BandedGridColumn bandedColumn = new BandedGridColumn();
            bandedColumn.Name = gridColumn.Name;
            bandedColumn.FieldName = gridColumn.FieldName;
            bandedColumn.Caption = gridColumn.Caption;
            bandedColumn.OptionsColumn.AllowEdit = isAllowEdit;
            bandedColumn.Visible = true;
            bandedColumn.Width = gridColumn.Width;
            return bandedColumn;
        }

        /// <summary>
        /// Init DataSource
        /// </summary>
        public DataTable InitProductLocationBranchPricesDataSource()
        {
            if (!moduleStart)
            {
                UserManagementEntities entity = CurrentModuleEntity as UserManagementEntities;
                ADUsersInfo user = entity.ModuleObjects[TableName.ADUsersTableName] as ADUsersInfo;
                if (user != null)
                    PrepareDataForGrid(user.ADUserID);
            }
            moduleStart = false;
            return tableResult;
        }

        /// <summary>
        /// Prepare data before apply for grid
        /// </summary>
        public void PrepareDataForGrid(int userID)
        {
            ADDataViewPermissionsController dataViewPermissionController = new ADDataViewPermissionsController();
            UserManagementEntities entity = CurrentModuleEntity as UserManagementEntities;
            tableResult = dataViewPermissionController.GetDataViewPermissions(userID, ADDataViewPermissionType.Module);
            guiListUsers.RefreshDataVewPermissionGridControlDataSource(tableResult);

            //store the original data view permission list
            originalDataViewPermissionList = ConvertDataTableToListObject();

        }

        public void SaveDataViewPermissions()
        {
            UserManagementEntities entity = CurrentModuleEntity as UserManagementEntities;
            ADUsersInfo user = entity.ModuleObjects[TableName.ADUsersTableName] as ADUsersInfo;
            ADDataViewPermissionsController dataViewPermissionController = new ADDataViewPermissionsController();
            if (user != null)
            {

                try
                {
                    List<ADDataViewPermissionsInfo> currentList = ConvertDataTableToListObject();
                    List<ADDataViewPermissionsInfo> newList = FilterChangedObjects(currentList, Add);
                    List<ADDataViewPermissionsInfo> deletedList = FilterChangedObjects(currentList, Delete);
                    ADDataViewPermissionsInfo originalDataViewPermission = null;
                    //add new item list
                    if (newList != null && newList.Count != 0)
                    {
                        foreach (ADDataViewPermissionsInfo dataViewPermission in newList)
                        {
                            originalDataViewPermission = dataViewPermissionController.GetDataViewPermissionsByUserIDAndBranchIDAndSTModuleOrReportIDAndDataViewPermissionType(
                                                       dataViewPermission.FK_ADUserID, dataViewPermission.FK_BRBranchID, dataViewPermission.FK_STModuleOrReportID, "Module");
                            if (originalDataViewPermission == null)
                                dataViewPermissionController.CreateObject(dataViewPermission);
                        }
                    }
                    //delete 
                    if (deletedList != null && deletedList.Count != 0)
                    {
                        foreach (ADDataViewPermissionsInfo dataViewPermission in deletedList)
                        {
                            originalDataViewPermission = dataViewPermissionController.GetDataViewPermissionsByUserIDAndBranchIDAndSTModuleOrReportIDAndDataViewPermissionType(
                                                        dataViewPermission.FK_ADUserID, dataViewPermission.FK_BRBranchID, dataViewPermission.FK_STModuleOrReportID, "Module");
                            if (originalDataViewPermission != null)
                                dataViewPermissionController.DeleteObject(originalDataViewPermission.ADDataViewPermissionID);
                        }
                    }
                    MessageBox.Show(UserManagementLocalizedResources.SaveSuccessfullyMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(UserManagementLocalizedResources.SaveUnsuccessfullyMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }

        /// <summary>
        /// Convert data view permissions from a datatable to a list 
        /// </summary>
        /// <returns></returns>
        private List<ADDataViewPermissionsInfo> ConvertDataTableToListObject()
        {
            List<ADDataViewPermissionsInfo> list = new List<ADDataViewPermissionsInfo>();
            BRBranchsController branchController = new BRBranchsController();
            List<BRBranchsInfo> branches = branchController.GetAllBranches();

            if (tableResult != null && tableResult.Rows.Count != 0)
            {
                for (int index = 1; index < tableResult.Rows.Count; index++)
                {
                    DataRow row = tableResult.Rows[index];
                    if (branches != null)
                    {
                        foreach (BRBranchsInfo branch in branches)
                        {
                            ADDataViewPermissionsInfo dataViewPermission = new ADDataViewPermissionsInfo();
                            dataViewPermission.ADDataViewPermissionID = int.Parse(row[ADDataViewPermissionColumnNames.ADDataViewPermissionID].ToString());
                            dataViewPermission.ADDataViewPermissionType = ADDataViewPermissionType.Module;
                            dataViewPermission.FK_ADUserID = int.Parse(row[ADDataViewPermissionColumnNames.UserID].ToString());
                            dataViewPermission.FK_BRBranchID = branch.BRBranchID;
                            dataViewPermission.FK_STModuleOrReportID = int.Parse(row[ADDataViewPermissionColumnNames.FK_STModuleOrReportID].ToString());
                            dataViewPermission.ADUserGroupSectionChecked = bool.Parse(row[branch.BRBranchID.ToString() + branch.BRBranchName].ToString());
                            list.Add(dataViewPermission);
                        }
                    }
                }
            }
            return list;
        }

        private List<ADDataViewPermissionsInfo> FilterChangedObjects(List<ADDataViewPermissionsInfo> currentList, string filteredType)
        {
            List<ADDataViewPermissionsInfo> list = new List<ADDataViewPermissionsInfo>();

            if (currentList != null && originalDataViewPermissionList != null)
            {
                if (filteredType == Add)
                    list = currentList.Where(item => item.ADUserGroupSectionChecked == true &&
                                                    originalDataViewPermissionList.Any(originalItem => originalItem.FK_BRBranchID == item.FK_BRBranchID
                                                                                                    && originalItem.FK_STModuleOrReportID == item.FK_STModuleOrReportID
                                                                                        //&& originalItem.ADUserGroupSectionChecked == false
                                                                                        )
                                            ).ToList();
                else if (filteredType == Delete)
                {
                    list = currentList.Where(item => item.ADUserGroupSectionChecked == false &&
                                                    originalDataViewPermissionList.Any(originalItem => originalItem.FK_BRBranchID == item.FK_BRBranchID
                                                                                                    && originalItem.FK_STModuleOrReportID == item.FK_STModuleOrReportID
                                                                                                    && originalItem.ADUserGroupSectionChecked == true
                                                                                        )
                                            ).ToList();
                }
            }

            return list;
        }

        public void SelectFullRow(DataRow row)
        {
            if (row != null)
            {
                bool selected = (bool)row[ADDataViewPermissionColumnNames.RowSelection];
                BRBranchsController branchController = new BRBranchsController();
                List<BRBranchsInfo> branches = branchController.GetAllBranches();
                foreach (BRBranchsInfo branch in branches)
                {
                    row[branch.BRBranchID.ToString() + branch.BRBranchName] = selected;
                }
            }
        }

        public void SelectFullColumn(string columnName, bool selectedValue)
        {
            if (tableResult != null && tableResult.Rows.Count != 0)
            {
                foreach (DataRow row in tableResult.Rows)
                {
                    row[columnName] = selectedValue;
                }
            }
        }

        public void SelectAll(bool selectedValue)
        {
            if (tableResult != null && tableResult.Rows.Count != 0)
            {
                BRBranchsController branchController = new BRBranchsController();
                List<BRBranchsInfo> branches = branchController.GetAllBranches();

                foreach (DataRow row in tableResult.Rows)
                {
                    row[ADDataViewPermissionColumnNames.RowSelection] = selectedValue;
                    foreach (BRBranchsInfo branch in branches)
                    {
                        row[branch.BRBranchID.ToString() + branch.BRBranchName] = selectedValue;
                    }
                }
            }
        }

        public void SelectionChanged(DataRow row, string columnName, bool selectedValue)
        {
            if (tableResult != null && tableResult.Rows.Count != 0)
            {
                BRBranchsController branchController = new BRBranchsController();
                List<BRBranchsInfo> branches = branchController.GetAllBranches();

                if (!selectedValue)
                {
                    row[ADDataViewPermissionColumnNames.RowSelection] = false;
                    tableResult.Rows[0][columnName] = false;
                }
                else
                {
                    int countRowSelection = 0;
                    int countColumnSelection = 0;
                    //select row
                    foreach (BRBranchsInfo branch in branches)
                    {
                        if ((bool)row[branch.BRBranchID.ToString() + branch.BRBranchName] == true)
                            countRowSelection++;
                    }
                    if (countRowSelection == branches.Count)
                        row[ADDataViewPermissionColumnNames.RowSelection] = true;

                    foreach (DataRow dtRow in tableResult.Rows)
                    {
                        if ((bool)dtRow[columnName] == true)
                            countColumnSelection++;
                    }

                    if (countColumnSelection == tableResult.Rows.Count - 1)
                        tableResult.Rows[0][columnName] = true;
                }
            }

        }

        #endregion Data view permission
        //NUThao [ADD] [23/11/2013] [DB centre] [Permission configuration], END

        #region Command Permission

        /// <summary>
        /// Init command Tree list
        /// </summary>
        public void InitCommandTreeList()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            MECommandsController objCommandsController = new MECommandsController();
            DataSet ds = objCommandsController.GetAllRootCommands();
            entity.MECommandsTreeList.Invalidate(ds);
            MECommandPermissionsController objCommandPermissionsController = new MECommandPermissionsController();
            CommandPermissionList = objCommandPermissionsController.GetAllCommandPermissionsByUserGroup(CurrentUserGroup.ADUserGroupID);
            LoadCommandPermission(entity.MECommandsTreeList);
        }

        /// <summary>
        /// Load command permission
        /// </summary>
        public void LoadCommandPermission(IBOSTreeList commandList)
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            foreach (MECommandsInfo objCommandsInfo in commandList)
            {
                MECommandPermissionsInfo objCommandPermissionsInfo = CommandPermissionList.Where(p => p.FK_MECommandID == objCommandsInfo.MECommandID).FirstOrDefault();
                if (objCommandPermissionsInfo != null)
                {
                    if (objCommandPermissionsInfo.MECommandPermissionType == Convert.ToInt32(FieldPermissionType.None))
                    {
                        objCommandsInfo.Selected = true;
                    }
                    else if (objCommandPermissionsInfo.MECommandPermissionType == Convert.ToInt32(FieldPermissionType.Hided))
                    {
                        objCommandsInfo.Selected = false;
                    }
                }
                else
                {
                    objCommandsInfo.Selected = true;
                }

                if (objCommandsInfo.HasChildren())
                {
                    LoadCommandPermission(objCommandsInfo.SubList);
                }
            }
        }

        /// <summary>
        /// Save command permission
        /// </summary>
        public void SaveCommandPermission()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            entity.SaveCommandPermission(CurrentUserGroup.ADUserGroupID);
            MessageBox.Show(UserManagementLocalizedResources.SaveSuccessfulMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Object State Permission
        public void InvalidateObjectStatePermissionsList()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            var statePermissionCtrl = new STObjectStatePermissionsController();
            var list = statePermissionCtrl.GetPermissionByUserGroupID(CurrentUserGroup.ADUserGroupID);
            entity.ObjectStatePermissionList.Invalidate(list);
        }
        public bool SaveObjectStatePermissions()
        {
            try
            {
                UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                foreach (var item in entity.ObjectStatePermissionList)
                {
                    item.FK_ADUserGroupID = CurrentUserGroup.ADUserGroupID;
                    item.STObjectStatePermissionTable = rgx.Replace(item.STObjectStatePermissionTable, string.Empty);
                    item.STObjectStatePermissionCol = rgx.Replace(item.STObjectStatePermissionCol, string.Empty);
                    item.STObjectStatePermissionVal = rgx.Replace(item.STObjectStatePermissionVal, string.Empty);
                }
                entity.ObjectStatePermissionList.SaveItemObjects();
                MessageBox.Show(UserManagementLocalizedResources.SaveSuccessfulMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi khi lưu");
            }
            return false;
        }
        internal void DeleteObjectStatePermissionList()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            entity.ObjectStatePermissionList.RemoveSelectedRowObjectFromList();
        }
        #endregion

        #region User in Group
        public void InvalidateADUsersOfGroup()
        {
            var list = _objAdUsersController.GetAllUserByUserGroupID(this.CurrentUserGroup.ADUserGroupID);
            _entity.ADUserOfGroupList.Invalidate(list);
        }
        public void InvalidateExtraUsersOfGroup()
        {
            var list = _userGroupExtrasCtrl.GetAllByUserGroupID(this.CurrentUserGroup.ADUserGroupID);
            _entity.ADUserExtraOfGroupList.Invalidate(list);
        }
        public bool SaveUserExtraOfGroups()
        {
            try
            {
                foreach (var item in _entity.ADUserExtraOfGroupList)
                {
                    item.FK_ADUserGroupID = this.CurrentUserGroup.ADUserGroupID;
                    if (item.ADUserGroupExtraID == 0)
                        item.ADUserGroupExtraDateAdd = DateTime.Now;
                }
                _entity.ADUserExtraOfGroupList.SaveItemObjects();
                MessageBox.Show(UserManagementLocalizedResources.SaveSuccessfulMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Có lỗi khi lưu");
            }
            return false;

        }
        internal void DeleteUserExtraOfGroupList()
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            entity.ADUserExtraOfGroupList.RemoveSelectedRowObjectFromList();
        }
        #endregion

        #region Templates
        public void InvalidateTemplates(ADUserGroupsInfo userGroup)
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            METemplatesController templatesController = new METemplatesController();
            var templateList = templatesController.GetListTemplatesByTypeOnly(TemplateType.ProgressNote.ToString());
            if (templateList.Count > 0)
            {
                METemplateUserGroupsController tpUserGroupsController = new METemplateUserGroupsController();
                var templateUserGroups = tpUserGroupsController.GetListBusinessObjects<METemplateUserGroupsInfo>(tpUserGroupsController.GetAllDataByForeignColumn("FK_ADUserGroupID", userGroup.ADUserGroupID));

                foreach (var template in templateList)
                {
                    if (templateUserGroups.Count(m => m.FK_METemplateID.Equals(template.METemplateID)) > 0)
                    {
                        template.Selected = true;
                    }
                }
                entity.METemplateList.Invalidate(templateList);
            }
        }

        /// <summary>
        /// Save report permission
        /// </summary>
        public void SaveTemplates(ADUserGroupsInfo userGroup)
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            entity.SaveTemplateUserGroup(userGroup.ADUserGroupID, BOSApp.CurrentUsersInfo.ADUserName);
            MessageBox.Show(UserManagementLocalizedResources.SaveSuccessfulMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Called when user wants to choose all or discard all reports for permission
        /// </summary>
        /// <param name="isChecked">A value indicates whether the action is choosing all or discarding all</param>
        public void ChooseAllTemplates(bool isChecked)
        {
            UserManagementEntities entity = (UserManagementEntities)CurrentModuleEntity;
            entity.METemplateList.ForEach(ip => ip.Selected = isChecked);
            entity.METemplateList.GridControl.RefreshDataSource();
        }
        #endregion
    }
}
