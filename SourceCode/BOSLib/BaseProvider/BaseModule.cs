using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;

namespace BOSLib
{
    public class BaseModule
    {
        #region Constructor
        private readonly STFieldFormatGroupsController _objFieldFormatGroupsController;
        public BaseModule()
        {
            Toolbar = new BaseToolbar();
            Screens = new List<BOSScreen>();
            Controls = new ControlCollection();
            FormatGroups = new List<STFieldFormatGroupsInfo>();
            _objFieldFormatGroupsController = new STFieldFormatGroupsController();
        }

        #endregion

        /// <summary>
        ///     Get format group the column is set to
        /// </summary>
        /// <param name="tableName">Name of the table the column belongs to</param>
        /// <param name="columnName">Name of the given column</param>
        /// <returns>Format group object</returns>
        public virtual STFieldFormatGroupsInfo GetColumnFormat(string tableName, string columnName)
        {
            var objFieldFormatGroupsInfo =
                FormatGroups.FirstOrDefault(fg => fg.TableName == tableName && fg.ColumnName == columnName);
            if (objFieldFormatGroupsInfo != null) return objFieldFormatGroupsInfo;
            //Find property binding to this column then get its format group attribute
            FormatGroupAttribute formatGroupAttr = null;
            var obj = BusinessObjectFactory.GetBusinessObject(tableName + "Info");
            var prop = obj?.GetType().GetProperty(columnName);
            var attrs = prop?.GetCustomAttributes(typeof(FormatGroupAttribute), true);
            if (attrs?.Length > 0)
                formatGroupAttr = (FormatGroupAttribute)attrs[0];
            if (formatGroupAttr != null)
                objFieldFormatGroupsInfo =
                    (STFieldFormatGroupsInfo)
                    _objFieldFormatGroupsController.GetObjectByName(formatGroupAttr.FormatGroup);

            //Get format group directly from database based on table name and column name
            return objFieldFormatGroupsInfo ??
                   (_objFieldFormatGroupsController.GetFieldFormatGroupByTableNameAndColumnName(tableName, columnName));
        }

        #region "Constant for Module"

        public const string cstHomeModule = "Home";
        public const string cstCustomerModule = "Customer";
        public const string cstSupplierModule = "Supplier";
        public const string cstProductModule = "Product";
        public const string cstAccountModule = "Account";
        public const string cstStockModule = "Stock";
        public const string cstPriceListModule = "PriceList";
        public const string cstTemplateModule = "Template";
        public const string cstSellerModule = "Seller";

        public const string cstUserManagementModule = "UserManagement";
        public const string cstBOSActivationModule = "BOSActivation";

        public const string cstMatchCodeModule = "MatchCode";
        public const string cstNumberingModule = "Numbering";
        public const string cstReportModule = "Report";

        #endregion

        #region Constant for Screen Type

        /// <summary>
        ///     Constant define screen is data main
        /// </summary>
        public const string cstDataMainScreen = "DM";

        /// <summary>
        ///     Constant define screen is search main
        /// </summary>
        public const string cstSearchMainScreen = "SM";

        /// <summary>
        ///     Constant define Screen is Search Results
        /// </summary>
        public const string cstSearchResultsScreen = "SR";

        /// <summary>
        ///     Constant define Screen is Data Sub
        /// </summary>
        public const string cstDataSubScreen = "DS";

        #endregion

        #region "Constant for Module Status"

        /// <summary>
        ///     Constant define Module is open
        /// </summary>
        public const string cstModuleStatusOpen = "Open";

        /// <summary>
        ///     Constant define Module is hibernate
        /// </summary>
        public const string cstModuleStatusHibernate = "Hibernate";

        /// <summary>
        ///     Constant define module is close
        /// </summary>
        public const string cstModuleStatusClose = "Close";

        /// <summary>
        ///     Constant define module is hide
        /// </summary>
        public const string cstModuleStatusHide = "Hide";

        #endregion

        #region "Constant for Show Module"

        /// <summary>
        ///     Constant define modus which module will be showed is Normal
        /// </summary>
        public const string cstModusNormal = "Normal";

        /// <summary>
        ///     Constant define modus which module will be showed is Search
        /// </summary>
        public const string cstModusSearch = "Search";

        #endregion

        #region Constant for User Audit Action

        public const string cstUserAuditNothing = "Nothing";
        public const string cstUserAuditNew = "Create";
        public const string cstUserAuditEdit = "Edit";

        #endregion

        #region Constant for Object History Action

        public const string cstObjectHistoryActionNew = "Create";
        public const string cstObjectHistoryActionChange = "Change";
        public const string cstObjectHistoryActionDelete = "Delete";
        public const string cstObjectHistoryActionRevokeEditPer = "RevokeEditPer";
        public const string cstObjectHistoryActionReOpen = "ReOpen";
        public const string cstObjectHistoryActionError = "Error";
        public const string cstObjectHistoryActionMerge = "Merge";
        #endregion

        #region variables

        /// <summary>
        ///     Variable define Name of Module
        /// </summary>
        protected string _name = string.Empty;

        /// <summary>
        ///     Variable define Code of Module
        /// </summary>
        protected string _code = string.Empty;

        /// <summary>
        ///     Variable define Screen collection of Module
        /// </summary>
        public List<BOSScreen> Screens;

        /// <summary>
        ///     Variable define Control collection of module
        /// </summary>
        public ControlCollection Controls;

        /// <summary>
        ///     Variable define Active Screen
        /// </summary>
        protected BOSScreen _activateScreen;

        /// <summary>
        ///     Variable define toolbar of module
        /// </summary>
        public BaseToolbar Toolbar;

        public WaitDialogForm WaitDialog;

        #endregion

        #region Public properties

        public int ModuleID { get; set; }

        /// <summary>
        ///     Gets,sets Module Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        ///     Gets,sets Module Code
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        ///     Gets,sets active Screen of modle
        /// </summary>
        public BOSScreen ActiveScreen
        {
            get { return _activateScreen; }
            set
            {
                _activateScreen = value;
                _activateScreen.Activate();
            }
        }

        /// <summary>
        ///     Gets or sets the format group list of table columns of the module
        /// </summary>
        public List<STFieldFormatGroupsInfo> FormatGroups { get; set; }

        #endregion

        #region Get Control Functions

        /// <summary type="GetControl">
        ///     Get Control by Name
        /// </summary>
        /// <param name="strControlName"></param>
        /// <returns></returns>
        public Control GetControlByName(string strControlName)
        {
            return Controls[strControlName];
        }


        /// <summary type="Check">
        ///     Determine module contains this control or not
        /// </summary>
        /// <param name="strControlName"></param>
        /// <returns></returns>
        public bool Contains(string strControlName)
        {
            return Controls[strControlName] != null;
        }

        #endregion

        #region Show Module functions

        /// <summary type="Show">
        ///     Showw all main screens of module
        /// </summary>
        protected void ShowAllMainScreens()
        {
            foreach (var t in Screens)
            {
                var scr = t;
                var strScreenNumber = t.ScreenNumber;
                if (strScreenNumber.StartsWith("DM") || strScreenNumber.StartsWith("SM") ||
                    strScreenNumber.StartsWith("SR"))
                    ShowScreen(scr, true);
            }
        }

        /// <summary type="Show">
        ///     Show specific screen
        /// </summary>
        /// <param name="scr">Screen to be showned</param>
        /// <param name="bIsChild">Define the screen is child screen or not</param>
        public virtual void ShowScreen(BOSScreen scr, bool bIsChild)
        {
        }

        public virtual BOSScreen GetScreenByScreenNumber(string strScreenNumber)
        {
            return Screens.FirstOrDefault(t => t.ScreenNumber == strScreenNumber);
        }

        #endregion

        #region Get Method Info Functions

        /// <summary>
        ///     Get Method by Method Name and Parameter Type array
        /// </summary>
        /// <functiontype>Get Method</functiontype>
        /// <param name="strMethodName"></param>
        /// <param name="parametersType"></param>
        /// <returns></returns>
        public MethodInfo GetMethodInfoByMethodNameAndParametersType(string strMethodName, Type[] parametersType)
        {
            return GetType()
                .GetMethod(strMethodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null,
                    parametersType, null);
        }

        /// <summary>
        ///     Get Parameter Type Array of Method
        /// </summary>
        /// <functiontype>Get Method</functiontype>
        /// <param name="strMethodFullName"></param>
        /// <returns></returns>
        public Type[] GetParameterTypeArrayFromMethodFullName(string strMethodFullName)
        {
            var strMethodParameters = strMethodFullName.Substring(strMethodFullName.IndexOf("(", StringComparison.Ordinal));
            var parametersType = new Type[0];
            var index = strMethodParameters.IndexOf(",", StringComparison.Ordinal);
            while (index > 0)
            {
                Array.Resize(ref parametersType, parametersType.Length + 1);
                var typeName = strMethodParameters.Substring(0, index).TrimStart('(').TrimEnd(')');
                parametersType.SetValue(Type.GetType(typeName), parametersType.Length - 1);
                strMethodParameters = strMethodParameters.Substring(index + 1);
                index = strMethodParameters.IndexOf(",", StringComparison.Ordinal);
            }
            index = strMethodParameters.IndexOf(")", StringComparison.Ordinal);
            if (index > 0)
                if (!string.IsNullOrEmpty(strMethodParameters.Substring(0, index)))
                {
                    var typeName = strMethodParameters.Substring(0, index).TrimStart('(').TrimEnd(')');
                    if (!string.IsNullOrEmpty(typeName))
                    {
                        Array.Resize(ref parametersType, parametersType.Length + 1);
                        parametersType.SetValue(
                            GetType(BOSUtil.GetFullTypeName(typeName)),
                            parametersType.Length - 1);
                    }
                }

            return parametersType;
        }

        /// <summary>
        ///     Get Method Info
        /// </summary>
        /// <functiontype>Get Method</functiontype>
        /// <param name="strMethodName">Method Name</param>
        /// <param name="strMethodFullName">Method Full Name</param>
        /// <param name="strMethodClass">Class of Method</param>
        /// <returns></returns>
        public MethodInfo GetMethodInfoByMethodFullNameAndMethodClass(string strMethodName, string strMethodFullName,
            string strMethodClass)
        {
            try
            {
                var strAssemblyName = GetAssemblyName();

                if (string.IsNullOrEmpty(strAssemblyName)) return null;
                //Assembly a = Assembly.Load(strAssemblyName);
                var classType = GetClassType(strMethodClass);
                var method = classType?.GetMethod(strMethodName,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null,
                    GetParameterTypeArrayFromMethodFullName(strMethodFullName), null);
                return method;
            }
            catch (Exception e)
            {
                MessageBox.Show(GetType().Name + ".GetMethodByMethodFullNameAndMethodClass:" + e.Message);
                return null;
            }
        }

        protected Type GetType(string strFullTypeName)
        {
            if (Type.GetType(strFullTypeName) != null)
                return Type.GetType(strFullTypeName);
            if (strFullTypeName == "DevExpress.XtraBars.ItemClickEventArgs")
                return typeof(ItemClickEventArgs);
            var strAssemblyName = strFullTypeName.Substring(0, strFullTypeName.LastIndexOf(".", StringComparison.Ordinal));
            var a = Assembly.LoadFile("C:\\WINDOWS\\Microsoft.NET\\Framework\\v2.0.50727\\" + strAssemblyName + ".dll");
            return a.GetType(strFullTypeName);
        }

        /// <summary>
        ///     Get Parameters value of method
        /// </summary>
        /// <functiontype>Get Method</functiontype>
        /// <param name="parameters"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public object[] GetMethodParameterValues(ParameterInfo[] parameters, params object[] parameterValue)
        {
            var paramObjects = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
                paramObjects[i] = parameterValue[i];
            return paramObjects;
        }

        public virtual string GetAssemblyName()
        {
            return string.Empty;
        }

        public virtual Type GetClassType(string strClassName)
        {
            return null;
        }

        #endregion
    }
}