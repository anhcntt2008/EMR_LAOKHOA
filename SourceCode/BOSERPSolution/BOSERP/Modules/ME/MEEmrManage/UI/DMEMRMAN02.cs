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
    public partial class DMEMRMAN02 : BOSERPScreen
    {
        public DMEMRMAN02()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            this.chkHistorySearchByPatient.CheckedChanged += new System.EventHandler(this.chkHistorySearchByPatient_CheckedChanged);
        }
        public override void InitializeScreen(STScreensInfo objStScreensInfo)
        {
            base.InitializeScreen(objStScreensInfo);
            fld_cmbMAN02ChooseView.SelectedIndex = 0;
        }

        private void chkHistorySearchByPatient_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckEdit)sender;
            ChangeControlsState(!chk.Checked);
            if (chk.Checked)
                this.HistorySearchByPatient(fld_txtMEPatientNo.Text);
            else
            {
                fld_txtMEPatientNo.Text = string.Empty;
                fld_lkeFK_MEPatientID.EditValue = 0;
                fld_txtMEPatientName.Text = string.Empty;
            }
        }
        private void ChangeControlsState(bool enable)
        {
            fld_cmbMAN02ChooseView.Enabled = enable;
            fld_dteMAN02SearchFromMEEmrCreatedDate.Enabled = enable;
            fld_dteMAN02SearchToMEEmrCreatedDate.Enabled = enable;
            fld_txtMAN02MEEmrNo.Enabled = enable;
            fld_txtMEPatientNo.Enabled = !enable;
            fld_lkeFK_MEPatientID.Enabled = !enable;
            fld_lkeObjectHistoryAction.Enabled = enable;
        }
        private void HistorySearchByPatient(string text)
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
        private void HistorySearchByPatient()
        {
            if (fld_lkeFK_MEPatientID.EditValue != null && fld_lkeFK_MEPatientID.EditValue?.ToString() != "0")
            {
                (this.Module as MEEmrManageModule).HistorySearchByPatient(fld_lkeFK_MEPatientID.EditValue);
                return;
            }
            MessageBox.Show("Vui lòng nhập chọn một bệnh nhân", "CHƯA CHỌN BỆNH NHÂN", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        private void fld_lkeFK_MEPatientID_EditValueChanged_1(object sender, EventArgs e)
        {
            if (chkHistorySearchByPatient.Checked && fld_lkeFK_MEPatientID.EditValue?.ToString() != "0")
            {
                HistorySearchByPatient();
            }
        }

        private void fld_txtMEPatientNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && chkHistorySearchByPatient.Checked)
            {
                this.HistorySearchByPatient(fld_txtMEPatientNo.Text);
            }
        }

        private void btnHistorySearch_Click(object sender, EventArgs e)
        {
            if (chkHistorySearchByPatient.Checked)
            {
                HistorySearchByPatient();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;

            (this.Module as MEEmrManageModule).HistorySearch(
                ((DateTime)fld_dteMAN02SearchFromMEEmrCreatedDate.EditValue).Year == DateTime.MaxValue.Year
                   ? new DateTime(2005, 1, 1, 0, 0, 0)
                   : ((DateTime)fld_dteMAN02SearchFromMEEmrCreatedDate.EditValue).Date,
               ((DateTime)fld_dteMAN02SearchToMEEmrCreatedDate.EditValue).Year == DateTime.MaxValue.Year
                   ? DateTime.MaxValue
                   : ((DateTime)fld_dteMAN02SearchToMEEmrCreatedDate.EditValue).Date.AddDays(1).AddMilliseconds(-1),
               fld_txtMAN02MEEmrNo.Text,
               fld_lkeObjectHistoryAction.EditValue == null? string.Empty: fld_lkeObjectHistoryAction.EditValue.ToString());

            Cursor.Current = Cursors.Default;
        }

        private void fld_cmbMAN02ChooseView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBoxEdit)sender;
            var start = DateTime.Now;
            switch (cb.SelectedIndex)
            {
                case 0: //trong ngay
                    fld_dteMAN02SearchFromMEEmrCreatedDate.EditValue = DateTime.Now.Date;
                    fld_dteMAN02SearchToMEEmrCreatedDate.EditValue = DateTime.Now.Date.AddHours(24).AddMilliseconds(-1);
                    break;
                case 1: //trong tuan
                    start = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                    fld_dteMAN02SearchFromMEEmrCreatedDate.EditValue = start;
                    fld_dteMAN02SearchToMEEmrCreatedDate.EditValue = start.AddDays(7).AddMilliseconds(-1);
                    break;
                case 2: //trong thang
                    start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                    fld_dteMAN02SearchFromMEEmrCreatedDate.EditValue = start;
                    fld_dteMAN02SearchToMEEmrCreatedDate.EditValue = start.AddMonths(1).AddMilliseconds(-1);
                    break;
                case 3: //trong nam
                    start = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
                    fld_dteMAN02SearchFromMEEmrCreatedDate.EditValue = start;
                    fld_dteMAN02SearchToMEEmrCreatedDate.EditValue = start.AddMonths(12).AddMilliseconds(-1);
                    break;
                case 4: //tat ca
                    fld_dteMAN02SearchFromMEEmrCreatedDate.EditValue = DateTime.MaxValue;// new DateTime(2005, 1, 1, 0, 0, 0);
                    fld_dteMAN02SearchToMEEmrCreatedDate.EditValue = DateTime.MaxValue;// new DateTime(2999, 1, 1, 0, 0, 0);
                    break;
                default:
                    break;
            }
        }
    }
}
