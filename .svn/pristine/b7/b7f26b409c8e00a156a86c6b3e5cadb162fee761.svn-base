using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region STFieldEventParametersController
    /// <summary>
    /// This object represents the properties and methods of a FieldEventParameter.
    /// </summary>
    public class STFieldEventParametersController:BaseBusinessController
    {
        #region SP Name
        
        //Select By ForeignKey Queries
        public readonly string spGetSTFieldEventParametersBySTFieldEventID = "STFieldEventParameters_SelectBySTFieldEventID";
        public readonly string spGetSTFieldEventParametersBySTFieldEventIDAndSTFieldEventParameterName =
                               "STFieldEventParameters_SelectBySTFieldEventIDAndSTFieldEventParameterName";

        //Delete by foreignkey Queries
        public readonly string spDeleteSTFieldEventParametersBySTFieldEventID = "STFieldEventParameters_DeleteBySTFieldEventID";

        #endregion

        public STFieldEventParametersController()
        {
            //dal = new STFieldEventParametersDAL();
            dal = new DALBaseProvider("STFieldEventParameters", typeof(STFieldEventParametersInfo));
        }        
        
        public DataSet GetFieldEventParameterByFieldEventID(int iFieldEventID)
        {            
            return (DataSet)dal.GetDataSet(spGetSTFieldEventParametersBySTFieldEventID, iFieldEventID);            
        }

        public STFieldEventParametersInfo GetFieldEventParameterByFieldEventIDAndFieldEventParameterName(int iFieldEventID, String strFieldEventParameterName)
        {            
            return (STFieldEventParametersInfo)dal.GetDataObject(spGetSTFieldEventParametersBySTFieldEventIDAndSTFieldEventParameterName,
                                                                 iFieldEventID,strFieldEventParameterName);            
        }        
    }
    #endregion
}
