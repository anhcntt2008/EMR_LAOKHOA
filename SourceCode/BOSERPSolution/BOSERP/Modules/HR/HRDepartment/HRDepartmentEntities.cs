using System;
using System.Collections.Generic;
using System.Text;
using BOSCommon;
using BOSLib;

namespace BOSERP.Modules.HRDepartment
{
    public class HRDepartmentEntities : ERPModuleEntities
    {
        #region Declare Constant
        #endregion
        
        #region Declare all entities variables
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the room list of the department
        /// </summary>
        public BOSList<HRDepartmentRoomsInfo> DepartmentRoomList { get; set; }
        #endregion

        #region Constructor
        public HRDepartmentEntities()
            : base()
        {
            DepartmentRoomList = new BOSList<HRDepartmentRoomsInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new HRDepartmentsInfo();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.HRDepartmentRoomsTableName, new HRDepartmentRoomsInfo());
        }

        public override void InitModuleObjectList()
        {
            DepartmentRoomList.InitBOSList(
                                            this,
                                            TableName.HRDepartmentsTableName,
                                            TableName.HRDepartmentRoomsTableName,                                            
                                            BOSList<HRDepartmentsInfo>.cstRelationForeign);
            DepartmentRoomList.ItemTableForeignKey = "FK_HRDepartmentID";
        }

        public override void InitGridControlInBOSList()
        {
            DepartmentRoomList.InitBOSListGridControl();
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();
            HRDepartmentsInfo objDepartmentsInfo = (HRDepartmentsInfo)MainObject;
            objDepartmentsInfo.HRDepartmentStatusCombo = DepartmentStatus.Active.ToString();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                DepartmentRoomList.SetDefaultListAndRefreshGridControl();
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
        }

        public override void InvalidateModuleObjects(int iObjectID)
        {
            DepartmentRoomList.Invalidate(iObjectID);
            if (DepartmentRoomList.Count > 0)
            {
                HRRoomBedsGridControl roomBedGridControl = (HRRoomBedsGridControl)Module.Controls[HRDepartmentModule.RoomBedGridControlName];
                HRDepartmentRoomsInfo objDepartmentRoomsInfo = (HRDepartmentRoomsInfo)DepartmentRoomList[0];
                if (objDepartmentRoomsInfo != null)
                {
                    if (objDepartmentRoomsInfo.RoomBedList == null)
                    {
                        objDepartmentRoomsInfo.RoomBedList = new BOSList<HRRoomBedsInfo>();
                        objDepartmentRoomsInfo.RoomBedList.InitBOSList(this,
                                                                            TableName.HRDepartmentRoomsTableName,
                                                                            TableName.HRRoomBedsTableName,
                                                                            BOSList<HRRoomBedsInfo>.cstRelationForeign);
                        objDepartmentRoomsInfo.RoomBedList.ItemTableForeignKey = "FK_HRDepartmentRoomID";
                        ((BOSList<HRRoomBedsInfo>)objDepartmentRoomsInfo.RoomBedList).GridControl = roomBedGridControl;
                        if (objDepartmentRoomsInfo.HRDepartmentRoomID > 0)
                        {
                            objDepartmentRoomsInfo.RoomBedList.Invalidate(objDepartmentRoomsInfo.HRDepartmentRoomID);
                        }
                    }
                    roomBedGridControl.InvalidateDataSource(objDepartmentRoomsInfo.RoomBedList);
                }
            }
        }
        #endregion

        #region Save Module Objects functions
        public override int SaveMainObject()
        {
            return base.SaveMainObject();
        }
        public override void SaveModuleObjects()
        {
            DepartmentRoomList.SaveItemObjects();
            SaveRoomBedList(DepartmentRoomList);
        }
        private void SaveRoomBedList(BOSList<HRDepartmentRoomsInfo> departmentRoomList)
        {
            foreach (HRDepartmentRoomsInfo objDepartmentRoomsInfo in departmentRoomList)
            {
                if (objDepartmentRoomsInfo.RoomBedList != null)
                {
                    foreach (HRRoomBedsInfo objRoomBedsInfo in objDepartmentRoomsInfo.RoomBedList)
                    {
                        objRoomBedsInfo.FK_HRDepartmentID = objDepartmentRoomsInfo.FK_HRDepartmentID;
                        objRoomBedsInfo.FK_HRDepartmentRoomID = objDepartmentRoomsInfo.HRDepartmentRoomID;
                        objRoomBedsInfo.HRRoomBedStatus = RoomBedStatus.Available.ToString();
                    }
                    objDepartmentRoomsInfo.RoomBedList.SaveItemObjects();
                }
            }
        }
        #endregion
    }
}
