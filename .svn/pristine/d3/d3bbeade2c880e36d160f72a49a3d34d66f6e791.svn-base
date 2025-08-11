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
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiSelectEmr : BOSERPScreen
    {
        private readonly MEEmrsController _emrCtrl;
        public int SelectedEmrID { get; private set; }

        public guiSelectEmr()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            _emrCtrl = new MEEmrsController();
        }
        private void Ok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.O)
            {
                Ok();
            }
        }
        private void fld_cmbChooseView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBoxEdit)sender;
            var start = DateTime.Now;
            switch (cb.SelectedIndex)
            {
                case 0: //trong ngay
                    guiSelectEmr_fld_dteSearchFromMEEmrCreatedDate.EditValue = DateTime.Now.Date;
                    guiSelectEmr_fld_dteSearchToMEEmrCreatedDate.EditValue = DateTime.Now.Date.AddHours(24).AddMilliseconds(-1);
                    break;
                case 1: //trong tuan
                    start = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                    guiSelectEmr_fld_dteSearchFromMEEmrCreatedDate.EditValue = start;
                    guiSelectEmr_fld_dteSearchToMEEmrCreatedDate.EditValue = start.AddDays(7).AddMilliseconds(-1);
                    break;
                case 2: //trong thang
                    start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                    guiSelectEmr_fld_dteSearchFromMEEmrCreatedDate.EditValue = start;
                    guiSelectEmr_fld_dteSearchToMEEmrCreatedDate.EditValue = start.AddMonths(1).AddMilliseconds(-1);
                    break;
                case 3: //trong nam
                    start = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
                    guiSelectEmr_fld_dteSearchFromMEEmrCreatedDate.EditValue = start;
                    guiSelectEmr_fld_dteSearchToMEEmrCreatedDate.EditValue = start.AddMonths(12).AddMilliseconds(-1);
                    break;
                case 4: //tat ca
                    guiSelectEmr_fld_dteSearchFromMEEmrCreatedDate.EditValue = new DateTime(2005, 1, 1, 0, 0, 0);
                    guiSelectEmr_fld_dteSearchToMEEmrCreatedDate.EditValue = new DateTime(2999, 1, 1, 0, 0, 0);
                    break;
                default:
                    break;
            }
        }

        private void chkSearchByPatient_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckEdit)sender;
            ChangeControlsState(!chk.Checked);
            if (chk.Checked)
                this.SearchPatient(guiSelectEmr_fld_txtMEPatientNo.Text);
            else
            {
                guiSelectEmr_fld_txtMEPatientNo.Text = string.Empty;
                fld_lkeFK_MEPatientID.EditValue = 0;
                guiSelectEmr_fld_txtMEPatientName.Text = string.Empty;
            }
        }
        private void ChangeControlsState(bool enable)
        {
            guiSelectEmr_fld_ccbeFK_HRDepartmentID.Enabled = enable;
            guiSelectEmr_fld_cmbChooseView.Enabled = enable;
            guiSelectEmr_fld_dteSearchFromMEEmrCreatedDate.Enabled = enable;
            guiSelectEmr_fld_dteSearchToMEEmrCreatedDate.Enabled = enable;
            guiSelectEmr_fld_txtMEEmrNo.Enabled = enable;
            guiSelectEmr_fld_lkeFK_MEEmrTypeID.Enabled = enable;
            guiSelectEmr_chkDepartmentShared.Enabled = enable;
            guiSelectEmr_fld_txtMEPatientNo.Enabled = !enable;
            fld_lkeFK_MEPatientID.Enabled = !enable;
        }
        private void SearchPatient(string text)
        {
            var gui = new guiSearchPatient(text);
            gui.Module = this.Module;
            gui.StartPosition = FormStartPosition.CenterParent;
            if (gui.ShowDialog() == DialogResult.OK)
            {
                fld_lkeFK_MEPatientID.EditValue = gui.Patient.MEPatientID;
                guiSelectEmr_fld_txtMEPatientNo.Text = gui.Patient.MEPatientNo;
                guiSelectEmr_fld_txtMEPatientName.Text = gui.Patient.MEPatientName;
            }
        }
        private void chkDepartmentShared_CheckedChanged(object sender, EventArgs e)
        {
            if (guiSelectEmr_chkDepartmentShared.Checked)
            {
                var dt = guiSelectEmr_fld_ccbeFK_HRDepartmentID.DataSource as DataTable;
                var shares = new List<int>();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["HRDepartmentEmrShared"].ToString() == "True")
                    {
                        shares.Add(int.Parse(row["HRDepartmentID"].ToString()));
                    }
                }
                guiSelectEmr_fld_ccbeFK_HRDepartmentID.EditValue = (string.Join(", ", shares));
            }
            else
                guiSelectEmr_fld_ccbeFK_HRDepartmentID.EditValue = (BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID.ToString());
        }
        public void Ok()
        {
            var grid = (fld_dgcEmrSelections.MainView as GridView);
            if (grid.FocusedRowHandle >= 0)
            {
                var row = grid.GetDataRow(grid.FocusedRowHandle) as DataRow;
                if (row["MEEmrStatus"].ToString() == EmrStatus.Closed.ToString())
                {
                    MessageBox.Show("Bệnh án được chọn đã đóng. Không thể thực hiện thao tác này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Bệnh án " + row["MEEmrNo"].ToString() + " sẽ được trộn vào bệnh án đang soạn." +
                    "\nSau khi trộn thành công BỆNH ÁN " + row["MEEmrNo"].ToString() + " sẽ bị XÓA." +
                    "\nChấp nhận trộn? ", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    return;
                this.SelectedEmrID = int.Parse(row["MEEmrID"].ToString());
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.InitializeControls(this.Controls);
            guiSelectEmr_fld_ccbeFK_HRDepartmentID.EditValue = (BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID.ToString());
            guiSelectEmr_fld_cmbChooseView.SelectedIndex = 0;

            var entity = (Module as BaseModuleERP).CurrentModuleEntity as MEEmrEntities;
            fld_lkeFK_MEPatientID.EditValue = entity.MEPatient.MEPatientID;
            guiSelectEmr_fld_txtMEPatientNo.Text = entity.MEPatient.MEPatientNo;
            guiSelectEmr_fld_txtMEPatientName.Text = entity.MEPatient.MEPatientName;
            guiSelectEmr_chkSearchByPatient.Checked = true;
            SearchByPatient();
            ChangeControlsState(false);
            this.guiSelectEmr_chkSearchByPatient.CheckedChanged += new System.EventHandler(this.chkSearchByPatient_CheckedChanged);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (guiSelectEmr_chkSearchByPatient.Checked)
            {
                SearchByPatient();
                return;
            }
            var view = string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserEmrView) ? BOSApp.CurrentUserGroupInfo.ADUserGroupEmrView : BOSApp.CurrentUsersInfo.ADUserEmrView;
            Cursor.Current = Cursors.WaitCursor;
            var department = guiSelectEmr_fld_ccbeFK_HRDepartmentID.EditValue.ToString();
            //department = ", " + department + ", ";
            department = department.Replace(", " + BOSApp.CurrentEmployeesInfo.FK_HRDepartmentRoomID + ", ", ", ");
            var fromDate = ((DateTime)guiSelectEmr_fld_dteSearchFromMEEmrCreatedDate.EditValue).Date;
            var toDate = ((DateTime)guiSelectEmr_fld_dteSearchToMEEmrCreatedDate.EditValue).Date.AddDays(1).AddMilliseconds(-1);
            // 1523 Đã ký CA
            var mEEmrArchiveStatus = 0;
            if (BOSApp.CurrentUserGroupInfo.ADUserGroupRole == UserGroupRole.admin.ToString())
            {
                mEEmrArchiveStatus = 1;
            }
            var stateConds = (this.Module as BaseModuleERP).GetStatePermiQueryConditionStr(TableName.MEEmrsTableName, false);

            var patientGroup = string.Empty;
            DateTime? fromDateOut = null;
            DateTime? toDateOut = null;

            object[] paramValues = new object[]
            {
                     guiSelectEmr_fld_txtMEEmrNo.Text,
                     EmrStatus.InProgress.ToString(),
                    fromDate,
                     toDate,
                     null,
                     guiSelectEmr_fld_lkeFK_MEEmrTypeID.EditValue,
                     patientGroup,
                     fromDateOut,
                     toDateOut,
                     department,
                     BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID,
                     BOSApp.CurrentEmployeesInfo.HREmployeeID,
                     mEEmrArchiveStatus,
                     view,
                     stateConds
            };
            var ds = _emrCtrl.Search(paramValues);
            fld_dgcEmrSelections.DataSource = ds.Tables[0];
            fld_dgcEmrSelections.RefreshDataSource();

            Cursor.Current = Cursors.Default;
        }
        private void SearchByPatient()
        {
            var view = string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserEmrView) ? BOSApp.CurrentUserGroupInfo.ADUserGroupEmrView : BOSApp.CurrentUsersInfo.ADUserEmrView;
            var stateConds = (this.Module as BaseModuleERP).GetStatePermiQueryConditionStr(TableName.MEEmrsTableName, false);

            var mEEmrArchiveStatus = 0;
            if (BOSApp.CurrentUserGroupInfo.ADUserGroupRole == UserGroupRole.admin.ToString())
            {
                mEEmrArchiveStatus = 1;
            }

            var ds = _emrCtrl.QuickSearchWithOneCriteria(null,
                   fld_lkeFK_MEPatientID.EditValue,
                   BOSApp.CurrentEmployeesInfo.HREmployeeID,
                   BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID,
                   EmrStatus.InProgress.ToString(),
                   mEEmrArchiveStatus,
                   view,
                   stateConds,
                   string.Empty
                 );
            fld_dgcEmrSelections.DataSource = ds.Tables[0];
            fld_dgcEmrSelections.RefreshDataSource();
        }
        private void fld_lkeFK_MEPatientID_EditValueChanged_1(object sender, EventArgs e)
        {
            if (guiSelectEmr_chkSearchByPatient.Checked && fld_lkeFK_MEPatientID.EditValue?.ToString() != "0")
            {
                SearchByPatient();
            }
        }

        private void fld_txtMEPatientNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && guiSelectEmr_chkSearchByPatient.Checked)
            {
                this.SearchPatient(guiSelectEmr_fld_txtMEPatientNo.Text);
            }
        }
    }
}
