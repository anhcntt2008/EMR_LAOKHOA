using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STModuleStatusInfo
    /// <summary>
    /// This object represents the properties and methods of a STModuleStatus.
    /// </summary>
    public class STModuleStatusInfo : BusinessObject
    {

        protected int _sTModuleStatusID;
        protected int _sTModuleID;
        protected int _sTUserID;
        protected string _sTModuleStatusStatus = DefaultStatus;
        protected int _sTModuleStatusCurrentObjectID = DefaultNumber;

        public STModuleStatusInfo()
        {
        }

        public STModuleStatusInfo(int iSTModuleID, int iSTUserID, string strSTModuleStatusStatus, int iSTModuleStatusCurrentObjectID)
        {
            STModuleID = iSTModuleID;
            STUserID = iSTUserID;
            STModuleStatusStatus = strSTModuleStatusStatus;
            STModuleStatusCurrentObjectID = iSTModuleStatusCurrentObjectID;
        }

        #region Public Properties
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

        public int STUserID
        {
            get { return _sTUserID; }
            set
            {
                if (value != this._sTUserID)
                {
                    _sTUserID = value;
                    NotifyChanged("STUserID");
                }
            }
        }

        public string STModuleStatusStatus
        {
            get { return _sTModuleStatusStatus; }
            set
            {
                if (value != this._sTModuleStatusStatus)
                {
                    _sTModuleStatusStatus = value;
                    NotifyChanged("STModuleStatusStatus");
                }
            }
        }

        public int STModuleStatusCurrentObjectID
        {
            get { return _sTModuleStatusCurrentObjectID; }
            set
            {
                if (value != this._sTModuleStatusCurrentObjectID)
                {
                    _sTModuleStatusCurrentObjectID = value;
                    NotifyChanged("STModuleStatusCurrentObjectID");
                }
            }
        }
        #endregion
    }
    #endregion
}
