using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;
using DevExpress.XtraEditors.Repository;
using BOSCommon;
using BOSERP.Modules.ME.MEService.Localization;

namespace BOSERP.Modules.MEService
{
    public partial class ServiceGridControl : BOSGridControl
    {
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            foreach (GridColumn column in gridView.Columns)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            GridColumn col = gridView.Columns["ICProductName"];
            if (col != null)
            {
                col.Caption = ServiceLocalizedResources.ICProductName;
            }

            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            return gridView;
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
           

            GridColumn column = new GridColumn();
            column.Caption = ServiceLocalizedResources.ACAccounts;
            column.FieldName = "FK_ACAccountID";
            column.OptionsColumn.AllowEdit = true;
            RepositoryItemBOSLookupEdit rep = InitColumnLookupEdit(TableName.ACAccountsTableName, ServiceLocalizedResources.ACAccountNo);
            if (rep != null)
            {
                rep.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ACAccountName", ServiceLocalizedResources.ACAccountName));
                column.ColumnEdit = rep;
            }

            gridView.Columns.Add(column);
        }

        public void InvalidateDataSource(IBOSList<ICProductsInfo> dataSource)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = dataSource;
            DataSource = bds;
            RefreshDataSource();
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                BOSList<ICProductsInfo> productList = (BOSList<ICProductsInfo>)((BindingSource)DataSource).DataSource;
                productList.RemoveSelectedRowObjectFromList();
            }
        }
    }
}
