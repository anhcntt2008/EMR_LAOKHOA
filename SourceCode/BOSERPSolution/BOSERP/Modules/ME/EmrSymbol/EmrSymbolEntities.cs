using BOSCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSERP.Modules.EmrSymbol
{
    class EmrSymbolEntities : ERPModuleEntities
    {
        private MEEmrSymbolsController _symbolCtrl;
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSList<MEEmrSymbolsInfo> MEEmrSymbolList { get; set; }
        #endregion

        #region Constructor
        public EmrSymbolEntities()
            : base()
        {
            MEEmrSymbolList = new BOSList<MEEmrSymbolsInfo>();
            _symbolCtrl = new MEEmrSymbolsController();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new MEEmrSymbolsInfo();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.MEEmrSymbolsTableName, new MEEmrSymbolsInfo());
        }

        public override void InitModuleObjectList()
        {
            MEEmrSymbolList.InitBOSList(this, TableName.MEEmrSymbolsTableName,
                                               TableName.MEEmrSymbolsTableName,
                                               BOSList<MEEmrSymbolsInfo>.cstRelationNone);
        }

        public override void InitGridControlInBOSList()
        {
            MEEmrSymbolList.InitBOSListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEEmrSymbolList.SetDefaultListAndRefreshGridControl();
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
