using BOSLib;
using FluentFTP;
using MongoDB.Driver;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Microsoft.VisualBasic.Devices;
using Clas.Business.Ftp;
using Emr;
using BOSLib.DataAccess;
using BOSCommon;

namespace BOSERP
{
    public class SystemHelper
    {
        public SystemHelper()
        {
        }

        public int CheckNetwork()
        {
            return 0;
        }

        public int CheckAPI()
        {
            return 0;
        }

        //public string StatusSqlConnection()
        //{
        //    try
        //    {
        //        Crypto cryp = new Crypto();
        //        string serverName = cryp.DecryptNew(ConfigurationManager.AppSettings["ServerName"], true);
        //        string databaseName = cryp.DecryptNew(ConfigurationManager.AppSettings["DatabaseName"], true);
        //        string userID = cryp.DecryptNew(ConfigurationManager.AppSettings["UserID"], true);
        //        string password = cryp.DecryptNew(ConfigurationManager.AppSettings["Password"], true);
        //        var connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", serverName, databaseName, userID, password);
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                return "OK";
        //            }
        //            catch (SqlException sqlEx)
        //            {
        //                return sqlEx.ToString();
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}

        //public string StatusMongoConnection()
        //{
        //    // Use later...
        //    try
        //    {
        //        Crypto cryp = new Crypto();
        //        var host = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_MONGO_HOST), true);
        //        var port = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_MONGO_PORT), true);
        //        var user = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_MONGO_USER), true);
        //        var pw = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_MONGO_PW), true);
        //        var authSource = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_MONGO_AUTH_SOURCE), true);
        //        var dbName = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_MONGO_DB), true);
        //        var connectionString = string.Format("mongodb://{0}:{1}@{2}:{3}/{4}?authSource={5}",
        //            user, pw, host, port, dbName, authSource);
        //        var client = new MongoClient(connectionString);
        //        var dbList = client.ListDatabases().ToList();
        //        if (dbList != null && dbList.Count() > 0)
        //        {
        //            return "OK";
        //        }
        //        else
        //        {
        //            return "Không tìm thấy cơ sở dữ liệu: "+ dbName;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}

        //public string StatusFTPConnection()
        //{
            //try
            //{
            //    Crypto cryp = new Crypto();
            //    var ftpHost = ConfigurationManager.AppSettings["ftp_host"];
            //    if (string.IsNullOrEmpty(ftpHost))
            //    {
            //        return "Không cấu hình sử dụng FTP để upload tờ bệnh án.";
            //    }

            //    var ftpAppDir = ConfigurationManager.AppSettings["ftp_app_dir"];
            //    var ftpUser = ConfigurationManager.AppSettings["ftp_user"];
            //    if (!string.IsNullOrEmpty(ftpUser))
            //        ftpUser = cryp.DecryptNew(ftpUser, true);
            //    var ftpPassword = ConfigurationManager.AppSettings["ftp_password"];
            //    if (!string.IsNullOrEmpty(ftpPassword))
            //    {
            //        ftpPassword = cryp.DecryptNew(ftpPassword, true);
            //    }
            //    if (string.IsNullOrEmpty(ftpUser))
            //    {
            //        ftpUser = "anonymous";
            //    }
            //    // create an FTP client
            //    FtpClient client = new FtpClient
            //    {
            //        Host = ftpHost,
            //        Credentials = new NetworkCredential(ftpUser, ftpPassword)
            //    };
            //    client.Connect();
            //    client.Disconnect();
            //    return "OK";
            //}
            //catch (Exception ex)
            //{
            //    return ex.ToString();
            //}
        //}

        public bool AllowThread()
        {
            var configAllowThread = ConfigurationManager.AppSettings["allow_thread"] == "true";
            if (configAllowThread)
            {
                var memoryConfigSt = ConfigurationManager.AppSettings["free_memory_allow"];
                if (string.IsNullOrEmpty(memoryConfigSt))
                {
                    return true;
                }

                var memoryFree = Convert.ToInt32(new ComputerInfo().AvailablePhysicalMemory / 1048576); //mb
                var memoryConfig = Convert.ToInt32(memoryConfigSt);
                if (memoryFree < memoryConfig)
                {
                    return false;
                }
                return true;
            }

            return false;
        }

        public void LogTxt(string type, string message, string fileName = null, bool? upload = false)
        {
            try
            {
                var logPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\logs";
                Directory.CreateDirectory(logPath);
                var now = DateTime.Now;
                if (string.IsNullOrEmpty(fileName))
                {
                    var macAddress = BOSApp.GetMachineMac();
                    var ipAddress = BOSApp.GetMachineIp();
                    var hostName = Dns.GetHostName();
                    fileName = SanitizedFileName.Sanitize($"{type}_{macAddress}_{ipAddress}_", "_") + now.ToString("yyyyMMdd") + ".txt";
                }

                logPath = Path.Combine(logPath, fileName);
                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    sw.WriteLine($"{now} : {message}");
                }

                if ((bool)upload)
                {
                    FileTemplateManager _ftpFileMng = new FileTemplateManager();
                    _ftpFileMng.UploadFile("/Logs/", fileName, logPath);
                }
            }
            catch { }
        }

        public bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}")
                   || input.StartsWith("[") && input.EndsWith("]");
        }
    }
}
