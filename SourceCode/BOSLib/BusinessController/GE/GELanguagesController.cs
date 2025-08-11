using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace BOSLib
{
    #region GELanguagesController
    /// <summary>
    /// This object represents the properties and methods of a Language.
    /// </summary>
    public class GELanguagesController:BaseBusinessController
    {        

        public GELanguagesController()
        {            
            dal = new DALBaseProvider("GELanguages", typeof(GELanguagesInfo));
        }                        
    }
    #endregion
}
