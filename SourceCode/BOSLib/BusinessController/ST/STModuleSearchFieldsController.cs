using System;
using System.Collections.Generic;
using System.Text;
using System.Data;




namespace BOSLib
{
    public class STModuleSearchFieldsController:BaseBusinessController
    {

        #region Query Declaration
        
        //Select By ForeignKey Queries
        private readonly string spGetSTModuleSearchFieldsBySTModuleStatusID = "STModuleSearchFields_SelectBySTModuleStatusID";
        private readonly string spGetSTModuleSearchFieldsBySTModuleNameAndADUserName =
                                "STModuleSearchFields_SelectBySTModuleNameAndADUserName";
        private readonly string spGetSTModuleSearchFieldsBySTModuleNameAndADUserNameAndSTModuleSearchFieldName =
                                "STModuleSearchFields_SelectSTModuleNameAndADUserNameAndSTModuleSearchFieldName";
        private readonly string spGetSTModuleSearchFieldsBySTModuleStatusIDAndSTModuleSearchFieldName =
                                "STModuleSearchFields_SelectBySTModuleStatusIDAndSTModuleSearchFieldName";

        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTModuleSearchFieldsBySTModuleStatusID = "STModuleSearchFields_DeleteBySTModuleStatusID";*/

        #endregion

        public STModuleSearchFieldsController()
        {
            //dal = new STModuleSearchFieldsDAL();
            dal = new DALBaseProvider("STModuleSearchFields", typeof(STModuleSearchFieldsInfo));
        }

        
        public STModuleSearchFieldsInfo GetModuleSearchFieldByModuleStatusIDAndFieldName(int iModuleStatusID, String strFieldName)
        {
            return (STModuleSearchFieldsInfo)dal.GetDataObject(spGetSTModuleSearchFieldsBySTModuleStatusIDAndSTModuleSearchFieldName,
                                                               iModuleStatusID, strFieldName);            
        }

        public STModuleSearchFieldsInfo GetModuleSearchFieldByModuleNameAndUserNameAndFieldName(String strModuleName, String strUserName, String strFieldName)
        {
            return (STModuleSearchFieldsInfo)dal.GetDataObject(spGetSTModuleSearchFieldsBySTModuleNameAndADUserNameAndSTModuleSearchFieldName,
                                                               strModuleName, strUserName, strFieldName);            
        }

        public DataSet GetAllModuleSearchFieldsByModuleStatusID(int iModuleStatusID)
        {
            return (DataSet)dal.GetDataSet(spGetSTModuleSearchFieldsBySTModuleStatusID,
                                           iModuleStatusID);           
        }

        public DataSet GetAllModuleSearchFieldsByModuleNameAndUserName(String strModuleName, String strUserName)
        {
            return (DataSet)dal.GetDataSet(spGetSTModuleSearchFieldsBySTModuleNameAndADUserName,
                                           strModuleName, strUserName);            
        }

        
        public bool IsExist(int iModuleStatusID, String strFieldName)
        {
            bool isExist = false;
            STModuleSearchFieldsInfo objSTModuleSearchFieldsInfo = GetModuleSearchFieldByModuleStatusIDAndFieldName(iModuleStatusID, strFieldName);
            if (objSTModuleSearchFieldsInfo != null)
                isExist = true;
            return isExist;
        }

        public bool IsExist(String strModuleName, String strUserName, String strFieldName)
        {
            bool isExist = false;
            STModuleSearchFieldsInfo objSTModuleSearchFieldsInfo = GetModuleSearchFieldByModuleNameAndUserNameAndFieldName(strModuleName, strUserName, strFieldName);
            if (objSTModuleSearchFieldsInfo != null)
                isExist = true;
            return isExist;
        }
    }
}
