using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BOSComponent;
using DevExpress.XtraGrid.Columns;
using Localization;

namespace BOSERP.Modules.ImportData
{
    public partial class ProductGridControl : BOSGridControl
    {
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = ImportDataLocalizedResources.ICDepartmentNo;
            column.FieldName = "ICDepartmentNo";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = ImportDataLocalizedResources.ParentProductGroupNo;
            column.FieldName = "ParentProductGroupNo";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = ImportDataLocalizedResources.ChildProductGroupNo;
            column.FieldName = "ChildProductGroupNo";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);            
        }
    }
}
