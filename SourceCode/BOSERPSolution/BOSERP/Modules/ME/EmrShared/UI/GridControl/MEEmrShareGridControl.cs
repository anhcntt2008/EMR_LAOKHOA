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
using DevExpress.XtraEditors;
using System.Data;
using System.Linq;

namespace BOSERP.Modules.EmrShared
{
    public partial class MEEmrShareGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (EmrSharedEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrShareHistoryList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            //var col = gridView.Columns["MEEmrShareHistoryActive"];
            //if (col != null)
            //{
            //    col.OptionsColumn.AllowEdit = true;
            //}
            //col = gridView.Columns["MEEmrShareHistoryRemark"];
            //if (col != null)
            //{
            //    col.OptionsColumn.AllowEdit = true;
            //}
            return gridView;
        }

        protected override void GridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            var grid = (GridView)sender;
            MEEmrShareHistoriesInfo obj = (MEEmrShareHistoriesInfo)grid.GetFocusedRow();
        }

    }
}
