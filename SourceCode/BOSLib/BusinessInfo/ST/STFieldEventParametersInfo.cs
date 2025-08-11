using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STFieldEventParametersInfo
    /// <summary>
    /// This object represents the properties and methods of a STFieldEventParameters.
    /// </summary>
    public class STFieldEventParametersInfo : BusinessObject
    {

        protected int _sTFieldEventParameterID;
        protected int _sTFieldEventID;
        protected string _sTFieldEventParameterName = DefaultString;
        protected string _sTFieldEventParameterValue = DefaultString;

        public STFieldEventParametersInfo()
        {
        }

        public STFieldEventParametersInfo(int iSTFieldEventID, string strSTFieldEventParameterName, string strSTFieldEventParameterValue)
        {
            STFieldEventID = iSTFieldEventID;
            STFieldEventParameterName = strSTFieldEventParameterName;
            STFieldEventParameterValue = strSTFieldEventParameterValue;
        }

        #region Public Properties
        public int STFieldEventParameterID
        {
            get { return _sTFieldEventParameterID; }
            set
            {
                if (value != this._sTFieldEventParameterID)
                {
                    _sTFieldEventParameterID = value;
                    NotifyChanged("STFieldEventParameterID");
                }
            }
        }

        public int STFieldEventID
        {
            get { return _sTFieldEventID; }
            set
            {
                if (value != this._sTFieldEventID)
                {
                    _sTFieldEventID = value;
                    NotifyChanged("STFieldEventID");
                }
            }
        }

        public string STFieldEventParameterName
        {
            get { return _sTFieldEventParameterName; }
            set
            {
                if (value != this._sTFieldEventParameterName)
                {
                    _sTFieldEventParameterName = value;
                    NotifyChanged("STFieldEventParameterName");
                }
            }
        }

        public string STFieldEventParameterValue
        {
            get { return _sTFieldEventParameterValue; }
            set
            {
                if (value != this._sTFieldEventParameterValue)
                {
                    _sTFieldEventParameterValue = value;
                    NotifyChanged("STFieldEventParameterValue");
                }
            }
        }
        #endregion
    }
    #endregion
}
