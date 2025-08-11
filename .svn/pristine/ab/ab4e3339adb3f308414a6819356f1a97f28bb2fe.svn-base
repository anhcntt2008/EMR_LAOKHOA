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
using BOSCommon;
using iTextSharp.text.pdf;

namespace BOSERP.Modules.MEDocumentManage.UI
{
    public partial class DMDOCMANERRDOC : BOSERPScreen
    {
        private MEEmrDocumentsController _emrDocumentCtrl;
        public DMDOCMANERRDOC()
        {
            InitializeComponent();
            _emrDocumentCtrl = new MEEmrDocumentsController();
        }

        private void guiSearchDocument_Load(object sender, EventArgs e)
        {
        }

        private void fld_tbnSearchDocument_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStorageDir.Text))
            {
                MessageBox.Show("Chức năng không thể chạy qua FTP nên cần chọn thư mục chứa bệnh án.",
                    "CHỨC NĂNG YÊU CẦU PHẢI CHỌN THƯ MỤC CHỨA BỆNH ÁN", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (!Directory.Exists(txtStorageDir.Text))
            {
                MessageBox.Show("Thư mục đã chọn không tồn tại",
                  "THƯ MỤC KHÔNG TỒN TẠI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (MessageBox.Show("Chức năng sẽ quét qua nội dung tờ bệnh án. Vui lòng không thực hiện quét trong giờ cao điểm.",
                  "CẢNH BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;
            BOSProgressBar.Start($"Đang quét dữ liệu");
            var today = DateTime.Now.Date;
            var to = today;
            var from = to.AddMonths(-1);
            if (fld_dteErrDocumentFromDate.EditValue != null)
            {
                from = ((DateTime)fld_dteErrDocumentFromDate.EditValue).Date;
            }
            if (fld_dteErrDocumentToDate.EditValue != null)
            {
                to = ((DateTime)fld_dteErrDocumentToDate.EditValue).Date;
            }

            object[] paramValues = new object[]
               {
                    from,
                    to
               };
            var documentDbs = _emrDocumentCtrl.Search(paramValues);
            var documentErrors = new List<string>();
            var documentHelper = new Clas.Emr.Core.EmrDocumentHelper();
            foreach (var document in documentDbs)
            {
                var filePath = $"/Emr/{document.FK_MEEmrID}/";
                BOSProgressBar.SetText($"Đang xử lý: {filePath}");
                try
                {
                    filePath = Path.Combine(txtStorageDir.Text, document.FK_MEEmrID.ToString(), document.MEEmrDocumentFile + "." + document.MEEmrDocumentFileExt);
                    if (document.MEEmrDocumentFileExt == EmrDocumentFileExtention.pdf.ToString())
                    {
                        using (var reader = new PdfReader(filePath)) { };
                    }
                    else if (document.MEEmrDocumentFileExt == EmrDocumentFileExtention.docx.ToString())
                    {
                        using (OfficeOpenXmlCrypto.OfficeCryptoStream stream =
                            OfficeOpenXmlCrypto.OfficeCryptoStream.Open(filePath, documentHelper.ShareEmrPassword))
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                    document.MEEmrDocumentDesc = ex.ToString();
                    document.AAStatus = "ERROR";
                }
            }

            fld_grdDocumentSearchResult.DataSource = documentDbs.Where(i => i.AAStatus == "ERROR").ToArray();
            this.fld_grdDocumentSearchResult.RefreshDataSource();
            this.fld_grdDocumentSearchResult.Refresh();
            BOSProgressBar.Close();

            MessageBox.Show("Đã quét xong. Xem nội dung lỗi trong cột [Mô tả] trên lưới",
                   "ĐÃ XONG", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fld_btnSelectFile_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtStorageDir.Text = fbd.SelectedPath;
                }
            }
        }
    }
}
