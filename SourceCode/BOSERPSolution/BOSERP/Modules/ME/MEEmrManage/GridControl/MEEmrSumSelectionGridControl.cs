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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BOSERP.Modules.MEEmr;

namespace BOSERP.Modules.MEEmrManage
{
    public partial class MEEmrSumSelectionGridControl : BOSGridControl
    {
        public override void InitGridControlDataSource()
        {
            var entity = (MEEmrManageEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
            BindingSource bds = new BindingSource
            {
                DataSource = entity.MEEmrSumList
            };
            DataSource = bds;
        }

        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            var column = new GridColumn
            {
                Caption = "In",
                FieldName = "Print",
                VisibleIndex = -1,
                Width = 25,
                UnboundType = DevExpress.Data.UnboundColumnType.Object
            };
            var btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btn.Buttons[0].Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/print/print_16x16.png");
            btn.AutoHeight = false;
            //btn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {new DevExpress.XtraEditors.Controls.EditorButton()});
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            column.ColumnEdit = btn;
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.ReadOnly = true;
            gridView.Columns.Add(column);
        }

        protected override GridView InitializeGridView()
        {
            GridView gridView = base.InitializeGridView();
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsCustomization.AllowFilter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseDown);
            //gridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseUp);
            return gridView;
        }

        private void gridView_MouseDown(object sender, MouseEventArgs e)
        {
            var gridView = (GridView)sender;
            GridHitInfo hi = gridView.CalcHitInfo(this.PointToClient(MousePosition));
            if (hi.InRowCell && hi.Column.FieldName == "Print")
            {
                ((MEEmrManageModule)Screen.Module).PrintDocument(gridView.GetRow(hi.RowHandle) as MEEmrSumsInfo);
                (e as DevExpress.Utils.DXMouseEventArgs).Handled = true;
            }
            Console.WriteLine("gridView_MouseDown(object sender, MouseEventArgs e): " + hi.HitTest + "/" + hi.InRowCell);
        }

        //private void gridView_MouseUp(object sender, MouseEventArgs e)
        //{
        //    var gridView = (GridView)sender;
        //    GridHitInfo hi = gridView.CalcHitInfo(this.PointToClient(MousePosition));
        //    if (hi.RowHandle != gridView.FocusedRowHandle)
        //    {
        //        var topIdx = gridView.TopRowIndex;
        //        gridView.FocusedRowHandle = GetFocusedRowHandleByCurrentDocument();
        //        gridView.TopRowIndex = topIdx;
        //    }
        //    /*if (gridView.IsGroupRow(hi.RowHandle))
        //    {
        //        gridView.TopRowIndex = (hi.RowHandle);
        //        Console.WriteLine("TopRowIndex(object sender, MouseEventArgs e): " + hi.RowHandle);
        //    }*/
        //}
        //private int GetFocusedRowHandleByCurrentDocument()
        //{
        //    var entity = (MEEmrEntities)((BaseModuleERP)Screen.Module).CurrentModuleEntity;
        //    var document = entity.ModuleObjects[TableName.MEEmrDocumentsTableName] as MEEmrDocumentsInfo;
        //    GridView gridView = (GridView)this.MainView;
        //    return gridView.LocateByValue("MEEmrDocumentID", document.MEEmrDocumentID);
        //}
    }
}
