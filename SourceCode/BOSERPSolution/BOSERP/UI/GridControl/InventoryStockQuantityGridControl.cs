using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using BOSComponent;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;
using DevExpress.XtraGrid;
using DevExpress.Data;

namespace BOSERP
{
    public partial class InventoryStockQuantityGridControl : BOSGridControl
    {
        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = BaseLocalizedResources.BRBranchName;
            column.FieldName = "BRBranchName";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = "InventoryType";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = "ICProductSerieNo";
            column.Caption = BaseLocalizedResources.ProductSerieNo;
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();

            GridColumn column = gridView.Columns["FK_ICStockID"];
            if (column != null)
            {                
                if (column.ColumnEdit != null)
                {
                    ICStocksController objStocksController = new ICStocksController();
                    DataSet ds = objStocksController.GetAllObjects();
                    if (ds.Tables.Count > 0)
                    {
                        (column.ColumnEdit as RepositoryItemLookUpEdit).DataSource = ds.Tables[0];
                    }
                }
            }

            gridView.GroupFormat = "[#image]{1}: {2}";
            column = gridView.Columns["InventoryType"];
            if (column != null)
            {
                column.Group();
                GridGroupSummaryItem summaryItem = (GridGroupSummaryItem)gridView.GroupSummary.Add(
                                                                    SummaryItemType.Sum, 
                                                                    "ICInventoryStockQuantity");
                summaryItem.DisplayFormat = "{0:n0}";
            }            

            return gridView;
        }
    }
}
