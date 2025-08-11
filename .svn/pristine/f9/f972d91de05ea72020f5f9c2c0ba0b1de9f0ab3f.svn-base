using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Columns;
using Localization;

namespace BOSERP
{
    public partial class BaseDocumentGridControl : BOSSearchResultsGridControl
    {
        protected override void AddColumnsToGridViewResults(DevExpress.XtraGrid.Views.Grid.GridView gridView, string tableName)
        {
            base.AddColumnsToGridViewResults(gridView, tableName);

            GridColumn column = new GridColumn();
            column.Caption = CommonLocalizedResources.Object;
            column.FieldName = "ACObjectName";
            gridView.Columns.Add(column);
        }
    }
}
