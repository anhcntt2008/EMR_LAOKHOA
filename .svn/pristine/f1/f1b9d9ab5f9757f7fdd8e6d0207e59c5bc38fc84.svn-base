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
using BOSComponent;
using Clas.Model.Middle;

namespace BOSERP.Modules.MEDocumentBackground.UI
{
    /// <summary>
    /// Summary description for DMMEEMR101
    /// </summary>
    public partial class DMEMRDOCBGSIGN02 : BOSERPScreen
    {
        public DMEMRDOCBGSIGN02()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            this.chkMdAutoSignDocumentSearchByPatient.CheckedChanged += new System.EventHandler(this.chkMdAutoSignDocumentSearchByPatient_CheckedChanged);
        }
        public override void InitializeScreen(STScreensInfo objStScreensInfo)
        {
            base.InitializeScreen(objStScreensInfo);
            fld_cmbMdAutoSignDocumentChooseView.SelectedIndex = 0;
        }
        private void fld_cmbMdAutoSignDocumentChooseView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBoxEdit)sender;
            var start = DateTime.Now;
            switch (cb.SelectedIndex)
            {
                case 0: //trong ngay
                    fld_dteMdAutoSignDocumentSearchFromCreatedDate.EditValue = DateTime.Now.Date;
                    fld_dteMdAutoSignDocumentSearchToCreatedDate.EditValue = DateTime.Now.Date.AddHours(24).AddMilliseconds(-1);
                    break;
                case 1: //trong tuan
                    start = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                    fld_dteMdAutoSignDocumentSearchFromCreatedDate.EditValue = start;
                    fld_dteMdAutoSignDocumentSearchToCreatedDate.EditValue = start.AddDays(7).AddMilliseconds(-1);
                    break;
                case 2: //trong thang
                    start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                    fld_dteMdAutoSignDocumentSearchFromCreatedDate.EditValue = start;
                    fld_dteMdAutoSignDocumentSearchToCreatedDate.EditValue = start.AddMonths(1).AddMilliseconds(-1);
                    break;
                case 3: //trong nam
                    start = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
                    fld_dteMdAutoSignDocumentSearchFromCreatedDate.EditValue = start;
                    fld_dteMdAutoSignDocumentSearchToCreatedDate.EditValue = start.AddMonths(12).AddMilliseconds(-1);
                    break;
                case 4: //tat ca
                    fld_dteMdAutoSignDocumentSearchFromCreatedDate.EditValue = DateTime.MaxValue;// new DateTime(2005, 1, 1, 0, 0, 0);
                    fld_dteMdAutoSignDocumentSearchToCreatedDate.EditValue = DateTime.MaxValue;// new DateTime(2999, 1, 1, 0, 0, 0);
                    break;
                default:
                    break;
            }
        }
        private void chkMdAutoSignDocumentSearchByPatient_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckEdit)sender;
            ChangeControlsState(!chk.Checked);
            if (chk.Checked)
                this.SearchPatient(fld_txtMdAutoSignDocumentPatientNo.Text);
            else
            {
                fld_txtMdAutoSignDocumentPatientNo.Text = string.Empty;
                fld_lkeFK_MEPatientID.EditValue = 0;
                fld_txtMdAutoSignDocumentPatientName.Text = string.Empty;
            }
        }
        private void ChangeControlsState(bool enable)
        {
            fld_lkeMdAutoSignDocumentsStatus.Enabled = enable;
            fld_cmbMdAutoSignDocumentChooseView.Enabled = enable;
            fld_dteMdAutoSignDocumentSearchFromCreatedDate.Enabled = enable;
            fld_dteMdAutoSignDocumentSearchToCreatedDate.Enabled = enable;

            fld_txtMdAutoSignDocumentEmrNo.Enabled = enable;
            fld_txtMdAutoSignDocumentPatientNo.Enabled = !enable;
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
                fld_txtMdAutoSignDocumentPatientNo.Text = gui.Patient.MEPatientNo;
                fld_txtMdAutoSignDocumentPatientName.Text = gui.Patient.MEPatientName;
            }
        }
        private void btnMdAutoSignDocumentSearch_Click(object sender, EventArgs e)
        {
            if (chkMdAutoSignDocumentSearchByPatient.Checked)
            {
                SearchByPatient();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;

            (this.Module as MEDocumentBackgroundModule).MdAutoSignDocumentsSearch(
                fld_txtMdAutoSignDocumentEmrNo.Text,
                fld_lkeMdAutoSignDocumentsStatus.EditValue,
                ((DateTime)fld_dteMdAutoSignDocumentSearchFromCreatedDate.EditValue).Year == DateTime.MaxValue.Year
                   ? new DateTime(2005, 1, 1, 0, 0, 0)
                   : ((DateTime)fld_dteMdAutoSignDocumentSearchFromCreatedDate.EditValue).Date,
               ((DateTime)fld_dteMdAutoSignDocumentSearchToCreatedDate.EditValue).Year == DateTime.MaxValue.Year
                   ? DateTime.MaxValue
                   : ((DateTime)fld_dteMdAutoSignDocumentSearchToCreatedDate.EditValue).Date.AddDays(1).AddMilliseconds(-1)
               );

            Cursor.Current = Cursors.Default;
        }
        private void SearchByPatient()
        {
            (this.Module as MEDocumentBackgroundModule).MdAutoSignDocumentsSearchByPatient(fld_lkeFK_MEPatientID.EditValue);
        }
        private void fld_lkeFK_MEPatientID_EditValueChanged_1(object sender, EventArgs e)
        {
            if (chkMdAutoSignDocumentSearchByPatient.Checked && fld_lkeFK_MEPatientID.EditValue?.ToString() != "0")
            {
                SearchByPatient();
            }
        }

        private void fld_txtMEPatientNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && chkMdAutoSignDocumentSearchByPatient.Checked)
            {
                this.SearchPatient(fld_txtMdAutoSignDocumentPatientNo.Text);
            }
        }

        private void btnMdAutoSignDocumentCreate_Click(object sender, EventArgs e)
        {
            (this.Module as MEDocumentBackgroundModule).MdAutoSignDocumentsRunAgain();
        }
    }
}
