using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region ModuleFunctionParameterValueController
    /// <summary>
    /// This object represents the properties and methods of a ModuleFunctionParameterValue.
    /// </summary>
    public class STModuleFunctionParameterValuesController:BaseBusinessController
    {
        #region SP Name
        //Select By ForeignKey Queries

        /*Remove cause of not use
        private readonly string spGetSTModuleFunctionParameterValuesBySTUserGroupID = "STModuleFunctionParameterValues_SelectBySTUserGroupID";
        private readonly string spGetSTModuleFunctionParameterValuesBySTModuleFunctionParameterID = "STModuleFunctionParameterValues_SelectBySTModuleFunctionParameterID";*/

        //Select By all foreignkey query
        private readonly string spGetSTModuleFunctionParameterValuesBySTUserGroupIDAndSTModuleFunctionParameterID =
                               "STModuleFunctionParameterValues_SelectBySTUserGroupIDAndSTModuleFunctionParameterID";


        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTModuleFunctionParameterValuesBySTUserGroupID = "STModuleFunctionParameterValues_DeleteBySTUserGroupID";
        private readonly string spDeleteSTModuleFunctionParameterValuesBySTModuleFunctionParameterID = "STModuleFunctionParameterValues_DeleteBySTModuleFunctionParameterID";*/

        #endregion
        public STModuleFunctionParameterValuesController()
        {
            //dal = new STModuleFunctionParameterValuesDAL();
            dal = new DALBaseProvider("STModuleFunctionParameterValues", typeof(STModuleFunctionParameterValuesInfo));
        }              


        public STModuleFunctionParameterValuesInfo GetModuleFunctionParameterValueByModuleFunctionParameterIDAndUserGroupID(int iModuleFunctionParameterID, int iUserGroupID)
        { 
            return (STModuleFunctionParameterValuesInfo)dal.GetDataObject(spGetSTModuleFunctionParameterValuesBySTUserGroupIDAndSTModuleFunctionParameterID,
                                                                          iModuleFunctionParameterID, iUserGroupID);           
        }
    }
    #endregion
}
