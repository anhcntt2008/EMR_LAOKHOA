using BOSComponent;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Localization;
using System;
using BOSCommon;

namespace BOSERP.Modules.SellStaff
{
    public partial class ARDeliverysGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            SellStaffEntities entity = (SellStaffEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.DeliverysList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            gridView.OptionsView.ShowFooter = true;
            GridColumn column = gridView.Columns["ARDeliveryTotalKm"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                InitColumnSummary("ARDeliveryTotalKm", DevExpress.Data.SummaryItemType.Sum);
            }
            gridView.DoubleClick += new EventHandler(GridView_DoubleClick);
            return gridView;
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            GridView gridView = (GridView)MainView;
            if (gridView.FocusedRowHandle >= 0)
            {
                ARDeliverysController objDeliverysController = new ARDeliverysController();
                ARDeliverysInfo objDeliverysInfo = (ARDeliverysInfo)gridView.GetRow(gridView.FocusedRowHandle);
                if (objDeliverysInfo != null)
                {
                    //BOSERP.Modules.DeliveryManagement.DeliveryManagementModule deliveryModule = (BOSERP.Modules.DeliveryManagement.DeliveryManagementModule)BOSApp.ShowModule(ModuleName.DeliveryManagement);
                    //if (deliveryModule != null)
                    //    deliveryModule.ActionInvalidate(objDeliverysInfo.ARDeliveryID);
                }
            }
        }
    }

}
