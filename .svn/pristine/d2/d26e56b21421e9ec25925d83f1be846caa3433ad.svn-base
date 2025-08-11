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
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.Entity.Model;
using System.Dynamic;
using System.Xml.Linq;
using BOSERP.Modules.MEEmrManage.UI;
using BOSLib.DataAccess;
#endregion

namespace BOSERP.Modules.MEEmrManage
{
    public class MEEmrManageModule : BaseModuleERP
    {
        private MEEmrsController _emrCtrl;
        private MEEmrDocumentsController _emrDocumentCtrl;
        private MEEmrArchivesController _archivesCtrl;
        private FileTemplateManager _ftpFileMng;
        private PdfProcessor _pdfProcessor;
        private HashProvider _hashProvider;
        private EmrArchiveHelper _emrArchiveHelper;
        private EmrHelper _emrHelper;

        private MEEmrManageEntities _entity;
        private string _documentPath;
        private DigitalSignatureProvider _caProvider;
        private IDigitalSignatureBase _digitalSig;
        private BOSMemoEdit _msgLogs;
        private METemplateIndexsController _templateIndexsCtrl;
        private EmrDocumentSortHelper _emrDocumentSortHelper;
        private MEEmrTypesController _emrTypeCtrl;
        private METemplatesController _templateCtrl;
        private METemplateParamsController _templateParamCtrl;
        private GEObjectHistoryController _geObjHistoryCtrl;

        private RichEditControl _richEditCtrl;
        private EmrDocumentHelper _emrDocumentHelper;
        private HashProvider _md5Hasher;
        private MEEmrSumsController _emrSumCtrl;
        private MEParamReportRelationsController _paramReportRelationCtrl;
        private MEParamsController _paramCtrl;
        private MEParamLookupDatasController _paramLookupDataCtrl;
        private EmrDocumentManager _emrDocumentMng;
        private MainHelper _helper;
        private DataAccess _dataHelper;
        private EmrParser _emrParser;
        private LabelControl _msgNotification;
        #region Constant

        #endregion

        #region Variable
        private ApiHelper _apiEmr;
        #endregion

        #region Public

        #endregion
        public MEEmrManageModule()
        {
            Name = "MEEmrManage";
            CurrentModuleEntity = new MEEmrManageEntities
            {
                Module = this
            };
            _entity = CurrentModuleEntity as MEEmrManageEntities;
            InitializeModule();
            _templateIndexsCtrl = new METemplateIndexsController();
            _emrDocumentSortHelper = new EmrDocumentSortHelper();
            _emrTypeCtrl = new MEEmrTypesController();
            _templateCtrl = new METemplatesController();
            _templateParamCtrl = new METemplateParamsController();
            _geObjHistoryCtrl = new GEObjectHistoryController();
            _emrSumCtrl = new MEEmrSumsController();
            _paramReportRelationCtrl = new MEParamReportRelationsController();
            _paramCtrl = new MEParamsController();
            _paramLookupDataCtrl = new MEParamLookupDatasController();
            var thDocMongo = new System.Threading.Thread(() =>
            {
                this._emrDocumentMng = new EmrDocumentManager();
            });
            thDocMongo.Start();
            this._helper = new MainHelper();
        }
        public override void InitializeModule()
        {
            base.InitializeModule();
            this._msgLogs = this.Controls["txtLogs"] as BOSMemoEdit;
            _emrCtrl = new MEEmrsController();
            _emrDocumentCtrl = new MEEmrDocumentsController();
            _archivesCtrl = new MEEmrArchivesController();

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this._documentPath = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_TEMPLATE_SERVER_PATH);
            if (!_documentPath.Contains(":\\")) // đường dẫn tương đối
                this._documentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + _documentPath;
            _ftpFileMng = new FileTemplateManager();
            _pdfProcessor = new PdfProcessor(_documentPath);
            _hashProvider = new HashProvider(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HASH_ALGORITHM));

            this._richEditCtrl = new RichEditControl();
            this._emrDocumentHelper = new EmrDocumentHelper(this._richEditCtrl);
            _md5Hasher = new HashProvider("MD5");

            if (!string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserCaIdentity))
            {
                _caProvider = new DigitalSignatureProvider(BOSApp.CurrentCompanyInfo.CSCompanyCaProvider);
                _digitalSig = _caProvider.GetInstance();
            }

            _emrArchiveHelper = new EmrArchiveHelper(_documentPath, _pdfProcessor, _ftpFileMng, _hashProvider, _digitalSig);
            _emrHelper = new EmrHelper(_documentPath, _pdfProcessor, _ftpFileMng, _hashProvider, _digitalSig);
            var emrEndpoint = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HIS_API_ENDPOINT);
            if (!string.IsNullOrEmpty(emrEndpoint) && !string.IsNullOrEmpty(BOSApp.EmrApiAuthToken))
                _apiEmr = new ApiHelper(emrEndpoint, BOSApp.EmrApiAuthToken, "EMR");

            if (!BOSApp.IsOpenedModule("MEEmr"))
                AppMemCache.InitEmrModuleSessionAsync();

            this._dataHelper = new DataAccess();
            this._emrParser = new EmrParser(this._richEditCtrl, this._msgNotification, this._msgLogs, this._emrDocumentHelper);
            //this._emrActionHelper = new EmrAction(this._richEditCtrl, this._emrDocumentHelper, this._emrParser);
            //this._dataHelper = new DataAccess();
            //this._ftpFileMng = new FileTemplateManager();

            this._richEditCtrl.Options.Authentication.UserName = BOSApp.CurrentUsersInfo.ADUserName;
            this._richEditCtrl.Options.Authentication.Password = this._emrDocumentHelper.ShareEmrPassword;

            //var myCommandFactory = new CustomRichEditCommandFactoryService(this, this._richEditCtrl, this._richEditCtrl.GetService<IRichEditCommandFactoryService>());
            //this._richEditCtrl.ReplaceService<IRichEditCommandFactoryService>(myCommandFactory);

        }
        public void Search(string department, DateTime fromDate, DateTime toDate, string emrNo, object emrTypeId, string patientGroup, DateTime fromDateOut, DateTime toDateOut, string emrStatus = null)
        {
            var stateConds = GetStatePermiQueryConditionStr(TableName.MEEmrsTableName, false);
            var view = string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserEmrView) ? BOSApp.CurrentUserGroupInfo.ADUserGroupEmrView : BOSApp.CurrentUsersInfo.ADUserEmrView;
            Cursor.Current = Cursors.WaitCursor;
            department = department.Replace(", " + BOSApp.CurrentEmployeesInfo.FK_HRDepartmentRoomID + ", ", ", ");
            // 1523 Đã ký CA
            var mEEmrArchiveStatus = 0;
            if (BOSApp.CurrentUserGroupInfo.ADUserGroupRole == UserGroupRole.admin.ToString())
            {
                mEEmrArchiveStatus = 1;
            }
            object[] paramValues = new object[]
            {
                    emrNo,
                    emrStatus,//EmrStatus.InProgress.ToString(),
                    fromDate,
                    toDate,
                    null,
                    emrTypeId,
                    patientGroup,
                    fromDateOut,
                    toDateOut,
                    department,
                    BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID,
                    BOSApp.CurrentEmployeesInfo.HREmployeeID,
                    mEEmrArchiveStatus,
                    view,
                    stateConds
            };
            _entity.MEEmrList.Invalidate(_emrCtrl.Search(paramValues));
        }

        internal void SearchByPatient(object patientId)
        {
            var mEEmrArchiveStatus = 0;
            if (BOSApp.CurrentUserGroupInfo.ADUserGroupRole == UserGroupRole.admin.ToString())
            {
                mEEmrArchiveStatus = 1;
            }
            var stateConds = GetStatePermiQueryConditionStr(TableName.MEEmrsTableName, false);
            var view = string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserEmrView) ? BOSApp.CurrentUserGroupInfo.ADUserGroupEmrView : BOSApp.CurrentUsersInfo.ADUserEmrView;
            var ds = _emrCtrl.QuickSearchWithOneCriteria(
                null,
                patientId,
                BOSApp.CurrentEmployeesInfo.HREmployeeID,
                BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID,
                null,//EmrStatus.InProgress.ToString(),
                mEEmrArchiveStatus,
                view,
                stateConds, string.Empty).Tables[0];
            _entity.MEEmrList.Invalidate(ds);
        }

        public void DeleteEmrs()
        {
            GridView grid = _entity.MEEmrList.GridView;
            var rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageBox.Show("Chọn ít nhất 01 bệnh án để thực hiện xóa.", "Chưa chọn bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            foreach (int rowidx in rows)
            {
                var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                if (emr.MEEmrStatus == EmrStatus.Closed.ToString())
                {
                    MessageBox.Show($"Bệnh án đã đóng không thể xóa {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}", "CÓ BỆNH ÁN ĐÃ ĐÓNG", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (!IsAllowDelete(emr))
                {
                    MessageBox.Show($"Bạn không thể xóa {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo} vì thiếu quyền", "THIẾU QUYỀN XÓA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            var emrNos = string.Empty;
            var i = 1;
            foreach (int rowidx in rows)
            {
                var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                emrNos += $" {i}. {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}\r\n";
                i++;
            }
            var gui = new guiConfirmWithLongInfo("DANH SÁCH BỆNH ÁN SẼ XÓA. Vui lòng xác nhận xóa?", emrNos, "DANH SÁCH BỆNH ÁN SẼ XÓA");
            if (gui.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                foreach (int rowidx in rows)
                {
                    var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                    var uid = $"{emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
                    BOSProgressBar.Start($"Đang xóa bệnh án: {uid}");
                    // auto call _entity.DeleteObjectRelations to delete relations data
                    AppendLog(LoggingTag.Info, "EMR DELETING", $"Đang xóa bệnh án: {uid}");
                    _entity.Delete(emr.MEEmrID);
                    SaveDeleteEmrHistory(emr);
                    AppendLog(LoggingTag.Info, "EMR DELETED", $"Đã xóa bệnh án: {uid}");
                }
                BOSProgressBar.Close();
                MessageBox.Show("Danh sách chi tiết các bệnh án đã xóa ở màn hình thông báo", "Xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                BOSProgressBar.Close();
                MessageBox.Show("Có lỗi xảy ra, xem chi tiết ở màn hình thông báo. "
                     + "\n\nMỘT SỐ BỆNH ÁN ĐÃ ĐƯỢC XÓA THÀNH CÔNG."
                    + "\n\nTải lại danh sách bệnh án để tiếp tục. " +
                    "\n\n Chi tiết lỗi: " + ex.ToString(), "Có lỗi xảy ra khi xóa bệnh án",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppendLog(LoggingTag.Error, "EMR DELETE", ex.ToString());
            }
            finally
            {
                BOSProgressBar.Close();
            }
        }

        private void SaveDeleteEmrHistory(MEEmrsInfo emr)
        {
            var objGeObjectHistoryInfo = new GEObjectHistoryInfo
            {
                ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                ADUserName = BOSApp.CurrentUser,
                GEObjectHistoryAction = cstObjectHistoryActionDelete,
                GEObjectHistoryObjectID = emr.MEEmrID,
                GEObjectHistoryObjectName = TableName.MEEmrsTableName,
                GEObjectHistoryObjectNumber = emr.MEEmrNo,
                GEObjectHistoryDate = DateTime.Now
            };
            _geObjHistoryCtrl.CreateObject(objGeObjectHistoryInfo);
        }

        private void HistoryEmr(MEEmrsInfo emr, string action, string remark)
        {
            var objGeObjectHistoryInfo = new GEObjectHistoryInfo
            {
                ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                ADUserName = BOSApp.CurrentUser,
                GEObjectHistoryObjectName = TableName.MEEmrsTableName,
                GEObjectHistoryObjectID = emr.MEEmrID,
                GEObjectHistoryObjectNumber = emr.MEEmrNo,
                GEObjectHistoryAction = action,
                GEObjectHistoryDate = DateTime.Now,
                GEObjectHistoryRemark = $"{BOSApp.CurrentEmployeesInfo.HREmployeeName} - {remark}."
            };

            _geObjHistoryCtrl.CreateObject(objGeObjectHistoryInfo);
        }

        public override void TriggerWorkflowMulti(object sender, string eventName, object toolbar)
        {
            var toolbarInfo = toolbar as STToolbarsInfo;
            var toolbarCaption = toolbarInfo.STToolbarCaption;
            var toolbarTag = toolbarInfo.STToolbarTag;
            GridView grid = _entity.MEEmrList.GridView;
            var rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageBox.Show("Chọn ít nhất 01 bệnh án để thực hiện.", "Chưa chọn bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            foreach (int rowidx in rows)
            {
                var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                _entity.MainObject = emr;
                if (InvalidateWorkflow(toolbar)) continue;
                MessageBox.Show($"Vui lòng kiểm tra trạng thái bệnh án {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}.", "KIỂM TRA TRẠNG THÁI BỆNH ÁN", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            var emrNos = string.Empty;
            var i = 1;
            foreach (int rowidx in rows)
            {
                var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                emrNos += $" {i}. {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}\r\n";
                i++;
            }
            var gui = new guiConfirmWithLongInfo("DANH SÁCH BỆNH ÁN SẼ XỬ LÝ. Vui lòng xác nhận?", emrNos, "DANH SÁCH BỆNH ÁN SẼ XỬ LÝ");

            if (gui.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                var ls = new List<MEEmrsInfo>();
                foreach (int rowidx in rows)
                {
                    var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                    var uid = $"{emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
                    BOSProgressBar.Start($"Đang xử lý {toolbarCaption}: {uid}");
                    AppendLog(LoggingTag.Info, "EMR " + toolbarTag.ToUpper() + " PROCESSING", $"Đang xử lý {toolbarCaption}: {uid}");

                    _entity.MainObject = emr;
                    base.TriggerWorkflowMulti(sender, eventName, toolbar);
                    ls.Add(emr);
                    AppendLog(LoggingTag.Info, "EMR " + toolbarTag.ToUpper() + " COMPLETED", $"Đã {toolbarCaption}: {uid}");
                }
                _entity.MEEmrList.Invalidate(ls);
                BOSProgressBar.Close();
                MessageBox.Show("Danh sách chi tiết kết quả ở màn hình thông báo", toolbarCaption + " thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                BOSProgressBar.Close();
                MessageBox.Show("Có lỗi xảy ra, xem chi tiết ở màn hình thông báo. "
                                + "\n\nTải lại danh sách bệnh án để tiếp tục. " +
                    "\n\n Chi tiết lỗi: " + ex.ToString(), "Có lỗi xảy ra khi {toolbarCaption}",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppendLog(LoggingTag.Error, "EMR {toolbarTag}", ex.ToString());
            }
            finally
            {
                BOSProgressBar.Close();
            }
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

        #region Archive Emr
        public void ArchiveEmrs()
        {
            GridView grid = _entity.MEEmrList.GridView;
            var rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageBox.Show("Chọn ít nhất 01 bệnh án để thực hiện Lưu trữ.", "Chưa chọn bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            foreach (int rowidx in rows)
            {
                var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                if (emr.MEEmrStatus != EmrStatus.Closed.ToString())
                {
                    MessageBox.Show($"Bệnh án chưa đóng không thể lưu trữ {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}", "CÓ BỆNH ÁN CHƯA ĐÓNG", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            var emrNos = string.Empty;
            var i = 1;
            foreach (int rowidx in rows)
            {
                var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                emrNos += $" {i}. {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
                if (string.IsNullOrEmpty(emr.MEEmrArchiveNo))
                    emrNos += $" [Không có SỐ LƯU TRỮ] ";

                if (emr.MEEmrDateOut == null || emr.MEEmrDateOut.Year == 9999)
                    emrNos += $" [Không có NGÀY RA VIỆN] ";

                emrNos += "\r\n";
                i++;
            }
            var gui = new guiConfirmWithLongInfo("DANH SÁCH BỆNH ÁN SẼ LƯU TRỮ. Vui lòng xác nhận?", emrNos, "DANH SÁCH BỆNH ÁN SẼ LƯU TRỮ");
            if (gui.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                foreach (int rowidx in rows)
                {
                    var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                    var uid = $"{emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
                    BOSProgressBar.Start($"Đang lưu trữ bệnh án: {uid}");
                    AppendLog(LoggingTag.Info, "EMR ARCHIVING", $"Đang lưu trữ bệnh án: {uid}");
                    this.ArchiveEmr(emr);
                    AppendLog(LoggingTag.Info, "EMR ARCHIVED", $"Đã xử lý bệnh án: {uid}");
                }
                BOSProgressBar.Close();
                MessageBox.Show("Danh sách chi tiết các bệnh án đã lưu trữ ở màn hình thông báo.", "Lưu trữ thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                BOSProgressBar.Close();
                MessageBox.Show("Có lỗi xảy ra, xem chi tiết ở màn hình thông báo."
                    + "\n\nMỘT SỐ BỆNH ÁN ĐÃ ĐƯỢC LƯU TRỮ THÀNH CÔNG."
                    + "\n\nTải lại danh sách bệnh án để tiếp tục. " +
                    "\n\n Chi tiết lỗi" + ex.ToString(), "Có lỗi xảy ra khi lưu trữ bệnh án",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppendLog(LoggingTag.Error, "EMR ARCHIVE", ex.ToString());
            }
            finally
            {
                BOSProgressBar.Close();
            }
        }

        private void ArchiveEmr(MEEmrsInfo emr)
        {
            CreateArchiveDir(emr.MEEmrID);
            var documents = _emrDocumentCtrl.GetByEmrId(emr.MEEmrID);
            var uid = $"{emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
            if (documents.Count == 0)
            {
                AppendLog(LoggingTag.Info, "EMR ARCHIVING", $"Bệnh án có 0 tờ bệnh án không lưu trữ được đã bỏ qua: {uid}");
                return;
            }
            var orderedDocs = _emrDocumentSortHelper.SortDocumentTree(documents, emr);
            var archive = _emrArchiveHelper.MergeAndArchived(emr, orderedDocs);
            if (archive == null) return;
            archive.AACreatedUser = BOSApp.CurrentUser;
            archive.AACreatedDate = DateTime.Now;
            _archivesCtrl.CreateObject(archive);
        }
        private void CreateArchiveDir(int emrId)
        {
            var localDir = Path.Combine(_documentPath, _emrArchiveHelper.StorageDir, emrId.ToString());
            if (!Directory.Exists(localDir))
                Directory.CreateDirectory(localDir);
        }
        #endregion

        #region Group Archive Emr
        public void GroupArchiveEmrs()
        {
            GridView grid = _entity.MEEmrList.GridView;
            var rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageBox.Show("Chọn ít nhất 01 bệnh án để thực hiện Tổng hợp bệnh án.", "Chưa chọn bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var errorEmrs = new List<string>();
            foreach (int rowidx in rows)
            {
                var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                if (emr.MEEmrDateOut.Year == DateTime.MaxValue.Year)
                {
                    errorEmrs.Add($"+ {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}");
                }
            }

            if (errorEmrs.Count > 0)
            {
                MessageBox.Show($"Bệnh án thiếu thông tin xuất viện\n\n" + string.Join("\n", errorEmrs) + "\nSẼ VẪN THỰC HIỆN TỔNG HỢP CÁC BỆNH ÁN NÀY.",
                    "[CẢNH BÁO] BỆNH ÁN THIẾU THÔNG TIN XUẤT VIỆN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                var localDirs = new List<string>(); // Show folder
                var errorsMsg = new List<string>();// show error
                foreach (int rowidx in rows)
                {
                    var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                    var uid = $"{emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
                    var archive = _archivesCtrl.GetObjectLastestByEmrId(emr.MEEmrID);
                    if (archive != null)
                    {
                        var localDir = Path.Combine(_documentPath, "Downloads", _emrArchiveHelper.StorageDir, $"{emr.MEEmrDateOut.ToString("ddMMyyyy")}");
                        if (!Directory.Exists(localDir))
                        {
                            Directory.CreateDirectory(localDir);
                        }
                        BOSProgressBar.Start($"Đang tổng hợp lưu trữ bệnh án: {uid}");
                        AppendLog(LoggingTag.Info, "GROUP EMR ARCHIVING", $"Đang tổng hợp lưu trữ bệnh án: {uid}");
                        var serverPath = $"/{_emrArchiveHelper.StorageDir}/{emr.MEEmrID}/";
                        var serverFile = $"{archive.MEEmrArchiveFile}.{archive.MEEmrArchiveFileExt}";
                        var patientName = Emr.SanitizedFileName.Sanitize(emr.MEPatientName.Trim(), ".");
                        string localFileName = $"{localDir}/{patientName}_{serverFile}";
                        try
                        {
                            DirectoryInfo dirLocalArchive = new DirectoryInfo(localDir);
                            var archiveFile = $"{patientName}_{Emr.SanitizedFileName.Sanitize(emr.MEEmrNo, ".")}_*";
                            var filesLocal = dirLocalArchive.GetFileSystemInfos(archiveFile);
                            foreach (FileSystemInfo file in filesLocal)
                            {
                                file.Delete();
                            }
                            _ftpFileMng.DownloadFile(serverPath, serverFile, localFileName);
                            AppendLog(LoggingTag.Info, "GROUP EMR ARCHIVED", $"Đã xử lý tổng hợp lưu trữ bệnh án: {uid} {localFileName}");
                            if (!localDirs.Contains(localDir))
                            {
                                localDirs.Add(localDir);
                            }
                        }
                        catch (Exception ex)
                        {
                            var message = $"Không tải được file lưu trữ bệnh án từ máy chủ. {uid} {serverFile}";
                            AppendLog(LoggingTag.Error, "GROUP EMR ARCHIVED", message);
                            Trace.TraceError("GroupArchiveEmrs.FtpFileMng.DownloadFile ERROR: {0}:{1}:{2}:{3}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), BOSApp.CurrentUser, ex, serverFile);
                            Trace.Flush();
                            MessageBox.Show(message, "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorsMsg.Add(message);
                        }
                    }
                    else
                    {
                        var message = $"{uid} chưa được lưu trữ.";
                        AppendLog(LoggingTag.Warning, "GROUP EMR ARCHIVED", message);
                        errorsMsg.Add(message);
                    }
                }
                BOSProgressBar.Close();
                var outputFolder = string.Empty;
                foreach (var folder in localDirs)
                {
                    outputFolder += folder + Environment.NewLine;
                }

                var msgFolder = !string.IsNullOrEmpty(outputFolder) ? $"{Environment.NewLine}Danh sách đã tổng hợp lưu ở thư mục:{Environment.NewLine}{outputFolder}" : string.Empty;
                var msgError = errorsMsg.Count() > 0 ? $"{Environment.NewLine}Danh sách chưa tổng hợp:{Environment.NewLine}{string.Join(Environment.NewLine, errorsMsg)}" : string.Empty;

                MessageBox.Show($"Chi tiết quá trình Tổng hợp bệnh án ở màn hình 'Thông báo'." + msgFolder + msgError,
                    "Tổng hợp bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                BOSProgressBar.Close();
                MessageBox.Show("Có lỗi xảy ra, xem chi tiết ở màn hình 'Thông báo'."
                    + "\n\nTải lại danh sách bệnh án để tiếp tục. " +
                    "\n\n Chi tiết lỗi " + ex.ToString(),
                    "Có lỗi xảy ra khi tổng hợp lưu trữ bệnh án",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppendLog(LoggingTag.Error, "GROUP EMR ARCHIVE", ex.ToString());
                Trace.TraceError("GroupArchiveEmrs ERROR: {0}:{1}:{2}:{3}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), BOSApp.CurrentUser, ex);
                Trace.Flush();
            }
            finally
            {
                BOSProgressBar.Close();
            }
        }
        #endregion

        #region PDF
        public void PdfExport()
        {
            var action = "Xuất pdf";
            GridView grid = _entity.MEEmrList.GridView;
            var rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageBox.Show($"Chọn ít nhất 01 bệnh án để thực hiện {action}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var statusLst = new List<string>
            {
                EmrStatus.InProgress.ToString(),
                EmrStatus.WaitClose.ToString()
            };
            foreach (int rowidx in rows)
            {
                var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                if (!statusLst.Contains(emr.MEEmrStatus))
                {
                    MessageBox.Show($"Chức năng chỉ áp dụng cho những bệnh án đang mở và bệnh án chờ đóng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            try
            {
                var dirLocalPdf = PdfExportGetDir();
                var emrs = new List<MEEmrsInfo>();
                foreach (int rowidx in rows)
                {
                    var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                    emrs.Add(emr);
                }

                BOSProgressBar.Start($"Đang xuất pdf...");
                AppendLog(LoggingTag.Info, "EXPORTING PDF", $"Đang xuất pdf...");
                var isPdfOk = PdfExportLocal(emrs);
                if (isPdfOk)
                {
                    foreach (int rowidx in rows)
                    {
                        var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                        this.MergePdf(emr, dirLocalPdf);
                        AppendLog(LoggingTag.Info, "EXPORTED PDF", $"{SanitizedFileName.Sanitize(emr.MEPatientName, ".")}_{SanitizedFileName.Sanitize(emr.MEEmrNo, ".")} xuất pdf thành công.");
                    }
                    BOSProgressBar.Close();
                    AppendLog(LoggingTag.Info, "EXPORTED PDF", $"Xuất pdf thành công. Đường dẫn: { dirLocalPdf}");
                    MessageBox.Show($"Đường dẫn chứa các tệp tin pdf của bệnh án: {dirLocalPdf}.{Environment.NewLine}" +
                        $"Chi tiết vui lòng xem tại màn hình 'Thông báo'", $"{action} thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                BOSProgressBar.Close();
                MessageBox.Show($"Có lỗi xảy ra, xem chi tiết ở màn hình 'Thông báo'.{Environment.NewLine}"
                    + $"Tải lại danh sách bệnh án để tiếp tục.{Environment.NewLine}"
                    + $"Chi tiết lỗi {ex.ToString()}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppendLog(LoggingTag.Error, "EXPORT PDF", ex.ToString());
            }
            finally
            {
                BOSProgressBar.Close();
            }
        }

        // Use API. No use until 22 Dec 2020
        private bool PdfExportAPI(List<int> ids)
        {
            if (_apiEmr != null)
            {
                var actionUri = BOSApp.GetSystemConfigValue(SysCfgConsts.EMR_API_ENDPOINT, SysCfgConsts.EMR_PDF_EXPORT);
                if (!string.IsNullOrEmpty(actionUri))
                {
                    var paramList = new Dictionary<string, object>
                    {
                        { "ids",  ids }
                    };
                    var response = _apiEmr.Post<Emr.Base.Models.Abp.AjaxResponse, JValue>(actionUri, null, paramList);
                    if (response != null)
                    {
                        if (response.Success)
                        {
                            AppendLog(LoggingTag.Info, "EXPORTED PDF", $"API đã chuyển định dạng thành công");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi phát sinh, xem ở màn hình Thông báo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            AppendLog(LoggingTag.Error, "EXPORTED PDF", response.Error != null ? response.Error.Message : "Api EMR lỗi.");
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        // Đảm bảo pdf phải có ở local
        public bool PdfExportLocal(List<MEEmrsInfo> emrs)
        {
            var result = true;
            var docExt = EmrDocumentFileExtention.docx.ToString();
            var pdfExt = EmrDocumentFileExtention.pdf.ToString();
            try
            {
                foreach (var emr in emrs)
                {
                    var documents = _emrDocumentCtrl.GetListBusinessObjects<MEEmrDocumentsInfo>(_emrDocumentCtrl.GetByMEEmrID(emr.MEEmrID));
                    foreach (var document in documents)
                    {
                        BOSProgressBar.SetText(document.MEEmrDocumentFile);
                        string filePath = string.Format(@"{0}\Emr\{1}\{2}.{3}", _documentPath, document.FK_MEEmrID, document.MEEmrDocumentFile, pdfExt);
                        if (document.MEEmrDocumentFileExt == pdfExt)
                        {
                            _ftpFileMng.DownloadFile($"/Emr/{document.FK_MEEmrID}/", $"{document.MEEmrDocumentFile}.{pdfExt}", filePath);
                            AppendLog(LoggingTag.Info, "EXPORT PDF", $"Đã tải {filePath}");
                        }
                        else
                        {
                            if (document.MEEmrDocumentStatus != EmrDocumentStatus.InProgress.ToString()) continue;
                            if (document.MEEmrDocumentFileExt != docExt) continue;

                            var exportResult = _emrHelper.ExportPdf(document, false, true, false);

                            if (exportResult["result"] is bool exportResultValue)
                            {
                                if (exportResultValue)
                                {
                                    AppendLog(LoggingTag.Info, "EXPORT PDF", $"{exportResult["content"]}");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AppendLog(LoggingTag.Error, "EXPORT PDF", ex.ToString());
                result = false;
            }
            return result;
        }

        #region function from MEEmrModule
        public void DownAndLoadDocx(RichEditControl richCtrl, MEEmrDocumentsInfo document)
        {
            try
            {
                var filePath = DownloadFtpFile(document);
                if (!File.Exists(filePath))
                {
                    MessageBox.Show(("File bệnh án không tồn tại ở địa chỉ. " + filePath), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (OfficeOpenXmlCrypto.OfficeCryptoStream stream = OfficeOpenXmlCrypto.OfficeCryptoStream.Open(filePath, _emrDocumentHelper.ShareEmrPassword))
                {
                    richCtrl.LoadDocument(stream, DocumentFormat.OpenXml);
                }
            }
            catch (OfficeOpenXmlCrypto.InvalidPasswordException)
            {
                MessageBox.Show("Có thể đã có lỗi trong quá trình mã hóa và upload tờ bệnh án. Không mở được tập tin.", "Không giải mã được tờ bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public string DownloadFtpFile(MEEmrDocumentsInfo document)
        {
            string filePath = string.Format(@"{0}\Emr\{1}\{2}.{3}", _documentPath, document.FK_MEEmrID, document.MEEmrDocumentFile, document.MEEmrDocumentFileExt);
            _ftpFileMng.DownloadFile($"/Emr/{document.FK_MEEmrID}/", document.MEEmrDocumentFile + "." + document.MEEmrDocumentFileExt, filePath);
            return filePath;
        }
        #endregion

        private void MergePdf(MEEmrsInfo emr, string dirLocalPdf)
        {
            var pdfFile = $"{SanitizedFileName.Sanitize(emr.MEPatientName, ".")}_{SanitizedFileName.Sanitize(emr.MEEmrNo, ".")}";
            var documents = _emrDocumentCtrl.GetByEmrId(emr.MEEmrID);
            var orderedDocs = _emrDocumentSortHelper.SortDocumentTree(documents, emr);
            _emrArchiveHelper.MergePdfFromDocx(dirLocalPdf, pdfFile, orderedDocs, false);
        }

        private string PdfExportGetDir()
        {
            var localDir = Path.Combine(_documentPath, "Downloads", "Export", DateTime.Now.ToString("ddMMyyyy"));
            Directory.CreateDirectory(localDir);
            return localDir;
        }
        #endregion

        public void DigitalSignArchiveEmrs()
        {
            try
            {
                GridView grid = _entity.MEEmrList.GridView;
                var selectList = grid.GetSelectedRows();
                if (selectList.Length == 0)
                {
                    MessageBox.Show("Chọn ít nhất 01 bệnh án để thực hiện Ký số.", "Chưa chọn bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                var emrNos = string.Empty;
                var i = 1;
                var archiveList = new List<MEEmrArchivesInfo>();
                var emrList = new List<MEEmrsInfo>();
                foreach (int rowidx in selectList)
                {
                    var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                    emrNos += $" {i}. {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
                    var archive = _archivesCtrl.GetObjectLastestByEmrId(emr.MEEmrID);
                    if (archive == null)
                    {
                        emrNos += $" [CHƯA LƯU TRỮ] [BỎ QUA]";
                    }
                    else if (archive.MEEmrArchiveStatus == EmrArchiveStatus.DigitalSigned.ToString())
                    {
                        emrNos += $" [ĐÃ KÝ SỐ] [BỎ QUA]";
                    }
                    else
                    {
                        archiveList.Add(archive);
                        emrList.Add(emr);
                    }
                    emrNos += "\r\n";
                    i++;
                }

                var gui = new guiConfirmWithLongInfo("DANH SÁCH BỆNH ÁN SẼ THỰC HIỆN KÝ SỐ. Vui lòng xác nhận?", emrNos, "DANH SÁCH BỆNH ÁN SẼ THỰC HIỆN KÝ SỐ");
                if (gui.ShowDialog() == DialogResult.Cancel)
                    return;
                int errorCount = 0;
                int successCount = 0;
                int index = 0;
                BOSProgressBar.Start($"Đang xử lý");
                if (BOSApp.CurrentCompanyInfo.CSCompanyCaProvider == CaProviders.VNPT_CA)
                {
                    if (archiveList.Count == 0 || emrList.Count == 0)
                        return;
                    if (archiveList.Count > 50)
                    {
                        MessageBox.Show("Chỉ được chọn tối đa 50 bệnh án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (emrList.Select(emr => emr.FK_MEEmrTypeID).Distinct().Count() > 1)
                    {
                        MessageBox.Show("Chỉ được chọn cùng loại bệnh án", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    
                    var emrType = _emrTypeCtrl.GetObjectByID(emrList.FirstOrDefault().FK_MEEmrTypeID) as MEEmrTypesInfo;
                    var page = emrType.MEEmrTypeDgtSignaturePage <= 0 ? 1 : emrType.MEEmrTypeDgtSignaturePage;
                    List<string> listFilePath = new List<string>();
                    foreach (var archive in archiveList)
                    {
                        try
                        {
                            var emr = emrList.Where(e => e.MEEmrID == archive.FK_MEEmrID).FirstOrDefault();
                            CreateArchiveDir(emr.MEEmrID);
                            var dotExt = "." + archive.MEEmrArchiveFileExt;
                            string fileName = archive.MEEmrArchiveFile + dotExt;
                            string filePath = Path.Combine(_documentPath, _emrArchiveHelper.StorageDir, emr.MEEmrID.ToString(), fileName);
                            if (_ftpFileMng.FileExists($"/{_emrArchiveHelper.StorageDir}/{emr.MEEmrID}/", fileName))
                            {
                                _ftpFileMng.DownloadFile($"/{_emrArchiveHelper.StorageDir}/{emr.MEEmrID}/", fileName, filePath);
                            }
                            else
                            {
                                _ftpFileMng.DownloadFile($"/Emr/{emr.MEEmrID}/", fileName, filePath);
                            }
                            listFilePath.Add(filePath);
                            //AppendLog(LoggingTag.Info, uid + " [ĐÃ KÝ]", string.Empty);
                            //successCount++;
                        }
                        catch (Exception ex)
                        {
                            //errorCount++;
                            //AppendLog(LoggingTag.Error, uid + " [KÝ LỖI]", ex.ToString());
                        }
                    }
                    List<MEEmrArchivesInfo> listMEEmrArchivesInfo = _emrArchiveHelper.DigitalSignListEmrArchivePdf(emrList, archiveList, emrType, page, string.Empty);
                    if (listMEEmrArchivesInfo.Count > 0)
                    {
                        successCount = listMEEmrArchivesInfo.Count();
                    }
                    else
                    {
                        errorCount = archiveList.Count();
                    }
                    foreach (var filePath in listFilePath)
                    {
                        File.Delete(filePath);
                    }
                    MessageBox.Show($"Thống kê: [{successCount} thành công]/[{errorCount} lỗi]",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (var archive in archiveList)
                    {
                        var emr = emrList.Where(e => e.MEEmrID == archive.FK_MEEmrID).FirstOrDefault();
                        var uid = $"{emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
                        try
                        {
                            index++;
                            BOSProgressBar.SetText($"Đang xử lý [{index}/{emrList.Count}]: {uid}");
                            var emrType = _emrTypeCtrl.GetObjectByID(emr.FK_MEEmrTypeID) as MEEmrTypesInfo;
                            var page = emrType.MEEmrTypeDgtSignaturePage <= 0 ? 1 : emrType.MEEmrTypeDgtSignaturePage;
                            CreateArchiveDir(emr.MEEmrID);
                            var dotExt = "." + archive.MEEmrArchiveFileExt;
                            string fileName = archive.MEEmrArchiveFile + dotExt;
                            string filePath = Path.Combine(_documentPath, _emrArchiveHelper.StorageDir, emr.MEEmrID.ToString(), fileName);
                            if (_ftpFileMng.FileExists($"/{_emrArchiveHelper.StorageDir}/{emr.MEEmrID}/", fileName))
                            {
                                _ftpFileMng.DownloadFile($"/{_emrArchiveHelper.StorageDir}/{emr.MEEmrID}/", fileName, filePath);
                            }
                            else
                            {
                                _ftpFileMng.DownloadFile($"/Emr/{emr.MEEmrID}/", fileName, filePath);
                            }
                            _emrArchiveHelper.DigitalSignEmrArchivePdf(emr, archive, emrType, page, string.Empty);
                            File.Delete(filePath);
                            AppendLog(LoggingTag.Info, uid + " [ĐÃ KÝ]", string.Empty);
                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            errorCount++;
                            AppendLog(LoggingTag.Error, uid + " [KÝ LỖI]", ex.ToString());
                        }
                    }
                    MessageBox.Show($"Danh sách chi tiết các bệnh án đã ký số ở [màn hình thông báo].\nThống kê: [{successCount} thành công]/[{errorCount} lỗi]",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SignerCustomException ex)
            {
                if (ex.Code == -1)
                {
                    MessageBox.Show(ex.Message, $"[KẾT QUẢ TỪ MÁY CHỦ KÝ SỐ CA]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                BOSProgressBar.Close();
            }
        }
        public void ReCloseEmrs()
        {
            GridView grid = _entity.MEEmrList.GridView;
            var selectList = grid.GetSelectedRows();
            if (selectList.Length == 0)
            {
                MessageBox.Show("Chọn ít nhất 01 bệnh án để thực hiện.", "Chưa chọn bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var emrNos = string.Empty;
            var i = 1;
            var emrList = new List<MEEmrsInfo>();
            foreach (int rowidx in selectList)
            {
                var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                emrNos += $" {i}. {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
                if (emr.MEEmrStatus != EmrStatus.Closed.ToString())
                {
                    emrNos += $" [CHƯA ĐÓNG] [BỎ QUA]";
                }
                else
                {
                    emrList.Add(emr);
                }
                emrNos += "\r\n";
                i++;
            }

            var gui = new guiConfirmWithLongInfo("DANH SÁCH BỆNH ÁN SẼ THỰC HIỆN ĐÓNG LẠI. Vui lòng xác nhận?", emrNos, "DANH SÁCH BỆNH ÁN SẼ THỰC HIỆN KÝ SỐ");
            if (gui.ShowDialog() == DialogResult.Cancel)
                return;
            var template = _templateCtrl.GetObjectByNo("TDT") as METemplatesInfo;
            if (template == null) return;

            var richEditCtrl = new RichEditControl();
            EmrDocumentHelper emrDocumentHelper = new EmrDocumentHelper(richEditCtrl);
            var templateParamsPath = AppMemCache.GetTemplateParamsDictPath(template.METemplateID);
            var templateParams = AppMemCache.GetTemplateParams(template.METemplateID);
            emrDocumentHelper.SetTemplateParamList(templateParams, templateParamsPath);

            int errorCount = 0;
            int successCount = 0;
            int index = 0;
            richEditCtrl.CreateNewDocument(false);
            BOSProgressBar.Start($"Đang xử lý");
            foreach (var emr in emrList)
            {
                CreateEmrLocalDir(emr.MEEmrID);
                var uid = $"{emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
                try
                {
                    index++;
                    BOSProgressBar.SetText($"Đang xử lý [{index}/{emrList.Count}]: {uid}");
                    var listDocs = _emrDocumentCtrl.GetListBusinessObjects<MEEmrDocumentsInfo>(_emrDocumentCtrl.GetByMEEmrID(emr.MEEmrID));
                    foreach (var item in listDocs)
                    {
                        if (item.FK_METemplateID == template.METemplateID)
                        {
                            if (item.MEEmrDocumentFileExt == EmrDocumentFileExtention.pdf.ToString())
                            {
                                // bo qua cac to an va huy
                                if (item.MEEmrDocumentStatus == EmrDocumentStatus.Discarded.ToString()
                                    || item.MEEmrDocumentStatus == EmrDocumentStatus.Hidden.ToString())
                                {
                                    continue;
                                }
                                string fileDocx = string.Format(@"{0}\Emr\{1}\{2}.docx", _documentPath, item.FK_MEEmrID, item.MEEmrDocumentFile);
                                _ftpFileMng.DownloadFile($"/Emr/{item.FK_MEEmrID}/", item.MEEmrDocumentFile + ".docx", fileDocx);
                                using (OfficeOpenXmlCrypto.OfficeCryptoStream stream = OfficeOpenXmlCrypto.OfficeCryptoStream.Open(fileDocx, emrDocumentHelper.ShareEmrPassword))
                                {
                                    richEditCtrl.LoadDocument(stream, DocumentFormat.OpenXml);
                                }
                                this.RemoveAllForPrint(richEditCtrl, template, emrDocumentHelper, templateParams);
                                string fileName = string.Format(@"{0}\Emr\{1}\{2}.{3}", _documentPath, item.FK_MEEmrID, item.MEEmrDocumentFile, EmrDocumentFileExtention.pdf.ToString());
                                richEditCtrl.ExportToPdf(fileName);
                                _ftpFileMng.UploadFile($"/Emr/{item.FK_MEEmrID}/", item.MEEmrDocumentFile + "." + EmrDocumentFileExtention.pdf.ToString(), fileName);
                                item.AAUpdatedUser = BOSApp.CurrentUser;
                                item.MEEmrDocumentDesc += $" [{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}] Chuyển PDF sau khi đóng.";
                                _emrDocumentCtrl.UpdateObject(item);
                            }
                        }
                    }
                    AppendLog(LoggingTag.Info, uid + " [ĐÃ XỬ LÝ]", string.Empty);
                    successCount++;
                }
                catch (Exception ex)
                {
                    errorCount++;
                    AppendLog(LoggingTag.Error, uid + " [LỖI - BỎ QUA]", ex.ToString());
                }
            }
            BOSProgressBar.Close();
            MessageBox.Show($"Danh sách chi tiết các bệnh án đã xử lý ở [màn hình thông báo].\nThống kê: [{successCount} thành công]/[{errorCount} lỗi]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CreateEmrLocalDir(int emrId)
        {
            string localDir = string.Format(@"{0}\Emr\{1}\", _documentPath, emrId);
            if (!Directory.Exists(localDir))
                Directory.CreateDirectory(localDir);

            localDir = string.Format(@"{0}\Emr\Partials\{1}\", _documentPath, emrId);
            if (!Directory.Exists(localDir))
                Directory.CreateDirectory(localDir);

            localDir = string.Format(@"{0}\Emr\Signed\{1}\", _documentPath, emrId);
            if (!Directory.Exists(localDir))
                Directory.CreateDirectory(localDir);
        }
        public void RemoveAllForPrint(RichEditControl richContrl, METemplatesInfo template,
            EmrDocumentHelper emrDocumentHelper, List<METemplateParamsInfo> templateParams)
        {
            this.RemoveAllTagForPrint(richContrl, template);
            this.RemoveAllCommentForPrint(richContrl);
            if (templateParams.FirstOrDefault()?.FK_METemplateID == template.METemplateID)
                emrDocumentHelper.RemoveAllHiddenDataForPrint(richContrl, template.METemplateID);
            else
            {
                templateParams = _templateParamCtrl.GetAllTemplateParamObjectByTemplateID(template.METemplateID);
                emrDocumentHelper.RemoveAllHiddenDataForPrint(richContrl, template.METemplateID, templateParams);
            }
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

        #region History
        public void HistorySearch(DateTime fromDate, DateTime toDate, string emrNo, string statusAction)
        {
            Cursor.Current = Cursors.WaitCursor;
            object[] paramValues = new object[]
            {
                    TableName.MEEmrsTableName,
                    emrNo,
                    fromDate,
                    toDate,
                    statusAction
            };

            var data = _geObjHistoryCtrl.GetListBusinessObjects<GEObjectHistoryInfo>(_geObjHistoryCtrl.Search(paramValues));
            //var data = _geObjHistoryCtrl.Search(paramValues);
            var gridControlEmrRelations = this.Controls["fld_dgcGEObjectHistory"] as GEObjectHistoryGridControl;
            if (gridControlEmrRelations != null)
            {
                gridControlEmrRelations.DataSource = data;
                gridControlEmrRelations.RefreshDataSource();
                gridControlEmrRelations.Refresh();
            }
        }

        internal void HistorySearchByPatient(object patientId)
        {
            var ds = _geObjHistoryCtrl.SearchPatient(TableName.MEEmrsTableName, patientId).Tables[0];
            var gridControlEmrRelations = this.Controls["fld_dgcGEObjectHistory"] as GEObjectHistoryGridControl;
            if (gridControlEmrRelations != null)
            {
                gridControlEmrRelations.DataSource = ds;
                gridControlEmrRelations.RefreshDataSource();
                gridControlEmrRelations.Refresh();
            }
        }
        #endregion


        #region TTBA
        internal void SearchByPatientTTBA(object patientId)
        {
            Cursor.Current = Cursors.WaitCursor;
            var result = _emrSumCtrl.GetListBusinessObjects<MEEmrSumsInfo>(_emrSumCtrl.QuickSearchWithOneCriteria(patientId));
            _entity.MEEmrSumList.Invalidate(result);
        }

        public void SearchTTBA(string department, DateTime fromDate, DateTime toDate, string emrNo, object emrTypeId, object no, object storeNo, string status)
        {
            var stateConds = GetStatePermiQueryConditionStr(TableName.MEEmrsTableName, false);
            var view = string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserEmrView) ? BOSApp.CurrentUserGroupInfo.ADUserGroupEmrView : BOSApp.CurrentUsersInfo.ADUserEmrView;
            Cursor.Current = Cursors.WaitCursor;
            department = department.Replace(", " + BOSApp.CurrentEmployeesInfo.FK_HRDepartmentRoomID + ", ", ", ");
            object[] paramValues = new object[]
            {
                    department,
                    fromDate,
                    toDate,
                    emrNo,
                    emrTypeId,
                    no,
                    storeNo,
                    status
            };
            var result = _emrSumCtrl.GetListBusinessObjects<MEEmrSumsInfo>(_emrSumCtrl.QuickSearch(paramValues));
            _entity.MEEmrSumList.Invalidate(result);
        }

        public void XmlExport()
        {
            var gridControl = this.Controls["fld_dgcMEEmrSums"] as MEEmrSumSelectionGridControl;
            if (gridControl != null)
            {
                var statusLst = new List<string>
                {
                    EmrSumStatus.Active.ToString()
                };
                var statusXMLLst = new List<string>
                {
                    EmrSumXMLStatus.None.ToString()
                };

                var gridView = (gridControl.MainView as GridView);
                var rows = gridView.GetSelectedRows();
                if (rows.Length == 0)
                {
                    MessageBox.Show($"Chọn ít nhất 01 tờ bệnh án đã đóng để làm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                foreach (int rowidx in rows)
                {
                    var emrSum = gridView.GetRow(rowidx) as MEEmrSumsInfo;
                    if (emrSum == null)
                    {
                        MessageBox.Show($"Lưới không lấy được dữ liệu đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (!statusLst.Contains(emrSum.MEEmrSumStatus) || !statusXMLLst.Contains(emrSum.MEEmrSumXMLStatus))
                    {
                        MessageBox.Show($"Chức năng chỉ áp dụng cho trạng thái phiếu hiệu lực và chưa xuất XML.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                try
                {
                    var dirLocalPdf = PdfExportGetDir();
                    var emrSums = new List<MEEmrSumsInfo>();
                    foreach (int rowidx in rows)
                    {
                        emrSums.Add(gridView.GetRow(rowidx) as MEEmrSumsInfo);
                    }

                    var sumTemplate = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.EMR_TEMPLATE_SUMMARY_TEMPLATE);
                    if (string.IsNullOrEmpty(sumTemplate))
                    {
                        MessageBox.Show("Chưa cấu hình mẫu Tóm tắt bệnh án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    var template = _templateCtrl.GetTemplateByTypeAndNo(TemplateType.Report.ToString(), sumTemplate);
                    if (template == null)
                    {
                        MessageBox.Show("Không tìm thấy mẫu Tóm tắt bệnh án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    var paramsReport = _paramCtrl.GetAllByTemplateAndMode(template.METemplateID, EmrParamModes.Report.ToString());
                    if (paramsReport.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy thẻ báo cáo ở mẫu Tóm tắt bệnh án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    var templateFile = _helper.DownloadTemplate(template.METemplateNo, _documentPath, _ftpFileMng);
                    if (string.IsNullOrEmpty(templateFile))
                    {
                        MessageBox.Show("Không tải được mẫu Tóm tắt bệnh án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    var isCombineFolder = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.EMR_TEMPLATE_SUMMARY_FOLDER_COMBINE) == "TRUE";
                    var templateParams = AppMemCache.GetTemplateParams(template.METemplateID);
                    BOSProgressBar.Start($"Đang xuất XML...");
                    AppendLog(LoggingTag.Info, "EXPORTING XML", $"Đang xuất XML...");
                    foreach (var item in emrSums)
                    {
                        var emr = _emrCtrl.GetObjectByID(item.FK_MEEmrID) as MEEmrsInfo;
                        var documents = _emrDocumentCtrl.GetListBusinessObjects<MEEmrDocumentsInfo>(_emrDocumentCtrl.GetByMEEmrID(emr.MEEmrID));

                        var fileName = Vietnamese.AliasConvert($"{template.METemplateNo}-{item.MEEmrSumCode}-{DateTime.Now.ToString("ddMMyyyyHHmmssfff")}-{Guid.NewGuid()}", "-");
                        var localPath = isCombineFolder ? Path.Combine(_documentPath, "Emr", "Report") : Path.Combine(_documentPath, "Emr", "Report", emr.MEEmrID.ToString());
                        var serverPath = isCombineFolder ? "/Emr/Report/" : $"/Emr/Report/{emr.MEEmrID}/";
                        DirectoryInfo di = Directory.CreateDirectory(localPath);
                        _ftpFileMng.CreateDirectory(serverPath);

                        var fileNamePdf = $"{fileName}.pdf";
                        var fileNameDocx = $"{fileName}.docx";
                        var fileNameXml = $"{fileName}.xml";
                        var fullFileDocxLocal = string.Format(@"{0}\{1}", localPath, fileNameDocx);
                        var fullFilePdfLocal = string.Format(@"{0}\{1}", localPath, fileNamePdf);
                        var fullFileXmlLocal = string.Format(@"{0}\{1}", localPath, fileNamePdf);

                        var paramList = GetParams(emr, documents, paramsReport);

                        var document = new MEEmrDocumentsInfo
                        {
                            FK_METemplateID = template.METemplateID,
                            MEEmrDocumentCreatedDate = DateTime.Now,
                            MEEmrDocumentStatus = EmrDocumentStatus.InProgress.ToString(),
                            MEEmrDocumentFile = fileName,
                            MEEmrDocumentNo = template.METemplateNo,
                            MEEmrDocumentCode = template.METemplateNo,
                            MEEmrDocumentGuid = template.METemplateGuid,
                            MEEmrDocumentOrder = 999,
                            MEEmrDocumentGroup = "Khác",
                            MEEmrDocumentSubOrder = 999, //GetDocumentSubOrder(emr.MEEmrID, doc.MEEmrDocumentGroup)
                            FK_MEEmrID = item.FK_MEEmrID,
                            FK_EditingUserID = 0,
                            MEEmrDocumentHoldMachineIp = string.Empty,
                            MEEmrDocumentHoldMachineMac = string.Empty,
                            FK_HRDepartmentID = BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID,
                            MEEmrDocumentFileExt = EmrDocumentFileExtention.docx.ToString(),
                            FK_HREmployeeCreatedID = BOSApp.CurrentEmployeesInfo.HREmployeeID
                        };
                        document.MEEmrDocumentJson = JsonConvert.SerializeObject(paramList, Newtonsoft.Json.Formatting.Indented);
                        document.MEEmrDocumentMongoID = item.MEEmrSumMongoID;
                        // Mongo
                        UpdateMongoDocument(emr, document);
                        item.MEEmrSumMongoID = document.MEEmrDocumentMongoID;

                        // Format XML Data
                        var xmlParamList = new Dictionary<string, string>();
                        foreach (var xItem in paramList)
                        {
                            try
                            {
                                var xKey = xItem.Key; // MEParamNo
                                object xItemValue = xItem.Value;
                                if (xItemValue == null)
                                {
                                    xmlParamList.Add(xItem.Key, string.Empty);
                                }
                                else
                                {
                                    // format base Param
                                    var paramE = paramsReport.Where(m => m.MEParamXMLTag.Equals(xItem.Key) || m.MEParamNo.ToUpper().Equals(xItem.Key)).FirstOrDefault();
                                    if (paramE != null)
                                    {
                                        // Encode
                                        var lookupDatas = new List<MEParamLookupDatasInfo>();
                                        var paramReportRelation = _paramReportRelationCtrl.GetObjectByParamCodeAndEmrType(xKey, emr.FK_MEEmrTypeID);
                                        if (paramReportRelation != null)
                                        {
                                            if (!string.IsNullOrEmpty(paramReportRelation.MEParamReportRelationEncode))
                                            {
                                                lookupDatas = _paramLookupDataCtrl.GetAllObjectByNo(paramReportRelation.MEParamReportRelationEncode);
                                            }
                                        }

                                        var valueStr = GetValueObject(xItemValue, paramE, paramReportRelation, lookupDatas, false);

                                        if (paramE.MEParamMaxLength > 0 && valueStr.Length > paramE.MEParamMaxLength)
                                        {
                                            MessageBox.Show($"Nội dung thẻ {paramE.MEParamNo} vượt quá {paramE.MEParamMaxLength} cho phép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            return;
                                        }
                                        xmlParamList.Add(xItem.Key, valueStr);
                                    }
                                }
                            }
                            catch(Exception ex)
                            {
                                xmlParamList.Add(xItem.Key, string.Empty);
                            }
                        }

                        var pdfParamList = new Dictionary<string, object>();
                        foreach (var xItem in paramList)
                        {
                            try
                            {
                                var xKey = xItem.Key; // MEParamNo
                                object xItemValue = xItem.Value;
                                if (xItemValue == null)
                                {
                                    pdfParamList.Add(xItem.Key, string.Empty);
                                }
                                else
                                {
                                    // format base Param
                                    var paramE = paramsReport.Where(m => m.MEParamXMLTag.Equals(xItem.Key) || m.MEParamNo.ToUpper().Equals(xItem.Key)).FirstOrDefault();
                                    if (paramE != null)
                                    {
                                        // Encode
                                        var lookupDatas = new List<MEParamLookupDatasInfo>();
                                        var paramReportRelation = _paramReportRelationCtrl.GetObjectByParamCodeAndEmrType(xKey, emr.FK_MEEmrTypeID);
                                        if (paramReportRelation != null)
                                        {
                                            if (!string.IsNullOrEmpty(paramReportRelation.MEParamReportRelationEncode))
                                            {
                                                lookupDatas = _paramLookupDataCtrl.GetAllObjectByNo(paramReportRelation.MEParamReportRelationEncode);
                                            }
                                        }

                                        var valueStr = GetValueObject(xItemValue, paramE, paramReportRelation, lookupDatas, true);

                                        if (paramE.MEParamMaxLength > 0 && valueStr.Length > paramE.MEParamMaxLength)
                                        {
                                            MessageBox.Show($"Nội dung thẻ {paramE.MEParamNo} vượt quá {paramE.MEParamMaxLength} cho phép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            return;
                                        }
                                        pdfParamList.Add(xItem.Key, valueStr);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                pdfParamList.Add(xItem.Key, string.Empty);
                            }
                        }

                        #region PDF
                        File.Copy(templateFile, fullFileDocxLocal, true);
                        _richEditCtrl.LoadDocument(fullFileDocxLocal);
                        //BackgroudLoadDocumentRelativeThings(doc); // X ok
                        BindingDataToEmrDocument(pdfParamList, document.MEEmrDocumentGuid, string.Empty);
                        var richDoc = this._richEditCtrl.Document;
                        richDoc.EndUpdate();

                        _emrHelper.RemoveAllForPrint(this._richEditCtrl, template, _emrDocumentHelper, templateParams);
                        this._richEditCtrl.ExportToPdf(fullFilePdfLocal);
                        _ftpFileMng.UploadFile(serverPath, fileNamePdf, fullFilePdfLocal);
                        File.Delete(fullFileDocxLocal);
                        #endregion

                        #region XML
                        var ttbaName = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.EMR_TEMPLATE_SUMMARY_TEMPLATE_XML_NAME);
                        var isXML = GeneralXML(xmlParamList, paramsReport, emr.FK_MEEmrTypeID, ttbaName, fileNameXml, localPath, serverPath);
                        if (!isXML)
                        {
                            MessageBox.Show("Lỗi xuất XML.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        #endregion

                        item.MEEmrSumXMLDate = DateTime.Now;
                        item.MEEmrSumXMLSentNum = 0;
                        item.MEEmrSumXMLStatus = EmrSumXMLStatus.Exported.ToString();
                        item.MEEmrSumFileName = fileName;
                        item.MEEmrSumXMLCombine = isCombineFolder;
                        _emrSumCtrl.UpdateObject(item);

                        AppendLog(LoggingTag.Info, "EXPORTED XML", $"Đã xuất XML phiếu {item.MEEmrSumCode}.");
                        BOSProgressBar.Start($"Đã xuất XML phiếu {item.MEEmrSumCode}.");
                    }
                    BOSProgressBar.Close();
                    AppendLog(LoggingTag.Info, "EXPORTED XML", $"Xuất XML thành công.");
                    MessageBox.Show("Xuất XML thành công.", $"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    BOSProgressBar.Close();
                    MessageBox.Show($"Có lỗi xảy ra, xem chi tiết ở màn hình 'Thông báo'.{Environment.NewLine}"
                        + $"Tải lại danh sách Tóm tắt bệnh án để tiếp tục.{Environment.NewLine}"
                        + $"Chi tiết lỗi {ex}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppendLog(LoggingTag.Error, "EXPORT XML", ex.ToString());
                }
                finally
                {
                    BOSProgressBar.Close();
                }
            }
        }

        internal void PrintDocument(MEEmrSumsInfo emrSum)
        {
            if (emrSum == null)
            {
                MessageBox.Show("Không tìm thấy thông tin Tóm tắt bệnh án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (emrSum.MEEmrSumXMLStatus == EmrSumXMLStatus.None.ToString())
            {
                MessageBox.Show("Tóm tắt bệnh án đang chờ khởi tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var gui = new guiPreviewPdf(new MEEmrDocumentsInfo
            {
                FK_MEEmrID = emrSum.FK_MEEmrID,
                MEEmrDocumentFile = emrSum.MEEmrSumFileName,
                MEEmrDocumentFileExt = "pdf"
            }, "Report", emrSum.MEEmrSumXMLCombine);
            gui.StartPosition = FormStartPosition.WindowsDefaultLocation;
            gui.Module = this;
            //gui.WindowState = FormWindowState.Maximized;
            gui.Show();
            BOSProgressBar.Close();
        }

        private Dictionary<string, object> GetParams(MEEmrsInfo emr, List<MEEmrDocumentsInfo> documents, List<MEParamsInfo> reportParams)
        {
            //GetHardParamList(emr); // default data
            var paramList = new Dictionary<string, object>();
            foreach (var param in reportParams)
            {
                // Get relation base type and id param
                var paramReportRelation = _paramReportRelationCtrl.GetObjectByParamAndEmrType(param.MEParamID, emr.FK_MEEmrTypeID);
                if (paramReportRelation != null)
                {
                    // Call mongo get data of param: paramItem.FK_METemplateID vs paramItem.MEParamReportMap
                    var valueParams = new List<object>();
                    object valueParamReport = null;
                    object valueParamReport2 = null;
                    object valueParamReport3 = null;
                    #region MEParamReportMap
                    var docReport = documents.FirstOrDefault(m => m.FK_METemplateID.Equals(paramReportRelation.FK_METemplateID));
                    if (docReport != null)
                    {
                        if (paramReportRelation.MEParamReportMap.Contains('*'))
                        {
                            paramReportRelation.MEParamReportMap = paramReportRelation.MEParamReportMap.Split('.')[0].Replace("[*]", "");
                        }
                        var filters = new Dictionary<string, object>
                        {
                            { "FK_MEEmrID", new Tuple<MongoFilter, object>(MongoFilter.Eq, emr.MEEmrID) }
                        };
                        var fields = new Dictionary<string, string>();
                        if (!fields.ContainsKey(paramReportRelation.MEParamReportMap))
                        {
                            fields.Add(paramReportRelation.MEParamReportMap, "$MEEmrDocumentContent." + paramReportRelation.MEParamReportMap);
                        }
                        var dataMongo = _emrDocumentMng.Find(filters, fields, docReport.MEEmrDocumentNo);
                        dataMongo = dataMongo is JArray ? _helper.MergeChildArrayData(dataMongo as JArray) : _helper.MergeChildArrayData(dataMongo as JToken);

                        valueParamReport = ((JToken)dataMongo).Type == JTokenType.Array
                            ? (dataMongo as JArray).SelectTokens($"$..{paramReportRelation.MEParamReportMap}")
                            : (dataMongo as JObject).SelectToken($"$.{paramReportRelation.MEParamReportMap}");

                        if (valueParamReport == null || string.IsNullOrEmpty(valueParamReport.ToString()))
                        {
                            valueParamReport = null;
                        }
                    }
                    #endregion

                    #region MEParamReportMap2
                    if (paramReportRelation.FK_METemplateID2 > 0 && !string.IsNullOrEmpty(paramReportRelation.MEParamReportMap2))
                    {
                        var docReport2 = documents.FirstOrDefault(m => m.FK_METemplateID.Equals(paramReportRelation.FK_METemplateID2));
                        if (docReport2 != null)
                        {
                            if (paramReportRelation.MEParamReportMap2.Contains('*'))
                            {
                                paramReportRelation.MEParamReportMap2 = paramReportRelation.MEParamReportMap2.Split('.')[0].Replace("[*]", "");
                            }
                            var filters = new Dictionary<string, object>
                            {
                                { "FK_MEEmrID", new Tuple<MongoFilter, object>(MongoFilter.Eq, emr.MEEmrID) }
                            };
                            var fields = new Dictionary<string, string>();
                            if (!fields.ContainsKey(paramReportRelation.MEParamReportMap2))
                            {
                                fields.Add(paramReportRelation.MEParamReportMap2, "$MEEmrDocumentContent." + paramReportRelation.MEParamReportMap2);
                            }
                            var dataMongo = _emrDocumentMng.Find(filters, fields, docReport2.MEEmrDocumentNo);
                            dataMongo = dataMongo is JArray ? _helper.MergeChildArrayData(dataMongo as JArray) : _helper.MergeChildArrayData(dataMongo as JToken);

                            valueParamReport2 = ((JToken)dataMongo).Type == JTokenType.Array
                                ? (dataMongo as JArray).SelectTokens($"$..{paramReportRelation.MEParamReportMap2}")
                                : (dataMongo as JObject).SelectToken($"$.{paramReportRelation.MEParamReportMap2}");

                            if (valueParamReport2 == null || string.IsNullOrEmpty(valueParamReport2.ToString()))
                            {
                                valueParamReport2 = null;
                            }
                        }
                    }
                    #endregion

                    #region MEParamReportMap3
                    if (paramReportRelation.FK_METemplateID3 > 0 && !string.IsNullOrEmpty(paramReportRelation.MEParamReportMap3))
                    {
                        var docReport3 = documents.FirstOrDefault(m => m.FK_METemplateID.Equals(paramReportRelation.FK_METemplateID3));
                        if (docReport3 != null)
                        {
                            if (paramReportRelation.MEParamReportMap3.Contains('*'))
                            {
                                paramReportRelation.MEParamReportMap3 = paramReportRelation.MEParamReportMap3.Split('.')[0].Replace("[*]", "");
                            }
                            var filters = new Dictionary<string, object>
                            {
                                { "FK_MEEmrID", new Tuple<MongoFilter, object>(MongoFilter.Eq, emr.MEEmrID) }
                            };
                            var fields = new Dictionary<string, string>();
                            if (!fields.ContainsKey(paramReportRelation.MEParamReportMap3))
                            {
                                fields.Add(paramReportRelation.MEParamReportMap3, "$MEEmrDocumentContent." + paramReportRelation.MEParamReportMap3);
                            }
                            var dataMongo = _emrDocumentMng.Find(filters, fields, docReport3.MEEmrDocumentNo);
                            dataMongo = dataMongo is JArray ? _helper.MergeChildArrayData(dataMongo as JArray) : _helper.MergeChildArrayData(dataMongo as JToken);

                            valueParamReport3 = ((JToken)dataMongo).Type == JTokenType.Array
                                ? (dataMongo as JArray).SelectTokens($"$..{paramReportRelation.MEParamReportMap3}")
                                : (dataMongo as JObject).SelectToken($"$.{paramReportRelation.MEParamReportMap3}");
                            if (valueParamReport3 == null || string.IsNullOrEmpty(valueParamReport3.ToString()))
                            {
                                valueParamReport3 = null;
                            }
                        }
                    }
                    #endregion

                    if (valueParamReport2 != null || valueParamReport3 != null)
                    {
                        if (valueParamReport != null)
                            valueParams.Add(valueParamReport);
                        if (valueParamReport2 != null)
                            valueParams.Add(valueParamReport2);
                        if (valueParamReport3 != null)
                            valueParams.Add(valueParamReport3);
                        paramList.Add(param.MEParamNo, valueParams);
                    }
                    else
                    {
                        paramList.Add(param.MEParamNo, valueParamReport);
                    }
                }
            }
            return paramList;
        }

        private Dictionary<string, object> GetHardParamList(MEEmrsInfo emr)
        {
            var paramList = new Dictionary<string, object>
            {
                { "Day", DateTime.Now.ToString("dd") },
                { "Month", DateTime.Now.ToString("MM") },
                { "Year", DateTime.Now.Year },
                { "Hour", DateTime.Now.Hour },
                { "Minute", DateTime.Now.Minute },
                { "Second", DateTime.Now.Second },
                { "DayMonth", DateTime.Now.ToString("dd/MM", CultureInfo.InvariantCulture) },
                { "MonthYear", DateTime.Now.ToString("MM/yyyy", CultureInfo.InvariantCulture) },
                { "Date", DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) },
                { "DateTime", DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture) },
                { "Time", DateTime.Now.ToString("HH:mm") },
                { "TimeSpan", DateTime.Now.ToString("HH:mm:ss") },

                { "day", DateTime.Now.ToString("dd") },
                { "month", DateTime.Now.ToString("MM") },
                { "year", DateTime.Now.Year },
                { "hour", DateTime.Now.Hour },
                { "minute", DateTime.Now.Minute },
                { "second", DateTime.Now.Second },
                { "daymonth", DateTime.Now.ToString("dd/MM", CultureInfo.InvariantCulture) },
                { "monthyear", DateTime.Now.ToString("MM/yyyy", CultureInfo.InvariantCulture) },
                { "date", DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) },
                { "datetime", DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture) },
                { "time", DateTime.Now.ToString("HH:mm") },
                { "timespan", DateTime.Now.ToString("HH:mm:ss") },

                { "EmrNo", emr.MEEmrNo },
                //{ "PatientNo", this._entity.MEPatient.MEPatientNo },
                { "Username", BOSApp.CurrentEmployeesInfo.HREmployeeName }
            };
            return paramList;
        }

        private void BindingDataToEmrDocument(IDictionary<string, object> data, string group, string prefix, bool paramUnit = true)
        {
            var doc = this._richEditCtrl.Document;
            var value = this._dataHelper.GetValueToBinding(data, EmrParam.TransactionIdTag);
            var tid = value != null ? value.ToString() : string.Empty;
            doc.BeginUpdate();
            //field needed update
            var fields = data.Keys;
            try
            {
                Field last = null;
                foreach (var f in fields)
                {
                    if (f == "CHAN_DOAN_RA")
                    {
                        var debug = true;
                    }
                    var codes = f.Split(EmrParam.CodeSeparator);
                    var param = AppMemCache.GetParamFromDictKeyNo(codes.Last());
                    if (param == null) continue;
                    //get value from return data
                    value = this._dataHelper.GetValueToBinding(data, f);
                    if (value != null)
                    {
                        //get update field from doc can have multi fields
                        List<Field> updateFields;
                        if (string.IsNullOrEmpty(prefix))
                            updateFields = this._emrDocumentHelper.GetBindingFields(group, f, tid, true, true);
                        else
                            updateFields = this._emrDocumentHelper.GetBindingFields(group, $"{prefix}{EmrParam.CodeSeparator}{f}", tid, false, true);

                        var newPrefix = string.Empty;
                        if (string.IsNullOrEmpty(prefix))
                            newPrefix = this._emrDocumentHelper.GetFieldPrefix(updateFields.FirstOrDefault());
                        else
                            newPrefix = prefix;

                        var formatStyle = this._dataHelper.GetValueToBinding(data, f + EmrConsts.FORMAT_STYLE_PREFIX)?.ToString();

                        foreach (var updateField in updateFields)
                        {
                            this._emrDocumentHelper.BindingDataToFieldV2(param, updateField, value, newPrefix, tid, group, null, formatStyle, allowRecursive: true, paramUnit: paramUnit);
                        }
                        last = updateFields.LastOrDefault();
                    }
                }
                if (last != null)
                {
                    this._emrDocumentHelper.GotoEndOfParam(doc, last);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("BINDING ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
                throw;
            }
            finally
            {

            }
            doc.EndUpdate();
        }

        public string ParserDocumentToJson(int templateID)
        {
            try
            {
                var doc = this._richEditCtrl.Document;
                //var docInfo = _entity.ModuleObjects[TableName.MEEmrDocumentsTableName] as MEEmrDocumentsInfo;
                //du lieu nay da dc cache khi load module neu cache=true InitEmrModuleSessionAsync
                var dictParams = AppMemCache.GetParamsDictKeyNo();
                //du lieu nay da dc lay tu cache/db la do AppMemCache quan ly
                var templateParams = AppMemCache.GetTemplateParamsDictPath(templateID);
                return this._emrParser.ParserFieldsToJsonV3(this._emrDocumentHelper.GetAllDataFieldInRangeOrDocument(), dictParams, templateParams);
            }
            catch (Exception)
            {
                _msgNotification.Text = ("Có lỗi khi trích xuất dữ liệu. Vui lòng kiểm tra thông báo lỗi");
            }
            return string.Empty;
        }

        internal void InsertMongoDocument(MEEmrsInfo emr, MEEmrDocumentsInfo emrDoc)
        {
            var mongoDoc = Mapper.Map<Clas.Model.Mongo.EmrDocument>(emrDoc);
            mongoDoc.MEEmr = Mapper.Map<Clas.Model.Mongo.Emr>(emr);
            if (!string.IsNullOrEmpty(emrDoc.MEEmrDocumentJson) && emrDoc.MEEmrDocumentJson.Length > 4)
            {
                var converter = new Newtonsoft.Json.Converters.ExpandoObjectConverter();
                var obj = JsonConvert.DeserializeObject<System.Dynamic.ExpandoObject>(emrDoc.MEEmrDocumentJson, converter);
                mongoDoc.MEEmrDocumentContent = (obj == null ? null : obj.ToBsonDocument());
            }
            mongoDoc.AAUpdatedDate = mongoDoc.AACreatedDate;
            emrDoc.MEEmrDocumentMongoID = _emrDocumentMng.Insert(mongoDoc, emrDoc.MEEmrDocumentNo);
        }

        internal void UpdateMongoDocument(MEEmrsInfo emr, MEEmrDocumentsInfo emrDoc, List<string> excludedFields = null)
        {
            if (string.IsNullOrEmpty(emrDoc.MEEmrDocumentMongoID))
            {
                InsertMongoDocument(emr, emrDoc);
            }
            else
            {
                var mongoDoc = Mapper.Map<Clas.Model.Mongo.EmrDocument>(emrDoc);
                mongoDoc.MEEmr = Mapper.Map<Clas.Model.Mongo.Emr>(emr);
                if (!string.IsNullOrEmpty(emrDoc.MEEmrDocumentJson) && emrDoc.MEEmrDocumentJson.Length > 4)
                {
                    var converter = new Newtonsoft.Json.Converters.ExpandoObjectConverter();
                    var obj = JsonConvert.DeserializeObject<System.Dynamic.ExpandoObject>(emrDoc.MEEmrDocumentJson, converter);
                    mongoDoc.MEEmrDocumentContent = (obj == null ? null : obj.ToBsonDocument());
                }
                mongoDoc.FK_MEEmrID = emrDoc.FK_MEEmrID;
                mongoDoc.AAUpdatedDate = DateTime.Now.ToLocalTime();
                mongoDoc.AAUpdatedUser = BOSApp.CurrentUser;
                _emrDocumentMng.Update(emrDoc.MEEmrDocumentMongoID, mongoDoc, emrDoc.MEEmrDocumentNo, excludedFields);
            }
        }

        private bool GeneralXML(Dictionary<string, string> paramList, List<MEParamsInfo> paramsReport, int emrTypeID, string typeXML, string xmlFile, string localPath, string serverPath)
        {
            var xmlList = new List<XMLModel>();
            foreach (KeyValuePair<string, string> entry in paramList)
            {
                // do something with entry.Value or entry.Key
                var tag = string.Empty;
                var xmlValue = string.Empty;
                var xmlGroup = 1;
                var xmlLevel = 1;
                var xmlOrder = 1;
                var paramE = paramsReport.FirstOrDefault(m => m.MEParamNo.Equals(entry.Key));
                if (paramE != null)
                {
                    tag = paramE.MEParamXMLTag;
                    if (string.IsNullOrEmpty(tag))
                    {
                        tag = paramE.MEParamNo.ToUpper();
                    }
                    var paramReportRelation = _paramReportRelationCtrl.GetObjectByParamAndEmrType(paramE.MEParamID, emrTypeID);
                    if (paramReportRelation != null)
                    {
                        xmlGroup = paramReportRelation.MEParamReportRelationXMLGroup;
                        xmlLevel = paramReportRelation.MEParamReportRelationXMLLevel;
                        xmlOrder = paramReportRelation.MEParamReportRelationXMLOrder;
                    }
                    //if (entry.Value.Length > )
                    xmlList.Add(new XMLModel
                    {
                        Tag = tag,
                        Value = entry.Value,
                        Group = xmlGroup,
                        Level = xmlLevel,
                        Order = xmlOrder
                    });
                }
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0",
                    "utf-8", string.Empty);
                xmlDoc.AppendChild(xmlDeclaration);

                XmlElement parentNode = xmlDoc.CreateElement(typeXML);
                XmlAttribute xsd = xmlDoc.CreateAttribute("xmlns:xsd");
                xsd.Value = "http://www.w3.org/2001/XMLSchema";
                parentNode.Attributes.Append(xsd);
                XmlAttribute xsi = xmlDoc.CreateAttribute("xmlns:xsi");
                xsi.Value = "http://www.w3.org/2001/XMLSchema-instance";
                parentNode.Attributes.Append(xsi);
                foreach (var item in xmlList.OrderBy(m => m.Order))
                {
                    // Group, Level do later. analytics
                    XmlElement itemNode = xmlDoc.CreateElement(item.Tag);
                    itemNode.InnerText = item.Value;
                    parentNode.AppendChild(itemNode);
                }
                xmlDoc.AppendChild(parentNode);

                var fullXMLLocal = string.Format(@"{0}\{1}", localPath, xmlFile);
                xmlDoc.Save(fullXMLLocal);
                _ftpFileMng.UploadFile(serverPath, xmlFile, fullXMLLocal);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string DownloadFtpFileCommon(string serverPath, string fileName, string localPart)
        {
            var localPath = Path.Combine(_documentPath, localPart);
            Directory.CreateDirectory(localPath);
            var fullFileLocal = Path.Combine(localPath, fileName);
            _ftpFileMng.DownloadFile(serverPath, fileName, fullFileLocal);
            return fullFileLocal;
        }

        private string GetValueObject(object value, MEParamsInfo param, MEParamReportRelationsInfo paramReport, List<MEParamLookupDatasInfo> lookupDatas, bool isPdf)
        {
            var formatType = param.MEParamFormatType;
            var formatString = param.MEParamFormatString;
            var filter = paramReport.MEParamReportMapFilter;

            var isEnCode = lookupDatas.Count() > 0;
            if (isPdf)
            {
                isEnCode = false;
                formatString = string.Empty;
            }
            if (value == null || string.IsNullOrEmpty(value.ToString())) return string.Empty;
            if (value.GetType() == typeof(JObject))
            {
                var childDataObj = (value as JObject).ToObject<IDictionary<string, object>>();
                if (childDataObj.Count() == 0) return string.Empty;
                if (isEnCode)
                {
                    var arrs = childDataObj.Select(x => x.Value).ToArray();
                    var result = string.Empty;
                    foreach(var item in arrs)
                    {
                        var lookUpData = lookupDatas.Where(m => m.MEParamLookupDataText.ToUpper() == item.ToString().ToUpper()).FirstOrDefault();
                        if (lookUpData != null)
                        {
                            result += string.IsNullOrEmpty(result) ? lookUpData.MEParamLookupDataEncode : $"; {lookUpData.MEParamLookupDataEncode}";
                        }
                        else
                        {
                            result += string.IsNullOrEmpty(result) ? value.ToString() : $"; {value}";
                        }
                    }
                    return result;
                }
                else
                {
                    var arrs = childDataObj.Select(x => x.Value).ToArray();
                    if (!string.IsNullOrEmpty(filter))
                    {
                        arrs = childDataObj.Where(x => x.Key == filter).Select(x => x.Value).ToArray();
                    }
                    var result = string.Empty;
                    foreach (var item in arrs)
                    { 
                        if (item != null && !string.IsNullOrEmpty(item.ToString()))
                        {
                            if (string.IsNullOrEmpty(formatString))
                            {
                                result += string.IsNullOrEmpty(result) ? item.ToString() : $"; {item}";
                            }
                            else
                            {
                                result += string.IsNullOrEmpty(result) ? _dataHelper.GetStringFromDataValue(formatType, formatString, item) : $"; {_dataHelper.GetStringFromDataValue(formatType, formatString, item)}";
                            }
                        }
                    }
                    return result;
                }
            }
            else if (value.GetType() == typeof(JArray))
            {
                // List parammap, parammap 1, parammap2
                if (JArray.FromObject(value).Count() == 0) return string.Empty;
               
                string texts = string.Empty;
                foreach (var item in JArray.FromObject(value))
                {
                    texts += string.IsNullOrEmpty(texts) ? GetValueObject(item, param, paramReport, lookupDatas, isPdf) : $"; {GetValueObject(item, param, paramReport, lookupDatas, isPdf)}";
                }
                return texts;
            }
            else
            {
                string result = string.Empty;
                if (value is IList && value.GetType().IsGenericType)
                {
                    var arrs = JArray.FromObject(value).Select(x => x).ToArray();
                    foreach (var item in arrs)
                    {
                        result += string.IsNullOrEmpty(result) ? GetValueObject(item, param, paramReport, lookupDatas, isPdf) : $"; {GetValueObject(item, param, paramReport, lookupDatas, isPdf)}";
                    }
                }
                else
                {
                    if (isEnCode)
                    {
                        var lookUpData = lookupDatas.Where(m => m.MEParamLookupDataText.ToUpper() == value.ToString().ToUpper()).FirstOrDefault();
                        result = lookUpData != null ? lookUpData.MEParamLookupDataEncode : value.ToString();
                    }
                    else
                    {
                        result = string.IsNullOrEmpty(formatString) ? value.ToString() : _dataHelper.GetStringFromDataValue(formatType, formatString, value);

                        if (!isPdf && formatString == "yyyyMMdd")
                        {
                            if (!string.IsNullOrEmpty(result) && result.Length < 5 && DateTime.TryParseExact(result, "yyyy", CultureInfo.InvariantCulture,
                                                      DateTimeStyles.None, out DateTime dt))
                            {
                                result = dt.ToString(formatString);
                            }
                        }
                    }
                }
                return result;
            }
        }
        #endregion
        #region Close All EMR
        public void CloseAllEmr()
        {
            GridView grid = _entity.MEEmrList.GridView;
            var rows = grid.GetSelectedRows();
            if (rows.Length == 0)
            {
                MessageBox.Show("Chọn ít nhất 01 bệnh án để thực hiện.", "Chưa chọn bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            foreach (int rowidx in rows)
            {
                var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                if ((emr.MEEmrStatus == EmrStatus.WaitClose.ToString() && emr.MEEmrPatientGroup == "BHYT") || (emr.MEEmrStatus == EmrStatus.Approved.ToString() && emr.MEEmrPatientGroup != "BHYT"))
                {
                    MessageBox.Show($"Bệnh án chưa chờ đóng hoặc chưa duyệt BHYT {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}", "CÓ BỆNH ÁN CHƯA CHỜ ĐÓNG HOẶC CHƯA DUYỆT BHYT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            var emrNos = string.Empty;
            var i = 1;
            foreach (int rowidx in rows)
            {
                var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                emrNos += $" {i}. {emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
                emrNos += "\r\n";
                i++;
            }
            var gui = new guiConfirmWithLongInfo("DANH SÁCH BỆNH ÁN SẼ ĐÓNG. Vui lòng xác nhận?", emrNos, "DANH SÁCH BỆNH ÁN SẼ ĐÓNG");
            if (gui.ShowDialog() == DialogResult.Cancel)
                return;

            int errorCount = 0;
            int successCount = 0;
            int index = 0;
            
            BOSProgressBar.Start($"Đang xử lý");
            foreach (int rowidx in rows)
            {
                var emr = grid.GetRow(rowidx) as MEEmrsInfo;
                var pdf = EmrDocumentFileExtention.pdf.ToString();
                var docx = EmrDocumentFileExtention.docx.ToString();
                var serverPath = $"/Emr/{emr.MEEmrID}/";
                var serverFiles = _ftpFileMng.GetNameListing(serverPath);
                var localPath = string.Format(@"{0}\Emr\{1}\", _documentPath, emr.MEEmrID);
                DirectoryInfo localDir = new DirectoryInfo(localPath);

                CreateEmrLocalDir(emr.MEEmrID);
                var uid = $"{emr.MEEmrNo} - {emr.MEPatientName} - {emr.MEPatientNo}";
                try
                {
                    index++;
                    BOSProgressBar.SetText($"Đang xử lý [{index}/{rows.Length}]: {uid}");
                    var listDocs = _emrDocumentCtrl.GetListBusinessObjects<MEEmrDocumentsInfo>(_emrDocumentCtrl.GetByMEEmrID(emr.MEEmrID));
                    foreach (var item in listDocs)
                    {
                        var template = _templateCtrl.GetObjectByNo(item.MEEmrDocumentNo) as METemplatesInfo;
                        if (template == null) continue;
                        var richEditCtrl = new RichEditControl();
                        EmrDocumentHelper emrDocumentHelper = new EmrDocumentHelper(richEditCtrl);
                        var templateParamsPath = AppMemCache.GetTemplateParamsDictPath(template.METemplateID);
                        var templateParams = AppMemCache.GetTemplateParams(template.METemplateID);
                        emrDocumentHelper.SetTemplateParamList(templateParams, templateParamsPath);
                        richEditCtrl.CreateNewDocument(false);
                        if (item.MEEmrDocumentFileExt == docx)
                        {
                            // bo qua cac to an va huy
                            if (item.MEEmrDocumentStatus == EmrDocumentStatus.Discarded.ToString()
                                || item.MEEmrDocumentStatus == EmrDocumentStatus.Hidden.ToString())
                            {
                                continue;
                            }
                            if (item.FK_EditingUserID > 0 && item.FK_EditingUserID != BOSApp.CurrentEmployeesInfo.HREmployeeID)
                            {
                                errorCount++;
                                AppendLog(LoggingTag.Error, uid + " [LỖI - BỎ QUA]",
                                    $"Có tờ BA đang được soạn bởi người khác ({item.MEEmrDocumentHoldMachineIp}:{item.MEEmrDocumentHoldMachineMac}) từ lúc {item.MEEmrDocumentHoldFrom.ToString("HH: mm dd / MM / yyyy")}");
                                break;
                            }
                            string fileDocx = string.Format(@"{0}\Emr\{1}\{2}.docx", _documentPath, item.FK_MEEmrID, item.MEEmrDocumentFile);
                            _ftpFileMng.DownloadFile($"/Emr/{item.FK_MEEmrID}/", item.MEEmrDocumentFile + ".docx", fileDocx);
                            using (OfficeOpenXmlCrypto.OfficeCryptoStream stream = OfficeOpenXmlCrypto.OfficeCryptoStream.Open(fileDocx, emrDocumentHelper.ShareEmrPassword))
                            {
                                richEditCtrl.LoadDocument(stream, DocumentFormat.OpenXml);
                            }
                            this.RemoveAllForPrint(richEditCtrl, template, emrDocumentHelper, templateParams);
                            string fileName = string.Format(@"{0}\Emr\{1}\{2}.{3}", _documentPath, item.FK_MEEmrID, item.MEEmrDocumentFile, pdf);
                            richEditCtrl.ExportToPdf(fileName);
                            _ftpFileMng.UploadFile($"/Emr/{item.FK_MEEmrID}/", item.MEEmrDocumentFile + "." + pdf, fileName);
                            item.AAUpdatedUser = BOSApp.CurrentUser;
                            item.MEEmrDocumentEndDate = DateTime.Now;
                            item.MEEmrDocumentPreStatus = item.MEEmrDocumentStatus;
                            item.MEEmrDocumentStatus = EmrDocumentStatus.Closed.ToString();
                            if (item.MEEmrDocumentFileExt == docx)
                                item.MEEmrDocumentFileExt = pdf;
                            item.MEEmrDocumentJson = string.Empty;
                            item.FK_EditingUserID = 0;
                            item.MEEmrDocumentHoldMachineMac = string.Empty;
                            item.MEEmrDocumentHoldMachineIp = string.Empty;
                            item.MEEmrDocumentHoldFrom = DateTime.MaxValue;
                            _emrDocumentCtrl.UpdateObject(item);
                        }
                        else
                        {
                            var fileNamePdf = $"{item.MEEmrDocumentFile}.{pdf}";
                            if (!_ftpFileMng.FileExists($"/Emr/{item.FK_MEEmrID}/", fileNamePdf))
                            {
                                throw new FtpException();
                            }

                            item.MEEmrDocumentEndDate = DateTime.Now;
                            item.MEEmrDocumentPreStatus = item.MEEmrDocumentStatus;
                            item.MEEmrDocumentStatus = EmrDocumentStatus.Closed.ToString();
                            if (item.MEEmrDocumentFileExt == docx)
                                item.MEEmrDocumentFileExt = pdf;
                            item.AAUpdatedUser = BOSApp.CurrentUser;
                            _emrDocumentCtrl.UpdateObject(item);
                        }
                    }
                    emr.FK_HREmployeeClosedID = BOSApp.CurrentEmployeesInfo.HREmployeeID;
                    emr.MEEmrStatus = EmrStatus.Closed.ToString();
                    emr.MEEmrEndDate = DateTime.Now;
                    emr.AAUpdatedUser = BOSApp.CurrentUser;
                    emr.MEEmrDesc = $"{emr.MEEmrDesc}. [{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}] BA được đóng hàng loạt";
                    _emrCtrl.UpdateObject(emr);
                    HistoryEmr(emr, cstObjectHistoryActionChange, "Đóng bệnh án hàng loạt");
                    AppendLog(LoggingTag.Info, uid + " [ĐÃ XỬ LÝ]", string.Empty);
                    successCount++;
                }
                catch (Exception ex)
                {
                    errorCount++;
                    AppendLog(LoggingTag.Error, uid + " [LỖI - BỎ QUA]", ex.ToString());
                }
            }
            BOSProgressBar.Close();
            MessageBox.Show($"Danh sách chi tiết các bệnh án đã xử lý ở [màn hình thông báo].\nThống kê: [{successCount} thành công]/[{errorCount} lỗi]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
        #region Restore EMR
        public void RestoreEmr()
        {
            var gridControlEmrRelations = this.Controls["fld_dgcGEObjectHistory"] as GEObjectHistoryGridControl;
            if (gridControlEmrRelations != null)
            {
                var node = gridControlEmrRelations.DataSource as List<GEObjectHistoryInfo>;
                if (node[0].GEObjectHistoryAction == cstObjectHistoryActionDelete)
                {
                    var emr = _emrCtrl.GetDeletedObjectByID(node[0].GEObjectHistoryObjectID) as MEEmrsInfo;
                    if (MessageBox.Show($"Xác nhận khôi phục bệnh án {emr.MEEmrNo}", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _emrCtrl.EmrActive(emr.MEEmrID, BOSApp.CurrentUser);
                        HistoryEmr(emr, "Change", $"Khôi phục bệnh án đã xóa");
                        _emrDocumentCtrl.EmrDocumentsActive(emr.MEEmrID, BOSApp.CurrentUser);
                        MessageBox.Show($"Khôi phục bệnh án thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                else
                    MessageBox.Show("Chỉ khôi phục bệnh án đã bị xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        #endregion
    }
}
