using System;
using System.Text;
using System.Collections.Generic;
using BOSLib;
namespace BOSERP
{
    #region HREmployees
    

    public class HREmployeesInfo : BusinessObject
    {
        public HREmployeesInfo()
        {
            HREmployeeDob = DateTime.Now;
            HREmployeeStartWorkingDate = DateTime.Now;
            HREmployeeHealthInsRegisteredDate = DateTime.Now;
            HREmployeeIDCardDate = DateTime.Now;
            HREmployeePassportIssuedDate = DateTime.Now;
            HREmployeePassportIssuedPlace = DateTime.Now;
            HREmployeeEndWorkingDate = DateTime.Now;
            HREmployeeSocialInsRegisteredDate = DateTime.Now;
            HREmployeeHealthInsExpiryDate = DateTime.Now;
        }
        #region Variables
        protected int _hREmployeeID;
        protected String _aAStatus = DefaultAAStatus;
        protected String _aACreatedUser = String.Empty;
        protected String _aAUpdatedUser = String.Empty;
        protected DateTime _aACreatedDate = DateTime.MaxValue;
        protected DateTime _aAUpdatedDate = DateTime.MaxValue;
        protected bool _isTransferred = true;
        protected DateTime _aATransferredDate = DateTime.MaxValue;
        protected int _fK_HRDepartmentID;
        protected int _fK_HRDepartmentRoomID;
        protected int _fK_HRLevelID;
        protected int _fK_HRTimeSheetScaleID;
        protected int _fK_BRBranchID;
        protected String _hREmployeeNo = String.Empty;
        protected String _hREmployeeName = String.Empty;
        protected String _hREmployeeGenderCombo = String.Empty;
        protected DateTime _hREmployeeDob = DateTime.MaxValue;
        protected String _hREmployeeBirthPlace = String.Empty;
        protected String _hREmployeeTypeCombo = String.Empty;
        protected String _hREmployeeStatusCombo = DefaultStatus;
        protected String _hREmployeeDesc = String.Empty;
        protected byte[] _hREmployeePicture;
        protected String _hREmployeeIDNumber = String.Empty;
        protected String _hREmployeeIDCardPlace = String.Empty;
        protected DateTime _hREmployeeIDCardDate = DateTime.MaxValue;
        protected String _hREmployeeCardNumber = String.Empty;
        protected String _hREmployeePassportNo = String.Empty;
        protected DateTime _hREmployeePassportIssuedDate = DateTime.MaxValue;
        protected DateTime _hREmployeePassportIssuedPlace = DateTime.MaxValue;
        protected String _hREmployeeSlrPmtMthdCombo = String.Empty;
        protected double _hREmployeeWorkingSlrAmt;
        protected double _hREmployeeContractSlrAmt;
        protected String _hREmployeeReligion = String.Empty;
        protected String _hREmployeeTaxNumber = String.Empty;
        protected bool _hREmployeeActiveCheck = true;
        protected DateTime _hREmployeeStartWorkingDate = DateTime.MaxValue;
        protected DateTime _hREmployeeEndWorkingDate = DateTime.MaxValue;
        protected DateTime _hREmployeeStartWorkingTime = DateTime.MaxValue;
        protected DateTime _hREmployeeEndWorkingTime = DateTime.MaxValue;
        protected String _hREmployeeTel1 = String.Empty;
        protected String _hREmployeeTel2 = String.Empty;
        protected String _hREmployeeTel3 = String.Empty;
        protected String _hREmployeeEmail1 = String.Empty;
        protected String _hREmployeePassword1 = String.Empty;
        protected String _hREmployeeEmail2 = String.Empty;
        protected String _hREmployeeFax = String.Empty;
        protected String _hREmployeeContactAddressStreet = String.Empty;
        protected String _hREmployeeContactAddressLine1 = String.Empty;
        protected String _hREmployeeContactAddressLine2 = String.Empty;
        protected String _hREmployeeContactAddressLine3 = String.Empty;
        protected String _hREmployeeContactAddressCity = String.Empty;
        protected String _hREmployeeContactAddressPostalCode = String.Empty;
        protected String _hREmployeeContactAddressStateProvince = String.Empty;
        protected String _hREmployeeContactAddressZipCode = String.Empty;
        protected String _hREmployeeContactAddressCountry = String.Empty;
        protected String _hREmployeeBankCode = String.Empty;
        protected String _hREmployeeBankName = String.Empty;
        protected String _hREmployeeBankAccount1 = String.Empty;
        protected int _hREmployeeBankAccountCurrency1;
        protected String _hREmployeeBankAccount2 = String.Empty;
        protected int _hREmployeeBankAccountCurrency2;
        protected String _hREmployeeBankAccount3 = String.Empty;
        protected int _hREmployeeBankAccountCurrency3;
        protected String _hREmployeeBankAccount4 = String.Empty;
        protected int _hREmployeeBankAccountCurrency4;
        protected String _hRInsCalculatedSalaryType = String.Empty;
        protected String _hREmployeeSocialInsNo = String.Empty;
        protected DateTime _hREmployeeSocialInsRegisteredDate = DateTime.MaxValue;
        protected DateTime _hREmployeeSocialInsExpiryDate = DateTime.MaxValue;
        protected double _hREmployeeSocialInsPaymentPercent;
        protected String _hREmployeeHealthInsNo = String.Empty;
        protected String _hREmployeeHealthInsRegisteredPlace = String.Empty;
        protected DateTime _hREmployeeHealthInsRegisteredDate = DateTime.MaxValue;
        protected DateTime _hREmployeeHealthInsExpiryDate = DateTime.MaxValue;
        protected double _hREmployeeHealthInsPaymentPercent;
        protected double _hREmployeeOutOfWorkInsPaymentPercent;
        protected double _hREmployeeSyndicatePaymentPercent;
        protected double _hREmployeeTaxPaymentPercent;
        protected double _hREmployeeSalaryFactor;
        protected double _hREmployeeExtraSalary1;
        protected double _hREmployeeExtraSalary2;
        protected double _hREmployeeExtraSalary3;
        protected double _hREmployeeExtraSalary4;
        protected String _hRPayRollCalculatedSalaryType = String.Empty;
        protected double _hREmployeeHoursPerDay;
        protected double _hREmployeeDaysPerMonth;
        protected double _hREmployeeWorkingHourlySalary;
        protected double _hREmployeeWorkingDailySalary;
        protected double _hREmployeeContractHourlySalary;
        protected double _hREmployeeContractDailySalary;
        protected int _fK_HREmployeePayrollFormulaID;
        protected int _fK_GENativeStateProvinceID;
        protected String _hREmployeeMaritalStatusCombo = DefaultStatus;
        protected String _hREmployeeEducation = String.Empty;
        protected int _fK_GEIDCardStateProvinceID;
        protected int _fK_GENationalityID;
        protected int _fK_GEReligionID;
        protected int _fK_MESpecialismID;
        protected int _fK_HRCommissionLevelID;
        protected int _fK_HRWorkingShiftID;
        protected double _hREmployeeTaxPaymentAmount;
        protected double _hREmployeeExtraGasolineVehicle;
        protected double _hREmployeeExtraResponsibility;
        protected double _hREmployeeExtraLunch;
        protected double _hREmployeeExtraHarmfullSubsidies;
        protected string _hrEmployeeBacSi24x7Id;
        protected byte[] _hREmployeeSignature;
        protected String _hREmployeeShortSignature = String.Empty;
        protected String _hREmployeeStatusTKCombo = ActiveStatus;
        protected int _fk_HREmployeeStateID;
        #endregion

        #region Public properties
        public int HREmployeeID
        {
            get { return _hREmployeeID; }
            set
            {
                if (value != this._hREmployeeID)
                {
                    _hREmployeeID = value;
                    NotifyChanged("HREmployeeID");
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
        public bool IsTransferred
        {
            get { return _isTransferred; }
            set
            {
                if (value != this._isTransferred)
                {
                    _isTransferred = value;
                    NotifyChanged("IsTransferred");
                }
            }
        }
        public DateTime AATransferredDate
        {
            get { return _aATransferredDate; }
            set
            {
                if (value != this._aATransferredDate)
                {
                    _aATransferredDate = value;
                    NotifyChanged("AATransferredDate");
                }
            }
        }
        public int FK_HRDepartmentID
        {
            get { return _fK_HRDepartmentID; }
            set
            {
                if (value != this._fK_HRDepartmentID)
                {
                    _fK_HRDepartmentID = value;
                    NotifyChanged("FK_HRDepartmentID");
                }
            }
        }
        public int FK_HRDepartmentRoomID
        {
            get { return _fK_HRDepartmentRoomID; }
            set
            {
                if (value != this._fK_HRDepartmentRoomID)
                {
                    _fK_HRDepartmentRoomID = value;
                    NotifyChanged("FK_HRDepartmentRoomID");
                }
            }
        }
        public int FK_HRLevelID
        {
            get { return _fK_HRLevelID; }
            set
            {
                if (value != this._fK_HRLevelID)
                {
                    _fK_HRLevelID = value;
                    NotifyChanged("FK_HRLevelID");
                }
            }
        }
        public int FK_HRTimeSheetScaleID
        {
            get { return _fK_HRTimeSheetScaleID; }
            set
            {
                if (value != this._fK_HRTimeSheetScaleID)
                {
                    _fK_HRTimeSheetScaleID = value;
                    NotifyChanged("FK_HRTimeSheetScaleID");
                }
            }
        }
        public int FK_BRBranchID
        {
            get { return _fK_BRBranchID; }
            set
            {
                if (value != this._fK_BRBranchID)
                {
                    _fK_BRBranchID = value;
                    NotifyChanged("FK_BRBranchID");
                }
            }
        }
        public String HREmployeeNo
        {
            get { return _hREmployeeNo; }
            set
            {
                if (value != this._hREmployeeNo)
                {
                    _hREmployeeNo = value;
                    NotifyChanged("HREmployeeNo");
                }
            }
        }
        public String HREmployeeName
        {
            get { return _hREmployeeName; }
            set
            {
                if (value != this._hREmployeeName)
                {
                    _hREmployeeName = value;
                    NotifyChanged("HREmployeeName");
                }
            }
        }
        public String HREmployeeGenderCombo
        {
            get { return _hREmployeeGenderCombo; }
            set
            {
                if (value != this._hREmployeeGenderCombo)
                {
                    _hREmployeeGenderCombo = value;
                    NotifyChanged("HREmployeeGenderCombo");
                }
            }
        }
        public DateTime HREmployeeDob
        {
            get { return _hREmployeeDob; }
            set
            {
                if (value != this._hREmployeeDob)
                {
                    _hREmployeeDob = value;
                    NotifyChanged("HREmployeeDob");
                }
            }
        }
        public String HREmployeeBirthPlace
        {
            get { return _hREmployeeBirthPlace; }
            set
            {
                if (value != this._hREmployeeBirthPlace)
                {
                    _hREmployeeBirthPlace = value;
                    NotifyChanged("HREmployeeBirthPlace");
                }
            }
        }
        public String HREmployeeTypeCombo
        {
            get { return _hREmployeeTypeCombo; }
            set
            {
                if (value != this._hREmployeeTypeCombo)
                {
                    _hREmployeeTypeCombo = value;
                    NotifyChanged("HREmployeeTypeCombo");
                }
            }
        }
        public String HREmployeeStatusCombo
        {
            get { return _hREmployeeStatusCombo; }
            set
            {
                if (value != this._hREmployeeStatusCombo)
                {
                    _hREmployeeStatusCombo = value;
                    NotifyChanged("HREmployeeStatusCombo");
                }
            }
        }
        public String HREmployeeDesc
        {
            get { return _hREmployeeDesc; }
            set
            {
                if (value != this._hREmployeeDesc)
                {
                    _hREmployeeDesc = value;
                    NotifyChanged("HREmployeeDesc");
                }
            }
        }
        public byte[] HREmployeePicture
        {
            get { return _hREmployeePicture; }
            set
            {
                if (value != this._hREmployeePicture)
                {
                    _hREmployeePicture = value;
                    NotifyChanged("HREmployeePicture");
                }
            }
        }
        public String HREmployeeIDNumber
        {
            get { return _hREmployeeIDNumber; }
            set
            {
                if (value != this._hREmployeeIDNumber)
                {
                    _hREmployeeIDNumber = value;
                    NotifyChanged("HREmployeeIDNumber");
                }
            }
        }
        public String HREmployeeIDCardPlace
        {
            get { return _hREmployeeIDCardPlace; }
            set
            {
                if (value != this._hREmployeeIDCardPlace)
                {
                    _hREmployeeIDCardPlace = value;
                    NotifyChanged("HREmployeeIDCardPlace");
                }
            }
        }
        public DateTime HREmployeeIDCardDate
        {
            get { return _hREmployeeIDCardDate; }
            set
            {
                if (value != this._hREmployeeIDCardDate)
                {
                    _hREmployeeIDCardDate = value;
                    NotifyChanged("HREmployeeIDCardDate");
                }
            }
        }
        public String HREmployeeCardNumber
        {
            get { return _hREmployeeCardNumber; }
            set
            {
                if (value != this._hREmployeeCardNumber)
                {
                    _hREmployeeCardNumber = value;
                    NotifyChanged("HREmployeeCardNumber");
                }
            }
        }
        public String HREmployeePassportNo
        {
            get { return _hREmployeePassportNo; }
            set
            {
                if (value != this._hREmployeePassportNo)
                {
                    _hREmployeePassportNo = value;
                    NotifyChanged("HREmployeePassportNo");
                }
            }
        }
        public DateTime HREmployeePassportIssuedDate
        {
            get { return _hREmployeePassportIssuedDate; }
            set
            {
                if (value != this._hREmployeePassportIssuedDate)
                {
                    _hREmployeePassportIssuedDate = value;
                    NotifyChanged("HREmployeePassportIssuedDate");
                }
            }
        }
        public DateTime HREmployeePassportIssuedPlace
        {
            get { return _hREmployeePassportIssuedPlace; }
            set
            {
                if (value != this._hREmployeePassportIssuedPlace)
                {
                    _hREmployeePassportIssuedPlace = value;
                    NotifyChanged("HREmployeePassportIssuedPlace");
                }
            }
        }
        public String HREmployeeSlrPmtMthdCombo
        {
            get { return _hREmployeeSlrPmtMthdCombo; }
            set
            {
                if (value != this._hREmployeeSlrPmtMthdCombo)
                {
                    _hREmployeeSlrPmtMthdCombo = value;
                    NotifyChanged("HREmployeeSlrPmtMthdCombo");
                }
            }
        }
        public double HREmployeeWorkingSlrAmt
        {
            get { return _hREmployeeWorkingSlrAmt; }
            set
            {
                if (value != this._hREmployeeWorkingSlrAmt)
                {
                    _hREmployeeWorkingSlrAmt = value;
                    NotifyChanged("HREmployeeWorkingSlrAmt");
                }
            }
        }
        public double HREmployeeContractSlrAmt
        {
            get { return _hREmployeeContractSlrAmt; }
            set
            {
                if (value != this._hREmployeeContractSlrAmt)
                {
                    _hREmployeeContractSlrAmt = value;
                    NotifyChanged("HREmployeeContractSlrAmt");
                }
            }
        }
        public String HREmployeeReligion
        {
            get { return _hREmployeeReligion; }
            set
            {
                if (value != this._hREmployeeReligion)
                {
                    _hREmployeeReligion = value;
                    NotifyChanged("HREmployeeReligion");
                }
            }
        }
        public String HREmployeeTaxNumber
        {
            get { return _hREmployeeTaxNumber; }
            set
            {
                if (value != this._hREmployeeTaxNumber)
                {
                    _hREmployeeTaxNumber = value;
                    NotifyChanged("HREmployeeTaxNumber");
                }
            }
        }
        public bool HREmployeeActiveCheck
        {
            get { return _hREmployeeActiveCheck; }
            set
            {
                if (value != this._hREmployeeActiveCheck)
                {
                    _hREmployeeActiveCheck = value;
                    NotifyChanged("HREmployeeActiveCheck");
                }
            }
        }
        public DateTime HREmployeeStartWorkingDate
        {
            get { return _hREmployeeStartWorkingDate; }
            set
            {
                if (value != this._hREmployeeStartWorkingDate)
                {
                    _hREmployeeStartWorkingDate = value;
                    NotifyChanged("HREmployeeStartWorkingDate");
                }
            }
        }
        public DateTime HREmployeeEndWorkingDate
        {
            get { return _hREmployeeEndWorkingDate; }
            set
            {
                if (value != this._hREmployeeEndWorkingDate)
                {
                    _hREmployeeEndWorkingDate = value;
                    NotifyChanged("HREmployeeEndWorkingDate");
                }
            }
        }
        public DateTime HREmployeeStartWorkingTime
        {
            get { return _hREmployeeStartWorkingTime; }
            set
            {
                if (value != this._hREmployeeStartWorkingTime)
                {
                    _hREmployeeStartWorkingTime = value;
                    NotifyChanged("HREmployeeStartWorkingTime");
                }
            }
        }
        public DateTime HREmployeeEndWorkingTime
        {
            get { return _hREmployeeEndWorkingTime; }
            set
            {
                if (value != this._hREmployeeEndWorkingTime)
                {
                    _hREmployeeEndWorkingTime = value;
                    NotifyChanged("HREmployeeEndWorkingTime");
                }
            }
        }
        public String HREmployeeTel1
        {
            get { return _hREmployeeTel1; }
            set
            {
                if (value != this._hREmployeeTel1)
                {
                    _hREmployeeTel1 = value;
                    NotifyChanged("HREmployeeTel1");
                }
            }
        }
        public String HREmployeeTel2
        {
            get { return _hREmployeeTel2; }
            set
            {
                if (value != this._hREmployeeTel2)
                {
                    _hREmployeeTel2 = value;
                    NotifyChanged("HREmployeeTel2");
                }
            }
        }
        public String HREmployeeTel3
        {
            get { return _hREmployeeTel3; }
            set
            {
                if (value != this._hREmployeeTel3)
                {
                    _hREmployeeTel3 = value;
                    NotifyChanged("HREmployeeTel3");
                }
            }
        }
        public String HREmployeeEmail1
        {
            get { return _hREmployeeEmail1; }
            set
            {
                if (value != this._hREmployeeEmail1)
                {
                    _hREmployeeEmail1 = value;
                    NotifyChanged("HREmployeeEmail1");
                }
            }
        }
        public String HREmployeePassword1
        {
            get { return _hREmployeePassword1; }
            set
            {
                if (value != this._hREmployeePassword1)
                {
                    _hREmployeePassword1 = value;
                    NotifyChanged("HREmployeePassword1");
                }
            }
        }
        public String HREmployeeEmail2
        {
            get { return _hREmployeeEmail2; }
            set
            {
                if (value != this._hREmployeeEmail2)
                {
                    _hREmployeeEmail2 = value;
                    NotifyChanged("HREmployeeEmail2");
                }
            }
        }
        public String HREmployeeFax
        {
            get { return _hREmployeeFax; }
            set
            {
                if (value != this._hREmployeeFax)
                {
                    _hREmployeeFax = value;
                    NotifyChanged("HREmployeeFax");
                }
            }
        }
        public String HREmployeeContactAddressStreet
        {
            get { return _hREmployeeContactAddressStreet; }
            set
            {
                if (value != this._hREmployeeContactAddressStreet)
                {
                    _hREmployeeContactAddressStreet = value;
                    NotifyChanged("HREmployeeContactAddressStreet");
                }
            }
        }
        public String HREmployeeContactAddressLine1
        {
            get { return _hREmployeeContactAddressLine1; }
            set
            {
                if (value != this._hREmployeeContactAddressLine1)
                {
                    _hREmployeeContactAddressLine1 = value;
                    NotifyChanged("HREmployeeContactAddressLine1");
                }
            }
        }
        public String HREmployeeContactAddressLine2
        {
            get { return _hREmployeeContactAddressLine2; }
            set
            {
                if (value != this._hREmployeeContactAddressLine2)
                {
                    _hREmployeeContactAddressLine2 = value;
                    NotifyChanged("HREmployeeContactAddressLine2");
                }
            }
        }
        public String HREmployeeContactAddressLine3
        {
            get { return _hREmployeeContactAddressLine3; }
            set
            {
                if (value != this._hREmployeeContactAddressLine3)
                {
                    _hREmployeeContactAddressLine3 = value;
                    NotifyChanged("HREmployeeContactAddressLine3");
                }
            }
        }
        public String HREmployeeContactAddressCity
        {
            get { return _hREmployeeContactAddressCity; }
            set
            {
                if (value != this._hREmployeeContactAddressCity)
                {
                    _hREmployeeContactAddressCity = value;
                    NotifyChanged("HREmployeeContactAddressCity");
                }
            }
        }
        public String HREmployeeContactAddressPostalCode
        {
            get { return _hREmployeeContactAddressPostalCode; }
            set
            {
                if (value != this._hREmployeeContactAddressPostalCode)
                {
                    _hREmployeeContactAddressPostalCode = value;
                    NotifyChanged("HREmployeeContactAddressPostalCode");
                }
            }
        }
        public String HREmployeeContactAddressStateProvince
        {
            get { return _hREmployeeContactAddressStateProvince; }
            set
            {
                if (value != this._hREmployeeContactAddressStateProvince)
                {
                    _hREmployeeContactAddressStateProvince = value;
                    NotifyChanged("HREmployeeContactAddressStateProvince");
                }
            }
        }
        public String HREmployeeContactAddressZipCode
        {
            get { return _hREmployeeContactAddressZipCode; }
            set
            {
                if (value != this._hREmployeeContactAddressZipCode)
                {
                    _hREmployeeContactAddressZipCode = value;
                    NotifyChanged("HREmployeeContactAddressZipCode");
                }
            }
        }
        public String HREmployeeContactAddressCountry
        {
            get { return _hREmployeeContactAddressCountry; }
            set
            {
                if (value != this._hREmployeeContactAddressCountry)
                {
                    _hREmployeeContactAddressCountry = value;
                    NotifyChanged("HREmployeeContactAddressCountry");
                }
            }
        }
        public String HREmployeeBankCode
        {
            get { return _hREmployeeBankCode; }
            set
            {
                if (value != this._hREmployeeBankCode)
                {
                    _hREmployeeBankCode = value;
                    NotifyChanged("HREmployeeBankCode");
                }
            }
        }
        public String HREmployeeBankName
        {
            get { return _hREmployeeBankName; }
            set
            {
                if (value != this._hREmployeeBankName)
                {
                    _hREmployeeBankName = value;
                    NotifyChanged("HREmployeeBankName");
                }
            }
        }
        public String HREmployeeBankAccount1
        {
            get { return _hREmployeeBankAccount1; }
            set
            {
                if (value != this._hREmployeeBankAccount1)
                {
                    _hREmployeeBankAccount1 = value;
                    NotifyChanged("HREmployeeBankAccount1");
                }
            }
        }
        public int HREmployeeBankAccountCurrency1
        {
            get { return _hREmployeeBankAccountCurrency1; }
            set
            {
                if (value != this._hREmployeeBankAccountCurrency1)
                {
                    _hREmployeeBankAccountCurrency1 = value;
                    NotifyChanged("HREmployeeBankAccountCurrency1");
                }
            }
        }
        public String HREmployeeBankAccount2
        {
            get { return _hREmployeeBankAccount2; }
            set
            {
                if (value != this._hREmployeeBankAccount2)
                {
                    _hREmployeeBankAccount2 = value;
                    NotifyChanged("HREmployeeBankAccount2");
                }
            }
        }
        public int HREmployeeBankAccountCurrency2
        {
            get { return _hREmployeeBankAccountCurrency2; }
            set
            {
                if (value != this._hREmployeeBankAccountCurrency2)
                {
                    _hREmployeeBankAccountCurrency2 = value;
                    NotifyChanged("HREmployeeBankAccountCurrency2");
                }
            }
        }
        public String HREmployeeBankAccount3
        {
            get { return _hREmployeeBankAccount3; }
            set
            {
                if (value != this._hREmployeeBankAccount3)
                {
                    _hREmployeeBankAccount3 = value;
                    NotifyChanged("HREmployeeBankAccount3");
                }
            }
        }
        public int HREmployeeBankAccountCurrency3
        {
            get { return _hREmployeeBankAccountCurrency3; }
            set
            {
                if (value != this._hREmployeeBankAccountCurrency3)
                {
                    _hREmployeeBankAccountCurrency3 = value;
                    NotifyChanged("HREmployeeBankAccountCurrency3");
                }
            }
        }
        public String HREmployeeBankAccount4
        {
            get { return _hREmployeeBankAccount4; }
            set
            {
                if (value != this._hREmployeeBankAccount4)
                {
                    _hREmployeeBankAccount4 = value;
                    NotifyChanged("HREmployeeBankAccount4");
                }
            }
        }
        public int HREmployeeBankAccountCurrency4
        {
            get { return _hREmployeeBankAccountCurrency4; }
            set
            {
                if (value != this._hREmployeeBankAccountCurrency4)
                {
                    _hREmployeeBankAccountCurrency4 = value;
                    NotifyChanged("HREmployeeBankAccountCurrency4");
                }
            }
        }
        public String HRInsCalculatedSalaryType
        {
            get { return _hRInsCalculatedSalaryType; }
            set
            {
                if (value != this._hRInsCalculatedSalaryType)
                {
                    _hRInsCalculatedSalaryType = value;
                    NotifyChanged("HRInsCalculatedSalaryType");
                }
            }
        }
        public String HREmployeeSocialInsNo
        {
            get { return _hREmployeeSocialInsNo; }
            set
            {
                if (value != this._hREmployeeSocialInsNo)
                {
                    _hREmployeeSocialInsNo = value;
                    NotifyChanged("HREmployeeSocialInsNo");
                }
            }
        }
        public DateTime HREmployeeSocialInsRegisteredDate
        {
            get { return _hREmployeeSocialInsRegisteredDate; }
            set
            {
                if (value != this._hREmployeeSocialInsRegisteredDate)
                {
                    _hREmployeeSocialInsRegisteredDate = value;
                    NotifyChanged("HREmployeeSocialInsRegisteredDate");
                }
            }
        }
        public DateTime HREmployeeSocialInsExpiryDate
        {
            get { return _hREmployeeSocialInsExpiryDate; }
            set
            {
                if (value != this._hREmployeeSocialInsExpiryDate)
                {
                    _hREmployeeSocialInsExpiryDate = value;
                    NotifyChanged("HREmployeeSocialInsExpiryDate");
                }
            }
        }
        public double HREmployeeSocialInsPaymentPercent
        {
            get { return _hREmployeeSocialInsPaymentPercent; }
            set
            {
                if (value != this._hREmployeeSocialInsPaymentPercent)
                {
                    _hREmployeeSocialInsPaymentPercent = value;
                    NotifyChanged("HREmployeeSocialInsPaymentPercent");
                }
            }
        }
        public String HREmployeeHealthInsNo
        {
            get { return _hREmployeeHealthInsNo; }
            set
            {
                if (value != this._hREmployeeHealthInsNo)
                {
                    _hREmployeeHealthInsNo = value;
                    NotifyChanged("HREmployeeHealthInsNo");
                }
            }
        }
        public String HREmployeeHealthInsRegisteredPlace
        {
            get { return _hREmployeeHealthInsRegisteredPlace; }
            set
            {
                if (value != this._hREmployeeHealthInsRegisteredPlace)
                {
                    _hREmployeeHealthInsRegisteredPlace = value;
                    NotifyChanged("HREmployeeHealthInsRegisteredPlace");
                }
            }
        }
        public DateTime HREmployeeHealthInsRegisteredDate
        {
            get { return _hREmployeeHealthInsRegisteredDate; }
            set
            {
                if (value != this._hREmployeeHealthInsRegisteredDate)
                {
                    _hREmployeeHealthInsRegisteredDate = value;
                    NotifyChanged("HREmployeeHealthInsRegisteredDate");
                }
            }
        }
        public DateTime HREmployeeHealthInsExpiryDate
        {
            get { return _hREmployeeHealthInsExpiryDate; }
            set
            {
                if (value != this._hREmployeeHealthInsExpiryDate)
                {
                    _hREmployeeHealthInsExpiryDate = value;
                    NotifyChanged("HREmployeeHealthInsExpiryDate");
                }
            }
        }
        public double HREmployeeHealthInsPaymentPercent
        {
            get { return _hREmployeeHealthInsPaymentPercent; }
            set
            {
                if (value != this._hREmployeeHealthInsPaymentPercent)
                {
                    _hREmployeeHealthInsPaymentPercent = value;
                    NotifyChanged("HREmployeeHealthInsPaymentPercent");
                }
            }
        }
        public double HREmployeeOutOfWorkInsPaymentPercent
        {
            get { return _hREmployeeOutOfWorkInsPaymentPercent; }
            set
            {
                if (value != this._hREmployeeOutOfWorkInsPaymentPercent)
                {
                    _hREmployeeOutOfWorkInsPaymentPercent = value;
                    NotifyChanged("HREmployeeOutOfWorkInsPaymentPercent");
                }
            }
        }
        public double HREmployeeSyndicatePaymentPercent
        {
            get { return _hREmployeeSyndicatePaymentPercent; }
            set
            {
                if (value != this._hREmployeeSyndicatePaymentPercent)
                {
                    _hREmployeeSyndicatePaymentPercent = value;
                    NotifyChanged("HREmployeeSyndicatePaymentPercent");
                }
            }
        }
        public double HREmployeeTaxPaymentPercent
        {
            get { return _hREmployeeTaxPaymentPercent; }
            set
            {
                if (value != this._hREmployeeTaxPaymentPercent)
                {
                    _hREmployeeTaxPaymentPercent = value;
                    NotifyChanged("HREmployeeTaxPaymentPercent");
                }
            }
        }
        public double HREmployeeSalaryFactor
        {
            get { return _hREmployeeSalaryFactor; }
            set
            {
                if (value != this._hREmployeeSalaryFactor)
                {
                    _hREmployeeSalaryFactor = value;
                    NotifyChanged("HREmployeeSalaryFactor");
                }
            }
        }
        public double HREmployeeExtraSalary1
        {
            get { return _hREmployeeExtraSalary1; }
            set
            {
                if (value != this._hREmployeeExtraSalary1)
                {
                    _hREmployeeExtraSalary1 = value;
                    NotifyChanged("HREmployeeExtraSalary1");
                }
            }
        }
        public double HREmployeeExtraSalary2
        {
            get { return _hREmployeeExtraSalary2; }
            set
            {
                if (value != this._hREmployeeExtraSalary2)
                {
                    _hREmployeeExtraSalary2 = value;
                    NotifyChanged("HREmployeeExtraSalary2");
                }
            }
        }
        public double HREmployeeExtraSalary3
        {
            get { return _hREmployeeExtraSalary3; }
            set
            {
                if (value != this._hREmployeeExtraSalary3)
                {
                    _hREmployeeExtraSalary3 = value;
                    NotifyChanged("HREmployeeExtraSalary3");
                }
            }
        }
        public double HREmployeeExtraSalary4
        {
            get { return _hREmployeeExtraSalary4; }
            set
            {
                if (value != this._hREmployeeExtraSalary4)
                {
                    _hREmployeeExtraSalary4 = value;
                    NotifyChanged("HREmployeeExtraSalary4");
                }
            }
        }
        public String HRPayRollCalculatedSalaryType
        {
            get { return _hRPayRollCalculatedSalaryType; }
            set
            {
                if (value != this._hRPayRollCalculatedSalaryType)
                {
                    _hRPayRollCalculatedSalaryType = value;
                    NotifyChanged("HRPayRollCalculatedSalaryType");
                }
            }
        }
        public double HREmployeeHoursPerDay
        {
            get { return _hREmployeeHoursPerDay; }
            set
            {
                if (value != this._hREmployeeHoursPerDay)
                {
                    _hREmployeeHoursPerDay = value;
                    NotifyChanged("HREmployeeHoursPerDay");
                }
            }
        }
        public double HREmployeeDaysPerMonth
        {
            get { return _hREmployeeDaysPerMonth; }
            set
            {
                if (value != this._hREmployeeDaysPerMonth)
                {
                    _hREmployeeDaysPerMonth = value;
                    NotifyChanged("HREmployeeDaysPerMonth");
                }
            }
        }
        public double HREmployeeWorkingHourlySalary
        {
            get { return _hREmployeeWorkingHourlySalary; }
            set
            {
                if (value != this._hREmployeeWorkingHourlySalary)
                {
                    _hREmployeeWorkingHourlySalary = value;
                    NotifyChanged("HREmployeeWorkingHourlySalary");
                }
            }
        }
        public double HREmployeeWorkingDailySalary
        {
            get { return _hREmployeeWorkingDailySalary; }
            set
            {
                if (value != this._hREmployeeWorkingDailySalary)
                {
                    _hREmployeeWorkingDailySalary = value;
                    NotifyChanged("HREmployeeWorkingDailySalary");
                }
            }
        }
        public double HREmployeeContractHourlySalary
        {
            get { return _hREmployeeContractHourlySalary; }
            set
            {
                if (value != this._hREmployeeContractHourlySalary)
                {
                    _hREmployeeContractHourlySalary = value;
                    NotifyChanged("HREmployeeContractHourlySalary");
                }
            }
        }
        public double HREmployeeContractDailySalary
        {
            get { return _hREmployeeContractDailySalary; }
            set
            {
                if (value != this._hREmployeeContractDailySalary)
                {
                    _hREmployeeContractDailySalary = value;
                    NotifyChanged("HREmployeeContractDailySalary");
                }
            }
        }
        public int FK_HREmployeePayrollFormulaID
        {
            get { return _fK_HREmployeePayrollFormulaID; }
            set
            {
                if (value != this._fK_HREmployeePayrollFormulaID)
                {
                    _fK_HREmployeePayrollFormulaID = value;
                    NotifyChanged("FK_HREmployeePayrollFormulaID");
                }
            }
        }
        public int FK_GENativeStateProvinceID
        {
            get { return _fK_GENativeStateProvinceID; }
            set
            {
                if (value != this._fK_GENativeStateProvinceID)
                {
                    _fK_GENativeStateProvinceID = value;
                    NotifyChanged("FK_GENativeStateProvinceID");
                }
            }
        }
        public String HREmployeeMaritalStatusCombo
        {
            get { return _hREmployeeMaritalStatusCombo; }
            set
            {
                if (value != this._hREmployeeMaritalStatusCombo)
                {
                    _hREmployeeMaritalStatusCombo = value;
                    NotifyChanged("HREmployeeMaritalStatusCombo");
                }
            }
        }
        public String HREmployeeEducation
        {
            get { return _hREmployeeEducation; }
            set
            {
                if (value != this._hREmployeeEducation)
                {
                    _hREmployeeEducation = value;
                    NotifyChanged("HREmployeeEducation");
                }
            }
        }
        public int FK_GEIDCardStateProvinceID
        {
            get { return _fK_GEIDCardStateProvinceID; }
            set
            {
                if (value != this._fK_GEIDCardStateProvinceID)
                {
                    _fK_GEIDCardStateProvinceID = value;
                    NotifyChanged("FK_GEIDCardStateProvinceID");
                }
            }
        }
        public int FK_GENationalityID
        {
            get { return _fK_GENationalityID; }
            set
            {
                if (value != this._fK_GENationalityID)
                {
                    _fK_GENationalityID = value;
                    NotifyChanged("FK_GENationalityID");
                }
            }
        }
        public int FK_GEReligionID
        {
            get { return _fK_GEReligionID; }
            set
            {
                if (value != this._fK_GEReligionID)
                {
                    _fK_GEReligionID = value;
                    NotifyChanged("FK_GEReligionID");
                }
            }
        }
        public int FK_MESpecialismID
        {
            get { return _fK_MESpecialismID; }
            set
            {
                if (value != this._fK_MESpecialismID)
                {
                    _fK_MESpecialismID = value;
                    NotifyChanged("FK_MESpecialismID");
                }
            }
        }
        public int FK_HRCommissionLevelID
        {
            get { return _fK_HRCommissionLevelID; }
            set
            {
                if (value != this._fK_HRCommissionLevelID)
                {
                    _fK_HRCommissionLevelID = value;
                    NotifyChanged("FK_HRCommissionLevelID");
                }
            }
        }
        public int FK_HRWorkingShiftID
        {
            get { return _fK_HRWorkingShiftID; }
            set
            {
                if (value != this._fK_HRWorkingShiftID)
                {
                    _fK_HRWorkingShiftID = value;
                    NotifyChanged("FK_HRWorkingShiftID");
                }
            }
        }
        public double HREmployeeTaxPaymentAmount
        {
            get { return _hREmployeeTaxPaymentAmount; }
            set
            {
                if (value != this._hREmployeeTaxPaymentAmount)
                {
                    _hREmployeeTaxPaymentAmount = value;
                    NotifyChanged("HREmployeeTaxPaymentAmount");
                }
            }
        }
        public double HREmployeeExtraGasolineVehicle
        {
            get { return _hREmployeeExtraGasolineVehicle; }
            set
            {
                if (value != this._hREmployeeExtraGasolineVehicle)
                {
                    _hREmployeeExtraGasolineVehicle = value;
                    NotifyChanged("HREmployeeExtraGasolineVehicle");
                }
            }
        }
        public double HREmployeeExtraResponsibility
        {
            get { return _hREmployeeExtraResponsibility; }
            set
            {
                if (value != this._hREmployeeExtraResponsibility)
                {
                    _hREmployeeExtraResponsibility = value;
                    NotifyChanged("HREmployeeExtraResponsibility");
                }
            }
        }
        public double HREmployeeExtraLunch
        {
            get { return _hREmployeeExtraLunch; }
            set
            {
                if (value != this._hREmployeeExtraLunch)
                {
                    _hREmployeeExtraLunch = value;
                    NotifyChanged("HREmployeeExtraLunch");
                }
            }
        }
        public double HREmployeeExtraHarmfullSubsidies
        {
            get { return _hREmployeeExtraHarmfullSubsidies; }
            set
            {
                if (value != this._hREmployeeExtraHarmfullSubsidies)
                {
                    _hREmployeeExtraHarmfullSubsidies = value;
                    NotifyChanged("HREmployeeExtraHarmfullSubsidies");
                }
            }
        }

        public string HREmployeeBacSi24x7Id
        {
            get { return _hrEmployeeBacSi24x7Id; }
            set
            {
                if (value != _hrEmployeeBacSi24x7Id)
                {
                    _hrEmployeeBacSi24x7Id = value;
                    NotifyChanged("HREmployeeBacSi24x7Id");
                }
            }
        }
        public byte[] HREmployeeSignature
        {
            get { return _hREmployeeSignature; }
            set
            {
                if (value != this._hREmployeeSignature)
                {
                    _hREmployeeSignature = value;
                    NotifyChanged("HREmployeeSignature");
                }
            }
        }
        public String HREmployeeShortSignature
        {
            get { return _hREmployeeShortSignature; }
            set
            {
                if (value != this._hREmployeeShortSignature)
                {
                    _hREmployeeShortSignature = value;
                    NotifyChanged("HREmployeeShortSignature");
                }
            }
        }
        public String HREmployeeStatusTKCombo
        {
            get { return _hREmployeeStatusTKCombo; }
            set
            {
                if (value != this._hREmployeeStatusTKCombo)
                {
                    _hREmployeeStatusTKCombo = value;
                    NotifyChanged("HREmployeeStatusTKCombo");
                }
            }
        }
        public int FK_HREmployeeStateID
        {
            get { return _fk_HREmployeeStateID; }
            set
            {
                if (value != this._fk_HREmployeeStateID)
                {
                    _fk_HREmployeeStateID = value;
                    NotifyChanged("FK_HREmployeeStateID");
                }
            }
        }
        #endregion







        #region Extra Properties
        public String HRDepartmentRoomName { get; set; }
        public String HRDepartmentName { get; set; }
        public String HRLevelName { get; set; }
        public String HREmployeeGender { get; set; }        

        [FormatGroup(FormatGroupAttribute.cstFormatGroupPrice)]
        public double TotalSaleAmount { get; set; }

        [FormatGroup(FormatGroupAttribute.cstFormatGroupQty)]
        public double TotalSaleQty { get; set; }

        //Salary
        public DateTime HREmployeeSalaryDate { get; set; }
        public double HREmployeeSalaryTotal { get; set; }
        public double HREmployeeSalaryCommission { get; set; }
        public double HREmployeeWorkingMonths  { get; set; }
        public String ADUserName { get; set; }        
        #endregion

    }
    #endregion
}