using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STFieldTextsInfo
    /// <summary>
    /// This object represents the properties and methods of a STFieldTexts.
    /// </summary>
    public class STFieldTextsInfo : BusinessObject
    {

        protected int _sTFieldTextID;
        protected int _sTFieldID;
        protected int _sTLanguageID;
        protected string _sTFieldTextText = String.Empty;
        protected string _sTFieldTextHint = String.Empty;

        public STFieldTextsInfo()
        {
        }

        public STFieldTextsInfo(int iSTFieldID, int iSTLanguageID, string strSTFieldTextText, string strSTFieldTextHint)
        {
            STFieldID = iSTFieldID;
            STLanguageID = iSTLanguageID;
            STFieldTextText = strSTFieldTextText;
            STFieldTextHint = strSTFieldTextHint;
        }

        #region Public Properties
        public int STFieldTextID
        {
            get { return _sTFieldTextID; }
            set
            {
                if (value != this._sTFieldTextID)
                {
                    _sTFieldTextID = value;
                    NotifyChanged("STFieldTextID");
                }
            }
        }

        public int STFieldID
        {
            get { return _sTFieldID; }
            set
            {
                if (value != this._sTFieldID)
                {
                    _sTFieldID = value;
                    NotifyChanged("STFieldID");
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

        public string STFieldTextText
        {
            get { return _sTFieldTextText; }
            set
            {
                if (value != this._sTFieldTextText)
                {
                    _sTFieldTextText = value;
                    NotifyChanged("STFieldTextText");
                }
            }
        }

        public string STFieldTextHint
        {
            get { return _sTFieldTextHint; }
            set
            {
                if (value != this._sTFieldTextHint)
                {
                    _sTFieldTextHint = value;
                    NotifyChanged("STFieldTextHint");
                }
            }
        }
        #endregion
    }
    #endregion
}
