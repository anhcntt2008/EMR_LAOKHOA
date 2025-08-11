using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;
using FluentFTP;
using Ionic.Zip;

namespace BOSUpdater
{
    public partial class guiUpdater : Form
    {
        private bool _called = true;
        private string _tempDownDir = string.Empty;
        private string _appProcess = string.Empty;
        private string _ftpHost = string.Empty;
        private string _version = string.Empty;
        private string _destDir = string.Empty;
        private string _ftpPw;
        private string _ftpUser;
        private string _ftpAppDir;
        private string _appZip = "app.zip";
        private string _fullUpdate = "False";

        public guiUpdater()
        {
            InitializeComponent();
            txtMsg.Text = "Đang tải dữ liệu...";
        }

        private void guiUpdater_Load(object sender, EventArgs e)
        {

            Hide();
            if (_called)
            {
                WindowState = FormWindowState.Normal;
                Show();
                var bw = new BackgroundWorker();
                bw.DoWork -= new DoWorkEventHandler(BackgroundWorker);
                bw.DoWork += new DoWorkEventHandler(BackgroundWorker);
                bw.WorkerSupportsCancellation = true;
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
                bw.RunWorkerAsync();
            }
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void BackgroundWorker(object sender, DoWorkEventArgs e)
        {
            PreDownload();
            if (_called)
            {
                try
                {
                    Process[] processes = Process.GetProcesses();
                    foreach (Process process in processes)
                    {
                        if (process.ProcessName == _appProcess
                            || process.ProcessName == _appProcess + ".exe"
                            || process.ProcessName == _appProcess.Replace(".exe", string.Empty))
                        {
                            process.Kill();
                        }
                    }
                    var ok = DownloadFile();
                    if (!ok) return;

                    ShowMsg("Đang giải nén dữ liệu...");
                    ok = Unzip(_tempDownDir + "\\" + _appZip, _tempDownDir);
                    if (!ok) return;
                    ReportProgress(50);

                    MoveFiles(_tempDownDir, _destDir, _appZip);
                    ShowMsg("Đang xóa dữ liệu tạm...");
                    WrapUp();
                    PostDownload();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra. \n" + ex.ToString());
                }
            }
        }
        private void ShowMsg(string msg)
        {
            if (txtMsg.InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    txtMsg.Text = msg;
                }));
            }
            else
                txtMsg.Text = msg;
        }
        private void ReportProgress(int count)
        {
            if (progressBar1.InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    var value = progressBar1.Value + count;
                    if (progressBar1.Maximum < value)
                        progressBar1.Value = value;
                }));
            }
            else
            {
                var value = progressBar1.Value + count;
                if (progressBar1.Maximum < value)
                    progressBar1.Value = value;
            }
        }
        public bool DownloadFile()
        {
            var serverPath = string.Empty;
            if (_fullUpdate == "True")
                serverPath = _ftpAppDir + "/full/" + _version + "/";
            else
                serverPath = _ftpAppDir + "/" + _version + "/";

            // create an FTP client
            FtpClient client = new FtpClient();
            client.Host = this._ftpHost;
            // if you don't specify login credentials, we use the "anonymous" user account
            client.Credentials = new NetworkCredential(this._ftpUser, this._ftpPw);
            // begin connecting to the server
            client.Connect();

            if (!client.DirectoryExists(serverPath))
            {
                client.Disconnect();
                MessageBox.Show("Không tìm thấy thư mục. " + serverPath + "\n"
                    + "Cấu trúc thư mục server: \n"
                    + "-full \n"
                    + "  -ver.1 \n"
                    + "   -app.zip \n"
                    + "  -ver.2 \n"
                    + "-ver.1 \n"
                    + "  -app.zip \n");
                return false;
            }
            if (!client.FileExists(serverPath + "/" + _appZip))
            {
                client.Disconnect();
                MessageBox.Show("Không tìm thấy tập tin app.zip tại " + serverPath);
                return false;
            }
            var progress = new Progress<double>(x =>
            {
                // When progress in unknown, -1 will be sent
                if (x > 0)
                {
                    if (progressBar1.InvokeRequired)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            progressBar1.Value = (int)x;
                        }));
                    }
                    else
                        progressBar1.Value = (int)x;
                }
            });

            client.DownloadFile(_tempDownDir + "\\" + _appZip, serverPath + "/" + _appZip, FtpLocalExists.Overwrite, FtpVerify.None, progress);

            // disconnect! good bye!
            client.Disconnect();
            return true;
        }

        private void PreDownload()
        {
            UnpackCommandline();
            if (!Directory.Exists(_destDir)) Directory.CreateDirectory(_destDir);
            _tempDownDir = _destDir + DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture) + @"\";

            if (Directory.Exists(_tempDownDir))
                Directory.Delete(_tempDownDir, true);
            Directory.CreateDirectory(_tempDownDir);
        }

        private void UnpackCommandline()
        {
            string commandLine = "";
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                commandLine += arg;
            }
            if (commandLine.IndexOf('|') == -1)
            {
                _called = false;
                Close();
            }

            string[] args = commandLine.Split('|');
            for (int i = 1; i < args.GetLength(0); i++)
            {
                switch (args[i])
                {
                    case "ftpHost":
                        _ftpHost = args[i + 1];
                        break;
                    case "ftpAppDir":
                        _ftpAppDir = args[i + 1];
                        break;
                    case "ftpUser":
                        _ftpUser = args[i + 1];
                        break;
                    case "ftpPw":
                        _ftpPw = args[i + 1];
                        break;
                    case "version":
                        _version = args[i + 1];
                        break;
                    case "appProcess":
                        _appProcess = args[i + 1];
                        break;
                    case "destDir":
                        _destDir = args[i + 1];
                        break;
                    case "fullUpdate":
                        _fullUpdate = args[i + 1];
                        break;
                }
                i++;
            }
        }

        private void PostDownload()
        {
            var app = _destDir + _appProcess + ".exe";
            if (!File.Exists(app))
            {
                MessageBox.Show("Không tìm thấy file. \n" + app);
                return;
            }
            //Start the application after update
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = app
            };
            Process.Start(startInfo);

            string link = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar + "CHC.EMR.lnk";
            if (!File.Exists(link))
            {
                var shell = new IWshRuntimeLibrary.WshShell();
                var shortcut = shell.CreateShortcut(link) as IWshRuntimeLibrary.IWshShortcut;
                shortcut.TargetPath = app;
                shortcut.WorkingDirectory = _destDir;
                shortcut.Save();
            }
        }

        private void WrapUp()
        {
            if (Directory.Exists(_tempDownDir))
                Directory.Delete(_tempDownDir, true);

            var oldApp = _destDir + "BOSERP.exe";
            if (File.Exists(oldApp))
            {
                File.Delete(oldApp);
            }
            var oldUpdater = _destDir + "Updater.exe";
            if (File.Exists(oldUpdater))
            {
                File.Delete(oldUpdater);
            }
        }
        public bool Unzip(string file, string unZipTo)
        {
            try
            {
                // Specifying Console.Out here causes diagnostic msgs to be sent to the Console
                // In a WinForms or WPF or Web app, you could specify nothing, or an alternate
                // TextWriter to capture diagnostic messages. 

                using (ZipFile zip = ZipFile.Read(file))
                {
                    // This call to ExtractAll() assumes:
                    //   - none of the entries are password-protected.
                    //   - want to extract all entries to current working directory
                    //   - none of the files in the zip already exist in the directory;
                    //     if they do, the method will throw.
                    zip.ExtractAll(unZipTo);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra. \n" + ex.ToString());
                return false;
            }
        }

        public void MoveFiles(string from, string to, string excludeFile)
        {
            DirectoryInfo di = new DirectoryInfo(from);
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo fi in files)
            {
                if (fi.Name != excludeFile)
                {
                    ShowMsg("Đang copy tập tin: " + fi.Name);
                    File.Copy(from + fi.Name, to + fi.Name, true);
                    ReportProgress(1);
                }
            }
            foreach (var f in di.GetDirectories())
            {
                ShowMsg("Đang copy thư mục: " + f.Name);
                DirectoryInfo target = new DirectoryInfo(Path.Combine(to, f.Name));
                CopyAll(f, target);
                ReportProgress(1);
            }
        }
        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}