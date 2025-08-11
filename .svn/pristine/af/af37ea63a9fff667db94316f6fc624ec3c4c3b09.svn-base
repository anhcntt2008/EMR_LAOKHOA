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
using BOSCommon;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiDataQuery : BOSERPScreen
    {
        private List<MEEmrDocumentsInfo> _documentList;
        public JToken SelectedRow { get; private set; }
        public List<JToken> SelectedRows { get; private set; }
        public bool InsertParam = true;
        private List<MEParamsInfo> _listEmrParams;
        private bool _multiSelect;

        public guiDataQuery(List<MEEmrDocumentsInfo> docs, bool multiSelect = false)
        {
            InitializeComponent();
            this._multiSelect = multiSelect;
            this._documentList = docs.Where(o => o.MEEmrDocumentStatus != EmrDocumentStatus.Hidden.ToString()).ToList();
            this._listEmrParams = new List<MEParamsInfo>();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                this.Ok();
            }
        }
        public void GetParamsTree(JToken data)
        {
            this.treeListData.BeginUnboundLoad();
            this.treeListData.ClearNodes();
            this.GetParamsTree(data, this.treeListData, null);
            this.treeListData.EndUnboundLoad();
            this.treeListData.ExpandAll();
        }
        public MEParamsInfo GetParamByNo(string v)
        {
            var p = _listEmrParams.Where(o => o.MEParamNo == v).FirstOrDefault();
            if (p != null) return p;
            p = AppMemCache.GetParamFromDictKeyNo(v);
            if (p != null) _listEmrParams.Add(p);
            return p;
        }
        private void GetParamsTree(JToken data, TreeList list, TreeListNode parent)
        {
            if (data.Type == JTokenType.Object)
            {
                foreach (JToken child in data.Children())
                    this.GetParamsTree(child, list, parent);
                return;
            }
            else if (data.Type == JTokenType.Property)
            {
                string paramNo = data.GetType().GetProperty("Name").GetValue(data).ToString();
                var info = GetParamByNo(paramNo);
                if (info != null)
                {
                    var prop = data as JProperty;
                    var value = prop != null ? prop.Value : null;
                    var str = value != null && value.HasValues ? string.Empty : value.ToString();
                    var obj = new object[] { info.MEParamName, str, prop };
                    var node = list.AppendNode(obj, parent);
                    this.GetParamsTree(value, list, node);
                }
                else this.GetParamsTree(data.FirstOrDefault(), list, parent);
                return;
            }
            else if (data.Type == JTokenType.Array)
            {
                for (int i = 0; i < data.Count(); i++)
                {
                    var value = data[i];
                    var obj = new object[] { "#" + (i + 1), string.Empty, value };
                    if (value.Type != JTokenType.Object && value.Type != JTokenType.Array && value.Type != JTokenType.Property)
                        obj[1] = value.ToString();
                    if (data.Parent != null)
                        obj[2] = new JProperty((data.Parent as JProperty).Name, new object[] { value });

                    var node = list.AppendNode(obj, parent);
                    this.GetParamsTree(value, list, node);
                }
                return;
            }
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.treeListData.BeginUpdate();
            this.treeListData.OptionsView.ShowCheckBoxes = true;
            this.treeListData.OptionsSelection.MultiSelect = this._multiSelect;
            this.treeListData.OptionsBehavior.Editable = false;
            this.treeListData.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeListData.OptionsCustomization.AllowFilter = true;
            this.treeListData.OptionsView.ShowAutoFilterRow = true;

            var col = this.treeListData.Columns.Add();
            col.Visible = true;
            col.FieldName = col.Name = "Thẻ";
            col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            col.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;

            var col2 = this.treeListData.Columns.Add();
            col2.Visible = true;
            col2.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            col2.FieldName = col2.Name = "Giá trị";
            col2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            col2.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;

            var col3 = this.treeListData.Columns.Add();
            col3.Visible = true;
            col3.VisibleIndex = -1;
            col3.FieldName = "Dữ liệu thô";

            this.treeListData.EndUpdate();
            this.InitializeControls(this.Controls);
            fld_dgcMEEmrDocuments1.DataSource = this._documentList;
        }

        internal void GetMongoData(MEEmrDocumentsInfo mEEmrDocumentsInfo)
        {
            var data = ((MEEmrModule)Module).GetMongoDataByQuery(mEEmrDocumentsInfo);
            if (data != null)
                GetParamsTree(data);
        }

        private void Ok()
        {
            DialogResult = DialogResult.OK;
            SelectedRows = new List<JToken>();
            //Call the operation:
            GetDataQueryCheckedNodesOperation op = new GetDataQueryCheckedNodesOperation();
            this.treeListData.NodesIterator.DoOperation(op);
            foreach (var item in op.CheckedNodes)
            {
                var value = item.GetValue(this.treeListData.Columns[2]);
                if (value is JProperty)
                    SelectedRow = (JToken)(value as JProperty).Parent;
                else
                    SelectedRow = (JToken)value;
                //chi lay node dau tien
                break;
            }
            if (this._multiSelect)
                foreach (var item in op.CheckedNodes)
                {
                    var value = item.GetValue(this.treeListData.Columns[2]);
                    SelectedRows.Add((JToken)value);
                }
            this.Close();
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
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)fld_dgcMEEmrDocuments1.MainView;
            if (gridView.FocusedRowHandle >= 0)
            {
                GetMongoData(gridView.GetRow(gridView.FocusedRowHandle) as MEEmrDocumentsInfo);
            }
        }

        private void btnInsertValue_Click(object sender, EventArgs e)
        {
            InsertParam = false;
            Ok();
        }
    }
    class GetDataQueryCheckedNodesOperation : TreeListOperation
    {
        public List<TreeListNode> CheckedNodes = new List<TreeListNode>();
        public GetDataQueryCheckedNodesOperation() : base() { }
        public override void Execute(TreeListNode node)
        {
            if (node.CheckState == CheckState.Checked)
            {
                if (node.ParentNode == null)
                    CheckedNodes.Add(node);
                else
                {
                    if (node.ParentNode.CheckState != CheckState.Checked)
                        CheckedNodes.Add(node);
                }
            }
        }
    }
}
