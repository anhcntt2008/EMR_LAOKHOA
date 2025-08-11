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
using DevExpress.XtraEditors.Repository;
using System.Data;
using BOSCommon;

namespace BOSERP
{
    public partial class ACDocTypeEntryAccountsGridControl : BOSGridControl
    {
        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.KeyUp += new KeyEventHandler(GridView_KeyUp);
            return gridView;
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            GridView gridView = (GridView)MainView;
            if (e.KeyCode == Keys.Delete)
            {
                gridView.DeleteSelectedRows();
            }
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = CommonLocalizedResources.ACAccountNo;
            column.FieldName = "ACAccountNo";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = CommonLocalizedResources.ACAccountName;
            column.FieldName = "ACAccountName";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }
    }
}
