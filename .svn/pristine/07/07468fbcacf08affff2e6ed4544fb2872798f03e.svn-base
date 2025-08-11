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
using DevExpress.XtraEditors.Repository;

namespace BOSERP.Modules.MEEmrManage
{
    public partial class GEObjectHistoryGridControl : BOSGridControl
    {
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.Appearance.GroupRow.ForeColor = Color.Black;
            gridView.OptionsSelection.MultiSelect = false;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsView.RowAutoHeight = true;
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsBehavior.AutoExpandAllGroups = true;

            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceHideSelection = true;

            GridColumn columnDate = gridView.Columns["GEObjectHistoryDate"];
            if (columnDate != null)
            {
                columnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                columnDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                columnDate.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            }

            var columnRemark = gridView.Columns["GEObjectHistoryRemark"];
            if (columnRemark != null)
            {
                var memoEdit = new RepositoryItemMemoEdit
                {
                    AutoHeight = true,
                    WordWrap = true
                };
                columnRemark.ColumnEdit = memoEdit;
                columnRemark.OptionsColumn.AllowEdit = false;
            }
            return gridView;
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);
        }
    }
}
