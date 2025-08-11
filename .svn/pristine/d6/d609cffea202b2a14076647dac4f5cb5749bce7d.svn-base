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
using BOSLib;

namespace BOSERP.Modules.MEEmr
{
    public partial class MEEmrDocumentsForCheckupGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (MEEmrEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource
            {
                DataSource = entity.MEEmrDocumentsList
            };
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            var column = new GridColumn
            {
                Caption = "Kết thúc",
                FieldName = "MEEmrDocumentEndDateStr"
            };
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Người ghi",
                FieldName = "ADUserGroupNames"
            };
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Xem",
                FieldName = "Preview",
                VisibleIndex = 0,
                Width = 30,
                UnboundType = DevExpress.Data.UnboundColumnType.Object
            };
            var btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btn.Buttons[0].Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/print/preview_16x16.png");
            btn.AutoHeight = false;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            column.ColumnEdit = btn;
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.ReadOnly = true;
            gridView.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "In",
                FieldName = "Print",
                VisibleIndex = 1,
                Width = 25,
                UnboundType = DevExpress.Data.UnboundColumnType.Object
            };
            var btnPrint = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnPrint.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnPrint.Buttons[0].Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/print/print_16x16.png");
            btnPrint.AutoHeight = false;
            btnPrint.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            column.ColumnEdit = btnPrint;
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.ReadOnly = true;
            gridView.Columns.Add(column);
        }
        private void gridView_MouseDown(object sender, MouseEventArgs e)
        {
            var gridView = (GridView)sender;
            GridHitInfo hi = gridView.CalcHitInfo(this.PointToClient(MousePosition));
            if (hi.InRowCell && hi.Column.FieldName == "Preview")
            {
                ((MEEmrModule)Screen.Module).PreviewDocumentForPrint(gridView.GetRow(hi.RowHandle) as MEEmrDocumentsInfo);
                (e as DevExpress.Utils.DXMouseEventArgs).Handled = true;
            }
            else if (hi.InRowCell && hi.Column.FieldName == "Print")
            {
                BOSProgressBar.Start("Đang tải xuống và xử lý tập tin");
                try
                {
                    ((MEEmrModule)Screen.Module).QuickPrintDocument(gridView.GetRow(hi.RowHandle) as MEEmrDocumentsInfo);
                    BOSProgressBar.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    BOSProgressBar.Close();
                }
                (e as DevExpress.Utils.DXMouseEventArgs).Handled = true;
            }
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.Appearance.GroupRow.ForeColor = Color.Black;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            //gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsCustomization.AllowFilter = true;
            //gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
            //gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsBehavior.AutoExpandAllGroups = true;

            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceHideSelection = true;

            GridColumn column = gridView.Columns["MEEmrDocumentCreatedDate"];
            if (column != null)
            {
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }
            column = gridView.Columns["MEEmrDocumentSubOrder"];
            if (column != null)
            {
                column.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            }
            column = gridView.Columns["MEEmrDocumentGroup"];
            if (column != null)
            {
                column.Caption = "-";
                column.GroupIndex = 0;
                column.VisibleIndex = 1;
                column.Group();
                var groupSum = gridView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Average, "MEEmrDocumentOrder", null, "|{0:n0}");
                gridView.GroupSummarySortInfo.Add(groupSum, DevExpress.Data.ColumnSortOrder.Ascending, column);
                groupSum = gridView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "MEEmrDocumentID", null, "|{0:n0}");
            }
            column = gridView.Columns["FK_HRDepartmentShortID"];
            if (column != null)
            {
                column.UnboundType = DevExpress.Data.UnboundColumnType.String;
                var repLookupEdit = InitColumnLookupEdit("HRDepartments", "Khoa");
                repLookupEdit.DisplayMember = "HRDepartmentAbbrev";
                if (repLookupEdit != null)
                {
                    var colName = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                    colName.Caption = "Khoa (tên tắt)";
                    colName.FieldName = repLookupEdit.DisplayMember;
                    colName.Width = 100;
                    repLookupEdit.Columns.Add(colName);
                    column.ColumnEdit = repLookupEdit;
                }
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
                var arr = row.GroupText.Split('|');
                if (arr.Length == 3)
                    row.GroupText = string.Format("[#image]{0}. {1} (SL: {2} tờ)", arr[1].Trim().TrimEnd(','), row.GroupValueText, arr[2]);
            }
        }
        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var gridView = (GridView)sender;
            ((UI.guiCheckup)Screen).ViewLocalPdfFile(gridView.GetRow(e.FocusedRowHandle) as MEEmrDocumentsInfo);
        }
        protected override void OnClick(EventArgs ev)
        {
            base.OnClick(ev);
        }
        protected override void GridView_RowClick(object sender, EventArgs e)
        {
            base.GridView_RowClick(sender, e);
            GridView gridView = (GridView)this.MainView;
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
        }
    }
}
