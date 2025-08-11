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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Linq;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.Utils.DirectXPaint;
using Newtonsoft.Json;
using DevExpress.XtraCharts.UI;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiDataSelection : BOSERPScreen
    {
        private JToken _data;
        private List<MEEmrActionParamsInfo> _updateParams;
        public JToken SelectedRow { get; private set; }
        public List<JToken> SelectedRows { get; private set; }
        private List<MEParamsInfo> _listEmrParams;
        private MEParamsInfo param;
        private bool _multiSelect;
        private int _currentIdx;
        private bool _selectChildArray = false;
        private bool _selectable = true;

        public guiDataSelection(JToken data, List<MEEmrActionParamsInfo> updateParams, bool multiSelect = false)
        {
            InitializeComponent();
            this._multiSelect = multiSelect;
            this._data = data;
            this._updateParams = updateParams;
            this._listEmrParams = new List<MEParamsInfo>();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            this._currentIdx = -1;
            this._selectChildArray = false;
            _selectable = true;
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
        }
        public guiDataSelection(JToken data, MEParamsInfo param, bool multiSelect = false, bool selectChildArray = false)
        {
            InitializeComponent();
            this._multiSelect = multiSelect;
            this._data = data;
            this.param = param;
            this._listEmrParams = new List<MEParamsInfo>();
            this._updateParams = new List<MEEmrActionParamsInfo>();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            this._currentIdx = -1;
            this._selectChildArray = selectChildArray;
        }

        public guiDataSelection(JToken data, MEParamsInfo param, bool multiSelect, int currentIdx) : this(data, param, multiSelect)
        {
            this._currentIdx = currentIdx;
        }

        public void GetParamsTree()
        {
            this.treeListData.BeginUnboundLoad();
            this.GetParamsTree(_data, this.treeListData, null, null);
            this.treeListData.EndUnboundLoad();
            this.treeListData.RefreshDataSource();
        }
        public MEParamsInfo GetParamByNo(string v)
        {
            var p = _listEmrParams.Where(o => o.MEParamNo == v).FirstOrDefault();
            if (p != null) return p;
            p = AppMemCache.GetParamFromDictKeyNo(v);
            if (p != null) _listEmrParams.Add(p);
            return p;
        }
        private void GetParamsTree(JToken data, TreeList list, TreeListNode parent, JToken parentData)
        {
            var bold = false;
            var color = string.Empty;
            if (data.Type == JTokenType.Object)
            {
                foreach (JToken child in data.Children())
                    this.GetParamsTree(child, list, parent, data);
                return;
            }
            if (data.Type == JTokenType.Property)
            {
                string paramNo = data.GetType().GetProperty("Name").GetValue(data).ToString();
                if (paramNo == "_highlightProps") return;

                if (paramNo == "_error" || paramNo == "_warn" || paramNo == "_info")
                {
                    var prop = data as JProperty;
                    var value = prop != null ? prop.Value : null;
                    var str = value != null && value.HasValues ? string.Empty : value.ToString();

                    var stTitle = "Thông báo";
                    var stColor = Color.Blue;
                    switch (paramNo)
                    {
                        case "_error":
                            stTitle = "Cảnh báo";
                            stColor = Color.Red;
                            break;
                        case "_warn":
                            stTitle = "Cảnh báo";
                            stColor = Color.DarkOrange;
                            break;
                    }

                    var obj = new object[] { stTitle, str, string.Empty, true, stColor.Name };
                    var node = list.AppendNode(obj, parent);
                    node.Tag = DrawCheckState.NotToDraw;
                    return;
                }

                var info = GetParamByNo(paramNo);
                if (info != null)
                {
                    var prop = data as JProperty;
                    var value = prop != null ? prop.Value : null;
                    var str = value != null && value.HasValues ? string.Empty : value.ToString();

                    if (parentData != null)
                    {
                        var parentDataObj = (parentData as JObject)?.ToObject<IDictionary<string, object>>();
                        if (parentDataObj != null)
                        {
                            if (parentDataObj.ContainsKey("_bold") && !string.IsNullOrEmpty(parentDataObj["_bold"].ToString()))
                            {
                                bold = bool.Parse(parentDataObj["_bold"].ToString());
                            }
                            if (parentDataObj.ContainsKey("_color"))
                            {
                                color = parentDataObj["_color"].ToString();
                            }

                            if (parentDataObj.ContainsKey("_highlightProps"))
                            {
                                var objectHighlights = parentDataObj["_highlightProps"] as JArray;
                                if (objectHighlights != null)
                                {
                                    if (!objectHighlights.Any(m=> m.ToString() == paramNo))
                                    {
                                        bold = false;
                                        color = string.Empty;
                                    }
                                }
                            }
                        }
                    }

                    var obj = new object[] { info.MEParamName, str, prop, bold, color };
                    var node = list.AppendNode(obj, parent);
                    if (_updateParams.Any(o => o.FK_MEParamID == info.MEParamID))
                        if ((value is JArray) && info.MEParamType == BOSCommon.EmrParamTypes.Single.ToString())
                            node.Tag = DrawCheckState.NotToDraw;
                        else
                            node.Tag = _selectable ? DrawCheckState.ToDraw : DrawCheckState.NotToDraw;
                    else
                        node.Tag = DrawCheckState.NotToDraw;
                    this.GetParamsTree(value, list, node,null);
                }
                else this.GetParamsTree(data.FirstOrDefault(), list, parent, null);
                return;
            }
            if (data.Type == JTokenType.Array)
            {
                for (int i = 0; i < data.Count(); i++)
                {
                    var value = data[i];

                    #region 1599
                    _selectable = true;
                    var dataObj = (value as JObject)?.ToObject<IDictionary<string, object>>();
                    if (dataObj != null)
                    {
                        if (dataObj.ContainsKey("_selectable"))
                        {
                            _selectable = bool.Parse(dataObj["_selectable"].ToString());
                        }
                    }
                    #endregion

                    var obj = new object[] { "#" + (i + 1), string.Empty, value, bold, color };
                    if (value.Type != JTokenType.Object && value.Type != JTokenType.Array && value.Type != JTokenType.Property)
                    {
                        obj[1] = value.ToString();
                    }
                    var tag = DrawCheckState.NotToDraw;
                    if (data.Parent != null)
                    {
                        var bindValue = new Dictionary<string, object>
                        {
                            { (data.Parent as JProperty).Name, value }
                        };
                        obj[2] = JObject.FromObject(bindValue);
                        var info = GetParamByNo((data.Parent as JProperty).Name);
                        if (_updateParams.Any(o => o.FK_MEParamID == info.MEParamID))
                            tag = _selectable ? DrawCheckState.ToDraw : DrawCheckState.NotToDraw;

                        if (_selectChildArray)
                        {
                            // node level 2
                            // only level 2 so ugly code
                            if (data.Parent.Parent != null && data.Parent.Parent.Root == data.Root)
                            {
                                var parentObj = (data.Parent.Parent as JObject)?.ToObject<IDictionary<string, object>>();
                                if (parentObj != null)
                                {
                                    if (parentObj.ContainsKey("_selectable") && !string.IsNullOrEmpty(parentObj["_selectable"].ToString()))
                                    {
                                        _selectable = bool.Parse(parentObj["_selectable"].ToString());
                                    }
                                }
                                tag = _selectable ? DrawCheckState.ToDraw : DrawCheckState.NotToDraw;
                            }
                        }
                    }
                    else
                    {
                        //truong hop nay la danh sach root
                        if (value is JObject)
                            foreach (var prop in value)
                            {
                                var info = GetParamByNo((prop as JProperty).Name);
                                if (info != null)
                                    if (_updateParams.Any(o => o.FK_MEParamID == info.MEParamID))
                                    {
                                        tag = _selectable ? DrawCheckState.ToDraw : DrawCheckState.NotToDraw;
                                        break;
                                    }
                            }
                    }
                    //truong hop chỉ chon gia tri cho mot param
                    //_currentIdx dung trong truong hop copy dong/cot sang dong/cot. _currentIdx la dong dang chon
                    if (param != null && data.Parent == null && i != _currentIdx)
                    {
                        tag = _selectable ? DrawCheckState.ToDraw : DrawCheckState.NotToDraw;
                    }
                    var node = list.AppendNode(obj, parent);
                    node.Tag = tag;
                    this.GetParamsTree(value, list, node, data);
                }
                return;
            }
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.treeListData.OptionsView.ShowCheckBoxes = true;
            this.treeListData.OptionsSelection.MultiSelect = this._multiSelect;
            this.treeListData.OptionsBehavior.Editable = false;
            this.treeListData.OptionsCustomization.AllowFilter = true;
            this.treeListData.OptionsView.ShowAutoFilterRow = true;

            var col = this.treeListData.Columns.Add();
            col.Visible = true;
            col.FieldName = col.Name = "Thẻ";
            col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            col.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;

            var col2 = this.treeListData.Columns.Add();
            col2.Visible = true;
            col2.FieldName = col2.Name = "Giá trị";
            col2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            col2.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;

            var col3 = this.treeListData.Columns.Add();
            col3.Visible = false;
            col3.VisibleIndex = -1;
            col3.FieldName = "Value";

            var col4 = this.treeListData.Columns.Add();
            col4.Visible = false;
            col4.VisibleIndex = -1;
            col4.FieldName = "Bold";

            var col5 = this.treeListData.Columns.Add();
            col5.Visible = false;
            col5.VisibleIndex = -1;
            col5.FieldName = "Color";

            GetParamsTree();
            //this.treeListData.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeListData.NodeCellStyle += treeList1_NodeCellStyle;

            this.treeListData.ExpandAll();
            chkSelectedAll.Visible = this._multiSelect;
        }
        private void treeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (_currentIdx < 0) return;
            if (e.Node["Thẻ"]?.ToString() == ("#" + (_currentIdx + 1)) && e.Node.ParentNode == null)
            {
                e.Appearance.BackColor = Color.FromArgb(255, 255, 192);
                e.Appearance.ForeColor = Color.DarkRed;
                e.Appearance.FontStyleDelta = FontStyle.Bold;
            }
        }
        private void Ok()
        {
            DialogResult = DialogResult.OK;
            SelectedRows = new List<JToken>();
            //Call the operation:
            GetCheckedNodesOperation op = new GetCheckedNodesOperation();
            this.treeListData.NodesIterator.DoOperation(op);
            foreach (var item in op.CheckedNodes)
            {
                var value = item.GetValue(this.treeListData.Columns[2]);
                if (value is JProperty)
                    SelectedRow = (JToken)(value as JProperty).Parent;
                else
                    SelectedRow = TrueData((JToken)value);
                break;
            }
            if (this._multiSelect)
            {
                if (this._selectChildArray)
                {
                    foreach (var node in op.CheckedNodes)
                    {
                        if (node.ParentNode == null)
                        {
                            var value = (JToken)node.GetValue(this.treeListData.Columns[2]);
                            var firstChild = true;
                            foreach (var child in op.CheckedNodes)
                            {
                                if (child.ParentNode != null && child.ParentNode.ParentNode == node)
                                {
                                    //merge data to parent
                                    var childValue = (JToken)child.GetValue(this.treeListData.Columns[2]);
                                    var prop = (childValue.First() as JProperty);
                                    if (firstChild)
                                        (value[prop.Name] as JArray).Clear();
                                    (value[prop.Name] as JArray).Add(prop.Value);
                                    firstChild = false;
                                }
                            }
                            var childR = TrueData((JToken)value);
                            if (childR != null)
                            {
                                SelectedRows.Add(childR);
                            }
                        }
                    }
                }
                else
                {
                    foreach (var item in op.CheckedNodes)
                    {
                        var value = item.GetValue(this.treeListData.Columns[2]);
                        if (value is JProperty)
                            SelectedRows.Add((JToken)(value as JProperty).Parent);
                        else
                            SelectedRows.Add((JToken)value);
                    }
                }
            }
            this.Close();
        }

        private JToken TrueData(JToken data)
        {
            if (data.Children().Count() == 1)
            {
                return data;
            }
            else
            {
                foreach (JToken child in data.Children())
                {
                    var valueChild = child.FirstOrDefault();
                    if (valueChild != null && valueChild.Type == JTokenType.Array)
                    {
                        var deletesNum = new List<int>();
                        for (int i = 0; i < valueChild.Count(); i++)
                        {
                            var valueChild2 = valueChild[i];
                            var dataObjChild2 = (valueChild2 as JObject)?.ToObject<IDictionary<string, object>>();
                            if (dataObjChild2 != null)
                            {
                                if (dataObjChild2.ContainsKey("_selectable") && !bool.Parse(dataObjChild2["_selectable"].ToString()))
                                {
                                    deletesNum.Add(i);
                                }
                            }
                        }
                        if (deletesNum != null)
                        {
                            if (deletesNum.Count() == valueChild.Count())
                            {
                                data = null;
                            }
                            else
                            {
                                foreach (var num in deletesNum.OrderByDescending(i => i))
                                {
                                    valueChild[num].Remove();
                                }
                            }
                        }
                    }
                }
                return data;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DSMEEMR106_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void DSMEEMR106_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void treeListData_CustomDrawNodeCheckBox(object sender, CustomDrawNodeCheckBoxEventArgs e)
        {
            if ((DrawCheckState)e.Node.Tag == DrawCheckState.NotToDraw)
            {
                e.ObjectArgs.State = DevExpress.Utils.Drawing.ObjectState.Disabled;
                e.Handled = true;
            }
        }

        private void chkSelectedAll_CheckedChanged(object sender, EventArgs e)
        {
            var op = new CheckedAllNodesOperation(chkSelectedAll.Checked ? CheckState.Checked : CheckState.Unchecked);
            this.treeListData.NodesIterator.DoOperation(op);
        }

        private void treeListData_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node[3] != null && (bool)e.Node[3])
                {
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }
                if (e.Node[4] != null && !string.IsNullOrEmpty(e.Node[4].ToString()))
                {
                    e.Appearance.ForeColor = Color.FromName(e.Node[4].ToString());
                }
            }
        }
    }

    public enum DrawCheckState { ToDraw, NotToDraw }
    //The operation class that collects checked nodes
    class GetCheckedNodesOperation : TreeListOperation
    {
        public List<TreeListNode> CheckedNodes = new List<TreeListNode>();
        public GetCheckedNodesOperation() : base() { }
        public override void Execute(TreeListNode node)
        {
            if (node.CheckState != CheckState.Unchecked)
                CheckedNodes.Add(node);
        }
    }
    class CheckedAllNodesOperation : TreeListOperation
    {
        private CheckState _state;
        public CheckedAllNodesOperation(CheckState state) : base()
        {
            this._state = state;
        }
        public override void Execute(TreeListNode node)
        {
            if ((DrawCheckState)node.Tag == DrawCheckState.ToDraw)
                node.CheckState = _state;
        }
    }
}
