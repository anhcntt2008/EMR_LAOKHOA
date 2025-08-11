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

namespace BOSERP.Modules.MEEmrAction
{
    public partial class MEActionRequestParamsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {

        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            GridColumn column = new GridColumn();
            column.Caption = "Tham số";
            column.FieldName = "Key";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Giá trị minh họa";
            column.FieldName = "Value";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.ShowAutoFilterRow = true;
            return gridView;
        }
        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView gridView = (GridView)this.MainView;
            base.GridView_FocusedRowChanged(sender, e);
        }
    }
}
