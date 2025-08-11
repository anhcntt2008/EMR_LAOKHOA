using System;
using BOSLib;

namespace BOSERP.Modules.BR.BranchServer.BusinessEntities.Info
{
    public class BRAutoUploadCHBaseInfo : BusinessObject
    {
        #region Variables

        protected int _bRAutoUploadCHBaseID;
        protected string _aACreatedUser = string.Empty;
        protected string _aAUpdatedUser = string.Empty;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected string _aAStatus = DefaultStatus;
        protected int _fK_BRBranchID;
        protected int _fK_MECommandID;
        protected bool _bRAutoUploadCHBaseValue = true;

        #endregion

        #region Public properties

        public int BRAutoUploadCHBaseID
        {
            get { return _bRAutoUploadCHBaseID; }
            set
            {
                if (value != _bRAutoUploadCHBaseID)
                {
                    _bRAutoUploadCHBaseID = value;
                    NotifyChanged("BRAutoUploadCHBaseID");
                }
            }
        }

        public string AACreatedUser
        {
            get { return _aACreatedUser; }
            set
            {
                if (value != _aACreatedUser)
                {
                    _aACreatedUser = value;
                    NotifyChanged("AACreatedUser");
                }
            }
        }

        public string AAUpdatedUser
        {
            get { return _aAUpdatedUser; }
            set
            {
                if (value != _aAUpdatedUser)
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
                if (value != _aACreatedDate)
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
                if (value != _aAUpdatedDate)
                {
                    _aAUpdatedDate = value;
                    NotifyChanged("AAUpdatedDate");
                }
            }
        }

        public string AAStatus
        {
            get { return _aAStatus; }
            set
            {
                if (value != _aAStatus)
                {
                    _aAStatus = value;
                    NotifyChanged("AAStatus");
                }
            }
        }

        public int FK_BRBranchID
        {
            get { return _fK_BRBranchID; }
            set
            {
                if (value != _fK_BRBranchID)
                {
                    _fK_BRBranchID = value;
                    NotifyChanged("FK_BRBranchID");
                }
            }
        }

        public int FK_MECommandID
        {
            get { return _fK_MECommandID; }
            set
            {
                if (value != _fK_MECommandID)
                {
                    _fK_MECommandID = value;
                    NotifyChanged("FK_MECommandID");
                }
            }
        }

        public bool BRAutoUploadCHBaseValue
        {
            get { return _bRAutoUploadCHBaseValue; }
            set
            {
                if (value != _bRAutoUploadCHBaseValue)
                {
                    _bRAutoUploadCHBaseValue = value;
                    NotifyChanged("BRAutoUploadCHBaseValue");
                }
            }
        }

        #endregion
    }
}