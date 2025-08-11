using System.Configuration;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using BOSLib;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using System.Linq;
using System.Data.Common;

namespace BOSERP
{
    partial class BOSApp
    {
		public static String GetMainObjectNo(String strModuleName, string mainTableName, ref int numberingStart)
        {
            String strMainObjectNo = String.Empty;
            String currentYear = DateTime.Now.ToString("yy");
            GENumberingController objGENumberingController = new GENumberingController();
            GENumberingInfo objGENumberingInfo = (GENumberingInfo)new GENumberingController().GetObjectByName(strModuleName);
            if (objGENumberingInfo != null)
            {                
                BaseBusinessController objMainObjectController = BusinessControllerFactory.GetBusinessController(mainTableName + "Controller");
                if (objMainObjectController != null)
                {
                    strMainObjectNo = String.Format("{0}{1}-{2}", objGENumberingInfo.GENumberingPrefix, currentYear, objGENumberingInfo.GENumberingStart);
                    numberingStart = objGENumberingInfo.GENumberingStart;
                    while (objMainObjectController.IsExist(strMainObjectNo))
                    {
                        objGENumberingInfo.GENumberingStart++;
                        strMainObjectNo = String.Format("{0}{1}-{2}", objGENumberingInfo.GENumberingPrefix, currentYear, objGENumberingInfo.GENumberingStart);
                        numberingStart = objGENumberingInfo.GENumberingStart;
                    }
                }
            }
            return strMainObjectNo;
        }

        public static void UpdateObjectNumbering(String strModuleName, int numberingStart)
        {
            GENumberingController objGENumberingController = new GENumberingController();
            GENumberingInfo objGENumberingInfo = (GENumberingInfo)objGENumberingController.GetObjectByName(strModuleName);
            if (objGENumberingInfo != null)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                objGENumberingInfo.GENumberingStart = numberingStart + 1;
                objGENumberingController.UpdateObject(objGENumberingInfo);
            }
        }
        
        public static String GetMainObjectNo(String strModuleName)
        {         
            String strMainObjectNo = String.Empty;
            GENumberingController objGENumberingController = new GENumberingController();
            
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], START
            //GENumberingInfo objGENumberingInfo = (GENumberingInfo)new GENumberingController().GetObjectByName(strModuleName);
            GENumberingInfo objGENumberingInfo;
            List<GENumberingInfo> nuberingList = objGENumberingController.GetNumberingListByName(strModuleName);
            if (nuberingList.Count == 1)
            {
                objGENumberingInfo = nuberingList[0];
            }
            else
            {
                objGENumberingInfo = nuberingList.Where(i => i.FK_BRBranchID == BOSApp.CurrentCompanyInfo?.FK_BRBranchID).FirstOrDefault();
            }
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], END

            if (objGENumberingInfo != null)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                DateTime currentDate = dbUtil.GetCurrentServerDate();
                strMainObjectNo = String.Format("{0}{1}.{2}",
                                                        objGENumberingInfo.GENumberingPrefix,
                                                        currentDate.Year.ToString().Substring(2, 2),
                                                        objGENumberingInfo.GENumberingStart.ToString().PadLeft(objGENumberingInfo.GENumberingLength, '0'));
            }
            
            return strMainObjectNo;
        }

        public static void UpdateObjectNumbering(String strModuleName)
        {
            GENumberingController objGENumberingController = new GENumberingController();

            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], START
            //GENumberingInfo objGENumberingInfo = (GENumberingInfo)objGENumberingController.GetObjectByName(strModuleName);
            GENumberingInfo objGENumberingInfo;
            List<GENumberingInfo> nuberingList = objGENumberingController.GetNumberingListByName(strModuleName);
            if (nuberingList.Count == 1)
            {
                objGENumberingInfo = nuberingList[0];
            }
            else
            {
                objGENumberingInfo = nuberingList.Where(i => i.FK_BRBranchID == BOSApp.CurrentCompanyInfo.FK_BRBranchID).FirstOrDefault();
            }
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], END


            if (objGENumberingInfo != null)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                objGENumberingInfo.GENumberingStart++;
                objGENumberingController.UpdateObject(objGENumberingInfo);
            }
        }
        

        #region Database connection
        public static void SwitchConnection(int iBranchID)
        {            
            SwitchConnection(iBranchID, false);
        }       

        public static void SwitchConnection(int iBranchID, Boolean bDecrypt)
        {
            BRBranchsController branchController = new BRBranchsController();
            BRBranchsInfo objCurrentBranchsInfo = (BRBranchsInfo)branchController.GetObjectByID(iBranchID);

            if (objCurrentBranchsInfo != null)
            {
                if (BOSApp.CurrentCompanyInfo != null)
                {
                    if (objCurrentBranchsInfo.BRBranchID != CurrentCompanyInfo.FK_BRBranchID)
                    {
                        String strDatabase = objCurrentBranchsInfo.BRBranchDatabase;
                        String strServer = objCurrentBranchsInfo.BRBranchServerName;
                        String strUser = objCurrentBranchsInfo.BRBranchDatabaseUser;
                        string strPassword = objCurrentBranchsInfo.BRBranchDatabasePassword;

                        if (bDecrypt)
                        {
                            Crypto cryp = new Crypto();
                            strPassword = cryp.Decrypt(strPassword);
                        }

                        String strBranchConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", strServer, strDatabase, strUser, strPassword);
                        SqlDatabaseHelper.SwitchConnection(strBranchConnectionString);
                    }
                }                
            }        
        }
        public static void SwitchConnectionAnotherServer(int iserverID)
        {
            MELabServersController objLabServersController = new MELabServersController();
            MELabServersInfo objLabServersInfo = (MELabServersInfo)objLabServersController.GetObjectByID(iserverID);
            if (objLabServersInfo != null)
            {
                String strDatabase = objLabServersInfo.MELabServerDB;
                String strServer = objLabServersInfo.MELabServerIP;
                String strUser = objLabServersInfo.MELabServerDBUserName;
                string strPassword = objLabServersInfo.MELabServerDBPass;
                 
                 String strBranchConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", strServer, strDatabase, strUser, strPassword);
                 SqlDatabaseHelper.SwitchConnection(strBranchConnectionString);
                
            }
        }
        public static SqlDatabase CreateConnectionToAnotherServer(int iserverID)
        {
            MELabServersController objLabServersController = new MELabServersController();
            MELabServersInfo objLabServersInfo = (MELabServersInfo)objLabServersController.GetObjectByID(iserverID);
            if (objLabServersInfo != null)
            {
                String strDatabase = objLabServersInfo.MELabServerDB;
                String strServer = objLabServersInfo.MELabServerIP;
                String strUser = objLabServersInfo.MELabServerDBUserName;
                string strPassword = objLabServersInfo.MELabServerDBPass;

                string connectionstring = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", strServer, strDatabase, strUser, strPassword);
                return SqlDatabaseHelper.CreateConnection(connectionstring);
            }
            return null;
        }
   
        //public static void SwitchConnection(String strConnectionString)
        //{
        //    database = CreateConnectionToAnotherServer(iserverID);      
        //}
  

        public static bool TestConnection(SqlDatabase database)
        {
            try
            {
                String strTestQuery = "Select * From [MELabOrders]";
                DbCommand cmd = database.GetSqlStringCommand(strTestQuery);
                //cmd = database.GetStoredProcCommand("sp_HIS_InsertPatient");

                database.ExecuteDataSet(cmd);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool LabServerInsertPatient(SqlDatabase database,string sID, string STT, DateTime LAbDate, string PatientName, int YearOfBirth, string Gender)
        {
            try
            {
                DbCommand cmd = database.GetStoredProcCommand("sp_HIS_InsertPatient", sID, STT, LAbDate, PatientName, YearOfBirth, Gender);
                database.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool LabServerInsertOrder(SqlDatabase database, string sID, string LabNo, string LabName)
        {
            try
            {
                DbCommand cmd = database.GetStoredProcCommand("sp_HIS_InsertOrder", sID, LabNo, LabName);
                database.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static void RollbackLocalConnection()
        {
            SqlDatabaseHelper.RollbackToLocalConnection();
        }

        public static bool TestCurrentConnection()
        {
            return SqlDatabaseHelper.TestConnection();
        }

        /// <summary>
        /// Test a connection whether it's available
        /// </summary>
        /// <param name="database">Database object contains the connection</param>
        /// <returns>True if the connection is available, otherwise false</returns>
        public static bool TestConnection(Database database)
        {
            return SqlDatabaseHelper.TestConnection((SqlDatabase)database);
        }

        /// <summary>
        /// Create a connection to a branch, seperate from the current connection
        /// </summary>
        /// <param name="branchID">Branch id</param>
        /// <returns>Database object contains the connection</returns>
        public static SqlDatabase CreateConnectionToBranch(int branchID)
        {
            BRBranchsController objBranchController = new BRBranchsController();
            BRBranchsInfo objBranchsInfo = (BRBranchsInfo)objBranchController.GetObjectByID(branchID);
            if (objBranchsInfo != null)
            {
                string strDatabase = objBranchsInfo.BRBranchDatabase;
                string strServer = objBranchsInfo.BRBranchServerName;
                string strUser = objBranchsInfo.BRBranchDatabaseUser;
                string strPassword = objBranchsInfo.BRBranchDatabasePassword;

                string connectionstring = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", strServer, strDatabase, strUser, strPassword);
                return SqlDatabaseHelper.CreateConnection(connectionstring);
            }
            return null;
        }
        #endregion

        /// <summary>
        /// Get the displayed text of a value stored in a table by id or values from system configuration
        /// </summary>
        /// <param name="tableName">Table name contains the value</param>
        /// <param name="columnName">Column name contains the value</param>
        /// <returns>Displayed text</returns>
        public static string GetDisplayedTextByValue(string tableName, string columnName, object value)
        {
            string displayedText = string.Empty;
            BOSDbUtil dbUtil = new BOSDbUtil();
            if (dbUtil.IsForeignKey(tableName, columnName))
            {                
                string primaryTableName = dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(tableName, columnName);
                string primaryKey = dbUtil.GetTablePrimaryColumn(primaryTableName);
                string displayedColumn = String.Format("{0}{1}", primaryKey.Substring(0, primaryKey.Length - 2), "Name");
                BaseBusinessController controller = BusinessControllerFactory.GetBusinessController(primaryTableName + "Controller");
                if (controller != null)
                {
                    object obj = controller.GetObjectByID(Convert.ToInt32(value));
                    if (obj != null)
                    {
                        displayedText = dbUtil.GetPropertyValue(obj, displayedColumn).ToString();
                    }
                }
            }
            else
            {
                string configKeyGroup = string.Empty;
                if (columnName.EndsWith("Combo"))
                {
                    configKeyGroup = columnName.Substring(2, columnName.Length - 7);
                }
                else if (columnName.Length > 2)
                {
                    configKeyGroup = columnName.Substring(2, columnName.Length - 2);
                }
                if (!String.IsNullOrEmpty(configKeyGroup) && ADConfigValueUtility.ConfigValues.Tables[configKeyGroup] != null)
                {
                    displayedText = ADConfigValueUtility.GetConfigTextByGroupAndValue(configKeyGroup, Convert.ToString(value));
                }
                else
                {
                    displayedText = value.ToString();
                }
            }
            return displayedText;
        }

        /// <summary>
        /// Convert from timestamp to DateTime
        /// </summary>
        /// <param name="unixTimeStamp">Value of timestamp</param>
        /// <param name="addTime">Add time need convert to GTM</param>
        /// <returns></returns>
        public static DateTime? UnixTimeStampToDateTime(long? unixTimeStamp, double addTime = 0)
        {
            if (unixTimeStamp == null)
                return null;
            try
            {
                double seconds = unixTimeStamp.Value;
                var localTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var rs = localTime.AddMilliseconds(seconds).AddHours(addTime);
                if(rs<new DateTime(1753,1,1) ||  rs > new DateTime(9999,12,31))
                {
                    return null;
                }
                return rs;
            }
            catch
            {
                return DateTime.Now.Date;
            }
        }

        public static long ConvertToTimestamp(DateTime value, double addTime = 0)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var diff = (long)(value.AddHours(-addTime) - origin).TotalMilliseconds;
            return diff;
        }
        public static long ConvertToUnixTimestamp(DateTime value, double addTime = 0)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var diff = (long)(value.AddHours(-addTime) - origin).TotalSeconds;
            return diff;
        }
        public static double GetTimeZone()
        {
            TimeZone zone = TimeZone.CurrentTimeZone;
            // Get offset.
            TimeSpan offset = zone.GetUtcOffset(DateTime.Now);
            return offset.TotalHours;
        }
    }
}