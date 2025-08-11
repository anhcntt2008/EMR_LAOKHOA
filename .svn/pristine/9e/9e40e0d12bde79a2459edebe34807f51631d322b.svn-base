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

namespace BOSERP.Modules.MEEmr
{
    public partial class MEEmrDocumentSignsGridControl : BOSGridControl
    {
        public MEEmrDocumentSignsGridControl(IContainer container)
            : base(container)
        {

        }
        public override void InitGridControlDataSource()
        {
            var entity = (MEEmrEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrDocumentSignsList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
           
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            var col = gridView.Columns["MEEmrDocumentSignTime"];
            if (col != null)
            {
                col.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }
            return gridView;
        }
        protected override void OnDoubleClick(EventArgs ev)
        {
            base.OnDoubleClick(ev);
            GridView gridView = (GridView)this.MainView;
            var module = ((MEEmrModule)((BaseModuleERP)Screen.Module));
            if (gridView.FocusedRowHandle >= 0)
            {
                module.ViewSignedDocument(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrDocumentSignsInfo);
            }
        }
    }
}
