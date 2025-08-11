using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using Localization;
using DevExpress.XtraGrid.Views.Base;

namespace BOSERP.Modules.CompanyConstant
{
    public partial class SystemConfigsGridControl : BOSComponent.BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.SystemConfigsList;
            this.DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);
        }
        protected override GridView InitializeGridView()
        {
            GridView gridview = base.InitializeGridView();
            gridview.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridview.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            GridColumn column = gridview.Columns["ADSystemConfigKey"];
            if (column != null)
            {
                column.Caption = "Mã tham số";
            }
            column = gridview.Columns["ADSystemConfigValue"];
            if (column != null)
            {
                column.Caption = "Giá trị tham số";
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            }
            column = gridview.Columns["ADSystemConfigText"];
            if (column != null)
            {
                column.Caption = "Tên tham số";
            }
            column = gridview.Columns["ADSystemConfigDesc"];
            if (column != null)
            {
                column.Caption = "Mô tả";
                column.OptionsColumn.AllowEdit = true;
            }
            return gridview;
        }
    }
}
