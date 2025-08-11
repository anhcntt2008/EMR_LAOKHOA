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
    public partial class MEEmrImagesGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            MEImageLibEntities entity = (MEImageLibEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrImageList;
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
            GridColumn column = gridView.Columns["FK_HRDepartmentID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["FK_HREmployeeID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEEmrImageNo"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;

            }
            column = gridView.Columns["MEEmrImageOrder"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEEmrImageHeight"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEEmrImageWidth"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["MEEmrImageName"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                column.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            }
            column = gridView.Columns["MEEmrImageLarge"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
                var edit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
                edit.CustomHeight = 80;
                edit.SizeMode = PictureSizeMode.Zoom;
                column.ColumnEdit = edit;
            }
            column = gridView.Columns["MEEmrImageShared"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            column = gridView.Columns["FK_MEParamContainerID"];
            if (column != null)
            {
                column.OptionsColumn.AllowEdit = true;
            }
            gridView.CalcRowHeight += gridView_CalcRowHeight;
            return gridView;
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
            MEImageLibEntities entity = (MEImageLibEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            GridView grid = this.MainView as GridView;
            if (e.FocusedRowHandle >= 0)
            {
                var img = grid.GetFocusedRow() as MEEmrImagesInfo;
                entity.MEEmrImagePatternList.Invalidate(img.MEEmrImageID);
                entity.MEEmrImageParamsList.Invalidate(img.MEEmrImageID);
            }
            else
            {
                entity.MEEmrImagePatternList.SetDefaultListAndRefreshGridControl();
                entity.MEEmrImageParamsList.SetDefaultListAndRefreshGridControl();
            }
        }
        protected override void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            base.GridView_KeyUp(sender, e);

            if (e.KeyCode == Keys.Delete)
            {
                ((MEImageLibModule)Screen.Module).DeleteImageFromList();
            }
        }
    }
}