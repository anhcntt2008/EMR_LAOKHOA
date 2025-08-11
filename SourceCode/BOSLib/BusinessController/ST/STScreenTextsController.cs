using System;
using System.Collections.Generic;
using System.Text;
using System.Data;



namespace BOSLib
{
    #region STScreenTextsController
    /// <summary>
    /// This object represents the properties and methods of a ScreenText.
    /// </summary>
    public class STScreenTextsController:BaseBusinessController
    {

        #region SP Name

        //Select By ForeignKey Queries
        /*Remove cause of not use
        private readonly string spGetSTScreenTextsBySTScreenID = "STScreenTexts_SelectBySTScreenID";
        private readonly string spGetSTScreenTextsBySTLanguageID = "STScreenTexts_SelectBySTLanguageID";*/

       
        //Select By all foreignkey query
        private readonly string spGetSTScreenTextsBySTScreenIDAndSTLanguageID =
                               "STScreenTexts_SelectBySTScreenIDAndSTLanguageID";

        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTScreenTextsBySTScreenID = "STScreenTexts_DeleteBySTScreenID";
        private readonly string spDeleteSTScreenTextsBySTLanguageID = "STScreenTexts_DeleteBySTLanguageID";*/

        #endregion

        public STScreenTextsController()
        {
            //dal = new STScreenTextsDAL();
            dal = new DALBaseProvider("STScreenTexts", typeof(STScreenTextsInfo));
        }               

        public STScreenTextsInfo GetScreenTextByScreenIDAndLanguageID(int iScreenID, int iLanguageID)
        {
            return (STScreenTextsInfo)dal.GetDataObject(spGetSTScreenTextsBySTScreenIDAndSTLanguageID,
                                                        iScreenID, iLanguageID);            
        }
    }
    #endregion
}
