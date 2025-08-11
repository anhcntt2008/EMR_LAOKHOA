using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region STModuleFunctionParametersController
    /// <summary>
    /// This object represents the properties and methods of a ModuleFunctionParameter.
    /// </summary>
    public class STModuleFunctionParametersController:BaseBusinessController
    {

        #region Query Declaration        
        //Select By ForeignKey Queries

        
        private readonly string spGetSTModuleFunctionParametersBySTModuleFunctionID = "STModuleFunctionParameters_SelectBySTModuleFunctionID";

        private readonly string spGetSTModuleFunctionParametersBySTModuleFunctionIDAndSTModuleFunctionParameterName =
                                "STModuleFunctionParameters_SelectBySTModuleFunctionIDAndSTModuleFunctionParameterName";

        //Delete by foreignkey Queries
        //private readonly string spDeleteSTModuleFunctionParametersBySTModuleFunctionID = "STModuleFunctionParameters_DeleteBySTModuleFunctionID";

        #endregion
        public STModuleFunctionParametersController()
        {
            //dal = new STModuleFunctionParametersDAL();
            dal = new DALBaseProvider("STModuleFunctionParameters", typeof(STModuleFunctionParametersInfo));
        }               

        public DataSet GetModuleFunctionParameterByModuleFunctionID(int iModuleFunctionID)
        {
            return (DataSet)dal.GetDataSet(spGetSTModuleFunctionParametersBySTModuleFunctionID,
                                           iModuleFunctionID);            
        }

        public STModuleFunctionParametersInfo GetModuleFunctionParameterByModuleFunctionIDAndModuleFunctionParameterName(int iModuleFunctionID, String strModuleFunctionParameterName)
        {
            return (STModuleFunctionParametersInfo)dal.GetDataObject(spGetSTModuleFunctionParametersBySTModuleFunctionIDAndSTModuleFunctionParameterName,
                                                                     iModuleFunctionID, strModuleFunctionParameterName);           
        }        
    }
    #endregion
}
