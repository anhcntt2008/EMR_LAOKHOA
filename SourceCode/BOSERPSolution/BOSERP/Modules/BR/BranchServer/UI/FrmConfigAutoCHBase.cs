using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using BOSERP.Modules.BR.BranchServer.BusinessEntities.Controller;
using BOSERP.Modules.BR.BranchServer.BusinessEntities.Info;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace BOSERP.Modules.BR.BranchServer.UI
{
    public partial class FrmConfigAutoCHBase : BOSERPScreen
    {
        private readonly BRBranchsInfo _branchsInfo;
        private readonly MECommandsController _commandsController;
        private readonly BRAutoUploadCHBaseController _autoUploadChBaseController;
        private readonly AutoUploadChBaseModel _dataSource = new AutoUploadChBaseModel(null, 0, string.Empty);
        private List<BRAutoUploadCHBaseInfo> _autoChBaseByBranch;

        public FrmConfigAutoCHBase(BRBranchsInfo branchsInfo)
        {
            InitializeComponent();
            _branchsInfo = branchsInfo;
            _commandsController = new MECommandsController();
            _autoUploadChBaseController = new BRAutoUploadCHBaseController();
            Load += FrmConfigAutoCHBase_Load;
            fld_btnClose.Click += Fld_btnClose_Click;
            fld_btnSave.Click += Fld_btnSave_Click;
            treeListCommands.CellValueChanging += TreeListCommands_CellValueChanging;
        }
        
        private void TreeListCommands_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "Checked") return;
            var value = (bool)e.Value;
            var se = treeListCommands.Selection[0];
            se.SetValue(2, value);

            var parent = e.Node.ParentNode;
            if (parent != null)
            {
                if (!value)
                {
                    parent.SetValue(2, value);
                }
                else
                {
                    var isCheck = true;
                    foreach (TreeListNode node in parent.Nodes)
                    {
                        var v =(bool) node.GetValue(2);
                        if (v) continue;
                        isCheck = false;
                        break;
                    }
                    if (isCheck)
                    {
                        parent.SetValue(2, true);
                    }
                }
            }
                
            foreach (TreeListNode treeListNode in e.Node.Nodes)
            {
                treeListNode.SetValue(2, e.Value);
            }
            // TreeListCommands_CellValueChanged(sender, e);
        }

        private void Fld_btnSave_Click(object sender, EventArgs e)
        {
            UpdateDataAutoChBase(_dataSource.ChildrenNode);
            MessageBox.Show("Đã lưu thành công");
            Close();
        }

        private void UpdateDataAutoChBase(List<AutoUploadChBaseModel> dataSource)
        {
            foreach (var data in dataSource)
            {
                var autoChBase =
                    _autoChBaseByBranch.FirstOrDefault(x => x.BRAutoUploadCHBaseID == data.IdAutoUploadChBase);
                if (autoChBase == null)
                {
                    autoChBase = new BRAutoUploadCHBaseInfo()
                    {
                        BRAutoUploadCHBaseValue = data.Checked,
                        FK_BRBranchID = _branchsInfo.BRBranchID,
                        FK_MECommandID = data.IdCommand,
                        AAStatus = "Alive"
                    };
                    _autoUploadChBaseController.CreateObject(autoChBase);
                }
                else
                {
                    if (autoChBase.BRAutoUploadCHBaseValue == data.Checked) continue;
                    autoChBase.BRAutoUploadCHBaseValue = data.Checked;
                    _autoUploadChBaseController.UpdateObject(autoChBase);
                }
                UpdateDataAutoChBase(data.ChildrenNode);
            }
        }

        private void Fld_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmConfigAutoCHBase_Load(object sender, EventArgs e)
        {

            var allCommand = _commandsController.GetAllCommandList();
            _autoChBaseByBranch = _autoUploadChBaseController.GetByBranch(_branchsInfo.BRBranchID);
            foreach (
                var commandsInfo in allCommand.Where(x => x.MECommandParentID == 0).OrderBy(x => x.MECommandSortOrder))
            {
                var autoChbase = _autoChBaseByBranch.FirstOrDefault(x => x.FK_MECommandID == commandsInfo.MECommandID);
                var node = new AutoUploadChBaseModel(_dataSource, commandsInfo.MECommandID, commandsInfo.MECommandDesc, autoChbase?.BRAutoUploadCHBaseID ?? 0,
                    autoChbase?.BRAutoUploadCHBaseValue ?? false);
                foreach (var child in allCommand.Where(x => x.MECommandParentID == commandsInfo.MECommandID).ToList())
                {
                    var childAuto = _autoChBaseByBranch.FirstOrDefault(x => x.FK_MECommandID == child.MECommandID);
                    if (autoChbase != null && autoChbase.BRAutoUploadCHBaseValue)
                    {

                        var autoUploadChBaseModel = new AutoUploadChBaseModel(node, child.MECommandID,
                            child.MECommandDesc, childAuto?.BRAutoUploadCHBaseID ?? 0, true);
                    }
                    else
                    {
                        var autoUploadChBaseModel = new AutoUploadChBaseModel(node, child.MECommandID,
                            child.MECommandDesc, childAuto?.BRAutoUploadCHBaseID ?? 0, childAuto?.BRAutoUploadCHBaseValue ?? false);
                    }


                }
            }
            var col1 = new TreeListColumn
            {
                Caption = "IdCommand",
                Name = "IdCommand",
                VisibleIndex = 0,
                Visible = false
            };
            var col2 = new TreeListColumn
            {
                Caption = "Chức năng",
                Name = "Name",
                VisibleIndex = 1,
            };

            var col3 = new TreeListColumn
            {
                Caption = "Tự động upload",
                Name = "Checked",
                VisibleIndex = 2,
                ColumnEdit = new RepositoryItemCheckEdit()
            };
            var col4 = new TreeListColumn
            {
                Caption = "IdAutoUploadCHBase",
                Name = "IdAutoUploadCHBase",
                VisibleIndex = 3,
                Visible = false
            };

            treeListCommands.Columns.AddRange(new[] { col1, col2, col3, col4 });

            treeListCommands.DataSource = _dataSource;
            treeListCommands.ExpandAll();
        }
    }
}