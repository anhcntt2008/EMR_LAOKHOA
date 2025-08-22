using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BOSCommon;
using BOSLib;
using Clas.Model.Doctor24x7;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using BOSBase;
using static System.String;
using FluentFTP;
using Ionic.Zip;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using BOSLib.DataAccess;
using Localization;
using Emr;
using Clas.Business.Ftp;
using DPUruNet;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BOSERP
{
    /// <summary>
    ///     BOSApp is the main class which manage all module,screens of BOS System
    /// </summary>
    public partial class BOSApp
    {
        #region Constants
        public const int UserGroupAdmin = 1;
        #endregion

        #region Static variables for BOS Application
        public static int NumOfOpenedModules = 5;
        public static String CurrentModule = Empty;
        public static GUIMain MainScreen;

        public static System.Windows.Forms.Form ActiveScreen;
        public static String CurrentLang;
        public static String CurrentUser;

        public static SortedList OpenModules = new SortedList();
        public static Assembly EmrAssembly;
        public static bool IsLoginBacSi24X7 = false;
        public static bool _isFirstLogin = true;
        public static bool _isLoginByHIS = false;

        private static int _currentUserGroupID;
        private static ADUsersInfo _currentUsersInfo;
        private static ADUserGroupsInfo _currentUserGroupsInfo;

        private static CSCompanysInfo _currentCompanyInfo;
        private static BRBranchsInfo _currentBranchInfo;
        public static ImageList ToolbarImageList = new ImageList();
        public static ImageList SectionImageList = new ImageList();
        public static Thread LoadingThread;
        public static ManualResetEvent _hisWaitHandle = new ManualResetEvent(false);
        private static SortedList _lookupTables;
        private static SortedList _lookupTableUpdatedDate;

        private static SortedList _fieldFormatGroups;
        private static int _priceDecimal = 2;
        private static List<ADDataViewPermissionsInfo> _currentDataViewPermissionList;

        private static SignalHubClient _signalHubClient;// = new SignalHubClient();
        private static List<IModel> ListModel = new List<IModel>();
        private static IModel _channelLogOffQueue;

        #endregion

        #region Properties
        public static ADUsersInfo CurrentUsersInfo
        {
            get
            {
                return _currentUsersInfo == null ? new ADUsersInfo() : _currentUsersInfo;
            }
            set
            {
                _currentUsersInfo = value;
            }
        }

        public static ADUserGroupsInfo CurrentUserGroupInfo
        {
            get
            {
                return _currentUserGroupsInfo == null ? new ADUserGroupsInfo() : _currentUserGroupsInfo;
            }
        }

        public static BRBranchsInfo CurrentBranchInfo
        {
            get
            {
                return _currentBranchInfo;
            }
            set
            {
                _currentBranchInfo = value;
            }
        }

        public static CSCompanysInfo CurrentCompanyInfo
        {
            get
            {
                return _currentCompanyInfo;
            }
            set
            {
                _currentCompanyInfo = value;
            }
        }

        public static SortedList LookupTables
        {
            get
            {
                return _lookupTables;
            }
            set
            {
                _lookupTables = value;
            }
        }
        public static SortedList LookupTablesUpdatedDate
        {
            get
            {
                return _lookupTableUpdatedDate;
            }
            set
            {
                _lookupTableUpdatedDate = value;
            }
        }

        public static SortedList FieldFormatGroups
        {
            get
            {
                return _fieldFormatGroups;
            }
            set
            {
                _fieldFormatGroups = value;
            }
        }

        public static int PriceDecimal
        {
            get
            {
                return _priceDecimal;
            }

            set
            {
                _priceDecimal = value;
            }
        }
        public static List<ADDataViewPermissionsInfo> CurrentADDataViewPermissionList
        {
            get
            {
                return _currentDataViewPermissionList;
            }
            set
            {
                _currentDataViewPermissionList = value;
            }
        }
        /// <summary>
        /// Gets or sets the list of lookup table objects
        /// </summary>
        public static SortedList<string, GELookupTablesInfo> LookupTableObjects { get; set; }

        /// <summary>
        /// Gets or sets the the current language
        /// </summary>
        public static GELanguagesInfo CurrentLanguage { get; set; }

        public static List<ADUserGroupExtrasInfo> CurrentUsersExtraGroups { get; set; }

        public static HRDepartmentsInfo CurrentDepartmentInfo { get; set; }

        public static List<ADUserFingerprintsInfo> UserFingerprints;
        public static List<ADUserFingerprintsZKTecoInfo> UserFingerprintsZKTeco;
        public static Dictionary<int, Fmd> UserFingerprintFmds;

        #endregion

        #region Constant
        public const String cstTopResultsSearchControl = "fld_txtTopResults";
        public const int cstTopResults = 10000;
        #endregion

        public static void SetAppLanguage(int languageID)
        {
            var objLanguagesController = new GELanguagesController();
            var objLanguagesInfo = (GELanguagesInfo)objLanguagesController.GetObjectByID(languageID);
            if (objLanguagesInfo != null)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(objLanguagesInfo.GELanguageCultur);
                CurrentLanguage = objLanguagesInfo;
            }
        }
        /// <summary>
        ///     Get first object from lookup table
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <returns>First object</returns>
        public static object GetFirstObjectFromLookupTable(string tableName)
        {
            var controller = BusinessControllerFactory.GetBusinessController(tableName + "Controller");
            if (controller != null)
            {
                var ds = (DataSet)LookupTables[tableName];
                if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                    return controller.GetObjectFromDataRow(ds.Tables[0].Rows[0]);
            }
            return null;
        }
        public static List<T> GetObjectsFromLookupTable<T>(string tableName)
        {
            var list = new List<T>();
            if (!LookupTables.ContainsKey(tableName))
                InitLookupByTable(tableName);
            var controller = BusinessControllerFactory.GetBusinessController(tableName + "Controller");
            if (controller != null)
            {
                var ds = (DataSet)LookupTables[tableName];
                if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        list.Add((T)controller.GetObjectFromDataRow(row));
                    }
                return list;
            }
            return null;
        }
        /// <summary>
        ///     Get the end date of a previous period by a current document date
        /// </summary>
        /// <param name="documentDate">Document date</param>
        /// <returns>End date of the previous period</returns>
        public static DateTime GetPreviousPeriodEndDate(DateTime documentDate)
        {
            var startMonth = CurrentCompanyInfo.CSCompanyStartMonth;
            var reportPeriod = CurrentCompanyInfo.CSCompanyReportPeriod;
            while (startMonth + reportPeriod - 1 < documentDate.Month)
            {
                startMonth += reportPeriod;
                if (startMonth > 12)
                    startMonth -= 12;
            }
            var endDate = documentDate.AddMonths(startMonth + reportPeriod - 1 - documentDate.Month);
            endDate = endDate.AddMonths(-reportPeriod);
            endDate = BOSUtil.GetMonthEndDate(endDate);
            return endDate;
        }

        /// <summary>
        ///     Get the start date of a period by a current document date
        /// </summary>
        /// <param name="documentDate">Document date</param>
        /// <returns>Start date of the period</returns>
        public static DateTime GetPeriodStartDate(DateTime documentDate)
        {
            var prevPeriodEndDate = GetPreviousPeriodEndDate(documentDate);
            return prevPeriodEndDate.AddDays(1);
        }

        /// <summary>
        ///     Get the end date of a period by a current document date
        /// </summary>
        /// <param name="documentDate">Document date</param>
        /// <returns>End date of the period</returns>
        public static DateTime GetPeriodEndDate(DateTime documentDate)
        {
            var startDate = GetPeriodStartDate(documentDate);
            return BOSUtil.GetMonthEndDate(startDate.AddMonths(CurrentCompanyInfo.CSCompanyReportPeriod - 1));
        }

        /// <summary>
        ///     Check whether a day is end of week
        /// </summary>
        /// <param name="dayOfWeek">Given day</param>
        /// <returns>True if the day is end of week, otherwise false</returns>
        public static bool IsEndOfWeek(DayOfWeek dayOfWeek)
        {
            if (dayOfWeek.Equals(DayOfWeek.Sunday))
                return true;
            return false;
        }

        /// <summary>
        ///     Check whether a date is a holiday
        /// </summary>
        /// <param name="date">Given date</param>
        /// <returns>True if the date is a holiday, otherwise false</returns>
        public static bool IsHoliday(DateTime date)
        {
            var objCalendarEntrysInfo = new HRCalendarEntrysInfo();
            var objCalendarEntrysController = new HRCalendarEntrysController();
            var entries =
                objCalendarEntrysController.GetCalendarEntryByDateAndCalenderType(CalendarType.Holiday.ToString(), date,
                    date);
            foreach (var entry in entries)
                if (date.Day == entry.HRCalendarEntryDate.Day)
                    return true;
            return false;
        }

        /// <summary>
        ///     Get the current server date
        /// </summary>
        /// <returns>Current server date</returns>
        public static DateTime GetCurrentServerDate()
        {
            var dbUtil = new BOSDbUtil();
            return dbUtil.GetCurrentServerDate();
        }

        public static double RoundingAmount(double amount, int round)
        {
            var r = amount % (1 * round);
            amount = amount - r;
            return amount;
        }

        /// <summary>
        ///     Check Changed
        /// </summary>
        /// <param name="oldObject">Old object</param>
        /// <param name="newObject">New object</param>
        /// <returns>true/false </returns>
        public static bool CheckChanged(BusinessObject oldObject, BusinessObject newObject)
        {
            object oldValue;
            object newValue;

            var props = oldObject.GetType().GetProperties();
            var tableName = BOSUtil.GetTableNameFromBusinessObject(oldObject);
            foreach (var propInfo in props)
                if (propInfo.Name.Substring(0, 2) != "AA")
                    if (propInfo.GetType() != typeof(byte[]))
                    {
                        var bosDbUtil = new BOSDbUtil();
                        newValue = bosDbUtil.GetPropertyValue(newObject, propInfo.Name);
                        oldValue = bosDbUtil.GetPropertyValue(oldObject, propInfo.Name);
                        if ((oldValue != null) && (newValue != null))
                            if (!oldValue.Equals(newValue))
                                return true;
                    }
            return false;
        }

        public static string RegenRandomPassword(int length)
        {
            const string charsALL = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            var randomIns = new Random();

            var rndChars = Enumerable.Range(0, length)
                            .Select(_ => charsALL[randomIns.Next(charsALL.Length)])
                            .ToArray();
            rndChars[randomIns.Next(rndChars.Length)] = "0123456789"[randomIns.Next(10)];

            return new string(rndChars);
        }

        #region Public Functions

        /// <summary>
        ///     Init Main Form Title
        /// </summary>
        private static void InitMainFormTitle(string company, string hRDepartmentName)
        {
            var title = "EMR " + FileVersion;
            title += " - " + company;
            title += " - " + CurrentUser;
            title += "/" + hRDepartmentName;
            MainScreen.Text = title;
        }

        public static void InitLookupTables()
        {
            LookupTables = new SortedList();
            LookupTablesUpdatedDate = new SortedList();
            LookupTables.Clear();
            LookupTablesUpdatedDate.Clear();
            LookupTableObjects = new SortedList<string, GELookupTablesInfo>();

            var dbUtil = new BOSDbUtil();
            var objGELookupTablesController = new GELookupTablesController();
            var dsLookupTables = objGELookupTablesController.GetAllObjects();
            if (dsLookupTables.Tables.Count > 0)
                foreach (DataRow rowLookupTable in dsLookupTables.Tables[0].Rows)
                {
                    var objGELookupTablesInfo =
                        (GELookupTablesInfo)objGELookupTablesController.GetObjectFromDataRow(rowLookupTable);
                    if (objGELookupTablesInfo != null)
                    {
                        if (!LookupTableObjects.ContainsKey(objGELookupTablesInfo.GELookupTableName))
                            LookupTableObjects.Add(objGELookupTablesInfo.GELookupTableName, objGELookupTablesInfo);
                        if (dbUtil.IsExistTable(objGELookupTablesInfo.GELookupTableName))
                        {
                            _lookupTableUpdatedDate.Add(objGELookupTablesInfo.GELookupTableName, DateTime.Now);
                        }

                        var ds = GetLookupTableData(objGELookupTablesInfo.GELookupTableName);
                        LookupTables.Add(objGELookupTablesInfo.GELookupTableName, ds);
                    }
                }
        }
        private static object LookupTableObjectsLock = new object();
        private static object LookupTablesUpdatedDateLock = new object();
        private static object LookupTablesLock = new object();

        public static DataSet InitLookupByTable(string table)
        {
            var dbUtil = new BOSDbUtil();
            var objGELookupTablesController = new GELookupTablesController();
            var objGELookupTablesInfo = (GELookupTablesInfo)objGELookupTablesController.GetObjectByName(table);
            if (objGELookupTablesInfo == null)
            {
                return null;
            }
            lock (LookupTableObjectsLock)
            {
                if (!LookupTableObjects.ContainsKey(objGELookupTablesInfo.GELookupTableName))
                    LookupTableObjects.Add(objGELookupTablesInfo.GELookupTableName, objGELookupTablesInfo);
            }
            lock (LookupTablesUpdatedDateLock)
            {
                if (dbUtil.IsExistTable(objGELookupTablesInfo.GELookupTableName))
                    if (!LookupTablesUpdatedDate.ContainsKey(objGELookupTablesInfo.GELookupTableName))
                        LookupTablesUpdatedDate.Add(objGELookupTablesInfo.GELookupTableName, dbUtil.GetCurrentServerDate());
            }
            lock (LookupTablesLock)
            {
                var ds = GetLookupTableData(objGELookupTablesInfo.GELookupTableName);
                if (!LookupTables.ContainsKey(objGELookupTablesInfo.GELookupTableName))
                    LookupTables.Add(objGELookupTablesInfo.GELookupTableName, ds);
            }
            return (DataSet)LookupTables[objGELookupTablesInfo.GELookupTableName];
        }
        public static void UpdateLookupTables(IBaseModuleERP module, string strLookupTable)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            if (LookupTables[strLookupTable] != null)
            {
                var dsTemp = (DataSet)BOSApp.LookupTables[strLookupTable];
                var primaryKey = SqlDatabaseHelper.GetPrimaryKeyColumn(strLookupTable);
                var maxKeyVal = 0;
                if (dsTemp.Tables.Count > 0)
                {
                    maxKeyVal = (int)dsTemp.Tables[0].Compute($"MAX([{primaryKey}])", "");
                }
                var dtLastModifyDate = dbUtil.GetDateMofifyOfTableByMaxId(strLookupTable, primaryKey, maxKeyVal);
                if (dtLastModifyDate.CompareTo(((DateTime)LookupTablesUpdatedDate[strLookupTable])) > 0)
                {
                    //Refesh Data Source
                    BaseBusinessController objLookupTableController = BusinessControllerFactory.GetBusinessController(strLookupTable + "Controller");
                    if (objLookupTableController != null)
                    {
                        DataSet ds = module.GetLookupTableData(strLookupTable);
                        if (ds.Tables.Count > 0)
                        {
                            // Update Last Updated Date of Lookup Table
                            LookupTablesUpdatedDate[strLookupTable] = DateTime.Now;
                            ((DataSet)LookupTables[strLookupTable]).Tables.Clear();
                            ((DataSet)LookupTables[strLookupTable]).Tables.Add(ds.Tables[0].Copy());
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Get data of a lookup table
        /// </summary>
        /// <param name="lookupTableName">Lookup table name</param>
        /// <returns>Data of the lookup table</returns>
        public static DataSet GetLookupTableData(string lookupTableName)
        {
            var objBusinessController = BusinessControllerFactory.GetBusinessController(lookupTableName + "Controller");
            var ds = new DataSet();
            if (objBusinessController != null)
                switch (lookupTableName)
                {
                    case TableName.MEPatientsTableName:
                        {
                            ds = ((MEPatientsController)objBusinessController).GetForLookupEdit();
                            break;
                        }
                    case TableName.ARCustomersTableName:
                        {
                            ds = ((ARCustomersController)objBusinessController).GetCustomerForLookupEdit();
                            InitAdditionalCustomerData(ds.Tables[0]);
                            break;
                        }
                    case TableName.ICStocksTableName:
                        {
                            ds = objBusinessController.GetAllObjects();
                            InitAdditionalStockData(ds.Tables[0]);
                            break;
                        }
                    case TableName.ICProductsTableName:
                        {
                            //var objProductsController = new ICProductsController();
                            ds = (objBusinessController as ICProductsController).GetProductsForLookupEdit();
                            if (ds.Tables.Count > 0)
                            {
                                ds.Tables[0].Columns.Add("LookupInfo");
                                foreach (DataRow row in ds.Tables[0].Rows)
                                    row["LookupInfo"] = Format("{0} {1} {2} {3}",
                                        row["ICProductBarCode"],
                                        row["ICProductNo"],
                                        row["ICProductSupplierNumber"],
                                        row["ICProductDesc"]);
                            }
                            break;
                        }
                    case TableName.HREmployeesTableName:
                        {
                            //var employeesController = new HREmployeesController();
                            ds = (objBusinessController as HREmployeesController).GetEmployeesForLookupEdit();
                            break;
                        }

                    case TableName.MEPatientVisitsTableName:
                        {
                            //var mePatientVisitsController = new MEPatientVisitsController();
                            ds = (objBusinessController as MEPatientVisitsController).GetPatientVisitsForLookupEdit();
                            break;
                        }
                    case TableName.MECompanysTableName:
                        {
                            // var companysController = new MECompanysController();
                            ds = (objBusinessController as MECompanysController).GetCompanysForLookupEdit();
                            break;
                        }
                    case TableName.MEVisitOrdersTableName:
                        {
                            //var meVisitOrdersController = new MEVisitOrdersController();
                            ds = (objBusinessController as MEVisitOrdersController).GetVisitOrdersForLookupEdit();
                            break;
                        }
                    case TableName.MEVisitMedicationsTableName:
                        {
                            //var meVisitMedicationsController = new MEVisitMedicationsController();
                            ds = (objBusinessController as MEVisitMedicationsController).GetVisitMedicationsForLookupEdit();
                            break;
                        }
                    case TableName.MEVisitLabsTableName:
                        {
                            //var meVisitLabsController = new MEVisitLabsController();
                            ds = (objBusinessController as MEVisitLabsController).GetVisitLabsForLookupEdit();
                            break;
                        }
                    case TableName.MEEmrTypesTableName:
                        {
                            ds = (objBusinessController as MEEmrTypesController).GetEmrTypesForLookupEdit();
                            break;
                        }
                    case TableName.HRDepartmentsTableName:
                        {
                            ds = (objBusinessController as HRDepartmentsController).GetDepartmentsForLookupEdit();
                            break;
                        }
                    default:
                        {
                            ds = objBusinessController.GetAllObjects();
                            break;
                        }
                }
            return ds;
        }

        /// <summary>
        ///     Init additional customer data and add it to the existing data source
        /// </summary>
        /// <param name="lookupTable">Existing data source</param>
        private static void InitAdditionalCustomerData(DataTable lookupTable)
        {
            var objCustomersController = new ARCustomersController();
            for (var i = 0; i < lookupTable.Rows.Count; i++)
            {
                var objCustomersInfo =
                    (ARCustomersInfo)objCustomersController.GetObjectFromDataRow(lookupTable.Rows[i]);
                var objCustomersInfo1 = (ARCustomersInfo)objCustomersInfo.Clone();
                objCustomersInfo1.ARCustomerName1 = Empty;
                objCustomersInfo1.ARCustomerName2 = Empty;
                objCustomersInfo1.ARCustomerName3 = Empty;
                if (!IsNullOrEmpty(objCustomersInfo.ARCustomerName1))
                {
                    var addedRow = lookupTable.NewRow();
                    objCustomersInfo1.ARCustomerName = objCustomersInfo.ARCustomerName1;
                    objCustomersController.GetDataRowFromBusinessObject(addedRow, objCustomersInfo1);
                    lookupTable.Rows.InsertAt(addedRow, i + 1);
                }
                if (!IsNullOrEmpty(objCustomersInfo.ARCustomerName2))
                {
                    var addedRow = lookupTable.NewRow();
                    objCustomersInfo1.ARCustomerName = objCustomersInfo.ARCustomerName2;
                    objCustomersController.GetDataRowFromBusinessObject(addedRow, objCustomersInfo1);
                    lookupTable.Rows.InsertAt(addedRow, i + 1);
                }
                if (!IsNullOrEmpty(objCustomersInfo.ARCustomerName3))
                {
                    var addedRow = lookupTable.NewRow();
                    objCustomersInfo1.ARCustomerName = objCustomersInfo.ARCustomerName3;
                    objCustomersController.GetDataRowFromBusinessObject(addedRow, objCustomersInfo1);
                    lookupTable.Rows.InsertAt(addedRow, i + 1);
                }
            }
        }


        /// <summary>
        ///     Init additional stock data and add it to the existing data source
        /// </summary>
        /// <param name="lookupTable">Existing data source</param>
        private static void InitAdditionalStockData(DataTable lookupTable)
        {
            var objStocksController = new ICStocksController();
            for (var i = 0; i < lookupTable.Rows.Count; i++)
            {
                var objStocksInfo = (ICStocksInfo)objStocksController.GetObjectFromDataRow(lookupTable.Rows[i]);
                if (
                    !((objStocksInfo.ICStockType == StockType.Central.ToString()) ||
                      (objStocksInfo.ICStockType == StockType.Sale.ToString())
                      || (objStocksInfo.ICStockType == StockType.SaleOff.ToString()) ||
                      (objStocksInfo.ICStockType == StockType.Maintenance.ToString())
                      || (objStocksInfo.ICStockType == StockType.Damaged.ToString())))
                {
                    lookupTable.Rows.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void InitFieldFormatGroups()
        {
            FieldFormatGroups = new SortedList();
            var objFieldFormatGroupsController = new STFieldFormatGroupsController();
            var ds = objFieldFormatGroupsController.GetAllObjects();
            if (ds.Tables.Count <= 0) return;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var objFieldFormatGroupsInfo =
                    (STFieldFormatGroupsInfo)objFieldFormatGroupsController.GetObjectFromDataRow(row);
                if (objFieldFormatGroupsInfo != null)
                    FieldFormatGroups.Add(objFieldFormatGroupsInfo.STFieldFormatGroupID, objFieldFormatGroupsInfo);
            }
        }

        public static void DisableActionToolbarOfOpenModules(string strCurrentModuleName)
        {
            foreach (string strModuleName in OpenModules.Keys)
                if (!strModuleName.Equals(strCurrentModuleName))
                {
                    var module = (BaseModuleERP)OpenModules[strModuleName];
                    if (module.ParentScreen.ToolbarManager.Bars[BaseToolbar.ToolbarAction] != null)
                        module.ParentScreen.ToolbarManager.Bars[BaseToolbar.ToolbarAction].Visible = false;
                }
        }

        public static void EnableActionToolbarOfOpenModules(string strCurrentModuleName)
        {
            foreach (string strModuleName in OpenModules.Keys)
                if (!strModuleName.Equals(strCurrentModuleName))
                {
                    var module = (BaseModuleERP)OpenModules[strModuleName];
                    if (module.ParentScreen.ToolbarManager.Bars[BaseToolbar.ToolbarAction] != null)
                        module.ParentScreen.ToolbarManager.Bars[BaseToolbar.ToolbarAction].Visible = true;
                }
        }

        public static bool IsExistOpenModulesInAction()
        {
            foreach (string strModuleName in OpenModules.Keys)
            {
                var module = (BaseModuleERP)OpenModules[strModuleName];
                if (!module.Toolbar.IsNullOrNoneAction())
                    return true;
            }
            return false;
        }

        #region Functions to Section Manager for Main Form

        public static void InitSectionManagerByCurrentUser(string strUserName)
        {
            var objUserController = new ADUsersController();
            var iUserGroupID = objUserController.GetUserGroupOfUser(strUserName, _currentBranchInfo.BRBranchID);
            var objUserGroupSectionController = new ADUserGroupSectionsController();
            var dsUserGroupSections = objUserGroupSectionController.GetUserGroupSectionByUserGroupID(iUserGroupID);
            if (dsUserGroupSections.Tables.Count > 0)
                foreach (DataRow row in dsUserGroupSections.Tables[0].Rows)
                {
                    var objADUserGroupSectionsInfo =
                        (ADUserGroupSectionsInfo)objUserGroupSectionController.GetObjectFromDataRow(row);
                    var fld_navbarGroupApp = new NavBarGroup();
                    fld_navbarGroupApp.Appearance.Font = new Font("Tahoma", 10.25F, FontStyle.Bold, GraphicsUnit.Point,
                        0);
                    fld_navbarGroupApp.Appearance.Options.UseFont = true;
                    fld_navbarGroupApp.Caption = objADUserGroupSectionsInfo.ADUserGroupSectionName;
                    fld_navbarGroupApp.Expanded = true;
                    fld_navbarGroupApp.Name = "fld_navBarGroup" + objADUserGroupSectionsInfo.ADUserGroupSectionID;
                    AddModuleToGroupSection(fld_navbarGroupApp, objADUserGroupSectionsInfo.ADUserGroupSectionID);

                    MainScreen.SectionManager.Groups.Add(fld_navbarGroupApp);
                    MainScreen.SectionManager.ActiveGroup = MainScreen.SectionManager.Groups[0];
                }
            dsUserGroupSections.Dispose();
        }

        public static void AddModuleToGroupSection(NavBarGroup fld_navBarGroupApp, int iUserGroupSectionID)
        {
            var objModuleToUserGroupSectionController = new STModuleToUserGroupSectionsController();
            var dsModules =
                objModuleToUserGroupSectionController.GetDisplayedModulesByUserGroupSectionID(iUserGroupSectionID);
            if (dsModules.Tables.Count > 0)
                foreach (DataRow row in dsModules.Tables[0].Rows)
                {
                    var objSTModuleToUserGroupSectionsInfo =
                        (STModuleToUserGroupSectionsInfo)
                        objModuleToUserGroupSectionController.GetObjectFromDataRow(row);

                    var objModuleController = new STModulesController();
                    var objModuleInfo = new STModulesInfo();
                    objModuleInfo =
                        (STModulesInfo)objModuleController.GetObjectByID(objSTModuleToUserGroupSectionsInfo.STModuleID);
                    var fld_navBarItemModule = new NavBarItem();
                    fld_navBarItemModule.Caption =
                        new STModuleDescriptionsController().GetDescriptionByModuleNameAndLanguageName(
                            objModuleInfo.STModuleName, CurrentLang);
                    fld_navBarItemModule.Name = "fld_navBar" + objModuleInfo.STModuleName;
                    fld_navBarItemModule.SmallImageIndex = SectionImageList.Images.IndexOfKey(objModuleInfo.STModuleName);
                    fld_navBarItemModule.Tag = objModuleInfo.STModuleName;
                    fld_navBarItemModule.LinkClicked += ModuleItem_LinkClicked;

                    MainScreen.SectionManager.Items.Add(fld_navBarItemModule);
                    fld_navBarGroupApp.ItemLinks.Add(new NavBarItemLink(fld_navBarItemModule));
                }
            dsModules.Dispose();
        }

        private static void ModuleItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (e.Link.Item.Tag.ToString().StartsWith("BOS_"))
            {
                var ProgName = "C:\\BOS\\exe\\" + e.Link.Item.Tag.ToString().Substring(6) + ".exe";

                if (File.Exists(ProgName))
                    Process.Start(ProgName, "1 2 BB_##TEST");
                else
                    MessageBox.Show("Programm : " + ProgName + " nicht gefunden");

                return;
            }
            ShowModule(e.Link.Item.Tag.ToString());
        }

        public static void SetActiveGroupByModule(string strModuleName)
        {
            var moduleItem = MainScreen.SectionManager.Items["fld_navBar" + strModuleName];
            var moduleItemLink = moduleItem.Links[0];
            MainScreen.SectionManager.ActiveGroup = moduleItemLink.Group;
            MainScreen.SectionManager.SelectedLink = moduleItemLink;
        }

        #endregion

        private static void InitMenuAndSectionByUser(string userName)
        {
            for (var i = 2; i < MainScreen.MainMenu.ItemLinks.Count - 5; i++)
            {
                MainScreen.MainMenu.ItemLinks.RemoveAt(i); i--;
            }

            var objUserController = new ADUsersController();
            var userGroupId = objUserController.GetUserGroupOfUser(userName, _currentBranchInfo.BRBranchID);
            var objUserGroupSectionController = new ADUserGroupSectionsController();
            var dsUserGroupSections = objUserGroupSectionController.GetUserGroupSectionByUserGroupID(userGroupId);

            //Get list 
            if (dsUserGroupSections.Tables.Count > 0)
            {
                //Get List STModuleToUserGroupSections
                var stModuleToUserGroupSections = new STModuleToUserGroupSectionsController();
                var stModuleDescription = new STModuleDescriptionsController();
                var stModuleController = new STModulesController();
                var listModuleToSection = stModuleToUserGroupSections.GetListModuleByUserGroup(userGroupId);
                var listModule = stModuleController.GetListModuleByUserGroup(userGroupId);
                var listModuleDescription = stModuleDescription.GetModuleDescriptionsInfosByUserGroupId(userGroupId,
                    CurrentLang);
                for (var i = 0; i < dsUserGroupSections.Tables[0].Rows.Count; i++)
                {
                    var objAdUserGroupSectionsInfo = (ADUserGroupSectionsInfo)objUserGroupSectionController.GetObjectFromDataRow(dsUserGroupSections.Tables[0].Rows[i]);
                    //Add menu
                    var item = new BarSubItem
                    {
                        Caption = objAdUserGroupSectionsInfo.ADUserGroupSectionName.ToUpper(),

                    };
                    MainScreen.MainMenu.InsertItem(MainScreen.MainMenu.ItemLinks[2 + i], item);

                    //Add section
                    var fldNavbarGroupApp = new NavBarGroup();
                    fldNavbarGroupApp.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    fldNavbarGroupApp.Appearance.Options.UseFont = true;
                    fldNavbarGroupApp.Caption = objAdUserGroupSectionsInfo.ADUserGroupSectionName.ToUpper();
                    fldNavbarGroupApp.Expanded = true;
                    fldNavbarGroupApp.Name = "fld_navBarGroup" + objAdUserGroupSectionsInfo.ADUserGroupSectionID;
                    InitSubMenuAndModule(item, fldNavbarGroupApp, listModuleToSection.Where(x => x.STUserGroupSectionID == objAdUserGroupSectionsInfo.ADUserGroupSectionID).ToList(), listModule, listModuleDescription);
                    MainScreen.SectionManager.Groups.Add(fldNavbarGroupApp);
                    MainScreen.SectionManager.ActiveGroup = MainScreen.SectionManager.Groups[0];
                }
            }

            dsUserGroupSections.Dispose();
        }

        private static void InitSubMenuAndModule(BarSubItem menuItem, NavBarGroup navBarGroupApp, List<STModuleToUserGroupSectionsInfo> listModuleBySection, List<STModulesInfo> listModule, List<STModuleDescriptionsInfo> listDescriptionsInfos)
        {
            foreach (var moduleBySection in listModuleBySection)
            {
                var objModuleDescriptionsInfo =
                    listDescriptionsInfos.FirstOrDefault(x => x.STModuleID == moduleBySection.STModuleID);
                var module = listModule.FirstOrDefault(x => x.STModuleID == moduleBySection.STModuleID);
                if (objModuleDescriptionsInfo == null || module == null) continue;

                BarButtonItem subItem;
                if (Devide.Current == Devide.Tablet)
                {
                    subItem = new BarLargeButtonItem
                    {
                        Caption = objModuleDescriptionsInfo.STModuleDescriptionDescription,
                        Tag = moduleBySection.STModuleID,
                        MinSize = new Size(0, 40)
                    };
                }
                else
                {
                    subItem = new BarButtonItem
                    {
                        Caption = objModuleDescriptionsInfo.STModuleDescriptionDescription,
                        Tag = moduleBySection.STModuleID,
                    };
                }

                subItem.ItemClick += subItem_ItemClick;
                menuItem.AddItem(subItem);

                //Sub module Section
                var fldNavBarItemModule = new NavBarItem
                {
                    Caption = objModuleDescriptionsInfo.STModuleDescriptionDescription,
                    Name = "fld_navBar" + module.STModuleName,
                    SmallImageIndex = SectionImageList.Images.IndexOfKey(module.STModuleName),
                    Tag = module.STModuleName,
                };
                fldNavBarItemModule.LinkClicked += ModuleItem_LinkClicked;

                MainScreen.SectionManager.Items.Add(fldNavBarItemModule);
                navBarGroupApp.ItemLinks.Add(new NavBarItemLink(fldNavBarItemModule));
            }
        }

        #region Treelist

        private static void InitRootTreeListManagerByCurrentUser(string strUserName)
        {
            MainScreen.TreeListSectionManager.StateImageList = SectionImageList;

            var objUserController = new ADUsersController();
            var iUserGroupID = objUserController.GetUserGroupOfUser(strUserName, _currentBranchInfo.BRBranchID);
            var objUserGroupSectionController = new ADUserGroupSectionsController();
            var dsUserGroupSections = objUserGroupSectionController.GetUserGroupSectionByUserGroupID(iUserGroupID);
            if (dsUserGroupSections.Tables.Count > 0)
                foreach (DataRow row in dsUserGroupSections.Tables[0].Rows)
                {
                    var objADUserGroupSectionsInfo =
                        (ADUserGroupSectionsInfo)objUserGroupSectionController.GetObjectFromDataRow(row);
                    var treelstNode =
                        MainScreen.TreeListSectionManager.AppendNode(
                            new object[] { objADUserGroupSectionsInfo.ADUserGroupSectionName }, null);
                    treelstNode.HasChildren = true;
                    AddModuleToChildNode(treelstNode, objADUserGroupSectionsInfo.ADUserGroupSectionID);
                }
            dsUserGroupSections.Dispose();

            MainScreen.TreeListSectionManager.NodeCellStyle += TreeListSectionManager_NodeCellStyle;
            MainScreen.TreeListSectionManager.MouseClick += TreeListSectionManager_MouseClick;
            MainScreen.TreeListSectionManager.MouseMove += TreeListSectionManager_MouseMove;
            MainScreen.TreeListSectionManager.MouseLeave += TreeListSectionManager_MouseLeave;

            MainScreen.TreeListSectionManager.ExpandAll();
        }

        private static void AddModuleToChildNode(TreeListNode treelstParent, int iUserGroupSectionID)
        {
            var objModuleToUserGroupSectionController = new STModuleToUserGroupSectionsController();
            var dsModules =
                objModuleToUserGroupSectionController.GetDisplayedModulesByUserGroupSectionID(iUserGroupSectionID);
            if (dsModules.Tables.Count > 0)
                foreach (DataRow row in dsModules.Tables[0].Rows)
                {
                    var objSTModuleToUserGroupSectionsInfo =
                        (STModuleToUserGroupSectionsInfo)
                        objModuleToUserGroupSectionController.GetObjectFromDataRow(row);

                    var objModuleController = new STModulesController();
                    var objModuleInfo = new STModulesInfo();
                    objModuleInfo =
                        (STModulesInfo)objModuleController.GetObjectByID(objSTModuleToUserGroupSectionsInfo.STModuleID);

                    var strCaption =
                        new STModuleDescriptionsController().GetDescriptionByModuleNameAndLanguageName(
                            objModuleInfo.STModuleName, CurrentLang);
                    var treelstNode = MainScreen.TreeListSectionManager.AppendNode(new object[] { strCaption },
                        treelstParent);
                    treelstNode.HasChildren = false;
                    treelstNode.Tag = objModuleInfo.STModuleName;
                    treelstNode.StateImageIndex = SectionImageList.Images.IndexOfKey(objModuleInfo.STModuleName);
                }
            dsModules.Dispose();
        }

        public static void SetActiveModuleByModuleName(string strModuleName)
        {
            MainScreen.TreeListHotTrackID = -1;
            foreach (TreeListNode treeParentNode in MainScreen.TreeListSectionManager.Nodes)
                foreach (TreeListNode treeItemNode in treeParentNode.Nodes)
                    if (treeItemNode.Tag.Equals(strModuleName))
                    {
                        treeParentNode.ExpandAll();
                        MainScreen.TreeListSectionManager.SetFocusedNode(treeItemNode);
                        return;
                    }
            MainScreen.TreeListSectionManager.Refresh();
        }

        private static void TreeListSectionManager_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if ((e.Node.Tag != null) && (e.Node.Tag.ToString() == CurrentModule))
            {
                e.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Underline);
                e.Appearance.GradientMode = LinearGradientMode.Vertical;
                e.Appearance.BackColor = Color.Yellow;
                e.Appearance.BackColor2 = Color.Tomato;
                return;
            }

            if (e.Node.Id == MainScreen.TreeListHotTrackID)
            {
                e.Appearance.GradientMode = LinearGradientMode.BackwardDiagonal;
                e.Appearance.BackColor = Color.Transparent;
                e.Appearance.BackColor2 = Color.Orange;
                return;
            }

            if (e.Node.HasChildren)
            {
                var tempfont = new Font("Tahoma", 10, FontStyle.Bold);
                e.Appearance.Font = tempfont;
                e.Appearance.GradientMode = LinearGradientMode.Vertical;
                e.Appearance.BackColor = Color.Silver;
                e.Appearance.BackColor2 = Color.White;
            }
            else
            {
                e.Appearance.BackColor = Color.White;
                e.Appearance.BackColor2 = Color.White;
            }
        }

        private static void TreeListSectionManager_MouseClick(object sender, MouseEventArgs e)
        {
            var treelst = (TreeList)sender;
            var treeHitInfo = treelst.CalcHitInfo(e.Location);
            if (treeHitInfo.Node != null)
                if (treeHitInfo.Node.Tag != null)
                {
                    var strModuleName = treeHitInfo.Node.Tag.ToString();
                    if (!IsNullOrEmpty(strModuleName))
                    {
                        SetActiveModuleByModuleName(strModuleName);
                        ShowModule(strModuleName);
                    }
                }
        }

        private static void TreeListSectionManager_MouseMove(object sender, MouseEventArgs e)
        {
            var treelst = (TreeList)sender;
            var treeHitInfo = treelst.CalcHitInfo(e.Location);
            if (treeHitInfo.Node != null)
                if (treeHitInfo.Node.Tag != null)
                {
                    MainScreen.TreeListHotTrackID = treeHitInfo.Node.Id;
                    MainScreen.TreeListSectionManager.Refresh();
                }
        }

        private static void TreeListSectionManager_MouseLeave(object sender, EventArgs e)
        {
            MainScreen.TreeListHotTrackID = -1;
            MainScreen.TreeListSectionManager.Refresh();
        }

        #endregion

        #region Utility Functions

        public static void InitToolbarImageList()
        {
            try
            {
                ToolbarImageList.Images.Clear();
                ToolbarImageList.ImageSize = new Size(16, 16);
                var strToolbarImagePath = Application.StartupPath + "\\img\\Toolbar";
                var dir = new DirectoryInfo(strToolbarImagePath);
                foreach (var file in dir.GetFiles())
                    if ((file.Extension.ToLower() == ".ico") || (file.Extension.ToLower() == ".png") ||
                        (file.Extension.ToLower() == ".jpg") || (file.Extension.ToLower() == ".bmp"))
                    {
                        var index = file.Name.IndexOf(".");
                        if (index > 0)
                        {
                            var strKey = file.Name.Substring(0, index);
                            var img = Image.FromFile(file.FullName);
                            ToolbarImageList.Images.Add(strKey, img);
                        }
                    }
            }
            catch (Exception)
            {
            }
        }

        public static void InitSectionImageList()
        {
            try
            {
                SectionImageList.Images.Clear();
                SectionImageList.ImageSize = new Size(12, 12);
                var strSectionImagePath = Application.StartupPath + "\\img\\Section";
                var dir = new DirectoryInfo(strSectionImagePath);
                foreach (var file in dir.GetFiles())
                    if ((file.Extension.ToLower() == ".ico") || (file.Extension.ToLower() == ".png") ||
                        (file.Extension.ToLower() == ".jpg") || (file.Extension.ToLower() == ".bmp"))
                    {
                        var index = file.Name.IndexOf(".");
                        if (index > 0)
                        {
                            var strKey = file.Name.Substring(0, index);
                            var img = Image.FromFile(file.FullName);
                            SectionImageList.Images.Add(strKey, img);
                        }
                    }
            }
            catch (Exception)
            {
            }
        }

        public static void SetApplicationStyle(string strLookAndFeelStyle, string strLookAndFeelStyleSkin)
        {
            if (strLookAndFeelStyle == "Skin")
            {
                if (!IsNullOrEmpty(strLookAndFeelStyleSkin))
                    UserLookAndFeel.Default.SetSkinStyle(strLookAndFeelStyleSkin);
                else
                    UserLookAndFeel.Default.SetSkinStyle("Black");
            }
            else
            {
                var style = LookAndFeelStyle.Office2003;
                try
                {
                    style = (LookAndFeelStyle)Enum.Parse(typeof(LookAndFeelStyle), strLookAndFeelStyle);
                }
                catch (Exception)
                {
                    style = LookAndFeelStyle.Office2003;
                }
                UserLookAndFeel.Default.SetStyle(style, false, true);
            }
            if (Devide.Current == Devide.Tablet)
            {
                var skin = DevExpress.Skins.TabSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
                var element = skin[DevExpress.Skins.TabSkins.SkinTabHeader];
                element.ContentMargins.Top = 10;
                element.ContentMargins.Bottom = 10;

                skin = DevExpress.Skins.DockingSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
                element = skin[DevExpress.Skins.DockingSkins.SkinDocumentGroupTabHeader];
                element.ContentMargins.Top = 10;
                element.ContentMargins.Bottom = 10;

                element = skin[DevExpress.Skins.DockingSkins.SkinDockWindowButton];
                element.ContentMargins.Top = 7;
                element.ContentMargins.Bottom = 7;
                element.ContentMargins.Left = 10;
                element.ContentMargins.Right = 10;

                element = skin[DevExpress.Skins.DockingSkins.SkinTabHeaderHideBar];
                element.ContentMargins.Top = 10;
                element.ContentMargins.Bottom = 10;

                LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            }
        }

        public static void SaveUserStyle(string strLookAndFeelStyle, string strLookAndFeelStyleSkin)
        {
            if (CurrentUsersInfo != null)
            {
                if (CurrentUsersInfo.ADUserStyleSkin == strLookAndFeelStyleSkin) return;

                var objUsersController = new ADUsersController();
                CurrentUsersInfo.ADUserStyle = strLookAndFeelStyle;
                CurrentUsersInfo.ADUserStyleSkin = strLookAndFeelStyleSkin;
                objUsersController.UpdateObject(CurrentUsersInfo);
            }
        }

        /// <summary>
        ///     Init menu main form
        /// </summary>
        public static void InitMenuOfMainForm()
        {
            //Clear all existing items
            for (var i = 2; i < MainScreen.MainMenu.ItemLinks.Count - 3; i++)
            {
                MainScreen.MainMenu.ItemLinks.RemoveAt(i);
                i--;
            }
            //Add new items from databaseADUsersController objUserController = new ADUsersController();
            var iUserGroupID = new ADUsersController().GetUserGroupOfUser(CurrentUser, _currentBranchInfo.BRBranchID);
            var objUserGroupSectionController = new ADUserGroupSectionsController();
            var dsUserGroupSections = objUserGroupSectionController.GetUserGroupSectionByUserGroupID(iUserGroupID);
            if (dsUserGroupSections.Tables.Count > 0)
                for (var i = 0; i < dsUserGroupSections.Tables[0].Rows.Count; i++)
                {
                    var objADUserGroupSectionsInfo =
                        (ADUserGroupSectionsInfo)
                        objUserGroupSectionController.GetObjectFromDataRow(dsUserGroupSections.Tables[0].Rows[i]);
                    var item = new BarSubItem();
                    item.Caption = objADUserGroupSectionsInfo.ADUserGroupSectionName;
                    MainScreen.MainMenu.InsertItem(MainScreen.MainMenu.ItemLinks[2 + i], item);
                    item = AddSubMenuToMenuItem(item, objADUserGroupSectionsInfo.ADUserGroupSectionID);
                }
        }

        /// <summary>
        ///     Init sub menu to menu item
        /// </summary> 
        public static BarSubItem AddSubMenuToMenuItem(BarSubItem menuItem, int userGroupSectionId)
        {
            var objStModuleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();
            var dsModuleUserGroupSections =
                objStModuleToUserGroupSectionsController.GetDisplayedModulesByUserGroupSectionID(userGroupSectionId);
            if (dsModuleUserGroupSections == null) return menuItem;
            foreach (DataRow row in dsModuleUserGroupSections.Tables[0].Rows)
            {
                var objStModuleToUserGroupSectionsInfo =
                    (STModuleToUserGroupSectionsInfo)
                    objStModuleToUserGroupSectionsController.GetObjectFromDataRow(row);
                if (objStModuleToUserGroupSectionsInfo == null) continue;
                var objStModulesInfo =
                    (STModulesInfo)
                    new STModulesController().GetObjectByID(objStModuleToUserGroupSectionsInfo.STModuleID);
                var objModuleDescriptionsController = new STModuleDescriptionsController();
                var objModuleDescriptionsInfo =
                    objModuleDescriptionsController.GetModuleDescriptionByModuleNameAndLanguageName(
                        objStModulesInfo.STModuleName, CurrentLang);
                var subItem = new BarButtonItem
                {
                    Caption = objModuleDescriptionsInfo.STModuleDescriptionDescription,
                    Tag = objStModulesInfo.STModuleID
                };
                subItem.ItemClick += subItem_ItemClick;
                menuItem.AddItem(subItem);
            }
            return menuItem;
        }

        /// <summary>
        ///     Init toolbar of main form
        /// </summary>
        public static void InitToolbarOfMainForm()
        {
            MainScreen.Toolbar.ClearLinks();
            var objToolbarsController = new STToolbarsController();
            var ds = objToolbarsController.GetMainToolbar();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var objToolbarsInfo = (STToolbarsInfo)objToolbarsController.GetObjectFromDataRow(row);
                var hasPermission = true;
                if (!IsNullOrEmpty(objToolbarsInfo.STToolbarTag) &&
                    (objToolbarsInfo.STToolbarTag != ModuleName.Common))
                    hasPermission = HasModuleAccessPermission(objToolbarsInfo.STToolbarTag);
                if (!hasPermission || !objToolbarsInfo.STToolbarVisible) continue;
                var toolbarItem = new BarButtonItem
                {
                    Caption = objToolbarsInfo.STToolbarCaption,
                    Name = objToolbarsInfo.STToolbarName,
                    Tag = objToolbarsInfo.STToolbarID,
                    LargeImageIndex = ToolbarImageList.Images.IndexOfKey(objToolbarsInfo.STToolbarImage),
                    ImageIndex = ToolbarImageList.Images.IndexOfKey(objToolbarsInfo.STToolbarImage),
                    PaintStyle = BarItemPaintStyle.CaptionGlyph,
                };
                toolbarItem.ItemClick += toolbarItem_ItemClick;
                MainScreen.Toolbar.AddItem(toolbarItem);
            }
        }
        private static void SyncButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show(@"Bạn có muốn cập nhật dữ liệu từ Server", @"Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes) return;
            CloseAllOpenModules();
            var form = new GuiSyncData(_currentBranchInfo.BRBranchBacSi24x7Id
                , _currentBranchInfo.BRBranchName
                , null
                , null
                , _currentBranchInfo.BRBranchID
                , null
                , _currentBranchInfo.BRBranchNo
                , true);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var dateNow = ConvertToTimestamp(GetCurrentServerDate().ToUniversalTime());
                _currentBranchInfo.BRBranchLatestSync = dateNow;
                var objBranchController = new BRBranchsController();
                objBranchController.UpdateObject(_currentBranchInfo); MessageBox.Show(@"Đã cập nhật dữ liệu thành công.", @"Thông báo", MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Cập nhật dữ liệu xảy ra lỗi. Vui lòng thử lại.", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///     Show module when click submenu item.
        /// </summary>
        private static void subItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var moduleID = (int)e.Item.Tag;
            var objModuleInfo = (STModulesInfo)new STModulesController().GetObjectByID(moduleID);
            if (!IsNullOrEmpty(objModuleInfo.STModuleName))
            {
                SetActiveModuleByModuleName(objModuleInfo.STModuleName);
                ShowModule(objModuleInfo.STModuleName);
            }
        }

        /// <summary>
        ///     Solve click event when user click on toolbar button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void toolbarItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var objToolbarsInfo = (STToolbarsInfo)new STToolbarsController().GetObjectByID((int)e.Item.Tag);
            var objToolbarFunctionsController = new STToolbarFunctionsController();
            var ds = objToolbarFunctionsController.GetAllDataByForeignColumn("STToolbarID", objToolbarsInfo.STToolbarID);
            SetActiveModuleByModuleName(objToolbarsInfo.STToolbarTag);
            BaseModuleERP currModule = null;
            if (objToolbarsInfo.STToolbarTag == ModuleName.Common)
                currModule = BaseModuleFactory.GetModule(ModuleName.Common);
            else
                currModule = ShowModule(objToolbarsInfo.STToolbarTag);

            if (ds.Tables[0].Rows.Count > 0)
            {
                var objToolbarFucntionsInfo =
                    (STToolbarFunctionsInfo)objToolbarFunctionsController.GetObjectFromDataRow(ds.Tables[0].Rows[0]);
                if (objToolbarFucntionsInfo != null)
                {
                    var methodInfo =
                        currModule.GetMethodInfoByMethodFullNameAndMethodClass(
                            objToolbarFucntionsInfo.STToolbarFunctionName,
                            objToolbarFucntionsInfo.STToolbarFunctionFullName,
                            objToolbarFucntionsInfo.STToolbarFunctionClass);
                    if (methodInfo != null)
                        methodInfo.Invoke(currModule, null);
                }
            }
        }
        #endregion

        public static void Init()
        {
            var appLocation = Environment.CurrentDirectory;
            if (appLocation.EndsWith("\\system32"))
                appLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            BOSApp.AppLocation = appLocation;

            Task.Run(() => BOSApp.GetSystemConfigs());

            Task.Run(() =>
            {
                ADConfigValueUtility.InitGlobalConfigValueTables();
                //Comment Lookup with new flow
                InitFieldFormatGroups();
            });

            Task.Run(() =>
            {
                //init blank LookupEdit
                if (LookupTables == null)
                    LookupTables = new SortedList();
                if (LookupTablesUpdatedDate == null)
                    LookupTablesUpdatedDate = new SortedList();
                if (LookupTableObjects == null)
                    LookupTableObjects = new SortedList<string, GELookupTablesInfo>();
            });
            Task.Run(() => SystemMemCache.Init());
            Task.Run(() => Assembly.LoadFrom(Application.StartupPath + "\\EMR.exe").GetType("BOSERP.Modules.MEEmr.MEEmrModule"));

            Task.Run(() =>
            {
                var strForeignTableNames = new List<string>
                {
                    "GEObjectHistory",
                    "MEEmrArchives",
                    "MEEmrDocuments",
                    "MEEmrDocumentSigns",
                    "MEEmrs",
                    "MEEmrShareHistories",
                    "MEEmrTransferHistories"
                };
                BOSDbUtil dbUtil = new BOSDbUtil();
                foreach (var strForeignTableName in strForeignTableNames)
                {
                    dbUtil.AddForeignTableColumns(strForeignTableName);
                }
            });

            PreLoadScreen("SMMEEMR100", "MEEmr");
            PreLoadScreen("SQMEEMR100", "MEEmr");
            PreLoadScreen("DMMEEMR100", "MEEmr");
            PreLoadScreen("DMMEEMR101", "MEEmr");
            PreLoadScreen("DMMEEMR102", "MEEmr");
        }
        /// <summary>
        /// Load vi muc dich cache
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="module"></param>
        public static void PreLoadScreen(string screen, string module)
        {
            Thread myStaThread = new Thread(() =>
            {
                try
                {
                    BOSERPScreenFactory.GetScreen(screen, module);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            });
            myStaThread.SetApartmentState(ApartmentState.STA);
            myStaThread.Start();

            //Task.Run(() =>
            //{
            //    try
            //    {
            //        var gui = BOSERPScreenFactory.GetScreen(screen, module);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }
            //});
        }
        public static void BeforeLogOn()
        {
            Task.Run(() =>
            {
                InitToolbarImageList();
                InitSectionImageList();
                MainScreen.BarManager.Images = ToolbarImageList;
                MainScreen.BarManager.LargeImages = ToolbarImageList;
            });
        }
        public static void LogOn()
        {
            BeforeLogOn();
            try
            {
                if (DiffTimeServer())
                {
                    MessageBox.Show(@"Máy bạn lệch thời gian với máy chủ. Vui lòng cập nhật thời gian cho đúng.", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                // No action
            }

            try
            {
                var guiLogin = new guiLogin();
                guiLogin.ShowDialog();
                if (guiLogin.DialogResult == DialogResult.OK)
                {
                    InitAfterLogOn();
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                var ExceptionFormatString = "Exception message: {0}{1}Exception Source: {2}{1}Exception StackTrace: {3}{1}";
                var exDetail = Format(ExceptionFormatString, ex.Message, Environment.NewLine, ex.Source, ex.StackTrace);
                MessageBox.Show(exDetail);
                Application.Exit();
            }
        }
        private static void GetExtraGroups(int userId)
        {
            CurrentUsersExtraGroups = (new ADUserGroupExtrasController()).GetAllByUserID(userId);
        }
        private static void InitAfterLogOn()
        {
            _isFirstLogin = false;
            AppMemCache.UseAppMemCache = GetUseAppCacheConfig();
            Task.Run(() => AppMemCache.Init());
            //Set application style for current user
            var objUsersController = new ADUsersController();
            var user = (ADUsersInfo)objUsersController.GetObjectByName(CurrentUser);
            if (user != null)
            {
                SetApplicationStyle(user.ADUserStyle, user.ADUserStyleSkin);
                Task.Run(() =>
                {
                    WriteUsingHistory(UsingHistoryType.LogIn.ToString(), user.ADUserID, user.ADUserName, user.ADUserOnIpAddress, user.ADUserOnComputerName, user.ADUserOnComputerMAC);
                });
            }
            //Get current user
            CurrentUsersInfo = user;
            Task.Run(() => GetExtraGroups(CurrentUsersInfo.ADUserID));
            if (CurrentUsersInfo.FK_HREmployeeID == 0)
            {
                MessageBox.Show("Tài khoản chưa gán nhân viên, vui lòng liên hệ quản trị viên.",
                    CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                BOSApp.LogOff();
            }

            //Get current company info
            var objCsCompanysController = new CSCompanysController();
            if (IsNullOrEmpty(ConfigurationManager.AppSettings["CSCompanyID"]))
                _currentCompanyInfo = (CSCompanysInfo)objCsCompanysController.GetFirstObject();
            else
                _currentCompanyInfo = (CSCompanysInfo)objCsCompanysController.GetObjectByID(int.Parse(ConfigurationManager.AppSettings["CSCompanyID"]));
            var objEmployeeController = new HREmployeesController();
            CurrentEmployeesInfo = (HREmployeesInfo)objEmployeeController.GetObjectByID(CurrentUsersInfo.FK_HREmployeeID);
            if (CurrentEmployeesInfo.FK_HRDepartmentID == 0)
            {
                MessageBox.Show("Nhân viên chưa có khoa mặc định, vui lòng liên hệ quản trị viên.",
                    CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                BOSApp.LogOff();
            }

            //Employee có thể làm việc ở nhiều khoa
            var deptCtrl = new HRDepartmentsController();
            var workingDepts = deptCtrl.GetAllDeptsOfEmp(CurrentUsersInfo.FK_HREmployeeID, CurrentEmployeesInfo.FK_HRDepartmentID);
            if (workingDepts.Count == 1)
            {
                CurrentEmployeesInfo.FK_HRDepartmentID = workingDepts[0].HRDepartmentID;
            }
            else if (workingDepts.Count > 1)
            {
                var guiSelectDept = new guiSelectDept(workingDepts);
                if (guiSelectDept.ShowDialog() == DialogResult.OK)
                {
                    CurrentEmployeesInfo.FK_HRDepartmentID = guiSelectDept.SelectedDepartmentID;
                }
            }

            var objBranchController = new BRBranchsController();
            _currentBranchInfo = (BRBranchsInfo)objBranchController.GetObjectByID(CurrentCompanyInfo.FK_BRBranchID);

            _currentUserGroupID = objUsersController.GetUserGroupOfUser(CurrentUser, _currentBranchInfo.BRBranchID);
            _currentUserGroupsInfo = (ADUserGroupsInfo)new ADUserGroupsController().GetObjectByID(_currentUserGroupID);

            InitCurrentDepartmentSession(workingDepts);

            Task.Run(() =>
            {
                _currentDataViewPermissionList = (new ADDataViewPermissionsController()).GetDataViewPermissionsByUserID(CurrentUsersInfo.ADUserID);
            });

            //Init status bar items
            MainScreen.roleItem.Caption = @"Vai trò\" + BOSApp.CurrentUserGroupInfo.ADUserGroupRole;
            MainScreen.ToggleDropBtnAdminMessage(BOSApp.CurrentUserGroupInfo.ADUserGroupRole == UserGroupRole.admin.ToString());

            MainScreen.userItem.Caption = CurrentUserGroupInfo.ADUserGroupName + @"\" + CurrentUser;
            MainScreen.dateItem.Caption = DateTime.Now.ToShortDateString();

            var viewKey = "UserGroupEmrView" + (string.IsNullOrEmpty(CurrentUsersInfo.ADUserEmrView) ? CurrentUserGroupInfo.ADUserGroupEmrView : CurrentUsersInfo.ADUserEmrView);
            MainScreen.viewPermissionItem.Caption = "Quyền truy xuất bệnh án\\" + ADConfigValueUtility.GetTextFromKey(viewKey);

            //Init bars of main form
            Task.Run(() =>
            {
                InitMenuAndSectionByUser(CurrentUser);
                InitToolbarOfMainForm();
            });

            ShowModule(GetUserConfigDefaultModule());

            //Show home page 
            Task.Run(() =>
            {
                (new MEEmrDocumentsController()).ReleaseAllEditing(BOSApp.CurrentUsersInfo.FK_HREmployeeID, BOSApp.GetMachineMac());
                CheckDocumentHoldOn(CurrentUsersInfo.FK_HREmployeeID);
                MoveErrorDocuments();
            });
            Task.Run(() =>
            {
                BOSApp.LoadUserFingerprints(user.ADUserID);
                BOSApp.LoadUserFingerprintsZKTeco(user.ADUserID);
            });
            MainScreen.machineInfoItem.Caption = Dns.GetHostName() + "\\" + BOSApp.GetMachineIp() + ":" + BOSApp.GetMachineMac();
        }

        /// <summary>
        ///     Check whether the current user has access permission to a module
        /// </summary>
        /// <param name="moduleName">Module name</param>
        /// <returns>True if can access, otherwise false</returns>
        public static bool HasModuleAccessPermission(string moduleName)
        {
            var objModuleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();
            var objModuleToUserGroupSectionsInfo = objModuleToUserGroupSectionsController
                .GetModuleToUserGroupSectionByModuleNameAndUserGroupID(
                    moduleName,
                    CurrentUserGroupInfo.ADUserGroupID);
            return objModuleToUserGroupSectionsInfo != null;
        }

        public static void WriteUsingHistory(string type, int userId, string userName, string ip, string hostName, string macAddress)
        {
            ADUsersController objUsersController = new ADUsersController();
            GEUsingHistoryController historyCtrl = new GEUsingHistoryController();
            GEUsingHistoryInfo history = new GEUsingHistoryInfo
            {
                ADUserID = userId,
                ADUserName = userName,
                GEUsingHistoryType = type,
                GEUsingHistoryDate = DateTime.Now,
                GEUsingHistoryComputer = hostName,
                GEUsingHistoryIp = ip,
                GEUsingHistoryMAC = macAddress
            };
            historyCtrl.CreateObject(history);
        }
        public static void ReleaseMachine(int userId)
        {
            ADUsersController objUsersController = new ADUsersController();
            ADUsersInfo user = (ADUsersInfo)objUsersController.GetObjectByID(userId);

            //neu co 1 may khac dang login sau may nay
            if (user.ADUserOnComputerMAC != GetMachineMac()) return;

            user.ADUserOnIpAddress = string.Empty;
            user.ADUserOnComputerName = string.Empty;
            user.ADUserOnComputerMAC = string.Empty;
            objUsersController.UpdateObject(user);
        }
        public static void TurnOff()
        {
            (new MEEmrDocumentsController()).ReleaseAllEditing(CurrentUsersInfo.FK_HREmployeeID, BOSApp.GetMachineMac());
            WriteUsingHistory(UsingHistoryType.TurnOff.ToString(), CurrentUsersInfo.ADUserID, CurrentUsersInfo.ADUserName, CurrentUsersInfo.ADUserOnIpAddress,
                CurrentUsersInfo.ADUserOnComputerName, CurrentUsersInfo.ADUserOnComputerMAC);
            BOSApp.SaveUserStyle("Skin", UserLookAndFeel.Default.SkinName);
            ReleaseMachine(CurrentUsersInfo.ADUserID);
            ShutDownRabbitMQ();
            _hisWaitHandle.Set();
            _hisWaitHandle.Close();
        }
        /// <summary>
        ///     Log off BOS
        /// </summary>
        public static void LogOff()
        {
            //Close all open modules,clear all in Open Module list and tool strip .Enable Open module tool strip
            CloseAllOpenModules();
            if (OpenModules.Count > 0) return;

            (new MEEmrDocumentsController()).ReleaseAllEditing(BOSApp.CurrentUsersInfo.FK_HREmployeeID, BOSApp.GetMachineMac());
            WriteUsingHistory(UsingHistoryType.LogOut.ToString(), CurrentUsersInfo.ADUserID, CurrentUsersInfo.ADUserName, CurrentUsersInfo.ADUserOnIpAddress,
                CurrentUsersInfo.ADUserOnComputerName, CurrentUsersInfo.ADUserOnComputerMAC);
            SaveUserStyle("Skin", UserLookAndFeel.Default.SkinName);
            ReleaseMachine(CurrentUsersInfo.ADUserID);

            //Clear section manager and enable if current section manager is not enable
            MainScreen.SectionManager.Groups.Clear();
            MainScreen.SectionManager.Enabled = true;

            OpenModules.Clear();
            MainScreen.OpenModulesToolStrip.Items.Clear();
            MainScreen.OpenModulesToolStrip.Enabled = true;

            MainScreen.Text = SystemMemCache.GetSystemConfigInitValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_COMPANY_NAME, "CHC.EMR");
            CurrentBacSi24X7 = null;
            CurrentUser = null;
            CurrentUsersInfo = null;
            CurrentEmployeesInfo = null;
            if (_signalHubClient != null)
            {
                _signalHubClient.Disconnect();
            }
            ShutDownRabbitMQ();
            _hisWaitHandle.Set();
            _hisWaitHandle.Close();


            BOSApp.MainScreen.MessageList.Clear();
            //Log on again
            LogOn();
        }

        #region RabbitMQ
        public static void InitExchangeLogOffRabbitMQ()
        {
            var _macAddress = GetMachineMac();

            _channelLogOffQueue = RabbitMqConnectionManager.CreateChannel();
            // declare a server-named queue
            _channelLogOffQueue.ExchangeDeclare(exchange: "EmrLogOff", durable: false, type: ExchangeType.Fanout);

            QueueDeclareOk queueDeclareResult = _channelLogOffQueue.QueueDeclare();
            string queueName = queueDeclareResult.QueueName;
            _channelLogOffQueue.QueueBind(queue: queueName, exchange: "EmrLogOff", routingKey: _macAddress);

            var consumer = new EventingBasicConsumer(_channelLogOffQueue);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var data = Encoding.UTF8.GetString(body);
                if (_isLoginByHIS && BOSApp.CurrentUser.ToLower() == data.ToLower())
                {
                    try
                    {
                        BOSApp.MainScreen.Invoke(new Action(() =>
                        {
                            TurnOff();
                            try
                            {
                                BOSApp.CurrentUser = null;
                                BOSApp.MainScreen.Close();

                            }
                            catch (Exception ex)
                            {

                            }
                        }));

                    }
                    catch (Exception ex)
                    {

                    }
                }
            };
            _channelLogOffQueue.BasicConsume(queueName, noAck: true, consumer: consumer);
        }

        private static void ShutDownRabbitMQ()
        {
            if (_channelLogOffQueue != null)
            {
                _channelLogOffQueue.Close();
                _channelLogOffQueue.Dispose();
            }
            RabbitMqConnectionManager.Shutdown();
        }

        #endregion

        /// <summary>
        ///     Show Module with module Name
        /// </summary>
        /// <param name="strModuleName">Module Name</param>
        public static BaseModuleERP ShowModule(string strModuleName)
        {
            BaseModuleERP currModule = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //Show new module                   
                //If module will be show is in Opened Module List, get this module and show
                if (IsOpenedModule(strModuleName))
                {
                    currModule = (BaseModuleERP)OpenModules[strModuleName];
                    ShowOpenedModule(strModuleName);
                }
                //if module is not in Opened Module List, create new instance and show
                else
                {
                    currModule = BaseModuleFactory.GetModule(strModuleName);
                    if (currModule != null)
                        ShowNewModule(currModule);
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                return null;
            }
            return currModule;
        }

        public static void ShowModule(string strModuleName, int ID)
        {
            var mdl = ShowModule(strModuleName);
            mdl.Invalidate(ID);
            //mdl.ActionInvalidate(ID);
        }

        public static void ShowModule(string strModuleName, string ID)
        {
        }

        /// <summary>
        ///     Show module have already exist on Opend Modules List
        /// </summary>
        /// <param name="strModuleName"></param>
        public static void ShowOpenedModule(string strModuleName)
        {
            var tsbtnModule = (ToolStripButton)MainScreen.OpenModulesToolStrip.Items[strModuleName];
            CheckOpenModuleToolStripButton(tsbtnModule);
            var module = (BaseModuleERP)OpenModules[strModuleName];
            module.ParentScreen.Activate();
        }

        /// <summary>
        ///     Show new module
        /// </summary>
        /// <param name="module"></param>
        public static void ShowNewModule(BaseModuleERP module)
        {
            UpdateOpenedModule(module);
            AddOpenModuleToOpenModulesToolStrip(module.Name);
            module.Show();
        }

        /// <summary>
        ///     Populate ToolStrip Button for open module
        /// </summary>
        /// <param name="strModuleName">Name of Module will be populated to toolstrip button</param>
        /// <returns></returns>
        private static ToolStripButton PopulateOpenModulesToolStripButton(string strModuleName)
        {
            var strModuleDesc =
                new STModuleDescriptionsController().GetDescriptionByModuleNameAndLanguageName(strModuleName,
                    CurrentLang);
            if (IsNullOrEmpty(strModuleDesc))
                strModuleDesc = strModuleName;

            var tsbtnOpenModules = new ToolStripButton(strModuleDesc, SectionImageList.Images[strModuleName],
                OpenModulesToolStrip_Click, strModuleName);
            tsbtnOpenModules.TextImageRelation = TextImageRelation.ImageBeforeText;
            tsbtnOpenModules.CheckOnClick = true;
            return tsbtnOpenModules;
        }


        /// <summary>
        ///     Set toolstripbutton of Open Module to checked
        /// </summary>
        /// <param name="tsbtnModule"></param>
        public static void CheckOpenModuleToolStripButton(ToolStripButton tsbtnModule)
        {
            tsbtnModule.Checked = true;
            foreach (ToolStripButton tsbtnOpenedModule in MainScreen.OpenModulesToolStrip.Items)
                if (tsbtnOpenedModule.Name != tsbtnModule.Name)
                    tsbtnOpenedModule.Checked = false;
        }


        /// <summary>
        ///     Delegate function for event click of Toolstrip Button Open Module
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">Event Arugment</param>
        private static void OpenModulesToolStrip_Click(object sender, EventArgs e)
        {
            var tsbtnModule = (ToolStripButton)sender;
            CheckOpenModuleToolStripButton(tsbtnModule);
            ShowModule(tsbtnModule.Name);
            //SetActiveGroupByModule(tsbtnModule.Name);
        }


        /// <summary>
        ///     Add open module to Open Modules Tool Strip
        /// </summary>
        /// <param name="strModuleName">Name of module will be added</param>
        public static void AddOpenModuleToOpenModulesToolStrip(string strModuleName)
        {
            var tsbtnModule = PopulateOpenModulesToolStripButton(strModuleName);
            MainScreen.OpenModulesToolStrip.Items.Add(tsbtnModule);
            tsbtnModule.Visible = true;
            CheckOpenModuleToolStripButton(tsbtnModule);
        }


        /// <summary>
        ///     Check the module is opened before or not
        /// </summary>
        /// <param name="strModuleName">Name of module is checked</param>
        /// <returns>true if is opened before, otherwise return false</returns>
        public static bool IsOpenedModule(string strModuleName)
        {
            return OpenModules.ContainsKey(strModuleName);
        }

        /// <summary>
        ///     Add new or update module into Opened Module list
        /// </summary>
        /// <param name="module">module will be added new or updated</param>
        public static void UpdateOpenedModule(BaseModuleERP module)
        {
            if (!IsOpenedModule(module.Name))
                OpenModules.Add(module.Name, module);
            else
                OpenModules[module.Name] = module;
        }

        /// <summary>
        ///     Remove module from Opened Module list
        /// </summary>
        /// <param name="module">Module will be removed</param>
        public static void RemoveOpenedModule(BaseModuleERP module)
        {
            if (IsOpenedModule(module.Name))
            {
                ((BaseModuleERP)OpenModules[module.Name]).Close();
                OpenModules.Remove(module.Name);
            }
        }

        /// <summary>
        ///     Remove module from Opened module list
        /// </summary>
        /// <param name="strModuleName">Module name will be removed</param>
        public static void RemoveOpenedModule(string strModuleName)
        {
            if (IsOpenedModule(strModuleName))
                OpenModules.Remove(strModuleName);
        }


        public static void CloseAllOpenModules()
        {
            for (var i = 0; i < OpenModules.Count; i++)
            {
                int count = OpenModules.Count;
                var module = (BaseModuleERP)OpenModules.GetByIndex(i);
                module.ParentScreen.Close();
                if (OpenModules.Count < count)
                    i--;
                else
                    //khong close dc module
                    break;
            }
        }

        #endregion

        #region Authentication
        public static bool IsAuthenticated(string strUserName, string strPassword)
        {
            var objAdUsersController = new ADUsersController();
            var objAdUsersInfo = (ADUsersInfo)objAdUsersController.GetObjectByName(strUserName.ToLower());
            if (objAdUsersInfo != null)
            {
                var encodedPassword =
                    Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(strPassword)));
                if (encodedPassword.Equals(objAdUsersInfo.ADPassword))
                    return true;
            }
            return false;
        }
        public static bool IsUserLoggedIn(string strUserName)
        {
            //Get iADUserID
            var objAdUsersController = new ADUsersController();
            var iAdUserId = objAdUsersController.GetObjectIDByName(strUserName);

            var objGeUserAuditsController = new GEUserAuditsController();
            return objGeUserAuditsController.IsExistUser(iAdUserId);
        }
        public static ADUsersInfo SetCurrentUserLogin(string strUserName)
        {
            var objAdUsersController = new ADUsersController();
            var objAdUsersInfo = (ADUsersInfo)objAdUsersController.GetObjectByName(strUserName);
            if (objAdUsersInfo == null) return null;

            CurrentUser = objAdUsersInfo.ADUserName;
            var objLanguageController = new GELanguagesController();
            var iLanguageId = ((ADUserGroupsInfo)new ADUserGroupsController().GetObjectByID(
                    objAdUsersController.GetUserGroupOfUser(objAdUsersInfo.ADUserID))).ADLanguageIDCombo;
            var objLanguageInfo = (GELanguagesInfo)objLanguageController.GetObjectByID(iLanguageId);
            if (objLanguageInfo != null)
                CurrentLang = objLanguageInfo.GELanguageName.Trim();

            GetAllUserConfigsAsync(objAdUsersInfo.ADUserID);

            GetAllObjectStatePermisionsAsync(objAdUsersInfo.ADUserGroupID);

            return objAdUsersInfo;
        }

        public static UserLoginHttpModel CurrentBacSi24X7
        {
            get { return Clas.Model.Doctor24x7.CurrentUser.CurrentBacSi24X7; }
            set { Clas.Model.Doctor24x7.CurrentUser.CurrentBacSi24X7 = value; }
        }
        public static HREmployeesInfo CurrentEmployeesInfo { get; private set; }
        public static string ApiToken { get; internal set; }
        #endregion

        #region Declared Variables
        public static string V100COMPort { get; set; }
        public static string FileVersion { get; set; }
        public static string AppLocation { get; set; }
        public static List<ADUserConfigsInfo> UserConfigs { get; set; }

        public static string EmrApiAuthToken { get; internal set; }
        public static string EmrApiSessionToken { get; internal set; }
        public static Dictionary<string, ObjectStatePermisionDto> ObjectStatePermisions { get; set; }
        #endregion

        #region Force Update
        internal static void ForceUpdateApp()
        {
            Cursor.Current = Cursors.WaitCursor;
            BOSProgressBar.Start("Đang kiểm tra phiên bản ứng dụng");

            // var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Crypto cryp = new Crypto();
            //var ftpHost = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_HOST), true);
            var ftpHost = SqlDatabaseHelper._PRIVATE_FTP_HOST;
            //_ftpPort = Convert.ToInt32(cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_PORT), true));
            var ftpUser = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_USER), true);
            var ftpPassword = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_PASSWORD), true);
            var ftpAppDir = cryp.DecryptNew(SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_FTP_APP_DIR), true);
            if (string.IsNullOrEmpty(ftpUser))
                ftpUser = "anonymous";

            try
            {
                var updaterDir = Application.StartupPath + @"\updater\";
                var updaterZip = "updater.zip";

                var tempDir = updaterDir + DateTime.Now.ToString("__yyyyddMM-HHmmss") + @"\";
                if (Directory.Exists(tempDir) == false)
                    Directory.CreateDirectory(tempDir);

                // create an FTP client
                FtpClient client = new FtpClient
                {
                    Host = ftpHost,
                    Credentials = new NetworkCredential(ftpUser, ftpPassword)
                };
                // begin connecting to the server
                client.Connect();
                client.DownloadFile(tempDir + "\\" + updaterZip, ftpAppDir + "/updater/" + updaterZip, FtpLocalExists.Overwrite);
                client.Disconnect();

                using (ZipFile zip = ZipFile.Read(tempDir + "\\" + updaterZip))
                {
                    zip.ExtractAll(tempDir);
                }

                FileInfo[] files = new DirectoryInfo(tempDir).GetFiles();
                foreach (FileInfo fi in files)
                {
                    if (fi.Name != updaterZip)
                        File.Copy(tempDir + fi.Name, updaterDir + fi.Name, true);
                }
                DirectoryInfo[] dirs = new DirectoryInfo(tempDir).GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    var localDir = updaterDir + dir.Name;
                    if (!Directory.Exists(localDir))
                        Directory.Move(dir.FullName, localDir);
                }
                if (Directory.Exists(tempDir))
                    Directory.Delete(tempDir, true);

                var verCtrl = new GEVersionsController();
                var newVersion = verCtrl.GetDbVersion();

                var updater = updaterDir + "ChcEmr.NextVer.exe";
                if (Directory.Exists(updaterDir))
                {
                    var nextVerPath = Directory.GetDirectories(updaterDir, "*", SearchOption.TopDirectoryOnly).OrderByDescending(f => f).FirstOrDefault();
                    updater = nextVerPath?.ToString() + @"\ChcEmr.NextVer.exe";
                }

                //old updater version
                if (!File.Exists(updater))
                    updater = updaterDir + "Updater.exe";

                const string appProcess = "CHC.EMR";
                var destDir = "\"" + Application.StartupPath + "\\";
                string cmd = "|ftpHost|" + ftpHost;
                cmd += "|ftpAppDir|" + ftpAppDir;
                cmd += "|ftpUser|" + ftpUser;
                cmd += "|ftpPw|" + ftpPassword;
                cmd += "|version|" + newVersion.ToString();
                cmd += "|destDir|" + destDir;
                cmd += "|appProcess|" + appProcess;
                cmd += "|fullUpdate|True";
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = updater,
                    Arguments = cmd
                };
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại. \n" + ex.ToString());
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                BOSProgressBar.Close();
            }
        }

        #endregion

        #region Machine info
        public static string GetMachineIp()
        {
            // No use
            //var staticIp = ConfigurationManager.AppSettings["machine-static-ip"]?.ToString();
            //if (!string.IsNullOrEmpty(staticIp)) return staticIp;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "INVALID IP";
        }
        public static string GetMachineMac()
        {
            // No use
            //var staticMac = ConfigurationManager.AppSettings["machine-static-mac"]?.ToString();
            //if (!string.IsNullOrEmpty(staticMac)) return staticMac;
            var networks = NetworkInterface.GetAllNetworkInterfaces();
            var activeNetworks = networks.Where(ni => ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback);
            var sortedNetworks = activeNetworks.OrderByDescending(ni => ni.Speed).Select(n => n.GetPhysicalAddress().ToString());
            return sortedNetworks.Where(a => a.Length >= 12).First().ToString();

            //return NetworkInterface.GetAllNetworkInterfaces()
            //                        .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            //                        .Select(nic => nic.GetPhysicalAddress().ToString())
            //                        .FirstOrDefault();
        }
        #endregion

        #region Signal App Recent Update
        public static void ConnectToSignalHub()
        {
            if (string.IsNullOrEmpty(EmrApiSessionToken))
            {
                SignalHubStatus("401");
                return;
            }
            Task.Run(async () =>
            {
                await ConnectToSignalHub(EmrApiAuthToken, EmrApiSessionToken);
            });
        }
        private static async Task ConnectToSignalHub(string authToken, string sessionToken)
        {
            if (_signalHubClient == null)
                _signalHubClient = new SignalHubClient(authToken, sessionToken);

            await _signalHubClient.ConnectAsync();
        }
        public static bool InvokeSignalHub(string action, params object[] paramValues)
        {
            if (_signalHubClient == null)
            {
                OnCommonSignalMessage(EmrConsts.SYS_HUB_SENDER, "Không có kết nối với hệ thống thông báo");
                return false;
            }
            _signalHubClient.Invoke(action, paramValues);
            return true;
        }
        internal static void SignalHubStatus(string status)
        {
            switch (status)
            {
                case "401":
                    OnCommonSignalMessage(EmrConsts.SYS_HUB_SENDER, "[Xác thực không thành công]. Không có kết nối với hệ thống thông báo");
                    break;
                case "ERROR":
                    OnCommonSignalMessage(EmrConsts.SYS_HUB_SENDER, "[Có lỗi] khi kết nối với hệ thống thông báo");
                    break;
                case "CONNECTING":
                    OnCommonSignalMessage(EmrConsts.SYS_HUB_SENDER, "[Đang kết nối] với hệ thống thông báo");
                    break;
                case "CONNECTED":
                    OnCommonSignalMessage(EmrConsts.SYS_HUB_SENDER, "[Đã kết nối] với hệ thống thông báo");
                    break;
                case "RECONNECTING":
                    OnCommonSignalMessage(EmrConsts.SYS_HUB_SENDER, "[Đang kết nối lại] với hệ thống thông báo");
                    break;
                case "DISCONNECTED":
                    OnCommonSignalMessage(EmrConsts.SYS_HUB_SENDER, "[Đã ngắt kết nối] với hệ thống thông báo");
                    break;
                default:
                    break;
            }
            status = "HUB: " + status;
            if (!BOSApp.MainScreen.IsDisposed)
            {
                if (BOSApp.MainScreen.InvokeRequired)
                    BOSApp.MainScreen.BeginInvoke((Action)(() =>
                    {
                        MainScreen.signalItem.Caption = status;
                    }));
                else
                    MainScreen.signalItem.Caption = status;
            }
        }
        internal static void RequestAppUpdate(string msg)
        {
            var verCtrl = new GEVersionsController();
            var newVersion = verCtrl.GetDbVersion();
            var checkVersion = verCtrl.CheckVersion(newVersion, BOSApp.FileVersion);
            // da update ver tren db
            if (checkVersion < 0)
            {
                if (string.IsNullOrEmpty(msg))
                    msg = "Phiên bản mới " + newVersion.ToString() + " đã sẵn sàng.\n Vui lòng tắt ứng dụng và mở lại để tải bản cập nhật mới nhất. \n" +
                        "LỖI CÓ THỂ SẼ XẢY RA NẾU BẠN VẪN TIẾP TỤC SỬ DỤNG PHIÊN BẢN CŨ.\n" +
                        "OK để tắt ứng dụng. Cancel để sau.";
                if (BOSApp.MainScreen.InvokeRequired)
                    BOSApp.MainScreen.BeginInvoke((Action)(() =>
                    {
                        if (MessageBox.Show(msg, "Cập nhật phiên bản mới", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            BOSApp.MainScreen.Close();
                    }));
                else
                {
                    if (MessageBox.Show(msg, "Cập nhật phiên bản mới", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        BOSApp.MainScreen.Close();
                }
            }
        }

        public static void OnCommonSignalMessage(string sender, string msg)
        {
            if (BOSApp.MainScreen.InvokeRequired)
                BOSApp.MainScreen.BeginInvoke((Action)(() =>
                {
                    BOSApp.MainScreen.ShowSignalMessage(sender, msg);
                }));
            else
            {
                BOSApp.MainScreen.ShowSignalMessage(sender, msg);
            }
        }
        #endregion

        #region User Config
        public static void GetAllUserConfigsAsync(int userID)
        {
            var thread1 = new Thread(() => GetAllUserConfigs(userID));
            thread1.Start();
        }

        public static IEnumerable<ADUserConfigsInfo> GetAllUserConfigs(int userID)
        {
            BOSApp.UserConfigs = (new ADUserConfigsController()).GetAllUserConfigs(userID);
            return BOSApp.UserConfigs;
        }
        public static ADUserConfigsInfo GetQuickAccessToolbarConfig()
        {
            return BOSApp.UserConfigs.Where(c => c.ADUserConfigKey == UserCfgConsts.EMR_QUICK_ACCESS_TOOLBAR).FirstOrDefault();
        }

        public static ADUserConfigsInfo GetAutoHideRibbonConfig()
        {
            return BOSApp.UserConfigs.Where(c => c.ADUserConfigKey == UserCfgConsts.EMR_MINIMIZE_RIBBON).FirstOrDefault();
        }
        public static bool GetBooleanUserConfig(string key, bool defaultValue)
        {
            var config = BOSApp.UserConfigs.Where(c => c.ADUserConfigKey == key).FirstOrDefault();
            if (config == null) return defaultValue;
            return config.ADUserConfigValue.ToUpper() == "TRUE";
        }
        public static ADUserConfigsInfo SaveMoveBetweenTagByTabConfig()
        {
            return SwitchUserBooleanCommonConfig(UserCfgConsts.MOVE_BETWEEN_TAG_BY_TAB,
              false,
             "BẬT/TẮT chức năng di huyển giữa các thẻ bằng phím TAB",
             "Giá trị = TRUE/FALSE");
        }
        public static ADUserConfigsInfo SaveClickThenAutoMoveToNextTagConfig()
        {
            return SwitchUserBooleanCommonConfig(UserCfgConsts.CLICK_THEN_MOVE_TO_NEXT_TAG,
               true,
              "BẬT/TẮT tự động chuyển đến thẻ tiếp theo gần nhất khi click chuột ngoài thẻ",
              "Giá trị = TRUE/FALSE");
        }
        public static ADUserConfigsInfo SaveUserHighlightEmrTagConfig()
        {
            return SwitchUserBooleanCommonConfig(UserCfgConsts.HIGHLIGHT_EMR_TAG,
                false,
                "BẬT/TẮT chức năng highlight thẻ",
                "Giá trị = TRUE/FALSE");
        }
        public static ADUserConfigsInfo SwitchUserBooleanCommonConfig(string key, bool initValue, string text, string desc)
        {
            var config = BOSApp.UserConfigs.Where(c => c.ADUserConfigKey == key).FirstOrDefault();
            var value = initValue.ToString().ToUpper();
            if (config != null)
                value = config.ADUserConfigValue == "TRUE" ? "FALSE" : "TRUE";

            return SaveUserCommonConfig(key, value, text, desc);
        }
        public static ADUserConfigsInfo SaveUserCommonConfig(string key, string value, string text, string desc)
        {
            var config = BOSApp.UserConfigs.Where(c => c.ADUserConfigKey == key).FirstOrDefault();
            var userConfigCtrl = new ADUserConfigsController();
            if (config == null)
            {
                config = new ADUserConfigsInfo()
                {
                    FK_ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                    AAStatus = "Alive",
                    IsActive = true,
                    ADUserConfigGroup = UserCfgConsts.COMMON_GROUP,
                    ADUserConfigKey = key,
                    ADUserConfigValue = value,
                    ADUserConfigText = text,
                    ADUserConfigDesc = desc
                };
                userConfigCtrl.CreateObject(config);
                BOSApp.UserConfigs.Add(config);
            }
            else
            {
                config.ADUserConfigValue = value;
                userConfigCtrl.UpdateObject(config);
            }
            return config;
        }

        #endregion

        #region System config
        public static void GetSystemConfigs()
        {
            var systemCfgCtrl = new ADSystemConfigsController();

            var configs = systemCfgCtrl.GetListByGroups($"'{SysCfgConsts.WORKFLOW_CONFIGS}','{SysCfgConsts.SYSTEM_CONFIGS}', '{EmrProcess.GROUP}','{DocumentProcess.GROUP}', '{SysCfgConsts.EMR_API_ENDPOINT}'");

            var results = configs.GroupBy(c => c.ADSystemConfigGroup,
                                            (group, children) => new
                                            {
                                                Group = group,
                                                Children = children.ToList()
                                            });
            // XUANTM: Must use code in Program line 35.
            //SystemMemCache.SysConfigs = new Dictionary<string, Dictionary<string, string>>();
            foreach (var item in results)
            {
                SystemMemCache.SysConfigs.Add(item.Group, item.Children.ToDictionary(c => c.ADSystemConfigKey, c => c.ADSystemConfigValue));
            }
        }

        public static void GetPrivateConfigs()
        {
            var systemCfgCtrl = new ADSystemConfigsController();
            var configs = systemCfgCtrl.GetListByGroup(SysCfgConsts.PRIVATE);
            SystemMemCache.SysConfigs = new Dictionary<string, Dictionary<string, string>>
            {
                { SysCfgConsts.PRIVATE, configs.ToDictionary(c => c.ADSystemConfigKey, c => c.ADSystemConfigValue) }
            };
        }

        public static string GetSystemConfigValue(string group, string key)
        {
            return SystemMemCache.GetSystemConfigValue(group, key);
        }
        public static int GetSystemConfigValueInt(string group, string key, int defaultValue)
        {
            if (int.TryParse(SystemMemCache.GetSystemConfigValue(group, key), out int value))
                return value;
            return defaultValue;
        }
        #endregion

        #region Object state permission
        public static void GetAllObjectStatePermisionsAsync(int userGroupID)
        {
            var thread1 = new Thread(() => GetAllObjectStatePermisions(userGroupID));
            thread1.Start();
        }
        public static void GetAllObjectStatePermisions(int userGroupID)
        {
            ObjectStatePermisions = new Dictionary<string, ObjectStatePermisionDto>();
            var permissionCtrl = new STObjectStatePermissionsController();
            var permissions = permissionCtrl.GetPermissionByUserGroupID(userGroupID);
            var tables = permissions.GroupBy(p => p.STObjectStatePermissionTable, (table, cols) => new { TableName = table, Cols = cols.ToList() }).ToList();
            foreach (var table in tables)
            {
                var permission = new ObjectStatePermisionDto
                {
                    View = new Dictionary<string, string[]>(),
                    Edit = new Dictionary<string, string[]>(),
                    Delete = new Dictionary<string, string[]>()
                };
                var cols = table.Cols.GroupBy(p => p.STObjectStatePermissionCol, (col, pers) => new { ColName = col, Permissions = pers.ToList() }).ToList();
                foreach (var col in cols)
                {
                    permission.View.Add(col.ColName, col.Permissions.Where(p => p.STObjectStatePermissionView).Select(p => p.STObjectStatePermissionVal).ToArray());
                    permission.Edit.Add(col.ColName, col.Permissions.Where(p => p.STObjectStatePermissionEdit).Select(p => p.STObjectStatePermissionVal).ToArray());
                    permission.Delete.Add(col.ColName, col.Permissions.Where(p => p.STObjectStatePermissionDelete).Select(p => p.STObjectStatePermissionVal).ToArray());
                }
                ObjectStatePermisions.Add(table.TableName, permission);
            }
        }
        /// <summary>
        /// Get all permission by action
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="action">VIEW|UPDATE|DELETE</param>
        /// <returns>null is allow all</returns>
        public static Dictionary<string, string[]> GetObjectStatePermisions(string tableName, ObjectStatePermissionAction action)
        {
            if (ObjectStatePermisions == null) return null;
            if (!ObjectStatePermisions.TryGetValue(tableName, out ObjectStatePermisionDto permis))
                return null;

            switch (action)
            {
                case ObjectStatePermissionAction.View:
                    return permis.View;
                case ObjectStatePermissionAction.Edit:
                    return permis.Edit;
                case ObjectStatePermissionAction.Delete:
                    return permis.Delete;
                default:
                    break;
            }
            return null;
        }
        #endregion

        #region Default Module
        internal static void SaveDefaultModuleConfig()
        {
            var config = BOSApp.UserConfigs.Where(c => c.ADUserConfigKey == UserCfgConsts.DEFAULT_MODULE).FirstOrDefault();
            var userConfigCtrl = new ADUserConfigsController();
            if (config == null)
            {
                config = new ADUserConfigsInfo()
                {
                    FK_ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                    AAStatus = "Alive",
                    IsActive = true,
                    ADUserConfigGroup = UserCfgConsts.COMMON_GROUP,
                    ADUserConfigKey = UserCfgConsts.DEFAULT_MODULE,
                    ADUserConfigValue = GetCurentOpenModuleName(),
                    ADUserConfigText = "Module mặc định",
                    ADUserConfigDesc = "Cấu hình Module mặc định mở sau khi người dùng đăng nhập"
                };
                userConfigCtrl.CreateObject(config);
            }
            else
            {
                config.ADUserConfigValue = GetCurentOpenModuleName();
                userConfigCtrl.UpdateObject(config);
            }
            GetAllUserConfigsAsync(CurrentUsersInfo.ADUserID);
            MessageBox.Show("Đã lưu cấu hình", "Đã lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private static string GetUserConfigDefaultModule()
        {
            var config = BOSApp.UserConfigs.Where(c => c.ADUserConfigKey == UserCfgConsts.DEFAULT_MODULE).FirstOrDefault();
            if (config == null) return "Welcome";
            return config.ADUserConfigValue;
        }
        private static string GetCurentOpenModuleName()
        {
            return BOSApp.CurrentModule;
        }

        #endregion

        #region App Cache
        internal static void SaveUseAppCachingConfig()
        {
            //neu cau hinh toan he thong mode != production thi khong dung cache
            var mode = GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_RUNNING_MODE);
            if (mode != SysCfgConsts.SYSTEM_CONFIGS_RUNNING_MODE_PRODUCTION)
            {
                MessageBox.Show($"Hệ thống đang vận hành ở chế độ [{mode}]. " +
                    $"Ở chế độ này mặc định bộ nhớ đệm [ĐÃ TẮT] và không thể bật theo người dùng",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var config = BOSApp.UserConfigs.Where(c => c.ADUserConfigKey == UserCfgConsts.USE_MEMORY_CACHING).FirstOrDefault();
            var userConfigCtrl = new ADUserConfigsController();
            if (config == null)
            {
                config = new ADUserConfigsInfo()
                {
                    FK_ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                    AAStatus = "Alive",
                    IsActive = true,
                    ADUserConfigGroup = UserCfgConsts.COMMON_GROUP,
                    ADUserConfigKey = UserCfgConsts.USE_MEMORY_CACHING,
                    ADUserConfigValue = "TRUE",
                    ADUserConfigText = "Sử dụng bộ nhớ đệm",
                    ADUserConfigDesc = "Giúp tăng tốc độ ứng dụng. Tuy nhiên không nên dùng nếu đang cấu hình bệnh án."
                };
                userConfigCtrl.CreateObject(config);
            }
            else
            {
                config.ADUserConfigValue = config.ADUserConfigValue == "TRUE" ? "FALSE" : "TRUE";
                userConfigCtrl.UpdateObject(config);
            }
            GetAllUserConfigsAsync(CurrentUsersInfo.ADUserID);

            MessageBox.Show("Bật bộ nhớ đệm giúp tăng tốc độ ứng dụng. " +
                "Tuy nhiên không nên dùng nếu đang cấu hình bệnh án. [Khởi động lại chương trình] để cập nhật thay đổi" +
                "\nTrạng thái bộ nhớ đệm: " + (config.ADUserConfigValue == "TRUE" ? "[ĐÃ BẬT]" : "[ĐÃ TẮT]"),
                "Đã lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private static bool GetUseAppCacheConfig()
        {
            //neu cau hinh toan he thong mode != production thi khong dung cache
            if (GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_RUNNING_MODE) != SysCfgConsts.SYSTEM_CONFIGS_RUNNING_MODE_PRODUCTION)
                return false;
            var config = BOSApp.UserConfigs.Where(c => c.ADUserConfigKey == UserCfgConsts.USE_MEMORY_CACHING).FirstOrDefault();
            //mac dinh o mode production thi se dung cache
            if (config == null) return true;
            //nguoi dung co the override
            return config.ADUserConfigValue == "TRUE";
        }
        #endregion

        #region Check Document HoldOn
        private static void CheckDocumentHoldOn(int currentUser)
        {
            var emrDocumentController = new MEEmrDocumentsController();
            var documents = emrDocumentController.GetAllByUserHoldon(currentUser);
            if (documents != null && documents.Count > 0)
            {
                new guiDocumentRelease(documents, CurrentUsersInfo.FK_HREmployeeID).ShowDialog();
            }
        }
        #endregion

        #region User Permission
        public static string GetUserEmrViewPermission()
        {
            return string.IsNullOrEmpty(BOSApp.CurrentUsersInfo.ADUserEmrView) ? BOSApp.CurrentUserGroupInfo.ADUserGroupEmrView : BOSApp.CurrentUsersInfo.ADUserEmrView;
        }
        #endregion

        #region Move Error EmrDocuments
        private static void MoveErrorDocuments()
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                FileTemplateManager _ftpFileMng = new FileTemplateManager();
                var emrDocumentController = new MEEmrDocumentsController();

                var dirLocal = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_TEMPLATE_SERVER_PATH);
                if (!dirLocal.Contains(":\\")) // đường dẫn tương đối
                    dirLocal = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + dirLocal;
                var dirEmrLocal = Path.Combine(dirLocal, "Emr");
                var uploadErrs = "UploadErrs";
                var encryptErrs = "EncryptErrs";
                Directory.CreateDirectory(Path.Combine(dirLocal, uploadErrs));
                Directory.CreateDirectory(Path.Combine(dirLocal, encryptErrs));

                var dirExcepts = new List<string> { "Partials", "Signed" };

                var filesSearch = Directory.EnumerateFiles(dirEmrLocal, "*.bk.*", SearchOption.AllDirectories)
                    .Where(s => !dirExcepts.Any(d => Path.GetDirectoryName(s).Contains(d)));

                foreach (var fileBk in filesSearch)
                {
                    var pathEmr = Path.GetDirectoryName(fileBk);
                    var fileName = Path.GetFileName(fileBk);
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileBk);
                    var extension = Path.GetExtension(fileBk).TrimStart('.');
                    var emrId = new DirectoryInfo(pathEmr).Name;
                    var parts = fileNameWithoutExtension.Split('.');
                    var fileN = parts.ElementAt(0);
                    var fKHREmployeeID = parts.ElementAt(1);
                    var dateTimeFile = parts.ElementAt(2);
                    var typeFile = parts.ElementAt(3);
                    var targetType = uploadErrs;
                    if (typeFile == "upload")
                    {
                        var emrDocumentE = emrDocumentController.GetObjectByEmrAndFile(Convert.ToInt32(emrId), fileN, extension);
                        if (emrDocumentE != null)
                        {
                            if (emrDocumentE.FK_EditingUserID == 0 || emrDocumentE.FK_EditingUserID == CurrentEmployeesInfo.HREmployeeID)
                            {
                                var genBKFile = $"{fileN}.{fKHREmployeeID}.{emrDocumentE.AAUpdatedDate.ToString("ddMMyyyyHHmmss")}.upload.bk.docx";
                                if (fileName == genBKFile)
                                {
                                    string orginalFileName = $"\\Emr\\{emrId}\\{fileN}.{extension}";
                                    string orginalFileNameTarget = $"\\Emr\\{emrId}\\{fileN}.org.{extension}";
                                    _ftpFileMng.RenameFile(orginalFileName, orginalFileNameTarget);

                                    _ftpFileMng.UploadFile($"\\Emr\\{emrId}\\", $"{fileN}.{extension}", fileBk);
                                }
                            }
                        }
                    }
                    else
                    {
                        targetType = encryptErrs;
                    }
                    var targetPath = Path.Combine(targetType, fKHREmployeeID, emrId);

                    _ftpFileMng.CreateDirectory("/" + targetPath);
                    _ftpFileMng.UploadFile("/" + targetPath + "/", fileName, fileBk);

                    var targetLocal = Path.Combine(dirLocal, targetPath, fileName);
                    Directory.CreateDirectory(Path.Combine(dirLocal, targetPath));
                    File.Move(fileBk, targetLocal);
                }
            }
            catch (Exception ex) { }
        }
        #endregion

        #region Change Department - Doi khoa phong lam viec
        private static void InitCurrentDepartmentSession(List<HRDepartmentsInfo> workingDepts)
        {
            var dept = workingDepts.Where(d => d.HRDepartmentID == CurrentEmployeesInfo.FK_HRDepartmentID).FirstOrDefault();
            ChangeCurrentDepartment(dept);
            if (workingDepts.Count > 1)
            {
                workingDepts = workingDepts.OrderBy(d => d.HRDepartmentName).ToList();
                var items = new List<BarButtonItem>();
                foreach (var item in workingDepts)
                {
                    if (item.HRDepartmentID == CurrentEmployeesInfo.FK_HRDepartmentID) continue;
                    var btn = new BarButtonItem(MainScreen.BarManager, item.HRDepartmentName)
                    {
                        Caption = item.HRDepartmentName,
                        Name = "barBtnChangeDepartment" + item.HRDepartmentID,
                        Id = MainScreen.BarManager.GetNewItemId(),
                        Tag = item.HRDepartmentID,
                    };
                    btn.ItemClick += BarBtnChangeDepartment_ItemClick;
                    items.Add(btn);
                }

                var btnCurrent = new BarButtonItem(MainScreen.BarManager, dept.HRDepartmentName)
                {
                    Caption = dept.HRDepartmentName,
                    Name = "barBtnChangeDepartment" + dept.HRDepartmentID,
                    Id = MainScreen.BarManager.GetNewItemId(),
                    Tag = dept.HRDepartmentID,
                };
                btnCurrent.ItemClick += BarBtnChangeDepartment_ItemClick;
                items.Add(btnCurrent);

                MainScreen.BarBtnChangeDepartment.DropDownControl = MainScreen.BarManager.Items.CreatePopupMenu(items.ToArray());
            }
            else
            {
                MainScreen.BarBtnChangeDepartment.DropDownControl = null;
            }
        }
        private static void ChangeCurrentDepartment(HRDepartmentsInfo dept)
        {
            var deptName = string.Empty;
            if (dept != null) deptName = dept.HRDepartmentName;
            InitMainFormTitle(_currentCompanyInfo.CSCompanyDesc, deptName);
            MainScreen.BarBtnChangeDepartment.Caption = deptName.ToUpper();
            CurrentDepartmentInfo = dept;
        }
        private static void BarBtnChangeDepartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            var btn = e.Item as BarButtonItem;
            if (btn.Tag == null) return;
            var deptId = (int)btn.Tag;
            if (deptId == CurrentEmployeesInfo.FK_HRDepartmentID) return;

            if (OpenModules.Count > 0)
                if (MessageBox.Show("Các module đang mở sẽ được đóng và mở lại sau khi đổi khoa phòng. Đảm bảo các thao tác dữ liệu đã được lưu?",
                    "THAY ĐỔI KHOA PHÒNG LÀM VIỆC", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;

            CurrentEmployeesInfo.FK_HRDepartmentID = deptId;
            var dept = (new HRDepartmentsController()).GetObjectByID(CurrentEmployeesInfo.FK_HRDepartmentID) as HRDepartmentsInfo;
            ChangeCurrentDepartment(dept);
            var openModules = new List<string>();
            for (int i = 0; i < OpenModules.Count; i++)
            {
                openModules.Add((OpenModules.GetByIndex(i) as BaseModuleERP).Name);
            }
            CloseAllOpenModules();
            foreach (string item in openModules)
            {
                ShowModule(item);
            }
        }
        #endregion
        #region Tab Notification
        internal static void SaveNotificationTabConfig()
        {
            var config = BOSApp.UserConfigs.Where(c => c.ADUserConfigKey == UserCfgConsts.EMR_NOTIFICATION_TAB).FirstOrDefault();
            var userConfigCtrl = new ADUserConfigsController();
            if (config == null)
            {
                config = new ADUserConfigsInfo()
                {
                    FK_ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                    AAStatus = "Alive",
                    IsActive = true,
                    ADUserConfigGroup = UserCfgConsts.EMR_MODULE_GROUP,
                    ADUserConfigKey = UserCfgConsts.EMR_NOTIFICATION_TAB,
                    ADUserConfigValue = "TRUE",
                    ADUserConfigText = "Sử dụng thẻ thông báo BAĐT",
                    ADUserConfigDesc = "Thông báo làm giảm hiệu năng EMR, sử dụng khi có nhu cầu."
                };
                userConfigCtrl.CreateObject(config);
            }
            else
            {
                config.ADUserConfigValue = config.ADUserConfigValue == "TRUE" ? "FALSE" : "TRUE";
                userConfigCtrl.UpdateObject(config);
            }
            GetAllUserConfigsAsync(CurrentUsersInfo.ADUserID);

            MessageBox.Show("Bật / tắt thẻ thông báo BAĐT." +
                "Thẻ thông báo làm giảm hiệu năng EMR, sử dụng khi có nhu cầu." +
                "\nTrạng thái thẻ thông báo BAĐT: " + (config.ADUserConfigValue == "TRUE" ? "[ĐÃ BẬT]" : "[ĐÃ TẮT]" +
                "\nÁp dụng sau khi đăng nhập lại."),
                "Đã lưu.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static ADUserConfigsInfo GetNotificationTabConfig()
        {
            return BOSApp.UserConfigs.Where(c => c.ADUserConfigKey == UserCfgConsts.EMR_NOTIFICATION_TAB).FirstOrDefault();
        }
        #endregion
        #region Recovery Document
        public static Task<int> OnRequestRecoveryDocument(int emrId, string file, string hash)
        {
            return Task.Factory.StartNew<int>(() =>
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var documentPath = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_TEMPLATE_SERVER_PATH);
                if (!documentPath.Contains(":\\")) // đường dẫn tương đối
                    documentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + documentPath;

                var dir = Path.Combine(documentPath, "Emr", emrId.ToString());
                if (Directory.Exists(dir))
                {
                    var uploader = new Clas.Business.Ftp.FileTemplateManager();
                    var docx = "." + EmrDocumentFileExtention.docx.ToString();
                    string filePath = Path.Combine(dir, $"{file}_MD5{hash}{docx}");
                    string mac = GetMachineMac();
                    string ip = GetMachineIp();
                    var result = -1;
                    if (File.Exists(filePath))
                    {
                        //neu tim thay file phu hop thi ghi de noi dung len ftp luon
                        try
                        {
                            var from = $"/Emr/{emrId}/{file}{docx}";
                            var to = $"/Emr/{emrId}/{file}_bak_before_recovered{docx}";
                            var localPath = Path.Combine(documentPath, "Emr", emrId.ToString(), $"{file}_bak_before_recovered{docx}");
                            uploader.CopyFile(from, to, localPath);
                        }
                        catch (Exception) {/*do no thing*/}

                        uploader.UploadFile($"/Emr/{emrId}/", file + docx, filePath);
                        result = 1;
                    }
                    //up toan bo len de admin xu ly
                    foreach (var f in Directory.GetFiles(dir, $"{file}*{docx}"))
                    {
                        if (f == filePath) continue;
                        FileInfo fi = new FileInfo(f);
                        if (fi.Length > 0)
                        {
                            var localName = $"{Path.GetFileNameWithoutExtension(f)}_recovered_{SanitizedFileName.Sanitize($"{BOSApp.CurrentUser}_{mac}_{ip}", "_")}{docx}";
                            uploader.UploadFile($"/Emr/{emrId}/", localName, f);
                            if (result == -1) result = 0;
                        }
                    }
                    return result;
                }
                return -1;
            });
        }
        #endregion

        #region Detect Devide
        public static string ModeScreen { get; set; }
        public static void DetectDevide(int input)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            // input = 1: choose devide (Views / Chọn loại thiết bị)
            if (input == 1)
            {
                var guiDevide = new guiDevide();
                guiDevide.ShowDialog();
                if (!string.IsNullOrEmpty(guiDevide.Devide))
                {
                    var devide = guiDevide.Devide;
                    var devideConfig = Path.Combine(Application.StartupPath, "device_type.cfg");
                    devide = !IsNullOrEmpty(devide) ? devide : Devide.Desktop;
                    if (File.Exists(devideConfig))
                    {
                        using (StreamWriter w = new StreamWriter(devideConfig, false))
                        {
                            w.WriteLine($"devide:{devide}");
                        }
                    }
                    else
                    {
                        // Backup file missing physical
                        using (StreamWriter w = new StreamWriter(devideConfig, true))
                        {
                            w.WriteLine($"devide:{devide}");
                        }
                    }
                }
            }

            Devide.Current = dbUtil.DetectDevide();
        }
        #endregion

        #region Finger Print
        public static void LoadUserFingerprints(int userId)
        {
            var controller = new ADUserFingerprintsController();
            UserFingerprints = controller.GetUserFingerprintsByUser(userId);
            UserFingerprintFmds = new Dictionary<int, Fmd>();
            foreach (var finger in UserFingerprints)
            {
                try
                {
                    if (UserFingerprintFmds.TryGetValue(finger.ADUserFingerprintIndex, out Fmd fmd))
                    {
                        UserFingerprintFmds[finger.ADUserFingerprintIndex] = Fmd.DeserializeXml(finger.ADUserFingerprintXml);
                    }
                    else
                    {
                        fmd = Fmd.DeserializeXml(finger.ADUserFingerprintXml);
                        UserFingerprintFmds.Add(finger.ADUserFingerprintIndex, fmd);
                    }
                }
                catch (Exception)
                {
                    /*do nothing*/
                }
            }
        }
        public static void LoadUserFingerprintsZKTeco(int userId)
        {
            var controller = new ADUserFingerprintsZKTecoController();
            UserFingerprintsZKTeco = controller.GetUserFingerprintsByUser(userId);
        }
        #endregion

        private static bool DiffTimeServer()
        {
            var minuteAllow = GetSystemConfigValueInt(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_CLIENT_SERVER_MAX_DIFF_TIME, 3);
            var serverTime = GetCurrentServerDate();
            var localTime = DateTime.Now;
            if ((serverTime - localTime).TotalMinutes > minuteAllow)
            {
                return true;
            }
            if ((localTime - serverTime).TotalMinutes > minuteAllow)
            {
                return true;
            }
            return false;
        }

        #region Password Update
        public static void PasswordUpdate()
        {
            var guiPasswordUpdate = new guiPassword();
            guiPasswordUpdate.ShowDialog();
        }
        #endregion
    }
}