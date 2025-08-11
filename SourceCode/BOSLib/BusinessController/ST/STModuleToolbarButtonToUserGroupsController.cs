using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region ModuleToolbarButtonToUserGroupController
    /// <summary>
    /// This object represents the properties and methods of a ModuleToolbarButtonToUserGroup.
    /// </summary>
    public class STModuleToolbarButtonToUserGroupsController:BaseBusinessController
    {

        #region SP Name
        //Select By ForeignKey Queries

        /*Remove cause of not use
        private readonly string spGetSTModuleToolbarButtonToUserGroupsBySTUserGroupID = "STModuleToolbarButtonToUserGroups_SelectBySTUserGroupID";
        private readonly string spGetSTModuleToolbarButtonToUserGroupsBySTModuleToolbarButtonID = "STModuleToolbarButtonToUserGroups_SelectBySTModuleToolbarButtonID";*/
        //Select By all foreignkey query
        private readonly string spGetSTModuleToolbarButtonToUserGroupsBySTUserGroupIDAndSTModuleToolbarButtonID =
                               "STModuleToolbarButtonToUserGroups_SelectBySTUserGroupIDAndSTModuleToolbarButtonID";



        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTModuleToolbarButtonToUserGroupsBySTUserGroupID = "STModuleToolbarButtonToUserGroups_DeleteBySTUserGroupID";
        private readonly string spDeleteSTModuleToolbarButtonToUserGroupsBySTModuleToolbarButtonID = "STModuleToolbarButtonToUserGroups_DeleteBySTModuleToolbarButtonID";*/

        #endregion

        public STModuleToolbarButtonToUserGroupsController()
        {
            //dal = new STModuleToolbarButtonToUserGroupsDAL();
            dal = new DALBaseProvider("STModuleToolbarButtonToUserGroups", typeof(STModuleToolbarButtonToUserGroupsInfo));
        }

        
        public STModuleToolbarButtonToUserGroupsInfo GetModuleToolbarButtonToUserGroupByModuleToolbarButtonIDAndUserGroupID(int iModuleToolbarButtonID, int iUserGroupID)
        {
            return (STModuleToolbarButtonToUserGroupsInfo)dal.GetDataObject(spGetSTModuleToolbarButtonToUserGroupsBySTUserGroupIDAndSTModuleToolbarButtonID,
                                                                            iModuleToolbarButtonID, iUserGroupID);           
        }
    }
    #endregion
}
