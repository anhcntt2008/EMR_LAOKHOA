using System.Configuration;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using BOSLib;

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
        
        public static void SwitchConnection(int iBranchID)
        {            
            SwitchConnection(iBranchID, false);
        }

        public static void SwitchConnectionNotCheckBranch(int iBranchID)
        {
            SwitchConnectionNotCheckBranch(iBranchID, false);
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

        public static void SwitchConnectionNotCheckBranch(int iBranchID, Boolean bDecrypt)
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
                    else
                        BOSApp.RollbackLocalConnection();
                }
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
    }
}