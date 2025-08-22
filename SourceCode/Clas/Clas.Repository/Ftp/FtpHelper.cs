using BOSCommon;
using BOSLib;
using BOSLib.DataAccess;
using Emr;
using FluentFTP;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Repository.Ftp
{
    public class FtpHelper
    {
        private string _ftpHost;
        private int _ftpPort = 0;
        private string _ftpPassword;
        private string _ftpRootFilePath;
        private string _ftpUser;
        private bool _notUseFtp;
        private int _ftpConnectTimeout;
        private int _ftpReadTimeout;
        private int _ftpDataConnectionConnectTimeout;
        private int _ftpDataConnectionReadTimeout;
        /// <summary>
        /// Ut khong muon refactor vi co the gay ra loi nen code hoi roi
        /// </summary>
        public FtpHelper()
        {
            Crypto cryp = new Crypto();
            //if (!string.IsNullOrEmpty(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_HOST)))
            if (!string.IsNullOrEmpty(SqlDatabaseHelper._PRIVATE_FTP_HOST))
            {
                //_ftpHost = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_HOST), true);
                _ftpHost = SqlDatabaseHelper._PRIVATE_FTP_HOST;
                _ftpPort = Convert.ToInt32(cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_PORT), true));
                _ftpUser = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_USER), true);
                _ftpPassword = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_PASSWORD), true);
                _ftpConnectTimeout = Convert.ToInt32(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_CONNECT_TIMEOUT)); //15000;
                _ftpReadTimeout = Convert.ToInt32(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_READ_TIMEOUT)); //15000;
                _ftpDataConnectionConnectTimeout = Convert.ToInt32(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_DATACONNECTIONCONNECT_TIMEOUT)); //15000;
                _ftpDataConnectionReadTimeout = Convert.ToInt32(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_DATACONNECTIONREAD_TIMEOUT)); //15000;
                if (string.IsNullOrEmpty(_ftpUser))
                {
                    _ftpUser = "anonymous";
                }
            }

            if (string.IsNullOrEmpty(_ftpHost))
            {
                _notUseFtp = true; // USE PATH LOCAL
            }

            _ftpRootFilePath = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_ROOT_PATH), true);

        }
        public FtpHelper(string ftpHost, string ftpPassword, string ftpRootFilePath, string ftpUser)
        {
            _ftpHost = ftpHost;
            _ftpPassword = ftpPassword;
            _ftpRootFilePath = ftpRootFilePath;
            _ftpUser = ftpUser;
        }

        public void CreateDirectory(string dir)
        {
            dir = _ftpRootFilePath + dir;
            if (_notUseFtp)
            {
                Directory.CreateDirectory(dir);
            }
            else
            {
                FtpClient client = FtpClientInit();
                try
                {
                    if (!client.DirectoryExists(dir))
                    {
                        client.CreateDirectory(dir);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect();
                }
            }
        }

        public string CopyFile(string from, string to, string localPath)
        {
            from = _ftpRootFilePath + from;
            to = _ftpRootFilePath + to;

            if (_notUseFtp) {
                File.Copy(from, localPath, true);
                File.Copy(localPath, to, true);
                return to;
            }
            else
            {
                FtpClient client = FtpClientInit();
                try
                {
                    if (client.FileExists(from))
                    {
                        client.DownloadFile(localPath, from, FtpLocalExists.Overwrite);
                        client.UploadFile(localPath, to, FtpExists.Overwrite, false, FtpVerify.Retry | FtpVerify.Throw);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect();
                }
                return to;
            }
        }

        public string CopyAllFiles(string from, string to, string localDir)
        {
            from = _ftpRootFilePath + from;
            to = _ftpRootFilePath + to;
            if (_notUseFtp)
            {
                if (Directory.Exists(from))
                {
                    Directory.CreateDirectory(to);
                    foreach (var file in Directory.GetFiles(from))
                    {
                        File.Copy(file, localDir + Path.GetFileName(file));
                        File.Copy(file, to + Path.GetFileName(file));
                    }
                    return to;
                }
                return string.Empty;
            }
            else
            {
                FtpClient client = FtpClientInit();
                try
                {
                    if (client.DirectoryExists(from))
                    {
                        if (!client.DirectoryExists(to))
                        {
                            client.CreateDirectory(to);
                        }
                        foreach (FtpListItem item in client.GetListing(from))
                        {
                            // if this is a file
                            if (item.Type == FtpFileSystemObjectType.File)
                            {
                                //client.MoveFile(item.FullName, to + "/" + item.Name, FtpExists.Overwrite);
                                client.DownloadFile(localDir + item.Name, item.FullName, FtpLocalExists.Overwrite);
                                client.UploadFile(localDir + item.Name, to + item.Name, FtpExists.Overwrite, false, FtpVerify.Retry | FtpVerify.Throw);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect();
                }
                return to;
            }
        }

        public bool FileExists(string serverPath, string serverFile)
        {
            serverPath = _ftpRootFilePath + serverPath;
            if (_notUseFtp)
            {
                return File.Exists(serverPath + serverFile);
            }
            else
            {
                FtpClient client = FtpClientInit();
                var result = false;
                try
                {
                    result = client.FileExists(serverPath + serverFile);
                }
                catch (Exception)
                {
                    //throw;
                }
                finally
                {
                    client.Disconnect();
                }
                return result;
            }
        }

        public string DownloadFile(string serverPath, string serverFile, string localPath)
        {
            serverPath = _ftpRootFilePath + serverPath;
            if (_notUseFtp) {
                File.Copy(serverPath + serverFile, localPath, true);
                return localPath;
            }
            else
            {
                FtpClient client = FtpClientInit();
                try
                {
                    client.DownloadFile(localPath, serverPath + serverFile, FtpLocalExists.Overwrite);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect();
                }
                return localPath;
            }
            
        }

        public string UploadFile(string serverPath, string serverFile, string localPath)
        {
            serverPath = _ftpRootFilePath + serverPath;
            if (_notUseFtp) 
            {
                if (!Directory.Exists(serverPath))
                {
                    throw new Exception("Folder not found. " + serverPath);
                }
                File.Copy(localPath, serverPath + serverFile, true);
                return localPath; 
            }
            else
            {
                FtpClient client = FtpClientInit();
                try
                {
                    if (!client.DirectoryExists(serverPath))
                    {
                        client.Disconnect();
                        throw new Exception("Ftp folder not found. " + serverPath);
                    }
                    client.UploadFile(localPath, serverPath + serverFile, FtpExists.Overwrite, false, FtpVerify.Retry | FtpVerify.Throw);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect();
                }
                return localPath;
            }
        }

        public string UploadFileSafe(string serverPath, string serverFile, string localPath)
        {
            var result = string.Empty;
            serverPath = _ftpRootFilePath + serverPath;
            var ext = Path.GetExtension(serverFile);
            var flag = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var tempFile = $"{Path.GetFileNameWithoutExtension(serverFile)}_{flag}{ext}";
            var fullTempFile = $"{serverPath}{tempFile}";
            if (_notUseFtp) 
            {
                if (!Directory.Exists(serverPath))
                {
                    throw new Exception("Folder not found. " + serverPath);
                }
                File.Copy(localPath, fullTempFile, true);
                return tempFile;
            }
            else
            {
                FtpClient client = FtpClientInit();
                try
                {
                    client.UploadFile(localPath, fullTempFile, FtpExists.Overwrite, false);
                    result = tempFile;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect();
                }
                return result;
            }
        }

        public string[] GetNameListing(string serverPath)
        {
            serverPath = _ftpRootFilePath + serverPath;
            string[] result = new string[] { };
            if (_notUseFtp) 
            {
                result = Directory.GetFiles(serverPath);
                return result; 
            }
            else
            {
                FtpClient client = FtpClientInit();
                try
                {
                    result = client.GetNameListing(serverPath);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect();
                }
                return result;
            }
        }

        public string DownloadFiles(string localDir, string remotePath, string exceptFile)
        {
            if (_notUseFtp)
            {
                foreach (var item in Directory.GetFiles(remotePath))
                {
                    if (item != exceptFile)
                    {
                        File.Copy(remotePath + item, localDir + item, true);
                    }
                }
                return localDir;
            }
            else
            {
                FtpClient client = FtpClientInit();
                try
                {
                    foreach (FtpListItem item in client.GetListing(remotePath))
                    {
                        if (item.Type == FtpFileSystemObjectType.File && item.Name != exceptFile)
                        {
                            client.DownloadFile(Path.Combine(localDir, item.Name), item.FullName, FtpLocalExists.Overwrite);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect();
                }
                return localDir;
            }
            
        }

        public void RenameFile(string from, string to)
        {
            from = _ftpRootFilePath + from;
            to = _ftpRootFilePath + to;
            if (_notUseFtp) {
                if (File.Exists(from))
                {
                    File.Delete(to);
                    File.Move(from, to);
                }
            }
            else
            {
                FtpClient client = FtpClientInit();

                if (client.FileExists(from))
                {
                    client.Rename(from, to);
                }
                client.Disconnect();
            }
        }

        public void Rename(string serverPath, string sourceFile, string targetFile)
        {
            serverPath = _ftpRootFilePath + serverPath;
            if (_notUseFtp) {
                File.Delete(serverPath +  targetFile);
                File.Move(serverPath + sourceFile, serverPath + targetFile);
            }
            else
            {
                FtpClient client = FtpClientInit();
                try
                {
                    // delete before
                    client.DeleteFile($"{serverPath}{targetFile}");
                    client.Rename($"{serverPath}{sourceFile}", $"{serverPath}{targetFile}");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect();
                }
            }
        }

        public void MoveFile(string serverPath, string sourceFile, string targetFile)
        {
            serverPath = _ftpRootFilePath + serverPath;
            if (_notUseFtp) {
                File.Delete(serverPath + targetFile);
                File.Move(serverPath + sourceFile, serverPath + targetFile);
            }
            else
            {
                FtpClient client = FtpClientInit();
                try
                {
                    client.MoveFile($"{serverPath}{sourceFile}", $"{serverPath}{targetFile}");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect();
                }
            }
        }

        public void Delete(string serverPath, string file)
        {
            serverPath = _ftpRootFilePath + serverPath;
            if (_notUseFtp) {
                File.Delete(serverPath + file);
            }
            else
            {
                FtpClient client = FtpClientInit();
                try
                {
                    client.DeleteFile($"{serverPath}{file}");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect();
                }
            }
        }

        private FtpClient FtpClientInit()
        {
            // create an FTP client
            FtpClient client = new FtpClient
            {
                Host = _ftpHost,
                // if you don't specify login credentials, we use the "anonymous" user account
                Credentials = new NetworkCredential(_ftpUser, _ftpPassword),
                RetryAttempts = 3
            };

            if (_ftpPort != 0) client.Port = _ftpPort;

            client.ConnectTimeout = _ftpConnectTimeout;
            client.ReadTimeout = _ftpReadTimeout;
            client.DataConnectionConnectTimeout = _ftpDataConnectionConnectTimeout;
            client.DataConnectionReadTimeout = _ftpDataConnectionReadTimeout;

            // begin connecting to the server
            client.Connect();
            return client;
        }
    }
}
