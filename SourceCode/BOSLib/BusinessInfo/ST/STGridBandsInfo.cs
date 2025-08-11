using System;
using System.Collections.Generic;
using System.Text;

namespace BOSLib
{
    #region STGridBandsInfo
    /// <summary>
    /// This object represents the properties and methods of a STGridBands.
    /// </summary>
    public class STGridBandsInfo : BusinessObject
    {

        protected int _sTGridBandID;
        protected string _sTGridBandName = DefaultString;
        protected string _sTGridBandCaption = DefaultString;
        protected int _sTGridBandWidth = DefaultNumber;
        protected int _sTGridViewID;

        public STGridBandsInfo()
        {
        }

        public STGridBandsInfo(string strSTGridBandName, string strSTGridBandCaption, int iSTGridBandWidth, int iSTGridViewID)
        {
            STGridBandName = strSTGridBandName;
            STGridBandCaption = strSTGridBandCaption;
            STGridBandWidth = iSTGridBandWidth;
            STGridViewID = iSTGridViewID;
        }

        #region Public Properties
        public int STGridBandID
        {
            get { return _sTGridBandID; }
            set
            {
                if (value != this._sTGridBandID)
                {
                    _sTGridBandID = value;
                    NotifyChanged("STGridBandID");
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

        public string STGridBandCaption
        {
            get { return _sTGridBandCaption; }
            set
            {
                if (value != this._sTGridBandCaption)
                {
                    _sTGridBandCaption = value;
                    NotifyChanged("STGridBandCaption");
                }
            }
        }

        public int STGridBandWidth
        {
            get { return _sTGridBandWidth; }
            set
            {
                if (value != this._sTGridBandWidth)
                {
                    _sTGridBandWidth = value;
                    NotifyChanged("STGridBandWidth");
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
        #endregion
    }
    #endregion
}
