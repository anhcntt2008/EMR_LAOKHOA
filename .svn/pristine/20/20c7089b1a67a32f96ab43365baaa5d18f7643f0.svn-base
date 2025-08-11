using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STModuleFunctionsInfo
    /// <summary>
    /// This object represents the properties and methods of a STModuleFunctions.
    /// </summary>
    public class STModuleFunctionsInfo : BusinessObject
    {

        protected int _sTModuleFunctionID;
        protected int _sTModuleID;
        protected string _sTModuleFunctionName = DefaultString;
        protected string _sTModuleFunctionFullName = DefaultString;
        protected string _sTModuleFunctionReturnType = DefaultString;
        protected string _sTModuleFunctionClass = DefaultString;
        protected string _sTModuleFunctionSummary = String.Empty;
        protected string _sTModuleFunctionType = String.Empty;

        public STModuleFunctionsInfo()
        {
        }

        public STModuleFunctionsInfo(int iSTModuleID, string strSTModuleFunctionName, string strSTModuleFunctionFullName, string strSTModuleFunctionReturnType, string strSTModuleFunctionClass, string strSTModuleFunctionSummary, string strSTModuleFunctionType)
        {
            STModuleID = iSTModuleID;
            STModuleFunctionName = strSTModuleFunctionName;
            STModuleFunctionFullName = strSTModuleFunctionFullName;
            STModuleFunctionReturnType = strSTModuleFunctionReturnType;
            STModuleFunctionClass = strSTModuleFunctionClass;
            STModuleFunctionSummary = strSTModuleFunctionSummary;
            STModuleFunctionType = strSTModuleFunctionType;
        }

        #region Public Properties
        public int STModuleFunctionID
        {
            get { return _sTModuleFunctionID; }
            set
            {
                if (value != this._sTModuleFunctionID)
                {
                    _sTModuleFunctionID = value;
                    NotifyChanged("STModuleFunctionID");
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

        public string STModuleFunctionName
        {
            get { return _sTModuleFunctionName; }
            set
            {
                if (value != this._sTModuleFunctionName)
                {
                    _sTModuleFunctionName = value;
                    NotifyChanged("STModuleFunctionName");
                }
            }
        }

        public string STModuleFunctionFullName
        {
            get { return _sTModuleFunctionFullName; }
            set
            {
                if (value != this._sTModuleFunctionFullName)
                {
                    _sTModuleFunctionFullName = value;
                    NotifyChanged("STModuleFunctionFullName");
                }
            }
        }

        public string STModuleFunctionReturnType
        {
            get { return _sTModuleFunctionReturnType; }
            set
            {
                if (value != this._sTModuleFunctionReturnType)
                {
                    _sTModuleFunctionReturnType = value;
                    NotifyChanged("STModuleFunctionReturnType");
                }
            }
        }

        public string STModuleFunctionClass
        {
            get { return _sTModuleFunctionClass; }
            set
            {
                if (value != this._sTModuleFunctionClass)
                {
                    _sTModuleFunctionClass = value;
                    NotifyChanged("STModuleFunctionClass");
                }
            }
        }

        public string STModuleFunctionSummary
        {
            get { return _sTModuleFunctionSummary; }
            set
            {
                if (value != this._sTModuleFunctionSummary)
                {
                    _sTModuleFunctionSummary = value;
                    NotifyChanged("STModuleFunctionSummary");
                }
            }
        }

        public string STModuleFunctionType
        {
            get { return _sTModuleFunctionType; }
            set
            {
                if (value != this._sTModuleFunctionType)
                {
                    _sTModuleFunctionType = value;
                    NotifyChanged("STModuleFunctionType");
                }
            }
        }
        #endregion
    }
    #endregion
}
