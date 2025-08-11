using System;
using System.IO;
using System.Threading;

using System.Collections.Generic;
using System.Text;
using System.Xml;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.ServiceProcess;

namespace SetupScripts
{
    /// <summary>
    /// UtHV
    /// 06022017
    /// </summary>
    class SetupDataBase
    {
        #region Private variables
        private string m_dbName = string.Empty;
        private string m_backUpFilePath = string.Empty;

        private string m_appConfigFileName = string.Empty;

        private string m_appPath = string.Empty;
        internal string m_datFilePath = string.Empty;

        private FrmLog m_log = null;
        private string _masterConnString;
        internal string _templatePath;
        internal string _ftpServerName;
        internal string _ftpRootPath;
        internal string _ftpUser;
        internal string _ftpPassword;
        #endregion

        #region Public methods
        public void SetPermissionOnDataFolder(string path, FrmLog log)
        {
            log.WriteLine("Set permission for SQL server service access to " + path);
            DirectoryInfo info = new DirectoryInfo(path);
            DirectorySecurity security = info.GetAccessControl();
            try
            {
                //SQL EXPRESS
                security.AddAccessRule(new FileSystemAccessRule(@"NT SERVICE\MSSQL$SQLEXPRESS", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
                security.AddAccessRule(new FileSystemAccessRule(@"NT SERVICE\MSSQL$SQLEXPRESS", FileSystemRights.FullControl, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));

                info.SetAccessControl(security);
            }
            catch (Exception ex)
            {

                log.WriteLine(ex.Message);
            }

            try
            {
                security = info.GetAccessControl();
                //SQL SERVER
                security.AddAccessRule(new FileSystemAccessRule(@"NT SERVICE\MSSQLSERVER", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
                security.AddAccessRule(new FileSystemAccessRule(@"NT SERVICE\MSSQLSERVER", FileSystemRights.FullControl, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));

                info.SetAccessControl(security);
            }
            catch (Exception ex)
            {

                log.WriteLine(ex.Message);
            }
        }

        public void Execute(FrmLog log)
        {
            m_log = log;

            SqlCommand cmd = null;
            SqlConnection conn = null;
            try
            {
                // Set SQL service permission to copy data to app install folder
                SetPermissionOnDataFolder(m_datFilePath, log);

                // user input nothing
                // case install sql express auto
                if (String.IsNullOrEmpty(_serverName) || string.IsNullOrEmpty(_userID))
                {
                    EncryptEngine encrypt = new EncryptEngine();
                    _userID = "sa";
                    _userIDEncrypt = encrypt.Encrypt(_userID, true);
                    _password = GenPassword();//"abc@123";
                    _passwordEncrypt = encrypt.Encrypt(_password, true);
                    _serverName = @".\SQLEXPRESS";

                    if (!EnableSaUser())
                    {
                        throw new ApplicationException("Sa user can't be enabled. Can't connect to SQLEXPRESS instance on you local server.");
                    }
                    if (!RestartSQLService())
                    {
                        throw new ApplicationException("SQL EXPRESS Service can't be restart. Can't connect to SQLEXPRESS instance on you local server.");
                    }
                }

                //case point to existing sql instance
                if (!string.IsNullOrEmpty(_dbName) && !string.IsNullOrEmpty(_serverName) && !string.IsNullOrEmpty(_userID))
                {
                    //
                    log.WriteLine("Connecting to db: " + _dbName);
                    if (!CheckConnectionToExistingDB()) throw new ApplicationException("Can't connect to " + _dbName + " on server " + _serverName);
                }
                else
                {
                    _dbName = "clas_his_" + DateTime.Now.ToString("ddMMyyyy_hhmm");
                    log.WriteLine("Auto generate db name: " + _dbName);

                    this._masterConnString = string.Format(@"Data Source={0};Initial Catalog=master;User ID={1};Password={2};", _serverName, _userID, _password);
                    log.WriteLine("Connection string to server created");
                    log.WriteLine("Connection string to master is: " + _masterConnString);
                    conn = new SqlConnection(_masterConnString);

                    // Show data lib path
                    log.WriteLine("Db directory after intalling: " + m_datFilePath);

                    GetDataFileName();

                    string query = string.Format(@"RESTORE DATABASE [{0}] FILE = N'{4}' 
                                                FROM  DISK = N'{2}{1}.bak'
                                                WITH  FILE = 1,
                                                MOVE N'{4}' TO N'{3}{0}.mdf',
                                                MOVE N'{5}' TO N'{3}{0}.ldf'",
                                                   m_dbName,
                                                   m_backUpFilePath,
                                                   m_appPath,
                                                   m_datFilePath,
                                                   this._dataFileName,
                                                   this._logFileName
                                                   );

                    log.WriteLine("Following query will be runned on SQL server:");
                    log.WriteLine(query);

                    // Create SQL query 
                    cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.Text;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    log.WriteLine("Database schema is created");

                }

                // IF USE FTP SERVER CLEAR TEMPLATE FOLDER
                if (!String.IsNullOrEmpty(_ftpServerName))
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(m_appPath + "\\Templates\\Template");
                    log.WriteLine("Use Ftp >> Clear template local folder");
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }

                    di = new DirectoryInfo(m_appPath + "\\Templates\\VisitTemplate");
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }
                //update config file
                UpdateConfig();

            }
            //catch (Exception ex)
            //{
            //    log.WriteLine(ex.ToString());
            //}
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (conn != null) conn.Dispose();
            }
        }
        /// <summary>
        /// auto gen pw sa truong hop cai tu dong
        /// </summary>
        /// <returns></returns>
        private string GenPassword()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        private bool CheckConnectionToExistingDB()
        {
            string connString = string.Format(@"Server={0};Database={1};User ID={2};Password={3};",
                _serverName, m_dbName, _userID, _password);
            m_log.WriteLine("Connection string :" + connString);
            SqlConnection conn = new SqlConnection(connString);
            string query = "SELECT * FROM dbo.STModules";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                m_log.WriteLine("Connect successfully");
                return true;
            }
            return false;
        }

        private void GetDataFileName()
        {
            SqlConnection conn = new SqlConnection(this._masterConnString);
            string query = string.Format("RESTORE FILELISTONLY FROM DISK = N'{0}{1}.bak'", m_appPath, m_backUpFilePath);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Type"].ToString() == "D")
                {
                    this._dataFileName = dr["LogicalName"].ToString();
                    m_log.WriteLine("Data file name :" + this._dataFileName);
                }
                if (dr["Type"].ToString() == "L")
                {

                    this._logFileName = dr["LogicalName"].ToString();
                    m_log.WriteLine("Log file name :" + this._logFileName);
                }

            }

        }
        #endregion

        #region Private methods

        public void UpdateConfig()
        {

            string connString = string.Format(@"Server={0};Database ={1};User ID ={2};Password ={3};Trusted_Connection =False;Encrypt =True;Connection Timeout=30;",
                _serverName, m_dbName, _userIDEncrypt, _passwordEncrypt);
            m_log.WriteLine("Encrypted connection string: " + connString);

            // Create config file to create 
            string fileName = string.Format(@"{0}{1}", AppPath, AppConfigFileName);

            // Updating connection string in file 
            m_log.WriteLine("Updating connection string in file: " + fileName);

            XmlDocument xmlDom = new XmlDocument();
            xmlDom.Load(fileName);

            // Get XML node 
            XmlNode xmlNode = xmlDom.SelectSingleNode(
                "configuration/connectionStrings/add[@name='BOSDataAccess']");
            if (xmlNode != null)
            {
                xmlNode.Attributes["connectionString"].Value = connString;

                // Updating connection string in file 
                m_log.WriteLine("Followin node of config file will be updated: configuration/connectionStrings/add[@name='BOSDataAccess']");
            }

            // Get XML node 
            xmlNode = xmlDom.SelectSingleNode(
                "configuration/appSettings/add[@key='ConnectionString']");
            if (xmlNode != null)
            {
                xmlNode.Attributes["value"].Value = connString;

                // Updating connection string in file 
                m_log.WriteLine("Followin node of config file will be updated: configuration/appSettings/add[@key='ConnectionString']");
            }

            // Get XML node 
            xmlNode = xmlDom.SelectSingleNode(
                "configuration/appSettings/add[@key='ServerName']");
            if (xmlNode != null)
            {
                xmlNode.Attributes["value"].Value = _serverName;

                // Updating connection string in file 
                m_log.WriteLine("Following node of config file will be updated: configuration/appSettings/add[@key='ServerName']");
            }

            // Get XML node 
            xmlNode = xmlDom.SelectSingleNode(
                "configuration/appSettings/add[@key='DatabaseName']");
            if (xmlNode != null)
            {
                xmlNode.Attributes["value"].Value = m_dbName;

                // Updating connection string in file 
                m_log.WriteLine("Following node of config file will be updated: configuration/appSettings/add[@key='DatabaseName']");
            }

            // Get XML node 
            xmlNode = xmlDom.SelectSingleNode(
                "configuration/appSettings/add[@key='UserID']");
            if (xmlNode != null)
            {
                xmlNode.Attributes["value"].Value = _userIDEncrypt;

                // Updating connection string in file 
                m_log.WriteLine("Following node of config file will be updated: configuration/appSettings/add[@key='UserID']");
            }

            // Get XML node 
            xmlNode = xmlDom.SelectSingleNode(
                "configuration/appSettings/add[@key='Password']");
            if (xmlNode != null)
            {
                xmlNode.Attributes["value"].Value = _passwordEncrypt;

                // Updating connection string in file 
                m_log.WriteLine("Followin node of config file will be updated: configuration/appSettings/add[@key='Password']");
            }

            if (!String.IsNullOrEmpty(_templatePath))
            {
                // Get XML node 
                xmlNode = xmlDom.SelectSingleNode(
                    "configuration/appSettings/add[@key='TemplateServerPath']");
                if (xmlNode != null)
                {
                    xmlNode.Attributes["value"].Value = _templatePath;

                    // Updating connection string in file 
                    m_log.WriteLine("Followin node of config file will be updated: configuration/appSettings/add[@key='TemplateServerPath']");
                }
            }

            // FTP SERVER
            if (!String.IsNullOrEmpty(_ftpServerName))
            {
                // Get XML node 
                xmlNode = xmlDom.SelectSingleNode("configuration/appSettings/add[@key='ftp_host']");
                if (xmlNode != null)
                {
                    xmlNode.Attributes["value"].Value = _ftpServerName;

                    // Updating connection string in file 
                    m_log.WriteLine("Followin node of config file will be updated: configuration/appSettings/add[@key='ftp_host']");
                }
                // Get XML node 
                xmlNode = xmlDom.SelectSingleNode("configuration/appSettings/add[@key='ftp_root_path']");
                if (xmlNode != null)
                {
                    xmlNode.Attributes["value"].Value = _ftpRootPath;

                    // Updating connection string in file 
                    m_log.WriteLine("Followin node of config file will be updated: configuration/appSettings/add[@key='ftp_root_path']");
                }
                // Get XML node 
                xmlNode = xmlDom.SelectSingleNode("configuration/appSettings/add[@key='ftp_user']");
                if (xmlNode != null)
                {
                    xmlNode.Attributes["value"].Value = _ftpUser;

                    // Updating connection string in file 
                    m_log.WriteLine("Followin node of config file will be updated: configuration/appSettings/add[@key='ftp_user']");
                }
                // Get XML node 
                xmlNode = xmlDom.SelectSingleNode("configuration/appSettings/add[@key='ftp_password']");
                if (xmlNode != null)
                {
                    xmlNode.Attributes["value"].Value = _ftpPassword;

                    // Updating connection string in file 
                    m_log.WriteLine("Followin node of config file will be updated: configuration/appSettings/add[@key='ftp_password']");
                }
            }

            // Save to disk
            xmlDom.Save(fileName);
        }

        /// <summary>
        /// Create conn string to local database 
        /// </summary>
        /// <returns></returns>
        // private string GetConnStringToLocalServer()
        // {

        /*
        SqlDataSourceEnumerator sqlEnum = SqlDataSourceEnumerator.Instance;
        DataTable table = sqlEnum.GetDataSources();

        // Get local machine name 
        string machineName = Environment.MachineName;

        foreach (DataRow row in table.Rows)
        {
            if (row[0].ToString() == machineName)
            {
                string connString = string.Format(
                    "Persist Security Info=False;Integrated Security=SSPI;Initial Catalog=master;Data Source={0}",
                    machineName);
                return connString;
            }

        }

        throw new ApplicationException("No local sql Server is installed");
        */
        //  }

        /// <summary>
        /// Case auto install SQL EXPRESS
        /// </summary>
        /// <returns></returns>
        private bool RestartSQLService()
        {
            ServiceController controller = new ServiceController();

            try
            {
                controller.MachineName = ".";
                controller.ServiceName = "MSSQL$SQLEXPRESS";

                // Stop the service
                controller.Stop();
                controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMinutes(1));
                m_log.WriteLine("MSSQL$SQLEXPRESS Stopped");

                // Start the service

                controller.Start();
                controller.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMinutes(2));
                m_log.WriteLine("MSSQL$SQLEXPRESS Runing");
                return true;

            }
            catch (Exception ex)
            {
                m_log.WriteLine(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Case auto install SQL EXPRESS
        /// </summary>
        /// <returns></returns>
        private bool EnableSaUser()
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            try
            {
                // Create connection string to datbase
                string connString = @"Data Source=" + _serverName + ";Initial Catalog=master;Integrated Security=SSPI;";
                m_log.WriteLine("Windows authentication connection string " + connString);
                conn = new SqlConnection(connString);

                string query = @"EXEC xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'LoginMode', REG_DWORD, 2";
                string query2 = "alter login " + _userID + " enable";
                string query3 = "alter login sa with password = '" + _password + "'";

                m_log.WriteLine("Following query will be runned on SQL server:");
                m_log.WriteLine(query + "\n" + query2 + "\n" + query3);

                // Create SQL query 
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;

                conn.Open();
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                cmd = new SqlCommand(query2, conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                cmd = new SqlCommand(query3, conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                m_log.WriteLine("SA user is enabled");

            }
            catch (Exception ex)
            {
                m_log.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (conn != null) conn.Dispose();
            }
            return true;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// 
        /// </summary>
        public string _dbName
        {
            get { return m_dbName; }
            set { m_dbName = value; }
        }

        /// <summary>
        /// Back 
        /// </summary>
        public string BackUpFilePath
        {
            get { return m_backUpFilePath; }
            set { m_backUpFilePath = value; }
        }

        /// <summary>
        /// Set application file 
        /// </summary>
        public string AppConfigFileName
        {
            get { return m_appConfigFileName; }
            set { m_appConfigFileName = value; }
        }

        public string AppPath
        {
            get { return m_appPath; }
            set { m_appPath = value; }
        }

        public string _serverName { get; internal set; }
        public string _userID { get; internal set; }
        public string _password { get; internal set; }
        public string _userIDEncrypt { get; internal set; }
        public string _passwordEncrypt { get; internal set; }
        public string _dataFileName { get; private set; }
        public string _logFileName { get; private set; }
        #endregion
    }
}
