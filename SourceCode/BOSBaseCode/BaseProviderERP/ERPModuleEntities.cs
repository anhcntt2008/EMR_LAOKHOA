using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using BOSCommon;
using BOSLib;
using DevExpress.XtraEditors;
using Localization;

namespace BOSERP
{
    public partial class ERPModuleEntities
    {
        protected readonly BOSDbUtil _dbUtil;
        private readonly GEHistoryDetailsController _geHistoryDetailsController;
        private readonly GENumberingController _geNumberingController;
        private readonly GENumberingController _gENumberingController;
        private readonly AAColumnAliasController _objColumnAlliasController;
        private readonly ARCustomersController _objCustomersController;
        private readonly GEHistoryDetailOfProductBranchPricesController _objHistoryDetailOfProductBranchPricesController;
        private readonly ICInventoryStocksController _objInventoryStocksController;
        private readonly ICProductsController _objProductsController;
        private readonly ICProductSeriesController _objProductSeriesController;
        private readonly ARPriceLevelsController _objPriceLevelsController;
        private readonly ICProductBranchPricesController _objProductBranchPricesController;
        private readonly ICProductPricesController _objProductPricesController;
        private readonly ICProductUnitsController _objProductUnitsController;
        private readonly ICPromotionItemsController _objPromotionItemsController;
        private readonly ICPromotionsController _objPromotionsController;


        public ERPModuleEntities()
        {
            MainObjectBindingSource = new BindingSource();
            ModuleObjects = new BusinessObjectCollection();
            ModuleObjectsBindingSource = new BindingSourceCollection();
            _geNumberingController = new GENumberingController();
            _dbUtil = new BOSDbUtil();
            _geHistoryDetailsController = new GEHistoryDetailsController();
            _objColumnAlliasController = new AAColumnAliasController();
            // _objHistoryDetailOfProductBranchPricesController = new GEHistoryDetailOfProductBranchPricesController();
            _gENumberingController = new GENumberingController();
            //_objInventoryStocksController = new ICInventoryStocksController();
            //_objProductsController = new ICProductsController();
            //_objProductSeriesController = new ICProductSeriesController();
            //_objCustomersController = new ARCustomersController();
            //_objProductUnitsController = new ICProductUnitsController();
            //_objPromotionsController = new ICPromotionsController();
            //_objPromotionItemsController = new ICPromotionItemsController();
            //_objProductBranchPricesController = new ICProductBranchPricesController();
            //_objProductPricesController = new ICProductPricesController();
            //_objPriceLevelsController = new ARPriceLevelsController();
        }

        /// <summary>
        ///     Save history details of an object
        /// </summary>
        /// <param name="objectHistoryId">History id of the object</param>
        /// <param name="oldObject">Old object</param>
        /// <param name="newObject">New object</param>
        public virtual void SaveHistoryDetails(int objectHistoryId, BusinessObject oldObject, BusinessObject newObject)
        {
            var props = oldObject.GetType().GetProperties();
            var tableName = BOSUtil.GetTableNameFromBusinessObject(oldObject);
            foreach (var propInfo in props)
                if (propInfo.Name.Substring(0, 2) != "AA")
                    if (propInfo.GetType() != typeof(byte[]))
                    {
                        var newValue = _dbUtil.GetPropertyValue(newObject, propInfo.Name);
                        var oldValue = _dbUtil.GetPropertyValue(oldObject, propInfo.Name);
                        if (oldValue == null || newValue == null) continue;
                        if (oldValue.Equals(newValue)) continue;
                        var objHistoryDetailsInfo = new GEHistoryDetailsInfo
                        {
                            FK_GEObjectHistoryID = objectHistoryId,
                            GEHistoryDetailTableName = tableName,
                            GEHistoryDetailColumnName = propInfo.Name,
                            GEHistoryDetailOldValue = oldValue.ToString().Trim(),
                            GEHistoryDetailNewValue = newValue.ToString().Trim()
                        };
                        _geHistoryDetailsController.CreateObject(objHistoryDetailsInfo);

                        //If the field is address line 3, create history details of its sub entries
                        if (!propInfo.Name.Contains("AddressLine3")) continue;
                        var addressType = string.Empty;
                        if (propInfo.Name.Contains(AddressType.Contact.ToString()))
                            addressType = AddressType.Contact.ToString();
                        else if (propInfo.Name.Contains(AddressType.Delivery.ToString()))
                            addressType = AddressType.Delivery.ToString();
                        else if (propInfo.Name.Contains(AddressType.Invoice.ToString()))
                            addressType = AddressType.Invoice.ToString();
                        else if (propInfo.Name.Contains(AddressType.Payment.ToString()))
                            addressType = AddressType.Payment.ToString();
                        if (!string.IsNullOrEmpty(addressType))
                            SaveAddressHistoryDetails(objectHistoryId,
                                objHistoryDetailsInfo.GEHistoryDetailID, oldObject, newObject, addressType);
                    }
        }

        /// <summary>
        ///     Save history details of an object
        /// </summary>
        /// <param name="objectHistoryId">History id of the object</param>
        /// <param name="objProductOldBranchPricesInfo">Old price</param>
        /// <param name="objProductNewBranchPricesInfo">new price</param>
        public virtual void SaveBranchPriceHistory(int objectHistoryId,
            ICProductBranchPricesInfo objProductOldBranchPricesInfo,
            ICProductBranchPricesInfo objProductNewBranchPricesInfo)
        {
            var objHistoryDetailOfProductBranchPricesInfo = new GEHistoryDetailOfProductBranchPricesInfo
            {
                FK_GEObjectHistoryID = objectHistoryId,
                AAStatus = objProductOldBranchPricesInfo.AAStatus,
                FK_BRBranchID = objProductOldBranchPricesInfo.FK_BRBranchID,
                FK_GECurrencyID = objProductOldBranchPricesInfo.FK_GECurrencyID,
                GEHistoryDetailOfProductBranchPriceOldValue = objProductOldBranchPricesInfo.ICProductBranchPrice,
                GEHistoryDetailOfProductBranchPriceNewValue = objProductNewBranchPricesInfo.ICProductBranchPrice
            };
            _objHistoryDetailOfProductBranchPricesController.CreateObject(objHistoryDetailOfProductBranchPricesInfo);
        }

        /// <summary>
        ///     Save history details of sub entries of an address
        /// </summary>
        /// <param name="objectHistoryId">The object history id</param>
        /// <param name="historyDetailParentId">ID of history that the sub history depends on</param>
        /// <param name="oldObject">Old object</param>
        /// <param name="newObject">New object</param>
        /// <param name="addressType">Address type</param>
        public void SaveAddressHistoryDetails(int objectHistoryId, int historyDetailParentId, BusinessObject oldObject,
            BusinessObject newObject, string addressType)
        {
            var props = typeof(ARCustomersInfo).GetProperties();

            var tableName = BOSUtil.GetTableNameFromBusinessObject(oldObject);

            foreach (var propInfo in props)
            {
                var objHistoryDetailsInfo = new GEHistoryDetailsInfo
                {
                    FK_GEObjectHistoryID = objectHistoryId,
                    GEHistoryDetailTableName = tableName,
                    GEHistoryDetailColumnName = propInfo.Name
                };
                if (!propInfo.Name.Contains(addressType + "Address") ||
                    propInfo.Name.Contains(addressType + "AddressLine3")) continue;
                var oldValue = _dbUtil.GetPropertyValue(oldObject, propInfo.Name);
                var newValue = _dbUtil.GetPropertyValue(newObject, propInfo.Name);
                if (oldValue != null)
                    objHistoryDetailsInfo.GEHistoryDetailOldValue = oldValue.ToString().Trim();
                if (newValue != null)
                    objHistoryDetailsInfo.GEHistoryDetailNewValue = newValue.ToString().Trim();
                _geHistoryDetailsController.CreateObject(objHistoryDetailsInfo);
            }
        }

        #region Constant

        public const string AAStatusColumn = "AAStatus";
        public const string AACreatedUser = "AACreatedUser";
        public const string AACreatedDate = "AACreatedDate";
        public const string AAUpdatedUser = "AAUpdatedUser";
        public const string AAUpdatedDate = "AAUpdatedDate";

        public const string cstNewObjectText = "***NEW***";
        public const string cstTemplateObjectText = "***TEMPLATE***";

        #endregion

        #region variables

        protected BaseModuleERP _module;
        protected BusinessObject _mainObject;
        protected BusinessObjectCollection _moduleObjects;
        protected BindingSource _mainObjectBindingSource;
        protected BindingSourceCollection _moduleObjectsBindingSource;

        private bool IsValid = true;

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the module that the entity belongs to
        /// </summary>
        public BaseModuleERP Module
        {
            get { return _module; }
            set { _module = value; }
        }

        /// <summary>
        ///     Gets or sets the search object of the module
        /// </summary>
        public BusinessObject SearchObject { get; set; }

        /// <summary>
        ///     Gets or sets the main object of the module
        /// </summary>
        public BusinessObject MainObject
        {
            get { return _mainObject; }
            set { _mainObject = value; }
        }

        /// <summary>
        ///     Gets or sets the list of module objects of the module
        /// </summary>
        public BusinessObjectCollection ModuleObjects
        {
            get { return _moduleObjects; }
            set { _moduleObjects = value; }
        }

        /// <summary>
        ///     Gets or sets the binding source of the search object
        /// </summary>
        public BindingSource SearchObjectBindingSource { get; set; }

        /// <summary>
        ///     Gets or sets the binding source of the main object
        /// </summary>
        public BindingSource MainObjectBindingSource
        {
            get { return _mainObjectBindingSource; }
            set { _mainObjectBindingSource = value; }
        }

        /// <summary>
        ///     Gets or sets the list of binding sources of the module objects
        /// </summary>
        public BindingSourceCollection ModuleObjectsBindingSource
        {
            get { return _moduleObjectsBindingSource; }
            set { _moduleObjectsBindingSource = value; }
        }

        #endregion

        #region Constructor

        public virtual void InitModuleEntity()
        {
            InitMainObject();
            InitModuleObjects();
            InitModuleObjectList();

            InitMainObjectBindingSource();
            InitModuleObjectsBindingSource();
        }

        public virtual void InitGridControlInBOSList()
        {
        }

        #endregion

        #region Init MainObject, ModuleObjects Functions

        public virtual void InitMainObject()
        {
        }

        /// <summary type="Initialize">
        ///     Initialize Module Objects
        /// </summary>
        public virtual void InitModuleObjects()
        {
        }

        public virtual void InitModuleObjectList()
        {
        }


        /// <summary type="Initialize">
        ///     Initialize Current Object Binding Source
        /// </summary>
        public virtual void InitMainObjectBindingSource()
        {
            if (MainObject != null)
                MainObjectBindingSource.DataSource = MainObject;
            if (SearchObject != null)
                SearchObjectBindingSource = new BindingSource { DataSource = SearchObject };
        }

        /// <summary type="Initialize">
        ///     Initialize Module Objects Binding Source
        /// </summary>
        public virtual void InitModuleObjectsBindingSource()
        {
            try
            {
                foreach (DictionaryEntry de in ModuleObjects)
                {
                    var bds = new BindingSource { DataSource = ModuleObjects[de.Key.ToString()].GetType() };
                    ModuleObjectsBindingSource.Add(de.Key.ToString(), bds);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(GetType().FullName + "-InitModuleObjectsBindingSource-" + e.Message);
            }
        }

        #endregion

        #region Register Module Object Event

        /// <summary type="ObjectRule">
        ///     Create Module Object Rule
        /// </summary>
        /// <functiontype>Create Object Rule</functiontype>
        public virtual void CreateMainObjectRule()
        {
            var strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);

            var dsColumns = _dbUtil.GetNotAllowNullTableColumns(strMainObjectTableName);

            if (dsColumns.Tables.Count > 0)
                foreach (DataRow rowColumn in dsColumns.Tables[0].Rows)
                {
                    var strColumnName = rowColumn["COLUMN_NAME"].ToString();
                    //Add rule if column is not primary key
                    if (_dbUtil.IsPrimaryKey(strMainObjectTableName, strColumnName)) continue;
                    if (_dbUtil.ColumnIsAllowNull(strMainObjectTableName, strColumnName)) continue;
                    var objColumnAliasInfo =
                        _objColumnAlliasController.GetAAColumnAliasByColumnNameAndTableName(strColumnName,
                            strMainObjectTableName);
                    var strBrokenRuleDescription = string.Format(BaseLocalizedResources.ColumnRequiredMessage,
                        objColumnAliasInfo != null ? objColumnAliasInfo.AAColumnAliasCaption : strColumnName);

                    if (_dbUtil.IsForeignKey(strMainObjectTableName, strColumnName))
                    {
                        var foreignKeyRule = new BusinessRule(
                            strColumnName,
                            strBrokenRuleDescription,
                            IsValidForeignKeyProperty);
                        MainObject.BusinessRuleCollections.Add(foreignKeyRule);
                    }
                    else
                    {
                        var nonForeignKeyRule = new BusinessRule(strColumnName, strBrokenRuleDescription,
                            IsValidNonForeignKeyPropety);
                        MainObject.BusinessRuleCollections.Add(nonForeignKeyRule);
                    }
                }
            dsColumns.Dispose();
        }

        protected List<BusinessRule> BackupMainObjectBusinessRule()
        {
            return MainObject.BusinessRuleCollections.ToList();
        }

        protected void RestoreMainObjectBusinessRule(List<BusinessRule> mainObjectRules)
        {
            foreach (var rule in mainObjectRules)
                MainObject.BusinessRuleCollections.Add(rule);
        }


        public bool IsValidForeignKeyProperty(string strForeignKeyColumn)
        {
            try
            {
                //String strMainObjectTableName = MainObject.GetType().Name.Substring(0, MainObject.GetType().Name.Length - 4);
                var strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
                var strPrimaryTable = _dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(strMainObjectTableName,
                    strForeignKeyColumn);

                var objPrimaryTableObjectController =
                    BusinessControllerFactory.GetBusinessController(strPrimaryTable + "Controller");
                var iForeignKeyColumnValue = Convert.ToInt32(_dbUtil.GetPropertyValue(MainObject, strForeignKeyColumn));
                return iForeignKeyColumnValue > 0 && objPrimaryTableObjectController.IsExist(iForeignKeyColumnValue);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsValidNonForeignKeyPropety(string strNonForeignKeyColumn)
        {
            try
            {
                var dbUtil = new BOSDbUtil();
                var property = MainObject.GetType().GetProperty(strNonForeignKeyColumn);
                if (property.PropertyType == typeof(int))
                {
                    var objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    var iConvert = Convert.ToInt32(objPropertyValue);
                    return true;
                }
                if (property.PropertyType == typeof(double))
                {
                    var objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    var dbConvert = Convert.ToDouble(objPropertyValue);
                    return true;
                }
                if (property.PropertyType == typeof(decimal))
                {
                    var objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    var dcConvert = Convert.ToDecimal(objPropertyValue);
                    return true;
                }
                if (property.PropertyType == typeof(short))
                {
                    var objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    var sConvert = Convert.ToInt16(objPropertyValue);
                    return true;
                }
                if (property.PropertyType == typeof(bool))
                {
                    var objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    var bConvert = Convert.ToBoolean(objPropertyValue);
                    return true;
                }
                if (property.PropertyType == typeof(DateTime))
                {
                    var objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    var dtConvert = Convert.ToDateTime(objPropertyValue);
                    return true;
                }
                if (property.PropertyType != typeof(string) && property.PropertyType != typeof(string)) return false;
                {
                    var objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);
                    var strConvert = Convert.ToString(objPropertyValue);
                    return !string.IsNullOrEmpty(strConvert);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary type="ObjectEvent">
        ///     Subcribe Main Object Event
        /// </summary>
        public void SubcribeMainObjectEvent()
        {
            MainObject.PropertyChanged += MainObject_OnChanged;
        }

        /// <summary>
        ///     Subcribe Module object Event
        /// </summary>
        public void SubcribeModueObjectEvent(string strModuleObjectName)
        {
            ModuleObjects[strModuleObjectName].PropertyChanged += ModuleObject_OnChanged;
        }

        /// <summary type="ObjectEvent">
        ///     Delegate Function for Event Valid of Module Object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModuleObject_OnValid(object sender, EventArgs e)
        {
            if (!Module.Toolbar.IsNullOrNoneAction())
            {
                var barbtnSave = Module.ParentScreen.GetToolbarButton(
                    BaseToolbar.ToolbarAction,
                    BaseToolbar.ToolbarButtonSave);
                var barbtnDelete = Module.ParentScreen.GetToolbarButton(
                    BaseToolbar.ToolbarAction,
                    BaseToolbar.ToolbarButtonDelete);
                if (barbtnSave != null)
                    barbtnSave.Enabled = true;
                if (barbtnDelete != null)
                    if (Module.Toolbar.ModusAction == BaseToolbar.ModusEdit)
                        barbtnDelete.Enabled = true;
                IsValid = true;
            }
        }

        /// <summary type="ObjectEvent">
        ///     Delegate Function for Event Invalid of Module Object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModuleObject_OnInvalid(object sender, EventArgs e)
        {
            if (!Module.Toolbar.IsNullOrNoneAction())
            {
                var barbtnSave = Module.ParentScreen.GetToolbarButton(
                    BaseToolbar.ToolbarAction,
                    BaseToolbar.ToolbarButtonSave);
                var barbtnDelete = Module.ParentScreen.GetToolbarButton(
                    BaseToolbar.ToolbarAction,
                    BaseToolbar.ToolbarButtonDelete);
                if (barbtnSave != null)
                    barbtnSave.Enabled = false;
                if (barbtnDelete != null)
                    barbtnDelete.Enabled = false;
                IsValid = false;
            }
        }


        /// <summary type="ObjectEvent">
        ///     Delegate Function for Event Invalid of Main Object
        /// </summary>
        public virtual void MainObject_OnChanged(object sender, PropertyChangedEventArgs e)
        {
            var changedValue = _dbUtil.GetPropertyValue((BusinessObject)sender, e.PropertyName);
            if (!Module.SwitchToEditMode((BusinessObject)sender, e.PropertyName)) return;
            _dbUtil.SetPropertyValue(MainObject, e.PropertyName, changedValue);
            UpdateMainObjectBindingSource();
        }

        /// <summary type="ObjectEvent">
        ///     Delegate Function for Event Invalid of Module Object
        /// </summary>
        public virtual void ModuleObject_OnChanged(object sender, PropertyChangedEventArgs e)
        {
            var tableName = BOSUtil.GetTableNameFromBusinessObject((BusinessObject)sender);
            if (ModuleObjects[tableName] == null || !ModuleObjects[tableName].Equals(sender)) return;
            var changedValue = _dbUtil.GetPropertyValue((BusinessObject)sender, e.PropertyName);
            if (!Module.SwitchToEditMode((BusinessObject)sender, e.PropertyName)) return;
            _dbUtil.SetPropertyValue(ModuleObjects[tableName], e.PropertyName, changedValue);
            UpdateModuleObjectBindingSource(tableName);
        }

        /// <summary>
        ///     Lock property change event, prevent it from raising continuously in action chain
        /// </summary>
        public void SetPropertyChangeEventLock(bool allow)
        {
            MainObject.AllowPropertyChangedEvent = allow;
            foreach (BusinessObject moduleObject in ModuleObjects.Values)
                moduleObject.AllowPropertyChangedEvent = allow;
        }

        private void RefreshControl(string strPropertyName, STFieldsInfo objStFieldsInfo)
        {
            var objPropertyValue = _dbUtil.GetPropertyValue(MainObject, strPropertyName);
            var strControlType = objStFieldsInfo.STFieldType;
            var ctrl = Module.Controls[objStFieldsInfo.STFieldName];
            if (strControlType.Equals("BOSTextBox"))
                ctrl.Text = objPropertyValue.ToString();
            else if (strControlType.Equals("BOSComboBox"))
                (ctrl as ComboBoxEdit).EditValue = objPropertyValue;
            else if (strControlType.Equals("BOSLookupEdit"))
                (ctrl as LookUpEdit).EditValue = objPropertyValue;
            else if (strControlType.Equals("BOSDateEdit"))
                (ctrl as DateEdit).DateTime = Convert.ToDateTime(objPropertyValue);
            else if (strControlType.Equals("BOSTimeEdit"))
                (ctrl as TimeEdit).Time = Convert.ToDateTime(objPropertyValue);
            else if (strControlType.Equals("BOSCheckEdit"))
                (ctrl as CheckEdit).EditValue = objPropertyValue;

            ctrl.Refresh();
        }

        #endregion

        #region Invalidate functions

        public virtual void Invalidate(int iObjectID)
        {
            InvalidateMainObject(iObjectID);
            InvalidateModuleObjects(iObjectID);
        }

        /// <summary type="Invalidate">
        ///     Invalidate Current Object
        /// </summary>
        /// <param name="iObjectId"></param>
        public virtual void InvalidateMainObject(int iObjectId)
        {
            var mainObjectRules = BackupMainObjectBusinessRule();

            var typMainObjectType = MainObject.GetType();
            var objMainObjectController = new BaseBusinessController(typMainObjectType);
            MainObject = (BusinessObject)objMainObjectController.GetObjectByID(iObjectId);

            RestoreMainObjectBusinessRule(mainObjectRules);
            SubcribeMainObjectEvent();

            UpdateMainObjectBindingSource();

            Module.InvalidateWorkflowToolbar();
        }

        /// <summary>
        ///     Update module object to the given business object
        ///     then refresh data binding to reflect changes to screen
        /// </summary>
        /// <param name="obj">The given business object</param>
        public virtual void InvalidateModuleObject(BusinessObject obj)
        {
            var strModuleObjectName = BOSUtil.GetTableNameFromBusinessObject(obj);
            if (ModuleObjects[strModuleObjectName] == null) return;
            ModuleObjects[strModuleObjectName] = obj;
            SubcribeModueObjectEvent(strModuleObjectName);
            UpdateModuleObjectBindingSource(strModuleObjectName);

            Module.InvalidateWorkflowToolbar(strModuleObjectName);
        }

        /// <summary>
        ///     Update module entity item, just convert to business object
        ///     and reuse the previous overload function
        /// </summary>
        /// <param name="entItem">The given entity item</param>
        /// <param name="strModuleObjectName">The table name of module object</param>
        public virtual void InvalidateModuleObject(ERPModuleItemsEntity entItem, string strModuleObjectName)
        {
            InvalidateModuleObject(entItem);
        }

        /// <summary type="Invalidate">
        ///     Invalidate Module Objects
        /// </summary>
        public virtual void InvalidateModuleObjects(int iObjectID)
        {
        }

        public virtual void InvalidateModuleItemObjectFromModuleItemsEntityList(int iPos)
        {
        }

        #endregion

        #region Set Default Main Object, Module Objects functions        

        public virtual void SetDefaultMainObject()
        {
            try
            {
                var mainObjectRules = BackupMainObjectBusinessRule();

                //If not Exist Template object,create new template object
                if (!IsExistTemplateObject())
                {
                    //Renew Current Object
                    var strMainObjectName = MainObject.GetType().Name;
                    MainObject = BusinessObjectFactory.GetBusinessObject(strMainObjectName);

                    //Get Table which Main Object Represent
                    var strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);

                    var strPrimaryColumn = strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "ID";

                    _dbUtil.SetPropertyValue(MainObject,
                        strPrimaryColumn.Substring(0, strPrimaryColumn.Length - 2) + "No", cstNewObjectText);


                    //Set Default Value for all property is foreign column and not allow null
                    var dsForeignKeys = _dbUtil.GetTableForeignKeys(strMainObjectTableName);
                    if (dsForeignKeys.Tables.Count > 0)
                        foreach (DataRow rowForeignKey in dsForeignKeys.Tables[0].Rows)
                        {
                            var strForeignKeyPropertyName = rowForeignKey["COLUMN_NAME"].ToString();
                            if (!_dbUtil.ColumnIsAllowNull(strMainObjectTableName, strForeignKeyPropertyName))
                            {
                                var strPrimaryTable = _dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(
                                    strMainObjectTableName,
                                    strForeignKeyPropertyName);
                                var typPrimaryTableObjectType =
                                    BusinessObjectFactory.GetBusinessObjectType(strPrimaryTable + "Info");
                                //BaseBusinessController objPrimaryTableController = new BaseBusinessController(BusinessObjectFactory.GetBusinessObjectType(strPrimaryTable + "Info"));
                                var objPrimaryTableController = new BaseBusinessController(typPrimaryTableObjectType);

                                objPrimaryTableController.GetFirstObjectID();
                            }
                        }
                }
                //If exist template object,copy template object to main object
                else
                {
                    //Get Table which Main Object Represent
                    var strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);

                    var strPrimaryColumn = strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "ID";

                    var objMainObjectController =
                        BusinessControllerFactory.GetBusinessController(strMainObjectTableName + "Controller");
                    var objTemplateObject = (BusinessObject)objMainObjectController.GetTemplateObject();
                    MainObject = (BusinessObject)objTemplateObject.Clone();
                    _dbUtil.SetPropertyValue(MainObject,
                        strPrimaryColumn.Substring(0, strPrimaryColumn.Length - 2) + "No", cstNewObjectText);
                    _dbUtil.SetPropertyValue(MainObject, AAStatusColumn, BusinessObject.DefaultAAStatus);
                }

                RestoreMainObjectBusinessRule(mainObjectRules);
                UpdateMainObjectBindingSource();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary type="Set">
        ///     Set Default Module Objects
        /// </summary>
        public virtual void SetDefaultModuleObjects()
        {
            var keysArray = new string[ModuleObjects.Count];
            ModuleObjects.Keys.CopyTo(keysArray, 0);
            foreach (var strModuleObjectName in keysArray)
                SetDefaultModuleObject(strModuleObjectName);
        }

        public virtual void SetDefaultModuleObject(string strModuleObjectName)
        {
            //Renew BusinessObject
            var strModuleObjectTypeName = ModuleObjects[strModuleObjectName].GetType().Name;
            ModuleObjects[strModuleObjectName] = BusinessObjectFactory.GetBusinessObject(strModuleObjectTypeName);

            //Get Table which Business object Represent
            //String strObjectTableName = ModuleObjects[strModuleObjectName].GetType().Name.Substring(0, ModuleObjects[strModuleObjectName].GetType().Name.Length - 4);
            var strObjectTableName = BOSUtil.GetTableNameFromBusinessObject(ModuleObjects[strModuleObjectName]);

            //Set Default Value for all property is foreign column and not allow null
            var dsForeignKeys = _dbUtil.GetTableForeignKeys(strObjectTableName);
            if (dsForeignKeys.Tables.Count > 0)
                foreach (DataRow rowForeignKey in dsForeignKeys.Tables[0].Rows)
                {
                    var strForeignKeyPropertyName = rowForeignKey["COLUMN_NAME"].ToString();
                    if (!_dbUtil.ColumnIsAllowNull(strObjectTableName, strForeignKeyPropertyName))
                    {
                        var strPrimaryTable = _dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(
                            strObjectTableName,
                            strForeignKeyPropertyName);

                        var strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
                        if (!strPrimaryTable.Equals(strMainObjectTableName))
                        {
                            var objPrimaryTableController =
                                new BaseBusinessController(
                                    BusinessObjectFactory.GetBusinessObjectType(strPrimaryTable + "Info"));

                            var iPrimaryTableObjectId = objPrimaryTableController.GetFirstObjectID();
                            _dbUtil.SetPropertyValue(
                                ModuleObjects[strModuleObjectName],
                                strForeignKeyPropertyName,
                                iPrimaryTableObjectId);
                        }
                    }
                }
            UpdateModuleObjectBindingSource(strModuleObjectName);
        }

        public virtual void SetDefaultModuleObjectsList()
        {
        }

        public virtual void DuplicateModuleObjectList()
        {
        }

        #endregion

        #region Update Main Object, Module Objects Binding Source Functions

        /// <summary type="Update">
        ///     Update Binding Source of Main Object
        /// </summary>
        public virtual void UpdateMainObjectBindingSource()
        {
            MainObjectBindingSource.DataSource = MainObject;
            MainObjectBindingSource.ResetBindings(false);
        }

        /// <summary>
        ///     Update the binding source of the search object
        /// </summary>
        public virtual void UpdateSearchObjectBindingSource()
        {
            SearchObjectBindingSource.DataSource = SearchObject;
            SearchObjectBindingSource.ResetBindings(false);
        }

        /// <summary type="Update">
        ///     Update Binding Source of Module Objects
        /// </summary>
        public virtual void UpdateModuleObjectsBindingSource()
        {
            foreach (DictionaryEntry de in ModuleObjects)
                ModuleObjectsBindingSource[de.Key.ToString()].DataSource = de.Value;
        }

        /// <summary type="Update">
        ///     Update Binding Source Of Module Object By Module Object Name
        /// </summary>
        /// <param name="strModuleObjectName">Module Object Name will be updated</param>
        public virtual void UpdateModuleObjectBindingSource(string strModuleObjectName)
        {
            ModuleObjectsBindingSource[strModuleObjectName].DataSource = ModuleObjects[strModuleObjectName];
            //ModuleObjectsBindingSource[strModuleObjectName].ResetBindings(false);
        }

        #endregion

        #region Function for create Module Entity  

        public virtual string GetMainObjectNo(ref int numberingStart)
        {
            var strMainObjectNo = string.Empty;


            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], START
            //GENumberingInfo objGENumberingInfo = (GENumberingInfo)objGENumberingController.GetObjectByName(Module.Name);
            var nuberingList = _geNumberingController.GetNumberingListByName(Module.Name);
            var objGeNumberingInfo = nuberingList.Count == 1
                ? nuberingList[0]
                : nuberingList.FirstOrDefault(i => i.FK_BRBranchID == BOSApp.CurrentCompanyInfo.FK_BRBranchID);
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], END

            if (objGeNumberingInfo == null) return strMainObjectNo;
            var mainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            var objMainObjectController =
                BusinessControllerFactory.GetBusinessController(mainTableName + "Controller");
            if (objMainObjectController == null) return strMainObjectNo;

            var currentDate = _dbUtil.GetCurrentServerDate();

            var prefixYear = "";
            var numberStart = objGeNumberingInfo.GENumberingStart;

            if (objGeNumberingInfo.GENumberingPrefixHaveYear)
            {
                prefixYear = currentDate.Year.ToString().Substring(2, 2) + ".";
                if (objGeNumberingInfo.AAUpdatedDate.Year < currentDate.Year)
                    numberStart = Convert.ToInt32(Math.Pow(10, objGeNumberingInfo.GENumberingLength - 1)) + 1;
            }

            strMainObjectNo = string.Format("{0}{1}{2}", objGeNumberingInfo.GENumberingPrefix, prefixYear,
                numberStart.ToString().PadLeft(objGeNumberingInfo.GENumberingLength, '0'));
            numberingStart = numberStart;

            while (objMainObjectController.IsExist(strMainObjectNo))
            {
                numberStart++;
                strMainObjectNo = string.Format("{0}{1}{2}", objGeNumberingInfo.GENumberingPrefix, prefixYear,
                    numberStart.ToString().PadLeft(objGeNumberingInfo.GENumberingLength, '0'));
                numberingStart = numberStart;
            }
            return strMainObjectNo;
        }

        /// <summary>
        ///     Get main object number automatically from config
        /// </summary>
        /// <returns>Main object number</returns>
        public virtual string GetMainObjectNo()
        {
            var numberingStart = 0;
            return GetMainObjectNo(ref numberingStart);
        }

        public virtual int CreateMainObject()
        {
            var editObjectNo = true;

            //Get Table which Business object Represent            
            var strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            var objMainObjectController =
                BusinessControllerFactory.GetBusinessController(strMainObjectTableName + "Controller");

            //Set Object No value
            var strPrimaryColumn = strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "ID";
            var strColumnNo = strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "No";
            var strMainObjectNo = _dbUtil.GetPropertyStringValue(MainObject, strColumnNo);
            var numberingStart = 0;
            if (strMainObjectNo.Equals(cstNewObjectText))
            {
                editObjectNo = false;
                strMainObjectNo = GetMainObjectNo(ref numberingStart);
                _dbUtil.SetPropertyValue(MainObject, strColumnNo, strMainObjectNo);
            }

            //Set Created User, Created Date
            _dbUtil.SetPropertyValue(MainObject, AACreatedUser, BOSApp.CurrentUser);
            _dbUtil.SetPropertyValue(MainObject, AACreatedDate, DateTime.Now);


            var iObjectId = _dbUtil.GetPropertyIntValue(MainObject, strPrimaryColumn);
            if (iObjectId == 0)
                iObjectId = objMainObjectController.CreateObject(MainObject);
            else
                objMainObjectController.CreateObject(MainObject, iObjectId);

            if (iObjectId <= 0) return iObjectId;
            if (!editObjectNo)
                UpdateObjectNumbering(numberingStart);

            var strMainObjectPrimaryColumnName = _dbUtil.GetTablePrimaryColumn(strMainObjectTableName);
            _dbUtil.SetPropertyValue(MainObject, strMainObjectPrimaryColumnName, iObjectId);

            return iObjectId;
        }

        /// <summary type="Save">
        ///     Update Current Object
        /// </summary>
        /// <returns></returns>
        public virtual int UpdateMainObject()
        {
            var strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            var objMainObjectController =
                BusinessControllerFactory.GetBusinessController(strMainObjectTableName + "Controller");

            //Set AAUpdatedUser, AAUpdatedDate

            _dbUtil.SetPropertyValue(MainObject, AAUpdatedUser, BOSApp.CurrentUser);
            _dbUtil.SetPropertyValue(MainObject, AAUpdatedDate, DateTime.Now);

            var iObjectId = objMainObjectController.UpdateObject(MainObject);

            return iObjectId;
        }

        /// <summary type="Save">
        ///     Save Main Object
        /// </summary>
        /// <returns></returns>
        public virtual int SaveMainObject()
        {
            return Module.Toolbar.IsNewAction() ? CreateMainObject() : UpdateMainObject();
        }

        public virtual bool IsExistTemplateObject()
        {
            var strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            var objMainObjectController =
                BusinessControllerFactory.GetBusinessController(strMainObjectTableName + "Controller");
            var objTemplateObject = (BusinessObject)objMainObjectController.GetTemplateObject();
            if (objTemplateObject != null)
                return true;
            return false;
        }


        public virtual void SaveModuleObjects()
        {
        }

        public virtual void UpdateObjectNumbering(int numberingStart)
        {
            if (numberingStart <= 0) return;
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], START
            //GENumberingInfo objGENumberingInfo = (GENumberingInfo)objGENumberingController.GetObjectByName(Module.Name);
            GENumberingInfo objGeNumberingInfo;
            var nuberingList = _gENumberingController.GetNumberingListByName(Module.Name);
            if (nuberingList.Count == 1)
                objGeNumberingInfo = nuberingList[0];
            else
                objGeNumberingInfo =
                    nuberingList
                        .FirstOrDefault(i => i.FK_BRBranchID == BOSApp.CurrentCompanyInfo.FK_BRBranchID);
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], END

            if (objGeNumberingInfo == null) return;
            objGeNumberingInfo.GENumberingStart = numberingStart + 1;
            _gENumberingController.UpdateObject(objGeNumberingInfo);
        }

        #endregion

        #region Function for action New,Save,Delete Module Entity

        public virtual void New()
        {
            SetDefaultMainObject();
            SetDefaultModuleObjects();
            SetDefaultModuleObjectsList();
        }

        public virtual void Save()
        {
        }

        public virtual void Delete(int iObjectId)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    var objCurrentObjectController =
                        BusinessControllerFactory.GetBusinessController(
                            MainObject.GetType().Name.Substring(0, MainObject.GetType().Name.Length - 4) + "Controller");
                    _dbUtil.SetPropertyValue(MainObject, "AAUpdatedDate", DateTime.Now);
                    _dbUtil.SetPropertyValue(MainObject, "AAUpdatedUser", BOSApp.CurrentUser);
                    objCurrentObjectController.UpdateObject(MainObject);

                    objCurrentObjectController.DeleteObject(iObjectId);
                    var strTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
                    DeleteObjectRelations(strTableName, iObjectId);
                    scope.Complete();
                }
                catch (Exception)
                {
                    scope.Dispose();
                }
            }
        }

        /// <summary>
        ///     Delete all relations of deleted object
        /// </summary>
        public virtual void DeleteObjectRelations(string strTableName, int iObjectID)
        {
        }

        public virtual void DeleteModuleObject(string strModuleObjectName, int iObjectID)
        {
        }

        public virtual void SaveMainObjectRelations()
        {
        }

        public virtual void SaveObjectItemRelations(ERPModuleItemsEntity entItems)
        {
        }

        /// <summary>
        ///     Complete transaction and update inventory
        /// </summary>
        public virtual bool CompleteTransaction()
        {
            return true;
        }

        #endregion

        #region Utitlity functions


        public List<ERPModuleItemsEntity> GetModuleItemsEntityList(string strModuleItemsEntityName)
        {
            var lstERPModuleItemsEntity = new List<ERPModuleItemsEntity>();
            foreach (var field in GetType().GetFields())
                if (field.FieldType.FullName.Contains("System.Collections.Generic"))
                {
                    var arrType = field.FieldType.GetGenericArguments();
                    if (arrType[0].Name.Contains(strModuleItemsEntityName))
                        try
                        {
                            if (arrType[0].BaseType == typeof(ERPModuleItemsEntity))
                            {
                                lstERPModuleItemsEntity = (List<ERPModuleItemsEntity>)field.GetValue(this);
                                return lstERPModuleItemsEntity;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return null;
                        }
                }
            return null;
        }

        public List<BusinessObject> GetBusinessObjectList(string strBusinessObjectName)
        {
            var lstBusinessObject = new List<BusinessObject>();
            foreach (var field in GetType().GetFields())
                if (field.FieldType.FullName.Contains("System.Collections.Generic"))
                {
                    var arrType = field.FieldType.GetGenericArguments();
                    try
                    {
                        if (arrType[0].BaseType == typeof(BusinessObject))
                        {
                            lstBusinessObject = (List<BusinessObject>)field.GetValue(this);
                            return lstBusinessObject;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return null;
                    }
                }
            return null;
        }

        #endregion
    }
}