using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region STScreensController
    /// <summary>
    /// This object represents the properties and methods of a Screen.
    /// </summary>
    public class STScreensController:BaseBusinessController
    {
        #region SP Name
        //Select By ForeignKey Queries
        /*Remove cause of not use
        private readonly string spGetSTScreensBySTUserGroupID = "STScreens_SelectBySTUserGroupID";
        private readonly string spGetSTScreensBySTModuleID = "STScreens_SelectBySTModuleID";*/

        //Select By all foreignkey query
        private readonly string spGetSTScreensBySTUserGroupIDAndSTModuleID =
                               "STScreens_SelectBySTUserGroupIDAndSTModuleID";
        private readonly string spGetSTScreensBySTModuleNameAndADUserGroupName =
                               "STScreens_SelectBySTModuleNameAndADUserGroupName";
        private readonly string spGetSTScreensBySTModuleName =
                               "STScreens_SelectBySTModuleName";
        private readonly string spGetSTScreensBySTModuleIDAndSTUserGroupIDAndSTScreenName =
                               "STScreens_SelectBySTModuleIDAndSTUserGroupIDAndSTScreenName";        

        private readonly string spGetSTScreensBySTModuleIDAndSTUserGroupIDAndSTScreenNumber=
                                "STScreens_SelectBySTModuleIDAndSTUserGroupIDAndSTScreenNumber";                
        private readonly string spDeleteSTScreensBySTModuleIDAndSTUserGroupID =
                                "STScreens_DeleteBySTModuleIDAndSTUserGroupID";

        #endregion
        public STScreensController()
        {
            dal = new DALBaseProvider("STScreens", typeof(STScreensInfo));
        }
        
        
        public DataSet GetScreenByUserGroupIDAndModuleID(int iUserGroupID, int iModuleID)
        {
            return (DataSet)dal.GetDataSet(spGetSTScreensBySTUserGroupIDAndSTModuleID,iModuleID,iUserGroupID);            
        }

        public DataSet GetScreenByModuleName(String strModuleName)
        {
            return (DataSet)dal.GetDataSet(spGetSTScreensBySTModuleName, strModuleName);            
        }

        public DataSet GetScreenByModuleNameAndUserGroupID(String strModuleName, int userGroupID)
        {
            return dal.GetDataSet("STScreens_GetScreensByModuleNameAndUserGroupID", strModuleName, userGroupID);
        }

        public STScreensInfo GetScreenByModuleIDAndUserGroupIDAndScreenName(int iModuleID, int iUserGroupID, String strScreenName)
        {
            return (STScreensInfo)dal.GetDataObject(spGetSTScreensBySTModuleIDAndSTUserGroupIDAndSTScreenName,iModuleID,iUserGroupID,strScreenName);
        }

        public STScreensInfo GetSTScreensByModuleIDAndUserGroupIDAndScreenNumber(int iModuleID, int iUserGroupID, String strScreenNumber)
        {
            return (STScreensInfo)dal.GetDataObject(spGetSTScreensBySTModuleIDAndSTUserGroupIDAndSTScreenNumber,
                                                    iModuleID, iUserGroupID, strScreenNumber);

        }

        public int GetScreenIDByModuleIDAndUserGroupIDAndScreenName(int iModuleID, int iUserGroupID, String strScreenName)
        {
            int iScreenID = 0;
            STScreensInfo objSTScreensInfo = GetScreenByModuleIDAndUserGroupIDAndScreenName(iModuleID, iUserGroupID, strScreenName);
            if (objSTScreensInfo != null)
                iScreenID = objSTScreensInfo.STScreenID;
            return iScreenID;
        }
       
        public void DeleteScreensBySTModuleIDAndSTUserGroupID(int iSTModuleID, int iSTUserGroupID)
        {
            dal.GetDataSet(spDeleteSTScreensBySTModuleIDAndSTUserGroupID, iSTModuleID, iSTUserGroupID);
        }      
    }
    #endregion
}
