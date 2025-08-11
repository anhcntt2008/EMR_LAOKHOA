using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BOSComponent;
using DevExpress.XtraGrid.Columns;
using Localization;

namespace BOSERP
{
    public partial class InventoryStatusGridControl : BOSGridControl
    {
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = BaseLocalizedResources.InventoryStatus;
            column.FieldName = "InventoryStatus";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = BaseLocalizedResources.ICProductSerialNo;
            column.FieldName = "ICProductSerialNo";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }        
    }
}
