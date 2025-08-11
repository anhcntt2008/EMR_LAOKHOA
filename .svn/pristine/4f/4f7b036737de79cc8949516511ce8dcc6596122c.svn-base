using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STScreenTextsInfo
    /// <summary>
    /// This object represents the properties and methods of a STScreenTexts.
    /// </summary>
    public class STScreenTextsInfo : BusinessObject
    {

        protected int _sTScreenTextID;
        protected int _sTScreenID;
        protected int _sTLanguageID;
        protected string _sTScreenTextDesc = DefaultString;

        public STScreenTextsInfo()
        {
        }

        public STScreenTextsInfo(int iSTScreenID, int iSTLanguageID, string strSTScreenTextDesc)
        {
            STScreenID = iSTScreenID;
            STLanguageID = iSTLanguageID;
            STScreenTextDesc = strSTScreenTextDesc;
        }

        #region Public Properties
        public int STScreenTextID
        {
            get { return _sTScreenTextID; }
            set
            {
                if (value != this._sTScreenTextID)
                {
                    _sTScreenTextID = value;
                    NotifyChanged("STScreenTextID");
                }
            }
        }

        public int STScreenID
        {
            get { return _sTScreenID; }
            set
            {
                if (value != this._sTScreenID)
                {
                    _sTScreenID = value;
                    NotifyChanged("STScreenID");
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

        public string STScreenTextDesc
        {
            get { return _sTScreenTextDesc; }
            set
            {
                if (value != this._sTScreenTextDesc)
                {
                    _sTScreenTextDesc = value;
                    NotifyChanged("STScreenTextDesc");
                }
            }
        }
        #endregion
    }
    #endregion
}
