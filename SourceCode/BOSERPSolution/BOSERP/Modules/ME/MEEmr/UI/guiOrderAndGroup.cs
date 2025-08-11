using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils.DragDrop;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Dynamic;
using BOSCommon;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiOrderAndGroup : BOSERPScreen
    {
        private JArray data;
        private List<MEParamRelationsInfo> Columns;
        private int _group = 1;

        public int FormatType { get; private set; }
        public JArray FormatedData { get; private set; }

        public guiOrderAndGroup(JArray data, List<MEParamRelationsInfo> child)
        {
            InitializeComponent();
            this.behaviorManager1.SetBehaviors(this.gridView1, new DevExpress.Utils.Behaviors.Behavior[] {
            ((DevExpress.Utils.Behaviors.Behavior)(DevExpress.Utils.DragDrop.DragDropBehavior.Create(typeof(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), true, true, true, this.dragDropEvents1)))});
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            this.StartPosition = FormStartPosition.CenterParent;
            this.data = data;
            this.Columns = child;
            HandleBehaviorDragDropEvents();
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            txtGroup.Text = _group.ToString();
            this.KeyPreview = true;
            foreach (JObject item in data)
            {
                item.Add("Selected", false);
                if (!item.ContainsKey(EmrParam.MedicationGroup))
                    item.Add(EmrParam.MedicationGroup, String.Empty);
            }
            var grid = this.grcData.MainView as GridView;
            //grid.OptionsSelection.MultiSelect = true;
            //grid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            grid.OptionsBehavior.Editable = true;
            grid.RowHeight = 30;
            var column = new GridColumn();
            column.Caption = "Chọn";
            column.FieldName = "Selected";
            column.OptionsColumn.AllowEdit = true;
            var edit = grid.GridControl.RepositoryItems.Add("CheckEdit") as DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit;
            edit.CheckedChanged += new EventHandler(rowColEdit_CheckedChanged);
            column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            column.ColumnEdit = edit;
            column.VisibleIndex = 0;
            grid.Columns.Add(column);

            column = new GridColumn();
            column.Caption = "Nhóm";
            column.FieldName = EmrParam.MedicationGroup;
            column.OptionsColumn.AllowEdit = false;
            column.VisibleIndex = 1;
            grid.Columns.Add(column);
            if (Columns.Count == 0)
            {
                column = new GridColumn();
                column.Caption = "Giá trị";
                column.FieldName = "Value";
                column.OptionsColumn.AllowEdit = false;
                column.VisibleIndex = 2;
                grid.Columns.Add(column);
            }
            else
            {
                foreach (var item in Columns)
                {
                    var param = AppMemCache.GetParamFromDictKeyID(item.FK_MEParamChildID);
                    if (param.MEParamNo == EmrParam.MedicationGroup) continue;
                    column = new GridColumn();
                    column.Caption = param.MEParamCaption;
                    column.FieldName = param.MEParamNo;
                    column.OptionsColumn.AllowEdit = false;
                    column.VisibleIndex = item.MEParamRelationOrder + 2;
                    grid.Columns.Add(column);
                }
            }
            this.grcData.DataSource = this.data.ToObject<List<System.Dynamic.ExpandoObject>>();
            this.grcData.RefreshDataSource();
            this.grcData.Refresh();
            grid.BestFitColumns();
        }

        private void rowColEdit_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as DevExpress.XtraEditors.CheckEdit;
            var grid = this.grcData.MainView as GridView;
            int idx = grid.GetDataSourceRowIndex(grid.FocusedRowHandle);
            var sourceTable = grid.GridControl.DataSource as List<System.Dynamic.ExpandoObject>;
            ((IDictionary<String, object>)sourceTable[idx])["Selected"] = chk.Checked;
            this.grcData.RefreshDataSource();
            this.grcData.Refresh();
        }

        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
        }
        public void Ok()
        {
            this.FormatType = cbbFormatType.SelectedIndex;
            this.FormatedData = JArray.FromObject(grcData.DataSource);
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Ok();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public void HandleBehaviorDragDropEvents()
        {
            DragDropBehavior gridControlBehavior = behaviorManager1.GetBehavior<DragDropBehavior>(this.gridView1);
            gridControlBehavior.DragDrop += Behavior_DragDrop;
            gridControlBehavior.DragOver += Behavior_DragOver;
        }
        private void Behavior_DragOver(object sender, DragOverEventArgs e)
        {
            DragOverGridEventArgs args = DragOverGridEventArgs.GetDragOverGridEventArgs(e);
            e.InsertType = args.InsertType;
            e.InsertIndicatorLocation = args.InsertIndicatorLocation;
            e.Action = args.Action;
            Cursor.Current = args.Cursor;
            args.Handled = true;
        }
        private void Behavior_DragDrop(object sender, DevExpress.Utils.DragDrop.DragDropEventArgs e)
        {
            GridView targetGrid = e.Target as GridView;
            GridView sourceGrid = e.Source as GridView;
            if (e.Action == DragDropActions.None || targetGrid != sourceGrid)
                return;
            var sourceTable = sourceGrid.GridControl.DataSource as List<System.Dynamic.ExpandoObject>;

            Point hitPoint = targetGrid.GridControl.PointToClient(Cursor.Position);
            GridHitInfo hitInfo = targetGrid.CalcHitInfo(hitPoint);

            int[] sourceHandles = e.GetData<int[]>();

            int targetRowHandle = hitInfo.RowHandle;
            int targetRowIndex = targetGrid.GetDataSourceRowIndex(targetRowHandle);

            List<ExpandoObject> draggedRows = new List<ExpandoObject>();
            foreach (int sourceHandle in sourceHandles)
            {
                int oldRowIndex = sourceGrid.GetDataSourceRowIndex(sourceHandle);
                var oldRow = sourceTable[oldRowIndex];
                draggedRows.Add(oldRow);
            }

            int newRowIndex;

            switch (e.InsertType)
            {
                case InsertType.Before:
                    newRowIndex = targetRowIndex > sourceHandles[sourceHandles.Length - 1] ? targetRowIndex - 1 : targetRowIndex;
                    for (int i = draggedRows.Count - 1; i >= 0; i--)
                    {
                        var oldRow = draggedRows[i];
                        var newRow = DeepCopy(oldRow);
                        sourceTable.Remove(oldRow);
                        sourceTable.Insert(newRowIndex, newRow);
                    }
                    break;
                case InsertType.After:
                    newRowIndex = targetRowIndex < sourceHandles[0] ? targetRowIndex + 1 : targetRowIndex;
                    for (int i = 0; i < draggedRows.Count; i++)
                    {
                        var oldRow = draggedRows[i];
                        var newRow = DeepCopy(oldRow);
                        sourceTable.Remove(oldRow);
                        sourceTable.Insert(newRowIndex, newRow);
                    }
                    break;
                default:
                    newRowIndex = -1;
                    break;
            }
            int insertedIndex = targetGrid.GetRowHandle(newRowIndex);
            targetGrid.FocusedRowHandle = insertedIndex;
            targetGrid.SelectRow(targetGrid.FocusedRowHandle);
        }
        static ExpandoObject DeepCopy(ExpandoObject original)
        {
            var clone = new ExpandoObject();
            var _original = (IDictionary<string, object>)original;
            var _clone = (IDictionary<string, object>)clone;
            foreach (var kvp in _original)
                _clone.Add(kvp.Key, kvp.Value is ExpandoObject ? DeepCopy((ExpandoObject)kvp.Value) : kvp.Value);

            return clone;
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            var grid = this.grcData.MainView as GridView;
            var sourceTable = (grid.GridControl.DataSource as List<ExpandoObject>);
            var firstIndex = -1; var count = 0;
            for (int i = 0; i < sourceTable.Count; i++)
            {
                var item = (IDictionary<string, object>)sourceTable[i];
                if ((bool)item["Selected"] == true)
                {
                    if (firstIndex == -1) firstIndex = i;
                    item[EmrParam.MedicationGroup] = txtGroup.Text.ToString();

                    var oldRow = sourceTable[i];
                    var newRow = DeepCopy(oldRow);
                    sourceTable.Remove(oldRow);
                    ((IDictionary<string, object>)newRow)["Selected"] = false;
                    sourceTable.Insert(firstIndex + count, newRow);
                    count++;
                    item["Selected"] = false;
                }
            }
            this.grcData.RefreshDataSource();
            this.grcData.Refresh();

            _group++;
            txtGroup.Text = _group.ToString();
        }

        private void btnUnGroup_Click(object sender, EventArgs e)
        {
            var grid = this.grcData.MainView as GridView;
            var sourceTable = grid.GridControl.DataSource as List<ExpandoObject>;
            for (int i = 0; i < sourceTable.Count; i++)
            {
                var item = (IDictionary<string, object>)sourceTable[i];
                if ((bool)item["Selected"] == true)
                {
                    item[EmrParam.MedicationGroup] = string.Empty;
                    item["Selected"] = false;
                }
            }
            this.grcData.RefreshDataSource();
            this.grcData.Refresh();
        }
    }
}
