using System;
using System.Collections.Generic;
using System.Text;
using System.Data;




namespace BOSLib
{
    public class STModuleStatusController:BaseBusinessController
    {

        #region SP Name

        //Select By ForeignKey Queries
        /*Remove cause of not use
        private readonly string spGetSTModuleStatusBySTModuleID = "STModuleStatus_SelectBySTModuleID";        
        private readonly string spGetSTModuleStatusBySTUserID = "STModuleStatus_SelectBySTUserID";*/

        //Select By all foreignkey query
        private readonly string spGetSTModuleStatusBySTModuleIDAndSTUserID =
                               "STModuleStatus_SelectBySTUserIDAndSTModuleID";
        private readonly string spGetSTModuleStatusBySTModuleNameAndSTUserName =
                                "STModuleStatus_SelectBySTModuleNameAndADUserName";

        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTModuleStatusBySTModuleID = "STModuleStatus_DeleteBySTModuleID";
        private readonly string spDeleteSTModuleStatusBySTUserID = "STModuleStatus_DeleteBySTUserID";*/

        #endregion

        public STModuleStatusController()
        {
            //dal = new STModuleStatusDAL();
            dal = new DALBaseProvider("STModuleStatus", typeof(STModuleStatusInfo));
        }

        
        public STModuleStatusInfo GetModuleStatusByModuleIDAndUserID(int iModuleID, int iUserID)
        {
            return (STModuleStatusInfo)dal.GetDataObject(spGetSTModuleStatusBySTModuleIDAndSTUserID, iModuleID, iUserID);            
        }

        public STModuleStatusInfo GetModuleStatusByModuleNameAndUserName(String strModuleName, String strUserName)
        {
            return (STModuleStatusInfo)dal.GetDataObject(spGetSTModuleStatusBySTModuleNameAndSTUserName, strModuleName, strUserName);            
        }
        

        public bool IsExist(int iModuleID, int iUserID)
        {
            bool result = false;
            STModuleStatusInfo objSTModuleStatusInfo = GetModuleStatusByModuleIDAndUserID(iModuleID, iUserID);
            if (objSTModuleStatusInfo != null)
                result = true;
            return result;
        }

        public bool IsExist(String strModuleName, String strUserName)
        {
            bool result = false;
            STModuleStatusInfo objSTModuleStatusInfo = GetModuleStatusByModuleNameAndUserName(strModuleName, strUserName);
            if (objSTModuleStatusInfo != null)
                result = true;
            return result;
        }

        public bool IsOpened(String strModuleName, String strUserName)
        {
            bool isOpened = false;
            STModuleStatusInfo objSTModuleStatusInfo = GetModuleStatusByModuleNameAndUserName(strModuleName, strUserName);
            if (objSTModuleStatusInfo != null)
            {
                if (objSTModuleStatusInfo.STModuleStatusStatus == "Open")
                    isOpened = true;
            }
            return isOpened;
        }

        public bool IsHibernate(String strModuleName, String strUserName)
        {
            bool isHide = false;
            STModuleStatusInfo objSTModuleStatusInfo = GetModuleStatusByModuleNameAndUserName(strModuleName, strUserName);
            if (objSTModuleStatusInfo != null)
            {
                if (objSTModuleStatusInfo.STModuleStatusStatus == "Hibernate")
                    isHide = true;
            }
            return isHide;
        }

        public bool IsClose(String strModuleName, String strUserName)
        {
            bool isClosed = false;
            STModuleStatusInfo objSTModuleStatusInfo = GetModuleStatusByModuleNameAndUserName(strModuleName, strUserName);
            if (objSTModuleStatusInfo != null)
            {
                if (objSTModuleStatusInfo.STModuleStatusStatus == "Close")
                    isClosed = true;
            }
            else
                isClosed = true;

            return isClosed;
        }

        public bool IsHide(String strModuleName, String strUserName)
        {
            bool isHide = false;
            STModuleStatusInfo objSTModuleStatusInfo = GetModuleStatusByModuleNameAndUserName(strModuleName, strUserName);
            if (objSTModuleStatusInfo != null)
            {
                if (objSTModuleStatusInfo.STModuleStatusStatus == "Hide")
                    isHide = true;
            }
            else
                isHide = true;

            return isHide;
        }
    }
}
