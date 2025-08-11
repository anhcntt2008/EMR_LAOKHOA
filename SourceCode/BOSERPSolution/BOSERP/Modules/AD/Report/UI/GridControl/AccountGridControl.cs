using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BOSComponent;
using DevExpress.XtraGrid.Columns;
using Localization;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.Report
{
    public partial class AccountGridControl : BOSGridControl
    {
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = ReportLocalizedResources.Selected;
            column.FieldName = "Selected";
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column);
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.ShowAutoFilterRow = true;
            return gridView;
        }
    }
}
