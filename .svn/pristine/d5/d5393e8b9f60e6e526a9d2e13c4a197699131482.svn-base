using BOSCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP.Modules.EmrAbbrev
{
    class EmrAbbrevEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSList<MEEmrAbbrevsInfo> MEEmrAbbrevList { get; set; }
        public BOSList<MEEmrAbbrevsInfo> MEEmrAbbrevSharedList { get; set; }
        #endregion

        #region Constructor
        public EmrAbbrevEntities()
            : base()
        {
            MEEmrAbbrevList = new BOSList<MEEmrAbbrevsInfo>();
            MEEmrAbbrevSharedList = new BOSList<MEEmrAbbrevsInfo>();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new MEEmrAbbrevsInfo();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.MEEmrAbbrevsTableName, new MEEmrAbbrevsInfo());
        }

        public override void InitModuleObjectList()
        {
            MEEmrAbbrevList.InitBOSList(this, TableName.HREmployeesTableName,
                                               TableName.MEEmrAbbrevsTableName,
                                               BOSList<MEEmrAbbrevsInfo>.cstRelationForeign);
            MEEmrAbbrevList.ItemTableForeignKey = "FK_HREmployeeID";

            MEEmrAbbrevSharedList.InitBOSList(this, TableName.HREmployeesTableName,
                                              TableName.MEEmrAbbrevsTableName,
                                              BOSList<MEEmrAbbrevsInfo>.cstRelationForeign);
            MEEmrAbbrevSharedList.ItemTableForeignKey = "FK_HREmployeeID";
        }

        public override void InitGridControlInBOSList()
        {
            MEEmrAbbrevList.InitBOSListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEEmrAbbrevList.SetDefaultListAndRefreshGridControl();
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
