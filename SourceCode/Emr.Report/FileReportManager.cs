using Clas.Repository.Ftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Report
{
    public class FileReportManager
    {
        FtpHelper _ftp;
        public FileReportManager()
        {
            _ftp = new FtpHelper(App.FtpHost, App.FtpPassword, App.FtpRootFilePath, App.FtpUser);
        }
        /// <summary>
        /// UtHV
        /// 12042017 
        /// Download file to local, will be overide local if exists
        /// </summary>
        /// <param name="serverPath"></param>
        /// <param name="serverFile"></param>
        /// <param name="localPath"></param>
        /// <returns></returns>
        public string DownloadFile(string serverPath, string serverFile, string localPath)
        {
            return _ftp.DownloadFile(serverPath, serverFile, localPath);
        }
        public bool FileExists(string serverPath, string serverFile)
        {
            return _ftp.FileExists(serverPath, serverFile);
        }

        /// <summary>
        /// UtHV
        /// 12042017 
        /// Upload file to server, will be overide server if exists
        /// </summary>
        /// <param name="serverPath"></param>
        /// <param name="serverFile"></param>
        /// <param name="localPath"></param>
        /// <returns></returns>
        public string UploadFile(string serverPath, string serverFile, string localPath)

        {
            return _ftp.UploadFile(serverPath, serverFile, localPath);
        }

        public void CreateDirectory(string dir)
        {
            _ftp.CreateDirectory(dir);
        }

        public string CopyFile(string from, string to, string localPath)
        {
            return _ftp.CopyFile(from, to, localPath);
        }
        public string CopyAllFiles(string from, string to, string localDir)
        {
            return _ftp.CopyAllFiles(from, to, localDir);
        }
    }
}
