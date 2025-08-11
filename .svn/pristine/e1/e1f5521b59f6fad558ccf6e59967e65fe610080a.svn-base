using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using DevExpress.XtraNavBar;


namespace BOSLib
{
    public class BOSScreen:DevExpress.XtraEditors.XtraForm
    {
        #region Windows Generated Code
        public HelpProvider ScreenHelper;
        private IContainer components;
        protected ContextMenuStrip fld_ctmAction;
        protected ToolStripMenuItem fld_mnuNew;
        protected ToolStripMenuItem fld_mnuEdit;
        protected ToolStripMenuItem fld_mnuDelete;
        protected ToolStripMenuItem fld_mnuCancel;
        protected ToolStripMenuItem fld_mnuSave;
        private ToolStripSeparator toolStripSeparator1;
        protected ToolStripMenuItem fld_mnuPrevious;
        protected ToolStripMenuItem fld_mnuNext;
        protected ContextMenuStrip fld_ctmStudio;
        protected ToolStripMenuItem fld_mnuExportScreen;
        protected ToolStripMenuItem fld_mnuImportScreen;        
        public DevExpress.XtraBars.BarManager screenToolbar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected ToolStripMenuItem fld_mnuDeleteAllControls;


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BOSScreen));
            this.ScreenHelper = new System.Windows.Forms.HelpProvider();
            this.fld_ctmAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fld_mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.fld_mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.fld_mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.fld_mnuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.fld_mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fld_mnuPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.fld_mnuNext = new System.Windows.Forms.ToolStripMenuItem();
            this.fld_ctmStudio = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fld_mnuExportScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.fld_mnuImportScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.fld_mnuDeleteAllControls = new System.Windows.Forms.ToolStripMenuItem();
            this.screenToolbar = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.fld_ctmAction.SuspendLayout();
            this.fld_ctmStudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenToolbar)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_ctmAction
            // 
            this.fld_ctmAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fld_mnuNew,
            this.fld_mnuEdit,
            this.fld_mnuDelete,
            this.fld_mnuCancel,
            this.fld_mnuSave,
            this.toolStripSeparator1,
            this.fld_mnuPrevious,
            this.fld_mnuNext});
            this.fld_ctmAction.Name = "contextMenuStrip1";
            this.fld_ctmAction.Size = new System.Drawing.Size(120, 164);
            // 
            // fld_mnuNew
            // 
            this.fld_mnuNew.Name = "fld_mnuNew";
            this.fld_mnuNew.Size = new System.Drawing.Size(119, 22);
            this.fld_mnuNew.Text = "&New";
            // 
            // fld_mnuEdit
            // 
            this.fld_mnuEdit.Name = "fld_mnuEdit";
            this.fld_mnuEdit.Size = new System.Drawing.Size(119, 22);
            this.fld_mnuEdit.Text = "&Edit";
            // 
            // fld_mnuDelete
            // 
            this.fld_mnuDelete.Name = "fld_mnuDelete";
            this.fld_mnuDelete.Size = new System.Drawing.Size(119, 22);
            this.fld_mnuDelete.Text = "&Delete";
            // 
            // fld_mnuCancel
            // 
            this.fld_mnuCancel.Name = "fld_mnuCancel";
            this.fld_mnuCancel.Size = new System.Drawing.Size(119, 22);
            this.fld_mnuCancel.Text = "&Cancel";
            // 
            // fld_mnuSave
            // 
            this.fld_mnuSave.Name = "fld_mnuSave";
            this.fld_mnuSave.Size = new System.Drawing.Size(119, 22);
            this.fld_mnuSave.Text = "&Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(116, 6);
            // 
            // fld_mnuPrevious
            // 
            this.fld_mnuPrevious.Name = "fld_mnuPrevious";
            this.fld_mnuPrevious.Size = new System.Drawing.Size(119, 22);
            this.fld_mnuPrevious.Text = "&Previous";
            // 
            // fld_mnuNext
            // 
            this.fld_mnuNext.Name = "fld_mnuNext";
            this.fld_mnuNext.Size = new System.Drawing.Size(119, 22);
            this.fld_mnuNext.Text = "&Next";
            // 
            // fld_ctmStudio
            // 
            this.fld_ctmStudio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fld_mnuExportScreen,
            this.fld_mnuImportScreen,
            this.fld_mnuDeleteAllControls});
            this.fld_ctmStudio.Name = "fld_ctmStudio";
            this.fld_ctmStudio.Size = new System.Drawing.Size(171, 70);
            // 
            // fld_mnuExportScreen
            // 
            this.fld_mnuExportScreen.Name = "fld_mnuExportScreen";
            this.fld_mnuExportScreen.Size = new System.Drawing.Size(170, 22);
            this.fld_mnuExportScreen.Text = "Export Screen";
            // 
            // fld_mnuImportScreen
            // 
            this.fld_mnuImportScreen.Name = "fld_mnuImportScreen";
            this.fld_mnuImportScreen.Size = new System.Drawing.Size(170, 22);
            this.fld_mnuImportScreen.Text = "Import Screen";
            // 
            // fld_mnuDeleteAllControls
            // 
            this.fld_mnuDeleteAllControls.Name = "fld_mnuDeleteAllControls";
            this.fld_mnuDeleteAllControls.Size = new System.Drawing.Size(170, 22);
            this.fld_mnuDeleteAllControls.Text = "Delete all Controls";
            // 
            // screenToolbar
            // 
            this.screenToolbar.DockControls.Add(this.barDockControlTop);
            this.screenToolbar.DockControls.Add(this.barDockControlBottom);
            this.screenToolbar.DockControls.Add(this.barDockControlLeft);
            this.screenToolbar.DockControls.Add(this.barDockControlRight);
            this.screenToolbar.Form = this;
            this.screenToolbar.MaxItemId = 0;
            // 
            // BOSScreen
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BOSScreen";
            this.fld_ctmAction.ResumeLayout(false);
            this.fld_ctmStudio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.screenToolbar)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constants of Field Groups
        public const String cstFieldGroupNonCreatable = "NonCreatable";
        public const String cstFieldGroupNonEditable = "NonEditable";
        public const String cstFieldGroupAction = "Action";
        public const String cstFieldGroupNonAction = "NonAction";
        public const String cstFieldGroupSearch = "Search";        
        public const String cstFieldGroupCustom = "Custom";        
        #endregion

        #region Constants of Property Names
        public const String cstDataSourcePropertyName = "BOSDataSource";
        public const String cstDataMemberPropertyName = "BOSDataMember";
        public const String cstFieldGroupPropertyName = "BOSFieldGroup";
        public const String cstCommentPropertyName = "BOSComment";
        public const String cstBindingPropertyName = "BOSPropertyName";
        public const String cstErrorPropertyName = "BOSErrorPropertyName";
        public const String cstPrivilegePropertyName = "BOSPrivilege";
        public const String cstDescriptionPropertyName = "BOSDescription";
        #endregion

        #region Constant for Control type
        public const String DataControl = "DC";
        public const String SearchControl = "SC";
        public const String SearchResultControl = "SR";
        public const String SearchInfo = "SI";
        #endregion

        #region Constant for Grid Control Type
        public const String SearchResultGrid = "Search Results";
        public const String InfoGrid = "Info";
        public const String AdvancedGrid = "Advanced";
        #endregion

        #region Constant for Format Action
        public const String FormatNone = "None";
        public const String FormatAlignLeft = "Align Left";
        public const String FormatAlignRight = "Align Right";
        public const String FormatAlignBottom = "Align Bottom";
        public const String FormatAlignTop = "Align Top";
        public const String FormatSameWidth = "Same Width";
        public const String FormatSameHeight = "Same Height";
        public const String FormatSameSize = "Same Size";
        public const String FormatSameColor = "Same Color";
        public const String FormatHorizontalSpacing = "Hori Spacing";
        public const String FormatVerticalSpacing = "Verti Spacing";
        public const String FormatCenterVertical = "Center Verti";
        public const String FormatCenterHorizontal = "Center Hori";
        public const String FormatTabIndex = "Tab Index";
        public const String FormatAddX = "Add X";
        public const String FormatAddY = "Add Y";
        public const String FormatLabel = "Label";
        #endregion

        #region Constants of Screen Display
        public const int cstAutoScrollMinSizeWidth = 1280;
        public const int cstAutoScrollMinSizeHeight = 720;
        #endregion

        #region Variables
        protected int _screenID;
        protected String _screenNumber;
        protected BaseModule _module;
        protected Control _activeSearchControl;
        #endregion

        #region Public Properties
        [Category("Custom")]
        [Browsable(false)]
        public int ScreenID
        {
            get
            {
                return _screenID;
            }
            set
            {
                _screenID = value;
            }
        }

        [Category("Custom")]
        public BaseModule Module
        {
            get { return _module; }
            set { _module = value; }
        }

        [Browsable(false)]
        public Control ActiveSearchControl
        {
            get { return _activeSearchControl; }
            set { _activeSearchControl = value; }
        }

        [Category("Custom")]
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

        [Category("Custom")]
        public String ScreenNumber
        {
            get
            {
                return _screenNumber;
            }
            set
            {
                _screenNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets field list of the screen
        /// </summary>
        public SortedList<string, STFieldsInfo> Fields { get; set; }

        /// <summary>
        /// Gets or sets permission list of all fields of the screen
        /// </summary>
        public SortedList<string, STFieldPermissionsInfo> FieldPermissions { get; set; }   
        #endregion

        public BOSScreen()
        {
            InitializeComponent();
            ControlBox = false;
        }              

        #region Functions for checking type of screen
        public bool IsDataMainScreen()
        {
            bool isDataMainScreen = false;
            if (this.ScreenNumber.StartsWith("DM"))
                isDataMainScreen = true;
            return isDataMainScreen;
        }
        public bool IsSearchQuickScreen()
        {
            bool ok = false;
            if (this.ScreenNumber.StartsWith("SQ"))
                ok = true;
            return ok;
        }
        public bool IsSearchMainScreen()
        {
            bool isSearchMainScreen = false;
            if (this.ScreenNumber.StartsWith("SM"))
                isSearchMainScreen = true;
            return isSearchMainScreen;
        }

        public bool IsSearchResultsScreen()
        {
            bool isSearchResultsScreen = false;
            if (this.ScreenNumber.StartsWith("SR"))
                isSearchResultsScreen = true;
            return isSearchResultsScreen;
        }

        public bool IsDataSubScreen()
        {
            bool isDataSubScreen = false;
            if (this.ScreenNumber.StartsWith("DS"))
                isDataSubScreen = true;
            return isDataSubScreen;
        }
        #endregion

        #region Functions to Init Screen

        public virtual BOSScreen Recreate()
        {
            BOSScreen scr = new BOSScreen();
            scr.Name = this.Name;
            scr.ScreenNumber = this.ScreenNumber;
            scr.Module = this.Module;
            scr.InitializeScreen();
            return scr;
        }

        public virtual void InitializeScreen()
        {                     
            
        }

        public virtual void InitializeControls()
        {           
            
        }

        public virtual Control InitializeControl(STFieldsInfo objSTFieldsInfo, int iLanguageID)
        {
            Control ctrl = new Control();          
            return ctrl;
        }

        /// <summary>
        /// Bind the control to a property of an business object
        /// </summary>
        /// <param name="ctrl">Control needs to be binded</param>
        public virtual void BindingDataControl(Control ctrl)
        {

        }       
        #endregion                             
    }
}
