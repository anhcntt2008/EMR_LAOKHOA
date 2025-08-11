using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STModuleToolbarButtonToUserGroupsInfo
    /// <summary>
    /// This object represents the properties and methods of a STModuleToolbarButtonToUserGroups.
    /// </summary>
    public class STModuleToolbarButtonToUserGroupsInfo : BusinessObject
    {

        protected int _sTModuleToolbarButtonToUserGroupID;
        protected int _sTModuleToolbarButtonID;
        protected int _sTUserGroupID;
        protected bool _sTModuleToolbarButtonToUserGroupStatus;

        public STModuleToolbarButtonToUserGroupsInfo()
        {
        }

        public STModuleToolbarButtonToUserGroupsInfo(int iSTModuleToolbarButtonID, int iSTUserGroupID, bool bSTModuleToolbarButtonToUserGroupStatus)
        {
            STModuleToolbarButtonID = iSTModuleToolbarButtonID;
            STUserGroupID = iSTUserGroupID;
            STModuleToolbarButtonToUserGroupStatus = bSTModuleToolbarButtonToUserGroupStatus;
        }

        #region Public Properties
        public int STModuleToolbarButtonToUserGroupID
        {
            get { return _sTModuleToolbarButtonToUserGroupID; }
            set
            {
                if (value != this._sTModuleToolbarButtonToUserGroupID)
                {
                    _sTModuleToolbarButtonToUserGroupID = value;
                    NotifyChanged("STModuleToolbarButtonToUserGroupID");
                }
            }
        }

        public int STModuleToolbarButtonID
        {
            get { return _sTModuleToolbarButtonID; }
            set
            {
                if (value != this._sTModuleToolbarButtonID)
                {
                    _sTModuleToolbarButtonID = value;
                    NotifyChanged("STModuleToolbarButtonID");
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

        public bool STModuleToolbarButtonToUserGroupStatus
        {
            get { return _sTModuleToolbarButtonToUserGroupStatus; }
            set
            {
                if (value != this._sTModuleToolbarButtonToUserGroupStatus)
                {
                    _sTModuleToolbarButtonToUserGroupStatus = value;
                    NotifyChanged("STModuleToolbarButtonToUserGroupStatus");
                }
            }
        }
        #endregion
    }
    #endregion
}
