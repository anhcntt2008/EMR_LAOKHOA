using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using BOSERP.UI;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for SRMEPV100
    /// </summary>
    public partial class SQMEEMR100 : BOSERPScreen
    {

        public SQMEEMR100()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
        }
        public override Control InitializeControl(Control ctrl)
        {
            var ctr = base.InitializeControl(ctrl);

            return ctr;
        }

        private void fld_cmbChooseView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBoxEdit)sender;
            var start = DateTime.Now;
            cb.Width = 78;
            cb.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            switch (cb.SelectedIndex)
            {
                case 0: //trong ngay
                    fld_dteSearchFromMEEmrCreatedDate.EditValue = DateTime.Now.Date;
                    fld_dteSearchToMEEmrCreatedDate.EditValue = DateTime.Now.Date.AddHours(24).AddMilliseconds(-1);
                    break;
                case 1: //trong 7 ngay
                    fld_dteSearchFromMEEmrCreatedDate.EditValue = DateTime.Now.Date.AddDays(-7);
                    fld_dteSearchToMEEmrCreatedDate.EditValue = DateTime.Now.Date;
                    break;
                case 2: //trong 30 ngay
                    fld_dteSearchFromMEEmrCreatedDate.EditValue = DateTime.Now.Date.AddDays(-30);
                    fld_dteSearchToMEEmrCreatedDate.EditValue = DateTime.Now.Date;
                    break;
                case 3: //trong tuan
                    start = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                    fld_dteSearchFromMEEmrCreatedDate.EditValue = start;
                    fld_dteSearchToMEEmrCreatedDate.EditValue = start.AddDays(7).AddMilliseconds(-1);
                    break;
                case 4: //trong thang
                    start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                    fld_dteSearchFromMEEmrCreatedDate.EditValue = start;
                    fld_dteSearchToMEEmrCreatedDate.EditValue = start.AddMonths(1).AddMilliseconds(-1);
                    break;
                case 5: //trong nam
                    start = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
                    fld_dteSearchFromMEEmrCreatedDate.EditValue = start;
                    fld_dteSearchToMEEmrCreatedDate.EditValue = start.AddMonths(12).AddMilliseconds(-1);
                    break;
                case 6: //Tu ngay den ngay
                    fld_dteSearchFromMEEmrCreatedDate.Focus();
                    fld_dteSearchFromMEEmrCreatedDate.SelectAll();
                    break;
                case 7: //tat ca
                    fld_dteSearchFromMEEmrCreatedDate.EditValue = new DateTime(2015, 1, 1, 0, 0, 0);
                    fld_dteSearchToMEEmrCreatedDate.EditValue = DateTime.Now.AddDays(1).Date;
                    cb.Width = fld_dteSearchToMEEmrCreatedDate.Location.X + fld_dteSearchToMEEmrCreatedDate.Width - cb.Location.X;
                    cb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    break;
                default:
                    break;
            }
        }


        private void fld_lkeFK_MEPatientID_QueryCloseUp(object sender, CancelEventArgs e)
        {

        }

        private void fld_lkeFK_MEPatientID_EditValueChanged_1(object sender, EventArgs e)
        {
            //if (chkSearchByPatient.Checked)
            //    (this.Module as BaseModuleERP).QuickSearch();
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
        private void chkSearchByPatient_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckEdit)sender;
            var chked = chk.Checked;
            chkSearchByEmrCode.Checked = false;
            chkSearchByShare.Checked = false;
            chkUserAssigned.Checked = false;
            ChangeStateAllControl();
            chk.Checked = chked;
            if (chked)
            {
                fld_txtMEPatientNo1.Focus();
                fld_txtMEPatientNo1.SelectAll();
                //this.SearchPatient(fld_txtMEPatientNo1.Text);
            }
        }

        private void chkSearchByEmrCode_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckEdit)sender;
            var chked = chk.Checked;
            chkSearchByPatient.Checked = false;
            chkSearchByShare.Checked = false;
            chkUserAssigned.Checked = false;
            ChangeStateAllControl();
            chk.Checked = chked;
            if (chked)
            {
                fld_txtMEEmrNo.Focus();
                fld_txtMEEmrNo.SelectAll();
            }
        }
        private void chkSearchByShare_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckEdit)sender;
            var chked = chk.Checked;
            chkSearchByEmrCode.Checked = false;
            chkSearchByPatient.Checked = false;
            chkUserAssigned.Checked = false;
            ChangeStateAllControl();
            chk.Checked = chked;
            if (chked)
            {
                fld_cmbChooseShare.Focus();
            }
        }
        private void chkUserAssigned_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckEdit)sender;
            var chked = chk.Checked;
            chkSearchByEmrCode.Checked = false;
            chkSearchByPatient.Checked = false;
            chkSearchByShare.Checked = false;
            ChangeStateAllControl();
            chk.Checked = chked;
        }
        private void ChangeStateAllControl()
        {
            var state = !(chkSearchByEmrCode.Checked || chkSearchByPatient.Checked || chkSearchByShare.Checked || chkUserAssigned.Checked);
            fld_ccbeFK_HRDepartmentID.Enabled = state;
            chkDepartmentShared.Enabled = state;
            fld_cmbChooseView.Enabled = state;
            fld_dteSearchFromMEEmrCreatedDate.Enabled = state;
            fld_dteSearchToMEEmrCreatedDate.Enabled = state;

            fld_txtMEEmrNo.Enabled = chkSearchByEmrCode.Checked;

            fld_lkeFK_MEPatientID.Enabled = chkSearchByPatient.Checked;
            fld_txtMEPatientNo1.Enabled = chkSearchByPatient.Checked;

            fld_cmbChooseShare.Enabled = chkSearchByShare.Checked;

            //chkSearchByPatient.Enabled = state;
            //chkSearchByShare.Enabled = state;
            //chkSearchByEmrCode.Enabled = state;
        }

        private void fld_txtMEEmrNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && chkSearchByEmrCode.Checked)
                (this.Module as BaseModuleERP).QuickSearch();
        }

        private void fld_cmbChooseShare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkSearchByShare.Checked)
                (this.Module as BaseModuleERP).QuickSearch();
        }

        private void fld_txtMEPatientNo1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && chkSearchByPatient.Checked)
                this.SearchPatient(fld_txtMEPatientNo1.Text);
        }
        private void SearchPatient(string text)
        {
            var gui = new guiSearchPatient(text);
            gui.Module = this.Module;
            gui.StartPosition = FormStartPosition.CenterParent;
            if (gui.ShowDialog() == DialogResult.OK)
            {
                fld_lkeFK_MEPatientID.EditValue = gui.Patient.MEPatientID;
                fld_txtMEPatientNo1.Text = gui.Patient.MEPatientNo;
                fld_txtMEPatientName1.Text = gui.Patient.MEPatientName;

                (this.Module as BaseModuleERP).QuickSearch();
            }
        }

        private void fld_dteSearchFromMEEmrCreatedDate_QueryCloseUp(object sender, CancelEventArgs e)
        {
            fld_cmbChooseView.Text = string.Empty;
        }

        private void fld_dteSearchToMEEmrCreatedDate_QueryCloseUp(object sender, CancelEventArgs e)
        {
            fld_cmbChooseView.Text = string.Empty;
        }

        private void fld_dteSearchFromMEEmrCreatedDate_KeyUp(object sender, KeyEventArgs e)
        {
            fld_cmbChooseView.Text = string.Empty;
        }

        private void fld_dteSearchToMEEmrCreatedDate_KeyUp(object sender, KeyEventArgs e)
        {
            fld_cmbChooseView.Text = string.Empty;
        }

        private void pnlQuickSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
