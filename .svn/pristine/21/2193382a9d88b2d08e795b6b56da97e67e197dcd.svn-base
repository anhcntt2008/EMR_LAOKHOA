using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
namespace BOSERP.Modules.MEPatient
{
    class MEPatientInssGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEPatientInssList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn();
            column.Caption = "Trạng thái thẻ";
            column.FieldName = "MEPatientInssStatus";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
            
        }

        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((MEPatientModule)Screen.Module).DeleteItemFromPatientInssList();        
            }
        }
    }
}
