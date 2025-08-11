using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STStoredProceduresInfo
    /// <summary>
    /// This object represents the properties and methods of a STStoredProcedures.
    /// </summary>
    public class STStoredProceduresInfo : BusinessObject
    {

        protected int _sTStoredProcedureID;
        protected string _sTStoredProcedureName = DefaultString;
        protected string _sTTableName = String.Empty;
        protected string _sTStoredProcedureText = DefaultString;
        protected string _sTStoredProcedureMatchCode1 = String.Empty;
        protected string _sTStoredProcedureMatchCode2 = String.Empty;
        protected string _sTStoredProcedureMatchCode3 = String.Empty;
        protected string _sTStoredProcedureMatchCode4 = String.Empty;
        protected string _sTStoredProcedurePreviousStatus = String.Empty;
        protected string _sTStoredProcedureStatus = String.Empty;

        public STStoredProceduresInfo()
        {
        }

        public STStoredProceduresInfo(string strSTStoredProcedureName, string strSTTableName, string strSTStoredProcedureText, string strSTStoredProcedureMatchCode1, string strSTStoredProcedureMatchCode2, string strSTStoredProcedureMatchCode3, string strSTStoredProcedureMatchCode4, string strSTStoredProcedurePreviousStatus, string strSTStoredProcedureStatus)
        {
            STStoredProcedureName = strSTStoredProcedureName;
            STTableName = strSTTableName;
            STStoredProcedureText = strSTStoredProcedureText;
            STStoredProcedureMatchCode1 = strSTStoredProcedureMatchCode1;
            STStoredProcedureMatchCode2 = strSTStoredProcedureMatchCode2;
            STStoredProcedureMatchCode3 = strSTStoredProcedureMatchCode3;
            STStoredProcedureMatchCode4 = strSTStoredProcedureMatchCode4;
            STStoredProcedurePreviousStatus = strSTStoredProcedurePreviousStatus;
            STStoredProcedureStatus = strSTStoredProcedureStatus;
        }

        #region Public Properties
        public int STStoredProcedureID
        {
            get { return _sTStoredProcedureID; }
            set
            {
                if (value != this._sTStoredProcedureID)
                {
                    _sTStoredProcedureID = value;
                    NotifyChanged("STStoredProcedureID");
                }
            }
        }

        public string STStoredProcedureName
        {
            get { return _sTStoredProcedureName; }
            set
            {
                if (value != this._sTStoredProcedureName)
                {
                    _sTStoredProcedureName = value;
                    NotifyChanged("STStoredProcedureName");
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

        public string STStoredProcedureText
        {
            get { return _sTStoredProcedureText; }
            set
            {
                if (value != this._sTStoredProcedureText)
                {
                    _sTStoredProcedureText = value;
                    NotifyChanged("STStoredProcedureText");
                }
            }
        }

        public string STStoredProcedureMatchCode1
        {
            get { return _sTStoredProcedureMatchCode1; }
            set
            {
                if (value != this._sTStoredProcedureMatchCode1)
                {
                    _sTStoredProcedureMatchCode1 = value;
                    NotifyChanged("STStoredProcedureMatchCode1");
                }
            }
        }

        public string STStoredProcedureMatchCode2
        {
            get { return _sTStoredProcedureMatchCode2; }
            set
            {
                if (value != this._sTStoredProcedureMatchCode2)
                {
                    _sTStoredProcedureMatchCode2 = value;
                    NotifyChanged("STStoredProcedureMatchCode2");
                }
            }
        }

        public string STStoredProcedureMatchCode3
        {
            get { return _sTStoredProcedureMatchCode3; }
            set
            {
                if (value != this._sTStoredProcedureMatchCode3)
                {
                    _sTStoredProcedureMatchCode3 = value;
                    NotifyChanged("STStoredProcedureMatchCode3");
                }
            }
        }

        public string STStoredProcedureMatchCode4
        {
            get { return _sTStoredProcedureMatchCode4; }
            set
            {
                if (value != this._sTStoredProcedureMatchCode4)
                {
                    _sTStoredProcedureMatchCode4 = value;
                    NotifyChanged("STStoredProcedureMatchCode4");
                }
            }
        }

        public string STStoredProcedurePreviousStatus
        {
            get { return _sTStoredProcedurePreviousStatus; }
            set
            {
                if (value != this._sTStoredProcedurePreviousStatus)
                {
                    _sTStoredProcedurePreviousStatus = value;
                    NotifyChanged("STStoredProcedurePreviousStatus");
                }
            }
        }

        public string STStoredProcedureStatus
        {
            get { return _sTStoredProcedureStatus; }
            set
            {
                if (value != this._sTStoredProcedureStatus)
                {
                    _sTStoredProcedureStatus = value;
                    NotifyChanged("STStoredProcedureStatus");
                }
            }
        }
        #endregion
    }
    #endregion
}
