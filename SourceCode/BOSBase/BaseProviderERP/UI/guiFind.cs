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
    public partial class guiFind<T> : BOSERPScreen where T : BusinessObject
    {
        public enum SearchType { FindAllRecords = 0, FindAnyRecords = 1, FindExactRecords = 2 };

        #region Variables
        /// <summary>
        /// The grid control contains search result
        /// </summary>
        private BOSGridControl GridControlResult;

        /// <summary>
        /// Type of filter
        /// </summary>
        private SearchType TypeFilter;

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
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the list of selected objects
        /// </summary>
        public IList<T> SelectedObjects { get; set; }
        #endregion

        public guiFind()
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
        public guiFind(String searchTableName, IList<T> objectList, Control owner, BaseModule module)
        {
            InitializeComponent();

            this.SearchTableName = searchTableName;
            this.ObjectList = objectList;
            this.Owner = owner;
            this.Module = module;
            AllowMultipleSelect = false;
            SelectedObjects = new List<T>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchTableName">Name of the table is searched on</param>
        /// <param name="objectList">Object list is used to be a data source for search</param>        
        /// <param name="module">Module the screen belongs to</param>
        public guiFind(String searchTableName, IList<T> objectList, BaseModule module)
        {
            InitializeComponent();

            this.SearchTableName = searchTableName;
            this.ObjectList = objectList;
            this.Module = module;
            AllowMultipleSelect = false;
            SelectedObjects = new List<T>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchTableName">Name of the table is searched on</param>
        /// <param name="objectList">Object list is used to be a data source for search</param>        
        /// <param name="module">Module the screen belongs to</param>
        /// <param name="allowMultipleSelect">A value indicates whether the screen allows multiple selection</param>
        public guiFind(string searchTableName, IList<T> objectList, BaseModule module, bool allowMultipleSelect)
        {
            InitializeComponent();

            SearchTableName = searchTableName;
            ObjectList = objectList;
            Module = module;
            AllowMultipleSelect = allowMultipleSelect;
            SelectedObjects = new List<T>();
        }

        private void guiFind_Load(object sender, EventArgs e)
        {
            //Init the result grid control
            GridControlResult = BOSGridControl.Instance(SearchTableName, this.Module.Name);
            GridControlResult.Name = "fld_dgc" + SearchTableName;
            GridControlResult.Screen = this;
            GridControlResult.BOSDataSource = SearchTableName;
            GridControlResult.Width = fld_pnlMainGroup.Width - 10;
            GridControlResult.Height = fld_pnlMainGroup.Height - 50;
            GridControlResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            GridControlResult.InitializeControl();
            
            //Init the grid view of the result grid control
            GridView gridView = (GridView)GridControlResult.MainView;
            if (AllowMultipleSelect)
            {
                GridColumn column = new GridColumn();
                column.Caption = BaseLocalizedResources.Select;
                column.FieldName = "Selected";
                column.OptionsColumn.AllowEdit = true;                
                gridView.Columns.Insert(0, column);
                column.VisibleIndex = 0;

                fld_chkSelectAll.Visible = true;
                GridControlResult.Height = GridControlResult.Height - 30;
            }

            fld_pnlMainGroup.Controls.Add(GridControlResult);
            fld_txtFind.Tag = 0;
            fld_lblSearch.Tag = 0;
            ViewOptionSearch(int.Parse(fld_lblSearch.Tag.ToString()));
            SearchData(null, SearchType.FindAllRecords);
            TypeFilter = SearchType.FindAllRecords;
        }

        private void fld_lblSearch_Click(object sender, EventArgs e)
        {
            ViewOptionSearch(int.Parse(fld_lblSearch.Tag.ToString()));
        }

        private void ViewOptionSearch(int flag)
        {
            int height = fld_ragAdvancedSearch.Height + 7;
            if (flag == 0)
            {                
                fld_pnlMainGroup.Location = new Point(fld_pnlMainGroup.Location.X, fld_pnlMainGroup.Location.Y - height);
                fld_pnlMainGroup.Size = new Size(fld_pnlMainGroup.Size.Width, fld_pnlMainGroup.Size.Height + height);
                fld_lblSearch.Tag = 1;
                fld_ragAdvancedSearch.Visible = false;
            }
            else
            {                
                fld_pnlMainGroup.Location = new Point(fld_pnlMainGroup.Location.X, fld_pnlMainGroup.Location.Y + height);
                fld_pnlMainGroup.Size = new Size(fld_pnlMainGroup.Size.Width, fld_pnlMainGroup.Size.Height - height);
                fld_lblSearch.Tag = 0;
                fld_ragAdvancedSearch.Visible = true;
            }
        }

        private void fld_txtFind_Click(object sender, EventArgs e)
        {
            int tag = int.Parse(fld_txtFind.Tag.ToString());
            if (tag == 0)
                fld_txtFind.Text = String.Empty;
            fld_txtFind.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
        }

        private void fld_txtFind_Leave(object sender, EventArgs e)
        {
            int tag = int.Parse(fld_txtFind.Tag.ToString());
            if (String.IsNullOrEmpty(fld_txtFind.Text) || tag == 0)
            {
                fld_txtFind.Text = "Type/Scan any keyword here";
                fld_txtFind.Properties.Appearance.ForeColor = System.Drawing.Color.DarkGray;
                fld_txtFind.Tag = 0;
            }
            else
            {
                fld_txtFind.Tag = 1;
                fld_txtFind.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            }

        }

        private void fld_txtFind_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            int tag = int.Parse(fld_txtFind.Tag.ToString());
            if (!String.IsNullOrEmpty(fld_txtFind.Text))
            {
                fld_txtFind.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                fld_txtFind.Tag = 1;
            }
        }

        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void fld_btnFind_Click(object sender, EventArgs e)
        {
            String keyWord = String.Empty;
            if (int.Parse(fld_txtFind.Tag.ToString()) != 0)
                keyWord = fld_txtFind.Text;
            SearchData(keyWord, TypeFilter);
        }

        private void fld_ragAdvancedSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fld_ragAdvancedSearch.SelectedIndex == 0)
                TypeFilter = SearchType.FindAllRecords;
            else if (fld_ragAdvancedSearch.SelectedIndex == 1)
                TypeFilter = SearchType.FindAnyRecords;
            else
                TypeFilter = SearchType.FindExactRecords;
        }

        protected int Count(String value, String keyWord)
        {
            value = value.ToLower();
            keyWord = keyWord.ToLower();
            String[] arrElement = keyWord.Split(new char[] { ' ' });
            int rs = 0;
            foreach (String element in arrElement)
            {
                if (value.Contains(element))
                    rs++;
            }
            return rs;
        }

        /// <summary>
        /// Check existence of keyword in each row
        /// </summary>
        protected bool IsExistKeyWord(String value, String keyWord, SearchType type)
        {
            value = value.ToLower();
            keyWord = keyWord.ToLower();
            String[] arrElement;
            bool rs = false;
            if (type == SearchType.FindExactRecords)
            {
                arrElement = new String[1];
                arrElement[0] = keyWord;
            }
            else
                arrElement = keyWord.Split(new char[] { ' ' });

            keyWord.Split(new char[] { ' ' });
            int count = 0;
            foreach (String element in arrElement)
            {
                if (value.Contains(element))
                    count++;
            }
            switch (type)
            {
                case SearchType.FindAllRecords:
                case SearchType.FindExactRecords:
                    if (count == arrElement.Length)
                        rs = true;
                    else 
                        rs = false;
                    break;
                case SearchType.FindAnyRecords:
                    if (count > 0)
                        rs = true;
                    else
                        rs = false;
                    break;
            }
            return rs;
        }

        /// <summary>
        /// Search data to show on gridview
        /// </summary>
        protected void SearchData(String keyWord, SearchType type)
        { 
            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)GridControlResult.MainView;
            if (!String.IsNullOrEmpty(keyWord))
            {
                List<String> lstColVisible = new List<String>();
                BOSList<BusinessObject> lstObject = new BOSList<BusinessObject>();
                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    if (gridView.Columns[i].VisibleIndex >= 0)
                        lstColVisible.Add(gridView.Columns[i].FieldName);
                }
                BOSDbUtil dbUtil = new BOSDbUtil();
                List<T> bindingList = new List<T>();
                for (int i = 0; i < ObjectList.Count; i++)
                {
                    T obj = ObjectList[i];
                    bool isExist = false;
                    for (int j = 0; j < lstColVisible.Count; j++)
                    {
                        string value = dbUtil.GetPropertyStringValue(obj, lstColVisible[j]);
                        isExist = IsExistKeyWord(value, keyWord, type);
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
            GridView gridView = (GridView)GridControlResult.MainView;
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
                }
                else
                {
                    this.Tag = 0;
                }
            }
            else
            {
                SelectedObjects.Clear();
                foreach (T obj in ObjectList)
                {
                    if (obj.Selected)
                    {
                        SelectedObjects.Add(obj);
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void fld_chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (T obj in ObjectList)
            {
                obj.Selected = fld_chkSelectAll.Checked;
            }
        }
    }
}