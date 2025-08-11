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
using DevExpress.Utils;

namespace BOSERP.Modules.EmrAbbrev
{
    public partial class MEEmrAbbrevsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            EmrAbbrevEntities entity = (EmrAbbrevEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrAbbrevList;
            DataSource = bds;
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.RowAutoHeight = true;
            GridColumn column = gridView.Columns["FK_HREmployeeID"];
            if (column != null)
                column.OptionsColumn.AllowEdit = false;
            column = gridView.Columns["MEEmrAbbrevNo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;

            }
            column = gridView.Columns["MEEmrAbbrevShared"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEEmrAbbrevRichText"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }

            column = gridView.Columns["MEEmrAbbrevContent"];
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
            gridView.CustomRowCellEditForEditing += gridView1_CustomRowCellEditForEditing;
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
        void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                e.RepositoryItem = new RepositoryItemTextEdit();
            }
            else if (e.Column.FieldName == "MEEmrAbbrevContent")
            {
                e.RepositoryItem = (this.Screen as UI.DMEAB100).riPopup;
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
        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((EmrAbbrevModule)Screen.Module).DeleteAbbrevFromList();
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