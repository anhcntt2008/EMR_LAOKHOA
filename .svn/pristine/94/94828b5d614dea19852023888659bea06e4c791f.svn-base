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
using System.Drawing;

namespace BOSERP.Modules.MEEmr
{
    public partial class MEEmrMergeHistoriesGridControl : BOSGridControl
    {
        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsBehavior.AutoExpandAllGroups = true;
            gridView.BestFitColumns();

            var columnId = gridView.Columns["MEEmrMergeHistoryID"];
            if (columnId != null)
            {
                columnId.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            }

            var columnDate = gridView.Columns["MEEmrMergeHistoryDate"];
            if (columnDate != null)
            {
                columnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                columnDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                columnDate.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            }

            return gridView;
        }
    }
}
