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

namespace BOSERP.Modules.MEImageLib
{
    public partial class MEEmrPatternsGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            MEImageLibEntities entity = (MEImageLibEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrImagePatternList;
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
            GridColumn column = gridView.Columns["MEEmrImagePatternNo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEEmrImagePatternOrder"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEEmrImagePatternName"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            }
            column = gridView.Columns["MEEmrImagePatternImage"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                var edit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
                edit.CustomHeight = 50;
                edit.SizeMode = PictureSizeMode.Zoom;
                column.ColumnEdit = edit;
            }
            gridView.CalcRowHeight += gridView_CalcRowHeight;
            return gridView;
        }
       
        private void gridView_CalcRowHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {
            GridView grid = this.MainView as GridView;
            if (grid.IsFilterRow(e.RowHandle))
                e.RowHeight = 25;
        }
        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((MEImageLibModule)Screen.Module).DeleteImagePattern();
            }
        }
    }
}