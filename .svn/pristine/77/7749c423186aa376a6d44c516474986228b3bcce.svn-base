using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;


namespace BOSLib
{
    #region STModuleDescriptionsController
    /// <summary>
    /// This object represents the properties and methods of a ModuleDescription.
    /// </summary>
    public class STModuleDescriptionsController : BaseBusinessController
    {
        #region SP Name

        //Select By ForeignKey Queries
        /*Remove cause of not use
        private readonly string spGetSTModuleDescriptionsBySTLanguageID = "STModuleDescriptions_SelectBySTLanguageID";
        private readonly string spGetSTModuleDescriptionsBySTModuleID = "STModuleDescriptions_SelectBySTModuleID";*/

        //Select By all foreignkey query

        /*Remove cause of not use
        private readonly string spGetSTModuleDescriptionsBySTModuleIDAndSTLanguageID = "STModuleDescriptions_SelectBySTModuleIDAndSTLanguageID";*/

        private readonly string spGetSTModuleDescriptionsBySTModuleNameAndGELanguageName =
                                "STModuleDescriptions_SelectBySTModuleNameAndGELanguageName";

        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTModuleDescriptionsBySTLanguageID = "STModuleDescriptions_DeleteBySTLanguageID";
        private readonly string spDeleteSTModuleDescriptionsBySTModuleID = "STModuleDescriptions_DeleteBySTModuleID";*/

        #endregion

        public STModuleDescriptionsController()
        {
            //dal = new STModuleDescriptionsDAL();
            dal = new DALBaseProvider("STModuleDescriptions", typeof(STModuleDescriptionsInfo));
        }


        public STModuleDescriptionsInfo GetModuleDescriptionByModuleNameAndLanguageName(String strModuleName, String strLanguageName)
        {
            return (STModuleDescriptionsInfo)dal.GetDataObject(spGetSTModuleDescriptionsBySTModuleNameAndGELanguageName,
                                                               strModuleName, strLanguageName);
        }

        public String GetDescriptionByModuleNameAndLanguageName(String strModuleName, String strLanguageName)
        {
            String strModuleDescription = String.Empty;
            STModuleDescriptionsInfo objSTModuleDescriptionsInfo = GetModuleDescriptionByModuleNameAndLanguageName(strModuleName, strLanguageName);
            if (objSTModuleDescriptionsInfo != null)
                strModuleDescription = objSTModuleDescriptionsInfo.STModuleDescriptionDescription;
            return strModuleDescription;
        }

        public STModuleDescriptionsInfo GetModuleDescriptionByDescriptionAndLanguageName(String description, String languageName)
        {
            return (STModuleDescriptionsInfo)dal.GetDataObject("STModuleDescriptions_GetModuleDescriptionByDescriptionAndLanguageName",
                                                              description, languageName);
        }

        public List<STModuleDescriptionsInfo> GetModuleDescriptionsInfosByUserGroupId(int userGroupId, string language)
        {
            var query = $@"SELECT
	*
FROM
	STModuleDescriptions
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
	)
AND STLanguageID = (
	SELECT
		GELanguageID
	FROM
		GELanguages
	WHERE
		GELanguageName = '{language}'
)";
            var ds = GetDataSet(query);
            var result = new List<STModuleDescriptionsInfo>();
            if (ds == null || ds.Tables[0].Rows.Count == 0) return result;
            result.AddRange(from DataRow dataRow in ds.Tables[0].Rows select (STModuleDescriptionsInfo) GetObjectFromDataRow(dataRow));
            return result;
        }
    }
    #endregion

}
