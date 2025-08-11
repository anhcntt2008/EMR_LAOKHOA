using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STModuleToolbarButtonsInfo
    /// <summary>
    /// This object represents the properties and methods of a STModuleToolbarButtons.
    /// </summary>
    public class STModuleToolbarButtonsInfo : BusinessObject
    {

        protected int _sTModuleToolbarButtonID;
        protected int _sTModuleToolbarID;
        protected string _sTModuleToolbarButtonName = DefaultString;
        protected string _sTModuleToolbarButtonTag = String.Empty;
        protected string _sTModuleToolbarButtonStyle = DefaultString;
        protected int _sTModuleToolbarButtonSortOrder = DefaultNumber;
        protected string _sTModuleToolbarButtonFunction = String.Empty;

        public STModuleToolbarButtonsInfo()
        {
        }

        public STModuleToolbarButtonsInfo(int iSTModuleToolbarID, string strSTModuleToolbarButtonName, string strSTModuleToolbarButtonTag, string strSTModuleToolbarButtonStyle, int iSTModuleToolbarButtonSortOrder, string strSTModuleToolbarButtonFunction)
        {
            STModuleToolbarID = iSTModuleToolbarID;
            STModuleToolbarButtonName = strSTModuleToolbarButtonName;
            STModuleToolbarButtonTag = strSTModuleToolbarButtonTag;
            STModuleToolbarButtonStyle = strSTModuleToolbarButtonStyle;
            STModuleToolbarButtonSortOrder = iSTModuleToolbarButtonSortOrder;
            STModuleToolbarButtonFunction = strSTModuleToolbarButtonFunction;
        }

        #region Public Properties
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

        public string STModuleToolbarButtonName
        {
            get { return _sTModuleToolbarButtonName; }
            set
            {
                if (value != this._sTModuleToolbarButtonName)
                {
                    _sTModuleToolbarButtonName = value;
                    NotifyChanged("STModuleToolbarButtonName");
                }
            }
        }

        public string STModuleToolbarButtonTag
        {
            get { return _sTModuleToolbarButtonTag; }
            set
            {
                if (value != this._sTModuleToolbarButtonTag)
                {
                    _sTModuleToolbarButtonTag = value;
                    NotifyChanged("STModuleToolbarButtonTag");
                }
            }
        }

        public string STModuleToolbarButtonStyle
        {
            get { return _sTModuleToolbarButtonStyle; }
            set
            {
                if (value != this._sTModuleToolbarButtonStyle)
                {
                    _sTModuleToolbarButtonStyle = value;
                    NotifyChanged("STModuleToolbarButtonStyle");
                }
            }
        }

        public int STModuleToolbarButtonSortOrder
        {
            get { return _sTModuleToolbarButtonSortOrder; }
            set
            {
                if (value != this._sTModuleToolbarButtonSortOrder)
                {
                    _sTModuleToolbarButtonSortOrder = value;
                    NotifyChanged("STModuleToolbarButtonSortOrder");
                }
            }
        }

        public string STModuleToolbarButtonFunction
        {
            get { return _sTModuleToolbarButtonFunction; }
            set
            {
                if (value != this._sTModuleToolbarButtonFunction)
                {
                    _sTModuleToolbarButtonFunction = value;
                    NotifyChanged("STModuleToolbarButtonFunction");
                }
            }
        }
        #endregion
    }
    #endregion
}
