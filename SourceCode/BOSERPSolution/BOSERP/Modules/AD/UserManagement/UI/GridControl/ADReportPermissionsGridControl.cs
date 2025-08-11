using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Windows.Forms;
using BOSComponent;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;

namespace BOSERP.Modules.UserManagement
{
    public partial class ADReportPermissionsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ReportPermissionsList;
            DataSource = bds;
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();
            gridView.OptionsBehavior.Editable = true;

            gridView.GroupFormat = "[#image]{1} {2}";
            GridColumn column = gridView.Columns["ADReportSection"];
            if (column != null)
                column.Group();
            return gridView;
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            GridColumn column = new GridColumn();
            column.FieldName = "ADReportName";
            column.Caption = UserManagementLocalizedResources.ADReportName;
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = "Selected";
            column.Caption = "Được xem";
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = "ADReportSection";
            column.Caption = "Mục báo cáo";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }
    }
}
