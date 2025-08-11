using System;
using System.Collections.Generic;
using System.Text;
using BOSCommon;
using System.Data;

namespace BOSERP.Modules.MEParamReports
{
    public class MEParamReportsEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSList<MEParamReportRelationsInfo> MEParamReportRelationsList { get; internal set; }
        #endregion

        #region Constructor
        public MEParamReportsEntities()
            : base()
        {
            MEParamReportRelationsList = new BOSList<MEParamReportRelationsInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new MEParamsInfo();
            SearchObject = new MEParamsInfo();
        }
        #endregion

        #region Invalidate Module Objects Functions
        public override void InvalidateModuleObjects(int iObjectID)
        {
            MEParamReportRelationsList.Invalidate(iObjectID);
        }
        #endregion

        public override int SaveMainObject()
        {
            MEParamsInfo objParamInfo = (MEParamsInfo)MainObject;
            return base.SaveMainObject();
        }

        public override void InitGridControlInBOSList()
        {
            MEParamReportRelationsList.InitBOSListGridControl();
        }

        public override void InitModuleObjectList()
        {
            base.InitModuleObjectList();

            MEParamReportRelationsList.InitBOSList(this,
               TableName.MEParamsTableName,
               TableName.MEParamReportRelationsTableName,
                BOSList<MEParamReportRelationsInfo>.cstRelationForeign);
            MEParamReportRelationsList.ItemTableForeignKey = "FK_MEParamID";
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEParamReportRelationsList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        public override void SaveModuleObjects()
        {
            base.SaveModuleObjects();
            var main = MainObject as MEParamsInfo;
            foreach (var item in MEParamReportRelationsList)
            {
                item.FK_MEParamID = main.MEParamID;
                if ((item.FK_METemplateID2 <= 0 && !string.IsNullOrEmpty(item.MEParamReportMap2)) || (item.FK_METemplateID2 >0 && string.IsNullOrEmpty(item.MEParamReportMap2)))
                {
                    item.FK_METemplateID2 = 0;
                    item.MEParamReportMap2 = string.Empty;
                }
                if ((item.FK_METemplateID3 <= 0 && !string.IsNullOrEmpty(item.MEParamReportMap3)) || (item.FK_METemplateID3 > 0 && string.IsNullOrEmpty(item.MEParamReportMap3)))
                {
                    item.FK_METemplateID3 = 0;
                    item.MEParamReportMap3 = string.Empty;
                }
            }
            MEParamReportRelationsList.SaveItemObjects();
        }
    }
}
