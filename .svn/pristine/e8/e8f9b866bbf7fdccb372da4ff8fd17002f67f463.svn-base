using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSLib;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;

namespace BOSERP
{
    public partial class guiDepositList<T> : BOSERPScreen where T : BusinessObject
    {
        #region Variables
        /// <summary>
        /// The grid control contains search result
        /// </summary>
        private BOSGridControl GridControlResult;

        /// <summary>
        /// The control causes this screen to show up
        /// </summary>
        private Control Owner;

        /// <summary>
        /// The name of table is searched on
        /// </summary>
        private String SearchTableName;

        /// <summary>
        /// List of objects is used to bind to the search grid control        
        /// </summary>
        private IList<T> ObjectList;

        /// <summary>
        /// A value indicates whether the screen allows multiple selection
        /// </summary>
        private bool AllowMultipleSelect;

        /// <summary>
        /// A value indicates whether the screen shows the object list when it's shown
        /// </summary>
        private bool ShowData;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the list of selected objects
        /// </summary>
        public IList<T> SelectedObjects { get; set; }

        /// <summary>
        /// Gets or sets the name of the grid control that its component
        /// will be instantiated and used in this form
        /// </summary>
        public string GridControlName {get;set;}
        #endregion

        public guiDepositList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchTableName">Name of the table is searched on</param>
        /// <param name="objectList">Object list is used to be a data source for search</param>
        /// <param name="owner">Control causes the screen to show up</param>
        /// <param name="module">Module the screen belongs to</param>
        public guiDepositList(String searchTableName, IList<T> objectList, Control owner, BaseModule module)
        {
            InitializeComponent();

            this.SearchTableName = searchTableName;
            this.ObjectList = objectList;
            this.Owner = owner;
            this.Module = module;
            AllowMultipleSelect = false;
            ShowData = true;
            SelectedObjects = new List<T>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchTableName">Name of the table is searched on</param>
        /// <param name="objectList">Object list is used to be a data source for search</param>        
        /// <param name="module">Module the screen belongs to</param>
        public guiDepositList(String searchTableName, IList<T> objectList, BaseModule module)
        {
            InitializeComponent();

            this.SearchTableName = searchTableName;
            this.ObjectList = objectList;
            this.Module = module;
            AllowMultipleSelect = false;
            ShowData = true;
            SelectedObjects = new List<T>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchTableName">Name of the table is searched on</param>
        /// <param name="objectList">Object list is used to be a data source for search</param>        
        /// <param name="module">Module the screen belongs to</param>
        /// <param name="allowMultipleSelect">A value indicates whether the screen allows multiple selection</param>
        public guiDepositList(string searchTableName, IList<T> objectList, BaseModule module, bool allowMultipleSelect)
        {
            InitializeComponent();

            SearchTableName = searchTableName;
            ObjectList = objectList;
            Module = module;
            AllowMultipleSelect = allowMultipleSelect;
            ShowData = true;
            SelectedObjects = new List<T>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchTableName">Name of the table is searched on</param>
        /// <param name="objectList">Object list is used to be a data source for search</param>        
        /// <param name="module">Module the screen belongs to</param>
        /// <param name="allowMultipleSelect">A value indicates whether the screen allows multiple selection</param>
        /// <param name="showData">A value indicates whether the screen shows the object list when it's shown</param>
        public guiDepositList(string searchTableName, IList<T> objectList, BaseModule module, bool allowMultipleSelect, bool showData)
        {
            InitializeComponent();

            SearchTableName = searchTableName;
            ObjectList = objectList;
            Module = module;
            AllowMultipleSelect = allowMultipleSelect;
            ShowData = showData;
            SelectedObjects = new List<T>();
        }

        private void guiDepositList_Load(object sender, EventArgs e)
        {
            //Init the result grid control
            string gridName = GridControlName;
            if (string.IsNullOrEmpty(gridName))
            {
                gridName = SearchTableName;
            }
            GridControlResult = BOSGridControl.Instance(gridName, this.Module.Name);
            GridControlResult.Name = "fld_dgc" + SearchTableName;
            GridControlResult.Screen = this;
            GridControlResult.BOSDataSource = SearchTableName;
            GridControlResult.Width = fld_pnlMainGroup.Width - 10;
            GridControlResult.Height = fld_pnlMainGroup.Height - 50;
            GridControlResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            GridControlResult.TabIndex = 0;
            GridControlResult.InitializeControl();            
            
            //Init the grid view of the result grid control
            GridView gridView = (GridView)GridControlResult.MainView;
            GridColumn column = new GridColumn();
            if (AllowMultipleSelect)
            {                
                column.Caption = BaseLocalizedResources.Select;
                column.FieldName = "Selected";
                column.OptionsColumn.AllowEdit = true;                
                gridView.Columns.Insert(0, column);
                column.VisibleIndex = 0;

                //fld_chkSelectAll.Visible = true;
                GridControlResult.Height = GridControlResult.Height - 30;
            }
            gridView.DoubleClick += new EventHandler(GridView_DoubleClick);

            fld_pnlMainGroup.Controls.Add(GridControlResult);
            //fld_txtFind.Tag = 0;
            if (ShowData)
            {
                SearchData(null);
            }
        }  

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            ChooseObjects();
        }

        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Check existence of keyword in each row
        /// </summary>
        protected bool IsExistKeyWord(String value, String keyWord)
        {
            value = value.ToLower();
            keyWord = keyWord.ToLower();
            String[] arrElement = keyWord.Split(new char[] { ' ' });
            bool isExist = false;
            foreach (String element in arrElement)
            {
                if (value.Contains(element))
                {
                    isExist = true;
                }
            }

            if (!isExist)
            {
                value = BOSUtil.ConvertUnicodeStringToUnSign(value);
                foreach (String element in arrElement)
                {
                    if (value.Contains(element))
                    {
                        isExist = true;
                    }
                }
            }
            return isExist;
        }

        /// <summary>
        /// Search data to show on gridview
        /// </summary>
        protected void SearchData(String keyWord)
        { 
            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)GridControlResult.MainView;
            if (!String.IsNullOrEmpty(keyWord))
            {
                List<GridColumn> lstColVisible = new List<GridColumn>();
                BOSList<BusinessObject> lstObject = new BOSList<BusinessObject>();
                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    if (gridView.Columns[i].VisibleIndex >= 0)
                        lstColVisible.Add(gridView.Columns[i]);
                }
                BOSDbUtil dbUtil = new BOSDbUtil();
                List<T> bindingList = new List<T>();
                
                //Bind object list to grid for searching
                GridControlResult.DataSource = ObjectList;
                GridControlResult.RefreshDataSource();

                for (int i = 0; i < ObjectList.Count; i++)
                {
                    T obj = ObjectList[i];
                    bool isExist = false;
                    foreach (GridColumn column in lstColVisible)
                    {
                        int rowHandle = gridView.GetRowHandle(i);
                        string value = gridView.GetRowCellDisplayText(rowHandle, column);
                        isExist = IsExistKeyWord(value, keyWord);
                        if (isExist)
                            break;
                    }
                    if (isExist)
                    {
                        bindingList.Add(obj);
                    }
                }
                GridControlResult.DataSource = bindingList;
                GridControlResult.RefreshDataSource();
            }
            else
            {
                GridControlResult.DataSource = ObjectList;
                GridControlResult.RefreshDataSource();
            }
        }

        private void fld_btnSelect_Click(object sender, EventArgs e)
        {
            ChooseObjects();           
        }

        /// <summary>
        /// Called when user selected objects. The formed will be closed
        /// and let user continue
        /// </summary>
        private void ChooseObjects()
        {            
            GridView gridView = (GridView)GridControlResult.MainView;
            bool isSelected = false;
            if (!AllowMultipleSelect)
            {
                if (gridView.FocusedRowHandle >= 0)
                {
                    T obj = (T)gridView.GetRow(gridView.FocusedRowHandle);
                    BOSDbUtil dbUtil = new BOSDbUtil();
                    String primaryColumn = dbUtil.GetTablePrimaryColumn(SearchTableName);
                    int objectID = dbUtil.GetPropertyIntValue(obj, primaryColumn);
                    if (Owner != null)
                        dbUtil.SetPropertyValue(Owner, "EditValue", objectID);
                    else
                        this.Tag = objectID;
                    isSelected = true;
                }
            }
            else
            {
                if (gridView.FocusedRowHandle >= 0)
                {
                    T obj = (T)gridView.GetRow(gridView.FocusedRowHandle);
                    obj.Selected = true;
                }

                SelectedObjects.Clear();
                foreach (T obj in ObjectList)
                {
                    if (obj.Selected)
                    {
                        SelectedObjects.Add(obj);
                        isSelected = true;
                    }
                }
            }

            bool isValid = ((BaseModuleERP)Module).CheckSelectedSearchObjects(SearchTableName, SelectedObjects);
            if (!isValid)
            {
                return;
            }

            if (!isSelected)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}