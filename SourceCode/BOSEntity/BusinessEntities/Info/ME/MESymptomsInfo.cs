using System;
using System.Text;
using System.Collections.Generic;
using BOSLib;
namespace BOSERP
{
    #region MESymptoms
    //-----------------------------------------------------------
    //UtHV
    //01172017
    //Symptoms: Danh muc trieu chung
    //-----------------------------------------------------------

    public class MESymptomsInfo : BusinessObject
    {
        public MESymptomsInfo()
        {
        }
        #region Variables
        protected int _mESymptomID;
        protected String _aAStatus = DefaultAAStatus;
        protected String _aACreatedUser = String.Empty;
        protected String _aAUpdatedUser = String.Empty;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected String _mESymptomNo = String.Empty;
        protected String _mESymptomDesc = String.Empty;
        #endregion

        #region Public properties
        public int MESymptomID
        {
            get { return _mESymptomID; }
            set
            {
                if (value != this._mESymptomID)
                {
                    _mESymptomID = value;
                    NotifyChanged("MESymptomID");
                }
            }
        }
        public String AAStatus
        {
            get { return _aAStatus; }
            set
            {
                if (value != this._aAStatus)
                {
                    _aAStatus = value;
                    NotifyChanged("AAStatus");
                }
            }
        }
        public String AACreatedUser
        {
            get { return _aACreatedUser; }
            set
            {
                if (value != this._aACreatedUser)
                {
                    _aACreatedUser = value;
                    NotifyChanged("AACreatedUser");
                }
            }
        }
        public String AAUpdatedUser
        {
            get { return _aAUpdatedUser; }
            set
            {
                if (value != this._aAUpdatedUser)
                {
                    _aAUpdatedUser = value;
                    NotifyChanged("AAUpdatedUser");
                }
            }
        }
        public DateTime AACreatedDate
        {
            get { return _aACreatedDate; }
            set
            {
                if (value != this._aACreatedDate)
                {
                    _aACreatedDate = value;
                    NotifyChanged("AACreatedDate");
                }
            }
        }
        public DateTime AAUpdatedDate
        {
            get { return _aAUpdatedDate; }
            set
            {
                if (value != this._aAUpdatedDate)
                {
                    _aAUpdatedDate = value;
                    NotifyChanged("AAUpdatedDate");
                }
            }
        }
        public String MESymptomNo
        {
            get { return _mESymptomNo; }
            set
            {
                if (value != this._mESymptomNo)
                {
                    _mESymptomNo = value;
                    NotifyChanged("MESymptomNo");
                }
            }
        }
        public String MESymptomDesc
        {
            get { return _mESymptomDesc; }
            set
            {
                if (value != this._mESymptomDesc)
                {
                    _mESymptomDesc = value;
                    NotifyChanged("MESymptomDesc");
                }
            }
        }
        #endregion
    }
    #endregion
}