using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using BOSLib;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;


namespace BOSERP.Modules.CompanyConstant
{
    public partial class HRTimesheetEmployeeLatesGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.HRTimesheetEmployeeLateList;
            this.DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            foreach (GridColumn col in gridView.Columns)
            {
                col.OptionsColumn.AllowEdit = true;
            }
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            return gridView;
        }


        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            GridView gridView = (GridView)sender;
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView.FocusedRowHandle >= 0)
                {
                    ((CompanyConstantModule)Screen.Module).RemoveSelectedTimesheetEmployeeLate();
                }
            }
        }
    }
}
