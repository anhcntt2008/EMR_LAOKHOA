using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STGridColumnsInfo
    /// <summary>
    /// This object represents the properties and methods of a STGridColumns.
    /// </summary>
    public class STGridColumnsInfo : BusinessObject
    {

        protected int _sTGridColumnID;
        protected int _sTGridViewID;
        protected string _sTGridColumnName = DefaultString;
        protected string _sTGridColumnType = DefaultString;
        protected string _sTGridColumnCaption = DefaultString;
        protected string _sTGridColumnFieldName = DefaultString;
        protected string _sTGridBandName = DefaultString;
        protected int _sTGridColumnRowIndex = DefaultNumber;
        protected bool _sTGridColumnAutoFillDown;
        protected int _sTGridColumnVisibleIndex = DefaultNumber;
        protected string _sTGridColumnRepositoryEditorType = DefaultString;
        protected string _sTGridColumnRepositoryEditorName = DefaultString;
        protected string _sTGridColumnRepositoryDataSetName = DefaultString;
        protected string _sTGridColumnRepositoryDataSource = DefaultString;
        protected string _sTGridColumnRepositoryDisplayMember = DefaultString;
        protected string _sTGridColumnRepositoryValueMember = DefaultString;

        public STGridColumnsInfo()
        {
        }

        public STGridColumnsInfo(int iSTGridViewID, string strSTGridColumnName, string strSTGridColumnType, string strSTGridColumnCaption, string strSTGridColumnFieldName, string strSTGridBandName, int iSTGridColumnRowIndex, bool bSTGridColumnAutoFillDown, int iSTGridColumnVisibleIndex, string strSTGridColumnRepositoryEditorType, string strSTGridColumnRepositoryEditorName, string strSTGridColumnRepositoryDataSetName, string strSTGridColumnRepositoryDataSource, string strSTGridColumnRepositoryDisplayMember, string strSTGridColumnRepositoryValueMember)
        {
            STGridViewID = iSTGridViewID;
            STGridColumnName = strSTGridColumnName;
            STGridColumnType = strSTGridColumnType;
            STGridColumnCaption = strSTGridColumnCaption;
            STGridColumnFieldName = strSTGridColumnFieldName;
            STGridBandName = strSTGridBandName;
            STGridColumnRowIndex = iSTGridColumnRowIndex;
            STGridColumnAutoFillDown = bSTGridColumnAutoFillDown;
            STGridColumnVisibleIndex = iSTGridColumnVisibleIndex;
            STGridColumnRepositoryEditorType = strSTGridColumnRepositoryEditorType;
            STGridColumnRepositoryEditorName = strSTGridColumnRepositoryEditorName;
            STGridColumnRepositoryDataSetName = strSTGridColumnRepositoryDataSetName;
            STGridColumnRepositoryDataSource = strSTGridColumnRepositoryDataSource;
            STGridColumnRepositoryDisplayMember = strSTGridColumnRepositoryDisplayMember;
            STGridColumnRepositoryValueMember = strSTGridColumnRepositoryValueMember;
        }

        #region Public Properties
        public int STGridColumnID
        {
            get { return _sTGridColumnID; }
            set
            {
                if (value != this._sTGridColumnID)
                {
                    _sTGridColumnID = value;
                    NotifyChanged("STGridColumnID");
                }
            }
        }

        public int STGridViewID
        {
            get { return _sTGridViewID; }
            set
            {
                if (value != this._sTGridViewID)
                {
                    _sTGridViewID = value;
                    NotifyChanged("STGridViewID");
                }
            }
        }

        public string STGridColumnName
        {
            get { return _sTGridColumnName; }
            set
            {
                if (value != this._sTGridColumnName)
                {
                    _sTGridColumnName = value;
                    NotifyChanged("STGridColumnName");
                }
            }
        }

        public string STGridColumnType
        {
            get { return _sTGridColumnType; }
            set
            {
                if (value != this._sTGridColumnType)
                {
                    _sTGridColumnType = value;
                    NotifyChanged("STGridColumnType");
                }
            }
        }

        public string STGridColumnCaption
        {
            get { return _sTGridColumnCaption; }
            set
            {
                if (value != this._sTGridColumnCaption)
                {
                    _sTGridColumnCaption = value;
                    NotifyChanged("STGridColumnCaption");
                }
            }
        }

        public string STGridColumnFieldName
        {
            get { return _sTGridColumnFieldName; }
            set
            {
                if (value != this._sTGridColumnFieldName)
                {
                    _sTGridColumnFieldName = value;
                    NotifyChanged("STGridColumnFieldName");
                }
            }
        }

        public string STGridBandName
        {
            get { return _sTGridBandName; }
            set
            {
                if (value != this._sTGridBandName)
                {
                    _sTGridBandName = value;
                    NotifyChanged("STGridBandName");
                }
            }
        }

        public int STGridColumnRowIndex
        {
            get { return _sTGridColumnRowIndex; }
            set
            {
                if (value != this._sTGridColumnRowIndex)
                {
                    _sTGridColumnRowIndex = value;
                    NotifyChanged("STGridColumnRowIndex");
                }
            }
        }

        public bool STGridColumnAutoFillDown
        {
            get { return _sTGridColumnAutoFillDown; }
            set
            {
                if (value != this._sTGridColumnAutoFillDown)
                {
                    _sTGridColumnAutoFillDown = value;
                    NotifyChanged("STGridColumnAutoFillDown");
                }
            }
        }

        public int STGridColumnVisibleIndex
        {
            get { return _sTGridColumnVisibleIndex; }
            set
            {
                if (value != this._sTGridColumnVisibleIndex)
                {
                    _sTGridColumnVisibleIndex = value;
                    NotifyChanged("STGridColumnVisibleIndex");
                }
            }
        }

        public string STGridColumnRepositoryEditorType
        {
            get { return _sTGridColumnRepositoryEditorType; }
            set
            {
                if (value != this._sTGridColumnRepositoryEditorType)
                {
                    _sTGridColumnRepositoryEditorType = value;
                    NotifyChanged("STGridColumnRepositoryEditorType");
                }
            }
        }

        public string STGridColumnRepositoryEditorName
        {
            get { return _sTGridColumnRepositoryEditorName; }
            set
            {
                if (value != this._sTGridColumnRepositoryEditorName)
                {
                    _sTGridColumnRepositoryEditorName = value;
                    NotifyChanged("STGridColumnRepositoryEditorName");
                }
            }
        }

        public string STGridColumnRepositoryDataSetName
        {
            get { return _sTGridColumnRepositoryDataSetName; }
            set
            {
                if (value != this._sTGridColumnRepositoryDataSetName)
                {
                    _sTGridColumnRepositoryDataSetName = value;
                    NotifyChanged("STGridColumnRepositoryDataSetName");
                }
            }
        }

        public string STGridColumnRepositoryDataSource
        {
            get { return _sTGridColumnRepositoryDataSource; }
            set
            {
                if (value != this._sTGridColumnRepositoryDataSource)
                {
                    _sTGridColumnRepositoryDataSource = value;
                    NotifyChanged("STGridColumnRepositoryDataSource");
                }
            }
        }

        public string STGridColumnRepositoryDisplayMember
        {
            get { return _sTGridColumnRepositoryDisplayMember; }
            set
            {
                if (value != this._sTGridColumnRepositoryDisplayMember)
                {
                    _sTGridColumnRepositoryDisplayMember = value;
                    NotifyChanged("STGridColumnRepositoryDisplayMember");
                }
            }
        }

        public string STGridColumnRepositoryValueMember
        {
            get { return _sTGridColumnRepositoryValueMember; }
            set
            {
                if (value != this._sTGridColumnRepositoryValueMember)
                {
                    _sTGridColumnRepositoryValueMember = value;
                    NotifyChanged("STGridColumnRepositoryValueMember");
                }
            }
        }
        #endregion
    }
    #endregion
}
