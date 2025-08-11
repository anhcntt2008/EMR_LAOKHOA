using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BOSCommon;
using BOSLib;
using System.Data;

namespace BOSERP.Modules.METemplate
{
    public class METemplateEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the param list
        /// </summary>
        public BOSList<MEParamsInfo> MEParamList { get; set; }
        public BOSList<MEEmrActionsInfo> MEEmrActionList { get; set; }
        public BOSList<MEEmrActionsInfo> MEEmrStartupActionList { get; set; }
        public BOSList<MEEmrTemplateActionsInfo> MEEmrTemplateActionList { get; set; }
        public BOSList<METemplateUserGroupsInfo> METemplateUserGroupList { get; set; }
        public BOSList<METemplateChartsInfo> METemplateChartList { get; set; }
        public BOSList<METemplateChartSeriesInfo> METemplateChartSeriesList { get; set; }
        public List<MEParamsInfo> MEParamLookupList { get; set; }
        public BOSList<ICProductsInfo> ICServiceList { get; set; }
        public SortedList<string, GELookupTablesInfo> LookupTableObjects { get; private set; }
        public SortedList LookupTablesUpdatedDate { get; private set; }
        public SortedList LookupTables { get; private set; }
        public BOSList<METemplateParamsInfo> METemplateParamList { get; set; }
        #endregion

        #region Constructor
        public METemplateEntities()
            : base()
        {
            MEParamList = new BOSList<MEParamsInfo>();
            MEEmrActionList = new BOSList<MEEmrActionsInfo>();

            ICServiceList = new BOSList<ICProductsInfo>();

            MEEmrStartupActionList = new BOSList<MEEmrActionsInfo>();
            MEEmrTemplateActionList = new BOSList<MEEmrTemplateActionsInfo>();
            METemplateUserGroupList = new BOSList<METemplateUserGroupsInfo>();
            METemplateChartList = new BOSList<METemplateChartsInfo>();
            METemplateChartSeriesList = new BOSList<METemplateChartSeriesInfo>();
            METemplateParamList = new BOSList<METemplateParamsInfo>();
        }

        #endregion

        public override void SetDefaultModuleObjects()
        {

        }

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new METemplatesInfo();

        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.MEParamsTableName, new MEParamsInfo());
            ModuleObjects.Add(TableName.MEEmrActionsTableName, new MEParamsInfo());
            ModuleObjects.Add(TableName.ICProductsTableName, new ICProductsInfo());
        }

        public override void InitModuleObjectList()
        {
            base.InitModuleObjectList();
            MEParamList.InitBOSList(this,
                                           String.Empty,
                                           TableName.MEParamsTableName,
                                           BOSList<MEParamsInfo>.cstRelationNone);
            MEEmrActionList.InitBOSList(this,
                                           String.Empty,
                                           TableName.MEEmrActionsTableName,
                                           BOSList<MEParamsInfo>.cstRelationNone);
            ICServiceList.InitBOSList(this,
                                          String.Empty,
                                          TableName.ICProductsTableName,
                                          BOSList<ICProductsInfo>.cstRelationNone);

            MEEmrTemplateActionList.InitBOSList(this,
               TableName.METemplatesTableName,
               TableName.MEEmrTemplateActionsTableName,
                BOSList<MEEmrTemplateActionsInfo>.cstRelationForeign);
            MEEmrTemplateActionList.ItemTableForeignKey = "FK_METemplateID";

            METemplateUserGroupList.InitBOSList(this,
              TableName.METemplatesTableName,
              TableName.METemplateUserGroupsTableName,
               BOSList<METemplateUserGroupsInfo>.cstRelationForeign);
            METemplateUserGroupList.ItemTableForeignKey = "FK_METemplateID";

            METemplateChartList.InitBOSList(this,
             TableName.METemplatesTableName,
             TableName.METemplateChartsTableName,
              BOSList<METemplateChartsInfo>.cstRelationForeign);
            METemplateChartList.ItemTableForeignKey = "FK_METemplateID";

            METemplateChartSeriesList.InitBOSList(this,
          TableName.METemplateChartsTableName,
          TableName.METemplateChartSeriesTableName,
           BOSList<METemplateChartSeriesInfo>.cstRelationForeign);
            METemplateChartSeriesList.ItemTableForeignKey = "FK_METemplateChartID";


            MEEmrStartupActionList.InitBOSList(this,
              String.Empty,
             TableName.MEEmrActionsTableName,
              BOSList<MEEmrActionsInfo>.cstRelationNone);

            METemplateParamList.InitBOSList(this,
             TableName.METemplatesTableName,
             TableName.METemplateParamsTableName,
              BOSList<METemplateParamsInfo>.cstRelationForeign);
            METemplateParamList.ItemTableForeignKey = "FK_METemplateID";
        }

        public override void InitGridControlInBOSList()
        {
            MEParamList.InitBOSListGridControl();
            MEEmrActionList.InitBOSListGridControl();

            MEEmrStartupActionList.InitBOSListGridControl();
            MEEmrTemplateActionList.InitBOSListGridControl();

            METemplateUserGroupList.InitBOSListGridControl();

            METemplateChartList.InitBOSListGridControl();
            METemplateChartSeriesList.InitBOSListGridControl();
            METemplateParamList.InitBOSListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            MEParamList.SetDefaultListAndRefreshGridControl();
            MEEmrActionList.SetDefaultListAndRefreshGridControl();

            MEEmrStartupActionList.SetDefaultListAndRefreshGridControl();
            MEEmrTemplateActionList.SetDefaultListAndRefreshGridControl();

            METemplateUserGroupList.SetDefaultListAndRefreshGridControl();

            METemplateChartList.SetDefaultListAndRefreshGridControl();
            METemplateChartSeriesList.SetDefaultListAndRefreshGridControl();

            METemplateParamList.SetDefaultListAndRefreshGridControl();
        }

        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateMainObject(int iObjectID)
        {
            base.InvalidateMainObject(iObjectID);
            
        }

        public override void InvalidateModuleObjects(int iObjectID)
        {
            MEEmrTemplateActionList.Invalidate(iObjectID);
            METemplateUserGroupList.Invalidate(iObjectID);
            METemplateChartList.Invalidate(iObjectID);
            if (METemplateChartList.Count > 0)
                METemplateChartSeriesList.Invalidate(METemplateChartList[0].METemplateChartID);
            else
                METemplateChartSeriesList.SetDefaultListAndRefreshGridControl();
            InvalidateActionList(iObjectID);

            METemplateParamList.Invalidate(iObjectID);
        }
        public void InvalidateActionList(int iObjectID)
        {
            MEEmrStartupActionList.Invalidate(iObjectID);
            //uthv thêm chức năng được gọi khi init/open/print/save
            //foreach (var item in MEEmrTemplateActionList)
            //{
            //    var a = MEEmrStartupActionList.Find(p => p.MEEmrActionID == item.FK_MEEmrActionID);
            //    MEEmrStartupActionList.Remove(a);
            //}
        }
        #endregion

        #region Save Module Objects functions
        public override int SaveMainObject()
        {
            return base.SaveMainObject();
        }

        public override void SaveModuleObjects()
        {
            MEEmrTemplateActionList.SaveItemObjects();
            METemplateUserGroupList.SaveItemObjects();
            METemplateChartList.SaveItemObjects();
            METemplateParamList.SaveItemObjects();
        }
        #endregion
    }
}
