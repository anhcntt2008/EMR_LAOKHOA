using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region STGridViewsController
    /// <summary>
    /// This object represents the properties and methods of a GridView.
    /// </summary>
    public class STGridViewsController:BaseBusinessController
    {
        #region SP Name
        
        //Select By ForeignKey Queries
        private readonly string spGetSTGridViewsBySTFieldID = "STGridViews_SelectBySTFieldID";
        private readonly string spGetSTGridViewsBySTFieldIDAndSTGridViewName =
                               "STGridViews_SelectBySTFieldIDAndSTGridViewName";


        //Delete by foreignkey Queries
        private readonly string spDeleteSTGridViewsBySTFieldID = "STGridViews_DeleteBySTFieldID";

        #endregion

        public STGridViewsController()
        {
            //dal = new STGridViewsDAL();
            dal = new DALBaseProvider("STGridViews", typeof(STGridViewsInfo));
        }

        public DataSet GetGridViewByFieldID(int iFieldID)
        {

            return (DataSet)dal.GetDataSet(spGetSTGridViewsBySTFieldID, iFieldID);            
        }

        public STGridViewsInfo GetGridViewByFieldIDAndGridViewName(int iFieldID, String strGridViewName)
        {
            return (STGridViewsInfo)dal.GetDataObject(spGetSTGridViewsBySTFieldIDAndSTGridViewName,
                                                      iFieldID, strGridViewName);            
        }

        public void DeleteGridViewByFieldID(int iFieldID)
        {         
            dal.GetDataSet(spDeleteSTGridViewsBySTFieldID, iFieldID);            
        }
    }
    #endregion
}
