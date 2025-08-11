using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using BOSLib;
using DevExpress.XtraTreeList.Nodes;
using Localization;

namespace BOSComponent
{
    public partial class BOSTreeListControl: DevExpress.XtraTreeList.TreeList, IBOSControl
    {
        #region Variables
        protected BOSScreen _screen;
        protected String _BOSFieldGroup;
        protected String _BOSFieldRelation;
        protected String _BOSDataSource;
        protected String _BOSDataMember;
        protected String _BOSPropertyName;
        protected String _BOSComment;
        protected String _BOSError;
        protected bool _BOSDisplayRoot;
        protected bool _BOSDisplayOption;
        protected String _BOSPrivilege;
        protected String _BOSDescription;
        private SortedList LookupTables;
        private SortedList LookupTablesUpdatedDate;
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
        public bool BOSDisplayRoot
        {
            get
            {
                return _BOSDisplayRoot;
            }
            set
            {
                _BOSDisplayRoot = value;
            }
        }

        [Category("BOS")]
        public bool BOSDisplayOption
        {
            get
            {
                return _BOSDisplayOption;
            }
            set
            {
                _BOSDisplayOption = value;
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
        #endregion

        public BOSTreeListControl()
        {
            InitializeComponent();
        }

        public BOSTreeListControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public virtual void InitializeControl(STFieldsInfo objFieldInfo)
        {
            this.BOSDisplayRoot = objFieldInfo.STFieldDisplayRoot;
            this.BOSDisplayOption = objFieldInfo.STFieldDisplayOption;
        }

        public virtual void InitializeControl()
        {
            LookupTables = ((IBaseModuleERP)Screen.Module).GetLookupTableCollection();
            LookupTablesUpdatedDate = ((IBaseModuleERP)Screen.Module).GetLookupTableUpdatedDateCollection();

            OptionsBehavior.EnterMovesNextColumn = true;

            //Init tree list columns
            InitTreeListColumns(BOSDataSource);

            //Init tree list data source
            InitTreeListDataSource();
        }

        public virtual void InitTreeListColumns(String strTableName)
        {
            //Add bound columns
            AAColumnAliasController objAAColumnAliasController = new AAColumnAliasController();
            DataSet dsColumns = objAAColumnAliasController.GetAAColumnAliasByTableName(strTableName);
            if (dsColumns.Tables.Count > 0)
            {
                foreach (DataRow rowColumn in dsColumns.Tables[0].Rows)
                {
                    AAColumnAliasInfo objAAColumnAliasInfo = (AAColumnAliasInfo)objAAColumnAliasController.GetObjectFromDataRow(rowColumn);
                    if (objAAColumnAliasInfo != null)
                    {
                        if (this.Columns.ColumnByFieldName(objAAColumnAliasInfo.AAColumnAliasName) == null)
                        {
                            DevExpress.XtraTreeList.Columns.TreeListColumn column = InitTreeListColumn(strTableName, -1, objAAColumnAliasInfo.AAColumnAliasName, objAAColumnAliasInfo.AAColumnAliasCaption, 50);
                            if (new BOSDbUtil().IsForeignKey(strTableName, objAAColumnAliasInfo.AAColumnAliasName))
                            {
                                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookupEdit = InitColumnLookupEdit(strTableName, objAAColumnAliasInfo.AAColumnAliasName);
                                if (repLookupEdit != null)
                                {
                                    column.ColumnEdit = repLookupEdit;
                                    this.RepositoryItems.Add(repLookupEdit);
                                }
                            }
                            else
                            {
                                String strConfigValueTable = String.Empty;

                                if (objAAColumnAliasInfo.AAColumnAliasName.EndsWith("Combo"))
                                    strConfigValueTable = objAAColumnAliasInfo.AAColumnAliasName.Substring(2, objAAColumnAliasInfo.AAColumnAliasName.Length - 7);
                                else
                                    strConfigValueTable = objAAColumnAliasInfo.AAColumnAliasName.Substring(2, objAAColumnAliasInfo.AAColumnAliasName.Length - 2);

                                if (ADConfigValueUtility.ConfigValues.Tables[strConfigValueTable] != null)
                                {
                                    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLookupEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

                                    repLookupEdit.DataSource = ADConfigValueUtility.ConfigValues.Tables[strConfigValueTable];
                                    repLookupEdit.ValueMember = "Value";
                                    repLookupEdit.DisplayMember = "Text";
                                    DevExpress.XtraEditors.Controls.LookUpColumnInfo repColumn = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                                    repColumn.FieldName = "Text";
                                    repColumn.Width = 100;
                                    repLookupEdit.Columns.Add(repColumn);
                                    repLookupEdit.PopupWidth = repColumn.Width;
                                    column.ColumnEdit = repLookupEdit;
                                    this.RepositoryItems.Add(repLookupEdit);
                                }
                                else
                                {
                                    //Init column repository based on field format group
                                    DevExpress.XtraEditors.Repository.RepositoryItem repItem = InitColumnRepositoryFromFieldFormatGroup(strTableName, objAAColumnAliasInfo.AAColumnAliasName);
                                    column.ColumnEdit = repItem;
                                    this.RepositoryItems.Add(repItem);
                                }
                            }

                            if (column.ColumnEdit != null)
                                InitColumnRepositoryFormat(column, strTableName, objAAColumnAliasInfo.AAColumnAliasName);
                            else
                            {
                                Type type = BOSUtil.GetColumnDataType(BOSDataSource, column.FieldName);
                                if (type == typeof(DateTime))
                                    column.ColumnEdit = BOSUtil.GetRepositoryItemFromText(RepositoryItem.RepositoryItemDateEdit.ToString());
                                else if (type == typeof(bool))
                                    column.ColumnEdit = BOSUtil.GetRepositoryItemFromText(RepositoryItem.RepositoryItemCheckEdit.ToString());
                                else
                                    column.ColumnEdit = BOSUtil.GetRepositoryItemFromText(RepositoryItem.RepositoryItemTextEdit.ToString());
                                InitColumnRepositoryFormat(column, strTableName, objAAColumnAliasInfo.AAColumnAliasName);
                            }

                            column.OptionsColumn.AllowEdit = false;
                            this.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { column });
                        }
                        else
                        {
                            this.Columns[objAAColumnAliasInfo.AAColumnAliasName].Caption = objAAColumnAliasInfo.AAColumnAliasCaption;
                        }
                    }
                }
            }

            if (BOSDisplayOption)
            {
                DevExpress.XtraTreeList.Columns.TreeListColumn column = InitTreeListColumn(strTableName, -1, "Selected", ComponentLocalizedResources.Check, 5);
                column.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                this.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { column });
                this.RepositoryItems.Add(column.ColumnEdit);    
            }
        }

        protected virtual DevExpress.XtraTreeList.Columns.TreeListColumn InitTreeListColumn(String strTableName, int iVisibleIndex, String strFieldName, String strCaption, int iWidth)
        {
            DevExpress.XtraTreeList.Columns.TreeListColumn column = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            column.Name = "col" + strFieldName;
            column.Caption = strCaption;
            column.FieldName = strFieldName;
            column.VisibleIndex = iVisibleIndex;
            column.Visible = true;
            column.Width = iWidth;
            return column;
        }

        protected virtual DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit InitColumnLookupEdit(String strTableName, String strColumnName)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            rep.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            rep.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            rep.NullText = String.Empty;

            String strLookupTable = new BOSDbUtil().GetPrimaryTableWhichForeignColumnReferenceTo(strTableName, strColumnName);
            if (LookupTables[strLookupTable] == null)
                return null;
           
            rep.DataSource =  ((DataSet)LookupTables[strLookupTable]).Tables[0];
            String strPrimaryColumn = new BOSDbUtil().GetTablePrimaryColumn(strLookupTable);
            String strDisplayColumn = GetLookupTableDisplayColumn(strLookupTable);
            rep.ValueMember = strPrimaryColumn;
            rep.DisplayMember = strDisplayColumn;

            rep.QueryPopUp += new CancelEventHandler(RepositoryItemLookupEdit_QueryPopup);

            DevExpress.XtraEditors.Controls.LookUpColumnInfo colName = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            colName.FieldName = strDisplayColumn;
            colName.Caption = strDisplayColumn.Substring(strPrimaryColumn.Length - 2);
            colName.Width = 100;

            rep.Columns.Add(colName);

            return rep;
        }

        protected virtual String GetLookupTableDisplayColumn(String strLookupTableName)
        {
            //Get GELookupTableDisplayColumn from GELookupTables
            GELookupTablesController objLookupTablesController = new GELookupTablesController();
            GELookupTablesInfo objLookupTablesInfo = objLookupTablesController.GetObjectByTableName(strLookupTableName);
            if (objLookupTablesInfo != null && !String.IsNullOrEmpty(objLookupTablesInfo.GELookupTableDisplayColumn))
                return objLookupTablesInfo.GELookupTableDisplayColumn;
            //If not exist, get default display column
            BOSDbUtil dbUtil = new BOSDbUtil();
            String strPrimaryColumn = dbUtil.GetTablePrimaryColumn(strLookupTableName);
            String prefix = strPrimaryColumn.Substring(0, strPrimaryColumn.Length - 2);
            if (dbUtil.ColumnIsExist(strLookupTableName, prefix + "Name"))
                return prefix + "Name";
            else if (dbUtil.ColumnIsExist(strLookupTableName, prefix + "No"))
                return prefix + "No";
            return String.Empty;
        }

        protected virtual void RepositoryItemLookupEdit_QueryPopup(object sender, CancelEventArgs e)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            DevExpress.XtraEditors.LookUpEdit lke = (DevExpress.XtraEditors.LookUpEdit)sender;
            String strLookupTable = lke.Properties.ValueMember.Substring(0, lke.Properties.ValueMember.Length - 2) + "s";
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
                    DataSet ds = objLookupTableController.GetAllObjects();
                    if (ds.Tables.Count > 0)
                    {
                        // Update Last Updated Date of Lookup Table
                        LookupTablesUpdatedDate[strLookupTable] = DateTime.Now;
                        ((DataSet)LookupTables[strLookupTable]).Tables.Clear();
                        ((DataSet)LookupTables[strLookupTable]).Tables.Add(ds.Tables[0].Copy());
                    }
                }
            }

            lke.Properties.DataSource = ((DataSet)LookupTables[strLookupTable]).Tables[0];
        }

        protected virtual DevExpress.XtraEditors.Repository.RepositoryItem InitColumnRepositoryFromFieldFormatGroup(String strTableName, String strColumnName)
        {
            STFieldFormatGroupsController objFieldFormatGroupsController = new STFieldFormatGroupsController();
            STFieldFormatGroupsInfo objFieldFormatGroupsInfo = objFieldFormatGroupsController.GetFieldFormatGroupByTableNameAndColumnName(strTableName, strColumnName);
            if (objFieldFormatGroupsInfo != null)
            {
                if (!String.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupRepository))
                {
                    return BOSUtil.GetRepositoryItemFromText(objFieldFormatGroupsInfo.STFieldFormatGroupRepository);
                }
            }
            return null;
        }

        protected virtual void InitColumnRepositoryFormat(DevExpress.XtraTreeList.Columns.TreeListColumn column, String strTableName, String strColumnName)
        {
            STFieldFormatGroupsController objFieldFormatGroupsController = new STFieldFormatGroupsController();
            STFieldFormatGroupsInfo objFieldFormatGroupsInfo = objFieldFormatGroupsController.GetFieldFormatGroupByTableNameAndColumnName(strTableName, strColumnName);
            if (objFieldFormatGroupsInfo != null)
            {
                DevExpress.XtraEditors.Repository.RepositoryItem rep = column.ColumnEdit;
                if (objFieldFormatGroupsInfo.STFieldFormatGroupBackColor > 0)
                {
                    rep.Appearance.BackColor = Color.FromArgb(objFieldFormatGroupsInfo.STFieldFormatGroupBackColor);
                    rep.Appearance.Options.UseBackColor = true;
                }
                if (objFieldFormatGroupsInfo.STFieldFormatGroupForeColor > 0)
                {
                    rep.Appearance.ForeColor = Color.FromArgb(objFieldFormatGroupsInfo.STFieldFormatGroupForeColor);
                    rep.Appearance.Options.UseForeColor = true;
                }

                String strDefaultFontName = "Tahoma";
                float fDefaultFontSize = 8.25F;
                if (!String.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupFontName))
                    strDefaultFontName = objFieldFormatGroupsInfo.STFieldFormatGroupFontName;
                if (objFieldFormatGroupsInfo.STFieldFormatGroupFontSize > 0)
                    fDefaultFontSize = objFieldFormatGroupsInfo.STFieldFormatGroupFontSize;
                rep.Appearance.Font = new Font(strDefaultFontName, fDefaultFontSize);
                rep.Appearance.Options.UseFont = true;

                if (BOSUtil.IsEditRepository(rep))
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repText = (DevExpress.XtraEditors.Repository.RepositoryItemTextEdit)rep;
                    if (objFieldFormatGroupsInfo.STFieldFormatGroupDecimalRound > 0)
                    {
                        repText.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        repText.Mask.EditMask = String.Format("n{0}", objFieldFormatGroupsInfo.STFieldFormatGroupDecimalRound);
                        repText.Mask.UseMaskAsDisplayFormat = true;
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupMaskType))
                        {
                            repText.Mask.MaskType = BOSUtil.GetMaskTypeFromText(objFieldFormatGroupsInfo.STFieldFormatGroupMaskType);
                            repText.Mask.EditMask = objFieldFormatGroupsInfo.STFieldFormatGroupMaskEdit;
                            repText.Mask.UseMaskAsDisplayFormat = true;
                        }
                        if (!String.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupFormatType))
                        {
                            repText.DisplayFormat.FormatType = BOSUtil.GetFormatTypeFromText(objFieldFormatGroupsInfo.STFieldFormatGroupFormatType);
                            repText.DisplayFormat.FormatString = objFieldFormatGroupsInfo.STFieldFormatGroupFormatString;
                        }
                    }
                }
            }
        }
     
        protected virtual void InitTreeListDataSource()
        {

        }

        public DevExpress.XtraTreeList.Nodes.TreeListNode GetSelectedNode()
        {
            if (this.FocusedNode != null)
                return this.FocusedNode;
            else if (BOSDisplayRoot)
                return this.Nodes.FirstNode;
            else
                return null;
        }

        public static BOSTreeListControl Instance(String strInstanceName, String strModuleName)
        {
            if (!String.IsNullOrEmpty(strInstanceName))
            {
                Assembly BOSERPAssembly = Assembly.LoadFrom(Application.StartupPath + "\\EMR.exe");
                Type treeListType = BOSERPAssembly.GetType("BOSERP.Modules." + strModuleName + "." + strInstanceName + "TreeListControl");
                if (treeListType != null)
                {
                    return (BOSTreeListControl)treeListType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
                }
                else
                {
                    treeListType = BOSERPAssembly.GetType("BOSERP." + strInstanceName + "TreeListControl");
                    if (treeListType != null)
                        return (BOSTreeListControl)treeListType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
                    else
                        return new BOSTreeListControl();
                }
            }
            else
                return new BOSTreeListControl();
        }

        /// <summary>
        /// Invalidate lookup edit columns to reflect all changes of lookup table
        /// </summary>
        public virtual void InvalidateLookupEditColumns()
        {
            foreach (DevExpress.XtraTreeList.Columns.TreeListColumn column in this.Columns)
            {
                if (column.ColumnEdit != null && column.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
                {
                    BOSDbUtil dbUtil = new BOSDbUtil();
                    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep = (DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)column.ColumnEdit;
                    String strLookupTable = dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(BOSDataSource, column.FieldName);
                    //Update lookup table if there is any changes to it
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
                                ((DataSet)LookupTables[strLookupTable]).Tables.Clear();
                                ((DataSet)LookupTables[strLookupTable]).Tables.Add(ds.Tables[0].Copy());
                            }
                        }
                    }

                    rep.DataSource = ((DataSet)LookupTables[strLookupTable]).Tables[0];
                }
            }
        }

        public override TreeListNode FindNodeByFieldValue(string fieldName, object cellValue)
        {
            return FindNodeByFieldValue(Nodes, fieldName, cellValue);
        }

        private TreeListNode FindNodeByFieldValue(TreeListNodes nodes, string fieldName, object cellValue)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            foreach (TreeListNode node in nodes)
            {
                BOSTreeListObject obj = (BOSTreeListObject)GetDataRecordByNode(node);
                object value = dbUtil.GetPropertyValue(obj, fieldName);
                if (value != null && value.Equals(cellValue))
                {
                    return node;
                }
                if (node.Nodes.Count > 0)
                {
                    TreeListNode childNode = FindNodeByFieldValue(node.Nodes, fieldName, cellValue);
                    if (childNode != null)
                    {
                        return childNode;
                    }
                }
            }
            return null;
        }
    }
}
