using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Localization;
using DevExpress.XtraGrid.Columns;

namespace BOSERP.Modules.SellStaff
{
    public partial class HREmployeeTemplatesGridControl : BOSComponent.BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            SellStaffEntities entity = (SellStaffEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.HREmployeeTemplatesList;
            this.DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();
            column = new DevExpress.XtraGrid.Columns.GridColumn();
            column.Caption = SellStaffLocalizedResource.UserCreatedName;
            column.FieldName = "UserCreatedFullname";
            gridView.Columns.Add(column);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = base.InitializeGridView();

            GridColumn column = gridView.Columns["UserCreatedFullname"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = false;
            }
            return gridView;
        }
    }
}
