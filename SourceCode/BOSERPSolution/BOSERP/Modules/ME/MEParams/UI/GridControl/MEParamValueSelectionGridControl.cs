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

namespace BOSERP.Modules.MEParams
{
    public partial class MEParamValueSelectionGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (MEParamsEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEParamValuesList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            //GridColumn column = new GridColumn();
            //column.Caption = "Dữ liệu";
            //column.FieldName = "MEParamName";
            //column.OptionsColumn.AllowEdit = false;
            //gridView.Columns.Add(column);

            //column = new GridColumn();
            //column.Caption = "Loại biểu đồ";
            //column.FieldName = "MEParamFormatType";
            //column.OptionsColumn.AllowEdit = false;
            //gridView.Columns.Add(column);
            //GridColumn column = new GridColumn();
            //column.Caption = "Giá trị";
            //column.FieldName = "MEParamValue";
            //column.OptionsColumn.AllowEdit = true;
            //gridView.Columns.Add(column);

        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView.OptionsSelection.MultiSelect = true;

            //gridView.Columns["ME Param Value ID"].Visible = false;

            return gridView;
        }
        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
        }
    }
}
