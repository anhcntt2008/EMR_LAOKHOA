using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ListControls;
using BOSCommon;
using BOSERP;
using BOSLib;
using Localization;
using DevExpress.Data.Filtering;
using DevExpress.Data;

namespace BOSComponent
{
    #region Customize Base Behaviours for Multiple-column Filtering
    public class BOSLookupListDataAdapter : DevExpress.XtraEditors.ListControls.LookUpListDataAdapter
    {        
        public BOSLookupListDataAdapter(RepositoryItemBOSLookupEdit item) : base(item)
        {
            
        }

        /// <summary>
        /// Create expression that filters all columns, not only DisplayMember
        /// uthv up dev exp 16.1
        /// </summary>
        protected override CriteriaOperator CreateFilterCriteria()
        {
            if (string.IsNullOrEmpty(this.FilterPrefix))
                return null;
            String filterExpression = String.Empty;
            if (this.Item.OwnerEdit.GetType().Name == "ItemLookupEdit")
            {
                String[] words = this.FilterPrefix.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    String word = BOSUtil.GetSearchString(words[i].Replace("'", "''"));
                    filterExpression += "(";
                    filterExpression += String.Format(" [{0}] LIKE '%{1}%'", "LookupInfo", word);
                    filterExpression += ")";
                    if (i < words.Length - 1)
                        filterExpression += " AND ";
                }
            }
            else
            {
                String[] words = this.FilterPrefix.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    String word = BOSUtil.GetSearchString(words[i].Replace("'", "''"));
                    filterExpression += "(";
                    for (int j = 0; j < this.Item.OwnerEdit.Properties.Columns.Count; j++)
                    {
                        LookUpColumnInfo column = this.Item.OwnerEdit.Properties.Columns[j];
                        filterExpression += String.Format(" [{0}] LIKE '%{1}%'", column.FieldName, word);
                        if (j < this.Item.OwnerEdit.Properties.Columns.Count - 1)
                            filterExpression += " OR";
                    }
                    filterExpression += ")";
                    if (i < words.Length - 1)
                        filterExpression += " AND ";
                }
            }
            return CriteriaOperator.Parse(filterExpression.ToString());
        }
    }

    [UserRepositoryItem("RegisterBOSLookupEdit")]
    public class RepositoryItemBOSLookupEdit : RepositoryItemLookUpEdit
    {
        static RepositoryItemBOSLookupEdit() { RegisterBOSLookupEdit(); }

        public RepositoryItemBOSLookupEdit()
            : base()
        {

        }
        public override void BeginInit()
        {
            base.BeginInit();
            if(this.DataSource == null)
            {

            }

        }
        public override void EndInit()
        {
            if (this.DataSource == null)
            {

            }
            base.EndInit();
        }
        public const string BOSLookupEditName = "BOSLookupEdit";

        public override string EditorTypeName { get { return BOSLookupEditName; } }

        public static void RegisterBOSLookupEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(BOSLookupEditName,
              typeof(BOSLookupEdit), typeof(RepositoryItemBOSLookupEdit),
              typeof(LookUpEditViewInfo), new ButtonEditPainter(), true, null));
        }

        protected override LookUpListDataAdapter CreateDataAdapter()
        {
            return new BOSLookupListDataAdapter(this);
        }
    }
    #endregion

    public partial class BOSLookupEdit : DevExpress.XtraEditors.LookUpEdit, IBOSControl
    {
        static BOSLookupEdit() { RepositoryItemBOSLookupEdit.RegisterBOSLookupEdit(); }

        public override string EditorTypeName { get { return RepositoryItemBOSLookupEdit.BOSLookupEditName; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemBOSLookupEdit Properties { get { return base.Properties as RepositoryItemBOSLookupEdit; } }
        #region Variables
        protected BOSScreen _screen;
        protected String _BOSFieldGroup;
        protected String _BOSFieldParent;
        protected String _BOSFieldRelation;
        protected String _BOSDataSource;
        protected String _BOSDataMember;
        protected String _BOSPropertyName;
        protected bool _BOSAllowDummy;
        protected String _BOSSelectType;
        protected String _BOSSelectTypeValue;
        protected String _BOSError;
        protected String _BOSComment;
        protected String _BOSPrivilege;
        protected String _BOSDescription;
        protected String _currentDisplayText;
        protected SortedList LookupTables;
        protected SortedList LookupTablesUpdatedDate;
        protected DateTime LastUpdatedDate;
        protected string _BOSDummyText;

        /// <summary>
        /// A variable to store the display member of the lookup edit
        /// </summary>
        private string DisplayMember = App.DefaultString;
        #endregion

        #region Public properties
        [Category("Design")]
        [Browsable(true)]
        public new String Name
        {
            get
            {
                return base.Name;
            }

            set
            {
                base.Name = value;
            }
        }

        public BOSScreen Screen
        {
            get
            {
                return _screen;
            }
            set
            {
                _screen = value;
            }
        }

        [Category("BOS")]
        public String BOSFieldGroup
        {
            get
            {
                return _BOSFieldGroup;
            }
            set
            {
                _BOSFieldGroup = value;
            }
        }

        [Category("BOS")]
        public String BOSFieldParent
        {
            get
            {
                return _BOSFieldParent;
            }
            set
            {
                _BOSFieldParent = value;
            }
        }

        [Category("BOS")]
        public String BOSFieldRelation
        {
            get
            {
                return _BOSFieldRelation;
            }
            set
            {
                _BOSFieldRelation = value;
            }
        }

        [Category("BOS")]
        public String BOSDataSource
        {
            get
            {
                return _BOSDataSource;
            }
            set
            {
                _BOSDataSource = value;
            }
        }

        [Category("BOS")]
        public String BOSDataMember
        {
            get
            {
                return _BOSDataMember;
            }
            set
            {
                _BOSDataMember = value;
            }
        }

        [Category("BOS")]
        public bool BOSAllowDummy
        {
            get
            {
                return _BOSAllowDummy;
            }
            set
            {
                _BOSAllowDummy = value;
            }
        }
        [Category("BOS")]
        public string BOSDummyText
        {
            get
            {
                return _BOSDummyText;
            }
            set
            {
                _BOSDummyText = value;
            }
        }

        [Category("BOS")]
        public String BOSSelectType
        {
            get
            {
                return _BOSSelectType;
            }
            set
            {
                _BOSSelectType = value;
            }
        }

        [Category("BOS")]
        public String BOSSelectTypeValue
        {
            get
            {
                return _BOSSelectTypeValue;
            }
            set
            {
                _BOSSelectTypeValue = value;
            }
        }

        [Category("BOS")]
        public String BOSError
        {
            get
            {
                return _BOSError;
            }
            set
            {
                _BOSError = value;
            }
        }

        [Category("BOS")]
        public String BOSPropertyName
        {
            get
            {
                return _BOSPropertyName;
            }
            set
            {
                _BOSPropertyName = value;
            }
        }

        [Category("BOS")]
        public String BOSComment
        {
            get
            {
                return _BOSComment;
            }
            set
            {
                _BOSComment = value;
            }
        }

        [Category("BOS")]
        public String BOSPrivilege
        {
            get
            {
                return _BOSPrivilege;
            }
            set
            {
                _BOSPrivilege = value;
            }
        }

        [Category("BOS")]
        public String BOSDescription
        {
            get
            {
                return _BOSDescription;
            }
            set
            {
                _BOSDescription = value;
            }
        }

        [Category("BOS")]
        public bool BOSAllowAddNew { get; set; }

        [Category("BOS")]
        public bool BOSAllowMange { get; set; }

        public String CurrentDisplayText
        {
            get { return _currentDisplayText; }
            set { _currentDisplayText = value; }
        }
        #endregion

        public BOSLookupEdit()
        {
            InitializeComponent();

            Size = new Size(150, 20);
            if (Devide.Current == Devide.Tablet)
            {
                Properties.DropDownItemHeight = 30;
            }
        }

        public BOSLookupEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Size = new Size(150, 20);
            if (Devide.Current == Devide.Tablet)
            {
                Properties.DropDownItemHeight = 30;
            }
        }

        public BOSLookupEdit(BOSScreen scr)
        {
            _screen = scr;
         
            InitializeComponent();

            Size = new Size(125, 20);
            
            InitializeControl();
            if (Devide.Current == Devide.Tablet)
            {
                Properties.DropDownItemHeight = 30;
            }
        }

        #region Initialize LookupEdit functions
        public virtual void InitializeControl(STFieldsInfo objFieldInfo)
        {
            this.BOSFieldParent = objFieldInfo.STFieldFieldParent;
            this.BOSAllowDummy = objFieldInfo.STFieldAllowDummy;
            this.BOSSelectType = objFieldInfo.STFieldSelectType;
            this.BOSSelectTypeValue = objFieldInfo.STFieldSelectTypeValue;
            this.BOSPrivilege = objFieldInfo.STFieldPrivilege;

            this.Properties.DisplayMember = objFieldInfo.STFieldDisplayMember;
            this.Properties.ValueMember = objFieldInfo.STFieldValueMember;
        }

        public virtual void InitializeControl()
        {
            try
            {
                LookupTables = ((IBaseModuleERP)Screen.Module).GetLookupTableCollection();
                LookupTablesUpdatedDate = ((IBaseModuleERP)Screen.Module).GetLookupTableUpdatedDateCollection();                

                //Init lookup edit columns                
                InitLookupEditColumns();

                InitObjectDataToLookupEdit();

                LastUpdatedDate = DateTime.Now;
                Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                Properties.SearchMode = SearchMode.AutoFilter;       
                Properties.TextEditStyle = TextEditStyles.Standard;
                Properties.NullText = string.Empty;

                if (!String.IsNullOrEmpty(BOSDataSource) && !String.IsNullOrEmpty(BOSDataMember))
                {
                    if (!BOSDataSource.Equals("ADConfigValues"))
                        ((BOSScreen)Screen).BindingDataControl(this);
                }
                
                this.Click += ((IBaseModuleERP)Screen.Module).Control_Click;
                this.KeyUp += new KeyEventHandler(((IBaseModuleERP)Screen.Module).Control_KeyUp);
                this.KeyUp += new KeyEventHandler(BOSLookupEdit_KeyUp);
                this.EditValueChanged += new EventHandler(BOSLookupEdit_EditValueChanged);
                this.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(BOSLookupEdit_ProcessNewValue);
                this.QueryPopUp += new CancelEventHandler(BOSLookupEdit_QueryPopUp);
                this.Leave += new EventHandler(BOSLookupEdit_Leave);    
                this.KeyDown += new KeyEventHandler(BOSLookupEdit_KeyDown);
                this.CloseUp += new CloseUpEventHandler(BOSLookupEdit_CloseUp);

                if (Devide.Current == Devide.Tablet)
                {
                    Properties.DropDownItemHeight = 30;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void InitObjectDataToLookupEdit()
        {          
            String strTableName = BOSDataSource;
            String strColumnName = BOSDataMember;
            BOSDbUtil dbUtil = new BOSDbUtil();

            //If DataMember is not empty
            if (!String.IsNullOrEmpty(strColumnName))
            {
                //If is foreign key
                if (dbUtil.IsForeignKey(strTableName, strColumnName))
                {
                    String strLookupTable = dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(BOSDataSource, BOSDataMember);
                    InitObjectDataFromLookupTable(strLookupTable);
                }
                else
                {
                    String configValueTable = GetConfigValueGroup();
                    if (!string.IsNullOrEmpty(configValueTable))
                    {
                        this.Properties.DataSource = ADConfigValueUtility.ConfigValues.Tables[configValueTable];
                        this.Properties.ValueMember = "Value";
                        this.Properties.DisplayMember = "Text";
                        DevExpress.XtraEditors.Controls.LookUpColumnInfo column = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                        column.Caption = ComponentLocalizedResources.Name;
                        column.FieldName = "Text";
                        column.Width = 100;
                        this.Properties.Columns.Add(column);
                        this.Properties.PopupWidth = column.Width;
                        Properties.ShowHeader = false;
                    }
                    else
                    {
                        InitObjectDataFromLookupTable(strTableName);
                    }
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(strTableName))
                {
                    InitObjectDataFromLookupTable(strTableName);
                }
            }
        }

        /// <summary>
        /// Init object data from lookup table
        /// </summary>
        /// <param name="strLookupTable">Lookup table name</param>
        protected bool InitObjectDataFromLookupTable(String strLookupTable)
        {
            if (LookupTables[strLookupTable] != null)
            {
                DataTable table = ((DataSet)LookupTables[strLookupTable]).Tables[0].Copy();
                InitObjectDataFromLookupTable(table, strLookupTable);
                return true;
            }
            else
            {
                ((IBaseModuleERP)Screen.Module).GetLookupTableByName(strLookupTable);
                if (LookupTables[strLookupTable] != null)
                {
                    DataTable table = ((DataSet)LookupTables[strLookupTable]).Tables[0].Copy();
                    InitObjectDataFromLookupTable(table, strLookupTable);
                    return true;
                }}
            return false;
        }

        /// <summary>
        /// Init data source for lookup edit from a lookup table
        /// </summary>
        /// <param name="dataSource">Data source</param>
        /// <param name="tableName">Name of table the data source is gotten from</param>
        protected void InitObjectDataFromLookupTable(DataTable dataSource, string tableName)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            //Get all data which column "BOSSelectType" contains BOSSelectTypeValue from look up table
            if (!String.IsNullOrEmpty(BOSSelectType))
            {
                if (dbUtil.ColumnIsExist(tableName, BOSSelectType))
                {
                    for (int i = 0; i < dataSource.Rows.Count; i++)
                    {
                        DataRow row = dataSource.Rows[i];
                        string value = row[BOSSelectType].ToString();
                        string[] selectTypeValues = BOSSelectTypeValue.Split(new char[] { ';' });
                        bool isRemoved = true;
                        foreach (string selectTypeValue in selectTypeValues)
                        {
                            if (value.Contains(selectTypeValue))
                            {
                                isRemoved = false;
                                break;
                            }
                        }
                        if (isRemoved)
                        {
                            dataSource.Rows.Remove(row);
                            i--;
                        }
                    }
                }
            }

            bool hasDummyRow = false;
            if (BOSAllowDummy)
            {
                if (dataSource.Rows.Count > 0)
                {
                    object value = dataSource.Rows[0][this.Properties.ValueMember];
                    if (value is int)
                    {
                        if (Convert.ToInt32(value) > 0)
                        {
                            DataRow row = dataSource.NewRow();
                            row[this.Properties.ValueMember] = 0;
                            if (dataSource.Columns.Contains(this.Properties.DisplayMember))
                                row[this.Properties.DisplayMember] = BOSDummyText;
                            dataSource.Rows.InsertAt(row, 0);
                            hasDummyRow = true;
                        }
                    }
                    else if (value is string)
                    {
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            DataRow row = dataSource.NewRow();
                            row[this.Properties.ValueMember] = string.Empty;
                            if (dataSource.Columns.Contains(this.Properties.DisplayMember))
                                row[this.Properties.DisplayMember] = BOSDummyText;
                            dataSource.Rows.InsertAt(row, 0);
                            hasDummyRow = true;
                        }
                    }
                }
            }

            if (BOSAllowAddNew)
            {
                DataRow row = dataSource.NewRow();
                row[this.Properties.ValueMember] = -1;
                row[this.Properties.DisplayMember] = ComponentLocalizedResources.AddNew;
                if (hasDummyRow)
                {
                    dataSource.Rows.InsertAt(row, 1);
                }
                else
                {
                    dataSource.Rows.InsertAt(row, 0);
                }
            }

            if (BOSAllowMange)
            {
                DataRow row = dataSource.NewRow();
                row[this.Properties.ValueMember] = -2;
                row[this.Properties.DisplayMember] = ComponentLocalizedResources.Manage;
                if (hasDummyRow)
                {
                    dataSource.Rows.InsertAt(row, 1);
                }
                else
                {
                    dataSource.Rows.InsertAt(row, 0);
                }
            }
            this.Properties.DataSource = dataSource;

            if (((DataSet)LookupTables[tableName]).Tables[0].Rows.Count > 0)
                this.ItemIndex = 0;
        }

        public virtual void InitLookupEditColumns()
        {
            STFieldsInfo objSTFieldsInfo = null;            
            if (Screen.Fields.ContainsKey(Name))
            {
                objSTFieldsInfo = Screen.Fields[Name];
            }
            if (objSTFieldsInfo != null)
            {
                STFieldColumnsController objSTFieldColumnsController = new STFieldColumnsController();
                DataSet dsFieldColumns = objSTFieldColumnsController.GetAllDataByForeignColumn("STFieldID", objSTFieldsInfo.STFieldID);
                if (dsFieldColumns.Tables.Count > 0)
                {
                    if (dsFieldColumns.Tables[0].Rows.Count > 0)
                        this.Properties.Columns.Clear();
                    this.Properties.PopupWidth = 0;
                    foreach (DataRow rowFieldColumn in dsFieldColumns.Tables[0].Rows)
                    {
                        STFieldColumnsInfo objSTFieldColumnsInfo = (STFieldColumnsInfo)objSTFieldColumnsController.GetObjectFromDataRow(rowFieldColumn);
                        if (objSTFieldColumnsInfo != null)
                        {
                            DevExpress.XtraEditors.Controls.LookUpColumnInfo column = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                            column.Caption = objSTFieldColumnsInfo.STFieldColumnCaption;
                            column.FieldName = objSTFieldColumnsInfo.STFieldColumnFieldName;
                            column.FormatType = (DevExpress.Utils.FormatType)Enum.Parse(typeof(DevExpress.Utils.FormatType), objSTFieldColumnsInfo.STFieldColumnFormatType);
                            column.FormatString = objSTFieldColumnsInfo.STFieldColumnFormatString;
                            column.Width = objSTFieldColumnsInfo.STFieldColumnWidth;
                            this.Properties.Columns.Add(column);
                            this.Properties.PopupWidth += column.Width;
                        }
                    }
                }
                dsFieldColumns.Dispose();
            }
        }
       
        /// <summary>
        /// Invalidate data source to LookupEdit which belongs to field parent
        /// For reflecting changes made to data source
        /// </summary>
        private void InvalidateDataSourceToLookupEditWhichBelongsToFieldParent()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            BOSLookupEdit lkeFieldParent = (BOSLookupEdit)this.Screen.Module.Controls[BOSFieldParent];
            InvalidateDataSourceToLookupEditWhichBelongsToFieldParent(lkeFieldParent);
        }
        public void InvalidateDataSourceToLookupEditWhichBelongsToFieldParent(BOSLookupEdit lkeFieldParent)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();

            if (lkeFieldParent != null)
            {
                String strFieldParentLookupTable = dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(lkeFieldParent.BOSDataSource, lkeFieldParent.BOSDataMember);
                String strFieldParentPrimaryColumn = dbUtil.GetTablePrimaryColumn(strFieldParentLookupTable);
                String strLookupTable = dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(this.BOSDataSource, this.BOSDataMember);

                if (String.IsNullOrEmpty(strLookupTable))
                    strLookupTable = this.BOSDataSource;

                String strForeignColumn = "FK_" + strFieldParentPrimaryColumn;
                BaseBusinessController objLookupTableController = BusinessControllerFactory.GetBusinessController(strLookupTable + "Controller");

                if (objLookupTableController != null)
                {
                    DataSet ds = objLookupTableController.GetAllDataByForeignColumn(strForeignColumn, lkeFieldParent.EditValue);
                    //Binding LookupEdit
                    if (ds.Tables.Count > 0)
                    {
                        DataTable dtLookupTable = ds.Tables[0];
                        //Get all data which column "BOSSelectType" contains BOSSelectTypeValue from look up table
                        if (!String.IsNullOrEmpty(BOSSelectType))
                            if (dbUtil.ColumnIsExist(strLookupTable, BOSSelectType))
                                for (int i = 0; i < dtLookupTable.Rows.Count; i++)
                                {
                                    DataRow row = dtLookupTable.Rows[i];
                                    if (!row[BOSSelectType].ToString().Contains(BOSSelectTypeValue))
                                    {
                                        dtLookupTable.Rows.Remove(row);
                                        i--;
                                    }
                                }

                        if (BOSAllowDummy)
                        {
                            if (dtLookupTable.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtLookupTable.Rows[0][this.Properties.ValueMember]) > 0)
                                {
                                    DataRow row = dtLookupTable.NewRow();
                                    row[this.Properties.ValueMember] = 0;
                                    if (dtLookupTable.Columns.Contains(this.Properties.DisplayMember))
                                        row[this.Properties.DisplayMember] = BOSDummyText;
                                    dtLookupTable.Rows.InsertAt(row, 0);
                                }
                            }
                        }
                        BindingSource bds = new BindingSource();
                        bds.DataSource = dtLookupTable;
                        this.Properties.DataSource = bds;
                    }
                }
            }
        }

        /// <summary>
        /// Invalidate data source to LookupEdit which not belong to field parent
        /// For reflecting changes made to data source
        /// </summary>
        public void InvalidateDataSourceToLookupEdit()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            String strLookupTable = dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(BOSDataSource, BOSDataMember);
            if (String.IsNullOrEmpty(strLookupTable))
                strLookupTable = BOSDataSource;
            if (LookupTables[strLookupTable] != null)
            {
                var dsTemp = (DataSet)LookupTables[strLookupTable];
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
                        DataSet ds = ((IBaseModuleERP)Screen.Module).GetLookupTableData(strLookupTable);
                        if (ds.Tables.Count > 0)
                        {
                            // Update Last Updated Date of Lookup Table
                            LookupTablesUpdatedDate[strLookupTable] = DateTime.Now;
                            LastUpdatedDate = (DateTime)LookupTablesUpdatedDate[strLookupTable];
                            ((DataSet)LookupTables[strLookupTable]).Tables.Clear();
                            ((DataSet)LookupTables[strLookupTable]).Tables.Add(ds.Tables[0].Copy());
                            InitObjectDataFromLookupTable(strLookupTable);
                        }
                    }
                }

                if (((DateTime)LookupTablesUpdatedDate[strLookupTable]).CompareTo(LastUpdatedDate) > 0)
                {
                    InitObjectDataFromLookupTable(strLookupTable);
                    LastUpdatedDate = (DateTime)LookupTablesUpdatedDate[strLookupTable];
                }
            }
        }

        #region Event Handlers
        protected virtual void BOSLookupEdit_QueryPopUp(object sender, CancelEventArgs e)
        {            
            String configValueGroup = GetConfigValueGroup();
            if (!String.IsNullOrEmpty(configValueGroup))
            {
                this.Properties.DataSource = ADConfigValueUtility.ConfigValues.Tables[configValueGroup];
            }
            else
            {
                if (!String.IsNullOrEmpty(BOSDataSource) && !String.IsNullOrEmpty(BOSDataMember))
                {
                    if (!String.IsNullOrEmpty(BOSFieldParent))
                        InvalidateDataSourceToLookupEditWhichBelongsToFieldParent();
                    else
                        InvalidateDataSourceToLookupEdit();
                }
            }
        }

        protected virtual void BOSLookupEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        protected virtual void BOSLookupEdit_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {

        }

        protected virtual void BOSLookupEdit_Leave(object sender, EventArgs e)
        {
            //Reset filter
            object dataSource = Properties.DataSource;
            Properties.DataSource = null;
            Properties.DataSource = dataSource;
        }

        protected virtual void BOSLookupEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                ShowPopup();
            }
        }

        protected virtual void BOSLookupEdit_KeyDown(object sender, KeyEventArgs e)
        {            
            if (!Properties.ReadOnly && !IsPopupOpen)
            {                                           
                byte keyCode = Convert.ToByte(e.KeyCode);
                if ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    if (Properties.DisplayMember != App.DefaultString)
                    {
                        DisplayMember = Properties.DisplayMember;
                    }
                    //Properties.DisplayMember = App.DefaultString;
                }
            }
        }

        protected virtual void BOSLookupEdit_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (DisplayMember != App.DefaultString)
            {
                Properties.DisplayMember = DisplayMember;
            }
        }

        //[NNTien] [ADD] [29/07/2013] [Focus to first row], START
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (this.BOSDataMember != null)
            {
                if (this.BOSDataMember.ToLower().EndsWith("ICProductID".ToLower()))
                {
                    if (char.IsLetterOrDigit(e.KeyChar) || Keys.Back == (Keys)e.KeyChar || Keys.Delete == (Keys)e.KeyChar)
                    {
                        SendKeys.Send("{DOWN}");
                        SendKeys.Send("{UP}");
                    }
                }
            }
        }
        //[NNTien] [ADD] [29/07/2013] [Focus to first row], END
        #endregion

        public static BOSLookupEdit Instance(String strInstanceName, String strModuleName)
        {
            if (!String.IsNullOrEmpty(strInstanceName))
            {
                Assembly BOSERPAssembly = Assembly.LoadFrom(Application.StartupPath + "\\EMR.exe");
                Type gridType = BOSERPAssembly.GetType("BOSERP.Modules." + strModuleName + "." + strInstanceName + "LookupEdit");
                if (gridType != null)
                {
                    return (BOSLookupEdit)gridType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
                }
                else
                {
                    gridType = BOSERPAssembly.GetType("BOSERP." + strInstanceName + "GridControl");
                    if (gridType != null)
                        return (BOSLookupEdit)gridType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
                    else
                        return new BOSLookupEdit();
                }
            }
            else
                return new BOSLookupEdit();
        }

        /// <summary>
        /// Get ADConfigValueGroup to initialize data source from  ADConfigValues table
        /// </summary>
        private String GetConfigValueGroup()
        {
            string configValueTable = string.Empty;
            if (!string.IsNullOrEmpty(BOSDataSource) && !string.IsNullOrEmpty(BOSDataMember))
            {
                if (BOSDataSource == TableName.ADConfigValuesTableName)
                {
                    configValueTable = BOSDataMember;
                }
                else
                {
                    if (BOSDataMember.Contains("Combo"))
                    {
                        configValueTable = BOSDataMember.Substring(2, BOSDataMember.Length - 7);
                    }
                    else
                    {
                        configValueTable = BOSDataMember.Substring(2, BOSDataMember.Length - 2);
                    }
                }

                if (ADConfigValueUtility.ConfigValues.Tables[configValueTable] != null)
                {


                    if ((Tag != null && Tag.ToString() == BOSScreen.SearchControl) && BOSAllowDummy)
                    {
                        configValueTable = configValueTable + "DummySearch";
                    }
                    else if ((Tag != null && Tag.ToString() == BOSScreen.SearchControl) || BOSAllowDummy)
                    {
                        configValueTable = configValueTable + "Search";
                    }
                }
                else
                {
                    configValueTable = string.Empty;
                }
            }            
            return configValueTable;
        }
        #endregion
    }
}
