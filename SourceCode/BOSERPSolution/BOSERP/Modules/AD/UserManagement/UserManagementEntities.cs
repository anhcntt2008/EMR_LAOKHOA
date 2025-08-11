using System;
using System.Collections.Generic;
using System.Text;
using BOSLib;
using BOSCommon;
using DevExpress.XtraTreeList.Nodes;
using System.Data;
using System.Windows.Forms;
using Localization;
using System.Linq;


namespace BOSERP.Modules.UserManagement
{
    public class UserManagementEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSTreeList MECommandsTreeList { get; set; }
        public BOSList<ADUsersInfo> ADUserList { get; set; }
        public BOSList<ADUsersInfo> ADUserOfGroupList { get; set; }
        public BOSList<ADUserGroupExtrasInfo> ADUserExtraOfGroupList { get; set; }
        public BOSTreeList STToolbarsTreeList { get; set; }

        //public BOSList<MEEndTimeFrameValuesInfo> MEEndTimeList { get;set;}
        /// <summary>
        /// Gets or sets column permission list of a table
        /// </summary>
        public BOSList<STFieldColumnPermissionsInfo> STFieldColumnPermissionList { get; set; }
        /// <summary>
        /// Gets or sets report list
        /// </summary>
        public BOSList<ADReportPermissionsInfo> ReportPermissionsList { get; set; }
        /// <summary>
        /// Gets or sets stock list
        /// </summary>
        public BOSList<ICInventoryPermissionsInfo> InventoryPermissionsList { get; set; }

        public BOSList<STObjectStatePermissionsInfo> ObjectStatePermissionList { get; set; }

        public BOSList<METemplatesInfo> METemplateList { get; set; }

        #endregion

        #region Constructor
        public UserManagementEntities()
        {
            ADUserList = new BOSList<ADUsersInfo>();
            ADUserOfGroupList = new BOSList<ADUsersInfo>();
            ADUserExtraOfGroupList = new BOSList<ADUserGroupExtrasInfo>();
            STToolbarsTreeList = new BOSTreeList();
            STFieldColumnPermissionList = new BOSList<STFieldColumnPermissionsInfo>();
            ReportPermissionsList = new BOSList<ADReportPermissionsInfo>();
            InventoryPermissionsList = new BOSList<ICInventoryPermissionsInfo>();
            MECommandsTreeList = new BOSTreeList();
            //MEEndTimeList = new BOSList<MEEndTimeFrameValuesInfo>();
            ObjectStatePermissionList = new BOSList<STObjectStatePermissionsInfo>();
            METemplateList = new BOSList<METemplatesInfo>();
        }
        #endregion

        #region Module Objects functions
        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.ADUsersTableName, new ADUsersInfo());
            ModuleObjects.Add(TableName.STFieldColumnPermissionsTableName, new STFieldColumnPermissionsInfo());
            ModuleObjects.Add(TableName.MEEndTimeTableName, new MEEndTimeFrameValuesInfo());

            ModuleObjects.Add(TableName.STObjectStatePermissionsTableName, new STObjectStatePermissionsInfo());
        }

        public override void InitModuleObjectList()
        {
            ADUserList.InitBOSList(this, string.Empty, TableName.ADUsersTableName, BOSList<ADUsersInfo>.cstRelationNone);
            ADUserOfGroupList.InitBOSList(this, string.Empty, TableName.ADUsersTableName, BOSList<ADUsersInfo>.cstRelationNone);
            ADUserExtraOfGroupList.InitBOSList(this, string.Empty, TableName.ADUserGroupExtrasTableName, BOSList<ADUserGroupExtrasInfo>.cstRelationNone);
            STFieldColumnPermissionList.InitBOSList(this, string.Empty, TableName.STFieldColumnPermissionsTableName,
                                                    BOSList<STFieldColumnPermissionsInfo>.cstRelationNone);

            ReportPermissionsList.InitBOSList(this, string.Empty, TableName.ADReportPermissionsTableName, BOSList<ADReportPermissionsInfo>.cstRelationNone);
            InventoryPermissionsList.InitBOSList(this, string.Empty, TableName.ICInventoryPermissionsTableName, BOSList<ICInventoryPermissionsInfo>.cstRelationNone);

            STToolbarsTreeList.InitBOSList(this,
                                            TableName.STModulesTableName,
                                            TableName.STToolbarsTableName,
                                            BOSTreeList.cstRelationForeign);
            STToolbarsTreeList.ItemTableForeignKey = "STModuleID";
            MECommandsTreeList.InitBOSList(this,
                                            String.Empty,
                                            TableName.MECommandsTableName,
                                            BOSTreeList.cstRelationNone);
            //MEEndTimeList.InitBOSList(this, string.Empty, TableName.MEEndTimeTableName, BOSList<MEEndTimeFrameValuesInfo>.cstRelationNone);

            ObjectStatePermissionList.InitBOSList(this, string.Empty, TableName.STObjectStatePermissionsTableName, BOSList<STObjectStatePermissionsInfo>.cstRelationNone);

            METemplateList.InitBOSList(this, string.Empty, TableName.METemplateIndexsTableName, BOSList<METemplatesInfo>.cstRelationNone);

        }
        public override void InitGridControlInBOSList()
        {
            STToolbarsTreeList.InitBOSTreeListControl();
            MECommandsTreeList.InitBOSTreeListControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            ADUsersInfo objUserInfo = (ADUsersInfo)MainObject;
            objUserInfo.ADUserActiveCheck = true;
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                STToolbarsTreeList.SetDefaultListAndRefreshTreeListControl();
                MECommandsTreeList.SetDefaultListAndRefreshTreeListControl();
            }
            catch (Exception)
            {
                return;
            }
        }
        #endregion

        #region Save Module Objects functions
        public override void SaveModuleObjects()
        {

        }

        public void SaveUser()
        {
            ADUsersController objUsersController = new ADUsersController();
            ADUsersInfo objUsersInfo = (ADUsersInfo)ModuleObjects[TableName.ADUsersTableName];
            if (objUsersInfo.ADUserID == 0)
            {
                objUsersInfo.ADUserStyle = "Skin";
                objUsersInfo.ADUserStyleSkin = "Black";
                objUsersController.CreateUser(objUsersInfo);
            }
            else
            {
                objUsersController.UpdateUser(objUsersInfo, true);
            }
        }

        public void DeleteUser(int userID)
        {
            ADUsersController objUsersController = new ADUsersController();
            objUsersController.DeleteObject(userID);
        }

        /// <summary>
        /// Save field premission 
        /// </summary>
        /// <param name="userGroupID">User group id</param>
        /// <param name="moduleName">Module name</param>
        public void SaveFieldPermission(int userGroupID, string moduleName)
        {
            SaveFieldPermission(STToolbarsTreeList, userGroupID, moduleName);
        }

        /// <summary>
        /// Save field permission. 
        /// The function is called recursively for toolbar tree list
        /// </summary>
        /// <param name="toolbarTreeList">Toolbar tree list</param>
        /// <param name="userGroupID">User group id</param>
        /// <param name="moduleName">Module name</param>
        private void SaveFieldPermission(IBOSTreeList toolbarTreeList, int userGroupID, string moduleName)
        {
            STFieldPermissionsController objFieldPermissionsController = new STFieldPermissionsController();
            STToolbarsController objToolbarsController = new STToolbarsController();
            for (int i = 0; i < toolbarTreeList.Count; i++)
            {
                STToolbarsInfo objToolbarsInfo = toolbarTreeList[i] as STToolbarsInfo;
                STFieldPermissionsInfo objFieldPermissionsInfo = objFieldPermissionsController.GetFieldPermissionByUserGroupIDAndModuleNameAndToolbarName(
                                                                                                        userGroupID,
                                                                                                        moduleName,
                                                                                                        objToolbarsInfo.STToolbarName);
                if (objFieldPermissionsInfo != null)
                {
                    if (toolbarTreeList[i].Selected)
                        objFieldPermissionsInfo.STFieldPermissionType = (int)FieldPermissionType.None;
                    else
                        objFieldPermissionsInfo.STFieldPermissionType = (int)FieldPermissionType.Hided;
                    objFieldPermissionsController.UpdateObject(objFieldPermissionsInfo);
                }
                else
                {
                    objFieldPermissionsInfo = new STFieldPermissionsInfo();
                    objFieldPermissionsInfo.FK_ADUserGroupID = userGroupID;
                    objFieldPermissionsInfo.STModuleName = moduleName;
                    objFieldPermissionsInfo.STToolbarName = objToolbarsInfo.STToolbarName;
                    if (toolbarTreeList[i].Selected)
                        objFieldPermissionsInfo.STFieldPermissionType = (int)FieldPermissionType.None;
                    else
                        objFieldPermissionsInfo.STFieldPermissionType = (int)FieldPermissionType.Hided;
                    objFieldPermissionsController.CreateObject(objFieldPermissionsInfo);
                }

                if (objToolbarsInfo.SubList != null && objToolbarsInfo.SubList.Count > 0)
                {
                    SaveFieldPermission(objToolbarsInfo.SubList, userGroupID, moduleName);
                }
            }
        }

        /// <summary>
        /// Save column permission
        /// </summary>
        /// <param name="tableName">Table name of grid control</param>
        /// <param name="userGroupID">Current user group id</param>
        /// <param name="moduleName">Current module name</param>
        public void SaveColumnPermissionList(string tableName, int userGroupID, string moduleName)
        {
            foreach (STFieldColumnPermissionsInfo objFieldColumnPermissionsInfo in STFieldColumnPermissionList)
            {
                objFieldColumnPermissionsInfo.STTableName = tableName;
                objFieldColumnPermissionsInfo.FK_ADUserGroupID = userGroupID;
                objFieldColumnPermissionsInfo.STModuleName = moduleName;
                if (objFieldColumnPermissionsInfo.IsCheck)
                    objFieldColumnPermissionsInfo.STFieldColumnPermissionType = Convert.ToByte(FieldPermissionType.Hided);
                else
                    objFieldColumnPermissionsInfo.STFieldColumnPermissionType = Convert.ToByte(FieldPermissionType.None);
            }
            STFieldColumnPermissionList.SaveItemObjects();
        }

        /// <summary>
        /// Save report permission
        /// </summary>
        /// <param name="userGroupID">User group ID</param>
        public void SaveReportPermission(int userGroupID)
        {
            ADReportPermissionsController objReportPermissionsController = new ADReportPermissionsController();
            foreach (ADReportPermissionsInfo objReportPermissionsInfo in ReportPermissionsList)
            {
                //Set value for report permission
                objReportPermissionsInfo.FK_ADReportID = objReportPermissionsInfo.ADReportID;
                objReportPermissionsInfo.FK_ADUserGroupID = userGroupID;
                if (objReportPermissionsInfo.Selected)
                    objReportPermissionsInfo.ADReportPermissionType = Convert.ToByte(FieldPermissionType.None);
                else
                    objReportPermissionsInfo.ADReportPermissionType = Convert.ToByte(FieldPermissionType.Hided);

                //Create or update report permission
                if (objReportPermissionsInfo.ADReportPermissionID > 0)
                    objReportPermissionsController.UpdateObject(objReportPermissionsInfo);
                else
                    objReportPermissionsController.CreateObject(objReportPermissionsInfo);
            }
        }

        /// <summary>
        /// Save inventory permission
        /// </summary>
        /// <param name="userGroupID">User group ID</param>
        public void SaveInventoryPermission(int userGroupID)
        {
            ICInventoryPermissionsController objInventoryPermissionsController = new ICInventoryPermissionsController();
            foreach (ICInventoryPermissionsInfo objInventoryPermissionsInfo in InventoryPermissionsList)
            {
                //Set value for report permission
                objInventoryPermissionsInfo.FK_ICStockID = objInventoryPermissionsInfo.ICStockID;
                objInventoryPermissionsInfo.FK_ADUserGroupID = userGroupID;
                if (objInventoryPermissionsInfo.Selected)
                    objInventoryPermissionsInfo.ICInventoryPermissionType = Convert.ToByte(FieldPermissionType.None);
                else
                    objInventoryPermissionsInfo.ICInventoryPermissionType = Convert.ToByte(FieldPermissionType.Hided);

                //Creat or update report permission
                if (objInventoryPermissionsInfo.ICInventoryPermissionID > 0)
                    objInventoryPermissionsController.UpdateObject(objInventoryPermissionsInfo);
                else
                    objInventoryPermissionsController.CreateObject(objInventoryPermissionsInfo);
            }
        }

        /// <summary>
        /// Save command permission
        /// </summary>
        /// <param name="userGroupID">User group ID</param>
        public void SaveCommandPermission(int userGroupID)
        {
            SaveCommandPermission(MECommandsTreeList, userGroupID);
        }

        /// <summary>
        /// Save Command permission to database 
        /// The function is called recursively for command tree list
        /// </summary>
        /// <param name="commandTreeList"> Command Tree List</param>
        /// <param name="userGroupID">User group ID</param>
        public void SaveCommandPermission(IBOSTreeList commandTreeList, int userGroupID)
        {
            MECommandPermissionsController objCommandPermissionsController = new MECommandPermissionsController();
            MECommandsController objCommandsController = new MECommandsController();
            for (int i = 0; i < commandTreeList.Count; i++)
            {
                MECommandsInfo objCommandsInfo = commandTreeList[i] as MECommandsInfo;
                MECommandPermissionsInfo objCommandPermissionsInfo = objCommandPermissionsController.GetAllCommandPermissionsByUserGroupAndCommandID(userGroupID, objCommandsInfo.MECommandID);

                if (objCommandPermissionsInfo != null)
                {
                    if (commandTreeList[i].Selected)
                        objCommandPermissionsInfo.MECommandPermissionType = (int)CommandPermissionType.None;
                    else
                        objCommandPermissionsInfo.MECommandPermissionType = (int)CommandPermissionType.Hided;
                    objCommandPermissionsController.UpdateObject(objCommandPermissionsInfo);
                }
                else
                {
                    if (objCommandsInfo.MECommandID > 0)
                    {
                        objCommandPermissionsInfo = new MECommandPermissionsInfo();
                        objCommandPermissionsInfo.FK_ADUserGroupID = userGroupID;
                        objCommandPermissionsInfo.FK_MECommandID = objCommandsInfo.MECommandID;

                        if (commandTreeList[i].Selected)
                            objCommandPermissionsInfo.MECommandPermissionType = (int)CommandPermissionType.None;
                        else
                            objCommandPermissionsInfo.MECommandPermissionType = (int)CommandPermissionType.Hided;
                        objCommandPermissionsController.CreateObject(objCommandPermissionsInfo);
                    }
                }

                if (objCommandsInfo.HasChildren())
                {
                    SaveCommandPermission(objCommandsInfo.SubList, userGroupID);
                }
            }
        }

        public void SaveTemplateUserGroup(int userGroupID, string userName)
        {
            METemplateUserGroupsController tpUserGroupsController = new METemplateUserGroupsController();
            foreach (METemplatesInfo tpInfo in METemplateList)
            {
                var existE = tpUserGroupsController.GetFirstByUserGroupAndTemplate(userGroupID, tpInfo.METemplateID);
                if (existE != null)
                {
                    existE.AAStatus = tpInfo.Selected ? Status.Alive.ToString() : Status.Delete.ToString();
                    existE.AAUpdatedUser = userName;
                    tpUserGroupsController.UpdateObject(existE);
                }
                else
                {
                    existE = new METemplateUserGroupsInfo
                    {
                        FK_ADUserGroupID = userGroupID,
                        FK_METemplateID = tpInfo.METemplateID,
                        AAStatus = tpInfo.Selected ? Status.Alive.ToString() : Status.Delete.ToString(),
                        AACreatedUser = userName
                };
                    tpUserGroupsController.CreateObject(existE);
                }
            }
        }
        #endregion
    }
}
