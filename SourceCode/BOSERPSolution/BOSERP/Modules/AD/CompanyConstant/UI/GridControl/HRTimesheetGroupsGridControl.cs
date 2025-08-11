using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using BOSLib;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;


namespace BOSERP.Modules.CompanyConstant
{
    public partial class HRTimesheetGroupsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            CompanyConstantEntities entity = (CompanyConstantEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.HRTimesheetGroupList;
            this.DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            foreach (GridColumn col in gridView.Columns)
            {
                col.OptionsColumn.AllowEdit = true;
            }
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
                    ((CompanyConstantModule)Screen.Module).RemoveSelectedTimesheetGroup();
                }
            }
        }
    }
}
