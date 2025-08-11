using BOSComponent;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Localization;
using System;
using BOSCommon;
using DevExpress.XtraGrid.Views.Base;

namespace BOSERP.Modules.SellStaff
{
    public partial class HREmployeeStatesGridControl : BOSGridControl
    {
        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            var gridView = base.InitializeGridView();

            gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gridView.OptionsCustomization.AllowFilter = false;
            gridView.OptionsView.ShowAutoFilterRow = false;
            gridView.OptionsView.RowAutoHeight = false;

            gridView.DoubleClick += new EventHandler(GridView_DoubleClick);
            GridColumn column = gridView.Columns["HREmployeeStateID"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["HREmployeeStateCode"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["HREmployeeStateName"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            return gridView;
        }
        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            GridView gridView = (GridView)MainView;
            if (gridView.FocusedRowHandle >= 0)
            {
            }
        }
        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            //if (e.KeyCode == Keys.Delete)
            //{
            //    ((SellStaffModule)Screen.Module).DeleteEmpWorkingDeptsFromList();
            //}
        }
        protected override void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            base.GridView_InitNewRow(sender, e);
        }
        protected override void GridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);
        }
    }

}
