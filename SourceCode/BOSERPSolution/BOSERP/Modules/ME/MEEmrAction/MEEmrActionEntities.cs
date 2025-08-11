using System;
using System.Collections.Generic;
using System.Text;
using BOSCommon;
using System.Data;

namespace BOSERP.Modules.MEEmrAction
{
    public class MEEmrActionEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSList<MEEmrActionParamsInfo> MEEmrActionParamsList { get; internal set; }
        public BOSList<MEParamsInfo> MEParamsList { get; internal set; }
        public BOSList<MEEmrActionRelationsInfo> MEEmrActionRelationsList { get; internal set; }
        public BOSList<MEEmrTemplateActionsInfo> MEEmrTemplateActionList { get; set; }

        #endregion

        #region Constructor
        public MEEmrActionEntities()
            : base()
        {
            MEEmrActionParamsList = new BOSList<MEEmrActionParamsInfo>();
            MEParamsList = new BOSList<MEParamsInfo>();
            MEEmrActionRelationsList = new BOSList<MEEmrActionRelationsInfo>();
            MEEmrTemplateActionList = new BOSList<MEEmrTemplateActionsInfo>();
        }
        #endregion
        public override void InitGridControlInBOSList()
        {
            MEEmrActionParamsList.InitBOSListGridControl();
            MEParamsList.InitBOSListGridControl();
            MEEmrActionRelationsList.InitBOSListGridControl();
            MEEmrTemplateActionList.InitBOSListGridControl("fld_dgcMEEmrActionsInTemplate");
        }
        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new MEEmrActionsInfo();
            SearchObject = new MEEmrActionsInfo();
        }
        public override void InitModuleObjectList()
        {
            base.InitModuleObjectList();
            MEEmrActionParamsList.InitBOSList(this,
               TableName.MEEmrActionsTableName,
               TableName.MEEmrActionParamsTableName,
                BOSList<MEEmrActionParamsInfo>.cstRelationForeign);
            MEEmrActionParamsList.ItemTableForeignKey = "FK_MEEmrActionID";

            MEParamsList.InitBOSList(this,
             TableName.MEEmrActionsTableName,
             TableName.MEParamsTableName,
              BOSList<MEEmrActionParamsInfo>.cstRelationNone);

            MEEmrActionRelationsList.InitBOSList(this,
              TableName.MEEmrActionsTableName,
              TableName.MEEmrActionRelationsTableName,
               BOSList<MEEmrActionRelationsInfo>.cstRelationForeign);
            MEEmrActionRelationsList.ItemTableForeignKey = "FK_MEEmrActionParentID";


            MEEmrTemplateActionList.InitBOSList(this,
               TableName.MEEmrActionsTableName,
               TableName.MEEmrTemplateActionsTableName,
                BOSList<MEEmrTemplateActionsInfo>.cstRelationForeign);
            MEEmrTemplateActionList.ItemTableForeignKey = "FK_MEEmrActionID";
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
                MEEmrActionParamsList.SetDefaultListAndRefreshGridControl();
                MEParamsList.SetDefaultListAndRefreshGridControl();
                MEEmrActionRelationsList.SetDefaultListAndRefreshGridControl();
                MEEmrTemplateActionList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }
        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
        }
        public override void InvalidateModuleObjects(int iObjectID)
        {
            MEEmrActionParamsList.Invalidate(iObjectID);
            MEEmrActionRelationsList.Invalidate(iObjectID);
            InvalidateParamList(iObjectID);
            MEEmrTemplateActionList.Invalidate(iObjectID);
        }
        public void InvalidateParamList(int iObjectID)
        {
            MEParamsList.Invalidate(iObjectID);
            foreach (var item in MEEmrActionParamsList)
            {
                var param = MEParamsList.Find(p => p.MEParamID == item.FK_MEParamID);
                MEParamsList.Remove(param);
            }
        }
        public override void SaveModuleObjects()
        {
            base.SaveModuleObjects();
            MEEmrActionParamsList.SaveItemObjects();
            var main = MainObject as MEEmrActionsInfo;
            foreach (var item in MEEmrActionRelationsList)
            {
                item.FK_MEEmrActionParentID = main.MEEmrActionID;
            }
            MEEmrActionRelationsList.SaveItemObjects();
        }
    }
}
