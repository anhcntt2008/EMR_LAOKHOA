using BOSLib;
using DevExpress.XtraReports.UserDesigner;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emr.Report
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            App.ReportLocalDir = string.Format(@"{0}\ReportFile", Application.StartupPath);

            var args = Environment.GetCommandLineArgs();
            if (args.Length < 2)
            {
                MessageBox.Show("Công cụ phải được gọi từ EMR. Không khởi chạy trực tiếp được.");
                //var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //App.FtpHost = configuration.AppSettings.Settings["ftp_host"].Value.ToString();
                //App.FtpRootFilePath = configuration.AppSettings.Settings["ftp_report_dir"]?.Value.ToString();
                //Crypto cryp = new Crypto();

                //App.FtpUser = configuration.AppSettings.Settings["ftp_user"].Value.ToString();
                //if (!string.IsNullOrEmpty(App.FtpUser))
                //    App.FtpUser = cryp.DecryptNew(App.FtpUser, true);
                //App.FtpPassword = configuration.AppSettings.Settings["ftp_password"].Value.ToString();
                //if (!string.IsNullOrEmpty(App.FtpPassword))
                //    App.FtpPassword = cryp.DecryptNew(App.FtpPassword, true);
                //if (string.IsNullOrEmpty(App.FtpUser))
                //    App.FtpUser = "anonymous";
            }
            else
            {
                Crypto cryp = new Crypto();

                App.FtpHost = args[2];
                App.FtpUser = args[3];
                App.FtpPassword = args[4];
                App.FtpRootFilePath = args[5];
                App.DataSourceName = args[7];
                App.ConnString = cryp.Decrypt(args[8]);
                var base64EncodedBytes = System.Convert.FromBase64String(args[9]);
                var ctxStr = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                App.Context = JsonConvert.DeserializeObject<Dictionary<string, object>>(ctxStr);

                if (args[1] == "DESIGNER")
                {
                    try
                    {
                        Type moduleType = Assembly.LoadFrom(Application.StartupPath + "\\Emr.Report.Designer.dll").GetType("Emr.Report.DesignerTool");
                        var gui = (XRDesignRibbonForm)moduleType.InvokeMember("", BindingFlags.CreateInstance, null, null, new object[] { args[6] });
                        //Application.Run(new DesignerTool(args[6]));
                        Application.Run(gui);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không hỗ trợ chức năng này.", "Vui lòng liên hệ nhà cung cấp", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    Application.Run(new ViewerForm(args[6]));
                }
            }
        }
    }
}
