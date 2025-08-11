using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STModuleDescriptionsInfo
    /// <summary>
    /// This object represents the properties and methods of a STModuleDescriptions.
    /// </summary>
    public class STModuleDescriptionsInfo : BusinessObject
    {

        protected int _sTModuleDescriptionID;
        protected int _sTModuleID;
        protected int _sTLanguageID;
        protected string _sTModuleDescriptionDescription = DefaultString;

        public STModuleDescriptionsInfo()
        {
        }

        public STModuleDescriptionsInfo(int iSTModuleID, int iSTLanguageID, string strSTModuleDescriptionDescription)
        {
            STModuleID = iSTModuleID;
            STLanguageID = iSTLanguageID;
            STModuleDescriptionDescription = strSTModuleDescriptionDescription;
        }

        #region Public Properties
        public int STModuleDescriptionID
        {
            get { return _sTModuleDescriptionID; }
            set
            {
                if (value != this._sTModuleDescriptionID)
                {
                    _sTModuleDescriptionID = value;
                    NotifyChanged("STModuleDescriptionID");
                }
            }
        }

        public int STModuleID
        {
            get { return _sTModuleID; }
            set
            {
                if (value != this._sTModuleID)
                {
                    _sTModuleID = value;
                    NotifyChanged("STModuleID");
                }
            }
        }

        public int STLanguageID
        {
            get { return _sTLanguageID; }
            set
            {
                if (value != this._sTLanguageID)
                {
                    _sTLanguageID = value;
                    NotifyChanged("STLanguageID");
                }
            }
        }

        public string STModuleDescriptionDescription
        {
            get { return _sTModuleDescriptionDescription; }
            set
            {
                if (value != this._sTModuleDescriptionDescription)
                {
                    _sTModuleDescriptionDescription = value;
                    NotifyChanged("STModuleDescriptionDescription");
                }
            }
        }
        #endregion
    }
    #endregion
}
