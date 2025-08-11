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
using System.Linq;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiSortTableRows : BOSERPScreen
    {
        private JArray _data;
        private List<MEParamRelationsInfo> Columns;
        private MEParamsController _paramCtrl;
        public JArray FormatedData { get; private set; }

        public guiSortTableRows(MEParamsInfo param, JArray data, List<MEParamRelationsInfo> child)
        {
            InitializeComponent();
            this.behaviorManager1.SetBehaviors(this.gridView1,
                new DevExpress.Utils.Behaviors.Behavior[] {
                    DragDropBehavior.Create(typeof(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), true, true, true, this.dragDropEvents1)
                });
            this.KeyDown += new KeyEventHandler(this.Ok_KeyDown);
            this.StartPosition = FormStartPosition.CenterParent;
            this._data = data;
            this.Columns = child;
            _paramCtrl = new MEParamsController();
            HandleBehaviorDragDropEvents();
            this.Text = this.Text + $" [{(string.IsNullOrEmpty(param.MEParamCaption) ? param.MEParamName : param.MEParamCaption) }]";
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            int order = 1;
            foreach (JObject item in _data)
            {
                item.Add("OriginalOrderNum", order++);
                foreach (KeyValuePair<string, JToken> pro in item)
                {
                    if (pro.Value.Type == JTokenType.Object)
                    {
                        string results = pro.Value.Aggregate(string.Empty, (values, jToken) =>
                        {
                            if (values.Length > 500) return values;
                            var val = (jToken as JProperty)?.Value;
                            if (val != null && val.Type != JTokenType.Array && val.Type != JTokenType.Object)
                                return values += " " + val.ToString();
                            return values;
                        });
                        item[pro.Key] = results;
                    }
                }
            }
            var grid = this.grcData.MainView as GridView;
            grid.OptionsBehavior.Editable = true;
            grid.OptionsView.ShowGroupPanel = false;

            grid.RowHeight = 30;
            var column = new GridColumn
            {
                Caption = "Thứ tự trên tờ",
                FieldName = "OriginalOrderNum",
                Width = 100
            };
            column.OptionsColumn.AllowEdit = false;
            column.VisibleIndex = 1;
            grid.Columns.Add(column);
            if (Columns.Count == 0)
            {
                column = new GridColumn
                {
                    Caption = "Giá trị",
                    FieldName = "Value"
                };
                column.OptionsColumn.AllowEdit = false;
                column.VisibleIndex = 2;
                grid.Columns.Add(column);
            }
            else
            {
                foreach (var item in Columns)
                {
                    var param = _paramCtrl.GetObjectByID(item.FK_MEParamChildID) as MEParamsInfo;
                    column = new GridColumn
                    {
                        Caption = param.MEParamCaption,
                        FieldName = param.MEParamNo,
                        Width = 150
                    };
                    column.OptionsColumn.AllowEdit = false;
                    if (param.MEParamFormatType == ParamFormatType.Date.ToString()
                        || param.MEParamFormatType == ParamFormatType.DateTime.ToString()
                        || param.MEParamFormatType == ParamFormatType.Time.ToString())
                    {
                        column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        column.DisplayFormat.FormatString = string.IsNullOrEmpty(param.MEParamFormatString) ? "dd/MM/yyyy HH:mm" : param.MEParamFormatString;
                    }
                    column.VisibleIndex = item.MEParamRelationOrder + 2;
                    grid.Columns.Add(column);
                }
            }
            this.grcData.DataSource = this._data.ToObject<List<System.Dynamic.ExpandoObject>>();
            this.grcData.RefreshDataSource();
            this.grcData.Refresh();
            //grid.BestFitColumns();
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
    }
}
