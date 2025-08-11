using BOSCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP.Modules.EmrShared
{
    class EmrSharedEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSList<MEEmrsInfo> MEEmrSharedList { get; set; }
        public BOSList<MEEmrShareHistoriesInfo> MEEmrShareHistoryList { get; set; }
        #endregion

        #region Constructor
        public EmrSharedEntities()
            : base()
        {
            MEEmrSharedList = new BOSList<MEEmrsInfo>();
            MEEmrShareHistoryList = new BOSList<MEEmrShareHistoriesInfo>();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new MEEmrsInfo();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.MEEmrsTableName, new MEEmrsInfo());
        }

        public override void InitModuleObjectList()
        {
            MEEmrSharedList.InitBOSList(this, TableName.HRDepartmentsTableName,
                                               TableName.MEEmrsTableName,
                                               BOSList<MEEmrsInfo>.cstRelationForeign);
            MEEmrSharedList.ItemTableForeignKey = "FK_HRDepartmentID";

            MEEmrShareHistoryList.InitBOSList(this, TableName.MEEmrsTableName,
                                              TableName.MEEmrShareHistoriesTableName,
                                              BOSList<MEEmrShareHistoriesInfo>.cstRelationForeign);
            MEEmrShareHistoryList.ItemTableForeignKey = "FK_MEEmrID";
        }

        public override void InitGridControlInBOSList()
        {
            MEEmrSharedList.InitBOSListGridControl();
            MEEmrShareHistoryList.InitBOSListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEEmrSharedList.SetDefaultListAndRefreshGridControl();
                MEEmrShareHistoryList.SetDefaultListAndRefreshGridControl();
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
        }
        #endregion

        public override void SaveModuleObjects()
        {
        }
    }
}
