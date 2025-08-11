using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Xml;
using System.Configuration;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using DevExpress.XtraTreeList;
using BOSCommon;
using BOSLib;

namespace BOSERP
{
    /// <summary>
    /// BOSApp is the main class which manage all module,screens of BOS System
    /// </summary>
    public partial class BOSApp
    {
        #region Constants
        public const String cstUserGroupAdmin = "ADMIN";
        #endregion

        #region Static variables for BOS Application
        public static int NumOfOpenedModules = 5;
        public static String CurrentModule = String.Empty;
        public static GUIMain MainScreen;
        public static System.Windows.Forms.Form ActiveScreen;                             
        public static String CurrentLang;
        public static String CurrentUser;

        public static SortedList OpenModules = new SortedList();
        public static Assembly BOSERPAssembly;


        private static int _currentUserGroupID;
        private static ADUsersInfo _currentUsersInfo;
        private static ADUserGroupsInfo _currentUserGroupsInfo;
        private static CSCompanysInfo _currentCompanyInfo;
        public static ImageList ToolbarImageList= new ImageList();
        public static ImageList SectionImageList = new ImageList();

        private static SortedList _lookupTables;
        private static SortedList _lookupTableUpdatedDate;

        private static SortedList _fieldFormatGroups;
        private static int _priceDecimal = 2;
        #endregion     
   
        #region Properties
        public static ADUsersInfo CurrentUsersInfo
        {
            get
            {
                return _currentUsersInfo;
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
                return _currentUserGroupsInfo;
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

        /// <summary>
        /// Gets or sets the list of lookup table objects
        /// </summary>
        public static SortedList<string, GELookupTablesInfo> LookupTableObjects { get; set; }

        /// <summary>
        /// Gets or sets the the current language
        /// </summary>
        public static GELanguagesInfo CurrentLanguage { get; set; }
        #endregion

        #region Constant
        public const String cstTopResultsSearchControl = "fld_txtTopResults";
        public const int cstTopResults = 10000;
        #endregion

        #region Public Functions
        /// <summary>
        /// Init Main Form Title
        /// </summary>
        public static void InitMainFormTitle()
        {
            RegistryWorker regWoker = new RegistryWorker();
            regWoker.SubKey = "SOFTWARE\\BOS";
            String strCompanyName = regWoker.Read("CompanyName");

            MainScreen.Text = "BYS Clinic - Licensed to " + strCompanyName;
            MainScreen.Text += " - " + DateTime.Now.ToShortDateString();
            MainScreen.Text += " - " + CurrentUser;
            MainScreen.Text += "/" + new ADUserGroupsController().GetObjectNameByID(new ADUsersController().GetUserGroupOfUser(CurrentUser));
        }

        public static void InitLookupTables()
        {
            _lookupTables = new SortedList();
            _lookupTableUpdatedDate = new SortedList();
            _lookupTables.Clear();
            _lookupTableUpdatedDate.Clear();
            LookupTableObjects = new SortedList<string, GELookupTablesInfo>();

            BOSDbUtil dbUtil = new BOSDbUtil();
            GELookupTablesController objGELookupTablesController = new GELookupTablesController();
            DataSet dsLookupTables = objGELookupTablesController.GetAllObjects();
            if (dsLookupTables.Tables.Count > 0)
            {
                foreach (DataRow rowLookupTable in dsLookupTables.Tables[0].Rows)
                {
                    GELookupTablesInfo objGELookupTablesInfo = (GELookupTablesInfo)objGELookupTablesController.GetObjectFromDataRow(rowLookupTable);
                    if (objGELookupTablesInfo != null)
                    {
                        if (!LookupTableObjects.ContainsKey(objGELookupTablesInfo.GELookupTableName))
                        {
                            LookupTableObjects.Add(objGELookupTablesInfo.GELookupTableName, objGELookupTablesInfo);
                        }
                        if (dbUtil.IsExistTable(objGELookupTablesInfo.GELookupTableName))
                        {
                            _lookupTableUpdatedDate.Add(objGELookupTablesInfo.GELookupTableName, DateTime.Now);
                            BaseBusinessController objBusinessController = BusinessControllerFactory.GetBusinessController(objGELookupTablesInfo.GELookupTableName + "Controller");
                            if (objBusinessController != null)
                            {
                                DataSet ds = objBusinessController.GetAllObjects();
                                _lookupTables.Add(objGELookupTablesInfo.GELookupTableName, ds);
                                
                            }
                        }
                    }
                }
            }
        }

        public static void InitFieldFormatGroups()
        {
            FieldFormatGroups = new SortedList();
            STFieldFormatGroupsController objFieldFormatGroupsController = new STFieldFormatGroupsController();
            DataSet ds = objFieldFormatGroupsController.GetAllObjects();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    STFieldFormatGroupsInfo objFieldFormatGroupsInfo = (STFieldFormatGroupsInfo)objFieldFormatGroupsController.GetObjectFromDataRow(row);
                    if (objFieldFormatGroupsInfo != null)
                    {
                        FieldFormatGroups.Add(objFieldFormatGroupsInfo.STFieldFormatGroupID, objFieldFormatGroupsInfo);
                    }
                }
            }
        }

        public static void DisableActionToolbarOfOpenModules(String strCurrentModuleName)
        {
            foreach (String strModuleName in OpenModules.Keys)
            {
                if(!strModuleName.Equals(strCurrentModuleName))
                {
                    BaseModuleERP module = (BaseModuleERP)OpenModules[strModuleName];
                    if(module.ParentScreen.ToolbarManager.Bars[BaseToolbar.ToolbarAction]!=null)
                        module.ParentScreen.ToolbarManager.Bars[BaseToolbar.ToolbarAction].Visible = false;
                }
            }
        }

        public static void EnableActionToolbarOfOpenModules(String strCurrentModuleName)
        {
            foreach (String strModuleName in OpenModules.Keys)
            {
                if (!strModuleName.Equals(strCurrentModuleName))
                {
                    BaseModuleERP module = (BaseModuleERP)OpenModules[strModuleName];
                    if (module.ParentScreen.ToolbarManager.Bars[BaseToolbar.ToolbarAction] != null)
                        module.ParentScreen.ToolbarManager.Bars[BaseToolbar.ToolbarAction].Visible = true;
                }
            }
        }

        public static bool IsExistOpenModulesInAction()
        {
            foreach (String strModuleName in OpenModules.Keys)
            {
                BaseModuleERP module = (BaseModuleERP)OpenModules[strModuleName];
                if (!module.Toolbar.IsNullOrNoneAction())
                    return true;
            }
            return false;
        }


        #region Functions to Section Manager for Main Form
        public static void InitSectionManagerByCurrentUser(String strUserName)
        {
            ADUsersController objUserController = new ADUsersController();
            int iUserGroupID = objUserController.GetUserGroupOfUser(strUserName);
            ADUserGroupSectionsController objUserGroupSectionController = new ADUserGroupSectionsController();
            DataSet dsUserGroupSections = objUserGroupSectionController.GetUserGroupSectionByUserGroupID(iUserGroupID);
            if (dsUserGroupSections.Tables.Count > 0)
            {
                foreach (DataRow row in dsUserGroupSections.Tables[0].Rows)
                {
                    ADUserGroupSectionsInfo objADUserGroupSectionsInfo = (ADUserGroupSectionsInfo)objUserGroupSectionController.GetObjectFromDataRow(row);
                    DevExpress.XtraNavBar.NavBarGroup fld_navbarGroupApp = new DevExpress.XtraNavBar.NavBarGroup();
                    fld_navbarGroupApp.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    fld_navbarGroupApp.Appearance.Options.UseFont = true;
                    fld_navbarGroupApp.Caption = objADUserGroupSectionsInfo.ADUserGroupSectionName;
                    fld_navbarGroupApp.Expanded = true;
                    fld_navbarGroupApp.Name = "fld_navBarGroup" + objADUserGroupSectionsInfo.ADUserGroupSectionID;
                    AddModuleToGroupSection(fld_navbarGroupApp, objADUserGroupSectionsInfo.ADUserGroupSectionID);

                    BOSApp.MainScreen.SectionManager.Groups.Add(fld_navbarGroupApp);
                    BOSApp.MainScreen.SectionManager.ActiveGroup = BOSApp.MainScreen.SectionManager.Groups[0];
                }
            }
            dsUserGroupSections.Dispose();
        }

        public static void AddModuleToGroupSection(DevExpress.XtraNavBar.NavBarGroup fld_navBarGroupApp, int iUserGroupSectionID)
        {
            STModuleToUserGroupSectionsController objModuleToUserGroupSectionController = new STModuleToUserGroupSectionsController();
            DataSet dsModules = objModuleToUserGroupSectionController.GetDisplayedModulesByUserGroupSectionID(iUserGroupSectionID);
            if (dsModules.Tables.Count > 0)
            {
                foreach (DataRow row in dsModules.Tables[0].Rows)
                {
                    STModuleToUserGroupSectionsInfo objSTModuleToUserGroupSectionsInfo = (STModuleToUserGroupSectionsInfo)objModuleToUserGroupSectionController.GetObjectFromDataRow(row);

                    STModulesController objModuleController = new STModulesController();
                    STModulesInfo objModuleInfo = new STModulesInfo();
                    objModuleInfo = (STModulesInfo)objModuleController.GetObjectByID(objSTModuleToUserGroupSectionsInfo.STModuleID);
                    DevExpress.XtraNavBar.NavBarItem fld_navBarItemModule = new DevExpress.XtraNavBar.NavBarItem();
                    fld_navBarItemModule.Caption = new STModuleDescriptionsController().GetDescriptionByModuleNameAndLanguageName(objModuleInfo.STModuleName, BOSApp.CurrentLang);
                    fld_navBarItemModule.Name = "fld_navBar" + objModuleInfo.STModuleName;
                    fld_navBarItemModule.SmallImageIndex = BOSApp.SectionImageList.Images.IndexOfKey(objModuleInfo.STModuleName);
                    fld_navBarItemModule.Tag = objModuleInfo.STModuleName;
                    fld_navBarItemModule.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(ModuleItem_LinkClicked);

                    BOSApp.MainScreen.SectionManager.Items.Add(fld_navBarItemModule);
                    fld_navBarGroupApp.ItemLinks.Add(new DevExpress.XtraNavBar.NavBarItemLink(fld_navBarItemModule));
                }
            }
            dsModules.Dispose();
        }

        private static void ModuleItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (e.Link.Item.Tag.ToString().StartsWith("BOS_") == true)
            {
                String ProgName = "C:\\BOS\\exe\\" + e.Link.Item.Tag.ToString().Substring(6) + ".exe";

                if (System.IO.File.Exists(ProgName) == true)
                    System.Diagnostics.Process.Start(ProgName, "1 2 BB_##TEST");
                else
                    MessageBox.Show("Programm : " + ProgName + " nicht gefunden");

                return;
            }  
            ShowModule(e.Link.Item.Tag.ToString());
        }

        public static void SetActiveGroupByModule(String strModuleName)
        {
            DevExpress.XtraNavBar.NavBarItem moduleItem = BOSApp.MainScreen.SectionManager.Items["fld_navBar" + strModuleName];
            DevExpress.XtraNavBar.NavBarItemLink moduleItemLink = moduleItem.Links[0];
            BOSApp.MainScreen.SectionManager.ActiveGroup = moduleItemLink.Group;
            BOSApp.MainScreen.SectionManager.SelectedLink = moduleItemLink;
        }

        #endregion    

        #region Treelist
        private static void InitRootTreeListManagerByCurrentUser(String strUserName)
        {
            BOSApp.MainScreen.TreeListSectionManager.StateImageList = BOSApp.SectionImageList;

            ADUsersController objUserController = new ADUsersController();
            int iUserGroupID = objUserController.GetUserGroupOfUser(strUserName);
            ADUserGroupSectionsController objUserGroupSectionController = new ADUserGroupSectionsController();
            DataSet dsUserGroupSections = objUserGroupSectionController.GetUserGroupSectionByUserGroupID(iUserGroupID);
            if (dsUserGroupSections.Tables.Count > 0)
            {
                foreach (DataRow row in dsUserGroupSections.Tables[0].Rows)
                {
                    ADUserGroupSectionsInfo objADUserGroupSectionsInfo = (ADUserGroupSectionsInfo)objUserGroupSectionController.GetObjectFromDataRow(row);
                    DevExpress.XtraTreeList.Nodes.TreeListNode treelstNode = BOSApp.MainScreen.TreeListSectionManager.AppendNode(new object[] { objADUserGroupSectionsInfo.ADUserGroupSectionName }, null);
                    treelstNode.HasChildren = true;
                    AddModuleToChildNode(treelstNode, objADUserGroupSectionsInfo.ADUserGroupSectionID);
                }
            }
            dsUserGroupSections.Dispose();

            BOSApp.MainScreen.TreeListSectionManager.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(TreeListSectionManager_NodeCellStyle);
            BOSApp.MainScreen.TreeListSectionManager.MouseClick += new MouseEventHandler(TreeListSectionManager_MouseClick);
            BOSApp.MainScreen.TreeListSectionManager.MouseMove += new MouseEventHandler(TreeListSectionManager_MouseMove);
            BOSApp.MainScreen.TreeListSectionManager.MouseLeave += new EventHandler(TreeListSectionManager_MouseLeave);

            BOSApp.MainScreen.TreeListSectionManager.ExpandAll();
        }

        private static void AddModuleToChildNode(DevExpress.XtraTreeList.Nodes.TreeListNode treelstParent, int iUserGroupSectionID)
        {
            STModuleToUserGroupSectionsController objModuleToUserGroupSectionController = new STModuleToUserGroupSectionsController();
            DataSet dsModules = objModuleToUserGroupSectionController.GetDisplayedModulesByUserGroupSectionID(iUserGroupSectionID);
            if (dsModules.Tables.Count > 0)
            {
                foreach (DataRow row in dsModules.Tables[0].Rows)
                {
                    STModuleToUserGroupSectionsInfo objSTModuleToUserGroupSectionsInfo = (STModuleToUserGroupSectionsInfo)objModuleToUserGroupSectionController.GetObjectFromDataRow(row);

                    STModulesController objModuleController = new STModulesController();
                    STModulesInfo objModuleInfo = new STModulesInfo();
                    objModuleInfo = (STModulesInfo)objModuleController.GetObjectByID(objSTModuleToUserGroupSectionsInfo.STModuleID);

                    string strCaption = new STModuleDescriptionsController().GetDescriptionByModuleNameAndLanguageName(objModuleInfo.STModuleName, BOSApp.CurrentLang);
                    DevExpress.XtraTreeList.Nodes.TreeListNode treelstNode = BOSApp.MainScreen.TreeListSectionManager.AppendNode(new object[] { strCaption }, treelstParent);
                    treelstNode.HasChildren = false;
                    treelstNode.Tag = objModuleInfo.STModuleName;
                    treelstNode.StateImageIndex = BOSApp.SectionImageList.Images.IndexOfKey(objModuleInfo.STModuleName);
                }
            }
            dsModules.Dispose();
        }

        public static void SetActiveModuleByModuleName(String strModuleName)
        {
            BOSApp.MainScreen.TreeListHotTrackID = -1;
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode treeParentNode in BOSApp.MainScreen.TreeListSectionManager.Nodes)
            {
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode treeItemNode in treeParentNode.Nodes)
                {
                    if (treeItemNode.Tag.Equals(strModuleName))
                    {
                        treeParentNode.ExpandAll();
                        BOSApp.MainScreen.TreeListSectionManager.SetFocusedNode(treeItemNode);
                        return;
                    }
                }
            }
            BOSApp.MainScreen.TreeListSectionManager.Refresh();
        }

        private static void TreeListSectionManager_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag.ToString() == BOSApp.CurrentModule)
            {
                e.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Underline);
                e.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                e.Appearance.BackColor = Color.Yellow;
                e.Appearance.BackColor2 = Color.Tomato;
                return;
            }

            if (e.Node.Id == BOSApp.MainScreen.TreeListHotTrackID)
            {
                e.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
                e.Appearance.BackColor = Color.Transparent;
                e.Appearance.BackColor2 = Color.Orange;
                return;
            }

            if (e.Node.HasChildren)
            {
                Font tempfont = new Font("Tahoma", (float)10, FontStyle.Bold);
                e.Appearance.Font = tempfont;
                e.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                e.Appearance.BackColor = Color.Silver;
                e.Appearance.BackColor2 = Color.White;
                return;
            }
            else
            {
                e.Appearance.BackColor = Color.White;
                e.Appearance.BackColor2 = Color.White;
                return;
            }
        }

        private static void TreeListSectionManager_MouseClick(object sender, MouseEventArgs e)
        {
            TreeList treelst = (TreeList)sender;
            TreeListHitInfo treeHitInfo = treelst.CalcHitInfo(e.Location);
            if (treeHitInfo.Node != null)
            {
                if (treeHitInfo.Node.Tag != null)
                {
                    String strModuleName = treeHitInfo.Node.Tag.ToString();
                    if (!String.IsNullOrEmpty(strModuleName))
                    {
                        BOSApp.SetActiveModuleByModuleName(strModuleName);
                        ShowModule(strModuleName);
                    }
                }
            }
        }

        private static void TreeListSectionManager_MouseMove(object sender, MouseEventArgs e)
        {
            TreeList treelst = (TreeList)sender;
            TreeListHitInfo treeHitInfo = treelst.CalcHitInfo(e.Location);
            if (treeHitInfo.Node != null)
            {
                if (treeHitInfo.Node.Tag != null)
                {
                    BOSApp.MainScreen.TreeListHotTrackID = treeHitInfo.Node.Id;
                    BOSApp.MainScreen.TreeListSectionManager.Refresh();
                }

            }
        }

        private static void TreeListSectionManager_MouseLeave(object sender, EventArgs e)
        {
            BOSApp.MainScreen.TreeListHotTrackID = -1;
            BOSApp.MainScreen.TreeListSectionManager.Refresh();
        }
        #endregion       

        #region Utility Functions
        public static void InitToolbarImageList()
        {
            try
            {
                ToolbarImageList.Images.Clear();
                ToolbarImageList.ImageSize = new Size(16, 16);
                String strToolbarImagePath = Application.StartupPath + "\\img\\Toolbar";
                DirectoryInfo dir = new DirectoryInfo(strToolbarImagePath);
                foreach (FileInfo file in dir.GetFiles())
                {
                    if (file.Extension.ToLower() == ".ico" || file.Extension.ToLower() == ".png" || file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".bmp")
                    {
                        int index = file.Name.IndexOf(".");
                        if (index > 0)
                        {
                            String strKey = file.Name.Substring(0, index);
                            Image img = Image.FromFile(file.FullName);
                            ToolbarImageList.Images.Add(strKey, img);
                        }
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
                String strSectionImagePath = Application.StartupPath + "\\img\\Section";
                DirectoryInfo dir = new DirectoryInfo(strSectionImagePath);
                foreach (FileInfo file in dir.GetFiles())
                {
                    if (file.Extension.ToLower() == ".ico" || file.Extension.ToLower() == ".png" || file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".bmp")
                    {
                        int index = file.Name.IndexOf(".");
                        if (index > 0)
                        {
                            String strKey = file.Name.Substring(0, index);
                            Image img = Image.FromFile(file.FullName);
                            SectionImageList.Images.Add(strKey, img);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public static void SetApplicationStyle(String strLookAndFeelStyle, String strLookAndFeelStyleSkin)
        {
            if (strLookAndFeelStyle == "Skin")
            {
                if (!String.IsNullOrEmpty(strLookAndFeelStyleSkin))
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(strLookAndFeelStyleSkin);
                else
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Black");
            }
            else
            {
                DevExpress.LookAndFeel.LookAndFeelStyle style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
                try
                {
                    style = (DevExpress.LookAndFeel.LookAndFeelStyle)Enum.Parse(typeof(DevExpress.LookAndFeel.LookAndFeelStyle), strLookAndFeelStyle);
                }
                catch (Exception)
                {
                    style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
                }

                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetStyle(style, false, true);
            }
        }

        public static void SaveUserStyle(String strLookAndFeelStyle, String strLookAndFeelStyleSkin)
        {
            if (BOSApp.CurrentUsersInfo != null)
            {
                ADUsersController objUsersController = new ADUsersController();
                BOSApp.CurrentUsersInfo.ADUserStyle = strLookAndFeelStyle;
                BOSApp.CurrentUsersInfo.ADUserStyleSkin = strLookAndFeelStyleSkin;
                objUsersController.UpdateObject(BOSApp.CurrentUsersInfo);
            }
        }

        /// <summary>
        /// Init menu main form
        /// </summary>
        public static void InitMenuOfMainForm()
        {
            //Clear all existing items
            for (int i = 2; i < BOSApp.MainScreen.MainMenu.ItemLinks.Count - 2; i++)
            {
                BOSApp.MainScreen.MainMenu.ItemLinks.RemoveAt(i);
                i--;
            }

            //Add new items from database
            ADUsersController objUserController = new ADUsersController();
            int iUserGroupID = objUserController.GetUserGroupOfUser(BOSApp.CurrentUser);
            ADUserGroupSectionsController objUserGroupSectionController = new ADUserGroupSectionsController();
            DataSet dsUserGroupSections = objUserGroupSectionController.GetUserGroupSectionByUserGroupID(iUserGroupID);
            if (dsUserGroupSections.Tables.Count > 0)
            {
                for (int i = 0; i < dsUserGroupSections.Tables[0].Rows.Count; i++)
                {
                    ADUserGroupSectionsInfo objADUserGroupSectionsInfo = (ADUserGroupSectionsInfo)objUserGroupSectionController.GetObjectFromDataRow(dsUserGroupSections.Tables[0].Rows[i]);
                    DevExpress.XtraBars.BarSubItem item = new DevExpress.XtraBars.BarSubItem();
                    item.Caption = objADUserGroupSectionsInfo.ADUserGroupSectionName;
                    BOSApp.MainScreen.MainMenu.InsertItem(BOSApp.MainScreen.MainMenu.ItemLinks[2 + i], item);
                    item = AddSubMenuToMenuItem(item, objADUserGroupSectionsInfo.ADUserGroupSectionID);
                }
            }
        }

        /// <summary>
        /// Init sub menu to menu item
        /// </summary>
        public static DevExpress.XtraBars.BarSubItem AddSubMenuToMenuItem(DevExpress.XtraBars.BarSubItem menuItem, int userGroupSectionID)
        {
            STModuleToUserGroupSectionsController objSTModuleToUserGroupSectionsController =new STModuleToUserGroupSectionsController();
            DataSet dsModuleUserGroupSections = objSTModuleToUserGroupSectionsController.GetDisplayedModulesByUserGroupSectionID(userGroupSectionID);
            if (dsModuleUserGroupSections != null)
            {
                foreach (DataRow row in dsModuleUserGroupSections.Tables[0].Rows)
                {
                    STModuleToUserGroupSectionsInfo objSTModuleToUserGroupSectionsInfo = (STModuleToUserGroupSectionsInfo)objSTModuleToUserGroupSectionsController.GetObjectFromDataRow(row);
                    if (objSTModuleToUserGroupSectionsInfo != null)
                    {
                        STModulesInfo objSTModulesInfo = (STModulesInfo)new STModulesController().GetObjectByID(objSTModuleToUserGroupSectionsInfo.STModuleID);
                        STModuleDescriptionsController objModuleDescriptionsController = new STModuleDescriptionsController();
                        STModuleDescriptionsInfo objModuleDescriptionsInfo = (STModuleDescriptionsInfo)objModuleDescriptionsController.GetModuleDescriptionByModuleNameAndLanguageName(objSTModulesInfo.STModuleName, BOSApp.CurrentLang);
                        DevExpress.XtraBars.BarButtonItem subItem = new DevExpress.XtraBars.BarButtonItem();
                        subItem.Caption = objModuleDescriptionsInfo.STModuleDescriptionDescription;
                        subItem.Tag = objSTModulesInfo.STModuleID;
                        subItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(subItem_ItemClick);
                        menuItem.AddItem(subItem);
                    }
                }
            }
            return menuItem;
        }
        /// <summary>
        /// Init toolbar of main form
        /// </summary>
        public static void InitToolbarOfMainForm()
        {
            BOSApp.MainScreen.Toolbar.ClearLinks();
            STToolbarsController objToolbarsController = new STToolbarsController();
            DataSet ds = objToolbarsController.GetMainToolbar();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                STToolbarsInfo objToolbarsInfo = (STToolbarsInfo)objToolbarsController.GetObjectFromDataRow(row);
                if (objToolbarsInfo.STToolbarVisible == true)
                {
                    DevExpress.XtraBars.BarButtonItem toolbarItem = new DevExpress.XtraBars.BarButtonItem();
                    toolbarItem.Caption = objToolbarsInfo.STToolbarCaption;
                    toolbarItem.Name = objToolbarsInfo.STToolbarName;
                    toolbarItem.Tag = objToolbarsInfo.STToolbarID;
                    toolbarItem.LargeImageIndex = BOSApp.ToolbarImageList.Images.IndexOfKey(objToolbarsInfo.STToolbarImage);
                    toolbarItem.ImageIndex = BOSApp.ToolbarImageList.Images.IndexOfKey(objToolbarsInfo.STToolbarImage);
                    toolbarItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                    toolbarItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(toolbarItem_ItemClick);                    
                    BOSApp.MainScreen.Toolbar.AddItem(toolbarItem);
                }
            }
        }

        /// <summary>
        /// Show module when click submenu item.
        /// </summary>
        private static void subItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int moduleID = (int)e.Item.Tag;
            STModulesInfo objModuleInfo = (STModulesInfo)new STModulesController().GetObjectByID(moduleID);
            if (!String.IsNullOrEmpty(objModuleInfo.STModuleName))
            {
                BOSApp.SetActiveModuleByModuleName(objModuleInfo.STModuleName);
                ShowModule(objModuleInfo.STModuleName);
            }
        }

        /// <summary>
        /// Solve click event when user click on toolbar button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void toolbarItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            STToolbarsInfo objToolbarsInfo = (STToolbarsInfo)new STToolbarsController().GetObjectByID((int)e.Item.Tag);
            STToolbarFunctionsController objToolbarFunctionsController = new STToolbarFunctionsController();
            DataSet ds = objToolbarFunctionsController.GetAllDataByForeignColumn("STToolbarID", objToolbarsInfo.STToolbarID);
            
            BOSApp.SetActiveModuleByModuleName(objToolbarsInfo.STToolbarTag);
            BaseModuleERP currModule = null;
            if (objToolbarsInfo.STToolbarTag == "Common")
            {
                currModule = BaseModuleFactory.GetModule("Common");
            }
            else
            {
                 currModule = ShowModule(objToolbarsInfo.STToolbarTag);
            }
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                STToolbarFunctionsInfo objToolbarFucntionsInfo = (STToolbarFunctionsInfo)objToolbarFunctionsController.GetObjectFromDataRow(ds.Tables[0].Rows[0]);
                if (objToolbarFucntionsInfo != null)
                {
                    MethodInfo methodInfo = currModule.GetMethodInfoByMethodFullNameAndMethodClass(objToolbarFucntionsInfo.STToolbarFunctionName, objToolbarFucntionsInfo.STToolbarFunctionFullName, objToolbarFucntionsInfo.STToolbarFunctionClass);
                    if (methodInfo != null)
                        methodInfo.Invoke(currModule, null);
                }
            }
        }               
        #endregion

        public static void LogOn()
        {
            guiLogin _guiLogin = new guiLogin();
            _guiLogin.ShowDialog();
            if (_guiLogin.IsDisposed)
            {
                //Show welcome wizards
                //ShowWelcomeWizards();

                StartApplication();
            }
        }

        /// <summary>
        /// Start application
        /// </summary>
        public static void StartApplication()
        {
            //Set application style for current user
            ADUsersController objUsersController = new ADUsersController();
            ADUsersInfo objUsersInfo = (ADUsersInfo)objUsersController.GetObjectByName(BOSApp.CurrentUser);
            if (objUsersInfo != null)
                BOSApp.SetApplicationStyle(objUsersInfo.ADUserStyle, objUsersInfo.ADUserStyleSkin);
            //Set current user
            BOSApp.CurrentUsersInfo = objUsersInfo;

            //Init toolbar manager
            InitToolbarImageList();
            InitSectionImageList();
            MainScreen.BarManager.Images = ToolbarImageList;
            MainScreen.BarManager.LargeImages = ToolbarImageList;


            //InitRootTreeListManagerByCurrentUser(BOSApp.CurrentUser);
            InitSectionManagerByCurrentUser(BOSApp.CurrentUser);

            ADConfigValueUtility.InitGlobalConfigValueTables();
            InitMainFormTitle();

            InitLookupTables();

            InitFieldFormatGroups();

            _currentUserGroupID = new ADUsersController().GetUserGroupOfUser(BOSApp.CurrentUser);
            _currentUserGroupsInfo = (ADUserGroupsInfo)new ADUserGroupsController().GetObjectByID(_currentUserGroupID);

            //Get current company info
            CSCompanysController objCSCompanysController = new CSCompanysController();
            _currentCompanyInfo = (CSCompanysInfo)objCSCompanysController.GetFirstObject();

            //Init status bar items
            BOSApp.MainScreen.userItem.Caption = BOSApp.CurrentUserGroupInfo.ADUserGroupName + "\\" + BOSApp.CurrentUser;
            BOSApp.MainScreen.dateItem.Caption = DateTime.Now.ToShortDateString();

            //Init bars of main form
            InitMenuOfMainForm();
            InitToolbarOfMainForm();

            //Show home page                
            BOSApp.ShowModule(ModuleName.Home);
        }

        /// <summary>
        /// Show welcome wizards
        /// </summary>
        private static void ShowWelcomeWizards()
        {
            guiDepartmentWizard guiDepartmentWizard = new guiDepartmentWizard();
            guiDepartmentWizard.ShowDialog();
        }

        /// <summary>
        /// Log off BOS
        /// </summary>
        public static void LogOff()
        {          
            //Clear section manager and enable if current section manager is not enable
            BOSApp.MainScreen.SectionManager.Groups.Clear();
            BOSApp.MainScreen.SectionManager.Enabled = true;

            //Close all open modules,clear all in Open Module list and tool strip .Enable Open module tool strip
            CloseAllOpenModules();
            OpenModules.Clear();
            BOSApp.MainScreen.OpenModulesToolStrip.Items.Clear();
            BOSApp.MainScreen.OpenModulesToolStrip.Enabled = true;

            MainScreen.Text = ConfigurationManager.AppSettings["CompanyName"];            

            //Log on again
            LogOn();
        }

        /// <summary>
        /// Change password
        /// </summary>
        public static void ChangePassword()
        {
            guiChangePassword _guiChangePassword = new guiChangePassword();
            _guiChangePassword.ShowDialog();
            if (_guiChangePassword.IsDisposed)
            {
                //Log off again
                LogOff();
            }
        }

        public static void ChangePassword(String strUserName, String strNewPassword)
        {
            ADUsersController objADUsersController = new ADUsersController();
            ADUsersInfo objADUsersInfo = new ADUsersInfo();
            objADUsersInfo = (ADUsersInfo)objADUsersController.GetObjectByName(strUserName.ToLower());
            if (objADUsersInfo != null)
            {
                String _encodedPassword = Convert.ToBase64String(SHA1Managed.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(strNewPassword)));
                objADUsersInfo.ADPassword = _encodedPassword;
                objADUsersController.UpdateObject(objADUsersInfo);
            }
        }

        /// <summary>
        /// Show Module with module Name
        /// </summary>
        /// <param name="strModuleName">Module Name</param>
        public static BaseModuleERP ShowModule(String strModuleName)
        {
            BaseModuleERP currModule = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //Show new module                   
                //If module will be show is in Opened Module List, get this module and show
                if (BOSApp.IsOpenedModule(strModuleName))
                {
                    currModule = ((BaseModuleERP)BOSApp.OpenModules[strModuleName]);
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
            catch (Exception)
            {
                return null;
            }
            return currModule;
        }

        /// <summary>
        /// Show module have already exist on Opend Modules List
        /// </summary>
        /// <param name="strModuleName"></param>
        public static void ShowOpenedModule(String strModuleName)
        {
            ToolStripButton tsbtnModule = (ToolStripButton)BOSApp.MainScreen.OpenModulesToolStrip.Items[strModuleName];
            CheckOpenModuleToolStripButton(tsbtnModule);
            BaseModuleERP module = (BaseModuleERP)BOSApp.OpenModules[strModuleName];            
            module.ParentScreen.Activate();
        }

        /// <summary>
        /// Show new module
        /// </summary>
        /// <param name="module"></param>
        public static void ShowNewModule(BaseModuleERP module)
        {
            AddOpenModuleToOpenModulesToolStrip(module.Name);
            module.Show();
        }

        /// <summary>
        /// Populate ToolStrip Button for open module
        /// </summary>
        /// <param name="strModuleName">Name of Module will be populated to toolstrip button</param>
        /// <returns></returns>
        private static ToolStripButton PopulateOpenModulesToolStripButton(String strModuleName)
        {
            String strModuleDesc = new STModuleDescriptionsController().GetDescriptionByModuleNameAndLanguageName(strModuleName, BOSApp.CurrentLang);
            if (String.IsNullOrEmpty(strModuleDesc))
                strModuleDesc = strModuleName;

            ToolStripButton tsbtnOpenModules = new ToolStripButton(strModuleDesc, BOSApp.SectionImageList.Images[strModuleName], OpenModulesToolStrip_Click, strModuleName);            
            tsbtnOpenModules.TextImageRelation = TextImageRelation.ImageBeforeText;
            tsbtnOpenModules.CheckOnClick = true;
            return tsbtnOpenModules;
        }



        /// <summary>
        /// Set toolstripbutton of Open Module to checked
        /// </summary>
        /// <param name="tsbtnModule"></param>
        public static void CheckOpenModuleToolStripButton(ToolStripButton tsbtnModule)
        {
            tsbtnModule.Checked = true;
            foreach (ToolStripButton tsbtnOpenedModule in BOSApp.MainScreen.OpenModulesToolStrip.Items)
            {
                if (tsbtnOpenedModule.Name != tsbtnModule.Name)
                    tsbtnOpenedModule.Checked = false;
            }
        }

        
        /// <summary>
        /// Delegate function for event click of Toolstrip Button Open Module
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">Event Arugment</param>
        private static void OpenModulesToolStrip_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbtnModule = (ToolStripButton)sender;
            CheckOpenModuleToolStripButton(tsbtnModule);
            ShowModule(tsbtnModule.Name);
            //SetActiveGroupByModule(tsbtnModule.Name);
        }        


        /// <summary>
        /// Add open module to Open Modules Tool Strip
        /// </summary>
        /// <param name="strModuleName">Name of module will be added</param>
        public static void AddOpenModuleToOpenModulesToolStrip(String strModuleName)
        {
            ToolStripButton tsbtnModule = PopulateOpenModulesToolStripButton(strModuleName);
            BOSApp.MainScreen.OpenModulesToolStrip.Items.Add(tsbtnModule);
            tsbtnModule.Visible = true;
            CheckOpenModuleToolStripButton(tsbtnModule);
        }


        /// <summary>
        /// Check the module is opened before or not
        /// </summary>
        /// <param name="strModuleName">Name of module is checked</param>
        /// <returns>true if is opened before, otherwise return false</returns>
        public static bool IsOpenedModule(String strModuleName)
        {
            return OpenModules.ContainsKey(strModuleName);
        }

        /// <summary>
        /// Add new or update module into Opened Module list
        /// </summary>
        /// <param name="module">module will be added new or updated</param>
        public static void UpdateOpenedModule(BaseModuleERP module)
        {
            if (!IsOpenedModule(module.Name))
            {
                OpenModules.Add(module.Name, module);
            }
            else
                OpenModules[module.Name] = module;
        }

        /// <summary>
        /// Remove module from Opened Module list
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
        /// Remove module from Opened module list
        /// </summary>
        /// <param name="strModuleName">Module name will be removed</param>
        public static void RemoveOpenedModule(String strModuleName)
        {
            if (IsOpenedModule(strModuleName))
                OpenModules.Remove(strModuleName);
        }        
       

        public static void CloseAllOpenModules()
        {
            for (int i = 0; i < OpenModules.Count; i++)
            {
                BaseModuleERP module = (BaseModuleERP)OpenModules.GetByIndex(i);
                module.ParentScreen.Close();
                i--;
            }            
        }              

        #endregion        

        #region Authentication
        public static bool IsAuthenticated(String strUserName, String strPassword)
        {
            ADUsersController objADUsersController = new ADUsersController();
            ADUsersInfo objADUsersInfo = new ADUsersInfo();
            objADUsersInfo = (ADUsersInfo)objADUsersController.GetObjectByName(strUserName.ToLower());
            if (objADUsersInfo != null)
            {
                String _encodedPassword = Convert.ToBase64String(SHA1Managed.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(strPassword)));
                if (_encodedPassword.Equals(objADUsersInfo.ADPassword))
                    return true;

            }
            return false;
        }

        public static bool IsUserLoggedIn(String strUserName)
        {
            //Get iADUserID
            ADUsersController objADUsersController = new ADUsersController();
            int iADUserID = objADUsersController.GetObjectIDByName(strUserName);

            GEUserAuditsController objGEUserAuditsController = new GEUserAuditsController();
            return objGEUserAuditsController.IsExistUser(iADUserID);
        }

        public static void SetCurrentUserLogin(string strUserName)
        {
            ADUsersController objADUsersController = new ADUsersController();
            ADUsersInfo objADUsersInfo = new ADUsersInfo();
            objADUsersInfo = (ADUsersInfo)objADUsersController.GetObjectByName(strUserName);
            if (objADUsersInfo != null)
            {
                BOSApp.CurrentUser = objADUsersInfo.ADUserName;
                GELanguagesController objLanguageController = new GELanguagesController();
                GELanguagesInfo objLanguageInfo = new GELanguagesInfo();
                int iLanguageID = ((ADUserGroupsInfo)new ADUserGroupsController().GetObjectByID(objADUsersController.GetUserGroupOfUser(objADUsersInfo.ADUserID))).ADLanguageIDCombo;
                objLanguageInfo = (GELanguagesInfo)objLanguageController.GetObjectByID(iLanguageID);
                if (objLanguageInfo != null)
                    BOSApp.CurrentLang = objLanguageInfo.GELanguageName.Trim();
            }
        }
        #endregion

        public static void SetAppLanguage(int languageID)
        {
            GELanguagesController objLanguagesController = new GELanguagesController();
            GELanguagesInfo objLanguagesInfo = (GELanguagesInfo)objLanguagesController.GetObjectByID(languageID);
            if (objLanguagesInfo != null)
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(objLanguagesInfo.GELanguageCultur);
                CurrentLanguage = objLanguagesInfo;
            }
        }
    }
        
}
