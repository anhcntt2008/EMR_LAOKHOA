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
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BOSERP.Modules.MEEmr
{
    public partial class SelectionTemplateGridControl : BOSGridControl
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
            gridView.OptionsCustomization.AllowFilter = false;
            gridView.OptionsView.ShowAutoFilterRow = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsBehavior.Editable = false;
            gridView.DoubleClick += new EventHandler(gridView_DoubleClick);
            return gridView;
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                var row = view.GetRow(info.RowHandle) as METemplatesInfo;
                ((UI.DSMEEMR100)Screen).Ok(row);
            }
        }

        public override void InitEmbeddedNavigator()
        {
            UseEmbeddedNavigator = false;
        }

        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
        }
    }
}
