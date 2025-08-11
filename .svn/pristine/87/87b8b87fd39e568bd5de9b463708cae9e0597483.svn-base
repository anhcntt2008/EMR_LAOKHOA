using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;


namespace BOSLib
{
    public class STModuleToUserGroupSectionsController : BaseBusinessController
    {
        #region SP Name

        //Select By ForeignKey Queries
        private readonly string spGetSTModuleToUserGroupSectionsBySTUserGroupSectionID =
                               "STModuleToUserGroupSections_SelectBySTUserGroupSectionID";

        /*Remove cause of not use
        private readonly string spGetSTModuleToUserGroupSectionsBySTModuleID = "STModuleToUserGroupSections_SelectBySTModuleID";*/


        //Select By all foreignkey query
        /*Remove cause of not use
        private readonly string spGetSTModuleToUserGroupSectionsBySTUserGroupSectionIDAndSTModuleID = "STModuleToUserGroupSections_SelectBySTUserGroupSectionIDAndSTModuleID";*/

        private readonly string spGetModulesBySTUserGroupID = "STModuleToUserGroupSections_SelectModulesBySTUserGroupID";

        private readonly string spGetSTModuleToUserGroupSectionsBySTUserGroupSectionIDAndSTModuleName =
                               "STModuleToUserGroupSections_SelectBySTUserGroupSectionIDAndSTModuleName";
        private static readonly string spGetMaxSTModuleToUserGroupSectionSortOrderBySTUserGroupSectionID =
                               "STModuleToUserGroupSections_SelectMaxSTModuleToUserGroupSectionSortOrderBySTUserGroupSectionID";

        //Delete by foreignkey Queries
        private readonly string spDeleteSTModuleToUserGroupSectionsBySTUserGroupSectionID = "STModuleToUserGroupSections_DeleteBySTUserGroupSectionID";

        /*Remove cause of not use
        private readonly string spDeleteSTModuleToUserGroupSectionsBySTModuleID = "STModuleToUserGroupSections_DeleteBySTModuleID";*/

        #endregion

        public STModuleToUserGroupSectionsController()
        {
            //dal = new STModuleToUserGroupSectionsDAL();
            dal = new DALBaseProvider("STModuleToUserGroupSections", typeof(STModuleToUserGroupSectionsInfo));
        }


        public DataSet GetAllModuleToUserGroupSectionByUserGroupSectionID(int iUserGroupSectionID)
        {
            return (DataSet)dal.GetDataSet("STModuleToUserGroupSections_GetAllModulesByUserGroupSectionID", iUserGroupSectionID);
        }


        public void DeleteAllModuleToUserGroupSectionByUserGroupSectionID(int iUserGroupSectionID)
        {
            dal.GetDataSet(spDeleteSTModuleToUserGroupSectionsBySTUserGroupSectionID, iUserGroupSectionID);
        }

        public DataSet GetSectionsAndModulesByUserGroupID(int iUserGroupID)
        {
            return (DataSet)dal.GetDataSet(spGetModulesBySTUserGroupID, iUserGroupID);
        }

        public STModuleToUserGroupSectionsInfo GetModuleToUserGroupSectionByUserGroupSectionIDAndModuleName(int iUserGroupSectionID, String strModuleName)
        {
            return (STModuleToUserGroupSectionsInfo)dal.GetDataObject(spGetSTModuleToUserGroupSectionsBySTUserGroupSectionIDAndSTModuleName, iUserGroupSectionID, strModuleName);
        }

        public int GetModuleToUserGroupSectionIDByUserGroupSectionIDAndModuleName(int iUserGroupSectionID, String strModuleName)
        {
            int iModuleToUserGroupSectionID = 0;
            STModuleToUserGroupSectionsInfo objSTModuleToUserGroupSectionsInfo = GetModuleToUserGroupSectionByUserGroupSectionIDAndModuleName(iUserGroupSectionID, strModuleName);
            if (objSTModuleToUserGroupSectionsInfo != null)
                iModuleToUserGroupSectionID = objSTModuleToUserGroupSectionsInfo.STModuleToUserGroupSectionID;
            return iModuleToUserGroupSectionID;
        }

        public bool IsExist(int iUserGroupSectionID, String strModuleName)
        {
            bool result = false;
            STModuleToUserGroupSectionsInfo objSTModuleToUserGroupSectionsInfo = GetModuleToUserGroupSectionByUserGroupSectionIDAndModuleName(iUserGroupSectionID, strModuleName);
            if (objSTModuleToUserGroupSectionsInfo != null)
                result = true;
            return result;
        }

        public int GetMaxSortOrderModuleToUserGroupByUserGroupSectionID(int iUserGroupSectionID)
        {
            int iMaxSortOrderModuleToUserGroup = 0;
            try
            {
                DataSet ds = dal.GetDataSet(spGetMaxSTModuleToUserGroupSectionSortOrderBySTUserGroupSectionID, iUserGroupSectionID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0] != null)
                        iMaxSortOrderModuleToUserGroup = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception)
            {
                iMaxSortOrderModuleToUserGroup = 0;
            }
            return iMaxSortOrderModuleToUserGroup;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iUserGroupSectionID"></param>
        /// <param name="strModuleName"></param>
        /// <returns></returns>
        public STModuleToUserGroupSectionsInfo GetModuleToUserGroupSectionByUserGroupSectionIDAndModuleID(int iUserGroupSectionID, int moduleID)
        {
            String query = String.Format("SELECT * FROM STModuleToUserGroupSections WHERE STUserGroupSectionID = {0} AND STModuleID = {1}", iUserGroupSectionID, moduleID);
            DataSet ds = GetDataSet(query);
            if (ds.Tables[0] == null && ds.Tables[0].Rows.Count == 0)
                return null;
            else
                return ((STModuleToUserGroupSectionsInfo)new STModuleToUserGroupSectionsController().GetObjectFromDataRow(ds.Tables[0].Rows[0]));
        }

        public STModuleToUserGroupSectionsInfo GetModuleToUserGroupSectionByModuleNameAndUserGroupID(String moduleName, int userGroupID)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT * FROM STModuleToUserGroupSections sm");
            queryBuilder.Append(BOSUtil.NewLine + "INNER JOIN STModules m ON sm.STModuleID = m.STModuleID");
            queryBuilder.Append(BOSUtil.NewLine + "INNER JOIN ADUserGroupSections ugs ON sm.STUserGroupSectionID = ugs.ADUserGroupSectionID");
            queryBuilder.Append(BOSUtil.NewLine + String.Format("WHERE m.AAStatus = 'Alive' AND ugs.AAStatus = 'Alive' AND m.STModuleName = '{0}' AND ugs.ADUserGroupID = {1}", moduleName, userGroupID));
            DataSet ds = GetDataSet(queryBuilder.ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return (STModuleToUserGroupSectionsInfo)GetObjectFromDataRow(ds.Tables[0].Rows[0]);
            return null;
        }

        public DataSet GetDisplayedModulesByUserGroupSectionID(int userGroupSectionID)
        {
            DataSet ds = dal.GetDataSet("STModuleToUserGroupSections_GetDisplayedModulesByUserGroupSectionID", userGroupSectionID);
            return ds;
        }

        public List<STModuleToUserGroupSectionsInfo> GetListModuleByUserGroup(int userGroupId)
        {
            var str = $@"SELECT
					*
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
					)";
            var ds = GetDataSet(str);
            var result = new List<STModuleToUserGroupSectionsInfo>();
            if (ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0) return result;
            result.AddRange(from DataRow dataRow in ds.Tables[0].Rows select (STModuleToUserGroupSectionsInfo) GetObjectFromDataRow(dataRow));
            return result;
        }
    }
}
