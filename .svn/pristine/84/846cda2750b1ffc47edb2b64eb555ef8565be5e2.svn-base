using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.API.Word;
using Clas.Business.Ftp;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using BOSLib;
using System.Diagnostics;

namespace BOSERP.Modules.MEDocumentManage.UI
{
    public partial class DMDOCMANLOSTDOC : BOSERPScreen
    {
        private MEEmrDocumentsController _emrDocumentCtrl;
        private FileTemplateManager _ftpFileMng;
        public DMDOCMANLOSTDOC()
        {
            InitializeComponent();
            _emrDocumentCtrl = new MEEmrDocumentsController();
            this._ftpFileMng = new FileTemplateManager();
        }

        private void guiSearchDocument_Load(object sender, EventArgs e)
        {
        }

        private void fld_tbnSearchDocument_Click(object sender, EventArgs e)
        {
            BOSProgressBar.Start($"Đang quét dữ liệu");
            var today = DateTime.Now.Date;
            var to = today;
            var from = to.AddMonths(-1);
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
                    to
               };
            var documentDbs = _emrDocumentCtrl.Search(paramValues);
            var emrIds = documentDbs.Select(d => d.FK_MEEmrID).Distinct().ToList();

            var documentFtps = new List<string>();
            foreach (var emrId in emrIds)
            {
                var serverPath = $"/Emr/{emrId}/";
                BOSProgressBar.SetText($"Đang xử lý: {serverPath}");
                try
                {
                    string[] ftpFiles = _ftpFileMng.GetNameListing(serverPath);
                    foreach (var ftpFile in ftpFiles)
                    {
                        documentFtps.Add(Path.GetFileNameWithoutExtension(ftpFile));
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("SearchDocumentNoFTP.FtpFileMng.GetNameListing ERROR: {0}:{1}:{2}:{3}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), BOSApp.CurrentUser, ex, serverPath);
                    Trace.Flush();
                }
            }

            var noMatchs = documentDbs.Where(i => !documentFtps.Contains(i.MEEmrDocumentFile));

            fld_grdDocumentSearchResult.DataSource = noMatchs;
            this.fld_grdDocumentSearchResult.RefreshDataSource();
            this.fld_grdDocumentSearchResult.Refresh();

            BOSProgressBar.Close();
        }
    }
}
