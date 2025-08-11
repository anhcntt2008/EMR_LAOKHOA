using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region STModuleFunctionsController
    /// <summary>
    /// This object represents the properties and methods of a ModuleFunction.
    /// </summary>
    public class STModuleFunctionsController:BaseBusinessController
    {
        #region SP Name
        
        //Select By ForeignKey Queries
        private readonly string spGetSTModuleFunctionsBySTModuleID = "STModuleFunctions_SelectBySTModuleID";
        private readonly string spGetSTModuleFunctionsBySTModuleIDAndSTModuleFunctionFullNameAndSTModuleFunctionClass =
                                "STModuleFunctions_SelectBySTModuleIDAndSTModuleFunctionFullNameAndSTModuleFunctionClass";

        //Delete by foreignkey Queries
        private readonly string spDeleteSTModuleFunctionsBySTModuleID = "STModuleFunctions_DeleteBySTModuleID";

        #endregion

        public STModuleFunctionsController()
        {
            //dal = new STModuleFunctionsDAL();
            dal = new DALBaseProvider("STModuleFunctions", typeof(STModuleFunctionsInfo));
        }
        
        public DataSet GetModuleFunctionByModuleID(int iModuleID)
        {
            return (DataSet)dal.GetDataSet(spGetSTModuleFunctionsBySTModuleID, iModuleID);            
        }

        public void DeleteModuleFunctionByModuleID(int iModuleID)
        {
            dal.GetDataSet(spDeleteSTModuleFunctionsBySTModuleID, iModuleID);            
        }

        public STModuleFunctionsInfo GetModuleFunctionByModuleIDAndModuleFunctionFullNameAndModuleFunctionClass(int iModuleID, String strModuleFunctionFullName, String strModuleFunctionClass)
        {
            return (STModuleFunctionsInfo)dal.GetDataObject(spGetSTModuleFunctionsBySTModuleIDAndSTModuleFunctionFullNameAndSTModuleFunctionClass,
                                                            iModuleID, strModuleFunctionFullName, strModuleFunctionClass);            
        }
        public bool IsExistFunctionInModule(int iSTModuleID, String strSTModuleFunctionFullName, String strSTModuleFunctionClass)
        {
            STModuleFunctionsInfo objSTModuleFunctionsInfo = GetModuleFunctionByModuleIDAndModuleFunctionFullNameAndModuleFunctionClass(iSTModuleID, strSTModuleFunctionFullName, strSTModuleFunctionClass);
            if (objSTModuleFunctionsInfo != null)
                return true;
            return false;
        }
    }
    #endregion
}
