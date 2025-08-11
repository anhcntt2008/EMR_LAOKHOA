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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Linq;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.ViewInfo;
using BOSLib;
using DevExpress.XtraRichEdit;
using System.Configuration;
using Clas.Business.Ftp;
using File = System.IO.File;
using DevExpress.XtraRichEdit.Services;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraPrinting;
using System.IO;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiPreviewPdf : BOSERPScreen
    {
        private MEEmrDocumentsInfo _document;
        private string _mode;
        private bool _combineFolder;
        public guiPreviewPdf(MEEmrDocumentsInfo row)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Escape_KeyDown);
            this._document = row;
            fld_pdfViewer.UriOpening += pdfViewer_UriOpening;
        }
        public guiPreviewPdf(MEEmrDocumentsInfo row, string mode, bool combineFolder)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Escape_KeyDown);
            this._document = row;
            _mode = mode;
            _combineFolder = combineFolder;
            fld_pdfViewer.UriOpening += pdfViewer_UriOpening;
        }
        private void pdfViewer_UriOpening(object sender, DevExpress.XtraPdfViewer.PdfUriOpeningEventArgs e)
        {
            if (e.Uri.Scheme == "http" || e.Uri.Scheme == "https")
            {
                ((MEEmrModule)Module).OpenWebBrowser(e.Uri.AbsoluteUri);
                e.Handled = true;
                e.Cancel = true;
            }
        }
        private void Escape_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void guiDocumentPreview_Load(object sender, EventArgs e)
        {
            BOSProgressBar.Start("Đang tải xuống và mở tập tin");
            try
            {
                var filePath = string.Empty;
                if (string.IsNullOrEmpty(_mode))
                    filePath = (this.Module as MEEmrModule).DownloadFtpFile(_document);
                else
                {
                    var localPart = _combineFolder ? Path.Combine("Emr", _mode) : Path.Combine("Emr", _mode, _document.FK_MEEmrID.ToString());
                    var serverPath = _combineFolder ? $"/Emr/{_mode}/" : $"/Emr/{_mode}/{_document.FK_MEEmrID}/";
                    string fileName = $"{_document.MEEmrDocumentFile}.pdf";
                    filePath = (this.Module as MEEmrModule).DownloadFtpFileCommon(serverPath, fileName, localPart);
                }
                if (!File.Exists(filePath))
                {
                    MessageBox.Show(("File bệnh án không tồn tại ở địa chỉ. " + filePath), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    fld_pdfViewer.DetachStreamAfterLoadComplete = true;
                    this.fld_pdfViewer.LoadDocument(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                BOSProgressBar.Close();
            }
        }
    }

}
