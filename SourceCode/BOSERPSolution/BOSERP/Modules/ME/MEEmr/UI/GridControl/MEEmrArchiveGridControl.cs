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

namespace BOSERP.Modules.MEEmr
{
    public partial class MEEmrArchiveGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (MEEmrEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource
            {
                DataSource = entity.MEEmrArchiveList
            };
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            var col = gridView.Columns["MEEmrArchiveSignTime"];
            if (col != null)
            {
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }
            col = gridView.Columns["MEEmrArchiveDate"];
            if (col != null)
            {
                col.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }
            return gridView;
        }
        protected override void OnDoubleClick(EventArgs ev)
        {
            base.OnDoubleClick(ev);
            GridView gridView = (GridView)this.MainView;
            if (gridView.FocusedRowHandle >= 0)
            {
                ((BOSERP.Modules.MEEmr.UI.DMMEEMR102)Screen).ViewArchivePdf(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrArchivesInfo);
            }
        }
    }
}
