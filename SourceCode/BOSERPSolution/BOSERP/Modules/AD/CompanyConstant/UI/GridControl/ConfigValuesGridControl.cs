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
    public partial class ConfigValuesGridControl : BOSComponent.BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ConfigValuesList;
            this.DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }

        protected override GridView InitializeGridView()
        {
            GridView gridview = base.InitializeGridView();
            GridColumn column = gridview.Columns["ADConfigText"];
            if (column != null)
            {
                column.Caption = "Tên";
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridview.Columns["ADConfigKeyDesc"];
            if (column != null)
            {
                column.Caption = "Mô tả";
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridview.Columns["ADConfigKeyValue"];
            if (column != null)
            {
                column.Caption = "Giá trị";
                column.OptionsColumn.AllowEdit = true;
            }
            return gridview;
        }
    }
}
