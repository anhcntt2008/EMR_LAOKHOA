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
using BOSCommon;

namespace BOSERP.Modules.MEParamReports
{
    public partial class MEParamReportRelationsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (MEParamReportsEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEParamReportRelationsList;
            DataSource = bds;
        }
        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((MEParamReportsModule)Screen.Module).DeleteItemFromRelationList();
            }
        }

        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView gridView = (GridView)this.MainView;
            base.GridView_FocusedRowChanged(sender, e);
        }
    }
}
