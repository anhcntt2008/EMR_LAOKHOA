using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STModuleToolbarButtonCaptionsInfo
    /// <summary>
    /// This object represents the properties and methods of a STModuleToolbarButtonCaptions.
    /// </summary>
    public class STModuleToolbarButtonCaptionsInfo : BusinessObject
    {

        protected int _sTModuleToolbarButtonCaptionID;
        protected int _sTModuleToolbarButtonID;
        protected int _sTLanguageID;
        protected string _sTModuleToolbarButtonCaptionName = String.Empty;
        protected string _sTModuleToolbarButtonDesc = String.Empty;

        public STModuleToolbarButtonCaptionsInfo()
        {
        }

        public STModuleToolbarButtonCaptionsInfo(int iSTModuleToolbarButtonID, int iSTLanguageID, string strSTModuleToolbarButtonCaptionName, string strSTModuleToolbarButtonDesc)
        {
            STModuleToolbarButtonID = iSTModuleToolbarButtonID;
            STLanguageID = iSTLanguageID;
            STModuleToolbarButtonCaptionName = strSTModuleToolbarButtonCaptionName;
            STModuleToolbarButtonDesc = strSTModuleToolbarButtonDesc;
        }

        #region Public Properties
        public int STModuleToolbarButtonCaptionID
        {
            get { return _sTModuleToolbarButtonCaptionID; }
            set
            {
                if (value != this._sTModuleToolbarButtonCaptionID)
                {
                    _sTModuleToolbarButtonCaptionID = value;
                    NotifyChanged("STModuleToolbarButtonCaptionID");
                }
            }
        }

        public int STModuleToolbarButtonID
        {
            get { return _sTModuleToolbarButtonID; }
            set
            {
                if (value != this._sTModuleToolbarButtonID)
                {
                    _sTModuleToolbarButtonID = value;
                    NotifyChanged("STModuleToolbarButtonID");
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

        public string STModuleToolbarButtonCaptionName
        {
            get { return _sTModuleToolbarButtonCaptionName; }
            set
            {
                if (value != this._sTModuleToolbarButtonCaptionName)
                {
                    _sTModuleToolbarButtonCaptionName = value;
                    NotifyChanged("STModuleToolbarButtonCaptionName");
                }
            }
        }

        public string STModuleToolbarButtonDesc
        {
            get { return _sTModuleToolbarButtonDesc; }
            set
            {
                if (value != this._sTModuleToolbarButtonDesc)
                {
                    _sTModuleToolbarButtonDesc = value;
                    NotifyChanged("STModuleToolbarButtonDesc");
                }
            }
        }
        #endregion
    }
    #endregion
}
