using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSLib;
using BOSCommon;

namespace BOSERP.Modules.MEParamLookup
{
    public class MEParamLookupEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSList<MEParamLookupDatasInfo> MEParamLookupDataList { get; set; }
        #endregion

        #region Constructor
        public MEParamLookupEntities()
            : base()
        {
            MEParamLookupDataList = new BOSList<MEParamLookupDatasInfo>();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new MEParamLookupsInfo();
            SearchObject = new MEParamLookupsInfo();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.MEParamLookupDatasTableName, new MEParamLookupDatasInfo());
        }

        public override void InitModuleObjectList()
        {
            MEParamLookupDataList.InitBOSList(this,
                                               TableName.MEParamLookupsTableName,
                                               TableName.MEParamLookupDatasTableName,
                                               BOSList<MEParamLookupDatasInfo>.cstRelationForeign);
            MEParamLookupDataList.ItemTableForeignKey = "FK_MEParamLookupID";
        }

        public override void InitGridControlInBOSList()
        {
            MEParamLookupDataList.InitBOSListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEParamLookupDataList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }
        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateModuleObjects(int iObjectID)
        {
            MEParamLookupDataList.Invalidate(iObjectID);
        }
        #endregion

        public override void SaveModuleObjects()
        {
            MEParamLookupDataList.SaveItemObjects();
        }
    }
}
