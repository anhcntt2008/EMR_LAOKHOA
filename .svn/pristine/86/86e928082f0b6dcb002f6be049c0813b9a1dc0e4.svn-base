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
    public partial class MEPatientsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEPatientList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = PatientLocalizedResources.GELocationName;
            column.FieldName = "GELocationName";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
            GridColumn column2 = new GridColumn();
            column2.Caption = "Mã Bacsi24x7";
            column2.FieldName = "MEPatientBs24x7ID";
            column2.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column2);
        }        
    }
}
