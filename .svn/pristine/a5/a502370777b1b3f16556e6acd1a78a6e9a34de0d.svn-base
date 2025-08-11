using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STFieldEventFunctionsInfo
    /// <summary>
    /// This object represents the properties and methods of a STFieldEventFunctions.
    /// </summary>
    public class STFieldEventFunctionsInfo : BusinessObject
    {

        protected int _sTFieldEventFunctionID;
        protected int _sTFieldEventID;
        protected string _sTFieldEventFunctionName = DefaultString;
        protected string _sTFieldEventFunctionFullName = DefaultString;
        protected string _sTFieldEventFunctionClass = DefaultString;
        protected int _sTFieldEventFunctionSortOrder = DefaultNumber;

        public STFieldEventFunctionsInfo()
        {
        }

        public STFieldEventFunctionsInfo(int iSTFieldEventID, string strSTFieldEventFunctionName, string strSTFieldEventFunctionFullName, string strSTFieldEventFunctionClass, int iSTFieldEventFunctionSortOrder)
        {
            STFieldEventID = iSTFieldEventID;
            STFieldEventFunctionName = strSTFieldEventFunctionName;
            STFieldEventFunctionFullName = strSTFieldEventFunctionFullName;
            STFieldEventFunctionClass = strSTFieldEventFunctionClass;
            STFieldEventFunctionSortOrder = iSTFieldEventFunctionSortOrder;
        }

        #region Public Properties
        public int STFieldEventFunctionID
        {
            get { return _sTFieldEventFunctionID; }
            set
            {
                if (value != this._sTFieldEventFunctionID)
                {
                    _sTFieldEventFunctionID = value;
                    NotifyChanged("STFieldEventFunctionID");
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

        public string STFieldEventFunctionName
        {
            get { return _sTFieldEventFunctionName; }
            set
            {
                if (value != this._sTFieldEventFunctionName)
                {
                    _sTFieldEventFunctionName = value;
                    NotifyChanged("STFieldEventFunctionName");
                }
            }
        }

        public string STFieldEventFunctionFullName
        {
            get { return _sTFieldEventFunctionFullName; }
            set
            {
                if (value != this._sTFieldEventFunctionFullName)
                {
                    _sTFieldEventFunctionFullName = value;
                    NotifyChanged("STFieldEventFunctionFullName");
                }
            }
        }

        public string STFieldEventFunctionClass
        {
            get { return _sTFieldEventFunctionClass; }
            set
            {
                if (value != this._sTFieldEventFunctionClass)
                {
                    _sTFieldEventFunctionClass = value;
                    NotifyChanged("STFieldEventFunctionClass");
                }
            }
        }

        public int STFieldEventFunctionSortOrder
        {
            get { return _sTFieldEventFunctionSortOrder; }
            set
            {
                if (value != this._sTFieldEventFunctionSortOrder)
                {
                    _sTFieldEventFunctionSortOrder = value;
                    NotifyChanged("STFieldEventFunctionSortOrder");
                }
            }
        }
        #endregion
    }
    #endregion
}
