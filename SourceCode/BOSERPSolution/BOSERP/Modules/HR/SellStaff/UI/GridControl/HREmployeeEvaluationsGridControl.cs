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
namespace BOSERP.Modules.SellStaff
{
    public partial class HREmployeeEvaluationsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            SellStaffEntities entity = (SellStaffEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.EmployeeEvaluationList;
            DataSource = bds;
        }
        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            GridColumn column;
            column = new GridColumn();
            column.Caption = SellStaffLocalizedResource.HREvaluationFromDate;
            column.FieldName = "HREvaluationFromDate";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = SellStaffLocalizedResource.HREvaluationToDate;
            column.FieldName = "HREvaluationToDate";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }
    }
}
