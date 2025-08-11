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
    public partial class DMEMRDOCBGCREATE01 : BOSERPScreen
    {
        public DMEMRDOCBGCREATE01()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            this.chkMdAutoGenDocumentSearchByPatient.CheckedChanged += new System.EventHandler(this.chkMdAutoGenDocumentSearchByPatient_CheckedChanged);
        }
        public override void InitializeScreen(STScreensInfo objStScreensInfo)
        {
            base.InitializeScreen(objStScreensInfo);
            fld_cmbMdAutoGenDocumentChooseView.SelectedIndex = 0;
        }
        private void fld_cmbMdAutoGenDocumentChooseView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBoxEdit)sender;
            var start = DateTime.Now;
            switch (cb.SelectedIndex)
            {
                case 0: //trong ngay
                    fld_dteMdAutoGenDocumentSearchFromCreatedDate.EditValue = DateTime.Now.Date;
                    fld_dteMdAutoGenDocumentSearchToCreatedDate.EditValue = DateTime.Now.Date.AddHours(24).AddMilliseconds(-1);
                    break;
                case 1: //trong tuan
                    start = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                    fld_dteMdAutoGenDocumentSearchFromCreatedDate.EditValue = start;
                    fld_dteMdAutoGenDocumentSearchToCreatedDate.EditValue = start.AddDays(7).AddMilliseconds(-1);
                    break;
                case 2: //trong thang
                    start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                    fld_dteMdAutoGenDocumentSearchFromCreatedDate.EditValue = start;
                    fld_dteMdAutoGenDocumentSearchToCreatedDate.EditValue = start.AddMonths(1).AddMilliseconds(-1);
                    break;
                case 3: //trong nam
                    start = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
                    fld_dteMdAutoGenDocumentSearchFromCreatedDate.EditValue = start;
                    fld_dteMdAutoGenDocumentSearchToCreatedDate.EditValue = start.AddMonths(12).AddMilliseconds(-1);
                    break;
                case 4: //tat ca
                    fld_dteMdAutoGenDocumentSearchFromCreatedDate.EditValue = DateTime.MaxValue;// new DateTime(2005, 1, 1, 0, 0, 0);
                    fld_dteMdAutoGenDocumentSearchToCreatedDate.EditValue = DateTime.MaxValue;// new DateTime(2999, 1, 1, 0, 0, 0);
                    break;
                default:
                    break;
            }
        }
        private void chkMdAutoGenDocumentSearchByPatient_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckEdit)sender;
            ChangeControlsState(!chk.Checked);
            if (chk.Checked)
                this.SearchPatient(fld_txtMdAutoGenDocumentPatientNo.Text);
            else
            {
                fld_txtMdAutoGenDocumentPatientNo.Text = string.Empty;
                fld_lkeFK_MEPatientID.EditValue = 0;
                fld_txtMdAutoGenDocumentPatientName.Text = string.Empty;
            }
        }
        private void ChangeControlsState(bool enable)
        {
            fld_lkeMdAutoGenDocumentsStatus.Enabled = enable;
            fld_cmbMdAutoGenDocumentChooseView.Enabled = enable;
            fld_dteMdAutoGenDocumentSearchFromCreatedDate.Enabled = enable;
            fld_dteMdAutoGenDocumentSearchToCreatedDate.Enabled = enable;

            fld_txtMdAutoGenDocumentEmrNo.Enabled = enable;
            fld_txtMdAutoGenDocumentPatientNo.Enabled = !enable;
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
                fld_txtMdAutoGenDocumentPatientNo.Text = gui.Patient.MEPatientNo;
                fld_txtMdAutoGenDocumentPatientName.Text = gui.Patient.MEPatientName;
            }
        }
        private void btnMdAutoGenDocumentSearch_Click(object sender, EventArgs e)
        {
            if (chkMdAutoGenDocumentSearchByPatient.Checked)
            {
                SearchByPatient();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;

            (this.Module as MEDocumentBackgroundModule).MdAutoGenDocumentsSearch(
                fld_txtMdAutoGenDocumentEmrNo.Text,
                fld_lkeMdAutoGenDocumentsStatus.EditValue,
                ((DateTime)fld_dteMdAutoGenDocumentSearchFromCreatedDate.EditValue).Year == DateTime.MaxValue.Year
                   ? new DateTime(2005, 1, 1, 0, 0, 0)
                   : ((DateTime)fld_dteMdAutoGenDocumentSearchFromCreatedDate.EditValue).Date,
               ((DateTime)fld_dteMdAutoGenDocumentSearchToCreatedDate.EditValue).Year == DateTime.MaxValue.Year
                   ? DateTime.MaxValue
                   : ((DateTime)fld_dteMdAutoGenDocumentSearchToCreatedDate.EditValue).Date.AddDays(1).AddMilliseconds(-1)
               );

            Cursor.Current = Cursors.Default;
        }
        private void SearchByPatient()
        {
            (this.Module as MEDocumentBackgroundModule).MdAutoGenDocumentsSearchByPatient(fld_lkeFK_MEPatientID.EditValue);
        }
        private void fld_lkeFK_MEPatientID_EditValueChanged_1(object sender, EventArgs e)
        {
            if (chkMdAutoGenDocumentSearchByPatient.Checked && fld_lkeFK_MEPatientID.EditValue?.ToString() != "0")
            {
                SearchByPatient();
            }
        }

        private void fld_txtMEPatientNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && chkMdAutoGenDocumentSearchByPatient.Checked)
            {
                this.SearchPatient(fld_txtMdAutoGenDocumentPatientNo.Text);
            }
        }

        private void btnMdAutoGenDocumentCreate_Click(object sender, EventArgs e)
        {
            (this.Module as MEDocumentBackgroundModule).MdAutoGenDocumentsRunAgain();
        }
    }
}
