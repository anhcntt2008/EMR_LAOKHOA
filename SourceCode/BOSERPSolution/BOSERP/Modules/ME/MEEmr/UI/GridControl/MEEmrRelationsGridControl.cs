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
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using System.Data;

namespace BOSERP.Modules.MEEmr
{
    public partial class MEEmrRelationsGridControl : BOSGridControl
    {
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            var column = gridView.Columns["FK_HRDepartmentShortID"];
            if (column != null)
            {
                column.UnboundType = DevExpress.Data.UnboundColumnType.String;
                var repLookupEdit = InitColumnLookupView(strTableName, "FK_HRDepartmentID", "Khoa (tên tắt)", "HRDepartmentAbbrev");
                if (repLookupEdit != null)
                    column.ColumnEdit = repLookupEdit;
            }
            column = new GridColumn
            {
                Caption = "Chủ thể",
                FieldName = "MEEmrRelationFromName",
                VisibleIndex = -1
            };
            var rep = InitRepositoryForConfigValues(BOSLib.ADConfigValueUtility.ConfigValues.Tables["EmrRelationFromName"]);
            column.ColumnEdit = rep;
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Mối quan hệ",
                FieldName = "MEEmrRelationToName",
                VisibleIndex = -1
            };
            rep = InitRepositoryForConfigValues(BOSLib.ADConfigValueUtility.ConfigValues.Tables["EmrRelationToName"]);
            column.ColumnEdit = rep;
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsSelection.MultiSelect = false;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsView.ShowFooter = false;
            gridView.OptionsMenu.ShowFooterItem = false;
            gridView.HorzScrollVisibility = ScrollVisibility.Never;
            gridView.BestFitColumns();

            GridColumn column = gridView.Columns["MEEmrArchiveStatus"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
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

            gridView.DoubleClick += new EventHandler(GridView_DoubleClick);
            return gridView;
        }

        protected override void GridView_Click(object sender, EventArgs e)
        {
            base.GridView_Click(sender, e);
            var grid = (GridView)sender;
            if (grid.FocusedRowHandle >= 0)
            {
                var obj = grid.GetRow(grid.FocusedRowHandle) as MEEmrsInfo;
                ((MEEmrModule)Screen.Module).EmrRelationAction(obj.MEEmrID);
            }
        }

        public override void InitEmbeddedNavigator()
        {
            UseEmbeddedNavigator = false;
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView gridView = (GridView)sender;
                if (gridView.FocusedRowHandle >= 0)
                {
                    var objSelected = (MEEmrsInfo)gridView.GetRow(gridView.FocusedRowHandle);
                    if (objSelected != null)
                    {
                        ((MEEmrModule)Screen.Module).Invalidate(objSelected);
                    }
                }
            }
            catch (Exception ex)
            {
                // co thoi gian fix sau.
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
                var row = gridView.GetRow(e.RowHandle) as MEEmrsInfo;
                if (row != null)
                    if (e.Column.FieldName == "MEEmrNo" || e.Column.FieldName == "MEEmrTypeProfile")
                    {
                        switch (row.MEEmrTypeProfile)
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
                        switch (row.MEEmrStatus)
                        {
                            case "Closed":
                                e.Appearance.ForeColor = Color.DarkGray;
                                break;
                            case "InProgress":
                                e.Appearance.ForeColor = Color.Green;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (e.Column.FieldName == "MEEmrArchiveStatus")
                    {
                        switch (row.MEEmrArchiveStatus)
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
