using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;
using DevExpress.XtraGrid.Views.Base;

namespace BOSERP.Modules.MEEmr
{
    public partial class DataSelectionGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);


        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView.OptionsSelection.MultiSelect = false;
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(GridView_SelectionChanged);
            return gridView;
        }
        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
        }
        //bool isRunning = false;
        private void GridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //if (isRunning) return;
            //isRunning = true;
            //GridView View = sender as GridView;
            //if (e.Action == CollectionChangeAction.Add && View.IsGroupRow(e.ControllerRow))
            //{
            //    View.UnselectRow(e.ControllerRow);
            //}
            //if (e.Action == CollectionChangeAction.Refresh && View.SelectedRowsCount > 0)
            //{
            //    View.BeginSelection();
            //    foreach (int Row in View.GetSelectedRows())
            //    {
            //        if (View.IsGroupRow(Row)) View.UnselectRow(Row);
            //    }
            //    View.EndSelection();
            //}
            //isRunning = false;
        }
    }
}
