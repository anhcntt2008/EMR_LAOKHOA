using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace BOSLib
{
    public class ADUserGroupSectionsController:BaseBusinessController
    {
        #region SP Name
        
        //Select By ForeignKey Stored Procedure
        private readonly string spGetADUserGroupSectionsByADUserGroupID = "ADUserGroupSections_SelectByADUserGroupID";
        private readonly string spGetADUserGroupSectionBySectionNameAndUserGroupID = "ADUserGroupSections_SelectByADUserGroupSectionNameAndADUserGroupID";
        private readonly string spGetMaxADUserGroupSortOrderSectionByADUserGroupID = "ADUserGroupSections_SelectMaxADUserGroupSortOrderSectionByADUserGroupID";

        //Delete by foreignkey Stored Procedure
        /*Remove cause of not use
        private readonly string spDeleteADUserGroupSectionsByADUserGroupID = "ADUserGroupSections_DeleteByADUserGroupID";*/

        #endregion

        public ADUserGroupSectionsController()
        {
            //dal = new ADUserGroupSectionsDAL();
            dal = new DALBaseProvider("ADUserGroupSections", typeof(ADUserGroupSectionsInfo));
        }

        public DataSet GetUserGroupSectionByUserGroupID(int iUserGroupID)
        {
            String query = String.Format("SELECT * FROM ADUserGroupSections WHERE [AAStatus] = 'Alive' AND ADUserGroupID = {0} ORDER BY ADUserGroupSectionSortOrder", iUserGroupID);
            return GetDataSet(query);
        }            
     
        public ADUserGroupSectionsInfo GetUserGroupSectionBySectionNameAndUserGroupID(String strADUserGroupSectionName, int iUserGroupID)
        {
            return (ADUserGroupSectionsInfo)dal.GetDataObject(spGetADUserGroupSectionBySectionNameAndUserGroupID, iUserGroupID, strADUserGroupSectionName);            
        }

        public int GetUserGroupSectionIDBySectionNameAndUserGroupID(String strADUserGroupSectionName, int iUserGroupID)
        {
            int iUserGroupSectionID = 0;
            ADUserGroupSectionsInfo objADUserGroupSectionsInfo = new ADUserGroupSectionsInfo();
            objADUserGroupSectionsInfo = GetUserGroupSectionBySectionNameAndUserGroupID(strADUserGroupSectionName, iUserGroupID);
            if (objADUserGroupSectionsInfo != null)
                iUserGroupSectionID = objADUserGroupSectionsInfo.ADUserGroupSectionID;
            return iUserGroupSectionID;
        }

        public bool IsExist(String strADUserGroupSectionName, int iUserGroupID)
        {
            bool result = false;
            ADUserGroupSectionsInfo objADUserGroupSectionsInfo = GetUserGroupSectionBySectionNameAndUserGroupID(strADUserGroupSectionName, iUserGroupID);
            if (objADUserGroupSectionsInfo != null)
                result = true;
            return result;
        }

        public int GetMaxSortOrderSectionByUserGroupID(int iUserGroupID)
        {
            int iMaxSortOrderSection = 0;
            try
            {
                DataSet ds = dal.GetDataSet(spGetMaxADUserGroupSortOrderSectionByADUserGroupID, iUserGroupID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0] != null)
                        iMaxSortOrderSection = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception)
            {
                iMaxSortOrderSection = 0;
            }            
            return iMaxSortOrderSection;
        }
        public int GetMaxID()
        {
            String query = String.Format("select top 1 ADUserGroupSectionID from ADUserGroupSections where AAStatus = 'Alive' order by ADUserGroupSectionID desc");
            int iMaxID = 0;
            DataSet ds = dal.GetDataSet(query);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0] != null)
                    iMaxID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return iMaxID;
        }

    }
}
