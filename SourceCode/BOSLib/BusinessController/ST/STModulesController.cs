using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BOSLib
{
    public class STModulesController:BaseBusinessController
    {

        public STModulesController()
        {
            //dal = new STModulesDAL();
            dal = new DALBaseProvider("STModules", typeof(STModulesInfo));
        }              

        public bool IsMainModule(String strModuleName)
        {
            bool isMainModule=true;
            STModulesInfo objSTModulesInfo = (STModulesInfo)GetObjectByName(strModuleName);
            if (objSTModulesInfo != null)
            {
                if (objSTModulesInfo.STModuleMain == 0)
                    isMainModule = false;
            }            
            return isMainModule;
        }

        /// <summary>
        /// Get all modules
        /// </summary>
        /// <returns>List of all modules</returns>
        public DataSet GetAllModules()
        {
            DataSet ds = dal.GetDataSet("STModules_GetAllModules");
            return ds;
        }

        public List<STModulesInfo> GetListModuleByUserGroup(int userGroupId)
        {
            var query = $@"SELECT
	*
FROM
	STModules
WHERE
	STModuleID IN (
		SELECT
			STModuleID
		FROM
			STModuleToUserGroupSections
		WHERE
			STUserGroupSectionID IN (
				SELECT
					ADUserGroupSectionID
				FROM
					ADUserGroupSections
				WHERE
					ADUserGroupID = {userGroupId}
			)
	)";
            var ds = GetDataSet(query);
            var result = new List<STModulesInfo>();
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return result;
            result.AddRange(from DataRow dataRow in ds.Tables[0].Rows select (STModulesInfo) GetObjectFromDataRow(dataRow));
            return result;
        }

        public STModulesInfo GetSTModulesByName(string moduleName)
        {
            return (STModulesInfo)dal.GetDataObject("STModules_SelectByName", moduleName);
        }
    }
}
