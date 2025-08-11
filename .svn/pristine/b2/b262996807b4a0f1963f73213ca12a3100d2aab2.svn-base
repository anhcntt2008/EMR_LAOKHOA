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
using BOSERP.Modules.METemplate;
using DevExpress.XtraEditors.Repository;
using System.Data;

namespace BOSERP.Modules.METemplate
{
    public partial class METemplateParamsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            METemplateEntities entity = (METemplateEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.METemplateParamList;
            this.DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            GridColumn column = gridView.Columns["FK_MEParamID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["METemplateParamPath"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["METemplateParamPrintHidden"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["METemplateParamManualAdded"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamRelationAllowMerge"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["METemplateParamDisabled"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["METemplateParamUpdateTo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                GenDummyRow(column.ColumnEdit);
            }
            column = gridView.Columns["METemplateParamOrder"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamFormatString"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamFormatType"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                GenDummyRow(column.ColumnEdit);
            }

            column = gridView.Columns["METemplateParamUpdToEmr"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                GenDummyRow(column.ColumnEdit);
            }

            column = gridView.Columns["MEParamImageHeight"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEParamImageWidth"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["METemplateParamRequired"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["METemplateParamSignAsGroup"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                GenDummyRow(column.ColumnEdit);
            }
            column = gridView.Columns["METemplateParamAlternativeSign"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            return gridView;
        }

        private void GenDummyRow(DevExpress.XtraEditors.Repository.RepositoryItem columnEdit)
        {
            var rep = columnEdit as RepositoryItemLookUpEdit;
            var tb = rep.DataSource as DataTable;
            if (tb.Rows.Count > 0)
            {
                DataRow dummyRow = tb.Rows[0];
                if (!string.IsNullOrEmpty(dummyRow["Key"].ToString()))
                {
                    dummyRow = tb.NewRow();
                    dummyRow["Key"] = string.Empty;
                    dummyRow["Value"] = string.Empty;
                    dummyRow["Text"] = string.Empty;
                    tb.Rows.InsertAt(dummyRow, 0);
                }
            }
        }

        protected override void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            base.GridView_InitNewRow(sender, e);
            GridView gridView = (GridView)sender;
            var row = (METemplateParamsInfo)gridView.GetRow(e.RowHandle);
            row.METemplateParamManualAdded = true;
        }
        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
        }
        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);
            GridView gridView = (GridView)MainView;
            if (e.KeyCode == Keys.Delete)
            {
                ((METemplateModule)Screen.Module).RemoveItemFromTemplateParamList();
            }
        }
    }
}
