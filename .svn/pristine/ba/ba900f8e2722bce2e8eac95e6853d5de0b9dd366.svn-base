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

namespace BOSERP.Modules.METemplate
{
    public partial class MEEmrTemplateActionsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            METemplateEntities entity = (METemplateEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrTemplateActionList;
            this.DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            GridColumn column = gridView.Columns["MEEmrTemplateActionOrder"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEEmrTemplateActionWhen"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEEmrTemplateActionDo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEEmrTemplateActionCacheExpire"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            return gridView;
        }
        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
        }
    }
}
