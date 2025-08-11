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

namespace BOSERP.Modules.MEEmrManage
{
    public partial class MEEmrSelectionGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (MEEmrManageEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource
            {
                DataSource = entity.MEEmrList
            };
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
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
        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
        }
        protected override void GridView_Click(object sender, EventArgs e)
        {
            base.GridView_Click(sender, e);
        }
        protected override void GridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView gridView = (GridView)sender;
                var row = gridView.GetRow(e.RowHandle) as MEEmrsInfo;
                if (e.Column.FieldName == "MEEmrNo"
                   || e.Column.FieldName == "MEEmrTypeProfile"
                   || e.Column.FieldName == "FK_MEEmrTypeID"
                   || e.Column.FieldName == "MEPatientName"
                   || e.Column.FieldName == "MEPatientNo"
                   || e.Column.FieldName == "FK_HRDepartmentID")
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
                            e.Appearance.BackColor = Color.LightGray;
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
