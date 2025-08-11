using System;
using System.Collections.Generic;
using System.Text;
using BOSLib;

namespace BOSERP
{
    #region GECurrencyHistoryInfo
    /// <summary>
    /// This object represents the properties and methods of a GECurrencyHistory.
    /// </summary>
    public class GECurrencyHistoryInfo : BusinessObject
    {

        protected int _gECurrencyHistoryID;
        protected int _gECurrencyID;
        protected string _gECurrencyHistoryIDString = DefaultString;
        protected string _gECurrencyHistoryInformation = String.Empty;
        protected double _gECurrencyHistoryValue;
        protected double _gECurrencyHistoryValue1;
        protected DateTime _gECurrencyHistoryDateFrom = DefaultDate;
        protected DateTime _gECurrencyHistoryDateUntil = DefaultDate;
        protected double _gECurrencyHistoryValueFix;

        public GECurrencyHistoryInfo()
        {
        }

        public GECurrencyHistoryInfo(int iGECurrencyID, string strGECurrencyHistoryIDString, string strGECurrencyHistoryInformation, double dbGECurrencyHistoryValue, double dbGECurrencyHistoryValue1, DateTime dtGECurrencyHistoryDateFrom, DateTime dtGECurrencyHistoryDateUntil, double dbGECurrencyHistoryValueFix)
        {
            GECurrencyID = iGECurrencyID;
            GECurrencyHistoryIDString = strGECurrencyHistoryIDString;
            GECurrencyHistoryInformation = strGECurrencyHistoryInformation;
            GECurrencyHistoryValue = dbGECurrencyHistoryValue;
            GECurrencyHistoryValue1 = dbGECurrencyHistoryValue1;
            GECurrencyHistoryDateFrom = dtGECurrencyHistoryDateFrom;
            GECurrencyHistoryDateUntil = dtGECurrencyHistoryDateUntil;
            GECurrencyHistoryValueFix = dbGECurrencyHistoryValueFix;
        }

        #region Public Properties
        public int GECurrencyHistoryID
        {
            get { return _gECurrencyHistoryID; }
            set
            {
                if (value != this._gECurrencyHistoryID)
                {
                    _gECurrencyHistoryID = value;
                    NotifyChanged("GECurrencyHistoryID");
                }
            }
        }

        public int GECurrencyID
        {
            get { return _gECurrencyID; }
            set
            {
                if (value != this._gECurrencyID)
                {
                    _gECurrencyID = value;
                    NotifyChanged("GECurrencyID");
                }
            }
        }

        public string GECurrencyHistoryIDString
        {
            get { return _gECurrencyHistoryIDString; }
            set
            {
                if (value != this._gECurrencyHistoryIDString)
                {
                    _gECurrencyHistoryIDString = value;
                    NotifyChanged("GECurrencyHistoryIDString");
                }
            }
        }

        public string GECurrencyHistoryInformation
        {
            get { return _gECurrencyHistoryInformation; }
            set
            {
                if (value != this._gECurrencyHistoryInformation)
                {
                    _gECurrencyHistoryInformation = value;
                    NotifyChanged("GECurrencyHistoryInformation");
                }
            }
        }

        public double GECurrencyHistoryValue
        {
            get { return _gECurrencyHistoryValue; }
            set
            {
                if (value != this._gECurrencyHistoryValue)
                {
                    _gECurrencyHistoryValue = value;
                    NotifyChanged("GECurrencyHistoryValue");
                }
            }
        }

        public double GECurrencyHistoryValue1
        {
            get { return _gECurrencyHistoryValue1; }
            set
            {
                if (value != this._gECurrencyHistoryValue1)
                {
                    _gECurrencyHistoryValue1 = value;
                    NotifyChanged("GECurrencyHistoryValue1");
                }
            }
        }

        public DateTime GECurrencyHistoryDateFrom
        {
            get { return _gECurrencyHistoryDateFrom; }
            set
            {
                if (value != this._gECurrencyHistoryDateFrom)
                {
                    _gECurrencyHistoryDateFrom = value;
                    NotifyChanged("GECurrencyHistoryDateFrom");
                }
            }
        }

        public DateTime GECurrencyHistoryDateUntil
        {
            get { return _gECurrencyHistoryDateUntil; }
            set
            {
                if (value != this._gECurrencyHistoryDateUntil)
                {
                    _gECurrencyHistoryDateUntil = value;
                    NotifyChanged("GECurrencyHistoryDateUntil");
                }
            }
        }

        public double GECurrencyHistoryValueFix
        {
            get { return _gECurrencyHistoryValueFix; }
            set
            {
                if (value != this._gECurrencyHistoryValueFix)
                {
                    _gECurrencyHistoryValueFix = value;
                    NotifyChanged("GECurrencyHistoryValueFix");
                }
            }
        }
        #endregion
    }
    #endregion
}
