using BOSComponent;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;


namespace BOSERP
{
    public partial class WorkflowInputParamGridControl : BOSGridControl
    {
        protected override void AddColumnsToGridView(string strTableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            base.AddColumnsToGridView(strTableName, gridView);

            GridColumn column = new GridColumn
            {
                FieldName = "MEParamNo",
                Caption = "Mã tham số",
                Visible = true,
                VisibleIndex = 1
            };
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            column = new GridColumn
            {
                FieldName = "MEParamCaption",
                Caption = "Diễn giải",
                Visible = true,
                VisibleIndex = 2
            };
            column.OptionsColumn.AllowEdit = false;
            gridView.Columns.Add(column);

            var memoEdit = new RepositoryItemMemoEdit
            {
                AutoHeight = true,
                WordWrap = true
            };
            column = new GridColumn
            {
                FieldName = "MEParamValue",
                Caption = "Giá trị tham số",
                Visible = true,
                VisibleIndex = 3,
                MinWidth = 500,
                ColumnEdit = memoEdit
            };
            column.OptionsColumn.AllowEdit = true;
            gridView.Columns.Add(column);
        }

        protected override GridView InitializeGridView()
        {
            var gridView = base.InitializeGridView();
            gridView.OptionsView.RowAutoHeight = true;
            gridView.RowHeight = 60;
            return gridView;
        }
    }
}
