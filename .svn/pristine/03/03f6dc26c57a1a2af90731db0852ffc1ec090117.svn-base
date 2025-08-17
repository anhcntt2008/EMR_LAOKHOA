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
using BOSERP.Modules.MENotification.UI;
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
using BOSERP.Modules.MENotification;
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
using Clas.Model.Middle;
using BOSLib.DataAccess;
#endregion

namespace BOSERP.Modules.MENotification
{
    public class MENotificationModule : BaseModuleERP
    {
        private MENotificationsController _notificationCtrl;
        private MENotificationEntities _entity;
        private string _documentPath;
        private string _macAddress;
        private string _ipAddress;
        private string _hostName;
        private FileTemplateManager _ftpFileMng;
        private EmrDocumentHelper _emrDocumentHelper;

        #region Constant
        //private const string _templateContentCtrlName = "richEditCtrlNotification";
        private const string _notificationType = "fld_lkeMENotificationType";
        private const string _notificationContent = "fld_medMENotificationContent";
        #endregion

        #region Variable
        private ApiHelper _apiEmr;
        //private RichEditControl _richEditCtrlNotification;
        private BOSMemoEdit _memoEdit;
        private BOSLookupEdit _typeNoti;
        #endregion

        #region Public

        #endregion
        public MENotificationModule()
        {
            Name = "MENotification";
            CurrentModuleEntity = new MENotificationEntities
            {
                Module = this
            };
            _entity = CurrentModuleEntity as MENotificationEntities;
            InitializeModule();

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this._documentPath = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_TEMPLATE_SERVER_PATH);
            if (!_documentPath.Contains(":\\")) // đường dẫn tương đối
                this._documentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + _documentPath;

            this._ftpFileMng = new FileTemplateManager();
            //_richEditCtrlNotification = (RichEditControl)Controls[_templateContentCtrlName];
            _memoEdit = (BOSMemoEdit)Controls[_notificationContent];
            //this._emrDocumentHelper = new EmrDocumentHelper(this._richEditCtrlNotification);
        }
        public override void InitializeModule()
        {
            base.InitializeModule();
            SetMachineInfo();
            _notificationCtrl = new MENotificationsController();

            //var emrEndpoint = BOSApp.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_EMR_API_ENDPOINT);
            var emrEndpoint = SqlDatabaseHelper._EMR_API_ENDPOINT;
            if (!string.IsNullOrEmpty(emrEndpoint) && !string.IsNullOrEmpty(BOSApp.EmrApiAuthToken))
                _apiEmr = new ApiHelper(emrEndpoint, BOSApp.EmrApiAuthToken, "EMR");

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            _memoEdit = (BOSMemoEdit)Controls[_notificationContent];
            _typeNoti = (BOSLookupEdit)Controls[_notificationType];
        }

        private void SetMachineInfo()
        {
            _macAddress = BOSApp.GetMachineMac();
            _ipAddress = BOSApp.GetMachineIp();
            _hostName = System.Net.Dns.GetHostName();
        }

        public override void Invalidate(int iObjectId)
        {
            //_richEditCtrlNotification.ReadOnly = true;

            base.Invalidate(iObjectId);

            var notification = ((MENotificationEntities)CurrentModuleEntity).MainObject as MENotificationsInfo;
            ((MultiColCheckedComboBoxEdit)Controls["fld_ccbeMENotificationDepartment"]).EditValue = notification.MENotificationDepartment;
            //Controls["fld_ccbeMENotificationDepartment"].Enabled = false;
            //_richEditCtrlNotification.HtmlText = notification.MENotificationContent;
            //DocumentLoad(notification);
            EnableField(false);
        }

        public override void ActionNew()
        {
            base.ActionNew();
            EnableField(true);

            var notification = ((MENotificationEntities)CurrentModuleEntity).MainObject as MENotificationsInfo;
            ((MultiColCheckedComboBoxEdit)Controls["fld_ccbeMENotificationDepartment"]).EditValue = string.Empty;
            notification.MENotificationNo = BOSApp.GetMainObjectNo(ModuleName.MENotification);
            notification.MENotificationName = string.Empty;
            notification.MENotificationDepartment = string.Empty;
            notification.MENotificationContent = string.Empty;
        }

        public override void ActionEdit()
        {
            base.ActionEdit();

            EnableField(true);
            var notification = ((MENotificationEntities)CurrentModuleEntity).MainObject as MENotificationsInfo;

        }

        public override int ActionSave()
        {
            var entity = ((MENotificationEntities)CurrentModuleEntity);
            var notification = entity.MainObject as MENotificationsInfo;

            if (string.IsNullOrEmpty(notification.MENotificationName))
            {
                MessageBox.Show("Vui lòng nhập tên thông báo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (notification.MENotificationContent.Length > 4000)
            {
                MessageBox.Show("Nội dung không vượt quá 4000 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            if (string.IsNullOrEmpty(notification.MENotificationNo))
                notification.MENotificationNo = Guid.NewGuid().ToString();

            notification.MENotificationDepartment = ((MultiColCheckedComboBoxEdit)Controls["fld_ccbeMENotificationDepartment"]).EditValue.ToString();
            if (notification.MENotificationType == "All")
            {
                notification.MENotificationDepartment = string.Empty;
            }

            //notification.MENotificationFile = Emr.Vietnamese.AliasConvert(notification.MENotificationName.Trim(), "-");
            //notification.MENotificationFileExt = EmrDocumentFileExtention.docx.ToString();

            var resultId = 0;
            if (notification.MENotificationID > 0)
            {
                resultId = base.ActionSave();
            }
            else
            {
                notification.AACreatedUser = BOSApp.CurrentUser;
                notification.AAUpdatedUser = BOSApp.CurrentUser;
                //BOSDbUtil dbUtil = new BOSDbUtil();
                //notification.AAUpdatedDate = dbUtil.GetCurrentServerDate();
                _notificationCtrl.CreateObject(notification);

                ModuleAfterSaved(notification.MENotificationID);
            }
            
            EnableField(false);

            return resultId;
        }

        private void EnableField(bool status)
        {
            _typeNoti.Enabled = status;
            Controls["fld_ccbeMENotificationDepartment"].Enabled = status;
            if (_typeNoti.EditValue.ToString() == "All")
            {
                Controls["fld_ccbeMENotificationDepartment"].Enabled = false;
            }
            Controls["fld_txtMENotificationName"].Enabled = status;
            Controls["fld_chkMENotificationActive"].Enabled = status;
            _memoEdit.Enabled = status;
            Controls["bosPictureEdit1"].Enabled = status;
            //_richEditCtrlNotification.ReadOnly = !status;
        }
    }
}
