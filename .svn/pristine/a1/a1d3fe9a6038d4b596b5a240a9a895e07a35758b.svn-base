using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STTableQueriesInfo
    /// <summary>
    /// This object represents the properties and methods of a STTableQueries.
    /// </summary>
    public class STTableQueriesInfo : BusinessObject
    {

        protected int _sTTableQueryID;
        protected string _sTTableName = DefaultString;
        protected string _sTTableQueryKey = DefaultString;
        protected string _sTTableQueryCommand = DefaultString;

        public STTableQueriesInfo()
        {
        }

        public STTableQueriesInfo(string strSTTableName, string strSTTableQueryKey, string strSTTableQueryCommand)
        {
            STTableName = strSTTableName;
            STTableQueryKey = strSTTableQueryKey;
            STTableQueryCommand = strSTTableQueryCommand;
        }

        #region Public Properties
        public int STTableQueryID
        {
            get { return _sTTableQueryID; }
            set
            {
                if (value != this._sTTableQueryID)
                {
                    _sTTableQueryID = value;
                    NotifyChanged("STTableQueryID");
                }
            }
        }

        public string STTableName
        {
            get { return _sTTableName; }
            set
            {
                if (value != this._sTTableName)
                {
                    _sTTableName = value;
                    NotifyChanged("STTableName");
                }
            }
        }

        public string STTableQueryKey
        {
            get { return _sTTableQueryKey; }
            set
            {
                if (value != this._sTTableQueryKey)
                {
                    _sTTableQueryKey = value;
                    NotifyChanged("STTableQueryKey");
                }
            }
        }

        public string STTableQueryCommand
        {
            get { return _sTTableQueryCommand; }
            set
            {
                if (value != this._sTTableQueryCommand)
                {
                    _sTTableQueryCommand = value;
                    NotifyChanged("STTableQueryCommand");
                }
            }
        }
        #endregion
    }
    #endregion
}
