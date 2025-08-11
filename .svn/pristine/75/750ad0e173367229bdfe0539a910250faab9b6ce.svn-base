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

namespace BOSERP.Modules.MEEmr
{
    public partial class METemplateChartsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            //MEEmrEntities entity = (MEEmrEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            //BindingSource bds = new BindingSource();
            //bds.DataSource = entity.METemplateChartList;
            //this.DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView.OptionsSelection.MultiSelect = false;
            return gridView;
        }
    }
}
