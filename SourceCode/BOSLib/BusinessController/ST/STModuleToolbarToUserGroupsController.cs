using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region ModuleToolbarToUserGroupController
    /// <summary>
    /// This object represents the properties and methods of a ModuleToolbarToUserGroup.
    /// </summary>
    public class STModuleToolbarToUserGroupsController:BaseBusinessController
    {
        #region SP Name
        //Select By ForeignKey Queries

        /*Remove cause of not use
        private readonly string spGetSTModuleToolbarToUserGroupsBySTUserGroupID = "STModuleToolbarToUserGroups_SelectBySTUserGroupID";
        private readonly string spGetSTModuleToolbarToUserGroupsBySTModuleToolbarID = "STModuleToolbarToUserGroups_SelectBySTModuleToolbarID";*/

        //Select By all foreignkey query
        private readonly string spGetSTModuleToolbarToUserGroupsBySTUserGroupIDAndSTModuleToolbarID = "STModuleToolbarToUserGroups_SelectBySTUserGroupIDAndSTModuleToolbarID";


        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTModuleToolbarToUserGroupsBySTUserGroupID = "STModuleToolbarToUserGroups_DeleteBySTUserGroupID";
        private readonly string spDeleteSTModuleToolbarToUserGroupsBySTModuleToolbarID = "STModuleToolbarToUserGroups_DeleteBySTModuleToolbarID";*/

        #endregion

        public STModuleToolbarToUserGroupsController()
        {
            //dal = new STModuleToolbarToUserGroupsDAL();
            dal = new DALBaseProvider("STModuleToolbarToUserGroups", typeof(STModuleToolbarToUserGroupsInfo));
        }       
        
        public STModuleToolbarToUserGroupsInfo GetModuleToolbarToUserGroupByModuleToolbarIDAndUserGroupID(int iModuleToolbarID, int iUserGroupID)
        {
            return (STModuleToolbarToUserGroupsInfo)dal.GetDataObject(spGetSTModuleToolbarToUserGroupsBySTUserGroupIDAndSTModuleToolbarID,
                                                                      iModuleToolbarID, iUserGroupID);           
        }
    }
    #endregion
}
