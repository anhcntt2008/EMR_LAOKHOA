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
    public partial class METemplatesGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            UserManagementEntities entity = (UserManagementEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource
            {
                DataSource = entity.METemplateList
            };
            DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            //gridView.OptionsBehavior.Editable = true;
            //gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            //gridView.OptionsSelection.MultiSelect = true;
            return gridView;
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            GridColumn column = new GridColumn
            {
                FieldName = "Selected",
                Caption = "Chọn"
            };
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column);
            base.AddColumnsToGridView(strTableName, gridView);
        }
    }
}
