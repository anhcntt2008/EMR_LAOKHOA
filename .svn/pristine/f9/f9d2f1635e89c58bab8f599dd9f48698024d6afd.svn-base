using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using BOSCommon;
using DevExpress.XtraGrid.Views.Base;

namespace BOSERP.Modules.HRDepartment
{
    public partial class HRDepartmentRoomsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            HRDepartmentEntities entity = (HRDepartmentEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.DepartmentRoomList;
            DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            GridColumn column = gridView.Columns["HRDepartmentRoomNo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            
            column = gridView.Columns["HRDepartmentRoomName"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["HRDepartmentRoomDesc"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["FK_BRBranchID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }


            gridView.RowClick += new RowClickEventHandler(GridView_RowClick);
            return gridView;
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((HRDepartmentModule)Screen.Module).RemoveItemFromList();
            }
        }
        private void GridView_RowClick(object sender, RowClickEventArgs e)
        {
            GridView gridView = (GridView)sender;
            if (e.RowHandle >= 0)
            {
                HRRoomBedsGridControl roomBedGridControl = (HRRoomBedsGridControl)Screen.Module
                                                                    .Controls[HRDepartmentModule.RoomBedGridControlName];
                HRDepartmentEntities entity = (HRDepartmentEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
                HRDepartmentRoomsInfo objDepartmentRoomsInfo = (HRDepartmentRoomsInfo)gridView.GetRow(e.RowHandle);
                if (objDepartmentRoomsInfo != null)
                {
                    if (objDepartmentRoomsInfo.RoomBedList == null)
                    {
                        objDepartmentRoomsInfo.RoomBedList = new BOSList<HRRoomBedsInfo>();
                        objDepartmentRoomsInfo.RoomBedList.InitBOSList(entity,
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
    }
}
