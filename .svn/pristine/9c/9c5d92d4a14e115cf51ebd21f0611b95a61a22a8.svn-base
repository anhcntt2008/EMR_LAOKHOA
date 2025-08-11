using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using BOSLib;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;

namespace BOSERP.Modules.MEService
{
    public partial class CommissionGridControl : BOSGridControl
    {
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            //GridColumn column = gridView.Columns["ICProductEmployeeCommissionPercent"];
            //if (column != null)
            //{
            //    column.OptionsColumn.AllowEdit = true;
            //}
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            foreach (GridColumn column in gridView.Columns)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            return gridView;
        }

        public override void InitGridControlDataSource()
        {
            MEServiceEntities entity = (MEServiceEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.ICProductEmployeeList;
            DataSource = bds;
        }
    }
}
