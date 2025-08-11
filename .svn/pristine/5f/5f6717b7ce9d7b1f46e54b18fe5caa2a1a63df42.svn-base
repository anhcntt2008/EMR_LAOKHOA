using BOSCommon;
using BOSERP.Utilities;
using BOSLib;
using Clas.Business.Ftp;
using Clas.Emr.Core;
using Clas.Emr.Intergration;
using Clas.Model.Domain;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using Emr.Ca.Core;
using Emr.Document.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOSERP.Modules.ME.Helpers
{
    public class EmrHelper
    {
        public string StorageDir = "Archives";

        private readonly string _documentPath;
        private readonly IPdfProcessor _pdfProcessor;
        private readonly FileTemplateManager _ftpFileMng;
        private readonly HashProvider _hashProvider;
        private readonly HashProvider _md5Hasher;
        private readonly IDigitalSignatureBase _digitalSig;
        private readonly MEEmrArchivesController _archivesCtrl;
        private RichEditControl _richEditCtrlHelper;
        private EmrDocumentHelper _emrDocumentHelper;
        private METemplatesController _templateCtrl;
        private METemplateParamsController _templateParamCtrl;
        private ApiHelper _apiEmr;
        private MEEmrsController _emrCtrl;
        private MEEmrDocumentsController _emrDocumentCtrl;
        private MEEmrTemplateActionsController _templateActionCtrl;

        #region Variable
        private readonly string _docExt;
        private readonly string _pdfExt;
        #endregion

        public EmrHelper(string documentPath, IPdfProcessor pdfProcessor, FileTemplateManager ftpFileMng, HashProvider hashProvider, IDigitalSignatureBase digitalSig)
        {
            _documentPath = documentPath;
            _pdfProcessor = pdfProcessor;
            _ftpFileMng = ftpFileMng;
            _hashProvider = hashProvider;
            _digitalSig = digitalSig;
            _archivesCtrl = new MEEmrArchivesController();
            _richEditCtrlHelper = new RichEditControl();
            _emrDocumentHelper = new EmrDocumentHelper(_richEditCtrlHelper);
            _md5Hasher = new HashProvider("MD5");
            _templateCtrl = new METemplatesController();
            _templateParamCtrl = new METemplateParamsController();
            _emrCtrl = new MEEmrsController();
            _emrDocumentCtrl = new MEEmrDocumentsController();
            _templateActionCtrl = new MEEmrTemplateActionsController();

            var emrEndpoint = BOSApp.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_EMR_API_ENDPOINT);
            if (!string.IsNullOrEmpty(emrEndpoint) && !string.IsNullOrEmpty(BOSApp.EmrApiAuthToken))
            {
                var timeout = BOSApp.GetSystemConfigValueInt(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_EMR_API_ENDPOINT_TIMEOUT, 180000);
                _apiEmr = new ApiHelper(emrEndpoint, BOSApp.EmrApiAuthToken, "EMR", timeout);
            }
            _docExt = EmrDocumentFileExtention.docx.ToString();
            _pdfExt = EmrDocumentFileExtention.pdf.ToString();
        }

        public Dictionary<string, object> ExportPdf(MEEmrDocumentsInfo document, bool refresh, bool upload, bool isHash)
        {
            try
            {
                var dld = DownloadAndLoadDocx(_richEditCtrlHelper, document, _docExt);
                if (dld["result"] is bool value)
                {
                    if (value)
                    {
                        string filePath = string.Format(@"{0}\Emr\{1}\{2}.{3}", _documentPath, document.FK_MEEmrID, document.MEEmrDocumentFile, _pdfExt);
                        var hash = _md5Hasher.ComputeHash(Path.Combine(_documentPath, "Emr", document.FK_MEEmrID.ToString(), document.MEEmrDocumentFile + "." + _docExt));
                        var hashName = $"{document.MEEmrDocumentFile}_MD5{hash}.{_pdfExt}";
                        if (!refresh)
                        {
                            if (_ftpFileMng.FileExists($"/Emr/{document.FK_MEEmrID}/", hashName))
                            {
                                _ftpFileMng.DownloadFile($"/Emr/{document.FK_MEEmrID}/", hashName, filePath);
                                return new Dictionary<string, object> { { "result", true }, { "content", $"{filePath} đã tải" } };
                            }
                        }

                        var template = _templateCtrl.GetObjectByID(document.FK_METemplateID) as METemplatesInfo;
                        //var templateParams = AppMemCache.GetTemplateParams(template.METemplateID);
                        var templateParams = _templateParamCtrl.GetAllTemplateParamObjectByTemplateID(template.METemplateID);
                        RemoveAllForPrint(_richEditCtrlHelper, template, _emrDocumentHelper, templateParams);

                        var fileHashPath = string.Empty;
                        if (isHash)
                        {
                            fileHashPath = Path.Combine(_documentPath, "Emr", document.FK_MEEmrID.ToString(), hashName);
                            _richEditCtrlHelper.ExportToPdf(fileHashPath);
                        }
                        else
                        {
                            _richEditCtrlHelper.ExportToPdf(filePath);
                        }

                        if (upload)
                        {
                            var serverPath = $"/Emr/{document.FK_MEEmrID}/";
                            if (isHash)
                            {
                                _ftpFileMng.UploadFile(serverPath, hashName, fileHashPath);
                            }
                            else
                            {
                                _ftpFileMng.UploadFile(serverPath, $"{document.MEEmrDocumentFile}.{_pdfExt}", filePath);
                            }
                        }

                        return new Dictionary<string, object> { { "result", true }, { "content", $"{filePath} đã xuất " } };
                    }
                }

                return dld;
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object> { { "result", false }, { "content", ex.ToString() } };
            }
        }

        public Dictionary<string, object> CheckupEmr(MEEmrsInfo emr, MEEmrDocumentsInfo mainDocument, bool again)
        {
            // VALIDATE BEFORE CALL CheckupEmr()
            // 1. mainDocument: check true, if no find mainDocument base emr. [PREPARE]
            // 2. Backup all file of mainDocument on ftp: again is true. [PREPARE]
            // 3. Checkup API => ok. if fail go 4.
            // 4. Checkup Local.
            var uid = $"{emr.MEEmrID} - {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
            string localPath = string.Format(@"{0}\Emr\{1}\", _documentPath, emr.MEEmrID);
            string serverPath = $"/Emr/{emr.MEEmrID}/";
            try
            {
                var documents = _emrDocumentCtrl.GetByEmrId(emr.MEEmrID);
                #region PREPARE
                // 1. mainDocument: check true, if no find mainDocument base emr.
                if (mainDocument.MEEmrDocumentID > 0)
                {
                    var actions = this._templateActionCtrl.GetAllByTemplateIdAndWhen(mainDocument.FK_METemplateID, EmrTemplateActionWhen.Checkup.ToString())
                                                    .OrderBy(o => o.MEEmrTemplateActionOrder).ToList();
                    if (actions.Count == 0)
                    {
                        return new Dictionary<string, object> {
                            { "result", false },
                            { "continue", false },
                            { "content", $"{uid} Không tìm thấy chức năng tự chạy khi kiểm duyệt dành cho tờ bệnh án này." },
                            { "message", "Vui lòng chọn đúng tờ bệnh án (vd: Tờ đầu bệnh án)" }
                        };
                    }
                }
                else
                {
                    if (documents.Count() == 0)
                    {
                        return new Dictionary<string, object> {
                            { "result", false },
                            { "continue", false },
                            { "content", $"{uid} không có tờ bệnh án." }
                        };
                    }
                    foreach (var document in documents)
                    {
                        if (mainDocument != null && mainDocument.MEEmrDocumentID == 0)
                        {
                            var actions = this._templateActionCtrl.GetAllByTemplateIdAndWhen(document.FK_METemplateID, EmrTemplateActionWhen.Checkup.ToString())
                                        .OrderBy(o => o.MEEmrTemplateActionOrder).ToList();
                            if (actions != null && actions.Count() > 0)
                            {
                                mainDocument = document;
                            }
                        }
                    }

                    if (mainDocument.MEEmrDocumentID == 0)
                    {
                        return new Dictionary<string, object> {
                            { "result", false },
                            { "continue", false },
                            { "content", $"{uid} Không tìm thấy tờ bệnh án có chức năng kiểm duyệt." }
                        };
                    }
                }

                // 2. Backup all file of mainDocument on ftp: again is true.
                if (again)
                {
                    if (_ftpFileMng.FileExists(serverPath, $"{mainDocument.MEEmrDocumentFile}.{_docExt}"))
                    {
                        string localPathFileBackup = Path.Combine(localPath, $"{mainDocument.MEEmrDocumentFile}_bkCheckup.{_docExt}");
                        var from = $"{serverPath}{mainDocument.MEEmrDocumentFile}.{_docExt}";
                        var to = $"{serverPath}{mainDocument.MEEmrDocumentFile}_bkCheckup.{_docExt}";
                        _ftpFileMng.CopyFile(from, to, localPathFileBackup);
                    }
                    if (_ftpFileMng.FileExists(serverPath, $"{mainDocument.MEEmrDocumentFile}.{_pdfExt}"))
                    {
                        string localPathFileBackup = Path.Combine(localPath, $"{mainDocument.MEEmrDocumentFile}_bkCheckup.{_pdfExt}");
                        var from = $"{serverPath}{mainDocument.MEEmrDocumentFile}.{_pdfExt}";
                        var to = $"{serverPath}{mainDocument.MEEmrDocumentFile}_bkCheckup.{_pdfExt}";
                        _ftpFileMng.CopyFile(from, to, localPathFileBackup);
                    }
                }
                #endregion

                var apiResult = CheckupEmrAPI(emr, documents, mainDocument, again);
                if (apiResult["result"] is bool value)
                {
                    if (value)
                    {

                        return new Dictionary<string, object> {
                            { "result", true },
                            { "continue", true },
                            { "content", apiResult["content"] },
                            { "message", apiResult["message"] }
                        };
                    }
                }
                return CheckupEmrLocal(emr, documents, mainDocument, again);
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object> { { "result", false }, { "content", ex.ToString() } };
            }
        }

        private Dictionary<string, object> CheckupEmrAPI(MEEmrsInfo emr, List<MEEmrDocumentsInfo> documents, MEEmrDocumentsInfo mainDocument, bool again)
        {
            var uid = $"{emr.MEEmrID} - {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
            string localPath = string.Format(@"{0}\Emr\{1}\", _documentPath, emr.MEEmrID);
            DirectoryInfo localDir = new DirectoryInfo(localPath);
            string serverPath = $"/Emr/{emr.MEEmrID}/";
            try
            {
                var documentsDto = new List<MEEmrDocumentsDto>();
                var msg = string.Empty;
                if (_apiEmr != null)
                {
                    var actionUri = BOSApp.GetSystemConfigValue(SysCfgConsts.EMR_API_ENDPOINT, SysCfgConsts.EMR_CHECKUP);
                    if (!string.IsNullOrEmpty(actionUri))
                    {
                        //PrintMgsLog("BAT-DAU-GOI-API-KIEM-DUYET", actionUri);
                        var body = new { emrId = emr.MEEmrID, userId = BOSApp.CurrentUsersInfo.ADUserID };
                        var response = _apiEmr.Post<Emr.Base.Models.Abp.AjaxResponse, List<MEEmrDocumentsDto>>(actionUri, null, body);
                        //PrintMgsLog("KET-THUC-GOI-API-KIEM-DUYET", actionUri);
                        if (response != null && response.Success)
                        {
                            documentsDto = response.Result;

                            foreach (var document in documents)
                            {
                                if (document.MEEmrDocumentStatus == EmrDocumentStatus.InProgress.ToString() || document.MEEmrDocumentStatus == EmrDocumentStatus.Closed.ToString())
                                {
                                    var docDto = documentsDto.FirstOrDefault(m => m.MEEmrDocumentID.Equals(document.MEEmrDocumentID));
                                    document.MEEmrDocumentPageCount = docDto.MEEmrDocumentPageCount;
                                    document.MEEmrDocumentDuplexCount = (int)Math.Ceiling(document.MEEmrDocumentPageCount / 2F);
                                }
                                // Xoá pdf kiểm duyệt trước đó nếu có
                                if (document.MEEmrDocumentFileExt == _docExt)
                                {
                                    string filePdfPath = Path.Combine(localPath, $"{document.MEEmrDocumentFile}.{_pdfExt}");
                                    File.Delete(filePdfPath);
                                }
                            }
                            #region Download files. Now download each file when click
                            //var pathWp = Path.Combine($"\\Workspace", BOSApp.CurrentUsersInfo.ADUserID.ToString(), "Emr", emr.MEEmrID.ToString());
                            //var threadDownWPEmrsPdf = new System.Threading.Thread(() => DownWpEmrPdf(localDir, pathWp, Path.GetFileName(mainFilePath)));
                            //threadDownWPEmrsPdf.Start();
                            #endregion

                            return new Dictionary<string, object> { 
                                { "result", true },
                                { "documents", documents },
                                { "content", "Kiểm duyệt thành công ở API." } 
                            };
                        }
                        msg = "Lỗi không xác định.";
                        if (response.Error != null)
                        {
                            var document = _emrDocumentCtrl.GetByEmrId(emr.MEEmrID).Where(d => d.MEEmrDocumentFile == response.Error.Message).FirstOrDefault();
                            if (document != null)
                            {
                                //TODO lấy số STT tờ theo gridview
                                var template = _templateCtrl.GetObjectByID(document.FK_METemplateID) as METemplatesInfo;
                                msg = $"Gáy: [{document.MEEmrDocumentOrder}.{document.MEEmrDocumentGroup}]\nTờ: [{document.MEEmrDocumentSubOrder}.{template.METemplateName}. {document.MEEmrDocumentFile}]";
                                msg += $"\n\n\nChi tiết: { response.Error?.Details.ToString()}";
                            }
                        }
                    }
                }
                else
                {
                    msg = "Không cấu hình kiểm duyệt bệnh án bằng EMR API";
                }

                return new Dictionary<string, object> {
                        { "result", false },
                        { "continue", true },
                        { "content", msg }
                    };
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object> {
                    { "result", false },
                    { "continue", true },
                    { "content", ex.ToString() }
                };
            }
        }

        private Dictionary<string, object> CheckupEmrLocal(MEEmrsInfo emr, List<MEEmrDocumentsInfo> documents, MEEmrDocumentsInfo mainDocument, bool again)
        {
            try
            {
                string localPath = string.Format(@"{0}\Emr\{1}\", _documentPath, emr.MEEmrID);
                DirectoryInfo localDir = new DirectoryInfo(localPath);
                string serverPath = $"/Emr/{emr.MEEmrID}/";
                var serverFiles = _ftpFileMng.GetNameListing(serverPath);
                var processBgFiles = new List<string>();
                foreach (var document in documents)
                {
                    try
                    {
                        if (document.MEEmrDocumentStatus == EmrDocumentStatus.InProgress.ToString() || document.MEEmrDocumentStatus == EmrDocumentStatus.Closed.ToString())
                        {
                            string filePdfPath = Path.Combine(localPath, $"{document.MEEmrDocumentFile}.{_pdfExt}");
                            if (document.MEEmrDocumentFileExt == _docExt)
                            {
                                var localFileDocx = string.Empty;
                                var dlm = DownloadFtpFile(document, _docExt);
                                if (dlm["result"] is bool value)
                                {
                                    if (value)
                                    {
                                        localFileDocx = dlm["content"].ToString();
                                    }
                                    else
                                    {
                                        return dlm;
                                    }
                                }
                                else
                                {
                                    return dlm;
                                }

                                //var localFileDocx = DownloadFtpFile(document);
                                var hash = _md5Hasher.ComputeHash(localFileDocx);
                                var filePdfHash = $"{document.MEEmrDocumentFile}_MD5{hash}.{_pdfExt}";
                                File.Delete(filePdfPath);
                                var fi = new FileInfo(Path.Combine(localPath, filePdfHash));
                                if (fi != null && fi.Exists && fi.Length > 10000)
                                {
                                    File.Move(Path.Combine(localPath, filePdfHash), filePdfPath);
                                    //khong up len lai server
                                    //processBgFiles.Add(filePdfHash);
                                }
                                else
                                {
                                    var existFileHash = serverFiles.Where(stringToCheck => stringToCheck.Contains(filePdfHash));
                                    if (existFileHash.Count() > 0)
                                    {
                                        //co file hash tren server thi tai ve
                                        _ftpFileMng.DownloadFile(serverPath, filePdfHash, filePdfPath);
                                        fi = new FileInfo(filePdfPath);
                                        if (fi != null && fi.Exists && fi.Length < 10000)
                                            File.Delete(filePdfPath);
                                    }
                                }

                                try
                                {
                                    //neu file pdf co loi thi se xuat lai
                                    document.MEEmrDocumentPageCount = GetNumberOfPdfPages(filePdfPath);
                                }
                                catch (Exception)
                                {
                                    using (OfficeOpenXmlCrypto.OfficeCryptoStream stream = OfficeOpenXmlCrypto.OfficeCryptoStream.Open(localFileDocx, this._emrDocumentHelper.ShareEmrPassword))
                                    {
                                        _richEditCtrlHelper.LoadDocument(stream, DocumentFormat.OpenXml);
                                    }
                                    var template = _templateCtrl.GetObjectByID(document.FK_METemplateID) as METemplatesInfo;
                                    var templateParams = AppMemCache.GetTemplateParams(template.METemplateID);
                                    RemoveAllForPrint(_richEditCtrlHelper, template, _emrDocumentHelper, templateParams);
                                    //RemoveAllForPrint(this._richEditCtrlHelper, document.FK_METemplateID);
                                    _richEditCtrlHelper.ExportToPdf(filePdfPath);

                                    document.MEEmrDocumentPageCount = GetNumberOfPdfPages(filePdfPath);
                                    if (!processBgFiles.Contains(filePdfHash))
                                    {
                                        processBgFiles.Add(filePdfHash);
                                    }
                                }

                                ClearHashFileLocal(localDir, document.MEEmrDocumentFile);
                                // trong tat ca cac truong hop deu giu lai file hash o local cho lan kiem duyet tiep theo neu co
                                File.Copy(filePdfPath, Path.Combine(localPath, filePdfHash), true);
                            }
                            else if (document.MEEmrDocumentFileExt == _pdfExt)
                            {
                                _ftpFileMng.DownloadFile(serverPath, $"{document.MEEmrDocumentFile}.{_pdfExt}", filePdfPath);
                                document.MEEmrDocumentPageCount = GetNumberOfPdfPages(filePdfPath);
                            }
                            document.MEEmrDocumentDuplexCount = (int)Math.Ceiling(document.MEEmrDocumentPageCount / 2F);
                        }
                    }
                    catch (Exception ex)
                    {
                        var mirrorDocument = (MEEmrDocumentsInfo)document.Clone();
                        mirrorDocument.MEEmrDocumentDesc = $"{ex.ToString()}";
                        var noticeDocs = new List<MEEmrDocumentsInfo>
                            {
                                mirrorDocument
                            };

                        return new Dictionary<string, object> {
                            { "result", false },
                            { "noticeDocs", noticeDocs },
                            { "content", ex.ToString() }
                        };
                    }
                }

                var threadProcessHashFileFtp = new System.Threading.Thread(() => ProcessHashFileFtp(localPath, serverPath, processBgFiles));
                threadProcessHashFileFtp.Start();

                return new Dictionary<string, object> { 
                    { "result", true },
                    { "documents", documents },
                    { "content", "" } 
                };
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object> { { "result", false }, { "content", ex.ToString() } };
            }
        }

        private Dictionary<string, object> DownloadAndLoadDocx(RichEditControl richCtrl, MEEmrDocumentsInfo document, string ext)
        {
            try
            {
                var dlm = DownloadFtpFile(document, ext);
                if (dlm["result"] is bool value)
                {
                    if (value)
                    {
                        var filePath = dlm["content"].ToString();
                        if (!File.Exists(filePath))
                        {
                            return new Dictionary<string, object> { { "result", false }, { "content", $"File bệnh án không tồn tại ở địa chỉ. {filePath}" } };
                        }

                        using (OfficeOpenXmlCrypto.OfficeCryptoStream stream = OfficeOpenXmlCrypto.OfficeCryptoStream.Open(filePath, _emrDocumentHelper.ShareEmrPassword))
                        {
                            richCtrl.LoadDocument(stream, DocumentFormat.OpenXml);
                        }
                    }
                }

                return dlm;
            }
            catch (OfficeOpenXmlCrypto.InvalidPasswordException ex)
            {
                return new Dictionary<string, object> { { "result", false }, { "content", ex.ToString() } };
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object> { { "result", false }, { "content", ex.ToString() } };
            }
        }

        private Dictionary<string, object> DownloadFtpFile(MEEmrDocumentsInfo document, string ext)
        {
            try
            {
                string filePath = string.Format(@"{0}\Emr\{1}\{2}.{3}", _documentPath, document.FK_MEEmrID, document.MEEmrDocumentFile, ext);
                _ftpFileMng.DownloadFile($"/Emr/{document.FK_MEEmrID}/", document.MEEmrDocumentFile + "." + ext, filePath);
                return new Dictionary<string, object> { { "result", true }, { "content", filePath } };
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object> { { "result", false }, { "content", ex.ToString() } };
            }
        }

        private void ProcessHashFileFtp(string localPath, string serverPath, List<string> processBgFiles)
        {
            var serverFiles = _ftpFileMng.GetNameListing(serverPath);
            foreach (var hashFile in processBgFiles)
            {
                var documentFile = Path.GetFileNameWithoutExtension(hashFile).Split(new string[] { "_MD5" }, StringSplitOptions.None)[0];
                var fileLocalPath = Path.Combine(localPath, $"{documentFile}.pdf");
                ClearHashFileServer(serverPath, serverFiles, documentFile, string.Empty);
                UploadFileFtp(serverPath, hashFile, fileLocalPath);
            }
        }

        private void ClearHashFileServer(string serverPath, string[] serverFiles, string mEEmrDocumentFile, string exceptFile)
        {
            var deleteFilePart = $"{mEEmrDocumentFile}_MD5";
            var deleteFiles = serverFiles.Where(m => m.Contains(deleteFilePart));
            if (!string.IsNullOrEmpty(exceptFile))
            {
                deleteFiles = deleteFiles.Where(m => !m.Contains(exceptFile));
            }
            foreach (var file in deleteFiles)
            {
                if (Path.GetExtension(file) == ".pdf")
                {
                    _ftpFileMng.Delete(serverPath, Path.GetFileName(file));
                }
            }
        }

        private void UploadFileFtp(string serverPath, string serverFile, string localPath)
        {
            try
            {
                _ftpFileMng.UploadFile(serverPath, serverFile, localPath);
            }
            catch (Exception ex)
            {
                //PrintMgsLog("Có lỗi khi tải lên tờ bệnh án tạm. Lỗi không ảnh hưởng.", ex.ToString());
            }
        }

        #region RemoveAllForPrint
        public void RemoveAllForPrint(RichEditControl richContrl, METemplatesInfo template,
            EmrDocumentHelper emrDocumentHelper, List<METemplateParamsInfo> templateParams)
        {
            this.RemoveAllTagForPrint(richContrl, template);
            this.RemoveAllCommentForPrint(richContrl);

            emrDocumentHelper.RemoveAllHiddenDataForPrint(richContrl, template.METemplateID, templateParams);

            emrDocumentHelper.ProgressHyperlinksParamForPrint(richContrl.Document);

            if (template.METemplateSignatureNotAlone)
                emrDocumentHelper.SignatureAndContentOnTheSamePage(richContrl, richContrl.Document, richContrl.DocumentLayout);

            if (template.METemplateNo.ToUpper() == "TDT")
            {
                var table = richContrl.Document.Tables.OrderByDescending(t => t.Range.Length).FirstOrDefault();
                if (table != null && table.Rows.Count > 2)
                {
                    try
                    {
                        int pageCount = richContrl.DocumentLayout.GetFormattedPageCount();
                        for (int i = 0; i < pageCount; i++)
                        {
                            var collector = new TableCellLayoutVisitor(richContrl);
                            collector.Visit(richContrl.DocumentLayout.GetPage(i));
                            foreach (var range in collector.Ranges)
                            {
                                var cell = richContrl.Document.Tables.GetTableCell(richContrl.Document.CreatePosition(range.Start));
                                if (cell != null && table == cell.Table)
                                {
                                    var pos = richContrl.Document.CreatePosition(cell.ContentRange.End.ToInt() - 1);
                                    var p = richContrl.Document.Paragraphs.Insert(pos);
                                    p = richContrl.Document.Paragraphs.Insert(pos);
                                    p = richContrl.Document.Paragraphs.Insert(pos);
                                    p = richContrl.Document.Paragraphs.Insert(pos);
                                    p = richContrl.Document.Paragraphs.Insert(pos);
                                }
                            }
                        }
                    }
                    catch (Exception) {/*do nothing to make sure not error*/}
                }
            }
        }
        /// <summary>
        /// remove all hyperlink and tag to print
        /// TODO: not remove info hyperlink ext: rc link...
        /// </summary>
        /// <param name="richContrl"></param>
        private void RemoveAllTagForPrint(RichEditControl richContrl, METemplatesInfo template)
        {
            var doc = richContrl.Document;
            doc.BeginUpdate();
            for (int i = 0; i < doc.Hyperlinks.Count; i++)
            {
                var link = doc.Hyperlinks[i];
                try
                {
                    if (template.METemplateNo.ToUpper() == "TDT")
                    {
                        if (link.NavigateUri.StartsWith("thaythethe_chandoan|gid="))
                        {
                            //14 = length('Thêm chẩn đoán')
                            doc.Replace(doc.CreateRange(doc.CreatePosition(link.Range.End.ToInt() - 14), 14), " ");
                            continue;
                        }
                    }
                }
                catch (Exception) {/*do nothing*/}
                link.ToolTip = null;
                doc.Replace(link.Range, string.Empty);
                doc.Hyperlinks.Remove(link);
                i--;
            }
            doc.ReplaceAll(EmrParam.BeginTag, " ", SearchOptions.None);
            doc.ReplaceAll(EmrParam.EndTag, " ", SearchOptions.None);
            doc.EndUpdate();
        }
        private void RemoveAllCommentForPrint(RichEditControl richContrl)
        {
            var doc = richContrl.Document;
            if (doc.Comments.Count == 0) return;
            doc.BeginUpdate();
            for (int i = 0; i < doc.Comments.Count; i++)
            {
                doc.Comments.Remove(doc.Comments[i]);
                i--;
            }
            doc.EndUpdate();
        }
        #endregion

        public void ClearHashFileLocal(DirectoryInfo localDir, string mEEmrDocumentFile)
        {
            var checkMD5HashSt = $"{mEEmrDocumentFile}_MD5";
            foreach (FileInfo file in localDir.GetFiles())
            {
                if (file.Name.Contains(checkMD5HashSt))
                {
                    file.Delete();
                }
            }
        }

        public void HandleLog(string type, string message)
        {
            var localDir = Path.Combine(_documentPath, "Logs");
            Directory.CreateDirectory(localDir);
            File.AppendAllText($"{localDir}/{type}-{DateTime.Now.ToString("MMddyyyy")}.txt", message + Environment.NewLine);
        }

        public int GetNumberOfPdfPages(string path)
        {
            using (var reader = new iTextSharp.text.pdf.PdfReader(path))
                return reader.NumberOfPages;
        }

        #region Current
        public MEEmrArchivesInfo MergeAndArchived(MEEmrsInfo emr, List<MEEmrDocumentsInfo> documents)
        {
            var dotPdf = "." + EmrDocumentFileExtention.pdf.ToString();
            var fileNames = new List<string>();
            //ordered on list
            //documents = documents.OrderBy(d => d.MEEmrDocumentOrder).ThenBy(d => d.MEEmrDocumentSubOrder).ToList();
            foreach (var document in documents)
            {
                Console.WriteLine(document.MEEmrDocumentRefNo);
                //Bo qua cac to an va huy
                if (document.MEEmrDocumentStatus == EmrDocumentStatus.Discarded.ToString() || document.MEEmrDocumentStatus == EmrDocumentStatus.Hidden.ToString())
                    continue;
                if (document.MEEmrDocumentFileExt == EmrDocumentFileExtention.pdf.ToString())
                {
                    string fileName = Path.Combine("Emr", document.FK_MEEmrID.ToString(), document.MEEmrDocumentFile + dotPdf);
                    string fileLocal = Path.Combine(_documentPath, fileName);
                    _ftpFileMng.DownloadFile($"/Emr/{document.FK_MEEmrID}/", document.MEEmrDocumentFile + dotPdf, fileLocal);
                    fileNames.Add(fileName);
                }
            }
            if (fileNames.Count() == 0) return null;

            var archiveFile = Emr.SanitizedFileName.Sanitize(emr.MEEmrNo, ".");
            if (!string.IsNullOrEmpty(emr.MEEmrArchiveNo))
                archiveFile += Emr.SanitizedFileName.Sanitize($"_{emr.MEEmrArchiveNo}", ".");
            if (emr.MEEmrDateOut.Year != 9999)
                archiveFile += $"_{emr.MEEmrDateOut.ToString("ddMMyyyy")}";
            archiveFile += $"_{DateTime.Now.ToString("ddMMyyyyHHmmss")}";

            var outFileName = archiveFile + dotPdf;
            var outFilePath = _pdfProcessor.Merge(Path.Combine(StorageDir, emr.MEEmrID.ToString(), outFileName), fileNames.ToArray());

            BOSProgressBar.Start("Đang lưu và upload tập tin");
            _ftpFileMng.CreateDirectory($"/{StorageDir}/{emr.MEEmrID}/");
            _ftpFileMng.UploadFile($"/{StorageDir}/{emr.MEEmrID}/", outFileName, outFilePath);
            var hashStr = _hashProvider.ComputeHash(outFilePath);
            var archive = new MEEmrArchivesInfo()
            {
                FK_MEEmrID = emr.MEEmrID,
                // khoa cua nguoi thuc hien luu tru
                FK_HRDepartmentID = BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID,
                FK_HREmployeeID = BOSApp.CurrentEmployeesInfo.HREmployeeID,
                MEEmrArchiveDate = DateTime.Now,
                MEEmrArchiveRemark = "Lưu trữ bệnh án",
                MEEmrArchiveStatus = EmrArchiveStatus.Archived.ToString(),
                MEEmrArchiveFile = archiveFile,
                MEEmrArchiveFileExt = EmrDocumentFileExtention.pdf.ToString(),
                MEEmrArchiveFileHash = hashStr
            };
            return archive;
        }
        public MEEmrArchivesInfo DigitalSignEmrArchivePdf(MEEmrsInfo emr, MEEmrArchivesInfo archive, MEEmrTypesInfo emrType, int page, string reason)
        {
            if (archive == null) return archive;
            if (emrType == null) return archive;

            var dotExt = "." + archive.MEEmrArchiveFileExt;
            string fileName = archive.MEEmrArchiveFile + dotExt;
            string filePath = Path.Combine(_documentPath, StorageDir, emr.MEEmrID.ToString(), fileName);
            try
            {
                var byteContent = File.ReadAllBytes(filePath);
                string signature = emrType.MEEmrTypeDgtSignatureImage ? Convert.ToBase64String(BOSApp.CurrentEmployeesInfo.HREmployeeSignature) : string.Empty;
                var configCA = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_CA_METHOD);
                var methodCA = !string.IsNullOrEmpty(configCA) ? configCA : string.Empty;
                var base64Resp = _digitalSig.PdfSigner(byteContent,
                    new SignerParammeterBase()
                    {
                        SerialNumber = BOSApp.CurrentUsersInfo.ADUserCaIdentity,
                        AgreementUUID = BOSApp.CurrentUsersInfo.ADUserCaIdentity,
                        AuthorizeCode = Emr.Cryptographier.Decrypt(BOSApp.CurrentUsersInfo.ADUserCaPasscode),
                        IdentityNumber = BOSApp.CurrentEmployeesInfo.HREmployeeIDNumber,
                        FileName = fileName,
                        Method = methodCA
                    },
                    new PdfSignerPropertyBase()
                    {
                        Visible = emrType.MEEmrTypeDgtSignatureVisible,
                        Width = emrType.MEEmrTypeDgtSignatureWidth,
                        Height = emrType.MEEmrTypeDgtSignatureHeight,
                        Reason = reason,
                        Page = page,
                        CoordinateX = emrType.MEEmrTypeDgtSignatureX, // góc Dưới - Trái
                        CoordinateY = emrType.MEEmrTypeDgtSignatureY, // góc Dưới - Trái
                        SignatureImage = signature,
                        TextColor = emrType.MEEmrTypeDgtSignatureTextColor,
                        FontSize = emrType.MEEmrTypeDgtSignatureFontSize,
                    });

                var byteArr = Convert.FromBase64String(base64Resp);
                File.WriteAllBytes(filePath, byteArr);
                _ftpFileMng.UploadFile($"/{StorageDir}/{emr.MEEmrID}/", fileName, filePath);

                archive.MEEmrArchiveFileHash = _hashProvider.ComputeHash(byteArr);
                archive.MEEmrArchiveStatus = EmrArchiveStatus.DigitalSigned.ToString();
                archive.AAUpdatedUser = BOSApp.CurrentUser;
                archive.FK_HREmployeeID = BOSApp.CurrentEmployeesInfo.HREmployeeID;
                archive.AAUpdatedDate = DateTime.Now;
                archive.MEEmrArchiveSignTime = DateTime.Now;
                _archivesCtrl.UpdateObject(archive);
                return archive;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ViewDigitalSignatureInfo(MEEmrArchivesInfo archive, string filePath, bool logConfig, bool notification, BOSComponent.BOSMemoEdit msgLogs)
        {
            var result = string.Empty;
            var hashStr = _hashProvider.ComputeHash(filePath);
            if (hashStr != archive.MEEmrArchiveFileHash)
            {
                BOSProgressBar.Close();
                MessageBox.Show($"NỘI DUNG BỘ BỆNH ÁN ĐÃ BỊ THAY ĐỔI KỂ TỪ THỜI ĐIỂM THỰC HIỆN LƯU TRỮ"
               + "\n \u2756 Mã băm cũ: " + archive.MEEmrArchiveFileHash
               + "\n\n \u2756 Mã băm hiện tại: " + hashStr,
               "Nội dung tờ bệnh án đã bị thay đổi kể từ thời điểm thực hiện lưu trữ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (archive.MEEmrArchiveStatus == EmrArchiveStatus.DigitalSigned.ToString())
            {
                var valid = false;
                var location = BOSApp.CurrentCompanyInfo.CSCompanyCaProvider == CaProviders.ESIGN_CA ? "LOCAL" : $"MÁY CHỦ {BOSApp.CurrentCompanyInfo.CSCompanyCaProvider} KÝ SỐ TRẢ VỀ";
                try
                {
                    BOSProgressBar.Start("Đang xác thực chữ ký số");
                    var configCA = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_CA_METHOD);
                    var methodCA = !string.IsNullOrEmpty(configCA) ? configCA : string.Empty;
                    valid = _digitalSig.Verify(File.ReadAllBytes(filePath), archive.MEEmrArchiveFileExt, methodCA);
                }
                catch (SignerCustomException ex)
                {
                    BOSProgressBar.Close();
                    MessageBox.Show(location + ": XÁC THỰC KHÔNG THÀNH CÔNG" +
                        "\n Mã lỗi: " + ex.Code +
                        "\n Chi tiết: " + ex.Message,
                        "Xác thực không thành công", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (notification)
                    {
                        msgLogs.Text += "\r\n DIGITAL VERIFY FAILED: " + ex.Code + "-" + ex.ToString();
                    }
                    else if (logConfig)
                    {
                        result += "\r\n DIGITAL VERIFY FAILED: " + ex.Code + "-" + ex.ToString();
                    }
                }
                catch (Exception ex)
                {
                    BOSProgressBar.Close();
                    var notificationStr = notification ? " Xem chi tiết ở thông báo" : string.Empty;
                    MessageBox.Show(ex.ToString(), $"Lỗi không xác định khi gọi xác thực.{notificationStr}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (notification)
                    {
                        msgLogs.Text += "\r\n DIGITAL VERIFY FAILED: " + ex.ToString();
                    }
                    else if (logConfig)
                    {
                        result += "\r\n DIGITAL VERIFY FAILED: " + ex.ToString();
                    }
                }
                if (valid)
                {
                    var cerDetail = _digitalSig.GetCerDetailFromPdf(filePath);
                    BOSProgressBar.Close();
                    MessageBox.Show(location + ": \u2714 TOÀN VẸN DỮ LIỆU VÀ CHỮ KÝ HỢP LỆ.\n\n" + cerDetail, "Xác thực toàn vẹn dữ liệu và thông tin chữ ký số", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return result;
        }

        public void MergePdfFromDocx(string dirLocalPdf, string pdfFile, List<MEEmrDocumentsInfo> documents, bool isDownload = true)
        {
            var dotPdf = "." + EmrDocumentFileExtention.pdf.ToString();
            var fileNames = new List<string>();
            foreach (var document in documents)
            {
                Console.WriteLine(document.MEEmrDocumentRefNo);
                if (document.MEEmrDocumentStatus == EmrDocumentStatus.Discarded.ToString() || document.MEEmrDocumentStatus == EmrDocumentStatus.Hidden.ToString())
                    continue;
                string fileName = Path.Combine("Emr", document.FK_MEEmrID.ToString(), document.MEEmrDocumentFile + dotPdf);
                string fileLocal = Path.Combine(_documentPath, fileName);

                if (isDownload)
                {
                    _ftpFileMng.DownloadFile($"/Emr/{document.FK_MEEmrID}/", document.MEEmrDocumentFile + dotPdf, fileLocal);
                }
                fileNames.Add(fileName);
            }
            _pdfProcessor.Merge(Path.Combine(dirLocalPdf, pdfFile + dotPdf), fileNames.ToArray());
        }
        #endregion

    }
}
