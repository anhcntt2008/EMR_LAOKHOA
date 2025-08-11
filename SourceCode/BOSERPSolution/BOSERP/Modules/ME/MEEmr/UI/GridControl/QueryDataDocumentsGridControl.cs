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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BOSERP.Modules.MEEmr.UI;

namespace BOSERP.Modules.MEEmr
{
    public partial class QueryDataDocumentsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (MEEmrEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            //BindingSource bds = new BindingSource();
            //bds.DataSource = entity.MEEmrDocumentsList;
            //DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            var column = new GridColumn();
            column.Caption = "Kết thúc";
            column.FieldName = "MEEmrDocumentEndDateStr";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Người ghi";
            column.FieldName = "ADUserGroupNames";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }
        private void gridView_MouseDown(object sender, MouseEventArgs e)
        {
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsBehavior.AutoExpandAllGroups = true;

            GridColumn column = gridView.Columns["MEEmrDocumentCreatedDate"];
            if (column != null)
            {
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                //column.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            }

            column = gridView.Columns["MEEmrDocumentGroup"];
            if (column != null)
            {
                column.Caption = "-";
                column.GroupIndex = 0;
                column.VisibleIndex = 999;
                column.Group();
                var groupSum = gridView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Average, "MEEmrDocumentOrder", null, ",{0:n0}");
                gridView.GroupSummarySortInfo.Add(groupSum, DevExpress.Data.ColumnSortOrder.Ascending, column);
                groupSum = gridView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "MEEmrDocumentID", null, "{0:n0}");
            }

            gridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseDown);
            gridView.CustomDrawGroupRow += GridView_CustomDrawGroupRow;
            return gridView;
        }
        void GridView_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo row = e.Info as GridGroupRowInfo;
            if (row.Column.FieldName == "MEEmrDocumentGroup")
            {
                var arr = row.GroupText.Split(',');
                if (arr.Length == 3)
                    row.GroupText = string.Format("[#image]{0}. {1} (SL:{2} tờ)", arr[1], row.GroupValueText, arr[2]);
            }
        }
        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
        }
        protected override void OnClick(EventArgs ev)
        {
            base.OnClick(ev);
        }
        protected override void GridView_RowClick(object sender, EventArgs e)
        {
            base.GridView_RowClick(sender, e);
            GridView gridView = (GridView)this.MainView;
            var module = ((MEEmrModule)((BaseModuleERP)Screen.Module));
            if (gridView.FocusedRowHandle >= 0)
            {
                ((guiDataQuery)Screen).GetMongoData(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrDocumentsInfo);
            }
        }
        protected override void GridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            var gridView = (GridView)sender;
            if (!gridView.IsValidRowHandle(e.RowHandle))
                return;
            if (gridView.IsRowSelected(e.RowHandle) || gridView.FocusedRowHandle == e.RowHandle)
            {
                e.Appearance.BackColor = System.Drawing.Color.LightBlue;
            }
            if (e.RowHandle >= 0)
            {
                var row = gridView.GetRow(e.RowHandle) as MEEmrDocumentsInfo;
                if (row != null)
                    if (e.Column.FieldName == "MEEmrDocumentStatus" || e.Column.FieldName == "FK_METemplateID")
                    {
                        switch (row.MEEmrDocumentStatus)
                        {
                            case "Discarded":
                                e.Appearance.ForeColor = Color.DarkRed;
                                break;
                            case "Closed":
                                e.Appearance.ForeColor = Color.DarkGray;
                                break;
                            case "Hidden":
                                e.Appearance.ForeColor = Color.DarkOrange;
                                break;
                            default:
                                break;
                        }
                    }
            }
        }
    }
}
