using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace BOSLib
{
    #region ADMatchCodesController

    public class ADMatchCodesController:BaseBusinessController
    {

        #region SP Name
        //Select By Name Query
        private readonly string spGetADMatchCodesByADMatchCodeColumnName = "ADMatchCodes_SelectByADMatchCodeColumnName";
        #endregion

        public ADMatchCodesController()
        {
            //dal = new ADMatchCodesDAL();
            dal = new DALBaseProvider("ADMatchCodes", typeof(ADMatchCodesInfo));
        }

       
        public DataSet GetADMatchCodesByADMatchCodeColumnName(String strADMatchCodeColumnName)
        {
            return (DataSet)dal.GetDataSet(spGetADMatchCodesByADMatchCodeColumnName,
                                           strADMatchCodeColumnName);
        }               
    }
    #endregion
}
