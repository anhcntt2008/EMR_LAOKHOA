using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STModuleToolbarsInfo
    /// <summary>
    /// This object represents the properties and methods of a STModuleToolbars.
    /// </summary>
    public class STModuleToolbarsInfo : BusinessObject
    {

        protected int _sTModuleToolbarID;
        protected int _sTModuleID;
        protected string _sTModuleToolbarName = DefaultString;
        protected string _sTModuleToolbarDesc = String.Empty;

        public STModuleToolbarsInfo()
        {
        }

        public STModuleToolbarsInfo(int iSTModuleID, string strSTModuleToolbarName, string strSTModuleToolbarDesc)
        {
            STModuleID = iSTModuleID;
            STModuleToolbarName = strSTModuleToolbarName;
            STModuleToolbarDesc = strSTModuleToolbarDesc;
        }

        #region Public Properties
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

        public string STModuleToolbarName
        {
            get { return _sTModuleToolbarName; }
            set
            {
                if (value != this._sTModuleToolbarName)
                {
                    _sTModuleToolbarName = value;
                    NotifyChanged("STModuleToolbarName");
                }
            }
        }

        public string STModuleToolbarDesc
        {
            get { return _sTModuleToolbarDesc; }
            set
            {
                if (value != this._sTModuleToolbarDesc)
                {
                    _sTModuleToolbarDesc = value;
                    NotifyChanged("STModuleToolbarDesc");
                }
            }
        }
        #endregion
    }
    #endregion
}
