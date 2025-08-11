using BOSComponent;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Localization;
using System;
using BOSCommon;

namespace BOSERP.Modules.SellStaff
{
    public partial class HRAllowancesGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            SellStaffEntities entity = (SellStaffEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.AllowanceList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = SellStaffLocalizedResource.HREmployeeAllowanceValue;
            column.FieldName = "HREmployeeAllowanceValue";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            gridView.DoubleClick += new EventHandler(GridView_DoubleClick);
            return gridView;
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            GridView gridView = (GridView)MainView;
            if (gridView.FocusedRowHandle >= 0)
            {
                HRAllowancesController objAllowancesController = new HRAllowancesController();
                HRAllowancesInfo objAllowancesInfo = (HRAllowancesInfo)gridView.GetRow(gridView.FocusedRowHandle);
                if (objAllowancesInfo != null)
                {
                    //BOSERP.Modules.HRAllowance.HRAllowanceModule allowanceModule = (BOSERP.Modules.HRAllowance.HRAllowanceModule)BOSApp.ShowModule(ModuleName.HRAllowance);
                    //if (allowanceModule != null)
                    //{
                    //    allowanceModule.ActionInvalidate(objAllowancesInfo.HRAllowanceID);
                    //}
                }
            }
        }
    }
}
