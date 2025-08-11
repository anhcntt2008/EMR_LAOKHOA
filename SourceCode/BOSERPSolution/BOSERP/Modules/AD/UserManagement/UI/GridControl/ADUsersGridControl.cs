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
using BOSCommon;

namespace BOSERP.Modules.UserManagement
{
    public partial class ADUsersGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource
            {
                DataSource = entity.ADUserList
            };
            DataSource = bds;
        }
        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;

            var column = gridView.Columns["ADUserGroupID"];
            if (column != null)
            {
                column.GroupIndex = 0;
                column.Group();
            }

            gridView.DoubleClick += new EventHandler(gridView_DoubleClick);
            return gridView;
        }

        void gridView_DoubleClick(object sender, EventArgs e)
        {
            UserManagementModule module = (UserManagementModule)Screen.Module;
            module.InitProductLocationBranchPricesDataSource();
        }
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = UserManagementLocalizedResources.EndTimeDefaultMessage;
            column.FieldName = "MEEndTimeFrameValue";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }
    }
}
