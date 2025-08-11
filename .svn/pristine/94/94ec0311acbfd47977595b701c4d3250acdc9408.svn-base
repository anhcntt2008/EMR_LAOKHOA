using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using Localization;

namespace BOSLib
{
    public class ReportHelper
    {
        protected static ConnectionInfo _reportConnection;
        protected static ReportDocument _reportDoc;

        public static String FileName
        {
            get
            {
                return _reportDoc.FileName;
            }
            set
            {
                _reportDoc.FileName = value;
            }
        }

        public static ReportDocument ReportDoc
        {
            get
            {
                return _reportDoc;
            }
            set
            {
                _reportDoc = value;
            }
        }

        static ReportHelper()
        {
            _reportDoc = new ReportDocument();            
            _reportConnection = new ConnectionInfo();
            //Auto connect database
            SetReportConnection();
        }

        private static void SetReportConnection()
        {
            RegistryWorker regW = new RegistryWorker();
            regW.SubKey = "SOFTWARE\\BOS";
            regW.SubKey = regW.SubKey + "\\ConnectionString";
            String strDatabase = regW.Read("Database");
            String strServer = regW.Read("Server");
            String strUser = regW.Read("User");
            string strPassword = regW.Read("Password");

            //If can get connection info from registry
            if (!String.IsNullOrEmpty(strServer))
            {
                Crypto cryp = new Crypto();
                strPassword = cryp.Decrypt(strPassword);

                //_reportConnection = new ConnectionInfo();
                _reportConnection.ServerName = strServer;
                _reportConnection.DatabaseName = strDatabase;
                _reportConnection.UserID = strUser;
                _reportConnection.Password = strPassword;
            }
            else
            {
                //Get from configuration file
                _reportConnection.ServerName = ConfigurationManager.AppSettings["ServerName"];
                _reportConnection.DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
                //[DDCan] [ADD] [21/05/2013] [Encrypt user id and password of database], START
                //_reportConnection.UserID = ConfigurationManager.AppSettings["UserID"];
                //_reportConnection.Password = ConfigurationManager.AppSettings["Password"];
                Crypto cryp = new Crypto();
                _reportConnection.UserID = cryp.DecryptNew(ConfigurationManager.AppSettings["UserID"], true);
                _reportConnection.Password = cryp.DecryptNew(ConfigurationManager.AppSettings["Password"], true);
                //[DDCan] [ADD] [21/05/2013] [Encrypt user id and password of database], END
            }
        }

        public static void ApplyReportLogon()
        {
            try
            {
                foreach (Table reportTable in ReportDoc.Database.Tables)
                {
                    TableLogOnInfo _tableLogonInfo = reportTable.LogOnInfo;
                    _tableLogonInfo.ConnectionInfo = _reportConnection;
                    reportTable.ApplyLogOnInfo(_tableLogonInfo);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(CommonLocalizedResources.CannotLogOnDatabaseMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void SetParamValues(Hashtable paramValues)
        {
            ApplyReportLogon();
            foreach (ParameterField paramField in ReportDoc.ParameterFields)
            {
                Object objValue = paramValues[paramField.Name];
                if (objValue != null)
                    ReportDoc.SetParameterValue(paramField.Name, paramValues[paramField.Name]);
            }
        }

        public static void DisplayReport(Hashtable paramValues)
        {
            SetParamValues(paramValues);
            guiBOSReportViewer _guiBOSReportViewer = new guiBOSReportViewer();
            _guiBOSReportViewer.BOSReportViewer.ReportSource = ReportDoc;
            _guiBOSReportViewer.Show();         
                    
        }
    }
}
