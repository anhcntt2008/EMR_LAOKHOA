using System;
using System.Collections.Generic;
using System.Text;
using System.Data;




namespace BOSLib
{
    public class STModuleToolbarsController:BaseBusinessController
    {
        #region SP Name
        
        //Select By ForeignKey Queries
        /*Remove cause of not use
        private readonly string spGetSTModuleToolbarsBySTModuleID = "STModuleToolbars_SelectBySTModuleID";*/

        private readonly string spGetSTModuleToolbarsBySTModuleName =
                               "STModuleToolbars_SelectBySTModuleName";
        private readonly string spGetSTModuleToolbarsByNameAndSTModuleName = "STModuleToolbars_SelectByNameAndSTModuleName";


        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTModuleToolbarsBySTModuleID = "STModuleToolbars_DeleteBySTModuleID";*/

        #endregion

        public STModuleToolbarsController()
        {
            //dal = new STModuleToolbarsDAL();
            dal = new DALBaseProvider("STModuleToolbars", typeof(STModuleToolbarsInfo));
        }               

        
        public DataSet GetModuleToolbarByModuleName(String strModuleName)
        {            
            return (DataSet)dal.GetDataSet(spGetSTModuleToolbarsBySTModuleName, strModuleName);            
        }

        public STModuleToolbarsInfo GetModuleToolbarByNameAndModuleName(String strModuleToolbarName, String strModuleName)
        {
            return (STModuleToolbarsInfo)dal.GetDataObject(spGetSTModuleToolbarsByNameAndSTModuleName,
                                                           strModuleToolbarName, strModuleName);            
        }

        public int GetModuleToolbarIDByNameAndModuleName(String strModuleToolbarName, String strModuleName)
        {
            int iModuleToolbarID = 0;
            STModuleToolbarsInfo objSTModuleToolbarsInfo = GetModuleToolbarByNameAndModuleName(strModuleToolbarName, strModuleName);
            if (objSTModuleToolbarsInfo != null)
            {
                iModuleToolbarID = objSTModuleToolbarsInfo.STModuleToolbarID;
            }
            return iModuleToolbarID;
        }

        public bool IsExist(String strModuleName, String strModuleToolbarName)
        {
            bool result = false;
            STModuleToolbarsInfo objSTModuleToolbarsInfo = GetModuleToolbarByNameAndModuleName(strModuleToolbarName, strModuleName);
            if (objSTModuleToolbarsInfo != null)
                result = true;
            return result;
        }
    }
}
