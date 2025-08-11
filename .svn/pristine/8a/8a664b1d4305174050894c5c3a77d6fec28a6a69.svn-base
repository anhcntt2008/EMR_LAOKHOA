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
using BOSCommon;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System.Drawing.Drawing2D;
using System.Linq;
using BOSERP.UI;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Lien Ket Benh An
    /// </summary>
    public partial class guiPatientRelation : BOSERPScreen
    {
        private readonly MEEmrsController _emrCtrl;
        public int SelectedEmrID { get; private set; }

        public string SelectedEmrNo { get; private set; }

        public string SelectedEmrRelationFromName { get; private set; }

        public string SelectedEmrRelationToName { get; private set; }

        public guiPatientRelation()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.guiSelectEmrRelation_Ok_KeyDown);
            _emrCtrl = new MEEmrsController();
        }

        private void guiSelectEmrRelation_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.InitializeControls(this.Controls);
            guiSelectEmrRelation_chkSearchByPatient.Checked = false;
            ChangeControlsState(true);
            this.guiSelectEmrRelation_chkSearchByPatient.CheckedChanged += new System.EventHandler(this.guiSelectEmrRelationChkSearchByPatient_CheckedChanged);
        }

        private void guiSelectEmrRelationChkSearchByPatient_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckEdit)sender;
            ChangeControlsState(!chk.Checked);
            if (chk.Checked)
                this.SearchPatient(guiSelectEmrRelation_fld_txtMEPatientNo.Text);
            else
            {
                guiSelectEmrRelation_fld_txtMEPatientNo.Text = string.Empty;
                guiSelectEmrRelation_fld_lkeFK_MEPatientID.EditValue = 0;
                guiSelectEmrRelation_fld_txtMEPatientName.Text = string.Empty;
            }
        }

        private void guiSelectEmrRelation_fld_txtMEPatientNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && guiSelectEmrRelation_chkSearchByPatient.Checked)
            {
                this.SearchPatient(guiSelectEmrRelation_fld_txtMEPatientNo.Text);
            }
        }

        private void ChangeControlsState(bool enable)
        {
            guiSelectEmrRelation_fld_txtMEEmrNo.Enabled = enable;
            guiSelectEmrRelation_fld_txtMEPatientNo.Enabled = !enable;
            guiSelectEmrRelation_fld_lkeFK_MEPatientID.Enabled = !enable;
        }

        private void SearchPatient(string text)
        {
            var gui = new guiSearchPatient(text);
            gui.Module = this.Module;
            gui.StartPosition = FormStartPosition.CenterParent;
            if (gui.ShowDialog() == DialogResult.OK)
            {
                guiSelectEmrRelation_fld_lkeFK_MEPatientID.EditValue = gui.Patient.MEPatientID;
                guiSelectEmrRelation_fld_txtMEPatientNo.Text = gui.Patient.MEPatientNo;
                guiSelectEmrRelation_fld_txtMEPatientName.Text = gui.Patient.MEPatientName;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (guiSelectEmrRelation_chkSearchByPatient.Checked)
            {
                SearchByPatient();
                return;
            }
            var view = string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserEmrView) ? BOSApp.CurrentUserGroupInfo.ADUserGroupEmrView : BOSApp.CurrentUsersInfo.ADUserEmrView;
            Cursor.Current = Cursors.WaitCursor;
            var stateConds = (this.Module as BaseModuleERP).GetStatePermiQueryConditionStr(TableName.MEEmrsTableName, false);
            var ds = _emrCtrl.QuickSearchWithOneCriteria(guiSelectEmrRelation_fld_txtMEEmrNo.Text,
                   null,
                   null, //BOSApp.CurrentEmployeesInfo.HREmployeeID,
                   null, //BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID,
                   null, //EmrStatus.InProgress.ToString(),
                   null, // mEEmrArchiveStatus,
                   view,
                   stateConds,
                   string.Empty);
            fld_dgcEmrRelationSelections.DataSource = ds.Tables[0];
            fld_dgcEmrRelationSelections.RefreshDataSource();
            Cursor.Current = Cursors.Default;
        }

        private void SearchByPatient()
        {
            var view = string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserEmrView) ? BOSApp.CurrentUserGroupInfo.ADUserGroupEmrView : BOSApp.CurrentUsersInfo.ADUserEmrView;
            var stateConds = (this.Module as BaseModuleERP).GetStatePermiQueryConditionStr(TableName.MEEmrsTableName, false);
            var ds = _emrCtrl.QuickSearchWithOneCriteria(null,
                   guiSelectEmrRelation_fld_lkeFK_MEPatientID.EditValue,
                   BOSApp.CurrentEmployeesInfo.HREmployeeID,
                   BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID,
                   null, // EmrStatus.InProgress.ToString(),
                   null, // mEEmrArchiveStatus,
                   view,
                   stateConds,
                   string.Empty
                 );
            fld_dgcEmrRelationSelections.DataSource = ds.Tables[0];
            fld_dgcEmrRelationSelections.RefreshDataSource();
        }

        private void guiSelectEmrRelation_Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                Ok();
            }
        }

        private void guiSelectEmrRelation_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void guiSelectEmrRelation_btnOk_Click(object sender, EventArgs e)
        {
            Ok();
        }

        public void Ok()
        {
            var grid = (fld_dgcEmrRelationSelections.MainView as GridView);
            if (grid.FocusedRowHandle >= 0)
            {
                var row = grid.GetDataRow(grid.FocusedRowHandle) as DataRow;
                if (row == null)
                {
                    MessageBox.Show("Vui lòng kiểm tra dữ liệu trên lưới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.SelectedEmrID = 0;
                this.SelectedEmrNo = row["MEEmrNo"].ToString();
                if (row["MEEmrID"] != null)
                {
                    this.SelectedEmrID = Convert.ToInt32(row["MEEmrID"].ToString());
                }
                var entity = ((MEEmrModule)Module).CurrentModuleEntity as MEEmrEntities;
                var currentEmr = entity.MainObject as MEEmrsInfo;
                if (currentEmr.MEEmrID == SelectedEmrID)
                {
                    MessageBox.Show($"Bệnh án trùng nhau, không thể liên kết. Vui lòng chọn bệnh án khác!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (currentEmr.MEEmrNo == SelectedEmrNo)
                {
                    MessageBox.Show($"Bệnh án trùng nhau, không thể liên kết. Vui lòng chọn bệnh án khác!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.SelectedEmrRelationFromName = guiPatientRelation_fld_lkeMEEmrRelationName.EditValue.ToString();
                this.SelectedEmrRelationToName = guiSelectEmrRelation_fld_lkeMEEmrRelationToName.EditValue.ToString();
                if (string.IsNullOrEmpty(SelectedEmrRelationFromName))
                {
                    MessageBox.Show("Vui lòng chọn Mối quan hệ Bệnh án hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(SelectedEmrRelationToName))
                {
                    MessageBox.Show("Vui lòng chọn Mối quan hệ Bệnh án liên kết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (SelectedEmrRelationFromName == SelectedEmrRelationToName)
                {
                    MessageBox.Show("Vui lòng chọn 2 loại quan hệ khác nhau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bệnh án " + SelectedEmrNo + " sẽ được liên kết vào bệnh án đang soạn." +
                    "\nChấp nhận liên kết? ", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    return;

                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Bệnh án liên kết trên lưới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
