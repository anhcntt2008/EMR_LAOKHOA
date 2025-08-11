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
    public partial class MEEmrDocumentDataHistorysGridControl : BOSGridControl
    {
        public MEEmrDocumentDataHistorysGridControl(IContainer container)
            : base(container)
        {

        }
        public override void InitGridControlDataSource()
        {
            var entity = (MEEmrEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource();
            bds.DataSource = entity.MEEmrDocumentDataHistoriesList;
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            var column = new GridColumn();
            column.Caption = "Ngày cập nhật";
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            column.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            column.FieldName = "AAUpdatedDate";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Người cập nhật";
            column.FieldName = "AAUpdatedUser";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Người tạo";
            column.FieldName = "AACreatedUser";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Ngày tạo";
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            column.FieldName = "AACreatedDate";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Trạng thái dữ liệu";
            column.FieldName = "AAStatus";
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }
        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            return gridView;
        }
        protected override void OnDoubleClick(EventArgs ev)
        {
            base.OnDoubleClick(ev);
            GridView gridView = (GridView)this.MainView;
            var module = ((MEEmrModule)((BaseModuleERP)Screen.Module));
            if (gridView.FocusedRowHandle >= 0)
            {
                module.ViewDocumentDataTree(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrDocumentsInfo);
            }
        }
    }
}
