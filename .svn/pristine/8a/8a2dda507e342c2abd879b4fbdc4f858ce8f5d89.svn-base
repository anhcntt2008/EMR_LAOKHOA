#region using
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BOSCommon;
using BOSERP.Utilities;
using BOSComponent;
using System.Linq;
using System.Windows.Forms;
using Localization;
using BOSLib;
using DevExpress.XtraEditors;
using BOSERP.Modules.MEDocumentManage.UI;
using System.Configuration;
using Clas.Business.Ftp;
using File = System.IO.File;
using DevExpress.XtraRichEdit;
using Clas.Emr.Ipc.Net.Messaging;
using Clas.Emr.Intergration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraGrid.Views.Grid;
using System.Xml;
using DevExpress.XtraRichEdit.Services;
using System.IO;
using System.Diagnostics;
using Clas.Emr.Model;
using System.Globalization;
using BOSERP.Modules.ME;
using System.Drawing;
using System.Drawing.Printing;
using Clas.Emr.Core;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraPrinting;
using Clas.Business.EmrStore;
using AutoMapper;
using Clas.Model.Mongo;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using BOSERP.Modules.MEDocumentManage;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using MongoDB.Bson.Serialization.Serializers;
using DevExpress.Skins;
using Clas.Model.Domain;
using Emr.Devices.GeV100;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Emr.Pluggable.Plugin;
using Emr.Pluggable.Interface;
using DevExpress.XtraRichEdit.API.Layout;
using Emr.Ca;
using Emr.Ca.Core;
using Emr;
using BOSERP.Modules.ME.Helpers;
using Emr.Document.Pdf;
using BOSERP.Modules.MEEmrAction.UI;
using BOSERP.Modules.MEEmr.UI;
using BOSERP.Modules.MEEmr;
using BOSLib.DataAccess;
#endregion

namespace BOSERP.Modules.MEDocumentManage
{
    public class MEDocumentManageModule : BaseModuleERP
    {
        private MEEmrDocumentsController _emrDocumentCtrl;
        private MEEmrsController _emrCtrl;
        private METemplatesController _templateCtrl;
        private MEEmrArchivesController _archivesCtrl;
        private MEDocumentManageEntities _entity;
        private string _documentPath;
        private BOSMemoEdit _msgLogs;
        private string _macAddress;
        private string _ipAddress;
        private string _hostName;
        private FileTemplateManager _ftpFileMng;
        private PdfProcessor _pdfProcessor;
        private HashProvider _hashProvider;
        private DigitalSignatureProvider _caProvider;
        private IDigitalSignatureBase _digitalSig;
        private EmrHelper _emrHelper;
        private EmrArchiveHelper _archiveHelper;
        private EmrDocumentSortHelper _emrDocumentSortHelper;
        private MEEmrActionsController _emrActionCtrl;
        private MEEmrTemplateActionsController _emrTemplateActionCtrl;

        #region Constant

        #endregion

        #region Variable

        #endregion

        #region Public

        #endregion
        public MEDocumentManageModule()
        {
            Name = "MEDocumentManage";
            CurrentModuleEntity = new MEDocumentManageEntities
            {
                Module = this
            };
            _entity = CurrentModuleEntity as MEDocumentManageEntities;
            _emrDocumentCtrl = new MEEmrDocumentsController();
            _emrCtrl = new MEEmrsController();
            _templateCtrl = new METemplatesController();
            _archivesCtrl = new MEEmrArchivesController();
            _emrActionCtrl = new MEEmrActionsController();
            _emrTemplateActionCtrl = new MEEmrTemplateActionsController();

            InitializeModule();
        }
        public override void InitializeModule()
        {
            base.InitializeModule();
            SetMachineInfo();
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            this._documentPath = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_TEMPLATE_SERVER_PATH);
            if (!_documentPath.Contains(":\\")) // đường dẫn tương đối
                this._documentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + _documentPath;

            _pdfProcessor = new PdfProcessor(_documentPath);
            _ftpFileMng = new FileTemplateManager();
            _hashProvider = new HashProvider(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HASH_ALGORITHM));

            if (!string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserCaIdentity))
            {
                _caProvider = new DigitalSignatureProvider(BOSApp.CurrentCompanyInfo.CSCompanyCaProvider);
                _digitalSig = _caProvider.GetInstance();
            }

            _emrDocumentSortHelper = new EmrDocumentSortHelper();
            _archiveHelper = new EmrArchiveHelper(_documentPath, _pdfProcessor, _ftpFileMng, _hashProvider, _digitalSig);
            _emrHelper = new EmrHelper(_documentPath, _pdfProcessor, _ftpFileMng, _hashProvider, _digitalSig);

            this._msgLogs = this.Controls["txtLogs"] as BOSMemoEdit;

            this._documentPath = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_TEMPLATE_SERVER_PATH);
            if (!_documentPath.Contains(":\\")) // đường dẫn tương đối
                this._documentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + _documentPath;

            var currentEmployeeID = BOSApp.CurrentUsersInfo.FK_HREmployeeID;
            var documents = _emrDocumentCtrl.GetListBusinessObjects<MEEmrDocumentsInfo>(_emrDocumentCtrl.GetAllDataByForeignColumn("FK_EditingUserID", currentEmployeeID));
            _entity.MEEmrDocumentList.Invalidate(documents);

            var today = DateTime.Now.Date;
            var control = (Controls["fld_dteSearchToMEEmrDocumentCreatedDate"] as BOSDateEdit);
            if (control != null) control.EditValue = today;
            control = (Controls["fld_dteSearchFromMEEmrDocumentCreatedDate"] as BOSDateEdit);
            if (control != null) control.EditValue = today.AddMonths(-1);

            control = (Controls["fld_dteErrDocumentToDate"] as BOSDateEdit);
            if (control != null) control.EditValue = today;

            control = (Controls["fld_dteErrDocumentFromDate"] as BOSDateEdit);
            if (control != null) control.EditValue = today.AddMonths(-1);
        }

        private void SetMachineInfo()
        {
            _macAddress = BOSApp.GetMachineMac();
            _ipAddress = BOSApp.GetMachineIp();
            _hostName = System.Net.Dns.GetHostName();
        }

        internal void InvalidateMEEmrDocuments()
        {
            var currentEmployeeID = BOSApp.CurrentUsersInfo.FK_HREmployeeID;
            var documents = _emrDocumentCtrl.GetListBusinessObjects<MEEmrDocumentsInfo>(_emrDocumentCtrl.GetAllDataByForeignColumn("FK_EditingUserID", currentEmployeeID));
            _entity.MEEmrDocumentList.Invalidate(documents);
        }

        public void ReleaseEmrDocuments()
        {
            GridView grid = _entity.MEEmrDocumentList.GridView;
            var rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageBox.Show("Chọn ít nhất 01 tờ bệnh án để thực hiện giải phóng.", "Chưa chọn tờ bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var othersMac = string.Empty;
            foreach (int rowidx in rows)
            {
                var document = grid.GetRow(rowidx) as MEEmrDocumentsInfo;
                if (document.MEEmrDocumentHoldMachineMac != _macAddress)
                {
                    var template = _templateCtrl.GetObjectByID(document.FK_METemplateID) as METemplatesInfo;
                    othersMac += $"{document.MEEmrDocumentSubOrder}. {template.METemplateName} - Mac: {document.MEEmrDocumentHoldMachineMac} - Ip: {document.MEEmrDocumentHoldMachineIp}{Environment.NewLine}";
                }
            }
            if (!string.IsNullOrEmpty(othersMac))
            {
                var confirmMac = MessageBox.Show(othersMac, "Danh sách tờ bệnh án đang được soạn trên máy khác", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirmMac != DialogResult.OK) return;
            }

            var docsInfo = string.Empty;
            foreach (int rowidx in rows)
            {
                var document = grid.GetRow(rowidx) as MEEmrDocumentsInfo;
                var template = _templateCtrl.GetObjectByID(document.FK_METemplateID) as METemplatesInfo;
                docsInfo += $"{document.MEEmrDocumentSubOrder}. {template.METemplateName}{Environment.NewLine}";
            }
            var gui = new guiConfirmWithLongInfo("DANH SÁCH TỜ BỆNH ÁN SẼ GIẢI PHÓNG. Vui lòng xác nhận giải phóng?", docsInfo, "DANH SÁCH TỜ BỆNH ÁN SẼ GIẢI PHÓNG");
            if (gui.ShowDialog() == DialogResult.Cancel) return;

            try
            {
                foreach (int rowidx in rows)
                {
                    var document = grid.GetRow(rowidx) as MEEmrDocumentsInfo;
                    var template = _templateCtrl.GetObjectByID(document.FK_METemplateID) as METemplatesInfo;
                    var uid = $"{document.MEEmrDocumentSubOrder}. {template.METemplateName}";
                    BOSProgressBar.Start($"Đang giải phóng tờ bệnh án: {uid}");
                    AppendLog(LoggingTag.Info, "EMR DOCUMENT RELEASE", $"Đang giải phóng tờ bệnh án: {uid}");
                    ForceReleaseDocument(document);
                    AppendLog(LoggingTag.Info, "EMR DOCUMENT RELEASE", $"Đã giải phóng tờ bệnh án: {uid}");
                }
                BOSProgressBar.Close();
                MessageBox.Show("Danh sách chi tiết các tờ bệnh án đã giải phóng ở màn hình thông báo", "Giải phóng thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InvalidateMEEmrDocuments();
            }
            catch (Exception ex)
            {
                BOSProgressBar.Close();
                MessageBox.Show("Có lỗi xảy ra, xem chi tiết ở màn hình thông báo. "
                     + "\n\nMỘT SỐ TỜ BỆNH ÁN ĐÃ ĐƯỢC GIẢI PHÓNG THÀNH CÔNG."
                    + "\n\nTải lại danh sách tờ bệnh án để tiếp tục. " +
                    "\n\n Chi tiết lỗi: " + ex.ToString(), "Có lỗi xảy ra khi giải phóng tờ bệnh án",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppendLog(LoggingTag.Error, "EMR DOCUMENT RELEASE", ex.ToString());
            }
            finally
            {
                BOSProgressBar.Close();
            }
        }

        public void ForceReleaseDocument(MEEmrDocumentsInfo document)
        {
            if (document != null)
            {
                if (document.FK_EditingUserID > 0)
                {
                    this._emrDocumentCtrl.ForceReleaseEditingPermission(document.MEEmrDocumentID, document.FK_EditingUserID);
                    var objGeObjectHistoryInfo = new GEObjectHistoryInfo
                    {
                        ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                        ADUserName = BOSApp.CurrentUser,
                        GEObjectHistoryAction = cstObjectHistoryActionRevokeEditPer,
                        GEObjectHistoryObjectID = document.MEEmrDocumentID,
                        GEObjectHistoryObjectName = TableName.MEEmrDocumentsTableName,
                        GEObjectHistoryObjectNumber = document.MEEmrDocumentFile,
                        GEObjectHistoryDate = DateTime.Now
                    };
                    _geObjHistoryCtrl.CreateObject(objGeObjectHistoryInfo);
                }
            }
        }

        public void CheckEmrDocuments()
        {
            var guiSearchDocument = new DMDOCMANERRDOC()
            {
                Module = this
            };
            guiSearchDocument.ShowDialog();
        }

        public void AppendLog(string tag, string title, string message)
        {
            var str = "\r\n" + title + " - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff");
            str += "\r\n" + message;
            str += "\r\n";

            if (_msgLogs.InvokeRequired)
                _msgLogs.Invoke((MethodInvoker)delegate { _msgLogs.Text += str; });
            else
                _msgLogs.Text += str;
        }

        #region ADMIN TOOL
        public void RefreshDocument()
        {
            #region Prepare - Validate
            var action = "Làm mới tờ BA đã đóng";
            var docsAction = new List<MEEmrDocumentsInfo>();
            var othersMac = string.Empty;
            var gridControl = this.Controls["fld_dgcMEEmrDocuments"] as MEEmrDocumentToolSelectionGridControl;
            if (gridControl != null)
            {
                var gridView = (gridControl.MainView as GridView);
                var rows = gridView.GetSelectedRows();
                if (rows.Length == 0)
                {
                    MessageBox.Show($"Chọn ít nhất 01 tờ bệnh án đã đóng để làm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                foreach (int rowidx in rows)
                {
                    var document = gridView.GetRow(rowidx) as MEEmrDocumentsInfo;
                    if (document.MEEmrDocumentStatus != EmrDocumentStatus.Closed.ToString())
                    {
                        MessageBox.Show($"Tính năng chỉ áp dụng tờ bệnh án đã đóng. Vui lòng lọc lại điều kiện tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (!string.IsNullOrEmpty(document.MEEmrDocumentHoldMachineMac) && document.MEEmrDocumentHoldMachineMac != _macAddress)
                    {
                        var template = _templateCtrl.GetObjectByID(document.FK_METemplateID) as METemplatesInfo;
                        othersMac += $"{document.MEEmrDocumentSubOrder}. {template.METemplateName} - Mac: {document.MEEmrDocumentHoldMachineMac} - Ip: {document.MEEmrDocumentHoldMachineIp}{Environment.NewLine}";
                    }
                    else
                    {
                        docsAction.Add(document);
                    }
                }
            }

            if (!string.IsNullOrEmpty(othersMac))
            {
                var confirmMac = MessageBox.Show($"Danh sách tờ bệnh án đang được soạn trên máy khác{Environment.NewLine}{othersMac}{Environment.NewLine}[OK] để xử lý các tờ bệnh án khác.{Environment.NewLine}[Cancel] Chọn lại tờ bệnh án.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirmMac != DialogResult.OK) return;
            }

            if (docsAction.Count() == 0)
            {
                MessageBox.Show($"Không có tờ bệnh án đã đóng để làm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            var docsInfo = string.Empty;
            foreach (var document in docsAction)
            {
                var template = _templateCtrl.GetObjectByID(document.FK_METemplateID) as METemplatesInfo;
                docsInfo += $"{document.MEEmrDocumentSubOrder}. {template.METemplateName}{Environment.NewLine}";
            }
            var gui = new guiConfirmWithLongInfo($"DANH SÁCH TỜ BỆNH ÁN ĐÃ ĐÓNG SẼ ĐƯỢC LÀM MỚI. Vui lòng xác nhận?", docsInfo, "Thông báo");
            if (gui.ShowDialog() == DialogResult.Cancel) return;

            var pdf = EmrDocumentFileExtention.pdf.ToString();
            var docx = EmrDocumentFileExtention.docx.ToString();
            var msg = string.Empty;
            #endregion

            try
            {
                var documentGroupByEmrs = docsAction
                                         .GroupBy(u => u.FK_MEEmrID)
                                         .Select(grp => new { EmrID = grp.Key, Documents = grp.ToList() })
                                         .ToList();
                var emrsCheckup = new List<MEEmrsInfo>();
                var emrsDigitalSign = new List<MEEmrsInfo>();
                foreach (var group in documentGroupByEmrs)
                {
                    var emrId = group.EmrID;
                    var emr = _emrCtrl.GetObjectByID(emrId) as MEEmrsInfo;
                    var uidEmr = $"{emrId}. {emr.MEEmrNo}";
                    string serverPath = $"/Emr/{emrId}/";
                    string localPath = string.Format(@"{0}\Emr\{1}\", _documentPath, emrId);
                    var isArchive = false;
                    // Error group => continue another.
                    try
                    {
                        #region EXPORT PDF
                        foreach (var document in group.Documents)
                        {
                            var template = _templateCtrl.GetObjectByID(document.FK_METemplateID) as METemplatesInfo;
                            var uid = $"{document.MEEmrDocumentSubOrder}. {template.METemplateName}";
                            var fileNamePdf = $"{document.MEEmrDocumentFile}.{pdf}";
                            var fileNameDocx = $"{document.MEEmrDocumentFile}.{docx}";
                            if (document.MEEmrDocumentFileExt == EmrDocumentFileExtention.pdf.ToString())
                            {
                                if (_ftpFileMng.FileExists($"/Emr/{document.FK_MEEmrID}/", fileNameDocx))
                                {
                                    #region Checkup: get old page
                                    string filePdfLocalFullPath = Path.Combine(localPath, fileNamePdf);
                                    //_ftpFileMng.DownloadFile(serverPath, fileNamePdf, filePdfLocalFullPath);
                                    var fromCp = Path.Combine(serverPath, fileNamePdf);
                                    var toCp = Path.Combine(serverPath, $"{document.MEEmrDocumentFile}_bkRefresh{DateTime.Now.ToString("MM-dd-yyyy")}.{pdf}");
                                    _ftpFileMng.CopyFile(fromCp, toCp, filePdfLocalFullPath);
                                    var pagePdfPast = _emrHelper.GetNumberOfPdfPages(filePdfLocalFullPath);
                                    #endregion

                                    BOSProgressBar.Start($"{action}: {uid}");
                                    var exportResult = _emrHelper.ExportPdf(document, true, true, false);

                                    if (exportResult["result"] is bool exportResultValue)
                                    {
                                        if (exportResultValue)
                                        {
                                            msg = $"{uidEmr} - {uid} - {exportResult["content"]}";
                                            AppendLog(LoggingTag.Info, "EMR DOCUMENT REFRESH", msg);
                                            HandleLog(LoggingTag.Info, msg);

                                            #region Histories
                                            var objGeObjectHistoryInfoDoc = new GEObjectHistoryInfo
                                            {
                                                ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                                                ADUserName = BOSApp.CurrentUser,
                                                GEObjectHistoryObjectName = TableName.MEEmrDocumentsTableName,
                                                GEObjectHistoryObjectID = document.FK_MEEmrID,
                                                GEObjectHistoryObjectNumber = document.MEEmrDocumentFile,
                                                GEObjectHistoryAction = cstObjectHistoryActionChange,
                                                GEObjectHistoryDate = DateTime.Now,
                                                GEObjectHistoryRemark = $"{BOSApp.CurrentEmployeesInfo.HREmployeeName} xuất lại pdf."
                                            };
                                            _geObjHistoryCtrl.CreateObject(objGeObjectHistoryInfoDoc);
                                            #endregion

                                            #region Checkup
                                            var pagePdfNew = _emrHelper.GetNumberOfPdfPages(filePdfLocalFullPath);
                                            if (pagePdfPast != pagePdfNew)
                                            {
                                                if (!emrsCheckup.Any(m => m.MEEmrID.Equals(emr.MEEmrID)))
                                                {
                                                    emrsCheckup.Add(emr);
                                                }
                                            }
                                            else
                                            {
                                                isArchive = true;
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            throw new Exception(exportResult["content"].ToString());
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception(exportResult["content"].ToString());
                                    }
                                }
                                else
                                {
                                    throw new Exception($"{uidEmr} - {uid} - {fileNameDocx} - Không tìm thấy file");
                                }
                            }
                            // Xu ly file docx sau...
                        }
                        #endregion

                        #region ARCHIVES & DIGITAL SIGN
                        if (isArchive)
                        {
                            var archiveResult = ArchiveEmr(emr, false);
                            if (archiveResult["result"] is bool valueArchive)
                            {
                                if (valueArchive)
                                {
                                    msg = $"{archiveResult["content"]}";
                                    #region DIGITAL SIGN
                                    if (archiveResult["digitalSign"] is bool digitalSign)
                                    {
                                        if (digitalSign)
                                        {
                                            if (!emrsDigitalSign.Any(m => m.MEEmrID.Equals(emr.MEEmrID)))
                                            {
                                                emrsDigitalSign.Add(emr);
                                            }
                                        }
                                    }
                                    #endregion
                                    AppendLog(LoggingTag.Info, "EMR DOCUMENT REFRESH", msg);
                                    HandleLog(LoggingTag.Info, msg);
                                }
                                else
                                {
                                    throw new Exception($"{uidEmr} - {archiveResult["content"]}");
                                }
                            }
                            else
                            {
                                throw new Exception($"{uidEmr} - {archiveResult["content"]}");
                            }
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        msg = $"{uidEmr}: {ex}";
                        AppendLog(LoggingTag.Error, "EMR DOCUMENT REFRESH", msg);
                        HandleLog(LoggingTag.Error, msg);
                    }
                }

                var logPath = Path.Combine(_documentPath, "Logs");
                #region CHECKUP: Thông báo để người dùng kiểm duyêt lại
                if (emrsCheckup.Count() > 0)
                {
                    AppendLog(LoggingTag.Info, "EMR CHECKUP INFO", $"{emrsCheckup.Count()} cần kiểm duyệt lại. Danh sách bên dưới hoặc file logs checkUp ở thư mục: {logPath}");
                    foreach(var item in emrsCheckup)
                    {
                        msg = $"{item.MEEmrID}. {item.MEEmrNo} cần kiểm duyệt lại.";
                        AppendLog(LoggingTag.Info, "EMR CHECKUP", msg);
                        HandleLog("checkUp", msg);
                    }
                }
                #endregion

                if (emrsDigitalSign.Count() > 0)
                {
                    AppendLog(LoggingTag.Info, "EMR DIGITAL SIGN INFO", $"{emrsDigitalSign.Count()} cần ký số lại. Danh sách bên dưới hoặc file logs digitalSign ở thư mục: {logPath}");
                    foreach (var item in emrsDigitalSign)
                    {
                        msg = $"{item.MEEmrID}. {item.MEEmrNo} cần ký số lại.";
                        AppendLog(LoggingTag.Info, "EMR DIGITAL SIGN", msg);
                        HandleLog("digitalSign", msg);
                    }
                }
                
                MessageBox.Show($"Danh sách chi tiết {action} ở màn hình thông báo{Environment.NewLine}Hoặc xem tất cả logs tại thư mục {logPath}", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                AppendLog(LoggingTag.Error, "EMR DOCUMENT RELEASE", ex.ToString());
                HandleLog(LoggingTag.Error, ex.ToString());
                var logPath = Path.Combine(_documentPath, "Logs");
                MessageBox.Show($"Có lỗi xảy ra, xem chi tiết ở màn hình thông báo."
                    + $"{Environment.NewLine}Hoặc xem tất cả logs tại thư mục {logPath}"
                    + $"{Environment.NewLine}Tải lại dữ liệu và thử lại."
                    + $"{Environment.NewLine}Chi tiết lỗi: " + ex.ToString(), 
                    "Thông báo",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            finally
            {
                BOSProgressBar.Close();
            }
        }

        private Dictionary<string, object> ArchiveEmr(MEEmrsInfo emr, bool history)
        {
            var uid = $"{emr.MEEmrID} - {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
            var isDigital = false;
            var archive = _archivesCtrl.GetObjectLastestByEmrId(emr.MEEmrID);
            if (archive == null)
            {
                BOSProgressBar.SetText($"Lưu trữ bệnh án: {uid}. Không thấy thông tin lưu trữ, bỏ qua lưu trữ.");
                return new Dictionary<string, object> {
                            { "result", false },
                            { "digitalSign", isDigital },
                            { "content", $"Lưu trữ bệnh án: {uid}. Không thấy thông tin lưu trữ, bỏ qua lưu trữ." }
                        };
            }

            isDigital = archive.MEEmrArchiveStatus == EmrArchiveStatus.DigitalSigned.ToString();
            try
            {
                BOSProgressBar.Start("Đang lưu trữ bệnh án " + uid + "...");
                CreateArchiveDir(emr.MEEmrID);
                var documents = _emrDocumentCtrl.GetByEmrId(emr.MEEmrID);
                if (documents.Count == 0)
                {
                    BOSProgressBar.SetText($"Lưu trữ bệnh án: {uid}. Bệnh án có 0 tờ. Bỏ qua lưu trữ.");
                    return new Dictionary<string, object> {
                            { "result", false },
                            { "digitalSign", isDigital },
                            { "content", $"Lưu trữ bệnh án: {uid}. Bệnh án có 0 tờ. Bỏ qua lưu trữ." }
                        };
                }
                BOSProgressBar.SetText($"Lưu trữ bệnh án: {uid} ...");
                var orderedDocs = _emrDocumentSortHelper.SortDocumentTree(documents, emr);
                var archiveNew = _archiveHelper.MergeAndArchived(emr, orderedDocs);
                if (archiveNew == null)
                {
                    BOSProgressBar.SetText($"Lưu trữ bệnh án: {uid} không thành công.");
                    return new Dictionary<string, object> {
                            { "result", false },
                            { "digitalSign", isDigital },
                            { "content", $"Lưu trữ bệnh án: {uid} không thành công." }
                        };
                }
                archiveNew.AACreatedUser = BOSApp.CurrentUser;
                archiveNew.AACreatedDate = DateTime.Now;

                if (history)
                {
                    _archivesCtrl.DeleteObject(archive.MEEmrArchiveID);
                    if (isDigital)
                    {
                        archiveNew.MEEmrArchiveStatus = EmrArchiveStatus.Archived.ToString();
                        archiveNew.MEEmrArchiveRemark += $" .{EmrArchiveStatus.DigitalSigned} => {EmrArchiveStatus.Archived}";
                    }
                    _archivesCtrl.CreateObject(archiveNew);
                }
                else
                {
                    archive.MEEmrArchiveFile = archiveNew.MEEmrArchiveFile;
                    archive.MEEmrArchiveFileExt = archiveNew.MEEmrArchiveFileExt;
                    archive.MEEmrArchiveFileHash = archiveNew.MEEmrArchiveFileHash;
                    _archivesCtrl.UpdateObject(archive);
                    if (isDigital)
                    {
                        archive.MEEmrArchiveStatus = EmrArchiveStatus.Archived.ToString();
                        archive.MEEmrArchiveRemark += $" .{EmrArchiveStatus.DigitalSigned} => {EmrArchiveStatus.Archived}";
                        _archivesCtrl.UpdateObject(archive);
                    }
                }

                #region Histories
                var objGeObjectHistoryInfoDoc = new GEObjectHistoryInfo
                {
                    ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                    ADUserName = BOSApp.CurrentUser,
                    GEObjectHistoryObjectName = TableName.MEEmrArchivesTableName,
                    GEObjectHistoryObjectID = archiveNew.FK_MEEmrID,
                    GEObjectHistoryObjectNumber = archiveNew.MEEmrArchiveFile,
                    GEObjectHistoryAction = cstObjectHistoryActionChange,
                    GEObjectHistoryDate = DateTime.Now,
                    GEObjectHistoryRemark = $"{BOSApp.CurrentEmployeesInfo.HREmployeeName} lưu trữ lại."
                };
                _geObjHistoryCtrl.CreateObject(objGeObjectHistoryInfoDoc);
                #endregion

                BOSProgressBar.SetText($"Lưu trữ bệnh án: {uid} thành công");
                return new Dictionary<string, object> {
                            { "result", true },
                            { "digitalSign", isDigital },
                            { "content", $"Lưu trữ bệnh án: {uid} thành công." }
                        };
            }
            catch (Exception ex)
            {
                BOSProgressBar.SetText($"Lưu trữ bệnh án: {uid} không thành công.");
                return new Dictionary<string, object> {
                            { "result", false },
                            { "digitalSign", isDigital },
                            { "content", ex }
                        };
            }
        }

        private void CreateArchiveDir(int emrId)
        {
            var localDir = Path.Combine(_documentPath, _archiveHelper.StorageDir, emrId.ToString());
            if (!Directory.Exists(localDir))
                Directory.CreateDirectory(localDir);
        }

        private void HandleLog(string type, string message)
        {
            var localDir = Path.Combine(_documentPath, "Logs");
            Directory.CreateDirectory(localDir);
            File.AppendAllText($"{localDir}/{type}-{DateTime.Now.ToString("MM-dd-yyyy")}.txt", message + Environment.NewLine);
        }

        public void CallBackAction()
        {
            #region Prepare - Validate
            //var action = "Gọi lại thẻ chức năng";
            var docsAction = new List<MEEmrDocumentsInfo>();
            var othersMac = string.Empty;
            var gridControl = this.Controls["fld_dgcMEEmrDocuments"] as MEEmrDocumentToolSelectionGridControl;
            var templateID = (this.Controls["fld_ccbeMETemplateID"] as MultiColCheckedComboBoxEdit).EditValue;
            if (templateID.ToString().Contains(","))
            {
                MessageBox.Show($"Chỉ được thực hiện trên 1 mẫu bệnh án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (gridControl != null)
            {
                var gridView = (gridControl.MainView as GridView);
                var rows = gridView.GetSelectedRows();
                if (rows.Length == 0)
                {
                    MessageBox.Show($"Chọn ít nhất 01 tờ bệnh án đang thực hiện để gọi lại thẻ chức năng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                foreach (int rowidx in rows)
                {
                    var document = gridView.GetRow(rowidx) as MEEmrDocumentsInfo;
                    if (document.MEEmrDocumentStatus != EmrDocumentStatus.InProgress.ToString())
                    {
                        MessageBox.Show($"Tính năng chỉ áp dụng tờ bệnh án đang thực hiện. Vui lòng lọc lại điều kiện tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (!string.IsNullOrEmpty(document.MEEmrDocumentHoldMachineMac) && document.MEEmrDocumentHoldMachineMac != _macAddress)
                    {
                        var template = _templateCtrl.GetObjectByID(document.FK_METemplateID) as METemplatesInfo;
                        othersMac += $"{document.MEEmrDocumentSubOrder}. {template.METemplateName} - Mac: {document.MEEmrDocumentHoldMachineMac} - Ip: {document.MEEmrDocumentHoldMachineIp}{Environment.NewLine}";
                    }
                    else
                    {
                        docsAction.Add(document);
                    }
                }
            }

            if (!string.IsNullOrEmpty(othersMac))
            {
                var confirmMac = MessageBox.Show($"Danh sách tờ bệnh án đang được soạn trên máy khác{Environment.NewLine}{othersMac}{Environment.NewLine}[OK] để xử lý các tờ bệnh án khác.{Environment.NewLine}[Cancel] Chọn lại tờ bệnh án.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirmMac != DialogResult.OK) return;
            }

            if (docsAction.Count() == 0)
            {
                MessageBox.Show($"Không có tờ bệnh án đang thực hiện để gọi lại thẻ chức năng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            var docsInfo = string.Empty;
            foreach (var document in docsAction)
            {
                var template = _templateCtrl.GetObjectByID(document.FK_METemplateID) as METemplatesInfo;
                docsInfo += $"{document.MEEmrDocumentSubOrder}. {template.METemplateName}{Environment.NewLine}";
            }
            var gui = new guiConfirmWithLongInfo($"DANH SÁCH TỜ BỆNH ÁN ĐANG THỰC HIỆN GỌI LẠI THẺ CHỨC NĂNG. Vui lòng xác nhận?", docsInfo, "Thông báo");
            if (gui.ShowDialog() == DialogResult.Cancel) return;

            var pdf = EmrDocumentFileExtention.pdf.ToString();
            var docx = EmrDocumentFileExtention.docx.ToString();
            var msg = string.Empty;
            #endregion
            var gui2 = new guiMEEmrActionSelection(Convert.ToInt32(templateID))
            {
                Module = this,
                StartPosition = FormStartPosition.CenterParent
            };
            if (gui2.ShowDialog() == DialogResult.OK)
            {
                var SelectedActionID = gui2.SelectedActionID;
                MEEmrModule emrModule = new MEEmrModule();
                var action = this._emrActionCtrl.GetObjectByID(SelectedActionID) as MEEmrActionsInfo;
                //Goi ham chay lai action

            }
        }
        #endregion
    }
}
