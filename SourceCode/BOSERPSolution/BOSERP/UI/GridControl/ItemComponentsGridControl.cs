using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Localization;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using BOSComponent;
using BOSLib;
using BOSCommon;

namespace BOSERP
{
    public partial class ItemComponentsGridControl : ItemGridControl
    {        
        /// <summary>
        /// Invalidate data source
        /// </summary>
        /// <param name="dataSource">Data source</param>
        public void InvalidateDataSource(BOSList<ICProductComponentsInfo> dataSource)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = dataSource;
            DataSource = bds;
            RefreshDataSource();
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            GridColumn column = gridView.Columns["ICProductComponentQty"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }            
            return gridView;
        }

        protected override void  GridView_KeyUp(object sender, KeyEventArgs e) 	 
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                GridView gridView = (GridView)sender;
                if (gridView.FocusedRowHandle >= 0)
                {
                    int index = gridView.GetDataSourceRowIndex(gridView.FocusedRowHandle);
                    List<ICProductComponentsInfo> productComponents = (List<ICProductComponentsInfo>)((BindingSource)DataSource).DataSource;
                    productComponents.RemoveAt(index);
                    RefreshDataSource();
                }
            }
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = SaleOrderLocalizedResources.ICProductDesc;
            column.FieldName = "ICProductDesc";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = SaleOrderLocalizedResources.ICProductSupplierNo;
            column.FieldName = "ICProductSupplierNo";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = SaleOrderLocalizedResources.ICStockName;
            column.FieldName = "FK_ICStockID";
            column.ColumnEdit = InitColumnLookupEdit(TableName.ICStocksTableName, SaleOrderLocalizedResources.ICStockName);
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = SaleOrderLocalizedResources.ICProductSerialNo;
            column.FieldName = "ICProductSerialNo";
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column);
        }        
    }
}
