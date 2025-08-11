using System;
using System.Collections.Generic;
using System.Text;
using System.Data;




namespace BOSLib
{
    public class STModuleToolbarButtonsController:BaseBusinessController
    {

        #region Query Declaration
        
        //Select By ForeignKey Queries
        /*Remove cause of not use
        private readonly string spGetSTModuleToolbarButtonsBySTModuleToolbarID = "STModuleToolbarButtons_SelectBySTModuleToolbarID";*/

        private readonly string spGetSTModuleToolbarButtonsBySTModuleName =
                               "STModuleToolbarButtons_SelectBySTModuleName";
        private readonly string spGetSTModuleToolbarButtonsBySTModuleToolbarName =
                               "STModuleToolbarButtons_SelectBySTModuleToolbarName";
        private readonly string spGetSTModuleToolbarButtonsBySTModuleNameAndSTModuleToolbarName =
                                "STModuleToolbarButtons_SelectBySTModuleNameAndSTModuleToolbarName";
        private readonly string spGetSTModuleToolbarButtonsBySTModuleNameAndSTModuleToolbarNameAndSTModuleToolbarButtonTag =
                               "STModuleToolbarButtons_SelectBySTModuleNameAndSTModuleToolbarNameAndSTModuleToolbarButtonTag";
        private readonly string spGetSTModuleToolbarButtonsBySTModuleToolbarIDAndSTModuleToolbarButtonName =
                               "STModuleToolbarButtons_SelectBySTModuleToolbarIDAndSTModuleToolbarButtonName";

        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTModuleToolbarButtonsBySTModuleToolbarID = "STModuleToolbarButtons_DeleteBySTModuleToolbarID";*/

        #endregion

        public STModuleToolbarButtonsController()
        {
            //dal = new STModuleToolbarButtonsDAL();
            dal = new DALBaseProvider("STModuleToolbarButtons", typeof(STModuleToolbarButtonsInfo));
        }                
        
        
        public DataSet GetModuleToolbarButtonByModuleToolbarName(String strModuleToolbarName)
        {
            return (DataSet)dal.GetDataSet(spGetSTModuleToolbarButtonsBySTModuleToolbarName,
                                           strModuleToolbarName);            
        }

        public DataSet GetModuleToolbarButtonsByModuleNameAndModuleToolbarName(String strModuleName, String strModuleToolbarName)
        {
            return (DataSet)dal.GetDataSet(spGetSTModuleToolbarButtonsBySTModuleNameAndSTModuleToolbarName,
                                           strModuleName,strModuleToolbarName);            
        }

        public STModuleToolbarButtonsInfo GetModuleToolbarButtonByModuleNameAndModuleToolbarNameAndButtonTag(String strModuleName, String strModuleToolbarName, String strModuleToolbarButtonTag)
        {
            return (STModuleToolbarButtonsInfo)dal.GetDataObject(spGetSTModuleToolbarButtonsBySTModuleNameAndSTModuleToolbarNameAndSTModuleToolbarButtonTag,
                                                                 strModuleToolbarName, strModuleName, strModuleToolbarButtonTag);            
        }

        public String GetModuleToolbarButtonNameByModuleNameAndModuleToolbarNameAndButtonTag(String strModuleName, String strModuleToolbarName, String strModuleToolbarButtonTag)
        {
            String strModuleToolbarButtonName = "";
            STModuleToolbarButtonsInfo objSTModuleToolbarButtonsInfo = GetModuleToolbarButtonByModuleNameAndModuleToolbarNameAndButtonTag(strModuleName, strModuleToolbarName, strModuleToolbarButtonTag);
            if (objSTModuleToolbarButtonsInfo != null)
                strModuleToolbarButtonName = objSTModuleToolbarButtonsInfo.STModuleToolbarButtonName;

            return strModuleToolbarButtonName;
        }

        public STModuleToolbarButtonsInfo GetModuleToolbarButttonByModuleToolbarIDAndButtonName(int iModuleToolbarID, String strModuleToolbarButtonName)
        {
            return (STModuleToolbarButtonsInfo)dal.GetDataObject(spGetSTModuleToolbarButtonsBySTModuleToolbarIDAndSTModuleToolbarButtonName,
                                                                iModuleToolbarID, strModuleToolbarButtonName);            
        }

        public int GetModuleToolbarButtonIDByModuleToolbarIDAndButtonName(int iModuleToolbarID, String strModuleToolbarButtonName)
        {
            int iModuleToolbarButtonID = 0;
            STModuleToolbarButtonsInfo objSTModuleToolbarButtonsInfo = GetModuleToolbarButttonByModuleToolbarIDAndButtonName(iModuleToolbarID, strModuleToolbarButtonName);
            if (objSTModuleToolbarButtonsInfo != null)
                iModuleToolbarButtonID = objSTModuleToolbarButtonsInfo.STModuleToolbarButtonID;
            return iModuleToolbarButtonID;
        }

        public DataSet GetAllModuleToolbarButtonsByModuleName(String strModuleName)
        {
            return (DataSet)dal.GetDataSet(spGetSTModuleToolbarButtonsBySTModuleName,
                                           strModuleName);
        }        
    }
}
