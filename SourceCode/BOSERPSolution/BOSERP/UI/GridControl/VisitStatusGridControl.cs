using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BOSCommon;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using Localization;

namespace BOSERP
{    
    public partial class VisitStatusGridControl : BOSGridControl
    {
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.FieldName = "ServiceName";
            column.Caption = CommonLocalizedResources.ServiceName;
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);            

            column = new GridColumn();
            column.FieldName = "ServiceDesc";
            column.Caption = CommonLocalizedResources.ServiceDesc;
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);            

            column = new GridColumn();
            column.FieldName = "ServiceStatus";
            column.Caption = CommonLocalizedResources.ServiceStatus;
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = "ServiceDate";
            column.Caption = CommonLocalizedResources.ServiceDate;
            column.OptionsColumn.AllowEdit = false;
            column.ColumnEdit = new RepositoryItemDateEdit();
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = "ServiceOrderBy";
            column.Caption = CommonLocalizedResources.ServiceOrderBy;
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = "ServiceReturnTo";
            column.Caption = CommonLocalizedResources.ServiceReturnTo;
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = "ServiceUrgency";
            column.Caption = CommonLocalizedResources.ServiceUrgency;
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = "ServiceResult";
            column.Caption = CommonLocalizedResources.ServiceResult;
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = "ServicePathological";
            column.Caption = CommonLocalizedResources.ServicePathological;
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column); 
        }

        /// <summary>
        /// Invalidate the grid's data source to reflect new changes of the current visit
        /// </summary>
        /// <param name="patientVisitID">Current visit id</param>
        public void InvalidateDataSource(int patientVisitID)
        {
            MEPatientVisitsController objPatientVisitsController = new MEPatientVisitsController();
            //KhangCV [EDIT] [15/02/2017] [], START
            List<ServiceStatusInfo> serviceStatusList = objPatientVisitsController.GetVisitStatusByBranch(patientVisitID, BOSApp.CurrentBranchInfo.BRBranchID);
            //KhangCV [EDIT] [15/02/2017] [], END
            DataSource = serviceStatusList;
        }
    }
}
