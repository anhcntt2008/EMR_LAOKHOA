using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using BOSERP.Modules.MEDocumentManage.UI;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using BOSCommon;
using BOSERP.UI;
using BOSLib;
using Clas.Business.Ftp;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace BOSERP.Modules.MEDocumentManage.UI
{
    public partial class DMEMRDOCMAN02 : BOSERPScreen
    {
        private MEEmrDocumentsController _emrDocumentCtrl;
        private FileTemplateManager _ftpFileMng;
        public DMEMRDOCMAN02()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            _emrDocumentCtrl = new MEEmrDocumentsController();
            this._ftpFileMng = new FileTemplateManager();
        }
        public override void InitializeScreen(STScreensInfo objStScreensInfo)
        {
            base.InitializeScreen(objStScreensInfo);
            fld_ccbeMETemplateID.EditValue = string.Empty;
        }

        private void fld_btnRefreshDocument_Click(object sender, EventArgs e)
        {
            BOSProgressBar.Start($"Đang quét dữ liệu");
            var today = DateTime.Now.Date;
            var to = today;
            var from = to.AddMonths(-1);
            object status = fld_lkeMEEmrDocumentStatus.EditValue.ToString() == "New" ? string.Empty : fld_lkeMEEmrDocumentStatus.EditValue;
            //object status = EmrDocumentStatus.Closed;
            var templateId = fld_ccbeMETemplateID.EditValue;
            if (fld_dteSearchFromMEEmrDocumentCreatedDate.EditValue != null)
            {
                from = ((DateTime)fld_dteSearchFromMEEmrDocumentCreatedDate.EditValue).Date;
            }
            if (fld_dteSearchToMEEmrDocumentCreatedDate.EditValue != null)
            {
                to = ((DateTime)fld_dteSearchToMEEmrDocumentCreatedDate.EditValue).Date;
            }

            object[] paramValues = new object[]
               {
                    from,
                    to,
                    status,
                    templateId
               };
            var documentDbs = _emrDocumentCtrl.SearchV2(paramValues);
            fld_dgcMEEmrDocuments.DataSource = documentDbs;
            this.fld_dgcMEEmrDocuments.RefreshDataSource();
            this.fld_dgcMEEmrDocuments.Refresh();
            BOSProgressBar.Close();
        }
    }
}
