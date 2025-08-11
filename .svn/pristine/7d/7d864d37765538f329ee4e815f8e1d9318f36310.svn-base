using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STGridLevelNodesInfo
    /// <summary>
    /// This object represents the properties and methods of a STGridLevelNodes.
    /// </summary>
    public class STGridLevelNodesInfo : BusinessObject
    {

        protected int _sTGridLevelNodeID;
        protected string _sTGridLevelNodeName = DefaultString;
        protected string _sTGridLevelNodeRelationName = String.Empty;
        protected string _sTGridViewName = String.Empty;
        protected int _sTFieldID;
        protected int _sTGridLevelNodeIndex = DefaultNumber;
        protected string _sTGridLevelNodeParentRelationName = String.Empty;

        public STGridLevelNodesInfo()
        {
        }

        public STGridLevelNodesInfo(string strSTGridLevelNodeName, string strSTGridLevelNodeRelationName, string strSTGridViewName, int iSTFieldID, int iSTGridLevelNodeIndex, string strSTGridLevelNodeParentRelationName)
        {
            STGridLevelNodeName = strSTGridLevelNodeName;
            STGridLevelNodeRelationName = strSTGridLevelNodeRelationName;
            STGridViewName = strSTGridViewName;
            STFieldID = iSTFieldID;
            STGridLevelNodeIndex = iSTGridLevelNodeIndex;
            STGridLevelNodeParentRelationName = strSTGridLevelNodeParentRelationName;
        }

        #region Public Properties
        public int STGridLevelNodeID
        {
            get { return _sTGridLevelNodeID; }
            set
            {
                if (value != this._sTGridLevelNodeID)
                {
                    _sTGridLevelNodeID = value;
                    NotifyChanged("STGridLevelNodeID");
                }
            }
        }

        public string STGridLevelNodeName
        {
            get { return _sTGridLevelNodeName; }
            set
            {
                if (value != this._sTGridLevelNodeName)
                {
                    _sTGridLevelNodeName = value;
                    NotifyChanged("STGridLevelNodeName");
                }
            }
        }

        public string STGridLevelNodeRelationName
        {
            get { return _sTGridLevelNodeRelationName; }
            set
            {
                if (value != this._sTGridLevelNodeRelationName)
                {
                    _sTGridLevelNodeRelationName = value;
                    NotifyChanged("STGridLevelNodeRelationName");
                }
            }
        }

        public string STGridViewName
        {
            get { return _sTGridViewName; }
            set
            {
                if (value != this._sTGridViewName)
                {
                    _sTGridViewName = value;
                    NotifyChanged("STGridViewName");
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

        public int STGridLevelNodeIndex
        {
            get { return _sTGridLevelNodeIndex; }
            set
            {
                if (value != this._sTGridLevelNodeIndex)
                {
                    _sTGridLevelNodeIndex = value;
                    NotifyChanged("STGridLevelNodeIndex");
                }
            }
        }

        public string STGridLevelNodeParentRelationName
        {
            get { return _sTGridLevelNodeParentRelationName; }
            set
            {
                if (value != this._sTGridLevelNodeParentRelationName)
                {
                    _sTGridLevelNodeParentRelationName = value;
                    NotifyChanged("STGridLevelNodeParentRelationName");
                }
            }
        }
        #endregion
    }
    #endregion
}
