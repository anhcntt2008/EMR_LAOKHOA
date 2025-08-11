using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.Transactions;
using BOSLib;
using Localization;

namespace BOSERP
{
    public partial class ERPModuleEntities
    {
        #region Constant
        public const String AAStatusColumn = "AAStatus";
        public const String AACreatedUser = "AACreatedUser";
        public const String AACreatedDate = "AACreatedDate";
        public const String AAUpdatedUser = "AAUpdatedUser";
        public const String AAUpdatedDate = "AAUpdatedDate";
        
        public const String cstNewObjectText = "***NEW***";
        public const String cstTemplateObjectText = "***TEMPLATE***";
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
        /// Gets or sets the module that the entity belongs to
        /// </summary>
        public BaseModuleERP Module
        {
            get { return _module; }
            set { _module = value; }
        }

        /// <summary>
        /// Gets or sets the main object of the module
        /// </summary>
        public BusinessObject MainObject
        {
            get { return _mainObject; }
            set { _mainObject = value; }
        }

        /// <summary>
        /// Gets or sets the list of module objects of the module
        /// </summary>
        public BusinessObjectCollection ModuleObjects
        {
            get { return _moduleObjects; }
            set { _moduleObjects = value; }
        }

        /// <summary>
        /// Gets or sets the binding source of the main object
        /// </summary>
        public BindingSource MainObjectBindingSource
        {
            get { return _mainObjectBindingSource; }
            set { _mainObjectBindingSource = value; }
        }

        /// <summary>
        /// Gets or sets the list of binding sources of the module objects
        /// </summary>
        public BindingSourceCollection ModuleObjectsBindingSource
        {
            get { return _moduleObjectsBindingSource; }
            set { _moduleObjectsBindingSource = value; }
        }
        #endregion

        #region Constructor
        public ERPModuleEntities()
        {
            MainObjectBindingSource = new BindingSource();            
            ModuleObjects = new BusinessObjectCollection();            
            ModuleObjectsBindingSource = new BindingSourceCollection();            
        }

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
        /// Initialize Module Objects
        /// </summary>
        public virtual void InitModuleObjects()
        {
            
        }

        public virtual void InitModuleObjectList()
        {

        }
       

        /// <summary type="Initialize">
        /// Initialize Current Object Binding Source
        /// </summary>
        public virtual void InitMainObjectBindingSource()
        {
            if(MainObject!=null)
                MainObjectBindingSource.DataSource = MainObject.GetType();                
        }

        /// <summary type="Initialize">
        /// Initialize Module Objects Binding Source
        /// </summary>
        public virtual void InitModuleObjectsBindingSource()
        {
            try
            {
                foreach (DictionaryEntry de in ModuleObjects)
                {
                    BindingSource bds = new BindingSource();
                    bds.DataSource = ModuleObjects[de.Key.ToString()].GetType();
                    ModuleObjectsBindingSource.Add(de.Key.ToString(), bds);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this.GetType().FullName + "-InitModuleObjectsBindingSource-" + e.Message);
            }
        }        

        #endregion

        #region Register Module Object Event
        /// <summary type="ObjectRule">
        /// Create Module Object Rule
        /// </summary>
        /// <functiontype>Create Object Rule</functiontype>
        public virtual void CreateMainObjectRule()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();            
            String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);

            DataSet dsColumns = dbUtil.GetNotAllowNullTableColumns(strMainObjectTableName);
            
            if (dsColumns.Tables.Count > 0)
            {
                AAColumnAliasController objColumnAlliasController = new AAColumnAliasController();
                foreach (DataRow rowColumn in dsColumns.Tables[0].Rows)
                {
                    String strColumnName = rowColumn["COLUMN_NAME"].ToString();
                    String strBrokenRuleDescription = String.Empty;
                    //Add rule if column is not primary key
                    if (!dbUtil.IsPrimaryKey(strMainObjectTableName, strColumnName))
                    {
                        //If column does not allow null
                        if (!dbUtil.ColumnIsAllowNull(strMainObjectTableName, strColumnName))
                        {
                            AAColumnAliasInfo objColumnAliasInfo = objColumnAlliasController.GetAAColumnAliasByColumnNameAndTableName(strColumnName, strMainObjectTableName);
                            if (objColumnAliasInfo != null)
                            {
                                strBrokenRuleDescription = String.Format(string.Format(BaseLocalizedResources.ColumnRequiredMessage, objColumnAliasInfo.AAColumnAliasCaption));                                
                            }
                            else
                            {
                                strBrokenRuleDescription = String.Format(string.Format(BaseLocalizedResources.ColumnRequiredMessage, strColumnName));
                            }

                            if (dbUtil.IsForeignKey(strMainObjectTableName, strColumnName))
                            {
                                BusinessRule foreignKeyRule = new BusinessRule(
                                                                    strColumnName,
                                                                    strBrokenRuleDescription,
                                                                    IsValidForeignKeyProperty);
                                MainObject.BusinessRuleCollections.Add(foreignKeyRule);
                            }
                            else
                            {
                                BusinessRule nonForeignKeyRule = new BusinessRule(strColumnName, strBrokenRuleDescription, IsValidNonForeignKeyPropety);
                                MainObject.BusinessRuleCollections.Add(nonForeignKeyRule);
                            }
                        }                        
                    }
                }
            }
            dsColumns.Dispose();
        }

        protected List<BusinessRule> BackupMainObjectBusinessRule()
        {
            List<BusinessRule> mainObjectRules = new List<BusinessRule>();
            foreach (BusinessRule rule in MainObject.BusinessRuleCollections)
            {
                mainObjectRules.Add(rule);
            }
            return mainObjectRules;
        }

        protected void RestoreMainObjectBusinessRule(List<BusinessRule> mainObjectRules)
        {
            foreach (BusinessRule rule in mainObjectRules)
            {
                MainObject.BusinessRuleCollections.Add(rule);
            }
        }


        private bool IsValidForeignKeyProperty(String strForeignKeyColumn)
        {
            try
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                //String strMainObjectTableName = MainObject.GetType().Name.Substring(0, MainObject.GetType().Name.Length - 4);
                String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
                String strPrimaryTable = dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(strMainObjectTableName, strForeignKeyColumn);
                String strPrimaryColumn = dbUtil.GetPrimaryColumnWhichForeignColumnReferenceTo(strMainObjectTableName, strForeignKeyColumn);
                BaseBusinessController objPrimaryTableObjectController = BusinessControllerFactory.GetBusinessController(strPrimaryTable + "Controller");
                int iForeignKeyColumnValue = Convert.ToInt32(dbUtil.GetPropertyValue(MainObject, strForeignKeyColumn));
                if (iForeignKeyColumnValue > 0)
                    return objPrimaryTableObjectController.IsExist(iForeignKeyColumnValue);
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private bool IsValidNonForeignKeyPropety(String strNonForeignKeyColumn)
        {
            try
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                PropertyInfo property = MainObject.GetType().GetProperty(strNonForeignKeyColumn);
                if (property.PropertyType.Equals(typeof(int)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);                    
                    int iConvert = Convert.ToInt32(objPropertyValue);
                    return true;
                }
                else if (property.PropertyType.Equals(typeof(double)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);                    
                    double dbConvert = Convert.ToDouble(objPropertyValue);
                    return true;
                }
                else if (property.PropertyType.Equals(typeof(decimal)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);                    
                    decimal dcConvert = Convert.ToDecimal(objPropertyValue);
                    return true;
                }
                else if (property.PropertyType.Equals(typeof(short)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);                    
                    short sConvert = Convert.ToInt16(objPropertyValue);
                    return true;
                }
                else if (property.PropertyType.Equals(typeof(bool)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);                    
                    bool bConvert = Convert.ToBoolean(objPropertyValue);
                    return true;
                }
                else if (property.PropertyType.Equals(typeof(DateTime)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);                    
                    DateTime dtConvert = Convert.ToDateTime(objPropertyValue);
                    return true;
                }
                else if (property.PropertyType.Equals(typeof(string)) || property.PropertyType.Equals(typeof(String)))
                {
                    object objPropertyValue = dbUtil.GetPropertyValue(MainObject, strNonForeignKeyColumn);                    
                    String strConvert = Convert.ToString(objPropertyValue);
                    if (!String.IsNullOrEmpty(strConvert))
                        return true;
                    else
                        return false;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary type="ObjectEvent">
        /// Subcribe Main Object Event
        /// </summary>        
        public void SubcribeMainObjectEvent()
        {
            MainObject.PropertyChanged += new PropertyChangedEventHandler(MainObject_OnChanged);
        }

        /// <summary>
        /// Subcribe Module object Event
        /// </summary>
        public void SubcribeModueObjectEvent(String strModuleObjectName)
        {
            ModuleObjects[strModuleObjectName].PropertyChanged += new PropertyChangedEventHandler(ModuleObject_OnChanged);
        }

        /// <summary type="ObjectEvent">
        /// Delegate Function for Event Valid of Module Object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void ModuleObject_OnValid(object sender, EventArgs e)
        {
            if (!Module.Toolbar.IsNullOrNoneAction())
            {
                DevExpress.XtraBars.BarButtonItem barbtnSave = Module.ParentScreen.GetToolbarButton(
                                                                            BaseToolbar.ToolbarAction, 
                                                                            BaseToolbar.ToolbarButtonSave);
                DevExpress.XtraBars.BarButtonItem barbtnDelete = Module.ParentScreen.GetToolbarButton(
                                                                                BaseToolbar.ToolbarAction, 
                                                                                BaseToolbar.ToolbarButtonDelete);
                if (barbtnSave != null)
                    barbtnSave.Enabled = true;
                if (barbtnDelete != null)
                {
                    if (Module.Toolbar.ModusAction == BaseToolbar.ModusEdit)
                        barbtnDelete.Enabled = true;
                }
                IsValid = true;
            }
        }

        /// <summary type="ObjectEvent">
        /// Delegate Function for Event Invalid of Module Object
        /// </summary>        
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModuleObject_OnInvalid(object sender, EventArgs e)
        {
            if (!Module.Toolbar.IsNullOrNoneAction())
            {
                DevExpress.XtraBars.BarButtonItem barbtnSave = Module.ParentScreen.GetToolbarButton(
                                                                                BaseToolbar.ToolbarAction, 
                                                                                BaseToolbar.ToolbarButtonSave);
                DevExpress.XtraBars.BarButtonItem barbtnDelete = Module.ParentScreen.GetToolbarButton(
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
        /// Delegate Function for Event Invalid of Main Object
        /// </summary>        
        public void MainObject_OnChanged(object sender, PropertyChangedEventArgs e)
        {
            BusinessObject_PropertyChanged((BusinessObject)sender, e.PropertyName);
        }

        /// <summary type="ObjectEvent">
        /// Delegate Function for Event Invalid of Module Object
        /// </summary>        
        public void ModuleObject_OnChanged(object sender, PropertyChangedEventArgs e)
        {
            BusinessObject_PropertyChanged((BusinessObject)sender, e.PropertyName);
        }

        public virtual void BusinessObject_PropertyChanged(BusinessObject obj, String strPropertyName)
        {
            if (Module.Toolbar.CurrentObjectID > 0 && Module.Toolbar.IsNullOrNoneAction() && obj.AllowPropertyChangedEvent)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                if (String.IsNullOrEmpty(strPropertyName) || dbUtil.ColumnIsExist(BOSUtil.GetTableNameFromBusinessObject(obj), strPropertyName))
                    Module.ActionEdit();
            }
        }

        /// <summary>
        /// Lock property change event, prevent it from raising continuously in action chain
        /// </summary
        public void SetPropertyChangeEventLock(bool allow)
        {
            MainObject.AllowPropertyChangedEvent = allow;
            foreach (BusinessObject moduleObject in ModuleObjects.Values)
                moduleObject.AllowPropertyChangedEvent = allow;
        }        

        private void RefreshControl(String strPropertyName,STFieldsInfo objSTFieldsInfo)
        {            
            String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            object objPropertyValue = new BOSDbUtil().GetPropertyValue(MainObject, strPropertyName);
            String strControlType = objSTFieldsInfo.STFieldType;
            Control ctrl = Module.Controls[objSTFieldsInfo.STFieldName];
            if (strControlType.Equals("BOSTextBox"))
                ctrl.Text = objPropertyValue.ToString();
            else if (strControlType.Equals("BOSComboBox"))
                (ctrl as DevExpress.XtraEditors.ComboBoxEdit).EditValue = objPropertyValue;
            else if (strControlType.Equals("BOSLookupEdit"))
                (ctrl as DevExpress.XtraEditors.LookUpEdit).EditValue = objPropertyValue;
            else if (strControlType.Equals("BOSDateEdit"))
                (ctrl as DevExpress.XtraEditors.DateEdit).DateTime = Convert.ToDateTime(objPropertyValue);
            else if (strControlType.Equals("BOSTimeEdit"))
                (ctrl as DevExpress.XtraEditors.TimeEdit).Time = Convert.ToDateTime(objPropertyValue);
            else if (strControlType.Equals("BOSCheckEdit"))
                (ctrl as DevExpress.XtraEditors.CheckEdit).EditValue = objPropertyValue;

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
        /// Invalidate Current Object
        /// </summary>
        /// <param name="iObjectID"></param>
        public virtual void InvalidateMainObject(int iObjectID)
        {
            List<BusinessRule> mainObjectRules = BackupMainObjectBusinessRule();

            Type typMainObjectType = MainObject.GetType();
            BaseBusinessController objMainObjectController = new BaseBusinessController(typMainObjectType);            
            MainObject = (BusinessObject)objMainObjectController.GetObjectByID(iObjectID);

            RestoreMainObjectBusinessRule(mainObjectRules);
            SubcribeMainObjectEvent();

            UpdateMainObjectBindingSource();
        }

        /// <summary>
        /// Update module object to the given business object
        /// then refresh data binding to reflect changes to screen
        /// </summary>
        /// <param name="obj">The given business object</param>
        public virtual void InvalidateModuleObject(BusinessObject obj)
        {
            String strModuleObjectName = BOSUtil.GetTableNameFromBusinessObject(obj);
            if (ModuleObjects[strModuleObjectName] != null)
            {
                ModuleObjects[strModuleObjectName] = obj;
                SubcribeModueObjectEvent(strModuleObjectName);
                UpdateModuleObjectBindingSource(strModuleObjectName);
            }
        }

        /// <summary>
        /// Update module entity item, just convert to business object
        /// and reuse the previous overload function
        /// </summary>
        /// <param name="entItem">The given entity item</param>
        /// <param name="strModuleObjectName">The table name of module object</param>
        public virtual void InvalidateModuleObject(ERPModuleItemsEntity entItem, String strModuleObjectName)
        {
            BusinessObject obj = entItem.SetToBusinessObject(strModuleObjectName);
            InvalidateModuleObject(obj);
        }

        /// <summary type="Invalidate">
        /// Invalidate Module Objects
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
                BOSDbUtil dbUtil = new BOSDbUtil();
                List<BusinessRule> mainObjectRules = BackupMainObjectBusinessRule();                

                //If not Exist Template object,create new template object
                if (!IsExistTemplateObject())
                {
                    //Renew Current Object
                    String strMainObjectName = MainObject.GetType().Name;
                    MainObject = BusinessObjectFactory.GetBusinessObject(strMainObjectName);

                    //Get Table which Main Object Represent
                    String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);

                    String strPrimaryColumn = strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "ID";

                    dbUtil.SetPropertyValue(MainObject, strPrimaryColumn.Substring(0, strPrimaryColumn.Length - 2) + "No", cstNewObjectText);


                    //Set Default Value for all property is foreign column and not allow null
                    DataSet dsForeignKeys = dbUtil.GetTableForeignKeys(strMainObjectTableName);
                    if (dsForeignKeys.Tables.Count > 0)
                    {
                        foreach (DataRow rowForeignKey in dsForeignKeys.Tables[0].Rows)
                        {
                            String strForeignKeyPropertyName = rowForeignKey["COLUMN_NAME"].ToString();
                            if (!dbUtil.ColumnIsAllowNull(strMainObjectTableName, strForeignKeyPropertyName))
                            {
                                String strPrimaryTable = dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(
                                                                    strMainObjectTableName,
                                                                    strForeignKeyPropertyName);
                                Type typPrimaryTableObjectType = BusinessObjectFactory.GetBusinessObjectType(strPrimaryTable + "Info");
                                //BaseBusinessController objPrimaryTableController = new BaseBusinessController(BusinessObjectFactory.GetBusinessObjectType(strPrimaryTable + "Info"));
                                BaseBusinessController objPrimaryTableController = new BaseBusinessController(typPrimaryTableObjectType);

                                int iPrimaryTableObjectID = objPrimaryTableController.GetFirstObjectID();
                            }
                        }
                    }
                }
                //If exist template object,copy template object to main object
                else
                {
                    //Get Table which Main Object Represent
                    String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);

                    String strPrimaryColumn = strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "ID";

                    BaseBusinessController objMainObjectController = BusinessControllerFactory.GetBusinessController(strMainObjectTableName + "Controller");
                    BusinessObject objTemplateObject = (BusinessObject)objMainObjectController.GetTemplateObject();
                    MainObject = (BusinessObject)objTemplateObject.Clone();
                    dbUtil.SetPropertyValue(MainObject, strPrimaryColumn.Substring(0, strPrimaryColumn.Length - 2) + "No", cstNewObjectText);
                    dbUtil.SetPropertyValue(MainObject, AAStatusColumn, BusinessObject.DefaultAAStatus);
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
        /// Set Default Module Objects
        /// </summary>
        public virtual void SetDefaultModuleObjects()
        {
            String[] keysArray = new String[ModuleObjects.Count];
            ModuleObjects.Keys.CopyTo(keysArray, 0);
            for (int i = 0; i < keysArray.Length; i++)
            {
                String strModuleObjectName = keysArray[i].ToString();
                SetDefaultModuleObject(strModuleObjectName);
            }
        }

        public virtual void SetDefaultModuleObject(String strModuleObjectName)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();

            //Renew BusinessObject
            String strModuleObjectTypeName = ModuleObjects[strModuleObjectName].GetType().Name;
            ModuleObjects[strModuleObjectName] = BusinessObjectFactory.GetBusinessObject(strModuleObjectTypeName);

            //Get Table which Business object Represent
            //String strObjectTableName = ModuleObjects[strModuleObjectName].GetType().Name.Substring(0, ModuleObjects[strModuleObjectName].GetType().Name.Length - 4);
            String strObjectTableName = BOSUtil.GetTableNameFromBusinessObject(ModuleObjects[strModuleObjectName]);

            //Set Default Value for all property is foreign column and not allow null
            DataSet dsForeignKeys = dbUtil.GetTableForeignKeys(strObjectTableName);
            if (dsForeignKeys.Tables.Count > 0)
            {
                foreach (DataRow rowForeignKey in dsForeignKeys.Tables[0].Rows)
                {
                    String strForeignKeyPropertyName = rowForeignKey["COLUMN_NAME"].ToString();
                    if (!dbUtil.ColumnIsAllowNull(strObjectTableName, strForeignKeyPropertyName))
                    {
                        String strPrimaryTable = dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(
                                                            strObjectTableName,
                                                            strForeignKeyPropertyName);

                        String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);                        
                        if (!strPrimaryTable.Equals(strMainObjectTableName))
                        {
                            BaseBusinessController objPrimaryTableController = new BaseBusinessController(BusinessObjectFactory.GetBusinessObjectType(strPrimaryTable + "Info"));

                            int iPrimaryTableObjectID = objPrimaryTableController.GetFirstObjectID();
                            dbUtil.SetPropertyValue(
                                        ModuleObjects[strModuleObjectName],
                                        strForeignKeyPropertyName,
                                        iPrimaryTableObjectID);
                        }
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
        /// Update Binding Source of Main Object
        /// </summary>        
        public virtual void UpdateMainObjectBindingSource()
        {           
            MainObjectBindingSource.DataSource = this.MainObject;
            MainObjectBindingSource.ResetBindings(false);
            
        }

        /// <summary type="Update">
        /// Update Binding Source of Module Objects
        /// </summary>        
        public virtual void UpdateModuleObjectsBindingSource()
        {
            foreach (DictionaryEntry de in ModuleObjects)
            {
                ModuleObjectsBindingSource[de.Key.ToString()].DataSource = de.Value;
                ModuleObjectsBindingSource[de.Key.ToString()].ResetBindings(false);
            }
        }

        /// <summary type="Update">
        /// Update Binding Source Of Module Object By Module Object Name
        /// </summary>
        /// <param name="strModuleObjectName">Module Object Name will be updated</param>
        public virtual void UpdateModuleObjectBindingSource(String strModuleObjectName)
        {
            ModuleObjectsBindingSource[strModuleObjectName].DataSource = ModuleObjects[strModuleObjectName];
            ModuleObjectsBindingSource[strModuleObjectName].ResetBindings(false);
        }
        #endregion

        #region Function for create Module Entity  
        public virtual String GetMainObjectNo(ref int numberingStart)
        {
            String strMainObjectNo = String.Empty;
            String currentYear = DateTime.Now.ToString("yy");
            GENumberingController objGENumberingController = new GENumberingController();
            GENumberingInfo objGENumberingInfo = (GENumberingInfo)new GENumberingController().GetObjectByName(Module.Name);
            if (objGENumberingInfo != null)
            {                                
                String mainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
                BaseBusinessController objMainObjectController = BusinessControllerFactory.GetBusinessController(mainTableName + "Controller");
                if (objMainObjectController != null)
                {
                    strMainObjectNo = String.Format("{0}{1}-{2}", objGENumberingInfo.GENumberingPrefix, currentYear, objGENumberingInfo.GENumberingStart);
                    numberingStart = objGENumberingInfo.GENumberingStart;
                    while (objMainObjectController.IsExist(strMainObjectNo))
                    {
                        objGENumberingInfo.GENumberingStart++;
                        strMainObjectNo = String.Format("{0}{1}-{2}", objGENumberingInfo.GENumberingPrefix, currentYear, objGENumberingInfo.GENumberingStart);
                        numberingStart = objGENumberingInfo.GENumberingStart;
                    }
                }
            }            
            return strMainObjectNo;
        }

        /// <summary>
        /// Get main object number automatically from config
        /// </summary>
        /// <returns>Main object number</returns>
        public virtual string GetMainObjectNo()
        {
            int numberingStart = 0;
            return GetMainObjectNo(ref numberingStart);
        }
        
        public virtual int CreateMainObject()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            int iObjectID = 0;
            bool bIsEditObjectNo = true;

            //Get Table which Business object Represent            
            String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            BaseBusinessController objMainObjectController = BusinessControllerFactory.GetBusinessController(strMainObjectTableName + "Controller");
            
            //Set Object No value
            String strPrimaryColumn = strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "ID";
            String strColumnNo = strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "No";
            String strMainObjectNo = dbUtil.GetPropertyStringValue(MainObject, strColumnNo);
            int numberingStart = 0;
            if (strMainObjectNo.Equals(cstNewObjectText))
            {
                bIsEditObjectNo = false;
                strMainObjectNo = GetMainObjectNo(ref numberingStart);
                dbUtil.SetPropertyValue(MainObject, strColumnNo, strMainObjectNo);
            }

            //Set Created User, Created Date
            dbUtil.SetPropertyValue(MainObject, AACreatedUser, BOSApp.CurrentUser);
            dbUtil.SetPropertyValue(MainObject, AACreatedDate, DateTime.Now);


            iObjectID = dbUtil.GetPropertyIntValue(MainObject, strPrimaryColumn);
            if (iObjectID == 0)
            {
                iObjectID = objMainObjectController.CreateObject(MainObject);
            }
            else
            {
                objMainObjectController.CreateObject(MainObject, iObjectID);
            }

            if (iObjectID > 0)
            {
                if(!bIsEditObjectNo)
                    UpdateObjectNumbering(numberingStart);

                String strMainObjectPrimaryColumnName = dbUtil.GetTablePrimaryColumn(strMainObjectTableName);
                dbUtil.SetPropertyValue(MainObject, strMainObjectPrimaryColumnName, iObjectID);
            }

            return iObjectID;
        }
        
        /// <summary type="Save">
        /// Update Current Object
        /// </summary>
        /// <returns></returns>
        public virtual int UpdateMainObject()
        {
            int iObjectID = 0;
            String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            BaseBusinessController objMainObjectController = BusinessControllerFactory.GetBusinessController(strMainObjectTableName + "Controller");

            //Set AAUpdatedUser, AAUpdatedDate
            BOSDbUtil dbUtil = new BOSDbUtil();
            dbUtil.SetPropertyValue(MainObject, AAUpdatedUser, BOSApp.CurrentUser);
            dbUtil.SetPropertyValue(MainObject, AAUpdatedDate, DateTime.Now);

            iObjectID = objMainObjectController.UpdateObject(MainObject);
            
            return iObjectID;
        }

        /// <summary type="Save">
        /// Save Main Object
        /// </summary>
        /// <returns></returns>
        public virtual int SaveMainObject()
        {
            if (Module.Toolbar.IsNewAction())
                return CreateMainObject();
            else
                return UpdateMainObject();
        }

        public virtual bool IsExistTemplateObject()
        {
            String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            BaseBusinessController objMainObjectController = BusinessControllerFactory.GetBusinessController(strMainObjectTableName + "Controller");
            BusinessObject objTemplateObject = (BusinessObject)objMainObjectController.GetTemplateObject();
            if (objTemplateObject != null)
                return true;
            return false;
        }


        public virtual void SaveModuleObjects()
        {

        }       
        
        public void UpdateObjectNumbering(int numberingStart)
        {
            GENumberingController objGENumberingController = new GENumberingController();
            GENumberingInfo objGENumberingInfo = (GENumberingInfo)objGENumberingController.GetObjectByName(Module.Name);
            if (objGENumberingInfo != null)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();                
                objGENumberingInfo.GENumberingStart = numberingStart + 1;
                objGENumberingController.UpdateObject(objGENumberingInfo);
            }
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

        public virtual void Delete(int iObjectID)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    BaseBusinessController objCurrentObjectController = BusinessControllerFactory.GetBusinessController(MainObject.GetType().Name.Substring(0, MainObject.GetType().Name.Length - 4) + "Controller");
                    objCurrentObjectController.DeleteObject(iObjectID);
                    String strTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
                    DeleteObjectRelations(strTableName, iObjectID);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                }
            }
        }

        /// <summary>
        /// Delete all relations of deleted object
        /// </summary>
        public virtual void DeleteObjectRelations(String strTableName, int iObjectID)
        {

        }

        public virtual void DeleteModuleObject(String strModuleObjectName, int iObjectID)
        {

        }

        public virtual void SaveMainObjectRelations()
        {

        }

        public virtual void SaveObjectItemRelations(ERPModuleItemsEntity entItems)
        {

        }

        /// <summary>
        /// Complete transaction and update inventory
        /// </summary>
        public virtual bool CompleteTransaction()
        {
            return true;
        }        
        #endregion

        #region Utitlity functions
        public List<FATransactionsInfo> CopyFATransactionsList(List<FATransactionsInfo> lstSourceFATransactions)
        {
            List<FATransactionsInfo> lstDestFATransaction = new List<FATransactionsInfo>();
            foreach (FATransactionsInfo objFATransactionsInfo in lstSourceFATransactions)
            {
                FATransactionsInfo objCopyTransactionsInfo = (FATransactionsInfo)objFATransactionsInfo.Clone();
                lstDestFATransaction.Add(objCopyTransactionsInfo);
            }

            return lstDestFATransaction;
        }

        public List<ERPModuleItemsEntity> GetModuleItemsEntityList(String strModuleItemsEntityName)
        {
            List<ERPModuleItemsEntity> lstERPModuleItemsEntity = new List<ERPModuleItemsEntity>();
            foreach (FieldInfo field in this.GetType().GetFields())
            {
                if (field.FieldType.FullName.Contains("System.Collections.Generic"))
                {                    
                    Type[] arrType = field.FieldType.GetGenericArguments();
                    if (arrType[0].Name.Contains(strModuleItemsEntityName))
                    {
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
                }
            }
            return null;
        }

        public List<BusinessObject> GetBusinessObjectList(String strBusinessObjectName)
        {
            List<BusinessObject> lstBusinessObject = new List<BusinessObject>();
            foreach (FieldInfo field in this.GetType().GetFields())
            {
                if (field.FieldType.FullName.Contains("System.Collections.Generic"))
                {
                    Type[] arrType = field.FieldType.GetGenericArguments();
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
            }
            return null;
        }

        public virtual void UpdateInventory(BusinessObject item, String strUpdateStatus, String strItemTableName)
        {

        }        
        #endregion        
        
        #region Generate Entity from Related Entity functions
        public virtual void GenerateEntity(BusinessObject objRelatedMainObjectInfo)
        {
            String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            String strModuleItemsTableName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Items";

            GenerateMainObject(objRelatedMainObjectInfo);

            GenerateModuleItemsList(objRelatedMainObjectInfo);
        }

        public virtual void GenerateMainObject(BusinessObject objRelatedMainObjectInfo)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            String strRelatedTableName = BOSUtil.GetTableNameFromBusinessObject(objRelatedMainObjectInfo);
            String strPrefixMainTable = strMainTableName.Substring(0, 2);
            String strPrefixRelatedMainTable = strRelatedTableName.Substring(0, 2);

            String strMainObjectNoPropertyName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "No";
            String strMainObjectStatusPropertyName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Status";
            String strMainObjectTypePropertyName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "TypeCombo";

            PropertyInfo[] properties = MainObject.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                if (!dbUtil.IsPrimaryKey(strMainTableName, prop.Name))
                {
                    if (!dbUtil.IsForeignKey(strMainTableName, prop.Name))
                    {
                        if (!prop.Name.Equals(strMainObjectNoPropertyName) && !prop.Name.Equals(strMainObjectStatusPropertyName) && !prop.Name.StartsWith("AA") && !prop.Name.Equals(strMainObjectTypePropertyName))
                        {
                            if (prop.Name.StartsWith(strMainTableName.Substring(0, strMainTableName.Length - 1)))
                            {
                                String strRelatedPropertyName = strRelatedTableName.Substring(0, strRelatedTableName.Length - 1) + prop.Name.Substring(strMainTableName.Length-1);
                                PropertyInfo relatedProp = objRelatedMainObjectInfo.GetType().GetProperty(strRelatedPropertyName);
                                if (relatedProp != null)
                                {
                                    object objValue = relatedProp.GetValue(objRelatedMainObjectInfo, null);
                                    prop.SetValue(MainObject, objValue, null);
                                }
                            }
                            else
                            {
                                PropertyInfo relatedProperty = objRelatedMainObjectInfo.GetType().GetProperty(prop.Name);
                                if (relatedProperty != null)
                                {
                                    object objValue = relatedProperty.GetValue(objRelatedMainObjectInfo, null);
                                    prop.SetValue(MainObject, objValue, null);
                                }
                            }

                        }
                    }
                    else
                    {
                        PropertyInfo relatedProperty = objRelatedMainObjectInfo.GetType().GetProperty(prop.Name);
                        if (relatedProperty != null)
                        {
                            object objValue = relatedProperty.GetValue(objRelatedMainObjectInfo, null);
                            prop.SetValue(MainObject, objValue, null);
                        }
                    }
                }

            }

            UpdateMainObjectBindingSource();
        }

        public virtual void GenerateModuleItemsList(BusinessObject objRelatedMainObjectInfo)
        {

        }        

        public virtual void AddItemsRelations(ERPModuleItemsEntity entModuleItems, BusinessObject objRelatedModuleItemsInfo)
        {

        }
        #endregion
    }
}
