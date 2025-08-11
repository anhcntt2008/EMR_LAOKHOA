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
    public partial class METemplateParamRelationGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (MEParamsEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.METemplateParamList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            GridColumn column = gridView.Columns["FK_MEParamID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = false;
            }
            /*column = gridView.Columns["MEParamValueContent"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }*/
            return gridView;
        }
        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);
            if (e.KeyCode == Keys.Delete)
            {
                ((MEParamsModule)Screen.Module).DeleteParamFromTemplateParamRelationList();
            }
        }
        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView gridView = (GridView)this.MainView;
            base.GridView_FocusedRowChanged(sender, e);
        }
    }
}
