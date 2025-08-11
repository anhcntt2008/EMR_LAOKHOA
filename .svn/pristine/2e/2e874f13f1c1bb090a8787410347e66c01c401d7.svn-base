using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using BOSERP.Modules.ME.MEPatient.Localization;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using Localization;

namespace BOSERP.Modules.MEPatient
{
    public partial class EmployeeVisitsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.EmployeeVisitList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = PatientLocalizedResources.MEPatientName;
            column.FieldName = "MEPatientName";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = PatientLocalizedResources.METimeFrameStartTime;
            column.FieldName = "METimeFrameStartTime";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();

            GridColumn column = gridView.Columns["MEPatientVisitCheckInTime"];
            if (column != null)
            {
                column.ColumnEdit = new RepositoryItemTimeEdit();
            }
            column = gridView.Columns["METimeFrameStartTime"];
            if (column != null)
            {
                column.ColumnEdit = new RepositoryItemTimeEdit();
            }
            gridView.SortInfo.Add(new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gridView.Columns["METimeFrameStartTime"], DevExpress.Data.ColumnSortOrder.Ascending));
            return gridView;
        }
    }
}
