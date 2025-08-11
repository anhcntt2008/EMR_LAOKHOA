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

namespace BOSERP.Modules.MEEmrStore
{
    public partial class MEEmrArchivesSelectionGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (MEEmrStoreEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource
            {
                DataSource = entity.MEEmrArchiveList
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
            return gridView;
        }
        protected override void GridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            var gridView = (GridView)sender;
            if (!gridView.IsValidRowHandle(e.RowHandle)) return;
            if (e.RowHandle >= 0)
            {
                var row = gridView.GetRow(e.RowHandle) as MEEmrArchivesInfo;
                if (row != null)
                {
                    if (e.Column.FieldName == "MEEmrArchiveBackupStatus")
                    {
                        switch (row.MEEmrArchiveBackupStatus)
                        {
                            case "Failed":
                                e.Appearance.ForeColor = Color.DarkRed;
                                break;
                            case "Uploaded":
                                e.Appearance.ForeColor = Color.DarkBlue;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
