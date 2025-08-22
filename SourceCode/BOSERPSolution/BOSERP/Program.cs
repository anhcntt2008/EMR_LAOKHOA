using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using Localization;
using System.Reflection;
using System.Diagnostics;
using BOSBase;
using DevExpress.XtraLayout.Localization;
using AutoMapper;
using Clas.Model.Mongo;
using Clas.Model.Domain;
using System.Threading.Tasks;
using BOSLib;
using System.Linq;
using BOSCommon;
using BOSLib.DataAccess;

namespace BOSERP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                const string appProcess = "EMR";
                // XUANTM load system configs to cache
                // If no use, edit code in BOSApp line 2241.
                BOSApp.GetPrivateConfigs();
                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var allowMultiProcess = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_ALLOW_MULTI_PROCESS) == "true";
                Process[] emrs = Process.GetProcessesByName(appProcess);
                if (emrs.Count() > 1 && !allowMultiProcess)
                {
                    MessageBox.Show("Có tiến trình Bệnh án điện tử EMR khác đang chạy.", "Chỉ cho phép 01 tiến trình", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                    return;
                }
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var assembly = Assembly.GetExecutingAssembly();

                Task.Run(() =>
                {
                    BOSApp.EmrAssembly = Assembly.LoadFrom(Application.StartupPath + "\\EMR.exe");
                });

                BOSApp.LoadingThread = new Thread(new ThreadStart(SS));
                BOSApp.LoadingThread.Start();

                var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                //Check Version DB
                var verCtrl = new GEVersionsController();

                // NOT FINISH
                //var license = verCtrl.CheckLicense();

                var newVersion = verCtrl.GetDbVersion();
                var checkVersion = verCtrl.CheckVersion(newVersion, fvi.FileVersion);
                checkVersion = 0; //FOR TESTING, REMOVE THIS LINE WHEN RELEASE
                LayoutLocalizer.Active = new LayoutLocalizer();
                if (checkVersion == 0)
                {
                    BOSApp.FileVersion = fvi.FileVersion;
                    //uthv automapper
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<MEEmrDocumentsInfo, EmrDocument>();
                        cfg.CreateMap<EmrDocument, MEEmrDocumentsInfo>();
                        cfg.CreateMap<MEEmrsInfo, Clas.Model.Mongo.Emr>();
                        cfg.CreateMap<MEEmrsInfo, MEEmrsDto>();
                        cfg.CreateMap<MEEmrDocumentsInfo, MEEmrDocumentsDto>();
                        cfg.CreateMap<HRDepartmentsInfo, HRDepartmentsDto>();
                        cfg.CreateMap<HREmployeesInfo, HREmployeesDto>();
                        cfg.CreateMap<MEEmrDocumentSignsInfo, MEEmrDocumentSignsDto>();
                        cfg.CreateMap<MEEmrShareHistoriesInfo, MEEmrShareHistoriesDto>();
                        cfg.CreateMap<MEEmrTransferHistoriesInfo, MEEmrTransferHistoriesDto>();
                        cfg.CreateMap<MEPatientsInfo, MEPatientsDto>();
                    });

                    Task.Run(async () =>
                    {
                        BOSApp.V100COMPort = await Emr.Devices.GeV100.GeV100SerialConn.ComPortDetectAsync();
                    });

                    /*Task.Run(async () =>
                    {
                        await Task.Delay(30000); //30 giay cho mainform khoi tao xong
                        await BOSApp.ConnectToSignalrHub();
                    });
                    */

                    Task.Run(() =>
                    {
                        BOSApp.Init();
                        BOSApp.DetectDevide(0);
                    });

                    Application.Run(new GUIMain());
                }
                else
                {
                    if (checkVersion < 0)
                    {
                        Crypto cryp = new Crypto();
                        //var ftpHost = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_HOST), true);
                        var ftpHost = SqlDatabaseHelper._PRIVATE_FTP_HOST;
                        //_ftpPort = Convert.ToInt32(cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_PORT), true));
                        var ftpUser = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_USER), true);
                        var ftpPassword = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_PASSWORD), true);
                        var ftpAppDir = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_APP_DIR), true);
                        if (string.IsNullOrEmpty(ftpUser))
                            ftpUser = "anonymous";
                        var fullUpdate = true;

                        var allVersions = verCtrl.GetAllDbVersion();
                        var currentDbVersion = allVersions.Where(v => v.ToString() == fvi.FileVersion).FirstOrDefault();
                        //cach 2 version tro len thi full update
                        if (currentDbVersion != null && currentDbVersion.GEVersionID == newVersion.GEVersionID - 1)
                            fullUpdate = false;

                        if (!string.IsNullOrEmpty(ftpAppDir))
                        {
                            var nextVerPath = Application.StartupPath + @"\updater\";
                            var updater = nextVerPath + "ChcEmr.NextVer.exe";
                            if (Directory.Exists(nextVerPath))
                            {
                                nextVerPath = Directory.GetDirectories(nextVerPath, "*", SearchOption.TopDirectoryOnly).OrderByDescending(f => f).FirstOrDefault();
                                updater = nextVerPath?.ToString() + @"\ChcEmr.NextVer.exe";
                            }
                            //old updater version
                            if (!File.Exists(updater))
                                updater = Application.StartupPath + @"\updater\Updater.exe";

                            var destDir = "\"" + Application.StartupPath + "\\";
                            BOSApp.LoadingThread.Abort();
                            string cmd = "|ftpHost|" + ftpHost;
                            cmd += "|ftpAppDir|" + ftpAppDir;
                            cmd += "|ftpUser|" + ftpUser;
                            cmd += "|ftpPw|" + ftpPassword;
                            cmd += "|version|" + newVersion.ToString();
                            cmd += "|destDir|" + destDir;
                            cmd += "|appProcess|" + appProcess;
                            cmd += "|fullUpdate|" + fullUpdate;
                            ProcessStartInfo startInfo = new ProcessStartInfo
                            {
                                //UseShellExecute = true,
                                //Verb = "runas",
                                FileName = updater,
                                Arguments = cmd
                            };
                            Process.Start(startInfo);
                        }
                        else
                            MessageBox.Show(CommonLocalizedResources.Version, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        MessageBox.Show(@"Bạn đang sử dụng phiên bản dữ liệu cũ. Vui lòng liên hệ quản trị để cập nhật dữ liệu.", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Application.Exit();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Vui lòng liên hệ IT hỗ trợ. Chi tiết lỗi: " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                return;
            }
        }

        private static void SS()
        {
            Application.Run(new guiLoading());
        }

    }
}