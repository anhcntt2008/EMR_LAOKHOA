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
using BOSERP;
using DevExpress.XtraEditors.Repository;
using System.Data;

namespace BOSERP.Modules.MEEmr
{
    public partial class MEEmrsSearchResultGridControl : BOSSearchResultsGridControl
    {
        private MEEmrEntities _entity;

        public MEEmrsSearchResultGridControl(IContainer container)
            : base(container)
        {

        }
        public MEEmrsSearchResultGridControl()
        {
        }
        protected override void AddColumnsToGridViewResults(DevExpress.XtraGrid.Views.Grid.GridView gridView, string strTableName)
        {
            base.AddColumnsToGridViewResults(gridView, strTableName);

            var column = gridView.Columns["FK_HRDepartmentShortID"];
            if (column != null)
            {
                column.UnboundType = DevExpress.Data.UnboundColumnType.String;
                var repLookupEdit = InitColumnLookupView(strTableName, "FK_HRDepartmentID", "Khoa (tên tắt)", "HRDepartmentAbbrev");
                if (repLookupEdit != null)
                    column.ColumnEdit = repLookupEdit;
            }
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeSearchResultsGridView()
        {
            GridView gridView = base.InitializeSearchResultsGridView();
            GridColumn column = gridView.Columns["MEEmrCreatedDate"];
            if (column != null)
            {
                column.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            }
            column = gridView.Columns["MEPatientBirthday"];
            if (column != null)
            {
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                column.DisplayFormat.FormatString = "dd/MM/yyyy";
            }
            column = gridView.Columns["MEEmrArchiveStatus"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = false;
                var rep = column.ColumnEdit as RepositoryItemLookUpEdit;
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
            gridView.RowStyle += GridView_RowStyle;
            gridView.CustomDrawCell += GridView_CustomDrawCell;
            _entity = (MEEmrEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            return gridView;
        }

        public override void GridViewSearchResults_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var dgvSearchResults = (GridView)sender;
            var row = dgvSearchResults.GetDataRow(dgvSearchResults.FocusedRowHandle);
            if (row != null)
            {
                var preEmrID = (_entity.MainObject as MEEmrsInfo)?.MEEmrID;
                if (preEmrID == (int)row["MEEmrID"]) return;

                Screen.Module.Toolbar.CurrentIndex = Screen.Module.Toolbar.ObjectCollection.Tables[0].Rows.IndexOf(row);
                Screen.Module.Toolbar.Invalidate();

                var currEmrID = (_entity.MainObject as MEEmrsInfo)?.MEEmrID;
                // khong thay doi dc vi cancel luu to hay vi ly do gi do
                if (preEmrID == currEmrID)
                    dgvSearchResults.FocusedRowHandle = e.PrevFocusedRowHandle;
            }
        }
        private void GridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView gridView = (GridView)sender;
                var row = gridView.GetDataRow(e.RowHandle);
                if (Convert.ToBoolean(row["MEEmrHasNote"]))
                {
                    e.Appearance.ForeColor = Color.DarkGreen;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }
            }
        }
        protected void GridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView gridView = (GridView)sender;
                var row = gridView.GetDataRow(e.RowHandle);
                if (e.Column.FieldName == "MEEmrNo"
                    || e.Column.FieldName == "MEEmrTypeProfile"
                    || e.Column.FieldName == "FK_MEEmrTypeID"
                    || e.Column.FieldName == "MEPatientName"
                    || e.Column.FieldName == "MEPatientNo"
                    || e.Column.FieldName == "FK_HRDepartmentID")
                {
                    switch (row["MEEmrTypeProfile"].ToString())
                    {
                        case "Patient":
                            e.Appearance.ForeColor = Color.Blue;
                            break;
                        case "Out":
                            e.Appearance.ForeColor = Color.DarkRed;
                            break;
                        default:
                            break;
                    }
                }
                else if (e.Column.FieldName == "MEEmrStatus")
                {
                    switch (row["MEEmrStatus"].ToString())
                    {
                        case "Closed":
                            e.Appearance.BackColor = Color.LightGray;
                            break;
                        default:
                            break;
                    }
                }
                else if (e.Column.FieldName == "MEEmrArchiveStatus")
                {
                    switch (row["MEEmrArchiveStatus"].ToString())
                    {
                        case "DigitalSigned":
                            e.Appearance.ForeColor = Color.Blue;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
