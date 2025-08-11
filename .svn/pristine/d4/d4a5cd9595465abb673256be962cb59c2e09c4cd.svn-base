using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using BOSERP.Modules.MEEmr.UI;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using BOSCommon;
using BOSERP.UI;
using BOSLib;

namespace BOSERP.Modules.MEEmrManage.UI
{
    /// <summary>
    /// Summary description for DMMEEMR101
    /// </summary>
    public partial class DMEMRMAN03 : BOSERPScreen
    {
        public DMEMRMAN03()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            this.chkSearchByPatient.CheckedChanged += new System.EventHandler(this.chkSearchByPatient_CheckedChanged);
        }
        public override void InitializeScreen(STScreensInfo objStScreensInfo)
        {
            base.InitializeScreen(objStScreensInfo);
            fld_ccbeFK_HRDepartmentID.EditValue = (BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID.ToString());
            fld_cmbChooseView.SelectedIndex = 0;
        }
        private void fld_cmbChooseView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBoxEdit)sender;
            var start = DateTime.Now;
            switch (cb.SelectedIndex)
            {
                case 0: //trong ngay
                    fld_dteSearchFromMEEmrCreatedDate.EditValue = DateTime.Now.Date;
                    fld_dteSearchToMEEmrCreatedDate.EditValue = DateTime.Now.Date.AddHours(24).AddMilliseconds(-1);
                    break;
                case 1: //trong tuan
                    start = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                    fld_dteSearchFromMEEmrCreatedDate.EditValue = start;
                    fld_dteSearchToMEEmrCreatedDate.EditValue = start.AddDays(7).AddMilliseconds(-1);
                    break;
                case 2: //trong thang
                    start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                    fld_dteSearchFromMEEmrCreatedDate.EditValue = start;
                    fld_dteSearchToMEEmrCreatedDate.EditValue = start.AddMonths(1).AddMilliseconds(-1);
                    break;
                case 3: //trong nam
                    start = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
                    fld_dteSearchFromMEEmrCreatedDate.EditValue = start;
                    fld_dteSearchToMEEmrCreatedDate.EditValue = start.AddMonths(12).AddMilliseconds(-1);
                    break;
                case 4: //tat ca
                    fld_dteSearchFromMEEmrCreatedDate.EditValue = DateTime.MaxValue;// new DateTime(2005, 1, 1, 0, 0, 0);
                    fld_dteSearchToMEEmrCreatedDate.EditValue = DateTime.MaxValue;// new DateTime(2999, 1, 1, 0, 0, 0);
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
                this.SearchPatient(fld_txtMEPatientNo.Text);
            else
            {
                fld_txtMEPatientNo.Text = string.Empty;
                fld_lkeFK_MEPatientID.EditValue = 0;
                fld_txtMEPatientName.Text = string.Empty;
            }
        }
        private void ChangeControlsState(bool enable)
        {
            fld_ccbeFK_HRDepartmentID.Enabled = enable;
            fld_cmbChooseView.Enabled = enable;
            fld_dteSearchFromMEEmrCreatedDate.Enabled = enable;
            fld_dteSearchToMEEmrCreatedDate.Enabled = enable;
            fld_txtMEEmrNoMAN03.Enabled = enable;
            fld_lkeFK_MEEmrTypeIDMAN03.Enabled = enable;
            chkDepartmentShared.Enabled = enable;
            fld_txtMEPatientNo.Enabled = !enable;
            fld_lkeFK_MEPatientID.Enabled = !enable;
        }
        private void SearchPatient(string text)
        {
            var gui = new guiSearchPatient(text)
            {
                Module = this.Module,
                StartPosition = FormStartPosition.CenterParent
            };
            if (gui.ShowDialog() == DialogResult.OK)
            {
                fld_lkeFK_MEPatientID.EditValue = gui.Patient.MEPatientID;
                fld_txtMEPatientNo.Text = gui.Patient.MEPatientNo;
                fld_txtMEPatientName.Text = gui.Patient.MEPatientName;
            }
        }
        private void chkDepartmentShared_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDepartmentShared.Checked)
            {
                var dt = fld_ccbeFK_HRDepartmentID.DataSource as DataTable;
                var shares = new List<int>();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["HRDepartmentEmrShared"].ToString() == "True")
                    {
                        shares.Add(int.Parse(row["HRDepartmentID"].ToString()));
                    }
                }
                fld_ccbeFK_HRDepartmentID.EditValue = (string.Join(", ", shares));
            }
            else
                fld_ccbeFK_HRDepartmentID.EditValue = (BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID.ToString());
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (chkSearchByPatient.Checked)
            {
                SearchByPatient();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;

            var hrDeparment = fld_ccbeFK_HRDepartmentID.EditValue.ToString();
            var fromDate = ((DateTime)fld_dteSearchFromMEEmrCreatedDate.EditValue).Year == DateTime.MaxValue.Year ? new DateTime(2005, 1, 1, 0, 0, 0) : ((DateTime)fld_dteSearchFromMEEmrCreatedDate.EditValue).Date;
            var toDate = ((DateTime)fld_dteSearchToMEEmrCreatedDate.EditValue).Year == DateTime.MaxValue.Year ? DateTime.MaxValue : ((DateTime)fld_dteSearchToMEEmrCreatedDate.EditValue).Date.AddDays(1).AddMilliseconds(-1);
            var emrNo = fld_txtMEEmrNoMAN03.Text;
            var emrType = fld_lkeFK_MEEmrTypeIDMAN03.EditValue;
            var no = fld_txtMEEmrSumNoMAN03.EditValue;
            var noStore = fld_txtMEEmrSumStoreNoMAN03.EditValue;
            var status = (bool)chkMEEmrSumStatusMAN03.EditValue ? EmrSumStatus.Hide.ToString() : EmrSumStatus.Active.ToString();
            (this.Module as MEEmrManageModule).SearchTTBA(
                        hrDeparment,
                        fromDate,
                        toDate,
                        emrNo,
                        emrType,
                        no,
                        noStore,
                        status
               );

            Cursor.Current = Cursors.Default;
        }
        private void SearchByPatient()
        {
            if (fld_lkeFK_MEPatientID.EditValue != null && fld_lkeFK_MEPatientID.EditValue?.ToString() != "0")
            {
                (this.Module as MEEmrManageModule).SearchByPatientTTBA(fld_lkeFK_MEPatientID.EditValue);
                return;
            }
            MessageBox.Show("Vui lòng nhập chọn một bệnh nhân", "CHƯA CHỌN BỆNH NHÂN", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        private void fld_lkeFK_MEPatientID_EditValueChanged_1(object sender, EventArgs e)
        {
            if (chkSearchByPatient.Checked && fld_lkeFK_MEPatientID.EditValue?.ToString() != "0")
            {
                SearchByPatient();
            }
        }

        private void fld_txtMEPatientNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && chkSearchByPatient.Checked)
            {
                this.SearchPatient(fld_txtMEPatientNo.Text);
            }
        }
    }
}
