using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BOSCommon;
using BOSLib;
using System.Data;

namespace BOSERP.Modules.Report
{
    public class ReportEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        #endregion

        #region Constructor
        public ReportEntities()
            : base()
        {
        }

        #endregion

        public override void SetDefaultModuleObjects()
        {

        }

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new ADReportsInfo();
        }

        public override void InitModuleObjects()
        {
        }

        public override void InitModuleObjectList()
        {
            base.InitModuleObjectList();
        }

        public override void InitGridControlInBOSList()
        {
        }

        public override void SetDefaultModuleObjectsList()
        {
        }

        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateMainObject(int iObjectID)
        {
            base.InvalidateMainObject(iObjectID);

        }

        public override void InvalidateModuleObjects(int iObjectID)
        {
        }
        public void InvalidateActionList(int iObjectID)
        {
        }
        #endregion

        #region Save Module Objects functions
        public override int SaveMainObject()
        {
            return base.SaveMainObject();
        }

        public override void SaveModuleObjects()
        {
        }
        #endregion
    }
}
