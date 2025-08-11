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
    public partial class ICInventoryPermissionsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.InventoryPermissionsList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            GridColumn column = new GridColumn();
            column.FieldName = "ICStockNo";
            column.Caption = UserManagementLocalizedResources.ICStockNo;
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = "ICStockName";
            column.Caption = UserManagementLocalizedResources.ICStockName;
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = "Selected";
            column.Caption = UserManagementLocalizedResources.CommandPermissionTypeNone;
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column);

           
        }
    }
}
