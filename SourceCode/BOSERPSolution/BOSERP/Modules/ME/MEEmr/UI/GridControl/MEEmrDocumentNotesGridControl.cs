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
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using System.Data;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;

namespace BOSERP.Modules.MEEmr
{
    public partial class MEEmrDocumentNotesGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsView.RowAutoHeight = true;
            gridView.DoubleClick += new EventHandler(gridView_DoubleClick);
            GridColumn column = gridView.Columns["MEEmrDocumentNoteTime"];
            if (column != null)
            {
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }
            column = gridView.Columns["MEEmrDocumentNoteText"];
            if (column != null)
            {
                var edit = new RepositoryItemMemoEdit();
                column.ColumnEdit = edit;
            }
            return gridView;
        }
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);
            var column = new GridColumn
            {
                Caption = "Đánh dấu",
                FieldName = "MEEmrDocumentNoteHasBookmark",
                VisibleIndex = -1
            };
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);
        }
        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                var row = view.GetRow(info.RowHandle) as MEEmrDocumentNotesInfo;
                ((UI.guiDocumentNoteList)Screen).GotoBookmark(row.MEEmrDocumentNoteBookmark, row.FK_MEEmrDocumentID);
            }
        }
    }
}
