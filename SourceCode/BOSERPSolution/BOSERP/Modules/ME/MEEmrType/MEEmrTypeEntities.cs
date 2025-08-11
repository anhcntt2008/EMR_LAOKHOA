using System;
using System.Collections.Generic;
using System.Text;
using BOSCommon;
using System.Data;

namespace BOSERP.Modules.MEEmrType
{
    public class MEEmrTypeEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSList<MEEmrTypeTemplatesInfo> MEEmrTypeTemplateList { get; internal set; }
        public BOSList<METemplateIndexsInfo> METemplateIndexList { get; internal set; }
        public BOSList<METemplatesInfo> METemplateList { get; internal set; }
        public BOSList<MEEmrTypeActionsInfo> MEEmrTypeActionList { get; internal set; }
        public BOSList<MEEmrActionsInfo> MEEmrActionList { get; internal set; }
        #endregion

        #region Constructor
        public MEEmrTypeEntities()
            : base()
        {
            MEEmrTypeTemplateList = new BOSList<MEEmrTypeTemplatesInfo>();
            METemplateIndexList = new BOSList<METemplateIndexsInfo>();
            METemplateList = new BOSList<METemplatesInfo>();
            MEEmrActionList = new BOSList<MEEmrActionsInfo>();
            MEEmrTypeActionList = new BOSList<MEEmrTypeActionsInfo>();
        }
        #endregion
        public override void InitGridControlInBOSList()
        {
            MEEmrTypeTemplateList.InitBOSListGridControl();
            METemplateIndexList.InitBOSListGridControl();
            METemplateList.InitBOSListGridControl();
            MEEmrActionList.InitBOSListGridControl();
            MEEmrTypeActionList.InitBOSListGridControl();
        }
        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new MEEmrTypesInfo();
            SearchObject = new MEEmrTypesInfo();
        }
        public override void InitModuleObjectList()
        {
            base.InitModuleObjectList();
            MEEmrTypeTemplateList.InitBOSList(this,
               TableName.MEEmrTypesTableName,
               TableName.MEEmrTypeTemplatesTableName,
                BOSList<MEEmrTypeTemplatesInfo>.cstRelationForeign);
            MEEmrTypeTemplateList.ItemTableForeignKey = "FK_MEEmrTypeID";

            METemplateList.InitBOSList(this,
             string.Empty,
             TableName.METemplatesTableName,
              BOSList<METemplatesInfo>.cstRelationNone);

            METemplateIndexList.InitBOSList(this,
             TableName.MEEmrTypesTableName,
             TableName.METemplateIndexsTableName,
              BOSList<METemplateIndexsInfo>.cstRelationForeign);
            METemplateIndexList.ItemTableForeignKey = "FK_MEEmrTypeID";

            MEEmrTypeActionList.InitBOSList(this,
                TableName.MEEmrTypesTableName,
                TableName.MEEmrTypeActionsTableName,
                BOSList<MEEmrTypeActionsInfo>.cstRelationForeign);
                MEEmrTypeActionList.ItemTableForeignKey = "FK_MEEmrTypeID";

            MEEmrActionList.InitBOSList(this,
                String.Empty,
                TableName.MEEmrActionsTableName,
                BOSList<MEParamsInfo>.cstRelationNone);
        }
        #endregion

        public override int SaveMainObject()
        {
            return base.SaveMainObject();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEEmrTypeTemplateList.SetDefaultListAndRefreshGridControl();
                METemplateIndexList.SetDefaultListAndRefreshGridControl();
                METemplateList.SetDefaultListAndRefreshGridControl();
                MEEmrTypeActionList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }
        public override void InvalidateModuleObjects(int iObjectID)
        {
            MEEmrTypeTemplateList.Invalidate(iObjectID);
            METemplateIndexList.Invalidate(iObjectID);
            InvalidateTemplateList(iObjectID);
            MEEmrTypeActionList.Invalidate(iObjectID);
        }
        public void InvalidateTemplateList(int iObjectID)
        {
            METemplateList.Invalidate(iObjectID);
            foreach (var item in MEEmrTypeTemplateList)
            {
                var param = METemplateList.Find(p => p.METemplateID == item.FK_METemplateID);
                METemplateList.Remove(param);
            }

            METemplateList.GridControl.RefreshDataSource();
            METemplateList.GridControl.Refresh();
        }
        public override void SaveModuleObjects()
        {
            base.SaveModuleObjects();
            MEEmrTypeTemplateList.SaveItemObjects();
            METemplateIndexList.SaveItemObjects();
            MEEmrTypeActionList.SaveItemObjects();
        }
    }
}
