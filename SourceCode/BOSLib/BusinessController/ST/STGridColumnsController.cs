using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region STGridColumnsController
    /// <summary>
    /// This object represents the properties and methods of a GridColumn.
    /// </summary>
    public class STGridColumnsController:BaseBusinessController
    {

        #region SP Name
        
        //Select By ForeignKey Queries
        private readonly string spGetSTGridColumnsBySTGridViewID = "STGridColumns_SelectBySTGridViewID";
        private readonly string spGetSTGridColumnsBySTGridViewIDAndSTGridColumnName =
                               "STGridColumns_SelectBySTGridViewIDAndSTGridColumnName";
        private readonly string spGetSTGridColumnsBySTGridViewIDAndSTGridBandName = "STGridColumns_SelectBySTGridViewIDAndSTGridBandName";

        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTGridColumnsBySTGridViewID = "STGridColumns_DeleteBySTGridViewID";*/

        #endregion

        public STGridColumnsController()
        {
            //dal = new STGridColumnsDAL();
            dal = new DALBaseProvider("STGridColumns", typeof(STGridColumnsInfo));
        }        
        
        public DataSet GetGridColumnByGridViewID(int iGridViewID)
        {           
            return (DataSet)dal.GetDataSet(spGetSTGridColumnsBySTGridViewID,
                                           iGridViewID);            
        }

        public STGridColumnsInfo GetGridColumnByGridViewIDAndGridColumnName(int iGridViewID, String strGridColumnName)
        {         
            return (STGridColumnsInfo)dal.GetDataObject(spGetSTGridColumnsBySTGridViewIDAndSTGridColumnName,
                                                        iGridViewID, strGridColumnName);            
        }

        public DataSet GetGridColumnByGridViewIDAndGridBandName(int iGridViewId, String strGridBandName)
        {         
            return (DataSet)dal.GetDataSet(spGetSTGridColumnsBySTGridViewIDAndSTGridBandName,
                                           iGridViewId, strGridBandName);            
        }

    }
    #endregion
}
