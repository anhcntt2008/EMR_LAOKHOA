using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace BOSLib
{
    #region ADUserGroupsController

    public class ADUserGroupsController:BaseBusinessController
    {

        public ADUserGroupsController()
        {
            dal = new DALBaseProvider("ADUserGroups", typeof(ADUserGroupsInfo));
        }               

        public int GetMaxID()
        {
            String query = String.Format("select top 1 ADUserGroupID from ADUserGroups where AAStatus = 'Alive' order by ADUserGroupID desc");
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
    #endregion
}
