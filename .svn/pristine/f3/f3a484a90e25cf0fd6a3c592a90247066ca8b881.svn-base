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
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;

namespace BOSERP.Modules.MEEmr
{
    public partial class MEEmrRelationSelectionGridControl : BOSGridControl
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
            gridView.OptionsSelection.MultiSelect = false;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            return gridView;
        }
        //protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        //{
        //}
        protected override void GridView_Click(object sender, EventArgs e)
        {
            base.GridView_Click(sender, e);
        }
        protected override void GridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            var gridView = (GridView)sender;
        }
    }
}
