using Clas.Repository.Ftp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Business.Ftp
{
    public class FileTemplateManager
    {
        FtpHelper _ftp;
        public FileTemplateManager()
        {
            _ftp = new FtpHelper();
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
            try
            {
                return _ftp.DownloadFile(serverPath, serverFile, localPath);
            }
            catch (Exception ex)
            {
                Trace.TraceError("DownloadFile_Init: {0} - {1} :{2}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), serverPath + serverFile, ex);
                throw new FtpException();
            }
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

        public string UploadFileSafe(string serverPath, string serverFile, string localPath)
        {
            return _ftp.UploadFileSafe(serverPath, serverFile, localPath);
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
        public bool FileExists(string serverPath, string serverFile)
        {
            return _ftp.FileExists(serverPath, serverFile);
        }

        public string[] GetNameListing(string serverPath)
        {
            return _ftp.GetNameListing(serverPath);
        }

        public string DownloadFiles(string localDir, string remotePath, string exceptFile)
        {
            try
            {
                return _ftp.DownloadFiles(localDir, remotePath, exceptFile);
            }
            catch (Exception ex)
            {
                Trace.TraceError("DownloadFiles_Init: {0} - {1} :{2}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), string.Join(";", remotePath), ex);
                throw new FtpException();
            }
        }

        public void RenameFile(string from, string to)
        {
            _ftp.RenameFile(from, to);
        }

        public void Rename(string serverPath, string sourceFile, string targetFile)
        {
            _ftp.Rename(serverPath, sourceFile, targetFile);
        }

        public void MoveFile(string serverPath, string sourceFile, string targetFile)
        {
            _ftp.MoveFile(serverPath, sourceFile, targetFile);
        }

        public void Delete(string serverPath, string file)
        {
            _ftp.Delete(serverPath, file);
        }
    }
}
