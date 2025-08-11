using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using DevExpress.XtraGrid.Columns;
using BOSCommon;
using BOSLib;

namespace BOSERP
{
    public partial class guiDocumentRelease : BOSERPScreen
    {
        private List<MEEmrDocumentsInfo> _data;
        private int _userID;
        public guiDocumentRelease(List<MEEmrDocumentsInfo> data, int userID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            KeyDown += new KeyEventHandler(this.Ok_KeyDown);
            _data = data;
            _userID = userID;
        }
        private void guiDocumentRelease_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            var grid = this.grcEmrDocumentRelease.MainView as GridView;
            grid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            grid.OptionsSelection.MultiSelect = true;
            grid.OptionsSelection.EnableAppearanceFocusedCell = false;
            grid.OptionsSelection.EnableAppearanceFocusedRow = true;

            var column = new GridColumn
            {
                Caption = "Mã tài liệu",
                FieldName = "MEEmrDocumentNo"
            };
            column.OptionsColumn.AllowEdit = false;
            column.VisibleIndex = 1;
            grid.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Gáy",
                FieldName = "MEEmrDocumentGroup"
            };
            column.OptionsColumn.AllowEdit = false;
            column.VisibleIndex = 1;
            grid.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Đang sửa bởi (IP/PC)",
                FieldName = "MEEmrDocumentHoldMachineIp"
            };
            column.OptionsColumn.AllowEdit = false;
            column.VisibleIndex = 1;
            grid.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Đang sửa bởi (MAC)",
                FieldName = "MEEmrDocumentHoldMachineMac"
            };
            column.OptionsColumn.AllowEdit = false;
            column.VisibleIndex = 1;
            grid.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Giữ tờ bệnh án từ",
                FieldName = "MEEmrDocumentHoldFrom"
            };
            column.OptionsColumn.AllowEdit = false;
            column.VisibleIndex = 1;
            grid.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Thứ tự",
                FieldName = "MEEmrDocumentSubOrder"
            };
            column.OptionsColumn.AllowEdit = false;
            column.VisibleIndex = 1;
            grid.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "Id",
                FieldName = "MEEmrDocumentID"
            };
            column.OptionsColumn.AllowEdit = false;
            column.VisibleIndex = 1;
            grid.Columns.Add(column);

            column = new GridColumn
            {
                Caption = "File",
                FieldName = "MEEmrDocumentFile"
            };
            column.OptionsColumn.AllowEdit = false;
            column.VisibleIndex = 1;
            grid.Columns.Add(column);

            this.grcEmrDocumentRelease.DataSource = _data;
            this.grcEmrDocumentRelease.RefreshDataSource();
            this.grcEmrDocumentRelease.Refresh();
            grid.BestFitColumns();
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
            var grid = this.grcEmrDocumentRelease.MainView as GridView;
            var rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageBox.Show("Chọn ít nhất 01 tờ bệnh án để thực hiện thao tác.", "Chưa chọn tờ bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var emrDocumentController = new MEEmrDocumentsController();
            var geObjHistoryCtrl = new GEObjectHistoryController();
            var cstObjectHistoryActionRevokeEditPer = BaseModule.cstObjectHistoryActionRevokeEditPer;
            foreach (int rowidx in rows)
            {
                var document = grid.GetRow(rowidx) as MEEmrDocumentsInfo;
                emrDocumentController.ForceReleaseEditingPermission(document.MEEmrDocumentID, _userID);
                var objGeObjectHistoryInfo = new GEObjectHistoryInfo
                {
                    ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                    ADUserName = BOSApp.CurrentUser,
                    GEObjectHistoryAction = cstObjectHistoryActionRevokeEditPer,
                    GEObjectHistoryObjectID = document.MEEmrDocumentID,
                    GEObjectHistoryObjectName = TableName.MEEmrDocumentsTableName,
                    GEObjectHistoryObjectNumber = document.MEEmrDocumentFile,
                    GEObjectHistoryDate = DateTime.Now
                };
                geObjHistoryCtrl.CreateObject(objGeObjectHistoryInfo);
            }

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
    }
}
