using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using BOSComponent;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using Localization;
using BOSCommon;
using System.Drawing;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Data;
using System.Reflection;

namespace BOSERP.Modules.EmrShared
{
    public partial class MEEmrsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            EmrSharedEntities entity = (EmrSharedEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrSharedList;
            DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView.OptionsSelection.MultiSelect = true;
            return gridView;
        }
        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            base.GridView_FocusedRowChanged(sender, e);
            var grid = (GridView)sender;
            if (grid.FocusedRowHandle >= 0)
            {
                ((EmrSharedModule)Screen.Module).InvalidateSharedHistory(grid.GetRow(grid.FocusedRowHandle) as MEEmrsInfo);
            }
        }
        protected override void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            base.GridView_InitNewRow(sender, e);
        }
        protected override void GridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.GridView_CellValueChanged(sender, e);
        }
    }
}