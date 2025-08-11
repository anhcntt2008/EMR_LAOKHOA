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

namespace BOSERP.Modules.MEEmrStore.UI
{
    /// <summary>
    /// Summary description for DMMEEMR101
    /// </summary>
    public partial class DMEMRSTORE01 : BOSERPScreen
    {
        public DMEMRSTORE01()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
        }
        public override void InitializeScreen(STScreensInfo objStScreensInfo)
        {
            base.InitializeScreen(objStScreensInfo);
            fld_cmbChooseView.SelectedIndex = 4;
            fld_cmbChooseViewStoreDate.SelectedIndex = 4;
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

        private void fld_cmbChooseViewStoreDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBoxEdit)sender;
            var start = DateTime.Now;
            switch (cb.SelectedIndex)
            {
                case 0: //trong ngay
                    fld_dteSearchFromMEEmrArchiveBackupDate.EditValue = DateTime.Now.Date;
                    fld_dteSearchToMEEmrArchiveBackupDate.EditValue = DateTime.Now.Date.AddHours(24).AddMilliseconds(-1);
                    break;
                case 1: //trong tuan
                    start = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                    fld_dteSearchFromMEEmrArchiveBackupDate.EditValue = start;
                    fld_dteSearchToMEEmrArchiveBackupDate.EditValue = start.AddDays(7).AddMilliseconds(-1);
                    break;
                case 2: //trong thang
                    start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                    fld_dteSearchFromMEEmrArchiveBackupDate.EditValue = start;
                    fld_dteSearchToMEEmrArchiveBackupDate.EditValue = start.AddMonths(1).AddMilliseconds(-1);
                    break;
                case 3: //trong nam
                    start = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
                    fld_dteSearchFromMEEmrArchiveBackupDate.EditValue = start;
                    fld_dteSearchToMEEmrArchiveBackupDate.EditValue = start.AddMonths(12).AddMilliseconds(-1);
                    break;
                case 4: //tat ca
                    fld_dteSearchFromMEEmrArchiveBackupDate.EditValue = DateTime.MaxValue;// new DateTime(2005, 1, 1, 0, 0, 0);
                    fld_dteSearchToMEEmrArchiveBackupDate.EditValue = DateTime.MaxValue;// new DateTime(2999, 1, 1, 0, 0, 0);
                    break;
                default:
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DateTime? fromDateStore = ((DateTime)fld_dteSearchFromMEEmrArchiveBackupDate.EditValue).Date;
            DateTime? toDateStore = ((DateTime)fld_dteSearchToMEEmrArchiveBackupDate.EditValue).Date;
            if (toDateStore.HasValue && toDateStore.Value.Year != DateTime.MaxValue.Year)
            {
                toDateStore = toDateStore.Value.AddDays(1).AddMilliseconds(-1);
            }

            (this.Module as MEEmrStoreModule).SearchEmrStorage(
                fld_lkeMEEmrArchiveStatus.EditValue,
                fld_lkeMEEmrArchiveBackupStatus.EditValue,
                ((DateTime)fld_dteSearchFromMEEmrCreatedDate.EditValue).Year == DateTime.MaxValue.Year
                   ? new DateTime(2005, 1, 1, 0, 0, 0)
                   : ((DateTime)fld_dteSearchFromMEEmrCreatedDate.EditValue).Date,
               ((DateTime)fld_dteSearchToMEEmrCreatedDate.EditValue).Year == DateTime.MaxValue.Year
                   ? DateTime.MaxValue
                   : ((DateTime)fld_dteSearchToMEEmrCreatedDate.EditValue).Date.AddDays(1).AddMilliseconds(-1),
               ((DateTime)fld_dteSearchFromMEEmrArchiveBackupDate.EditValue).Year == DateTime.MaxValue.Year
                   ? new DateTime(2005, 1, 1, 0, 0, 0)
                   : ((DateTime)fld_dteSearchFromMEEmrArchiveBackupDate.EditValue).Date,
               ((DateTime)fld_dteSearchToMEEmrArchiveBackupDate.EditValue).Year == DateTime.MaxValue.Year
                   ? DateTime.MaxValue
                   : ((DateTime)fld_dteSearchToMEEmrArchiveBackupDate.EditValue).Date.AddDays(1).AddMilliseconds(-1));

            Cursor.Current = Cursors.Default;
        }
    }
}
