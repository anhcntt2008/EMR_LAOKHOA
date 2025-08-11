using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region STFieldEventsController
    /// <summary>
    /// This object represents the properties and methods of a FieldEvent.
    /// </summary>
    public class STFieldEventsController:BaseBusinessController
    {
        #region SP Name        
        //Select By ForeignKey Queries
        private readonly string spGetSTFieldEventsBySTFieldID = "STFieldEvents_SelectBySTFieldID";
        private readonly string spGetSTFieldEventBySTFieldIDAndSTFieldEventName =
                               "STFieldEvents_SelectBySTFieldIDAndSTFieldEventName";


        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTFieldEventsBySTFieldID = "STFieldEvents_DeleteBySTFieldID";*/

        #endregion
        public STFieldEventsController()
        {
            //dal = new STFieldEventsDAL();
            dal = new DALBaseProvider("STFieldEvents", typeof(STFieldEventsInfo));
        }                                     

        public DataSet GetFieldEventByFieldID(int iFieldID)
        {            
            return (DataSet)dal.GetDataSet(spGetSTFieldEventsBySTFieldID, iFieldID);           
        }

        public STFieldEventsInfo GetFieldEventByFieldIDAndEventName(int iFieldID, String strEventName)
        {            
            return (STFieldEventsInfo)dal.GetDataObject(spGetSTFieldEventBySTFieldIDAndSTFieldEventName, iFieldID, strEventName);            
        }
    }
    #endregion
}
