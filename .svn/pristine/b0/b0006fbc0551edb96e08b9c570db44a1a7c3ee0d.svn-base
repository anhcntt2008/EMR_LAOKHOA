using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using BOSERP.Modules.ME.MEPatient.Localization;
using BOSLib;
using DevExpress.XtraGrid.Columns;
using Localization;

namespace BOSERP.Modules.MEPatient
{
    public partial class MEPatientVisitsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEPatientVisitList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = PatientLocalizedResources.ARInvoiceTotalAmount;
            column.FieldName = "ARInvoiceTotalAmount";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }        
    }
}
