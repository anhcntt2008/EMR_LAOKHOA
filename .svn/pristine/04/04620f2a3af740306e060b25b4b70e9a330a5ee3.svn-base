using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;

namespace BOSERP.Modules.BranchStatistics
{
    public partial class AROwingInvoicesGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            BranchStatisticsEntities entity = (BranchStatisticsEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.AROwingInvoiceList;
            DataSource = bds;
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.ShowFooter = true;

            InitColumnSummary("ARInvoiceTotalAmount", DevExpress.Data.SummaryItemType.Sum);
            InitColumnSummary("ARInvoiceDepositBalance", DevExpress.Data.SummaryItemType.Sum);
            InitColumnSummary("ARInvoiceBalanceDue", DevExpress.Data.SummaryItemType.Sum);
            return gridView;
        }
    }
}
