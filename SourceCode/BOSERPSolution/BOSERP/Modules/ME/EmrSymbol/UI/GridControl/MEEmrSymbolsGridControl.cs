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
using DevExpress.XtraRichEdit;

namespace BOSERP.Modules.EmrSymbol
{
    public partial class MEEmrSymbolsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            EmrSymbolEntities entity = (EmrSymbolEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrSymbolList;
            DataSource = bds;
        }
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            var column = new GridColumn
            {
                Caption = "Xem",
                FieldName = "RtfText",
                VisibleIndex = 0,
                Width = 50
            };
            var edit = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            edit.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
            edit.Name = "repositoryItemRichTextEdit1";
            edit.ShowCaretInReadOnly = false;
            column.ColumnEdit = edit;
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.ReadOnly = true;
            gridView.Columns.Add(column);

        }
        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.OptionsView.RowAutoHeight = true;
            GridColumn column = gridView.Columns["MEEmrSymbolNo"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["MEEmrSymbolName"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["MEEmrSymbolOrder"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["MEEmrSymbolFont"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["MEEmrSymbolChar"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["MEEmrSymbolStr"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["MEEmrSymbolMenu"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["MEEmrSymbolGroup"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;
            column = gridView.Columns["MEEmrSymbolIcon"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                var edit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
                edit.CustomHeight = 20;
                edit.SizeMode = PictureSizeMode.Zoom;
                column.ColumnEdit = edit;
            }
            column = gridView.Columns["MEEmrSymbolRemark"];
            if (column != null)
                column.OptionsColumn.AllowEdit = true;


            gridView.CalcRowHeight += gridView_CalcRowHeight;
            gridView.CustomDrawCell += Grid_CustomDrawCell;
            return gridView;
        }

        private void Grid_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName != "RtfContent") return;
            if (e.RowHandle >= 0)
            {
                
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
                ((EmrSymbolModule)Screen.Module).DeleteSymbolFromList();
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