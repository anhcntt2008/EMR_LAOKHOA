using System;
using System.Collections.Generic;
using System.Text;
using System.Data;




namespace BOSLib
{
    public class STModuleToolbarButtonCaptionsController:BaseBusinessController
    {

        #region SP Declaration        
        //Select By ForeignKey Queries

        /*Remove cause of not use
        private readonly string spGetSTModuleToolbarButtonCaptionsBySTLanguageID = "STModuleToolbarButtonCaptions_SelectBySTLanguageID";

        private readonly string spGetSTModuleToolbarButtonCaptionsBySTModuleToolbarButtonID = "STModuleToolbarButtonCaptions_SelectBySTModuleToolbarButtonID";
        //Select By all foreignkey query
        private readonly string spGetSTModuleToolbarButtonCaptionsBySTLanguageIDAndSTModuleToolbarButtonID = "STModuleToolbarButtonCaptions_SelectBySTLanguageIDAndSTModuleToolbarButtonID";*/

        private readonly string spGetSTModuleToolbarButtonCaptionsBySTModuleToolbarButtonIDAndGELanguageName =
                               "STModuleToolbarButtonCaptions_SelectBySTModuleToolbarButtonIDAndGELanguageName";

        //Delete by foreignkey Queries
        /*Remove cause of not use
        private readonly string spDeleteSTModuleToolbarButtonCaptionsBySTLanguageID = "STModuleToolbarButtonCaptions_DeleteBySTLanguageID";
        private readonly string spDeleteSTModuleToolbarButtonCaptionsBySTModuleToolbarButtonID = "STModuleToolbarButtonCaptions_DeleteBySTModuleToolbarButtonID";*/

        #endregion


        public STModuleToolbarButtonCaptionsController()
        {
            //dal = new STModuleToolbarButtonCaptionsDAL();
            dal = new DALBaseProvider("STModuleToolbarButtonCaptions", typeof(STModuleToolbarButtonCaptionsInfo));
        }        
        

        public STModuleToolbarButtonCaptionsInfo GetModuleToolbarButtonCaptionByModuleToolbarButtonIDAndLanguageName(int iModuleToolbarButtonID, String strLanguageName)
        {
            return (STModuleToolbarButtonCaptionsInfo)dal.GetDataObject(spGetSTModuleToolbarButtonCaptionsBySTModuleToolbarButtonIDAndGELanguageName,
                                                                       iModuleToolbarButtonID, strLanguageName);            
        }

        public String GetModuleToolbarButtonCaptionNameByModuleToolbarButtonIDAndLanguageName(int iModuleToolbarButtonID, String strLanguageName)
        {
            String strModuleToolbarButtonCaptionName = "";
            STModuleToolbarButtonCaptionsInfo objSTModuleToolbarButtonCaptionsInfo = GetModuleToolbarButtonCaptionByModuleToolbarButtonIDAndLanguageName(iModuleToolbarButtonID, strLanguageName);
            if (objSTModuleToolbarButtonCaptionsInfo != null)
                strModuleToolbarButtonCaptionName = objSTModuleToolbarButtonCaptionsInfo.STModuleToolbarButtonCaptionName;
            return strModuleToolbarButtonCaptionName;
        }

        public String GetModuleToolbarButtonDescByModuleToolbarButtonIDAndLanguageName(int iModuleToolbarButtonID, String strLanguageName)
        {
            String strModuleToolbarButtonDesc = "";
            STModuleToolbarButtonCaptionsInfo objSTModuleToolbarButtonCaptionsInfo = GetModuleToolbarButtonCaptionByModuleToolbarButtonIDAndLanguageName(iModuleToolbarButtonID, strLanguageName);
            if (objSTModuleToolbarButtonCaptionsInfo != null)
                strModuleToolbarButtonDesc = objSTModuleToolbarButtonCaptionsInfo.STModuleToolbarButtonDesc;
            return strModuleToolbarButtonDesc;
        }

    }
}
