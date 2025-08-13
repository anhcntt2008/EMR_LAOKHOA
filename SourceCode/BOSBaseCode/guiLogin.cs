using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using BOSBase;
using BOSCommon;
using BOSLib;
using Clas.Business.Doctor24x7;
using Clas.Model.Doctor24x7;
using Clas.Repository.HttpApi;
using Localization;
using Clas.Emr.Intergration;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using Emr.Base.Models.Abp;
using Emr.Base;
using BOSLib.DataAccess;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace BOSERP
{
    public partial class guiLogin : Form
    {
        private readonly HopitalManager _hopitalManager;
        private readonly UserManager _userBs247Manager;
        private BRBranchsController _brBranchsController;
        private Hospital[] _listHospitals;
        private readonly STModuleToUserGroupSectionsController _moduleToUserGroupSectionsController;
        private User _userBacsi24X7;

        private readonly ADUserGroupsController _userGroupsController;
        private readonly ADUserGroupSectionsController _userGroupSectionsController;
        private readonly ADUsersController _usersController;
        private readonly NetHttp _netWork;
        private ApiHelper _apiHis;
        private SqlHelper _sqlHelper;
        private string _apiLogin;
        private string _spLogin;
        private readonly ApiHelper _apiEmr;

        public guiLogin()
        {
            LogTxt($"InitializeComponent", $"---- start");

            InitializeComponent();
            _userBs247Manager = new UserManager();
            _hopitalManager = new HopitalManager();
            _userGroupsController = new ADUserGroupsController();
            _userGroupSectionsController = new ADUserGroupSectionsController();
            _usersController = new ADUsersController();
            _moduleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();
            _netWork = new NetHttp();
#if DEBUG
            fld_txtUserName.Text = "admin";
            fld_txtPassword.Text = "";
#endif
            panelControl1.Visible = true;
            fld_panelSelectBranch.Visible = false;
            this.BackColor = fld_panelSelectBranch.BackColor;

            this._apiHis = new ApiHelper();
            this._sqlHelper = new SqlHelper();
            LogTxt($"InitializeComponent", $"GetSystemConfigValue---- start");

            _apiLogin = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HIS_API_LOGIN);
            _spLogin = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_HIS_SP_LOGIN);

            LogTxt($"InitializeComponent", $"EmrEndPoint---- start");

            var emrEndpoint = EmrEndPoint();

            LogTxt($"InitializeComponent", $"EmrEndPoint---- End");

            if (!string.IsNullOrEmpty(emrEndpoint))
                this._apiEmr = new ApiHelper(emrEndpoint, "emr-wf-client", "EMR");
        }

        private void AutoLoginFromHIS()
        {
            var autoLoginHisToEMR = new AutoLoginHisToEMR();
            if (BOSApp._isFirstLogin == true && autoLoginHisToEMR.IsAllowLoginByHIS())
            {
                if (autoLoginHisToEMR.LoginByHisLink() == true)
                {
                    if (BOSApp.LoadingThread != null)
                    {
                        BOSApp.LoadingThread.Abort();
                        BOSApp.LoadingThread = null;
                    }
                    if (BOSApp._isFirstLogin)
                    {
                        Thread.Sleep(2000); // Giả sử tác vụ init module của hệ thống hết mất 3 giây    
                        BOSApp.IsLoginBacSi24X7 = false;
                        BOSApp._isLoginByHIS = true;
                        //GetEmrApiToken(fld_txtUserName.Text, fld_txtPassword.Text);
                        //BOSApp.ConnectToSignalHub();
                        DialogResult = DialogResult.OK;
                        Task.Run(() =>
                        {
                            BOSApp.InitExchangeLogOffRabbitMQ();
                        });
                        Dispose();
                    }

                }
            }

        }

        private string EmrEndPoint()
        {
            try
            {
                var emrEndpoint = BOSApp.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.EMR_API_ENDPOINT);
                if (!string.IsNullOrEmpty(emrEndpoint))
                    return emrEndpoint;
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public sealed override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        private void guiLogin_show(object sender, EventArgs e)
        {
            if (BOSApp.LoadingThread != null)
            {
                BOSApp.LoadingThread.Abort();
                BOSApp.LoadingThread = null;
            }
            AutoLoginFromHIS();
#if DEBUG
            //fld_btnLogin.PerformClick();
#endif
        }

        private void guiLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(BOSApp.CurrentUser))
                Application.Exit();
        }
        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
            Application.Exit();
        }
        private bool ForceLoginAtOtherMachine(string hostName, string mac, string ip)
        {
            var reqUser = _usersController.GetObjectByName(fld_txtUserName.Text) as ADUsersInfo;
            if (reqUser == null) return true;
            //neu cung host name tuc la cung 1 may thi ko can check
            if (!string.IsNullOrEmpty(reqUser.ADUserOnComputerMAC) && reqUser.ADUserOnComputerMAC != mac)
            {
                if (MessageBox.Show("Bạn chưa thực hiện đăng xuất ở máy " + reqUser.ADUserOnComputerName + " địa chỉ IP " + reqUser.ADUserOnIpAddress
                   // + "\n\nCác tờ bệnh án chưa lưu trên máy " + reqUser.ADUserOnComputerName + " sẽ không thể lưu được."
                   + "\nVẫn tiếp tục đăng nhập ở máy này (" + hostName + "/" + ip + ")?",
                   "Cảnh báo chưa đăng xuất ở máy khác", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return false;
            }
            return true;
        }
        private void fld_btnLogin_Click(object sender, EventArgs e)
        { 
            try
            {
                if (string.IsNullOrEmpty(fld_txtUserName.Text) || string.IsNullOrEmpty(fld_txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", CommonLocalizedResources.MessageBoxDefaultCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var ip = BOSApp.GetMachineIp();
                var hostName = Dns.GetHostName();
                var mac = BOSApp.GetMachineMac();

                var isNetworkToBs24x7 = _netWork.CheckNetworkToBs24x7();
                if (isNetworkToBs24x7.IsNetwork)
                {
                    var result = _userBs247Manager.Login(fld_txtUserName.Text, fld_txtPassword.Text);
                    if (!result.successful)
                    {
                        if (result.errorCode == 9)
                        {
                            if (BOSApp.IsAuthenticated(fld_txtUserName.Text, fld_txtPassword.Text))
                            {
                                MessageBox.Show(BaseLocalizedResources.OfflineLogin,
                                    CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                                BOSApp.IsLoginBacSi24X7 = false;
                                BOSApp.SetCurrentUserLogin(fld_txtUserName.Text);
                                DialogResult = DialogResult.OK;
                                Dispose();
                            }
                            else
                            {
                                MessageBox.Show(BaseLocalizedResources.InvalidAuthenticationMessage,
                                    CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            }
                        }
                        else if (result.errorCode == 3)
                        {
                            MessageBox.Show(BaseLocalizedResources.InvalidAuthenticationMessage,
                            CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        }
                        else if (result.errorCode == -3)
                        {
                            MessageBox.Show("Tài khoản của bạn chưa được kích hoạt. Vui lòng kiểm tra lại.",
                                CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show(BaseLocalizedResources.InvalidAuthenticationMessage,
                                    CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        BOSApp.IsLoginBacSi24X7 = true;
                        BOSApp.CurrentBacSi24X7 = result.data;

                        if (result.data.hospitals == null || result.data.hospitals.Length == 0)
                        {
                            MessageBox.Show(BaseLocalizedResources.HospitalEmpty,
                                CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            _listHospitals = result.data.hospitals;
                            var listName = _listHospitals.Select(x => x.name).ToArray();
                            fld_cboBranch.Properties.Items.AddRange(listName);
                            fld_cboBranch.SelectedIndex = 0;
                            _brBranchsController = new BRBranchsController();
                            var userResult = _userBs247Manager.GetUserDetailsIncludeClinic(BOSApp.CurrentBacSi24X7.userId,
                                BOSApp.CurrentBacSi24X7.userId, BOSApp.CurrentBacSi24X7.sessionId);
                            _userBacsi24X7 = userResult.data.user;
                            panelControl1.Visible = false;
                            fld_panelSelectBranch.Visible = true;
                        }
                    }
                }
                else
                {
                    var paramList = new Dictionary<string, object>();
                    object data = null;
                    //login by call api his or sql
                    //uu tiên api
                    if (!string.IsNullOrEmpty(_apiLogin))
                    {
                        string passwordSend = fld_txtPassword.Text;
                        var methodHash = BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, "HASH_PASSWORD_TO_HIS");
                        if (!string.IsNullOrEmpty(methodHash))
                        {
                            var hashProvider = new HashProvider(methodHash);
                            passwordSend = hashProvider.ComputeHash(Encoding.ASCII.GetBytes(fld_txtPassword.Text)).ToLower();
                        }

                        data = _apiHis.Post(_apiLogin,
                          paramList,
                          new
                          {
                              User = fld_txtUserName.Text,
                              user = fld_txtUserName.Text,
                              Pass = passwordSend,
                              pass = passwordSend,
                              IP = ip,
                              ip
                          });
                    }
                    else if (!string.IsNullOrEmpty(_spLogin))
                    {
                        paramList.Add("username", fld_txtUserName.Text);
                        paramList.Add("password", fld_txtPassword.Text);
                        paramList.Add("ip", ip);
                        data = JObject.FromObject(_sqlHelper.Get(_spLogin, paramList).FirstOrDefault());
                    }
                    if (!string.IsNullOrEmpty(_spLogin) || !string.IsNullOrEmpty(_apiLogin))
                    {
                        if (data != null)
                        {
                            //ip success update pw to db
                            var value = data as JObject;
                            if (!value.ContainsKey("success"))
                            {
                                MessageBox.Show("HIS trả về dữ liệu không đúng khi gọi api/sp login", "Lỗi từ HIS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (value["success"].ToString().ToLower() == "true")
                            {
                                ADUsersInfo user = null;
                                //Nếu login API không trả về user_id, EMR sẽ login theo cách cũ
                                if (value.ContainsKey("user_id") && !string.IsNullOrEmpty(value["user_id"].ToString()))
                                {
                                    user = _usersController.GetFirstObjectByStringColumn("ADUserHISID", value["user_id"].ToString()) as ADUsersInfo;
                                }
                                else
                                {
                                    user = _usersController.GetObjectByName(fld_txtUserName.Text) as ADUsersInfo;
                                }
                                if (user == null)
                                {
                                    MessageBox.Show("Người dùng này không tồn tại trên CHC.EMR. Vui lòng tạo người dùng.",
                                    "Không tìm thấy người dùng.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                                else
                                {
                                    byte[] passwordBytes = SHA1Managed.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(fld_txtPassword.Text));
                                    user.ADPassword = Convert.ToBase64String(passwordBytes);
                                    //cap nhat lai username theo HIS
                                    if (value.ContainsKey("user_id") && !string.IsNullOrEmpty(value["user_id"].ToString()))
                                        user.ADUserName = fld_txtUserName.Text;

                                    _usersController.UpdateObject(user);
                                }
                                //login local
                                if (BOSApp.IsAuthenticated(fld_txtUserName.Text, fld_txtPassword.Text))
                                {
                                    if (!ForceLoginAtOtherMachine(hostName, mac, ip))
                                        return;

                                    user.ADUserOnComputerName = hostName;
                                    user.ADUserOnIpAddress = ip;
                                    user.ADUserOnComputerMAC = mac;

                                    _usersController.UpdateObject(user);

                                    BOSApp.IsLoginBacSi24X7 = false;
                                    BOSApp.SetCurrentUserLogin(fld_txtUserName.Text);
                                    if (value.ContainsKey("token"))
                                        BOSApp.ApiToken = value["token"].ToString();

                                    var userName = fld_txtUserName.Text;
                                    var pwd = fld_txtPassword.Text;
                                    GetEmrApiToken(userName, pwd);
                                    //Task.Run(() =>
                                    //{
                                    //    GetEmrApiToken(userName, pwd);
                                    //});
                                    BOSApp.ConnectToSignalHub();

                                    DialogResult = DialogResult.OK;
                                    Dispose();
                                }
                            }
                            else
                            {
                                var msg = BaseLocalizedResources.InvalidAuthenticationMessage;
                                if (value.ContainsKey("msg"))
                                {
                                    msg = value["msg"].ToString();
                                }
                                MessageBox.Show(msg, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            var msg = BaseLocalizedResources.InvalidAuthenticationMessage;
                            MessageBox.Show(msg, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        if (BOSApp.IsAuthenticated(fld_txtUserName.Text, fld_txtPassword.Text))
                        {

                            if (!ForceLoginAtOtherMachine(hostName, mac, ip))
                                return;

                            BOSApp.IsLoginBacSi24X7 = false;
                            var user = BOSApp.SetCurrentUserLogin(fld_txtUserName.Text);
                            BOSApp.ApiToken = "local-logined";

                            user.ADUserOnComputerName = hostName;
                            user.ADUserOnIpAddress = ip;
                            user.ADUserOnComputerMAC = mac;

                            _usersController.UpdateObject(user);

                            if (!user.ADUserActiveCheck)
                            {
                                MessageBox.Show("Người dùng không hoạt động. Vui lòng liên hệ quản trị viên.",
                                CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                var userName = fld_txtUserName.Text;
                                var pwd = fld_txtPassword.Text;
                                //Task.Run(() =>
                                //{
                                //    GetEmrApiToken(userName, pwd);
                                //});
                                GetEmrApiToken(userName, pwd);
                                //GetEmrApiToken(fld_txtUserName.Text, fld_txtPassword.Text);
                                BOSApp.ConnectToSignalHub();
                                DialogResult = DialogResult.OK;
                            }
                            Dispose();
                        }
                        else
                        {
                            var msg = BaseLocalizedResources.InvalidAuthenticationMessage;
                            MessageBox.Show(msg, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            } 
            catch(ThreadAbortException)
            {
                Thread.ResetAbort(); // tránh crash
            } 
            
           
        }

        private void GetEmrApiToken(string userName, string password)
        {
            if (_apiEmr == null) return;
            var body = new { UsernameOrEmailAddress = userName, password };
            try
            {
                var response = _apiEmr.Post<AjaxResponse, JObject>("authenticate/internal", null, body);
                if (response != null)
                {
                    if (response.Success)
                    {
                        if (response.Result.ContainsKey("authToken"))
                            BOSApp.EmrApiAuthToken = response.Result["authToken"].ToString();
                        if (response.Result.ContainsKey("sessionToken"))
                            BOSApp.EmrApiSessionToken = response.Result["sessionToken"].ToString();
                    }
                    else
                    {
                        MessageBox.Show($"Đăng nhập EMR API không thành công.\nMỘT SỐ TÍNH NĂNG SẼ BỊ GIỚI HẠN. " +
                            $"\nVui lòng kiểm tra thông tin người dùng." +
                            $"\n\nChi tiết: {response.Error?.Message} {response.Error?.Details}",
                            "ĐĂNG NHẬP EMR API KHÔNG THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    throw new Exception("KHÔNG CÓ KẾT QUẢ TRẢ VỀ TỪ API");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng nhập EMR API không thành công.\nMỘT SỐ TÍNH NĂNG SẼ BỊ GIỚI HẠN. " +
                    $"\nVui lòng kiểm tra tra lại kết nối. \n\nChi tiết lỗi: {ex.ToString()}",
                    "ĐĂNG NHẬP EMR API KHÔNG THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            fld_btnCancel.PerformClick();
        }

        private int CreateUserGroup(string name)
        {
            //Create group user for new Account
            var objAdUserGroupsInfo = new ADUserGroupsInfo
            {
                ADUserGroupName = name,
                ADLanguageIDCombo = 1,
                ADUserGroupDesc = name
            };
            return _userGroupsController.CreateObject(objAdUserGroupsInfo);
        }

        private void CreateFunctions(int idGroup)
        {
            //Create Section and Module
            var listSection = Constant.ListModuleFree;

            for (var i = 0; i < listSection.GetLength(0); i++)
            {
                var section = listSection[i, 0];
                var groupSection = new ADUserGroupSectionsInfo
                {
                    ADUserGroupID = idGroup,
                    ADUserGroupSectionName = section,
                    ADUserGroupSectionDesc = section,
                    ADUserGroupSectionSortOrder = i + 1
                };
                var sectionId = _userGroupSectionsController.CreateObject(groupSection);
                var modules = listSection[i, 1];
                var listModule = modules.Split(',');
                var sort = 1;
                foreach (var s in listModule)
                {
                    var module = new STModuleToUserGroupSectionsInfo()
                    {
                        STUserGroupSectionID = sectionId,
                        STModuleID = int.Parse(s),
                        STModuleToUserGroupSectionSortOrder = sort++
                    };
                    _moduleToUserGroupSectionsController.CreateObject(module);
                }
            }

        }

        private void guiLogin_Load(object sender, EventArgs e)
        {
            this.TopLevel = true;
            this.Activate();
        }

        private void hplForceUpdate_MouseClick(object sender, MouseEventArgs e)
        {
            BOSApp.ForceUpdateApp();
        }
        public static void LogTxt(string type, string message, string fileName = null)
        {
            try
            {
                var logPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\logs";
                Directory.CreateDirectory(logPath);
                var now = DateTime.Now;
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = $"GuiLogin" + now.ToString("yyyyMMdd") + ".txt";
                }

                logPath = Path.Combine(logPath, fileName);
                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    sw.WriteLine($"{now} : {type} : {message}");
                }
            }
            catch { }
        }
    }
}