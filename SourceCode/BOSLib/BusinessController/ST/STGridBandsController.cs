using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region GridBandController
    /// <summary>
    /// This object represents the properties and methods of a GridBand.
    /// </summary>
    public class STGridBandsController:BaseBusinessController
    {
        #region SP Name
        
        //Select By ForeignKey Queries
        private readonly string spGetSTGridBandsBySTGridViewID = "STGridBands_SelectBySTGridViewID";
        private readonly string spGetSTGridBandsBySTGridViewIDAndSTGridBandName = "STGridBands_SelectBySTGridViewIDAndSTGridBandName";

        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTGridBandsBySTGridViewID = "STGridBands_DeleteBySTGridViewID";*/

        #endregion

        public STGridBandsController()
        {
            //dal = new STGridBandsDAL();
            dal = new DALBaseProvider("STGridBands", typeof(STGridBandsInfo));
        }       
        
        public DataSet GetGridBandByGridViewID(int iGridViewID)
        {            
            return (DataSet)dal.GetDataSet(spGetSTGridBandsBySTGridViewID, iGridViewID);            
        }

        public STGridBandsInfo GetGridBandByGridViewIDAndGridBandName(int iGridViewID, String strGridBandName)
        {         
            return (STGridBandsInfo)dal.GetDataObject(spGetSTGridBandsBySTGridViewIDAndSTGridBandName, iGridViewID, strGridBandName);
        }
    }
    #endregion
}
