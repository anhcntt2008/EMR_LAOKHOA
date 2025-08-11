using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STModuleToUserGroupSectionsInfo
    /// <summary>
    /// This object represents the properties and methods of a STModuleToUserGroupSections.
    /// </summary>
    public class STModuleToUserGroupSectionsInfo : BusinessObject
    {

        protected int _sTModuleToUserGroupSectionID;
        protected int _sTUserGroupSectionID;
        protected int _sTModuleID;
        protected int _sTModuleToUserGroupSectionSortOrder = DefaultNumber;

        public STModuleToUserGroupSectionsInfo()
        {
        }

        public STModuleToUserGroupSectionsInfo(int iSTUserGroupSectionID, int iSTModuleID, int iSTModuleToUserGroupSectionSortOrder)
        {
            STUserGroupSectionID = iSTUserGroupSectionID;
            STModuleID = iSTModuleID;
            STModuleToUserGroupSectionSortOrder = iSTModuleToUserGroupSectionSortOrder;
        }

        #region Public Properties
        public int STModuleToUserGroupSectionID
        {
            get { return _sTModuleToUserGroupSectionID; }
            set
            {
                if (value != this._sTModuleToUserGroupSectionID)
                {
                    _sTModuleToUserGroupSectionID = value;
                    NotifyChanged("STModuleToUserGroupSectionID");
                }
            }
        }

        public int STUserGroupSectionID
        {
            get { return _sTUserGroupSectionID; }
            set
            {
                if (value != this._sTUserGroupSectionID)
                {
                    _sTUserGroupSectionID = value;
                    NotifyChanged("STUserGroupSectionID");
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

        public int STModuleToUserGroupSectionSortOrder
        {
            get { return _sTModuleToUserGroupSectionSortOrder; }
            set
            {
                if (value != this._sTModuleToUserGroupSectionSortOrder)
                {
                    _sTModuleToUserGroupSectionSortOrder = value;
                    NotifyChanged("STModuleToUserGroupSectionSortOrder");
                }
            }
        }
        #endregion
    }
    #endregion
}
