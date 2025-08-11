using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STModuleTablesInfo
    /// <summary>
    /// This object represents the properties and methods of a STModuleTables.
    /// </summary>
    public class STModuleTablesInfo : BusinessObject
    {

        protected int _sTModuleTableID;
        protected int _sTModuleID;
        protected string _sTModuleTableName = DefaultString;
        protected int _sTModuleTableType = DefaultNumber;
        protected int _sTModuleTableLevelIndex;

        public STModuleTablesInfo()
        {
        }

        public STModuleTablesInfo(int iSTModuleID, string strSTModuleTableName, int iSTModuleTableType, int iSTModuleTableLevelIndex)
        {
            STModuleID = iSTModuleID;
            STModuleTableName = strSTModuleTableName;
            STModuleTableType = iSTModuleTableType;
            STModuleTableLevelIndex = iSTModuleTableLevelIndex;
        }

        #region Public Properties
        public int STModuleTableID
        {
            get { return _sTModuleTableID; }
            set
            {
                if (value != this._sTModuleTableID)
                {
                    _sTModuleTableID = value;
                    NotifyChanged("STModuleTableID");
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

        public string STModuleTableName
        {
            get { return _sTModuleTableName; }
            set
            {
                if (value != this._sTModuleTableName)
                {
                    _sTModuleTableName = value;
                    NotifyChanged("STModuleTableName");
                }
            }
        }

        public int STModuleTableType
        {
            get { return _sTModuleTableType; }
            set
            {
                if (value != this._sTModuleTableType)
                {
                    _sTModuleTableType = value;
                    NotifyChanged("STModuleTableType");
                }
            }
        }

        public int STModuleTableLevelIndex
        {
            get { return _sTModuleTableLevelIndex; }
            set
            {
                if (value != this._sTModuleTableLevelIndex)
                {
                    _sTModuleTableLevelIndex = value;
                    NotifyChanged("STModuleTableLevelIndex");
                }
            }
        }
        #endregion
    }
    #endregion
}
