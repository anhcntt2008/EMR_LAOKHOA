using BOSCommon;
using BOSComponent;
using BOSERP.Modules.GE.Welcome;
using BOSLib.DataAccess;
using Clas.Business.Ftp;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOSERP.Modules.Welcome
{
    public class WelcomeModule : BaseModuleERP
    {
        private MENotificationsController _notificationCtrl;
        private string _documentPath;
        private FileTemplateManager _ftpFileMng;
        #region Constant

        #endregion

        #region Variable
        private const string _currBoxName = "pictureBox1";
        private const string _notiBoxName = "pictureBoxNotification";
        private const string _notiPanelName = "panelNotification";
        private const string _notiLabelName = "lblNotification";
        private const string _notiImgName = "pic_MENotificationImg";

        private PictureBox _currBox;
        private PictureBox _notiBox;
        private Panel _notiPanel;
        private BOSLabel _notiLabel;
        private BOSPictureEdit _notiImgBox;
        #endregion

        public WelcomeModule()
        {
            Name = "Welcome";
            CurrentModuleEntity = new WelcomeEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
        }

        public override void InitializeModule()
        {
            base.InitializeModule();

            _notificationCtrl = new MENotificationsController();

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this._documentPath = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_TEMPLATE_SERVER_PATH);
            if (!_documentPath.Contains(":\\")) // đường dẫn tương đối
                this._documentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + _documentPath;

            this._ftpFileMng = new FileTemplateManager();

            _currBox = (PictureBox)Controls[_currBoxName];
            _notiBox = (PictureBox)Controls[_notiBoxName];
            _notiImgBox = (BOSPictureEdit)Controls[_notiImgName];
            _notiPanel = (Panel)Controls[_notiPanelName];
            _notiLabel = (BOSLabel)Controls[_notiLabelName];
            _notiImgBox.Properties.ContextMenuStrip = new ContextMenuStrip();
            //_rtfNotification = (RichTextBox)Controls["rtfNotification"];
            SetNotificication();
        }

        private void SetNotificication()
        {
            // check thong bao
            var alls = new List<MENotificationsInfo>();

            var notificationAll = _notificationCtrl.GetListBusinessObjects<MENotificationsInfo>(_notificationCtrl.GetAllObjects())
                .Where(m => m.MENotificationActive.Equals(true) && m.MENotificationType.Equals("All")).OrderByDescending(m => m.AAUpdatedDate);
            var lastNotificationAll = notificationAll.FirstOrDefault();
            if (lastNotificationAll != null)
                alls.Add(lastNotificationAll);

            var userDept = BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID;
            var notificationDept = _notificationCtrl.GetListBusinessObjects<MENotificationsInfo>(_notificationCtrl.GetAllObjects())
                .Where(m => m.MENotificationActive.Equals(true) && m.MENotificationType.Equals("Department")
                && m.MENotificationDepartment.Contains(userDept.ToString()))
                .OrderByDescending(m => m.AAUpdatedDate);
            var lastNotificationDept = notificationDept.FirstOrDefault();
            if (lastNotificationDept != null)
                alls.Add(lastNotificationDept);

            // hien thi thong bao
            var notification = alls.OrderByDescending(m => m.AAUpdatedDate).FirstOrDefault();
            if (notification != null && !string.IsNullOrEmpty(notification.MENotificationContent))
            {
                if (string.IsNullOrEmpty(notification.MENotificationContent.Trim())) 
                {
                    _currBox.Visible = true;
                    return;
                }

                _currBox.Visible = false;
                _notiBox.Visible = true;
                _notiPanel.Visible = true;
                _notiLabel.Visible = true;
                _notiLabel.Text = notification.MENotificationContent;
                if (notification.MENotificationImg != null)
                {
                    _notiImgBox.Visible = true;
                    _notiImgBox.Image = ConvertByteToImg(notification.MENotificationImg);
                }
            }
            else
            {
                _currBox.Visible = true;
            }
        }

        private Image ConvertByteToImg(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
