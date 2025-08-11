using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSComponent;
using BOSLib;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace BOSERP
{
    public partial class ItemGridControl : BOSGridControl
    {
        /// <summary>
        /// A variable to store the serie column name
        /// </summary>
        private string SerieColumnName = string.Empty;               

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(GridView_FocusedColumnChanged);
            gridView.DoubleClick += new EventHandler(GridView_DoubleClick);            
            return gridView;
        }

        protected override void GridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);

            GridView gridView = (GridView)sender;
            if (gridView.FocusedRowHandle >= 0)
            {               
                if (e.Column.FieldName == "FK_ICStockID" || e.Column.FieldName.Contains("ProductSerialNo"))
                {
                    BusinessObject item = (BusinessObject)gridView.GetRow(gridView.FocusedRowHandle); 
                    ((BaseTransactionModule)Screen.Module).InvalidateItemSerieNo(item, BOSDataSource, SerieColumnName);
                }
            }
        }

        protected override void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            base.GridView_FocusedRowChanged(sender, e);

            GridView gridView = (GridView)sender;
            if (gridView.FocusedColumn!=null && gridView.FocusedColumn.FieldName.Contains("ProductSerialNo"))
            {
                SerieColumnName = gridView.FocusedColumn.FieldName;
                if (gridView.FocusedRowHandle >= 0)
                {
                    BusinessObject item = (BusinessObject)gridView.GetRow(gridView.FocusedRowHandle);
                    ((BaseTransactionModule)Screen.Module).InvalidateSerieColumn(gridView.FocusedColumn, item, BOSDataSource);
                }
                else
                {
                    GridColumn column = gridView.Columns[SerieColumnName];
                    if (column != null)
                    {
                        column.ColumnEdit = null;
                    }
                }
            }
        }

        protected virtual void GridView_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            GridView gridView = (GridView)sender;            
            if (gridView.FocusedColumn.FieldName.Contains("ProductSerialNo"))
            {
                SerieColumnName = gridView.FocusedColumn.FieldName;
                if (gridView.FocusedRowHandle >= 0)
                {
                    BusinessObject item = (BusinessObject)gridView.GetRow(gridView.FocusedRowHandle);
                    ((BaseTransactionModule)Screen.Module).InvalidateSerieColumn(gridView.FocusedColumn, item, BOSDataSource);
                }
            }
            else
            {
                GridColumn column = gridView.Columns[SerieColumnName];
                if (column != null)
                {
                    column.ColumnEdit = null;
                }
            }
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ShowInventory();
            }
            catch (Exception ex)
            {
                // UtHV co tinh giau exception nay tren ban free
                // co thoi gian fix sau.
            }
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ShowInventory();
            }
        }

        /// <summary>
        /// Show inventory details of the current item
        /// </summary>
        private void ShowInventory()
        {
            GridView gridView = (GridView)MainView;
            if (gridView.FocusedRowHandle >= 0)
            {
                BusinessObject item = (BusinessObject)gridView.GetRow(gridView.FocusedRowHandle);
                BOSDbUtil dbUtil = new BOSDbUtil();
                int productID = dbUtil.GetPropertyIntValue(item, "FK_ICProductID");
                ((BaseTransactionModule)Screen.Module).ShowInventory(productID);
            }
        }
    }
}
