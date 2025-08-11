using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STFieldEventsInfo
    /// <summary>
    /// This object represents the properties and methods of a STFieldEvents.
    /// </summary>
    public class STFieldEventsInfo : BusinessObject
    {

        protected int _sTFieldEventID;
        protected int _sTFieldID;
        protected string _sTFieldEventName = DefaultString;
        protected string _sTFieldEventDelegateFunctionName = DefaultString;
        protected string _sTFieldEventDelegateFunctionFullName = DefaultString;
        protected string _sTFieldEventDelegateFunctionClass = DefaultString;

        public STFieldEventsInfo()
        {
        }

        public STFieldEventsInfo(int iSTFieldID, string strSTFieldEventName, string strSTFieldEventDelegateFunctionName, string strSTFieldEventDelegateFunctionFullName, string strSTFieldEventDelegateFunctionClass)
        {
            STFieldID = iSTFieldID;
            STFieldEventName = strSTFieldEventName;
            STFieldEventDelegateFunctionName = strSTFieldEventDelegateFunctionName;
            STFieldEventDelegateFunctionFullName = strSTFieldEventDelegateFunctionFullName;
            STFieldEventDelegateFunctionClass = strSTFieldEventDelegateFunctionClass;
        }

        #region Public Properties
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

        public string STFieldEventName
        {
            get { return _sTFieldEventName; }
            set
            {
                if (value != this._sTFieldEventName)
                {
                    _sTFieldEventName = value;
                    NotifyChanged("STFieldEventName");
                }
            }
        }

        public string STFieldEventDelegateFunctionName
        {
            get { return _sTFieldEventDelegateFunctionName; }
            set
            {
                if (value != this._sTFieldEventDelegateFunctionName)
                {
                    _sTFieldEventDelegateFunctionName = value;
                    NotifyChanged("STFieldEventDelegateFunctionName");
                }
            }
        }

        public string STFieldEventDelegateFunctionFullName
        {
            get { return _sTFieldEventDelegateFunctionFullName; }
            set
            {
                if (value != this._sTFieldEventDelegateFunctionFullName)
                {
                    _sTFieldEventDelegateFunctionFullName = value;
                    NotifyChanged("STFieldEventDelegateFunctionFullName");
                }
            }
        }

        public string STFieldEventDelegateFunctionClass
        {
            get { return _sTFieldEventDelegateFunctionClass; }
            set
            {
                if (value != this._sTFieldEventDelegateFunctionClass)
                {
                    _sTFieldEventDelegateFunctionClass = value;
                    NotifyChanged("STFieldEventDelegateFunctionClass");
                }
            }
        }
        #endregion
    }
    #endregion
}
