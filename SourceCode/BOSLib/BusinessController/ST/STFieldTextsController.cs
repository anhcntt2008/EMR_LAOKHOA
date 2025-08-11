using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;


namespace BOSLib
{
    public class STFieldTextsController:BaseBusinessController
    {

        #region SP Name

        //Select By ForeignKey Queries
        private readonly string spGetSTFieldTextsBySTLanguageID = "STFieldTexts_SelectBySTLanguageID";
        private readonly string spGetSTFieldTextsBySTFieldID = "STFieldTexts_SelectBySTFieldID";
        //Select By all foreignkey query
        private readonly string spGetSTFieldTextsBySTFieldIDAndSTLanguageID = "STFieldTexts_SelectBySTFieldIDAndSTLanguageID";



        //Delete by foreignkey Queries

        /*Remove cause of not use
        private readonly string spDeleteSTFieldTextsBySTLanguageID = "STFieldTexts_DeleteBySTLanguageID";
        private readonly string spDeleteSTFieldTextsBySTFieldID = "STFieldTexts_DeleteBySTFieldID";*/

        #endregion

        public STFieldTextsController()
        {
            //dal = new STFieldTextsDAL();
            dal = new DALBaseProvider("STFieldTexts", typeof(STFieldTextsInfo));
        }
        
        public DataSet GetFieldTextByLanguageID(int iLanguageID)
        {            
            return (DataSet)dal.GetDataSet(spGetSTFieldTextsBySTLanguageID,
                                           iLanguageID);
            
        }

        public DataSet GetFieldTextByFieldID(int iFieldID)
        {
         
            return (DataSet)dal.GetDataSet(spGetSTFieldTextsBySTFieldID,
                                           iFieldID);            
        }

        public STFieldTextsInfo GetFieldTextByFieldIDAndLanguageID(int iFieldID, int iLanguageID)
        {         
            return (STFieldTextsInfo)dal.GetDataObject(spGetSTFieldTextsBySTFieldIDAndSTLanguageID,
                                                       iFieldID, iLanguageID);            
        }        
        public bool IsExist(int iFieldID, int iLanguageID)
        {
            try
            {
                STFieldTextsInfo objSTFieldTextsInfo = new STFieldTextsInfo();
                objSTFieldTextsInfo = GetFieldTextByFieldIDAndLanguageID(iFieldID, iLanguageID);
                if (objSTFieldTextsInfo != null)
                    return true;
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
    }
}
