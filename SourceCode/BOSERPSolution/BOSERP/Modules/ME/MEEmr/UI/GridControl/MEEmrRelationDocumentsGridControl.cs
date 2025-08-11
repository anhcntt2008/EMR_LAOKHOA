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
using DevExpress.XtraEditors;
using BOSCommon;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout.ViewInfo;

namespace BOSERP.Modules.MEEmr
{
    public partial class MEEmrRelationDocumentsGridControl : BOSGridControl
    {
        public MEEmrRelationDocumentsGridControl()
        {
            this.ProcessGridKey += Grid_ProcessGridKey;
        }

        private void Grid_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                return;
            }
        }
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            var column = new GridColumn
            {
                Caption = "Kết thúc",
                FieldName = "MEEmrDocumentEndDateStr",
                VisibleIndex = -1
            };
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Người ghi",
                FieldName = "ADUserGroupNames",
                VisibleIndex = -1
            };
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Xem",
                FieldName = "Preview",
                VisibleIndex = -1,
                Width = 25,
                UnboundType = DevExpress.Data.UnboundColumnType.Object
            };
            var btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btn.Buttons[0].Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/print/preview_16x16.png");
            btn.AutoHeight = false;
            //btn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {new DevExpress.XtraEditors.Controls.EditorButton()});
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            column.ColumnEdit = btn;
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
                ((MEEmrModule)Screen.Module).PreviewDocument(gridView.GetRow(hi.RowHandle) as MEEmrDocumentsInfo);
                (e as DevExpress.Utils.DXMouseEventArgs).Handled = true;
            }
            Console.WriteLine("gridView_MouseDown(object sender, MouseEventArgs e): " + hi.HitTest + "/" + hi.InRowCell);
        }
        private void gridView_MouseUp(object sender, MouseEventArgs e)
        {
            var gridView = (GridView)sender;
            GridHitInfo hi = gridView.CalcHitInfo(this.PointToClient(MousePosition));
            if (hi.RowHandle != gridView.FocusedRowHandle)
            {
                var topIdx = gridView.TopRowIndex;
                gridView.FocusedRowHandle = GetFocusedRowHandleByCurrentDocument();
                gridView.TopRowIndex = topIdx;
            }
            /*if (gridView.IsGroupRow(hi.RowHandle))
            {
                gridView.TopRowIndex = (hi.RowHandle);
                Console.WriteLine("TopRowIndex(object sender, MouseEventArgs e): " + hi.RowHandle);
            }*/
        }
        private int GetFocusedRowHandleByCurrentDocument()
        {
            var entity = (MEEmrEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            var document = entity.ModuleObjects[TableName.MEEmrDocumentsTableName] as MEEmrDocumentsInfo;
            GridView gridView = (GridView)this.MainView;
            return gridView.LocateByValue("MEEmrDocumentID", document.MEEmrDocumentID);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.IndicatorWidth = 35;
            gridView.Appearance.GroupRow.ForeColor = Color.Black;
            gridView.OptionsSelection.MultiSelect = false;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsCustomization.AllowSort = false;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.ShowGroupPanel = false;
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
                //column.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            }
            column = gridView.Columns["MEEmrDocumentSubOrder"];
            if (column != null)
            {
                //column.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            }
            column = gridView.Columns["MEEmrDocumentGroup"];
            if (column != null)
            {
                column.Caption = "-";
                column.GroupIndex = 0;
                column.VisibleIndex = 999;
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
                    var colName = new DevExpress.XtraEditors.Controls.LookUpColumnInfo
                    {
                        Caption = "Khoa (tên tắt)",
                        FieldName = repLookupEdit.DisplayMember,
                        Width = 100
                    };
                    repLookupEdit.Columns.Add(colName);
                    column.ColumnEdit = repLookupEdit;
                }
            }
            gridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseDown);
            gridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseUp);
            gridView.CustomDrawGroupRow += GridView_CustomDrawGroupRow;
            gridView.CustomDrawRowIndicator += GridView_CustomDrawRowIndicator;
            if (Devide.Current == Devide.Tablet)
                gridView.GroupRowHeight = 30;
            return gridView;
        }
        private void GridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        void GridView_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo row = e.Info as GridGroupRowInfo;
            if (row.Column.FieldName == "MEEmrDocumentGroup")
            {
                var arr = row.GroupText.Split('|');
                if (arr.Length == 3)
                    row.GroupText = string.Format("[#image]{0}. {1} (SL: {2} tờ)", arr[1].Trim().TrimEnd(','), row.GroupValueText, arr[2]);
            }
        }
        public override void InitEmbeddedNavigator()
        {
            UseEmbeddedNavigator = true;
            EmbeddedNavigator.Name = "navigator_" + Name;
            foreach (NavigatorButton item in EmbeddedNavigator.Buttons.ButtonCollection)
            {
                item.Visible = false;
            }
            EmbeddedNavigator.TextLocation = NavigatorButtonsTextLocation.None;
            var refreshButton = new NavigatorCustomButton(11, "Làm mới cây bệnh án")
            {
                Tag = "RefreshData",
                Visible = true
            };
            EmbeddedNavigator.Buttons.CustomButtons.AddRange(new[] { refreshButton });
            EmbeddedNavigator.ButtonClick += NavigatorButton_ClickOverride;
        }

        private void NavigatorButton_ClickOverride(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            if (e.Button.Tag.ToString() == "RefreshData")
            {
                (Screen.Module as MEEmrModule).InvalidateEmrDocumentList();
            }
        }

        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            Console.WriteLine("protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e): " + e.FocusedRowHandle + "/" + e.PrevFocusedRowHandle);
        }
        protected override void OnClick(EventArgs ev)
        {
            base.OnClick(ev);
        }
        protected override void GridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            var gridView = (GridView)sender;
            if (!gridView.IsValidRowHandle(e.RowHandle)) return;
            if (gridView.IsRowSelected(e.RowHandle) || gridView.FocusedRowHandle == e.RowHandle)
            {
                e.Appearance.BackColor = System.Drawing.Color.LightBlue;
            }
            if (e.RowHandle >= 0)
            {
                var row = gridView.GetRow(e.RowHandle) as MEEmrDocumentsInfo;
                if (row != null)
                {
                    if (e.Column.FieldName == "MEEmrDocumentStatus" || e.Column.FieldName == "FK_METemplateID")
                    {
                        if (row.MEEmrDocumentHasNote)
                        {
                            e.Appearance.ForeColor = Color.DarkGreen;
                            e.Appearance.FontStyleDelta = FontStyle.Bold;
                        }
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
                    if (e.Column.FieldName == "MEEmrDocumentBgJobStatus")
                    {
                        switch (row.MEEmrDocumentBgJobStatus)
                        {
                            case "CreatedWithErr":
                                e.Appearance.ForeColor = Color.DarkRed;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
