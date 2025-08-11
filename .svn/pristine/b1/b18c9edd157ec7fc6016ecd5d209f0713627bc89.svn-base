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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using System.Data;
using System.Linq;

namespace BOSERP.Modules.MEEmr
{
    public partial class MEEmrShareGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (MEEmrEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrShareList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            //gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            var col = gridView.Columns["MEEmrShareHistoryDate"];
            if (col != null)
            {
                col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                var edit = col.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemDateEdit;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                edit.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
                edit.EditMask = "dd/MM/yyyy HH:mm";
                edit.Mask.UseMaskAsDisplayFormat = true;
            }
            col = gridView.Columns["FK_HRDepartmentID"];
            if (col != null)
            {
                col.OptionsColumn.AllowEdit = true;
            }
            col = gridView.Columns["FK_HREmployeeID"];
            if (col != null)
            {
                col.OptionsColumn.AllowEdit = true;
            }
            col = gridView.Columns["MEEmrShareHistoryFromDate"];
            if (col != null)
            {
                col.OptionsColumn.AllowEdit = true;
                col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                var edit = col.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemDateEdit;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                edit.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
                edit.EditMask = "dd/MM/yyyy HH:mm";
                edit.Mask.UseMaskAsDisplayFormat = true;
            }

            col = gridView.Columns["MEEmrShareHistoryToDate"];
            if (col != null)
            {
                col.OptionsColumn.AllowEdit = true;
                col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                var edit = col.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemDateEdit;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                edit.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
                edit.EditMask = "dd/MM/yyyy HH:mm";
                edit.Mask.UseMaskAsDisplayFormat = true;
            }

            col = gridView.Columns["MEEmrShareHistoryActive"];
            if (col != null)
            {
                col.OptionsColumn.AllowEdit = true;
            }
            col = gridView.Columns["MEEmrShareHistoryRemark"];
            if (col != null)
            {
                col.OptionsColumn.AllowEdit = true;
            }
            gridView.CustomColumnDisplayText += new CustomColumnDisplayTextEventHandler(Grid_CustomCellDisplayText);

            gridView.ShowingEditor += GridView_ShowingEditor;

            return gridView;
        }

        private void GridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            var grid = (GridView)sender;
            MEEmrShareHistoriesInfo obj = (MEEmrShareHistoriesInfo)grid.GetFocusedRow();
            if (obj != null)
                if (BOSApp.CurrentUserGroupInfo.ADUserGroupRole != BOSCommon.UserGroupRole.admin.ToString())
                {
                    if (obj.FK_HREmployeeShareByID != BOSApp.CurrentEmployeesInfo.HREmployeeID)
                    {
                        MessageBox.Show("Chỉ người thực hiện chia sẻ hay Admin mới thay đổi được dòng này.", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        e.Cancel = true;
                    }
                }
        }

        private void Grid_CustomCellDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "FK_HREmployeeID" || e.Column.FieldName == "FK_HRDepartmentID")
            {
                if (e.Value != null && e.Value.ToString() == "0")
                {
                    e.DisplayText = "Tất cả";
                }
            }
        }

        protected override void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var module = ((MEEmrModule)Screen.Module);
            if (!module.CanShareEmr()) return;

            //TODO không ổn định
            module.SwitchToEditMode(module.CurrentModuleEntity.ModuleObjects["MEEmrShareHistories"], String.Empty);

            base.GridView_InitNewRow(sender, e);
            var grid = (GridView)sender;
            MEEmrShareHistoriesInfo obj = (MEEmrShareHistoriesInfo)grid.GetFocusedRow();
            if (obj != null)
            {
                obj.MEEmrShareHistoryDate = DateTime.Now;
                obj.MEEmrShareHistoryFromDate = DateTime.Now.AddMinutes(-1);
                obj.MEEmrShareHistoryToDate = obj.MEEmrShareHistoryFromDate.AddHours(BOSApp.CurrentCompanyInfo.CSCompanyEmrShareHours);
                obj.MEEmrShareHistoryActive = true;
                obj.FK_HREmployeeShareByID = BOSApp.CurrentEmployeesInfo.HREmployeeID;
                this.RefreshDataSource();
                this.Refresh();
            }
        }
        protected override void GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            var grid = (GridView)sender;
            //MEEmrShareHistoriesInfo obj = (MEEmrShareHistoriesInfo)grid.GetFocusedRow();
        }
        protected override void GridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);
            var grid = (GridView)sender;
            var row = (MEEmrShareHistoriesInfo)grid.GetFocusedRow();
            if (row != null)
            {
                if (e.Column.FieldName == "FK_HREmployeeID")
                {
                    ((MEEmrModule)Screen.Module).ChangeShareEmployeeOrDepartment(row);
                }
            }
        }

        protected override RepositoryItemLookUpEdit InitColumnLookupEdit(string strTableName, string strColumnName, string columnCaption)
        {
            var lke = base.InitColumnLookupEdit(strTableName, strColumnName, columnCaption);
            if (strColumnName == "FK_HREmployeeID" || strColumnName == "FK_HRDepartmentID")
            {
                var data = (lke.DataSource as DataTable).Copy();
                if (data.Rows.Count > 0)
                {
                    data.Rows.RemoveAt(0);
                    var row = data.NewRow();
                    row[lke.ValueMember] = 0;
                    row[lke.DisplayMember] = "Tất cả";
                    data.Rows.InsertAt(row, 0);

                    lke.DataSource = data;
                }
            }
            return lke;
        }
        protected override void RepositoryItemLookupEdit_QueryPopup(object sender, CancelEventArgs e)
        {
            base.RepositoryItemLookupEdit_QueryPopup(sender, e);
            var lke = (LookUpEdit)sender;
            if (lke.Properties.ValueMember == "HREmployeeID" || lke.Properties.ValueMember == "HRDepartmentID")
            {
                var data = (lke.Properties.DataSource as DataTable).Copy();
                if (data.Rows.Count > 0)
                {
                    data.Rows.RemoveAt(0);
                    var row = data.NewRow();
                    row[lke.Properties.ValueMember] = 0;
                    row[lke.Properties.DisplayMember] = "Tất cả";
                    data.Rows.InsertAt(row, 0);
                    lke.Properties.DataSource = data;
                }
            }
        }
        protected override void RepositoryItemLookupEdit_QueryCloseUp(object sender, CancelEventArgs e)
        {
            ////base.RepositoryItemLookupEdit_QueryCloseUp(sender, e);

        }
        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                var grid = (GridView)sender;
                DeleteRow(grid);
            }
        }
        private void DeleteRow(GridView grid)
        {
            MEEmrShareHistoriesInfo obj = (MEEmrShareHistoriesInfo)grid.GetFocusedRow();
            if (obj != null)
            {
                if (BOSApp.CurrentUserGroupInfo.ADUserGroupRole == BOSCommon.UserGroupRole.admin.ToString())
                {
                    ((MEEmrModule)Screen.Module).DeleteShareHistoryList();
                    return;
                }
                else if (obj.FK_HREmployeeShareByID == BOSApp.CurrentEmployeesInfo.HREmployeeID)
                {
                    ((MEEmrModule)Screen.Module).DeleteShareHistoryList();
                    return;
                }
                MessageBox.Show("Chỉ người thực hiện chia sẻ hay Admin mới thay đổi được dòng này.", "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
