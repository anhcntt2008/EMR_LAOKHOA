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
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using Clas.Model.Middle;

namespace BOSERP.Modules.MEEmr
{
    public partial class MdAutoGenDocumentDtoGridControl : BOSGridControl
    {
        public void LoadDataToGridMdAutoGenDocumentDto(List<MdAutoGenDocumentDto> data)
        {
            var grid = (this.MainView as GridView);
            MdAutoGenDocumentsInitGridColumns(grid);
            DataSource = data;
            RefreshDataSource();
            Refresh();
        }

        private void MdAutoGenDocumentsInitGridColumns(GridView grid)
        {
            grid.OptionsSelection.EnableAppearanceFocusedCell = false;
            grid.OptionsSelection.EnableAppearanceFocusedRow = true;
            grid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            grid.OptionsSelection.MultiSelect = true;
            grid.OptionsCustomization.AllowFilter = true;
            grid.OptionsView.ShowAutoFilterRow = true;
            grid.OptionsBehavior.AutoExpandAllGroups = true;
            grid.BestFitColumns();

            var column = grid.Columns["EMR_NO"];
            if (column != null)
            {
                column.Group();
            }
            column = grid.Columns["VENDOR_DOC_NO"];
            if (column != null)
            {
                column.Group();
            }
            column = grid.Columns["ID"];
            if (column != null)
            {
                column.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            }
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.DoubleClick += new EventHandler(fld_dgvMdAutoGenDocumentDto_DoubleClick);


            return gridView;
        }

        private void fld_dgvMdAutoGenDocumentDto_DoubleClick(object sender, EventArgs e)
        {
            var grid = (this.MainView as GridView);
            if (grid.FocusedRowHandle >= 0)
            {
                var selectedE = (MdAutoGenDocumentDto)grid.GetRow(grid.FocusedRowHandle);
                if (!string.IsNullOrEmpty(selectedE.CREATED_LOG))
                {
                    MessageBox.Show(selectedE.CREATED_LOG, "Nội dung", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
