using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region FieldEventFunctionController
    /// <summary>
    /// This object represents the properties and methods of a FieldEventFunction.
    /// </summary>
    public class STFieldEventFunctionsController:BaseBusinessController
    {
        #region SP Name        
        //Select By ForeignKey Queries
        private readonly string spGetSTFieldEventFunctionsBySTFieldEventID = "STFieldEventFunctions_SelectBySTFieldEventID";
        private readonly string spGetMaxSortOrderFunctionBySTFieldEventID = "STFieldEventFunctions_SelectMaxSTFieldEventFunctionSortOrderBySTFieldEventID";
        private readonly string spGetSTFieldEventFunctionsBySTFieldEventIDAndSTFieldEventFunctionFullNameAndSTFieldEventFunctionClass =
                               "STFieldEventFunctions_SelectBySTFieldEventIDAndSTFieldEventFunctionFullNameAndSTFieldEventFunctionClass";

        //Delete by foreignkey Queries
        private readonly string spDeleteSTFieldEventFunctionsBySTFieldEventID = "STFieldEventFunctions_DeleteBySTFieldEventID";

        #endregion

        public STFieldEventFunctionsController()
        {
            //dal = new STFieldEventFunctionsDAL();
            dal = new DALBaseProvider("STFieldEventFunctions", typeof(STFieldEventFunctionsInfo));
        }        
        

        public DataSet GetFieldEventFunctionByFieldEventID(int iFieldEventID)
        {            
            return (DataSet)dal.GetDataSet(spGetSTFieldEventFunctionsBySTFieldEventID,
                                           iFieldEventID);            
        }

        public int GetMaxSortOrderFunctionByFieldEventID(int iFieldEventID)
        {
            int iMaxSortOrderFunction = 0;
            try
            {                                
                DataSet ds = dal.GetDataSet(spGetMaxSortOrderFunctionBySTFieldEventID,
                                          iFieldEventID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0] != null)
                            iMaxSortOrderFunction = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    }
                }
            }
            catch (Exception)
            {
                iMaxSortOrderFunction = 0;
            }
            return iMaxSortOrderFunction;
            
        }

        public STFieldEventFunctionsInfo GetFieldEventFunctionByFieldEventIDAndFunctionFullNameAndFunctionClass(int iFieldEventID, String strFieldEventFunctionFullName, String strFieldEventFunctionClass)
        {            
            return (STFieldEventFunctionsInfo)dal.GetDataObject(spGetSTFieldEventFunctionsBySTFieldEventIDAndSTFieldEventFunctionFullNameAndSTFieldEventFunctionClass,
                                                                iFieldEventID, strFieldEventFunctionFullName, strFieldEventFunctionClass);            
        }

        public void DeleteFieldEventFunctionByFieldEventID(int iFieldEventID)
        {            
            dal.GetDataSet(spDeleteSTFieldEventFunctionsBySTFieldEventID,
                           iFieldEventID);           
        }        
    }
    #endregion
}
