using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STModuleSearchFieldsInfo
    /// <summary>
    /// This object represents the properties and methods of a STModuleSearchFields.
    /// </summary>
    public class STModuleSearchFieldsInfo : BusinessObject
    {

        protected int _sTModuleSearchFieldID;
        protected int _sTModuleStatusID;
        protected string _sTModuleSearchFieldName = DefaultString;
        protected string _sTModuleSearchFieldValue = String.Empty;

        public STModuleSearchFieldsInfo()
        {
        }

        public STModuleSearchFieldsInfo(int iSTModuleStatusID, string strSTModuleSearchFieldName, string strSTModuleSearchFieldValue)
        {
            STModuleStatusID = iSTModuleStatusID;
            STModuleSearchFieldName = strSTModuleSearchFieldName;
            STModuleSearchFieldValue = strSTModuleSearchFieldValue;
        }

        #region Public Properties
        public int STModuleSearchFieldID
        {
            get { return _sTModuleSearchFieldID; }
            set
            {
                if (value != this._sTModuleSearchFieldID)
                {
                    _sTModuleSearchFieldID = value;
                    NotifyChanged("STModuleSearchFieldID");
                }
            }
        }

        public int STModuleStatusID
        {
            get { return _sTModuleStatusID; }
            set
            {
                if (value != this._sTModuleStatusID)
                {
                    _sTModuleStatusID = value;
                    NotifyChanged("STModuleStatusID");
                }
            }
        }

        public string STModuleSearchFieldName
        {
            get { return _sTModuleSearchFieldName; }
            set
            {
                if (value != this._sTModuleSearchFieldName)
                {
                    _sTModuleSearchFieldName = value;
                    NotifyChanged("STModuleSearchFieldName");
                }
            }
        }

        public string STModuleSearchFieldValue
        {
            get { return _sTModuleSearchFieldValue; }
            set
            {
                if (value != this._sTModuleSearchFieldValue)
                {
                    _sTModuleSearchFieldValue = value;
                    NotifyChanged("STModuleSearchFieldValue");
                }
            }
        }
        #endregion
    }
    #endregion
}
