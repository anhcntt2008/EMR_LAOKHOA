using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOSCommon
{
    #region Common
    public enum Status
    {
        Alive,
        Delete,
        Dummy
    }

    public enum AddressType
    {
        Contact,
        Invoice,
        Delivery,
        Payment,
        Stock
    }

    public enum ObjectType
    {
        Customer,
        Supplier,
        Employee,
        Branch
    }
    public enum ObjectHistoryAction
    {
        Create,
        Change,
        Delete
    }
    public enum LabType
    {
        Lab,
        VitalSigns
    }
    public enum VisitLabStatus
    {
        InProgress,
        WaitForResult,
        Complete
    }
    public enum VisitLabSentToServerLabStatus
    {
        New,
        Sent,
        Complete
    }
    public enum ReportViewType
    {
        PrintViewer,
        Form
    }
    public enum TemplateType
    {
        PrimaryHeader,
        ProgressNote,
        Sub,
        Report
    }
    public enum MatchCodeMedicine
    {
        MEMedicationItemMatchCodeRoute,
        MEMedicationItemMatchCodeFrequence
    }
    public enum ObjectStatePermissionAction
    {
        View,
        Edit,
        Delete
    }
    #endregion

    #region Patient Visit
    public enum PatientVisitStatus
    {
        /// <summary>
        /// The patient has cancel for an appointment
        /// </summary>
        CancelReserved,

        /// <summary>
        /// The patient has registered for visit
        /// </summary>
        In,

        /// <summary>
        /// The patient is waiting for doing vital signs
        /// </summary>
        WaitingForVitalSigns,

        /// <summary>
        /// The patient is done vital signs
        /// </summary>
        DoingVitalSigns,

        /// <summary>
        /// The patient is waiting for cure
        /// </summary>
        WaitingForCure,

        /// <summary>
        /// The patient is curied
        /// </summary>
        Curing,

        /// <summary>
        /// Finished by main doctor
        /// </summary>
        Finished,

        /// <summary>
        /// The patient is waiting for taking payment for orders
        /// </summary>
        WaitingForPayment,

        /// <summary>
        /// The patient is taking payment for orders
        /// </summary>
        TakingPayment,

        /// <summary>
        /// The patient is waiting for doing labs
        /// </summary>
        WaitingForLabs,

        /// <summary>
        /// The patient is done labs
        /// </summary>
        DoingLabs,

        /// <summary>
        /// The patient is waiting for taking medication
        /// </summary>
        WaitingForMedication,

        /// <summary>
        /// The patient is taking medication
        /// </summary>
        TakingMedication,

        /// <summary>
        /// The patient has been out of the clinic
        /// </summary>
        Out,

        /// <summary>
        /// The patient has reserved for an appointment
        /// </summary>
        Reserved,

        /// <summary>
        /// The patient has registered for inpatient
        /// </summary>
        InPatient,

        /// <summary>
        /// The patient has transfered
        /// </summary>
        Transfer


    }
    public enum PackageItemType
    {
        Required,
        Optional
    }

    public enum PatientVisitSubType
    {
        Urgent,
        Normal
    }
    public enum PatientAppointmentStatus
    {
        Reserved,
        In,
        Out,
        Canceled
    }
    public enum LabParamStatus
    {
        Low,
        Normal,
        High
    }

    public enum Command
    {
        ProgressNote,
        Order,
        Letter,
        Medication,
        VitalSigns,
        HealthMaintenance,
        Pathology,
        NurseNote,
        XRay,
        ECG,
        Ultrasound,
        Endoscopy,
        CTScan,
        PatientDocument,
        BoneMineralDensity,
        RecentLab,
        LabTable,
        PatientGuide,
        CoronaryAngiogram,
        Document
    }

    public enum CommandType
    {
        Visit
    }

    public enum PatientVisitType
    {
        VIS,
        EC,
        GE,
        FU,
        RES,
        PAC,
        Sale,
        Customer,
        Purchasing,
        Staff,
        Inventory,
        Accounting,
        PrintedDocument,
        InPatient,
        Emergency
    }
    public enum VisitTemplateStatus
    {
        New,
        InProgress,
        WaitForResult,
        Complete
    }
    public enum VisitOrderItemStatus
    {
        Sent,
        Paid,
        InProgress,
        WaitForResult,
        Complete,
        NotPaid,
        NotBuy
    }

    public enum VisitOrderUrgency
    {
        Urgent,
        Routine,
        DoWithin
    }

    public enum VisitOrderStatus
    {
        /// <summary>
        /// The visit order has been just created
        /// </summary>
        Sent,

        /// <summary>
        /// The visit order has been paid
        /// </summary>
        Paid,
        /// <summary>
        /// The visit order has not-yet-paid item(s)
        /// </summary>
        HalfPaidBHYT,
        HalfPaidOrder,
        /// <summary>
        /// Return 
        /// </summary>
        NotBuy
    }
    public enum VisitMedicationStatus
    {
        /// <summary>
        /// The visit medication has been just created
        /// </summary>
        Sent,

        /// <summary>
        /// The visit medication has been paid
        /// </summary>        
        Paid,

        NotBuy
    }

    public enum VisitMedicationItemRemark
    {
        Available,
        Unavailable
    }

    public enum PatientHistoryType
    {
        TSBT,
        TSGD
    }

    #endregion

    #region Inventory
    /// <summary>
    /// Set of return values for inventory validation
    /// </summary>
    public enum InventoryStatus
    {
        Empty = 1,
        LessThanMinQty = 2,
        GreaterThanMaxQty = 3,
        Valid = 4
    }

    /// <summary>
    /// Set of inventory type
    /// </summary>
    public enum InventoryType
    {
        OnHand,
        SaleOrder,
        PurchaseOrder,
        Proposal,
        TransitIn,
        TransitOut,
        Maintenance
    }

    public enum TransactionType
    {
        Sale,
        Purchase,
        Other
    }

    public enum ReceiptType
    {
        PurchaseReceipt,
        ReturnReceipt,
        Receipt,
        EquipmentReceipt
    }

    public enum ReceiptItemType
    {
        MultiPackage,
        MultiProduct,
        MultiPackageProduct
    }
    public enum ReceiptStatus
    {
        New,
        Complete
    }

    public enum ShipmentType
    {
        SaleShipment,
        PresentingShipment,
        ReturnShipment,
        Shipment,
        EquipmentShipment,
        EquipmentIncreasing,
        EquipmentDecreasing
    }

    public enum ShipmentStatus
    {
        /// <summary>
        /// Shipment has been created
        /// </summary>
        New,

        /// <summary>
        /// Shipment has been completed, its items have been shipped out of inventory
        /// </summary>
        Complete,

        Return,

        //Đã phát thuốc
        MedicationTransfer,

        //Hủy phát thuốc
        MedicationCancel

    }

    public enum StockType
    {
        Sale,
        Purchase,
        Central,
        TransitIn,
        TransitOut,
        Maintenance,
        SaleOrder,
        SaleOff,
        Damaged
    }

    public enum TransferType
    {
        Transfer,
        TransferReceipt
    }

    public enum TransferStatus
    {
        New,
        Post,
        Incomplete,
        Complete
    }

    public enum TransferProposalStatus
    {
        New,
        Approved,
        Complete,
        Cancel
    }

    public enum ProductDepreciationMethod
    {
        Once,
        Many
    }
    public enum InventoryStockCountStatus
    {
        New,
        Checked
    }
    public enum InventoryEstimateStatus
    {
        New,
        Complete
    }
    #endregion

    #region Human Resources
    public enum EmployeeStatus
    {
        Working,
        Resigned
    }

    public enum EmployeeStatusTK
    {
        Active,
        InActive
    }

    public enum DepartmentStatus
    {
        Active,
        InActive
    }

    public enum TimeSheetType
    {
        Day,
        Hour,
        Common
    }

    public enum TimeSheetStatus
    {
        New,
        SalaryCalculated
    }

    public enum TimeSheetParamType
    {
        Day,
        Hour,
        Common
    }

    public enum PayRollType
    {
        Day,
        Hour
    }

    public enum PayRollStatus
    {
        New,
        Posted
    }

    public enum CalculatedSalaryType
    {
        Basic,
        Working
    }

    public enum CalendarType
    {
        Holiday
    }


    public enum MailPriority
    {
        VeryImportant,
        High,
        Normal,
        Low
    }
    public enum MailType
    {
        Inbox,
        SentItem
    }

    public enum OTFactorType
    {
        Holiday,
        EndOfWeek,
        WorkingDay
    }
    public enum AttachmentFileType
    {
        KB,
        MB
    }
    public enum LeaveDaysType
    {
        Annual,
        Sick,
        Birth,
        OT,
        Normal
    }
    public enum TrainningEmployee
    {
        Teacher,
        Student
    }
    public enum EmployeeEvaluationType
    {
        Evaluating,
        Evaluated
    }

    public enum RewardType
    {
        Percent,
        Amount,
        Other
    }

    public enum DisciplineType
    {
        Percent,
        Amount,
        WorkDay,
        Other
    }

    public enum AllowanceType
    {
        Percent,
        Amount,
        GasolineVehicle,
        Responsibility,
        Lunch,
        Other
    }

    public enum EvaluationStatus
    {
        New,
        InProgress,
        Closed,
    }

    public enum HRDayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    public enum AdvanceRequestStatus
    {
        New,
        Complete,
        Advanced,
    }
    public enum VOSubItemType
    {
        NeedCharge,
        NoNeedCharge
    }
    public enum EmployeeContractDeductionType
    {
        Yes,
        No
    }
    #endregion

    #region Sale
    public enum CustomerType
    {

        Patient,
        Insuarance,
        Employer,
        Personal,
        Company,
        BN,
        BH,
        Temp

    }

    public enum PriceLevel
    {
        Regular,
        VIP,
        Employee,
        WholeSale
    }

    public enum PaymentMethod
    {
        Cash,
        EFTPOS,
        Check,
        CreditCard,
        Account,
        CreditNote,
        GiftVoucher,
        BankTransfer,
        PaymentOrder,
        CashSec,
        TransferSec,
        OwingExchange,
        DepositTransfer,
        DepositExchange
    }

    public enum InvoiceType
    {
        SaleReceipt,
        GiftReceipt,
        SaleOrder,
        SaleReturn,
        SwapAndMaintainance,
        ServiceReceipt,
        MedicationReceipt,
        DrugInvoice
    }

    public enum ProductType
    {
        Product,
        Component,
        Equipment,
        Medicine,
        Service,
        Package
    }
    public enum PackageCostingMethod
    {
        ServicePrice,
        RatioServicePrice,
        Package
    }

    public enum RoomBedStatus
    {
        Available,
        InUse,
        HouseKeeping,
        Maintained
    }

    public enum InvoiceStatus
    {
        /// <summary>
        /// The invoice has been created
        /// </summary>
        New,

        /// <summary>
        /// The invoice has been completed and can not modify
        /// </summary>
        Complete,

        /// <summary>
        /// The invoice has been paid
        /// </summary>
        Paid,

        //Đã phát thuốc
        MedicationTransfer,

        //Hủy phát thuốc
        MedicationCancel,

        //Hủy phát thuốc và hoàn trả
        Return,

        //Sửa sau hoàn tất
        EditAfterComplete
    }

    public enum SaleOrderType
    {
        LayBy,
        SaleOrder
    }

    public enum SaleOrderStatus
    {
        /// <summary>
        /// Sale order has been created, wait for approval
        /// </summary>
        New,

        /// <summary>
        /// Sale order has been approved, wait for customer's confirmation
        /// </summary>
        Approved,

        /// <summary>
        /// Sale order has been confirmed by customer, wait for shipment
        /// </summary>
        Confirmed,

        /// <summary>
        /// Sale order has been canceled by customer
        /// </summary>
        Canceled,

        /// <summary>
        /// Sale order has been invoiced, but still has no full shipment
        /// </summary>
        Incomplete,

        /// <summary>
        /// Sale order has been shipped
        /// </summary>
        Shipped
    }

    public enum CustomerPaymentType
    {
        Deposit,
        SaleReceipt,
        SaleOrder,
        Repaid,
        DepositExchange,
        DepositTransfer,
        OwingExchange
    }

    public enum PaymentType
    {
        Deposit,
        SaleReceipt,
        SaleOrder
    }

    public enum EmployeeComissionStatus
    {
        New,
        Complete
    }

    public enum SaleReturnStatus
    {
        /// <summary>
        /// The sale return has been created
        /// </summary>
        New,

        /// <summary>
        /// The sale return has been completed
        /// </summary>
        Complete
    }

    public enum CancelVoucherStatus
    {
        /// <summary>
        /// The cancel voucher has been created
        /// </summary>
        New
    }

    public enum CreditNoteType
    {
        CreditNote,
        GiftVoucher
    }

    public enum ReceiptVoucherType
    {
        Receipt,
        CustomerPayment,
        Deposit
    }

    public enum SwapAndMaintainanceStatus
    {
        New,
        Complete
    }

    #endregion

    #region Purchase    
    public enum InvoiceInType
    {
        PurchaseReceipt,
        Return
    }

    public enum InvoiceInStatus
    {
        New,
        Completed,
        Incompleted
    }

    public enum PurchaseOrderStatus
    {
        New,
        Confirmed,
        Canceled,
        Completed,
        Incompleted,
        Packaged
    }

    public enum PurchaseOrderType
    {
        SaleOrder,
        Inventory,
        Maintenance
    }

    public enum PurchaseProposalStatus
    {
        New,
        Confirmed,
        Canceled,
        Approved
    }

    public enum PurchaseProposalType
    {
        SaleOrder,
        Inventory,
        Operating
    }

    public enum PurchaseProposalItemStatus
    {
        New,
        Confirmed,
        Canceled,
        Approved,
        Purchased
    }

    public enum ProductBranchPriceType
    {
        Sale,
        Purchase
    }

    public enum SupplierPaymentType
    {
        SupplierPayment
    }

    public enum PaymentVoucherType
    {
        Payment,
        SupplierPayment,
        CustomerRepaid
    }
    #endregion

    #region Bank Transaction
    public enum BankTransactionType
    {
        BankTransfer,
        PaymentOrder,
        PaymentCash
    }
    #endregion

    #region Accounting
    public enum AccDocumentType
    {
        #region Sale
        BanHangCongNo,
        BanLe,
        BanDichVu,
        HangBanTraLai,
        PhieuTangHang,
        #endregion

        #region Purchase
        MuaHangCongNo,
        ThanhToanPhi,
        #endregion

        #region Bank Transaction
        NopTienVaoTaiKhoan,
        UyNhiemChi,
        SecTienMat,
        #endregion

        #region Inventory
        XuatKhoBanHang,
        XuatKho,
        XuatKhoTangHang,
        NhapKhoMuaHangHoaDon,
        NhapKhoMuaHang,
        NhapKhoHangTra,
        NhapKho,
        #endregion

        #region Budget
        PhieuThu,
        PhieuChi,
        #endregion

        #region Human Resources
        HachToanLuong,
        #endregion

        #region Asset
        TangTSCD,
        GiamTSCD,
        DieuChuyenTSCD,
        #endregion

        #region Equipment
        NhapCCDC,
        XuatCCDC,
        DieuChuyenCCDC,
        TangCCDC,
        GiamCCDC,
        #endregion

        #region General
        NghiepVuKhac,
        PhanBoChiPhi,
        KhauTruThue,
        TinhThueTNDN,
        XacDinhKQKD,
        DanhGiaNgoaiTe,
        ChenhLechTyGia,
        KhauHaoTSCD,
        PhanBoCCDC
        #endregion        
    }

    public enum AccEntryType
    {
        #region Sale        
        DoanhThuBanHang,
        DoanhThuChuaThucHien,
        ChietKhauThuongMai,
        GiamGiaHangBan,
        ThueGTGTPhaiNop,
        ThuChietKhauHangTra,
        HangBanTraLai,
        #endregion

        #region Purchase
        PhaiTraNguoiBan,
        ChiPhiMuaHang,
        ThueGTGTDuocKhauTru,
        #endregion

        #region Inventory
        NhapKhoMuaHang,
        NhapKhoHangTra,
        NhapKhoDieuChinh,
        XuatKhoBanHang,
        XuatKhoDieuChinh,
        XuatKhoTangHang,
        #endregion

        #region Budget        
        ThuTienKhachHang,
        ThuTienUngTruoc,
        TraTienKhachHang,
        TraTienNCC,
        #endregion

        #region Bank
        NopTienNganHang,
        #endregion

        #region Human Resources
        LuongNhanVien,
        BHXHNhanVienDong,
        BHXHDoanhNghiepDong,
        BHTNNhanVienDong,
        BHTNDoanhNghiepDong,
        BHYTNhanVienDong,
        BHYTDoanhNghiepDong,
        PhiCongDoanNVDong,
        PhiCongDoanDNDong,
        ThueTNCN,
        #endregion

        #region Asset
        TangTSCD,
        GiamTSCDHaoMon,
        GiamTSCDGiaTriConLai,
        #endregion

        #region Equipment
        NhapCCDC,
        XuatCCDC,
        XuatCCDCPhanBo,
        GhiGiamCCDC,
        #endregion

        #region General
        PhanBoChiPhiMuaHang,
        KhauTruThueGTGT,
        TinhThueTNDN,
        KetChuyenGiaVon,
        KetChuyenChiPhiBanHang,
        KetChuyenChiPhiQLDN,
        KetChuyenChiPhiTaiChinh,
        KetChuyenChiPhiKhac,
        KetChuyenChiPhiThueTNDN,
        KetChuyenCKTM,
        KetChuyenGiamGiaHangBan,
        KetChuyenHangBanTraLai,
        KetChuyenDoanhThuBanHang,
        KetChuyenDoanhThuTaiChinh,
        KetChuyenThuNhapKhac,
        KetChuyenLaiLo,
        DanhGiaNgoaiTe,
        ChenhLechTyGia,
        KhauHaoTSCD,
        PhanBoCCDC,
        PhanBoChiPhiTraTruoc,
        #endregion

        #region Other
        CanTruCongNoNCC,
        CanTruCoc,
        ThuPhieuGhiCo,
        ThuCocBangPhieuGhiCo,
        ThuTheTinDung,
        ThuCocBangTheTinDung
        #endregion
    }

    public enum AccAccountType
    {
        DebitBalance,
        CreditBalance,
        DebitCreditBalance,
        NoBalance
    }

    public enum AccPostingType
    {
        Credit,
        Debit
    }

    public enum AccCostMethod
    {
        SpecificIdentification,
        ContinuousWeightedAverage,
        PeriodicWeightedAverage
    }

    public enum AccountType
    {
        DebitBalance,
        CreditBalance,
        DebitCreditBalance,
        NoBalance
    }

    public enum AccountPostingRule
    {
        IncreasingByDebit,
        IncreasingByCredit
    }

    public enum AssetStatus
    {
        Purchased,
        Using,
        UsingWithoutDepreciation,
        Shipped
    }

    public enum AssetDepreciationMethod
    {
        StraightLine
    }

    public enum EquipmentDepreciationMethod
    {
        Once,
        Many
    }
    #endregion

    #region Data Exchange
    public enum DataExchangeStatus
    {
        New,
        Posting,
        Complete,
        Failed
    }

    public enum DataExchangeType
    {
        Inventory,
        Sale,
        Customer,
        Purchase,
        Accounting,
        HumanResource,
        AccountInitData,
        UsingCashDrawerHistory,
        InventoryStockCounts,
        SwapAndMaintainance
    }

    /// <summary>
    /// Set of report type
    /// </summary>
    public enum ReportType
    {
        Sale,
        Customer,
        Purchasing,
        Staff,
        Inventory,
        Accounting,
        PrintedDocument
    }

    public enum BranchType
    {
        Central,
        Branch
    }
    public enum ARCustomerPaymentType
    {
        Deposit,
        SaleOrder,
        Repaid,
        SaleReceipt
    }
    #endregion
    public enum PatientTypeHospi
    {
        InPatient,
        OutPatient
    }
    public enum QuarterInYear
    {
        I,
        II,
        III,
        IV
    }

    public enum InsLevelType
    {
        PaymentPercent,
        AccompaniedItem
    }

    public enum CommandPermissionType
    {
        None = 0,
        Hided = 1
    }

    public enum CompanyType
    {
        Insuarance,
        Employer,
        BHYT
    }

    public enum SalaryType
    {
        Basic,
        Working
    }

    public enum UsingHistoryType
    {
        LogIn,
        LogOut,
        TurnOff
    }
    public enum PatientInsPlaceLevelType
    {
        LevelI,
        LevelII,
        LevelIII
    }
    public enum PatientVisitHealthInsuranceLine
    {
        InLine,
        ExtLine
    }
    public enum CHBaseFileType
    {
        ProgressNote = 1,
        MedicalInsuranceCard = 2,
        ImagingLabResult = 3,
        OtherFile = 4,
        MedicalHistory = 5
    }

    public enum LoaiBHYT
    {
        HsKcb = 3,
        Hs7980A = 5,
        Hs19 = 6,
        Hs20 = 7,
        Hs21 = 8,
        HsGiayChuyenTuyen = 9
    }

    #region EMR-UTHV
    public enum EmrParamTypes
    {
        Single,
        List
    }
    public enum EmrParamListTypes
    {
        Vertical,
        Horizontal
    }
    public enum EmrParamControlTypes
    {
        Textbox,
        DatePicker,
        Radio,
        Checkbox
    }
    public enum EmrParamFormatTypes
    {
        Number,
        Date,
        DateTime,
        Boolean,
        Barcode,
        QRCode,
        Symbol,
        Image,
        ImageRotate90,
        Rtf
    }
    // future update more
    public enum EmrParamMaps
    {
        MEParamLookupDataKey,
        MEParamLookupDataValue,
        MEParamLookupDataText,
        MEParamLookupDataGroup
    }
    public enum EmrParamModes
    {
        Report
    }
    public enum EmrActionTypes
    {
        Sql,
        Api,
        App,
        Replace,
        Assign,
        RemoteCase,
        AddRow,
        AddCol,
        Hard,
        Composition,
        Lookup,
        AutoAddDoc,
        AddExtFileSharedDoc,
        SubTemplate,
        AutoValue,
        AddImageFileShared,
        DinamapProV100,
        DataPlugin,
        CalcPlugin,
        OpenWebBrowser
    }
    public enum EmrActionDataTypes
    {
        Xml,
        Json,
    }
    public enum EmrStatus
    {
        InProgress,
        Signed,
        Closed,
        Initing,
        BackToDept,
        Return,
        WaitToClose,
        WaitClose,
        Approved,
        WaitApprove
    }
    public enum EmrDocumentStatus
    {
        InProgress,
        Signed,
        Closed,
        Hidden,
        Discarded
    }
    public enum EmrActionScopes
    {
        Document,
        Emr,
        Patient,
        Department,
        All,
        DocumentBeforeSaving
    }
    public enum EmrDocumentFileExtention
    {
        docx,
        pdf,
        jpg
    }
    public enum ParamFormatType
    {
        Number,
        Date,
        DateTime,
        Time
    }
    public enum MongoFilter
    {
        Eq,
        Ne,
        Nin
    }

    public enum TemplateShareMode
    {
        privated,
        department,
        open
    }
    public enum UserGroupRole
    {
        admin,
        nurse,
        doctor
    }
    public enum EmrTemplateActionWhen
    {
        Init,
        Open,
        Save,
        Print,
        HisUpdated,
        Checkup,
        Manual
    }
    public enum EmrTemplateActionDo
    {
        UpdateEmr,
        UpdateDoc,
        AskUpdateEmr,
        AskUpdateDoc,
        Notify
    }

    public enum EmrTypeProfile
    {
        Patient,
        In,
        Out
    }
    public enum HttpMethod
    {
        POST,
        GET
    }

    public enum EmrDocumentSignType
    {
        Signed,
        FingerPrintSigned,
        Unsigned,
        DigitalSigned
    }
    public enum EmrArchiveStatus
    {
        Archived,
        DigitalSigned
    }

    public enum EmrArchiveBackupStatus
    {
        Scheduled,
        Uploaded,
        Failed
    }

    public enum EmrTypeActionWhen
    {
        Init,
        Open,
        Save,
        Print,
        HisUpdated,
        Checkup
    }
    public enum EmrTypeActionDo
    {
        UpdateEmr,
        UpdateDoc,
        AskUpdateEmr,
        AskUpdateDoc,
        Notify
    }


    public enum EmrShareHistoryMode
    {
        Edit,
        Read
    }

    public enum EmrMergeHistoryStatus
    {
        Merge,
        Rollback,
        MergeError,
        RollbackError
    }

    public enum EmrSumStatus
    {
        Hide,
        Active
    }

    public enum EmrSumXMLStatus
    {
        None,
        Exported,
        Error,
        Sent,
        Fail
    }
    #endregion

    #region MIDDLE
    public enum AutoGenDocumentStatus
    {
        SCHEDULED,
        CREATING,
        CREATED,
        RETRYING,
        DISCARDED
    }
    public enum AutoSignDocumentStatus
    {
        SCHEDULED,
        SIGNING,
        SIGNED,
        RETRYING,
        DISCARDED
    }
    public enum EmrDocumentBgJobStatus
    {
        Initing,
        Created,
        CreatedWithErr
    }
    #endregion
}
