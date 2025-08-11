using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSLib;

namespace BOSERP.Modules.Branch
{
    public class BranchEntities : ERPModuleEntities
    {
        #region Declare Constant
        public readonly static String strBRBranchsObjectName = "BRBranchs";

        #endregion

        #region Declare all entities variables
        private BRBranchsInfo _BRBranchsObject;
        #endregion

        #region Public Properties
        public BRBranchsInfo BRBranchsObject
        {
            get
            {
                return _BRBranchsObject;
            }
            set
            {
                _BRBranchsObject = value;
            }
        }

        /// <summary>
        /// Gets or sets location tree list control
        /// </summary>
        public BOSTreeList LocationTreeList { get; set; }
        #endregion

        #region Constructor
        public BranchEntities()
            : base()
        {
            _BRBranchsObject = new BRBranchsInfo();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {

            MainObject = BRBranchsObject;
            LocationTreeList = new BOSTreeList();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.GELocationsTableName, new GELocationsInfo());
        }

        public override void InitModuleObjectList()
        {
            LocationTreeList.InitBOSList(this,
                                    String.Empty,
                                    TableName.GELocationsTableName,
                                    BOSTreeList.cstRelationNone);
        }

        public override void InitGridControlInBOSList()
        {
            LocationTreeList.InitBOSTreeListControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                LocationTreeList.SetDefaultListAndRefreshTreeListControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateMainObject(int iObjectID)
        {
            base.InvalidateMainObject(iObjectID);

            BRBranchsInfo objBranchsInfo = (BRBranchsInfo)MainObject;
            GELocationsController objLocationsController = new GELocationsController();
            objBranchsInfo.GELocationName = objLocationsController.GetFullLocationNameByID(objBranchsInfo.FK_GELocationID);
            UpdateMainObjectBindingSource();
        }

        public override void InvalidateModuleObjects(int iObjectID)
        {
        }


        #endregion

        #region Save Module Objects functions
        public override int SaveMainObject()
        {
            BRBranchsInfo objBranchsInfo = (BRBranchsInfo)MainObject;
            objBranchsInfo.BRBranchContactAddressLine3 = BOSUtil.GenerateFullAddress(objBranchsInfo, AddressType.Contact.ToString());
            return base.SaveMainObject();
        }

        public override void SaveModuleObjects()
        {
        }

        #endregion     
    }
}
