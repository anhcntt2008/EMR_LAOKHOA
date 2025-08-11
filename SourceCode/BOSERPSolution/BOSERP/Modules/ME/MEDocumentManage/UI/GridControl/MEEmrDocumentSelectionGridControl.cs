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
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BOSERP.Modules.MEEmr;

namespace BOSERP.Modules.MEDocumentManage
{
    public partial class MEEmrDocumentSelectionGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (MEDocumentManageEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource
            {
                DataSource = entity.MEEmrDocumentList
            };
            DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;

            GridColumn column = gridView.Columns["MEEmrDocumentCreatedDate"];
            if (column != null)
            {
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }
            return gridView;
        }
    }
}
