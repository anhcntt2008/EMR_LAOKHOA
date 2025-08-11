using System;
using System.Collections.Generic;
using System.Text;
using BOSCommon;
using System.Data;

namespace BOSERP.Modules.MEParams
{
    public class MEParamsEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSList<MEParamRelationsInfo> MEParamRelationsList { get; internal set; }
        public BOSList<METemplateParamsInfo> METemplateParamList { get; internal set; }
        #endregion

        #region Constructor
        public MEParamsEntities()
            : base()
        {
            MEParamRelationsList = new BOSList<MEParamRelationsInfo>();
            METemplateParamList = new BOSList<METemplateParamsInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new MEParamsInfo();
            SearchObject = new MEParamsInfo();
        }
        #endregion

        public override int SaveMainObject()
        {
            MEParamsInfo objParamInfo = (MEParamsInfo)MainObject;
            return base.SaveMainObject();
        }
        public override void InitGridControlInBOSList()
        {
            MEParamRelationsList.InitBOSListGridControl();
            METemplateParamList.InitBOSListGridControl();
        }
        public override void InitModuleObjectList()
        {
            base.InitModuleObjectList();
            MEParamRelationsList.InitBOSList(this,
               TableName.MEParamsTableName,
               TableName.MEParamRelationsTableName,
                BOSList<MEParamRelationsInfo>.cstRelationForeign);
            MEParamRelationsList.ItemTableForeignKey = "FK_MEParamParentID";


            METemplateParamList.InitBOSList(this,
               TableName.MEParamsTableName,
               TableName.METemplateParamsTableName,
                BOSList<METemplateParamsInfo>.cstRelationForeign);
            METemplateParamList.ItemTableForeignKey = "FK_MEParamID";
        }
        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEParamRelationsList.SetDefaultListAndRefreshGridControl();
                METemplateParamList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }
        public override void InvalidateModuleObjects(int iObjectID)
        {
            MEParamRelationsList.Invalidate(iObjectID);
            METemplateParamList.Invalidate(iObjectID);
        }
        public override void SaveModuleObjects()
        {
            base.SaveModuleObjects();
            var main = MainObject as MEParamsInfo;
            foreach (var item in MEParamRelationsList)
            {
                item.FK_MEParamParentID = main.MEParamID;
            }
            MEParamRelationsList.SaveItemObjects();

            foreach (var item in METemplateParamList)
            {
                item.FK_MEParamID = main.MEParamID;
            }
            METemplateParamList.SaveItemObjects();
        }
    }
}
