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

namespace BOSERP.Modules.EmrAbbrev
{
    public partial class MEEmrAbbrevSharedsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            EmrAbbrevEntities entity = (EmrAbbrevEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrAbbrevSharedList;
            DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.RowAutoHeight = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView.OptionsSelection.MultiSelect = true;
            GridColumn column = gridView.Columns["MEEmrAbbrevContent"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;

                //var edit = new RepositoryItemRichTextEdit
                //{
                //    DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf
                //};
                //edit.Appearance.Font = new Font("Times New Roman", 13);
                //edit.Name = "repositoryItemRichTextEdit1";
                //edit.ShowCaretInReadOnly = false;

                var edit = new RepositoryItemTextEdit();
                edit.CustomDisplayText += repositoryItemRichTextEdit1_CustomDisplayText;
                column.ColumnEdit = edit;
                column.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
                column.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            }
            gridView.CalcRowHeight += gridView_CalcRowHeight;
            return gridView;
        }
        private void repositoryItemRichTextEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null)
            {
                try
                {
                    e.DisplayText = ((EmrAbbrevModule)Screen.Module).FormatRichEditDisplayText(e.Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Lỗi định dạng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void gridView_CalcRowHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {
            GridView grid = this.MainView as GridView;
            if (grid.IsFilterRow(e.RowHandle))
                e.RowHeight = 20;
        }
        protected override void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            base.GridView_FocusedRowChanged(sender, e);
        }
    }
}