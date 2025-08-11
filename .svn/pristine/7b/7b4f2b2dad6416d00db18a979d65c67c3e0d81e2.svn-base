using System;
using System.Threading;

using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace SetupScripts
{
    [RunInstaller(true)]
    public partial class InstallerCmd : Installer
    {
        public InstallerCmd()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            //var str = "";
            //foreach (var item in Context.Parameters.Keys)
            //{
            //    str += ";" + item.ToString() + "-" + this.Context.Parameters[item.ToString()];
            //}
            //MessageBox.Show(str);

            //return;

            FrmLog log = null;
            try
            {

                base.Install(stateSaver);
                string AppPath = Context.Parameters["assemblypath"];
                AppPath = AppPath.Substring(0, AppPath.LastIndexOf(@"\") + 1);

                log = new FrmLog(AppPath);
                log.Show();
                SetupDataBase db = new SetupDataBase();
                EncryptEngine encrypt = new EncryptEngine();
                // Application file
                db.AppPath = AppPath; //@"C:\Program Files (x86)\Bys.Clas\iHis\";// Context.Parameters["AppPath"];
                log.WriteLine("AppPath: " + db.AppPath);


                db._serverName = Context.Parameters["servername"];
                db._serverName = db._serverName.Replace("\\\\", "\\");
                log.WriteLine("Server Name: " + db._serverName);
                db._userID = Context.Parameters["userid"];
                db._userIDEncrypt = encrypt.Encrypt(db._userID,true);
                log.WriteLine("UserID : " + db._userID);

                db._password = Context.Parameters["password"];
                db._passwordEncrypt = encrypt.Encrypt(db._password, true);

                // Database name 
                db._dbName = Context.Parameters["dbname"]; 
                log.WriteLine("Database name: " + db._dbName);

                db._templatePath = Context.Parameters["template"];
                db._templatePath = db._templatePath.Replace("\\\\", "\\");
                log.WriteLine("Template path: " + db._templatePath);

                db._ftpServerName = Context.Parameters["ftpserver"];
                log.WriteLine("FTP Server Name: " + db._ftpServerName);

                db._ftpRootPath = Context.Parameters["ftproot"];
                log.WriteLine("FTP Folder Path: " + db._ftpRootPath);

                db._ftpUser = Context.Parameters["ftpuser"];
                log.WriteLine("FTP User: " + db._ftpUser);

                db._ftpPassword = Context.Parameters["ftppassword"];
                log.WriteLine("FTP Password: " + db._ftpPassword);

                // Backup file
                db.BackUpFilePath = "db";
                log.WriteLine("Backup file: " + db.BackUpFilePath);

                // Application file
                db.AppConfigFileName = "EMR.exe.config";
                log.WriteLine("Config file: " + db.AppConfigFileName);

                db.m_datFilePath = AppPath;
                log.WriteLine("DATFile: " + db.m_datFilePath);

                db.Execute(log);
            }
            catch (Exception e)
            {
                log.WriteLine("Data base init failed:");
                log.WriteLine(e.ToString());

                throw new ApplicationException(
                    "Database init fault: \n" + e.ToString());
            }
            finally
            {
                Thread.Sleep(60 * 1000);

                log.Close();
                log.Release();
            }
        }
    }
}