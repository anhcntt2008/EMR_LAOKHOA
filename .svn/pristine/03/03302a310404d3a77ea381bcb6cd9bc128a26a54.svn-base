using BOSCommon;
using BOSERP;
using BOSLib;
using Clas.Emr.Intergration;
using Emr.Base.Models.Abp;
using Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOSBase
{
    public class AutoLoginHisToEMR
    {
        private readonly ApiHelper _apiHisIntergrate;
        private readonly ADUsersController _usersController;

        public AutoLoginHisToEMR()
        {
            LogTxt($"LoginByHisLink", $"HISIntergrateEndPoint ---- start");

            _usersController = new ADUsersController();
            string hisIntergrateEndPoint = HISIntergrateEndPoint();
            LogTxt($"LoginByHisLink", $"HISIntergrateEndPoint ---- End");

            if (!string.IsNullOrEmpty(hisIntergrateEndPoint))
                _apiHisIntergrate = new ApiHelper(hisIntergrateEndPoint, "");
        }

        public bool IsAllowLoginByHIS()
        {
           return _apiHisIntergrate != null;
        }

        public bool LoginByHisLink()
        {
            if (_apiHisIntergrate == null)
                return false;
            var ip = BOSApp.GetMachineIp();
            var hostName = Dns.GetHostName();
            var mac = BOSApp.GetMachineMac();
            var body = new { MacAddress = mac };

            try
            {
                LogTxt($"LoginByHisLink", $"CheckTrangThaiDangNhap ---- start");
                var response = _apiHisIntergrate.Post<AjaxResponse, SingleResponse<string>>("AutoLoginHisToEmr/CheckTrangThaiDangNhap", null, body);
                LogTxt($"LoginByHisLink", $"CheckTrangThaiDangNhap ---- End");


                if (response != null)
                {
                    if (response.Success)
                    {
                        var result = response.Result;
                        if (result.IsSuccess)
                        {
                            if (!string.IsNullOrEmpty(result.Data))
                            {
                                LogTxt($"LoginByHisLink", $"SetCurrentUserLogin");

                                BOSApp.IsLoginBacSi24X7 = false;
                                var user = BOSApp.SetCurrentUserLogin(result.Data);
                                BOSApp.ApiToken = "local-logined";

                                user.ADUserOnComputerName = hostName;
                                user.ADUserOnIpAddress = ip;
                                user.ADUserOnComputerMAC = mac;
                                LogTxt($"LoginByHisLink", $" _usersController.UpdateObject");

                                _usersController.UpdateObject(user);

                                if (!user.ADUserActiveCheck)
                                {
                                    MessageBox.Show("Người dùng không hoạt động. Vui lòng liên hệ quản trị viên.",
                                    CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                    return false;
                                }
                                else
                                {
                                    //GetEmrApiToken(fld_txtUserName.Text, fld_txtPassword.Text);
                                    //BOSApp.ConnectToSignalHub();
                                    return true;
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Đăng nhập bằng tài khoản HIS không thành công. \n\nChi tiết lỗi: Bạn chưa đăng nhập HIS xin vui lòng thử lại",
                                "ĐĂNG NHẬP EMR HIS KHÔNG THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Đăng nhập bằng tài khoản HIS không thành công. \n\nChi tiết lỗi: {result.ErrorMessage.ToString()}",
                            "ĐĂNG NHẬP EMR HIS KHÔNG THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Đăng nhập bằng tài khoản HIS không thành công. \n\nChi tiết lỗi: Không thể kết nối đến HISLink_Intergrate",
                             "ĐĂNG NHẬP EMR HIS KHÔNG THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show($"Đăng nhập bằng tài khoản HIS không thành công. \n\nChi tiết lỗi: Không thể kết nối đến HISLink_Intergrate",
                               "ĐĂNG NHẬP EMR HIS KHÔNG THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng nhập bằng tài khoản HIS không thành công. \n\nChi tiết lỗi: Không thể kết nối đến HISLink_Intergrate",
                              "ĐĂNG NHẬP EMR HIS KHÔNG THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

        }
        private static string HISIntergrateEndPoint()
        {
            try
            {
                var endPoint = BOSApp.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.HIS_INTERGRATE_API_ENDPOINT);
                if (!string.IsNullOrEmpty(endPoint))
                    return endPoint;
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
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
                    fileName = $"AutoLoginHisToEmr" + now.ToString("yyyyMMdd") + ".txt";
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
