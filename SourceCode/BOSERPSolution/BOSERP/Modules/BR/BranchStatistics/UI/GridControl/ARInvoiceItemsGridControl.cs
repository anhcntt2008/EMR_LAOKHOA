using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BOSERP.Modules.BranchStatistics
{
    public partial class ARInvoiceItemsGridControl : BOSComponent.BOSGridControl
    {
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            gridView.OptionsView.ShowFooter = true;

            InitColumnSummary("ARInvoiceItemNetAmount", DevExpress.Data.SummaryItemType.Sum);
            InitColumnSummary("ARInvoiceItemTotalCost", DevExpress.Data.SummaryItemType.Sum);                        

            gridView.SortInfo.Add(new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gridView.Columns["ARInvoiceItemProductQty"], DevExpress.Data.ColumnSortOrder.Descending));
            return gridView;
        }
    }
}
