using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region STGridLevelNodesController
    /// <summary>
    /// This object represents the properties and methods of a GridLevelNode.
    /// </summary>
    public class STGridLevelNodesController:BaseBusinessController
    {

        #region SP Name        
        //Select By ForeignKey Queries
        private readonly string spGetSTGridLevelNodesBySTFieldID = "STGridLevelNodes_SelectBySTFieldID";
        private readonly string spGetMaxSTLevelIndexBySTFieldID = "STGridLevelNodes_SelectMaxSTGridLevelNodeIndexBySTFieldID";
        private readonly string spGetSTGridLevelNodesBySTFieldIDAndSTGridLevelNodeIndex =
                               "STGridLevelNodes_SelectBySTFieldIDAndSTGridLevelNodeIndex";
        private readonly string spGetSTGridLevelNodeBySTFieldIDAndSTGridLevelNodeRelationNameAndSTGridLeveNodeIndex =
                               "STGridLevelNodes_SelectBySTFieldIDAndSTGridLevelNodeRelationNameAndSTGridLeveNodeIndex";


        //Delete by foreignkey Queries
        private readonly string spDeleteSTGridLevelNodesBySTFieldID = "STGridLevelNodes_DeleteBySTFieldID";

        #endregion

        public STGridLevelNodesController()
        {
            //dal = new STGridLevelNodesDAL();
            dal = new DALBaseProvider("STGridLevelNodes", typeof(STGridLevelNodesInfo));
        }                
        
        public DataSet GetGridLevelNodeByFieldID(int iFieldID)
        {            
            return (DataSet)dal.GetDataSet(spGetSTGridLevelNodesBySTFieldID,
                                           iFieldID);            
        }

        public int GetMaxLevelIndexByFieldID(int iFieldID)
        {
            int iMaxLevelIndex = 0;
            try
            {                
                DataSet ds = dal.GetDataSet(spGetMaxSTLevelIndexBySTFieldID,
                                          iFieldID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        iMaxLevelIndex = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    }
                }
            }
            catch (Exception)
            {
                iMaxLevelIndex = 0;
            }
            return iMaxLevelIndex;                     
        }

        public DataSet GetGridLevelNodeByFieldIDAndLevelIndex(int iFieldID, int iLevelIndex)
        {            
            return (DataSet)dal.GetDataSet(spGetSTGridLevelNodesBySTFieldIDAndSTGridLevelNodeIndex,
                                           iFieldID, iLevelIndex);           
        }

        public STGridLevelNodesInfo GetGridLevelNodeByFieldIDAndGridLevelNodeRelationNameAndLevelIndex(int iFieldID, String strGridLevelNodeRelationName, int iLevelIndex)
        {            
            return (STGridLevelNodesInfo)dal.GetDataObject(spGetSTGridLevelNodeBySTFieldIDAndSTGridLevelNodeRelationNameAndSTGridLeveNodeIndex,
                                                           iFieldID, strGridLevelNodeRelationName, iLevelIndex);
        }

        public void DeleteGridLevelNodeByFieldID(int iFieldID)
        {         
            dal.GetDataSet(spDeleteSTGridLevelNodesBySTFieldID,
                           iFieldID);            
        }
    }
    #endregion
}
