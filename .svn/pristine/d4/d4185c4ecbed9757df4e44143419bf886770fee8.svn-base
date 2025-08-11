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
    public partial class MEEmrsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (MEEmrEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrsList;
            DataSource = bds;
        }
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
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsView.ShowFooter = false;
            gridView.OptionsMenu.ShowFooterItem = false;
            gridView.HorzScrollVisibility = ScrollVisibility.Never;


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

            return gridView;
        }
        public override void InitEmbeddedNavigator()
        {
            UseEmbeddedNavigator = false;
        }
        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
        }
        protected override void GridView_Click(object sender, EventArgs e)
        {
            base.GridView_Click(sender, e);
            var grid = this.MainView as GridView;
            if (grid.FocusedRowHandle >= 0)
            {
                var obj = grid.GetRow(grid.FocusedRowHandle) as MEEmrsInfo;
                ((MEEmrModule)Screen.Module).Invalidate(obj);
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
