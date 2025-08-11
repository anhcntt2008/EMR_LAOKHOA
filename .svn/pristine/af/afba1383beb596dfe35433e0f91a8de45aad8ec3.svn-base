using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STModuleToolbarToUserGroupsInfo
    /// <summary>
    /// This object represents the properties and methods of a STModuleToolbarToUserGroups.
    /// </summary>
    public class STModuleToolbarToUserGroupsInfo : BusinessObject
    {

        protected int _sTModuleToolbarToUserGroupID;
        protected int _sTModuleToolbarID;
        protected int _sTUserGroupID;
        protected bool _sTModuleToolbarToUserGroupStatus;

        public STModuleToolbarToUserGroupsInfo()
        {
        }

        public STModuleToolbarToUserGroupsInfo(int iSTModuleToolbarID, int iSTUserGroupID, bool bSTModuleToolbarToUserGroupStatus)
        {
            STModuleToolbarID = iSTModuleToolbarID;
            STUserGroupID = iSTUserGroupID;
            STModuleToolbarToUserGroupStatus = bSTModuleToolbarToUserGroupStatus;
        }

        #region Public Properties
        public int STModuleToolbarToUserGroupID
        {
            get { return _sTModuleToolbarToUserGroupID; }
            set
            {
                if (value != this._sTModuleToolbarToUserGroupID)
                {
                    _sTModuleToolbarToUserGroupID = value;
                    NotifyChanged("STModuleToolbarToUserGroupID");
                }
            }
        }

        public int STModuleToolbarID
        {
            get { return _sTModuleToolbarID; }
            set
            {
                if (value != this._sTModuleToolbarID)
                {
                    _sTModuleToolbarID = value;
                    NotifyChanged("STModuleToolbarID");
                }
            }
        }

        public int STUserGroupID
        {
            get { return _sTUserGroupID; }
            set
            {
                if (value != this._sTUserGroupID)
                {
                    _sTUserGroupID = value;
                    NotifyChanged("STUserGroupID");
                }
            }
        }

        public bool STModuleToolbarToUserGroupStatus
        {
            get { return _sTModuleToolbarToUserGroupStatus; }
            set
            {
                if (value != this._sTModuleToolbarToUserGroupStatus)
                {
                    _sTModuleToolbarToUserGroupStatus = value;
                    NotifyChanged("STModuleToolbarToUserGroupStatus");
                }
            }
        }
        #endregion
    }
    #endregion
}
