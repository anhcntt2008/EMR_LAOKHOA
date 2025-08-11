using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.IO;
using System.Configuration;
using DevExpress.XtraNavBar;
using BOSLib;
using Localization;

namespace BOSERP
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    public class GUIMain : DevExpress.XtraEditors.XtraForm
    {
        private int _treeListHotTrackID = -1;

        private System.ComponentModel.IContainer components;
		private DevExpress.XtraBars.BarManager fld_brmToolbarManager;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public ToolStrip fld_tsOpenedModules;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.Docking.DockManager dockSectionManager;
        private NavBarControl navbarSectionManager;
        private DevExpress.XtraBars.Docking.DockPanel dockSectionPanel;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraTreeList.TreeList treelistManager;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarManager fld_barManager;
        private DevExpress.XtraBars.Bar fld_barToolbar;
        private DevExpress.XtraBars.Bar fld_barMenu;
        private DevExpress.XtraBars.Bar barStatus;
        public DevExpress.XtraBars.BarStaticItem userItem;
        public DevExpress.XtraBars.BarStaticItem moduleItem;
        public DevExpress.XtraBars.BarStaticItem nameItem;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        public DevExpress.XtraBars.BarStaticItem numItem;
        public DevExpress.XtraBars.BarStaticItem capItem;
        public DevExpress.XtraBars.BarStaticItem scrollItem;
        private MenuStrip menuStrip1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem fld_barbtnMenuImport;
        private DevExpress.XtraBars.BarButtonItem fld_barbtnMenuExport;
        private DevExpress.XtraBars.BarButtonItem fld_barbtnMenuExit;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarCheckItem fld_barchkMenuToolbar;
        private DevExpress.XtraBars.BarCheckItem fld_barchkMenuOpenModuleToolStrip;
        private DevExpress.XtraBars.BarCheckItem fld_barchkMenuStatusBar;
        private DevExpress.XtraBars.BarButtonItem fld_barbtnMenuCustomizeToolbar;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraBars.BarCheckItem barCheckItem4;
        private DevExpress.XtraBars.BarCheckItem barCheckItem5;
        private DevExpress.XtraBars.BarCheckItem barCheckItem6;
        private DevExpress.XtraBars.BarCheckItem barCheckItem7;
        private DevExpress.XtraBars.BarSubItem barSubItem5;
        private DevExpress.XtraBars.BarCheckItem barCheckItem8;
        private DevExpress.XtraBars.BarCheckItem barCheckItem9;
        private DevExpress.XtraBars.BarCheckItem barCheckItem10;
        private DevExpress.XtraBars.BarCheckItem barCheckItem11;
        private DevExpress.XtraBars.BarCheckItem barCheckItem12;
        private DevExpress.XtraBars.BarCheckItem barCheckItem13;
        private DevExpress.XtraBars.BarCheckItem barCheckItem14;
        private DevExpress.XtraBars.BarSubItem barSubItem6;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        public DevExpress.XtraBars.BarStaticItem dateItem;

        public GUIMain()
        {
            //
            // Required for Windows Form Designer support
            //			            
            BOSApp.MainScreen = this;
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //           

            this.Text = ConfigurationManager.AppSettings["CompanyName"];
            BOSApp.BOSERPAssembly = Assembly.LoadFrom(Application.StartupPath + "\\BOSERP.exe");
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUIMain));
            this.fld_brmToolbarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockSectionManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockSectionPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.treelistManager = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.navbarSectionManager = new DevExpress.XtraNavBar.NavBarControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.fld_tsOpenedModules = new System.Windows.Forms.ToolStrip();
            this.fld_barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.fld_barToolbar = new DevExpress.XtraBars.Bar();
            this.fld_barMenu = new DevExpress.XtraBars.Bar();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.fld_barbtnMenuImport = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnMenuExport = new DevExpress.XtraBars.BarButtonItem();
            this.fld_barbtnMenuExit = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.fld_barchkMenuToolbar = new DevExpress.XtraBars.BarCheckItem();
            this.fld_barchkMenuOpenModuleToolStrip = new DevExpress.XtraBars.BarCheckItem();
            this.fld_barchkMenuStatusBar = new DevExpress.XtraBars.BarCheckItem();
            this.fld_barbtnMenuCustomizeToolbar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.barCheckItem4 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem5 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem6 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem7 = new DevExpress.XtraBars.BarCheckItem();
            this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.barCheckItem8 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem9 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem10 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem11 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem12 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem13 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem14 = new DevExpress.XtraBars.BarCheckItem();
            this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.userItem = new DevExpress.XtraBars.BarStaticItem();
            this.moduleItem = new DevExpress.XtraBars.BarStaticItem();
            this.nameItem = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.numItem = new DevExpress.XtraBars.BarStaticItem();
            this.capItem = new DevExpress.XtraBars.BarStaticItem();
            this.scrollItem = new DevExpress.XtraBars.BarStaticItem();
            this.dateItem = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.fld_brmToolbarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockSectionManager)).BeginInit();
            this.dockSectionPanel.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treelistManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navbarSectionManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_brmToolbarManager
            // 
            this.fld_brmToolbarManager.AllowCustomization = false;
            this.fld_brmToolbarManager.AllowQuickCustomization = false;
            this.fld_brmToolbarManager.Controller = this.barAndDockingController1;
            this.fld_brmToolbarManager.DockControls.Add(this.barDockControlTop);
            this.fld_brmToolbarManager.DockControls.Add(this.barDockControlBottom);
            this.fld_brmToolbarManager.DockControls.Add(this.barDockControlLeft);
            this.fld_brmToolbarManager.DockControls.Add(this.barDockControlRight);
            this.fld_brmToolbarManager.DockManager = this.dockSectionManager;
            this.fld_brmToolbarManager.Form = this;
            this.fld_brmToolbarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barEditItem1});
            this.fld_brmToolbarManager.MaxItemId = 76;
            this.fld_brmToolbarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMarqueeProgressBar1,
            this.repositoryItemProgressBar1});
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // dockSectionManager
            // 
            this.dockSectionManager.Controller = this.barAndDockingController1;
            this.dockSectionManager.Form = this;
            this.dockSectionManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockSectionPanel});
            this.dockSectionManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar"});
            // 
            // dockSectionPanel
            // 
            this.dockSectionPanel.Controls.Add(this.dockPanel1_Container);
            this.dockSectionPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockSectionPanel.ID = new System.Guid("410a208d-7c05-4965-a79d-b10d980fa0df");
            this.dockSectionPanel.Location = new System.Drawing.Point(773, 49);
            this.dockSectionPanel.Name = "dockSectionPanel";
            this.dockSectionPanel.Options.ShowCloseButton = false;
            this.dockSectionPanel.OriginalSize = new System.Drawing.Size(243, 200);
            this.dockSectionPanel.Size = new System.Drawing.Size(243, 664);
            this.dockSectionPanel.TabText = "Module";
            this.dockSectionPanel.Text = "Module";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.treelistManager);
            this.dockPanel1_Container.Controls.Add(this.navbarSectionManager);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(237, 636);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // treelistManager
            // 
            this.treelistManager.BestFitVisibleOnly = true;
            this.treelistManager.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treelistManager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treelistManager.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treelistManager.Location = new System.Drawing.Point(-3, 17);
            this.treelistManager.Name = "treelistManager";
            this.treelistManager.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treelistManager.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treelistManager.OptionsView.ShowColumns = false;
            this.treelistManager.OptionsView.ShowIndicator = false;
            this.treelistManager.Size = new System.Drawing.Size(237, 164);
            this.treelistManager.TabIndex = 20;
            this.treelistManager.TreeLevelWidth = 12;
            this.treelistManager.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            this.treelistManager.Visible = false;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Modules";
            this.treeListColumn1.FieldName = "Modules";
            this.treeListColumn1.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.FixedWidth = true;
            this.treeListColumn1.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // navbarSectionManager
            // 
            this.navbarSectionManager.ActiveGroup = null;
            this.navbarSectionManager.AllowSelectedLink = true;
            this.navbarSectionManager.ContentButtonHint = null;
            this.navbarSectionManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navbarSectionManager.EachGroupHasSelectedLink = true;
            this.navbarSectionManager.Location = new System.Drawing.Point(0, 0);
            this.navbarSectionManager.Name = "navbarSectionManager";
            this.navbarSectionManager.OptionsNavPane.ExpandedWidth = 146;
            this.navbarSectionManager.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navbarSectionManager.Size = new System.Drawing.Size(237, 636);
            this.navbarSectionManager.StoreDefaultPaintStyleName = true;
            this.navbarSectionManager.TabIndex = 18;
            this.navbarSectionManager.Text = "Section Explorer";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemProgressBar1;
            this.barEditItem1.Id = 75;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            this.repositoryItemMarqueeProgressBar1.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.PingPong;
            this.repositoryItemMarqueeProgressBar1.ShowTitle = true;
            // 
            // fld_tsOpenedModules
            // 
            this.fld_tsOpenedModules.AllowDrop = true;
            this.fld_tsOpenedModules.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fld_tsOpenedModules.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.fld_tsOpenedModules.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.fld_tsOpenedModules.Location = new System.Drawing.Point(0, 688);
            this.fld_tsOpenedModules.Name = "fld_tsOpenedModules";
            this.fld_tsOpenedModules.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.fld_tsOpenedModules.Size = new System.Drawing.Size(1016, 25);
            this.fld_tsOpenedModules.TabIndex = 14;
            this.fld_tsOpenedModules.Visible = false;
            // 
            // fld_barManager
            // 
            this.fld_barManager.AllowCustomization = false;
            this.fld_barManager.AllowQuickCustomization = false;
            this.fld_barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.fld_barToolbar,
            this.fld_barMenu,
            this.barStatus});
            this.fld_barManager.Controller = this.barAndDockingController1;
            this.fld_barManager.DockControls.Add(this.barDockControl1);
            this.fld_barManager.DockControls.Add(this.barDockControl2);
            this.fld_barManager.DockControls.Add(this.barDockControl3);
            this.fld_barManager.DockControls.Add(this.barDockControl4);
            this.fld_barManager.DockManager = this.dockSectionManager;
            this.fld_barManager.Form = this;
            this.fld_barManager.Images = this.imageCollection1;
            this.fld_barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.userItem,
            this.moduleItem,
            this.nameItem,
            this.barStaticItem1,
            this.numItem,
            this.capItem,
            this.scrollItem,
            this.dateItem,
            this.barSubItem2,
            this.fld_barbtnMenuImport,
            this.fld_barbtnMenuExport,
            this.fld_barbtnMenuExit,
            this.barSubItem3,
            this.fld_barchkMenuToolbar,
            this.fld_barchkMenuOpenModuleToolStrip,
            this.fld_barchkMenuStatusBar,
            this.fld_barbtnMenuCustomizeToolbar,
            this.barSubItem4,
            this.barCheckItem4,
            this.barCheckItem5,
            this.barCheckItem6,
            this.barCheckItem7,
            this.barSubItem5,
            this.barCheckItem8,
            this.barCheckItem9,
            this.barCheckItem10,
            this.barCheckItem11,
            this.barCheckItem12,
            this.barCheckItem13,
            this.barCheckItem14,
            this.barSubItem6});
            this.fld_barManager.LargeImages = this.imageCollection1;
            this.fld_barManager.MainMenu = this.fld_barMenu;
            this.fld_barManager.MaxItemId = 50;
            this.fld_barManager.StatusBar = this.barStatus;
            // 
            // fld_barToolbar
            // 
            this.fld_barToolbar.BarName = "Tool bar";
            this.fld_barToolbar.DockCol = 0;
            this.fld_barToolbar.DockRow = 1;
            this.fld_barToolbar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.fld_barToolbar.FloatLocation = new System.Drawing.Point(315, 191);
            this.fld_barToolbar.FloatSize = new System.Drawing.Size(46, 24);
            this.fld_barToolbar.Text = "Tool bar";
            // 
            // fld_barMenu
            // 
            this.fld_barMenu.BarName = "Main menu";
            this.fld_barMenu.DockCol = 0;
            this.fld_barMenu.DockRow = 0;
            this.fld_barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.fld_barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem6)});
            this.fld_barMenu.OptionsBar.MultiLine = true;
            this.fld_barMenu.OptionsBar.UseWholeRow = true;
            this.fld_barMenu.Text = "Main menu";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "File";
            this.barSubItem2.Id = 10;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnMenuImport),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnMenuExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnMenuExit, true)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // fld_barbtnMenuImport
            // 
            this.fld_barbtnMenuImport.Caption = "Import";
            this.fld_barbtnMenuImport.Id = 12;
            this.fld_barbtnMenuImport.Name = "fld_barbtnMenuImport";
            this.fld_barbtnMenuImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.fld_barbtnMenuImport_ItemClick);
            // 
            // fld_barbtnMenuExport
            // 
            this.fld_barbtnMenuExport.Caption = "Export";
            this.fld_barbtnMenuExport.Id = 13;
            this.fld_barbtnMenuExport.Name = "fld_barbtnMenuExport";
            this.fld_barbtnMenuExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.fld_barbtnMenuExport_ItemClick);
            // 
            // fld_barbtnMenuExit
            // 
            this.fld_barbtnMenuExit.Caption = "Exit";
            this.fld_barbtnMenuExit.Id = 14;
            this.fld_barbtnMenuExit.Name = "fld_barbtnMenuExit";
            this.fld_barbtnMenuExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.fld_barbtnMenuExit_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "View";
            this.barSubItem3.Id = 15;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barchkMenuToolbar),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barchkMenuOpenModuleToolStrip),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barchkMenuStatusBar),
            new DevExpress.XtraBars.LinkPersistInfo(this.fld_barbtnMenuCustomizeToolbar, true)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // fld_barchkMenuToolbar
            // 
            this.fld_barchkMenuToolbar.Caption = "Toolbar";
            this.fld_barchkMenuToolbar.Checked = true;
            this.fld_barchkMenuToolbar.Id = 17;
            this.fld_barchkMenuToolbar.Name = "fld_barchkMenuToolbar";
            this.fld_barchkMenuToolbar.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.fld_barchkMenuToolbar_CheckedChanged);
            // 
            // fld_barchkMenuOpenModuleToolStrip
            // 
            this.fld_barchkMenuOpenModuleToolStrip.Caption = "Open Module ToolStrip";
            this.fld_barchkMenuOpenModuleToolStrip.Id = 18;
            this.fld_barchkMenuOpenModuleToolStrip.Name = "fld_barchkMenuOpenModuleToolStrip";
            this.fld_barchkMenuOpenModuleToolStrip.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.fld_barchkMenuOpenModuleToolStrip_CheckedChanged);
            // 
            // fld_barchkMenuStatusBar
            // 
            this.fld_barchkMenuStatusBar.Caption = "Status Bar";
            this.fld_barchkMenuStatusBar.Id = 19;
            this.fld_barchkMenuStatusBar.Name = "fld_barchkMenuStatusBar";
            this.fld_barchkMenuStatusBar.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.fld_barchkMenuStatusBar_CheckedChanged);
            // 
            // fld_barbtnMenuCustomizeToolbar
            // 
            this.fld_barbtnMenuCustomizeToolbar.Caption = "Customize Toolbar";
            this.fld_barbtnMenuCustomizeToolbar.Id = 20;
            this.fld_barbtnMenuCustomizeToolbar.Name = "fld_barbtnMenuCustomizeToolbar";
            this.fld_barbtnMenuCustomizeToolbar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.fld_barbtnMenuCustomizeToolbar_ItemClick);
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "Look And Feel";
            this.barSubItem4.Id = 21;
            this.barSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem6),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem7),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem5)});
            this.barSubItem4.Name = "barSubItem4";
            // 
            // barCheckItem4
            // 
            this.barCheckItem4.Caption = "Office 2003";
            this.barCheckItem4.GroupIndex = 1;
            this.barCheckItem4.Id = 22;
            this.barCheckItem4.Name = "barCheckItem4";
            this.barCheckItem4.Tag = "Office2003";
            this.barCheckItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LookAndFeelBar_ItemClick);
            // 
            // barCheckItem5
            // 
            this.barCheckItem5.Caption = "Flat";
            this.barCheckItem5.GroupIndex = 1;
            this.barCheckItem5.Id = 23;
            this.barCheckItem5.Name = "barCheckItem5";
            this.barCheckItem5.Tag = "Flat";
            this.barCheckItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LookAndFeelBar_ItemClick);
            // 
            // barCheckItem6
            // 
            this.barCheckItem6.Caption = "Ultra Flat";
            this.barCheckItem6.GroupIndex = 1;
            this.barCheckItem6.Id = 24;
            this.barCheckItem6.Name = "barCheckItem6";
            this.barCheckItem6.Tag = "UltraFlat";
            this.barCheckItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LookAndFeelBar_ItemClick);
            // 
            // barCheckItem7
            // 
            this.barCheckItem7.Caption = "Style 3D";
            this.barCheckItem7.GroupIndex = 1;
            this.barCheckItem7.Id = 25;
            this.barCheckItem7.Name = "barCheckItem7";
            this.barCheckItem7.Tag = "Style3D";
            this.barCheckItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LookAndFeelBar_ItemClick);
            // 
            // barSubItem5
            // 
            this.barSubItem5.Caption = "Skin";
            this.barSubItem5.Id = 26;
            this.barSubItem5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem8),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem9),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem10),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem11),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem12),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem13),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem14)});
            this.barSubItem5.Name = "barSubItem5";
            // 
            // barCheckItem8
            // 
            this.barCheckItem8.Caption = "Caramel";
            this.barCheckItem8.GroupIndex = 1;
            this.barCheckItem8.Id = 27;
            this.barCheckItem8.Name = "barCheckItem8";
            this.barCheckItem8.Tag = "Caramel";
            this.barCheckItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LookAndFeelSkin_ItemClick);
            // 
            // barCheckItem9
            // 
            this.barCheckItem9.Caption = "Money Twins";
            this.barCheckItem9.GroupIndex = 1;
            this.barCheckItem9.Id = 28;
            this.barCheckItem9.Name = "barCheckItem9";
            this.barCheckItem9.Tag = "Money Twins";
            this.barCheckItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LookAndFeelSkin_ItemClick);
            // 
            // barCheckItem10
            // 
            this.barCheckItem10.Caption = "Lilian";
            this.barCheckItem10.GroupIndex = 1;
            this.barCheckItem10.Id = 29;
            this.barCheckItem10.Name = "barCheckItem10";
            this.barCheckItem10.Tag = "Lilian";
            this.barCheckItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LookAndFeelSkin_ItemClick);
            // 
            // barCheckItem11
            // 
            this.barCheckItem11.Caption = "The Asphalt World";
            this.barCheckItem11.GroupIndex = 1;
            this.barCheckItem11.Id = 30;
            this.barCheckItem11.Name = "barCheckItem11";
            this.barCheckItem11.Tag = "The Asphalt World";
            this.barCheckItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LookAndFeelSkin_ItemClick);
            // 
            // barCheckItem12
            // 
            this.barCheckItem12.Caption = "iMaginary";
            this.barCheckItem12.GroupIndex = 1;
            this.barCheckItem12.Id = 31;
            this.barCheckItem12.Name = "barCheckItem12";
            this.barCheckItem12.Tag = "iMaginary";
            this.barCheckItem12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LookAndFeelSkin_ItemClick);
            // 
            // barCheckItem13
            // 
            this.barCheckItem13.Caption = "Black";
            this.barCheckItem13.GroupIndex = 1;
            this.barCheckItem13.Id = 32;
            this.barCheckItem13.Name = "barCheckItem13";
            this.barCheckItem13.Tag = "Black";
            this.barCheckItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LookAndFeelSkin_ItemClick);
            // 
            // barCheckItem14
            // 
            this.barCheckItem14.Caption = "Blue";
            this.barCheckItem14.GroupIndex = 1;
            this.barCheckItem14.Id = 33;
            this.barCheckItem14.Name = "barCheckItem14";
            this.barCheckItem14.Tag = "Blue";
            this.barCheckItem14.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.LookAndFeelSkin_ItemClick);
            // 
            // barSubItem6
            // 
            this.barSubItem6.Caption = "Help";
            this.barSubItem6.Id = 34;
            this.barSubItem6.Name = "barSubItem6";
            // 
            // barStatus
            // 
            this.barStatus.BarName = "Status bar";
            this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barStatus.DockCol = 0;
            this.barStatus.DockRow = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.userItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.moduleItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.nameItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.numItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.capItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.scrollItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.dateItem)});
            this.barStatus.OptionsBar.AllowQuickCustomization = false;
            this.barStatus.OptionsBar.DrawDragBorder = false;
            this.barStatus.OptionsBar.UseWholeRow = true;
            this.barStatus.Text = "Status bar";
            this.barStatus.Visible = false;
            // 
            // userItem
            // 
            this.userItem.Caption = "                                       ";
            this.userItem.Id = 0;
            this.userItem.Name = "userItem";
            this.userItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // moduleItem
            // 
            this.moduleItem.Caption = "                                                  ";
            this.moduleItem.Id = 1;
            this.moduleItem.Name = "moduleItem";
            this.moduleItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // nameItem
            // 
            this.nameItem.Caption = "                                                              ";
            this.nameItem.Id = 2;
            this.nameItem.Name = "nameItem";
            this.nameItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "                                                                   ";
            this.barStaticItem1.Id = 3;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // numItem
            // 
            this.numItem.Caption = "NUM";
            this.numItem.Id = 4;
            this.numItem.Name = "numItem";
            this.numItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // capItem
            // 
            this.capItem.Caption = "CAPS";
            this.capItem.Id = 5;
            this.capItem.Name = "capItem";
            this.capItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // scrollItem
            // 
            this.scrollItem.Caption = "SCROLL";
            this.scrollItem.Id = 6;
            this.scrollItem.Name = "scrollItem";
            this.scrollItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // dateItem
            // 
            this.dateItem.Caption = "                               ";
            this.dateItem.Id = 8;
            this.dateItem.Name = "dateItem";
            this.dateItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Export.ico");
            this.imageCollection1.Images.SetKeyName(1, "FromSaleReceipt.png");
            this.imageCollection1.Images.SetKeyName(2, "Import.ico");
            this.imageCollection1.Images.SetKeyName(3, "Refresh.ico");
            this.imageCollection1.Images.SetKeyName(4, "FromReceipt.ico");
            this.imageCollection1.Images.SetKeyName(5, "Preferences.png");
            this.imageCollection1.Images.SetKeyName(6, "Goods Refund List.png");
            this.imageCollection1.Images.SetKeyName(7, "Customer List.jpg");
            this.imageCollection1.Images.SetKeyName(8, "New Item.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 49);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(773, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GUIMain
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.fld_tsOpenedModules);
            this.Controls.Add(this.dockSectionPanel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUIMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GUIMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUIMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fld_brmToolbarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockSectionManager)).EndInit();
            this.dockSectionPanel.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treelistManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navbarSectionManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        #region Public Properties
        public DevExpress.XtraNavBar.NavBarControl SectionManager
        {
            get
            {
                return navbarSectionManager;
            }
            set
            {
                navbarSectionManager = value;
            }
        }

        public ToolStrip OpenModulesToolStrip
        {
            get
            {
                return fld_tsOpenedModules;
            }
            set
            {
                fld_tsOpenedModules = value;
            }
        }

        public DevExpress.XtraTreeList.TreeList TreeListSectionManager
        {
            get
            {
                return treelistManager;
            }
            set
            {
                treelistManager = value;
            }
        }

        public int TreeListHotTrackID
        {
            get
            {
                return _treeListHotTrackID;
            }
            set
            {
                _treeListHotTrackID = value;
            }
        }

        /// <summary>
        /// Get main menu
        /// </summary>
        public DevExpress.XtraBars.Bar MainMenu
        {
            get
            {
                return fld_barMenu;
            }
        }
        /// <summary>
        /// Get toolbar
        /// </summary>
        public DevExpress.XtraBars.Bar Toolbar
        {
            get
            {
                return fld_barToolbar;
            }
        }

        public DevExpress.XtraBars.BarManager BarManager
        {
            get
            {
                return fld_barManager;
            }
        }
        #endregion


        #region Windows event handlers


        private void GUIMain_Load(object sender, System.EventArgs e)
        {
            BOSApp.LogOn();
            fld_tsOpenedModules.Visible = true;
        }

        private void fld_barmnuLogOff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(BaseLocalizedResources.ConfirmLogOffMessage, "#Message#", MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                == DialogResult.Yes)
            {
                BOSApp.LogOff();
            }
        }

        private void fld_barmnuExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Close program
            this.Close();
        }

        private void GUIMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BOSApp.CurrentUser != null)
            {
                int iADUserID = new ADUsersController().GetObjectIDByName(BOSApp.CurrentUser);
                GEUserAuditsController objGEUserAuditsController = new GEUserAuditsController();
                objGEUserAuditsController.DeleteGEUserAuditsByADUserID(iADUserID);
            }
        }

        /// <summary>
        /// Change style
        /// </summary>
        private void LookAndFeelBar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String strLookAndFeelStyle = e.Item.Tag.ToString();
            BOSApp.SetApplicationStyle(strLookAndFeelStyle, String.Empty);
            BOSApp.SaveUserStyle(strLookAndFeelStyle, String.Empty);
        }

        /// <summary>
        ///Change skin
        /// </summary>
        private void LookAndFeelSkin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String strLookAndFeelStyleSkin = e.Item.Tag.ToString();
            BOSApp.SetApplicationStyle("Skin", strLookAndFeelStyleSkin);
            BOSApp.SaveUserStyle("Skin", strLookAndFeelStyleSkin);
        }

        #endregion

        private void fld_barbtnMenuImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            guiExcelImport _guiExcelImport = new guiExcelImport();
            _guiExcelImport.Module = (BaseModuleERP)BOSApp.OpenModules[BOSApp.CurrentModule];
            _guiExcelImport.ShowDialog();
        }

        private void fld_barbtnMenuExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!String.IsNullOrEmpty(BOSApp.CurrentModule))
            {
                guiExcelExport _guiExceExport = new guiExcelExport();
                _guiExceExport.Module = (BaseModuleERP)BOSApp.OpenModules[BOSApp.CurrentModule];
                _guiExceExport.ShowDialog();
            }
            else
            {
                MessageBox.Show("There is no available data. Please open a module of which you want to export data.", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void fld_barbtnMenuExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void fld_barchkMenuToolbar_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fld_barchkMenuToolbar.Checked)
                fld_barToolbar.Visible = true;
            else
                fld_barToolbar.Visible = false;
        }

        private void fld_barchkMenuOpenModuleToolStrip_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fld_barchkMenuOpenModuleToolStrip.Checked)
                fld_tsOpenedModules.Visible = true;
            else
                fld_tsOpenedModules.Visible = false;
        }

        private void fld_barchkMenuStatusBar_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fld_barchkMenuStatusBar.Checked)
                barStatus.Visible = true;
            else
                barStatus.Visible = false;
        }

        private void fld_barbtnMenuCustomizeToolbar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            guiCustomizeToolbarForm customizeToolbarForm = new guiCustomizeToolbarForm();
            customizeToolbarForm.ShowDialog();
        }       
    }
}
